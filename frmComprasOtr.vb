Public Class frmComprasOtr
   '
   Dim Trn As OleDb.OleDbTransaction
   Dim Cmd As New OleDb.OleDbCommand
   '
   Dim nCol As Integer
   Dim nColFec As Integer
   Dim nColCon As Integer
   Dim nColDet As Integer
   Dim nColImp As Integer
   Dim nColAcc As Integer
   '
   Dim Proveedor As Integer
   Dim Propietario As Integer
   Dim nNumero As Long
   Dim Comprob As String
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
   Dim FormLoad As Boolean
   '
   Const cmpInt = "CP"
   '
   Private Sub frmComprasOtr_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      '
      GetRegForm(Me)
      '
      TraducirForm(Me)
      '
      dtpFecDesde.Value = Today.AddDays(-30)
      dtpFecHasta.Value = Today
      '
      ArmaComboItem(cbPropietario, "Propietarios", , "Nombre", "Nombre", "(Adm)")
      ArmaComboItem(cbProveedor, "Proveedores", "Codigo", "Nombre", "Nombre", "(Todos)")
      ArmaCombo(cbComprob, "Descrip", "CompInt", "Descrip", , , "(Todos)")
      '
      FormLoad = True
      ActData()
      '
   End Sub
   '
   Private Sub Form_KeyPress(KeyAscii As Integer)
      'TabReturn(KeyAscii, True)
   End Sub
   '
   'Private Sub cbNombre_Change()
   '   PintarCb(cbNombre, LastKey)
   '   If cbNombre = "" Then Proveedor = 0
   'End Sub
   '
   Private Sub chkPagados_CheckedChanged(sender As Object, e As EventArgs) Handles chkPagados.CheckedChanged
      ActData()
   End Sub
   '
   Private Sub DataGrid1_Click()
      'With Adodc1.Recordset
      '   If .RecordCount > 0 Then
      '      cmdBaja.Enabled = Not !Liquidado And Not !Pagado
      '      cmdEdicion.Enabled = Not !Pagado
      '   End If
      'End With
   End Sub
   '
   Private Sub DataGrid1_KeyUp(KeyCode As Integer, Shift As Integer)
      DataGrid1_Click()
   End Sub
   '
   Private Sub DataGrid1_RowColChange(LastRow As Object, ByVal LastCol As Integer)
      DataGrid1_Click()
   End Sub
   '
   Private Sub cbProveedor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbProveedor.SelectedIndexChanged
      With cbProveedor
         If .SelectedIndex > 0 Then
            Proveedor = .SelectedValue
         Else
            Proveedor = 0
         End If
      End With
      ActData()
   End Sub
   '
   Private Sub chkTodas_CheckedChanged(sender As Object, e As EventArgs) Handles chkTodas.CheckedChanged
      dtpFecDesde.Enabled = IIf(chkTodas.Checked, False, True)
      dtpFecHasta.Enabled = IIf(chkTodas.Checked, False, True)
      ActData()
   End Sub
   '
   Private Sub dtpFechas_ValueChanged(sender As Object, e As EventArgs) Handles dtpFecDesde.ValueChanged, dtpFecHasta.ValueChanged
      ActData()
   End Sub
   '
   'Private Sub chkTodos_Click()
   '   cbDescProp.Enabled = IIf(chkTodos.Value = 0, True, False)
   '   ActData()
   'End Sub
   '
   Private Sub cbPropietario_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPropietario.SelectedIndexChanged
      With cbPropietario
         If .SelectedIndex > 0 Then
            Propietario = .SelectedValue
         Else
            Propietario = 0
         End If
      End With
      ActData()
   End Sub
   '
   Private Sub cbComprob_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbComprob.SelectedIndexChanged
      With cbComprob
         If .SelectedIndex = 0 Then
            Comprob = ""
         Else
            Comprob = CapturaDato(Cn, "CompInt", "Codigo", "Descrip = '" & .Text & "'")
         End If
      End With
      ActData()
   End Sub
   '
   'Private Sub DataGrid1_DblClick()
   '   cmdEdicion_Click()
   'End Sub
   '
   Private Sub cmdDetalle_Click()
      AltaMod(False, True)
   End Sub
   '
   Private Sub cmdAlta_Click(sender As Object, e As EventArgs) Handles cmdAlta.Click
      AltaMod(True)
   End Sub
   '
   Private Sub cmdEdicion_Click(sender As Object, e As EventArgs) Handles cmdEdicion.Click
      With DataGridView1
         If .RowCount > 0 Then
            If .SelectedCells(.Columns("Pagado").Index).Value Then
               MensajeTrad("CmpPagado")
            ElseIf .SelectedCells(.Columns("Liquidado").Index).Value Then
               MensajeTrad("CmpLiqNoModDet")
               AltaMod(False, , True)
            Else
               AltaMod(False)
            End If
         End If
      End With
   End Sub
   '
   Private Sub AltaMod(Alta As Boolean, Optional SoloVer As Boolean = False, Optional NoModDet As Boolean = False)
      '
      Dim nPro As Long
      Dim cCmp As String
      Dim nSuc As Integer
      Dim nNro As Long
      Dim cNom As String
      Dim nPrt As Int32
      Dim nPrd As Int32
      '
      If Alta Then
         cCmp = cmpInt
      Else
         With DataGridView1
            nPro = .SelectedCells(.Columns("Proveedor").Index).Value
            cCmp = .SelectedCells(.Columns("Comprob").Index).Value
            nSuc = .SelectedCells(.Columns("Sucursal").Index).Value
            nNro = .SelectedCells(.Columns("Numero").Index).Value
            cNom = .SelectedCells(.Columns("Nombre").Index).Value & ""
            nPrt = .SelectedCells(.Columns("Propietario").Index).Value
            nPrd = .SelectedCells(.Columns("Propiedad").Index).Value
         End With
         '
      End If
      '
      Dim Frm As New frmComprasOtrAM
      With Frm
         .Alta = Alta
         .Comprob = cCmp
         .SoloVer = SoloVer
         .NoModDet = NoModDet
         .Pagar = True
         If Not Alta Then
            .Proveedor = nPro
            .Sucursal = nSuc
            .Numero = nNro
            .Propiet = nPrt
            .Propied = nPrd
         End If
         .ShowDialog()
         ActData()
      End With
      '
   End Sub
   '
   Private Sub cmdBaja_Click(sender As Object, e As EventArgs) Handles cmdBaja.Click
      '
      Dim nPro As String
      Dim cCmp As String
      Dim nSuc As Integer
      Dim nNro As Long
      '
      With DataGridView1
         If .RowCount > 0 Then
            '
            If .SelectedCells(.Columns("Pagado").Index).Value Then
               MensajeTrad("CmpPagado")
               Exit Sub
            End If
            '
            If .SelectedCells(.Columns("Liquidado").Index).Value Then
               MensajeTrad("CpteLiquid")
               Exit Sub
            End If
            '
            If DaDeBaja("Comprob." & ": " & .SelectedCells(.Columns("Comprob").Index).Value & " - " & _
                                            .SelectedCells(.Columns("Sucursal").Index).Value & " - " & _
                                            .SelectedCells(.Columns("Numero").Index).Value & vbCrLf & _
                                            .SelectedCells(.Columns("Nombre").Index).Value) Then
               '
               nPro = .SelectedCells(.Columns("Proveedor").Index).Value
               cCmp = .SelectedCells(.Columns("Comprob").Index).Value
               nSuc = .SelectedCells(.Columns("Sucursal").Index).Value
               nNro = .SelectedCells(.Columns("Numero").Index).Value
               '
               Trn = Cn.BeginTransaction
               '
               With Cmd
                  .Connection = Cn
                  .Transaction = Trn
                  .CommandText = "DELETE FROM CompraOtr WHERE Proveedor = " & nPro & " AND Comprob = '" & cCmp & "' AND Sucursal = " & nSuc & " AND Numero = " & nNro
                  .ExecuteNonQuery()
                  .CommandText = "DELETE FROM CompraOtrDet WHERE Proveedor = " & nPro & " AND Comprob = '" & cCmp & "' AND Sucursal = " & nSuc & " AND Numero = " & nNro
                  .ExecuteNonQuery()
               End With
               '
               GuardarAudit("Baja Compra Otros", "Cpte: " & cCmp & " - " & nSuc & " - " & nNro, Me.Name, "Baja", Trn)
               '
               Trn.Commit()
               '
               ActData()
               '
            End If
         End If
      End With
      '
      Exit Sub
      '
      'mError:
      '      MsgBox Err.Number & " - " & Err.Description & vbCrLf & _
      '             Traducir("TransNComp")
      '      Cn.Rollback()
      '
   End Sub
   '
   Private Sub btnPagar_Click(sender As Object, e As EventArgs) Handles btnPagar.Click
      '
      With DataGridView1
         If .RowCount > 0 Then
            If .SelectedCells(.Columns("Pagado").Index).Value Then
               MensajeTrad("CptePagado")
            Else
               Dim Frm As New frmOrdenPagoPago
               With Frm
                  .OrdenPagoId = 0
                  .Proveedor = CapturaDatoColumna(DataGridView1, "Proveedor")
                  .Comprob = CapturaDatoColumna(DataGridView1, "Comprob")
                  .Sucursal = CapturaDatoColumna(DataGridView1, "Sucursal")
                  .Numero = CapturaDatoColumna(DataGridView1, "Numero")
                  .PagoDir = True
                  .cmpInt = "PO"
                  .ShowDialog(Me)
               End With
               ActData()
            End If
         End If
      End With
      '
   End Sub
   '
   Private Sub btnAnulaPago_Click(sender As Object, e As EventArgs) Handles btnAnulaPago.Click
      '
      Dim nPro As String
      Dim cCmp As String
      Dim nSuc As Integer
      Dim nNro As Long
      '
      With DataGridView1
         If .RowCount > 0 Then
            '
            If Not .SelectedCells(.Columns("Pagado").Index).Value Then
               MensajeTrad("CmpNoPagado")
               Exit Sub
            End If
            '
            'If .SelectedCells(.Columns("Liquidado").Index).Value Then
            ' MensajeTrad("CpteLiquid")
            'Exit Sub
            'End If
            '
            If MsgConfirma("Anula Pago " & ": " & .SelectedCells(.Columns("Comprob").Index).Value & " - " & _
                                                  .SelectedCells(.Columns("Sucursal").Index).Value & " - " & _
                                                  .SelectedCells(.Columns("Numero").Index).Value & vbCrLf & _
                                                  .SelectedCells(.Columns("Nombre").Index).Value) Then
               '
               nPro = .SelectedCells(.Columns("Proveedor").Index).Value
               cCmp = .SelectedCells(.Columns("Comprob").Index).Value
               nSuc = .SelectedCells(.Columns("Sucursal").Index).Value
               nNro = .SelectedCells(.Columns("Numero").Index).Value
               '
               Trn = Cn.BeginTransaction
               '
               With Cmd
                  .Connection = Cn
                  .Transaction = Trn
                  '.CommandText = "DELETE FROM CompraOtr WHERE Proveedor = " & nPro & " AND Comprob = '" & cCmp & "' AND Sucursal = " & nSuc & " AND Numero = " & nNro
                  .ExecuteNonQuery()
                  '.CommandText = "DELETE FROM CompraOtrDet WHERE Proveedor = " & nPro & " AND Comprob = '" & cCmp & "' AND Sucursal = " & nSuc & " AND Numero = " & nNro
                  .ExecuteNonQuery()
               End With
               '
               GuardarAudit("Anula Pago Otros", "Cpte: " & cCmp & " - " & nSuc & " - " & nNro, Me.Name, "Baja", Trn)
               '
               Trn.Commit()
               '
               ActData()
               '
            End If
         End If
      End With
   End Sub
   '
   Sub ActData()
      '
      Dim cWhere As String = ""
      '
      If Not FormLoad Then Exit Sub
      '
      If Propietario > 0 Then
         cWhere = " AND C.Propietario = " & Propietario
      End If
      '
      If Proveedor > 0 Then
         cWhere = cWhere & " AND C.Proveedor = " & Proveedor
      End If
      '
      If Comprob <> "" Then
         cWhere = cWhere & " AND C.Comprob LIKE '" & Comprob & "%'"
      End If
      '
      If Not chkTodas.Checked Then
         cWhere = cWhere & " AND Fecha >= " & strFEC & Format(dtpFecDesde.Value, FormatFecha) & strFEC & _
                           " AND Fecha <= " & strFEC & Format(dtpFecHasta.Value, FormatFecha) & strFEC & " "
      End If
      '
      SetRegGrid(Me, DataGridView1)
      '
      LlenarGrid(DataGridView1, "SELECT C.Fecha, C.Comprob, C.Sucursal, C.Numero, " & _
                                " C.Propietario, C.Propiedad, C.Proveedor, C.Nombre, C.Detalle, " & _
                                " C.Total, C.Liquidado, C.Pagado, C.LiqPropiet, C.NroPago, O.OPNumero, O.OPFecha, E.Descrip AS EstOP " & _
                                "FROM CompraOtr C LEFT JOIN OrdenPago O ON C.NroPago = O.OrdenPagoId " & _
                                " LEFT JOIN EstPagos E ON O.Estado = E.Estado " & _
                                "WHERE C.Pagado " & IIf(chkPagados.Checked, "<>", "=") & " 0 " & cwhere & _
                                " ORDER BY C.Fecha, C.Comprob, C.Sucursal, C.Numero")
      '
      SetCols()
      '
      GetRegGrid(Me, DataGridView1)
      '
      DataGrid1_Click()
      '
   End Sub
   '
   Private Sub SetCols()

      'Dim cCol As MSDBGrid.Column

      With DataGridView1
         For Each cCol As DataGridViewColumn In .Columns
            With cCol
               Select Case .Name
                  Case "Comprob"
                     .HeaderText = "Comprob."
                  Case "Sucursal"
                     .HeaderText = "Suc."
                  Case "Numero"
                     .HeaderText = "Número"
                  Case "Fecha"
                  Case "Nombre"
                  Case "Concepto" : cCol.HeaderText = "Conc."
                  Case "Detalle"
                  Case "Total"
                     With .DefaultCellStyle
                        .Alignment = DataGridViewContentAlignment.MiddleRight
                        .Format = cfgFormatoPrCol
                     End With
                  Case "LiqPropiet"
                  Case "NroPago" : .HeaderText = "Pago Nro."
                     With .DefaultCellStyle
                        .Alignment = DataGridViewContentAlignment.MiddleRight
                     End With
                  Case "OPNumero" : .HeaderText = "OP.Nro."
                  Case "OPFecha" : .HeaderText = "OP.Fecha"
                     With .DefaultCellStyle
                        .Alignment = DataGridViewContentAlignment.MiddleRight
                     End With
                  Case "EstOP" : .HeaderText = "Est.OP"
                  Case Else : .Visible = False
               End Select
            End With
         Next cCol
      End With

   End Sub
   '
   Private Sub cmdImprimir_Click()
      '
      Dim Reporte As String
      Dim Filtro As String
      Dim Formulas(0, 1) As String
      '
      Reporte = "CompraOtr"
      Filtro = IIf(Proveedor = 0, "", " AND {CompraOtr.Proveedor} = " & Proveedor)
      '
      If Comprob <> "" Then
         Filtro = IIf(Filtro = "", "", Filtro & " AND ") & "{CompraOtr.Comprob} LIKE '" & Comprob & "*'"
      End If
      '
      If Not chkTodas.Checked Then
         Filtro = IIf(Filtro = "", "", Filtro & " AND ") & "{CompraOtr.Fecha} IN CDATE('" & Format(dtpFecDesde.Value, FormatCDATE) & "')" & _
                                                           "      TO CDATE('" & Format(dtpFecHasta.Value, FormatCDATE) & "') "
      End If
      '
      'If chkTodos = 0 Then
      'Filtro = IIf(Filtro = "", "", Filtro & " AND ") & "{CompraOtr.Propietario} = '" & cbPropietario & "' "
      'End If
      '
      Filtro = IIf(Filtro = "", "", Filtro & " AND ") & IIf(Not chkPagados.Checked, "NOT {CompraOtr.Pagado}", "{CompraOtr.Pagado}")
      Formulas(0, 0) = "SubTitulo" : Formulas(0, 1) = IIf(Not chkPagados.Checked, "Pendientes", "Pagados")
      '
      ImprimirCrp(Reporte, crptToWindow, Filtro, "Listado otras compras", Formulas)
      '
   End Sub
   '
   Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
      Me.Close()
   End Sub
   '
   Private Sub frmComprasOtr_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
      '
      SetRegGrid(Me, DataGridView1)
      SetRegForm(Me)
      '
   End Sub
   '
End Class