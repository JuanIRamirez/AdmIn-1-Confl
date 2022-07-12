Public Class frmVentasAMDet

   Public Tabla As String
   '
   Public Alta As Boolean
   Public cmpINT As String
   Public Letra As String
   Public Concepto As Long
   Public Renglon As Integer
   Public AlicIva As String
   Public Detalle As String = ""
   '
   Dim Trn As OleDb.OleDbTransaction
   Dim Cmd As New OleDb.OleDbCommand
   Dim Drd As OleDb.OleDbDataReader
   '
   Dim ConcDef As Integer = 0
   Dim AlicuoIva As Single
   '
   Private Sub frmVentasAMDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      '
      GetRegForm(Me)
      '
      armacbconceptos()
      ArmaCombo(cbAlicIva, "Alicuo1", "AlicIva", "AlicIva", , , "")
      '
      'ConcDef = Val(CapturaDato(cn, "Conceptos", "Concepto", "ConcDef <> 0") & "")
      '
      If Letra = "B" Then
         optBruto.Checked = True
         'optBruto.Enabled = False
         'optNeto.Enabled = False
      End If
      '
      If Alta Then
         Me.Text = "Ventas - " & Traducir("Alta")
         If ConcDef <> 0 Then
            PosCboItem(cboConcepto, ConcDef)
         End If
         PosCombo(cbAlicIva, cfgAlicIva)
         If optNeto.Checked Then
            'optBruto.Checked = GetConfigUsu(Me, optBruto)
         End If
      Else
         Me.Text = "Ventas - " & Traducir("Edición")
         PosCombo(cbAlicIva, AlicIva)
         With Cmd
            .Connection = cn
            .CommandText = "SELECT * FROM " & Tabla & " WHERE Renglon = " & Renglon
            Drd = .ExecuteReader
         End With
         With Drd
            If .Read Then
               PosCboItem(cboConcepto, !Concepto)
               tbDetalle.Text = IIf(Detalle <> "", Detalle, !Detalle)
               If !Cantidad > 0 Then
                  optDebe.Checked = True
               Else
                  optHaber.Checked = True
               End If
               txtPrecio.Text = Format(!Precio, cfgFormatoPr)
               tbBonificacion.Text = !Bonificacion & ""
            End If
            .Close()
         End With
      End If
      '
      btnAgrConc.Enabled = TienePermiso(cn, Uid, frmMenu.mConceptos.Name)
      '
   End Sub
   '
   Private Sub frmVentasAMDet_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
      TabReturn(e.KeyChar)
   End Sub
   '
   Private Sub armacbconceptos()
      ArmaComboItem(cboConcepto, "Conceptos", "ConceptoId", "Descrip", , , "ConceptoId <> 0")
   End Sub
   '
   Private Sub CboConcepto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboConcepto.SelectedIndexChanged
      '
      With cboConcepto
         If .SelectedIndex > 0 Then
            Concepto = .SelectedValue
         Else
            Concepto = 0
         End If
      End With
      '
      If Alta Then
         tbDetalle.Text = cboConcepto.Text
         'txtPrecio.Text = Val(CapturaDato(Cn, "Conceptos", "ValorNeto", "Codigo = " & Concepto) & "")
      End If
      '
      AlicIva = "GEN"   ' CapturaDato(Cn, "Conceptos", "AlicIva", "Codigo = " & Concepto) & ""
      '
      If AlicIva = "" Then
         AlicuoIva = cfgAlicIva
      Else
         AlicuoIva = Val(CapturaDato(cn, "AlicIva", "Alicuo1", "AlicIva = '" & AlicIva & "'"))
      End If
      '
      PosCombo(cbAlicIva, AlicuoIva)
      '
   End Sub
   '
   'Private Sub cboConcepto_Change()
   '   If cboConcepto.Text = "" Then
   '      Concepto = 0
   '   End If
   'End Sub
   '
   Private Sub cmdAceptar_Click(sender As Object, e As EventArgs) Handles cmdAceptar.Click
      '
      Dim Precio As Double
      Dim SubTotal As Double
      ' Dim PrUnit As Double
      '
      If tbDetalle.Text = "" Then
         MensajeTrad("DIDetalle", , False)
         tbDetalle.Focus()
         Exit Sub
      End If
      '
      If Val(txtPrecio.Text) <= 0 Then
         MensajeTrad("DII>0", , False)
         txtPrecio.Focus()
         Exit Sub
      End If
      '
      Precio = txtPrecio.Text
      SubTotal = tbSubtotal.Text
      '
      'If Letra = "B" Then
      '   If optNeto.Checked Then
      '      Precio = Precio * (1 + AlicuoIva / 100)
      '   End If
      '   SubTotal = SubTotal * (1 + AlicuoIva / 100)
      'End If
      '
      Trn = cn.BeginTransaction
      '
      With Cmd
         .Connection = cn
         .Transaction = Trn
         If Alta Then
            .CommandText = "INSERT INTO " & Tabla & "(Renglon, Comprob, Concepto, Cantidad, Precio, Bonificacion, SubTotal, Detalle, AlicuoIva) " &
                           "VALUES( " & Renglon & ", " &
                                  "'" & cmpINT & "', " &
                                        Concepto & ", " &
                                        IIf(optDebe.Checked, 1, -1) & ", " &
                                        Precio & ", " &
                                  "'" & tbBonificacion.Text & "', " &
                                        SubTotal & ", " &
                                  "'" & tbDetalle.Text & "', " &
                                        AlicuoIva & ")"
         Else
            .CommandText = "UPDATE " & Tabla & " SET " &
                           " Comprob = '" & cmpINT & "', " &
                           " Concepto = " & Concepto & ", " &
                           " Cantidad = " & IIf(optDebe.Checked, 1, -1) & ", " &
                           " Precio = " & Precio & ", " &
                           " Bonificacion = '" & tbBonificacion.Text & "', " &
                           " SubTotal = " & SubTotal & ", " &
                           " Detalle = '" & tbDetalle.Text & "', " &
                           " AlicuoIva = " & AlicuoIva & " " &
                           " WHERE Renglon = " & Renglon
         End If
         .ExecuteNonQuery()
      End With
      '
      Trn.Commit()
      '
      If Alta Then
         'SetConfigUsu(Me, optBruto, optBruto.Checked)
      End If
      '
      Me.Close()
      '
   End Sub
   '
   Private Sub cbAlicIva_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbAlicIva.SelectedIndexChanged
      AlicuoIva = Val(cbAlicIva.Text)
      CalcImportes()
   End Sub
   '
   Private Sub optBruto_Click() Handles optBruto.Click, optNeto.Click
      CalcImportes()
   End Sub
   '
   Private Sub tbDetalle_GotFocus()
      'PintarTb tbDetalle
   End Sub
   '
   Private Sub tbBonificacion_TextChanged(sender As Object, e As EventArgs) Handles tbBonificacion.TextChanged
      CalcImportes()
   End Sub

   Private Sub txtPrecio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrecio.KeyPress, tbIva.KeyPress
      SoloNumeros(e.KeyChar, True)
   End Sub

   Private Sub txtPrecio_TextChanged(sender As Object, e As EventArgs) Handles txtPrecio.TextChanged
      CalcImportes()
   End Sub
   '
   Private Sub tbBonificacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbBonificacion.KeyPress
      SoloNumeros(e.KeyChar, True, , "+")
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
      If Val(tbBonificacion.Text) <> 0 Then
         Bonific = tbBonificacion.Text
         Bonif.Add(Val(Bonific))
         Do While InStr(Bonific, "+") > 0
            Pos = InStr(Bonific, "+")
            Bonific = Strings.Right(Bonific, Len(Bonific) - Pos)
            Bonif.Add(Val(Bonific))
         Loop
      End If
      '
      'PrUnit = Val(IIf(optNeto.Checked, Val(txtPrecio.Text), (Val(txtPrecio.Text) / (1 + AlicuoIva / 100))))
      PrUnit = Val(txtPrecio.Text)
      '
      For i = 1 To Bonif.Count
         PrUnit = PrUnit - PrUnit * Val(Bonif.Item(i)) / 100
      Next i
      '
      If optNeto.Checked Then
         tbSubtotal.Text = Format(PrUnit, cfgFormatoPr)
         tbIva.Text = Format(Math.Round(PrUnit * AlicuoIva / 100, 2), cfgFormatoPr)
         tbTotal.Text = Format(Val(tbSubtotal.Text) + Val(tbIva.Text), cfgFormatoPr)
      Else
         tbTotal.Text = Format(PrUnit, cfgFormatoPr)
         tbSubtotal.Text = Format(Math.Round(PrUnit / (1 + AlicuoIva / 100), 2), cfgFormatoPr)
         tbIva.Text = Format(Val(tbTotal.Text) - Val(tbSubtotal.Text), cfgFormatoPr)
      End If
      '
   End Sub
   '
   Private Sub brnAgrConc_Click(sender As Object, e As EventArgs) Handles btnAgrConc.Click
      Dim frm As New frmConceptosAM
      With frm
         .Alta = True
         .ShowDialog(Me)
         armacbconceptos()
      End With
   End Sub
   '
   Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
      Me.Close()
   End Sub
   '
   Private Sub frmVentasAMDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
      SetRegForm(Me)
   End Sub
   '
End Class