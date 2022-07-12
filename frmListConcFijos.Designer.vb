<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListConcFijos
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
      Me.optTodos = New System.Windows.Forms.RadioButton()
      Me.optPropietario = New System.Windows.Forms.RadioButton()
      Me.optAdmin = New System.Windows.Forms.RadioButton()
      Me.cbConcepto = New System.Windows.Forms.ComboBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.cbDescConc = New System.Windows.Forms.ComboBox()
      Me.cmdCancelar = New System.Windows.Forms.Button()
      Me.cmdAceptar = New System.Windows.Forms.Button()
      Me.chkActuales = New System.Windows.Forms.CheckBox()
      Me.optAdminNR = New System.Windows.Forms.RadioButton()
        Me.chkNoInq = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'optTodos
        '
        Me.optTodos.AutoSize = True
        Me.optTodos.Checked = True
        Me.optTodos.Location = New System.Drawing.Point(29, 33)
        Me.optTodos.Name = "optTodos"
        Me.optTodos.Size = New System.Drawing.Size(55, 17)
        Me.optTodos.TabIndex = 0
        Me.optTodos.TabStop = True
        Me.optTodos.Text = "&Todos"
        Me.optTodos.UseVisualStyleBackColor = True
        '
        'optPropietario
        '
        Me.optPropietario.AutoSize = True
        Me.optPropietario.Location = New System.Drawing.Point(29, 56)
        Me.optPropietario.Name = "optPropietario"
        Me.optPropietario.Size = New System.Drawing.Size(84, 17)
        Me.optPropietario.TabIndex = 1
        Me.optPropietario.Text = "a &Propietario"
        Me.optPropietario.UseVisualStyleBackColor = True
        '
        'optAdmin
        '
        Me.optAdmin.AutoSize = True
        Me.optAdmin.Location = New System.Drawing.Point(29, 79)
        Me.optAdmin.Name = "optAdmin"
        Me.optAdmin.Size = New System.Drawing.Size(102, 17)
        Me.optAdmin.TabIndex = 3
        Me.optAdmin.Text = "a &Administración"
        Me.optAdmin.UseVisualStyleBackColor = True
        '
        'cbConcepto
        '
        Me.cbConcepto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbConcepto.FormattingEnabled = True
        Me.cbConcepto.Location = New System.Drawing.Point(88, 188)
        Me.cbConcepto.Name = "cbConcepto"
        Me.cbConcepto.Size = New System.Drawing.Size(51, 21)
        Me.cbConcepto.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(26, 191)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 43
        Me.Label3.Text = "Concepto:"
        '
        'cbDescConc
        '
        Me.cbDescConc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbDescConc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbDescConc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDescConc.FormattingEnabled = True
        Me.cbDescConc.Location = New System.Drawing.Point(145, 188)
        Me.cbDescConc.Name = "cbDescConc"
        Me.cbDescConc.Size = New System.Drawing.Size(456, 21)
        Me.cbDescConc.TabIndex = 7
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Location = New System.Drawing.Point(536, 245)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(65, 27)
        Me.cmdCancelar.TabIndex = 9
        Me.cmdCancelar.Text = "&Cancelar"
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAceptar.Location = New System.Drawing.Point(443, 245)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(87, 27)
        Me.cmdAceptar.TabIndex = 8
        Me.cmdAceptar.Text = "&Aceptar"
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'chkActuales
        '
        Me.chkActuales.AutoSize = True
        Me.chkActuales.Location = New System.Drawing.Point(29, 148)
        Me.chkActuales.Name = "chkActuales"
        Me.chkActuales.Size = New System.Drawing.Size(90, 17)
        Me.chkActuales.TabIndex = 5
        Me.chkActuales.Text = "&Solo actuales"
        Me.chkActuales.UseVisualStyleBackColor = True
        '
        'optAdminNR
        '
        Me.optAdminNR.AutoSize = True
        Me.optAdminNR.Location = New System.Drawing.Point(29, 102)
        Me.optAdminNR.Name = "optAdminNR"
        Me.optAdminNR.Size = New System.Drawing.Size(184, 17)
        Me.optAdminNR.TabIndex = 4
        Me.optAdminNR.Text = "a Administración no &Recuperados"
        Me.optAdminNR.UseVisualStyleBackColor = True
        '
        'chkNoInq
        '
        Me.chkNoInq.AutoSize = True
        Me.chkNoInq.Enabled = False
        Me.chkNoInq.Location = New System.Drawing.Point(217, 56)
        Me.chkNoInq.Name = "chkNoInq"
        Me.chkNoInq.Size = New System.Drawing.Size(144, 17)
        Me.chkNoInq.TabIndex = 2
        Me.chkNoInq.Text = "&No imputables a Inquilino"
        Me.chkNoInq.UseVisualStyleBackColor = True
        '
        'frmListConcFijos
        '
        Me.AcceptButton = Me.cmdAceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(613, 284)
        Me.Controls.Add(Me.chkNoInq)
        Me.Controls.Add(Me.optAdminNR)
        Me.Controls.Add(Me.chkActuales)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Controls.Add(Me.cbConcepto)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cbDescConc)
        Me.Controls.Add(Me.optAdmin)
        Me.Controls.Add(Me.optPropietario)
        Me.Controls.Add(Me.optTodos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmListConcFijos"
        Me.Text = "Listado de Conceptos Fijos"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents optTodos As System.Windows.Forms.RadioButton
   Friend WithEvents optPropietario As System.Windows.Forms.RadioButton
   Friend WithEvents optAdmin As System.Windows.Forms.RadioButton
   Friend WithEvents cbConcepto As System.Windows.Forms.ComboBox
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents cbDescConc As System.Windows.Forms.ComboBox
   Friend WithEvents cmdCancelar As System.Windows.Forms.Button
   Friend WithEvents cmdAceptar As System.Windows.Forms.Button
   Friend WithEvents chkActuales As System.Windows.Forms.CheckBox
   Friend WithEvents optAdminNR As RadioButton
    Friend WithEvents chkNoInq As CheckBox
End Class
