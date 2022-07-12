Public Class frmBancosCtasAM
   '
   Public Banco As Int32
   Public BancoCta As String = ""
   '
   'Dim Ctrl As Control
   Dim Alta As Boolean
   Dim cmd As New OleDb.OleDbCommand
   Dim Drd As OleDb.OleDbDataReader
   'Dim i As Integer
   Dim CtaCont As String
   '
   Const cTabla = "Bancos"

   Private Sub frmBancosCtas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      '
      GetRegForm(Me)
      '
      If Banco = 0 Then
         MensajeTrad("DinfBanco")
         DeshabForm(Me)
      End If
      '
      tbBanco.Text = CapturaDato(Cn, "Bancos", "Nombre", "Banco = " & Banco)
      '
      cmd.Connection = Cn
      '
      If BancoCta = "" Then
         Alta = True
      Else
         With cmd
            .CommandText = "SELECT * FROM BancosCtas WHERE Banco = " & Banco & " AND BancoCta = '" & BancoCta & "'"
            Drd = .ExecuteReader
         End With
         With Drd
            If .Read Then
               tbCtaBco.Enabled = False
               tbCtaBco.Text = !BancoCta
               tbDescrip.Text = !Descrip
               tbTitular.Text = !Titular
               tbSaldoIni.Text = !SaldoIni
               If SisContable Then
                  cboCtaCont.Text = CapturaDato(Cn, "PlanCtas", "Descrip", "CtaCont = '" & !CtaCont & "'")
               End If
               If IsDBNull(!FechaSdo) Then
                  dtpFechaSdo.Value = Today
               Else
                  dtpFechaSdo.Value = !FechaSdo
               End If
            End If
            .Close()
         End With
      End If
      If SisContable Then
         cboCtaCont.Enabled = True
         ArmaComboItem(cboCtaCont, "PlanCtas", "CtaCont", , , , "RecAsi <> 0")
      Else
         cboCtaCont.Enabled = False
      End If
      '
   End Sub
   '
   Private Sub frmBancosCtas_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
      TabReturn(e.KeyChar)
   End Sub
   '
   Private Sub btnAceptarCta_Click(sender As Object, e As EventArgs) Handles btnAceptarCta.Click
      '
      If Alta Then
         If Not IsNothing(CapturaDato(Cn, "BancosCtas", "BancoCta", "Banco = " & Banco & " AND BancoCta = '" & tbCtaBco.Text & "'")) Then
            MensajeTrad("CuentaExist")
            Exit Sub
         End If
      End If
      '
      If validar Then
         Guardar()
      End If
      '
   End Sub
   '
   Private Function Validar() As Boolean
      If tbCtaBco.Text = "" Then
         MensajeTrad("DiCuenta")
         tbCtaBco.Focus()
         Return False
      End If
      If tbDescrip.Text = "" Then
         MensajeTrad("DiDescrip")
         tbDescrip.Focus()
         Return False
      End If
      Return True
   End Function
   '
   Private Sub Guardar()
      '
      With cmd
         If IsNothing(CapturaDato(Cn, "BancosCtas", "Banco", "Banco = " & Banco & " AND BancoCta = '" & tbCtaBco.Text & "'")) Then
            .CommandText = "INSERT INTO BancosCtas( Banco, BancoCta, Descrip, Titular, SaldoIni, FechaSdo, CtaCont, Usuario, FechaMod) " &
                           "VALUES( " & Banco & ", '" & tbCtaBco.Text & "', '" & tbDescrip.Text & "', '" & tbTitular.Text & "', " & Val(tbSaldoIni.Text) & ", '" & Format(dtpFechaSdo.Value, FormatFecha) & "', '" & CtaCont & "', '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
         Else
            .CommandText = "UPDATE BancosCtas SET " &
                           " Descrip = '" & tbDescrip.Text & "', " &
                           " Titular = '" & tbTitular.Text & "', " &
                           " SaldoIni = " & Val(tbSaldoIni.Text) & ", " &
                           " FechaSdo = '" & Format(dtpFechaSdo.Value, FormatFecha) & "', " &
                           " CtaCont = '" & CtaCont & "', " &
                           " Usuario = '" & Uid & "', " &
                           " FechaMod = '" & Format(Now, FormatFechaHora) & "' " &
                           "WHERE Banco = " & Banco &
                           "  AND BancoCta = '" & tbCtaBco.Text & "'"
         End If
         .ExecuteNonQuery()
      End With
      Me.Close()
   End Sub
   '
   Private Sub cboCtaCont_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCtaCont.SelectedIndexChanged
      CtaCont = CapturaDato(Cn, "PlanCtas", "CtaCont", "Descrip = '" & cboCtaCont.Text & "'")
   End Sub
   '
   Private Sub btnCancelarCta_Click(sender As Object, e As EventArgs) Handles btnCancelarCta.Click
      Me.Close()
   End Sub
   '
   Private Sub frmBancos_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
      SetRegForm(Me)
      Me.Dispose()
   End Sub
   '
End Class