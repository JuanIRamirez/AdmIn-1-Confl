<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmLogin
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLogin))
      Me.btnAceptar = New System.Windows.Forms.Button()
      Me.btnCancelar = New System.Windows.Forms.Button()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.tbUsuario = New System.Windows.Forms.TextBox()
      Me.tbContraseña = New System.Windows.Forms.TextBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.chkTruCnx = New System.Windows.Forms.CheckBox()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.tbServidor = New System.Windows.Forms.TextBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.tbCatalogo = New System.Windows.Forms.TextBox()
      Me.tbDbTemp = New System.Windows.Forms.TextBox()
      Me.tbReportes = New System.Windows.Forms.TextBox()
      Me.cmdDetalles = New System.Windows.Forms.Button()
      Me.Icono = New System.Windows.Forms.PictureBox()
      Me.Label7 = New System.Windows.Forms.Label()
      Me.tbArchivoCfg = New System.Windows.Forms.TextBox()
      Me.btnValDef = New System.Windows.Forms.Button()
      Me.chkModoPrueba = New System.Windows.Forms.CheckBox()
      Me.Panel1 = New System.Windows.Forms.Panel()
        Me.tbPwdDb = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tbUserDb = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnCrearDB = New System.Windows.Forms.Button()
        CType(Me.Icono, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(446, 135)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 3
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Location = New System.Drawing.Point(529, 135)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 4
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(125, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Usuario:"
        '
        'tbUsuario
        '
        Me.tbUsuario.Location = New System.Drawing.Point(201, 30)
        Me.tbUsuario.Name = "tbUsuario"
        Me.tbUsuario.Size = New System.Drawing.Size(190, 20)
        Me.tbUsuario.TabIndex = 0
        '
        'tbContraseña
        '
        Me.tbContraseña.Location = New System.Drawing.Point(201, 67)
        Me.tbContraseña.Name = "tbContraseña"
        Me.tbContraseña.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.tbContraseña.Size = New System.Drawing.Size(190, 20)
        Me.tbContraseña.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(125, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Contraseña:"
        '
        'chkTruCnx
        '
        Me.chkTruCnx.AutoSize = True
        Me.chkTruCnx.Location = New System.Drawing.Point(16, 85)
        Me.chkTruCnx.Name = "chkTruCnx"
        Me.chkTruCnx.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkTruCnx.Size = New System.Drawing.Size(155, 17)
        Me.chkTruCnx.TabIndex = 10
        Me.chkTruCnx.Text = "Conexión de confianza       "
        Me.chkTruCnx.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(53, 175)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(93, 13)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "Carpeta Reportes:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(19, 148)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(127, 13)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "Base de Datos Temporal:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 117)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(133, 13)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Base de Datos / Catálogo:"
        '
        'tbServidor
        '
        Me.tbServidor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbServidor.Location = New System.Drawing.Point(152, 13)
        Me.tbServidor.Name = "tbServidor"
        Me.tbServidor.Size = New System.Drawing.Size(210, 20)
        Me.tbServidor.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(97, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 13)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Servidor:"
        '
        'tbCatalogo
        '
        Me.tbCatalogo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbCatalogo.Location = New System.Drawing.Point(152, 114)
        Me.tbCatalogo.Name = "tbCatalogo"
        Me.tbCatalogo.Size = New System.Drawing.Size(210, 20)
        Me.tbCatalogo.TabIndex = 11
        '
        'tbDbTemp
        '
        Me.tbDbTemp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbDbTemp.Location = New System.Drawing.Point(152, 145)
        Me.tbDbTemp.Name = "tbDbTemp"
        Me.tbDbTemp.Size = New System.Drawing.Size(428, 20)
        Me.tbDbTemp.TabIndex = 13
        '
        'tbReportes
        '
        Me.tbReportes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbReportes.Location = New System.Drawing.Point(152, 172)
        Me.tbReportes.Name = "tbReportes"
        Me.tbReportes.Size = New System.Drawing.Size(428, 20)
        Me.tbReportes.TabIndex = 14
        '
        'cmdDetalles
        '
        Me.cmdDetalles.Location = New System.Drawing.Point(18, 135)
        Me.cmdDetalles.Name = "cmdDetalles"
        Me.cmdDetalles.Size = New System.Drawing.Size(103, 23)
        Me.cmdDetalles.TabIndex = 5
        Me.cmdDetalles.Text = "&Det. Conexión"
        Me.cmdDetalles.UseVisualStyleBackColor = True
        '
        'Icono
        '
        Me.Icono.Image = CType(resources.GetObject("Icono.Image"), System.Drawing.Image)
        Me.Icono.InitialImage = CType(resources.GetObject("Icono.InitialImage"), System.Drawing.Image)
        Me.Icono.Location = New System.Drawing.Point(485, 22)
        Me.Icono.Name = "Icono"
        Me.Icono.Size = New System.Drawing.Size(75, 75)
        Me.Icono.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Icono.TabIndex = 25
        Me.Icono.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(35, 213)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(111, 13)
        Me.Label7.TabIndex = 26
        Me.Label7.Text = "Archivo config. Inicial:"
        '
        'tbArchivoCfg
        '
        Me.tbArchivoCfg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbArchivoCfg.Location = New System.Drawing.Point(152, 201)
        Me.tbArchivoCfg.Multiline = True
        Me.tbArchivoCfg.Name = "tbArchivoCfg"
        Me.tbArchivoCfg.Size = New System.Drawing.Size(428, 60)
        Me.tbArchivoCfg.TabIndex = 15
        '
        'btnValDef
        '
        Me.btnValDef.Location = New System.Drawing.Point(390, 11)
        Me.btnValDef.Name = "btnValDef"
        Me.btnValDef.Size = New System.Drawing.Size(103, 23)
        Me.btnValDef.TabIndex = 7
        Me.btnValDef.Text = "&Valores p/Defecto"
        Me.btnValDef.UseVisualStyleBackColor = True
        '
        'chkModoPrueba
        '
        Me.chkModoPrueba.AutoSize = True
        Me.chkModoPrueba.Location = New System.Drawing.Point(301, 109)
        Me.chkModoPrueba.Name = "chkModoPrueba"
        Me.chkModoPrueba.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkModoPrueba.Size = New System.Drawing.Size(90, 17)
        Me.chkModoPrueba.TabIndex = 2
        Me.chkModoPrueba.Text = "Modo &Prueba"
        Me.chkModoPrueba.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.tbPwdDb)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.tbUserDb)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.chkTruCnx)
        Me.Panel1.Controls.Add(Me.btnCrearDB)
        Me.Panel1.Controls.Add(Me.tbArchivoCfg)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.btnValDef)
        Me.Panel1.Controls.Add(Me.tbServidor)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.tbCatalogo)
        Me.Panel1.Controls.Add(Me.tbReportes)
        Me.Panel1.Controls.Add(Me.tbDbTemp)
        Me.Panel1.Location = New System.Drawing.Point(12, 199)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(594, 279)
        Me.Panel1.TabIndex = 27
        '
        'tbPwdDb
        '
        Me.tbPwdDb.Location = New System.Drawing.Point(390, 50)
        Me.tbPwdDb.Name = "tbPwdDb"
        Me.tbPwdDb.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.tbPwdDb.Size = New System.Drawing.Size(190, 20)
        Me.tbPwdDb.TabIndex = 9
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(314, 53)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(64, 13)
        Me.Label8.TabIndex = 35
        Me.Label8.Text = "Contraseña:"
        '
        'tbUserDb
        '
        Me.tbUserDb.Location = New System.Drawing.Point(152, 50)
        Me.tbUserDb.Name = "tbUserDb"
        Me.tbUserDb.Size = New System.Drawing.Size(147, 20)
        Me.tbUserDb.TabIndex = 8
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(100, 53)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(46, 13)
        Me.Label9.TabIndex = 34
        Me.Label9.Text = "Usuario:"
        '
        'btnCrearDB
        '
        Me.btnCrearDB.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCrearDB.Location = New System.Drawing.Point(390, 112)
        Me.btnCrearDB.Name = "btnCrearDB"
        Me.btnCrearDB.Size = New System.Drawing.Size(57, 23)
        Me.btnCrearDB.TabIndex = 12
        Me.btnCrearDB.Text = "&Crear"
        Me.btnCrearDB.UseVisualStyleBackColor = True
        '
        'FrmLogin
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(616, 490)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.chkModoPrueba)
        Me.Controls.Add(Me.Icono)
        Me.Controls.Add(Me.cmdDetalles)
        Me.Controls.Add(Me.tbContraseña)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tbUsuario)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login"
        CType(Me.Icono, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
   Friend WithEvents btnCancelar As System.Windows.Forms.Button
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents tbUsuario As System.Windows.Forms.TextBox
   Friend WithEvents tbContraseña As System.Windows.Forms.TextBox
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents chkTruCnx As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tbServidor As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tbCatalogo As System.Windows.Forms.TextBox
    Friend WithEvents tbDbTemp As System.Windows.Forms.TextBox
    Friend WithEvents tbReportes As System.Windows.Forms.TextBox
    Friend WithEvents cmdDetalles As System.Windows.Forms.Button
   Friend WithEvents Icono As System.Windows.Forms.PictureBox
   Friend WithEvents Label7 As System.Windows.Forms.Label
   Friend WithEvents tbArchivoCfg As System.Windows.Forms.TextBox
   Friend WithEvents btnValDef As System.Windows.Forms.Button
   Friend WithEvents chkModoPrueba As System.Windows.Forms.CheckBox
   Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnCrearDB As Button
    Friend WithEvents tbPwdDb As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents tbUserDb As TextBox
    Friend WithEvents Label9 As Label
End Class
