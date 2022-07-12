<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCajaRec
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
      Me.tbComprob = New System.Windows.Forms.TextBox()
      Me.Label8 = New System.Windows.Forms.Label()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.cbCaja = New System.Windows.Forms.ComboBox()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
      Me.tbMovRec = New System.Windows.Forms.TextBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.tbCuenta = New System.Windows.Forms.TextBox()
      Me.lblCuenta = New System.Windows.Forms.Label()
      Me.cbCuenta = New System.Windows.Forms.ComboBox()
      Me.tbCheques = New System.Windows.Forms.TextBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.cmdIngCheques = New System.Windows.Forms.Button()
      Me.tbEfectivo = New System.Windows.Forms.TextBox()
      Me.tbTotal = New System.Windows.Forms.TextBox()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.tbNombre = New System.Windows.Forms.TextBox()
      Me.Label13 = New System.Windows.Forms.Label()
      Me.tbDetalle = New System.Windows.Forms.TextBox()
      Me.Label12 = New System.Windows.Forms.Label()
      Me.btnCancelar = New System.Windows.Forms.Button()
      Me.btnAceptar = New System.Windows.Forms.Button()
      Me.SuspendLayout()
      '
      'tbComprob
      '
      Me.tbComprob.Enabled = False
      Me.tbComprob.Location = New System.Drawing.Point(420, 12)
      Me.tbComprob.Name = "tbComprob"
      Me.tbComprob.Size = New System.Drawing.Size(113, 20)
      Me.tbComprob.TabIndex = 92
      '
      'Label8
      '
      Me.Label8.AutoSize = True
      Me.Label8.Location = New System.Drawing.Point(341, 15)
      Me.Label8.Name = "Label8"
      Me.Label8.Size = New System.Drawing.Size(73, 13)
      Me.Label8.TabIndex = 94
      Me.Label8.Text = "Comprobante:"
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(12, 15)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(31, 13)
      Me.Label2.TabIndex = 93
      Me.Label2.Text = "Caja:"
      '
      'cbCaja
      '
      Me.cbCaja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbCaja.FormattingEnabled = True
      Me.cbCaja.Location = New System.Drawing.Point(49, 12)
      Me.cbCaja.Name = "cbCaja"
      Me.cbCaja.Size = New System.Drawing.Size(206, 21)
      Me.cbCaja.TabIndex = 91
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(12, 53)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(40, 13)
      Me.Label4.TabIndex = 96
      Me.Label4.Text = "Fecha:"
      '
      'dtpFecha
      '
      Me.dtpFecha.Enabled = False
      Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpFecha.Location = New System.Drawing.Point(61, 49)
      Me.dtpFecha.Name = "dtpFecha"
      Me.dtpFecha.Size = New System.Drawing.Size(94, 20)
      Me.dtpFecha.TabIndex = 95
      Me.dtpFecha.Value = New Date(2015, 9, 24, 0, 0, 0, 0)
      '
      'tbMovRec
      '
      Me.tbMovRec.Enabled = False
      Me.tbMovRec.Location = New System.Drawing.Point(443, 50)
      Me.tbMovRec.Name = "tbMovRec"
      Me.tbMovRec.Size = New System.Drawing.Size(90, 20)
      Me.tbMovRec.TabIndex = 97
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(341, 53)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(96, 13)
      Me.Label1.TabIndex = 98
      Me.Label1.Text = "Mov. a Recuperar:"
      '
      'tbCuenta
      '
      Me.tbCuenta.Location = New System.Drawing.Point(62, 85)
      Me.tbCuenta.Name = "tbCuenta"
      Me.tbCuenta.Size = New System.Drawing.Size(100, 20)
      Me.tbCuenta.TabIndex = 100
      '
      'lblCuenta
      '
      Me.lblCuenta.AutoSize = True
      Me.lblCuenta.Location = New System.Drawing.Point(12, 88)
      Me.lblCuenta.Name = "lblCuenta"
      Me.lblCuenta.Size = New System.Drawing.Size(44, 13)
      Me.lblCuenta.TabIndex = 102
      Me.lblCuenta.Text = "Cuenta:"
      '
      'cbCuenta
      '
      Me.cbCuenta.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      Me.cbCuenta.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.cbCuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbCuenta.FormattingEnabled = True
      Me.cbCuenta.Location = New System.Drawing.Point(168, 85)
      Me.cbCuenta.Name = "cbCuenta"
      Me.cbCuenta.Size = New System.Drawing.Size(365, 21)
      Me.cbCuenta.TabIndex = 101
      '
      'tbCheques
      '
      Me.tbCheques.BackColor = System.Drawing.Color.LightGoldenrodYellow
      Me.tbCheques.Enabled = False
      Me.tbCheques.Location = New System.Drawing.Point(86, 162)
      Me.tbCheques.Name = "tbCheques"
      Me.tbCheques.Size = New System.Drawing.Size(86, 20)
      Me.tbCheques.TabIndex = 106
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(12, 125)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(55, 13)
      Me.Label3.TabIndex = 105
      Me.Label3.Text = "Efectivo $"
      '
      'cmdIngCheques
      '
      Me.cmdIngCheques.Location = New System.Drawing.Point(15, 162)
      Me.cmdIngCheques.Name = "cmdIngCheques"
      Me.cmdIngCheques.Size = New System.Drawing.Size(65, 22)
      Me.cmdIngCheques.TabIndex = 104
      Me.cmdIngCheques.Text = "Che&ques"
      Me.cmdIngCheques.UseVisualStyleBackColor = True
      '
      'tbEfectivo
      '
      Me.tbEfectivo.Location = New System.Drawing.Point(86, 122)
      Me.tbEfectivo.Name = "tbEfectivo"
      Me.tbEfectivo.Size = New System.Drawing.Size(86, 20)
      Me.tbEfectivo.TabIndex = 103
      '
      'tbTotal
      '
      Me.tbTotal.BackColor = System.Drawing.Color.LightGoldenrodYellow
      Me.tbTotal.Enabled = False
      Me.tbTotal.Location = New System.Drawing.Point(86, 199)
      Me.tbTotal.Name = "tbTotal"
      Me.tbTotal.Size = New System.Drawing.Size(86, 20)
      Me.tbTotal.TabIndex = 108
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.Location = New System.Drawing.Point(12, 202)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(40, 13)
      Me.Label5.TabIndex = 107
      Me.Label5.Text = "Total $"
      '
      'tbNombre
      '
      Me.tbNombre.Location = New System.Drawing.Point(62, 265)
      Me.tbNombre.Name = "tbNombre"
      Me.tbNombre.Size = New System.Drawing.Size(374, 20)
      Me.tbNombre.TabIndex = 110
      '
      'Label13
      '
      Me.Label13.AutoSize = True
      Me.Label13.Location = New System.Drawing.Point(13, 268)
      Me.Label13.Name = "Label13"
      Me.Label13.Size = New System.Drawing.Size(47, 13)
      Me.Label13.TabIndex = 112
      Me.Label13.Text = "Nombre:"
      '
      'tbDetalle
      '
      Me.tbDetalle.Location = New System.Drawing.Point(62, 232)
      Me.tbDetalle.Name = "tbDetalle"
      Me.tbDetalle.Size = New System.Drawing.Size(450, 20)
      Me.tbDetalle.TabIndex = 109
      '
      'Label12
      '
      Me.Label12.AutoSize = True
      Me.Label12.Location = New System.Drawing.Point(13, 235)
      Me.Label12.Name = "Label12"
      Me.Label12.Size = New System.Drawing.Size(43, 13)
      Me.Label12.TabIndex = 111
      Me.Label12.Text = "Detalle:"
      '
      'btnCancelar
      '
      Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btnCancelar.Location = New System.Drawing.Point(457, 310)
      Me.btnCancelar.Name = "btnCancelar"
      Me.btnCancelar.Size = New System.Drawing.Size(76, 27)
      Me.btnCancelar.TabIndex = 114
      Me.btnCancelar.Text = "&Cancelar"
      Me.btnCancelar.UseVisualStyleBackColor = True
      '
      'btnAceptar
      '
      Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btnAceptar.Location = New System.Drawing.Point(375, 310)
      Me.btnAceptar.Name = "btnAceptar"
      Me.btnAceptar.Size = New System.Drawing.Size(76, 27)
      Me.btnAceptar.TabIndex = 113
      Me.btnAceptar.Text = "&Aceptar"
      Me.btnAceptar.UseVisualStyleBackColor = True
      '
      'frmCajaRec
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(545, 349)
      Me.Controls.Add(Me.btnCancelar)
      Me.Controls.Add(Me.btnAceptar)
      Me.Controls.Add(Me.tbNombre)
      Me.Controls.Add(Me.Label13)
      Me.Controls.Add(Me.tbDetalle)
      Me.Controls.Add(Me.Label12)
      Me.Controls.Add(Me.tbTotal)
      Me.Controls.Add(Me.Label5)
      Me.Controls.Add(Me.tbCheques)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.cmdIngCheques)
      Me.Controls.Add(Me.tbEfectivo)
      Me.Controls.Add(Me.tbCuenta)
      Me.Controls.Add(Me.lblCuenta)
      Me.Controls.Add(Me.cbCuenta)
      Me.Controls.Add(Me.tbMovRec)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.Label4)
      Me.Controls.Add(Me.dtpFecha)
      Me.Controls.Add(Me.tbComprob)
      Me.Controls.Add(Me.Label8)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.cbCaja)
      Me.KeyPreview = True
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "frmCajaRec"
      Me.Text = "Caja a Recuperar"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents tbComprob As System.Windows.Forms.TextBox
   Friend WithEvents Label8 As System.Windows.Forms.Label
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents cbCaja As System.Windows.Forms.ComboBox
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
   Friend WithEvents tbMovRec As System.Windows.Forms.TextBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents tbCuenta As System.Windows.Forms.TextBox
   Friend WithEvents lblCuenta As System.Windows.Forms.Label
   Friend WithEvents cbCuenta As System.Windows.Forms.ComboBox
   Friend WithEvents tbCheques As System.Windows.Forms.TextBox
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents cmdIngCheques As System.Windows.Forms.Button
   Friend WithEvents tbEfectivo As System.Windows.Forms.TextBox
   Friend WithEvents tbTotal As System.Windows.Forms.TextBox
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents tbNombre As System.Windows.Forms.TextBox
   Friend WithEvents Label13 As System.Windows.Forms.Label
   Friend WithEvents tbDetalle As System.Windows.Forms.TextBox
   Friend WithEvents Label12 As System.Windows.Forms.Label
   Friend WithEvents btnCancelar As System.Windows.Forms.Button
   Friend WithEvents btnAceptar As System.Windows.Forms.Button
End Class
