Public Class frmComprasOtrAmDet
   '
   Public tTmp As String
   Public Alta As Boolean
   Public cmpInt As String
   Public cConcepto As String = ""
   Public nProveedor As Long
   Public nSucursal As Integer
   Public nNumero As Long
   Public nRenglon As Byte
   Public Propietario As Long
   Public Titulo As String = ""
   '
   Dim Trn As OleDb.OleDbTransaction
   Dim cmd As New OleDb.OleDbCommand
   Dim Drd As OleDb.OleDbDataReader
   '
   Private Sub frmCompraOtrDetAM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      '
      GetRegForm(Me)
      '
      Me.Text = IIf(Titulo = "", Me.Text, Titulo) & " - " & IIf(Alta, Traducir("Alta"), Traducir("Modificación"))
      '
      cmd.Connection = Cn
      '
      ArmaCombo(cbConcepto, "Descrip", "Conceptos", "Descrip", , , "(Seleccionar)")
      If cConcepto <> "" Then
         cbConcepto.Text = CapturaDato(Cn, "Conceptos", "Descrip", "Codigo = '" & cConcepto & "'")
      End If
      '
      If Alta Then
         '
      Else
         With cmd
            .CommandText = "SELECT * FROM " & tTmp & " WHERE Renglon = " & nRenglon
            Drd = .ExecuteReader
         End With
         With Drd
            If .Read Then
               cbConcepto.Text = CapturaDato(Cn, "Conceptos", "Descrip", "Codigo = '" & !Concepto & "'")
               cbConcepto.Enabled = False
               tbDetalle.Text = !Detalle
               optDebe.Checked = !Debe
               opthaber.Checked = !Haber
               If !aPropiet Then
                  optPropiet.Checked = True
               Else
                  optAdmin.Checked = True
               End If
               tbImporte.Text = Format(!Debe + !Haber, "Fixed")
            Else
               MensajeTrad("RegNoEnc")
               DeshabForm(Me)
            End If
            .Close()
         End With
      End If
      '
      If Propietario = 0 Then
         optPropiet.Enabled = False
         optAdmin.Enabled = False
         optAdmin.Checked = True
      End If
      '
   End Sub
   '
   Private Sub frmCompraOtrDetAM_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
      TabReturn(e.KeyChar)
   End Sub
   '
   Private Sub cbConcepto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbConcepto.SelectedIndexChanged
      With cbConcepto
         If .SelectedIndex = 0 Then
            cConcepto = ""
         Else
            cConcepto = CapturaDato(Cn, "Conceptos", "Codigo", "Descrip = '" & cbConcepto.Text & "'")
            If Alta Then
               tbDetalle.Text = cbConcepto.Text
            End If
         End If
      End With
   End Sub
   '
   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      '
      If cbConcepto.SelectedIndex = 0 Then
         MensajeTrad("DIConcepto")
         cbConcepto.Focus()
         Exit Sub
      End If
      '
      If tbDetalle.Text = "" Then
         MensajeTrad("DIDetalle")
         tbDetalle.Focus()
         Exit Sub
      End If
      '
      If Val(tbImporte.Text) <= 0 Then
         MensajeTrad("DII>0")
         tbImporte.Focus()
         Exit Sub
      End If
      '
      If Not optPropiet.Checked And Not optAdmin.Checked Then
         MensajeTrad("DIAsignacion")
         Exit Sub
      End If
      '
      Try
         '
         Trn = Cn.BeginTransaction
         '
         With cmd
            .Transaction = Trn
            If Alta Then
               .CommandText = "INSERT INTO " & tTmp & "(Proveedor, Renglon, Concepto, Detalle, Fecha, Debe, Haber, aPropiet) " & _
                              "VALUES(" & nProveedor & ", " & _
                                          nRenglon & ", " & _
                                    "'" & cConcepto & "', " & _
                                    "'" & tbDetalle.Text & "', " & _
                                    "'" & Format(Today, FormatFecha) & "', " & _
                                          IIf(optDebe.Checked, Val(tbImporte.Text), 0) & ", " & _
                                          IIf(opthaber.Checked, Val(tbImporte.Text), 0) & ", " & _
                                          IIf(optPropiet.Checked, 1, 0) & ")"
            Else
               .CommandText = "UPDATE " & tTmp & " SET " & _
                              " Proveedor = " & nProveedor & ", " & _
                              " Concepto = '" & cConcepto & "', " & _
                              " Detalle = '" & tbDetalle.Text & "', " & _
                              " Fecha = '" & Format(Today, FormatFecha) & "', " & _
                              " Debe = " & IIf(optDebe.Checked, Val(tbImporte.Text), 0) & ", " & _
                              " Haber = " & IIf(opthaber.Checked, Val(tbImporte.Text), 0) & ", " & _
                              " aPropiet = " & IIf(optPropiet.Checked, 1, 0) & " " & _
                              "WHERE Renglon = " & nRenglon
            End If
            .ExecuteNonQuery()
         End With
         '
         Trn.Commit()
         '
         Me.Close()
         '
      Catch ex As System.Exception
         Trn.Rollback()
         Dim st As New StackTrace(True)
         RegistrarError(st, Me.Name, True)
      End Try
      '
   End Sub
   '
   Private Sub tbDetalle_GotFocus()
      'PintarTb tbDetalle
   End Sub
   '
   Private Sub tbImporte_GotFocus()
      'PintarTb tbImporte
   End Sub
   '
   Private Sub tbImporte_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbImporte.KeyPress
      SoloNumeros(e.KeyChar, True)
   End Sub
   '
   Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
      Me.Close()
   End Sub
   '
   Private Sub Form_Unload(Cancel As Integer)
      SetRegForm(Me)
      Me.Dispose()
   End Sub
   '
End Class