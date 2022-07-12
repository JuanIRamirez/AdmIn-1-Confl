'
Imports System.Net.Mail
'
Module ModWin
   '
   Public Const HKEY_LOCAL_MACHINE = 0
   Public Const HKEY_CURRENT_USER = 0
   Public Const KeyRoot = HKEY_LOCAL_MACHINE
   '
   Public keyStr As String
   '
   Public Function GetNombrePC() As String
      Dim ComputerName As String
      ComputerName = Environ("COMPUTERNAME")
      If ComputerName <> "" Then
         GetNombrePC = ComputerName
      ElseIf GetKeyValue(HKEY_LOCAL_MACHINE, "System\CurrentControlSet\Control\ComputerName\ComputerName", "ComputerName", keyStr) Then
         GetNombrePC = keyStr
      ElseIf GetKeyValue(HKEY_LOCAL_MACHINE, "SYSTEM\ControlSet001\Control\ComputerName\ActiveComputerName", "ComputerName", keyStr) Then
         GetNombrePC = keyStr
      Else
         GetNombrePC = ""
      End If
   End Function

   Function GetKeyValue(ByVal Raiz, ByVal Clave, ByVal Cadena, ByVal Valor) As Boolean
      Return False
   End Function

   Sub AbrirDocWord(ByVal Doc As String)
      '
      Dim aDoc As Object
      Dim Documento As Object
      Documento = CreateObject("Word.Application")
      '
      Try
         With Documento
            '
            aDoc = .Documents.Open(Doc, , , , , , , , , , True)
            '
            .WindowState = 2   '*** wdWindowStateMaximize
            .Application.Visible = True
            '
         End With
         '
         Documento = Nothing
         '
      Catch ex As Exception
         Dim st As New StackTrace(True)
         MensageError(st, "modWin.AbrirDocWord")
      End Try
      '
   End Sub
   '
   Public Function EnviarMail(DestEMail As String, Asunto As String, Cuerpo As String, Adjuntos As Collection, Optional Msg As Boolean = False, Optional SmtpServ As String = "", Optional SmtpPort As String = "", Optional CtaRtte As String = "", Optional PwdRtte As String = "", Optional EnablSSL As Boolean = False, Optional DestCCopia As String = "") As Boolean
      '
      If cfgSmtpServ = "" Then
         If Msg Then
            MensajeTrad("SmtpServNoDef")
         End If
         Return False
      End If
      '
      Dim correo As New MailMessage
      Dim i As Byte
      '
      If SmtpServ = "" Then
         SmtpServ = cfgSmtpServ
      End If
      If SmtpPort = "" Then
         SmtpPort = cfgSmtpPort
      End If
      If CtaRtte = "" Then
         CtaRtte = cfgSmtpCta
      End If
      If PwdRtte = "" Then
         PwdRtte = cfgSmtpPwd
      End If
      '
      Try
         If CtaRtte <> "" Then
            correo.From = New MailAddress(cfgSmtpCta, cfgNomEmp, System.Text.Encoding.UTF8)
            correo.To.Add(DestEMail)
            If DestCCopia <> "" Then
               correo.CC.Add(DestCCopia)
            End If
            correo.SubjectEncoding = System.Text.Encoding.UTF8
            correo.Subject = Asunto
            correo.Body = Cuerpo
            For i = 1 To Adjuntos.Count
               Dim Attach As New System.Net.Mail.Attachment(Adjuntos.Item(i))
               correo.Attachments.Add(Attach)
            Next
            correo.BodyEncoding = System.Text.Encoding.UTF8
            correo.IsBodyHtml = False
            correo.Priority = MailPriority.High
            '
            Dim Smtp As New SmtpClient(SmtpServ, SmtpPort)
            Smtp.UseDefaultCredentials = True
            Smtp.Credentials = New System.Net.NetworkCredential(CtaRtte, PwdRtte)
            Smtp.EnableSsl = EnablSSL
            Smtp.Send(correo)
            Return True
         End If
      Catch
         Mensaje(Err.Description)
         Return False
      End Try
      '
      Return False
      '
   End Function
   '
End Module
