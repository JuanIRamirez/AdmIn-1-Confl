Public Class frmAlquileres

   Public Inquilino As Int32

   Private Sub frmLiqInquilinosAbm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      '
      GetRegForm(Me)
      '
      'TraducirForm(Me)
      '
      tbInquilino.Text = CapturaDato(Cn, "Inquilinos", "Nombre", "Codigo = " & Inquilino)
      '
      ActData()
      '
   End Sub
   '
   Private Sub ActData()
      SetRegGrid(Me, DataGridView1)
      LlenarGrid(DataGridView1, "SELECT P.Domicilio, P.Codigo, PR.Nombre AS Propietario, P.NomCat, P.Valor, P.Estado, P.Localidad, P.Barrio " &
                                "FROM Propiedades P LEFT JOIN Propietarios PR " &
                                "ON P.Propietario = PR.Codigo " &
                                "WHERE P.Inquilino = " & Inquilino & " " &
                                "ORDER BY P.Domicilio")
      'SetCols()
      GetRegGrid(Me, DataGridView1)
   End Sub
   '
   Private Sub cmdSalir_Click(sender As Object, e As EventArgs) Handles cmdSalir.Click
      Me.Close()
   End Sub
   '
   Private Sub frmAlquileres_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
      SetRegForm(Me)
   End Sub
   '
End Class