Public Class frmFondo
   '
   Private Sub btnReciboInq_Click(sender As Object, e As EventArgs) Handles btnReciboInq.Click
      frmMenu.AltaLiqInq()
   End Sub
   '
   Private Sub btnLiquidProp_Click(sender As Object, e As EventArgs) Handles btnLiquidProp.Click
      frmMenu.AltaLiqProp()
   End Sub

   Private Sub btnInquilinos_Click(sender As Object, e As EventArgs) Handles btnInquilinos.Click
      frmMenu.Inquilinos()
   End Sub

   Private Sub btnPropiedades_Click(sender As Object, e As EventArgs) Handles btnPropiedades.Click
      frmMenu.Propiedades()
   End Sub

   Private Sub btnPropietarios_Click(sender As Object, e As EventArgs) Handles btnPropietarios.Click
      frmMenu.Propietarios()
   End Sub

   Private Sub btnContrato_Click(sender As Object, e As EventArgs) Handles btnContrato.Click
      frmMenu.AltaContrato()
   End Sub

   Private Sub frmFondo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

   End Sub
   '
End Class