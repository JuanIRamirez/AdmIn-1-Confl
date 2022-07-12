<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRendPropPend
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
      Me.cbPropietario = New System.Windows.Forms.ComboBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.chkResumen = New System.Windows.Forms.CheckBox()
      Me.cmdAceptar = New System.Windows.Forms.Button()
      Me.cmdCancelar = New System.Windows.Forms.Button()
      Me.optActivos = New System.Windows.Forms.RadioButton()
      Me.optInactivos = New System.Windows.Forms.RadioButton()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.dtpHasta = New System.Windows.Forms.DateTimePicker()
      Me.Label18 = New System.Windows.Forms.Label()
      Me.SuspendLayout()
      '
      'cbPropietario
      '
      Me.cbPropietario.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      Me.cbPropietario.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.cbPropietario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbPropietario.FormattingEnabled = True
      Me.cbPropietario.Location = New System.Drawing.Point(96, 71)
      Me.cbPropietario.Name = "cbPropietario"
      Me.cbPropietario.Size = New System.Drawing.Size(433, 21)
      Me.cbPropietario.TabIndex = 71
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(30, 74)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(60, 13)
      Me.Label1.TabIndex = 72
      Me.Label1.Text = "Propietario:"
      '
      'chkResumen
      '
      Me.chkResumen.AutoSize = True
      Me.chkResumen.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.chkResumen.Location = New System.Drawing.Point(39, 121)
      Me.chkResumen.Name = "chkResumen"
      Me.chkResumen.Size = New System.Drawing.Size(71, 17)
      Me.chkResumen.TabIndex = 73
      Me.chkResumen.Text = "&Resumen"
      Me.chkResumen.UseVisualStyleBackColor = True
      '
      'cmdAceptar
      '
      Me.cmdAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdAceptar.Location = New System.Drawing.Point(373, 176)
      Me.cmdAceptar.Name = "cmdAceptar"
      Me.cmdAceptar.Size = New System.Drawing.Size(75, 23)
      Me.cmdAceptar.TabIndex = 74
      Me.cmdAceptar.Text = "&Aceptar"
      Me.cmdAceptar.UseVisualStyleBackColor = True
      '
      'cmdCancelar
      '
      Me.cmdCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.cmdCancelar.Location = New System.Drawing.Point(454, 176)
      Me.cmdCancelar.Name = "cmdCancelar"
      Me.cmdCancelar.Size = New System.Drawing.Size(75, 23)
      Me.cmdCancelar.TabIndex = 75
      Me.cmdCancelar.Text = "&Cancelar"
      Me.cmdCancelar.UseVisualStyleBackColor = True
      '
      'optActivos
      '
      Me.optActivos.AutoSize = True
      Me.optActivos.Checked = True
      Me.optActivos.Location = New System.Drawing.Point(96, 28)
      Me.optActivos.Name = "optActivos"
      Me.optActivos.Size = New System.Drawing.Size(60, 17)
      Me.optActivos.TabIndex = 76
      Me.optActivos.TabStop = True
      Me.optActivos.Text = "&Activos"
      Me.optActivos.UseVisualStyleBackColor = True
      '
      'optInactivos
      '
      Me.optInactivos.AutoSize = True
      Me.optInactivos.Location = New System.Drawing.Point(162, 28)
      Me.optInactivos.Name = "optInactivos"
      Me.optInactivos.Size = New System.Drawing.Size(68, 17)
      Me.optInactivos.TabIndex = 77
      Me.optInactivos.Text = "&Inactivos"
      Me.optInactivos.UseVisualStyleBackColor = True
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(30, 30)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(43, 13)
      Me.Label2.TabIndex = 78
      Me.Label2.Text = "Estado:"
      '
      'dtpHasta
      '
      Me.dtpHasta.CustomFormat = "MM/yyyy"
      Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpHasta.Location = New System.Drawing.Point(96, 166)
      Me.dtpHasta.Name = "dtpHasta"
      Me.dtpHasta.Size = New System.Drawing.Size(68, 20)
      Me.dtpHasta.TabIndex = 92
      '
      'Label18
      '
      Me.Label18.AutoSize = True
      Me.Label18.Location = New System.Drawing.Point(52, 168)
      Me.Label18.Name = "Label18"
      Me.Label18.Size = New System.Drawing.Size(38, 13)
      Me.Label18.TabIndex = 93
      Me.Label18.Text = "Hasta:"
      '
      'frmRendPropPend
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(564, 227)
      Me.Controls.Add(Me.dtpHasta)
      Me.Controls.Add(Me.Label18)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.optInactivos)
      Me.Controls.Add(Me.optActivos)
      Me.Controls.Add(Me.cmdAceptar)
      Me.Controls.Add(Me.cmdCancelar)
      Me.Controls.Add(Me.chkResumen)
      Me.Controls.Add(Me.cbPropietario)
      Me.Controls.Add(Me.Label1)
      Me.MaximizeBox = False
      Me.Name = "frmRendPropPend"
      Me.Text = "Rendiciones a Propietario Pendientes"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents cbPropietario As System.Windows.Forms.ComboBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents chkResumen As System.Windows.Forms.CheckBox
   Friend WithEvents cmdAceptar As System.Windows.Forms.Button
   Friend WithEvents cmdCancelar As System.Windows.Forms.Button
   Friend WithEvents optActivos As System.Windows.Forms.RadioButton
   Friend WithEvents optInactivos As System.Windows.Forms.RadioButton
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents dtpHasta As System.Windows.Forms.DateTimePicker
   Friend WithEvents Label18 As System.Windows.Forms.Label
End Class
