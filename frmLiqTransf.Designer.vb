<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLiqTransf
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
      Me.GroupBox1 = New System.Windows.Forms.GroupBox()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.tbTitular0 = New System.Windows.Forms.TextBox()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.cbCuenta0 = New System.Windows.Forms.ComboBox()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.cbBanco0 = New System.Windows.Forms.ComboBox()
      Me.GroupBox2 = New System.Windows.Forms.GroupBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.tbTitular1 = New System.Windows.Forms.TextBox()
      Me.Label7 = New System.Windows.Forms.Label()
      Me.cbCuenta1 = New System.Windows.Forms.ComboBox()
      Me.Label8 = New System.Windows.Forms.Label()
      Me.cbBanco1 = New System.Windows.Forms.ComboBox()
      Me.gbGastos = New System.Windows.Forms.GroupBox()
      Me.Label12 = New System.Windows.Forms.Label()
      Me.tbIva = New System.Windows.Forms.TextBox()
      Me.Label11 = New System.Windows.Forms.Label()
      Me.tbGastosSF = New System.Windows.Forms.TextBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.tbGastos = New System.Windows.Forms.TextBox()
      Me.GroupBox4 = New System.Windows.Forms.GroupBox()
      Me.lblImporte = New System.Windows.Forms.Label()
      Me.tbImporte = New System.Windows.Forms.TextBox()
      Me.Label13 = New System.Windows.Forms.Label()
      Me.Label9 = New System.Windows.Forms.Label()
      Me.tbImpNeto = New System.Windows.Forms.TextBox()
      Me.tbNumero = New System.Windows.Forms.TextBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.dtFecha = New System.Windows.Forms.DateTimePicker()
      Me.cmdCancelar = New System.Windows.Forms.Button()
      Me.cmdAceptar = New System.Windows.Forms.Button()
      Me.GroupBox1.SuspendLayout()
      Me.GroupBox2.SuspendLayout()
      Me.gbGastos.SuspendLayout()
      Me.GroupBox4.SuspendLayout()
      Me.SuspendLayout()
      '
      'GroupBox1
      '
      Me.GroupBox1.Controls.Add(Me.Label6)
      Me.GroupBox1.Controls.Add(Me.tbTitular0)
      Me.GroupBox1.Controls.Add(Me.Label5)
      Me.GroupBox1.Controls.Add(Me.cbCuenta0)
      Me.GroupBox1.Controls.Add(Me.Label4)
      Me.GroupBox1.Controls.Add(Me.cbBanco0)
      Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
      Me.GroupBox1.Name = "GroupBox1"
      Me.GroupBox1.Size = New System.Drawing.Size(532, 117)
      Me.GroupBox1.TabIndex = 49
      Me.GroupBox1.TabStop = False
      Me.GroupBox1.Text = "Origen"
      '
      'Label6
      '
      Me.Label6.AutoSize = True
      Me.Label6.Location = New System.Drawing.Point(22, 81)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(39, 13)
      Me.Label6.TabIndex = 55
      Me.Label6.Text = "Titular:"
      '
      'tbTitular0
      '
      Me.tbTitular0.Location = New System.Drawing.Point(103, 78)
      Me.tbTitular0.Name = "tbTitular0"
      Me.tbTitular0.Size = New System.Drawing.Size(404, 20)
      Me.tbTitular0.TabIndex = 2
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.Location = New System.Drawing.Point(22, 54)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(44, 13)
      Me.Label5.TabIndex = 53
      Me.Label5.Text = "Cuenta:"
      '
      'cbCuenta0
      '
      Me.cbCuenta0.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      Me.cbCuenta0.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.cbCuenta0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbCuenta0.FormattingEnabled = True
      Me.cbCuenta0.Location = New System.Drawing.Point(103, 51)
      Me.cbCuenta0.Name = "cbCuenta0"
      Me.cbCuenta0.Size = New System.Drawing.Size(404, 21)
      Me.cbCuenta0.TabIndex = 1
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(22, 27)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(41, 13)
      Me.Label4.TabIndex = 51
      Me.Label4.Text = "Banco:"
      '
      'cbBanco0
      '
      Me.cbBanco0.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      Me.cbBanco0.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.cbBanco0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbBanco0.FormattingEnabled = True
      Me.cbBanco0.Location = New System.Drawing.Point(103, 24)
      Me.cbBanco0.Name = "cbBanco0"
      Me.cbBanco0.Size = New System.Drawing.Size(404, 21)
      Me.cbBanco0.TabIndex = 0
      '
      'GroupBox2
      '
      Me.GroupBox2.Controls.Add(Me.Label2)
      Me.GroupBox2.Controls.Add(Me.tbTitular1)
      Me.GroupBox2.Controls.Add(Me.Label7)
      Me.GroupBox2.Controls.Add(Me.cbCuenta1)
      Me.GroupBox2.Controls.Add(Me.Label8)
      Me.GroupBox2.Controls.Add(Me.cbBanco1)
      Me.GroupBox2.Location = New System.Drawing.Point(12, 135)
      Me.GroupBox2.Name = "GroupBox2"
      Me.GroupBox2.Size = New System.Drawing.Size(532, 117)
      Me.GroupBox2.TabIndex = 50
      Me.GroupBox2.TabStop = False
      Me.GroupBox2.Text = "Destino"
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(22, 85)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(39, 13)
      Me.Label2.TabIndex = 61
      Me.Label2.Text = "Titular:"
      '
      'tbTitular1
      '
      Me.tbTitular1.Location = New System.Drawing.Point(103, 82)
      Me.tbTitular1.Name = "tbTitular1"
      Me.tbTitular1.Size = New System.Drawing.Size(404, 20)
      Me.tbTitular1.TabIndex = 5
      '
      'Label7
      '
      Me.Label7.AutoSize = True
      Me.Label7.Location = New System.Drawing.Point(22, 58)
      Me.Label7.Name = "Label7"
      Me.Label7.Size = New System.Drawing.Size(44, 13)
      Me.Label7.TabIndex = 59
      Me.Label7.Text = "Cuenta:"
      '
      'cbCuenta1
      '
      Me.cbCuenta1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      Me.cbCuenta1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.cbCuenta1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbCuenta1.FormattingEnabled = True
      Me.cbCuenta1.Location = New System.Drawing.Point(103, 55)
      Me.cbCuenta1.Name = "cbCuenta1"
      Me.cbCuenta1.Size = New System.Drawing.Size(404, 21)
      Me.cbCuenta1.TabIndex = 4
      '
      'Label8
      '
      Me.Label8.AutoSize = True
      Me.Label8.Location = New System.Drawing.Point(22, 31)
      Me.Label8.Name = "Label8"
      Me.Label8.Size = New System.Drawing.Size(41, 13)
      Me.Label8.TabIndex = 57
      Me.Label8.Text = "Banco:"
      '
      'cbBanco1
      '
      Me.cbBanco1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      Me.cbBanco1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.cbBanco1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbBanco1.FormattingEnabled = True
      Me.cbBanco1.Location = New System.Drawing.Point(103, 28)
      Me.cbBanco1.Name = "cbBanco1"
      Me.cbBanco1.Size = New System.Drawing.Size(404, 21)
      Me.cbBanco1.TabIndex = 3
      '
      'gbGastos
      '
      Me.gbGastos.Controls.Add(Me.Label12)
      Me.gbGastos.Controls.Add(Me.tbIva)
      Me.gbGastos.Controls.Add(Me.Label11)
      Me.gbGastos.Controls.Add(Me.tbGastosSF)
      Me.gbGastos.Controls.Add(Me.Label1)
      Me.gbGastos.Controls.Add(Me.tbGastos)
      Me.gbGastos.Location = New System.Drawing.Point(12, 373)
      Me.gbGastos.Name = "gbGastos"
      Me.gbGastos.Size = New System.Drawing.Size(443, 66)
      Me.gbGastos.TabIndex = 66
      Me.gbGastos.TabStop = False
      Me.gbGastos.Text = "Gastos bancarios"
      '
      'Label12
      '
      Me.Label12.AutoSize = True
      Me.Label12.Location = New System.Drawing.Point(312, 30)
      Me.Label12.Name = "Label12"
      Me.Label12.Size = New System.Drawing.Size(31, 13)
      Me.Label12.TabIndex = 71
      Me.Label12.Text = "Iva $"
      '
      'tbIva
      '
      Me.tbIva.Location = New System.Drawing.Point(349, 27)
      Me.tbIva.Name = "tbIva"
      Me.tbIva.Size = New System.Drawing.Size(75, 20)
      Me.tbIva.TabIndex = 11
      '
      'Label11
      '
      Me.Label11.AutoSize = True
      Me.Label11.Location = New System.Drawing.Point(161, 30)
      Me.Label11.Name = "Label11"
      Me.Label11.Size = New System.Drawing.Size(62, 13)
      Me.Label11.TabIndex = 69
      Me.Label11.Text = "Suma Fija $"
      '
      'tbGastosSF
      '
      Me.tbGastosSF.Location = New System.Drawing.Point(229, 27)
      Me.tbGastosSF.Name = "tbGastosSF"
      Me.tbGastosSF.Size = New System.Drawing.Size(77, 20)
      Me.tbGastosSF.TabIndex = 10
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(22, 30)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(49, 13)
      Me.Label1.TabIndex = 67
      Me.Label1.Text = "Gastos $"
      '
      'tbGastos
      '
      Me.tbGastos.Location = New System.Drawing.Point(79, 27)
      Me.tbGastos.Name = "tbGastos"
      Me.tbGastos.Size = New System.Drawing.Size(76, 20)
      Me.tbGastos.TabIndex = 9
      '
      'GroupBox4
      '
      Me.GroupBox4.Controls.Add(Me.lblImporte)
      Me.GroupBox4.Controls.Add(Me.tbImporte)
      Me.GroupBox4.Controls.Add(Me.Label13)
      Me.GroupBox4.Controls.Add(Me.Label9)
      Me.GroupBox4.Controls.Add(Me.tbImpNeto)
      Me.GroupBox4.Controls.Add(Me.tbNumero)
      Me.GroupBox4.Controls.Add(Me.Label3)
      Me.GroupBox4.Controls.Add(Me.dtFecha)
      Me.GroupBox4.Location = New System.Drawing.Point(12, 261)
      Me.GroupBox4.Name = "GroupBox4"
      Me.GroupBox4.Size = New System.Drawing.Size(532, 94)
      Me.GroupBox4.TabIndex = 67
      Me.GroupBox4.TabStop = False
      Me.GroupBox4.Text = "Transferencia"
      '
      'lblImporte
      '
      Me.lblImporte.AutoSize = True
      Me.lblImporte.Location = New System.Drawing.Point(120, 61)
      Me.lblImporte.Name = "lblImporte"
      Me.lblImporte.Size = New System.Drawing.Size(103, 13)
      Me.lblImporte.TabIndex = 71
      Me.lblImporte.Text = "Importe a transferir $"
      '
      'tbImporte
      '
      Me.tbImporte.Location = New System.Drawing.Point(243, 58)
      Me.tbImporte.Name = "tbImporte"
      Me.tbImporte.Size = New System.Drawing.Size(93, 20)
      Me.tbImporte.TabIndex = 8
      '
      'Label13
      '
      Me.Label13.AutoSize = True
      Me.Label13.Location = New System.Drawing.Point(363, 61)
      Me.Label13.Name = "Label13"
      Me.Label13.Size = New System.Drawing.Size(39, 13)
      Me.Label13.TabIndex = 73
      Me.Label13.Text = "Neto $"
      '
      'Label9
      '
      Me.Label9.AutoSize = True
      Me.Label9.Location = New System.Drawing.Point(183, 31)
      Me.Label9.Name = "Label9"
      Me.Label9.Size = New System.Drawing.Size(54, 13)
      Me.Label9.TabIndex = 69
      Me.Label9.Text = "Número #"
      '
      'tbImpNeto
      '
      Me.tbImpNeto.BackColor = System.Drawing.SystemColors.Info
      Me.tbImpNeto.Enabled = False
      Me.tbImpNeto.Location = New System.Drawing.Point(408, 58)
      Me.tbImpNeto.Name = "tbImpNeto"
      Me.tbImpNeto.Size = New System.Drawing.Size(99, 20)
      Me.tbImpNeto.TabIndex = 72
      '
      'tbNumero
      '
      Me.tbNumero.Location = New System.Drawing.Point(243, 27)
      Me.tbNumero.Name = "tbNumero"
      Me.tbNumero.Size = New System.Drawing.Size(93, 20)
      Me.tbNumero.TabIndex = 7
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(22, 31)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(40, 13)
      Me.Label3.TabIndex = 67
      Me.Label3.Text = "Fecha:"
      '
      'dtFecha
      '
      Me.dtFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtFecha.Location = New System.Drawing.Point(74, 27)
      Me.dtFecha.Name = "dtFecha"
      Me.dtFecha.Size = New System.Drawing.Size(94, 20)
      Me.dtFecha.TabIndex = 6
      Me.dtFecha.Value = New Date(2015, 9, 24, 0, 0, 0, 0)
      '
      'cmdCancelar
      '
      Me.cmdCancelar.Location = New System.Drawing.Point(468, 412)
      Me.cmdCancelar.Name = "cmdCancelar"
      Me.cmdCancelar.Size = New System.Drawing.Size(76, 27)
      Me.cmdCancelar.TabIndex = 13
      Me.cmdCancelar.Text = "&Cancelar"
      Me.cmdCancelar.UseVisualStyleBackColor = True
      '
      'cmdAceptar
      '
      Me.cmdAceptar.Location = New System.Drawing.Point(468, 373)
      Me.cmdAceptar.Name = "cmdAceptar"
      Me.cmdAceptar.Size = New System.Drawing.Size(76, 33)
      Me.cmdAceptar.TabIndex = 12
      Me.cmdAceptar.Text = "&Aceptar"
      Me.cmdAceptar.UseVisualStyleBackColor = True
      '
      'frmLiqTransf
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(557, 454)
      Me.Controls.Add(Me.cmdCancelar)
      Me.Controls.Add(Me.cmdAceptar)
      Me.Controls.Add(Me.GroupBox4)
      Me.Controls.Add(Me.gbGastos)
      Me.Controls.Add(Me.GroupBox2)
      Me.Controls.Add(Me.GroupBox1)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "frmLiqTransf"
      Me.Text = "Transferencia"
      Me.GroupBox1.ResumeLayout(False)
      Me.GroupBox1.PerformLayout()
      Me.GroupBox2.ResumeLayout(False)
      Me.GroupBox2.PerformLayout()
      Me.gbGastos.ResumeLayout(False)
      Me.gbGastos.PerformLayout()
      Me.GroupBox4.ResumeLayout(False)
      Me.GroupBox4.PerformLayout()
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents tbTitular0 As System.Windows.Forms.TextBox
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents cbCuenta0 As System.Windows.Forms.ComboBox
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents cbBanco0 As System.Windows.Forms.ComboBox
   Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents tbTitular1 As System.Windows.Forms.TextBox
   Friend WithEvents Label7 As System.Windows.Forms.Label
   Friend WithEvents cbCuenta1 As System.Windows.Forms.ComboBox
   Friend WithEvents Label8 As System.Windows.Forms.Label
   Friend WithEvents cbBanco1 As System.Windows.Forms.ComboBox
   Friend WithEvents gbGastos As System.Windows.Forms.GroupBox
   Friend WithEvents Label12 As System.Windows.Forms.Label
   Friend WithEvents tbIva As System.Windows.Forms.TextBox
   Friend WithEvents Label11 As System.Windows.Forms.Label
   Friend WithEvents tbGastosSF As System.Windows.Forms.TextBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents tbGastos As System.Windows.Forms.TextBox
   Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
   Friend WithEvents lblImporte As System.Windows.Forms.Label
   Friend WithEvents tbImporte As System.Windows.Forms.TextBox
   Friend WithEvents Label9 As System.Windows.Forms.Label
   Friend WithEvents tbNumero As System.Windows.Forms.TextBox
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents dtFecha As System.Windows.Forms.DateTimePicker
   Friend WithEvents Label13 As System.Windows.Forms.Label
   Friend WithEvents tbImpNeto As System.Windows.Forms.TextBox
   Friend WithEvents cmdCancelar As System.Windows.Forms.Button
   Friend WithEvents cmdAceptar As System.Windows.Forms.Button
End Class
