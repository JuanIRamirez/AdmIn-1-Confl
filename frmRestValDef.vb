Public Class frmRestValDef
   '
   Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
      Dim cmd As New OleDb.OleDbCommand
      Try
         With cmd
            .Connection = cn
            .CommandText = "DELETE FROM ConfigUsu WHERE CfuUsuario = '" & Uid & "'"
            .ExecuteNonQuery()
         End With
         MsgBox("Valores restaurados", MsgBoxStyle.Information)
         Me.Close()
      Catch ex As System.Exception
         Dim st As New StackTrace(True)
         MensageError(st, Me.Name, Err.Description)
      End Try
   End Sub
   '
   Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
      Me.Close()
   End Sub
   '
End Class