<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBancosMovAM
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
      Me.Label2 = New System.Windows.Forms.Label()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.lblCuenta = New System.Windows.Forms.Label()
      Me.cbDescCta = New System.Windows.Forms.ComboBox()
      Me.tbCuenta = New System.Windows.Forms.TextBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.cboTipoMovBco = New System.Windows.Forms.ComboBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.Label15 = New System.Windows.Forms.Label()
      Me.tbFechaEmi = New System.Windows.Forms.DateTimePicker()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.tbFechaAcr = New System.Windows.Forms.DateTimePicker()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.cmdSalir = New System.Windows.Forms.Button()
      Me.cmdCancelar = New System.Windows.Forms.Button()
      Me.lblDetObs = New System.Windows.Forms.Label()
      Me.tbDetalle = New System.Windows.Forms.TextBox()
      Me.tbHojaNro = New System.Windows.Forms.TextBox()
      Me.Label8 = New System.Windows.Forms.Label()
      Me.tbImporte = New System.Windows.Forms.TextBox()
      Me.cbNumero = New System.Windows.Forms.ComboBox()
      Me.cbBancoCh = New System.Windows.Forms.ComboBox()
      Me.Label9 = New System.Windows.Forms.Label()
      Me.cbCuentaCh = New System.Windows.Forms.ComboBox()
      Me.Label10 = New System.Windows.Forms.Label()
      Me.Label11 = New System.Windows.Forms.Label()
      Me.cbNumeroCh = New System.Windows.Forms.ComboBox()
      Me.GroupBox1 = New System.Windows.Forms.GroupBox()
      Me.cbImporteCh = New System.Windows.Forms.ComboBox()
      Me.Label13 = New System.Windows.Forms.Label()
      Me.optEfectivo = New System.Windows.Forms.RadioButton()
      Me.optCheque = New System.Windows.Forms.RadioButton()
      Me.cmdAceptar = New System.Windows.Forms.Button()
      Me.cmdConciliar = New System.Windows.Forms.Button()
      Me.Label12 = New System.Windows.Forms.Label()
      Me.cbCaja = New System.Windows.Forms.ComboBox()
      Me.cbCuentaBco = New System.Windows.Forms.ComboBox()
      Me.cbBanco = New System.Windows.Forms.ComboBox()
      Me.GroupBox1.SuspendLayout()
      Me.SuspendLayout()
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(65, 37)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(41, 13)
      Me.Label2.TabIndex = 99
      Me.Label2.Text = "Banco:"
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(50, 74)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(56, 13)
      Me.Label4.TabIndex = 108
      Me.Label4.Text = "Cuenta Nº"
      '
      'lblCuenta
      '
      Me.lblCuenta.AutoSize = True
      Me.lblCuenta.Location = New System.Drawing.Point(56, 120)
      Me.lblCuenta.Name = "lblCuenta"
      Me.lblCuenta.Size = New System.Drawing.Size(54, 13)
      Me.lblCuenta.TabIndex = 110
      Me.lblCuenta.Text = "Cta.Cont.:"
      '
      'cbDescCta
      '
      Me.cbDescCta.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      Me.cbDescCta.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.cbDescCta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbDescCta.FormattingEnabled = True
      Me.cbDescCta.Location = New System.Drawing.Point(252, 117)
      Me.cbDescCta.Name = "cbDescCta"
      Me.cbDescCta.Size = New System.Drawing.Size(442, 21)
      Me.cbDescCta.TabIndex = 111
      '
      'tbCuenta
      '
      Me.tbCuenta.Location = New System.Drawing.Point(112, 117)
      Me.tbCuenta.Name = "tbCuenta"
      Me.tbCuenta.Size = New System.Drawing.Size(134, 20)
      Me.tbCuenta.TabIndex = 112
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(48, 158)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(58, 13)
      Me.Label1.TabIndex = 114
      Me.Label1.Text = "Tipo Mov.:"
      '
      'cboTipoMovBco
      '
      Me.cboTipoMovBco.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      Me.cboTipoMovBco.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.cboTipoMovBco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboTipoMovBco.FormattingEnabled = True
      Me.cboTipoMovBco.Location = New System.Drawing.Point(112, 155)
      Me.cboTipoMovBco.Name = "cboTipoMovBco"
      Me.cboTipoMovBco.Size = New System.Drawing.Size(134, 21)
      Me.cboTipoMovBco.TabIndex = 113
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(52, 202)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(54, 13)
      Me.Label3.TabIndex = 115
      Me.Label3.Text = "Número #"
      '
      'Label15
      '
      Me.Label15.AutoSize = True
      Me.Label15.Location = New System.Drawing.Point(31, 246)
      Me.Label15.Name = "Label15"
      Me.Label15.Size = New System.Drawing.Size(79, 13)
      Me.Label15.TabIndex = 118
      Me.Label15.Text = "Fecha Emisión:"
      '
      'tbFechaEmi
      '
      Me.tbFechaEmi.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.tbFechaEmi.Location = New System.Drawing.Point(112, 243)
      Me.tbFechaEmi.Name = "tbFechaEmi"
      Me.tbFechaEmi.Size = New System.Drawing.Size(88, 20)
      Me.tbFechaEmi.TabIndex = 117
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.Location = New System.Drawing.Point(31, 291)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(79, 13)
      Me.Label5.TabIndex = 120
      Me.Label5.Text = "Fecha Acredit.:"
      '
      'tbFechaAcr
      '
      Me.tbFechaAcr.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.tbFechaAcr.Location = New System.Drawing.Point(112, 288)
      Me.tbFechaAcr.Name = "tbFechaAcr"
      Me.tbFechaAcr.Size = New System.Drawing.Size(88, 20)
      Me.tbFechaAcr.TabIndex = 119
      '
      'Label6
      '
      Me.Label6.AutoSize = True
      Me.Label6.Location = New System.Drawing.Point(55, 333)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(51, 13)
      Me.Label6.TabIndex = 121
      Me.Label6.Text = "Importe $"
      '
      'cmdSalir
      '
      Me.cmdSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdSalir.Location = New System.Drawing.Point(618, 468)
      Me.cmdSalir.Name = "cmdSalir"
      Me.cmdSalir.Size = New System.Drawing.Size(76, 27)
      Me.cmdSalir.TabIndex = 123
      Me.cmdSalir.Text = "&Cerrar"
      Me.cmdSalir.UseVisualStyleBackColor = True
      '
      'cmdCancelar
      '
      Me.cmdCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdCancelar.Location = New System.Drawing.Point(536, 468)
      Me.cmdCancelar.Name = "cmdCancelar"
      Me.cmdCancelar.Size = New System.Drawing.Size(76, 27)
      Me.cmdCancelar.TabIndex = 124
      Me.cmdCancelar.Text = "&Cancelar"
      Me.cmdCancelar.UseVisualStyleBackColor = True
      '
      'lblDetObs
      '
      Me.lblDetObs.AutoSize = True
      Me.lblDetObs.Location = New System.Drawing.Point(31, 369)
      Me.lblDetObs.Name = "lblDetObs"
      Me.lblDetObs.Size = New System.Drawing.Size(75, 13)
      Me.lblDetObs.TabIndex = 126
      Me.lblDetObs.Text = "Det./ Observ.:"
      '
      'tbDetalle
      '
      Me.tbDetalle.Location = New System.Drawing.Point(112, 366)
      Me.tbDetalle.Multiline = True
      Me.tbDetalle.Name = "tbDetalle"
      Me.tbDetalle.Size = New System.Drawing.Size(582, 74)
      Me.tbDetalle.TabIndex = 125
      '
      'tbHojaNro
      '
      Me.tbHojaNro.Location = New System.Drawing.Point(112, 457)
      Me.tbHojaNro.Name = "tbHojaNro"
      Me.tbHojaNro.Size = New System.Drawing.Size(88, 20)
      Me.tbHojaNro.TabIndex = 128
      '
      'Label8
      '
      Me.Label8.AutoSize = True
      Me.Label8.Location = New System.Drawing.Point(62, 460)
      Me.Label8.Name = "Label8"
      Me.Label8.Size = New System.Drawing.Size(44, 13)
      Me.Label8.TabIndex = 127
      Me.Label8.Text = "Hoja Nº"
      '
      'tbImporte
      '
      Me.tbImporte.Location = New System.Drawing.Point(112, 330)
      Me.tbImporte.Name = "tbImporte"
      Me.tbImporte.Size = New System.Drawing.Size(134, 20)
      Me.tbImporte.TabIndex = 122
      '
      'cbNumero
      '
      Me.cbNumero.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      Me.cbNumero.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.cbNumero.FormattingEnabled = True
      Me.cbNumero.Location = New System.Drawing.Point(112, 199)
      Me.cbNumero.Name = "cbNumero"
      Me.cbNumero.Size = New System.Drawing.Size(134, 21)
      Me.cbNumero.TabIndex = 129
      '
      'cbBancoCh
      '
      Me.cbBancoCh.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      Me.cbBancoCh.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.cbBancoCh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbBancoCh.Enabled = False
      Me.cbBancoCh.FormattingEnabled = True
      Me.cbBancoCh.Location = New System.Drawing.Point(66, 22)
      Me.cbBancoCh.Name = "cbBancoCh"
      Me.cbBancoCh.Size = New System.Drawing.Size(352, 21)
      Me.cbBancoCh.TabIndex = 130
      '
      'Label9
      '
      Me.Label9.AutoSize = True
      Me.Label9.Location = New System.Drawing.Point(22, 25)
      Me.Label9.Name = "Label9"
      Me.Label9.Size = New System.Drawing.Size(41, 13)
      Me.Label9.TabIndex = 131
      Me.Label9.Text = "Banco:"
      '
      'cbCuentaCh
      '
      Me.cbCuentaCh.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      Me.cbCuentaCh.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.cbCuentaCh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbCuentaCh.Enabled = False
      Me.cbCuentaCh.FormattingEnabled = True
      Me.cbCuentaCh.Location = New System.Drawing.Point(66, 57)
      Me.cbCuentaCh.Name = "cbCuentaCh"
      Me.cbCuentaCh.Size = New System.Drawing.Size(352, 21)
      Me.cbCuentaCh.TabIndex = 132
      '
      'Label10
      '
      Me.Label10.AutoSize = True
      Me.Label10.Location = New System.Drawing.Point(19, 61)
      Me.Label10.Name = "Label10"
      Me.Label10.Size = New System.Drawing.Size(44, 13)
      Me.Label10.TabIndex = 133
      Me.Label10.Text = "Cuenta:"
      '
      'Label11
      '
      Me.Label11.AutoSize = True
      Me.Label11.Location = New System.Drawing.Point(9, 97)
      Me.Label11.Name = "Label11"
      Me.Label11.Size = New System.Drawing.Size(54, 13)
      Me.Label11.TabIndex = 134
      Me.Label11.Text = "Número #"
      '
      'cbNumeroCh
      '
      Me.cbNumeroCh.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      Me.cbNumeroCh.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.cbNumeroCh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbNumeroCh.Enabled = False
      Me.cbNumeroCh.FormattingEnabled = True
      Me.cbNumeroCh.Location = New System.Drawing.Point(66, 94)
      Me.cbNumeroCh.Name = "cbNumeroCh"
      Me.cbNumeroCh.Size = New System.Drawing.Size(134, 21)
      Me.cbNumeroCh.TabIndex = 135
      '
      'GroupBox1
      '
      Me.GroupBox1.Controls.Add(Me.cbImporteCh)
      Me.GroupBox1.Controls.Add(Me.Label13)
      Me.GroupBox1.Controls.Add(Me.cbNumeroCh)
      Me.GroupBox1.Controls.Add(Me.Label9)
      Me.GroupBox1.Controls.Add(Me.Label10)
      Me.GroupBox1.Controls.Add(Me.cbBancoCh)
      Me.GroupBox1.Controls.Add(Me.Label11)
      Me.GroupBox1.Controls.Add(Me.cbCuentaCh)
      Me.GroupBox1.Location = New System.Drawing.Point(269, 189)
      Me.GroupBox1.Name = "GroupBox1"
      Me.GroupBox1.Size = New System.Drawing.Size(427, 171)
      Me.GroupBox1.TabIndex = 136
      Me.GroupBox1.TabStop = False
      '
      'cbImporteCh
      '
      Me.cbImporteCh.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      Me.cbImporteCh.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.cbImporteCh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbImporteCh.Enabled = False
      Me.cbImporteCh.FormattingEnabled = True
      Me.cbImporteCh.Location = New System.Drawing.Point(66, 130)
      Me.cbImporteCh.Name = "cbImporteCh"
      Me.cbImporteCh.Size = New System.Drawing.Size(134, 21)
      Me.cbImporteCh.TabIndex = 137
      '
      'Label13
      '
      Me.Label13.AutoSize = True
      Me.Label13.Location = New System.Drawing.Point(12, 133)
      Me.Label13.Name = "Label13"
      Me.Label13.Size = New System.Drawing.Size(51, 13)
      Me.Label13.TabIndex = 136
      Me.Label13.Text = "Importe $"
      '
      'optEfectivo
      '
      Me.optEfectivo.AutoSize = True
      Me.optEfectivo.Checked = True
      Me.optEfectivo.Location = New System.Drawing.Point(269, 160)
      Me.optEfectivo.Name = "optEfectivo"
      Me.optEfectivo.Size = New System.Drawing.Size(64, 17)
      Me.optEfectivo.TabIndex = 137
      Me.optEfectivo.TabStop = True
      Me.optEfectivo.Text = "&Efectivo"
      Me.optEfectivo.UseVisualStyleBackColor = True
      '
      'optCheque
      '
      Me.optCheque.AutoSize = True
      Me.optCheque.Location = New System.Drawing.Point(339, 160)
      Me.optCheque.Name = "optCheque"
      Me.optCheque.Size = New System.Drawing.Size(62, 17)
      Me.optCheque.TabIndex = 138
      Me.optCheque.Text = "&Cheque"
      Me.optCheque.UseVisualStyleBackColor = True
      '
      'cmdAceptar
      '
      Me.cmdAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdAceptar.Location = New System.Drawing.Point(454, 468)
      Me.cmdAceptar.Name = "cmdAceptar"
      Me.cmdAceptar.Size = New System.Drawing.Size(76, 27)
      Me.cmdAceptar.TabIndex = 139
      Me.cmdAceptar.Text = "&Aceptar"
      Me.cmdAceptar.UseVisualStyleBackColor = True
      '
      'cmdConciliar
      '
      Me.cmdConciliar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdConciliar.Location = New System.Drawing.Point(372, 468)
      Me.cmdConciliar.Name = "cmdConciliar"
      Me.cmdConciliar.Size = New System.Drawing.Size(76, 27)
      Me.cmdConciliar.TabIndex = 140
      Me.cmdConciliar.Text = "&Conciliar"
      Me.cmdConciliar.UseVisualStyleBackColor = True
      '
      'Label12
      '
      Me.Label12.AutoSize = True
      Me.Label12.Location = New System.Drawing.Point(451, 162)
      Me.Label12.Name = "Label12"
      Me.Label12.Size = New System.Drawing.Size(31, 13)
      Me.Label12.TabIndex = 142
      Me.Label12.Text = "Caja:"
      '
      'cbCaja
      '
      Me.cbCaja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbCaja.Enabled = False
      Me.cbCaja.FormattingEnabled = True
      Me.cbCaja.Location = New System.Drawing.Point(488, 158)
      Me.cbCaja.Name = "cbCaja"
      Me.cbCaja.Size = New System.Drawing.Size(206, 21)
      Me.cbCaja.TabIndex = 141
      '
      'cbCuentaBco
      '
      Me.cbCuentaBco.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      Me.cbCuentaBco.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.cbCuentaBco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbCuentaBco.FormattingEnabled = True
      Me.cbCuentaBco.Location = New System.Drawing.Point(112, 71)
      Me.cbCuentaBco.Name = "cbCuentaBco"
      Me.cbCuentaBco.Size = New System.Drawing.Size(286, 21)
      Me.cbCuentaBco.TabIndex = 144
      '
      'cbBanco
      '
      Me.cbBanco.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      Me.cbBanco.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.cbBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbBanco.FormattingEnabled = True
      Me.cbBanco.Location = New System.Drawing.Point(112, 34)
      Me.cbBanco.Name = "cbBanco"
      Me.cbBanco.Size = New System.Drawing.Size(441, 21)
      Me.cbBanco.TabIndex = 143
      '
      'frmBancosMovAM
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(706, 507)
      Me.Controls.Add(Me.cbCuentaBco)
      Me.Controls.Add(Me.cbBanco)
      Me.Controls.Add(Me.Label12)
      Me.Controls.Add(Me.cbCaja)
      Me.Controls.Add(Me.cmdConciliar)
      Me.Controls.Add(Me.cmdAceptar)
      Me.Controls.Add(Me.optCheque)
      Me.Controls.Add(Me.optEfectivo)
      Me.Controls.Add(Me.GroupBox1)
      Me.Controls.Add(Me.cbNumero)
      Me.Controls.Add(Me.tbHojaNro)
      Me.Controls.Add(Me.Label8)
      Me.Controls.Add(Me.lblDetObs)
      Me.Controls.Add(Me.tbDetalle)
      Me.Controls.Add(Me.cmdCancelar)
      Me.Controls.Add(Me.cmdSalir)
      Me.Controls.Add(Me.tbImporte)
      Me.Controls.Add(Me.Label6)
      Me.Controls.Add(Me.Label5)
      Me.Controls.Add(Me.tbFechaAcr)
      Me.Controls.Add(Me.Label15)
      Me.Controls.Add(Me.tbFechaEmi)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.cboTipoMovBco)
      Me.Controls.Add(Me.tbCuenta)
      Me.Controls.Add(Me.cbDescCta)
      Me.Controls.Add(Me.lblCuenta)
      Me.Controls.Add(Me.Label4)
      Me.Controls.Add(Me.Label2)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.KeyPreview = True
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "frmBancosMovAM"
      Me.Text = "Movimiento Banco"
      Me.GroupBox1.ResumeLayout(False)
      Me.GroupBox1.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents lblCuenta As System.Windows.Forms.Label
   Friend WithEvents cbDescCta As System.Windows.Forms.ComboBox
   Friend WithEvents tbCuenta As System.Windows.Forms.TextBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents cboTipoMovBco As System.Windows.Forms.ComboBox
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents Label15 As System.Windows.Forms.Label
   Friend WithEvents tbFechaEmi As System.Windows.Forms.DateTimePicker
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents tbFechaAcr As System.Windows.Forms.DateTimePicker
   Friend WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents cmdSalir As System.Windows.Forms.Button
   Friend WithEvents cmdCancelar As System.Windows.Forms.Button
   Friend WithEvents lblDetObs As System.Windows.Forms.Label
   Friend WithEvents tbDetalle As System.Windows.Forms.TextBox
   Friend WithEvents tbHojaNro As System.Windows.Forms.TextBox
   Friend WithEvents Label8 As System.Windows.Forms.Label
   Friend WithEvents tbImporte As System.Windows.Forms.TextBox
   Friend WithEvents cbNumero As System.Windows.Forms.ComboBox
   Friend WithEvents cbBancoCh As System.Windows.Forms.ComboBox
   Friend WithEvents Label9 As System.Windows.Forms.Label
   Friend WithEvents cbCuentaCh As System.Windows.Forms.ComboBox
   Friend WithEvents Label10 As System.Windows.Forms.Label
   Friend WithEvents Label11 As System.Windows.Forms.Label
   Friend WithEvents cbNumeroCh As System.Windows.Forms.ComboBox
   Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents optEfectivo As System.Windows.Forms.RadioButton
   Friend WithEvents optCheque As System.Windows.Forms.RadioButton
   Friend WithEvents cmdAceptar As System.Windows.Forms.Button
   Friend WithEvents cmdConciliar As System.Windows.Forms.Button
   Friend WithEvents Label12 As System.Windows.Forms.Label
   Friend WithEvents cbCaja As System.Windows.Forms.ComboBox
   Friend WithEvents cbImporteCh As System.Windows.Forms.ComboBox
   Friend WithEvents Label13 As System.Windows.Forms.Label
   Friend WithEvents cbCuentaBco As System.Windows.Forms.ComboBox
   Friend WithEvents cbBanco As System.Windows.Forms.ComboBox
End Class
