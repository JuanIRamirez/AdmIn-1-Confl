Public Class frmPropietAg
   '
   Dim PropietAgId As Int16
   '
   Dim Trn As OleDb.OleDbTransaction
   Dim Cmd As New OleDb.OleDbCommand
   '
   Private Sub frmPropietAg_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      '
      GetRegForm(Me)
      '
      Cmd.Connection = Cn
      '
      ArmaComboItem(cbGrupo, "PropietAg", "PropietAgId", "PagDescrip", "PagDescrip")
      '
   End Sub
   '
   Private Sub frmPropietAg_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
      TabReturn(e.KeyChar)
   End Sub
   '
   Private Sub cbGrupo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbGrupo.SelectedIndexChanged
      With cbGrupo
         If .SelectedIndex > 0 Then
            PropietAgId = .SelectedValue
         Else
            PropietAgId = 0
         End If
      End With
      ActData()
   End Sub
   '
   Private Sub ActData()
      '
      SetRegGrid(Me, DataGridView1)
      '
      LlenarGrid(DataGridView1, "SELECT Codigo, Nombre FROM Propietarios WHERE Estado = 'A' AND Codigo NOT IN( SELECT Propietario FROM PropietAgDet WHERE PropietAgId = " & PropietAgId & ") " & IIf(tbBuscar.Text = "", "", " AND Nombre LIKE '%" & tbBuscar.Text & "%'") & " ORDER BY Nombre")
      '
      With DataGridView1
         For Each Col As DataGridViewColumn In .Columns
            With Col
               Select Case UCase(.Name)
                  Case "CODIGO" : .HeaderText = "Id" : .Width = 100
                  Case "NOMBRE" : .Width = 300
                  Case Else : .Visible = False
               End Select
            End With
         Next Col
      End With
      '
      GetRegGrid(Me, DataGridView1)
      '
      SetRegGrid(Me, DataGridView2)
      '
      LlenarGrid(DataGridView2, "SELECT Codigo, Nombre FROM Propietarios WHERE Codigo IN( SELECT Propietario FROM PropietAgDet WHERE PropietAgId = " & PropietAgId & ") ORDER BY Nombre")
      '
      With DataGridView2
         For Each Col As DataGridViewColumn In .Columns
            With Col
               Select Case UCase(.Name)
                  Case "CODIGO" : .HeaderText = "Id" : .Width = 100
                  Case "NOMBRE" : .Width = 300
                  Case Else : .Visible = False
               End Select
            End With
         Next Col
      End With
      '
      GetRegGrid(Me, DataGridView1)
      '
      btnAgregar.Enabled = DataGridView1.RowCount > 0 And PropietAgId > 0
      btnQuitar.Enabled = DataGridView2.RowCount > 0 And PropietAgId > 0
      '
   End Sub
   '
   Private Sub cmdAlta_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
      '
      If DataGridView1.RowCount > 0 Then
         '
         Trn = Cn.BeginTransaction
         '
         With Cmd
            .Transaction = Trn
            .CommandText = "INSERT INTO PropietAgDet( PropietAgId, Propietario, PadUsuario, PadFecMod) " & _
                           "VALUES(" & PropietAgId & ", " & _
                                       CapturaDatoColumna(DataGridView1, "Codigo") & ", " & _
                                 "'" & Uid & "', " & _
                                 "'" & Format(Now, FormatFechaHora) & "')"
            .ExecuteNonQuery()
         End With
         '
         Trn.Commit()
         '
         ActData()
         '
      End If
      '
   End Sub
   '
   Private Sub btnQuitar_Click(sender As Object, e As EventArgs) Handles btnQuitar.Click
      '
      If DataGridView2.RowCount > 0 Then
         '
         Trn = Cn.BeginTransaction
         '
         With Cmd
            .Transaction = Trn
            .CommandText = "DELETE FROM PropietAgDet WHERE PropietAgId = " & PropietAgId & " AND Propietario = " & CapturaDatoColumna(DataGridView2, "Codigo")
            .ExecuteNonQuery()
         End With
         '
         Trn.Commit()
         '
         ActData()
         '
      End If
      '
   End Sub
   '
   Private Sub tbBuscar_TextChanged(sender As Object, e As EventArgs) Handles tbBuscar.TextChanged
      ActData()
   End Sub
   '
   Private Sub cmdSalir_Click(sender As Object, e As EventArgs) Handles cmdSalir.Click
      Me.Close()
   End Sub
   '
   Private Sub frmPropietAg_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
      SetRegGrid(Me, DataGridView1)
      SetRegGrid(Me, DataGridView2)
      SetRegForm(Me)
   End Sub
   '
End Class