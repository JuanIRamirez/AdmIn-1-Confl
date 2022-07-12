<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChRechAM
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
      Me.tbDescBanco = New System.Windows.Forms.TextBox()
      Me.tbCtaBco = New System.Windows.Forms.TextBox()
      Me.lblCuenta = New System.Windows.Forms.Label()
      Me.cbDescCta = New System.Windows.Forms.ComboBox()
      Me.tbCuenta = New System.Windows.Forms.TextBox()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.tbFechaAcr = New System.Windows.Forms.DateTimePicker()
      Me.cmdCancelar = New System.Windows.Forms.Button()
      Me.lblDetObs = New System.Windows.Forms.Label()
      Me.tbDetalle = New System.Windows.Forms.TextBox()
      Me.Label9 = New System.Windows.Forms.Label()
      Me.Label10 = New System.Windows.Forms.Label()
      Me.Label11 = New System.Windows.Forms.Label()
      Me.Label13 = New System.Windows.Forms.Label()
      Me.cmdAceptar = New System.Windows.Forms.Button()
      Me.Label12 = New System.Windows.Forms.Label()
      Me.cbCaja = New System.Windows.Forms.ComboBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.dtpFechaRech = New System.Windows.Forms.DateTimePicker()
      Me.tbBancoCh = New System.Windows.Forms.TextBox()
      Me.tbCuentaCh = New System.Windows.Forms.TextBox()
      Me.tbNumeroCh = New System.Windows.Forms.TextBox()
      Me.tbImporteCh = New System.Windows.Forms.TextBox()
      Me.tbCliente = New System.Windows.Forms.TextBox()
      Me.Label3 = New System.Windows.Forms.Label()
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
      Me.Label4.Location = New System.Drawing.Point(50, 63)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(56, 13)
      Me.Label4.TabIndex = 108
      Me.Label4.Text = "Cuenta Nº"
      '
      'tbDescBanco
      '
      Me.tbDescBanco.BackColor = System.Drawing.Color.LightYellow
      Me.tbDescBanco.Enabled = False
      Me.tbDescBanco.Location = New System.Drawing.Point(112, 34)
      Me.tbDescBanco.Name = "tbDescBanco"
      Me.tbDescBanco.Size = New System.Drawing.Size(514, 20)
      Me.tbDescBanco.TabIndex = 107
      '
      'tbCtaBco
      '
      Me.tbCtaBco.BackColor = System.Drawing.Color.LightYellow
      Me.tbCtaBco.Enabled = False
      Me.tbCtaBco.Location = New System.Drawing.Point(112, 60)
      Me.tbCtaBco.Name = "tbCtaBco"
      Me.tbCtaBco.Size = New System.Drawing.Size(265, 20)
      Me.tbCtaBco.TabIndex = 109
      '
      'lblCuenta
      '
      Me.lblCuenta.AutoSize = True
      Me.lblCuenta.Location = New System.Drawing.Point(52, 108)
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
      Me.cbDescCta.Location = New System.Drawing.Point(252, 105)
      Me.cbDescCta.Name = "cbDescCta"
      Me.cbDescCta.Size = New System.Drawing.Size(442, 21)
      Me.cbDescCta.TabIndex = 111
      '
      'tbCuenta
      '
      Me.tbCuenta.Location = New System.Drawing.Point(112, 105)
      Me.tbCuenta.Name = "tbCuenta"
      Me.tbCuenta.Size = New System.Drawing.Size(134, 20)
      Me.tbCuenta.TabIndex = 112
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.Location = New System.Drawing.Point(38, 309)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(79, 13)
      Me.Label5.TabIndex = 120
      Me.Label5.Text = "Fecha Acredit.:"
      '
      'tbFechaAcr
      '
      Me.tbFechaAcr.Enabled = False
      Me.tbFechaAcr.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.tbFechaAcr.Location = New System.Drawing.Point(132, 307)
      Me.tbFechaAcr.Name = "tbFechaAcr"
      Me.tbFechaAcr.Size = New System.Drawing.Size(86, 20)
      Me.tbFechaAcr.TabIndex = 119
      '
      'cmdCancelar
      '
      Me.cmdCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdCancelar.Location = New System.Drawing.Point(618, 468)
      Me.cmdCancelar.Name = "cmdCancelar"
      Me.cmdCancelar.Size = New System.Drawing.Size(76, 27)
      Me.cmdCancelar.TabIndex = 124
      Me.cmdCancelar.Text = "&Cancelar"
      Me.cmdCancelar.UseVisualStyleBackColor = True
      '
      'lblDetObs
      '
      Me.lblDetObs.AutoSize = True
      Me.lblDetObs.Location = New System.Drawing.Point(38, 380)
      Me.lblDetObs.Name = "lblDetObs"
      Me.lblDetObs.Size = New System.Drawing.Size(88, 13)
      Me.lblDetObs.TabIndex = 126
      Me.lblDetObs.Text = "Motivo Rechazo:"
      '
      'tbDetalle
      '
      Me.tbDetalle.Location = New System.Drawing.Point(132, 377)
      Me.tbDetalle.Multiline = True
      Me.tbDetalle.Name = "tbDetalle"
      Me.tbDetalle.Size = New System.Drawing.Size(562, 74)
      Me.tbDetalle.TabIndex = 125
      '
      'Label9
      '
      Me.Label9.AutoSize = True
      Me.Label9.Location = New System.Drawing.Point(69, 187)
      Me.Label9.Name = "Label9"
      Me.Label9.Size = New System.Drawing.Size(41, 13)
      Me.Label9.TabIndex = 131
      Me.Label9.Text = "Banco:"
      '
      'Label10
      '
      Me.Label10.AutoSize = True
      Me.Label10.Location = New System.Drawing.Point(66, 213)
      Me.Label10.Name = "Label10"
      Me.Label10.Size = New System.Drawing.Size(44, 13)
      Me.Label10.TabIndex = 133
      Me.Label10.Text = "Cuenta:"
      '
      'Label11
      '
      Me.Label11.AutoSize = True
      Me.Label11.Location = New System.Drawing.Point(55, 239)
      Me.Label11.Name = "Label11"
      Me.Label11.Size = New System.Drawing.Size(54, 13)
      Me.Label11.TabIndex = 134
      Me.Label11.Text = "Número #"
      '
      'Label13
      '
      Me.Label13.AutoSize = True
      Me.Label13.Location = New System.Drawing.Point(273, 239)
      Me.Label13.Name = "Label13"
      Me.Label13.Size = New System.Drawing.Size(51, 13)
      Me.Label13.TabIndex = 136
      Me.Label13.Text = "Importe $"
      '
      'cmdAceptar
      '
      Me.cmdAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdAceptar.Location = New System.Drawing.Point(536, 468)
      Me.cmdAceptar.Name = "cmdAceptar"
      Me.cmdAceptar.Size = New System.Drawing.Size(76, 27)
      Me.cmdAceptar.TabIndex = 139
      Me.cmdAceptar.Text = "&Rechazar"
      Me.cmdAceptar.UseVisualStyleBackColor = True
      '
      'Label12
      '
      Me.Label12.AutoSize = True
      Me.Label12.Location = New System.Drawing.Point(75, 152)
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
      Me.cbCaja.Location = New System.Drawing.Point(112, 149)
      Me.cbCaja.Name = "cbCaja"
      Me.cbCaja.Size = New System.Drawing.Size(206, 21)
      Me.cbCaja.TabIndex = 141
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(38, 345)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(86, 13)
      Me.Label1.TabIndex = 144
      Me.Label1.Text = "Fecha Rechazo:"
      '
      'dtpFechaRech
      '
      Me.dtpFechaRech.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpFechaRech.Location = New System.Drawing.Point(132, 342)
      Me.dtpFechaRech.Name = "dtpFechaRech"
      Me.dtpFechaRech.Size = New System.Drawing.Size(86, 20)
      Me.dtpFechaRech.TabIndex = 143
      '
      'tbBancoCh
      '
      Me.tbBancoCh.BackColor = System.Drawing.Color.LightYellow
      Me.tbBancoCh.Enabled = False
      Me.tbBancoCh.Location = New System.Drawing.Point(112, 184)
      Me.tbBancoCh.Name = "tbBancoCh"
      Me.tbBancoCh.Size = New System.Drawing.Size(514, 20)
      Me.tbBancoCh.TabIndex = 145
      '
      'tbCuentaCh
      '
      Me.tbCuentaCh.BackColor = System.Drawing.Color.LightYellow
      Me.tbCuentaCh.Enabled = False
      Me.tbCuentaCh.Location = New System.Drawing.Point(112, 210)
      Me.tbCuentaCh.Name = "tbCuentaCh"
      Me.tbCuentaCh.Size = New System.Drawing.Size(265, 20)
      Me.tbCuentaCh.TabIndex = 146
      '
      'tbNumeroCh
      '
      Me.tbNumeroCh.BackColor = System.Drawing.Color.LightYellow
      Me.tbNumeroCh.Enabled = False
      Me.tbNumeroCh.Location = New System.Drawing.Point(112, 236)
      Me.tbNumeroCh.Name = "tbNumeroCh"
      Me.tbNumeroCh.Size = New System.Drawing.Size(131, 20)
      Me.tbNumeroCh.TabIndex = 147
      '
      'tbImporteCh
      '
      Me.tbImporteCh.BackColor = System.Drawing.Color.LightYellow
      Me.tbImporteCh.Enabled = False
      Me.tbImporteCh.Location = New System.Drawing.Point(330, 236)
      Me.tbImporteCh.Name = "tbImporteCh"
      Me.tbImporteCh.Size = New System.Drawing.Size(131, 20)
      Me.tbImporteCh.TabIndex = 148
      '
      'tbCliente
      '
      Me.tbCliente.BackColor = System.Drawing.Color.LightYellow
      Me.tbCliente.Enabled = False
      Me.tbCliente.Location = New System.Drawing.Point(112, 271)
      Me.tbCliente.Name = "tbCliente"
      Me.tbCliente.Size = New System.Drawing.Size(419, 20)
      Me.tbCliente.TabIndex = 156
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(68, 274)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(42, 13)
      Me.Label3.TabIndex = 155
      Me.Label3.Text = "Cliente:"
      '
      'frmChRechAM
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(706, 507)
      Me.Controls.Add(Me.tbCliente)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.tbImporteCh)
      Me.Controls.Add(Me.tbNumeroCh)
      Me.Controls.Add(Me.tbCuentaCh)
      Me.Controls.Add(Me.tbBancoCh)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.dtpFechaRech)
      Me.Controls.Add(Me.Label13)
      Me.Controls.Add(Me.Label12)
      Me.Controls.Add(Me.cbCaja)
      Me.Controls.Add(Me.Label11)
      Me.Controls.Add(Me.Label10)
      Me.Controls.Add(Me.Label9)
      Me.Controls.Add(Me.cmdAceptar)
      Me.Controls.Add(Me.lblDetObs)
      Me.Controls.Add(Me.tbDetalle)
      Me.Controls.Add(Me.cmdCancelar)
      Me.Controls.Add(Me.Label5)
      Me.Controls.Add(Me.tbFechaAcr)
      Me.Controls.Add(Me.tbCuenta)
      Me.Controls.Add(Me.cbDescCta)
      Me.Controls.Add(Me.lblCuenta)
      Me.Controls.Add(Me.tbCtaBco)
      Me.Controls.Add(Me.Label4)
      Me.Controls.Add(Me.tbDescBanco)
      Me.Controls.Add(Me.Label2)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.KeyPreview = True
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "frmChRechAM"
      Me.Text = "Rechazar Cheque"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents tbDescBanco As System.Windows.Forms.TextBox
   Friend WithEvents tbCtaBco As System.Windows.Forms.TextBox
   Friend WithEvents lblCuenta As System.Windows.Forms.Label
   Friend WithEvents cbDescCta As System.Windows.Forms.ComboBox
   Friend WithEvents tbCuenta As System.Windows.Forms.TextBox
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents tbFechaAcr As System.Windows.Forms.DateTimePicker
   Friend WithEvents cmdCancelar As System.Windows.Forms.Button
   Friend WithEvents lblDetObs As System.Windows.Forms.Label
   Friend WithEvents tbDetalle As System.Windows.Forms.TextBox
   Friend WithEvents Label9 As System.Windows.Forms.Label
   Friend WithEvents Label10 As System.Windows.Forms.Label
   Friend WithEvents Label11 As System.Windows.Forms.Label
   Friend WithEvents cmdAceptar As System.Windows.Forms.Button
   Friend WithEvents Label12 As System.Windows.Forms.Label
   Friend WithEvents cbCaja As System.Windows.Forms.ComboBox
   Friend WithEvents Label13 As System.Windows.Forms.Label
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents dtpFechaRech As System.Windows.Forms.DateTimePicker
   Friend WithEvents tbBancoCh As System.Windows.Forms.TextBox
   Friend WithEvents tbCuentaCh As System.Windows.Forms.TextBox
   Friend WithEvents tbNumeroCh As System.Windows.Forms.TextBox
   Friend WithEvents tbImporteCh As System.Windows.Forms.TextBox
   Friend WithEvents tbCliente As System.Windows.Forms.TextBox
   Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
