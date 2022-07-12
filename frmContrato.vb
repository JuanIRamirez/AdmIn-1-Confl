Public Class frmContrato
   '
   Public Escalon As Integer
   Public IncrPorc As Double
   Public MesesEsc As Integer
   '
   Dim Trn As OleDb.OleDbTransaction
   ReadOnly Cnx As New OleDb.OleDbConnection
   ReadOnly Cmd As New OleDb.OleDbCommand
   ReadOnly Drd As OleDb.OleDbDataReader
   '
   Dim vAutoriza As Boolean
   '
   Dim Propietario As Long
   Dim Propiedad As Long
   Dim Inquilino As Long
   Dim GaranteId As Int32
   Dim vCamposVacios As String
   '
   Dim DescAlq As String
   Dim DescSel As String
   Dim DescMdp As String
   Dim DescHna As String
   Dim DescIDf1 As String
   'Dim DescIDf2 As String
   Dim DescIva As String
   '
   Dim DomLocador As String
   Dim LocLocador As String
   Dim DomLocatar As String
   Dim LocLocatar As String
   'Dim DomGarante As String
   'Dim LocGarante As String
   '
   Dim vSelladoInq As Double
   Dim vSelladoPro As Double
   Dim vPorSellInq As Single
   Dim vPorSellPro As Single
   Dim AlicIva1 As Single
   Dim AlicIva2 As Single
   Dim UltPerCtto As String
   Dim MinFecCtto As Date
   '
   Dim cTIvaInq As String
   Dim cCuitInq As String
   Dim cLetraFact As String
   '
   Dim vTipoalq As String
   ReadOnly nAnchoArch As Integer
   '
   Dim cCtaPro As String
   Dim cCtaInq As String
   Dim cCtaHna As String
   Dim cCtaIDF1 As String
   Dim cCtaIDF2 As String
   Dim cCtaCaja As String
   '
   Dim cFechaDesde As String
   Dim cFechaHasta As String
   '
   'Dim i As Integer
   Dim CaptCtas As Boolean
   Dim CaptVrs As Boolean
   Dim cTmp As String
   Dim FormLoad As Boolean = False
   '
   Const vEstado = 0
   Const cmpInt = "CT"
   Const cStruct = "Mes SMALLINT NOT NULL, FechaVenc SMALLDATETIME NOT NULL, Importe FLOAT NOT NULL, Iva FLOAT NOT NULL, Porcent REAL"
   '
   Private Sub frmContrato_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      '
      GetRegForm(Me)
      '
      TraducirForm(Me)
      '
      ssTab1.SelectedIndex = 0
      '
      cTmp = ""
      If Not CrearTabla(Cn, cStruct, cTmp) Then
         DeshabForm(Me)
      End If
      '
      If FechaIncorrecta() Then
         DeshabForm(Me)
      End If
      '
      Cmd.Connection = Cn
      '
      Limpiacampos()
      LlenaCombos()
      CargaVariables()
      '
      If CaptCtasConc(cfgCodigoAlq, DescAlq, "", "") Then
         If CaptCtasConc(cfgCodigoSel, DescSel, "", "") Then
            If CaptCtasConc(cfgCodigoMdp, DescMdp, "", "") Then
               If CaptCtasConc(cfgCodigoIva, DescIva, "", "") Then
                  If CaptCtasConc(cfgCodigoHnA, DescHna, cCtaHna, "") Then
                     If CaptCtasConc(cfgCodigoIDf1, DescIDf1, cCtaIDF1, "") Then
                        'If CaptCtasConc(cfgCodigoIDf2, DescIDf2, cCtaIDF2, "") Then
                        If SisContable Then
                           If CaptCtasCaja(prmNroCaja, cCtaCaja, "") Then
                              CaptCtas = True
                           End If
                        Else
                           CaptCtas = True
                        End If
                     End If
                  End If
               End If
            End If
         End If
      End If
      '
      If Not CaptCtas Then DeshabForm(Me)
      '
      'If UCase(Sistema) <> "RSISQL2" Then
      'If AbrirCnx(Cnx, "RsiSql2") Then
      '   Me.lblNomInq.BackColor = &H80000010
      'End If
      'End If
      '
      FormLoad = True
      '
      '*** frmMenu.StatusBar1.Panels(1) = "FrmContrato_Load: OK"
      '
   End Sub
   '
   Private Sub frmContrato_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
      TabReturn(e.KeyChar)
   End Sub
   '
   Private Sub cmdImpuestos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImpuestos.Click
      CargaImpuestos()
   End Sub
   '
   Private Sub cmdAnterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAnterior.Click
      ssTab1.SelectedIndex = 0
   End Sub
   '
   Private Sub cmdAnterior2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAnterior2.Click
      ssTab1.SelectedIndex = 1
   End Sub
   '
   'Private Sub cboConsorcio_Click()
   '   If cboConsorcio.ListIndex > -1 Then
   '      With rsCons
   '         .Open("SELECT * FROM Consorcios WHERE Descrip = '" & cboConsorcio & "'", Cn, adOpenForwardOnly, adLockReadOnly)
   '         If .EOF Then
   '            MensajeTrad("ConsNoEnc")
   '         Else
   '            tbDomCons = !Domicilio
   '         End If
   '         .Close()
   '      End With
   '   End If
   'End Sub
   '
   'Private Sub cbNomPropiet_Change()
   '   PintarCb(cbNomPropiet, LastKey)
   'End Sub
   '
   Private Sub cbPropietario_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbPropietario.SelectedIndexChanged
      '
      If Not formload Then Exit Sub
      '
      Dim Rs As New OleDb.OleDbCommand
      Dim Dr As OleDb.OleDbDataReader
      '
      With cbPropietario
         If .SelectedIndex > 0 Then
            Propietario = .SelectedValue
         Else
            Propietario = 0
            Exit Sub
         End If
      End With

      With Rs
         .Connection = Cn
         .CommandText = "SELECT * FROM Propietarios WHERE Codigo = '" & Propietario & "'"
         Dr = .ExecuteReader
      End With
      '
      With Dr
         If .Read Then
            Propietario = !Codigo
            tbDniPrt.Text = Format(!DNI, "###,###,###")
            DomLocador = !Domicilio
            tbDomicilioPrt.Text = !Domicilio
            PosCboItem(cbLocalidadPrt, Val(!Localidad))
            If IsDBNull(!Cuenta) Then
               MensajeTrad("PropSinCuenta")
               cbPropietario.SelectedIndex = -1
               Exit Sub
            Else
               cCtaPro = IIf(cfgCtaPrtUnica, cfgCtaMadrePrt, !Cuenta)
            End If
            LocLocador = CapturaDato(Cn, "Localidad", "Descrip", "Codigo = '" & Val(!Localidad & "") & "'")
            ArmaCboPrd()
         Else
            MensajeTrad("PropietNoExist")
         End If
         .Close()
      End With
      '
   End Sub
   '
   Private Sub cbPropiedad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbPropiedad.SelectedIndexChanged
      '
      If Not formload Then Exit Sub
      '
      Dim Rs As New OleDb.OleDbCommand
      Dim Dr As OleDb.OleDbDataReader
      '
      With cbPropiedad
         If .SelectedIndex > 0 Then
            Propiedad = .SelectedValue
         Else
            Propiedad = 0
            Exit Sub
         End If
      End With
      '
      With Rs
         .Connection = Cn
         .CommandText = "SELECT * FROM Propiedades WHERE Codigo = " & Propiedad
         Dr = .ExecuteReader
      End With
      '
      With Dr
         If .Read Then
            If Val(!Inquilino & "") > 0 Then
               MensajeTrad("PropiedAlq")
               cbPropiedad.SelectedIndex = -1
               cmdImpuestos.Enabled = False
            Else
               UltPerCtto = "200012"
               'With rsFInq
               '.Open("SELECT * FROM FactInq WHERE Propiedad = " & Propiedad, Cn, adOpenForwardOnly, adLockReadOnly)
               'If .EOF Then
               ''Ok. No tiene Facturación.
               'Else
               'Do While !Propiedad = Propiedad
               'If !Periodo > UltPerCtto Then
               'UltPerCtto = !Periodo
               UltPerCtto = CapturaDato(Cn, "FactInq", "TOP 1 Periodo", "Propiedad = " & Propiedad, , , "Periodo DESC")
               'End If
               '.MoveNext()
               'If .EOF Then Exit Do
               'Loop
               If IsNothing(UltPerCtto) Then
                  UltPerCtto = "200012"
               End If
               MinFecCtto = SumaMes("01/" & UltPerCtto.Substring(4, 2) & "/" & UltPerCtto.Substring(0, 4), 1)
               'tdomPropiedad = "Barrio " & Trim(!Barrio) & ", " & Trim(!Domicilio)
               tbComodid.Text = !Descripcion & ""
               tbImpAlq.Text = Format(!Valor, "Fixed")
               txtLocPrd.Text = !Localidad
               vTipoalq = !TipoAlq
               If !TipoAlq = "P" Then
                  tbMeses.Text = cfgMesesAlqP
                  optParticular.Checked = True
               Else
                  tbMeses.Text = cfgMesesAlqC
                  optComercial.Checked = True
               End If
               txtTipo.Text = CapturaDato(Cn, "TipoProp", "Descrip", "Codigo = '" & !Tipo & "'")
               '
               cmdImpuestos.Enabled = TienePermiso(Cn, Uid, frmMenu.mConceptos.Name)
            End If
         Else
            cmdImpuestos.Enabled = False
         End If
         .Close()
      End With
      '
   End Sub
   '
   Private Sub chkMesDep_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMesDep.CheckedChanged
      CalcTotCtto()
      CalcImportes()
      tbImpDep.Enabled = chkMesDep.Checked
   End Sub
   '
   Private Sub chkSellado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSellado.CheckedChanged
      chkSellProp.Enabled = chkSellado.Checked
      chkSellInq.Enabled = chkSellado.Checked
      chkSellCG.Enabled = chkSellado.Checked
      CalcImportes()
   End Sub
   '
   Private Sub chkSellCG_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSellCG.CheckedChanged
      CalcImportes()
   End Sub
   '
   Private Sub chkSellInq_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSellInq.CheckedChanged
      TradPorcSell()
   End Sub
   '
   Private Sub chkSellProp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSellProp.CheckedChanged
      TradPorcSell()
   End Sub
   '
   Private Sub TradPorcSell()
      If chkSellProp.Checked Then
         If chkSellInq.Checked Then
            vPorSellPro = 50
            vPorSellInq = 50
         Else
            vPorSellPro = 100
            vPorSellInq = 0
         End If
      Else
         If chkSellInq.Checked Then
            vPorSellPro = 0
            vPorSellInq = 100
         Else
            chkSellInq.Checked = True
         End If
      End If
      chkSellProp.Text = Traducir("Propietario") & " " & vPorSellPro & "%"
      chkSellInq.Text = Traducir("Inquilino") & " " & vPorSellInq & "%"
      CalcImportes()
   End Sub
   '
   Private Sub cmdImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImprimir.Click
      '
      If IsNothing(CapturaDato(Cn, "Contratos", "Numero", "Numero = " & tbNroCtto.Text)) Then
         Mensaje("Debe guardar el contrato")
      Else
         'GenRepContrato(Val(tbNroCtto.Text), "Contrato")
         If Dir(tbContrato.Text) <> "" Then
            AbrirDocWord(tbContrato.Text)
         End If
         If Dir(tbConvenio.Text) <> "" Then
            AbrirDocWord(tbConvenio.Text)
         End If
      End If
      '
   End Sub
   '
   Private Sub cmdGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGenerar.Click
      '
      If VerificaCampos() Then
         '
         EditaContrato(IIf(optLocacion.Checked, "CttoLoc.txt", "CttoTmp.txt"), tbContrato)
         '
         If chkConvDesocup.Checked Then
            EditaContrato("ConvDes.txt", tbConvenio)
            tbConvenio.Enabled = True
         Else
            tbConvenio.Text = ""
            tbConvenio.Enabled = False
         End If
         '
         GenWordDoc(IIf(optLocacion.Checked, "CttoLoc", "CttoTmp"), tbContrato)
         '
         If chkConvDesocup.Checked Then
            GenWordDoc("ConvDes", tbConvenio)
            tbConvenio.Enabled = True
         End If
         '
         cmdGenerar.Enabled = False
         '
      End If
   End Sub
   '
   Private Sub CargaImpuestos()
      Dim Frm As New frmPropConc
      With frm
         .NuevoCtto = True
         .Propiedad = Propiedad
         .Propietario = Propietario
         .ShowDialog(Me)
      End With
   End Sub
   '
   Private Sub EditaContrato(ByVal Archivo As String, ByVal Tb As TextBox)
      '
      cFechaDesde = dtpDesde.Value.Day & " de " & MonthName(dtpDesde.Value.Month, False) & " de " & dtpDesde.Value.Year
      cFechaHasta = dtpHasta.Value.Day & " de " & MonthName(dtpHasta.Value.Month, False) & " de " & dtpHasta.Value.Year
      '
      ActTextMarc()
      '
      Archivo = RPT & "\" & Archivo
      '
      Tb.Text = ""
      '   Screen.MousePointer = 0
      Exit Sub   'Porque genera .Doc'
      '
      'Open Archivo For Input As #1
      '      '
      '   Line Input #1, vCadena
      '      nAnchoArch = Len(vCadena)
      '      vCadena = ""
      '      '
      '      While Not EOF(1)
      '      Line Input #1, vCadena
      '         '
      '         For i = 0 To nMarcadores - 1
      '            If i = 0 Then
      '               vCadena = ReemplCadena(vCadena, "%NUMEROCTTO%", tbNroCtto)
      '            Else
      '               ReemplTexto(vCadena, "%" & Marcador(i) & "%", TextMarc(i))
      '            End If
      '         Next i
      '         '
      '         Tb = Tb & vCadena & vbCrLf
      '         '
      '      End While
      '      '
      '      Close()
      '      '
      '      Screen.MousePointer = vbDefault
      '
   End Sub
   '
   Private Sub GenWordDoc(ByVal Doc As String, ByVal Tb As TextBox)
      '
      Dim aDoc As Object
      Dim Documento As Object
      Documento = CreateObject("Word.Application")
      '
      Dim DocOrig As String
      Dim NuevoDoc As String
      Dim nCont As Integer
      Dim i As Int16
      '
      Try
         With Documento
            '
            'Abre el documento.
            DocOrig = cfgUbicDocs & "\" & Doc & ".Doc"
            '
            aDoc = Documento.Documents.Open(DocOrig, , , , , , , , , , True)
            '
            'Relleno de marcadores
            For i = 1 To nMarcadores
               Debug.Print(Marcador(i) & ": " & TextMarc(i))
               If .ActiveDocument.Bookmarks.Exists(Marcador(i)) = True Then
                  .ActiveDocument.Bookmarks.Item(Marcador(i)).Range.Text = TextMarc(i)
               End If
            Next i
            '
            'Final del documento.
            .Application.Selection.HomeKey()
            '
            'Abre MS-Word.
            .WindowState = 2   'wdWindowStateMaximize
            .Application.Visible = True
            NuevoDoc = cfgUbicDocs & "\" & Doc & "-" & cbPropietario.Text & "-" & cbInquilino.Text
            Do While Dir(NuevoDoc & ".Doc") <> ""
               nCont = nCont + 1
               NuevoDoc = NuevoDoc & "_" & nCont
            Loop
            NuevoDoc = NuevoDoc & ".Doc"
            .ActiveDocument.SaveAs(NuevoDoc)
            Tb.Text = NuevoDoc
            '
         End With
         '
         Documento = Nothing
         '
      Catch ex As Exception
         Dim st As New StackTrace(True)
         MensageError(st, "frmContrato.GenWordDoc")
      End Try
      '
   End Sub
   '
   'Private Sub ReemplTexto(ByVal Texto As String, ByVal Clave As String, ByVal Valor As Object, Optional ByVal Caract = "-")
   '   '
   '   Dim nPos As Integer
   '   '
   '   nPos = InStr(Texto, Clave)
   '   '
   '   If nPos > 0 Then
   '   vCadena = CompletaCadena(ReemplCadena(Texto, Clave, Valor), _
   '                            nAnchoArch, Char)
   '      vCadena = ReemplCadena(Texto, Clave, Valor)
   '   End If
   '   '
   'End Sub
   '
   Private Sub cmdGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGuardar.Click
      '
      Dim guardarOK As Boolean = True
      '
      If SuperaRegistros("Contratos") Then
         Exit Sub
      End If
      '
      If Not VerificaCampos() Then
         Exit Sub
      End If
      '
      If tbContrato.Text = "" Or vAutoriza = False Then
         guardarOK = MsgConfirma("Contrato no generado, guarda de todas formas")
      End If
      '
      If guardarOK Then
         '
         If MsgConfirma("Carga impuestos/Gastos") Then
            CargaImpuestos()
         End If
         '
         If Guardar() Then
            '
            cmdGenerar.Enabled = False
            cmdGuardar.Enabled = False
            '
            If Cnx.State = 1 Then
               If varOkInq2 Then
                  If MsgBox("Carga Honorarios", vbQuestion + vbYesNo) = vbYes Then
                     With frmFactInqAM
                        '.Cnx = Cnx
                        .aPropiet = False
                        .Periodo = CalcPeriodo(dtpDesde.Value, 1)
                        .Propiedad = 0
                        .Inquilino = Inquilino
                        .Concepto = cfgCodigoHnA
                        .ShowDialog(Me)
                     End With
                  End If
               End If
            End If
            '
            If chkConvDesocup.Checked Then
               'GenRepConvenio tbNroCtto, Traducir("Convenio"), CrystalReport1
            End If
            If Val(tbHonAdm.Text) > 0 Then
               If Not CaptVrs Then
                  CaptNroFact()
                  If cfgGenFactCom Then
                     GenRepFact(cLetraFact, Val(tbSucursal.Text), Val(tbNroFact.Text), Traducir("Factura"), 0)
                  End If
               End If
            End If
            '
            MensajeTrad("Contrato Nº " & tbNroCtto.Text & ", Generado y Guardado")
            '
            Me.Close()
            '
         End If
      End If
      '
   End Sub
   '
   Private Sub cmdSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSiguiente.Click
      ssTab1.SelectedIndex = 1
      tbInventario.Focus()
   End Sub
   '
   Private Sub cmdSiguiente2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSiguiente2.Click
      ssTab1.SelectedIndex = 2
      If cmdGenerar.Enabled Then
         cmdGenerar.Focus()
      End If
   End Sub
   '
   Private Sub dtpDesde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDesde.ValueChanged
      If dtpDesde.Value < MinFecCtto Then
         If MsgConfirma("Propiedad C/Facturación en la Fecha Ingresada, Continúa ?") Then
            '*** OK.-
         Else
            dtpDesde.Value = MinFecCtto
         End If
      End If
      If Val(tbMeses.Text) > 0 Then
         dtpHasta.Value = SumaMes(dtpDesde.Value, Val(tbMeses.Text)).AddDays(-1)
      Else
         dtpHasta.Value = dtpDesde.Value
      End If
      Ins_Tmp()
   End Sub
   '
   Private Sub dtFechaCtto_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtFechaCtto.ValueChanged
      'On Error Resume Next
      dtpDesde.Value = dtFechaCtto.Value
      'dtpDesde_Change()
   End Sub
   '
   'Private Sub dtpHasta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpHasta.ValueChanged
   '   CalculoFecha()
   '   If dtpHasta.Value < dtpDesde.Value Then
   '      Mensaje("La fecha de fin de contrato no puede ser menor al la de inicio")
   '      dtpHasta.Value = dtpDesde.Value.AddDays((365 * 2) - 1)
   '   End If
   'End Sub
   '
   'Private Sub TamañoFormulario()
   '   Me.WindowState = 0
   '   Me.Top = 0
   '   Me.Left = 0
   'End Sub
   '
   Private Sub CargaVariables()
      '
      'frmMenu.StatusBar1.Panels(1) = "CargaVariables"
      '
      tbNroCtto.Text = Val(cfgNContrato) + 1
      '
      Do While Not IsNothing(CapturaDato(Cn, "Contratos", "Numero", "Numero = " & Val(tbNroCtto.Text)))
         tbNroCtto.Text = Val(tbNroCtto.Text) + 1
      Loop
      '
      dtFechaCtto.Value = Today
      dtpDesde.Value = Today
      dtpHasta.Value = Today.AddDays((365 * 2) - 1)
      If dtpDesde.Value < dtpHasta.Value Then
         tbMeses.Text = DateDiff(DateInterval.Month, dtpDesde.Value, dtpHasta.Value)
      End If
      vPorSellInq = 50
      vPorSellPro = 50
      'cboConsorcio.Enabled = False
      vAutoriza = False
      '
      'frmMenu.StatusBar1.Panels(1) = "CargaVariables: OK"
      '
   End Sub
   '
   Private Sub ActTextMarc()
      '
      DefMarcadores()
      '
      TextMarc(1) = tbNroCtto.Text
      '
      TextMarc(2) = cbPropietario.Text
      TextMarc(3) = tbDniPrt.Text
      TextMarc(4) = DomLocador
      TextMarc(5) = LocLocador
      '
      TextMarc(6) = cbInquilino.Text
      TextMarc(7) = txtDniInq.Text
      TextMarc(8) = DomLocatar
      TextMarc(9) = LocLocatar
      '
      TextMarc(10) = "un/a " & txtTipo.Text
      TextMarc(11) = cbPropiedad.Text
      TextMarc(12) = txtLocPrd.Text
      TextMarc(13) = tbComodid.Text
      TextMarc(14) = Traducir(IIf(optParticular.Checked, "DestParticular", "DestLocalCom"))
      '
      TextMarc(15) = tbMeses.Text
      TextMarc(16) = Numero_a_Texto(tbMeses.Text, , False)
      TextMarc(17) = tbAños.Text
      TextMarc(18) = Numero_a_Texto(tbAños.Text, , False)
      TextMarc(19) = dtpDesde.Value
      TextMarc(20) = cFechaDesde
      TextMarc(21) = dtpHasta.Value
      TextMarc(22) = cFechaHasta
      TextMarc(23) = tbDiaVenc.Text
      '
      TextMarc(24) = tbSonPesos.Text
      TextMarc(25) = tbImpAlq.Text
      If cfgCotDollar = 0 Then
         cfgCotDollar = 1
      End If
      TextMarc(26) = Numero_a_Texto(Val(tbImpAlq.Text) / cfgCotDollar, , True)
      TextMarc(27) = Format(Val(tbImpAlq.Text) / cfgCotDollar, "Fixed")
      '
      TextMarc(28) = cfgNomEmp
      TextMarc(29) = cfgDomEmp
      TextMarc(30) = cfgLocEmp
      '
      TextMarc(31) = cbGarante.Text
      TextMarc(32) = txtDniGte.Text
      TextMarc(33) = tbDomGte.Text
      TextMarc(34) = cbLocGte.Text
      '
      TextMarc(35) = Numero_a_Texto(tbImpDep.Text)
      TextMarc(36) = tbImpDep.Text
      TextMarc(37) = vPorSellInq
      TextMarc(38) = vPorSellPro
      '
      TextMarc(39) = tbInventario.Text
      TextMarc(40) = ""   'cboConsorcio
      '
      TextMarc(41) = dtFechaCtto.Value.Day
      TextMarc(42) = Numero_a_Texto(dtFechaCtto.Value.Day, , False)
      TextMarc(43) = MonthName(dtFechaCtto.Value.Month)
      TextMarc(44) = dtFechaCtto.Value.Year
      '
      TextMarc(45) = cfgCotDollar
      '
      TextMarc(46) = Traducir(IIf(optParticular.Checked, "DestParticular", "DestLocalCom"))
      TextMarc(47) = cbPropiedad.Text
      TextMarc(48) = txtLocPrd.Text
      '
   End Sub
   '
   'Private Sub lblHonAdm_Click()
   '   With lblPesos
   '      If .BackColor.ToString = "&H8000000F" Then
   '         If cfgCtaVrs1 = "" Or cfgCtaVrs2 = "" Then
   '            MsgBox("Cuenta/s Servicios Varios no definida/s", vbInformation)
   '         Else
   '            .BackColor = Color.FromKnownColor(&H80000010)
   '            CaptVrs = True
   '         End If
   '      Else
   '         .BackColor = Color.FromKnownColor(&H8000000F)
   '         CaptVrs = False
   '      End If
   '   End With
   '   optContado.Enabled = Not CaptVrs
   '   optCtaCte.Enabled = Not CaptVrs
   '   IvaDbF()
   'End Sub
   '
   Private Sub optDepart_Click()
      'If optDepart.Value = True Then
      'cboConsorcio.Enabled = True
      'cboConsorcio.SetFocus()
      'End If
   End Sub
   '
   Private Sub Option2_Click()
      'cboConsorcio.ListIndex = -1
      'cboConsorcio.Enabled = False
      'tbDomCons.Enabled = False
      'tbDomCons = ""
   End Sub
   '
   Private Sub optParticular_CheckedChanged_1(sender As Object, e As EventArgs) Handles optParticular.CheckedChanged, optComercial.CheckedChanged
      'chkIvaAlq.Checked = False
      If optParticular.Checked Then
         vTipoalq = "P"
         tbMeses.Text = cfgMesesAlqP
      Else
         vTipoalq = "C"
         tbMeses.Text = cfgMesesAlqC
      End If
      HabDesIvaAlq()
      CalcImportes()
   End Sub
   '
   Private Sub tbHonAdm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbHonAdm.TextChanged
      IvaDbF()
   End Sub
   '
   Private Sub tbHonAdm_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbHonAdm.KeyPress
      SoloNumeros(e.KeyChar, True)
   End Sub
   '
   Private Sub tbImpDep_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbImpDep.TextChanged
      CalcTotCtto()
      CalcImportes()
   End Sub
   '
   Private Sub chkIvaAlq_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIvaAlq.CheckedChanged
      '
      CalcIvaAlq()
      CalcTotCtto()
      CalcImportes()
      '
   End Sub
   '
   Private Sub CalcIvaAlq()
      If Val(tbImpAlq.Text) > cfgMaxAlqSIva Then
         If chkIvaAlq.Checked Then
            tbIvaAlq.Text = Math.Round(Val(tbImpAlq.Text) * (AlicIva1 + AlicIva2) / 100, 2)
         Else
            tbIvaAlq.Text = 0
         End If
      End If
   End Sub
   '
   Private Sub tbImpSell_Change()
      Sellado()
      TotAPagar()
   End Sub
   '
   Private Sub tbImpSell_KeyPress(ByVal KeyAscii As Integer)
      SoloNumeros(KeyAscii, True)
   End Sub
   '
   Private Sub tbImpSell_LostFocus()
      tbImpSell.Text = Format(tbImpSell.Text, "Fixed")
   End Sub
   '
   Private Sub tbIvaAlq_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbIvaAlq.TextChanged
      TotAPagar()
   End Sub
   '
   Private Sub tbIvaAlq_KeyPress(ByVal KeyAscii As Integer)
      SoloNumeros(KeyAscii, True)
   End Sub
   '
   Private Sub tbNroCtto_LostFocus()
      '
      If IsNothing(CapturaDato(Cn, "Contratos", "Numero", "Numero = " & tbNroCtto.Text)) Then
         'Ok.
      Else
         MensajeTrad("CttoExiste")
         DeshabForm(Me)
      End If
      '
   End Sub
   '
   Private Sub cbNomInq_Change()
      'PintarCb(cbNomInq, LastKey)
   End Sub
   '
   Private Sub cbInquilino_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbInquilino.SelectedIndexChanged
      '
      If Not FormLoad Then Exit Sub
      '
      With cbInquilino
         If .SelectedIndex > 0 Then
            Inquilino = .SelectedValue
         Else
            Inquilino = 0
            Exit Sub
         End If
      End With
      '
      Dim Rs As New OleDb.OleDbCommand
      Dim Dr As OleDb.OleDbDataReader
      Dim DNI As String
      '
      With Rs
         .Connection = Cn
         .CommandText = "SELECT * FROM Inquilinos WHERE Codigo = " & Inquilino & " AND Estado = 'A'"
         Dr = .ExecuteReader
      End With
      '
      With Dr
         If .Read Then
            txtDniInq.Text = Format(!DNI, "###,###,##0")
            DNI = !DNI & ""
            DomLocatar = !Domicilio
            LocLocatar = !Localidad & ""
            cTIvaInq = !TipoIva
            '
            If Not IsDBNull(!Cuit) Then
               cCuitInq = !Cuit
            End If
            '
            If SisContable Then
               If IsDBNull(!Cuenta) Then
                  MensajeTrad("InqSinCuenta")
                  cbInquilino.SelectedIndex = -1
                  Exit Sub
               Else
                  cCtaInq = IIf(cfgCtaInqUnica, cfgCtaMadreInq, !Cuenta)
               End If
            End If
            '
            btnGarante.Enabled = TienePermiso(Cn, Uid, frmMenu.mGarantes.Name)
            '
         Else
            MensajeTrad("InqNoEnc")
         End If
         .Close()
      End With
      '
      'With Rs
      '   .CommandText = "SELECT * FROM Garantias WHERE Inquilino = " & Inquilino
      '   Dr = .ExecuteReader
      'End With
      ''
      'With Dr
      '   If .Read Then
      '      cbGarante.Text = !Nombre
      '      txtDniGte.Text = !Codigo
      '      tbDomGte.Text = !Domicilio
      '      cbLocGte.Text = !Localidad
      '   Else
      '      'MsgBox("Sin garante", vbInformation)
      '      cbGarante.Text = "(SIN GARANTE)"
      '      txtDniGte.Text = "0"
      '      tbDomGte.Text = ""
      '      cbLocGte.Text = ""
      '   End If
      '   .Close()
      'End With
      '
      cLetraFact = CapturaDato(Cn, "TipoIva", "RecibeComp", "Codigo = '" & cTIvaInq & "'") & ""
      '
      If cLetraFact = "" Then
         MensajeTrad("TIvaNoEnc")
         cbInquilino.SelectedIndex = -1
         '.Close()
         Exit Sub
      Else
         'cLetraFact = Trim(!RecibeComp)
         cLetraFact = Trim(cLetraFact).Substring(0, 1)
         lblFactura.Text = Traducir("Factura") & " " & cLetraFact
         tbSucursal.Text = Format(prmSucursal, "0000")
         CaptNroFact()
      End If
      '
      If Not AlicuotasIva("A", cTIvaInq, "GEN", AlicIva1, AlicIva2) Then
         cbInquilino.SelectedIndex = -1
         Exit Sub
      End If
      '
      CalcIvaAlq()
      CalcTotCtto()
      CalcImportes()
      '
      'If Cnx <> "" Then
      'lblNomInq.BackColor = CaptColor_x(Cnx, Inquilino, cbInquilino.Text, DNI)
      'End If
      '
   End Sub
   '
   Private Sub CaptNroFact()
      tbNroFact.Text = Format(CaptNroFactura(cLetraFact, Val(tbSucursal.Text)), "00000000")
   End Sub

   Private Sub tbMeses_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbMeses.KeyPress
      SoloNumeros(e.KeyChar)
   End Sub
   '
   Private Sub tbMeses_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbMeses.TextChanged
      '
      If Val(tbMeses.Text) > 0 Then
         If cfgMesesAlqMax > 0 Then
            If Val(tbMeses.Text) > cfgMesesAlqMax Then
               Mensaje("Cantidad de meses supera el máximo permitido")
               tbMeses.Text = cfgMesesAlqMax
            End If
         End If
         dtpHasta.Value = SumaMes(dtpDesde.Value, Val(tbMeses.Text)).AddDays(-1)
      Else
         dtpHasta.Value = dtpDesde.Value
      End If
      '
      tbAños.Text = DateDiff(DateInterval.Year, dtpDesde.Value, dtpHasta.Value())  '/ 365.2425) + 1
      '
      CalcTotCtto()
      CalcImportes()
      '
   End Sub
   '
   Private Sub Ins_Tmp()
      '
      Dim Rs As New OleDb.OleDbCommand
      Dim i As Int16
      '
      If Escalon = 0 Then
         Trn = Cn.BeginTransaction
         With Rs
            .Transaction = Trn
            .Connection = Cn
            .CommandText = "DELETE FROM " & cTmp
            .ExecuteNonQuery()
            For i = 1 To Val(tbMeses.Text)
               .CommandText = "INSERT INTO " & cTmp & "( Mes, FechaVenc, Importe, Iva) " & _
                              "VALUES(" & i & ", '" & _
                                      Format(SumaMes(dtpDesde.Value, i - 1), FormatFecha) & "', " & _
                                      Val(tbImpAlq.Text) & ", " & _
                                      Val(tbIvaAlq.Text) & ")"
               .ExecuteNonQuery()
            Next i
         End With
         Trn.Commit()
      End If
   End Sub
   '
   Private Sub tMeses_LostFocus()
      If Val(tbMeses.Text) < 1 Then
         MensajeTrad("DIV>0")
         tbMeses.Focus()
      End If
   End Sub
   '
   Private Sub tbImpAlq_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbImpAlq.TextChanged
      tbSonPesos.Text = Numero_a_Texto(Val(tbImpAlq.Text), , , True)
      HabDesIvaAlq()
      CalcTotCtto()
      CalcImportes()
   End Sub
   '
   Private Sub HabDesIvaAlq()
      With chkIvaAlq
         .Enabled = optComercial.Checked And Val(tbImpAlq.Text) > cfgMaxAlqSIva
         .Checked = .Enabled
         If Not .Enabled Then
            tbIvaAlq.Text = ""
         End If
      End With
      CalcIvaAlq()
   End Sub
   '
   Private Sub CalcTotCtto()
      '
      If Escalon > 0 Then
         tbImpAlq.Text = Format(Val(CapturaDato(Cn, cTmp, "Importe", "Mes = 1") & ""), "Fixed")
      End If
      '
      If chkMesDep.Checked Then
         tbImpDep.Text = tbImpAlq.Text
      Else
         tbImpDep.Text = Format(0, "Fixed")
      End If
      '
      Ins_Tmp()
      '
      tbTotCtto.Text = 0
      '
      tbTotCttoSDep.Text = Format(Val(CapturaDato(Cn, cTmp, "SUM(Importe+Iva)", "") & ""), "Fixed")
      tbTotCtto.Text = Format(Val(tbTotCttoSDep.Text) + Val(tbImpDep.Text), "Fixed")
      '
   End Sub
   '
   Private Sub CalcImportes()
      '
      If chkSellado.Checked Then
         If vTipoalq = "C" Then
            tbImpSell.Text = Math.Round(Val(tbTotCttoSDep.Text) * IIf(chkSellCG.Checked, cfgSellComCG, cfgSellComSG) / 100, 2) + cfgFoliadoCom
         Else
            tbImpSell.Text = Math.Round(Val(tbTotCttoSDep.Text) * cfgSellParSG / 100, 2)
            If chkSellCG.Checked Then
               tbImpSell.Text = Val(tbImpSell.Text) + Val(cfgSellParCG)
            End If
            tbImpSell.Text = tbImpSell.Text + cfgFoliadoPart
         End If
         tbImpSell.Text = tbImpSell.Text + Math.Round(Val(tbImpDep.Text) * cfgSellMesDep / 100, 2)
      Else
         tbImpSell.Text = 0
      End If
      '
      tbIvaAlq.Text = Format(tbIvaAlq.Text, "Fixed")
      '
      Dim honAdmAnt As Double = Val(tbHonAdm.Text)
      If cfgCobHonCont = 1 Then
         tbHonAdm.Text = Format(Val(tbTotCtto.Text) * cfgComisiAdm / 100, "Fixed")
      Else
         tbHonAdm.Text = honAdmAnt
      End If
      '
      Sellado()
      IvaDbF()
      '
   End Sub
   '
   Private Sub Sellado()
      vSelladoInq = Math.Round(IIf(chkSellInq.Checked, IIf(chkSellProp.Checked, Val(tbImpSell.Text) / 2, Val(tbImpSell.Text)), 0), 2)
      vSelladoPro = Math.Round(IIf(chkSellProp.Checked, IIf(chkSellInq.Checked, Val(tbImpSell.Text) / 2, Val(tbImpSell.Text)), 0), 2)
   End Sub
   '
   Private Sub IvaDbF()
      If CaptVrs Then
         tbIvaDbF1.Text = 0
         'tbIvaDbF2.Text = 0
      Else
         tbIvaDbF1.Text = Math.Round(Val(tbHonAdm.Text) * AlicIva1 / 100, 2)
         'tbIvaDbF2.Text = Round(Val(tbHonAdm) * AlicIva2 / 100, 2)
      End If
      TotAPagar()
   End Sub
   '
   Private Sub TotAPagar()
      tbTotaPagar.Text = Format(Val(tbImpAlq.Text) + Val(tbImpDep.Text) + Val(tbIvaAlq.Text) + _
                         Val(tbHonAdm.Text) + Val(tbIvaDbF1.Text) + vSelladoInq, "Fixed")
   End Sub
   '
   Private Sub Limpiacampos()
      Dim Ctrl As Control
      For Each Ctrl In Me.Controls
         If TypeOf Ctrl Is TextBox Then
            Ctrl.Text = ""
         End If
      Next Ctrl
      With cbGarante
         If .Items.Count > 0 Then
            .SelectedIndex = 0
         End If
      End With
      cbLocGte.Text = ""
      dtpDesde.Value = Today
      dtpHasta.Value = Today.AddDays(365 * 2)
      tbDiaVenc.Text = 10
   End Sub
   '
   Private Sub LlenaCombos()
      '
      ArmaComboItem(cbPropietario, "Propietarios", , "Nombre", "Nombre", "...", "Estado = 'A' AND Codigo IN( SELECT DISTINCT Propietario FROM Propiedades WHERE Inquilino = 0 OR Inquilino IS NULL)")
      '
      LlenaComboInq()
      '
      ArmaCbGarantes()
      '
      ArmaComboItem(cbLocalidadPrt, "Localidad", , , , "...")
      ArmaComboItem(cbLocGte, "Localidad", , , , "...")
      '
   End Sub
   '
   Private Sub LlenaComboInq()
      ArmaComboItem(cbInquilino, "Inquilinos", , "Nombre", "Nombre", , "Estado = 'A'" & IIf(chkSinAlq.Checked, " AND NOT EXISTS( SELECT Codigo FROM Propiedades WHERE Inquilino = Inquilinos.Codigo)", ""))
   End Sub
   '
   Private Sub chkSinAlq_CheckedChanged(sender As Object, e As EventArgs) Handles chkSinAlq.CheckedChanged
      LlenaComboInq()
   End Sub
   '
   Private Sub ArmaCbGarantes()
      ArmaComboItem(cbGarante, "Garantias", "GaranteId", "Nombre", "Nombre", , , , , True)
   End Sub
   '
   Private Sub ArmaCboPrd()
      '
      If cbPropietario.Text = "" Then
         Mensaje("Debe seleccionar un Propietario")
      Else
         ArmaComboItem(cbPropiedad, "Propiedades", , "Domicilio", "Domicilio", "(Seleccionar Propiedad)", "Propietario = " & Propietario & " AND Estado = 'A' AND (Inquilino = 0 OR Inquilino IS NULL)")
      End If
      '
      cmdImpuestos.Enabled = False
      '
   End Sub
   '
   Private Sub CalculoFecha()
      tbMeses.Text = DateDiff("M", dtpDesde.Value, dtpHasta.Value)
      tbAños.Text = DateDiff("yyyy", dtpDesde.Value, dtpHasta.Value())
   End Sub
   '
   Private Function VerificaCampos() As Boolean
      '
      vCamposVacios = ""
      vAutoriza = True
      '
      If cbPropietario.Text = "" Or Propietario = 0 Then
         Mensaje("Debe ingresar Propietario")
         ssTab1.SelectedIndex = 0
         cbPropietario.Focus()
         Return False
      End If
      '
      If tbDniPrt.Text = "" Then
         Mensaje("Debe ingresar DNI Propietario")
         ssTab1.SelectedIndex = 0
         tbDniPrt.Focus()
         Return False
      End If
      '
      If cbPropiedad.Text = "" Or Propiedad = 0 Then
         Mensaje("Debe ingresar Propiedad")
         ssTab1.SelectedIndex = 0
         cbPropiedad.Focus()
         Return False
      End If
      '
      If tbComodid.Text = "" Then
         vCamposVacios = vCamposVacios + " - Comodidades"
         vAutoriza = False
      End If
      '
      If txtLocPrd.Text = "" Then
         vCamposVacios = vCamposVacios + " - Localidad"
         vAutoriza = False
      End If
      '
      'If optDepart.Value Then
      'If cboConsorcio.Text = "" Then
      'vCamposVacios = vCamposVacios + " - Consorcio"
      'vAutoriza = False
      'End If
      'End If
      '
      If cbInquilino.Text = "" Or Inquilino = 0 Then
         Mensaje("Debe ingresar Inquilino")
         ssTab1.SelectedIndex = 0
         cbInquilino.Focus()
         Return False
      End If
      '
      If txtDniInq.Text = "" Then
         vCamposVacios = vCamposVacios + " - DNI. Locatario"
         vAutoriza = False
      End If
      '
      If GaranteId = 0 Then
         vCamposVacios = vCamposVacios + " - Garante"
         vAutoriza = False
      End If
      '
      If txtDniGte.Text = "" Then
         vCamposVacios = vCamposVacios + " - DNI. Garante"
         vAutoriza = False
      End If
      '
      If tbDomGte.Text = "" Then
         vCamposVacios = vCamposVacios + " - Domicilio Garante"
         vAutoriza = False
      End If
      '
      If tbInventario.Text = "" Then
         If vAutoriza Then
            MensajeTrad("DIInventario")
            ssTab1.TabPages(1).Focus()
            tbInventario.Focus()
            Exit Function
         End If
      End If
      '
      If tbNroCtto.Text = "" Then
         vCamposVacios = vCamposVacios + " - NUMERO DE CONTRATO"
         vAutoriza = False
      End If
      '
      If cfgMesesAlqMax > 0 Then
         If Val(tbMeses.Text) > cfgMesesAlqMax Then
            Mensaje("Cantidad de meses supera el máximo permitido")
            ssTab1.SelectedIndex = 0
            tbMeses.Focus()
            Return False
         End If
      End If
      '
      If Val(tbDiaVenc.Text) <= 0 Or _
         Val(tbDiaVenc.Text) > 30 Then
         MensajeTrad("DiaVencInc")
         tbDiaVenc.Focus()
         ssTab1.SelectedIndex = 0
         Return False
      End If
      '
      If Val(tbImpAlq.Text) = 0 Then
         MensajeTrad("DIIAlq>0")
         ssTab1.SelectedIndex = 1
         tbImpAlq.Focus()
         Return False
      End If
      '
      If vAutoriza Then
         If Not CaptVrs Then
            If Val(tbHonAdm.Text) > 0 Then
               If Not optContado.Checked And Not optCtaCte.Checked Then
                  MensajeTrad("DICtdoCtaCte")
                  ssTab1.SelectedIndex = 1
                  vAutoriza = False
                  Exit Function
               End If
            End If
         End If
      End If
      '
      If Not vAutoriza Then
         Mensaje("Debe llenar los campos " + vCamposVacios)
         ssTab1.SelectedIndex = 0
         cbPropietario.Focus()
      End If
      '
      Return vAutoriza
      '
   End Function
   '
   Private Function Guardar() As Boolean
      '
      Dim nMes As Integer
      Dim cPer As String
      Dim dFec As Date
      Dim nRen As Integer
      Dim cDetSell As String
      Dim TotFact As Double
      Dim ImpAlqAnt As Double = 0
      Dim ImpAlqMes As Double
      Dim ContMes As Integer
      '
      Dim CodAsi As String
      Dim NroAsi As Long
      Dim RenASi As Integer
      Dim DetAsi As String
      Dim ImpIvaAnt As Double
      Dim ImpIvaMes As Double
      Dim dFecDde As Date
      Dim i As Int16
      '
      Try
         '
         Trn = Cn.BeginTransaction
         '
         dFec = SumaMes(tbDiaVenc.Text & "/" & Format(dtpDesde.Value, "MM/yyyy"), cfgLiqVenCur * -1)
         cDetSell = DescSel & " Nº " & tbNroCtto.Text
         '
         If Val(tbHonAdm.Text) > 0 Then
            tbNroFact.Text = Format(CaptNroFactura(cLetraFact, Val(tbSucursal.Text), Trn), "00000000")
         Else
            tbNroFact.Text = 0
         End If
         '
         If CaptVrs Then
            CodAsi = "FF" & "-" & Val(tbNroCtto.Text)
         Else
            CodAsi = "FC" & "-" & cLetraFact & "-" & Val(prmSucursal) & "-" & Val(tbNroFact.Text)
         End If
         '
         DetAsi = IIf(Not CaptVrs, Traducir("Factura", , Trn) & " " & Traducir("Contrato", , Trn) & " Nº " & Val(tbNroCtto.Text) & "-" & cbInquilino.Text, _
                                   Traducir("FondoFijo", , Trn) & " - " & cbInquilino.Text)
         '
         TotFact = Val(tbHonAdm.Text) + Val(tbIvaDbF1.Text)   '+ Val(tbIvaDbF2)
         '
         GuardarCfg(cfgNContrato, "cfgNContrato", tbNroCtto.Text, Trn)
         '
         If Val(tbHonAdm.Text) > 0 Then
            If Not CaptVrs Then
               If cLetraFact = "A" Then
                  GuardarCfg(cfgNroFactA, "cfgNroFactA", tbNroFact.Text, Trn)
               Else
                  GuardarCfg(cfgNroFactB, "cfgNroFactB", tbNroFact.Text, Trn)
               End If
            End If
         End If
         '
         With Cmd
            .Connection = Cn
            .Transaction = Trn
            .CommandText = "INSERT INTO Contratos( Numero, Texto, Convenio, FechaContrato, FechaC, Propietario, Inquilino, Propiedad, GaranteId, PerDesde, PerHasta, Meses, DiaVenc, Estado, Tipo, Sucursal, NroFact, Escalon, MesesEsc, Incremento, Usuario, FechaMod) " & _
                           "VALUES( " & tbNroCtto.Text & ", " & _
                                  "'" & tbContrato.Text & "', " & _
                                  "'" & tbConvenio.Text & "', " & _
                                  "'" & Format(dtFechaCtto.Value, FormatFecha) & "', " & _
                                  "'" & Format(dtFechaCtto.Value, FormatFecha) & "', " & _
                                        Propietario & ", " & _
                                        Inquilino & ", " & _
                                        Propiedad & ", " & _
                                        GaranteId & ", " & _
                                  "'" & CalcPeriodo(dtpDesde.Value, 1) & "', " & _
                                  "'" & CalcPeriodo(dtpDesde.Value, Val(tbMeses.Text)) & "', " & _
                                        tbMeses.Text & ", " & _
                                        tbDiaVenc.Text & ", " & _
                                        vEstado & ", " & _
                                  "'" & cLetraFact & "', " & _
                                        prmSucursal & ", " & _
                                        Val(tbNroFact.Text) & ", " & _
                                        Escalon & ", " & _
                                        MesesEsc & ", " & _
                                        IncrPorc & ", " & _
                                  "'" & Uid & "', " & _
                                  "'" & Format(Now, FormatFechaHora) & "')"
            .ExecuteNonQuery()
            '
            .CommandText = "UPDATE Propiedades SET " & _
                           " Inquilino = " & Inquilino & ", " & _
                           " Valor = " & Val(tbImpAlq.Text) & ", " & _
                           " Usuario = '" & Uid & "', " & _
                           " Fechamod = '" & Format(Now, FormatFechaHora) & "' " & _
                           "WHERE Codigo = " & Propiedad
            .ExecuteNonQuery()
            '
            ImpAlqMes = tbImpAlq.Text
            dFecDde = dFec
            '
            For i = 1 To tbMeses.Text
               '
               ImpAlqMes = CapturaDato(Cn, cTmp, "Importe", "Mes = " & i, , , , Trn)
               dFecDde = CapturaDato(Cn, cTmp, "FechaVenc", "Mes = " & i, , , , Trn)
               '
               If ImpAlqMes <> ImpAlqAnt Then
                  '
                  If IsNothing(CapturaDato(Cn, "PropiedConc", "Concepto", "Propiedad = " & Propiedad & " AND Concepto = '" & cfgCodigoAlq & "' AND FecDesde = '" & Format(dFecDde, FormatFecha) & "'", , , , Trn)) Then
                     .CommandText = "INSERT INTO PropiedConc( Propiedad, Concepto, FecDesde, Automatico, Detalle, Importe, Imputacion, aPropiet, aPagar, NoInquilino, Usuario, FechaMod) " & _
                                    "VALUES(" & Propiedad & ", " & _
                                          "'" & cfgCodigoAlq & "', " & _
                                          "'" & Format(dFecDde, FormatFecha) & "', " & _
                                                1 & ", " & _
                                          "'" & DescAlq & "', " & _
                                                ImpAlqMes & ", " & _
                                          "'" & "D" & "', " & _
                                                1 & ", " & _
                                                0 & ", " & _
                                                0 & ", " & _
                                          "'" & Uid & "', " & _
                                          "'" & Format(Now, FormatFechaHora) & "')"
                  Else
                     .CommandText = "UPDATE PropiedConc SET " & _
                                    " Automatico = 1, " & _
                                    " Detalle = '" & DescAlq & "', " & _
                                    " Importe = " & ImpAlqMes & ", " & _
                                    " Imputacion = 'D', " & _
                                    " aPropiet = 1, " & _
                                    " aPagar = 0, " & _
                                    " NoInquilino = 0, " & _
                                    " Usuario = '" & Uid & "', " & _
                                    " Fechamod = '" & Format(Now, FormatFechaHora) & "' " & _
                                    "WHERE Propiedad = " & Propiedad & " AND Concepto = '" & cfgCodigoAlq & "' AND FecDesde = '" & Format(dFecDde, FormatFecha) & "'"
                     '
                  End If
                  '
                  .ExecuteNonQuery()
                  '
                  ImpAlqAnt = ImpAlqMes
                  '
               End If
               '
               If chkIvaAlq.Checked Then
                  ImpIvaMes = CapturaDato(Cn, cTmp, "Iva", "Mes = " & i, , , , Trn)
                  '
                  If ImpIvaMes <> ImpIvaAnt Then
                     If ImpAlqMes > cfgMaxAlqSIva Then
                        If IsNothing(CapturaDato(Cn, "PropiedConc", "Concepto", "Propiedad = " & Propiedad & " AND Concepto = '" & cfgCodigoIva & "' AND Automatico <> 0 AND FecDesde = '" & Format(dFecDde, FormatFecha) & "'", , , , Trn)) Then
                           .CommandText = "INSERT INTO PropiedConc( Propiedad, Concepto, FecDesde, Automatico, Detalle, Importe, Imputacion, aPropiet, aPagar, NoInquilino, Usuario, FechaMod) " & _
                                          "VALUES(" & Propiedad & ", " & _
                                                "'" & cfgCodigoIva & "', " & _
                                                "'" & Format(dFecDde, FormatFecha) & "', " & _
                                                      1 & ", " & _
                                                "'" & DescIva & "', " & _
                                                      ImpIvaMes & ", " & _
                                                "'" & "D" & "', " & _
                                                      1 & ", " & _
                                                      0 & ", " & _
                                                      0 & ", " & _
                                                "'" & Uid & "', " & _
                                                "'" & Format(Now, FormatFechaHora) & "')"
                        Else
                           .CommandText = "UPDATE PropiedConc SET " & _
                                          " Automatico = 1, " & _
                                          " Detalle = '" & DescIva & "', " & _
                                          " Importe = " & ImpIvaMes & ", " & _
                                          " Imputacion = 'D', " & _
                                          " aPropiet = 1, " & _
                                          " aPagar = 0, " & _
                                          " NoInquilino = 0, " & _
                                          " Usuario = '" & Uid & "', " & _
                                          " Fechamod = '" & Format(Now, FormatFechaHora) & "' " & _
                                          "WHERE Propiedad = " & Propiedad & " AND Concepto = '" & cfgCodigoIva & "' AND Automatico <> 0 AND FecDesde = '" & Format(dFecDde, FormatFecha) & "'"
                           '
                        End If
                        '
                        .ExecuteNonQuery()
                        '
                        ImpIvaAnt = ImpIvaMes
                        '
                     End If
                  End If
               End If
               '
               'dFecDde = SumaMes(dFecDde, 1)
               ContMes = ContMes + 1
            Next i
            '
            If Val(tbImpDep.Text) > 0 Then
               'Mes Depósito.
               .CommandText = "INSERT INTO FactInq( Periodo, Propiedad, Inquilino, Concepto, Fecha, Detalle, Importe, Saldo, Imputacion, Liquidado, TipoNroRbo, Automatico, aPropiet, MesPago, Usuario, FechaMod) " & _
                              "VALUES('" & CalcPeriodo(dtpDesde.Value, 1) & "', " & _
                                           Propiedad & ", " & _
                                           Inquilino & ", " & _
                                     "'" & cfgCodigoMdp & "', " & _
                                     "'" & Format(dFec, FormatFecha) & "', " & _
                                     "'" & DescMdp & "', " & _
                                           tbImpDep.Text & ", " & _
                                           tbImpDep.Text & ", " & _
                                     "'" & "D" & "', " & _
                                           0 & ", " & _
                                     "'" & "" & "', " & _
                                           0 & ", " & _
                                           1 & ", " & _
                                           1 & ", " & _
                                     "'" & Uid & "', " & _
                                     "'" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
            End If
            '
            'Sellado Inquilino.
            If vSelladoInq > 0 Then
               .CommandText = "INSERT INTO FactInq( Periodo, Propiedad, Inquilino, Concepto, Fecha, Detalle, Importe, Saldo, Imputacion, Liquidado, TipoNroRbo, Automatico, aPropiet, MesPago, Usuario, FechaMod) " & _
                              "VALUES('" & CalcPeriodo(dtpDesde.Value, 1) & "', " & _
                                           Propiedad & ", " & _
                                           Inquilino & ", " & _
                                     "'" & cfgCodigoSel & "', " & _
                                     "'" & Format(dFec, FormatFecha) & "', " & _
                                     "'" & DescSel & "', " & _
                                           vSelladoInq & ", " & _
                                           vSelladoInq & ", " & _
                                     "'" & "D" & "', " & _
                                           0 & ", " & _
                                     "'" & "" & "', " & _
                                           0 & ", " & _
                                           0 & ", " & _
                                           1 & ", " & _
                                     "'" & Uid & "', " & _
                                     "'" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
            End If
            '
            'Otros Comprobantes.
            If Val(tbImpSell.Text) > 0 Then
               .CommandText = "INSERT INTO CompraOtr( Comprob, Sucursal, Numero, Propietario, Proveedor, Nombre, Fecha, FechaVenc, Detalle, Total, Liquidado, Pagado, Propiedad, Usuario, FechaMod) " & _
                              "VALUES('" & cmpInt & "', " & _
                                          prmSucursal & ", " & _
                                          tbNroCtto.Text & ", " & _
                                          IIf(vSelladoPro > 0, Propietario, "0") & ", " & _
                                          0 & ", " & _
                                          "''" & ", " & _
                                    "'" & Format(dFec, FormatFecha) & "', " & _
                                    "'" & Format(dFec, FormatFecha) & "', " & _
                                    "'" & cDetSell & "', " & _
                                          Val(tbImpSell.Text) & ", " & _
                                          0 & ", " & _
                                          0 & ", " & _
                                          Propiedad & ", " & _
                                     "'" & Uid & "', " & _
                                     "'" & Format(Now, FormatFechaHora) & "')"

               .ExecuteNonQuery()
            End If
            '
            If vSelladoInq > 0 Then
               'Sellado Inquilino.
               nRen = nRen + 1
               .CommandText = "INSERT INTO CompraOtrDet( Comprob, Proveedor, Sucursal, Numero, Renglon, aPropiet, Fecha, Concepto, Detalle, Imput, Importe, Usuario, FechaMod) " & _
                              "VALUES('" & "CT" & "', " & _
                                           0 & ", " & _
                                           prmSucursal & ", " & _
                                           tbNroCtto.Text & ", " & _
                                           nRen & ", " & _
                                           0 & ", " & _
                                     "'" & Format(dFec, FormatFecha) & "', " & _
                                     "'" & cfgCodigoSel & "', " & _
                                     "'" & cDetSell & " (" & UCase(Traducir("Inquilino", , Trn)) & ")" & "', " & _
                                     "'" & "D" & "', " & _
                                           vSelladoInq & ", " & _
                                     "'" & Uid & "', " & _
                                     "'" & Format(Now, FormatFechaHora) & "')"

               .ExecuteNonQuery()

            End If
            '
            If vSelladoPro > 0 Then
               'Sellado Propietario.
               nRen = nRen + 1
               .CommandText = "INSERT INTO CompraOtrDet( Comprob, Proveedor, Sucursal, Numero, Renglon, aPropiet, Fecha, Concepto, Detalle, Imput, Importe, Usuario, FechaMod) " & _
                              "VALUES('" & "CT" & "', " & _
                                           0 & ", " & _
                                           prmSucursal & ", " & _
                                           tbNroCtto.Text & ", " & _
                                           nRen & ", " & _
                                           1 & ", " & _
                                     "'" & Format(dFec, FormatFecha) & "', " & _
                                     "'" & cfgCodigoSel & "', " & _
                                     "'" & cDetSell & " (" & UCase(Traducir("Propietario", , Trn)) & ")" & "', " & _
                                     "'" & "D" & "', " & _
                                           vSelladoPro & ", " & _
                                     "'" & Uid & "', " & _
                                     "'" & Format(Now, FormatFechaHora) & "')"

               .ExecuteNonQuery()
            End If
         End With
         '
         If Val(tbHonAdm.Text) > 0 Then
            'Factura p/Comisión.
            If Not CaptVrs Then
               If Not AltaFactura(cLetraFact, prmSucursal, tbNroFact.Text, "FC.", Today, _
                                  Inquilino, Propietario, cbInquilino.Text, cTIvaInq, _
                                  cCuitInq, tbHonAdm.Text, 0, 0, Val(tbIvaDbF1.Text), _
                                  0, TotFact, _
                                  Traducir("CadPCtto", , Trn) & " Nº " & tbNroCtto.Text, , _
                                  IIf(optContado.Checked, 1, 0), Trn) Then
                  Err.Raise(1001, , "NoAltaFact")
               End If
               ' 
               If Not AltaRenFact(cLetraFact, prmSucursal, tbNroFact.Text, 1, cfgCodigoHnA, DescHna, 1, tbHonAdm.Text, 0, Trn) Then
                  Err.Raise(1001, , "NoAltaRenFact")
               End If
            End If
            '
            If SisContable Then
               NroAsi = GuardaAsiento(CodAsi, Today, DetAsi, Trn)
               '
               If NroAsi = 0 Then
                  Err.Raise(1001, , "NoUpAsiDet")
               End If
               '
               RenASi = 1
               If Not GuardaAsienDet(NroAsi, RenASi, IIf(CaptVrs, cfgCtaVrs1, IIf(optContado.Checked, cCtaCaja, cCtaInq)), DetAsi, TotFact, 0, Trn) Then
                  Err.Raise(1001, , "NoUpAsiDet")
               End If
               '
               RenASi = RenASi + 1
               If Not GuardaAsienDet(NroAsi, RenASi, IIf(CaptVrs, cfgCtaVrs2, cCtaHna), DetAsi, 0, tbHonAdm.Text, Trn) Then
                  Err.Raise(1001, , "NoUpAsiDet")
               End If
               '
               If Val(tbIvaDbF1.Text) > 0 Then
                  RenASi = RenASi + 1
                  If Not GuardaAsienDet(NroAsi, RenASi, cCtaIDF1, DetAsi, 0, tbIvaDbF1.Text, Trn) Then
                     Err.Raise(1001, , "NoUpAsiDet")
                  End If
               End If
               '
            End If
            '
            If optContado.Checked Then
               '
               If Not CaptVrs Then
                  If Not ActCaja(prmNroCaja, CodAsi, "EF", Today, cbPropietario.Text, "", DetAsi, TotFact, 0, , Trn) Then
                     Err.Raise(1001)
                  End If
               End If
               '
            End If
         End If
         '
         For nMes = 1 To Val(tbMeses.Text)
            cPer = CalcPeriodo(dtpDesde.Value, nMes)
            ActPropConc(cPer, Propiedad, Inquilino, nMes, tbDiaVenc.Text, , Trn)
         Next nMes
         '
         'Asientos.
         If SisContable Then
            If Not ActAsiFactInq(Val(tbNroCtto.Text), Trn) Then
               Err.Raise(1001, , "NoUpAsiento")
            End If
         End If
         '
         GuardarAudit("Alta contrato", cbPropietario.Text & " - " & cbInquilino.Text & " - Nº " & tbNroCtto.Text, Me.Name, cmdGuardar.Text, Trn)
         '
         Trn.Commit()
         '
         Return True
         '
      Catch ex As System.Exception
         '
         Trn.Rollback()
         '
         Dim st As New StackTrace(True)
         RegistrarError(st, "frmContratos")
         Return False
         '
      End Try
      '
   End Function
   '
   Private Sub DeshabCtrl()
      '
      Dim Ctrl As Control
      '
      For Each Ctrl In Me.Controls
         If TypeOf Ctrl Is TextBox Or _
            TypeOf Ctrl Is ComboBox Or _
            TypeOf Ctrl Is Button Then
            Ctrl.Enabled = False
         End If
      Next Ctrl
      '
   End Sub
   '
   Private Sub cmdEscalonado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEscalonado.Click
      If Val(tbMeses.Text) = 0 Then
         MensajeTrad("DICantMeses")
         ssTab1.SelectedIndex = 0
         tbMeses.Focus()
      Else
         Dim Frm As New frmContratoEsc
         With Frm
            .TablaTmp = cTmp
            .Comercial = optComercial.Checked And (chkIvaAlq.Checked)
            .AlicIva1 = AlicIva1
            .AlicIva2 = AlicIva2
            .ImpAlq = Val(tbImpAlq.Text)
            .Meses = Val(tbMeses.Text)
            .FecIni = dtpDesde.Value
            .Escalon = Escalon
            .IncrPorc = IncrPorc
            .MesesEsc = MesesEsc
            .ShowDialog(Me)
            'tbImpAlq.Text = .ImpAlq
            'tbMeses.Text = .Meses
            '.FecIni = dtpDesde.Value
            Escalon = .Escalon
            IncrPorc = .IncrPorc
            MesesEsc = .MesesEsc
            CalcTotCtto()
            CalcImportes()
         End With
      End If
      If Escalon = 0 Then
         lblEscalon.Text = "Uniforme"
      ElseIf Escalon = 1 Then
         lblEscalon.Text = "Incremental." & vbCrLf & vbCrLf & _
                      IIf(IncrPorc > 0, "Aumenta", "Disminuye") & _
                      " $" & Math.Abs(IncrPorc) & ", todos los meses."
      ElseIf Escalon = 2 Then
         lblEscalon.Text = "En Bloques." & vbCrLf & vbCrLf & _
                      IIf(IncrPorc > 0, "Aumenta", "Disminuye") & _
                      " $" & Math.Abs(IncrPorc) & ", cada " & MesesEsc & " meses."
      ElseIf Escalon = 3 Then
         lblEscalon.Text = "En porcentaje" & vbCrLf & vbCrLf & _
                      IIf(IncrPorc > 0, "Aumenta ", "Disminuye ") & _
                      Math.Abs(IncrPorc) & "%, cada " & MesesEsc & " meses."
      Else
         lblEscalon.Text = "Manual"
      End If
   End Sub
   '
   Private Sub chkHonAdm_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkHonAdm.CheckedChanged
      If Not chkHonAdm.Checked And SisContable Then
         If cfgCtaVrs1 = "" Or cfgCtaVrs2 = "" Then
            Mensaje("Cuenta/s Servicios Varios no definida/s")
            CaptVrs = False
         Else
            '.BackColor = &H80000010
            CaptVrs = True
         End If
      Else
         '.BackColor = &H8000000F
         CaptVrs = False
      End If
      tbHonAdm.Enabled = Not CaptVrs
      optContado.Enabled = Not CaptVrs
      optCtaCte.Enabled = Not CaptVrs
      IvaDbF()
   End Sub
   '
   Private Sub tbDniPrt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbDniPrt.KeyPress
      SoloNumeros(e.KeyChar)
   End Sub
   '
   Private Sub tbDniPrt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbDniPrt.LostFocus
      tbDniPrt.Text = Format(Val(tbDniPrt.Text), MaskDNI)
   End Sub
   '
   Private Sub tbDiaVenc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbDiaVenc.KeyPress
      SoloNumeros(e.KeyChar)
   End Sub
   '
   Private Sub cbGarante_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbGarante.SelectedIndexChanged
      '
      Dim Cmd As New OleDb.OleDbCommand
      Dim Drd As OleDb.OleDbDataReader
      '
      With cbGarante
         If .SelectedIndex > 0 Then
            GaranteId = .SelectedValue
         Else
            GaranteId = 0
         End If
      End With
      '
      With Cmd
         .Connection = Cn
         .CommandText = "SELECT * FROM Garantias WHERE GaranteId = " & GaranteId
         Drd = .ExecuteReader
      End With
      '
      With Drd
         If .Read Then
            cbGarante.Text = !Nombre
            txtDniGte.Text = Format(Val(!DNI), "###,###,##0")
            tbDomGte.Text = !Domicilio
            cbLocGte.Text = CapturaDato(Cn, "Localidad", "Descrip", "LocalidadId = " & Val(!LocalidadId & "")) & ""
         Else
            cbGarante.SelectedIndex = 0
            txtDniGte.Text = "0"
            tbDomGte.Text = ""
            cbLocGte.Text = ""
         End If
         .Close()
      End With
   End Sub
   '
   Private Sub btnGarante_Click(sender As Object, e As EventArgs) Handles btnGarante.Click
      With frmGarantesAM
         .Alta = True
         .ShowDialog(Me)
      End With
      ArmaCbGarantes()
   End Sub
   '
   Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click, cmdSalir2.Click, cmdSalir3.Click
      Me.Close()
   End Sub
   '
   Private Sub frmContrato_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
      '
      EliminaTmp(Cn, cTmp)
      '
      SetRegForm(Me)
      Me.Dispose()
      '
   End Sub
   '
End Class