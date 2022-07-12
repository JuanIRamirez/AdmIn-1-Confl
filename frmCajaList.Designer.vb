<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCajaList
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
      Me.Label2 = New System.Windows.Forms.Label()
      Me.cboCaja = New System.Windows.Forms.ComboBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.cboUid = New System.Windows.Forms.ComboBox()
      Me.cmdCerrar = New System.Windows.Forms.Button()
      Me.cmdAceptar = New System.Windows.Forms.Button()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.dtpDesde = New System.Windows.Forms.DateTimePicker()
      Me.tbResponsable = New System.Windows.Forms.TextBox()
        Me.DtpHasta = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.chkSaldoAnt = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(112, 77)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 13)
        Me.Label2.TabIndex = 78
        Me.Label2.Text = "Caja:"
        '
        'cboCaja
        '
        Me.cboCaja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCaja.FormattingEnabled = True
        Me.cboCaja.Location = New System.Drawing.Point(149, 74)
        Me.cboCaja.Name = "cboCaja"
        Me.cboCaja.Size = New System.Drawing.Size(227, 21)
        Me.cboCaja.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(72, 121)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 13)
        Me.Label1.TabIndex = 82
        Me.Label1.Text = "Responsable:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(97, 160)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 84
        Me.Label3.Text = "Usuario:"
        '
        'cboUid
        '
        Me.cboUid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUid.FormattingEnabled = True
        Me.cboUid.Location = New System.Drawing.Point(149, 157)
        Me.cboUid.Name = "cboUid"
        Me.cboUid.Size = New System.Drawing.Size(227, 21)
        Me.cboUid.TabIndex = 4
        '
        'cmdCerrar
        '
        Me.cmdCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCerrar.Location = New System.Drawing.Point(410, 234)
        Me.cmdCerrar.Name = "cmdCerrar"
        Me.cmdCerrar.Size = New System.Drawing.Size(70, 27)
        Me.cmdCerrar.TabIndex = 7
        Me.cmdCerrar.Text = "&Cerrar"
        Me.cmdCerrar.UseVisualStyleBackColor = True
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdAceptar.Location = New System.Drawing.Point(319, 234)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(85, 27)
        Me.cmdAceptar.TabIndex = 6
        Me.cmdAceptar.Text = "&Aceptar"
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(100, 38)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 95
        Me.Label4.Text = "Fecha:"
        '
        'dtpDesde
        '
        Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDesde.Location = New System.Drawing.Point(149, 34)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(94, 20)
        Me.dtpDesde.TabIndex = 0
        Me.dtpDesde.Value = New Date(2015, 9, 24, 0, 0, 0, 0)
        '
        'tbResponsable
        '
        Me.tbResponsable.Enabled = False
        Me.tbResponsable.Location = New System.Drawing.Point(150, 118)
        Me.tbResponsable.Name = "tbResponsable"
        Me.tbResponsable.Size = New System.Drawing.Size(226, 20)
        Me.tbResponsable.TabIndex = 3
        '
        'DtpHasta
        '
        Me.DtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpHasta.Location = New System.Drawing.Point(282, 34)
        Me.DtpHasta.Name = "DtpHasta"
        Me.DtpHasta.Size = New System.Drawing.Size(94, 20)
        Me.DtpHasta.TabIndex = 1
        Me.DtpHasta.Value = New Date(2015, 9, 24, 0, 0, 0, 0)
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(257, 38)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(19, 13)
        Me.Label5.TabIndex = 98
        Me.Label5.Text = "Al:"
        '
        'chkSaldoAnt
        '
        Me.chkSaldoAnt.AutoSize = True
        Me.chkSaldoAnt.Location = New System.Drawing.Point(149, 199)
        Me.chkSaldoAnt.Name = "chkSaldoAnt"
        Me.chkSaldoAnt.Size = New System.Drawing.Size(95, 17)
        Me.chkSaldoAnt.TabIndex = 5
        Me.chkSaldoAnt.Text = "Arrastrar &Saldo"
        Me.chkSaldoAnt.UseVisualStyleBackColor = True
        '
        'frmCajaList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(492, 273)
        Me.Controls.Add(Me.chkSaldoAnt)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.DtpHasta)
        Me.Controls.Add(Me.tbResponsable)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dtpDesde)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Controls.Add(Me.cmdCerrar)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboUid)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboCaja)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCajaList"
        Me.Text = "Listado de Caja"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents cboCaja As System.Windows.Forms.ComboBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents cboUid As System.Windows.Forms.ComboBox
   Friend WithEvents cmdCerrar As System.Windows.Forms.Button
   Friend WithEvents cmdAceptar As System.Windows.Forms.Button
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents dtpDesde As System.Windows.Forms.DateTimePicker
   Friend WithEvents tbResponsable As System.Windows.Forms.TextBox
    Friend WithEvents DtpHasta As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents chkSaldoAnt As CheckBox
End Class
