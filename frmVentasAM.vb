Imports System.ComponentModel

Public Class FrmVentasAM
   '
   Public EmpresaId As Integer
   Public Alta As Boolean
   Public Facturar As Boolean
   Public VentaID As Long
   Public CompraRtoId As Int32
   Public SoloVer As Boolean
   Public VentaServ As Boolean = False
   Public VentaProd As Boolean = False
   '
   Dim Trn As OleDb.OleDbTransaction
   Dim Cmd As New OleDb.OleDbCommand
   Dim Rs2 As New OleDb.OleDbCommand
   Dim Drd As OleDb.OleDbDataReader
   '
   Dim Cliente, Inquilino, Propietario As Int32
   Dim TipoIva As Byte
   Dim TipoComp As Byte
   '
   Dim cTipoIva As String
   Dim TCpteFiscal As String
   Dim TIvaFiscal As String
   Dim DomFiscal As String
   Dim LocFiscal As String
   '
   Dim Vendedor As Integer
   Dim CondVenta As Integer
   Dim PagoDif As Boolean
   Dim EgresoId As Long = 0
   Dim RemitoId As Long
   Dim SucursalDes As Integer
   Dim DepartDes As Integer
   Dim Comprob As String
   Dim Imput As String
   Dim LimCredito As Double
   Dim Dias As Integer
   Dim CobroID As Long
   Dim FormaPago As Integer
   Dim Moneda As Integer
   Dim lEfectivo As Boolean
   Dim lCheques As Boolean
   Dim lTarjetaC As Boolean
   Dim lTarjetaD As Boolean
   Dim Margen As Single
   Dim PresupID As Long
   Dim PedidoId As Long
   Dim TarjetaC As Integer
   Dim TarjetaD As Integer
   Dim TransporteID As Integer
   Dim EmiteComp As Boolean
   Dim BonifExtra As String
   Dim Letra As String
   '
   Dim cCtaCli As String
   Dim cCtaCaja As String
   '
   Dim VerifCtas As Boolean
   '
   Dim SubTotal, SubTotalBon, Gravado, noGravado, Exento, Iva1, Iva2 As Double
   Dim Bonific, AlicIva1, AlicIva2 As Single
   Dim AlicIva As String
   Dim i, Entrega As Integer
   Dim Aceptado As Boolean
   Dim BloqueoVta As Byte
   Dim FormLoad As Boolean = False
   '
   Dim cTmp, cTmpCh, cTmpCmp, cTmpRto As String
   '
   Const cmpINT = "VT"
   Const cStruct = "Renglon INT, " &
                   "Proveedor INT DEFAULT 0, " &
                   "Producto INT DEFAULT 0, " &
                   "Concepto INT DEFAULT 0, " &
                   "CodProd VARCHAR (50), " &
                   "Partida VARCHAR (20), " &
                   "Detalle VARCHAR (60), " &
                   "Cantidad FLOAT NOT NULL, " &
                   "Costo FLOAT DEFAULT 0, " &
                   "Precio FLOAT, " &
                   "Bonificacion VarChar (25) NULL, " &
                   "ImpInt FLOAT, " &
                   "SubTotal FLOAT, " &
                   "SubTotIva FLOAT, " &
                   "FechaVenc SMALLDATETIME, " &
                   "AlicuoIva REAL NULL, " &
                   "RemitoId INT NULL, " &
                   "Comprob VARCHAR(10) NULL"
   '
   Const cStructCh = "Renglon SMALLINT NOT NULL, " &
                     "ChCartID INT NOT NULL, " &
                     "Banco INT, " &
                     "BancoCta VARCHAR (25), " &
                     "ChCartNro VARCHAR (25), " &
                     "Titular VARCHAR (50), " &
                     "Entrego VARCHAR (50), " &
                     "Importe FLOAT, " &
                     "Fecha SMALLDATETIME, " &
                     "FechaEmi SMALLDATETIME"
   '
   Private Sub FrmVentasAM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      '
      Me.Text = IIf(Facturar, "Facturación", "Ventas") & " - " & Traducir(IIf(SoloVer, "Consulta", IIf(Alta, "Alta", "Modificación")))
      '
      If Alta Then
         If SuperaRegistros("Ventas") Then
            DeshabForm(Me)
            Exit Sub
         End If
      End If
      '
      If SisContable Then
         If cfgCtaIvaDF1 <> "" Then
            If cfgCtaIvaDF2 <> "" Then
               If cfgCtaValCar <> "" Then
                  If cfgCtaTarjC <> "" Then
                     If cfgCtaTarjD <> "" Then
                        If CaptCtasCaja(prmNroCaja, cCtaCaja, "") Then
                           VerifCtas = True
                        End If
                     End If
                  End If
               End If
            End If
         End If
         If Not VerifCtas Then
            MensajeTrad("CtasNoDef")
            DeshabForm(Me)
         End If
      End If
      '
      cTmp = ""
      CrearTabla(cn, cStruct, cTmp)
      '
      cTmpCh = ""
      CrearTabla(cn, cStructCh, cTmpCh)
      '
      cTmpCmp = ""
      CrearTabla(cn, "VentaID INT NOT NULL, PedidoID INT NULL, CobroId INT NULL, ImpPago FLOAT NOT NULL", cTmpCmp)
      '
      cTmpRto = ""
      CrearTabla(cn, "RemitoID INT NOT NULL", cTmpRto)
      '
      'If EmpresaId = 0 Then
      '   EmpresaId = prmEmpresaId
      'End If
      'ArmaComboItem(cboEmpresa, "Empresas", "EmpresaId", "EmpNombre", "EmpNombre", "(Empresa)", "EmpresaId <> 0")
      'With cboEmpresa
      '   If .Items.Count = 1 Then
      '      .Enabled = False
      '   Else
      '      PosCboItem(cboEmpresa, EmpresaId)
      '   End If
      'End With
      '
      tbFecha.MaxDate = Today
      'cmdAltaCliente.Enabled = TienePermiso(cn, Uid, frmMenu.mClientes.Name)
      '
      With cboLetra
         .Items.Add("(Letra)")
         .Items.Add("A")
         .Items.Add("B")
         .Items.Add("C")
      End With
      '
      ArmaComboItem(cboTipoComp, "TipoComp", "TipoComp", "Descrip", "Descrip", "(Tipo Comp.)", "ParaFact <> 0")
      If Alta Then
         PosTipoComp()
      End If
      '
      ArmaComboItem(cboTipoIva, "TipoIva", "TipoIva", , , , "TipoIva <> 0")
      'ArmaComboItem(cboCondVenta, "CondVenta", "CondVenta", , , "(Cond.Vta.)")
      With cboCondVenta
         .Items.Add("(Seleccionar)")
         .Items.Add("CONTADO")
         .Items.Add("CTA.CTE.")
         .SelectedIndex = 2
      End With
      '
      ArmaCboCliente()
      '
      'ArmaComboItem(cboVendedor, "Vendedores", "Vendedor", "Nombre", "Nombre", "(Vendedor)", "Vendedor <> 0")
      'ArmaComboItem(cboFormaPago, "FormasPagos", "FormaPago", , , "(Forma Pago)")
      'ArmaComboItem(cboTransporte, "Transportes", "TransporteID", "TranspDescrip", "TranspDescrip")
      '
      With cboEntrega
         .Items.Add("Inmediata")
         .Items.Add("a Retirar")
         .Items.Add("a Reparto")
      End With
      '
      Cmd.Connection = cn
      Rs2.Connection = cn
      '
      AlicIva = "GEN"
      '
      If Alta Then
         VentaID = 0
         tbSucursal.Text = Format(prmSucursal, "0000")
         tbFecha.Value = Today
         tbFecVenc.Value = Today
         Comprob = "Factura"
         PosTipoComp()
         cboEntrega.SelectedIndex = 0
      Else
         If Not SoloVer Then
            If Val(CapturaDato(cn, "Cobros C, CobrosDet D", "CobNumero", "C.CobroID = D.CobroID AND D.VentaID = " & VentaID) & "") <> 0 Then
               MensajeTrad("VentaCobrada", , False)
               DeshabForm(Me)
            End If
         End If
         '
         CobroID = CapturaDato(cn, "Cobros C, CobrosDet D", "C.CobroID", "C.CobroID = D.CobroID AND D.VentaID = " & VentaID)
         '
         Rs2.CommandText = "SELECT * FROM Ventas WHERE VentaID = " & VentaID
         Drd = Rs2.ExecuteReader
         With Drd
            If .Read Then
               If .Item("Cliente") = 0 Then
                  chkCasual.Checked = True
               End If
               Cliente = .Item("Cliente")
               tbFecha.Value = .Item("Fecha")
               If Not IsDBNull(.Item("FechaVenc")) Then
                  If .Item("FechaVenc") >= tbFecVenc.MinDate And .Item("FechaVenc") <= tbFecVenc.MaxDate Then
                     tbFecVenc.Value = .Item("FechaVenc")
                  End If
               End If
               cboLetra.Text = .Item("FactLetra")
               tbSucursal.Text = Format(.Item("Sucursal"), "0000")
               tbNumero.Text = Format(.Item("FactNumero"), "00000000")
               cboCliente.Text = .Item("Nombre")
               PosCboItem(cboTipoIva, .Item("TipoIva"))
               If .Item("Cuit") = "" Or IsDBNull(.Item("Cuit")) Then
                  tbCuit.Clear()   '  = MaskCuit
               Else
                  tbCuit.Text = .Item("Cuit") & ""
               End If
               PosCboItem(cboTipoComp, .Item("TipoComp"))
               PosicionarComboItem(cboCondVenta, .Item("CondVenta"))
               EgresoId = Val(.Item("EgresoId") & "")
               tbBonificacion.Text = .Item("Bonificacion")
               tbExento.Text = System.Math.Abs(Val(.Item("Exento") & ""))
               'PosCboItem(cboVendedor, .Item("Vendedor"))
               tbObserv.Text = .Item("Detalle") & ""
               VentaServ = .Item("VentaServ")
               PosCboItem(cboFormaPago, .Item("FormaPago"))
               If Not IsDBNull(.Item("TransporteID")) Then
                  PosCboItem(cboTransporte, .Item("TransporteID"))
               End If
               'tbRemito.Text = .Item("Remito") & ""
               cboEntrega.SelectedIndex = .Item("Entrega")
            End If
            .Close()
         End With
         With Rs2
            .CommandText = "SELECT * FROM Cobros WHERE CobroID = " & CobroID
            Drd = .ExecuteReader
         End With
         '
         With Drd
            If .Read Then
               tbEfectivo.Text = System.Math.Abs(.Item("Efectivo"))
               tbCheques.Text = System.Math.Abs(.Item("Cheques"))
               tbTarjetaC.Text = System.Math.Abs(.Item("ImpTarjetaC"))
               tbTarjetaD.Text = System.Math.Abs(.Item("ImpTarjetaD"))
               PosCboItem(cboTarjetaC, Val(.Item("TarjetaC") & ""))
               PosCboItem(cboTarjetaD, Val(.Item("TarjetaD") & ""))
            End If
            .Close()
         End With
         '
         Trn = cn.BeginTransaction
         '
         With Rs2
            .Transaction = Trn
            .CommandText = "INSERT INTO " & cTmp & "( Renglon, Proveedor, Producto, Concepto, CodProd, Detalle, Cantidad, Costo, Precio, Bonificacion, SubTotal, AlicuoIva, RemitoId ) " &
                           "SELECT D.FactRenglon, 0, D.Producto, D.Concepto, '', D.Descrip, ABS(D.Cantidad), D.Costo, D.Precio, D.Bonificacion, D.SubTotal, D.AlicuoIva, D.RemitoId " &
                           "FROM VentasDet D " &
                           "WHERE VentaID = " & VentaID & " AND D.Producto = 0 " &
                           "UNION " &
                           "SELECT D.FactRenglon, P.Proveedor, D.Producto, D.Concepto, P.CodProd, " & IIf(cfgSumDescRubro, "R.Descrip + ' ' + ", "") + "P.Descrip, ABS(D.Cantidad), D.Costo, D.Precio, D.Bonificacion, D.SubTotal, D.AlicuoIva, D.RemitoId " &
                           "FROM VentasDet D LEFT JOIN Productos P " &
                           " ON D.Producto = P.Producto " &
                           "INNER JOIN Rubros R ON P.Rubro = R.Rubro " &
                           "WHERE VentaID = " & VentaID & " AND D.Producto <> 0 " &
                           "ORDER BY D.FactRenglon"
            .ExecuteNonQuery()
            '
            If cboLetra.Text = "B" Then
               '.CommandText = "UPDATE " & cTmp & " SET " &
               '               " Precio = Precio * (1 + AlicuoIva / 100), " &
               '               " SubTotal = SubTotal * (1 + AlicuoIva / 100)"
               '.ExecuteNonQuery()
            End If
            .CommandText = "INSERT INTO " & cTmpCh & "( Renglon, ChCartID, Banco, BancoCta, ChCartNro, Titular, Importe, Fecha) " &
                           "SELECT C.Renglon, C.ChCartID, H.Banco, H.BancoCta, H.ChCartNro, H.Titular, H.Importe, H.FechaDif " &
                           "FROM CobrosDetCh C, ChCartera H " &
                           "WHERE C.CobroID = " & CobroID &
                           "  AND C.ChCartID = H.ChCartID"
            .ExecuteNonQuery()
            '
            .CommandText = "INSERT INTO " & cTmpRto & "( RemitoId) SELECT RemitoId FROM VentasRtos WHERE VentaId = " & VentaID
            .ExecuteNonQuery()
            '
         End With
         '
         Trn.Commit()
         '
      End If
      '
      ActData()
      '
      'cboLetra.Enabled = Alta And Not Facturar
      tbSucursal.Enabled = Alta And Not Facturar
      tbNumero.Enabled = Alta And Not Facturar
      '
      TabControl1.SelectedIndex = 0
      '
      If Not Alta Then
         Aceptar()
      End If
      '
      FormLoad = True
      '
   End Sub
   '
   Private Sub frmVentasAM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
      TabReturn(e.KeyChar)
   End Sub
   '
   Private Sub chkCasual_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCasual.CheckedChanged
      cboCliente.DropDownStyle = IIf(chkCasual.Checked, ComboBoxStyle.DropDown, ComboBoxStyle.DropDownList)
      ArmaCboCliente()
      cboCondVenta.Enabled = False   ' (Not chkCasual.Checked)
      'cmdAltaCliente.Enabled = (Not chkCasual.Checked)
      If chkCasual.Checked Then
         CondVenta = 1   'CapturaDato(cn, "CondVenta", "CondVenta", "Defecto <> 0")
         PosCboItem(cboCondVenta, CondVenta)
         cCtaCli = cfgCtaCliVar
         'cboVendedor.SelectedValue = 0
         'tbCliente.Text = ""
         Cliente = 0
      End If
   End Sub
   '
   Private Sub ArmaCboCliente()
      If optClientes.Checked Then
         If chkCasual.Checked Then
            'ArmaCombo(cboCliente, "Nombre", "ClientesCas", "Nombre", "")
            cboCliente.DataSource = Nothing
            cboCliente.Items.Clear()
         Else
            ArmaComboItem(cboCliente, "Clientes", "Codigo", "Nombre", "Nombre", "(Cliente)", "Codigo <> 0")
         End If
      ElseIf optInquilinos.Checked Then
         ArmaComboItem(cboCliente, "Inquilinos",, "Nombre", "Nombre",, "Estado = 'A'")
      ElseIf optPropietarios.Checked Then
         ArmaComboItem(cboCliente, "Propietarios",, "Nombre", "Nombre",, "Estado = 'A'")
      End If
   End Sub
   '
   'Private Sub cmdAltaCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAltaCliente.Click
   '   With frmClientesAM
   '      .Alta = True
   '      .Show()
   '      If .Cliente <> 0 Then
   '         ArmaCboCliente()
   '         PosCboItem(cboCliente, .Cliente)
   '      End If
   '   End With
   'End Sub
   '
   Private Sub cboEntrega_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboEntrega.SelectedIndexChanged
      Entrega = cboEntrega.SelectedIndex
      cboTransporte.Enabled = (Entrega = 2 And cboEntrega.Enabled)
   End Sub
   '
   Private Sub PosTipoComp()
      PosCboItem(cboTipoComp, 1)
   End Sub
   '
   Private Sub cboTarjetaC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTarjetaC.SelectedIndexChanged

   End Sub
   '
   Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
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

   Private Function Validar1() As Boolean
      '
      If optClientes.Checked Then
         If chkCasual.Checked Then
            If cboCliente.Text = "" Then
               MensajeTrad("DINomCliente", , False)
               If Alta Then cboCliente.Focus()
               Return False
            End If
         Else
            If Cliente = 0 Then
               MensajeTrad("DICliente", , False)
               If Alta Then cboCliente.Show()
               Return False
            End If
         End If

      ElseIf optInquilinos.Checked Then
         If Inquilino = 0 Then
            MensajeTrad("DIInquilino", , False)
            If Alta Then cboCliente.Show()
            Return False
         End If

      ElseIf optPropietarios.Checked Then
         If Propietario = 0 Then
            MensajeTrad("DIPropietario", , False)
            If Alta Then cboCliente.Show()
            Return False
         End If
      End If
      '
      If SisContable Then
         If cCtaCli = "" Then
            MensajeTrad("CtaClieNoAsig", , False)
            If Alta Then cboCliente.Show()
            Exit Function
         End If
      End If
      '
      If TipoIva = 0 Then
         MensajeTrad("DITipoIva", , False)
         cboTipoIva.Focus()
         Exit Function
      End If
      '
      If tbCuit.Enabled Then
         If tbCuit.Text = "  -        - " Then
            MensajeTrad("DICuit", , False)
            tbCuit.Focus()
            Exit Function
         End If
      End If
      '
      If TipoComp = 0 Then
         MensajeTrad("DIComprob", , False)
         cboTipoComp.Focus()
         Exit Function
      End If
      '
      If tbSucursal.Text = "" Then
         MensajeTrad("DISucursal", , False)
         tbSucursal.Focus()
         Exit Function
      End If
      '
      If Val(tbNumero.Text) = 0 Then
         MensajeTrad("DINumero", , False)
         tbNumero.Focus()
         Exit Function
      End If
      '
      If Alta Then
         If Not IsNothing(CapturaDato(Cn, "Ventas", "Numero", "Tipo = '" & Letra & "' AND Sucursal = " & tbSucursal.Text & " AND Numero = " & Val(tbNumero.Text))) Then
            MensajeTrad("ComprExist", , False)
            With tbNumero
               If .Enabled Then
                  .Focus()
               End If
            End With
            Exit Function
         End If
      End If
      '
      If CondVenta = 0 Then
         MensajeTrad("DICondVenta", , False)
         If cboCondVenta.Enabled Then
            cboCondVenta.Focus()
         End If
         Exit Function
      End If
      '
      If Facturar Then
         If BloqueoVta = 1 Then
            If PagoDif Then
               If Not ClaveSuperv() Then
                  MensajeTrad("Cta.Cte.Bloqueada")
                  Exit Function
               End If
            Else
               MensajeTrad("Cta.Cte.Bloqueada")
            End If
         End If
         '
         If BloqueoVta = 2 Then
            If Not ClaveSuperv() Then
               MensajeTrad("Cuenta Bloqueada")
               Exit Function
            End If
         End If
      End If
      '
      Validar1 = True
      '
   End Function
   '
   Private Sub cboTipoIva_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoIva.SelectedIndexChanged
      '
      Dim Cmd As New OleDb.OleDbCommand
      Dim Dr As OleDb.OleDbDataReader
      Dim Letra As String
      '
      With cboTipoIva
         If .SelectedIndex > 0 Then
            TipoIva = Val(.SelectedValue())
         Else
            TipoIva = 0
         End If
      End With
      '
      With Cmd
         .Connection = Cn
         .CommandText = "SELECT * FROM TipoIva WHERE TipoIva = " & TipoIva
         Dr = .ExecuteReader
      End With
      '
      With Dr
         If .Read Then
            '
            cTipoIva = .Item("Codigo")
            '
            If cfgAlicIva = 0 Then
               Letra = "C"
            Else
               Letra = Mid(Trim(.Item("RecibeComp")), 1, 1)
               'TIvaFiscal = !TIFiscal & ""
            End If
            '
            PosCombo(cboLetra, Letra)
            '
            If IsDBNull(.Item("EmiteComp")) Then
               With tbCuit
                  .Text = MaskCuit
                  .Enabled = False
               End With
               EmiteComp = False
            Else
               tbCuit.Enabled = (chkCasual.Checked)
               EmiteComp = True
            End If
            '
         Else
            'Me.cboTipoIva.SelectedIndex = -1
         End If
         .Close()
      End With

      Cmd.CommandText = "SELECT * FROM AlicIva WHERE AlicIva = 'GEN'"
      Dr = Cmd.ExecuteReader

      With Dr
         If .Read Then
            If cfgAlicIva = 0 Then
               AlicIva1 = 0
               AlicIva2 = 0
            Else
               AlicIva1 = .Item("Alicuo1")
               AlicIva2 = 0
            End If
         Else
            MensajeTrad("AlcIvaGenNEnc", , False)
            AlicIva1 = 0
            AlicIva2 = 0
         End If
         '
         lblIva1.Text = Traducir("IVA") & " " & AlicIva1 & "%"
         lblIva2.Text = Traducir("IVA") & " " & AlicIva2 & "%"
         '
         .Close()
      End With
      '
   End Sub
   '
   Public Sub ActData()
      '
      Dim CantReng, CantRtos As Int16
      '
      SetRegGrid(Me, DataGridView1)
      '
      CantRtos = Val(CapturaDato(Cn, cTmpRto, "COUNT(1)", ""))
      '
      'If CantRtos <= 1 Or chkDet.Checked Then
      LlenarGrid(DataGridView1, "SELECT T.* FROM " & cTmp & " T ORDER BY Renglon")
      'Else
      'LlenarGrid(DataGridView1, "SELECT R.Sucursal, R.RtoNumero, R.RtoFecha, R.RtoDetalle FROM " & cTmpRto & " T LEFT JOIN Remitos R ON T.RemitoId = R.RemitoId ORDER BY R.Sucursal, R.RtoNumero")
      'End If
      '
      'RemitoId = Val(CapturaDato(Cn, cTmp, "RemitoId", "") & "")
      '
      'If Val(tbRemito.Text) = 0 Then
      '   tbRemito.Text = CaptNroRemitos()
      'End If
      '
      'EgresoId = CapturaDato(Cn, "Remitos", "EgresoId", "RemitoId = " & RemitoId)
      '
      CantReng = Me.DataGridView1.RowCount
      'btnAlta.Enabled = (EgresoId = 0 And Aceptado And (CantReng < cfgMaxRengFact Or cfgMaxRengFact = 0) And VentaProd)
      btnAltaServ.Enabled = (Aceptado And (CantReng < cfgMaxRengFact Or cfgMaxRengFact = 0) And VentaServ)
      btnBaja.Enabled = (CantReng > 0 And (EgresoId = 0) And Aceptado)
      btnModif.Enabled = (CantReng > 0 And Aceptado) 'And (CantRtos <= 1 Or chkDet.Checked)
      '
      With DataGridView1
         For Each columna As DataGridViewColumn In .Columns
            With columna
               Select Case UCase(.Name)
                  Case "RENGLON" : .HeaderText = "Reng." : .Width = 25
                  Case "CONCEPTO" : .HeaderText = "Conc." : .Visible = VentaServ : .Width = 50 : .Visible = False
                  Case "CODPROD" : .Width = 75 : .Visible = Not VentaServ : .HeaderText = "Código"
                  Case "DETALLE" : .Width = 350
                  Case "CANTIDAD" : .Width = 60 : .DefaultCellStyle.Format = "#,##0.00 "
                  Case "PRECIO" : .Width = 60 : .DefaultCellStyle.Format = "#,##0.00 "
                  Case "BONIFICACION" : .Width = 30 : .DefaultCellStyle.Format = "0.00 " : .HeaderText = "Bonif."
                  Case "SUBTOTAL" : .Width = 75 : .DefaultCellStyle.Format = "#,##0.00 "
                  Case "PARTIDA" : .Visible = False
                  Case "PRODUCTO" : .Visible = False
                  Case "PROVEEDOR" : .Visible = False
                  Case "COSTO" : .Visible = False
                  Case "IMPINT" : .Visible = False
                  Case "FECHAVENC" : .Visible = False
                  Case "ALICUOIVA" : .HeaderText = "Alic.IVA"
                  Case "RTONUMERO" : .Width = 1000 : .HeaderText = "Remito"
                  Case "SUCURSAL"
                  Case "RTOFECHA" : .HeaderText = "Fecha"
                  Case "RTODETALLE" : .HeaderText = "Detalle"
                  Case Else
                     .Visible = False
               End Select
            End With
         Next columna
      End With
      '
      GetRegGrid(Me, DataGridView1)
      '
      CalcImportes()
      '
   End Sub
   '
   Private Function CaptNroRemitos() As String
      Dim r As String = ""
      'With Cmd
      '   .CommandText = "SELECT DISTINCT R.RtoNumero FROM " & cTmp & " T LEFT JOIN Remitos R ON T.RemitoId = R.RemitoId "
      '   Drd = .ExecuteReader
      'End With
      'With Drd
      '   While .Read
      '      r = IIf(r = "", "", r & "-") & .Item("RtoNumero")
      '   End While
      '   .Close()
      'End With
      Return r
   End Function
   '
   Private Sub tbBonificacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbBonificacion.KeyPress, tbGravado.KeyPress, tbNoGravado.KeyPress, tbIva1.KeyPress, tbIva2.KeyPress, tbExento.KeyPress, tbEfectivo.KeyPress, tbCheques.KeyPress, tbTarjetaC.KeyPress, tbTarjetaD.KeyPress
      SoloNumeros(e.KeyChar, True)
   End Sub
   '
   'Protected Sub ActImportesTmp()
   '   Dim Cmd As New OleDb.OleDbCommand
   '   Dim Drd As OleDb.OleDbDataReader
   '   '
   '   With Cmd
   '      .Connection = cn
   '      .CommandText = "UPDATE " & cTmp & " SET AlicuoIva = " & cfgAlicIva & " WHERE AlicuoIva IS NULL"
   '      .ExecuteNonQuery()

   '      If cboLetra.Text = "B" Then
   '         .CommandText = "UPDATE " & cTmp & " SET Precio = Precio * (1 + AlicuoIva)"
   '         .ExecuteNonQuery()
   '         .CommandText = "UPDATE " & cTmp & " SET SubTotal Precio * Cantidad"
   '         .ExecuteNonQuery()
   '      End If
   '   End With
   '   '
   'End Sub
   '
   Private Sub TbBonificacion_TextChanged(sender As Object, e As EventArgs) Handles tbBonificacion.TextChanged
      CalcImportes()
   End Sub
   '
   Private Sub BtnRecalc_Click(sender As Object, e As EventArgs) Handles btnRecalc.Click
      CalcImportes()
   End Sub
   '
   Private Sub CalcImportes()
      '
      Dim Cmd As New OleDb.OleDbCommand
      Dim Drd As OleDb.OleDbDataReader
      '
      SubTotal = 0
      SubTotalBon = 0
      Iva1 = 0
      Iva2 = 0
      noGravado = 0
      Exento = 0
      '
      If Alta Then
         tbGravado.Text = Format(0, "Fixed")
         tbNoGravado.Text = Format(0, "Fixed")
         tbExento.Text = Format(0, "Fixed")
         tbIva1.Text = Format(0, "Fixed")
         tbIva2.Text = Format(0, "Fixed")
         tbTotal.Text = Format(0, "Fixed")
         tbTotal2.Text = Format(0, "Fixed")
      End If
      '
      'SubTotal = Val(CapturaDato(cn, cTmp, "SUM(SubTotal " & IIf(Letra = "B", "/ ( 1 + AlicuoIva / 100)", "") & ")", "") & "")
      SubTotal = Val(CapturaDato(Cn, cTmp, "SUM(SubTotal)", "") & "")
      Bonific = Val(tbBonificacion.Text)
      '
      With Cmd
         .Connection = Cn
         .CommandText = "UPDATE " & cTmp & " SET AlicuoIva = " & cfgAlicIva & " WHERE AlicuoIva IS NULL"
         .ExecuteNonQuery()
         '
         .CommandText = "SELECT DISTINCT AlicuoIva FROM " & cTmp
         Drd = .ExecuteReader
      End With
      '
      With Drd
         Do While .Read
            If !AlicuoIva = cfgAlicIva Then
               AlicIva1 = !AlicuoIva
               lblIva1.Text = "Iva. " & AlicIva1 & "%"
               'If cboLetra.Text = "B" Then
               'Iva1 = Iva1 + CapturaDato(cn, cTmp, "SUM(SubTotal) - SUM(Subtotal) / (1.0  + " & AlicIva1 & " / 100.0)", "AlicuoIva = " & AlicIva1)
               'Else
               Iva1 = Iva1 + CapturaDato(Cn, cTmp, "SUM(Subtotal) * " & AlicIva1 & " / 100", "AlicuoIva = " & AlicIva1)
               'End If
            Else
               AlicIva2 = !AlicuoIva
               lblIva2.Text = "Iva. " & AlicIva2 & "%"
               'If cboLetra.Text = "B" Then
               'Iva2 = Iva2 + CapturaDato(cn, cTmp, "SUM(SubTotal) - SUM(Subtotal) / (1.0  + " & AlicIva2 & " / 100.0)", "AlicuoIva = " & AlicIva2)
               'Else
               Iva2 = Iva2 + CapturaDato(Cn, cTmp, "SUM(Subtotal) * " & AlicIva2 & " / 100", "AlicuoIva = " & AlicIva2)
               'End If
            End If
         Loop
         .Close()
      End With
      '
      If regHabFactEl Then
         Exento = CapturaDato(Cn, cTmp, "ISNULL( SUM( SubTotal), 0)", "AlicuoIva = 0")
      Else
         noGravado = CapturaDato(Cn, cTmp, "ISNULL( SUM( SubTotal), 0)", "AlicuoIva = 0")
      End If
      '
      'If cboLetra.Text = "B" Then
      'SubTotal = SubTotal / (1 + (AlicIva1 + AlicIva2) / 100)
      'Gravado = CapturaDato(cn, cTmp, "ISNULL( SUM(SubTotal), 0)", "AlicuoIva = " & AlicIva1) / (1 + AlicIva1 / 100)
      'If AlicIva2 <> 0 Then
      'Gravado = Gravado + CapturaDato(cn, cTmp, "ISNULL( SUM(SubTotal), 0)", "AlicuoIva = " & AlicIva2) / (1 + AlicIva2 / 100)
      'End If
      'Else
      Gravado = CapturaDato(Cn, cTmp, "ISNULL( SUM(SubTotal), 0)", "AlicuoIva <> 0")
      'End If
      '
      tbSubtotal.Text = Format(SubTotal, cfgFormatoPr)
      '
      SubTotalBon = SubTotal - SubTotal * Val(tbBonificacion.Text) / 100
      '
      If Letra = "A" Or Letra = "B" Then
         tbGravado.Text = Format(Gravado - Gravado * Bonific / 100, cfgFormatoPr)
         tbNoGravado.Text = Format(noGravado - noGravado * Bonific / 100, cfgFormatoPr)
         tbExento.Text = Format(Exento - Exento * Bonific / 100, cfgFormatoPr)
         'Iva1 = SubTotalBon * AlicIva1 / 100
         'Iva2 = SubTotalBon * AlicIva2 / 100
         tbIva1.Text = Format(Iva1 - Iva1 * Bonific / 100, cfgFormatoPr)
         tbIva2.Text = Format(Iva2 - Iva2 * Bonific / 100, cfgFormatoPr)
      Else
         'tbNoGravado.Text = Format(SubTotalBon, cfgFormatoPr)
      End If
      '
      LlenarTxt()
      '
      If Imput = "H" Then
         If Not PagoDif Then
            cboFormaPago.SelectedIndex = -1
            PosCboItem(cboFormaPago, 1)
         End If
      End If
      '
   End Sub
   '
   Private Sub LlenarTxt()
      tbTotal.Text = Format(Val(tbGravado.Text) + Val(tbNoGravado.Text) +
                     Val(tbIva1.Text) + Val(tbIva2.Text) +
                     Val(tbExento.Text), cfgFormatoPr)
      tbTotal2.Text = tbTotal.Text
   End Sub
   '
   Private Sub tbGravado_TextChanged(sender As Object, e As EventArgs) Handles tbGravado.TextChanged, tbNoGravado.TextChanged, tbIva1.TextChanged, tbIva2.TextChanged, tbExento.TextChanged
      LlenarTxt()
   End Sub
   '
   Private Sub cboLetra_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLetra.SelectedIndexChanged
      Letra = cboLetra.Text
      CalcNumeros()
      CalcImportes()
   End Sub
   '
   Private Sub CalcNumeros(Optional Trn As Object = "")
      If Alta Then
         If Letra <> "" Then
            'If cfgNumNCSep Then
            'tbNumero.Text = Format(CaptNroFact(EmpresaId, Val(tbSucursal.Text), Letra, Comprob, Trn), "00000000")
            'Else
            'tbNumero.Text = Format(CaptNroFact(EmpresaId, Val(tbSucursal.Text), Letra, , Trn), "00000000")
            'End If
            tbNumero.Text = Format(CaptNroFactura(Letra, tbSucursal.Text), "00000000")
         End If
      End If
   End Sub
   '
   Private Sub ActivaCtrl(ByVal Activo As Boolean)
      '
      Dim CntRg As Int16 = DataGridView1.RowCount
      Dim CntRtos As Int16 = 0
      '
      btnAceptar.Enabled = Not Activo
      cboLetra.Enabled = Not Activo And Alta And Not Facturar
      tbSucursal.Enabled = Not Activo And Alta And Not Facturar
      tbNumero.Enabled = Not Activo And Alta And Not Facturar
      chkCasual.Enabled = Not Activo
      cboCliente.Enabled = Not Activo
      'tbCliente.Enabled = Not Activo
      'cmdAltaCliente.Enabled = Not Activo
      cboTipoIva.Enabled = Not Activo And (TipoIva = 0)
      tbCuit.Enabled = Not Activo And EmiteComp
      cboTipoComp.Enabled = Not Activo
      tbFecha.Enabled = Not Activo
      cboCondVenta.Enabled = False   'Not Activo
      tbFecVenc.Enabled = Not Activo And PagoDif
      'tbRemito.Enabled = Not Activo
      '
      tbBonificacion.Enabled = Activo And Not SoloVer
      tbGravado.Enabled = Activo And Not SoloVer
      tbNoGravado.Enabled = Activo And Not SoloVer
      tbIva1.Enabled = Activo And Not SoloVer
      tbIva2.Enabled = Activo And Not SoloVer
      tbExento.Enabled = Activo And Not SoloVer
      tbObserv.Enabled = Activo And Not SoloVer
      'cboVendedor.Enabled = Activo And Not SoloVer
      cboEntrega.Enabled = Activo And Not SoloVer
      cboTransporte.Enabled = (Activo And cboEntrega.SelectedIndex = 2) And Not SoloVer
      '
      cboFormaPago.Enabled = Activo And Not PagoDif
      tbEfectivo.Enabled = Activo And Not PagoDif And lEfectivo
      btnCheques.Enabled = Activo And Not PagoDif And lCheques
      tbTarjetaC.Enabled = Activo And Not PagoDif And lTarjetaC
      cboTarjetaC.Enabled = Activo And Not PagoDif And lTarjetaC
      tbTarjetaD.Enabled = Activo And Not PagoDif And lTarjetaD
      cboTarjetaD.Enabled = Activo And Not PagoDif And lTarjetaD
      tbDetCobro.Enabled = Activo And Not PagoDif
      '
      If Activo And Not PagoDif Then
         Me.TabControl1.TabPages(1).Show()
      Else
         Me.TabControl1.TabPages(1).Hide()
      End If
      '
      btnGuardar.Enabled = Activo And Not SoloVer
      btnGuardar2.Enabled = Activo And Not PagoDif And Not SoloVer
      btnSiguiente.Enabled = Activo And Not PagoDif
      btnAnterior.Enabled = Activo And Not PagoDif
      btnCancelar.Enabled = Activo And Not SoloVer
      btnCancelar2.Enabled = Activo And Not PagoDif And Not SoloVer
      '
      CntRtos = Val(CapturaDato(Cn, cTmpRto, "COUNT(1)", ""))
      '
      ' btnAlta.Enabled = Activo And (EgresoId = 0) And Aceptado And Not SoloVer And VentaProd
      btnAltaServ.Enabled = Activo And (EgresoId = 0) And Aceptado And Not SoloVer And VentaServ
      btnModif.Enabled = Activo And Aceptado And CntRg > 0 And Not SoloVer 'And (CntRtos <= 1 Or chkDet.Checked)
      btnBaja.Enabled = Activo And Aceptado And CntRg > 0 And EgresoId = 0 And Not SoloVer
      '
      'btnRefRemito.Enabled = Activo And Alta And Not SoloVer
      'chkDet.Enabled = Activo And Not SoloVer And CntRtos > 0
      'btnRefPedido.Enabled = Activo And Alta And Not SoloVer And CntRtos = 0
      '
   End Sub
   '
   Private Function ClaveSuperv() As Boolean
      'Dim Frm As New frmContraseña
      'With Frm
      '   .Titulo = "Cuenta Corriente bloqueada, ingrese Clave Supervisor"
      '   .Clave = "cfgKeyGts"
      '   .ShowDialog(Me)
      '   If .ClaveValida Then
      '      Return True
      '   Else
      '      Return False
      '   End If
      'End With
   End Function
   '
   Private Sub cboTipoComp_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoComp.SelectedIndexChanged
      With cboTipoComp
         If .SelectedIndex > 0 Then
            TipoComp = .SelectedValue
            Imput = CapturaDato(Cn, "TipoComp", "Imput", "TipoComp = " & TipoComp)
            'TCpteFiscal = CapturaDato(Cn, "TipoComp", "TcFiscal", "TipoComp = " & TipoComp) & ""
            If cfgNumNCSep Then
               Comprob = IIf(Imput = "H", "NotaCred", IIf(TipoComp = 1, "Factura", "NotaDeb"))
            Else
               Comprob = "Factura"
            End If
            CalcNumeros()
         Else
            TipoComp = 0
            TCpteFiscal = ""
         End If
      End With
   End Sub
   '
   Private Sub cboCliente_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCliente.SelectedIndexChanged
      '
      'Private Sub CboCliente_Leave(sender As Object, e As EventArgs) Handles cboCliente.Leave
      '
      Dim Cmd As New OleDb.OleDbCommand
      Dim Dr As OleDb.OleDbDataReader
      '
      If cboCliente.SelectedIndex = 0 Then
         Exit Sub
      End If
      '
      With Cmd
         '
         .Connection = Cn
         If optClientes.Checked Then
            If chkCasual.Checked Then
               Cliente = 0
               .CommandText = "SELECT * FROM Clientes WHERE Nombre = ''"
            Else
               Cliente = cboCliente.SelectedValue
               .CommandText = "SELECT * FROM Clientes WHERE Codigo = " & Cliente
            End If
            Inquilino = 0
            Propietario = 0
         ElseIf optInquilinos.Checked Then
            Cliente = 0
            Inquilino = cboCliente.SelectedValue
            Propietario = 0
            .CommandText = "SELECT * FROM Inquilinos WHERE Codigo = " & Inquilino
         ElseIf optPropietarios.Checked Then
            Cliente = 0
            Inquilino = 0
            Propietario = cboCliente.SelectedValue
            .CommandText = "SELECT * FROM Propietarios WHERE Codigo = " & Propietario
         End If
         '
         Dr = .ExecuteReader
         '
         With Dr
            If Not .HasRows Then
               If Alta Then
                  tbCuit.Clear()    ' = "  -        - "
                  cboTipoIva.SelectedIndex = -1
                  cboTipoIva.Enabled = True
                  LimCredito = 0
               End If
            Else
               .Read()
               If Not chkCasual.Checked Then
                  'Cliente = .Item("Cliente")
                  'Dias = Val(.Item("Dias") & "")
                  'If .Item("TipoMargen") = "A" Or IsDBNull(.Item("Margen")) Then
                  '   Margen = 0
                  'Else
                  '   Margen = .Item("Margen")
                  'End If
                  'If IsDBNull(.Item("LimCredito")) Then
                  '   LimCredito = 0
                  'Else
                  '   LimCredito = .Item("LimCredito")
                  'End If
                  'BloqueoVta = .Item("BloqueoVta")
                  'BonifExtra = .Item("BonifExtra") & ""
                  'If Val(.Item("Vendedor") & "") = 0 Then
                  '   With cboVendedor
                  '      If .Items.Count = 2 Then
                  '         .SelectedIndex = 1
                  '      Else
                  '         .SelectedIndex = 0
                  '      End If
                  '   End With
                  'Else
                  '   PosCboItem(cboVendedor, .Item("Vendedor"))
                  'End If
                  DomFiscal = !Domicilio & ""
                  LocFiscal = !Localidad & ""
               Else
                  Cliente = 0
                  Margen = 0
                  Dias = 0
                  'cboVendedor.SelectedIndex = -1
                  BonifExtra = ""
                  DomFiscal = "-"
                  LocFiscal = CapturaDato(Cn, "Parametros", "LocEmp", "Sucursal = " & prmSucursal)
               End If
               '
               If IsDBNull(.Item("Cuit")) Then
                  tbCuit.Clear()    ' = MaskCuit
               Else
                  If Len(.Item("Cuit")) = 13 Then
                     tbCuit.Text = .Item("Cuit")
                  End If
               End If
               '
               TipoIva = CapturaDato(Cn, "TipoIva", "TipoIva", "Codigo = '" & .Item("TipoIva") & "'")
               PosicionarComboItem(cboTipoIva, TipoIva)
               cboTipoIva.Enabled = (TipoIva = 0) Or (chkCasual.Checked)
               '
               'If Not chkCasual.Checked Then
               '   CondVenta = .Item("CondVenta")
               'Else
               '   CondVenta = CapturaDato(Cn, "CondVenta", "CondVenta", "PagoDif = 0")
               'End If
               PosicionarComboItem(cboCondVenta, 1)   'CondVenta)
               '
               tbFecha_Change()
               '
               If SisContable Then
                  cCtaCli = cfgCtaCliVar
                  If Not chkCasual.Checked Then
                     If cfgUniCtaCliVar = False Then
                        cCtaCli = .Item("CtaCont") & ""
                     End If
                  End If
               End If
               '
            End If
            .Close()
         End With
      End With
      '
      'If Cliente = 0 Then
      '   tbCliente.Text = ""
      'Else
      '   tbCliente.Text = Cliente
      'End If
      '
   End Sub
   '
   Private Sub cboCliente_Validating(sender As Object, e As CancelEventArgs) Handles cboCliente.Validating
      'Dim SdoAct As Double = 0
      'If PagoDif Then
      '   If LimCredito <> 0 Then
      '      SdoAct = CaptDeudaCliente(Cliente)
      '      If LimCredito < SdoAct Then
      '         If MsgBox(Traducir("LimCredSup") & " (Sdo.Actual $ " & SdoAct & ")" & vbCrLf &
      '                      "Ver Cuenta Corriente ?", vbInformation + vbYesNo) = vbYes Then
      '            With frmCtasCtes
      '               .Clientes = True
      '               .CliPro = Cliente
      '               .ShowDialog()
      '            End With
      '         End If
      '         tbCliente.Text = ""
      '         e.Cancel = True
      '      End If
      '   End If
      'End If
   End Sub
   '
   Private Sub tbFecha_Change()
      If Format(tbFecha.Value, "yyyyMM") <= cfgPerCierreIVA Then
         MensajeTrad("PerIvaCerrado")
         tbFecha.Value = Today
      End If
      With tbFecVenc
         If .Value < tbFecha.Value Then
            .Value = tbFecha.Value
         End If
         .MinDate = tbFecha.Value
      End With
      If Dias = 0 Then
         tbFecVenc.Value = tbFecha.Value
      Else
         tbFecVenc.Value = tbFecha.Value.AddDays(Dias)
      End If
   End Sub
   '
   Private Sub TbCliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
      'Cliente = Val(tbCliente.Text)
      cboCliente.Text = CapturaDato(Cn, "Clientes", "Nombre", "Cliente=" & Cliente)
   End Sub
   '
   Private Sub btnAlta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      AltaMod(True, False)
   End Sub
   '
   Private Sub btnAltaServ_Click(sender As Object, e As EventArgs) Handles btnAltaServ.Click
      AltaMod(True, True)
   End Sub
   '
   Private Sub AltaMod(ByVal Alta As Boolean, VentaServ As Boolean)
      '
      Dim Renglon As Integer
      Dim CantReng As Integer
      Dim Precio As Double
      Dim AlicIva As Single
      '
      formAct = Me
      '
      If Alta Then
         Renglon = CapturaDato(Cn, cTmp, "ISNULL(MAX(Renglon),0)", "") + 1
      Else
         If DataGridView1.RowCount = 0 Then
            Exit Sub
         End If
         With DataGridView1
            Renglon = .SelectedCells(.Columns("Renglon").Index).Value
            AlicIva = Val(.SelectedCells(.Columns("AlicuoIva").Index).Value & "")
         End With
      End If
      '
      If Facturar Then
         CantReng = CapturaDato(Cn, cTmp, "COUNT(1)", "")
         If Alta And cfgMaxRengFact > 0 And CantReng >= cfgMaxRengFact Then
            MensajeTrad("NoAddReng")
            Exit Sub
         End If
      End If
      '
      If VentaServ Then
         Dim Frm As New frmVentasAMDet
         With Frm
            .Tabla = cTmp
            .Alta = Alta
            If Alta Then
               .Concepto = 0
            Else
               .Concepto = DataGridView1.SelectedCells(3).Value
               .AlicIva = AlicIva
            End If
            .Letra = Letra
            .Renglon = Renglon
            .ShowDialog(Me)
         End With
      Else
         If Not Alta Then
            'If Letra = "B" Then
            '   Precio = Val(DataGridView1.SelectedCells(9).Value & "") / (1 + (AlicIva1 + AlicIva2) / 100)
            'Else
            Precio = Val(DataGridView1.SelectedCells(9).Value & "")
            'End If
         End If
         Dim Frm As New FrmVentasAMProd
         With Frm
            .EmpresaId = EmpresaId
            .TablaAct = cTmp
            .Cliente = Cliente
            .Alta = Alta
            .Imput = Imput
            If Alta Then
               .Proveedor = 0
               .Producto = 0
               .Partida = 0
               .Cantidad = 0
               .Precio = 0
               .Bonificacion = ""
            Else
               .Proveedor = DataGridView1.SelectedCells(1).Value
               .Producto = DataGridView1.SelectedCells(2).Value
               .Partida = DataGridView1.SelectedCells(5).Value & ""
               .Cantidad = DataGridView1.SelectedCells(7).Value
               .Precio = Precio
               .Bonificacion = DataGridView1.SelectedCells(10).Value
            End If
            .BonifExtra = BonifExtra
            .Renglon = Renglon
            .NoModCant = (EgresoId <> 0 Or RemitoId <> 0)
            .Margen = Margen
            .Letra = Letra
            .MantenerAbierto = Alta
            .Facturar = Facturar
            .CompraRtoId = CompraRtoId
            .ShowDialog(Me)
         End With
      End If
      '
      ActData()
      '
   End Sub
   '
   Private Sub btnModif_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModif.Click
      With DataGridView1
         If .RowCount > 0 Then
            VentaServ = (.SelectedCells(.Columns("Producto").Index).Value = 0)
         End If
      End With
      AltaMod(False, VentaServ)
   End Sub
   '
   Private Sub btnBaja_Click(sender As Object, e As EventArgs) Handles btnBaja.Click
      Dim Renglon As Int16
      Dim Detalle As String
      With DataGridView1
         If .RowCount > 0 Then
            Renglon = .SelectedCells(.Columns("Renglon").Index).Value
            Detalle = .SelectedCells(.Columns("Detalle").Index).Value
            If DaDeBaja("Renglón: " & Renglon & " (" & Detalle & ")") Then
               Trn = Cn.BeginTransaction
               With Cmd
                  .Transaction = Trn
                  .CommandText = "DELETE FROM " & cTmp & " WHERE Renglon = " & Renglon
                  .ExecuteNonQuery()
               End With
               Trn.Commit()
               ActData()
            End If
         End If
      End With
   End Sub
   '
   Private Sub btnSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSiguiente.Click
      TabControl1.SelectedIndex = 1
      With cboFormaPago
         If .Enabled Then .Focus()
      End With
   End Sub
   '
   Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click, btnGuardar2.Click
      '
      'Dim ImprRemito As Boolean
      '
      If Validar2() Then
         'If chkCasual.Checked Then
         '   If AltaAuto("ClientesCas", "", 0, "Nombre", cboCliente.Text, TipoIva, tbCuit.Text, False) Then
         '      cboCliente.Items.Add(cboCliente.Text)
         '   End If
         'End If
         '
         If Guardar() Then
            '
            If Facturar Then
               If Not regCtrlFiscal Then
                  '
                  GenRepFact(VentaID, "FACTURACION", cfgDestinoCmp)
                  '
                  'If Val(tbRemito.Text) = 0 Then
                  '   If Not VentaServ Then
                  '      If cfgImprRtoFact = "S" Then
                  '         ImprRemito = True
                  '      ElseIf cfgImprRtoFact = "P" Then
                  '         ImprRemito = MsgConfirma("Imprime Remito")
                  '      End If
                  '      If ImprRemito Then
                  '         ImprimirRemito(RemitoId)   '*** VER ***, cfgDestinoCmp)
                  '      End If
                  '   End If
                  'End If
               End If
            End If
            '
            If Alta Then
               Cancelar()
               Me.cboLetra_SelectedIndexChanged(sender, e)
            Else
               Me.Close()
            End If
         End If
      End If
      '
   End Sub
   '
   Private Function Validar2() As Boolean
      '
      If Val(tbSubtotal.Text) = 0 Then
         MensajeTrad("SubTotal=0", , False)
         Exit Function
      End If
      '
      If Format(Val(tbTotal.Text) - Val(tbIva1.Text) - Val(tbIva2.Text), "Fixed") <> Format(tbSubtotal.Text * (1 - Val(tbBonificacion.Text) / 100), "Fixed") Then
         MensajeTrad("ImportIncorr", , False)
         tbTotal.Focus()
         Exit Function
      End If
      '
      If Format(Val(tbGravado.Text) + Val(tbNoGravado.Text) +
                Val(tbExento.Text), cfgFormatoPr) <> Format(tbSubtotal.Text * (1 - Val(tbBonificacion.Text) / 100), cfgFormatoPr) Then
         MensajeTrad("ImportIncorr", , False)
         tbGravado.Focus()
         Exit Function
      End If
      '
      'If Vendedor = 0 Then
      '   MensajeTrad("DIVendedor", , False)
      '   cboVendedor.Focus()
      '   Exit Function
      'End If
      '
      If Not PagoDif Then
         If FormaPago = 0 Then
            MensajeTrad("DIFormaPago", , False)
            TabControl1.SelectedIndex = 1
            cboFormaPago.Focus()
            Exit Function
         End If
         '
         If Val(tbTotal2.Text) <> (Val(tbEfectivo.Text) + Val(tbCheques.Text) + Val(tbTarjetaC.Text) + Val(tbTarjetaD.Text)) Then
            MensajeTrad("ImpCobro<>Tot", , False)
            Exit Function
         End If
      End If
      '
      Validar2 = True
      '
   End Function
   '
   Private Function Guardar() As Boolean
      '
      Dim cCuenta As String
      Dim ImpRen As Double
      Dim ImpIntTot As Double
      Dim Comprob As String
      '
      Dim CodAsi As String
      Dim NroAsi As Long
      Dim RenASi As Integer
      Dim DetAsi As String
      Dim n As Int16
      '
      Dim Cmd As New OleDb.OleDbCommand
      Dim Drd As OleDb.OleDbDataReader
      '
      Trn = Cn.BeginTransaction
      '
      Try
         '
         Comprob = CapturaDato(Cn, "TipoComp", "DescAbrev", "Codigo = " & TipoComp,,,, Trn)
         '
         Cmd.Connection = Cn
         Cmd.Transaction = Trn
         '
         If Alta Then
            VentaID = 0
            If Facturar Then
               CalcNumeros(Trn)
            End If
         End If
         '
         If VentaServ Then
            EgresoId = 0
         End If
         '
         'If VentaProd Then
         '   If EgresoId = 0 Then
         '      EgresoId = GuardarEgreso(EmpresaId, tbSucursal.Text, prmDepart, "V", tbFecha.Text, Cliente, SucursalDes, DepartDes, tbObserv.Text, SubTotal, False, cTmp, False, True, , IIf(Entrega = 0, True, False), , , , , Trn)
         '   End If
         '   If Not Alta Then
         '      cmd.CommandText = "UPDATE EgresosDet SET " &
         '                        " Saldo = Saldo + (SELECT Cantidad FROM VentasDet " &
         '                        "                  WHERE Producto = VentasDet.Producto " &
         '                        "                    AND FactRenglon = EgresosDet.EgrRenglon " &
         '                        "                    AND VentaID = " & VentaID & ") " &
         '                        "WHERE EgresosDet.EgresoID = " & EgresoId
         '      cmd.ExecuteNonQuery()
         '   End If
         '   cmd.CommandText = "UPDATE EgresosDet SET " &
         '                     " Saldo = Saldo - (SELECT Cantidad FROM " & cTmp & " " &
         '                     "                  WHERE Producto = EgresosDet.Producto " &
         '                     "                    AND Renglon = EgresosDet.EgrRenglon) " &
         '                     "WHERE EgresosDet.EgresoID = " & EgresoId
         '   cmd.ExecuteNonQuery()
         '   If RemitoId <> 0 Then
         '      Cmd.CommandText = "UPDATE RemitosDet SET " &
         '                        " RtdSaldo = RtdSaldo - (SELECT Cantidad FROM " & cTmp & " " &
         '                        "                        WHERE Producto = RemitosDet.Producto " &
         '                        "                          AND Renglon = RemitosDet.RtdRenglon) " &
         '                        "WHERE RemitoID = " & RemitoId & " AND Producto <> 0"
         '      Cmd.ExecuteNonQuery()
         '   End If
         'End If
         '
         With Cmd
            If Alta Then
               AltaFactura(Letra, tbSucursal.Text, tbNumero.Text, Comprob, tbFecha.Value, Inquilino, Propietario, cboCliente.Text, cTipoIva, tbCuit.Text, tbGravado.Text, tbNoGravado.Text, tbExento.Text, tbIva1.Text, tbIva2.Text, tbTotal.Text, tbObserv.Text, 0, 0, Trn)
               VentaID = CapturaDato(Cn, "Ventas", "MAX(VentaID)", "", , , , Trn)
            Else
               '.CommandText = "UPDATE Ventas SET " &
               '               " EmpresaId = " & EmpresaId & ", " &
               '               " TipoComp = " & TipoComp & ", " &
               '               " FactLetra = '" & Letra & "', " &
               '               " Sucursal = " & Val(tbSucursal.Text) & ", " &
               '               " FactNumero = " & Val(tbNumero.Text) & ", " &
               '               " Cliente = " & IIf(chkCasual.Checked, 0, Cliente) & ", " &
               '               " Fecha = '" & Format(tbFecha.Value, FormatFecha) & "', " &
               '               " Nombre = '" & cboCliente.Text & "', " &
               '               " TipoIva = " & TipoIva & ", " &
               '               " Cuit = '" & tbCuit.Text & "', " &
               '               " SubTotal = " & SubTotal & ", " &
               '               " Bonificacion = " & Val(tbBonificacion.Text) & ", " &
               '               " Gravado = " & Val(tbGravado.Text) * IIf(Imput = "D", 1, -1) & ", " &
               '               " NoGravado = " & Val(tbNoGravado.Text) * IIf(Imput = "D", 1, -1) & ", " &
               '               " Exento = " & Val(tbExento.Text) * IIf(Imput = "D", 1, -1) & ", " &
               '               " Iva1 = " & Val(tbIva1.Text) * IIf(Imput = "D", 1, -1) & ", " &
               '               " Iva2 = " & Val(tbIva2.Text) * IIf(Imput = "D", 1, -1) & ", " &
               '               " Total = " & Val(tbTotal.Text) * IIf(Imput = "D", 1, -1) & ", " &
               '               " Detalle = '" & tbObserv.Text & "', " &
               '               " Estado = " & IIf(PagoDif, 0, 3) & ", " &
               '               " Vendedor = " & Vendedor & ", " &
               '               " VentaServ = " & IIf(VentaServ, 1, 0) & ", " &
               '               " EgresoId = " & EgresoId & ", " &
               '               " RemitoId = " & RemitoId & ", " &
               '               " CondVenta = " & CondVenta & ", " &
               '               " FechaVenc = '" & Format(tbFecVenc.Value, FormatFecha) & "', " &
               '               " FormaPago = " & FormaPago & ", " &
               '               " Facturado = " & IIf(Facturar, 1, 0) & ", " &
               '               " TransporteID = " & TransporteID & ", " &
               '               " Remito = '" & tbRemito.Text & "', " &
               '               " Entrega = " & Entrega & ", " &
               '               " CompraRtoId = " & IIf(CompraRtoId = 0, "NULL", CompraRtoId) & ", " &
               '               " Usuario = '" & Uid & "', " &
               '               " FechaMod = '" & Format(Now, FormatFechaHora) & "' " &
               '               "WHERE VentaId = " & VentaID
               '.ExecuteNonQuery()
            End If
            '
            'If PagoDif Then
            '   If IsNothing(CapturaDato(Cn, "CtaCteCli", "VentaId", "VentaID = " & VentaID, , , , Trn)) Then
            '      .CommandText = "INSERT INTO CtaCteCli( EmpresaId, Sucursal, Departamento, TipoComp, Cliente, CliLetra, CliNumero, Fecha, FechaVenc, Debe, Haber, Saldo, VentaID, Usuario, FechaMod) " &
            '                     "VALUES(" & EmpresaId & ", " &
            '                                 Val(tbSucursal.Text) & ", " &
            '                                 prmDepart & ", " &
            '                                 TipoComp & ", " &
            '                                 Cliente & ", " &
            '                           "'" & Letra & "', " &
            '                                 Val(tbNumero.Text) & ", " &
            '                           "'" & Format(tbFecha.Value, FormatFecha) & "', " &
            '                           "'" & Format(tbFecVenc.Value, FormatFecha) & "', " &
            '                                 IIf(Imput = "D", Val(tbTotal.Text), 0) & ", " &
            '                                 IIf(Imput = "H", Val(tbTotal.Text), 0) & ", " &
            '                                 Val(tbTotal.Text) * IIf(Imput = "D", 1, -1) & ", " &
            '                                 VentaID & ", " &
            '                           "'" & Uid & "', " &
            '                           "'" & Format(Now, FormatFechaHora) & "')"
            '   Else
            '      .CommandText = "UPDATE CtaCteCli SET " &
            '                     " EmpresaId = " & EmpresaId & ", " &
            '                     " Sucursal = " & Val(tbSucursal.Text) & ", " &
            '                     " Departamento = " & prmDepart & ", " &
            '                     " TipoComp = " & TipoComp & ", " &
            '                     " Cliente = " & Cliente & ", " &
            '                     " CliLetra = '" & cboLetra.Text & "', " &
            '                     " CliNumero = " & Val(tbNumero.Text) & ", " &
            '                     " Fecha = '" & Format(tbFecha.Value, FormatFecha) & "', " &
            '                     " FechaVenc = '" & Format(tbFecVenc.Value, FormatFecha) & "', " &
            '                     " Debe = " & IIf(Imput = "D", Val(tbTotal.Text), 0) & ", " &
            '                     " Haber = " & IIf(Imput = "H", Val(tbTotal.Text), 0) & ", " &
            '                     " Saldo = " & Val(tbTotal.Text) * IIf(Imput = "D", 1, -1) & ", " &
            '                     " VentaID = " & VentaID & ", " &
            '                     " Usuario = '" & Uid & "', " &
            '                     " FechaMod = '" & Format(Now, FormatFechaHora) & "' " &
            '                     "WHERE VentaId = " & VentaID
            '   End If
            'Else
            '   .CommandText = "DELETE FROM CtaCteCli WHERE VentaID = " & VentaID
            'End If
            '.ExecuteNonQuery()
            '
            '.CommandText = "DELETE FROM VentasDet WHERE VentaID = " & VentaID
            '.ExecuteNonQuery()
            '
            '.CommandText = "INSERT INTO " & cTmpCmp & "( VentaID, ImpPago) VALUES( " & VentaID & ", " & Val(tbTotal.Text) * IIf(Imput = "D", 1, -1) & ")"
            '.ExecuteNonQuery()
            ''
            'If PresupID <> 0 Then
            '   .CommandText = "UPDATE Presupuestos SET " &
            '                  " VentaID = " & VentaID & ", " &
            '                  " Estado = 7, " &
            '                  " Usuario = '" & Uid & "', " &
            '                  " FechaMod = '" & Format(Now, FormatFechaHora) & "' " &
            '                  "WHERE PresupID = " & PresupID
            '   .ExecuteNonQuery()
            'End If
            ''
            'If PedidoId <> 0 Then
            '   .CommandText = "UPDATE Pedidos SET " &
            '                  " VentaID = " & VentaID & ", " &
            '                  " Estado = 7, " &
            '                  " Usuario = '" & Uid & "', " &
            '                  " FechaMod = '" & Format(Now, FormatFechaHora) & "' " &
            '                  "WHERE PedidoID = " & PedidoId
            '   .ExecuteNonQuery()
            'End If
            ''
            'If RemitoId <> 0 Then
            '   .CommandText = "UPDATE Remitos SET " &
            '                  " Estado = 7, " &
            '                  " RtoUsuMod = '" & Uid & "', " &
            '                  " RtoFecMod = '" & Format(Now, FormatFechaHora) & "' " &
            '                  "WHERE RemitoID IN( SELECT RemitoId FROM " & cTmpRto & ")"
            '   .ExecuteNonQuery()
            '   '
            '   .CommandText = "DELETE FROM VentasRtos WHERE VentaID = " & VentaID
            '   .ExecuteNonQuery()
            '   .CommandText = "INSERT INTO VentasRtos( VentaID, RemitoId, VrUsuario, VrFechaMod ) " &
            '                  "SELECT " & VentaID & ", RemitoId, '" & Uid & "', '" & Format(Now, FormatFechaHora) & "' FROM " & cTmpRto
            '   .ExecuteNonQuery()
            '   '
            'End If
            '
         End With
         '
         CodAsi = cmpINT & "-" & VentaID
         DetAsi = cboCliente.Text
         '
         If SisContable Then
            NroAsi = GuardaAsiento(CodAsi, tbFecha.Text, DetAsi)
            If NroAsi = 0 Then
               Err.Raise(1001, , "NoUpAsiento")
            End If
            '
            If Not BorraAsienDet(NroAsi) Then
               Err.Raise(1001, , "NoDelAsiDet")
            End If
            '
            RenASi = 1
            If Not GuardaAsienDet(NroAsi, RenASi, cCtaCli, DetAsi, tbTotal.Text, 0) Then
               Err.Raise(1001, , "NoUpDetAsi")
            End If
         End If
         '
         With Cmd
            '
            .CommandText = "SELECT COUNT(1) FROM " & cTmp
            n = .ExecuteScalar
            '
            .CommandText = "SELECT * FROM " & cTmp
            Drd = Cmd.ExecuteReader
            '
         End With
         '
         Dim Producto(n) As Int32
         Dim Concepto(n) As String   ' Int32
         Dim Detalle(n) As String
         Dim Cantidad(n) As Double
         Dim Costo(n) As Double
         Dim Precio(n) As Double
         Dim Bonificacion(n) As Single   ' String
         Dim ImpInt(n) As Double
         Dim SubTot(n) As Double
         Dim Renglon(n) As Byte
         Dim AlicuoIva(n) As String
         Dim cRemitoId(n) As String
         '
         i = 0
         '
         With Drd
            While .Read()
               Producto(i) = .Item("Producto")
               Concepto(i) = CapturaDato(Cn, "Conceptos", "Codigo", "ConceptoId = " & .Item("Concepto"),,,, Trn)
               Detalle(i) = .Item("Detalle")
               Cantidad(i) = .Item("Cantidad")
               Costo(i) = .Item("Costo")
               Precio(i) = .Item("Precio")
               Bonificacion(i) = Val(.Item("Bonificacion") & "")
               ImpInt(i) = Val(.Item("ImpInt") & "")
               SubTot(i) = .Item("SubTotal")
               Renglon(i) = .Item("Renglon")
               If IsDBNull(.Item("AlicuoIva")) Then
                  AlicuoIva(i) = "NULL"
               Else
                  AlicuoIva(i) = .Item("AlicuoIva")
               End If
               If IsDBNull(.Item("RemitoId")) Then
                  cRemitoId(i) = "NULL"
               Else
                  cRemitoId(i) = .Item("RemitoId")
               End If
               i = i + 1
            End While
            .Close()
         End With
         'End With
         ''
         'With Dr
         'While .Read()
         With Cmd
            For i = 0 To n - 1
            '
            AltaRenFact(Letra, tbSucursal.Text, tbNumero.Text, i + 1, Concepto(i), Detalle(i), Cantidad(i), Precio(i), Bonificacion(i), Trn)
            '
            If SisContable Then
                  If VentaServ Then
                     cCuenta = CapturaDato(Cn, "Conceptos", "CtaCont", "Concepto = " & Concepto(i), , , , Trn)
                     If cCuenta = "" Then
                        Err.Raise(1001, , Traducir("CtaServNoAsig", , Trn))
                     End If
                  Else
                     cCuenta = cfgCtaMerc
                  End If
                  '
                  ImpRen = SubTot(i) - ImpInt(i)
                  'If Letra = "B" Then
                  '   ImpRen = ImpRen / (1 + (AlicIva1 + AlicIva2) / 100)
                  'End If
                  '
                  RenASi = RenASi + 1
                  If Not GuardaAsienDet(NroAsi, RenASi, cCuenta, DetAsi, 0, ImpRen, Trn) Then
                     Err.Raise(1001, , "NoUpDetAsi")
                  End If
               End If
               '
               ImpIntTot = ImpIntTot + ImpInt(i)
               '
            Next i
            '
            '.Close()
            '
         End With
         '
         If SisContable Then
            If Val(tbIva1) > 0 Then
               RenASi = RenASi + 1
               If Not GuardaAsienDet(NroAsi, RenASi, cfgCtaIvaDF1, DetAsi, 0, Val(tbIva1), Trn) Then
                  Err.Raise(1001, , "NoUpDetAsi")
               End If
            End If
            If Val(tbIva2) > 0 Then
               RenASi = RenASi + 1
               If Not GuardaAsienDet(NroAsi, RenASi, cfgCtaIvaDF2, DetAsi, 0, Val(tbIva2), Trn) Then
                  Err.Raise(1001, , "NoUpDetAsi")
               End If
            End If
            If ImpIntTot > 0 Then
               RenASi = RenASi + 1
               If Not GuardaAsienDet(NroAsi, RenASi, cfgCtaImpInt, DetAsi, 0, ImpIntTot, Trn) Then
                  Err.Raise(1001, , "NoUpDetAsi")
               End If
            End If
         End If
         '
         'If Not PagoDif Then
         '   If Not GuardarCobro(EmpresaId, CobroID, IIf(cfgSoloReciboX, "X", cboLetra.Text), Val(tbSucursal.Text), 0, 0, tbFecha.Value, Cliente, tbTotal.Text * IIf(Imput = "D", 1, -1), Val(tbEfectivo.Text) * IIf(Imput = "D", 1, -1), Val(tbCheques.Text) * IIf(Imput = "D", 1, -1), Val(tbTarjetaC.Text) * IIf(Imput = "D", 1, -1), TarjetaC, Val(tbNroTarjC.Text), Val(tbTarjetaD.Text) * IIf(Imput = "D", 1, -1), TarjetaD, Val(tbNroTarjD.Text), tbDetCobro.Text, regNroCaja, cCtaCaja, Moneda, cTmpCmp, cTmpCh, False, True, cboCliente.Text, , , , , , , Trn) Then
         '      Err.Raise(1001, , "NoGenCobro")
         '   End If
         'End If
         '
         'Cmd.CommandText = "UPDATE Sucursales SET " & Comprob & Letra & " = " & tbNumero.Text & " " &
         '                  "WHERE EmpresaId = " & EmpresaId &
         '                  "  AND Sucursal = " & tbSucursal.Text &
         '                  "  AND " & Comprob & Letra & " < " & tbNumero.Text
         Cmd.ExecuteNonQuery()
         '
         If Letra = "A" Then
            If Val(CapturaDato(Cn, "Config", "Valor", "Clave = 'cfgNroFactA'",,,, Trn)) < Val(tbNumero.Text) Then
               GuardarCfg(cfgNroFactA, "cfgNroFactA", tbNumero.Text, Trn)
            End If
         Else
            If Val(CapturaDato(Cn, "Config", "Valor", "Clave = 'cfgNroFactB'",,,, Trn)) < Val(tbNumero.Text) Then
               GuardarCfg(cfgNroFactB, "cfgNroFactB", tbNumero.Text, Trn)
            End If
         End If
            '
            'If Facturar Then
            '   If regCtrlFiscal Then
            '      If Not EmitirCpteFiscal(tbCuit.Text, cboCliente.Text, VentaServ, TIvaFiscal, TCpteFiscal, Letra, PagoDif, tbObserv.Text, tbRemito.Text, DomFiscal, LocFiscal, cTmp, SubTotal, tbBonificacion.Text, Val(tbEfectivo.Text), Val(tbCheques.Text), Val(tbTarjetaC.Text), Val(tbTarjetaD.Text), Val(tbTotal.Text), Trn) Then
            '         Err.Raise(1001, , "No se pudo emitir Comprobante Fiscal")
            '      End If
            '   Else
            '      If regHabFactEl Then
            '         If Not GuardarAfip(VentaID, Trn) Then
            '            Err.Raise(1001, , "No se pudo guardar FE-AFIP")
            '         End If
            '      End If
            '   End If
            'End If
            '
            GuardarAudit(IIf(Alta, "Alta", "Modificación") & " de Venta" & IIf(Facturar, " (Facturación)", ""), Comprob & " " & cboLetra.Text & "-" & Val(tbSucursal.Text) & "-" & Val(tbNumero.Text) & "-" & cboCliente.Text, "Ventas", "Guardar", Trn)
         '
         Trn.Commit()
         '
         If Not Alta Then
            frmVentas.ActData()
         End If
         '
         Return True
         '
      Catch e As Exception
         '
         Trn.Rollback()
         '
         Dim st As New StackTrace(True)
         RegistrarError(st, Me.Name, , e.Message)
         '
         Return False
         '
      End Try
      '
   End Function
   '
   Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click, btnCancelar2.Click
      Cancelar()
   End Sub
   '
   Private Sub Cancelar()
      If Alta Then
         Aceptado = False
         LimpiaTemp()
         ActData()
         CalcImportes()
         ActivaCtrl(False)
         VentaID = 0
         CobroID = 0
         EgresoId = 0
         PresupID = 0
         RemitoId = 0
         PedidoId = 0
         'tbRemito.Text = ""
         TabControl1.SelectedIndex = 0
         tbObserv.Text = ""
         tbDetCobro.Text = ""
         tbEfectivo.Text = ""
         tbCheques.Text = ""
         tbTarjetaC.Text = ""
         tbTarjetaD.Text = ""
         cboCliente.Focus()
         PosTipoComp()
         'tbPedido.Text = ""
      Else
         Me.Close()
      End If
   End Sub

   Private Sub optClientes_CheckedChanged(sender As Object, e As EventArgs) Handles optClientes.CheckedChanged, optInquilinos.CheckedChanged, optPropietarios.CheckedChanged
      chkCasual.Enabled = optClientes.Checked
      ArmaCboCliente()
   End Sub
   '
   'Private Sub cboVendedor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
   '   With cboVendedor
   '      If .SelectedIndex > 0 Then
   '         Vendedor = .SelectedValue
   '      Else
   '         Vendedor = 0
   '      End If
   '   End With
   'End Sub

   Private Sub ChkDet_CheckedChanged(sender As Object, e As EventArgs)
      ActData()
   End Sub
   '
   Private Sub cboCondVenta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCondVenta.SelectedIndexChanged
      With cboCondVenta
         If .SelectedIndex > 0 Then
            CondVenta = .SelectedIndex
         Else
            CondVenta = 0
         End If
      End With
      If CondVenta > 0 Then
         PagoDif = CondVenta = 2  ' CapturaDato(Cn, "CondVenta", "PagoDif", "CondVenta = " & CondVenta)
         tbFecVenc.Enabled = PagoDif
         btnSiguiente.Enabled = Not PagoDif
         cboCondVenta.Enabled = False   ' PagoDif
      End If
   End Sub

   Private Sub cboFormaPago_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFormaPago.SelectedIndexChanged
      With cboFormaPago
         If .SelectedIndex > 0 Then
            FormaPago = .SelectedValue
         Else
            FormaPago = 0
         End If
      End With
      With Cmd
         .Connection = Cn
         .CommandText = "SELECT * FROM FormasPagos WHERE FormaPago = " & FormaPago
         Drd = .ExecuteReader
      End With
      With Drd
         If .Read() Then
            lEfectivo = .Item("Efectivo")
            lCheques = .Item("Cheques")
            lTarjetaC = .Item("TarjetaC")
            lTarjetaD = .Item("TarjetaD")
         Else
            lEfectivo = False
            lCheques = False
            lTarjetaC = False
            lTarjetaD = False
         End If
         .Close()
      End With
      '
      tbEfectivo.Text = ""
      tbTarjetaC.Text = ""
      tbTarjetaD.Text = ""
      '
      If lEfectivo Then
         If Not lCheques And Not lTarjetaC And Not lTarjetaD Then
            tbEfectivo.Text = tbTotal.Text
         End If
      ElseIf lTarjetaC Then
         If Not lEfectivo And Not lCheques And Not lTarjetaD Then
            tbTarjetaC.Text = tbTotal.Text
         End If
      ElseIf lTarjetaD Then
         If Not lEfectivo And Not lCheques And Not lTarjetaC Then
            tbTarjetaD.Text = tbTotal.Text
         End If
      End If
      '
      ActivaCtrl(Not btnAceptar.Enabled)
      '
   End Sub
   '
   Private Sub LimpiaTemp()
      Trn = Cn.BeginTransaction
      With Cmd
         .Transaction = Trn
         .CommandText = "DELETE FROM " & cTmp
         .ExecuteNonQuery()
         .CommandText = "DELETE FROM " & cTmpCh
         .ExecuteNonQuery()
         .CommandText = "DELETE FROM " & cTmpCmp
         .ExecuteNonQuery()
         .CommandText = "DELETE FROM " & cTmpRto
         .ExecuteNonQuery()
      End With
      Trn.Commit()
      ActData()
   End Sub
   '
   Private Sub BtnCheques_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheques.Click
      'With frmCobrosAmCh
      '   .TablaTmp = cTmpCh
      '   .Show(Me)
      '   tbCheques.Text = .Total
      'End With
   End Sub
   '
   Private Sub BtnAnterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnterior.Click
      Me.TabControl1.SelectedIndex = 0
   End Sub
   '
   Private Sub BtnRefRemito_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      'Dim Frm As New FrmVentasRefRto
      'With Frm
      '   .EmpresaId = EmpresaId
      '   .TablaAct = cTmp
      '   .TablaRto = cTmpRto
      '   .Cliente = Cliente
      '   .Devolucion = (Imput = "H")
      '   .Letra = cboLetra.Text
      '   .ShowDialog(Me)
      '   If .RemitoId <> 0 Then
      '      RemitoId = .RemitoId
      '      tbRemito.Text = CapturaDato(cn, "Remitos", "RtoNumero", "RemitoId = " & RemitoId)
      '      EgresoId = CapturaDato(cn, "Remitos", "EgresoId", "RemitoId = " & RemitoId)
      '      ActData()
      '      ActivaCtrl(True)
      '   End If
      'End With
   End Sub
   '
   Private Sub BtnRefPedido_Click(sender As Object, e As EventArgs)
      'Dim Frm As New frmVentasRefPedido
      'With Frm
      '   .TablaAct = cTmp
      '   .Cliente = Cliente
      '   .Letra = Letra
      '   .ShowDialog(Me)
      '   If .PedidoId <> 0 Then
      '      PedidoId = .PedidoId
      '      tbPedido.Text = CapturaDato(cn, "Pedidos", "PedidoNro", "PedidoId = " & PedidoId)
      '      PosCboItem(cboVendedor, Val(CapturaDato(cn, "Pedidos", "Vendedor", "PedidoId = " & PedidoId) & ""))
      '      ActData()
      '   End If
      'End With
   End Sub
   '
   'Private Sub CboEmpresa_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
   '   If FormLoad Then
   '      With cboEmpresa
   '         If .SelectedIndex <= 0 Then
   '            EmpresaId = 0
   '         Else
   '            EmpresaId = .SelectedValue
   '         End If
   '      End With
   '   End If
   'End Sub
   '
   Private Sub TbSucursal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbSucursal.TextChanged
      CalcNumeros()
   End Sub
   '
   Private Sub TbRemito_KeyPress(sender As Object, e As KeyPressEventArgs)
      SoloNumeros(e.KeyChar,,, "-")
   End Sub
   '
   Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
      LimpiaTemp()
      Me.Close()
   End Sub
   '
   Private Sub FrmVentasAM_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
      If ExisteTabla(cn, cTmp) Then
         Cmd.CommandText = "DROP TABLE " & cTmp
         Cmd.ExecuteNonQuery()
      End If
      SetDBGrid(Me, DataGridView1)
      SetDBForm(Me)
   End Sub
   '
End Class