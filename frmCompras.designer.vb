<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCompras
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
      Me.Label3 = New System.Windows.Forms.Label()
      Me.cboTipoComp = New System.Windows.Forms.ComboBox()
      Me.cboProveedor = New System.Windows.Forms.ComboBox()
      Me.Label18 = New System.Windows.Forms.Label()
      Me.cboEmpresa = New System.Windows.Forms.ComboBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.cboEstado = New System.Windows.Forms.ComboBox()
      Me.tbFecHasta = New System.Windows.Forms.DateTimePicker()
      Me.tbFecDesde = New System.Windows.Forms.DateTimePicker()
      Me.chkTodas = New System.Windows.Forms.CheckBox()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.tbPerIVA = New System.Windows.Forms.DateTimePicker()
      Me.Label7 = New System.Windows.Forms.Label()
      Me.chkTodos = New System.Windows.Forms.CheckBox()
      Me.cmdBaja = New System.Windows.Forms.Button()
      Me.cmdEdicion = New System.Windows.Forms.Button()
      Me.btnAlta = New System.Windows.Forms.Button()
      Me.btnSetCols = New System.Windows.Forms.Button()
      Me.cmdSalir = New System.Windows.Forms.Button()
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
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
      Me.DataGridView1.Location = New System.Drawing.Point(12, 86)
      Me.DataGridView1.Name = "DataGridView1"
      Me.DataGridView1.ReadOnly = True
      Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.DataGridView1.Size = New System.Drawing.Size(694, 358)
      Me.DataGridView1.TabIndex = 35
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(397, 35)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(32, 13)
      Me.Label3.TabIndex = 53
      Me.Label3.Text = "Cpte:"
      '
      'cboTipoComp
      '
      Me.cboTipoComp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboTipoComp.FormattingEnabled = True
      Me.cboTipoComp.Location = New System.Drawing.Point(435, 32)
      Me.cboTipoComp.Name = "cboTipoComp"
      Me.cboTipoComp.Size = New System.Drawing.Size(122, 21)
      Me.cboTipoComp.TabIndex = 52
      '
      'cboProveedor
      '
      Me.cboProveedor.FormattingEnabled = True
      Me.cboProveedor.Location = New System.Drawing.Point(78, 32)
      Me.cboProveedor.Name = "cboProveedor"
      Me.cboProveedor.Size = New System.Drawing.Size(313, 21)
      Me.cboProveedor.TabIndex = 51
      '
      'Label18
      '
      Me.Label18.AutoSize = True
      Me.Label18.Location = New System.Drawing.Point(9, 9)
      Me.Label18.Name = "Label18"
      Me.Label18.Size = New System.Drawing.Size(51, 13)
      Me.Label18.TabIndex = 55
      Me.Label18.Text = "Empresa:"
      '
      'cboEmpresa
      '
      Me.cboEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboEmpresa.FormattingEnabled = True
      Me.cboEmpresa.Location = New System.Drawing.Point(70, 6)
      Me.cboEmpresa.Name = "cboEmpresa"
      Me.cboEmpresa.Size = New System.Drawing.Size(266, 21)
      Me.cboEmpresa.TabIndex = 54
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(9, 35)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(59, 13)
      Me.Label1.TabIndex = 56
      Me.Label1.Text = "Proveedor:"
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(563, 35)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(43, 13)
      Me.Label2.TabIndex = 58
      Me.Label2.Text = "Estado:"
      '
      'cboEstado
      '
      Me.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboEstado.FormattingEnabled = True
      Me.cboEstado.Location = New System.Drawing.Point(612, 32)
      Me.cboEstado.Name = "cboEstado"
      Me.cboEstado.Size = New System.Drawing.Size(92, 21)
      Me.cboEstado.TabIndex = 57
      '
      'tbFecHasta
      '
      Me.tbFecHasta.Enabled = False
      Me.tbFecHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.tbFecHasta.Location = New System.Drawing.Point(310, 60)
      Me.tbFecHasta.Name = "tbFecHasta"
      Me.tbFecHasta.Size = New System.Drawing.Size(89, 20)
      Me.tbFecHasta.TabIndex = 64
      '
      'tbFecDesde
      '
      Me.tbFecDesde.Enabled = False
      Me.tbFecDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.tbFecDesde.Location = New System.Drawing.Point(171, 60)
      Me.tbFecDesde.Name = "tbFecDesde"
      Me.tbFecDesde.Size = New System.Drawing.Size(89, 20)
      Me.tbFecDesde.TabIndex = 63
      '
      'chkTodas
      '
      Me.chkTodas.AutoSize = True
      Me.chkTodas.Checked = True
      Me.chkTodas.CheckState = System.Windows.Forms.CheckState.Checked
      Me.chkTodas.Location = New System.Drawing.Point(60, 62)
      Me.chkTodas.Name = "chkTodas"
      Me.chkTodas.Size = New System.Drawing.Size(56, 17)
      Me.chkTodas.TabIndex = 62
      Me.chkTodas.Text = "Todas"
      Me.chkTodas.UseVisualStyleBackColor = True
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(266, 63)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(38, 13)
      Me.Label4.TabIndex = 61
      Me.Label4.Text = "Hasta:"
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.Location = New System.Drawing.Point(124, 64)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(41, 13)
      Me.Label5.TabIndex = 60
      Me.Label5.Text = "Desde:"
      '
      'Label6
      '
      Me.Label6.AutoSize = True
      Me.Label6.Location = New System.Drawing.Point(9, 63)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(45, 13)
      Me.Label6.TabIndex = 59
      Me.Label6.Text = "Fechas:"
      '
      'tbPerIVA
      '
      Me.tbPerIVA.Enabled = False
      Me.tbPerIVA.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.tbPerIVA.Location = New System.Drawing.Point(552, 60)
      Me.tbPerIVA.Name = "tbPerIVA"
      Me.tbPerIVA.Size = New System.Drawing.Size(89, 20)
      Me.tbPerIVA.TabIndex = 66
      '
      'Label7
      '
      Me.Label7.AutoSize = True
      Me.Label7.Location = New System.Drawing.Point(497, 64)
      Me.Label7.Name = "Label7"
      Me.Label7.Size = New System.Drawing.Size(49, 13)
      Me.Label7.TabIndex = 65
      Me.Label7.Text = "Per.IVA.:"
      '
      'chkTodos
      '
      Me.chkTodos.AutoSize = True
      Me.chkTodos.Checked = True
      Me.chkTodos.CheckState = System.Windows.Forms.CheckState.Checked
      Me.chkTodos.Location = New System.Drawing.Point(435, 62)
      Me.chkTodos.Name = "chkTodos"
      Me.chkTodos.Size = New System.Drawing.Size(56, 17)
      Me.chkTodos.TabIndex = 67
      Me.chkTodos.Text = "Todos"
      Me.chkTodos.UseVisualStyleBackColor = True
      '
      'cmdBaja
      '
      Me.cmdBaja.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdBaja.Location = New System.Drawing.Point(93, 454)
      Me.cmdBaja.Name = "cmdBaja"
      Me.cmdBaja.Size = New System.Drawing.Size(75, 23)
      Me.cmdBaja.TabIndex = 70
      Me.cmdBaja.Text = "&Baja"
      Me.cmdBaja.UseVisualStyleBackColor = True
      '
      'cmdEdicion
      '
      Me.cmdEdicion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdEdicion.Location = New System.Drawing.Point(174, 454)
      Me.cmdEdicion.Name = "cmdEdicion"
      Me.cmdEdicion.Size = New System.Drawing.Size(75, 23)
      Me.cmdEdicion.TabIndex = 69
      Me.cmdEdicion.Text = "&Modificar"
      Me.cmdEdicion.UseVisualStyleBackColor = True
      '
      'btnAlta
      '
      Me.btnAlta.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btnAlta.Location = New System.Drawing.Point(12, 454)
      Me.btnAlta.Name = "btnAlta"
      Me.btnAlta.Size = New System.Drawing.Size(75, 23)
      Me.btnAlta.TabIndex = 68
      Me.btnAlta.Text = "&Alta"
      Me.btnAlta.UseVisualStyleBackColor = True
      '
      'btnSetCols
      '
      Me.btnSetCols.Location = New System.Drawing.Point(674, 61)
      Me.btnSetCols.Name = "btnSetCols"
      Me.btnSetCols.Size = New System.Drawing.Size(32, 23)
      Me.btnSetCols.TabIndex = 71
      Me.btnSetCols.Text = "| | | |"
      Me.btnSetCols.UseVisualStyleBackColor = True
      '
      'cmdSalir
      '
      Me.cmdSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.cmdSalir.Location = New System.Drawing.Point(646, 454)
      Me.cmdSalir.Name = "cmdSalir"
      Me.cmdSalir.Size = New System.Drawing.Size(60, 23)
      Me.cmdSalir.TabIndex = 75
      Me.cmdSalir.Text = "&Cerrar"
      Me.cmdSalir.UseVisualStyleBackColor = True
      '
      'frmCompras
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(718, 489)
      Me.Controls.Add(Me.cmdSalir)
      Me.Controls.Add(Me.btnSetCols)
      Me.Controls.Add(Me.cmdBaja)
      Me.Controls.Add(Me.cmdEdicion)
      Me.Controls.Add(Me.btnAlta)
      Me.Controls.Add(Me.chkTodos)
      Me.Controls.Add(Me.tbPerIVA)
      Me.Controls.Add(Me.Label7)
      Me.Controls.Add(Me.tbFecHasta)
      Me.Controls.Add(Me.tbFecDesde)
      Me.Controls.Add(Me.chkTodas)
      Me.Controls.Add(Me.Label4)
      Me.Controls.Add(Me.Label5)
      Me.Controls.Add(Me.Label6)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.cboEstado)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.Label18)
      Me.Controls.Add(Me.cboEmpresa)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.cboTipoComp)
      Me.Controls.Add(Me.cboProveedor)
      Me.Controls.Add(Me.DataGridView1)
      Me.Name = "frmCompras"
      Me.Text = "Compras"
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents cboTipoComp As System.Windows.Forms.ComboBox
   Friend WithEvents cboProveedor As System.Windows.Forms.ComboBox
   Friend WithEvents Label18 As System.Windows.Forms.Label
   Friend WithEvents cboEmpresa As System.Windows.Forms.ComboBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents cboEstado As System.Windows.Forms.ComboBox
   Friend WithEvents tbFecHasta As System.Windows.Forms.DateTimePicker
   Friend WithEvents tbFecDesde As System.Windows.Forms.DateTimePicker
   Friend WithEvents chkTodas As System.Windows.Forms.CheckBox
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents tbPerIVA As System.Windows.Forms.DateTimePicker
   Friend WithEvents Label7 As System.Windows.Forms.Label
   Friend WithEvents chkTodos As System.Windows.Forms.CheckBox
   Friend WithEvents cmdBaja As System.Windows.Forms.Button
   Friend WithEvents cmdEdicion As System.Windows.Forms.Button
   Friend WithEvents btnAlta As System.Windows.Forms.Button
   Friend WithEvents btnSetCols As System.Windows.Forms.Button
   Friend WithEvents cmdSalir As System.Windows.Forms.Button
End Class
