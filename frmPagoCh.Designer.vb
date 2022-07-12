<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPagoCh
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
      Me.DataGridView1 = New System.Windows.Forms.DataGridView()
      Me.cmdAlta = New System.Windows.Forms.Button()
      Me.cmdBaja = New System.Windows.Forms.Button()
      Me.cmdEdicion = New System.Windows.Forms.Button()
      Me.cmdCerrar = New System.Windows.Forms.Button()
      Me.cmdGuardar = New System.Windows.Forms.Button()
      Me.GroupBox1 = New System.Windows.Forms.GroupBox()
      Me.optPropio = New System.Windows.Forms.RadioButton()
      Me.optCartera = New System.Windows.Forms.RadioButton()
      Me.GroupBox2 = New System.Windows.Forms.GroupBox()
      Me.cmdAceptar = New System.Windows.Forms.Button()
      Me.cmdCancelar = New System.Windows.Forms.Button()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.cbFecha = New System.Windows.Forms.ComboBox()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.cbImporte = New System.Windows.Forms.ComboBox()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.cbTitular = New System.Windows.Forms.ComboBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.cbNumero = New System.Windows.Forms.ComboBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.cbCuenta = New System.Windows.Forms.ComboBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.cbBanco = New System.Windows.Forms.ComboBox()
      Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.GroupBox1.SuspendLayout()
      Me.GroupBox2.SuspendLayout()
      Me.SuspendLayout()
      '
      'DataGridView1
      '
      Me.DataGridView1.AllowUserToAddRows = False
      Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
      Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.DataGridView1.Location = New System.Drawing.Point(12, 12)
      Me.DataGridView1.Name = "DataGridView1"
      Me.DataGridView1.ReadOnly = True
      Me.DataGridView1.RowTemplate.ReadOnly = True
      Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.DataGridView1.Size = New System.Drawing.Size(718, 273)
      Me.DataGridView1.TabIndex = 37
      '
      'cmdAlta
      '
      Me.cmdAlta.Location = New System.Drawing.Point(12, 294)
      Me.cmdAlta.Name = "cmdAlta"
      Me.cmdAlta.Size = New System.Drawing.Size(75, 23)
      Me.cmdAlta.TabIndex = 38
      Me.cmdAlta.Text = "A&gregar"
      Me.cmdAlta.UseVisualStyleBackColor = True
      '
      'cmdBaja
      '
      Me.cmdBaja.Location = New System.Drawing.Point(93, 294)
      Me.cmdBaja.Name = "cmdBaja"
      Me.cmdBaja.Size = New System.Drawing.Size(75, 23)
      Me.cmdBaja.TabIndex = 39
      Me.cmdBaja.Text = "&Quitar"
      Me.cmdBaja.UseVisualStyleBackColor = True
      '
      'cmdEdicion
      '
      Me.cmdEdicion.Location = New System.Drawing.Point(174, 294)
      Me.cmdEdicion.Name = "cmdEdicion"
      Me.cmdEdicion.Size = New System.Drawing.Size(75, 23)
      Me.cmdEdicion.TabIndex = 40
      Me.cmdEdicion.Text = "&Modificar"
      Me.cmdEdicion.UseVisualStyleBackColor = True
      '
      'cmdCerrar
      '
      Me.cmdCerrar.Location = New System.Drawing.Point(655, 294)
      Me.cmdCerrar.Name = "cmdCerrar"
      Me.cmdCerrar.Size = New System.Drawing.Size(75, 25)
      Me.cmdCerrar.TabIndex = 41
      Me.cmdCerrar.Text = "&Cancelar"
      Me.cmdCerrar.UseVisualStyleBackColor = True
      '
      'cmdGuardar
      '
      Me.cmdGuardar.Location = New System.Drawing.Point(561, 294)
      Me.cmdGuardar.Name = "cmdGuardar"
      Me.cmdGuardar.Size = New System.Drawing.Size(88, 25)
      Me.cmdGuardar.TabIndex = 42
      Me.cmdGuardar.Text = "&Aceptar"
      Me.cmdGuardar.UseVisualStyleBackColor = True
      '
      'GroupBox1
      '
      Me.GroupBox1.Controls.Add(Me.optPropio)
      Me.GroupBox1.Controls.Add(Me.optCartera)
      Me.GroupBox1.Location = New System.Drawing.Point(12, 325)
      Me.GroupBox1.Name = "GroupBox1"
      Me.GroupBox1.Size = New System.Drawing.Size(156, 134)
      Me.GroupBox1.TabIndex = 43
      Me.GroupBox1.TabStop = False
      Me.GroupBox1.Text = "Origen"
      '
      'optPropio
      '
      Me.optPropio.AutoSize = True
      Me.optPropio.Location = New System.Drawing.Point(46, 74)
      Me.optPropio.Name = "optPropio"
      Me.optPropio.Size = New System.Drawing.Size(55, 17)
      Me.optPropio.TabIndex = 1
      Me.optPropio.Text = "&Propio"
      Me.optPropio.UseVisualStyleBackColor = True
      '
      'optCartera
      '
      Me.optCartera.AutoSize = True
      Me.optCartera.Checked = True
      Me.optCartera.Location = New System.Drawing.Point(46, 32)
      Me.optCartera.Name = "optCartera"
      Me.optCartera.Size = New System.Drawing.Size(59, 17)
      Me.optCartera.TabIndex = 0
      Me.optCartera.TabStop = True
      Me.optCartera.Text = "&Cartera"
      Me.optCartera.UseVisualStyleBackColor = True
      '
      'GroupBox2
      '
      Me.GroupBox2.Controls.Add(Me.dtpFecha)
      Me.GroupBox2.Controls.Add(Me.cmdAceptar)
      Me.GroupBox2.Controls.Add(Me.cmdCancelar)
      Me.GroupBox2.Controls.Add(Me.Label6)
      Me.GroupBox2.Controls.Add(Me.cbFecha)
      Me.GroupBox2.Controls.Add(Me.Label5)
      Me.GroupBox2.Controls.Add(Me.cbImporte)
      Me.GroupBox2.Controls.Add(Me.Label4)
      Me.GroupBox2.Controls.Add(Me.cbTitular)
      Me.GroupBox2.Controls.Add(Me.Label3)
      Me.GroupBox2.Controls.Add(Me.cbNumero)
      Me.GroupBox2.Controls.Add(Me.Label2)
      Me.GroupBox2.Controls.Add(Me.cbCuenta)
      Me.GroupBox2.Controls.Add(Me.Label1)
      Me.GroupBox2.Controls.Add(Me.cbBanco)
      Me.GroupBox2.Location = New System.Drawing.Point(174, 325)
      Me.GroupBox2.Name = "GroupBox2"
      Me.GroupBox2.Size = New System.Drawing.Size(556, 134)
      Me.GroupBox2.TabIndex = 44
      Me.GroupBox2.TabStop = False
      '
      'cmdAceptar
      '
      Me.cmdAceptar.Location = New System.Drawing.Point(402, 107)
      Me.cmdAceptar.Name = "cmdAceptar"
      Me.cmdAceptar.Size = New System.Drawing.Size(81, 24)
      Me.cmdAceptar.TabIndex = 9
      Me.cmdAceptar.Text = "&Aceptar"
      Me.cmdAceptar.UseVisualStyleBackColor = True
      '
      'cmdCancelar
      '
      Me.cmdCancelar.Location = New System.Drawing.Point(489, 107)
      Me.cmdCancelar.Name = "cmdCancelar"
      Me.cmdCancelar.Size = New System.Drawing.Size(61, 24)
      Me.cmdCancelar.TabIndex = 10
      Me.cmdCancelar.Text = "&Cancelar"
      Me.cmdCancelar.UseVisualStyleBackColor = True
      '
      'Label6
      '
      Me.Label6.AutoSize = True
      Me.Label6.Location = New System.Drawing.Point(198, 96)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(40, 13)
      Me.Label6.TabIndex = 11
      Me.Label6.Text = "Fecha:"
      '
      'cbFecha
      '
      Me.cbFecha.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbFecha.FormattingEnabled = True
      Me.cbFecha.Location = New System.Drawing.Point(245, 93)
      Me.cbFecha.Name = "cbFecha"
      Me.cbFecha.Size = New System.Drawing.Size(108, 21)
      Me.cbFecha.TabIndex = 8
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.Location = New System.Drawing.Point(11, 96)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(51, 13)
      Me.Label5.TabIndex = 9
      Me.Label5.Text = "Importe $"
      '
      'cbImporte
      '
      Me.cbImporte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbImporte.FormattingEnabled = True
      Me.cbImporte.Location = New System.Drawing.Point(68, 93)
      Me.cbImporte.Name = "cbImporte"
      Me.cbImporte.Size = New System.Drawing.Size(108, 21)
      Me.cbImporte.TabIndex = 6
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(199, 59)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(39, 13)
      Me.Label4.TabIndex = 7
      Me.Label4.Text = "Titular:"
      '
      'cbTitular
      '
      Me.cbTitular.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbTitular.FormattingEnabled = True
      Me.cbTitular.Location = New System.Drawing.Point(245, 56)
      Me.cbTitular.Name = "cbTitular"
      Me.cbTitular.Size = New System.Drawing.Size(305, 21)
      Me.cbTitular.TabIndex = 4
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(15, 59)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(47, 13)
      Me.Label3.TabIndex = 5
      Me.Label3.Text = "Número:"
      '
      'cbNumero
      '
      Me.cbNumero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbNumero.FormattingEnabled = True
      Me.cbNumero.Location = New System.Drawing.Point(68, 56)
      Me.cbNumero.Name = "cbNumero"
      Me.cbNumero.Size = New System.Drawing.Size(108, 21)
      Me.cbNumero.TabIndex = 3
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(365, 22)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(44, 13)
      Me.Label2.TabIndex = 3
      Me.Label2.Text = "Cuenta:"
      '
      'cbCuenta
      '
      Me.cbCuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbCuenta.FormattingEnabled = True
      Me.cbCuenta.Location = New System.Drawing.Point(415, 19)
      Me.cbCuenta.Name = "cbCuenta"
      Me.cbCuenta.Size = New System.Drawing.Size(135, 21)
      Me.cbCuenta.TabIndex = 1
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(21, 22)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(41, 13)
      Me.Label1.TabIndex = 1
      Me.Label1.Text = "Banco:"
      '
      'cbBanco
      '
      Me.cbBanco.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      Me.cbBanco.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.cbBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbBanco.FormattingEnabled = True
      Me.cbBanco.Location = New System.Drawing.Point(68, 19)
      Me.cbBanco.Name = "cbBanco"
      Me.cbBanco.Size = New System.Drawing.Size(291, 21)
      Me.cbBanco.TabIndex = 0
      '
      'dtpFecha
      '
      Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpFecha.Location = New System.Drawing.Point(245, 94)
      Me.dtpFecha.Name = "dtpFecha"
      Me.dtpFecha.Size = New System.Drawing.Size(89, 20)
      Me.dtpFecha.TabIndex = 102
      Me.dtpFecha.Value = New Date(2015, 9, 24, 0, 0, 0, 0)
      '
      'frmPagoCh
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(742, 468)
      Me.Controls.Add(Me.GroupBox2)
      Me.Controls.Add(Me.GroupBox1)
      Me.Controls.Add(Me.cmdGuardar)
      Me.Controls.Add(Me.cmdCerrar)
      Me.Controls.Add(Me.cmdEdicion)
      Me.Controls.Add(Me.cmdBaja)
      Me.Controls.Add(Me.cmdAlta)
      Me.Controls.Add(Me.DataGridView1)
      Me.KeyPreview = True
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "frmPagoCh"
      Me.Text = "Pago c/Cheques"
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.GroupBox1.ResumeLayout(False)
      Me.GroupBox1.PerformLayout()
      Me.GroupBox2.ResumeLayout(False)
      Me.GroupBox2.PerformLayout()
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
   Friend WithEvents cmdAlta As System.Windows.Forms.Button
   Friend WithEvents cmdBaja As System.Windows.Forms.Button
   Friend WithEvents cmdEdicion As System.Windows.Forms.Button
   Friend WithEvents cmdCerrar As System.Windows.Forms.Button
   Friend WithEvents cmdGuardar As System.Windows.Forms.Button
   Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents optPropio As System.Windows.Forms.RadioButton
   Friend WithEvents optCartera As System.Windows.Forms.RadioButton
   Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
   Friend WithEvents cmdAceptar As System.Windows.Forms.Button
   Friend WithEvents cmdCancelar As System.Windows.Forms.Button
   Friend WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents cbFecha As System.Windows.Forms.ComboBox
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents cbImporte As System.Windows.Forms.ComboBox
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents cbTitular As System.Windows.Forms.ComboBox
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents cbNumero As System.Windows.Forms.ComboBox
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents cbCuenta As System.Windows.Forms.ComboBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents cbBanco As System.Windows.Forms.ComboBox
   Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
End Class
