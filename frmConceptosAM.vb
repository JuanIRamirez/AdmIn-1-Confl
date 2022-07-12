Public Class frmConceptosAM
   '
   Public Alta As Boolean = False
   Public Concepto As String = ""
   '
   Dim Cmd As New OleDb.OleDbCommand
   Dim Drd As OleDb.OleDbDataReader
   '
   Private Sub frmConceptosAM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      '
      GetRegForm(Me)
      TraducirForm(Me)
      '
      Me.Text = Me.Text & " - " & Traducir(IIf(Concepto = "", "Alta", "Edición"))
      '
      Cmd.Connection = Cn
      '
      If SisContable Then
         ArmaCombo(cbCuenta, "Descrip", "PlanCtas", "Descrip", "RecAsi <> 0", , "(Seleccionar)")
         ArmaCombo(cbCtaAdm, "Descrip", "PlanCtas", "Descrip", "RecAsi <> 0", , "(Seleccionar)")
      End If
      '
      If Alta Then
         tbCodigo.Enabled = True
      Else
         With Cmd
            .CommandText = "SELECT * FROM Conceptos WHERE Codigo = '" & Concepto & "'"
            Drd = .ExecuteReader
         End With
         With Drd
            If .Read Then
               tbCodigo.Text = !Codigo
               tbDescrip.Text = !Descrip
               tbPrioridad.Text = !Prioridad
               If !Accion = "D" Then
                  optDebe.Checked = True
               Else
                  optHaber.Checked = True
               End If
               If !Comision Then
                  chkComision.Checked = True
               End If
               If Not IsDBNull(!Cuenta) Then
                  PosCombo(cbCuenta, !Cuenta)
               End If
               If Not IsDBNull(!CtaAdm) Then
                  PosCombo(cbCtaAdm, !CtaAdm)
               End If
            Else
               MensajeTrad("ConcNoEnc")
               DeshabForm(Me)
            End If
            .Close()
         End With
         '
         tbCodigo.Enabled = False
         cmdCancelar.Enabled = False
         '
      End If
      '
      lblCuenta.Enabled = SisContable
      cbCuenta.Enabled = SisContable
      tbCuenta.Enabled = SisContable
      lblCtaAdm.Enabled = SisContable
      cbCtaAdm.Enabled = SisContable
      tbCtaAdm.Enabled = SisContable
      '
   End Sub

   Private Sub frmConceptosAM_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
      TabReturn(e)
   End Sub
   '
   Private Sub cbCuenta_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCuenta.SelectedIndexChanged
      tbCuenta.Text = CapturaDato(Cn, "PlanCtas", "Cuenta", "Descrip = '" & cbCuenta.Text & "'")
   End Sub
   '
   Private Sub cbCtaAdm_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCtaAdm.SelectedIndexChanged
      tbCtaAdm.Text = CapturaDato(Cn, "PlanCtas", "Cuenta", "Descrip = '" & cbCtaAdm.Text & "'")
   End Sub
   '
   Private Sub tbCuenta_TextChanged(sender As Object, e As EventArgs) Handles tbCuenta.TextChanged
      cbCuenta.Text = CapturaDato(Cn, "PlanCtas", "Descrip", "Cuenta = '" & tbCuenta.Text & "'")
   End Sub
   '
   Private Sub tbCtaAdm_TextChanged(sender As Object, e As EventArgs) Handles tbCtaAdm.TextChanged
      cbCtaAdm.Text = CapturaDato(Cn, "PlanCtas", "Descrip", "Cuenta = '" & tbCtaAdm.Text & "'")
   End Sub
   '
   Private Sub IniTb()
      Dim Ctrl As Control
      For Each Ctrl In Me.Controls
         If TypeOf Ctrl Is TextBox Then
            Ctrl.Text = ""
         End If
      Next Ctrl
   End Sub
   '
   Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
      If Concepto = "" Then
         IniTb()
         tbCodigo.Focus()
      End If
   End Sub
   '
   Private Sub cmdAceptar_Click(sender As Object, e As EventArgs) Handles cmdAceptar.Click
      '
      'On Error GoTo mError
      '
      If Not ValTb() Then
         Exit Sub
      End If
      '
      'Dim cAccion As String
      '
      With Cmd
         If Alta Then
            .CommandText = "INSERT INTO Conceptos( Codigo, [Descrip], [Accion], [Cuenta], [CtaAdm], [Comision], [Prioridad], [ImpDef], [Usuario], [FechaMod]) " & _
                           "VALUES('" & tbCodigo.Text & "', " & _
                                  "'" & tbDescrip.Text & "', " & _
                                  "'" & IIf(optDebe.Checked, "D", "H") & "', " & _
                                  "'" & tbCuenta.Text & "', " & _
                                  "'" & tbCtaAdm.Text & "', " & _
                                        IIf(chkComision.Checked, 1, 0) & ", " & _
                                        Val(tbPrioridad.Text) & ", " & _
                                        0 & ", " & _
                                  "'" & Uid & "', " & _
                                  "'" & Format(Now, FormatFechaHora) & "')"

         Else
            .CommandText = "UPDATE Conceptos SET " & _
                           " Codigo = '" & tbCodigo.Text & "', " & _
                           " Descrip = '" & tbDescrip.Text & "', " & _
                           " Accion = '" & IIf(optDebe.Checked, "D", "H") & "', " & _
                           " Cuenta = '" & tbCuenta.Text & "', " & _
                           " CtaAdm = '" & tbCtaAdm.Text & "', " & _
                           " Comision = " & IIf(chkComision.Checked, 1, 0) & ", " & _
                           " Prioridad = " & Val(tbPrioridad.Text) & ", " & _
                           " ImpDef = 0, " & _
                           " Usuario = '" & Uid & "', " & _
                           " FechaMod = '" & Format(Now, FormatFechaHora) & "' " & _
                           "WHERE Codigo = '" & tbCodigo.Text & "'"
         End If
         .ExecuteNonQuery()
      End With
      '
      If Concepto = "" Then
         IniTb()
         tbCodigo.Focus()
      Else
         'frmConceptos.DataGrid1.Row = frmConceptos.nRow
         Me.Close()
      End If
      '
      Exit Sub
      '
mError:
      MsgBox("Error: " & Err.Number & " - " & Err.Description)
      '
   End Sub
   '
   Private Function ValTb() As Boolean
      '
      If tbCodigo.Text = "" Then
         MensajeTrad("DebIngCod")
         tbCodigo.Focus()
         Return False
      End If
      '
      If Alta Then
         If Not IsNothing(CapturaDato(Cn, "Conceptos", "Codigo", "Codigo = '" & tbCodigo.Text & "'")) Then
            MensajeTrad("CodExist")
            tbCodigo.Focus()
            Return False
         End If
      End If
      '
      If tbDescrip.Text = "" Then
         MensajeTrad("DebIngDesc")
         tbDescrip.Focus()
         Return False
      End If
      '
      If Not optDebe.Checked And Not optHaber.Checked Then
         MensajeTrad("DebIngDebHab")
         optDebe.Focus()
         Return False
      End If
      '
      If tbPrioridad.Text = "" Then
         MensajeTrad("DIPrioridad")
         tbPrioridad.Focus()
         Return False
      ElseIf Val(tbPrioridad.Text) < 0 Then
         MensajeTrad("Prioridad>=0")
         tbPrioridad.Focus()
         Return False
      End If
      '
      If SisContable Then
         If cbCuenta.Text = "" Then
            MensajeTrad("DSelCuenta")
            cbCuenta.Focus()
            Return False
         End If
         '
         If cbCtaAdm.Text = "" Then
            MensajeTrad("DSelCtaAdm")
            cbCtaAdm.Focus()
            Return False
         End If
      End If
      '
      Return True
      '
   End Function
   '
   Private Sub tbPrioridad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbPrioridad.KeyPress
      SoloNumeros(e.KeyChar)
   End Sub
   '
   Private Sub cmdSalir_Click(sender As Object, e As EventArgs) Handles cmdSalir.Click
      Me.Close()
   End Sub
   '
   Private Sub frmConceptosAM_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
      SetRegForm(Me)
      Me.Dispose()
   End Sub
   '
End Class