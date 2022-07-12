Public Class frmBancosMovAM
   '
   Public Concilia As Boolean = False
   Public Alta As Boolean
   Public Deposito As Boolean = False
   '
   Public Banco As Integer = 0
   Public BancoCta As String = ""
   Public TipoMovBco As Integer = 0
   Public NroMovBco As String = ""
   '
   Public CtaCont As String
   Public Rechazar As Boolean
   '
   Public Caja As Int16
   Public BancoCh As Int16 = 0
   Public CuentaCh As String = ""
   Public NumeroCh As String = ""
   '
   Dim CtaChSel As String = ""
   '
   Dim Trn As OleDb.OleDbTransaction
   Dim Cmd As New OleDb.OleDbCommand
   Dim Drd As OleDb.OleDbDataReader
   Dim Cm2 As New OleDb.OleDbCommand
   Dim Dr2 As OleDb.OleDbDataReader
   '
   Dim cImput As String
   Dim cTipoMov As String
   Dim ChCartId As Long
   Dim cCtaCaja As String
   Dim cCtaCajaA As String
   Dim cCtaVCar As String
   Dim i As Integer
   '
   Const ESTEMI = 1
   Const ESTDEP = 1
   Const EstCONC = 2
   Const EstANUL = 3
   Const EstRECH = 3
   '
   Private Sub frmBancodMovAM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      '
      GetRegForm(Me)
      '
      Me.Text = Me.Text & " - " & Traducir(IIf(Concilia, "Conciliar", IIf(Alta, "Alta", "Modificar")))
      '
      Cmd.Connection = cn
      Cm2.Connection = cn
      '
      ArmaComboItem(cbBanco, "Bancos", "Banco", "Nombre", "Nombre", , "Banco IN( SELECT DISTINCT Banco FROM BancosCtas)", , , , Banco)
      If Banco = 0 Then
         With cbCuentaBco
            If .Items.Count = 2 Then
               .SelectedIndex = 1
            End If
         End With
      Else
         cbBanco.Enabled = False
      End If
      '
      If BancoCta <> "" Then
         cbCuentaBco.Text = BancoCta
         cbCuentaBco.Enabled = False
      End If
      '
      If SisContable Then
         If cfgCtaValCar = "" Then
            DeshabForm(Me)
         End If
      Else
         lblCuenta.Enabled = False
         tbCuenta.Enabled = False
         cbDescCta.Enabled = False
      End If
      '
      If TipoMovBco <> 0 Then
         cboTipoMovBco.Enabled = False
      End If
      ArmaComboItem(cboTipoMovBco, "TipoMovBco", "TipoMovBco", , , "(Seleccionar)", , , , , TipoMovBco)
      '
      If SisContable Then
         ArmaCombo(cbDescCta, "Descrip", "PlanCtas", , "RecAsi <> 0", "Descrip", "(Seleccionar)")
      End If
      '
      If Caja <> 0 Then
         cbCaja.Enabled = False
      End If
      ArmaComboItem(cbCaja, "Cajas", "Caja", , , "(Seleccionar)", "Caja <> 0", , , , IIf(Caja <> 0, Caja, prmNroCaja))
      '
      If Alta Then
         cbNumero.Enabled = True
         tbFechaEmi.Value = Today
         tbFechaEmi.MaxDate = Today
         tbFechaAcr.Value = Today
         If Deposito Then
            optCheque.Checked = True
            optCheque.Enabled = False
            optEfectivo.Enabled = False
         End If
      Else
         cmdSalir.Visible = False
         Me.CancelButton = cmdCancelar
         '
         With Cmd
            .CommandText = "SELECT * FROM BancosMov WHERE Banco = " & Banco & " AND BancoCta = '" & BancoCta & "' AND TipoMovBco = " & TipoMovBco & " AND NroMovBco = '" & NroMovBco & "'"
            Drd = .ExecuteReader
         End With
         With Drd
            If .Read Then
               cbNumero.Text = NroMovBco
               tbFechaEmi.Value = !FechaEmi
               tbFechaAcr.Value = !FechaAcr
               tbImporte.Text = !Debe + !Haber
               tbDetalle.Text = !Detalle
               If Not IsDBNull(!HojaBco) Then
                  If !HojaBco > 0 Then
                     tbHojaNro.Text = !HojaBco
                  End If
               End If
               '
               If SisContable Then
                  tbCuenta.Text = !CtaCont & ""
               End If
               '
               If cTipoMov = "CH" Then
                  With cbNumero
                     .Enabled = False
                  End With
                  '
               ElseIf cTipoMov = "DP" Then
                  If !ChCartId <> 0 Then
                     '
                     optCheque.Checked = True
                     '
                     Cm2.CommandText = "SELECT * FROM ChCartera WHERE ChCartId = " & !ChCartId
                     Dr2 = Cm2.ExecuteReader
                     '
                     If Dr2.Read Then
                        cbBancoCh.Text = CapturaDato(Cn, "Bancos", "Nombre", "Banco = " & Dr2!Banco)
                        cbCuentaCh.Text = Dr2!BancoCta
                        cbNumeroCh.Text = Dr2!ChCartNro
                        tbImporte.Text = Format(!Debe + !Haber, "Fixed")
                        optCheque.Checked = True
                     Else
                        MensajeTrad("ChCartNoEnc", , False)
                        DeshabForm(Me)
                     End If
                     '
                     Dr2.Close()
                     '
                  Else
                     optEfectivo.Checked = True
                     PosCboItem(cbCaja, !Caja)
                  End If
                  '
               ElseIf cTipoMov = "EX" Then
                  optEfectivo.Checked = True
                  PosCboItem(cbCaja, !Caja)
               End If
               '
            Else
               MensajeTrad("MovNoEnc", , False)
               DeshabForm(Me)
            End If
            '
            .Close()
            '
         End With
      End If
      '
      tbFechaEmi.Enabled = Not Concilia And Alta
      tbImporte.Enabled = Not Concilia
      cmdConciliar.Visible = Concilia
      cmdAceptar.Visible = Not Concilia
      cmdSalir.Visible = Not Concilia
      tbHojaNro.Enabled = Concilia
      '
   End Sub
   '
   Private Sub frmBancodMovAM_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
      TabReturn(e.KeyChar)
   End Sub
   '
   Private Sub cbBanco_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbBanco.SelectedIndexChanged
      '
      With cbBanco
         If .SelectedIndex > 0 Then
            Banco = .SelectedValue
         Else
            Banco = 0
         End If
      End With
      '
      ArmaCombo(cbCuentaBco, "BancoCta", "BancosCtas", "BancoCta", "Banco = " & Banco, "BancoCta")
      '
      With cbCuentaBco
         If .Items.Count = 2 Then
            .SelectedIndex = 1
         End If
      End With
      '
   End Sub
   '
   Private Sub cbCuentaBco_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCuentaBco.SelectedIndexChanged
      With cbCuentaBco
         If .SelectedIndex > 0 Then
            BancoCta = .Text
         Else
            BancoCta = ""
         End If
      End With
   End Sub
   '
   Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
      If Alta Then
         ArmaControles()
      Else
         Me.Close()
      End If
   End Sub
   '
   Private Sub cbCaja_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCaja.SelectedIndexChanged
      '
      With cbCaja
         If .SelectedIndex > 0 Then
            Caja = .SelectedValue
         Else
            Caja = -1
         End If
      End With
      '
      If cTipoMov = "DP" Then
         '
         If optEfectivo.Checked Or cTipoMov = "EX" Then
            If SisContable Then
               If Not CaptCtasCaja(Caja, cCtaCaja, cCtaCajaA) Then
                  cbCaja.SelectedIndex = 0
               End If
            End If
            '
            If optCheque.Checked Then
               ArmaCbNroImp()
            End If
            '
         End If
      End If
   End Sub
   '
   Private Sub cboTipoMovBco_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipoMovBco.SelectedIndexChanged
      '
      With cboTipoMovBco
         If .SelectedIndex > 0 Then
            TipoMovBco = .SelectedValue
         Else
            TipoMovBco = 0
         End If
      End With
      '
      tbCuenta.Enabled = SisContable
      cbDescCta.Enabled = SisContable
      '
      cImput = CapturaDato(Cn, "TipoMovBco", "Imput", "TipoMovBco = " & TipoMovBco)
      cTipoMov = CapturaDato(Cn, "TipoMovBco", "TipoMov", "TipoMovBco = " & TipoMovBco)
      '
      ArmaControles()
      '
      ActDesCtrl()
      '
   End Sub
   '
   Private Sub ArmaControles()
      '
      Select Case cTipoMov
         Case "CH"
            If Alta Then
               ArmaCombo(cbNumero, "ChPropNro", "ChPropios", "ChPropNro", "Estado = 0", , "(Seleccionar)")
            Else
               With cbNumero
                  .Items.Clear()
                  .Items.Add(NroMovBco)
               End With
            End If
            '
            'With cbNumero
            '.DropDownStyle = ComboBoxStyle.DropDownList
            'End With
            '
         Case "DP"
            tbCuenta.Enabled = False
            cbDescCta.Enabled = False
            '
         Case "DB"
            '
         Case "CR"
            '
         Case "EX"
            '
      End Select
      '
      tbFechaAcr.Value = tbFechaEmi.Value
      tbImporte.Text = ""
      cbNumero.Text = ""
      tbDetalle.Text = ""
      '
   End Sub
   ' 
   Private Sub cbImporteDep_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbImporteCh.SelectedIndexChanged
      If cbImporteCh.Items.Count > 0 Then
         cbNumeroCh.SelectedIndex = cbImporteCh.SelectedIndex
      End If
      cbNumero.Text = Val(cbNumeroCh.Text)
   End Sub
   '
   Private Sub cbNumeroDep_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbNumeroCh.SelectedIndexChanged
      If cbNumeroCh.Items.Count > 0 Then
         If cbImporteCh.Items.Count > 0 Then
            cbImporteCh.SelectedIndex = cbNumeroCh.SelectedIndex
            If BancoCh > 0 Then
               If CuentaCh <> "" Then
                  If cbNumeroCh.SelectedIndex > 0 Then
                     tbFechaEmi.Value = CapturaDato(Cn, "ChCartera", "FechaEmi", "Banco = " & BancoCh & " AND BancoCta = '" & CuentaCh & "' AND ChCartNro = '" & cbNumeroCh.Text & "'")
                  End If
               End If
            End If
            tbFechaAcr.Value = Today
         End If
      End If
      tbImporte.Text = Val(cbImporteCh.Text)
   End Sub
   '
   Private Sub cmdAceptar_Click(sender As Object, e As EventArgs) Handles cmdAceptar.Click
      '
      If Banco = 0 Then
         MensajeTrad("DIBanco", , False)
         cbBanco.Focus()
         Exit Sub
      End If
      '
      If BancoCta = "" Then
         MensajeTrad("DICuentaBco", , False)
         cbCuentaBco.Focus()
         Exit Sub
      End If
      '
      If TipoMovBco = 0 Then
         MensajeTrad("DITipoMov", , False)
         cboTipoMovBco.Focus()
         Exit Sub
      End If
      '
      If cTipoMov = "CH" Then
         If cbNumero.Text = "" Then
            MensajeTrad("DINumero", , False)
            cbNumero.Focus()
            Exit Sub
         End If
      Else
         If cbNumero.Text = "" Then
            MensajeTrad("DINumero", , False)
            cbNumero.Focus()
            Exit Sub
         End If
      End If
      '
      If tbFechaEmi.Value > Today Then
         MensajeTrad("FecEmi>Date")
         tbFechaEmi.Focus()
         Exit Sub
      End If
      '
      If tbFechaAcr.Value < tbFechaEmi.Value Then
         MensajeTrad("FecAcr<Emi")
         tbFechaAcr.Focus()
         Exit Sub
      End If
      '
      If cTipoMov = "DP" Then
         If Not optEfectivo.Checked And Not optCheque.Checked Then
            MensajeTrad("DIEFoCH")
            Exit Sub
         End If
      End If
      '
      If optEfectivo.Checked Then
         If Caja = 0 Then
            MensajeTrad("DICaja")
            cbCaja.Focus()
            Exit Sub
         End If
      End If
      '
      If Val(tbImporte.Text) = 0 Then
         If cTipoMov <> "DP" Or optEfectivo.Checked Then
            MensajeTrad("DIImporte")
            tbImporte.Focus()
            Exit Sub
         End If
      End If
      '
      If Val(cbImporteCh.Text) = 0 Then
         If cTipoMov = "DP" And optCheque.Checked Then
            MensajeTrad("DII>0")
            cbImporteCh.Focus()
            Exit Sub
         End If
      End If
      '
      If SisContable Then
         If InStr("DP EX", cTipoMov) = 0 Then
            If tbCuenta.Text = "" Then
               MensajeTrad("DICuenta")
               cbDescCta.Focus()
               Exit Sub
            End If
         End If
      End If
      '
      If Rechazar Then
         If tbDetalle.Text = "" Then
            MensajeTrad("DIMotRech")
            tbDetalle.Focus()
            Exit Sub
         End If
      End If
      '
      If Guardar() Then
         Me.Close()
      End If
      '
   End Sub
   '
   Private Sub ActDesCtrl()
      '
      cbNumero.Enabled = Alta
      optEfectivo.Enabled = (cTipoMov = "DP")
      optCheque.Enabled = (cTipoMov = "DP")
      '
      If cTipoMov = "CH" Then
         cbNumeroCh.Visible = False
         cbNumero.Visible = True
         '
      ElseIf cTipoMov = "DP" Then
         cbNumero.Enabled = optEfectivo.Checked
         tbImporte.Enabled = optEfectivo.Checked
         cbBancoCh.Enabled = optCheque.Checked
         cbCuentaCh.Enabled = optCheque.Checked
         cbImporteCh.Enabled = optCheque.Checked
         cbNumeroCh.Enabled = optCheque.Checked
         '
      ElseIf cTipoMov = "EX" Then
         optEfectivo.Checked = True
         cbCaja.Enabled = True
         cbImporteCh.Enabled = False
         cbNumeroCh.Enabled = False
      End If
      '
   End Sub
   '
   Private Sub ArmaCbDep()
      If optCheque.Checked Then
         If cTipoMov = "DP" Then
            ArmaComboItem(cbBancoCh, "Bancos", "Banco", "Nombre", "Nombre", , "Banco IN( SELECT DISTINCT Banco FROM ChCartera WHERE Estado = 0 AND Caja = " & Caja & ")", , , , BancoCh)
            If BancoCh > 0 Then
               cbBancoCh.Enabled = False
            End If
         End If
      End If
   End Sub
   '
   Private Sub cbBancoDep_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbBancoCh.SelectedIndexChanged
      '
      With cbBancoCh
         If .SelectedIndex > 0 Then
            BancoCh = .SelectedValue
         Else
            BancoCh = 0
         End If
      End With
      '
      If CuentaCh <> "" Then
         CtaChSel = CuentaCh
      End If
      '
      ArmaCombo(cbCuentaCh, "BancoCta", "ChCartera", "BancoCta", "Banco = " & BancoCh & " AND Estado = 0 AND Caja = " & Caja, , "(Seleccionar)", True)
      '
      If CtaChSel <> "" Then
         cbCuentaCh.Text = CtaChSel
         cbCuentaCh.Enabled = False
      End If
      '
      ArmaCbNroImp()
      '
   End Sub
   '
   Private Sub optCheque_CheckedChanged(sender As Object, e As EventArgs) Handles optCheque.CheckedChanged
      '
      ActDesCtrl()
      '
      ArmaCbDep()
      '
      If Alta Then
         If cTipoMov = "DP" And optCheque.Checked Then
            cbNumeroCh.Focus()
         End If
      End If
      '
   End Sub
   '
   Private Sub optEfectivo_CheckedChanged(sender As Object, e As EventArgs) Handles optEfectivo.CheckedChanged
      '
      ActDesCtrl()
      '
   End Sub
   '
   Private Sub tbFechaEmi_Change()
      tbFechaAcr.MinDate = tbFechaEmi.Value
   End Sub
   '
   Private Sub tbHojaNro_KeyPress(KeyAscii As Integer)
      SoloNumeros(KeyAscii, False)
   End Sub
   '
   Private Sub tbImporte_KeyPress1(sender As Object, e As KeyPressEventArgs) Handles tbImporte.KeyPress
      SoloNumeros(e.KeyChar, True)
   End Sub
   '
   Private Function Guardar() As Boolean
      '
      Dim compCaja As String
      Dim cDetCaja As String
      Dim cComp As String
      Dim nDebe As Double
      Dim nHaber As Double
      Dim nImporte As Double
      '
      Dim CodAsi As String
      Dim NroAsi As Long
      Dim RenASi As Integer
      Dim DetAsi As String
      '
      nImporte = Val(tbImporte.Text)
      '
      If cImput = "D" Then
         nDebe = nImporte
      Else
         nHaber = nImporte
      End If
      '
      compCaja = cTipoMov & "-" & Banco & "-" & BancoCta & "-" & cbNumero.Text
      CodAsi = compCaja
      DetAsi = IIf(tbDetalle.Text <> "", tbDetalle.Text, CodAsi)
      '
      If cTipoMov = "DP" Then
         If optCheque.Checked Then
            ChCartId = Val(CapturaDato(Cn, "ChCartera", "ChCartId", "Banco = " & BancoCh & " AND BancoCta = '" & cbCuentaCh.Text & "' AND ChCartNro = '" & cbNumeroCh.Text & "'"))
            If ChCartId = 0 Then
               MensajeTrad("ChCartNoEnc")
            End If
         End If
      End If
      '
      If Alta Then
         If Not IsNothing(CapturaDato(Cn, "BancosMov", "Banco", "Banco = " & Banco & " AND BancoCta = '" & BancoCta & "' AND TipoMovBco = " & TipoMovBco & " AND NroMovBco = " & cbNumero.Text)) Then
            MensajeTrad("MovExiste")
            Exit Function
         End If
      End If
      '
      Trn = cn.BeginTransaction
      '
      With Cmd
         '
         .Transaction = Trn
         '
         If Alta Then
            .CommandText = "INSERT INTO BancosMov(Banco, BancoCta, TipoMovBco, NroMovBco, FechaEmi, FechaAcr, Debe, Haber, Detalle, ChCartId, Caja, Estado, CtaCont, Usuario, FechaMod) " & _
                           "VALUES(" & Banco & ", " & _
                                 "'" & BancoCta & "', " & _
                                       TipoMovBco & ", " & _
                                       cbNumero.Text & ", " & _
                                 "'" & Format(tbFechaEmi.Value, FormatFecha) & "', " & _
                                 "'" & Format(tbFechaAcr.Value, FormatFecha) & "', " & _
                                       nDebe & ", " & _
                                       nHaber & ", " & _
                                 "'" & tbDetalle.Text & "', " & _
                                       ChCartId & ", " & _
                                       Caja & ", " & _
                                       ESTEMI & ", " & _
                                 "'" & tbCuenta.Text & "', " & _
                                 "'" & Uid & "', " & _
                                 "'" & Format(Now, FormatFechaHora) & "')"
         Else
            .CommandText = "UPDATE BancosMov SET " & _
                           " FechaEmi = '" & Format(tbFechaEmi.Value, FormatFecha) & "', " & _
                           " FechaAcr = '" & Format(tbFechaAcr.Value, FormatFecha) & "', " & _
                           " Debe = " & nDebe & ", " & _
                           " Haber = " & nHaber & ", " & _
                           " Detalle = '" & tbDetalle.Text & "', " & _
                           " ChCartId = " & ChCartId & ", " & _
                           " Caja = " & Caja & ", " & _
                           " Estado = " & ESTEMI & ", " & _
                           " CtaCont = '" & tbCuenta.Text & "', " & _
                           " Usuario = '" & Uid & "', " & _
                           " FechaMod = '" & Format(Now, FormatFechaHora) & "' " & _
                           "WHERE Banco = " & Banco & _
                           "  AND BancoCta = '" & BancoCta & "'" & _
                           "  AND TipoMovBco = " & TipoMovBco & _
                           "  AND NroMovBco = '" & cbNumero.Text & "'"
         End If
         .ExecuteNonQuery()
         '
      End With
      '
      If SisContable Then
         NroAsi = GuardaAsiento(CodAsi, tbFechaAcr.Value, DetAsi, Trn)
         If NroAsi = 0 Then
            Err.Raise(1001, , "NoUpAsiento")
         End If
         '
         If Not BorraAsienDet(NroAsi, Trn) Then
            Err.Raise(1001, , "NoDelAsiento")
         End If
         '
         RenASi = IIf(cImput = "D", 1, 2)
         If Not GuardaAsienDet(NroAsi, RenASi, CtaCont, DetAsi, nDebe, nHaber, Trn) Then
            Err.Raise(1001, , "NoUpAsiento")
         End If
      End If
      '
      If cTipoMov = "CH" Then
         With Cmd
            .CommandText = "UPDATE ChPropios SET " & _
                           " Estado = " & ESTEMI & ", " & _
                           " Usuario = '" & Uid & "', " & _
                           " FechaMod = '" & Format(Now, FormatFechaHora) & "' " & _
                           "WHERE Banco = " & Banco & _
                           "  AND BancoCta = '" & BancoCta & "'" & _
                           "  AND ChPropNro = '" & cbNumero.Text & "'"
            .ExecuteNonQuery()
         End With
         '
         With cbNumero
            .Items.Remove(.SelectedIndex)
         End With
         '
         If SisContable Then
            RenASi = IIf(cImput = "D", 2, 1)
            If Not GuardaAsienDet(NroAsi, RenASi, tbCuenta.Text, DetAsi, nHaber, nDebe, Trn) Then
               Err.Raise(1001, , "NoUpAsiento")
            End If
         End If
         '
      ElseIf cTipoMov = "DP" Then
         If optCheque.Checked Then
            With Cmd
               .CommandText = "UPDATE ChCartera SET " & _
                              " Estado = " & ESTEMI & ", " & _
                              " Usuario = '" & Uid & "', " & _
                              " FechaMod = '" & Format(Now, FormatFechaHora) & "' " & _
                              "WHERE Banco = " & BancoCh & _
                              "  AND BancoCta = '" & cbCuentaCh.Text & "'" & _
                              "  AND ChCartNro = '" & cbNumeroCh.Text & "'"
               .ExecuteNonQuery()
            End With
         End If
         '
         If SisContable Then
            RenASi = IIf(cImput = "D", 2, 1)
            If Not GuardaAsienDet(NroAsi, RenASi, IIf(optEfectivo.Checked, cCtaCaja, cCtaVCar), DetAsi, nHaber, nDebe, Trn) Then
               Err.Raise(1001, , "NoUpAsiento")
            End If
         End If
         '
         If optEfectivo.Checked Then
            cDetCaja = IIf(tbDetalle.Text = "", "DEP. EFECTIVO", tbDetalle.Text)
            cComp = "EF"
         Else
            cDetCaja = "CH. Bco. " & cbBancoCh.Text & " Nº: " & cbNumeroCh.Text
            cComp = "CH"
         End If
         '
         ActCaja(prmNroCaja, compCaja, cComp, tbFechaEmi.Value, cbBanco.Text, "", cDetCaja, 0, nImporte, True, Trn)
         '
      ElseIf cTipoMov = "EX" Then
         '
         If SisContable Then
            RenASi = IIf(cImput = "D", 2, 1)
            If Not GuardaAsienDet(NroAsi, RenASi, cCtaCaja, DetAsi, nHaber, nDebe) Then
               Err.Raise(1001, , "NoUpAsiento")
            End If
         End If
         '
         cDetCaja = IIf(tbDetalle.Text = "", "EXTRACCION", tbDetalle.Text)
         cComp = "EF"
         '
         If Not ActCaja(prmNroCaja, compCaja, cComp, tbFechaEmi.Value, cbBanco.Text, "", cDetCaja, nImporte, 0, True, Trn) Then
            Err.Raise(1001, , "NoActCaja")
         End If
         '
      ElseIf cTipoMov = "TC" Then
         '
      Else
         '
         If SisContable Then
            RenASi = IIf(cImput = "D", 2, 1)
            If Not GuardaAsienDet(NroAsi, RenASi, tbCuenta.Text, DetAsi, nHaber, nDebe) Then
               Err.Raise(1001, , "NoUpAsiento")
            End If
         End If
         '
      End If
      '
      GuardarAudit(IIf(Alta, "Alta", "Modif.") & "Mov. Bancos", cboTipoMovBco.Text & ": " & cbNumero.Text, "BancosMovAM", "Guardar", Trn)
      '
      Trn.Commit()
      '
      ArmaCbDep()
      '
      Return True
      '
mError:
      MsgBox(Err.Number & ": " & Err.Description & Chr(13) + Chr(10) & _
             Traducir("TransNComp"))
      Trn.Rollback()
      Return False
      '
   End Function
   '
   Private Sub cmdConciliar_Click(sender As Object, e As EventArgs) Handles cmdConciliar.Click
      '
      If tbFechaAcr.Value > Today Then
         MensajeTrad("FecAcr>Hoy")
         tbFechaAcr.Focus()
         Exit Sub
      End If
      '
      If Val(tbHojaNro.Text) = 0 Then
         MensajeTrad("DIHojaBanco")
         tbHojaNro.Focus()
         Exit Sub
      End If
      '
      Trn = Cn.BeginTransaction
      '
      With Cmd
         .Transaction = Trn
         .CommandText = "UPDATE BancosMov SET " & _
                        " FechaAcr = '" & Format(tbFechaAcr.Value, FormatFecha) & "', " & _
                        " Estado = " & EstCONC & ", " & _
                        " HojaBco = " & tbHojaNro.Text & ", " & _
                        " Usuario = '" & Uid & "', " & _
                        " FechaMod = '" & Format(Now, FormatFechaHora) & "' " & _
                        "WHERE Banco = " & Banco & _
                        "  AND BancoCta = '" & BancoCta & "'" & _
                        "  AND TipoMovBco = " & TipoMovBco & _
                        "  AND NroMovBco = '" & cbNumero.Text & "'"
         .ExecuteNonQuery()
      End With
      '
      If cTipoMov = "CH" Then
         With Cmd
            .CommandText = "UPDATE ChPropios SET " & _
                           " Estado = " & EstCONC & ", " & _
                           " Usuario = '" & Uid & "', " & _
                           " FechaMod = '" & Format(Now, FormatFechaHora) & "' " & _
                           "WHERE Banco = " & Banco & _
                           "  AND BancoCta = '" & BancoCta & "'" & _
                           "  AND ChPropNro = '" & cbNumero.Text & "'"
            .ExecuteNonQuery()
         End With
      End If
      '
      Trn.Commit()
      '
      Me.Close()
      '
      ''mError:
      ''      MsgBox(Err.Number & ": " & Err.Description & Chr(13) + Chr(10) & _
      ''             Traducir("TransNComp"))
      ''      Cn.Rollback()
      '
   End Sub
   '
   Private Sub tbNumero_KeyPress(KeyAscii As Integer)
      SoloNumeros(KeyAscii, False)
   End Sub
   '
   Private Sub txtCuenta_Change()
      cbDescCta = CapturaDato(cn, "PlanCtas", "Descrip", "CtaCont = '" & tbCuenta.Text & "'")
   End Sub
   '
   Private Sub cbCuentaDep_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCuentaCh.SelectedIndexChanged
      With cbCuentaCh
         If .Items.Count > 0 Then
            If .SelectedIndex > 0 Then
               CuentaCh = .Text
            Else
               CuentaCh = ""
            End If
         Else
            CuentaCh = ""
         End If
      End With
      ArmaCbNroImp()
   End Sub
   '
   Private Sub ArmaCbNroImp()
      ArmaCombo(cbNumeroCh, "ChCartNro", "ChCartera", "ChCartNro", "Banco = " & BancoCh & IIf(CuentaCh = "", "", " AND BancoCta = '" & CuentaCh & "'") & " AND Caja = " & Caja & " AND Estado = 0", , "(Seleccionar)")
      ArmaCombo(cbImporteCh, "Importe", "ChCartera", "ChCartNro", "Banco = " & BancoCh & IIf(CuentaCh = "", "", " AND BancoCta = '" & CuentaCh & "'") & " AND Caja = " & Caja & " AND Estado = 0", , "(Seleccionar)")
      If NumeroCh <> "" Then
         cbNumeroCh.Text = NumeroCh
         cbNumeroCh.Enabled = False
         cbImporteCh.Enabled = False
      End If
   End Sub
   '
   Private Sub cmdSalir_Click(sender As Object, e As EventArgs) Handles cmdSalir.Click
      Me.Close()
   End Sub
   '
   Private Sub frmBancosMovAM_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
      SetRegForm(Me)
      Me.Dispose()
   End Sub
   '

   Private Sub tbImporte_TextChanged(sender As Object, e As EventArgs) Handles tbImporte.TextChanged

   End Sub
End Class