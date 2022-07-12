Public Class frmOrdenPagoPago
   '
   Public Estado As Byte = 0
   Public OrdenPagoId As Int32 = 0
   Public PagoDir As Boolean = False
   Public cmpInt As String = ""
   Public Proveedor As Int32 = 0
   Public Comprob As String = ""
   Public Sucursal As Int16 = 0
   Public Numero As Int32 = 0
   '
   Dim Trn As OleDb.OleDbTransaction
   Dim Cmd As New OleDb.OleDbCommand
   Dim Cm2 As New OleDb.OleDbCommand
   Dim Drd As OleDb.OleDbDataReader
   '
   Dim TablaCmp As String
   Dim nTotal As Double
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
   '
   Dim EstOP As String
   Dim vGtosBanc As Double
   '
   Dim cTmp As String
   Dim cTmpCh As String
   Dim cTmpTr As String
   Dim cTmpDev As String
   '
   Const cStruct = "Nombre VARCHAR(250) NULL, " & _
                   "Proveedor INT NOT NULL, " & _
                   "Comprob VARCHAR(50) NOT NULL, " & _
                   "Sucursal SMALLINT NOT NULL, " & _
                   "Numero INT NOT NULL, " & _
                   "Propietario INT NULL, " & _
                   "Propiedad INT NULL, " & _
                   "Total FLOAT NOT NULL"
   '
   Const cStructCh = "Origen VARCHAR (1), " & _
                     "Banco INT, " & _
                     "DescBco VARCHAR(250), " & _
                     "Cuenta VARCHAR(50), " & _
                     "Titular VARCHAR(50), " & _
                     "Numero VARCHAR(50), " & _
                     "Fecha SMALLDATETIME, " & _
                     "Importe FLOAT, " & _
                     "Usuario VARCHAR(5), " & _
                     "CtaCont VARCHAR(20)"
   '
   Const cStructTr = "Banco0 INT NOT NULL, " & _
                     "Cuenta0 VarChar(50) NOT NULL, " & _
                     "Banco1 INT NOT NULL, " & _
                     "Cuenta1 VarChar(50) NOT NULL, " & _
                     "Titular VarChar(50) NOT NULL, " & _
                     "FechaTR SmallDateTime NOT NULL, " & _
                     "NumeroTR VarChar(25) NOT NULL, " & _
                     "ImporteTR FLOAT NOT NULL, " & _
                     "GastosImp FLOAT NULL, " & _
                     "GastosSF FLOAT NULL, " & _
                     "GastosIva FLOAT NULL, " & _
                     "ImporteNeto FLOAT NOT NULL"
   '
   Const EstConf = 2
   Const EstPagado = 3
   Const estRendido = 4
   Const estEMIT = 1
   '
   Private Sub frmOrdenPagoPago_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      '
      GetRegForm(Me)
      '
      TraducirForm(Me)
      '
      If PagoDir Then
         Me.Text = "Pago Directo"
         dtpFecha.Value = Today
         tbEfectivo.Enabled = True
         tbEfectivo.BackColor = Color.White
         cmdCheques.Enabled = True
         cmdTransf.Enabled = True
      Else
         If Estado = EstConf Then
            Me.Text = "Confirmar Orden de Pago"
            cboCaja.Enabled = False
            tbEfectivo.Enabled = False
            cmdCheques.Enabled = False
            cmdTransf.Enabled = False
            cmdPagar.Text = "&Guardar"
         ElseIf Estado = EstPagado Then
            Me.Text = "Pagar Orden de Pago"
            cboCaja.Enabled = False
            tbEfectivo.Enabled = False
            cmdCheques.Enabled = False
            cmdTransf.Enabled = False
            cmdPagar.Text = "&Pagar"
         ElseIf Estado = estRendido Then
            Me.Text = "Rendir Orden de Pago"
            cmdPagar.Text = "&Rendir"
            cmdModif.Enabled = False
            cmdQuitar.Enabled = False
         Else
            Mensaje("Estado de la OP incorrecto")
            DeshabForm(Me)
         End If
      End If
      '
      If cmpInt = "PC" Or cmpInt = "OP" Then
         TablaCmp = "Compras"
      Else
         TablaCmp = "CompraOtr"
      End If
      '
      cTmp = ""
      CrearTabla(Cn, cStruct, cTmp)
      '
      cTmpCh = ""
      CrearTabla(Cn, cStructCh, cTmpCh)
      '
      cTmpTr = ""
      CrearTabla(Cn, cStructTr, cTmpTr)
      '
      cTmpDev = ""
      CrearTabla(Cn, cStruct, cTmpDev)
      '
      ArmaComboItem(Me.cboCaja, "Cajas", "Caja", , , "(Seleccionar)", "Caja <> 0")
      PosicionarComboItem(cboCaja, prmNroCaja)
      '
      nTipoMov = CapturaDato(Cn, "TipoMovBco", "TipoMovBco", "TipoMov = 'CH'")
      cImput = CapturaDato(Cn, "TipoMovBco", "Imput", "TipoMov = 'CH'")
      '
      Cmd.Connection = Cn
      '
      If PagoDir Then
         Proveedor = CapturaDato(Cn, "PagosDetTmp", "Proveedor", "Usuario = '" & Uid & "'")
         tbProveedor.Text = CapturaDato(Cn, "Proveedores", "Nombre", "Codigo = " & Proveedor)
         CuentaProv = CapturaDato(Cn, "Proveedores", "Cuenta", "Codigo = " & Proveedor)
         tbImpCaja.Text = Format(CapturaDato(Cn, "PagosDetTmp", "Total", "Usuario = '" & Uid & "'"), "Fixed")
      Else
         With Cmd
            .CommandText = "SELECT * FROM OrdenPago WHERE OrdenPagoID = " & OrdenPagoId
            Drd = .ExecuteReader
         End With
         With Drd
            If .Read Then
               dtpFecha.Value = !OPFecha
               tbNumero.Text = !OPNumero
               tbDetalle.Text = !OPDetalle
               tbTotal.Text = !OPTotal
               cmpInt = !OPTipo
               EstOP = !Estado
               FecPago = Today
               If !Proveedor = 0 Then
                  tbProveedor.Text = "(Varios)"
                  CuentaProv = cfgCtaProvVarios
               Else
                  tbProveedor.Text = IIf(!Proveedor = 0, "(Varios)", CapturaDato(Cn, "Proveedores", "Nombre", "Codigo = " & !Proveedor))
                  CuentaProv = CapturaDato(Cn, "Proveedores", "Cuenta", "Codigo = " & !Proveedor)
               End If
               tbEfectivo.Text = Format(Val(!OpEfectivo & ""), "Fixed")
               tbCheques.Text = Format(Val(!OPCheques & ""), "Fixed")
               tbTransf.Text = Format(Val(!OpTransf & ""), "Fixed")
            End If
            .Close()
            Comprob = cmpInt & "-" & tbNumero.Text
            tbImpCaja.Text = Format(Val(tbEfectivo.Text) + Val(tbCheques.Text), "Fixed")
            tbRecibio.Text = CapturaDato(Cn, "Caja", "Nombre", "Comprob = '" & Comprob & "'")
            If EstOP = 6 Then
               cmdPagar.Enabled = False
            Else
               If Estado <> EstOP + 1 Then
                  MensajeTrad("Estado de la OP incorrecto")
                  DeshabForm(Me)
               End If
            End If
         End With
         '
      End If
      '
      ActTemporal()
      '
      If Not PagoDir Then
         ActTmpCh()
      End If
      '
      cmdGuardar.Enabled = (Estado = 3)
      '
      If CaptCtasConc(cfgCodigoInt, cDescInt, cCtaInt, "") Then
         If CaptCtasConc(cfgCodigoVCar, cDescVCar, "", cCtaVCar) Then
            CaptCtas = True
         End If
      End If
      '
      If SisContable Then
         If CuentaProv = "" Then
            MensajeTrad("CtaProvNoAsig")
            DeshabForm(Me)
         End If
      End If
      '
      ActData()
      '
   End Sub
   '
   Private Sub frmOrdenPagoPago_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
      TabReturn(e.KeyChar)
   End Sub
   '
   Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
      'With DataGridView1
      '   If .RowCount > 0 Then
      '      OpId = .SelectedCells(.Columns("OrdenPagoId").Index).Value
      '   Else
      '      OpId = 0
      '   End If
      'End With
   End Sub
   '
   Private Sub ActTemporal()
      '
      Trn = Cn.BeginTransaction
      '
      With Cmd
         .Transaction = Trn
         '
         .CommandText = "DELETE FROM " & cTmp
         .ExecuteNonQuery()
         '
         If PagoDir Then
            .CommandText = "INSERT INTO " & cTmp & "( Nombre, Proveedor, Sucursal, Numero, Comprob, Propietario, Propiedad, Total) " & _
                           "SELECT Nombre, Proveedor, Sucursal, Numero, Comprob, Propietario, Propiedad, Total " & _
                           "FROM CompraOtr " & _
                           "WHERE Proveedor = " & Proveedor & _
                           "  AND Comprob = '" & Comprob & "' " & _
                           "  AND Sucursal = " & Sucursal & _
                           "  AND Numero = " & Numero
         Else
            .CommandText = "INSERT INTO " & cTmp & "( Nombre, Proveedor, Sucursal, Numero, Comprob, Propietario, Propiedad, Total) " & _
                           "SELECT ISNULL( P.Nombre, '(Varios)'), D.Proveedor, D.ProSucursal, D.ProNumero, D.ProComprob, " & IIf(cmpInt = "PO", "C.Propietario, C.Propiedad", "NULL, NULL") & ", C.Total " & _
                           "FROM OrdenPagoDet D LEFT JOIN Proveedores P ON D.Proveedor = P.Codigo, " & TablaCmp & " C " & _
                           "WHERE D.OrdenPagoID = " & OrdenPagoId & _
                           "  AND D.Proveedor = C.Proveedor" & _
                           "  AND D.ProComprob = " & IIf(cmpInt = "PO", "C.Comprob", "LEFT(C.Comprob,3)") & _
                           "  AND D.ProSucursal = C.Sucursal" & _
                           "  AND D.ProNumero = C.Numero " & _
                           "UNION " & _
                           "SELECT ISNULL( P.Nombre, '(Varios)'), D.Proveedor, D.ProSucursal, D.ProNumero, D.ProComprob, NULL, NULL, C.OpTotal " & _
                           "FROM OrdenPagoDet D LEFT JOIN Proveedores P ON D.Proveedor = P.Codigo, OrdenPago C " & _
                           "WHERE D.OrdenPagoID = " & OrdenPagoId & _
                           "  AND D.ProComprob = '" & cmpInt & "'" & _
                           "  AND D.ProNumero = C.OpNumero"
         End If
         .ExecuteNonQuery()
      End With
      '
      Trn.Commit()
      '
   End Sub
   '
   Private Sub ActTmpCh()
      Trn = Cn.BeginTransaction
      With Cmd
         .Transaction = Trn
         .CommandText = "INSERT INTO " & cTmpCh & "( Origen, Banco, Cuenta, Titular, Numero, Fecha, Importe) " & _
                        "SELECT O.Origen, O.Banco, O.Cuenta, C.Titular, O.Numero, C.FechaDif, C.Importe " & _
                        "FROM OrdenPagoCh O, ChCartera C " & _
                        "WHERE O.Banco = C.Banco AND O.Cuenta = C.BancoCta AND O.Numero = C.ChCartNro " & _
                        "  AND O.OrdenPagoID = " & OrdenPagoId & " AND O.Origen = 'C' " & _
                        "UNION " & _
                        "SELECT O.Origen, O.Banco, O.Cuenta, '(PROPIO)' AS Titular, O.Numero, C.FechaAcr, C.Haber " & _
                        "FROM OrdenPagoCh O, BancosMov C " & _
                        "WHERE O.Banco = C.Banco AND O.Cuenta = C.BancoCta AND O.Numero = C.NroMovBco AND C.TipoMovBco = 1 " & _
                        "  AND O.OrdenPagoID = " & OrdenPagoId & " AND O.Origen = 'P'"
         .ExecuteNonQuery()
      End With
      Trn.Commit()
   End Sub
   '
   Private Sub cboCaja_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCaja.SelectedIndexChanged
      With cboCaja
         If .SelectedIndex > 0 Then
            Caja = .SelectedValue
            If SisContable Then
               If Not CaptCtasCaja(Caja, cCtaCaja, cCtaCajaA) Then
                  cboCaja.SelectedIndex = -1
                  Caja = 0
               End If
            End If
         Else
            Caja = 0
         End If
      End With
   End Sub
   '
   Private Sub cmdModif_Click(sender As Object, e As EventArgs) Handles cmdModif.Click
      '
      With DataGridView1
         '
         If .RowCount > 0 Then
            '
            Dim CompraId As Int32 = .SelectedCells(.Columns("CompraId").Index).Value
            Dim Proveedor As Int32 = .SelectedCells(.Columns("Proveedor").Index).Value
            Dim Comprob As String = .SelectedCells(.Columns("Comprob").Index).Value & ""
            Dim Sucursal As Int16 = .SelectedCells(.Columns("Sucursal").Index).Value
            Dim Numero As Int32 = .SelectedCells(.Columns("Numero").Index).Value()
            Dim Nombre As String = .SelectedCells(.Columns("Nombre").Index).Value & ""
            Dim Propiedad As Int32 = Val(.SelectedCells(.Columns("Propiedad").Index).Value & "")
            '
            If .SelectedCells(.Columns("Comprob").Index).Value = cmpInt Then
               Dim frm As New frmOrdenPagoPago
               With frm
                  .Estado = Estado
                  .OrdenPagoId = CapturaDato(Cn, "OrdenPago", "OrdenPagoId", "OpNumero=" & Numero)
                  .ShowDialog(Me)
               End With
            Else
               If cmpInt = "PO" Then
                  Dim frm As New frmComprasOtrAM
                  With frm
                     .Proveedor = Proveedor
                     .Comprob = Comprob
                     .Sucursal = Sucursal
                     .Numero = Numero
                     .Propied = Propiedad
                     .OrdenPagoId = OrdenPagoId
                     .Alta = False
                     .Pagar = False
                     .ShowDialog(Me)
                  End With
               Else
                  Dim frm As New frmComprasAM
                  With frm
                     .Proveedor = Proveedor
                     .CompraID = CompraId
                     .OrdenPagoId = OrdenPagoId
                     .Alta = False
                     '.Pagar = False
                     .ShowDialog(Me)
                  End With
               End If
            End If
         End If
      End With
      '
      ActTemporal()
      ActData()
      '
   End Sub
   '
   Private Sub cmdQuitar_Click(sender As Object, e As EventArgs) Handles cmdQuitar.Click
      '
      With DataGridView1
         If .RowCount > 0 Then
            '
            Dim Proveedor As Int32 = .SelectedCells(.Columns("Proveedor").Index).Value
            Dim Comprob As String = .SelectedCells(.Columns("Comprob").Index).Value & ""
            Dim Sucursal As Int16 = .SelectedCells(.Columns("Sucursal").Index).Value
            Dim Numero As Int32 = .SelectedCells(.Columns("Numero").Index).Value()
            Dim Tipo As String = .SelectedCells(.Columns("Tipo").Index).Value & ""

            If DaDeBaja(Comprob & " - " & Tipo & " N° " & Sucursal & "-" & Numero & " Prov.: " & Proveedor) Then
               Trn = Cn.BeginTransaction
               With Cmd
                  .Transaction = Trn
                  .CommandText = "DELETE FROM " & cTmp & " WHERE Comprob = '" & Comprob & "' AND Sucursal = " & Sucursal & " AND Numero = " & Numero & " AND Proveedor = " & Proveedor
                  .ExecuteNonQuery()
               End With
               Trn.Commit()
            End If
            '
         End If
      End With
      '
      ActData()
      '
   End Sub
   '
   Private Sub cmdCheques_Click(sender As Object, e As EventArgs) Handles cmdCheques.Click
      If PagoDir Then
         Dim Frm As New frmPagoCh
         With Frm
            .TablaAct = cTmpCh
            .Titulo = "Confirmar Orden de Pago"
            .ShowDialog()
            tbCheques.Text = .Total
         End With
      Else
         Dim Frm As New frmOrdenPagoChDev
         With frm
            .TablaTmp = cTmpCh
            .TablaDev = cTmpDev
            .ShowDialog(Me)
            tbCheques.Text = Format(.Total + .TotalDev, "Fixed")
            tbDevolCh.Text = Format(.TotalDev, "Fixed")
         End With
      End If
   End Sub
   '
   Private Sub cmdTransf_Click(sender As Object, e As EventArgs) Handles cmdTransf.Click
      Dim Frm As New frmLiqTransf
      With frm
         .TablaTmp = cTmpTr
         .TransfRec = False
         .ShowDialog(Me)
         tbTransf.Text = Format(.Total, "Fixed")
         vGtosBanc = .GtosBanc
      End With
   End Sub
   '
   Private Sub LimpiaTemp()
      Trn = Cn.BeginTransaction
      With Cmd
         .Transaction = Trn
         .CommandText = "DELETE FROM " & cTmp
         .ExecuteNonQuery()
      End With
      Trn.Commit()
   End Sub
   '
   Private Sub chkComprob_Click()
      ActData()
   End Sub
   '
   Sub ActData()
      '
      On Error Resume Next
      '
      nTotal = 0
      '
      SetRegGrid(Me, DataGridView1)
      '
      LlenarGrid(DataGridView1, "SELECT C.Fecha, C.Nombre, T.Proveedor, PR.Nombre AS NomProv, T.Sucursal, T.Numero, T.Comprob, " & IIf(cmpInt = "PO", "''", "C.Tipo") & " AS Tipo, " & IIf(cmpInt = "PO", "''", "C.PerIva") & " AS PerIVA, C.Total, P.Nombre AS NomProp, R.Domicilio, D.Detalle, R.Codigo AS Propiedad, " & IIf(cmpInt = "PO", "0", "C.CompraId") & " AS CompraId " & _
                                "FROM " & cTmp & " T LEFT JOIN Propietarios P ON T.Propietario = P.Codigo LEFT JOIN Propiedades R ON T.Propiedad = R.Codigo " & _
                                " LEFT JOIN " & IIf(cmpInt = "PO", "CompraOtr", "Compras") & " C " & _
                                "  ON C.Proveedor = T.Proveedor " & IIf(cmpInt = "PO", "AND C.Comprob = T.Comprob", "") & _
                                " AND C.Sucursal = T.Sucursal AND C.Numero = T.Numero " & _
                                " LEFT JOIN " & IIf(cmpInt = "PO", "CompraOtrDet", "ComprasDet") & " D " & _
                                "  ON D.Proveedor = T.Proveedor " & IIf(cmpInt = "PO", "AND D.Comprob = T.Comprob", "") & _
                                " AND D.Sucursal = T.Sucursal AND D.Numero = T.Numero AND D.Renglon = 1 " & _
                                " LEFT JOIN Proveedores PR ON T.Proveedor = PR.Codigo " & _
                                "ORDER BY C.Fecha, C.Nombre")
      '
      With DataGridView1
         cmdQuitar.Enabled = IIf(.RowCount = 0, False, (Estado = 3))
         cmdModif.Enabled = IIf(.RowCount = 0, False, (Estado = 3))
      End With
      '
      nTotal = CapturaDato(Cn, cTmp, "ISNULL(SUM(Total),0)", "")
      '
      SetCols()
      GetRegGrid(Me, DataGridView1)
      '
      CalcImportes()
      '
   End Sub
   '
   Private Sub SetCols()
      With DataGridView1
         For Each Col As DataGridViewColumn In .Columns
            With Col
               Select Case UCase(.Name)
                  Case "COMPROB" : .HeaderText = "Cpte."
                  Case "TIPO"
                     If cmpInt = "PO" Then
                        .Visible = False
                     End If
                  Case "SUCURSAL"
                  Case "NUMERO"
                  Case "FECHA"
                  Case "PERIVA" : .HeaderText = "Per.Iva."
                     If cmpInt = "PO" Then
                        .Visible = False
                     End If
                  Case "NOMPROV" : .HeaderText = "Proveedor"
                  Case "NOMPROP"
                     If cmpInt = "PO" Then
                        .HeaderText = "Propietario"
                     Else
                        .Visible = False
                     End If
                  Case "DOMICILIO"
                     If cmpInt = "PO" Then
                        .HeaderText = "Propiedad"
                     Else
                        .Visible = False
                     End If
                  Case "DETALLE"
                  Case "TOTAL"
                     With .DefaultCellStyle
                        .Format = "#,##0.00 "
                        .Alignment = DataGridViewContentAlignment.MiddleRight
                     End With
                  Case Else
                     .Visible = False
               End Select
            End With
         Next Col
      End With
   End Sub
   '
   Private Sub tbEfectivo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbEfectivo.KeyPress
      SoloNumeros(e.KeyChar, True)
   End Sub
   '
   Private Sub tbEfectivo_TextChanged(sender As Object, e As EventArgs) Handles tbEfectivo.TextChanged
      CalcImportes()
   End Sub
   '
   Private Sub CalcImportes()
      tbTotal.Text = Format(nTotal, "Fixed")
      tbImpCaja.Text = Format(Val(tbEfectivo.Text) + Val(tbCheques.Text), "Fixed")
      If Not PagoDir Then
         tbDevolEf.Text = Format(Val(tbTransf.Text) + Val(tbImpCaja.Text) - nTotal - Val(tbDevolCh.Text), "Fixed")
      End If
   End Sub
   '
   Private Sub cmdGuardar_Click(sender As Object, e As EventArgs) Handles cmdGuardar.Click
      If ValidaDatos() Then
         If Guardar(Estado - 1) Then
            Me.Close()
         End If
      End If
   End Sub
   '
   Private Sub cmdPagar_Click(sender As Object, e As EventArgs) Handles cmdPagar.Click
      If ValidaDatos() Then
         If PagoDir Then
            If GuardarOrdenPago(True, "PO", Proveedor, Today, Val(tbTotal.Text), Val(tbEfectivo.Text), Val(tbCheques.Text), Val(tbTransf.Text), vGtosBanc, Traducir("PagoDirOtr") & ". " & tbDetalle.Text, 0, Caja, "", cTmp, cTmpCh, cTmpTr, estRendido, True) Then
               Me.Close()
            End If
         Else
            If Guardar(Estado) Then
               GenRepOrdPago(cmpInt, prmSucursal, Val(tbNumero.Text), "ORDEN DE PAGO", crptToWindow)
               Me.Close()
            End If
         End If
      End If
   End Sub
   '
   Private Function ValidaDatos() As Boolean
      '
      If Val(tbTotal.Text) < 0 Then
         MensajeTrad("Total<0")
         Return False
      End If
      '
      If PagoDir Then
         If Format(Val(tbEfectivo.Text) + Val(tbCheques.Text) + Val(tbTransf.Text), "Fixed") <> Format(tbTotal.Text, "Fixed") Then
            MensajeTrad("Pago<>Tot")
            tbEfectivo.Focus()
            Return False
         End If
      End If
      '
      If Estado = 4 Then
         If Val(tbEfectivo.Text) + Val(tbCheques.Text) + Val(tbTransf.Text) = 0 Then
            MensajeTrad("DIEfeOChe")
            tbEfectivo.Focus()
            Return False
         ElseIf Format(Val(tbEfectivo.Text) + Val(tbCheques.Text) + Val(tbTransf.Text) - Val(tbDevolEf.Text) - Val(tbDevolCh.Text), "Fixed") <> Format(tbTotal.Text, "Fixed") Then
            MensajeTrad("Ef+Ch<>Tot")
            tbDevolEf.Focus()
            Return False
         End If
      End If
      '
      Return True
      '
   End Function
   '
   Private Function Guardar(Estado As Integer) As Boolean
      '
      Dim compCaja As String
      Dim cDetCaja As String
      '
      Dim NroAsi As Long
      Dim RenASi As Integer
      Dim DetAsi As String
      '
      compCaja = cmpInt & "-" & tbNumero.Text
      DetAsi = tbProveedor.Text
      '
      Try
         '
         Trn = Cn.BeginTransaction
         '
         With Cmd
            .Transaction = Trn
            .CommandText = "UPDATE OrdenPago SET " & _
                           " OPFecPago = '" & Format(FecPago, FormatFecha) & "', " & _
                           " OPTotal = " & nTotal & ", " & _
                           " OPEfectivo = " & Val(tbEfectivo.Text) & ", " & _
                           " OPCheques = " & Val(tbCheques.Text) & ", " & _
                           " OPTransf = " & Val(tbTransf.Text) & ", " & _
                           " OPDetalle = '" & tbDetalle.Text & "', " & _
                           " Estado = " & IIf(EstOP = 6, 6, Estado) & ", " & _
                           " OPUid = '" & Uid & "', " & _
                           " OPFecMod = '" & Format(Now, FormatFechaHora) & "' " & _
                           "WHERE OrdenPagoID = " & OrdenPagoId
            .ExecuteNonQuery()
            '
            If Not PagoDir Then
               .CommandText = "UPDATE " & TablaCmp & " " & _
                              " SET Pagado = 0, NroPago = 0, Usuario = '" & Uid & "', FechaMod = '" & Format(Now, FormatFechaHora) & "' " & _
                              "WHERE EXISTS( SELECT Numero FROM OrdenPagoDet T " & _
                              "              WHERE OrdenPagoID = " & OrdenPagoId & _
                              "                AND Proveedor = " & TablaCmp & ".Proveedor " & _
                              "                AND ProComprob = " & TablaCmp & ".Comprob " & _
                              "                AND ProSucursal = " & TablaCmp & ".Sucursal " & _
                              "                AND ProNumero = " & TablaCmp & ".Numero)"
               .ExecuteNonQuery()
               '
               .CommandText = "DELETE FROM OrdenPagoDet WHERE OrdenPagoID = " & OrdenPagoId
               .ExecuteNonQuery()
            End If
            '
            .CommandText = "INSERT INTO OrdenPagoDet( OrdenPagoId, Proveedor, ProComprob, ProSucursal, ProNumero, OPDUid, OPDFecMod) " & _
                           "SELECT " & OrdenPagoId & ", Proveedor, Comprob, Sucursal, Numero, '" & Uid & "', '" & Format(Now, FormatFechaHora) & "' " & _
                           "FROM " & cTmp
            .ExecuteNonQuery()
            '
            .CommandText = "UPDATE " & TablaCmp & " SET " & _
                           " Pagado = 1, " & _
                           " NroPago = " & OrdenPagoId & ", " & _
                           " Usuario = '" & Uid & "', " & _
                           " FechaMod = '" & Format(Now, FormatFechaHora) & "' " & _
                           "WHERE EXISTS( SELECT Comprob FROM " & cTmp & " " & _
                                         "WHERE Proveedor = " & TablaCmp & ".Proveedor " & _
                                         " AND Comprob = " & TablaCmp & ".Comprob " & _
                                         " AND Sucursal = " & TablaCmp & ".Sucursal " & _
                                         " AND Numero = " & TablaCmp & ".Numero)"
            .ExecuteNonQuery()
            '
         End With
         '
         If Estado = 4 Then
            '
            If SisContable Then
               NroAsi = GuardaAsiento(compCaja, Today, DetAsi, Trn)
               BorraAsienDet(NroAsi)
               '
               RenASi = RenASi + 1
               If Not GuardaAsienDet(NroAsi, RenASi, CuentaProv, DetAsi, Val(tbTotal.Text), 0, Trn) Then
                  Err.Raise(1001, , "NoUpAsiDet")
               End If
               '
               If Val(tbEfectivo.Text) <> 0 Then
                  RenASi = RenASi + 1
                  If Not GuardaAsienDet(NroAsi, RenASi, cCtaCaja, DetAsi, 0, Val(tbEfectivo.Text), Trn) Then
                     Err.Raise(1001, , "NoUpAsiDet")
                  End If
               End If
               '
            End If
            '
            If Val(tbDevolEf.Text) <> 0 Then
               cDetCaja = "Dev.Efectivo"
               If Not ActCaja(Caja, compCaja, "EFD", Today, tbRecibio.Text, "", cDetCaja, IIf(Val(tbDevolEf.Text) > 0, Val(tbDevolEf.Text), 0), IIf(Val(tbDevolEf.Text) < 0, Val(-tbDevolEf.Text), 0), , Trn) Then
                  Err.Raise(1001)
               End If
            End If
            '
         End If
         '
         RenASi = RenASi + 1
         '
         GuardarAudit(IIf(Estado = 2, "Guarda", IIf(Estado = 3, "Paga", "Rinde")) & " Orden de Pago", compCaja, Me.Name, Me.cmdPagar.Text, Trn)
         '
         Trn.Commit()
         '
         Return True
         '
      Catch ex As Exception
         Trn.Rollback()
         Dim st As New StackTrace(True)
         RegistrarError(st, "OrdenPagoPago", True, Err.Description, "Guardar", Err.Number)
      End Try
      '
   End Function
   '
   Private Sub btnSetCols_Click(sender As Object, e As EventArgs) Handles btnSetCols.Click
      SetCols()
   End Sub
   '
   Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
      Me.Close()
   End Sub
   '
   Private Sub frmOrdenPagoPago_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
      SetRegGrid(Me, DataGridView1)
      SetRegForm(Me)
      Me.Dispose()
   End Sub
   '
End Class