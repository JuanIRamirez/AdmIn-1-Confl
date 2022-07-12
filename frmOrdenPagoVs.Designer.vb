<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOrdenPagoVs
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
      Me.Label2 = New System.Windows.Forms.Label()
      Me.DataGridView1 = New System.Windows.Forms.DataGridView()
      Me.cmdQuitar = New System.Windows.Forms.Button()
      Me.cmdAgregar = New System.Windows.Forms.Button()
      Me.tbNumero = New System.Windows.Forms.TextBox()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
      Me.tbTotal = New System.Windows.Forms.TextBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.tbDetalle = New System.Windows.Forms.TextBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.cmdCheques = New System.Windows.Forms.Button()
      Me.tbCheques = New System.Windows.Forms.TextBox()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.tbEfectivo = New System.Windows.Forms.TextBox()
      Me.Label7 = New System.Windows.Forms.Label()
      Me.tbRecibe = New System.Windows.Forms.TextBox()
      Me.Label8 = New System.Windows.Forms.Label()
      Me.cmdConfirmar = New System.Windows.Forms.Button()
      Me.cmdCancelar = New System.Windows.Forms.Button()
      Me.cbCaja = New System.Windows.Forms.ComboBox()
      Me.Label9 = New System.Windows.Forms.Label()
      Me.tbComprob = New System.Windows.Forms.TextBox()
      Me.Label10 = New System.Windows.Forms.Label()
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'cbProveedor
      '
      Me.cbProveedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      Me.cbProveedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.cbProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbProveedor.FormattingEnabled = True
      Me.cbProveedor.Location = New System.Drawing.Point(77, 15)
      Me.cbProveedor.Name = "cbProveedor"
      Me.cbProveedor.Size = New System.Drawing.Size(385, 21)
      Me.cbProveedor.TabIndex = 108
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(12, 18)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(59, 13)
      Me.Label2.TabIndex = 109
      Me.Label2.Text = "Proveedor:"
      '
      'DataGridView1
      '
      Me.DataGridView1.AllowUserToAddRows = False
      Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
      Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.DataGridView1.Location = New System.Drawing.Point(12, 42)
      Me.DataGridView1.Name = "DataGridView1"
      Me.DataGridView1.ReadOnly = True
      Me.DataGridView1.RowTemplate.ReadOnly = True
      Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.DataGridView1.Size = New System.Drawing.Size(706, 345)
      Me.DataGridView1.TabIndex = 111
      '
      'cmdQuitar
      '
      Me.cmdQuitar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdQuitar.Enabled = False
      Me.cmdQuitar.Location = New System.Drawing.Point(93, 393)
      Me.cmdQuitar.Name = "cmdQuitar"
      Me.cmdQuitar.Size = New System.Drawing.Size(75, 25)
      Me.cmdQuitar.TabIndex = 127
      Me.cmdQuitar.Text = "&Quitar"
      Me.cmdQuitar.UseVisualStyleBackColor = True
      '
      'cmdAgregar
      '
      Me.cmdAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdAgregar.Location = New System.Drawing.Point(12, 393)
      Me.cmdAgregar.Name = "cmdAgregar"
      Me.cmdAgregar.Size = New System.Drawing.Size(75, 25)
      Me.cmdAgregar.TabIndex = 126
      Me.cmdAgregar.Text = "&Agregar"
      Me.cmdAgregar.UseVisualStyleBackColor = True
      '
      'tbNumero
      '
      Me.tbNumero.BackColor = System.Drawing.Color.LightYellow
      Me.tbNumero.Enabled = False
      Me.tbNumero.Location = New System.Drawing.Point(645, 15)
      Me.tbNumero.MaxLength = 10
      Me.tbNumero.Name = "tbNumero"
      Me.tbNumero.Size = New System.Drawing.Size(73, 20)
      Me.tbNumero.TabIndex = 130
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.Location = New System.Drawing.Point(620, 19)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(19, 13)
      Me.Label5.TabIndex = 129
      Me.Label5.Text = "Nº"
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(468, 18)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(59, 13)
      Me.Label4.TabIndex = 132
      Me.Label4.Text = "Fec. Pago:"
      '
      'dtpFecha
      '
      Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpFecha.Location = New System.Drawing.Point(533, 15)
      Me.dtpFecha.Name = "dtpFecha"
      Me.dtpFecha.Size = New System.Drawing.Size(81, 20)
      Me.dtpFecha.TabIndex = 131
      Me.dtpFecha.Value = New Date(2015, 9, 24, 0, 0, 0, 0)
      '
      'tbTotal
      '
      Me.tbTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tbTotal.BackColor = System.Drawing.Color.LightGoldenrodYellow
      Me.tbTotal.Enabled = False
      Me.tbTotal.Location = New System.Drawing.Point(630, 393)
      Me.tbTotal.Name = "tbTotal"
      Me.tbTotal.Size = New System.Drawing.Size(88, 20)
      Me.tbTotal.TabIndex = 173
      '
      'Label1
      '
      Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(584, 396)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(40, 13)
      Me.Label1.TabIndex = 172
      Me.Label1.Text = "Total $"
      '
      'tbDetalle
      '
      Me.tbDetalle.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.tbDetalle.Enabled = False
      Me.tbDetalle.Location = New System.Drawing.Point(94, 424)
      Me.tbDetalle.Multiline = True
      Me.tbDetalle.Name = "tbDetalle"
      Me.tbDetalle.Size = New System.Drawing.Size(406, 70)
      Me.tbDetalle.TabIndex = 170
      '
      'Label3
      '
      Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(12, 444)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(76, 13)
      Me.Label3.TabIndex = 171
      Me.Label3.Text = "Detalle / Obs.:"
      '
      'cmdCheques
      '
      Me.cmdCheques.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdCheques.Location = New System.Drawing.Point(191, 503)
      Me.cmdCheques.Name = "cmdCheques"
      Me.cmdCheques.Size = New System.Drawing.Size(58, 24)
      Me.cmdCheques.TabIndex = 178
      Me.cmdCheques.Text = "Che&ques"
      Me.cmdCheques.UseVisualStyleBackColor = True
      '
      'tbCheques
      '
      Me.tbCheques.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tbCheques.BackColor = System.Drawing.Color.LightGoldenrodYellow
      Me.tbCheques.Enabled = False
      Me.tbCheques.Location = New System.Drawing.Point(266, 505)
      Me.tbCheques.Name = "tbCheques"
      Me.tbCheques.Size = New System.Drawing.Size(80, 20)
      Me.tbCheques.TabIndex = 177
      '
      'Label6
      '
      Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label6.AutoSize = True
      Me.Label6.Location = New System.Drawing.Point(250, 508)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(13, 13)
      Me.Label6.TabIndex = 176
      Me.Label6.Text = "$"
      '
      'tbEfectivo
      '
      Me.tbEfectivo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tbEfectivo.BackColor = System.Drawing.SystemColors.Window
      Me.tbEfectivo.Location = New System.Drawing.Point(94, 505)
      Me.tbEfectivo.Name = "tbEfectivo"
      Me.tbEfectivo.Size = New System.Drawing.Size(85, 20)
      Me.tbEfectivo.TabIndex = 175
      '
      'Label7
      '
      Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label7.AutoSize = True
      Me.Label7.Location = New System.Drawing.Point(32, 508)
      Me.Label7.Name = "Label7"
      Me.Label7.Size = New System.Drawing.Size(55, 13)
      Me.Label7.TabIndex = 174
      Me.Label7.Text = "Efectivo $"
      '
      'tbRecibe
      '
      Me.tbRecibe.Location = New System.Drawing.Point(556, 424)
      Me.tbRecibe.MaxLength = 10
      Me.tbRecibe.Name = "tbRecibe"
      Me.tbRecibe.Size = New System.Drawing.Size(162, 20)
      Me.tbRecibe.TabIndex = 180
      '
      'Label8
      '
      Me.Label8.AutoSize = True
      Me.Label8.Location = New System.Drawing.Point(506, 427)
      Me.Label8.Name = "Label8"
      Me.Label8.Size = New System.Drawing.Size(44, 13)
      Me.Label8.TabIndex = 179
      Me.Label8.Text = "Recibe:"
      '
      'cmdConfirmar
      '
      Me.cmdConfirmar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdConfirmar.Location = New System.Drawing.Point(560, 506)
      Me.cmdConfirmar.Name = "cmdConfirmar"
      Me.cmdConfirmar.Size = New System.Drawing.Size(88, 25)
      Me.cmdConfirmar.TabIndex = 181
      Me.cmdConfirmar.Text = "&Confirmar"
      Me.cmdConfirmar.UseVisualStyleBackColor = True
      '
      'cmdCancelar
      '
      Me.cmdCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdCancelar.Location = New System.Drawing.Point(654, 506)
      Me.cmdCancelar.Name = "cmdCancelar"
      Me.cmdCancelar.Size = New System.Drawing.Size(64, 25)
      Me.cmdCancelar.TabIndex = 182
      Me.cmdCancelar.Text = "&Cancelar"
      Me.cmdCancelar.UseVisualStyleBackColor = True
      '
      'cbCaja
      '
      Me.cbCaja.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cbCaja.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      Me.cbCaja.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.cbCaja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbCaja.FormattingEnabled = True
      Me.cbCaja.Location = New System.Drawing.Point(543, 459)
      Me.cbCaja.Name = "cbCaja"
      Me.cbCaja.Size = New System.Drawing.Size(175, 21)
      Me.cbCaja.TabIndex = 183
      '
      'Label9
      '
      Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label9.AutoSize = True
      Me.Label9.Location = New System.Drawing.Point(506, 462)
      Me.Label9.Name = "Label9"
      Me.Label9.Size = New System.Drawing.Size(31, 13)
      Me.Label9.TabIndex = 184
      Me.Label9.Text = "Caja:"
      '
      'tbComprob
      '
      Me.tbComprob.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tbComprob.BackColor = System.Drawing.Color.LightGoldenrodYellow
      Me.tbComprob.Enabled = False
      Me.tbComprob.Location = New System.Drawing.Point(420, 505)
      Me.tbComprob.Name = "tbComprob"
      Me.tbComprob.Size = New System.Drawing.Size(80, 20)
      Me.tbComprob.TabIndex = 185
      '
      'Label10
      '
      Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label10.AutoSize = True
      Me.Label10.Location = New System.Drawing.Point(359, 509)
      Me.Label10.Name = "Label10"
      Me.Label10.Size = New System.Drawing.Size(55, 13)
      Me.Label10.TabIndex = 186
      Me.Label10.Text = "Comprob.:"
      '
      'frmOrdenPagoVs
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(730, 537)
      Me.Controls.Add(Me.Label10)
      Me.Controls.Add(Me.tbComprob)
      Me.Controls.Add(Me.cbCaja)
      Me.Controls.Add(Me.Label9)
      Me.Controls.Add(Me.cmdConfirmar)
      Me.Controls.Add(Me.cmdCancelar)
      Me.Controls.Add(Me.tbRecibe)
      Me.Controls.Add(Me.Label8)
      Me.Controls.Add(Me.cmdCheques)
      Me.Controls.Add(Me.tbCheques)
      Me.Controls.Add(Me.Label6)
      Me.Controls.Add(Me.tbEfectivo)
      Me.Controls.Add(Me.Label7)
      Me.Controls.Add(Me.tbTotal)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.tbDetalle)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.Label4)
      Me.Controls.Add(Me.dtpFecha)
      Me.Controls.Add(Me.tbNumero)
      Me.Controls.Add(Me.Label5)
      Me.Controls.Add(Me.cmdQuitar)
      Me.Controls.Add(Me.cmdAgregar)
      Me.Controls.Add(Me.DataGridView1)
      Me.Controls.Add(Me.cbProveedor)
      Me.Controls.Add(Me.Label2)
      Me.KeyPreview = True
      Me.Name = "frmOrdenPagoVs"
      Me.Text = "Orden de Pago Vs"
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents cbProveedor As System.Windows.Forms.ComboBox
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
   Friend WithEvents cmdQuitar As System.Windows.Forms.Button
   Friend WithEvents cmdAgregar As System.Windows.Forms.Button
   Friend WithEvents tbNumero As System.Windows.Forms.TextBox
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
   Friend WithEvents tbTotal As System.Windows.Forms.TextBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents tbDetalle As System.Windows.Forms.TextBox
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents cmdCheques As System.Windows.Forms.Button
   Friend WithEvents tbCheques As System.Windows.Forms.TextBox
   Friend WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents tbEfectivo As System.Windows.Forms.TextBox
   Friend WithEvents Label7 As System.Windows.Forms.Label
   Friend WithEvents tbRecibe As System.Windows.Forms.TextBox
   Friend WithEvents Label8 As System.Windows.Forms.Label
   Friend WithEvents cmdConfirmar As System.Windows.Forms.Button
   Friend WithEvents cmdCancelar As System.Windows.Forms.Button
   Friend WithEvents cbCaja As System.Windows.Forms.ComboBox
   Friend WithEvents Label9 As System.Windows.Forms.Label
   Friend WithEvents tbComprob As System.Windows.Forms.TextBox
   Friend WithEvents Label10 As System.Windows.Forms.Label
End Class
