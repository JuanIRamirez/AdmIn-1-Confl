Public Class frmBancosCtas
   '
   Public Banco As Int32
   '
   'Dim Alta As Boolean
   Dim Cmd As New OleDb.OleDbCommand
   Dim Drd As OleDb.OleDbDataReader
   'Dim i As Integer
   'Dim CtaCont As String
   '
   'Const cTabla = "Bancos"
   '
   Private Sub frmBancos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      '
      GetRegForm(Me)
      '
      If Banco = 0 Then
         MensajeTrad("DinfBanco")
         DeshabForm(Me)
      End If
      '
      tbBanco.Text = CapturaDato(Cn, "Bancos", "Nombre", "Banco = " & Banco)
      '
      If SisContable Then
         'cboCtaCont.Enabled = True
         'ArmaComboItem(cboCtaCont, "PlanCtas", "CtaCont", , , , "RecAsi <> 0")
      Else
         'cboCtaCont.Enabled = False
      End If
      '
      Cmd.Connection = cn
      'Adodc1.ConnectionString = cn
      'Adodc2.ConnectionString = cn
      '
      ActData()
      'ActData2()
      '
   End Sub

   Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
      Me.Close()
   End Sub
   '
   Private Sub frmBancos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
      TabReturn(e.KeyChar)
   End Sub
   '
   Private Sub ActData()
      '
      'With Adodc2
      Dim cSql As String = "SELECT * FROM BancosCtas " &
                           "WHERE Banco = " & Banco &
                           "ORDER BY BancoCta"
      '
      LlenarGrid(DataGridView1, cSql)
      '
      SetCols()
      '
      With DataGridView1
         btnBaja.Enabled = (.RowCount > 0)
         btnModif.Enabled = (.RowCount > 0)
      End With
      '
   End Sub
   '
   Private Sub SetCols()
      '
      With DataGridView1
         For Each cCol As DataGridViewColumn In .Columns
            With cCol
               Select Case UCase(.Name)
                  Case "BANCOCTA" : .Width = 50
                  Case "DESCRIP" : .Width = 250
                  Case "TITULAR" : .Width = 250
                  Case Else : cCol.Visible = False
               End Select
            End With
         Next cCol
      End With

   End Sub

   'Private Sub btnAceptar_Click(sender As Object, e As EventArgs)
   '   '
   '   If Alta Then
   '      If Not IsNothing(CapturaDato(Cn, "Bancos", "Codigo", "Codigo = " & tbCodigo.Text)) Then
   '         MensajeTrad("CodExist")
   '         Exit Sub
   '      End If
   '   End If
   '   '
   '   Guardar(0)
   '   '
   'End Sub
   '
   'Private Sub btnAceptarCta_Click(sender As Object, e As EventArgs)
   '   '
   '   Dim Banco As Integer
   '   '
   '   If Alta Then
   '      With DataGridView1
   '         If .RowCount > 0 Then
   '            Banco = Val(.SelectedCells(.Columns("Codigo").Index).Value)
   '            If Not IsNothing(CapturaDato(Cn, "BancoCta", "BancoCta", "Banco = " & Banco & " AND BancoCta = '" & tbCtaBco.Text & "'")) Then
   '               MensajeTrad("CuentaExist")
   '               Exit Sub
   '            End If
   '         End If
   '      End With
   '   End If
   '   '
   '   Guardar(1)
   '   '
   'End Sub
   '
   Private Sub btnCancelar_Click(sender As Object, e As EventArgs)
      'ActivaCmd(0)
   End Sub
   '
   Private Sub btnCancelarCta_Click(sender As Object, e As EventArgs)
      'ActivaCmd2(0)
   End Sub
   '
   Private Sub DataGrid1_RowColChange(ByVal LastRow As Object, ByVal LastCol As Integer)
      'DataGrid1_Click()
   End Sub
   '
   Private Sub DataGrid2_RowColChange(ByVal LastRow As Object, ByVal LastCol As Integer)
      'DataGrid2_Click()
   End Sub
   '
   Private Sub btnAlta_Click(sender As Object, e As EventArgs) Handles btnAlta.Click
      Altamod(True)
   End Sub
   '
   Private Sub btnBaja_Click(sender As Object, e As EventArgs) Handles btnBaja.Click
      '
      Dim Cmd As New OleDb.OleDbCommand
      Dim Descrip, BancoCta As String
      '
      With DataGridView1
         If .RowCount = 0 Then
            MensajeTrad("NoHayRegAct")
            Exit Sub
         End If
         Descrip = .SelectedCells(.Columns("Descrip").Index).Value
         BancoCta = .SelectedCells(.Columns("BancoCta").Index).Value
         If Not IsNothing(CapturaDato(Cn, "ChCartera", "Numero", "Banco = " & Banco & " AND BancoCta = '" & BancoCta & "'")) Then
            MensajeTrad("CtaUtilizada")
         Else
            If Not IsNothing(CapturaDato(Cn, "BancosMov", "Numero", "Banco = " & Banco & " AND BancoCta = '" & BancoCta & "'")) Then
               MensajeTrad("CtaUtilizada")
            Else
               If MsgBox("Elimina " & Descrip, vbQuestion & vbYesNo) = vbYes Then
                  Cmd.Connection = Cn
                  Cmd.CommandText = "DELETE FROM BancoCta WHERE BancoCta = '" & BancoCta & "'"
                  Cmd.ExecuteNonQuery()
                  ActData()
               End If
            End If
         End If
      End With
      '
   End Sub
   '
   Private Sub btnModif_Click(sender As Object, e As EventArgs) Handles btnModif.Click
      Altamod(False)
   End Sub
   '
   Private Sub AltaMod(Alta As Boolean)
      '
      Dim BancoCta As String
      '
      If Alta Then
         BancoCta = ""
      Else
         With DataGridView1
            If .RowCount = 0 Then
               MensajeTrad("NoHayRegAct")
               Exit Sub
            End If
            BancoCta = .SelectedCells(.Columns("BancoCta").Index).Value
         End With
      End If
      '
      Dim Frm As New frmBancosCtasAM
      With frm
         .Banco = Banco
         .BancoCta = BancoCta
         .ShowDialog(Me)
      End With
      '
      ActData()
      '
   End Sub
   '
   'Private Sub btnCuentas_Click(sender As Object, e As EventArgs) Handles btnCuentas.Click
   '   '
   '   Dim Banco As Int32
   '   '
   '   With DataGridView1
   '      If .RowCount = 0 Then
   '         MensajeTrad("NoHayRegAct")
   '         Exit Sub
   '      End If
   '      Banco = .SelectedCells(.Columns("Codigo").Index).Value
   '   End With
   '   '
   '   With frmBancosCtasAM
   '      .Banco = Banco
   '      .ShowDialog(Me)
   '   End With
   '   '
   'End Sub
   '
   'Private Sub DataGrid1_DblClick()
   '   If DataGrid1.Row > -1 Then
   '      cmdEdicion_Click(0)
   '   End If
   'End Sub

   Private Sub tbBuscar_Change()
      ActData()
   End Sub

   'Private Sub DataGrid1_KeyPress(ByVal KeyAscii As Integer)
   '   tbBuscar.Focus()
   '   SendKeys(Chr(KeyAscii))
   'End Sub


   'Private Sub DataGrid2_Click()
   '   ActivaCmd2()
   'End Sub
   '

   '
  
   '
   Private Sub cboCtaCont_Change()
      'PintarCb(cboCtaCont, LastKey)
      'If cboCtaCont = "" Then
      ' CtaCont = ""
      'End If
   End Sub
   '
   Private Sub cboCtaCont_Click()
      'CtaCont = CapturaDato(Cn, "PlanCtas", "CtaCont", "Descrip = '" & cboCtaCont.Text & "'")
   End Sub
   '
   Private Sub frmBancos_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
      SetRegForm(Me)
   End Sub
   '
End Class