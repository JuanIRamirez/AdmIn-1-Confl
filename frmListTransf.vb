Public Class frmListTransf
   '
   Private Sub frmListTransf_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      GetRegForm(Me)
      dtpPeriodo.Value = Today
   End Sub
   '
   Private Sub cmdAceptar_Click(sender As Object, e As EventArgs) Handles cmdAceptar.Click
      '
      Dim Formulas(0, 1) As String
      Dim Filtro As String = ""
      Dim SubTitulo As String = ""
      Dim Reporte As String = ""
      '
      If optInq.Checked Then
         Reporte = "TransfInq"
         Filtro = "{LiqInqTR.FechaTR} IN CDATE('" & Format(dtpDesde.Value, FormatCDATE) & "') " & _
                                    " TO CDATE('" & Format(dtpHasta.Value, FormatCDATE) & "') "
      Else
         Reporte = "TransfProp"
         Filtro = "{LiqPropTR.FechaTR} IN CDATE('" & Format(dtpDesde.Value, FormatCDATE) & "') " & _
                                     " TO CDATE('" & Format(dtpHasta.Value, FormatCDATE) & "') "
      End If
      '
      Formulas(0, 0) = "Subtitulo" : Formulas(0, 1) = "Del: " & dtpDesde.Value & " al: " & dtpHasta.Value
      '
      ImprimirCrp(Reporte, crptToWindow, Filtro, Me.Text, Formulas)
      '
   End Sub
   '
   Private Sub dtpPeriodo_ValueChanged(sender As Object, e As EventArgs) Handles dtpPeriodo.ValueChanged
      dtpDesde.Value = PrimeroDeMes(dtpPeriodo.Value)
      dtpHasta.Value = UltDiaMes(dtpPeriodo.Value)
   End Sub
   '
   Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
      Me.Close()
   End Sub
   '
   Private Sub frmListTransf_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
      SetRegForm(Me)
   End Sub
   '
End Class