Public Class frmChCartera
   '
   Dim Cmd As New OleDb.OleDbCommand
   '
   Dim Banco As Int16
   Dim Estado As Integer
   Dim Caja As Integer
   Dim FormLoad As Boolean = False
   '
   Const estEMIT = 1
   Const EstCONC = 2
   Const EstANUL = 3
   '
   Private Sub frmChCartera_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      '
      GetRegForm(Me)
      '
      TraducirForm(Me)
      '
      ArmaComboItem(cbCaja, "Cajas", "Caja", "Descrip", "Descrip", "(Todas)", , , , , prmNroCaja)
      ArmaComboItem(cbBanco, "Bancos", "Banco", "Nombre", "Nombre")
      ArmaComboItem(cbEstado, "EstChCartera", "Estado", , , "(Todos)", , , , , 0)
      '
      dtpDesde.Value = Today
      dtpHasta.Value = Today
      '
      FormLoad = True
      ActData()
      '
   End Sub

   Private Sub frmChCartera_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
      TabReturn(e.KeyChar)
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
      ActData()
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
      ActData()
   End Sub
   '
   Private Sub cbCaja_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCaja.SelectedIndexChanged
      With cbCaja
         If .SelectedIndex > 0 Then
            Caja = .SelectedValue
         Else
            Caja = 0
         End If
      End With
      ActData()
   End Sub
   '
   Private Sub DataGridView1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyUp
      ActCtrl()
   End Sub
   '
   Private Sub DataGridView1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridView1.MouseClick
      ActCtrl()
   End Sub
   '
   Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
      ActCtrl()
   End Sub
   '
   Private Sub ActCtrl()
      '
      Dim Est As Byte
      '
      With DataGridView1
         If .RowCount = 0 Then
            cmdBaja.Enabled = False
            cmdEdicion.Enabled = False
            btnEntregar.Enabled = False
            btnACobrar.Enabled = False
            btnCobrar.Enabled = False
            btnDevolver.Enabled = False
            btnDepositar.Enabled = False
         Else
            Est = .SelectedCells(.Columns("Estado").Index).Value
            cmdBaja.Enabled = (Est = 0)
            cmdEdicion.Enabled = (Est = 0)
            btnEntregar.Enabled = (Est = 0)
            btnACobrar.Enabled = (Est = 0)
            btnCobrar.Enabled = (Est = 4)
            btnDevolver.Enabled = (Est = 4)
            btnDepositar.Enabled = (Est = 0)
         End If
      End With
      '
   End Sub
   '
   Private Sub btnDevolver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDevolver.Click
      AltaMod(False, False, False, False, True)
   End Sub
   '
   Private Sub btnACobrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnACobrar.Click
      AltaMod(False, , True)
   End Sub
   '
   Private Sub btnCobrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCobrar.Click
      AltaMod(False, , , True)
   End Sub
   '
   Private Sub chkTodas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodas.CheckedChanged
      dtpDesde.Enabled = Not chkTodas.Checked
      dtpHasta.Enabled = Not chkTodas.Checked
      ActData()
   End Sub
   '
   Private Sub tbNumero_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbNumero.TextChanged
      ActData()
   End Sub
   '
   Sub ActData()
      '
      If Not FormLoad Then Exit Sub
      '
      Dim Filtro As String
      '
      If Estado >= 0 Then
         Filtro = " AND C.Estado = " & Estado
      Else
         Filtro = " AND C.Estado >= 0"
      End If
      '
      If Banco > 0 Then
         Filtro = Filtro & " AND C.Banco = " & Banco
      End If
      '
      If Not chkTodas.Checked Then
         Filtro = Filtro & " AND C.FechaEmi  >= " & strFEC & Format(dtpDesde.Value, FormatFecha) & strFEC &
                           " AND C.FechaEmi  <= " & strFEC & Format(dtpHasta.Value, FormatFecha) & strFEC
      End If
      '
      If tbNombre.Text <> "" Then
         Filtro = Filtro & " AND C.Entrego LIKE '%" & tbNombre.Text & "%' "
      End If
      '
      If tbNumero.Text <> "" Then
         Filtro = Filtro & " AND C.ChCartNro LIKE '%" & tbNumero.Text & "%' "
      End If
      '
      If Caja <> 0 Then
         Filtro = Filtro & " AND C.Caja = " & Caja & " "
      End If
      '
      SetRegGrid(Me, DataGridView1)
      '
      LlenarGrid(Me.DataGridView1, "SELECT C.FechaEmi, C.FechaDif, C.FechaEnt, C.FechaSal, " &
                                   " C.Banco, B.Nombre, C.BancoCta, C.ChCartNro, C.Titular, C.Entrego, C.Importe, C.Detalle, C.ChCartId, C.Estado, E.Descrip AS DescEst, C.Comprob, C.Caja " &
                                   "FROM ChCartera C, Bancos B, EstChCartera E " &
                                   "WHERE C.Banco = B.Banco " &
                                   "  AND C.Estado = E.Estado " &
                                   Filtro &
                                   " ORDER BY C.FechaDif, C.ChCartNro")
      '
      With Me.DataGridView1
         Me.cmdEdicion.Enabled = (.RowCount > 0)
         Me.cmdBaja.Enabled = (.RowCount > 0)
      End With
      '
      SetCols()
      '
      GetRegGrid(Me, DataGridView1)
      '
      ActCtrl()
      '
   End Sub
   '
   Private Sub SetCols()
      '
      With DataGridView1
         For Each Col As DataGridViewColumn In .Columns
            With Col
               Select Case UCase(Col.Name)
                  Case "NOMBRE" : .Width = 200 : .HeaderText = "Banco"
                  Case "BANCOCTA" : .Width = 100 : .HeaderText = "Cuenta"
                  Case "CHCARTNRO" : .Width = 100 : .HeaderText = "Número"
                  Case "TITULAR" : .Width = 200
                  Case "FECHAEMI" : .Width = 120 : .HeaderText = "Fecha Ing."
                  Case "FECHADIF" : .Width = 120 : .HeaderText = "Fecha Ch."
                  Case "ENTREGO" : .Width = 200
                  Case "IMPORTE" : .Width = 100
                     With .DefaultCellStyle
                        .Format = "#,##0.00 "
                        .Alignment = DataGridViewContentAlignment.MiddleRight
                     End With
                  Case "DETALLE"
                  Case "DESCEST" : .HeaderText = "Estado"
                  Case "COMPROB" : .HeaderText = "Comprob."
                  Case Else : .Visible = False
               End Select
            End With
         Next Col
         '
      End With
      '
   End Sub
   '
   Private Sub cmdAlta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAlta.Click
      AltaMod(True)
   End Sub
   '
   Private Sub cmdEdicion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdicion.Click
      AltaMod(False, , , , , True)
   End Sub
   '
   Private Sub btnEntregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEntregar.Click
      AltaMod(False, True)
   End Sub
   '
   Private Sub AltaMod(ByVal Alta As Boolean, Optional ByVal Entregar As Boolean = False, Optional ByVal aCobrar As Boolean = False, Optional ByVal Cobrado As Boolean = False, Optional ByVal Devolver As Boolean = False, Optional ByVal Editar As Boolean = False)
      '
      Dim Frm As New frmChCarteraAM
      '
      With Frm
         If Alta Then
            .Alta = True
            .Banco = Banco
            .ChCartId = 0
            .Entregar = False
            .Cobrado = False
            .aCobrar = False
            .Devolver = False
         Else
            '
            Dim ChId As Int32 = CapturaDatoColumna(DataGridView1, "ChCartId")
            Dim Comprob As String = CapturaDatoColumna(DataGridView1, "Comprob") & ""
            '
            If Not Entregar And Not aCobrar And Not Cobrado And Not Devolver Then
               If ComprobNoNull(Comprob) Then
                  Exit Sub
               End If
            End If
            '
            .Alta = False
               .ChCartId = ChId
               .Editar = Editar
               .Entregar = Entregar
               .Cobrado = Cobrado
               .aCobrar = aCobrar
               .Devolver = Devolver
               .Comprob = Comprob
            End If
            .ShowDialog(Me)
         ActData()
      End With
   End Sub
   '
   Private Sub cmdBaja_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBaja.Click
      '
      With DataGridView1
         '
         If .RowCount = 0 Then
            MensajeTrad("NoHayRegAct")
            Exit Sub
         End If
         '
         Dim Comprob As String = CapturaDatoColumna(DataGridView1, "Comprob") & ""
         '
         If ComprobNoNull(Comprob) Then
            Exit Sub
         End If
         '
         Dim Trn As OleDb.OleDbTransaction
         Dim ChId As Int32
         '
         Comprob = "CH-" & .SelectedCells(.Columns("Banco").Index).Value & "-" & .SelectedCells(.Columns("BancoCta").Index).Value & "-" & .SelectedCells(.Columns("ChCartNro").Index).Value
         ChId = .SelectedCells(.Columns("ChCartId").Index).Value
         '
         If MsgConfirma("Elimina Cheque Nº " & .SelectedCells(.Columns("ChCartNro").Index).Value) Then
            '
            Trn = Cn.BeginTransaction
            '
            With Cmd
               .Connection = Cn
               .Transaction = Trn
               .CommandText = "DELETE FROM ChCartera WHERE ChCartId = " & ChId
               .ExecuteNonQuery()
            End With
            '
            BorraAsiento(Comprob, Trn)
            BajaCaja(Comprob, , Trn)
            '
            GuardarAudit("Baja Cheque Cartera", Comprob, Me.Name, sender.ToString, Trn)
            '
            Trn.Commit()
            '
            ActData()
         End If
         '
      End With
      '
   End Sub
   '
   Private Function ComprobNoNull(Comprob As String) As Boolean
      If Comprob = "" Then
         Return False
      Else
         If Comprob.Substring(0, 2) = "MN" Then
            MensajeTrad("ChIngPCaja")
         Else
            MensajeTrad("ChIngPCobros")
         End If
         Return True
      End If
   End Function
   '
   Private Sub cmdImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImprimir.Click
      FrmChCarteraList.ShowDialog(Me)
   End Sub
   '
   Private Sub dtpFechas_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDesde.ValueChanged, dtpHasta.ValueChanged
      ActData()
   End Sub
   '
   Private Sub tbNombre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbNombre.TextChanged
      ActData()
   End Sub
   '
   Private Sub btnDepositar_Click(sender As Object, e As EventArgs) Handles btnDepositar.Click
      '
      Dim Frm As New frmBancosMovAM
      Dim TipoMovBco As Byte = CapturaDato(Cn, "TipoMovBco", "TipoMovBco", "TipoMov = 'DP'")
      '
      With Frm
         .Concilia = False
         .Alta = True
         .Deposito = True
         .Banco = 0
         .BancoCta = ""
         .TipoMovBco = TipoMovBco
         .NroMovBco = 0
         .Caja = CapturaDatoColumna(DataGridView1, "Caja")
         .BancoCh = CapturaDatoColumna(DataGridView1, "Banco")
         .CuentaCh = CapturaDatoColumna(DataGridView1, "BancoCta")
         .NumeroCh = CapturaDatoColumna(DataGridView1, "ChCartNro")
         .Rechazar = False
         .ShowDialog(Me)
      End With
      '
      ActData()
      '
   End Sub
   '
   Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
      Me.Close()
   End Sub
   '
   Private Sub frmChCartera_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
      SetRegGrid(Me, DataGridView1)
      SetRegForm(Me)
   End Sub
   '
End Class