<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLiqPropiet
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
      Me.Label1 = New System.Windows.Forms.Label()
      Me.cbDescProp = New System.Windows.Forms.ComboBox()
      Me.DataGridView1 = New System.Windows.Forms.DataGridView()
      Me.cbPeriodo = New System.Windows.Forms.ComboBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.cbDescPrd = New System.Windows.Forms.ComboBox()
      Me.Label7 = New System.Windows.Forms.Label()
      Me.tbNetoCom = New System.Windows.Forms.TextBox()
      Me.lblComision = New System.Windows.Forms.Label()
      Me.tbComision = New System.Windows.Forms.TextBox()
      Me.lblIva1 = New System.Windows.Forms.Label()
      Me.tIva1 = New System.Windows.Forms.TextBox()
      Me.Label10 = New System.Windows.Forms.Label()
      Me.Label11 = New System.Windows.Forms.Label()
      Me.tSubtotal = New System.Windows.Forms.TextBox()
      Me.Label12 = New System.Windows.Forms.Label()
      Me.tHaber = New System.Windows.Forms.TextBox()
      Me.Label13 = New System.Windows.Forms.Label()
      Me.tDebe = New System.Windows.Forms.TextBox()
      Me.cmdAceptar = New System.Windows.Forms.Button()
      Me.cmdAdelanto = New System.Windows.Forms.Button()
      Me.Label8 = New System.Windows.Forms.Label()
      Me.tbNroLiq = New System.Windows.Forms.TextBox()
      Me.lblRetGan = New System.Windows.Forms.GroupBox()
      Me.Label17 = New System.Windows.Forms.Label()
      Me.tbAcuPer = New System.Windows.Forms.TextBox()
      Me.Label16 = New System.Windows.Forms.Label()
      Me.tbNeto = New System.Windows.Forms.TextBox()
      Me.Label9 = New System.Windows.Forms.Label()
      Me.tbNroRetG = New System.Windows.Forms.TextBox()
      Me.Label15 = New System.Windows.Forms.Label()
      Me.tbRetGan = New System.Windows.Forms.TextBox()
      Me.Label14 = New System.Windows.Forms.Label()
      Me.lblTipo = New System.Windows.Forms.Label()
      Me.tbFactura = New System.Windows.Forms.TextBox()
      Me.cmdGenerar = New System.Windows.Forms.Button()
      Me.cmdPendiente = New System.Windows.Forms.Button()
      Me.cmdCancelar = New System.Windows.Forms.Button()
      Me.cmdSalir = New System.Windows.Forms.Button()
      Me.Label18 = New System.Windows.Forms.Label()
      Me.tbRecibo = New System.Windows.Forms.TextBox()
      Me.gbPago = New System.Windows.Forms.GroupBox()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.txtTransferencia = New System.Windows.Forms.TextBox()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.tbCheques = New System.Windows.Forms.TextBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.cmdIngCheques = New System.Windows.Forms.Button()
      Me.cmdTransferencia = New System.Windows.Forms.Button()
      Me.tbEfectivo = New System.Windows.Forms.TextBox()
      Me.Label23 = New System.Windows.Forms.Label()
      Me.TextBox1 = New System.Windows.Forms.TextBox()
      Me.tbDetalle = New System.Windows.Forms.TextBox()
      Me.Label19 = New System.Windows.Forms.Label()
      Me.Label20 = New System.Windows.Forms.Label()
      Me.tbAlquiler = New System.Windows.Forms.TextBox()
      Me.Label21 = New System.Windows.Forms.Label()
      Me.tbRetInq = New System.Windows.Forms.TextBox()
      Me.Label22 = New System.Windows.Forms.Label()
      Me.tbGtosBanc = New System.Windows.Forms.TextBox()
      Me.tTotal = New System.Windows.Forms.TextBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.lblRetGan.SuspendLayout()
        Me.gbPago.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Propietario:"
        '
        'cbDescProp
        '
        Me.cbDescProp.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbDescProp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbDescProp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDescProp.FormattingEnabled = True
        Me.cbDescProp.Location = New System.Drawing.Point(78, 14)
        Me.cbDescProp.Name = "cbDescProp"
        Me.cbDescProp.Size = New System.Drawing.Size(407, 21)
        Me.cbDescProp.TabIndex = 0
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
        Me.DataGridView1.Location = New System.Drawing.Point(12, 68)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowTemplate.ReadOnly = True
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(958, 342)
        Me.DataGridView1.TabIndex = 36
        '
        'cbPeriodo
        '
        Me.cbPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPeriodo.FormattingEnabled = True
        Me.cbPeriodo.Location = New System.Drawing.Point(78, 42)
        Me.cbPeriodo.Name = "cbPeriodo"
        Me.cbPeriodo.Size = New System.Drawing.Size(81, 21)
        Me.cbPeriodo.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(24, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 38
        Me.Label2.Text = "Período:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(165, 45)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(58, 13)
        Me.Label6.TabIndex = 48
        Me.Label6.Text = "Propiedad:"
        '
        'cbDescPrd
        '
        Me.cbDescPrd.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbDescPrd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDescPrd.FormattingEnabled = True
        Me.cbDescPrd.Location = New System.Drawing.Point(229, 42)
        Me.cbDescPrd.Name = "cbDescPrd"
        Me.cbDescPrd.Size = New System.Drawing.Size(460, 21)
        Me.cbDescPrd.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(539, 537)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(39, 13)
        Me.Label7.TabIndex = 50
        Me.Label7.Text = "Neto $"
        '
        'tbNetoCom
        '
        Me.tbNetoCom.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbNetoCom.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.tbNetoCom.Enabled = False
        Me.tbNetoCom.Location = New System.Drawing.Point(542, 553)
        Me.tbNetoCom.Name = "tbNetoCom"
        Me.tbNetoCom.Size = New System.Drawing.Size(71, 20)
        Me.tbNetoCom.TabIndex = 49
        '
        'lblComision
        '
        Me.lblComision.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblComision.AutoSize = True
        Me.lblComision.Location = New System.Drawing.Point(616, 537)
        Me.lblComision.Name = "lblComision"
        Me.lblComision.Size = New System.Drawing.Size(58, 13)
        Me.lblComision.TabIndex = 52
        Me.lblComision.Text = "Comisión $"
        '
        'tbComision
        '
        Me.tbComision.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbComision.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.tbComision.Enabled = False
        Me.tbComision.Location = New System.Drawing.Point(619, 553)
        Me.tbComision.Name = "tbComision"
        Me.tbComision.Size = New System.Drawing.Size(71, 20)
        Me.tbComision.TabIndex = 51
        '
        'lblIva1
        '
        Me.lblIva1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblIva1.AutoSize = True
        Me.lblIva1.Location = New System.Drawing.Point(693, 537)
        Me.lblIva1.Name = "lblIva1"
        Me.lblIva1.Size = New System.Drawing.Size(31, 13)
        Me.lblIva1.TabIndex = 54
        Me.lblIva1.Text = "Iva $"
        '
        'tIva1
        '
        Me.tIva1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tIva1.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.tIva1.Enabled = False
        Me.tIva1.Location = New System.Drawing.Point(696, 553)
        Me.tIva1.Name = "tIva1"
        Me.tIva1.Size = New System.Drawing.Size(71, 20)
        Me.tIva1.TabIndex = 53
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(770, 537)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(40, 13)
        Me.Label10.TabIndex = 56
        Me.Label10.Text = "Total $"
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(838, 420)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(55, 13)
        Me.Label11.TabIndex = 58
        Me.Label11.Text = "Subtotal $"
        '
        'tSubtotal
        '
        Me.tSubtotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tSubtotal.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.tSubtotal.Enabled = False
        Me.tSubtotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tSubtotal.Location = New System.Drawing.Point(899, 417)
        Me.tSubtotal.Name = "tSubtotal"
        Me.tSubtotal.Size = New System.Drawing.Size(71, 20)
        Me.tSubtotal.TabIndex = 57
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(701, 420)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(54, 13)
        Me.Label12.TabIndex = 60
        Me.Label12.Text = "Créditos $"
        '
        'tHaber
        '
        Me.tHaber.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tHaber.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.tHaber.Enabled = False
        Me.tHaber.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tHaber.Location = New System.Drawing.Point(761, 417)
        Me.tHaber.Name = "tHaber"
        Me.tHaber.Size = New System.Drawing.Size(71, 20)
        Me.tHaber.TabIndex = 59
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(566, 420)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(52, 13)
        Me.Label13.TabIndex = 62
        Me.Label13.Text = "Débitos $"
        '
        'tDebe
        '
        Me.tDebe.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tDebe.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.tDebe.Enabled = False
        Me.tDebe.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tDebe.Location = New System.Drawing.Point(624, 417)
        Me.tDebe.Name = "tDebe"
        Me.tDebe.Size = New System.Drawing.Size(71, 20)
        Me.tDebe.TabIndex = 61
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Location = New System.Drawing.Point(491, 11)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(76, 27)
        Me.cmdAceptar.TabIndex = 1
        Me.cmdAceptar.Text = "&Aceptar"
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'cmdAdelanto
        '
        Me.cmdAdelanto.Location = New System.Drawing.Point(573, 11)
        Me.cmdAdelanto.Name = "cmdAdelanto"
        Me.cmdAdelanto.Size = New System.Drawing.Size(76, 27)
        Me.cmdAdelanto.TabIndex = 2
        Me.cmdAdelanto.Text = "Adelanto"
        Me.cmdAdelanto.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(657, 18)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(19, 13)
        Me.Label8.TabIndex = 66
        Me.Label8.Text = "Nº"
        '
        'tbNroLiq
        '
        Me.tbNroLiq.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.tbNroLiq.Enabled = False
        Me.tbNroLiq.Location = New System.Drawing.Point(682, 14)
        Me.tbNroLiq.Name = "tbNroLiq"
        Me.tbNroLiq.Size = New System.Drawing.Size(71, 20)
        Me.tbNroLiq.TabIndex = 65
        '
        'lblRetGan
        '
        Me.lblRetGan.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblRetGan.Controls.Add(Me.Label17)
        Me.lblRetGan.Controls.Add(Me.tbAcuPer)
        Me.lblRetGan.Controls.Add(Me.Label16)
        Me.lblRetGan.Controls.Add(Me.tbNeto)
        Me.lblRetGan.Controls.Add(Me.Label9)
        Me.lblRetGan.Controls.Add(Me.tbNroRetG)
        Me.lblRetGan.Controls.Add(Me.Label15)
        Me.lblRetGan.Controls.Add(Me.tbRetGan)
        Me.lblRetGan.Location = New System.Drawing.Point(15, 417)
        Me.lblRetGan.Name = "lblRetGan"
        Me.lblRetGan.Size = New System.Drawing.Size(337, 58)
        Me.lblRetGan.TabIndex = 67
        Me.lblRetGan.TabStop = False
        Me.lblRetGan.Text = "Ganancias"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(30, 16)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(54, 13)
        Me.Label17.TabIndex = 80
        Me.Label17.Text = "Acu.Per.$"
        '
        'tbAcuPer
        '
        Me.tbAcuPer.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.tbAcuPer.Enabled = False
        Me.tbAcuPer.Location = New System.Drawing.Point(13, 32)
        Me.tbAcuPer.Name = "tbAcuPer"
        Me.tbAcuPer.Size = New System.Drawing.Size(71, 20)
        Me.tbAcuPer.TabIndex = 79
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(122, 16)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(39, 13)
        Me.Label16.TabIndex = 78
        Me.Label16.Text = "Neto $"
        '
        'tbNeto
        '
        Me.tbNeto.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.tbNeto.Enabled = False
        Me.tbNeto.Location = New System.Drawing.Point(90, 32)
        Me.tbNeto.Name = "tbNeto"
        Me.tbNeto.Size = New System.Drawing.Size(71, 20)
        Me.tbNeto.TabIndex = 77
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(276, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(39, 13)
        Me.Label9.TabIndex = 76
        Me.Label9.Text = "Ret.Nº"
        '
        'tbNroRetG
        '
        Me.tbNroRetG.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.tbNroRetG.Enabled = False
        Me.tbNroRetG.Location = New System.Drawing.Point(244, 32)
        Me.tbNroRetG.Name = "tbNroRetG"
        Me.tbNroRetG.Size = New System.Drawing.Size(71, 20)
        Me.tbNroRetG.TabIndex = 75
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(202, 16)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(36, 13)
        Me.Label15.TabIndex = 74
        Me.Label15.Text = "Ret. $"
        '
        'tbRetGan
        '
        Me.tbRetGan.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.tbRetGan.Enabled = False
        Me.tbRetGan.Location = New System.Drawing.Point(167, 32)
        Me.tbRetGan.Name = "tbRetGan"
        Me.tbRetGan.Size = New System.Drawing.Size(71, 20)
        Me.tbRetGan.TabIndex = 73
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(698, 45)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(43, 13)
        Me.Label14.TabIndex = 68
        Me.Label14.Text = "Factura"
        '
        'lblTipo
        '
        Me.lblTipo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTipo.AutoSize = True
        Me.lblTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipo.Location = New System.Drawing.Point(745, 45)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(15, 13)
        Me.lblTipo.TabIndex = 69
        Me.lblTipo.Text = "X"
        '
        'tbFactura
        '
        Me.tbFactura.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbFactura.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.tbFactura.Enabled = False
        Me.tbFactura.Location = New System.Drawing.Point(766, 42)
        Me.tbFactura.Name = "tbFactura"
        Me.tbFactura.Size = New System.Drawing.Size(71, 20)
        Me.tbFactura.TabIndex = 70
        '
        'cmdGenerar
        '
        Me.cmdGenerar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdGenerar.Location = New System.Drawing.Point(894, 493)
        Me.cmdGenerar.Name = "cmdGenerar"
        Me.cmdGenerar.Size = New System.Drawing.Size(76, 27)
        Me.cmdGenerar.TabIndex = 8
        Me.cmdGenerar.Text = "&Generar"
        Me.cmdGenerar.UseVisualStyleBackColor = True
        '
        'cmdPendiente
        '
        Me.cmdPendiente.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPendiente.Location = New System.Drawing.Point(894, 524)
        Me.cmdPendiente.Name = "cmdPendiente"
        Me.cmdPendiente.Size = New System.Drawing.Size(76, 27)
        Me.cmdPendiente.TabIndex = 9
        Me.cmdPendiente.Text = "&Pendiente"
        Me.cmdPendiente.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancelar.Location = New System.Drawing.Point(894, 556)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(76, 27)
        Me.cmdCancelar.TabIndex = 10
        Me.cmdCancelar.Text = "&Cancelar"
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'cmdSalir
        '
        Me.cmdSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSalir.Location = New System.Drawing.Point(894, 10)
        Me.cmdSalir.Name = "cmdSalir"
        Me.cmdSalir.Size = New System.Drawing.Size(76, 27)
        Me.cmdSalir.TabIndex = 11
        Me.cmdSalir.Text = "&Salir"
        Me.cmdSalir.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(844, 45)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(56, 13)
        Me.Label18.TabIndex = 76
        Me.Label18.Text = "Recibo Nº"
        '
        'tbRecibo
        '
        Me.tbRecibo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbRecibo.Location = New System.Drawing.Point(906, 42)
        Me.tbRecibo.Name = "tbRecibo"
        Me.tbRecibo.Size = New System.Drawing.Size(64, 20)
        Me.tbRecibo.TabIndex = 5
        '
        'gbPago
        '
        Me.gbPago.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gbPago.Controls.Add(Me.Label5)
        Me.gbPago.Controls.Add(Me.txtTransferencia)
        Me.gbPago.Controls.Add(Me.Label4)
        Me.gbPago.Controls.Add(Me.tbCheques)
        Me.gbPago.Controls.Add(Me.Label3)
        Me.gbPago.Controls.Add(Me.cmdIngCheques)
        Me.gbPago.Controls.Add(Me.cmdTransferencia)
        Me.gbPago.Controls.Add(Me.tbEfectivo)
        Me.gbPago.Controls.Add(Me.Label23)
        Me.gbPago.Controls.Add(Me.TextBox1)
        Me.gbPago.Location = New System.Drawing.Point(15, 481)
        Me.gbPago.Name = "gbPago"
        Me.gbPago.Size = New System.Drawing.Size(337, 100)
        Me.gbPago.TabIndex = 77
        Me.gbPago.TabStop = False
        Me.gbPago.Text = "Pago"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(17, 75)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 13)
        Me.Label5.TabIndex = 54
        Me.Label5.Text = "Transferencia $"
        '
        'txtTransferencia
        '
        Me.txtTransferencia.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.txtTransferencia.Enabled = False
        Me.txtTransferencia.Location = New System.Drawing.Point(104, 72)
        Me.txtTransferencia.Name = "txtTransferencia"
        Me.txtTransferencia.Size = New System.Drawing.Size(100, 20)
        Me.txtTransferencia.TabIndex = 53
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(40, 45)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 13)
        Me.Label4.TabIndex = 52
        Me.Label4.Text = "Cheques $"
        '
        'tbCheques
        '
        Me.tbCheques.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.tbCheques.Enabled = False
        Me.tbCheques.Location = New System.Drawing.Point(104, 42)
        Me.tbCheques.Name = "tbCheques"
        Me.tbCheques.Size = New System.Drawing.Size(100, 20)
        Me.tbCheques.TabIndex = 51
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(43, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 50
        Me.Label3.Text = "Efectivo $"
        '
        'cmdIngCheques
        '
        Me.cmdIngCheques.Location = New System.Drawing.Point(210, 42)
        Me.cmdIngCheques.Name = "cmdIngCheques"
        Me.cmdIngCheques.Size = New System.Drawing.Size(100, 24)
        Me.cmdIngCheques.TabIndex = 49
        Me.cmdIngCheques.Text = "Che&ques"
        Me.cmdIngCheques.UseVisualStyleBackColor = True
        '
        'cmdTransferencia
        '
        Me.cmdTransferencia.Location = New System.Drawing.Point(210, 71)
        Me.cmdTransferencia.Name = "cmdTransferencia"
        Me.cmdTransferencia.Size = New System.Drawing.Size(100, 23)
        Me.cmdTransferencia.TabIndex = 48
        Me.cmdTransferencia.Text = "&Transferencia"
        Me.cmdTransferencia.UseVisualStyleBackColor = True
        '
        'tbEfectivo
        '
        Me.tbEfectivo.Location = New System.Drawing.Point(104, 16)
        Me.tbEfectivo.Name = "tbEfectivo"
        Me.tbEfectivo.Size = New System.Drawing.Size(100, 20)
        Me.tbEfectivo.TabIndex = 6
        '
        'Label23
        '
        Me.Label23.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(713, -61)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(55, 13)
        Me.Label23.TabIndex = 58
        Me.Label23.Text = "Subtotal $"
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.TextBox1.Enabled = False
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(774, -64)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(71, 20)
        Me.TextBox1.TabIndex = 57
        '
        'tbDetalle
        '
        Me.tbDetalle.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbDetalle.Location = New System.Drawing.Point(542, 443)
        Me.tbDetalle.Multiline = True
        Me.tbDetalle.Name = "tbDetalle"
        Me.tbDetalle.Size = New System.Drawing.Size(428, 46)
        Me.tbDetalle.TabIndex = 7
        '
        'Label19
        '
        Me.Label19.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(493, 452)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(47, 13)
        Me.Label19.TabIndex = 79
        Me.Label19.Text = "Observ.:"
        '
        'Label20
        '
        Me.Label20.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(539, 498)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(50, 13)
        Me.Label20.TabIndex = 81
        Me.Label20.Text = "Alquiler $"
        '
        'tbAlquiler
        '
        Me.tbAlquiler.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbAlquiler.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.tbAlquiler.Enabled = False
        Me.tbAlquiler.Location = New System.Drawing.Point(542, 514)
        Me.tbAlquiler.Name = "tbAlquiler"
        Me.tbAlquiler.Size = New System.Drawing.Size(71, 20)
        Me.tbAlquiler.TabIndex = 80
        '
        'Label21
        '
        Me.Label21.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(616, 498)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(51, 13)
        Me.Label21.TabIndex = 83
        Me.Label21.Text = "Ret.Inq.$"
        '
        'tbRetInq
        '
        Me.tbRetInq.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbRetInq.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.tbRetInq.Enabled = False
        Me.tbRetInq.Location = New System.Drawing.Point(619, 514)
        Me.tbRetInq.Name = "tbRetInq"
        Me.tbRetInq.Size = New System.Drawing.Size(71, 20)
        Me.tbRetInq.TabIndex = 82
        '
        'Label22
        '
        Me.Label22.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(693, 498)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(66, 13)
        Me.Label22.TabIndex = 85
        Me.Label22.Text = "Gtos.Banc.$"
        '
        'tbGtosBanc
        '
        Me.tbGtosBanc.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbGtosBanc.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.tbGtosBanc.Enabled = False
        Me.tbGtosBanc.Location = New System.Drawing.Point(696, 514)
        Me.tbGtosBanc.Name = "tbGtosBanc"
        Me.tbGtosBanc.Size = New System.Drawing.Size(71, 20)
        Me.tbGtosBanc.TabIndex = 84
        '
        'tTotal
        '
        Me.tTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tTotal.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.tTotal.Enabled = False
        Me.tTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tTotal.Location = New System.Drawing.Point(773, 553)
        Me.tTotal.Name = "tTotal"
        Me.tTotal.Size = New System.Drawing.Size(71, 20)
        Me.tTotal.TabIndex = 55
        '
        'frmLiqPropiet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdSalir
        Me.ClientSize = New System.Drawing.Size(974, 589)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.tbGtosBanc)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.tbRetInq)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.tbAlquiler)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.tbDetalle)
        Me.Controls.Add(Me.gbPago)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.tbRecibo)
        Me.Controls.Add(Me.cmdSalir)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdPendiente)
        Me.Controls.Add(Me.cmdGenerar)
        Me.Controls.Add(Me.tbFactura)
        Me.Controls.Add(Me.lblTipo)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.lblRetGan)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.tbNroLiq)
        Me.Controls.Add(Me.cmdAdelanto)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.tDebe)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.tHaber)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.tSubtotal)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.tTotal)
        Me.Controls.Add(Me.lblIva1)
        Me.Controls.Add(Me.tIva1)
        Me.Controls.Add(Me.lblComision)
        Me.Controls.Add(Me.tbComision)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.tbNetoCom)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cbDescPrd)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cbPeriodo)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.cbDescProp)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLiqPropiet"
        Me.Text = "Liquidación Propietario"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.lblRetGan.ResumeLayout(False)
        Me.lblRetGan.PerformLayout()
        Me.gbPago.ResumeLayout(False)
        Me.gbPago.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents cbDescProp As System.Windows.Forms.ComboBox
   Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
   Friend WithEvents cbPeriodo As System.Windows.Forms.ComboBox
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents cbDescPrd As System.Windows.Forms.ComboBox
   Friend WithEvents Label7 As System.Windows.Forms.Label
   Friend WithEvents tbNetoCom As System.Windows.Forms.TextBox
   Friend WithEvents lblComision As System.Windows.Forms.Label
   Friend WithEvents tbComision As System.Windows.Forms.TextBox
   Friend WithEvents lblIva1 As System.Windows.Forms.Label
   Friend WithEvents tIva1 As System.Windows.Forms.TextBox
   Friend WithEvents Label10 As System.Windows.Forms.Label
   Friend WithEvents Label11 As System.Windows.Forms.Label
   Friend WithEvents tSubtotal As System.Windows.Forms.TextBox
   Friend WithEvents Label12 As System.Windows.Forms.Label
   Friend WithEvents tHaber As System.Windows.Forms.TextBox
   Friend WithEvents Label13 As System.Windows.Forms.Label
   Friend WithEvents tDebe As System.Windows.Forms.TextBox
   Friend WithEvents cmdAceptar As System.Windows.Forms.Button
   Friend WithEvents cmdAdelanto As System.Windows.Forms.Button
   Friend WithEvents Label8 As System.Windows.Forms.Label
   Friend WithEvents tbNroLiq As System.Windows.Forms.TextBox
   Friend WithEvents lblRetGan As System.Windows.Forms.GroupBox
   Friend WithEvents Label14 As System.Windows.Forms.Label
   Friend WithEvents lblTipo As System.Windows.Forms.Label
   Friend WithEvents tbFactura As System.Windows.Forms.TextBox
   Friend WithEvents Label17 As System.Windows.Forms.Label
   Friend WithEvents tbAcuPer As System.Windows.Forms.TextBox
   Friend WithEvents Label16 As System.Windows.Forms.Label
   Friend WithEvents tbNeto As System.Windows.Forms.TextBox
   Friend WithEvents Label9 As System.Windows.Forms.Label
   Friend WithEvents tbNroRetG As System.Windows.Forms.TextBox
   Friend WithEvents Label15 As System.Windows.Forms.Label
   Friend WithEvents tbRetGan As System.Windows.Forms.TextBox
   Friend WithEvents cmdGenerar As System.Windows.Forms.Button
   Friend WithEvents cmdPendiente As System.Windows.Forms.Button
   Friend WithEvents cmdCancelar As System.Windows.Forms.Button
   Friend WithEvents cmdSalir As System.Windows.Forms.Button
   Friend WithEvents Label18 As System.Windows.Forms.Label
   Friend WithEvents tbRecibo As System.Windows.Forms.TextBox
   Friend WithEvents gbPago As System.Windows.Forms.GroupBox
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents txtTransferencia As System.Windows.Forms.TextBox
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents tbCheques As System.Windows.Forms.TextBox
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents cmdIngCheques As System.Windows.Forms.Button
   Friend WithEvents cmdTransferencia As System.Windows.Forms.Button
   Friend WithEvents tbEfectivo As System.Windows.Forms.TextBox
   Friend WithEvents tbDetalle As System.Windows.Forms.TextBox
   Friend WithEvents Label19 As System.Windows.Forms.Label
   Friend WithEvents Label20 As System.Windows.Forms.Label
   Friend WithEvents tbAlquiler As System.Windows.Forms.TextBox
   Friend WithEvents Label21 As System.Windows.Forms.Label
   Friend WithEvents tbRetInq As System.Windows.Forms.TextBox
   Friend WithEvents Label22 As System.Windows.Forms.Label
   Friend WithEvents tbGtosBanc As System.Windows.Forms.TextBox
   Friend WithEvents Label23 As System.Windows.Forms.Label
   Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
   Friend WithEvents tTotal As System.Windows.Forms.TextBox
End Class
