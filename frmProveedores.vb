Public Class frmProveedores

   Dim Cmd As New OleDb.OleDbCommand
   'Dim rsLoc As ADODB.Recordset
   'Dim rsTIva As ADODB.Recordset
   'Dim rsPlan As ADODB.Recordset
   '
   Dim vAlta As Boolean
   Dim vAutoriza As Boolean
   '
   Private Sub frmProveedores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      '
      TraducirForm(Me)
      '
      GetRegForm(Me)
      '
      ArmaCombo(cbLocalidad, "Descrip", "Localidad", , , "Descrip", "(Todas)")
      ArmaCombo(cbTipoIva, "Descrip", "TipoIva", "Descrip", , , "(Seleccionar)")
      '
      Cmd.Connection = Cn
      ActData()
      '
      Exit Sub
      '
   End Sub
   '
   'Private Sub DataGrid1_RowColChange(LastRow As Object, ByVal LastCol As Integer)
   '   DataGrid1_Click()
   'End Sub
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
      Dim Proveedor As Integer
      '
      If Alta Then
         Proveedor = 0
      Else
         With DataGridView1
            If .RowCount > 0 Then
               Proveedor = .SelectedCells(.Columns("Codigo").Index).Value
            Else
               Exit Sub
            End If
         End With
      End If
      '
      With frmProveedoresAM
         .Alta = Alta
         .Proveedor = Proveedor
         .ShowDialog(Me)
         ActData()
      End With
      '
   End Sub
   '
   'Private Sub cmdCancelar_Click()
   '   'LimpiaCampos
   '   ActivaCampos(False)
   '   ActivaControles(1)
   'End Sub
   '
   'Private Sub cmdEdicion_Click()
   '   vAlta = False
   '   ActivaControles(2)
   '   ActivaCampos(True)
   '   tbNombre.SetFocus()
   'End Sub
   '
   Private Sub cmdBaja_Click(sender As Object, e As EventArgs) Handles cmdBaja.Click
      '
      Dim Del As MsgBoxResult
      Dim Proveedor As Integer
      Dim Nombre As String
      '
      With DataGridView1
         If .RowCount > 0 Then
            '
            Proveedor = .SelectedCells(.Columns("Codigo").Index).Value
            Nombre = .SelectedCells(.Columns("Nombre").Index).Value
            '
            If IsNothing(CapturaDato(Cn, "Compras", "Proveedor", "Proveedor = " & Proveedor)) Then
               If IsNothing(CapturaDato(Cn, "CompraOtr", "Proveedor", "Proveedor = " & Proveedor)) Then
                  If DaDeBaja("Proveedor " & Nombre) Then
                     Del = MsgBoxResult.Yes
                  End If
               End If
            End If
            '
            If Del = MsgBoxResult.Yes Then
               With Cmd
                  .CommandText = "DELETE FROM Proveedores WHERE Codigo = " & Proveedor
                  .ExecuteNonQuery()
               End With
               ActData()
            Else
               MsgBox("Proveedor con movimientos, no se puede eliminar", vbInformation)
            End If
            '
         End If
      End With
      '
   End Sub
   '
   'Private Sub cmdAceptar_Click()
   '   '
   '   If ValidaCampos() Then
   '      Guardar()
   '      Limpiacampos()
   '      ActivaCampos(False)
   '      ActivaControles(1)
   '   End If
   '   '
   'End Sub
   '
   Private Sub cmdSalir_Click()
      Me.Close()
   End Sub
   '
   'Private Sub DataGrid1_Click()
   '   '
   '   Dim i As Integer
   '   '
   '   If Adodc1.Recordset.RecordCount = 0 Then
   '      Limpiacampos()
   '      Exit Sub
   '   Else
   '      ActivaControles(1)
   '      With Cmd
   '         .Open("SELECT * FROM Proveedores WHERE Codigo = " & Adodc1.Recordset!Codigo, Cn, adOpenKeyset, adLockOptimistic)
   '         tbCodigo.Text = !Codigo
   '         tbNombre = !Nombre
   '         tbDomicilio = !Domicilio & ""
   '         tbProvincia = !Provincia & ""
   '         tbContacto = !Contacto & ""
   '         tbTelefono = !Telefono & ""
   '         tbFax = !Fax & ""
   '         tbEMail = !Email & ""
   '         If Not IsNull(!Cuit) Then
   '            tbCuit = !Cuit
   '         End If
   '         '
   '         cbLocalidad.ListIndex = -1
   '         For i = 0 To cbLocalidad.ListCount - 1
   '            If cbLocalidad.List(i) = !Localidad Then
   '               cbLocalidad.ListIndex = i
   '            End If
   '         Next i
   '         '
   '         cbTipoIva.ListIndex = -1
   '         For i = 0 To cbTipoIva.ListCount - 1
   '            If cbTipoIva.List(i) = !TipoIva Then
   '               cbTipoIva.ListIndex = i
   '            End If
   '         Next i
   '         '
   '         cbCuenta.ListIndex = -1
   '         For i = 0 To cbCuenta.ListCount - 1
   '            If cbCuenta.List(i) = !Cuenta Then
   '               cbCuenta.ListIndex = i
   '            End If
   '         Next i
   '         '
   '         .Close()
   '      End With
   '   End If
   '   '
   'End Sub
   '
   Private Sub tbBuscar_Change()
      ActData()
   End Sub
   '
   Private Sub ActData()
      '
      LlenarGrid(DataGridView1, "SELECT * " & _
                                "FROM Proveedores " & _
                                IIf(tbBuscar.Text = "", "", "WHERE Nombre LIKE '" & tbBuscar.Text & "%' ") & _
                                "ORDER BY Nombre")
      '
      With DataGridView1
         cmdBaja.Enabled = .RowCount > 0
         cmdEditar.Enabled = .RowCount > 0
      End With
      '
      SetCols()
      '
   End Sub
   '
   Private Sub SetCols()

      'Dim cCol As MSDBGrid.Column
      With DataGridView1
         For Each Col As DataGridViewColumn In .Columns
            With Col
               Select Case UCase(.Name)
                  Case "CODIGO" : .Width = 100
                  Case "NOMBRE" : .Width = 400
                     'Case Else : .Visible = False
               End Select
               'cCol.Caption = Traducir(cCol.Caption)
            End With
         Next
      End With
      '
   End Sub

   'Private Sub cListado_Click()
   '   frmLisPropiedades.Show()
   'End Sub

   'Private Sub tNombre_KeyPress(KeyAscii As Integer)
   '   Mayusculas KeyAscii
   'End Sub

   'Private Function ValidaCampos() As Boolean

   '   If Val(tbCodigo) < 0 Then
   '      MensajeTrad("DICodigo>0")
   '      tbCodigo.SetFocus()
   '      Exit Function
   '   Else
   '      If vAlta Then
   '         'With rsProv
   '         '   .Index = "Codigo"
   '         '   .Seek "=", tbCodigo
   '         '   If Not .NoMatch Then
   '         If Not IsEmpty(CapturaDato(Cn, "Proveedores", "Codigo", "Codigo = '" & tbCodigo & "'")) Then
   '            MensajeTrad("CodExist")
   '            tbCodigo.SetFocus()
   '            Exit Function
   '         End If
   '         'End With
   '      End If
   '   End If

   '   If tbNombre = "" Then
   '      MensajeTrad("DINombre")
   '      tbNombre.SetFocus()
   '      Exit Function
   '   End If

   '   If cbDescTIva = "" Then
   '      MensajeTrad("DITipoIva")
   '      cbDescTIva.SetFocus()
   '      Exit Function
   '   End If

   '   ValidaCampos = True

   'End Function

   'Private Sub Limpiacampos()

   '   Dim Ctrl As Control

   '   For Each Ctrl In Me.Controls
   '      If TypeOf Ctrl Is TextBox Then
   '         If Ctrl.Name <> "tbBuscar" Then
   '            Ctrl.Text = ""
   '         End If
   '      ElseIf TypeOf Ctrl Is MaskEdBox Then
   '         tbCuit.Text = "  -        - "
   '      ElseIf TypeOf Ctrl Is ComboBox Then
   '         If Ctrl.Style = 2 Then
   '            Ctrl.ListIndex = -1
   '         Else
   '            Ctrl = ""
   '         End If
   '      End If
   '   Next Ctrl

   'End Sub

   'Private Sub Guardar()

   '   With Cmd
   '      .Open("SELECT * FROM Proveedores WHERE Codigo = " & tbCodigo, Cn, adOpenKeyset, adLockOptimistic)
   '      If vAlta Then
   '         .AddNew()
   '         !Codigo = tbCodigo
   '         'Else
   '         '   .Edit
   '      End If
   '      !Nombre = tbNombre
   '      !Domicilio = tbDomicilio
   '      !Localidad = cbLocalidad
   '      !Provincia = tbProvincia
   '      !Contacto = tbContacto
   '      !Telefono = tbTelefono
   '      !Fax = tbFax
   '      !Email = tbEMail
   '      !TipoIva = cbTipoIva
   '      !Cuit = tbCuit
   '      !Cuenta = cbCuenta
   '      !Usuario = Uid
   '      !FechaMod = Now
   '      .Update()
   '      .Close()
   '   End With

   '   ActData()

   'End Sub

   'Private Sub DataGrid1_DblClick()
   '   cmdEdicion_Click()
   'End Sub

   'Private Sub tbCodigo_GotFocus()
   '   With tbCodigo
   '      .SelStart = 0
   '      .SelLength = Len(.Text)
   '   End With
   'End Sub

   'Private Sub tValor_KeyPress(KeyAscii As Integer)
   '   SoloNumeros(KeyAscii)
   'End Sub

   'Private Sub cbDescCta_Change()
   '   PintarCb(cbDescCta, LastKey)
   'End Sub

   'Private Sub cbDescCta_Click()
   '   cbCuenta.ListIndex = cbDescCta.ListIndex
   'End Sub

   'Private Sub cbCuenta_Click()
   '   cbDescCta.ListIndex = cbCuenta.ListIndex
   'End Sub

   'Private Sub ActivaCampos(Activo As Boolean)

   '   Dim Campo As Control

   '   For Each Campo In Me.Controls
   '      If TypeOf Campo Is TextBox Or _
   '         TypeOf Campo Is ComboBox Or _
   '         TypeOf Campo Is MaskEdBox Then
   '         If Campo.Name <> "tbBuscar" Then
   '            If vAlta Then
   '               Campo.Enabled = Activo
   '            Else
   '               If Campo.Name = "tbCodigo" Then
   '                  Campo.Enabled = False
   '               Else
   '                  Campo.Enabled = Activo
   '               End If
   '            End If
   '         End If
   '      End If
   '   Next Campo

   'End Sub

   'Private Sub ActivaControles(nOpcion As Integer)

   '   tbBuscar.Enabled = True
   '   DataGrid1.Enabled = True
   '   cmdSalir.Cancel = True

   '   cmdAceptar.Enabled = False
   '   cmdCancelar.Enabled = False
   '   cmdAlta.Enabled = False
   '   cmdEdicion.Enabled = False
   '   cmdBaja.Enabled = False

   '   If nOpcion = 1 Then
   '      cmdAlta.Enabled = True
   '      If Adodc1.Recordset.RecordCount > 0 Then
   '         cmdEdicion.Enabled = True
   '         cmdBaja.Enabled = True
   '      End If
   '   ElseIf nOpcion = 2 Then
   '      cmdAceptar.Enabled = True
   '      cmdCancelar.Enabled = True
   '      cmdCancelar.Cancel = True
   '      tbBuscar.Enabled = False
   '      DataGrid1.Enabled = False
   '   End If

   'End Sub

   'Private Sub tbCodigo_KeyPress(KeyAscii As Integer)
   '   SoloNumeros(KeyAscii, False)
   'End Sub
   '
   'Private Sub cbTipoIva_Click()
   '   cbDescTIva.ListIndex = cbTipoIva.ListIndex
   'End Sub
   '
   'Private Sub cbDescTIva_Click()
   '   cbTipoIva.ListIndex = cbDescTIva.ListIndex
   'End Sub
   '
   Private Sub frmProveedores_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
      SetRegGrid(Me, DataGridView1)
      SetRegForm(Me)
      Me.Dispose()
   End Sub
   '
End Class