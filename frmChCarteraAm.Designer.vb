<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChCarteraAM
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
      Me.cboBanco = New System.Windows.Forms.ComboBox()
      Me.tbCtaBco = New System.Windows.Forms.TextBox()
      Me.tbTitular = New System.Windows.Forms.TextBox()
      Me.tbNumero = New System.Windows.Forms.TextBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
      Me.Label18 = New System.Windows.Forms.Label()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.tbImporte = New System.Windows.Forms.TextBox()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.tbEntrego = New System.Windows.Forms.TextBox()
      Me.Label7 = New System.Windows.Forms.Label()
      Me.tbDetalle = New System.Windows.Forms.TextBox()
      Me.btnCancelar = New System.Windows.Forms.Button()
      Me.btnAceptar = New System.Windows.Forms.Button()
      Me.SuspendLayout()
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(61, 24)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(41, 13)
      Me.Label2.TabIndex = 95
      Me.Label2.Text = "Banco:"
      '
      'cboBanco
      '
      Me.cboBanco.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      Me.cboBanco.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.cboBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboBanco.FormattingEnabled = True
      Me.cboBanco.Location = New System.Drawing.Point(108, 21)
      Me.cboBanco.Name = "cboBanco"
      Me.cboBanco.Size = New System.Drawing.Size(345, 21)
      Me.cboBanco.TabIndex = 94
      '
      'tbCtaBco
      '
      Me.tbCtaBco.Location = New System.Drawing.Point(108, 48)
      Me.tbCtaBco.Name = "tbCtaBco"
      Me.tbCtaBco.Size = New System.Drawing.Size(189, 20)
      Me.tbCtaBco.TabIndex = 96
      '
      'tbTitular
      '
      Me.tbTitular.Location = New System.Drawing.Point(108, 74)
      Me.tbTitular.Name = "tbTitular"
      Me.tbTitular.Size = New System.Drawing.Size(345, 20)
      Me.tbTitular.TabIndex = 97
      '
      'tbNumero
      '
      Me.tbNumero.Location = New System.Drawing.Point(108, 100)
      Me.tbNumero.Name = "tbNumero"
      Me.tbNumero.Size = New System.Drawing.Size(189, 20)
      Me.tbNumero.TabIndex = 98
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(55, 103)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(47, 13)
      Me.Label1.TabIndex = 99
      Me.Label1.Text = "Número:"
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(63, 77)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(39, 13)
      Me.Label3.TabIndex = 100
      Me.Label3.Text = "Titular:"
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(58, 51)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(44, 13)
      Me.Label4.TabIndex = 101
      Me.Label4.Text = "Cuenta:"
      '
      'dtpFecha
      '
      Me.dtpFecha.Enabled = False
      Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpFecha.Location = New System.Drawing.Point(108, 126)
      Me.dtpFecha.Name = "dtpFecha"
      Me.dtpFecha.Size = New System.Drawing.Size(88, 20)
      Me.dtpFecha.TabIndex = 103
      '
      'Label18
      '
      Me.Label18.AutoSize = True
      Me.Label18.Location = New System.Drawing.Point(62, 130)
      Me.Label18.Name = "Label18"
      Me.Label18.Size = New System.Drawing.Size(40, 13)
      Me.Label18.TabIndex = 102
      Me.Label18.Text = "Fecha:"
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.Location = New System.Drawing.Point(49, 155)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(51, 13)
      Me.Label5.TabIndex = 105
      Me.Label5.Text = "Importe $"
      '
      'tbImporte
      '
      Me.tbImporte.Location = New System.Drawing.Point(108, 152)
      Me.tbImporte.Name = "tbImporte"
      Me.tbImporte.Size = New System.Drawing.Size(100, 20)
      Me.tbImporte.TabIndex = 104
      '
      'Label6
      '
      Me.Label6.AutoSize = True
      Me.Label6.Location = New System.Drawing.Point(55, 181)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(47, 13)
      Me.Label6.TabIndex = 107
      Me.Label6.Text = "Entregó:"
      '
      'tbEntrego
      '
      Me.tbEntrego.Location = New System.Drawing.Point(108, 178)
      Me.tbEntrego.Name = "tbEntrego"
      Me.tbEntrego.Size = New System.Drawing.Size(345, 20)
      Me.tbEntrego.TabIndex = 106
      '
      'Label7
      '
      Me.Label7.AutoSize = True
      Me.Label7.Location = New System.Drawing.Point(55, 207)
      Me.Label7.Name = "Label7"
      Me.Label7.Size = New System.Drawing.Size(43, 13)
      Me.Label7.TabIndex = 109
      Me.Label7.Text = "Detalle:"
      '
      'tbDetalle
      '
      Me.tbDetalle.Location = New System.Drawing.Point(108, 204)
      Me.tbDetalle.Multiline = True
      Me.tbDetalle.Name = "tbDetalle"
      Me.tbDetalle.Size = New System.Drawing.Size(345, 83)
      Me.tbDetalle.TabIndex = 108
      '
      'btnCancelar
      '
      Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnCancelar.Location = New System.Drawing.Point(441, 316)
      Me.btnCancelar.Name = "btnCancelar"
      Me.btnCancelar.Size = New System.Drawing.Size(63, 27)
      Me.btnCancelar.TabIndex = 111
      Me.btnCancelar.Text = "&Cancelar"
      Me.btnCancelar.UseVisualStyleBackColor = True
      '
      'btnAceptar
      '
      Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnAceptar.Location = New System.Drawing.Point(361, 316)
      Me.btnAceptar.Name = "btnAceptar"
      Me.btnAceptar.Size = New System.Drawing.Size(74, 27)
      Me.btnAceptar.TabIndex = 110
      Me.btnAceptar.Text = "&Aceptar"
      Me.btnAceptar.UseVisualStyleBackColor = True
      '
      'frmChCarteraAM
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(516, 355)
      Me.Controls.Add(Me.btnCancelar)
      Me.Controls.Add(Me.btnAceptar)
      Me.Controls.Add(Me.Label7)
      Me.Controls.Add(Me.tbDetalle)
      Me.Controls.Add(Me.Label6)
      Me.Controls.Add(Me.tbEntrego)
      Me.Controls.Add(Me.Label5)
      Me.Controls.Add(Me.tbImporte)
      Me.Controls.Add(Me.dtpFecha)
      Me.Controls.Add(Me.Label18)
      Me.Controls.Add(Me.Label4)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.tbNumero)
      Me.Controls.Add(Me.tbTitular)
      Me.Controls.Add(Me.tbCtaBco)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.cboBanco)
      Me.KeyPreview = True
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "frmChCarteraAM"
      Me.Text = "Cheques en Cartera"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents cboBanco As System.Windows.Forms.ComboBox
   Friend WithEvents tbCtaBco As System.Windows.Forms.TextBox
   Friend WithEvents tbTitular As System.Windows.Forms.TextBox
   Friend WithEvents tbNumero As System.Windows.Forms.TextBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
   Friend WithEvents Label18 As System.Windows.Forms.Label
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents tbImporte As System.Windows.Forms.TextBox
   Friend WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents tbEntrego As System.Windows.Forms.TextBox
   Friend WithEvents Label7 As System.Windows.Forms.Label
   Friend WithEvents tbDetalle As System.Windows.Forms.TextBox
   Friend WithEvents btnCancelar As System.Windows.Forms.Button
   Friend WithEvents btnAceptar As System.Windows.Forms.Button
End Class
