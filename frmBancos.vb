Public Class frmBancos
   '
   'Dim Ctrl As Control
   'Dim Alta As Boolean
   Dim Rs As New OleDb.OleDbCommand
   Dim Dr As OleDb.OleDbDataReader
   'Dim i As Integer
   'Dim CtaCont As String
   '
   'Const cTabla = "Bancos"
   '
   Private Sub frmBancos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      '
      GetRegForm(Me)
      '
      'TraducirForm(Me)
      GetRegForm(Me)
      '
      If SisContable Then
         'cboCtaCont.Enabled = True
         'ArmaComboItem(cboCtaCont, "PlanCtas", "CtaCont", , , , "RecAsi <> 0")
      Else
         'cboCtaCont.Enabled = False
      End If
      '
      Rs.Connection = cn
      'Adodc1.ConnectionString = cn
      'Adodc2.ConnectionString = cn
      '
      ActData()
      'ActData2()
      '
   End Sub

   Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
      Me.Close()
   End Sub
   '
   Private Sub frmBancos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
      TabReturn(e.KeyChar)
   End Sub
   '
   Sub ActData()
      '
      SetRegGrid(Me, DataGridView1)
      '
      Dim cSql As String = "SELECT Banco, Nombre, Domicilio, Telefono, Contacto, Tel_Contac " & _
                           "FROM Bancos " & _
                           "WHERE Nombre LIKE '%" & tbBuscar.Text & "%' " & _
                           "ORDER BY Nombre"
      LlenarGrid(Me.DataGridView1, cSql)
      '
      SetCols()
      '
      GetRegGrid(Me, DataGridView1)
      '
      With DataGridView1
         btnBaja.Enabled = (.RowCount > 0)
         btnModif.Enabled = (.RowCount > 0)
      End With
      '
   End Sub
   '
   Private Sub SetCols()
      With DataGridView1
         For Each cCol As DataGridViewColumn In .Columns
            With cCol
               Select Case UCase(.Name)
                  Case "BANCO" : .Width = 50
                  Case "NOMBRE" : .Width = 250
                  Case "DOMICILIO" : .Width = 250
                  Case "TEL_CONTAC"
                     'Case Else : cCol.Visible = False
               End Select
               'cCol.Caption = Traducir(cCol.Caption)
            End With
         Next cCol
      End With
   End Sub
   '
   Private Sub DataGridView1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyUp
      'ActCtrl()
   End Sub
   '
   Private Sub DataGridView1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridView1.MouseClick
      'ActCtrl()
   End Sub
   '
   Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
      'ActCtrl()
   End Sub
   '
   Private Sub btnAlta_Click(sender As Object, e As EventArgs) Handles btnAlta.Click
      AltaMod(True)
   End Sub
   '
   Private Sub btnBaja_Click(sender As Object, e As EventArgs) Handles btnBaja.Click
      '
      Dim Cmd As New OleDb.OleDbCommand
      Dim Nombre As String
      Dim Banco As Integer
      '
      Cmd.Connection = Cn
      '
      With DataGridView1
         If .RowCount = 0 Then
            MensajeTrad("NoHayRegAct")
            Exit Sub
         End If
         Nombre = .SelectedCells(.Columns("Nombre").Index).Value
         Banco = Val(.SelectedCells(.Columns("Codigo").Index).Value)
         If MsgBox("Elimina " & Nombre, vbQuestion & vbYesNo) = vbYes Then
            Cmd.CommandText = "DELETE FROM Bancos WHERE Banco = " & Banco
            Cmd.ExecuteNonQuery()
            ActData()
         End If
      End With
      '
   End Sub
   '
   Private Sub btnModif_Click(sender As Object, e As EventArgs) Handles btnModif.Click
      Altamod(False)
   End Sub
   '
   Private Sub AltaMod(Alta As Boolean)
      Dim Banco As Int32
      If Alta Then
         Banco = 0
      Else
         With DataGridView1
            If .RowCount = 0 Then
               MensajeTrad("NoHayRegAct")
               Exit Sub
            End If
            Banco = .SelectedCells(.Columns("Banco").Index).Value
         End With
      End If
      '
      With frmBancosAM
         .Banco = Banco
         .ShowDialog(Me)
      End With
      '
      ActData()
      '
   End Sub
   '
   Private Sub btnCuentas_Click(sender As Object, e As EventArgs) Handles btnCuentas.Click
      '
      Dim Banco As Int32
      '
      With DataGridView1
         If .RowCount = 0 Then
            MensajeTrad("NoHayRegAct")
            Exit Sub
         End If
         Banco = .SelectedCells(.Columns("Banco").Index).Value
      End With
      '
      With frmBancosCtas
         .Banco = Banco
         .ShowDialog(Me)
      End With
      '
   End Sub
   '
   'Private Sub DataGrid1_DblClick()
   '   If DataGrid1.Row > -1 Then
   '      cmdEdicion_Click(0)
   '   End If
   'End Sub
   '
   Private Sub tbBuscar_TextChanged(sender As Object, e As EventArgs) Handles tbBuscar.TextChanged
      ActData()
   End Sub
   '
   Private Sub cboCtaCont_Change()
      'PintarCb(cboCtaCont, LastKey)
      'If cboCtaCont = "" Then
      ' CtaCont = ""
      'End If
   End Sub
   '
   'Private Sub cboCtaCont_Click()
   '   CtaCont = CapturaDato(Cn, "PlanCtas", "CtaCont", "Descrip = '" & cboCtaCont.Text & "'")
   'End Sub
   '
   Private Sub frmBancos_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
      SetRegGrid(Me, DataGridView1)
      SetRegForm(Me)
   End Sub
   '
End Class