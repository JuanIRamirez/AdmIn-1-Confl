<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmEnviarEmail
   Inherits System.Windows.Forms.Form

   'Form overrides dispose to clean up the component list.
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

   'Required by the Windows Form Designer
   Private components As System.ComponentModel.IContainer

   'NOTE: The following procedure is required by the Windows Form Designer
   'It can be modified using the Windows Form Designer.  
   'Do not modify it using the code editor.
   <System.Diagnostics.DebuggerStepThrough()>
   Private Sub InitializeComponent()
      Me.btnCancelar = New System.Windows.Forms.Button()
      Me.btnAceptar = New System.Windows.Forms.Button()
      Me.tbEmail = New System.Windows.Forms.TextBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.tbAsunto = New System.Windows.Forms.TextBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.tbCopiaA = New System.Windows.Forms.TextBox()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.tbCuerpo = New System.Windows.Forms.TextBox()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.PictureBox1 = New System.Windows.Forms.PictureBox()
      Me.LbAdjuntos = New System.Windows.Forms.ListBox()
      Me.Label6 = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.btnAgregar = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.Location = New System.Drawing.Point(775, 487)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(72, 25)
        Me.btnCancelar.TabIndex = 107
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.Location = New System.Drawing.Point(672, 487)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(97, 25)
        Me.btnAceptar.TabIndex = 106
        Me.btnAceptar.Text = "&Enviar >>"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'tbEmail
        '
        Me.tbEmail.Location = New System.Drawing.Point(330, 12)
        Me.tbEmail.MaxLength = 50
        Me.tbEmail.Name = "tbEmail"
        Me.tbEmail.Size = New System.Drawing.Size(518, 20)
        Me.tbEmail.TabIndex = 110
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(255, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 111
        Me.Label2.Text = "Destinatario:"
        '
        'tbAsunto
        '
        Me.tbAsunto.Location = New System.Drawing.Point(330, 82)
        Me.tbAsunto.MaxLength = 50
        Me.tbAsunto.Name = "tbAsunto"
        Me.tbAsunto.Size = New System.Drawing.Size(518, 20)
        Me.tbAsunto.TabIndex = 112
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(278, 85)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 113
        Me.Label3.Text = "Asunto:"
        '
        'tbCopiaA
        '
        Me.tbCopiaA.Location = New System.Drawing.Point(330, 38)
        Me.tbCopiaA.MaxLength = 50
        Me.tbCopiaA.Name = "tbCopiaA"
        Me.tbCopiaA.Size = New System.Drawing.Size(518, 20)
        Me.tbCopiaA.TabIndex = 114
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(275, 41)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 13)
        Me.Label4.TabIndex = 115
        Me.Label4.Text = "Copia a:"
        '
        'tbCuerpo
        '
        Me.tbCuerpo.Location = New System.Drawing.Point(330, 119)
        Me.tbCuerpo.MaxLength = 50
        Me.tbCuerpo.Multiline = True
        Me.tbCuerpo.Name = "tbCuerpo"
        Me.tbCuerpo.Size = New System.Drawing.Size(518, 362)
        Me.tbCuerpo.TabIndex = 116
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(278, 122)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 13)
        Me.Label5.TabIndex = 117
        Me.Label5.Text = "Cuerpo:"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.AdmIn.My.Resources.Resources.Email
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(227, 230)
        Me.PictureBox1.TabIndex = 118
        Me.PictureBox1.TabStop = False
        '
        'LbAdjuntos
        '
        Me.LbAdjuntos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbAdjuntos.FormattingEnabled = True
        Me.LbAdjuntos.Location = New System.Drawing.Point(12, 347)
        Me.LbAdjuntos.Name = "LbAdjuntos"
        Me.LbAdjuntos.Size = New System.Drawing.Size(227, 134)
        Me.LbAdjuntos.TabIndex = 119
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 331)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(102, 13)
        Me.Label6.TabIndex = 120
        Me.Label6.Text = "Archivo/s Adjunto/s"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'btnAgregar
        '
        Me.btnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAgregar.Location = New System.Drawing.Point(167, 320)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(72, 21)
        Me.btnAgregar.TabIndex = 121
        Me.btnAgregar.Text = "&Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'FrmEnviarEmail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(865, 526)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.LbAdjuntos)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.tbCuerpo)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.tbCopiaA)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.tbAsunto)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tbEmail)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.KeyPreview = True
        Me.Name = "FrmEnviarEmail"
        Me.Text = "Enviar e-mail"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblBanco As System.Windows.Forms.Label
   Friend WithEvents cbCtaCaja As System.Windows.Forms.ComboBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents cbCtaCajaAd As System.Windows.Forms.ComboBox
   Friend WithEvents btnCancelar As System.Windows.Forms.Button
   Friend WithEvents btnAceptar As System.Windows.Forms.Button
   Friend WithEvents tbEmail As System.Windows.Forms.TextBox
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents tbAsunto As System.Windows.Forms.TextBox
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents tbCopiaA As TextBox
   Friend WithEvents Label4 As Label
   Friend WithEvents tbCuerpo As TextBox
   Friend WithEvents Label5 As Label
   Friend WithEvents PictureBox1 As PictureBox
   Friend WithEvents LbAdjuntos As ListBox
   Friend WithEvents Label6 As Label
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents btnAgregar As Button
End Class
