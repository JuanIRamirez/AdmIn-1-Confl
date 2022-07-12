<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListRetGan
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
      Me.dtpPeriodo = New System.Windows.Forms.DateTimePicker()
      Me.Label18 = New System.Windows.Forms.Label()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.optPropiet = New System.Windows.Forms.RadioButton()
      Me.optGeneral = New System.Windows.Forms.RadioButton()
      Me.cmdAceptar = New System.Windows.Forms.Button()
      Me.cmdCancelar = New System.Windows.Forms.Button()
      Me.SuspendLayout()
      '
      'dtpPeriodo
      '
      Me.dtpPeriodo.CustomFormat = "MM/yyyy"
      Me.dtpPeriodo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpPeriodo.Location = New System.Drawing.Point(139, 57)
      Me.dtpPeriodo.Name = "dtpPeriodo"
      Me.dtpPeriodo.Size = New System.Drawing.Size(86, 20)
      Me.dtpPeriodo.TabIndex = 90
      '
      'Label18
      '
      Me.Label18.AutoSize = True
      Me.Label18.Location = New System.Drawing.Point(79, 60)
      Me.Label18.Name = "Label18"
      Me.Label18.Size = New System.Drawing.Size(48, 13)
      Me.Label18.TabIndex = 91
      Me.Label18.Text = "Período:"
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(79, 109)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(31, 13)
      Me.Label2.TabIndex = 94
      Me.Label2.Text = "Tipo:"
      '
      'optPropiet
      '
      Me.optPropiet.AutoSize = True
      Me.optPropiet.Location = New System.Drawing.Point(220, 107)
      Me.optPropiet.Name = "optPropiet"
      Me.optPropiet.Size = New System.Drawing.Size(86, 17)
      Me.optPropiet.TabIndex = 93
      Me.optPropiet.Text = "&p/Propietario"
      Me.optPropiet.UseVisualStyleBackColor = True
      '
      'optGeneral
      '
      Me.optGeneral.AutoSize = True
      Me.optGeneral.Checked = True
      Me.optGeneral.Location = New System.Drawing.Point(139, 107)
      Me.optGeneral.Name = "optGeneral"
      Me.optGeneral.Size = New System.Drawing.Size(62, 17)
      Me.optGeneral.TabIndex = 92
      Me.optGeneral.TabStop = True
      Me.optGeneral.Text = "&General"
      Me.optGeneral.UseVisualStyleBackColor = True
      '
      'cmdAceptar
      '
      Me.cmdAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdAceptar.Location = New System.Drawing.Point(293, 244)
      Me.cmdAceptar.Name = "cmdAceptar"
      Me.cmdAceptar.Size = New System.Drawing.Size(75, 23)
      Me.cmdAceptar.TabIndex = 95
      Me.cmdAceptar.Text = "&Aceptar"
      Me.cmdAceptar.UseVisualStyleBackColor = True
      '
      'cmdCancelar
      '
      Me.cmdCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.cmdCancelar.Location = New System.Drawing.Point(374, 244)
      Me.cmdCancelar.Name = "cmdCancelar"
      Me.cmdCancelar.Size = New System.Drawing.Size(75, 23)
      Me.cmdCancelar.TabIndex = 96
      Me.cmdCancelar.Text = "&Cancelar"
      Me.cmdCancelar.UseVisualStyleBackColor = True
      '
      'frmListRetGan
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(461, 279)
      Me.Controls.Add(Me.cmdAceptar)
      Me.Controls.Add(Me.cmdCancelar)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.optPropiet)
      Me.Controls.Add(Me.optGeneral)
      Me.Controls.Add(Me.dtpPeriodo)
      Me.Controls.Add(Me.Label18)
      Me.MaximizeBox = False
      Me.Name = "frmListRetGan"
      Me.Text = "Listado Retenciones Ganancias"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents dtpPeriodo As System.Windows.Forms.DateTimePicker
   Friend WithEvents Label18 As System.Windows.Forms.Label
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents optPropiet As System.Windows.Forms.RadioButton
   Friend WithEvents optGeneral As System.Windows.Forms.RadioButton
   Friend WithEvents cmdAceptar As System.Windows.Forms.Button
   Friend WithEvents cmdCancelar As System.Windows.Forms.Button
End Class
