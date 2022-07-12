<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBancosMov
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
      Me.Label2 = New System.Windows.Forms.Label()
      Me.cboBanco = New System.Windows.Forms.ComboBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.cbTipoMov = New System.Windows.Forms.ComboBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.cbEstado = New System.Windows.Forms.ComboBox()
      Me.cmdModif = New System.Windows.Forms.Button()
      Me.cmdAlta = New System.Windows.Forms.Button()
      Me.cmdAnular = New System.Windows.Forms.Button()
      Me.DataGridView1 = New System.Windows.Forms.DataGridView()
      Me.GroupBox1 = New System.Windows.Forms.GroupBox()
      Me.chkTodas = New System.Windows.Forms.CheckBox()
      Me.dtpHasta = New System.Windows.Forms.DateTimePicker()
      Me.Label18 = New System.Windows.Forms.Label()
      Me.Label15 = New System.Windows.Forms.Label()
      Me.dtpDesde = New System.Windows.Forms.DateTimePicker()
      Me.btnConciliar = New System.Windows.Forms.Button()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.cbCuentaBco = New System.Windows.Forms.ComboBox()
      Me.cmdSalir = New System.Windows.Forms.Button()
      Me.cmdCancConc = New System.Windows.Forms.Button()
      Me.btnRechazar = New System.Windows.Forms.Button()
      Me.tbNumero = New System.Windows.Forms.TextBox()
      Me.Label6 = New System.Windows.Forms.Label()
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.GroupBox1.SuspendLayout()
      Me.SuspendLayout()
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(11, 15)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(41, 13)
      Me.Label2.TabIndex = 97
      Me.Label2.Text = "Banco:"
      '
      'cboBanco
      '
      Me.cboBanco.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      Me.cboBanco.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.cboBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboBanco.FormattingEnabled = True
      Me.cboBanco.Location = New System.Drawing.Point(58, 12)
      Me.cboBanco.Name = "cboBanco"
      Me.cboBanco.Size = New System.Drawing.Size(441, 21)
      Me.cboBanco.TabIndex = 96
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(385, 62)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(58, 13)
      Me.Label1.TabIndex = 99
      Me.Label1.Text = "Tipo Mov.:"
      '
      'cbTipoMov
      '
      Me.cbTipoMov.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      Me.cbTipoMov.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.cbTipoMov.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbTipoMov.FormattingEnabled = True
      Me.cbTipoMov.Location = New System.Drawing.Point(449, 59)
      Me.cbTipoMov.Name = "cbTipoMov"
      Me.cbTipoMov.Size = New System.Drawing.Size(134, 21)
      Me.cbTipoMov.TabIndex = 98
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(589, 63)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(43, 13)
      Me.Label3.TabIndex = 106
      Me.Label3.Text = "Estado:"
      '
      'cbEstado
      '
      Me.cbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbEstado.FormattingEnabled = True
      Me.cbEstado.Location = New System.Drawing.Point(638, 59)
      Me.cbEstado.Name = "cbEstado"
      Me.cbEstado.Size = New System.Drawing.Size(102, 21)
      Me.cbEstado.TabIndex = 105
      '
      'cmdModif
      '
      Me.cmdModif.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdModif.Location = New System.Drawing.Point(177, 512)
      Me.cmdModif.Name = "cmdModif"
      Me.cmdModif.Size = New System.Drawing.Size(76, 27)
      Me.cmdModif.TabIndex = 110
      Me.cmdModif.Text = "&Modificar"
      Me.cmdModif.UseVisualStyleBackColor = True
      '
      'cmdAlta
      '
      Me.cmdAlta.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdAlta.Location = New System.Drawing.Point(13, 512)
      Me.cmdAlta.Name = "cmdAlta"
      Me.cmdAlta.Size = New System.Drawing.Size(76, 27)
      Me.cmdAlta.TabIndex = 108
      Me.cmdAlta.Text = "&Alta"
      Me.cmdAlta.UseVisualStyleBackColor = True
      '
      'cmdAnular
      '
      Me.cmdAnular.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdAnular.Location = New System.Drawing.Point(95, 512)
      Me.cmdAnular.Name = "cmdAnular"
      Me.cmdAnular.Size = New System.Drawing.Size(76, 27)
      Me.cmdAnular.TabIndex = 109
      Me.cmdAnular.Text = "A&nular"
      Me.cmdAnular.UseVisualStyleBackColor = True
      '
      'DataGridView1
      '
      Me.DataGridView1.AllowUserToAddRows = False
      Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
      Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.DataGridView1.Location = New System.Drawing.Point(12, 94)
      Me.DataGridView1.Name = "DataGridView1"
      Me.DataGridView1.ReadOnly = True
      Me.DataGridView1.RowTemplate.ReadOnly = True
      Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.DataGridView1.Size = New System.Drawing.Size(851, 412)
      Me.DataGridView1.TabIndex = 107
      '
      'GroupBox1
      '
      Me.GroupBox1.Controls.Add(Me.chkTodas)
      Me.GroupBox1.Controls.Add(Me.dtpHasta)
      Me.GroupBox1.Controls.Add(Me.Label18)
      Me.GroupBox1.Controls.Add(Me.Label15)
      Me.GroupBox1.Controls.Add(Me.dtpDesde)
      Me.GroupBox1.Location = New System.Drawing.Point(14, 39)
      Me.GroupBox1.Name = "GroupBox1"
      Me.GroupBox1.Size = New System.Drawing.Size(365, 49)
      Me.GroupBox1.TabIndex = 111
      Me.GroupBox1.TabStop = False
      Me.GroupBox1.Text = "Fechas"
      '
      'chkTodas
      '
      Me.chkTodas.AutoSize = True
      Me.chkTodas.Location = New System.Drawing.Point(298, 20)
      Me.chkTodas.Name = "chkTodas"
      Me.chkTodas.Size = New System.Drawing.Size(56, 17)
      Me.chkTodas.TabIndex = 5
      Me.chkTodas.Text = "&Todas"
      Me.chkTodas.UseVisualStyleBackColor = True
      '
      'dtpHasta
      '
      Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpHasta.Location = New System.Drawing.Point(204, 18)
      Me.dtpHasta.Name = "dtpHasta"
      Me.dtpHasta.Size = New System.Drawing.Size(88, 20)
      Me.dtpHasta.TabIndex = 4
      '
      'Label18
      '
      Me.Label18.AutoSize = True
      Me.Label18.Location = New System.Drawing.Point(160, 22)
      Me.Label18.Name = "Label18"
      Me.Label18.Size = New System.Drawing.Size(38, 13)
      Me.Label18.TabIndex = 100
      Me.Label18.Text = "Hasta:"
      '
      'Label15
      '
      Me.Label15.AutoSize = True
      Me.Label15.Location = New System.Drawing.Point(17, 23)
      Me.Label15.Name = "Label15"
      Me.Label15.Size = New System.Drawing.Size(41, 13)
      Me.Label15.TabIndex = 98
      Me.Label15.Text = "Desde:"
      '
      'dtpDesde
      '
      Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDesde.Location = New System.Drawing.Point(64, 18)
      Me.dtpDesde.Name = "dtpDesde"
      Me.dtpDesde.Size = New System.Drawing.Size(88, 20)
      Me.dtpDesde.TabIndex = 3
      '
      'btnConciliar
      '
      Me.btnConciliar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btnConciliar.Location = New System.Drawing.Point(303, 512)
      Me.btnConciliar.Name = "btnConciliar"
      Me.btnConciliar.Size = New System.Drawing.Size(76, 27)
      Me.btnConciliar.TabIndex = 112
      Me.btnConciliar.Text = "&Conciliar"
      Me.btnConciliar.UseVisualStyleBackColor = True
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(527, 15)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(44, 13)
      Me.Label4.TabIndex = 114
      Me.Label4.Text = "Cuenta:"
      '
      'cbCuentaBco
      '
      Me.cbCuentaBco.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      Me.cbCuentaBco.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.cbCuentaBco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbCuentaBco.FormattingEnabled = True
      Me.cbCuentaBco.Location = New System.Drawing.Point(577, 12)
      Me.cbCuentaBco.Name = "cbCuentaBco"
      Me.cbCuentaBco.Size = New System.Drawing.Size(286, 21)
      Me.cbCuentaBco.TabIndex = 113
      '
      'cmdSalir
      '
      Me.cmdSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdSalir.Location = New System.Drawing.Point(787, 512)
      Me.cmdSalir.Name = "cmdSalir"
      Me.cmdSalir.Size = New System.Drawing.Size(76, 27)
      Me.cmdSalir.TabIndex = 115
      Me.cmdSalir.Text = "&Salir"
      Me.cmdSalir.UseVisualStyleBackColor = True
      '
      'cmdCancConc
      '
      Me.cmdCancConc.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdCancConc.Location = New System.Drawing.Point(385, 512)
      Me.cmdCancConc.Name = "cmdCancConc"
      Me.cmdCancConc.Size = New System.Drawing.Size(114, 27)
      Me.cmdCancConc.TabIndex = 116
      Me.cmdCancConc.Text = "Ca&ncelar Conc."
      Me.cmdCancConc.UseVisualStyleBackColor = True
      '
      'btnRechazar
      '
      Me.btnRechazar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btnRechazar.Location = New System.Drawing.Point(505, 512)
      Me.btnRechazar.Name = "btnRechazar"
      Me.btnRechazar.Size = New System.Drawing.Size(76, 27)
      Me.btnRechazar.TabIndex = 117
      Me.btnRechazar.Text = "&Rechazar"
      Me.btnRechazar.UseVisualStyleBackColor = True
      '
      'tbNumero
      '
      Me.tbNumero.Location = New System.Drawing.Point(787, 60)
      Me.tbNumero.Name = "tbNumero"
      Me.tbNumero.Size = New System.Drawing.Size(76, 20)
      Me.tbNumero.TabIndex = 124
      '
      'Label6
      '
      Me.Label6.AutoSize = True
      Me.Label6.Location = New System.Drawing.Point(754, 62)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(27, 13)
      Me.Label6.TabIndex = 123
      Me.Label6.Text = "Nro."
      '
      'frmBancosMov
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(875, 551)
      Me.Controls.Add(Me.tbNumero)
      Me.Controls.Add(Me.Label6)
      Me.Controls.Add(Me.btnRechazar)
      Me.Controls.Add(Me.cmdCancConc)
      Me.Controls.Add(Me.cmdSalir)
      Me.Controls.Add(Me.Label4)
      Me.Controls.Add(Me.cbCuentaBco)
      Me.Controls.Add(Me.btnConciliar)
      Me.Controls.Add(Me.GroupBox1)
      Me.Controls.Add(Me.cmdModif)
      Me.Controls.Add(Me.cmdAlta)
      Me.Controls.Add(Me.cmdAnular)
      Me.Controls.Add(Me.DataGridView1)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.cbEstado)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.cbTipoMov)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.cboBanco)
      Me.KeyPreview = True
      Me.Name = "frmBancosMov"
      Me.Text = "Bancos, Movimientos"
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.GroupBox1.ResumeLayout(False)
      Me.GroupBox1.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents cboBanco As System.Windows.Forms.ComboBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents cbTipoMov As System.Windows.Forms.ComboBox
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents cbEstado As System.Windows.Forms.ComboBox
   Friend WithEvents cmdModif As System.Windows.Forms.Button
   Friend WithEvents cmdAlta As System.Windows.Forms.Button
   Friend WithEvents cmdAnular As System.Windows.Forms.Button
   Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
   Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents chkTodas As System.Windows.Forms.CheckBox
   Friend WithEvents dtpHasta As System.Windows.Forms.DateTimePicker
   Friend WithEvents Label18 As System.Windows.Forms.Label
   Friend WithEvents Label15 As System.Windows.Forms.Label
   Friend WithEvents dtpDesde As System.Windows.Forms.DateTimePicker
   Friend WithEvents btnConciliar As System.Windows.Forms.Button
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents cbCuentaBco As System.Windows.Forms.ComboBox
   Friend WithEvents cmdSalir As System.Windows.Forms.Button
   Friend WithEvents cmdCancConc As System.Windows.Forms.Button
   Friend WithEvents btnRechazar As System.Windows.Forms.Button
   Friend WithEvents tbNumero As System.Windows.Forms.TextBox
   Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
