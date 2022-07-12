<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOrdenPagoConf
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
      Me.Label4 = New System.Windows.Forms.Label()
      Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.tbTotal = New System.Windows.Forms.TextBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.tbDetalle = New System.Windows.Forms.TextBox()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.DataGridView1 = New System.Windows.Forms.DataGridView()
      Me.tbRecibe = New System.Windows.Forms.TextBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.cboCaja = New System.Windows.Forms.ComboBox()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.tbComprob = New System.Windows.Forms.TextBox()
      Me.Label7 = New System.Windows.Forms.Label()
      Me.tbTransf = New System.Windows.Forms.TextBox()
      Me.tbCheques = New System.Windows.Forms.TextBox()
      Me.Label8 = New System.Windows.Forms.Label()
      Me.cmdIngCheques = New System.Windows.Forms.Button()
      Me.cmdTransferencia = New System.Windows.Forms.Button()
      Me.tbEfectivo = New System.Windows.Forms.TextBox()
      Me.cmdConfirmar = New System.Windows.Forms.Button()
      Me.cmdCancelar = New System.Windows.Forms.Button()
      Me.tbProveedor = New System.Windows.Forms.TextBox()
      Me.tbNumero = New System.Windows.Forms.TextBox()
      Me.Label9 = New System.Windows.Forms.Label()
      Me.tbDiferencia = New System.Windows.Forms.TextBox()
      Me.Label10 = New System.Windows.Forms.Label()
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(502, 15)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(59, 13)
      Me.Label4.TabIndex = 105
      Me.Label4.Text = "Fec. Pago:"
      '
      'dtpFecha
      '
      Me.dtpFecha.Enabled = False
      Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpFecha.Location = New System.Drawing.Point(567, 12)
      Me.dtpFecha.Name = "dtpFecha"
      Me.dtpFecha.Size = New System.Drawing.Size(81, 20)
      Me.dtpFecha.TabIndex = 104
      Me.dtpFecha.Value = New Date(2015, 9, 24, 0, 0, 0, 0)
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(8, 15)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(59, 13)
      Me.Label1.TabIndex = 103
      Me.Label1.Text = "Proveedor:"
      '
      'tbTotal
      '
      Me.tbTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tbTotal.BackColor = System.Drawing.Color.LightGoldenrodYellow
      Me.tbTotal.Enabled = False
      Me.tbTotal.Location = New System.Drawing.Point(698, 373)
      Me.tbTotal.Name = "tbTotal"
      Me.tbTotal.Size = New System.Drawing.Size(85, 20)
      Me.tbTotal.TabIndex = 121
      '
      'Label2
      '
      Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(651, 377)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(40, 13)
      Me.Label2.TabIndex = 120
      Me.Label2.Text = "Total $"
      '
      'tbDetalle
      '
      Me.tbDetalle.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.tbDetalle.Location = New System.Drawing.Point(90, 374)
      Me.tbDetalle.Multiline = True
      Me.tbDetalle.Name = "tbDetalle"
      Me.tbDetalle.Size = New System.Drawing.Size(428, 78)
      Me.tbDetalle.TabIndex = 118
      '
      'Label5
      '
      Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.Label5.AutoSize = True
      Me.Label5.Location = New System.Drawing.Point(8, 377)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(76, 13)
      Me.Label5.TabIndex = 119
      Me.Label5.Text = "Detalle / Obs.:"
      '
      'DataGridView1
      '
      Me.DataGridView1.AllowUserToAddRows = False
      Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
      Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.DataGridView1.Location = New System.Drawing.Point(11, 42)
      Me.DataGridView1.Name = "DataGridView1"
      Me.DataGridView1.ReadOnly = True
      Me.DataGridView1.RowTemplate.ReadOnly = True
      Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.DataGridView1.Size = New System.Drawing.Size(772, 325)
      Me.DataGridView1.TabIndex = 122
      '
      'tbRecibe
      '
      Me.tbRecibe.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tbRecibe.Location = New System.Drawing.Point(608, 399)
      Me.tbRecibe.Name = "tbRecibe"
      Me.tbRecibe.Size = New System.Drawing.Size(176, 20)
      Me.tbRecibe.TabIndex = 124
      '
      'Label3
      '
      Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(558, 402)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(44, 13)
      Me.Label3.TabIndex = 123
      Me.Label3.Text = "Recibe:"
      '
      'cboCaja
      '
      Me.cboCaja.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cboCaja.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      Me.cboCaja.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.cboCaja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboCaja.FormattingEnabled = True
      Me.cboCaja.Location = New System.Drawing.Point(608, 427)
      Me.cboCaja.Name = "cboCaja"
      Me.cboCaja.Size = New System.Drawing.Size(175, 21)
      Me.cboCaja.TabIndex = 125
      '
      'Label6
      '
      Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label6.AutoSize = True
      Me.Label6.Location = New System.Drawing.Point(571, 430)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(31, 13)
      Me.Label6.TabIndex = 126
      Me.Label6.Text = "Caja:"
      '
      'tbComprob
      '
      Me.tbComprob.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tbComprob.BackColor = System.Drawing.Color.LightGoldenrodYellow
      Me.tbComprob.Enabled = False
      Me.tbComprob.Location = New System.Drawing.Point(569, 374)
      Me.tbComprob.Name = "tbComprob"
      Me.tbComprob.Size = New System.Drawing.Size(73, 20)
      Me.tbComprob.TabIndex = 128
      '
      'Label7
      '
      Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label7.AutoSize = True
      Me.Label7.Location = New System.Drawing.Point(528, 377)
      Me.Label7.Name = "Label7"
      Me.Label7.Size = New System.Drawing.Size(35, 13)
      Me.Label7.TabIndex = 127
      Me.Label7.Text = "Cpte.:"
      '
      'tbTransf
      '
      Me.tbTransf.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.tbTransf.BackColor = System.Drawing.Color.LightGoldenrodYellow
      Me.tbTransf.Enabled = False
      Me.tbTransf.Location = New System.Drawing.Point(416, 461)
      Me.tbTransf.Name = "tbTransf"
      Me.tbTransf.Size = New System.Drawing.Size(86, 20)
      Me.tbTransf.TabIndex = 133
      '
      'tbCheques
      '
      Me.tbCheques.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.tbCheques.BackColor = System.Drawing.Color.LightGoldenrodYellow
      Me.tbCheques.Enabled = False
      Me.tbCheques.Location = New System.Drawing.Point(230, 462)
      Me.tbCheques.Name = "tbCheques"
      Me.tbCheques.Size = New System.Drawing.Size(86, 20)
      Me.tbCheques.TabIndex = 131
      '
      'Label8
      '
      Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.Label8.AutoSize = True
      Me.Label8.Location = New System.Drawing.Point(12, 465)
      Me.Label8.Name = "Label8"
      Me.Label8.Size = New System.Drawing.Size(55, 13)
      Me.Label8.TabIndex = 134
      Me.Label8.Text = "Efectivo $"
      '
      'cmdIngCheques
      '
      Me.cmdIngCheques.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdIngCheques.Location = New System.Drawing.Point(165, 461)
      Me.cmdIngCheques.Name = "cmdIngCheques"
      Me.cmdIngCheques.Size = New System.Drawing.Size(59, 25)
      Me.cmdIngCheques.TabIndex = 130
      Me.cmdIngCheques.Text = "Che&ques"
      Me.cmdIngCheques.UseVisualStyleBackColor = True
      '
      'cmdTransferencia
      '
      Me.cmdTransferencia.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdTransferencia.Location = New System.Drawing.Point(322, 461)
      Me.cmdTransferencia.Name = "cmdTransferencia"
      Me.cmdTransferencia.Size = New System.Drawing.Size(88, 24)
      Me.cmdTransferencia.TabIndex = 132
      Me.cmdTransferencia.Text = "&Transferencia"
      Me.cmdTransferencia.UseVisualStyleBackColor = True
      '
      'tbEfectivo
      '
      Me.tbEfectivo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.tbEfectivo.Location = New System.Drawing.Point(73, 461)
      Me.tbEfectivo.Name = "tbEfectivo"
      Me.tbEfectivo.Size = New System.Drawing.Size(86, 20)
      Me.tbEfectivo.TabIndex = 129
      '
      'cmdConfirmar
      '
      Me.cmdConfirmar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdConfirmar.Location = New System.Drawing.Point(627, 459)
      Me.cmdConfirmar.Name = "cmdConfirmar"
      Me.cmdConfirmar.Size = New System.Drawing.Size(88, 25)
      Me.cmdConfirmar.TabIndex = 135
      Me.cmdConfirmar.Text = "&Confirmar"
      Me.cmdConfirmar.UseVisualStyleBackColor = True
      '
      'cmdCancelar
      '
      Me.cmdCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdCancelar.Location = New System.Drawing.Point(721, 459)
      Me.cmdCancelar.Name = "cmdCancelar"
      Me.cmdCancelar.Size = New System.Drawing.Size(64, 25)
      Me.cmdCancelar.TabIndex = 136
      Me.cmdCancelar.Text = "&Cancelar"
      Me.cmdCancelar.UseVisualStyleBackColor = True
      '
      'tbProveedor
      '
      Me.tbProveedor.BackColor = System.Drawing.Color.LightGoldenrodYellow
      Me.tbProveedor.Enabled = False
      Me.tbProveedor.Location = New System.Drawing.Point(73, 12)
      Me.tbProveedor.Name = "tbProveedor"
      Me.tbProveedor.Size = New System.Drawing.Size(423, 20)
      Me.tbProveedor.TabIndex = 137
      '
      'tbNumero
      '
      Me.tbNumero.BackColor = System.Drawing.Color.LightGoldenrodYellow
      Me.tbNumero.Enabled = False
      Me.tbNumero.Location = New System.Drawing.Point(706, 12)
      Me.tbNumero.Name = "tbNumero"
      Me.tbNumero.Size = New System.Drawing.Size(73, 20)
      Me.tbNumero.TabIndex = 139
      '
      'Label9
      '
      Me.Label9.AutoSize = True
      Me.Label9.Location = New System.Drawing.Point(665, 15)
      Me.Label9.Name = "Label9"
      Me.Label9.Size = New System.Drawing.Size(40, 13)
      Me.Label9.TabIndex = 138
      Me.Label9.Text = "Nº OP:"
      '
      'tbDiferencia
      '
      Me.tbDiferencia.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.tbDiferencia.BackColor = System.Drawing.Color.LightGoldenrodYellow
      Me.tbDiferencia.Enabled = False
      Me.tbDiferencia.Location = New System.Drawing.Point(543, 462)
      Me.tbDiferencia.Name = "tbDiferencia"
      Me.tbDiferencia.Size = New System.Drawing.Size(73, 20)
      Me.tbDiferencia.TabIndex = 141
      '
      'Label10
      '
      Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.Label10.AutoSize = True
      Me.Label10.Location = New System.Drawing.Point(508, 465)
      Me.Label10.Name = "Label10"
      Me.Label10.Size = New System.Drawing.Size(29, 13)
      Me.Label10.TabIndex = 140
      Me.Label10.Text = "Dif.$"
      '
      'frmOrdenPagoConf
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(794, 490)
      Me.Controls.Add(Me.tbDiferencia)
      Me.Controls.Add(Me.Label10)
      Me.Controls.Add(Me.tbNumero)
      Me.Controls.Add(Me.Label9)
      Me.Controls.Add(Me.tbProveedor)
      Me.Controls.Add(Me.cmdConfirmar)
      Me.Controls.Add(Me.cmdCancelar)
      Me.Controls.Add(Me.tbTransf)
      Me.Controls.Add(Me.tbCheques)
      Me.Controls.Add(Me.Label8)
      Me.Controls.Add(Me.cmdIngCheques)
      Me.Controls.Add(Me.cmdTransferencia)
      Me.Controls.Add(Me.tbEfectivo)
      Me.Controls.Add(Me.tbComprob)
      Me.Controls.Add(Me.Label7)
      Me.Controls.Add(Me.cboCaja)
      Me.Controls.Add(Me.Label6)
      Me.Controls.Add(Me.tbRecibe)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.DataGridView1)
      Me.Controls.Add(Me.tbTotal)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.tbDetalle)
      Me.Controls.Add(Me.Label5)
      Me.Controls.Add(Me.Label4)
      Me.Controls.Add(Me.dtpFecha)
      Me.Controls.Add(Me.Label1)
      Me.KeyPreview = True
      Me.Name = "frmOrdenPagoConf"
      Me.Text = "Orden de Pago: Confirmar"
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents tbTotal As System.Windows.Forms.TextBox
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents tbDetalle As System.Windows.Forms.TextBox
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
   Friend WithEvents tbRecibe As System.Windows.Forms.TextBox
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents cboCaja As System.Windows.Forms.ComboBox
   Friend WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents tbComprob As System.Windows.Forms.TextBox
   Friend WithEvents Label7 As System.Windows.Forms.Label
   Friend WithEvents tbTransf As System.Windows.Forms.TextBox
   Friend WithEvents tbCheques As System.Windows.Forms.TextBox
   Friend WithEvents Label8 As System.Windows.Forms.Label
   Friend WithEvents cmdIngCheques As System.Windows.Forms.Button
   Friend WithEvents cmdTransferencia As System.Windows.Forms.Button
   Friend WithEvents tbEfectivo As System.Windows.Forms.TextBox
   Friend WithEvents cmdConfirmar As System.Windows.Forms.Button
   Friend WithEvents cmdCancelar As System.Windows.Forms.Button
   Friend WithEvents tbProveedor As System.Windows.Forms.TextBox
   Friend WithEvents tbNumero As System.Windows.Forms.TextBox
   Friend WithEvents Label9 As System.Windows.Forms.Label
   Friend WithEvents tbDiferencia As System.Windows.Forms.TextBox
   Friend WithEvents Label10 As System.Windows.Forms.Label
End Class
