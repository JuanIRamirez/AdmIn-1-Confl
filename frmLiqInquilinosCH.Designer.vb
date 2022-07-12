<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLiqInquilinosCH
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
      Me.cmdCancelar = New System.Windows.Forms.Button()
      Me.cmdAceptar = New System.Windows.Forms.Button()
      Me.cmdBaja = New System.Windows.Forms.Button()
      Me.cmdEditar = New System.Windows.Forms.Button()
      Me.cmdAlta = New System.Windows.Forms.Button()
      Me.gbDatos = New System.Windows.Forms.GroupBox()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.tbTitular = New System.Windows.Forms.TextBox()
      Me.cmdCancelar2 = New System.Windows.Forms.Button()
      Me.cmdAceptar2 = New System.Windows.Forms.Button()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.tbFecCheque = New System.Windows.Forms.DateTimePicker()
      Me.cbBanco = New System.Windows.Forms.ComboBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.tbImporte = New System.Windows.Forms.TextBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.tbNroCheque = New System.Windows.Forms.TextBox()
      Me.Label12 = New System.Windows.Forms.Label()
      Me.Label10 = New System.Windows.Forms.Label()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.tbCuenta = New System.Windows.Forms.TextBox()
      Me.Label23 = New System.Windows.Forms.Label()
      Me.TextBox1 = New System.Windows.Forms.TextBox()
      Me.tbTotal = New System.Windows.Forms.TextBox()
      Me.Label6 = New System.Windows.Forms.Label()
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.gbDatos.SuspendLayout()
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
      Me.DataGridView1.Location = New System.Drawing.Point(12, 12)
      Me.DataGridView1.Name = "DataGridView1"
      Me.DataGridView1.ReadOnly = True
      Me.DataGridView1.RowTemplate.ReadOnly = True
      Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.DataGridView1.Size = New System.Drawing.Size(802, 360)
      Me.DataGridView1.TabIndex = 10
      '
      'cmdCancelar
      '
      Me.cmdCancelar.Location = New System.Drawing.Point(752, 378)
      Me.cmdCancelar.Name = "cmdCancelar"
      Me.cmdCancelar.Size = New System.Drawing.Size(62, 27)
      Me.cmdCancelar.TabIndex = 15
      Me.cmdCancelar.Text = "&Cancelar"
      Me.cmdCancelar.UseVisualStyleBackColor = True
      '
      'cmdAceptar
      '
      Me.cmdAceptar.Location = New System.Drawing.Point(663, 378)
      Me.cmdAceptar.Name = "cmdAceptar"
      Me.cmdAceptar.Size = New System.Drawing.Size(83, 27)
      Me.cmdAceptar.TabIndex = 14
      Me.cmdAceptar.Text = "&Aceptar"
      Me.cmdAceptar.UseVisualStyleBackColor = True
      '
      'cmdBaja
      '
      Me.cmdBaja.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdBaja.Location = New System.Drawing.Point(82, 378)
      Me.cmdBaja.Name = "cmdBaja"
      Me.cmdBaja.Size = New System.Drawing.Size(60, 27)
      Me.cmdBaja.TabIndex = 12
      Me.cmdBaja.Text = "&Quitar"
      Me.cmdBaja.UseVisualStyleBackColor = True
      '
      'cmdEditar
      '
      Me.cmdEditar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdEditar.Location = New System.Drawing.Point(148, 378)
      Me.cmdEditar.Name = "cmdEditar"
      Me.cmdEditar.Size = New System.Drawing.Size(66, 27)
      Me.cmdEditar.TabIndex = 13
      Me.cmdEditar.Text = "&Modificar"
      Me.cmdEditar.UseVisualStyleBackColor = True
      '
      'cmdAlta
      '
      Me.cmdAlta.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdAlta.Location = New System.Drawing.Point(12, 378)
      Me.cmdAlta.Name = "cmdAlta"
      Me.cmdAlta.Size = New System.Drawing.Size(64, 27)
      Me.cmdAlta.TabIndex = 11
      Me.cmdAlta.Text = "A&gregar"
      Me.cmdAlta.UseVisualStyleBackColor = True
      '
      'gbDatos
      '
      Me.gbDatos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.gbDatos.Controls.Add(Me.Label4)
      Me.gbDatos.Controls.Add(Me.tbTitular)
      Me.gbDatos.Controls.Add(Me.cmdCancelar2)
      Me.gbDatos.Controls.Add(Me.cmdAceptar2)
      Me.gbDatos.Controls.Add(Me.Label5)
      Me.gbDatos.Controls.Add(Me.tbFecCheque)
      Me.gbDatos.Controls.Add(Me.cbBanco)
      Me.gbDatos.Controls.Add(Me.Label2)
      Me.gbDatos.Controls.Add(Me.tbImporte)
      Me.gbDatos.Controls.Add(Me.Label1)
      Me.gbDatos.Controls.Add(Me.tbNroCheque)
      Me.gbDatos.Controls.Add(Me.Label12)
      Me.gbDatos.Controls.Add(Me.Label10)
      Me.gbDatos.Controls.Add(Me.Label3)
      Me.gbDatos.Controls.Add(Me.tbCuenta)
      Me.gbDatos.Controls.Add(Me.Label23)
      Me.gbDatos.Controls.Add(Me.TextBox1)
      Me.gbDatos.Enabled = False
      Me.gbDatos.Location = New System.Drawing.Point(12, 411)
      Me.gbDatos.Name = "gbDatos"
      Me.gbDatos.Size = New System.Drawing.Size(802, 117)
      Me.gbDatos.TabIndex = 100
      Me.gbDatos.TabStop = False
      Me.gbDatos.Text = "Cobro"
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(8, 66)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(39, 13)
      Me.Label4.TabIndex = 120
      Me.Label4.Text = "Titular:"
      '
      'tbTitular
      '
      Me.tbTitular.Location = New System.Drawing.Point(53, 63)
      Me.tbTitular.MaxLength = 50
      Me.tbTitular.Name = "tbTitular"
      Me.tbTitular.Size = New System.Drawing.Size(235, 20)
      Me.tbTitular.TabIndex = 3
      '
      'cmdCancelar2
      '
      Me.cmdCancelar2.Location = New System.Drawing.Point(734, 78)
      Me.cmdCancelar2.Name = "cmdCancelar2"
      Me.cmdCancelar2.Size = New System.Drawing.Size(62, 27)
      Me.cmdCancelar2.TabIndex = 7
      Me.cmdCancelar2.Text = "&Cancelar"
      Me.cmdCancelar2.UseVisualStyleBackColor = True
      '
      'cmdAceptar2
      '
      Me.cmdAceptar2.Location = New System.Drawing.Point(651, 78)
      Me.cmdAceptar2.Name = "cmdAceptar2"
      Me.cmdAceptar2.Size = New System.Drawing.Size(77, 27)
      Me.cmdAceptar2.TabIndex = 6
      Me.cmdAceptar2.Text = "&Aceptar"
      Me.cmdAceptar2.UseVisualStyleBackColor = True
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.Location = New System.Drawing.Point(464, 67)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(40, 13)
      Me.Label5.TabIndex = 116
      Me.Label5.Text = "Fecha:"
      '
      'tbFecCheque
      '
      Me.tbFecCheque.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.tbFecCheque.Location = New System.Drawing.Point(511, 63)
      Me.tbFecCheque.Name = "tbFecCheque"
      Me.tbFecCheque.Size = New System.Drawing.Size(87, 20)
      Me.tbFecCheque.TabIndex = 5
      Me.tbFecCheque.Value = New Date(2015, 9, 24, 0, 0, 0, 0)
      '
      'cbBanco
      '
      Me.cbBanco.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      Me.cbBanco.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.cbBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbBanco.FormattingEnabled = True
      Me.cbBanco.Location = New System.Drawing.Point(53, 22)
      Me.cbBanco.Name = "cbBanco"
      Me.cbBanco.Size = New System.Drawing.Size(358, 21)
      Me.cbBanco.TabIndex = 0
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(6, 25)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(41, 13)
      Me.Label2.TabIndex = 113
      Me.Label2.Text = "Banco:"
      '
      'tbImporte
      '
      Me.tbImporte.Location = New System.Drawing.Point(351, 64)
      Me.tbImporte.MaxLength = 15
      Me.tbImporte.Name = "tbImporte"
      Me.tbImporte.Size = New System.Drawing.Size(107, 20)
      Me.tbImporte.TabIndex = 4
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(294, 67)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(51, 13)
      Me.Label1.TabIndex = 112
      Me.Label1.Text = "Importe $"
      '
      'tbNroCheque
      '
      Me.tbNroCheque.Location = New System.Drawing.Point(651, 22)
      Me.tbNroCheque.MaxLength = 25
      Me.tbNroCheque.Name = "tbNroCheque"
      Me.tbNroCheque.Size = New System.Drawing.Size(142, 20)
      Me.tbNroCheque.TabIndex = 2
      '
      'Label12
      '
      Me.Label12.AutoSize = True
      Me.Label12.Location = New System.Drawing.Point(604, 25)
      Me.Label12.Name = "Label12"
      Me.Label12.Size = New System.Drawing.Size(41, 13)
      Me.Label12.TabIndex = 62
      Me.Label12.Text = "Ch. Nº:"
      '
      'Label10
      '
      Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.Label10.AutoSize = True
      Me.Label10.Location = New System.Drawing.Point(6, -38)
      Me.Label10.Name = "Label10"
      Me.Label10.Size = New System.Drawing.Size(41, 13)
      Me.Label10.TabIndex = 110
      Me.Label10.Text = "Banco:"
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(417, 25)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(44, 13)
      Me.Label3.TabIndex = 50
      Me.Label3.Text = "Cuenta:"
      '
      'tbCuenta
      '
      Me.tbCuenta.Location = New System.Drawing.Point(467, 22)
      Me.tbCuenta.MaxLength = 50
      Me.tbCuenta.Name = "tbCuenta"
      Me.tbCuenta.Size = New System.Drawing.Size(131, 20)
      Me.tbCuenta.TabIndex = 1
      '
      'Label23
      '
      Me.Label23.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label23.AutoSize = True
      Me.Label23.Location = New System.Drawing.Point(1178, -44)
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
      Me.TextBox1.Location = New System.Drawing.Point(1239, -47)
      Me.TextBox1.Name = "TextBox1"
      Me.TextBox1.Size = New System.Drawing.Size(71, 20)
      Me.TextBox1.TabIndex = 57
      '
      'tbTotal
      '
      Me.tbTotal.BackColor = System.Drawing.SystemColors.Info
      Me.tbTotal.Enabled = False
      Me.tbTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.tbTotal.Location = New System.Drawing.Point(421, 382)
      Me.tbTotal.MaxLength = 15
      Me.tbTotal.Name = "tbTotal"
      Me.tbTotal.Size = New System.Drawing.Size(107, 20)
      Me.tbTotal.TabIndex = 113
      '
      'Label6
      '
      Me.Label6.AutoSize = True
      Me.Label6.Location = New System.Drawing.Point(375, 385)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(40, 13)
      Me.Label6.TabIndex = 114
      Me.Label6.Text = "Total $"
      '
      'frmLiqInquilinosCH
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(826, 538)
      Me.Controls.Add(Me.tbTotal)
      Me.Controls.Add(Me.Label6)
      Me.Controls.Add(Me.gbDatos)
      Me.Controls.Add(Me.cmdBaja)
      Me.Controls.Add(Me.cmdEditar)
      Me.Controls.Add(Me.cmdAlta)
      Me.Controls.Add(Me.cmdCancelar)
      Me.Controls.Add(Me.cmdAceptar)
      Me.Controls.Add(Me.DataGridView1)
      Me.KeyPreview = True
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "frmLiqInquilinosCH"
      Me.Text = "Recibo Inquilino: Cheques"
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.gbDatos.ResumeLayout(False)
      Me.gbDatos.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
   Friend WithEvents cmdCancelar As System.Windows.Forms.Button
   Friend WithEvents cmdAceptar As System.Windows.Forms.Button
   Friend WithEvents cmdBaja As System.Windows.Forms.Button
   Friend WithEvents cmdEditar As System.Windows.Forms.Button
   Friend WithEvents cmdAlta As System.Windows.Forms.Button
   Friend WithEvents gbDatos As System.Windows.Forms.GroupBox
   Friend WithEvents tbNroCheque As System.Windows.Forms.TextBox
   Friend WithEvents Label12 As System.Windows.Forms.Label
   Friend WithEvents Label10 As System.Windows.Forms.Label
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents tbCuenta As System.Windows.Forms.TextBox
   Friend WithEvents Label23 As System.Windows.Forms.Label
   Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
   Friend WithEvents tbImporte As System.Windows.Forms.TextBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents cbBanco As System.Windows.Forms.ComboBox
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents tbFecCheque As System.Windows.Forms.DateTimePicker
   Friend WithEvents cmdCancelar2 As System.Windows.Forms.Button
   Friend WithEvents cmdAceptar2 As System.Windows.Forms.Button
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents tbTitular As System.Windows.Forms.TextBox
   Friend WithEvents tbTotal As TextBox
   Friend WithEvents Label6 As Label
End Class
