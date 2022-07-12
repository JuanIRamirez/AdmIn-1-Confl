<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmComprasOtrAM
   Inherits System.Windows.Forms.Form

   'Form overrides dispose to clean up the component list.
   <System.Diagnostics.DebuggerNonUserCode()> _
   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      Try
         If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
         End If
      Finally
         MyBase.Dispose(disposing)
      End Try
   End Sub

   'Required by the Windows Form Designer
   Private components As System.ComponentModel.IContainer

   'NOTE: The following procedure is required by the Windows Form Designer
   'It can be modified using the Windows Form Designer.  
   'Do not modify it using the code editor.
   <System.Diagnostics.DebuggerStepThrough()> _
   Private Sub InitializeComponent()
      Me.cbProveedor = New System.Windows.Forms.ComboBox()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.dtpFecVenc = New System.Windows.Forms.DateTimePicker()
      Me.tbNumero = New System.Windows.Forms.TextBox()
      Me.tbSucursal = New System.Windows.Forms.TextBox()
      Me.lblFactura = New System.Windows.Forms.Label()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.DataGridView1 = New System.Windows.Forms.DataGridView()
      Me.cmdEdicion = New System.Windows.Forms.Button()
      Me.cmdAlta = New System.Windows.Forms.Button()
      Me.cmdBaja = New System.Windows.Forms.Button()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.tbTotal = New System.Windows.Forms.TextBox()
      Me.tbDetalle = New System.Windows.Forms.TextBox()
      Me.cmdGuardar = New System.Windows.Forms.Button()
      Me.cmdCancelar = New System.Windows.Forms.Button()
      Me.cbPropietario = New System.Windows.Forms.ComboBox()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.cbPropiedad = New System.Windows.Forms.ComboBox()
      Me.Label7 = New System.Windows.Forms.Label()
      Me.Label9 = New System.Windows.Forms.Label()
      Me.btnAceptar = New System.Windows.Forms.Button()
      Me.btnSalir = New System.Windows.Forms.Button()
      Me.btnNuevoProv = New System.Windows.Forms.Button()
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'cbProveedor
      '
      Me.cbProveedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      Me.cbProveedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.cbProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbProveedor.FormattingEnabled = True
      Me.cbProveedor.Location = New System.Drawing.Point(71, 11)
      Me.cbProveedor.Name = "cbProveedor"
      Me.cbProveedor.Size = New System.Drawing.Size(406, 21)
      Me.cbProveedor.TabIndex = 141
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.Location = New System.Drawing.Point(10, 15)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(59, 13)
      Me.Label5.TabIndex = 142
      Me.Label5.Text = "Proveedor:"
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(29, 42)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(40, 13)
      Me.Label4.TabIndex = 144
      Me.Label4.Text = "Fecha:"
      '
      'dtpFecha
      '
      Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpFecha.Location = New System.Drawing.Point(71, 38)
      Me.dtpFecha.Name = "dtpFecha"
      Me.dtpFecha.Size = New System.Drawing.Size(81, 20)
      Me.dtpFecha.TabIndex = 143
      Me.dtpFecha.Value = New Date(2015, 9, 24, 0, 0, 0, 0)
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(198, 42)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(38, 13)
      Me.Label1.TabIndex = 146
      Me.Label1.Text = "Venc.:"
      '
      'dtpFecVenc
      '
      Me.dtpFecVenc.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpFecVenc.Location = New System.Drawing.Point(242, 38)
      Me.dtpFecVenc.Name = "dtpFecVenc"
      Me.dtpFecVenc.Size = New System.Drawing.Size(81, 20)
      Me.dtpFecVenc.TabIndex = 145
      Me.dtpFecVenc.Value = New Date(2015, 9, 24, 0, 0, 0, 0)
      '
      'tbNumero
      '
      Me.tbNumero.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.tbNumero.Location = New System.Drawing.Point(693, 12)
      Me.tbNumero.MaxLength = 10
      Me.tbNumero.Name = "tbNumero"
      Me.tbNumero.Size = New System.Drawing.Size(83, 20)
      Me.tbNumero.TabIndex = 148
      Me.tbNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'tbSucursal
      '
      Me.tbSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.tbSucursal.Location = New System.Drawing.Point(582, 12)
      Me.tbSucursal.MaxLength = 4
      Me.tbSucursal.Name = "tbSucursal"
      Me.tbSucursal.Size = New System.Drawing.Size(48, 20)
      Me.tbSucursal.TabIndex = 147
      Me.tbSucursal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblFactura
      '
      Me.lblFactura.AutoSize = True
      Me.lblFactura.Location = New System.Drawing.Point(518, 15)
      Me.lblFactura.Name = "lblFactura"
      Me.lblFactura.Size = New System.Drawing.Size(58, 13)
      Me.lblFactura.TabIndex = 149
      Me.lblFactura.Text = "Sucursal #"
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(636, 15)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(54, 13)
      Me.Label2.TabIndex = 150
      Me.Label2.Text = "Número #"
      '
      'DataGridView1
      '
      Me.DataGridView1.AllowUserToAddRows = False
      Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
      Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.DataGridView1.Location = New System.Drawing.Point(11, 93)
      Me.DataGridView1.Name = "DataGridView1"
      Me.DataGridView1.ReadOnly = True
      Me.DataGridView1.RowTemplate.ReadOnly = True
      Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.DataGridView1.Size = New System.Drawing.Size(843, 294)
      Me.DataGridView1.TabIndex = 151
      '
      'cmdEdicion
      '
      Me.cmdEdicion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdEdicion.Enabled = False
      Me.cmdEdicion.Location = New System.Drawing.Point(172, 393)
      Me.cmdEdicion.Name = "cmdEdicion"
      Me.cmdEdicion.Size = New System.Drawing.Size(76, 27)
      Me.cmdEdicion.TabIndex = 154
      Me.cmdEdicion.Text = "&Modificar"
      Me.cmdEdicion.UseVisualStyleBackColor = True
      '
      'cmdAlta
      '
      Me.cmdAlta.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdAlta.Enabled = False
      Me.cmdAlta.Location = New System.Drawing.Point(8, 393)
      Me.cmdAlta.Name = "cmdAlta"
      Me.cmdAlta.Size = New System.Drawing.Size(76, 27)
      Me.cmdAlta.TabIndex = 152
      Me.cmdAlta.Text = "&Alta"
      Me.cmdAlta.UseVisualStyleBackColor = True
      '
      'cmdBaja
      '
      Me.cmdBaja.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdBaja.Enabled = False
      Me.cmdBaja.Location = New System.Drawing.Point(90, 393)
      Me.cmdBaja.Name = "cmdBaja"
      Me.cmdBaja.Size = New System.Drawing.Size(76, 27)
      Me.cmdBaja.TabIndex = 153
      Me.cmdBaja.Text = "&Baja"
      Me.cmdBaja.UseVisualStyleBackColor = True
      '
      'Label3
      '
      Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(709, 400)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(40, 13)
      Me.Label3.TabIndex = 156
      Me.Label3.Text = "Total $"
      '
      'tbTotal
      '
      Me.tbTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tbTotal.BackColor = System.Drawing.Color.LightYellow
      Me.tbTotal.Enabled = False
      Me.tbTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.tbTotal.Location = New System.Drawing.Point(761, 397)
      Me.tbTotal.Name = "tbTotal"
      Me.tbTotal.Size = New System.Drawing.Size(94, 20)
      Me.tbTotal.TabIndex = 155
      Me.tbTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'tbDetalle
      '
      Me.tbDetalle.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.tbDetalle.Enabled = False
      Me.tbDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.tbDetalle.Location = New System.Drawing.Point(258, 393)
      Me.tbDetalle.Multiline = True
      Me.tbDetalle.Name = "tbDetalle"
      Me.tbDetalle.Size = New System.Drawing.Size(423, 89)
      Me.tbDetalle.TabIndex = 157
      '
      'cmdGuardar
      '
      Me.cmdGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdGuardar.Enabled = False
      Me.cmdGuardar.Location = New System.Drawing.Point(688, 432)
      Me.cmdGuardar.Name = "cmdGuardar"
      Me.cmdGuardar.Size = New System.Drawing.Size(85, 25)
      Me.cmdGuardar.TabIndex = 159
      Me.cmdGuardar.Text = "&Guardar"
      Me.cmdGuardar.UseVisualStyleBackColor = True
      '
      'cmdCancelar
      '
      Me.cmdCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdCancelar.Enabled = False
      Me.cmdCancelar.Location = New System.Drawing.Point(779, 432)
      Me.cmdCancelar.Name = "cmdCancelar"
      Me.cmdCancelar.Size = New System.Drawing.Size(75, 25)
      Me.cmdCancelar.TabIndex = 158
      Me.cmdCancelar.Text = "&Cancelar"
      Me.cmdCancelar.UseVisualStyleBackColor = True
      '
      'cbPropietario
      '
      Me.cbPropietario.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      Me.cbPropietario.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.cbPropietario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbPropietario.FormattingEnabled = True
      Me.cbPropietario.Location = New System.Drawing.Point(71, 66)
      Me.cbPropietario.Name = "cbPropietario"
      Me.cbPropietario.Size = New System.Drawing.Size(370, 21)
      Me.cbPropietario.TabIndex = 160
      '
      'Label6
      '
      Me.Label6.AutoSize = True
      Me.Label6.Location = New System.Drawing.Point(10, 69)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(60, 13)
      Me.Label6.TabIndex = 161
      Me.Label6.Text = "Propietario:"
      '
      'cbPropiedad
      '
      Me.cbPropiedad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      Me.cbPropiedad.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.cbPropiedad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbPropiedad.FormattingEnabled = True
      Me.cbPropiedad.Location = New System.Drawing.Point(511, 66)
      Me.cbPropiedad.Name = "cbPropiedad"
      Me.cbPropiedad.Size = New System.Drawing.Size(341, 21)
      Me.cbPropiedad.TabIndex = 162
      '
      'Label7
      '
      Me.Label7.AutoSize = True
      Me.Label7.Location = New System.Drawing.Point(447, 69)
      Me.Label7.Name = "Label7"
      Me.Label7.Size = New System.Drawing.Size(58, 13)
      Me.Label7.TabIndex = 163
      Me.Label7.Text = "Propiedad:"
      '
      'Label9
      '
      Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.Label9.AutoSize = True
      Me.Label9.Location = New System.Drawing.Point(209, 432)
      Me.Label9.Name = "Label9"
      Me.Label9.Size = New System.Drawing.Size(43, 13)
      Me.Label9.TabIndex = 166
      Me.Label9.Text = "Detalle:"
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(794, 7)
      Me.btnAceptar.Name = "btnAceptar"
      Me.btnAceptar.Size = New System.Drawing.Size(62, 28)
      Me.btnAceptar.TabIndex = 167
      Me.btnAceptar.Text = "&Aceptar"
      Me.btnAceptar.UseVisualStyleBackColor = True
      '
      'btnSalir
      '
      Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnSalir.Location = New System.Drawing.Point(779, 463)
      Me.btnSalir.Name = "btnSalir"
      Me.btnSalir.Size = New System.Drawing.Size(75, 25)
      Me.btnSalir.TabIndex = 168
      Me.btnSalir.Text = "&Salir"
      Me.btnSalir.UseVisualStyleBackColor = True
      '
      'btnNuevoProv
      '
      Me.btnNuevoProv.Location = New System.Drawing.Point(483, 10)
      Me.btnNuevoProv.Name = "btnNuevoProv"
      Me.btnNuevoProv.Size = New System.Drawing.Size(29, 23)
      Me.btnNuevoProv.TabIndex = 169
      Me.btnNuevoProv.Text = "..."
      Me.btnNuevoProv.UseVisualStyleBackColor = True
      '
      'frmComprasOtrAM
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(864, 500)
      Me.Controls.Add(Me.btnNuevoProv)
      Me.Controls.Add(Me.btnSalir)
      Me.Controls.Add(Me.btnAceptar)
      Me.Controls.Add(Me.Label9)
      Me.Controls.Add(Me.cbPropiedad)
      Me.Controls.Add(Me.Label7)
      Me.Controls.Add(Me.cbPropietario)
      Me.Controls.Add(Me.Label6)
      Me.Controls.Add(Me.cmdGuardar)
      Me.Controls.Add(Me.cmdCancelar)
      Me.Controls.Add(Me.tbDetalle)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.tbTotal)
      Me.Controls.Add(Me.cmdEdicion)
      Me.Controls.Add(Me.cmdAlta)
      Me.Controls.Add(Me.cmdBaja)
      Me.Controls.Add(Me.DataGridView1)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.tbNumero)
      Me.Controls.Add(Me.tbSucursal)
      Me.Controls.Add(Me.lblFactura)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.dtpFecVenc)
      Me.Controls.Add(Me.Label4)
      Me.Controls.Add(Me.dtpFecha)
      Me.Controls.Add(Me.cbProveedor)
      Me.Controls.Add(Me.Label5)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.KeyPreview = True
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "frmComprasOtrAM"
      Me.Text = "Otros Comprobantes"
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents cbProveedor As System.Windows.Forms.ComboBox
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents dtpFecVenc As System.Windows.Forms.DateTimePicker
   Friend WithEvents tbNumero As System.Windows.Forms.TextBox
   Friend WithEvents tbSucursal As System.Windows.Forms.TextBox
   Friend WithEvents lblFactura As System.Windows.Forms.Label
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
   Friend WithEvents cmdEdicion As System.Windows.Forms.Button
   Friend WithEvents cmdAlta As System.Windows.Forms.Button
   Friend WithEvents cmdBaja As System.Windows.Forms.Button
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents tbTotal As System.Windows.Forms.TextBox
   Public WithEvents tbDetalle As System.Windows.Forms.TextBox
   Friend WithEvents cmdGuardar As System.Windows.Forms.Button
   Friend WithEvents cmdCancelar As System.Windows.Forms.Button
   Friend WithEvents cbPropietario As System.Windows.Forms.ComboBox
   Friend WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents cbPropiedad As System.Windows.Forms.ComboBox
   Friend WithEvents Label7 As System.Windows.Forms.Label
   Friend WithEvents Label9 As System.Windows.Forms.Label
   Friend WithEvents btnAceptar As System.Windows.Forms.Button
   Friend WithEvents btnSalir As System.Windows.Forms.Button
   Friend WithEvents btnNuevoProv As System.Windows.Forms.Button
End Class
