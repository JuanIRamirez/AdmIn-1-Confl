Public Class frmLiqInquilinosRet
   '
   Public tablaTmp As String
   Public Total As Double
   '
   Private Sub frmLiqInquilinosRet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      ActData()
   End Sub
   '
   Private Sub ActData()
      LlenarGrid(DataGridView1, "SELECT * FROM " & tablaTmp)
      SetCols()
   End Sub
   '
   Private Sub SetCols()
      '
      For Each Col As DataGridViewColumn In DataGridView1.Columns
         With Col
            Select Case .Name
               Case "Tipo" : .Width = 40
               Case "Sucursal" : .Width = 50 : .HeaderText = "Suc."
               Case "Numero" : .Width = 75 : .HeaderText = "Rbo. Nº"
               Case "Retencion" : .DefaultCellStyle.Format = "#,##0.00 " : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .Width = 100
               Case Else : .Visible = False
            End Select
         End With
      Next Col
      '
   End Sub
   '
   Private Sub DataGridView1_Click(sender As Object, e As EventArgs) Handles DataGridView1.Click
      ActText()
   End Sub
   '
   Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
      ActText()
   End Sub
   '
   Private Sub ActText()
      With DataGridView1
         tbRetencion.Text = .SelectedCells(.Columns("Retencion").Index).Value
      End With
   End Sub
   '
   Private Sub brnAceptar_Click(sender As Object, e As EventArgs) Handles brnAceptar.Click
      Dim Numero As Int32
      With DataGridView1
         Numero = .SelectedCells(.Columns("Numero").Index).Value
      End With
      Dim cmd As New OleDb.OleDbCommand
      cmd.Connection = Cn
      cmd.CommandText = "UPDATE " & tablaTmp & " SET Retencion = " & Val(tbRetencion.Text) & " WHERE Numero = " & Numero
      cmd.ExecuteNonQuery()
      ActData()
   End Sub
   '
   Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
      Total = CapturaDato(Cn, tablaTmp, "SUM(Retencion)", "")
      Me.Close()
   End Sub
   '
End Class