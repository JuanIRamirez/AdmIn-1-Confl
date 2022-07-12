Public Class frmComprasDet
   '
   Public Frm As Form
   Public Tabla As String
   Public Rs As New OleDb.OleDbCommand
   '
   Public Alta As Boolean
   Public cmpINT As String
   '
   Public Concepto As Integer
   Public Renglon As Integer
   Public AlicIva As Single
   Public SoloConcepto As Boolean
   '
   Dim TR As OleDb.OleDbTransaction
   Dim DR As OleDb.OleDbDataReader
   '
   Private Sub frmComprasDet_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
      '
      GetRegForm(Me)
      '
      'TraducirForm(Me)
      '
      'Dim nList As Integer
      'Dim Ctrl As Control
      '
      Rs.Connection = cn
      '
      ArmaComboItem(cboConcepto, "Conceptos", "ConceptoId", "Descrip", "Descrip", "(Seleccionar)", "ConceptoId <> 0", , , , Concepto)
      '
      'If Concepto <> 0 Then
      'PosicionarComboItem(cboConcepto, Concepto)
      'End If
      '
      If Alta Then
         Me.Text = Frm.Text & " - " & Traducir("Alta")
      Else
         Me.Text = Frm.Text & " - " & Traducir("Edición")
         With Rs
            .CommandText = "SELECT * FROM " & Tabla & " WHERE Renglon = " & Renglon
            DR = .ExecuteReader
         End With
         With DR
            If .Read Then
               tbDetalle.Text = !Detalle
               If !Cantidad > 0 Then
                  optDebe.Checked = True
               Else
                  optHaber.Checked = True
               End If
               tbImporte.Text = Format(!Costo, cfgFormatoPr)
               txtBonificacion.Text = Format(!Bonificacion, cfgFormatoPr)
            End If
            .Close()
         End With
      End If
      '
      fraImportes.Enabled = Not SoloConcepto
      '
   End Sub
   '
   Private Sub frmComprasDet_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
      TabReturn(e.KeyChar, True)
   End Sub
   '
   Private Sub cboConcepto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboConcepto.SelectedIndexChanged
      '
      If cboConcepto.Text = "" Then
         Concepto = 0
      End If
      '
      With cboConcepto
         If .SelectedIndex > 0 Then
            Concepto = .SelectedValue
            If Alta Then
               tbDetalle.Text = cboConcepto.Text
            End If
         Else
            Concepto = 0
         End If
      End With
   End Sub
   '
   Private Sub cmdAceptar_Click(sender As Object, e As EventArgs) Handles cmdAceptar.Click
      '
      If Concepto = 0 Then
         MensajeTrad("DIConcepto")
         cboConcepto.Focus()
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
      Dim Cantidad As Byte = IIf(optDebe.Checked, 1, -1)
      Dim Costo As Double = IIf(optNeto.Checked, Val(tbImporte.Text), (Val(tbImporte.Text) / (1 + AlicIva / 100)))
      '
      If IsNothing(CapturaDato(cn, Tabla, "Renglon", "Renglon = " & Renglon)) Then
         Rs.CommandText = "INSERT INTO " & Tabla & "(Renglon, IngresoId, Producto, CodProd, Concepto, Cantidad, Costo, Bonificacion, Detalle, SubTotal, NoGravado) " & _
                          "VALUES(" & Renglon & ", 0, 0, '', " & Concepto & ", " & Cantidad & ", " & Costo & ", '" & txtBonificacion.Text & "', '" & tbDetalle.Text & "', " & Val(txtSubtotal.Text) & ", " & Val(txtNoGravado.Text) & ")"
      Else
         Rs.CommandText = "UPDATE " & Tabla & " SET " & _
                          " IngresoId = 0, " & _
                          " Producto = 0, " & _
                          " CodProd = '', " & _
                          " Concepto = " & Concepto & ", " & _
                          " Cantidad = " & Cantidad & ", " & _
                          " Costo = " & Costo & ", " & _
                          " Bonificacion = '" & txtBonificacion.Text & "', " & _
                          " Detalle = '" & tbDetalle.Text & "', " & _
                          " SubTotal = " & Val(txtSubtotal.Text) & ", " & _
                          " NoGravado = " & Val(txtNoGravado.Text) & " " & _
                          "WHERE Renglon = " & Renglon
      End If
      '
      TR = cn.BeginTransaction
      Rs.Transaction = TR
      Rs.ExecuteNonQuery()
      TR.Commit()
      '
      Me.Close()
      '
   End Sub
   '
   Private Sub optNeto_CheckedChanged(sender As Object, e As EventArgs) Handles optNeto.CheckedChanged, optBruto.CheckedChanged
      CalcImportes()
   End Sub
   '
   Private Sub tbImporte_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbImporte.KeyPress, txtBonificacion.KeyPress, txtNoGravado.KeyPress
      SoloNumeros(e.KeyChar)
   End Sub
   '
   Private Sub tbImporte_TextChanged(sender As Object, e As EventArgs) Handles tbImporte.TextChanged, txtNoGravado.TextAlignChanged, txtBonificacion.TextChanged
      CalcImportes()
   End Sub
   '
   Private Sub CalcImportes()
      '
      Dim PrUnit As Double
      Dim Bonific As String
      Dim Bonif As New Collection
      Dim Pos As Integer
      Dim i As Int16
      '
      If Val(txtBonificacion.Text) <> 0 Then
         Bonific = txtBonificacion.Text
         Bonif.Add(Val(Bonific))
         Do While InStr(Bonific, "+") > 0
            Pos = InStr(Bonific, "+")
            Bonific = Strings.Right(Bonific, Len(Bonific) - Pos)
            Bonif.Add(Val(Bonific))
         Loop
      End If
      PrUnit = Val(IIf(optNeto.Checked, Val(tbImporte.Text), (Val(tbImporte.Text) / (1 + AlicIva / 100))))
      For i = 1 To Bonif.Count
         PrUnit = PrUnit - PrUnit * Val(Bonif.Item(i)) / 100
      Next i
      txtSubtotal.Text = Format(PrUnit + Val(txtNoGravado.Text), cfgFormatoPr)
   End Sub
   '
   Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
      Me.Close()
   End Sub
   '
   Private Sub frmComprasDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
      SetRegForm(Me)
      Me.Dispose()
   End Sub
   '
End Class