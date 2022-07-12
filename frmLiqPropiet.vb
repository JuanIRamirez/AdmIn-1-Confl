Public Class frmLiqPropiet
   '
   Dim Tr As OleDb.OleDbTransaction
   Dim Rs As New OleDb.OleDbCommand
   Dim RsD As New OleDb.OleDbCommand
   Dim Dr As OleDb.OleDbDataReader
   Dim DrD As OleDb.OleDbDataReader
   '
   Dim Propietario As Int32
   Dim Propiedad As Int32
   Dim Inquilino As Int32
   '
   Dim cPeriodo As String
   Dim vTipoIva As String
   Dim cCuitProp As String
   'Dim vPeriodo As String
   '
   Dim vImpAlq As Double
   Dim vImpAdl As Double
   Dim vComProp As Double
   Dim vComision As Double
   Dim ComFija As Boolean
   Dim AlicIva1 As Double
   Dim AlicIva2 As Double
   Dim vAliGan As Double
   Dim vMinimp As Double
   Dim vRetMin As Double
   Dim vBonosInq As Double
   Dim vRetGan As Double
   Dim vImpAlqRet As Double
   Dim vRetInq As Double
   Dim vRetAdl As Double
   Dim vRetSdo As Double = 0
   Dim vGtosBanc As Double
   Dim vNetoCom As Double
   '
   Dim nTipoMov As Short
   Dim cImput As String
   Dim Adelanto As Boolean
   '
   Dim CaptCtas As Boolean
   '
   Dim cCtaCAdm As String
   Dim cCtaIDF1 As String
   Dim cCtaIDF2 As String
   Dim cCtaRGan As String
   Dim cCtaPro As String
   Dim cCtaCaja As String
   Dim cCtaCajaAd As String
   Dim cCtaBanco As String
   Dim cCtaAdl As String
   Dim cCtaInt As String
   Dim cCtaVCar As String
   '
   Dim cDescCAdm As String
   Dim cDescIDF1 As String
   Dim cDescIDF2 As String
   Dim cDescRgan As String
   Dim cDescInt As String
   Dim cDescVCar As String
   Dim cTmp As String
   Dim cTmpCh As String
   Dim FormLoad As Boolean = False
   '
   Const cmpInt = "LP"
   Const estEMIT = 1
   Const cStruct = "Banco0 INT NOT NULL, " &
                   "Cuenta0 VarChar(50) NOT NULL, " &
                   "Banco1 INT NOT NULL, " &
                   "Cuenta1 VarChar(50) NOT NULL, " &
                   "Titular VarChar(50) NOT NULL, " &
                   "FechaTR SmallDateTime NOT NULL, " &
                   "NumeroTR VarChar(25) NOT NULL, " &
                   "ImporteTR FLOAT NOT NULL, " &
                   "GastosImp FLOAT NULL, " &
                   "GastosSF FLOAT NULL, " &
                   "GastosIva FLOAT NULL, " &
                   "ImporteNeto FLOAT NOT NULL"
   '
   Const cStrCh = "Renglon SMALLINT, " &
                  "Origen VARCHAR (1), " &
                  "Banco INT, " &
                  "DescBco VARCHAR(50), " &
                  "Cuenta VARCHAR(25), " &
                  "Titular VARCHAR(50), " &
                  "Numero VARCHAR(25), " &
                  "Fecha SMALLDATETIME, " &
                  "Importe FLOAT, " &
                  "CtaCont VARCHAR(15), " &
                  "Usuario VARCHAR(25)"
   '
   Private Sub frmLiqPropiet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      '
      GetRegForm(Me)
      '
      TraducirForm(Me)
      '
      If SisContable Then
         If CaptCtasCaja(prmNroCaja, cCtaCaja, cCtaCajaAd) Then
            If CaptCtasConc(cfgCodigoCAd, cDescCAdm, cCtaCAdm, "") Then
               If CaptCtasConc(cfgCodigoRGan, cDescRgan, cCtaRGan, "") Then
                  If CaptCtasConc(cfgCodigoIDf1, cDescIDF1, cCtaIDF1, "") Then
                     If CaptCtasConc(cfgCodigoIDf2, cDescIDF2, cCtaIDF2, "") Then
                        If CaptCtasConc(cfgCodigoInt, cDescInt, "", cCtaInt) Then
                           If CaptCtasConc(cfgCodigoVCar, cDescVCar, "", cCtaVCar) Then
                              CaptCtas = True
                           End If
                        End If
                     End If
                  End If
               End If
            End If
         End If
      Else
         CaptCtas = True
      End If
      '
      If Not CaptCtas Then DeshabForm(Me)
      '
      cTmp = ""
      If Not CrearTabla(Cn, cStruct, cTmp) Then
         DeshabForm(Me)
      End If
      '
      ArmaComboItem(cbDescProp, "Propietarios", , "Nombre", "Nombre", "(Seleccionar)", "Estado <> 'I'")
      '
      Rs.Connection = Cn
      '
      With Rs
         .CommandText = "SELECT * FROM TipoMovBco WHERE TipoMov = 'CH'"
         Dr = .ExecuteReader
         With Dr
            If .Read Then
               nTipoMov = .Item("TipoMovBco")
               cImput = .Item("Imput")
            End If
            .Close()
         End With
      End With
      '
      ActivaControles(False)
      '
      FormLoad = True
      '
   End Sub
   '
   Private Sub cbPeriodo_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbPeriodo.SelectedIndexChanged
      '
      If Len(cbPeriodo.Text) > 6 Then
         cPeriodo = cbPeriodo.Text.Substring(0, 4) & cbPeriodo.Text.Substring(5, 2)
      Else
         cPeriodo = cbPeriodo.Text
      End If
      '
      If Adelanto Then
         ActDataTmp()
      Else
         ActData()
      End If
      '
   End Sub
   '
   Private Sub cmdTransferencia_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdTransferencia.Click
      Dim Frm As New frmLiqTransf
      With Frm
         .TablaTmp = cTmp
         .TransfRec = False
         .ShowDialog(Me)
         txtTransferencia.Text = Format(.Total - .GtosBanc, "Fixed")
         tbGtosBanc.Text = Format(.GtosBanc, "Fixed")
         vGtosBanc = .GtosBanc
         CalcTotal()
      End With
      CalcEfectivo()
   End Sub
   '
   Private Sub cmdIngCheques_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIngCheques.Click
      Dim Frm As New frmPagoCh
      With Frm
         .ShowDialog(Me)
         tbCheques.Text = Format(.Total, "Fixed")
      End With
      CalcEfectivo()
   End Sub
   '
   Private Sub cbDescPrd_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbDescPrd.SelectedIndexChanged
      '
      With cbDescPrd
         If .SelectedIndex > 0 Then
            Propiedad = .SelectedValue
         Else
            Propiedad = 0
         End If
      End With
      '
      Dim vComPrd As Object
      '
      If Propiedad <= 0 Then
         vComision = vComProp
         Inquilino = 0
      Else
         vComPrd = CapturaDato(Cn, "Propiedades", "Comision", "Codigo = " & Propiedad)
         If IsDBNull(vComPrd) Then
            vComision = vComProp
         Else
            vComision = vComPrd
         End If
         Inquilino = Val(CapturaDato(Cn, "Propiedades", "Inquilino", "Codigo = " & Propiedad) & "")
      End If
      '
      lblComision.Text = Traducir("Comisión") & IIf(ComFija, " $ ", " " & Math.Round(vComision, 2) & " %")
      '
      If Adelanto Then
         ActDataTmp()
      Else
         ActData()
      End If
      '
   End Sub
   '
   Private Sub ActData()
      '
      If Not FormLoad Then Exit Sub
      '
      SetRegGrid(Me, DataGridView1)
      '
      If Propietario > 0 Then
         LlenarGrid(DataGridView1, SQLLiqProp(cPeriodo, Propietario, IIf(Propiedad > 0, Propiedad, 0)))
      End If
      '
      ActivaControles(IIf(DataGridView1.RowCount > 0, True, False))
      '
      SetCols()
      CalcImportes()
      '
      GetRegGrid(Me, DataGridView1)
      '
   End Sub
   '
   Sub ActDataTmp()
      '
      Dim cCampos As String
      '
      cCampos = "Periodo as Per, Propiedad, Fecha, Concepto, Detalle, '' AS Inquilino, Nombre, Debe, Haber, Importe, Tipo, Sucursal, Numero, Origen, Proveedor, Retencion, 0 AS Saldo "
      '
      SetRegGrid(Me, DataGridView1)
      '
      LlenarGrid(DataGridView1, "SELECT " & cCampos & "FROM LiqPropTmp " & "WHERE Usuario = '" & Uid & "'")
      ActivaControles(IIf(DataGridView1.RowCount > 0, True, False))
      '
      SetCols()
      CalcImportes()
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
                  Case "PER" : .HeaderText = "Período"
                  Case "FECHA" : .Width = 100
                  Case "CONCEPTO" : .Width = 90
                  Case "PROPIEDAD" : .Visible = False
                  Case "DETALLE" : .Width = 300
                  Case "NOMBRE" : .Width = 290
                  Case "DEBE" : .Width = 110 : .DefaultCellStyle.Format = "#,##0.00" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                  Case "HABER" : .Width = 110 : .DefaultCellStyle.Format = "#,##0.00" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                  Case "SALDO" : .Width = 110 : .DefaultCellStyle.Format = "#,##0.00" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                  Case "INQUILINO" : .Visible = False
                  Case "TIPO" : .HeaderText = "L/Cmp."
                  Case "PROPIETARIO" : .Visible = False
                  Case "IMPORTE" : .Visible = False
               End Select
            End With
         Next Col
      End With
      '
   End Sub
   '
   Private Sub cbDescProp_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbDescProp.TextChanged
      If cbDescProp.Text = "" Then
         cbPeriodo.Items.Clear()
      End If
   End Sub
   '
   Private Sub cbDescProp_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbDescProp.SelectedIndexChanged
      With cbDescProp
         If .SelectedIndex > 0 Then
            Propietario = .SelectedValue
         Else
            Propietario = 0
         End If
      End With
   End Sub
   '
   Private Sub ArmaComboPer()
      '
      Dim Rs As New OleDb.OleDbCommand
      Dim Dr As OleDb.OleDbDataReader
      '
      Dim i As Short
      Dim AgrPer As Boolean
      '
      Adelanto = False
      '
      'ArmaCombo(cbPeriodo, "DISTINCT Left(L.Periodo, 4) + '/' + Right(L.Periodo, 2)", "LiqInqCab L, LiqInqDet D", "Left(L.Periodo, 4) + '/' + Right(L.Periodo, 2)", "L.Propietario = " & Propietario & " AND L.Liquidado = 0 AND L.Estado <> 2 AND L.LiqInqId = D.LiqInqId AND D.aPropiet <> 0", , "")
      ArmaCombo(cbPeriodo, "DISTINCT Left(L.Periodo, 4) + '/' + Right(L.Periodo, 2)", "LiqInqCab L INNER Join LiqInqDet D ON L.LiqInqId = D.LiqInqId INNER Join LiqInqCobDet LD ON LD.LiqInqId = L.LiqInqID INNER Join liqinqcob C ON C.licid = ld.LicId", "Left(L.Periodo, 4) + '/' + Right(L.Periodo, 2)", "L.Propietario = " & Propietario & " AND L.Estado <> 2 AND D.aPropiet <> 0 AND C.LiqPropiet = 0 AND D.LiqPropiet = 0 " & IIf(Propiedad = 0, "", " AND L.Propiedad = " & Propiedad), , "")
      '
      With Rs
         .Connection = Cn
         .CommandText = "SELECT DISTINCT Left(Periodo, 4) + '/' + Right(Periodo, 2) " & "FROM LiqPropiet L, LiqInqDet D " & "WHERE L.Propietario = " & Propietario & " AND L.Estado <> 2 " & "  AND D.Tipo = 'L' " & " AND L.Numero = D.Numero " & "  AND D.LiqPropiet = 0 " & "  AND D.Concepto = '" & cfgCodigoAdl & "'"
         Dr = .ExecuteReader
         With Dr
            Do While .Read
               AgrPer = True
               For i = 0 To cbPeriodo.Items.Count - 1
                  If cbPeriodo.Items.Item(i) = .Item(0) Then
                     AgrPer = False
                     Exit For
                  End If
               Next
               If AgrPer Then
                  cbPeriodo.Items.Add(.Item(0))
               End If
            Loop
            .Close()
         End With
      End With
      '
   End Sub
   '
   Private Sub GenAdelanto()
      '
      cCtaAdl = CapturaDato(Cn, "Propietarios", "CtaAdl", "Codigo = " & Propietario) & ""
      '
      If SisContable Then
         If cCtaAdl = "" Then
            MensajeTrad("PropSCtaAdl")
            Exit Sub
         End If
      End If
      '
      If TieneAdelantos(Propietario, Propiedad, cPeriodo) Then
         Exit Sub
      End If
      '
      Adelanto = True
      '
      Tr = Cn.BeginTransaction
      '
      Rs.Transaction = Tr
      Rs.CommandText = "DELETE FROM LiqPropTmp WHERE Usuario = '" & Uid & "'"
      Rs.ExecuteNonQuery()
      '
      Tr.Commit()
      '
      ActDataTmp()
      '
      Dim Frm As New frmLiqPropietAdl
      With Frm
         .Propietario = Propietario
         .NroLiq = Val(tbNroLiq.Text)
         .cTmp = "LiqPropTmp"
         .Alta = True
         .AlicIva1 = AlicIva1
         .AlicIva2 = AlicIva2
         .ShowDialog(Me)
         '
         tbDetalle.Text = .Detalle
         With cbPeriodo
            .Items.Clear()
            If Not IsNothing(Frm.Periodo) Then
               .Items.Add(Frm.Periodo)
               .SelectedIndex = 0
            End If
         End With
         PosCboItem(cbDescPrd, .Propiedad)
         '
         ActDataTmp()
         tbEfectivo.Focus()
      End With
      '
   End Sub
   '
   Private Sub cmdAdelanto_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAdelanto.Click
      Aceptar(True)
   End Sub
   '
   Private Sub cmdAceptar_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAceptar.Click
      Aceptar(False)
   End Sub
   '
   Private Sub Aceptar(ByRef lAdel As Boolean)
      '
      cPeriodo = Format(Today, "yyyyMM")
      '
      Adelanto = lAdel
      '
      If cbDescProp.SelectedIndex = 0 Or Propietario = 0 Then
         MensajeTrad("DSelPropietario")
         Exit Sub
      End If
      '
      With Rs
         .CommandText = "SELECT * FROM Propietarios WHERE Codigo = " & Propietario
         Dr = .ExecuteReader
      End With
      '
      With Dr
         If .Read Then
            vTipoIva = .Item("TipoIva")
            vComProp = .Item("Comision")
            ComFija = .Item("ComFija")
            cCuitProp = .Item("Cuit")
            If SisContable Then
               If IsDBNull(.Item("Cuenta")) Or .Item("Cuenta") = "" Then
                  .Close()
                  MensajeTrad("PropSinCuenta")
                  Exit Sub
               End If
               cCtaPro = IIf(cfgCtaPrtUnica, cfgCtaMadrePrt, !Cuenta)
               cCtaAdl = IIf(cfgCtaAdlUnica, cfgCtaMadreAdl, !CtaAdl & "")
            End If
            '
            lblComision.Text = Traducir("Comisión") & " " & .Item("Comision") & "%"
            '
            If Not IsDBNull(.Item("Observaciones")) Then
               If .Item("Observaciones") <> "." Then
                  If .Item("Observaciones") <> "" Then
                     If .Item("Observaciones") <> vbCrLf Then
                        MsgBox(.Item("Observaciones"), MsgBoxStyle.Information)
                     End If
                  End If
               End If
            End If
            '
            If Not IsDBNull(.Item("DocPend")) Then
               If .Item("DocPend") Then
                  MsgBox("Propietario con Documentación Pendiente !", MsgBoxStyle.Information)
               End If
            End If
            '
            If Not CapturaIva() Then
               cbDescProp.SelectedIndex = -1
               Exit Sub
            End If
            '
            'ArmaComboItem(cbDescPrd, "Propiedades", , "Domicilio", "Domicilio", "(Todas)", "Propietario = " & Propietario)
            ArmaCbPropiedad(cbDescPrd, Propietario, "(Todas)")
            '
            If Not lAdel Then
               ArmaComboPer()
            End If
            '
            With cbPeriodo
               If .Items.Count > 0 Then .SelectedIndex = 0
            End With
            '
            With RsD
               .Connection = Cn
               .CommandText = "SELECT * FROM CatGcias WHERE Codigo = " & Dr.Item("CatGcias")
               DrD = .ExecuteReader
            End With
            With DrD
               vAliGan = 0
               vMinimp = 0
               vRetMin = 0
               If .Read Then
                  vAliGan = .Item("Alicuota")
                  vMinimp = .Item("MinimoImp")
                  vRetMin = .Item("RetMinima")
               Else
                  MensajeTrad("CatGanNoEnc")
               End If
               '
               lblRetGan.Text = "Ganancias " & vAliGan & "%"
               .Close()
            End With
         Else
            MensajeTrad("CodNoEnc")
            cbDescProp.SelectedIndex = -1
         End If
         .Close()
      End With
      '
      If Not lAdel Then
         'Actualiza Data para ver si genera Adelanto.-
         ActData()
         '
         LimpiaTmp()
         '
         If cbDescProp.SelectedIndex > -1 Then
            If Val(tTotal.Text) <= 0 Then
               If Not Adelanto Then
                  If MsgBox(Traducir("TotALiq<=0") & Chr(13) & Traducir("GenAdelanto"), MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                     '
                     GenAdelanto()
                     '
                  End If
               End If
            ElseIf Val(tbNetoCom.Text) < 0 Then
               If Not Adelanto Then
                  If MsgBox(Traducir("NetoCom<0") & Chr(13) & Traducir("GenAdelanto"), MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                     '
                     GenAdelanto()
                     '
                  End If
               End If
            End If
         End If
      Else
         'If Not TieneAdelantos Then
         GenAdelanto()
         'End If
      End If
      '
   End Sub
   '
   Private Function CapturaIva() As Boolean
      '
      Dim Rs As New OleDb.OleDbCommand
      Dim RsD As New OleDb.OleDbCommand
      Dim Dr As OleDb.OleDbDataReader
      Dim DrD As OleDb.OleDbDataReader
      '
      Rs.Connection = Cn
      RsD.Connection = Cn
      '
      vTipoIva = CapturaDato(Cn, "Propietarios", "TipoIva", "Codigo = " & Propietario)
      With Rs
         .CommandText = "SELECT * FROM TipoIva WHERE Codigo = '" & vTipoIva & "'"
         Dr = .ExecuteReader
      End With
      With Dr
         If .Read Then
            If cfgEmiteComp = "C" Then
               lblTipo.Text = cfgEmiteComp
            Else
               lblTipo.Text = Mid(LTrim(.Item("RecibeComp")), 1, 1)
            End If
            CaptNumeros(True)
            With RsD
               .CommandText = "SELECT * FROM AlicIva WHERE Codigo = 'GEN'"
               DrD = .ExecuteReader
            End With
            With DrD
               If .Read Then
                  If lblTipo.Text = "C" Then
                     AlicIva1 = 0
                     AlicIva2 = 0
                  Else
                     AlicIva1 = .Item("Alicuo1")
                     If lblTipo.Text = "A" And Trim(Dr.Item("EmiteComp")) = "C" Then
                        AlicIva2 = .Item("Alicuo2")
                     Else
                        AlicIva2 = 0
                     End If
                     lblIva1.Text = "I.V.A." & .Item("Alicuo1") & "%"
                     'lblIva2.Text = "I.V.A." & .Item("Alicuo2").Value & "%"
                     CapturaIva = True
                  End If
               Else
                  MensajeTrad("AlcIvaGenNEnc")
                  AlicIva1 = 0
                  AlicIva2 = 0
               End If
               .Close()
            End With
         Else
            MensajeTrad("TIvaNoEnc")
            cbDescProp.SelectedIndex = -1
         End If
         .Close()
      End With
   End Function
   '
   Private Sub CaptNumeros(Optional ByVal IniTr As Boolean = False)
      '
      If IniTr Then
         Tr = Cn.BeginTransaction
      End If
      '
      Try
         '
         tbFactura.Text = Format(CaptNroFactura(lblTipo.Text, prmSucursal, Tr), "00000000")
         '
         'If lblTipo.Text = "A" Then
         '   BuscarCfg(cfgNroFactA, "cfgNroFactA", Tr)
         '   tbFactura.Text = CStr(Val(CStr(cfgNroFactA)) + 1)
         'Else
         '   BuscarCfg(cfgNroFactB, "cfgNroFactB", Tr)
         '   tbFactura.Text = CStr(Val(CStr(cfgNroFactB)) + 1)
         'End If
         '
         BuscarCfg(cfgNroLiqP, "cfgNroLiqP", Tr)
         tbNroLiq.Text = CStr(Val(CStr(cfgNroLiqP)) + 1)
         '
         BuscarCfg(cfgNroRetG, "cfgNroRetG", Tr)
         If vRetGan = 0 Then
            tbNroRetG.Text = CStr(0)
         Else
            tbNroRetG.Text = CStr(Val(CStr(cfgNroRetG)) + 1)
         End If
         '
         If IniTr Then
            Tr.Commit()
         End If
         '
      Catch
         If IniTr Then
            Tr.Rollback()
         End If
      End Try
      '
   End Sub
   '
   Private Sub cmdCancelar_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancelar.Click
      LimpiaDatos()
   End Sub
   '
   Private Sub LimpiaDatos()
      'cbDescProp.SelectedIndex = -1
      'cbDescProp.Text = ""
      LimpiaTmp()
      While (DataGridView1.Rows.Count > 0)
         DataGridView1.Rows.RemoveAt(DataGridView1.Rows.Count - 1)
      End While
      cbPeriodo.Items.Clear()
      'cbDescPrd.Items.Clear()
      'ActData()
      ActivaControles(False)
      Adelanto = False
      cbDescProp.Focus()
   End Sub
   '
   Private Sub LimpiaTmp()
      Tr = Cn.BeginTransaction
      With Rs
         .Transaction = Tr
         .CommandText = "DELETE FROM ChLiqProTmp WHERE Usuario = '" & Uid & "'"
         .ExecuteNonQuery()
         .CommandText = "DELETE FROM LiqPropTmp WHERE Usuario = '" & Uid & "'"
         .ExecuteNonQuery()
         .CommandText = "DELETE FROM " & cTmp
         .ExecuteNonQuery()
         If cTmpCh <> "" Then
            .CommandText = "DELETE FROM " & cTmpCh
            .ExecuteNonQuery()
         End If
      End With
      Tr.Commit()
   End Sub
   '
   Private Sub cmdGenerar_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdGenerar.Click
      Generar(False)
   End Sub
   '
   Private Sub cmdPendiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPendiente.Click
      Generar(True)
   End Sub
   '
   Private Sub Generar(ByVal Pendiente As Boolean)
      '
      Dim nNroLiq As Integer
      Dim nNroRet As Integer
      Dim nNroFac As Integer
      Dim nComision As Double
      Dim lAdel As Boolean
      '
      If ValidaDatos(Pendiente) Then
         '
         If Guardar(Pendiente) Then
            '
            nNroLiq = Val(tbNroLiq.Text)
            nNroRet = Val(tbNroRetG.Text)
            nNroFac = Val(tbFactura.Text)
            nComision = Val(tbComision.Text)
            lAdel = Adelanto
            '
            LimpiaDatos()
            '
            GenRepLiqPro(nNroLiq, IIf(prmVistPrevLiq, crptToWindow, crptToPrinter), lAdel)
            '
            If Val(CStr(nNroRet)) > 0 Then
               GenRepRetGan(nNroRet, IIf(prmVistPrevLiq, crptToWindow, crptToPrinter))
            End If
            '
            If nComision > 0 And cfgGenFactCom Then
               GenRepFact(lblTipo.Text, prmSucursal, nNroFac, Traducir("Factura"), IIf(prmVistPrevLiq, 0, 1))
            End If
            '
         End If
      End If
      '
   End Sub
   '
   Private Function ValidaDatos(ByVal Pendiente As Boolean) As Boolean
      '
      If Val(tTotal.Text) < 0 Then
         'If MsgBox(Traducir("Total<0"), MsgBoxStyle.Question + MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel Then
         MensajeTrad("Total<0")
         Exit Function
         'End If
      End If
      '
      If Val(tbNetoCom.Text) < 0 Then
         MensajeTrad("NetoCom<0")
         Exit Function
      End If
      '
      If Val(tTotal.Text) <> 0 Then
         If Val(tbEfectivo.Text) + Val(tbCheques.Text) + Val(txtTransferencia.Text) = 0 Then
            If Not Pendiente Then
               MensajeTrad("DIImpPago")
               tbEfectivo.Focus()
               Exit Function
            End If
         Else
            If Pendiente Then
               MensajeTrad("PendNoIngPago")
               Exit Function
            Else
               Dim totPago As Double = Val(tbEfectivo.Text) + Val(tbCheques.Text) + Val(txtTransferencia.Text)
               If Math.Round(totPago, 2) <> Val(tTotal.Text) Then
                  MensajeTrad("Imp.Pago $ " & totPago & " <> Total")
                  tbEfectivo.Focus()
                  Exit Function
               End If
            End If
         End If
      End If
      '
      ValidaDatos = True
      '
   End Function
   '
   Private Sub frmLiqPropietario_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
      Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
      TabReturn(eventArgs.KeyChar)
      eventArgs.KeyChar = Chr(KeyAscii)
      If KeyAscii = 0 Then
         eventArgs.Handled = True
      End If
   End Sub
   '
   Private Sub tbCheques_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbCheques.TextChanged
      tbEfectivo.Text = Format(Val(tTotal.Text) - Val(tbCheques.Text), "Fixed")
   End Sub
   '
   Private Sub tbEfectivo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbEfectivo.TextChanged
      If Val(tbEfectivo.Text) > Val(tTotal.Text) Then
         tbEfectivo.Text = Format(Val(tTotal.Text), "Fixed")
      End If
      ActivaControles(True)
   End Sub
   '
   Private Sub tbEfectivo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbEfectivo.KeyPress
      SoloNumeros(e.KeyChar, True)
   End Sub
   '
   Private Sub tbRecibo_KeyPress(ByVal eventSender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbRecibo.KeyPress
      SoloNumeros(e.KeyChar)
   End Sub
   '
   Private Sub ActivaControles(ByVal Activo As Boolean)
      cbDescProp.Enabled = Not Activo
      cmdAceptar.Enabled = Not Activo
      cmdAdelanto.Enabled = Not Activo
      cmdIngCheques.Enabled = Activo
      cmdGenerar.Enabled = Activo
      cmdPendiente.Enabled = Activo And Val(tbEfectivo.Text) = 0 And Val(txtTransferencia.Text) = 0 And Val(tbCheques.Text) = 0
      cmdCancelar.Enabled = Activo
      'cmdCancelar.cancel = Activo
      cmdTransferencia.Enabled = Activo
      tbEfectivo.Enabled = Activo
      tbDetalle.Enabled = Activo
      'VB6.SetCancel(cmdSalir, Not Activo)
   End Sub
   '
   Private Sub Limpiacampos()
      '
      Dim Ctrl As System.Windows.Forms.Control
      '
      For Each Ctrl In Me.Controls
         If TypeOf Ctrl Is System.Windows.Forms.TextBox Then
            Ctrl.Text = ""
         ElseIf TypeOf Ctrl Is System.Windows.Forms.ComboBox Then
            'Ctrl.selectedindex = 0
         End If
      Next Ctrl
      '
   End Sub
   '
   Private Sub CalcImportes()
      '
      Dim Rs As New OleDb.OleDbCommand
      Dim Dr As OleDb.OleDbDataReader
      '
      Dim Tipo As String
      Dim Sucursal As Integer
      Dim Numero As Long
      Dim bCom As Boolean
      Dim NroLiqInq As Long = 0
      '
      Dim vDebe As Double
      Dim vHaber As Double
      Dim vAcuPer As Double
      Dim vNetoPer As Double
      Dim vNeto As Double
      Dim vImpCom As Double
      Dim cPerGan As String
      Dim InqAgRetGan As Boolean
      Dim i As Int16
      '
      vDebe = 0
      vHaber = 0
      vAcuPer = 0
      vNetoPer = 0
      vNeto = 0
      vRetGan = 0
      vImpCom = 0
      vNetoCom = 0
      vImpAlq = 0
      vImpAlqRet = 0
      vImpAdl = 0
      vBonosInq = 0
      cPerGan = Format(Year(Today), "0000") & Format(Month(Today), "00")
      vRetInq = 0
      vRetAdl = 0
      vGtosBanc = 0
      '
      With Rs
         .Connection = Cn
         '.CommandText = "SELECT * FROM LiqPropiet WHERE Propietario = " & Propietario & " AND LEFT(FechaC,6) = '" & cPerGan & "'"
         '.CommandText = "SELECT * FROM LiqPropiet WHERE Propietario = " & Propietario & " AND Periodo = '" & cPerGan & "'"
         .CommandText = "SELECT L.AlquilerRet, R.Neto FROM LiqPropiet L LEFT JOIN RetGcias R ON L.Numero = R.LiqPropiet " &
                        "WHERE L.Propietario = " & Propietario & " AND R.Periodo = '" & cPerGan & "'"   ' AND L.Periodo = '" & cPerGan & "'"
         Dr = .ExecuteReader
      End With
      With Dr
         Do While .Read
            vAcuPer += !AlquilerRet
            If Not IsDBNull(!Neto) Then
               vNetoPer += !Neto
            End If
         Loop
         .Close()
      End With
      '
      'vNetoPer = Val(CapturaDato(Cn, "RetGcias", "SUM(Neto)", "Propietario = " & Propietario & " AND Periodo = '" & cPerGan & "'") & "")
      '
      With DataGridView1
         If .RowCount > 0 Then
            For i = 0 To .RowCount - 1
               If Inquilino = 0 Then
                  If Val(.Item("Inquilino", i).Value & "") = 0 Then
                     InqAgRetGan = CapturaDato(Cn, "Inquilinos", "AgRetGan", "Codigo = (SELECT Inquilino FROM Propiedades WHERE Codigo = " & Val(.Item("Propiedad", i).Value & "") & ")")
                  Else
                     InqAgRetGan = CapturaDato(Cn, "Inquilinos", "AgRetGan", "Codigo = " & Val(.Item("Inquilino", i).Value & ""))
                  End If
               Else
                  InqAgRetGan = CapturaDato(Cn, "Inquilinos", "AgRetGan", "Codigo = " & Inquilino)
               End If
               '
               vDebe += .Item("Debe", i).Value
               vHaber += .Item("Haber", i).Value
               '
               'If .Item("Concepto", i).Value = "PPA" Then
               '   vImpAlq = CalcImpAlqProp(.Item("Numero", i).Value)
               '
               If .Item("Concepto", i).Value = cfgCodigoAlq Or
                  .Item("Concepto", i).Value = cfgCodigoBon Or
                  .Item("Concepto", i).Value = cfgCodigoAdl Or
                  .Item("Concepto", i).Value = cfgCodigoIva Then
                  '
                  vImpAlq = vImpAlq + .Item("Debe", i).Value - .Item("Haber", i).Value
                  '
                  If InqAgRetGan Then
                     If .Item("Numero", i).Value <> NroLiqInq Then
                        vRetInq += Val(.Item("Retencion", i).Value & "")
                        NroLiqInq = .Item("Numero", i).Value
                     End If
                  Else
                     If .Item("Concepto", i).Value <> cfgCodigoIva Then
                        vImpAlqRet += .Item("Debe", i).Value - .Item("Haber", i).Value
                     End If
                  End If
                  'ElseIf !Concepto = cfgCodigoAdl Then   ' Or Adelanto Then
                  'Nuevo 25/06/2005. Anulado 07/09/2010.-
                  'vImpAdl = Round(!Debe - !Haber, 2)
               ElseIf .Item("Concepto", i).Value = cfgCodigoRGan Then
                  vRetAdl = vRetAdl + .Item("Debe", i).Value - .Item("Haber", i).Value
               End If
               '
               bCom = CapturaDato(Cn, "Conceptos", "Comision", "Codigo = '" & .Item("Concepto", i).Value & "'")
               If bCom Then
                  vNetoCom = vNetoCom + .Item("Debe", i).Value - .Item("Haber", i).Value
               End If
               '
               'If Tipo <> .Item("Tipo", i).Value And Sucursal <> .Item("Sucursal", i).Value And Numero <> .Item("Numero", i).Value Then
               'vBonosInq = vBonosInq + !Bonos
               'End If
               '
               Tipo = .Item("Tipo", i).Value
               Sucursal = .Item("Sucursal", i).Value
               Numero = .Item("Numero", i).Value
               '
            Next i
         End If
         '
         'vRetSdo = vRetInq   '- vRetAdl
         '
         If vImpAlqRet > 0 Then
            vAcuPer = vAcuPer + vImpAlqRet
            vNeto = vAcuPer - (vNetoPer + vMinimp)
         End If
         '
         'vNetoCom = vNetoCom - vRetInq
         '
         If vNeto > 0 Then
            vRetGan = Math.Round(vNeto * vAliGan / 100, 2)
            If vRetGan < vRetMin Then
               vRetGan = 0
            End If
         Else
            vNeto = 0
            vRetGan = 0
         End If
         '
         tSubtotal.Text = Format(vDebe - vHaber, "Fixed")
         tDebe.Text = Format(vDebe, "Fixed")
         tHaber.Text = Format(vHaber, "Fixed")
         tbAlquiler.Text = Format(vImpAlq, "Fixed")
         tbRetInq.Text = Format(vRetInq, "Fixed")
         'txtRetSdo = Format(vRetSdo, "Fixed")
         tbAcuPer.Text = Format(vAcuPer, "Fixed")
         tbNeto.Text = Format(vNeto, "Fixed")
         tbRetGan.Text = Format(vRetGan, "Fixed")
         tbNetoCom.Text = Format(vNetoCom, "Fixed")
         If ComFija Then
            vImpCom = vComision
         Else
            vImpCom = Math.Round(vNetoCom * Val(vComision) / 100, 2)
         End If
         tbComision.Text = Format(vImpCom, "Fixed")
         tIva1.Text = Format(Math.Round(vImpCom * AlicIva1 / 100, 2), "Fixed")
         'tIva2 = Format(Round(vImpCom * AlicIva2 / 100, 2), "Fixed")
         CalcTotal()
         tbEfectivo.Text = Format(tTotal.Text, "Fixed")
         tbCheques.Text = ""
         txtTransferencia.Text = ""
         tbGtosBanc.Text = Format(vGtosBanc, "Fixed")
         '
      End With

      CaptNumeros(True)

   End Sub
   '
   Private Sub CalcEfectivo()
      tbEfectivo.Text = Format(Val(tTotal.Text) - Val(tbCheques.Text) - Val(txtTransferencia.Text), "Fixed")
      ActivaControles(True)
   End Sub
   '
   Private Sub CalcTotal()
      tTotal.Text = Format(Val(tSubtotal.Text) - Val(tbRetGan.Text) - Val(tbComision.Text) - Val(tIva1.Text) - vRetSdo - vGtosBanc, "Fixed")   '// - vRetInq
   End Sub
   '
   'Private Function CalcImpAlqProp(LicId As Int32) As Double
   '   '
   '   Dim Cmd As New OleDb.OleDbCommand
   '   Dim Cm2 As New OleDb.OleDbCommand
   '   Dim Drd As OleDb.OleDbDataReader
   '   Dim ImpAlq As Double = 0
   '   '
   '   With Cmd
   '      .Connection = Cn
   '      .CommandText = "SELECT C.LcdImpPago, C.LiqInqId, L.Total, D.Concepto, D.Importe, d.aPropiet, D.Importe * C.LcdImpPago / L.Total AS Prop " &
   '                     "FROM LiqInqCobDet C " &
   '                     "INNER JOIN LiqInqCab L ON L.LiqInqId = C.LiqInqId " &
   '                     "INNER JOIN LiqInqDet D ON D.LiqInqId = L.LiqInqId " &
   '                     "WHERE C.LicId = " & LicId &
   '                     " AND D.Imputacion = 'D' " &
   '                     "UNION " &
   '                     "SELECT C.LcdImpPago, C.LiqInqId, L.Total, D.Concepto, -D.Importe, d.aPropiet , -D.Importe * c.LcdImpPago / L.Total AS Prop " &
   '                     "FROM LiqInqCobDet C " &
   '                     "INNER JOIN LiqInqCab L ON L.LiqInqId = C.LiqInqId " &
   '                     "INNER JOIN LiqInqDet D ON D.LiqInqId = L.LiqInqId " &
   '                     "WHERE C.LicId = " & LicId &
   '                     " AND D.Imputacion='H'"
   '      Drd = .ExecuteReader()
   '   End With
   '   With Drd
   '      While .Read()
   '         If .Item("Concepto") = cfgCodigoAlq Or
   '            .Item("Concepto") = cfgCodigoBon Or
   '            .Item("Concepto") = cfgCodigoAdl Or
   '            .Item("Concepto") = cfgCodigoIva Then
   '            '
   '            ImpAlq = ImpAlq + .Item("Prop")
   '            '
   '         End If
   '         If CapturaDato(Cn, "Conceptos", "Comision", "Codigo = '" & .Item("Concepto") & "'") Then
   '            vNetoCom = vNetoCom + .Item("Prop")
   '         End If
   '         '
   '      End While
   '   End With
   '   '
   '   Return ImpAlq
   '   '
   'End Function
   '
   Private Function Guardar(ByVal Pendiente As Boolean) As Boolean
      '
      Tr = Cn.BeginTransaction
      '
      CaptNumeros()
      '
      tbNroLiq.Text = GuardarLiqProp(Propietario, cPeriodo, Propiedad, Val(tbComision.Text), Val(tIva1.Text), 0, Val(tbRetGan.Text), lblTipo.Text, CInt(tbNroRetG.Text), Val(tbRecibo.Text), tbDetalle.Text, vImpAlq, vImpAlqRet, Math.Abs(vRetAdl), Val(tDebe.Text), Val(tHaber.Text), Val(tTotal.Text), Val(tbEfectivo.Text), Val(tbCheques.Text), Val(tbNetoCom.Text), vBonosInq, DataGridView1, Adelanto, vImpAdl, Val(tbAcuPer.Text), Val(tbNeto.Text), Val(tSubtotal.Text), cCtaPro, cCtaAdl, cCtaInt, cCtaCaja, cCtaCAdm, cCtaIDF1, cCtaIDF2, cCtaRGan, cCtaCajaAd, cCtaVCar, nTipoMov, cImput, vTipoIva, cCuitProp, cDescCAdm, Val(txtTransferencia.Text), vGtosBanc, cTmp, cTmpCh, Pendiente, , Tr)
      '
      If Val(tbNroLiq.Text) <> 0 Then
         Tr.Commit()
         Return True
      Else
         Tr.Rollback()
         Return False
      End If
      '
   End Function
   '
   Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
      'MsgBox("q onda ?")
   End Sub
   '
   Private Sub cmdSalir_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSalir.Click
      Me.Close()
   End Sub
   '
   Private Sub frmLiqPropietario_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
      SetRegGrid(Me, DataGridView1)
      SetRegForm(Me)
   End Sub
   '
End Class
