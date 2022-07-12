Public Class frmCajaRecList
   '
   Dim Periodo As String
   Dim Filtro As String = ""
   '
   Private Sub frmCajaRecList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      GetRegForm(Me)
   End Sub
   '
   Private Sub cmdAceptar_Click(sender As Object, e As EventArgs) Handles cmdAceptar.Click
      Dim Reporte As String
      If optDetalle.Checked Then
         Reporte = "CajaRec"
      ElseIf optResumen.Checked Then
         Reporte = "CajaRecRes"
      Else
         Reporte = "CajaRecRec"
      End If
      ImprimirCrp(Reporte, crptToWindow, Filtro, "Listado de Caja a Recuperar")
   End Sub
   '
   Private Sub cmdCerrar_Click(sender As Object, e As EventArgs) Handles cmdCerrar.Click
      Me.Close()
   End Sub
   '
   Private Sub frmCajaRecList_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
      SetRegForm(Me)
   End Sub
   '
End Class