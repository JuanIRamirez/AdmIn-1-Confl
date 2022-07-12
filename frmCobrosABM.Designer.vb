<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCobrosABM
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
      Me.cbCliente = New System.Windows.Forms.ComboBox()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.cbEstado = New System.Windows.Forms.ComboBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.dtpHasta = New System.Windows.Forms.DateTimePicker()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.dtpDesde = New System.Windows.Forms.DateTimePicker()
      Me.DataGridView1 = New System.Windows.Forms.DataGridView()
      Me.cmdSalir = New System.Windows.Forms.Button()
      Me.cmdAnular = New System.Windows.Forms.Button()
      Me.cmdDevolver = New System.Windows.Forms.Button()
      Me.cmdAlta = New System.Windows.Forms.Button()
      Me.cmdDetalle = New System.Windows.Forms.Button()
      Me.chkFecTodas = New System.Windows.Forms.CheckBox()
      Me.cmdImprimir = New System.Windows.Forms.Button()
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'cbCliente
      '
      Me.cbCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      Me.cbCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.cbCliente.FormattingEnabled = True
      Me.cbCliente.Location = New System.Drawing.Point(59, 12)
      Me.cbCliente.Name = "cbCliente"
      Me.cbCliente.Size = New System.Drawing.Size(414, 21)
      Me.cbCliente.TabIndex = 98
      '
      'Label6
      '
      Me.Label6.AutoSize = True
      Me.Label6.Location = New System.Drawing.Point(11, 16)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(42, 13)
      Me.Label6.TabIndex = 99
      Me.Label6.Text = "Cliente:"
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(488, 16)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(43, 13)
      Me.Label3.TabIndex = 97
      Me.Label3.Text = "Estado:"
      '
      'cbEstado
      '
      Me.cbEstado.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      Me.cbEstado.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.cbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbEstado.FormattingEnabled = True
      Me.cbEstado.Location = New System.Drawing.Point(537, 13)
      Me.cbEstado.Name = "cbEstado"
      Me.cbEstado.Size = New System.Drawing.Size(122, 21)
      Me.cbEstado.TabIndex = 96
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(145, 42)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(38, 13)
      Me.Label1.TabIndex = 103
      Me.Label1.Text = "Hasta:"
      '
      'dtpHasta
      '
      Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpHasta.Location = New System.Drawing.Point(191, 39)
      Me.dtpHasta.Name = "dtpHasta"
      Me.dtpHasta.Size = New System.Drawing.Size(80, 20)
      Me.dtpHasta.TabIndex = 102
      Me.dtpHasta.Value = New Date(2015, 9, 24, 0, 0, 0, 0)
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(13, 42)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(40, 13)
      Me.Label4.TabIndex = 101
      Me.Label4.Text = "Fecha:"
      '
      'dtpDesde
      '
      Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDesde.Location = New System.Drawing.Point(59, 39)
      Me.dtpDesde.Name = "dtpDesde"
      Me.dtpDesde.Size = New System.Drawing.Size(80, 20)
      Me.dtpDesde.TabIndex = 100
      Me.dtpDesde.Value = New Date(2015, 9, 24, 0, 0, 0, 0)
      '
      'DataGridView1
      '
      Me.DataGridView1.AllowUserToAddRows = False
      Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
      Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.DataGridView1.Location = New System.Drawing.Point(12, 65)
      Me.DataGridView1.Name = "DataGridView1"
      Me.DataGridView1.ReadOnly = True
      Me.DataGridView1.RowTemplate.ReadOnly = True
      Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.DataGridView1.Size = New System.Drawing.Size(764, 437)
      Me.DataGridView1.TabIndex = 113
      '
      'cmdSalir
      '
      Me.cmdSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdSalir.Location = New System.Drawing.Point(700, 508)
      Me.cmdSalir.Name = "cmdSalir"
      Me.cmdSalir.Size = New System.Drawing.Size(76, 27)
      Me.cmdSalir.TabIndex = 117
      Me.cmdSalir.Text = "&Salir"
      Me.cmdSalir.UseVisualStyleBackColor = True
      '
      'cmdAnular
      '
      Me.cmdAnular.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdAnular.Enabled = False
      Me.cmdAnular.Location = New System.Drawing.Point(83, 508)
      Me.cmdAnular.Name = "cmdAnular"
      Me.cmdAnular.Size = New System.Drawing.Size(65, 27)
      Me.cmdAnular.TabIndex = 115
      Me.cmdAnular.Text = "A&nular"
      Me.cmdAnular.UseVisualStyleBackColor = True
      '
      'cmdDevolver
      '
      Me.cmdDevolver.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdDevolver.Enabled = False
      Me.cmdDevolver.Location = New System.Drawing.Point(154, 508)
      Me.cmdDevolver.Name = "cmdDevolver"
      Me.cmdDevolver.Size = New System.Drawing.Size(75, 27)
      Me.cmdDevolver.TabIndex = 116
      Me.cmdDevolver.Text = "&Devolver"
      Me.cmdDevolver.UseVisualStyleBackColor = True
      '
      'cmdAlta
      '
      Me.cmdAlta.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdAlta.Location = New System.Drawing.Point(12, 508)
      Me.cmdAlta.Name = "cmdAlta"
      Me.cmdAlta.Size = New System.Drawing.Size(65, 27)
      Me.cmdAlta.TabIndex = 114
      Me.cmdAlta.Text = "A&lta"
      Me.cmdAlta.UseVisualStyleBackColor = True
      '
      'cmdDetalle
      '
      Me.cmdDetalle.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdDetalle.Enabled = False
      Me.cmdDetalle.Location = New System.Drawing.Point(329, 508)
      Me.cmdDetalle.Name = "cmdDetalle"
      Me.cmdDetalle.Size = New System.Drawing.Size(75, 27)
      Me.cmdDetalle.TabIndex = 118
      Me.cmdDetalle.Text = "De&talle"
      Me.cmdDetalle.UseVisualStyleBackColor = True
      '
      'chkFecTodas
      '
      Me.chkFecTodas.AutoSize = True
      Me.chkFecTodas.Location = New System.Drawing.Point(290, 42)
      Me.chkFecTodas.Name = "chkFecTodas"
      Me.chkFecTodas.Size = New System.Drawing.Size(56, 17)
      Me.chkFecTodas.TabIndex = 119
      Me.chkFecTodas.Text = "&Todas"
      Me.chkFecTodas.UseVisualStyleBackColor = True
      '
      'cmdImprimir
      '
      Me.cmdImprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdImprimir.Enabled = False
      Me.cmdImprimir.Location = New System.Drawing.Point(410, 508)
      Me.cmdImprimir.Name = "cmdImprimir"
      Me.cmdImprimir.Size = New System.Drawing.Size(75, 27)
      Me.cmdImprimir.TabIndex = 120
      Me.cmdImprimir.Text = "&Imprimir"
      Me.cmdImprimir.UseVisualStyleBackColor = True
      '
      'frmCobrosABM
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(788, 547)
      Me.Controls.Add(Me.cmdImprimir)
      Me.Controls.Add(Me.chkFecTodas)
      Me.Controls.Add(Me.cmdDetalle)
      Me.Controls.Add(Me.cmdSalir)
      Me.Controls.Add(Me.cmdAnular)
      Me.Controls.Add(Me.cmdDevolver)
      Me.Controls.Add(Me.cmdAlta)
      Me.Controls.Add(Me.DataGridView1)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.dtpHasta)
      Me.Controls.Add(Me.Label4)
      Me.Controls.Add(Me.dtpDesde)
      Me.Controls.Add(Me.cbCliente)
      Me.Controls.Add(Me.Label6)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.cbEstado)
      Me.Name = "frmCobrosABM"
      Me.Text = "Cobros"
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents cbCliente As System.Windows.Forms.ComboBox
   Friend WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents cbEstado As System.Windows.Forms.ComboBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents dtpHasta As System.Windows.Forms.DateTimePicker
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents dtpDesde As System.Windows.Forms.DateTimePicker
   Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
   Friend WithEvents cmdSalir As System.Windows.Forms.Button
   Friend WithEvents cmdAnular As System.Windows.Forms.Button
   Friend WithEvents cmdDevolver As System.Windows.Forms.Button
   Friend WithEvents cmdAlta As System.Windows.Forms.Button
   Friend WithEvents cmdDetalle As System.Windows.Forms.Button
   Friend WithEvents chkFecTodas As System.Windows.Forms.CheckBox
   Friend WithEvents cmdImprimir As System.Windows.Forms.Button
End Class
