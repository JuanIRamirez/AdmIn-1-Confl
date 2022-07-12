Public Class frmOrdenesPago
   '
   Public cmpInt As String
   Public Estado As Integer
   '
   Dim Trn As OleDb.OleDbTransaction
   Dim Cmd As New OleDb.OleDbCommand
   Dim Cm2 As New OleDb.OleDbCommand
   Dim Drd As OleDb.OleDbDataReader
   '
   Dim Proveedor As Int32
   '
   Dim nSubTotal As Double
   Dim nIntereses As Double
   Dim nTotal As Double
   '
   Dim AlicIva1 As Single
   Dim AlicIva2 As Single
   Dim i As Integer
   '
   Dim nTipoMov As Integer
   Dim cImput As String
   '
   Dim cCtaCaja As String
   Dim cCtaBanco As String
   Dim cCtaInt As String
   Dim cCtaVCar As String
   '
   Dim FormLoad As Boolean
   '
   '
   Const cStruct = "Nombre VARCHAR(250) NULL, " & _
                   "Proveedor INT NOT NULL, " & _
                   "Comprob VARCHAR(50) NOT NULL, " & _
                   "Sucursal SMALLINT NOT NULL, " & _
                   "Numero INT NOT NULL, " & _
                   "Propietario INT NULL, " & _
                   "Propiedad INT NULL, " & _
                   "Total FLOAT NOT NULL"
   '*Fecha, PerIva, Comprob, Total
   '
   Const EstGEN = 0
   Const EstAut = 1
   Const EstConf = 2
   Const EstPAGO = 3
   Const EstREND = 4
   Const EstANUL = 5
   Const EstAGRUP = 6
   '
   Private Sub frmOrdenesPago_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      '
      GetRegForm(Me)
      '
      TraducirForm(Me)
      '
      If cmpInt = "" Then
         cmpInt = "OP"
      End If
      '
      Me.Text = Me.Text & " - " & Traducir(IIf(cmpInt = "OP", "Cptes", "OtrCptes"))
      '
      Cmd.Connection = Cn
      '
      If SisContable Then
         If Not CaptCtasCaja(prmNroCaja, cCtaCaja, "") Then
            DeshabForm(Me)
         Else
            If Not CaptCtasConc(cfgCodigoInt, "", cCtaInt, "") Then
               DeshabForm(Me)
            Else
               If Not CaptCtasConc(cfgCodigoVCar, "", cCtaVCar, "") Then
                  DeshabForm(Me)
               End If
            End If
         End If
      End If
      '
      ArmaComboItem(cbProveedor, "Proveedores", , "Nombre", "Nombre", "(Todos)")
      ArmaComboItem(cbEstado, "EstPagos", "Estado", "Descrip", "Estado", "(Todos)")
      '
      nTipoMov = CapturaDato(Cn, "TipoMovBco", "TipoMovBco", "TipoMov = 'CH'")
      cImput = CapturaDato(Cn, "TipoMovBco", "Imput", "TipoMov = 'CH'")
      '
      If nTipoMov = 0 Then
         MensajeTrad("TMovChNoDef")
         DeshabForm(Me)
      End If
      '
      dtpFecDesde.Value = Today
      dtpFecHasta.Value = Today
      '
      FormLoad = True
      '
      ActData()
      '
   End Sub
   '
   Private Sub DataGridView1_KeyUp(sender As Object, e As KeyEventArgs) Handles DataGridView1.KeyUp
      ActPanel()
   End Sub
   '
   Private Sub DataGridView1_MouseClick(sender As Object, e As MouseEventArgs) Handles DataGridView1.MouseClick
      ActPanel()
   End Sub
   '
   Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
      ActPanel()
   End Sub
   '
   Private Sub ActPanel()
      '
      Dim Estado As Byte
      '
      With DataGridView1
         If .RowCount > 0 Then
            Estado = .SelectedCells(.Columns("Estado").Index).Value
            Me.cmdAutorizar.Enabled = (Estado = 0 Or Estado = 1)
            Me.cmdAutorizar.Text = IIf(Estado = 0, "A&utorizar", "Desa&utorizar")
            Me.cmdConfirmar.Enabled = (Estado >= 1 And Estado <= 2)
            Me.cmdConfirmar.Text = IIf(Estado = 1, "&Confirmar", "&Desconfirmar")
            Me.cmdModificar.Enabled = (Estado = 0)
            Me.cmdPagar.Enabled = (Estado = 2 Or Estado = 3)
            Me.cmdPagar.Text = IIf(Estado = 3, "&Canc.Pago", "&Pagar")
            Me.cmdRendir.Enabled = (Estado = 3)
            Me.btnAgrupar.Enabled = TienePermiso(Cn, Uid, frmMenu.mOrdenPagoAgO.Name)
            'btnAgrupar.Visible = False   'POR AHORA.
            Me.cmdAnular.Enabled = (Estado = 0) Or (Estado < 5 And LGR)
            btnImprimir.Enabled = (Estado < 5)
         Else
            cmdConfirmar.Enabled = False
            cmdAutorizar.Enabled = False
            cmdModificar.Enabled = False
            cmdPagar.Enabled = False
            cmdAnular.Enabled = False
         End If
      End With
      '
   End Sub
   '
   Private Sub Form_KeyPress(KeyAscii As Integer)
      'TabReturn(KeyAscii, True)
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
      dtpFecDesde.Enabled = Not chkTodas.Checked
      dtpFecHasta.Enabled = Not chkTodas.Checked
      ActData()
   End Sub
   '
   Private Sub dtpFechas_ValueChanged(sender As Object, e As EventArgs) Handles dtpFecDesde.ValueChanged, dtpFecHasta.ValueChanged
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
   Private Sub cmdAlta_Click(sender As Object, e As EventArgs) Handles cmdAlta.Click
      AltaMod(True)
   End Sub
   '
   Private Sub cmdModificar_Click(sender As Object, e As EventArgs) Handles cmdModificar.Click
      AltaMod(False)
   End Sub
   '
   Private Sub CmdAnular_Click(sender As Object, e As EventArgs) Handles cmdAnular.Click
      '
      Dim ok As Boolean = False
      Dim Estado As Byte
      Dim OpNumero, OrdenPagoId As Int32
      '
      With DataGridView1
         If .RowCount = 0 Then
            MensajeTrad("Debe Seleccionar un Item")
         Else
            Estado = .SelectedCells(.Columns("Estado").Index).Value
            OpNumero = .SelectedCells(.Columns("OpNumero").Index).Value
            OrdenPagoId = .SelectedCells(.Columns("OrdenPagoId").Index).Value
            '
            If Estado = 1 Then
               MensajeTrad("Pago Autorizado")
            ElseIf Estado = 2 Then
               MensajeTrad("Pago Confirmado")
            ElseIf Estado = 3 Then
               ok = MsgConfirma("Anula OP. Nº " & OpNumero)
            ElseIf Estado = 4 Then
               ok = MsgConfirma("Anula OP. Nº " & OpNumero)
            ElseIf Estado = 5 Then
               MensajeTrad("PagoYaAnul")
            Else
               ok = MsgConfirma("Anula OP. Nº " & OpNumero)
            End If
         End If
         If ok Then
            AnularOP(OrdenPagoId)
         End If
      End With
   End Sub
   '
   Private Sub cmdDetalle_Click()
      AltaMod(False, True)
   End Sub
   '
   Private Sub AltaMod(Alta As Boolean, Optional NoMod As Boolean = False)
      '
      Dim Nombre As String = ""
      Dim OrdenPagoId, OpNumero, Proveedor As Int32
      '
      If Not Alta Then
         With DataGridView1
            If .RowCount = 0 Then
               Exit Sub
            Else
               OrdenPagoId = .SelectedCells(.Columns("OrdenPagoId").Index).Value
               Proveedor = .SelectedCells(.Columns("Proveedor").Index).Value
               Nombre = .SelectedCells(.Columns("Nombre").Index).Value & ""
               OpNumero = .SelectedCells(.Columns("OpNumero").Index).Value
            End If
         End With
      End If
      '
      Dim Frm As New frmOrdenesPagoAM
      With Frm
         .cmpInt = cmpInt
         If Alta Then
            '
         Else
            .Proveedor = Proveedor
            .OrdenPagoId = OrdenPagoId
            .SoloVer = NoMod
         End If
         .Alta = Alta
         .cbProveedor.Text = IIf(Alta, "", Nombre)
         .ShowDialog(Me)
         '
         ActData()
         '
      End With
      '
   End Sub
   '
   Private Sub cmdAutorizar_Click(sender As Object, e As EventArgs) Handles cmdAutorizar.Click
      '
      Dim Msg As String
      Dim Est As Integer
      Dim OrdenPagoId, OpNumero As Int32
      Dim OpTipo As String
      '
      With DataGridView1
         If .SelectedCells(.Columns("Estado").Index).Value = 0 Then
            Msg = "Autoriza"
            Est = 1
         Else
            Msg = "Desautoriza"
            Est = 0
         End If
         '
         OrdenPagoId = .SelectedCells(.Columns("OrdenPagoId").Index).Value
         OpNumero = .SelectedCells(.Columns("OPNumero").Index).Value
         OpTipo = .SelectedCells(.Columns("OPTipo").Index).Value
         '
         If MsgConfirma(Msg & " OP. Nº " & OpNumero) Then
            Trn = Cn.BeginTransaction
            With Cmd
               .Transaction = Trn
               .CommandText = "UPDATE OrdenPago SET Estado = " & Est & " WHERE OrdenPagoId = " & OrdenPagoId
               .ExecuteNonQuery()
            End With
            GuardarAudit(Msg & " Orden de Pago Nº " & OpNumero, OpTipo & "-" & OpNumero, "OrdenesPago", "Autorizar", Trn)
            Trn.Commit()
            ActData()
         End If
         '
      End With
      '
   End Sub
   '
   Private Sub btnAgrupar_Click(sender As Object, e As EventArgs) Handles btnAgrupar.Click
      Dim Frm As New frmOrdenPagoVs
      With frm
         .CmpInt = "PO"
         .Estado = 3
         .ShowDialog()
      End With
      ActData()
   End Sub
   '
   Private Sub cmdConfirmar_Click(sender As Object, e As EventArgs) Handles cmdConfirmar.Click
      '
      Dim Estado As Byte
      Dim OrdenPagoId As Int32
      '
      With DataGridView1
         OrdenPagoId = .SelectedCells(.Columns("OrdenPagoId").Index).Value
         Estado = .SelectedCells(.Columns("Estado").Index).Value
      End With
      '
      Dim Frm As New frmOrdenPagoConf
      With frm
         .Estado = IIf(Estado = 1, 2, 1)
         .OrdenPagoId = OrdenPagoId
         .ShowDialog(Me)
         ActData()
      End With
      '
   End Sub
   '
   Private Sub cmdPagar_Click(sender As Object, e As EventArgs) Handles cmdPagar.Click
      '
      Dim OrdenPagoId, OpNumero As Int32
      Dim Estado As Byte
      '
      With DataGridView1
         If .RowCount > 0 Then
            '
            Estado = .SelectedCells(.Columns("Estado").Index).Value
            OrdenPagoId = .SelectedCells(.Columns("OrdenPagoId").Index).Value
            OpNumero = .SelectedCells(.Columns("OpNumero").Index).Value
            '
            If Estado = 2 Then
               Dim Frm As New frmOrdenPagoPago
               With Frm
                  .Estado = 3
                  .OrdenPagoId = OrdenPagoId
                  .ShowDialog()
                  ActData()
               End With
            Else
               If MsgConfirma("Cancela Pago de la OP " & OpNumero) Then
                  DesPagarOP(OrdenPagoId)
                  ActData()
               End If
            End If
         End If
      End With
   End Sub
   '
   Private Sub cmdRendir_Click(sender As Object, e As EventArgs) Handles cmdRendir.Click
      '
      Dim OrdenPagoId As Int32
      '
      With DataGridView1
         '
         If .RowCount > 0 Then
            OrdenPagoId = .SelectedCells(.Columns("OrdenPagoId").Index).Value
            Dim Frm As New frmOrdenPagoPago
            With frm
               .Estado = 4
               .OrdenPagoId = OrdenPagoId
               .ShowDialog()
            End With
            ActData()
         End If
      End With
   End Sub
   '
   Sub ActData()
      '
      If Not FormLoad Then Exit Sub
      '
      Dim cWhere As String = ""
      Dim cSQL As String
      '
      If Proveedor > 0 Then
         cWhere = "AND O.Proveedor = " & Proveedor & " "
      End If
      '
      If Not chkTodas.Checked Then
         cWhere = cWhere & " AND O.OPFecha >= " & strFEC & Format(dtpFecDesde.Value, FormatFecha) & strFEC & _
                           " AND O.OPFecha <= " & strFEC & Format(dtpFecHasta.Value, FormatFecha) & strFEC & " "
      End If
      '
      If Estado > -1 Then
         cWhere = cWhere & " AND O.Estado = " & Estado & " "
      End If
      '
      If Val(tbNumero.Text) > 0 Then
         cWhere = cWhere & " OR O.OPNumero = " & Val(tbNumero.Text) & " "
      End If
      '
      cSQL = "SELECT O.OrdenPagoID, O.Proveedor, O.Sucursal, O.OpTipo, O.OPNumero, O.OPFecha, P.Nombre, O.OPTotal, O.OPDetalle, E.Descrip AS DescEst, O.Estado, " & _
             " (SELECT A.OpNumero FROM OrdenPago A INNER JOIN OrdenPagoDet D ON A.OrdenPagoID = D.OrdenPagoID WHERE D.ProComprob = '" & cmpInt & "' AND D.ProNumero = O.OpNumero) AS OpAgrup " & _
             "FROM OrdenPago O LEFT JOIN Proveedores P ON O.Proveedor = P.Codigo " & _
             "LEFT JOIN EstPagos E ON O.Estado = E.Estado " & _
             "WHERE O.OPTipo = '" & cmpInt & "' " & cWhere & _
             "ORDER BY O.OpNumero"
      '
      SetRegGrid(Me, DataGridView1)
      '
      LlenarGrid(DataGridView1, cSQL)
      '
      SetCols()
      '
      GetRegGrid(Me, DataGridView1)
      '
      ActPanel()
      '
   End Sub
   '
   Private Sub SetCols()
      '
      With DataGridView1
         For Each Col As DataGridViewColumn In .Columns
            With Col
               Select Case UCase(.Name)
                  Case "SUCURSAL" : .HeaderText = "Suc." : .Width = 75
                  Case "OPNUMERO" : .HeaderText = "Número" : .Width = 100
                  Case "OPFECHA" : .HeaderText = "Fecha" : .Width = 110
                  Case "NOMBRE" : .HeaderText = "Proveedor" : .Width = 300
                  Case "OPTOTAL" : .HeaderText = "Total" : .Width = 100
                     With .DefaultCellStyle
                        .Format = "#,##0.00 "
                        .Alignment = DataGridViewContentAlignment.MiddleRight
                     End With
                  Case "OPDETALLE" : .HeaderText = "Detalle" : .Width = 300
                  Case "DESCEST" : .HeaderText = "Estado"
                  Case "OPAGRUP" : .HeaderText = "OP.Agrup."
                  Case Else : .Visible = False
               End Select
            End With
         Next Col
      End With
      '
   End Sub
   '
   'Private Sub ActTemporal()
   '   '
   '   Dim Suc As Integer
   '   Dim Nro As Long
   '   '
   '   With DataGridView1
   '      Suc = .SelectedCells(.Columns("Sucursal").Index).Value
   '      Nro = .SelectedCells(.Columns("Numero").Index).Value
   '   End With
   '   '
   '   Trn = Cn.BeginTransaction
   '   With Cmd
   '      .Transaction = Trn
   '      .CommandText = "DELETE FROM " & cTmp
   '      .ExecuteNonQuery()
   '      '
   '      .CommandText = "INSERT INTO " & cTmp & "( Proveedor, Sucursal, Numero, Nombre, Fecha, PerIva, Comprob, Total) " & _
   '                     "SELECT '" & Uid & "', Proveedor, Sucursal, Numero, Nombre, Fecha, PerIva, Comprob, Total FROM " & IIf(cmpInt = "PC", "Compras", "CompraOtr") & " C " & _
   '                     "INNER JOIN PagosDet P ON C.Proveedor = P.Proveedor AND C.Comprob = P.ProComprob AND Sucursal = P.ProSucursal AND Numero = P.ProNumero " & _
   '                     "WHERE P.Comprob = '" & cmpInt & "' AND P.Sucursal = " & Suc & " AND P.Numero = " & Nro
   '      .ExecuteNonQuery()
   '      '
   '   End With
   '   '
   '   Trn.Commit()
   '   '
   'End Sub
   '
   Private Sub AnularOP(OrdenPagoId As Long)
      '
      Dim Comprob As String
      Dim Caja As Integer
      Dim OpNumero As Long
      '
      Dim ImpCaja As Double
      Dim fPago As String
      Dim Nombre As String
      Dim Detalle As String
      Dim Entrada As Boolean
      Dim CtaCaja As String
      Dim CtaProv As String
      Dim Proveedor As Long
      Dim nTipoTR As Integer
      Dim TablaC As String
      '
      With DataGridView1
         OrdenPagoId = .SelectedCells(.Columns("OrdenPagoID").Index).Value()
         Proveedor = .SelectedCells(.Columns("Proveedor").Index).Value()
         OpNumero = .SelectedCells(.Columns("OPNumero").Index).Value()
         Comprob = cmpInt & "-" & opnumero
      End With
      '
      Try
         '
         Trn = Cn.BeginTransaction
         '
         With Cmd
            '
            .Transaction = Trn
            .CommandText = "UPDATE OrdenPago SET " & _
                           " OPTotal = 0, " & _
                           " OPDetalle = '" & Traducir("Anulada", , Trn) & "', " & _
                           " Estado = " & EstANUL & ", " & _
                           " OPUid = '" & Uid & "', " & _
                           " OPFecMod = '" & Format(Now, FormatFechaHora) & "' " & _
                           "WHERE OrdenPagoID = " & OrdenPagoId
            .ExecuteNonQuery()
            '
            .CommandText = "UPDATE OrdenPago SET Estado = 1 " & _
                           "WHERE OPNumero = (SELECT ProNumero FROM OrdenPagoDet " & _
                                             "WHERE OrdenPagoID = " & OrdenPagoId & _
                                             "  AND ProComprob = '" & cmpInt & "')"
            .ExecuteNonQuery()
            '
            TablaC = IIf(cmpInt = "OP", "Compras", "CompraOtr")
            '
            .CommandText = "UPDATE " & TablaC & " SET " & _
                           " Pagado = 0, " & _
                           " NroPago = 0 " & _
                           "WHERE EXISTS( SELECT Pronumero FROM OrdenPagoDet " & _
                                         "WHERE OrdenPagoID = " & OrdenPagoId & _
                                         "  AND " & IIf(cmpInt = "OP", "Proveedor = Compras.Proveedor AND ", "") & _
                                         "      ProComprob = " & TablaC & ".Comprob " & _
                                         " AND ProSucursal = " & TablaC & ".Sucursal " & _
                                         " AND ProNumero = " & TablaC & ".Numero)"
            .ExecuteNonQuery()
            '
            .CommandText = "DELETE FROM OrdenPagoDet WHERE OrdenPagoID = " & OrdenPagoId
            .ExecuteNonQuery()
            '
         End With
         '
         If cfgCtaPrvUnica Or Proveedor = 0 Then
            CtaProv = cfgCtaProvVarios
         Else
            CtaProv = CapturaDato(Cn, "Proveedores", "Cuenta", "Codigo = " & Proveedor, , , , Trn)
         End If
         '
         With Cmd
            .CommandText = "SELECT * FROM Caja WHERE Comprob = '" & Comprob & "' ORDER BY FechaMod DESC"
            Drd = .ExecuteReader
         End With
         '
         With Drd
            Do While .Read
               If Strings.Left(!fPago, 1) = "-" Then
                  Exit Do
               End If
               ImpCaja = !Entrada + !Salida
               Caja = !Caja
               fPago = "-" & !fPago
               Nombre = !Nombre
               Detalle = "Anula " & !Detalle
               Entrada = True   ' (!Salida = 0)
               CtaCaja = CapturaDato(Cn, "Cajas", "Cuenta", "Caja = " & Caja, , , , Trn)
               '
               GuardarCaja(True, False, cmpInt, Caja, Entrada, 0, ImpCaja, fPago, Now, Nombre, Detalle, CtaProv, 0, CtaCaja, Trn, Comprob)
               '
            Loop
            .Close()
         End With
         '
         If SisContable Then
            If Not BorraAsiento(Comprob, Trn) Then
               Err.Raise(1001, "OrdenesPago")
            End If
         End If
         '
         With Cmd
            .CommandText = "SELECT * FROM OrdenPagoCH WHERE OrdenPagoID = " & OrdenPagoId
            Drd = .ExecuteReader
         End With
         '
         With Cm2
            .Connection = Cn
            .Transaction = Trn
         End With
         '
         With Drd
            Do While .Read

               If !Origen = "P" Then
                  If CapturaDato(Cn, "BancosMov", "Estado", "Banco = " & !Banco & " AND BancoCta = '" & !Cuenta & "' AND TipoMovBco = " & nTipoMov & " AND NroMovBco = " & !Numero, , , , Trn) > 1 Then
                     Err.Raise(1001, , "Cheque en estado: " & CapturaDato(Cn, "EstMovBco", "Descrip", "Estado = " & !Estado, , , , Trn))
                     .Close()
                     Err.Raise(1001, "OrdenesPago")
                  End If
                  Cm2.CommandText = "DELETE FROM BancosMov WHERE Banco = " & !Banco & " AND BancoCta = '" & !Cuenta & "' AND TipoMovBco = " & nTipoMov & " AND NroMovBco = " & !Numero
                  Cm2.ExecuteNonQuery()
                  Cm2.CommandText = "UPDATE ChPropios SET Estado = 0 WHERE Banco = " & !Banco & " AND BancoCta = '" & !Cuenta & "' AND TipoMovBco = " & nTipoMov & " AND ChPropNro = '" & !Numero & "'"
                  Cm2.ExecuteNonQuery()
               Else
                  Cm2.CommandText = "UPDATE ChCartera SET Estado = 0 WHERE Banco = " & !Banco & " AND BancoCta = '" & !Cuenta & "' AND ChCartNro = " & !Numero
                  Cm2.ExecuteNonQuery()
                  '
               End If
               '
            Loop
            .Close()
         End With
         '
         nTipoTR = CapturaDato(Cn, "TipoMovBco", "TipoMovBco", "TipoMov = 'TR'", , , , Trn)
         '
         With Cmd
            .CommandText = "DELETE FROM BancosMov " & _
                           "WHERE EXISTS( SELECT * FROM OrdenPagoTR " & _
                                         "WHERE OrdenPagoID = " & OrdenPagoId & _
                                         "  AND Banco0 = BancosMov.Banco " & _
                                         "  AND Cuenta0 = BancosMov.BancoCta " & _
                                         "  AND NumeroTR = BancosMov.NroMovBco) " & _
                           "  AND TipoMovBco = " & nTipoTR
            .ExecuteNonQuery()
            .CommandText = "DELETE FROM OrdenPagoTR WHERE OrdenPagoID = " & OrdenPagoId
            .ExecuteNonQuery()
            '
         End With
         ' 
         GuardarAudit("Anula Orden de Pago Nº " & OpNumero, Comprob, Me.Name, "AnularOP", Trn)
         '
         Trn.Commit()
         '
         ActData()
         '
         Exit Sub
         '
      Catch ex As System.Exception
         Dim st As New StackTrace(True)
         RegistrarError(st, "OrdenesPago")
         Trn.Rollback()
         '
      End Try
      '
   End Sub
   '
   Private Sub DesPagarOP(OrdenPagoId)
      '
      Dim nTotal, nEfectivo, nCheques, nTransf As Double
      Dim EstOP As Byte
      Dim compCaja As String
      Dim OpNumero As Long

      With Cmd
         .CommandText = "SELECT * FROM OrdenPago WHERE OrdenPagoID = " & OrdenPagoId
         Drd = .ExecuteReader
      End With
      With Drd
         If .Read Then
            OpNumero = !OpNumero
            nTotal = !OPTotal
            nEfectivo = !OpEfectivo
            nCheques = !OPCheques
            nTransf = !OpTransf
            EstOP = !Estado
         End If
         .Close()
      End With
      '
      compCaja = cmpInt & "-" & OpNumero
      '
      Trn = Cn.BeginTransaction
      '
      With Cmd
         .Transaction = Trn
         .CommandText = "UPDATE OrdenPago SET " & _
                        " OPFecPago = NULL, " & _
                        " Estado = " & IIf(EstOP = 6, 6, "Estado - 1") & ", " & _
                        " OPUid = '" & Uid & "', " & _
                        " OPFecMod = '" & Format(Now, FormatFechaHora) & "' " & _
                        "WHERE OrdenPagoID = " & OrdenPagoId
         .ExecuteNonQuery()
         '
         .CommandText = "DELETE FROM Caja WHERE Comprob = '" & compCaja & "' AND fPago = 'EFD'"
         .ExecuteNonQuery()
         '
      End With
      '
      GuardarAudit("Anula Pago de OP. Nº " & OpNumero, compCaja, Me.Name, "DesPagarOP", Trn)
      '
      Trn.Commit()
      '
   End Sub
   '
   Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
      '
      Dim OrdenPagoId As Integer
      Dim Comprob As String = ""
      Dim Estado As Byte
      Dim Sucursal As Int16
      Dim OpNumero As Int32
      Dim OpTotal As Double
      Dim SonPesos As String
      Dim Formulas(0, 1) As String
      '
      With DataGridView1
         '
         If .RowCount = 0 Then
            MensajeTrad("DSelItem")
            Exit Sub
         End If
         '
         OrdenPagoId = .SelectedCells(.Columns("OrdenPagoId").Index).Value()
         Sucursal = .SelectedCells(.Columns("Sucursal").Index).Value()
         OpNumero = .SelectedCells(.Columns("OPNumero").Index).Value()
         Estado = .SelectedCells(.Columns("Estado").Index).Value()
         OpTotal = .SelectedCells(.Columns("OpTotal").Index).Value()
         '
         Comprob = cmpInt & "-" & OpNumero
         '
         GenRepOrdPago(cmpInt, Sucursal, OpNumero, "ORDEN DE PAGO", crptToWindow)
         '
         If Estado = 2 Then
            If Val(OpTotal) > 0 Then
               SonPesos = Numero_a_Texto(CapturaDato(Cn, "OrdenPago", "SUM(ISNULL(OpEfectivo,0) + ISNULL(OpCheques,0))", "OrdenPagoId = " & OrdenPagoId))
               Formulas(0, 0) = "SonPesos" : Formulas(0, 1) = SonPesos
               ImprimirCrp("CompCaja", crptToWindow, "{Caja.Comprob} = '" & Comprob & "'", "Comprobante de Caja", Formulas)
            End If
         End If
         '
      End With
      '
   End Sub
   '
   Private Sub tbNumero_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbNumero.KeyPress
      SoloNumeros(e.KeyChar)
   End Sub
   '
   Private Sub tbNumero_TextChanged(sender As Object, e As EventArgs) Handles tbNumero.TextChanged
      ActData()
   End Sub
   '
   Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
      Me.Close()
   End Sub
   '
   Private Sub frmOrdenesPago_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
      SetRegGrid(Me, DataGridView1)
      SetRegForm(Me)
   End Sub
   '
End Class