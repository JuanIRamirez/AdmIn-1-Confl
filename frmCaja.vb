Public Class frmCaja
   '
   Dim Trn As OleDb.OleDbTransaction
   Dim Cmd As New OleDb.OleDbCommand
   Dim Drd As OleDb.OleDbDataReader
   Dim Cm2 As New OleDb.OleDbCommand
   '
   Dim Caja As Int16 = 0
   Dim cmpInt As String = ""
   Dim cUid As String = ""
   Dim Ctrl As Control
   Dim Alta As Boolean
   Dim cTipoMov As String
   Dim FormLoad As Boolean
   '
   Private Sub frmCaja_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      '
      GetRegForm(Me)
      '
      TraducirForm(Me)
      '
      ArmaComboItem(cbCaja, "Cajas", "Caja", , , "(Todas)")
      ArmaCombo(cbUsuario, "Usuario", "Caja", "Usuario", "", , "(Todos)", True)
      ArmaCombo(cbComprob, "Descrip", "CompInt", "Descrip", , , "(Todos)")
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
   Private Sub frmCaja_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
      TabReturn(e.KeyChar)
   End Sub
   '
   Private Sub cbCaja_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCaja.SelectedIndexChanged
      Caja = CapturaDato(Cn, "Cajas", "Caja", "Descrip = '" & Me.cbCaja.Text & "'")
      ActData()
   End Sub
   '
   Private Sub cbUsuario_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbUsuario.SelectedIndexChanged
      With cbUsuario
         If .SelectedIndex > 0 Then
            cUid = cbUsuario.Text
         Else
            cUid = ""
         End If
      End With
      ActData()
   End Sub
   '
   Private Sub cbComprob_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbComprob.SelectedIndexChanged
      cmpInt = CapturaDato(Cn, "CompInt", "Codigo", "Descrip = '" & cbComprob.Text & "'")
      ActData()
   End Sub
   '
   Private Sub chkTodas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodas.CheckedChanged
      dtpDesde.Enabled = Not chkTodas.Checked
      dtpHasta.Enabled = Not chkTodas.Checked
      ActData()
   End Sub
   '
   Private Sub dtpFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDesde.ValueChanged
      ActData()
   End Sub
   '
   Sub ActData()
      '
      Dim cWhere As String = ""
      '
      If Not FormLoad Then Exit Sub
      '
      If Caja > 0 Then
         cWhere = " WHERE Caja.Caja = " & Caja & " "
      End If
      '
      If Not chkTodas.Checked Then
         cWhere = IIf(cWhere = "", " WHERE", cWhere & " AND") & " Fecha >= '" & Format(dtpDesde.Value, FormatFecha) & "' AND Fecha <= '" & Format(dtpHasta.Value, FormatFecha2359) & "' "
      End If
      '
      If cmpInt <> "" Then
         cWhere = IIf(cWhere = "", " WHERE", cWhere & " AND") & " Comprob LIKE '" & cmpInt & "%' "
      End If
      '
      If cUid <> "" Then
         cWhere = IIf(cWhere = "", " WHERE", cWhere & " AND") & " Usuario = '" & cUid & "' "
      End If
      '
      If tbDetalle.Text <> "" Then
         cWhere = IIf(cWhere = "", " WHERE", cWhere & " AND") & " (Detalle LIKE '%" & tbDetalle.Text & "%' OR Nombre LIKE '%" & tbDetalle.Text & "%') "
      End If
      '
      If Val(tbNumero.Text) <> 0 Then
         cWhere = IIf(cWhere = "", " WHERE", cWhere & " AND") & " (Comprob LIKE '%" & tbNumero.Text & "%' OR MovRec = " & Val(tbNumero.Text) & ") "
      End If
      '
      If Val(tbImporte.Text) <> 0 Then
         cWhere = IIf(cWhere = "", " WHERE", cWhere & " AND") & " (Entrada = " & Val(tbImporte.Text) & " OR Salida = " & Val(tbImporte.Text) & ") "
      End If
      '
      SetRegGrid(Me, DataGridView1)
      '
      LlenarGrid(DataGridView1, "SELECT Fecha, Comprob, fPago, Caja, Nombre, " & _
                                "       Detalle, Entrada, Salida, MovRec, SaldoRec, Cuenta, Usuario " & _
                                "FROM Caja " & cWhere & _
                                "ORDER BY Fecha, FechaMod")
      '
      SetCols()
      GetRegGrid(Me, DataGridView1)
      '
      ActivaCmd()
      '
   End Sub
   '
   Private Sub SetCols()
      '
      With DataGridView1
         For Each Col As DataGridViewColumn In .Columns
            With Col
               Select Case UCase(.Name)
                  Case "FECHA" : .Width = 100
                  Case "COMPROB" : .Width = 120
                  Case "FPAGO" : .Width = 40 : .HeaderText = "FP"
                  Case "CAJA" : .Width = 50
                  Case "NOMBRE" : .Width = 300
                  Case "DETALLE" : .Width = 300
                  Case "ENTRADA" : .Width = 115   'cCol.NumberFormat = "Fixed"
                  Case "SALIDA" : .Width = 115   'cCol.NumberFormat = "Fixed"
                  Case "USUARIO" : .Width = 100
                  Case "MOVREC" : .Width = 100
                  Case "SALDOREC" : .Width = 115 ': cCol.NumberFormat = "Fixed"
                  Case Else : .Visible = False
               End Select
            End With
         Next Col
      End With
      '
   End Sub
   '
   Private Sub ActivaCmd()
      If DataGridView1.RowCount = 0 Then
         cmdEdicion.Enabled = False
         cmdBaja.Enabled = False
      Else
         cmdEdicion.Enabled = True And LGR
         cmdBaja.Enabled = True And LGR
      End If
   End Sub
   '
   Private Sub cmdAlta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAlta.Click
      AltaMod(True)
   End Sub
   '
   Private Sub cmdEdicion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdicion.Click
      AltaMod(False)
   End Sub
   '
   Private Sub cmdCajaRec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCajaRec.Click
      AltaMod(True, True)
   End Sub
   '
   Private Sub AltaMod(ByVal Alta As Boolean, Optional ByVal aRecuperar As Boolean = False)
      '
      Dim Caja As Int16
      Dim Comprob As String = ""
      Dim fPago As String = ""
      Dim Cuenta As String = ""
      Dim Usuario As String = ""
      Dim Fecha As Date
      '
      If Not Alta Then
         With DataGridView1
            If .RowCount = 0 Then
               Exit Sub
            Else
               Caja = .SelectedCells(.Columns("Caja").Index).Value
               Comprob = .SelectedCells(.Columns("Comprob").Index).Value
               Fecha = .SelectedCells(.Columns("Fecha").Index).Value
               fPago = .SelectedCells(.Columns("fPago").Index).Value
               Cuenta = .SelectedCells(.Columns("Cuenta").Index).Value & ""
               Usuario = .SelectedCells(.Columns("Usuario").Index).Value
               '
               If Comprob.Substring(0, 2) <> "MN" Then
                  MensajeTrad("CajaAutNoMod")
                  Exit Sub
               End If
               '
               If Fecha < Today Then
                  MensajeTrad("Caja Cerrada")
                  Exit Sub
               End If
               '
            End If
         End With
      End If
      '
      If FechaIncorrecta() Then
         Exit Sub
      End If
      '
      If aRecuperar Then
         With frmCajaRec
            .Alta = Alta
            If Not Alta Then
               .Caja = Caja
               .Comprob = Comprob
               .fPago = fPago
               .Cuenta = Cuenta & ""
            End If
            .ShowDialog(Me)
         End With
      Else
         If Not Alta Then
            If Usuario <> Uid And Not LGR Then
               MsgBox("Movimiento de otro Usuario, no se permite modificar !")
               Exit Sub
            End If
         End If
         With frmCajaAM
            .Alta = Alta
            If Not Alta Then
               .Caja = Caja
               .Comprob = Comprob
               .fPago = fPago
               .Cuenta = Cuenta & ""
            End If
            .ShowDialog(Me)
            .Dispose()
         End With
      End If
      '
      ActData()
      '
   End Sub
   '
   Private Sub CmdTransferir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTransferir.Click
      '
      If FechaIncorrecta() Then
         Exit Sub
      End If
      '
      With FrmCajaTransf
         .Alta = True
         .ShowDialog(Me)
      End With
      '
      ActData()
      '
   End Sub
   '
   Private Sub cmdImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImprimir.Click
      '
      Dim Formulas(0, 1) As String
      Dim i As Integer = 0
      '
      Dim cPesos As String
      '
      With DataGridView1
         If .RowCount > 0 Then
            '
            Dim Comprob As String = .SelectedCells(.Columns("Comprob").Index).Value
            Dim Entrada As Double = .SelectedCells(.Columns("Entrada").Index).Value
            Dim Salida As Double = .SelectedCells(.Columns("Salida").Index).Value
            '
            cPesos = Numero_a_Texto(Math.Abs(Entrada - Salida))
            '
            Formulas(0, 0) = "SonPesos" : Formulas(0, 1) = cPesos
            '
            ImprimirCrp("CompCaja", crptToWindow, "{Caja.Comprob} = '" & Comprob & "'", "Comprobante de Caja", Formulas)
            '
         End If
      End With
      '
   End Sub
   '
   Private Sub cmdBaja_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBaja.Click
      '
      Dim Saldo As Double
      '
      With DataGridView1
         If .RowCount = 0 Then
            MensajeTrad("NoHayRegAct")
            Exit Sub
         Else
            '
            Dim Comprob As String = .SelectedCells(.Columns("Comprob").Index).Value
            Dim Fecha As Date = .SelectedCells(.Columns("Fecha").Index).Value
            Dim SaldoRec As Double = Val(.SelectedCells(.Columns("SaldoRec").Index).Value & "")
            Dim Entrada As Double = .SelectedCells(.Columns("Entrada").Index).Value
            Dim Salida As Double = .SelectedCells(.Columns("Salida").Index).Value
            Dim Detalle As String = .SelectedCells(.Columns("Detalle").Index).Value
            Dim Caja As Int16 = .SelectedCells(.Columns("Caja").Index).Value
            Dim MovRec As Int32 = Val(.SelectedCells(.Columns("MovRec").Index).Value & "")
            '
            If Comprob.Substring(0, 2) <> "MN" Then
               MensajeTrad("CajaAutNoBaja")
               Exit Sub
            End If
            '
            If Fecha < Today Then
               MensajeTrad("Caja Cerrada")
               Exit Sub
            End If
            '
            If SaldoRec <> 0 And Salida > 0 Then
               If SaldoRec <> Salida Then
                  MensajeTrad("Mov.C/Recupero(s)")
                  Exit Sub
               End If
            End If
            '
            If DaDeBaja(Comprob & " - " & Detalle) Then
               '
               Try
                  Trn = Cn.BeginTransaction
                  '
                  If MovRec <> 0 And Entrada > 0 Then
                     '
                     Saldo = Entrada
                     '
                     With Cmd
                        '
                        .Connection = Cn
                        .Transaction = Trn
                        '
                        Do While Saldo > 0
                           .CommandText = "SELECT * FROM Caja WHERE MovRec = " & MovRec & " AND Salida <> 0 AND SaldoRec < Salida"
                           Drd = .ExecuteReader
                           With Drd
                              If .Read Then
                                 '
                                 With Cm2
                                    '
                                    .Connection = Cn
                                    .Transaction = Trn
                                    '
                                    If Drd!SaldoRec + Saldo <= Drd!Salida Then
                                       .CommandText = "UPDATE Caja SET " & _
                                                      " SaldoRec = SaldoRec + " & Saldo & ", " & _
                                                      " Usuario = '" & Uid & "', " & _
                                                      " FechaMod = '" & Format(Now, FormatFechaHora) & "' " & _
                                                      " WHERE MovRec = " & MovRec & " AND SaldoRec + " & Saldo & " <= Salida "
                                       Saldo = 0
                                    Else
                                       Saldo = Saldo - (Drd!Salida - Drd!SaldoRec)
                                       .CommandText = "UPDATE Caja SET " & _
                                                      " SaldoRec = " & Drd!Salida & ", " & _
                                                      " Usuario = '" & Uid & "', " & _
                                                      " FechaMod = '" & Format(Now, FormatFechaHora) & "' " & _
                                                      " WHERE MovRec = " & MovRec & " AND SaldoRec + " & Saldo & " > Salida "
                                    End If
                                    '
                                    .ExecuteNonQuery()
                                    '
                                 End With
                              End If
                              .Close()
                           End With
                        Loop
                     End With
                     '
                  End If
                  '
                  If Not BorraAsiento(Comprob, Trn) Then
                     Err.Raise(1001, "frmCaja.cmdBaja_Click", Err.Description)
                  End If
                  If Not BajaCaja(Comprob, , Trn) Then
                     Err.Raise(1001, "frmCaja.cmdBaja_Click", Err.Description)
                  End If
                  '
                  Trn.Commit()
                  '
               Catch ex As System.Exception
                  Dim st As New StackTrace(True)
                  MensageError(st, "frmCaja.cmdBaja.Click")
                  Trn.Rollback()
               End Try
               '
            End If
         End If
         '
      End With
      '
      ActData()
      '
   End Sub
   '
   Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
      ActivaCmd()
   End Sub
   '
   Private Sub DataGridView1_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentDoubleClick
      AltaMod(False)
   End Sub
   '
   Private Sub tbDetalle_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbDetalle.TextChanged
      ActData()
   End Sub
   '
   Private Sub tbImporte_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbImporte.TextChanged
      ActData()
   End Sub
   '
   Private Sub tbNumero_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbNumero.TextChanged
      ActData()
   End Sub
   '
   Private Sub cmdListado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdListado.Click
      If TienePermiso(Cn, Uid, frmMenu.mCajaList.Name) Then
         With frmCajaList
            .Fecha = dtpDesde.Value
            .ShowDialog()
         End With
      End If
   End Sub
   '
   Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
      Me.Close()
   End Sub
   '
   Private Sub frmCaja_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
      SetRegGrid(Me, DataGridView1)
      SetRegForm(Me)
   End Sub
   '
End Class