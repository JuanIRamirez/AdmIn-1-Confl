<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPropietarios
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
      Me.cmdEdicion = New System.Windows.Forms.Button()
      Me.cmdAlta = New System.Windows.Forms.Button()
      Me.cmdSalir = New System.Windows.Forms.Button()
      Me.cmdBaja = New System.Windows.Forms.Button()
      Me.DataGridView1 = New System.Windows.Forms.DataGridView()
      Me.tbBuscar = New System.Windows.Forms.TextBox()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.optActivos = New System.Windows.Forms.RadioButton()
      Me.optInactivos = New System.Windows.Forms.RadioButton()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.btPropiedades = New System.Windows.Forms.Button()
      Me.optTodos = New System.Windows.Forms.RadioButton()
      Me.btnRestCol1 = New System.Windows.Forms.Button()
      Me.btListado = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdEdicion
        '
        Me.cmdEdicion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdEdicion.Location = New System.Drawing.Point(178, 557)
        Me.cmdEdicion.Name = "cmdEdicion"
        Me.cmdEdicion.Size = New System.Drawing.Size(76, 27)
        Me.cmdEdicion.TabIndex = 6
        Me.cmdEdicion.Text = "&Modificar"
        Me.cmdEdicion.UseVisualStyleBackColor = True
        '
        'cmdAlta
        '
        Me.cmdAlta.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdAlta.Location = New System.Drawing.Point(14, 557)
        Me.cmdAlta.Name = "cmdAlta"
        Me.cmdAlta.Size = New System.Drawing.Size(76, 27)
        Me.cmdAlta.TabIndex = 4
        Me.cmdAlta.Text = "&Alta"
        Me.cmdAlta.UseVisualStyleBackColor = True
        '
        'cmdSalir
        '
        Me.cmdSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSalir.Location = New System.Drawing.Point(928, 557)
        Me.cmdSalir.Name = "cmdSalir"
        Me.cmdSalir.Size = New System.Drawing.Size(76, 27)
        Me.cmdSalir.TabIndex = 7
        Me.cmdSalir.Text = "&Salir"
        Me.cmdSalir.UseVisualStyleBackColor = True
        '
        'cmdBaja
        '
        Me.cmdBaja.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdBaja.Location = New System.Drawing.Point(96, 557)
        Me.cmdBaja.Name = "cmdBaja"
        Me.cmdBaja.Size = New System.Drawing.Size(76, 27)
        Me.cmdBaja.TabIndex = 5
        Me.cmdBaja.Text = "&Baja"
        Me.cmdBaja.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(12, 38)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowTemplate.ReadOnly = True
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(992, 505)
        Me.DataGridView1.TabIndex = 3
        '
        'tbBuscar
        '
        Me.tbBuscar.Location = New System.Drawing.Point(61, 12)
        Me.tbBuscar.Name = "tbBuscar"
        Me.tbBuscar.Size = New System.Drawing.Size(227, 20)
        Me.tbBuscar.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 96
        Me.Label5.Text = "Buscar:"
        '
        'optActivos
        '
        Me.optActivos.AutoSize = True
        Me.optActivos.Checked = True
        Me.optActivos.Location = New System.Drawing.Point(541, 12)
        Me.optActivos.Name = "optActivos"
        Me.optActivos.Size = New System.Drawing.Size(60, 17)
        Me.optActivos.TabIndex = 1
        Me.optActivos.TabStop = True
        Me.optActivos.Text = "&Activos"
        Me.optActivos.UseVisualStyleBackColor = True
        '
        'optInactivos
        '
        Me.optInactivos.AutoSize = True
        Me.optInactivos.Location = New System.Drawing.Point(607, 12)
        Me.optInactivos.Name = "optInactivos"
        Me.optInactivos.Size = New System.Drawing.Size(68, 17)
        Me.optInactivos.TabIndex = 2
        Me.optInactivos.Text = "&Inactivos"
        Me.optInactivos.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(492, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 100
        Me.Label1.Text = "Estado:"
        '
        'btPropiedades
        '
        Me.btPropiedades.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btPropiedades.Location = New System.Drawing.Point(396, 557)
        Me.btPropiedades.Name = "btPropiedades"
        Me.btPropiedades.Size = New System.Drawing.Size(76, 27)
        Me.btPropiedades.TabIndex = 101
        Me.btPropiedades.Text = "&Propiedades"
        Me.btPropiedades.UseVisualStyleBackColor = True
        '
        'optTodos
        '
        Me.optTodos.AutoSize = True
        Me.optTodos.Location = New System.Drawing.Point(681, 12)
        Me.optTodos.Name = "optTodos"
        Me.optTodos.Size = New System.Drawing.Size(55, 17)
        Me.optTodos.TabIndex = 105
        Me.optTodos.Text = "&Todos"
        Me.optTodos.UseVisualStyleBackColor = True
        '
        'btnRestCol1
        '
        Me.btnRestCol1.Location = New System.Drawing.Point(13, 39)
        Me.btnRestCol1.Name = "btnRestCol1"
        Me.btnRestCol1.Size = New System.Drawing.Size(28, 19)
        Me.btnRestCol1.TabIndex = 106
        Me.btnRestCol1.Text = "..."
        Me.btnRestCol1.UseVisualStyleBackColor = True
        '
        'btListado
        '
        Me.btListado.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btListado.Location = New System.Drawing.Point(478, 557)
        Me.btListado.Name = "btListado"
        Me.btListado.Size = New System.Drawing.Size(76, 27)
        Me.btListado.TabIndex = 107
        Me.btListado.Text = "&Listado"
        Me.btListado.UseVisualStyleBackColor = True
        '
        'frmPropietarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1015, 596)
        Me.Controls.Add(Me.btListado)
        Me.Controls.Add(Me.btnRestCol1)
        Me.Controls.Add(Me.optTodos)
        Me.Controls.Add(Me.btPropiedades)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.optInactivos)
        Me.Controls.Add(Me.optActivos)
        Me.Controls.Add(Me.cmdEdicion)
        Me.Controls.Add(Me.cmdAlta)
        Me.Controls.Add(Me.cmdSalir)
        Me.Controls.Add(Me.cmdBaja)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.tbBuscar)
        Me.Controls.Add(Me.Label5)
        Me.Name = "frmPropietarios"
        Me.Text = "Propietarios"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdEdicion As System.Windows.Forms.Button
   Friend WithEvents cmdAlta As System.Windows.Forms.Button
   Friend WithEvents cmdSalir As System.Windows.Forms.Button
   Friend WithEvents cmdBaja As System.Windows.Forms.Button
   Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
   Friend WithEvents tbBuscar As System.Windows.Forms.TextBox
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents optActivos As System.Windows.Forms.RadioButton
   Friend WithEvents optInactivos As System.Windows.Forms.RadioButton
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents btPropiedades As System.Windows.Forms.Button
   Friend WithEvents optTodos As System.Windows.Forms.RadioButton
   Friend WithEvents btnRestCol1 As System.Windows.Forms.Button
   Friend WithEvents btListado As System.Windows.Forms.Button
End Class
