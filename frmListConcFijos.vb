Public Class frmListConcFijos
   '
   Dim Periodo As String
   Dim Concepto As String
   '
   Private Sub frmListConcFijos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      '
      GetRegForm(Me)
      '
      ArmaCombo(cbDescConc, "Descrip", "Conceptos", "Descrip", , , "(Todos)")
      ArmaCombo(cbConcepto, "Codigo", "Conceptos", "Descrip", , , "(Todos)")
      '
   End Sub
   '
   Private Sub frmListConcFijos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
      TabReturn(e.KeyChar)
   End Sub
   '
   Private Sub cbConcepto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbConcepto.SelectedIndexChanged
      cbDescConc.SelectedIndex = cbConcepto.SelectedIndex
      If cbConcepto.SelectedIndex <= 0 Then
         Concepto = ""
      Else
         Concepto = cbConcepto.SelectedItem
      End If
   End Sub
   '
   Private Sub cbDescConc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbDescConc.SelectedIndexChanged
      If cbConcepto.Items.Count > 0 Then
         cbConcepto.SelectedIndex = cbDescConc.SelectedIndex
      End If
   End Sub
   '
   Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
      '
      Dim Reporte As String = "ConceptosFijos"
      Dim Filtro As String = "{Propietarios.Estado} = 'A' AND {Propiedades.Estado} = 'A'"
      Dim Formulas(0, 1) As String
      '
      Formulas(0, 0) = "Subtitulo"
      '
      If optPropietario.Checked Then
         Filtro = Filtro & " AND {PropiedConc.aPropiet}"
         Formulas(0, 1) = "a Propietario"
      ElseIf optAdmin.Checked Then
         Filtro = Filtro & " AND NOT {PropiedConc.aPropiet}"
         Formulas(0, 1) = "Administración"
      ElseIf optAdminNR.Checked Then
         Reporte = "ConcAdmNR"
         InsAuxReporte()
         Filtro = "{AuxReporte.uid} = '" & Uid & "' AND {AuxReporte.Host} = '" & NombrePC & "'"
         Formulas(0, 1) = "Administración no recuperados"
      End If
      '
      If Not optAdminNR.Checked Then
         If chkActuales.Checked Then
            Reporte = "ConceptosFijosAct"
            Filtro = Filtro & " AND {PropiedConc.FecDesde} <= CDATE('" & Format(Today, FormatCDATE) & "') "
            Formulas(0, 1) = Formulas(0, 1) & ", Solo actuales "
         End If
      End If
      '
      If optPropietario.Checked Then
         If chkNoInq.Checked Then
            Filtro = Filtro & " AND {PropiedConc.noInquilino}"
            Formulas(0, 1) = Formulas(0, 1) & ", No imputados a Inquilino"
         End If
      End If
      '
      If Concepto <> "" Then
         Filtro = Filtro & " AND {PropiedConc.Concepto} = '" & Concepto & "'"
      End If
      '
      ImprimirCrp(Reporte, crptToWindow, Filtro, "Listado de Conceptos Fijos", Formulas)
      '
   End Sub
   '
   Private Sub optAdminNR_CheckedChanged(sender As Object, e As EventArgs) Handles optAdminNR.CheckedChanged
      chkActuales.Enabled = Not optAdminNR.Checked
   End Sub
   '
   Private Sub optPropietario_CheckedChanged(sender As Object, e As EventArgs) Handles optPropietario.CheckedChanged, optTodos.CheckedChanged, optAdmin.CheckedChanged, optAdminNR.CheckedChanged
      chkNoInq.Enabled = optPropietario.Checked
   End Sub
   '
   Private Sub InsAuxReporte()
      '
      Dim Cmd As New OleDb.OleDbCommand
      '
      With Cmd
         .Connection = Cn
         .CommandText = "DELETE From AuxReporte WHERE uid = '" & Uid & "' AND Host = '" & NombrePC & "'"
         .ExecuteNonQuery()
         '
         .CommandText = "INSERT INTO [dbo].[AuxReporte]( [Propietario], [Propiedad], [Inquilino], [Codigo], [Concepto], [Importe], [Saldo], [Periodo], [Uid], [Host]) " &
                        "SELECT F.Propietario, F.Propiedad, F.Inquilino, NULL, F.Concepto, F.Importe, F.Saldo, LEFT(F.Periodo,4) + '-' + RIGHT(F.Periodo,2), '" & Uid & "', '" & NombrePC & "' " &
                        "FROM FactInq F INNER JOIN CompraOtr C " &
                        " ON F.Propiedad = C.Propiedad And F.Concepto = RIGHT(C.Comprob, 3) And FORMAT(C.Numero, '000#') + FORMAT(C.Sucursal, '0#') = F.Periodo " &
                        "WHERE F.aPropiet = 0 And F.Saldo <> 0 And F.Fecha <= GETDATE() AND C.Pagado <> 0" &
                        "ORDER BY F.Propiedad, F.Concepto, F.Periodo "
         .ExecuteNonQuery()
      End With
      '
   End Sub
   Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
      Me.Close()
   End Sub
   '
   Private Sub frmListConcFijos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
      SetRegForm(Me)
   End Sub
   '
End Class