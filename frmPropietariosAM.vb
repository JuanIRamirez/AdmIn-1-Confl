Public Class frmPropietariosAM
   '
   Public Alta As Boolean
   Public Propietario As Int32 = 0
   '
   Dim Trn As OleDb.OleDbTransaction
   Dim cmd As New OleDb.OleDbCommand
   Dim Drd As OleDb.OleDbDataReader
   '
   Dim TipoIva As String = ""
   Dim FormaPago As String = ""
   Dim CatGcias As Byte = 0
   Dim cCodLoc As String = ""
   Dim Banco As Int32 = 0
   Dim comPorc, comImp As Double
   '
   Private Sub frmPropietariosAM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      '
      GetRegForm(Me)
      '
      Me.Text = "Propietarios: " & IIf(Alta, "Alta", "Modificación")
      '
      With cbFormaPago
         .Items.Add("(Seleccionar)")
         .Items.Add("CONTADO")
         .Items.Add("CTA.CTE.")
         .SelectedIndex = 0
      End With
      '
      ArmaCombo(cbTipoIva, "Descrip", "TipoIva", "Descrip")
      ArmaComboItem(cbCatGcias, "CatGcias", , , "Codigo")
      ArmaCombo(cbOcupacion, "Descrip", "Ocupaciones", , , "Descrip")
      ArmaCombo(cbLocalidad, "Descrip", "Localidad", "Descrip")
      ArmaCombo(cbLocEmp, "Descrip", "Localidad", "Descrip")
      ArmaComboItem(cbBarrio, "Barrios", , "Nombre", "Nombre")
      ArmaComboItem(cbBanco, "Bancos", "Banco", "Nombre", "Nombre")
      '
      If SisContable Then
         ArmaCbCuentas()
      Else
         cbCuenta.Enabled = False
         cbCtaAdl.Enabled = False
         tbCuenta.Enabled = False
         tbCtaAdl.Enabled = False
         btAltaCta.Enabled = False
         btAltaCtaAdl.Enabled = False
      End If
      '
      cmd.Connection = Cn
      '
      dtpFechaNac.Value = Today.AddYears(-20)
      '
      If Alta Then
         '
      Else
         With cmd
            .CommandText = "SELECT * FROM Propietarios WHERE Codigo = " & Propietario
            Drd = .ExecuteReader
         End With
         With Drd
            If .Read Then
               tbDni.Text = !DNI
               tbCodigo.Text = !Codigo
               tbCodigo.Enabled = False
               tbNombre.Text = !Nombre
               cbBarrio.Text = !Barrio & ""
               tbDomicilio.Text = !Domicilio & ""
               cCodLoc = !Localidad & ""
               If Val(!Localidad) = 0 Then
                  cbLocalidad.Text = !Localidad
               Else
                  cbLocalidad.Text = CapturaDato(Cn, "Localidad", "Descrip", "Codigo = '" & !Localidad & "'")
               End If
               tbTelefono.Text = !Telefono & ""
               tbTelMovil.Text = !Tel_Movil & ""
               tbEMail.Text = !Email & ""
               tbTelEmp.Text = !Tel_Emp & ""
               If RTrim(!Cuit) <> "  -        -" Then
                  tbCuit.Text = !Cuit & ""
               Else
                  tbCuit.Text = MaskCuit
               End If
               tbEmpresa.Text = !Empresa & ""
               tbDomEmp.Text = !DomEmp & ""
               tbEMailEmp.Text = !eMailEmp & ""
               cbOcupacion.Text = !Condicion & ""
               cbLocEmp.Text = !LocEmp & ""
               cbFormaPago.Text = !FormaPago
               If !Comision > 99 Or !ComFija Then
                  comImp = !Comision
                  optImp.Checked = True
               Else
                  comPorc = !Comision
                  optPorc.Checked = True
               End If
               tbComision.Text = Format(!Comision, "Fixed")
               tbObserv.Text = !Observaciones & ""
               cbBanco.Text = !Banco & ""
               tbTipoCta.Text = !TipoCta & ""
               tbCtaBanco.Text = !NroCta & ""
               tbTitular.Text = !NombreCta & ""
               tbCBU.Text = !CBU & ""
               optActivo.Checked = IIf(!Estado = "A", True, False)
               optInactivo.Checked = IIf(!Estado = "A", False, True)
               tbLegajo.Text = !Legajo & ""
               If IsDBNull(!DocPend) Then
                  chkDocPend.Checked = False
               Else
                  chkDocPend.Checked = !DocPend
               End If
               If IsDBNull(!FechaNac) Then
                  chkFechaNac.Checked = False
               Else
                  dtpFechaNac.Value = Strings.Right(!FechaNac, 2) & "/" & Mid(!FechaNac, 5, 2) & "/" & Strings.Left(!FechaNac, 4)
                  chkFechaNac.Checked = True
               End If
               If IsDBNull(!AlicGan) Then
                  tbAlicGan.Text = ""
               Else
                  tbAlicGan.Text = !AlicGan
                  'lblAlicGan = "%"
               End If
               cbTipoIva.Text = CapturaDato(Cn, "TipoIva", "Descrip", "Codigo = '" & !TipoIva & "'")
               PosCboItem(cbCatGcias, !CatGcias)
               'cbCuenta.Text = CapturaDato(Cn, "PlanCtas", "Descrip", "Cuenta = '" & !Cuenta & "'")
               'cbCtaAdl.Text = CapturaDato(Cn, "PlanCtas", "Descrip", "Cuenta = '" & !CtaAdl & "'")
               tbCuenta.Text = !Cuenta
               tbCtaAdl.Text = !CtaAdl
               '
               btCodSig.Enabled = False
               btPriLib.Enabled = False
               '
            End If
            '
            .Close()
            '
         End With
         '
         'cbLocEmp.Text = CapturaDato(Cn, "Localidad", "Descrip", "Codigo = '" & cCodLoc & "'")
         '
         'With cbTipoIva
         'For i = 0 To .ListCount - 1
         'If .List(i) = rsProp!TipoIva Then
         '.ListIndex = i
         'Exit For
         'End If
         'Next i
         'End With
         '
         'With cbCatGcias
         '   For i = 0 To .ListCount - 1
         '      If .List(i) = rsProp!CatGcias Then
         '         .ListIndex = i
         '         Exit For
         '      End If
         '   Next i
         'End With
         '
         'cbCuenta.ListIndex = -1
         'For i = 0 To cbCuenta.ListCount - 1
         '   If cbCuenta.List(i) = rsProp!Cuenta Then
         '      cbCuenta.ListIndex = i
         '   End If
         'Next i
         ''
         'cbCtaAdl.ListIndex = -1
         'For i = 0 To cbCtaAdl.ListCount - 1
         '   If cbCtaAdl.List(i) = rsProp!CtaAdl Then
         '      cbCtaAdl.ListIndex = i
         '   End If
         'Next i
         '
         'rsProp.Close()
      End If
      '
      TabControl1.SelectedIndex = 0
      '
   End Sub
   '
   Private Sub frmPropietariosAM_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
      TabReturn(e.KeyChar, True)
   End Sub
   '
   Private Sub tbCodigo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbCodigo.KeyPress
      SoloNumeros(e.KeyChar)
   End Sub
   '
   Private Sub btCodSig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCodSig.Click
      If Alta Then
         tbCodigo.Text = Val(CapturaDato(Cn, "Propietarios", "ISNULL(MAX(Codigo),0) + 1", ""))
      End If
   End Sub
   '
   Private Sub btPriLib_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btPriLib.Click
      If Alta Then
         tbCodigo.Text = Val(CapturaDato(Cn, "Propietarios P", "ISNULL(MIN(Codigo),0) + 1", "Codigo > 0 AND NOT EXISTS( SELECT Codigo FROM Propietarios WHERE Codigo = P.Codigo + 1)"))
      End If
   End Sub
   '
   Private Sub chkFechaNac_Click()
      dtpFechaNac.Enabled = (chkFechaNac.Enabled And chkFechaNac.Checked)
   End Sub
   '
   Private Sub cmdListMin_Click()
      '
      ImprimirCrp("PropietMin", crptToWindow, "", Me.Text)
      ImprimirCrp("PropietMinC", crptToWindow, "", Me.Text & " C/Local Comercial")
      ImprimirCrp("PropietMinP", crptToWindow, "", Me.Text & " C/Vivienda Particular")
      '
   End Sub
   '
   Private Sub AltaCuenta(Index As Byte)
      Dim cCuenta As String
      With frmPlanCtasAM
         If Index = 0 Then
            .Descrip = tbNombre.Text
            .cCtaMadre = cfgCtaMadrePrt
            If cfgCtaMadrePrt <> "" Then
               .cCuenta = Strings.Left(cfgCtaMadrePrt, Len(cfgCtaMadrePrt) - Len(tbCodigo)) & tbCodigo.Text
            End If
         Else
            .cCtaMadre = cfgCtaMadreAdl
            If cfgCtaMadreAdl <> "" Then
               .cCuenta = Strings.Left(cfgCtaMadreAdl, Len(cfgCtaMadreAdl) - Len(tbCodigo)) & tbCodigo.Text
            End If
            .Descrip = "ADELANTO " & tbNombre.Text
         End If
         .Alta = True
         .Cerrar = True
         .ShowDialog(Me)
         cCuenta = .cCuenta
         ArmaCbCuentas(Index)
         If Index = 0 Then
            With cbCuenta
               'For i = 0 To .ListCount - 1
               'If .List(i) = cCuenta Then
               '.ListIndex = i
               'Exit For
               'End If
               'Next i
               .Text = cCuenta
            End With
         Else
            With cbCtaAdl
               'For i = 0 To .ListCount - 1
               '   If .List(i) = cCuenta Then
               '      .ListIndex = i
               '      Exit For
               '   End If
               'Next i
               .Text = cCuenta
            End With
         End If
      End With
   End Sub
   '
   Private Sub cmdAceptar_Click(sender As Object, e As EventArgs) Handles cmdAceptar.Click
      If Validar() Then
         Guardar()
         Me.Close()
         'ActivaControles(1)
         'ActivaCampos(False)
      End If
   End Sub
   '
   Private Sub cbLocalidad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbLocalidad.SelectedIndexChanged
      '
      Dim cmd As New OleDb.OleDbCommand
      '
      With cmd
         .Connection = Cn
         .CommandText = "SELECT Codigo FROM Localidad WHERE Descrip = '" & cbLocalidad.Text & "'"
         cCodLoc = .ExecuteScalar & ""
      End With
      '
   End Sub
   '
   Private Sub cboConIVA_Click()
      '*cbTipoIva.ListIndex = cboConIVA.ListIndex
   End Sub
   '
   Private Sub cbTipoIva_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbTipoIva.SelectedIndexChanged
      TipoIva = CapturaDato(Cn, "TipoIva", "Codigo", "Descrip = '" & cbTipoIva.Text & "'")
   End Sub
   '
   Private Sub cbDescGcias_Click()
      '*cbCatGcias.ListIndex = cbDescGcias.ListIndex
   End Sub
   '
   Private Sub tbComision_Change(ByVal sender As Object, ByVal e As EventArgs) Handles tbComision.TextChanged
      If Val(tbComision.Text) <= 0 Then
         tbComision.Text = 0
      ElseIf tbComision.Text > 99 Then
         If optPorc.Checked Then
            tbComision.Text = 99
         End If
      End If
   End Sub
   '
   Private Sub tbcomision_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbComision.KeyPress
      SoloNumeros(e.KeyChar, True)
   End Sub
   '
   'Private Sub tbObservaciones_KeyPress(KeyAscii As Integer)
   '   If KeyAscii = 13 Then
   '      SSTab1.Tab = 1
   '   End If
   'End Sub
   '
   Private Sub tbDni_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbDni.KeyPress
      SoloNumeros(e.KeyChar, False)
   End Sub
   '
   Private Function Validar() As Boolean
      '
      'Dim vCamposVacios As String
      '
      If tbCodigo.Text = "" Then
         MensajeTrad("DICodigo")
         TabControl1.SelectedIndex = 0
         tbCodigo.Focus()
         Return False
      Else
         If Alta Then
            If Not IsNothing(CapturaDato(Cn, "Propietarios", "Codigo", "Codigo = " & tbCodigo.Text)) Then
               MensajeTrad("CodExist")
               TabControl1.SelectedIndex = 0
               tbCodigo.Focus()
               Return False
            End If
         End If
      End If
      '
      If tbDni.Text = "" Then
         MensajeTrad("DIDni")
         TabControl1.SelectedIndex = 0
         tbDni.Focus()
         Return False
      End If
      '
      If tbNombre.Text = "" Then
         MensajeTrad("DIApeNom")
         TabControl1.SelectedIndex = 0
         tbNombre.Focus()
         Return False
      End If
      '
      'If cbOcupacion.Text = "" Then
      '   MensajeTrad("DIOcupacion")
      '   TabControl1.SelectedIndex = 1
      '   cbOcupacion.Focus()
      '   Return False
      'End If
      '
      If cbTipoIva.SelectedIndex = 0 Then
         MensajeTrad("DITipoIva")
         TabControl1.SelectedIndex = 2
         cbTipoIva.Focus()
         Return False
      End If
      '
      Return True
      '
   End Function
   '
   Private Sub Guardar()
      '
      'On Error GoTo mError
      '
      Dim FechaNac As String = "NULL"
      '
      If chkFechaNac.Checked Then
         FechaNac = "'" & Format(dtpFechaNac.Value, FormatFecha) & "'"
      End If
      '
      Trn = Cn.BeginTransaction
      '
      With cmd
         .Transaction = Trn
         '.CommandText = "SELECT * FROM Propietarios WHERE Codigo = " & tbCodigo.Text
         If Alta Then
            .CommandText = "INSERT INTO Propietarios( Codigo, Dni, Nombre, Barrio, Domicilio, Localidad, Telefono, Tel_Emp, Tel_Movil, eMail, CUIT, Empresa, DomEmp, eMailEmp, Condicion, LocEmp, TipoIva, TipoFactura, FormaPago, CatGcias, Comision, Cuenta, CtaAdl, Observaciones, Banco, TipoCta, NroCta, NombreCta, CBU, Estado, Legajo, DocPend, FechaNac, AlicGan, Usuario, FechaMod) " &
                           "VALUES(" & tbCodigo.Text & ", " &
                                 "'" & tbDni.Text & "', " &
                                 "'" & tbNombre.Text & "', " &
                                 "'" & IIf(cbBanco.SelectedIndex = 0, "", cbBarrio.Text) & "', " &
                                 "'" & tbDomicilio.Text & "', " &
                                 "'" & IIf(cbLocalidad.SelectedIndex = 0, "", Trim(cbLocalidad.Text)) & "', " &
                                 "'" & tbTelefono.Text & "', " &
                                 "'" & tbTelEmp.Text & "', " &
                                 "'" & tbTelMovil.Text & "', " &
                                 "'" & tbEMail.Text & "', " &
                                 "'" & tbCuit.Text & "', " &
                                 "'" & tbEmpresa.Text & "', " &
                                 "'" & tbDomEmp.Text & "', " &
                                 "'" & tbEMailEmp.Text & "', " &
                                 "'" & cbOcupacion.Text & "', " &
                                 "'" & Trim(cbLocEmp.Text) & "', " &
                                 "'" & TipoIva & "', " &
                                 "'" & "" & "', " &
                                 "'" & cbFormaPago.Text & "', " &
                                       CatGcias & ", " &
                                       Val(tbComision.Text) & ", " &
                                 "'" & tbCuenta.Text & "', " &
                                 "'" & tbCtaAdl.Text & "', " &
                                 "'" & tbObserv.Text & "', " &
                                       Banco & ", " &
                                 "'" & tbTipoCta.Text & "', " &
                                 "'" & tbCtaBanco.Text & "', " &
                                 "'" & tbTitular.Text & "', " &
                                 "'" & tbCBU.Text & "', " &
                                 "'" & IIf(optActivo.Checked, "A", "I") & "', " &
                                 "'" & tbLegajo.Text & "', " &
                                       IIf(chkDocPend.Checked, 1, 0) & ", " &
                                       FechaNac & ", " &
                                 "'" & tbAlicGan.Text & "', " &
                                 "'" & Uid & "', " &
                                 "'" & Format(Now, FormatFechaHora) & "')"

         Else
            .CommandText = "UPDATE Propietarios SET " &
                           " DNI = '" & tbDni.Text & "', " &
                           " Nombre = '" & tbNombre.Text & "', " &
                           " Barrio = '" & IIf(cbBanco.SelectedIndex = 0, "", cbBarrio.Text) & "', " &
                           " Domicilio = '" & tbDomicilio.Text & "', " &
                           " Localidad = '" & IIf(cbLocalidad.SelectedIndex = 0, "", Trim(cbLocalidad.Text)) & "', " &
                           " Telefono = '" & tbTelefono.Text & "', " &
                           " Tel_Movil = '" & tbTelMovil.Text & "', " &
                           " Email = '" & tbEMail.Text & "', " &
                           " Tel_Emp = '" & tbTelEmp.Text & "', " &
                           " Cuit = '" & tbCuit.Text & "', " &
                           " Empresa = '" & tbEmpresa.Text & "', " &
                           " DomEmp = '" & tbDomEmp.Text & "', " &
                           " eMailEmp = '" & tbEMailEmp.Text & "', " &
                           " Condicion = '" & cbOcupacion.Text & "', " &
                           " LocEmp = '" & Trim(cbLocEmp.Text) & "', " &
                           " TipoIva = '" & TipoIva & "', " &
                           " TipoFactura = '', " &
                           " FormaPago = '" & cbFormaPago.Text & "', " &
                           " CatGcias = " & CatGcias & ", " &
                           " Comision = " & Val(tbComision.Text) & ", " &
                           " Cuenta = '" & tbCuenta.Text & "', " &
                           " CtaAdl = '" & tbCtaAdl.Text & "', " &
                           " Observaciones = '" & tbObserv.Text & "', " &
                           " Banco = " & Banco & ", " &
                           " TipoCta = '" & tbTipoCta.Text & "', " &
                           " NroCta = '" & tbCtaBanco.Text & "', " &
                           " NombreCta = '" & tbTitular.Text & "', " &
                           " CBU = '" & tbCBU.Text & "', " &
                           " Legajo = '" & tbLegajo.Text & "', " &
                           " Estado = '" & IIf(optActivo.Checked, "A", "I") & "', " &
                           " DocPend = " & IIf(chkDocPend.Checked, 1, 0) & ", " &
                           " FechaNac = " & FechaNac & ", " &
                           " AlicGan = '" & tbAlicGan.Text & "', " &
                           " Usuario = '" & Uid & "', " &
                           " FechaMod = '" & Format(Now, FormatFechaHora) & "' " &
                           "WHERE Codigo = " & tbCodigo.Text
         End If
         .ExecuteNonQuery()
      End With
      '
      AltaLocalidadAuto(cbLocalidad.Text, , Trn)
      AltaLocalidadAuto(cbLocEmp.Text, , Trn)
      AgrNuevoBarrio(cbBarrio.Text, Trn)
      '
      Trn.Commit()
      '
   End Sub
   '
   'Private Sub ArmaCbCuentas(Index As Integer)
   '   With rsPlan
   '      .Open("SELECT Cuenta, Descrip FROM PlanCtas WHERE RecAsi <> 0 ORDER BY Descrip", Cn, adOpenForwardOnly, adLockReadOnly)
   '      cbCtaAdl.AddItem ""
   '      cbDCtaAdl.AddItem Traducir("(Ninguna)")
   '      Do Until .EOF
   '         If Index <> 1 Then
   '            cbCuenta.AddItem!Cuenta()
   '            cbDescCta.AddItem!Descrip()
   '         End If
   '         If Index <> 0 Then
   '            cbCtaAdl.AddItem!Cuenta()
   '            cbDCtaAdl.AddItem!Descrip()
   '         End If
   '         .MoveNext()
   '      Loop
   '      .Close()
   '   End With
   'End Sub
   '
   '   Private Sub AbreRecordset()
   '      '
   '      'Adodc1.ConnectionString = Cn
   '      'ActData()

   '      Exit Sub
   '      '
   'mError:
   '      MsgBox("ERROR: " & Err.Number & " - " & Err.Description)
   '      DeshabForm(Me)
   '
   '   End Sub
   '
   '
   Private Sub tbEmailEmp_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbEMail.KeyPress, tbEMailEmp.KeyPress
      e.KeyChar = LCase(e.KeyChar)
   End Sub
   '
   Private Sub cbDescCta_Change()
      'PintarCb(cbDescCta, LastKey)
      cbDescCta_Click()
   End Sub
   '
   Private Sub cbDescCta_Click()
      '*cbCuenta.ListIndex = cbDescCta.ListIndex
   End Sub
   '
   Private Sub cbCuenta_Click()
      '*cbDescCta.ListIndex = cbCuenta.ListIndex
   End Sub
   '
   Private Sub cbDCtaAdl_Change()
      'PintarCb(cbDCtaAdl, LastKey)
      'cbDCtaAdl_Click()
   End Sub
   '
   Private Sub txtAlicGan_KeyPress(KeyAscii As Integer)
      SoloNumeros(KeyAscii)
   End Sub
   '
   Private Sub tNombre_Change()
      Dim UltNro As Integer
      Dim Letra As String
      If Alta Then
         Letra = Strings.Left(tbNombre.Text, 1)
         UltNro = Val(Strings.Right(CapturaDato(Cn, "Propietarios", "MAX(Legajo)", "LEFT(Nombre,1) = '" & Letra & "'"), 3) & "")
         tbLegajo.Text = Letra & PadL(UltNro + 1, "0", 3)
      End If
   End Sub
   '
   Private Sub tbEMail_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbEMail.KeyPress
      e.KeyChar = LCase(e.KeyChar)
   End Sub
   '
   Private Sub cbCatGcias_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCatGcias.SelectedIndexChanged
      With cbCatGcias
         If .SelectedIndex > 0 Then
            CatGcias = .SelectedValue
         Else
            CatGcias = 0
         End If
      End With
      tbAlicGan.Text = CapturaDato(Cn, "CatGcias", "Alicuota", "Codigo = " & CatGcias)
   End Sub
   '
   Private Sub chkFechaNac_CheckedChanged(sender As Object, e As EventArgs) Handles chkFechaNac.CheckedChanged
      dtpFechaNac.Enabled = chkFechaNac.Checked
   End Sub
   '
   Private Sub cbCuenta_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCuenta.SelectedIndexChanged
      tbCuenta.Text = CapturaDato(Cn, "PlanCtas", "Cuenta", "Descrip = '" & cbCuenta.Text & "'")
   End Sub
   '
   Private Sub cbCtaAdl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCtaAdl.SelectedIndexChanged
      tbCtaAdl.Text = CapturaDato(Cn, "PlanCtas", "Cuenta", "Descrip = '" & cbCtaAdl.Text & "'")
   End Sub
   '
   Private Sub tbCuenta_TextChanged(sender As Object, e As EventArgs) Handles tbCuenta.TextChanged
      cbCuenta.Text = CapturaDato(Cn, "PlanCtas", "Descrip", "Cuenta = '" & tbCuenta.Text & "'")
   End Sub
   '
   Private Sub tbCtaAdl_TextChanged(sender As Object, e As EventArgs) Handles tbCtaAdl.TextChanged
      cbCtaAdl.Text = CapturaDato(Cn, "PlanCtas", "Descrip", "Cuenta = '" & tbCtaAdl.Text & "'")
   End Sub
   '
   Private Sub ArmaCbCuentas(Optional Index As Byte = 0)
      If Index = 0 Or Index = 1 Then
         ArmaCombo(cbCuenta, "Descrip", "PlanCtas", "Descrip", "RecAsi <> 0", , "(Seleccionar)")
      End If
      If Index = 0 Or Index = 2 Then
         ArmaCombo(cbCtaAdl, "Descrip", "PlanCtas", "Descrip", "RecAsi <> 0", , "(Seleccionar)")
      End If
   End Sub
   '
   Private Sub btSiguiente_Click(sender As Object, e As EventArgs) Handles btSiguiente.Click
      With TabControl1
         If .SelectedIndex = .TabCount - 1 Then
            .SelectedIndex = 0
         Else
            .SelectedIndex = .SelectedIndex + 1
         End If
      End With
   End Sub
   '
   Private Sub cbBanco_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbBanco.SelectedIndexChanged
      With cbBanco
         If .SelectedIndex > 0 Then
            Banco = .SelectedValue
         Else
            Banco = 0
         End If
      End With
   End Sub
   '
   Private Sub optPorc_CheckedChanged(sender As Object, e As EventArgs) Handles optPorc.CheckedChanged, optImp.CheckedChanged
      If optPorc.Checked Then
         tbComision.Text = comPorc
         If Val(tbComision.Text) > 99 Then
            tbComision.Text = 0
         End If
      Else
         tbComision.Text = comImp
      End If
   End Sub
   '
   Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
      Me.Close()
   End Sub
   '
   Private Sub frmPropietarios_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
      Me.Dispose()
      SetRegForm(Me)
   End Sub
   '
End Class