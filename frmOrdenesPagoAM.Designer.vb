<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOrdenesPagoAM
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
      Me.cbProveedor = New System.Windows.Forms.ComboBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
      Me.DataGridView1 = New System.Windows.Forms.DataGridView()
      Me.cmdAgregar = New System.Windows.Forms.Button()
      Me.cmdQuitar = New System.Windows.Forms.Button()
      Me.tbDetalle = New System.Windows.Forms.TextBox()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.cmdGuardar = New System.Windows.Forms.Button()
      Me.cmdCancelar = New System.Windows.Forms.Button()
      Me.cmdAceptar = New System.Windows.Forms.Button()
      Me.tbTotal = New System.Windows.Forms.TextBox()
      Me.Label2 = New System.Windows.Forms.Label()
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'cbProveedor
      '
      Me.cbProveedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      Me.cbProveedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.cbProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbProveedor.FormattingEnabled = True
      Me.cbProveedor.Location = New System.Drawing.Point(78, 12)
      Me.cbProveedor.Name = "cbProveedor"
      Me.cbProveedor.Size = New System.Drawing.Size(401, 21)
      Me.cbProveedor.TabIndex = 94
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(12, 15)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(59, 13)
      Me.Label1.TabIndex = 95
      Me.Label1.Text = "Proveedor:"
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(506, 15)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(40, 13)
      Me.Label4.TabIndex = 101
      Me.Label4.Text = "Fecha:"
      '
      'dtpFecha
      '
      Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpFecha.Location = New System.Drawing.Point(552, 13)
      Me.dtpFecha.Name = "dtpFecha"
      Me.dtpFecha.Size = New System.Drawing.Size(81, 20)
      Me.dtpFecha.TabIndex = 100
      Me.dtpFecha.Value = New Date(2015, 9, 24, 0, 0, 0, 0)
      '
      'DataGridView1
      '
      Me.DataGridView1.AllowUserToAddRows = False
      Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
      Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.DataGridView1.Location = New System.Drawing.Point(12, 43)
      Me.DataGridView1.Name = "DataGridView1"
      Me.DataGridView1.ReadOnly = True
      Me.DataGridView1.RowTemplate.ReadOnly = True
      Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.DataGridView1.Size = New System.Drawing.Size(725, 366)
      Me.DataGridView1.TabIndex = 102
      '
      'cmdAgregar
      '
      Me.cmdAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdAgregar.Enabled = False
      Me.cmdAgregar.Location = New System.Drawing.Point(12, 416)
      Me.cmdAgregar.Name = "cmdAgregar"
      Me.cmdAgregar.Size = New System.Drawing.Size(76, 27)
      Me.cmdAgregar.TabIndex = 103
      Me.cmdAgregar.Text = "&Agregar"
      Me.cmdAgregar.UseVisualStyleBackColor = True
      '
      'cmdQuitar
      '
      Me.cmdQuitar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdQuitar.Enabled = False
      Me.cmdQuitar.Location = New System.Drawing.Point(94, 416)
      Me.cmdQuitar.Name = "cmdQuitar"
      Me.cmdQuitar.Size = New System.Drawing.Size(64, 27)
      Me.cmdQuitar.TabIndex = 104
      Me.cmdQuitar.Text = "&Quitar"
      Me.cmdQuitar.UseVisualStyleBackColor = True
      '
      'tbDetalle
      '
      Me.tbDetalle.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.tbDetalle.Enabled = False
      Me.tbDetalle.Location = New System.Drawing.Point(173, 415)
      Me.tbDetalle.Multiline = True
      Me.tbDetalle.Name = "tbDetalle"
      Me.tbDetalle.Size = New System.Drawing.Size(404, 59)
      Me.tbDetalle.TabIndex = 105
      '
      'Label5
      '
      Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.Label5.AutoSize = True
      Me.Label5.Location = New System.Drawing.Point(91, 457)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(76, 13)
      Me.Label5.TabIndex = 106
      Me.Label5.Text = "Detalle / Obs.:"
      '
      'cmdGuardar
      '
      Me.cmdGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdGuardar.Enabled = False
      Me.cmdGuardar.Location = New System.Drawing.Point(591, 447)
      Me.cmdGuardar.Name = "cmdGuardar"
      Me.cmdGuardar.Size = New System.Drawing.Size(76, 27)
      Me.cmdGuardar.TabIndex = 107
      Me.cmdGuardar.Text = "&Guardar"
      Me.cmdGuardar.UseVisualStyleBackColor = True
      '
      'cmdCancelar
      '
      Me.cmdCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdCancelar.Location = New System.Drawing.Point(673, 447)
      Me.cmdCancelar.Name = "cmdCancelar"
      Me.cmdCancelar.Size = New System.Drawing.Size(64, 27)
      Me.cmdCancelar.TabIndex = 108
      Me.cmdCancelar.Text = "&Cancelar"
      Me.cmdCancelar.UseVisualStyleBackColor = True
      '
      'cmdAceptar
      '
      Me.cmdAceptar.Location = New System.Drawing.Point(666, 10)
      Me.cmdAceptar.Name = "cmdAceptar"
      Me.cmdAceptar.Size = New System.Drawing.Size(71, 27)
      Me.cmdAceptar.TabIndex = 109
      Me.cmdAceptar.Text = "&Aceptar"
      Me.cmdAceptar.UseVisualStyleBackColor = True
      '
      'tbTotal
      '
      Me.tbTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tbTotal.Enabled = False
      Me.tbTotal.Location = New System.Drawing.Point(637, 415)
      Me.tbTotal.Name = "tbTotal"
      Me.tbTotal.Size = New System.Drawing.Size(100, 20)
      Me.tbTotal.TabIndex = 117
      '
      'Label2
      '
      Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(588, 419)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(40, 13)
      Me.Label2.TabIndex = 116
      Me.Label2.Text = "Total $"
      '
      'frmOrdenesPagoAM
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(744, 480)
      Me.Controls.Add(Me.tbTotal)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.cmdAceptar)
      Me.Controls.Add(Me.cmdGuardar)
      Me.Controls.Add(Me.cmdCancelar)
      Me.Controls.Add(Me.tbDetalle)
      Me.Controls.Add(Me.Label5)
      Me.Controls.Add(Me.cmdAgregar)
      Me.Controls.Add(Me.cmdQuitar)
      Me.Controls.Add(Me.DataGridView1)
      Me.Controls.Add(Me.Label4)
      Me.Controls.Add(Me.dtpFecha)
      Me.Controls.Add(Me.cbProveedor)
      Me.Controls.Add(Me.Label1)
      Me.KeyPreview = True
      Me.Name = "frmOrdenesPagoAM"
      Me.Text = "Orden de Pago"
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents cbProveedor As System.Windows.Forms.ComboBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
   Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
   Friend WithEvents cmdAgregar As System.Windows.Forms.Button
   Friend WithEvents cmdQuitar As System.Windows.Forms.Button
   Friend WithEvents tbDetalle As System.Windows.Forms.TextBox
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents cmdGuardar As System.Windows.Forms.Button
   Friend WithEvents cmdCancelar As System.Windows.Forms.Button
   Friend WithEvents cmdAceptar As System.Windows.Forms.Button
   Friend WithEvents tbTotal As System.Windows.Forms.TextBox
   Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
