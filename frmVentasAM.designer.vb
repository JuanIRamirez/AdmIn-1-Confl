<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmVentasAM
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
      Me.TabControl1 = New System.Windows.Forms.TabControl()
      Me.TabPage1 = New System.Windows.Forms.TabPage()
      Me.btnRecalc = New System.Windows.Forms.Button()
      Me.btnAltaServ = New System.Windows.Forms.Button()
      Me.btnBaja = New System.Windows.Forms.Button()
      Me.btnModif = New System.Windows.Forms.Button()
      Me.Label22 = New System.Windows.Forms.Label()
      Me.tbObserv = New System.Windows.Forms.TextBox()
      Me.btnSiguiente = New System.Windows.Forms.Button()
      Me.btnGuardar = New System.Windows.Forms.Button()
      Me.btnCancelar = New System.Windows.Forms.Button()
      Me.Label20 = New System.Windows.Forms.Label()
      Me.tbTotal = New System.Windows.Forms.TextBox()
      Me.Label21 = New System.Windows.Forms.Label()
      Me.tbExento = New System.Windows.Forms.TextBox()
      Me.lblIva2 = New System.Windows.Forms.Label()
      Me.tbIva2 = New System.Windows.Forms.TextBox()
      Me.lblIva1 = New System.Windows.Forms.Label()
      Me.tbIva1 = New System.Windows.Forms.TextBox()
      Me.Label17 = New System.Windows.Forms.Label()
      Me.tbNoGravado = New System.Windows.Forms.TextBox()
      Me.Label16 = New System.Windows.Forms.Label()
      Me.tbGravado = New System.Windows.Forms.TextBox()
      Me.Label15 = New System.Windows.Forms.Label()
      Me.Label14 = New System.Windows.Forms.Label()
      Me.tbBonificacion = New System.Windows.Forms.TextBox()
      Me.tbSubtotal = New System.Windows.Forms.TextBox()
      Me.DataGridView1 = New System.Windows.Forms.DataGridView()
      Me.cboEntrega = New System.Windows.Forms.ComboBox()
      Me.btnAceptar = New System.Windows.Forms.Button()
      Me.tbFecVenc = New System.Windows.Forms.DateTimePicker()
      Me.Label11 = New System.Windows.Forms.Label()
      Me.tbFecha = New System.Windows.Forms.DateTimePicker()
      Me.Label10 = New System.Windows.Forms.Label()
      Me.btnSalir = New System.Windows.Forms.Button()
      Me.Label35 = New System.Windows.Forms.Label()
      Me.Label9 = New System.Windows.Forms.Label()
      Me.tbNumero = New System.Windows.Forms.TextBox()
      Me.tbSucursal = New System.Windows.Forms.TextBox()
      Me.tbCuit = New System.Windows.Forms.MaskedTextBox()
      Me.Label34 = New System.Windows.Forms.Label()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.cboTransporte = New System.Windows.Forms.ComboBox()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.cboCondVenta = New System.Windows.Forms.ComboBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.cboTipoIva = New System.Windows.Forms.ComboBox()
      Me.Label32 = New System.Windows.Forms.Label()
      Me.chkCasual = New System.Windows.Forms.CheckBox()
      Me.Label31 = New System.Windows.Forms.Label()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.cboTipoComp = New System.Windows.Forms.ComboBox()
      Me.cboLetra = New System.Windows.Forms.ComboBox()
      Me.cboCliente = New System.Windows.Forms.ComboBox()
      Me.TabPage2 = New System.Windows.Forms.TabPage()
      Me.btnAnterior = New System.Windows.Forms.Button()
      Me.btnGuardar2 = New System.Windows.Forms.Button()
      Me.btnCancelar2 = New System.Windows.Forms.Button()
      Me.Label30 = New System.Windows.Forms.Label()
      Me.tbNroTarjD = New System.Windows.Forms.TextBox()
      Me.cboTarjetaD = New System.Windows.Forms.ComboBox()
      Me.Label29 = New System.Windows.Forms.Label()
      Me.tbNroTarjC = New System.Windows.Forms.TextBox()
      Me.cboTarjetaC = New System.Windows.Forms.ComboBox()
      Me.btnCheques = New System.Windows.Forms.Button()
      Me.Label28 = New System.Windows.Forms.Label()
      Me.tbDetCobro = New System.Windows.Forms.TextBox()
      Me.Label27 = New System.Windows.Forms.Label()
      Me.tbTarjetaD = New System.Windows.Forms.TextBox()
      Me.Label26 = New System.Windows.Forms.Label()
      Me.tbTarjetaC = New System.Windows.Forms.TextBox()
      Me.Label25 = New System.Windows.Forms.Label()
      Me.tbCheques = New System.Windows.Forms.TextBox()
      Me.Label24 = New System.Windows.Forms.Label()
      Me.tbEfectivo = New System.Windows.Forms.TextBox()
      Me.Label23 = New System.Windows.Forms.Label()
      Me.tbTotal2 = New System.Windows.Forms.TextBox()
      Me.Label7 = New System.Windows.Forms.Label()
      Me.cboFormaPago = New System.Windows.Forms.ComboBox()
      Me.optPropietarios = New System.Windows.Forms.RadioButton()
      Me.optInquilinos = New System.Windows.Forms.RadioButton()
      Me.optClientes = New System.Windows.Forms.RadioButton()
      Me.TabControl1.SuspendLayout()
      Me.TabPage1.SuspendLayout()
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.TabPage2.SuspendLayout()
      Me.SuspendLayout()
      '
      'TabControl1
      '
      Me.TabControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.TabControl1.Controls.Add(Me.TabPage1)
      Me.TabControl1.Controls.Add(Me.TabPage2)
      Me.TabControl1.Location = New System.Drawing.Point(12, 12)
      Me.TabControl1.Name = "TabControl1"
      Me.TabControl1.SelectedIndex = 0
      Me.TabControl1.Size = New System.Drawing.Size(826, 584)
      Me.TabControl1.TabIndex = 0
      '
      'TabPage1
      '
      Me.TabPage1.BackColor = System.Drawing.SystemColors.Control
      Me.TabPage1.Controls.Add(Me.optClientes)
      Me.TabPage1.Controls.Add(Me.optInquilinos)
      Me.TabPage1.Controls.Add(Me.optPropietarios)
      Me.TabPage1.Controls.Add(Me.btnRecalc)
      Me.TabPage1.Controls.Add(Me.btnAltaServ)
      Me.TabPage1.Controls.Add(Me.btnBaja)
      Me.TabPage1.Controls.Add(Me.btnModif)
      Me.TabPage1.Controls.Add(Me.Label22)
      Me.TabPage1.Controls.Add(Me.tbObserv)
      Me.TabPage1.Controls.Add(Me.btnSiguiente)
      Me.TabPage1.Controls.Add(Me.btnGuardar)
      Me.TabPage1.Controls.Add(Me.btnCancelar)
      Me.TabPage1.Controls.Add(Me.Label20)
      Me.TabPage1.Controls.Add(Me.tbTotal)
      Me.TabPage1.Controls.Add(Me.Label21)
      Me.TabPage1.Controls.Add(Me.tbExento)
      Me.TabPage1.Controls.Add(Me.lblIva2)
      Me.TabPage1.Controls.Add(Me.tbIva2)
      Me.TabPage1.Controls.Add(Me.lblIva1)
      Me.TabPage1.Controls.Add(Me.tbIva1)
      Me.TabPage1.Controls.Add(Me.Label17)
      Me.TabPage1.Controls.Add(Me.tbNoGravado)
      Me.TabPage1.Controls.Add(Me.Label16)
      Me.TabPage1.Controls.Add(Me.tbGravado)
      Me.TabPage1.Controls.Add(Me.Label15)
      Me.TabPage1.Controls.Add(Me.Label14)
      Me.TabPage1.Controls.Add(Me.tbBonificacion)
      Me.TabPage1.Controls.Add(Me.tbSubtotal)
      Me.TabPage1.Controls.Add(Me.DataGridView1)
      Me.TabPage1.Controls.Add(Me.cboEntrega)
      Me.TabPage1.Controls.Add(Me.btnAceptar)
      Me.TabPage1.Controls.Add(Me.tbFecVenc)
      Me.TabPage1.Controls.Add(Me.Label11)
      Me.TabPage1.Controls.Add(Me.tbFecha)
      Me.TabPage1.Controls.Add(Me.Label10)
      Me.TabPage1.Controls.Add(Me.btnSalir)
      Me.TabPage1.Controls.Add(Me.Label35)
      Me.TabPage1.Controls.Add(Me.Label9)
      Me.TabPage1.Controls.Add(Me.tbNumero)
      Me.TabPage1.Controls.Add(Me.tbSucursal)
      Me.TabPage1.Controls.Add(Me.tbCuit)
      Me.TabPage1.Controls.Add(Me.Label34)
      Me.TabPage1.Controls.Add(Me.Label6)
      Me.TabPage1.Controls.Add(Me.cboTransporte)
      Me.TabPage1.Controls.Add(Me.Label4)
      Me.TabPage1.Controls.Add(Me.cboCondVenta)
      Me.TabPage1.Controls.Add(Me.Label3)
      Me.TabPage1.Controls.Add(Me.cboTipoIva)
      Me.TabPage1.Controls.Add(Me.Label32)
      Me.TabPage1.Controls.Add(Me.chkCasual)
      Me.TabPage1.Controls.Add(Me.Label31)
      Me.TabPage1.Controls.Add(Me.Label2)
      Me.TabPage1.Controls.Add(Me.Label1)
      Me.TabPage1.Controls.Add(Me.cboTipoComp)
      Me.TabPage1.Controls.Add(Me.cboLetra)
      Me.TabPage1.Controls.Add(Me.cboCliente)
      Me.TabPage1.Location = New System.Drawing.Point(4, 22)
      Me.TabPage1.Name = "TabPage1"
      Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
      Me.TabPage1.Size = New System.Drawing.Size(818, 558)
      Me.TabPage1.TabIndex = 0
      Me.TabPage1.Text = "Venta"
      '
      'btnRecalc
      '
      Me.btnRecalc.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnRecalc.Location = New System.Drawing.Point(679, 410)
      Me.btnRecalc.Name = "btnRecalc"
      Me.btnRecalc.Size = New System.Drawing.Size(53, 23)
      Me.btnRecalc.TabIndex = 66
      Me.btnRecalc.Text = "&Recalc."
      Me.btnRecalc.UseVisualStyleBackColor = True
      '
      'btnAltaServ
      '
      Me.btnAltaServ.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btnAltaServ.Location = New System.Drawing.Point(10, 410)
      Me.btnAltaServ.Name = "btnAltaServ"
      Me.btnAltaServ.Size = New System.Drawing.Size(63, 23)
      Me.btnAltaServ.TabIndex = 61
      Me.btnAltaServ.Text = "&Agregar"
      Me.btnAltaServ.UseVisualStyleBackColor = True
      '
      'btnBaja
      '
      Me.btnBaja.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btnBaja.Location = New System.Drawing.Point(79, 410)
      Me.btnBaja.Name = "btnBaja"
      Me.btnBaja.Size = New System.Drawing.Size(62, 23)
      Me.btnBaja.TabIndex = 62
      Me.btnBaja.Text = "&Quitar"
      Me.btnBaja.UseVisualStyleBackColor = True
      '
      'btnModif
      '
      Me.btnModif.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btnModif.Location = New System.Drawing.Point(147, 409)
      Me.btnModif.Name = "btnModif"
      Me.btnModif.Size = New System.Drawing.Size(69, 23)
      Me.btnModif.TabIndex = 63
      Me.btnModif.Text = "&Modificar"
      Me.btnModif.UseVisualStyleBackColor = True
      '
      'Label22
      '
      Me.Label22.AutoSize = True
      Me.Label22.Location = New System.Drawing.Point(16, 480)
      Me.Label22.Name = "Label22"
      Me.Label22.Size = New System.Drawing.Size(47, 13)
      Me.Label22.TabIndex = 56
      Me.Label22.Text = "Observ.:"
      '
      'tbObserv
      '
      Me.tbObserv.Enabled = False
      Me.tbObserv.Location = New System.Drawing.Point(69, 458)
      Me.tbObserv.Multiline = True
      Me.tbObserv.Name = "tbObserv"
      Me.tbObserv.Size = New System.Drawing.Size(451, 66)
      Me.tbObserv.TabIndex = 55
      '
      'btnSiguiente
      '
      Me.btnSiguiente.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnSiguiente.Enabled = False
      Me.btnSiguiente.Location = New System.Drawing.Point(574, 529)
      Me.btnSiguiente.Name = "btnSiguiente"
      Me.btnSiguiente.Size = New System.Drawing.Size(75, 23)
      Me.btnSiguiente.TabIndex = 54
      Me.btnSiguiente.Text = "&Siguiente >>"
      Me.btnSiguiente.UseVisualStyleBackColor = True
      '
      'btnGuardar
      '
      Me.btnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnGuardar.Enabled = False
      Me.btnGuardar.Location = New System.Drawing.Point(655, 529)
      Me.btnGuardar.Name = "btnGuardar"
      Me.btnGuardar.Size = New System.Drawing.Size(75, 23)
      Me.btnGuardar.TabIndex = 53
      Me.btnGuardar.Text = "&Guardar"
      Me.btnGuardar.UseVisualStyleBackColor = True
      '
      'btnCancelar
      '
      Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnCancelar.Enabled = False
      Me.btnCancelar.Location = New System.Drawing.Point(736, 529)
      Me.btnCancelar.Name = "btnCancelar"
      Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
      Me.btnCancelar.TabIndex = 52
      Me.btnCancelar.Text = "&Cancelar"
      Me.btnCancelar.UseVisualStyleBackColor = True
      '
      'Label20
      '
      Me.Label20.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label20.AutoSize = True
      Me.Label20.Location = New System.Drawing.Point(694, 497)
      Me.Label20.Name = "Label20"
      Me.Label20.Size = New System.Drawing.Size(40, 13)
      Me.Label20.TabIndex = 51
      Me.Label20.Text = "Total $"
      '
      'tbTotal
      '
      Me.tbTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tbTotal.BackColor = System.Drawing.Color.LightGoldenrodYellow
      Me.tbTotal.Enabled = False
      Me.tbTotal.Location = New System.Drawing.Point(736, 494)
      Me.tbTotal.Name = "tbTotal"
      Me.tbTotal.Size = New System.Drawing.Size(76, 20)
      Me.tbTotal.TabIndex = 50
      '
      'Label21
      '
      Me.Label21.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label21.AutoSize = True
      Me.Label21.Location = New System.Drawing.Point(545, 496)
      Me.Label21.Name = "Label21"
      Me.Label21.Size = New System.Drawing.Size(49, 13)
      Me.Label21.TabIndex = 49
      Me.Label21.Text = "Exento $"
      '
      'tbExento
      '
      Me.tbExento.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tbExento.Enabled = False
      Me.tbExento.Location = New System.Drawing.Point(598, 494)
      Me.tbExento.MaxLength = 12
      Me.tbExento.Name = "tbExento"
      Me.tbExento.Size = New System.Drawing.Size(76, 20)
      Me.tbExento.TabIndex = 48
      '
      'lblIva2
      '
      Me.lblIva2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblIva2.AutoSize = True
      Me.lblIva2.Location = New System.Drawing.Point(677, 470)
      Me.lblIva2.Name = "lblIva2"
      Me.lblIva2.Size = New System.Drawing.Size(40, 13)
      Me.lblIva2.TabIndex = 47
      Me.lblIva2.Text = "Iva 2 $"
      '
      'tbIva2
      '
      Me.tbIva2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tbIva2.Enabled = False
      Me.tbIva2.Location = New System.Drawing.Point(736, 467)
      Me.tbIva2.MaxLength = 12
      Me.tbIva2.Name = "tbIva2"
      Me.tbIva2.Size = New System.Drawing.Size(76, 20)
      Me.tbIva2.TabIndex = 46
      '
      'lblIva1
      '
      Me.lblIva1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblIva1.AutoSize = True
      Me.lblIva1.Location = New System.Drawing.Point(537, 470)
      Me.lblIva1.Name = "lblIva1"
      Me.lblIva1.Size = New System.Drawing.Size(40, 13)
      Me.lblIva1.TabIndex = 45
      Me.lblIva1.Text = "Iva 1 $"
      '
      'tbIva1
      '
      Me.tbIva1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tbIva1.Enabled = False
      Me.tbIva1.Location = New System.Drawing.Point(598, 467)
      Me.tbIva1.MaxLength = 12
      Me.tbIva1.Name = "tbIva1"
      Me.tbIva1.Size = New System.Drawing.Size(76, 20)
      Me.tbIva1.TabIndex = 44
      '
      'Label17
      '
      Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label17.AutoSize = True
      Me.Label17.Location = New System.Drawing.Point(675, 443)
      Me.Label17.Name = "Label17"
      Me.Label17.Size = New System.Drawing.Size(59, 13)
      Me.Label17.TabIndex = 43
      Me.Label17.Text = "No Grav. $"
      '
      'tbNoGravado
      '
      Me.tbNoGravado.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tbNoGravado.Enabled = False
      Me.tbNoGravado.Location = New System.Drawing.Point(736, 438)
      Me.tbNoGravado.MaxLength = 12
      Me.tbNoGravado.Name = "tbNoGravado"
      Me.tbNoGravado.Size = New System.Drawing.Size(76, 20)
      Me.tbNoGravado.TabIndex = 42
      '
      'Label16
      '
      Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label16.AutoSize = True
      Me.Label16.Location = New System.Drawing.Point(537, 441)
      Me.Label16.Name = "Label16"
      Me.Label16.Size = New System.Drawing.Size(57, 13)
      Me.Label16.TabIndex = 41
      Me.Label16.Text = "Gravado $"
      '
      'tbGravado
      '
      Me.tbGravado.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tbGravado.Enabled = False
      Me.tbGravado.Location = New System.Drawing.Point(598, 438)
      Me.tbGravado.MaxLength = 12
      Me.tbGravado.Name = "tbGravado"
      Me.tbGravado.Size = New System.Drawing.Size(76, 20)
      Me.tbGravado.TabIndex = 40
      '
      'Label15
      '
      Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label15.AutoSize = True
      Me.Label15.Location = New System.Drawing.Point(539, 417)
      Me.Label15.Name = "Label15"
      Me.Label15.Size = New System.Drawing.Size(55, 13)
      Me.Label15.TabIndex = 39
      Me.Label15.Text = "Subtotal $"
      '
      'Label14
      '
      Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label14.AutoSize = True
      Me.Label14.Location = New System.Drawing.Point(731, 417)
      Me.Label14.Name = "Label14"
      Me.Label14.Size = New System.Drawing.Size(42, 13)
      Me.Label14.TabIndex = 38
      Me.Label14.Text = "Bonif.%"
      '
      'tbBonificacion
      '
      Me.tbBonificacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tbBonificacion.Enabled = False
      Me.tbBonificacion.Location = New System.Drawing.Point(773, 412)
      Me.tbBonificacion.MaxLength = 2
      Me.tbBonificacion.Name = "tbBonificacion"
      Me.tbBonificacion.Size = New System.Drawing.Size(39, 20)
      Me.tbBonificacion.TabIndex = 37
      '
      'tbSubtotal
      '
      Me.tbSubtotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tbSubtotal.BackColor = System.Drawing.Color.LightGoldenrodYellow
      Me.tbSubtotal.Enabled = False
      Me.tbSubtotal.Location = New System.Drawing.Point(598, 412)
      Me.tbSubtotal.Name = "tbSubtotal"
      Me.tbSubtotal.Size = New System.Drawing.Size(76, 20)
      Me.tbSubtotal.TabIndex = 36
      '
      'DataGridView1
      '
      Me.DataGridView1.AllowUserToAddRows = False
      Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
      Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.DataGridView1.Location = New System.Drawing.Point(10, 100)
      Me.DataGridView1.Name = "DataGridView1"
      Me.DataGridView1.ReadOnly = True
      Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.DataGridView1.Size = New System.Drawing.Size(803, 304)
      Me.DataGridView1.TabIndex = 32
      '
      'cboEntrega
      '
      Me.cboEntrega.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cboEntrega.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboEntrega.Enabled = False
      Me.cboEntrega.FormattingEnabled = True
      Me.cboEntrega.Location = New System.Drawing.Point(69, 469)
      Me.cboEntrega.Name = "cboEntrega"
      Me.cboEntrega.Size = New System.Drawing.Size(80, 21)
      Me.cboEntrega.TabIndex = 31
      '
      'btnAceptar
      '
      Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnAceptar.Location = New System.Drawing.Point(677, 70)
      Me.btnAceptar.Name = "btnAceptar"
      Me.btnAceptar.Size = New System.Drawing.Size(68, 23)
      Me.btnAceptar.TabIndex = 13
      Me.btnAceptar.Text = "&Aceptar"
      Me.btnAceptar.UseVisualStyleBackColor = True
      '
      'tbFecVenc
      '
      Me.tbFecVenc.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.tbFecVenc.Location = New System.Drawing.Point(417, 73)
      Me.tbFecVenc.Name = "tbFecVenc"
      Me.tbFecVenc.Size = New System.Drawing.Size(89, 20)
      Me.tbFecVenc.TabIndex = 11
      '
      'Label11
      '
      Me.Label11.AutoSize = True
      Me.Label11.Location = New System.Drawing.Point(377, 77)
      Me.Label11.Name = "Label11"
      Me.Label11.Size = New System.Drawing.Size(38, 13)
      Me.Label11.TabIndex = 25
      Me.Label11.Text = "Venc.:"
      '
      'tbFecha
      '
      Me.tbFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.tbFecha.Location = New System.Drawing.Point(69, 73)
      Me.tbFecha.Name = "tbFecha"
      Me.tbFecha.Size = New System.Drawing.Size(89, 20)
      Me.tbFecha.TabIndex = 9
      '
      'Label10
      '
      Me.Label10.AutoSize = True
      Me.Label10.Location = New System.Drawing.Point(23, 77)
      Me.Label10.Name = "Label10"
      Me.Label10.Size = New System.Drawing.Size(40, 13)
      Me.Label10.TabIndex = 23
      Me.Label10.Text = "Fecha:"
      '
      'btnSalir
      '
      Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnSalir.Location = New System.Drawing.Point(749, 70)
      Me.btnSalir.Name = "btnSalir"
      Me.btnSalir.Size = New System.Drawing.Size(60, 23)
      Me.btnSalir.TabIndex = 14
      Me.btnSalir.Text = "&Salir"
      Me.btnSalir.UseVisualStyleBackColor = True
      '
      'Label35
      '
      Me.Label35.AutoSize = True
      Me.Label35.Location = New System.Drawing.Point(618, 44)
      Me.Label35.Name = "Label35"
      Me.Label35.Size = New System.Drawing.Size(69, 13)
      Me.Label35.TabIndex = 21
      Me.Label35.Text = "Suc-Número:"
      '
      'Label9
      '
      Me.Label9.AutoSize = True
      Me.Label9.Location = New System.Drawing.Point(617, 44)
      Me.Label9.Name = "Label9"
      Me.Label9.Size = New System.Drawing.Size(69, 13)
      Me.Label9.TabIndex = 21
      Me.Label9.Text = "Suc-Número:"
      '
      'tbNumero
      '
      Me.tbNumero.Location = New System.Drawing.Point(733, 40)
      Me.tbNumero.MaxLength = 8
      Me.tbNumero.Name = "tbNumero"
      Me.tbNumero.Size = New System.Drawing.Size(76, 20)
      Me.tbNumero.TabIndex = 8
      '
      'tbSucursal
      '
      Me.tbSucursal.Location = New System.Drawing.Point(692, 40)
      Me.tbSucursal.MaxLength = 4
      Me.tbSucursal.Name = "tbSucursal"
      Me.tbSucursal.Size = New System.Drawing.Size(35, 20)
      Me.tbSucursal.TabIndex = 7
      '
      'tbCuit
      '
      Me.tbCuit.Location = New System.Drawing.Point(278, 41)
      Me.tbCuit.Mask = "00-00000000-0"
      Me.tbCuit.Name = "tbCuit"
      Me.tbCuit.Size = New System.Drawing.Size(100, 20)
      Me.tbCuit.TabIndex = 4
      '
      'Label34
      '
      Me.Label34.AutoSize = True
      Me.Label34.Location = New System.Drawing.Point(238, 44)
      Me.Label34.Name = "Label34"
      Me.Label34.Size = New System.Drawing.Size(35, 13)
      Me.Label34.TabIndex = 16
      Me.Label34.Text = "CUIT:"
      '
      'Label6
      '
      Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.Label6.AutoSize = True
      Me.Label6.Location = New System.Drawing.Point(155, 473)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(61, 13)
      Me.Label6.TabIndex = 13
      Me.Label6.Text = "Transporte:"
      '
      'cboTransporte
      '
      Me.cboTransporte.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cboTransporte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboTransporte.Enabled = False
      Me.cboTransporte.FormattingEnabled = True
      Me.cboTransporte.Location = New System.Drawing.Point(219, 470)
      Me.cboTransporte.Name = "cboTransporte"
      Me.cboTransporte.Size = New System.Drawing.Size(221, 21)
      Me.cboTransporte.TabIndex = 14
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(164, 77)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(66, 13)
      Me.Label4.TabIndex = 9
      Me.Label4.Text = "Cond.Venta:"
      '
      'cboCondVenta
      '
      Me.cboCondVenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboCondVenta.FormattingEnabled = True
      Me.cboCondVenta.Location = New System.Drawing.Point(236, 73)
      Me.cboCondVenta.Name = "cboCondVenta"
      Me.cboCondVenta.Size = New System.Drawing.Size(127, 21)
      Me.cboCondVenta.TabIndex = 10
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(12, 44)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(51, 13)
      Me.Label3.TabIndex = 7
      Me.Label3.Text = "Tipo IVA:"
      '
      'cboTipoIva
      '
      Me.cboTipoIva.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cboTipoIva.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboTipoIva.FormattingEnabled = True
      Me.cboTipoIva.Location = New System.Drawing.Point(68, 39)
      Me.cboTipoIva.Name = "cboTipoIva"
      Me.cboTipoIva.Size = New System.Drawing.Size(130, 21)
      Me.cboTipoIva.TabIndex = 3
      '
      'Label32
      '
      Me.Label32.AutoSize = True
      Me.Label32.Location = New System.Drawing.Point(531, 44)
      Me.Label32.Name = "Label32"
      Me.Label32.Size = New System.Drawing.Size(34, 13)
      Me.Label32.TabIndex = 5
      Me.Label32.Text = "Letra:"
      '
      'chkCasual
      '
      Me.chkCasual.AutoSize = True
      Me.chkCasual.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.chkCasual.Location = New System.Drawing.Point(79, 11)
      Me.chkCasual.Name = "chkCasual"
      Me.chkCasual.Size = New System.Drawing.Size(64, 17)
      Me.chkCasual.TabIndex = 5
      Me.chkCasual.Text = "(Casual)"
      Me.chkCasual.UseVisualStyleBackColor = True
      '
      'Label31
      '
      Me.Label31.AutoSize = True
      Me.Label31.Location = New System.Drawing.Point(387, 44)
      Me.Label31.Name = "Label31"
      Me.Label31.Size = New System.Drawing.Size(32, 13)
      Me.Label31.TabIndex = 3
      Me.Label31.Text = "Cpte:"
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(530, 44)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(34, 13)
      Me.Label2.TabIndex = 5
      Me.Label2.Text = "Letra:"
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(386, 44)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(32, 13)
      Me.Label1.TabIndex = 3
      Me.Label1.Text = "Cpte:"
      '
      'cboTipoComp
      '
      Me.cboTipoComp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboTipoComp.FormattingEnabled = True
      Me.cboTipoComp.Location = New System.Drawing.Point(424, 40)
      Me.cboTipoComp.Name = "cboTipoComp"
      Me.cboTipoComp.Size = New System.Drawing.Size(100, 21)
      Me.cboTipoComp.TabIndex = 5
      '
      'cboLetra
      '
      Me.cboLetra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboLetra.FormattingEnabled = True
      Me.cboLetra.Location = New System.Drawing.Point(570, 40)
      Me.cboLetra.Name = "cboLetra"
      Me.cboLetra.Size = New System.Drawing.Size(36, 21)
      Me.cboLetra.TabIndex = 6
      '
      'cboCliente
      '
      Me.cboCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      Me.cboCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.cboCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboCliente.FormattingEnabled = True
      Me.cboCliente.Location = New System.Drawing.Point(316, 10)
      Me.cboCliente.Name = "cboCliente"
      Me.cboCliente.Size = New System.Drawing.Size(493, 21)
      Me.cboCliente.TabIndex = 0
      '
      'TabPage2
      '
      Me.TabPage2.BackColor = System.Drawing.SystemColors.Control
      Me.TabPage2.Controls.Add(Me.btnAnterior)
      Me.TabPage2.Controls.Add(Me.btnGuardar2)
      Me.TabPage2.Controls.Add(Me.btnCancelar2)
      Me.TabPage2.Controls.Add(Me.Label30)
      Me.TabPage2.Controls.Add(Me.tbNroTarjD)
      Me.TabPage2.Controls.Add(Me.cboTarjetaD)
      Me.TabPage2.Controls.Add(Me.Label29)
      Me.TabPage2.Controls.Add(Me.tbNroTarjC)
      Me.TabPage2.Controls.Add(Me.cboTarjetaC)
      Me.TabPage2.Controls.Add(Me.btnCheques)
      Me.TabPage2.Controls.Add(Me.Label28)
      Me.TabPage2.Controls.Add(Me.tbDetCobro)
      Me.TabPage2.Controls.Add(Me.Label27)
      Me.TabPage2.Controls.Add(Me.tbTarjetaD)
      Me.TabPage2.Controls.Add(Me.Label26)
      Me.TabPage2.Controls.Add(Me.tbTarjetaC)
      Me.TabPage2.Controls.Add(Me.Label25)
      Me.TabPage2.Controls.Add(Me.tbCheques)
      Me.TabPage2.Controls.Add(Me.Label24)
      Me.TabPage2.Controls.Add(Me.tbEfectivo)
      Me.TabPage2.Controls.Add(Me.Label23)
      Me.TabPage2.Controls.Add(Me.tbTotal2)
      Me.TabPage2.Controls.Add(Me.Label7)
      Me.TabPage2.Controls.Add(Me.cboFormaPago)
      Me.TabPage2.Location = New System.Drawing.Point(4, 22)
      Me.TabPage2.Name = "TabPage2"
      Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
      Me.TabPage2.Size = New System.Drawing.Size(818, 558)
      Me.TabPage2.TabIndex = 1
      Me.TabPage2.Text = "Cobranza"
      '
      'btnAnterior
      '
      Me.btnAnterior.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnAnterior.Location = New System.Drawing.Point(488, 461)
      Me.btnAnterior.Name = "btnAnterior"
      Me.btnAnterior.Size = New System.Drawing.Size(75, 23)
      Me.btnAnterior.TabIndex = 73
      Me.btnAnterior.Text = "<< &Anterior"
      Me.btnAnterior.UseVisualStyleBackColor = True
      '
      'btnGuardar2
      '
      Me.btnGuardar2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnGuardar2.Location = New System.Drawing.Point(569, 461)
      Me.btnGuardar2.Name = "btnGuardar2"
      Me.btnGuardar2.Size = New System.Drawing.Size(75, 23)
      Me.btnGuardar2.TabIndex = 72
      Me.btnGuardar2.Text = "&Guardar"
      Me.btnGuardar2.UseVisualStyleBackColor = True
      '
      'btnCancelar2
      '
      Me.btnCancelar2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnCancelar2.Location = New System.Drawing.Point(650, 461)
      Me.btnCancelar2.Name = "btnCancelar2"
      Me.btnCancelar2.Size = New System.Drawing.Size(75, 23)
      Me.btnCancelar2.TabIndex = 71
      Me.btnCancelar2.Text = "&Cancelar"
      Me.btnCancelar2.UseVisualStyleBackColor = True
      '
      'Label30
      '
      Me.Label30.AutoSize = True
      Me.Label30.Location = New System.Drawing.Point(519, 283)
      Me.Label30.Name = "Label30"
      Me.Label30.Size = New System.Drawing.Size(19, 13)
      Me.Label30.TabIndex = 70
      Me.Label30.Text = "Nº"
      '
      'tbNroTarjD
      '
      Me.tbNroTarjD.Location = New System.Drawing.Point(544, 279)
      Me.tbNroTarjD.Name = "tbNroTarjD"
      Me.tbNroTarjD.Size = New System.Drawing.Size(107, 20)
      Me.tbNroTarjD.TabIndex = 69
      '
      'cboTarjetaD
      '
      Me.cboTarjetaD.FormattingEnabled = True
      Me.cboTarjetaD.Location = New System.Drawing.Point(285, 278)
      Me.cboTarjetaD.Name = "cboTarjetaD"
      Me.cboTarjetaD.Size = New System.Drawing.Size(223, 21)
      Me.cboTarjetaD.TabIndex = 68
      '
      'Label29
      '
      Me.Label29.AutoSize = True
      Me.Label29.Location = New System.Drawing.Point(519, 234)
      Me.Label29.Name = "Label29"
      Me.Label29.Size = New System.Drawing.Size(19, 13)
      Me.Label29.TabIndex = 67
      Me.Label29.Text = "Nº"
      '
      'tbNroTarjC
      '
      Me.tbNroTarjC.Location = New System.Drawing.Point(544, 230)
      Me.tbNroTarjC.Name = "tbNroTarjC"
      Me.tbNroTarjC.Size = New System.Drawing.Size(107, 20)
      Me.tbNroTarjC.TabIndex = 66
      '
      'cboTarjetaC
      '
      Me.cboTarjetaC.FormattingEnabled = True
      Me.cboTarjetaC.Location = New System.Drawing.Point(285, 229)
      Me.cboTarjetaC.Name = "cboTarjetaC"
      Me.cboTarjetaC.Size = New System.Drawing.Size(223, 21)
      Me.cboTarjetaC.TabIndex = 65
      '
      'btnCheques
      '
      Me.btnCheques.Location = New System.Drawing.Point(285, 181)
      Me.btnCheques.Name = "btnCheques"
      Me.btnCheques.Size = New System.Drawing.Size(75, 23)
      Me.btnCheques.TabIndex = 64
      Me.btnCheques.Text = "Cheques"
      Me.btnCheques.UseVisualStyleBackColor = True
      '
      'Label28
      '
      Me.Label28.AutoSize = True
      Me.Label28.Location = New System.Drawing.Point(39, 325)
      Me.Label28.Name = "Label28"
      Me.Label28.Size = New System.Drawing.Size(91, 13)
      Me.Label28.TabIndex = 63
      Me.Label28.Text = "Detalle del Cobro:"
      '
      'tbDetCobro
      '
      Me.tbDetCobro.Location = New System.Drawing.Point(137, 322)
      Me.tbDetCobro.Multiline = True
      Me.tbDetCobro.Name = "tbDetCobro"
      Me.tbDetCobro.Size = New System.Drawing.Size(371, 53)
      Me.tbDetCobro.TabIndex = 62
      '
      'Label27
      '
      Me.Label27.AutoSize = True
      Me.Label27.Location = New System.Drawing.Point(39, 281)
      Me.Label27.Name = "Label27"
      Me.Label27.Size = New System.Drawing.Size(83, 13)
      Me.Label27.TabIndex = 61
      Me.Label27.Text = "Tarjeta Débito $"
      '
      'tbTarjetaD
      '
      Me.tbTarjetaD.Location = New System.Drawing.Point(137, 278)
      Me.tbTarjetaD.Name = "tbTarjetaD"
      Me.tbTarjetaD.Size = New System.Drawing.Size(107, 20)
      Me.tbTarjetaD.TabIndex = 60
      '
      'Label26
      '
      Me.Label26.AutoSize = True
      Me.Label26.Location = New System.Drawing.Point(39, 232)
      Me.Label26.Name = "Label26"
      Me.Label26.Size = New System.Drawing.Size(85, 13)
      Me.Label26.TabIndex = 59
      Me.Label26.Text = "Tarjeta Crédito $"
      '
      'tbTarjetaC
      '
      Me.tbTarjetaC.Location = New System.Drawing.Point(137, 229)
      Me.tbTarjetaC.Name = "tbTarjetaC"
      Me.tbTarjetaC.Size = New System.Drawing.Size(107, 20)
      Me.tbTarjetaC.TabIndex = 58
      '
      'Label25
      '
      Me.Label25.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label25.AutoSize = True
      Me.Label25.Location = New System.Drawing.Point(39, 186)
      Me.Label25.Name = "Label25"
      Me.Label25.Size = New System.Drawing.Size(58, 13)
      Me.Label25.TabIndex = 57
      Me.Label25.Text = "Cheques $"
      '
      'tbCheques
      '
      Me.tbCheques.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tbCheques.BackColor = System.Drawing.Color.LightGoldenrodYellow
      Me.tbCheques.Enabled = False
      Me.tbCheques.Location = New System.Drawing.Point(137, 183)
      Me.tbCheques.Name = "tbCheques"
      Me.tbCheques.Size = New System.Drawing.Size(107, 20)
      Me.tbCheques.TabIndex = 56
      '
      'Label24
      '
      Me.Label24.AutoSize = True
      Me.Label24.Location = New System.Drawing.Point(39, 138)
      Me.Label24.Name = "Label24"
      Me.Label24.Size = New System.Drawing.Size(55, 13)
      Me.Label24.TabIndex = 55
      Me.Label24.Text = "Efectivo $"
      '
      'tbEfectivo
      '
      Me.tbEfectivo.Location = New System.Drawing.Point(137, 135)
      Me.tbEfectivo.Name = "tbEfectivo"
      Me.tbEfectivo.Size = New System.Drawing.Size(107, 20)
      Me.tbEfectivo.TabIndex = 54
      '
      'Label23
      '
      Me.Label23.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label23.AutoSize = True
      Me.Label23.Location = New System.Drawing.Point(39, 59)
      Me.Label23.Name = "Label23"
      Me.Label23.Size = New System.Drawing.Size(40, 13)
      Me.Label23.TabIndex = 53
      Me.Label23.Text = "Total $"
      '
      'tbTotal2
      '
      Me.tbTotal2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tbTotal2.BackColor = System.Drawing.Color.LightGoldenrodYellow
      Me.tbTotal2.Enabled = False
      Me.tbTotal2.Location = New System.Drawing.Point(137, 56)
      Me.tbTotal2.Name = "tbTotal2"
      Me.tbTotal2.Size = New System.Drawing.Size(107, 20)
      Me.tbTotal2.TabIndex = 52
      '
      'Label7
      '
      Me.Label7.AutoSize = True
      Me.Label7.Location = New System.Drawing.Point(39, 98)
      Me.Label7.Name = "Label7"
      Me.Label7.Size = New System.Drawing.Size(82, 13)
      Me.Label7.TabIndex = 11
      Me.Label7.Text = "Forma de Pago:"
      '
      'cboFormaPago
      '
      Me.cboFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboFormaPago.FormattingEnabled = True
      Me.cboFormaPago.Location = New System.Drawing.Point(137, 95)
      Me.cboFormaPago.Name = "cboFormaPago"
      Me.cboFormaPago.Size = New System.Drawing.Size(123, 21)
      Me.cboFormaPago.TabIndex = 12
      '
      'optPropietarios
      '
      Me.optPropietarios.AutoSize = True
      Me.optPropietarios.Location = New System.Drawing.Point(158, 11)
      Me.optPropietarios.Name = "optPropietarios"
      Me.optPropietarios.Size = New System.Drawing.Size(80, 17)
      Me.optPropietarios.TabIndex = 67
      Me.optPropietarios.Text = "&Propietarios"
      Me.optPropietarios.UseVisualStyleBackColor = True
      '
      'optInquilinos
      '
      Me.optInquilinos.AutoSize = True
      Me.optInquilinos.Location = New System.Drawing.Point(244, 11)
      Me.optInquilinos.Name = "optInquilinos"
      Me.optInquilinos.Size = New System.Drawing.Size(69, 17)
      Me.optInquilinos.TabIndex = 68
      Me.optInquilinos.Text = "&Inquilinos"
      Me.optInquilinos.UseVisualStyleBackColor = True
      '
      'optClientes
      '
      Me.optClientes.AutoSize = True
      Me.optClientes.Checked = True
      Me.optClientes.Location = New System.Drawing.Point(10, 10)
      Me.optClientes.Name = "optClientes"
      Me.optClientes.Size = New System.Drawing.Size(62, 17)
      Me.optClientes.TabIndex = 69
      Me.optClientes.TabStop = True
      Me.optClientes.Text = "&Clientes"
      Me.optClientes.UseVisualStyleBackColor = True
      '
      'FrmVentasAM
      '
      Me.AcceptButton = Me.btnGuardar
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me.btnSalir
      Me.ClientSize = New System.Drawing.Size(842, 600)
      Me.Controls.Add(Me.TabControl1)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.KeyPreview = True
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "FrmVentasAM"
      Me.Text = "Venta"
      Me.TabControl1.ResumeLayout(False)
      Me.TabPage1.ResumeLayout(False)
      Me.TabPage1.PerformLayout()
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.TabPage2.ResumeLayout(False)
      Me.TabPage2.PerformLayout()
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
   Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
   Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents cboLetra As System.Windows.Forms.ComboBox
   Friend WithEvents chkCasual As System.Windows.Forms.CheckBox
   Friend WithEvents cboTipoComp As System.Windows.Forms.ComboBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents cboCliente As System.Windows.Forms.ComboBox
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents cboTipoIva As System.Windows.Forms.ComboBox
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents cboCondVenta As System.Windows.Forms.ComboBox
   Friend WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents cboTransporte As System.Windows.Forms.ComboBox
   Friend WithEvents Label7 As System.Windows.Forms.Label
   Friend WithEvents cboFormaPago As System.Windows.Forms.ComboBox
   Friend WithEvents tbCuit As System.Windows.Forms.MaskedTextBox
   Friend WithEvents btnSalir As System.Windows.Forms.Button
   Friend WithEvents Label9 As System.Windows.Forms.Label
   Friend WithEvents tbNumero As System.Windows.Forms.TextBox
   Friend WithEvents tbSucursal As System.Windows.Forms.TextBox
   Friend WithEvents tbFecVenc As System.Windows.Forms.DateTimePicker
   Friend WithEvents Label11 As System.Windows.Forms.Label
   Friend WithEvents tbFecha As System.Windows.Forms.DateTimePicker
   Friend WithEvents Label10 As System.Windows.Forms.Label
   Friend WithEvents btnAceptar As System.Windows.Forms.Button
   Friend WithEvents cboEntrega As System.Windows.Forms.ComboBox
   Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
   Friend WithEvents Label17 As System.Windows.Forms.Label
   Friend WithEvents tbNoGravado As System.Windows.Forms.TextBox
   Friend WithEvents Label16 As System.Windows.Forms.Label
   Friend WithEvents tbGravado As System.Windows.Forms.TextBox
   Friend WithEvents Label15 As System.Windows.Forms.Label
   Friend WithEvents Label14 As System.Windows.Forms.Label
   Friend WithEvents tbBonificacion As System.Windows.Forms.TextBox
   Friend WithEvents tbSubtotal As System.Windows.Forms.TextBox
   Friend WithEvents Label20 As System.Windows.Forms.Label
   Friend WithEvents tbTotal As System.Windows.Forms.TextBox
   Friend WithEvents Label21 As System.Windows.Forms.Label
   Friend WithEvents tbExento As System.Windows.Forms.TextBox
   Friend WithEvents lblIva2 As System.Windows.Forms.Label
   Friend WithEvents tbIva2 As System.Windows.Forms.TextBox
   Friend WithEvents lblIva1 As System.Windows.Forms.Label
   Friend WithEvents tbIva1 As System.Windows.Forms.TextBox
   Friend WithEvents btnSiguiente As System.Windows.Forms.Button
   Friend WithEvents btnGuardar As System.Windows.Forms.Button
   Friend WithEvents btnCancelar As System.Windows.Forms.Button
   Friend WithEvents Label22 As System.Windows.Forms.Label
   Friend WithEvents tbObserv As System.Windows.Forms.TextBox
   Friend WithEvents Label23 As System.Windows.Forms.Label
   Friend WithEvents tbTotal2 As System.Windows.Forms.TextBox
   Friend WithEvents cboTarjetaC As System.Windows.Forms.ComboBox
   Friend WithEvents btnCheques As System.Windows.Forms.Button
   Friend WithEvents Label28 As System.Windows.Forms.Label
   Friend WithEvents tbDetCobro As System.Windows.Forms.TextBox
   Friend WithEvents Label27 As System.Windows.Forms.Label
   Friend WithEvents tbTarjetaD As System.Windows.Forms.TextBox
   Friend WithEvents Label26 As System.Windows.Forms.Label
   Friend WithEvents tbTarjetaC As System.Windows.Forms.TextBox
   Friend WithEvents Label25 As System.Windows.Forms.Label
   Friend WithEvents tbCheques As System.Windows.Forms.TextBox
   Friend WithEvents Label24 As System.Windows.Forms.Label
   Friend WithEvents tbEfectivo As System.Windows.Forms.TextBox
   Friend WithEvents Label30 As System.Windows.Forms.Label
   Friend WithEvents tbNroTarjD As System.Windows.Forms.TextBox
   Friend WithEvents cboTarjetaD As System.Windows.Forms.ComboBox
   Friend WithEvents Label29 As System.Windows.Forms.Label
   Friend WithEvents tbNroTarjC As System.Windows.Forms.TextBox
   Friend WithEvents btnAnterior As System.Windows.Forms.Button
   Friend WithEvents btnGuardar2 As System.Windows.Forms.Button
   Friend WithEvents btnCancelar2 As System.Windows.Forms.Button
   Friend WithEvents btnBaja As System.Windows.Forms.Button
   Friend WithEvents btnModif As System.Windows.Forms.Button
   Friend WithEvents btnAltaServ As System.Windows.Forms.Button
   Friend WithEvents btnRecalc As System.Windows.Forms.Button
   Friend WithEvents Label35 As System.Windows.Forms.Label
   Friend WithEvents Label34 As System.Windows.Forms.Label
   Friend WithEvents Label32 As System.Windows.Forms.Label
   Friend WithEvents Label31 As System.Windows.Forms.Label
   Friend WithEvents optInquilinos As RadioButton
   Friend WithEvents optPropietarios As RadioButton
   Friend WithEvents optClientes As RadioButton
End Class
