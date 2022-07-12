Public Class frmPagos
   '
   Public cmpInt As String
   Public Alta As Boolean
   Public Sucursal As Integer
   Public Numero As Long
   Public Proveedor As Long
   Public PagoDir As Boolean
   '
   Dim Trn As OleDb.OleDbTransaction
   Dim Cmd As New OleDb.OleDbCommand
   Dim Drd As OleDb.OleDbDataReader
   '
   'Dim RsCCom As New ADODB.Recordset   'Compras Cabecera.
   'Dim rsDCom As New ADODB.Recordset   'Compras Detalle.
   'Dim rsProv As New ADODB.Recordset   'Proveedores.
   'Dim rsCPag As New ADODB.Recordset   'Pagos Cabecera.
   'Dim rsDPag As New ADODB.Recordset   'Pagos Detalle.
   'Dim rsTPag As New ADODB.Recordset   'Pagos Detalle (Temporal).
   'Dim rsBcos As New ADODB.Recordset   'Bancos.
   'Dim rsCBco As New ADODB.Recordset   'Cuentas Bancos.
   'Dim rsCheq As New ADODB.Recordset   'Cheques Propios.
   'Dim rsCCar As New ADODB.Recordset   'Cheques en Cartera.
   'Dim rsCaja As New ADODB.Recordset   'Caja.
   'Dim rsMBco As New ADODB.Recordset   'Mov. Bancos.
   'Dim rsTMov As New ADODB.Recordset   'Tipos de Mov. Bancos.
   'Dim rsCAsi As New ADODB.Recordset
   'Dim rsDAsi As New ADODB.Recordset
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
   Dim Caja As Integer
   Dim cCtaCaja As String
   Dim cCtaCajaA As String
   Dim cCtaBanco As String
   Dim cCtaVCar As String
   Dim cDescVCar As String
   Dim cCtaInt As String
   Dim cDescInt As String
   Dim CaptCtas As Boolean
   '
   Const estEMIT = 1
   '
   Private Sub Form_Load()
      '
      GetRegForm(Me)
      '
      TraducirForm(Me)
      '
      Me.Text = Me.Text & " - " & Traducir(IIf(Alta, "Alta", "Edición"))
      '
      ArmaComboItem(cbCaja, "Cajas", "Caja", , , "(Seleccionar)", "Caja <> 0", , , , prmNroCaja)
      'PosCboItem(cboCaja, regNroCaja)
      '
      If FechaIncorrecta() Then
         DeshabForm(Me)
      End If
      '
      Cmd.Connection = Cn
      '
      If Not Alta Then
         '
         Me.Text = Me.Text & " - Nº" & Numero
         '
         cmdAceptar.Enabled = False
         cmdQuitar.Enabled = False
         cmdGenerar.Enabled = False
         '
         Trn = Cn.BeginTransaction
         '
         With Cmd
            .Transaction = Trn
            .CommandText = "DELETE FROM PagosDetTmp WHERE Usuario = '" & Uid & "'"
            .ExecuteNonQuery()
            .CommandText = "INSERT INTO PagosDetTmp( Usuario, Fecha, Nombre, Proveedor, Sucursal, Numero, Comprob, Tipo, PerIva, Total) " & _
                       "SELECT '" & Uid & "' AS Usuario, C.Fecha, P.Nombre, D.Proveedor, D.ProSucursal, D.ProNumero, D.ProComprob, '', '', C.Total " & _
                       "FROM PagosDet D, Proveedores P, CompraOtr C " & _
                       "WHERE D.Proveedor = P.Codigo " & _
                       "  AND D.Comprob = '" & cmpInt & "'" & _
                       "  AND D.Sucursal = " & Sucursal & _
                       "  AND D.Numero = " & Numero & _
                       "  AND D.Proveedor = C.Proveedor" & _
                       "  AND D.ProComprob = LEFT(C.Comprob,2)" & _
                       "  AND D.ProSucursal = C.Sucursal" & _
                       "  AND D.ProNumero = C.Numero"
            .ExecuteNonQuery()
         End With
         '
         Trn.Commit()
         '
      End If
      '
      'Adodc1.ConnectionString = Cn
      '
      If CaptCtasConc(cfgCodigoInt, cDescInt, cCtaInt, "") Then
         If CaptCtasConc(cfgCodigoVCar, cDescVCar, "", cCtaVCar) Then
            CaptCtas = True
         End If
      End If
      '
      If Not CaptCtas Then DeshabForm(Me)
      '
      ArmaComboItem(cbProveedor, "Proveedores", "Codigo", "Nombre", "Nombre", "(Seleccionar)", , , , , Proveedor)
      '
      'If Proveedor <> 0 Then
      'PosComboItem(cbProveedor, Proveedor)
      'End If
      '
      '* ArmaComboItem(cbBanco, "Codigo", "Bancos", cbDescBco, "Nombre", "Nombre")
      '
      nTipoMov = CapturaDato(Cn, "TipoMovBco", "Tipo", "TipoMov = 'CH'")
      cImput = CapturaDato(Cn, "TipoMovBco", "Imput", "TipoMov = 'CH'")
      'With rsTMov
      '   .Open("SELECT * FROM TipoMovBco WHERE TipoMov = 'CH'", Cn, adOpenForwardOnly, adLockReadOnly)
      '   If Not .EOF Then
      '      nTipoMov = !Tipo
      '      cImput = !Imput
      '   End If
      '   .Close()
      'End With
      '
      dtpFecha.Value = Today
      dtpFecha.Enabled = LGR
      '
      'tbFecCheque = Today
      '
      If PagoDir Then
         cmdAceptar_Click()
      Else
         'Fin Nuevo.
         If Alta Then
            LimpiaTemp()
         End If
      End If
      '
      ActData()
      '
   End Sub
   '
   Private Sub Form_KeyPress(KeyAscii As Integer)
      'TabReturn(KeyAscii, True)
      'LastKey = KeyAscii
   End Sub
   '
   Private Sub cbNroCheque_Click()
      'If chkCartera = 1 Then
      'tbCheque = CapturaDato(Cn, "ChCartera", "Importe", "Banco = " & Val(cbBanco) & " AND BancoCta = '" & cbCtaBco & "' AND Numero = " & cbNroCheque)
      'End If
   End Sub
   '
   Private Sub cboCaja_Click()
      'With cboCaja
      '   If .ListIndex >= 0 Then
      '      Caja = .ItemData(.ListIndex)
      '      If Not CaptCtasCaja(Caja, cCtaCaja, cCtaCajaA) Then
      '         cboCaja.ListIndex = -1
      '      End If
      '   Else
      '      Caja = 0
      '   End If
      'End With
   End Sub
   '
   Private Sub cbProveedor_Change()
      'PintarCb(cbProveedor, LastKey)
      'If cbProveedor = "" Then
      '   Proveedor = 0
      'End If
   End Sub
   '
   Private Sub cbProveedor_Click()
      'With cbProveedor
      '   If .ListIndex >= 0 Then
      '      Proveedor = .ItemData(.ListIndex)
      '   Else
      '      Proveedor = 0
      '   End If
      'End With
      'ActData()
   End Sub
   '
   Private Sub cmdAceptar_Click()
      'If cbProveedor = "" Then
      '   MensajeTrad("DIProveedor")
      '   Exit Sub
      'End If
      'ArmaCombos()
      'ActivaCtrl(True)
      'CalcImportes()
   End Sub
   '
   Private Sub cmdCancelar_Click()
      'If PagoDir Then
      '   Unload Me
      'Else
      '   If Alta Then
      '      ActivaCtrl(False)
      '      LimpiaTemp()
      '      ActData()
      '   Else
      '      frmPagosAbm.ActData()
      '      Unload Me
      '   End If
      'End If
   End Sub
   '
   Private Sub chkCartera_Click()
      'If chkCartera = 1 Then
      '   tbCheque = 0
      '   ActCtrlBco(True)
      'End If
      'tbCheque.Enabled = chkCartera = 0
      'ArmaCombos()
   End Sub
   '
   Private Sub ArmaCombos()
      '
      'If chkCartera = 0 Then
      '   ArmaCombo(cbBanco, "Codigo", "Bancos", cbDescBco, "Nombre", "Nombre", "Codigo IN(SELECT DISTINCT Banco FROM BancoCta)")
      'Else
      '   ArmaCombo(cbBanco, "DISTINCT C.Banco", "ChCartera C, Bancos B ", cbDescBco, "B.Nombre", "B.Nombre", "C.Banco = B.Codigo AND C.Estado = 0")
      'End If
      ''
   End Sub
   '
   Private Sub ActivaCtrl(Activo As Boolean)
      '
      'With Me
      '   .cbProveedor.Enabled = Not Activo
      '   .cmdAceptar.Enabled = Not Activo And Alta
      '   .cmdSalir.Cancel = Not Activo
      '   .DataGrid1.Enabled = Activo
      '   .cmdAgregar.Enabled = Activo
      '   .cmdQuitar.Enabled = Activo And Alta
      '   .frDetPago.Enabled = Activo
      '   .cmdGenerar.Enabled = Activo And Alta
      '   .cmdCancelar.Enabled = Activo
      '   .cmdCancelar.Cancel = Activo
      '   .tbIntereses.Enabled = Activo
      'End With
      '
   End Sub
   '
   Private Sub cmdAgregar_Click()
      'With frmPagosAgrCmp
      '   .rsTPag = rsTPag
      '   .cmpInt = cmpInt
      '   .nProveedor = Proveedor
      '   .tbNombre = cbProveedor
      '   .Show(1)
      '   ActData()
      'End With
   End Sub
   '
   Private Sub cmdQuitar_Click()
      'With Adodc1
      '   With .Recordset
      '      If DaDeBaja(!Comprob & " - " & !Tipo & " N° " & !Sucursal & "-" & !Numero & " Prov.: " & !Proveedor) Then
      '         .Delete()
      '      End If
      '   End With
      '   ActData()
      'End With
   End Sub
   '
   Private Sub LimpiaTemp()
      'Cn.BeginTrans()
      'Cn.Execute "DELETE FROM PagosDetTmp WHERE Usuario = '" & Uid & "'"
      'Cn.CommitTrans()
   End Sub

   Sub ActData()

      'On Error Resume Next

      'nSubTotal = 0

      'With Adodc1
      '   .RecordSource = "SELECT Fecha, Nombre, Proveedor, Sucursal, Numero, " & _
      '                   "Comprob, Tipo, PerIva, Total " & _
      '                   "FROM PagosDetTmp " & _
      '                   "WHERE PagosDetTmp.Usuario = '" & Uid & "' " & _
      '                   "ORDER BY Fecha, Nombre"
      '   .Refresh()
      '   cmdQuitar.Enabled = IIf(.Recordset.RecordCount = 0, False, True) And Alta
      'End With

      'If DataGrid1.Row > -1 Then
      '   With Adodc1.Recordset
      '      .MoveFirst()
      '      Do Until .EOF
      '         nSubTotal = nSubTotal + !Total
      '         .MoveNext()
      '      Loop
      '      .MoveFirst()
      '   End With
      'End If

      'SetCols()

      'CalcImportes()

   End Sub

   Private Sub SetCols()

      'Dim cCol As MSDBGrid.Column

      'With DataGrid1
      '   For Each cCol In .Columns
      '      Select Case cCol.Caption
      '         Case "Comprob"
      '            cCol.Width = 500
      '            cCol.Caption = "Cpte."
      '         Case "Tipo"
      '            cCol.Width = 500
      '         Case "Sucursal"
      '            cCol.Width = 750
      '         Case "Numero"
      '            cCol.Width = 1000
      '         Case "Fecha"
      '            cCol.Width = 1100
      '         Case "PerIva"
      '            cCol.Width = 1000
      '            cCol.Caption = "Per.Iva."
      '         Case "Nombre"
      '            cCol.Width = 3450
      '            cCol.Caption = "Proveedor"
      '         Case "Total"
      '            cCol.Width = 1000
      '            cCol.NumberFormat = "#,##0.00"
      '         Case Else
      '            cCol.Visible = False
      '      End Select
      '   Next cCol
      'End With

   End Sub

   Private Sub tbIntereses_Change()
      CalcImportes()
   End Sub

   Private Sub CalcImportes()
      'nIntereses = Val(tbIntereses)
      'nTotal = nSubTotal + nIntereses
      'tbSubTotal = Format(nSubTotal, "Fixed")
      'tbTotal = Format(nTotal, "Fixed")
   End Sub

   Private Sub tbCheque_Change()
      'If Val(tbCheque) = 0 Then
      '   ActCtrlBco(False)
      'Else
      '   ActCtrlBco(True)
      'End If
   End Sub

   Private Sub ActCtrlBco(Activo As Boolean)

      'With Me
      '   .cbDescBco.Enabled = Activo
      '   .cbCtaBco.Enabled = Activo
      '   .cbNroCheque.Enabled = Activo
      '   .tbFecCheque.Enabled = Activo
      'End With
      '
   End Sub
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
   '   '   'No tiene BancoCtas.
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

   Private Sub cbDescBco_Click()
      '   'Nuevo 09/07/2005.
      '   cbBanco.ListIndex = cbDescBco.ListIndex
      '   'cbCtaBco.Clear
      '   If Me.chkCartera = 0 Then
      '      '   With rsCBco
      '      '      .Seek ">=", cbBanco, ""
      '      '      If .NoMatch Then
      '      '         'No tiene BancoCtas.
      '      '      Else
      '      '         Do While !Banco = cbBanco
      '      '            cbCtaBco.AddItem !BancoCta
      '      '            .MoveNext
      '      '            If .EOF Then Exit Do
      '      '         Loop
      '      '      End If
      '      '   End With
      '      ArmaCombo(cbCtaBco, "BancoCta", "BancoCta", , , "BancoCta", "Banco = " & Val(cbBanco))
      '   Else
      '      'Set rsCCar = Dbs.OpenRecordset("SELECT DISTINCT BancoCta FROM ChCartera WHERE Estado = 0 AND Banco = " & Val(cbBanco))
      '      'With rsCCar
      '      '   Do Until .EOF
      '      '      cbCtaBco.AddItem !BancoCta
      '      '      .MoveNext
      '      '   Loop
      '      'End With
      '      ArmaCombo(cbCtaBco, "DISTINCT BancoCta", "ChCartera", , , "BancoCta", "Estado = 0 AND Banco = " & Val(cbBanco))
      '   End If
   End Sub
   '
   Private Sub cbCtaBco_Click()
      ''
      'cbNroCheque.Clear()
      ''
      ''With rsCBco
      ''   .Seek ">=", cbBanco, cbCtaBco
      'If chkCartera = 0 Then
      '   cCtaBanco = CapturaDato(Cn, "BancoCta", "CtaCont", "Banco = " & Val(cbBanco) & " AND BancoCta = '" & cbCtaBco & "'") & ""
      '   If cCtaBanco = "" Then
      '      MensajeTrad("CtaContNoDef")
      '      cbCtaBco.ListIndex = -1
      '      'Else
      '      '   cCtaBanco = !CtaCont
      '   End If
      'End If
      ''End With
      ''
      ''With rsCheq
      ''   .Seek ">=", 0, cbBanco, cbCtaBco
      ''   If .NoMatch Then
      ''      'No hay Cheques.
      ''   Else
      ''      Do While !Banco = cbBanco And _
      ''               !BancoCta = cbCtaBco And _
      ''               !Estado = 0
      ''            cbNroCheque.AddItem !Numero
      ''         .MoveNext
      ''         If .EOF Then Exit Do
      ''      Loop
      ''   End If
      ''End With
      'ArmaCombo(cbNroCheque, "Numero", IIf(chkCartera = 0, "ChPropios", "ChCartera"), , , "Numero", "Banco = " & Val(cbBanco) & " AND BancoCta = '" & cbCtaBco & "' AND Estado = 0")
      ''
   End Sub

   Private Sub cmdGenerar_Click()
      'If ValidaDatos() Then
      '   If Guardar() Then
      '      GenRepOrdPago(cmpInt, regSucursal, Numero, "ORDEN DE PAGO", , crptToWindow)
      '      cmdCancelar_Click()
      '   End If
      'End If
   End Sub

   Private Function ValidaDatos() As Boolean

      'If Val(tbSubTotal) <= 0 Then
      '   MensajeTrad("SubTotal<=0")
      '   Exit Function
      'End If

      'If Val(tbTotal) < 0 Then
      '   MensajeTrad("Total<0")
      '   Exit Function
      'End If

      'If Val(tbEfectivo) + Val(tbCheque) = 0 Then
      '   MensajeTrad("DIEfeOChe")
      '   tbEfectivo.SetFocus()
      '   Exit Function
      'ElseIf Format(Val(tbEfectivo) + Val(tbCheque), "Fixed") <> Format(tbTotal, "Fixed") Then
      '   MensajeTrad("Ef+Ch<>Tot")
      '   tbEfectivo.SetFocus()
      '   Exit Function
      'End If

      'If Val(tbCheque) > 0 Then
      '   If cbBanco = "" Then
      '      MensajeTrad("DIBanco")
      '      cbDescBco.SetFocus()
      '      Exit Function
      '   ElseIf cbCtaBco = "" Then
      '      MensajeTrad("DICtaBco")
      '      cbCtaBco.SetFocus()
      '      Exit Function
      '   ElseIf cbNroCheque = "" Then
      '      MensajeTrad("DINroCheque")
      '      cbNroCheque.SetFocus()
      '      Exit Function
      '   End If
      'End If

      ValidaDatos = True

   End Function

   Private Function Guardar() As Boolean
      '
      '      Dim nRen As Integer
      '      Dim compCaja As String
      '      Dim cDetCaja As String
      '      Dim cTipo As String
      '      Dim cComp As String
      '      '
      '      Dim CodAsi As String
      '      Dim NroAsi As Long
      '      Dim RenASi As Integer
      '      Dim DetAsi As String
      '      Dim cCtaProv As String
      '      Dim cCtaConc As String
      '      Dim cDescConc As String
      '      Dim Debe As Double
      '      Dim Haber As Double
      '      '
      '      On Error GoTo mError
      '      '
      '      '*Cn.BeginTrans()
      '      '
      '      'Set rsCCar = Dbs.OpenRecordset("SELECT * FROM ChCartera WHERE Banco = " & Val(cbBanco) & " AND BancoCta = '" & cbCtaBco & "' AND Numero = " & Val(cbNroCheque))
      '      '
      '      If Alta Then
      '         BuscarCfg(cfgNroPago, "cfgNroPago")
      '         Numero = cfgNroPago + 1
      '         GuardarCfg(cfgNroPago, "cfgNroPago", Numero)
      '      End If
      '      '
      '      compCaja = cmpInt & "-" & Numero
      '      CodAsi = compCaja
      '      DetAsi = Left(cbProveedor, 50)
      '      '
      '      With rsCPag
      '         .Open("SELECT * FROM Pagos WHERE Numero = 0", Cn, adOpenKeyset, adLockOptimistic)
      '         .AddNew()
      '         !Comprob = cmpInt
      '         !Sucursal = regSucursal
      '         !Numero = Numero
      '         !Fecha = tbFecPago
      '         !Proveedor = Proveedor
      '         !Subtotal = nSubTotal
      '         !Intereses = nIntereses
      '         !Total = nTotal
      '         !Efectivo = Val(tbEfectivo)
      '         !Cheques = Val(Me.tbCheque)
      '         If Val(tbCheque) > 0 Then
      '            !NroCheque = cbNroCheque
      '            !FecCheque = tbFecCheque
      '            !Banco = cbBanco
      '            !CtaBco = cbCtaBco
      '         End If
      '         !Detalle = tbDetalle
      '         !Caja = Caja
      '         !Moneda = "PES"
      '         !Usuario = Uid
      '         !FechaMod = Now
      '         .Update()
      '         .Close()
      '      End With
      '      '
      '      NroAsi = GuardaAsiento(CodAsi, tbFecPago, DetAsi)
      '      If NroAsi = 0 Then
      '         Err.Raise(1001, , "NoUpAsiento")
      '      End If
      '      '
      '      With Adodc1.Recordset
      '         .MoveFirst()
      '         Do While Not .EOF
      '            nRen = nRen + 1
      '            rsDPag.Open("SELECT * FROM PagosDet WHERE Numero = 0", Cn, adOpenKeyset, adLockOptimistic)
      '            rsDPag.AddNew()
      '            rsDPag!Comprob = cmpInt
      '            rsDPag!Sucursal = regSucursal
      '            rsDPag!Numero = Numero
      '            rsDPag!Renglon = nRen
      '            rsDPag!Proveedor = !Proveedor
      '            rsDPag!ProComprob = !Comprob
      '            rsDPag!ProSucursal = !Sucursal
      '            rsDPag!ProNumero = !Numero
      '            rsDPag!Usuario = Uid
      '            rsDPag!FechaMod = Now
      '            rsDPag.Update()
      '            rsDPag.Close()
      '            '
      '            'If cmpINT = "PC" Then
      '            '   rsCCom.Seek "=", !Proveedor, !Sucursal, !Numero
      '            'Else
      '            '   rsCCom.Seek "=", !Proveedor, !Comprob, !Sucursal, !Numero
      '            'End If
      '            '
      '            RsCCom.Open("SELECT * FROM " & IIf(cmpInt = "PC", "Compras", "CompraOtr") & " WHERE Proveedor = " & !Proveedor & " AND Comprob = '" & !Comprob & "' AND Sucursal = " & !Sucursal & " AND Numero = " & !Numero, Cn, adOpenKeyset, adLockOptimistic)
      '            '
      '            RsCCom!Pagado = True
      '            RsCCom!NroPago = Numero
      '            RsCCom!Usuario = Uid
      '            RsCCom!FechaMod = Now
      '            RsCCom.Update()
      '            RsCCom.Close()
      '            '
      '            If cmpInt = "PC" Then
      '               'rsProv.Index = "Codigo"
      '               'rsProv.Seek "=", !Proveedor
      '               'If IsNull(rsProv!BancoCta) Then
      '               '   Err.Raise 1001, , "ProvSinCtaAsig"
      '               'End If
      '               cCtaProv = CapturaDato(Cn, "Proveedores", "BancoCta", "Codigo = " & !Proveedor) & ""
      '               If cCtaProv = "" Then
      '                  Err.Raise(1001, , "ProvSinCtaAsig")
      '               End If
      '               '
      '               RenASi = RenASi + 1
      '               If Not GuardaAsienDet(NroAsi, RenASi, cCtaProv, DetAsi, !Total, 0) Then
      '                  Err.Raise(1001, , "NoUpAsiDet")
      '               End If
      '               '
      '            Else
      '               'rsDCom.Seek ">=", !Proveedor, !Comprob, !Sucursal, !Numero
      '               rsDCom.Open("SELECT * FROM CompraOtrDet WHERE Proveedor = " & !Proveedor & " AND Comprob = '" & !Comprob & "' AND Sucursal = " & !Sucursal & " AND Numero = " & !Numero, Cn, adOpenKeyset, adLockOptimistic)
      '               'Do While rsDCom!Proveedor = !Proveedor And _
      '               '         rsDCom!Comprob = !Comprob And _
      '               '         rsDCom!Sucursal = !Sucursal And _
      '               '         rsDCom!Numero = !Numero
      '               Do Until .EOF
      '                  '
      '                  If Not CaptCtasConc(rsDCom!Concepto, cDescConc, "", cCtaConc) Then
      '                     .Close()
      '                     Err.Raise(1001, , Traducir("ConcSinCtaAsig"))
      '                  End If
      '                  '
      '                  If rsDCom!Imput = "D" Then
      '                     Debe = rsDCom!Importe
      '                     Haber = 0
      '                  Else
      '                     Debe = 0
      '                     Haber = rsDCom!Importe
      '                  End If
      '                  RenASi = RenASi + 1
      '                  If Not GuardaAsienDet(NroAsi, RenASi, cCtaConc, DetAsi & "-" & cDescConc, Debe, Haber) Then
      '                     .Close()
      '                     Err.Raise(1001, , "NoUpAsiDet")
      '                  End If
      '                  '
      '                  rsDCom.MoveNext()
      '                  If rsDCom.EOF Then Exit Do
      '                  '
      '               Loop
      '               rsDCom.Close()
      '            End If
      '            '
      '            .MoveNext()
      '            If .EOF Then Exit Do
      '         Loop
      '      End With
      '      '
      '      If nIntereses > 0 Then
      '         RenASi = RenASi + 1
      '         If Not GuardaAsienDet(NroAsi, RenASi, cCtaInt, DetAsi, nIntereses, 0) Then
      '            Err.Raise(1001, , "NoUpAsiDet")
      '         End If
      '      End If

      '      If Val(tbEfectivo) > 0 Then
      '         cDetCaja = "Efectivo"
      '         ActCaja(Caja, compCaja, "EF", tbFecPago, cbProveedor, _
      '                 "", cDetCaja, 0, tbEfectivo)
      '         '
      '         RenASi = RenASi + 1
      '         If Not GuardaAsienDet(NroAsi, RenASi, IIf(cmpInt = "PC", cCtaCaja, cCtaCajaA), DetAsi, 0, Val(tbEfectivo)) Then
      '            Err.Raise(1001, , "NoUpAsiDet")
      '         End If
      '         '
      '      End If
      '      '
      '      If Val(tbCheque) > 0 Then
      '         '
      '         If chkCartera = 1 Then
      '            cDetCaja = "CH." & cbDescBco & ", CTA:" & cbCtaBco & ", Nº" & cbNroCheque & ", Al:" & tbFecCheque
      '            '
      '            ActCaja(Caja, compCaja, "CH", tbFecPago, cbProveedor, _
      '                    "", cDetCaja, 0, tbCheque)
      '         End If
      '         '
      '         'Detalle Asiento (Banco/Ch.Cartera).
      '         RenASi = RenASi + 1
      '         If Not GuardaAsienDet(NroAsi, RenASi, IIf(chkCartera = 0, cCtaBanco, cCtaVCar), DetAsi, 0, tbCheque) Then
      '            Err.Raise(1001, , Traducir("NoUpAsiento"))
      '         End If
      '         '
      '         If chkCartera = 0 Then
      '            With rsMBco
      '               .Open("SELECT * FROM BancosMov WHERE Banco = " & Val(cbBanco) & " AND BancoCta = '" & cbCtaBco & "' AND Tipo = " & nTipoMov & " AND Numero = " & cbNroCheque, Cn, adOpenKeyset, adLockOptimistic)
      '               '.Seek "=", cbBanco, cbCtaBco, nTipoMov, cbNroCheque
      '               If .EOF Then
      '                  'Ok.
      '               Else
      '                  .Close()
      '                  Err.Raise(1001, , Traducir("MovExiste"))
      '               End If
      '               .AddNew()
      '               !Banco = cbBanco
      '               !BancoCta = cbCtaBco
      '               !Tipo = nTipoMov
      '               !Numero = cbNroCheque
      '               !FechaEmi = tbFecPago
      '               !FechaAcr = tbFecCheque
      '               !Debe = IIf(cImput = "D", tbCheque, 0)
      '               !Haber = IIf(cImput = "H", tbCheque, 0)
      '               !Detalle = compCaja & " - " & DetAsi
      '               !Estado = estEMIT
      '               !HojaBco = 0
      '               !Usuario = Uid
      '               !FechaMod = Now
      '               .Update()
      '               .Close()
      '            End With
      '            '
      '            With rsCheq
      '               .Open("SELECT * FROM ChPropios WHERE Banco = " & Val(cbBanco) & " AND BancoCta = '" & cbCtaBco & "' AND Tipo = " & nTipoMov & " AND Numero = " & cbNroCheque, Cn, adOpenKeyset, adLockOptimistic)
      '               '.Seek "=", 0, cbBanco, cbCtaBco, nTipoMov, cbNroCheque
      '               If .EOF Then
      '                  .Close()
      '                  Err.Raise(1001, , Traducir("ChNoEnc"))
      '               Else
      '                  '.Edit
      '                  !Estado = estEMIT
      '                  !Usuario = Uid
      '                  !FechaMod = Now
      '                  .Update()
      '               End If
      '               .Close()
      '            End With
      '            '
      '         Else
      '            With rsCCar
      '               .Open("SELECT * FROM Chcartera WHERE Banco = " & Val(cbBanco) & " AND BancoCta = '" & cbCtaBco & "' AND Numero = " & cbNroCheque & " AND Estado = 0", Cn, adOpenKeyset, adLockOptimistic)
      '               '.Seek "=", 0, cbBanco, cbCtaBco, cbNroCheque
      '               If .EOF Then
      '                  .Close()
      '                  Err.Raise(1001, , Traducir("ChNoEnc"))
      '                  GoTo mError
      '               Else
      '                  '.Edit
      '                  !Estado = 2
      '                  !Usuario = Uid
      '                  !FechaMod = Now
      '                  .Update()
      '               End If
      '               .Close()
      '            End With
      '         End If
      '         '
      '         cbNroCheque.RemoveItem cbNroCheque.ListIndex
      '         '
      '      End If
      '      '
      '      GuardarAudit("Paga Comprobante", compCaja, Me.Name, Me.cmdAceptar.Caption)
      '      '
      '      Cn.CommitTrans()
      '      '
      '      Guardar = True
      '      Exit Function
      '      '
      'mError:
      '      MsgBox(Err.Number & ": " & Err.Description & Chr(13) & Chr(10) & _
      '             Traducir("TransNComp"))
      '      Cn.Rollback()
      '      '
   End Function

   Private Sub cmdSalir_Click()
      'If Not PagoDir Then
      '   frmPagosAbm.ActData()
      'End If
      'Unload Me
   End Sub

   Private Sub Form_Unload(Cancel As Integer)
      SetRegForm(Me)
   End Sub

End Class