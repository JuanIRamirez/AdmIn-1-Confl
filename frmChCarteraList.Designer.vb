<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmChCarteraList
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
      Me.Label4 = New System.Windows.Forms.Label()
      Me.dtpAl = New System.Windows.Forms.DateTimePicker()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.cboCaja = New System.Windows.Forms.ComboBox()
      Me.chkTodas = New System.Windows.Forms.CheckBox()
      Me.cmdSalir = New System.Windows.Forms.Button()
      Me.cmdAceptar = New System.Windows.Forms.Button()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.cbEstado = New System.Windows.Forms.ComboBox()
      Me.SuspendLayout()
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(41, 78)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(23, 13)
      Me.Label4.TabIndex = 100
      Me.Label4.Text = "Ak:"
      '
      'dtpAl
      '
      Me.dtpAl.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpAl.Location = New System.Drawing.Point(70, 75)
      Me.dtpAl.Name = "dtpAl"
      Me.dtpAl.Size = New System.Drawing.Size(94, 20)
      Me.dtpAl.TabIndex = 99
      Me.dtpAl.Value = New Date(2015, 9, 24, 0, 0, 0, 0)
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(33, 37)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(31, 13)
      Me.Label2.TabIndex = 98
      Me.Label2.Text = "Caja:"
      '
      'cboCaja
      '
      Me.cboCaja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboCaja.FormattingEnabled = True
      Me.cboCaja.Location = New System.Drawing.Point(70, 34)
      Me.cboCaja.Name = "cboCaja"
      Me.cboCaja.Size = New System.Drawing.Size(206, 21)
      Me.cboCaja.TabIndex = 97
      '
      'chkTodas
      '
      Me.chkTodas.AutoSize = True
      Me.chkTodas.Location = New System.Drawing.Point(180, 77)
      Me.chkTodas.Name = "chkTodas"
      Me.chkTodas.Size = New System.Drawing.Size(56, 17)
      Me.chkTodas.TabIndex = 101
      Me.chkTodas.Text = "&Todas"
      Me.chkTodas.UseVisualStyleBackColor = True
      '
      'cmdSalir
      '
      Me.cmdSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdSalir.Location = New System.Drawing.Point(295, 181)
      Me.cmdSalir.Name = "cmdSalir"
      Me.cmdSalir.Size = New System.Drawing.Size(76, 27)
      Me.cmdSalir.TabIndex = 103
      Me.cmdSalir.Text = "&Salir"
      Me.cmdSalir.UseVisualStyleBackColor = True
      '
      'cmdAceptar
      '
      Me.cmdAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdAceptar.Location = New System.Drawing.Point(213, 181)
      Me.cmdAceptar.Name = "cmdAceptar"
      Me.cmdAceptar.Size = New System.Drawing.Size(76, 27)
      Me.cmdAceptar.TabIndex = 102
      Me.cmdAceptar.Text = "&Aceptar"
      Me.cmdAceptar.UseVisualStyleBackColor = True
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(21, 120)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(43, 13)
      Me.Label3.TabIndex = 106
      Me.Label3.Text = "Estado:"
      '
      'cbEstado
      '
      Me.cbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbEstado.FormattingEnabled = True
      Me.cbEstado.Location = New System.Drawing.Point(70, 117)
      Me.cbEstado.Name = "cbEstado"
      Me.cbEstado.Size = New System.Drawing.Size(137, 21)
      Me.cbEstado.TabIndex = 105
      '
      'FrmChCarteraList
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(383, 220)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.cbEstado)
      Me.Controls.Add(Me.cmdSalir)
      Me.Controls.Add(Me.cmdAceptar)
      Me.Controls.Add(Me.chkTodas)
      Me.Controls.Add(Me.Label4)
      Me.Controls.Add(Me.dtpAl)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.cboCaja)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "FrmChCarteraList"
      Me.Text = "Listado de Cheques en Cartera"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents dtpAl As System.Windows.Forms.DateTimePicker
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents cboCaja As System.Windows.Forms.ComboBox
   Friend WithEvents chkTodas As System.Windows.Forms.CheckBox
   Friend WithEvents cmdSalir As System.Windows.Forms.Button
   Friend WithEvents cmdAceptar As System.Windows.Forms.Button
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents cbEstado As System.Windows.Forms.ComboBox
End Class
