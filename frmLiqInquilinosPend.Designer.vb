<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLiqInquilinosPend
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
      Me.cboInquilino = New System.Windows.Forms.ComboBox()
      Me.Label13 = New System.Windows.Forms.Label()
      Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnRetencion = New System.Windows.Forms.Button()
        Me.cmdListado = New System.Windows.Forms.Button()
        Me.btnRestCol2 = New System.Windows.Forms.Button()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.cmdSalir = New System.Windows.Forms.Button()
        Me.cmdGenerar = New System.Windows.Forms.Button()
        Me.cmdImprimir = New System.Windows.Forms.Button()
        Me.cmdIngCheques = New System.Windows.Forms.Button()
        Me.cmdAnular = New System.Windows.Forms.Button()
        Me.cmdTransferencia = New System.Windows.Forms.Button()
        Me.cmdQuitar = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmdAgregar = New System.Windows.Forms.Button()
        Me.txtSaldoPend = New System.Windows.Forms.TextBox()
        Me.cmdConfirmar = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.txtEfectivo = New System.Windows.Forms.TextBox()
        Me.txtTransf = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbCheques = New System.Windows.Forms.TextBox()
        Me.txtRetencion = New System.Windows.Forms.TextBox()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkTodas = New System.Windows.Forms.CheckBox()
        Me.chkConfirmadas = New System.Windows.Forms.CheckBox()
        Me.btnRestCol1 = New System.Windows.Forms.Button()
        Me.DgvConf = New System.Windows.Forms.DataGridView()
        Me.btnLiqProp = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgvConf, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.DataGridView1.Location = New System.Drawing.Point(12, 33)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowTemplate.ReadOnly = True
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(967, 260)
        Me.DataGridView1.TabIndex = 4
        '
        'cboInquilino
        '
        Me.cboInquilino.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboInquilino.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboInquilino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboInquilino.FormattingEnabled = True
        Me.cboInquilino.Location = New System.Drawing.Point(69, 6)
        Me.cboInquilino.Name = "cboInquilino"
        Me.cboInquilino.Size = New System.Drawing.Size(351, 21)
        Me.cboInquilino.TabIndex = 0
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(12, 9)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(49, 13)
        Me.Label13.TabIndex = 96
        Me.Label13.Text = "Inquilino:"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.btnLiqProp)
        Me.Panel1.Controls.Add(Me.btnRetencion)
        Me.Panel1.Controls.Add(Me.cmdListado)
        Me.Panel1.Controls.Add(Me.btnRestCol2)
        Me.Panel1.Controls.Add(Me.cmdCancelar)
        Me.Panel1.Controls.Add(Me.cmdSalir)
        Me.Panel1.Controls.Add(Me.cmdGenerar)
        Me.Panel1.Controls.Add(Me.cmdImprimir)
        Me.Panel1.Controls.Add(Me.cmdIngCheques)
        Me.Panel1.Controls.Add(Me.cmdAnular)
        Me.Panel1.Controls.Add(Me.cmdTransferencia)
        Me.Panel1.Controls.Add(Me.cmdQuitar)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.cmdAgregar)
        Me.Panel1.Controls.Add(Me.txtSaldoPend)
        Me.Panel1.Controls.Add(Me.cmdConfirmar)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.DataGridView2)
        Me.Panel1.Controls.Add(Me.txtTotal)
        Me.Panel1.Controls.Add(Me.txtEfectivo)
        Me.Panel1.Controls.Add(Me.txtTransf)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.tbCheques)
        Me.Panel1.Controls.Add(Me.txtRetencion)
        Me.Panel1.Location = New System.Drawing.Point(12, 299)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(968, 289)
        Me.Panel1.TabIndex = 97
        '
        'btnRetencion
        '
        Me.btnRetencion.Location = New System.Drawing.Point(454, 223)
        Me.btnRetencion.Name = "btnRetencion"
        Me.btnRetencion.Size = New System.Drawing.Size(85, 23)
        Me.btnRetencion.TabIndex = 116
        Me.btnRetencion.Text = "&Retención/es"
        Me.btnRetencion.UseVisualStyleBackColor = True
        '
        'cmdListado
        '
        Me.cmdListado.Location = New System.Drawing.Point(12, 157)
        Me.cmdListado.Name = "cmdListado"
        Me.cmdListado.Size = New System.Drawing.Size(75, 23)
        Me.cmdListado.TabIndex = 115
        Me.cmdListado.Text = "&Listado"
        Me.cmdListado.UseVisualStyleBackColor = True
        '
        'btnRestCol2
        '
        Me.btnRestCol2.Location = New System.Drawing.Point(100, 5)
        Me.btnRestCol2.Name = "btnRestCol2"
        Me.btnRestCol2.Size = New System.Drawing.Size(28, 19)
        Me.btnRestCol2.TabIndex = 103
        Me.btnRestCol2.Text = "..."
        Me.btnRestCol2.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancelar.Location = New System.Drawing.Point(901, 254)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(63, 28)
        Me.cmdCancelar.TabIndex = 15
        Me.cmdCancelar.Text = "&Cancelar"
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'cmdSalir
        '
        Me.cmdSalir.Location = New System.Drawing.Point(12, 253)
        Me.cmdSalir.Name = "cmdSalir"
        Me.cmdSalir.Size = New System.Drawing.Size(75, 23)
        Me.cmdSalir.TabIndex = 5
        Me.cmdSalir.Text = "&Salir"
        Me.cmdSalir.UseVisualStyleBackColor = True
        '
        'cmdGenerar
        '
        Me.cmdGenerar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdGenerar.Location = New System.Drawing.Point(809, 254)
        Me.cmdGenerar.Name = "cmdGenerar"
        Me.cmdGenerar.Size = New System.Drawing.Size(86, 28)
        Me.cmdGenerar.TabIndex = 14
        Me.cmdGenerar.Text = "&Generar"
        Me.cmdGenerar.UseVisualStyleBackColor = True
        '
        'cmdImprimir
        '
        Me.cmdImprimir.Location = New System.Drawing.Point(12, 128)
        Me.cmdImprimir.Name = "cmdImprimir"
        Me.cmdImprimir.Size = New System.Drawing.Size(75, 23)
        Me.cmdImprimir.TabIndex = 9
        Me.cmdImprimir.Text = "&Imprimir"
        Me.cmdImprimir.UseVisualStyleBackColor = True
        '
        'cmdIngCheques
        '
        Me.cmdIngCheques.Location = New System.Drawing.Point(289, 224)
        Me.cmdIngCheques.Name = "cmdIngCheques"
        Me.cmdIngCheques.Size = New System.Drawing.Size(58, 23)
        Me.cmdIngCheques.TabIndex = 11
        Me.cmdIngCheques.Text = "&Cheques"
        Me.cmdIngCheques.UseVisualStyleBackColor = True
        '
        'cmdAnular
        '
        Me.cmdAnular.Location = New System.Drawing.Point(12, 99)
        Me.cmdAnular.Name = "cmdAnular"
        Me.cmdAnular.Size = New System.Drawing.Size(75, 23)
        Me.cmdAnular.TabIndex = 8
        Me.cmdAnular.Text = "Anular"
        Me.cmdAnular.UseVisualStyleBackColor = True
        '
        'cmdTransferencia
        '
        Me.cmdTransferencia.Location = New System.Drawing.Point(99, 223)
        Me.cmdTransferencia.Name = "cmdTransferencia"
        Me.cmdTransferencia.Size = New System.Drawing.Size(82, 23)
        Me.cmdTransferencia.TabIndex = 10
        Me.cmdTransferencia.Text = "&Transferencia"
        Me.cmdTransferencia.UseVisualStyleBackColor = True
        '
        'cmdQuitar
        '
        Me.cmdQuitar.Location = New System.Drawing.Point(12, 41)
        Me.cmdQuitar.Name = "cmdQuitar"
        Me.cmdQuitar.Size = New System.Drawing.Size(75, 23)
        Me.cmdQuitar.TabIndex = 6
        Me.cmdQuitar.Text = "Quitar"
        Me.cmdQuitar.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(253, 259)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(94, 13)
        Me.Label7.TabIndex = 114
        Me.Label7.Text = "Saldo Pendiente $"
        '
        'cmdAgregar
        '
        Me.cmdAgregar.Location = New System.Drawing.Point(12, 12)
        Me.cmdAgregar.Name = "cmdAgregar"
        Me.cmdAgregar.Size = New System.Drawing.Size(75, 23)
        Me.cmdAgregar.TabIndex = 5
        Me.cmdAgregar.Text = "Agregar"
        Me.cmdAgregar.UseVisualStyleBackColor = True
        '
        'txtSaldoPend
        '
        Me.txtSaldoPend.Enabled = False
        Me.txtSaldoPend.Location = New System.Drawing.Point(353, 256)
        Me.txtSaldoPend.Name = "txtSaldoPend"
        Me.txtSaldoPend.Size = New System.Drawing.Size(91, 20)
        Me.txtSaldoPend.TabIndex = 113
        '
        'cmdConfirmar
        '
        Me.cmdConfirmar.Location = New System.Drawing.Point(12, 70)
        Me.cmdConfirmar.Name = "cmdConfirmar"
        Me.cmdConfirmar.Size = New System.Drawing.Size(75, 23)
        Me.cmdConfirmar.TabIndex = 7
        Me.cmdConfirmar.Text = "Confirmar"
        Me.cmdConfirmar.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(98, 259)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 13)
        Me.Label6.TabIndex = 112
        Me.Label6.Text = "Total $"
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView2.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(99, 3)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.ReadOnly = True
        Me.DataGridView2.RowTemplate.ReadOnly = True
        Me.DataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView2.Size = New System.Drawing.Size(866, 213)
        Me.DataGridView2.TabIndex = 102
        '
        'txtTotal
        '
        Me.txtTotal.Enabled = False
        Me.txtTotal.Location = New System.Drawing.Point(144, 256)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(94, 20)
        Me.txtTotal.TabIndex = 111
        '
        'txtEfectivo
        '
        Me.txtEfectivo.Location = New System.Drawing.Point(706, 225)
        Me.txtEfectivo.Name = "txtEfectivo"
        Me.txtEfectivo.Size = New System.Drawing.Size(94, 20)
        Me.txtEfectivo.TabIndex = 13
        '
        'txtTransf
        '
        Me.txtTransf.Enabled = False
        Me.txtTransf.Location = New System.Drawing.Point(187, 225)
        Me.txtTransf.Name = "txtTransf"
        Me.txtTransf.Size = New System.Drawing.Size(89, 20)
        Me.txtTransf.TabIndex = 109
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(645, 229)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 104
        Me.Label2.Text = "Efectivo $"
        '
        'tbCheques
        '
        Me.tbCheques.Enabled = False
        Me.tbCheques.Location = New System.Drawing.Point(353, 225)
        Me.tbCheques.Name = "tbCheques"
        Me.tbCheques.Size = New System.Drawing.Size(91, 20)
        Me.tbCheques.TabIndex = 105
        '
        'txtRetencion
        '
        Me.txtRetencion.Enabled = False
        Me.txtRetencion.Location = New System.Drawing.Point(545, 225)
        Me.txtRetencion.Name = "txtRetencion"
        Me.txtRetencion.Size = New System.Drawing.Size(84, 20)
        Me.txtRetencion.TabIndex = 12
        '
        'dtpFecha
        '
        Me.dtpFecha.Enabled = False
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(492, 6)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(88, 20)
        Me.dtpFecha.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(446, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 99
        Me.Label1.Text = "Fecha:"
        '
        'chkTodas
        '
        Me.chkTodas.AutoSize = True
        Me.chkTodas.Checked = True
        Me.chkTodas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkTodas.Location = New System.Drawing.Point(596, 9)
        Me.chkTodas.Name = "chkTodas"
        Me.chkTodas.Size = New System.Drawing.Size(56, 17)
        Me.chkTodas.TabIndex = 2
        Me.chkTodas.Text = "&Todas"
        Me.chkTodas.UseVisualStyleBackColor = True
        '
        'chkConfirmadas
        '
        Me.chkConfirmadas.AutoSize = True
        Me.chkConfirmadas.Location = New System.Drawing.Point(681, 9)
        Me.chkConfirmadas.Name = "chkConfirmadas"
        Me.chkConfirmadas.Size = New System.Drawing.Size(84, 17)
        Me.chkConfirmadas.TabIndex = 3
        Me.chkConfirmadas.Text = "&Confirmadas"
        Me.chkConfirmadas.UseVisualStyleBackColor = True
        '
        'btnRestCol1
        '
        Me.btnRestCol1.Location = New System.Drawing.Point(14, 34)
        Me.btnRestCol1.Name = "btnRestCol1"
        Me.btnRestCol1.Size = New System.Drawing.Size(28, 19)
        Me.btnRestCol1.TabIndex = 102
        Me.btnRestCol1.Text = "..."
        Me.btnRestCol1.UseVisualStyleBackColor = True
        '
        'DgvConf
        '
        Me.DgvConf.AllowUserToAddRows = False
        Me.DgvConf.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvConf.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.DgvConf.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvConf.Location = New System.Drawing.Point(12, 33)
        Me.DgvConf.Name = "DgvConf"
        Me.DgvConf.ReadOnly = True
        Me.DgvConf.RowTemplate.ReadOnly = True
        Me.DgvConf.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvConf.Size = New System.Drawing.Size(967, 260)
        Me.DgvConf.TabIndex = 103
        '
        'btnLiqProp
        '
        Me.btnLiqProp.Enabled = False
        Me.btnLiqProp.Location = New System.Drawing.Point(12, 193)
        Me.btnLiqProp.Name = "btnLiqProp"
        Me.btnLiqProp.Size = New System.Drawing.Size(75, 23)
        Me.btnLiqProp.TabIndex = 117
        Me.btnLiqProp.Text = "&Liq. Propiet."
        Me.btnLiqProp.UseVisualStyleBackColor = True
        '
        'FrmLiqInquilinosPend
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(991, 590)
        Me.Controls.Add(Me.btnRestCol1)
        Me.Controls.Add(Me.chkConfirmadas)
        Me.Controls.Add(Me.chkTodas)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtpFecha)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.cboInquilino)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.DgvConf)
        Me.KeyPreview = True
        Me.Name = "FrmLiqInquilinosPend"
        Me.Text = "Recibos Inquilinos Pendientes"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgvConf, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
   Friend WithEvents cboInquilino As System.Windows.Forms.ComboBox
   Friend WithEvents Label13 As System.Windows.Forms.Label
   Friend WithEvents Panel1 As System.Windows.Forms.Panel
   Friend WithEvents cmdImprimir As System.Windows.Forms.Button
   Friend WithEvents cmdAnular As System.Windows.Forms.Button
   Friend WithEvents cmdQuitar As System.Windows.Forms.Button
   Friend WithEvents cmdAgregar As System.Windows.Forms.Button
   Friend WithEvents cmdConfirmar As System.Windows.Forms.Button
   Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents chkTodas As System.Windows.Forms.CheckBox
   Friend WithEvents chkConfirmadas As System.Windows.Forms.CheckBox
   Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
   Friend WithEvents txtEfectivo As System.Windows.Forms.TextBox
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents tbCheques As System.Windows.Forms.TextBox
    Friend WithEvents txtRetencion As System.Windows.Forms.TextBox
    Friend WithEvents txtTransf As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtSaldoPend As System.Windows.Forms.TextBox
    Friend WithEvents cmdTransferencia As System.Windows.Forms.Button
    Friend WithEvents cmdIngCheques As System.Windows.Forms.Button
    Friend WithEvents cmdGenerar As System.Windows.Forms.Button
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents cmdSalir As System.Windows.Forms.Button
    Friend WithEvents btnRestCol1 As System.Windows.Forms.Button
    Friend WithEvents btnRestCol2 As System.Windows.Forms.Button
    Friend WithEvents DgvConf As System.Windows.Forms.DataGridView
    Friend WithEvents cmdListado As System.Windows.Forms.Button
    Friend WithEvents btnRetencion As Button
    Friend WithEvents btnLiqProp As Button
End Class
