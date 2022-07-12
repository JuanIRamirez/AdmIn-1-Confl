Public Class frmOrdenPagoConf
   '
   Public Estado As Byte = 0
   Public OrdenPagoId As Int32 = 0
   '
   Dim Trn As OleDb.OleDbTransaction
   Dim Cmd As New OleDb.OleDbCommand
   Dim Cm2 As New OleDb.OleDbCommand
   Dim Drd As OleDb.OleDbDataReader
   Dim Dr2 As OleDb.OleDbDataReader
   '
   Dim nSubTotal As Double
   Dim cCtaProv As String
   Dim cCtaCaja As String
   Dim Proveedor As Long
   Dim GenAsi As Boolean
   Dim Caja As Integer
   Dim cmpInt As String
   Dim cDescVCar As String
   Dim cCtaVCar As String
   Dim CaptCtas As Boolean
   Dim nTipoMov As Integer
   Dim cImput As String
   Dim vGtosBanc As Double
   '
   Dim cTmpCh As String
   Dim cTmpTr As String
   '
   Const cStrCh = "Renglon SMALLINT, " & _
                  "Origen VARCHAR (1), " & _
                  "Banco INT, " & _
                  "DescBco VARCHAR(50), " & _
                  "Cuenta VARCHAR(25), " & _
                  "Titular VARCHAR(50), " & _
                  "Numero VARCHAR(25), " & _
                  "Fecha SMALLDATETIME, " & _
                  "Importe FLOAT, " & _
                  "CtaCont VARCHAR(15), " & _
                  "Usuario VARCHAR(25)"
   '
   Const cStrTr = "Banco0 INT NOT NULL, " & _
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
   Const EstPagado = 3
   Const estRendido = 4
   Const estEMIT = 1
   '
   Private Sub frmOrdenPagoConf_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      '
      GetRegForm(Me)
      '
      TraducirForm(Me)
      '
      If Estado = 1 Then
         cmdConfirmar.Text = "&Desconfirmar"
         tbEfectivo.Enabled = False
         cboCaja.Enabled = False
         cmdIngCheques.Enabled = False
         cmdTransferencia.Enabled = False
      ElseIf Estado = 2 Then
         cmdConfirmar.Text = "&Confirmar"
      Else
         MensajeTrad("Estado de la OP incorrecto")
         DeshabForm(Me)
      End If
      '
      If CaptCtasConc(cfgCodigoVCar, cDescVCar, "", cCtaVCar) Then
         CaptCtas = True
      End If
      '
      cTmpCh = ""
      CrearTabla(Cn, cStrCh, cTmpCh)
      '
      cTmpTr = ""
      CrearTabla(Cn, cStrTr, cTmpTr)
      '
      ArmaComboItem(cboCaja, "Cajas", "Caja", , , "(Seleccionar)", "Caja <> 0")
      PosicionarComboItem(cboCaja, prmNroCaja)
      '
      nTipoMov = CapturaDato(Cn, "TipoMovBco", "TipoMovBco", "TipoMov = 'CH'")
      cImput = CapturaDato(Cn, "TipoMovBco", "Imput", "TipoMov = 'CH'")
      '
      'If cDbBkp <> "" Then
      '   With Rs
      '      .Open("SELECT * FROM Cajas ORDER BY Descrip", CnBkp, adOpenForwardOnly, adLockReadOnly)
      '      Do Until .EOF
      '         cboCaja.AddItem!Descrip()
      '         .MoveNext()
      '      Loop
      '      .Close()
      '   End With
      'End If
      '
      With Cmd
         .Connection = Cn
         .CommandText = "SELECT * FROM OrdenPago WHERE OrdenPagoID = " & OrdenPagoId
         Drd = .ExecuteReader
      End With
      With Drd
         If .Read Then
            tbProveedor.Text = IIf(!Proveedor = 0, "(Varios)", CapturaDato(Cn, "Proveedores", "Nombre", "Codigo = " & !Proveedor))
            dtpFecha.Value = !OPFecha
            tbNumero.Text = !OPNumero
            tbDetalle.Text = !OPDetalle
            tbTotal.Text = Format(Val(!OPTotal & ""), "Fixed")
            tbTransf.Text = Format(Val(!OpTransf & ""), "Fixed")
            cmpInt = !OPTipo
            Proveedor = !Proveedor
            tbComprob.Text = cmpInt & "-" & !OPNumero
            tbEfectivo.Text = Format(Val(!OpEfectivo & ""), "Fixed")   'CapturaDato(Cn, "Caja", "Salida", "Comprob = '" & tbComprob & "' AND FPago = 'EF'")
            tbCheques.Text = Format(Val(!OpCheques & ""), "Fixed")
            Caja = CapturaDato(Cn, "Caja", "Caja", "Comprob = '" & tbComprob.Text & "'")
            If Caja = 0 Then
               Caja = prmNroCaja
            End If
            PosicionarComboItem(cboCaja, Caja)
         End If
         .Close()
      End With
      '
      If cfgCtaPrvUnica Or Proveedor = 0 Then
         cCtaProv = cfgCtaProvVarios
      Else
         cCtaProv = CapturaDato(Cn, "Proveedores", "Cuenta", "Codigo = " & Proveedor)
      End If
      '
      ActData()
      '
   End Sub
   '
   Private Sub frmOrdenPagoConf_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
      TabReturn(e.KeyChar)
   End Sub
   '
   Private Sub cboCaja_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCaja.SelectedIndexChanged
      With cboCaja
         If .SelectedIndex > 0 Then
            Caja = .SelectedValue
         Else
            Caja = 0
         End If
      End With
   End Sub
   '
   Private Sub cmdIngCheques_Click(sender As Object, e As EventArgs) Handles cmdIngCheques.Click
      Dim Frm As New frmPagoCh
      With frm
         .TablaAct = cTmpCh
         .Titulo = "Confirmar Orden de Pago"
         .ShowDialog()
         tbCheques.Text = .Total
      End With
   End Sub
   '
   Private Sub cmdTransferencia_Click(sender As Object, e As EventArgs) Handles cmdTransferencia.Click
      Dim Frm As New frmLiqTransf
      With frm
         .TablaTmp = cTmpTr
         .TransfRec = False
         .ShowDialog()
         tbTransf.Text = Format(.Total, "Fixed")
         vGtosBanc = .GtosBanc
      End With
   End Sub
   '
   Sub ActData()
      '
      nSubTotal = 0
      Dim cSQL, TablaC, RelDet As String
      '
      SetRegGrid(Me, DataGridView1)
      '
      If cmpInt = "PO" Then
         TablaC = "CompraOtr"
         RelDet = "D.Proveedor = C.Proveedor AND D.ProComprob = C.Comprob AND D.ProSucursal = C.Sucursal AND D.ProNumero = C.Numero"
         '
         cSQL = "SELECT C.Fecha, P.Nombre, C.Sucursal, C.Numero, C.Comprob, '' AS Tipo, '' AS PerIva, CD.Detalle, C.Total " & _
                "FROM (((OrdenPagoDet D LEFT JOIN Proveedores P ON D.Proveedor = P.Codigo) " & _
                " INNER JOIN CompraOtr C ON " & RelDet & ") " & _
                " LEFT JOIN CompraOtrDet CD ON CD.Proveedor = C.Proveedor AND CD.Comprob = C.Comprob AND CD.Sucursal = C.Sucursal AND CD.Numero = C.Numero) " & _
                "WHERE D.OrdenPagoID = " & OrdenPagoId & _
                "  AND CD.Renglon = 1 " & _
                "ORDER BY C.Fecha, P.Nombre"
      Else
         TablaC = "Compras"
         RelDet = "D.Proveedor = C.Proveedor AND D.ProComprob = LEFT(C.Comprob,3) AND D.ProSucursal = C.Sucursal AND D.ProNumero = C.Numero"
         '
         cSQL = "SELECT C.Fecha, P.Nombre, C.Sucursal, C.Numero, C.Comprob, C.Tipo, C.PerIva, C.Total " & _
                "FROM (((OrdenPagoDet D LEFT JOIN Proveedores P ON D.Proveedor = P.Codigo) " & _
                " INNER JOIN Compras C ON " & RelDet & ") " & _
                " LEFT JOIN ComprasDet CD ON CD.Proveedor = C.Proveedor AND CD.Sucursal = C.Sucursal AND CD.Numero = C.Numero) " & _
                "WHERE D.OrdenPagoID = " & OrdenPagoId & _
                "  AND CD.Renglon = 1 " & _
                "ORDER BY C.Fecha, P.Nombre"
      End If
      '
      LlenarGrid(DataGridView1, cSQL)
      '
      nSubTotal = Val(CapturaDato(Cn, "OrdenPagoDet D, " & TablaC & " C", "SUM(C.Total)", "D.OrdenPagoID = " & OrdenPagoId & " AND " & RelDet) & "")
      '
      SetCols()
      '
      GetRegGrid(Me, DataGridView1)
      '
      CalcImportes()
      '
   End Sub
   '
   Private Sub SetCols()
      '
      With DataGridView1
         For Each Col As DataGridViewColumn In .Columns
            With Col
               Select Case UCase(.Name)
                  Case "COMPROB" : .Width = 50 : .HeaderText = "Cpte."
                  Case "TIPO" : .Width = 50
                  Case "SUCURSAL" : .Width = 75
                  Case "NUMERO" : .Width = 100
                  Case "FECHA" : .Width = 110
                  Case "PERIVA" : .Width = 100 : .HeaderText = "Per.Iva."
                  Case "NOMBRE" : .Width = 200 : .HeaderText = "Proveedor"
                  Case "DETALLE" : .Width = 200
                  Case "TOTAL" : .Width = 100
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
      '
   End Sub
   '
   Private Sub CalcImportes()
      tbDiferencia.Text = Format(Val(tbEfectivo.Text) + Val(tbCheques.Text) + Val(tbTransf.Text) - Val(tbTotal.Text), "Fixed")
   End Sub
   '
   Private Sub cmdConfirmar_Click(sender As Object, e As EventArgs) Handles cmdConfirmar.Click
      If ValidaDatos() Then
         If Guardar() Then
            GenRepOrdPago(cmpInt, prmSucursal, Val(tbNumero.Text), "ORDEN DE PAGO", crptToWindow)
            If Estado = 2 Then
               ImprimirCrp("CompCaja", crptToWindow, "{Caja.Comprob} = '" & tbComprob.Text & "'", "Comprobante de Caja")
            End If
            Me.Close()
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
      If Estado = 2 Then
         If tbProveedor.Text = "" Then
            MensajeTrad("Debe Ingresar Proveedor")
            tbProveedor.Focus()
            Return False
         End If
      End If
      '
      If Math.Round(Val(tbEfectivo.Text) + Val(tbCheques.Text) + Val(tbTransf.Text), 2) < Math.Round(Val(tbTotal.Text), 2) Then
         MensajeTrad("ImpPago<Total")
         tbEfectivo.Focus()
         Return False
      End If
      '
      If Caja = 0 Then
         MensajeTrad("DICaja")
         cboCaja.Focus()
         Return False
      End If
      '
      If tbRecibe.Text = "" Then
         MensajeTrad("DiRecibe")
         tbRecibe.Focus()
         Return False
      End If
      '
      Return True
      '
   End Function
   '
   Private Function Guardar() As Boolean
      '
      Dim Cmd As New OleDb.OleDbCommand
      Dim Cm2 As New OleDb.OleDbCommand
      '
      Dim OPNumero As Long
      Dim OrdenPagoTrID As Long
      Dim nRen As Integer = 0
      Dim nRenCh As Integer
      Dim compCaja As String
      Dim cDetCaja As String
      Dim cCtaBanco As String
      Dim cBanco As String
      Dim nContFp As Integer
      '
      Dim CodAsi As String
      Dim NroAsi As Long
      Dim RenASi As Integer
      Dim DetAsi As String
      Dim ImpCaja As Double
      Dim fPago As String
      Dim Nombre As String
      Dim Detalle As String
      Dim Entrada As Boolean
      Dim CtaCaja As String
      '
      Dim nBanco, nTipo As Integer
      Dim cNumero, cCuenta As String
      '
      Try
         '
         Trn = Cn.BeginTransaction
         '
         With Cmd
            .Connection = Cn
            .Transaction = Trn
            .CommandText = "UPDATE OrdenPago SET " & _
                           " OPFecPago = '" & Format(Today, FormatFecha) & "', " & _
                           " OPTotal = " & tbTotal.Text & ", " & _
                           " OPEfectivo = " & IIf(Estado = 2, Val(tbEfectivo.Text), 0) & ", " & _
                           " OPCheques = " & IIf(Estado = 2, Val(tbCheques.Text), 0) & ", " & _
                           " OPTransf = " & IIf(Estado = 2, Val(tbTransf.Text), 0) & ", " & _
                           " OPDetalle = '" & tbDetalle.Text & "', " & _
                           " Estado = " & Estado & ", " & _
                           " OPUid = '" & Uid & "', " & _
                           " OPFecMod = '" & Format(Now, FormatFechaHora) & "' " & _
                           "WHERE OrdenPagoID = " & OrdenPagoId
            .ExecuteNonQuery()
         End With
         '
         With Cm2
            .Connection = Cn
            .Transaction = Trn
         End With
         '
         OPNumero = CapturaDato(Cn, "OrdenPago", "OpNumero", "OrdenPagoId = " & OrdenPagoId, , , , Trn)
         '
         tbComprob.Text = cmpInt & "-" & tbNumero.Text
         compCaja = tbComprob.Text
         cDetCaja = "Pagar " & tbComprob.Text
         CodAsi = tbComprob.Text
         '
         If SisContable Then
            If Estado = 2 Then
               NroAsi = GuardaAsiento(CodAsi, Today, tbDetalle.Text, Trn)
               If NroAsi = 0 Then
                  Err.Raise(1001, , "NoUpAsiento")
               End If
               BorraAsienDet(NroAsi, Trn)
               RenASi = RenASi + 1
               If Not GuardaAsienDet(NroAsi, RenASi, cCtaProv, DetAsi, Val(tbTotal.Text) + Val(tbDiferencia.Text), 0, Trn) Then
                  Err.Raise(1001, , "NoUpAsiDet")
               End If
            Else
               BorraAsiento(CodAsi, Trn)
            End If
         End If
         '
         If Val(tbEfectivo.Text) > 0 Then
            If Estado = 2 Then
               fPago = "EF"
               nContFp = 1
               Do While Not IsNothing(CapturaDato(Cn, "Caja", "Comprob", "Comprob = '" & compCaja & "' AND FPago = '" & fPago & "'", , , , Trn))
                  nContFp = nContFp + 1
                  fPago = "EF" & nContFp
               Loop
               If Not GuardarCaja(True, False, cmpInt, Caja, False, 0, tbEfectivo.Text, fPago, Now, tbProveedor.Text, cDetCaja, cCtaProv, 0, cCtaCaja, Trn, tbComprob.Text) Then
                  Err.Raise(1001)
               End If
               If SisContable Then
                  RenASi = RenASi + 1
                  GuardaAsienDet(NroAsi, RenASi, cCtaCaja, tbDetalle.Text, 0, Val(tbEfectivo.Text), Trn)
               End If
            Else
               'Desconfirmar.
               If Not BorraAsiento(CodAsi, Trn) Then
                  Err.Raise(1001, , "NoDelAsi")
               End If
               '
               With Cmd
                  .CommandText = "SELECT TOP 1 * FROM Caja WHERE Comprob = '" & tbComprob.Text & "' AND fPago LIKE 'EF%' ORDER BY fPago DESC"
                  Drd = .ExecuteReader
               End With
               With Drd
                  If .Read Then
                     ImpCaja = !Entrada + !Salida
                     Caja = !Caja
                     fPago = "-" & !fPago
                     Nombre = !Nombre
                     Detalle = "Anula " & !Detalle
                     Entrada = (!Entrada = 0)
                     CtaCaja = CapturaDato(Cn, "Cajas", "Cuenta", "Caja = " & Caja, , , , Trn) & ""
                     '
                     If Not GuardarCaja(True, False, cmpInt, Caja, Entrada, 0, ImpCaja, fPago, Now, Nombre, Detalle, cCtaProv, 0, CtaCaja, Trn, tbComprob.Text) Then
                        .Close()
                        Err.Raise(1001)
                     End If
                     '
                  End If
                  .Close()
               End With
               '
            End If
         End If
         '
         If Val(tbCheques.Text) > 0 Then
            If Estado = 2 Then
               With Cmd
                  .CommandText = "SELECT * FROM " & cTmpCh
                  Drd = .ExecuteReader
               End With
               With Drd
                  Do While .Read
                     nRen = nRen + 1
                     Cm2.CommandText = "INSERT INTO OrdenPagoCH( OrdenPagoId, OPCRenglon, Origen, Banco, Cuenta, Numero, OPCUid, OPCFecMod) " & _
                                       "VALUES( " & OrdenPagoId & ", " & _
                                                    nRen & ", " & _
                                              "'" & !Origen & "', " & _
                                                    !Banco & ", " & _
                                              "'" & !Cuenta & "', " & _
                                              "'" & !Numero & "', " & _
                                              "'" & Uid & "', " & _
                                              "'" & Format(Now, FormatFechaHora) & "')"
                     Cm2.ExecuteNonQuery()
                     '
                     If SisContable Then
                        cCtaBanco = CapturaDato(Cn, "BancoCta", "CtaCont", "Banco = " & !Banco & " AND BancoCta = '" & !Cuenta & "'", , , , Trn) & ""
                     End If
                     '
                     cBanco = CapturaDato(Cn, "Bancos", "Nombre", "Banco = " & !Banco, , , , Trn) & ""
                     '
                     If !Origen = "C" Then
                        nRenCh = 1
                        fPago = "CH"
                        Do While Not IsNothing(CapturaDato(Cn, "Caja", "Comprob", "Comprob = '" & compCaja & "' AND FPago = '" & fPago & "'", , , , Trn))
                           nRenCh = nRenCh + 1
                           fPago = "CH" & nRenCh
                        Loop
                        cDetCaja = "CH. " & cBanco & " CTA:" & !Cuenta & ", Nº" & !Numero & ", Al:" & Today
                        '
                        If Not ActCaja(Caja, compCaja, fPago, Today, tbProveedor.Text, "", cDetCaja, 0, !Importe, , Trn) Then
                           .Close()
                           Err.Raise(1001)
                        End If
                        '
                     End If
                     '
                     'Detalle Asiento (Banco/Ch.Cartera).
                     If SisContable Then
                        RenASi = RenASi + 1
                        If Not GuardaAsienDet(NroAsi, RenASi, IIf(!Origen = "P", cCtaBanco, cCtaVCar), DetAsi, 0, !Importe, Trn) Then
                           .Close()
                           Err.Raise(1001, , Traducir("NoUpAsiento", , Trn))
                        End If
                     End If
                     '
                     If !Origen = "P" Then
                        If Not IsNothing(CapturaDato(Cn, "BancosMov", "NroMovBco", "Banco = " & !Banco & " AND BancoCta = '" & !Cuenta & "' AND TipoMovBco = " & nTipoMov & " AND NroMovBco = '" & !Numero & "'", , , , Trn)) Then
                           .Close()
                           Err.Raise(1001, , Traducir("MovBcoExiste", , Trn))
                        End If
                        Cm2.CommandText = "INSERT INTO BancosMov( Banco, BancoCta, TipoMovBco, NroMovBco, FechaEmi, FechaAcr, Debe, Haber, Detalle, Estado, HojaBco, Usuario, FechaMod) " & _
                                          "VALUES( " & !Banco & ", " & _
                                                 "'" & !Cuenta & "', " & _
                                                       nTipoMov & ", " & _
                                                 "'" & !Numero & "', " & _
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
                        Cm2.CommandText = "UPDATE ChPropios SET " & _
                                          " Estado = " & estEMIT & ", " & _
                                          " Usuario = '" & Uid & "', " & _
                                          " FechaMod = '" & Format(Now, FormatFechaHora) & "' " & _
                                          "WHERE Banco = " & !Banco & " AND BancoCta = '" & !Cuenta & "' AND TipoMovBco = " & nTipoMov & " AND ChPropNro = '" & !Numero & "'"
                        If Cm2.ExecuteNonQuery() = 0 Then
                           Cm2.CommandText = "INSERT INTO ChPropios( Banco, BancoCta, TipoMovBco, ChPropNro, Estado, Usuario, FechaMod) " & _
                                             "VALUES( " & !Banco & ", " & _
                                                    "'" & !Cuenta & "', " & _
                                                          nTipoMov & ", " & _
                                                    "'" & !Numero & "', " & _
                                                          estEMIT & ", " & _
                                                    "'" & Uid & "', " & _
                                                    "'" & Format(Now, FormatFechaHora) & "')"
                           Cm2.ExecuteNonQuery()
                        End If
                        '
                     Else
                        Cm2.CommandText = "UPDATE Chcartera SET " & _
                                          " Estado = 2, " & _
                                          " Usuario = '" & Uid & "', " & _
                                          " FechaMod = '" & Format(Now, FormatFechaHora) & "' " & _
                                          "WHERE Banco = " & !Banco & " AND BancoCta = '" & !Cuenta & "' AND ChCartNro = '" & !Numero & "' AND Estado = 0"
                        If Cm2.ExecuteNonQuery = 0 Then
                           .Close()
                           Err.Raise(1001, , Traducir("ChNoEnc", , Trn))
                        End If
                     End If
                     '
                  Loop
                  .Close()
               End With
            Else
               '* Desconfirmar OP.
               With Cmd
                  .CommandText = "SELECT * FROM OrdenPagoCh WHERE OrdenPagoId = " & OrdenPagoId
                  Drd = .ExecuteReader
               End With
               With Drd
                  Do While .Read
                     If !Origen = "C" Then
                        '* Cheques en Cartera.
                        Cm2.CommandText = "UPDATE Chcartera SET " & _
                                          " Estado = 0, " & _
                                          " Usuario = '" & Uid & "', " & _
                                          " FechaMod = '" & Format(Now, FormatFechaHora) & "' " & _
                                          "WHERE Banco = " & !Banco & " AND BancoCta = '" & !Cuenta & "' AND ChCartNro = '" & !Numero & "'"
                        Cm2.ExecuteNonQuery()
                        '
                        Cm2.CommandText = "SELECT * FROM Chcartera WHERE Banco = " & !Banco & " AND BancoCta = '" & !Cuenta & "' AND ChCartNro = '" & !Numero & "'"
                        Dr2 = Cm2.ExecuteReader
                        '
                        If Dr2.Read Then
                           '* Contra-Asiento Caja.
                           nRenCh = 1
                           fPago = "CH"
                           Do While Not IsNothing(CapturaDato(Cn, "Caja", "Comprob", "Comprob = '" & compCaja & "' AND FPago = '" & fPago & "'", , , , Trn))
                              nRenCh = nRenCh + 1
                              fPago = "CH" & nRenCh
                           Loop
                           ImpCaja = Dr2!Importe
                           Caja = Dr2!Caja
                           Nombre = Dr2!Titular
                           Detalle = "Anula OP " & OPNumero
                           Entrada = True
                           CtaCaja = CapturaDato(Cn, "Cajas", "Cuenta", "Caja = " & Caja, , , , Trn)
                           '
                           If Not GuardarCaja(True, False, cmpInt, Caja, Entrada, 0, ImpCaja, fPago, Now, Nombre, Detalle, cCtaProv, 0, CtaCaja, Trn, tbComprob.Text) Then
                              .Close()
                              Err.Raise(1001)
                           End If
                           '
                        End If
                        Dr2.Close()
                     Else
                        '
                        '* Cheques Propios.
                        Cm2.CommandText = "UPDATE ChPropios SET " & _
                                          " Estado = 0, " & _
                                          " Usuario = '" & Uid & "', " & _
                                          " FechaMod = '" & Format(Now, FormatFechaHora) & "' " & _
                                          "WHERE Banco = " & !Banco & " AND BancoCta = '" & !Cuenta & "' AND TipoMovBco = " & nTipoMov & " AND ChPropNro = '" & !Numero & "'"
                        Cm2.ExecuteNonQuery()
                        '
                        Cm2.CommandText = "SELECT * FROM ChPropios WHERE Banco = " & !Banco & " AND BancoCta = '" & !Cuenta & "' AND TipoMovBco = " & nTipoMov & " AND ChPropNro = '" & !Numero & "'"
                        Dr2 = Cm2.ExecuteReader
                        If Dr2.Read Then
                           '
                           '* Contra-Asiento Caja.
                           nRenCh = 1
                           fPago = "CP"
                           Do While Not IsNothing(CapturaDato(Cn, "Caja", "Comprob", "Comprob = '" & compCaja & "' AND FPago = '" & fPago & "'", , , , Trn))
                              nRenCh = nRenCh + 1
                              fPago = "CP" & nRenCh
                           Loop
                           ImpCaja = CapturaDato(Cn, "BancosMov", "Debe + Haber", "Banco = " & Dr2!Banco & " AND BancoCta = '" & Dr2!BancoCta & "' AND TipoMovBco = " & nTipoMov & " AND NroMovBco = '" & Dr2!ChPropNro & "'", , , , Trn)
                           Caja = CapturaDato(Cn, "BancosMov", "ISNULL( Caja, 1)", "Banco = " & Dr2!Banco & " AND BancoCta = '" & Dr2!BancoCta & "' AND TipoMovBco = " & nTipoMov & " AND NroMovBco = '" & Dr2!ChPropNro & "'", , , , Trn)
                           Detalle = "Anula OP " & OPNumero
                           Entrada = True
                           CtaCaja = CapturaDato(Cn, "Cajas", "Cuenta", "Caja = " & Caja, , , , Trn)
                           If Not GuardarCaja(True, False, cmpInt, Caja, Entrada, 0, ImpCaja, fPago, Now, Nombre, Detalle, cCtaProv, 0, CtaCaja, Trn, tbComprob.Text) Then
                              .Close()
                              Err.Raise(1001)
                           End If
                        End If
                        '
                        Dr2.Close()
                        '
                        Cm2.CommandText = "DELETE FROM BancosMov WHERE Banco = " & !Banco & " AND BancoCta = '" & !Cuenta & "' AND TipoMovBco = " & nTipoMov & " AND NroMovBco = '" & !Numero & "'"
                        Cm2.ExecuteNonQuery()
                        '
                     End If
                  Loop
                  '
                  .Close()
                  '
               End With
               '
               With Cmd
                  .CommandText = "DELETE FROM OrdenPagoCh WHERE OrdenPagoId = " & OrdenPagoId
                  .ExecuteNonQuery()
               End With
            End If
         End If
         '
         If Val(tbTransf.Text) > 0 Then
            '
            nTipo = CapturaDato(Cn, "TipoMovBco", "TipoMovBco", "TipoMov = 'TR'", , , , Trn)
            '
            If nTipo = 0 Then
               Err.Raise(1001, , "Tipo de Mov. Transferencia no Definida")
            End If
            '
            With Cmd
               If Estado = 2 Then
                  .CommandText = "INSERT INTO OrdenPagoTR( OrdenPagoId, Banco0, Cuenta0, Banco1, Cuenta1, Titular1, FechaTR, NumeroTR, ImporteTR, GastosImp, GastosSF, GastosIva, ImporteNeto, Usuario, FechaMod) " & _
                                 "SELECT " & OrdenPagoId & ", Banco0, Cuenta0, Banco1, Cuenta1, Titular, FechaTR, NumeroTR, ImporteTR, GastosImp, GastosSF, GastosIva, ImporteNeto, '" & Uid & "', '" & Format(Now, FormatFechaHora) & "' " & _
                                 "FROM " & cTmpTr
                  .ExecuteNonQuery()
                  '
                  OrdenPagoTrID = CapturaDato(Cn, "OrdenPagoTR", "MAX(OrdenPagoTrId)", "", , , , Trn)
               Else
                  OrdenPagoTrID = CapturaDato(Cn, "OrdenPagoTR", "OrdenPagoTrId", "OrdenPagoId = " & OrdenPagoId, , , , Trn)
               End If
               '
               nBanco = CapturaDato(Cn, "OrdenPagoTR", "Banco0", "OrdenPagoTrID = " & OrdenPagoTrID, , , , Trn)
               cCuenta = CapturaDato(Cn, "OrdenPagoTR", "Cuenta0", "OrdenPagoTrID = " & OrdenPagoTrID, , , , Trn)
               cNumero = CapturaDato(Cn, "OrdenPagoTR", "NumeroTR", "OrdenPagoTrID = " & OrdenPagoTrID, , , , Trn)
               '
               If Estado = 1 Then
                  .CommandText = "DELETE FROM OrdenPagoTR WHERE OrdenPagoId = " & OrdenPagoId
                  .ExecuteNonQuery()
               End If

            End With
            '
            With Cmd
               .CommandText = "INSERT INTO BancosMov( Banco, BancoCta, TipoMovBco, NroMovBco, FechaEmi, FechaAcr, Debe, Haber, Estado, HojaBco, Detalle, Caja, Usuario, FechaMod) " & _
                              "VALUES(" & nBanco & ", " & _
                                    "'" & cCuenta & "', " & _
                                          nTipo & ", " & _
                                    "'" & IIf(Estado = 1, "-", "") & cNumero & "', " & _
                                    "'" & Format(Today, FormatFecha) & "', " & _
                                    "'" & Format(Today, FormatFecha) & "', " & _
                                          IIf(Estado = 2, 0, Val(tbTransf.Text)) & ", " & _
                                          IIf(Estado = 2, Val(tbTransf.Text), 0) & ", " & _
                                          0 & ", " & _
                                          0 & ", " & _
                                    "'" & "Transf. O.P. " & tbNumero.Text & "', " & _
                                          prmNroCaja & ", " & _
                                    "'" & Uid & "', " & _
                                    "'" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
               '
               If vGtosBanc <> 0 Then
                  .CommandText = "INSERT INTO BancosMov( Banco, BancoCta, TipoMovBco, NroMovBco, FechaEmi, FechaAcr, Debe, Haber, Estado, HojaBco, Detalle, Caja, Usuario, FechaMod) " & _
                                 "VALUES(" & nBanco & ", " & _
                                       "'" & cCuenta & "', " & _
                                             nTipo & ", " & _
                                       "'" & IIf(Estado = 1, "-", "") & cNumero & "', " & _
                                       "'" & Format(Today, FormatFecha) & "', " & _
                                       "'" & Format(Today, FormatFecha) & "', " & _
                                             IIf(Estado = 2, 0, vGtosBanc) & ", " & _
                                             IIf(Estado = 2, vGtosBanc, 0) & ", " & _
                                             0 & ", " & _
                                             0 & ", " & _
                                       "'" & "Gastos O.P. " & tbNumero.Text & "', " & _
                                             prmNroCaja & ", " & _
                                       "'" & Uid & "', " & _
                                       "'" & Format(Now, FormatFechaHora) & "')"
                  .ExecuteNonQuery()
               End If
               '
            End With
         End If
         '
         GuardarAudit(IIf(Estado = 1, "Des-", "") & "Confirma Orden de Pago Nº " & OPNumero, tbComprob.Text, Me.Name, Me.cmdConfirmar.Text, Trn)
         '
         Trn.Commit()
         '
         Return True
         '
      Catch ex As System.Exception
         '
         Dim st As New StackTrace(True)
         RegistrarError(st, "frmOrdenPagoConf")
         Trn.Rollback()
         '
      End Try
      '
   End Function
   '
   Private Sub tbEfectivo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbEfectivo.KeyPress
      SoloNumeros(e.KeyChar, True)
   End Sub
   '
   Private Sub tbEfectivo_TextChanged(sender As Object, e As EventArgs) Handles tbEfectivo.TextChanged, tbCheques.TextChanged, tbTransf.TextChanged
      CalcImportes()
   End Sub
   '
   Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
      Me.Close()
   End Sub
   '
   Private Sub frmOrdenPagoConf_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
      SetRegGrid(Me, DataGridView1)
      SetRegForm(Me)
      Me.Dispose()
   End Sub
   '
End Class