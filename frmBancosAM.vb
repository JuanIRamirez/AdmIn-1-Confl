Public Class frmBancosAM
   '
   Public Banco As Int32
   '
   'Dim Ctrl As Control
   Dim Alta As Boolean
   Dim Cmd As New OleDb.OleDbCommand
   Dim Drd As OleDb.OleDbDataReader
   'Dim i As Integer
   'Dim CtaCont As String
   '
   Const cTabla = "Bancos"

   Private Sub frmBancos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      '
      GetRegForm(Me)
      '
      Me.Text = Me.Text & ": " & IIf(Banco = 0, "Alta", "Modificación")
      '
      Cmd.Connection = Cn
      '
      If Banco = 0 Then
         Alta = True
         tbCodigo.Text = CapturaDato(Cn, "Bancos", "ISNULL(MAX(Banco),0)", "") + 1
         tbNombre.Focus()
      Else
         With Cmd
            .CommandText = "SELECT * FROM Bancos WHERE Banco = " & Banco
            Drd = .ExecuteReader
         End With
         With Drd
            If .Read Then
               tbCodigo.Enabled = False
               tbCodigo.Text = !Banco
               tbNombre.Text = !Nombre
               tbDomicilio.Text = !Domicilio
               tbTelefono.Text = !Telefono
               tbContacto.Text = !Contacto
               tbTelContacto.Text = !Tel_Contac
            End If
            .Close()
         End With
      End If
      '
   End Sub
   '
   Private Sub frmBancosAM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
      TabReturn(e.KeyChar)
   End Sub
   '
   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      '
      If Alta Then
         If Not IsNothing(CapturaDato(Cn, "Bancos", "Banco", "Banco = " & tbCodigo.Text)) Then
            MensajeTrad("CodExist")
            Exit Sub
         End If
      End If
      '
      If Validar() Then
         Guardar()
      End If
      '
   End Sub
   '
   Private Function Validar() As Boolean
      '
      If Val(tbCodigo.Text) = 0 Then
         MensajeTrad("DICod>0")
         tbCodigo.Focus()
         Return False
      End If
      '
      If tbNombre.Text = "" Then
         MensajeTrad("DINombre")
         tbNombre.Focus()
         Return False
      End If
      '
      Return True
      '
   End Function
   Private Sub Guardar()
      '
      Try
         With Cmd
            If Alta Then
               .CommandText = "INSERT INTO Bancos( Banco, Nombre, Domicilio, Telefono, Contacto, Tel_Contac, Usuario, FechaMod) " & _
                              "VALUES(" & tbCodigo.Text & ", '" & tbNombre.Text & "', '" & tbDomicilio.Text & "', '" & tbTelefono.Text & "', '" & tbContacto.Text & "', '" & tbTelContacto.Text & "', '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"

            Else
               .CommandText = "UPDATE Bancos SET " & _
                              " Nombre = '" & tbNombre.Text & "', " & _
                              " Domicilio = '" & tbDomicilio.Text & "', " & _
                              " Telefono = '" & tbTelefono.Text & "', " & _
                              " Contacto = '" & tbContacto.Text & "', " & _
                              " Tel_Contac = '" & tbTelContacto.Text & "', " & _
                              " Usuario = '" & Uid & "', " & _
                              " FechaMod = '" & Format(Now, FormatFechaHora) & "' " & _
                              "WHERE Banco = " & tbCodigo.Text
            End If
            .ExecuteNonQuery()
         End With
         '
         Me.Close()
         '
      Catch ex As System.Exception
         Dim st As New StackTrace(True)
         RegistrarError(st, "frmBancosAM", , Err.Description, "Guardar")
      End Try
      '
   End Sub
   '
   Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
      Me.Close()
   End Sub
   '
   Private Sub frmBancosAM_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
      SetRegForm(Me)
      Me.Dispose()
   End Sub
   '
End Class