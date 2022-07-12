Public Class frmOrdenPagoVs
   '
   Public CmpInt As String
   Public Estado As Byte
   Public OrdenPagoId As Long
   '
   Dim Trn As OleDb.OleDbTransaction
   Dim Cmd As New OleDb.OleDbCommand
   Dim Cm2 As New OleDb.OleDbCommand
   Dim Drd As OleDb.OleDbDataReader
   '
   Dim OpId As Long
   Dim OpNro As Long
   Dim OpNumero As Long
   Dim nTotal As Double
   Dim nEfectivo As Double
   Dim nCheques As Double
   Dim Caja As Integer
   Dim CuentaProv As String
   Dim cCtaCaja As String
   Dim cCtaCajaA As String
   Dim FecPago As Date
   Dim nTipoMov As Integer
   Dim cImput As String
   Dim cDescInt As String
   Dim cCtaInt As String
   Dim cDescVCar As String
   Dim cCtaVCar As String
   Dim CaptCtas As Boolean
   Dim Alta As Boolean
   Dim Comprob As String
   Dim EstOP As Integer
   Dim Proveedor As Long
   '
   Dim cTmpCh As String
   Dim cTmpOP As String
   '
   Const cStrOP = "OpNumero INT NOT NULL"
   '
   Const cStrCh = "Origen VARCHAR (1), " & _
                  "Banco INT, " & _
                  "DescBco VARCHAR(250) NULL, " & _
                  "BancoCta VARCHAR(10), " & _
                  "Titular VARCHAR(50), " & _
                  "Numero VARCHAR(50), " & _
                  "Fecha SMALLDATETIME, " & _
                  "Importe FLOAT, " & _
                  "Renglon SMALLINT NULL, " & _
                  "CtaCont VARCHAR(25) NULL, " & _
                  "Usuario VARCHAR(50) NULL"
   '
   Const EstAut = 1
   Const EstConf = 2
   Const EstAgrup = 6
   Const estEMIT = 1
   '
   Private Sub frmOrdenPagoVs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      '
      GetRegForm(Me)
      '
      TraducirForm(Me)
      '
      Alta = (OrdenPagoId = 0)
      '
      If CmpInt = "" Then
         CmpInt = "OP"
         BuscarCfg(cfgNroPago, "cfgNroPago")
         OpNumero = cfgNroPago + 1
         tbNumero.Text = OpNumero
      End If
      '
      cTmpCh = ""
      CrearTabla(Cn, cStrCh, cTmpCh)
      '
      cTmpOP = ""
      CrearTabla(Cn, cStrOP, cTmpOP)
      '
      ArmaComboItem(cbCaja, "Cajas", "Caja", , , "(Seleccionar)", "Caja <> 0")
      PosicionarComboItem(cbCaja, prmNroCaja)
      '
      ArmaComboItem(cbProveedor, "Proveedores", "Codigo", "Nombre", "Nombre", "(Varios)")
      '
      PosCboItem(cbProveedor, Proveedor)
      '
      If Alta Then
         dtpFecha.Value = Today
      End If
      '
      nTipoMov = CapturaDato(Cn, "TipoMovBco", "TipoMovBco", "TipoMov = 'CH'")
      cImput = CapturaDato(Cn, "TipoMovBco", "Imput", "TipoMov = 'CH'")
      '
      With Cmd
         .Connection = Cn
         .CommandText = "SELECT * FROM OrdenPago WHERE OrdenPagoID = " & OrdenPagoId
         Drd = .ExecuteReader
      End With
      '
      With Drd
         If .Read Then
            dtpFecha.Value = !OPFecha
            tbNumero.Text = !OPNumero
            tbDetalle.Text = !OPDetalle
            tbTotal.Text = !OPTotal
            CmpInt = !OPTipo
            EstOP = !Estado
            FecPago = Today
            If !Proveedor = 0 Then
               Proveedor = 0
               CuentaProv = cfgCtaProvVarios
            Else
               cbProveedor = IIf(!Proveedor = 0, "(Varios)", CapturaDato(Cn, "Proveedores", "Nombre", "Codigo = " & !Proveedor))
               CuentaProv = CapturaDato(Cn, "Proveedores", "Cuenta", "Codigo = " & !Proveedor)
            End If
            tbEfectivo.Text = Format(Val(!OpEfectivo & ""), "Fixed")
            tbCheques.Text = Format(Val(!OpCheques & ""), "Fixed")
            'txtImpCaja = Format(Val(txtEfectivo) + Val(txtCheque), "Fixed")
            If Estado <> EstOP + 1 Then
               MensajeTrad("Estado de la OP incorrecto")
               DeshabForm(Me)
            End If
         End If
         .Close()
         Comprob = CmpInt & "-" & tbNumero.Text
         '
      End With
      '
      ActTmpCh()
      ActTmpOP()
      '
      'Adodc1.ConnectionString = Cn
      '
      If SisContable Then
         If CaptCtasConc(cfgCodigoInt, cDescInt, cCtaInt, "") Then
            If CaptCtasConc(cfgCodigoVCar, cDescVCar, "", cCtaVCar) Then
               CaptCtas = True
            End If
         End If
      End If
      '
      ActData()
      '
   End Sub
   '
   Private Sub frmOrdenPagoVs_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
      TabReturn(e.KeyChar)
   End Sub
   '
   Private Sub cboProveedor_Change()
      'PintarCb cboProveedor
   End Sub
   '
   Private Sub cbProveedor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbProveedor.SelectedIndexChanged
      '
      With cbProveedor
         If .SelectedIndex > 0 Then
            Proveedor = .SelectedValue
            CuentaProv = CapturaDato(Cn, "Proveedores", "Cuenta", "Codigo = " & Proveedor)
         Else
            Proveedor = 0
            CuentaProv = cfgCtaProvVarios
         End If
      End With
      '
      If SisContable Then
         If CuentaProv = "" Then
            MensajeTrad("CtaProvNoAsig")
            DeshabForm(Me)
         End If
      End If
      '
   End Sub
   '
   Private Sub chkComprob_Click()
      ActData()
   End Sub
   '
   Private Sub cmdAgregar_Click(sender As Object, e As EventArgs) Handles cmdAgregar.Click
      Dim Frm As New frmOrdenPagoVsAg
      With frm
         .TablaAct = cTmpOP
         .cmpInt = CmpInt
         .ShowDialog()
         ActData()
      End With
   End Sub
   '
   Private Sub DataGrid1_Click()
      With DataGridView1
         If .RowCount = 0 Then
            OpId = 0
         Else
            OpId = .SelectedCells(.Columns("OrdenPagoId").Index).Value
         End If
      End With
   End Sub
   '
   'Private Sub ActTemporal()
   '   Cn.BeginTrans
   '   Cn.Execute "DELETE FROM PagosDetTmp WHERE Usuario = '" & Uid & "'"
   '   Cn.Execute "INSERT INTO PagosDetTmp( Usuario, Fecha, Nombre, Proveedor, Sucursal, Numero, Comprob, Tipo, PerIva, Total, Propietario, Propiedad) " & _
   '              "SELECT '" & Uid & "' AS Usuario, C.Fecha, ISNULL(P.Nombre,'(Varios)'), D.Proveedor, D.ProSucursal, D.ProNumero, D.ProComprob, '', '', C.Total, " & IIf(cmpInt = "PO", "C.Propietario, C.Propiedad ", "NULL, NULL ") & _
   '              "FROM OrdenPagoDet D LEFT JOIN Proveedores P ON D.Proveedor = P.Codigo, " & IIf(cmpInt = "PO", "CompraOtr", "Compras") & " C " & _
   '              "WHERE D.OrdenPagoID = " & OrdenPagoId & _
   '              "  AND D.Proveedor = C.Proveedor" & _
   '              "  AND D.ProComprob = " & IIf(cmpInt = "PO", "C.Comprob", "LEFT(C.Comprob,3)") & _
   '              "  AND D.ProSucursal = C.Sucursal" & _
   '              "  AND D.ProNumero = C.Numero"
   '   Cn.CommitTrans
   'End Sub
   '
   Private Sub ActTmpCh()
      Trn = Cn.BeginTransaction
      With Cmd
         .Transaction = Trn
         .CommandText = "INSERT INTO " & cTmpCh & "( Origen, Banco, BancoCta, Titular, Numero, Fecha, Importe) " & _
                        "SELECT O.Origen, O.Banco, O.Cuenta, C.Titular, O.Numero, C.FechaDif, C.Importe " & _
                        "FROM OrdenPagoCh O, ChCartera C " & _
                        "WHERE O.Banco = C.Banco AND O.Cuenta = C.BancoCta AND O.Numero = C.ChCartNro " & _
                        "  AND O.OrdenPagoID = " & OrdenPagoId & " AND O.Origen = 'C' " & _
                        "UNION " & _
                        "SELECT O.Origen, O.Banco, O.Cuenta, '(PROPIO)' AS Titular, O.Numero, C.FechaAcr, C.Haber " & _
                        "FROM OrdenPagoCh O, BancosMov C " & _
                        "WHERE O.Banco = C.Banco AND O.Cuenta = C.BancoCta AND O.Numero = C.NroMovBco AND TipoMovBco = 1 " & _
                        "  AND O.OrdenPagoID = " & OrdenPagoId & " AND O.Origen = 'P'"
         .ExecuteNonQuery()
      End With
      Trn.Commit()
   End Sub
   '
   Private Sub ActTmpOP()
      Trn = Cn.BeginTransaction
      With Cmd
         .Transaction = Trn
         .CommandText = "INSERT INTO " & cTmpOP & "(OpNumero) " & _
                        "SELECT ProNumero " & _
                        "FROM OrdenPagoDet " & _
                        "WHERE OrdenPagoID = " & OrdenPagoId
         .ExecuteNonQuery()
      End With
      Trn.Commit()
   End Sub
   '
   Private Sub cbCaja_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCaja.SelectedIndexChanged
      With cbCaja
         If .SelectedIndex > 0 Then
            Caja = .SelectedValue
            If SisContable Then
               If Not CaptCtasCaja(Caja, cCtaCaja, cCtaCajaA) Then
                  cbCaja.SelectedIndex = -1
               End If
            End If
         Else
            Caja = 0
         End If
      End With
   End Sub
   '
   'Private Sub cmdModif_Click(sender As Object, e As EventArgs) Handles cmdModif.Click
   '   '
   '   With DataGridView1
   '      If .RowCount > 0 Then
   '         OpId = .SelectedCells(.Columns("OrdenPagoId").Index).Value
   '      End If
   '   End With
   '   '
   '   With frmOrdenPagoPago
   '      .Estado = EstConf
   '      .OrdenPagoId = OrdenPagoId
   '      .ShowDialog(Me)
   '      ActData()
   '   End With
   '   'Else
   '   '   With AmCompras
   '   '      .Proveedor = Adodc1.Recordset!Proveedor
   '   '      .Nombre = Adodc1.Recordset!Nombre
   '   '      .Sucursal = Adodc1.Recordset!Sucursal
   '   '      .Numero = Adodc1.Recordset!Numero
   '   '      '.OrdenPagoId = Me.OrdenPagoId
   '   '      .Alta = False
   '   '      '.Pagar = False
   '   '      .Show 1
   '   '   End With
   '   'End If
   '   'ActTemporal
   '   ActData()
   'End Sub
   '
   Private Sub cmdQuitar_Click(sender As Object, e As EventArgs) Handles cmdQuitar.Click
      '
      With DataGridView1
         If .RowCount > 0 Then
            OpId = .SelectedCells(.Columns("OrdenPagoId").Index).Value
            OpNro = .SelectedCells(.Columns("OPNumero").Index).Value
         End If
      End With
      '
      If MsgConfirma("Quita Orden de Pago N° " & OpNro) Then
         '
         Trn = Cn.BeginTransaction
         '
         With Cmd
            .Transaction = Trn
            .CommandText = "DELETE FROM " & cTmpOP & " WHERE OpNumero = " & OpNro
            .ExecuteNonQuery()
         End With
         '
         Trn.Commit()
         '
         ActData()
         '
      End If

   End Sub
   '
   Private Sub cmdCheques_Click(sender As Object, e As EventArgs) Handles cmdCheques.Click
      Dim Frm As New frmPagoCh
      With frm
         .TablaAct = cTmpCh
         .ShowDialog(Me)
         tbCheques.Text = .Total
      End With
   End Sub
   '
   Private Sub ActivaCtrl(Activo As Boolean)
      '
      'With Me
      '   .cbNombre.Enabled = Not Activo
      '   .cmdAceptar.Enabled = Not Activo And Alta
      '   .cmdSalir.Cancel = Not Activo
      '   .DataGrid1.Enabled = Activo
      '   .cmdAgregar.Enabled = Activo
      '   .cmdQuitar.Enabled = Activo And Alta
      '   '.frDetPago.Enabled = Activo
      '   .cmdGuardar.Enabled = Activo And Alta
      '   .cmdCancelar.Enabled = Activo
      '   .cmdCancelar.Cancel = Activo
      '   '.tbIntereses.Enabled = Activo
      'End With
      '
   End Sub
   '
   Private Sub LimpiaTemp()
      '
      Trn = Cn.BeginTransaction
      '
      With Cmd
         .Transaction = Trn
         .CommandText = "DELETE FROM PagosDetTmp WHERE Usuario = '" & Uid & "'"
         .ExecuteNonQuery()
      End With
      '
      Trn.Commit()
      '
   End Sub
   '
   Sub ActData()
      '
      'On Error Resume Next
      '
      Dim Sql As String
      '
      nTotal = 0
      nEfectivo = 0
      nCheques = 0
      '
      SetRegGrid(Me, DataGridView1)
      '
      Sql = "SELECT O.OrdenPagoId, O.OPFecha, P.Nombre, O.Proveedor, O.Sucursal, O.OpNumero, O.OPTotal, O.OpEfectivo, O.OpCheques, O.OpDetalle " & _
            "FROM " & cTmpOP & " T INNER JOIN OrdenPago O ON T.OpNumero = O.OpNumero " & _
            " LEFT JOIN Proveedores P ON O.Proveedor = P.Codigo " & _
            "ORDER BY O.OpFecha, O.OpNumero"
      '
      LlenarGrid(DataGridView1, Sql)
      '
      With DataGridView1
         cmdQuitar.Enabled = IIf(.RowCount = 0, False, (Estado = 3))
         'cmdModif.Enabled = IIf(.RowCount = 0, False, (Estado = 3))
      End With
      '
      nTotal = Val(CapturaDato(Cn, cTmpOP & " T, OrdenPago O", "SUM(O.OpTotal)", "T.OpNumero = O.OpNumero") & "")
      nEfectivo = Val(CapturaDato(Cn, cTmpOP & " T, OrdenPago O", "SUM(O.OpEfectivo)", "T.OpNumero = O.OpNumero") & "")
      nCheques = Val(CapturaDato(Cn, cTmpOP & " T, OrdenPago O", "SUM(O.OpCheques)", "T.OpNumero = O.OpNumero") & "")
      '
      SetCols()
      GetRegGrid(Me, DataGridView1)
      '
      CalcImportes()
      '
   End Sub
   '
   Private Sub SetCols()
      '
      With DataGridView1
         For Each cCol As DataGridViewColumn In .Columns
            With cCol
               Select Case UCase(.Name)
                  Case "OPNUMERO" : .Width = 100 : .HeaderText = "Número"
                  Case "OPFECHA" : .Width = 110 : .HeaderText = "Fecha"
                  Case "NOMBRE"
                     If CmpInt = "OP" Then
                        .Width = 250
                        .HeaderText = "Proveedor"
                     Else
                        cCol.Visible = False
                     End If
                  Case "NOMPROP"
                     If CmpInt = "PO" Then
                        .Width = 250
                        .HeaderText = "Propietario"
                     Else
                        .Visible = False
                     End If
                  Case "OPDETALLE" : .Width = 250 : .HeaderText = "Detalle"
                  Case "OPTOTAL" : .Width = 100 : .HeaderText = "Total"
                     With .DefaultCellStyle
                        .Format = "#,##0.00 "
                        .Alignment = DataGridViewContentAlignment.MiddleRight
                     End With
                  Case Else
                     cCol.Visible = False
               End Select
            End With
         Next cCol
      End With
      '
   End Sub
   '
   Private Sub tbIntereses_Change()
      CalcImportes()
   End Sub
   '
   Private Sub CalcImportes()
      tbTotal.Text = Format(nTotal, "Fixed")
      'txtEfectivo = Format(Val(nEfectivo & ""), "Fixed")
      'txtCheque = Format(Val(nCheques & ""), "Fixed")
      'txtImpCaja = Format(Val(txtEfectivo) + Val(txtCheque), "Fixed")
      'txtDevol = Format(Val(txtImpCaja) - nTotal - Val(txtChequeDev), "Fixed")
   End Sub
   '
   'Private Sub tbCheque_Change()
   '   If Val(tbCheque) = 0 Then
   '      ActCtrlBco False
   '   Else
   '      ActCtrlBco True
   '   End If
   'End Sub
   '
   'Private Sub ActCtrlBco(Activo As Boolean)
   '
   'With Me
   '   .cbDescBco.Enabled = Activo
   '   .cbCtaBco.Enabled = Activo
   '   .cbNroCheque.Enabled = Activo
   '   .tbFecCheque.Enabled = Activo
   'End With
   ''
   'End Sub
   '
   'Private Sub cbDescBco_Click()
   '
   'cbBanco.ListIndex = cbDescBco.ListIndex
   'cbCtaBco.Clear
   '
   'With rsCBco
   '   .Open "SELECT * FROM BancoCta WHERE Banco = " & Val(cbBanco), Cn, adOpenForwardOnly, adLockReadOnly
   '   '.Seek ">=", cbBanco, ""
   '   'If .NoMatch Then
   '   '   'No tiene cuentas.
   '   'Else
   '      'Do While !Banco = cbBanco
   '      Do Until .EOF
   '         cbCtaBco.AddItem !BancoCta
   '         .MoveNext
   '         'If .EOF Then Exit Do
   '      Loop
   '   'End If
   '   .Close
   'End With
   '
   'End Sub
   '
   Private Sub cmdConfirmar_Click(sender As Object, e As EventArgs) Handles cmdConfirmar.Click
      If ValidaDatos() Then
         If Guardar() Then
            GenRepOrdPago(CmpInt, prmSucursal, Val(tbNumero.Text), "ORDEN DE PAGO", crptToWindow)
            Me.Close()
         End If
      End If
   End Sub
   '
   Private Function ValidaDatos() As Boolean
      '
      If DataGridView1.RowCount < 2 Then
         MensajeTrad("DIMas1Item")
         Return False
      End If
      '
      If Val(tbTotal.Text) < 0 Then
         MensajeTrad("Total<0")
         Return False
      End If
      '
      If tbRecibe.Text = "" Then
         MensajeTrad("Debe Ingresar quien recibe")
         tbRecibe.Focus()
         Exit Function
      End If
      '
      If Format(Val(tbEfectivo.Text) + Val(tbCheques.Text), "Fixed") < Format(Val(tbTotal.Text), "Fixed") Then
         MensajeTrad("Importes de Pago menor que Total")
         tbEfectivo.Focus()
         Exit Function
      End If
      '
      If Caja = 0 Then
         MensajeTrad("DICaja")
         cbCaja.Focus()
         Exit Function
      End If
      '
      ValidaDatos = True
      '
   End Function
   '
   Private Function Guardar() As Boolean
      '
      Dim nRen As Integer
      Dim compCaja As String
      Dim cDetCaja As String
      Dim cCtaBanco As String
      Dim cBanco As String
      Dim CodAsi As String
      Dim NroAsi As Long
      Dim RenASi As Integer
      Dim DetAsi As String
      Dim cCtaProv As String
      Dim fPago As String
      Dim nRenCh As Integer
      Dim OPNumero As Long
      Dim nContFp As Integer
      '
      '*Try
      '
      Trn = Cn.BeginTransaction
      '
      If Alta Then
         BuscarCfg(cfgNroPago, "cfgNroPago", Trn)
         OPNumero = cfgNroPago + 1
         GuardarCfg(cfgNroPago, "cfgNroPago", OPNumero, Trn)
      End If
      '
      compCaja = CmpInt & "-" & OPNumero
      CodAsi = compCaja
      DetAsi = cbProveedor.Text
      '
      With Cmd
         .Transaction = Trn
         If Alta Then
            .CommandText = "INSERT INTO OrdenPago( Sucursal, OPNumero, OPTipo, OPFecha, Proveedor, OPTotal, OpEfectivo, OpCheques, OPDetalle, Estado, OPUid, OPFecMod) " & _
                           "VALUES(" & prmSucursal & ", " & _
                                       OPNumero & ", " & _
                                 "'" & CmpInt & "', " & _
                                 "'" & Format(dtpFecha.Value, FormatFecha) & "', " & _
                                       Proveedor & ", " & _
                                       nTotal & ", " & _
                                       Val(tbEfectivo.Text) & ", " & _
                                       Val(tbCheques.Text) & ", " & _
                                 "'" & tbDetalle.Text & "', " & _
                                       EstConf & ", " & _
                                 "'" & Uid & "', " & _
                                 "'" & Format(Now, FormatFechaHora) & "')"
            OrdenPagoId = CapturaDato(Cn, "OrdenPago", "MAX(OrdenPagoId)", "", , , , Trn)
         Else
            .CommandText = "UPDATE OrdenPago SET " & _
                           " Sucursal = " & prmSucursal & ", " & _
                           " OpNumero = " & OPNumero & ", " & _
                           " OPTipo = '" & CmpInt & "', " & _
                           " OPFecha = '" & Format(dtpFecha.Value, FormatFecha) & "', " & _
                           " Proveedor = " & Proveedor & ", " & _
                           " OPTotal = " & nTotal & ", " & _
                           " OpEfectivo = " & Val(tbEfectivo.Text) & ", " & _
                           " OpCheques = " & Val(tbCheques.Text) & ", " & _
                           " OPDetalle = '" & tbDetalle.Text & "', " & _
                           " Estado = " & EstConf & ", " & _
                           " OPUid = '" & Uid & "', " & _
                           " OPFecMod = '" & Format(Now, FormatFechaHora) & "' " & _
                           "WHERE OrdenPagoId = " & OrdenPagoId
         End If
         .ExecuteNonQuery()
         '
         .CommandText = "UPDATE OrdenPago SET " & _
                        " Estado = " & EstAgrup & ", " & _
                        " OpUid = '" & Uid & "', " & _
                        " OpFecMod = '" & Format(Now, FormatFechaHora) & "' " & _
                        "WHERE OpNumero IN( SELECT OpNumero FROM " & cTmpOP & ")"
         .ExecuteNonQuery()
         '
         .CommandText = "INSERT INTO OrdenPagoDet( OrdenPagoId, Proveedor, ProComprob, ProSucursal, ProNumero, OPDUid, OPDFecMod) " & _
                        "SELECT " & OrdenPagoId & ", 0, '" & CmpInt & "', " & prmSucursal & ", OPNumero, '" & Uid & "', '" & Format(Now, FormatFechaHora) & "' " & _
                        "FROM " & cTmpOP
         .ExecuteNonQuery()
         '
      End With
      '
      'With Adodc1.Recordset
      '   .MoveFirst()
      '   Do While Not .EOF
      '      nRen = nRen + 1
      '      Rs.Open("SELECT * FROM OrdenPagoDet WHERE OrdenPagoID = 0", Cn, adOpenKeyset, adLockOptimistic)
      '      Rs.AddNew()
      '      Rs!OrdenPagoId = OrdenPagoId
      '      Rs!Proveedor = !Proveedor
      '      Rs!ProComprob = CmpInt
      '      Rs!ProSucursal = regSucursal
      '      Rs!ProNumero = !OPNumero
      '      Rs!OPDUid = Uid
      '      Rs!OPDFecMod = Now
      '      Rs.Update()
      '      Rs.Close()
      '      '
      If SisContable Then
         NroAsi = GuardaAsiento(compCaja, Today, DetAsi, Trn)
         BorraAsienDet(NroAsi, Trn)
         '
         RenASi = RenASi + 1
         If Not GuardaAsienDet(NroAsi, RenASi, CuentaProv, DetAsi, Val(tbTotal.Text), 0, Trn) Then
            Err.Raise(1001, , "NoUpAsiDet")
         End If
      End If
      '
      If Val(tbEfectivo.Text) > 0 Then
         fPago = "EF"
         nContFp = 1
         Do While Not IsNothing(CapturaDato(Cn, "Caja", "Comprob", "Comprob = '" & compCaja & "' AND FPago = '" & fPago & "'", , , , Trn))
            nContFp = nContFp + 1
            fPago = "EF" & nContFp
         Loop
         '
         GuardarCaja(True, False, CmpInt, Caja, False, 0, tbEfectivo.Text, fPago, Today, tbRecibe.Text, cDetCaja, cCtaProv, 0, cCtaCaja, Trn, compCaja)
         '
         If SisContable Then
            RenASi = RenASi + 1
            GuardaAsienDet(NroAsi, RenASi, cCtaCaja, tbDetalle.Text, 0, Val(tbEfectivo.Text), Trn)
         End If
      End If
      '
      If Val(tbCheques.Text) > 0 Then
         '
         Cm2.Connection = Cn
         Cm2.Transaction = Trn
         '
         With Cmd
            '
            '.CommandText = "INSERT INTO OrdenPagoCH( OrdenPagoId, OpcRenglon, Origen, Banco, Cuenta, Numero, OPCUid, OPCFecMod) " & _
            '               "SELECT " & OrdenPagoId & ", Renglon, Origen, Banco, BancoCta, Numero, '" & Uid & "', '" & Format(Now, FormatFechaHora) & "' " & _
            '               "FROM " & cTmpCh
            '.ExecuteNonQuery()
            '
            .CommandText = "SELECT * FROM " & cTmpCh
            Drd = .ExecuteReader
            '
            With Drd
               Do While .Read
                  nRen = nRen + 1
                  Cm2.CommandText = "INSERT INTO OrdenPagoCH( OrdenPagoId, OPCRenglon, Origen, Banco, Cuenta, Numero, OPCUid, OPCFecMod) " & _
                                    "VALUES( " & OrdenPagoId & ", " & _
                                                 nRen & ", " & _
                                           "'" & !Origen & "', " & _
                                                 !Banco & ", " & _
                                           "'" & !BancoCta & "', " & _
                                           "'" & !Numero & "', " & _
                                           "'" & Uid & "', " & _
                                           "'" & Format(Now, FormatFechaHora) & "')"
                  Cm2.ExecuteNonQuery()
                  '
                  cCtaBanco = CapturaDato(Cn, "BancoCta", "CtaCont", "Banco = " & !Banco & " AND BancoCta = '" & !BancoCta & "'", , , , Trn) & ""
                  cBanco = CapturaDato(Cn, "Bancos", "Nombre", "Banco = " & !Banco, , , , Trn) & ""
                  If !Origen = "C" Then
                     nRenCh = 1
                     fPago = "CH"
                     Do While Not IsNothing(CapturaDato(Cn, "Caja", "Comprob", "Comprob = '" & compCaja & "' AND FPago = '" & fPago & "'", , , , Trn))
                        nRenCh = nRenCh + 1
                        fPago = "CH" & nRenCh
                     Loop
                     cDetCaja = "CH. " & cBanco & " CTA:" & !BancoCta & ", Nº" & !Numero & ", Al:" & !Fecha
                     '
                     If Not ActCaja(Caja, compCaja, fPago, Today, tbRecibe.Text, "", cDetCaja, 0, !Import, , Trn) Then
                        Err.Raise(1001)
                     End If
                     '
                  End If
                  '
                  'Detalle Asiento (Banco/Ch.Cartera).
                  If SisContable Then
                     RenASi = RenASi + 1
                     If Not GuardaAsienDet(NroAsi, RenASi, IIf(!Origen = "P", cCtaBanco, cCtaVCar), DetAsi, 0, !Importe) Then
                        Err.Raise(1001, , Traducir("NoUpAsiento"))
                     End If
                  End If
                  '
                  If !Origen = "P" Then
                     If Not IsNothing(CapturaDato(Cn, "BancosMov", "Numero", "Banco = " & !Banco & " AND BancoCta = '" & !BancoCta & "' AND TipoMovBco = " & nTipoMov & " AND Numero = " & !Numero, , , , Trn)) Then
                        Err.Raise(1001, , Traducir("MovBcoExiste"))
                     End If
                     Cm2.CommandText = "INSERT INTO BancosMov( Banco, BancoCta, TipoMovBco, Numero, FechaEmi, FechaAcr, Debe, Haber, Detalle, Estado, HojaBco, Usuario, FechaMod) " & _
                                       "VALUES(" & !Banco & ", " & _
                                             "'" & !BancoCta & "', " & _
                                                   nTipoMov & ", " & _
                                                   !Numero & ", " & _
                                             "'" & Format(Today, FormatFecha) & "', " & _
                                             "'" & Format(!Fecha, FormatFecha) & "', " & _
                                                   IIf(cImput = "D", !Importe, 0) & ", " & _
                                                   IIf(cImput = "H", !Importe, 0) & ", " & _
                                             "'" & compCaja & " - " & DetAsi & "', " & _
                                                   estEMIT & ", " & _
                                                   0 & ", " & _
                                             "'" & Uid & "', " & _
                                             "'" & Format(Now, FormatFechaHora) & "')"
                     Cm2.ExecuteNonQuery()
                     '
                     If IsNothing(CapturaDato(Cn, "ChPropios", "Numero", "Banco = " & !Banco & " AND BancoCta = '" & !BancoCta & "' AND TipoMovBco = " & nTipoMov & " AND Numero = " & !Numero, , , , Trn)) Then
                        Cm2.CommandText = "INSERT INTO ChPropios( Banco, BancoCta, TipoMovBco, Numero, Estado, Usuario, FechaMod) " & _
                                          "VALUES( " & !Banco & ", " & _
                                                 "'" & !BancoCta & "', " & _
                                                       nTipoMov & ", " & _
                                                       !Numero & ", " & _
                                                       estEMIT & ", " & _
                                                 "'" & Uid & "', " & _
                                                 "'" & Format(Now, FormatFechaHora) & "')"
                     Else
                        Cm2.CommandText = "UPDATE ChPropios SET " & _
                                          " Estado = " & estEMIT & ", " & _
                                          " Usuario = '" & Uid & "', " & _
                                          " FechaMod = '" & Format(Now, FormatFechaHora) & "' " & _
                                          "WHERE Banco = " & !Banco & " AND BancoCta = '" & !BancoCta & "' AND TipoMovBco = " & nTipoMov & " AND Numero = " & !Numero
                     End If
                     Cm2.ExecuteNonQuery()
                     '
                  Else
                     If IsNothing(CapturaDato(Cn, "Chcartera", "Numero", "Banco = " & !Banco & " AND BancoCta = '" & !BancoCta & "' AND Numero = " & !Numero, , , , Trn)) Then
                        Err.Raise(1001, , Traducir("ChNoEnc"))
                     Else
                        Cm2.CommandText = "UPDATE Chcartera SET " & _
                                         " Estado = 2, " & _
                                         " Usuario = '" & Uid & "', " & _
                                         " FechaMod = '" & Format(Now, FormatFechaHora) & "' " & _
                                         "WHERE Banco = " & !Banco & " AND BancoCta = '" & !BancoCta & "' AND Numero = " & !Numero
                        Cm2.ExecuteNonQuery()
                     End If
                  End If
                  '
               Loop
               '
               .Close()
               '
            End With
            '
         End With
      End If
      '
      GuardarAudit(IIf(Estado = 2, "Guarda", IIf(Estado = 3, "Paga", "Rinde")) & " Orden de Pago Vs.", compCaja, Me.Name, Me.cmdConfirmar.Text, Trn)
      '
      Trn.Commit()
      '
      Return True
      '
      'mError:
      '      MsgBox(Err.Number & ": " & Err.Description & Chr(13) & Chr(10) & _
      '             Traducir("TransNComp"))
      '      Cn.RollbackTrans()
      '
   End Function
   '
   Private Sub tbCheques_TextChanged(sender As Object, e As EventArgs) Handles tbCheques.TextChanged
      CalcImportes()
   End Sub
   '
   Private Sub txtChequeDev_Change()
      CalcImportes()
   End Sub
   '
   Private Sub txtDevol_Change()
      CalcImportes()
   End Sub
   '
   Private Sub tbEfectivo_TextChanged(sender As Object, e As EventArgs) Handles tbEfectivo.TextChanged
      CalcImportes()
   End Sub
   '
   Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
      Me.Close()
   End Sub
   '
   Private Sub frmOrdenPagoVs_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
      SetRegGrid(Me, DataGridView1)
      SetRegForm(Me)
   End Sub
   '
End Class