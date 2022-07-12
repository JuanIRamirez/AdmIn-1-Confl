Public Class frmContratosList
   '
   Dim Propietario As Long
   '
   Private Sub frmContratosList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      '
      GetRegForm(Me)
      '
      TraducirForm(Me)
      '
      dtpDesde.Value = PrimeroDeMes(Today)
      dtpHasta.Value = Today
      '
      ArmaComboItem(cbPropietario, "Propietarios", "Codigo", "Nombre", "Nombre", "(Todos)", "Estado = 'A'")
      '
      ActCtrl()
      '
   End Sub
   '
   Private Sub frmContratosList_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
      TabReturn(e.KeyChar)
   End Sub
   '
   '
   Private Sub cbPropietario_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPropietario.SelectedIndexChanged
      With cbPropietario
         If .SelectedIndex <= 0 Then
            Propietario = 0
         Else
            Propietario = .SelectedValue
         End If
      End With
   End Sub
   '
   Private Sub chkActivos_CheckedChanged(sender As Object, e As EventArgs) Handles chkActivos.CheckedChanged
      ActCtrl()
   End Sub
   '
   Private Sub chkVencidos_CheckedChanged(sender As Object, e As EventArgs) Handles chkFinalizados.CheckedChanged
      ActCtrl()
   End Sub
   '
   Private Sub optFinalizados_CheckedChanged(sender As Object, e As EventArgs)
      ActCtrl()
   End Sub
   '
   Private Sub chkTodas_CheckedChanged(sender As Object, e As EventArgs) Handles chkTodas.CheckedChanged
      ActCtrl()
   End Sub
   '
   Private Sub chkNoAct_CheckedChanged(sender As Object, e As EventArgs) Handles chkNoAct.CheckedChanged
      ActCtrl()
   End Sub
   '
   Private Sub ActCtrl()
      dtpDesde.Enabled = Not chkTodas.Checked  'IIf(Not chkFinalizados.Checked And Not optFinalizados.Checked, True, False)
      dtpHasta.Enabled = Not chkTodas.Checked  'IIf(Not chkFinalizados.Checked And Not optFinalizados.Checked, True, False)
      chkActivos.Enabled = Not chkNoAct.Checked
      chkFinalizados.Enabled = Not chkNoAct.Checked
      chkAnulados.Enabled = Not chkNoAct.Checked
      'cbPropietario.Enabled = Not optFinalizados.Checked
      optInicio.Enabled = Not chkTodas.Checked
      optFinal.Enabled = Not chkTodas.Checked
      chkNoAct.Enabled = cfgMesesAct > 0
   End Sub
   '
   Private Sub cmdAceptar_Click(sender As Object, e As EventArgs) Handles cmdAceptar.Click
      '
      Dim Filtro As String = ""
      Dim Reporte As String = "ListContratos.rpt"
      Dim Per0 As String
      Dim Per1 As String
      Dim Formulas(0, 1) As String
      '
      Per0 = Format(dtpDesde.Value, "yyyyMM")
      Per1 = Format(dtpHasta.Value, "yyyyMM")
      '
      'If optFinalizados.Checked Then
      'Reporte = "ListCttosFinDda"
      'Else
      If chkActivos.Checked Then
         Filtro = "{Contratos.Estado} = 0"
      End If
      If chkFinalizados.Checked Then
         Filtro = IIf(Filtro = "", "", Filtro & " OR ") & "{Contratos.Estado} = 1 "
      End If
      If chkAnulados.Checked Then
         Filtro = IIf(Filtro = "", "", Filtro & " OR ") & "{Contratos.Estado} = 2 "
      End If
      If Filtro <> "" Then
         Filtro = "(" & Filtro & ")"
      End If
      '
      If Not chkTodas.Checked Then
         If optInicio.Checked Then
            Filtro = Filtro & " AND {Contratos.PerDesde} >= '" & Per0 & "' AND " &
                              "     {Contratos.PerDesde} <= '" & Per1 & "' "
         Else
            'If Not chkFinalizados.Checked Then
            Filtro = Filtro & " AND {Contratos.PerHasta} >= '" & Per0 & "' AND " &
                              "     {Contratos.PerHasta} <= '" & Per1 & "' "
            'Else
            'Filtro = Filtro & " AND {Contratos.PerHasta} < '" & Format(Today, "yyyyMM") & "'"
            'Reporte = "ListCttoVenc.rpt"
            'End If
         End If
      End If
      '
      If Propietario <> 0 Then
         Filtro = Filtro & " AND {Propietarios.Codigo} = " & Propietario & " "
      End If
      ' 
      Formulas(0, 0) = "SubTitulo" : Formulas(0, 1) = IIf(chkActivos.Checked, "Activos, ", "") & IIf(chkFinalizados.Checked, "Finalizados, ", "") & IIf(chkAnulados.Checked, "Anulados, ", "") & IIf(chkTodas.Checked, "", " - p/Fecha " & IIf(optInicio.Checked, "Inicio", "Finalización") & " - Desde: " & Format(dtpDesde.Value, "MM/yyyy") & " Hasta: " & Format(dtpHasta.Value, "MM/yyyy"))
      '
      'End If
      '
      ImprimirCrp(Reporte, crptToWindow, Filtro, Me.Text, Formulas)
      '
   End Sub
   '
   Private Sub cmdCerrar_Click(sender As Object, e As EventArgs) Handles cmdCerrar.Click
      Me.Close()
   End Sub
   '
   Private Sub frmContratosList_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
      SetRegForm(Me)
   End Sub
   '
End Class