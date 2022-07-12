<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVentasAMDet
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
      Me.Label1 = New System.Windows.Forms.Label()
      Me.cboConcepto = New System.Windows.Forms.ComboBox()
      Me.Label12 = New System.Windows.Forms.Label()
      Me.tbDetalle = New System.Windows.Forms.TextBox()
      Me.GroupBox1 = New System.Windows.Forms.GroupBox()
      Me.optHaber = New System.Windows.Forms.RadioButton()
      Me.optDebe = New System.Windows.Forms.RadioButton()
      Me.GroupBox2 = New System.Windows.Forms.GroupBox()
      Me.optBruto = New System.Windows.Forms.RadioButton()
      Me.optNeto = New System.Windows.Forms.RadioButton()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.txtPrecio = New System.Windows.Forms.TextBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.tbBonificacion = New System.Windows.Forms.TextBox()
      Me.cmdAceptar = New System.Windows.Forms.Button()
      Me.btnCancelar = New System.Windows.Forms.Button()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.tbSubtotal = New System.Windows.Forms.TextBox()
      Me.lblAlicIva = New System.Windows.Forms.Label()
      Me.cbAlicIva = New System.Windows.Forms.ComboBox()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.tbIva = New System.Windows.Forms.TextBox()
      Me.Label7 = New System.Windows.Forms.Label()
      Me.tbTotal = New System.Windows.Forms.TextBox()
      Me.btnAgrConc = New System.Windows.Forms.Button()
      Me.GroupBox1.SuspendLayout()
      Me.GroupBox2.SuspendLayout()
      Me.SuspendLayout()
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(31, 38)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(56, 13)
      Me.Label1.TabIndex = 5
      Me.Label1.Text = "Concepto:"
      '
      'cboConcepto
      '
      Me.cboConcepto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboConcepto.FormattingEnabled = True
      Me.cboConcepto.Location = New System.Drawing.Point(93, 35)
      Me.cboConcepto.Name = "cboConcepto"
      Me.cboConcepto.Size = New System.Drawing.Size(367, 21)
      Me.cboConcepto.TabIndex = 0
      '
      'Label12
      '
      Me.Label12.AutoSize = True
      Me.Label12.Location = New System.Drawing.Point(44, 82)
      Me.Label12.Name = "Label12"
      Me.Label12.Size = New System.Drawing.Size(43, 13)
      Me.Label12.TabIndex = 30
      Me.Label12.Text = "Detalle:"
      '
      'tbDetalle
      '
      Me.tbDetalle.Location = New System.Drawing.Point(93, 79)
      Me.tbDetalle.Name = "tbDetalle"
      Me.tbDetalle.Size = New System.Drawing.Size(421, 20)
      Me.tbDetalle.TabIndex = 2
      '
      'GroupBox1
      '
      Me.GroupBox1.Controls.Add(Me.optHaber)
      Me.GroupBox1.Controls.Add(Me.optDebe)
      Me.GroupBox1.Location = New System.Drawing.Point(260, 226)
      Me.GroupBox1.Name = "GroupBox1"
      Me.GroupBox1.Size = New System.Drawing.Size(200, 102)
      Me.GroupBox1.TabIndex = 8
      Me.GroupBox1.TabStop = False
      Me.GroupBox1.Text = "Imputación"
      '
      'optHaber
      '
      Me.optHaber.AutoSize = True
      Me.optHaber.Location = New System.Drawing.Point(124, 42)
      Me.optHaber.Name = "optHaber"
      Me.optHaber.Size = New System.Drawing.Size(54, 17)
      Me.optHaber.TabIndex = 9
      Me.optHaber.Text = "&Haber"
      Me.optHaber.UseVisualStyleBackColor = True
      '
      'optDebe
      '
      Me.optDebe.AutoSize = True
      Me.optDebe.Checked = True
      Me.optDebe.Location = New System.Drawing.Point(28, 42)
      Me.optDebe.Name = "optDebe"
      Me.optDebe.Size = New System.Drawing.Size(51, 17)
      Me.optDebe.TabIndex = 8
      Me.optDebe.TabStop = True
      Me.optDebe.Text = "&Debe"
      Me.optDebe.UseVisualStyleBackColor = True
      '
      'GroupBox2
      '
      Me.GroupBox2.Controls.Add(Me.optBruto)
      Me.GroupBox2.Controls.Add(Me.optNeto)
      Me.GroupBox2.Location = New System.Drawing.Point(260, 120)
      Me.GroupBox2.Name = "GroupBox2"
      Me.GroupBox2.Size = New System.Drawing.Size(200, 100)
      Me.GroupBox2.TabIndex = 7
      Me.GroupBox2.TabStop = False
      Me.GroupBox2.Text = "Valor"
      '
      'optBruto
      '
      Me.optBruto.AutoSize = True
      Me.optBruto.Location = New System.Drawing.Point(123, 42)
      Me.optBruto.Name = "optBruto"
      Me.optBruto.Size = New System.Drawing.Size(50, 17)
      Me.optBruto.TabIndex = 7
      Me.optBruto.TabStop = True
      Me.optBruto.Text = "&Bruto"
      Me.optBruto.UseVisualStyleBackColor = True
      '
      'optNeto
      '
      Me.optNeto.AutoSize = True
      Me.optNeto.Checked = True
      Me.optNeto.Location = New System.Drawing.Point(27, 42)
      Me.optNeto.Name = "optNeto"
      Me.optNeto.Size = New System.Drawing.Size(48, 17)
      Me.optNeto.TabIndex = 6
      Me.optNeto.TabStop = True
      Me.optNeto.Text = "&Neto"
      Me.optNeto.UseVisualStyleBackColor = True
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(39, 164)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(51, 13)
      Me.Label2.TabIndex = 36
      Me.Label2.Text = "Importe $"
      '
      'txtPrecio
      '
      Me.txtPrecio.Location = New System.Drawing.Point(93, 161)
      Me.txtPrecio.Name = "txtPrecio"
      Me.txtPrecio.Size = New System.Drawing.Size(91, 20)
      Me.txtPrecio.TabIndex = 4
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(14, 207)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(76, 13)
      Me.Label3.TabIndex = 38
      Me.Label3.Text = "Bonificación %"
      '
      'tbBonificacion
      '
      Me.tbBonificacion.Location = New System.Drawing.Point(93, 204)
      Me.tbBonificacion.Name = "tbBonificacion"
      Me.tbBonificacion.Size = New System.Drawing.Size(91, 20)
      Me.tbBonificacion.TabIndex = 5
      '
      'cmdAceptar
      '
      Me.cmdAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdAceptar.Location = New System.Drawing.Point(358, 347)
      Me.cmdAceptar.Name = "cmdAceptar"
      Me.cmdAceptar.Size = New System.Drawing.Size(75, 23)
      Me.cmdAceptar.TabIndex = 10
      Me.cmdAceptar.Text = "&Aceptar"
      Me.cmdAceptar.UseVisualStyleBackColor = True
      '
      'btnCancelar
      '
      Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnCancelar.Location = New System.Drawing.Point(439, 347)
      Me.btnCancelar.Name = "btnCancelar"
      Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
      Me.btnCancelar.TabIndex = 11
      Me.btnCancelar.Text = "&Cancelar"
      Me.btnCancelar.UseVisualStyleBackColor = True
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(32, 244)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(55, 13)
      Me.Label4.TabIndex = 57
      Me.Label4.Text = "Subtotal $"
      '
      'tbSubtotal
      '
      Me.tbSubtotal.BackColor = System.Drawing.Color.LightYellow
      Me.tbSubtotal.Enabled = False
      Me.tbSubtotal.Location = New System.Drawing.Point(93, 241)
      Me.tbSubtotal.Name = "tbSubtotal"
      Me.tbSubtotal.Size = New System.Drawing.Size(91, 20)
      Me.tbSubtotal.TabIndex = 6
      '
      'lblAlicIva
      '
      Me.lblAlicIva.AutoSize = True
      Me.lblAlicIva.Location = New System.Drawing.Point(43, 120)
      Me.lblAlicIva.Name = "lblAlicIva"
      Me.lblAlicIva.Size = New System.Drawing.Size(44, 13)
      Me.lblAlicIva.TabIndex = 58
      Me.lblAlicIva.Text = "I.V.A. %"
      '
      'cbAlicIva
      '
      Me.cbAlicIva.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbAlicIva.FormattingEnabled = True
      Me.cbAlicIva.Location = New System.Drawing.Point(93, 117)
      Me.cbAlicIva.Name = "cbAlicIva"
      Me.cbAlicIva.Size = New System.Drawing.Size(53, 21)
      Me.cbAlicIva.TabIndex = 3
      '
      'Label6
      '
      Me.Label6.AutoSize = True
      Me.Label6.Location = New System.Drawing.Point(45, 282)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(42, 13)
      Me.Label6.TabIndex = 60
      Me.Label6.Text = "I.V.A. $"
      '
      'tbIva
      '
      Me.tbIva.Location = New System.Drawing.Point(93, 279)
      Me.tbIva.Name = "tbIva"
      Me.tbIva.Size = New System.Drawing.Size(91, 20)
      Me.tbIva.TabIndex = 6
      '
      'Label7
      '
      Me.Label7.AutoSize = True
      Me.Label7.Location = New System.Drawing.Point(47, 323)
      Me.Label7.Name = "Label7"
      Me.Label7.Size = New System.Drawing.Size(40, 13)
      Me.Label7.TabIndex = 62
      Me.Label7.Text = "Total $"
      '
      'tbTotal
      '
      Me.tbTotal.BackColor = System.Drawing.Color.LightYellow
      Me.tbTotal.Enabled = False
      Me.tbTotal.Location = New System.Drawing.Point(93, 320)
      Me.tbTotal.Name = "tbTotal"
      Me.tbTotal.Size = New System.Drawing.Size(91, 20)
      Me.tbTotal.TabIndex = 61
      '
      'btnAgrConc
      '
      Me.btnAgrConc.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnAgrConc.Enabled = False
      Me.btnAgrConc.Location = New System.Drawing.Point(466, 33)
      Me.btnAgrConc.Name = "btnAgrConc"
      Me.btnAgrConc.Size = New System.Drawing.Size(48, 23)
      Me.btnAgrConc.TabIndex = 1
      Me.btnAgrConc.Text = "&Nuevo"
      Me.btnAgrConc.UseVisualStyleBackColor = True
      '
      'frmVentasAMDet
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(526, 382)
      Me.Controls.Add(Me.btnAgrConc)
      Me.Controls.Add(Me.Label7)
      Me.Controls.Add(Me.tbTotal)
      Me.Controls.Add(Me.Label6)
      Me.Controls.Add(Me.tbIva)
      Me.Controls.Add(Me.cbAlicIva)
      Me.Controls.Add(Me.lblAlicIva)
      Me.Controls.Add(Me.Label4)
      Me.Controls.Add(Me.tbSubtotal)
      Me.Controls.Add(Me.cmdAceptar)
      Me.Controls.Add(Me.btnCancelar)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.tbBonificacion)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.txtPrecio)
      Me.Controls.Add(Me.GroupBox2)
      Me.Controls.Add(Me.GroupBox1)
      Me.Controls.Add(Me.Label12)
      Me.Controls.Add(Me.tbDetalle)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.cboConcepto)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.MaximizeBox = False
      Me.Name = "frmVentasAMDet"
      Me.Text = "Venta - Detalle"
      Me.GroupBox1.ResumeLayout(False)
      Me.GroupBox1.PerformLayout()
      Me.GroupBox2.ResumeLayout(False)
      Me.GroupBox2.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents cboConcepto As System.Windows.Forms.ComboBox
   Friend WithEvents Label12 As System.Windows.Forms.Label
   Friend WithEvents tbDetalle As System.Windows.Forms.TextBox
   Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents optHaber As System.Windows.Forms.RadioButton
   Friend WithEvents optDebe As System.Windows.Forms.RadioButton
   Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
   Friend WithEvents optBruto As System.Windows.Forms.RadioButton
   Friend WithEvents optNeto As System.Windows.Forms.RadioButton
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents txtPrecio As System.Windows.Forms.TextBox
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents tbBonificacion As System.Windows.Forms.TextBox
   Friend WithEvents cmdAceptar As System.Windows.Forms.Button
   Friend WithEvents btnCancelar As System.Windows.Forms.Button
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents tbSubtotal As System.Windows.Forms.TextBox
   Friend WithEvents lblAlicIva As System.Windows.Forms.Label
   Friend WithEvents cbAlicIva As System.Windows.Forms.ComboBox
   Friend WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents tbIva As System.Windows.Forms.TextBox
   Friend WithEvents Label7 As System.Windows.Forms.Label
   Friend WithEvents tbTotal As System.Windows.Forms.TextBox
   Friend WithEvents btnAgrConc As System.Windows.Forms.Button
End Class
