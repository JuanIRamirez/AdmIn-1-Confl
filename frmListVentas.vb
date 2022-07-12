Public Class frmListVentas
   '
   Dim Desde, Hasta As Date
   '
   Private Sub frmListVentasProp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      '
      GetRegForm(Me)
      '
      TraducirForm(Me)
      '
      dtpPeriodo.Value = SumaMes(Today, -1)
      '
   End Sub
   '
   Private Sub frmListVentas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
      TabReturn(e.KeyChar)
   End Sub
   '
   Private Sub dtpPeriodo_ValueChanged(sender As Object, e As EventArgs) Handles dtpPeriodo.ValueChanged
      Desde = "01/" & Format(dtpPeriodo.Value, "MM/yyyy")
      Hasta = UltDiaMes(dtpPeriodo.Value)
   End Sub
   '
   Private Sub cmdAceptar_Click(sender As Object, e As EventArgs) Handles cmdAceptar.Click
      '
      Dim Filtro As String
      Dim Formulas(1, 1) As String
      '
      Filtro = "{Ventas.Fecha} IN CDATE('" & Format(Desde, FormatCDATE) & "')" & _
                             " TO CDATE('" & Format(Hasta, FormatCDATE) & "')"
      '
      If chkProp.Checked Then
         Filtro = Filtro & " AND {Ventas.LiqPropiet} <> 0"
      End If
      '
      Formulas(0, 0) = "Subtitulo" : Formulas(0, 1) = "Período: " & Format(dtpPeriodo.Value, "MM/yyyy") & IIf(chkProp.Checked, " (Solo a Propietarios)", "")
      Formulas(1, 0) = "Empresa" : Formulas(1, 1) = cfgNomEmp
      '
      ImprimirCrp("Ventas", crptToWindow, Filtro, Me.Text, Formulas)
      '
   End Sub
   '
   Private Sub cmdCerrar_Click(sender As Object, e As EventArgs) Handles cmdCerrar.Click
      Me.Close()
   End Sub
   '
   Private Sub Form_Unload(Cancel As Integer)
      SetRegForm(Me)
   End Sub
   '
End Class