Public Class frmInquilinos
   '
   Dim Trn As OleDb.OleDbTransaction
   Dim Cmd As New OleDb.OleDbCommand
   '
   Dim FormLoad As Boolean = False
   '
   'Dim rsInq As New ADODB.Recordset
   'Dim rsGarantes As New ADODB.Recordset
   'Dim rsCtto As New ADODB.Recordset
   '
   'Dim vAutoriza As Boolean
   'Dim Alta As Boolean
   'Dim cTipoIva As String
   'Dim LastKey As Integer
   'Dim vCamposVacios As String
   'Dim cBookM
   '
   Private Sub frmInquilinos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      '
      GetRegForm(Me)
      '
      TraducirForm(Me)
      '
      ActData()
      '
      FormLoad = True
      '
   End Sub
   '
   Private Sub frmInquilinos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
      TabReturn(e.KeyChar)
   End Sub
   '
   Private Sub cmdAlta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAlta.Click
      altamod(True)
   End Sub
   '
   Private Sub cmdEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEditar.Click
      AltaMod(False)
   End Sub
   '
   Private Sub AltaMod(ByVal Alta As Boolean)
      '
      Dim Form As New frmInquilinosAM
      Dim Inquilino As Int32 = 0
      '
      With Form
         .Alta = Alta
         If Not Alta Then
            With DataGridView1
               If .RowCount > 0 Then
                  Inquilino = .SelectedCells(.Columns("Codigo").Index).Value
               Else
                  Exit Sub
               End If
            End With
         End If
         .Inquilino = Inquilino
         .ShowDialog(Me)
         ActData()
      End With
      '
   End Sub
   '
   Private Sub cmdListado_Click()
      ' frmListInquilinos.Show()
   End Sub
   '
   Private Sub DataGrid1_KeyUp(ByVal KeyCode As Integer, ByVal Shift As Integer)
      'DataGrid1_Click()
   End Sub
   '
   Private Sub DataGrid1_RowColChange(ByVal LastRow As Object, ByVal LastCol As Integer)
      'DataGrid1_Click()
   End Sub
   '
   Private Sub cmdBaja_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBaja.Click
      '
      Dim Codigo As Int32
      Dim Nombre As String
      '
      With DataGridView1
         If .RowCount > 0 Then
            '
            Codigo = .SelectedCells(.Columns("Codigo").Index).Value
            Nombre = .SelectedCells(.Columns("Nombre").Index).Value
            '
            If Not IsNothing(CapturaDato(Cn, "Contratos", "Numero", "Inquilino = " & Codigo)) Then
               MensajeTrad("InqCCtto")
               Exit Sub
            End If
            '
            If DaDeBaja(Nombre) Then
               Trn = Cn.BeginTransaction
               With Cmd
                  .Connection = Cn
                  .Transaction = Trn
                  .CommandText = "DELETE FROM Inquilinos WHERE Codigo = " & Codigo
                  .ExecuteNonQuery()
               End With
               Trn.Commit()
               ActData()
            End If
            '
         End If
      End With
      '
   End Sub
   '
   Private Sub rbActivos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbActivos.CheckedChanged, rbInactivos.CheckedChanged
      ActData()
   End Sub
   '
   Private Sub tbBuscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbBuscar.TextChanged
      ActData()
   End Sub
   '
   Private Sub ActData()
      '
      If FormLoad Then
         SetRegGrid(Me, DataGridView1)
      End If
      '
      LlenarGrid(DataGridView1, "SELECT Codigo, Nombre, Domicilio, Localidad, Telefono, InqEMail, Dni FROM Inquilinos WHERE (Nombre LIKE '%" & tbBuscar.Text & "%' OR Codigo = " & Val(tbBuscar.Text) & ") AND Estado = '" & IIf(Me.rbActivos.Checked, "A", "I") & "' ORDER BY Nombre")
      '
      With DataGridView1
         For Each Col As DataGridViewColumn In .Columns
            With Col
               Select Case UCase(.Name)
                  Case "CODIGO" : .Width = 60
                  Case "NOMBRE" : .Width = 300
                  Case "DOMICILIO" : .Width = 300
                  Case "LOCALIDAD" : .Width = 200
                  Case "TELEFONO"
                  Case "INQEMAIL" : .HeaderText = "e-Mail"
                  Case "DNI" : .HeaderText = "D.N.I."
                  Case Else
                     'cCol.Caption = Traducir(cCol.Caption)
               End Select
            End With
         Next Col
         '
         cmdAlta.Enabled = True
         cmdBaja.Enabled = .RowCount > 0
         cmdEditar.Enabled = .RowCount > 0
         '
      End With
      '
      GetRegGrid(Me, DataGridView1)
      '
   End Sub
   '
   Private Sub cmdcmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
      Me.Close()
   End Sub
   '
   Private Sub frmInquilinos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
      '
      SetRegGrid(Me, DataGridView1)
      SetRegForm(Me)
      '
   End Sub
   '
End Class