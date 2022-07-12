<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCajaRecList
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
      Me.optResumen = New System.Windows.Forms.RadioButton()
      Me.optDetalle = New System.Windows.Forms.RadioButton()
      Me.optRecup = New System.Windows.Forms.RadioButton()
      Me.cmdAceptar = New System.Windows.Forms.Button()
      Me.cmdCerrar = New System.Windows.Forms.Button()
      Me.SuspendLayout()
      '
      'optResumen
      '
      Me.optResumen.AutoSize = True
      Me.optResumen.Checked = True
      Me.optResumen.Location = New System.Drawing.Point(37, 55)
      Me.optResumen.Name = "optResumen"
      Me.optResumen.Size = New System.Drawing.Size(70, 17)
      Me.optResumen.TabIndex = 0
      Me.optResumen.TabStop = True
      Me.optResumen.Text = "&Resumen"
      Me.optResumen.UseVisualStyleBackColor = True
      '
      'optDetalle
      '
      Me.optDetalle.AutoSize = True
      Me.optDetalle.Location = New System.Drawing.Point(113, 55)
      Me.optDetalle.Name = "optDetalle"
      Me.optDetalle.Size = New System.Drawing.Size(70, 17)
      Me.optDetalle.TabIndex = 1
      Me.optDetalle.Text = "&Detallado"
      Me.optDetalle.UseVisualStyleBackColor = True
      '
      'optRecup
      '
      Me.optRecup.AutoSize = True
      Me.optRecup.Location = New System.Drawing.Point(189, 55)
      Me.optRecup.Name = "optRecup"
      Me.optRecup.Size = New System.Drawing.Size(89, 17)
      Me.optRecup.TabIndex = 2
      Me.optRecup.Text = "R&ecuperados"
      Me.optRecup.UseVisualStyleBackColor = True
      '
      'cmdAceptar
      '
      Me.cmdAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdAceptar.Location = New System.Drawing.Point(229, 140)
      Me.cmdAceptar.Name = "cmdAceptar"
      Me.cmdAceptar.Size = New System.Drawing.Size(76, 27)
      Me.cmdAceptar.TabIndex = 6
      Me.cmdAceptar.Text = "&Aceptar"
      Me.cmdAceptar.UseVisualStyleBackColor = True
      '
      'cmdCerrar
      '
      Me.cmdCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdCerrar.Location = New System.Drawing.Point(311, 140)
      Me.cmdCerrar.Name = "cmdCerrar"
      Me.cmdCerrar.Size = New System.Drawing.Size(70, 27)
      Me.cmdCerrar.TabIndex = 7
      Me.cmdCerrar.Text = "&Cerrar"
      Me.cmdCerrar.UseVisualStyleBackColor = True
      '
      'frmCajaRecList
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(393, 179)
      Me.Controls.Add(Me.cmdAceptar)
      Me.Controls.Add(Me.cmdCerrar)
      Me.Controls.Add(Me.optRecup)
      Me.Controls.Add(Me.optDetalle)
      Me.Controls.Add(Me.optResumen)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.Name = "frmCajaRecList"
      Me.Text = "Listado de Caja a Recuperar"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents optResumen As System.Windows.Forms.RadioButton
   Friend WithEvents optDetalle As System.Windows.Forms.RadioButton
   Friend WithEvents optRecup As System.Windows.Forms.RadioButton
   Friend WithEvents cmdAceptar As System.Windows.Forms.Button
   Friend WithEvents cmdCerrar As System.Windows.Forms.Button
End Class
