<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLiqPropietPend
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
      Me.cbPropietario = New System.Windows.Forms.ComboBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
      Me.Label22 = New System.Windows.Forms.Label()
      Me.btnRestCol1 = New System.Windows.Forms.Button()
      Me.DataGridView1 = New System.Windows.Forms.DataGridView()
      Me.cmdQuitar = New System.Windows.Forms.Button()
      Me.cmdAgregar = New System.Windows.Forms.Button()
      Me.chkTodas = New System.Windows.Forms.CheckBox()
      Me.cmdSalir = New System.Windows.Forms.Button()
      Me.cmdAnular = New System.Windows.Forms.Button()
      Me.DataGridView2 = New System.Windows.Forms.DataGridView()
      Me.cmdCancelar = New System.Windows.Forms.Button()
      Me.cmdGenerar = New System.Windows.Forms.Button()
      Me.cmdIngCheques = New System.Windows.Forms.Button()
      Me.cmdTransferencia = New System.Windows.Forms.Button()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.txtTotal = New System.Windows.Forms.TextBox()
      Me.txtEfectivo = New System.Windows.Forms.TextBox()
      Me.txtTransf = New System.Windows.Forms.TextBox()
      Me.lblEfectivo = New System.Windows.Forms.Label()
      Me.tbCheques = New System.Windows.Forms.TextBox()
      Me.btnRestCol2 = New System.Windows.Forms.Button()
      Me.cmdListado = New System.Windows.Forms.Button()
      Me.cmdImprimir = New System.Windows.Forms.Button()
      Me.chkGrupos = New System.Windows.Forms.CheckBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cbPropietario
        '
        Me.cbPropietario.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbPropietario.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbPropietario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPropietario.FormattingEnabled = True
        Me.cbPropietario.Location = New System.Drawing.Point(77, 12)
        Me.cbPropietario.Name = "cbPropietario"
        Me.cbPropietario.Size = New System.Drawing.Size(407, 21)
        Me.cbPropietario.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Propietario:"
        '
        'dtpFecha
        '
        Me.dtpFecha.Enabled = False
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(700, 12)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(88, 20)
        Me.dtpFecha.TabIndex = 3
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(654, 14)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(40, 13)
        Me.Label22.TabIndex = 114
        Me.Label22.Text = "Fecha:"
        '
        'btnRestCol1
        '
        Me.btnRestCol1.Location = New System.Drawing.Point(12, 39)
        Me.btnRestCol1.Name = "btnRestCol1"
        Me.btnRestCol1.Size = New System.Drawing.Size(28, 19)
        Me.btnRestCol1.TabIndex = 119
        Me.btnRestCol1.Text = "..."
        Me.btnRestCol1.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(12, 39)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowTemplate.ReadOnly = True
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(1069, 266)
        Me.DataGridView1.TabIndex = 4
        '
        'cmdQuitar
        '
        Me.cmdQuitar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdQuitar.Location = New System.Drawing.Point(14, 340)
        Me.cmdQuitar.Name = "cmdQuitar"
        Me.cmdQuitar.Size = New System.Drawing.Size(75, 23)
        Me.cmdQuitar.TabIndex = 6
        Me.cmdQuitar.Text = "Quitar"
        Me.cmdQuitar.UseVisualStyleBackColor = True
        '
        'cmdAgregar
        '
        Me.cmdAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdAgregar.Location = New System.Drawing.Point(14, 311)
        Me.cmdAgregar.Name = "cmdAgregar"
        Me.cmdAgregar.Size = New System.Drawing.Size(75, 23)
        Me.cmdAgregar.TabIndex = 5
        Me.cmdAgregar.Text = "Agregar"
        Me.cmdAgregar.UseVisualStyleBackColor = True
        '
        'chkTodas
        '
        Me.chkTodas.AutoSize = True
        Me.chkTodas.Checked = True
        Me.chkTodas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkTodas.Location = New System.Drawing.Point(592, 13)
        Me.chkTodas.Name = "chkTodas"
        Me.chkTodas.Size = New System.Drawing.Size(56, 17)
        Me.chkTodas.TabIndex = 2
        Me.chkTodas.Text = "&Todas"
        Me.chkTodas.UseVisualStyleBackColor = True
        '
        'cmdSalir
        '
        Me.cmdSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdSalir.Location = New System.Drawing.Point(14, 564)
        Me.cmdSalir.Name = "cmdSalir"
        Me.cmdSalir.Size = New System.Drawing.Size(75, 23)
        Me.cmdSalir.TabIndex = 10
        Me.cmdSalir.Text = "&Salir"
        Me.cmdSalir.UseVisualStyleBackColor = True
        '
        'cmdAnular
        '
        Me.cmdAnular.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdAnular.Location = New System.Drawing.Point(14, 407)
        Me.cmdAnular.Name = "cmdAnular"
        Me.cmdAnular.Size = New System.Drawing.Size(75, 23)
        Me.cmdAnular.TabIndex = 7
        Me.cmdAnular.Text = "Anular"
        Me.cmdAnular.UseVisualStyleBackColor = True
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView2.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(99, 311)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.ReadOnly = True
        Me.DataGridView2.RowTemplate.ReadOnly = True
        Me.DataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView2.Size = New System.Drawing.Size(982, 213)
        Me.DataGridView2.TabIndex = 123
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancelar.Enabled = False
        Me.cmdCancelar.Location = New System.Drawing.Point(1018, 561)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(63, 28)
        Me.cmdCancelar.TabIndex = 15
        Me.cmdCancelar.Text = "&Cancelar"
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'cmdGenerar
        '
        Me.cmdGenerar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdGenerar.Enabled = False
        Me.cmdGenerar.Location = New System.Drawing.Point(926, 561)
        Me.cmdGenerar.Name = "cmdGenerar"
        Me.cmdGenerar.Size = New System.Drawing.Size(86, 28)
        Me.cmdGenerar.TabIndex = 14
        Me.cmdGenerar.Text = "&Generar"
        Me.cmdGenerar.UseVisualStyleBackColor = True
        '
        'cmdIngCheques
        '
        Me.cmdIngCheques.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdIngCheques.Enabled = False
        Me.cmdIngCheques.Location = New System.Drawing.Point(209, 562)
        Me.cmdIngCheques.Name = "cmdIngCheques"
        Me.cmdIngCheques.Size = New System.Drawing.Size(82, 23)
        Me.cmdIngCheques.TabIndex = 12
        Me.cmdIngCheques.Text = "&Cheques"
        Me.cmdIngCheques.UseVisualStyleBackColor = True
        '
        'cmdTransferencia
        '
        Me.cmdTransferencia.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdTransferencia.Enabled = False
        Me.cmdTransferencia.Location = New System.Drawing.Point(209, 530)
        Me.cmdTransferencia.Name = "cmdTransferencia"
        Me.cmdTransferencia.Size = New System.Drawing.Size(82, 23)
        Me.cmdTransferencia.TabIndex = 11
        Me.cmdTransferencia.Text = "&Transferencia"
        Me.cmdTransferencia.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Enabled = False
        Me.Label6.Location = New System.Drawing.Point(940, 533)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 13)
        Me.Label6.TabIndex = 133
        Me.Label6.Text = "Total $"
        '
        'txtTotal
        '
        Me.txtTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotal.BackColor = System.Drawing.Color.LightYellow
        Me.txtTotal.Enabled = False
        Me.txtTotal.Location = New System.Drawing.Point(987, 530)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(94, 20)
        Me.txtTotal.TabIndex = 132
        '
        'txtEfectivo
        '
        Me.txtEfectivo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtEfectivo.Enabled = False
        Me.txtEfectivo.Location = New System.Drawing.Point(462, 565)
        Me.txtEfectivo.Name = "txtEfectivo"
        Me.txtEfectivo.Size = New System.Drawing.Size(94, 20)
        Me.txtEfectivo.TabIndex = 13
        '
        'txtTransf
        '
        Me.txtTransf.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtTransf.BackColor = System.Drawing.Color.LightYellow
        Me.txtTransf.Enabled = False
        Me.txtTransf.Location = New System.Drawing.Point(297, 532)
        Me.txtTransf.Name = "txtTransf"
        Me.txtTransf.Size = New System.Drawing.Size(89, 20)
        Me.txtTransf.TabIndex = 131
        '
        'lblEfectivo
        '
        Me.lblEfectivo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblEfectivo.AutoSize = True
        Me.lblEfectivo.Enabled = False
        Me.lblEfectivo.Location = New System.Drawing.Point(401, 568)
        Me.lblEfectivo.Name = "lblEfectivo"
        Me.lblEfectivo.Size = New System.Drawing.Size(55, 13)
        Me.lblEfectivo.TabIndex = 129
        Me.lblEfectivo.Text = "Efectivo $"
        '
        'tbCheques
        '
        Me.tbCheques.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tbCheques.BackColor = System.Drawing.Color.LightYellow
        Me.tbCheques.Enabled = False
        Me.tbCheques.Location = New System.Drawing.Point(297, 564)
        Me.tbCheques.Name = "tbCheques"
        Me.tbCheques.Size = New System.Drawing.Size(89, 20)
        Me.tbCheques.TabIndex = 130
        '
        'btnRestCol2
        '
        Me.btnRestCol2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnRestCol2.Location = New System.Drawing.Point(99, 311)
        Me.btnRestCol2.Name = "btnRestCol2"
        Me.btnRestCol2.Size = New System.Drawing.Size(28, 19)
        Me.btnRestCol2.TabIndex = 134
        Me.btnRestCol2.Text = "..."
        Me.btnRestCol2.UseVisualStyleBackColor = True
        '
        'cmdListado
        '
        Me.cmdListado.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdListado.Location = New System.Drawing.Point(14, 533)
        Me.cmdListado.Name = "cmdListado"
        Me.cmdListado.Size = New System.Drawing.Size(75, 23)
        Me.cmdListado.TabIndex = 9
        Me.cmdListado.Text = "&Listado"
        Me.cmdListado.UseVisualStyleBackColor = True
        '
        'cmdImprimir
        '
        Me.cmdImprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdImprimir.Location = New System.Drawing.Point(14, 436)
        Me.cmdImprimir.Name = "cmdImprimir"
        Me.cmdImprimir.Size = New System.Drawing.Size(75, 23)
        Me.cmdImprimir.TabIndex = 8
        Me.cmdImprimir.Text = "&Imprimir"
        Me.cmdImprimir.UseVisualStyleBackColor = True
        '
        'chkGrupos
        '
        Me.chkGrupos.AutoSize = True
        Me.chkGrupos.Location = New System.Drawing.Point(490, 14)
        Me.chkGrupos.Name = "chkGrupos"
        Me.chkGrupos.Size = New System.Drawing.Size(77, 17)
        Me.chkGrupos.TabIndex = 1
        Me.chkGrupos.Text = "&Agrupados"
        Me.chkGrupos.UseVisualStyleBackColor = True
        '
        'frmLiqPropietPend
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1093, 601)
        Me.Controls.Add(Me.chkGrupos)
        Me.Controls.Add(Me.cmdListado)
        Me.Controls.Add(Me.cmdImprimir)
        Me.Controls.Add(Me.btnRestCol2)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdGenerar)
        Me.Controls.Add(Me.cmdIngCheques)
        Me.Controls.Add(Me.cmdTransferencia)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.txtEfectivo)
        Me.Controls.Add(Me.txtTransf)
        Me.Controls.Add(Me.lblEfectivo)
        Me.Controls.Add(Me.tbCheques)
        Me.Controls.Add(Me.cmdSalir)
        Me.Controls.Add(Me.cmdAnular)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.btnRestCol1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.cmdQuitar)
        Me.Controls.Add(Me.cmdAgregar)
        Me.Controls.Add(Me.chkTodas)
        Me.Controls.Add(Me.dtpFecha)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.cbPropietario)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmLiqPropietPend"
        Me.Text = "Liquidaciones Propietarios Pendientes"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cbPropietario As System.Windows.Forms.ComboBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
   Friend WithEvents Label22 As System.Windows.Forms.Label
   Friend WithEvents btnRestCol1 As System.Windows.Forms.Button
   Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
   Friend WithEvents cmdQuitar As System.Windows.Forms.Button
   Friend WithEvents cmdAgregar As System.Windows.Forms.Button
   Friend WithEvents chkTodas As System.Windows.Forms.CheckBox
   Friend WithEvents cmdSalir As System.Windows.Forms.Button
   Friend WithEvents cmdAnular As System.Windows.Forms.Button
   Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
   Friend WithEvents cmdCancelar As System.Windows.Forms.Button
   Friend WithEvents cmdGenerar As System.Windows.Forms.Button
   Friend WithEvents cmdIngCheques As System.Windows.Forms.Button
   Friend WithEvents cmdTransferencia As System.Windows.Forms.Button
   Friend WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents txtTotal As System.Windows.Forms.TextBox
   Friend WithEvents txtEfectivo As System.Windows.Forms.TextBox
   Friend WithEvents txtTransf As System.Windows.Forms.TextBox
   Friend WithEvents lblEfectivo As System.Windows.Forms.Label
   Friend WithEvents tbCheques As System.Windows.Forms.TextBox
   Friend WithEvents btnRestCol2 As System.Windows.Forms.Button
   Friend WithEvents cmdListado As System.Windows.Forms.Button
   Friend WithEvents cmdImprimir As System.Windows.Forms.Button
   Friend WithEvents chkGrupos As System.Windows.Forms.CheckBox
End Class
