Public Class frmOrdenesPagoAM
   '
   Public cmpInt As String
   Public Alta As Boolean
   Public Sucursal As Integer = 0
   Public OrdenPagoId As Long = 0
   Public Proveedor As Long = 0
   Public PagoDir As Boolean
   Public SoloVer As Boolean
   '
   Dim Trn As OleDb.OleDbTransaction
   Dim Cmd As New OleDb.OleDbCommand
   '
   Dim OPNumero As Long
   '
   Dim TablaC As String
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
   Dim FormLoad As Boolean = False
   '
   Const estEMIT = 1
   '
   Private Sub frmOrdenesPagoAM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      '
      GetRegForm(Me)
      '
      TraducirForm(Me)
      '
      Me.Text = Me.Text & IIf(Alta, "", " - Nº " & OrdenPagoId) & " - " & Traducir(IIf(Alta, "Alta", "Edición"))
      '
      Cmd.Connection = Cn
      '
      TablaC = IIf(cmpInt = "PC" Or cmpInt = "OP", "Compras", "CompraOtr")
      '
      If Not Alta Then
         '
         cmdQuitar.Enabled = False
         cmdGuardar.Enabled = False
         '
         Trn = Cn.BeginTransaction
         '
         With Cmd
            .Transaction = Trn
            .CommandText = "DELETE FROM PagosDetTmp WHERE Usuario = '" & Uid & "'"
            .ExecuteNonQuery()
            '
            .CommandText = "INSERT INTO PagosDetTmp( Usuario, Fecha, Nombre, Proveedor, Sucursal, Numero, Comprob, Tipo, PerIva, Total, Propietario, Propiedad) " & _
                           "SELECT '" & Uid & "' AS Usuario, C.Fecha, ISNULL(P.Nombre,'(Varios)'), D.Proveedor, D.ProSucursal, D.ProNumero, D.ProComprob, '', '', C.Total, " & IIf(cmpInt = "PO", "C.Propietario, C.Propiedad ", "NULL, NULL ") & _
                           "FROM (OrdenPagoDet D LEFT JOIN Proveedores P ON D.Proveedor = P.Codigo) " & _
                           " INNER JOIN " & IIf(cmpInt = "PO", "CompraOtr", "Compras") & " C " & _
                           "  ON  D.Proveedor = C.Proveedor" & _
                           "  AND D.ProComprob = " & IIf(cmpInt = "PO", "C.Comprob", "LEFT(C.Comprob,3)") & _
                           "  AND D.ProSucursal = C.Sucursal" & _
                           "  AND D.ProNumero = C.Numero " & _
                           "WHERE D.OrdenPagoID = " & OrdenPagoId
            .ExecuteNonQuery()
            '
         End With
         '
         Trn.Commit()
         '
         tbDetalle.Text = CapturaDato(Cn, "OrdenPago", "OPDetalle", "OrdenPagoId=" & OrdenPagoId)
         OPNumero = CapturaDato(Cn, "OrdenPago", "OpNumero", "OrdenPagoId=" & OrdenPagoId)
         '
      End If
      '
      'Adodc1.ConnectionString = Cn
      '
      'If CaptCtasConc(cfgCodigoInt, cDescInt, cCtaInt, "") Then
      '   If CaptCtasConc(cfgCodigoVCar, cDescVCar, "", cCtaVCar) Then
      '      CaptCtas = True
      '   End If
      'End If
      '
      If Not CaptCtas Then DeshabForm(Me)
      '
      ArmaComboItem(cbProveedor, "Proveedores", "Codigo", "Nombre", "Nombre", "(Varios)")
      '
      If Proveedor <> 0 Then
         PosCboItem(cbProveedor, Proveedor)
      End If
      '
      nTipoMov = CapturaDato(Cn, "TipoMovBco", "TipoMovBco", "TipoMov = 'CH'")
      cImput = CapturaDato(Cn, "TipoMovBco", "Imput", "TipoMov = 'CH'")
      '
      'With Cmd
      '   .Open("SELECT * FROM TipoMovBco WHERE TipoMov = 'CH'", Cn, adOpenForwardOnly, adLockReadOnly)
      '   If Not .EOF Then
      '      nTipoMov = !Tipo
      '      cImput = !Imput
      '   End If
      '   .Close()
      'End With
      '
      dtpFecha.Value = Today
      '
      If Alta Then
         LimpiaTemp()
      Else
         Aceptar()
      End If
      '
      FormLoad = True
      ActData()
      '
   End Sub
   '
   Private Sub form_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
      TabReturn(e.KeyChar)
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
   Private Sub cmdAceptar_Click(sender As Object, e As EventArgs) Handles cmdAceptar.Click
      Aceptar()
   End Sub
   '
   Private Sub Aceptar()
      If cbProveedor.Text = "" Then
         MensajeTrad("DIProveedor")
         Exit Sub
      End If
      ArmaCombos()
      ActivaCtrl(True)
      CalcImportes()
   End Sub
   '
   Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
      If PagoDir Then
         Me.Close()
      Else
         If Alta Then
            If cbProveedor.Enabled Then
               ActivaCtrl(False)
               LimpiaTemp()
               ActData()
            Else
               Me.Close()
            End If
         Else
            Me.Close()
         End If
      End If
   End Sub
   '
   Private Sub ArmaCombos()
      '
      '   If chkCartera = 0 Then
      '      ArmaCombo cbBanco, "Codigo", "Bancos", cbDescBco, "Nombre", "Nombre", "Codigo IN(SELECT DISTINCT Banco FROM BancoCta)"
      '   Else
      '      ArmaCombo cbBanco, "DISTINCT C.Banco", "ChCartera C, Bancos B ", cbDescBco, "B.Nombre", "B.Nombre", "C.Banco = B.Codigo AND C.Estado = 0"
      '   End If
      '
   End Sub
   '
   Private Sub ActivaCtrl(Activo As Boolean)
      '
      cbProveedor.Enabled = Not Activo
      dtpFecha.Enabled = Not Activo
      cmdAceptar.Enabled = Not Activo And Alta
      DataGridView1.Enabled = Activo
      cmdAgregar.Enabled = Activo And Not SoloVer
      cmdQuitar.Enabled = Activo And Not SoloVer
      tbDetalle.Enabled = Activo And Not SoloVer
      cmdGuardar.Enabled = Activo And Not SoloVer
      cmdCancelar.Enabled = Activo
      '
   End Sub
   '
   Private Sub cmdAgregar_Click(sender As Object, e As EventArgs) Handles cmdAgregar.Click
      With frmPagosAgrCmp
         .ordenpagoid = OrdenPagoId
         .cmpInt = cmpInt
         .nProveedor = Proveedor
         .tbNombre.Text = cbProveedor.Text
         .ShowDialog(Me)
         ActData()
      End With
   End Sub
   '
   Private Sub cmdQuitar_Click(sender As Object, e As EventArgs) Handles cmdQuitar.Click
      '
      Dim Tipo As String
      Dim Sucursal As Int16
      Dim Numero, Proveedor As Int32
      Dim Comprob As String
      '
      With DataGridView1
         If .RowCount > 0 Then
            Tipo = .SelectedCells(.Columns("Tipo").Index).Value
            Proveedor = .SelectedCells(.Columns("Proveedor").Index).Value
            Sucursal = .SelectedCells(.Columns("Sucursal").Index).Value
            Numero = .SelectedCells(.Columns("Numero").Index).Value
            Comprob = .SelectedCells(.Columns("Comprob").Index).Value
            If DaDeBaja(Comprob & " - " & Tipo & " N° " & Sucursal & "-" & Numero & " Prov.: " & Proveedor) Then
               Trn = Cn.BeginTransaction
               With Cmd
                  .Transaction = Trn
                  .CommandText = "DELETE FROM PagosDetTmp WHERE Usuario = '" & Uid & "' AND Comprob = '" & Comprob & "' AND Tipo = '" & Tipo & "' AND Sucursal = " & Sucursal & " AND Numero = " & Numero & " AND Proveedor = " & Proveedor
                  .ExecuteNonQuery()
               End With
               Trn.Commit()
            End If
            ActData()
         End If
      End With
   End Sub
   '
   Private Sub LimpiaTemp()
      Trn = Cn.BeginTransaction
      With Cmd
         .Transaction = Trn
         .CommandText = "DELETE FROM PagosDetTmp WHERE Usuario = '" & Uid & "'"
         .ExecuteNonQuery()
      End With
      Trn.Commit()
      '
   End Sub
   '
   Sub ActData()
      '
      Dim cSQL As String
      '
      If Not FormLoad Then Exit Sub
      '
      cSQL = "SELECT T.Fecha, T.Nombre, T.Proveedor, T.Sucursal, T.Numero, T.Comprob, D.Detalle, T.Tipo, T.PerIva, T.Total, P.Nombre AS NomProp, R.Domicilio " & _
                                "FROM (((PagosDetTmp T LEFT JOIN " & IIf(cmpInt = "OP", "ComprasDet", "CompraOtrDet") & " D " & _
                                " ON T.Proveedor = D.Proveedor " & IIf(cmpInt = "OP", "", "AND T.Comprob = D.Comprob ") & "AND T.Sucursal = D.Sucursal AND T.Numero = D.Numero) " & _
                                "LEFT JOIN Propietarios P ON T.Propietario = P.Codigo) " & _
                                "LEFT JOIN Propiedades R ON T.Propiedad = R.Codigo) " & _
                                "WHERE T.Usuario = '" & Uid & "' AND D.Renglon = 1 " & _
                                "ORDER BY T.Fecha, T.Nombre"
      '
      SetRegGrid(Me, DataGridView1)

      LlenarGrid(DataGridView1, cSQL)
      '
      ActivaCtrl(True)
      '
      nSubTotal = CapturaDato(Cn, "PagosDetTmp", "ISNULL(SUM(Total),0)", "Usuario = '" & Uid & "'")
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
                  Case "TIPO"
                     If cmpInt = "PO" Then
                        .Visible = False
                     Else
                        .Width = 500
                     End If
                  Case "SUCURSAL" : .Width = 75
                  Case "NUMERO" : .Width = 100
                  Case "FECHA" : .Width = 110
                  Case "PERIVA"
                     If cmpInt = "PO" Then
                        .Visible = False
                     Else
                        .Width = 100 : .HeaderText = "Per.Iva."
                     End If
                  Case "NOMBRE" : .Width = 250 : .HeaderText = "Proveedor"
                  Case "TOTAL" : .Width = 100
                     With .DefaultCellStyle
                        .Format = "#,##0.00 "
                        .Alignment = DataGridViewContentAlignment.MiddleRight
                     End With
                  Case "NOMPROP" : .HeaderText = "Propietario"
                  Case "DOMICILIO"
                  Case "DETALLE"
                  Case Else : .Visible = False
               End Select
            End With
         Next Col
      End With
      '
   End Sub
   '
   Private Sub tbIntereses_Change()
      CalcImportes()
   End Sub
   '
   Private Sub CalcImportes()
      'nIntereses = Val(tbIntereses)
      nTotal = nSubTotal + nIntereses
      'tbSubTotal = Format(nSubTotal, "Fixed")
      tbTotal.Text = Format(nTotal, "Fixed")
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
   Private Sub cmdGuardar_Click(sender As Object, e As EventArgs) Handles cmdGuardar.Click
      If ValidaDatos() Then
         If Guardar() Then
            GenRepOrdPago(cmpInt, prmSucursal, OPNumero, "ORDEN DE PAGO", crptToWindow)
            Me.Close()
         End If
      End If
   End Sub
   '
   Private Function ValidaDatos() As Boolean
      '
      If DataGridView1.RowCount = 0 Then
         MensajeTrad("DiCptes")
         Return False
      End If
      '
      If Val(tbTotal.Text) < 0 Then
         MensajeTrad("Total<0")
         Return False
      End If
      '
      'If Val(tbEfectivo) + Val(tbCheque) = 0 Then
      '   MensajeTrad "DIEfeOChe"
      '   tbEfectivo.SetFocus
      '   Exit Function
      'ElseIf Format(Val(tbEfectivo) + Val(tbCheque), "Fixed") <> Format(tbTotal, "Fixed") Then
      '   MensajeTrad "Ef+Ch<>Tot"
      '   tbEfectivo.SetFocus
      '   Exit Function
      'End If
      '
      'If Val(tbCheque) > 0 Then
      '   If cbBanco = "" Then
      '      MensajeTrad "DIBanco"
      '      cbDescBco.SetFocus
      '      Exit Function
      '   ElseIf cbCtaBco = "" Then
      '      MensajeTrad "DICtaBco"
      '      cbCtaBco.SetFocus
      '      Exit Function
      '   ElseIf cbNroCheque = "" Then
      '      MensajeTrad "DINroCheque"
      '      cbNroCheque.SetFocus
      '      Exit Function
      '   End If
      'End If
      '
      ValidaDatos = True
      '
   End Function
   '
   Private Function Guardar() As Boolean
      '
      Dim compCaja As String
      Dim CodAsi As String
      '
      Try
         '
         Trn = Cn.BeginTransaction
         '
         If Alta Then
            BuscarCfg(cfgNroPago, "cfgNroPago", Trn)
            OPNumero = cfgNroPago + 1
            Do While Not IsNothing(CapturaDato(Cn, "OrdenPago", "OpNumero", "OpNumero = " & OPNumero, , , , Trn))
               OPNumero = OPNumero + 1
            Loop
            GuardarCfg(cfgNroPago, "cfgNroPago", OPNumero, Trn)
         End If
         '
         compCaja = cmpInt & "-" & OPNumero
         CodAsi = compCaja
         '
         With Cmd
            .Transaction = Trn
            '
            If Alta Then
               .CommandText = "INSERT INTO OrdenPago( Sucursal, OPNumero, OPTipo, Proveedor, OPFecha, OPDetalle, Estado, OPTotal, OPUid, OPFecMod) " & _
                              "VALUES (" & prmSucursal & ", " & _
                                           OPNumero & ", " & _
                                     "'" & cmpInt & "', " & _
                                           Proveedor & ", " & _
                                     "'" & Format(dtpFecha.Value, FormatFecha) & "', " & _
                                     "'" & tbDetalle.Text & "', " & _
                                           0 & ", " & _
                                           nTotal & ", " & _
                                     "'" & Uid & "', " & _
                                     "'" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
               OrdenPagoId = CapturaDato(Cn, "OrdenPago", "MAX(OrdenPagoId)", "", , , , Trn)
            Else
               .CommandText = "UPDATE OrdenPago SET " & _
                              " Sucursal = " & prmSucursal & ", " & _
                              " OPNumero = " & OPNumero & ", " & _
                              " OPTipo = '" & cmpInt & "', " & _
                              " Proveedor = " & Proveedor & ", " & _
                              " OPFecha = '" & Format(dtpFecha.Value, FormatFecha) & "', " & _
                              " OPDetalle = '" & tbDetalle.Text & "', " & _
                              " OPTotal = " & nTotal & ", " & _
                              " OPUid = '" & Uid & "', " & _
                              " OPFecMod = '" & Format(Now, FormatFechaHora) & "' " & _
                              "WHERE OrdenPagoID = " & OrdenPagoId
               .ExecuteNonQuery()
            End If
            '
            .CommandText = "DELETE FROM OrdenPagoDet WHERE OrdenPagoID = " & OrdenPagoId
            .ExecuteNonQuery()
            '
            .CommandText = "UPDATE " & TablaC & " SET Pagado = 0, NroPago = 0 WHERE NroPago = " & OrdenPagoId
            .ExecuteNonQuery()
            '
            .CommandText = "INSERT INTO OrdenPagoDet( OrdenPagoID, Proveedor, ProComprob, ProSucursal, ProNumero, OPDUid, OPDFecMod) " & _
                           "SELECT " & OrdenPagoId & ", Proveedor, Comprob, Sucursal, Numero, '" & Uid & "', '" & Format(Now, FormatFechaHora) & "' " & _
                           "FROM PagosDetTmp WHERE Usuario = '" & Uid & "'"
            .ExecuteNonQuery()
            '
            .CommandText = ("UPDATE " & TablaC & " SET " & _
                            " Pagado = 1, " & _
                            " NroPago = " & OrdenPagoId & ", " & _
                            " Usuario = '" & Uid & "', " & _
                            " FechaMod = '" & Format(Now, FormatFechaHora) & "' " & _
                            "WHERE EXISTS( SELECT * FROM PagosDetTmp " & _
                                          "WHERE Usuario = '" & Uid & "'" & _
                                          "  AND Proveedor = " & TablaC & ".Proveedor" & _
                                          "  AND Comprob = " & TablaC & ".Comprob" & _
                                          "  AND Sucursal = " & TablaC & ".Sucursal" & _
                                          "  AND Numero = " & TablaC & ".Numero)")
            .ExecuteNonQuery()
            '
         End With
         '
         GuardarAudit(IIf(Alta, "Alta", "Modifica") & " Orden de Pago", compCaja, Me.Name, "Guardar", Trn)
         '
         Trn.Commit()
         '
         Mensaje("Se generó la OP Nº " & OPNumero)
         '
         Return True
         '
      Catch ex As System.Exception
         Dim st As New StackTrace(True)
         RegistrarError(st, "OrdenesPagoAM")
         Trn.Rollback()
      End Try
      '
   End Function
   '
   Private Sub frmOrdenesPagoAM_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
      SetRegGrid(Me, DataGridView1)
      SetRegForm(Me)
      Me.Dispose()
   End Sub
   '
End Class