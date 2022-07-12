<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInquilinosAM
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
      Me.tbEMail = New System.Windows.Forms.TextBox()
      Me.Label10 = New System.Windows.Forms.Label()
      Me.btPriLib = New System.Windows.Forms.Button()
      Me.tbCtaCont = New System.Windows.Forms.TextBox()
      Me.btCtaCont = New System.Windows.Forms.Button()
      Me.Label8 = New System.Windows.Forms.Label()
      Me.tbObserv = New System.Windows.Forms.TextBox()
      Me.tbCuit = New System.Windows.Forms.MaskedTextBox()
      Me.cbCtaCont = New System.Windows.Forms.ComboBox()
      Me.Label7 = New System.Windows.Forms.Label()
      Me.chkAgRetGan = New System.Windows.Forms.CheckBox()
      Me.btCodSig = New System.Windows.Forms.Button()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.cbTipoIva = New System.Windows.Forms.ComboBox()
      Me.Label5 = New System.Windows.Forms.Label()
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
      Me.Label18 = New System.Windows.Forms.Label()
      Me.tbCodigo = New System.Windows.Forms.TextBox()
      Me.GroupBox2 = New System.Windows.Forms.GroupBox()
      Me.tbTelTrabajo = New System.Windows.Forms.TextBox()
      Me.Label9 = New System.Windows.Forms.Label()
      Me.tbDomTrabajo = New System.Windows.Forms.TextBox()
      Me.Label14 = New System.Windows.Forms.Label()
      Me.Label17 = New System.Windows.Forms.Label()
      Me.tbTrabajo = New System.Windows.Forms.TextBox()
      Me.GroupBox3 = New System.Windows.Forms.GroupBox()
      Me.tbDescEstado = New System.Windows.Forms.TextBox()
      Me.rbInactivo = New System.Windows.Forms.RadioButton()
      Me.rbActivo = New System.Windows.Forms.RadioButton()
      Me.chkDocPend = New System.Windows.Forms.CheckBox()
      Me.Label12 = New System.Windows.Forms.Label()
      Me.cmdCancelar = New System.Windows.Forms.Button()
      Me.cmdAceptar = New System.Windows.Forms.Button()
      Me.GroupBox1.SuspendLayout()
      Me.GroupBox2.SuspendLayout()
      Me.GroupBox3.SuspendLayout()
      Me.SuspendLayout()
      '
      'GroupBox1
      '
      Me.GroupBox1.Controls.Add(Me.tbEMail)
      Me.GroupBox1.Controls.Add(Me.Label10)
      Me.GroupBox1.Controls.Add(Me.btPriLib)
      Me.GroupBox1.Controls.Add(Me.tbCtaCont)
      Me.GroupBox1.Controls.Add(Me.btCtaCont)
      Me.GroupBox1.Controls.Add(Me.Label8)
      Me.GroupBox1.Controls.Add(Me.tbObserv)
      Me.GroupBox1.Controls.Add(Me.tbCuit)
      Me.GroupBox1.Controls.Add(Me.cbCtaCont)
      Me.GroupBox1.Controls.Add(Me.Label7)
      Me.GroupBox1.Controls.Add(Me.chkAgRetGan)
      Me.GroupBox1.Controls.Add(Me.btCodSig)
      Me.GroupBox1.Controls.Add(Me.Label6)
      Me.GroupBox1.Controls.Add(Me.cbTipoIva)
      Me.GroupBox1.Controls.Add(Me.Label5)
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
      Me.GroupBox1.Controls.Add(Me.Label18)
      Me.GroupBox1.Controls.Add(Me.tbCodigo)
      Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
      Me.GroupBox1.Name = "GroupBox1"
      Me.GroupBox1.Size = New System.Drawing.Size(759, 311)
      Me.GroupBox1.TabIndex = 0
      Me.GroupBox1.TabStop = False
      Me.GroupBox1.Text = "Datos Personales"
      '
      'tbEMail
      '
      Me.tbEMail.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.tbEMail.Location = New System.Drawing.Point(80, 285)
      Me.tbEMail.MaxLength = 50
      Me.tbEMail.Name = "tbEMail"
      Me.tbEMail.Size = New System.Drawing.Size(393, 20)
      Me.tbEMail.TabIndex = 13
      '
      'Label10
      '
      Me.Label10.AutoSize = True
      Me.Label10.Location = New System.Drawing.Point(35, 288)
      Me.Label10.Name = "Label10"
      Me.Label10.Size = New System.Drawing.Size(39, 13)
      Me.Label10.TabIndex = 120
      Me.Label10.Text = "E-Mail:"
      '
      'btPriLib
      '
      Me.btPriLib.AutoEllipsis = True
      Me.btPriLib.Location = New System.Drawing.Point(189, 23)
      Me.btPriLib.Name = "btPriLib"
      Me.btPriLib.Size = New System.Drawing.Size(30, 23)
      Me.btPriLib.TabIndex = 105
      Me.btPriLib.Text = "Primero Libre"
      Me.btPriLib.UseVisualStyleBackColor = True
      '
      'tbCtaCont
      '
      Me.tbCtaCont.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.tbCtaCont.Location = New System.Drawing.Point(519, 157)
      Me.tbCtaCont.MaxLength = 10
      Me.tbCtaCont.Name = "tbCtaCont"
      Me.tbCtaCont.Size = New System.Drawing.Size(95, 20)
      Me.tbCtaCont.TabIndex = 10
      '
      'btCtaCont
      '
      Me.btCtaCont.Location = New System.Drawing.Point(621, 155)
      Me.btCtaCont.Name = "btCtaCont"
      Me.btCtaCont.Size = New System.Drawing.Size(30, 23)
      Me.btCtaCont.TabIndex = 11
      Me.btCtaCont.Text = "..."
      Me.btCtaCont.UseVisualStyleBackColor = True
      '
      'Label8
      '
      Me.Label8.AutoSize = True
      Me.Label8.Location = New System.Drawing.Point(18, 188)
      Me.Label8.Name = "Label8"
      Me.Label8.Size = New System.Drawing.Size(81, 13)
      Me.Label8.TabIndex = 104
      Me.Label8.Text = "Observaciones:"
      '
      'tbObserv
      '
      Me.tbObserv.Location = New System.Drawing.Point(105, 185)
      Me.tbObserv.Multiline = True
      Me.tbObserv.Name = "tbObserv"
      Me.tbObserv.Size = New System.Drawing.Size(490, 83)
      Me.tbObserv.TabIndex = 12
      '
      'tbCuit
      '
      Me.tbCuit.Location = New System.Drawing.Point(413, 130)
      Me.tbCuit.Mask = "##-########-#"
      Me.tbCuit.Name = "tbCuit"
      Me.tbCuit.Size = New System.Drawing.Size(100, 20)
      Me.tbCuit.TabIndex = 7
      '
      'cbCtaCont
      '
      Me.cbCtaCont.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      Me.cbCtaCont.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.cbCtaCont.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbCtaCont.FormattingEnabled = True
      Me.cbCtaCont.Location = New System.Drawing.Point(96, 156)
      Me.cbCtaCont.Name = "cbCtaCont"
      Me.cbCtaCont.Size = New System.Drawing.Size(417, 21)
      Me.cbCtaCont.TabIndex = 9
      '
      'Label7
      '
      Me.Label7.AutoSize = True
      Me.Label7.Location = New System.Drawing.Point(18, 160)
      Me.Label7.Name = "Label7"
      Me.Label7.Size = New System.Drawing.Size(72, 13)
      Me.Label7.TabIndex = 100
      Me.Label7.Text = "Cuenta Cont.:"
      '
      'chkAgRetGan
      '
      Me.chkAgRetGan.AutoSize = True
      Me.chkAgRetGan.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.chkAgRetGan.Location = New System.Drawing.Point(532, 132)
      Me.chkAgRetGan.Name = "chkAgRetGan"
      Me.chkAgRetGan.Size = New System.Drawing.Size(119, 17)
      Me.chkAgRetGan.TabIndex = 8
      Me.chkAgRetGan.Text = "A&g. Ret. Ganancias"
      Me.chkAgRetGan.UseVisualStyleBackColor = True
      '
      'btCodSig
      '
      Me.btCodSig.AutoEllipsis = True
      Me.btCodSig.Location = New System.Drawing.Point(154, 23)
      Me.btCodSig.Name = "btCodSig"
      Me.btCodSig.Size = New System.Drawing.Size(30, 23)
      Me.btCodSig.TabIndex = 1
      Me.btCodSig.Text = "Código siguiente"
      Me.btCodSig.UseVisualStyleBackColor = True
      '
      'Label6
      '
      Me.Label6.AutoSize = True
      Me.Label6.Location = New System.Drawing.Point(337, 133)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(70, 13)
      Me.Label6.TabIndex = 96
      Me.Label6.Text = "CUIT / CUIL:"
      '
      'cbTipoIva
      '
      Me.cbTipoIva.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbTipoIva.FormattingEnabled = True
      Me.cbTipoIva.Location = New System.Drawing.Point(80, 129)
      Me.cbTipoIva.Name = "cbTipoIva"
      Me.cbTipoIva.Size = New System.Drawing.Size(217, 21)
      Me.cbTipoIva.TabIndex = 6
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.Location = New System.Drawing.Point(18, 133)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(60, 13)
      Me.Label5.TabIndex = 94
      Me.Label5.Text = "Tipo I.V.A.:"
      '
      'cbLocalidad
      '
      Me.cbLocalidad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      Me.cbLocalidad.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.cbLocalidad.FormattingEnabled = True
      Me.cbLocalidad.Location = New System.Drawing.Point(80, 103)
      Me.cbLocalidad.Name = "cbLocalidad"
      Me.cbLocalidad.Size = New System.Drawing.Size(433, 21)
      Me.cbLocalidad.TabIndex = 5
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(18, 106)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(56, 13)
      Me.Label4.TabIndex = 92
      Me.Label4.Text = "Localidad:"
      '
      'tbDomicilio
      '
      Me.tbDomicilio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.tbDomicilio.Location = New System.Drawing.Point(80, 77)
      Me.tbDomicilio.MaxLength = 50
      Me.tbDomicilio.Name = "tbDomicilio"
      Me.tbDomicilio.Size = New System.Drawing.Size(433, 20)
      Me.tbDomicilio.TabIndex = 4
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(18, 80)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(52, 13)
      Me.Label3.TabIndex = 90
      Me.Label3.Text = "Domicilio:"
      '
      'tbTelefono
      '
      Me.tbTelefono.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.tbTelefono.Location = New System.Drawing.Point(250, 51)
      Me.tbTelefono.MaxLength = 25
      Me.tbTelefono.Name = "tbTelefono"
      Me.tbTelefono.Size = New System.Drawing.Size(489, 20)
      Me.tbTelefono.TabIndex = 3
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(181, 54)
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
      Me.tbDni.TabIndex = 2
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
      Me.Label1.Location = New System.Drawing.Point(225, 28)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(47, 13)
      Me.Label1.TabIndex = 80
      Me.Label1.Text = "Nombre:"
      '
      'tbNombre
      '
      Me.tbNombre.Location = New System.Drawing.Point(278, 25)
      Me.tbNombre.MaxLength = 100
      Me.tbNombre.Name = "tbNombre"
      Me.tbNombre.Size = New System.Drawing.Size(461, 20)
      Me.tbNombre.TabIndex = 1
      '
      'Label18
      '
      Me.Label18.AutoSize = True
      Me.Label18.Location = New System.Drawing.Point(18, 28)
      Me.Label18.Name = "Label18"
      Me.Label18.Size = New System.Drawing.Size(55, 13)
      Me.Label18.TabIndex = 78
      Me.Label18.Text = "Código Nº"
      '
      'tbCodigo
      '
      Me.tbCodigo.Enabled = False
      Me.tbCodigo.Location = New System.Drawing.Point(80, 25)
      Me.tbCodigo.MaxLength = 10
      Me.tbCodigo.Name = "tbCodigo"
      Me.tbCodigo.Size = New System.Drawing.Size(68, 20)
      Me.tbCodigo.TabIndex = 0
      Me.tbCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'GroupBox2
      '
      Me.GroupBox2.Controls.Add(Me.tbTelTrabajo)
      Me.GroupBox2.Controls.Add(Me.Label9)
      Me.GroupBox2.Controls.Add(Me.tbDomTrabajo)
      Me.GroupBox2.Controls.Add(Me.Label14)
      Me.GroupBox2.Controls.Add(Me.Label17)
      Me.GroupBox2.Controls.Add(Me.tbTrabajo)
      Me.GroupBox2.Location = New System.Drawing.Point(12, 329)
      Me.GroupBox2.Name = "GroupBox2"
      Me.GroupBox2.Size = New System.Drawing.Size(759, 114)
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
      Me.tbTelTrabajo.Size = New System.Drawing.Size(499, 20)
      Me.tbTelTrabajo.TabIndex = 15
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
      Me.tbDomTrabajo.Size = New System.Drawing.Size(499, 20)
      Me.tbDomTrabajo.TabIndex = 14
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
      Me.tbTrabajo.Size = New System.Drawing.Size(499, 20)
      Me.tbTrabajo.TabIndex = 13
      '
      'GroupBox3
      '
      Me.GroupBox3.Controls.Add(Me.tbDescEstado)
      Me.GroupBox3.Controls.Add(Me.rbInactivo)
      Me.GroupBox3.Controls.Add(Me.rbActivo)
      Me.GroupBox3.Controls.Add(Me.chkDocPend)
      Me.GroupBox3.Controls.Add(Me.Label12)
      Me.GroupBox3.Location = New System.Drawing.Point(12, 449)
      Me.GroupBox3.Name = "GroupBox3"
      Me.GroupBox3.Size = New System.Drawing.Size(608, 103)
      Me.GroupBox3.TabIndex = 2
      Me.GroupBox3.TabStop = False
      Me.GroupBox3.Text = "Estado"
      '
      'tbDescEstado
      '
      Me.tbDescEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.tbDescEstado.Location = New System.Drawing.Point(199, 26)
      Me.tbDescEstado.MaxLength = 50
      Me.tbDescEstado.Name = "tbDescEstado"
      Me.tbDescEstado.Size = New System.Drawing.Size(396, 20)
      Me.tbDescEstado.TabIndex = 18
      '
      'rbInactivo
      '
      Me.rbInactivo.AutoSize = True
      Me.rbInactivo.Location = New System.Drawing.Point(85, 29)
      Me.rbInactivo.Name = "rbInactivo"
      Me.rbInactivo.Size = New System.Drawing.Size(63, 17)
      Me.rbInactivo.TabIndex = 17
      Me.rbInactivo.Text = "&Inactivo"
      Me.rbInactivo.UseVisualStyleBackColor = True
      '
      'rbActivo
      '
      Me.rbActivo.AutoSize = True
      Me.rbActivo.Checked = True
      Me.rbActivo.Location = New System.Drawing.Point(23, 29)
      Me.rbActivo.Name = "rbActivo"
      Me.rbActivo.Size = New System.Drawing.Size(55, 17)
      Me.rbActivo.TabIndex = 16
      Me.rbActivo.TabStop = True
      Me.rbActivo.Text = "&Activo"
      Me.rbActivo.UseVisualStyleBackColor = True
      '
      'chkDocPend
      '
      Me.chkDocPend.AutoSize = True
      Me.chkDocPend.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.chkDocPend.Location = New System.Drawing.Point(21, 64)
      Me.chkDocPend.Name = "chkDocPend"
      Me.chkDocPend.Size = New System.Drawing.Size(152, 17)
      Me.chkDocPend.TabIndex = 19
      Me.chkDocPend.Text = "&Documentación Pendiente"
      Me.chkDocPend.UseVisualStyleBackColor = True
      '
      'Label12
      '
      Me.Label12.AutoSize = True
      Me.Label12.Location = New System.Drawing.Point(169, 31)
      Me.Label12.Name = "Label12"
      Me.Label12.Size = New System.Drawing.Size(30, 13)
      Me.Label12.TabIndex = 80
      Me.Label12.Text = "Det.:"
      '
      'cmdCancelar
      '
      Me.cmdCancelar.Location = New System.Drawing.Point(709, 502)
      Me.cmdCancelar.Name = "cmdCancelar"
      Me.cmdCancelar.Size = New System.Drawing.Size(62, 27)
      Me.cmdCancelar.TabIndex = 21
      Me.cmdCancelar.Text = "&Cancelar"
      Me.cmdCancelar.UseVisualStyleBackColor = True
      '
      'cmdAceptar
      '
      Me.cmdAceptar.Location = New System.Drawing.Point(626, 502)
      Me.cmdAceptar.Name = "cmdAceptar"
      Me.cmdAceptar.Size = New System.Drawing.Size(77, 27)
      Me.cmdAceptar.TabIndex = 20
      Me.cmdAceptar.Text = "&Aceptar"
      Me.cmdAceptar.UseVisualStyleBackColor = True
      '
      'frmInquilinosAM
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(783, 564)
      Me.Controls.Add(Me.cmdCancelar)
      Me.Controls.Add(Me.cmdAceptar)
      Me.Controls.Add(Me.GroupBox3)
      Me.Controls.Add(Me.GroupBox2)
      Me.Controls.Add(Me.GroupBox1)
      Me.KeyPreview = True
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "frmInquilinosAM"
      Me.Text = "Inquilinos"
      Me.GroupBox1.ResumeLayout(False)
      Me.GroupBox1.PerformLayout()
      Me.GroupBox2.ResumeLayout(False)
      Me.GroupBox2.PerformLayout()
      Me.GroupBox3.ResumeLayout(False)
      Me.GroupBox3.PerformLayout()
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents Label18 As System.Windows.Forms.Label
   Friend WithEvents tbCodigo As System.Windows.Forms.TextBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents tbNombre As System.Windows.Forms.TextBox
   Friend WithEvents tbDni As System.Windows.Forms.TextBox
   Friend WithEvents lblDNI As System.Windows.Forms.Label
   Friend WithEvents tbDomicilio As System.Windows.Forms.TextBox
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents tbTelefono As System.Windows.Forms.TextBox
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents btCodSig As System.Windows.Forms.Button
   Friend WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents cbTipoIva As System.Windows.Forms.ComboBox
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents cbLocalidad As System.Windows.Forms.ComboBox
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents cbCtaCont As System.Windows.Forms.ComboBox
   Friend WithEvents Label7 As System.Windows.Forms.Label
   Friend WithEvents chkAgRetGan As System.Windows.Forms.CheckBox
   Friend WithEvents tbCuit As System.Windows.Forms.MaskedTextBox
   Friend WithEvents Label8 As System.Windows.Forms.Label
   Friend WithEvents tbObserv As System.Windows.Forms.TextBox
   Friend WithEvents btCtaCont As System.Windows.Forms.Button
   Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
   Friend WithEvents tbTelTrabajo As System.Windows.Forms.TextBox
   Friend WithEvents Label9 As System.Windows.Forms.Label
   Friend WithEvents tbDomTrabajo As System.Windows.Forms.TextBox
   Friend WithEvents Label14 As System.Windows.Forms.Label
   Friend WithEvents Label17 As System.Windows.Forms.Label
   Friend WithEvents tbTrabajo As System.Windows.Forms.TextBox
   Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
   Friend WithEvents chkDocPend As System.Windows.Forms.CheckBox
   Friend WithEvents Label12 As System.Windows.Forms.Label
   Friend WithEvents rbInactivo As System.Windows.Forms.RadioButton
   Friend WithEvents rbActivo As System.Windows.Forms.RadioButton
   Friend WithEvents cmdCancelar As System.Windows.Forms.Button
   Friend WithEvents cmdAceptar As System.Windows.Forms.Button
   Friend WithEvents tbDescEstado As System.Windows.Forms.TextBox
   Friend WithEvents tbCtaCont As System.Windows.Forms.TextBox
   Friend WithEvents btPriLib As System.Windows.Forms.Button
   Friend WithEvents tbEMail As System.Windows.Forms.TextBox
   Friend WithEvents Label10 As System.Windows.Forms.Label
End Class
