<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPropiedadesAM
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
        Me.Label11 = New System.Windows.Forms.Label()
        Me.optInactivo = New System.Windows.Forms.RadioButton()
        Me.optActivo = New System.Windows.Forms.RadioButton()
        Me.chkComProp = New System.Windows.Forms.CheckBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tbComision = New System.Windows.Forms.TextBox()
        Me.cbTipo = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cbPropietario = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tbNomCat = New System.Windows.Forms.MaskedTextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbBarrio = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.optComercial = New System.Windows.Forms.RadioButton()
        Me.optParticular = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbValorAlq = New System.Windows.Forms.TextBox()
        Me.btPriLib = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tbDescrip = New System.Windows.Forms.TextBox()
        Me.btCodSig = New System.Windows.Forms.Button()
        Me.cbLocalidad = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbDomicilio = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.tbCodigo = New System.Windows.Forms.TextBox()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.cmdAceptar = New System.Windows.Forms.Button()
        Me.lblComPorcImp = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblComPorcImp)
        Me.GroupBox1.Controls.Add(Me.chkComProp)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.tbComision)
        Me.GroupBox1.Controls.Add(Me.cbTipo)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.cbPropietario)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.tbNomCat)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.cbBarrio)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.optComercial)
        Me.GroupBox1.Controls.Add(Me.optParticular)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.tbValorAlq)
        Me.GroupBox1.Controls.Add(Me.btPriLib)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.tbDescrip)
        Me.GroupBox1.Controls.Add(Me.btCodSig)
        Me.GroupBox1.Controls.Add(Me.cbLocalidad)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.tbDomicilio)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.tbCodigo)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(671, 482)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(85, 507)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(43, 13)
        Me.Label11.TabIndex = 127
        Me.Label11.Text = "Estado:"
        '
        'optInactivo
        '
        Me.optInactivo.AutoSize = True
        Me.optInactivo.Location = New System.Drawing.Point(216, 505)
        Me.optInactivo.Name = "optInactivo"
        Me.optInactivo.Size = New System.Drawing.Size(63, 17)
        Me.optInactivo.TabIndex = 126
        Me.optInactivo.Text = "&Inactivo"
        Me.optInactivo.UseVisualStyleBackColor = True
        '
        'optActivo
        '
        Me.optActivo.AutoSize = True
        Me.optActivo.Checked = True
        Me.optActivo.Location = New System.Drawing.Point(134, 505)
        Me.optActivo.Name = "optActivo"
        Me.optActivo.Size = New System.Drawing.Size(55, 17)
        Me.optActivo.TabIndex = 125
        Me.optActivo.TabStop = True
        Me.optActivo.Text = "&Activo"
        Me.optActivo.UseVisualStyleBackColor = True
        '
        'chkComProp
        '
        Me.chkComProp.AutoSize = True
        Me.chkComProp.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkComProp.Location = New System.Drawing.Point(423, 194)
        Me.chkComProp.Name = "chkComProp"
        Me.chkComProp.Size = New System.Drawing.Size(133, 17)
        Me.chkComProp.TabIndex = 9
        Me.chkComProp.Text = "Heredar del propietario"
        Me.chkComProp.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(259, 195)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(49, 13)
        Me.Label10.TabIndex = 121
        Me.Label10.Text = "Comisión"
        '
        'tbComision
        '
        Me.tbComision.Enabled = False
        Me.tbComision.Location = New System.Drawing.Point(329, 192)
        Me.tbComision.MaxLength = 3
        Me.tbComision.Name = "tbComision"
        Me.tbComision.Size = New System.Drawing.Size(67, 20)
        Me.tbComision.TabIndex = 8
        Me.tbComision.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cbTipo
        '
        Me.cbTipo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbTipo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTipo.FormattingEnabled = True
        Me.cbTipo.Location = New System.Drawing.Point(123, 223)
        Me.cbTipo.Name = "cbTipo"
        Me.cbTipo.Size = New System.Drawing.Size(273, 21)
        Me.cbTipo.TabIndex = 10
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(20, 226)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(97, 13)
        Me.Label9.TabIndex = 119
        Me.Label9.Text = "Tipo de Propiedad:"
        '
        'cbPropietario
        '
        Me.cbPropietario.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbPropietario.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbPropietario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPropietario.Enabled = False
        Me.cbPropietario.FormattingEnabled = True
        Me.cbPropietario.Location = New System.Drawing.Point(123, 451)
        Me.cbPropietario.Name = "cbPropietario"
        Me.cbPropietario.Size = New System.Drawing.Size(433, 21)
        Me.cbPropietario.TabIndex = 14
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(57, 454)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 13)
        Me.Label7.TabIndex = 117
        Me.Label7.Text = "Propietario:"
        '
        'tbNomCat
        '
        Me.tbNomCat.Location = New System.Drawing.Point(123, 166)
        Me.tbNomCat.Mask = "00-00-000-0000-0000"
        Me.tbNomCat.Name = "tbNomCat"
        Me.tbNomCat.Size = New System.Drawing.Size(122, 20)
        Me.tbNomCat.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(18, 169)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(99, 13)
        Me.Label6.TabIndex = 114
        Me.Label6.Text = "Nomencl. Catastral:"
        '
        'cbBarrio
        '
        Me.cbBarrio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbBarrio.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbBarrio.FormattingEnabled = True
        Me.cbBarrio.Location = New System.Drawing.Point(123, 133)
        Me.cbBarrio.Name = "cbBarrio"
        Me.cbBarrio.Size = New System.Drawing.Size(433, 21)
        Me.cbBarrio.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(79, 136)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 13)
        Me.Label5.TabIndex = 112
        Me.Label5.Text = "Barrio:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(87, 260)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 13)
        Me.Label2.TabIndex = 110
        Me.Label2.Text = "Uso:"
        '
        'optComercial
        '
        Me.optComercial.AutoSize = True
        Me.optComercial.Location = New System.Drawing.Point(205, 258)
        Me.optComercial.Name = "optComercial"
        Me.optComercial.Size = New System.Drawing.Size(71, 17)
        Me.optComercial.TabIndex = 12
        Me.optComercial.Text = "&Comercial"
        Me.optComercial.UseVisualStyleBackColor = True
        '
        'optParticular
        '
        Me.optParticular.AutoSize = True
        Me.optParticular.Checked = True
        Me.optParticular.Location = New System.Drawing.Point(123, 258)
        Me.optParticular.Name = "optParticular"
        Me.optParticular.Size = New System.Drawing.Size(69, 17)
        Me.optParticular.TabIndex = 11
        Me.optParticular.TabStop = True
        Me.optParticular.Text = "&Particular"
        Me.optParticular.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(39, 195)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 13)
        Me.Label1.TabIndex = 107
        Me.Label1.Text = "Valor Alquiler $"
        '
        'tbValorAlq
        '
        Me.tbValorAlq.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbValorAlq.Location = New System.Drawing.Point(123, 192)
        Me.tbValorAlq.MaxLength = 10
        Me.tbValorAlq.Name = "tbValorAlq"
        Me.tbValorAlq.Size = New System.Drawing.Size(95, 20)
        Me.tbValorAlq.TabIndex = 7
        Me.tbValorAlq.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btPriLib
        '
        Me.btPriLib.AutoEllipsis = True
        Me.btPriLib.Location = New System.Drawing.Point(205, 26)
        Me.btPriLib.Name = "btPriLib"
        Me.btPriLib.Size = New System.Drawing.Size(30, 23)
        Me.btPriLib.TabIndex = 1
        Me.btPriLib.Text = "Primero Libre"
        Me.btPriLib.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(50, 299)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(66, 13)
        Me.Label8.TabIndex = 104
        Me.Label8.Text = "Descripción:"
        '
        'tbDescrip
        '
        Me.tbDescrip.Location = New System.Drawing.Point(123, 281)
        Me.tbDescrip.Multiline = True
        Me.tbDescrip.Name = "tbDescrip"
        Me.tbDescrip.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tbDescrip.Size = New System.Drawing.Size(542, 164)
        Me.tbDescrip.TabIndex = 13
        '
        'btCodSig
        '
        Me.btCodSig.AutoEllipsis = True
        Me.btCodSig.Location = New System.Drawing.Point(241, 26)
        Me.btCodSig.Name = "btCodSig"
        Me.btCodSig.Size = New System.Drawing.Size(30, 23)
        Me.btCodSig.TabIndex = 2
        Me.btCodSig.Text = "Código siguiente"
        Me.btCodSig.UseVisualStyleBackColor = True
        '
        'cbLocalidad
        '
        Me.cbLocalidad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbLocalidad.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbLocalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbLocalidad.FormattingEnabled = True
        Me.cbLocalidad.Location = New System.Drawing.Point(123, 99)
        Me.cbLocalidad.Name = "cbLocalidad"
        Me.cbLocalidad.Size = New System.Drawing.Size(433, 21)
        Me.cbLocalidad.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(60, 102)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 13)
        Me.Label4.TabIndex = 92
        Me.Label4.Text = "Localidad:"
        '
        'tbDomicilio
        '
        Me.tbDomicilio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbDomicilio.Location = New System.Drawing.Point(123, 69)
        Me.tbDomicilio.MaxLength = 50
        Me.tbDomicilio.Name = "tbDomicilio"
        Me.tbDomicilio.Size = New System.Drawing.Size(542, 20)
        Me.tbDomicilio.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(64, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 90
        Me.Label3.Text = "Domicilio:"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(62, 31)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(55, 13)
        Me.Label18.TabIndex = 78
        Me.Label18.Text = "Código Nº"
        '
        'tbCodigo
        '
        Me.tbCodigo.Enabled = False
        Me.tbCodigo.Location = New System.Drawing.Point(123, 28)
        Me.tbCodigo.MaxLength = 10
        Me.tbCodigo.Name = "tbCodigo"
        Me.tbCodigo.Size = New System.Drawing.Size(76, 20)
        Me.tbCodigo.TabIndex = 0
        Me.tbCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Location = New System.Drawing.Point(621, 519)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(62, 27)
        Me.cmdCancelar.TabIndex = 21
        Me.cmdCancelar.Text = "&Cancelar"
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Location = New System.Drawing.Point(538, 519)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(77, 27)
        Me.cmdAceptar.TabIndex = 20
        Me.cmdAceptar.Text = "&Aceptar"
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'lblComPorcImp
        '
        Me.lblComPorcImp.AutoSize = True
        Me.lblComPorcImp.Location = New System.Drawing.Point(305, 195)
        Me.lblComPorcImp.Name = "lblComPorcImp"
        Me.lblComPorcImp.Size = New System.Drawing.Size(15, 13)
        Me.lblComPorcImp.TabIndex = 128
        Me.lblComPorcImp.Text = "%"
        '
        'frmPropiedadesAM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(695, 558)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.optInactivo)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Controls.Add(Me.optActivo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPropiedadesAM"
        Me.Text = "Propiedades"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents Label18 As System.Windows.Forms.Label
   Friend WithEvents tbCodigo As System.Windows.Forms.TextBox
   Friend WithEvents tbDomicilio As System.Windows.Forms.TextBox
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents btCodSig As System.Windows.Forms.Button
   Friend WithEvents cbLocalidad As System.Windows.Forms.ComboBox
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents Label8 As System.Windows.Forms.Label
   Friend WithEvents tbDescrip As System.Windows.Forms.TextBox
   Friend WithEvents cmdCancelar As System.Windows.Forms.Button
   Friend WithEvents cmdAceptar As System.Windows.Forms.Button
   Friend WithEvents btPriLib As System.Windows.Forms.Button
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents tbValorAlq As System.Windows.Forms.TextBox
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents optComercial As System.Windows.Forms.RadioButton
   Friend WithEvents optParticular As System.Windows.Forms.RadioButton
   Friend WithEvents cbBarrio As System.Windows.Forms.ComboBox
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents tbNomCat As System.Windows.Forms.MaskedTextBox
   Friend WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents cbPropietario As System.Windows.Forms.ComboBox
   Friend WithEvents Label7 As System.Windows.Forms.Label
   Friend WithEvents cbTipo As System.Windows.Forms.ComboBox
   Friend WithEvents Label9 As System.Windows.Forms.Label
   Friend WithEvents Label10 As System.Windows.Forms.Label
   Friend WithEvents tbComision As System.Windows.Forms.TextBox
    Friend WithEvents chkComProp As CheckBox
    Friend WithEvents Label11 As Label
    Friend WithEvents optInactivo As RadioButton
    Friend WithEvents optActivo As RadioButton
    Friend WithEvents lblComPorcImp As Label
End Class
