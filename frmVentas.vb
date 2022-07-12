Public Class frmVentas
   '
   Dim formLoad As Boolean = False
   Dim Cliente As Integer
   Dim Comprob As Integer
   Dim Estado As Integer
   Dim Letra As String
   Dim EmpresaId As Integer
   '
   Const cmpINT = "VT"
   '
   Private Sub FrmVentasABM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      '
      GetRegForm(Me)
      '
      'modDb.LlenarCboItem(cboComprob, "Comprob", "Comprob", , , "(Todos)", "ParaFact <> 0")
      LlenarCbo(cboLetra, "Ventas", "Tipo", , "(Todas)", , , , True)
      LlenarCboItem(cboEstado, "Estados", "Estado", "Descrip", "Estado", "(Todos)", "Ventas <> 0")
      'modDb.ArmaComboItem(cboEmpresa, "Empresas", "EmpresaId", "EmpNombre", "EmpNombre", "(Todas)", "EmpresaId <> 0")
      'modDb.PosCboItem(cboEmpresa, prmEmpresaId)
      ArmaCboClientes()
      '
      dtpDesde.Value = Today
      dtpHasta.Value = Today
      '
      formLoad = True
      '
      ActData()
      '
   End Sub
   '
   Private Sub dtpDesde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDesde.ValueChanged
      ActData()
   End Sub
   '
   Private Sub ArmaCboClientes()
      ArmaComboItem(cboCliente, "Clientes", "Codigo", "Nombre", "Nombre", "(Cliente)", "Codigo <> 0")
   End Sub
   '
   Private Sub cboCliente_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCliente.SelectedIndexChanged
      With cboCliente
         If .SelectedIndex = 0 Then
            Cliente = -1
         Else
            Cliente = .SelectedValue
         End If
      End With
      ActData()
   End Sub
   '
   'Private Sub cboComprob_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboComprob.SelectedIndexChanged
   '   With cboComprob
   '      If .SelectedIndex = 0 Then
   '         Comprob = 0
   '      Else
   '         Comprob = .SelectedValue
   '      End If
   '   End With
   '   ActData()
   'End Sub
   '
   Private Sub cboLetra_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLetra.SelectedIndexChanged
      With cboLetra
         If .SelectedIndex = 0 Then
            Letra = ""
         Else
            Letra = .SelectedItem
         End If
      End With
      ActData()
   End Sub
   '
   Private Sub cboEstado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboEstado.SelectedIndexChanged
      With cboEstado
         If .SelectedIndex = 0 Then
            Estado = -1
         Else
            Estado = .SelectedValue
         End If
      End With
      ActData()
   End Sub
   '
   Public Sub ActData()

      Dim sql, wEmp, wCli, wCmp, wFec, wEst, wLetra As String
      Dim ev As System.EventArgs = EventArgs.Empty
      '
      If Not formLoad Then Exit Sub
      '
      If Cliente > -1 Then
         wCli = " AND V.Cliente = " & Cliente
      Else
         wCli = ""
      End If
      '
      If Comprob <> 0 Then
         wCmp = " AND V.Comprob = " & Comprob
      Else
         wCmp = ""
      End If
      '
      If Me.chkFechas.Checked Then
         wFec = ""
      Else
         wFec = " AND V.Fecha >= " & strFEC & Format(dtpDesde.Value, FormatFecha) & strFEC &
                " AND V.Fecha <= " & strFEC & Format(dtpHasta.Value, FormatFecha) & strFEC & " "
      End If
      '
      If Estado > -1 Then
         wEst = "V.Estado = " & Estado & " "
      Else
         wEst = "V.Estado >= 0"
      End If
      '
      If Letra <> "" Then
         wLetra = " AND V.Tipo = '" & Letra & "'"
      Else
         wLetra = ""
      End If
      '
      If EmpresaId <> 0 Then
         wEmp = " AND V.EmpresaId = " & EmpresaId & " "
      Else
         wEmp = ""
      End If
      '
      sql = "SELECT T.DescAbrev AS DescTC, V.*, E.Descrip AS DescEst " &
            "FROM Ventas V LEFT JOIN TipoComp T ON V.Comprob = T.Codigo " &
            "LEFT JOIN Estados E ON V.Estado = E.Estado " &
            "WHERE " & wEst &
            wEmp & wCli & wCmp & wFec & wLetra &
            " ORDER BY V.Fecha, V.Tipo, V.Sucursal, V.Numero"
      '
      SetRegGrid(Me, DataGridView1)
      '
      LlenarGrid(DataGridView1, sql)
      '
      SetCols()
      '
      GetRegGrid(Me, DataGridView1)
      '
      DataGridView1_Click(Me, ev)
      '
   End Sub
   '
   Private Sub SetCols()
      With DataGridView1
         For Each Columna As DataGridViewColumn In .Columns
            With Columna
               Select Case UCase(.Name)
                  Case "COMPROB" : .Width = 25 : .HeaderText = "Cpte."
                  Case "TIPO" : .Width = 25 : .HeaderText = "Letra"
                  Case "SUCURSAL" : .Width = 35
                  Case "NUMERO" : .Width = 50 : .HeaderText = "Número"
                  Case "FECHA" : .Width = 55
                  Case "NOMBRE" : .Width = 175 : .HeaderText = "Cliente"
                  Case "TOTAL" : .Width = 50 : .DefaultCellStyle.Format = "#,##0.00 " : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                  Case "DETALLE" : .Width = 150
                  Case "NRO_CAE"
                  Case "CAEFECHAVTO" : .HeaderText = "CAE F.Venc."
                  Case "DESCEST" : .HeaderText = "Estado"
                  Case Else : .Visible = False
               End Select
            End With
         Next
      End With
   End Sub
   '
   Private Sub ActivaCtrl()
      '
      Dim lEnabl As Boolean = False
      Dim Estado As Integer = 0
      '
      With DataGridView1
         If .RowCount > 0 Then
            If .SelectedRows.Count > 0 Then
               lEnabl = True
               Estado = Val(.SelectedCells(.Columns("Estado").Index).Value & "")
            End If
         End If
      End With
      '
      btnModif.Enabled = lEnabl And Estado <> 4
      btnAnular.Enabled = lEnabl And Estado <> 4
      btnEliminar.Enabled = lEnabl
      btnImprimir.Enabled = lEnabl
      btnRenumerar.Enabled = lEnabl
      btnVPrevia.Enabled = lEnabl And Estado <> 4
      '
   End Sub
   '
   Private Sub chkFechas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFechas.CheckedChanged
      dtpDesde.Enabled = Not chkFechas.Checked
      dtpHasta.Enabled = Not chkFechas.Checked
      ActData()
   End Sub
   '
   Private Sub btnAlta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAlta.Click
      AltaMod(0, EmpresaId)
   End Sub
   '
   Private Sub btnModif_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModif.Click
      Editar()
   End Sub
   '
   Private Sub Editar()
      With DataGridView1
         If .RowCount > 0 Then
            AltaMod(.SelectedCells(.Columns("VentaId").Index).Value, 0)
         End If
      End With
   End Sub
   '
   Private Sub AltaMod(ByVal VentaId As Int32, ByVal EmpresaId As Integer)
      Dim Frm As New FrmVentasAM
      With Frm
         .EmpresaId = IIf(EmpresaId = 0, prmEmpresaId, EmpresaId)
         .Alta = (VentaId = 0)
         .VentaID = VentaId
         .Facturar = False
         .VentaServ = True
         .VentaProd = True
         .ShowDialog(Me)
      End With
      ActData()
   End Sub
   '
   Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
      ImprFact(1)
   End Sub
   '
   Private Sub btnVPrevia_Click(sender As Object, e As EventArgs) Handles btnVPrevia.Click
      ImprFact(0)
   End Sub
   '
   Private Sub ImprFact(Destino As Byte)
      Dim VentaId As Long
      Dim Tipo As String
      Dim Sucursal As Int16
      Dim FactNumero As Int32
      With Me.DataGridView1
         If .RowCount > 0 Then
            VentaId = .SelectedCells(.Columns("VentaId").Index).Value
            Tipo = .SelectedCells(.Columns("Tipo").Index).Value
            Sucursal = .SelectedCells(.Columns("Sucursal").Index).Value
            FactNumero = .SelectedCells(.Columns("Numero").Index).Value
         Else
            Exit Sub
         End If
      End With
      GenRepFact(Tipo, Sucursal, FactNumero, "VENTA", Destino)
   End Sub
   '
   Private Sub dtpHasta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpHasta.ValueChanged
      ActData()
   End Sub
   '
   Private Sub btnAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnular.Click
      Dim Fecha As Date
      With Me.DataGridView1
         If .RowCount > 0 Then
            Fecha = .SelectedCells(.Columns("Fecha").Index).Value
         Else
            Exit Sub
         End If
      End With
      If PerIvaCerrado(Fecha) Then
         MensajeTrad("PerIvaCerrado")
         Exit Sub
      Else
         Anular(False)
      End If
   End Sub
   '
   Private Sub Anular(ByVal Borrar As Boolean)
      '
      'Dim Tr As OleDb.OleDbTransaction
      'Dim Rs As New OleDb.OleDbCommand
      'Dim Rs2 As New OleDb.OleDbCommand
      'Dim Dr As OleDb.OleDbDataReader
      ''
      'Dim VentaID As Long
      Dim Letra As String
      Dim Sucursal As Integer
      Dim Numero As Long
      Dim Total As Double
      Dim CodAsi, DetAsi, Nombre As String
      'Dim EgresoId As Long
      'Dim CobroID As Long
      'Dim PagoDif As Boolean
      'Dim RemitoId As Long
      'Dim TC As String
      '
      With Me.DataGridView1
         If .RowCount > 0 Then
            Letra = .SelectedCells(.Columns("Tipo").Index).Value
            Sucursal = .SelectedCells(.Columns("Sucursal").Index).Value
            Numero = .SelectedCells(.Columns("Numero").Index).Value
            Total = .SelectedCells(.Columns("Total").Index).Value
            CodAsi = "-VT-" & .SelectedCells(.Columns("VentaId").Index).Value
            Nombre = .SelectedCells(.Columns("Nombre").Index).Value
            DetAsi = "Anula FC-" & Letra & "-" & Sucursal & "-" & Numero
         Else
            Exit Sub
         End If
      End With
      '
      AnulaFactura(Letra, Sucursal, Numero,, Borrar)
      '
      If Not ActCaja(prmNroCaja, CodAsi, "EF", Today, Nombre, "", DetAsi, 0, Total) Then
         Err.Raise(1001)
      End If
      '
      'With Me.DataGridView1
      '   VentaID = .SelectedCells(.Columns("VentaId").Index).Value
      'End With
      ''
      'Tr = cn.BeginTransaction
      ''
      'Try
      '   '
      '   With Rs
      '      .Transaction = Tr
      '      .Connection = cn
      '      .CommandText = "SELECT * FROM Ventas WHERE VentaId = " & VentaID
      '      Dr = .ExecuteReader
      '   End With
      '   '
      '   With Dr
      '      If .Read Then
      '         PagoDif = CapturaDato(cn, "CondVenta", "PagoDif", "CondVenta = " & !CondVenta, False, , , Tr)
      '         '
      '         If Not Borrar Then
      '            If !Estado = 4 Then
      '               Err.Raise(1001, "Anular Venta", Traducir("VentaAnulada", , Tr))
      '            End If
      '         End If
      '         '
      '         If !Estado = 3 And PagoDif Then
      '            Err.Raise(1001, , Traducir("Venta Cobrada", , Tr))
      '            'Exit Sub
      '         End If
      '         '
      '         If Val(CapturaDato(cn, "EgresosDet E, RemitosDet R", "E.CantEntr", "E.EgresoId = R.EgresoId And E.EgresoId = " & !EgresoId & " And CantEntr > 0", , , , Tr) & "") > 0 Then
      '            Err.Raise(1001, , Traducir("Venta con mercadería Entregada", , Tr))
      '            'Exit Sub
      '         End If
      '         '
      '         CobroID = CapturaDato(cn, "CobrosDet", "CobroID", "VentaID = " & !VentaID, , , , Tr)
      '         '
      '         If MsgConfirma(Traducir(IIf(Borrar, "EliminaComprob", "AnulaComprob"), , Tr) & ": " & !Comprob & " - " & _
      '                        !Tipo & "-" & !Sucursal & "-" & !FactNumero & vbCrLf & !Nombre) Then
      '            '
      '            VentaID = !VentaID
      '            Tipo = !Tipo
      '            Sucursal = !Sucursal
      '            Numero = !FactNumero
      '            Nombre = !Nombre
      '            EgresoId = !EgresoId
      '            RemitoId = Val(!RemitoId & "")
      '            TC = CapturaDato(cn, "Comprob", "DescAbrev", "Comprob = " & !Comprob, , , , Tr)
      '            '
      '            Rs2.Connection = cn
      '            Rs2.Transaction = Tr
      '            '
      '            If RemitoId <> 0 Then
      '               Rs2.CommandText = "UPDATE RemitosDet SET " & _
      '                                 " RtdSaldo = RtdSaldo + (SELECT Cantidad FROM VentasDet " & _
      '                                 "                        WHERE VentaId = " & VentaID & _
      '                                 "                          And Producto = RemitosDet.Producto " & _
      '                                 "                          And RtdRenglon = RemitosDet.RtdRenglon) " & _
      '                                 "WHERE RemitoID = " & RemitoId
      '               Rs2.ExecuteNonQuery()
      '            End If
      '            '
      '            Rs2.CommandText = "DELETE FROM VentasDet WHERE VentaID = " & VentaID
      '            Rs2.ExecuteNonQuery()
      '            Rs2.CommandText = "DELETE FROM CtaCteCli WHERE VentaID = " & VentaID
      '            Rs2.ExecuteNonQuery()
      '            '
      '            If Borrar Then
      '               Rs2.CommandText = "DELETE FROM Ventas WHERE VentaID = " & VentaID
      '               Rs2.ExecuteNonQuery()
      '            Else
      '               Rs2.CommandText = "UPDATE Ventas SET " & _
      '                                 " Gravado = 0, " & _
      '                                 " NoGravado = 0, " & _
      '                                 " Exento = 0, " & _
      '                                 " Iva1 = 0, " & _
      '                                 " Iva2 = 0, " & _
      '                                 " Total = 0, " & _
      '                                 " Detalle = '" & Mid("(" & Traducir("Anulada", , Tr) & ") " & !Detalle, 1, 250) & "', " & _
      '                                 " Estado = 4, " & _
      '                                 " Usuario = '" & Uid & "', " & _
      '                                 " FechaMod = '" & Format(Now, FormatFechaHora) & "' " & _
      '                                 "WHERE VentaID = " & VentaID
      '               Rs2.ExecuteNonQuery()
      '            End If
      '            '
      '            If RemitoId <> 0 Then
      '               Rs2.CommandText = "UPDATE Remitos SET " & _
      '                                 " Estado = 2, " & _
      '                                 " RtoUsuMod = '" & Uid & "', " & _
      '                                 " RtoFecMod = '" & Format(Now, FormatFechaHora) & "' " & _
      '                                 "WHERE RemitoID = " & RemitoId
      '               Rs2.ExecuteNonQuery()
      '            Else
      '               If CapturaDato(cn, "Egresos", "Auto", "EgresoID = " & EgresoId, , , , Tr) Then
      '                  AnularEgreso(EgresoId, Tr)
      '               End If
      '            End If
      '            '
      '            If CobroID <> 0 Then
      '               If Not IsNothing(CapturaDato(cn, "Cobros", "Auto", "CobroID = " & CobroID, , , , Tr)) Then
      '                  AnularCobro(CobroID, Tr, False)
      '               End If
      '            End If
      '            '
      '            Rs2.CommandText = "UPDATE Presupuestos SET " & _
      '                              " VentaID = NULL, " & _
      '                              " Estado = 0, " & _
      '                              " Usuario = '" & Uid & "', " & _
      '                              " FechaMod = '" & Format(Now, FormatFechaHora) & "' " & _
      '                              "WHERE VentaID = " & VentaID
      '            Rs2.ExecuteNonQuery()
      '            '
      '            Rs2.CommandText = "UPDATE Pedidos SET " &
      '                              " VentaID = NULL, " &
      '                              " Estado = 0, " &
      '                              " Usuario = '" & Uid & "', " &
      '                              " FechaMod = '" & Format(Now, FormatFechaHora) & "' " &
      '                              "WHERE VentaID = " & VentaID
      '            Rs2.ExecuteNonQuery()
      '            '
      '            Rs2.CommandText = "UPDATE Remitos SET " &
      '                              " Estado = 2, " &
      '                              " RtoUsuMod = '" & Uid & "', " &
      '                              " RtoFecMod = '" & Format(Now, FormatFechaHora) & "' " &
      '                              "WHERE RemitoID IN( SELECT RemitoId FROM VentasRtos WHERE VentaID = " & VentaID & ")"
      '            Rs2.ExecuteNonQuery()
      '            '
      '            Rs2.CommandText = "DELETE FROM VentasRtos WHERE VentaID = " & VentaID
      '            Rs2.ExecuteNonQuery()
      '            '
      '            If SisContable Then
      '               BorraAsiento(cmpINT & "-" & VentaID)
      '            End If
      '            '
      '            GuardarAudit(IIf(Borrar, "Elimina", "Anula") & " Venta", TC & " " & Tipo & "-" & Sucursal & "-" & Numero & ", " & Nombre, "Ventas", "Anular", Tr)
      '            '
      '            Tr.Commit()
      '            '
      ActData()
      '            '
      '         Else
      '            Tr.Rollback()
      '         End If
      '         '
      '      Else
      '         Tr.Rollback()
      '      End If
      '   End With
      '   '
      'Catch e As Exception
      '   '
      '   Tr.Rollback()
      '   Dim st As New StackTrace(True)
      '   RegistrarError(st, Me.Name)
      '   '
      'End Try
      '
   End Sub
   '
   Private Sub BtnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
      Me.SetCols()
   End Sub
   '
   Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
      Dim Fecha As Date
      With Me.DataGridView1
         If .RowCount > 0 Then
            Fecha = .SelectedCells(.Columns("Fecha").Index).Value
         Else
            Exit Sub
         End If
      End With
      If PerIvaCerrado(Fecha) Then
         MensajeTrad("PerIvaCerrado")
         Exit Sub
      Else
         Anular(True)
      End If
   End Sub
   '
   Private Sub BtnRenumerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRenumerar.Click
      Dim VentaId As Long
      Dim Fecha As Date
      With Me.DataGridView1
         If .RowCount > 0 Then
            Fecha = .SelectedCells(.Columns("Fecha").Index).Value
            VentaId = .SelectedCells(.Columns("VentaId").Index).Value
         Else
            Exit Sub
         End If
      End With
      If PerIvaCerrado(Fecha) Then
         MensajeTrad("PerIvaCrrado")
      Else
         With frmVentasRenum
            .VentaID = VentaId
            .ShowDialog(Me)
            ActData()
         End With
      End If

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
      ArmaCboClientes()
      ActData()
   End Sub
   '
   Private Sub DataGridView1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
      Editar()
   End Sub
   '
   Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
      ActivaCtrl()
   End Sub
   '
   Private Sub DataGridView1_KeyUp(sender As Object, e As KeyEventArgs) Handles DataGridView1.KeyUp
      ActivaCtrl()
   End Sub
   '
   Private Sub DataGridView1_Click(sender As Object, e As EventArgs) Handles DataGridView1.Click
      ActivaCtrl()
   End Sub
   '
   Private Sub BtnListado_Click(sender As Object, e As EventArgs) Handles btnListado.Click
      '
      Dim Filtro As String
      '
      Filtro = "{Ventas.Fecha} IN CDATE('" & Format(dtpDesde.Value, FormatCDATE) & "') " &
                             " TO CDATE('" & Format(dtpHasta.Value, FormatCDATE) & "')"
      '
      ImprimirCrp("Ventas", 0, Filtro, "Diario Ventas")
      '
   End Sub
   '
   Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
      Me.Close()
   End Sub
   '
   Private Sub FrmVentas_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
      SetRegGrid(Me, DataGridView1)
      SetRegForm(Me)
   End Sub
   '
End Class