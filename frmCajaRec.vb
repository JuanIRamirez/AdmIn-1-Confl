Public Class frmCajaRec
   '
   Public Alta As Boolean = True
   Public Caja As Int16
   Public Comprob, fPago, Cuenta, Usuario As String
   Public Recupero As Boolean
   '
   Dim Trn As OleDb.OleDbTransaction
   Dim Cmd As New OleDb.OleDbCommand
   Dim Drd As OleDb.OleDbDataReader
   Dim Cm2 As New OleDb.OleDbCommand
   '
   Dim MovRec As Long
   Dim cCtaCaja As String
   Dim cCtaVCar As String
   Dim cSqlCaja As String
   Dim ImporteAnt As Double
   Dim SaldoAnt As Double
   Dim Banco As Long
   Dim cCtaBco As String
   Dim cTmpCh As String
   '
   Const cmpInt = "MN"
   Const estEMIT = 1
   '
   Const cStrCh = "Renglon SMALLINT, " & _
                  "Origen VARCHAR (1), " & _
                  "Banco INT, " & _
                  "DescBco VARCHAR(50), " & _
                  "BancoCta VARCHAR(25), " & _
                  "Titular VARCHAR(50), " & _
                  "Numero VARCHAR(25), " & _
                  "Fecha SMALLDATETIME, " & _
                  "Importe FLOAT, " & _
                  "CtaCont VARCHAR(15), " & _
                  "Usuario VARCHAR(25)"
   '
   Private Sub frmCajaRec_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      '
      GetRegForm(Me)
      '
      TraducirForm(Me)
      '
      Me.Text = Me.Text & " - " & IIf(Alta, "Alta", "Edición")
      '
      cTmpCh = ""
      If Not CrearTabla(Cn, cStrCh, cTmpCh) Then
         DeshabForm(Me)
      End If
      '
      If SisContable Then
         ArmaComboCuentas()
      Else
         lblCuenta.Enabled = False
         tbCuenta.Enabled = False
         cbCuenta.Enabled = False
      End If
      '
      ArmaComboItem(cbCaja, "Cajas", "Caja", "Descrip", "Descrip", "(Seleccionar)")
      '
      Cmd.Connection = Cn
      '
      If Alta Then
         dtpFecha.Value = Today
         fPago = "EF"
         PosCboItem(cbCaja, Val(prmNroCaja))
      Else
         PosCboItem(cbCaja, Val(Caja))
         tbComprob.Text = Comprob
         With Cmd
            .CommandText = "SELECT * FROM Caja WHERE Comprob = '" & Comprob & "' AND fPago = '" & fPago & "'"
            Drd = .ExecuteReader
            With Drd
               If .Read Then
                  dtpFecha.Value = !Fecha
                  tbDetalle.Text = !Detalle
                  tbNombre.Text = !Nombre & ""
                  tbEfectivo.Text = !Entrada + !Salida
                  ImporteAnt = Val(tbEfectivo.Text)
               End If
               .Close()
            End With
         End With
      End If
      '
      dtpFecha.MaxDate = Today
      '
   End Sub
   '
   Private Sub frmCajaRec_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
      TabReturn(e.KeyChar)
   End Sub
   '
   Private Sub ArmaComboCuentas()
      ArmaCombo(cbCuenta, "Descrip", "PlanCtas", "Descrip", "RecAsi <> 0")
      PosCombo(cbCuenta, Cuenta)
   End Sub
   '
   Private Sub cmdCancelar_Click()
      If Alta Then
         With dtpFecha
            If .Enabled Then
               .Focus()
            End If
         End With
      Else
         Me.Close()
      End If
   End Sub
   '
   Private Sub tbCuenta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbCuenta.TextChanged
      cbCuenta.Text = CapturaDato(Cn, "PlanCtas", "Descrip", "Cuenta = '" & tbCuenta.Text & "'")
   End Sub
   '
   Private Sub cbCuenta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCuenta.SelectedIndexChanged
      If cbCuenta.SelectedIndex > 0 Then
         tbCuenta.Text = CapturaDato(Cn, "PlanCtas", "Cuenta", "Descrip = '" & cbCuenta.Text & "'")
      End If
   End Sub
   '
   Private Sub cbCaja_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCaja.SelectedIndexChanged
      With cbCaja
         If .SelectedIndex > 0 Then
            Caja = .SelectedValue
         Else
            Caja = -1
         End If
      End With
      ArmaComprob()
   End Sub
   '
   Private Sub ArmaComprob(Optional Tr As Object = "")
      If Caja > -1 Then
         If SisContable Then
            CaptCtasCaja(Caja, cCtaCaja, "", False)
         End If
         '
         If Alta Then
            If SisContable Then
               tbComprob.Text = cmpInt & ProximoNroAsi(Tr)
            Else
               tbComprob.Text = ProxCompCaja(, MovRec, Tr)
            End If
            Comprob = tbComprob.Text
         End If
      End If
   End Sub
   '
   Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
      '
      Dim Rs As New OleDb.OleDbCommand
      Dim RsD As New OleDb.OleDbCommand
      Dim nCaja As Integer
      Dim Importe As Double
      Dim CtaCont As String
      Dim nTipo As Integer
      Dim nContCh As Integer
      Dim NroAsi As Long
      Dim RenASi As Integer
      Dim DetAsi As String = ""

      '
      nTipo = CapturaDato(Cn, "TipoMovBco", "TipoMovBco", "TipoMov = 'CH'")
      '
      If Caja = 0 Then
         MensajeTrad("DICaja")
         If cbCaja.Enabled Then
            cbCaja.Focus()
         End If
         Exit Sub
      End If
      '
      If dtpFecha.Value > Today Then
         MensajeTrad("Fec>Date")
         If dtpFecha.Enabled Then
            dtpFecha.Focus()
         End If
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
      If Val(tbEfectivo.Text) = 0 And Val(tbCheques.Text) = 0 Then
         '
         MensajeTrad("Debe Ingresar importes Efectivo o Cheques")
         tbEfectivo.Focus()
         Exit Sub
         '
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
         ArmaComprob(Trn)
         '
         If SisContable Then
            DetAsi = "Mov.Caja Rec. " & Comprob
            NroAsi = GuardaAsiento(Comprob, dtpFecha.Value, DetAsi, Trn)
            '
            RenASi = RenASi + 1
            If Not GuardaAsienDet(NroAsi, RenASi, tbCuenta.Text, DetAsi, Val(tbTotal.Text), 0, Trn) Then
               Err.Raise(1001, , Traducir("NoUpAsiento"))
            End If
         End If
         '
         If Val(tbEfectivo.Text) > 0 Then
            Importe = Val(tbEfectivo.Text)
            fPago = "EF"
            CtaCont = cCtaCaja
            '
            If Not GuardarCaja(Alta, False, cmpInt, Caja, False, MovRec, Importe, fPago, Now, tbNombre.Text, tbDetalle.Text, tbCuenta.Text, ImporteAnt, CtaCont, Trn, Comprob, True) Then
               Err.Raise(1001, , "No se pudo guardar caja")
            End If
            '
            If SisContable Then
               RenASi = RenASi + 1
               If Not GuardaAsienDet(NroAsi, RenASi, CtaCont, DetAsi, 0, Val(tbEfectivo.Text), Trn) Then
                  Err.Raise(1001, , Traducir("NoUpAsiento"))
               End If
            End If
         End If
         '
         If Val(tbCheques.Text) > 0 Then
            '
            RsD.Connection = Cn
            '
            With Rs
               .Connection = Cn
               .Transaction = Trn
               .CommandText = "SELECT * FROM " & cTmpCh
               Drd = .ExecuteReader
               With Drd
                  Do While .Read
                     nContCh = nContCh + 1
                     If !Origen = "C" Then
                        Importe = !Importe
                        fPago = "CH"
                        CtaCont = cCtaVCar
                        If Not GuardarCaja(Alta, False, cmpInt, Caja, False, MovRec, Importe, fPago, Now, tbNombre.Text, tbDetalle.Text, tbCuenta.Text, ImporteAnt, CtaCont, Trn, Comprob, True) Then
                           Err.Raise(1001, , "No se pudo guardar caja")
                        End If
                     End If
                     '
                     If SisContable Then
                        'Detalle Asiento (Banco/Ch.Cartera).
                        RenASi = RenASi + 1
                        If Not GuardaAsienDet(NroAsi, RenASi, IIf(!Origen = "P", !CtaCont, cCtaVCar), DetAsi, 0, !Importe, Trn) Then
                           Err.Raise(1001, , Traducir("NoUpAsiento"))
                        End If
                     End If
                     '
                     If !Origen = "P" Then
                        nTipo = CapturaDato(Cn, "TipoMovBco", "TipoMovBco", "TipoMov = 'CH'", , , , Trn)
                        '                     '
                        Importe = !Importe
                        fPago = "CP"
                        CtaCont = cCtaBco
                        '
                        If Not GuardarCaja(Alta, False, cmpInt, Caja, False, MovRec, Importe, fPago, Now, tbNombre.Text, tbDetalle.Text, tbCuenta.Text, ImporteAnt, CtaCont, Trn, Comprob, True) Then
                           Err.Raise(1001, , "No se pudo guardar caja")
                        End If
                        '
                        If Not IsNothing(CapturaDato(Cn, "BancosMov", "NroMovBco", "Banco = " & !Banco & " AND BancoCta = '" & !BancoCta & "' AND TipoMovBco = " & nTipo & " AND NroMovBco = '" & !Numero & "'", , , , Trn)) Then
                           Err.Raise(1001, "frmCajaRec", Traducir("MovBcoExiste", , Trn))
                        End If
                        '
                        RsD.Transaction = Trn
                        RsD.CommandText = "INSERT INTO BancosMov( Banco, BancoCta, TipoMovBco, NroMovBco, FechaEmi, FechaAcr, Debe, Haber, Detalle, Estado, HojaBco, Usuario, FechaMod) " & _
                                          "VALUES(" & !Banco & ", " & _
                                                "'" & !BancoCta & "', " & _
                                                      nTipo & ", " & _
                                                "'" & !Numero & "', " & _
                                                "'" & Format(Today, FormatFecha) & "', " & _
                                                "'" & Format(!Fecha, FormatFecha) & "', " & _
                                                      0 & ", " & _
                                                      !Importe & ", " & _
                                                "'" & DetAsi & "', " & _
                                                      estEMIT & ", " & _
                                                      0 & ", " & _
                                                "'" & Uid & "', " & _
                                                "'" & Format(Now, FormatFechaHora) & "')"
                        RsD.ExecuteNonQuery()
                        '
                        If IsNothing(CapturaDato(Cn, "ChPropios", "ChPropNro", "Banco = " & !Banco & " AND BancoCta = '" & !BancoCta & "' AND TipoMovBco = " & nTipo & " AND ChPropNro = '" & !Numero & "'", , , , Trn)) Then
                           RsD.CommandText = "INSERT INTO ChPropios( Banco, BancoCta, TipoMovBco, ChPropNro, Estado, Usuario, FechaMod) " & _
                                             "VALUES(" & !Banco & ", " & _
                                                   "'" & !BancoCta & "', " & _
                                                         nTipo & ", " & _
                                                   "'" & !Numero & "', " & _
                                                         estEMIT & ", " & _
                                                   "'" & Uid & "', " & _
                                                   "'" & Format(Now, FormatFechaHora) & "')"
                        Else
                           RsD.CommandText = "UPDATE ChPropios SET " & _
                                             " Estado = " & estEMIT & ", " & _
                                             " Usuario = '" & Uid & "', " & _
                                             " FechaMod = '" & Format(Now, FormatFechaHora) & "' " & _
                                             "WHERE Banco = " & !Banco & " AND BancoCta = '" & !BancoCta & "' AND TipoMovBco = " & nTipo & " AND ChPropNro = '" & !Numero & "'"
                        End If
                        RsD.ExecuteNonQuery()
                     Else
                        '
                        If IsNothing(CapturaDato(Cn, "ChCartera", "ChCartNro", "Estado = 0 AND Banco = " & !Banco & " AND BancoCta = '" & !BancoCta & "' AND ChCartNro = '" & !Numero & "'", , , , Trn)) Then
                           Err.Raise(1001, "frmCajaRec", Traducir("ChNoEnc", , Trn))
                        End If
                        '
                        RsD.Transaction = Trn
                        RsD.CommandText = "UPDATE ChCartera SET " & _
                                          " Estado = 2, " & _
                                          " Usuario = '" & Uid & "', " & _
                                          " FechaMod = '" & Format(Now, FormatFechaHora) & "' " & _
                                          "WHERE Estado = 0 AND Banco = " & !Banco & " AND BancoCta = '" & !BancoCta & "' AND ChCartNro = '" & !Numero & "'"
                        RsD.ExecuteNonQuery()
                     End If
                     '
                     RsD.CommandText = "INSERT INTO CajaRecCh( Comprob, Origen, Banco, BancoCta, Numero, Titular, Fecha, Importe, Usuario, FechaMod) " & _
                                       "VALUES('" & Comprob & "', " & _
                                              "'" & !Origen & "', " & _
                                                    !Banco & ", " & _
                                              "'" & !BancoCta & "', " & _
                                              "'" & !Numero & "', " & _
                                              "'" & !Titular & "', " & _
                                              "'" & Format(!Fecha, FormatFecha) & "', " & _
                                                    !Importe & ", " & _
                                              "'" & Uid & "', " & _
                                              "'" & Format(Now, FormatFechaHora) & "')"
                     RsD.ExecuteNonQuery()
                     '
                  Loop
                  .Close()
               End With
            End With
         End If
         '
         GuardarAudit(IIf(Alta, "Alta", "Modifica") & " Mov. Caja. ", Comprob & "; " & tbNombre.Text & "; " & tbDetalle.Text & "; $ " & Val(tbEfectivo.Text) + Val(tbCheques.Text), Me.Name, btnAceptar.Name, Trn)
         '
         Trn.Commit()
         '
         If MsgConfirma("Imprime Comprobante") Then
            Dim Formulas(0, 1) As String
            Formulas(0, 0) = "SonPesos" : Formulas(0, 1) = "'" & Numero_a_Texto(Val(tbEfectivo.Text) + Val(tbCheques.Text)) & "'"
            ImprimirCrp("CompCaja", crptToWindow, "{Caja.Comprob} = '" & tbComprob.Text & "'", "Comprobante de Caja", Formulas)
         End If
         '
         frmCaja.ActData()
         '
         If Alta Then
            nCaja = cbCaja.SelectedValue
            LimpiaCtrl(Me)
            cbCaja.SelectedValue = nCaja
            If dtpFecha.Enabled Then
               dtpFecha.Focus()
            End If
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
         '
      End Try
      '
   End Sub
   '
   Private Sub tbCheques_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbCheques.TextChanged
      CalcTotal()
   End Sub
   '
   Private Sub tbEfectivo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbEfectivo.KeyPress
      SoloNumeros(e.KeyChar, True)
   End Sub
   '
   Private Sub tbEfectivo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbEfectivo.TextChanged
      CalcTotal()
   End Sub
   '
   Private Sub CalcTotal()
      tbTotal.Text = Format(Val(tbEfectivo.Text) + Val(tbCheques.Text), "Fixed")
   End Sub
   '
   Private Sub cmdIngCheques_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIngCheques.Click
      If CaptCtasConc(cfgCodigoVCar, "", cCtaVCar, "") Then
         Dim Frm As New frmPagoCh
         With Frm
            .Titulo = "Caja a Recuperar"
            .TablaAct = cTmpCh
            .ShowDialog(Me)
            tbCheques.Text = Format(.Total, "Fixed")
         End With
      Else
         MensajeTrad("Cuenta Valores en Cartera no definida")
      End If
   End Sub
   '
   Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
      Me.Close()
   End Sub
   '
   Private Sub frmCajaRec_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
      frmCajaAM = Nothing
      SetRegForm(Me)
   End Sub
   '
End Class