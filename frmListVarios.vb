Public Class frmListVarios
   '
   'Dim Periodo As String
   'Dim Concepto As String
   '
   Private Sub frmListRSI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      '
      GetRegForm(Me)
      '
      dtpDesde.Value = Today
      dtpHasta.Value = Today
      '
   End Sub
   '
   Private Sub frmListConcFijos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
      TabReturn(e.KeyChar)
   End Sub
   '
   Private Sub optConcCob_CheckedChanged(sender As Object, e As EventArgs) Handles optConcCob.CheckedChanged, optInqGar.CheckedChanged, optConcLiq.CheckedChanged
      dtpDesde.Enabled = optConcCob.Checked
      dtpHasta.Enabled = optConcCob.Checked
   End Sub
   '
   Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
      '
      'Dim CarpRep As String = "C:\RamSis\Admin\Reportes\RSI\"
      Dim Reporte As String = ""
      Dim Filtro As String = ""
      Dim Titulo As String = ""
      '
      If optInqGar.Checked Then
         Reporte = "InquilinosGar"
         Filtro = "{Inquilinos.Estado} = 'A'"
         Titulo = "Listado de Inquilinos y Garantes"
      Else
         If optConcCob.Checked Then
            Reporte = "ConceptosCob"
            Titulo = "Listado de Conceptos Cobrados"
            Filtro = "{LiqInqCab.Fecha} IN CDATE('" & Format(dtpDesde.Value, FormatCDATE) & "')" &
                                      " TO CDATE('" & Format(dtpHasta.Value, FormatCDATE) & "') "
         Else
            Reporte = "ConceptosLiq"
            Titulo = "Listado de Conceptos Liquidados"
            Filtro = "{LiqPropiet.Fecha} IN CDATE('" & Format(dtpDesde.Value, FormatCDATE) & "')" &
                                       " TO CDATE('" & Format(dtpHasta.Value, FormatCDATE) & "') "
         End If
      End If
      '
      'If Concepto <> "" Then
      'Filtro = IIf(Filtro = "", "", Filtro & " AND ") & "{PropiedConc.Concepto} = '" & Concepto & "'"
      'End If
      '
      ImprimirCrp(Reporte, crptToWindow, Filtro, Titulo)
      '
   End Sub
   '
   Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
      Me.Close()
   End Sub
   '
   Private Sub frmListConcFijos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
      SetRegForm(Me)
   End Sub
   '
End Class