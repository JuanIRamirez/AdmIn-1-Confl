Public Class frmCatGcias
   '
   Public nCodigo As Integer
   '
   Dim Trn As OleDb.OleDbTransaction
   Dim Cmd As New OleDb.OleDbCommand
   Dim Drd As OleDb.OleDbDataReader
   '
   Dim Alta As Boolean
   Dim Ctrl As Control
   '
   Private Sub frmCatGcias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      '
      GetRegForm(Me)
      TraducirForm(Me)
      '
      IniTb()
      '
      Me.Text = Me.Text & " - " & IIf(nCodigo = 0, "Alta", "Edición")
      '
      Cmd.Connection = Cn
      '
      ActData()
      '
   End Sub
   '
   Private Sub frmCatGcias_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
      TabReturn(e.KeyChar)
   End Sub
   '
   Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
      ActivaCampos(False)
   End Sub
   '
   Private Sub IniTb()

      Dim Ctrl As Control

      If nCodigo = 0 Then   'Alta.
         For Each Ctrl In Me.Controls
            If TypeOf Ctrl Is TextBox Then
               Ctrl.Text = ""
            End If
         Next Ctrl
         tbCodigo.Enabled = True
      Else
         With Cmd
            .CommandText = "SELECT * FROM CatGcias WHERE Codigo = " & nCodigo
            Drd = .ExecuteReader
         End With
         With Drd
            If .Read Then
               tbCodigo.Text = !Codigo
               tbDescrip.Text = !Descrip
               tbAbrev.Text = !Abrev
               tbAlicuota.Text = Format(!Alicuota, "Fixed")
               tbMinImp.Text = Format(!MinimoImp, "Fixed")
               tbRetMin.Text = Format(!RetMinima, "Fixed")
            Else
               .Close()
               MensajeTrad("CodNoEnc")
               Me.Close()
            End If
            .Close()
         End With
         tbCodigo.Enabled = False
         'btnCancelar.Enabled = False
         'btnCerrar.Cancel = True
      End If
      '
   End Sub
   '
   Sub ActData()
      '
      LlenarGrid(DataGridView1, "SELECT * FROM CatGcias ORDER BY Codigo")
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
                  Case "CODIGO" : .Width = 50
                  Case "DESCRIP" : .Width = 300 : .HeaderText = "Descripción"
                  Case "ABREV" : .Width = 100 : .HeaderText = "Desc.Abrev."
                  Case "ALICUOTA"
                  Case "MINIMOIMP" : .HeaderText = "Min.Imp."
                  Case "RETMINIMA" : .HeaderText = "Ret.Min."
                  Case Else : .Visible = False
               End Select
            End With
         Next Col
      End With
   End Sub
   '
   Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick, DataGridView1.CellClick
      Datagrid_Click()
   End Sub
   '
   Private Sub DataGridView1_KeyUp1(sender As Object, e As KeyEventArgs) Handles DataGridView1.KeyUp
      Datagrid_Click()
   End Sub
   '
   Private Sub Datagrid_Click()
      With DataGridView1
         If .RowCount > 0 Then
            '
            tbCodigo.Text = .SelectedCells(.Columns("Codigo").Index).Value
            tbDescrip.Text = .SelectedCells(.Columns("Descrip").Index).Value
            tbAbrev.Text = .SelectedCells(.Columns("Abrev").Index).Value
            tbAlicuota.Text = .SelectedCells(.Columns("Alicuota").Index).Value
            tbMinImp.Text = .SelectedCells(.Columns("MinimoImp").Index).Value
            tbRetMin.Text = .SelectedCells(.Columns("RetMinima").Index).Value
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
   Private Sub btnAlta_Click(sender As Object, e As EventArgs) Handles btnAlta.Click
      Alta = True
      Limpiacampos()
      ActivaCampos(True)
      tbCodigo.Focus()
   End Sub
   '
   Private Sub btnModif_Click(sender As Object, e As EventArgs) Handles btnModif.Click
      Modif()
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
   '
   Private Sub ActivaCampos(Modo As Boolean)
      '
      Dim lEnabl As Boolean = DataGridView1.RowCount > 0
      '
      btnAlta.Enabled = Not Modo
      btnModif.Enabled = Not Modo And lEnabl
      btnBaja.Enabled = Not Modo And lEnabl
      DataGridView1.Enabled = Not Modo
      '
      btnAceptar.Enabled = Modo
      btnCancelar.Enabled = Modo
      '
      tbCodigo.Enabled = IIf(Alta, Modo, False)
      tbDescrip.Enabled = Modo
      tbAbrev.Enabled = Modo
      tbAlicuota.Enabled = Modo
      tbMinImp.Enabled = Modo
      tbRetMin.Enabled = Modo
      '
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
   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      '
      'Dim cEmite As String
      'Dim cRecibe As String
      '
      'On Error GoTo mError
      '
      If Not ValTb() Then
         Exit Sub
      End If
      '
      Trn = Cn.BeginTransaction
      '
      With Cmd
         '
         .Transaction = Trn
         '
         If Alta Then
            .CommandText = "INSERT INTO CatGcias( Codigo, Descrip, Abrev, Alicuota, MinimoImp, RetMinima, Usuario, FechaMod) " & _
                           "VALUES(" & Val(tbCodigo.Text) & ", " & _
                                 "'" & tbDescrip.Text & "', " & _
                                 "'" & tbAbrev.Text & "', " & _
                                       Val(tbAlicuota.Text) & ", " & _
                                       Val(tbMinImp.Text) & ", " & _
                                       Val(tbRetMin.Text) & ", " & _
                                 "'" & Uid & "', " & _
                                 "'" & Format(Now, FormatFechaHora) & "')"
         Else
            .CommandText = "UPDATE CatGcias SET " & _
                           " Descrip = '" & tbDescrip.Text & "', " & _
                           " Abrev = '" & tbAbrev.Text & "', " & _
                           " Alicuota = " & Val(tbAlicuota.Text) & ", " & _
                           " MinimoImp = " & Val(tbMinImp.Text) & ", " & _
                           " RetMinima = " & Val(tbRetMin.Text) & ", " & _
                           " Usuario = '" & Uid & "', " & _
                           " FechaMod = '" & Format(Now, FormatFechaHora) & "' " & _
                           "WHERE Codigo = " & Val(tbCodigo.Text)
         End If
         '
         .ExecuteNonQuery()
         '
         GuardarAudit(IIf(Alta, "Alta", "Modificación") & " de Cat. Ganancias", "Cat. (" & tbCodigo.Text & ") " & tbDescrip.Text, Me.Name, "Guardar", Trn)
         '
         Trn.Commit()
         '
      End With
      '
      ActivaCampos(False)
      ActData()
      '
      Exit Sub
      '
mError:
      MsgBox("Error: " & Err.Number & " - " & Err.Description)
      '
   End Sub
   '
   Private Function ValTb() As Boolean
      '
      ValTb = True
      '
      If tbCodigo.Text = 0 Then
         MensajeTrad("DebIngCod")
         tbCodigo.Focus()
         ValTb = False
      Else
         If Alta Then
            If IsNothing(CapturaDato(Cn, "CatGcias", "Descrip", "Codigo = " & nCodigo)) Then
               'Ok.
            Else
               MensajeTrad("CodExist")
               tbCodigo.Focus()
               ValTb = False
            End If
         End If
      End If
      '
      If ValTb Then
         If tbDescrip.Text = "" Then
            MensajeTrad("DebIngDesc")
            tbDescrip.Focus()
            ValTb = False
         End If
      End If
      '
   End Function
   '
   Private Sub Form_LostFocus()
      Me.Show()
   End Sub

   Private Sub tbNum_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbAlicuota.KeyPress, tbMinImp.KeyPress, tbRetMin.KeyPress
      SoloNumeros(e.KeyChar, True)
   End Sub
   '   
   Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
      Me.Close()
   End Sub

   Private Sub Form_Unload(Cancel As Integer)
      SetRegForm(Me)
   End Sub
   '

   Private Sub btnBaja_Click(sender As Object, e As EventArgs) Handles btnBaja.Click

   End Sub
   '
End Class