<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGarantesAM
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
      Me.GroupBox1 = New System.Windows.Forms.GroupBox()
      Me.cbLocalidad = New System.Windows.Forms.ComboBox()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.tbDomicilio = New System.Windows.Forms.TextBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.tbTelefono = New System.Windows.Forms.TextBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.tbDni = New System.Windows.Forms.TextBox()
      Me.lblDNI = New System.Windows.Forms.Label()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.tbNombre = New System.Windows.Forms.TextBox()
      Me.GroupBox2 = New System.Windows.Forms.GroupBox()
      Me.tbTelTrabajo = New System.Windows.Forms.TextBox()
      Me.Label9 = New System.Windows.Forms.Label()
      Me.tbDomTrabajo = New System.Windows.Forms.TextBox()
      Me.Label14 = New System.Windows.Forms.Label()
      Me.Label17 = New System.Windows.Forms.Label()
      Me.tbTrabajo = New System.Windows.Forms.TextBox()
      Me.GroupBox3 = New System.Windows.Forms.GroupBox()
      Me.optPrenda = New System.Windows.Forms.RadioButton()
      Me.optHipotecaria = New System.Windows.Forms.RadioButton()
      Me.optPagare = New System.Windows.Forms.RadioButton()
      Me.cmdCancelar = New System.Windows.Forms.Button()
      Me.cmdAceptar = New System.Windows.Forms.Button()
      Me.GroupBox1.SuspendLayout()
      Me.GroupBox2.SuspendLayout()
      Me.GroupBox3.SuspendLayout()
      Me.SuspendLayout()
      '
      'GroupBox1
      '
      Me.GroupBox1.Controls.Add(Me.cbLocalidad)
      Me.GroupBox1.Controls.Add(Me.Label4)
      Me.GroupBox1.Controls.Add(Me.tbDomicilio)
      Me.GroupBox1.Controls.Add(Me.Label3)
      Me.GroupBox1.Controls.Add(Me.tbTelefono)
      Me.GroupBox1.Controls.Add(Me.Label2)
      Me.GroupBox1.Controls.Add(Me.tbDni)
      Me.GroupBox1.Controls.Add(Me.lblDNI)
      Me.GroupBox1.Controls.Add(Me.Label1)
      Me.GroupBox1.Controls.Add(Me.tbNombre)
      Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
      Me.GroupBox1.Name = "GroupBox1"
      Me.GroupBox1.Size = New System.Drawing.Size(536, 186)
      Me.GroupBox1.TabIndex = 0
      Me.GroupBox1.TabStop = False
      Me.GroupBox1.Text = "Datos Personales"
      '
      'cbLocalidad
      '
      Me.cbLocalidad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      Me.cbLocalidad.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.cbLocalidad.FormattingEnabled = True
      Me.cbLocalidad.Location = New System.Drawing.Point(80, 134)
      Me.cbLocalidad.Name = "cbLocalidad"
      Me.cbLocalidad.Size = New System.Drawing.Size(433, 21)
      Me.cbLocalidad.TabIndex = 4
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(18, 137)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(56, 13)
      Me.Label4.TabIndex = 92
      Me.Label4.Text = "Localidad:"
      '
      'tbDomicilio
      '
      Me.tbDomicilio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.tbDomicilio.Location = New System.Drawing.Point(80, 108)
      Me.tbDomicilio.MaxLength = 50
      Me.tbDomicilio.Name = "tbDomicilio"
      Me.tbDomicilio.Size = New System.Drawing.Size(433, 20)
      Me.tbDomicilio.TabIndex = 3
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(18, 111)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(52, 13)
      Me.Label3.TabIndex = 90
      Me.Label3.Text = "Domicilio:"
      '
      'tbTelefono
      '
      Me.tbTelefono.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.tbTelefono.Location = New System.Drawing.Point(80, 80)
      Me.tbTelefono.MaxLength = 25
      Me.tbTelefono.Name = "tbTelefono"
      Me.tbTelefono.Size = New System.Drawing.Size(229, 20)
      Me.tbTelefono.TabIndex = 2
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(12, 83)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(62, 13)
      Me.Label2.TabIndex = 88
      Me.Label2.Text = "Teléfono/s:"
      '
      'tbDni
      '
      Me.tbDni.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.tbDni.Location = New System.Drawing.Point(80, 51)
      Me.tbDni.MaxLength = 10
      Me.tbDni.Name = "tbDni"
      Me.tbDni.Size = New System.Drawing.Size(95, 20)
      Me.tbDni.TabIndex = 1
      Me.tbDni.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblDNI
      '
      Me.lblDNI.AutoSize = True
      Me.lblDNI.Location = New System.Drawing.Point(39, 54)
      Me.lblDNI.Name = "lblDNI"
      Me.lblDNI.Size = New System.Drawing.Size(35, 13)
      Me.lblDNI.TabIndex = 86
      Me.lblDNI.Text = "D.N.I."
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(27, 25)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(47, 13)
      Me.Label1.TabIndex = 80
      Me.Label1.Text = "Nombre:"
      '
      'tbNombre
      '
      Me.tbNombre.Location = New System.Drawing.Point(80, 22)
      Me.tbNombre.MaxLength = 100
      Me.tbNombre.Name = "tbNombre"
      Me.tbNombre.Size = New System.Drawing.Size(433, 20)
      Me.tbNombre.TabIndex = 0
      '
      'GroupBox2
      '
      Me.GroupBox2.Controls.Add(Me.tbTelTrabajo)
      Me.GroupBox2.Controls.Add(Me.Label9)
      Me.GroupBox2.Controls.Add(Me.tbDomTrabajo)
      Me.GroupBox2.Controls.Add(Me.Label14)
      Me.GroupBox2.Controls.Add(Me.Label17)
      Me.GroupBox2.Controls.Add(Me.tbTrabajo)
      Me.GroupBox2.Location = New System.Drawing.Point(12, 204)
      Me.GroupBox2.Name = "GroupBox2"
      Me.GroupBox2.Size = New System.Drawing.Size(536, 114)
      Me.GroupBox2.TabIndex = 1
      Me.GroupBox2.TabStop = False
      Me.GroupBox2.Text = "Datos Laborales"
      '
      'tbTelTrabajo
      '
      Me.tbTelTrabajo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.tbTelTrabajo.Location = New System.Drawing.Point(96, 77)
      Me.tbTelTrabajo.MaxLength = 25
      Me.tbTelTrabajo.Name = "tbTelTrabajo"
      Me.tbTelTrabajo.Size = New System.Drawing.Size(234, 20)
      Me.tbTelTrabajo.TabIndex = 7
      '
      'Label9
      '
      Me.Label9.AutoSize = True
      Me.Label9.Location = New System.Drawing.Point(18, 80)
      Me.Label9.Name = "Label9"
      Me.Label9.Size = New System.Drawing.Size(62, 13)
      Me.Label9.TabIndex = 92
      Me.Label9.Text = "Teléfono/s:"
      '
      'tbDomTrabajo
      '
      Me.tbDomTrabajo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.tbDomTrabajo.Location = New System.Drawing.Point(96, 51)
      Me.tbDomTrabajo.MaxLength = 50
      Me.tbDomTrabajo.Name = "tbDomTrabajo"
      Me.tbDomTrabajo.Size = New System.Drawing.Size(417, 20)
      Me.tbDomTrabajo.TabIndex = 6
      '
      'Label14
      '
      Me.Label14.AutoSize = True
      Me.Label14.Location = New System.Drawing.Point(18, 54)
      Me.Label14.Name = "Label14"
      Me.Label14.Size = New System.Drawing.Size(52, 13)
      Me.Label14.TabIndex = 90
      Me.Label14.Text = "Domicilio:"
      '
      'Label17
      '
      Me.Label17.AutoSize = True
      Me.Label17.Location = New System.Drawing.Point(18, 28)
      Me.Label17.Name = "Label17"
      Me.Label17.Size = New System.Drawing.Size(72, 13)
      Me.Label17.TabIndex = 80
      Me.Label17.Text = "Organización:"
      '
      'tbTrabajo
      '
      Me.tbTrabajo.Location = New System.Drawing.Point(96, 25)
      Me.tbTrabajo.MaxLength = 50
      Me.tbTrabajo.Name = "tbTrabajo"
      Me.tbTrabajo.Size = New System.Drawing.Size(417, 20)
      Me.tbTrabajo.TabIndex = 5
      '
      'GroupBox3
      '
      Me.GroupBox3.Controls.Add(Me.optPrenda)
      Me.GroupBox3.Controls.Add(Me.optHipotecaria)
      Me.GroupBox3.Controls.Add(Me.optPagare)
      Me.GroupBox3.Location = New System.Drawing.Point(12, 324)
      Me.GroupBox3.Name = "GroupBox3"
      Me.GroupBox3.Size = New System.Drawing.Size(536, 77)
      Me.GroupBox3.TabIndex = 2
      Me.GroupBox3.TabStop = False
      Me.GroupBox3.Text = "Garantía"
      '
      'optPrenda
      '
      Me.optPrenda.AutoSize = True
      Me.optPrenda.Location = New System.Drawing.Point(246, 29)
      Me.optPrenda.Name = "optPrenda"
      Me.optPrenda.Size = New System.Drawing.Size(59, 17)
      Me.optPrenda.TabIndex = 10
      Me.optPrenda.Text = "&Prenda"
      Me.optPrenda.UseVisualStyleBackColor = True
      '
      'optHipotecaria
      '
      Me.optHipotecaria.AutoSize = True
      Me.optHipotecaria.Location = New System.Drawing.Point(161, 29)
      Me.optHipotecaria.Name = "optHipotecaria"
      Me.optHipotecaria.Size = New System.Drawing.Size(79, 17)
      Me.optHipotecaria.TabIndex = 9
      Me.optHipotecaria.Text = "&Hipotecaria"
      Me.optHipotecaria.UseVisualStyleBackColor = True
      '
      'optPagare
      '
      Me.optPagare.AutoSize = True
      Me.optPagare.Checked = True
      Me.optPagare.Location = New System.Drawing.Point(96, 29)
      Me.optPagare.Name = "optPagare"
      Me.optPagare.Size = New System.Drawing.Size(59, 17)
      Me.optPagare.TabIndex = 8
      Me.optPagare.TabStop = True
      Me.optPagare.Text = "&Pagaré"
      Me.optPagare.UseVisualStyleBackColor = True
      '
      'cmdCancelar
      '
      Me.cmdCancelar.Location = New System.Drawing.Point(486, 407)
      Me.cmdCancelar.Name = "cmdCancelar"
      Me.cmdCancelar.Size = New System.Drawing.Size(62, 27)
      Me.cmdCancelar.TabIndex = 21
      Me.cmdCancelar.Text = "&Cancelar"
      Me.cmdCancelar.UseVisualStyleBackColor = True
      '
      'cmdAceptar
      '
      Me.cmdAceptar.Location = New System.Drawing.Point(403, 407)
      Me.cmdAceptar.Name = "cmdAceptar"
      Me.cmdAceptar.Size = New System.Drawing.Size(77, 27)
      Me.cmdAceptar.TabIndex = 20
      Me.cmdAceptar.Text = "&Aceptar"
      Me.cmdAceptar.UseVisualStyleBackColor = True
      '
      'frmGarantesAM
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(557, 443)
      Me.Controls.Add(Me.cmdCancelar)
      Me.Controls.Add(Me.cmdAceptar)
      Me.Controls.Add(Me.GroupBox3)
      Me.Controls.Add(Me.GroupBox2)
      Me.Controls.Add(Me.GroupBox1)
      Me.KeyPreview = True
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "frmGarantesAM"
      Me.Text = "Garantes"
      Me.GroupBox1.ResumeLayout(False)
      Me.GroupBox1.PerformLayout()
      Me.GroupBox2.ResumeLayout(False)
      Me.GroupBox2.PerformLayout()
      Me.GroupBox3.ResumeLayout(False)
      Me.GroupBox3.PerformLayout()
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents tbNombre As System.Windows.Forms.TextBox
   Friend WithEvents tbDni As System.Windows.Forms.TextBox
   Friend WithEvents lblDNI As System.Windows.Forms.Label
   Friend WithEvents tbDomicilio As System.Windows.Forms.TextBox
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents tbTelefono As System.Windows.Forms.TextBox
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents cbLocalidad As System.Windows.Forms.ComboBox
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
   Friend WithEvents tbTelTrabajo As System.Windows.Forms.TextBox
   Friend WithEvents Label9 As System.Windows.Forms.Label
   Friend WithEvents tbDomTrabajo As System.Windows.Forms.TextBox
   Friend WithEvents Label14 As System.Windows.Forms.Label
   Friend WithEvents Label17 As System.Windows.Forms.Label
   Friend WithEvents tbTrabajo As System.Windows.Forms.TextBox
   Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
   Friend WithEvents optHipotecaria As System.Windows.Forms.RadioButton
   Friend WithEvents optPagare As System.Windows.Forms.RadioButton
   Friend WithEvents cmdCancelar As System.Windows.Forms.Button
   Friend WithEvents cmdAceptar As System.Windows.Forms.Button
   Friend WithEvents optPrenda As System.Windows.Forms.RadioButton
End Class
