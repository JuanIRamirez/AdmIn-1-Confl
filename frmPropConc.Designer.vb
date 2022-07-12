<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPropConc
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
      Me.cbPropietario = New System.Windows.Forms.ComboBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.cbPropiedad = New System.Windows.Forms.ComboBox()
      Me.Label9 = New System.Windows.Forms.Label()
      Me.chkTodos = New System.Windows.Forms.CheckBox()
      Me.DataGridView1 = New System.Windows.Forms.DataGridView()
      Me.cmdEdicion = New System.Windows.Forms.Button()
      Me.cmdcmdSalir = New System.Windows.Forms.Button()
      Me.cmdBaja = New System.Windows.Forms.Button()
      Me.cmdImprimir = New System.Windows.Forms.Button()
      Me.cmdAlta = New System.Windows.Forms.Button()
      Me.cmdSalir = New System.Windows.Forms.Button()
      Me.cmdListado = New System.Windows.Forms.Button()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.tbInquilino = New System.Windows.Forms.TextBox()
      Me.btnGenerar = New System.Windows.Forms.Button()
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'cbPropietario
      '
      Me.cbPropietario.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      Me.cbPropietario.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.cbPropietario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbPropietario.FormattingEnabled = True
      Me.cbPropietario.Location = New System.Drawing.Point(70, 12)
      Me.cbPropietario.Name = "cbPropietario"
      Me.cbPropietario.Size = New System.Drawing.Size(433, 21)
      Me.cbPropietario.TabIndex = 71
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(8, 15)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(60, 13)
      Me.Label1.TabIndex = 70
      Me.Label1.Text = "Propietario:"
      '
      'cbPropiedad
      '
      Me.cbPropiedad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbPropiedad.FormattingEnabled = True
      Me.cbPropiedad.Location = New System.Drawing.Point(70, 39)
      Me.cbPropiedad.Name = "cbPropiedad"
      Me.cbPropiedad.Size = New System.Drawing.Size(433, 21)
      Me.cbPropiedad.TabIndex = 84
      '
      'Label9
      '
      Me.Label9.AutoSize = True
      Me.Label9.Location = New System.Drawing.Point(8, 44)
      Me.Label9.Name = "Label9"
      Me.Label9.Size = New System.Drawing.Size(58, 13)
      Me.Label9.TabIndex = 83
      Me.Label9.Text = "Propiedad:"
      '
      'chkTodos
      '
      Me.chkTodos.AutoSize = True
      Me.chkTodos.Location = New System.Drawing.Point(661, 14)
      Me.chkTodos.Name = "chkTodos"
      Me.chkTodos.Size = New System.Drawing.Size(101, 17)
      Me.chkTodos.TabIndex = 85
      Me.chkTodos.Text = "Mostrar &Historial"
      Me.chkTodos.UseVisualStyleBackColor = True
      '
      'DataGridView1
      '
      Me.DataGridView1.AllowUserToAddRows = False
      Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
      Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.DataGridView1.Location = New System.Drawing.Point(11, 66)
      Me.DataGridView1.Name = "DataGridView1"
      Me.DataGridView1.ReadOnly = True
      Me.DataGridView1.RowTemplate.ReadOnly = True
      Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.DataGridView1.Size = New System.Drawing.Size(762, 356)
      Me.DataGridView1.TabIndex = 86
      '
      'cmdEdicion
      '
      Me.cmdEdicion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdEdicion.Location = New System.Drawing.Point(137, 428)
      Me.cmdEdicion.Name = "cmdEdicion"
      Me.cmdEdicion.Size = New System.Drawing.Size(59, 27)
      Me.cmdEdicion.TabIndex = 91
      Me.cmdEdicion.Text = "&Edición"
      Me.cmdEdicion.UseVisualStyleBackColor = True
      '
      'cmdcmdSalir
      '
      Me.cmdcmdSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdcmdSalir.Location = New System.Drawing.Point(859, 419)
      Me.cmdcmdSalir.Name = "cmdcmdSalir"
      Me.cmdcmdSalir.Size = New System.Drawing.Size(76, 27)
      Me.cmdcmdSalir.TabIndex = 90
      Me.cmdcmdSalir.Text = "&Salir"
      Me.cmdcmdSalir.UseVisualStyleBackColor = True
      '
      'cmdBaja
      '
      Me.cmdBaja.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdBaja.Location = New System.Drawing.Point(75, 428)
      Me.cmdBaja.Name = "cmdBaja"
      Me.cmdBaja.Size = New System.Drawing.Size(56, 27)
      Me.cmdBaja.TabIndex = 89
      Me.cmdBaja.Text = "&Baja"
      Me.cmdBaja.UseVisualStyleBackColor = True
      '
      'cmdImprimir
      '
      Me.cmdImprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdImprimir.Location = New System.Drawing.Point(381, 428)
      Me.cmdImprimir.Name = "cmdImprimir"
      Me.cmdImprimir.Size = New System.Drawing.Size(62, 27)
      Me.cmdImprimir.TabIndex = 88
      Me.cmdImprimir.Text = "&Imprimir"
      Me.cmdImprimir.UseVisualStyleBackColor = True
      '
      'cmdAlta
      '
      Me.cmdAlta.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdAlta.Location = New System.Drawing.Point(12, 428)
      Me.cmdAlta.Name = "cmdAlta"
      Me.cmdAlta.Size = New System.Drawing.Size(58, 27)
      Me.cmdAlta.TabIndex = 87
      Me.cmdAlta.Text = "&Alta"
      Me.cmdAlta.UseVisualStyleBackColor = True
      '
      'cmdSalir
      '
      Me.cmdSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdSalir.Location = New System.Drawing.Point(713, 428)
      Me.cmdSalir.Name = "cmdSalir"
      Me.cmdSalir.Size = New System.Drawing.Size(60, 27)
      Me.cmdSalir.TabIndex = 92
      Me.cmdSalir.Text = "&Salir"
      Me.cmdSalir.UseVisualStyleBackColor = True
      '
      'cmdListado
      '
      Me.cmdListado.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdListado.Location = New System.Drawing.Point(449, 428)
      Me.cmdListado.Name = "cmdListado"
      Me.cmdListado.Size = New System.Drawing.Size(68, 27)
      Me.cmdListado.TabIndex = 93
      Me.cmdListado.Text = "&Listado"
      Me.cmdListado.UseVisualStyleBackColor = True
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(509, 24)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(78, 13)
      Me.Label2.TabIndex = 94
      Me.Label2.Text = "Inquilino actual"
      '
      'tbInquilino
      '
      Me.tbInquilino.BackColor = System.Drawing.Color.LightYellow
      Me.tbInquilino.Enabled = False
      Me.tbInquilino.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.tbInquilino.Location = New System.Drawing.Point(509, 40)
      Me.tbInquilino.Name = "tbInquilino"
      Me.tbInquilino.Size = New System.Drawing.Size(263, 20)
      Me.tbInquilino.TabIndex = 95
      '
      'btnGenerar
      '
      Me.btnGenerar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btnGenerar.Location = New System.Drawing.Point(256, 428)
      Me.btnGenerar.Name = "btnGenerar"
      Me.btnGenerar.Size = New System.Drawing.Size(59, 27)
      Me.btnGenerar.TabIndex = 96
      Me.btnGenerar.Text = "&Generar"
      Me.btnGenerar.UseVisualStyleBackColor = True
      '
      'frmPropConc
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(775, 458)
      Me.Controls.Add(Me.btnGenerar)
      Me.Controls.Add(Me.tbInquilino)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.cmdListado)
      Me.Controls.Add(Me.cmdSalir)
      Me.Controls.Add(Me.cmdEdicion)
      Me.Controls.Add(Me.cmdcmdSalir)
      Me.Controls.Add(Me.cmdBaja)
      Me.Controls.Add(Me.cmdImprimir)
      Me.Controls.Add(Me.cmdAlta)
      Me.Controls.Add(Me.DataGridView1)
      Me.Controls.Add(Me.chkTodos)
      Me.Controls.Add(Me.cbPropiedad)
      Me.Controls.Add(Me.Label9)
      Me.Controls.Add(Me.cbPropietario)
      Me.Controls.Add(Me.Label1)
      Me.KeyPreview = True
      Me.Name = "frmPropConc"
      Me.Text = "Conceptos Fijos"
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents cbPropietario As System.Windows.Forms.ComboBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents cbPropiedad As System.Windows.Forms.ComboBox
   Friend WithEvents Label9 As System.Windows.Forms.Label
   Friend WithEvents chkTodos As System.Windows.Forms.CheckBox
   Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
   Friend WithEvents cmdEdicion As System.Windows.Forms.Button
   Friend WithEvents cmdcmdSalir As System.Windows.Forms.Button
   Friend WithEvents cmdBaja As System.Windows.Forms.Button
   Friend WithEvents cmdImprimir As System.Windows.Forms.Button
   Friend WithEvents cmdAlta As System.Windows.Forms.Button
   Friend WithEvents cmdSalir As System.Windows.Forms.Button
   Friend WithEvents cmdListado As System.Windows.Forms.Button
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents tbInquilino As System.Windows.Forms.TextBox
   Friend WithEvents btnGenerar As System.Windows.Forms.Button
End Class
