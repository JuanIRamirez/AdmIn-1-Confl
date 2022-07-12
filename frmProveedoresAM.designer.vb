<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProveedoresAM
   Inherits System.Windows.Forms.Form

   'Form reemplaza a Dispose para limpiar la lista de componentes.
   <System.Diagnostics.DebuggerNonUserCode()> _
   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing AndAlso components IsNot Nothing Then
         components.Dispose()
      End If
      MyBase.Dispose(disposing)
   End Sub

   'Requerido por el Diseñador de Windows Forms
   Private components As System.ComponentModel.IContainer

   'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
   'Se puede modificar usando el Diseñador de Windows Forms.  
   'No lo modifique con el editor de código.
   <System.Diagnostics.DebuggerStepThrough()> _
   Private Sub InitializeComponent()
      Me.lblEfectivo = New System.Windows.Forms.Label()
      Me.tbCodigo = New System.Windows.Forms.TextBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.tbNombre = New System.Windows.Forms.TextBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.tbDomicilio = New System.Windows.Forms.TextBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.cboLocalidad = New System.Windows.Forms.ComboBox()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.cboProvincia = New System.Windows.Forms.ComboBox()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.txtCodPostal = New System.Windows.Forms.TextBox()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.tbContacto = New System.Windows.Forms.TextBox()
      Me.Label7 = New System.Windows.Forms.Label()
      Me.tbTelefono = New System.Windows.Forms.TextBox()
      Me.Label8 = New System.Windows.Forms.Label()
      Me.tbFax = New System.Windows.Forms.TextBox()
      Me.Label9 = New System.Windows.Forms.Label()
      Me.tbEMail = New System.Windows.Forms.TextBox()
      Me.tbCuit = New System.Windows.Forms.MaskedTextBox()
      Me.Label10 = New System.Windows.Forms.Label()
      Me.Label11 = New System.Windows.Forms.Label()
      Me.cboTipoIva = New System.Windows.Forms.ComboBox()
      Me.Label13 = New System.Windows.Forms.Label()
      Me.cboCtaCont = New System.Windows.Forms.ComboBox()
      Me.Label14 = New System.Windows.Forms.Label()
      Me.cboCondVenta = New System.Windows.Forms.ComboBox()
      Me.cmdAceptar = New System.Windows.Forms.Button()
      Me.cmdCancelar = New System.Windows.Forms.Button()
      Me.SuspendLayout()
      '
      'lblEfectivo
      '
      Me.lblEfectivo.AutoSize = True
      Me.lblEfectivo.Location = New System.Drawing.Point(22, 41)
      Me.lblEfectivo.Name = "lblEfectivo"
      Me.lblEfectivo.Size = New System.Drawing.Size(50, 13)
      Me.lblEfectivo.TabIndex = 91
      Me.lblEfectivo.Text = "Código #"
      '
      'tbCodigo
      '
      Me.tbCodigo.Location = New System.Drawing.Point(98, 38)
      Me.tbCodigo.MaxLength = 10
      Me.tbCodigo.Name = "tbCodigo"
      Me.tbCodigo.Size = New System.Drawing.Size(71, 20)
      Me.tbCodigo.TabIndex = 0
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(22, 67)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(47, 13)
      Me.Label1.TabIndex = 93
      Me.Label1.Text = "Nombre:"
      '
      'tbNombre
      '
      Me.tbNombre.Location = New System.Drawing.Point(98, 64)
      Me.tbNombre.Name = "tbNombre"
      Me.tbNombre.Size = New System.Drawing.Size(388, 20)
      Me.tbNombre.TabIndex = 1
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(22, 93)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(52, 13)
      Me.Label2.TabIndex = 95
      Me.Label2.Text = "Domicilio:"
      '
      'tbDomicilio
      '
      Me.tbDomicilio.Location = New System.Drawing.Point(98, 90)
      Me.tbDomicilio.Name = "tbDomicilio"
      Me.tbDomicilio.Size = New System.Drawing.Size(351, 20)
      Me.tbDomicilio.TabIndex = 2
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(22, 148)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(56, 13)
      Me.Label3.TabIndex = 96
      Me.Label3.Text = "Localidad:"
      '
      'cboLocalidad
      '
      Me.cboLocalidad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      Me.cboLocalidad.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.cboLocalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboLocalidad.FormattingEnabled = True
      Me.cboLocalidad.Location = New System.Drawing.Point(98, 145)
      Me.cboLocalidad.Name = "cboLocalidad"
      Me.cboLocalidad.Size = New System.Drawing.Size(351, 21)
      Me.cboLocalidad.TabIndex = 4
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(22, 121)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(54, 13)
      Me.Label4.TabIndex = 98
      Me.Label4.Text = "Provincia:"
      '
      'cboProvincia
      '
      Me.cboProvincia.FormattingEnabled = True
      Me.cboProvincia.Location = New System.Drawing.Point(98, 118)
      Me.cboProvincia.Name = "cboProvincia"
      Me.cboProvincia.Size = New System.Drawing.Size(351, 21)
      Me.cboProvincia.TabIndex = 3
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.Location = New System.Drawing.Point(22, 175)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(52, 13)
      Me.Label5.TabIndex = 101
      Me.Label5.Text = "C. Postal:"
      '
      'txtCodPostal
      '
      Me.txtCodPostal.Location = New System.Drawing.Point(98, 172)
      Me.txtCodPostal.Name = "txtCodPostal"
      Me.txtCodPostal.Size = New System.Drawing.Size(167, 20)
      Me.txtCodPostal.TabIndex = 5
      '
      'Label6
      '
      Me.Label6.AutoSize = True
      Me.Label6.Location = New System.Drawing.Point(22, 201)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(53, 13)
      Me.Label6.TabIndex = 103
      Me.Label6.Text = "Contacto:"
      '
      'tbContacto
      '
      Me.tbContacto.Location = New System.Drawing.Point(98, 198)
      Me.tbContacto.Name = "tbContacto"
      Me.tbContacto.Size = New System.Drawing.Size(351, 20)
      Me.tbContacto.TabIndex = 6
      '
      'Label7
      '
      Me.Label7.AutoSize = True
      Me.Label7.Location = New System.Drawing.Point(22, 227)
      Me.Label7.Name = "Label7"
      Me.Label7.Size = New System.Drawing.Size(62, 13)
      Me.Label7.TabIndex = 105
      Me.Label7.Text = "Teléfono/s:"
      '
      'tbTelefono
      '
      Me.tbTelefono.Location = New System.Drawing.Point(98, 224)
      Me.tbTelefono.Name = "tbTelefono"
      Me.tbTelefono.Size = New System.Drawing.Size(194, 20)
      Me.tbTelefono.TabIndex = 7
      '
      'Label8
      '
      Me.Label8.AutoSize = True
      Me.Label8.Location = New System.Drawing.Point(43, 253)
      Me.Label8.Name = "Label8"
      Me.Label8.Size = New System.Drawing.Size(47, 13)
      Me.Label8.TabIndex = 107
      Me.Label8.Text = "Tel/Fax:"
      '
      'tbFax
      '
      Me.tbFax.Location = New System.Drawing.Point(98, 250)
      Me.tbFax.Name = "tbFax"
      Me.tbFax.Size = New System.Drawing.Size(194, 20)
      Me.tbFax.TabIndex = 8
      '
      'Label9
      '
      Me.Label9.AutoSize = True
      Me.Label9.Location = New System.Drawing.Point(52, 279)
      Me.Label9.Name = "Label9"
      Me.Label9.Size = New System.Drawing.Size(38, 13)
      Me.Label9.TabIndex = 109
      Me.Label9.Text = "E-mail:"
      '
      'tbEMail
      '
      Me.tbEMail.Location = New System.Drawing.Point(98, 276)
      Me.tbEMail.Name = "tbEMail"
      Me.tbEMail.Size = New System.Drawing.Size(351, 20)
      Me.tbEMail.TabIndex = 9
      '
      'tbCuit
      '
      Me.tbCuit.Location = New System.Drawing.Point(349, 308)
      Me.tbCuit.Mask = "00-00000000-0"
      Me.tbCuit.Name = "tbCuit"
      Me.tbCuit.Size = New System.Drawing.Size(100, 20)
      Me.tbCuit.TabIndex = 11
      '
      'Label10
      '
      Me.Label10.AutoSize = True
      Me.Label10.Location = New System.Drawing.Point(308, 311)
      Me.Label10.Name = "Label10"
      Me.Label10.Size = New System.Drawing.Size(35, 13)
      Me.Label10.TabIndex = 112
      Me.Label10.Text = "CUIT:"
      '
      'Label11
      '
      Me.Label11.AutoSize = True
      Me.Label11.Location = New System.Drawing.Point(39, 311)
      Me.Label11.Name = "Label11"
      Me.Label11.Size = New System.Drawing.Size(51, 13)
      Me.Label11.TabIndex = 110
      Me.Label11.Text = "Tipo IVA:"
      '
      'cboTipoIva
      '
      Me.cboTipoIva.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboTipoIva.FormattingEnabled = True
      Me.cboTipoIva.Location = New System.Drawing.Point(98, 307)
      Me.cboTipoIva.Name = "cboTipoIva"
      Me.cboTipoIva.Size = New System.Drawing.Size(194, 21)
      Me.cboTipoIva.TabIndex = 10
      '
      'Label13
      '
      Me.Label13.AutoSize = True
      Me.Label13.Location = New System.Drawing.Point(33, 342)
      Me.Label13.Name = "Label13"
      Me.Label13.Size = New System.Drawing.Size(57, 13)
      Me.Label13.TabIndex = 116
      Me.Label13.Text = "Cta. Cont.:"
      '
      'cboCtaCont
      '
      Me.cboCtaCont.FormattingEnabled = True
      Me.cboCtaCont.Location = New System.Drawing.Point(98, 339)
      Me.cboCtaCont.Name = "cboCtaCont"
      Me.cboCtaCont.Size = New System.Drawing.Size(351, 21)
      Me.cboCtaCont.TabIndex = 12
      '
      'Label14
      '
      Me.Label14.AutoSize = True
      Me.Label14.Location = New System.Drawing.Point(22, 369)
      Me.Label14.Name = "Label14"
      Me.Label14.Size = New System.Drawing.Size(69, 13)
      Me.Label14.TabIndex = 118
      Me.Label14.Text = "Cond. Venta:"
      '
      'cboCondVenta
      '
      Me.cboCondVenta.FormattingEnabled = True
      Me.cboCondVenta.Location = New System.Drawing.Point(98, 366)
      Me.cboCondVenta.Name = "cboCondVenta"
      Me.cboCondVenta.Size = New System.Drawing.Size(194, 21)
      Me.cboCondVenta.TabIndex = 14
      '
      'cmdAceptar
      '
      Me.cmdAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdAceptar.Location = New System.Drawing.Point(330, 411)
      Me.cmdAceptar.Name = "cmdAceptar"
      Me.cmdAceptar.Size = New System.Drawing.Size(75, 23)
      Me.cmdAceptar.TabIndex = 22
      Me.cmdAceptar.Text = "&Guardar"
      Me.cmdAceptar.UseVisualStyleBackColor = True
      '
      'cmdCancelar
      '
      Me.cmdCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.cmdCancelar.Location = New System.Drawing.Point(411, 411)
      Me.cmdCancelar.Name = "cmdCancelar"
      Me.cmdCancelar.Size = New System.Drawing.Size(75, 23)
      Me.cmdCancelar.TabIndex = 23
      Me.cmdCancelar.Text = "&Cancelar"
      Me.cmdCancelar.UseVisualStyleBackColor = True
      '
      'frmProveedoresAM
      '
      Me.AcceptButton = Me.cmdAceptar
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me.cmdCancelar
      Me.ClientSize = New System.Drawing.Size(504, 446)
      Me.Controls.Add(Me.cmdAceptar)
      Me.Controls.Add(Me.cmdCancelar)
      Me.Controls.Add(Me.Label14)
      Me.Controls.Add(Me.cboCondVenta)
      Me.Controls.Add(Me.Label13)
      Me.Controls.Add(Me.cboCtaCont)
      Me.Controls.Add(Me.tbCuit)
      Me.Controls.Add(Me.Label10)
      Me.Controls.Add(Me.Label11)
      Me.Controls.Add(Me.cboTipoIva)
      Me.Controls.Add(Me.Label9)
      Me.Controls.Add(Me.tbEMail)
      Me.Controls.Add(Me.Label8)
      Me.Controls.Add(Me.tbFax)
      Me.Controls.Add(Me.Label7)
      Me.Controls.Add(Me.tbTelefono)
      Me.Controls.Add(Me.Label6)
      Me.Controls.Add(Me.tbContacto)
      Me.Controls.Add(Me.Label5)
      Me.Controls.Add(Me.txtCodPostal)
      Me.Controls.Add(Me.Label4)
      Me.Controls.Add(Me.cboProvincia)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.cboLocalidad)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.tbDomicilio)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.tbNombre)
      Me.Controls.Add(Me.lblEfectivo)
      Me.Controls.Add(Me.tbCodigo)
      Me.KeyPreview = True
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "frmProveedoresAM"
      Me.Text = "Proveedores"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblEfectivo As System.Windows.Forms.Label
   Friend WithEvents tbCodigo As System.Windows.Forms.TextBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents tbNombre As System.Windows.Forms.TextBox
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents tbDomicilio As System.Windows.Forms.TextBox
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents cboLocalidad As System.Windows.Forms.ComboBox
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents cboProvincia As System.Windows.Forms.ComboBox
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents txtCodPostal As System.Windows.Forms.TextBox
   Friend WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents tbContacto As System.Windows.Forms.TextBox
   Friend WithEvents Label7 As System.Windows.Forms.Label
   Friend WithEvents tbTelefono As System.Windows.Forms.TextBox
   Friend WithEvents Label8 As System.Windows.Forms.Label
   Friend WithEvents tbFax As System.Windows.Forms.TextBox
   Friend WithEvents Label9 As System.Windows.Forms.Label
   Friend WithEvents tbEMail As System.Windows.Forms.TextBox
   Friend WithEvents tbCuit As System.Windows.Forms.MaskedTextBox
   Friend WithEvents Label10 As System.Windows.Forms.Label
   Friend WithEvents Label11 As System.Windows.Forms.Label
   Friend WithEvents cboTipoIva As System.Windows.Forms.ComboBox
   Friend WithEvents Label13 As System.Windows.Forms.Label
   Friend WithEvents cboCtaCont As System.Windows.Forms.ComboBox
   Friend WithEvents Label14 As System.Windows.Forms.Label
   Friend WithEvents cboCondVenta As System.Windows.Forms.ComboBox
   Friend WithEvents cmdAceptar As System.Windows.Forms.Button
   Friend WithEvents cmdCancelar As System.Windows.Forms.Button
End Class
