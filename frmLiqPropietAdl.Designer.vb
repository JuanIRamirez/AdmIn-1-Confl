<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLiqPropietAdl
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
      Me.cbPropiedad = New System.Windows.Forms.ComboBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.cbDescConc = New System.Windows.Forms.ComboBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.cbPeriodo = New System.Windows.Forms.ComboBox()
      Me.cbConcepto = New System.Windows.Forms.ComboBox()
      Me.lblComision = New System.Windows.Forms.Label()
      Me.optNeto = New System.Windows.Forms.RadioButton()
      Me.optBruto = New System.Windows.Forms.RadioButton()
      Me.tbImporte = New System.Windows.Forms.TextBox()
      Me.tbImpAlq = New System.Windows.Forms.TextBox()
      Me.tbDetalle = New System.Windows.Forms.TextBox()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.tbDetOtros = New System.Windows.Forms.TextBox()
      Me.tbImpOtros = New System.Windows.Forms.TextBox()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.tbDetDesc = New System.Windows.Forms.TextBox()
      Me.tbImpDesc = New System.Windows.Forms.TextBox()
      Me.Label7 = New System.Windows.Forms.Label()
      Me.tbDetRet = New System.Windows.Forms.TextBox()
      Me.tbImpRet = New System.Windows.Forms.TextBox()
      Me.cmdProyeccion = New System.Windows.Forms.Button()
      Me.cmdAceptar = New System.Windows.Forms.Button()
      Me.cmdCancelar = New System.Windows.Forms.Button()
      Me.Label8 = New System.Windows.Forms.Label()
      Me.tbPropietario = New System.Windows.Forms.TextBox()
      Me.tbImpBon = New System.Windows.Forms.TextBox()
      Me.Label9 = New System.Windows.Forms.Label()
      Me.tbDetBon = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'cbPropiedad
        '
        Me.cbPropiedad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPropiedad.FormattingEnabled = True
        Me.cbPropiedad.Location = New System.Drawing.Point(90, 56)
        Me.cbPropiedad.Name = "cbPropiedad"
        Me.cbPropiedad.Size = New System.Drawing.Size(525, 21)
        Me.cbPropiedad.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(26, 59)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Propiedad:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(28, 88)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Concepto:"
        '
        'cbDescConc
        '
        Me.cbDescConc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDescConc.FormattingEnabled = True
        Me.cbDescConc.Location = New System.Drawing.Point(90, 85)
        Me.cbDescConc.Name = "cbDescConc"
        Me.cbDescConc.Size = New System.Drawing.Size(439, 21)
        Me.cbDescConc.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(34, 121)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Período:"
        '
        'cbPeriodo
        '
        Me.cbPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPeriodo.FormattingEnabled = True
        Me.cbPeriodo.Location = New System.Drawing.Point(90, 118)
        Me.cbPeriodo.Name = "cbPeriodo"
        Me.cbPeriodo.Size = New System.Drawing.Size(85, 21)
        Me.cbPeriodo.TabIndex = 3
        '
        'cbConcepto
        '
        Me.cbConcepto.FormattingEnabled = True
        Me.cbConcepto.Location = New System.Drawing.Point(427, 85)
        Me.cbConcepto.Name = "cbConcepto"
        Me.cbConcepto.Size = New System.Drawing.Size(85, 21)
        Me.cbConcepto.TabIndex = 6
        Me.cbConcepto.Visible = False
        '
        'lblComision
        '
        Me.lblComision.AutoSize = True
        Me.lblComision.Location = New System.Drawing.Point(294, 121)
        Me.lblComision.Name = "lblComision"
        Me.lblComision.Size = New System.Drawing.Size(52, 13)
        Me.lblComision.TabIndex = 7
        Me.lblComision.Text = "Comisión:"
        '
        'optNeto
        '
        Me.optNeto.AutoSize = True
        Me.optNeto.Checked = True
        Me.optNeto.Location = New System.Drawing.Point(82, 158)
        Me.optNeto.Name = "optNeto"
        Me.optNeto.Size = New System.Drawing.Size(48, 17)
        Me.optNeto.TabIndex = 4
        Me.optNeto.TabStop = True
        Me.optNeto.Text = "&Neto"
        Me.optNeto.UseVisualStyleBackColor = True
        '
        'optBruto
        '
        Me.optBruto.AutoSize = True
        Me.optBruto.Location = New System.Drawing.Point(166, 158)
        Me.optBruto.Name = "optBruto"
        Me.optBruto.Size = New System.Drawing.Size(50, 17)
        Me.optBruto.TabIndex = 5
        Me.optBruto.Text = "&Bruto"
        Me.optBruto.UseVisualStyleBackColor = True
        '
        'tbImporte
        '
        Me.tbImporte.Location = New System.Drawing.Point(90, 193)
        Me.tbImporte.Name = "tbImporte"
        Me.tbImporte.Size = New System.Drawing.Size(78, 20)
        Me.tbImporte.TabIndex = 10
        '
        'tbImpAlq
        '
        Me.tbImpAlq.Enabled = False
        Me.tbImpAlq.Location = New System.Drawing.Point(174, 193)
        Me.tbImpAlq.Name = "tbImpAlq"
        Me.tbImpAlq.Size = New System.Drawing.Size(77, 20)
        Me.tbImpAlq.TabIndex = 11
        '
        'tbDetalle
        '
        Me.tbDetalle.Location = New System.Drawing.Point(257, 193)
        Me.tbDetalle.MaxLength = 50
        Me.tbDetalle.Name = "tbDetalle"
        Me.tbDetalle.Size = New System.Drawing.Size(358, 20)
        Me.tbDetalle.TabIndex = 12
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(34, 196)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Alquiler $"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(45, 250)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 13)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Otros $"
        '
        'tbDetOtros
        '
        Me.tbDetOtros.Location = New System.Drawing.Point(174, 247)
        Me.tbDetOtros.MaxLength = 50
        Me.tbDetOtros.Name = "tbDetOtros"
        Me.tbDetOtros.Size = New System.Drawing.Size(441, 20)
        Me.tbDetOtros.TabIndex = 16
        '
        'tbImpOtros
        '
        Me.tbImpOtros.Location = New System.Drawing.Point(90, 247)
        Me.tbImpOtros.Name = "tbImpOtros"
        Me.tbImpOtros.Size = New System.Drawing.Size(78, 20)
        Me.tbImpOtros.TabIndex = 15
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 276)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 13)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "Descuentos $"
        '
        'tbDetDesc
        '
        Me.tbDetDesc.Location = New System.Drawing.Point(174, 273)
        Me.tbDetDesc.MaxLength = 50
        Me.tbDetDesc.Name = "tbDetDesc"
        Me.tbDetDesc.Size = New System.Drawing.Size(441, 20)
        Me.tbDetDesc.TabIndex = 18
        '
        'tbImpDesc
        '
        Me.tbImpDesc.Location = New System.Drawing.Point(90, 273)
        Me.tbImpDesc.Name = "tbImpDesc"
        Me.tbImpDesc.Size = New System.Drawing.Size(78, 20)
        Me.tbImpDesc.TabIndex = 17
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(10, 305)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(76, 13)
        Me.Label7.TabIndex = 22
        Me.Label7.Text = "Retenciones $"
        '
        'tbDetRet
        '
        Me.tbDetRet.Location = New System.Drawing.Point(176, 302)
        Me.tbDetRet.MaxLength = 50
        Me.tbDetRet.Name = "tbDetRet"
        Me.tbDetRet.Size = New System.Drawing.Size(439, 20)
        Me.tbDetRet.TabIndex = 21
        '
        'tbImpRet
        '
        Me.tbImpRet.Location = New System.Drawing.Point(90, 302)
        Me.tbImpRet.Name = "tbImpRet"
        Me.tbImpRet.Size = New System.Drawing.Size(78, 20)
        Me.tbImpRet.TabIndex = 20
        '
        'cmdProyeccion
        '
        Me.cmdProyeccion.Location = New System.Drawing.Point(443, 155)
        Me.cmdProyeccion.Name = "cmdProyeccion"
        Me.cmdProyeccion.Size = New System.Drawing.Size(86, 23)
        Me.cmdProyeccion.TabIndex = 6
        Me.cmdProyeccion.Text = "&Proyección"
        Me.cmdProyeccion.UseVisualStyleBackColor = True
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Location = New System.Drawing.Point(459, 363)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(75, 23)
        Me.cmdAceptar.TabIndex = 22
        Me.cmdAceptar.Text = "Aceptar"
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Location = New System.Drawing.Point(540, 363)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancelar.TabIndex = 25
        Me.cmdCancelar.Text = "&Cancelar"
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(24, 30)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(60, 13)
        Me.Label8.TabIndex = 27
        Me.Label8.Text = "Propietario:"
        '
        'tbPropietario
        '
        Me.tbPropietario.Enabled = False
        Me.tbPropietario.Location = New System.Drawing.Point(90, 27)
        Me.tbPropietario.Name = "tbPropietario"
        Me.tbPropietario.Size = New System.Drawing.Size(525, 20)
        Me.tbPropietario.TabIndex = 0
        '
        'tbImpBon
        '
        Me.tbImpBon.Location = New System.Drawing.Point(90, 219)
        Me.tbImpBon.Name = "tbImpBon"
        Me.tbImpBon.Size = New System.Drawing.Size(78, 20)
        Me.tbImpBon.TabIndex = 13
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(25, 226)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(61, 13)
        Me.Label9.TabIndex = 50
        Me.Label9.Text = "Bonif.Alq. $"
        '
        'tbDetBon
        '
        Me.tbDetBon.Location = New System.Drawing.Point(174, 221)
        Me.tbDetBon.MaxLength = 50
        Me.tbDetBon.Name = "tbDetBon"
        Me.tbDetBon.Size = New System.Drawing.Size(441, 20)
        Me.tbDetBon.TabIndex = 14
        '
        'frmLiqPropietAdl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(627, 398)
        Me.Controls.Add(Me.tbDetBon)
        Me.Controls.Add(Me.tbImpBon)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.tbPropietario)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Controls.Add(Me.cmdProyeccion)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.tbDetRet)
        Me.Controls.Add(Me.tbImpRet)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.tbDetDesc)
        Me.Controls.Add(Me.tbImpDesc)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.tbDetOtros)
        Me.Controls.Add(Me.tbImpOtros)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.tbDetalle)
        Me.Controls.Add(Me.tbImpAlq)
        Me.Controls.Add(Me.tbImporte)
        Me.Controls.Add(Me.optBruto)
        Me.Controls.Add(Me.optNeto)
        Me.Controls.Add(Me.lblComision)
        Me.Controls.Add(Me.cbConcepto)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cbPeriodo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cbDescConc)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbPropiedad)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLiqPropietAdl"
        Me.Text = "Liquidación Propietario: Adelanto"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cbPropiedad As System.Windows.Forms.ComboBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents cbDescConc As System.Windows.Forms.ComboBox
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents cbPeriodo As System.Windows.Forms.ComboBox
   Friend WithEvents cbConcepto As System.Windows.Forms.ComboBox
   Friend WithEvents lblComision As System.Windows.Forms.Label
   Friend WithEvents optNeto As System.Windows.Forms.RadioButton
   Friend WithEvents optBruto As System.Windows.Forms.RadioButton
   Friend WithEvents tbImporte As System.Windows.Forms.TextBox
   Friend WithEvents tbImpAlq As System.Windows.Forms.TextBox
   Friend WithEvents tbDetalle As System.Windows.Forms.TextBox
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents tbDetOtros As System.Windows.Forms.TextBox
   Friend WithEvents tbImpOtros As System.Windows.Forms.TextBox
   Friend WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents tbDetDesc As System.Windows.Forms.TextBox
   Friend WithEvents tbImpDesc As System.Windows.Forms.TextBox
   Friend WithEvents Label7 As System.Windows.Forms.Label
   Friend WithEvents tbDetRet As System.Windows.Forms.TextBox
   Friend WithEvents tbImpRet As System.Windows.Forms.TextBox
   Friend WithEvents cmdProyeccion As System.Windows.Forms.Button
   Friend WithEvents cmdAceptar As System.Windows.Forms.Button
   Friend WithEvents cmdCancelar As System.Windows.Forms.Button
   Friend WithEvents Label8 As System.Windows.Forms.Label
   Friend WithEvents tbPropietario As System.Windows.Forms.TextBox
   Friend WithEvents tbImpBon As System.Windows.Forms.TextBox
   Friend WithEvents Label9 As System.Windows.Forms.Label
   Friend WithEvents tbDetBon As System.Windows.Forms.TextBox
End Class
