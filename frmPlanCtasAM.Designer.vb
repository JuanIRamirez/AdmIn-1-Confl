<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPlanCtasAM
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
      Me.cbCtaMadre = New System.Windows.Forms.ComboBox()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.tbCtaMadre = New System.Windows.Forms.TextBox()
      Me.lblDNI = New System.Windows.Forms.Label()
      Me.tbCuenta = New System.Windows.Forms.TextBox()
      Me.tbCtaAbrev = New System.Windows.Forms.TextBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.tbDescrip = New System.Windows.Forms.TextBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.tbDescAbrev = New System.Windows.Forms.TextBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.chkRecAsi = New System.Windows.Forms.CheckBox()
      Me.GroupBox1 = New System.Windows.Forms.GroupBox()
      Me.rbHaber = New System.Windows.Forms.RadioButton()
      Me.rbDebe = New System.Windows.Forms.RadioButton()
      Me.cmdCancelar = New System.Windows.Forms.Button()
      Me.cmdAceptar = New System.Windows.Forms.Button()
      Me.GroupBox1.SuspendLayout()
      Me.SuspendLayout()
      '
      'cbCtaMadre
      '
      Me.cbCtaMadre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbCtaMadre.FormattingEnabled = True
      Me.cbCtaMadre.Location = New System.Drawing.Point(196, 17)
      Me.cbCtaMadre.Name = "cbCtaMadre"
      Me.cbCtaMadre.Size = New System.Drawing.Size(433, 21)
      Me.cbCtaMadre.TabIndex = 1
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(12, 20)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(77, 13)
      Me.Label4.TabIndex = 94
      Me.Label4.Text = "Cuenta Madre:"
      '
      'tbCtaMadre
      '
      Me.tbCtaMadre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.tbCtaMadre.Location = New System.Drawing.Point(95, 17)
      Me.tbCtaMadre.MaxLength = 11
      Me.tbCtaMadre.Name = "tbCtaMadre"
      Me.tbCtaMadre.Size = New System.Drawing.Size(95, 20)
      Me.tbCtaMadre.TabIndex = 0
      '
      'lblDNI
      '
      Me.lblDNI.AutoSize = True
      Me.lblDNI.Location = New System.Drawing.Point(12, 62)
      Me.lblDNI.Name = "lblDNI"
      Me.lblDNI.Size = New System.Drawing.Size(44, 13)
      Me.lblDNI.TabIndex = 96
      Me.lblDNI.Text = "Cuenta:"
      '
      'tbCuenta
      '
      Me.tbCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.tbCuenta.Location = New System.Drawing.Point(95, 59)
      Me.tbCuenta.MaxLength = 10
      Me.tbCuenta.Name = "tbCuenta"
      Me.tbCuenta.Size = New System.Drawing.Size(95, 20)
      Me.tbCuenta.TabIndex = 2
      '
      'tbCtaAbrev
      '
      Me.tbCtaAbrev.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.tbCtaAbrev.Location = New System.Drawing.Point(145, 88)
      Me.tbCtaAbrev.MaxLength = 4
      Me.tbCtaAbrev.Name = "tbCtaAbrev"
      Me.tbCtaAbrev.Size = New System.Drawing.Size(45, 20)
      Me.tbCtaAbrev.TabIndex = 3
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(12, 91)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(80, 13)
      Me.Label1.TabIndex = 98
      Me.Label1.Text = "Cta. Abreviada:"
      '
      'tbDescrip
      '
      Me.tbDescrip.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.tbDescrip.Location = New System.Drawing.Point(95, 124)
      Me.tbDescrip.MaxLength = 50
      Me.tbDescrip.Name = "tbDescrip"
      Me.tbDescrip.Size = New System.Drawing.Size(534, 20)
      Me.tbDescrip.TabIndex = 4
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(12, 127)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(66, 13)
      Me.Label2.TabIndex = 100
      Me.Label2.Text = "Descripción:"
      '
      'tbDescAbrev
      '
      Me.tbDescAbrev.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.tbDescAbrev.Location = New System.Drawing.Point(107, 155)
      Me.tbDescAbrev.MaxLength = 10
      Me.tbDescAbrev.Name = "tbDescAbrev"
      Me.tbDescAbrev.Size = New System.Drawing.Size(95, 20)
      Me.tbDescAbrev.TabIndex = 5
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(12, 158)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(89, 13)
      Me.Label3.TabIndex = 102
      Me.Label3.Text = "Desc. Abreviada:"
      '
      'chkRecAsi
      '
      Me.chkRecAsi.AutoSize = True
      Me.chkRecAsi.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.chkRecAsi.Location = New System.Drawing.Point(12, 199)
      Me.chkRecAsi.Name = "chkRecAsi"
      Me.chkRecAsi.Size = New System.Drawing.Size(103, 17)
      Me.chkRecAsi.TabIndex = 6
      Me.chkRecAsi.Text = "&Recibe Asientos"
      Me.chkRecAsi.UseVisualStyleBackColor = True
      '
      'GroupBox1
      '
      Me.GroupBox1.Controls.Add(Me.rbHaber)
      Me.GroupBox1.Controls.Add(Me.rbDebe)
      Me.GroupBox1.Location = New System.Drawing.Point(15, 237)
      Me.GroupBox1.Name = "GroupBox1"
      Me.GroupBox1.Size = New System.Drawing.Size(253, 83)
      Me.GroupBox1.TabIndex = 7
      Me.GroupBox1.TabStop = False
      Me.GroupBox1.Text = "Saldo Habitual"
      '
      'rbHaber
      '
      Me.rbHaber.AutoSize = True
      Me.rbHaber.Location = New System.Drawing.Point(181, 36)
      Me.rbHaber.Name = "rbHaber"
      Me.rbHaber.Size = New System.Drawing.Size(54, 17)
      Me.rbHaber.TabIndex = 1
      Me.rbHaber.TabStop = True
      Me.rbHaber.Text = "Haber"
      Me.rbHaber.UseVisualStyleBackColor = True
      '
      'rbDebe
      '
      Me.rbDebe.AutoSize = True
      Me.rbDebe.Location = New System.Drawing.Point(80, 36)
      Me.rbDebe.Name = "rbDebe"
      Me.rbDebe.Size = New System.Drawing.Size(51, 17)
      Me.rbDebe.TabIndex = 0
      Me.rbDebe.TabStop = True
      Me.rbDebe.Text = "Debe"
      Me.rbDebe.UseVisualStyleBackColor = True
      '
      'cmdCancelar
      '
      Me.cmdCancelar.Location = New System.Drawing.Point(567, 293)
      Me.cmdCancelar.Name = "cmdCancelar"
      Me.cmdCancelar.Size = New System.Drawing.Size(62, 27)
      Me.cmdCancelar.TabIndex = 9
      Me.cmdCancelar.Text = "&Cancelar"
      Me.cmdCancelar.UseVisualStyleBackColor = True
      '
      'cmdAceptar
      '
      Me.cmdAceptar.Location = New System.Drawing.Point(484, 293)
      Me.cmdAceptar.Name = "cmdAceptar"
      Me.cmdAceptar.Size = New System.Drawing.Size(77, 27)
      Me.cmdAceptar.TabIndex = 8
      Me.cmdAceptar.Text = "&Aceptar"
      Me.cmdAceptar.UseVisualStyleBackColor = True
      '
      'frmPlanCtasAM
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(641, 334)
      Me.Controls.Add(Me.cmdCancelar)
      Me.Controls.Add(Me.cmdAceptar)
      Me.Controls.Add(Me.GroupBox1)
      Me.Controls.Add(Me.chkRecAsi)
      Me.Controls.Add(Me.tbDescAbrev)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.tbDescrip)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.tbCtaAbrev)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.tbCuenta)
      Me.Controls.Add(Me.tbCtaMadre)
      Me.Controls.Add(Me.lblDNI)
      Me.Controls.Add(Me.cbCtaMadre)
      Me.Controls.Add(Me.Label4)
      Me.KeyPreview = True
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "frmPlanCtasAM"
      Me.Text = "Plan de Cuentas"
      Me.GroupBox1.ResumeLayout(False)
      Me.GroupBox1.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents cbCtaMadre As System.Windows.Forms.ComboBox
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents tbCtaMadre As System.Windows.Forms.TextBox
   Friend WithEvents lblDNI As System.Windows.Forms.Label
   Friend WithEvents tbCuenta As System.Windows.Forms.TextBox
   Friend WithEvents tbCtaAbrev As System.Windows.Forms.TextBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents tbDescrip As System.Windows.Forms.TextBox
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents tbDescAbrev As System.Windows.Forms.TextBox
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents chkRecAsi As System.Windows.Forms.CheckBox
   Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents rbHaber As System.Windows.Forms.RadioButton
   Friend WithEvents rbDebe As System.Windows.Forms.RadioButton
   Friend WithEvents cmdCancelar As System.Windows.Forms.Button
   Friend WithEvents cmdAceptar As System.Windows.Forms.Button
End Class
