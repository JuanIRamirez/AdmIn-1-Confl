<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVentas
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
      Me.lblCliente = New System.Windows.Forms.Label()
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.cboEmpresa = New System.Windows.Forms.ComboBox()
      Me.btnReset = New System.Windows.Forms.Button()
      Me.dtpHasta = New System.Windows.Forms.DateTimePicker()
      Me.dtpDesde = New System.Windows.Forms.DateTimePicker()
      Me.cboEstado = New System.Windows.Forms.ComboBox()
      Me.chkFechas = New System.Windows.Forms.CheckBox()
      Me.Label8 = New System.Windows.Forms.Label()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.cboLetra = New System.Windows.Forms.ComboBox()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.cboTipoComp = New System.Windows.Forms.ComboBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.cboCliente = New System.Windows.Forms.ComboBox()
      Me.DataGridView1 = New System.Windows.Forms.DataGridView()
      Me.btnAlta = New System.Windows.Forms.Button()
      Me.btnModif = New System.Windows.Forms.Button()
      Me.btnAnular = New System.Windows.Forms.Button()
      Me.btnImprimir = New System.Windows.Forms.Button()
      Me.btnSalir = New System.Windows.Forms.Button()
      Me.btnEliminar = New System.Windows.Forms.Button()
      Me.btnRenumerar = New System.Windows.Forms.Button()
      Me.btnVPrevia = New System.Windows.Forms.Button()
      Me.btnListado = New System.Windows.Forms.Button()
      Me.Panel1.SuspendLayout()
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'lblCliente
      '
      Me.lblCliente.AutoSize = True
      Me.lblCliente.Location = New System.Drawing.Point(200, 9)
      Me.lblCliente.Name = "lblCliente"
      Me.lblCliente.Size = New System.Drawing.Size(42, 13)
      Me.lblCliente.TabIndex = 0
      Me.lblCliente.Text = "Cliente:"
      '
      'Panel1
      '
      Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Panel1.Controls.Add(Me.Label6)
      Me.Panel1.Controls.Add(Me.cboEmpresa)
      Me.Panel1.Controls.Add(Me.btnReset)
      Me.Panel1.Controls.Add(Me.dtpHasta)
      Me.Panel1.Controls.Add(Me.dtpDesde)
      Me.Panel1.Controls.Add(Me.cboEstado)
      Me.Panel1.Controls.Add(Me.chkFechas)
      Me.Panel1.Controls.Add(Me.Label8)
      Me.Panel1.Controls.Add(Me.Label3)
      Me.Panel1.Controls.Add(Me.cboLetra)
      Me.Panel1.Controls.Add(Me.Label4)
      Me.Panel1.Controls.Add(Me.Label2)
      Me.Panel1.Controls.Add(Me.Label5)
      Me.Panel1.Controls.Add(Me.cboTipoComp)
      Me.Panel1.Controls.Add(Me.Label1)
      Me.Panel1.Controls.Add(Me.cboCliente)
      Me.Panel1.Controls.Add(Me.lblCliente)
      Me.Panel1.Location = New System.Drawing.Point(12, 11)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(789, 64)
      Me.Panel1.TabIndex = 2
      '
      'Label6
      '
      Me.Label6.AutoSize = True
      Me.Label6.Location = New System.Drawing.Point(14, 9)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(34, 13)
      Me.Label6.TabIndex = 16
      Me.Label6.Text = "Emp.:"
      '
      'cboEmpresa
      '
      Me.cboEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboEmpresa.FormattingEnabled = True
      Me.cboEmpresa.Location = New System.Drawing.Point(54, 4)
      Me.cboEmpresa.Name = "cboEmpresa"
      Me.cboEmpresa.Size = New System.Drawing.Size(135, 21)
      Me.cboEmpresa.TabIndex = 0
      '
      'btnReset
      '
      Me.btnReset.Location = New System.Drawing.Point(740, 3)
      Me.btnReset.Name = "btnReset"
      Me.btnReset.Size = New System.Drawing.Size(44, 23)
      Me.btnReset.TabIndex = 13
      Me.btnReset.Text = "Reset"
      Me.btnReset.UseVisualStyleBackColor = True
      '
      'dtpHasta
      '
      Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpHasta.Location = New System.Drawing.Point(510, 36)
      Me.dtpHasta.Name = "dtpHasta"
      Me.dtpHasta.Size = New System.Drawing.Size(89, 20)
      Me.dtpHasta.TabIndex = 6
      '
      'dtpDesde
      '
      Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDesde.Location = New System.Drawing.Point(371, 35)
      Me.dtpDesde.Name = "dtpDesde"
      Me.dtpDesde.Size = New System.Drawing.Size(89, 20)
      Me.dtpDesde.TabIndex = 5
      '
      'cboEstado
      '
      Me.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboEstado.FormattingEnabled = True
      Me.cboEstado.Location = New System.Drawing.Point(684, 34)
      Me.cboEstado.Name = "cboEstado"
      Me.cboEstado.Size = New System.Drawing.Size(100, 21)
      Me.cboEstado.TabIndex = 7
      '
      'chkFechas
      '
      Me.chkFechas.AutoSize = True
      Me.chkFechas.Location = New System.Drawing.Point(263, 38)
      Me.chkFechas.Name = "chkFechas"
      Me.chkFechas.Size = New System.Drawing.Size(56, 17)
      Me.chkFechas.TabIndex = 3
      Me.chkFechas.Text = "Todas"
      Me.chkFechas.UseVisualStyleBackColor = True
      '
      'Label8
      '
      Me.Label8.AutoSize = True
      Me.Label8.Location = New System.Drawing.Point(639, 40)
      Me.Label8.Name = "Label8"
      Me.Label8.Size = New System.Drawing.Size(43, 13)
      Me.Label8.TabIndex = 0
      Me.Label8.Text = "Estado:"
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(466, 39)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(38, 13)
      Me.Label3.TabIndex = 5
      Me.Label3.Text = "Hasta:"
      '
      'cboLetra
      '
      Me.cboLetra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboLetra.FormattingEnabled = True
      Me.cboLetra.Location = New System.Drawing.Point(677, 3)
      Me.cboLetra.Name = "cboLetra"
      Me.cboLetra.Size = New System.Drawing.Size(57, 21)
      Me.cboLetra.TabIndex = 2
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(324, 40)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(41, 13)
      Me.Label4.TabIndex = 3
      Me.Label4.Text = "Desde:"
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(637, 6)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(34, 13)
      Me.Label2.TabIndex = 5
      Me.Label2.Text = "Letra:"
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.Location = New System.Drawing.Point(212, 40)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(45, 13)
      Me.Label5.TabIndex = 4
      Me.Label5.Text = "Fechas:"
      '
      'cboTipoComp
      '
      Me.cboTipoComp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboTipoComp.FormattingEnabled = True
      Me.cboTipoComp.Location = New System.Drawing.Point(54, 34)
      Me.cboTipoComp.Name = "cboTipoComp"
      Me.cboTipoComp.Size = New System.Drawing.Size(100, 21)
      Me.cboTipoComp.TabIndex = 3
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(16, 37)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(32, 13)
      Me.Label1.TabIndex = 3
      Me.Label1.Text = "Cpte:"
      '
      'cboCliente
      '
      Me.cboCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      Me.cboCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.cboCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboCliente.FormattingEnabled = True
      Me.cboCliente.Location = New System.Drawing.Point(251, 3)
      Me.cboCliente.Name = "cboCliente"
      Me.cboCliente.Size = New System.Drawing.Size(380, 21)
      Me.cboCliente.TabIndex = 1
      '
      'DataGridView1
      '
      Me.DataGridView1.AllowUserToAddRows = False
      Me.DataGridView1.AllowUserToDeleteRows = False
      Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
      Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.DataGridView1.Location = New System.Drawing.Point(12, 81)
      Me.DataGridView1.MultiSelect = False
      Me.DataGridView1.Name = "DataGridView1"
      Me.DataGridView1.ReadOnly = True
      Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.DataGridView1.Size = New System.Drawing.Size(789, 399)
      Me.DataGridView1.TabIndex = 8
      '
      'btnAlta
      '
      Me.btnAlta.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btnAlta.Location = New System.Drawing.Point(12, 487)
      Me.btnAlta.Name = "btnAlta"
      Me.btnAlta.Size = New System.Drawing.Size(62, 23)
      Me.btnAlta.TabIndex = 9
      Me.btnAlta.Text = "&Alta"
      Me.btnAlta.UseVisualStyleBackColor = True
      '
      'btnModif
      '
      Me.btnModif.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btnModif.Location = New System.Drawing.Point(153, 487)
      Me.btnModif.Name = "btnModif"
      Me.btnModif.Size = New System.Drawing.Size(69, 23)
      Me.btnModif.TabIndex = 11
      Me.btnModif.Text = "&Modificar"
      Me.btnModif.UseVisualStyleBackColor = True
      '
      'btnAnular
      '
      Me.btnAnular.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btnAnular.Location = New System.Drawing.Point(80, 487)
      Me.btnAnular.Name = "btnAnular"
      Me.btnAnular.Size = New System.Drawing.Size(67, 23)
      Me.btnAnular.TabIndex = 10
      Me.btnAnular.Text = "A&nular"
      Me.btnAnular.UseVisualStyleBackColor = True
      '
      'btnImprimir
      '
      Me.btnImprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btnImprimir.Location = New System.Drawing.Point(562, 487)
      Me.btnImprimir.Name = "btnImprimir"
      Me.btnImprimir.Size = New System.Drawing.Size(57, 24)
      Me.btnImprimir.TabIndex = 15
      Me.btnImprimir.Text = "&Imprimir"
      Me.btnImprimir.UseVisualStyleBackColor = True
      '
      'btnSalir
      '
      Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnSalir.CausesValidation = False
      Me.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnSalir.Location = New System.Drawing.Point(726, 487)
      Me.btnSalir.Name = "btnSalir"
      Me.btnSalir.Size = New System.Drawing.Size(75, 23)
      Me.btnSalir.TabIndex = 16
      Me.btnSalir.Text = "&Salir"
      Me.btnSalir.UseVisualStyleBackColor = True
      '
      'btnEliminar
      '
      Me.btnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btnEliminar.Location = New System.Drawing.Point(275, 487)
      Me.btnEliminar.Name = "btnEliminar"
      Me.btnEliminar.Size = New System.Drawing.Size(75, 23)
      Me.btnEliminar.TabIndex = 12
      Me.btnEliminar.Text = "&Eliminar"
      Me.btnEliminar.UseVisualStyleBackColor = True
      '
      'btnRenumerar
      '
      Me.btnRenumerar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btnRenumerar.Location = New System.Drawing.Point(356, 487)
      Me.btnRenumerar.Name = "btnRenumerar"
      Me.btnRenumerar.Size = New System.Drawing.Size(75, 23)
      Me.btnRenumerar.TabIndex = 13
      Me.btnRenumerar.Text = "&Renumerar"
      Me.btnRenumerar.UseVisualStyleBackColor = True
      '
      'btnVPrevia
      '
      Me.btnVPrevia.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btnVPrevia.Location = New System.Drawing.Point(481, 486)
      Me.btnVPrevia.Name = "btnVPrevia"
      Me.btnVPrevia.Size = New System.Drawing.Size(75, 24)
      Me.btnVPrevia.TabIndex = 14
      Me.btnVPrevia.Text = "&Vista Previa"
      Me.btnVPrevia.UseVisualStyleBackColor = True
      '
      'btnListado
      '
      Me.btnListado.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btnListado.Location = New System.Drawing.Point(626, 487)
      Me.btnListado.Name = "btnListado"
      Me.btnListado.Size = New System.Drawing.Size(57, 24)
      Me.btnListado.TabIndex = 17
      Me.btnListado.Text = "&Listado"
      Me.btnListado.UseVisualStyleBackColor = True
      '
      'frmVentas
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me.btnSalir
      Me.ClientSize = New System.Drawing.Size(812, 522)
      Me.Controls.Add(Me.btnListado)
      Me.Controls.Add(Me.btnVPrevia)
      Me.Controls.Add(Me.btnRenumerar)
      Me.Controls.Add(Me.btnEliminar)
      Me.Controls.Add(Me.btnSalir)
      Me.Controls.Add(Me.btnImprimir)
      Me.Controls.Add(Me.btnAnular)
      Me.Controls.Add(Me.btnModif)
      Me.Controls.Add(Me.btnAlta)
      Me.Controls.Add(Me.DataGridView1)
      Me.Controls.Add(Me.Panel1)
      Me.Name = "frmVentas"
      Me.Text = "Ventas"
      Me.Panel1.ResumeLayout(False)
      Me.Panel1.PerformLayout()
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents lblCliente As System.Windows.Forms.Label
   Friend WithEvents Panel1 As System.Windows.Forms.Panel
   Friend WithEvents cboLetra As System.Windows.Forms.ComboBox
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents cboTipoComp As System.Windows.Forms.ComboBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents cboCliente As System.Windows.Forms.ComboBox
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents dtpDesde As System.Windows.Forms.DateTimePicker
   Friend WithEvents chkFechas As System.Windows.Forms.CheckBox
   Friend WithEvents dtpHasta As System.Windows.Forms.DateTimePicker
   Friend WithEvents cboEstado As System.Windows.Forms.ComboBox
   Friend WithEvents Label8 As System.Windows.Forms.Label
   Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
   Friend WithEvents btnAlta As System.Windows.Forms.Button
   Friend WithEvents btnModif As System.Windows.Forms.Button
   Friend WithEvents btnAnular As System.Windows.Forms.Button
   Friend WithEvents btnImprimir As System.Windows.Forms.Button
   Friend WithEvents btnSalir As System.Windows.Forms.Button
   Friend WithEvents btnReset As System.Windows.Forms.Button
   Friend WithEvents btnEliminar As System.Windows.Forms.Button
   Friend WithEvents btnRenumerar As System.Windows.Forms.Button
   Friend WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents cboEmpresa As System.Windows.Forms.ComboBox
   Friend WithEvents btnVPrevia As System.Windows.Forms.Button
   Friend WithEvents btnListado As Button
End Class
