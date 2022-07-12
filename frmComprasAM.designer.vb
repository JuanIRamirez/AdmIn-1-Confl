<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmComprasAM
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
      Me.chkCasual = New System.Windows.Forms.CheckBox()
      Me.Label18 = New System.Windows.Forms.Label()
      Me.cboEmpresa = New System.Windows.Forms.ComboBox()
      Me.tbFecha = New System.Windows.Forms.DateTimePicker()
      Me.Label10 = New System.Windows.Forms.Label()
      Me.tbFecVenc = New System.Windows.Forms.DateTimePicker()
      Me.Label11 = New System.Windows.Forms.Label()
      Me.tbPerIVA = New System.Windows.Forms.DateTimePicker()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.ssTab1 = New System.Windows.Forms.TabControl()
      Me.TabPage1 = New System.Windows.Forms.TabPage()
      Me.Label29 = New System.Windows.Forms.Label()
      Me.cmdAltaServ = New System.Windows.Forms.Button()
      Me.Label16 = New System.Windows.Forms.Label()
      Me.txtGravado2 = New System.Windows.Forms.TextBox()
      Me.cmdRefRemito = New System.Windows.Forms.Button()
      Me.cmdEdicion = New System.Windows.Forms.Button()
      Me.cmdBaja = New System.Windows.Forms.Button()
      Me.cmdAltaProd = New System.Windows.Forms.Button()
      Me.cmdSiguiente = New System.Windows.Forms.Button()
      Me.cmdGuardar = New System.Windows.Forms.Button()
      Me.cmdCancelar = New System.Windows.Forms.Button()
      Me.cboPedidoPr = New System.Windows.Forms.ComboBox()
      Me.Label25 = New System.Windows.Forms.Label()
      Me.cboAlicIVA = New System.Windows.Forms.ComboBox()
      Me.Label24 = New System.Windows.Forms.Label()
      Me.optCtaCte = New System.Windows.Forms.RadioButton()
      Me.optContado = New System.Windows.Forms.RadioButton()
      Me.Label23 = New System.Windows.Forms.Label()
      Me.tbDetalle = New System.Windows.Forms.TextBox()
      Me.Label22 = New System.Windows.Forms.Label()
      Me.txtTotal = New System.Windows.Forms.TextBox()
      Me.cmdNuevoProv = New System.Windows.Forms.Button()
      Me.cmdAceptar = New System.Windows.Forms.Button()
      Me.cmdSalir = New System.Windows.Forms.Button()
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.Label21 = New System.Windows.Forms.Label()
      Me.txtRetGan = New System.Windows.Forms.TextBox()
      Me.Label20 = New System.Windows.Forms.Label()
      Me.txtRetIB = New System.Windows.Forms.TextBox()
      Me.Label19 = New System.Windows.Forms.Label()
      Me.txtRetIva = New System.Windows.Forms.TextBox()
      Me.lblIva2 = New System.Windows.Forms.Label()
      Me.tbIVA2 = New System.Windows.Forms.TextBox()
      Me.lblIva1 = New System.Windows.Forms.Label()
      Me.tbIVA1 = New System.Windows.Forms.TextBox()
      Me.Label15 = New System.Windows.Forms.Label()
      Me.tbExento = New System.Windows.Forms.TextBox()
      Me.Label14 = New System.Windows.Forms.Label()
      Me.tbCompraRNI = New System.Windows.Forms.TextBox()
      Me.Label13 = New System.Windows.Forms.Label()
      Me.tbNoGravado = New System.Windows.Forms.TextBox()
      Me.Label12 = New System.Windows.Forms.Label()
      Me.Label7 = New System.Windows.Forms.Label()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.tbGravado = New System.Windows.Forms.TextBox()
      Me.txtDescuento = New System.Windows.Forms.TextBox()
      Me.tbSubtotal = New System.Windows.Forms.TextBox()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.cboTipoIva = New System.Windows.Forms.ComboBox()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.cboLetra = New System.Windows.Forms.ComboBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.cboTipoComp = New System.Windows.Forms.ComboBox()
      Me.Label9 = New System.Windows.Forms.Label()
      Me.tbNumero = New System.Windows.Forms.TextBox()
      Me.tbSucursal = New System.Windows.Forms.TextBox()
      Me.txtCuit = New System.Windows.Forms.MaskedTextBox()
      Me.Label8 = New System.Windows.Forms.Label()
      Me.cboProveedor = New System.Windows.Forms.ComboBox()
      Me.DataGridView1 = New System.Windows.Forms.DataGridView()
      Me.TabPage2 = New System.Windows.Forms.TabPage()
      Me.btnCheques = New System.Windows.Forms.Button()
      Me.Label17 = New System.Windows.Forms.Label()
      Me.txtTotalPago = New System.Windows.Forms.TextBox()
      Me.cmdAnterior = New System.Windows.Forms.Button()
      Me.cmdGuardar2 = New System.Windows.Forms.Button()
      Me.cmdCancelar2 = New System.Windows.Forms.Button()
      Me.txtCheques = New System.Windows.Forms.TextBox()
      Me.Label27 = New System.Windows.Forms.Label()
      Me.txtEfectivo = New System.Windows.Forms.TextBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.txtDetPago = New System.Windows.Forms.TextBox()
      Me.ssTab1.SuspendLayout()
      Me.TabPage1.SuspendLayout()
      Me.Panel1.SuspendLayout()
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.TabPage2.SuspendLayout()
      Me.SuspendLayout()
      '
      'chkCasual
      '
      Me.chkCasual.AutoSize = True
      Me.chkCasual.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.chkCasual.Location = New System.Drawing.Point(11, 8)
      Me.chkCasual.Name = "chkCasual"
      Me.chkCasual.Size = New System.Drawing.Size(116, 17)
      Me.chkCasual.TabIndex = 34
      Me.chkCasual.Text = "Proveedor (Casual)"
      Me.chkCasual.UseVisualStyleBackColor = True
      '
      'Label18
      '
      Me.Label18.AutoSize = True
      Me.Label18.Location = New System.Drawing.Point(12, 15)
      Me.Label18.Name = "Label18"
      Me.Label18.Size = New System.Drawing.Size(51, 13)
      Me.Label18.TabIndex = 36
      Me.Label18.Text = "Empresa:"
      '
      'cboEmpresa
      '
      Me.cboEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboEmpresa.FormattingEnabled = True
      Me.cboEmpresa.Location = New System.Drawing.Point(70, 12)
      Me.cboEmpresa.Name = "cboEmpresa"
      Me.cboEmpresa.Size = New System.Drawing.Size(266, 21)
      Me.cboEmpresa.TabIndex = 35
      '
      'tbFecha
      '
      Me.tbFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.tbFecha.Location = New System.Drawing.Point(54, 82)
      Me.tbFecha.Name = "tbFecha"
      Me.tbFecha.Size = New System.Drawing.Size(89, 20)
      Me.tbFecha.TabIndex = 38
      '
      'Label10
      '
      Me.Label10.AutoSize = True
      Me.Label10.Location = New System.Drawing.Point(8, 86)
      Me.Label10.Name = "Label10"
      Me.Label10.Size = New System.Drawing.Size(40, 13)
      Me.Label10.TabIndex = 37
      Me.Label10.Text = "Fecha:"
      '
      'tbFecVenc
      '
      Me.tbFecVenc.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.tbFecVenc.Location = New System.Drawing.Point(681, 82)
      Me.tbFecVenc.Name = "tbFecVenc"
      Me.tbFecVenc.Size = New System.Drawing.Size(89, 20)
      Me.tbFecVenc.TabIndex = 40
      '
      'Label11
      '
      Me.Label11.AutoSize = True
      Me.Label11.Location = New System.Drawing.Point(629, 86)
      Me.Label11.Name = "Label11"
      Me.Label11.Size = New System.Drawing.Size(38, 13)
      Me.Label11.TabIndex = 39
      Me.Label11.Text = "Venc.:"
      '
      'tbPerIVA
      '
      Me.tbPerIVA.CustomFormat = "MM/yyyy"
      Me.tbPerIVA.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.tbPerIVA.Location = New System.Drawing.Point(208, 82)
      Me.tbPerIVA.Name = "tbPerIVA"
      Me.tbPerIVA.Size = New System.Drawing.Size(79, 20)
      Me.tbPerIVA.TabIndex = 42
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(153, 86)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(49, 13)
      Me.Label1.TabIndex = 41
      Me.Label1.Text = "Per.IVA.:"
      '
      'ssTab1
      '
      Me.ssTab1.Controls.Add(Me.TabPage1)
      Me.ssTab1.Controls.Add(Me.TabPage2)
      Me.ssTab1.Location = New System.Drawing.Point(12, 39)
      Me.ssTab1.Name = "ssTab1"
      Me.ssTab1.SelectedIndex = 0
      Me.ssTab1.Size = New System.Drawing.Size(792, 531)
      Me.ssTab1.TabIndex = 43
      '
      'TabPage1
      '
      Me.TabPage1.BackColor = System.Drawing.SystemColors.Control
      Me.TabPage1.Controls.Add(Me.Label29)
      Me.TabPage1.Controls.Add(Me.cmdAltaServ)
      Me.TabPage1.Controls.Add(Me.Label16)
      Me.TabPage1.Controls.Add(Me.txtGravado2)
      Me.TabPage1.Controls.Add(Me.cmdRefRemito)
      Me.TabPage1.Controls.Add(Me.cmdEdicion)
      Me.TabPage1.Controls.Add(Me.cmdBaja)
      Me.TabPage1.Controls.Add(Me.cmdAltaProd)
      Me.TabPage1.Controls.Add(Me.cmdSiguiente)
      Me.TabPage1.Controls.Add(Me.cmdGuardar)
      Me.TabPage1.Controls.Add(Me.cmdCancelar)
      Me.TabPage1.Controls.Add(Me.cboPedidoPr)
      Me.TabPage1.Controls.Add(Me.Label25)
      Me.TabPage1.Controls.Add(Me.cboAlicIVA)
      Me.TabPage1.Controls.Add(Me.Label24)
      Me.TabPage1.Controls.Add(Me.optCtaCte)
      Me.TabPage1.Controls.Add(Me.optContado)
      Me.TabPage1.Controls.Add(Me.Label23)
      Me.TabPage1.Controls.Add(Me.tbDetalle)
      Me.TabPage1.Controls.Add(Me.Label22)
      Me.TabPage1.Controls.Add(Me.txtTotal)
      Me.TabPage1.Controls.Add(Me.cmdNuevoProv)
      Me.TabPage1.Controls.Add(Me.cmdAceptar)
      Me.TabPage1.Controls.Add(Me.cmdSalir)
      Me.TabPage1.Controls.Add(Me.Panel1)
      Me.TabPage1.Controls.Add(Me.lblIva2)
      Me.TabPage1.Controls.Add(Me.tbIVA2)
      Me.TabPage1.Controls.Add(Me.lblIva1)
      Me.TabPage1.Controls.Add(Me.tbIVA1)
      Me.TabPage1.Controls.Add(Me.Label15)
      Me.TabPage1.Controls.Add(Me.tbExento)
      Me.TabPage1.Controls.Add(Me.Label14)
      Me.TabPage1.Controls.Add(Me.tbCompraRNI)
      Me.TabPage1.Controls.Add(Me.Label13)
      Me.TabPage1.Controls.Add(Me.tbNoGravado)
      Me.TabPage1.Controls.Add(Me.Label12)
      Me.TabPage1.Controls.Add(Me.Label7)
      Me.TabPage1.Controls.Add(Me.Label6)
      Me.TabPage1.Controls.Add(Me.tbGravado)
      Me.TabPage1.Controls.Add(Me.txtDescuento)
      Me.TabPage1.Controls.Add(Me.tbSubtotal)
      Me.TabPage1.Controls.Add(Me.Label5)
      Me.TabPage1.Controls.Add(Me.cboTipoIva)
      Me.TabPage1.Controls.Add(Me.Label4)
      Me.TabPage1.Controls.Add(Me.cboLetra)
      Me.TabPage1.Controls.Add(Me.Label3)
      Me.TabPage1.Controls.Add(Me.cboTipoComp)
      Me.TabPage1.Controls.Add(Me.Label9)
      Me.TabPage1.Controls.Add(Me.tbNumero)
      Me.TabPage1.Controls.Add(Me.tbSucursal)
      Me.TabPage1.Controls.Add(Me.txtCuit)
      Me.TabPage1.Controls.Add(Me.Label8)
      Me.TabPage1.Controls.Add(Me.cboProveedor)
      Me.TabPage1.Controls.Add(Me.DataGridView1)
      Me.TabPage1.Controls.Add(Me.tbFecVenc)
      Me.TabPage1.Controls.Add(Me.Label11)
      Me.TabPage1.Controls.Add(Me.tbPerIVA)
      Me.TabPage1.Controls.Add(Me.Label1)
      Me.TabPage1.Controls.Add(Me.chkCasual)
      Me.TabPage1.Controls.Add(Me.Label10)
      Me.TabPage1.Controls.Add(Me.tbFecha)
      Me.TabPage1.Location = New System.Drawing.Point(4, 22)
      Me.TabPage1.Name = "TabPage1"
      Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
      Me.TabPage1.Size = New System.Drawing.Size(784, 505)
      Me.TabPage1.TabIndex = 0
      Me.TabPage1.Text = "Compra"
      '
      'Label29
      '
      Me.Label29.AutoSize = True
      Me.Label29.Location = New System.Drawing.Point(300, 391)
      Me.Label29.Name = "Label29"
      Me.Label29.Size = New System.Drawing.Size(68, 13)
      Me.Label29.TabIndex = 98
      Me.Label29.Text = "Pedido Prov."
      '
      'cmdAltaServ
      '
      Me.cmdAltaServ.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdAltaServ.Enabled = False
      Me.cmdAltaServ.Location = New System.Drawing.Point(92, 337)
      Me.cmdAltaServ.Name = "cmdAltaServ"
      Me.cmdAltaServ.Size = New System.Drawing.Size(75, 41)
      Me.cmdAltaServ.TabIndex = 97
      Me.cmdAltaServ.Text = "&Agregar Serv."
      Me.cmdAltaServ.UseVisualStyleBackColor = True
      '
      'Label16
      '
      Me.Label16.AutoSize = True
      Me.Label16.Location = New System.Drawing.Point(492, 391)
      Me.Label16.Name = "Label16"
      Me.Label16.Size = New System.Drawing.Size(57, 13)
      Me.Label16.TabIndex = 96
      Me.Label16.Text = "Gravado $"
      '
      'txtGravado2
      '
      Me.txtGravado2.Enabled = False
      Me.txtGravado2.Location = New System.Drawing.Point(555, 388)
      Me.txtGravado2.Name = "txtGravado2"
      Me.txtGravado2.Size = New System.Drawing.Size(67, 20)
      Me.txtGravado2.TabIndex = 95
      Me.txtGravado2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'cmdRefRemito
      '
      Me.cmdRefRemito.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdRefRemito.Enabled = False
      Me.cmdRefRemito.Location = New System.Drawing.Point(374, 346)
      Me.cmdRefRemito.Name = "cmdRefRemito"
      Me.cmdRefRemito.Size = New System.Drawing.Size(75, 23)
      Me.cmdRefRemito.TabIndex = 94
      Me.cmdRefRemito.Text = "&Ref.Remito"
      Me.cmdRefRemito.UseVisualStyleBackColor = True
      '
      'cmdEdicion
      '
      Me.cmdEdicion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdEdicion.Enabled = False
      Me.cmdEdicion.Location = New System.Drawing.Point(254, 346)
      Me.cmdEdicion.Name = "cmdEdicion"
      Me.cmdEdicion.Size = New System.Drawing.Size(75, 23)
      Me.cmdEdicion.TabIndex = 93
      Me.cmdEdicion.Text = "&Modif."
      Me.cmdEdicion.UseVisualStyleBackColor = True
      '
      'cmdBaja
      '
      Me.cmdBaja.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdBaja.Enabled = False
      Me.cmdBaja.Location = New System.Drawing.Point(173, 346)
      Me.cmdBaja.Name = "cmdBaja"
      Me.cmdBaja.Size = New System.Drawing.Size(75, 23)
      Me.cmdBaja.TabIndex = 92
      Me.cmdBaja.Text = "&Quitar"
      Me.cmdBaja.UseVisualStyleBackColor = True
      '
      'cmdAltaProd
      '
      Me.cmdAltaProd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdAltaProd.Enabled = False
      Me.cmdAltaProd.Location = New System.Drawing.Point(11, 337)
      Me.cmdAltaProd.Name = "cmdAltaProd"
      Me.cmdAltaProd.Size = New System.Drawing.Size(75, 41)
      Me.cmdAltaProd.TabIndex = 91
      Me.cmdAltaProd.Text = "&Agregar Prod."
      Me.cmdAltaProd.UseVisualStyleBackColor = True
      '
      'cmdSiguiente
      '
      Me.cmdSiguiente.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdSiguiente.Enabled = False
      Me.cmdSiguiente.Location = New System.Drawing.Point(541, 476)
      Me.cmdSiguiente.Name = "cmdSiguiente"
      Me.cmdSiguiente.Size = New System.Drawing.Size(75, 23)
      Me.cmdSiguiente.TabIndex = 90
      Me.cmdSiguiente.Text = "&Siguiente >>"
      Me.cmdSiguiente.UseVisualStyleBackColor = True
      '
      'cmdGuardar
      '
      Me.cmdGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdGuardar.Enabled = False
      Me.cmdGuardar.Location = New System.Drawing.Point(622, 476)
      Me.cmdGuardar.Name = "cmdGuardar"
      Me.cmdGuardar.Size = New System.Drawing.Size(75, 23)
      Me.cmdGuardar.TabIndex = 89
      Me.cmdGuardar.Text = "&Guardar"
      Me.cmdGuardar.UseVisualStyleBackColor = True
      '
      'cmdCancelar
      '
      Me.cmdCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdCancelar.Enabled = False
      Me.cmdCancelar.Location = New System.Drawing.Point(703, 476)
      Me.cmdCancelar.Name = "cmdCancelar"
      Me.cmdCancelar.Size = New System.Drawing.Size(75, 23)
      Me.cmdCancelar.TabIndex = 88
      Me.cmdCancelar.Text = "&Cancelar"
      Me.cmdCancelar.UseVisualStyleBackColor = True
      '
      'cboPedidoPr
      '
      Me.cboPedidoPr.FormattingEnabled = True
      Me.cboPedidoPr.Location = New System.Drawing.Point(376, 388)
      Me.cboPedidoPr.Name = "cboPedidoPr"
      Me.cboPedidoPr.Size = New System.Drawing.Size(102, 21)
      Me.cboPedidoPr.TabIndex = 87
      '
      'Label25
      '
      Me.Label25.AutoSize = True
      Me.Label25.Location = New System.Drawing.Point(531, 60)
      Me.Label25.Name = "Label25"
      Me.Label25.Size = New System.Drawing.Size(70, 13)
      Me.Label25.TabIndex = 84
      Me.Label25.Text = "Alícuota IVA:"
      '
      'cboAlicIVA
      '
      Me.cboAlicIVA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboAlicIVA.FormattingEnabled = True
      Me.cboAlicIVA.Location = New System.Drawing.Point(608, 56)
      Me.cboAlicIVA.Name = "cboAlicIVA"
      Me.cboAlicIVA.Size = New System.Drawing.Size(104, 21)
      Me.cboAlicIVA.TabIndex = 85
      '
      'Label24
      '
      Me.Label24.AutoSize = True
      Me.Label24.Location = New System.Drawing.Point(344, 87)
      Me.Label24.Name = "Label24"
      Me.Label24.Size = New System.Drawing.Size(63, 13)
      Me.Label24.TabIndex = 83
      Me.Label24.Text = "Cond.Venta"
      '
      'optCtaCte
      '
      Me.optCtaCte.AutoSize = True
      Me.optCtaCte.Location = New System.Drawing.Point(486, 86)
      Me.optCtaCte.Name = "optCtaCte"
      Me.optCtaCte.Size = New System.Drawing.Size(63, 17)
      Me.optCtaCte.TabIndex = 82
      Me.optCtaCte.Text = "Cta.Cte."
      Me.optCtaCte.UseVisualStyleBackColor = True
      '
      'optContado
      '
      Me.optContado.AutoSize = True
      Me.optContado.Checked = True
      Me.optContado.Location = New System.Drawing.Point(413, 85)
      Me.optContado.Name = "optContado"
      Me.optContado.Size = New System.Drawing.Size(65, 17)
      Me.optContado.TabIndex = 81
      Me.optContado.TabStop = True
      Me.optContado.Text = "Contado"
      Me.optContado.UseVisualStyleBackColor = True
      '
      'Label23
      '
      Me.Label23.AutoSize = True
      Me.Label23.Location = New System.Drawing.Point(8, 439)
      Me.Label23.Name = "Label23"
      Me.Label23.Size = New System.Drawing.Size(43, 13)
      Me.Label23.TabIndex = 80
      Me.Label23.Text = "Detalle:"
      '
      'tbDetalle
      '
      Me.tbDetalle.Location = New System.Drawing.Point(57, 436)
      Me.tbDetalle.Multiline = True
      Me.tbDetalle.Name = "tbDetalle"
      Me.tbDetalle.Size = New System.Drawing.Size(421, 63)
      Me.tbDetalle.TabIndex = 79
      '
      'Label22
      '
      Me.Label22.AutoSize = True
      Me.Label22.Location = New System.Drawing.Point(632, 438)
      Me.Label22.Name = "Label22"
      Me.Label22.Size = New System.Drawing.Size(40, 13)
      Me.Label22.TabIndex = 78
      Me.Label22.Text = "Total $"
      '
      'txtTotal
      '
      Me.txtTotal.Enabled = False
      Me.txtTotal.Location = New System.Drawing.Point(678, 435)
      Me.txtTotal.Name = "txtTotal"
      Me.txtTotal.Size = New System.Drawing.Size(97, 20)
      Me.txtTotal.TabIndex = 77
      Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'cmdNuevoProv
      '
      Me.cmdNuevoProv.Location = New System.Drawing.Point(396, 27)
      Me.cmdNuevoProv.Name = "cmdNuevoProv"
      Me.cmdNuevoProv.Size = New System.Drawing.Size(25, 23)
      Me.cmdNuevoProv.TabIndex = 76
      Me.cmdNuevoProv.Text = "..."
      Me.cmdNuevoProv.UseVisualStyleBackColor = True
      '
      'cmdAceptar
      '
      Me.cmdAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdAceptar.Location = New System.Drawing.Point(644, 26)
      Me.cmdAceptar.Name = "cmdAceptar"
      Me.cmdAceptar.Size = New System.Drawing.Size(68, 23)
      Me.cmdAceptar.TabIndex = 75
      Me.cmdAceptar.Text = "&Aceptar"
      Me.cmdAceptar.UseVisualStyleBackColor = True
      '
      'cmdSalir
      '
      Me.cmdSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.cmdSalir.Location = New System.Drawing.Point(715, 26)
      Me.cmdSalir.Name = "cmdSalir"
      Me.cmdSalir.Size = New System.Drawing.Size(60, 23)
      Me.cmdSalir.TabIndex = 74
      Me.cmdSalir.Text = "&Salir"
      Me.cmdSalir.UseVisualStyleBackColor = True
      '
      'Panel1
      '
      Me.Panel1.Controls.Add(Me.Label21)
      Me.Panel1.Controls.Add(Me.txtRetGan)
      Me.Panel1.Controls.Add(Me.Label20)
      Me.Panel1.Controls.Add(Me.txtRetIB)
      Me.Panel1.Controls.Add(Me.Label19)
      Me.Panel1.Controls.Add(Me.txtRetIva)
      Me.Panel1.Location = New System.Drawing.Point(11, 387)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(248, 43)
      Me.Panel1.TabIndex = 73
      '
      'Label21
      '
      Me.Label21.AutoSize = True
      Me.Label21.Location = New System.Drawing.Point(194, 4)
      Me.Label21.Name = "Label21"
      Me.Label21.Size = New System.Drawing.Size(43, 13)
      Me.Label21.TabIndex = 76
      Me.Label21.Text = "Gcias.$"
      '
      'txtRetGan
      '
      Me.txtRetGan.Location = New System.Drawing.Point(171, 19)
      Me.txtRetGan.Name = "txtRetGan"
      Me.txtRetGan.Size = New System.Drawing.Size(66, 20)
      Me.txtRetGan.TabIndex = 75
      '
      'Label20
      '
      Me.Label20.AutoSize = True
      Me.Label20.Location = New System.Drawing.Point(136, 4)
      Me.Label20.Name = "Label20"
      Me.Label20.Size = New System.Drawing.Size(29, 13)
      Me.Label20.TabIndex = 74
      Me.Label20.Text = "I.B.$"
      '
      'txtRetIB
      '
      Me.txtRetIB.Location = New System.Drawing.Point(98, 19)
      Me.txtRetIB.Name = "txtRetIB"
      Me.txtRetIB.Size = New System.Drawing.Size(67, 20)
      Me.txtRetIB.TabIndex = 73
      '
      'Label19
      '
      Me.Label19.AutoSize = True
      Me.Label19.Location = New System.Drawing.Point(7, 4)
      Me.Label19.Name = "Label19"
      Me.Label19.Size = New System.Drawing.Size(85, 13)
      Me.Label19.TabIndex = 72
      Me.Label19.Text = "Retención IVA $"
      '
      'txtRetIva
      '
      Me.txtRetIva.Location = New System.Drawing.Point(25, 19)
      Me.txtRetIva.Name = "txtRetIva"
      Me.txtRetIva.Size = New System.Drawing.Size(67, 20)
      Me.txtRetIva.TabIndex = 71
      '
      'lblIva2
      '
      Me.lblIva2.AutoSize = True
      Me.lblIva2.Location = New System.Drawing.Point(648, 391)
      Me.lblIva2.Name = "lblIva2"
      Me.lblIva2.Size = New System.Drawing.Size(56, 13)
      Me.lblIva2.TabIndex = 70
      Me.lblIva2.Text = "IVA 27% $"
      '
      'tbIVA2
      '
      Me.tbIVA2.Enabled = False
      Me.tbIVA2.Location = New System.Drawing.Point(708, 388)
      Me.tbIVA2.Name = "tbIVA2"
      Me.tbIVA2.Size = New System.Drawing.Size(67, 20)
      Me.tbIVA2.TabIndex = 69
      Me.tbIVA2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblIva1
      '
      Me.lblIva1.AutoSize = True
      Me.lblIva1.Location = New System.Drawing.Point(648, 368)
      Me.lblIva1.Name = "lblIva1"
      Me.lblIva1.Size = New System.Drawing.Size(56, 13)
      Me.lblIva1.TabIndex = 68
      Me.lblIva1.Text = "IVA 21% $"
      '
      'tbIVA1
      '
      Me.tbIVA1.Enabled = False
      Me.tbIVA1.Location = New System.Drawing.Point(708, 365)
      Me.tbIVA1.Name = "tbIVA1"
      Me.tbIVA1.Size = New System.Drawing.Size(67, 20)
      Me.tbIVA1.TabIndex = 67
      Me.tbIVA1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label15
      '
      Me.Label15.AutoSize = True
      Me.Label15.Location = New System.Drawing.Point(500, 438)
      Me.Label15.Name = "Label15"
      Me.Label15.Size = New System.Drawing.Size(49, 13)
      Me.Label15.TabIndex = 66
      Me.Label15.Text = "Exento $"
      '
      'tbExento
      '
      Me.tbExento.Enabled = False
      Me.tbExento.Location = New System.Drawing.Point(555, 435)
      Me.tbExento.Name = "tbExento"
      Me.tbExento.Size = New System.Drawing.Size(67, 20)
      Me.tbExento.TabIndex = 65
      Me.tbExento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label14
      '
      Me.Label14.AutoSize = True
      Me.Label14.Location = New System.Drawing.Point(475, 414)
      Me.Label14.Name = "Label14"
      Me.Label14.Size = New System.Drawing.Size(74, 13)
      Me.Label14.TabIndex = 64
      Me.Label14.Text = "Compra RNI $"
      '
      'tbCompraRNI
      '
      Me.tbCompraRNI.Enabled = False
      Me.tbCompraRNI.Location = New System.Drawing.Point(555, 411)
      Me.tbCompraRNI.Name = "tbCompraRNI"
      Me.tbCompraRNI.Size = New System.Drawing.Size(67, 20)
      Me.tbCompraRNI.TabIndex = 63
      Me.tbCompraRNI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label13
      '
      Me.Label13.AutoSize = True
      Me.Label13.Location = New System.Drawing.Point(632, 414)
      Me.Label13.Name = "Label13"
      Me.Label13.Size = New System.Drawing.Size(72, 13)
      Me.Label13.TabIndex = 62
      Me.Label13.Text = "No gravado $"
      '
      'tbNoGravado
      '
      Me.tbNoGravado.Enabled = False
      Me.tbNoGravado.Location = New System.Drawing.Point(708, 411)
      Me.tbNoGravado.Name = "tbNoGravado"
      Me.tbNoGravado.Size = New System.Drawing.Size(67, 20)
      Me.tbNoGravado.TabIndex = 61
      Me.tbNoGravado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label12
      '
      Me.Label12.AutoSize = True
      Me.Label12.Location = New System.Drawing.Point(492, 368)
      Me.Label12.Name = "Label12"
      Me.Label12.Size = New System.Drawing.Size(57, 13)
      Me.Label12.TabIndex = 60
      Me.Label12.Text = "Gravado $"
      '
      'Label7
      '
      Me.Label7.AutoSize = True
      Me.Label7.Location = New System.Drawing.Point(494, 345)
      Me.Label7.Name = "Label7"
      Me.Label7.Size = New System.Drawing.Size(55, 13)
      Me.Label7.TabIndex = 59
      Me.Label7.Text = "Subtotal $"
      '
      'Label6
      '
      Me.Label6.AutoSize = True
      Me.Label6.Location = New System.Drawing.Point(659, 345)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(70, 13)
      Me.Label6.TabIndex = 58
      Me.Label6.Text = "Descuento %"
      '
      'tbGravado
      '
      Me.tbGravado.Enabled = False
      Me.tbGravado.Location = New System.Drawing.Point(555, 365)
      Me.tbGravado.Name = "tbGravado"
      Me.tbGravado.Size = New System.Drawing.Size(67, 20)
      Me.tbGravado.TabIndex = 57
      Me.tbGravado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtDescuento
      '
      Me.txtDescuento.Enabled = False
      Me.txtDescuento.Location = New System.Drawing.Point(735, 342)
      Me.txtDescuento.Name = "txtDescuento"
      Me.txtDescuento.Size = New System.Drawing.Size(40, 20)
      Me.txtDescuento.TabIndex = 56
      '
      'tbSubtotal
      '
      Me.tbSubtotal.Enabled = False
      Me.tbSubtotal.Location = New System.Drawing.Point(555, 342)
      Me.tbSubtotal.Name = "tbSubtotal"
      Me.tbSubtotal.Size = New System.Drawing.Size(67, 20)
      Me.tbSubtotal.TabIndex = 55
      Me.tbSubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.Location = New System.Drawing.Point(8, 59)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(51, 13)
      Me.Label5.TabIndex = 53
      Me.Label5.Text = "Tipo IVA:"
      '
      'cboTipoIva
      '
      Me.cboTipoIva.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cboTipoIva.FormattingEnabled = True
      Me.cboTipoIva.Location = New System.Drawing.Point(65, 56)
      Me.cboTipoIva.Name = "cboTipoIva"
      Me.cboTipoIva.Size = New System.Drawing.Size(110, 21)
      Me.cboTipoIva.TabIndex = 54
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(373, 59)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(34, 13)
      Me.Label4.TabIndex = 51
      Me.Label4.Text = "Letra:"
      '
      'cboLetra
      '
      Me.cboLetra.FormattingEnabled = True
      Me.cboLetra.Location = New System.Drawing.Point(413, 55)
      Me.cboLetra.Name = "cboLetra"
      Me.cboLetra.Size = New System.Drawing.Size(36, 21)
      Me.cboLetra.TabIndex = 52
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(429, 8)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(32, 13)
      Me.Label3.TabIndex = 50
      Me.Label3.Text = "Cpte:"
      '
      'cboTipoComp
      '
      Me.cboTipoComp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboTipoComp.FormattingEnabled = True
      Me.cboTipoComp.Location = New System.Drawing.Point(432, 28)
      Me.cboTipoComp.Name = "cboTipoComp"
      Me.cboTipoComp.Size = New System.Drawing.Size(92, 21)
      Me.cboTipoComp.TabIndex = 49
      '
      'Label9
      '
      Me.Label9.AutoSize = True
      Me.Label9.Location = New System.Drawing.Point(527, 12)
      Me.Label9.Name = "Label9"
      Me.Label9.Size = New System.Drawing.Size(69, 13)
      Me.Label9.TabIndex = 48
      Me.Label9.Text = "Suc-Número:"
      '
      'tbNumero
      '
      Me.tbNumero.Location = New System.Drawing.Point(571, 28)
      Me.tbNumero.MaxLength = 10
      Me.tbNumero.Name = "tbNumero"
      Me.tbNumero.Size = New System.Drawing.Size(67, 20)
      Me.tbNumero.TabIndex = 47
      '
      'tbSucursal
      '
      Me.tbSucursal.Location = New System.Drawing.Point(530, 28)
      Me.tbSucursal.MaxLength = 4
      Me.tbSucursal.Name = "tbSucursal"
      Me.tbSucursal.Size = New System.Drawing.Size(35, 20)
      Me.tbSucursal.TabIndex = 46
      '
      'txtCuit
      '
      Me.txtCuit.Location = New System.Drawing.Point(246, 56)
      Me.txtCuit.Mask = "00-00000000-0"
      Me.txtCuit.Name = "txtCuit"
      Me.txtCuit.Size = New System.Drawing.Size(100, 20)
      Me.txtCuit.TabIndex = 45
      '
      'Label8
      '
      Me.Label8.AutoSize = True
      Me.Label8.Location = New System.Drawing.Point(205, 59)
      Me.Label8.Name = "Label8"
      Me.Label8.Size = New System.Drawing.Size(35, 13)
      Me.Label8.TabIndex = 44
      Me.Label8.Text = "CUIT:"
      '
      'cboProveedor
      '
      Me.cboProveedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      Me.cboProveedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.cboProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboProveedor.FormattingEnabled = True
      Me.cboProveedor.Location = New System.Drawing.Point(11, 28)
      Me.cboProveedor.Name = "cboProveedor"
      Me.cboProveedor.Size = New System.Drawing.Size(379, 21)
      Me.cboProveedor.TabIndex = 43
      '
      'DataGridView1
      '
      Me.DataGridView1.AllowUserToAddRows = False
      Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
      Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.DataGridView1.Location = New System.Drawing.Point(11, 108)
      Me.DataGridView1.Name = "DataGridView1"
      Me.DataGridView1.ReadOnly = True
      Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.DataGridView1.Size = New System.Drawing.Size(764, 221)
      Me.DataGridView1.TabIndex = 34
      '
      'TabPage2
      '
      Me.TabPage2.BackColor = System.Drawing.SystemColors.Control
      Me.TabPage2.Controls.Add(Me.btnCheques)
      Me.TabPage2.Controls.Add(Me.Label17)
      Me.TabPage2.Controls.Add(Me.txtTotalPago)
      Me.TabPage2.Controls.Add(Me.cmdAnterior)
      Me.TabPage2.Controls.Add(Me.cmdGuardar2)
      Me.TabPage2.Controls.Add(Me.cmdCancelar2)
      Me.TabPage2.Controls.Add(Me.txtCheques)
      Me.TabPage2.Controls.Add(Me.Label27)
      Me.TabPage2.Controls.Add(Me.txtEfectivo)
      Me.TabPage2.Controls.Add(Me.Label2)
      Me.TabPage2.Controls.Add(Me.txtDetPago)
      Me.TabPage2.Location = New System.Drawing.Point(4, 22)
      Me.TabPage2.Name = "TabPage2"
      Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
      Me.TabPage2.Size = New System.Drawing.Size(784, 505)
      Me.TabPage2.TabIndex = 1
      Me.TabPage2.Text = "Pago"
      '
      'btnCheques
      '
      Me.btnCheques.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btnCheques.Enabled = False
      Me.btnCheques.Location = New System.Drawing.Point(43, 110)
      Me.btnCheques.Name = "btnCheques"
      Me.btnCheques.Size = New System.Drawing.Size(69, 23)
      Me.btnCheques.TabIndex = 94
      Me.btnCheques.Text = "&Cheques $"
      Me.btnCheques.UseVisualStyleBackColor = True
      '
      'Label17
      '
      Me.Label17.AutoSize = True
      Me.Label17.Location = New System.Drawing.Point(72, 164)
      Me.Label17.Name = "Label17"
      Me.Label17.Size = New System.Drawing.Size(40, 13)
      Me.Label17.TabIndex = 87
      Me.Label17.Text = "Total $"
      '
      'txtTotalPago
      '
      Me.txtTotalPago.BackColor = System.Drawing.Color.LightYellow
      Me.txtTotalPago.Enabled = False
      Me.txtTotalPago.Location = New System.Drawing.Point(118, 161)
      Me.txtTotalPago.Name = "txtTotalPago"
      Me.txtTotalPago.Size = New System.Drawing.Size(82, 20)
      Me.txtTotalPago.TabIndex = 86
      '
      'cmdAnterior
      '
      Me.cmdAnterior.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdAnterior.Location = New System.Drawing.Point(541, 453)
      Me.cmdAnterior.Name = "cmdAnterior"
      Me.cmdAnterior.Size = New System.Drawing.Size(75, 23)
      Me.cmdAnterior.TabIndex = 85
      Me.cmdAnterior.Text = "<< &Anterior"
      Me.cmdAnterior.UseVisualStyleBackColor = True
      '
      'cmdGuardar2
      '
      Me.cmdGuardar2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdGuardar2.Location = New System.Drawing.Point(622, 453)
      Me.cmdGuardar2.Name = "cmdGuardar2"
      Me.cmdGuardar2.Size = New System.Drawing.Size(75, 23)
      Me.cmdGuardar2.TabIndex = 84
      Me.cmdGuardar2.Text = "&Guardar"
      Me.cmdGuardar2.UseVisualStyleBackColor = True
      '
      'cmdCancelar2
      '
      Me.cmdCancelar2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdCancelar2.Location = New System.Drawing.Point(703, 453)
      Me.cmdCancelar2.Name = "cmdCancelar2"
      Me.cmdCancelar2.Size = New System.Drawing.Size(75, 23)
      Me.cmdCancelar2.TabIndex = 83
      Me.cmdCancelar2.Text = "&Cancelar"
      Me.cmdCancelar2.UseVisualStyleBackColor = True
      '
      'txtCheques
      '
      Me.txtCheques.BackColor = System.Drawing.Color.LightYellow
      Me.txtCheques.Enabled = False
      Me.txtCheques.Location = New System.Drawing.Point(118, 112)
      Me.txtCheques.Name = "txtCheques"
      Me.txtCheques.Size = New System.Drawing.Size(82, 20)
      Me.txtCheques.TabIndex = 81
      '
      'Label27
      '
      Me.Label27.AutoSize = True
      Me.Label27.Location = New System.Drawing.Point(51, 82)
      Me.Label27.Name = "Label27"
      Me.Label27.Size = New System.Drawing.Size(55, 13)
      Me.Label27.TabIndex = 80
      Me.Label27.Text = "Efectivo $"
      '
      'txtEfectivo
      '
      Me.txtEfectivo.Location = New System.Drawing.Point(118, 79)
      Me.txtEfectivo.Name = "txtEfectivo"
      Me.txtEfectivo.Size = New System.Drawing.Size(82, 20)
      Me.txtEfectivo.TabIndex = 79
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(24, 275)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(88, 13)
      Me.Label2.TabIndex = 37
      Me.Label2.Text = "Detalle del Pago:"
      '
      'txtDetPago
      '
      Me.txtDetPago.Location = New System.Drawing.Point(118, 272)
      Me.txtDetPago.Multiline = True
      Me.txtDetPago.Name = "txtDetPago"
      Me.txtDetPago.Size = New System.Drawing.Size(392, 70)
      Me.txtDetPago.TabIndex = 0
      '
      'frmComprasAM
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(809, 579)
      Me.Controls.Add(Me.ssTab1)
      Me.Controls.Add(Me.Label18)
      Me.Controls.Add(Me.cboEmpresa)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "frmComprasAM"
      Me.Text = "Compra"
      Me.ssTab1.ResumeLayout(False)
      Me.TabPage1.ResumeLayout(False)
      Me.TabPage1.PerformLayout()
      Me.Panel1.ResumeLayout(False)
      Me.Panel1.PerformLayout()
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.TabPage2.ResumeLayout(False)
      Me.TabPage2.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents chkCasual As System.Windows.Forms.CheckBox
   Friend WithEvents Label18 As System.Windows.Forms.Label
   Friend WithEvents cboEmpresa As System.Windows.Forms.ComboBox
   Friend WithEvents tbFecha As System.Windows.Forms.DateTimePicker
   Friend WithEvents Label10 As System.Windows.Forms.Label
   Friend WithEvents tbFecVenc As System.Windows.Forms.DateTimePicker
   Friend WithEvents Label11 As System.Windows.Forms.Label
   Friend WithEvents tbPerIVA As System.Windows.Forms.DateTimePicker
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents ssTab1 As System.Windows.Forms.TabControl
   Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
   Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
   Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents txtDetPago As System.Windows.Forms.TextBox
   Friend WithEvents cboProveedor As System.Windows.Forms.ComboBox
   Friend WithEvents Label9 As System.Windows.Forms.Label
   Friend WithEvents tbNumero As System.Windows.Forms.TextBox
   Friend WithEvents tbSucursal As System.Windows.Forms.TextBox
   Friend WithEvents txtCuit As System.Windows.Forms.MaskedTextBox
   Friend WithEvents Label8 As System.Windows.Forms.Label
   Friend WithEvents cboTipoComp As System.Windows.Forms.ComboBox
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents cboLetra As System.Windows.Forms.ComboBox
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents cboTipoIva As System.Windows.Forms.ComboBox
   Friend WithEvents tbGravado As System.Windows.Forms.TextBox
   Friend WithEvents txtDescuento As System.Windows.Forms.TextBox
   Friend WithEvents tbSubtotal As System.Windows.Forms.TextBox
   Friend WithEvents Label7 As System.Windows.Forms.Label
   Friend WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents Label12 As System.Windows.Forms.Label
   Friend WithEvents Label13 As System.Windows.Forms.Label
   Friend WithEvents tbNoGravado As System.Windows.Forms.TextBox
   Friend WithEvents Label14 As System.Windows.Forms.Label
   Friend WithEvents tbCompraRNI As System.Windows.Forms.TextBox
   Friend WithEvents Label15 As System.Windows.Forms.Label
   Friend WithEvents tbExento As System.Windows.Forms.TextBox
   Friend WithEvents lblIva1 As System.Windows.Forms.Label
   Friend WithEvents tbIVA1 As System.Windows.Forms.TextBox
   Friend WithEvents lblIva2 As System.Windows.Forms.Label
   Friend WithEvents tbIVA2 As System.Windows.Forms.TextBox
   Friend WithEvents Panel1 As System.Windows.Forms.Panel
   Friend WithEvents Label19 As System.Windows.Forms.Label
   Friend WithEvents txtRetIva As System.Windows.Forms.TextBox
   Friend WithEvents cmdAceptar As System.Windows.Forms.Button
   Friend WithEvents cmdSalir As System.Windows.Forms.Button
   Friend WithEvents cmdNuevoProv As System.Windows.Forms.Button
   Friend WithEvents Label21 As System.Windows.Forms.Label
   Friend WithEvents txtRetGan As System.Windows.Forms.TextBox
   Friend WithEvents Label20 As System.Windows.Forms.Label
   Friend WithEvents txtRetIB As System.Windows.Forms.TextBox
   Friend WithEvents Label22 As System.Windows.Forms.Label
   Friend WithEvents txtTotal As System.Windows.Forms.TextBox
   Friend WithEvents Label23 As System.Windows.Forms.Label
   Friend WithEvents tbDetalle As System.Windows.Forms.TextBox
   Friend WithEvents optContado As System.Windows.Forms.RadioButton
   Friend WithEvents optCtaCte As System.Windows.Forms.RadioButton
   Friend WithEvents Label24 As System.Windows.Forms.Label
   Friend WithEvents Label25 As System.Windows.Forms.Label
   Friend WithEvents cboAlicIVA As System.Windows.Forms.ComboBox
   Friend WithEvents cboPedidoPr As System.Windows.Forms.ComboBox
   Friend WithEvents txtCheques As System.Windows.Forms.TextBox
   Friend WithEvents Label27 As System.Windows.Forms.Label
   Friend WithEvents txtEfectivo As System.Windows.Forms.TextBox
   Friend WithEvents cmdSiguiente As System.Windows.Forms.Button
   Friend WithEvents cmdGuardar As System.Windows.Forms.Button
   Friend WithEvents cmdCancelar As System.Windows.Forms.Button
   Friend WithEvents cmdAnterior As System.Windows.Forms.Button
   Friend WithEvents cmdGuardar2 As System.Windows.Forms.Button
   Friend WithEvents cmdCancelar2 As System.Windows.Forms.Button
   Friend WithEvents cmdRefRemito As System.Windows.Forms.Button
   Friend WithEvents cmdEdicion As System.Windows.Forms.Button
   Friend WithEvents cmdBaja As System.Windows.Forms.Button
   Friend WithEvents cmdAltaProd As System.Windows.Forms.Button
   Friend WithEvents Label16 As System.Windows.Forms.Label
   Friend WithEvents txtGravado2 As System.Windows.Forms.TextBox
   Friend WithEvents cmdAltaServ As System.Windows.Forms.Button
   Friend WithEvents Label17 As System.Windows.Forms.Label
   Friend WithEvents txtTotalPago As System.Windows.Forms.TextBox
   Friend WithEvents Label29 As System.Windows.Forms.Label
   Friend WithEvents btnCheques As System.Windows.Forms.Button
End Class
