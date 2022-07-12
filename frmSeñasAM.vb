Public Class frmSeñasAM
   '
   Public Tipo As String
   Public Sucursal As Integer
   Public Numero As Long
   Public SoloVer As Boolean
   Public Devolucion As Boolean
   '
   Dim Propietario As Long
   Dim Propiedad As Long
   Dim Banco As Long
   '
   Dim Cmd As New OleDb.OleDbCommand
   Dim Drd As OleDb.OleDbDataReader
   Dim Trn As OleDb.OleDbTransaction
   'Dim rsDLiq As New ADODB.Recordset
   'Dim rsTemp As New ADODB.Recordset
   'Dim rsCart As New ADODB.Recordset
   '
   Dim Total As Double
   Dim nCol As Integer
   Dim nColFec As Integer
   Dim nColCon As Integer
   Dim nColDet As Integer
   Dim nColImp As Integer
   Dim nColAcc As Integer
   Dim Inquilino As Long
   Dim TipoIva As String
   '
   Dim nNumero As Long
   Dim Cliente As Long
   Dim NroCheque As String
   '
   Dim Importe As Double
   Dim AlicIva1 As Single
   Dim AlicIva2 As Single
   '
   Dim cCtaCaja As String
   Dim cCtaCajaAd As String
   Dim cCtaVCar As String
   Dim cCtaVCar3 As String
   Dim cCtaSeña As String
   Dim CaptCtas As Boolean
   '
   Dim tTmp As String = ""
   '
   Const StrTmp = "Renglon INT NOT NULL, " & _
                  "Concepto VARCHAR(10), " & _
                  "Fecha SMALLDATETIME, " & _
                  "Detalle VARCHAR(250), " & _
                  "Debe FLOAT, " & _
                  "Haber FLOAT, " & _
                  "Proveedor INT NULL, " & _
                  "aPropiet BIT NULL"
   '
   Const cmpInt = "CO"
   '
   Private Sub frmSeñasAM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      '
      ' Dim i As Integer
      Dim Sel As String
      Dim Propietario As Long
      Dim Propiedad As Long
      '
      GetRegForm(Me)
      '
      Cmd.Connection = Cn
      '
      tTmp = ""
      If Not CrearTabla(Cn, StrTmp, tTmp) Then
         DeshabForm(Me)
      End If
      '
      If cfgCodigoSen = "" Then
         MensajeTrad("Concepto Seña no definido")
         DeshabForm(Me)
      End If
      '
      If SisContable Then
         If CaptCtasCaja(prmNroCaja, cCtaCaja, cCtaCajaAd) Then
            If CaptCtasConc(cfgCodigoVCar, "", cCtaVCar, cCtaVCar3) Then
               If CaptCtasConc(cfgCodigoSen, "", cCtaSeña, "") Then
                  CaptCtas = True
               End If
            End If
         End If
         '
         If Not CaptCtas Then DeshabForm(Me)
         '
      End If
      '
      ArmaComboItem(cbPropietario, "Propietarios", , "Nombre", "Nombre", , "Estado = 'A'")
      ArmaComboItem(cbCliente, "Clientes", , "Nombre", "Nombre")
      ArmaComboItem(cboBanco, "Bancos", "Banco", "Nombre", "Nombre")
      '
      tbNumero.Enabled = False
      dtpFecHasta.Value = Today.AddDays(5)
      tbConcepto.Text = cfgCodigoSen
      '
      If Devolucion Then
         Me.Text = "Devolución de Seña"
         cmdGenerar.Text = "Devolver"
         cbNroCheque.DropDownStyle = ComboBoxStyle.DropDownList
         tbCheque.Enabled = False
         tbCtaBanco.Enabled = False
         tbTitular.Enabled = False
         tbFecCheque.Enabled = False
      End If
      '
      If SoloVer Or Devolucion Then
         If CapturaDato(Cn, "CobrosOtr", "Cliente", "Tipo='" & Tipo & "' AND Sucursal=" & Sucursal & " AND Numero=" & Numero) = 0 Then
            Sel = "SELECT C.Nombre AS Nom, I.Nombre, C.Tipo, C.Sucursal, C.Numero, D.Importe, C.Efectivo, C.Cheques, C.Propietario, C.Propiedad, C.Banco, C.CtaBco, C.NroCheque, C.FecCheque " & _
                  "FROM CobrosOtr C INNER JOIN CobOtrDet D ON C.Tipo = D.Tipo AND C.Sucursal = D.Sucursal AND C.Numero = D.Numero " & _
                  " LEFT JOIN Inquilinos I ON C.Inquilino = I.Codigo " & _
                  "WHERE C.Tipo = '" & Tipo & "'" & _
                  "  AND C.Sucursal = " & Sucursal & _
                  "  AND C.Numero = " & Numero
         Else
            Sel = "SELECT * FROM CobrosOtr C, CobOtrDet D, Clientes CL " & _
                  "WHERE C.Tipo = '" & Tipo & "'" & _
                  "  AND C.Sucursal = " & Sucursal & _
                  "  AND C.Numero = " & Numero & _
                  "  AND C.Tipo = D.Tipo" & _
                  "  AND C.Sucursal = D.Sucursal" & _
                  "  AND C.Numero = D.Numero" & _
                  "  AND C.Cliente = CL.Codigo"
         End If
         '
         With Cmd
            .CommandText = Sel
            Drd = .ExecuteReader
         End With
         '
         With Drd
            If .Read Then
               If IsDBNull(!Nombre) Then
                  cbCliente.Text = !Nom & ""
               Else
                  cbCliente.Text = !Nombre & ""
               End If
               lblLetra.Text = !Tipo
               tbSucursal.Text = !Sucursal
               tbNumero.Text = !Numero
               tbTotal.Text = !Importe
               Total = !Importe
               tbEfectivo.Text = !Efectivo
               tbCheque.Text = !Cheques
               Propietario = Val(!Propietario & "")
               Propiedad = Val(!Propiedad & "")
               tbCtaBanco.Text = !CtaBco & ""
               NroCheque = !NroCheque & ""
               PosCboItem(cboBanco, Val(!Banco & ""))
               If Not IsDBNull(!FecCheque) Then
                  tbFecCheque.Value = !FecCheque
               End If
            Else
               MensajeTrad("CobNoEnc")
            End If
            .Close()
         End With
         '
         Trn = Cn.BeginTransaction
         '
         With Cmd
            .Transaction = Trn
            '
            '.CommandText = "DELETE FROM CobOtrTmp WHERE Usuario = '" & Uid & "' AND PC = '" & NombrePC & "'"
            LimpiaTemp()
            '
            .ExecuteNonQuery()
            '
            .CommandText = "INSERT INTO " & tTmp & "( Renglon, Concepto, Fecha, Detalle, Debe, Haber) " & _
                           "SELECT Renglon, Concepto, Fecha, Detalle, Importe, 0 " & _
                           "FROM CobOtrDet " & _
                           "WHERE Tipo = '" & Tipo & "'" & _
                           "  AND Sucursal = " & Sucursal & _
                           "  AND Numero = " & Numero & _
                           "  AND Imputacion = 'D'"
            .ExecuteNonQuery()
            '
            .CommandText = "INSERT INTO " & tTmp & "( Renglon, Concepto, Fecha, Detalle, Debe, Haber) " & _
                           "SELECT Renglon, Concepto, Fecha, Detalle, 0, Importe " & _
                           "FROM CobOtrDet " & _
                           "WHERE Tipo = '" & Tipo & "'" & _
                           "  AND Sucursal = " & Sucursal & _
                           "  AND Numero = " & Numero & _
                           "  AND Imputacion = 'H'"
            .ExecuteNonQuery()
            '
         End With
         '
         Trn.Commit()
         '
         PosCboItem(cbPropietario, Propietario)
         PosCboItem(cbPropiedad, Propiedad)
         '
         cmdGenerar.Enabled = False
         '
      Else
         Trn = Cn.BeginTransaction
         '
         'With Cmd
         '   .Transaction = Trn
         '   .CommandText = "DELETE FROM CobOtrTmp WHERE Usuario = '" & Uid & "' AND PC = '" & NombrePC & "'"
         '   .ExecuteNonQuery()
         'End With
         '
         LimpiaTemp()
         '
         Trn.Commit()
         '
         CaptRecibo()
         '
      End If
      '
      tbFecCheque.MinDate = Today.AddDays(-365)
      tbFecCheque.MaxDate = Today.AddDays(365)
      tbFecCheque.Value = Today
      '
      If Numero <> 0 And Not SoloVer Then
         ActivaCtrl(True)
      End If
      '
   End Sub
   '
   Private Sub frmSeñasAM_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
      TabReturn(e.KeyChar)
   End Sub
   '
   Private Sub chkImp_CheckedChanged(sender As Object, e As EventArgs) Handles chkRet1.CheckedChanged, chkRet2.CheckedChanged, chkRet3.CheckedChanged, chkAgu1.CheckedChanged, chkAgu2.CheckedChanged, chkAgu3.CheckedChanged, chkExp1.CheckedChanged, chkExp2.CheckedChanged, chkExp3.CheckedChanged
      ArmaDetalle()
   End Sub
   '
   Private Sub ArmaDetalle()
      If Devolucion Then
         tbDetalle.Text = "Devolución de Seña"
      Else
         Dim Localidad As String
         Localidad = CapturaDato(Cn, "Propiedades", "Localidad", "Codigo = " & Propiedad)
         tbDetalle.Text = "SEÑA POR LA PROPIEDAD DEL/A SR./A. " & cbPropietario.Text & _
                     ", UBICADA EN LA CALLE " & cbPropiedad.Text & ", DE LA CIUDAD DE " & Localidad & _
                     ". SEÑA VALIDA HASTA EL " & dtpFecHasta.Value & vbCrLf & _
                     "EL VALOR SE PACTA EN LA SUMA DE $" & txtAlq1.Text & _
                     IIf(chkAgu1.Checked Or chkRet1.Checked Or chkExp1.Checked, " MAS ", "") & _
                     IIf(chkAgu1.Checked, "AGUA", "") & _
                     IIf(chkRet1.Checked, IIf(chkAgu1.Checked, IIf(Not chkExp1.Checked, " Y ", ", "), "") & "RETRIBUTIVOS", "") & _
                     IIf(chkExp1.Checked, IIf(chkAgu1.Checked Or chkRet1.Checked, " Y ", "") & "EXPENSAS", "") & " EL 1º AÑO" & _
                     IIf(Val(txtAlq2.Text) > 0, ", $" & txtAlq2.Text & _
                     IIf(chkAgu2.Checked Or chkRet2.Checked Or chkExp2.Checked, " MAS ", "") & _
                     IIf(chkAgu2.Checked, "AGUA", "") & _
                     IIf(chkRet2.Checked, IIf(chkAgu2.Checked, IIf(Not chkExp2.Checked, " Y ", ", "), "") & "RETRIBUTIVOS", "") & _
                     IIf(chkExp2.Checked, IIf(chkAgu2.Checked Or chkRet2.Checked, " Y ", "") & "EXPENSAS", "") & " EL 2º AÑO", "") & _
                     IIf(Val(txtAlq3.Text) > 0, ", $" & txtAlq3.Text & _
                     IIf(chkAgu3.Checked Or chkRet3.Checked Or chkExp3.Checked, " MAS ", "") & _
                     IIf(chkAgu3.Checked, "AGUA", "") & _
                     IIf(chkRet3.Checked, IIf(chkAgu3.Checked, IIf(Not chkExp3.Checked, " Y ", ", "), "") & "RETRIBUTIVOS", "") & _
                     IIf(chkExp3.Checked, IIf(chkAgu3.Checked Or chkRet3.Checked, " Y ", "") & "EXPENSAS", "") & " EL 3º AÑO", "") & _
                     IIf(chkMesDep.Checked, ". CON MES DE DEPOSITO.", "") & vbCrLf & _
                     "SEÑA AD REFEREMDUM DEL PROPIETARIO.-"
      End If
   End Sub
   '
   Private Sub cbPropietario_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPropietario.SelectedIndexChanged
      With cbPropietario
         If .SelectedIndex > 0 Then
            Propietario = .SelectedValue
         Else
            Propietario = 0
         End If
      End With
      ArmaComboItem(cbPropiedad, "Propiedades", , "Domicilio", "Domicilio", "(Propiedad)", "Propietario = " & Propietario)
      ArmaDetalle()
   End Sub
   '
   Private Sub cmdAceptar_Click(sender As Object, e As EventArgs)
      If Not Validar1() Then Exit Sub
      ActivaCtrl(True)
   End Sub
   '
   Private Sub ActivaCtrl(Activo As Boolean)
      '
      cmdGenerar.Enabled = Activo
      cmdCancelar.Enabled = Activo
      'cmdAceptar.Enabled = Not Activo
      cbPropietario.Enabled = Not Activo
      cbCliente.Enabled = Not Activo
      tbTotal.Enabled = Not Devolucion
      '
   End Sub
   '
   Private Sub cmdGenerar_Click(sender As Object, e As EventArgs) Handles cmdGenerar.Click
      '
      If Not Validar1() Then Exit Sub
      If Not Validar2() Then Exit Sub
      '
      If Guardar() Then
         '
         If AltaAuto("Clientes", "Codigo", Cliente, "Nombre", cbCliente.Text, 0, "", , 0, True) Then
            ArmaComboItem(cbCliente, "Clientes", , "Nombre", "Nombre", "(Cliente)")
         End If
         '
         If Not Devolucion Then
            ImprimirRboOtr(lblLetra.Text, tbSucursal.Text, tbNumero.Text)
         End If
         '
         cmdCancelar_Click()
         '
      End If
      '
   End Sub
   '
   Private Function Validar1() As Boolean
      '
      If cbCliente.Text = "" Or Trim(cbCliente.Text) = "(Cliente)" Then
         MensajeTrad("DIApeNomCli")
         cbCliente.Focus()
         Exit Function
      End If
      '
      If Propietario = 0 Then
         MensajeTrad("DIPropietario")
         cbPropietario.Focus()
         Exit Function
      End If
      '
      If Propiedad = 0 Then
         MensajeTrad("DIPropiedad")
         cbPropiedad.Focus()
         Exit Function
      End If
      '
      If Val(tbNumero.Text) = 0 Then
         MensajeTrad("DINumero")
         tbNumero.Focus()
         Exit Function
      End If
      '
      Validar1 = True
      '
   End Function
   '
   Private Function Validar2() As Boolean
      '
      If Val(tbTotal.Text) = 0 Then
         MensajeTrad("DIImporte")
         tbEfectivo.Focus()
         Exit Function
      End If
      '
      If dtpFecHasta.Value < Today Then
         MensajeTrad("Debe ingresar fecha posterior a Hoy")
         dtpFecHasta.Focus()
         Exit Function
      End If
      '
      If Val(tbEfectivo.Text) + Val(tbCheque.Text) <> Val(tbTotal.Text) Then
         MensajeTrad("Ef+Ch<>Tot")
         tbEfectivo.Focus()
         Exit Function
      End If

      If Val(tbCheque.Text) > 0 Then
         If Banco = 0 Then
            MensajeTrad("DIBanco")
            cboBanco.Focus()
            Exit Function
         ElseIf tbCtaBanco.Text = "" Then
            MensajeTrad("DICtaBco")
            tbCtaBanco.Focus()
            Exit Function
         ElseIf cbNroCheque.Text = "" Then
            MensajeTrad("DINroCheque")
            cbNroCheque.Focus()
            Exit Function
         Else
            If Not Devolucion Then
               If Not IsNothing(CapturaDato(Cn, "ChCartera", "ChCartNro", "Banco = " & Banco & " AND BancoCta = '" & tbCtaBanco.Text & "' AND ChCartNro = '" & cbNroCheque.Text & "'")) Then
                  MensajeTrad("ChYaIng")
                  cbNroCheque.Focus()
                  Exit Function
               End If
            End If
         End If
      End If
      '
      Validar2 = True
      '
   End Function
   '
   Private Sub CaptRecibo(Optional Tr As Object = "")
      tbSucursal.Text = Format(prmSucursal, "0000")
      tbNumero.Text = Format(CaptNroRecibo(lblLetra.Text, Val(tbSucursal.Text), Tr), "00000000")
   End Sub
   '
   Private Sub cmdSalir_Click()
      Me.Close()
   End Sub
   '
   Private Sub cmdCancelar_Click()
      If Devolucion Then
         Me.Close()
      Else
         Dim Ctrl As Control
         ActivaCtrl(False)
         LimpiaTemp(True)
         For Each Ctrl In Me.Controls
            If TypeOf Ctrl Is TextBox Then
               If Ctrl.Enabled Then
                  Ctrl.Text = ""
               End If
            End If
         Next Ctrl
         CaptRecibo()
      End If
   End Sub
   '
   Private Sub cbPropiedad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPropiedad.SelectedIndexChanged
      With cbPropiedad
         If .SelectedIndex > 0 Then
            Propiedad = .SelectedValue
         Else
            Propiedad = 0
         End If
      End With
      ArmaDetalle()
   End Sub
   '
   Private Sub tbCheque_TextChanged(sender As Object, e As EventArgs) Handles tbCheque.TextChanged
      Dim lEnabl As Boolean
      If Val(tbCheque.Text) > 0 Then
         lEnabl = True
      End If
      tbFecCheque.Enabled = lEnabl And Not Devolucion
      cbNroCheque.Enabled = lEnabl Or Devolucion
      cboBanco.Enabled = lEnabl Or Devolucion
      tbCtaBanco.Enabled = lEnabl And Not Devolucion
      tbTitular.Enabled = lEnabl And Not Devolucion
      SumTotal()
   End Sub
   '
   Private Sub tbCheque_KeyPress(KeyAscii As Integer)
      SoloNumeros(KeyAscii)
   End Sub
   '
   Private Sub txtAlq1_TextChanged(sender As Object, e As EventArgs) Handles txtAlq1.TextChanged
      '
      txtAlq2.Enabled = (Val(txtAlq1.Text) > 0)
      chkRet2.Enabled = (Val(txtAlq1.Text) > 0)
      chkAgu2.Enabled = (Val(txtAlq1.Text) > 0)
      chkExp2.Enabled = (Val(txtAlq1.Text) > 0)
      '
      If Not txtAlq2.Enabled Then
         txtAlq2.Text = ""
         chkRet2.Checked = False
         chkAgu2.Checked = False
         chkExp2.Checked = False
      End If

      ArmaDetalle()
      '
   End Sub
   '
   Private Sub txtAlq2_TextChanged(sender As Object, e As EventArgs) Handles txtAlq2.TextChanged
      '
      txtAlq3.Enabled = (Val(txtAlq2.Text) > 0)
      chkRet3.Enabled = (Val(txtAlq2.Text) > 0)
      chkAgu3.Enabled = (Val(txtAlq2.Text) > 0)
      chkExp3.Enabled = (Val(txtAlq2.Text) > 0)
      '
      If Not txtAlq3.Enabled Then
         txtAlq3.Text = ""
         chkRet3.Checked = False
         chkAgu3.Checked = False
         chkExp3.Checked = False
      End If
      '
      ArmaDetalle()
      '
   End Sub
   '
   Private Sub txtImporte_Change()
      Importe = Val(tbTotal.Text)
   End Sub
   '
   Private Sub tbEfectivo_KeyPress(KeyAscii As Integer)
      SoloNumeros(KeyAscii)
   End Sub
   '
   Private Sub tbEfectivo_TextChanged(sender As Object, e As EventArgs) Handles tbEfectivo.TextChanged
      SumTotal()
   End Sub
   '
   Private Sub SumTotal()
      If Not Devolucion Then
         tbTotal.Text = Format(Val(tbEfectivo.Text) + Val(tbCheque.Text), "Fixed")
      End If
   End Sub
   '
   Private Sub cboBanco_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboBanco.SelectedIndexChanged
      With cboBanco
         If .SelectedIndex > 0 Then
            Banco = .SelectedValue
         Else
            Banco = 0
         End If
      End With
      ArmaComboItem(cbNroCheque, "ChCartera", "ChCartId", "ChCartNro", "ChCartNro", "(Ninguno)", "Banco = " & Banco & " AND Estado = 0")
      cbNroCheque.Text = NroCheque
   End Sub
   '
   'Private Sub cbDescBco_Click()
   '   '
   '   cbBanco.ListIndex = cbDescBco.ListIndex
   '   cbCtaBco.Clear
   '   '
   '   With Rs
   '      .Open "SELECT * FROM BancoCta WHERE Banco = " & cbBanco, Cn, adOpenForwardOnly, adLockReadOnly
   '      '.Seek ">=", cbBanco, ""
   '      If .EOF Then
   '         'No tiene cuentas.
   '      Else
   '         Do While !Banco = cbBanco
   '            cbCtaBco.AddItem !Cuenta
   '            .MoveNext
   '            If .EOF Then Exit Do
   '         Loop
   '      End If
   '      .Close
   '   End With
   '   '
   'End Sub
   '
   'Private Sub CalcImportes()
   '   '
   '   nSubTotal = 0
   '   '
   '   'With Adodc1.Recordset
   '   '   Do While Not .EOF
   '   '      nSubTotal = nSubTotal + !Debe - !Haber
   '   '      .MoveNext
   '   '   Loop
   '   '   If .RecordCount > 0 Then .MoveFirst
   '   'End With
   '   '
   '   If lblLetra = "B" Then
   '      nTotal = nSubTotal
   '      nSubTotal = Round(nTotal / (1 + AlicIva1 / 100), 2)
   '      nIva1 = nTotal - nSubTotal
   '      nIva2 = 0
   '   Else
   '      nIva1 = Round(nSubTotal * AlicIva1 / 100, 2)
   '      nIva2 = Round(nSubTotal * AlicIva2 / 100, 2)
   '      nTotal = nSubTotal + nIva1 + nIva2
   '   End If
   '   '
   '   'tbSubTotal = Format(nSubTotal, "Fixed")
   '   'tbIva1 = Format(nIva1, "Fixed")
   '   'tbIva2 = Format(nIva2, "Fixed")
   '   'tbTotal = Format(nTotal, "Fixed")
   '   '
   'End Sub
   '
   Private Function Guardar() As Boolean
      '
      Dim cComprob, FecCheque As String
      Dim cDetCaja As String
      Dim cCtaConc As String = ""
      Dim DetAsi As String = ""
      Dim NroAsi As Long
      Dim RenASi As Integer
      Dim Periodo As String
      '
      Periodo = Format(Today, "yyyymm")
      cComprob = IIf(Devolucion, "-", "") & cmpInt & "-" & lblLetra.Text & "-" & Val(tbSucursal.Text) & "-" & Val(tbNumero.Text)
      '
      If Val(tbCheque.Text) > 0 Then
         FecCheque = "'" & Format(tbFecCheque.Value, FormatFecha) & "'"
      Else
         FecCheque = "NULL"
      End If
      '
      Dim nRenglon As Integer
      '
      Trn = Cn.BeginTransaction
      '
      CaptRecibo(Trn)
      '
      GuardarNroRecibo(lblLetra.Text, Val(tbNumero.Text), Trn)
      '
      With Cmd
         '
         .Transaction = Trn
         '
         If Devolucion Then
            .CommandText = "UPDATE CobrosOtr SET Estado = 7 WHERE Tipo = '" & Tipo & "' AND Sucursal = " & Sucursal & " AND Numero = " & Numero
            .ExecuteNonQuery()
         Else
            .CommandText = "INSERT INTO CobrosOtr( Tipo, Sucursal, Numero, Cliente, Inquilino, Propietario, Propiedad, Fecha, Nombre, Domicilio, TipoIva, Subtotal, Iva1, Iva2, Total, Efectivo, Cheques, Banco, CtaBco, NroCheque, FecCheque, Moneda, Detalle, LiqPropiet, Liquidado, Caja, Usuario, FechaMod) " & _
                           "VALUES('" & lblLetra.Text & "', " & _
                                        Val(tbSucursal.Text) & ", " & _
                                        Val(tbNumero.Text) & ", " & _
                                        Cliente & ", " & _
                                        Inquilino & ", " & _
                                        Propietario & ", " & _
                                        Propiedad & ", " & _
                                  "'" & Format(Today, FormatFecha) & "', " & _
                                  "'" & cbCliente.Text & "', " & _
                                  "'" & cbPropiedad.Text & "', " & _
                                        0 & ", " & _
                                        Val(tbTotal.Text) & ", " & _
                                        0 & ", " & _
                                        0 & ", " & _
                                        Val(tbTotal.Text) & ", " & _
                                        Val(tbEfectivo.Text) & ", " & _
                                        Val(tbCheque.Text) & ", " & _
                                        Banco & ", " & _
                                  "'" & tbCtaBanco.Text & "', " & _
                                  "'" & cbNroCheque.Text & "', " & _
                                        FecCheque & ", " & _
                                  "'" & "PES" & "', " & _
                                  "'" & tbDetalle.Text & "', " & _
                                        0 & ", " & _
                                        0 & ", " & _
                                        prmNroCaja & ", " & _
                                  "'" & Uid & "', " & _
                                  "'" & Format(Now, FormatFechaHora) & "')"
            .ExecuteNonQuery()
         End If
      End With
      '
      'Asiento.
      If SisContable Then
         NroAsi = GuardaAsiento(cComprob, Today, DetAsi, Trn)
         If NroAsi = 0 Then
            Err.Raise(1001, , Traducir("NoUpAsiento", , Trn))
         End If
      End If
      '
      If Val(tbEfectivo.Text) > 0 Then
         cDetCaja = txtDescConc.Text
         If Not ActCaja(prmNroCaja, cComprob, "EF", Today, cbCliente.Text, "Efectivo", cDetCaja, IIf(Devolucion, 0, tbEfectivo.Text), IIf(Devolucion, tbEfectivo.Text, 0), , Trn) Then
            Err.Raise(1001)
         End If
         '
         If SisContable Then
            RenASi = RenASi + 1
            If Not GuardaAsienDet(NroAsi, RenASi, cCtaCajaAd, DetAsi, IIf(Devolucion, 0, tbEfectivo.Text), IIf(Devolucion, tbEfectivo.Text, 0), Trn) Then
               Err.Raise(1001, , Traducir("NoUpAsiento"))
            End If
         End If
         '
      End If
      '
      If Val(tbCheque.Text) > 0 Then
         cDetCaja = "CH." & cboBanco.Text & " Nº" & cbNroCheque.Text & " Al:" & tbFecCheque.Value
         If Not ActCaja(prmNroCaja, cComprob, "CH", Today, cbCliente.Text, cDetCaja, txtDescConc.Text, IIf(Devolucion, 0, tbCheque.Text), IIf(Devolucion, tbCheque.Text, 0), , Trn) Then
            Err.Raise(1001)
         End If
         '
         If SisContable Then
            RenASi = RenASi + 1
            If Not GuardaAsienDet(NroAsi, RenASi, cCtaVCar3, DetAsi, IIf(Devolucion, 0, tbCheque.Text), IIf(Devolucion, tbCheque.Text, 0), Trn) Then
               Err.Raise(1001, , Traducir("NoUpAsiento", , Trn))
            End If
         End If
         '
         With Cmd
            If Devolucion Then
               .CommandText = "UPDATE ChCartera SET " & _
                              " Estado = 2, " & _
                              " Detalle = Detalle + '(Devolución de Seña)' " & _
                              "WHERE Banco = " & Banco & " AND BancoCta = '" & tbCtaBanco.Text & "' AND ChCartNro = '" & cbNroCheque.Text & "'"
            Else
               .CommandText = "INSERT INTO ChCartera( Banco, BancoCta, ChCartNro, Titular, FechaEmi, FechaDif, Entrego, Importe, Estado, CajaAdm, Caja, Usuario, FechaMod) " & _
                              "VALUES(" & Banco & ", " & _
                                    "'" & tbCtaBanco.Text & "', " & _
                                    "'" & cbNroCheque.Text & "', " & _
                                    "'" & tbTitular.Text & "', " & _
                                    "'" & Format(Today, FormatFecha) & "', " & _
                                    "'" & Format(tbFecCheque.Value, FormatFecha) & "', " & _
                                    "'" & cbCliente.Text & "', " & _
                                          tbCheque.Text & ", " & _
                                          0 & ", " & _
                                          1 & ", " & _
                                          prmNroCaja & ", " & _
                                    "'" & Uid & "', " & _
                                    "'" & Format(Now, FormatFechaHora) & "')"
            End If
            .ExecuteNonQuery()
         End With
      End If
      '
      With Cmd
         '
         If Devolucion Then
            '.CommandText = "DELETE FROM CobOtrDet WHERE Tipo = '" & Tipo & "' AND Sucursal = " & Sucursal & " AND Numero = " & Numero
         Else
            nRenglon = nRenglon + 1
            .CommandText = "INSERT INTO CobOtrDet( Tipo, Sucursal, Numero, Renglon, Concepto, Fecha, Detalle, Importe, Imputacion, aPropiet, Usuario, FechaMod) " & _
                           "VALUES('" & lblLetra.Text & "', " & _
                                        tbSucursal.Text & ", " & _
                                        tbNumero.Text & ", " & _
                                        nRenglon & ", " & _
                                  "'" & cfgCodigoSen & "', " & _
                                  "'" & Format(Today, FormatFecha) & "', " & _
                                  "'" & txtDescConc.Text & "', " & _
                                        tbTotal.Text & ", " & _
                                  "'" & "D" & "', " & _
                                        IIf(chkAPropiet.Checked, 1, 0) & ", " & _
                                  "'" & Uid & "', " & _
                                  "'" & Format(Now, FormatFechaHora) & "')"
         End If
         '
         .ExecuteNonQuery()
         '
      End With
      '
      If SisContable Then
         If Not CaptCtasConc(cfgCodigoSen, "", "", cCtaConc) Then
            Err.Raise(1001, , "NoCaptCta")
         End If
         '
         RenASi = RenASi + 1
         If Not GuardaAsienDet(NroAsi, RenASi, cCtaConc, DetAsi, IIf(Devolucion, tbTotal.Text, 0), IIf(Devolucion, 0, tbTotal.Text)) Then
            Err.Raise(1001, , Traducir("NoUpAsiento"))
         End If
      End If
      '
      Trn.Commit()
      '
      Return True
      '
      'mError:
      '      MsgBox(Err.Number & ": " & Err.Description & Chr(13) + Chr(10) & _
      '             Traducir("TransNComp"))
      '      Cn.RollbackTrans()
      '
   End Function
   '
   Private Sub txtAlq3_TextChanged(sender As Object, e As EventArgs) Handles txtAlq3.TextChanged
      ArmaDetalle()
   End Sub
   '
   Private Sub chkMesDep_CheckedChanged(sender As Object, e As EventArgs) Handles chkMesDep.CheckedChanged
      ArmaDetalle()
   End Sub
   '
   Private Sub cbCliente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCliente.SelectedIndexChanged
      With cbCliente
         If .SelectedIndex > 0 Then
            Cliente = .SelectedValue
         Else
            Cliente = 0
         End If
      End With
   End Sub
   '
   Private Sub LimpiaTemp(Optional IniTrans As Boolean = False)
      If IniTrans Then
         Trn = Cn.BeginTransaction
      End If
      With Cmd
         '.CommandText = "DELETE FROM CobOtrTmp " & _
         '               "WHERE Tipo = '" & lblLetra.Text & "'" & _
         '               "  AND Sucursal = " & Val(tbSucursal.Text) & _
         '               "  AND Numero = " & Val(tbNumero.Text)
         .Transaction = Trn
         .CommandText = "DELETE FROM " & tTmp
         .ExecuteNonQuery()
      End With
      If IniTrans Then
         Trn.Commit()
      End If
   End Sub
   '
   Private Sub cbNroCheque_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbNroCheque.SelectedIndexChanged
      '
      Dim ChequeId As Int32
      Dim Cmd As New OleDb.OleDbCommand
      Dim Drd As OleDb.OleDbDataReader
      '
      With cbNroCheque
         If .SelectedIndex > 0 Then
            ChequeId = .SelectedValue
         End If
      End With
      With Cmd
         .Connection = Cn
         .CommandText = "SELECT * FROM ChCartera WHERE ChCartId = " & ChequeId
         Drd = .ExecuteReader
      End With
      With Drd
         If .Read Then
            tbCheque.Text = !Importe
            tbCtaBanco.Text = !BancoCta & ""
            cbNroCheque.Text = !ChCartNro & ""
            tbTitular.Text = !Titular
            tbFecCheque.Value = !FechaDif
         Else
            tbCheque.Text = ""
            tbCtaBanco.Text = ""
            cbNroCheque.Text = ""
            tbTitular.Text = ""
            tbFecCheque.Value = Today
         End If
         .Close()
      End With
      '
   End Sub
   '
   Private Sub tbConcepto_TextChanged(sender As Object, e As EventArgs) Handles tbConcepto.TextChanged
      txtDescConc.Text = CapturaDato(Cn, "Conceptos", "Descrip", "Codigo = '" & tbConcepto.Text & "'") & ""
   End Sub
   '
   Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
      Me.Close()
   End Sub
   '
   Private Sub frmSeñasAM_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
      EliminaTmp(Cn, tTmp)
      Numero = 0
      SoloVer = False
      Devolucion = False
      SetRegForm(Me)
      Me.Dispose()
   End Sub
   '
End Class