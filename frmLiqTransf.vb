Public Class frmLiqTransf
   '
   Public TablaTmp As String
   Public TransfRec As Boolean = False
   Public Total As Double = 0
   Public GtosBanc As Double = 0
   Public Alta As Boolean
   '
   Dim Trn As OleDb.OleDbTransaction
   Dim Cmd As New OleDb.OleDbCommand
   Dim Drd As OleDb.OleDbDataReader
   '
   Dim Banco0 As Integer
   Dim Banco1 As Integer
   Dim NumeroTR As Long
   '
   Private Sub frmLiqTransf_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      '
      dtFecha.Value = Today
      '
      If TransfRec Then
         ArmaComboItem(cbBanco0, "Bancos", "Banco", "Nombre", "Nombre", "...")
         ArmaComboItem(cbBanco1, "Bancos", "Banco", "Nombre", "Nombre", "...", "Banco IN (SELECT DISTINCT Banco FROM BancosCtas)")
         cbCuenta0.DropDownStyle = ComboBoxStyle.DropDown
      Else
         ArmaComboItem(cbBanco1, "Bancos", "Banco", "Nombre", "Nombre", "...")
         ArmaComboItem(cbBanco0, "Bancos", "Banco", "Nombre", "Nombre", "...", "Banco IN (SELECT DISTINCT Banco FROM BancosCtas)")
         cbCuenta1.DropDownStyle = ComboBoxStyle.DropDown
      End If
      '
      If cbBanco0.Items.Count = 1 Then
         cbBanco0.SelectedIndex = 0
      End If
      '
      Alta = CapturaDato(Cn, TablaTmp, "COUNT(1)", "") = 0
      '
      With Cmd
         .Connection = Cn
         .CommandText = "SELECT * FROM " & TablaTmp
         Drd = .ExecuteReader
      End With
      With Drd
         If .Read Then
            PosCboItem(cbBanco0, !Banco0)
            PosCboItem(cbBanco1, !Banco1)
            PosCombo(cbCuenta0, !Cuenta0)
            PosCombo(cbCuenta1, !Cuenta1)
            If TransfRec Then
               tbTitular1.Text = !Titular
            Else
               tbTitular0.Text = !Titular
            End If
            dtFecha.Value = !FechaTR
            tbNumero.Text = !NumeroTR
            tbImporte.Text = !ImporteTr
            tbGastos.Text = Val(!GastosImp & "")
            tbGastosSF.Text = Val(!GastosSF & "")
            tbIva.Text = Val(!GastosIva & "")
            tbImpNeto.Text = Val(!ImporteNeto & "")
         End If
         .Close()
      End With
      '
      NumeroTR = BuscarCfg("cfgNroTransf", 0)
      tbNumero.Text = NumeroTR + 1
      '
      If TransfRec Then
         gbGastos.Enabled = False
         tbGastos.Enabled = False
         tbIva.Enabled = False
         tbGastosSF.Enabled = False
         lblImporte.Text = "Importe Transferencia $"
      Else
         tbIva.Enabled = cfgGtosBancIva
      End If
      '
   End Sub
   '
   Private Sub cbCuenta0_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCuenta0.SelectedIndexChanged
      tbTitular0.Text = CapturaDato(Cn, "BancosCtas", "Titular", "Banco = " & Banco0 & " AND BancoCta = '" & cbCuenta0.Text & "'")
   End Sub
   '
   'Private Sub dtFecha_KeyDown(ByVal KeyCode As Integer, ByVal Shift As Integer)
   '   TabReturn(KeyCode)
   'End Sub
   '
   'Private Sub cboBanco_Change(ByVal Index As Integer)
   '   PintarCb(cboBanco(Index), LastKey)
   'End Sub
   '
   Private Sub Form_KeyPress(ByVal KeyAscii As Integer)
      'TabReturn(KeyAscii, True)
   End Sub
   '
   Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
      '
      If Not TransfRec Then
         If Banco0 = 0 Then
            MensajeTrad("DIBancoOri")
            cbBanco0.Focus()
            Exit Sub
         End If
         '
         If cbCuenta0.Text = "" Then
            MensajeTrad("DICuentaOri")
            cbCuenta0.Focus()
            Exit Sub
         End If
         '
         If tbTitular0.Text = "" Then
            MensajeTrad("DITitularOri")
            tbTitular0.Focus()
            Exit Sub
         End If
      Else
         If Banco1 = 0 Then
            MensajeTrad("DIBancoDes")
            cbBanco1.Focus()
            Exit Sub
         End If
         '
         If cbCuenta1.Text = "" Then
            MensajeTrad("DICuentaDes")
            cbCuenta1.Focus()
            Exit Sub
         End If
         '
         If tbTitular1.Text = "" Then
            MensajeTrad("DITitularDes")
            tbTitular1.Focus()
            Exit Sub
         End If
      End If
      '
      If tbNumero.Text = "" Then
         MensajeTrad("DINumero")
         tbNumero.Focus()
         Exit Sub
      End If
      '
      If Val(tbImporte.Text) = 0 Then
         MensajeTrad("DIImporte")
         tbImporte.Focus()
         Exit Sub
      End If
      '
      If Val(tbImpNeto.Text) <= 0 Then
         MensajeTrad("Imp.Neto<=0")
         tbImporte.Focus()
         Exit Sub
      End If
      '
      Try
         '
         Trn = Cn.BeginTransaction
         '
         With Cmd
            .Transaction = Trn
            If Alta Then
               .CommandText = "INSERT INTO " & TablaTmp & "( Banco0, Banco1, Cuenta0, Cuenta1, Titular, FechaTR, NumeroTR, ImporteTr" & _
                                               IIf(TransfRec, "", ", GastosImp, GastosSF, GastosIva, ImporteNeto") & ") " & _
                              "VALUES( " & Banco0 & ", " & _
                                           Banco1 & ", " & _
                                     "'" & cbCuenta0.Text & "', " & _
                                     "'" & cbCuenta1.Text & "', " & _
                                     "'" & IIf(TransfRec, tbTitular1.Text, tbTitular0.Text) & "', " & _
                                     "'" & Format(dtFecha.Value, FormatFecha) & "', " & _
                                           tbNumero.Text & ", " & _
                                           tbImporte.Text & _
                                           IIf(TransfRec, "", ", " & Val(tbGastos.Text) & ", " & _
                                                                     Val(tbGastosSF.Text) & ", " & _
                                                                     Val(tbIva.Text) & ", " & _
                                                                     Val(tbImpNeto.Text)) & ")"
            Else
               .CommandText = "UPDATE " & TablaTmp & " SET " & _
                              " Banco0 = " & Banco0 & ", " & _
                              " Banco1 = " & Banco1 & ", " & _
                              " Cuenta0 = '" & cbCuenta0.Text & "', " & _
                              " Cuenta1 = '" & cbCuenta1.Text & "', " & _
                              " Titular = '" & IIf(TransfRec, tbTitular1.Text, tbTitular0.Text) & "', " & _
                              " FechaTR = '" & Format(dtFecha.Value, FormatFecha) & "', " & _
                              " NumeroTR = " & tbNumero.Text & ", " & _
                              " ImporteTr = " & tbImporte.Text & _
                              IIf(TransfRec, "", "," & " GastosImp = " & Val(tbGastos.Text) & ", " & _
                                                       " GastosSF = " & Val(tbGastosSF.Text) & ", " & _
                                                       " GastosIva = " & Val(tbIva.Text) & ", " & _
                                                       " ImporteNeto = " & Val(tbImpNeto.Text))
            End If
            .ExecuteNonQuery()
         End With
         '
         GuardarCfg(cfgNroTransf, "cfgNroTransf", Val(tbNumero.Text), Trn)
         '
         Trn.Commit()
         '
      Catch ex As Exception
         '
         Dim st As New StackTrace(True)
         RegistrarError(st, "frmLiqTransf", , , cmdAceptar.Name)
         Trn.Rollback()
         '
      End Try
      '
      Total = tbImporte.Text
      GtosBanc = Val(tbGastos.Text) + Val(tbGastosSF.Text) + Val(tbIva.Text)
      '
      Me.Close()
      '
      Exit Sub
      '
   End Sub
   '
   Private Sub cmdAlta_Click()
      LimpiaCtrl(Me)
      Alta = True
      cbBanco0.Focus()
   End Sub
   '
   Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
      '
      Dim Cerrar As Boolean
      '
      If Val(tbImporte.Text) = 0 And Val(tbGastos.Text) = 0 And Val(tbGastosSF.Text) = 0 And Val(tbIva.Text) = 0 Then
         Cerrar = True
      Else
         '
         If MsgConfirma("Cancela transferencia") Then
            Trn = Cn.BeginTransaction
            With Cmd
               .Transaction = Trn
               .CommandText = "DELETE FROM " & TablaTmp
               .ExecuteNonQuery()
            End With
            Trn.Commit()
            Cerrar = True
            Total = 0
            GtosBanc = 0
         Else
            Cerrar = False
         End If
      End If
      '
      If Cerrar Then
         Me.Close()
      End If
      '
   End Sub
   '
   Private Sub cmdEdicion_Click()
      Alta = False
   End Sub
   '
   Private Sub cbBanco0_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbBanco0.SelectedIndexChanged
      '
      With cbBanco0
         If .SelectedIndex > 0 Then
            Banco0 = .SelectedValue
         Else
            Banco0 = 0
         End If
      End With
      '
      If Not TransfRec Then
         ArmaComboItem(cbCuenta0, "BancosCtas", "Banco", "BancoCta", "BancoCta", "", "Banco = " & Banco0)
         With cbCuenta0
            If .Items.Count = 1 Then
               .SelectedIndex = 0
            End If
         End With
      End If
      '
   End Sub

   Private Sub cbBanco1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbBanco1.SelectedIndexChanged
      '
      With cbBanco1
         If .SelectedIndex > 0 Then
            Banco1 = .SelectedValue
         Else
            Banco1 = 0
         End If
         '
         If TransfRec Then
            ArmaComboItem(cbCuenta1, "BancosCtas", "Banco", "BancoCta", "BancoCta", "", "Banco = " & Banco1)
            With cbCuenta1
               If .Items.Count = 1 Then
                  .SelectedIndex = 0
               End If
            End With
         End If
         '
      End With
      '
   End Sub
   '
   Private Sub cbCuenta1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCuenta1.SelectedIndexChanged
      If TransfRec Then
         tbTitular1.Text = CapturaDato(Cn, "BancosCtas", "Titular", "Banco = " & Banco1 & " AND BancoCta = '" & cbCuenta1.Text & "'") & ""
      End If
   End Sub
   '
   Private Sub tbGastos_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbGastos.TextChanged, tbGastosSF.TextChanged, tbIva.TextChanged
      CalcNeto()
   End Sub
   '
   Private Sub CalcGastos()
      Dim PorcIva As Single
      PorcIva = Val(CapturaDato(Cn, "AlicIva", "Alicuo1", "Codigo = 'GEN'"))
      tbGastos.Text = Format(Val(tbImporte.Text) * cfgGtosBancPT / 100, "Fixed")
      tbGastosSF.Text = Format(cfgGtosBancSF, "Fixed")
      If cfgGtosBancIva Then
         tbIva.Text = Format((Val(tbGastos.Text) + Val(tbGastosSF.Text)) * PorcIva / 100, "Fixed")
      Else
         tbIva.Text = Format(0, "Fixed")
      End If
      CalcNeto()
   End Sub
   '
   Private Sub CalcNeto()
      tbImpNeto.Text = Val(tbImporte.Text) - Val(tbGastos.Text) - Val(tbGastosSF.Text) - Val(tbIva.Text)
   End Sub
   '
   Private Sub tbImporte_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbImporte.TextChanged
      If TransfRec Then
         CalcNeto()
      Else
         CalcGastos()
      End If
   End Sub
   '
   Private Sub tbImporte_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbImporte.KeyPress, tbGastos.KeyPress, tbGastosSF.KeyPress, tbIva.KeyPress
      SoloNumeros(e.KeyChar, True)
   End Sub
   '
   Private Sub tbNumero_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbNumero.KeyPress
      SoloNumeros(e.KeyChar)
   End Sub
   '
   Private Sub frmLiqTransf_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
      SetRegForm(Me)
   End Sub
   '
End Class