<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPropConcAM
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
      Me.Label1 = New System.Windows.Forms.Label()
      Me.tbPropiedad = New System.Windows.Forms.TextBox()
      Me.tbPropietario = New System.Windows.Forms.TextBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.cbDescConc = New System.Windows.Forms.ComboBox()
      Me.cbConcepto = New System.Windows.Forms.ComboBox()
      Me.tbDetalle = New System.Windows.Forms.TextBox()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.tbImporte = New System.Windows.Forms.TextBox()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.tbFecDesde = New System.Windows.Forms.DateTimePicker()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.fraImput = New System.Windows.Forms.GroupBox()
      Me.optHaber = New System.Windows.Forms.RadioButton()
      Me.optDebe = New System.Windows.Forms.RadioButton()
      Me.fraAsigna = New System.Windows.Forms.GroupBox()
      Me.chkNoInquilino = New System.Windows.Forms.CheckBox()
      Me.optAdmin = New System.Windows.Forms.RadioButton()
      Me.optPropiet = New System.Windows.Forms.RadioButton()
      Me.cmdCancelar = New System.Windows.Forms.Button()
      Me.cmdAceptar = New System.Windows.Forms.Button()
      Me.fraImput.SuspendLayout()
      Me.fraAsigna.SuspendLayout()
      Me.SuspendLayout()
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(8, 47)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(58, 13)
      Me.Label1.TabIndex = 0
      Me.Label1.Text = "Propiedad:"
      '
      'tbPropiedad
      '
      Me.tbPropiedad.Enabled = False
      Me.tbPropiedad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.tbPropiedad.Location = New System.Drawing.Point(74, 44)
      Me.tbPropiedad.Name = "tbPropiedad"
      Me.tbPropiedad.Size = New System.Drawing.Size(484, 20)
      Me.tbPropiedad.TabIndex = 1
      '
      'tbPropietario
      '
      Me.tbPropietario.Enabled = False
      Me.tbPropietario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.tbPropietario.Location = New System.Drawing.Point(74, 12)
      Me.tbPropietario.Name = "tbPropietario"
      Me.tbPropietario.Size = New System.Drawing.Size(484, 20)
      Me.tbPropietario.TabIndex = 0
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(8, 15)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(60, 13)
      Me.Label2.TabIndex = 2
      Me.Label2.Text = "Propietario:"
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(12, 87)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(56, 13)
      Me.Label3.TabIndex = 40
      Me.Label3.Text = "Concepto:"
      '
      'cbDescConc
      '
      Me.cbDescConc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      Me.cbDescConc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.cbDescConc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbDescConc.FormattingEnabled = True
      Me.cbDescConc.Location = New System.Drawing.Point(131, 84)
      Me.cbDescConc.Name = "cbDescConc"
      Me.cbDescConc.Size = New System.Drawing.Size(427, 21)
      Me.cbDescConc.TabIndex = 3
      '
      'cbConcepto
      '
      Me.cbConcepto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      Me.cbConcepto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.cbConcepto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbConcepto.FormattingEnabled = True
      Me.cbConcepto.Location = New System.Drawing.Point(74, 84)
      Me.cbConcepto.Name = "cbConcepto"
      Me.cbConcepto.Size = New System.Drawing.Size(51, 21)
      Me.cbConcepto.TabIndex = 2
      '
      'tbDetalle
      '
      Me.tbDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.tbDetalle.Location = New System.Drawing.Point(74, 119)
      Me.tbDetalle.MaxLength = 250
      Me.tbDetalle.Name = "tbDetalle"
      Me.tbDetalle.Size = New System.Drawing.Size(484, 20)
      Me.tbDetalle.TabIndex = 4
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(23, 122)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(43, 13)
      Me.Label4.TabIndex = 42
      Me.Label4.Text = "Detalle:"
      '
      'tbImporte
      '
      Me.tbImporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.tbImporte.Location = New System.Drawing.Point(74, 154)
      Me.tbImporte.Name = "tbImporte"
      Me.tbImporte.Size = New System.Drawing.Size(85, 20)
      Me.tbImporte.TabIndex = 5
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.Location = New System.Drawing.Point(17, 157)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(51, 13)
      Me.Label5.TabIndex = 44
      Me.Label5.Text = "Importe $"
      '
      'tbFecDesde
      '
      Me.tbFecDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.tbFecDesde.Location = New System.Drawing.Point(74, 191)
      Me.tbFecDesde.Name = "tbFecDesde"
      Me.tbFecDesde.Size = New System.Drawing.Size(85, 20)
      Me.tbFecDesde.TabIndex = 6
      '
      'Label6
      '
      Me.Label6.AutoSize = True
      Me.Label6.Location = New System.Drawing.Point(27, 193)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(41, 13)
      Me.Label6.TabIndex = 47
      Me.Label6.Text = "Desde:"
      '
      'fraImput
      '
      Me.fraImput.BackColor = System.Drawing.SystemColors.ControlLight
      Me.fraImput.Controls.Add(Me.optHaber)
      Me.fraImput.Controls.Add(Me.optDebe)
      Me.fraImput.Location = New System.Drawing.Point(35, 233)
      Me.fraImput.Name = "fraImput"
      Me.fraImput.Size = New System.Drawing.Size(227, 100)
      Me.fraImput.TabIndex = 7
      Me.fraImput.TabStop = False
      Me.fraImput.Text = "Imputación"
      '
      'optHaber
      '
      Me.optHaber.AutoSize = True
      Me.optHaber.Location = New System.Drawing.Point(106, 43)
      Me.optHaber.Name = "optHaber"
      Me.optHaber.Size = New System.Drawing.Size(58, 17)
      Me.optHaber.TabIndex = 1
      Me.optHaber.Text = "&Crédito"
      Me.optHaber.UseVisualStyleBackColor = True
      '
      'optDebe
      '
      Me.optDebe.AutoSize = True
      Me.optDebe.Checked = True
      Me.optDebe.Location = New System.Drawing.Point(23, 43)
      Me.optDebe.Name = "optDebe"
      Me.optDebe.Size = New System.Drawing.Size(56, 17)
      Me.optDebe.TabIndex = 0
      Me.optDebe.TabStop = True
      Me.optDebe.Text = "&Débito"
      Me.optDebe.UseVisualStyleBackColor = True
      '
      'fraAsigna
      '
      Me.fraAsigna.BackColor = System.Drawing.SystemColors.ControlLight
      Me.fraAsigna.Controls.Add(Me.chkNoInquilino)
      Me.fraAsigna.Controls.Add(Me.optAdmin)
      Me.fraAsigna.Controls.Add(Me.optPropiet)
      Me.fraAsigna.Location = New System.Drawing.Point(280, 191)
      Me.fraAsigna.Name = "fraAsigna"
      Me.fraAsigna.Size = New System.Drawing.Size(278, 142)
      Me.fraAsigna.TabIndex = 8
      Me.fraAsigna.TabStop = False
      Me.fraAsigna.Text = "Asignación"
      '
      'chkNoInquilino
      '
      Me.chkNoInquilino.AutoSize = True
      Me.chkNoInquilino.Location = New System.Drawing.Point(85, 102)
      Me.chkNoInquilino.Name = "chkNoInquilino"
      Me.chkNoInquilino.Size = New System.Drawing.Size(114, 17)
      Me.chkNoInquilino.TabIndex = 2
      Me.chkNoInquilino.Text = "&No Imp. a Inquilino"
      Me.chkNoInquilino.UseVisualStyleBackColor = True
      '
      'optAdmin
      '
      Me.optAdmin.AutoSize = True
      Me.optAdmin.Location = New System.Drawing.Point(85, 65)
      Me.optAdmin.Name = "optAdmin"
      Me.optAdmin.Size = New System.Drawing.Size(93, 17)
      Me.optAdmin.TabIndex = 1
      Me.optAdmin.Text = "&Administración"
      Me.optAdmin.UseVisualStyleBackColor = True
      '
      'optPropiet
      '
      Me.optPropiet.AutoSize = True
      Me.optPropiet.Checked = True
      Me.optPropiet.Location = New System.Drawing.Point(85, 32)
      Me.optPropiet.Name = "optPropiet"
      Me.optPropiet.Size = New System.Drawing.Size(75, 17)
      Me.optPropiet.TabIndex = 0
      Me.optPropiet.TabStop = True
      Me.optPropiet.Text = "&Propietario"
      Me.optPropiet.UseVisualStyleBackColor = True
      '
      'cmdCancelar
      '
      Me.cmdCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.cmdCancelar.Location = New System.Drawing.Point(482, 349)
      Me.cmdCancelar.Name = "cmdCancelar"
      Me.cmdCancelar.Size = New System.Drawing.Size(76, 27)
      Me.cmdCancelar.TabIndex = 49
      Me.cmdCancelar.Text = "&Cancelar"
      Me.cmdCancelar.UseVisualStyleBackColor = True
      '
      'cmdAceptar
      '
      Me.cmdAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdAceptar.Location = New System.Drawing.Point(400, 349)
      Me.cmdAceptar.Name = "cmdAceptar"
      Me.cmdAceptar.Size = New System.Drawing.Size(76, 27)
      Me.cmdAceptar.TabIndex = 48
      Me.cmdAceptar.Text = "&Aceptar"
      Me.cmdAceptar.UseVisualStyleBackColor = True
      '
      'frmPropConcAM
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(572, 388)
      Me.Controls.Add(Me.cmdCancelar)
      Me.Controls.Add(Me.cmdAceptar)
      Me.Controls.Add(Me.fraAsigna)
      Me.Controls.Add(Me.fraImput)
      Me.Controls.Add(Me.Label6)
      Me.Controls.Add(Me.tbFecDesde)
      Me.Controls.Add(Me.tbImporte)
      Me.Controls.Add(Me.Label5)
      Me.Controls.Add(Me.tbDetalle)
      Me.Controls.Add(Me.Label4)
      Me.Controls.Add(Me.cbConcepto)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.cbDescConc)
      Me.Controls.Add(Me.tbPropietario)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.tbPropiedad)
      Me.Controls.Add(Me.Label1)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "frmPropConcAM"
      Me.Text = "Concepto Fijo"
      Me.fraImput.ResumeLayout(False)
      Me.fraImput.PerformLayout()
      Me.fraAsigna.ResumeLayout(False)
      Me.fraAsigna.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents tbPropiedad As System.Windows.Forms.TextBox
   Friend WithEvents tbPropietario As System.Windows.Forms.TextBox
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents cbDescConc As System.Windows.Forms.ComboBox
   Friend WithEvents cbConcepto As System.Windows.Forms.ComboBox
   Friend WithEvents tbDetalle As System.Windows.Forms.TextBox
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents tbImporte As System.Windows.Forms.TextBox
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents tbFecDesde As System.Windows.Forms.DateTimePicker
   Friend WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents fraImput As System.Windows.Forms.GroupBox
   Friend WithEvents optHaber As System.Windows.Forms.RadioButton
   Friend WithEvents optDebe As System.Windows.Forms.RadioButton
   Friend WithEvents fraAsigna As System.Windows.Forms.GroupBox
   Friend WithEvents chkNoInquilino As System.Windows.Forms.CheckBox
   Friend WithEvents optAdmin As System.Windows.Forms.RadioButton
   Friend WithEvents optPropiet As System.Windows.Forms.RadioButton
   Friend WithEvents cmdCancelar As System.Windows.Forms.Button
   Friend WithEvents cmdAceptar As System.Windows.Forms.Button
End Class
