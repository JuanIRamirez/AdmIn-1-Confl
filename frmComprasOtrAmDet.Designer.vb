<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmComprasOtrAmDet
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
      Me.Label2 = New System.Windows.Forms.Label()
      Me.cbConcepto = New System.Windows.Forms.ComboBox()
      Me.Label9 = New System.Windows.Forms.Label()
      Me.tbDetalle = New System.Windows.Forms.TextBox()
      Me.tbImporte = New System.Windows.Forms.TextBox()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.optDebe = New System.Windows.Forms.RadioButton()
      Me.opthaber = New System.Windows.Forms.RadioButton()
      Me.GroupBox1 = New System.Windows.Forms.GroupBox()
      Me.GroupBox2 = New System.Windows.Forms.GroupBox()
      Me.optPropiet = New System.Windows.Forms.RadioButton()
      Me.optAdmin = New System.Windows.Forms.RadioButton()
      Me.btnCancelar = New System.Windows.Forms.Button()
      Me.btnAceptar = New System.Windows.Forms.Button()
      Me.GroupBox1.SuspendLayout()
      Me.GroupBox2.SuspendLayout()
      Me.SuspendLayout()
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(27, 45)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(56, 13)
      Me.Label2.TabIndex = 110
      Me.Label2.Text = "Concepto:"
      '
      'cbConcepto
      '
      Me.cbConcepto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      Me.cbConcepto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.cbConcepto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbConcepto.FormattingEnabled = True
      Me.cbConcepto.Location = New System.Drawing.Point(89, 42)
      Me.cbConcepto.Name = "cbConcepto"
      Me.cbConcepto.Size = New System.Drawing.Size(525, 21)
      Me.cbConcepto.TabIndex = 0
      '
      'Label9
      '
      Me.Label9.AutoSize = True
      Me.Label9.Location = New System.Drawing.Point(40, 83)
      Me.Label9.Name = "Label9"
      Me.Label9.Size = New System.Drawing.Size(43, 13)
      Me.Label9.TabIndex = 168
      Me.Label9.Text = "Detalle:"
      '
      'tbDetalle
      '
      Me.tbDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.tbDetalle.Location = New System.Drawing.Point(89, 80)
      Me.tbDetalle.MaxLength = 50
      Me.tbDetalle.Name = "tbDetalle"
      Me.tbDetalle.Size = New System.Drawing.Size(525, 20)
      Me.tbDetalle.TabIndex = 1
      '
      'tbImporte
      '
      Me.tbImporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.tbImporte.Location = New System.Drawing.Point(89, 118)
      Me.tbImporte.MaxLength = 10
      Me.tbImporte.Name = "tbImporte"
      Me.tbImporte.Size = New System.Drawing.Size(103, 20)
      Me.tbImporte.TabIndex = 2
      Me.tbImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.Location = New System.Drawing.Point(32, 121)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(51, 13)
      Me.Label5.TabIndex = 170
      Me.Label5.Text = "Importe $"
      '
      'optDebe
      '
      Me.optDebe.AutoSize = True
      Me.optDebe.Checked = True
      Me.optDebe.Location = New System.Drawing.Point(59, 30)
      Me.optDebe.Name = "optDebe"
      Me.optDebe.Size = New System.Drawing.Size(51, 17)
      Me.optDebe.TabIndex = 3
      Me.optDebe.TabStop = True
      Me.optDebe.Text = "&Debe"
      Me.optDebe.UseVisualStyleBackColor = True
      '
      'opthaber
      '
      Me.opthaber.AutoSize = True
      Me.opthaber.Location = New System.Drawing.Point(149, 30)
      Me.opthaber.Name = "opthaber"
      Me.opthaber.Size = New System.Drawing.Size(54, 17)
      Me.opthaber.TabIndex = 4
      Me.opthaber.Text = "&Haber"
      Me.opthaber.UseVisualStyleBackColor = True
      '
      'GroupBox1
      '
      Me.GroupBox1.Controls.Add(Me.optDebe)
      Me.GroupBox1.Controls.Add(Me.opthaber)
      Me.GroupBox1.Location = New System.Drawing.Point(30, 167)
      Me.GroupBox1.Name = "GroupBox1"
      Me.GroupBox1.Size = New System.Drawing.Size(267, 65)
      Me.GroupBox1.TabIndex = 3
      Me.GroupBox1.TabStop = False
      Me.GroupBox1.Text = "Imputación"
      '
      'GroupBox2
      '
      Me.GroupBox2.Controls.Add(Me.optPropiet)
      Me.GroupBox2.Controls.Add(Me.optAdmin)
      Me.GroupBox2.Location = New System.Drawing.Point(30, 252)
      Me.GroupBox2.Name = "GroupBox2"
      Me.GroupBox2.Size = New System.Drawing.Size(267, 65)
      Me.GroupBox2.TabIndex = 4
      Me.GroupBox2.TabStop = False
      Me.GroupBox2.Text = "Asignación"
      '
      'optPropiet
      '
      Me.optPropiet.AutoSize = True
      Me.optPropiet.Location = New System.Drawing.Point(59, 30)
      Me.optPropiet.Name = "optPropiet"
      Me.optPropiet.Size = New System.Drawing.Size(75, 17)
      Me.optPropiet.TabIndex = 5
      Me.optPropiet.Text = "&Propietario"
      Me.optPropiet.UseVisualStyleBackColor = True
      '
      'optAdmin
      '
      Me.optAdmin.AutoSize = True
      Me.optAdmin.Location = New System.Drawing.Point(149, 30)
      Me.optAdmin.Name = "optAdmin"
      Me.optAdmin.Size = New System.Drawing.Size(93, 17)
      Me.optAdmin.TabIndex = 6
      Me.optAdmin.Text = "&Administración"
      Me.optAdmin.UseVisualStyleBackColor = True
      '
      'btnCancelar
      '
      Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btnCancelar.Location = New System.Drawing.Point(551, 333)
      Me.btnCancelar.Name = "btnCancelar"
      Me.btnCancelar.Size = New System.Drawing.Size(63, 27)
      Me.btnCancelar.TabIndex = 8
      Me.btnCancelar.Text = "&Cancelar"
      Me.btnCancelar.UseVisualStyleBackColor = True
      '
      'btnAceptar
      '
      Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btnAceptar.Location = New System.Drawing.Point(456, 333)
      Me.btnAceptar.Name = "btnAceptar"
      Me.btnAceptar.Size = New System.Drawing.Size(89, 27)
      Me.btnAceptar.TabIndex = 7
      Me.btnAceptar.Text = "&Aceptar"
      Me.btnAceptar.UseVisualStyleBackColor = True
      '
      'frmComprasOtrAmDet
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(626, 372)
      Me.Controls.Add(Me.btnCancelar)
      Me.Controls.Add(Me.btnAceptar)
      Me.Controls.Add(Me.GroupBox2)
      Me.Controls.Add(Me.GroupBox1)
      Me.Controls.Add(Me.tbImporte)
      Me.Controls.Add(Me.Label5)
      Me.Controls.Add(Me.Label9)
      Me.Controls.Add(Me.tbDetalle)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.cbConcepto)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "frmComprasOtrAmDet"
      Me.Text = "Otros Comprobantes, Conceptos"
      Me.GroupBox1.ResumeLayout(False)
      Me.GroupBox1.PerformLayout()
      Me.GroupBox2.ResumeLayout(False)
      Me.GroupBox2.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents cbConcepto As System.Windows.Forms.ComboBox
   Friend WithEvents Label9 As System.Windows.Forms.Label
   Public WithEvents tbDetalle As System.Windows.Forms.TextBox
   Friend WithEvents tbImporte As System.Windows.Forms.TextBox
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents optDebe As System.Windows.Forms.RadioButton
   Friend WithEvents opthaber As System.Windows.Forms.RadioButton
   Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
   Friend WithEvents optPropiet As System.Windows.Forms.RadioButton
   Friend WithEvents optAdmin As System.Windows.Forms.RadioButton
   Friend WithEvents btnCancelar As System.Windows.Forms.Button
   Friend WithEvents btnAceptar As System.Windows.Forms.Button
End Class
