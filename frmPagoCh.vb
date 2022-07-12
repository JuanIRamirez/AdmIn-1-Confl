Public Class frmPagoCh
   '
   Public TablaAct As String
   Public Total As Double
   Public Titulo As String = "Pagos"
   Public Subtitulo As String = "Cheques"
   Public Cobro As Boolean = False
   '
   Dim Trn As OleDb.OleDbTransaction
   Dim Rs As New OleDb.OleDbCommand
   Dim DR As OleDb.OleDbDataReader
   '
   Dim Banco As Integer
   Dim CtaBanco As String
   Dim CtaCont As String
   Dim Alta As Boolean
   Dim TipoMov As Byte
   '
   Private Sub frmLiqProCh_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      '
      If Titulo <> "" Then
         Me.Text = Titulo
      End If
      '
      If Subtitulo <> "" Then
         Me.Text = Me.Text & ": " & Subtitulo
      End If
      '
      If TablaAct = "" Then
         TablaAct = "ChLiqProTmp"
      End If
      '
      TipoMov = Val(CapturaDato(Cn, "TipoMovBco", "TipoMovBco", "TipoMov = 'CH'") & "")
      '
      If TipoMov = 0 Then
         Mensaje("TipoMovBco_NoDef")
         DeshabForm(Me)
      End If
      '
      Rs.Connection = Cn
      '
      ArmaCboBancos()
      '
      dtpFecha.Value = Today
      '
      ActData()
      '
   End Sub
   '
   Private Sub ArmaCboBancos()
      '
      If optCartera.Checked Then
         If Cobro Then
            ArmaComboItem(cbBanco, "Bancos", "Banco", "Nombre", "Nombre", , "Banco <> 0")
         Else
            ArmaComboItem(cbBanco, "Bancos B, ChCartera C", "B.Banco", "B.Nombre", "Nombre", , "C.Estado = 0 AND C.Banco = B.Banco", , , True)
         End If
      Else
         ArmaComboItem(cbBanco, "Bancos", "Banco", "Nombre", "Nombre", , "Banco IN( SELECT DISTINCT Banco FROM BancosCtas)")
      End If
      '
      If cbBanco.Items.Count = 2 Then cbBanco.SelectedIndex = 1
      '
   End Sub
   '
   Private Sub cbCuenta_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbCuenta.TextChanged
      CaptCtaTitNro()
   End Sub
   '
   Private Sub cbCuenta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCuenta.SelectedIndexChanged
      CaptCtaTitNro()
   End Sub
   '
   Private Sub CaptCtaTitNro()
      '
      CtaBanco = cbCuenta.Text
      '
      If optCartera.Checked Then
         CtaCont = ""
         Exit Sub
      End If
      '
      ArmaCombo(cbTitular, "Titular", "BancosCtas", , "Banco = " & Banco & " AND BancoCta = '" & CtaBanco & "'", , "")
      '
      If SisContable Then
         CtaCont = CapturaDato(Cn, "BancosCtas", "CtaCont", "Banco = " & Banco & " AND BancoCta = '" & CtaBanco & "'") & ""
         If CtaCont = "" Then
            MensajeTrad("CtaBcoNoDef")
            cbCuenta.SelectedIndex = -1
            Exit Sub
         End If
      End If
      '
      ArmaCombo(cbNumero, "ChPropNro", "ChPropios", "ChPropNro", "Banco = " & Banco & " AND BancoCta = '" & CtaBanco & "' AND Estado = 0", , "")
      '
   End Sub
   '
   Private Sub cmdBaja_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBaja.Click
      With DataGridView1
         If .RowCount > 0 Then
            If .SelectedRows.Count > 0 Then
               '
               Dim Origen As String = .SelectedCells(.Columns("Origen").Index).Value
               Dim Banco As Int16 = .SelectedCells(.Columns("Banco").Index).Value
               Dim BancoCta As String = .SelectedCells(.Columns("Cuenta").Index).Value
               Dim Numero = .SelectedCells(.Columns("Numero").Index).Value
               '
               If DaDeBaja("Cheque Nº: " & .SelectedCells(.Columns("Numero").Index).Value) Then
                  With Rs
                     .CommandText = "DELETE FROM " & TablaAct & " " & _
                                    "WHERE Origen = '" & Origen & "'" & _
                                    "  AND Banco = " & Banco & _
                                    "  AND Cuenta = '" & BancoCta & "'" & _
                                    "  AND Numero = " & Numero
                     .ExecuteNonQuery()
                  End With
                  ActData()
               End If
            End If
         End If
      End With
   End Sub
   '
   Private Sub cbDescBco_Change()
      'PintarCb(cbDescBco, LastKey)
   End Sub
   '
   Private Sub Form_KeyPress(ByVal KeyAscii As Integer)
      'TabReturn(KeyAscii, True)
   End Sub
   '
   Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
      '
      Dim Numero As String
      Dim Fecha As Date
      '
      Total = 0
      '
      If cbBanco.Text = "" Or Banco = 0 Then
         MensajeTrad("DIBanco")
         cbBanco.Focus()
         Exit Sub
      End If
      '
      If cbNumero.Text = "" Then
         MensajeTrad("DINroCheque")
         cbNumero.Focus()
         Exit Sub
      End If
      '
      If cbCuenta.Text = "" Then
         MensajeTrad("DICuenta")
         With cbCuenta
            If .Enabled Then
               .Focus()
            End If
         End With
         Exit Sub
      End If
      '
      If Val(cbImporte.Text) = 0 Then
         MensajeTrad("DII>0")
         cbImporte.Focus()
         Exit Sub
      End If
      '
      Numero = cbNumero.Text
      '
      Try
         '
         Trn = Cn.BeginTransaction
         '
         If IsNothing(CapturaDato(Cn, TablaAct, "Numero", "Origen = '" & IIf(optPropio.Checked, "P", "C") & "' AND Banco = " & Banco & " AND Cuenta = '" & CtaBanco & "' AND Numero = '" & Numero & "'", , , , Trn)) Then
            If Alta Then
               If optPropio.Checked Then
                  If Not IsNothing(CapturaDato(Cn, "BancosMov", "NroMovBco", "Banco = " & Banco & " AND BancoCta = '" & CtaBanco & "' AND TipoMovBco = " & TipoMov & " AND NroMovBco = '" & Numero & "'", , , , Trn)) Then
                     Err.Raise(1001, , Traducir("MovBcoExiste", , Trn))
                  End If
               End If
            Else
               Err.Raise(1001, , Traducir("ChNoEnc", , Trn))
               Exit Sub
            End If
            '
            If optCartera.Checked Then
               If Cobro Then
                  If Not IsNothing(CapturaDato(Cn, "ChCartera", "ChCartNro", "Banco = " & Banco & " AND BancoCta = '" & CtaBanco & "' AND ChCartNro = '" & Numero & "'", , , , Trn)) Then
                     Err.Raise(1001, , Traducir("ChEnCartera", , Trn))
                  End If
               End If
            End If
            '
         Else
            If Alta Then
               Err.Raise(1001, , Traducir("ChYaIng", , Trn))
               Exit Sub
            End If
         End If
         '
         Fecha = IIf(optPropio.Checked Or Cobro, dtpFecha.Value, cbFecha.Text)
         '
         With Rs
            .Transaction = Trn
            If Alta Then
               .CommandText = "INSERT INTO " & TablaAct & "( DescBco, Origen, Banco, Cuenta, Titular, Numero, Fecha, Importe, CtaCont, Usuario) " & _
                              "VALUES ('" & cbBanco.Text & "', " & _
                                      "'" & IIf(optPropio.Checked, "P", "C") & "', " & _
                                            Banco & ", " & _
                                      "'" & CtaBanco & "', " & _
                                      "'" & cbTitular.Text & "', " & _
                                      "'" & Numero & "', " & _
                                      "'" & Format(Fecha, FormatFecha) & "', " & _
                                            Val(cbImporte.Text) & ", " & _
                                      "'" & CtaCont & "', " & _
                                      "'" & Uid & "')"
            Else
               .CommandText = "UPDATE " & TablaAct & " SET " & _
                              " DescBco = '" & cbBanco.Text & "', " & _
                              " Titular = '" & cbTitular.Text & "', " & _
                              " Fecha = '" & Format(Fecha, FormatFecha) & "', " & _
                              " Importe = " & Val(cbImporte.Text) & ", " & _
                              " CtaCont = '" & CtaCont & "', " & _
                              " Usuario = '" & Uid & "' " & _
                              "WHERE Origen = '" & IIf(optPropio.Checked, "P", "C") & "' " & _
                              "  AND Banco = " & Banco & _
                              "  AND Cuenta = '" & CtaBanco & "' " & _
                              "  AND Numero = '" & Numero & "'"
            End If
            '
            .ExecuteNonQuery()
            '
         End With
         '
         Trn.Commit()
         '
         ActivaCtrl(False)
         ActData()
         '
      Catch ex As Exception
         If Err.Number = 1001 Then
            Mensaje(Err.Description)
         Else
            Dim st As New StackTrace(True)
            MensageError(st, "frmPagoCh")
         End If
         Trn.Rollback()
      End Try
      '
   End Sub
   '
   Private Sub cmdGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGuardar.Click
      '
      With DataGridView1
         If .RowCount = 0 Then
            MensajeTrad("DICheques")
            Exit Sub
         Else
            Total = CapturaDato(Cn, TablaAct, "SUM(Importe)", "Usuario = '" & Uid & "'")
            Me.Close()
         End If
      End With
      '
   End Sub
   '
   Private Sub cmdAlta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAlta.Click
      LimpiaCtrl(Me)
      Alta = True
      ActivaCtrl(True)
      With cbBanco
         If .Enabled Then
            If .Items.Count = 1 Then .SelectedIndex = 0
            .Focus()
         End If
      End With
      cbBanco.Text = ""
      cbNumero.Text = ""
      cbImporte.Text = ""
      cbTitular.Text = ""
      cbCuenta.Text = ""
   End Sub
   '
   Private Sub cmdCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCerrar.Click
      '
      Dim Cerrar As Boolean
      '
      If Me.DataGridView1.RowCount > 0 Then
         If MsgConfirma("Cancela cheques ingresados") Then
            Trn = Cn.BeginTransaction
            With Rs
               .Transaction = Trn
               .CommandText = "DELETE FROM " & TablaAct & " WHERE Usuario = '" & Uid & "'"
               .ExecuteNonQuery()
            End With
            Trn.Commit()
            Cerrar = True
         End If
      Else
         Cerrar = True
      End If
      '
      If Cerrar Then
         Total = 0
         Me.Close()
      End If
      '
   End Sub
   '
   Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
      ActivaCtrl(False)
      LimpiaCtrl(Me)
      Actualizar()
   End Sub
   '
   Private Sub cmdEdicion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdicion.Click
      Alta = False
      ActivaCtrl(True)
   End Sub
   '
   Private Sub DataGridView1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyUp
      Actualizar()
   End Sub
   '
   Private Sub DataGridView1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridView1.MouseClick
      Actualizar()
   End Sub
   '
   Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
      Actualizar()
   End Sub
   '
   Private Sub Actualizar()
      With DataGridView1
         If .RowCount > 0 Then
            optPropio.Checked = .SelectedCells(.Columns("Origen").Index).Value = "P"
            optCartera.Checked = .SelectedCells(.Columns("Origen").Index).Value = "C"
            PosCboItem(cbBanco, .SelectedCells(.Columns("Banco").Index).Value)
            PosCombo(cbCuenta, .SelectedCells(.Columns("Cuenta").Index).Value)
            PosCombo(cbTitular, .SelectedCells(.Columns("Titular").Index).Value)
            If optPropio.Checked Then
               cbNumero.Text = .SelectedCells(.Columns("Numero").Index).Value
               cbImporte.Text = .SelectedCells(.Columns("Importe").Index).Value
               dtpFecha.Value = .SelectedCells(.Columns("Fecha").Index).Value
            Else
               If Cobro Then
                  cbCuenta.Text = .SelectedCells(.Columns("Cuenta").Index).Value
                  cbTitular.Text = .SelectedCells(.Columns("Titular").Index).Value
                  cbNumero.Text = .SelectedCells(.Columns("Numero").Index).Value
                  cbImporte.Text = .SelectedCells(.Columns("Importe").Index).Value
                  dtpFecha.Value = .SelectedCells(.Columns("Fecha").Index).Value
               Else
                  PosCombo(cbNumero, .SelectedCells(.Columns("Numero").Index).Value)
                  PosCombo(cbFecha, .SelectedCells(.Columns("Fecha").Index).Value)
               End If
            End If
         End If
      End With
      '
      ActivaCtrl(False)
      '
   End Sub
   '
   Private Sub cbBanco_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbBanco.SelectedIndexChanged
      With cbBanco
         If .SelectedIndex > 0 Then
            Banco = .SelectedValue
         Else
            Banco = 0
         End If
      End With
      ArmaCombos2()
   End Sub
   '
   Private Sub ArmaCombos2()
      '
      cbCuenta.Items.Clear()
      cbTitular.Items.Clear()
      cbNumero.Items.Clear()
      cbImporte.Items.Clear()
      cbFecha.Items.Clear()
      '
      If optCartera.Checked Then
         '
         If Not Cobro Then
            With Rs
               .CommandText = "SELECT * FROM ChCartera WHERE Banco = " & Banco & " AND Estado = 0"
               DR = .ExecuteReader
            End With
            '
            With DR
               Do While .Read
                  cbCuenta.Items.Add(!BancoCta)
                  cbTitular.Items.Add(!Titular & "")
                  cbNumero.Items.Add(!ChCartNro)
                  cbImporte.Items.Add(Format(!Importe, "Fixed"))
                  cbFecha.Items.Add(!FechaDif)
               Loop
               .Close()
            End With
         End If
         '
      Else
         cbCuenta.Items.Clear()
         With Rs
            .CommandText = "SELECT * FROM BancosCtas WHERE Banco = " & Banco & " ORDER BY BancoCta"
            DR = .ExecuteReader
         End With
         '
         With DR
            Do While .Read
               cbCuenta.Items.Add(!BancoCta)
            Loop
            If cbCuenta.Items.Count = 1 Then
               cbCuenta.SelectedIndex = 0
            End If
            .Close()
         End With
      End If
   End Sub
   '
   Private Sub ActData()
      '
      LlenarGrid(DataGridView1, "SELECT * FROM " & TablaAct & " WHERE Usuario = '" & Uid & "'")
      '
      SetCols()
      '
      Actualizar()
      '
   End Sub
   '
   Private Sub SetCols()
      '
      With DataGridView1
         For Each Col As DataGridViewColumn In .Columns
            With Col
               Select Case UCase(.Name)
                  Case "USUARIO" : .Visible = False
                  Case "BANCO" : .Visible = False
                  Case "ORIGEN" : .Width = 50
                  Case "BANCOCTA" : .Width = 100
                  Case "FECHA" : .Width = 100
                  Case "TITULAR" : .Width = 200
                  Case "IMPORTE" : .Width = 100 : .DefaultCellStyle.Format = "#,##0.00 " : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
               End Select
            End With
         Next Col
      End With
      '
   End Sub
   '
   Private Sub ActivaCtrl(ByVal Modo As Boolean)
      '
      Dim cbs As ComboBoxStyle
      '
      cmdAlta.Enabled = Not Modo
      cmdBaja.Enabled = Not Modo
      cmdEdicion.Enabled = Not Modo
      '
      cmdGuardar.Enabled = Not Modo
      cmdCerrar.Enabled = Not Modo
      cmdAceptar.Enabled = Modo
      cmdCancelar.Enabled = Modo
      '
      optPropio.Enabled = Modo And Alta And Not Cobro
      optCartera.Enabled = Modo And Alta
      '
      cbBanco.Enabled = Modo
      cbCuenta.Enabled = Modo
      cbTitular.Enabled = Modo
      cbNumero.Enabled = Modo
      cbImporte.Enabled = Modo
      cbFecha.Enabled = Modo And optCartera.Checked And Not Cobro
      dtpFecha.Enabled = Modo And (optPropio.Checked Or Cobro)
      '
      If optPropio.Checked Or Cobro Then
         cbs = ComboBoxStyle.DropDown
      Else
         cbs = ComboBoxStyle.DropDownList
      End If
      '
      cbCuenta.DropDownStyle = cbs
      cbTitular.DropDownStyle = cbs
      cbNumero.DropDownStyle = cbs
      cbImporte.DropDownStyle = cbs
      '
      cbFecha.Visible = optCartera.Checked And Not Cobro
      dtpFecha.Visible = optPropio.Checked Or Cobro
      '
   End Sub
   '
   Private Sub optCartera_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optCartera.CheckedChanged, optPropio.CheckedChanged
      ArmaCboBancos()
      ActivaCtrl(True)
   End Sub
   '
   Private Sub tbImporte_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
      SoloNumeros(e.KeyChar, True)
   End Sub
   '
   Private Sub tbImporte_LostFocus()
      'tbImporte = Format(Val(tbImporte), "Fixed")
   End Sub
   '
   Private Sub cbNumero_Change()
      'PintarCb(cbNumero, LastKey)
   End Sub
   '
   Private Sub cbNumero_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbNumero.SelectedIndexChanged
      If optCartera.Checked Then
         cbCuenta.SelectedIndex = cbNumero.SelectedIndex
         cbImporte.SelectedIndex = cbNumero.SelectedIndex
         cbTitular.SelectedIndex = cbNumero.SelectedIndex
         cbFecha.SelectedIndex = cbNumero.SelectedIndex
      End If
   End Sub
   '
   Private Sub cbImporte_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbImporte.SelectedIndexChanged
      cbNumero.SelectedIndex = cbImporte.SelectedIndex
   End Sub
   '
   Private Sub tbNumero_KeyPress(sender As Object, e As KeyPressEventArgs)
      SoloNumeros(e.KeyChar)
   End Sub
   '
   Private Sub frm_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
      SetRegForm(Me)
   End Sub
   '
End Class