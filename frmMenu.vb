Public Class frmMenu
   '
   Dim ArchImg As String
   Dim ImgFondo As Image
   '
   Private Sub Menu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      '
      Me.Text = Sistema & IIf(ModoPrueba, " - (Modo Prueba)", "")
      '
      CapturaConfig()
      CargaTablasBase()
      '
      mRepararDB.Visible = usrAdmin
      mVerificarDB.Visible = usrAdmin
      '
      mParametros.Visible = LGR
      mPermisos.Visible = usrAdmin
      mAuditoria.Visible = LGR
      mp_Compras.Visible = False
      '
      Me.ArmaMenu()
      '
      mUsuariosCC.Enabled = True
      '
      Me.BarStatus.Text = "OK."
      Me.BarUid.Text = "Uid: " & Uid & "."
      Me.BarNomPC.Text = "Host: " & NombrePC & "."
      Me.barServer.Text = "Svr: " & Svr
      Me.barDB.Text = "DB: " & DBN
      '
      ArchImg = BuscarCfg("ImgFondo")
      '
      If ArchImg <> "" Then
         If Dir(ArchImg) = "" Then
            Me.BarStatus.Text = "Img. Fondo no enc."
         Else
            If ArchImg <> "" Then
               ImgFondo = Image.FromFile(ArchImg)
               Me.BackgroundImage = ImgFondo
            End If
         End If
      End If
      '
      If cfgShowFrmFondo Then
         With frmFondo
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me
            .Show()
         End With
      End If
      '
   End Sub
   '
   Private Sub ArmaMenu()
      Dim i As Int16
      With MenuStrip1
         For i = 0 To .Items.Count - 1
            If TieneHijos(.Items(i)) Then
               RecorrerMenuItem(.Items(i))
            End If
         Next i
      End With
   End Sub
   '
   Private Function TieneHijos(ByVal MenuItem As ToolStripMenuItem) As Boolean
      Return MenuItem.DropDownItems.Count > 0
   End Function
   '
   Private Sub RecorrerMenuItem(ByVal MenuItem As ToolStripMenuItem)
      Dim mItem As Object
      For Each mItem In MenuItem.DropDownItems()
         If TypeOf mItem Is ToolStripMenuItem Then
            If TieneHijos(mItem) Then
               RecorrerMenuItem(mItem)
            Else
               If LCase(Strings.Left(mItem.Name, 3)) = "mp_" Then
                  mItem.Enabled = True
               Else
                  mItem.Enabled = TienePermiso(Cn, Uid, mItem.Name)
               End If
            End If
         End If
      Next
   End Sub
   '
   Private Sub mp_Restaurar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mp_Restaurar.Click
      frmRestValDef.Show(Me)
   End Sub
   '
   Private Sub mRepararDB_Click(sender As Object, e As EventArgs) Handles mRepararDB.Click
      If TienePermiso(Cn, Uid, mRepararDB.Name) Then
         FrmRepDb.ShowDialog()
      End If
   End Sub
   '
   Private Sub mParametros_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mParametros.Click
      If TienePermiso(Cn, Uid, Me.mParametros.Name, True) Then
         With frmParametros
            '.MdiParent = Me
            .ShowDialog()
         End With
      End If
   End Sub
   '
   Private Sub mCajaAlta_Click(sender As Object, e As EventArgs) Handles mCajaAlta.Click
      If TienePermiso(Cn, Uid, Me.mCajaAlta.Name, True) Then
         Dim Frm As New frmCajaAM
         With Frm
            '.MdiParent = Me
            .Alta = True
            .ShowDialog()
         End With
      End If
   End Sub
   '
   Private Sub mCajaABM_Click(sender As Object, e As EventArgs) Handles mCajaABM.Click
      If TienePermiso(Cn, Uid, Me.mCajaABM.Name, True) Then
         Dim Frm As New frmCaja
         With Frm
            .MdiParent = Me
            .Show()
         End With
      End If
   End Sub
   '
   Private Sub mCajaTransf_Click(sender As Object, e As EventArgs) Handles mCajaTransf.Click
      If TienePermiso(Cn, Uid, Me.mCajaTransf.Name, True) Then
         Dim Frm As New FrmCajaTransf
         With Frm
            .MdiParent = Me
            .Alta = True
            .Show()
         End With
      End If
   End Sub
   '
   Private Sub mLiqPropietAlta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mAltaLiqPro.Click
      AltaLiqProp()
   End Sub
   '
   Sub AltaLiqProp()
      If TienePermiso(Cn, Uid, Me.mAltaLiqPro.Name, True) Then
         Dim Frm As New frmLiqPropiet
         With Frm
            '.MdiParent = Me
            Frm.ShowDialog(Me)
         End With
      End If
   End Sub
   '
   Private Sub mLiqPropietMod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mModLiqPro.Click
      If TienePermiso(Cn, Uid, Me.mModLiqPro.Name, True) Then
         With FrmLiqPropietABM
            .MdiParent = Me
            .Show()
         End With
      End If
   End Sub
   '
   Private Sub VerificarDBToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mVerificarDB.Click
      If usrAdmin Then
         VerificaDb()
         LlenarTraductor()
      Else
         Mensaje("No tiene permisos para esta opción.")
      End If
   End Sub
   '
   Private Sub mAltaContrato_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mAltaContrato.Click
      AltaContrato()
   End Sub
   '
   Sub AltaContrato()
      If TienePermiso(Cn, Uid, Me.mAltaContrato.Name, True) Then
         Dim Frm As New frmContrato
         With Frm
            '.MdiParent = Me
            .ShowDialog()
         End With
      End If
   End Sub
   '
   Private Sub mModContrato_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mModContrato.Click
      If TienePermiso(Cn, Uid, Me.mModContrato.Name, True) Then
         Dim Frm As New frmContratosAbm
         With Frm
            .MdiParent = Me
            .Show()
         End With
      End If
   End Sub
   '
   Private Sub mActContratos_Click(sender As Object, e As EventArgs) Handles mActContratos.Click
      If TienePermiso(Cn, Uid, Me.mActContratos.Name, True) Then
         Dim Frm As New frmContratosAbm
         With Frm
            .MdiParent = Me
            .Actualiz = True
            .Show()
         End With
      End If
   End Sub
   '
   Private Sub mConcProp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mConcProp.Click
      If TienePermiso(Cn, Uid, Me.mConcProp.Name, True) Then
         Dim Frm As New frmPropConc
         With Frm
            .MdiParent = Me
            .Show()
         End With
      End If
   End Sub
   '
   Private Sub mAltaInq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mAltaInq.Click
      If TienePermiso(Cn, Uid, Me.mAltaInq.Name, True) Then
         With frmInquilinosAM
            .Alta = True
            .Inquilino = 0
            .ShowDialog(Me)
         End With
      End If
   End Sub
   '
   Private Sub mMantInq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mMantInq.Click
      Inquilinos()
   End Sub
   '
   Sub Inquilinos()
      If TienePermiso(Cn, Uid, Me.mMantInq.Name, True) Then
         With frmInquilinos
            .MdiParent = Me
            .Show()
         End With
      End If
   End Sub
   '
   Private Sub mGarantes_Click(sender As Object, e As EventArgs) Handles mGarantes.Click
      If TienePermiso(Cn, Uid, Me.mGarantes.Name, True) Then
         Dim frm As New frmGarantes
         With frm
            .MdiParent = Me
            .Show()
         End With
      End If
   End Sub
   '
   Private Sub mAltaLiqInq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mAltaLiqInq.Click
      AltaLiqInq()
   End Sub
   '
   Sub AltaLiqInq()
      If TienePermiso(Cn, Uid, Me.mAltaLiqInq.Name, True) Then
         Dim Frm As New frmLiqInquilinosAM
         With Frm
            .ShowDialog()
            .Dispose()
         End With
      End If
   End Sub
   '
   Private Sub mModLiqInq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mModLiqInq.Click
      If TienePermiso(Cn, Uid, Me.mModLiqInq.Name, True) Then
         With frmLiqInquilinos
            .MdiParent = Me
            .Show()
         End With
      End If
   End Sub
   '
   Private Sub mFactInq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mFactInq.Click
      If TienePermiso(Cn, Uid, Me.mFactInq.Name, True) Then
         With frmFactInquilino
            .MdiParent = Me
            .Show()
         End With
      End If
   End Sub
   '
   Private Sub mChCartera_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mChCartera.Click
      If TienePermiso(Cn, Uid, mChCartera.Name, True) Then
         With frmChCartera
            .MdiParent = Me
            .Show()
         End With
      End If
   End Sub
   '
   Private Sub RecibosPendientesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mLiqInqPend.Click
      If TienePermiso(Cn, Uid, mLiqInqPend.Name, True) Then
         With FrmLiqInquilinosPend
            .MdiParent = Me
            .Show()
         End With
      End If
   End Sub
   '
   Private Sub mCajaList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mCajaList.Click
      If TienePermiso(Cn, Uid, mCajaList.Name, True) Then
         With frmCajaList
            '.MdiParent = Me
            .ShowDialog()
         End With
      End If
   End Sub
   '
   Private Sub mPropiedConcList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mPropiedConcList.Click
      If TienePermiso(Cn, Uid, mPropiedConcList.Name, True) Then
         With frmListConcFijos
            .MdiParent = Me
            .Show()
         End With
      End If
   End Sub
   '
   Private Sub mPropiedadesAlta_Click(sender As Object, e As EventArgs) Handles mPropiedadesAlta.Click
      If TienePermiso(Cn, Uid, mPropiedadesAlta.Name, True) Then
         With frmPropiedadesAM
            '.MdiParent = Me
            .Alta = True
            .ShowDialog()
         End With
      End If
   End Sub
   '
   Private Sub mPropiedades_Click(sender As Object, e As EventArgs) Handles mPropiedades.Click
      Propiedades()
   End Sub
   '
   Sub Propiedades()
      If TienePermiso(Cn, Uid, mPropiedades.Name, True) Then
         With frmPropiedades
            .MdiParent = Me
            .Show()
         End With
      End If
   End Sub
   '
   Private Sub mPropiedCProp_Click(sender As Object, e As EventArgs) Handles mPropiedCProp.Click
      If TienePermiso(Cn, Uid, mPropiedCProp.Name, True) Then
         With frmPropiedades
            .MdiParent = Me
            .CambiarPropiet = True
            .Show()
         End With
      End If
   End Sub
   '
   Private Sub mPropietariosAlta_Click(sender As Object, e As EventArgs) Handles mPropietariosAlta.Click
      If TienePermiso(Cn, Uid, mPropietariosAlta.Name, True) Then
         With frmPropietariosAM
            '.MdiParent = Me
            .Alta = True
            .ShowDialog()
         End With
      End If
   End Sub
   '
   Private Sub mPropietariosABM_Click(sender As Object, e As EventArgs) Handles mPropietariosABM.Click
      Propietarios()
   End Sub
   '
   Sub Propietarios()
      If TienePermiso(Cn, Uid, mPropietariosABM.Name, True) Then
         With frmPropietarios
            .MdiParent = Me
            .Show()
         End With
      End If
   End Sub
   '
   Private Sub mAuditoria_Click(sender As Object, e As EventArgs) Handles mAuditoria.Click
      If TienePermiso(Cn, Uid, mAuditoria.Name, True) Then
         With frmAuditoria
            .MdiParent = Me
            .Show()
         End With
      End If
   End Sub
   '
   Private Sub mOrdenesPagoAbmO_Click(sender As Object, e As EventArgs) Handles mOrdenesPagoAbmO.Click
      If TienePermiso(Cn, Uid, mOrdenesPagoAbmO.Name, True) Then
         With frmOrdenesPago
            .MdiParent = Me
            .cmpInt = "PO"
            .Show()
         End With
      End If
   End Sub
   '
   Private Sub mRegError_Click(sender As Object, e As EventArgs) Handles mRegError.Click
      If TienePermiso(Cn, Uid, mRegError.Name, True) Then
         With frmRegError
            .MdiParent = Me
            .Show()
         End With
      End If
   End Sub
   '
   Private Sub mConceptos_Click(sender As Object, e As EventArgs) Handles mConceptos.Click
      If TienePermiso(Cn, Uid, mConceptos.Name, True) Then
         With frmConceptos
            .MdiParent = Me
            .Show()
         End With
      End If
   End Sub
   '
   Private Sub mUsuarios_Click(sender As Object, e As EventArgs) Handles mUsuarios.Click
      If TienePermiso(Cn, Uid, mUsuarios.Name, True) Then
         With frmUsuarios
            .MdiParent = Me
            .Show()
         End With
      End If
   End Sub
   '
   Private Sub mBancos_Click(sender As Object, e As EventArgs) Handles mBancos.Click
      If TienePermiso(Cn, Uid, mBancos.Name, True) Then
         With frmBancos
            .MdiParent = Me
            .Show()
         End With
      End If
   End Sub
   '
   Private Sub Localidades_Click(sender As Object, e As EventArgs) Handles mLocalidades.Click
      If TienePermiso(Cn, Uid, mLocalidades.Name, True) Then
         Dim Frm As New frmABM
         With Frm
            .AltaAuto = False
            .Tabla = "Localidad"
            .colClave = "LocalidadId"
            .claveNumerica = True
            .AutoNumerico = True
            .colDescrip = "Descrip"
            .titDescrip = "Nombre Localid."
            .colEntero = "Codigo"
            .titEntero = "Cod.Postal"
            .Titulo = "Localidades"
            .ShowDialog()
         End With
      End If
   End Sub
   '
   Private Sub mPropietAgABM_Click(sender As Object, e As EventArgs) Handles mPropietAgABM.Click
      If TienePermiso(Cn, Uid, mPropietAgABM.Name, True) Then
         Dim Frm As New frmABM
         With Frm
            .AltaAuto = False
            .Titulo = "Propietarios: Agrupar"
            .Tabla = "PropietAg"
            .claveNumerica = True
            .AutoNumerico = True
            .colClave = "PropietAgId"
            .colDescrip = "PagDescrip"
            .ColUsuMod = "PagUsuario"
            .ColFecMod = "PagFecMod"
            .ShowDialog()
         End With
      End If
   End Sub
   '
   Private Sub mTipoProp_Click(sender As Object, e As EventArgs) Handles mTipoProp.Click
      If TienePermiso(Cn, Uid, mTipoProp.Name, True) Then
         Dim Frm As New frmABM
         With Frm
            .AltaAuto = False
            .Tabla = "TipoProp"
            .colClave = "Codigo"
            .claveNumerica = False
            .colDescrip = "Descrip"
            .Titulo = "Tipos de Propiedades"
            .ShowDialog()
         End With
      End If
   End Sub
   '
   Private Sub mPropietAg_Click(sender As Object, e As EventArgs) Handles mPropietAg.Click
      If TienePermiso(Cn, Uid, mPropietAg.Name, True) Then
         Dim Frm As New frmPropietAg
         With Frm
            .MdiParent = Me
            .Show()
         End With
      End If
   End Sub
   '
   Private Sub mOrdenPagoAO_Click(sender As Object, e As EventArgs) Handles mOrdenPagoAO.Click
      If TienePermiso(Cn, Uid, mOrdenPagoAO.Name, True) Then
         With frmOrdenesPagoAM
            .MdiParent = Me
            '.Estado = 0
            .Alta = True
            .cmpInt = "PO"
            .Show()
         End With
      End If
   End Sub
   '
   Private Sub mOrdenPagoAgO_Click(sender As Object, e As EventArgs) Handles mOrdenPagoAgO.Click
      If TienePermiso(Cn, Uid, mOrdenPagoAgO.Name) Then
         With frmOrdenPagoVs
            .MdiParent = Me
            .CmpInt = "PO"
            .Estado = 3
            .OrdenPagoId = 0
            .Show()
         End With
      End If
   End Sub
   '
   Private Sub mProveedoresAlta_Click(sender As Object, e As EventArgs) Handles mProveedoresAlta.Click
      If TienePermiso(Cn, Uid, mProveedoresAlta.Name, True) Then
         With frmProveedoresAM
            .MdiParent = Me
            '.Estado = 0
            '.cmpInt = "PO"
            .Show()
         End With
      End If
   End Sub
   '
   Private Sub mProveedores_Click(sender As Object, e As EventArgs) Handles mProveedores.Click
      If TienePermiso(Cn, Uid, mProveedores.Name, True) Then
         With frmProveedores
            .MdiParent = Me
            '.Estado = 0
            '.cmpInt = "PO"
            .Show()
         End With
      End If
   End Sub
   '
   Private Sub mListVarios_Click(sender As Object, e As EventArgs) Handles mListVarios.Click
      If TienePermiso(Cn, Uid, mListVarios.Name) Then
         With frmListVarios
            .MdiParent = Me
            .Show()
         End With
      End If
   End Sub
   '
   Private Sub mRepInquilinos_Click(sender As Object, e As EventArgs) Handles mRepInquilinos.Click
      If TienePermiso(Cn, Uid, mRepInquilinos.Name) Then
         With FrmListInquilinos
            .MdiParent = Me
            .Show()
         End With
      End If
   End Sub
   '
   Private Sub mComprasOtrAlta_Click(sender As Object, e As EventArgs) Handles mComprasOtrAlta.Click
      If TienePermiso(Cn, Uid, mComprasOtrAlta.Name) Then
         With frmComprasOtrAM
            .MdiParent = Me
            .Alta = True
            .Show()
         End With
      End If
   End Sub
   '
   Private Sub mComprasOtr_Click(sender As Object, e As EventArgs) Handles mComprasOtr.Click
      If TienePermiso(Cn, Uid, mComprasOtr.Name) Then
         With frmComprasOtr
            .MdiParent = Me
            .Show()
         End With
      End If
   End Sub
   '
   Private Sub mListInqPend_Click(sender As Object, e As EventArgs) Handles mListInqPend.Click
      If TienePermiso(Cn, Uid, mListInqPend.Name) Then
         Dim Filtro As String = "({LiqInqCab.Estado} = 3 OR {LiqInqCab.Estado} = 1) AND ROUND({LiqInqCab.SaldoPend},1) <> 0"
         ImprimirCrp("LiqInqPend", crptToWindow, Filtro, "Cobros Inquilinos Pendientes")
      End If
   End Sub
   '
   Private Sub mRendPropPend_Click(sender As Object, e As EventArgs) Handles mRendPropPend.Click
      If TienePermiso(Cn, Uid, mRendPropPend.Name) Then
         frmRendPropPend.Show()
      End If
   End Sub
   '
   Private Sub mListRetGan_Click(sender As Object, e As EventArgs) Handles mListRetGan.Click
      If TienePermiso(Cn, Uid, mListRetGan.Name) Then
         frmListRetGan.Show()
      End If
   End Sub
   '
   Private Sub mLiqPropPend_Click(sender As Object, e As EventArgs) Handles mLiqPropPend.Click
      If TienePermiso(Cn, Uid, mLiqPropPend.Name) Then
         With frmLiqPropietPend
            .MdiParent = Me
            .Show()
         End With
      End If
   End Sub
   '
   Private Sub mListVentas_Click(sender As Object, e As EventArgs) Handles mListVentas.Click
      If TienePermiso(Cn, Uid, mListVentas.Name) Then
         With frmListVentas
            '.MdiParent = Me
            .ShowDialog()
         End With
      End If
   End Sub
   '
   Private Sub mPermisos_Click(sender As Object, e As EventArgs) Handles mPermisos.Click
      mPermisos.Checked = Not mPermisos.Checked
   End Sub
   '
   Private Sub mCajaARec_Click(sender As Object, e As EventArgs) Handles mCajaARec.Click
      If TienePermiso(Cn, Uid, mCajaARec.Name) Then
         With frmCajaRec
            .MdiParent = Me
            .Alta = True
            .Show()
         End With
      End If
   End Sub
   '
   Private Sub mListCajaRec_Click(sender As Object, e As EventArgs) Handles mListCajaRec.Click
      If TienePermiso(Cn, Uid, mListCajaRec.Name) Then
         With frmCajaRecList
            .MdiParent = Me
            .Show()
         End With
      End If
   End Sub
   '
   Private Sub mContratosList_Click(sender As Object, e As EventArgs) Handles mContratosList.Click
      If TienePermiso(Cn, Uid, mContratosList.Name) Then
         With frmContratosList
            .MdiParent = Me
            .Show()
         End With
      End If
   End Sub
   '
   Private Sub mCobrosOtrAlta_Click(sender As Object, e As EventArgs) Handles mCobrosOtrAlta.Click
      If TienePermiso(Cn, Uid, mCobrosOtrAlta.Name) Then
         With frmCobrosOtr
            .MdiParent = Me
            .Show()
         End With
      End If
   End Sub
   '
   Private Sub mCobrosOtrABM_Click(sender As Object, e As EventArgs) Handles mCobrosOtrABM.Click
      If TienePermiso(Cn, Uid, mCobrosOtrABM.Name) Then
         With frmCobrosABM
            .CobroComp = False
            .MdiParent = Me
            .Show()
         End With
      End If
   End Sub
   '
   Private Sub mCobrosSeñas_Click(sender As Object, e As EventArgs) Handles mCobrosSeñas.Click
      If TienePermiso(Cn, Uid, mCobrosSeñas.Name) Then
         With frmCobrosABM
            .CobroComp = False
            .Señas = True
            .MdiParent = Me
            .Show()
         End With
      End If
   End Sub
   '
   Private Sub mUsuariosCC_Click(sender As Object, e As EventArgs) Handles mUsuariosCC.Click
      Dim Frm As New frmUsuariosCC
      With Frm
         '.MdiParent = Me
         .ShowDialog()
      End With
   End Sub
   '
   Private Sub mListAdelProp_Click(sender As Object, e As EventArgs) Handles mListAdelProp.Click
      If TienePermiso(Cn, Uid, mListAdelProp.Name) Then
         With frmListAdelPropSdo
            .MdiParent = Me
            .Show()
         End With
      End If
   End Sub
   '
   Private Sub mPropListAdelantos_Click(sender As Object, e As EventArgs) Handles mPropListAdelantos.Click
      If TienePermiso(Cn, Uid, mPropListAdelantos.Name) Then
         With frmListAdelPropSdo
            .MdiParent = Me
            .Show()
         End With
      End If
   End Sub
   '
   Private Sub mBancosMovAlta_Click(sender As Object, e As EventArgs) Handles mBancosMovAlta.Click
      If TienePermiso(Cn, Uid, mBancosMovAlta.Name) Then
         Dim Frm As New frmBancosMovAM
         With Frm
            .MdiParent = Me
            .Alta = True
            .Show()
         End With
      End If
   End Sub
   '
   Private Sub mBancosMovABM_Click(sender As Object, e As EventArgs) Handles mBancosMovABM.Click
      If TienePermiso(Cn, Uid, mBancosMovABM.Name) Then
         With frmBancosMov
            .MdiParent = Me
            .Show()
         End With
      End If
   End Sub
   '
   Private Sub mBancisMovConc_Click(sender As Object, e As EventArgs) Handles mBancisMovConc.Click
      If TienePermiso(Cn, Uid, mBancosMovABM.Name) Then
         With frmBancosMov
            .MdiParent = Me
            .Concilia = True
            .Show()
         End With
      End If
   End Sub
   '
   Private Sub mListConcAdm_Click(sender As Object, e As EventArgs) Handles mListConcAdm.Click
      If TienePermiso(Cn, Uid, mListConcAdm.Name) Then
         With frmListConcAdm
            .MdiParent = Me
            .Show()
         End With
      End If
   End Sub
   '
   Private Sub mListTransf_Click(sender As Object, e As EventArgs) Handles mListTransf.Click
      If TienePermiso(Cn, Uid, mListTransf.Name) Then
         With frmListTransf
            .MdiParent = Me
            .Show()
         End With
      End If
   End Sub
   '
   Private Sub mComprasAlta_Click(sender As Object, e As EventArgs) Handles mComprasAlta.Click
      If TienePermiso(Cn, Uid, mComprasAlta.Name) Then
         With frmComprasAM
            .MdiParent = Me
            '.CompServ = True
            .Alta = True
            .Show()
         End With
      End If
   End Sub
   '
   Private Sub mComprasABM_Click(sender As Object, e As EventArgs) Handles mComprasABM.Click
      If TienePermiso(Cn, Uid, mComprasABM.Name) Then
         With frmCompras
            .MdiParent = Me
            .Show()
         End With
      End If
   End Sub
   '
   Private Sub mCajas_Click(sender As Object, e As EventArgs) Handles mCajas.Click
      If TienePermiso(Cn, Uid, mCajas.Name) Then
         With frmCajas
            .MdiParent = Me
            .Show()
         End With
      End If
   End Sub
   '
   Private Sub mCatGcias_Click(sender As Object, e As EventArgs) Handles mCatGcias.Click
      If TienePermiso(Cn, Uid, mCatGcias.Name) Then
         With frmCatGcias
            .MdiParent = Me
            .Show()
         End With
      End If
   End Sub
   '
   Private Sub mListAlq_Click(sender As Object, e As EventArgs) Handles mListAlq.Click
      If TienePermiso(Cn, Uid, mListAlq.Name) Then
         With frmListAlq
            .Show()
         End With
      End If
   End Sub
   '
   Private Sub mListPropied_Click(sender As Object, e As EventArgs) Handles mListPropied.Click
      If TienePermiso(Cn, Uid, mListPropied.Name) Then
         With frmListPropiedades
            .Show()
         End With
      End If
   End Sub
   '
   Private Sub mListInquilinos_Click(sender As Object, e As EventArgs) Handles mListInquilinos.Click
      If TienePermiso(Cn, Uid, mListInquilinos.Name) Then
         With frmListInquilinos
            .Show()
         End With
      End If
   End Sub
   '
   Private Sub mVentasAlta_Click(sender As Object, e As EventArgs) Handles mVentasAlta.Click
      If TienePermiso(Cn, Uid, mVentasAlta.Name) Then
         With FrmVentasAM
            .Alta = True
            .VentaServ = True
            '.MdiParent = Me
            .Show()
         End With
      End If
   End Sub
   '
   Private Sub mVentasABM_Click(sender As Object, e As EventArgs) Handles mVentasABM.Click
      If TienePermiso(Cn, Uid, mVentasABM.Name) Then
         With frmVentas
            .MdiParent = Me
            .Show()
         End With
      End If
   End Sub
   '
   Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mp_Salir.Click
      Me.Close()
   End Sub
   '
   Private Sub FrmMenu_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
      GuardarAudit("LogOut", "Sale del Sistema", "", "")
      EliminaTmp(Cn)
      Cn.Close()
      Application.Exit()
   End Sub
   '
End Class
