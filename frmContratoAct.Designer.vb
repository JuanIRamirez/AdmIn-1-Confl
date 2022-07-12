<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmContratoAct
   Inherits System.Windows.Forms.Form

   'Form reemplaza a Dispose para limpiar la lista de componentes.
   <System.Diagnostics.DebuggerNonUserCode()>
   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      Try
         If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
         End If
      Finally
         MyBase.Dispose(disposing)
      End Try
   End Sub

   'Requerido por el Diseñador de Windows Forms
   Private components As System.ComponentModel.IContainer

   'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
   'Se puede modificar usando el Diseñador de Windows Forms.  
   'No lo modifique con el editor de código.
   <System.Diagnostics.DebuggerStepThrough()>
   Private Sub InitializeComponent()
      Me.tbContrato = New System.Windows.Forms.TextBox()
      Me.Label12 = New System.Windows.Forms.Label()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.Label9 = New System.Windows.Forms.Label()
      Me.Label13 = New System.Windows.Forms.Label()
      Me.tbPropietario = New System.Windows.Forms.TextBox()
      Me.tbPropiedad = New System.Windows.Forms.TextBox()
      Me.tbInquilino = New System.Windows.Forms.TextBox()
      Me.GroupBox4 = New System.Windows.Forms.GroupBox()
      Me.dtpHasta = New System.Windows.Forms.DateTimePicker()
      Me.dtpDesde = New System.Windows.Forms.DateTimePicker()
      Me.Label18 = New System.Windows.Forms.Label()
      Me.tbMeses = New System.Windows.Forms.TextBox()
      Me.Label16 = New System.Windows.Forms.Label()
      Me.Label15 = New System.Windows.Forms.Label()
      Me.dtFechaCtto = New System.Windows.Forms.DateTimePicker()
      Me.Label22 = New System.Windows.Forms.Label()
      Me.tbEscalon = New System.Windows.Forms.TextBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.tbEscMeses = New System.Windows.Forms.TextBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.lblIncrem = New System.Windows.Forms.Label()
      Me.tbEscIncr = New System.Windows.Forms.TextBox()
      Me.cmdAceptar = New System.Windows.Forms.Button()
      Me.cmdCancelar = New System.Windows.Forms.Button()
      Me.btnModif = New System.Windows.Forms.Button()
      Me.GroupBox1 = New System.Windows.Forms.GroupBox()
      Me.tbEscalonM = New System.Windows.Forms.TextBox()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.Label7 = New System.Windows.Forms.Label()
      Me.tbEscMesesM = New System.Windows.Forms.TextBox()
      Me.lblIncremm = New System.Windows.Forms.Label()
      Me.Label10 = New System.Windows.Forms.Label()
      Me.tbEscIncrM = New System.Windows.Forms.TextBox()
      Me.GroupBox2 = New System.Windows.Forms.GroupBox()
      Me.tbImpIva = New System.Windows.Forms.TextBox()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.tbImpAlq = New System.Windows.Forms.TextBox()
      Me.Label20 = New System.Windows.Forms.Label()
      Me.GroupBox4.SuspendLayout()
      Me.GroupBox1.SuspendLayout()
      Me.GroupBox2.SuspendLayout()
      Me.SuspendLayout()
      '
      'tbContrato
      '
      Me.tbContrato.BackColor = System.Drawing.SystemColors.Info
      Me.tbContrato.Enabled = False
      Me.tbContrato.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.tbContrato.Location = New System.Drawing.Point(87, 21)
      Me.tbContrato.MaxLength = 11
      Me.tbContrato.Name = "tbContrato"
      Me.tbContrato.Size = New System.Drawing.Size(94, 20)
      Me.tbContrato.TabIndex = 71
      Me.tbContrato.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label12
      '
      Me.Label12.AutoSize = True
      Me.Label12.Location = New System.Drawing.Point(19, 24)
      Me.Label12.Name = "Label12"
      Me.Label12.Size = New System.Drawing.Size(62, 13)
      Me.Label12.TabIndex = 72
      Me.Label12.Text = "Contrato N°"
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(21, 50)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(60, 13)
      Me.Label1.TabIndex = 74
      Me.Label1.Text = "Propietario:"
      '
      'Label9
      '
      Me.Label9.AutoSize = True
      Me.Label9.Location = New System.Drawing.Point(23, 77)
      Me.Label9.Name = "Label9"
      Me.Label9.Size = New System.Drawing.Size(58, 13)
      Me.Label9.TabIndex = 76
      Me.Label9.Text = "Propiedad:"
      '
      'Label13
      '
      Me.Label13.AutoSize = True
      Me.Label13.Location = New System.Drawing.Point(25, 104)
      Me.Label13.Name = "Label13"
      Me.Label13.Size = New System.Drawing.Size(49, 13)
      Me.Label13.TabIndex = 78
      Me.Label13.Text = "Inquilino:"
      '
      'tbPropietario
      '
      Me.tbPropietario.BackColor = System.Drawing.SystemColors.Info
      Me.tbPropietario.Enabled = False
      Me.tbPropietario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.tbPropietario.Location = New System.Drawing.Point(87, 47)
      Me.tbPropietario.MaxLength = 11
      Me.tbPropietario.Name = "tbPropietario"
      Me.tbPropietario.Size = New System.Drawing.Size(500, 20)
      Me.tbPropietario.TabIndex = 79
      '
      'tbPropiedad
      '
      Me.tbPropiedad.BackColor = System.Drawing.SystemColors.Info
      Me.tbPropiedad.Enabled = False
      Me.tbPropiedad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.tbPropiedad.Location = New System.Drawing.Point(87, 74)
      Me.tbPropiedad.MaxLength = 11
      Me.tbPropiedad.Name = "tbPropiedad"
      Me.tbPropiedad.Size = New System.Drawing.Size(500, 20)
      Me.tbPropiedad.TabIndex = 80
      '
      'tbInquilino
      '
      Me.tbInquilino.BackColor = System.Drawing.SystemColors.Info
      Me.tbInquilino.Enabled = False
      Me.tbInquilino.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.tbInquilino.Location = New System.Drawing.Point(87, 101)
      Me.tbInquilino.MaxLength = 11
      Me.tbInquilino.Name = "tbInquilino"
      Me.tbInquilino.Size = New System.Drawing.Size(500, 20)
      Me.tbInquilino.TabIndex = 81
      '
      'GroupBox4
      '
      Me.GroupBox4.Controls.Add(Me.dtpHasta)
      Me.GroupBox4.Controls.Add(Me.dtpDesde)
      Me.GroupBox4.Controls.Add(Me.Label18)
      Me.GroupBox4.Controls.Add(Me.tbMeses)
      Me.GroupBox4.Controls.Add(Me.Label16)
      Me.GroupBox4.Controls.Add(Me.Label15)
      Me.GroupBox4.Controls.Add(Me.dtFechaCtto)
      Me.GroupBox4.Controls.Add(Me.Label22)
      Me.GroupBox4.Location = New System.Drawing.Point(28, 139)
      Me.GroupBox4.Name = "GroupBox4"
      Me.GroupBox4.Size = New System.Drawing.Size(688, 53)
      Me.GroupBox4.TabIndex = 82
      Me.GroupBox4.TabStop = False
      Me.GroupBox4.Text = "Fechas"
      '
      'dtpHasta
      '
      Me.dtpHasta.Enabled = False
      Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpHasta.Location = New System.Drawing.Point(584, 18)
      Me.dtpHasta.Name = "dtpHasta"
      Me.dtpHasta.Size = New System.Drawing.Size(88, 20)
      Me.dtpHasta.TabIndex = 89
      '
      'dtpDesde
      '
      Me.dtpDesde.Enabled = False
      Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDesde.Location = New System.Drawing.Point(424, 18)
      Me.dtpDesde.Name = "dtpDesde"
      Me.dtpDesde.Size = New System.Drawing.Size(88, 20)
      Me.dtpDesde.TabIndex = 88
      '
      'Label18
      '
      Me.Label18.AutoSize = True
      Me.Label18.Location = New System.Drawing.Point(539, 21)
      Me.Label18.Name = "Label18"
      Me.Label18.Size = New System.Drawing.Size(38, 13)
      Me.Label18.TabIndex = 87
      Me.Label18.Text = "Hasta:"
      '
      'tbMeses
      '
      Me.tbMeses.BackColor = System.Drawing.SystemColors.Info
      Me.tbMeses.Enabled = False
      Me.tbMeses.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.tbMeses.Location = New System.Drawing.Point(300, 18)
      Me.tbMeses.MaxLength = 3
      Me.tbMeses.Name = "tbMeses"
      Me.tbMeses.Size = New System.Drawing.Size(40, 20)
      Me.tbMeses.TabIndex = 17
      Me.tbMeses.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'Label16
      '
      Me.Label16.AutoSize = True
      Me.Label16.Location = New System.Drawing.Point(247, 21)
      Me.Label16.Name = "Label16"
      Me.Label16.Size = New System.Drawing.Size(41, 13)
      Me.Label16.TabIndex = 83
      Me.Label16.Text = "Meses:"
      '
      'Label15
      '
      Me.Label15.AutoSize = True
      Me.Label15.Location = New System.Drawing.Point(377, 21)
      Me.Label15.Name = "Label15"
      Me.Label15.Size = New System.Drawing.Size(41, 13)
      Me.Label15.TabIndex = 75
      Me.Label15.Text = "Desde:"
      '
      'dtFechaCtto
      '
      Me.dtFechaCtto.CalendarMonthBackground = System.Drawing.SystemColors.Info
      Me.dtFechaCtto.Enabled = False
      Me.dtFechaCtto.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtFechaCtto.Location = New System.Drawing.Point(129, 18)
      Me.dtFechaCtto.Name = "dtFechaCtto"
      Me.dtFechaCtto.Size = New System.Drawing.Size(80, 20)
      Me.dtFechaCtto.TabIndex = 15
      '
      'Label22
      '
      Me.Label22.AutoSize = True
      Me.Label22.Location = New System.Drawing.Point(41, 21)
      Me.Label22.Name = "Label22"
      Me.Label22.Size = New System.Drawing.Size(82, 13)
      Me.Label22.TabIndex = 68
      Me.Label22.Text = "Fecha contrato:"
      '
      'tbEscalon
      '
      Me.tbEscalon.BackColor = System.Drawing.SystemColors.Info
      Me.tbEscalon.Enabled = False
      Me.tbEscalon.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.tbEscalon.Location = New System.Drawing.Point(125, 21)
      Me.tbEscalon.MaxLength = 11
      Me.tbEscalon.Name = "tbEscalon"
      Me.tbEscalon.Size = New System.Drawing.Size(131, 20)
      Me.tbEscalon.TabIndex = 83
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(41, 24)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(75, 13)
      Me.Label2.TabIndex = 84
      Me.Label2.Text = "Original - Tipo:"
      '
      'tbEscMeses
      '
      Me.tbEscMeses.BackColor = System.Drawing.SystemColors.Info
      Me.tbEscMeses.Enabled = False
      Me.tbEscMeses.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.tbEscMeses.Location = New System.Drawing.Point(329, 21)
      Me.tbEscMeses.MaxLength = 3
      Me.tbEscMeses.Name = "tbEscMeses"
      Me.tbEscMeses.Size = New System.Drawing.Size(40, 20)
      Me.tbEscMeses.TabIndex = 85
      Me.tbEscMeses.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(375, 24)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(38, 13)
      Me.Label3.TabIndex = 86
      Me.Label3.Text = "Meses"
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(291, 24)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(32, 13)
      Me.Label4.TabIndex = 87
      Me.Label4.Text = "Cada"
      '
      'lblIncrem
      '
      Me.lblIncrem.AutoSize = True
      Me.lblIncrem.Location = New System.Drawing.Point(452, 24)
      Me.lblIncrem.Name = "lblIncrem"
      Me.lblIncrem.Size = New System.Drawing.Size(45, 13)
      Me.lblIncrem.TabIndex = 89
      Me.lblIncrem.Text = "Increm. "
      '
      'tbEscIncr
      '
      Me.tbEscIncr.BackColor = System.Drawing.SystemColors.Info
      Me.tbEscIncr.Enabled = False
      Me.tbEscIncr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.tbEscIncr.Location = New System.Drawing.Point(519, 21)
      Me.tbEscIncr.MaxLength = 3
      Me.tbEscIncr.Name = "tbEscIncr"
      Me.tbEscIncr.Size = New System.Drawing.Size(40, 20)
      Me.tbEscIncr.TabIndex = 88
      Me.tbEscIncr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'cmdAceptar
      '
      Me.cmdAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdAceptar.Enabled = False
      Me.cmdAceptar.Location = New System.Drawing.Point(567, 386)
      Me.cmdAceptar.Name = "cmdAceptar"
      Me.cmdAceptar.Size = New System.Drawing.Size(85, 25)
      Me.cmdAceptar.TabIndex = 92
      Me.cmdAceptar.Text = "&Aceptar"
      Me.cmdAceptar.UseVisualStyleBackColor = True
      '
      'cmdCancelar
      '
      Me.cmdCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdCancelar.Location = New System.Drawing.Point(658, 386)
      Me.cmdCancelar.Name = "cmdCancelar"
      Me.cmdCancelar.Size = New System.Drawing.Size(75, 25)
      Me.cmdCancelar.TabIndex = 91
      Me.cmdCancelar.Text = "&Cancelar"
      Me.cmdCancelar.UseVisualStyleBackColor = True
      '
      'btnModif
      '
      Me.btnModif.Location = New System.Drawing.Point(587, 54)
      Me.btnModif.Name = "btnModif"
      Me.btnModif.Size = New System.Drawing.Size(85, 22)
      Me.btnModif.TabIndex = 93
      Me.btnModif.Text = "&Modificar"
      Me.btnModif.UseVisualStyleBackColor = True
      '
      'GroupBox1
      '
      Me.GroupBox1.Controls.Add(Me.tbEscalonM)
      Me.GroupBox1.Controls.Add(Me.Label6)
      Me.GroupBox1.Controls.Add(Me.Label7)
      Me.GroupBox1.Controls.Add(Me.tbEscMesesM)
      Me.GroupBox1.Controls.Add(Me.lblIncremm)
      Me.GroupBox1.Controls.Add(Me.Label10)
      Me.GroupBox1.Controls.Add(Me.tbEscIncrM)
      Me.GroupBox1.Controls.Add(Me.tbEscalon)
      Me.GroupBox1.Controls.Add(Me.btnModif)
      Me.GroupBox1.Controls.Add(Me.Label2)
      Me.GroupBox1.Controls.Add(Me.Label3)
      Me.GroupBox1.Controls.Add(Me.tbEscMeses)
      Me.GroupBox1.Controls.Add(Me.lblIncrem)
      Me.GroupBox1.Controls.Add(Me.Label4)
      Me.GroupBox1.Controls.Add(Me.tbEscIncr)
      Me.GroupBox1.Location = New System.Drawing.Point(28, 257)
      Me.GroupBox1.Name = "GroupBox1"
      Me.GroupBox1.Size = New System.Drawing.Size(688, 98)
      Me.GroupBox1.TabIndex = 90
      Me.GroupBox1.TabStop = False
      Me.GroupBox1.Text = "Escalonamiento"
      '
      'tbEscalonM
      '
      Me.tbEscalonM.BackColor = System.Drawing.SystemColors.Info
      Me.tbEscalonM.Enabled = False
      Me.tbEscalonM.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.tbEscalonM.Location = New System.Drawing.Point(125, 56)
      Me.tbEscalonM.MaxLength = 11
      Me.tbEscalonM.Name = "tbEscalonM"
      Me.tbEscalonM.Size = New System.Drawing.Size(131, 20)
      Me.tbEscalonM.TabIndex = 94
      '
      'Label6
      '
      Me.Label6.AutoSize = True
      Me.Label6.Location = New System.Drawing.Point(24, 59)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(92, 13)
      Me.Label6.TabIndex = 95
      Me.Label6.Text = "Modificado - Tipo:"
      '
      'Label7
      '
      Me.Label7.AutoSize = True
      Me.Label7.Location = New System.Drawing.Point(375, 59)
      Me.Label7.Name = "Label7"
      Me.Label7.Size = New System.Drawing.Size(38, 13)
      Me.Label7.TabIndex = 97
      Me.Label7.Text = "Meses"
      '
      'tbEscMesesM
      '
      Me.tbEscMesesM.BackColor = System.Drawing.SystemColors.Info
      Me.tbEscMesesM.Enabled = False
      Me.tbEscMesesM.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.tbEscMesesM.Location = New System.Drawing.Point(329, 56)
      Me.tbEscMesesM.MaxLength = 3
      Me.tbEscMesesM.Name = "tbEscMesesM"
      Me.tbEscMesesM.Size = New System.Drawing.Size(40, 20)
      Me.tbEscMesesM.TabIndex = 96
      Me.tbEscMesesM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'lblIncremm
      '
      Me.lblIncremm.AutoSize = True
      Me.lblIncremm.Location = New System.Drawing.Point(452, 59)
      Me.lblIncremm.Name = "lblIncremm"
      Me.lblIncremm.Size = New System.Drawing.Size(42, 13)
      Me.lblIncremm.TabIndex = 100
      Me.lblIncremm.Text = "Increm."
      '
      'Label10
      '
      Me.Label10.AutoSize = True
      Me.Label10.Location = New System.Drawing.Point(291, 59)
      Me.Label10.Name = "Label10"
      Me.Label10.Size = New System.Drawing.Size(32, 13)
      Me.Label10.TabIndex = 98
      Me.Label10.Text = "Cada"
      '
      'tbEscIncrM
      '
      Me.tbEscIncrM.BackColor = System.Drawing.SystemColors.Info
      Me.tbEscIncrM.Enabled = False
      Me.tbEscIncrM.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.tbEscIncrM.Location = New System.Drawing.Point(519, 56)
      Me.tbEscIncrM.MaxLength = 3
      Me.tbEscIncrM.Name = "tbEscIncrM"
      Me.tbEscIncrM.Size = New System.Drawing.Size(40, 20)
      Me.tbEscIncrM.TabIndex = 99
      Me.tbEscIncrM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'GroupBox2
      '
      Me.GroupBox2.Controls.Add(Me.tbImpIva)
      Me.GroupBox2.Controls.Add(Me.Label5)
      Me.GroupBox2.Controls.Add(Me.tbImpAlq)
      Me.GroupBox2.Controls.Add(Me.Label20)
      Me.GroupBox2.Location = New System.Drawing.Point(28, 198)
      Me.GroupBox2.Name = "GroupBox2"
      Me.GroupBox2.Size = New System.Drawing.Size(688, 53)
      Me.GroupBox2.TabIndex = 93
      Me.GroupBox2.TabStop = False
      Me.GroupBox2.Text = "Alquiler"
      '
      'tbImpIva
      '
      Me.tbImpIva.BackColor = System.Drawing.SystemColors.Info
      Me.tbImpIva.Enabled = False
      Me.tbImpIva.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.tbImpIva.Location = New System.Drawing.Point(346, 19)
      Me.tbImpIva.Name = "tbImpIva"
      Me.tbImpIva.Size = New System.Drawing.Size(83, 20)
      Me.tbImpIva.TabIndex = 92
      Me.tbImpIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.Location = New System.Drawing.Point(272, 22)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(68, 13)
      Me.Label5.TabIndex = 93
      Me.Label5.Text = "IVA 1° mes $"
      '
      'tbImpAlq
      '
      Me.tbImpAlq.BackColor = System.Drawing.SystemColors.Info
      Me.tbImpAlq.Enabled = False
      Me.tbImpAlq.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.tbImpAlq.Location = New System.Drawing.Point(125, 19)
      Me.tbImpAlq.Name = "tbImpAlq"
      Me.tbImpAlq.Size = New System.Drawing.Size(83, 20)
      Me.tbImpAlq.TabIndex = 90
      Me.tbImpAlq.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label20
      '
      Me.Label20.AutoSize = True
      Me.Label20.Location = New System.Drawing.Point(33, 22)
      Me.Label20.Name = "Label20"
      Me.Label20.Size = New System.Drawing.Size(75, 13)
      Me.Label20.TabIndex = 91
      Me.Label20.Text = "Valor 1° mes $"
      '
      'FrmContratoAct
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(745, 423)
      Me.Controls.Add(Me.GroupBox2)
      Me.Controls.Add(Me.GroupBox1)
      Me.Controls.Add(Me.cmdAceptar)
      Me.Controls.Add(Me.cmdCancelar)
      Me.Controls.Add(Me.GroupBox4)
      Me.Controls.Add(Me.tbInquilino)
      Me.Controls.Add(Me.tbPropiedad)
      Me.Controls.Add(Me.tbPropietario)
      Me.Controls.Add(Me.Label13)
      Me.Controls.Add(Me.Label9)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.tbContrato)
      Me.Controls.Add(Me.Label12)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "FrmContratoAct"
      Me.Text = "Actualización Contrato"
      Me.GroupBox4.ResumeLayout(False)
      Me.GroupBox4.PerformLayout()
      Me.GroupBox1.ResumeLayout(False)
      Me.GroupBox1.PerformLayout()
      Me.GroupBox2.ResumeLayout(False)
      Me.GroupBox2.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

   Friend WithEvents tbContrato As TextBox
   Friend WithEvents Label12 As Label
   Friend WithEvents Label1 As Label
   Friend WithEvents Label9 As Label
   Friend WithEvents Label13 As Label
   Friend WithEvents tbPropietario As TextBox
   Friend WithEvents tbPropiedad As TextBox
   Friend WithEvents tbInquilino As TextBox
   Friend WithEvents GroupBox4 As GroupBox
   Friend WithEvents Label18 As Label
   Friend WithEvents tbMeses As TextBox
   Friend WithEvents Label16 As Label
   Friend WithEvents Label15 As Label
   Friend WithEvents dtFechaCtto As DateTimePicker
   Friend WithEvents Label22 As Label
   Friend WithEvents tbEscalon As TextBox
   Friend WithEvents Label2 As Label
   Friend WithEvents tbEscMeses As TextBox
   Friend WithEvents Label3 As Label
   Friend WithEvents Label4 As Label
   Friend WithEvents lblIncrem As Label
   Friend WithEvents tbEscIncr As TextBox
   Friend WithEvents cmdAceptar As Button
   Friend WithEvents cmdCancelar As Button
   Friend WithEvents btnModif As Button
   Friend WithEvents GroupBox1 As GroupBox
   Friend WithEvents dtpHasta As DateTimePicker
   Friend WithEvents dtpDesde As DateTimePicker
   Friend WithEvents GroupBox2 As GroupBox
   Friend WithEvents tbImpAlq As TextBox
   Friend WithEvents Label20 As Label
   Friend WithEvents tbEscalonM As TextBox
   Friend WithEvents Label6 As Label
   Friend WithEvents Label7 As Label
   Friend WithEvents tbEscMesesM As TextBox
   Friend WithEvents lblIncremm As Label
   Friend WithEvents Label10 As Label
   Friend WithEvents tbEscIncrM As TextBox
   Friend WithEvents tbImpIva As TextBox
   Friend WithEvents Label5 As Label
End Class
