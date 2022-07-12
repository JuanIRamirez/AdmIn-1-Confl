<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmUsuarios
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
      Me.DataGridView1 = New System.Windows.Forms.DataGridView()
      Me.tbBuscar = New System.Windows.Forms.TextBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.cmdEdicion = New System.Windows.Forms.Button()
      Me.cmdBaja = New System.Windows.Forms.Button()
      Me.cmdAlta = New System.Windows.Forms.Button()
      Me.tbUsuario = New System.Windows.Forms.TextBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.tbNombre = New System.Windows.Forms.TextBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.tbContraseña = New System.Windows.Forms.TextBox()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.tbContraseñaR = New System.Windows.Forms.TextBox()
      Me.optParciales = New System.Windows.Forms.RadioButton()
      Me.optTotales = New System.Windows.Forms.RadioButton()
      Me.chkAdmin = New System.Windows.Forms.CheckBox()
      Me.cmdAceptar = New System.Windows.Forms.Button()
      Me.cmdCancelar = New System.Windows.Forms.Button()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.cmdSalir = New System.Windows.Forms.Button()
      Me.btnPwd = New System.Windows.Forms.Button()
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
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
      Me.DataGridView1.Location = New System.Drawing.Point(11, 32)
      Me.DataGridView1.Name = "DataGridView1"
      Me.DataGridView1.ReadOnly = True
      Me.DataGridView1.RowTemplate.ReadOnly = True
      Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.DataGridView1.Size = New System.Drawing.Size(642, 263)
      Me.DataGridView1.TabIndex = 1
      '
      'tbBuscar
      '
      Me.tbBuscar.Enabled = False
      Me.tbBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.tbBuscar.Location = New System.Drawing.Point(61, 6)
      Me.tbBuscar.Name = "tbBuscar"
      Me.tbBuscar.Size = New System.Drawing.Size(245, 20)
      Me.tbBuscar.TabIndex = 0
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(12, 9)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(43, 13)
      Me.Label2.TabIndex = 96
      Me.Label2.Text = "Buscar:"
      '
      'cmdEdicion
      '
      Me.cmdEdicion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdEdicion.Location = New System.Drawing.Point(137, 301)
      Me.cmdEdicion.Name = "cmdEdicion"
      Me.cmdEdicion.Size = New System.Drawing.Size(66, 27)
      Me.cmdEdicion.TabIndex = 4
      Me.cmdEdicion.Text = "&Modificar"
      Me.cmdEdicion.UseVisualStyleBackColor = True
      '
      'cmdBaja
      '
      Me.cmdBaja.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdBaja.Location = New System.Drawing.Point(75, 301)
      Me.cmdBaja.Name = "cmdBaja"
      Me.cmdBaja.Size = New System.Drawing.Size(56, 27)
      Me.cmdBaja.TabIndex = 3
      Me.cmdBaja.Text = "&Baja"
      Me.cmdBaja.UseVisualStyleBackColor = True
      '
      'cmdAlta
      '
      Me.cmdAlta.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdAlta.Location = New System.Drawing.Point(11, 301)
      Me.cmdAlta.Name = "cmdAlta"
      Me.cmdAlta.Size = New System.Drawing.Size(58, 27)
      Me.cmdAlta.TabIndex = 2
      Me.cmdAlta.Text = "&Alta"
      Me.cmdAlta.UseVisualStyleBackColor = True
      '
      'tbUsuario
      '
      Me.tbUsuario.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.tbUsuario.Enabled = False
      Me.tbUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.tbUsuario.Location = New System.Drawing.Point(118, 344)
      Me.tbUsuario.MaxLength = 50
      Me.tbUsuario.Name = "tbUsuario"
      Me.tbUsuario.Size = New System.Drawing.Size(139, 20)
      Me.tbUsuario.TabIndex = 5
      '
      'Label1
      '
      Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(66, 347)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(46, 13)
      Me.Label1.TabIndex = 101
      Me.Label1.Text = "Usuario:"
      '
      'tbNombre
      '
      Me.tbNombre.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.tbNombre.Enabled = False
      Me.tbNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.tbNombre.Location = New System.Drawing.Point(118, 374)
      Me.tbNombre.MaxLength = 50
      Me.tbNombre.Name = "tbNombre"
      Me.tbNombre.Size = New System.Drawing.Size(318, 20)
      Me.tbNombre.TabIndex = 6
      '
      'Label3
      '
      Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(65, 377)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(47, 13)
      Me.Label3.TabIndex = 103
      Me.Label3.Text = "Nombre:"
      '
      'tbContraseña
      '
      Me.tbContraseña.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.tbContraseña.Enabled = False
      Me.tbContraseña.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.tbContraseña.Location = New System.Drawing.Point(118, 401)
      Me.tbContraseña.MaxLength = 50
      Me.tbContraseña.Name = "tbContraseña"
      Me.tbContraseña.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
      Me.tbContraseña.Size = New System.Drawing.Size(199, 20)
      Me.tbContraseña.TabIndex = 7
      '
      'Label4
      '
      Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(48, 404)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(64, 13)
      Me.Label4.TabIndex = 105
      Me.Label4.Text = "Contraseña:"
      '
      'Label5
      '
      Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.Label5.AutoSize = True
      Me.Label5.Location = New System.Drawing.Point(11, 431)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(101, 13)
      Me.Label5.TabIndex = 107
      Me.Label5.Text = "Repetir Contraseña:"
      '
      'tbContraseñaR
      '
      Me.tbContraseñaR.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.tbContraseñaR.Enabled = False
      Me.tbContraseñaR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.tbContraseñaR.Location = New System.Drawing.Point(118, 428)
      Me.tbContraseñaR.MaxLength = 50
      Me.tbContraseñaR.Name = "tbContraseñaR"
      Me.tbContraseñaR.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
      Me.tbContraseñaR.Size = New System.Drawing.Size(199, 20)
      Me.tbContraseñaR.TabIndex = 8
      '
      'optParciales
      '
      Me.optParciales.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.optParciales.AutoSize = True
      Me.optParciales.Checked = True
      Me.optParciales.Enabled = False
      Me.optParciales.Location = New System.Drawing.Point(118, 459)
      Me.optParciales.Name = "optParciales"
      Me.optParciales.Size = New System.Drawing.Size(68, 17)
      Me.optParciales.TabIndex = 9
      Me.optParciales.TabStop = True
      Me.optParciales.Text = "&Parciales"
      Me.optParciales.UseVisualStyleBackColor = True
      '
      'optTotales
      '
      Me.optTotales.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.optTotales.AutoSize = True
      Me.optTotales.Enabled = False
      Me.optTotales.Location = New System.Drawing.Point(209, 459)
      Me.optTotales.Name = "optTotales"
      Me.optTotales.Size = New System.Drawing.Size(60, 17)
      Me.optTotales.TabIndex = 10
      Me.optTotales.Text = "&Totales"
      Me.optTotales.UseVisualStyleBackColor = True
      '
      'chkAdmin
      '
      Me.chkAdmin.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.chkAdmin.AutoSize = True
      Me.chkAdmin.Enabled = False
      Me.chkAdmin.Location = New System.Drawing.Point(299, 460)
      Me.chkAdmin.Name = "chkAdmin"
      Me.chkAdmin.Size = New System.Drawing.Size(89, 17)
      Me.chkAdmin.TabIndex = 11
      Me.chkAdmin.Text = "Administrador"
      Me.chkAdmin.UseVisualStyleBackColor = True
      '
      'cmdAceptar
      '
      Me.cmdAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdAceptar.Enabled = False
      Me.cmdAceptar.Location = New System.Drawing.Point(497, 488)
      Me.cmdAceptar.Name = "cmdAceptar"
      Me.cmdAceptar.Size = New System.Drawing.Size(85, 25)
      Me.cmdAceptar.TabIndex = 12
      Me.cmdAceptar.Text = "&Guardar"
      Me.cmdAceptar.UseVisualStyleBackColor = True
      '
      'cmdCancelar
      '
      Me.cmdCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdCancelar.Enabled = False
      Me.cmdCancelar.Location = New System.Drawing.Point(588, 488)
      Me.cmdCancelar.Name = "cmdCancelar"
      Me.cmdCancelar.Size = New System.Drawing.Size(65, 25)
      Me.cmdCancelar.TabIndex = 13
      Me.cmdCancelar.Text = "&Cancelar"
      Me.cmdCancelar.UseVisualStyleBackColor = True
      '
      'Label6
      '
      Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.Label6.AutoSize = True
      Me.Label6.Location = New System.Drawing.Point(57, 461)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(52, 13)
      Me.Label6.TabIndex = 112
      Me.Label6.Text = "Permisos:"
      '
      'cmdSalir
      '
      Me.cmdSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.cmdSalir.Location = New System.Drawing.Point(593, 301)
      Me.cmdSalir.Name = "cmdSalir"
      Me.cmdSalir.Size = New System.Drawing.Size(60, 27)
      Me.cmdSalir.TabIndex = 15
      Me.cmdSalir.Text = "&Salir"
      Me.cmdSalir.UseVisualStyleBackColor = True
      '
      'btnPwd
      '
      Me.btnPwd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btnPwd.Location = New System.Drawing.Point(240, 301)
      Me.btnPwd.Name = "btnPwd"
      Me.btnPwd.Size = New System.Drawing.Size(123, 27)
      Me.btnPwd.TabIndex = 113
      Me.btnPwd.Text = "&Cambiar Contraseña"
      Me.btnPwd.UseVisualStyleBackColor = True
      '
      'FrmUsuarios
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me.cmdSalir
      Me.ClientSize = New System.Drawing.Size(666, 521)
      Me.Controls.Add(Me.btnPwd)
      Me.Controls.Add(Me.cmdSalir)
      Me.Controls.Add(Me.Label6)
      Me.Controls.Add(Me.chkAdmin)
      Me.Controls.Add(Me.cmdAceptar)
      Me.Controls.Add(Me.optTotales)
      Me.Controls.Add(Me.cmdCancelar)
      Me.Controls.Add(Me.optParciales)
      Me.Controls.Add(Me.tbContraseñaR)
      Me.Controls.Add(Me.Label5)
      Me.Controls.Add(Me.tbContraseña)
      Me.Controls.Add(Me.Label4)
      Me.Controls.Add(Me.tbNombre)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.tbUsuario)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.cmdEdicion)
      Me.Controls.Add(Me.cmdBaja)
      Me.Controls.Add(Me.cmdAlta)
      Me.Controls.Add(Me.tbBuscar)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.DataGridView1)
      Me.Name = "FrmUsuarios"
      Me.Text = "Usuarios"
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
   Friend WithEvents tbBuscar As System.Windows.Forms.TextBox
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents cmdEdicion As System.Windows.Forms.Button
   Friend WithEvents cmdBaja As System.Windows.Forms.Button
   Friend WithEvents cmdAlta As System.Windows.Forms.Button
   Friend WithEvents tbUsuario As System.Windows.Forms.TextBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents tbNombre As System.Windows.Forms.TextBox
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents tbContraseña As System.Windows.Forms.TextBox
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents tbContraseñaR As System.Windows.Forms.TextBox
   Friend WithEvents chkAdmin As System.Windows.Forms.CheckBox
   Friend WithEvents optTotales As System.Windows.Forms.RadioButton
   Friend WithEvents optParciales As System.Windows.Forms.RadioButton
   Friend WithEvents cmdAceptar As System.Windows.Forms.Button
   Friend WithEvents cmdCancelar As System.Windows.Forms.Button
   Friend WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents cmdSalir As System.Windows.Forms.Button
   Friend WithEvents btnPwd As Button
End Class
