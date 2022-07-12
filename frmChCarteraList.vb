Public Class FrmChCarteraList
   '
   Dim Caja As Integer
   Dim Estado As Int16
   '
   Private Sub FrmChCarteraList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      '
      GetRegForm(Me)
      '
      TraducirForm(Me)
      '
      ArmaComboItem(cboCaja, "Cajas", "Caja", "Descrip", "Descrip", "(Todas)", , , , , prmNroCaja)
      ArmaComboItem(cbEstado, "EstChCartera", "Estado", , , "(Todos)", , , , , 0)
      '
      dtpAl.Value = Today
      '
   End Sub
   '
   Private Sub FrmChCarteraList_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
      TabReturn(e.KeyChar, True)
   End Sub
   '
   Private Sub chkTodas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodas.CheckedChanged
      dtpAl.Enabled = Not chkTodas.Checked
   End Sub
   '
   Private Sub cboCaja_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCaja.SelectedIndexChanged
      With cboCaja
         If .SelectedIndex > 0 Then
            Caja = .SelectedValue
         Else
            Caja = 0
         End If
      End With
   End Sub
   '
   Private Sub cbEstado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbEstado.SelectedIndexChanged
      With cbEstado
         If .SelectedIndex > 0 Then
            Estado = .SelectedValue
         Else
            Estado = -1
         End If
      End With
   End Sub
   '
   Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
      '
      Dim Filtro As String = ""
      Dim Formulas(0, 1) As String
      Dim Subtitulo As String = ""
      '
      If Caja <> 0 Then
         Filtro = "{ChCartera.Caja} = " & Caja
         Subtitulo = "Caja " & cboCaja.Text
      End If
      '
      Formulas(0, 0) = "SubTitulo"
      '
      If Estado > -1 Then
         Filtro = IIf(Filtro = "", "", Filtro & " AND ") & "{ChCartera.Estado} = " & Estado & " "
         Subtitulo = IIf(Subtitulo = "", "", Subtitulo & ", ") & cbEstado.Text
      End If
      '
      If Not chkTodas.Checked Then
         Filtro = IIf(Filtro = "", "", Filtro & " AND ") & " {ChCartera.FechaEmi} <= CDate('" & Format(dtpAl.Value, FormatCDATE) & "')  AND " &
                                                           "(ISNULL({ChCartera.FechaSal}) OR {ChCartera.FechaSal} >= CDATE('" & Format(dtpAl.Value, FormatCDATE) & "'))"
         Subtitulo = IIf(Subtitulo = "", "", Subtitulo & ", ") & " Al: " & dtpAl.Value
      End If
      '
      Formulas(0, 1) = Subtitulo
      '
      ImprimirCrp("ChCartera.rpt", crptToWindow, Filtro, "Cheques de Terceros", Formulas)
      '
   End Sub
   '
   Private Sub optHoy_Click()
      dtpAl.Enabled = False
   End Sub
   '
   Private Sub Option1_Click()
      dtpAl.Enabled = False
   End Sub
   '
   Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
      Me.Close()
   End Sub
   '
   Private Sub FrmChCarteraList_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
      SetRegForm(Me)
   End Sub

End Class