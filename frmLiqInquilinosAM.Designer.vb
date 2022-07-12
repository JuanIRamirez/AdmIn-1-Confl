<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLiqInquilinosAM
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
      Me.cbInquilino = New System.Windows.Forms.ComboBox()
      Me.Label13 = New System.Windows.Forms.Label()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.cbPropiedad = New System.Windows.Forms.ComboBox()
      Me.tbPropietario = New System.Windows.Forms.TextBox()
      Me.Label11 = New System.Windows.Forms.Label()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.cbPeriodo = New System.Windows.Forms.ComboBox()
      Me.tbSucursal = New System.Windows.Forms.TextBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.lblLetra = New System.Windows.Forms.Label()
      Me.tbNumero = New System.Windows.Forms.TextBox()
      Me.cmdSalir = New System.Windows.Forms.Button()
      Me.cmdAceptar = New System.Windows.Forms.Button()
      Me.DataGridView1 = New System.Windows.Forms.DataGridView()
      Me.gbPago = New System.Windows.Forms.GroupBox()
      Me.Label14 = New System.Windows.Forms.Label()
      Me.tbRetencNro = New System.Windows.Forms.TextBox()
      Me.Label12 = New System.Windows.Forms.Label()
      Me.Label10 = New System.Windows.Forms.Label()
      Me.tbTotal = New System.Windows.Forms.TextBox()
      Me.Label15 = New System.Windows.Forms.Label()
      Me.tbRetencion = New System.Windows.Forms.TextBox()
      Me.tbSaldo = New System.Windows.Forms.TextBox()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.tbTotCobro = New System.Windows.Forms.TextBox()
      Me.tbTransferencia = New System.Windows.Forms.TextBox()
      Me.tbCheques = New System.Windows.Forms.TextBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.cmdIngCheques = New System.Windows.Forms.Button()
      Me.cmdTransferencia = New System.Windows.Forms.Button()
      Me.tbEfectivo = New System.Windows.Forms.TextBox()
      Me.Label23 = New System.Windows.Forms.Label()
      Me.TextBox1 = New System.Windows.Forms.TextBox()
      Me.cmdCancelar = New System.Windows.Forms.Button()
      Me.cmdPendiente = New System.Windows.Forms.Button()
      Me.cmdGenerar = New System.Windows.Forms.Button()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.tbTotConc = New System.Windows.Forms.TextBox()
      Me.Label7 = New System.Windows.Forms.Label()
      Me.tbSdoAnt = New System.Windows.Forms.TextBox()
      Me.gbIntereses = New System.Windows.Forms.GroupBox()
      Me.optAdmin = New System.Windows.Forms.RadioButton()
      Me.optPropiet = New System.Windows.Forms.RadioButton()
      Me.tbFecAnt = New System.Windows.Forms.DateTimePicker()
      Me.Label22 = New System.Windows.Forms.Label()
      Me.Label9 = New System.Windows.Forms.Label()
      Me.tbIntereses = New System.Windows.Forms.TextBox()
      Me.tbIntDiario = New System.Windows.Forms.TextBox()
      Me.Label8 = New System.Windows.Forms.Label()
      Me.cmdCancSeña = New System.Windows.Forms.Button()
      Me.lblObserv = New System.Windows.Forms.Label()
      Me.tbDetalle = New System.Windows.Forms.TextBox()
      Me.lblAdelProp = New System.Windows.Forms.Label()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbPago.SuspendLayout()
        Me.gbIntereses.SuspendLayout()
        Me.SuspendLayout()
        '
        'cbInquilino
        '
        Me.cbInquilino.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbInquilino.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbInquilino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbInquilino.FormattingEnabled = True
        Me.cbInquilino.Location = New System.Drawing.Point(60, 12)
        Me.cbInquilino.Name = "cbInquilino"
        Me.cbInquilino.Size = New System.Drawing.Size(356, 21)
        Me.cbInquilino.TabIndex = 0
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(8, 15)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(49, 13)
        Me.Label13.TabIndex = 70
        Me.Label13.Text = "Inquilino:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(422, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(58, 13)
        Me.Label6.TabIndex = 73
        Me.Label6.Text = "Propiedad:"
        '
        'cbPropiedad
        '
        Me.cbPropiedad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPropiedad.FormattingEnabled = True
        Me.cbPropiedad.Location = New System.Drawing.Point(486, 12)
        Me.cbPropiedad.Name = "cbPropiedad"
        Me.cbPropiedad.Size = New System.Drawing.Size(359, 21)
        Me.cbPropiedad.TabIndex = 1
        '
        'tbPropietario
        '
        Me.tbPropietario.Enabled = False
        Me.tbPropietario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbPropietario.Location = New System.Drawing.Point(76, 43)
        Me.tbPropietario.Name = "tbPropietario"
        Me.tbPropietario.Size = New System.Drawing.Size(317, 20)
        Me.tbPropietario.TabIndex = 2
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(8, 46)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(60, 13)
        Me.Label11.TabIndex = 83
        Me.Label11.Text = "Propietario:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(399, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 86
        Me.Label2.Text = "Período:"
        '
        'cbPeriodo
        '
        Me.cbPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPeriodo.FormattingEnabled = True
        Me.cbPeriodo.Location = New System.Drawing.Point(453, 43)
        Me.cbPeriodo.Name = "cbPeriodo"
        Me.cbPeriodo.Size = New System.Drawing.Size(81, 21)
        Me.cbPeriodo.TabIndex = 3
        '
        'tbSucursal
        '
        Me.tbSucursal.Enabled = False
        Me.tbSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbSucursal.Location = New System.Drawing.Point(634, 43)
        Me.tbSucursal.Name = "tbSucursal"
        Me.tbSucursal.Size = New System.Drawing.Size(39, 20)
        Me.tbSucursal.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(559, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 87
        Me.Label1.Text = "Recibo:"
        '
        'lblLetra
        '
        Me.lblLetra.AutoSize = True
        Me.lblLetra.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLetra.Location = New System.Drawing.Point(609, 46)
        Me.lblLetra.Name = "lblLetra"
        Me.lblLetra.Size = New System.Drawing.Size(15, 13)
        Me.lblLetra.TabIndex = 89
        Me.lblLetra.Text = "X"
        '
        'tbNumero
        '
        Me.tbNumero.Enabled = False
        Me.tbNumero.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbNumero.Location = New System.Drawing.Point(679, 43)
        Me.tbNumero.Name = "tbNumero"
        Me.tbNumero.Size = New System.Drawing.Size(77, 20)
        Me.tbNumero.TabIndex = 5
        '
        'cmdSalir
        '
        Me.cmdSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSalir.Location = New System.Drawing.Point(766, 592)
        Me.cmdSalir.Name = "cmdSalir"
        Me.cmdSalir.Size = New System.Drawing.Size(82, 27)
        Me.cmdSalir.TabIndex = 29
        Me.cmdSalir.Text = "&Salir"
        Me.cmdSalir.UseVisualStyleBackColor = True
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Location = New System.Drawing.Point(780, 39)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(66, 27)
        Me.cmdAceptar.TabIndex = 6
        Me.cmdAceptar.Text = "&Aceptar"
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(11, 72)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowTemplate.ReadOnly = True
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(836, 366)
        Me.DataGridView1.TabIndex = 93
        '
        'gbPago
        '
        Me.gbPago.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gbPago.Controls.Add(Me.Label14)
        Me.gbPago.Controls.Add(Me.tbRetencNro)
        Me.gbPago.Controls.Add(Me.Label12)
        Me.gbPago.Controls.Add(Me.Label10)
        Me.gbPago.Controls.Add(Me.tbTotal)
        Me.gbPago.Controls.Add(Me.Label15)
        Me.gbPago.Controls.Add(Me.tbRetencion)
        Me.gbPago.Controls.Add(Me.tbSaldo)
        Me.gbPago.Controls.Add(Me.Label4)
        Me.gbPago.Controls.Add(Me.tbTotCobro)
        Me.gbPago.Controls.Add(Me.tbTransferencia)
        Me.gbPago.Controls.Add(Me.tbCheques)
        Me.gbPago.Controls.Add(Me.Label3)
        Me.gbPago.Controls.Add(Me.cmdIngCheques)
        Me.gbPago.Controls.Add(Me.cmdTransferencia)
        Me.gbPago.Controls.Add(Me.tbEfectivo)
        Me.gbPago.Controls.Add(Me.Label23)
        Me.gbPago.Controls.Add(Me.TextBox1)
        Me.gbPago.Location = New System.Drawing.Point(430, 444)
        Me.gbPago.Name = "gbPago"
        Me.gbPago.Size = New System.Drawing.Size(326, 175)
        Me.gbPago.TabIndex = 16
        Me.gbPago.TabStop = False
        Me.gbPago.Text = "Cobro"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(209, 123)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(13, 13)
        Me.Label14.TabIndex = 64
        Me.Label14.Text = "$"
        '
        'tbRetencNro
        '
        Me.tbRetencNro.Location = New System.Drawing.Point(140, 120)
        Me.tbRetencNro.Name = "tbRetencNro"
        Me.tbRetencNro.Size = New System.Drawing.Size(63, 20)
        Me.tbRetencNro.TabIndex = 22
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(63, 123)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(71, 13)
        Me.Label12.TabIndex = 62
        Me.Label12.Text = "Retención Nº"
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(137, 20)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(83, 13)
        Me.Label10.TabIndex = 110
        Me.Label10.Text = "Total a Cobrar $"
        '
        'tbTotal
        '
        Me.tbTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tbTotal.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.tbTotal.Enabled = False
        Me.tbTotal.Location = New System.Drawing.Point(228, 17)
        Me.tbTotal.Name = "tbTotal"
        Me.tbTotal.Size = New System.Drawing.Size(86, 20)
        Me.tbTotal.TabIndex = 16
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(179, 149)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(43, 13)
        Me.Label15.TabIndex = 112
        Me.Label15.Text = "Saldo $"
        '
        'tbRetencion
        '
        Me.tbRetencion.Location = New System.Drawing.Point(228, 120)
        Me.tbRetencion.Name = "tbRetencion"
        Me.tbRetencion.Size = New System.Drawing.Size(86, 20)
        Me.tbRetencion.TabIndex = 23
        '
        'tbSaldo
        '
        Me.tbSaldo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tbSaldo.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.tbSaldo.Enabled = False
        Me.tbSaldo.Location = New System.Drawing.Point(228, 146)
        Me.tbSaldo.Name = "tbSaldo"
        Me.tbSaldo.Size = New System.Drawing.Size(86, 20)
        Me.tbSaldo.TabIndex = 25
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 149)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 13)
        Me.Label4.TabIndex = 60
        Me.Label4.Text = "Total cobro $"
        '
        'tbTotCobro
        '
        Me.tbTotCobro.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.tbTotCobro.Enabled = False
        Me.tbTotCobro.Location = New System.Drawing.Point(82, 146)
        Me.tbTotCobro.Name = "tbTotCobro"
        Me.tbTotCobro.Size = New System.Drawing.Size(86, 20)
        Me.tbTotCobro.TabIndex = 24
        '
        'tbTransferencia
        '
        Me.tbTransferencia.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.tbTransferencia.Enabled = False
        Me.tbTransferencia.Location = New System.Drawing.Point(228, 93)
        Me.tbTransferencia.Name = "tbTransferencia"
        Me.tbTransferencia.Size = New System.Drawing.Size(86, 20)
        Me.tbTransferencia.TabIndex = 21
        '
        'tbCheques
        '
        Me.tbCheques.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.tbCheques.Enabled = False
        Me.tbCheques.Location = New System.Drawing.Point(228, 67)
        Me.tbCheques.Name = "tbCheques"
        Me.tbCheques.Size = New System.Drawing.Size(86, 20)
        Me.tbCheques.TabIndex = 19
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(165, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 50
        Me.Label3.Text = "Efectivo $"
        '
        'cmdIngCheques
        '
        Me.cmdIngCheques.Location = New System.Drawing.Point(122, 67)
        Me.cmdIngCheques.Name = "cmdIngCheques"
        Me.cmdIngCheques.Size = New System.Drawing.Size(98, 20)
        Me.cmdIngCheques.TabIndex = 18
        Me.cmdIngCheques.Text = "Che&ques"
        Me.cmdIngCheques.UseVisualStyleBackColor = True
        '
        'cmdTransferencia
        '
        Me.cmdTransferencia.Location = New System.Drawing.Point(122, 92)
        Me.cmdTransferencia.Name = "cmdTransferencia"
        Me.cmdTransferencia.Size = New System.Drawing.Size(98, 20)
        Me.cmdTransferencia.TabIndex = 20
        Me.cmdTransferencia.Text = "&Transferencia"
        Me.cmdTransferencia.UseVisualStyleBackColor = True
        '
        'tbEfectivo
        '
        Me.tbEfectivo.Location = New System.Drawing.Point(228, 42)
        Me.tbEfectivo.Name = "tbEfectivo"
        Me.tbEfectivo.Size = New System.Drawing.Size(86, 20)
        Me.tbEfectivo.TabIndex = 17
        '
        'Label23
        '
        Me.Label23.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(702, 14)
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
        Me.TextBox1.Location = New System.Drawing.Point(763, 11)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(71, 20)
        Me.TextBox1.TabIndex = 57
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancelar.Location = New System.Drawing.Point(764, 540)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(83, 30)
        Me.cmdCancelar.TabIndex = 28
        Me.cmdCancelar.Text = "&Cancelar"
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'cmdPendiente
        '
        Me.cmdPendiente.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPendiente.Location = New System.Drawing.Point(764, 494)
        Me.cmdPendiente.Name = "cmdPendiente"
        Me.cmdPendiente.Size = New System.Drawing.Size(83, 35)
        Me.cmdPendiente.TabIndex = 27
        Me.cmdPendiente.Text = "&Pendiente"
        Me.cmdPendiente.UseVisualStyleBackColor = True
        '
        'cmdGenerar
        '
        Me.cmdGenerar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdGenerar.Location = New System.Drawing.Point(764, 451)
        Me.cmdGenerar.Name = "cmdGenerar"
        Me.cmdGenerar.Size = New System.Drawing.Size(83, 39)
        Me.cmdGenerar.TabIndex = 26
        Me.cmdGenerar.Text = "&Generar"
        Me.cmdGenerar.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 461)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 13)
        Me.Label5.TabIndex = 99
        Me.Label5.Text = "Subtotal $"
        '
        'tbTotConc
        '
        Me.tbTotConc.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tbTotConc.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.tbTotConc.Enabled = False
        Me.tbTotConc.Location = New System.Drawing.Point(66, 457)
        Me.tbTotConc.Name = "tbTotConc"
        Me.tbTotConc.Size = New System.Drawing.Size(100, 20)
        Me.tbTotConc.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 491)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 13)
        Me.Label7.TabIndex = 101
        Me.Label7.Text = "Saldo Ant. $"
        '
        'tbSdoAnt
        '
        Me.tbSdoAnt.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tbSdoAnt.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.tbSdoAnt.Enabled = False
        Me.tbSdoAnt.Location = New System.Drawing.Point(76, 488)
        Me.tbSdoAnt.Name = "tbSdoAnt"
        Me.tbSdoAnt.Size = New System.Drawing.Size(90, 20)
        Me.tbSdoAnt.TabIndex = 8
        '
        'gbIntereses
        '
        Me.gbIntereses.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gbIntereses.Controls.Add(Me.optAdmin)
        Me.gbIntereses.Controls.Add(Me.optPropiet)
        Me.gbIntereses.Controls.Add(Me.tbFecAnt)
        Me.gbIntereses.Controls.Add(Me.Label22)
        Me.gbIntereses.Controls.Add(Me.Label9)
        Me.gbIntereses.Controls.Add(Me.tbIntereses)
        Me.gbIntereses.Controls.Add(Me.tbIntDiario)
        Me.gbIntereses.Controls.Add(Me.Label8)
        Me.gbIntereses.Location = New System.Drawing.Point(172, 444)
        Me.gbIntereses.Name = "gbIntereses"
        Me.gbIntereses.Size = New System.Drawing.Size(252, 100)
        Me.gbIntereses.TabIndex = 10
        Me.gbIntereses.TabStop = False
        Me.gbIntereses.Text = "Intereses"
        '
        'optAdmin
        '
        Me.optAdmin.AutoSize = True
        Me.optAdmin.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.optAdmin.Location = New System.Drawing.Point(137, 70)
        Me.optAdmin.Name = "optAdmin"
        Me.optAdmin.Size = New System.Drawing.Size(102, 17)
        Me.optAdmin.TabIndex = 14
        Me.optAdmin.Text = "a Administración"
        Me.optAdmin.UseVisualStyleBackColor = True
        '
        'optPropiet
        '
        Me.optPropiet.AutoSize = True
        Me.optPropiet.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.optPropiet.Checked = True
        Me.optPropiet.Location = New System.Drawing.Point(155, 45)
        Me.optPropiet.Name = "optPropiet"
        Me.optPropiet.Size = New System.Drawing.Size(84, 17)
        Me.optPropiet.TabIndex = 13
        Me.optPropiet.TabStop = True
        Me.optPropiet.Text = "a Propietario"
        Me.optPropiet.UseVisualStyleBackColor = True
        '
        'tbFecAnt
        '
        Me.tbFecAnt.Enabled = False
        Me.tbFecAnt.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.tbFecAnt.Location = New System.Drawing.Point(43, 43)
        Me.tbFecAnt.Name = "tbFecAnt"
        Me.tbFecAnt.Size = New System.Drawing.Size(88, 20)
        Me.tbFecAnt.TabIndex = 11
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(6, 47)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(19, 13)
        Me.Label22.TabIndex = 112
        Me.Label22.Text = "Al:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 72)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 13)
        Me.Label9.TabIndex = 109
        Me.Label9.Text = "Interes $"
        '
        'tbIntereses
        '
        Me.tbIntereses.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.tbIntereses.Enabled = False
        Me.tbIntereses.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbIntereses.Location = New System.Drawing.Point(60, 69)
        Me.tbIntereses.Name = "tbIntereses"
        Me.tbIntereses.Size = New System.Drawing.Size(71, 20)
        Me.tbIntereses.TabIndex = 12
        '
        'tbIntDiario
        '
        Me.tbIntDiario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbIntDiario.Location = New System.Drawing.Point(95, 17)
        Me.tbIntDiario.Name = "tbIntDiario"
        Me.tbIntDiario.Size = New System.Drawing.Size(36, 20)
        Me.tbIntDiario.TabIndex = 10
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 20)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(63, 13)
        Me.Label8.TabIndex = 106
        Me.Label8.Text = "Int. Diario %"
        '
        'cmdCancSeña
        '
        Me.cmdCancSeña.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdCancSeña.Enabled = False
        Me.cmdCancSeña.Location = New System.Drawing.Point(11, 513)
        Me.cmdCancSeña.Name = "cmdCancSeña"
        Me.cmdCancSeña.Size = New System.Drawing.Size(85, 23)
        Me.cmdCancSeña.TabIndex = 8
        Me.cmdCancSeña.Text = "Canc. &Seña/s"
        Me.cmdCancSeña.UseVisualStyleBackColor = True
        '
        'lblObserv
        '
        Me.lblObserv.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblObserv.AutoSize = True
        Me.lblObserv.Location = New System.Drawing.Point(8, 570)
        Me.lblObserv.Name = "lblObserv"
        Me.lblObserv.Size = New System.Drawing.Size(47, 13)
        Me.lblObserv.TabIndex = 115
        Me.lblObserv.Text = "Observ.:"
        '
        'tbDetalle
        '
        Me.tbDetalle.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tbDetalle.Location = New System.Drawing.Point(60, 564)
        Me.tbDetalle.Multiline = True
        Me.tbDetalle.Name = "tbDetalle"
        Me.tbDetalle.Size = New System.Drawing.Size(363, 55)
        Me.tbDetalle.TabIndex = 15
        '
        'lblAdelProp
        '
        Me.lblAdelProp.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblAdelProp.AutoSize = True
        Me.lblAdelProp.Location = New System.Drawing.Point(12, 543)
        Me.lblAdelProp.Name = "lblAdelProp"
        Me.lblAdelProp.Size = New System.Drawing.Size(10, 13)
        Me.lblAdelProp.TabIndex = 116
        Me.lblAdelProp.Text = "."
        '
        'frmLiqInquilinosAM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdSalir
        Me.ClientSize = New System.Drawing.Size(860, 625)
        Me.Controls.Add(Me.lblAdelProp)
        Me.Controls.Add(Me.lblObserv)
        Me.Controls.Add(Me.tbDetalle)
        Me.Controls.Add(Me.cmdCancSeña)
        Me.Controls.Add(Me.gbIntereses)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.tbSdoAnt)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.tbTotConc)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdPendiente)
        Me.Controls.Add(Me.cmdGenerar)
        Me.Controls.Add(Me.gbPago)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.cmdSalir)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Controls.Add(Me.tbNumero)
        Me.Controls.Add(Me.lblLetra)
        Me.Controls.Add(Me.tbSucursal)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cbPeriodo)
        Me.Controls.Add(Me.tbPropietario)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cbPropiedad)
        Me.Controls.Add(Me.cbInquilino)
        Me.Controls.Add(Me.Label13)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLiqInquilinosAM"
        Me.Text = "Recibo Inquilino"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbPago.ResumeLayout(False)
        Me.gbPago.PerformLayout()
        Me.gbIntereses.ResumeLayout(False)
        Me.gbIntereses.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cbInquilino As System.Windows.Forms.ComboBox
   Friend WithEvents Label13 As System.Windows.Forms.Label
   Friend WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents cbPropiedad As System.Windows.Forms.ComboBox
   Friend WithEvents tbPropietario As System.Windows.Forms.TextBox
   Friend WithEvents Label11 As System.Windows.Forms.Label
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents cbPeriodo As System.Windows.Forms.ComboBox
   Friend WithEvents tbSucursal As System.Windows.Forms.TextBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents lblLetra As System.Windows.Forms.Label
   Friend WithEvents tbNumero As System.Windows.Forms.TextBox
   Friend WithEvents cmdSalir As System.Windows.Forms.Button
   Friend WithEvents cmdAceptar As System.Windows.Forms.Button
   Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
   Friend WithEvents gbPago As System.Windows.Forms.GroupBox
   Friend WithEvents tbTransferencia As System.Windows.Forms.TextBox
   Friend WithEvents tbCheques As System.Windows.Forms.TextBox
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents cmdIngCheques As System.Windows.Forms.Button
   Friend WithEvents cmdTransferencia As System.Windows.Forms.Button
   Friend WithEvents tbEfectivo As System.Windows.Forms.TextBox
   Friend WithEvents Label23 As System.Windows.Forms.Label
   Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents tbTotCobro As System.Windows.Forms.TextBox
   Friend WithEvents cmdCancelar As System.Windows.Forms.Button
   Friend WithEvents cmdPendiente As System.Windows.Forms.Button
   Friend WithEvents cmdGenerar As System.Windows.Forms.Button
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents tbTotConc As System.Windows.Forms.TextBox
   Friend WithEvents Label7 As System.Windows.Forms.Label
   Friend WithEvents tbSdoAnt As System.Windows.Forms.TextBox
   Friend WithEvents gbIntereses As System.Windows.Forms.GroupBox
   Friend WithEvents tbFecAnt As System.Windows.Forms.DateTimePicker
   Friend WithEvents Label22 As System.Windows.Forms.Label
   Friend WithEvents Label9 As System.Windows.Forms.Label
   Friend WithEvents tbIntereses As System.Windows.Forms.TextBox
   Friend WithEvents tbIntDiario As System.Windows.Forms.TextBox
   Friend WithEvents Label8 As System.Windows.Forms.Label
   Friend WithEvents Label10 As System.Windows.Forms.Label
   Friend WithEvents tbTotal As System.Windows.Forms.TextBox
   Friend WithEvents optAdmin As System.Windows.Forms.RadioButton
   Friend WithEvents optPropiet As System.Windows.Forms.RadioButton
   Friend WithEvents Label12 As System.Windows.Forms.Label
   Friend WithEvents tbRetencion As System.Windows.Forms.TextBox
   Friend WithEvents tbRetencNro As System.Windows.Forms.TextBox
   Friend WithEvents Label14 As System.Windows.Forms.Label
   Friend WithEvents Label15 As System.Windows.Forms.Label
   Friend WithEvents tbSaldo As System.Windows.Forms.TextBox
   Friend WithEvents cmdCancSeña As System.Windows.Forms.Button
   Friend WithEvents lblObserv As System.Windows.Forms.Label
   Friend WithEvents tbDetalle As System.Windows.Forms.TextBox
   Friend WithEvents lblAdelProp As System.Windows.Forms.Label
End Class
