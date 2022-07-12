Public Class frmPropiedadesAM
   '
   Public Alta As Boolean
   Public Propiedad As Long
   Public Propietario As Int32
   Public CambiarPropiet As Boolean
   '
   Dim Trn As OleDb.OleDbTransaction
   Dim Cmd As New OleDb.OleDbCommand
   Dim Drd As OleDb.OleDbDataReader
   '
   Dim Inquilino As Int32
   Dim vAutoriza As Boolean
   Dim Comision As Single
   Dim NuevoProp As Long
   Dim Localidad As Integer
   Dim TipoProp As String
   '
   Private Sub frmPropiedadesAM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      '
      Me.Text = "Propiedades: " & IIf(Alta, "Alta", "Modificación")
      '
      GetRegForm(Me)
      'TraducirForm(Me)
      '
      ArmaComboItem(cbLocalidad, "Localidad")
      ArmaCombo(cbTipo, "Descrip", "TipoProp")
      ArmaCombo(cbBarrio, "Nombre", "Barrios")
      '
      If Alta Then
         tbComision.Text = Val(CapturaDato(Cn, "Propietarios", "Comision", "Codigo = " & Propietario))
      Else
         With Cmd
            .Connection = Cn
            .CommandText = "SELECT * FROM Propiedades WHERE Codigo = " & Propiedad
            Drd = .ExecuteReader
         End With
         With Drd
            If .Read Then
               tbCodigo.Text = !Codigo
               tbValorAlq.Text = Format(!Valor, "Fixed")
               Propietario = !Propietario
               If !TipoAlq = "P" Then
                  optParticular.Checked = True
               Else
                  optComercial.Checked = True
               End If
               tbComision.Text = IIf(IsDBNull(!Comision), Comision, !Comision)
               chkComProp.Checked = IsDBNull(!Comision)
               tbDomicilio.Text = !Domicilio
               cbBarrio.Text = !Barrio
               'For i = 0 To cbLocalidad.ListCount - 1
               'If cbLocalidad.List(i) = !Localidad Then
               cbLocalidad.Text = !Localidad
               'End If
               'Next i
               If !NomCat <> "" Then
                  tbNomCat.Text = !NomCat
               Else
                  With tbNomCat
                     .Mask = ""
                     .Text = ""
                     .Mask = cfgMaskNomCat
                  End With
               End If
               '
               cbTipo.Text = CapturaDato(Cn, "TipoProp", "Descrip", "Codigo = '" & !Tipo & "" & "'")
               '
               tbDescrip.Text = !Descripcion & ""
               Inquilino = Val(!Inquilino & "")
               optActivo.Checked = (!Estado & "" = "A")
               optInactivo.Checked = (!Estado & "" = "I")
               '
            End If
            .Close()
         End With
      End If
      ' 
      If CambiarPropiet Or Propietario = 0 Then
         ArmaComboItem(cbPropietario, "Propietarios", , "Nombre", "Nombre", "(Seleccionar)", "Estado = 'A' AND Codigo <> " & Propietario)
      Else
         ArmaComboItem(cbPropietario, "Propietarios", , "Nombre", "Nombre", "(Seleccionar)", "Codigo = " & Propietario)
         PosCboItem(cbPropietario, Propietario)
      End If
      '
      If UCase(Sistema) <> "RSISQL2" Then
         'If AbrirCnx(Cnx, "RsiSql2") Then
         '   lblCodigo.BackColor = &H80000010
         'End If
      End If
      '
      ActivaControles()
      '
   End Sub
   '
   Private Sub frmInquilinosAM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
      TabReturn(e.KeyChar)
   End Sub
   '
   Private Sub btCodSig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCodSig.Click
      '
      tbCodigo.Text = Val(CapturaDato(Cn, "Propiedades", "ISNULL(MAX(Codigo),0) + 1", ""))
      '
   End Sub
   '
   Private Sub btPriLib_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btPriLib.Click
      '
      tbCodigo.Text = Val(CapturaDato(Cn, "Propiedades P", "ISNULL(MIN(Codigo),0) + 1", "Codigo > 0 AND NOT EXISTS( SELECT Codigo FROM Propiedades WHERE Codigo = P.Codigo + 1)"))
      '
   End Sub
   '
   Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
      '
      If CambiarPropiet Then
         If NuevoProp = 0 Then
            MensajeTrad("DiPropietario")
            cbPropietario.Focus()
            Exit Sub
         Else
            If MsgConfirma("Cambia Propietario") Then
               CambiaPropietario()
            End If
         End If
      Else
         If Validar() Then
            Guardar()
         End If
      End If
      '
   End Sub
   '
   Private Sub CambiaPropietario()
      '
      Dim CambCob As Boolean = False
      '
      If CambiarPropiet Then
         '
         If Not IsNothing(CapturaDato(Cn, "LiqInqCab", "Propietario", "Liquidado = 0 AND Estado <> 2 AND Propiedad = " & tbCodigo.Text)) Then
            CambCob = MsgConfirma("Cambia cobranzas no liquidadas al nuevo propietario")
         End If
         '
         Try
            '
            Trn = Cn.BeginTransaction
            '
            With Cmd
               '
               .Connection = Cn
               .Transaction = Trn
               '
               .CommandText = "UPDATE Propiedades SET Propietario = " & NuevoProp & " WHERE Codigo = " & tbCodigo.Text
               .ExecuteNonQuery()
               .CommandText = "UPDATE Contratos SET Propietario = " & NuevoProp & " WHERE Estado = 0 AND Propiedad = " & tbCodigo.Text
               .ExecuteNonQuery()
               If CambCob Then
                  .CommandText = "UPDATE LiqInqCab SET Propietario = " & NuevoProp & " WHERE Liquidado = 0 AND Estado <> 2 AND Propiedad = " & tbCodigo.Text
                  .ExecuteNonQuery()
                  .CommandText = "UPDATE CobrosOtr SET Propietario = " & NuevoProp & " WHERE Liquidado = 0 AND Propiedad = " & tbCodigo.Text
                  .ExecuteNonQuery()
               End If
               '.CommandText = "UPDATE LiqPropiet SET Propietario = " & NuevoProp & _
               '               " WHERE Estado <> 2 AND Propiedad = " & tbCodigo.Text & _
               '               "   AND EXISTS( SELECT Numero FROM LiqInqDet WHERE Numero = LiqPropiet.Numero AND Tipo = 'L' AND aPropiet <> 0 AND LiqPropiet = 0)"
               '.ExecuteNonQuery()
               .CommandText = "UPDATE CompraOtr SET Propietario = " & NuevoProp & " WHERE Liquidado = 0 AND Propiedad = " & tbCodigo.Text
               .ExecuteNonQuery()
               '
               GuardarAudit("Cambio de Propietario", "Propiedad (" & tbCodigo.Text & ") " & tbDomicilio.Text, "Propiedades", "CambiaPropietario", Trn)
               '
               Trn.Commit()
               '
            End With
            '
            Mensaje("Se cambió de propietario a la propiedad " & tbDomicilio.Text & "." & vbCrLf & _
                    "De " & CapturaDato(Cn, "Propietarios", "Nombre", "Codigo = " & Propietario) & vbCrLf & _
                    " a " & CapturaDato(Cn, "Propietarios", "Nombre", "Codigo = " & NuevoProp))
            '
            Me.Close()
            '
         Catch ex As Exception
            Dim st As New StackTrace(True)
            MensageError(st, "frmPropiedadesAM.CambiaPropietario", ex.Message)
            Trn.Rollback()
         End Try
      End If
      '
   End Sub
   '
   Private Function Validar() As Boolean
      '
      If tbCodigo.Text = "" Then
         MensajeTrad("DiCodigo")
         tbCodigo.Focus()
         Return False
      End If
      '
      If Alta Then
         If Not IsNothing(CapturaDato(Cn, "Propiedades", "Codigo", "Codigo = " & tbCodigo.Text)) Then
            MensajeTrad("CodExist")
            tbCodigo.Focus()
            Return False
         End If
      End If
      '
      If tbDomicilio.Text = "" Then
         MensajeTrad("DiDomicilio")
         tbDomicilio.Focus()
         Return False
      Else
         If Not IsNothing(CapturaDato(Cn, "Propiedades", "Domicilio", "Codigo <> " & Val(tbCodigo.Text) & " AND Domicilio = '" & tbDomicilio.Text & "'")) Then
            MensajeTrad("DomicilioEx")
            tbDomicilio.Focus()
            Return False
         End If
      End If
      '
      If Localidad = 0 Then
         MensajeTrad("DiLocalidad")
         cbLocalidad.Focus()
         Return False
      End If
      '
      If Val(tbValorAlq.Text) = 0 Then
         MensajeTrad("DiValor>0")
         tbValorAlq.Focus()
         Return False
      End If
      '
      If Alta And NuevoProp = 0 Then
         MensajeTrad("DSelPropietario")
         cbPropietario.Focus()
         Return False
      End If
      '
      Return True
      '
   End Function
   '
   Private Sub Guardar()
      '
      Try
         '
         Trn = Cn.BeginTransaction
         '
         With Cmd
            '
            .Connection = Cn
            .Transaction = Trn
            '
            If Alta Then
               .CommandText = "INSERT INTO Propiedades( Propietario, Codigo, Valor, Domicilio, Barrio, Localidad, Tipo, Descripcion, TipoAlq, NomCat, Comision, Estado, Usuario, FechaMod) " &
                              "VALUES(" & NuevoProp & ", " &
                                          Val(tbCodigo.Text) & ", " &
                                          Val(tbValorAlq.Text) & ", " &
                                    "'" & tbDomicilio.Text & "', " &
                                    "'" & cbBarrio.Text & "', " &
                                    "'" & cbLocalidad.Text & "', " &
                                    "'" & TipoProp & "', " &
                                    "'" & tbDescrip.Text & "', " &
                                    "'" & IIf(optParticular.Checked, "P", "C") & "', " &
                                    "'" & tbNomCat.Text & "', " &
                                          IIf(chkComProp.Enabled, "NULL", Val(tbComision.Text)) & ", " &
                                    "'" & IIf(optActivo.Checked, "A", "I") & "', " &
                                    "'" & Uid & "', " &
                                    "'" & Format(Now, FormatFechaHora) & "')"
            Else
               .CommandText = "UPDATE Propiedades SET " &
                              " Propietario = " & NuevoProp & ", " &
                              " Valor = " & Val(tbValorAlq.Text) & ", " &
                              " Domicilio = '" & tbDomicilio.Text & "', " &
                              " Barrio = '" & cbBarrio.Text & "', " &
                              " Localidad = '" & cbLocalidad.Text & "', " &
                              " Tipo = '" & TipoProp & "', " &
                              " Descripcion = '" & tbDescrip.Text & "', " &
                              " TipoAlq = '" & IIf(optParticular.Checked, "P", "C") & "', " &
                              " NomCat = '" & tbNomCat.Text & "', " &
                              " Comision = " & IIf(chkComProp.Enabled, "NULL", Val(tbComision.Text)) & ", " &
                              " Estado = '" & IIf(optActivo.Checked, "A", "I") & "', " &
                              " Usuario = '" & Uid & "', " &
                              " FechaMod = '" & Format(Now, FormatFechaHora) & "' " &
                              "WHERE Codigo = " & Val(tbCodigo.Text)
            End If
            '
            .ExecuteNonQuery()
            '
            AgrNuevoBarrio(cbBarrio.Text, Trn)
            '
         End With
         '
         GuardarAudit(IIf(Alta, "Alta", "Modificaión") & " de Propiedad", "(" & tbCodigo.Text & ") " & tbDomicilio.Text, "Propiedades", "Guardar", Trn)
         '
         Trn.Commit()
         '
         Mensaje("Se guardó la Propiedad (" & tbCodigo.Text & ") " & tbDomicilio.Text)
         '
         Me.Close()
         '
      Catch ex As Exception
         Trn.Rollback()
         Dim st As New StackTrace(True)
         MensageError(st, "frmPropiedadesAM.Guardar", ex.Message)
      End Try
      '
   End Sub
   '
   Private Sub tbCodigo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbCodigo.KeyPress
      SoloNumeros(e.KeyChar)
   End Sub
   '
   Private Sub tbDni_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
      SoloNumeros(e.KeyChar)
   End Sub
   '
   Private Sub cbPropietario_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPropietario.SelectedIndexChanged
      With cbPropietario
         If .SelectedIndex > 0 Then
            NuevoProp = .SelectedValue
         Else
            NuevoProp = 0
         End If
      End With
   End Sub
   '
   Private Sub ActivaControles()
      '
      Me.tbCodigo.Enabled = Not CambiarPropiet And Alta
      btCodSig.Enabled = Not CambiarPropiet And Alta
      btPriLib.Enabled = Not CambiarPropiet And Alta
      Me.tbComision.Enabled = Not CambiarPropiet And Not chkComProp.Checked
      chkComProp.Enabled = Not CambiarPropiet
      Me.tbNomCat.Enabled = Not CambiarPropiet
      Me.tbDomicilio.Enabled = Not CambiarPropiet
      Me.tbDescrip.Enabled = Not CambiarPropiet
      Me.tbValorAlq.Enabled = Not CambiarPropiet
      Me.cbTipo.Enabled = Not CambiarPropiet
      Me.cbBarrio.Enabled = Not CambiarPropiet
      Me.cbLocalidad.Enabled = Not CambiarPropiet
      Me.optComercial.Enabled = Not CambiarPropiet
      Me.optParticular.Enabled = Not CambiarPropiet
      Me.optActivo.Enabled = Not CambiarPropiet
      Me.optInactivo.Enabled = Not CambiarPropiet
      '
      cbPropietario.Enabled = CambiarPropiet Or Propietario = 0
      '
   End Sub
   '
   Private Sub tbComision_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbComision.KeyPress
      SoloNumeros(e.KeyChar, True)
   End Sub
   '
   Private Sub cbLocalidad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbLocalidad.SelectedIndexChanged
      With cbLocalidad
         If .SelectedIndex > 0 Then
            Localidad = .SelectedValue
         Else
            Localidad = 0
         End If
      End With
   End Sub

   Private Sub cbTipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbTipo.SelectedIndexChanged
      With cbTipo
         If .SelectedIndex > 0 Then
            TipoProp = CapturaDato(Cn, "TipoProp", "Codigo", "Descrip = '" & cbTipo.Text & "'")
         Else
            TipoProp = ""
         End If
      End With
   End Sub
   '
   Private Sub chkComProp_CheckedChanged(sender As Object, e As EventArgs) Handles chkComProp.CheckedChanged
      Dim comFija As Boolean
      tbComision.Enabled = Not chkComProp.Checked
      If chkComProp.Checked Then
         tbComision.Text = Val(CapturaDato(Cn, "Propietarios", "Comision", "Codigo = " & Propietario) & "")
         comFija = CBool(CapturaDato(Cn, "Propietarios", "ComFija", "Codigo = " & Propietario))
         lblComPorcImp.Text = IIf(comFija, "$", "%")
      End If
   End Sub
   '
   Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
      Me.Close()
   End Sub
   '
   Private Sub frmPropiedadesAM_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed   '
      '
      SetRegForm(Me)
      Me.Dispose()
      '
   End Sub
   '
End Class