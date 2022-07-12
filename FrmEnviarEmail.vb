Public Class FrmEnviarEmail
   '
   Public CtaDestino As String = ""
   Public CopiaA As String = ""
   Public Asunto As String = ""
   Public Cuerpo As String = ""
   Public Adjuntos As Collection
   '
   Private Sub FrmEnviarEmail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      '
      Dim i As Byte
      '
      GetRegForm(Me)
      '
      tbEmail.Text = CtaDestino
      tbCopiaA.Text = CopiaA
      tbAsunto.Text = Asunto
      tbCuerpo.Text = Cuerpo
      '
      LbAdjuntos.Items.Clear()
      '
      With Adjuntos
         For i = 1 To Adjuntos.Count
            LbAdjuntos.Items.Add(Adjuntos.Item(i))
         Next
      End With
      '
   End Sub
   '
   Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      '
      If EnviarMail(tbEmail.Text, tbAsunto.Text, tbCuerpo.Text, Adjuntos, True, , , cfgSmtpCtaAdm, cfgSmtpPwdAdm,, tbCopiaA.Text) Then
         Mensaje("Correo enviado a " & tbEmail.Text & " !")
         Me.Close()
      End If
      '
   End Sub
   '
   Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
      Me.Close()
   End Sub
   '
   Private Sub Form_Unload(Cancel As Integer)
      SetRegForm(Me)
      Me.Dispose()
   End Sub
   '
   Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
      OpenFileDialog1.ShowDialog()
      LbAdjuntos.Items.Add(OpenFileDialog1.FileName)
      Adjuntos.Add(OpenFileDialog1.FileName)
   End Sub
   '
End Class