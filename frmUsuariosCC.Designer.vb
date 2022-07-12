<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUsuariosCC
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
      Me.tbContraseñaR = New System.Windows.Forms.TextBox()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.tbContraseña = New System.Windows.Forms.TextBox()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.tbNombre = New System.Windows.Forms.TextBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.tbUsuario = New System.Windows.Forms.TextBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.tbContrAct = New System.Windows.Forms.TextBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.cmdAceptar = New System.Windows.Forms.Button()
      Me.cmdCancelar = New System.Windows.Forms.Button()
      Me.SuspendLayout()
      '
      'tbContraseñaR
      '
      Me.tbContraseñaR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.tbContraseñaR.Location = New System.Drawing.Point(138, 200)
      Me.tbContraseñaR.MaxLength = 50
      Me.tbContraseñaR.Name = "tbContraseñaR"
      Me.tbContraseñaR.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
      Me.tbContraseñaR.Size = New System.Drawing.Size(199, 20)
      Me.tbContraseñaR.TabIndex = 2
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.Location = New System.Drawing.Point(31, 203)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(101, 13)
      Me.Label5.TabIndex = 115
      Me.Label5.Text = "Repetir Contraseña:"
      '
      'tbContraseña
      '
      Me.tbContraseña.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.tbContraseña.Location = New System.Drawing.Point(138, 164)
      Me.tbContraseña.MaxLength = 50
      Me.tbContraseña.Name = "tbContraseña"
      Me.tbContraseña.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
      Me.tbContraseña.Size = New System.Drawing.Size(199, 20)
      Me.tbContraseña.TabIndex = 1
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(33, 167)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(99, 13)
      Me.Label4.TabIndex = 114
      Me.Label4.Text = "Nueva Contraseña:"
      '
      'tbNombre
      '
      Me.tbNombre.BackColor = System.Drawing.Color.LightYellow
      Me.tbNombre.Enabled = False
      Me.tbNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.tbNombre.Location = New System.Drawing.Point(138, 84)
      Me.tbNombre.MaxLength = 50
      Me.tbNombre.Name = "tbNombre"
      Me.tbNombre.Size = New System.Drawing.Size(318, 20)
      Me.tbNombre.TabIndex = 109
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(85, 87)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(47, 13)
      Me.Label3.TabIndex = 113
      Me.Label3.Text = "Nombre:"
      '
      'tbUsuario
      '
      Me.tbUsuario.BackColor = System.Drawing.Color.LightYellow
      Me.tbUsuario.Enabled = False
      Me.tbUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.tbUsuario.Location = New System.Drawing.Point(138, 54)
      Me.tbUsuario.MaxLength = 50
      Me.tbUsuario.Name = "tbUsuario"
      Me.tbUsuario.Size = New System.Drawing.Size(139, 20)
      Me.tbUsuario.TabIndex = 108
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(86, 57)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(46, 13)
      Me.Label1.TabIndex = 112
      Me.Label1.Text = "Usuario:"
      '
      'tbContrAct
      '
      Me.tbContrAct.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.tbContrAct.Location = New System.Drawing.Point(138, 128)
      Me.tbContrAct.MaxLength = 50
      Me.tbContrAct.Name = "tbContrAct"
      Me.tbContrAct.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
      Me.tbContrAct.Size = New System.Drawing.Size(199, 20)
      Me.tbContrAct.TabIndex = 0
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(35, 131)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(97, 13)
      Me.Label2.TabIndex = 117
      Me.Label2.Text = "Contraseña Actual:"
      '
      'cmdAceptar
      '
      Me.cmdAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdAceptar.Location = New System.Drawing.Point(345, 292)
      Me.cmdAceptar.Name = "cmdAceptar"
      Me.cmdAceptar.Size = New System.Drawing.Size(85, 25)
      Me.cmdAceptar.TabIndex = 3
      Me.cmdAceptar.Text = "&Cambiar"
      Me.cmdAceptar.UseVisualStyleBackColor = True
      '
      'cmdCancelar
      '
      Me.cmdCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdCancelar.Location = New System.Drawing.Point(436, 292)
      Me.cmdCancelar.Name = "cmdCancelar"
      Me.cmdCancelar.Size = New System.Drawing.Size(65, 25)
      Me.cmdCancelar.TabIndex = 4
      Me.cmdCancelar.Text = "&Cancelar"
      Me.cmdCancelar.UseVisualStyleBackColor = True
      '
      'frmUsuariosCC
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(513, 329)
      Me.Controls.Add(Me.cmdAceptar)
      Me.Controls.Add(Me.cmdCancelar)
      Me.Controls.Add(Me.tbContrAct)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.tbContraseñaR)
      Me.Controls.Add(Me.Label5)
      Me.Controls.Add(Me.tbContraseña)
      Me.Controls.Add(Me.Label4)
      Me.Controls.Add(Me.tbNombre)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.tbUsuario)
      Me.Controls.Add(Me.Label1)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.KeyPreview = True
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "frmUsuariosCC"
      Me.Text = "Cambiar Contraseña"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents tbContraseñaR As System.Windows.Forms.TextBox
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents tbContraseña As System.Windows.Forms.TextBox
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents tbNombre As System.Windows.Forms.TextBox
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents tbUsuario As System.Windows.Forms.TextBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents tbContrAct As System.Windows.Forms.TextBox
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents cmdAceptar As System.Windows.Forms.Button
   Friend WithEvents cmdCancelar As System.Windows.Forms.Button
End Class
