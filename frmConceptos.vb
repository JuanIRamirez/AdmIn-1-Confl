Public Class frmConceptos
   '
   Public Propietario As Int32
   Public Propiedad As Int32
   '
   Dim Inquilino As Int32
   '
   Dim Trn As OleDb.OleDbTransaction
   Dim Cmd As New OleDb.OleDbCommand
   Dim Drd As OleDb.OleDbDataReader
   '
   Dim NroCtto As Long
   Dim nCol As Integer
   Dim nRow As Integer
   '
   Private Sub frmConcFijos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      '
      GetRegForm(Me)
      '
      'ArmaComboItem(cbPropietario, "Propietarios", , "Nombre", "Nombre", "(Seleccionar)", "Estado = 'A'")
      'If Propietario <> 0 Then
      '   PosCboItem(cbPropietario, Propietario)
      '   cbPropietario.Enabled = False
      'End If
      ActData()
      '
   End Sub
   '
   Private Sub frmConcFijos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
      TabReturn(e.KeyChar)
   End Sub
   '
   Private Sub cmdListado_Click()
      '*frmListConcFijos.Show(1)
   End Sub
   '
   '
   'Private Sub cbPropiedad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPropiedad.SelectedIndexChanged
   '   'cbDescPrd.ListIndex = cbPropiedad.ListIndex
   '   With cbPropiedad
   '      If .SelectedIndex > 0 Then
   '         Propiedad = .SelectedValue
   '      Else
   '         Propiedad = 0
   '      End If
   '   End With
   '   Inquilino = Val(CapturaDato(Cn, "Propiedades", "Inquilino", "Codigo = " & Propiedad) & "")
   '   If Inquilino = 0 Then
   '      Inquilino = Val(CapturaDato(Cn, "Contratos", "Inquilino", "Propietario = " & Propietario & " AND Propiedad = " & Propiedad & " AND Estado = 0") & "")
   '   End If
   '   ActData()
   'End Sub
   '
   'Private Sub cbDescPrd_Change()
   '   PintarCb(cbDescPrd, LastKey)
   'End Sub
   ''
   'Private Sub cbDescPrd_Click()
   '   cbPropiedad.ListIndex = cbDescPrd.ListIndex
   'End Sub
   '
   'Private Sub cbPropietario_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPropietario.SelectedIndexChanged
   '   With cbPropietario
   '      If .SelectedIndex > 0 Then
   '         Propietario = .SelectedValue
   '      Else
   '         Propietario = 0
   '      End If
   '   End With
   '   ArmaComboItem(cbPropiedad, "Propiedades", , "Domicilio", "Domicilio", "Estado = 'A'" & IIf(Propietario = 0, "", " AND Propietario = " & Propietario))
   '   If Propiedad <> 0 Then
   '      PosCboItem(cbPropiedad, Propiedad)
   '      cbPropiedad.Enabled = False
   '   End If
   '   ActData()
   'End Sub
   '
   'Private Sub cbDescPrt_Change()
   '   PintarCb(cbDescPrt, LastKey)
   'End Sub
   ''
   'Private Sub cbDescPrt_Click()
   '   cbPropietario.ListIndex = cbDescPrt.ListIndex
   'End Sub
   '
   'Private Sub ArmaCbPrd()
   '   '
   '   cbPropiedad.Clear()
   '   cbDescPrd.Clear()
   '   '
   '   ArmaCombo(cbPropiedad, "Codigo", "Propiedades", cbDescPrd, "Domicilio", "Domicilio", "Propietario = " & Val(cbPropietario))
   '   If Propiedad <> 0 Then
   '      PosicionarCombo(cbPropiedad, Propiedad)
   '      cbPropiedad.Enabled = False
   '   End If
   '   '
   'End Sub
   '
   Sub ActData()
      '
      SetRegGrid(Me, DataGridView1)
   '
      LlenarGrid(DataGridView1, "SELECT C.Descrip, C.Codigo, C.Accion, L.Comision, C.Cuenta, C.CtaAdm, C.Prioridad " & _
                                "FROM Conceptos C LEFT JOIN Logicos L " & _
                                " ON C.Comision = L.Dato " & _
                                IIf(tbBuscar.Text = "", "", "WHERE C.Descrip LIKE '%" & tbBuscar.Text & "%' ") & _
                                "ORDER BY C.Descrip")
      '
      With DataGridView1
         cmdBaja.Enabled = (.RowCount > 0)
         cmdEditar.Enabled = (.RowCount > 0)
      End With
      '
      SetCols()
      '
      GetRegGrid(Me, DataGridView1)
      '
   End Sub
   '
   Private Sub SetCols()
      '
      With DataGridView1
         For Each Col As DataGridViewColumn In .Columns
            Select Case UCase(.Name)
               Case "CODIGO" : .Width = 80
               Case "DESCRIP" : .Width = 250
               Case "ACCION" : .Width = 40
               Case "COMISION" : .Width = 40
               Case "CUENTA" : .Width = 60
               Case "CTAADM" : .Width = 60
               Case "PRIORIDAD" : .Width = 40
            End Select
         Next Col
      End With
      '
   End Sub
   '
   '
   'Private Sub cmdImprimir_Click()
   '   ImprimirCrp("PropiedConc", crptToWindow, "{Propiedades.Propietario} = " & Val(cbPropietario), Me.Text)
   'End Sub
   '
   Private Sub cmdSalir_Click(sender As Object, e As EventArgs) Handles cmdSalir.Click
      Me.Close()
   End Sub
   '
   Private Sub frmConcFijos_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
      SetRegGrid(Me, DataGridView1)
      SetRegForm(Me)
      Me.Dispose()
   End Sub
   '
   Private Sub cmdBaja_Click(sender As Object, e As EventArgs) Handles cmdBaja.Click
      '
      Dim Codigo As String = ""
      Dim Usado As Boolean = True
      '
      With DataGridView1
         If .RowCount = 0 Then
            MensajeTrad("NoHayRegAct")
         Else
            Codigo = .SelectedCells(.Columns("Codigo").Index).Value()
         End If
      End With
      '
      If IsNothing(CapturaDato(Cn, "LiqInqDet", "TOP 1 Concepto", "Concepto = '" & Codigo & "'")) Then
         If IsNothing(CapturaDato(Cn, "FactInq", "TOP 1 Concepto", "Concepto = '" & Codigo & "'")) Then
            If IsNothing(CapturaDato(Cn, "VentasDet", "TOP 1 Concepto", "Concepto = '" & Codigo & "'")) Then
               If MsgBox(Traducir("Elimina") & " " & Codigo, vbQuestion & vbYesNo) = vbYes Then
                  Trn = Cn.BeginTransaction
                  With Cmd
                     .Connection = Cn
                     .Transaction = Trn
                     .CommandText = "DELETE FROM Conceptos WHERE Codigo = '" & Codigo & "'"
                     .ExecuteNonQuery()
                  End With
                  Trn.Commit()
                  ActData()
               End If
               Usado = False
            End If
         End If
      End If
      '
      If Usado Then
         MsgBox("Concepto en uso, no se puede eliminar")
      End If
      '
   End Sub
   '
   Private Sub cmdAlta_Click(sender As Object, e As EventArgs) Handles cmdAlta.Click
      AltaMod(True)
   End Sub
   '
   Private Sub cmdEditar_Click(sender As Object, e As EventArgs) Handles cmdEditar.Click
      AltaMod(False)
   End Sub
   '
   Private Sub AltaMod(Alta As Boolean)
      '
      Dim Concepto As String = ""
      '
      With DataGridView1
         If Not Alta Then
            If .RowCount = 0 Then
               MensajeTrad("DSelItem")
               Exit Sub
            End If
            Concepto = .SelectedCells(.Columns("Codigo").Index).Value()
         End If
      End With
      '
      With frmConceptosAM
         If Alta Then
            .Concepto = ""
         Else
            .Concepto = Concepto
         End If
         .Alta = Alta
         .ShowDialog(Me)
      End With
      '
      ActData()
      '
   End Sub
   '
   Private Sub DataGrid1_DblClick()
      'cmdEdicion_Click()
   End Sub
   '
   Private Sub tbBuscar_TextChanged(sender As Object, e As EventArgs) Handles tbBuscar.TextChanged
      ActData()
   End Sub
   '


End Class