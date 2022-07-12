<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPagosAgrCmp
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
      Me.cbPropietario = New System.Windows.Forms.ComboBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.dtpFecHasta = New System.Windows.Forms.DateTimePicker()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.dtpFecDesde = New System.Windows.Forms.DateTimePicker()
      Me.tbNombre = New System.Windows.Forms.TextBox()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.cbPropiedad = New System.Windows.Forms.ComboBox()
      Me.gbPropietario = New System.Windows.Forms.GroupBox()
      Me.DataGridView1 = New System.Windows.Forms.DataGridView()
      Me.cmdCancelar = New System.Windows.Forms.Button()
      Me.cmdAgregar = New System.Windows.Forms.Button()
      Me.chkTodas = New System.Windows.Forms.CheckBox()
      Me.gbPropietario.SuspendLayout()
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'cbPropietario
      '
      Me.cbPropietario.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      Me.cbPropietario.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.cbPropietario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbPropietario.FormattingEnabled = True
      Me.cbPropietario.Location = New System.Drawing.Point(14, 19)
      Me.cbPropietario.Name = "cbPropietario"
      Me.cbPropietario.Size = New System.Drawing.Size(349, 21)
      Me.cbPropietario.TabIndex = 112
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(9, 16)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(59, 13)
      Me.Label2.TabIndex = 113
      Me.Label2.Text = "Proveedor:"
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(146, 71)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(38, 13)
      Me.Label1.TabIndex = 111
      Me.Label1.Text = "Hasta:"
      '
      'dtpFecHasta
      '
      Me.dtpFecHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpFecHasta.Location = New System.Drawing.Point(190, 68)
      Me.dtpFecHasta.Name = "dtpFecHasta"
      Me.dtpFecHasta.Size = New System.Drawing.Size(81, 20)
      Me.dtpFecHasta.TabIndex = 110
      Me.dtpFecHasta.Value = New Date(2015, 9, 24, 0, 0, 0, 0)
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(12, 71)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(41, 13)
      Me.Label4.TabIndex = 109
      Me.Label4.Text = "Desde:"
      '
      'dtpFecDesde
      '
      Me.dtpFecDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpFecDesde.Location = New System.Drawing.Point(59, 68)
      Me.dtpFecDesde.Name = "dtpFecDesde"
      Me.dtpFecDesde.Size = New System.Drawing.Size(81, 20)
      Me.dtpFecDesde.TabIndex = 108
      Me.dtpFecDesde.Value = New Date(2015, 9, 24, 0, 0, 0, 0)
      '
      'tbNombre
      '
      Me.tbNombre.Enabled = False
      Me.tbNombre.Location = New System.Drawing.Point(12, 32)
      Me.tbNombre.Name = "tbNombre"
      Me.tbNombre.Size = New System.Drawing.Size(326, 20)
      Me.tbNombre.TabIndex = 115
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.Location = New System.Drawing.Point(6, 43)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(58, 13)
      Me.Label5.TabIndex = 117
      Me.Label5.Text = "Propiedad:"
      '
      'cbPropiedad
      '
      Me.cbPropiedad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      Me.cbPropiedad.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.cbPropiedad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbPropiedad.FormattingEnabled = True
      Me.cbPropiedad.Location = New System.Drawing.Point(14, 59)
      Me.cbPropiedad.Name = "cbPropiedad"
      Me.cbPropiedad.Size = New System.Drawing.Size(349, 21)
      Me.cbPropiedad.TabIndex = 116
      '
      'gbPropietario
      '
      Me.gbPropietario.Controls.Add(Me.cbPropietario)
      Me.gbPropietario.Controls.Add(Me.Label5)
      Me.gbPropietario.Controls.Add(Me.cbPropiedad)
      Me.gbPropietario.Location = New System.Drawing.Point(352, 12)
      Me.gbPropietario.Name = "gbPropietario"
      Me.gbPropietario.Size = New System.Drawing.Size(369, 94)
      Me.gbPropietario.TabIndex = 118
      Me.gbPropietario.TabStop = False
      Me.gbPropietario.Text = "Propietario"
      '
      'DataGridView1
      '
      Me.DataGridView1.AllowUserToAddRows = False
      Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
      Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.DataGridView1.Location = New System.Drawing.Point(12, 112)
      Me.DataGridView1.Name = "DataGridView1"
      Me.DataGridView1.ReadOnly = True
      Me.DataGridView1.RowTemplate.ReadOnly = True
      Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.DataGridView1.Size = New System.Drawing.Size(709, 328)
      Me.DataGridView1.TabIndex = 119
      '
      'cmdCancelar
      '
      Me.cmdCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdCancelar.Location = New System.Drawing.Point(657, 446)
      Me.cmdCancelar.Name = "cmdCancelar"
      Me.cmdCancelar.Size = New System.Drawing.Size(64, 27)
      Me.cmdCancelar.TabIndex = 121
      Me.cmdCancelar.Text = "&Cerrar"
      Me.cmdCancelar.UseVisualStyleBackColor = True
      '
      'cmdAgregar
      '
      Me.cmdAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdAgregar.Location = New System.Drawing.Point(575, 446)
      Me.cmdAgregar.Name = "cmdAgregar"
      Me.cmdAgregar.Size = New System.Drawing.Size(76, 27)
      Me.cmdAgregar.TabIndex = 120
      Me.cmdAgregar.Text = "&Agregar"
      Me.cmdAgregar.UseVisualStyleBackColor = True
      '
      'chkTodas
      '
      Me.chkTodas.AutoSize = True
      Me.chkTodas.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.chkTodas.Location = New System.Drawing.Point(282, 70)
      Me.chkTodas.Name = "chkTodas"
      Me.chkTodas.Size = New System.Drawing.Size(56, 17)
      Me.chkTodas.TabIndex = 122
      Me.chkTodas.Text = "&Todas"
      Me.chkTodas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      Me.chkTodas.UseVisualStyleBackColor = True
      '
      'frmPagosAgrCmp
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(733, 485)
      Me.Controls.Add(Me.chkTodas)
      Me.Controls.Add(Me.cmdCancelar)
      Me.Controls.Add(Me.cmdAgregar)
      Me.Controls.Add(Me.DataGridView1)
      Me.Controls.Add(Me.gbPropietario)
      Me.Controls.Add(Me.tbNombre)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.dtpFecHasta)
      Me.Controls.Add(Me.Label4)
      Me.Controls.Add(Me.dtpFecDesde)
      Me.Name = "frmPagosAgrCmp"
      Me.Text = "Pagos: Agregar Comprobante"
      Me.gbPropietario.ResumeLayout(False)
      Me.gbPropietario.PerformLayout()
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents cbPropietario As System.Windows.Forms.ComboBox
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents dtpFecHasta As System.Windows.Forms.DateTimePicker
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents dtpFecDesde As System.Windows.Forms.DateTimePicker
   Friend WithEvents tbNombre As System.Windows.Forms.TextBox
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents cbPropiedad As System.Windows.Forms.ComboBox
   Friend WithEvents gbPropietario As System.Windows.Forms.GroupBox
   Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
   Friend WithEvents cmdCancelar As System.Windows.Forms.Button
   Friend WithEvents cmdAgregar As System.Windows.Forms.Button
   Friend WithEvents chkTodas As System.Windows.Forms.CheckBox
End Class
