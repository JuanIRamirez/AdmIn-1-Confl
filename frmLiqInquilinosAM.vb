Public Class frmLiqInquilinosAM
   '
   Dim Trn As OleDb.OleDbTransaction
   Dim Cmd As New OleDb.OleDbCommand
   Dim Drd As OleDb.OleDbDataReader
   Dim Cm2 As New OleDb.OleDbCommand
   '
   Dim adcLiqProp As New DataGridView
   '
   Dim Inquilino As Int32
   Dim Propiedad As Int32
   Dim Propietario As Int32
   '
   Dim nTotConc As Double
   Dim nSdoAnt As Double
   Dim nIntAnt As Double
   Dim nIntereses As Double
   Dim nTotal As Double
   Dim nTotCobro As Double
   Dim nSaldo As Double
   Dim dFecAnt As Date = Today
   Dim nMesPago As Integer
   Dim DiaVenc As Integer
   Dim cPeriodo As String
   Dim PerMaxIndex As Integer
   '
   Dim VerifConc As Boolean
   '
   Dim cCtaInq As String
   Dim cCtaInt As String
   Dim cCtaInt3 As String
   Dim nPrdInt As Integer = 0
   Dim cDescInt As String
   Dim cCtaCaja As String
   Dim cCtaCajaAd As String
   Dim cCtaVCar As String
   Dim cCtaVCar3 As String
   Dim cCtaRGan As String
   Dim cDescRGan As String
   '
   Dim cObserv As String
   Dim LiqPend As Boolean
   Dim TotLiqProp As Double
   Dim vImpAlq As Double
   Dim cTmp As String
   Dim LiqInqTrID As Long
   Dim NroSeña As New Collection
   Dim FechaInt As Date
   Dim AgRetGan As Boolean
   '
   Const cmpInt = "LI"
   Const cStruct = "Banco0 INT NOT NULL, " &
                   "Cuenta0 VarChar(25) NOT NULL, " &
                   "Titular VarChar(50) NOT NULL, " &
                   "Banco1 INT NOT NULL, " &
                   "Cuenta1 VarChar(25) NOT NULL, " &
                   "FechaTR SmallDateTime NOT NULL, " &
                   "NumeroTR VarChar(25) NOT NULL, " &
                   "ImporteTR FLOAT NOT NULL, " &
                   "GastosImp FLOAT NULL, " &
                   "GastosSF FLOAT NULL, " &
                   "GastosIva FLOAT NULL, " &
                   "ImporteNeto FLOAT NULL"
   '
   Private Sub frmLiqInquilinosAM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      '
      GetRegForm(Me)
      '
      TraducirForm(Me)
      '
      If CaptCtasConc(cfgCodigoVCar, "", cCtaVCar, cCtaVCar3) Then
         If CaptCtasConc(cfgCodigoInt, cDescInt, cCtaInt, cCtaInt3, nPrdInt) Then
            If CaptCtasConc(cfgCodigoRGan, cDescRGan, cCtaRGan, "") Then
               VerifConc = True
            End If
         End If
      End If
      '
      If Not VerifConc Then DeshabForm(Me)
      '
      cTmp = ""
      If Not CrearTabla(Cn, cStruct, cTmp) Then
         DeshabForm(Me)
      End If
      '
      If FechaIncorrecta() Then
         DeshabForm(Me)
      End If
      '
      ArmaComboItem(cbInquilino, "Inquilinos", , "Nombre", "Nombre", "(Seleccionar)", "Estado = 'A' AND Codigo IN( SELECT DISTINCT Inquilino FROM FactInq WHERE Saldo <> 0)")
      '
      FechaInt = Today
      '
      With Cmd
         .Connection = Cn
         .CommandText = "SELECT * FROM Cajas WHERE Caja = " & prmNroCaja
         Drd = .ExecuteReader
         With Drd
            If .Read Then
               If IsDBNull(!Cuenta) Or IsDBNull(!CtaAdm) Then
                  MensajeTrad("CtaCajaNoAsig")
                  DeshabForm(Me)
                  Exit Sub
               End If
               cCtaCaja = !Cuenta
               cCtaCajaAd = !CtaAdm
            Else
               MensajeTrad("CajaNoDef")
               DeshabForm(Me)
            End If
            .Close()
         End With
      End With
      '
      LimpiaTmp()
      '
      ActData()
      '
   End Sub
   '
   Private Sub frmLiqInquilino_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
      TabReturn(e.KeyChar)
   End Sub
   '
   Private Sub cmdCancSeña_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancSeña.Click
      With frmLiqInquilinosCS
         .Inquilino = Inquilino
         .NroSeña = NroSeña
         .ShowDialog()
         NroSeña.Add(.Numero)
         ActData()
         CalcImportes()
      End With
   End Sub
   '
   Private Sub cmdTransferencia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTransferencia.Click
      Dim Frm As New frmLiqTransf
      With Frm
         .TablaTmp = cTmp
         .TransfRec = True
         .ShowDialog(Me)
         tbTransferencia.Text = Format(.Total, "Fixed")
         CalcSaldo()
      End With
   End Sub
   '
   Private Sub LimpiaTmp()
      If Not SLL Then
         Trn = Cn.BeginTransaction
         With Cmd
            .Transaction = Trn
            .CommandText = "DELETE FROM ChReciboTmp WHERE Usuario = '" & Uid & "' AND PC = '" & NombrePC & "'"
            .ExecuteNonQuery()
            '
            .CommandText = "DELETE FROM " & cTmp
            .ExecuteNonQuery()
            '
         End With
         Trn.Commit()
      End If
   End Sub
   '
   Private Sub cbPeriodo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbPeriodo.SelectedIndexChanged
      With cbPeriodo
         If .SelectedIndex > PerMaxIndex Then .SelectedIndex = PerMaxIndex
         cPeriodo = .Text.Substring(3, 4) & .Text.Substring(0, 2)
         nMesPago = Val(CapturaDato(Cn, "FactInq", "MesPago", "Inquilino = " & Inquilino & " AND (Propiedad = " & Propiedad & " OR Propiedad = 0) AND Saldo <> 0") & "")
      End With
   End Sub
   '
   Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
      '
      Dim ImpAlq As Double
      Dim ContMes As Integer
      '
      If Not Validar1() Then Exit Sub
      '
      If cbPeriodo.Text = "" Then
         MensajeTrad("DSelPeriodo")
         cbPeriodo.Focus()
         Exit Sub
      End If
      '
      If SumaMes("01/" & cbPeriodo.Text, cfgLiqVenCur * -1) > Today Then
         If MsgBox(Traducir("PerNoVenc"), vbOKCancel + vbInformation) = vbCancel Then
            cbPeriodo.Focus()
            Exit Sub
         End If
      End If
      '
      If cObserv <> "" Then
         If cObserv <> "." Then
            If cObserv <> vbCrLf Then
               MsgBox(cObserv, vbInformation)
            End If
         End If
      End If
      '
      ActSdoIntAnt(cPeriodo, Propiedad, Inquilino, nSdoAnt, nIntAnt, dFecAnt)
      '
      With Cmd
         .CommandText = "SELECT * FROM ConsDepart WHERE Propiedad = '" & Propiedad & "'"
         Drd = .ExecuteReader
         With Drd
            If .Read Then
               AgrConsConc(!Consorcio, cPeriodo, DiaVenc)
               ActConsDFac(!Consorcio, cPeriodo, "", !Propiedad, Inquilino, !Porcent)
            End If
            .Close()
         End With
      End With
      '
      'Nuevo 23/07/2005.
      LiqPend = CapturaDato(Cn, "LiqInqCab", "COUNT(1)",
                                "Inquilino = " & Inquilino & " AND " &
                                "Propiedad = " & Propiedad & " AND " &
                                "Estado = 3")
      '
      With Cmd
         .CommandText = "SELECT Importe " &
                        "FROM FactInq F " &
                        "WHERE F.Concepto = '" & cfgCodigoAlq & "' " &
                        "  AND F.Inquilino = " & Inquilino & " " &
                        "  AND F.Propiedad = " & Propiedad & " " &
                        "  AND F.Fecha <= '" & Format(CDate("10/" & cbPeriodo.Text), FormatFecha) & "' " &
                        "ORDER BY F.Fecha DESC"
         Drd = .ExecuteReader
         With Drd
            ContMes = 0
            Do While .Read
               If ContMes = 0 Then
                  ImpAlq = !Importe
                  ContMes = 1
               End If
               If ImpAlq = !Importe Then
                  ContMes = ContMes + 1
               Else
                  Exit Do
               End If
            Loop
            .Close()
         End With
      End With
      '
      If ContMes >= 6 Then
         MsgBox("Hace " & ContMes & " meses que no se actualiza el Importe de Alquiler", vbInformation)
      End If
      '
      If CapturaDato(Cn, "Inquilinos", "DocPend", "Codigo = " & Inquilino) Then
         MsgBox("Inquilino con DOCUMENTACION PENDIENTE !", vbInformation)
      End If
      '
      If LiqPend = 0 Then
         cmdGenerar.Enabled = True
      Else
         MsgBox("Inquilino con Recibos Pendientes." & vbCrLf &
                "No podrá generar Recibos", vbInformation)
         cmdGenerar.Enabled = False
      End If
      '
      ActData()
      tbIntDiario.Text = Format(cfgIntDiario, "Fixed")
      LimpiaTmp()
      ActivaCtrl(True)
      CalcImportes()
      '
      VerifAdelanto()
      If TotLiqProp <> 0 Then
         optAdmin.Checked = True
      Else
         optPropiet.Checked = True
      End If
      '
      tbEfectivo.Focus()
      '
   End Sub
   '
   Private Sub ActivaCtrl(ByVal Activo As Boolean)
      '
      Dim Ctrl As Control
      '
      cmdIngCheques.Enabled = Activo
      cmdGenerar.Enabled = Activo And LiqPend = 0   'Nuevo 23/07/2005.
      cmdPendiente.Enabled = Activo
      cmdCancelar.Enabled = Activo
      '
      cmdAceptar.Enabled = Not Activo
      'Me.CancelButton = IIf(Activo, cmdCancelar, cmdSalir)
      '
      For Each Ctrl In Me.Controls
         If TypeOf Ctrl Is ComboBox Then
            Ctrl.Enabled = Not Activo
         End If
      Next Ctrl
      '
      lblObserv.Enabled = Activo
      tbDetalle.Enabled = Activo
      cmdCancSeña.Enabled = Activo
      gbPago.Enabled = Activo
      gbIntereses.Enabled = Activo
      '
      tbRetencion.Enabled = AgRetGan
      tbRetencNro.Enabled = AgRetGan
      '
   End Sub
   '
   Private Sub cmdGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGenerar.Click
      Generar(False)
   End Sub
   '
   Private Sub cmdPendiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPendiente.Click
      Generar(True)
   End Sub
   '
   Private Sub Generar(ByVal Pendiente As Boolean)
      '
      Dim cTipo As String
      Dim nSuc As Integer
      Dim nNum As Long
      '
      Dim AlicIva1 As Single
      Dim AlicIva2 As Single
      Dim TipoIva As String = ""
      Dim Letra As String = ""
      Dim cCtaPro As String
      Dim cCtaAdl As String
      Dim NroLiqProp As Long
      Dim ImpAdl As Double
      '
      If Not Validar1() Then Exit Sub
      If Not Validar2() Then Exit Sub
      '
      If Guardar(Pendiente) Then
         '
         cTipo = lblLetra.Text
         nSuc = Val(tbSucursal.Text)
         nNum = Val(tbNumero.Text)
         ImpAdl = TotLiqProp
         '
         VerifAdelanto()
         '
         If adcLiqProp.RowCount > 0 And Math.Abs(TotLiqProp) > 0 And Math.Abs(TotLiqProp) <= 0.01 Then
            If MsgConfirma("Cancela adelanto propietario") Then
               CapturaIva(Propietario, TipoIva, Letra, AlicIva1, AlicIva2)
               cCtaPro = CapturaDato(Cn, "Propietarios", "Cuenta", "Codigo = " & Propietario)
               cCtaAdl = CapturaDato(Cn, "Propietarios", "CtaAdl", "Codigo = " & Propietario)
               NroLiqProp = GuardarLiqProp(Propietario, cPeriodo, Propiedad, 0, 0, 0, 0, Letra, 0, 0, "",
                                           0, 0, 0, 0, 0, 0, 0, 0, 0, 0, adcLiqProp, False, ImpAdl, 0, 0, 0,
                                           cCtaPro, cCtaAdl, "", "", "", "", "", "", "", "", 0, "", TipoIva, "", "", 0, 0, "")
            End If
         End If
         '
         If NroLiqProp > 0 Then
            GenRepLiqPro(NroLiqProp, crptToWindow)
            ActLiqAux(True)
         End If
         '
         Cancelar()
         '
         GenRepLiqInq(cTipo, nSuc, nNum, Me.Text, IIf(prmVistPrevLiq, crptToWindow, crptToPrinter))
         '
      End If
      '
   End Sub
   '
   Private Function Validar1() As Boolean
      '
      If cbInquilino.Text = "" Or Inquilino = 0 Then
         MensajeTrad("DIInquilino")
         cbInquilino.Focus()
         Exit Function
      End If
      '
      If cbPropiedad.Text = "" Or Propiedad = 0 Then
         If UCase(Sistema) <> "RSISQL2" Then
            MensajeTrad("DIPropiedad")
            cbPropiedad.Focus()
            Exit Function
         End If
      End If
      '
      Validar1 = True
      '
   End Function
   '
   Private Function Validar2() As Boolean
      '
      If Math.Round(nSaldo, 3) = Math.Round(nTotal, 3) Then
         If Math.Round(nTotal, 3) > 0 Then
            Mensaje("Debe ingresar Efectivo, Cheques o Transferencia")
            tbEfectivo.Focus()
            Return False
         Else
            If nTotConc <> 0 Then
               If Math.Round(nSaldo, 0) <> 0 Then
                  Mensaje("Total pago en cero")
                  Return False
               End If
            End If
         End If
      ElseIf Math.Round(nSaldo, 2) < 0 Then
         If Not MsgConfirma(Traducir("SdoAFavor") & ", " & Traducir("Continúa")) Then
            tbEfectivo.Focus()
            Return False
         End If
      End If
      '
      Return True
      '
   End Function
   '
   Sub ActData()
      '
      Dim cSql As String
      Dim cCols As String
      Dim cFrom As String
      Dim cWhere As String
      Dim cSeñas As String = ""
      Dim i As Int16
      '
      cCols = "F.Fecha, F.Concepto, F.Detalle, F.Importe, F.aPropiet, F.MesPago, C.Prioridad, C.Comision, F.Imputacion, F.Propiedad, F.FactInqID "
      cFrom = "FactInq F LEFT JOIN Conceptos C ON F.Concepto = C.Codigo "
      cWhere = "F.Periodo = '" & cPeriodo & "' AND " &
               "F.Inquilino = " & Inquilino & " AND " &
               "(Propiedad = " & Propiedad & " OR Propiedad = 0) AND " &
               "Saldo <> 0 "
      '
      For i = 1 To NroSeña.Count
         cSeñas = cSeñas & IIf(cSeñas = "", "", ",") & NroSeña.Item(i)
      Next i
      '
      If cSeñas = "" Then cSeñas = "0"
      '
      cSql = "SELECT " & cCols & ", F.Saldo AS Debe, 0 AS Haber " &
             "FROM " & cFrom &
             "WHERE " & cWhere & " AND F.Imputacion = 'D' " &
             "UNION " &
             "SELECT " & cCols & ", 0 AS Debe, F.Saldo AS Haber " &
             "FROM " & cFrom &
             "WHERE " & cWhere & " AND F.Imputacion = 'H' " &
             "UNION " &
             "SELECT C.Fecha, 'SEÑ' AS Concepto, 'SEÑA', C.Total, 0, 1, 0 AS Prioridad, 0, 'H' AS Imputacion, 0, 0, 0, C.Total " &
             "FROM CobrosOtr C WHERE Numero IN (" & cSeñas & ") " &
             "ORDER BY Imputacion DESC, Prioridad, Fecha, Concepto"
      '
      SetRegGrid(Me, DataGridView1)
      '
      LlenarGrid(DataGridView1, cSql)
      '
      SetCols()
      '
      GetRegGrid(Me, DataGridView1)
      '
   End Sub
   '
   Private Sub SetCols()
      '
      With DataGridView1
         For Each Col As DataGridViewColumn In .Columns
            With Col
               Select Case UCase(.Name)
                  Case "FECHA" : .Width = 100
                  Case "CONCEPTO" : .Width = 80
                  Case "DETALLE" : .Width = 450
                  Case "IMPORTE" : .Width = 100 : .DefaultCellStyle.Format = "#,##0.00 " : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                  Case "DEBE" : .Width = 100 : .DefaultCellStyle.Format = "#,##0.00 " : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                  Case "HABER" : .Width = 100 : .DefaultCellStyle.Format = "#,##0.00 " : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                  Case Else : .Visible = False
               End Select
            End With
         Next Col
      End With
      '
   End Sub
   '
   'Private Sub btnQuitarConc_Click(sender As Object, e As EventArgs)
   '   With DataGridView1
   '      If .RowCount > 0 Then
   '         .Rows.Remove(.CurrentRow)
   '      End If
   '   End With
   'End Sub
   '
   Private Sub cmdIngCheques_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIngCheques.Click
      Dim Frm As New frmLiqInquilinosCH
      With Frm
         .ShowDialog(Me)
         tbCheques.Text = Format(.Total, "Fixed")
         FechaInt = .FechaDif
         CalcImportes()
      End With
   End Sub
   '
   Private Sub CalcImportes()
      '
      Dim i As Int16
      Dim dFecIni As Date
      Dim Comision As Boolean
      '
      nTotConc = 0
      nIntereses = 0
      '
      With DataGridView1
         If .RowCount > 0 Then
            For i = 0 To .RowCount - 1
               nTotConc = nTotConc + Val(.Item("Debe", i).Value & "") - Val(.Item("Haber", i).Value & "")
               If IsDBNull(.Item("Comision", i).Value) Then
                  Comision = False
               Else
                  Comision = .Item("Comision", i).Value
               End If
               If Comision Then
                  If .Item("Fecha", i).Value < Today Then
                     dFecIni = "01/" & Month(.Item("Fecha", i).Value) & "/" & Year(.Item("Fecha", i).Value)
                     nIntereses = nIntereses + CalcInteres(.Item("Debe", i).Value - .Item("Haber", i).Value, dFecIni, FechaInt, Val(tbIntDiario.Text))
                  End If
               End If
            Next i
         End If
      End With
      '
      nIntereses = nIntereses - nIntAnt
      If nIntereses < 0 Then nIntereses = 0
      nIntereses = Math.Round(nIntereses + CalcInteres(nSdoAnt, dFecAnt, FechaInt, Val(tbIntDiario.Text)), 2)
      If nIntereses < 0 Then nIntereses = 0
      '
      tbSdoAnt.Text = Format(nSdoAnt, "Fixed")
      tbFecAnt.Value = dFecAnt
      tbIntereses.Text = Format(nIntereses, "Fixed")
      '
      nTotal = nTotConc + nSdoAnt + nIntereses
      '
      tbTotConc.Text = Format(nTotConc, "Fixed")
      tbTotal.Text = Format(nTotal, "Fixed")
      '
      CalcSaldo()
      '
   End Sub
   '
   Private Sub cbInquilino_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbInquilino.SelectedIndexChanged
      '
      With cbInquilino
         If .SelectedIndex > 0 Then
            Inquilino = .SelectedValue
         Else
            Inquilino = 0
         End If
      End With
      '
      If Inquilino > 0 Then
         With Cmd
            .CommandText = "SELECT * FROM Inquilinos WHERE Codigo = " & Inquilino
            Drd = .ExecuteReader
            With Drd
               '
               If .Read Then
                  If !Estado = "I" Then
                     MensajeTrad("InqInactivo")
                     cbInquilino.SelectedIndex = -1
                     .Close()
                     Exit Sub
                  Else
                     If SisContable Then
                        If IsDBNull(!Cuenta) Then
                           MensajeTrad("CtaInqNoAsig")
                           cbInquilino.SelectedIndex = -1
                           .Close()
                           Exit Sub
                        End If
                        cCtaInq = IIf(cfgCtaInqUnica, cfgCtaMadreInq, !Cuenta)
                     End If
                     cObserv = !Observaciones & ""
                     AgRetGan = !AgRetGan
                     '
                     If cfgImpRboX Then
                        lblLetra.Text = "X"
                     Else
                        lblLetra.Text = CapturaDato(Cn, "TipoIva", "RecibeComp", "Codigo = '" & !TipoIva & "'").ToString.Substring(0, 1)
                        If lblLetra.Text = "" Then
                           MensajeTrad("TIvaNoEnc")
                           cbInquilino.SelectedIndex = -1
                           .Close()
                           Exit Sub
                        End If
                     End If
                     'tbNumero = Format(CaptNroRecibo(lblletra, Val(tbSucursal)), "00000000")
                  End If
               Else
                  MensajeTrad("InqNoEnc")
                  cbInquilino.SelectedIndex = -1
                  .Close()
                  Exit Sub
               End If
               .Close()
            End With
         End With
      End If
      '
      If Inquilino > 0 Then
         '
         ArmaComboItem(cbPropiedad, "Propiedades", , "Domicilio", "Domicilio", "(Seleccionar)", "Codigo IN( SELECT DISTINCT Propiedad FROM FactInq WHERE Inquilino = " & Inquilino & " AND Saldo <> 0 )")
         '
         With cbPropiedad
            If .Items.Count = 1 Then
               ArmaCombo(cbPeriodo, "RIGHT(Periodo,2) + '/' + LEFT(Periodo,4)", "FactInq", "Periodo", "Propiedad = 0 And Inquilino = " & Inquilino, , , True)
               With cbPeriodo
                  If .Items.Count = 1 Then .SelectedIndex = 0
               End With
            ElseIf .Items.Count = 2 Then
               .SelectedIndex = 1
            End If
         End With
      End If
      '
   End Sub
   '
   Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
      Cancelar()
   End Sub
   '
   Private Sub Cancelar()
      '
      Dim i As Int16
      '
      ActivaCtrl(False)
      '
      Limpiacampos(Me, cbInquilino.Name)
      nSdoAnt = 0
      For i = NroSeña.Count To 1 Step -1
         NroSeña.Remove(i)
      Next i
      '
      Propietario = 0
      cbPropiedad.SelectedIndex = 0
      cPeriodo = ""
      '
      tbEfectivo.Text = ""
      tbCheques.Text = ""
      tbTransferencia.Text = ""
      tbRetencNro.Text = ""
      tbRetencion.Text = ""
      '
      LimpiaTmp()
      ActData()
      CalcImportes()
      '
      lblAdelProp.Text = ""
      TotLiqProp = 0
      FechaInt = Today
      '
      cbInquilino.Focus()
      '
   End Sub
   '
   Private Sub cbPropiedad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbPropiedad.SelectedIndexChanged
      '
      Dim i As Integer
      '
      With cbPropiedad
         If .SelectedIndex > 0 Then
            Propiedad = .SelectedValue
         Else
            Propiedad = 0
         End If
      End With
      '
      Propietario = Val(CapturaDato(Cn, "Propiedades", "Propietario", "Codigo = " & Propiedad) & "")
      tbPropietario.Text = CapturaDato(Cn, "Propietarios", "Nombre", "Codigo = " & Propietario)
      '
      With Cmd
         .CommandText = "SELECT MIN(Periodo), Max(Periodo) FROM FactInq " &
                        "WHERE Inquilino = " & Inquilino &
                        "  AND (Propiedad = " & Propiedad & " OR Propiedad = 0)" &
                        "  AND Saldo <> 0"
         Drd = .ExecuteReader
         With Drd
            If .Read Then
               If IsDBNull(.Item(0)) Then
                  cbPeriodo.Items.Clear()
               Else
                  ArmaComboPer(cbPeriodo, .Item(0), .Item(1), )
               End If
               ''DiaVenc = .Fields(2)
               DiaVenc = 10
            Else
               .Close()
               MensajeTrad("ContratoNoEnc")
               cbPropiedad.SelectedIndex = -1
               Exit Sub
            End If
            .Close()
         End With
         '
         .CommandText = "SELECT * FROM FactInq " &
                        "WHERE Inquilino = " & Inquilino &
                        "  AND (Propiedad = " & Propiedad & " OR Propiedad = 0)" &
                        "  AND Saldo <> 0 " &
                        "ORDER BY Periodo"
         Drd = .ExecuteReader
         With Drd
            Do While .Read
               For i = 0 To cbPeriodo.Items.Count - 1
                  If cbPeriodo.Items.Item(i) = !Periodo.ToString.Substring(4, 2) + "/" + !Periodo.ToString.Substring(0, 4) Then
                     PerMaxIndex = i
                     cbPeriodo.SelectedIndex = i
                     cPeriodo = !Periodo
                     Exit Do
                  End If
               Next i
            Loop
            .Close()
         End With
         If cbPropiedad.Items.Count = 0 Then
            MensajeTrad("InqSinFact")
         End If
      End With
      '
      CaptNumeros()
      '
   End Sub
   '
   Private Sub CaptNumeros(Optional ByVal Tr As Object = "")
      tbSucursal.Text = Format(prmSucursal, "0000")
      tbNumero.Text = Format(CaptNroRecibo(lblLetra.Text, Val(tbSucursal.Text), Tr), "00000000")
   End Sub
   '
   Private Sub tbIntDiario_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbIntDiario.KeyPress
      SoloNumeros(e.KeyChar, True)
   End Sub
   '
   Private Sub tbIntDiario_LostFocus(sender As Object, e As EventArgs) Handles tbIntDiario.LostFocus
      If Val(tbIntDiario.Text) > cfgIntDiaMax Or
         Val(tbIntDiario.Text) < cfgIntDiaMin Then
         MensajeTrad("Int><Rango")
         tbIntDiario.Text = Format(cfgIntDiario, "Fixed")
         tbIntDiario.Focus()
      End If
      CalcImportes()
   End Sub
   '
   Private Sub tbCheques_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbCheques.TextChanged
      CalcSaldo()
   End Sub
   '
   Private Sub tbEfectivo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbEfectivo.TextChanged
      CalcSaldo()
   End Sub

   Private Sub tbRetencion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbRetencion.KeyPress
      SoloNumeros(e.KeyChar, True)
   End Sub
   '
   'Private Sub tbBonos_Change()
   '   CalcSaldo()
   'End Sub
   '
   Private Sub tbRetencion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbRetencion.TextChanged
      CalcSaldo()
   End Sub
   '
   Private Sub tbEfectivo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbEfectivo.KeyPress
      SoloNumeros(e.KeyChar, True)
   End Sub
   '
   'Private Sub tbBonos_KeyPress(ByVal KeyAscii As Integer)
   '   SoloNumeros(KeyAscii, True)
   'End Sub
   '
   Private Sub CalcSaldo()
      nTotCobro = Val(tbEfectivo.Text) + Val(tbCheques.Text) + Val(tbRetencion.Text) + Val(tbTransferencia.Text)
      nSaldo = nTotal - nTotCobro
      tbTotCobro.Text = Format(nTotCobro, "Fixed")
      tbSaldo.Text = Format(nSaldo, "Fixed")
   End Sub
   '
   Private Function Guardar(ByVal Pendiente As Boolean) As Boolean
      '
      Dim Renglon As Integer
      Dim aPropiet As Boolean = False
      Dim cComprob As String
      Dim cDetCaja As String
      Dim nSdoPago As Double
      Dim nSdoActu As Double
      Dim nSdoItem As Double
      Dim nPagItem As Double
      Dim nIntPago As Double
      Dim nImpCaja As Double
      Dim Efectivo As Double
      Dim nImpCajaAd As Double
      Dim cCtaBanco As String
      Dim nBanco As Long
      Dim cCuenta As String
      Dim i As Integer
      Dim n As Byte = 0
      '
      Dim NroCtto As Long
      Dim NroAsi As Long
      Dim RenASi As Integer
      Dim DetAsi As String
      Dim DetChs As String = ""
      Dim ChReciboID As Long
      Dim LiqInqId As Long
      Dim nTipo As Integer
      Dim cNumero As String
      Dim LicId, ChCartId As Int32
      Dim FechaFin As Date
      '
      Try
         '
         Trn = Cn.BeginTransaction
         '
         CaptNumeros(Trn)
         '
         cComprob = cmpInt & "-" & lblLetra.Text & "-" & Val(tbSucursal.Text) & "-" & Val(tbNumero.Text)
         DetAsi = Traducir("Recibo Inq.", , Trn) & " Nº " & Val(tbNumero.Text) & "-" & cbInquilino.Text
         cDetCaja = DetAsi
         Efectivo = Val(tbEfectivo.Text)
         '
         Cmd.Transaction = Trn
         Cm2.Transaction = Trn
         Cm2.Connection = Cn
         '
         With DataGridView1
            If .RowCount > 0 Then
               For i = 0 To .RowCount - 1
                  If .Item("aPropiet", i).Value Then
                     aPropiet = .Item("aPropiet", i).Value
                     Exit For
                  End If
               Next i
            End If
         End With
         '
         GuardarNroRecibo(lblLetra.Text, Val(tbNumero.Text), Trn)
         '
         nSdoPago = Val(tbTotCobro.Text) - Val(tbSdoAnt.Text)
         nSdoActu = IIf(nSaldo > 0, 0, nSaldo)
         '
         With DataGridView1
            If .RowCount > 0 Then
               For i = 0 To .RowCount - 1
                  If nSdoPago > 0 Then
                     If nIntPago < nIntereses Then
                        If nPrdInt <= Val(.Item("Prioridad", i).Value & "") Then
                           AgregarInt(nSdoPago, nIntPago, nSdoActu, nImpCajaAd, nImpCaja, Renglon)
                        End If
                     End If
                  End If
                  '
                  If nSdoPago > 0 Or nTotal = 0 Then
                     '
                     If .Item("Concepto", i).Value = "SEÑ" Then
                        nSdoItem = 0
                        nSdoPago = nSdoPago + .Item("Haber", i).Value
                        Renglon = Renglon + 1
                        nPagItem = .Item("Haber", i).Value
                        AltaDetLiq(lblLetra.Text, tbSucursal.Text, tbNumero.Text, Renglon, .Item("Fecha", i).Value,
                                   .Item("Concepto", i).Value, .Item("Detalle", i).Value, nPagItem,
                                   .Item("Imputacion", i).Value, .Item("aPropiet", i).Value, nSdoItem, .Item("FactInqId", i).Value, Trn)
                     Else
                        Cmd.CommandText = "SELECT * FROM FactInq WHERE Periodo = '" & cPeriodo & "' AND Propiedad = " & .Item("Propiedad", i).Value & " AND Inquilino = " & Inquilino & " AND Concepto = '" & .Item("Concepto", i).Value & "'"
                        Drd = Cmd.ExecuteReader
                        '
                        If Drd.Read Then
                           '
                           If Drd!Imputacion = "D" Then
                              If Drd!Saldo - nSdoPago >= 0 Then
                                 nSdoItem = Drd!Saldo - nSdoPago
                              Else
                                 nSdoItem = 0
                              End If
                              nSdoPago = nSdoPago - Drd!Saldo - nSdoItem
                           Else
                              nSdoItem = 0
                              nSdoPago = nSdoPago + Drd!Saldo
                           End If
                           '
                           nPagItem = Drd!Saldo - nSdoItem
                           '
                           With Cm2
                              .Connection = Cn
                              .CommandText = "UPDATE FactInq SET " &
                                             " Liquidado = 1, " &
                                             " Saldo = " & Math.Round(nSdoItem, 2) & ", " &
                                             " TipoNroRbo = '" & lblLetra.Text & tbSucursal.Text & tbNumero.Text & "', " &
                                             " Usuario = '" & Uid & "', " &
                                             " FechaMod = '" & Format(Now, FormatFechaHora) & "' " &
                                             "WHERE FactInqId = " & Drd!FactInqId
                              .ExecuteNonQuery()
                           End With
                           '
                           nImpCajaAd = nImpCajaAd + IIf(Drd!Imputacion = "D", nPagItem, -nPagItem)
                           '
                           Renglon = Renglon + 1
                           '
                           AltaDetLiq(lblLetra.Text, tbSucursal.Text, tbNumero.Text, Renglon, .Item("Fecha", i).Value,
                                      .Item("Concepto", i).Value, .Item("Detalle", i).Value, nPagItem,
                                      .Item("Imputacion", i).Value, .Item("aPropiet", i).Value, nSdoItem, .Item("FactInqId", i).Value, Trn)
                           '
                        Else
                           Drd.Close()
                           Err.Raise(1001, , "FactInqNoEnc")
                        End If
                        Drd.Close()
                     End If
                  Else
                     Exit For
                  End If
                  '
               Next i
            End If
         End With
         '
         If nIntPago < nIntereses Then
            If nSdoPago > 0 Then
               AgregarInt(nSdoPago, nIntPago, nSdoActu, nImpCajaAd, nImpCaja, Renglon)
               If nSdoAnt > 0 Then
                  nSdoActu = nSdoAnt - nSdoPago
               End If
            Else
               nSdoActu = nIntereses - nIntPago
            End If
         End If
         '
         '*** Cabecera Liquid. ***'
         '
         With Cmd
            .CommandText = "INSERT INTO LiqInqCab( Periodo, Propietario, Propiedad, Inquilino, Fecha, Tipo, Sucursal, Numero, MesPago, SaldoAnt, Subtotal, Intereses, Iva1, Iva2, Total, Efectivo, Cheques, Bonos, ImporteTr, Saldo, Detalle, Liquidado, LiqPropiet, Caja, cFecha, Estado, SaldoPend, Retencion, RetencNro, Usuario, FechaMod) " &
                           "VALUES('" & cPeriodo & "', " &
                                        Propietario & ", " &
                                        Propiedad & ", " &
                                        Inquilino & ", " &
                                  "'" & Format(Today, FormatFecha) & "', " &
                                  "'" & lblLetra.Text & "', " &
                                        Val(tbSucursal.Text) & ", " &
                                        Val(tbNumero.Text) & ", " &
                                        nMesPago & ", " &
                                        Math.Round(nSdoAnt, 2) & ", " &
                                        nTotConc & ", " &
                                        nIntPago & ", " &
                                        0 & ", " &
                                        0 & ", " &
                                        nTotal & ", " &
                                        Val(tbEfectivo.Text) & ", " &
                                        Val(tbCheques.Text) & ", " &
                                        0 & ", " &
                                        Val(tbTransferencia.Text) & ", " &
                                        Math.Round(nSdoActu, 2) & ", " &
                                  "'" & tbDetalle.Text & "', " &
                                        IIf(aPropiet, 0, 1) & ", " &
                                        0 & ", " &
                                        prmNroCaja & ", " &
                                  "'" & Format(Today, FormatFecha) & "', " &
                                        IIf(Pendiente, 3, 0) & ", " &
                                        IIf(Pendiente, Val(tbTotCobro.Text), 0) & ", " &
                                        Val(tbRetencion.Text) & ", " &
                                        Val(tbRetencNro.Text) & ", " &
                                  "'" & Uid & "', " &
                                  "'" & Format(Now, FormatFechaHora) & "')"
            .ExecuteNonQuery()
            '
            .CommandText = "SELECT MAX(LiqInqId) FROM LiqInqCab"
            LiqInqId = .ExecuteScalar
            '
            .CommandText = "UPDATE LiqInqDet SET LiqInqID = " & LiqInqId & " " &
                           "WHERE Tipo = '" & lblLetra.Text & "'" &
                           "  AND Sucursal = " & Val(tbSucursal.Text) &
                           "  AND Numero = " & Val(tbNumero.Text)
            .ExecuteNonQuery()
            '
         End With
         '
         If CapturaDato(Cn, "FactInq", "SUM(Saldo)", "Inquilino = " & Inquilino & " AND Propiedad = " & Propiedad, , , , Trn) = 0 Then
            NroCtto = CapturaDato(Cn, "Contratos", "Numero", "Inquilino = " & Inquilino & " AND Propiedad = " & Propiedad & " AND Estado = 0", , , , Trn)
            If NroCtto <> 0 Then
               FechaFin = UltDiaMes("10/" & Mid(cPeriodo, 5, 2) & "/" & Mid(cPeriodo, 1, 4))
               AnulFinCtto(NroCtto, 1, FechaFin, Trn)
            End If
         End If
         '
         If Val(tbCheques.Text) > 0 Then
            ChReciboID = Val(CapturaDato(Cn, "ChRecibo", "MAX(ChReciboID)", "", , , , Trn) & "") + 1
            '
            n = CapturaDato(Cn, "ChReciboTmp", "COUNT(1)", "Usuario = '" & Uid & "' AND PC = '" & NombrePC & "'",,,, Trn)
            '  
            Dim Banco(n) As Int16
            Dim Cuenta(n) As String
            Dim Numero(n) As String
            Dim Titular(n) As String
            Dim Fecha(n) As Date
            Dim Importe(n) As Double
            '
            With Cmd
               .CommandText = "SELECT * FROM ChReciboTmp WHERE Usuario = '" & Uid & "' AND PC = '" & NombrePC & "'"
               Drd = .ExecuteReader
               With Drd
                  i = 0
                  Do While .Read
                     Banco(i) = !Banco
                     Cuenta(i) = !Cuenta
                     Numero(i) = !Numero
                     Titular(i) = !Titular
                     Fecha(i) = !Fecha
                     Importe(i) = !Importe
                     DetChs = DetChs & "N°" & !Numero & " $" & !Importe & ".- "
                     i = i + 1
                  Loop
                  .Close()
               End With
               '
               For i = 0 To n - 1
                  If Not Pendiente Then
                     .CommandText = "INSERT INTO ChCartera( Banco, BancoCta, ChCartNro, Titular, FechaEmi, FechaDif, Entrego, Importe, Estado, CajaAdm, Caja, Comprob, Usuario, FechaMod) " &
                                    "VALUES(" & Banco(i) & ", " &
                                          "'" & Cuenta(i) & "', " &
                                          "'" & Numero(i) & "', " &
                                          "'" & Titular(i) & "', " &
                                          "'" & Format(Today(), FormatFecha) & "', " &
                                          "'" & Format(Fecha(i), FormatFecha) & "', " &
                                          "'" & cbInquilino.Text & "', " &
                                                Importe(i) & ", " &
                                                0 & ", " &
                                                1 & ", " &
                                                prmNroCaja & ", " &
                                          "'" & cComprob & "', " &
                                          "'" & Uid & "', " &
                                          "'" & Format(Now, FormatFechaHora) & "')"
                     .ExecuteNonQuery()
                  End If
                  '
                  .CommandText = "INSERT INTO ChRecibo( ChReciboID, Banco, Cuenta, Numero, Titular, Fecha, Importe, RboTipo, RboSucursal, RboNumero, Usuario, FechaMod) " &
                                 "VALUES(" & ChReciboID & ", " &
                                             Banco(i) & ", " &
                                       "'" & Cuenta(i) & "', " &
                                       "'" & Numero(i) & "', " &
                                       "'" & Titular(i) & "', " &
                                       "'" & Format(Fecha(i), FormatFecha) & "', " &
                                             Importe(i) & ", " &
                                       "'" & lblLetra.Text & "', " &
                                             tbSucursal.Text & ", " &
                                             tbNumero.Text & ", " &
                                       "'" & Uid & "', " &
                                       "'" & Format(Now, FormatFechaHora) & "')"
                  .ExecuteNonQuery()
                  '
               Next i
               '
               'Loop
               '.Close()
               'End With
               '
               .CommandText = "UPDATE LiqInqCab SET ChReciboID = " & ChReciboID & " " &
                              "WHERE Tipo = '" & lblLetra.Text & "'" &
                              "  AND Sucursal = " & Val(tbSucursal.Text) &
                              "  AND Numero = " & Val(tbNumero.Text)
               .ExecuteNonQuery()
               '
            End With
         End If
         '
         If Not Pendiente Then
            If Val(tbTransferencia.Text) > 0 Then
               With Cmd
                  '
                  .CommandText = "INSERT INTO LiqInqTR( Banco0, Cuenta0, Titular0, Banco1, Cuenta1, FechaTR, NumeroTR, ImporteTR, Usuario, FechaMod) " &
                                 "SELECT Banco0, Cuenta0, Titular, Banco1, Cuenta1, FechaTR, NumeroTR, ImporteTR, '" & Uid & "', '" & Format(Now, FormatFechaHora) & "' " &
                                 "FROM " & cTmp
                  .ExecuteNonQuery()
                  '
                  LiqInqTrID = CapturaDato(Cn, "LiqInqTR", "ISNULL(MAX(LiqInqTrID), 0)", "", , , , Trn)
                  nBanco = CapturaDato(Cn, "LiqInqTR", "Banco1", "LiqInqTrID = " & LiqInqTrID, , , , Trn)
                  cCuenta = CapturaDato(Cn, "LiqInqTR", "Cuenta1", "LiqInqTrID = " & LiqInqTrID, , , , Trn) & ""
                  cNumero = CapturaDato(Cn, "LiqInqTR", "NumeroTR", "LiqInqTrID = " & LiqInqTrID, , , , Trn) & ""
                  nTipo = CapturaDato(Cn, "TipoMovBco", "TipoMovBco", "TipoMov = 'TR'", , , , Trn)
                  '
                  If nTipo = 0 Then
                     Err.Raise(1001, , "Tipo de Mov. Transferencia no Definida")
                  End If
                  '
                  .CommandText = "UPDATE LiqInqCab SET LiqInqTrID = " & LiqInqTrID & " " &
                                 "WHERE Tipo = '" & lblLetra.Text & "'" &
                                 "  AND Sucursal = " & Val(tbSucursal.Text) &
                                 "  AND Numero = " & Val(tbNumero.Text)
                  .ExecuteNonQuery()
                  '
                  cCtaBanco = CapturaDato(Cn, "BancosCtas", "CtaCont", "Banco = " & nBanco & " AND BancoCta = '" & cCuenta & "'", , , , Trn)
                  '
                  .CommandText = "INSERT INTO BancosMov( Banco, BancoCta, TipoMovBco, NroMovBco, FechaEmi, FechaAcr, Debe, Haber, Estado, HojaBco, Detalle, Caja, Usuario, FechaMod) " &
                                 "VALUES(" & nBanco & ", " &
                                       "'" & cCuenta & "', " &
                                             nTipo & ", " &
                                       "'" & cNumero & "', " &
                                       "'" & Format(Today, FormatFecha) & "', " &
                                       "'" & Format(Today, FormatFecha) & "', " &
                                             Val(tbTransferencia.Text) & ", " &
                                             0 & ", " &
                                             0 & ", " &
                                             0 & ", " &
                                       "'" & Strings.Left("Liq.Inq." & cbInquilino.Text, 50) & "', " &
                                             prmNroCaja & ", " &
                                       "'" & Uid & "', " &
                                       "'" & Format(Now, FormatFechaHora) & "')"
                  .ExecuteNonQuery()
                  '
               End With
            End If
         End If
         '
         With Cmd
            .CommandText = "INSERT INTO ChReciboDesc( Tipo, Sucursal, Numero, Detalle, Usuario, FechaMod) " &
                           "VALUES ( '" & lblLetra.Text & "', " &
                                          tbSucursal.Text & ", " &
                                          tbNumero.Text & ", " &
                                    "'" & DetChs & "', " &
                                    "'" & Uid & "', " &
                                    "'" & Format(Now, FormatFechaHora) & "')"
            .ExecuteNonQuery()
         End With
         '
         ActLiqAux()
         '
         '* Asiento y Caja.
         If Not Pendiente Then   'Nuevo 23/07/2005.
            '
            With Cmd
               .CommandText = "INSERT INTO LiqInqCob( LicFecha, Inquilino, LicEfectivo, LicRetencion, LicTransferencia, LiqInqTrId, LicCheques, LicSaldo, LicUid, LicFecMod) " &
                              "VALUES('" & Format(Today, FormatFecha) & "', " &
                                           Inquilino & ", " &
                                           Efectivo & ", " &
                                           Val(tbRetencion.Text) & ", " &
                                           Val(tbTransferencia.Text) & ", " &
                                           LiqInqTrID & ", " &
                                           Val(tbCheques.Text) & ", " &
                                           0 & ", " &
                                     "'" & Uid & "', " &
                                     "'" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
               LicId = CapturaDato(Cn, "LiqInqCob", "MAX(LicId)", "", , , , Trn)
               '
               .CommandText = "INSERT INTO LiqInqCobDet( LicId, LiqInqId, LcdImpPago, LcdSaldo, LcdRetencion, LcdUid, LcdFecMod) " &
                              "VALUES(" & LicId & ", " &
                                          LiqInqId & ", " &
                                          nTotCobro & ", " &
                                          0 & ", " &
                                          Val(tbRetencion.Text) & ", " &
                                    "'" & Uid & "', " &
                                    "'" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
               '
               .CommandText = "SELECT * FROM ChReciboTmp WHERE Usuario = '" & Uid & "' AND PC = '" & NombrePC & "'"
               Drd = .ExecuteReader
               '
               With Drd
                  Do While .Read
                     '
                     ChCartId = CapturaDato(Cn, "ChCartera", "ChCartId", "Banco = " & !Banco & " AND BancoCta = '" & !Cuenta & "' AND ChCartNro = '" & !Numero & "'", , , , Trn)
                     '
                     Cm2.CommandText = "INSERT INTO LiqInqCobCh( LicId, ChCarteraId, LicUid, LicFecMod) " &
                                       "VALUES(" & LicId & ", " &
                                                   ChCartId & ", " &
                                             "'" & Uid & "', " &
                                             "'" & Format(Now, FormatFechaHora) & "')"
                     Cm2.ExecuteNonQuery()
                     '
                  Loop
                  .Close()
               End With
               '
            End With
            '
            If SisContable Then
               NroAsi = GuardaAsiento(cComprob, Today, DetAsi, Trn)
               If NroAsi = 0 Then
                  Err.Raise(1001, , Traducir("NoUpAsiento"))
               End If
            End If
            '
            If Efectivo > 0 Then
               '
               If Not ActCaja(prmNroCaja, cComprob, "EF", Today, cbInquilino.Text, "", cDetCaja, Efectivo, 0, True, Trn) Then
                  Err.Raise(1001)
               End If
               '
               If SisContable Then
                  If Efectivo - nImpCaja >= 0 Then
                     RenASi = RenASi + 1
                     If Not GuardaAsienDet(NroAsi, RenASi, cCtaCajaAd, DetAsi, Efectivo - nImpCaja, 0, Trn) Then
                        Err.Raise(1001, , Traducir("NoUpAsiento", , Trn))
                     End If
                     Debug.Print(NroAsi)
                     If nImpCaja > 0 Then
                        RenASi = RenASi + 1
                        If Not GuardaAsienDet(NroAsi, RenASi, cCtaCaja, DetAsi, nImpCaja, 0, Trn) Then
                           Err.Raise(1001, , Traducir("NoUpAsiento", , Trn))
                        End If
                        nImpCaja = 0
                     End If
                  End If
               End If
               '
            End If
            '
            If SisContable Then
               If Val(tbRetencion.Text) > 0 Then
                  RenASi = RenASi + 1
                  If Not GuardaAsienDet(NroAsi, RenASi, cCtaRGan, DetAsi, Val(tbRetencion.Text) - nImpCaja, 0, Trn) Then
                     Err.Raise(1001, , Traducir("NoUpAsiento", , Trn))
                  End If
               End If
            End If
            '
            If Val(tbCheques.Text) > 0 Then
               '
               With Cmd
                  .CommandText = "SELECT * FROM ChReciboTmp WHERE Usuario = '" & Uid & "' AND PC = '" & NombrePC & "'"
                  Drd = .ExecuteReader
                  '
                  i = 1
                  With Drd
                     Do While .Read
                        If Not ActCaja(prmNroCaja, cComprob & "/" & i, "CH", Today, cbInquilino.Text, "", cDetCaja, !Importe, 0, True, Trn) Then
                           Err.Raise(1001)
                        End If
                        i = i + 1
                     Loop
                     .Close()
                  End With
               End With
               '
               If SisContable Then
                  If Val(tbCheques.Text) - nImpCaja >= 0 Then
                     RenASi = RenASi + 1
                     If Not GuardaAsienDet(NroAsi, RenASi, cCtaVCar3, DetAsi, Val(tbCheques.Text) - nImpCaja, 0, Trn) Then
                        Err.Raise(1001, , Traducir("NoUpAsiento", , Trn))
                     End If
                     If nImpCaja > 0 Then
                        RenASi = RenASi + 1
                        If Not GuardaAsienDet(NroAsi, RenASi, cCtaVCar, DetAsi, nImpCaja, 0, Trn) Then
                           Err.Raise(1001, , Traducir("NoUpAsiento", , Trn))
                        End If
                     End If
                  End If
               End If
               '
            End If
            '
            If SisContable Then
               If Val(tbTransferencia.Text) > 0 Then
                  RenASi = RenASi + 1
                  If Not GuardaAsienDet(NroAsi, RenASi, cCtaBanco, DetAsi, Val(tbTransferencia), 0, Trn) Then
                     Err.Raise(1001, , Traducir("NoUpAsiento", , Trn))
                  End If
               End If
               '
               If nTotCobro - nIntPago > 0 Then
                  RenASi = RenASi + 1
                  If Not GuardaAsienDet(NroAsi, RenASi, cCtaInq, DetAsi, 0, nTotCobro - nIntPago, Trn) Then
                     Err.Raise(1001, , Traducir("NoUpAsiento", , Trn))
                  End If
               End If
               '
               If nIntPago > 0 Then
                  RenASi = RenASi + 1
                  If Not GuardaAsienDet(NroAsi, RenASi, IIf(Me.optAdmin.Checked, cCtaInt, cCtaInt3), DetAsi, 0, nIntPago, Trn) Then
                     Err.Raise(1001, , Traducir("NoUpAsiento", , Trn))
                  End If
               End If
            End If
         End If
         '
         If NroSeña.Count > 0 Then
            With Cmd
               For i = 1 To NroSeña.Count
                  .CommandText = "UPDATE CobrosOtr SET " &
                                 " Estado = 1, " &
                                 " Inquilino = " & Inquilino & ", " &
                                 " Liquidado = 1, " &
                                 " LiqInquilino = " & tbNumero.Text & ", " &
                                 " Usuario = '" & Uid & "', " &
                                 " FechaMod = '" & Format(Now, FormatFechaHora) & "' " &
                                 "WHERE Numero = " & NroSeña.Item(i)
                  .ExecuteNonQuery()
               Next i
            End With
         End If
         '
         GuardarAudit("Alta Recibo " & IIf(Pendiente, "Pendiente", "") & " Inquilino", cbInquilino.Text & " - Nº " & tbNumero.Text & " - Período " & cbPeriodo.Text, Me.Name, IIf(Pendiente, cmdPendiente.Text, cmdGenerar.Text), Trn)
         '
         Trn.Commit()
         '
         Return True
         '
      Catch
         Trn.Rollback()
         Dim st As New StackTrace(True)
         MensageError(st, Me.Name, Err.Description)
         Return False
      End Try
      '
   End Function
   '
   Private Sub ActLiqAux(Optional ByVal IniTrans = False)
      '
      Dim Cmd As New OleDb.OleDbCommand
      '
      If IniTrans Then
         Trn = Cn.BeginTransaction
      End If
      '
      Dim Periodo As String = MonthName(Val(cPeriodo.Substring(4, 2))).ToUpper & " /" & cPeriodo.Substring(0, 4)
      '
      With Cmd
         .Connection = Cn
         .Transaction = Trn
         '
         .CommandText = "DELETE FROM LiqAux WHERE Usuario = '" & Uid & "' AND LqxPC = '" & NombrePC & "'"
         .ExecuteNonQuery()
         '
         .CommandText = "INSERT INTO LiqAux( Recibe, SonPesos, Periodo, Usuario, LqxPC, Numero) " &
                        "VALUES('" & cfgNomEmp & "', " &
                               "'" & Numero_a_Texto(nTotCobro) & "', " &
                               "'" & Periodo & "', " &
                               "'" & Uid & "', " &
                               "'" & NombrePC & "', " &
                                     tbNumero.Text & ")"
         .ExecuteNonQuery()
      End With
      '
      If IniTrans Then
         Trn.Commit()
      End If
      '
   End Sub
   '
   Private Sub AgregarInt(ByRef nSdoPago, ByRef nIntPago, ByRef nSdoActu, ByRef nImpCajaAd, ByRef nImpCaja, ByRef Renglon)
      '
      If nIntereses - nSdoPago >= 0 Then
         nIntPago = nSdoPago
      Else
         nIntPago = nIntereses
      End If
      '
      nSdoPago = nSdoPago - nIntPago
      nSdoActu = nSdoActu + nIntereses - nIntPago
      '
      If optPropiet.Checked Then
         nImpCajaAd = nImpCajaAd + nIntPago
      Else
         nImpCaja = nImpCaja + nIntPago
      End If
      '
      Renglon = Renglon + 1
      '
      AltaDetLiq(lblLetra.Text, tbSucursal.Text, tbNumero.Text, Renglon, Today, cfgCodigoInt, cDescInt, nIntPago, "D", IIf(optPropiet.Checked, True, False), 0, 0, Trn)
      '
   End Sub
   '
   Private Sub AltaDetLiq(ByVal Letra As String, ByVal Sucursal As Int16, ByVal Numero As Int32, ByVal Renglon As Byte, ByVal Fecha As Date, ByVal Concepto As String,
                          ByVal Detalle As String, ByVal Importe As Double, ByVal Imputacion As String, ByVal aPropiet As Boolean, ByVal Saldo As Double, ByVal FactInqID As Long, Optional ByVal Tr As Object = "")
      '
      Dim Cmd As New OleDb.OleDbCommand
      '
      With Cmd
         .Connection = Cn
         If Tr.ToString <> "" Then
            .Transaction = Tr
         End If
         .CommandText = "INSERT INTO LiqInqDet( Tipo, Sucursal, Numero, Renglon, Fecha, Concepto, Detalle, Importe, Imputacion, Saldo, aPropiet, Origen, FactInqID, Usuario, FechaMod) " &
                        "VALUES('" & Letra & "', " &
                                     Sucursal & ", " &
                                     Numero & ", " &
                                     Renglon & ", " &
                               "'" & Format(Fecha, FormatFecha) & "', " &
                               "'" & Concepto & "', " &
                               "'" & Detalle & "', " &
                                     Importe & ", " &
                               "'" & Imputacion & "', " &
                                     Math.Round(Saldo, 2) & ", " &
                                     IIf(aPropiet, 1, 0) & ", " &
                                     0 & ", " &
                                     FactInqID & ", " &
                               "'" & Uid & "', " &
                               "'" & Format(Now, FormatFechaHora) & "')"
         .ExecuteNonQuery()
      End With
      '
   End Sub
   '
   Private Sub VerifAdelanto()
      '
      Dim cSql As String
      '
      TotLiqProp = 0
      vImpAlq = 0
      '
      cSql = SQLLiqProp(cPeriodo, Propietario, Propiedad, False)
      '
      LlenarGrid(adcLiqProp, cSql)
      '
      With Cmd
         .Connection = Cn
         .CommandText = cSql
         Drd = .ExecuteReader
         With Drd
            If Not .Read Then
               '*:) Si no tiene Adelantos la Propiedad, busca adelanto general (Todas las propiedades).
               cSql = SQLLiqProp(cPeriodo, Propietario, Propiedad, False, True)
            End If
            .Close()
         End With
         .CommandText = cSql
         Drd = .ExecuteReader
         With Drd
            Do While .Read
               TotLiqProp = TotLiqProp + (Math.Round(!Debe, 2) - Math.Round(!Haber, 2))
               '
               If !Concepto = cfgCodigoAlq Or
                  !Concepto = cfgCodigoBon Then
                  vImpAlq = vImpAlq + !Debe - !Haber
               End If
               '
            Loop
            .Close()
         End With
      End With
      '
      lblAdelProp.Text = "Adel.Prop.: " & TotLiqProp
      '
   End Sub
   '
   Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

   End Sub
   '
   Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
      Me.Close()
   End Sub
   '
   Private Sub frmLiqInquilinosAM_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
      EliminaTmp(Cn, cTmp)
      SetRegGrid(Me, DataGridView1)
      SetRegForm(Me)
      Me.Dispose()
   End Sub
   '
End Class