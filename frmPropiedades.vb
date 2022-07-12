Public Class frmPropiedades
   '
   Public CambiarPropiet As Boolean
   Public Propietario As Int32
   '
   Dim Cmd As New OleDb.OleDbCommand
   Dim Propiet As Int32
   Dim vAutoriza As Boolean
   Dim Comision As Single
   Dim NuevoProp As Long
   Dim FormLoad As Boolean = False
   '
   Private Sub frmPropiedades_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      '
      On Error GoTo mError
      '
      GetRegForm(Me)
      TraducirForm(Me)
      '
      ArmaComboItem(cbPropietario, "Propietarios", , "Nombre", "Nombre", "(Todos)", IIf(Propietario = 0, "Estado = 'A'", "Codigo = " & Propietario))
      If Propietario <> 0 Then
         With cbPropietario
            .SelectedIndex = 1
            .Enabled = False
         End With
      End If
      '
      If Not CambiarPropiet Then
         cmdCambiarPropiet.Enabled = False
      End If
      '
      FormLoad = True
      '
      ActData()
      '
      Exit Sub
      '
mError:
      MsgBox("ERROR: " & Err.Number & " - " & Err.Description)
      DeshabForm(Me)
      '
   End Sub
   '
   Private Sub frmPropiedades_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
      TabReturn(e.KeyChar)
   End Sub
   '
   Private Sub cbPropietario_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPropietario.SelectedIndexChanged
      With cbPropietario
         If .SelectedIndex > 0 Then
            Propiet = .SelectedValue
         Else
            Propiet = 0
         End If
      End With
      ActData()
   End Sub
   '
   Private Sub cmdAlta_Click(sender As Object, e As EventArgs) Handles cmdAlta.Click
      AltaMod(True)
   End Sub
   '
   Private Sub cmdEdicion_Click(sender As Object, e As EventArgs) Handles cmdEdicion.Click
      AltaMod(False)
   End Sub
   '
   Private Sub AltaMod(Alta As Boolean, Optional CambiarPropiet As Boolean = False)
      '
      If SuperaRegistros("Propiedades") Then
         Exit Sub
      End If
      '
      Dim Propiedad As Int32
      '
      If Alta Then
         Propiedad = 0
      Else
         With DataGridView1
            If .RowCount > 0 Then
               Propiedad = Val(.SelectedCells(.Columns("Codigo").Index).Value)
            End If
         End With
      End If
      '
      With frmPropiedadesAM
         .Alta = Alta
         .Propietario = Propiet
         .Propiedad = Propiedad
         .CambiarPropiet = CambiarPropiet
         .ShowDialog(Me)
         ActData()
      End With
      '
   End Sub
   '
   Private Sub cmdBaja_Click(sender As Object, e As EventArgs) Handles cmdBaja.Click
      '
      Dim Inquilino As Int32
      Dim Propiedad As Int32
      Dim Domicilio As String
      '
      With DataGridView1
         If .RowCount > 0 Then
            Inquilino = Val(.SelectedCells(.Columns("Inquilino").Index).Value & "")
            Propiedad = Val(.SelectedCells(.Columns("Codigo").Index).Value & "")
            Domicilio = .SelectedCells(.Columns("Domicilio").Index).Value
            If Inquilino = 0 Then
               If IsNothing(CapturaDato(Cn, "PropiedConc", "Propiedad", "Propiedad = " & Propiedad)) Then
                  If IsNothing(CapturaDato(Cn, "FactInq", "Propiedad", "Propiedad = " & Propiedad)) Then
                     If MsgBox("Elimina (" & Propiedad & ") - " & Domicilio, vbQuestion & vbYesNo) = vbYes Then
                        With Cmd
                           .CommandText = "DELETE FROM Propiedades WHERE Propiedad = " & Propiedad
                           .ExecuteNonQuery()
                        End With
                        ActData()
                     End If
                  Else
                     MensajeTrad("PrdConFacInq")
                  End If
               Else
                  MensajeTrad("PrdCConcFijos")
               End If
            Else
               MensajeTrad("PropiedAlq")
            End If
         End If
      End With
      '
   End Sub
   '
   Private Sub cmdCambiarPropiet_Click(sender As Object, e As EventArgs) Handles cmdCambiarPropiet.Click
      AltaMod(False, True)
   End Sub
   '
   Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick, DataGridView1.CellContentDoubleClick, DataGridView1.RowLeave
      ActivaControles()
   End Sub
   '
   Private Sub ActData()
      '
      If Not FormLoad Then Exit Sub
      '
      Dim cWhere As String = ""
      '
      If Propiet <> 0 Then
         cWhere = "P.Propietario = " & Propiet & " "
      End If
      '
      If optActivas.Checked Then
         cWhere = IIf(cWhere = "", "", cWhere & " AND ") & "P.Estado = 'A' "
      ElseIf optInactivas.Checked Then
         cWhere = IIf(cWhere = "", "", cWhere & " AND ") & "P.Estado = 'I' "
      End If
      '
      If txtDomicilio.Text <> "" Then
         cWhere = IIf(cWhere = "", "", cWhere & " AND ") & "P.Domicilio LIKE '%" & txtDomicilio.Text & "%' "
      End If
      '
      SetRegGrid(Me, DataGridView1)
      LlenarGrid(DataGridView1, "SELECT P.Domicilio, P.Localidad, P.Barrio, P.Codigo, PR.Nombre, I.Nombre AS Inquilino, P.NomCat, P.Valor, P.Estado " &
                                "FROM Propiedades P LEFT JOIN Propietarios PR " &
                                "ON P.Propietario = PR.Codigo LEFT JOIN Inquilinos I ON P.Inquilino = I.Codigo " &
                                IIf(cWhere = "", "", "WHERE " & cWhere) &
                                "ORDER BY P.Domicilio")
      SetCols()
      GetRegGrid(Me, DataGridView1)
      '
      ActivaControles()
      '
   End Sub
   '
   Private Sub SetCols()
      With DataGridView1
         For Each Col As DataGridViewColumn In .Columns
            With Col
               Select Case UCase(.Name)
                  Case "CODIGO" : .Width = 60
                  Case "DOMICILIO" : .Width = 300
                  Case "LOCALIDAD"
                  Case "BARRIO"
                  Case "VALOR" : .Width = 100
                  Case "NOMBRE" : .Width = 250 : .HeaderText = "Propietario"
                  Case "NOMCAT" : .Width = 100 : .HeaderText = "Nom.Catastral"
                  Case "ESTADO" : .Width = "50"
                  Case "INQUILINO" : .Width = "250"
                  Case Else
                     .Visible = False
               End Select
            End With
         Next Col
      End With
   End Sub
   '
   Private Sub cmdListado_Click(sender As Object, e As EventArgs) Handles cmdListado.Click
      With frmListPropiedades
         .Propietario = Propiet
         .Domicilio = txtDomicilio.Text
         .ShowDialog()
      End With
   End Sub
   '
   Private Sub DataGrid1_DblClick()
      AltaMod(False)
   End Sub
   '
   Private Sub tbcomision_KeyPress(KeyAscii As Integer)
      SoloNumeros(KeyAscii)
   End Sub
   '
   Private Sub ActivaControles()
      '
      Dim lEdit As Boolean = (DataGridView1.RowCount > 0)
      '
      cmdAlta.Enabled = Propiet <> 0
      cmdEdicion.Enabled = lEdit
      cmdBaja.Enabled = lEdit
      cmdCambiarPropiet.Enabled = lEdit And CambiarPropiet
      '
   End Sub
   '
   Private Sub txtDomicilio_TextChanged(sender As Object, e As EventArgs) Handles txtDomicilio.TextChanged
      ActData()
   End Sub
   '
   Private Sub cmdCancelar_Click()
      ActivaControles()
   End Sub
   '
   Private Sub optActivos_CheckedChanged(sender As Object, e As EventArgs) Handles optActivas.CheckedChanged, optInactivas.CheckedChanged, optTodos.CheckedChanged
      ActData()
   End Sub
   '
    Private Sub cmdSalir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSalir.Click
        Me.Close()
    End Sub
   '
   Private Sub frmPropiedades_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
      SetRegGrid(Me, DataGridView1)
      SetRegForm(Me)
      Me.Dispose()
   End Sub
   '
End Class