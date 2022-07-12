'
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
'
Module ModReps
   '
   Public Const crptToWindow = 0
   Public Const crptToPrinter = 1
   Public Const crptToMail = 2
   '
   Function ImprimirCrp(ByVal Reporte As String, ByVal Destino As Clases.DestinoReportes, ByVal Filtro As String, ByVal Titulo As String, Optional ByVal Formulas As Object = "", Optional ByVal SubReporte As String = "", Optional ByVal FiltroSub As String = "", Optional ByVal Copias As Byte = 1, Optional ByVal Parametros As Object = "") As Boolean
      '
      If Destino = Clases.DestinoReportes.eMail Then
         Return CrpCrearPdf(Reporte, Filtro, Formulas, SubReporte, FiltroSub)
      End If
      '
      If InStr(LCase(Reporte), ".rpt") = 0 Then
         Reporte = Reporte & ".Rpt"
      End If
      '
      If Dir(Application.StartupPath & "\Report\" & Reporte) <> "" Then
         Reporte = Application.StartupPath & "\Report\" & Reporte
      Else
         If InStr(Reporte, "\") = 0 Then
            Reporte = RPT & "\" & Reporte
         End If
      End If
      '
      Dim Rep As New frmReporte
      '
      With Rep
         .Titulo = Titulo
         .Filtro = Filtro
         .Reporte = Reporte
         .Formulas = Formulas
         .Show()
      End With
      '
      Return True
      '
   End Function
   '
   Function CrpCrearPdf(ByVal Reporte As String, ByVal Filtro As String, Optional ByVal Formulas As Object = "", Optional ByVal SubReporte As String = "", Optional ByVal FiltroSub As String = "") As Boolean
      '
      Dim Adjunto As String = Reporte & ".pdf"
      '
      If InStr(LCase(Reporte), ".rpt") = 0 Then
         Reporte = Reporte & ".Rpt"
      End If
      '
      If Dir(Application.StartupPath & "\Report\" & Reporte) <> "" Then
         Reporte = Application.StartupPath & "\Report\" & Reporte
      Else
         If InStr(Reporte, "\") = 0 Then
            Reporte = RPT & "\" & Reporte
         End If
      End If
      '
      Dim cryRpt As New ReportDocument
      Dim crtableLogoninfos As New TableLogOnInfos
      Dim crtableLogoninfo As New TableLogOnInfo
      Dim crConnectionInfo As New ConnectionInfo
      Dim CrTables As Tables
      Dim CrTable As Table
      Dim i As Byte
      '
      Try
         '
         If InStr(LCase(Reporte), ".rpt") = 0 Then
            Reporte += ".Rpt"
         End If
         '
         If InStr(Reporte, "\") = 0 Then
            Reporte = RPT & "\" & Reporte
         End If
         '
         If Dir(Reporte) = "" Then
            MensajeTrad("ReporteNE")
            Return False
         Else
            '
            With cryRpt
               .Load(Reporte)
               If Filtro <> "" Then
                  .RecordSelectionFormula = Filtro
               End If
               If TypeOf Formulas Is String(,) Then
                  For i = 0 To (Formulas.Length / 2) - 1
                     .DataDefinition.FormulaFields(Formulas(i, 0)).Text = "'" & Formulas(i, 1) & "'"
                  Next i
               End If
            End With
            '
            If InStr(Reporte, "\Report\") <> 0 Then
               With crConnectionInfo
                  .IntegratedSecurity = TrustedCnx
                  .ServerName = Svr
                  .DatabaseName = DBN
                  If Not TrustedCnx Then
                     .UserID = Uid
                     .Password = Pwd
                  End If
               End With
               '
               CrTables = cryRpt.Database.Tables
               For Each CrTable In CrTables
                  crtableLogoninfo = CrTable.LogOnInfo
                  crtableLogoninfo.ConnectionInfo = crConnectionInfo
                  CrTable.ApplyLogOnInfo(crtableLogoninfo)
               Next
               '
            End If

            cryRpt.VerifyDatabase()
            cryRpt.Refresh()
            cryRpt.ExportToDisk(ExportFormatType.PortableDocFormat, Adjunto)
            cryRpt.Close()

            Return True

         End If
         '
      Catch ex As Exception
         '
         Dim st As New StackTrace(True)
         RegistrarError(st, "ModReps.CrpEnviarMail")
         Return False
         '
      End Try
      '
   End Function
   '
   Sub GenRepFact(ByVal VentaId As Long, ByVal Titulo As String, ByVal Destino As Clases.DestinoReportes, Optional ByRef ListaPDF As Object = "")
      '
      Dim Cmd As New OleDb.OleDbCommand
      Dim Drd As OleDb.OleDbDataReader
      Dim Letra As String = ""
      Dim Sucursal As Int16 = 0
      Dim Numero As Int32 = 0
      '
      With Cmd
         .Connection = Cn
         .CommandText = "Select FactLetra, Sucursal, FactNumero FROM Ventas WHERE VentaId = " & VentaId
         Drd = .ExecuteReader
      End With
      '
      With Drd
         If .Read Then
            Letra = !FactLetra
            Sucursal = !Sucursal
            Numero = !FactNumero
         End If
         .Close()
      End With
      '
      GenRepFact(Letra, Sucursal, Numero, Titulo, Destino)
      '
   End Sub
   '
   Sub GenRepFact(ByVal Letra As String, ByVal Sucursal As Integer, ByVal Numero As Long, ByVal Titulo As String, ByVal Destino As Clases.DestinoReportes, Optional ByRef ListaPDF As Object = "")
      '
      Dim Filtro As String
      Dim Reporte As String
      '
      Reporte = IIf(Letra = "A", "FacturaA", "FacturaB")
      Filtro = "{Ventas.Tipo} = '" & Letra & "' AND " &
               "{Ventas.Sucursal} = " & Sucursal & " AND " &
               "{Ventas.Numero} = " & Numero
      '
      If ImprimirCrp(Reporte, Destino, Filtro, "Venta") Then
         If ListaPDF.ToString() <> "" Then
            ListaPDF.add(Reporte & ".pdf")
         End If
      End If
      '
   End Sub
   '
   Sub ImprimirRemito(ByVal RemitoId As Long)
      '
      Dim Reporte As String
      Dim Filtro As String
      Dim Formulas() As String    ' Array ' New Collection
      '
      Reporte = "Remito"
      Filtro = "{Remitos.RemitoID} = " & RemitoId
      'Formula.Add("Empresa = """ & Empresa & """")
      'Formula.Add("Sucursal = """ & prmDSucursal & """")
      '
      ImprimirCrp(Reporte, "P", Filtro, "Remito", Formulas)
      '
   End Sub
   '
   Sub ImprimirRecibo(ByVal CobroID As Long)
      '
      Dim Trn As OleDb.OleDbTransaction
      Dim Cmd As New OleDb.OleDbCommand
      '
      Dim Reporte As String
      Dim Filtro As String
      Dim Formulas(2, 1) As String '(Array) ' New Collection
      Dim CobNumero As Long
      Dim Letra As String
      Dim Total As Double
      Dim CantCH As Integer
      '
      CobNumero = CapturaDato(Cn, "Cobros", "CobNumero", "CobroID = " & CobroID)
      Letra = CapturaDato(Cn, "Cobros", "CobLetra", "CobroID = " & CobroID)
      Total = CapturaDato(Cn, "Cobros", "Total", "CobroID = " & CobroID)
      CantCH = CapturaDato(Cn, "CobrosDetCh", "COUNT(1)", "CobroID = " & CobroID)
      Reporte = "Recibo"
      Filtro = "{Cobros.CobroID} = " & CobroID
      '
      Formulas(0, 0) = "Empresa" : Formulas(0, 1) = "'" & Empresa & "'"
      Formulas(1, 0) = "Sucursal" : Formulas(1, 1) = "'" & prmDSucursal & "'"
      Formulas(2, 0) = "SonPesos" : Formulas(2, 1) = "'Son Pesos: " & Numero_a_Texto(Total) & ".-'"
      '
      ImprimirCrp(Reporte, cfgDestinoCmp, "", "RECIBO", Formulas)
      '
      Trn = Cn.BeginTransaction
      '
      With cmd
         .Connection = Cn
         .Transaction = Trn
         .CommandText = "UPDATE Cobros SET Estado = 1 WHERE CobroID = " & CobroID
         .ExecuteNonQuery()
         .CommandText = "UPDATE Sucursales SET Recibo" & Letra & " = " & CobNumero & " " & _
                        "WHERE Sucursal = " & prmSucursal & _
                        "  AND Recibo" & Letra & " < " & CobNumero
         .ExecuteNonQuery()
      End With
      '
      Trn.Commit()
      '
   End Sub
   '
   Sub ImprimirLiqPropiet(Numero As Int32, destino As Clases.DestinoReportes)
      'Dim NroLiq As Long
      Dim Adelanto As Boolean
      Dim Resumen As Boolean
      Dim NroRet As Long
      Dim Estado As Byte
      Dim cTipoIva As String = CapturaDato(Cn, "TipoIva", "Descrip", "Codigo = (SELECT Valor FROM Config WHERE Clave = 'cfgIvaEmp')")
      Dim cTelEmp As String = CapturaDato(Cn, "Config", "Valor", "Clave = 'cfgTelEmp'")
      Dim Rs2 As New OleDb.OleDbCommand
      Dim Total As Double
      Dim Periodo, Letra As String
      Dim eMail As String
      Dim ListaPDF As New Collection
      Dim Sucursal As Integer
      Dim FactNro As Long
      '
      Dim Cmd As New OleDb.OleDbCommand
      Dim Drd As OleDb.OleDbDataReader
      '
      With Cmd
         .Connection = Cn
         .CommandText = "SELECT L.*, RIGHT(L.Periodo,2) + '/' + LEFT(L.Periodo,4) AS Per, " &
                        " (SELECT SUM(Retenido) FROM RetGcias WHERE LiqPropiet = L.Numero) AS RetGan, R.Numero AS NroRet, P.eMail " &
                        "FROM LiqPropiet L INNER JOIN Propietarios P ON L.Propietario = P.Codigo " &
                        "                  LEFT JOIN RetGcias R ON L.Numero = R.LiqPropiet " &
                        "WHERE L.Numero = " & Numero
         Drd = .ExecuteReader
      End With
      '
      With Drd
         If .Read Then
            Estado = .Item("Estado")
            'NroLiq = Val(.SelectedCells(.Columns("Numero").Index).Value & "")
            Periodo = .Item("Per")
            Total = .Item("Total")
            eMail = .Item("eMail")
            Letra = .Item("Tipo")
            Sucursal = .Item("Sucursal")
            FactNro = .Item("Factura")
            NroRet = Val(.Item("NroRet") & "")
            .Close()
         Else
            .Close()
            Mensaje("Liq. Propiet. Nº " & Numero & ", no encontrada !")
            Exit Sub
         End If
      End With
      '
      If Estado = Clases.EstadoLiq.Anulado Then
         MensajeTrad("LiqAnulada")
         Exit Sub
      Else
         'Me.Cursor = Cursors.WaitCursor
         With Cmd
            .CommandText = "DELETE FROM LiqAux WHERE Usuario = '" & Uid & "' AND LqxPC = '" & NombrePC & "'"
            .ExecuteNonQuery()
            .CommandText = "INSERT INTO LiqAux( Recibe, Cuit, TipoIva, Telefono, SonPesos, Periodo, Usuario, LqxPC, Numero) " &
                           "VALUES('" & cfgNomEmp & "', " &
                                  "'" & cfgCuitEmp & "', " &
                                  "'" & cTipoIva & "', " &
                                  "'" & cTelEmp & "', " &
                                  "'" & Numero_a_Texto(Total) & "', " &
                                  "'" & Periodo & "', " &
                                  "'" & Uid & "', " &
                                  "'" & NombrePC & "', " &
                                        Numero & ")"
            .ExecuteNonQuery()
         End With
         '
         Adelanto = IIf(IsNothing(CapturaDato(Cn, "LiqInqDet", "Concepto", "Tipo = 'L' AND Sucursal = " & prmSucursal & " AND Numero = " & Numero & " AND Concepto = '" & cfgCodigoAdl & "'")), False, True)
         Resumen = IIf(IsNothing(CapturaDato(Cn, "LiqPropietAg", "Numero", "Numero = " & Numero)), False, True)
         '
         GenRepLiqPro(Numero, destino, Adelanto, Resumen, ListaPDF)
         '
         If NroRet > 0 Then
            GenRepRetGan(NroRet, destino, ListaPDF)
         End If
         '
         If FactNro <> 0 Then
            If cfgGenFactCom Then
               GenRepFact(Letra, Sucursal, FactNro, "Factura", destino.ToString, ListaPDF)
            End If
         End If
         '
         'Me.Cursor = Cursors.Default
         '
         If destino = Clases.DestinoReportes.eMail Then
            With FrmEnviarEmail
               .Asunto = "Liquidación N° " & Numero
               .CtaDestino = eMail
               .Cuerpo = "Ajuntamos archivos de liquidacion."
               .Adjuntos = ListaPDF
               .ShowDialog()
            End With
         End If
      End If
   End Sub
   '
   Sub GenRepLiqPro(ByVal Num As Long, ByVal Destino As Clases.DestinoReportes, Optional ByVal Adelanto As Boolean = False, Optional ByVal Resumen As Boolean = False, Optional ByRef ListaPDF As Object = "")
      '
      Dim Reporte As String
      Dim Filtro As String
      Dim Formulas() As String
      Dim Titulo As String = IIf(Resumen, "Resumen ", "") & "Liq. Propietario Nº " & Num
      Dim Cuerpo As String = "Adjunto Liquidación."
      '
      Reporte = IIf(Resumen, "LiqPropietAg", IIf(Adelanto, "LiqPropietAdl", IIf(Destino = Clases.DestinoReportes.eMail, "LiqPropiet", "LiqPropietDupl")))
      '
      If Resumen Then
         Filtro = "{LiqPropietAg.Numero} = " & Num & " AND {LiqAux.Usuario} = '" & Uid & "' AND {LiqAux.LqxPC} = '" & NombrePC & "'"
      Else
         Filtro = "{LiqPropiet.Numero} = " & Num & " AND {LiqAux.Usuario} = '" & Uid & "' AND {LiqAux.LqxPC} = '" & NombrePC & "'"
         If Adelanto Then
            Filtro = Filtro & " AND {LiqInqDet.Tipo} = 'L'"
         Else
            If ExisteDato(Cn, "LiqPropietDet", "Numero = " & Num) Then
               Reporte = "LiqPropietDet"
            End If
         End If
      End If
      '
      'If Destino = Clases.DestinoReportes.eMail Then
      '   If CuentaDest = "" Then
      '      Mensaje("Cuenta destino vacía !")
      '   Else
      '      If CrpEnviarMail(Reporte, CuentaDest, Filtro, Titulo, Cuerpo, Formulas) Then
      '         Mensaje(Titulo & " enviado a: " & CuentaDest)
      '      End If
      '   End If
      'Else
      '
      If ImprimirCrp(Reporte, Destino, Filtro, Titulo, Formulas) Then
         If ListaPDF.ToString() <> "" Then
            ListaPDF.add(Reporte & ".pdf")
         End If
      End If
      'End If
      '
      If Adelanto Then
         Reporte = "LiqPropietAdlAut"
         Filtro = "{LiqPropiet.Numero} = " & Num & " AND {LiqInqDet.Tipo} = 'L'"
         'Cuerpo = "Adjunto Autorización."
         'If Destino = Clases.DestinoReportes.eMail Then
         '   If CuentaDest <> "" Then
         '      CrpEnviarMail(Reporte, CuentaDest, Filtro, Titulo, Cuerpo, Formulas)
         '   End If
         'Else
         If ImprimirCrp(Reporte, Destino, Filtro, Titulo, Formulas) Then
            If ListaPDF.ToString() <> "" Then
               ListaPDF.add(Reporte & ".pdf")
            End If
         End If
         '
      End If
      '
   End Sub
   '
   Sub GenRepRetGan(ByVal NroRet As Long, ByVal Destino As Clases.DestinoReportes, Optional ByRef ListaPDF As Object = "")
      '
      Dim Reporte As String
      Dim Filtro As String
      Dim Formulas(1, 1) As String   ' Array ' New Collection
      Dim Titulo As String = "Retención Ganancias N° " & NroRet
      Dim Cuerpo As String = "Adjunto Retención."
      '
      Reporte = "RetGcias"
      Filtro = "{RetGcias.Numero} = " & NroRet
      '
      Formulas(0, 0) = "Domicilio" : Formulas(0, 1) = cfgDomEmp & ", " & cfgLocEmp
      Formulas(1, 0) = "CUIT" : Formulas(1, 1) = cfgCuitEmp
      '
      'If Destino < 2 Then
      If ImprimirCrp(Reporte, Destino, Filtro, Titulo, Formulas) Then
         If ListaPDF.ToString() <> "" Then
            ListaPDF.add(Reporte & ".pdf")
         End If
      End If
      'Else
      '   If CuentaDest = "" Then
      '      Mensaje("Cuenta destino vacía !")
      '   Else
      '      If CrpEnviarMail(Reporte, CuentaDest, Filtro, Titulo, Cuerpo, Formulas) Then
      '         Mensaje(Titulo & " enviado a: " & CuentaDest)
      '      End If
      '   End If
      'End If
      '
   End Sub
   '
   Sub GenRepContrato(ByVal NroCtto As Long, ByVal Tit As String)
      ImprimirCrp("Contrato", crptToWindow, "{Contratos.Numero}=" & NroCtto, "Contrato")
   End Sub
   '
   Sub GenRepLiqInq(ByVal Tipo As String, ByVal Sucursal As Integer, ByVal Numero As Long, ByVal Titulo As String, Optional ByVal Destino As Clases.DestinoReportes = 0)
      '
      Dim Filtro As String
      Dim Reporte As String
      Dim Estado As Byte
      Dim LiqInqId, LicId As Int32
      Dim Cmd As New OleDb.OleDbCommand
      Dim Drd As OleDb.OleDbDataReader
      '
      Reporte = IIf(Tipo = "A", "RboInqA.rpt", IIf(Tipo = "B", "RboInqB.rpt", "ReciboX.rpt"))
      '
      Filtro = "{LiqInqCab.Tipo} = '" & Tipo & "' AND " &
               "{LiqInqCab.Sucursal} = " & Sucursal & " AND " &
               "{LiqInqCab.Numero} = " & Numero & " AND " &
               "{LiqAux.Usuario} = '" & Uid & "' AND " &
               "{LiqAux.Numero} = " & Numero
      '
      If Destino = Clases.DestinoReportes.Window Then
         ImprimirCrp(Reporte, Destino, Filtro, "Recibo")
      Else
         Imprimir(Reporte, Filtro, "")
      End If
      '
      'ChReciboID = Val(CapturaDato(Cn, "LiqInqCab", "ChReciboID", "LiqInqCab.Tipo = '" & Tipo & "' AND LiqInqCab.Sucursal = " & Sucursal & " AND LiqInqCab.Numero = " & Numero) & "")
      '
      LiqInqId = Val(CapturaDato(Cn, "LiqInqCab", "LiqInqId", "LiqInqCab.Tipo = '" & Tipo & "' AND LiqInqCab.Sucursal = " & Sucursal & " AND LiqInqCab.Numero = " & Numero) & "")
      Estado = CapturaDato(Cn, "LiqInqCab", "Estado", "LiqInqId = " & LiqInqId)
      LicId = Val(CapturaDato(Cn, "LiqInqCobDet", "LicId", "LiqInqId = " & LiqInqId) & "")
      '
      If LicId <> 0 Then
         If MsgConfirma("Imprime detalle del Cobro") Then
            If Estado = 0 Then
               ImprimirCrp("LiqInqDetCob", Destino, "{LiqInqCob.LicId} = " & LicId, "Detalle de Cobro")
            Else
               With Cmd
                  .Connection = Cn
                  .CommandText = "SELECT LicId FROM LiqInqCobDet WHERE LiqInqId = " & LiqInqId
                  Drd = .ExecuteReader
               End With
               With Drd
                  While .Read()
                     ImprimirCrp("LiqInqConf", IIf(prmVistPrevLiq, crptToWindow, crptToPrinter), "{LiqInqCob.LicId} = " & !LicId, "Detalle del Cobro")
                  End While
                  .Close()
               End With
            End If
         End If
         End If
      '
   End Sub
   '
   Sub GenRepOrdPago(Cmp As String, Sucursal As Integer, Numero As Long, Titulo As String, Optional Destino As Byte = 0)
      '
      Dim Reporte As String
      Dim Filtro As String
      Dim OpAgrup As Boolean
      '
      OpAgrup = (CapturaDato(Cn, "OrdenPago O, OrdenPagoDet D", "ProComprob", "O.OpNumero = " & Numero & " AND O.OrdenPagoId = D.OrdenPagoId") = "PO")
      '
      Reporte = IIf(Cmp = "OP", "OrdPago", IIf(Cmp = "PC", "OrdPago", IIf(OpAgrup, "OrdPagoOtrAg", "OrdPagoOtr")))
      '
      If Cmp = "OP" Or Cmp = "PO" Then
         Filtro = "{OrdenPago.Sucursal} = " & Sucursal & " AND " & _
                  "{OrdenPago.OPNumero} = " & Numero
      Else
         Filtro = "{Pagos.Comprob} = '" & Cmp & "' AND " & _
                  "{Pagos.Sucursal} = " & Sucursal & " AND " & _
                  "{Pagos.Numero}   = " & Numero
      End If
      '
      ImprimirCrp(Reporte, crptToWindow, Filtro, "Orden de Pago")
      '
   End Sub
   '
   Sub Imprimir(Reporte As String, Filtro As String, Formulas As Object)
      '
      Dim cryRpt As New ReportDocument
      Dim i As Byte
      '
      If Reporte = "" Then
         MensajeTrad("DDReporte")
         Exit Sub
      End If
      '
      With cryRpt
         .Load(Reporte)
         .RecordSelectionFormula = Filtro
         If TypeOf Formulas Is String(,) Then
            If Formulas.Length > 0 Then
               For i = 0 To (Formulas.Length / 2) - 1
                  .DataDefinition.FormulaFields(Formulas(i, 0)).Text = "'" & Formulas(i, 1) & "'"
               Next i
            End If
         End If
         .PrintToPrinter(1, False, 0, 0)
      End With
      '
   End Sub
   '
   Sub ImprimirRboOtr(Tipo As String, Sucursal As Int16, Numero As Int32)
      '
      Dim Rs As New OleDb.OleDbCommand
      Dim Drd As OleDb.OleDbDataReader
      '
      Dim Filtro As String
      Dim Reporte As String
      Dim Total As Double
      '
      Reporte = IIf(Tipo = "A", "RboOtrosA.rpt", "RboOtrosB.rpt")
      '
      Filtro = "{CobrosOtr.Tipo} = '" & Tipo & "' AND " & _
               "{CobrosOtr.Sucursal} = " & Sucursal & " AND " & _
               "{CobrosOtr.Numero} = " & Numero & " AND " & _
               "{LiqAux.Usuario} = '" & Uid & "'"
      '
      With Rs
         .Connection = Cn
         .CommandText = "SELECT Efectivo+Cheques AS Total FROM CobrosOtr WHERE Tipo = '" & Tipo & "' AND Sucursal = " & Sucursal & " AND Numero = " & Numero
         Drd = .ExecuteReader
         With Drd
            If .Read Then
               Total = !Total
            End If
            .Close()
         End With
         '
         .CommandText = "DELETE FROM LiqAux WHERE Usuario = '" & Uid & "' AND Numero = " & Numero
         .ExecuteNonQuery()
         '
         .CommandText = "INSERT INTO LiqAux( Usuario, Recibe, SonPesos, Numero) " & _
                        "VALUES('" & Uid & "', '" & cfgNomEmp & "', '" & Numero_a_Texto(Total) & "', " & Numero & ")"
         .ExecuteNonQuery()
         '
      End With
      '
      ImprimirCrp(Reporte, cfgDestinoRep, Filtro, "Recibo")
      '
   End Sub
   '
End Module
