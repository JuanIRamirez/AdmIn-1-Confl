Public Class frmRegError
   '
   Dim ArchLog As String
   '
   Private Sub frmRegError_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      '
      ArchLog = Raiz & EmpAbr & "\" & Sistema & "\Error.log"
      '
      Dim f As New System.IO.StreamReader(ArchLog)
      '
      Do While f.Peek() >= 0
         ListBox1.Items.Add(f.ReadLine())
      Loop
      f.Close()
      '
   End Sub
   '
End Class