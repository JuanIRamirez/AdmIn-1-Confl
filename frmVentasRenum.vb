Public Class frmVentasRenum

   Public VentaID As Long
   '
   Private Sub frmVentasRenum_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      '
      GetRegForm(Me)
      '
      tbTipoComp.Text = CapturaDato(cn, "TipoComp", "Descrip", "TipoComp = (SELECT TipoComp FROM Ventas WHERE VentaID = " & VentaID & ")")
      'tbVendedor = CapturaDato(cn, "Vendedores", "Nombre", "Vendedor = (SELECT Vendedor FROM Ventas WHERE VentaID = " & VentaID & ")")
      tbCliente.Text = CapturaDato(cn, "Clientes", "Nombre", "Cliente = (SELECT Cliente FROM Ventas WHERE VentaID = " & VentaID & ")")
      tbLetra.Text = CapturaDato(cn, "Ventas", "FactLetra", "VentaID = " & VentaID)
      tbSucursal.Text = CapturaDato(cn, "Ventas", "Sucursal", "VentaID = " & VentaID)
      tbNumero.Text = CapturaDato(cn, "Ventas", "FactNumero", "VentaID = " & VentaID)
      dtpFecha.Value = CapturaDato(cn, "Ventas", "Fecha", "VentaID = " & VentaID)
      '

   End Sub
   '
   Private Sub frmVentasRenum_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
      SoloNumeros(e.KeyChar)
   End Sub
   '
   Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
      If tbNSucursal.Text = "" Then
         MensajeTrad("DISucursal")
         tbNSucursal.Focus()
         Exit Sub
      End If
      If Val(tbNNumero.Text) = 0 Then
         MensajeTrad("DINumero")
         tbNNumero.Focus()
         Exit Sub
      End If

      Dim Trn As OleDb.OleDbTransaction
      Dim Cmd As New OleDb.OleDbCommand

      If IsNothing(CapturaDato(Cn, "Ventas", "FactNumero", "FactLetra = '" & tbLetra.Text & "' AND Sucursal = " & tbNSucursal.Text & " AND FactNumero = " & tbNNumero.Text)) Then
         If MsgConfirma("Cambia numeración de comprobante " & tbLetra.Text & " - " & tbSucursal.Text & " - " & tbNumero.Text & vbCrLf &
                        " a " & tbLetra.Text & " - " & tbNSucursal.Text & " - " & tbNNumero.Text) Then
            '
            Trn = Cn.BeginTransaction
            Cmd.Connection = Cn
            Cmd.Transaction = Trn
            '
            Cmd.CommandText = "UPDATE Ventas SET " &
                              " Sucursal = " & tbNSucursal.Text & ", " &
                              " FactNumero = " & tbNNumero.Text & " " &
                              "WHERE VentaID = " & VentaID
            Cmd.ExecuteNonQuery()
            '
            Cmd.CommandText = "UPDATE CtaCteCli SET " &
                              " Sucursal = " & tbNSucursal.Text & ", " &
                              " CliNumero = " & tbNNumero.Text & " " &
                              "WHERE VentaID = " & VentaID
            Cmd.ExecuteNonQuery()
            '
            GuardarAudit("Renumera venta", tbLetra.Text & "-" & tbSucursal.Text & "-" & tbNumero.Text & " a " & tbLetra.Text & "-" & tbNSucursal.Text & "-" & tbNNumero.Text, "VentasRenum", "Aceptar", Trn)
            '
            Trn.Commit()
            '
            Me.Close()
         End If
      Else
         MensajeTrad("CmpExist")
      End If
   End Sub
   '
   'Private Sub txtNumero_KeyPress(ByVal Index As Integer, ByVal KeyAscii As Integer)
   '   SoloNumeros(KeyAscii)
   'End Sub
   '
   'Private Sub txtSucursal_KeyPress(ByVal Index As Integer, ByVal KeyAscii As Integer)
   '   SoloNumeros(KeyAscii)
   'End Sub
   '
   Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
      Me.Close()
   End Sub
   '
   Private Sub Form_Unload(ByVal Cancel As Integer)
      SetRegForm(Me)
   End Sub

End Class