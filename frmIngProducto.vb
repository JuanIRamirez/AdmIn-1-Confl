Public Class frmIngProducto
   '
   Public FormAct As Form
   Public TablaAct As String
   '
   Public EmpresaId As Integer
   Public Proveedor As Long
   Public Sucursal As Integer
   Public Numero As Long
   Public IngresoId As Long
   Public Renglon As Integer
   '
   Public Alta As Boolean
   Public Descrip As String
   Public Producto As Long
   Public Cantidad As Double
   Public Costo As Double
   Public Bonificacion As String
   Public Partida As String
   Public FechaVenc As Date
   Public OrdCompra As Long
   Public RenglonOC As Integer
   '
   Public SoloCantidad As Boolean
   Public Todos As Boolean
   Public Unico As Boolean
   Public MantAbierto As Boolean
   '
   Dim AlicIva As String
   Dim AlicuoIva As Single
   Dim ImpInt As Double
   Dim SubTotal As Double
   Dim Rubro As String
   '
   Private Sub frmIngProducto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      '
      GetRegForm(Me)
      '
      Me.Text = Me.Text & " - " & IIf(Alta, "Alta", "Edición")
      '
      'Adodc1.ConnectionString = Cn.ConnectionString
      '
      optBruto.Checked = regDefPrFinal
      '
      ActData()
      '
      'With Adodc1.Recordset
      If Producto = 0 Then
         'If .RecordCount > 0 Then
         '.MoveFirst()
         'End If
      Else
         tbBuscar.Enabled = False
         DataGridView1.Enabled = False
      End If
      'End With
      '
      If Alta Then
         ArmaCombo(cboRubro, "Descrip", "Rubros", "Descrip", "RubroPadre = '' OR RubroPadre IS NULL", , "(Todos)")
      End If
      '
      tbCodigo.Text = CapturaDato(cn, "Productos", "CodProd", "Producto = " & Producto)
      '
      If Descrip = "" Then
         With DataGridView1
            If .RowCount > 0 Then
               tbCodigo.Text = .SelectedCells(.Columns("CodProd").Index).Value
               tbDescrip.Text = .SelectedCells(.Columns("Descrip").Index).Value
            End If
         End With
      Else
         tbDescrip.Text = Descrip
      End If
      '
      tbCantidad.Text = Format(Cantidad, cfgFormatoCn)
      tbCosto.Text = Format(Costo, cfgFormatoPr)
      txtBonificacion.Text = Bonificacion
      txtRenglonOC.Text = RenglonOC
      '
      txtRenglonOC.Enabled = IIf(OrdCompra = 0, False, True)
      '
      If Todos Then
         'optMedicam.Visible = False
         'optProductos.Visible = False
      Else
         'optMedicam = prmMedicam
         'optProductos = Not optMedicam
      End If
      '
      If SoloCantidad Then
         lblPartida.Visible = False
         lblFechaVenc.Visible = False
         lblCosto.Visible = False
         tbPartida.Visible = False
         tbCosto.Visible = False
         dtFechaVenc.Visible = False
         txtRenglonOC.Visible = False
         lblRenglonOC.Visible = False
      Else
         tbPartida.Text = Partida
         If Not IsDBNull(FechaVenc) And FechaVenc <> "00:00:00" Then
            dtFechaVenc.Value = FechaVenc
         End If
         txtRenglonOC.Visible = IIf(prmConOrdCom, True, False)
         lblRenglonOC.Visible = IIf(prmConOrdCom, True, False)
         lblPartida.Visible = cfgSolPartida
         tbPartida.Visible = cfgSolPartida
         dtFechaVenc.Visible = cfgSolFecVenc
         lblFechaVenc.Visible = cfgSolFecVenc
      End If
      '
      cmdCancelar.Text = IIf(Alta, "&Cerrar", "&Cancelar")
      '
      'DataGrid1_Click()
      '
      tbBuscar.Focus()
      '
   End Sub
   '
   Private Sub DataGrid1_DblClick()
      'If Adodc1.Recordset.RecordCount > 0 Then
      '   With frmDescripDet
      '      .CodProducto = Adodc1.Recordset!Producto
      '      .Show(1)
      '   End With
      'End If
   End Sub
   '
   Private Sub cmdAltaProducto_Click(sender As Object, e As EventArgs) Handles cmdAltaProducto.Click
      'If TienePermiso(cn, Uid, frmMenu.mProductosAlta.Name) Then
      '   With frmProductosAM
      '      .Alta = True
      '      .ShowDialog(Me)
      '   End With
      '   ActData()
      'End If
   End Sub
   '
   Private Sub cboRubro_Change()
      'PintarCb(cboRubro)
      'If cboRubro = "" Then
      '   Rubro = ""
      'End If
   End Sub
   '
   Private Sub cboRubro_Click()
      Rubro = CapturaDato(cn, "Rubros", "Rubro", "Descrip = '" & cboRubro.Text & "'")
      ActData()
   End Sub
   '
   Private Sub dtFechaVenc_KeyDown(ByVal KeyCode As Integer, ByVal Shift As Integer)
      ' ''TabReturn(KeyCode, True)
   End Sub
   '
   Private Sub ActData()
      '
      Dim cWhere As String = ""
      Dim Clave As String
      '
      If Producto <> 0 And Not Alta Then
         cWhere = " AND P.Producto = " & Producto
      End If
      '
      ' ''Screen.MousePointer = 11
      '
      SetRegGrid(Me, DataGridView1)
      '
      Clave = "'%" & tbBuscar.Text & "%' "
      '
      If Not prmVerTodosProd And Alta Then
         cWhere = cWhere & " AND (P.Descrip LIKE " & Clave & " OR P.CodProd = " & Clave & " OR P.CodProv LIKE " & Clave & ") "
      End If
      '
      If Rubro <> "" Then
         cWhere = cWhere & " AND P.Rubro = '" & Rubro & "' "
      End If
      '
      LlenarGrid(DataGridView1, "SELECT " & IIf(cfgSumDescRubro, "R.Descrip + ' ' + ", "") & "P.Descrip AS Descrip, P.CodProd, P.CodProv, P.Producto, P.DiasVenc, P.Costo, P.BonifProv, O.Nombre, P.AlicIva, P.ImpInt, (SELECT TOP 1 '*' FROM " & TablaAct & " WHERE CodPRod = P.CodProd) AS Sel " & _
                                "FROM Productos P LEFT JOIN Proveedores O ON P.Proveedor = O.Proveedor, Rubros R " & _
                                "WHERE P.Producto <> 0 " & _
                                "  AND P.Rubro = R.Rubro " & _
                                "  AND P.Inactivo = 0 " & cWhere & _
                                IIf(cfgIngProdProv, IIf(Proveedor = 0, "", " AND P.Proveedor IN( 0, " & Proveedor & ") "), "") & _
                                "ORDER BY P.Descrip")
      '
      With DataGridView1
         For Each Columna As DataGridViewColumn In .Columns
            With Columna
               Select Case UCase(.Name)
                  Case "DESCRIP" : .HeaderText = "Descripción" : .Width = 400
                  Case "CODPROD" : .HeaderText = "Código" : .Width = 100
                  Case "CODPROV" : .HeaderText = "Cod.Prov." : .Width = 100
                  Case "COSTO" : .DefaultCellStyle.Format = "0.00 "
                  Case "NOMBRE" : .HeaderText = "Proveedor"
                  Case "SEL"
                  Case Else : .Visible = False
               End Select
            End With
         Next
      End With
      '
      GetRegGrid(Me, DataGridView1)
      '
      'DataGrid1_Click()
      '
   End Sub

   Private Sub frmIngProducto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
      TabReturn(e.KeyChar)
   End Sub

   Private Sub opCodigo_Click()
      ActData()
   End Sub
   '
   Private Sub opDescrip_Click()
      ActData()
   End Sub

   Private Sub optBruto_CheckedChanged(sender As Object, e As EventArgs) Handles optBruto.CheckedChanged
      regDefPrFinal = True
      CalcImportes(0)
   End Sub
   '
   Private Sub optCodigo_Click()
      ActData()
   End Sub
   '
   Private Sub optDescrip_Click()
      ActData()
   End Sub
   '
   Private Sub optMedicam_Click()
      ActData()
   End Sub
   '
   Private Sub optProductos_Click()
      ActData()
   End Sub
   '
   Private Sub optNeto_CheckedChanged(sender As Object, e As EventArgs) Handles optNeto.CheckedChanged
      regDefPrFinal = False
      CalcImportes(0)
   End Sub
   '
   Private Sub optRubro_Click()
      ' ''VER
      ' ''With frmProductosArbol
      ' ''   .ABM = False
      ' ''   .Seleccionar = True
      ' ''   .Show(1, Me)
      ' ''   '
      ' ''   tbCodigo = .CodigoSelec
      ' ''   optCodigo = True
      ' ''   ActData()
      ' ''   tbBuscar = .CodigoSelec
      ' ''   tbCantidad.Focus()
      ' ''   '
      ' ''End With
   End Sub
   '
   'Private Sub chkAproximada_Click()
   '   tbBuscar_Change()
   'End Sub
   '
   Private Sub tbBuscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbBuscar.TextChanged

      ActData()
      '
      DataGrid1_Click()
      '
   End Sub
   '
   Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
      DataGrid1_Click()
   End Sub
   '
   Private Sub DataGridView1_MouseClick(sender As Object, e As MouseEventArgs) Handles DataGridView1.MouseClick
      DataGrid1_Click()
   End Sub
   '
   Private Sub DataGridView1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DataGridView1.KeyPress
      If e.KeyChar > " " Then
         tbBuscar.Text = e.KeyChar
         tbBuscar.Focus()
      End If
   End Sub
   '
   Private Sub DataGridView1_KeyUp(sender As Object, e As KeyEventArgs) Handles DataGridView1.KeyUp
      DataGrid1_Click()
   End Sub
   '
   Private Sub DataGrid1_Click()
      '
      Dim DiasVenc As Integer
      '
      With DataGridView1
         If .RowCount > 0 Then
            AlicIva = .SelectedCells(.Columns("AlicIva").Index).Value & ""
            If AlicIva = "" Then
               AlicuoIva = cfgAlicIva
            Else
               AlicuoIva = Val(CapturaDato(cn, "AlicIva", "Alicuo1", "AlicIva = '" & AlicIva & "'"))
            End If
            DiasVenc = Val(.SelectedCells(.Columns("DiasVenc").Index).Value & "")
            dtFechaVenc.Value = Today.AddDays(DiasVenc)
            tbCodigo.Text = .SelectedCells(.Columns("CodProd").Index).Value & ""
            tbDescrip.Text = .SelectedCells(.Columns("Descrip").Index).Value & ""
            Producto = Val(.SelectedCells(.Columns("Producto").Index).Value & "")
            Costo = Val(.SelectedCells(.Columns("Costo").Index).Value & "")
            ImpInt = Val(.SelectedCells(.Columns("ImpInt").Index).Value & "")
            txtBonificacion.Text = .SelectedCells(.Columns("BonifProv").Index).Value & ""
         End If
      End With
      '
      CalcImportes(0)
      '
   End Sub
   '
   Private Sub tbCantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbCantidad.KeyPress, tbCosto.KeyPress, txtRenglonOC.KeyPress
      SoloNumeros(e.KeyChar)
   End Sub

   Private Sub tbCantidad_TextChanged(sender As Object, e As EventArgs) Handles tbCantidad.TextChanged
      CalcImportes(0)
   End Sub
   '
   Private Sub tbCosto_TextChanged(sender As Object, e As EventArgs) Handles tbCosto.TextChanged
      CalcImportes(Val(tbCosto.Text))
   End Sub
   '
   Private Sub tbPartida_LostFocus()
      Dim Costo As Double
      dtFechaVenc.Value = CaptFechaPartida(Proveedor, Producto, tbPartida.Text, Costo)
      tbCosto.Text = Costo
   End Sub
   '
   Private Sub txtBonificacion_Change()
      'If Val(txtDbonificacion) > cfgMaxDescuento Then
      '   MensajeTrad "DescNoPerm"
      '   txtDescuento = ""
      '   txtDescuento.Focus
      'End If
      CalcImportes(0)
   End Sub
   '
   Private Sub txtBonificacion_GotFocus()
      'PintarTb(txtBonificacion)
   End Sub
   '
   Private Sub txtDescuento_KeyPress(ByVal KeyAscii As Integer)
      SoloNumeros(KeyAscii, , , "+")
   End Sub
   '
   Private Sub txtRenglonOC_GotFocus()
      'PintarTb(txtRenglonOC)
   End Sub
   '
   Private Sub cmdAceptar_Click(sender As Object, e As EventArgs) Handles cmdAceptar.Click
      '
      'On Error GoTo mError
      '
      Dim Trn As OleDb.OleDbTransaction
      Dim Rs As New OleDb.OleDbCommand
      Dim Dr As OleDb.OleDbDataReader
      '
      Dim cWhere As String = ""
      Dim FechaVenc As String
      '
      If Producto = 0 Then
         MsgBox("Debe seleccionar Producto")
         Exit Sub
      End If
      '
      If tbCodigo.Text = "" Then
         MsgBox("Debe seleccionar Producto")
         Exit Sub
      End If
      '
      If Val(tbCantidad.Text) = 0 Then
         MsgBox("Debe ingresar Cantidad", vbInformation)
         tbCantidad.Focus()
         Exit Sub
      End If
      '
      If Val(tbCosto.Text) = 0 Then
         MsgBox("Debe ingresar Costo", vbInformation)
         tbCosto.Focus()
         Exit Sub
      End If
      '
      Rs.Connection = cn
      '
      If Not SoloCantidad And cfgSolPartida Then
         If tbPartida.Text = "" Then
            MsgBox("Debe ingresar Partida", vbInformation)
            tbPartida.Focus()
            Exit Sub
         End If
         '
         With Rs
            .CommandText = "SELECT D.Partida FROM Ingresos I INNER JOIN IngresosDet D ON I.IngresoId = D.IngresoId " & _
                           "WHERE I.EmpresaId = " & EmpresaId & _
                           "  AND I.Sucursal = " & prmSucursal & _
                           "  AND I.Departamento = " & prmDepart & _
                           "  AND I.Proveedor = " & Proveedor & _
                           "  AND D.Producto = '" & Producto & "'" & _
                           "  AND D.Partida = '" & tbPartida.Text & "'" & _
                           "  AND (RtoSucursal <> " & Sucursal & _
                           "       OR RtoNumero <> " & IIf(prmConOrdCom, "'", "") & Numero & IIf(prmConOrdCom, "'", "") & ")"
            Dr = .ExecuteReader
         End With
         '
         With Dr
            If .Read Then
               If MsgBox("Partida existente, Continúa", vbQuestion + vbYesNo) = vbNo Then
                  .Close()
                  tbPartida.Focus()
                  Exit Sub
               End If
            Else
               'Ok Partida.                  
            End If
            .Close()
         End With
         '
         If cfgSolFecVenc Then
            If dtFechaVenc.Value <= Today Then
               If MsgBox("Fecha Vencida", vbInformation + vbOKCancel) = vbCancel Then
                  dtFechaVenc.Focus()
                  Exit Sub
               End If
            End If
         End If
         '
         If txtRenglonOC.Enabled Then
            If Val(txtRenglonOC.Text) = 0 Then
               MsgBox("Debe ingresar Renglón de O. Compra", vbInformation)
               txtRenglonOC.Focus()
               Exit Sub
            End If
         End If
         '
      End If
      '
      Trn = cn.BeginTransaction
      '
      Rs.Transaction = Trn
      '
      If Unico Then
         With Rs
            .CommandText = "SELECT * FROM " & TablaAct & " " & _
                  "WHERE Producto = '" & Producto & "'" & _
                  "  AND Partida = '" & tbPartida.Text & "'"
            Dr = .ExecuteReader
         End With
         With Dr
            If Alta Or tbPartida.Text <> Partida Then
               If .Read Then
                  .Close()
                  Err.Raise(1001, , "Producto/Partida ya ingresado")
               End If
            End If
            .Close()
         End With
         '
         If txtRenglonOC.Enabled Then
            With Rs
               .CommandText = "SELECT * FROM " & TablaAct
               Dr = .ExecuteReader
            End With
            With Dr
               While .Read
                  If !Producto <> Producto And !RenglonOC = Val(txtRenglonOC.Text) Then
                     .Close()
                     Err.Raise(1001, , "El Renglón OC. debe ser distinto para cada Código")
                  End If
               End While
               .Close()
            End With
         End If
         '
      End If
      '
      FechaVenc = IIf(cfgSolFecVenc, "'" & dtFechaVenc.Value & "'", "NULL")
      '
      tbDescrip.Text = ReemplazaChar(tbDescrip.Text, "'", "´")
      '
      If Alta Then
         Rs.CommandText = "INSERT INTO " & TablaAct & "( IngresoId, Renglon, Producto, CodProd, Detalle, Cantidad, Costo, Bonificacion, Partida, " & IIf(prmConOrdCom, " RenglonOC, ", "") & "FechaVenc, SubTotal, AlicuoIva) " & _
                         " VALUES( 0, " & Renglon & ", " & _
                                          Producto & ", " & _
                                    "'" & tbCodigo.Text & "', " & _
                                    "'" & tbDescrip.Text & "', " & _
                                          Val(tbCantidad.Text) & ", " & _
                                          Costo & ", " & _
                                    "'" & txtBonificacion.Text & "', " & _
                                    "'" & tbPartida.Text & "', " & _
                                          IIf(prmConOrdCom, Val(txtRenglonOC.Text) & ", ", "") & _
                                          FechaVenc & ", " & _
                                          SubTotal & ", " & _
                                          AlicuoIva & ")"
         Rs.ExecuteNonQuery()
      Else
         If Not Partida = "" Then
            cWhere = " AND Partida = '" & Partida & "'"
         End If
         Rs.CommandText = "UPDATE " & TablaAct & " SET " & _
                          " CodProd = '" & tbCodigo.Text & "', " & _
                          " Detalle = '" & tbDescrip.Text & "', " & _
                          " Cantidad = " & Val(tbCantidad.Text) & ", " & _
                          " Costo = " & Costo & ", " & _
                          " Bonificacion = '" & txtBonificacion.Text & "', " & _
                          " Partida = '" & tbPartida.Text & "', " & _
                          " FechaVenc = " & FechaVenc & ", " & _
                          " SubTotal = " & SubTotal & ", " & _
                          " AlicuoIva = " & AlicuoIva & " " & _
                          IIf(prmConOrdCom, ", RenglonOC = " & Val(txtRenglonOC.Text), "") & _
                          " WHERE Renglon = " & Renglon & " " & _
                          "  AND IngresoId = " & IngresoId & " " & _
                           cWhere
         Rs.ExecuteNonQuery()
      End If
      '
      Trn.Commit()
      '
      If Not MantAbierto Then
         Me.Close()
      Else
         ' ***VER*** FormAct.ActData()
         tbCantidad.Text = Format(Cantidad, cfgFormatoCn)
         tbCosto.Text = Format(Costo, cfgFormatoPr)
         'txtPrecio = Format(Precio, cfgFormatoPr)
         txtRenglonOC.Text = ""
         tbBuscar.Focus()
         If Alta Then
            Renglon = Renglon + 1
         End If
         ActData()
      End If
      '
      Exit Sub
      '
mError:
      ' ''Cn.RollbackTrans()
      MsgBox(Err.Description, vbInformation)
      '
   End Sub
   '
   Private Sub CalcImportes(ByVal CostoLocal As Double)
      '
      Dim PrUnit As Double
      'Dim Bonific As String
      Dim Bonif As New Collection
      'Dim Pos As Integer
      '
      If CostoLocal <> 0 Then
         If optNeto.Checked Then
            Costo = CostoLocal
         Else
            Costo = CostoLocal / (1 + AlicuoIva / 100)
         End If
      End If
      '
      PrUnit = DescontarBonificacion(Costo, txtBonificacion.Text)
      SubTotal = (PrUnit + ImpInt) * Val(tbCantidad.Text)
      '
      tbCosto.Text = Format(Costo * IIf(optNeto.Checked, 1, 1 + (AlicuoIva / 100)), cfgFormatoPr)
      txtSubTotal.Text = Format(SubTotal * IIf(optNeto.Checked, 1, 1 + (AlicuoIva / 100)), cfgFormatoPr)
      '
   End Sub
   '
   Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
      MantAbierto = False
      Me.Close()
   End Sub

   Private Sub frmIngProducto_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
      SetRegGrid(Me, DataGridView1)
      SetRegForm(Me)
      Me.Dispose()
   End Sub
   '
End Class