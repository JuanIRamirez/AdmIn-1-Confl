Imports System.Threading

Module ModInicio
   '
   Public Const EmpAbr = "RamSis"
   Public Const Sistema = "AdmIn"
   '
   Public regNomEmp As String = "Versión Demo"
   Public regSistema As String
   Public TrialVers As Boolean
   Public TrialMaxReg As Integer
   Public SisContable As Boolean = False
   Public ModoPrueba As Boolean = False
   '
   Public Const nMarcadores = 48
   Public Marcador(nMarcadores) As String
   Public TextMarc(nMarcadores) As String
   Public DescMarc(nMarcadores) As String
   Public varOkInq2 As Boolean
   '
   Public prmEmpresaId As Integer = 0
   Public prmEmpNombre As String = ""
   Public prmSucursal As Integer = 0
   Public prmDepart As Integer = 1
   Public prmConOrdCom As Boolean = False
   Public prmImprLiq As Boolean = False
   Public prmVistPrevLiq As Boolean = True
   Public prmNroCaja As Int16 = 1
   '
   Public sOrigen As String
   Public sDriver As String
   Public cDbBkp As String
   Public NombrePC As String
   '
   Public cfgSegurid As String
   '
   '*** DATOS EMPRESA ***
   Public cfgNomEmp As String
   Public cfgDomEmp As String
   Public cfgCPosEmp As String
   Public cfgLocEmp As String
   Public cfgIvaEmp As String
   Public cfgEmiteComp As String
   Public cfgCuitEmp As String
   Public cfgProvEmp As String
   Public cfgTelEmp As String
   Public cfgEMailEmp As String
   'Public cfgEMailPwd As String
   '
   '*** CONTADORES ***
   Public cfgNroFactA As Long
   Public cfgNroFactB As Long
   Public cfgNroFactC As Long
   '
   Public cfgNroRboA As Long
   Public cfgNroRboB As Long
   Public cfgNroRboC As Long
   Public cfgNroRboX As Long
   Public cfgImpRboX As Boolean
   '
   Public cfgNContrato As Long
   Public cfgNroLiqP As Long
   Public cfgNroRetG As Long
   Public cfgNroPago As Long
   Public cfgNroTransf As Long
   Public cfgNroCobro As Long
   Public cfgNroCajaMN As Long
   '
   '*** IVA ***
   Public cfgTipoIva As Integer
   Public cfgAlicIva As Single = 21.0
   '
   '*** INTERESES ***
   Public cfgIntDiario As Single
   Public cfgIntDiaMin As Single
   Public cfgIntDiaMax As Single
   '
   '*** CODIGOS o CONCEPTOS ***
   Public cfgCodAutSup As String = ""
   Public cfgCodigoAdl As String
   Public cfgCodigoAlq As String
   Public cfgCodigoBon As String
   Public cfgCodigoCAd As String
   Public cfgCodigoHnA As String   'Comisiones/Honorarios p/Alquiler.
   Public cfgCodigoHnV As String   'Comisiones/Honorarios p/Ventas.
   Public cfgCodigoSen As String   'Señas.
   Public cfgCodigoExp As String
   Public cfgCodigoICF1 As String
   Public cfgCodigoICF2 As String
   Public cfgCodigoIDf1 As String
   Public cfgCodigoIDf2 As String
   Public cfgCodigoInt As String
   Public cfgCodigoIva As String
   Public cfgCodigoMdp As String
   Public cfgCodigoRGan As String
   Public cfgCodigoSel As String
   Public cfgCodigoVCar As String
   Public cfgCodigoCom As String   'Comisiones.
   '
   '*** POLITICA ***
   Public cfgAdelMayProy As Boolean
   Public cfgMaxAlqSIva As Double
   Public cfgCobHonCont As Integer
   Public cfgLiqVenCur As Boolean = True
   Public cfgFormatCod As String
   Public cfgMesesAlqC As Integer
   Public cfgMesesAlqP As Integer
   Public cfgMesesAlqMax As Integer   'Maxima cantidad de meses del alquiler p/Contrato.
   Public cfgMaxMesAdl As Integer
   Public cfgComisiAdm As Single
   Public cfgCntDigCtas As Integer
   Public cfgCotDollar As Double
   Public cfgPerGenCmp As String
   Public cfgUbicDocs As String
   Public cfgUltimaAct As String
   Public cfgFecIniAct As Date
   Public cfgGtosBancPT As Single    'Gastos Bancarios Porcentaje por Transferencias.
   Public cfgGtosBancSF As Single    'Gastos Bancarios Suma Fija.
   Public cfgGtosBancIva As Boolean  'Gastos Bancarios IVA.
   Public cfgGenDifComprob As Boolean
   Public cfgPerCierreIVA As String
   Public cfgPerCierreGEN As String
   Public cfgSolPartida As Boolean
   Public cfgSolFecVenc As Boolean
   Public cfgModFecEgr As Boolean
   Public cfgModPrecioVta As Boolean
   Public cfgPartVenc As Boolean
   Public cfgActCosto As Boolean
   Public cfgNoImpCmpAut As Boolean
   Public cfgVistaPrevInf As Boolean
   Public cfgEgrSinStk As Boolean = True
   Public cfgMaxDescuento As Single
   Public cfgSumDescRubro As Boolean
   Public cfgValCuit As Boolean
   Public prmAvisoDeuda As Boolean
   Public cfgMesesAct As Byte = 0
   Public cfgMaxRengFact As Byte = 0
   Public regHabFactEl As Boolean = False
   Public cfgNumNCSep As Boolean = False
   Public cfuBusqInt As Boolean = True
   Public cfgImprRtoFact As String = "N"
   Public cfgGenFactCom As Boolean = False
   '
   '*** SELLADO ***
   Public cfgSellComCG As Single
   Public cfgSellComSG As Single
   Public cfgSellParSG As Single
   Public cfgSellParCG As Single
   Public cfgSellMesDep As Single
   Public cfgFoliadoCom As Single
   Public cfgFoliadoPart As Single
   Public cfgSellComDep As Single
   Public cfgSellParDep As Single
   Public cfgSellMaxNoImp As Double
   '
   '*** FORMATOS ***
   Public cfgMaskNomCat As String = "##-##-###-####-####"
   Public cfgMaskCuit As String = "##-########-#"
   Public cfgFormatoPr As String = "#0.00"
   Public cfgFormatoCn As String = "#0.00"
   Public cfgFormatoPrCol As String = cfgFormatoPr & " "
   '
   '*** CUENTAS CONT ***
   Public cfgCtaVrs1 As String
   Public cfgCtaVrs2 As String
   Public cfgCtaMadreInq As String
   Public cfgCtaInqUnica As Boolean
   Public cfgCtaMadrePrt As String
   Public cfgCtaPrtUnica As Boolean
   Public cfgCtaMadreAdl As String
   Public cfgCtaAdlUnica As Boolean
   Public cfgCtaProvVarios As String
   Public cfgCtaPrvUnica As Boolean
   Public cfgCtaCajaRec As String
   '
   '*** COMUNICACION ***
   Public cfgSmtpServ As String = ""
   Public cfgSmtpPort As Int16 = 0
   Public cfgSmtpCta As String = ""
   Public cfgSmtpPwd As String = ""
   Public cfgEnablSSL As Boolean = False
   Public cfgEmailDest As String = ""
   Public cfgSmtpCtaAdm As String = ""
   Public cfgSmtpPwdAdm As String = ""
   '
   '*** STOCK ***
   Public cfgSvrStk As String
   Public cfgTruCnStk As Boolean
   Public cfgAutDbstk As Boolean
   Public cfgUsrStk As String
   Public cfgPwdStk As String
   Public cfgDbProdStk As String
   Public cfgDbTmpStk As String
   Public cfgIngProdProv As Boolean
   Public prmVerTodosProd As Boolean    'Ver todos los productos al buscar.
   Public prmConMedicam As Boolean
   Public prmSepMedicam As Boolean
   '
   '*** REPORTES ***
   Public cfgDestinoCmp As Byte = 1     'Destino Impresora   ***Crystal.DestinationConstants
   Public cfgDestinoRep As Byte = 0     'Destino Pantalla    ***Crystal.DestinationConstants
   Public prmOcultarMenus As Boolean
   '
   Public prmDSucursal As String
   Public prmDDepartamento As String
   '
   Public cfpFontSize As Integer
   Public cfgImgFondo As String = ""
   '
   Public Raiz As String = "C:\"
   Public ArchivoIni As String
   Public ArchivoCfg As String
   '
   Public Empresa As String
   '
   Public regFacturar As Boolean
   Public regCtrlFiscal As Boolean
   Public regCFComPort As Integer
   Public regCFCopias As Integer
   Public regCFCantReng As Integer
   Public regDefPrFinal As Boolean
   Public regFontSize As Integer
   Public prmIdioma As String = "ESPAÑOL"
   Public regUsr As String
   '
   Public eMailG As String
   Public eMailS As String
   ' 
   Public collEstados As New Collection
   ' 
   Public Const prmZona = ""
   Public Const FecDemo = ""
   '
   Public MdiMenu                    'MDIForm (Menú principal).
   Public FormIni                    'Formulario inicial.
   Public MenuIni                    'Menú inicial.
   Public formAct As Form
   Public OcultarMenu As Boolean
   Public cfgShowFrmFondo As Boolean 'Mostrar Form. accesos directos.
   '
   '*** CONEXION DB. ***
   Public Svr As String = ""                       'Server DB.
   Public PRV As String = "SQLOLEDB"               'Proveedor de Datos.
   Public DSN As String = ""                       'ODBC.
   Public Uid As String                            'User Id.
   Public Pwd As String                            'Password.
   Public LGR As Boolean                           'Login Right.
   Public RPT As String = ""                       'Reportes.
   Public DBN As String = ""                       'Base de Datos.
   Public DBT As String = ""                       'DB. Temporal.
   Public cODBC As String                          'Cadena de Conexión ODBC.
   Public TrustedCnx As Boolean = True             'Conexión de Confianza.
   Public AutDB As Boolean = True                  'Autentica usuario en la Base de Datos.
   Public GroupName As String                      'Nombre de Grupo o Función en la Db.
   Public usrAdmin As Boolean                      'Indica si el usuario actual es el administrador de la DB.
   Public SLL As Boolean                           'Usuario de Solo Lectura.
   Public UsrDb As String                          'Usuario de la DB.
   Public PwdDb As String                          'Pwd de la DB.
   Public regPID As String                         'Clave de Registro.
   '
   Public strDEL As String                         'String p/Delete.
   Public strFEC As String = "'"                   'Tilde(SQL) o Numeral(JET)
   Public strLIKE As String = "%"                  '% (SQL) o * (Jet) p/LIKE.
   '
   Public FormatFecha As String = "yyyyMMdd"            'Formato p/Consulta de Fechas.
   Public FormatFechaHora As String = "yyyyMMdd HH:mm"  'Formato para guardar SmallDateTime.
   Public FormatFecha2359 As String = "yyyyMMdd 23:59"  'Formato para guardar SmallDateTime.
   Public FormatFechaVenc As String = "yyyyMM"          'Formato p/Consulta Fecha de Vencimiento.
   Public Const FormatCDATE = "yyyy,MM,dd"
   Public Const FormatCDateTime = "yyyy,MM,dd HH:mm"
   Public Const PromptCuit = "__-________-_"
   Public Const PromptNroIp = "___.___.___.___"
   Public Const PromptFax = "(    )-          "
   Public Const Meses = 12
   Public Const MaskCuit = "  -        - "
   Public Const MaskDNI = "###,###,##0"
   Public Const PrimerItemCb = "(Seleccionar)"
   '
   Public LastKey As Char
   '
   Sub ConfigIni(Optional Prueba As Boolean = False)
      '
      Dim DirSist As String
      '
      Empresa = EmpAbr
      NombrePC = GetNombrePC()
      DirSist = EmpAbr & "\" & Sistema
      '
      If Not System.IO.Directory.Exists(Raiz & DirSist) Then
         System.IO.Directory.CreateDirectory(Raiz & DirSist)
      End If
      '
      ArchivoIni = Raiz & DirSist & "\Config" & IIf(Prueba, "2", "") & ".ini"
      ArchivoCfg = Raiz & DirSist & "\Config" & IIf(Prueba, "2", "") & ".cfg"
      '
      cfpFontSize = 8
      prmConMedicam = False
      prmSepMedicam = False
      '
      prmIdioma = "ESPAÑOL"
      '
      If Dir(ArchivoCfg) <> "" Then
         GetVarArchivoPrm()
      End If
      '
      'If Globalization.CultureInfo.CurrentCulture.ToString <> "es-AR" Then
      '   My.Application.ChangeCulture("es-AR")
      'End If
      '
      Dim cinfo As Globalization.CultureInfo = Thread.CurrentThread.CurrentCulture.Clone()
      cinfo.NumberFormat.NumberDecimalSeparator = "."
      cinfo.NumberFormat.CurrencyDecimalSeparator = "."
      cinfo.NumberFormat.CurrencyDecimalDigits = 2
      cinfo.DateTimeFormat.ShortTimePattern = "HH:mm"
      cinfo.DateTimeFormat.LongTimePattern = "HH:mm:ss"
      cinfo.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
      Thread.CurrentThread.CurrentCulture = cinfo
      '
   End Sub
   '
   Function GetVarTxt(ByVal Archivo As String, ByVal Variable As String, Optional ByVal Def As String = "") As String

      Dim Linea As String
      Dim r As String = ""

      If Archivo <> "" Then
         If Dir(Archivo) <> "" Then
            Dim f As New System.IO.StreamReader(Archivo)
            Do
               Linea = f.ReadLine()
               If Not Linea Is Nothing Then
                  If Left(Linea, Len(Variable)) = Variable Then
                     r = Trim(Right(Linea, Len(Linea) - Len(Variable) - 1))
                     Exit Do
                  End If
               End If
            Loop Until Linea Is Nothing
            '
            f.Close()

         End If
         '
         If r = "" Then
            If Def <> "" Then
               r = Def
            End If
         End If
      End If

      Return r

   End Function
   '
   Sub GuardaConfigTxt(Optional ByVal Archivo As String = "")
      '
      Dim cDBC As String
      '
      cDBC = DBT
      ReemplazaChar(cDBC, "..", "")
      ReemplazaChar(cDBC, ".dbo.", "")
      '
      If Archivo = "" Then
         Archivo = ArchivoIni
      End If
      '
      Dim f As New System.IO.StreamWriter(Archivo)
      '
      f.WriteLine("Usuario=" & Uid)
      f.WriteLine("Server=" & Svr)
      f.WriteLine("Proveedor=" & PRV)
      f.WriteLine("DataBase=" & DBN)
      f.WriteLine("DBTemp=" & cDBC)
      f.WriteLine("ODBC=" & DSN)
      f.WriteLine("Reportes=" & RPT)
      f.WriteLine("TrustedCnx=" & IIf(TrustedCnx, 1, 0))
      f.WriteLine("AutDB=" & IIf(AutDB, 1, 0))
      f.WriteLine("UsrDB=" & UsrDb)
      f.WriteLine("PwdDB=" & Encrypt(PwdDb))
      f.WriteLine("PID=" & regPID)
      f.Close()
      '
   End Sub
   '
   Sub GuardarArchivoPrm(Optional ByVal Archivo As String = "")
      '
      Dim cDBC As String
      '
      cDBC = DBT
      ReemplazaChar(cDBC, "..", "")
      ReemplazaChar(cDBC, ".dbo.", "")
      '
      If Archivo = "" Then
         Archivo = ArchivoCfg
      End If
      '
      Dim f As New System.IO.StreamWriter(Archivo)
      '
      With f
         .WriteLine("Idioma=" & prmIdioma)
         .WriteLine("Sucursal=" & prmSucursal)
         .WriteLine("Caja=" & prmNroCaja)
         .WriteLine("ImprLiq=" & prmImprLiq)
         .WriteLine("VistaPrevia=" & prmVistPrevLiq)
         .WriteLine("AvisoDeuda=" & prmAvisoDeuda)
         .Close()
      End With
      '
   End Sub
   '
   Function TituloAplicacion() As String
      TituloAplicacion = Application.ProductName & " - " & prmEmpNombre & " : " & prmDSucursal & " - " & prmDDepartamento
   End Function
   '
   Sub CapturaConfig()
      '
      frmMenu.BarStatus.Text = "Captura Config..."
      '
      cfgSegurid = BuscarCfg("cfgSegurid", "S")
      '
      cfgNroFactA = BuscarCfg("cfgNroFactA", 0)
      cfgNroFactB = BuscarCfg("cfgNroFactB", 0)
      cfgNroFactC = BuscarCfg("cfgNroFactC", 0)
      '
      cfgNroRboA = BuscarCfg("cfgNroRboA", 0)
      cfgNroRboB = BuscarCfg("cfgNroRboB", 0)
      cfgNroRboC = BuscarCfg("cfgNroRboC", 0)
      cfgNroRboX = BuscarCfg("cfgNroRboX", 0)
      cfgImpRboX = CBool(BuscarCfg("cfgImpRboX", 0))
      '
      cfgNContrato = BuscarCfg("cfgNContrato", 0)
      cfgNroLiqP = BuscarCfg("cfgNroLiqP", 0)
      cfgNroRetG = BuscarCfg("cfgNroRetG", 0)
      cfgNroPago = BuscarCfg("cfgNroPago", 0)
      cfgNroTransf = BuscarCfg("cfgNroTransf", 0)
      cfgNroCobro = BuscarCfg("cfgNroCobro", 0)
      cfgNroCajaMN = BuscarCfg("cfgNroCajaMN", 0)
      '
      cfgIntDiaMin = BuscarCfg("cfgIntDiaMin", 0.01)
      cfgIntDiario = BuscarCfg("cfgIntDiario", 0.02)
      cfgIntDiaMax = BuscarCfg("cfgIntDiaMax", 0.03)
      '
      cfgCodAutSup = BuscarCfg("cfgCodAutSup")
      cfgCodigoAlq = BuscarCfg("cfgCodigoAlq")
      cfgCodigoBon = BuscarCfg("cfgCodigoBon")
      cfgCodigoAdl = BuscarCfg("cfgCodigoAdl")
      cfgCodigoExp = BuscarCfg("cfgCodigoExp")
      cfgCodigoSel = BuscarCfg("cfgCodigoSel")
      cfgCodigoMdp = BuscarCfg("cfgCodigoMdp")
      cfgCodigoCAd = BuscarCfg("cfgCodigoCAd")
      cfgCodigoHnA = BuscarCfg("cfgCodigoHnA")
      cfgCodigoHnV = BuscarCfg("cfgCodigoHnV")
      cfgCodigoICF1 = BuscarCfg("cfgCodigoICF1")
      cfgCodigoICF2 = BuscarCfg("cfgCodigoICF2")
      cfgCodigoIDf1 = BuscarCfg("cfgCodigoIDf1")
      cfgCodigoIDf2 = BuscarCfg("cfgCodigoIDf2")
      cfgCodigoInt = BuscarCfg("cfgCodigoInt")
      cfgCodigoIva = BuscarCfg("cfgCodigoIva")
      cfgCodigoRGan = BuscarCfg("cfgCodigoRGan")
      cfgCodigoVCar = BuscarCfg("cfgCodigoVCar")
      cfgCodigoSen = BuscarCfg("cfgCodigoSen")
      '
      cfgAdelMayProy = BuscarCfg("cfgAdelMayProy", False)
      cfgMaxAlqSIva = BuscarCfg("cfgMaxAlqSIva", 0)
      cfgCobHonCont = BuscarCfg("cfgCobHonCont", 0)
      cfgLiqVenCur = CBool(BuscarCfg("cfgLiqVenCur", 0))
      cfgFormatCod = BuscarCfg("cfgFormatCod", "000")
      '
      cfgMesesAlqC = BuscarCfg("cfgMesesAlqC", 36)
      cfgMesesAlqP = BuscarCfg("cfgMesesAlqP", 24)
      cfgMesesAlqMax = BuscarCfg("cfgMesesAlqMax", cfgMesesAlqC)
      cfgComisiAdm = BuscarCfg("cfgComisiAdm", 0)
      cfgMaxMesAdl = BuscarCfg("cfgMaxMesAdl", 0)
      cfgMesesAct = BuscarCfg("cfgMesesAct", 0)
      '
      cfgSellComSG = BuscarCfg("cfgSellComSG", 1.4)
      cfgSellComCG = BuscarCfg("cfgSellComCG", 2.8)
      cfgSellParSG = BuscarCfg("cfgSellParSG", 1.4)
      cfgSellParCG = BuscarCfg("cfgSellParCG", 13)
      cfgSellMesDep = BuscarCfg("cfgSellMesDep", 1.4)
      cfgFoliadoCom = BuscarCfg("cfgFoliadoCom", 5)
      cfgFoliadoPart = BuscarCfg("cfgFoliadoPart", 5)
      cfgSellComDep = BuscarCfg("cfgSellComDep", 1.4)
      cfgSellParDep = BuscarCfg("cfgSellParDep", 1.4)
      cfgSellMaxNoImp = BuscarCfg("cfgSellMaxNoImp", 12000.0)
      '
      cfgNomEmp = BuscarCfg("cfgNomEmp")
      cfgDomEmp = BuscarCfg("cfgDomEmp")
      cfgCPosEmp = BuscarCfg("cfgCPosEmp")
      cfgLocEmp = BuscarCfg("cfgLocEmp")
      cfgIvaEmp = BuscarCfg("cfgIvaEmp")
      cfgEmiteComp = BuscarCfg("cfgEmiteComp")
      cfgCuitEmp = BuscarCfg("cfgCuitEmp")
      cfgProvEmp = BuscarCfg("cfgProvEmp")
      cfgTelEmp = BuscarCfg("cfgTelEmp")
      cfgEMailEmp = BuscarCfg("cfgEMailEmp")
      'cfgEMailPwd = BuscarCfg("cfgEMailPwd")
      '
      cfgCntDigCtas = BuscarCfg("cfgCntDigCtas", 10)
      cfgCotDollar = BuscarCfg("cfgCotDollar", 1)
      cfgPerGenCmp = BuscarCfg("cfgPerGenCmp")
      '
      cfgCtaVrs1 = BuscarCfg("cfgCtaVrs1")
      cfgCtaVrs2 = BuscarCfg("cfgCtaVrs2")
      '
      cfgUbicDocs = BuscarCfg("cfgUbicDocs")
      cfgUltimaAct = BuscarCfg("cfgUltimaAct")
      '
      cfgCtaMadreInq = BuscarCfg("cfgCtaMadreInq")
      cfgCtaMadrePrt = BuscarCfg("cfgCtaMadrePrt")
      cfgCtaMadreAdl = BuscarCfg("cfgCtaMadreAdl")
      cfgCtaProvVarios = BuscarCfg("cfgCtaProvVarios")
      cfgCtaCajaRec = BuscarCfg("cfgCtaCajaRec")
      cfgGtosBancPT = BuscarCfg("cfgGtosBancPT", 0.0)
      cfgGtosBancSF = BuscarCfg("cfgGtosBancSF", 0.0)
      cfgGtosBancIva = BuscarCfg("cfgGtosBancIva", False)
      cfgGenDifComprob = BuscarCfg("cfgGenDifComprob", False)
      cfgGenFactCom = BuscarCfg("cfgGenFactCom", False)
      '
      cfgFecIniAct = BuscarCfg("cfgFecIniAct", "01/01/01")
      '
      cfgCtaInqUnica = BuscarCfg("cfgCtaInqUnica", False)
      cfgCtaPrtUnica = BuscarCfg("cfgCtaPrtUnica", False)
      cfgCtaAdlUnica = BuscarCfg("cfgCtaAdlUnica", False)
      cfgCtaPrvUnica = BuscarCfg("cfgCtaPrvUnica", False)
      '
      cfgSmtpPort = BuscarCfg("cfgSmtpPort", 0)
      cfgSmtpServ = BuscarCfg("cfgSmtpServ", "")
      cfgEnablSSL = BuscarCfg("cfgEnablSSL", False)
      cfgSmtpCta = BuscarCfg("cfgSmtpCta", "")
      cfgSmtpPwd = BuscarCfg("cfgSmtpPwd", "")
      cfgSmtpCtaAdm = BuscarCfg("cfgSmtpCtaAdm", "")
      cfgSmtpPwdAdm = BuscarCfg("cfgSmtpPwdAdm", "")
      cfgEmailDest = BuscarCfg("cfgEmailDest", "")
      '
      cfgShowFrmFondo = BuscarCfg("cfgShowFrmFondo", False)
      '
      If cfgNomEmp <> regNomEmp Then
         '*** SistNoReg( False) ***
      End If
      '
      NombrePC = GetNombrePC()
      '
      frmMenu.BarStatus.Text = "Captura Config. OK"
      '
   End Sub
   '
   Sub GetVarArchivoPrm()
      '
      prmSucursal = Val(GetVarTxt(ArchivoCfg, "Sucursal", "0"))
      prmDepart = Val(GetVarTxt(ArchivoCfg, "Depart", "0"))
      regUsr = GetVarTxt(ArchivoCfg, "Usuario", "Admin")
      cfgNoImpCmpAut = GetVarTxt(ArchivoCfg, "NoImpCmpAut", "False")
      cfgVistaPrevInf = GetVarTxt(ArchivoCfg, "VistaPrevInf", "True")
      prmNroCaja = Val(GetVarTxt(ArchivoCfg, "Caja", "1"))
      prmImprLiq = GetVarTxt(ArchivoCfg, "ImprLiq", "False")
      prmIdioma = GetVarTxt(ArchivoCfg, "Idioma", "ESPAÑOL")
      'regPID = GetVarTxt(ArchivoCfg, "PID")
      regFacturar = GetVarTxt(ArchivoCfg, "Facturar", "False")
      regFontSize = Val(GetVarTxt(ArchivoCfg, "FontSize"))
      prmOcultarMenus = GetVarTxt(ArchivoCfg, "OcultarMenus", "False")
      '
   End Sub
   '
End Module
