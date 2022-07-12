<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCodigoAut
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
      Me.tbCodigoAut = New System.Windows.Forms.TextBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.cmdAceptar = New System.Windows.Forms.Button()
      Me.cmdCancelar = New System.Windows.Forms.Button()
      Me.lblMensaje = New System.Windows.Forms.Label()
      Me.SuspendLayout()
      '
      'tbCodigoAut
      '
      Me.tbCodigoAut.Location = New System.Drawing.Point(148, 88)
      Me.tbCodigoAut.MaxLength = 50
      Me.tbCodigoAut.Name = "tbCodigoAut"
      Me.tbCodigoAut.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
      Me.tbCodigoAut.Size = New System.Drawing.Size(252, 20)
      Me.tbCodigoAut.TabIndex = 0
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(48, 91)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(94, 13)
      Me.Label2.TabIndex = 4
      Me.Label2.Text = "Código supervisor:"
      '
      'cmdAceptar
      '
      Me.cmdAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdAceptar.Location = New System.Drawing.Point(272, 153)
      Me.cmdAceptar.Name = "cmdAceptar"
      Me.cmdAceptar.Size = New System.Drawing.Size(75, 23)
      Me.cmdAceptar.TabIndex = 1
      Me.cmdAceptar.Text = "&Aceptar"
      Me.cmdAceptar.UseVisualStyleBackColor = True
      '
      'cmdCancelar
      '
      Me.cmdCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.cmdCancelar.Location = New System.Drawing.Point(353, 153)
      Me.cmdCancelar.Name = "cmdCancelar"
      Me.cmdCancelar.Size = New System.Drawing.Size(75, 23)
      Me.cmdCancelar.TabIndex = 2
      Me.cmdCancelar.Text = "&Cancelar"
      Me.cmdCancelar.UseVisualStyleBackColor = True
      '
      'lblMensaje
      '
      Me.lblMensaje.AutoSize = True
      Me.lblMensaje.Location = New System.Drawing.Point(26, 33)
      Me.lblMensaje.Name = "lblMensaje"
      Me.lblMensaje.Size = New System.Drawing.Size(47, 13)
      Me.lblMensaje.TabIndex = 5
      Me.lblMensaje.Text = "Mensaje"
      '
      'frmCodigoAut
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(450, 197)
      Me.Controls.Add(Me.lblMensaje)
      Me.Controls.Add(Me.cmdAceptar)
      Me.Controls.Add(Me.cmdCancelar)
      Me.Controls.Add(Me.tbCodigoAut)
      Me.Controls.Add(Me.Label2)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "frmCodigoAut"
      Me.Text = "Código Autorización"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents tbCodigoAut As System.Windows.Forms.TextBox
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents cmdAceptar As System.Windows.Forms.Button
   Friend WithEvents cmdCancelar As System.Windows.Forms.Button
   Friend WithEvents lblMensaje As System.Windows.Forms.Label
End Class
