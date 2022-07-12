Public Class frmPropietarios
   '
   Dim cmd As New OleDb.OleDbCommand
   Dim FormLoad As Boolean = False
   '
   Private Sub frmPropietarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      '
      GetRegForm(Me)
      '
      FormLoad = True
      ActData()
      '
   End Sub
   '
   Private Sub tbBuscar_TextChanged(sender As Object, e As EventArgs) Handles tbBuscar.TextChanged
      ActData()
   End Sub
   '
   Private Sub btListado_Click(sender As Object, e As EventArgs) Handles btListado.Click
      ImprimirCrp("PropietMin", crptToWindow, "", Me.Text)
      ImprimirCrp("PropietMinC", crptToWindow, "", Me.Text & " C/Local Comercial")
      ImprimirCrp("PropietMinP", crptToWindow, "", Me.Text & " C/Vivienda Particular")
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
   Private Sub AltaMod(Alta As Boolean)
      '
      If SuperaRegistros("Propietarios") Then
         Exit Sub
      End If
      '
      Dim Propietario As Int32
      '
      If Alta Then
         Propietario = 0
      Else
         With DataGridView1
            If .RowCount > 0 Then
               Propietario = Val(.SelectedCells(.Columns("Codigo").Index).Value)
            End If
         End With
      End If
      With frmPropietariosAM
         .Alta = Alta
         .Propietario = Propietario
         .ShowDialog(Me)
         ActData()
      End With
   End Sub
   '
   Private Sub btPropiedades_Click(sender As Object, e As EventArgs) Handles btPropiedades.Click
      If TienePermiso(Cn, Uid, frmMenu.mPropiedades.Name) Then
         Dim Propietario As Int32 = 0
         With DataGridView1
            If .RowCount > 0 Then
               Propietario = Val(.SelectedCells(.Columns("Codigo").Index).Value)
            End If
         End With
         With frmPropiedades
            .CambiarPropiet = False
            .Propietario = Propietario
            .MdiParent = frmMenu
            .Show()
         End With
      End If
   End Sub
   '
   Private Sub DataGridView1_RowLeave(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.RowLeave
      ActivaControles()
   End Sub
   '
   Private Sub DataGrid1_RowColChange(LastRow As Object, ByVal LastCol As Integer)
      ActivaControles()
   End Sub
   '
   Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
      ActivaControles()
   End Sub
   '
   Private Sub ActData()
      '
      If Not FormLoad Then Exit Sub
      '
      Dim cWhere As String = ""
      '
      If optActivos.Checked Then
         cWhere = IIf(cWhere = "", "", cWhere & " AND ") & "P.Estado = 'A' "
      ElseIf optInactivos.Checked Then
         cWhere = IIf(cWhere = "", "", cWhere & " AND ") & "P.Estado = 'I' "
      End If
      '
      If tbBuscar.Text <> "" Then
         cWhere = IIf(cWhere = "", "", cWhere & " AND ") & "P.Nombre LIKE '%" & tbBuscar.Text & "%' "
      End If
      '
      SetRegGrid(Me, DataGridView1)
      '
      LlenarGrid(DataGridView1, "SELECT P.Nombre, P.Codigo, P.Dni, P.Barrio, P.Domicilio, ISNULL(L.Descrip, Localidad) AS Localidad, P.Telefono, P.Tel_Movil, P.eMail, P.Estado " & _
                                "FROM Propietarios P LEFT JOIN Localidad L ON P.Localidad = L.Codigo " & _
                                IIf(cWhere = "", "", "WHERE " & cWhere) & _
                                "ORDER BY P.Nombre")
      '
      SetCols()
      '
      GetRegGrid(Me, DataGridView1)
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
                  Case "NOMBRE" : .Width = 300 : .HeaderText = "Propietario"
                  Case "NOMCAT" : .Width = 100 : .HeaderText = "Nom.Catastral"
                  Case "ESTADO" : .Width = "50"
               End Select
            End With
         Next Col
      End With
   End Sub

   Private Sub ActivaControles()
      '
      Dim lEnabl As Boolean = DataGridView1.RowCount > 0
      '
      cmdAlta.Enabled = True
      cmdBaja.Enabled = lEnabl
      cmdEdicion.Enabled = lEnabl
      '
      btPropiedades.Enabled = lEnabl And TienePermiso(Cn, Uid, frmMenu.mPropiedades.Name)
      '
   End Sub
   '
   Private Sub cmdBaja_Click(sender As Object, e As EventArgs) Handles cmdBaja.Click
      '
      Dim Propietario As Int32 = 0
      Dim Nombre As String = ""
      Dim Trn As OleDb.OleDbTransaction
      '
      With DataGridView1
         If .RowCount > 0 Then
            Propietario = Val(.SelectedCells(.Columns("Codigo").Index).Value)
            Nombre = .SelectedCells(.Columns("Codigo").Index).Value
         End If
      End With
      '
      If Propietario = 0 Then
         Exit Sub
      End If
      '
      If Not IsNothing(CapturaDato(Cn, "Propiedades", "Codigo", "Propietario = " & Propietario)) Then
         MensajeTrad("PrtConPrd")
         Exit Sub
      End If
      '
      If Not IsNothing(CapturaDato(Cn, "CompraOtr", "Numero", "Propietario = " & Propietario)) Then
         MensajeTrad("PrtConCptes")
         Exit Sub
      End If
      '
      If DaDeBaja("Propietario " & Nombre) Then
         '
         Trn = Cn.BeginTransaction
         '
         With cmd
            .Transaction = Trn
            .CommandText = "DELETE FROM Propietarios WHERE Codigo = " & Propietario
            .ExecuteNonQuery()
            '
            GuardarAudit("Baja Propietario", Nombre, Me.Name, "Baja", Trn)
            '
         End With
         '
         ActData()
      End If
      '
   End Sub
   '
   Private Sub optActivos_CheckedChanged(sender As Object, e As EventArgs) Handles optActivos.CheckedChanged, optInactivos.CheckedChanged, optTodos.CheckedChanged
      ActData()
   End Sub
   '
   Private Sub btnRestCol1_Click(sender As Object, e As EventArgs) Handles btnRestCol1.Click
      SetCols()
   End Sub
   '
   Private Sub cmdSalir_Click(sender As Object, e As EventArgs) Handles cmdSalir.Click
      Me.Close()
   End Sub
   '
   Private Sub Propietarios_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
      SetRegGrid(Me, DataGridView1)
      SetRegForm(Me)
      Me.Dispose()
   End Sub
   '
End Class