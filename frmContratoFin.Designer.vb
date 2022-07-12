<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmContratoFin
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
      Me.tbContrato = New System.Windows.Forms.TextBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.dtFecha = New System.Windows.Forms.DateTimePicker()
      Me.tbDetalle = New System.Windows.Forms.TextBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.cmdCancelar = New System.Windows.Forms.Button()
      Me.cmdAceptar = New System.Windows.Forms.Button()
      Me.SuspendLayout()
      '
      'tbContrato
      '
      Me.tbContrato.Enabled = False
      Me.tbContrato.Location = New System.Drawing.Point(80, 26)
      Me.tbContrato.Name = "tbContrato"
      Me.tbContrato.Size = New System.Drawing.Size(100, 20)
      Me.tbContrato.TabIndex = 0
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(12, 29)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(62, 13)
      Me.Label1.TabIndex = 1
      Me.Label1.Text = "Contrato Nº"
      '
      'dtFecha
      '
      Me.dtFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtFecha.Location = New System.Drawing.Point(80, 152)
      Me.dtFecha.Name = "dtFecha"
      Me.dtFecha.Size = New System.Drawing.Size(100, 20)
      Me.dtFecha.TabIndex = 2
      '
      'tbDetalle
      '
      Me.tbDetalle.Enabled = False
      Me.tbDetalle.Location = New System.Drawing.Point(12, 52)
      Me.tbDetalle.Multiline = True
      Me.tbDetalle.Name = "tbDetalle"
      Me.tbDetalle.Size = New System.Drawing.Size(454, 94)
      Me.tbDetalle.TabIndex = 3
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(12, 156)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(56, 13)
      Me.Label2.TabIndex = 4
      Me.Label2.Text = "Finaliza el:"
      '
      'cmdCancelar
      '
      Me.cmdCancelar.Anchor = System.Windows.Forms.AnchorStyles.None
      Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.cmdCancelar.Location = New System.Drawing.Point(390, 180)
      Me.cmdCancelar.Name = "cmdCancelar"
      Me.cmdCancelar.Size = New System.Drawing.Size(76, 27)
      Me.cmdCancelar.TabIndex = 12
      Me.cmdCancelar.Text = "&Cancelar"
      Me.cmdCancelar.UseVisualStyleBackColor = True
      '
      'cmdAceptar
      '
      Me.cmdAceptar.Anchor = System.Windows.Forms.AnchorStyles.None
      Me.cmdAceptar.Location = New System.Drawing.Point(308, 180)
      Me.cmdAceptar.Name = "cmdAceptar"
      Me.cmdAceptar.Size = New System.Drawing.Size(76, 27)
      Me.cmdAceptar.TabIndex = 11
      Me.cmdAceptar.Text = "&Aceptar"
      Me.cmdAceptar.UseVisualStyleBackColor = True
      '
      'frmContratoFin
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(478, 219)
      Me.Controls.Add(Me.cmdCancelar)
      Me.Controls.Add(Me.cmdAceptar)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.tbDetalle)
      Me.Controls.Add(Me.dtFecha)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.tbContrato)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "frmContratoFin"
      Me.Text = "Finalizar Contrato"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents tbContrato As System.Windows.Forms.TextBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents dtFecha As System.Windows.Forms.DateTimePicker
   Friend WithEvents tbDetalle As System.Windows.Forms.TextBox
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents cmdCancelar As System.Windows.Forms.Button
   Friend WithEvents cmdAceptar As System.Windows.Forms.Button
End Class
