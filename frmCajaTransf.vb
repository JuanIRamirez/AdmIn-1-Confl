Public Class FrmCajaTransf
   '
   Public Alta As Boolean
   Public Caja1 As Integer
   Public Caja2 As Integer
   Public Comprob As String
   Public fPago As String
   Public Cuenta As String
   Public Recupero As Boolean
   '
   Dim Cmd As New OleDb.OleDbCommand
   Dim Drd As OleDb.OleDbDataReader
   '
   Dim GenAsi As Boolean
   Dim cCtaCaja1 As String
   Dim cCtaCaja2 As String
   Dim cCtaVCar As String
   Dim cSqlCaja As String
   Dim ImporteAnt As Double
   Dim SaldoAnt As Double
   Dim Banco As Long
   Dim cCtaBco As String
   Dim NroComp As Int32
   '
   Dim cTmp As String
   Const cStruct = "Origen VARCHAR (1), " &
                   "Banco INT, " &
                   "BancoCta VARCHAR(15), " &
                   "Titular VARCHAR(50), " &
                   "Numero VARCHAR(50), " &
                   "Fecha SMALLDATETIME, " &
                   "Importe FLOAT"
   Const cmpInt = "TR"
   '
   Private Sub FrmCajaTransf_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      '
      GetRegForm(Me)
      '
      TraducirForm(Me)
      '
      Me.Text = Me.Text & " - " & IIf(Alta, "Alta", "Edición")
      '
      ArmaComboItem(cboCaja1, "Cajas", "Caja", "Descrip", "Descrip", "(Seleccionar)")
      ArmaComboItem(cboCaja2, "Cajas", "Caja", "Descrip", "Descrip", "(Seleccionar)", "Caja <> " & Val(prmNroCaja))
      ArmaComboBancos()
      '
      cTmp = ""
      CrearTabla(Cn, cStruct, cTmp)
      '
      If Alta Then
         fPago = "EF"
         PosCboItem(cboCaja1, Val(prmNroCaja))
      Else
         PosCboItem(cboCaja1, Val(Caja1))
         PosCboItem(cboCaja2, Val(Caja2))
         tbComprob.Text = Comprob
         With Cmd
            .CommandText = "SELECT * FROM Caja WHERE Comprob = '" & Comprob & "' AND fPago = '" & fPago & "'"
            Drd = .ExecuteReader
         End With
         With Drd
            If .Read Then
               txtDetalle.Text = !Detalle
               txtImporte.Text = !Entrada + !Salida
               ImporteAnt = Val(txtImporte.Text)
            End If
            .Close()
         End With
      End If
      '
   End Sub
   '
   Private Sub cboBanco_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBanco.SelectedIndexChanged
      With cboBanco
         If .SelectedIndex > 0 Then
            Banco = .SelectedValue
         Else
            Banco = 0
         End If
      End With
      If optCheque.Checked Then
         ArmaCombo(cboCtaBanco, "BancoCta", "ChCartera", "ChCartNro", "Estado = 0 AND Banco = " & Banco & " AND Caja = " & prmNroCaja)
         ArmaCombo(cboNumero, "ChCartNro", "ChCartera", "ChCartNro", "Estado = 0 AND Banco = " & Banco & " AND Caja = " & prmNroCaja)
      End If
   End Sub
   '
   Private Sub cboNumero_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboNumero.SelectedIndexChanged
      cboCtaBanco.SelectedIndex = cboNumero.SelectedIndex
      txtImporte.Text = CapturaDato(Cn, "ChCartera", "Importe", "Estado = 0 AND Banco = " & Banco & " AND BancoCta = '" & cboCtaBanco.Text & "' AND ChCartNro = '" & cboNumero.Text & "'")
   End Sub
   '
   Private Sub ArmaComboBancos()
      ArmaComboItem(cboBanco, "Bancos", "Banco", "Nombre", "Nombre", , "Banco IN( SELECT Distinct Banco FROM ChCartera WHERE Estado = 0 AND Caja = " & prmNroCaja & ")")
   End Sub
   '
   Private Sub frmCajaTransf_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
      TabReturn(e.KeyChar)
   End Sub
   '
   Private Sub cboCaja1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCaja1.SelectedIndexChanged
      With cboCaja1
         If .SelectedIndex > 0 Then
            Caja1 = .SelectedValue
         Else
            Caja1 = 0
         End If
      End With
      ArmaComprob()
   End Sub
   '
   Private Sub cboCaja2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCaja2.SelectedIndexChanged
      With cboCaja2
         If .SelectedIndex > 0 Then
            Caja2 = .SelectedValue
         Else
            Caja2 = 0
         End If
      End With
      ArmaComprob()
   End Sub
   '
   Private Sub ArmaComprob()
      If Caja1 <> 0 Then
         If SisContable Then
            CaptCtasCaja(Caja1, cCtaCaja1, "", False)
            If IsNothing(CapturaDato(Cn, "Cajas", "Caja", "Caja = " & Caja1)) Then
               GenAsi = False
            Else
               GenAsi = True
            End If
         End If
         CaptComprob()
      End If
      If Caja2 <> 0 Then
         CaptCtasCaja(Caja2, cCtaCaja2, "", False)
      End If
   End Sub
   '
   Private Sub CaptComprob(Optional ByVal Trn As Object = "")
      If Alta Then
         If GenAsi Then
            tbComprob.Text = cmpInt & ProximoNroAsi(Trn)
         Else
            tbComprob.Text = ProxCompCaja(cmpInt, NroComp, Trn)
         End If
         Comprob = tbComprob.Text
      End If
   End Sub
   '
   Private Sub CmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
      '
      Dim Trn As OleDb.OleDbTransaction
      Dim nCaja As Integer
      Dim Importe As Double
      Dim CtaCont As String
      Dim nTipo As Integer
      Dim ok As Boolean
      '
      nTipo = CapturaDato(Cn, "TipoMovBco", "TipoMovBco", "TipoMov = 'CH'")
      '
      If Caja1 = 0 Then
         MensajeTrad("DICajaOrigen")
         cboCaja1.Focus()
         Exit Sub
      End If
      '
      If Caja2 = 0 Then
         MensajeTrad("DICajaDestino")
         cboCaja2.Focus()
         Exit Sub
      End If
      '
      If Not optEfectivo.Checked And Not optCheque.Checked Then
         MensajeTrad("DIEfeOCh")
         Exit Sub
      End If
      '
      If Val(txtImporte.Text) = 0 Then
         MensajeTrad("DIImporte")
         txtImporte.Focus()
         Exit Sub
      Else
         Importe = Val(txtImporte.Text)
      End If
      '
      If optEfectivo.Checked Then
         fPago = "EF"
         CtaCont = cCtaCaja1
      Else
         fPago = "CH"
         CtaCont = cCtaVCar
         If Banco = 0 Then
            MensajeTrad("DIBanco")
            cboBanco.Focus()
            Exit Sub
         End If
         If Val(cboNumero.Text) = 0 Then
            MensajeTrad("DINumeroCh")
            cboNumero.Focus()
            Exit Sub
         End If
      End If
      '
      If txtDetalle.Text = "" Then
         MensajeTrad("DIDetalle")
         txtDetalle.Focus()
         Exit Sub
      End If
      '
      Trn = Cn.BeginTransaction
      '
      Try
         '
         CaptComprob(Trn)
         '
         If GuardarCaja(Alta, GenAsi, cmpInt, Caja1, False, 0, Importe, fPago, Now, "", txtDetalle.Text, cCtaCaja2, ImporteAnt, cCtaCaja1, Trn, Comprob, False) Then
            If GuardarCaja(Alta, GenAsi, cmpInt, Caja2, True, 0, Importe, fPago, Now, "", txtDetalle.Text, cCtaCaja1, ImporteAnt, cCtaCaja2, Trn, Comprob, False) Then
               ok = True
            End If
         End If
         '
         If optCheque.Checked Then
            Cmd.Connection = Cn
            Cmd.Transaction = Trn
            Cmd.CommandText = "UPDATE ChCartera SET Caja = " & Caja2 & " WHERE Banco = " & Banco & " AND BancoCta = '" & cboCtaBanco.Text & "' AND ChCartNro = '" & cboNumero.Text & "'"
            Cmd.ExecuteNonQuery()
         End If
         '
         If Not ok Then
            Err.Raise(1001, "No se pugo guardar Transferencia de Caja !")
         End If
         '
         GuardarAudit(IIf(Alta, "Alta", "Modifica") & " Mov. Caja. ", Comprob & "; " & txtDetalle.Text & "; $ " & Me.txtImporte.Text, Me.Name, cmdAceptar.Name, Trn)
         '
         Trn.Commit()
         '
         If MsgConfirma("Imprime Comprobante") Then
            Dim Formulas As New Collection
            Formulas.Add("SonPesos = '" & Numero_a_Texto(txtImporte.Text) & "'")
            ImprimirCrp("CompCaja", crptToWindow, "{Caja.Comprob} = '" & tbComprob.Text & "'", "Comprobante de Caja", Formulas)
         End If
         '
         If Alta Then
            nCaja = cboCaja1.SelectedValue
            LimpiaCtrl(Me)
            cboCaja1.SelectedValue = nCaja
            ArmaComprob()
         Else
            Me.Close()
         End If
         '
      Catch ex As Exception
         Dim st As New StackTrace(True)
         MensageError(st, Err.Description)
         Trn.Rollback()
         '
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
   Private Sub optChequeP_Click()
      ArmaComboBancos()
      ActCtrl()
   End Sub
   '
   Private Sub optEfectivo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optEfectivo.CheckedChanged
      ActCtrl()
   End Sub
   '
   Private Sub ActCtrl()
      Panel1.Enabled = optCheque.Checked
      cboBanco.Enabled = optCheque.Checked
      cboNumero.Enabled = optCheque.Checked
      txtImporte.Enabled = optEfectivo.Checked
      lblBanco.Enabled = optCheque.Checked
      lblCtaBco.Enabled = optCheque.Checked
      lblNroCheque.Enabled = optCheque.Checked
   End Sub
   '
   Private Sub TxtImporte_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtImporte.KeyPress
      SoloNumeros(e.KeyChar, True)
   End Sub
   '
   Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
      Me.Close()
   End Sub
   '
   Private Sub FrmCajaTransf_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
      SetRegForm(Me)
   End Sub
   '
End Class