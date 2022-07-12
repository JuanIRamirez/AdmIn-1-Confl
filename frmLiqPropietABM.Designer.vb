<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLiqPropietABM
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
      Me.cbPropietario = New System.Windows.Forms.ComboBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.cbEstado = New System.Windows.Forms.ComboBox()
      Me.GroupBox1 = New System.Windows.Forms.GroupBox()
      Me.chkTodas = New System.Windows.Forms.CheckBox()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.dtpHasta = New System.Windows.Forms.DateTimePicker()
      Me.dtpDesde = New System.Windows.Forms.DateTimePicker()
      Me.DataGridView1 = New System.Windows.Forms.DataGridView()
      Me.cmdImprimir = New System.Windows.Forms.Button()
      Me.cmdAnular = New System.Windows.Forms.Button()
      Me.cmdSalir = New System.Windows.Forms.Button()
      Me.cmdAlta = New System.Windows.Forms.Button()
        Me.btnEnviarMail = New System.Windows.Forms.Button()
        Me.dtpPeriodo = New System.Windows.Forms.DateTimePicker()
        Me.chkPeriodo = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cbPropietario
        '
        Me.cbPropietario.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbPropietario.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbPropietario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPropietario.FormattingEnabled = True
        Me.cbPropietario.Location = New System.Drawing.Point(79, 12)
        Me.cbPropietario.Name = "cbPropietario"
        Me.cbPropietario.Size = New System.Drawing.Size(448, 21)
        Me.cbPropietario.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Propietario:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(543, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 40
        Me.Label2.Text = "Estado:"
        '
        'cbEstado
        '
        Me.cbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbEstado.FormattingEnabled = True
        Me.cbEstado.Location = New System.Drawing.Point(592, 12)
        Me.cbEstado.Name = "cbEstado"
        Me.cbEstado.Size = New System.Drawing.Size(100, 21)
        Me.cbEstado.TabIndex = 39
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkTodas)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.dtpHasta)
        Me.GroupBox1.Controls.Add(Me.dtpDesde)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 39)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(515, 52)
        Me.GroupBox1.TabIndex = 46
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Fechas"
        '
        'chkTodas
        '
        Me.chkTodas.AutoSize = True
        Me.chkTodas.Location = New System.Drawing.Point(391, 22)
        Me.chkTodas.Name = "chkTodas"
        Me.chkTodas.Size = New System.Drawing.Size(56, 17)
        Me.chkTodas.TabIndex = 51
        Me.chkTodas.Text = "&Todas"
        Me.chkTodas.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(223, 23)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 50
        Me.Label5.Text = "Hasta:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(66, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 13)
        Me.Label4.TabIndex = 49
        Me.Label4.Text = "Desde:"
        '
        'dtpHasta
        '
        Me.dtpHasta.CustomFormat = "dd/MM/yyyy"
        Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHasta.Location = New System.Drawing.Point(267, 19)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(94, 20)
        Me.dtpHasta.TabIndex = 47
        Me.dtpHasta.Value = New Date(2015, 9, 24, 0, 0, 0, 0)
        '
        'dtpDesde
        '
        Me.dtpDesde.CustomFormat = "dd/MM/yyyy"
        Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDesde.Location = New System.Drawing.Point(113, 19)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(94, 20)
        Me.dtpDesde.TabIndex = 46
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
        Me.DataGridView1.Location = New System.Drawing.Point(12, 97)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowTemplate.ReadOnly = True
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(929, 420)
        Me.DataGridView1.TabIndex = 47
        '
        'cmdImprimir
        '
        Me.cmdImprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdImprimir.Location = New System.Drawing.Point(176, 523)
        Me.cmdImprimir.Name = "cmdImprimir"
        Me.cmdImprimir.Size = New System.Drawing.Size(76, 27)
        Me.cmdImprimir.TabIndex = 62
        Me.cmdImprimir.Text = "&Imprimir"
        Me.cmdImprimir.UseVisualStyleBackColor = True
        '
        'cmdAnular
        '
        Me.cmdAnular.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdAnular.Location = New System.Drawing.Point(94, 523)
        Me.cmdAnular.Name = "cmdAnular"
        Me.cmdAnular.Size = New System.Drawing.Size(76, 27)
        Me.cmdAnular.TabIndex = 63
        Me.cmdAnular.Text = "&Anular"
        Me.cmdAnular.UseVisualStyleBackColor = True
        '
        'cmdSalir
        '
        Me.cmdSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSalir.Location = New System.Drawing.Point(865, 523)
        Me.cmdSalir.Name = "cmdSalir"
        Me.cmdSalir.Size = New System.Drawing.Size(76, 27)
        Me.cmdSalir.TabIndex = 64
        Me.cmdSalir.Text = "&Salir"
        Me.cmdSalir.UseVisualStyleBackColor = True
        '
        'cmdAlta
        '
        Me.cmdAlta.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdAlta.Location = New System.Drawing.Point(12, 523)
        Me.cmdAlta.Name = "cmdAlta"
        Me.cmdAlta.Size = New System.Drawing.Size(76, 27)
        Me.cmdAlta.TabIndex = 65
        Me.cmdAlta.Text = "&Alta"
        Me.cmdAlta.UseVisualStyleBackColor = True
        '
        'btnEnviarMail
        '
        Me.btnEnviarMail.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnEnviarMail.Enabled = False
        Me.btnEnviarMail.Location = New System.Drawing.Point(297, 523)
        Me.btnEnviarMail.Name = "btnEnviarMail"
        Me.btnEnviarMail.Size = New System.Drawing.Size(107, 27)
        Me.btnEnviarMail.TabIndex = 66
        Me.btnEnviarMail.Text = "&Enviar e-Mail"
        Me.btnEnviarMail.UseVisualStyleBackColor = True
        '
        'dtpPeriodo
        '
        Me.dtpPeriodo.CustomFormat = "MM/yyyy"
        Me.dtpPeriodo.Enabled = False
        Me.dtpPeriodo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpPeriodo.Location = New System.Drawing.Point(635, 59)
        Me.dtpPeriodo.Name = "dtpPeriodo"
        Me.dtpPeriodo.Size = New System.Drawing.Size(81, 20)
        Me.dtpPeriodo.TabIndex = 52
        Me.dtpPeriodo.Value = New Date(2015, 9, 24, 0, 0, 0, 0)
        '
        'chkPeriodo
        '
        Me.chkPeriodo.AutoSize = True
        Me.chkPeriodo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkPeriodo.Location = New System.Drawing.Point(563, 61)
        Me.chkPeriodo.Name = "chkPeriodo"
        Me.chkPeriodo.Size = New System.Drawing.Size(64, 17)
        Me.chkPeriodo.TabIndex = 52
        Me.chkPeriodo.Text = "&Período"
        Me.chkPeriodo.UseVisualStyleBackColor = True
        '
        'FrmLiqPropietABM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(948, 553)
        Me.Controls.Add(Me.chkPeriodo)
        Me.Controls.Add(Me.dtpPeriodo)
        Me.Controls.Add(Me.btnEnviarMail)
        Me.Controls.Add(Me.cmdAlta)
        Me.Controls.Add(Me.cmdSalir)
        Me.Controls.Add(Me.cmdAnular)
        Me.Controls.Add(Me.cmdImprimir)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cbEstado)
        Me.Controls.Add(Me.cbPropietario)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FrmLiqPropietABM"
        Me.Text = "Liquidaciones Propietarios"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cbPropietario As System.Windows.Forms.ComboBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents cbEstado As System.Windows.Forms.ComboBox
   Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents chkTodas As System.Windows.Forms.CheckBox
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents dtpHasta As System.Windows.Forms.DateTimePicker
   Friend WithEvents dtpDesde As System.Windows.Forms.DateTimePicker
   Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
   Friend WithEvents cmdImprimir As System.Windows.Forms.Button
   Friend WithEvents cmdAnular As System.Windows.Forms.Button
   Friend WithEvents cmdSalir As System.Windows.Forms.Button
   Friend WithEvents cmdAlta As System.Windows.Forms.Button
    Friend WithEvents btnEnviarMail As Button
    Friend WithEvents dtpPeriodo As DateTimePicker
    Friend WithEvents chkPeriodo As CheckBox
End Class
