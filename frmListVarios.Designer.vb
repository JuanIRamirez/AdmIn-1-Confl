<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListVarios
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
      Me.optInqGar = New System.Windows.Forms.RadioButton()
      Me.cmdCancelar = New System.Windows.Forms.Button()
      Me.cmdAceptar = New System.Windows.Forms.Button()
        Me.optConcCob = New System.Windows.Forms.RadioButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpHasta = New System.Windows.Forms.DateTimePicker()
        Me.dtpDesde = New System.Windows.Forms.DateTimePicker()
        Me.optConcLiq = New System.Windows.Forms.RadioButton()
        Me.SuspendLayout()
        '
        'optInqGar
        '
        Me.optInqGar.AutoSize = True
        Me.optInqGar.Checked = True
        Me.optInqGar.Location = New System.Drawing.Point(45, 43)
        Me.optInqGar.Name = "optInqGar"
        Me.optInqGar.Size = New System.Drawing.Size(123, 17)
        Me.optInqGar.TabIndex = 0
        Me.optInqGar.TabStop = True
        Me.optInqGar.Text = "&Inquilinos y Garantes"
        Me.optInqGar.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Location = New System.Drawing.Point(424, 230)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(65, 27)
        Me.cmdCancelar.TabIndex = 51
        Me.cmdCancelar.Text = "&Cancelar"
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAceptar.Location = New System.Drawing.Point(331, 230)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(87, 27)
        Me.cmdAceptar.TabIndex = 50
        Me.cmdAceptar.Text = "&Aceptar"
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'optConcCob
        '
        Me.optConcCob.AutoSize = True
        Me.optConcCob.Location = New System.Drawing.Point(45, 82)
        Me.optConcCob.Name = "optConcCob"
        Me.optConcCob.Size = New System.Drawing.Size(123, 17)
        Me.optConcCob.TabIndex = 1
        Me.optConcCob.Text = "&Conceptos cobrados"
        Me.optConcCob.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(191, 169)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 89
        Me.Label5.Text = "Hasta:"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(44, 169)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 13)
        Me.Label4.TabIndex = 88
        Me.Label4.Text = "Desde:"
        '
        'dtpHasta
        '
        Me.dtpHasta.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpHasta.Enabled = False
        Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpHasta.Location = New System.Drawing.Point(235, 165)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(94, 20)
        Me.dtpHasta.TabIndex = 5
        Me.dtpHasta.Value = New Date(2015, 9, 24, 0, 0, 0, 0)
        '
        'dtpDesde
        '
        Me.dtpDesde.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpDesde.Enabled = False
        Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDesde.Location = New System.Drawing.Point(91, 165)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(94, 20)
        Me.dtpDesde.TabIndex = 4
        Me.dtpDesde.Value = New Date(2015, 9, 24, 0, 0, 0, 0)
        '
        'optConcLiq
        '
        Me.optConcLiq.AutoSize = True
        Me.optConcLiq.Location = New System.Drawing.Point(45, 123)
        Me.optConcLiq.Name = "optConcLiq"
        Me.optConcLiq.Size = New System.Drawing.Size(126, 17)
        Me.optConcLiq.TabIndex = 2
        Me.optConcLiq.Text = "&Conceptos liquidados"
        Me.optConcLiq.UseVisualStyleBackColor = True
        '
        'frmListVarios
        '
        Me.AcceptButton = Me.cmdAceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(501, 269)
        Me.Controls.Add(Me.optConcLiq)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dtpHasta)
        Me.Controls.Add(Me.dtpDesde)
        Me.Controls.Add(Me.optConcCob)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Controls.Add(Me.optInqGar)
        Me.MaximizeBox = False
        Me.Name = "frmListVarios"
        Me.Text = "Listados"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents optInqGar As System.Windows.Forms.RadioButton
   Friend WithEvents cmdCancelar As System.Windows.Forms.Button
   Friend WithEvents cmdAceptar As System.Windows.Forms.Button
    Friend WithEvents optConcCob As RadioButton
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents dtpHasta As DateTimePicker
    Friend WithEvents dtpDesde As DateTimePicker
    Friend WithEvents optConcLiq As RadioButton
End Class
