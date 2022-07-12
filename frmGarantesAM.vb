Public Class frmGarantesAM
   '
   Public Alta As Boolean
   Public GaranteId As Int32 = 0
   '
   Dim Cmd As New OleDb.OleDbCommand
   Dim Drd As OleDb.OleDbDataReader
   Dim Trn As OleDb.OleDbTransaction
   '
   Dim LocalidadId As Integer
   '
   Private Sub frmGarantesAM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      '
      GetRegForm(Me)
      '
      TraducirForm(Me)
      '
      Cmd.Connection = Cn
      '
      ArmaComboItem(cbLocalidad, "Localidad", "LocalidadId", , , "(Seleccionar)")
      '
      If Not Alta Then
         With Cmd
            .CommandText = "SELECT * FROM Garantias WHERE GaranteId = " & GaranteId
            Drd = .ExecuteReader
            With Drd
               If .Read Then
                  tbDni.Text = !DNI
                  tbNombre.Text = !Nombre
                  tbTelefono.Text = !Telefono & ""
                  tbDomicilio.Text = !Domicilio & ""
                  If Not IsDBNull(!LocalidadId) Then
                     cbLocalidad.Text = CapturaDato(Cn, "Localidad", "Descrip", "LocalidadId = " & !LocalidadId)
                  End If
                  '
                  tbTrabajo.Text = !Trabajo & ""
                  tbTelTrabajo.Text = !TelTrabajo & ""
                  tbDomTrabajo.Text = !DomTrabajo & ""
                  '
                  optPagare.Checked = !gPagare
                  optHipotecaria.Checked = !gHipotecario
                  optPrenda.Checked = !gPrenda
                  '
               Else
                  MensajeTrad("CodNoEnc")
                  DeshabForm(Me)
               End If
               .Close()
            End With
         End With
      End If
      '
   End Sub
   '
   Private Sub frmGarantesAM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
      TabReturn(e.KeyChar)
   End Sub
   '
   Private Sub cmdListado_Click()
      'frmListInquilinos.Show()
   End Sub
   '
   Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
      '
      If Validar() Then
         Guardar()
      End If
      '
   End Sub
   '
   Private Sub cbDescCta_Click()
      '  cbCuenta.ListIndex = cbDescCta.ListIndex
   End Sub
   '
   Private Function Validar() As Boolean
      '
      If tbNombre.Text = "" Then
         MensajeTrad("DebIngApeNom")
         tbNombre.Focus()
         Return False
      End If
      '
      If Not IsNothing(CapturaDato(Cn, "Garantias", "Nombre", "GaranteId <> " & GaranteId & " AND Nombre = '" & tbNombre.Text & "'")) Then
         MensajeTrad("NomExist")
         tbNombre.Focus()
         Return False
      End If
      '
      Return True
      '
   End Function
   '
   Private Sub tDni_Change()
      'If tDni = "" Then tDni = 0
   End Sub
   '
   Private Sub Guardar()
      '
      Try
         '
         Trn = Cn.BeginTransaction
         '
         With Cmd
            '
            .Transaction = Trn
            '
            LocalidadId = AltaLocalidadAuto(cbLocalidad.Text, , Trn)
            '
            If Alta Then
               .CommandText = "INSERT INTO Garantias( Nombre, DNI, Domicilio, Telefono, LocalidadId, Trabajo, DomTrabajo, TelTrabajo, GPagare, GHipotecario, gPrenda, Usuario, FechaMod) " & _
                              "VALUES('" & tbNombre.Text & "', " & _
                                     "'" & tbDni.Text & "', " & _
                                     "'" & tbDomicilio.Text & "', " & _
                                     "'" & tbTelefono.Text & "', " & _
                                     "'" & LocalidadId & "', " & _
                                     "'" & tbTrabajo.Text & "', " & _
                                     "'" & tbDomTrabajo.Text & "', " & _
                                     "'" & tbTelTrabajo.Text & "', " & _
                                           IIf(optPagare.Checked, 1, 0) & ", " & _
                                           IIf(optHipotecaria.Checked, 1, 0) & ", " & _
                                           IIf(optPrenda.Checked, 1, 0) & ", " & _
                                     "'" & Uid & "', " & _
                                     "'" & Format(Now, FormatFechaHora) & "')"
            Else
               .CommandText = "UPDATE Garantias SET " & _
                              " Nombre = '" & tbNombre.Text & "', " & _
                              " DNI = '" & tbDni.Text & "', " & _
                              " Domicilio = '" & tbDomicilio.Text & "', " & _
                              " Telefono = '" & tbTelefono.Text & "', " & _
                              " LocalidadId = " & LocalidadId & ", " & _
                              " Trabajo = '" & tbTrabajo.Text & "', " & _
                              " DomTrabajo = '" & tbDomTrabajo.Text & "', " & _
                              " TelTrabajo = '" & tbTelTrabajo.Text & "', " & _
                              " gPagare = " & IIf(optPagare.Checked, 1, 0) & ", " & _
                              " gHipotecario = " & IIf(optHipotecaria.Checked, 1, 0) & ", " & _
                              " gPrenda = " & IIf(optPrenda.Checked, 1, 0) & ", " & _
                              " Usuario = '" & Uid & "', " & _
                              " FechaMod = '" & Format(Now, FormatFechaHora) & "' " & _
                              "WHERE GaranteId = " & GaranteId
            End If
            .ExecuteNonQuery()
         End With
         '
         Trn.Commit()
         '
         Me.Close()
         '
      Catch ex As Exception
         Dim st As New StackTrace(True)
         MensageError(st, "frmInquilinosAM.Guardar", ex.Message)
      End Try
      '
   End Sub
   '
   Private Sub cbLocalidad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbLocalidad.SelectedIndexChanged
      With cbLocalidad
         If .SelectedIndex > 0 Then
            LocalidadId = .SelectedValue
         Else
            LocalidadId = 0
         End If
      End With
   End Sub
   '
   Private Sub tbDni_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbDni.KeyPress
      SoloNumeros(e.KeyChar)
   End Sub
   '
   Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
      Me.Close()
   End Sub
   '
   Private Sub frmInquilinosAM_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed   '
      '
      SetRegForm(Me)
      Me.Dispose()
      '
   End Sub
   '
End Class