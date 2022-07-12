<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBancosAM
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
      Me.gbBanco = New System.Windows.Forms.GroupBox()
      Me.btnAceptar = New System.Windows.Forms.Button()
      Me.tbCodigo = New System.Windows.Forms.TextBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.tbNombre = New System.Windows.Forms.TextBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.tbDomicilio = New System.Windows.Forms.TextBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.tbTelefono = New System.Windows.Forms.TextBox()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.tbContacto = New System.Windows.Forms.TextBox()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.tbTelContacto = New System.Windows.Forms.TextBox()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.btnCancelar = New System.Windows.Forms.Button()
      Me.gbBanco.SuspendLayout()
      Me.SuspendLayout()
      '
      'gbBanco
      '
      Me.gbBanco.Controls.Add(Me.btnAceptar)
      Me.gbBanco.Controls.Add(Me.tbCodigo)
      Me.gbBanco.Controls.Add(Me.Label1)
      Me.gbBanco.Controls.Add(Me.tbNombre)
      Me.gbBanco.Controls.Add(Me.Label2)
      Me.gbBanco.Controls.Add(Me.tbDomicilio)
      Me.gbBanco.Controls.Add(Me.Label3)
      Me.gbBanco.Controls.Add(Me.tbTelefono)
      Me.gbBanco.Controls.Add(Me.Label4)
      Me.gbBanco.Controls.Add(Me.tbContacto)
      Me.gbBanco.Controls.Add(Me.Label5)
      Me.gbBanco.Controls.Add(Me.tbTelContacto)
      Me.gbBanco.Controls.Add(Me.Label6)
      Me.gbBanco.Controls.Add(Me.btnCancelar)
      Me.gbBanco.Location = New System.Drawing.Point(12, 12)
      Me.gbBanco.Name = "gbBanco"
      Me.gbBanco.Size = New System.Drawing.Size(612, 304)
      Me.gbBanco.TabIndex = 149
      Me.gbBanco.TabStop = False
      '
      'btnAceptar
      '
      Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnAceptar.Location = New System.Drawing.Point(406, 275)
      Me.btnAceptar.Name = "btnAceptar"
      Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
      Me.btnAceptar.TabIndex = 6
      Me.btnAceptar.Text = "&Aceptar"
      Me.btnAceptar.UseVisualStyleBackColor = True
      '
      'tbCodigo
      '
      Me.tbCodigo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tbCodigo.Location = New System.Drawing.Point(195, 52)
      Me.tbCodigo.MaxLength = 10
      Me.tbCodigo.Name = "tbCodigo"
      Me.tbCodigo.Size = New System.Drawing.Size(74, 20)
      Me.tbCodigo.TabIndex = 0
      '
      'Label1
      '
      Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(146, 55)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(43, 13)
      Me.Label1.TabIndex = 118
      Me.Label1.Text = "Código:"
      '
      'tbNombre
      '
      Me.tbNombre.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tbNombre.Location = New System.Drawing.Point(195, 81)
      Me.tbNombre.MaxLength = 50
      Me.tbNombre.Name = "tbNombre"
      Me.tbNombre.Size = New System.Drawing.Size(342, 20)
      Me.tbNombre.TabIndex = 1
      '
      'Label2
      '
      Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(68, 84)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(121, 13)
      Me.Label2.TabIndex = 120
      Me.Label2.Text = "Nombre / Razón Social:"
      '
      'tbDomicilio
      '
      Me.tbDomicilio.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tbDomicilio.Location = New System.Drawing.Point(195, 110)
      Me.tbDomicilio.MaxLength = 50
      Me.tbDomicilio.Name = "tbDomicilio"
      Me.tbDomicilio.Size = New System.Drawing.Size(342, 20)
      Me.tbDomicilio.TabIndex = 2
      '
      'Label3
      '
      Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(136, 113)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(52, 13)
      Me.Label3.TabIndex = 122
      Me.Label3.Text = "Domicilio:"
      '
      'tbTelefono
      '
      Me.tbTelefono.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tbTelefono.Location = New System.Drawing.Point(195, 146)
      Me.tbTelefono.MaxLength = 50
      Me.tbTelefono.Name = "tbTelefono"
      Me.tbTelefono.Size = New System.Drawing.Size(255, 20)
      Me.tbTelefono.TabIndex = 3
      '
      'Label4
      '
      Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(136, 149)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(52, 13)
      Me.Label4.TabIndex = 124
      Me.Label4.Text = "Teléfono:"
      '
      'tbContacto
      '
      Me.tbContacto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tbContacto.Location = New System.Drawing.Point(195, 181)
      Me.tbContacto.MaxLength = 50
      Me.tbContacto.Name = "tbContacto"
      Me.tbContacto.Size = New System.Drawing.Size(255, 20)
      Me.tbContacto.TabIndex = 4
      '
      'Label5
      '
      Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label5.AutoSize = True
      Me.Label5.Location = New System.Drawing.Point(136, 184)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(53, 13)
      Me.Label5.TabIndex = 126
      Me.Label5.Text = "Contacto:"
      '
      'tbTelContacto
      '
      Me.tbTelContacto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tbTelContacto.Location = New System.Drawing.Point(195, 218)
      Me.tbTelContacto.MaxLength = 50
      Me.tbTelContacto.Name = "tbTelContacto"
      Me.tbTelContacto.Size = New System.Drawing.Size(231, 20)
      Me.tbTelContacto.TabIndex = 5
      '
      'Label6
      '
      Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label6.AutoSize = True
      Me.Label6.Location = New System.Drawing.Point(118, 221)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(71, 13)
      Me.Label6.TabIndex = 128
      Me.Label6.Text = "Tel.Contacto:"
      '
      'btnCancelar
      '
      Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnCancelar.Location = New System.Drawing.Point(487, 275)
      Me.btnCancelar.Name = "btnCancelar"
      Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
      Me.btnCancelar.TabIndex = 7
      Me.btnCancelar.Text = "&Cancelar"
      Me.btnCancelar.UseVisualStyleBackColor = True
      '
      'frmBancosAM
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(636, 331)
      Me.Controls.Add(Me.gbBanco)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.KeyPreview = True
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "frmBancosAM"
      Me.Text = "Bancos"
      Me.gbBanco.ResumeLayout(False)
      Me.gbBanco.PerformLayout()
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents gbBanco As System.Windows.Forms.GroupBox
   Friend WithEvents btnAceptar As System.Windows.Forms.Button
   Friend WithEvents tbCodigo As System.Windows.Forms.TextBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents tbNombre As System.Windows.Forms.TextBox
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents tbDomicilio As System.Windows.Forms.TextBox
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents tbTelefono As System.Windows.Forms.TextBox
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents tbContacto As System.Windows.Forms.TextBox
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents tbTelContacto As System.Windows.Forms.TextBox
   Friend WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents btnCancelar As System.Windows.Forms.Button
End Class
