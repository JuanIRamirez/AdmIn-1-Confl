Public Class frmCobrosOtr
   '
   Public Tipo As String
   Public Sucursal As Integer
   Public Numero As Long
   Public SoloVer As Boolean
   '
   Dim Trn As OleDb.OleDbTransaction
   Dim Cmd As New OleDb.OleDbCommand
   Dim Cm2 As New OleDb.OleDbCommand
   Dim Drd As OleDb.OleDbDataReader
   '
   Dim nCol As Integer
   Dim nColFec As Integer
   Dim nColCon As Integer
   Dim nColDet As Integer
   Dim nColImp As Integer
   Dim nColAcc As Integer
   '
   Dim Propietario, Propiedad, Inquilino As Int32
   Dim TipoIva As String
   Dim Nombre As String
   Dim nNumero As Long
   Dim Cliente As Long
   Dim Periodo As String
   '
   Dim nSubTotal As Double
   Dim nIva1 As Double
   Dim nIva2 As Double
   Dim nTotal As Double
   Dim AlicIva1 As Single
   Dim AlicIva2 As Single
   '
   Dim cCtaCaja As String
   Dim cCtaCajaAd As String
   Dim cCtaVCar As String
   Dim cCtaVCar3 As String
   Dim CaptCtas As Boolean
   '
   Dim Tmp As String = ""
   Dim Tch As String = ""
   Dim tTR As String = ""
   '
   Const strTmp = "Renglon INT NOT NULL, " & _
                  "Concepto VARCHAR(10), " & _
                  "Fecha SMALLDATETIME, " & _
                  "Detalle VARCHAR(250), " & _
                  "Debe FLOAT, " & _
                  "Haber FLOAT, " & _
                  "Proveedor INT NULL, " & _
                  "aPropiet BIT NULL"
   '
   Const strTCh = "Renglon SMALLINT, " & _
                  "Origen VARCHAR (1), " & _
                  "Banco INT, " & _
                  "DescBco VARCHAR(50), " & _
                  "Cuenta VARCHAR(25), " & _
                  "Titular VARCHAR(50), " & _
                  "Numero VARCHAR(25), " & _
                  "Fecha SMALLDATETIME, " & _
                  "Importe FLOAT, " & _
                  "CtaCont VARCHAR(25), " & _
                  "Usuario VARCHAR(25)"
   '
   Const strTr = "Banco0 INT NOT NULL, " & _
                 "Cuenta0 VarChar(25) NOT NULL, " & _
                 "Titular VarChar(50) NOT NULL, " & _
                 "Banco1 INT NOT NULL, " & _
                 "Cuenta1 VarChar(25) NOT NULL, " & _
                 "FechaTR SmallDateTime NOT NULL, " & _
                 "NumeroTR VarChar(25) NOT NULL, " & _
                 "ImporteTR FLOAT NOT NULL, " & _
                 "GastosImp FLOAT NULL, " & _
                 "GastosSF FLOAT NULL, " & _
                 "GastosIva FLOAT NULL, " & _
                 "ImporteNeto FLOAT NULL"
   '
   Const cmpInt = "CO"
   '
   Private Sub frmCobrosOtr_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      '
      'Dim i As Integer
      Dim Sel As String
      '
      GetRegForm(Me)
      '
      Cmd.Connection = Cn
      '
      Tmp = ""
      If Not CrearTabla(Cn, strTmp, Tmp) Then
         DeshabForm(Me)
      End If
      '
      Tch = ""
      If Not CrearTabla(Cn, strTCh, Tch) Then
         DeshabForm(Me)
      End If
      '
      tTR = ""
      If Not CrearTabla(Cn, strTr, tTR) Then
         DeshabForm(Me)
      End If
      '
      If SisContable Then
         If CaptCtasCaja(prmNroCaja, cCtaCaja, cCtaCajaAd) Then
            If CaptCtasConc(cfgCodigoVCar, "", cCtaVCar, cCtaVCar3) Then
               CaptCtas = True
            End If
         End If
         '
         If Not CaptCtas Then DeshabForm(Me)
         '
      End If
      '
      If FechaIncorrecta() Then
         DeshabForm(Me)
      End If
      '
      'cboProp.AddItem "(Admin)"
      'cbDescProp.AddItem "(Administración)"
      'cboProp.ListIndex = 0
      '
      'ArmaComboItem(cbPropietario, "Propietarios", , "Nombre", "Nombre", "(Administración)", "Estado = 'A'")
      '
      'With Cmd
      '   .Open("SELECT * FROM Propietarios WHERE Estado = 'A' ORDER BY Nombre", Cn, adOpenForwardOnly, adLockReadOnly)
      '   If .RecordCount > 0 Then
      '      Do While Not .EOF
      '         cboProp.AddItem!Codigo()
      '         cbDescProp.AddItem!Nombre()
      '         .MoveNext()
      '      Loop
      '   End If
      '   .Close()
      'End With
      '
      'ArmaComboItem(cbBanco, "Bancos", , "Nombre", "Nombre", "(Banco)")
      ArmaCombo(cbTipoIva, "Descrip", "TipoIva", "Descrip", , , "(Tipo de IVA)")
      ArmaCboCliInqProp()   'Nuevo 17/09/2005.
      tbNumero.Enabled = False
      Periodo = Format(Today, "yyyyMM")
      '
      If SoloVer Then
         '
         ActData()
         '
         Inquilino = Val(CapturaDato(Cn, "CobrosOtr", "Inquilino", "Tipo = '" & Tipo & "' AND Sucursal = " & Sucursal & " AND Numero = " & Numero) & "")
         If Inquilino > 0 Then
            chkInquilinos.Checked = True
            PosCboItem(cbCliInq, Inquilino)
            Sel = "SELECT C.*, I.Nombre AS Nombre FROM CobrosOtr C, CobOtrDet D, Inquilinos I " & _
                  "WHERE C.Tipo = '" & Tipo & "'" & _
                  "  AND C.Sucursal = " & Sucursal & _
                  "  AND C.Numero = " & Numero & _
                  "  AND C.Tipo = D.Tipo" & _
                  "  AND C.Sucursal = D.Sucursal" & _
                  "  AND C.Numero = D.Numero" & _
                  "  AND C.Inquilino = I.Codigo"
         Else
            Sel = "SELECT C.*, CL.Nombre AS Nombre FROM CobrosOtr C, CobOtrDet D, Clientes CL " & _
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
            With Drd
               If .Read Then
                  cbCliInq.Text = !Nombre
                  lblLetra.Text = !Tipo
                  tbSucursal.Text = !Sucursal
                  tbNumero.Text = !Numero
                  tbEfectivo.Text = Format(Val(!Efectivo & ""), "Fixed")
                  tbCheques.Text = Format(Val(!Cheques & ""), "Fixed")
                  txtTransferencia.Text = Format(Val(!CooTransf & ""), "Fixed")
               Else
                  MensajeTrad("CobNoEnc")
               End If
               .Close()
            End With
            '
            Trn = Cn.BeginTransaction
            '
            .Transaction = Trn
            '.CommandText = "DELETE FROM CobOtrTmp WHERE Usuario = '" & Uid & "' AND PC = '" & NombrePC & "'"
            '.ExecuteNonQuery()
            '
            .CommandText = "INSERT INTO " & Tmp & "( Renglon, Concepto, Fecha, Detalle, Debe, Haber) " & _
                           "SELECT Renglon, Concepto, Fecha, Detalle, Importe, 0 " & _
                           "FROM CobOtrDet " & _
                           "WHERE Tipo = '" & Tipo & "'" & _
                           "  AND Sucursal = " & Sucursal & _
                           "  AND Numero = " & Numero & _
                           "  AND Imputacion = 'D'"
            .ExecuteNonQuery()
            '
            .CommandText = "INSERT INTO " & Tmp & "( Renglon, Concepto, Fecha, Detalle, Debe, Haber) " & _
                           "SELECT Renglon, Concepto, Fecha, Detalle, 0, Importe " & _
                           "FROM CobOtrDet " & _
                           "WHERE Tipo = '" & Tipo & "'" & _
                           "  AND Sucursal = " & Sucursal & _
                           "  AND Numero = " & Numero & _
                           "  AND Imputacion = 'H'"
            .ExecuteNonQuery()
         End With
         '
         Trn.Commit()
         '
         ActivaCtrl(True)
         '
      Else
         '
         'Trn = Cn.BeginTransaction
         'With Cmd
         '   .Transaction = Trn
         '   .CommandText = "DELETE FROM CobOtrTmp WHERE Usuario = '" & Uid & "' AND PC = '" & NombrePC & "'"
         '   .ExecuteNonQuery()
         'End With
         'Trn.Commit()
         '
         LimpiaTemp()
         CaptRecibo()
         ActivaCtrl(False)
         '
      End If
      '
      ActData()
      ActivaCtrl(False)
      '
   End Sub
   '
   Private Sub frmCobrosOtr_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
      TabReturn(e.KeyChar)
   End Sub
   '
   Private Sub ArmaCboCliInqProp()   'Nuevo 17/09/2005.
      'cbCliente.Clear()
      '
      If chkInquilinos.Checked Then
         cbCliInq.DropDownStyle = ComboBoxStyle.DropDownList
         ArmaComboItem(cbCliInq, "Inquilinos", , "Nombre", "Nombre", "(Seleccionar)", "Estado = 'A'")
         ArmaComboItem(cbProp, "Propiedades", , "Domicilio", "Domicilio", "(Administración)", "Estado = 'A'")
         lblProp.Text = "Propiedad:"
         '
      ElseIf chkPropiet.Checked Then
         cbCliInq.DropDownStyle = ComboBoxStyle.DropDownList
         ArmaComboItem(cbCliInq, "Propietarios", , "Nombre", "Nombre", "(Seleccionar)", "Estado = 'A'")
         lblProp.Text = "Propiedad:"
         '
      Else
         cbCliInq.DropDownStyle = ComboBoxStyle.DropDown
         ArmaComboItem(cbCliInq, "Clientes", , "Nombre", "Nombre", "(Seleccionar)")
         ArmaComboItem(cbProp, "Propietarios", , "Nombre", "Nombre", "(Administración)", "Estado = 'A'")
         lblProp.Text = "Propietario:"
         '
      End If
      '
   End Sub
   '
   'Private Sub cbNombre_Change()
   '   PintarCb(cbNombre, LastKey)
   'End Sub
   '
   Private Sub cbCliente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCliInq.SelectedIndexChanged
      '
      Dim Cmd As New OleDb.OleDbCommand
      Dim Drd As OleDb.OleDbDataReader
      '
      With cbCliInq
         If .SelectedIndex > 0 Then
            Cliente = .SelectedValue
            Nombre = .Text
         End If
      End With
      '
      Cmd.Connection = Cn
      '
      If chkInquilinos.Checked Then
         Inquilino = Cliente
         Cliente = 0
         Propietario = 0
         With Cmd
            .CommandText = "SELECT * FROM Inquilinos WHERE Codigo = " & Inquilino
            Drd = .ExecuteReader
            With Drd
               If .Read Then
                  tbDomicilio.Text = !Domicilio
                  tbCuit.Text = !Cuit
                  cbTipoIva.Text = CapturaDato(Cn, "TipoIva", "Descrip", "Codigo = '" & !TipoIva & "'")
               End If
               .Close()
            End With
         End With
      ElseIf chkPropiet.Checked Then
         Propietario = Cliente
         Cliente = 0
         Inquilino = 0
         With Cmd
            .CommandText = "SELECT * FROM Propietarios WHERE Codigo = " & Propietario
            Drd = .ExecuteReader
            With Drd
               If .Read Then
                  tbDomicilio.Text = !Domicilio
                  tbCuit.Text = !Cuit
                  cbTipoIva.Text = CapturaDato(Cn, "TipoIva", "Descrip", "Codigo = '" & !TipoIva & "'")
               End If
               .Close()
            End With
         End With
         ArmaComboItem(cbProp, "Propiedades", , "Domicilio", "Domicilio", "(Sin especificar)", "Estado = 'A' AND Propietario = " & Propietario)
      Else
         Inquilino = 0
         Propietario = 0
         With Cmd
            .CommandText = "SELECT * FROM Clientes WHERE Codigo = " & Cliente
            Drd = .ExecuteReader
            With Drd
               If .Read Then
                  tbDomicilio.Text = !Domicilio & ""
                  tbCuit.Text = !Cuit & ""
                  cbTipoIva.Text = CapturaDato(Cn, "TipoIva", "Descrip", "Codigo = '" & !TipoIva & "'")
               End If
               .Close()
            End With
         End With
         '
         'ArmaCombo cboProp, "Codigo", "Propiedades", cbDescProp, "Domicilio", "Domicilio", "Codigo IN( SELECT Propiedad FROM Contratos WHERE Inquilino = '" & Inquilino & "' AND Estado = 0)", , "(Ninguna)"
         '
         'Set rsProp = Dbs.OpenRecordset("SELECT Codigo, Domicilio FROM Propiedades WHERE Codigo IN( SELECT Propiedad FROM Contratos WHERE Inquilino = '" & Inquilino & "' AND Estado = 0)")
         'With rsProp
         '   Do Until .EOF
         '      cbProp.AddItem !Codigo
         '      cbDescProp.AddItem !Nombre
         '      .MoveNext
         '   Loop
         '   .Close
         'End With
      End If
      '
      'For i = 0 To cbTipoIva.ListCount - 1
      'If cbTipoIva.List(i) = TipoIva Then   'Nuevo 17/09/2005.
      'cbTipoIva.ListIndex = i
      'End If
      'Next i
      '
   End Sub
   '
   Private Sub cbTipoIva_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbTipoIva.SelectedIndexChanged
      '
      Dim Cmd As New OleDb.OleDbCommand
      Dim Drd As OleDb.OleDbDataReader
      '
      With cbTipoIva
         If .SelectedIndex > 0 Then
            TipoIva = CapturaDato(Cn, "TipoIva", "Codigo", "Descrip = '" & cbTipoIva.Text & "'")
         Else
            TipoIva = ""
            Exit Sub
         End If
      End With
      '
      With Cmd
         .Connection = Cn
         .CommandText = "SELECT * FROM TipoIva WHERE Codigo = '" & TipoIva & "'"
         Drd = .ExecuteReader
         '
         With Drd
            '
            If .Read Then
               'If PagoCobro = 1 Then
               '   lblLetra = "C"
               '   nNumero = Val(cfgNroRboC) + 1
               '   AlicIva1 = 0
               '   AlicIva2 = 0
               'Else
               If cfgImpRboX Then
                  lblLetra.Text = "X"
               Else
                  lblLetra.Text = Strings.Left(Trim(!RecibeComp), 1)
               End If
               'If lblLetra = "A" Then
               '   nNumero = Val(cfgNroRboA) + 1
               'ElseIf lblLetra = "B" Then
               '   nNumero = Val(cfgNroRboB) + 1
               'ElseIf lblLetra = "C" Then
               '   nNumero = Val(cfgNroRboC) + 1
               'Else
               '   nNumero = Val(cfgNroRboX) + 1
               'End If
               nNumero = CaptNroRecibo(lblLetra.Text, Val(tbSucursal.Text))
               'With rsAIva
               '   .Open("SELECT * FROM AlicIva WHERE Codigo = 'GEN'", Cn, adOpenForwardOnly, adLockReadOnly)
               '   '.Seek "=", "GEN"
               '   If .EOF Then
               '      MensajeTrad("AlcIvaGenNEnc")
               '      AlicIva1 = 0
               '      AlicIva2 = 0
               '   Else
               '      'AlicIva1 = !Alicuo1
               '      AlicIva1 = 0
               '      If lblLetra = "A" And _
               '         Trim(rsTIva!EmiteComp) = "C" Then
               '         'AlicIva2 = !Alicuo2
               '         AlicIva2 = 0
               '      Else
               '         AlicIva2 = 0
               '      End If
               '   End If
               '   .Close()
               'End With
               'End If
               CaptRecibo()
            Else
               MensajeTrad("TIvaNoEnc")
               cbTipoIva.SelectedIndex = -1
            End If
            .Close()
         End With
      End With
      '
   End Sub
   '
   Private Sub cmdAceptar_Click(sender As Object, e As EventArgs) Handles cmdAceptar.Click
      '
      If Not Validar1() Then
         Exit Sub
      End If
      '
      Dim Nombre As String = cbCliInq.Text
      '
      If Not chkInquilinos.Checked Then
         If AltaAuto("Clientes", "Codigo", Cliente, "Nombre", cbCliInq.Text, TipoIva, tbCuit.Text, tbDomicilio.Text, 0, True) Then
            'tbCuit, Traducir("ClNoEncDaAlta")) Then
            ArmaCboCliInqProp()
            cbCliInq.Text = Nombre
         End If
      End If
      ActData()
      CalcImportes()
      ActivaCtrl(True)
      cmdAlta.Focus()
   End Sub
   '
   Private Sub ActivaCtrl(Activo As Boolean)
      '
      Dim lEnabl As Boolean = DataGridView1.RowCount() > 0
      '
      cmdAceptar.Enabled = Not Activo
      cbProp.Enabled = Not Activo
      cbCliInq.Enabled = Not Activo
      cbTipoIva.Enabled = Not Activo
      '
      tbEfectivo.Enabled = Activo And Not SoloVer
      tbDetalle.Enabled = Activo And Not SoloVer
      cmdGenerar.Enabled = Activo And Not SoloVer
      cmdCancelar.Enabled = Activo And Not SoloVer
      cmdAlta.Enabled = Activo And Not SoloVer
      cmdBaja.Enabled = Activo And Not SoloVer And lEnabl
      cmdModif.Enabled = Activo And Not SoloVer And lEnabl
      cmdIngCheques.Enabled = Activo And Not SoloVer
      cmdTransferencia.Enabled = Activo And Not SoloVer
      '
   End Sub
   '
   Private Sub cmdAlta_Click(sender As Object, e As EventArgs) Handles cmdAlta.Click
      AltaMod(True)
   End Sub
   '
   Private Sub cmdBaja_Click(sender As Object, e As EventArgs) Handles cmdBaja.Click
      Dim Conc As String = CapturaDatoColumna(DataGridView1, "Concepto")
      If MsgConfirma("Elimina concepto " & Conc) Then
         Trn = Cn.BeginTransaction()
         Cmd.Transaction = Trn
         Cmd.CommandText = "DELETE FROM " & Tmp & " WHERE Concepto = '" & Conc & "'"
         Cmd.ExecuteNonQuery()
         Trn.Commit()
         ActData()
      End If
   End Sub

   Private Sub cmdModif_Click(sender As Object, e As EventArgs) Handles cmdModif.Click
      AltaMod(False)
   End Sub
   '
   Private Sub AltaMod(Alta As Boolean)
      '
      Dim Renglon As Byte
      Dim Concepto As String
      '
      With DataGridView1
         If Alta Then
            Renglon = .RowCount + 1
            Concepto = ""
         Else
            If .RowCount = 0 Then
               MensajeTrad("DSelItem")
               Exit Sub
            Else
               Concepto = .SelectedCells(.Columns("Concepto").Index).Value
               Renglon = .SelectedCells(.Columns("Renglon").Index).Value
            End If
         End If
      End With
      '
      Dim Frm As New frmComprasOtrAmDet
      '
      With Frm
         .Titulo = Me.Text
         .Alta = Alta
         .tTmp = Tmp
         .cConcepto = Concepto
         .nRenglon = Renglon
         .nSucursal = Me.tbSucursal.Text
         .nNumero = Me.tbNumero.Text
         .Propietario = Propietario
         .ShowDialog(Me)
      End With
      '
      ActData()
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
         ImprimirRboOtr(lblLetra.Text, tbSucursal.Text, tbNumero.Text)
         Limpiar()
         '
      End If
      '
   End Sub
   '
   Private Function Validar1() As Boolean
      '
      If cbCliInq.Text = "" Or Trim(cbCliInq.Text) = PrimerItemCb Then
         If cbProp.SelectedIndex <= 0 Then
            MensajeTrad("DIApeNom")
            cbCliInq.Focus()
            Exit Function
         End If
      End If
      '
      If TipoIva = "" Then
         MensajeTrad("DITipoIva")
         cbTipoIva.Focus()
         Exit Function
      End If
      '
      If tbDomicilio.Text = "" Then
         MensajeTrad("DIDomicilio")
         tbDomicilio.Focus()
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

   Private Function Validar2() As Boolean

      Dim Conc As String

      Conc = CapturaDato(Cn, "FactInq", "Concepto", "Periodo = '" & Periodo & "' AND Propiedad = " & Propiedad & " AND Inquilino = " & Inquilino & " AND Concepto IN( SELECT Concepto FROM " & Tmp & ")") & ""

      If Conc <> "" Then
         Mensaje("Concepto (" & Conc & ") ya utilizado en el período " & Periodo)
         Exit Function
      End If

      If nTotal = 0 Then
         MensajeTrad("Total=0")
         cmdAlta.Focus()
         Exit Function
      End If

      If Val(tbEfectivo.Text) + Val(tbCheques.Text) + Val(txtTransferencia.Text) <> nTotal Then
         MensajeTrad("Ef+Ch+Tr<>Tot")
         tbEfectivo.Focus()
         Exit Function
      End If
      '
      'If Val(tbCheques.Text) > 0 Then
      '   If cbBanco = "" Then
      '      MensajeTrad("DIBanco")
      '      cbDescBco.SetFocus()
      '      Exit Function
      '   ElseIf tbCtaBco = "" Then
      '      MensajeTrad("DICtaBco")
      '      tbCtaBco.SetFocus()
      '      Exit Function
      '   ElseIf tbNroCheque = "" Then
      '      MensajeTrad("DINroCheque")
      '      tbNroCheque.SetFocus()
      '      Exit Function
      '   Else
      '      With rsCart
      '         .Open("SELECT * FROM ChCartera WHERE Banco = " & cbBanco & " AND BancoCta = '" & tbCtaBco & "' AND Numero = '" & tbNroCheque & "'", Cn, adOpenForwardOnly, adLockReadOnly)
      '         '.Seek "=", cbBanco, tbCtaBco, tbNroCheque
      '         If .EOF Then
      '            'Ok.
      '         Else
      '            MensajeTrad("ChYaIng")
      '            tbNroCheque.SetFocus()
      '            .Close()
      '            Exit Function
      '         End If
      '         .Close()
      '      End With
      '   End If
      'End If
      '
      Validar2 = True
      '
   End Function
   '
   Private Sub CaptRecibo(Optional Tr As Object = "")
      tbSucursal.Text = Format(prmSucursal, "0000")
      'BuscarCfg cfgNroRboX, "cfgNroRboX"
      tbNumero.Text = Format(CaptNroRecibo(lblLetra.Text, Val(tbSucursal.Text), Tr), "00000000")
      'tbNumero = Format(nNumero, "00000000")
   End Sub
   '
   Sub ActData()
      '
      'Dim dFecIni As Date
      '
      LlenarGrid(DataGridView1, "SELECT * FROM " & Tmp)
      '
      With DataGridView1
         For Each Col As DataGridViewColumn In .Columns
            With Col
               Select Case UCase(.Name)
                  Case "CONCEPTO" : .Width = 100 : nColCon = .Index
                  Case "FECHA" : .Width = 100 : nColFec = .Index
                  Case "DETALLE" : .Width = 450 : nColDet = .Index
                  Case "DEBE" : .Width = 125
                     With .DefaultCellStyle
                        .Format = "#,##0.00 "
                        .Alignment = DataGridViewContentAlignment.MiddleRight
                     End With
                  Case "HABER" : .Width = 125
                     With .DefaultCellStyle
                        .Format = "#,##0.00 "
                        .Alignment = DataGridViewContentAlignment.MiddleRight
                     End With
                  Case Else
                     .Visible = False
               End Select
            End With
         Next
      End With
      '
      CalcImportes()
      ActivaCtrl(True)
      '
   End Sub
   '
   Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
      Limpiar()
   End Sub
   '
   Private Sub Limpiar()
      Dim Ctrl As Control
      LimpiaTemp()
      For Each Ctrl In Me.Controls
         If TypeOf Ctrl Is TextBox Then
            If Ctrl.Enabled Then
               Ctrl.Text = ""
            End If
         End If
      Next Ctrl
      ActData()
      CalcImportes()
      CaptRecibo()
      ActivaCtrl(False)
   End Sub
   '
   Private Sub cbPropietario_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbProp.SelectedIndexChanged
      '
      Dim Cmd As New OleDb.OleDbCommand
      Dim Drd As OleDb.OleDbDataReader
      '
      lblPropietario.Visible = False

      With cbProp
         If .SelectedIndex > 0 Then
            If Not chkInquilinos.Checked Then
               Propietario = .SelectedValue
               Propiedad = 0
               Nombre = cbProp.Text
            Else
               Propietario = 0
               Propiedad = .SelectedValue
               lblPropietario.Text = CapturaDato(Cn, "Propietarios", "Nombre", "Codigo = (SELECT Propietario FROM Propiedades WHERE Codigo = " & Propiedad & ")")
               lblPropietario.Visible = True
            End If
         End If
      End With
      '
      If cbCliInq.Text = "" Then
         With Cmd
            .Connection = Cn
            .CommandText = "SELECT * FROM Propietarios WHERE Codigo = " & Propietario
            Drd = .ExecuteReader
            With Drd
               If .Read Then
                  tbDomicilio.Text = !Domicilio
                  cbTipoIva.Text = CapturaDato(Cn, "TipoIva", "Descrip", "Codigo = '" & !TipoIva & "'")
                  tbCuit.Text = !Cuit
               End If
               .Close()
            End With
            '
         End With
      End If
      '
   End Sub
   '
   Private Sub chkInquilinos_CheckedChanged(sender As Object, e As EventArgs) Handles chkInquilinos.CheckedChanged
      If chkInquilinos.Checked Then
         chkPropiet.Checked = False
      End If
      ArmaCboCliInqProp()
   End Sub
   '
   Private Sub chkPropiet_CheckedChanged(sender As Object, e As EventArgs) Handles chkPropiet.CheckedChanged
      If chkPropiet.Checked Then
         chkInquilinos.Checked = False
      End If
      ArmaCboCliInqProp()
   End Sub
   '
   'Private Sub tbCheque_Change()
   '   Dim lEnabl As Boolean
   '   If Val(tbCheque) > 0 Then
   '      lEnabl = True
   '   End If
   '   tbFecCheque.Enabled = lEnabl
   '   tbNroCheque.Enabled = lEnabl
   '   cbBanco.Enabled = lEnabl
   '   cbDescBco.Enabled = lEnabl
   '   cbCtaBco.Enabled = lEnabl
   '   'If PagoCobro = 2 Then
   '   tbCtaBco.Enabled = lEnabl
   '   tbTitular.Enabled = lEnabl
   '   'End If
   '   CalcImportes()
   'End Sub
   '
   Private Sub tbCheque_KeyPress(KeyAscii As Integer)
      SoloNumeros(KeyAscii)
   End Sub
   '
   Private Sub tbEfectivo_KeyPress(KeyAscii As Integer)
      SoloNumeros(KeyAscii)
   End Sub
   '
   Private Sub cbBanco_Click()
      'cbDescBco.ListIndex = cbBanco.ListIndex
   End Sub
   '
  Private Sub cmdIngCheques_Click(sender As Object, e As EventArgs) Handles cmdIngCheques.Click
      Dim frm As New frmPagoCh
      With frm
         .Titulo = "Cobro"
         .Cobro = True
         .TablaAct = Tch
         .ShowDialog(Me)
         tbCheques.Text = Format(.Total, "Fixed")
      End With
   End Sub
   '
   Private Sub CalcImportes()
      '
      'nSubTotal = 0
      '
      'With Adodc1.Recordset
      'Do While Not .EOF
      nSubTotal = CapturaDato(Cn, Tmp, "ISNULL( SUM(Debe-Haber), 0)", "")
      '.MoveNext()
      'Loop
      'If .RecordCount > 0 Then .MoveFirst()
      'End With
      '
      If lblLetra.Text = "B" Then
         nTotal = nSubTotal
         nSubTotal = Math.Round(nTotal / (1 + AlicIva1 / 100), 2)
         nIva1 = nTotal - nSubTotal
         nIva2 = 0
      Else
         nIva1 = Math.Round(nSubTotal * AlicIva1 / 100, 2)
         nIva2 = Math.Round(nSubTotal * AlicIva2 / 100, 2)
         nTotal = nSubTotal + nIva1 + nIva2
      End If
      '
      tbTotal.Text = Format(nSubTotal, "Fixed")
      'tbIva1 = Format(nIva1, "Fixed")
      'tbIva2 = Format(nIva2, "Fixed")
      '
   End Sub
   '
   Private Function Guardar() As Boolean
      '
      Dim CobroOtrId As Int32
      Dim Comprob As String
      Dim cDetCaja As String
      Dim cCtaConc As String = ""
      Dim DetAsi As String
      Dim NroAsi As Long
      Dim RenASi As Integer
      Dim Renglon As Byte = 0
      Dim aPropiet As Boolean = False
      '
      Dim nBanco As Long
      Dim cCuenta As String
      Dim cNumero As String
      Dim nTipo As Byte
      Dim cCtaBco As String
      '
      DetAsi = cbCliInq.Text
      '
      If cbProp.SelectedIndex > 0 Then
         If Not chkInquilinos.Checked Then
            aPropiet = True
         End If
      End If
      '
      Trn = Cn.BeginTransaction
      '
      CaptRecibo(Trn)
      '
      GuardarNroRecibo(lblLetra.Text, Val(tbNumero.Text), Trn)
      '
      Comprob = cmpInt & "-" & lblLetra.Text & "-" & Val(tbSucursal.Text) & "-" & Val(tbNumero.Text)
      '
      With Cmd
         .Transaction = Trn
         .CommandText = "INSERT INTO CobrosOtr( Tipo, Sucursal, Numero, Cliente, Propietario, Propiedad, Inquilino, Fecha, Nombre, Domicilio, TipoIva, Cuit, SubTotal, Iva1, Iva2, Total, Efectivo, Cheques, CooTransf, Moneda, Detalle, Caja, Estado, Usuario, FechaMod) " & _
                        "VALUES('" & lblLetra.Text & "', " & _
                                     Val(tbSucursal.Text) & ", " & _
                                     Val(tbNumero.Text) & ", " & _
                                     Cliente & ", " & _
                                     Propietario & ", " & _
                                     Propiedad & ", " & _
                                     Inquilino & ", " & _
                               "'" & Format(Today, FormatFecha) & "', " & _
                               "'" & IIf(cbCliInq.Text = "", cbProp.Text, cbCliInq.Text) & "', " & _
                               "'" & tbDomicilio.Text & "', " & _
                               "'" & TipoIva & "', " & _
                               "'" & tbCuit.Text & "', " & _
                                     nSubTotal & ", " & _
                                     0 & ", " & _
                                     0 & ", " & _
                                     Val(tbTotal.Text) & ", " & _
                                     Val(tbEfectivo.Text) & ", " & _
                                     Val(tbCheques.Text) & ", " & _
                                     Val(txtTransferencia.Text) & ", " & _
                               "'" & "PES" & "', " & _
                               "'" & tbDetalle.Text & "', " & _
                                     prmNroCaja & ", " & _
                                     0 & ", " & _
                               "'" & Uid & "', " & _
                               "'" & Format(Now, FormatFechaHora) & "')"
         '
         '"'" & tbCtaBanco.Text & "', " & _
         '"'" & tbNroCheque.Text & "', " & _
         '"'" & Format(tbFecCheque.Value, FormatFecha) & "', " & _
         '
         .ExecuteNonQuery()
         '
         CobroOtrId = CapturaDato(Cn, "CobrosOtr", "MAX(CobroOtrId)", "", , , , Trn)
         '
      End With
      '
      If SisContable Then
         NroAsi = GuardaAsiento(Comprob, Today, DetAsi, Trn)
         If NroAsi = 0 Then
            Err.Raise(1001, , Traducir("NoUpAsiento"))
         End If
      End If
      '
      If Val(tbEfectivo.Text) > 0 Then
         '
         If tbDetalle.Text = "" Then
            cDetCaja = "Cobro en Efectivo"
         Else
            cDetCaja = Strings.Left(tbDetalle.Text, 250)
         End If
         '
         If Not ActCaja(prmNroCaja, Comprob, "EF", Today, Nombre, "", cDetCaja, tbEfectivo.Text, 0, , Trn) Then
            Err.Raise(1001)
         End If
         '
         If SisContable Then
            RenASi = RenASi + 1
            If Not GuardaAsienDet(NroAsi, RenASi, cCtaCajaAd, DetAsi, tbEfectivo.Text, 0, Trn) Then
               Err.Raise(1001, , Traducir("NoUpAsiento"))
            End If
         End If
         '
      End If
      '
      Try
         Cm2.Connection = Cn
         Cm2.Transaction = Trn
         '
         If Val(tbCheques.Text) > 0 Then
            '
            With Cmd
               '
               .CommandText = "INSERT INTO CobrosOtrCh( CobroOtrId, Origen, Banco, CuentaBco, Numero, CrdUsuario, CrdFecMod) " &
                              "SELECT " & CobroOtrId & ", 'C', Banco, Cuenta, Numero, '" & Uid & "', '" & Format(Now, FormatFechaHora) & "' " &
                              "FROM " & Tch
               .ExecuteNonQuery()
               '
               .CommandText = "SELECT * FROM " & Tch
               Drd = .ExecuteReader
               '
            End With
            '
            With Drd
               '
               If .Read Then
                  '
                  cDetCaja = "CH." & !Banco & " Nº" & !Numero & " Al:" & !Fecha
                  '
                  If Not ActCaja(prmNroCaja, Comprob, "CH", Today, Nombre, "", cDetCaja, !Importe, 0, , Trn) Then
                     Err.Raise(1001)
                  End If
                  '
                  If SisContable Then
                     RenASi = RenASi + 1
                     If Not GuardaAsienDet(NroAsi, RenASi, cCtaVCar3, DetAsi, !Importe, 0, Trn) Then
                        Err.Raise(1001, , Traducir("NoUpAsiento"))
                     End If
                  End If
                  '
                  Cm2.CommandText = "INSERT INTO ChCartera( Banco, BancoCta, ChCartNro, Titular, FechaEmi, FechaDif, Importe, Detalle, Estado, Caja, Comprob, Entrego, Usuario, FechaMod) " &
                                    "VALUES(" & !Banco & ", " &
                                          "'" & !Cuenta & "', " &
                                          "'" & !Numero & "', " &
                                          "'" & !Titular & "', " &
                                          "'" & Format(Today, FormatFecha) & "', " &
                                          "'" & Format(!Fecha, FormatFecha) & "', " &
                                                !Importe & ", " &
                                          "'" & tbDetalle.Text & "', " &
                                                0 & ", " &
                                                prmNroCaja & ", " &
                                          "'" & Comprob & "', " &
                                          "'" & cbCliInq.Text & "', " &
                                          "'" & Uid & "', " &
                                          "'" & Format(Now, FormatFechaHora) & "')"
                  Cm2.ExecuteNonQuery()
                  '
               Else
                  '
                  Err.Raise(1001)
                  '
               End If
               '
               .Close()
               '
            End With
            '
         End If
         '
         If Val(txtTransferencia.Text) > 0 Then
            With Cmd
               '
               .CommandText = "INSERT INTO CobrosOtrTR( CobroOtrID, Banco0, Cuenta0, Titular0, Banco1, Cuenta1, FechaTR, NumeroTR, ImporteTR, Usuario, FechaMod) " &
                              "SELECT " & CobroOtrId & ", Banco0, Cuenta0, Titular, Banco1, Cuenta1, FechaTR, NumeroTR, ImporteTR, '" & Uid & "', '" & Format(Now, FormatFechaHora) & "' " &
                              "FROM " & tTR
               .ExecuteNonQuery()
               '
               'LiqInqTrID = CapturaDato(Cn, "LiqInqTR", "ISNULL(MAX(LiqInqTrID), 0)", "", , , , Trn)
               nBanco = CapturaDato(Cn, "CobrosOtrTR", "Banco1", "CobroOtrId = " & CobroOtrId, , , , Trn)
               cCuenta = CapturaDato(Cn, "CobrosOtrTR", "Cuenta1", "CobroOtrId = " & CobroOtrId, , , , Trn) & ""
               cNumero = CapturaDato(Cn, "CobrosOtrTR", "NumeroTR", "CobroOtrId = " & CobroOtrId, , , , Trn) & ""
               nTipo = CapturaDato(Cn, "TipoMovBco", "TipoMovBco", "TipoMov = 'TR'", , , , Trn)
               '
               If nTipo = 0 Then
                  Err.Raise(1001, , "Tipo de Mov. Transferencia no Definida")
               End If
               '
               '.CommandText = "UPDATE LiqInqCab SET LiqInqTrID = " & LiqInqTrID & " " & _
               '               "WHERE Tipo = '" & lblLetra.Text & "'" & _
               '               "  AND Sucursal = " & Val(tbSucursal.Text) & _
               '               "  AND Numero = " & Val(tbNumero.Text)
               '.ExecuteNonQuery()
               '
               If SisContable Then
                  cCtaBco = CapturaDato(Cn, "BancoCta", "CtaCont", "Banco = " & nBanco & " AND BancoCta = '" & cCuenta & "'", , , , Trn)
               End If
               '
               .CommandText = "INSERT INTO BancosMov( Banco, BancoCta, TipoMovBco, NroMovBco, FechaEmi, FechaAcr, Debe, Haber, Estado, HojaBco, Detalle, Caja, Usuario, FechaMod) " &
                              "VALUES(" & nBanco & ", " &
                                    "'" & cCuenta & "', " &
                                          nTipo & ", " &
                                    "'" & cNumero & "', " &
                                    "'" & Format(Today, FormatFecha) & "', " &
                                    "'" & Format(Today, FormatFecha) & "', " &
                                          txtTransferencia.Text & ", " &
                                          0 & ", " &
                                          0 & ", " &
                                          0 & ", " &
                                    "'" & Strings.Left("Cobro Otr. " & cbCliInq.Text, 50) & "', " &
                                          prmNroCaja & ", " &
                                    "'" & Uid & "', " &
                                    "'" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
               '
            End With
         End If
         '
         With Cmd
            .CommandText = "SELECT * FROM " & Tmp
            Drd = .ExecuteReader
         End With
         '
         With Drd
            Do While .Read
               '
               Cm2.CommandText = "INSERT INTO CobOtrDet( Tipo, Sucursal, Numero, Renglon, Concepto, Fecha, Detalle, Importe, Imputacion, aPropiet, Usuario, FechaMod) " &
                                 "VALUES('" & lblLetra.Text & "', " &
                                              tbSucursal.Text & ", " &
                                              tbNumero.Text & ", " &
                                              !Renglon & ", " &
                                        "'" & !Concepto & "', " &
                                        "'" & Format(!Fecha, FormatFecha) & "', " &
                                        "'" & !Detalle & "', " &
                                              !Debe + !Haber & ", " &
                                        "'" & IIf(!Debe > 0, "D", "H") & "', " &
                                              IIf(aPropiet, 1, 0) & ", " &
                                        "'" & Uid & "', " &
                                        "'" & Format(Now, FormatFechaHora) & "')"
               Cm2.ExecuteNonQuery()
               '
               If SisContable Then
                  '
                  If Not CaptCtasConc(!Concepto, "", "", cCtaConc) Then
                     Err.Raise(1001, , "NoCaptCta")
                  End If
                  '
                  RenASi = RenASi + 1
                  If Not GuardaAsienDet(NroAsi, RenASi, cCtaConc, DetAsi, !Haber, !Debe) Then
                     Err.Raise(1001, , Traducir("NoUpAsiento"))
                  End If
               End If
               '
               If chkInquilinos.Checked Then
                  '
                  Dim TipoNro As String = lblLetra.Text & "-" & tbSucursal.Text & "-" & tbNumero.Text
                  '
                  Cm2.CommandText = "INSERT INTO FactInq( Periodo, Propiedad, Inquilino, Concepto, Fecha, Detalle, Importe, Saldo, Imputacion, Automatico, aPropiet, MesPago, Propietario, Liquidado, TipoNroRbo, Usuario, FechaMod) " &
                                    "VALUES('" & Periodo & "', " &
                                                 Propiedad & ", " &
                                                 Inquilino & ", " &
                                           "'" & !Concepto & "', " &
                                           "'" & Format(!Fecha, FormatFecha) & "', " &
                                           "'" & !Detalle & "', " &
                                                 !Debe + !Haber & ", " &
                                                 0 & ", " &
                                           "'" & IIf(!Debe > 0, "H", "D") & "', " &
                                                 1 & ", " &
                                                 0 & ", " &
                                                 0 & ", " &
                                                 0 & ", " &
                                                 1 & ", " &
                                           "'" & TipoNro & "', " &
                                           "'" & Uid & "', " &
                                           "'" & Format(Now, FormatFechaHora) & "')"
                  Cm2.ExecuteNonQuery()
               End If
               '
            Loop
            .Close()
         End With
         '
         GuardarAudit("Cobro Otros", Comprob & ", " & cbCliInq.Text, "Cobros Otros", "Guardar", Trn)
         '
         Trn.Commit()
         '
         Return True
         '
      Catch
         Dim st As New StackTrace(True)
         MensageError(st, "frmCobrosOtr", Err.Description)
      End Try
      '
   End Function
   '
   Private Sub LimpiaTemp()
      '
      Trn = Cn.BeginTransaction
      '
      With Cmd
         .Transaction = Trn
         .CommandText = "DELETE FROM " & Tmp
         .ExecuteNonQuery()
         '
         .CommandText = "DELETE FROM " & Tch
         .ExecuteNonQuery()
         '
      End With
      '
      Trn.Commit()
      '
   End Sub
   '
   Private Sub cmdTransferencia_Click(sender As Object, e As EventArgs) Handles cmdTransferencia.Click
      Dim frm As New frmLiqTransf
      With frm
         .TransfRec = True
         .TablaTmp = tTR
         .ShowDialog(Me)
         txtTransferencia.Text = Format(.Total, "Fixed")
      End With
   End Sub
   '
   Private Sub cmdSalir_Click(sender As Object, e As EventArgs) Handles cmdSalir.Click
      Me.Close()
   End Sub
   '
   Private Sub Form_Unload(Cancel As Integer)
      EliminaTmp(Cn, Tmp)
      SetRegForm(Me)
   End Sub
   '
End Class