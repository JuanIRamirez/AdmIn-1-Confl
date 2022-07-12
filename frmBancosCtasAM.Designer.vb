<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBancosCtasAM
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
      Me.gbCuenta = New System.Windows.Forms.GroupBox()
      Me.Label7 = New System.Windows.Forms.Label()
      Me.tbCtaBco = New System.Windows.Forms.TextBox()
      Me.tbDescrip = New System.Windows.Forms.TextBox()
      Me.Label8 = New System.Windows.Forms.Label()
      Me.btnAceptarCta = New System.Windows.Forms.Button()
      Me.tbTitular = New System.Windows.Forms.TextBox()
      Me.btnCancelarCta = New System.Windows.Forms.Button()
      Me.Label9 = New System.Windows.Forms.Label()
      Me.lblCtaCont = New System.Windows.Forms.Label()
      Me.tbSaldoIni = New System.Windows.Forms.TextBox()
      Me.cboCtaCont = New System.Windows.Forms.ComboBox()
      Me.Label10 = New System.Windows.Forms.Label()
      Me.dtpFechaSdo = New System.Windows.Forms.DateTimePicker()
      Me.Label11 = New System.Windows.Forms.Label()
      Me.tbBanco = New System.Windows.Forms.TextBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.gbCuenta.SuspendLayout()
      Me.SuspendLayout()
      '
      'gbCuenta
      '
      Me.gbCuenta.Controls.Add(Me.Label7)
      Me.gbCuenta.Controls.Add(Me.tbCtaBco)
      Me.gbCuenta.Controls.Add(Me.tbDescrip)
      Me.gbCuenta.Controls.Add(Me.Label8)
      Me.gbCuenta.Controls.Add(Me.btnAceptarCta)
      Me.gbCuenta.Controls.Add(Me.tbTitular)
      Me.gbCuenta.Controls.Add(Me.btnCancelarCta)
      Me.gbCuenta.Controls.Add(Me.Label9)
      Me.gbCuenta.Controls.Add(Me.lblCtaCont)
      Me.gbCuenta.Controls.Add(Me.tbSaldoIni)
      Me.gbCuenta.Controls.Add(Me.cboCtaCont)
      Me.gbCuenta.Controls.Add(Me.Label10)
      Me.gbCuenta.Controls.Add(Me.dtpFechaSdo)
      Me.gbCuenta.Controls.Add(Me.Label11)
      Me.gbCuenta.Location = New System.Drawing.Point(12, 39)
      Me.gbCuenta.Name = "gbCuenta"
      Me.gbCuenta.Size = New System.Drawing.Size(590, 287)
      Me.gbCuenta.TabIndex = 150
      Me.gbCuenta.TabStop = False
      '
      'Label7
      '
      Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label7.AutoSize = True
      Me.Label7.Location = New System.Drawing.Point(44, 42)
      Me.Label7.Name = "Label7"
      Me.Label7.Size = New System.Drawing.Size(59, 13)
      Me.Label7.TabIndex = 132
      Me.Label7.Text = "Nº Cuenta:"
      '
      'tbCtaBco
      '
      Me.tbCtaBco.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tbCtaBco.Location = New System.Drawing.Point(109, 39)
      Me.tbCtaBco.MaxLength = 10
      Me.tbCtaBco.Name = "tbCtaBco"
      Me.tbCtaBco.Size = New System.Drawing.Size(134, 20)
      Me.tbCtaBco.TabIndex = 131
      '
      'tbDescrip
      '
      Me.tbDescrip.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tbDescrip.Location = New System.Drawing.Point(109, 71)
      Me.tbDescrip.MaxLength = 50
      Me.tbDescrip.Name = "tbDescrip"
      Me.tbDescrip.Size = New System.Drawing.Size(439, 20)
      Me.tbDescrip.TabIndex = 133
      '
      'Label8
      '
      Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label8.AutoSize = True
      Me.Label8.Location = New System.Drawing.Point(37, 74)
      Me.Label8.Name = "Label8"
      Me.Label8.Size = New System.Drawing.Size(66, 13)
      Me.Label8.TabIndex = 134
      Me.Label8.Text = "Descripción:"
      '
      'btnAceptarCta
      '
      Me.btnAceptarCta.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnAceptarCta.Location = New System.Drawing.Point(392, 248)
      Me.btnAceptarCta.Name = "btnAceptarCta"
      Me.btnAceptarCta.Size = New System.Drawing.Size(75, 23)
      Me.btnAceptarCta.TabIndex = 145
      Me.btnAceptarCta.Text = "&Aceptar"
      Me.btnAceptarCta.UseVisualStyleBackColor = True
      '
      'tbTitular
      '
      Me.tbTitular.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tbTitular.Location = New System.Drawing.Point(109, 102)
      Me.tbTitular.MaxLength = 50
      Me.tbTitular.Name = "tbTitular"
      Me.tbTitular.Size = New System.Drawing.Size(439, 20)
      Me.tbTitular.TabIndex = 135
      '
      'btnCancelarCta
      '
      Me.btnCancelarCta.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnCancelarCta.Location = New System.Drawing.Point(473, 248)
      Me.btnCancelarCta.Name = "btnCancelarCta"
      Me.btnCancelarCta.Size = New System.Drawing.Size(75, 23)
      Me.btnCancelarCta.TabIndex = 144
      Me.btnCancelarCta.Text = "&Cancelar"
      Me.btnCancelarCta.UseVisualStyleBackColor = True
      '
      'Label9
      '
      Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label9.AutoSize = True
      Me.Label9.Location = New System.Drawing.Point(64, 105)
      Me.Label9.Name = "Label9"
      Me.Label9.Size = New System.Drawing.Size(39, 13)
      Me.Label9.TabIndex = 136
      Me.Label9.Text = "Titular:"
      '
      'lblCtaCont
      '
      Me.lblCtaCont.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblCtaCont.AutoSize = True
      Me.lblCtaCont.Location = New System.Drawing.Point(46, 205)
      Me.lblCtaCont.Name = "lblCtaCont"
      Me.lblCtaCont.Size = New System.Drawing.Size(57, 13)
      Me.lblCtaCont.TabIndex = 143
      Me.lblCtaCont.Text = "Cta. Cont.:"
      '
      'tbSaldoIni
      '
      Me.tbSaldoIni.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tbSaldoIni.Location = New System.Drawing.Point(109, 136)
      Me.tbSaldoIni.MaxLength = 10
      Me.tbSaldoIni.Name = "tbSaldoIni"
      Me.tbSaldoIni.Size = New System.Drawing.Size(82, 20)
      Me.tbSaldoIni.TabIndex = 137
      '
      'cboCtaCont
      '
      Me.cboCtaCont.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cboCtaCont.FormattingEnabled = True
      Me.cboCtaCont.Location = New System.Drawing.Point(109, 202)
      Me.cboCtaCont.Name = "cboCtaCont"
      Me.cboCtaCont.Size = New System.Drawing.Size(439, 21)
      Me.cboCtaCont.TabIndex = 142
      '
      'Label10
      '
      Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label10.AutoSize = True
      Me.Label10.Location = New System.Drawing.Point(30, 139)
      Me.Label10.Name = "Label10"
      Me.Label10.Size = New System.Drawing.Size(73, 13)
      Me.Label10.TabIndex = 138
      Me.Label10.Text = "Saldo Inicial $"
      '
      'dtpFechaSdo
      '
      Me.dtpFechaSdo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.dtpFechaSdo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpFechaSdo.Location = New System.Drawing.Point(109, 169)
      Me.dtpFechaSdo.Name = "dtpFechaSdo"
      Me.dtpFechaSdo.Size = New System.Drawing.Size(89, 20)
      Me.dtpFechaSdo.TabIndex = 141
      '
      'Label11
      '
      Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label11.AutoSize = True
      Me.Label11.Location = New System.Drawing.Point(38, 171)
      Me.Label11.Name = "Label11"
      Me.Label11.Size = New System.Drawing.Size(65, 13)
      Me.Label11.TabIndex = 140
      Me.Label11.Text = "Fecha Sdo.:"
      '
      'tbBanco
      '
      Me.tbBanco.Enabled = False
      Me.tbBanco.Location = New System.Drawing.Point(59, 12)
      Me.tbBanco.MaxLength = 10
      Me.tbBanco.Name = "tbBanco"
      Me.tbBanco.Size = New System.Drawing.Size(543, 20)
      Me.tbBanco.TabIndex = 154
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(12, 15)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(41, 13)
      Me.Label1.TabIndex = 155
      Me.Label1.Text = "Banco:"
      '
      'frmBancosCtasAM
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(610, 338)
      Me.Controls.Add(Me.tbBanco)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.gbCuenta)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.KeyPreview = True
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "frmBancosCtasAM"
      Me.Text = "Cuentas Banco"
      Me.gbCuenta.ResumeLayout(False)
      Me.gbCuenta.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents gbCuenta As System.Windows.Forms.GroupBox
   Friend WithEvents Label7 As System.Windows.Forms.Label
   Friend WithEvents tbCtaBco As System.Windows.Forms.TextBox
   Friend WithEvents tbDescrip As System.Windows.Forms.TextBox
   Friend WithEvents Label8 As System.Windows.Forms.Label
   Friend WithEvents btnAceptarCta As System.Windows.Forms.Button
   Friend WithEvents tbTitular As System.Windows.Forms.TextBox
   Friend WithEvents btnCancelarCta As System.Windows.Forms.Button
   Friend WithEvents Label9 As System.Windows.Forms.Label
   Friend WithEvents lblCtaCont As System.Windows.Forms.Label
   Friend WithEvents tbSaldoIni As System.Windows.Forms.TextBox
   Friend WithEvents cboCtaCont As System.Windows.Forms.ComboBox
   Friend WithEvents Label10 As System.Windows.Forms.Label
   Friend WithEvents dtpFechaSdo As System.Windows.Forms.DateTimePicker
   Friend WithEvents Label11 As System.Windows.Forms.Label
   Friend WithEvents tbBanco As System.Windows.Forms.TextBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
