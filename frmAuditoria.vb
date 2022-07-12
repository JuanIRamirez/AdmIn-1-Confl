Public Class frmAuditoria
   '
   Dim FormLoad As Boolean = False
   '
   Const cmpInt = "CT"
   '
   Private Sub frmAuditoria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      '
      GetRegForm(Me)
      '
      TraducirForm(Me)
      '
      ArmaCombo(cbProceso, "AuditProceso", "Audit", "AuditProceso", , "AuditProceso", "(Todos)", True)
      ArmaCombo(cbUsuario, "AuditUid", "Audit", "AuditUid", , "AuditUid", "(Todos)", True)
      '
      dtpDesde.Value = Today
      dtpHasta.Value = Today
      '
      FormLoad = True
      '
      ActData()
      '
   End Sub
   '
   Private Sub frmAuditoria_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
      TabReturn(e.KeyChar)
   End Sub
   '
   Private Sub cbProceso_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbProceso.SelectedIndexChanged, cbUsuario.SelectedIndexChanged
      ActData()
   End Sub
   '
   Private Sub dtpDesde_ValueChanged(sender As Object, e As EventArgs) Handles dtpDesde.ValueChanged, dtpHasta.ValueChanged
      ActData()
   End Sub
   '
   Private Sub chkTodas_CheckedChanged(sender As Object, e As EventArgs) Handles chkTodas.CheckedChanged
      dtpDesde.Enabled = Not chkTodas.Checked
      dtpHasta.Enabled = Not chkTodas.Checked
      ActData()
   End Sub
   '
   Private Sub tbBuscar_TextChanged(sender As Object, e As EventArgs) Handles tbBuscar.TextChanged
      ActData()
   End Sub
   '
   Private Sub ActData()
      '
      If Not FormLoad Then Exit Sub
      '
      Dim cWhere As String = ""
      '
      If cbProceso.SelectedIndex > 0 Then
         cWhere = "WHERE AuditProceso = '" & cbProceso.Text & "'"
      End If
      '
      If cbUsuario.SelectedIndex > 0 Then
         cWhere = IIf(cWhere = "", "WHERE", cWhere & " AND") & " AuditUid = '" & cbUsuario.Text & "'"
      End If
      '
      If tbBuscar.Text <> "" Then
         cWhere = IIf(cWhere = "", "WHERE", cWhere & " AND") & "( AuditDetalle LIKE '%" & tbBuscar.Text & "%' OR AuditDescrip LIKE '%" & tbBuscar.Text & "%')"
      End If
      '
      If Not chkTodas.Checked Then
         cWhere = IIf(cWhere = "", "WHERE", cWhere & " AND") & _
                  " AuditFecha >= " & strFEC & Format(dtpDesde.Value, FormatFecha) & strFEC & _
                  " AND AuditFecha <= " & strFEC & Format(dtpHasta.Value, FormatFecha) & " 23:59:59" & strFEC & " "
      End If
      '
      SetRegGrid(Me, DataGridView1)
      LlenarGrid(DataGridView1, "SELECT * FROM Audit " & cWhere & "ORDER BY AuditID DESC")
      '
      GetRegGrid(Me, DataGridView1)
      '
      DataGrid1_Click()
      '
   End Sub
   '
   Private Sub SetCols()
      With DataGridView1
         For Each Col As DataGridViewColumn In .Columns
            With Col
               Select Case UCase(.Name)
                  Case "Numero" : .Width = 75 : .HeaderText = "Nº Ctto."
                  Case "FechaContrato" : .HeaderText = "Fecha"
                  Case "Propietario" : .Visible = False
                  Case "NomProp" : .Width = 200 : .HeaderText = "Propietario"
                  Case "Propiedad" : .Width = 85
                  Case "Domicilio" : .Width = 200
                  Case "Inquilino" : .Visible = False
                  Case "Nombre" : .Width = 200 : .HeaderText = "Inquilino"
                  Case "PerDde" : .HeaderText = "Per.Desde"
                  Case "PerHta" : .HeaderText = "Per.Hasta"
                  Case "Estado" : .Visible = False
                  Case "DescEst" : .HeaderText = "Estado"
               End Select
            End With
         Next Col
      End With
   End Sub
   '
   Private Sub DataGrid1_RowColChange(LastRow As Object, ByVal LastCol As Integer)
      DataGrid1_Click()
   End Sub
   '
   Private Sub DataGrid1_KeyUp(KeyCode As Integer, Shift As Integer)
      DataGrid1_Click()
   End Sub
   '
   Private Sub DataGrid1_Click()
      'With Adodc1.Recordset
      'If .RecordCount > 0 Then
      'cmdImprimir.Enabled = True
      ''cmdAnular.Enabled = True
      'Me.txtDescrip = !AuditDescrip
      'Me.txtDetalle = !AuditDetalle
      'Me.dtpFechaHora = !AuditFecha
      'Me.txtProceso = !AuditProceso
      'Me.txtSubProceso = !AuditSubProc & ""
      'End If
      'End With
   End Sub
   '
   Private Sub cmdImprimir_Click()
      'If Adodc1.Recordset!Estado = 2 Then
      'MensajeTrad("CttoAnulado")
      'Else
      'GenRepContrato tbNumero, "Contrato", CrystalReport1
      'End If
   End Sub
   '
   Private Sub btCerrar_Click(sender As Object, e As EventArgs) Handles btCerrar.Click
      Me.Close()
   End Sub
   '
   Private Sub frmAuditoria_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
      SetRegGrid(Me, DataGridView1)
      SetRegForm(Me)
      Me.Dispose()
   End Sub
   '
End Class