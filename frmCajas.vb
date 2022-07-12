Public Class frmCajas
   '
   Dim Cmd As New OleDb.OleDbCommand
   Dim Trn As OleDb.OleDbTransaction
   '
   Dim Ctrl As Control
   Dim Alta As Boolean
   '
   Private Sub frmCajas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      '
      GetRegForm(Me)
      '
      TraducirForm(Me)
      '
      cmd.Connection = Cn
      '
      If SisContable Then
         ArmaCombo(cbCtaCaja, "Cuenta", "PlanCtas", "Descrip", "RecAsi <> 0")
         ArmaCombo(cbCtaCajaAd, "Cuenta", "PlanCtas", "Descrip", "RecAsi <> 0")
      End If
      '
      ActData()
      '
   End Sub
   '
   Private Sub frmCajas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
      TabReturn(e.KeyChar)
   End Sub
   '
   Sub ActData()
      '
      LlenarGrid(DataGridView1, "SELECT * FROM Cajas ORDER BY Caja")
      '
      SetCols()
      '
   End Sub
   '
   Private Sub SetCols()
      With DataGridView1
         For Each Col As DataGridViewColumn In .Columns
            With Col
               Select Case UCase(.Name)
                  Case "CAJA" : .Width = 50
                  Case "DESCRIP" : .Width = 300 : .HeaderText = "Descripción"
                  Case "RESPONSABLE" : .Width = 300
                  Case Else : .Visible = False
               End Select
            End With
         Next Col
      End With
   End Sub
   '
   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      '
      If Val(tbCaja.Text) = 0 Then
         MensajeTrad("DINroCaja")
         tbCaja.Focus()
         Exit Sub
         '
      ElseIf tbDescrip.Text = "" Then
         MensajeTrad("DIDescrip")
         tbDescrip.Focus()
         Exit Sub
         '
      ElseIf tbResponsable.Text = "" Then
         MensajeTrad("DIResponsable")
         tbResponsable.Focus()
         Exit Sub
         '
      End If
      '
      If Alta Then
         If Not IsNothing(CapturaDato(Cn, "Cajas", "Caja", "Caja = " & Val(tbCaja.Text))) Then
            MensajeTrad("NroCajaExist")
            tbCaja.Focus()
            Exit Sub
         End If
      End If
      '
      Guardar()
      '
      ActivaCampos(False)
      '
   End Sub
   '
   Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
      ActivaCampos(False)
   End Sub
   '
   Private Sub tbCaja_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbCaja.KeyPress
      SoloNumeros(e.KeyChar)
   End Sub
   '
   Private Sub DataGrid1_RowColChange(LastRow As Object, ByVal LastCol As Integer)
      'DataGrid1_Click()
   End Sub
   '
   Private Sub btnAlta_Click(sender As Object, e As EventArgs) Handles btnAlta.Click
      Alta = True
      Limpiacampos()
      ActivaCampos(True)
      tbCaja.Focus()
   End Sub
   '
   Private Sub btnBaja_Click(sender As Object, e As EventArgs) Handles btnBaja.Click
      '
      With DataGridView1
         '
         If .RowCount = 0 Then
            MensajeTrad("NoHayRegAct")
            Exit Sub
         End If
         '
         If MsgConfirma("Elimina " & CapturaDatoColumna(DataGridView1, "Descrip")) Then
            '
            With cmd
               .CommandText = "DELETE FROM Caja WHERE Caja = " & CapturaDatoColumna(DataGridView1, "Caja")
               .ExecuteNonQuery()
            End With
            '
            ActData()
            '
         End If
         '
      End With
      '
   End Sub
   '
   Private Sub btnModif_Click(sender As Object, e As EventArgs) Handles btnModif.Click
      Modif()
   End Sub

   Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
      '
      cbCtaCaja.SelectedIndex = -1
      cbCtaCajaAd.SelectedIndex = -1
      '
      With DataGridView1
         If .RowCount > 0 Then
            '
            tbCaja.Text = .SelectedCells(.Columns("Caja").Index).Value
            tbDescrip.Text = .SelectedCells(.Columns("Descrip").Index).Value
            tbResponsable.Text = .SelectedCells(.Columns("Responsable").Index).Value
            '
         End If
      End With
      '
      ActivaCampos(False)
      '
   End Sub
   '
   Private Sub DataGridView1_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentDoubleClick
      Modif()
   End Sub
   '
   Private Sub Modif()
      If DataGridView1.RowCount > 0 Then
         Alta = False
         ActivaCampos(True)
         tbDescrip.Focus()
      End If
   End Sub
   '
   Private Sub tbBuscar_Change()
      ActData()
   End Sub
   '
   Private Sub ActivaCampos(Modo As Boolean)
      '
      Dim lEnabl As Boolean = DataGridView1.RowCount > 0
      '
      btnAlta.Enabled = Not Modo
      btnModif.Enabled = Not Modo And lEnabl
      btnBaja.Enabled = Not Modo And lEnabl
      btnCerrar.Enabled = Not Modo
      DataGridView1.Enabled = Not Modo
      '
      btnAceptar.Enabled = Modo
      btnCancelar.Enabled = Modo
      '
      tbCaja.Enabled = IIf(Alta, Modo, False)
      tbDescrip.Enabled = Modo
      tbResponsable.Enabled = Modo
      '
   End Sub
   '
   Private Sub Limpiacampos()
      For Each Ctrl In Me.Controls
         If TypeOf Ctrl Is TextBox Then
            If Ctrl.Name <> "tbBuscar" Then
               Ctrl.Text = ""
            End If
         End If
      Next Ctrl
   End Sub

   Private Sub Guardar()
      '
      Trn = Cn.BeginTransaction
      '
      With Cmd
         '
         .Transaction = Trn
         '
         If Alta Then
            .CommandText = "INSERT INTO Cajas( Caja, Descrip, Responsable, Usuario, FechaMod) " & _
                           "VALUES(" & Val(tbCaja.Text) & ", " & _
                                 "'" & tbDescrip.Text & "', " & _
                                 "'" & tbResponsable.Text & "', " & _
                                 "'" & Uid & "', " & _
                                 "'" & Format(Now, FormatFechaHora) & "')"
         Else
            .CommandText = "UPDATE Cajas SET " & _
                           " Descrip = '" & tbDescrip.Text & "', " & _
                           " Responsable = '" & tbResponsable.Text & "', " & _
                           " Usuario = '" & Uid & "', " & _
                           " FechaMod = '" & Format(Now, FormatFechaHora) & "' " & _
                           "WHERE Caja = " & Val(tbCaja.Text)
         End If
         '
         .ExecuteNonQuery()
         '
         GuardarAudit(IIf(Alta, "Alta", "Modificación") & " de Caja", "Caja (" & tbCaja.Text & ") " & tbDescrip.Text, Me.Name, "Guardar", Trn)
         '
         Trn.Commit()
         '
      End With
      '
      ActData()
      '
   End Sub

   Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
      Me.Close()
   End Sub

   Private Sub Form_Unload(Cancel As Integer)
      SetRegForm(Me)
      Me.Dispose()
   End Sub
   '
End Class