Public Class frmPlanCtasAM
   '
   Public Alta As Boolean
   Public cCtaMadre As String = ""
   Public cCuenta As String
   Public Cerrar As Boolean
   Public Descrip As String
   '
   Dim Trn As OleDb.OleDbTransaction
   Dim Cmd As New OleDb.OleDbCommand
   Dim Drd As OleDb.OleDbDataReader
   '
   Private Sub frmPlanCtasAM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      '
      GetRegForm(Me)
      '
      TraducirForm(Me)
      '
      tbCuenta.MaxLength = cfgCntDigCtas
      '
      ArmaCombo(Me.cbCtaMadre, "Descrip", "PlanCtas", "Descrip", , , "(Seleccionar)")
      ArmaCombo(Me.cbCtaMadre, "Cuenta", "PlanCtas", "Descrip", , , "(Seleccionar)")
      '
      tbCtaMadre.Text = cCtaMadre
      '
      'With Cmd
      '   .Connection = Cn
      '   .CommandText = "SELECT * FROM PlanCtas ORDER BY Descrip"
      '   Do Until .EOF
      '      cbCtaMadre.AddItem!Cuenta()
      '      cbDescCtaM.AddItem!Descrip()
      '      If !Cuenta = cCtaMadre Then
      '         cbCtaMadre.ListIndex = cbCtaMadre.ListCount - 1
      '      End If
      '      .MoveNext()
      '   Loop
      '   'End If
      '   .Close()
      'End With
      '
      If Alta Then
         Me.Text = Me.Text & " - " & Traducir("Alta")
         If cCuenta = "" Then
            tbCuenta.Text = Val(CapturaDato(Cn, "PlanCtas", "MAX(Cuenta)", "CtaMadre = '" & cCtaMadre & "'") & "") + 1
         Else
            tbCuenta.Text = cCuenta
            tbDescrip.Text = Descrip
         End If
      Else
         Me.Text = Me.Text & " - " & Traducir("Edición")
         With Cmd
            .Connection = Cn
            .CommandText = "SELECT * FROM PlanCtas WHERE Cuenta = '" & cCuenta & "'"
            Drd = .ExecuteReader
            With Drd
               If .Read Then
                  tbCuenta.Text = !Cuenta
                  tbCtaAbrev.Text = !CtaAbr
                  tbDescrip.Text = !Descrip
                  tbDescAbrev.Text = !DescAbr
                  chkRecAsi.Checked = !RecAsi
                  rbDebe.Checked = (!SdoHab = "D")
                  rbHaber.Checked = (!SdoHab = "H")
               Else
                  MensajeTrad("CtaNoEnc")
                  DeshabForm(Me)
               End If
               .Close()
            End With
         End With
         '
         tbCuenta.Enabled = False
         '
      End If
      '
   End Sub
   '
   Private Sub frmPlanCtasAM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
      TabReturn(e.KeyChar, True)
   End Sub
   '
   Private Sub tbCtaMadre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbCtaMadre.TextChanged
      cbCtaMadre.Text = CapturaDato(Cn, "PlanCtas", "Descrip", "Cuenta = '" & tbCtaMadre.Text & "'")
   End Sub
   '
   Private Sub cbDescCtaM_Change()
      'PintarCb(cbDescCtaM, LastKey)
   End Sub
   '
   Private Sub cbDescCtaM_Click()
      'cbCtaMadre.ListIndex = cbDescCtaM.ListIndex
   End Sub
   '
   Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
      If ValTb() Then
         Guardar()
         If Cerrar Then
            cCuenta = tbCuenta.Text
            Me.Close()
         End If
      End If
   End Sub
   '
   Private Function ValTb() As Boolean
      '
      'Dim cIndex As String
      'Dim cBookM As String
      '
      If tbCuenta.Text = "" Then
         MensajeTrad("DICuenta")
         tbCuenta.Focus()
         Exit Function
      End If
      '
      If tbCuenta.Text <= tbCtaMadre.Text Then
         MensajeTrad("Cuenta debe ser mayor a Cuenta Madre")
         tbCuenta.Focus()
         Exit Function
      End If
      '
      If Alta Then
         If Not IsNothing(CapturaDato(Cn, "PlanCtas", "Cuenta", "Cuenta = '" & tbCuenta.Text & "'")) Then
            MensajeTrad("CtaExist")
            tbCuenta.Focus()
            Exit Function
         End If
         'End With
      End If
      '
      If tbCtaAbrev.Text = "" Then
         'MensajeTrad "DICtaAbr"
         'tbCtaAbr.SetFocus
         'Exit Function
      Else
         'With rsPlanC
         '   .Index = "CtaAbr"
         '   .Seek "=", tbCtaAbr
         '   If .NoMatch Then
         'Ok.
         '   Else
         '      If !Cuenta <> tbCuenta Then
         '         MensajeTrad "CtaAbrExist"
         '         tbCtaAbr.SetFocus
         '         Exit Function
         '      End If
         '   End If
         'End With
      End If
      '
      If tbDescrip.Text = "" Then
         MensajeTrad("DIDescrip")
         tbDescrip.Focus()
         Exit Function
      End If
      '
      If tbDescAbrev.Text = "" Then
         MensajeTrad("DIDescAbr")
         tbDescAbrev.Focus()
         Exit Function
      End If
      '
      If Not rbDebe.Checked And Not rbHaber.Checked Then
         MensajeTrad("DIDebHab")
         rbDebe.Focus()
         Exit Function
      End If
      '
      ValTb = True
      '
   End Function
   '
   Private Sub Guardar()

      'On Error GoTo Fin

      If Alta Then
         If Not IsNothing(CapturaDato(Cn, "PlanCtas", "Cuenta", "Cuenta = '" & tbCuenta.Text & "'")) Then
            MensajeTrad("CtaExist")
            Exit Sub
         End If
      End If
      '
      Trn = Cn.BeginTransaction
      '
      With Cmd
         .Connection = Cn
         .Transaction = Trn
         If Alta Then
            .CommandText = "INSERT INTO PlanCtas( CtaMadre, Cuenta, CtaAbr, Descrip, DescAbr, SdoHab, RecAsi, Usuario, FechaMod) " & _
                           "VALUES('" & tbCtaMadre.Text & "', " & _
                                  "'" & tbCuenta.Text & "', " & _
                                  "'" & tbCtaAbrev.Text & "', " & _
                                  "'" & tbDescrip.Text & "', " & _
                                  "'" & tbDescAbrev.Text & "', " & _
                                  "'" & IIf(rbDebe.Checked, "D", "H") & "', " & _
                                        IIf(chkRecAsi.Checked, 1, 0) & ", " & _
                                  "'" & Uid & "', " & _
                                  "'" & Format(Now, FormatFechaHora) & "')"

         Else
            .CommandText = "UPDATE PlanCtas SET " & _
                           " CtaMadre = '" & tbCtaMadre.Text & "', " & _
                           " CtaAbr = '" & tbCtaAbrev.Text & "', " & _
                           " Descrip = '" & tbDescrip.Text & "', " & _
                           " DescAbr = '" & tbDescAbrev.Text & "', " & _
                           " SdoHab = '" & IIf(rbDebe.Checked, "D", "H") & "', " & _
                           " RecAsi = " & IIf(chkRecAsi.Checked, 1, 0) & ", " & _
                           " Usuario = '" & Uid & "', " & _
                           " FechaMod = '" & Format(Now, FormatFechaHora) & "' " & _
                           "WHERE Cuenta = '" & tbCuenta.Text & "'"
         End If
         .ExecuteNonQuery()
      End With
      '
      Trn.Commit()
      '
      If Cerrar Then Exit Sub
      '
      'With frmPlanCtas
      'If Alta Then
      '.ActTree()
      'LimpiarTb(Me)
      'tbCuenta.SetFocus()
      'Else
      'If Me.cbCtaMadre = cCtaMadre Then
      '.TreeView.SelectedItem.Text = tbCuenta & " - " & tbDescrip
      'Else
      '.ActTree()
      'End If
      Me.Close()
      'End If
      'End With
      '
      Exit Sub
      '
      'Fin:
      '     MsgBox(Err.Number & ": " & Err.Description & Chr(13) + Chr(10) & _
      '           Traducir("TransNComp"))
      '   Cn.RollbackTrans()
      '
   End Sub
   '
   Private Sub tbCuenta_GotFocus()
      'PintarTb(tbCuenta)
   End Sub
   '
   Private Sub tbDescrip_LostFocus()
      'If tbDescAbr = "" Then
      'tbDescAbr = tbDescrip
      'End If
   End Sub
   '
   Private Sub tbDescrip_GotFocus()
      'PintarTb(tbDescrip)
   End Sub
   '
   Private Sub tbCtaAbr_GotFocus()
      'PintarTb(tbCtaAbr)
   End Sub
   '
   Private Sub tbDescAbr_GotFocus()
      'PintarTb(tbDescAbr)
   End Sub
   '
   Private Sub tbDetalle_KeyPress(ByVal KeyAscii As Integer)
      'Mayusculas(KeyAscii)
   End Sub
   '
   Private Sub tbCuenta_KeyPress(ByVal KeyAscii As Integer)
      SoloNumeros(KeyAscii)
   End Sub
   '
   Private Sub tbCtaAbr_KeyPress(ByVal KeyAscii As Integer)
      SoloNumeros(KeyAscii)
   End Sub
   '
   Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
      cCuenta = ""
      Me.Close()
   End Sub
   '
   Private Sub frmPlanCtasAM_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
      SetRegForm(Me)
   End Sub
   '
End Class