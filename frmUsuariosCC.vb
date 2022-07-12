Public Class frmUsuariosCC
   '
   Dim Tabla As String
   Dim Alta As Boolean
   '
   Dim Trn As OleDb.OleDbTransaction
   Dim Cmd As New OleDb.OleDbCommand
   '
   Private Sub frmUsuariosCC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      '
      GetRegForm(Me)
      '
      tbUsuario.Text = Uid
      tbNombre.Text = CapturaDato(Cn, "Usuarios", "Nombre", "Usuario = '" & Uid & "'")
      '
   End Sub
   '
   Private Sub frmUsuariosCC_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
      TabReturn(e.KeyChar)
   End Sub
   '
   Private Sub cmdAceptar_Click(sender As Object, e As EventArgs) Handles cmdAceptar.Click
      '
      If Not Validar() Then Exit Sub
      '
      Try
         'Trn = Cn.BeginTransaction
         '
         With Cmd
            '
            .Connection = Cn
            '.Transaction = Trn
            '
            'If AutDB Then
            .CommandText = "UPDATE Usuarios SET " &
                              "     Contraseña = '" & Encrypt(tbContraseña.Text) & "', " &
                              "     UsuMod = '" & Uid & "', " &
                              "     FechaMod = '" & Format(Now, FormatFechaHora) & "' " &
                              "WHERE Usuario = '" & Uid & "'"
               .ExecuteNonQuery()
            'End If
            '
            'If Not TrustedCnx Then
            '   If PRV = "SQLOLEDB" Then
            '      With Cmd
            '         .CommandText = "sp_password NULL, '" & tbContraseña.Text & "','" & tbUsuario.Text & "'"
            '         .ExecuteNonQuery()
            '      End With
            '   End If
            'End If
            '
         End With
         '
         'Trn.Commit()
         '
         MensajeTrad("PwdChanged")
         '
         Me.Close()
         '
      Catch ex As System.Exception
         'Trn.Rollback()
         Dim st As New StackTrace(True)
         RegistrarError(st, "UsuariosCC")
      End Try
      '
   End Sub
   '
   Private Function Validar() As Boolean
      '
      If Not ValidaLogin(Uid, tbContrAct.Text) Then
         tbContrAct.Focus()
         Exit Function
      End If
      '
      If tbContraseña.Text = "" Then
         MsgBox("Debe ingresar Contraseña", vbInformation)
         tbContraseña.Focus()
         Exit Function
      End If
      '
      If tbContraseña.Text <> tbContraseñaR.Text Then
         MsgBox("Contraseñas no coinciden", vbInformation)
         tbContraseña.Focus()
         Exit Function
      End If
      '
      Validar = True
      '
   End Function
   '
   Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
      Me.Close()
   End Sub
   '
   Private Sub frmUsuariosCC_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
      SetRegForm(Me)
   End Sub
   '
End Class