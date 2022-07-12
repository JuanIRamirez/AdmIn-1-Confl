Public Class frmInquilinosAM
   '
   Public Alta As Boolean
   Public Inquilino As Int32
   '
   Dim Cmd As New OleDb.OleDbCommand
   Dim Drd As OleDb.OleDbDataReader
   Dim Trn As OleDb.OleDbTransaction
   '
   Dim TipoIva As String
   '
   Private Sub frmInquilinosAM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      '
      GetRegForm(Me)
      '
      TraducirForm(Me)
      '
      Cmd.Connection = Cn
      '
      ArmaComboItem(cbLocalidad, "Localidad", , , , "(Seleccionar)")
      ArmaCombo(cbTipoIva, "Descrip", "TipoIva", "Descrip", , , "(Seleccionar)")
      '
      If SisContable Then
         ArmaCombo(cbCtaCont, "Descrip", "PlanCtas", "Descrip", "RecAsi <> 0")
      Else
         cbCtaCont.Enabled = False
         tbCtaCont.Enabled = False
         btCtaCont.Enabled = False
      End If
      '
      tbCodigo.Enabled = Alta
      btCodSig.Enabled = Alta
      btPriLib.Enabled = Alta
      '
      If Not Alta Then
         With Cmd
            .CommandText = "SELECT * FROM Inquilinos WHERE Codigo = " & Inquilino
            Drd = .ExecuteReader
            With Drd
               If .Read Then
                  tbCodigo.Text = !Codigo
                  tbDni.Text = !DNI
                  tbNombre.Text = !Nombre
                  tbTelefono.Text = !Telefono & ""
                  tbEMail.Text = !InqEMail & ""
                  cbLocalidad.Text = !Localidad & ""
                  tbDomicilio.Text = !Domicilio & ""
                  TipoIva = !TipoIva & ""
                  cbTipoIva.Text = CapturaDato(Cn, "TipoIva", "Descrip", "Codigo = '" & TipoIva & "'")
                  If IsDBNull(!Cuit) Then
                     tbCuit.Mask = cfgMaskCuit
                     'tbCuit = "  -        - "
                  Else
                     tbCuit.Text = !Cuit
                  End If
                  '
                  If IsDBNull(!AgRetGan) Then
                     chkAgRetGan.Checked = False
                  Else
                     chkAgRetGan.Checked = !AgRetGan
                  End If
                  '
                  tbObserv.Text = !Observaciones & ""
                  '
                  tbTrabajo.Text = !Trabajo & ""
                  tbTelTrabajo.Text = !TelTrabajo & ""
                  tbDomTrabajo.Text = !DomTrabajo & ""

                  rbActivo.Checked = (!Estado = "A")
                  rbInactivo.Checked = (!Estado = "I")
                  '
                  tbDescEstado.Text = !DescEstado & ""
                  '
                  If SisContable Then
                     PosCombo(cbCtaCont, !Cuenta)
                  End If
                  '
                  If IsDBNull(!DocPend) Then
                        chkDocPend.Checked = False
                     Else
                        chkDocPend.Checked = !DocPend
                     End If
                  Else
                     MensajeTrad("CodNoEnc")
                  DeshabForm(Me)
               End If
               .Close()
            End With
         End With
      End If
      '
   End Sub
   '
   Private Sub frmInquilinosAM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
      TabReturn(e.KeyChar)
   End Sub
   '
   Private Sub tbEMail_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbEMail.KeyPress
      e.KeyChar = LCase(e.KeyChar)
   End Sub
   '
   Private Sub cmdListado_Click()
      'frmListInquilinos.Show()
   End Sub
   '
   Private Sub cbTipoIva_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbTipoIva.SelectedIndexChanged
      '
      With cbTipoIva
         If .SelectedIndex > 0 Then
            TipoIva = CapturaDato(Cn, "TipoIva", "Codigo", "Descrip = '" & cbTipoIva.Text & "'")
         Else
            TipoIva = ""
         End If
      End With
      '
   End Sub
   '
   Private Sub btCtaCont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCtaCont.Click
      '
      'Dim cCuenta As String
      '
      With frmPlanCtasAM
         .Descrip = tbNombre.Text
         .Alta = True
         .Cerrar = True
         .cCtaMadre = cfgCtaMadreInq
         If cfgCtaMadreInq <> "" Then
            .cCuenta = cfgCtaMadreInq.Substring(0, Len(cfgCtaMadreInq) - Len(tbCodigo.Text)) & tbCodigo.Text
         End If
         .ShowDialog(Me)
         'cCuenta = .cCuenta
         ArmaCombo(cbCtaCont, "Descrip", "PlanCtas", "Descrip", "RecAsi <> 0")
         tbCtaCont.Text = .cCuenta
         'For i = 0 To .ListCount - 1
         'If .List(i) = cCuenta Then
         '.ListIndex = i
         'Exit For
         'End If
         'Next i
         'End With
      End With
   End Sub
   '
   Private Sub btCodSig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCodSig.Click
      '
      tbCodigo.Text = Val(CapturaDato(Cn, "Inquilinos", "ISNULL(MAX(Codigo),0) + 1", ""))
      '
   End Sub
   '
   Private Sub btPriLib_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btPriLib.Click
      '
      tbCodigo.Text = Val(CapturaDato(Cn, "Inquilinos I", "ISNULL(MIN(Codigo),0) + 1", "Codigo > 0 AND NOT EXISTS( SELECT Codigo FROM Inquilinos WHERE Codigo = I.Codigo + 1)"))
      '
   End Sub
   '
   Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
      '
      If Validar() Then
         Guardar()
      End If
      '
   End Sub
   '
   Private Sub Estado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbActivo.CheckedChanged, rbInactivo.CheckedChanged
      tbDescEstado.Enabled = rbInactivo.Checked
   End Sub
   '
   'Private Sub cbDescCta_Change()
   '   PintarCb(cbDescCta, LastKey)
   '   cbDescCta_Click()
   'End Sub
   '
   Private Sub cbDescCta_Click()
      '  cbCuenta.ListIndex = cbDescCta.ListIndex
   End Sub
   '
   Private Sub cbCtaCont_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCtaCont.SelectedIndexChanged
      tbCtaCont.Text = CapturaDato(Cn, "PlanCtas", "Cuenta", "Descrip = '" & cbCtaCont.Text & "'") & ""
   End Sub
   '
   Private Function Validar() As Boolean
      '
      If Alta Then
         If Val(tbCodigo.Text) = 0 Then
            MensajeTrad("DebIngCod")
            tbCodigo.Focus()
            Return False
         Else
            If Not IsNothing(CapturaDato(Cn, "Inquilinos", "Codigo", "Codigo = " & tbCodigo.Text)) Then
               MensajeTrad("CodExist")
               tbCodigo.Focus()
               Return False
            End If
         End If
      End If
      '
      If tbNombre.Text = "" Then
         MensajeTrad("DebIngApeNom")
         tbNombre.Focus()
         Return False
      End If
      '
      If TipoIva = "" Then
         MensajeTrad("DITipoIva")
         cbTipoIva.Focus()
         Return False
      End If
      '
      'If cbCuenta = "" Then
      '   MensajeTrad "DICuenta"
      '   Me.cbDescCta.SetFocus
      '   Exit Function
      'End If
      '
      'If cboEstado.Text = "" Then
      'MensajeTrad("DebIngEstado")
      'cboEstado.SetFocus()
      'Exit Function
      'End If
      '
      '
      Return True
      '
   End Function
   '
   Private Sub tDni_Change()
      'If tDni = "" Then tDni = 0
   End Sub
   '
   Private Sub Guardar()
      '
      Try
         '
         Trn = Cn.BeginTransaction
         '
         With Cmd
            '
            .Transaction = Trn
            '
            If Alta Then
               .CommandText = "INSERT INTO Inquilinos( Codigo, DNI, Nombre, Telefono, Domicilio, Localidad, TipoIva, Cuit, Trabajo, TelTrabajo, DomTrabajo, Estado, DescEstado, Observaciones, Cuenta, AgRetGan, DocPend, InqEMail, Usuario, FechaMod) " & _
                              "VALUES(" & tbCodigo.Text & ", " & _
                                          Val(tbDni.Text) & ", " & _
                                    "'" & tbNombre.Text & "', " & _
                                    "'" & tbTelefono.Text & "', " & _
                                    "'" & tbDomicilio.Text & "', " & _
                                    "'" & Trim(cbLocalidad.Text) & "', " & _
                                    "'" & TipoIva & "', " & _
                                    "'" & tbCuit.Text & "', " & _
                                    "'" & tbTrabajo.Text & "', " & _
                                    "'" & tbTelTrabajo.Text & "', " & _
                                    "'" & tbDomTrabajo.Text & "', " & _
                                    "'" & IIf(rbActivo.Checked, "A", "I") & "', " & _
                                    "'" & tbDescEstado.Text & "', " & _
                                    "'" & tbObserv.Text & "', " & _
                                    "'" & tbCtaCont.Text & "', " & _
                                          IIf(chkAgRetGan.Checked, 1, 0) & ", " & _
                                          IIf(chkDocPend.Checked, 1, 0) & ", " & _
                                    "'" & tbEMail.Text & "', " & _
                                    "'" & Uid & "', " & _
                                    "'" & Format(Now, FormatFechaHora) & "')"
            Else
               .CommandText = "UPDATE Inquilinos SET " & _
                              " DNI = " & Val(tbDni.Text) & ", " & _
                              " Nombre = '" & tbNombre.Text & "', " & _
                              " Telefono = '" & tbTelefono.Text & "', " & _
                              " Domicilio = '" & tbDomicilio.Text & "', " & _
                              " Localidad = '" & Trim(cbLocalidad.Text) & "', " & _
                              " TipoIva = '" & TipoIva & "', " & _
                              " Cuit = '" & tbCuit.Text & "', " & _
                              " Trabajo = '" & tbTrabajo.Text & "', " & _
                              " TelTrabajo = '" & tbTelTrabajo.Text & "', " & _
                              " DomTrabajo = '" & tbDomTrabajo.Text & "', " & _
                              " Estado = '" & IIf(rbActivo.Checked, "A", "I") & "', " & _
                              " DescEstado = '" & tbDescEstado.Text & "', " & _
                              " Observaciones = '" & tbObserv.Text & "', " & _
                              " Cuenta = '" & tbCtaCont.Text & "', " & _
                              " AgRetGan = " & IIf(chkAgRetGan.Checked, 1, 0) & ", " & _
                              " DocPend = " & IIf(chkDocPend.Checked, 1, 0) & ", " & _
                              " InqEMail = '" & tbEMail.Text & "', " & _
                              " Usuario = '" & Uid & "', " & _
                              " FechaMod = '" & Format(Now, FormatFechaHora) & "' " & _
                              "WHERE Codigo = " & tbCodigo.Text
            End If
            .ExecuteNonQuery()
         End With
         '
         AltaLocalidadAuto(cbLocalidad.Text, , Trn)
         '
         Trn.Commit()
         '
         Me.Close()
         '
      Catch ex As Exception
         Dim st As New StackTrace(True)
         MensageError(st, "frmInquilinosAM.Guardar", ex.Message)
      End Try
      '
      'With rsGarantes
      '   .Open("SELECT * FROM Garantias WHERE Inquilino = " & tCodigo, Conn, adOpenKeyset, adLockOptimistic)
      '   '.Seek "=", tCodigo
      '   If .EOF Then
      '      .AddNew()
      '      !Inquilino = tCodigo.Text
      '      'Else
      '      '   .Edit
      '   End If
      '   !Codigo = tCodGte.Text
      '   !Nombre = tNombreGte.Text
      '   !Domicilio = tDomGte.Text
      '   !Localidad = tLocGte.Text
      '   !Telefono = tTelGte.Text
      '   !Trabajo = tTrabajoGte.Text
      '   !DomTrabajo = tDomTrabajoGte.Text
      '   !TelTrabajo = tTelTrabGte.Text
      '   If oHipotecaria.Value = True Then
      '      !gHipotecario = True
      '      !gPagare = False
      '      !gPrenda = False
      '   ElseIf oPagare.Value = True Then
      '      !gPagare = True
      '      !gHipotecario = False
      '      !gPrenda = False
      '   ElseIf oPrenda = True Then
      '      !gPrenda = True
      '      !gPagare = False
      '      !gHipotecario = False
      '   End If
      '   !FechaMod = Now
      '   .Update()
      '   .Close()
      'End With
      '
      '
   End Sub
   '
   'Private Sub Limpiacampos()
   '   Dim Ctrl As Control
   '   For Each Ctrl In Me.Controls
   '      If TypeOf Ctrl Is TextBox Then
   '         If Ctrl.Name <> "tBusca" Then
   '            Ctrl.Text = ""
   '         End If
   '      ElseIf TypeOf Ctrl Is ComboBox Then
   '         Ctrl.selectedIndex = -1
   '      End If
   '   Next Ctrl
   'End Sub
   '
   Private Sub tbCodigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbCodigo.KeyPress
      SoloNumeros(e.KeyChar)
   End Sub
   '
   Private Sub tbDni_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbDni.KeyPress
      SoloNumeros(e.KeyChar)
   End Sub
   '
   Private Sub tbCtaCont_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbCtaCont.TextChanged
      cbCtaCont.Text = CapturaDato(Cn, "PlanCtas", "Descrip", "Cuenta = '" & tbCtaCont.Text & "'")
   End Sub
   '
   Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
      Me.Close()
   End Sub
   '
   Private Sub frmInquilinosAM_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed   '
      '
      SetRegForm(Me)
      '
   End Sub
   '
End Class