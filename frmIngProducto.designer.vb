<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIngProducto
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
      Me.lblCosto = New System.Windows.Forms.Label()
      Me.optBruto = New System.Windows.Forms.RadioButton()
      Me.optNeto = New System.Windows.Forms.RadioButton()
      Me.DataGridView1 = New System.Windows.Forms.DataGridView()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.tbCodigo = New System.Windows.Forms.TextBox()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.tbDescrip = New System.Windows.Forms.TextBox()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.tbCantidad = New System.Windows.Forms.TextBox()
      Me.lblPartida = New System.Windows.Forms.Label()
      Me.tbPartida = New System.Windows.Forms.TextBox()
      Me.dtFechaVenc = New System.Windows.Forms.DateTimePicker()
      Me.lblFechaVenc = New System.Windows.Forms.Label()
      Me.tbCosto = New System.Windows.Forms.TextBox()
      Me.Label8 = New System.Windows.Forms.Label()
      Me.txtBonificacion = New System.Windows.Forms.TextBox()
      Me.Label9 = New System.Windows.Forms.Label()
      Me.txtSubTotal = New System.Windows.Forms.TextBox()
      Me.lblRenglonOC = New System.Windows.Forms.Label()
      Me.txtRenglonOC = New System.Windows.Forms.TextBox()
      Me.cmdAceptar = New System.Windows.Forms.Button()
      Me.cmdCancelar = New System.Windows.Forms.Button()
      Me.cboRubro = New System.Windows.Forms.ComboBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.tbBuscar = New System.Windows.Forms.TextBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.cmdAltaProducto = New System.Windows.Forms.Button()
      Me.Panel1 = New System.Windows.Forms.Panel()
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.Panel1.SuspendLayout()
      Me.SuspendLayout()
      '
      'lblCosto
      '
      Me.lblCosto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblCosto.AutoSize = True
      Me.lblCosto.Location = New System.Drawing.Point(505, 468)
      Me.lblCosto.Name = "lblCosto"
      Me.lblCosto.Size = New System.Drawing.Size(37, 13)
      Me.lblCosto.TabIndex = 86
      Me.lblCosto.Text = "Costo:"
      '
      'optBruto
      '
      Me.optBruto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.optBruto.AutoSize = True
      Me.optBruto.Location = New System.Drawing.Point(602, 466)
      Me.optBruto.Name = "optBruto"
      Me.optBruto.Size = New System.Drawing.Size(47, 17)
      Me.optBruto.TabIndex = 85
      Me.optBruto.Text = "&Final"
      Me.optBruto.UseVisualStyleBackColor = True
      '
      'optNeto
      '
      Me.optNeto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.optNeto.AutoSize = True
      Me.optNeto.Checked = True
      Me.optNeto.Location = New System.Drawing.Point(548, 466)
      Me.optNeto.Name = "optNeto"
      Me.optNeto.Size = New System.Drawing.Size(48, 17)
      Me.optNeto.TabIndex = 84
      Me.optNeto.TabStop = True
      Me.optNeto.Text = "&Neto"
      Me.optNeto.UseVisualStyleBackColor = True
      '
      'DataGridView1
      '
      Me.DataGridView1.AllowUserToAddRows = False
      Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
      Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.DataGridView1.Location = New System.Drawing.Point(12, 83)
      Me.DataGridView1.Name = "DataGridView1"
      Me.DataGridView1.ReadOnly = True
      Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.DataGridView1.Size = New System.Drawing.Size(719, 345)
      Me.DataGridView1.TabIndex = 2
      '
      'Label4
      '
      Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(13, 437)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(43, 13)
      Me.Label4.TabIndex = 95
      Me.Label4.Text = "Código:"
      '
      'tbCodigo
      '
      Me.tbCodigo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.tbCodigo.Enabled = False
      Me.tbCodigo.Location = New System.Drawing.Point(62, 434)
      Me.tbCodigo.Name = "tbCodigo"
      Me.tbCodigo.Size = New System.Drawing.Size(212, 20)
      Me.tbCodigo.TabIndex = 94
      '
      'Label5
      '
      Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.Label5.AutoSize = True
      Me.Label5.Location = New System.Drawing.Point(9, 467)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(49, 13)
      Me.Label5.TabIndex = 97
      Me.Label5.Text = "Descrip.:"
      '
      'tbDescrip
      '
      Me.tbDescrip.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.tbDescrip.Enabled = False
      Me.tbDescrip.Location = New System.Drawing.Point(62, 463)
      Me.tbDescrip.Name = "tbDescrip"
      Me.tbDescrip.Size = New System.Drawing.Size(433, 20)
      Me.tbDescrip.TabIndex = 96
      '
      'Label6
      '
      Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.Label6.AutoSize = True
      Me.Label6.Location = New System.Drawing.Point(593, 442)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(59, 13)
      Me.Label6.TabIndex = 99
      Me.Label6.Text = "Cantidad #"
      '
      'tbCantidad
      '
      Me.tbCantidad.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.tbCantidad.Location = New System.Drawing.Point(659, 438)
      Me.tbCantidad.Name = "tbCantidad"
      Me.tbCantidad.Size = New System.Drawing.Size(72, 20)
      Me.tbCantidad.TabIndex = 3
      '
      'lblPartida
      '
      Me.lblPartida.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblPartida.AutoSize = True
      Me.lblPartida.Location = New System.Drawing.Point(116, 494)
      Me.lblPartida.Name = "lblPartida"
      Me.lblPartida.Size = New System.Drawing.Size(43, 13)
      Me.lblPartida.TabIndex = 101
      Me.lblPartida.Text = "Partida:"
      '
      'tbPartida
      '
      Me.tbPartida.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.tbPartida.Enabled = False
      Me.tbPartida.Location = New System.Drawing.Point(165, 490)
      Me.tbPartida.Name = "tbPartida"
      Me.tbPartida.Size = New System.Drawing.Size(72, 20)
      Me.tbPartida.TabIndex = 5
      '
      'dtFechaVenc
      '
      Me.dtFechaVenc.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.dtFechaVenc.Enabled = False
      Me.dtFechaVenc.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtFechaVenc.Location = New System.Drawing.Point(301, 490)
      Me.dtFechaVenc.Name = "dtFechaVenc"
      Me.dtFechaVenc.Size = New System.Drawing.Size(89, 20)
      Me.dtFechaVenc.TabIndex = 6
      '
      'lblFechaVenc
      '
      Me.lblFechaVenc.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblFechaVenc.AutoSize = True
      Me.lblFechaVenc.Location = New System.Drawing.Point(257, 494)
      Me.lblFechaVenc.Name = "lblFechaVenc"
      Me.lblFechaVenc.Size = New System.Drawing.Size(38, 13)
      Me.lblFechaVenc.TabIndex = 102
      Me.lblFechaVenc.Text = "Venc.:"
      '
      'tbCosto
      '
      Me.tbCosto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.tbCosto.Location = New System.Drawing.Point(659, 464)
      Me.tbCosto.Name = "tbCosto"
      Me.tbCosto.Size = New System.Drawing.Size(72, 20)
      Me.tbCosto.TabIndex = 4
      '
      'Label8
      '
      Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.Label8.AutoSize = True
      Me.Label8.Location = New System.Drawing.Point(584, 493)
      Me.Label8.Name = "Label8"
      Me.Label8.Size = New System.Drawing.Size(68, 13)
      Me.Label8.TabIndex = 106
      Me.Label8.Text = "Bonificación:"
      '
      'txtBonificacion
      '
      Me.txtBonificacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.txtBonificacion.Location = New System.Drawing.Point(659, 490)
      Me.txtBonificacion.Name = "txtBonificacion"
      Me.txtBonificacion.Size = New System.Drawing.Size(72, 20)
      Me.txtBonificacion.TabIndex = 8
      '
      'Label9
      '
      Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.Label9.AutoSize = True
      Me.Label9.Location = New System.Drawing.Point(424, 521)
      Me.Label9.Name = "Label9"
      Me.Label9.Size = New System.Drawing.Size(55, 13)
      Me.Label9.TabIndex = 108
      Me.Label9.Text = "Subtotal $"
      '
      'txtSubTotal
      '
      Me.txtSubTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.txtSubTotal.Enabled = False
      Me.txtSubTotal.Location = New System.Drawing.Point(485, 516)
      Me.txtSubTotal.Name = "txtSubTotal"
      Me.txtSubTotal.Size = New System.Drawing.Size(72, 20)
      Me.txtSubTotal.TabIndex = 9
      '
      'lblRenglonOC
      '
      Me.lblRenglonOC.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblRenglonOC.AutoSize = True
      Me.lblRenglonOC.Location = New System.Drawing.Point(408, 493)
      Me.lblRenglonOC.Name = "lblRenglonOC"
      Me.lblRenglonOC.Size = New System.Drawing.Size(71, 13)
      Me.lblRenglonOC.TabIndex = 110
      Me.lblRenglonOC.Text = "Renglón O.C."
      '
      'txtRenglonOC
      '
      Me.txtRenglonOC.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.txtRenglonOC.Location = New System.Drawing.Point(485, 490)
      Me.txtRenglonOC.Name = "txtRenglonOC"
      Me.txtRenglonOC.Size = New System.Drawing.Size(72, 20)
      Me.txtRenglonOC.TabIndex = 7
      '
      'cmdAceptar
      '
      Me.cmdAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdAceptar.Location = New System.Drawing.Point(574, 523)
      Me.cmdAceptar.Name = "cmdAceptar"
      Me.cmdAceptar.Size = New System.Drawing.Size(75, 23)
      Me.cmdAceptar.TabIndex = 10
      Me.cmdAceptar.Text = "&Aceptar"
      Me.cmdAceptar.UseVisualStyleBackColor = True
      '
      'cmdCancelar
      '
      Me.cmdCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdCancelar.Location = New System.Drawing.Point(655, 523)
      Me.cmdCancelar.Name = "cmdCancelar"
      Me.cmdCancelar.Size = New System.Drawing.Size(75, 23)
      Me.cmdCancelar.TabIndex = 11
      Me.cmdCancelar.Text = "&Cerrar"
      Me.cmdCancelar.UseVisualStyleBackColor = True
      '
      'cboRubro
      '
      Me.cboRubro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboRubro.FormattingEnabled = True
      Me.cboRubro.Location = New System.Drawing.Point(64, 37)
      Me.cboRubro.Name = "cboRubro"
      Me.cboRubro.Size = New System.Drawing.Size(437, 21)
      Me.cboRubro.TabIndex = 1
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(19, 40)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(39, 13)
      Me.Label1.TabIndex = 91
      Me.Label1.Text = "Rubro:"
      '
      'tbBuscar
      '
      Me.tbBuscar.Location = New System.Drawing.Point(64, 9)
      Me.tbBuscar.Name = "tbBuscar"
      Me.tbBuscar.Size = New System.Drawing.Size(312, 20)
      Me.tbBuscar.TabIndex = 0
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(15, 12)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(43, 13)
      Me.Label3.TabIndex = 96
      Me.Label3.Text = "Buscar:"
      '
      'cmdAltaProducto
      '
      Me.cmdAltaProducto.Location = New System.Drawing.Point(662, 7)
      Me.cmdAltaProducto.Name = "cmdAltaProducto"
      Me.cmdAltaProducto.Size = New System.Drawing.Size(53, 23)
      Me.cmdAltaProducto.TabIndex = 98
      Me.cmdAltaProducto.Text = "&Nuevo"
      Me.cmdAltaProducto.UseVisualStyleBackColor = True
      '
      'Panel1
      '
      Me.Panel1.Controls.Add(Me.cmdAltaProducto)
      Me.Panel1.Controls.Add(Me.Label3)
      Me.Panel1.Controls.Add(Me.tbBuscar)
      Me.Panel1.Controls.Add(Me.Label1)
      Me.Panel1.Controls.Add(Me.cboRubro)
      Me.Panel1.Location = New System.Drawing.Point(12, 12)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(718, 65)
      Me.Panel1.TabIndex = 90
      '
      'frmIngProducto
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(743, 552)
      Me.Controls.Add(Me.cmdAceptar)
      Me.Controls.Add(Me.cmdCancelar)
      Me.Controls.Add(Me.lblRenglonOC)
      Me.Controls.Add(Me.txtRenglonOC)
      Me.Controls.Add(Me.Label9)
      Me.Controls.Add(Me.txtSubTotal)
      Me.Controls.Add(Me.Label8)
      Me.Controls.Add(Me.txtBonificacion)
      Me.Controls.Add(Me.tbCosto)
      Me.Controls.Add(Me.dtFechaVenc)
      Me.Controls.Add(Me.lblFechaVenc)
      Me.Controls.Add(Me.lblPartida)
      Me.Controls.Add(Me.tbPartida)
      Me.Controls.Add(Me.Label6)
      Me.Controls.Add(Me.tbCantidad)
      Me.Controls.Add(Me.Label5)
      Me.Controls.Add(Me.tbDescrip)
      Me.Controls.Add(Me.Label4)
      Me.Controls.Add(Me.tbCodigo)
      Me.Controls.Add(Me.Panel1)
      Me.Controls.Add(Me.DataGridView1)
      Me.Controls.Add(Me.lblCosto)
      Me.Controls.Add(Me.optBruto)
      Me.Controls.Add(Me.optNeto)
      Me.Name = "frmIngProducto"
      Me.Text = "Seleccionar Producto"
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.Panel1.ResumeLayout(False)
      Me.Panel1.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblCosto As System.Windows.Forms.Label
   Friend WithEvents optBruto As System.Windows.Forms.RadioButton
   Friend WithEvents optNeto As System.Windows.Forms.RadioButton
   Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents tbCodigo As System.Windows.Forms.TextBox
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents tbDescrip As System.Windows.Forms.TextBox
   Friend WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents tbCantidad As System.Windows.Forms.TextBox
   Friend WithEvents lblPartida As System.Windows.Forms.Label
   Friend WithEvents tbPartida As System.Windows.Forms.TextBox
   Friend WithEvents dtFechaVenc As System.Windows.Forms.DateTimePicker
   Friend WithEvents lblFechaVenc As System.Windows.Forms.Label
   Friend WithEvents tbCosto As System.Windows.Forms.TextBox
   Friend WithEvents Label8 As System.Windows.Forms.Label
   Friend WithEvents txtBonificacion As System.Windows.Forms.TextBox
   Friend WithEvents Label9 As System.Windows.Forms.Label
   Friend WithEvents txtSubTotal As System.Windows.Forms.TextBox
   Friend WithEvents lblRenglonOC As System.Windows.Forms.Label
   Friend WithEvents txtRenglonOC As System.Windows.Forms.TextBox
   Friend WithEvents cmdAceptar As System.Windows.Forms.Button
   Friend WithEvents cmdCancelar As System.Windows.Forms.Button
   Friend WithEvents cboRubro As System.Windows.Forms.ComboBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents tbBuscar As System.Windows.Forms.TextBox
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents cmdAltaProducto As System.Windows.Forms.Button
   Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
