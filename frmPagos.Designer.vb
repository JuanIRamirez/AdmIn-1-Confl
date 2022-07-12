<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPagos
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
      Me.cbCaja = New System.Windows.Forms.ComboBox()
      Me.Label8 = New System.Windows.Forms.Label()
      Me.cmdAceptar = New System.Windows.Forms.Button()
      Me.cmdQuitar = New System.Windows.Forms.Button()
      Me.cmdGenerar = New System.Windows.Forms.Button()
      Me.cbProveedor = New System.Windows.Forms.ComboBox()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.SuspendLayout()
      '
      'cbCaja
      '
      Me.cbCaja.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      Me.cbCaja.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.cbCaja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbCaja.FormattingEnabled = True
      Me.cbCaja.Location = New System.Drawing.Point(49, 12)
      Me.cbCaja.Name = "cbCaja"
      Me.cbCaja.Size = New System.Drawing.Size(194, 21)
      Me.cbCaja.TabIndex = 166
      '
      'Label8
      '
      Me.Label8.AutoSize = True
      Me.Label8.Location = New System.Drawing.Point(12, 15)
      Me.Label8.Name = "Label8"
      Me.Label8.Size = New System.Drawing.Size(31, 13)
      Me.Label8.TabIndex = 167
      Me.Label8.Text = "Caja:"
      '
      'cmdAceptar
      '
      Me.cmdAceptar.Location = New System.Drawing.Point(474, 252)
      Me.cmdAceptar.Name = "cmdAceptar"
      Me.cmdAceptar.Size = New System.Drawing.Size(75, 23)
      Me.cmdAceptar.TabIndex = 168
      Me.cmdAceptar.Text = "&Aceptar"
      Me.cmdAceptar.UseVisualStyleBackColor = True
      '
      'cmdQuitar
      '
      Me.cmdQuitar.Location = New System.Drawing.Point(474, 327)
      Me.cmdQuitar.Name = "cmdQuitar"
      Me.cmdQuitar.Size = New System.Drawing.Size(75, 23)
      Me.cmdQuitar.TabIndex = 169
      Me.cmdQuitar.Text = "&Quitar"
      Me.cmdQuitar.UseVisualStyleBackColor = True
      '
      'cmdGenerar
      '
      Me.cmdGenerar.Location = New System.Drawing.Point(474, 400)
      Me.cmdGenerar.Name = "cmdGenerar"
      Me.cmdGenerar.Size = New System.Drawing.Size(75, 23)
      Me.cmdGenerar.TabIndex = 170
      Me.cmdGenerar.Text = "&Generar"
      Me.cmdGenerar.UseVisualStyleBackColor = True
      '
      'cbProveedor
      '
      Me.cbProveedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      Me.cbProveedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.cbProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbProveedor.FormattingEnabled = True
      Me.cbProveedor.Location = New System.Drawing.Point(74, 50)
      Me.cbProveedor.Name = "cbProveedor"
      Me.cbProveedor.Size = New System.Drawing.Size(430, 21)
      Me.cbProveedor.TabIndex = 171
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.Location = New System.Drawing.Point(13, 54)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(59, 13)
      Me.Label5.TabIndex = 172
      Me.Label5.Text = "Proveedor:"
      '
      'dtpFecha
      '
      Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpFecha.Location = New System.Drawing.Point(413, 12)
      Me.dtpFecha.Name = "dtpFecha"
      Me.dtpFecha.Size = New System.Drawing.Size(91, 20)
      Me.dtpFecha.TabIndex = 173
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(367, 15)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(40, 13)
      Me.Label1.TabIndex = 174
      Me.Label1.Text = "Fecha:"
      '
      'frmPagos
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(721, 496)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.dtpFecha)
      Me.Controls.Add(Me.cbProveedor)
      Me.Controls.Add(Me.Label5)
      Me.Controls.Add(Me.cmdGenerar)
      Me.Controls.Add(Me.cmdQuitar)
      Me.Controls.Add(Me.cmdAceptar)
      Me.Controls.Add(Me.cbCaja)
      Me.Controls.Add(Me.Label8)
      Me.Name = "frmPagos"
      Me.Text = "frmPagos"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents cbCaja As System.Windows.Forms.ComboBox
   Friend WithEvents Label8 As System.Windows.Forms.Label
   Friend WithEvents cmdAceptar As System.Windows.Forms.Button
   Friend WithEvents cmdQuitar As System.Windows.Forms.Button
   Friend WithEvents cmdGenerar As System.Windows.Forms.Button
   Friend WithEvents cbProveedor As System.Windows.Forms.ComboBox
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
   Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
