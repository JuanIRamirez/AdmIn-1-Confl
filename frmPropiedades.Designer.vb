<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPropiedades
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
      Me.Label5 = New System.Windows.Forms.Label()
      Me.txtDomicilio = New System.Windows.Forms.TextBox()
      Me.DataGridView1 = New System.Windows.Forms.DataGridView()
      Me.cmdAlta = New System.Windows.Forms.Button()
      Me.cmdSalir = New System.Windows.Forms.Button()
      Me.cmdBaja = New System.Windows.Forms.Button()
      Me.cmdEdicion = New System.Windows.Forms.Button()
      Me.cmdCambiarPropiet = New System.Windows.Forms.Button()
      Me.cmdListado = New System.Windows.Forms.Button()
      Me.cbPropietario = New System.Windows.Forms.ComboBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.optInactivas = New System.Windows.Forms.RadioButton()
      Me.optActivas = New System.Windows.Forms.RadioButton()
      Me.optTodos = New System.Windows.Forms.RadioButton()
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.Location = New System.Drawing.Point(8, 44)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(52, 13)
      Me.Label5.TabIndex = 82
      Me.Label5.Text = "Domicilio:"
      '
      'txtDomicilio
      '
      Me.txtDomicilio.Location = New System.Drawing.Point(74, 41)
      Me.txtDomicilio.Name = "txtDomicilio"
      Me.txtDomicilio.Size = New System.Drawing.Size(227, 20)
      Me.txtDomicilio.TabIndex = 6
      '
      'DataGridView1
      '
      Me.DataGridView1.AllowUserToAddRows = False
      Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
      Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.DataGridView1.Location = New System.Drawing.Point(11, 70)
      Me.DataGridView1.Name = "DataGridView1"
      Me.DataGridView1.ReadOnly = True
      Me.DataGridView1.RowTemplate.ReadOnly = True
      Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.DataGridView1.Size = New System.Drawing.Size(887, 408)
      Me.DataGridView1.TabIndex = 90
      '
      'cmdAlta
      '
      Me.cmdAlta.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdAlta.Location = New System.Drawing.Point(11, 485)
      Me.cmdAlta.Name = "cmdAlta"
      Me.cmdAlta.Size = New System.Drawing.Size(76, 27)
      Me.cmdAlta.TabIndex = 9
      Me.cmdAlta.Text = "&Alta"
      Me.cmdAlta.UseVisualStyleBackColor = True
      '
      'cmdSalir
      '
      Me.cmdSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdSalir.Location = New System.Drawing.Point(822, 485)
      Me.cmdSalir.Name = "cmdSalir"
      Me.cmdSalir.Size = New System.Drawing.Size(76, 27)
      Me.cmdSalir.TabIndex = 15
      Me.cmdSalir.Text = "&Salir"
      Me.cmdSalir.UseVisualStyleBackColor = True
      '
      'cmdBaja
      '
      Me.cmdBaja.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdBaja.Location = New System.Drawing.Point(93, 485)
      Me.cmdBaja.Name = "cmdBaja"
      Me.cmdBaja.Size = New System.Drawing.Size(76, 27)
      Me.cmdBaja.TabIndex = 10
      Me.cmdBaja.Text = "&Baja"
      Me.cmdBaja.UseVisualStyleBackColor = True
      '
      'cmdEdicion
      '
      Me.cmdEdicion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdEdicion.Location = New System.Drawing.Point(175, 485)
      Me.cmdEdicion.Name = "cmdEdicion"
      Me.cmdEdicion.Size = New System.Drawing.Size(76, 27)
      Me.cmdEdicion.TabIndex = 11
      Me.cmdEdicion.Text = "&Modificar"
      Me.cmdEdicion.UseVisualStyleBackColor = True
      '
      'cmdCambiarPropiet
      '
      Me.cmdCambiarPropiet.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdCambiarPropiet.Location = New System.Drawing.Point(329, 485)
      Me.cmdCambiarPropiet.Name = "cmdCambiarPropiet"
      Me.cmdCambiarPropiet.Size = New System.Drawing.Size(106, 27)
      Me.cmdCambiarPropiet.TabIndex = 12
      Me.cmdCambiarPropiet.Text = "Cambiar &Propietario"
      Me.cmdCambiarPropiet.UseVisualStyleBackColor = True
      '
      'cmdListado
      '
      Me.cmdListado.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdListado.Location = New System.Drawing.Point(441, 485)
      Me.cmdListado.Name = "cmdListado"
      Me.cmdListado.Size = New System.Drawing.Size(76, 27)
      Me.cmdListado.TabIndex = 91
      Me.cmdListado.Text = "&Listado"
      Me.cmdListado.UseVisualStyleBackColor = True
      '
      'cbPropietario
      '
      Me.cbPropietario.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      Me.cbPropietario.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.cbPropietario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbPropietario.FormattingEnabled = True
      Me.cbPropietario.Location = New System.Drawing.Point(74, 11)
      Me.cbPropietario.Name = "cbPropietario"
      Me.cbPropietario.Size = New System.Drawing.Size(433, 21)
      Me.cbPropietario.TabIndex = 92
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(8, 14)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(60, 13)
      Me.Label1.TabIndex = 93
      Me.Label1.Text = "Propietario:"
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(307, 44)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(43, 13)
      Me.Label2.TabIndex = 103
      Me.Label2.Text = "Estado:"
      '
      'optInactivas
      '
      Me.optInactivas.AutoSize = True
      Me.optInactivas.Location = New System.Drawing.Point(422, 42)
      Me.optInactivas.Name = "optInactivas"
      Me.optInactivas.Size = New System.Drawing.Size(68, 17)
      Me.optInactivas.TabIndex = 102
      Me.optInactivas.Text = "&Inactivas"
      Me.optInactivas.UseVisualStyleBackColor = True
      '
      'optActivas
      '
      Me.optActivas.AutoSize = True
      Me.optActivas.Checked = True
      Me.optActivas.Location = New System.Drawing.Point(356, 42)
      Me.optActivas.Name = "optActivas"
      Me.optActivas.Size = New System.Drawing.Size(60, 17)
      Me.optActivas.TabIndex = 101
      Me.optActivas.TabStop = True
      Me.optActivas.Text = "&Activas"
      Me.optActivas.UseVisualStyleBackColor = True
      '
      'optTodos
      '
      Me.optTodos.AutoSize = True
      Me.optTodos.Location = New System.Drawing.Point(496, 42)
      Me.optTodos.Name = "optTodos"
      Me.optTodos.Size = New System.Drawing.Size(55, 17)
      Me.optTodos.TabIndex = 104
      Me.optTodos.Text = "&Todas"
      Me.optTodos.UseVisualStyleBackColor = True
      '
      'frmPropiedades
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(910, 524)
      Me.Controls.Add(Me.optTodos)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.optInactivas)
      Me.Controls.Add(Me.optActivas)
      Me.Controls.Add(Me.cbPropietario)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.cmdListado)
      Me.Controls.Add(Me.cmdCambiarPropiet)
      Me.Controls.Add(Me.cmdEdicion)
      Me.Controls.Add(Me.cmdAlta)
      Me.Controls.Add(Me.cmdSalir)
      Me.Controls.Add(Me.cmdBaja)
      Me.Controls.Add(Me.DataGridView1)
      Me.Controls.Add(Me.txtDomicilio)
      Me.Controls.Add(Me.Label5)
      Me.KeyPreview = True
      Me.Name = "frmPropiedades"
      Me.Text = "Propiedades"
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents txtDomicilio As System.Windows.Forms.TextBox
   Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
   Friend WithEvents cmdAlta As System.Windows.Forms.Button
   Friend WithEvents cmdSalir As System.Windows.Forms.Button
   Friend WithEvents cmdBaja As System.Windows.Forms.Button
   Friend WithEvents cmdEdicion As System.Windows.Forms.Button
   Friend WithEvents cmdCambiarPropiet As System.Windows.Forms.Button
   Friend WithEvents cmdListado As System.Windows.Forms.Button
   Friend WithEvents cbPropietario As System.Windows.Forms.ComboBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents optInactivas As System.Windows.Forms.RadioButton
   Friend WithEvents optActivas As System.Windows.Forms.RadioButton
   Friend WithEvents optTodos As System.Windows.Forms.RadioButton
End Class
