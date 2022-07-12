<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCajaTransf
   Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.cboCaja1 = New System.Windows.Forms.ComboBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.cboCaja2 = New System.Windows.Forms.ComboBox()
      Me.tbComprob = New System.Windows.Forms.TextBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.optEfectivo = New System.Windows.Forms.RadioButton()
      Me.optCheque = New System.Windows.Forms.RadioButton()
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.cboCtaBanco = New System.Windows.Forms.ComboBox()
      Me.lblNroCheque = New System.Windows.Forms.Label()
      Me.cboNumero = New System.Windows.Forms.ComboBox()
      Me.lblCtaBco = New System.Windows.Forms.Label()
      Me.lblBanco = New System.Windows.Forms.Label()
      Me.cboBanco = New System.Windows.Forms.ComboBox()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.txtImporte = New System.Windows.Forms.TextBox()
      Me.txtDetalle = New System.Windows.Forms.TextBox()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.btnCancelar = New System.Windows.Forms.Button()
      Me.cmdAceptar = New System.Windows.Forms.Button()
      Me.Panel1.SuspendLayout()
      Me.SuspendLayout()
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(35, 75)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(48, 13)
      Me.Label2.TabIndex = 80
      Me.Label2.Text = "De Caja:"
      '
      'cboCaja1
      '
      Me.cboCaja1.Enabled = False
      Me.cboCaja1.FormattingEnabled = True
      Me.cboCaja1.Location = New System.Drawing.Point(89, 72)
      Me.cboCaja1.Name = "cboCaja1"
      Me.cboCaja1.Size = New System.Drawing.Size(220, 21)
      Me.cboCaja1.TabIndex = 79
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(333, 75)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(41, 13)
      Me.Label1.TabIndex = 82
      Me.Label1.Text = "A Caja:"
      '
      'cboCaja2
      '
      Me.cboCaja2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboCaja2.FormattingEnabled = True
      Me.cboCaja2.Location = New System.Drawing.Point(380, 72)
      Me.cboCaja2.Name = "cboCaja2"
      Me.cboCaja2.Size = New System.Drawing.Size(217, 21)
      Me.cboCaja2.TabIndex = 81
      '
      'tbComprob
      '
      Me.tbComprob.Enabled = False
      Me.tbComprob.Location = New System.Drawing.Point(89, 22)
      Me.tbComprob.Name = "tbComprob"
      Me.tbComprob.Size = New System.Drawing.Size(206, 20)
      Me.tbComprob.TabIndex = 83
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(10, 25)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(73, 13)
      Me.Label3.TabIndex = 84
      Me.Label3.Text = "Comprobante:"
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(26, 129)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(57, 13)
      Me.Label4.TabIndex = 85
      Me.Label4.Text = "Transfiere:"
      '
      'optEfectivo
      '
      Me.optEfectivo.AutoSize = True
      Me.optEfectivo.Checked = True
      Me.optEfectivo.Location = New System.Drawing.Point(89, 127)
      Me.optEfectivo.Name = "optEfectivo"
      Me.optEfectivo.Size = New System.Drawing.Size(64, 17)
      Me.optEfectivo.TabIndex = 86
      Me.optEfectivo.TabStop = True
      Me.optEfectivo.Text = "&Efectivo"
      Me.optEfectivo.UseVisualStyleBackColor = True
      '
      'optCheque
      '
      Me.optCheque.AutoSize = True
      Me.optCheque.Location = New System.Drawing.Point(196, 127)
      Me.optCheque.Name = "optCheque"
      Me.optCheque.Size = New System.Drawing.Size(113, 17)
      Me.optCheque.TabIndex = 87
      Me.optCheque.Text = "&Cheque en cartera"
      Me.optCheque.UseVisualStyleBackColor = True
      '
      'Panel1
      '
      Me.Panel1.Controls.Add(Me.cboCtaBanco)
      Me.Panel1.Controls.Add(Me.lblNroCheque)
      Me.Panel1.Controls.Add(Me.cboNumero)
      Me.Panel1.Controls.Add(Me.lblCtaBco)
      Me.Panel1.Controls.Add(Me.lblBanco)
      Me.Panel1.Controls.Add(Me.cboBanco)
      Me.Panel1.Enabled = False
      Me.Panel1.Location = New System.Drawing.Point(196, 165)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(411, 110)
      Me.Panel1.TabIndex = 88
      '
      'cboCtaBanco
      '
      Me.cboCtaBanco.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      Me.cboCtaBanco.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.cboCtaBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboCtaBanco.Enabled = False
      Me.cboCtaBanco.FormattingEnabled = True
      Me.cboCtaBanco.Location = New System.Drawing.Point(75, 79)
      Me.cboCtaBanco.Name = "cboCtaBanco"
      Me.cboCtaBanco.Size = New System.Drawing.Size(194, 21)
      Me.cboCtaBanco.TabIndex = 111
      '
      'lblNroCheque
      '
      Me.lblNroCheque.AutoSize = True
      Me.lblNroCheque.Location = New System.Drawing.Point(7, 52)
      Me.lblNroCheque.Name = "lblNroCheque"
      Me.lblNroCheque.Size = New System.Drawing.Size(62, 13)
      Me.lblNroCheque.TabIndex = 110
      Me.lblNroCheque.Text = "Nº Cheque:"
      '
      'cboNumero
      '
      Me.cboNumero.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      Me.cboNumero.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.cboNumero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboNumero.FormattingEnabled = True
      Me.cboNumero.Location = New System.Drawing.Point(75, 49)
      Me.cboNumero.Name = "cboNumero"
      Me.cboNumero.Size = New System.Drawing.Size(194, 21)
      Me.cboNumero.TabIndex = 107
      '
      'lblCtaBco
      '
      Me.lblCtaBco.AutoSize = True
      Me.lblCtaBco.Location = New System.Drawing.Point(25, 82)
      Me.lblCtaBco.Name = "lblCtaBco"
      Me.lblCtaBco.Size = New System.Drawing.Size(44, 13)
      Me.lblCtaBco.TabIndex = 109
      Me.lblCtaBco.Text = "Nº Cta.:"
      '
      'lblBanco
      '
      Me.lblBanco.AutoSize = True
      Me.lblBanco.Location = New System.Drawing.Point(28, 20)
      Me.lblBanco.Name = "lblBanco"
      Me.lblBanco.Size = New System.Drawing.Size(41, 13)
      Me.lblBanco.TabIndex = 108
      Me.lblBanco.Text = "Banco:"
      '
      'cboBanco
      '
      Me.cboBanco.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      Me.cboBanco.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.cboBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboBanco.FormattingEnabled = True
      Me.cboBanco.Location = New System.Drawing.Point(75, 17)
      Me.cboBanco.Name = "cboBanco"
      Me.cboBanco.Size = New System.Drawing.Size(326, 21)
      Me.cboBanco.TabIndex = 105
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.Location = New System.Drawing.Point(32, 218)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(51, 13)
      Me.Label5.TabIndex = 90
      Me.Label5.Text = "Importe $"
      '
      'txtImporte
      '
      Me.txtImporte.Location = New System.Drawing.Point(89, 215)
      Me.txtImporte.Name = "txtImporte"
      Me.txtImporte.Size = New System.Drawing.Size(101, 20)
      Me.txtImporte.TabIndex = 89
      '
      'txtDetalle
      '
      Me.txtDetalle.Location = New System.Drawing.Point(89, 299)
      Me.txtDetalle.Multiline = True
      Me.txtDetalle.Name = "txtDetalle"
      Me.txtDetalle.Size = New System.Drawing.Size(518, 72)
      Me.txtDetalle.TabIndex = 91
      '
      'Label6
      '
      Me.Label6.AutoSize = True
      Me.Label6.Location = New System.Drawing.Point(32, 302)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(43, 13)
      Me.Label6.TabIndex = 92
      Me.Label6.Text = "Detalle:"
      '
      'btnCancelar
      '
      Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btnCancelar.Location = New System.Drawing.Point(544, 388)
      Me.btnCancelar.Name = "btnCancelar"
      Me.btnCancelar.Size = New System.Drawing.Size(63, 27)
      Me.btnCancelar.TabIndex = 94
      Me.btnCancelar.Text = "&Cancelar"
      Me.btnCancelar.UseVisualStyleBackColor = True
      '
      'cmdAceptar
      '
      Me.cmdAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdAceptar.Location = New System.Drawing.Point(449, 388)
      Me.cmdAceptar.Name = "cmdAceptar"
      Me.cmdAceptar.Size = New System.Drawing.Size(89, 27)
      Me.cmdAceptar.TabIndex = 93
      Me.cmdAceptar.Text = "&Aceptar"
      Me.cmdAceptar.UseVisualStyleBackColor = True
      '
      'frmCajaTransf
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(619, 427)
      Me.Controls.Add(Me.btnCancelar)
      Me.Controls.Add(Me.cmdAceptar)
      Me.Controls.Add(Me.Label6)
      Me.Controls.Add(Me.txtDetalle)
      Me.Controls.Add(Me.Label5)
      Me.Controls.Add(Me.txtImporte)
      Me.Controls.Add(Me.Panel1)
      Me.Controls.Add(Me.optCheque)
      Me.Controls.Add(Me.optEfectivo)
      Me.Controls.Add(Me.Label4)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.tbComprob)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.cboCaja2)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.cboCaja1)
      Me.KeyPreview = True
      Me.Name = "frmCajaTransf"
      Me.Text = "Transferencia de Cajas"
      Me.Panel1.ResumeLayout(False)
      Me.Panel1.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents cboCaja1 As System.Windows.Forms.ComboBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents cboCaja2 As System.Windows.Forms.ComboBox
   Friend WithEvents tbComprob As System.Windows.Forms.TextBox
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents optEfectivo As System.Windows.Forms.RadioButton
   Friend WithEvents optCheque As System.Windows.Forms.RadioButton
   Friend WithEvents Panel1 As System.Windows.Forms.Panel
   Friend WithEvents lblNroCheque As System.Windows.Forms.Label
   Friend WithEvents cboNumero As System.Windows.Forms.ComboBox
   Friend WithEvents lblCtaBco As System.Windows.Forms.Label
   Friend WithEvents lblBanco As System.Windows.Forms.Label
   Friend WithEvents cboBanco As System.Windows.Forms.ComboBox
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents txtImporte As System.Windows.Forms.TextBox
   Friend WithEvents txtDetalle As System.Windows.Forms.TextBox
   Friend WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents btnCancelar As System.Windows.Forms.Button
   Friend WithEvents cmdAceptar As System.Windows.Forms.Button
   Friend WithEvents cboCtaBanco As System.Windows.Forms.ComboBox
End Class
