Imports System.Math
'
Public Class frmComprasAM
   '
   Public CompraID As Long
   Public EmpresaId As Integer
   Public OrdenPagoId As Long
   '
   Public Alta As Boolean
   Public Proveedor As Long
   Public SoloVer As Boolean
   Public SoloPerIva As Boolean
   Public SoloConcepto As Boolean
   '
   Dim Trn As OleDb.OleDbTransaction
   Dim Cmd As New OleDb.OleDbCommand
   Dim Cm2 As New OleDb.OleDbCommand
   Dim Drd As OleDb.OleDbDataReader
   '
   Dim TipoComp As Integer
   Dim IngresoId As Long
   Dim Imput As String
   '
   Dim cCtaPro As String
   Dim cCtaCaja As String
   '
   Dim Moneda As Integer
   Dim Contado As Boolean
   '
   Dim VerifCtas As Boolean
   '
   Dim AlicIva As String
   Dim nSubTotal As Double
   Dim AlicIva1 As Single
   Dim AlicIva2 As Single
   Dim i As Integer
   Dim LastKey As Integer
   Dim TipoIva As Integer
   Dim Letra As String
   Dim PagoID As Long
   Dim Dias As Integer
   Dim IngAuto As Boolean
   Dim PedidoPrID As Long
   '
   Dim cTmp As String
   Dim cTmpCh As String
   Dim cTmpCmp As String
   Dim Aceptado As Boolean
   Dim FormLoad As Boolean = False
   '
   Const cmpINT = "CM"
   Const cStruct = "Renglon INT NOT NULL, " & _
                   "Proveedor INT, " & _
                   "TipoComp SMALLINT, " & _
                   "Sucursal SMALLINT, " & _
                   "Numero INT, " & _
                   "Producto INT DEFAULT 0, " & _
                   "Concepto INT DEFAULT 0, " & _
                   "CodProd VARCHAR (50), " & _
                   "Partida VARCHAR (20) NOT NULL DEFAULT '', " & _
                   "FechaVenc SMALLDATETIME, " & _
                   "Detalle VARCHAR (50), " & _
                   "Cantidad FLOAT, " & _
                   "Costo FLOAT DEFAULT 0, " & _
                   "Bonificacion VarChar (25), " & _
                   "SubTotal FLOAT, " & _
                   "NoGravado FLOAT NULL, " & _
                   "IngresoId INT NULL, " & _
                   "RtoRenglon SMALLINT NULL, " & _
                   "AlicuoIva REAL NULL"
   '
   Const cStructCh = "Renglon SMALLINT NOT NULL, " & _
                     "Origen VARCHAR (1), " & _
                     "ChequeID INT NOT NULL, " & _
                     "Banco INT, " & _
                     "BancoCta VARCHAR (25), " & _
                     "ChNumero VARCHAR (25), " & _
                     "Titular VARCHAR (50), " & _
                     "Importe FLOAT, " & _
                     "Fecha SMALLDATETIME"
   '
   Private Sub frmComprasAM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      '
      GetRegForm(Me)
      '
      Me.Text = Me.Text & " - " & Traducir(IIf(SoloVer, "Consulta", IIf(Alta, "Alta", "Modificación")))
      '
      If Alta Then
         If SuperaRegistros("Compras") Then
            DeshabForm(Me)
            Exit Sub
         End If
      End If
      '
      If SisContable Then
         If cfgCtaIvaCF1 <> "" Then
            If cfgCtaIvaCF2 <> "" Then
               If CaptCtasCaja(prmNroCaja, cCtaCaja, "") Then
                  VerifCtas = True
               End If
            End If
         End If
         If Not VerifCtas Then
            MensajeTrad("CtasNoDef")
            DeshabForm(Me)
         End If
      End If
      '
      Cmd.Connection = cn
      Cm2.Connection = cn
      '
      cTmp = ""
      cTmpCmp = ""
      cTmpCh = ""
      CrearTabla(cn, cStruct, cTmp)
      CrearTabla(cn, "Renglon SMALLINT NOT NULL, CompraID INT NOT NULL, Saldo FLOAT NULL, PagoPrId INT NULL", cTmpCmp)
      CrearTabla(cn, cStructCh, cTmpCh)
      '
      If Not Alta And Proveedor = 0 Then
         chkCasual.Checked = True
      End If
      '
      If EmpresaId = 0 Then
         EmpresaId = prmEmpresaId
      End If
      ArmaComboItem(cboEmpresa, "Empresas", "EmpresaId", "EmpNombre", "EmpNombre", "(Empresa)", "EmpresaId <> 0")
      With cboEmpresa
         If .Items.Count = 1 Then
            .Enabled = False
         Else
            PosCboItem(cboEmpresa, EmpresaId)
         End If
      End With
      '
      ArmaCboProveedor()
      '
      With cboLetra
         .Items.Add("A")
         .Items.Add("C")
      End With
      '
      ArmaComboItem(cboTipoIva, "TipoIva", "TipoIva", , , "(Tipo de IVA)")
      ArmaComboItem(cboTipoComp, "TipoComp", "TipoComp", , , "(Tipo de Cpte.)", "ParaFact <> 0")
      ArmaCombo(cboAlicIVA, "Descrip", "AlicIva", "Descrip", , , "(Alic. IVA)")
      '
      If Alta Then
         tbFecha.Value = Today
         tbFecha.MaxDate = Today
         tbFecVenc.Value = Today
         tbPerIVA.Value = Today
         PagoID = 0
         IngAuto = True
      Else
         If Not SoloPerIva Then
            If Val(CapturaDato(cn, "Pagos C, PagosDet D", "RboNumero", "C.PagoID = D.PagoID AND D.CompraID = " & CompraID) & "") <> 0 Then
               MensajeTrad("CompraPagada")
               DeshabForm(Me)
            End If
         End If
         '
         Proveedor_Val()
         PagoID = CapturaDato(cn, "Pagos C, PagosDet D", "C.PagoID", "C.PagoID = D.PagoID AND D.CompraID = " & CompraID)
         txtDetPago.Text = CapturaDato(cn, "Pagos", "Detalle", "PagoID = " & PagoID) & ""
         '
         With Cmd
            .CommandText = "SELECT * FROM Compras WHERE CompraID = " & CompraID
            Drd = .ExecuteReader
         End With
         '
         With Drd
            If .Read Then
               If Not chkCasual.Checked = False Then
                  cboProveedor.Text = CapturaDato(cn, "Proveedores", "Nombre", "Proveedor = " & !Proveedor)
               Else
                  cboProveedor.Text = !Nombre
               End If
               tbSucursal.Text = !CompSucursal
               tbNumero.Text = !CompNumero
               txtCuit.Text = !Cuit
               tbFecha.Value = !Fecha
               tbFecha.MaxDate = Today
               tbFecVenc.MinDate = tbFecha.Value
               tbFecVenc.Value = !FechaVenc
               tbPerIVA.Value = "01/" & !PerIva
               tbSubtotal.Text = Format(Abs(!SubTotal), cfgFormatoPr)
               txtDescuento.Text = Val(!Descuento & "")
               tbGravado.Text = Format(Abs(!Gravado), cfgFormatoPr)
               tbNoGravado.Text = Format(Abs(!NoGravado), cfgFormatoPr)
               tbCompraRNI.Text = Format(Abs(!CompraRni), cfgFormatoPr)
               tbExento.Text = Format(Abs(!Exento), cfgFormatoPr)
               tbIVA1.Text = Format(Abs(!Iva1), cfgFormatoPr)
               tbIVA2.Text = Format(Abs(!Iva2), cfgFormatoPr)
               txtRetIva.Text = Format(Abs(!RetIva), cfgFormatoPr)
               txtRetIB.Text = Format(Abs(!RetIB), cfgFormatoPr)
               txtRetGan.Text = Format(Abs(!RetGAN), cfgFormatoPr)
               txtTotal.Text = Format(Abs(!Total), cfgFormatoPr)
               tbDetalle.Text = !Detalle & ""
               TipoIva = !TipoIva
               AlicIva = !AlicIva
               Letra = !CompLetra
               TipoComp = !TipoComp
               optContado.Checked = (!CondVenta = 1)
               optCtaCte.Checked = (!CondVenta = 2)
               'CompServ = True
               'CompProd = True
               IngresoId = IIf(IsDBNull(!IngresoId), 0, !IngresoId)
               If IngresoId = 0 Then
                  IngAuto = True
               Else
                  IngAuto = CapturaDato(cn, "Ingresos", "Auto", "IngresoID = " & IngresoId)
               End If
               If Not IsDBNull(!PedidoPrID) Then
                  PosCboItem(cboPedidoPr, !PedidoPrID)
               End If
               '
               PosicionarComboItem(cboTipoComp, TipoComp)
               PosicionarComboItem(cboTipoIva, TipoIva)
               '
               cboLetra.Text = Letra
               '
            Else
               MensajeTrad("ComprNoEnc")
               DeshabForm(Me)
            End If
            '
            .Close()
            '
         End With
         '
         With Cmd
            .CommandText = "SELECT * FROM Pagos WHERE PagoID = " & PagoID
            Drd = .ExecuteReader
         End With
         '
         With Drd
            If .Read Then
               txtEfectivo.Text = !Efectivo
               txtCheques.Text = !Cheques
            End If
            .Close()
         End With
         '
         Trn = cn.BeginTransaction
         '
         Cmd.Transaction = Trn
         Cmd.CommandText = "INSERT INTO " & cTmp & "( Renglon, Producto, Partida, Concepto, CodProd, Detalle, Cantidad, Costo, Bonificacion, FechaVenc, SubTotal, IngresoId, RtoRenglon) " & _
                          "SELECT C.CompRenglon, C.Producto, C.Partida, C.Concepto, P.CodProd, ISNULL(C.Detalle, P.Descrip), ABS(C.Cantidad), ABS(C.Costo), C.Bonificacion, C.FechaVenc, ABS(C.SubTotal), C.IngresoId, C.RtoRenglon " & _
                          "FROM ComprasDet C, Productos P " & _
                          "WHERE C.Producto = P.Producto " & _
                          "  AND C.CompraID = " & CompraID
         Cmd.ExecuteNonQuery()
         '
         Cmd.CommandText = "INSERT INTO " & cTmpCh & "( Renglon, Origen, ChequeID, Banco, BancoCta, ChNumero, Titular, Importe, Fecha) " & _
                          "SELECT C.Renglon, 'P', C.ChequeID, H.Banco, H.BancoCta, H.ChPropNro, '', H.Importe, H.FechaDif " & _
                          "FROM PagosDetCh C, ChPropios H " & _
                          "WHERE C.PagoID = " & PagoID & _
                          "  AND C.ChequeID = H.ChPropID " & _
                          "  AND C.Origen = 'P' " & _
                          "UNION " & _
                          "SELECT C.Renglon, 'C', C.ChequeID, H.Banco, H.BancoCta, H.ChCartNro, H.Titular, H.Importe, H.FechaDif " & _
                          "FROM PagosDetCh C, ChCartera H " & _
                          "WHERE C.PagoID = " & PagoID & _
                          "  AND C.ChequeID = H.ChCartID" & _
                          "  AND C.Origen = 'C'"
         Cmd.ExecuteNonQuery()
         '
         Trn.Commit()
         '
      End If
      '
      cboAlicIVA.Text = CapturaDato(cn, "AlicIva", "Descrip", "AlicIva = '" & AlicIva & "'")
      '
      ssTab1.SelectedIndex = 0
      ssTab1.TabPages(1).Hide()

      cmdSiguiente.Enabled = False
      '
      FormLoad = True
      '
      ActData()
      '
      If Not Alta Then
         Aceptar()
      End If
      '
   End Sub
   '
   Private Sub frmComprasAM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
      TabReturn(e.KeyChar)
   End Sub
   '
   Private Sub cboPedidoPr_Click()
      With cboPedidoPr
         If .SelectedIndex > 0 Then
            PedidoPrID = .SelectedValue
         Else
            PedidoPrID = 0
         End If
      End With
   End Sub
   '
   Private Sub cmdNuevoProv_Click()
      If TienePermiso(cn, Uid, MdiMenu.mProveedores.Name) Then
         With frmProveedoresAM
            .Alta = True
            .Show(Me)
         End With
         ArmaCboProveedor()
      End If
   End Sub
   '
   Private Sub cboEmpresa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEmpresa.SelectedIndexChanged
      With cboEmpresa
         If .SelectedIndex <= 0 Then
            EmpresaId = 0
         Else
            EmpresaId = .SelectedValue
         End If
      End With
      ActData()
   End Sub
   '
   Private Sub cboAlicIVA_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboAlicIVA.SelectedIndexChanged
      AlicIva = CapturaDato(cn, "AlicIva", "AlicIva", "Descrip = '" & cboAlicIVA.Text & "'")
      With Cmd
         .CommandText = "SELECT * FROM AlicIva WHERE AlicIva = '" & AlicIva & "'"
         Drd = .ExecuteReader
         With Drd
            If .Read Then
               AlicIva1 = !Alicuo1
               AlicIva2 = !Alicuo2
            Else
               AlicIva1 = 0
               AlicIva2 = 0
            End If
            .Close()
         End With
         lblIva1.Text = Traducir("IVA") & " " & AlicIva1 & "%"
         lblIva2.Text = Traducir("IVA") & " " & AlicIva2 & "%"
      End With
   End Sub
   '
   Private Sub btnCheques_Click(sender As Object, e As EventArgs) Handles btnCheques.Click
      With frmPagoCh
         '.SoloVer = SoloVer
         .TablaAct = cTmpCh
         .ShowDialog(Me)
         txtCheques.Text = .Total
      End With
   End Sub
   '
   Private Sub cmdSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSiguiente.Click
      ssTab1.SelectedIndex = 1
   End Sub
   '
   Private Sub cmdAnterior_Click(sender As Object, e As EventArgs) Handles cmdAnterior.Click
      ssTab1.SelectedIndex = 0
   End Sub
   '
   Private Sub cmdRefRemito_Click(sender As Object, e As EventArgs) Handles cmdRefRemito.Click
      With frmComprasRefRto
         .TablaAct = cTmp
         .Proveedor = Proveedor
         .Show(Me)
         If .IngresoId <> 0 Then
            IngresoId = .IngresoId
            IngAuto = False
            ActData()
         End If
      End With
   End Sub
   '
   Private Sub DataGrid1_DblClick()
      If cmdEdicion.Enabled Then
         Modif()
      End If
   End Sub
   '
   Private Sub chkCasual_CheckedChanged(sender As Object, e As EventArgs) Handles chkCasual.CheckedChanged
      ArmaCboProveedor()
      cboProveedor.DropDownStyle = IIf(chkCasual.Checked, ComboBoxStyle.DropDown, ComboBoxStyle.DropDownList)
   End Sub
   '
   Private Sub ArmaCboProveedor()
      If Not chkCasual.Checked Then
         ArmaComboItem(cboProveedor, "Proveedores", "Proveedor", "Nombre", "Nombre", "(Proveedor)", "Proveedor <> 0 AND Inactivo = 0")
         PosicionarComboItem(cboProveedor, Proveedor)
      Else
         ArmaCombo(cboProveedor, "Nombre", "ProveedoresCas", , , "Nombre")
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
   Private Sub cboProveedor_Leave(sender As Object, e As EventArgs) Handles cboProveedor.Leave
      Proveedor_Val()
   End Sub
   '
   Private Sub Proveedor_Val()
      '
      'Dim i As Integer
      Dim Rs As New OleDb.OleDbCommand
      Dim DR As OleDb.OleDbDataReader
      '
      With Rs
         .Connection = cn
         If chkCasual.Checked = False Then
            .CommandText = "SELECT * FROM Proveedores WHERE Proveedor = " & Proveedor
         Else
            .CommandText = "SELECT * FROM ProveedoresCas WHERE Nombre = '" & cboProveedor.Text & "'"
         End If
         DR = .ExecuteReader
      End With
      '
      With DR
         If Not .Read Then
            txtCuit.Text = "  -        - "
            cboTipoIva.SelectedIndex = -1
            cboTipoIva.Enabled = True
         Else
            If IsDBNull(!Cuit) Then
               txtCuit.Text = "  -        - "
            Else
               txtCuit.Text = !Cuit
            End If
            If Not chkCasual.Checked Then
               optContado.Checked = (!CondVenta < 2)
               optCtaCte.Checked = (!CondVenta = 2)
               If !CondVenta = 1 Then
                  Contado = True
               Else
                  Contado = False
               End If
               Dias = Val(!Dias & "")
               AlicIva = !AlicIva
            Else
               Contado = True
               optContado.Checked = True
               Dias = 0
               AlicIva = "GEN"
            End If
            '
            PosCboItem(cboTipoIva, CapturaDato(Cn, "TipoIva", "TipoIva", "Codigo = '" & !TipoIva & "'"))
            cboAlicIVA.Text = CapturaDato(Cn, "AlicIva", "Descrip", "Codigo = '" & AlicIva & "'")
            '
            Fecha_Change()
            '
            If SisContable Then
               If chkCasual.Checked = False Then
                  cCtaPro = !CtaCont & ""
               Else
                  cCtaPro = cfgCtaProVar
               End If
            End If
         End If
         .Close()
      End With
      '
      ArmaCboPedidoPr()
      '
      ActivaCtrl(False)
      '
   End Sub
   '
   Private Sub ArmaCboPedidoPr()
      ArmaComboItem(cboPedidoPr, "PedidosProv", "PedidoPrID", "PedidoPrNro", "PedidoPrNro", "(Ninguno)", _
                    "Proveedor = " & Proveedor & _
                    " AND NOT EXISTS( SELECT PedidoPrID FROM Compras WHERE CompraID <> " & CompraID & " AND PedidoPrID = " & PedidoPrID & ")")
   End Sub
   '
   Private Sub cboTipoIva_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipoIva.SelectedIndexChanged
      '
      Dim Cmd As New OleDb.OleDbCommand
      Dim Drd As OleDb.OleDbDataReader
      '
      With cboTipoIva
         If .SelectedIndex > 0 Then
            TipoIva = .SelectedValue
         Else
            TipoIva = 0
         End If
      End With
      '
      With Cmd
         .Connection = cn
         .CommandText = "SELECT * FROM TipoIva WHERE TipoIva = " & TipoIva
         Drd = .ExecuteReader
      End With
      '
      With Drd
         If Not .Read Then
            cboTipoIva.SelectedIndex = -1
            .Close()
         Else
            If Trim(!EmiteComp) = "" Then
               MensajeTrad("TIvaNoPerm")
               cboLetra.SelectedIndex = -1
               .Close()
               Exit Sub
            End If
            '
            Letra = Strings.Left(Trim(!EmiteComp & ""), 1)
            .Close()
            '
            For i = 0 To cboLetra.Items.Count - 1
               If cboLetra.Items(i) = Letra Then
                  cboLetra.SelectedIndex = i
               End If
            Next i
            '
         End If
      End With
      '
   End Sub
   '
   Private Sub cboTipoComp_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipoComp.SelectedIndexChanged
      With cboTipoComp
         If .SelectedIndex > 0 Then
            TipoComp = .SelectedValue
         Else
            TipoComp = 0
         End If
      End With
      Imput = CapturaDato(cn, "TipoComp", "Imput", "TipoComp = " & TipoComp)
   End Sub
   '
   Private Sub cboLetra_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboLetra.SelectedIndexChanged
      CalcImportes()
   End Sub
   '
   Private Sub optContado_CheckedChanged(sender As Object, e As EventArgs) Handles optContado.CheckedChanged
      If Aceptado Then
         ActivaCtrl(True)
      End If
      Dias = 0
   End Sub
   '
   Private Sub optCtaCte_CheckedChanged(sender As Object, e As EventArgs) Handles optCtaCte.CheckedChanged
      If Aceptado Then
         ActivaCtrl(True)
      End If
   End Sub
   '
   Private Sub tbCompraRni_Change()
      SumTotal()
   End Sub
   '
   Private Sub tbCompraRni_GotFocus()
      'PintarTb(tbCompraRNI)
   End Sub
   '
   Private Sub tbExento_Change()
      SumTotal()
   End Sub
   '
   Private Sub tbExento_GotFocus()
      'PintarTb(tbExento)
   End Sub
   '
   Private Sub tbFecha_ValueChanged(sender As Object, e As EventArgs) Handles tbFecha.ValueChanged
      Fecha_Change()
   End Sub
   '
   Private Sub Fecha_Change()
      '
      With tbFecVenc
         If .Value < tbFecha.Value Then
            .Value = tbFecha.Value
         End If
         .MinDate = tbFecha.Value
      End With
      '
      If Dias = 0 Then
         tbFecVenc.Value = tbFecha.Value
      Else
         tbFecVenc.Value = tbFecha.Value.AddDays(Dias)
      End If
      '
      If Format(tbFecha.Value, "yyyymm") <= cfgPerCierreIVA Then
         tbPerIVA.Value = CDate("01/" & Mid(cfgPerCierreIVA, 4, 2) & "/" & Mid(cfgPerCierreIVA, 4)).AddMonths(1)
      Else
         tbPerIVA.Value = tbFecha.Value
      End If
      '
   End Sub
   '
   Private Sub cmdAceptar_Click(sender As Object, e As EventArgs) Handles cmdAceptar.Click
      Aceptar()
   End Sub
   '
   Private Sub Aceptar()
      If Not Validar1() Then Exit Sub
      ActData()
      CalcImportes()
      Aceptado = True
      ActivaCtrl(True)
   End Sub
   '
   Private Sub ActivaCtrl(ByVal Activo As Boolean)
      '
      'Dim Ctrl As Control
      '
      cmdAceptar.Enabled = Not Activo
      tbSucursal.Enabled = Not Activo
      tbNumero.Enabled = Not Activo
      cboProveedor.Enabled = Not Activo
      cboTipoComp.Enabled = Not Activo
      chkCasual.Enabled = Not Activo
      cmdNuevoProv.Enabled = Not Activo
      'cmdSalir.Cancel = Not Activo
      '
      cboTipoIva.Enabled = Activo And Not SoloPerIva And Not SoloConcepto
      txtCuit.Enabled = Activo And Not SoloPerIva And Not SoloConcepto
      cboLetra.Enabled = Activo And Not SoloPerIva And Not SoloConcepto
      tbFecha.Enabled = Activo And Not SoloPerIva And Not SoloConcepto
      tbFecVenc.Enabled = Activo And optCtaCte.Checked And Not SoloPerIva And Not SoloConcepto
      tbPerIVA.Enabled = Activo And Not SoloConcepto
      optContado.Enabled = Activo And Not SoloPerIva And Not SoloConcepto
      optCtaCte.Enabled = Activo And Not Contado And Not SoloPerIva And Not SoloConcepto
      cmdRefRemito.Enabled = Activo And Alta And Not SoloPerIva And Not SoloConcepto
      '
      txtDescuento.Enabled = Activo And Not SoloPerIva And Not SoloConcepto
      tbGravado.Enabled = Activo And Not SoloPerIva And Not SoloConcepto
      txtGravado2.Enabled = Activo And Not SoloPerIva And Not SoloConcepto
      tbNoGravado.Enabled = Activo And Not SoloPerIva And Not SoloConcepto
      tbIVA1.Enabled = Activo And Not SoloPerIva And Not SoloConcepto
      tbIVA2.Enabled = Activo And Not SoloPerIva And Not SoloConcepto
      tbCompraRNI.Enabled = Activo And Not SoloPerIva And Not SoloConcepto
      tbExento.Enabled = Activo And Not SoloPerIva And Not SoloConcepto
      txtRetIva.Enabled = Activo And Not SoloPerIva And Not SoloConcepto
      txtRetIB.Enabled = Activo And Not SoloPerIva And Not SoloConcepto
      txtRetGan.Enabled = Activo And Not SoloPerIva And Not SoloConcepto
      txtTotal.Enabled = Activo And Not SoloPerIva And Not SoloConcepto
      tbDetalle.Enabled = Activo And Not SoloPerIva And Not SoloConcepto
      '
      cmdGuardar.Enabled = Activo And Not SoloVer
      cmdCancelar.Enabled = Activo And Not SoloVer
      'cmdCancelar.Cancel = Activo And Not SoloVer
      '
      cmdAltaProd.Enabled = Activo And Not SoloPerIva And Not SoloConcepto
      cmdAltaServ.Enabled = Activo And Not SoloPerIva And Not SoloConcepto
      '
      cmdSiguiente.Enabled = Activo And optContado.Checked And Not SoloPerIva And Not SoloConcepto
      cmdAnterior.Enabled = Activo And optContado.Checked And Not SoloPerIva And Not SoloConcepto
      cmdGuardar.Enabled = Activo And Not optContado.Checked And Not SoloVer And Not SoloPerIva And Not SoloConcepto
      cmdGuardar2.Enabled = Activo And optContado.Checked And Not SoloPerIva And Not SoloConcepto
      ssTab1.TabPages(1).Enabled = Activo And optContado.Checked And Not SoloPerIva And Not SoloConcepto
      cboAlicIVA.Enabled = Activo And Not SoloPerIva And Not SoloPerIva And Not SoloConcepto
      cboPedidoPr.Enabled = Activo And Not SoloPerIva And Not SoloConcepto
      '
   End Sub
   '
   Private Sub cmdAltaProd_Click(sender As Object, e As EventArgs) Handles cmdAltaProd.Click
      AltaMod(True, False)
   End Sub
   '
   Private Sub cmdAltaServ_Click(sender As Object, e As EventArgs) Handles cmdAltaServ.Click
      AltaMod(True, True)
   End Sub
   '
   Private Sub cmdEdicion_Click(sender As Object, e As EventArgs) Handles cmdEdicion.Click
      Modif()
   End Sub
   '
   Private Sub Modif()
      With DataGridView1
         If .RowCount > 0 Then
            AltaMod(False, .SelectedCells(.Columns("Producto").Index).Value = 0)
         End If
      End With
   End Sub
   '
   Private Sub cmdBaja_Click(sender As Object, e As EventArgs) Handles cmdBaja.Click
      With DataGridView1
         Dim Renglon As Int16 = .SelectedCells(.Columns("Renglon").Index).Value
         If MsgBox("Elimina renglon " & Renglon & " : " & .SelectedCells(.Columns("Detalle").Index).Value, vbQuestion & vbYesNo) = vbYes Then
            Trn = cn.BeginTransaction
            Cmd.Transaction = Trn
            Cmd.CommandText = "DELETE FROM " & cTmp & " WHERE Renglon = " & Renglon
            Cmd.ExecuteNonQuery()
            Trn.Commit()
            ActData()
         End If
      End With
   End Sub
   '
   Private Sub AltaMod(ByVal Alta As Boolean, ByVal CompServ As Boolean)
      '
      Dim Renglon As Integer
      Dim Concepto As Integer
      Dim Producto As Long
      Dim Cantidad As Double
      Dim Costo As Double
      Dim Bonificacion As String = ""
      '
      If Alta Then
         Renglon = CapturaDato(cn, cTmp, "ISNULL(MAX(Renglon),0)", "") + 1
         Concepto = 0
         Producto = 0
         Cantidad = 0
         Costo = 0
         Bonificacion = ""
      Else
         With DataGridView1
            If .RowCount > 0 Then
               Renglon = .SelectedCells(.Columns("Renglon").Index).Value
               Concepto = .SelectedCells(.Columns("Concepto").Index).Value
               Producto = .SelectedCells(.Columns("Producto").Index).Value
               Cantidad = .SelectedCells(.Columns("Cantidad").Index).Value
               Costo = .SelectedCells(.Columns("Costo").Index).Value
               Bonificacion = .SelectedCells(.Columns("Bonificacion").Index).Value
            End If
         End With
      End If
      '
      If CompServ Then
         Dim Frm As New frmComprasDet
         With Frm
            .Frm = Me
            .Tabla = cTmp
            .AlicIva = IIf(cboLetra.Text = "A", AlicIva1 + AlicIva2, 0)
            .Alta = Alta
            .Concepto = Concepto
            .Renglon = Renglon
            .SoloConcepto = SoloConcepto
            .ShowDialog(Me)
         End With
      Else
         Dim Frm As New frmIngProducto
         With Frm
            .FormAct = Me
            .TablaAct = cTmp
            .Alta = Alta
            .EmpresaId = EmpresaId
            If Alta Then
               .MantAbierto = True
            Else
               .Producto = Producto
               .Proveedor = Proveedor
               .Sucursal = tbSucursal.Text
               .Numero = tbNumero.Text
               .IngresoId = IngresoId
               .Renglon = Renglon
               .Cantidad = Cantidad
               .Costo = Costo
               .Bonificacion = Bonificacion
            End If
            .Renglon = Renglon
            .ShowDialog(Me)
         End With
      End If
      '
      ActData()
      '
   End Sub
   '
   Private Sub cmdGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGuardar.Click, cmdGuardar2.Click
      '
      If Validar2() Then
         If chkCasual.Checked Then
            If AltaAuto("ProveedoresCas", "", 0, "Nombre", cboProveedor.Text, TipoIva, txtCuit.Text, "Da de alta Proveedor") Then
               cboProveedor.Items.Add(cboProveedor.Text)
            End If
         End If
         If SoloPerIva Then
            GuardarPerIva()
            Me.Close()
         ElseIf SoloConcepto Then
            GuardarConcepto()
            Me.Close()
         Else
            If Guardar() Then
               Cancelar()
            End If
         End If
      End If
      '
   End Sub
   '
   Private Function Validar1() As Boolean
      '
      'On Error Resume Next
      '
      If EmpresaId = 0 Then
         If cboEmpresa.Enabled Then
            MensajeTrad("DSelEmpresa")
            cboEmpresa.Focus()
            Return False
         End If
      End If
      '
      If chkCasual.Checked And cboProveedor.Text = "" Or Not chkCasual.Checked And Proveedor = 0 Then
         MensajeTrad("DIProveedor")
         cboProveedor.Focus()
         Return False
      End If
      '
      If SisContable Then
         If cCtaPro = "" Then
            MensajeTrad("CtaProvNoDef")
            If cboProveedor.Enabled Then
               cboProveedor.Focus()
               Return False
            End If
         End If
      End If
      '
      If TipoComp = 0 Then
         MensajeTrad("DITipoComp")
         cboTipoComp.Focus()
         Return False
      End If
      '
      If tbSucursal.Text = "" Then
         MensajeTrad("DISucursal")
         tbSucursal.Focus()
         Return False
      End If
      '
      If Val(tbNumero.Text) = 0 Then
         MensajeTrad("DINumero")
         tbNumero.Focus()
         Return False
      End If
      '
      If Not IsNothing(CapturaDato(cn, "Compras", "CompNumero", "TipoComp = " & TipoComp & " AND Proveedor = " & Proveedor & " AND CompSucursal = " & tbSucursal.Text & " AND CompNumero = " & tbNumero.Text)) Then
         If Alta Then
            MensajeTrad("ComprExist")
            tbNumero.Focus()
            Return False
         End If
      End If
      '
      Return True
      '
   End Function
   '
   Private Function Validar2() As Boolean
      '
      If TipoIva = 0 Then
         MensajeTrad("DITipoIva", , False)
         cboTipoIva.Focus()
         Return False
      End If
      '
      If txtCuit.Text = "  -        - " Then
         MensajeTrad("DICuit", , False)
         txtCuit.Focus()
         Return False
      End If
      '
      If TipoComp = 0 Then
         MensajeTrad("DIComprob", , False)
         cboTipoComp.Focus()
         Return False
      End If
      '
      If Format(tbPerIVA.Value, "yyyy/MM") < Format(tbFecha.Value, "yyyy/MM") Then
         MensajeTrad("PerIvaIncorr", , False)
         tbPerIVA.Focus()
         Return False
      End If
      '
      If DataGridView1.RowCount = 0 Then
         'If Not CompProd Then
         'MensajeTrad("DIServicios", , False)
         'cmdAltaServ.Focus()
         'ElseIf Not CompServ Then
         'MensajeTrad("DIProductos", , False)
         'cmdAltaProd.Focus()
         'Else
         MensajeTrad("DIProdOServ", , False)
         cmdAltaProd.Focus()
      End If
      '
      If Format(Val(txtTotal.Text), cfgFormatoPr) <> Format(Val(tbGravado.Text) + Val(txtGravado2.Text) + Val(tbNoGravado.Text) + Val(tbCompraRNI.Text) + Val(tbExento.Text) + Val(tbIVA1.Text) + Val(tbIVA2.Text) + Val(txtRetGan.Text) + Val(txtRetIB.Text) + Val(txtRetIva.Text), cfgFormatoPr) Then
         MensajeTrad("ImportIncorr", , False)
         txtTotal.Focus()
         Return False
      End If
      '
      If Format(Val(tbGravado.Text), cfgFormatoPr) <> Format(Val(tbSubtotal.Text), cfgFormatoPr) Then
         If Format(Val(tbGravado.Text) + Val(txtGravado2.Text), cfgFormatoPr) <> Format(Val(tbSubtotal.Text), cfgFormatoPr) Then
            If Format(Val(tbGravado.Text) + Val(txtGravado2.Text) + Val(tbNoGravado.Text) + _
                      Val(tbCompraRNI.Text) + Val(tbExento.Text), cfgFormatoPr) <> Format(tbSubtotal.Text, cfgFormatoPr) Then
               MensajeTrad("ImportIncorr", , False)
               tbGravado.Focus()
               Return False
            End If
         End If
      End If
      '
      If optContado.Checked Then
         If Format(Val(txtTotal.Text), cfgFormatoPr) <> Format(Val(txtEfectivo.Text) + Val(txtCheques.Text), cfgFormatoPr) Then
            MensajeTrad("ImpPagoIncorr", , False)
            ssTab1.SelectedIndex = 1
            If txtEfectivo.Enabled Then
               txtEfectivo.Focus()
               Return False
            End If
         End If
      End If
      '
      Return True
      '
   End Function
   '
   Sub ActData()
      '
      If Not FormLoad Then Exit Sub
      '
      SetRegGrid(Me, DataGridView1)
      '
      LlenarGrid(DataGridView1, "SELECT T.Renglon, T.Producto, T.Partida, T.FechaVenc, T.Concepto, T.CodProd, T.Detalle, T.Cantidad, T.Costo, T.Bonificacion, T.Subtotal, T.NoGravado, I.RtoNumero, I.FechaIng, D.Cantidad AS RtoCant, T.IngresoId, T.RtoRenglon, T.AlicuoIva " & _
                                "FROM " & cTmp & " T LEFT JOIN Ingresos I ON T.IngresoId = I.IngresoId " & _
                                " LEFT JOIN IngresosDet D ON I.IngresoId = D.IngresoId AND T.RtoRenglon = D.RtoRenglon ")
      '
      With DataGridView1
         cmdBaja.Enabled = (IIf(.RowCount > 0, True, False) And Not SoloPerIva And Not SoloConcepto)   'And IngAuto
         cmdEdicion.Enabled = IIf(.RowCount > 0, True, False) And Not SoloPerIva
         '
         For Each Columna As DataGridViewColumn In .Columns
            With Columna
               Select Case UCase(.Name)
                  Case "CODPROD" : .Width = 100 ': .Visible = Not CompServ
                     'Case "CONCEPTO" : .Width = 50 : .Visible = CompServ
                  Case "DETALLE" : .Width = 500 : .HeaderText = "Descripción"
                  Case "COSTO" : .Width = 100 : .DefaultCellStyle.Format = "#,##0.00 " : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                  Case "CANTIDAD" : .Width = 100 : .DefaultCellStyle.Format = "#,##0.00 " : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                  Case "BONIFICACION" : .Width = 100 : .HeaderText = "Bonif."
                  Case "SUBTOTAL" : .Width = 100 : .DefaultCellStyle.Format = "#,##0.00 " : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                  Case "RTONUMERO" : .Width = 100 : .HeaderText = "Remito"
                  Case "FECHAING" : .Width = 100 : .HeaderText = "Fec.Rto."
                  Case "RTOCANT" : .Width = 100 : .HeaderText = "Cant.Rto."
                  Case Else : .Visible = False
               End Select
            End With
         Next Columna
      End With
      '
      GetRegGrid(Me, DataGridView1)
      CalcImportes()
      '
   End Sub
   '
   Private Sub CalcImportes()
      '
      Dim NoGravado As Double
      '
      nSubTotal = 0
      '
      '* AlicIva1 = Val(CapturaDato(cn, cTmp, "TOP 1 AlicuoIva", "") & "")
      lblIva1.Text = Traducir("IVA") & " " & AlicIva1 & "%"
      '
      nSubTotal = Val(CapturaDato(cn, cTmp, "SUM(Subtotal)", "") & "")
      NoGravado = Val(CapturaDato(cn, cTmp, "SUM(NoGravado)", "") & "")
      '
      '   With Adodc1.Recordset
      '      If .RecordCount > 0 Then
      '         .MoveFirst
      '         Do While Not .EOF
      '            nSubTotal = nSubTotal + Val(!SubTotal & "")
      '            NoGravado = NoGravado + Val(!NoGravado & "")
      '            .MoveNext
      '         Loop
      '         .MoveFirst
      '      End If
      '   End With
      '
      tbSubtotal.Text = Format(nSubTotal, cfgFormatoPr)
      '
      If Val(tbGravado.Text) <> Val(tbSubtotal.Text) Then
         If Val(tbGravado.Text) + Val(txtGravado2.Text) + Val(tbNoGravado.Text) + Val(tbCompraRNI.Text) + Val(tbExento.Text) <> nSubTotal Then
            '
            tbGravado.Text = Format(0, cfgFormatoPr)
            tbNoGravado.Text = Format(NoGravado, cfgFormatoPr)
            tbCompraRNI.Text = Format(0, cfgFormatoPr)
            tbExento.Text = Format(0, cfgFormatoPr)
            tbIVA1.Text = Format(0, cfgFormatoPr)
            tbIVA2.Text = Format(0, cfgFormatoPr)
            txtRetGan.Text = Format(0, cfgFormatoPr)
            txtRetIB.Text = Format(0, cfgFormatoPr)
            txtRetIva.Text = Format(0, cfgFormatoPr)
            txtTotal.Text = Format(0, cfgFormatoPr)
            '
            If cboLetra.Text = "A" Then
               tbGravado.Text = Format(nSubTotal - NoGravado, cfgFormatoPr)
               tbIVA1.Text = Format(Round(Val(tbGravado.Text) * AlicIva1 / 100, 2), cfgFormatoPr)
               tbIVA2.Text = Format(Round(Val(txtGravado2.Text) * AlicIva2 / 100, 2), cfgFormatoPr)
            ElseIf cboLetra.Text = "B" Then
               tbNoGravado.Text = Format(nSubTotal, cfgFormatoPr)
            Else
               tbCompraRNI.Text = Format(nSubTotal - NoGravado, cfgFormatoPr)
            End If
            '
            SumTotal()
            '
         End If
      End If
   End Sub
   '
   Private Sub SumTotal()
      txtTotal.Text = Format(Val(tbGravado.Text) + Val(txtGravado2.Text) + Val(tbNoGravado.Text) + _
                             Val(tbIVA1.Text) + Val(tbIVA2.Text) + _
                             Val(tbCompraRNI.Text) + Val(tbExento.Text) + _
                             Val(txtRetGan.Text) + Val(txtRetIB.Text) + _
                             Val(txtRetIva.Text), cfgFormatoPr)
   End Sub
   '
   Private Function Guardar() As Boolean
      '
      'Dim OrdenPagoId As Int32 = 0
      '
      Dim CodAsi As String = ""
      Dim NroAsi As Long
      Dim RenASi As Integer
      Dim DetAsi As String = ""
      Dim DetAsiR As String
      '
      Try
         '
         Trn = cn.BeginTransaction
         '
         Cmd.Transaction = Trn
         '
         If SisContable Then
            CodDetAsi(CodAsi, DetAsi)
         End If
         '
         'If CompProd Then
         If Not IsNothing(CapturaDato(cn, cTmp, "Producto", "Producto <> 0", , , , Trn)) Then
            'If IngresoID = 0 Then
            If IngAuto Then
               'IngresoID = GuardarIngreso(IngresoID, Proveedor, 0, 0, tbFecha, tbFecha, tbDetalle, cTmp, False, True)
               GuardarIngreso(IngresoId, Proveedor, 0, 0, tbFecha.Value, tbFecha.Value, tbDetalle.Text, cTmp, False, True, EmpresaId, , , Trn)
            End If
            If Not Alta Then
               Cmd.CommandText = "UPDATE IngresosDet SET " & _
                                " Saldo = Saldo + ISNULL((SELECT Cantidad FROM ComprasDet " & _
                                "                  WHERE Producto = IngresosDet.Producto " & _
                                "                    AND RtoRenglon = IngresosDet.RtoRenglon " & _
                                "                    AND IngresoID = IngresosDet.IngresoId), 0) " & _
                                "WHERE IngresoId IN( SELECT IngresoID FROM ComprasDet WHERE CompraId = " & CompraID & ")"
               Cmd.ExecuteNonQuery()
            End If
            Cmd.CommandText = "UPDATE IngresosDet SET " & _
                             " Saldo = Saldo - ISNULL((SELECT Cantidad FROM " & cTmp & " " & _
                             "                  WHERE Producto = IngresosDet.Producto " & _
                             "                    AND RtoRenglon = IngresosDet.RtoRenglon " & _
                             "                    AND IngresoId = IngresosDet.IngresoID), 0) " & _
                             "WHERE IngresoID IN( SELECT IngresoID FROM " & cTmp & ")"
            Cmd.ExecuteNonQuery()
         End If
         '
         With Cmd
            If IsNothing(CapturaDato(cn, "Compras", "CompraId", "CompraID = " & CompraID, , , , Trn)) Then
               .CommandText = "INSERT INTO Compras( TipoComp, Proveedor, CompSucursal, CompNumero, EmpresaId, Sucursal, CompLetra, Fecha, FechaVenc, PerIva, Nombre, TipoIva, Cuit, SubTotal, Descuento, Gravado, Gravado2, NoGravado, CompraRni, Exento, Iva1, Iva2, RetIva, RetIB, RetGAN, Total, Detalle, CompServ, CondVenta, Estado, IngresoId, AlicIva, AlicIva1, AlicIva2, PedidoPrID, Usuario, FechaMod) " & _
                              "VALUES(" & TipoComp & ", " & _
                                          Proveedor & ", " & _
                                          Val(tbSucursal.Text) & ", " & _
                                          Val(tbNumero.Text) & ", " & _
                                          EmpresaId & ", " & _
                                          prmSucursal & ", " & _
                                    "'" & cboLetra.Text & "', " & _
                                    "'" & tbFecha.Value & "', " & _
                                    "'" & tbFecVenc.Value & "', " & _
                                    "'" & Format(tbPerIVA.Value, "MM/yyyy") & "', " & _
                                    "'" & cboProveedor.Text & "', " & _
                                          TipoIva & ", " & _
                                    "'" & txtCuit.Text & "', " & _
                                          Val(tbSubtotal.Text) * IIf(Imput = "D", 1, -1) & ", " & _
                                          Val(txtDescuento.Text) * IIf(Imput = "D", 1, -1) & ", " & _
                                          Val(tbGravado.Text) * IIf(Imput = "D", 1, -1) & ", " & _
                                          Val(txtGravado2.Text) * IIf(Imput = "D", 1, -1) & ", " & _
                                          Val(tbNoGravado.Text) * IIf(Imput = "D", 1, -1) & ", " & _
                                          Val(tbCompraRNI.Text) * IIf(Imput = "D", 1, -1) & ", " & _
                                          Val(tbExento.Text) * IIf(Imput = "D", 1, -1) & ", " & _
                                          Val(tbIVA1.Text) * IIf(Imput = "D", 1, -1) & ", " & _
                                          Val(tbIVA2.Text) * IIf(Imput = "D", 1, -1) & ", " & _
                                          Val(txtRetIva.Text) * IIf(Imput = "D", 1, -1) & ", " & _
                                          Val(txtRetIB.Text) * IIf(Imput = "D", 1, -1) & ", " & _
                                          Val(txtRetGan.Text) * IIf(Imput = "D", 1, -1) & ", " & _
                                          Val(txtTotal.Text) * IIf(Imput = "D", 1, -1) & ", " & _
                                    "'" & tbDetalle.Text & "', " & _
                                          0 & ", " & _
                                          IIf(optContado.Checked, 1, 2) & ", " & _
                                          IIf(optContado.Checked, 3, 0) & ", " & _
                                          IngresoId & ", " & _
                                    "'" & AlicIva & "', " & _
                                          AlicIva1 & ", " & _
                                          AlicIva2 & ", " & _
                                          PedidoPrID & ", " & _
                                    "'" & Uid & "', " & _
                                    "'" & Now & "')"
               .ExecuteNonQuery()
               CompraID = CapturaDato(cn, "Compras", "MAX(CompraId)", "", , , , Trn)
            Else
               .CommandText = "UPDATE Compras SET " & _
                              " TipoComp = " & TipoComp & ", " & _
                              " Proveedor = " & Proveedor & ", " & _
                              " CompSucursal = " & Val(tbSucursal.Text) & ", " & _
                              " CompNumero = " & Val(tbNumero.Text) & ", " & _
                              " EmpresaId = " & EmpresaId & ", " & _
                              " Sucursal = " & prmSucursal & ", " & _
                              " CompLetra = '" & cboLetra.Text & "', " & _
                              " Fecha = '" & Format(tbFecha.Value, FormatFecha) & "', " & _
                              " FechaVenc = '" & Format(tbFecVenc.Value, FormatFecha) & "', " & _
                              " PerIva = '" & Format(tbPerIVA.Value, "MM/yyyy") & "', " & _
                              " Nombre = '" & cboProveedor.Text & "', " & _
                              " TipoIva = " & TipoIva & ", " & _
                              " Cuit = '" & txtCuit.Text & "', " & _
                              " SubTotal = " & Val(tbSubtotal.Text) * IIf(Imput = "D", 1, -1) & ", " & _
                              " Descuento = " & Val(txtDescuento.Text) * IIf(Imput = "D", 1, -1) & ", " & _
                              " Gravado = " & Val(tbGravado.Text) * IIf(Imput = "D", 1, -1) & ", " & _
                              " Gravado2 = " & Val(txtGravado2.Text) * IIf(Imput = "D", 1, -1) & ", " & _
                              " NoGravado = " & Val(tbNoGravado.Text) * IIf(Imput = "D", 1, -1) & ", " & _
                              " CompraRni = " & Val(tbCompraRNI.Text) * IIf(Imput = "D", 1, -1) & ", " & _
                              " Exento = " & Val(tbExento.Text) * IIf(Imput = "D", 1, -1) & ", " & _
                              " Iva1 = " & Val(tbIVA1.Text) * IIf(Imput = "D", 1, -1) & ", " & _
                              " Iva2 = " & Val(tbIVA2.Text) * IIf(Imput = "D", 1, -1) & ", " & _
                              " RetIva = " & Val(txtRetIva.Text) * IIf(Imput = "D", 1, -1) & ", " & _
                              " RetIB = " & Val(txtRetIB.Text) * IIf(Imput = "D", 1, -1) & ", " & _
                              " RetGAN = " & Val(txtRetGan.Text) * IIf(Imput = "D", 1, -1) & ", " & _
                              " Total = " & Val(txtTotal.Text) * IIf(Imput = "D", 1, -1) & ", " & _
                              " Detalle = '" & tbDetalle.Text & "', " & _
                              " CompServ = 0, " & _
                              " CondVenta = " & IIf(optContado.Checked, 1, 2) & ", " & _
                              " Estado = " & IIf(optContado.Checked, 3, 0) & ", " & _
                              " IngresoId = " & IngresoId & ", " & _
                              " AlicIva = '" & AlicIva & "', " & _
                              " AlicIva1 = " & AlicIva1 & ", " & _
                              " AlicIva2 = " & AlicIva2 & ", " & _
                              " PedidoPrID = " & PedidoPrID & ", " & _
                              " Usuario = '" & Uid & "', " & _
                              " FechaMod = '" & Format(Now, FormatFechaHora) & "' " & _
                              "WHERE CompraID = " & CompraID
               .ExecuteNonQuery()
               '
               OrdenPagoId = Val(CapturaDato(Cn, "OrdenPagoDet", "OrdenPagoId", "Proveedor = " & Proveedor & " AND ProComprob = '" & TipoComp & "' AND ProSucursal = " & Val(tbSucursal.Text) & " AND ProNumero = " & Val(tbNumero.Text)) & "")
               '
            End If
            '
            .CommandText = "DELETE FROM CtaCtePro WHERE CompraID = " & CompraID
            .ExecuteNonQuery()
            '
            If optCtaCte.Checked Then
               '
               .CommandText = "INSERT INTO CtaCtePro( Sucursal, Departamento, TipoComp, Proveedor, ProSucursal, ProNumero, EmpresaId, Fecha, FechaVenc, Debe, Haber, Saldo, CompraID, Usuario, FechaMod) " & _
                              "VALUES(" & prmSucursal & ", " & _
                                          prmDepart & ", " & _
                                          TipoComp & ", " & _
                                          Proveedor & ", " & _
                                          Val(tbSucursal.Text) & ", " & _
                                          Val(tbNumero.Text) & ", " & _
                                          EmpresaId & ", " & _
                                    "'" & Format(tbFecha.Value, FormatFecha) & "', " & _
                                    "'" & Format(tbFecVenc.Value, FormatFecha) & "', " & _
                                          IIf(Imput = "D", Val(txtTotal.Text), 0) & ", " & _
                                          IIf(Imput = "H", Val(txtTotal.Text), 0) & ", " & _
                                          Val(txtTotal.Text) * IIf(Imput = "D", 1, -1) & ", " & _
                                          CompraID & ", " & _
                                    "'" & Uid & "', " & _
                                    "'" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
               '
            End If
            '
         End With
         '
         If SisContable Then
            NroAsi = GuardaAsiento(CodAsi, tbFecha.Value, DetAsi, Trn)
            If NroAsi = 0 Then
               Err.Raise(1001, , "NoUpAsiento")
            End If
            '
            If Not BorraAsienDet(NroAsi, Trn) Then
               Err.Raise(1001, , "NoDelAsiDet")
            End If
         End If
         '
         GuardarRenglones(NroAsi, DetAsi, Trn)
         '
         If SisContable Then
            If Val(tbIVA1) > 0 Then
               RenASi = RenASi + 1
               If Not GuardaAsienDet(NroAsi, RenASi, cfgCtaIvaCF1, DetAsiR.Substring(1, 50), Val(tbIVA1), 0, Trn) Then
                  Err.Raise(1001, , "NoUpDetAsi")
               End If
            End If
            '
            If Val(tbIVA2) > 0 Then
               RenASi = RenASi + 1
               If Not GuardaAsienDet(NroAsi, RenASi, cfgCtaIvaCF2, DetAsiR.Substring(1, 50), Val(tbIVA2), 0, Trn) Then
                  Err.Raise(1001, , "NoUpDetAsi")
               End If
            End If
            '
            RenASi = RenASi + 1
            If Not GuardaAsienDet(NroAsi, RenASi, cCtaPro, DetAsiR.Substring(1, 50), 0, Val(txtTotal.Text), Trn) Then
               Err.Raise(1001, , "NoUpDetAsi")
            End If
         End If
         '
         If optContado.Checked Then
            Cmd.CommandText = "INSERT INTO " & cTmpCmp & "( Renglon, CompraID) VALUES( 1, " & CompraID & ")"
            Cmd.ExecuteNonQuery()
            GuardarOrdenPago(True, "OP", Proveedor, Today, txtTotalPago.Text, Val(txtEfectivo.Text), Val(txtCheques.Text), 0, 0, txtDetPago.Text, OrdenPagoId, prmNroCaja, "", cTmpCmp, cTmpCh, "", 0, True)
         End If
         '
         Trn.Commit()
         '
         Return True
         '
      Catch ex As System.Exception
         Dim st As New StackTrace(True)
         RegistrarError(st, Me.Name)
         Trn.Rollback()
         Return False
      End Try
      '
   End Function
   '
   Private Sub GuardarRenglones(ByRef NroAsi As Long, ByVal DetAsi As String, Optional Tr As Object = "", Optional IniTrans As Boolean = False)
      '
      Dim Producto, Concepto As Int32
      Dim nRenglon As Integer
      Dim RenASi As Integer
      Dim DetAsiR As String = ""
      Dim cCtaReng, Detalle, RtoRenglon As String
      Dim Cantidad As Double
      '
      If IniTrans Then
         Tr = cn.BeginTransaction
      End If
      '
      With Cmd
         If Tr.ToString <> "" Then
            .Transaction = Tr
         End If
         .CommandText = "DELETE FROM ComprasDet WHERE CompraID = " & CompraID
         .ExecuteNonQuery()
         '
         .CommandText = "SELECT * FROM " & cTmp
         Drd = .ExecuteReader
      End With
      '
      With Drd
         While .Read
            nRenglon = nRenglon + 1
            Producto = .Item("Producto")
            Concepto = .Item("Concepto")
            Detalle = IIf(Producto = 0, "'" & .Item("Detalle") & "'", "Null")
            Cantidad = .Item("Cantidad") * IIf(Imput = "D", 1, -1)
            If IsDBNull(.Item("RtoRenglon")) Then
               RtoRenglon = "NULL"
            Else
               RtoRenglon = .Item("RtoRenglon")
            End If
            '
            If Tr.ToString <> "" Then
               Cm2.Transaction = Tr
            End If
            '
            Cm2.CommandText = "INSERT INTO ComprasDet( CompraID, CompRenglon, Producto, Partida, Concepto, Detalle, Costo, Bonificacion, Cantidad, SubTotal, Descuento, IngresoId, RtoRenglon, Usuario, FechaMod) " & _
                              "VALUES (" & CompraID & ", " & .Item("Renglon") & ", " & .Item("Producto") & ", '" & .Item("Partida") & "', " & .Item("Concepto") & ", " & Detalle & ", " & .Item("Costo") & ", '" & .Item("Bonificacion") & "', " & Cantidad & ", " & .Item("SubTotal") & ", 0, " & .Item("IngresoId") & ", " & RtoRenglon & ", '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
            Cm2.ExecuteNonQuery()
            '
            If SisContable Then
               '
               DetAsiR = DetAsiR & .Item("Detalle") & "- "
               RenASi = RenASi + 1
               '
               If Concepto <> 0 Then
                  cCtaReng = CapturaDato(cn, "Conceptos", "CtaCont", "Concepto = " & .Item("Concepto"), , , , Tr)
               Else
                  cCtaReng = cfgCtaMerc
               End If
               '
               If Not GuardaAsienDet(NroAsi, RenASi, cCtaReng, DetAsi, .Item("SubTotal"), 0, Tr) Then
                  Err.Raise(1001, , "NoUpDetAsi")
               End If
            End If
            '
         End While
         '
         .Close()
         '
      End With
      '
      If IniTrans Then
         Tr.Commit()
      End If
      '
   End Sub
   '
   Private Function GuardarPerIva() As Boolean
      '
      If IsNothing(CapturaDato(cn, "Compras", "CompraId", "CompraID = " & CompraID)) Then
         MensajeTrad("Compra no encontrada")
         Return False
      End If
      '
      Trn = cn.BeginTransaction
      '
      With Cmd
         .Transaction = Trn
         .CommandText = "UPDATE Compras SET " & _
                        " PerIva = '" & Format(tbPerIVA, "MM/yyyy") & "', " & _
                        " Usuario = '" & Uid & "', " & _
                        " FechaMod = '" & Now & "' " & _
                        "WHERE CompraID = " & CompraID
         .ExecuteNonQuery()
      End With
      '
      Trn.Commit()
      '
      Return True
      '
   End Function
   '
   Private Function GuardarConcepto() As Boolean
      '
      Dim NroAsi As Long
      Dim CodAsi As String = ""
      Dim DetAsi As String = ""
      '
      If SisContable Then
         CodDetAsi(CodAsi, DetAsi)
         NroAsi = CapturaAsiento(CodAsi)
      End If
      '
      GuardarRenglones(NroAsi, DetAsi, Trn, True)
      '
      GuardarConcepto = True
      '
   End Function
   '
   Private Sub CodDetAsi(ByRef CodAsi, ByRef DetAsi)
      CodAsi = cmpINT & "-" & Proveedor & "-" & tbSucursal.Text & "-" & tbNumero.Text
      DetAsi = Strings.Left(cboProveedor.Text & "-" & cboTipoComp.Text & "-" & tbSucursal.Text & "-" & tbNumero.Text, 50)
   End Sub
   '
   Private Sub LimpiaTemp()
      Trn = cn.BeginTransaction
      With Cmd
         .Transaction = Trn
         .CommandText = "DELETE FROM " & cTmp
         .ExecuteNonQuery()
         .CommandText = "DELETE FROM " & cTmpCh
         .ExecuteNonQuery()
         .CommandText = "DELETE FROM " & cTmpCmp
         .ExecuteNonQuery()
      End With
      Trn.Commit()
      ActData()
   End Sub
   '
   Private Sub tbFecha_KeyDown1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tbFecha.KeyDown, tbFecVenc.KeyDown
      TabReturn(Chr(e.KeyCode))
   End Sub
   '
   Private Sub tbGravado_Change()
      tbIVA1.Text = Val(tbGravado.Text) * AlicIva1 / 100
      SumTotal()
   End Sub
   '
   Private Sub txtGravado2_Change()
      tbIVA2.Text = Val(txtGravado2.Text) * AlicIva2 / 100
      SumTotal()
   End Sub
   '
   Private Sub tbGravado_GotFocus()
      'PintarTb(tbGravado)
   End Sub

   Private Sub tbIva1_Change()
      SumTotal()
   End Sub
   '
   Private Sub tbIva1_GotFocus()
      'PintarTb(tbIVA1)
   End Sub
   '
   Private Sub tbIva2_Change()
      SumTotal()
   End Sub
   '
   Private Sub tbIva2_GotFocus()
      'PintarTb(tbIVA2)
   End Sub
   '
   Private Sub tbNoGravado_Change()
      SumTotal()
   End Sub
   '
   Private Sub tbNoGravado_GotFocus()
      'PintarTb(tbNoGravado)
   End Sub

   Private Sub txtRetGan_Change()
      SumTotal()
   End Sub

   Private Sub txtRetIB_Change()
      SumTotal()
   End Sub

   Private Sub txtRetIva_Change()
      SumTotal()
   End Sub
   '
   Private Sub txtRetIva_GotFocus()
      'PintarTb(txtRetIva)
   End Sub
   '
   Private Sub txtRetIB_GotFocus()
      'PintarTb(txtRetIB)
   End Sub
   '
   Private Sub txtRetGan_GotFocus()
      'PintarTb(txtRetGan)
   End Sub
   '
   Private Sub txtTotal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTotal.TextChanged
      txtTotalPago.Text = txtTotal.Text
   End Sub
   '
   Private Sub txtTotal_GotFocus(ByVal Index As Integer)
      'PintarTb(txtTotal(Index))
   End Sub
   '
   Private Sub tbNumero_GotFocus()
      'PintarTb(tbNumero)
   End Sub
   '
   Private Sub tbSucursal_GotFocus()
      'PintarTb(tbSucursal)
   End Sub
   '
   Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
      Cancelar()
   End Sub
   '
   Private Sub Cancelar()
      If Alta Then
         ActivaCtrl(False)
         LimpiaTemp()
         CalcImportes()
         Limpiacampos(Me, chkCasual.Name, cboTipoComp.Name, cboEmpresa.Name)
         Fecha_Change()
         ssTab1.SelectedIndex = 0
         CompraID = 0
         PagoID = 0
         IngresoId = 0
         IngAuto = True
         Aceptado = False
         cboProveedor.Focus()
      Else
         Me.Close()
      End If
   End Sub
   '
   Private Sub cmdSalir_Click(sender As Object, e As EventArgs) Handles cmdSalir.Click
      Me.Close()
   End Sub
   '
   Private Sub Form_Unload(ByVal Cancel As Integer)
      SetRegGrid(Me, DataGridView1)
      SetRegForm(Me)
      Me.Dispose()
   End Sub
   '
End Class