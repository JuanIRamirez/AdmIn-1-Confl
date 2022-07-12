<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListTransf
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
      Me.cmdCancelar = New System.Windows.Forms.Button()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.optProp = New System.Windows.Forms.RadioButton()
      Me.optInq = New System.Windows.Forms.RadioButton()
      Me.dtpPeriodo = New System.Windows.Forms.DateTimePicker()
      Me.Label18 = New System.Windows.Forms.Label()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.dtpHasta = New System.Windows.Forms.DateTimePicker()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.dtpDesde = New System.Windows.Forms.DateTimePicker()
      Me.SuspendLayout()
      '
      'cmdAceptar
      '
      Me.cmdAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdAceptar.Location = New System.Drawing.Point(338, 284)
      Me.cmdAceptar.Name = "cmdAceptar"
      Me.cmdAceptar.Size = New System.Drawing.Size(75, 23)
      Me.cmdAceptar.TabIndex = 102
      Me.cmdAceptar.Text = "&Aceptar"
      Me.cmdAceptar.UseVisualStyleBackColor = True
      '
      'cmdCancelar
      '
      Me.cmdCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.cmdCancelar.Location = New System.Drawing.Point(419, 284)
      Me.cmdCancelar.Name = "cmdCancelar"
      Me.cmdCancelar.Size = New System.Drawing.Size(75, 23)
      Me.cmdCancelar.TabIndex = 103
      Me.cmdCancelar.Text = "&Cancelar"
      Me.cmdCancelar.UseVisualStyleBackColor = True
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(69, 181)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(31, 13)
      Me.Label2.TabIndex = 101
      Me.Label2.Text = "Tipo:"
      '
      'optProp
      '
      Me.optProp.AutoSize = True
      Me.optProp.Location = New System.Drawing.Point(239, 179)
      Me.optProp.Name = "optProp"
      Me.optProp.Size = New System.Drawing.Size(89, 17)
      Me.optProp.TabIndex = 100
      Me.optProp.Text = "a &Propietarios"
      Me.optProp.UseVisualStyleBackColor = True
      '
      'optInq
      '
      Me.optInq.AutoSize = True
      Me.optInq.Checked = True
      Me.optInq.Location = New System.Drawing.Point(125, 179)
      Me.optInq.Name = "optInq"
      Me.optInq.Size = New System.Drawing.Size(84, 17)
      Me.optInq.TabIndex = 99
      Me.optInq.TabStop = True
      Me.optInq.Text = "de &Inquilinos"
      Me.optInq.UseVisualStyleBackColor = True
      '
      'dtpPeriodo
      '
      Me.dtpPeriodo.CustomFormat = "MM/yyyy"
      Me.dtpPeriodo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpPeriodo.Location = New System.Drawing.Point(123, 74)
      Me.dtpPeriodo.Name = "dtpPeriodo"
      Me.dtpPeriodo.Size = New System.Drawing.Size(86, 20)
      Me.dtpPeriodo.TabIndex = 97
      '
      'Label18
      '
      Me.Label18.AutoSize = True
      Me.Label18.Location = New System.Drawing.Point(63, 77)
      Me.Label18.Name = "Label18"
      Me.Label18.Size = New System.Drawing.Size(48, 13)
      Me.Label18.TabIndex = 98
      Me.Label18.Text = "Período:"
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(236, 130)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(38, 13)
      Me.Label1.TabIndex = 107
      Me.Label1.Text = "Hasta:"
      '
      'dtpHasta
      '
      Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpHasta.Location = New System.Drawing.Point(280, 127)
      Me.dtpHasta.Name = "dtpHasta"
      Me.dtpHasta.Size = New System.Drawing.Size(94, 20)
      Me.dtpHasta.TabIndex = 105
      Me.dtpHasta.Value = New Date(2015, 9, 24, 0, 0, 0, 0)
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(69, 130)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(41, 13)
      Me.Label4.TabIndex = 106
      Me.Label4.Text = "Desde:"
      '
      'dtpDesde
      '
      Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDesde.Location = New System.Drawing.Point(115, 127)
      Me.dtpDesde.Name = "dtpDesde"
      Me.dtpDesde.Size = New System.Drawing.Size(94, 20)
      Me.dtpDesde.TabIndex = 104
      Me.dtpDesde.Value = New Date(2015, 9, 24, 0, 0, 0, 0)
      '
      'frmListTransf
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(506, 319)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.dtpHasta)
      Me.Controls.Add(Me.Label4)
      Me.Controls.Add(Me.dtpDesde)
      Me.Controls.Add(Me.cmdAceptar)
      Me.Controls.Add(Me.cmdCancelar)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.optProp)
      Me.Controls.Add(Me.optInq)
      Me.Controls.Add(Me.dtpPeriodo)
      Me.Controls.Add(Me.Label18)
      Me.Name = "frmListTransf"
      Me.Text = "Listado de Transferencias"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents cmdAceptar As System.Windows.Forms.Button
   Friend WithEvents cmdCancelar As System.Windows.Forms.Button
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents optProp As System.Windows.Forms.RadioButton
   Friend WithEvents optInq As System.Windows.Forms.RadioButton
   Friend WithEvents dtpPeriodo As System.Windows.Forms.DateTimePicker
   Friend WithEvents Label18 As System.Windows.Forms.Label
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents dtpHasta As System.Windows.Forms.DateTimePicker
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents dtpDesde As System.Windows.Forms.DateTimePicker
End Class
