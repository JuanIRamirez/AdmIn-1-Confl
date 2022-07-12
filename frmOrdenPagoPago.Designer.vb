<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOrdenPagoPago
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
      Me.Label9 = New System.Windows.Forms.Label()
      Me.tbProveedor = New System.Windows.Forms.TextBox()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.DataGridView1 = New System.Windows.Forms.DataGridView()
      Me.cmdPagar = New System.Windows.Forms.Button()
      Me.cmdCancelar = New System.Windows.Forms.Button()
      Me.cmdGuardar = New System.Windows.Forms.Button()
      Me.cmdModif = New System.Windows.Forms.Button()
      Me.cmdQuitar = New System.Windows.Forms.Button()
      Me.tbDetalle = New System.Windows.Forms.TextBox()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.tbRecibio = New System.Windows.Forms.TextBox()
      Me.Label10 = New System.Windows.Forms.Label()
      Me.tbTotal = New System.Windows.Forms.TextBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.tbEfectivo = New System.Windows.Forms.TextBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.tbCheques = New System.Windows.Forms.TextBox()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.tbDevolEf = New System.Windows.Forms.TextBox()
      Me.Label7 = New System.Windows.Forms.Label()
      Me.tbNumero = New System.Windows.Forms.TextBox()
      Me.Label8 = New System.Windows.Forms.Label()
      Me.cboCaja = New System.Windows.Forms.ComboBox()
      Me.Label11 = New System.Windows.Forms.Label()
      Me.cmdCheques = New System.Windows.Forms.Button()
      Me.tbTransf = New System.Windows.Forms.TextBox()
      Me.Label12 = New System.Windows.Forms.Label()
      Me.cmdTransf = New System.Windows.Forms.Button()
      Me.tbImpCaja = New System.Windows.Forms.TextBox()
      Me.Label13 = New System.Windows.Forms.Label()
      Me.tbDevolCh = New System.Windows.Forms.TextBox()
      Me.Label14 = New System.Windows.Forms.Label()
      Me.btnSetCols = New System.Windows.Forms.Button()
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'Label9
      '
      Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label9.AutoSize = True
      Me.Label9.Location = New System.Drawing.Point(657, 119)
      Me.Label9.Name = "Label9"
      Me.Label9.Size = New System.Drawing.Size(40, 13)
      Me.Label9.TabIndex = 144
      Me.Label9.Text = "Nº OP:"
      '
      'tbProveedor
      '
      Me.tbProveedor.BackColor = System.Drawing.Color.LightGoldenrodYellow
      Me.tbProveedor.Enabled = False
      Me.tbProveedor.Location = New System.Drawing.Point(71, 10)
      Me.tbProveedor.Name = "tbProveedor"
      Me.tbProveedor.Size = New System.Drawing.Size(423, 20)
      Me.tbProveedor.TabIndex = 143
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(505, 13)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(59, 13)
      Me.Label4.TabIndex = 142
      Me.Label4.Text = "Fec. Pago:"
      '
      'dtpFecha
      '
      Me.dtpFecha.Enabled = False
      Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpFecha.Location = New System.Drawing.Point(570, 10)
      Me.dtpFecha.Name = "dtpFecha"
      Me.dtpFecha.Size = New System.Drawing.Size(81, 20)
      Me.dtpFecha.TabIndex = 141
      Me.dtpFecha.Value = New Date(2015, 9, 24, 0, 0, 0, 0)
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(6, 13)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(59, 13)
      Me.Label1.TabIndex = 140
      Me.Label1.Text = "Proveedor:"
      '
      'DataGridView1
      '
      Me.DataGridView1.AllowUserToAddRows = False
      Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
      Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.DataGridView1.Location = New System.Drawing.Point(9, 38)
      Me.DataGridView1.Name = "DataGridView1"
      Me.DataGridView1.ReadOnly = True
      Me.DataGridView1.RowTemplate.ReadOnly = True
      Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.DataGridView1.Size = New System.Drawing.Size(767, 364)
      Me.DataGridView1.TabIndex = 146
      '
      'cmdPagar
      '
      Me.cmdPagar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdPagar.Location = New System.Drawing.Point(641, 528)
      Me.cmdPagar.Name = "cmdPagar"
      Me.cmdPagar.Size = New System.Drawing.Size(65, 27)
      Me.cmdPagar.TabIndex = 147
      Me.cmdPagar.Text = "&Pagar"
      Me.cmdPagar.UseVisualStyleBackColor = True
      '
      'cmdCancelar
      '
      Me.cmdCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdCancelar.Location = New System.Drawing.Point(712, 528)
      Me.cmdCancelar.Name = "cmdCancelar"
      Me.cmdCancelar.Size = New System.Drawing.Size(64, 27)
      Me.cmdCancelar.TabIndex = 148
      Me.cmdCancelar.Text = "&Cancelar"
      Me.cmdCancelar.UseVisualStyleBackColor = True
      '
      'cmdGuardar
      '
      Me.cmdGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdGuardar.Location = New System.Drawing.Point(566, 528)
      Me.cmdGuardar.Name = "cmdGuardar"
      Me.cmdGuardar.Size = New System.Drawing.Size(69, 27)
      Me.cmdGuardar.TabIndex = 149
      Me.cmdGuardar.Text = "&Guardar"
      Me.cmdGuardar.UseVisualStyleBackColor = True
      '
      'cmdModif
      '
      Me.cmdModif.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdModif.Location = New System.Drawing.Point(9, 410)
      Me.cmdModif.Name = "cmdModif"
      Me.cmdModif.Size = New System.Drawing.Size(69, 27)
      Me.cmdModif.TabIndex = 150
      Me.cmdModif.Text = "&Modificar"
      Me.cmdModif.UseVisualStyleBackColor = True
      '
      'cmdQuitar
      '
      Me.cmdQuitar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdQuitar.Location = New System.Drawing.Point(84, 410)
      Me.cmdQuitar.Name = "cmdQuitar"
      Me.cmdQuitar.Size = New System.Drawing.Size(57, 27)
      Me.cmdQuitar.TabIndex = 151
      Me.cmdQuitar.Text = "&Quitar"
      Me.cmdQuitar.UseVisualStyleBackColor = True
      '
      'tbDetalle
      '
      Me.tbDetalle.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.tbDetalle.Location = New System.Drawing.Point(147, 410)
      Me.tbDetalle.Multiline = True
      Me.tbDetalle.Name = "tbDetalle"
      Me.tbDetalle.Size = New System.Drawing.Size(414, 70)
      Me.tbDetalle.TabIndex = 152
      '
      'Label5
      '
      Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.Label5.AutoSize = True
      Me.Label5.Location = New System.Drawing.Point(65, 459)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(76, 13)
      Me.Label5.TabIndex = 153
      Me.Label5.Text = "Detalle / Obs.:"
      '
      'tbRecibio
      '
      Me.tbRecibio.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.tbRecibio.BackColor = System.Drawing.Color.LightGoldenrodYellow
      Me.tbRecibio.Enabled = False
      Me.tbRecibio.Location = New System.Drawing.Point(147, 494)
      Me.tbRecibio.Name = "tbRecibio"
      Me.tbRecibio.Size = New System.Drawing.Size(159, 20)
      Me.tbRecibio.TabIndex = 155
      '
      'Label10
      '
      Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.Label10.AutoSize = True
      Me.Label10.Location = New System.Drawing.Point(95, 497)
      Me.Label10.Name = "Label10"
      Me.Label10.Size = New System.Drawing.Size(46, 13)
      Me.Label10.TabIndex = 154
      Me.Label10.Text = "Recibió:"
      '
      'tbTotal
      '
      Me.tbTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tbTotal.BackColor = System.Drawing.Color.LightGoldenrodYellow
      Me.tbTotal.Enabled = False
      Me.tbTotal.Location = New System.Drawing.Point(703, 410)
      Me.tbTotal.Name = "tbTotal"
      Me.tbTotal.Size = New System.Drawing.Size(73, 20)
      Me.tbTotal.TabIndex = 157
      '
      'Label2
      '
      Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(657, 413)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(40, 13)
      Me.Label2.TabIndex = 156
      Me.Label2.Text = "Total $"
      '
      'tbEfectivo
      '
      Me.tbEfectivo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tbEfectivo.BackColor = System.Drawing.Color.LightGoldenrodYellow
      Me.tbEfectivo.Location = New System.Drawing.Point(703, 436)
      Me.tbEfectivo.Name = "tbEfectivo"
      Me.tbEfectivo.Size = New System.Drawing.Size(73, 20)
      Me.tbEfectivo.TabIndex = 159
      '
      'Label3
      '
      Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(642, 439)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(55, 13)
      Me.Label3.TabIndex = 158
      Me.Label3.Text = "Efectivo $"
      '
      'tbCheques
      '
      Me.tbCheques.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tbCheques.BackColor = System.Drawing.Color.LightGoldenrodYellow
      Me.tbCheques.Enabled = False
      Me.tbCheques.Location = New System.Drawing.Point(703, 464)
      Me.tbCheques.Name = "tbCheques"
      Me.tbCheques.Size = New System.Drawing.Size(73, 20)
      Me.tbCheques.TabIndex = 161
      '
      'Label6
      '
      Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label6.AutoSize = True
      Me.Label6.Location = New System.Drawing.Point(684, 467)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(13, 13)
      Me.Label6.TabIndex = 160
      Me.Label6.Text = "$"
      '
      'tbDevolEf
      '
      Me.tbDevolEf.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.tbDevolEf.BackColor = System.Drawing.Color.LightGoldenrodYellow
      Me.tbDevolEf.Enabled = False
      Me.tbDevolEf.Location = New System.Drawing.Point(384, 494)
      Me.tbDevolEf.Name = "tbDevolEf"
      Me.tbDevolEf.Size = New System.Drawing.Size(91, 20)
      Me.tbDevolEf.TabIndex = 163
      '
      'Label7
      '
      Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.Label7.AutoSize = True
      Me.Label7.Location = New System.Drawing.Point(315, 497)
      Me.Label7.Name = "Label7"
      Me.Label7.Size = New System.Drawing.Size(63, 13)
      Me.Label7.TabIndex = 162
      Me.Label7.Text = "Devol. Ef. $"
      '
      'tbNumero
      '
      Me.tbNumero.BackColor = System.Drawing.Color.LightGoldenrodYellow
      Me.tbNumero.Enabled = False
      Me.tbNumero.Location = New System.Drawing.Point(702, 10)
      Me.tbNumero.Name = "tbNumero"
      Me.tbNumero.Size = New System.Drawing.Size(73, 20)
      Me.tbNumero.TabIndex = 165
      '
      'Label8
      '
      Me.Label8.AutoSize = True
      Me.Label8.Location = New System.Drawing.Point(656, 13)
      Me.Label8.Name = "Label8"
      Me.Label8.Size = New System.Drawing.Size(40, 13)
      Me.Label8.TabIndex = 164
      Me.Label8.Text = "Nº OP:"
      '
      'cboCaja
      '
      Me.cboCaja.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cboCaja.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      Me.cboCaja.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.cboCaja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboCaja.FormattingEnabled = True
      Me.cboCaja.Location = New System.Drawing.Point(147, 527)
      Me.cboCaja.Name = "cboCaja"
      Me.cboCaja.Size = New System.Drawing.Size(175, 21)
      Me.cboCaja.TabIndex = 166
      '
      'Label11
      '
      Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.Label11.AutoSize = True
      Me.Label11.Location = New System.Drawing.Point(110, 531)
      Me.Label11.Name = "Label11"
      Me.Label11.Size = New System.Drawing.Size(31, 13)
      Me.Label11.TabIndex = 167
      Me.Label11.Text = "Caja:"
      '
      'cmdCheques
      '
      Me.cmdCheques.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdCheques.Enabled = False
      Me.cmdCheques.Location = New System.Drawing.Point(621, 461)
      Me.cmdCheques.Name = "cmdCheques"
      Me.cmdCheques.Size = New System.Drawing.Size(58, 24)
      Me.cmdCheques.TabIndex = 168
      Me.cmdCheques.Text = "Che&ques"
      Me.cmdCheques.UseVisualStyleBackColor = True
      '
      'tbTransf
      '
      Me.tbTransf.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tbTransf.BackColor = System.Drawing.Color.LightGoldenrodYellow
      Me.tbTransf.Enabled = False
      Me.tbTransf.Location = New System.Drawing.Point(703, 494)
      Me.tbTransf.Name = "tbTransf"
      Me.tbTransf.Size = New System.Drawing.Size(73, 20)
      Me.tbTransf.TabIndex = 170
      '
      'Label12
      '
      Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label12.AutoSize = True
      Me.Label12.Location = New System.Drawing.Point(684, 497)
      Me.Label12.Name = "Label12"
      Me.Label12.Size = New System.Drawing.Size(13, 13)
      Me.Label12.TabIndex = 169
      Me.Label12.Text = "$"
      '
      'cmdTransf
      '
      Me.cmdTransf.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdTransf.Enabled = False
      Me.cmdTransf.Location = New System.Drawing.Point(621, 491)
      Me.cmdTransf.Name = "cmdTransf"
      Me.cmdTransf.Size = New System.Drawing.Size(58, 24)
      Me.cmdTransf.TabIndex = 171
      Me.cmdTransf.Text = "&Transf."
      Me.cmdTransf.UseVisualStyleBackColor = True
      '
      'tbImpCaja
      '
      Me.tbImpCaja.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.tbImpCaja.BackColor = System.Drawing.Color.LightGoldenrodYellow
      Me.tbImpCaja.Enabled = False
      Me.tbImpCaja.Location = New System.Drawing.Point(414, 528)
      Me.tbImpCaja.Name = "tbImpCaja"
      Me.tbImpCaja.Size = New System.Drawing.Size(73, 20)
      Me.tbImpCaja.TabIndex = 173
      '
      'Label13
      '
      Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.Label13.AutoSize = True
      Me.Label13.Location = New System.Drawing.Point(368, 531)
      Me.Label13.Name = "Label13"
      Me.Label13.Size = New System.Drawing.Size(37, 13)
      Me.Label13.TabIndex = 172
      Me.Label13.Text = "Caja $"
      '
      'tbDevolCh
      '
      Me.tbDevolCh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.tbDevolCh.BackColor = System.Drawing.Color.LightGoldenrodYellow
      Me.tbDevolCh.Enabled = False
      Me.tbDevolCh.Location = New System.Drawing.Point(519, 494)
      Me.tbDevolCh.Name = "tbDevolCh"
      Me.tbDevolCh.Size = New System.Drawing.Size(91, 20)
      Me.tbDevolCh.TabIndex = 175
      '
      'Label14
      '
      Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.Label14.AutoSize = True
      Me.Label14.Location = New System.Drawing.Point(481, 497)
      Me.Label14.Name = "Label14"
      Me.Label14.Size = New System.Drawing.Size(32, 13)
      Me.Label14.TabIndex = 174
      Me.Label14.Text = "Ch. $"
      '
      'btnSetCols
      '
      Me.btnSetCols.Location = New System.Drawing.Point(9, 38)
      Me.btnSetCols.Name = "btnSetCols"
      Me.btnSetCols.Size = New System.Drawing.Size(38, 24)
      Me.btnSetCols.TabIndex = 176
      Me.btnSetCols.Text = "|||"
      Me.btnSetCols.UseVisualStyleBackColor = True
      '
      'frmOrdenPagoPago
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(788, 567)
      Me.Controls.Add(Me.btnSetCols)
      Me.Controls.Add(Me.tbDevolCh)
      Me.Controls.Add(Me.Label14)
      Me.Controls.Add(Me.tbImpCaja)
      Me.Controls.Add(Me.Label13)
      Me.Controls.Add(Me.cmdTransf)
      Me.Controls.Add(Me.tbTransf)
      Me.Controls.Add(Me.Label12)
      Me.Controls.Add(Me.cmdCheques)
      Me.Controls.Add(Me.cboCaja)
      Me.Controls.Add(Me.Label11)
      Me.Controls.Add(Me.tbNumero)
      Me.Controls.Add(Me.Label8)
      Me.Controls.Add(Me.tbDevolEf)
      Me.Controls.Add(Me.Label7)
      Me.Controls.Add(Me.tbCheques)
      Me.Controls.Add(Me.Label6)
      Me.Controls.Add(Me.tbEfectivo)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.tbTotal)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.tbRecibio)
      Me.Controls.Add(Me.Label10)
      Me.Controls.Add(Me.tbDetalle)
      Me.Controls.Add(Me.Label5)
      Me.Controls.Add(Me.cmdQuitar)
      Me.Controls.Add(Me.cmdModif)
      Me.Controls.Add(Me.cmdGuardar)
      Me.Controls.Add(Me.cmdPagar)
      Me.Controls.Add(Me.cmdCancelar)
      Me.Controls.Add(Me.DataGridView1)
      Me.Controls.Add(Me.Label9)
      Me.Controls.Add(Me.tbProveedor)
      Me.Controls.Add(Me.Label4)
      Me.Controls.Add(Me.dtpFecha)
      Me.Controls.Add(Me.Label1)
      Me.KeyPreview = True
      Me.Name = "frmOrdenPagoPago"
      Me.Text = "Orden de Pago: Pagar"
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents Label9 As System.Windows.Forms.Label
   Friend WithEvents tbProveedor As System.Windows.Forms.TextBox
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
   Friend WithEvents cmdPagar As System.Windows.Forms.Button
   Friend WithEvents cmdCancelar As System.Windows.Forms.Button
   Friend WithEvents cmdGuardar As System.Windows.Forms.Button
   Friend WithEvents cmdModif As System.Windows.Forms.Button
   Friend WithEvents cmdQuitar As System.Windows.Forms.Button
   Friend WithEvents tbDetalle As System.Windows.Forms.TextBox
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents tbRecibio As System.Windows.Forms.TextBox
   Friend WithEvents Label10 As System.Windows.Forms.Label
   Friend WithEvents tbTotal As System.Windows.Forms.TextBox
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents tbEfectivo As System.Windows.Forms.TextBox
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents tbCheques As System.Windows.Forms.TextBox
   Friend WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents tbDevolEf As System.Windows.Forms.TextBox
   Friend WithEvents Label7 As System.Windows.Forms.Label
   Friend WithEvents tbNumero As System.Windows.Forms.TextBox
   Friend WithEvents Label8 As System.Windows.Forms.Label
   Friend WithEvents cboCaja As System.Windows.Forms.ComboBox
   Friend WithEvents Label11 As System.Windows.Forms.Label
   Friend WithEvents cmdCheques As System.Windows.Forms.Button
   Friend WithEvents tbTransf As System.Windows.Forms.TextBox
   Friend WithEvents Label12 As System.Windows.Forms.Label
   Friend WithEvents cmdTransf As System.Windows.Forms.Button
   Friend WithEvents tbImpCaja As System.Windows.Forms.TextBox
   Friend WithEvents Label13 As System.Windows.Forms.Label
   Friend WithEvents tbDevolCh As System.Windows.Forms.TextBox
   Friend WithEvents Label14 As System.Windows.Forms.Label
   Friend WithEvents btnSetCols As System.Windows.Forms.Button
End Class
