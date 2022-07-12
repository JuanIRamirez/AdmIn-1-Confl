Public Class frmLiqPropietPend
   '
   Const estAnulado = 2
   '
   Dim Trn As OleDb.OleDbTransaction
   Dim Cmd As New OleDb.OleDbCommand
   '
   Dim NroLiq As Long
   Dim Propietario As Integer
   '
   Dim cTmp As String
   Dim cTmpCh As String
   Dim cTmpTr As String
   Dim CantLiq As Integer
   Dim cImput As String
   '
   Dim cCtaCaja As String
   Dim cCtaCAdm As String
   Dim cCtaCajaAd As String
   Dim cDescCAdm As String
   Dim cCtaVCar As String
   Dim cDescVCar As String
   Dim CaptCtas As Boolean
   Dim FormLoad As Boolean = False
   '
   Const minHeight = 6555
   Const minWidth = 9810
   Const cmpInt = "LP"
   '
   Const cStruct = "Numero INT NOT NULL"
   '
   Const cStrCh = "Renglon SMALLINT, " & _
                  "Origen VARCHAR (1), " & _
                  "Banco INT, " & _
                  "DescBco VARCHAR(50), " & _
                  "Cuenta VARCHAR(25), " & _
                  "Titular VARCHAR(50), " & _
                  "Numero VARCHAR(25), " & _
                  "Fecha SMALLDATETIME, " & _
                  "Importe FLOAT, " & _
                  "CtaCont VARCHAR(15), " & _
                  "Usuario VARCHAR(25)"
   '
   Const cStrTR = "Banco0 INT NOT NULL, " & _
                  "Cuenta0 VarChar(50) NOT NULL, " & _
                  "Banco1 INT NOT NULL, " & _
                  "Cuenta1 VarChar(50) NOT NULL, " & _
                  "Titular VarChar(50) NOT NULL, " & _
                  "FechaTR SmallDateTime NOT NULL, " & _
                  "NumeroTR VarChar(25) NOT NULL, " & _
                  "ImporteTR FLOAT NOT NULL, " & _
                  "GastosImp FLOAT NULL, " & _
                  "GastosSF FLOAT NULL, " & _
                  "GastosIva FLOAT NULL, " & _
                  "ImporteNeto FLOAT NOT NULL"
   '
   Const estCONF = 1
   Const estANUL = 2
   Const estPEND = 3
   '
   Private Sub LiqPropietPend_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      '
      GetRegForm(Me)
      '
      '*TraducirForm Me
      '
      cTmp = ""
      If Not CrearTabla(Cn, cStruct, cTmp) Then
         DeshabForm(Me)
      End If
      '
      cTmpCh = ""
      If Not CrearTabla(Cn, cStrCh, cTmpCh) Then
         DeshabForm(Me)
      End If
      '
      cTmpTr = ""
      If Not CrearTabla(Cn, cStrTR, cTmpTr) Then
         DeshabForm(Me)
      End If
      '
      If FechaIncorrecta() Then
         DeshabForm(Me)
      End If
      '
      If SisContable Then
         If CaptCtasCaja(prmNroCaja, cCtaCaja, cCtaCajaAd) Then
            If CaptCtasConc(cfgCodigoCAd, cDescCAdm, cCtaCAdm, "") Then
               'If CaptCtasConc(cfgCodigoRGan, cDescRGan, cCtaRGan, "") Then
               'If CaptCtasConc(cfgCodigoIDf1, cDescIDF1, cCtaIDF1, "") Then
               'If CaptCtasConc(cfgCodigoIDf2, cDescIDF2, cCtaIDF2, "") Then
               'If CaptCtasConc(cfgCodigoInt, cDescInt, "", cCtaInt) Then
               If CaptCtasConc(cfgCodigoVCar, cDescVCar, "", cCtaVCar) Then
                  CaptCtas = True
               End If
               'End If
               'End If
               'End If
               'End If
            End If
         End If
         If Not CaptCtas Then DeshabForm(Me)
      End If
      '
      cImput = CapturaDato(Cn, "TipoMovBco", "Imput", "TipoMov = 'CH'")
      If cImput = "" Then
         cImput = "H"
      End If
      '
      Cmd.Connection = Cn
      '
      ArmaCbPropiet()
      '
      dtpFecha.Value = Today
      '
      FormLoad = True
      '
      ActData()
      '
   End Sub
   '
   Private Sub frmLiqPropietPend_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
      TabReturn(e.KeyChar)
   End Sub
   '
   Private Sub chkGrupos_CheckedChanged(sender As Object, e As EventArgs) Handles chkGrupos.CheckedChanged
      ArmaCbPropiet()
   End Sub
   '
   Private Sub ArmaCbPropiet()
      If chkGrupos.Checked Then
         ArmaComboItem(cbPropietario, "PropietAg", "PropietAgId", "PagDescrip", "PagDescrip")
      Else
         ArmaComboItem(cbPropietario, "Propietarios", , "Nombre", "Nombre", "(Todos)")
      End If
   End Sub
   '
   Private Sub cmdIngCheques_Click(sender As Object, e As EventArgs) Handles cmdIngCheques.Click
      Dim Frm As New frmPagoCh
      With Frm
         .TablaAct = cTmpCh
         .ShowDialog(Me)
         tbCheques.Text = Format(.Total, "Fixed")
      End With
   End Sub
   '
   Private Sub cmdTransferencia_Click(sender As Object, e As EventArgs) Handles cmdTransferencia.Click
      Dim Frm As New frmLiqTransf
      With Frm
         .TablaTmp = cTmpTr
         .TransfRec = False
         .ShowDialog(Me)
         txtTransf.Text = Format(.Total, "Fixed")
      End With
   End Sub
   '
   Private Sub tbCheques_TextChanged(sender As Object, e As EventArgs) Handles tbCheques.TextChanged
      CalcEfectivo()
   End Sub
   '
   Private Sub txtTransf_TextChanged(sender As Object, e As EventArgs) Handles txtTransf.TextChanged
      CalcEfectivo()
   End Sub
   '
   Private Sub CalcEfectivo()
      txtEfectivo.Text = Format(Val(txtTotal.Text) - Val(tbCheques.Text) - Val(txtTransf.Text), "Fixed")
   End Sub
   '
   Private Sub cmdConfirmar_Click(sender As Object, e As EventArgs)
      Agregar()
   End Sub
   '
   Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
      Cancelar()
   End Sub
   '
   Private Sub Cancelar()
      Trn = Cn.BeginTransaction
      With Cmd
         .Transaction = Trn
         .CommandText = "DELETE FROM " & cTmp
         .ExecuteNonQuery()
      End With
      Trn.Commit()
      '
      ActData()
      '
   End Sub
   '
   Private Sub ActivaCtrl()
      '
      Dim HayLiq As Boolean = False
      Dim Estado As Byte = 0
      Dim Saldo As Double = 0
      Dim Agregado As Boolean = False
      '
      'If Me.chkConfirmadas.Checked Then
      'With Me.DgvConf
      'If .RowCount > 0 Then
      'Estado = .SelectedCells(.Columns("Estado").Index).Value
      'Saldo = 0
      'HayLiq = True
      'End If
      'End With
      'Else
      With DataGridView1
         If .RowCount > 0 Then
            Estado = .SelectedCells(.Columns("Estado").Index).Value
            Saldo = .SelectedCells(.Columns("Total").Index).Value
            HayLiq = True
         End If
      End With
      'End If
      '
      Agregado = (DataGridView2.RowCount > 0)   '*And Not chkConfirmadas.Checked)
      '
      cbPropietario.Enabled = Not Agregado
      chkGrupos.Enabled = Not Agregado
      chkTodas.Enabled = Not Agregado
      dtpFecha.Enabled = Not Agregado And Not chkTodas.Checked
      DataGridView1.Enabled = Not Agregado Or Propietario <> 0
      '
      cmdAgregar.Enabled = (Estado = estPEND Or Saldo <> 0) And (Propietario <> 0 Or Not Agregado)
      cmdQuitar.Enabled = Agregado
      'cmdConfirmar.Enabled = ((Estado = estPEND Or Saldo <> 0) And Not Agregado)
      cmdAnular.Enabled = ((Estado = estPEND Or Estado = estCONF) And Not Agregado) And LGR
      cmdGenerar.Enabled = Agregado
      cmdCancelar.Enabled = Agregado
      cmdImprimir.Enabled = HayLiq
      cmdIngCheques.Enabled = Agregado
      txtEfectivo.Enabled = Agregado
      'txtRetencion.Enabled = Agregado
      cmdTransferencia.Enabled = Agregado
      lblEfectivo.Enabled = Agregado
      '
   End Sub
   '
   'Private Sub cbDescProp_Change()
   '   PintarCb(cbDescProp, LastKey)
   'End Sub
   '
   Private Sub cbPropietario_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPropietario.SelectedIndexChanged
      With cbPropietario
         If .SelectedIndex = 0 Then
            Propietario = 0
         Else
            Propietario = .SelectedValue
         End If
      End With
      ActData()
   End Sub
   '
   Private Sub cmdAgregar_Click(sender As Object, e As EventArgs) Handles cmdAgregar.Click
      Agregar()
   End Sub
   '
   Private Sub Agregar()
      '
      Dim Numero As Int32
      '
      With DataGridView1
         If .RowCount > 0 Then
            Numero = .SelectedCells(.Columns("Numero").Index).Value
         Else
            Numero = 0
         End If
      End With
      '
      If Numero > 0 Then
         '
         Trn = Cn.BeginTransaction
         '
         With Cmd
            .Transaction = Trn
            .CommandText = "INSERT INTO " & cTmp & " VALUES(" & Numero & ")"
            .ExecuteNonQuery()
         End With
         '
         Trn.Commit()
         '
         ActData()
         '
      End If
      '
   End Sub
   '
   Private Sub dtpFecha_ValueChanged(sender As Object, e As EventArgs) Handles dtpFecha.ValueChanged
      ActData()
   End Sub
   '
   Private Sub chkTodas_CheckedChanged(sender As Object, e As EventArgs) Handles chkTodas.CheckedChanged
      If chkTodas.Checked Then
         dtpFecha.Enabled = False
      Else
         dtpFecha.Enabled = True
      End If
      ActData()
   End Sub
   '
   Private Sub cmdSalir_Click(sender As Object, e As EventArgs) Handles cmdSalir.Click
      Me.Close()
   End Sub
   '
   Private Sub ActData()
      '
      Dim cCols As String
      Dim cWhere1 As String
      Dim cWhere2 As String
      Dim cWhere3 As String
      'Dim cWhere4 As String
      Dim cRels As String
      '
      If Not FormLoad Then Exit Sub
      '
      cCols = "LiqPropiet.Fecha, " & _
              "LiqPropiet.Numero, " & _
              "LiqPropiet.Propietario, " & _
              "Propietarios.Nombre, " & _
              "LiqPropiet.Recibo, " & _
              "LiqPropiet.Detalle, " & _
              "right(LiqPropiet.Periodo,2) + '/' + left(LiqPropiet.Periodo,4) as Per, " & _
              "LiqPropiet.Estado, " & _
              "EstLiquid.Descrip as DescEst, " & _
              "LiqPropiet.Total"
      '
      cRels = "LiqPropiet.Propietario = Propietarios.Codigo AND " & _
              "LiqPropiet.Estado = EstLiquid.Estado"
      '
      If Propietario = 0 Then
         cWhere1 = ""
      Else
         If chkGrupos.Checked Then
            cWhere1 = " AND LiqPropiet.Propietario IN( SELECT Propietario FROM PropietAgDet WHERE PropietAgId = " & Propietario & ")"
         Else
            cWhere1 = " AND LiqPropiet.Propietario = " & Propietario
         End If
      End If
      '
      If chkTodas.Checked Then
         cWhere2 = ""
      Else
         cWhere2 = " AND LiqPropiet.Fecha = " & strFEC & Format(dtpFecha.Value, FormatFecha) & strFEC
      End If
      '
      cWhere3 = " AND LiqPropiet.Estado = 3 "
      '
      SetRegGrid(Me, DataGridView1)
      '
      LlenarGrid(DataGridView1, "SELECT " & cCols & _
                                " FROM LiqPropiet, Propietarios, EstLiquid" & _
                                " WHERE " & cRels & cWhere1 & cWhere2 & cWhere3 & _
                                "  AND LiqPropiet.Numero NOT IN( SELECT Numero FROM " & cTmp & ") " & _
                                " ORDER BY Fecha, Numero")
      '
      SetCols()
      '
      GetRegGrid(Me, DataGridView1)
      '
      SetRegGrid(Me, DataGridView2)
      '
      LlenarGrid(DataGridView2, "SELECT L.Numero, L.Fecha, P.Nombre, L.Periodo, L.Total, L.Propietario " & _
                                 " FROM LiqPropiet L, " & cTmp & " T, Propietarios P " & _
                                " WHERE T.Numero = L.Numero" & _
                                "   AND L.Propietario = P.Codigo " & _
                                " ORDER BY L.Numero")
      '
      GetRegGrid(Me, DataGridView1)
      '
      CantLiq = DataGridView2.RowCount
      cmdQuitar.Enabled = CantLiq > 0
      '
      txtEfectivo.Text = Format(CapturaDato(Cn, "LiqPropiet", "ISNULL(SUM(Efectivo),0)", _
                                                "EXISTS( SELECT Numero FROM " & cTmp & " " & _
                                                "        WHERE Numero = LiqPropiet.Numero )"), "Fixed")
      '
      tbCheques.Text = Format(CapturaDato(Cn, "LiqPropiet", "ISNULL(SUM(Cheque),0)", _
                                              "EXISTS( SELECT Numero FROM " & cTmp & " " & _
                                              "        WHERE Numero = LiqPropiet.Numero )"), "Fixed")
      '
      'txtRetencion = Format(CapturaDato(Cn, "LiqInqCab", "SUM(Retencion)", _
      '                           "EXISTS( SELECT Numero FROM " & cTmp & " " & _
      '                           "        WHERE Tipo = LiqInqCab.Tipo " & _
      '                           "          AND Sucursal = LiqInqCab.Sucursal " & _
      '                           "          AND Numero = LiqInqCab.Numero )"), "Fixed")
      '
      txtTransf.Text = Format(CapturaDato(Cn, "LiqPropiet", "ISNULL(SUM(ImporteTr),0)", _
                                              "EXISTS( SELECT Numero FROM " & cTmp & " " & _
                                              "        WHERE Numero = LiqPropiet.Numero )"), "Fixed")
      '
      txtTotal.Text = Format(CapturaDato(Cn, "LiqPropiet", "ISNULL(SUM(Total),0)", _
                                             "EXISTS( SELECT Numero FROM " & cTmp & " " & _
                                             "        WHERE Numero = LiqPropiet.Numero )"), "Fixed")
      '
      'txtSaldoPend = Format(CapturaDato(Cn, "LiqPropiet", "SUM(SaldoPend)", _
      '                                   "EXISTS( SELECT Numero FROM " & cTmp & " " & _
      '                                   "        WHERE Numero = LiqPropiet.Numero )"), "Fixed")
      '
      'DataGrid1_Click()
      'DataGrid2_Click()
      ActivaCtrl()
      '
   End Sub
   '
   Private Sub SetCols()
      '
      For Each col As DataGridViewColumn In DataGridView1.Columns
         With col
            Select Case UCase(.Name)
               Case "FECHA"
               Case "NUMERO" : .Width = 75 : .HeaderText = "Nº Liq."
               Case "PROPIETARIO" : .Visible = False
               Case "NOMBRE" : .Width = 200 : .HeaderText = "Propietario"
               Case "RECIBO" : .Width = 100
               Case "DETALLE" : .Width = 250
               Case "PER" : .Width = 100 : .HeaderText = "Período"
               Case "ESTADO" : .Visible = False
               Case "DESCEST" : .HeaderText = "Estado"
               Case "TOTAL" : .Width = 100
                  With .DefaultCellStyle
                     .Format = "##,##0.00 "
                     .Alignment = DataGridViewContentAlignment.MiddleRight
                  End With
            End Select
         End With
      Next col
      '
   End Sub

   'Private Sub Form_Resize()
   '   '
   '   On Error Resume Next
   '   '
   '   If frmMenu.WindowState <> 1 Then
   '      If Me.WindowState <> 1 Then
   '         If Me.WindowState = 0 Then
   '            If Me.Height < minHeight Then Me.Height = minHeight
   '            If Me.Width < minWidth Then Me.Width = minWidth
   '         End If
   '         FrSelect.Width = Me.Width - 180
   '         DataGrid1.Height = Me.ScaleHeight - FrDatos.Height - FrSelect.Height - 210
   '         DataGrid1.Width = Me.ScaleWidth - 90
   '         cmdSalir.Top = Me.ScaleHeight - cmdSalir.Height - 90
   '         cmdAnular.Top = cmdSalir.Top - cmdAnular.Height - 90
   '         With FrDatos
   '            .Top = Me.ScaleHeight - .Height - 120
   '            .Width = Me.ScaleWidth - .Left - 90
   '         End With
   '         cmdAgregar.Top = FrDatos.Top + 90
   '         cmdQuitar.Top = cmdAgregar.Top + cmdAgregar.Height + 90
   '         cmdConfirmar.Top = cmdQuitar.Top + cmdQuitar.Height + 90
   '      End If
   '   End If
   'End Sub
   '
   Private Sub DataGrid1_KeyUp(KeyCode As Integer, Shift As Integer)
      'DataGrid1_Click()
   End Sub
   '
   Private Sub DataGrid1_RowColChange(LastRow As Object, ByVal LastCol As Integer)
      'DataGrid1_Click()
   End Sub
   '
   Private Sub cmdQuitar_Click(sender As Object, e As EventArgs) Handles cmdQuitar.Click
      '
      Dim Numero As Long
      '
      With DataGridView2
         If .RowCount > 0 Then
            Numero = .SelectedCells(.Columns("Numero").Index).Value
         Else
            Numero = 0
         End If
      End With
      '
      If Numero > 0 Then
         Trn = Cn.BeginTransaction
         With Cmd
            .Transaction = Trn
            .CommandText = "DELETE FROM " & cTmp & " WHERE Numero = " & Numero
            .ExecuteNonQuery()
         End With
         Trn.Commit()
         ActData()
      End If
      '
   End Sub
   '
   'Private Sub DataGrid1_Click()
   '   With Adodc1.Recordset
   '      If .RecordCount > 0 Then
   '         cmdAgregar.Enabled = True
   '         cmdAnular.Enabled = True
   '      Else
   '         cmdAgregar.Enabled = False
   '         cmdAnular.Enabled = False
   '      End If
   '   End With
   'End Sub
   '
   'Private Sub DataGrid2_Click()
   '   With Adodc2.Recordset
   '      If .RecordCount > 0 Then
   '         cmdQuitar.Enabled = True
   '         cmdGenerar.Enabled = True
   '      Else
   '         cmdQuitar.Enabled = False
   '         cmdGenerar.Enabled = False
   '      End If
   '   End With
   'End Sub
   '
   Private Sub cmdGenerar_Click(sender As Object, e As EventArgs) Handles cmdGenerar.Click
      If ValidaDatos() Then
         If Guardar() Then
            'nNroLiq = NroLiq
            'nNroRet = Val(tbNroRetG)
            'nNroFac = Val(tbFactura)
            'nComision = Val(tComision)
            'lAdel = Adelanto
            '
            Cancelar()
            '
            GenRepLiqPro(NroLiq, crptToWindow, False, True)
            '
            'If Val(nNroRet) > 0 Then
            '   GenRepRetGan nNroRet, Traducir("RetGcias"), frmMenuInmob.crpGeneral, IIf(regVistPrevLiq, crptToWindow, DestinoRep)
            'End If
            'If nComision > 0 Then
            '   GenRepFact lblTipo, regSucursal, nNroFac, Traducir("Factura"), DestinoRep
            'End If
         End If
      End If
   End Sub
   '
   Private Function ValidaDatos() As Boolean
      '
      If Val(txtTotal.Text) < 0 Then
         If MsgBox(Traducir("Total<0"), vbQuestion + vbOKCancel) = vbCancel Then
            Exit Function
         End If
      End If
      '
      'If Val(tbNetoCom) < 0 Then
      '   MensajeTrad "NetoCom<0"
      '   Exit Function
      'End If
      '
      If Val(txtTotal.Text) <> 0 Then
         If Val(txtEfectivo.Text) + Val(tbCheques.Text) + Val(txtTransf.Text) = 0 Then
            MensajeTrad("DIImpPago")
            txtEfectivo.Focus()
            Exit Function
         ElseIf Format(Val(txtEfectivo.Text) + Val(tbCheques.Text) + Val(txtTransf.Text), "#0.00") <> Format(Val(txtTotal.Text), "#0.00") Then
            MensajeTrad("ImpPago<>Tot")
            txtEfectivo.Focus()
            Exit Function
         End If
      End If
      '
      ValidaDatos = True
      '
   End Function
   '
   Private Function Guardar() As Boolean
      '
      Dim cPer As String
      Dim Prop As Long = 0
      '
      cPer = Format(Today, "yyyyMM")
      '
      With DataGridView2
         If .RowCount > 0 Then
            Prop = .SelectedCells(.Columns("Propietario").Index).Value
         End If
      End With
      '
      NroLiq = GuardarLiqProp(Prop, cPer, 0, 0, 0, 0, 0, "", 0, 0, "", 0, 0, 0, Val(txtTotal.Text), 0, Val(txtTotal.Text), Val(txtEfectivo.Text), Val(tbCheques.Text), 0, 0, DataGridView2, False, 0, 0, 0, Val(txtTotal.Text), "", "", "", cCtaCaja, cCtaCAdm, "", "", "", cCtaCajaAd, cCtaVCar, 0, cImput, "", "", cDescCAdm, Val(txtTransf.Text), 0, cTmpTr, cTmpCh, , True)
      '
      If Val(NroLiq) <> 0 Then
         Return True
      Else
         Return False
      End If
      '
   End Function
   '
   Private Sub cmdAnular_Click(sender As Object, e As EventArgs) Handles cmdAnular.Click
      '
      Dim Tr As OleDb.OleDbTransaction
      Dim Numero As Long
      '
      With DataGridView1
         If .RowCount > 0 Then
            Numero = .SelectedCells(.Columns("Numero").Index).Value
         End If
      End With
      '
      If Numero > 0 Then
         If MsgBox(Traducir("AnulaLiqProp") & " Nº " & Numero, vbQuestion + vbYesNo) = vbYes Then
            Tr = Cn.BeginTransaction
            If AnulaLiqProp(Numero, Tr) Then
               Tr.Commit()
            Else
               Tr.Rollback()
            End If
            ActData()
         End If
      End If
      '
   End Sub
   '
   Private Sub frmLiqPropietPend_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
      SetRegGrid(Me, DataGridView1)
      SetRegGrid(Me, DataGridView2)
      SetRegForm(Me)
   End Sub
   '
End Class