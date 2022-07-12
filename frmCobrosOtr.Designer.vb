<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCobrosOtr
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
      Me.cbProp = New System.Windows.Forms.ComboBox()
      Me.lblProp = New System.Windows.Forms.Label()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.cbTipoIva = New System.Windows.Forms.ComboBox()
      Me.tbNumero = New System.Windows.Forms.TextBox()
      Me.lblLetra = New System.Windows.Forms.Label()
      Me.tbSucursal = New System.Windows.Forms.TextBox()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.cbCliInq = New System.Windows.Forms.ComboBox()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.Label7 = New System.Windows.Forms.Label()
      Me.tbEfectivo = New System.Windows.Forms.TextBox()
      Me.cmdGenerar = New System.Windows.Forms.Button()
      Me.cmdCancelar = New System.Windows.Forms.Button()
      Me.tbCuit = New System.Windows.Forms.MaskedTextBox()
      Me.Label8 = New System.Windows.Forms.Label()
      Me.tbDomicilio = New System.Windows.Forms.TextBox()
      Me.Label9 = New System.Windows.Forms.Label()
      Me.cmdModif = New System.Windows.Forms.Button()
      Me.cmdBaja = New System.Windows.Forms.Button()
      Me.cmdAlta = New System.Windows.Forms.Button()
      Me.cmdAceptar = New System.Windows.Forms.Button()
      Me.cmdSalir = New System.Windows.Forms.Button()
      Me.DataGridView1 = New System.Windows.Forms.DataGridView()
      Me.tbTotal = New System.Windows.Forms.TextBox()
      Me.Label10 = New System.Windows.Forms.Label()
      Me.Label14 = New System.Windows.Forms.Label()
      Me.tbDetalle = New System.Windows.Forms.TextBox()
      Me.txtTransferencia = New System.Windows.Forms.TextBox()
      Me.tbCheques = New System.Windows.Forms.TextBox()
      Me.cmdIngCheques = New System.Windows.Forms.Button()
      Me.cmdTransferencia = New System.Windows.Forms.Button()
      Me.chkInquilinos = New System.Windows.Forms.CheckBox()
      Me.chkPropiet = New System.Windows.Forms.CheckBox()
        Me.lblPropietario = New System.Windows.Forms.Label()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cbProp
        '
        Me.cbProp.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbProp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbProp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbProp.FormattingEnabled = True
        Me.cbProp.Location = New System.Drawing.Point(81, 75)
        Me.cbProp.Name = "cbProp"
        Me.cbProp.Size = New System.Drawing.Size(402, 21)
        Me.cbProp.TabIndex = 8
        '
        'lblProp
        '
        Me.lblProp.AutoSize = True
        Me.lblProp.Location = New System.Drawing.Point(10, 78)
        Me.lblProp.Name = "lblProp"
        Me.lblProp.Size = New System.Drawing.Size(60, 13)
        Me.lblProp.TabIndex = 74
        Me.lblProp.Text = "Propietario:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 13)
        Me.Label3.TabIndex = 78
        Me.Label3.Text = "Tipo de IVA:"
        '
        'cbTipoIva
        '
        Me.cbTipoIva.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbTipoIva.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbTipoIva.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTipoIva.FormattingEnabled = True
        Me.cbTipoIva.Location = New System.Drawing.Point(76, 45)
        Me.cbTipoIva.Name = "cbTipoIva"
        Me.cbTipoIva.Size = New System.Drawing.Size(122, 21)
        Me.cbTipoIva.TabIndex = 5
        '
        'tbNumero
        '
        Me.tbNumero.Enabled = False
        Me.tbNumero.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbNumero.Location = New System.Drawing.Point(766, 17)
        Me.tbNumero.Name = "tbNumero"
        Me.tbNumero.Size = New System.Drawing.Size(77, 20)
        Me.tbNumero.TabIndex = 4
        '
        'lblLetra
        '
        Me.lblLetra.AutoSize = True
        Me.lblLetra.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLetra.Location = New System.Drawing.Point(700, 20)
        Me.lblLetra.Name = "lblLetra"
        Me.lblLetra.Size = New System.Drawing.Size(15, 13)
        Me.lblLetra.TabIndex = 93
        Me.lblLetra.Text = "X"
        '
        'tbSucursal
        '
        Me.tbSucursal.Enabled = False
        Me.tbSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbSucursal.Location = New System.Drawing.Point(721, 17)
        Me.tbSucursal.Name = "tbSucursal"
        Me.tbSucursal.Size = New System.Drawing.Size(39, 20)
        Me.tbSucursal.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(650, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 13)
        Me.Label5.TabIndex = 92
        Me.Label5.Text = "Recibo:"
        '
        'cbCliInq
        '
        Me.cbCliInq.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbCliInq.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbCliInq.FormattingEnabled = True
        Me.cbCliInq.Location = New System.Drawing.Point(57, 16)
        Me.cbCliInq.Name = "cbCliInq"
        Me.cbCliInq.Size = New System.Drawing.Size(414, 21)
        Me.cbCliInq.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 20)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 13)
        Me.Label6.TabIndex = 95
        Me.Label6.Text = "Cliente:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(682, 423)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(55, 13)
        Me.Label7.TabIndex = 100
        Me.Label7.Text = "Efectivo $"
        '
        'tbEfectivo
        '
        Me.tbEfectivo.Location = New System.Drawing.Point(743, 420)
        Me.tbEfectivo.Name = "tbEfectivo"
        Me.tbEfectivo.Size = New System.Drawing.Size(100, 20)
        Me.tbEfectivo.TabIndex = 97
        '
        'cmdGenerar
        '
        Me.cmdGenerar.Location = New System.Drawing.Point(674, 530)
        Me.cmdGenerar.Name = "cmdGenerar"
        Me.cmdGenerar.Size = New System.Drawing.Size(88, 25)
        Me.cmdGenerar.TabIndex = 102
        Me.cmdGenerar.Text = "&Guardar"
        Me.cmdGenerar.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Location = New System.Drawing.Point(768, 530)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(75, 25)
        Me.cmdCancelar.TabIndex = 101
        Me.cmdCancelar.Text = "&Cancelar"
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'tbCuit
        '
        Me.tbCuit.Location = New System.Drawing.Point(256, 44)
        Me.tbCuit.Mask = "##-########-#"
        Me.tbCuit.Name = "tbCuit"
        Me.tbCuit.Size = New System.Drawing.Size(100, 20)
        Me.tbCuit.TabIndex = 6
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(215, 48)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(35, 13)
        Me.Label8.TabIndex = 104
        Me.Label8.Text = "CUIT:"
        '
        'tbDomicilio
        '
        Me.tbDomicilio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbDomicilio.Location = New System.Drawing.Point(433, 44)
        Me.tbDomicilio.Name = "tbDomicilio"
        Me.tbDomicilio.Size = New System.Drawing.Size(410, 20)
        Me.tbDomicilio.TabIndex = 7
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(375, 47)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(52, 13)
        Me.Label9.TabIndex = 106
        Me.Label9.Text = "Domicilio:"
        '
        'cmdModif
        '
        Me.cmdModif.Location = New System.Drawing.Point(174, 397)
        Me.cmdModif.Name = "cmdModif"
        Me.cmdModif.Size = New System.Drawing.Size(75, 23)
        Me.cmdModif.TabIndex = 109
        Me.cmdModif.Text = "&Modificar"
        Me.cmdModif.UseVisualStyleBackColor = True
        '
        'cmdBaja
        '
        Me.cmdBaja.Location = New System.Drawing.Point(93, 397)
        Me.cmdBaja.Name = "cmdBaja"
        Me.cmdBaja.Size = New System.Drawing.Size(75, 23)
        Me.cmdBaja.TabIndex = 108
        Me.cmdBaja.Text = "&Quitar"
        Me.cmdBaja.UseVisualStyleBackColor = True
        '
        'cmdAlta
        '
        Me.cmdAlta.Location = New System.Drawing.Point(12, 397)
        Me.cmdAlta.Name = "cmdAlta"
        Me.cmdAlta.Size = New System.Drawing.Size(75, 23)
        Me.cmdAlta.TabIndex = 107
        Me.cmdAlta.Text = "A&gregar"
        Me.cmdAlta.UseVisualStyleBackColor = True
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Location = New System.Drawing.Point(674, 102)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(88, 25)
        Me.cmdAceptar.TabIndex = 9
        Me.cmdAceptar.Text = "&Aceptar"
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'cmdSalir
        '
        Me.cmdSalir.Location = New System.Drawing.Point(768, 102)
        Me.cmdSalir.Name = "cmdSalir"
        Me.cmdSalir.Size = New System.Drawing.Size(75, 25)
        Me.cmdSalir.TabIndex = 10
        Me.cmdSalir.Text = "&Cerrar"
        Me.cmdSalir.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(12, 133)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowTemplate.ReadOnly = True
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(831, 255)
        Me.DataGridView1.TabIndex = 112
        '
        'tbTotal
        '
        Me.tbTotal.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.tbTotal.Enabled = False
        Me.tbTotal.Location = New System.Drawing.Point(743, 394)
        Me.tbTotal.Name = "tbTotal"
        Me.tbTotal.Size = New System.Drawing.Size(100, 20)
        Me.tbTotal.TabIndex = 113
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(697, 397)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(40, 13)
        Me.Label10.TabIndex = 114
        Me.Label10.Text = "Total $"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(27, 466)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(43, 13)
        Me.Label14.TabIndex = 124
        Me.Label14.Text = "Detalle:"
        '
        'tbDetalle
        '
        Me.tbDetalle.Location = New System.Drawing.Point(76, 463)
        Me.tbDetalle.Multiline = True
        Me.tbDetalle.Name = "tbDetalle"
        Me.tbDetalle.Size = New System.Drawing.Size(431, 88)
        Me.tbDetalle.TabIndex = 123
        '
        'txtTransferencia
        '
        Me.txtTransferencia.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.txtTransferencia.Enabled = False
        Me.txtTransferencia.Location = New System.Drawing.Point(743, 476)
        Me.txtTransferencia.Name = "txtTransferencia"
        Me.txtTransferencia.Size = New System.Drawing.Size(100, 20)
        Me.txtTransferencia.TabIndex = 129
        '
        'tbCheques
        '
        Me.tbCheques.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.tbCheques.Enabled = False
        Me.tbCheques.Location = New System.Drawing.Point(743, 446)
        Me.tbCheques.Name = "tbCheques"
        Me.tbCheques.Size = New System.Drawing.Size(100, 20)
        Me.tbCheques.TabIndex = 127
        '
        'cmdIngCheques
        '
        Me.cmdIngCheques.Location = New System.Drawing.Point(653, 444)
        Me.cmdIngCheques.Name = "cmdIngCheques"
        Me.cmdIngCheques.Size = New System.Drawing.Size(84, 22)
        Me.cmdIngCheques.TabIndex = 126
        Me.cmdIngCheques.Text = "Che&ques"
        Me.cmdIngCheques.UseVisualStyleBackColor = True
        '
        'cmdTransferencia
        '
        Me.cmdTransferencia.Location = New System.Drawing.Point(653, 476)
        Me.cmdTransferencia.Name = "cmdTransferencia"
        Me.cmdTransferencia.Size = New System.Drawing.Size(84, 22)
        Me.cmdTransferencia.TabIndex = 125
        Me.cmdTransferencia.Text = "&Transferencia"
        Me.cmdTransferencia.UseVisualStyleBackColor = True
        '
        'chkInquilinos
        '
        Me.chkInquilinos.AutoSize = True
        Me.chkInquilinos.Location = New System.Drawing.Point(489, 20)
        Me.chkInquilinos.Name = "chkInquilinos"
        Me.chkInquilinos.Size = New System.Drawing.Size(65, 17)
        Me.chkInquilinos.TabIndex = 1
        Me.chkInquilinos.Text = "&Inquilino"
        Me.chkInquilinos.UseVisualStyleBackColor = True
        '
        'chkPropiet
        '
        Me.chkPropiet.AutoSize = True
        Me.chkPropiet.Location = New System.Drawing.Point(565, 20)
        Me.chkPropiet.Name = "chkPropiet"
        Me.chkPropiet.Size = New System.Drawing.Size(76, 17)
        Me.chkPropiet.TabIndex = 2
        Me.chkPropiet.Text = "&Propietario"
        Me.chkPropiet.UseVisualStyleBackColor = True
        '
        'lblPropietario
        '
        Me.lblPropietario.AutoSize = True
        Me.lblPropietario.Location = New System.Drawing.Point(497, 78)
        Me.lblPropietario.Name = "lblPropietario"
        Me.lblPropietario.Size = New System.Drawing.Size(60, 13)
        Me.lblPropietario.TabIndex = 130
        Me.lblPropietario.Text = "Propietario:"
        '
        'frmCobrosOtr
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(855, 563)
        Me.Controls.Add(Me.lblPropietario)
        Me.Controls.Add(Me.chkPropiet)
        Me.Controls.Add(Me.txtTransferencia)
        Me.Controls.Add(Me.tbCheques)
        Me.Controls.Add(Me.cmdIngCheques)
        Me.Controls.Add(Me.cmdTransferencia)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.tbDetalle)
        Me.Controls.Add(Me.tbTotal)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.cmdSalir)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Controls.Add(Me.cmdModif)
        Me.Controls.Add(Me.cmdBaja)
        Me.Controls.Add(Me.cmdAlta)
        Me.Controls.Add(Me.tbDomicilio)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.tbCuit)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cmdGenerar)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.tbEfectivo)
        Me.Controls.Add(Me.chkInquilinos)
        Me.Controls.Add(Me.cbCliInq)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.tbNumero)
        Me.Controls.Add(Me.lblLetra)
        Me.Controls.Add(Me.tbSucursal)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cbTipoIva)
        Me.Controls.Add(Me.cbProp)
        Me.Controls.Add(Me.lblProp)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCobrosOtr"
        Me.Text = "Cobro"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cbProp As System.Windows.Forms.ComboBox
   Friend WithEvents lblProp As System.Windows.Forms.Label
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents cbTipoIva As System.Windows.Forms.ComboBox
   Friend WithEvents tbNumero As System.Windows.Forms.TextBox
   Friend WithEvents lblLetra As System.Windows.Forms.Label
   Friend WithEvents tbSucursal As System.Windows.Forms.TextBox
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents cbCliInq As System.Windows.Forms.ComboBox
   Friend WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents Label7 As System.Windows.Forms.Label
   Friend WithEvents tbEfectivo As System.Windows.Forms.TextBox
   Friend WithEvents cmdGenerar As System.Windows.Forms.Button
   Friend WithEvents cmdCancelar As System.Windows.Forms.Button
   Friend WithEvents tbCuit As System.Windows.Forms.MaskedTextBox
   Friend WithEvents Label8 As System.Windows.Forms.Label
   Friend WithEvents tbDomicilio As System.Windows.Forms.TextBox
   Friend WithEvents Label9 As System.Windows.Forms.Label
   Friend WithEvents cmdModif As System.Windows.Forms.Button
   Friend WithEvents cmdBaja As System.Windows.Forms.Button
   Friend WithEvents cmdAlta As System.Windows.Forms.Button
   Friend WithEvents cmdAceptar As System.Windows.Forms.Button
   Friend WithEvents cmdSalir As System.Windows.Forms.Button
   Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
   Friend WithEvents tbTotal As System.Windows.Forms.TextBox
   Friend WithEvents Label10 As System.Windows.Forms.Label
   Friend WithEvents Label14 As System.Windows.Forms.Label
   Friend WithEvents tbDetalle As System.Windows.Forms.TextBox
   Friend WithEvents txtTransferencia As System.Windows.Forms.TextBox
   Friend WithEvents tbCheques As System.Windows.Forms.TextBox
   Friend WithEvents cmdIngCheques As System.Windows.Forms.Button
   Friend WithEvents cmdTransferencia As System.Windows.Forms.Button
   Friend WithEvents chkInquilinos As System.Windows.Forms.CheckBox
   Friend WithEvents chkPropiet As System.Windows.Forms.CheckBox
    Friend WithEvents lblPropietario As Label
End Class
