<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmComprasDet
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
      Me.cboConcepto = New System.Windows.Forms.ComboBox()
      Me.lblCliente = New System.Windows.Forms.Label()
      Me.Label23 = New System.Windows.Forms.Label()
      Me.tbDetalle = New System.Windows.Forms.TextBox()
      Me.Label24 = New System.Windows.Forms.Label()
      Me.optHaber = New System.Windows.Forms.RadioButton()
      Me.optDebe = New System.Windows.Forms.RadioButton()
      Me.fraImportes = New System.Windows.Forms.Panel()
      Me.txtBonificacion = New System.Windows.Forms.TextBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.txtNoGravado = New System.Windows.Forms.TextBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.tbImporte = New System.Windows.Forms.TextBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.optBruto = New System.Windows.Forms.RadioButton()
      Me.optNeto = New System.Windows.Forms.RadioButton()
      Me.txtSubtotal = New System.Windows.Forms.TextBox()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.cmdAceptar = New System.Windows.Forms.Button()
      Me.cmdCancelar = New System.Windows.Forms.Button()
      Me.fraImportes.SuspendLayout()
      Me.SuspendLayout()
      '
      'cboConcepto
      '
      Me.cboConcepto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      Me.cboConcepto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.cboConcepto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboConcepto.FormattingEnabled = True
      Me.cboConcepto.Location = New System.Drawing.Point(91, 41)
      Me.cboConcepto.Name = "cboConcepto"
      Me.cboConcepto.Size = New System.Drawing.Size(382, 21)
      Me.cboConcepto.TabIndex = 4
      '
      'lblCliente
      '
      Me.lblCliente.AutoSize = True
      Me.lblCliente.Location = New System.Drawing.Point(23, 44)
      Me.lblCliente.Name = "lblCliente"
      Me.lblCliente.Size = New System.Drawing.Size(56, 13)
      Me.lblCliente.TabIndex = 3
      Me.lblCliente.Text = "Concepto:"
      '
      'Label23
      '
      Me.Label23.AutoSize = True
      Me.Label23.Location = New System.Drawing.Point(36, 76)
      Me.Label23.Name = "Label23"
      Me.Label23.Size = New System.Drawing.Size(43, 13)
      Me.Label23.TabIndex = 82
      Me.Label23.Text = "Detalle:"
      '
      'tbDetalle
      '
      Me.tbDetalle.Location = New System.Drawing.Point(91, 73)
      Me.tbDetalle.Multiline = True
      Me.tbDetalle.Name = "tbDetalle"
      Me.tbDetalle.Size = New System.Drawing.Size(382, 57)
      Me.tbDetalle.TabIndex = 81
      '
      'Label24
      '
      Me.Label24.AutoSize = True
      Me.Label24.Location = New System.Drawing.Point(16, 155)
      Me.Label24.Name = "Label24"
      Me.Label24.Size = New System.Drawing.Size(62, 13)
      Me.Label24.TabIndex = 86
      Me.Label24.Text = "Imputación:"
      '
      'optHaber
      '
      Me.optHaber.AutoSize = True
      Me.optHaber.Location = New System.Drawing.Point(164, 154)
      Me.optHaber.Name = "optHaber"
      Me.optHaber.Size = New System.Drawing.Size(58, 17)
      Me.optHaber.TabIndex = 85
      Me.optHaber.Text = "Crédito"
      Me.optHaber.UseVisualStyleBackColor = True
      '
      'optDebe
      '
      Me.optDebe.AutoSize = True
      Me.optDebe.Checked = True
      Me.optDebe.Location = New System.Drawing.Point(91, 153)
      Me.optDebe.Name = "optDebe"
      Me.optDebe.Size = New System.Drawing.Size(56, 17)
      Me.optDebe.TabIndex = 84
      Me.optDebe.TabStop = True
      Me.optDebe.Text = "Débito"
      Me.optDebe.UseVisualStyleBackColor = True
      '
      'fraImportes
      '
      Me.fraImportes.Controls.Add(Me.txtBonificacion)
      Me.fraImportes.Controls.Add(Me.Label3)
      Me.fraImportes.Controls.Add(Me.txtNoGravado)
      Me.fraImportes.Controls.Add(Me.Label2)
      Me.fraImportes.Controls.Add(Me.tbImporte)
      Me.fraImportes.Controls.Add(Me.Label1)
      Me.fraImportes.Controls.Add(Me.optBruto)
      Me.fraImportes.Controls.Add(Me.optNeto)
      Me.fraImportes.Location = New System.Drawing.Point(19, 193)
      Me.fraImportes.Name = "fraImportes"
      Me.fraImportes.Size = New System.Drawing.Size(454, 117)
      Me.fraImportes.TabIndex = 87
      '
      'txtBonificacion
      '
      Me.txtBonificacion.Location = New System.Drawing.Point(99, 77)
      Me.txtBonificacion.Name = "txtBonificacion"
      Me.txtBonificacion.Size = New System.Drawing.Size(77, 20)
      Me.txtBonificacion.TabIndex = 94
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(17, 80)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(76, 13)
      Me.Label3.TabIndex = 93
      Me.Label3.Text = "Bonificación %"
      '
      'txtNoGravado
      '
      Me.txtNoGravado.Location = New System.Drawing.Point(99, 47)
      Me.txtNoGravado.Name = "txtNoGravado"
      Me.txtNoGravado.Size = New System.Drawing.Size(77, 20)
      Me.txtNoGravado.TabIndex = 92
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(21, 50)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(72, 13)
      Me.Label2.TabIndex = 91
      Me.Label2.Text = "No gravado $"
      '
      'tbImporte
      '
      Me.tbImporte.Location = New System.Drawing.Point(99, 18)
      Me.tbImporte.Name = "tbImporte"
      Me.tbImporte.Size = New System.Drawing.Size(77, 20)
      Me.tbImporte.TabIndex = 90
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(42, 21)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(51, 13)
      Me.Label1.TabIndex = 89
      Me.Label1.Text = "Importe $"
      '
      'optBruto
      '
      Me.optBruto.AutoSize = True
      Me.optBruto.Location = New System.Drawing.Point(249, 19)
      Me.optBruto.Name = "optBruto"
      Me.optBruto.Size = New System.Drawing.Size(47, 17)
      Me.optBruto.TabIndex = 88
      Me.optBruto.Text = "&Final"
      Me.optBruto.UseVisualStyleBackColor = True
      '
      'optNeto
      '
      Me.optNeto.AutoSize = True
      Me.optNeto.Checked = True
      Me.optNeto.Location = New System.Drawing.Point(187, 19)
      Me.optNeto.Name = "optNeto"
      Me.optNeto.Size = New System.Drawing.Size(48, 17)
      Me.optNeto.TabIndex = 87
      Me.optNeto.TabStop = True
      Me.optNeto.Text = "&Neto"
      Me.optNeto.UseVisualStyleBackColor = True
      '
      'txtSubtotal
      '
      Me.txtSubtotal.Enabled = False
      Me.txtSubtotal.Location = New System.Drawing.Point(118, 328)
      Me.txtSubtotal.Name = "txtSubtotal"
      Me.txtSubtotal.Size = New System.Drawing.Size(77, 20)
      Me.txtSubtotal.TabIndex = 92
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(57, 331)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(55, 13)
      Me.Label4.TabIndex = 91
      Me.Label4.Text = "Subtotal $"
      '
      'cmdAceptar
      '
      Me.cmdAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdAceptar.Location = New System.Drawing.Point(317, 383)
      Me.cmdAceptar.Name = "cmdAceptar"
      Me.cmdAceptar.Size = New System.Drawing.Size(75, 23)
      Me.cmdAceptar.TabIndex = 94
      Me.cmdAceptar.Text = "&Aceptar"
      Me.cmdAceptar.UseVisualStyleBackColor = True
      '
      'cmdCancelar
      '
      Me.cmdCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdCancelar.Location = New System.Drawing.Point(398, 383)
      Me.cmdCancelar.Name = "cmdCancelar"
      Me.cmdCancelar.Size = New System.Drawing.Size(75, 23)
      Me.cmdCancelar.TabIndex = 93
      Me.cmdCancelar.Text = "&Cancelar"
      Me.cmdCancelar.UseVisualStyleBackColor = True
      '
      'frmComprasDet
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(485, 418)
      Me.Controls.Add(Me.cmdAceptar)
      Me.Controls.Add(Me.cmdCancelar)
      Me.Controls.Add(Me.txtSubtotal)
      Me.Controls.Add(Me.Label4)
      Me.Controls.Add(Me.fraImportes)
      Me.Controls.Add(Me.Label24)
      Me.Controls.Add(Me.optHaber)
      Me.Controls.Add(Me.optDebe)
      Me.Controls.Add(Me.Label23)
      Me.Controls.Add(Me.tbDetalle)
      Me.Controls.Add(Me.cboConcepto)
      Me.Controls.Add(Me.lblCliente)
      Me.KeyPreview = True
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "frmComprasDet"
      Me.Text = "frmComprasDet"
      Me.fraImportes.ResumeLayout(False)
      Me.fraImportes.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents cboConcepto As System.Windows.Forms.ComboBox
   Friend WithEvents lblCliente As System.Windows.Forms.Label
   Friend WithEvents Label23 As System.Windows.Forms.Label
   Friend WithEvents tbDetalle As System.Windows.Forms.TextBox
   Friend WithEvents Label24 As System.Windows.Forms.Label
   Friend WithEvents optHaber As System.Windows.Forms.RadioButton
   Friend WithEvents optDebe As System.Windows.Forms.RadioButton
   Friend WithEvents fraImportes As System.Windows.Forms.Panel
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents optBruto As System.Windows.Forms.RadioButton
   Friend WithEvents optNeto As System.Windows.Forms.RadioButton
   Friend WithEvents tbImporte As System.Windows.Forms.TextBox
   Friend WithEvents txtBonificacion As System.Windows.Forms.TextBox
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents txtNoGravado As System.Windows.Forms.TextBox
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents txtSubtotal As System.Windows.Forms.TextBox
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents cmdAceptar As System.Windows.Forms.Button
   Friend WithEvents cmdCancelar As System.Windows.Forms.Button
End Class
