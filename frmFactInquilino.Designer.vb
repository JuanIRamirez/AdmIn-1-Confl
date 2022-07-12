<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFactInquilino
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
      Me.cbInquilino = New System.Windows.Forms.ComboBox()
      Me.Label13 = New System.Windows.Forms.Label()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.cbPropiedad = New System.Windows.Forms.ComboBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.cbPeriodo = New System.Windows.Forms.ComboBox()
      Me.tbPropietario = New System.Windows.Forms.TextBox()
      Me.Label11 = New System.Windows.Forms.Label()
      Me.cmdSalir = New System.Windows.Forms.Button()
      Me.DataGridView1 = New System.Windows.Forms.DataGridView()
      Me.cmdBaja = New System.Windows.Forms.Button()
      Me.cmdEditar = New System.Windows.Forms.Button()
      Me.cmdAlta = New System.Windows.Forms.Button()
      Me.lblInfo = New System.Windows.Forms.Label()
      Me.tbTotConc = New System.Windows.Forms.TextBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.tbSdoAnt = New System.Windows.Forms.TextBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.tbTotal = New System.Windows.Forms.TextBox()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.chkFRango = New System.Windows.Forms.CheckBox()
      Me.optActual = New System.Windows.Forms.RadioButton()
      Me.optAnterior = New System.Windows.Forms.RadioButton()
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'cbInquilino
      '
      Me.cbInquilino.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      Me.cbInquilino.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.cbInquilino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbInquilino.FormattingEnabled = True
      Me.cbInquilino.Location = New System.Drawing.Point(67, 12)
      Me.cbInquilino.Name = "cbInquilino"
      Me.cbInquilino.Size = New System.Drawing.Size(351, 21)
      Me.cbInquilino.TabIndex = 71
      '
      'Label13
      '
      Me.Label13.AutoSize = True
      Me.Label13.Location = New System.Drawing.Point(12, 15)
      Me.Label13.Name = "Label13"
      Me.Label13.Size = New System.Drawing.Size(49, 13)
      Me.Label13.TabIndex = 72
      Me.Label13.Text = "Inquilino:"
      '
      'Label6
      '
      Me.Label6.AutoSize = True
      Me.Label6.Location = New System.Drawing.Point(427, 15)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(58, 13)
      Me.Label6.TabIndex = 75
      Me.Label6.Text = "Propiedad:"
      '
      'cbPropiedad
      '
      Me.cbPropiedad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbPropiedad.FormattingEnabled = True
      Me.cbPropiedad.Location = New System.Drawing.Point(491, 12)
      Me.cbPropiedad.Name = "cbPropiedad"
      Me.cbPropiedad.Size = New System.Drawing.Size(381, 21)
      Me.cbPropiedad.TabIndex = 74
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(403, 48)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(48, 13)
      Me.Label2.TabIndex = 90
      Me.Label2.Text = "Período:"
      '
      'cbPeriodo
      '
      Me.cbPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbPeriodo.FormattingEnabled = True
      Me.cbPeriodo.Location = New System.Drawing.Point(457, 45)
      Me.cbPeriodo.Name = "cbPeriodo"
      Me.cbPeriodo.Size = New System.Drawing.Size(81, 21)
      Me.cbPeriodo.TabIndex = 88
      '
      'tbPropietario
      '
      Me.tbPropietario.Enabled = False
      Me.tbPropietario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.tbPropietario.Location = New System.Drawing.Point(80, 45)
      Me.tbPropietario.Name = "tbPropietario"
      Me.tbPropietario.Size = New System.Drawing.Size(317, 20)
      Me.tbPropietario.TabIndex = 87
      '
      'Label11
      '
      Me.Label11.AutoSize = True
      Me.Label11.Location = New System.Drawing.Point(12, 48)
      Me.Label11.Name = "Label11"
      Me.Label11.Size = New System.Drawing.Size(60, 13)
      Me.Label11.TabIndex = 89
      Me.Label11.Text = "Propietario:"
      '
      'cmdSalir
      '
      Me.cmdSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.cmdSalir.Location = New System.Drawing.Point(815, 454)
      Me.cmdSalir.Name = "cmdSalir"
      Me.cmdSalir.Size = New System.Drawing.Size(62, 27)
      Me.cmdSalir.TabIndex = 94
      Me.cmdSalir.Text = "&Salir"
      Me.cmdSalir.UseVisualStyleBackColor = True
      '
      'DataGridView1
      '
      Me.DataGridView1.AllowUserToAddRows = False
      Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
      Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.DataGridView1.Location = New System.Drawing.Point(11, 74)
      Me.DataGridView1.Name = "DataGridView1"
      Me.DataGridView1.ReadOnly = True
      Me.DataGridView1.RowTemplate.ReadOnly = True
      Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.DataGridView1.Size = New System.Drawing.Size(866, 330)
      Me.DataGridView1.TabIndex = 95
      '
      'cmdBaja
      '
      Me.cmdBaja.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdBaja.Enabled = False
      Me.cmdBaja.Location = New System.Drawing.Point(82, 413)
      Me.cmdBaja.Name = "cmdBaja"
      Me.cmdBaja.Size = New System.Drawing.Size(60, 27)
      Me.cmdBaja.TabIndex = 101
      Me.cmdBaja.Text = "&Quitar"
      Me.cmdBaja.UseVisualStyleBackColor = True
      '
      'cmdEditar
      '
      Me.cmdEditar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdEditar.Enabled = False
      Me.cmdEditar.Location = New System.Drawing.Point(148, 413)
      Me.cmdEditar.Name = "cmdEditar"
      Me.cmdEditar.Size = New System.Drawing.Size(66, 27)
      Me.cmdEditar.TabIndex = 102
      Me.cmdEditar.Text = "&Modificar"
      Me.cmdEditar.UseVisualStyleBackColor = True
      '
      'cmdAlta
      '
      Me.cmdAlta.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdAlta.Enabled = False
      Me.cmdAlta.Location = New System.Drawing.Point(12, 413)
      Me.cmdAlta.Name = "cmdAlta"
      Me.cmdAlta.Size = New System.Drawing.Size(64, 27)
      Me.cmdAlta.TabIndex = 100
      Me.cmdAlta.Text = "A&gregar"
      Me.cmdAlta.UseVisualStyleBackColor = True
      '
      'lblInfo
      '
      Me.lblInfo.AutoSize = True
      Me.lblInfo.ForeColor = System.Drawing.Color.Red
      Me.lblInfo.Location = New System.Drawing.Point(30, 511)
      Me.lblInfo.Name = "lblInfo"
      Me.lblInfo.Size = New System.Drawing.Size(0, 13)
      Me.lblInfo.TabIndex = 103
      '
      'tbTotConc
      '
      Me.tbTotConc.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tbTotConc.Enabled = False
      Me.tbTotConc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.tbTotConc.Location = New System.Drawing.Point(671, 410)
      Me.tbTotConc.Name = "tbTotConc"
      Me.tbTotConc.Size = New System.Drawing.Size(103, 20)
      Me.tbTotConc.TabIndex = 104
      '
      'Label1
      '
      Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(571, 413)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(94, 13)
      Me.Label1.TabIndex = 105
      Me.Label1.Text = "Total Conceptos $"
      '
      'tbSdoAnt
      '
      Me.tbSdoAnt.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tbSdoAnt.Enabled = False
      Me.tbSdoAnt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.tbSdoAnt.Location = New System.Drawing.Point(671, 436)
      Me.tbSdoAnt.Name = "tbSdoAnt"
      Me.tbSdoAnt.Size = New System.Drawing.Size(103, 20)
      Me.tbSdoAnt.TabIndex = 106
      '
      'Label3
      '
      Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(571, 439)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(82, 13)
      Me.Label3.TabIndex = 107
      Me.Label3.Text = "Saldo Anterior $"
      '
      'tbTotal
      '
      Me.tbTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tbTotal.Enabled = False
      Me.tbTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.tbTotal.Location = New System.Drawing.Point(671, 462)
      Me.tbTotal.Name = "tbTotal"
      Me.tbTotal.Size = New System.Drawing.Size(103, 20)
      Me.tbTotal.TabIndex = 108
      '
      'Label4
      '
      Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(571, 465)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(40, 13)
      Me.Label4.TabIndex = 109
      Me.Label4.Text = "Total $"
      '
      'chkFRango
      '
      Me.chkFRango.AutoSize = True
      Me.chkFRango.Location = New System.Drawing.Point(769, 48)
      Me.chkFRango.Name = "chkFRango"
      Me.chkFRango.Size = New System.Drawing.Size(103, 17)
      Me.chkFRango.TabIndex = 110
      Me.chkFRango.Text = "&Fuera de Rango"
      Me.chkFRango.UseVisualStyleBackColor = True
      '
      'optActual
      '
      Me.optActual.AutoSize = True
      Me.optActual.Checked = True
      Me.optActual.Location = New System.Drawing.Point(558, 48)
      Me.optActual.Name = "optActual"
      Me.optActual.Size = New System.Drawing.Size(80, 17)
      Me.optActual.TabIndex = 111
      Me.optActual.TabStop = True
      Me.optActual.Text = "Ctto. &Actual"
      Me.optActual.UseVisualStyleBackColor = True
      '
      'optAnterior
      '
      Me.optAnterior.AutoSize = True
      Me.optAnterior.Location = New System.Drawing.Point(653, 48)
      Me.optAnterior.Name = "optAnterior"
      Me.optAnterior.Size = New System.Drawing.Size(86, 17)
      Me.optAnterior.TabIndex = 112
      Me.optAnterior.Text = "Ctto. A&nterior"
      Me.optAnterior.UseVisualStyleBackColor = True
      '
      'frmFactInquilino
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(884, 491)
      Me.Controls.Add(Me.optAnterior)
      Me.Controls.Add(Me.optActual)
      Me.Controls.Add(Me.chkFRango)
      Me.Controls.Add(Me.tbTotal)
      Me.Controls.Add(Me.Label4)
      Me.Controls.Add(Me.tbSdoAnt)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.tbTotConc)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.lblInfo)
      Me.Controls.Add(Me.cmdBaja)
      Me.Controls.Add(Me.cmdEditar)
      Me.Controls.Add(Me.cmdAlta)
      Me.Controls.Add(Me.DataGridView1)
      Me.Controls.Add(Me.cmdSalir)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.cbPeriodo)
      Me.Controls.Add(Me.tbPropietario)
      Me.Controls.Add(Me.Label11)
      Me.Controls.Add(Me.Label6)
      Me.Controls.Add(Me.cbPropiedad)
      Me.Controls.Add(Me.cbInquilino)
      Me.Controls.Add(Me.Label13)
      Me.Name = "frmFactInquilino"
      Me.Text = "Facturación Inquilino"
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents cbInquilino As System.Windows.Forms.ComboBox
   Friend WithEvents Label13 As System.Windows.Forms.Label
   Friend WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents cbPropiedad As System.Windows.Forms.ComboBox
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents cbPeriodo As System.Windows.Forms.ComboBox
   Friend WithEvents tbPropietario As System.Windows.Forms.TextBox
   Friend WithEvents Label11 As System.Windows.Forms.Label
   Friend WithEvents cmdSalir As System.Windows.Forms.Button
   Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
   Friend WithEvents cmdBaja As System.Windows.Forms.Button
   Friend WithEvents cmdEditar As System.Windows.Forms.Button
   Friend WithEvents cmdAlta As System.Windows.Forms.Button
   Friend WithEvents lblInfo As System.Windows.Forms.Label
   Friend WithEvents tbTotConc As System.Windows.Forms.TextBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents tbSdoAnt As System.Windows.Forms.TextBox
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents tbTotal As System.Windows.Forms.TextBox
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents chkFRango As System.Windows.Forms.CheckBox
   Friend WithEvents optActual As RadioButton
   Friend WithEvents optAnterior As RadioButton
End Class
