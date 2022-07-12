<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFactInqAM
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
      Me.btAceptar = New System.Windows.Forms.Button()
      Me.tbPropietario = New System.Windows.Forms.TextBox()
      Me.Label11 = New System.Windows.Forms.Label()
      Me.tbPropiedad = New System.Windows.Forms.TextBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.cbDescConc = New System.Windows.Forms.ComboBox()
      Me.cbConcepto = New System.Windows.Forms.ComboBox()
      Me.dtFecha = New System.Windows.Forms.DateTimePicker()
      Me.Label22 = New System.Windows.Forms.Label()
      Me.tbDetalle = New System.Windows.Forms.TextBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.tbImporte = New System.Windows.Forms.TextBox()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.gbImput = New System.Windows.Forms.GroupBox()
      Me.optHaber = New System.Windows.Forms.RadioButton()
      Me.optDebe = New System.Windows.Forms.RadioButton()
      Me.gbAsign = New System.Windows.Forms.GroupBox()
      Me.optAdmin = New System.Windows.Forms.RadioButton()
      Me.optPropiet = New System.Windows.Forms.RadioButton()
      Me.btCancelar = New System.Windows.Forms.Button()
      Me.tbPeriodo = New System.Windows.Forms.TextBox()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.tbInquilino = New System.Windows.Forms.TextBox()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.gbImput.SuspendLayout()
      Me.gbAsign.SuspendLayout()
      Me.SuspendLayout()
      '
      'btAceptar
      '
      Me.btAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btAceptar.Location = New System.Drawing.Point(416, 336)
      Me.btAceptar.Name = "btAceptar"
      Me.btAceptar.Size = New System.Drawing.Size(76, 27)
      Me.btAceptar.TabIndex = 12
      Me.btAceptar.Text = "&Aceptar"
      Me.btAceptar.UseVisualStyleBackColor = True
      '
      'tbPropietario
      '
      Me.tbPropietario.Enabled = False
      Me.tbPropietario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.tbPropietario.Location = New System.Drawing.Point(80, 20)
      Me.tbPropietario.Name = "tbPropietario"
      Me.tbPropietario.Size = New System.Drawing.Size(496, 20)
      Me.tbPropietario.TabIndex = 0
      '
      'Label11
      '
      Me.Label11.AutoSize = True
      Me.Label11.Location = New System.Drawing.Point(16, 23)
      Me.Label11.Name = "Label11"
      Me.Label11.Size = New System.Drawing.Size(60, 13)
      Me.Label11.TabIndex = 102
      Me.Label11.Text = "Propietario:"
      '
      'tbPropiedad
      '
      Me.tbPropiedad.Enabled = False
      Me.tbPropiedad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.tbPropiedad.Location = New System.Drawing.Point(80, 46)
      Me.tbPropiedad.Name = "tbPropiedad"
      Me.tbPropiedad.Size = New System.Drawing.Size(496, 20)
      Me.tbPropiedad.TabIndex = 1
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(16, 49)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(58, 13)
      Me.Label1.TabIndex = 105
      Me.Label1.Text = "Propiedad:"
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(16, 102)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(56, 13)
      Me.Label2.TabIndex = 107
      Me.Label2.Text = "Concepto:"
      '
      'cbDescConc
      '
      Me.cbDescConc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      Me.cbDescConc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.cbDescConc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbDescConc.FormattingEnabled = True
      Me.cbDescConc.Location = New System.Drawing.Point(160, 99)
      Me.cbDescConc.Name = "cbDescConc"
      Me.cbDescConc.Size = New System.Drawing.Size(416, 21)
      Me.cbDescConc.TabIndex = 4
      '
      'cbConcepto
      '
      Me.cbConcepto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      Me.cbConcepto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.cbConcepto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbConcepto.FormattingEnabled = True
      Me.cbConcepto.Location = New System.Drawing.Point(80, 99)
      Me.cbConcepto.Name = "cbConcepto"
      Me.cbConcepto.Size = New System.Drawing.Size(74, 21)
      Me.cbConcepto.TabIndex = 3
      '
      'dtFecha
      '
      Me.dtFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtFecha.Location = New System.Drawing.Point(96, 126)
      Me.dtFecha.Name = "dtFecha"
      Me.dtFecha.Size = New System.Drawing.Size(88, 20)
      Me.dtFecha.TabIndex = 5
      '
      'Label22
      '
      Me.Label22.AutoSize = True
      Me.Label22.Location = New System.Drawing.Point(16, 130)
      Me.Label22.Name = "Label22"
      Me.Label22.Size = New System.Drawing.Size(74, 13)
      Me.Label22.TabIndex = 109
      Me.Label22.Text = "Fecha Desde:"
      '
      'tbDetalle
      '
      Me.tbDetalle.AcceptsReturn = True
      Me.tbDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.tbDetalle.Location = New System.Drawing.Point(80, 151)
      Me.tbDetalle.Name = "tbDetalle"
      Me.tbDetalle.Size = New System.Drawing.Size(496, 20)
      Me.tbDetalle.TabIndex = 6
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(16, 154)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(43, 13)
      Me.Label3.TabIndex = 112
      Me.Label3.Text = "Detalle:"
      '
      'tbImporte
      '
      Me.tbImporte.AcceptsReturn = True
      Me.tbImporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.tbImporte.Location = New System.Drawing.Point(80, 177)
      Me.tbImporte.MaxLength = 10
      Me.tbImporte.Name = "tbImporte"
      Me.tbImporte.Size = New System.Drawing.Size(104, 20)
      Me.tbImporte.TabIndex = 7
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.Location = New System.Drawing.Point(16, 180)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(51, 13)
      Me.Label5.TabIndex = 117
      Me.Label5.Text = "Importe $"
      '
      'gbImput
      '
      Me.gbImput.Controls.Add(Me.optHaber)
      Me.gbImput.Controls.Add(Me.optDebe)
      Me.gbImput.Location = New System.Drawing.Point(19, 220)
      Me.gbImput.Name = "gbImput"
      Me.gbImput.Size = New System.Drawing.Size(220, 100)
      Me.gbImput.TabIndex = 118
      Me.gbImput.TabStop = False
      Me.gbImput.Text = "Imputación"
      '
      'optHaber
      '
      Me.optHaber.AutoSize = True
      Me.optHaber.Location = New System.Drawing.Point(128, 42)
      Me.optHaber.Name = "optHaber"
      Me.optHaber.Size = New System.Drawing.Size(58, 17)
      Me.optHaber.TabIndex = 9
      Me.optHaber.Text = "&Crédito"
      Me.optHaber.UseVisualStyleBackColor = True
      '
      'optDebe
      '
      Me.optDebe.AutoSize = True
      Me.optDebe.Checked = True
      Me.optDebe.Location = New System.Drawing.Point(46, 42)
      Me.optDebe.Name = "optDebe"
      Me.optDebe.Size = New System.Drawing.Size(56, 17)
      Me.optDebe.TabIndex = 8
      Me.optDebe.TabStop = True
      Me.optDebe.Text = "&Débito"
      Me.optDebe.UseVisualStyleBackColor = True
      '
      'gbAsign
      '
      Me.gbAsign.Controls.Add(Me.optAdmin)
      Me.gbAsign.Controls.Add(Me.optPropiet)
      Me.gbAsign.Location = New System.Drawing.Point(258, 220)
      Me.gbAsign.Name = "gbAsign"
      Me.gbAsign.Size = New System.Drawing.Size(316, 100)
      Me.gbAsign.TabIndex = 119
      Me.gbAsign.TabStop = False
      Me.gbAsign.Text = "Asignación"
      '
      'optAdmin
      '
      Me.optAdmin.AutoSize = True
      Me.optAdmin.Location = New System.Drawing.Point(182, 42)
      Me.optAdmin.Name = "optAdmin"
      Me.optAdmin.Size = New System.Drawing.Size(93, 17)
      Me.optAdmin.TabIndex = 11
      Me.optAdmin.Text = "&Administración"
      Me.optAdmin.UseVisualStyleBackColor = True
      '
      'optPropiet
      '
      Me.optPropiet.AutoSize = True
      Me.optPropiet.Checked = True
      Me.optPropiet.Location = New System.Drawing.Point(77, 42)
      Me.optPropiet.Name = "optPropiet"
      Me.optPropiet.Size = New System.Drawing.Size(75, 17)
      Me.optPropiet.TabIndex = 10
      Me.optPropiet.TabStop = True
      Me.optPropiet.Text = "&Propietario"
      Me.optPropiet.UseVisualStyleBackColor = True
      '
      'btCancelar
      '
      Me.btCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btCancelar.Location = New System.Drawing.Point(498, 336)
      Me.btCancelar.Name = "btCancelar"
      Me.btCancelar.Size = New System.Drawing.Size(76, 27)
      Me.btCancelar.TabIndex = 120
      Me.btCancelar.Text = "&Cancelar"
      Me.btCancelar.UseVisualStyleBackColor = True
      '
      'tbPeriodo
      '
      Me.tbPeriodo.AcceptsReturn = True
      Me.tbPeriodo.Enabled = False
      Me.tbPeriodo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.tbPeriodo.Location = New System.Drawing.Point(80, 72)
      Me.tbPeriodo.MaxLength = 10
      Me.tbPeriodo.Name = "tbPeriodo"
      Me.tbPeriodo.Size = New System.Drawing.Size(57, 20)
      Me.tbPeriodo.TabIndex = 2
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(16, 75)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(48, 13)
      Me.Label4.TabIndex = 122
      Me.Label4.Text = "Período:"
      '
      'tbInquilino
      '
      Me.tbInquilino.AcceptsReturn = True
      Me.tbInquilino.Enabled = False
      Me.tbInquilino.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.tbInquilino.Location = New System.Drawing.Point(178, 72)
      Me.tbInquilino.MaxLength = 10
      Me.tbInquilino.Name = "tbInquilino"
      Me.tbInquilino.Size = New System.Drawing.Size(398, 20)
      Me.tbInquilino.TabIndex = 123
      '
      'Label6
      '
      Me.Label6.AutoSize = True
      Me.Label6.Location = New System.Drawing.Point(144, 75)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(28, 13)
      Me.Label6.TabIndex = 124
      Me.Label6.Text = "Inq.:"
      '
      'frmFactInqAM
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(586, 375)
      Me.Controls.Add(Me.tbInquilino)
      Me.Controls.Add(Me.Label6)
      Me.Controls.Add(Me.tbPeriodo)
      Me.Controls.Add(Me.Label4)
      Me.Controls.Add(Me.btCancelar)
      Me.Controls.Add(Me.gbAsign)
      Me.Controls.Add(Me.gbImput)
      Me.Controls.Add(Me.tbImporte)
      Me.Controls.Add(Me.Label5)
      Me.Controls.Add(Me.tbDetalle)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.dtFecha)
      Me.Controls.Add(Me.Label22)
      Me.Controls.Add(Me.cbConcepto)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.cbDescConc)
      Me.Controls.Add(Me.tbPropiedad)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.btAceptar)
      Me.Controls.Add(Me.tbPropietario)
      Me.Controls.Add(Me.Label11)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.KeyPreview = True
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "frmFactInqAM"
      Me.Text = "Facturación Inquilino"
      Me.gbImput.ResumeLayout(False)
      Me.gbImput.PerformLayout()
      Me.gbAsign.ResumeLayout(False)
      Me.gbAsign.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents btAceptar As System.Windows.Forms.Button
   Friend WithEvents tbPropietario As System.Windows.Forms.TextBox
   Friend WithEvents Label11 As System.Windows.Forms.Label
   Friend WithEvents tbPropiedad As System.Windows.Forms.TextBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents cbDescConc As System.Windows.Forms.ComboBox
   Friend WithEvents cbConcepto As System.Windows.Forms.ComboBox
   Friend WithEvents dtFecha As System.Windows.Forms.DateTimePicker
   Friend WithEvents Label22 As System.Windows.Forms.Label
   Friend WithEvents tbDetalle As System.Windows.Forms.TextBox
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents tbImporte As System.Windows.Forms.TextBox
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents gbImput As System.Windows.Forms.GroupBox
   Friend WithEvents optHaber As System.Windows.Forms.RadioButton
   Friend WithEvents optDebe As System.Windows.Forms.RadioButton
   Friend WithEvents gbAsign As System.Windows.Forms.GroupBox
   Friend WithEvents optAdmin As System.Windows.Forms.RadioButton
   Friend WithEvents optPropiet As System.Windows.Forms.RadioButton
   Friend WithEvents btCancelar As System.Windows.Forms.Button
   Friend WithEvents tbPeriodo As System.Windows.Forms.TextBox
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents tbInquilino As TextBox
   Friend WithEvents Label6 As Label
End Class
