Public Class frmCodigoAut
   '
   Public Mensaje As String
   Public Autorizado As Boolean
   '
   Private Sub frmCodigoAut_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Autorizado = False
      lblMensaje.Text = Mensaje
   End Sub
   '
   Private Sub cmdAceptar_Click(sender As Object, e As EventArgs) Handles cmdAceptar.Click
      '
      If cfgCodAutSup <> "" Then
         If tbCodigoAut.Text = cfgCodAutSup Then
            Autorizado = True
         End If
      End If
      '
      Me.Close()
      '
   End Sub
   '
   Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
      Autorizado = False
      Me.Close()
   End Sub
   '
End Class