<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListVentas
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
      Me.Label22 = New System.Windows.Forms.Label()
      Me.chkProp = New System.Windows.Forms.CheckBox()
      Me.cmdAceptar = New System.Windows.Forms.Button()
      Me.cmdCerrar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'dtpPeriodo
        '
        Me.dtpPeriodo.CustomFormat = "MM/yyyy"
        Me.dtpPeriodo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpPeriodo.Location = New System.Drawing.Point(131, 61)
        Me.dtpPeriodo.Name = "dtpPeriodo"
        Me.dtpPeriodo.Size = New System.Drawing.Size(90, 20)
        Me.dtpPeriodo.TabIndex = 69
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(68, 64)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(48, 13)
        Me.Label22.TabIndex = 70
        Me.Label22.Text = "Período:"
        '
        'chkProp
        '
        Me.chkProp.AutoSize = True
        Me.chkProp.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkProp.Location = New System.Drawing.Point(71, 115)
        Me.chkProp.Name = "chkProp"
        Me.chkProp.Size = New System.Drawing.Size(150, 17)
        Me.chkProp.TabIndex = 71
        Me.chkProp.Text = "Solo Ventas a &Propietarios"
        Me.chkProp.UseVisualStyleBackColor = True
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Location = New System.Drawing.Point(333, 214)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(75, 25)
        Me.cmdAceptar.TabIndex = 72
        Me.cmdAceptar.Text = "&Aceptar"
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'cmdCerrar
        '
        Me.cmdCerrar.Location = New System.Drawing.Point(414, 214)
        Me.cmdCerrar.Name = "cmdCerrar"
        Me.cmdCerrar.Size = New System.Drawing.Size(75, 25)
        Me.cmdCerrar.TabIndex = 73
        Me.cmdCerrar.Text = "&Cerrar"
        Me.cmdCerrar.UseVisualStyleBackColor = True
        '
        'frmListVentas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(501, 251)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Controls.Add(Me.cmdCerrar)
        Me.Controls.Add(Me.chkProp)
        Me.Controls.Add(Me.dtpPeriodo)
        Me.Controls.Add(Me.Label22)
        Me.Name = "frmListVentas"
        Me.Text = "Listado de Ventas"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtpPeriodo As System.Windows.Forms.DateTimePicker
   Friend WithEvents Label22 As System.Windows.Forms.Label
   Friend WithEvents chkProp As System.Windows.Forms.CheckBox
   Friend WithEvents cmdAceptar As System.Windows.Forms.Button
   Friend WithEvents cmdCerrar As System.Windows.Forms.Button
End Class
