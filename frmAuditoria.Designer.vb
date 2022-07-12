<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAuditoria
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
      Me.cbProceso = New System.Windows.Forms.ComboBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.cbUsuario = New System.Windows.Forms.ComboBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.dtpDesde = New System.Windows.Forms.DateTimePicker()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.dtpHasta = New System.Windows.Forms.DateTimePicker()
      Me.chkTodas = New System.Windows.Forms.CheckBox()
      Me.btCerrar = New System.Windows.Forms.Button()
      Me.tbBuscar = New System.Windows.Forms.TextBox()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.DataGridView1 = New System.Windows.Forms.DataGridView()
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'cbProceso
      '
      Me.cbProceso.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      Me.cbProceso.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.cbProceso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbProceso.FormattingEnabled = True
      Me.cbProceso.Location = New System.Drawing.Point(68, 12)
      Me.cbProceso.Name = "cbProceso"
      Me.cbProceso.Size = New System.Drawing.Size(273, 21)
      Me.cbProceso.TabIndex = 94
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(13, 15)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(49, 13)
      Me.Label1.TabIndex = 95
      Me.Label1.Text = "Proceso:"
      '
      'cbUsuario
      '
      Me.cbUsuario.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      Me.cbUsuario.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.cbUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbUsuario.FormattingEnabled = True
      Me.cbUsuario.Location = New System.Drawing.Point(409, 12)
      Me.cbUsuario.Name = "cbUsuario"
      Me.cbUsuario.Size = New System.Drawing.Size(172, 21)
      Me.cbUsuario.TabIndex = 96
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(357, 15)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(46, 13)
      Me.Label2.TabIndex = 97
      Me.Label2.Text = "Usuario:"
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(21, 45)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(41, 13)
      Me.Label4.TabIndex = 99
      Me.Label4.Text = "Desde:"
      '
      'dtpDesde
      '
      Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDesde.Location = New System.Drawing.Point(68, 42)
      Me.dtpDesde.Name = "dtpDesde"
      Me.dtpDesde.Size = New System.Drawing.Size(81, 20)
      Me.dtpDesde.TabIndex = 98
      Me.dtpDesde.Value = New Date(2015, 9, 24, 0, 0, 0, 0)
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(200, 45)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(38, 13)
      Me.Label3.TabIndex = 101
      Me.Label3.Text = "Hasta:"
      '
      'dtpHasta
      '
      Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpHasta.Location = New System.Drawing.Point(244, 42)
      Me.dtpHasta.Name = "dtpHasta"
      Me.dtpHasta.Size = New System.Drawing.Size(81, 20)
      Me.dtpHasta.TabIndex = 100
      Me.dtpHasta.Value = New Date(2015, 9, 24, 0, 0, 0, 0)
      '
      'chkTodas
      '
      Me.chkTodas.AutoSize = True
      Me.chkTodas.Location = New System.Drawing.Point(360, 44)
      Me.chkTodas.Name = "chkTodas"
      Me.chkTodas.Size = New System.Drawing.Size(56, 17)
      Me.chkTodas.TabIndex = 102
      Me.chkTodas.Text = "&Todas"
      Me.chkTodas.UseVisualStyleBackColor = True
      '
      'btCerrar
      '
      Me.btCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btCerrar.Location = New System.Drawing.Point(655, 442)
      Me.btCerrar.Name = "btCerrar"
      Me.btCerrar.Size = New System.Drawing.Size(63, 27)
      Me.btCerrar.TabIndex = 104
      Me.btCerrar.Text = "&Cerrar"
      Me.btCerrar.UseVisualStyleBackColor = True
      '
      'tbBuscar
      '
      Me.tbBuscar.Location = New System.Drawing.Point(485, 42)
      Me.tbBuscar.Name = "tbBuscar"
      Me.tbBuscar.Size = New System.Drawing.Size(233, 20)
      Me.tbBuscar.TabIndex = 105
      '
      'Label6
      '
      Me.Label6.AutoSize = True
      Me.Label6.Location = New System.Drawing.Point(435, 45)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(43, 13)
      Me.Label6.TabIndex = 106
      Me.Label6.Text = "Buscar:"
      '
      'DataGridView1
      '
      Me.DataGridView1.AllowUserToAddRows = False
      Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
      Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.DataGridView1.Location = New System.Drawing.Point(12, 67)
      Me.DataGridView1.Name = "DataGridView1"
      Me.DataGridView1.ReadOnly = True
      Me.DataGridView1.RowTemplate.ReadOnly = True
      Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.DataGridView1.Size = New System.Drawing.Size(704, 369)
      Me.DataGridView1.TabIndex = 107
      '
      'frmAuditoria
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(728, 481)
      Me.Controls.Add(Me.DataGridView1)
      Me.Controls.Add(Me.tbBuscar)
      Me.Controls.Add(Me.Label6)
      Me.Controls.Add(Me.btCerrar)
      Me.Controls.Add(Me.chkTodas)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.dtpHasta)
      Me.Controls.Add(Me.Label4)
      Me.Controls.Add(Me.dtpDesde)
      Me.Controls.Add(Me.cbUsuario)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.cbProceso)
      Me.Controls.Add(Me.Label1)
      Me.KeyPreview = True
      Me.Name = "frmAuditoria"
      Me.Text = "Auditoría"
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents cbProceso As System.Windows.Forms.ComboBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents cbUsuario As System.Windows.Forms.ComboBox
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents dtpDesde As System.Windows.Forms.DateTimePicker
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents dtpHasta As System.Windows.Forms.DateTimePicker
   Friend WithEvents chkTodas As System.Windows.Forms.CheckBox
   Friend WithEvents btCerrar As System.Windows.Forms.Button
   Friend WithEvents tbBuscar As System.Windows.Forms.TextBox
   Friend WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
End Class
