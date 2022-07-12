<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChCartera
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
      Me.Label2 = New System.Windows.Forms.Label()
      Me.cbBanco = New System.Windows.Forms.ComboBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.cbCaja = New System.Windows.Forms.ComboBox()
      Me.chkTodas = New System.Windows.Forms.CheckBox()
      Me.dtpHasta = New System.Windows.Forms.DateTimePicker()
      Me.Label18 = New System.Windows.Forms.Label()
      Me.dtpDesde = New System.Windows.Forms.DateTimePicker()
      Me.Label15 = New System.Windows.Forms.Label()
      Me.GroupBox1 = New System.Windows.Forms.GroupBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.cbEstado = New System.Windows.Forms.ComboBox()
      Me.tbNombre = New System.Windows.Forms.TextBox()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.cmdEdicion = New System.Windows.Forms.Button()
      Me.cmdAlta = New System.Windows.Forms.Button()
      Me.cmdBaja = New System.Windows.Forms.Button()
      Me.btnEntregar = New System.Windows.Forms.Button()
      Me.btnACobrar = New System.Windows.Forms.Button()
      Me.btnCobrar = New System.Windows.Forms.Button()
      Me.btnDevolver = New System.Windows.Forms.Button()
      Me.cmdSalir = New System.Windows.Forms.Button()
      Me.cmdImprimir = New System.Windows.Forms.Button()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.tbNumero = New System.Windows.Forms.TextBox()
      Me.btnDepositar = New System.Windows.Forms.Button()
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.GroupBox1.SuspendLayout()
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
      Me.DataGridView1.Location = New System.Drawing.Point(12, 94)
      Me.DataGridView1.Name = "DataGridView1"
      Me.DataGridView1.ReadOnly = True
      Me.DataGridView1.RowTemplate.ReadOnly = True
      Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.DataGridView1.Size = New System.Drawing.Size(853, 362)
      Me.DataGridView1.TabIndex = 8
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(12, 15)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(41, 13)
      Me.Label2.TabIndex = 93
      Me.Label2.Text = "Banco:"
      '
      'cbBanco
      '
      Me.cbBanco.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      Me.cbBanco.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.cbBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbBanco.FormattingEnabled = True
      Me.cbBanco.Location = New System.Drawing.Point(59, 12)
      Me.cbBanco.Name = "cbBanco"
      Me.cbBanco.Size = New System.Drawing.Size(318, 21)
      Me.cbBanco.TabIndex = 0
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(383, 15)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(31, 13)
      Me.Label1.TabIndex = 95
      Me.Label1.Text = "Caja:"
      '
      'cbCaja
      '
      Me.cbCaja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbCaja.FormattingEnabled = True
      Me.cbCaja.Location = New System.Drawing.Point(420, 12)
      Me.cbCaja.Name = "cbCaja"
      Me.cbCaja.Size = New System.Drawing.Size(155, 21)
      Me.cbCaja.TabIndex = 1
      '
      'chkTodas
      '
      Me.chkTodas.AutoSize = True
      Me.chkTodas.Location = New System.Drawing.Point(309, 21)
      Me.chkTodas.Name = "chkTodas"
      Me.chkTodas.Size = New System.Drawing.Size(56, 17)
      Me.chkTodas.TabIndex = 5
      Me.chkTodas.Text = "&Todas"
      Me.chkTodas.UseVisualStyleBackColor = True
      '
      'dtpHasta
      '
      Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpHasta.Location = New System.Drawing.Point(215, 17)
      Me.dtpHasta.Name = "dtpHasta"
      Me.dtpHasta.Size = New System.Drawing.Size(88, 20)
      Me.dtpHasta.TabIndex = 4
      '
      'Label18
      '
      Me.Label18.AutoSize = True
      Me.Label18.Location = New System.Drawing.Point(171, 22)
      Me.Label18.Name = "Label18"
      Me.Label18.Size = New System.Drawing.Size(38, 13)
      Me.Label18.TabIndex = 100
      Me.Label18.Text = "Hasta:"
      '
      'dtpDesde
      '
      Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDesde.Location = New System.Drawing.Point(64, 18)
      Me.dtpDesde.Name = "dtpDesde"
      Me.dtpDesde.Size = New System.Drawing.Size(88, 20)
      Me.dtpDesde.TabIndex = 3
      '
      'Label15
      '
      Me.Label15.AutoSize = True
      Me.Label15.Location = New System.Drawing.Point(17, 23)
      Me.Label15.Name = "Label15"
      Me.Label15.Size = New System.Drawing.Size(41, 13)
      Me.Label15.TabIndex = 98
      Me.Label15.Text = "Desde:"
      '
      'GroupBox1
      '
      Me.GroupBox1.Controls.Add(Me.chkTodas)
      Me.GroupBox1.Controls.Add(Me.dtpHasta)
      Me.GroupBox1.Controls.Add(Me.Label18)
      Me.GroupBox1.Controls.Add(Me.Label15)
      Me.GroupBox1.Controls.Add(Me.dtpDesde)
      Me.GroupBox1.Location = New System.Drawing.Point(12, 39)
      Me.GroupBox1.Name = "GroupBox1"
      Me.GroupBox1.Size = New System.Drawing.Size(374, 49)
      Me.GroupBox1.TabIndex = 102
      Me.GroupBox1.TabStop = False
      Me.GroupBox1.Text = "Fechas"
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(581, 15)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(43, 13)
      Me.Label3.TabIndex = 104
      Me.Label3.Text = "Estado:"
      '
      'cbEstado
      '
      Me.cbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbEstado.FormattingEnabled = True
      Me.cbEstado.Location = New System.Drawing.Point(630, 12)
      Me.cbEstado.Name = "cbEstado"
      Me.cbEstado.Size = New System.Drawing.Size(102, 21)
      Me.cbEstado.TabIndex = 2
      '
      'tbNombre
      '
      Me.tbNombre.Location = New System.Drawing.Point(444, 59)
      Me.tbNombre.Name = "tbNombre"
      Me.tbNombre.Size = New System.Drawing.Size(154, 20)
      Me.tbNombre.TabIndex = 6
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(392, 62)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(47, 13)
      Me.Label4.TabIndex = 106
      Me.Label4.Text = "Nombre:"
      '
      'cmdEdicion
      '
      Me.cmdEdicion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdEdicion.Location = New System.Drawing.Point(176, 462)
      Me.cmdEdicion.Name = "cmdEdicion"
      Me.cmdEdicion.Size = New System.Drawing.Size(76, 27)
      Me.cmdEdicion.TabIndex = 11
      Me.cmdEdicion.Text = "&Modificar"
      Me.cmdEdicion.UseVisualStyleBackColor = True
      '
      'cmdAlta
      '
      Me.cmdAlta.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdAlta.Location = New System.Drawing.Point(12, 462)
      Me.cmdAlta.Name = "cmdAlta"
      Me.cmdAlta.Size = New System.Drawing.Size(76, 27)
      Me.cmdAlta.TabIndex = 9
      Me.cmdAlta.Text = "&Alta"
      Me.cmdAlta.UseVisualStyleBackColor = True
      '
      'cmdBaja
      '
      Me.cmdBaja.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdBaja.Location = New System.Drawing.Point(94, 462)
      Me.cmdBaja.Name = "cmdBaja"
      Me.cmdBaja.Size = New System.Drawing.Size(76, 27)
      Me.cmdBaja.TabIndex = 10
      Me.cmdBaja.Text = "&Baja"
      Me.cmdBaja.UseVisualStyleBackColor = True
      '
      'btnEntregar
      '
      Me.btnEntregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btnEntregar.Location = New System.Drawing.Point(280, 462)
      Me.btnEntregar.Name = "btnEntregar"
      Me.btnEntregar.Size = New System.Drawing.Size(76, 27)
      Me.btnEntregar.TabIndex = 12
      Me.btnEntregar.Text = "&Entregar"
      Me.btnEntregar.UseVisualStyleBackColor = True
      '
      'btnACobrar
      '
      Me.btnACobrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btnACobrar.Location = New System.Drawing.Point(362, 462)
      Me.btnACobrar.Name = "btnACobrar"
      Me.btnACobrar.Size = New System.Drawing.Size(76, 27)
      Me.btnACobrar.TabIndex = 13
      Me.btnACobrar.Text = "a &Cobrar"
      Me.btnACobrar.UseVisualStyleBackColor = True
      '
      'btnCobrar
      '
      Me.btnCobrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btnCobrar.Location = New System.Drawing.Point(444, 462)
      Me.btnCobrar.Name = "btnCobrar"
      Me.btnCobrar.Size = New System.Drawing.Size(76, 27)
      Me.btnCobrar.TabIndex = 14
      Me.btnCobrar.Text = "&Cobrar"
      Me.btnCobrar.UseVisualStyleBackColor = True
      '
      'btnDevolver
      '
      Me.btnDevolver.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btnDevolver.Location = New System.Drawing.Point(526, 462)
      Me.btnDevolver.Name = "btnDevolver"
      Me.btnDevolver.Size = New System.Drawing.Size(76, 27)
      Me.btnDevolver.TabIndex = 15
      Me.btnDevolver.Text = "&Devolver"
      Me.btnDevolver.UseVisualStyleBackColor = True
      '
      'cmdSalir
      '
      Me.cmdSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdSalir.Location = New System.Drawing.Point(789, 462)
      Me.cmdSalir.Name = "cmdSalir"
      Me.cmdSalir.Size = New System.Drawing.Size(76, 27)
      Me.cmdSalir.TabIndex = 17
      Me.cmdSalir.Text = "&Salir"
      Me.cmdSalir.UseVisualStyleBackColor = True
      '
      'cmdImprimir
      '
      Me.cmdImprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdImprimir.Location = New System.Drawing.Point(707, 462)
      Me.cmdImprimir.Name = "cmdImprimir"
      Me.cmdImprimir.Size = New System.Drawing.Size(76, 27)
      Me.cmdImprimir.TabIndex = 16
      Me.cmdImprimir.Text = "&Listado"
      Me.cmdImprimir.UseVisualStyleBackColor = True
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.Location = New System.Drawing.Point(616, 63)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(47, 13)
      Me.Label5.TabIndex = 117
      Me.Label5.Text = "Número:"
      '
      'tbNumero
      '
      Me.tbNumero.Location = New System.Drawing.Point(669, 59)
      Me.tbNumero.Name = "tbNumero"
      Me.tbNumero.Size = New System.Drawing.Size(135, 20)
      Me.tbNumero.TabIndex = 7
      '
      'btnDepositar
      '
      Me.btnDepositar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btnDepositar.Location = New System.Drawing.Point(608, 462)
      Me.btnDepositar.Name = "btnDepositar"
      Me.btnDepositar.Size = New System.Drawing.Size(76, 27)
      Me.btnDepositar.TabIndex = 118
      Me.btnDepositar.Text = "De&positar"
      Me.btnDepositar.UseVisualStyleBackColor = True
      '
      'frmChCartera
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(877, 501)
      Me.Controls.Add(Me.btnDepositar)
      Me.Controls.Add(Me.Label5)
      Me.Controls.Add(Me.tbNumero)
      Me.Controls.Add(Me.cmdSalir)
      Me.Controls.Add(Me.cmdImprimir)
      Me.Controls.Add(Me.btnDevolver)
      Me.Controls.Add(Me.btnCobrar)
      Me.Controls.Add(Me.btnACobrar)
      Me.Controls.Add(Me.btnEntregar)
      Me.Controls.Add(Me.cmdEdicion)
      Me.Controls.Add(Me.cmdAlta)
      Me.Controls.Add(Me.cmdBaja)
      Me.Controls.Add(Me.Label4)
      Me.Controls.Add(Me.tbNombre)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.cbEstado)
      Me.Controls.Add(Me.GroupBox1)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.cbCaja)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.cbBanco)
      Me.Controls.Add(Me.DataGridView1)
      Me.Name = "frmChCartera"
      Me.Text = "Cheques en Cartera"
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.GroupBox1.ResumeLayout(False)
      Me.GroupBox1.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents cbBanco As System.Windows.Forms.ComboBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents cbCaja As System.Windows.Forms.ComboBox
   Friend WithEvents chkTodas As System.Windows.Forms.CheckBox
   Friend WithEvents dtpHasta As System.Windows.Forms.DateTimePicker
   Friend WithEvents Label18 As System.Windows.Forms.Label
   Friend WithEvents dtpDesde As System.Windows.Forms.DateTimePicker
   Friend WithEvents Label15 As System.Windows.Forms.Label
   Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents cbEstado As System.Windows.Forms.ComboBox
   Friend WithEvents tbNombre As System.Windows.Forms.TextBox
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents cmdEdicion As System.Windows.Forms.Button
   Friend WithEvents cmdAlta As System.Windows.Forms.Button
   Friend WithEvents cmdBaja As System.Windows.Forms.Button
   Friend WithEvents btnEntregar As System.Windows.Forms.Button
   Friend WithEvents btnACobrar As System.Windows.Forms.Button
   Friend WithEvents btnCobrar As System.Windows.Forms.Button
   Friend WithEvents btnDevolver As System.Windows.Forms.Button
   Friend WithEvents cmdSalir As System.Windows.Forms.Button
   Friend WithEvents cmdImprimir As System.Windows.Forms.Button
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents tbNumero As System.Windows.Forms.TextBox
   Friend WithEvents btnDepositar As System.Windows.Forms.Button
End Class
