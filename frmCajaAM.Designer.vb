<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCajaAM
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
      Me.cbCaja = New System.Windows.Forms.ComboBox()
      Me.tbComprob = New System.Windows.Forms.TextBox()
      Me.Label8 = New System.Windows.Forms.Label()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
      Me.lblFecCheque = New System.Windows.Forms.Label()
      Me.dtpFecCheque = New System.Windows.Forms.DateTimePicker()
      Me.GroupBox1 = New System.Windows.Forms.GroupBox()
      Me.optSalida = New System.Windows.Forms.RadioButton()
      Me.optEntrada = New System.Windows.Forms.RadioButton()
      Me.GroupBox2 = New System.Windows.Forms.GroupBox()
      Me.tbSaldo = New System.Windows.Forms.TextBox()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.cbMovRec = New System.Windows.Forms.ComboBox()
      Me.chkMovRec = New System.Windows.Forms.CheckBox()
      Me.lblCuenta = New System.Windows.Forms.Label()
      Me.cbCuenta = New System.Windows.Forms.ComboBox()
      Me.GroupBox3 = New System.Windows.Forms.GroupBox()
      Me.lblNroCheque = New System.Windows.Forms.Label()
      Me.cbNumero = New System.Windows.Forms.ComboBox()
      Me.lblCtaBco = New System.Windows.Forms.Label()
      Me.cbCtaBanco = New System.Windows.Forms.ComboBox()
      Me.lblBanco = New System.Windows.Forms.Label()
      Me.cbBanco = New System.Windows.Forms.ComboBox()
      Me.cbImporte = New System.Windows.Forms.ComboBox()
      Me.Label7 = New System.Windows.Forms.Label()
      Me.optChequeP = New System.Windows.Forms.RadioButton()
      Me.optCheque = New System.Windows.Forms.RadioButton()
      Me.optEfectivo = New System.Windows.Forms.RadioButton()
      Me.tbDetalle = New System.Windows.Forms.TextBox()
      Me.Label12 = New System.Windows.Forms.Label()
      Me.tbNombre = New System.Windows.Forms.TextBox()
      Me.Label13 = New System.Windows.Forms.Label()
      Me.btnCancelar = New System.Windows.Forms.Button()
      Me.btnAceptar = New System.Windows.Forms.Button()
      Me.tbCuenta = New System.Windows.Forms.TextBox()
      Me.GroupBox1.SuspendLayout()
      Me.GroupBox2.SuspendLayout()
      Me.GroupBox3.SuspendLayout()
      Me.SuspendLayout()
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(23, 36)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(31, 13)
      Me.Label2.TabIndex = 78
      Me.Label2.Text = "Caja:"
      '
      'cbCaja
      '
      Me.cbCaja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbCaja.FormattingEnabled = True
      Me.cbCaja.Location = New System.Drawing.Point(60, 33)
      Me.cbCaja.Name = "cbCaja"
      Me.cbCaja.Size = New System.Drawing.Size(206, 21)
      Me.cbCaja.TabIndex = 0
      '
      'tbComprob
      '
      Me.tbComprob.Enabled = False
      Me.tbComprob.Location = New System.Drawing.Point(397, 33)
      Me.tbComprob.Name = "tbComprob"
      Me.tbComprob.Size = New System.Drawing.Size(113, 20)
      Me.tbComprob.TabIndex = 1
      '
      'Label8
      '
      Me.Label8.AutoSize = True
      Me.Label8.Location = New System.Drawing.Point(318, 36)
      Me.Label8.Name = "Label8"
      Me.Label8.Size = New System.Drawing.Size(73, 13)
      Me.Label8.TabIndex = 90
      Me.Label8.Text = "Comprobante:"
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(23, 73)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(40, 13)
      Me.Label4.TabIndex = 93
      Me.Label4.Text = "Fecha:"
      '
      'dtpFecha
      '
      Me.dtpFecha.Enabled = False
      Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpFecha.Location = New System.Drawing.Point(72, 69)
      Me.dtpFecha.Name = "dtpFecha"
      Me.dtpFecha.Size = New System.Drawing.Size(87, 20)
      Me.dtpFecha.TabIndex = 2
      Me.dtpFecha.Value = New Date(2015, 9, 24, 0, 0, 0, 0)
      '
      'lblFecCheque
      '
      Me.lblFecCheque.AutoSize = True
      Me.lblFecCheque.Location = New System.Drawing.Point(176, 75)
      Me.lblFecCheque.Name = "lblFecCheque"
      Me.lblFecCheque.Size = New System.Drawing.Size(80, 13)
      Me.lblFecCheque.TabIndex = 95
      Me.lblFecCheque.Text = "Fecha Cheque:"
      '
      'dtpFecCheque
      '
      Me.dtpFecCheque.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpFecCheque.Location = New System.Drawing.Point(326, 71)
      Me.dtpFecCheque.Name = "dtpFecCheque"
      Me.dtpFecCheque.Size = New System.Drawing.Size(94, 20)
      Me.dtpFecCheque.TabIndex = 19
      Me.dtpFecCheque.Value = New Date(2015, 9, 24, 0, 0, 0, 0)
      '
      'GroupBox1
      '
      Me.GroupBox1.Controls.Add(Me.optSalida)
      Me.GroupBox1.Controls.Add(Me.optEntrada)
      Me.GroupBox1.Location = New System.Drawing.Point(25, 106)
      Me.GroupBox1.Name = "GroupBox1"
      Me.GroupBox1.Size = New System.Drawing.Size(314, 66)
      Me.GroupBox1.TabIndex = 3
      Me.GroupBox1.TabStop = False
      Me.GroupBox1.Text = "Movimiento"
      '
      'optSalida
      '
      Me.optSalida.AutoSize = True
      Me.optSalida.Location = New System.Drawing.Point(180, 28)
      Me.optSalida.Name = "optSalida"
      Me.optSalida.Size = New System.Drawing.Size(54, 17)
      Me.optSalida.TabIndex = 5
      Me.optSalida.Text = "&Salida"
      Me.optSalida.UseVisualStyleBackColor = True
      '
      'optEntrada
      '
      Me.optEntrada.AutoSize = True
      Me.optEntrada.Checked = True
      Me.optEntrada.Location = New System.Drawing.Point(72, 28)
      Me.optEntrada.Name = "optEntrada"
      Me.optEntrada.Size = New System.Drawing.Size(62, 17)
      Me.optEntrada.TabIndex = 4
      Me.optEntrada.TabStop = True
      Me.optEntrada.Text = "&Entrada"
      Me.optEntrada.UseVisualStyleBackColor = True
      '
      'GroupBox2
      '
      Me.GroupBox2.Controls.Add(Me.tbSaldo)
      Me.GroupBox2.Controls.Add(Me.Label5)
      Me.GroupBox2.Controls.Add(Me.Label3)
      Me.GroupBox2.Controls.Add(Me.cbMovRec)
      Me.GroupBox2.Controls.Add(Me.chkMovRec)
      Me.GroupBox2.Location = New System.Drawing.Point(26, 178)
      Me.GroupBox2.Name = "GroupBox2"
      Me.GroupBox2.Size = New System.Drawing.Size(635, 66)
      Me.GroupBox2.TabIndex = 6
      Me.GroupBox2.TabStop = False
      Me.GroupBox2.Text = "Caja a Recuperar"
      '
      'tbSaldo
      '
      Me.tbSaldo.Enabled = False
      Me.tbSaldo.Location = New System.Drawing.Point(526, 28)
      Me.tbSaldo.Name = "tbSaldo"
      Me.tbSaldo.Size = New System.Drawing.Size(103, 20)
      Me.tbSaldo.TabIndex = 9
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.Location = New System.Drawing.Point(477, 32)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(43, 13)
      Me.Label5.TabIndex = 92
      Me.Label5.Text = "Saldo $"
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(137, 32)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(46, 13)
      Me.Label3.TabIndex = 80
      Me.Label3.Text = "Nº Mov."
      '
      'cbMovRec
      '
      Me.cbMovRec.Enabled = False
      Me.cbMovRec.FormattingEnabled = True
      Me.cbMovRec.Location = New System.Drawing.Point(189, 29)
      Me.cbMovRec.Name = "cbMovRec"
      Me.cbMovRec.Size = New System.Drawing.Size(282, 21)
      Me.cbMovRec.TabIndex = 8
      '
      'chkMovRec
      '
      Me.chkMovRec.AutoSize = True
      Me.chkMovRec.Location = New System.Drawing.Point(46, 31)
      Me.chkMovRec.Name = "chkMovRec"
      Me.chkMovRec.Size = New System.Drawing.Size(85, 17)
      Me.chkMovRec.TabIndex = 7
      Me.chkMovRec.Text = "a &Recuperar"
      Me.chkMovRec.UseVisualStyleBackColor = True
      '
      'lblCuenta
      '
      Me.lblCuenta.AutoSize = True
      Me.lblCuenta.Location = New System.Drawing.Point(25, 269)
      Me.lblCuenta.Name = "lblCuenta"
      Me.lblCuenta.Size = New System.Drawing.Size(44, 13)
      Me.lblCuenta.TabIndex = 99
      Me.lblCuenta.Text = "Cuenta:"
      '
      'cbCuenta
      '
      Me.cbCuenta.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      Me.cbCuenta.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.cbCuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbCuenta.FormattingEnabled = True
      Me.cbCuenta.Location = New System.Drawing.Point(188, 266)
      Me.cbCuenta.Name = "cbCuenta"
      Me.cbCuenta.Size = New System.Drawing.Size(467, 21)
      Me.cbCuenta.TabIndex = 11
      '
      'GroupBox3
      '
      Me.GroupBox3.Controls.Add(Me.lblNroCheque)
      Me.GroupBox3.Controls.Add(Me.cbNumero)
      Me.GroupBox3.Controls.Add(Me.lblCtaBco)
      Me.GroupBox3.Controls.Add(Me.cbCtaBanco)
      Me.GroupBox3.Controls.Add(Me.lblBanco)
      Me.GroupBox3.Controls.Add(Me.cbBanco)
      Me.GroupBox3.Controls.Add(Me.cbImporte)
      Me.GroupBox3.Controls.Add(Me.Label7)
      Me.GroupBox3.Controls.Add(Me.optChequeP)
      Me.GroupBox3.Controls.Add(Me.optCheque)
      Me.GroupBox3.Controls.Add(Me.optEfectivo)
      Me.GroupBox3.Controls.Add(Me.lblFecCheque)
      Me.GroupBox3.Controls.Add(Me.dtpFecCheque)
      Me.GroupBox3.Location = New System.Drawing.Point(26, 303)
      Me.GroupBox3.Name = "GroupBox3"
      Me.GroupBox3.Size = New System.Drawing.Size(635, 105)
      Me.GroupBox3.TabIndex = 12
      Me.GroupBox3.TabStop = False
      Me.GroupBox3.Text = "Forma de Pago"
      '
      'lblNroCheque
      '
      Me.lblNroCheque.AutoSize = True
      Me.lblNroCheque.Location = New System.Drawing.Point(436, 47)
      Me.lblNroCheque.Name = "lblNroCheque"
      Me.lblNroCheque.Size = New System.Drawing.Size(62, 13)
      Me.lblNroCheque.TabIndex = 104
      Me.lblNroCheque.Text = "Nº Cheque:"
      '
      'cbNumero
      '
      Me.cbNumero.FormattingEnabled = True
      Me.cbNumero.Location = New System.Drawing.Point(504, 44)
      Me.cbNumero.Name = "cbNumero"
      Me.cbNumero.Size = New System.Drawing.Size(125, 21)
      Me.cbNumero.TabIndex = 18
      '
      'lblCtaBco
      '
      Me.lblCtaBco.AutoSize = True
      Me.lblCtaBco.Location = New System.Drawing.Point(176, 47)
      Me.lblCtaBco.Name = "lblCtaBco"
      Me.lblCtaBco.Size = New System.Drawing.Size(44, 13)
      Me.lblCtaBco.TabIndex = 102
      Me.lblCtaBco.Text = "Nº Cta.:"
      '
      'cbCtaBanco
      '
      Me.cbCtaBanco.FormattingEnabled = True
      Me.cbCtaBanco.Location = New System.Drawing.Point(226, 44)
      Me.cbCtaBanco.Name = "cbCtaBanco"
      Me.cbCtaBanco.Size = New System.Drawing.Size(194, 21)
      Me.cbCtaBanco.TabIndex = 17
      '
      'lblBanco
      '
      Me.lblBanco.AutoSize = True
      Me.lblBanco.Location = New System.Drawing.Point(176, 20)
      Me.lblBanco.Name = "lblBanco"
      Me.lblBanco.Size = New System.Drawing.Size(41, 13)
      Me.lblBanco.TabIndex = 100
      Me.lblBanco.Text = "Banco:"
      '
      'cbBanco
      '
      Me.cbBanco.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      Me.cbBanco.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.cbBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbBanco.FormattingEnabled = True
      Me.cbBanco.Location = New System.Drawing.Point(226, 17)
      Me.cbBanco.Name = "cbBanco"
      Me.cbBanco.Size = New System.Drawing.Size(403, 21)
      Me.cbBanco.TabIndex = 16
      '
      'cbImporte
      '
      Me.cbImporte.FormattingEnabled = True
      Me.cbImporte.Location = New System.Drawing.Point(504, 71)
      Me.cbImporte.Name = "cbImporte"
      Me.cbImporte.Size = New System.Drawing.Size(125, 21)
      Me.cbImporte.TabIndex = 20
      '
      'Label7
      '
      Me.Label7.AutoSize = True
      Me.Label7.Location = New System.Drawing.Point(436, 75)
      Me.Label7.Name = "Label7"
      Me.Label7.Size = New System.Drawing.Size(51, 13)
      Me.Label7.TabIndex = 96
      Me.Label7.Text = "Importe $"
      '
      'optChequeP
      '
      Me.optChequeP.AutoSize = True
      Me.optChequeP.Location = New System.Drawing.Point(24, 72)
      Me.optChequeP.Name = "optChequeP"
      Me.optChequeP.Size = New System.Drawing.Size(95, 17)
      Me.optChequeP.TabIndex = 15
      Me.optChequeP.Text = "Cheque &Propio"
      Me.optChequeP.UseVisualStyleBackColor = True
      '
      'optCheque
      '
      Me.optCheque.AutoSize = True
      Me.optCheque.Location = New System.Drawing.Point(24, 45)
      Me.optCheque.Name = "optCheque"
      Me.optCheque.Size = New System.Drawing.Size(114, 17)
      Me.optCheque.TabIndex = 14
      Me.optCheque.Text = "&Cheque en Cartera"
      Me.optCheque.UseVisualStyleBackColor = True
      '
      'optEfectivo
      '
      Me.optEfectivo.AutoSize = True
      Me.optEfectivo.Checked = True
      Me.optEfectivo.Location = New System.Drawing.Point(24, 18)
      Me.optEfectivo.Name = "optEfectivo"
      Me.optEfectivo.Size = New System.Drawing.Size(64, 17)
      Me.optEfectivo.TabIndex = 13
      Me.optEfectivo.TabStop = True
      Me.optEfectivo.Text = "&Efectivo"
      Me.optEfectivo.UseVisualStyleBackColor = True
      '
      'tbDetalle
      '
      Me.tbDetalle.Location = New System.Drawing.Point(74, 423)
      Me.tbDetalle.Name = "tbDetalle"
      Me.tbDetalle.Size = New System.Drawing.Size(450, 20)
      Me.tbDetalle.TabIndex = 21
      '
      'Label12
      '
      Me.Label12.AutoSize = True
      Me.Label12.Location = New System.Drawing.Point(25, 426)
      Me.Label12.Name = "Label12"
      Me.Label12.Size = New System.Drawing.Size(43, 13)
      Me.Label12.TabIndex = 102
      Me.Label12.Text = "Detalle:"
      '
      'tbNombre
      '
      Me.tbNombre.Location = New System.Drawing.Point(74, 456)
      Me.tbNombre.Name = "tbNombre"
      Me.tbNombre.Size = New System.Drawing.Size(374, 20)
      Me.tbNombre.TabIndex = 22
      '
      'Label13
      '
      Me.Label13.AutoSize = True
      Me.Label13.Location = New System.Drawing.Point(25, 459)
      Me.Label13.Name = "Label13"
      Me.Label13.Size = New System.Drawing.Size(47, 13)
      Me.Label13.TabIndex = 104
      Me.Label13.Text = "Nombre:"
      '
      'btnCancelar
      '
      Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btnCancelar.Location = New System.Drawing.Point(617, 492)
      Me.btnCancelar.Name = "btnCancelar"
      Me.btnCancelar.Size = New System.Drawing.Size(63, 27)
      Me.btnCancelar.TabIndex = 24
      Me.btnCancelar.Text = "&Cerrar"
      Me.btnCancelar.UseVisualStyleBackColor = True
      '
      'btnAceptar
      '
      Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btnAceptar.Location = New System.Drawing.Point(522, 492)
      Me.btnAceptar.Name = "btnAceptar"
      Me.btnAceptar.Size = New System.Drawing.Size(89, 27)
      Me.btnAceptar.TabIndex = 23
      Me.btnAceptar.Text = "&Aceptar"
      Me.btnAceptar.UseVisualStyleBackColor = True
      '
      'tbCuenta
      '
      Me.tbCuenta.Location = New System.Drawing.Point(82, 266)
      Me.tbCuenta.Name = "tbCuenta"
      Me.tbCuenta.Size = New System.Drawing.Size(100, 20)
      Me.tbCuenta.TabIndex = 10
      '
      'frmCajaAM
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(692, 531)
      Me.Controls.Add(Me.tbCuenta)
      Me.Controls.Add(Me.btnCancelar)
      Me.Controls.Add(Me.btnAceptar)
      Me.Controls.Add(Me.tbNombre)
      Me.Controls.Add(Me.Label13)
      Me.Controls.Add(Me.tbDetalle)
      Me.Controls.Add(Me.Label12)
      Me.Controls.Add(Me.GroupBox3)
      Me.Controls.Add(Me.lblCuenta)
      Me.Controls.Add(Me.cbCuenta)
      Me.Controls.Add(Me.GroupBox2)
      Me.Controls.Add(Me.GroupBox1)
      Me.Controls.Add(Me.Label4)
      Me.Controls.Add(Me.dtpFecha)
      Me.Controls.Add(Me.tbComprob)
      Me.Controls.Add(Me.Label8)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.cbCaja)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.KeyPreview = True
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "frmCajaAM"
      Me.Text = "Caja"
      Me.GroupBox1.ResumeLayout(False)
      Me.GroupBox1.PerformLayout()
      Me.GroupBox2.ResumeLayout(False)
      Me.GroupBox2.PerformLayout()
      Me.GroupBox3.ResumeLayout(False)
      Me.GroupBox3.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents cbCaja As System.Windows.Forms.ComboBox
   Friend WithEvents tbComprob As System.Windows.Forms.TextBox
   Friend WithEvents Label8 As System.Windows.Forms.Label
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
   Friend WithEvents lblFecCheque As System.Windows.Forms.Label
   Friend WithEvents dtpFecCheque As System.Windows.Forms.DateTimePicker
   Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents optSalida As System.Windows.Forms.RadioButton
   Friend WithEvents optEntrada As System.Windows.Forms.RadioButton
   Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
   Friend WithEvents tbSaldo As System.Windows.Forms.TextBox
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents cbMovRec As System.Windows.Forms.ComboBox
   Friend WithEvents chkMovRec As System.Windows.Forms.CheckBox
   Friend WithEvents lblCuenta As System.Windows.Forms.Label
   Friend WithEvents cbCuenta As System.Windows.Forms.ComboBox
   Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
   Friend WithEvents optChequeP As System.Windows.Forms.RadioButton
   Friend WithEvents optCheque As System.Windows.Forms.RadioButton
   Friend WithEvents optEfectivo As System.Windows.Forms.RadioButton
   Friend WithEvents cbImporte As System.Windows.Forms.ComboBox
   Friend WithEvents Label7 As System.Windows.Forms.Label
   Friend WithEvents lblNroCheque As System.Windows.Forms.Label
   Friend WithEvents cbNumero As System.Windows.Forms.ComboBox
   Friend WithEvents lblCtaBco As System.Windows.Forms.Label
   Friend WithEvents cbCtaBanco As System.Windows.Forms.ComboBox
   Friend WithEvents lblBanco As System.Windows.Forms.Label
   Friend WithEvents cbBanco As System.Windows.Forms.ComboBox
   Friend WithEvents tbDetalle As System.Windows.Forms.TextBox
   Friend WithEvents Label12 As System.Windows.Forms.Label
   Friend WithEvents tbNombre As System.Windows.Forms.TextBox
   Friend WithEvents Label13 As System.Windows.Forms.Label
   Friend WithEvents btnCancelar As System.Windows.Forms.Button
   Friend WithEvents btnAceptar As System.Windows.Forms.Button
   Friend WithEvents tbCuenta As System.Windows.Forms.TextBox
End Class
