Public Class frmBancosMov
   '
   Public Concilia As Boolean
   '
   Dim Cmd As New OleDb.OleDbCommand
   Dim Trn As OleDb.OleDbTransaction
   '
   Dim Banco As Integer
   Dim Ctrl As Control
   Dim Alta As Boolean
   Dim TipoMovBco As Integer
   Dim Estado As Integer
   Dim cCtaBco As String
   '
   Dim FormLoad As Boolean = False
   '
   Const estEMIT = 1
   Const EstCONC = 2
   Const EstANUL = 3
   '
   Private Sub frmBancosMov_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      '
      GetRegForm(Me)
      '
      Cmd.Connection = Cn
      '
      ArmaComboItem(cboBanco, "Bancos", "Banco", "Nombre", "Nombre", , "Banco IN( SELECT DISTINCT Banco FROM BancosCtas)")
      With cboBanco
         If .Items.Count = 2 Then
            .SelectedIndex = 1
         End If
      End With
      '
      ArmaComboItem(cbTipoMov, "TipoMovBco", "TipoMovBco", , , "(Todos)")
      ArmaComboItem(cbEstado, "EstMovBco", "Estado", , "Estado", "(Todos)")
      '
      If Concilia Then
         cmdAlta.Visible = False
         cmdModif.Visible = False
         cmdAnular.Visible = False
      Else
         btnConciliar.Visible = False
      End If
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
   Private Sub frmBancosMov_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
      TabReturn(e.KeyChar)
   End Sub
   '
   Private Sub cbCuentaBco_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCuentaBco.SelectedIndexChanged
      'With Rs
      '   .Open("SELECT CtaCont FROM BancoCta WHERE Banco = " & Banco & " AND BancoCta = '" & cbCtaBco & "'", cn, adOpenForwardOnly, adLockReadOnly)
      '   If .EOF Then
      '      .Close()
      '      MensajeTrad("BcoCtaNoEnc")
      '      cbCuentaBco.ListIndex = -1
      '      Exit Sub
      '   Else
      If SisContable Then
         cCtaBco = CapturaDato(Cn, "BancosCtas", "CtaCont", "Banco = " & Banco & " AND BancoCta = '" & cbCuentaBco.Text & "'")
         If IsDBNull(cCtaBco) Then
            MensajeTrad("CtaBcoNoDef")
            cbCuentaBco.SelectedIndex = 0
            Exit Sub
         End If
      End If
      '
      ActData()
      '
   End Sub
   '
   Private Sub cbTipoMov_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbTipoMov.SelectedIndexChanged
      With cbTipoMov
         If .SelectedIndex > 0 Then
            TipoMovBco = .SelectedValue
         Else
            TipoMovBco = -1
         End If
      End With
      ActData()
   End Sub
   '
   Private Sub cbEstado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbEstado.SelectedIndexChanged
      With cbEstado
         If .SelectedIndex > 0 Then
            Estado = .SelectedValue
         Else
            Estado = -1
         End If
      End With
      ActData()
   End Sub
   '
   Private Sub chkTodas_CheckedChanged(sender As Object, e As EventArgs) Handles chkTodas.CheckedChanged
      dtpDesde.Enabled = Not chkTodas.Checked
      dtpHasta.Enabled = Not chkTodas.Checked
      ActData()
   End Sub
   '
   Sub ActData()
      '
      If Not FormLoad Then Exit Sub
      '
      Dim Filtro As String = ""
      '
      If tbNumero.Text <> "" Then
         '
         Filtro = " AND M.NroMovBco LIKE '%" & tbNumero.Text & "%'"
         '
      Else
         If TipoMovBco > -1 Then
            Filtro = " AND M.TipoMovBco = " & TipoMovBco
         End If
         '
         If Estado > -1 Then
            Filtro = Filtro & " AND M.Estado = " & Estado
         End If
         '
         If Not chkTodas.Checked Then
            Filtro = Filtro & " AND M.FechaAcr >= " & strFEC & Format(dtpDesde.Value, FormatFecha) & strFEC & _
                              " AND M.FechaAcr <= " & strFEC & Format(dtpHasta.Value, FormatFecha) & strFEC
         End If
         '
      End If
      '
      SetRegGrid(Me, DataGridView1)
      '
      LlenarGrid(DataGridView1, "SELECT M.Banco, M.BancoCta, M.TipoMovBco, T.TipoMov, T.Descrip, M.NroMovBco, " & _
                                " M.FechaEmi, M.FechaAcr, M.Debe, M.Haber, M.Estado, E.Descrip AS Est, " & _
                                " M.HojaBco, M.Detalle, BC.Nombre as BancoCh, CH.Titular " & _
                                "FROM BancosMov M LEFT JOIN ChCartera CH ON M.ChCartId = CH.ChCartId " & _
                                "                 LEFT JOIN Bancos BC ON CH.Banco = BC.Banco " & _
                                ", TipoMovBco T, EstMovBco E " & _
                                "WHERE M.Banco = " & Banco & " " & _
                                "  AND M.BancoCta = '" & cbCuentaBco.Text & "' " & _
                                "  AND M.Estado = E.Estado " & _
                                "  AND T.TipoMovBco = M.TipoMovBco " & _
                                Filtro & _
                                "ORDER BY M.FechaAcr, M.NroMovBco")
      '
      SetCols()
      '
      GetRegGrid(Me, DataGridView1)
      '
      ActivaCmd()
      '
   End Sub
   '
   Private Sub SetCols()
      '
      With DataGridView1
         For Each cCol As DataGridViewColumn In .Columns
            With cCol
               Select Case .Name
                  Case "Descrip" : .Width = 120 : .HeaderText = "T.Mov."
                  Case "NroMovBco" : .Width = 100 : .HeaderText = "Número"
                  Case "FechaEmi" : .Width = 100 : .HeaderText = "F.Emisión"
                  Case "FechaAcr" : .Width = 100 : .HeaderText = "F.Acredit."
                  Case "Debe" : .Width = 100 : .DefaultCellStyle.Format = "#0.00 "
                  Case "Haber" : .Width = 100 : .DefaultCellStyle.Format = "#0.00 "
                  Case "Est" : .Width = 60
                  Case "HojaBco" : .Width = 75 : .HeaderText = "Hoja Nº"
                  Case "Detalle" : .Width = 600
                  Case "BancoCh" : .HeaderText = "Bco.CH."
                  Case "Titular"
                  Case "Cliente"
                  Case Else
                     .Visible = False
               End Select
               'cCol.Caption = Traducir(cCol.Caption)
            End With
         Next cCol
      End With
      '
   End Sub
   '
   Private Sub ActivaCmd()
      '
      Dim lEnabl As Boolean = False
      Dim Est As Byte = 0
      Dim TMov As String = ""
      Dim BcoCh As String = ""
      '
      If Concilia Then
         Me.AcceptButton = btnConciliar
      End If
      '
      With DataGridView1
         If .RowCount > 0 Then
            Est = .SelectedCells(.Columns("Estado").Index).Value
            TMov = .SelectedCells(.Columns("TipoMov").Index).Value
            BcoCh = .SelectedCells(.Columns("BancoCh").Index).Value & ""
            lEnabl = True
         End If
      End With
      '
      cmdAlta.Enabled = cbCuentaBco.SelectedIndex > 0
      cmdAnular.Enabled = lEnabl
      '
      btnConciliar.Enabled = lEnabl And (Est <= estEMIT)
      cmdCancConc.Enabled = lEnabl And (Est = EstCONC)
      cmdModif.Enabled = lEnabl And (Est <= estEMIT)
      btnRechazar.Enabled = lEnabl And Est = estEMIT And TMov = "DP" And BcoCh <> ""
      '
   End Sub
   '
   Private Sub cboBanco_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboBanco.SelectedIndexChanged
      '
      With cboBanco
         If .SelectedIndex > 0 Then
            Banco = .SelectedValue
         Else
            Banco = 0
         End If
      End With
      '
      ArmaCombo(cbCuentaBco, "BancoCta", "BancosCtas", "BancoCta", "Banco = " & Banco, "BancoCta")
      '
      With cbCuentaBco
         If .Items.Count = 2 Then
            .SelectedIndex = 1
         End If
      End With
      '
      ActData()
      '
   End Sub
   '
   Private Sub cmdAlta_Click(sender As Object, e As EventArgs) Handles cmdAlta.Click
      AltaMod(True)
   End Sub
   '
   Private Sub cmdModif_Click(sender As Object, e As EventArgs) Handles cmdModif.Click
      AltaMod(False)
   End Sub
   '
   Private Sub btnConciliar_Click(sender As Object, e As EventArgs) Handles btnConciliar.Click
      AltaMod(False, False)
   End Sub
   '
   Private Sub btnRechazar_Click(sender As Object, e As EventArgs) Handles btnRechazar.Click
      AltaMod(False, False, True)
   End Sub
   '
   Private Sub AltaMod(Alta As Boolean, Optional Conciliar As Boolean = False, Optional Rechazar As Boolean = False)
      '
      Dim TipoMovBco As Byte = 0
      Dim NroMov As Long = 0
      '
      If Not Alta Then
         With DataGridView1
            If .RowCount > 0 Then
               TipoMovBco = .SelectedCells(.Columns("TipoMovBco").Index).Value
               NroMov = .SelectedCells(.Columns("NroMovBco").Index).Value
            End If
         End With
      End If
      '
      If Rechazar Then
         Dim Frm As New frmChRechAM
         With Frm
            .Banco = Banco
            .BancoCta = cbCuentaBco.Text
            .TipoMovBco = TipoMovBco
            .NroMovBco = NroMov
            .ShowDialog(Me)
         End With
      Else
         Dim Frm As New frmBancosMovAM
         With Frm
            .Concilia = Concilia
            .Alta = Alta
            .Banco = Banco
            .BancoCta = cbCuentaBco.Text
            .TipoMovBco = TipoMovBco
            .NroMovBco = NroMov
            .Rechazar = Rechazar
            .ShowDialog(Me)
         End With
      End If
      '
      ActData()
      '
   End Sub
   '
   Private Sub cmdAnular_Click(sender As Object, e As EventArgs) Handles cmdAnular.Click
      '
      Dim Banco As Int16
      Dim BancoCta As String
      Dim TipoMovBco As Byte
      Dim NroMovBco As Long
      Dim Descrip As String
      '
      With DataGridView1
         If .RowCount = 0 Then
            MensajeTrad("DSelItem")
            Exit Sub
         Else
            Banco = .SelectedCells(.Columns("Banco").Index).Value
            BancoCta = .SelectedCells(.Columns("BancoCta").Index).Value
            TipoMovBco = .SelectedCells(.Columns("TipoMovBco").Index).Value
            NroMovBco = .SelectedCells(.Columns("NroMovBco").Index).Value
            Descrip = .SelectedCells(.Columns("Detalle").Index).Value
         End If
      End With
      '
      If MsgConfirma("Anula Mov. " & Descrip & " Nº " & NroMovBco) Then
         AnulaMov(Banco, BancoCta, TipoMovBco, NroMovBco)
      End If
      '
   End Sub
   '
   Private Sub AnulaMov(Banco As Int16, BancoCta As String, TipoMovBco As Byte, NroMov As Long)
      '
      'On Error GoTo mError
      '
      Dim compCaja, TipoMov As String
      Dim ChCartId As Long
      '
      TipoMov = CapturaDato(Cn, "TipoMovBco", "TipoMov", "TipoMovBco = " & TipoMovBco)
      ChCartId = Val(CapturaDato(Cn, "BancosMov", "ChCartId", "Banco = " & Banco & " AND BancoCta = '" & BancoCta & "' AND TipoMovBco = " & TipoMovBco & " AND NroMovBco = " & NroMov) & "")
      '
      compCaja = TipoMov & "-" & Banco & "-" & _
                 BancoCta & "-" & NroMov
      '
      Trn = Cn.BeginTransaction
      '
      With Cmd
         .Transaction = Trn
         .CommandText = "UPDATE BancosMov SET " & _
                        " Estado = " & EstANUL & ", " & _
                        " Usuario = '" & Uid & "', " & _
                        " FechaMod = '" & Format(Now, FormatFechaHora) & "' " & _
                        "WHERE Banco = " & Banco & _
                        "  AND BancoCta = '" & BancoCta & "'" & _
                        "  AND TipoMovBco = " & TipoMovBco & _
                        "  AND NroMovBco = " & NroMov
         .ExecuteNonQuery()
         '
         If TipoMov = "CH" Then
            .CommandText = "UPDATE ChPropios SET " & _
                           " Estado = " & 0 & ", " & _
                           " Usuario = '" & Uid & "', " & _
                           " FechaMod = '" & Format(Now, FormatFechaHora) & "' " & _
                           "WHERE Banco = " & Banco & _
                           "  AND BancoCta = '" & BancoCta & "'" & _
                           "  AND TipoMovBco = " & TipoMovBco & _
                           "  AND ChPropNro = '" & NroMov & "'"
            .ExecuteNonQuery()
            '
         ElseIf TipoMov = "DP" Then
            If ChCartId <> 0 Then
               .CommandText = "UPDATE ChCartera SET " & _
                              " Estado = " & 0 & ", " & _
                              " Usuario = '" & Uid & "', " & _
                              " FechaMod = '" & Format(Now, FormatFechaHora) & "' " & _
                              " WHERE ChCartId = " & ChCartId
               .ExecuteNonQuery()
            End If
         End If
         '
         If Not BajaCaja(compCaja, , Trn) Then
            Err.Raise(1001)
         End If
         '
         If SisContable Then
            If Not BorraAsiento(compCaja, Trn) Then
               Err.Raise(1001)
            End If
         End If
         '
      End With
      '
      Trn.Commit()
      '
      ActData()
      '
      'mError:
      '     MsgBox(Err.Number & ": " & Err.Description & Chr(13) + Chr(10) & _
      '           Traducir("TransNComp"))
      '   cn.Rollback()
      '
   End Sub
   '
   Private Sub cmdCancConc_Click(sender As Object, e As EventArgs) Handles cmdCancConc.Click
      '
      If MsgConfirma("Cancela Conciliación") Then
         '
         Dim Banco As Int16
         Dim BancoCta As String
         Dim TipoMovBco As Byte
         Dim NroMov As Long
         '
         With DataGridView1
            If .RowCount = 0 Then
               MensajeTrad("DSelItem")
               Exit Sub
            Else
               Banco = .SelectedCells(.Columns("Banco").Index).Value
               BancoCta = .SelectedCells(.Columns("BancoCta").Index).Value
               TipoMovBco = .SelectedCells(.Columns("TipoMovBco").Index).Value
               NroMov = .SelectedCells(.Columns("NroMovBco").Index).Value
            End If
         End With
         Trn = Cn.BeginTransaction
         With Cmd
            .Transaction = Trn
            .CommandText = "UPDATE BancosMov SET " & _
                           " HojaBco = 0, " & _
                           " Estado = " & estEMIT & ", " & _
                           " Usuario = '" & Uid & "', " & _
                           " FechaMod = '" & Format(Now, FormatFechaHora) & "' " & _
                           "WHERE Banco = " & Banco & _
                           "  AND BancoCta = '" & BancoCta & "'" & _
                           "  AND TipoMovBco = " & TipoMovBco & _
                           "  AND NroMovBco = '" & NroMov & "'"
            .ExecuteNonQuery()
            '
            .CommandText = "UPDATE ChPropios SET " & _
                          " Estado = " & estEMIT & ", " & _
                          " Usuario = '" & Uid & "', " & _
                          " FechaMod = '" & Format(Now, FormatFechaHora) & "' " & _
                          "WHERE Banco = " & Banco & _
                          "  AND BancoCta = '" & BancoCta & "'" & _
                          "  AND ChPropNro = '" & NroMov & "'"
            .ExecuteNonQuery()
            '
            Trn.Commit()
         End With
         ActData()
      End If
   End Sub
   '
   Private Sub DataGridView1_MouseClick(sender As Object, e As MouseEventArgs) Handles DataGridView1.MouseClick
      ActivaCmd()
   End Sub
   '
   Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
      ActivaCmd()
   End Sub
   '
   Private Sub DataGridView1_KeyUp(sender As Object, e As KeyEventArgs) Handles DataGridView1.KeyUp
      ActivaCmd()
   End Sub
   '
   'Private Sub DataGrid1_DblClick()
   '   If Adodc1.Recordset.RecordCount > 0 Then
   '      If Concilia Then
   '         cmdConciliar_Click()
   '      Else
   '         cmdEdicion_Click()
   '      End If
   '   End If
   'End Sub
   '
   Private Sub dtp_ValueChanged(sender As Object, e As EventArgs) Handles dtpDesde.ValueChanged, dtpHasta.ValueChanged
      ActData()
   End Sub
   '
   Private Sub tbNumero_TextChanged(sender As Object, e As EventArgs) Handles tbNumero.TextChanged
      ActData()
   End Sub
   '
   Private Sub cmdSalir_Click(sender As Object, e As EventArgs) Handles cmdSalir.Click
      Me.Close()
   End Sub
   '
   Private Sub frmBancosMov_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
      SetRegGrid(Me, DataGridView1)
      SetRegForm(Me)
   End Sub
   '
End Class