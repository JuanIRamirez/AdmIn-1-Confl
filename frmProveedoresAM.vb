Public Class frmProveedoresAM
   '
   Public EmpresaId As Int16
   Public SoloVer As Boolean
   Public Alta As Boolean
   Public Proveedor As Long
   '
   Dim Rs As New OleDb.OleDbCommand
   Dim Dr As OleDb.OleDbDataReader
   '
   Dim TipoIva As String   ' Integer
   Dim Localidad As Long
   Dim cCuit As String
   Dim Provincia As Integer
   Dim CondVenta As Integer
   Dim Vendedor As Integer
   Dim CtaCont As String
   Dim BloqueoVta As Byte
   '
   Private Sub frmProveedoresAM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
      TabReturn(e.KeyChar)
   End Sub
   '
   Private Sub frmProveedoresAM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      '
      GetRegForm(Me)
      '
      If Proveedor = 0 Then
         Alta = True
      End If
      '
      Me.Text = Me.Text & " - " & IIf(Alta, "Alta", "Edición")
      '
      If Alta Then
         If SuperaRegistros("Proveedores") Then
            DeshabForm(Me)
            Exit Sub
         End If
      End If
      '
      Rs.Connection = cn
      '
      'ArmaComboItem(cboEmpresa, "Empresas", "EmpresaId", "EmpNombre", "EmpNombre", "(Todas)", "EmpresaId <> 0")
      'PosCboItem(cboEmpresa, EmpresaId)
      '
      'ArmaComboItem(cboProvincia, "Provincias", "Provincia", "Nombre", "Nombre", "(Provincia)")
      ArmaCombo(cboLocalidad, "Descrip", "Localidad", , , "Descrip", "(Todas)")
      ArmaCombo(cboTipoIva, "Descrip", "TipoIva", "Descrip", , , "(Seleccionar)")
      'ArmaComboItem(cboCondVenta, "CondVenta", "CondVenta", , , "(Cond.Venta)")
      'ArmaComboItem(cboVendedor, "Vendedores", "Vendedor", "Nombre", "Nombre", "(Ninguno)", "Vendedor <> 0")
      'ArmaComboItem(cboBloqueoVta, "BloqueoVta", "BloqueoVta", "BVtaDescrip", "BVtaDescrip")
      '
      If SisContable Then
         ArmaCombo(cboCtaCont, "Descrip", "PlanCtas", "", "", "Descrip", "RecAsi <> 0")
         cboCtaCont.Enabled = True
      Else
         'cbCuenta.Enabled = False
         cboCtaCont.Enabled = False
      End If
      '
      If Alta Then
         tbCodigo.Text = CapturaDato(Cn, "Proveedores", "ISNULL(MAX(Codigo), 0)", "") + 1
         'cboBloqueoVta.Enabled = False
      Else
         tbCodigo.Enabled = False
         With Rs
            .CommandText = "SELECT * FROM Proveedores WHERE Codigo = " & Proveedor
            Dr = Rs.ExecuteReader
         End With
         With Dr
            If .Read Then
               'If !Empresaid <> 0 Then
               'PosCboItem(cboEmpresa, !EmpresaId)
               'End If
               tbCodigo.Text = !Codigo
               tbNombre.Text = !Nombre
               tbDomicilio.Text = !Domicilio & ""
               tbContacto.Text = !Contacto & ""
               tbTelefono.Text = !Telefono & ""
               tbFax.Text = !Fax & ""
               tbEMail.Text = !Email & ""
               If IsDBNull(!Cuit) Then
                  tbCuit.Text = MaskCuit
                  cCuit = ""
               Else
                  tbCuit.Text = !Cuit
                  cCuit = !Cuit
               End If
               If Trim(cCuit) = Trim(MaskCuit) Then
                  cCuit = ""
               End If
               'If Not IsDBNull(!Dias) Then
               'txtDias.Text = !Dias
               'End If
               '
               'If Not IsDBNull(!Vendedor) Then
               'Vendedor = !Vendedor
               'End If
               '
               txtCodPostal.Text = !Cod_Postal & ""
               '
               'PosicionarComboItem(cboProvincia, CapturaDato(Cn, "Localidades", "Provincia", "Localidad = " & !Localidad))
               '
               'PosicionarComboItem(cboLocalidad, !Localidad)
               cboLocalidad.Text = !Localidad
               cboTipoIva.Text = CapturaDato(Cn, "TipoIva", "Descrip", "Codigo = '" & !TipoIva & "'")
               'PosCboItem(cboCondVenta, !CondVenta)
               'PosCboItem(cboVendedor, Vendedor)
               'PosCboItem(cboBloqueoVta, !BloqueoVta)
               '
               If SisContable Then
                  'cbCuenta.ListIndex = -1
                  'For I = 0 To cbCuenta.ListCount - 1
                  '   If cbCuenta.List(I) = !CtaCont Then
                  '      cbCuenta.ListIndex = I
                  '   End If
                  'Next I
                  cboCtaCont.Text = CapturaDato(Cn, "PlanCtas", "Descrip", "CtaCont = '" & !CtaCont & "'")
               End If
               '
               'If Not IsDBNull(!TipoMargen) Then
               '   If !TipoMargen = "A" Then
               '      optMargenAuto.Checked = True
               '   ElseIf !TipoMargen = "M" Then
               '      optMargenMan.Checked = True
               '   End If
               'End If
               ''
               'If Not IsDBNull(!Margen) Then
               '   txtMargen.Text = !Margen
               'End If
               ''
               'If Not IsDBNull(!LimCredito) Then
               '   txtLimCredito.Text = !LimCredito
               'End If
               ''
               'If Not IsDBNull(!BonifExtra) Then
               '   txtBonifExtra.Text = !BonifExtra
               'End If
               '
            End If
      .Close()
         End With
      End If
      '
      Exit Sub
      '
      'mError:
      '        MsgBox("ERROR: " & Err.Number & " - " & Err.Description)
      '        DeshabForm(Me)
      '
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
   '
   'Private Sub cboBloqueoVta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
   '   With cboBloqueoVta
   '      If .SelectedIndex > 0 Then
   '         BloqueoVta = .SelectedValue
   '      Else
   '         BloqueoVta = 0
   '      End If
   '   End With
   'End Sub
   '
   Private Sub cboTipoIva_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoIva.SelectedIndexChanged
      'With cboTipoIva
      'If .SelectedIndex > 0 Then
      'TipoIva = .SelectedValue
      'Else
      'TipoIva = 0
      'End If
      'End With
      With cboTipoIva
         If .SelectedIndex > 0 Then
            TipoIva = CapturaDato(Cn, "TipoIva", "Codigo", "Descrip = '" & cboTipoIva.Text & "'")
         Else
            TipoIva = ""
         End If
      End With
      With tbCuit
         If IsDBNull(CapturaDato(Cn, "TipoIva", "EmiteComp", "Codigo = '" & TipoIva & "'")) Then
            .Text = MaskCuit
            .Enabled = False
         Else
            If cCuit <> "" Then
               .Text = cCuit
            End If
            .Enabled = True
         End If
      End With
   End Sub
   '
   Private Sub cboCondVenta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCondVenta.SelectedIndexChanged
      'Dim PagoDif As Boolean
      With cboCondVenta
         If .SelectedIndex > 0 Then
            CondVenta = .SelectedValue
         Else
            CondVenta = 0
         End If
      End With
      'PagoDif = CapturaDato(cn, "CondVenta", "PagoDif", "CondVenta = " & CondVenta)
      'txtDias.Enabled = PagoDif
      'lblDias.Enabled = PagoDif
      'lblLimCredito.Enabled = PagoDif
      'txtLimCredito.Enabled = PagoDif
   End Sub
   '
   Private Sub cboProvincia_Change()
      'PintarCb(cboProvincia)
   End Sub
   '
   'Private Sub cboProvincia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboProvincia.SelectedIndexChanged
   '   With cboProvincia
   '      If .SelectedIndex > 0 Then
   '         Provincia = .SelectedValue
   '      Else
   '         Provincia = 0
   '      End If
   '   End With
   '   ArmaComboItem(cboLocalidad, "Localidades", "Localidad", "Nombre", "Nombre", , IIf(Provincia = 0, "", "Provincia = " & Provincia))
   'End Sub
   '
   Private Sub cboLocalidad_Change()
      'PintarCb(cboLocalidad)
   End Sub
   '
   Private Sub cboLocalidad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLocalidad.SelectedIndexChanged
      With cboLocalidad
         If .SelectedIndex > 0 Then
            Localidad = .SelectedValue
         Else
            Localidad = 0
         End If
      End With
      If Alta Then
         'txtCodPostal.Text = CapturaDato(Cn, "Localidad", "CodPostal", "Localidad = " & Localidad) & ""
      End If
   End Sub
   '
   Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
      If ValidaCampos() Then
         Guardar()
         ' ***VER*** 'frmProveedores.ActData()
         Me.Close()
      End If
   End Sub
   '
   'Private Sub optMargenDif_Click()
   '   txtMargen.Enabled = True
   '   lblMargen.Enabled = True
   'End Sub
   '
   Private Sub tbCuit_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbCuit.TextChanged
      If tbCuit.Text <> "" And Trim(tbCuit.Text) <> Trim(MaskCuit) Then
         cCuit = tbCuit.Text
      Else
         cCuit = ""
      End If
   End Sub
   '
   Private Sub tbNombre_KeyPress(ByVal KeyAscii As Integer)
      'Mayusculas(KeyAscii)
   End Sub
   '
   Private Function ValidaCampos() As Boolean
      '
      If Val(tbCodigo.Text) = 0 Then
         MensajeTrad("DICodigo>0")
         tbCodigo.Focus()
         Exit Function
      Else
         If Alta Then
            If Not IsNothing(CapturaDato(Cn, "Proveedores", "Nombre", "Codigo = " & tbCodigo.Text)) Then
               MensajeTrad("CodExist")
               tbCodigo.Focus()
               Exit Function
            End If
         End If
      End If
      '
      If tbNombre.Text = "" Then
         MensajeTrad("DINombre")
         tbNombre.Focus()
         Exit Function
      End If
      '
      If TipoIva = "" Then
         MensajeTrad("DITipoIva")
         cboTipoIva.Focus()
         Exit Function
      End If
      '
      If cCuit <> "" Then
         If Not ValCuit(cCuit) Then
            tbCuit.Focus()
            Exit Function
         End If
      End If
      '
      'If CondVenta = 0 Then
      '   MensajeTrad("DICondVenta")
      '   With cboCondVenta
      '      If .Enabled Then
      '         .Focus()
      '      End If
      '   End With
      '   Exit Function
      'End If
      '
      'With txtDias
      '   If .Enabled Then
      '      If Val(.Text) <= 0 Then
      '         MensajeTrad("DIDiasVenc")
      '         .Focus()
      '         Exit Function
      '      End If
      '   End If
      'End With
      '
      'With txtMargen
      '   If .Enabled Then
      '      If Val(.Text) <= 0 Then
      '         MensajeTrad("DIMargenVta")
      '         .Focus()
      '         Exit Function
      '      End If
      '   End If
      'End With
      ''
      'If Not optMargenAuto.Checked And Not optMargenMan.Checked Then
      '   MensajeTrad("DIMargen")
      '   Exit Function
      'End If
      '
      ValidaCampos = True
      '
   End Function
   '
   Private Sub Limpiacampos()
      ModAlgo.LimpiaCtrl(Me)
   End Sub
   '
   Private Sub Guardar()
      '
      'On Error GoTo mError
      '
      'cn.BeginTrans()
      '
      With Rs
         If Alta Then
            .CommandText = "INSERT INTO Proveedores( Codigo, Nombre, Domicilio, Localidad, Cod_Postal, Contacto, Telefono, Fax, Email, TipoIva, Cuit, Cuenta, CondVenta, Usuario, FechaMod) " & _
                            "VALUES(" & tbCodigo.Text & ", " & _
                                  "'" & tbNombre.Text & "', " & _
                                  "'" & tbDomicilio.Text & "', " & _
                                  "'" & cboLocalidad.Text & "', " & _
                                  "'" & txtCodPostal.Text & "', " & _
                                  "'" & tbContacto.Text & "', " & _
                                  "'" & tbTelefono.Text & "', " & _
                                  "'" & tbFax.Text & "', " & _
                                  "'" & tbEMail.Text & "', " & _
                                  "'" & TipoIva & "', " & _
                                  "'" & tbCuit.Text & "', " & _
                                  "'" & CtaCont & "', " & _
                                        CondVenta & ", " & _
                                  "'" & Uid & "', " & _
                                  "'" & Format(Now, FormatFechaHora) & "')"
         Else
            .CommandText = "UPDATE Proveedores SET " & _
                           " Nombre = '" & tbNombre.Text & "', " & _
                           " Domicilio = '" & tbDomicilio.Text & "', " & _
                           " Localidad = '" & cboLocalidad.Text & "', " & _
                           " Cod_Postal = '" & txtCodPostal.Text & "', " & _
                           " Contacto = '" & tbContacto.Text & "', " & _
                           " Telefono = '" & tbTelefono.Text & "', " & _
                           " Fax = '" & tbFax.Text & "', " & _
                           " Email = '" & tbEMail.Text & "', " & _
                           " TipoIva = '" & TipoIva & "', " & _
                           " Cuit = '" & tbCuit.Text & "', " & _
                           " Cuenta = '" & CtaCont & "', " & _
                           " CondVenta = " & CondVenta & ", " & _
                           " Usuario = '" & Uid & "', " & _
                           " FechaMod = '" & Format(Now, FormatFechaHora) & "' " & _
                           "WHERE Codigo = " & Val(tbCodigo.Text)
         End If
         .ExecuteNonQuery()
      End With
      '
      'cn.CommitTrans()
      '
      Proveedor = Val(tbCodigo.Text)
      '
      'mError:
      '        If Err.Number <> 0 Then
      '            MsgBox(Err.Description)
      '        End If
      '
   End Sub
   '
   Private Sub optMargenAuto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
      'txtMargen.Enabled = False
      'lblMargen.Enabled = False
   End Sub
   '
   Private Sub optMargenMan_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
      'txtMargen.Enabled = True
      'lblMargen.Enabled = True
   End Sub
   '
   Private Sub tbCodigo_GotFocus()
      'With tbCodigo
      '    .SelStart = 0
      '    .SelLength = Len(.Text)
      'End With
   End Sub
   '
   Private Sub cbDescCta_Change()
      'PintarCb(cbDescCta, LastKey)
      'If cbDescCta = "" Then
      '    CtaCont = ""
      'End If
   End Sub
   '
   Private Sub cboCtaCont_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCtaCont.SelectedIndexChanged
      CtaCont = CapturaDato(cn, "PlanCtas", "CtaCont", "Descrip = '" & Me.cboCtaCont.Text & "'")
   End Sub
   '
   'Private Sub cbCuenta_Click()
   '   cbDescCta.ListIndex = cbCuenta.ListIndex
   'End Sub
   '
   Private Sub tbCodigo_KeyPress(ByVal KeyAscii As Integer)
      SoloNumeros(KeyAscii, False)
   End Sub
   '
   Private Sub tbEMail_KeyPress(ByVal KeyAscii As Integer)
      'Minusculas(KeyAscii)
   End Sub
   '
   Private Sub txtBonifExtra_KeyPress(ByVal KeyAscii As Integer)
      SoloNumeros(KeyAscii, , , "-")
   End Sub
   '
   Private Sub txtLimCredito_KeyPress(ByVal KeyAscii As Integer)
      SoloNumeros(KeyAscii)
   End Sub
   '
   Private Sub cmdCancelar_Click()
      Me.Close()
   End Sub
   '
   Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
      Me.Close()
   End Sub
   '
   Private Sub tbEMail_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbEMail.KeyPress
      e.KeyChar = LCase(e.KeyChar)
   End Sub
   '
   Private Sub frmProveedoresAM_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
      SetRegForm(Me)
      Me.Dispose()
   End Sub
   '
End Class