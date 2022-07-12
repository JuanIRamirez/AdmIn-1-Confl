Public Class frmCajaAM
   '
   Public Alta As Boolean
   Public Caja As Integer
   Public Comprob As String
   Public fPago As String
   Public Cuenta As String
   Public Recupero As Boolean
   '
   Dim Trn As OleDb.OleDbTransaction
   Dim Cmd As New OleDb.OleDbCommand
   Dim Drd As OleDb.OleDbDataReader
   '
   Dim GenAsi As Boolean
   Dim cCtaCaja As String
   Dim cCtaVCar As String
   Dim cSqlCaja As String
   Dim ImporteAnt As Double
   Dim SaldoAnt As Double
   Dim Banco As Long
   Dim cCtaBco As String
   Dim MovRec As Long
   Dim NumeroComp As Long
   '
   Const cmpInt = "MN"
   '
   Private Sub frmCajaAM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      '
      GetRegForm(Me)
      '
      TraducirForm(Me)
      '
      Me.Text = Me.Text & " - " & IIf(Alta, "Alta", "Edición")
      '
      If SisContable Then
         ArmaComboCuentas()
      Else
         lblCuenta.Enabled = False
         tbCuenta.Enabled = False
         cbCuenta.Enabled = False
      End If
      '
      ArmaComboItem(cbCaja, "Cajas", "Caja", "Descrip", "Descrip", "(Seleccionar)", , , , , prmNroCaja)
      ArmaComboBancos()
      '
      If Alta Then
         dtpFecha.Value = Today
         dtpFecCheque.Value = Today
         fPago = "EF"
         PosCboItem(cbCaja, prmNroCaja)
      Else
         PosCboItem(cbCaja, Caja)
         tbComprob.Text = Comprob
         With Cmd
            .Connection = Cn
            .CommandText = "SELECT * FROM Caja WHERE Comprob = '" & Comprob & "' AND fPago = '" & fPago & "'"
            Drd = .ExecuteReader
            With Drd
               If .Read Then
                  PosCboItem(cbCaja, !Caja)
                  dtpFecha.Value = !Fecha
                  tbDetalle.Text = !Detalle & ""
                  tbNombre.Text = !Nombre & ""
                  optEntrada.Checked = (!Entrada > 0)
                  optSalida.Checked = (!Salida > 0)
                  cbImporte.Text = !Entrada + !Salida
                  ImporteAnt = Math.Round(Val(cbImporte.Text), 2)
                  If Not IsDBNull(!MovRec) Then
                     chkMovRec.Checked = True
                     PosCombo(cbMovRec, !MovRec)
                  End If
                  If SisContable Then
                     tbCuenta.Text = !Cuenta & ""
                  End If
                  If Mid(!fPago, 1, 2) = "CH" Then
                     optCheque.Checked = True
                  End If
               End If
               .Close()
            End With
            '
            .CommandText = "SELECT * FROM ChCartera WHERE Comprob = '" & Comprob & "'"
            Drd = .ExecuteReader
            With Drd
               If .Read Then
                  PosCboItem(cbBanco, !Banco)
                  cbCtaBanco.Text = !BancoCta
                  cbNumero.Text = !ChCartNro
                  dtpFecCheque.Value = !FechaDif
                  cbImporte.Text = !Importe
               End If
               .Close()
            End With
            '
         End With
      End If
      '
      dtpFecha.MaxDate = Today
      '  dtpFecha.Enabled = LGR
      '
   End Sub
   '
   Private Sub frmCajaAM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
      TabReturn(e.KeyChar)
   End Sub
   '
   Private Sub cbBanco_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbBanco.SelectedIndexChanged
      With cbBanco
         If .SelectedIndex > 0 Then
            Banco = .SelectedValue
         Else
            Banco = 0
         End If
      End With
      If optCheque.Checked Then
         ArmaCombo(cbCtaBanco, "BancoCta", "ChCartera", "BancoCta", "Estado = 0 AND Banco = " & Banco, , , True)
      Else
         ArmaCombo(cbCtaBanco, "BancoCta", "BancosCtas", "BancoCta", "Banco = " & Banco)
      End If
   End Sub
   '
   Private Sub cbCtaBanco_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCtaBanco.SelectedIndexChanged
      If optCheque.Checked Then
         If optSalida.Checked Then
            ArmaCombo(cbNumero, "ChCartNro", "ChCartera", "ChCartNro", "Estado = 0 AND Banco = " & Banco & " AND BancoCta = '" & cbCtaBanco.Text & "'")
            ArmaCombo(cbImporte, "Importe", "ChCartera", "ChCartNro", "Estado = 0 AND Banco = " & Banco & " AND BancoCta = '" & cbCtaBanco.Text & "'")
         End If
      Else
         If optSalida.Checked Then
            ArmaCombo(cbNumero, "ChPropNro", "ChPropios", "ChPropNro", "Estado = 0 AND Banco = " & Banco & " AND BancoCta = '" & cbCtaBanco.Text & "'")
            cCtaBco = CapturaDato(Cn, "BancosCtas", "CtaCont", "Banco = " & Banco & " AND BancoCta = '" & cbCtaBanco.Text & "'")
         End If
      End If
   End Sub
   '
   Private Sub cbNumero_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbNumero.SelectedIndexChanged
      With cbImporte
         If .Enabled And .Visible Then
            .SelectedIndex = cbNumero.SelectedIndex
         End If
      End With
   End Sub
   '
   Private Sub cbImporte_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbImporte.KeyPress
      SoloNumeros(e.KeyChar, True)
   End Sub
   '
   Private Sub cbImporte_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbImporte.SelectedIndexChanged
      cbNumero.SelectedIndex = cbImporte.SelectedIndex
   End Sub
   '
   Private Sub cbMovRec_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbMovRec.TextChanged
      MovRec = Val(cbMovRec.Text)
      ActMovRec()
   End Sub
   '
   Private Sub cbMovRec_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbMovRec.SelectedIndexChanged
      If optEntrada.Checked Then
         With cbMovRec
            If .SelectedIndex > 0 Then
               MovRec = .SelectedValue
            Else
               MovRec = 0
            End If
         End With
      End If
      ActMovRec()
   End Sub
   '
   Private Sub ActMovRec()
      If Alta Then
         tbDetalle.Text = CapturaDato(Cn, "Caja", "Detalle", "MovRec = " & MovRec & " AND Salida <> 0") & ""
      End If
      SaldoAnt = Math.Round(Val(CapturaDato(Cn, "Caja", "SUM(SaldoRec)", "MovRec = " & MovRec & " AND Salida <> 0") & ""), 2)
      CalcSaldo()
      chkMovRec.Checked = IIf(MovRec > 0, True, False)
   End Sub
   '
   Private Sub ArmaComboBancos()
      ArmaComboItem(cbBanco, "Bancos", "Banco", "Nombre", "Nombre", "(Seleccionar)", IIf(optChequeP.Checked, "Banco IN(SELECT DISTINCT Banco FROM BancoCta)", ""))
   End Sub
   '
   Private Sub chkMovRec_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMovRec.CheckedChanged
      '
      If Not chkMovRec.Checked Then
         If SisContable Then
            ArmaComboCuentas()
            cbCuenta.Enabled = True
            tbCuenta.Enabled = True
         End If
      Else
         If SisContable Then
            If cfgCtaCajaRec = "" Then
               MensajeTrad("Cuenta Cajas a Recuperar, no definida")
               chkMovRec.Checked = False
            End If
            tbCuenta.Text = cfgCtaCajaRec
         End If
         '
         cbCuenta.Enabled = False
         tbCuenta.Enabled = False
         '
         If optSalida.Checked Then
            cbMovRec.Text = NumeroComp
         End If
         '
      End If
      '
      ActCtrl()
      '
   End Sub
   '
   Private Sub ArmaComboCuentas()
      ArmaCombo(cbCuenta, "Descrip", "PlanCtas", "Descrip", "RecAsi <> 0", , "(Seleccionar)")
      PosCombo(cbCuenta, Cuenta)
   End Sub
   '
   Private Sub tbCuenta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbCuenta.TextChanged
      cbCuenta.Text = CapturaDato(Cn, "PlanCtas", "Descrip", "Cuenta = '" & tbCuenta.Text & "'")
   End Sub
   '
   Private Sub cbCuenta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCuenta.SelectedIndexChanged
      tbCuenta.Text = CapturaDato(Cn, "PlanCtas", "Cuenta", "Descrip = '" & cbCuenta.Text & "'")
   End Sub
   '
   Private Sub cbCaja_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCaja.SelectedIndexChanged
      With cbCaja
         If .SelectedIndex > 0 Then
            Caja = .SelectedValue
         Else
            Caja = 0
         End If
      End With
      ArmaComprob()
   End Sub
   '
   Private Sub ArmaComprob()
      If Caja <> 0 Then
         CaptCtasCaja(Caja, cCtaCaja, "", False)
         If IsNothing(CapturaDato(Cn, "Cajas", "Caja", "Caja = " & Caja)) Then
            GenAsi = False
         Else
            GenAsi = True And SisContable
         End If
         CaptComprob()
         If optEntrada.Checked Then
            esEntrada()
         End If
      End If
   End Sub
   '
   Private Sub CaptComprob(Optional ByVal Tr As Object = "")
      If Alta Then
         If GenAsi Then
            NumeroComp = ProximoNroAsi(Tr)
            tbComprob.Text = cmpInt & NumeroComp
         Else
            tbComprob.Text = ProxCompCaja(, NumeroComp, Tr)
         End If
         Comprob = tbComprob.Text
      End If
   End Sub
   '
   Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
      '
      Dim nCaja As Integer
      Dim Importe As Double
      Dim CtaCont As String
      Dim nTipo As Integer
      '
      nTipo = CapturaDato(Cn, "TipoMovBco", "TipoMovBco", "TipoMov = 'CH'")
      '
      If Caja = 0 Then
         MensajeTrad("DICaja")
         cbCaja.Focus()
         Exit Sub
      End If

      If dtpFecha.Value > Today Then
         MensajeTrad("Fec>Date")
         If dtpFecha.Enabled Then
            dtpFecha.Focus()
         End If
         Exit Sub
      End If

      If Not optEntrada.Checked And Not optSalida.Checked Then
         MensajeTrad("DSelEntSal")
         Exit Sub
      End If
      '
      If SisContable Then
         If tbCuenta.Text = "" Then
            MensajeTrad("DICuenta")
            If cbCuenta.Enabled Then
               cbCuenta.Focus()
            End If
            Exit Sub
         End If
      End If
      '
      If MovRec > 0 Then
         If Val(tbSaldo.Text) < 0 Then
            MensajeTrad("Imp>saldo")
            cbImporte.Focus()
            Exit Sub
         End If
      End If
      '
      If optEfectivo.Checked Or optEntrada.Checked Or optChequeP.Checked Then
         If Val(cbImporte.Text) = 0 Then
            MensajeTrad("DIImporte")
            cbImporte.Focus()
            Exit Sub
         End If
      Else
         If cbImporte.Text = "" Or cbNumero.Text = "" Then
            MensajeTrad("DiImpoNro")
            cbImporte.Focus()
            Exit Sub
         End If
      End If
      '
      If optChequeP.Checked Then
         If cbNumero.Text = "" Then
            MensajeTrad("Debe ingresar Número")
            cbNumero.Focus()
            Exit Sub
         End If
      End If
      '
      If optEfectivo.Checked Then
         Importe = Val(cbImporte.Text)
         fPago = "EF"
         CtaCont = cCtaCaja
      ElseIf optCheque.Checked Then
         Importe = Val(IIf(optSalida.Checked, cbImporte.Text, cbImporte.Text))
         fPago = "CH"
         CtaCont = cCtaVCar
         If Banco = 0 Then
            MensajeTrad("DIBanco")
            cbBanco.Focus()
            Exit Sub
         End If
         If cbCtaBanco.Text = "" Then
            MensajeTrad("DICtaBanco")
            cbCtaBanco.Focus()
            Exit Sub
         End If
         If cbNumero.Text = "" Then
            MensajeTrad("DINumero")
            cbNumero.Focus()
            Exit Sub
         End If
      Else
         Importe = Val(cbImporte.Text)
         fPago = "CP"
         CtaCont = cCtaBco
      End If
      '
      If tbDetalle.Text = "" Then
         MensajeTrad("DIDetalle")
         tbDetalle.Focus()
         Exit Sub
      End If
      '
      Trn = Cn.BeginTransaction
      '
      Try
         '
         CaptComprob(Trn)
         '
         If GuardarCaja(Alta, GenAsi, cmpInt, Caja, optEntrada.Checked, MovRec, Importe, fPago, Now, tbNombre.Text, tbDetalle.Text, tbCuenta.Text, ImporteAnt, CtaCont, Trn, Comprob, chkMovRec.Checked) Then
            '
            If optCheque.Checked Then
               With Cmd
                  '
                  .Connection = Cn
                  .Transaction = Trn
                  '
                  If Me.optEntrada.Checked Then
                     If Alta Then
                        If Not IsNothing(CapturaDato(Cn, "ChCartera", "ChCartNro", "Banco = " & Banco & " AND BancoCta = '" & cbCtaBanco.Text & "' AND ChCartNro = '" & cbNumero.Text & "'", , , , Trn)) Then
                           Err.Raise(1001, , "Cheque existente")
                        End If
                     Else
                        .CommandText = "DELETE FROM ChCartera WHERE Banco = " & Banco & " AND BancoCta = '" & cbCtaBanco.Text & "' AND ChCartNro = '" & cbNumero.Text & "'"
                        .ExecuteNonQuery()
                     End If
                     .CommandText = "INSERT INTO ChCartera( Banco, BancoCta, ChCartNro, Titular, FechaEmi, FechaDif, Importe, Detalle, Estado, Caja, Comprob, Usuario, FechaMod) " & _
                                    "VALUES(" & Banco & ", " & _
                                          "'" & cbCtaBanco.Text & "', " & _
                                          "'" & cbNumero.Text & "', " & _
                                          "'" & tbNombre.Text & "', " & _
                                          "'" & Format(Today, FormatFecha) & "', " & _
                                          "'" & Format(dtpFecCheque.Value, FormatFecha) & "', " & _
                                                cbImporte.Text & ", " & _
                                          "'" & tbDetalle.Text & "', " & _
                                                0 & ", " & _
                                                prmNroCaja & ", " & _
                                          "'" & Comprob & "', " & _
                                          "'" & Uid & "', " & _
                                          "'" & Format(Now, FormatFechaHora) & "')"

                  Else
                     .CommandText = "UPDATE ChCartera SET " & _
                                    " Estado = 2, " & _
                                    " Comprob = '" & Comprob & "', " & _
                                    " Usuario = '" & Uid & "', " & _
                                    " FechaMod = '" & Format(Now, FormatFechaHora) & "' " & _
                                    "WHERE Banco = " & Banco & " AND BancoCta = '" & cbCtaBanco.Text & "' AND ChCartNro = '" & cbNumero.Text & "'"

                  End If
                  '
                  .ExecuteNonQuery()
                  '
               End With
               '
            ElseIf optChequeP.Checked Then
               With Cmd
                  If Alta Then
                     If Not IsNothing(CapturaDato(Cn, "BancosMov", "NroMovBco", "Banco = " & Banco & " AND BancoCta = '" & cbCtaBanco.Text & "' AND TipoMovBco = " & nTipo & " AND NroMovBco = '" & cbNumero.Text & "'", , , , Trn)) Then
                        Err.Raise(1001, , "Mov. Banco existente")
                     End If
                  Else
                     .CommandText = "DELETE FROM BancosMov WHERE Banco = " & Banco & " AND BancoCta = '" & cbCtaBanco.Text & "' AND TipoMovBco = " & nTipo & " AND NroMovBco = '" & cbNumero.Text & "'"
                     .ExecuteNonQuery()
                  End If
                  '
                  .CommandText = "INSERT INTO BancosMov( Banco, BancoCta, TipoMovBco, NroMovBco, FechaEmi, FechaAcr, Debe, Haber, Detalle, Estado, CtaCont, Usuario, FechaMod) " & _
                                 "VALUES(" & Banco & ", " & _
                                       "'" & cbCtaBanco.Text & "', " & _
                                             nTipo & ", " & _
                                             cbNumero.Text & ", " & _
                                       "'" & Format(Today, FormatFecha) & "', " & _
                                       "'" & Format(dtpFecCheque.Value, FormatFecha) & "', " & _
                                             0 & ", " & _
                                             Val(cbImporte.Text) & "', " & _
                                       "'" & tbDetalle.Text & "', " & _
                                             1 & ", " & _
                                       "'" & cbCuenta.Text & "', " & _
                                       "'" & Uid & "', " & _
                                       "'" & Format(Now, FormatFechaHora) & "')"
                  .ExecuteNonQuery()
                  '
                  If IsNothing(CapturaDato(Cn, "ChPropios", "NroMovBco", "Banco = " & Banco & " AND BancoCta = '" & cbCtaBanco.Text & "' AND TipoMovBco = " & nTipo & " AND NroMovBco = " & cbNumero.Text, , , , Trn)) Then
                     Err.Raise(1001, , Traducir("ChNoEnc"))
                  Else
                     .CommandText = "UPDATE ChPropios SET " & _
                                   " Estado = 1, " & _
                                   " Usuario = '" & Uid & "', " & _
                                   " FechaMod = '" & Format(Now, FormatFechaHora) & "' " & _
                                   "WHERE Banco = " & Banco & " AND BancoCta = '" & cbCtaBanco.Text & "' AND TipoMovBco = " & nTipo & " AND NroMovBco = " & cbNumero.Text
                     .ExecuteNonQuery()
                  End If
               End With
            End If
            '
            GuardarAudit(IIf(Alta, "Alta", "Modifica") & " Mov. Caja. ", Comprob & "; " & Me.tbNombre.Text & "; " & tbDetalle.Text & "; $ " & cbImporte.Text, Me.Name, Me.btnAceptar.Name, Trn)
            '
         End If
         '
         Trn.Commit()
         '
         If MsgConfirma("Imprime Comprobante") Then
            Dim Formulas(0, 1) As String
            '
            Formulas(0, 0) = "SonPesos" : Formulas(0, 1) = Numero_a_Texto(cbImporte.Text)
            '
            ImprimirCrp("CompCaja", crptToWindow, "{Caja.Comprob} = '" & tbComprob.Text & "'", "Comprobante de Caja", Formulas)
         End If
         '
         frmCaja.ActData()
         '
         If Alta Then
            nCaja = cbCaja.SelectedValue
            LimpiaCtrl(Me)
            cbCaja.SelectedValue = nCaja
            chkMovRec.Checked = False
            If dtpFecha.Enabled Then
               dtpFecha.Focus()
            End If
            ArmaComprob()
         Else
            Me.Close()
         End If
         '
         Exit Sub
         '
      Catch
         Trn.Rollback()
         Dim st As New StackTrace(True)
         MensageError(st, Me.Name)
      End Try
      '
   End Sub
   '
   Private Sub optCheque_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optCheque.CheckedChanged
      If CaptCtasConc(cfgCodigoVCar, "", cCtaVCar, "") Then
         ActCtrl()
      Else
         MensajeTrad("Cuenta Valores en Cartera no definida")
         optEfectivo.Checked = True
      End If
      ArmaComboBancos()
   End Sub
   '
   Private Sub optChequeP_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optChequeP.CheckedChanged
      ActCtrl()
      ArmaComboBancos()
   End Sub
   '
   Private Sub optEfectivo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optEfectivo.CheckedChanged
      ActCtrl()
   End Sub
   '
   Private Sub ActCtrl()
      '
      If Alta Then
         cbCtaBanco.Items.Clear()
         cbCtaBanco.Text = ""
         cbNumero.Items.Clear()
         cbNumero.Text = ""
         cbImporte.Items.Clear()
         cbImporte.Text = ""
      End If
      '
      optChequeP.Enabled = (chkMovRec.Checked And optSalida.Checked)
      dtpFecCheque.Enabled = (optCheque.Checked And optEntrada.Checked Or optChequeP.Checked)
      cbBanco.Enabled = (optCheque.Checked Or optChequeP.Checked)
      cbCtaBanco.Enabled = Not optEfectivo.Checked
      cbNumero.Enabled = (optCheque.Checked And optSalida.Checked Or Not optEfectivo.Checked)
      cbImporte.Enabled = optEntrada.Checked Or Not optCheque.Checked
      lblBanco.Enabled = optCheque.Checked
      lblCtaBco.Enabled = optCheque.Checked
      lblNroCheque.Enabled = optCheque.Checked
      lblFecCheque.Enabled = (optCheque.Checked And optEntrada.Checked Or optChequeP.Checked)
      cbMovRec.Enabled = optEntrada.Checked And Alta
      chkMovRec.Enabled = optSalida.Checked And Alta
      '
   End Sub
   '
   Private Sub optEntrada_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optEntrada.CheckedChanged
      esEntrada()
   End Sub
   '
   Private Sub esEntrada()
      ArmaComboItem(cbMovRec, "Caja C", "MovRec", "'(' + CAST(MovRec AS VarChar(10)) + ') ' + Comprob + ' | ' + Detalle + ' | ' + Nombre + ' | $' + CAST(Salida AS VarChar(12))", "MovRec", "(Seleccionar)", "Salida > 0 AND SaldoRec > 0", , , True)
      ActCtrl()
   End Sub
   '
   Private Sub optSalida_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optSalida.CheckedChanged
      cbMovRec.Enabled = False
      chkMovRec.Enabled = True
      ActCtrl()
   End Sub
   '
   Private Sub cbImporte_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbImporte.TextChanged
      If optEntrada.Checked And MovRec > 0 Then
         CalcSaldo()
      Else
         tbSaldo.Text = ""
      End If
   End Sub
   '
   Private Sub CalcSaldo()
      tbSaldo.Text = SaldoAnt - Val(cbImporte.Text) + ImporteAnt
   End Sub
   '
   Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
      Me.Close()
   End Sub
   '
   Private Sub frmCajaAM_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
      SetRegForm(Me)
   End Sub
   '
End Class