Public Class frmCompras
   '
   Dim EmpresaId As Integer
   Dim TipoComp As Integer
   Dim Proveedor As Long
   Dim Estado As Integer
   '
   Dim nSubTotal As Double
   Dim nGravado As Double
   Dim nNoGravado As Double
   Dim nCompraRni As Double
   Dim nExento As Double
   Dim nIva1 As Double
   Dim nIva2 As Double
   Dim nTotal As Double
   '
   Dim AlicIva1 As Single
   Dim AlicIva2 As Single
   Dim i As Integer
   Dim CompProd As Boolean
   Dim CompServ As Boolean
   Dim FormLoad As Boolean = False
   '
   Const cmpINT = "CM"
   '
   Private Sub frmCompras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      '
      GetRegForm(Me)
      '
      ArmaComboItem(cboProveedor, "Proveedores", "Proveedor", "Nombre", "Nombre", "(Todos)", "Inactivo = 0")
      ArmaComboItem(cboTipoComp, "TipoComp", "TipoComp", , , "(Todos)", "ParaFact <> 0")
      ArmaComboItem(cboEstado, "Estados", "Estado", , , "(Todos)", "Compras <> 0")
      ArmaComboItem(cboEmpresa, "Empresas", "EmpresaId", "EmpNombre", "EmpNombre", "(Todas)", "EmpresaId <> 0", , , , prmEmpresaId)
      With cboEmpresa
         If .Items.Count <= 1 Then
            .Enabled = False
         End If
      End With
      '
      tbFecDesde.Value = Today
      tbFecHasta.Value = Today
      tbPerIVA.Value = Today
      tbPerIVA.CustomFormat = "MM/yyyy"
      '
      FormLoad = True
      '
      ActData()
      '
   End Sub
   '
   Private Sub frmCompras_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
      TabReturn(e.KeyChar)
   End Sub
   '
   Private Sub cboEmpresa_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboEmpresa.SelectedIndexChanged
      With cboEmpresa
         If .SelectedIndex <= 0 Then
            EmpresaId = 0
         Else
            EmpresaId = .SelectedValue
         End If
      End With
      ArmaCboProveedor()
      ActData()
   End Sub
   '
   Private Sub ArmaCboProveedor()
      ArmaComboItem(cboProveedor, "Proveedores", "Proveedor", "Nombre", "Nombre", "(Proveedor)", "EmpresaId IN ( 0, " & EmpresaId & ") AND Proveedor <> 0")
   End Sub
   '
   Private Sub cboProveedor_Change()
      If cboProveedor.Text = "" Then
         Proveedor = 0
         ActData()
      End If
   End Sub
   '
   Private Sub cboProveedor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboProveedor.SelectedIndexChanged
      With cboProveedor
         If .SelectedIndex > 0 Then
            Proveedor = .SelectedValue
         Else
            Proveedor = 0
         End If
      End With
   End Sub
   '
   Private Sub cboEstado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEstado.SelectedIndexChanged
      With cboEstado
         If .SelectedIndex > 0 Then
            Estado = .SelectedValue
         Else
            Estado = -1
         End If
      End With
      ActData()
   End Sub
   '
   Private Sub chkTodas_Click()
      tbFecDesde.Enabled = IIf(chkTodas.Checked = False, True, False)
      tbFecHasta.Enabled = IIf(chkTodas.Checked = False, True, False)
      ActData()
   End Sub
   '
   'Private Sub Form_Resize()
   '   On Error Resume Next
   '   Me.DataGrid1.Width = Me.ScaleWidth - 60
   '   Me.DataGrid1.Height = Me.ScaleHeight - Me.DataGrid1.Top - Me.fraPie.Height - 60
   '   Me.fraPie.Top = Me.ScaleHeight - fraPie.Height - 60
   '   fraPie.Width = Me.ScaleWidth - 60
   '   Me.cmdSalir.Left = fraPie.Width - cmdSalir.Width - 60
   'End Sub
   '
   Private Sub tbFecDesde_Change()
      ActData()
   End Sub
   '
   Private Sub tbFecHasta_Change()
      ActData()
   End Sub
   '
   Private Sub chkTodos_Click()
      tbPerIVA.Enabled = IIf(chkTodos.Checked = False, True, False)
      ActData()
   End Sub
   '
   'Private Sub tbPerIva_GotFocus()
   '   With tbPerIva
   '      .SelStart = 0
   '      .SelLength = Len(.Text)
   '   End With
   'End Sub
   '
   'Private Sub tbPerIva_LostFocus()
   '   If ValPeriodo(tbPerIva) Then
   '      ActData()
   '   Else
   '      tbPerIva.SetFocus()
   '   End If
   'End Sub
   '
   Private Sub cboTipoComp_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoComp.SelectedIndexChanged
      With cboTipoComp
         If .SelectedIndex > 0 Then
            TipoComp = .SelectedValue
         Else
            TipoComp = 0
         End If
      End With
      ActData()
   End Sub
   '
   Private Sub DataGrid1_Click()
      With DataGridView1
         If .RowCount > 1 Then
            Dim lEnabl As Boolean = .SelectedCells(.Columns("Estado").Index).Value = 0 Or .SelectedCells(.Columns("CondVenta").Index).Value = 1
            cmdBaja.Enabled = lEnabl
            cmdEdicion.Enabled = lEnabl
         Else
            cmdBaja.Enabled = False
            cmdEdicion.Enabled = False
         End If
      End With
   End Sub
   '
   Private Sub btnAlta_Click(sender As Object, e As EventArgs) Handles btnAlta.Click
      AltaMod(True)
   End Sub
   '
   Private Sub cmdEdicion_Click(sender As Object, e As EventArgs) Handles cmdEdicion.Click
      Editar(False)
   End Sub
   '
   Private Sub cmdPerIva_Click()
      Editar(True)
   End Sub
   '
   Private Sub cmdConcepto_Click()
      Editar(False, True)
   End Sub
   '
   Private Sub Editar(ByVal SoloPerIva As Boolean, Optional ByVal SoloConcepto As Boolean = False)
      With DataGridView1
         If .RowCount = 1 Then
            MensajeTrad("DSelItem")
         Else
            Dim PerIva As String = .SelectedCells(.Columns("PerIva").Index).Value
            Dim Estado As Byte = .SelectedCells(.Columns("Estado").Index).Value
            Dim CondVenta As Byte = .SelectedCells(.Columns("CondVenta").Index).Value
            Dim Descrip As String = .SelectedCells(.Columns("Descrip").Index).Value
            Dim CompraId As Long = .SelectedCells(.Columns("CompraId").Index).Value
            If (Strings.Right(PerIva, 4) & Strings.Left(PerIva, 2)) <= cfgPerCierreIVA Then
               MensajeTrad("PerIvaCerrado")
               Exit Sub
            End If
            If Estado = 0 Or CondVenta = 1 Or SoloPerIva Or SoloConcepto Then
               CompServ = (Not IsNothing(CapturaDato(Cn, "ComprasDet", "Concepto", "CompraID = " & CompraId & " AND Concepto <> 0")))
               CompProd = (Not IsNothing(CapturaDato(Cn, "ComprasDet", "Producto", "CompraID = " & CompraId & " AND Producto <> 0")))
               AltaMod(False, False, SoloPerIva, SoloConcepto)
            Else
               MensajeTrad("Comprobante " & Descrip & ", no se puede modificar", , False)
            End If
         End If
      End With
   End Sub
   '
   Private Sub cmdDetalle_Click()
      AltaMod(False, False, False, True)
   End Sub
   '
   Private Sub AltaMod(ByVal Alta As Boolean, Optional ByVal SoloVer As Boolean = False, Optional ByVal SoloPerIva As Boolean = False, Optional ByVal SoloConcepto As Boolean = False)
      '
      Dim nPro As Long
      Dim nID As Long
      '
      If Not Alta Then
         With Me.DataGridView1
            If .RowCount > 1 Then
               nPro = .SelectedCells(.Columns("Proveedor").Index).Value
               nID = .SelectedCells(.Columns("CompraID").Index).Value
            End If
         End With
      End If
      '
      With frmComprasAM
         .Alta = Alta
         '.CompServ = CompServ
         '.CompProd = CompProd
         .SoloVer = SoloVer
         .EmpresaId = IIf(EmpresaId = 0, prmEmpresaId, EmpresaId)
         If Not Alta Then
            .SoloPerIva = SoloPerIva
            .SoloConcepto = SoloConcepto
            .Proveedor = nPro
            .CompraID = nID
         End If
         .ShowDialog(Me)
         ActData()
      End With
      '
   End Sub
   '
   Private Sub cmdBaja_Click(sender As Object, e As EventArgs) Handles cmdBaja.Click
      '
      On Error GoTo mError
      '
      Dim CodAsi As String
      Dim PagoID As Long
      Dim IngAuto As Boolean
      Dim SelIngDet As String
      Dim Depart As Integer
      Dim TR As OleDb.OleDbTransaction
      Dim Cmd As New OleDb.OleDbCommand
      '
      With Me.DataGridView1
         If .RowCount = 1 Then
            MensajeTrad("DSelItem")
         Else
            '
            Dim PerIva As String = .SelectedCells(.Columns("PerIva").Index).Value
            '
            If (Strings.Right(PerIva, 4) & Strings.Left(PerIva, 2)) <= cfgPerCierreIVA Then
               MensajeTrad("PerIvaCerrado")
               Exit Sub
            End If
            '
            Dim Sucursal As Int16 = CapturaDatoColumna(DataGridView1, "Sucursal")
            Dim TipoComp As String = CapturaDatoColumna(DataGridView1, "TipoComp")
            Dim CompSucursal As Int16 = CapturaDatoColumna(DataGridView1, "CompSucursal")
            Dim CompNumero As Long = CapturaDatoColumna(DataGridView1, "CompNumero")
            Dim Nombre As String = CapturaDatoColumna(DataGridView1, "Nombre")
            Dim Proveedor As Long = CapturaDatoColumna(DataGridView1, "Proveedor")
            Dim CompraID As Long = CapturaDatoColumna(DataGridView1, "CompraId")
            Dim IngresoId As Long = CapturaDatoColumna(DataGridView1, "IngresoId")

            If MsgBox(Traducir("BajaComprob") & ": " & TipoComp & " - " & _
                      CompSucursal & " - " & CompNumero & vbCrLf & _
                      Nombre, vbQuestion & vbYesNo) = vbYes Then
               '
               CodAsi = cmpINT & "-" & Proveedor & "-" & CompSucursal & "-" & CompNumero
               '
               If Val(CapturaDato(Cn, "Pagos C, PagosDet D", "RboNumero", "C.PagoID = D.PagoID AND D.CompraID = " & CompraID) & "") <> 0 Then
                  MensajeTrad("CompraPagada")
                  Exit Sub
               End If
               '
               PagoID = CapturaDato(Cn, "Pagos C, PagosDet D", "C.PagoID", "C.PagoID = D.PagoID AND D.CompraID = " & CompraID)
               IngAuto = (CapturaDato(Cn, "Ingresos", "RtoNumero", "IngresoID = " & IngresoId) = 0)
               Depart = CapturaDato(Cn, "Ingresos", "Departamento", "IngresoID = " & IngresoId)
               '
               SelIngDet = "SELECT SUM(Cantidad) FROM Ingresos I, IngresosDet D " & _
                           "WHERE I.Sucursal = Partidas.Sucursal " & _
                           "  AND I.Departamento = Partidas.Departamento " & _
                           "  AND I.Proveedor = Partidas.Proveedor " & _
                           "  AND I.IngresoID = " & IngresoId & _
                           "  AND I.IngresoID = D.IngresoID " & _
                           "  AND D.Producto = Partidas.Producto " & _
                           "  AND D.Partida = Partidas.Partida " & _
                           "GROUP BY I.Proveedor, D.Producto, D.Partida"
               '
               TR = Cn.BeginTransaction
               Cmd.Transaction = TR
               '
               With Cmd
                  If IngAuto Then
                     .CommandText = "UPDATE Partidas SET " & _
                                    " Saldo = Saldo - (" & SelIngDet & "), " & _
                                    " Cantidad = Cantidad - (" & SelIngDet & "), " & _
                                    " Usuario = '" & Uid & "', " & _
                                    " FechaMod = '" & Format(Now, FormatFechaHora) & "' " & _
                                    "WHERE Sucursal = " & Sucursal & _
                                    "  AND Departamento = " & Depart & _
                                    "  AND Proveedor = " & Proveedor & _
                                    "  AND EXISTS (" & SelIngDet & ")"
                     .ExecuteNonQuery()
                     '
                     .CommandText = "UPDATE Stock SET " & _
                                    " Cantidad = Cantidad - (SELECT SUM(D.Cantidad) AS Cant FROM Ingresos I, IngresosDet D " & _
                                    "                        WHERE I.IngresoID = " & IngresoId & _
                                    "                          AND I.IngresoID = D.IngresoID " & _
                                    "                          AND D.Producto = Stock.Producto " & _
                                    "                        GROUP BY D.Producto), " & _
                                    " Usuario   = '" & Uid & "', " & _
                                    " FechaMod  = '" & Format(Now, FormatFechaHora) & "' " & _
                                    "WHERE Stock.Sucursal = " & Sucursal & _
                                    " AND Stock.Departamento = " & Depart & _
                                    " AND Producto IN( SELECT D.Producto FROM Ingresos I, IngresosDet D " & _
                                    "                  WHERE I.IngresoID = " & IngresoId & _
                                    "                    AND I.IngresoID = D.IngresoID " & _
                                    "                  GROUP BY Producto )"
                     .ExecuteNonQuery()
                     '
                     .CommandText = "DELETE FROM IngresosDet WHERE IngresoID = " & IngresoId
                     .ExecuteNonQuery()
                     '
                     .CommandText = "DELETE FROM Ingresos WHERE IngresoID = " & IngresoId
                     .ExecuteNonQuery()
                     '
                  Else
                     .CommandText = "UPDATE IngresosDet SET " & _
                                    " Saldo = Saldo + ISNULL((SELECT Cantidad FROM ComprasDet " & _
                                    "                  WHERE CompraID = " & CompraID & _
                                    "                    AND Producto = IngresosDet.Producto " & _
                                    "                    AND IngresoId = IngresosDet.IngresoId " & _
                                    "                    AND RtoRenglon = IngresosDet.RtoRenglon), 0) " & _
                                    "WHERE IngresoID IN( SELECT IngresoId FROM ComprasDet WHERE CompraID = " & CompraID & ")"
                     .ExecuteNonQuery()
                  End If
                  '
                  .CommandText = "DELETE FROM ComprasDet WHERE CompraID = " & CompraID
                  .ExecuteNonQuery()
                  '
                  .CommandText = "DELETE FROM Compras WHERE CompraID = " & CompraID
                  .ExecuteNonQuery()
                  '
                  .CommandText = "DELETE FROM CtaCtePro WHERE CompraID = " & CompraID
                  .ExecuteNonQuery()
                  '
                  .CommandText = "DELETE FROM Pagos WHERE PagoID = " & PagoID
                  .ExecuteNonQuery()
                  '
                  .CommandText = "DELETE FROM PagosDet WHERE PagoID = " & PagoID
                  .ExecuteNonQuery()
                  '
               End With
               '
               BajaCaja(CodAsi, , TR)
               BajaCaja("PG-" & PagoID, , TR)
               '
               If SisContable Then
                  If Not BorraAsiento(CodAsi) Then GoTo mError
               End If
               '
               TR.Commit()
               '
               ActData()
            End If
         End If
      End With
      '
      Exit Sub
      '
mError:
      MsgBox(Err.Number & " - " & Err.Description & vbCrLf & _
             Traducir("TransNComp"))
      TR.Rollback()
      '
   End Sub
   '
   Sub ActData()
      '
      Dim cWhere As String = ""
      Dim cSql As String
      '
      If Not formload Then Exit Sub
      '
      If Proveedor > 0 Then
         cWhere = " AND C.Proveedor = " & Proveedor & " "
      End If
      '
      If cboTipoComp.SelectedIndex > 0 Then
         cWhere = cWhere & " AND C.TipoComp = '" & TipoComp & "' "
      End If
      '
      If Not chkTodas.Checked Then
         cWhere = cWhere & " AND C.Fecha >= " & strFEC & Format(tbFecDesde.Value, FormatFecha) & strFEC & _
                           " AND C.Fecha <= " & strFEC & Format(tbFecHasta.Value, FormatFecha) & strFEC & " "
      End If
      '
      If Not chkTodos.Checked Then
         cWhere = cWhere & " AND C.PerIva = '" & tbPerIVA.Text & "' "
      End If
      '
      If Estado > -1 Then
         cWhere = cWhere & " AND C.Estado = " & Estado & " "
      End If
      '
      SetRegGrid(Me, DataGridView1)
      '
      cSql = "SELECT C.Sucursal, C.CompraID, C.TipoComp, T.DescAbrev AS DescTC, C.CompLetra, C.Proveedor, C.CompSucursal, C.CompNumero, " & _
                                "       C.Fecha, C.PerIva, C.Nombre, C.Total, C.CompServ, C.Estado, E.Descrip, C.CondVenta, C.IngresoID, P.PedidoPrNro " & _
                                "FROM Compras C LEFT JOIN PedidosProv P " & _
                                "  ON C.PedidoPrID = P.PedidoPrID, Estados E, TipoComp T " & _
                                "WHERE C.Estado = E.Estado " & _
                                "  AND C.TipoComp = T.TipoComp " & _
                                cWhere & _
                                "ORDER BY C.Fecha"
      '
      LlenarGrid(DataGridView1, cSql)
      '
      SetCols()
      '
      GetRegGrid(Me, DataGridView1)
      '
   End Sub
   '
   Private Sub btnSetCols_Click(sender As Object, e As EventArgs) Handles btnSetCols.Click
      SetCols()
   End Sub
   '
   Private Sub SetCols()
      '
      With DataGridView1
         For Each Columna As DataGridViewColumn In .Columns
            With Columna
               Select Case UCase(.Name)
                  Case "DESCTC" : .Width = 50 : .HeaderText = "Cpte."
                  Case "COMPLETRA" : .Width = 50 : .HeaderText = "Letra"
                  Case "COMPSUCURSAL" : .Width = 75 : .HeaderText = "Sucursal"
                  Case "COMPNUMERO" : .Width = 100 : .HeaderText = "Número"
                  Case "FECHA" : .Width = 110
                  Case "PERIVA" : .Width = 100 : .HeaderText = "Per.Iva."
                  Case "NOMBRE" : .Width = 345 : .HeaderText = "Proveedor"
                  Case "TOTAL" : .Width = 100
                     With .DefaultCellStyle
                        .Format = "#,##0.00 "
                        .Alignment = DataGridViewContentAlignment.MiddleRight
                     End With
                  Case "DESCRIP" : .HeaderText = "Estado"
                  Case "PEDIDOPRNRO" : .HeaderText = "Pedido Nº"
                  Case Else : .Visible = False
               End Select
            End With
         Next Columna
      End With
      '
   End Sub
   '
   Private Sub cmdSalir_Click(sender As Object, e As EventArgs) Handles cmdSalir.Click
      Me.Close()
   End Sub
   '
   Private Sub frmCompras_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
      SetRegGrid(Me, DataGridView1)
      SetRegForm(Me)
   End Sub
   '
End Class