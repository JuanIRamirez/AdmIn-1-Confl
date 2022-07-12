<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListAlq
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
      Me.cmdAceptar = New System.Windows.Forms.Button()
      Me.cmdCerrar = New System.Windows.Forms.Button()
      Me.dtpPeriodo = New System.Windows.Forms.DateTimePicker()
      Me.Label22 = New System.Windows.Forms.Label()
      Me.SuspendLayout()
      '
      'cmdAceptar
      '
      Me.cmdAceptar.Location = New System.Drawing.Point(234, 230)
      Me.cmdAceptar.Name = "cmdAceptar"
      Me.cmdAceptar.Size = New System.Drawing.Size(75, 25)
      Me.cmdAceptar.TabIndex = 77
      Me.cmdAceptar.Text = "&Aceptar"
      Me.cmdAceptar.UseVisualStyleBackColor = True
      '
      'cmdCerrar
      '
      Me.cmdCerrar.Location = New System.Drawing.Point(315, 230)
      Me.cmdCerrar.Name = "cmdCerrar"
      Me.cmdCerrar.Size = New System.Drawing.Size(75, 25)
      Me.cmdCerrar.TabIndex = 78
      Me.cmdCerrar.Text = "&Cerrar"
      Me.cmdCerrar.UseVisualStyleBackColor = True
      '
      'dtpPeriodo
      '
      Me.dtpPeriodo.CustomFormat = "MM/yyyy"
      Me.dtpPeriodo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpPeriodo.Location = New System.Drawing.Point(152, 99)
      Me.dtpPeriodo.Name = "dtpPeriodo"
      Me.dtpPeriodo.Size = New System.Drawing.Size(90, 20)
      Me.dtpPeriodo.TabIndex = 74
      '
      'Label22
      '
      Me.Label22.AutoSize = True
      Me.Label22.Location = New System.Drawing.Point(89, 102)
      Me.Label22.Name = "Label22"
      Me.Label22.Size = New System.Drawing.Size(48, 13)
      Me.Label22.TabIndex = 75
      Me.Label22.Text = "Período:"
      '
      'frmListAlq
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(402, 267)
      Me.Controls.Add(Me.cmdAceptar)
      Me.Controls.Add(Me.cmdCerrar)
      Me.Controls.Add(Me.dtpPeriodo)
      Me.Controls.Add(Me.Label22)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.KeyPreview = True
      Me.MaximizeBox = False
      Me.Name = "frmListAlq"
      Me.Text = "Listado de Alquileres"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents cmdAceptar As System.Windows.Forms.Button
   Friend WithEvents cmdCerrar As System.Windows.Forms.Button
   Friend WithEvents dtpPeriodo As System.Windows.Forms.DateTimePicker
   Friend WithEvents Label22 As System.Windows.Forms.Label
End Class
