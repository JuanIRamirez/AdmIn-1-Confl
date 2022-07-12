<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConceptosAM
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
      Me.Label3 = New System.Windows.Forms.Label()
      Me.tbCodigo = New System.Windows.Forms.TextBox()
      Me.tbDescrip = New System.Windows.Forms.TextBox()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.optDebe = New System.Windows.Forms.RadioButton()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.optHaber = New System.Windows.Forms.RadioButton()
      Me.tbPrioridad = New System.Windows.Forms.TextBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.cmdCancelar = New System.Windows.Forms.Button()
      Me.cmdAceptar = New System.Windows.Forms.Button()
      Me.cmdSalir = New System.Windows.Forms.Button()
      Me.chkComision = New System.Windows.Forms.CheckBox()
      Me.tbCtaAdm = New System.Windows.Forms.TextBox()
      Me.cbCtaAdm = New System.Windows.Forms.ComboBox()
      Me.lblCtaAdm = New System.Windows.Forms.Label()
      Me.tbCuenta = New System.Windows.Forms.TextBox()
      Me.cbCuenta = New System.Windows.Forms.ComboBox()
      Me.lblCuenta = New System.Windows.Forms.Label()
      Me.SuspendLayout()
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(52, 36)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(43, 13)
      Me.Label3.TabIndex = 43
      Me.Label3.Text = "Código:"
      '
      'tbCodigo
      '
      Me.tbCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.tbCodigo.Location = New System.Drawing.Point(105, 33)
      Me.tbCodigo.MaxLength = 3
      Me.tbCodigo.Name = "tbCodigo"
      Me.tbCodigo.Size = New System.Drawing.Size(36, 20)
      Me.tbCodigo.TabIndex = 0
      '
      'tbDescrip
      '
      Me.tbDescrip.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.tbDescrip.Location = New System.Drawing.Point(105, 71)
      Me.tbDescrip.MaxLength = 50
      Me.tbDescrip.Name = "tbDescrip"
      Me.tbDescrip.Size = New System.Drawing.Size(457, 20)
      Me.tbDescrip.TabIndex = 1
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(29, 74)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(66, 13)
      Me.Label4.TabIndex = 46
      Me.Label4.Text = "Descripción:"
      '
      'optDebe
      '
      Me.optDebe.AutoSize = True
      Me.optDebe.Checked = True
      Me.optDebe.Location = New System.Drawing.Point(105, 117)
      Me.optDebe.Name = "optDebe"
      Me.optDebe.Size = New System.Drawing.Size(51, 17)
      Me.optDebe.TabIndex = 2
      Me.optDebe.TabStop = True
      Me.optDebe.Text = "&Debe"
      Me.optDebe.UseVisualStyleBackColor = True
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(33, 119)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(62, 13)
      Me.Label1.TabIndex = 48
      Me.Label1.Text = "Imputación:"
      '
      'optHaber
      '
      Me.optHaber.AutoSize = True
      Me.optHaber.Location = New System.Drawing.Point(162, 117)
      Me.optHaber.Name = "optHaber"
      Me.optHaber.Size = New System.Drawing.Size(54, 17)
      Me.optHaber.TabIndex = 3
      Me.optHaber.Text = "&Haber"
      Me.optHaber.UseVisualStyleBackColor = True
      '
      'tbPrioridad
      '
      Me.tbPrioridad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.tbPrioridad.Location = New System.Drawing.Point(105, 158)
      Me.tbPrioridad.MaxLength = 5
      Me.tbPrioridad.Name = "tbPrioridad"
      Me.tbPrioridad.Size = New System.Drawing.Size(36, 20)
      Me.tbPrioridad.TabIndex = 4
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(37, 161)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(58, 13)
      Me.Label2.TabIndex = 50
      Me.Label2.Text = "Prioridad #"
      '
      'cmdCancelar
      '
      Me.cmdCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdCancelar.Location = New System.Drawing.Point(478, 419)
      Me.cmdCancelar.Name = "cmdCancelar"
      Me.cmdCancelar.Size = New System.Drawing.Size(76, 27)
      Me.cmdCancelar.TabIndex = 11
      Me.cmdCancelar.Text = "&Cancelar"
      Me.cmdCancelar.UseVisualStyleBackColor = True
      '
      'cmdAceptar
      '
      Me.cmdAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdAceptar.Location = New System.Drawing.Point(396, 419)
      Me.cmdAceptar.Name = "cmdAceptar"
      Me.cmdAceptar.Size = New System.Drawing.Size(76, 27)
      Me.cmdAceptar.TabIndex = 10
      Me.cmdAceptar.Text = "&Aceptar"
      Me.cmdAceptar.UseVisualStyleBackColor = True
      '
      'cmdSalir
      '
      Me.cmdSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.cmdSalir.Location = New System.Drawing.Point(560, 419)
      Me.cmdSalir.Name = "cmdSalir"
      Me.cmdSalir.Size = New System.Drawing.Size(76, 27)
      Me.cmdSalir.TabIndex = 12
      Me.cmdSalir.Text = "&Salir"
      Me.cmdSalir.UseVisualStyleBackColor = True
      '
      'chkComision
      '
      Me.chkComision.AutoSize = True
      Me.chkComision.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.chkComision.Location = New System.Drawing.Point(12, 203)
      Me.chkComision.Name = "chkComision"
      Me.chkComision.Size = New System.Drawing.Size(106, 17)
      Me.chkComision.TabIndex = 5
      Me.chkComision.Text = "Genera &Comisión"
      Me.chkComision.UseVisualStyleBackColor = True
      '
      'tbCtaAdm
      '
      Me.tbCtaAdm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.tbCtaAdm.Location = New System.Drawing.Point(526, 283)
      Me.tbCtaAdm.MaxLength = 10
      Me.tbCtaAdm.Name = "tbCtaAdm"
      Me.tbCtaAdm.Size = New System.Drawing.Size(97, 20)
      Me.tbCtaAdm.TabIndex = 9
      '
      'cbCtaAdm
      '
      Me.cbCtaAdm.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      Me.cbCtaAdm.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.cbCtaAdm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbCtaAdm.FormattingEnabled = True
      Me.cbCtaAdm.Location = New System.Drawing.Point(105, 283)
      Me.cbCtaAdm.Name = "cbCtaAdm"
      Me.cbCtaAdm.Size = New System.Drawing.Size(415, 21)
      Me.cbCtaAdm.TabIndex = 8
      '
      'lblCtaAdm
      '
      Me.lblCtaAdm.AutoSize = True
      Me.lblCtaAdm.Location = New System.Drawing.Point(24, 286)
      Me.lblCtaAdm.Name = "lblCtaAdm"
      Me.lblCtaAdm.Size = New System.Drawing.Size(71, 13)
      Me.lblCtaAdm.TabIndex = 114
      Me.lblCtaAdm.Text = "Cuenta Adm.:"
      '
      'tbCuenta
      '
      Me.tbCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.tbCuenta.Location = New System.Drawing.Point(526, 245)
      Me.tbCuenta.MaxLength = 10
      Me.tbCuenta.Name = "tbCuenta"
      Me.tbCuenta.Size = New System.Drawing.Size(97, 20)
      Me.tbCuenta.TabIndex = 7
      '
      'cbCuenta
      '
      Me.cbCuenta.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      Me.cbCuenta.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.cbCuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbCuenta.FormattingEnabled = True
      Me.cbCuenta.Location = New System.Drawing.Point(105, 245)
      Me.cbCuenta.Name = "cbCuenta"
      Me.cbCuenta.Size = New System.Drawing.Size(415, 21)
      Me.cbCuenta.TabIndex = 6
      '
      'lblCuenta
      '
      Me.lblCuenta.AutoSize = True
      Me.lblCuenta.Location = New System.Drawing.Point(23, 248)
      Me.lblCuenta.Name = "lblCuenta"
      Me.lblCuenta.Size = New System.Drawing.Size(72, 13)
      Me.lblCuenta.TabIndex = 113
      Me.lblCuenta.Text = "Cuenta Cont.:"
      '
      'frmConceptosAM
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(648, 458)
      Me.Controls.Add(Me.tbCtaAdm)
      Me.Controls.Add(Me.cbCtaAdm)
      Me.Controls.Add(Me.lblCtaAdm)
      Me.Controls.Add(Me.tbCuenta)
      Me.Controls.Add(Me.cbCuenta)
      Me.Controls.Add(Me.lblCuenta)
      Me.Controls.Add(Me.chkComision)
      Me.Controls.Add(Me.cmdSalir)
      Me.Controls.Add(Me.cmdCancelar)
      Me.Controls.Add(Me.cmdAceptar)
      Me.Controls.Add(Me.tbPrioridad)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.optHaber)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.optDebe)
      Me.Controls.Add(Me.tbCodigo)
      Me.Controls.Add(Me.tbDescrip)
      Me.Controls.Add(Me.Label4)
      Me.Controls.Add(Me.Label3)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.KeyPreview = True
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "frmConceptosAM"
      Me.Text = "Conceptos"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents tbCodigo As System.Windows.Forms.TextBox
   Friend WithEvents tbDescrip As System.Windows.Forms.TextBox
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents optDebe As System.Windows.Forms.RadioButton
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents optHaber As System.Windows.Forms.RadioButton
   Friend WithEvents tbPrioridad As System.Windows.Forms.TextBox
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents cmdCancelar As System.Windows.Forms.Button
   Friend WithEvents cmdAceptar As System.Windows.Forms.Button
   Friend WithEvents cmdSalir As System.Windows.Forms.Button
   Friend WithEvents chkComision As System.Windows.Forms.CheckBox
   Friend WithEvents tbCtaAdm As System.Windows.Forms.TextBox
   Friend WithEvents cbCtaAdm As System.Windows.Forms.ComboBox
   Friend WithEvents lblCtaAdm As System.Windows.Forms.Label
   Friend WithEvents tbCuenta As System.Windows.Forms.TextBox
   Friend WithEvents cbCuenta As System.Windows.Forms.ComboBox
   Friend WithEvents lblCuenta As System.Windows.Forms.Label
End Class
