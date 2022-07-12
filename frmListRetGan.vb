Public Class frmListRetGan
   '
   Private Sub frmListRetGan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      '
      GetRegForm(Me)
      '
      dtpPeriodo.Value = SumaMes(Today, -1)
      '
   End Sub
   '
   Private Sub cmdAceptar_Click(sender As Object, e As EventArgs) Handles cmdAceptar.Click
      '
      Dim Periodo As String
      Dim Reporte As String
      Dim Filtro As String
      '
      Periodo = Format(dtpPeriodo.Value, "yyyyMM")
      '
      Reporte = IIf(optGeneral.Checked, "InfRetGcias", "InfRetGciasPrt")
      Filtro = "{RetGcias.Periodo} = '" & Periodo & "'"
      '
      ImprimirCrp(Reporte, crptToWindow, Filtro, Me.Text)
      '
   End Sub
   '
   Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
      Me.Close()
   End Sub
   '
   Private Sub Form_Unload(Cancel As Integer)
      SetRegForm(Me)
   End Sub
   '
End Class