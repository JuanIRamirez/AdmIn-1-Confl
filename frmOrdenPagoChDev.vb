Public Class frmOrdenPagoChDev

   Public TablaTmp, TablaDev As String
   Public Total, TotalDev As Double
   '
   Dim Cmd As New OleDb.OleDbCommand
   Dim Trn As OleDb.OleDbTransaction
   'Dim CtaCont As String
   'Dim Alta As Boolean
   '
   Dim Origen As String
   Dim Banco As Integer
   Dim Cuenta As String
   Dim Numero As Long
   '
   Private Sub frmOrdenPagoChDev_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      '
      ActData()
      '
   End Sub
   '
    Private Sub btnDevolver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDevolver.Click
        '
        With DataGridView1
            If .RowCount > 0 Then
                '
                Origen = .SelectedCells(.Columns("Origen").Index).Value
                Banco = .SelectedCells(.Columns("Banco").Index).Value
                Cuenta = .SelectedCells(.Columns("Cuenta").Index).Value
                Numero = .SelectedCells(.Columns("Numero").Index).Value
                '
                Trn = Cn.BeginTransaction
                '
                With Cmd
                    .Connection = Cn
                    .Transaction = Trn
                    .CommandText = "INSERT INTO " & TablaDev & " SELECT * FROM " & TablaTmp & _
                                   " WHERE Origen = '" & Origen & "' AND Banco = " & Banco & " AND Cuenta = '" & Cuenta & "' AND Numero = " & Numero
                    .ExecuteNonQuery()
                    '
                    .CommandText = "DELETE FROM " & TablaTmp & _
                                   " WHERE Origen = '" & Origen & "' AND Banco = " & Banco & " AND Cuenta = '" & Cuenta & "' AND Numero = " & Numero
                    .ExecuteNonQuery()
                End With

                Trn.Commit()
                '
                ActData()
                '
            End If
        End With
    End Sub

   Private Sub btnCancelar_Click_1(sender As Object, e As EventArgs) Handles btnCancelar.Click
      '
      With DataGridView2
         '
         If .RowCount > 0 Then
            '
            Origen = .SelectedCells(.Columns("Origen").Index).Value
            Banco = .SelectedCells(.Columns("Banco").Index).Value
            Cuenta = .SelectedCells(.Columns("Cuenta").Index).Value
            Numero = .SelectedCells(.Columns("Numero").Index).Value
            '
            Trn = Cn.BeginTransaction
            '
            With Cmd
               .Connection = Cn
               .Transaction = Trn
               .CommandText = "INSERT INTO " & TablaTmp & " SELECT * FROM " & TablaDev & _
                              " WHERE Origen = '" & Origen & "' AND Banco = " & Banco & " AND Cuenta = '" & Cuenta & "' AND Numero = " & Numero
               .ExecuteNonQuery()
               .CommandText = "DELETE FROM " & TablaDev & _
                              " WHERE Origen = '" & Origen & "' AND Banco = " & Banco & " AND Cuenta = '" & Cuenta & "' AND Numero = " & Numero
               .ExecuteNonQuery()
               '
            End With
            '
            Trn.Commit()
            '
            ActData()
            '
         End If
      End With

   End Sub
   '
   Private Sub DataGrid1_RowColChange(LastRow As Object, ByVal LastCol As Integer)
      'DataGrid1_Click
   End Sub
   '
   Private Sub ActData()
      '
      'Dim cCol As MSDBGrid.Column
      '
      LlenarGrid(DataGridView1, "SELECT * FROM " & TablaTmp)
      Total = Val(CapturaDato(Cn, TablaTmp, "SUM(Importe)", "") & "")
      '
      '
      LlenarGrid(DataGridView2, "SELECT * FROM " & TablaDev)
      TotalDev = Val(CapturaDato(Cn, TablaDev, "SUM(Importe)", "") & "")
      '
      'With DataGrid1
      '   For Each cCol In .Columns
      '      With cCol
      '         Select Case UCase(.Caption)
      '            Case "USUARIO"
      '               .Visible = False
      '            Case "BANCO"
      '               .Visible = False
      '            Case "ORIGEN"
      '               .Width = 500
      '            Case "CUENTA"
      '               .Width = 1000
      '            Case "FECHA"
      '               .Width = 1000
      '            Case "TITULAR"
      '               .Width = 2000
      '            Case "IMPORTE"
      '               .Width = 1000
      '               .NumberFormat = "#,##0.00 "
      '         End Select
      '      End With
      '   Next cCol
      'End With
      '
      'DataGrid1_Click
      '
   End Sub
   '
   Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
      Me.Close()
   End Sub
   '
   Private Sub Form_Unload(Cancel As Integer)
      'rsBcos.Close
      SetRegForm(Me)
      Me.Dispose()
   End Sub
   '


End Class