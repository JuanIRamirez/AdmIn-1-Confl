Public Class frmLiqInquilinosCS
   '
   Public Inquilino As Long
   Public NroSeña As New Collection
   Public Numero As Long
   '
   Dim rsTmp As New OleDb.OleDbCommand
   Dim Alta As Boolean
   Dim Banco0 As Integer
   Dim Banco1 As Integer
   '
   Private Sub frmLiqInquilinoCS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      '
      GetRegForm(Me)
      '
      ActData()
      '
   End Sub
   '
   Private Sub frmLiqInquilinoCS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
      TabReturn(e.KeyChar, True)
   End Sub
   '
   Private Sub txtImporte_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtImporte.TextChanged
      ActData()
   End Sub
   '
   Private Sub txtNombre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNombre.TextChanged
      ActData()
   End Sub
   '
   Sub ActData()
      '
      Dim cSeñas As String = ""
      Dim i As Int16
      '
      For i = 1 To NroSeña.Count
         cSeñas = cSeñas & IIf(cSeñas = "", "", ",") & NroSeña.Item(i)
      Next i
      If cSeñas = "" Then cSeñas = "0"
      '
      GetRegGrid(Me, DataGridView1)
      '
      LlenarGrid(DataGridView1, "SELECT C.Numero, C.Fecha, C.Nombre, C.Detalle, C.Total " & _
                      "FROM CobrosOtr C, CobOtrDet D " & _
                      "WHERE C.Sucursal = D.Sucursal AND C.Numero = D.Numero " & _
                      "  AND (C.Inquilino = " & Inquilino & " OR C.Inquilino IS NULL OR C.Inquilino = 0) " & _
                      "  AND C.Liquidado = 0 AND C.Estado = 0 " & _
                      "  AND C.Total >= " & Val(txtImporte.Text) & " " & _
                      "  AND C.Nombre LIKE '%" & txtNombre.Text & "%' " & _
                      "  AND D.Concepto = 'SEN' " & _
                      "  AND C.Numero NOT IN(" & cSeñas & ") " & _
                      "ORDER BY C.Fecha DESC")
      '
      cmdAceptar.Enabled = (DataGridView1.RowCount > 0)
      '
      With DataGridView1
         For Each Col As DataGridViewColumn In .Columns
            With Col
               Select Case UCase(.Name)
                  Case "NOMBRE" : .Width = 300
                  Case "DETALLE" : .Width = 300
                  Case Else
                     'Na.
               End Select
            End With
         Next Col
      End With
      '
      SetRegGrid(Me, DataGridView1)
      '
   End Sub
   '
   Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
      '
      With DataGridView1
         If .RowCount > 0 Then
            Numero = .SelectedCells(.Columns("Numero").Index).Value
            Me.Close()
         End If
      End With
   End Sub
   '
   Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
      Me.Close()
   End Sub
   '
   Private Sub frmLiqInquilinoCS_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
      SetRegGrid(Me, DataGridView1)
      SetRegForm(Me)
   End Sub
   '
End Class