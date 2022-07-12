Public Class frmListConcAdm
   '
   Dim Reporte As String
   Dim Concepto As String = ""
   '
   Private Sub frmListConcAdm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      '
      GetRegForm(Me)
      '
      ArmaCombo(cbConcepto, "Codigo", "Conceptos", "Descrip", , , "(Todos)")
      ArmaCombo(cbConceptos, "Descrip", "Conceptos", "Descrip", , , "(Todos)")
      '
      dtpPeriodo.Value = Today
      '
   End Sub
   '
   Private Sub frmListPropiedades_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
      TabReturn(e.KeyChar)
   End Sub
   '
   Private Sub cbConcepto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbConcepto.SelectedIndexChanged
      With cbConcepto
         If .SelectedIndex > 0 Then
            Concepto = .Text
         Else
            Concepto = ""
         End If
      End With
   End Sub
   '
   Private Sub cbConceptos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbConceptos.SelectedIndexChanged
      cbConcepto.SelectedIndex = cbConceptos.SelectedIndex
   End Sub
   '
   Private Sub cmdImprimir_Click(sender As Object, e As EventArgs) Handles cmdImprimir.Click      '
      '
      Dim Formulas(0, 1) As String
      Dim Filtro As String = "{AuxReporte.Uid} = '" & Uid & "' AND {AuxReporte.Host} = '" & NombrePC & "'"
      Dim SubTitulo As String = ""
      Dim Reporte As String = "ConceptosAdm.rpt"
      '
      ArmaAuxRep()
      '
      If Concepto <> "" Then
         'Filtro = Filtro & " AND {FactInq.Concepto} = '" & Concepto & "'"
         SubTitulo = "Concepto: " & cbConceptos.Text
      End If
      '
      If Not chkTodos.Checked Then
         'Filtro = Filtro & " AND {FactInq.Periodo} = '" & Format(dtpPeriodo.Value, "yyyyMM") & "'"
         SubTitulo = SubTitulo & ", Período: " & Format(dtpPeriodo.Value, "MM/yyyy")
      End If
      '
      If optPagoSi.Checked Then
         SubTitulo = SubTitulo & ", Pagados"
      End If
      '
      If optPagoNo.Checked Then
         SubTitulo = SubTitulo & ", No Pagados"
      End If
      '
      If optCobroSi.Checked Then
         SubTitulo = SubTitulo & ", Cobrados"
      End If
      '
      If optCobroNo.Checked Then
         SubTitulo = SubTitulo & ", No Cobrados"
      End If
      '
      Formulas(0, 0) = "Subtitulo" : Formulas(0, 1) = SubTitulo
      '
      ImprimirCrp(Reporte, crptToWindow, Filtro, Me.Text, Formulas)
      '
   End Sub
   '
   Private Sub ArmaAuxRep()
      '
      Dim Cmd As New OleDb.OleDbCommand
      Dim Trn As OleDb.OleDbTransaction
      '
      Trn = Cn.BeginTransaction
      '
      With Cmd
         .Connection = Cn
         .Transaction = Trn
         .CommandText = "DELETE FROM AuxReporte WHERE Uid = '" & Uid & "' AND Host = '" & NombrePC & "'"
         .ExecuteNonQuery()
         .CommandText = "INSERT INTO AuxReporte( Propietario, Propiedad, Inquilino, Codigo, Concepto, Importe, Periodo, Saldo, Uid, Host) " &
                        "SELECT  C.Propietario, F.Propiedad, F.Inquilino, 0, F.Concepto, F.Importe, F.Periodo, F.Saldo, '" & Uid & "', '" & NombrePC & "' " &
                        "FROM FactInq AS F INNER JOIN " &
                        " CompraOtr AS C ON 'CP-' + CONVERT(VARCHAR(3), F.Propiedad) + '-' + F.Concepto = C.Comprob AND RIGHT(F.Periodo, 2) = C.Sucursal AND LEFT(F.Periodo, 4) = C.Numero " &
                        "WHERE F.aPropiet = 0 " &
                        IIf(optPagoSi.Checked, "And C.Pagado <> 0 ", "") &
                        IIf(optPagoNo.Checked, "And C.Pagado = 0 ", "") &
                        IIf(optCobroNo.Checked, " And F.Saldo <> 0 ", "") &
                        IIf(optCobroSi.Checked, " And F.Saldo = 0 ", "") &
                        IIf(chkTodos.Checked, "", " And F.Periodo = '" & Format(dtpPeriodo.Value, "yyyyMM") & "'") &
                        IIf(Concepto = "", "", " AND F.Concepto = '" & Concepto & "'")
         .ExecuteNonQuery()
      End With
      '
      Trn.Commit()
      '
   End Sub
   '
   Private Sub chkTodos_CheckedChanged(sender As Object, e As EventArgs) Handles chkTodos.CheckedChanged
      dtpPeriodo.Enabled = Not chkTodos.Checked
   End Sub
   '
   Private Sub BtCerrar_Click(sender As Object, e As EventArgs) Handles btCerrar.Click
      Me.Close()
   End Sub
   '
   Private Sub FrmListConcAdm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
      SetRegForm(Me)
      Me.Dispose()
   End Sub
   '
End Class