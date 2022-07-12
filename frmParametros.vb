Public Class frmParametros
   '
   Dim cFormatCod As String
   Dim i As Integer
   '
   Dim Caja As Int16 = -1
   Dim TipoIva As String = cfgIvaEmp
   Dim EmiteComp As String = cfgEmiteComp
   '
   Private Sub frmParametros_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      '
      TraducirForm(Me)
      '
      ArmaCombos()
      '
      tbSucursal.Text = prmSucursal
      chkImprLiq.Checked = prmImprLiq
      chkVistaPrevia.Checked = prmVistPrevLiq
      '
      tbNroLiqP.Text = cfgNroLiqP
      tbNContrato.Text = cfgNContrato
      tbNroRetG.Text = cfgNroRetG
      tbNroPago.Text = cfgNroPago
      tbNroTransf.Text = cfgNroTransf
      tbNroCajaMN.Text = cfgNroCajaMN
      '
      tbNroFactA.Text = cfgNroFactA
      tbNroFactB.Text = cfgNroFactB
      tbNroFactC.Text = cfgNroFactC
      '
      tbNroRboA.Text = cfgNroRboA
      tbNroRboB.Text = cfgNroRboB
      tbNroRboC.Text = cfgNroRboC
      tbNroRboX.Text = cfgNroRboX
      chkImpRboX.Checked = cfgImpRboX
      '
      tbIntDiario.Text = cfgIntDiario
      tbIntMin.Text = cfgIntDiaMin
      tbIntMax.Text = cfgIntDiaMax
      '
      tbMaxMesAdl.Text = cfgMaxMesAdl
      tbMesesAct.Text = cfgMesesAct
      '
      cbConcAlq.Text = CapturaDato(Cn, "Conceptos", "Descrip", "Codigo = '" & cfgCodigoAlq & "'")
      cbConcBon.Text = CapturaDato(Cn, "Conceptos", "Descrip", "Codigo = '" & cfgCodigoBon & "'")
      cbConcAdl.Text = CapturaDato(Cn, "Conceptos", "Descrip", "Codigo = '" & cfgCodigoAdl & "'")
      cbConcExp.Text = CapturaDato(Cn, "Conceptos", "Descrip", "Codigo = '" & cfgCodigoExp & "'")
      cbConcSell.Text = CapturaDato(Cn, "Conceptos", "Descrip", "Codigo = '" & cfgCodigoSel & "'")
      cbConcCAd.Text = CapturaDato(Cn, "Conceptos", "Descrip", "Codigo = '" & cfgCodigoCAd & "'")
      cbConcHon.Text = CapturaDato(Cn, "Conceptos", "Descrip", "Codigo = '" & cfgCodigoHnA & "'")
      cbConcSen.Text = CapturaDato(Cn, "Conceptos", "Descrip", "Codigo = '" & cfgCodigoSen & "'")
      '
      cbConcIvaCf1.Text = CapturaDato(Cn, "Conceptos", "Descrip", "Codigo = '" & cfgCodigoICF1 & "'")
      '*BuscarCfg(cbConcIvaCf2.text, "cfgCodigoICF2")
      cbConcIvaDf1.Text = CapturaDato(Cn, "Conceptos", "Descrip", "Codigo = '" & cfgCodigoIDf1 & "'")
      '*BuscarCfg(cbConcIvaDf2, "cfgCodigoIDf2")
      cbConcMdp.Text = CapturaDato(Cn, "Conceptos", "Descrip", "Codigo = '" & cfgCodigoMdp & "'")
      cbConcRGan.Text = CapturaDato(Cn, "Conceptos", "Descrip", "Codigo = '" & cfgCodigoRGan & "'")
      cbConcIvaA.Text = CapturaDato(Cn, "Conceptos", "Descrip", "Codigo = '" & cfgCodigoIva & "'")
      cbConcInt.Text = CapturaDato(Cn, "Conceptos", "Descrip", "Codigo = '" & cfgCodigoInt & "'")
      cbConcVCar.Text = CapturaDato(Cn, "Conceptos", "Descrip", "Codigo = '" & cfgCodigoVCar & "'")
      '
      tbMaxAlqSIva.Text = cfgMaxAlqSIva
      tbCotDollar.Text = cfgCotDollar
      chkCobHonCont.Checked = cfgCobHonCont
      '
      cbCntDigCtas.Text = cfgCntDigCtas
      '
      optMesVenc.Checked = cfgLiqVenCur
      optMesCurso.Checked = Not cfgLiqVenCur
      '
      tbMesesAlqC.Text = cfgMesesAlqC
      tbMesesAlqP.Text = cfgMesesAlqP
      tbMesesAlqMax.Text = cfgMesesAlqmax
      '
      tbSellComSG.Text = cfgSellComSG
      tbSellComCG.Text = cfgSellComCG
      tbSellParSG.Text = cfgSellParSG
      tbSellParCG.Text = cfgSellParCG
      tbFoliadoCom.Text = cfgFoliadoCom
      tbFoliadoPart.Text = cfgFoliadoPart
      tbSellComDep.Text = cfgsellcomdep
      tbSellParDep.Text = cfgSellParDep
      tbSellMaxNoImp.Text = cfgSellMaxNoImp
      '
      tbComisiAdm.Text = cfgComisiAdm
      '
      tbNomEmp.Text = cfgNomEmp
      tbDomEmp.Text = cfgDomEmp
      tbCPosEmp.Text = cfgCPosEmp
      If cfgProvEmp <> "" Then
         cbProvincia.Text = cfgProvEmp
      End If
      If cfgLocEmp <> "" Then
         cbLocEmp.Text = cfgLocEmp
      End If
      '
      tbTelefono.Text = cfgTelEmp
      tbEMail.Text = cfgEMailEmp
      'tbEmailPwd.Text = cfgEMailPwd
      '
      tbDocumentos.Text = cfgUbicDocs
      '
      chkCtaInqUnica.Checked = cfgCtaInqUnica
      chkCtaPrtUnica.Checked = cfgCtaPrtUnica
      chkCtaAdlUnica.Checked = cfgCtaAdlUnica
      chkCtaPrvUnica.Checked = cfgCtaPrvUnica
      '
      tbGtosBancPT.Text = cfgGtosBancPT
      tbGtosBancSF.Text = cfgGtosBancSF
      chkGtosBancIva.Checked = cfgGtosBancIva
      '
      chkGenDifComprob.Checked = cfgGenDifComprob
      chkAdlMayProy.Checked = cfgAdelMayProy
      tbCodAutSup.Text = cfgCodAutSup
      chkGenFactCom.Checked = cfgGenFactCom
      '
      dtpFecIniAct.Value = cfgFecIniAct
      '
      If cfgCuitEmp <> "" Then
         tbCuitEmp.Text = cfgCuitEmp
      End If
      '
      cbFormatCod.Text = cfgFormatCod
      '
      cbIdioma.Text = prmIdioma
      PosCboItem(cbCaja, prmNroCaja)
      cbTipoIva.Text = CapturaDato(Cn, "TipoIva", "Descrip", "Codigo = '" & cfgIvaEmp & "'")
      '
      '*** CUENTAS MADRE ***
      If cfgCtaMadreInq <> "" Then
         cbCtaMadreInq.Text = CapturaDato(Cn, "PlanCtas", "Descrip", "Cuenta = '" & cfgCtaMadreInq & "'")
         tbCtaInq.Text = cfgCtaMadreInq
      End If
      If cfgCtaMadrePrt <> "" Then
         cbCtaMadrePrt.Text = CapturaDato(Cn, "PlanCtas", "Descrip", "Cuenta = '" & cfgCtaMadrePrt & "'")
         tbCtaPrt.Text = cfgCtaMadrePrt
      End If
      If cfgCtaMadreAdl <> "" Then
         cbCtaMadreAdl.Text = CapturaDato(Cn, "PlanCtas", "Descrip", "Cuenta = '" & cfgCtaMadreAdl & "'")
         tbCtaAdl.Text = cfgCtaMadreAdl
      End If
      If cfgCtaProvVarios <> "" Then
         cbProvVarios.Text = CapturaDato(Cn, "PlanCtas", "Descrip", "Cuenta = '" & cfgCtaProvVarios & "'")
         tbCtaPrvVs.Text = cfgCtaProvVarios
      End If
      If cfgCtaCajaRec <> "" Then
         cbCtaCajaRec.Text = CapturaDato(Cn, "PlanCtas", "Descrip", "Cuenta = '" & cfgCtaCajaRec & "'")
         tbCtaCajaRec.Text = cfgCtaCajaRec
      End If
      '
      '*** COMUNICACION ***
      tbSmtpServ.Text = cfgSmtpServ
      tbSmtpPort.Text = cfgSmtpPort
      chkEnablSSL.Checked = cfgEnablSSL
      tbSmtpCta.Text = cfgSmtpCta
      tbSmtpPwd.Text = cfgSmtpPwd
      tbSmtpCtaAdm.Text = cfgSmtpCtaAdm
      tbSmtpPwdAdm.Text = cfgSmtpPwdAdm
      '
      tbImgFondo.Text = BuscarCfg("ImgFondo", "")
      chkShowFrmFondo.Checked = cfgShowFrmFondo
      '
      'Adodc1.ConnectionString = Cn
      'Adodc1.RecordSource = "AvisoHoras"
      'Adodc1.Refresh()
      ''
      'chkAvisoDeuda = IIf(regAvisoDeuda, 1, 0)
      ''
      'CalcIntDiario()
      'SSTab1.Tab = 2
      '
   End Sub
   '
   Private Sub frmParametros_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
      'TabReturn(e.KeyChar)
   End Sub
   '
   Private Sub ArmaCombos()
      '
      ArmaCombo(cbConcAlq, "Descrip", "Conceptos", "Descrip", , , "(Seleccionar)")
      ArmaCombo(cbConcBon, "Descrip", "Conceptos", "Descrip", , , "(Seleccionar)")
      ArmaCombo(cbConcAdl, "Descrip", "Conceptos", "Descrip", , , "(Seleccionar)")
      ArmaCombo(cbConcExp, "Descrip", "Conceptos", "Descrip", , , "(Seleccionar)")
      ArmaCombo(cbConcSell, "Descrip", "Conceptos", "Descrip", , , "(Seleccionar)")
      ArmaCombo(cbConcMdp, "Descrip", "Conceptos", "Descrip", , , "(Seleccionar)")
      ArmaCombo(cbConcCAd, "Descrip", "Conceptos", "Descrip", , , "(Seleccionar)")
      ArmaCombo(cbConcHon, "Descrip", "Conceptos", "Descrip", , , "(Seleccionar)")
      ArmaCombo(cbConcSen, "Descrip", "Conceptos", "Descrip", , , "(Seleccionar)")
      ArmaCombo(cbConcIvaA, "Descrip", "Conceptos", "Descrip", , , "(Seleccionar)")
      ArmaCombo(cbConcIvaCf1, "Descrip", "Conceptos", "Descrip", , , "(Seleccionar)")
      ArmaCombo(cbConcIvaDf1, "Descrip", "Conceptos", "Descrip", , , "(Seleccionar)")
      ArmaCombo(cbConcRGan, "Descrip", "Conceptos", "Descrip", , , "(Seleccionar)")
      ArmaCombo(cbConcInt, "Descrip", "Conceptos", "Descrip", , , "(Seleccionar)")
      ArmaCombo(cbConcVCar, "Descrip", "Conceptos", "Descrip", , , "(Seleccionar)")
      '
      ArmaComboItem(cbCaja, "Cajas", "Caja", , , "(Seleccionar)")
      ArmaCombo(cbIdioma, "Descrip", "Idiomas", "Descrip", , , "(Seleccionar)")
      ArmaCombo(cbTipoIva, "Descrip", "TipoIva", "Descrip", , , "(Seleccionar)")
      '
      ArmaCbCtaInq()
      ArmaCbCtaAdl()
      ArmaCbCtaProv()
      ArmaCbCtaPrt()
      '
      ArmaCombo(cbCtaCajaRec, "Descrip", "PlanCtas", "Descrip", "RecAsi <> 0", , "(Seleccionar)")
      '
      For i = 3 To 15
         cbCntDigCtas.Items.Add(i)
      Next i
      '
      ArmaCombo(cbProvincia, "DISTINCT(Provincia)", "Localidad", , , , "(Seleccionar)")
      ArmaComboItem(cbLocEmp, "Localidad", , , , "(Seleccionar)")
      '
   End Sub
   '
   Private Sub tbNroDec(sender As Object, e As KeyPressEventArgs) Handles tbIntDiario.KeyPress, tbIntMin.KeyPress, tbIntMax.KeyPress, tbCotDollar.KeyPress, tbCuitEmp.KeyPress
      SoloNumeros(e.KeyChar, True)
   End Sub
   '
   'Private Sub Form_KeyPress(ByVal KeyAscii As Integer)
   '   TabReturn(KeyAscii, True)
   '   If TypeOf Me.ActiveControl Is ComboBox Then
   '      'Nada.
   '   Else
   '      If Me.ActiveControl.Name <> "tbDomEmp" And _
   '         Me.ActiveControl.Name <> "tbLocEmp" And _
   '         Me.ActiveControl.Name <> "tbCPosEmp" And _
   '         Me.ActiveControl.Name <> DataGrid1.Name Then
   '         SoloNumeros(KeyAscii)
   '      End If
   '   End If
   'End Sub
   '
   'Private Sub cboCtaMadreInqD_Change()
   '   PintarCb(cboCtaMadreInqD)
   'End Sub
   ''
   'Private Sub cboCtaMadreInqD_Click()
   '   cboCtaMadreInq.ListIndex = cboCtaMadreInqD.ListIndex
   'End Sub
   ''
   'Private Sub cboCtaMadreInq_Click()
   '   cboCtaMadreInqD.ListIndex = cboCtaMadreInq.ListIndex
   'End Sub
   ''
   'Private Sub cboCtaMadreInq_Change()
   '   PintarCb(cboCtaMadreInq)
   'End Sub
   ''
   'Private Sub cboCtaMadrePrtD_Change()
   '   PintarCb(cboCtaMadrePrtD)
   'End Sub
   ''
   'Private Sub cboCtaMadrePrtD_Click()
   '   cboCtaMadrePrt.ListIndex = cboCtaMadrePrtD.ListIndex
   'End Sub
   ''
   'Private Sub cboCtaMadrePrt_Click()
   '   cboCtaMadrePrtD.ListIndex = cboCtaMadrePrt.ListIndex
   'End Sub
   ''
   'Private Sub cboCtaMadreAdlD_Change()
   '   PintarCb(cboCtaMadreAdlD)
   'End Sub
   ''
   'Private Sub cboCtaMadreAdlD_Click()
   '   cboCtaMadreAdl.ListIndex = cboCtaMadreAdlD.ListIndex
   'End Sub
   ''
   'Private Sub cboCtaMadreAdl_Click()
   '   cboCtaMadreAdlD.ListIndex = cboCtaMadreAdl.ListIndex
   'End Sub
   ''
   'Private Sub cboProvVariosD_Change()
   '   PintarCb(cboProvVariosD)
   'End Sub
   ''
   'Private Sub cboProvVariosD_Click()
   '   cboProvVarios.ListIndex = cboProvVariosD.ListIndex
   'End Sub
   ''
   'Private Sub cboProvVarios_Click()
   '   cboProvVariosD.ListIndex = cboProvVarios.ListIndex
   'End Sub
   ''
   'Private Sub cbCajas_Click()
   '   cbDescCajas.ListIndex = cbCajas.ListIndex
   'End Sub
   ''
   'Private Sub cbDescCajas_Click()
   '   cbCajas.ListIndex = cbDescCajas.ListIndex
   'End Sub
   ''
   'Private Sub cboCtaCajaRec_Click()
   '   cboCtaCajaRecD.ListIndex = cboCtaCajaRec.ListIndex
   'End Sub
   ''
   'Private Sub cboCtaCajaRecD_Click()
   '   cboCtaCajaRec.ListIndex = cboCtaCajaRecD.ListIndex
   'End Sub
   ''
   'Private Sub cbocboCtaCajaRecD_Change()
   '   PintarCb(cboCtaCajaRecD)
   'End Sub
   ''
   ''Private Sub cboCtaCajaRec_Change()
   ''   PintarCb cboCtaCajaRec
   ''End Sub
   ''
   'Private Sub CalcIntDiario()

   '   If Val(tbIntDiario) = 0 Then tbIntDiario = cfgIntDiario

   '   With tbIntMin
   '      If .Text = "" Then
   '         .Text = Format(0, "Fixed")
   '      ElseIf Val(.Text) > tbIntDiario Then
   '         .Text = Format(tbIntDiario, "Fixed")
   '      End If
   '   End With

   '   With tbIntMax
   '      If Val(.Text) = 0 Or Val(.Text) < tbIntDiario Then
   '         .Text = Format(tbIntDiario, "Fixed")
   '      End If
   '   End With

   'End Sub
   ''
   Private Sub cmdAceptar_Click(sender As Object, e As EventArgs) Handles cmdAceptar.Click

      If cbConcAlq.Text <> "" And _
         cbConcAlq.Text = cbConcExp.Text Then
         MensajeTrad("CAlq=CExp")
         cbConcAlq.Focus()
         Exit Sub
      End If
      '
      prmIdioma = cbIdioma.Text
      prmSucursal = Val(tbSucursal.Text)
      prmNroCaja = Caja
      prmImprLiq = chkImprLiq.Checked
      prmVistPrevLiq = chkVistaPrevia.Checked
      prmAvisoDeuda = False
      '
      GuardarArchivoPrm()
      '
      GuardarCfg(cfgNomEmp, "cfgNomEmp", tbNomEmp.Text)
      GuardarCfg(cfgDomEmp, "cfgDomEmp", tbDomEmp.Text)
      GuardarCfg(cfgCPosEmp, "cfgCPosEmp", tbCPosEmp.Text)
      GuardarCfg(cfgLocEmp, "cfgLocEmp", cbLocEmp.Text)
      GuardarCfg(cfgProvEmp, "cfgProvEmp", cbProvincia.Text)
      GuardarCfg(cfgTelEmp, "cfgTelEmp", tbTelefono.Text)
      GuardarCfg(cfgEMailEmp, "cfgEMailEmp", tbEMail.Text)
      '
      GuardarCfg(cfgNroLiqP, "cfgNroLiqP", Val(tbNroLiqP.Text))
      GuardarCfg(cfgNroRetG, "cfgNroRetG", Val(tbNroRetG.Text))
      GuardarCfg(cfgNContrato, "cfgNContrato", Val(tbNContrato.Text))
      GuardarCfg(cfgNroPago, "cfgNroPago", Val(tbNroPago.Text))
      GuardarCfg(cfgNroTransf, "cfgNroTransf", Val(tbNroTransf.Text))
      GuardarCfg(cfgNroCajaMN, "cfgNroCajaMN", Val(tbNroCajaMN.Text))
      '
      GuardarCfg(cfgNroRboA, "cfgNroRboA", Val(tbNroRboA.Text))
      GuardarCfg(cfgNroRboB, "cfgNroRboB", Val(tbNroRboB.Text))
      GuardarCfg(cfgNroRboC, "cfgNroRboC", Val(tbNroRboC.Text))
      GuardarCfg(cfgNroRboX, "cfgNroRboX", Val(tbNroRboX.Text))
      GuardarCfg(cfgImpRboX, "cfgImpRboX", IIf(chkImpRboX.Checked, 1, 0))
      '
      GuardarCfg(cfgNroFactA, "cfgNroFactA", Val(tbNroFactA.Text))
      GuardarCfg(cfgNroFactB, "cfgNroFactB", Val(tbNroFactB.Text))
      GuardarCfg(cfgNroFactC, "cfgNroFactC", Val(tbNroFactC.Text))
      '
      GuardarCfg(cfgIntDiario, "cfgIntDiario", Val(tbIntDiario.Text))
      GuardarCfg(cfgIntDiaMin, "cfgIntDiaMin", Val(tbIntMin.Text))
      GuardarCfg(cfgIntDiaMax, "cfgIntDiaMax", Val(tbIntMax.Text))
      GuardarCfg(cfgMaxMesAdl, "cfgMaxMesAdl", Val(tbMaxMesAdl.Text))
      GuardarCfg(cfgMesesAct, "cfgMesesAct", Val(tbMesesAct.Text))
      '
      GuardarCfg(cfgCodigoAlq, "cfgCodigoAlq", tbConcAlq.Text)
      GuardarCfg(cfgCodigoBon, "cfgCodigoBon", tbConcBon.Text)
      GuardarCfg(cfgCodigoAdl, "cfgCodigoAdl", tbConcAdl.Text)
      GuardarCfg(cfgCodigoExp, "cfgCodigoExp", tbConcExp.Text)
      GuardarCfg(cfgCodigoSel, "cfgCodigoSel", tbConcSell.Text)
      GuardarCfg(cfgCodigoMdp, "cfgCodigoMdp", tbConcMdp.Text)
      GuardarCfg(cfgCodigoCAd, "cfgCodigoCAd", tbConcCAd.Text)
      GuardarCfg(cfgCodigoHnA, "cfgCodigoHnA", tbConcHon.Text)
      GuardarCfg(cfgCodigoSen, "cfgCodigoSen", tbConcSen.Text)
      GuardarCfg(cfgCodigoIva, "cfgCodigoIva", tbConcIvaA.Text)
      GuardarCfg(cfgCodigoICF1, "cfgCodigoICF1", tbConcIvaCf1.Text)
      GuardarCfg(cfgCodigoIDf1, "cfgCodigoIDf1", tbConcIvaDf1.Text)
      GuardarCfg(cfgCodigoRGan, "cfgCodigoRGan", tbConcRGan.Text)
      GuardarCfg(cfgCodigoInt, "cfgCodigoInt", tbConcInt.Text)
      GuardarCfg(cfgCodigoVCar, "cfgCodigoVCar", tbConcVCar.Text)
      '
      GuardarCfg(cfgMaxAlqSIva, "cfgMaxAlqSIva", Val(tbMaxAlqSIva.Text))
      GuardarCfg(cfgCotDollar, "cfgCotDollar", Val(tbCotDollar.Text))
      GuardarCfg(cfgCobHonCont, "cfgCobhonCont", IIf(chkCobHonCont.Checked, 1, 0))
      '
      GuardarCfg(cfgLiqVenCur, "cfgLiqVenCur", IIf(optMesVenc.Checked, 1, 0))
      '
      GuardarCfg(cfgFormatCod, "cfgFormatCod", cbFormatCod.Text)
      GuardarCfg(cfgCntDigCtas, "cfgCntDigCtas", cbCntDigCtas.Text)
      '
      GuardarCfg(cfgMesesAlqC, "cfgMesesAlqC", Val(tbMesesAlqC.Text))
      GuardarCfg(cfgMesesAlqP, "cfgMesesAlqP", Val(tbMesesAlqP.Text))
      GuardarCfg(cfgMesesAlqMax, "cfgMesesAlqMax", Val(tbMesesAlqMax.Text))
      '
      GuardarCfg(cfgSellComCG, "cfgSellComCG", Val(tbSellComCG.Text))
      GuardarCfg(cfgSellComSG, "cfgSellComSG", Val(tbSellComSG.Text))
      GuardarCfg(cfgSellParCG, "cfgSellParCG", Val(tbSellParCG.Text))
      GuardarCfg(cfgSellParSG, "cfgSellParSG", Val(tbSellParSG.Text))
      GuardarCfg(cfgFoliadoCom, "cfgFoliadoCom", Val(tbFoliadoCom.Text))
      GuardarCfg(cfgFoliadoPart, "cfgFoliadoPart", Val(tbFoliadoPart.Text))
      GuardarCfg(cfgSellComDep, "cfgSellComDep", Val(tbSellComDep.Text))
      GuardarCfg(cfgSellParDep, "cfgSellparDep", Val(tbSellParDep.Text))
      GuardarCfg(cfgSellMaxNoImp, "cfgSellMaxNoImp", Val(tbSellMaxNoImp.Text))
      '
      GuardarCfg(cfgComisiAdm, "cfgComisiAdm", Val(tbComisiAdm.Text))
      '
      GuardarCfg(cfgDomEmp, "cfgDomEmp", tbDomEmp.Text)
      GuardarCfg(cfgCPosEmp, "cfgCPosEmp", tbCPosEmp.Text)
      GuardarCfg(cfgLocEmp, "cfgLocEmp", cbLocEmp.Text)
      GuardarCfg(cfgIvaEmp, "cfgIvaEmp", TipoIva)
      GuardarCfg(cfgEmiteComp, "cfgEmiteComp", EmiteComp)
      GuardarCfg(cfgCuitEmp, "cfgCuitEmp", tbCuitEmp.Text)
      GuardarCfg(cfgUbicDocs, "cfgUbicDocs", tbDocumentos.Text)
      '
      GuardarCfg(cfgCtaMadreInq, "cfgCtaMadreInq", tbCtaInq.Text)
      GuardarCfg(cfgCtaMadrePrt, "cfgCtaMadrePrt", tbCtaPrt.Text)
      GuardarCfg(cfgCtaMadreAdl, "cfgCtaMadreAdl", tbCtaAdl.Text)
      GuardarCfg(cfgCtaProvVarios, "cfgCtaProvVarios", tbCtaPrvVs.Text)
      GuardarCfg(cfgCtaCajaRec, "cfgCtaCajaRec", tbCtaCajaRec.Text)
      GuardarCfg(cfgFecIniAct, "cfgFecIniAct", dtpFecIniAct.Value)
      '
      GuardarCfg(cfgCtaInqUnica, "cfgCtaInqUnica", chkCtaInqUnica.Checked)
      GuardarCfg(cfgCtaPrtUnica, "cfgCtaPrtUnica", chkCtaPrtUnica.Checked)
      GuardarCfg(cfgCtaAdlUnica, "cfgCtaAdlUnica", chkCtaAdlUnica.Checked)
      GuardarCfg(cfgCtaPrvUnica, "cfgCtaPrvUnica", chkCtaPrvUnica.Checked)
      '
      GuardarCfg(cfgGtosBancPT, "cfgGtosBancPT", Val(tbGtosBancPT.Text))
      GuardarCfg(cfgGtosBancSF, "cfgGtosBancSF", Val(tbGtosBancSF.Text))
      GuardarCfg(cfgGtosBancIva, "cfgGtosBancIva", chkGtosBancIva.Checked)
      GuardarCfg(cfgGenDifComprob, "cfgGenDifComprob", chkGenDifComprob.Checked)
      GuardarCfg(cfgAdelMayProy, "cfgAdelMayProy", chkAdlMayProy.Checked)
      GuardarCfg(cfgCodAutSup, "cfgCodAutSup", tbCodAutSup.Text)
      GuardarCfg(cfgGenFactCom, "cfgGenFactCom", chkGenFactCom.Checked)
      '
      GuardarCfg(cfgSmtpCta, "cfgSmtpCta", tbSmtpCta.Text)
      GuardarCfg(cfgSmtpPwd, "cfgSmtpPwd", tbSmtpPwd.Text)
      GuardarCfg(cfgSmtpPort, "cfgSmtpPort", Val(tbSmtpPort.Text))
      GuardarCfg(cfgEnablSSL, "cfgEnablSSL", chkEnablSSL.Checked)
      GuardarCfg(cfgSmtpServ, "cfgSmtpServ", tbSmtpServ.Text)
      GuardarCfg(cfgSmtpCtaAdm, "cfgSmtpCtaAdm", tbSmtpCtaAdm.Text)
      GuardarCfg(cfgSmtpPwdAdm, "cfgSmtpPwdAdm", tbSmtpPwdAdm.Text)
      '
      GuardarCfg(cfgImgFondo, "ImgFondo", tbImgFondo.Text)
      GuardarCfg(cfgShowFrmFondo, "cfgShowFrmFondo", chkShowFrmFondo.Checked)
      '
      TraducirForm(frmMenu)
      '
      Me.Close()
      '
   End Sub
   '
   Private Sub chkImpRboX_CheckedChanged(sender As Object, e As EventArgs) Handles chkImpRboX.CheckedChanged
      With chkImpRboX
         tbNroRboA.Enabled = Not .Checked
         tbNroRboB.Enabled = Not .Checked
         tbNroRboC.Enabled = Not .Checked
         tbNroRboX.Enabled = .Checked
      End With
   End Sub
   '
   Private Sub btnExplDoc_Click(sender As Object, e As EventArgs) Handles btnExplDoc.Click
      With FolderBrowserDialog1
         .SelectedPath = tbDocumentos.Text
         .ShowDialog()
         If .SelectedPath <> "" Then
            tbDocumentos.Text = .SelectedPath
         End If
      End With
   End Sub
   '
   Private Sub ArmaCbCtaInq()
      ArmaCombo(cbCtaMadreInq, "Descrip", "PlanCtas", "Descrip", "RecAsi = " & IIf(chkCtaInqUnica.Checked, 1, 0), , "(Seleccionar)")
   End Sub
   '
   Private Sub ArmaCbCtaPrt()
      ArmaCombo(cbCtaMadrePrt, "Descrip", "PlanCtas", "Descrip", "RecAsi = " & IIf(chkCtaPrtUnica.Checked, 1, 0), , "(Seleccionar)")
   End Sub
   '
   Private Sub ArmaCbCtaAdl()
      ArmaCombo(cbCtaMadreAdl, "Descrip", "PlanCtas", "Descrip", "RecAsi = " & IIf(chkCtaAdlUnica.Checked, 1, 0), , "(Seleccionar)")
   End Sub
   '
   Private Sub ArmaCbCtaProv()
      ArmaCombo(cbProvVarios, "Descrip", "PlanCtas", "Descrip", "RecAsi <> " & IIf(chkCtaPrvUnica.Checked, 1, 0), , "(Seleccionar)")
   End Sub
   '
   Private Sub chkCtaInqUnica_CheckedChanged(sender As Object, e As EventArgs) Handles chkCtaInqUnica.CheckedChanged
      ArmaCbCtaInq()
   End Sub
   '
   Private Sub chkCtaPrtUnica_CheckedChanged(sender As Object, e As EventArgs) Handles chkCtaPrtUnica.CheckedChanged
      ArmaCbCtaPrt()
   End Sub
   '
   Private Sub chkCtaAdlUnica_CheckedChanged(sender As Object, e As EventArgs) Handles chkCtaAdlUnica.CheckedChanged
      ArmaCbCtaAdl()
   End Sub
   '
   Private Sub chkCtaPrvUnica_CheckedChanged(sender As Object, e As EventArgs) Handles chkCtaPrvUnica.CheckedChanged
      ArmaCbCtaProv()
   End Sub
   '
   Private Sub tbNumeros_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbMesesAlqP.KeyPress, tbMesesAlqC.KeyPress, tbNContrato.KeyPress, tbSucursal.KeyPress, tbMesesAlqMax.KeyPress, tbMesesAct.KeyPress
      SoloNumeros(e.KeyChar)
   End Sub
   '
   Private Sub tbNumDec_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbSellComSG.KeyPress, tbSellComCG.KeyPress, tbSellParCG.KeyPress, tbSellParSG.KeyPress, tbFoliadoCom.KeyPress, tbFoliadoPart.KeyPress
      SoloNumeros(e.KeyChar, True)
   End Sub
   '
   Private Sub btnCaptNumeros_Click(sender As Object, e As EventArgs) Handles btnCaptNumeros.Click
      tbNroLiqP.Text = CapturaDato(Cn, "LiqPropiet", "ISNULL(MAX(Numero),0)", "")
      tbNroFactA.Text = CapturaDato(Cn, "Ventas", "ISNULL(MAX(Numero),0)", "Tipo = 'A'")
      tbNroFactB.Text = CapturaDato(Cn, "Ventas", "ISNULL(MAX(Numero),0)", "Tipo = 'B'")
      tbNroFactC.Text = CapturaDato(Cn, "Ventas", "ISNULL(MAX(Numero),0)", "Tipo = 'C'")
      tbNroPago.Text = CapturaDato(Cn, "OrdenPago", "ISNULL(MAX(OpNumero),0)", "")
      tbNContrato.Text = CapturaDato(Cn, "Contratos", "ISNULL(MAX(Numero),0)", "")
      tbNroRetG.Text = CapturaDato(Cn, "RetGcias", "ISNULL(MAX(Numero),0)", "")
      tbNroTransf.Text = CapturaDato(Cn, "LiqPropTr", "ISNULL(MAX(NumeroTr),0)", "")
      tbNroCajaMN.Text = CapturaDato(Cn, "Caja", "ISNULL(MAX(CONVERT( INT, ISNULL(SUBSTRING( Comprob, 3, LEN(Comprob) - 2), 1))),0)", "Comprob LIKE 'MN%'")
      tbNroRboA.Text = CapturaDato(Cn, "Cobros", "ISNULL(MAX(Numero),0)", "Tipo = 'A'")
      tbNroRboB.Text = CapturaDato(Cn, "Cobros", "ISNULL(MAX(Numero),0)", "Tipo = 'B'")
      tbNroRboC.Text = CapturaDato(Cn, "Cobros", "ISNULL(MAX(Numero),0)", "Tipo = 'C'")
      tbNroRboX.Text = CapturaDato(Cn, "LiqInqCab", "ISNULL(MAX(Numero),0)", "Tipo = 'X'")
   End Sub
   '
   Private Sub cbCaja_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCaja.SelectedIndexChanged
      With cbCaja
         If .SelectedIndex > 0 Then
            Caja = .SelectedValue
         Else
            Caja = -1
         End If
      End With
   End Sub
   '
   Private Sub cbTipoIva_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbTipoIva.SelectedIndexChanged
      TipoIva = CapturaDato(Cn, "TipoIva", "Codigo", "Descrip = '" & cbTipoIva.Text & "'")
      EmiteComp = LTrim(CapturaDato(Cn, "TipoIva", "EmiteComp", "Codigo = '" & TipoIva & "'") & "")
   End Sub
   '
   Private Sub cbCtaMadreInq_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCtaMadreInq.SelectedIndexChanged
      tbCtaInq.Text = CapturaDato(Cn, "PlanCtas", "Cuenta", "Descrip = '" & cbCtaMadreInq.Text & "'")
   End Sub
   '
   Private Sub cbCtaMadrePrt_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCtaMadrePrt.SelectedIndexChanged
      tbCtaPrt.Text = CapturaDato(Cn, "PlanCtas", "Cuenta", "Descrip = '" & cbCtaMadrePrt.Text & "'")
   End Sub
   '
   Private Sub cbConcIvaCf1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbConcIvaCf1.SelectedIndexChanged
      tbConcIvaCf1.Text = CapturaDato(Cn, "Conceptos", "Codigo", "Descrip = '" & cbConcIvaCf1.Text & "'")
   End Sub
   '
   Private Sub cbConcIvaDf1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbConcIvaDf1.SelectedIndexChanged
      tbConcIvaDf1.Text = CapturaDato(Cn, "Conceptos", "Codigo", "Descrip = '" & cbConcIvaDf1.Text & "'")
   End Sub
   '
   Private Sub cbConcRGan_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbConcRGan.SelectedIndexChanged
      tbConcRGan.Text = CapturaDato(Cn, "Conceptos", "Codigo", "Descrip = '" & cbConcRGan.Text & "'")
   End Sub
   '
   Private Sub cbConcInt_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbConcInt.SelectedIndexChanged
      tbConcInt.Text = CapturaDato(Cn, "Conceptos", "Codigo", "Descrip = '" & cbConcInt.Text & "'")
   End Sub
   '
   Private Sub cbConcVCar_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbConcVCar.SelectedIndexChanged
      tbConcVCar.Text = CapturaDato(Cn, "Conceptos", "Codigo", "Descrip = '" & cbConcVCar.Text & "'")
   End Sub
   '
   Private Sub cbCtaMadreAdl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCtaMadreAdl.SelectedIndexChanged
      tbCtaAdl.Text = CapturaDato(Cn, "PlanCtas", "Cuenta", "Descrip = '" & cbCtaMadreAdl.Text & "'")
   End Sub
   '
   Private Sub cbProvVarios_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbProvVarios.SelectedIndexChanged
      tbCtaPrvVs.Text = CapturaDato(Cn, "PlanCtas", "Cuenta", "Descrip = '" & cbProvVarios.Text & "'")
   End Sub
   '
   Private Sub cbCtaCajaRec_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCtaCajaRec.SelectedIndexChanged
      tbCtaCajaRec.Text = CapturaDato(Cn, "PlanCtas", "Cuenta", "Descrip = '" & cbCtaCajaRec.Text & "'")
   End Sub
   '
   Private Sub cbConcAlq_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbConcAlq.SelectedIndexChanged
      tbConcAlq.Text = CapturaDato(Cn, "Conceptos", "Codigo", "Descrip = '" & cbConcAlq.Text & "'")
   End Sub
   '
   Private Sub cbConcBon_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbConcBon.SelectedIndexChanged
      tbConcBon.Text = CapturaDato(Cn, "Conceptos", "Codigo", "Descrip = '" & cbConcBon.Text & "'")
   End Sub
   '
   Private Sub cbConcAdl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbConcAdl.SelectedIndexChanged
      tbConcAdl.Text = CapturaDato(Cn, "Conceptos", "Codigo", "Descrip = '" & cbConcAdl.Text & "'")
   End Sub
   '
   Private Sub cbConcIvaA_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbConcIvaA.SelectedIndexChanged
      tbConcIvaA.Text = CapturaDato(Cn, "Conceptos", "Codigo", "Descrip = '" & cbConcIvaA.Text & "'")
   End Sub
   '
   Private Sub cbConcCAd_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbConcCAd.SelectedIndexChanged
      tbConcCAd.Text = CapturaDato(Cn, "Conceptos", "Codigo", "Descrip = '" & cbConcCAd.Text & "'")
   End Sub
   '
   Private Sub cbConcSen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbConcSen.SelectedIndexChanged
      tbConcSen.Text = CapturaDato(Cn, "Conceptos", "Codigo", "Descrip = '" & cbConcSen.Text & "'")
   End Sub
   '
   Private Sub cbConcExp_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbConcExp.SelectedIndexChanged
      tbConcExp.Text = CapturaDato(Cn, "Conceptos", "Codigo", "Descrip = '" & cbConcExp.Text & "'")
   End Sub
   '
   Private Sub cbConcMdp_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbConcMdp.SelectedIndexChanged
      tbConcMdp.Text = CapturaDato(Cn, "Conceptos", "Codigo", "Descrip = '" & cbConcMdp.Text & "'")
   End Sub
   '
   Private Sub cbConcHon_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbConcHon.SelectedIndexChanged
      tbConcHon.Text = CapturaDato(Cn, "Conceptos", "Codigo", "Descrip = '" & cbConcHon.Text & "'")
   End Sub
   '
   Private Sub cbConcSell_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbConcSell.SelectedIndexChanged
      tbConcSell.Text = CapturaDato(Cn, "Conceptos", "Codigo", "Descrip = '" & cbConcSell.Text & "'")
   End Sub
   '
   Private Sub cbLocEmp_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbLocEmp.SelectedIndexChanged
      tbCPosEmp.Text = CapturaDato(Cn, "Localidad", "Codigo", "Descrip = '" & cbLocEmp.Text & "'")
   End Sub
   '
   Private Sub tbox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbNomEmp.KeyPress, tbDomEmp.KeyPress
      e.KeyChar = UCase(e.KeyChar)
   End Sub
   '
   Private Sub tbEMail_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbEMail.KeyPress
      e.KeyChar = LCase(e.KeyChar)
   End Sub
   '
   Private Sub chkAdlMayProy_CheckedChanged(sender As Object, e As EventArgs) Handles chkAdlMayProy.CheckedChanged
      tbCodAutSup.Enabled = chkAdlMayProy.Checked
   End Sub
   '
   Private Sub btnSelImgFondo_Click(sender As Object, e As EventArgs) Handles btnSelImgFondo.Click
      With OpenFileImgFondo
         .InitialDirectory = tbImgFondo.Text
         .RestoreDirectory = True
         .ShowDialog()
         If .FileName <> "" Then
            tbImgFondo.Text = .FileName
         End If
      End With
   End Sub
   '
   Private Sub tbSmtpPort_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbSmtpPort.KeyPress
      SoloNumeros(e.KeyChar)
   End Sub
   '
   Private Sub btnProbar_Click(sender As Object, e As EventArgs) Handles btnProbar.Click
      Dim Ctadest As String = "jiramirez.nqn@gmail.com"
      Dim Adjuntos As New Collection
      If EnviarMail(Ctadest, "Parámetros. Prueba comunicación", "Si llegó este e-Mail funciona corectamente.", Adjuntos, True, tbSmtpServ.Text, tbSmtpPort.Text, tbSmtpCta.Text, tbSmtpPwd.Text, chkEnablSSL.Checked) Then
         chkPrueba1.Visible = True
         MsgBox("Correo enviado existosamente a '" & Ctadest & "' !")
      Else
         chkPrueba1.Visible = False
      End If
   End Sub
   '
   Private Sub btnProbarAdm_Click(sender As Object, e As EventArgs) Handles btnProbarAdm.Click
      Dim Ctadest As String = "jiramirez.nqn@gmail.com"
      Dim Adjuntos As New Collection
      If EnviarMail(Ctadest, "Parámetros. Prueba comunicación cuenta Adm.", "Si llegó este e-Mail funciona corectamente.", Adjuntos, True, tbSmtpServ.Text, tbSmtpPort.Text, tbSmtpCtaAdm.Text, tbSmtpPwdAdm.Text, chkEnablSSL.Checked) Then
         chkPrueba2.Visible = True
         MsgBox("Correo enviado existosamente a '" & Ctadest & "' !")
      Else
         chkPrueba2.Visible = False
      End If
   End Sub
   '
   Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
      Me.Close()
   End Sub
   '
   Private Sub frmParametros_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
      SetRegForm(Me)
   End Sub
   '
End Class
