<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmComprasOtr
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
      Me.chkTodas = New System.Windows.Forms.CheckBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.dtpFecHasta = New System.Windows.Forms.DateTimePicker()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.dtpFecDesde = New System.Windows.Forms.DateTimePicker()
      Me.cbPropietario = New System.Windows.Forms.ComboBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.DataGridView1 = New System.Windows.Forms.DataGridView()
      Me.cbComprob = New System.Windows.Forms.ComboBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.cbProveedor = New System.Windows.Forms.ComboBox()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.chkPagados = New System.Windows.Forms.CheckBox()
      Me.cmdEdicion = New System.Windows.Forms.Button()
      Me.cmdAlta = New System.Windows.Forms.Button()
      Me.cmdBaja = New System.Windows.Forms.Button()
      Me.btnCerrar = New System.Windows.Forms.Button()
      Me.btnAnulaPago = New System.Windows.Forms.Button()
      Me.btnPagar = New System.Windows.Forms.Button()
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'chkTodas
      '
      Me.chkTodas.AutoSize = True
      Me.chkTodas.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.chkTodas.Location = New System.Drawing.Point(277, 40)
      Me.chkTodas.Name = "chkTodas"
      Me.chkTodas.Size = New System.Drawing.Size(56, 17)
      Me.chkTodas.TabIndex = 133
      Me.chkTodas.Text = "&Todas"
      Me.chkTodas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      Me.chkTodas.UseVisualStyleBackColor = True
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(146, 41)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(38, 13)
      Me.Label1.TabIndex = 132
      Me.Label1.Text = "Hasta:"
      '
      'dtpFecHasta
      '
      Me.dtpFecHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpFecHasta.Location = New System.Drawing.Point(190, 38)
      Me.dtpFecHasta.Name = "dtpFecHasta"
      Me.dtpFecHasta.Size = New System.Drawing.Size(81, 20)
      Me.dtpFecHasta.TabIndex = 131
      Me.dtpFecHasta.Value = New Date(2015, 9, 24, 0, 0, 0, 0)
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(12, 41)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(41, 13)
      Me.Label4.TabIndex = 130
      Me.Label4.Text = "Desde:"
      '
      'dtpFecDesde
      '
      Me.dtpFecDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpFecDesde.Location = New System.Drawing.Point(59, 38)
      Me.dtpFecDesde.Name = "dtpFecDesde"
      Me.dtpFecDesde.Size = New System.Drawing.Size(81, 20)
      Me.dtpFecDesde.TabIndex = 129
      Me.dtpFecDesde.Value = New Date(2015, 9, 24, 0, 0, 0, 0)
      '
      'cbPropietario
      '
      Me.cbPropietario.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      Me.cbPropietario.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.cbPropietario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbPropietario.FormattingEnabled = True
      Me.cbPropietario.Location = New System.Drawing.Point(417, 38)
      Me.cbPropietario.Name = "cbPropietario"
      Me.cbPropietario.Size = New System.Drawing.Size(382, 21)
      Me.cbPropietario.TabIndex = 134
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(351, 41)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(60, 13)
      Me.Label2.TabIndex = 135
      Me.Label2.Text = "Propietario:"
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
      Me.DataGridView1.Size = New System.Drawing.Size(787, 403)
      Me.DataGridView1.TabIndex = 136
      '
      'cbComprob
      '
      Me.cbComprob.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      Me.cbComprob.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.cbComprob.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbComprob.FormattingEnabled = True
      Me.cbComprob.Location = New System.Drawing.Point(538, 11)
      Me.cbComprob.Name = "cbComprob"
      Me.cbComprob.Size = New System.Drawing.Size(181, 21)
      Me.cbComprob.TabIndex = 137
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(459, 14)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(73, 13)
      Me.Label3.TabIndex = 138
      Me.Label3.Text = "Comprobante:"
      '
      'cbProveedor
      '
      Me.cbProveedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      Me.cbProveedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.cbProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbProveedor.FormattingEnabled = True
      Me.cbProveedor.Location = New System.Drawing.Point(74, 11)
      Me.cbProveedor.Name = "cbProveedor"
      Me.cbProveedor.Size = New System.Drawing.Size(379, 21)
      Me.cbProveedor.TabIndex = 139
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.Location = New System.Drawing.Point(9, 14)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(59, 13)
      Me.Label5.TabIndex = 140
      Me.Label5.Text = "Proveedor:"
      '
      'chkPagados
      '
      Me.chkPagados.AutoSize = True
      Me.chkPagados.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.chkPagados.Location = New System.Drawing.Point(731, 12)
      Me.chkPagados.Name = "chkPagados"
      Me.chkPagados.Size = New System.Drawing.Size(68, 17)
      Me.chkPagados.TabIndex = 141
      Me.chkPagados.Text = "&Pagados"
      Me.chkPagados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      Me.chkPagados.UseVisualStyleBackColor = True
      '
      'cmdEdicion
      '
      Me.cmdEdicion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdEdicion.Location = New System.Drawing.Point(176, 474)
      Me.cmdEdicion.Name = "cmdEdicion"
      Me.cmdEdicion.Size = New System.Drawing.Size(76, 25)
      Me.cmdEdicion.TabIndex = 144
      Me.cmdEdicion.Text = "&Modificar"
      Me.cmdEdicion.UseVisualStyleBackColor = True
      '
      'cmdAlta
      '
      Me.cmdAlta.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdAlta.Location = New System.Drawing.Point(12, 475)
      Me.cmdAlta.Name = "cmdAlta"
      Me.cmdAlta.Size = New System.Drawing.Size(76, 25)
      Me.cmdAlta.TabIndex = 142
      Me.cmdAlta.Text = "&Alta"
      Me.cmdAlta.UseVisualStyleBackColor = True
      '
      'cmdBaja
      '
      Me.cmdBaja.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdBaja.Location = New System.Drawing.Point(94, 474)
      Me.cmdBaja.Name = "cmdBaja"
      Me.cmdBaja.Size = New System.Drawing.Size(76, 25)
      Me.cmdBaja.TabIndex = 143
      Me.cmdBaja.Text = "&Baja"
      Me.cmdBaja.UseVisualStyleBackColor = True
      '
      'btnCerrar
      '
      Me.btnCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnCerrar.Location = New System.Drawing.Point(723, 475)
      Me.btnCerrar.Name = "btnCerrar"
      Me.btnCerrar.Size = New System.Drawing.Size(76, 25)
      Me.btnCerrar.TabIndex = 145
      Me.btnCerrar.Text = "&Cerrar"
      Me.btnCerrar.UseVisualStyleBackColor = True
      '
      'btnAnulaPago
      '
      Me.btnAnulaPago.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btnAnulaPago.Location = New System.Drawing.Point(385, 474)
      Me.btnAnulaPago.Name = "btnAnulaPago"
      Me.btnAnulaPago.Size = New System.Drawing.Size(86, 25)
      Me.btnAnulaPago.TabIndex = 146
      Me.btnAnulaPago.Text = "A&nular Pago"
      Me.btnAnulaPago.UseVisualStyleBackColor = True
      '
      'btnPagar
      '
      Me.btnPagar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btnPagar.Location = New System.Drawing.Point(293, 474)
      Me.btnPagar.Name = "btnPagar"
      Me.btnPagar.Size = New System.Drawing.Size(86, 25)
      Me.btnPagar.TabIndex = 147
      Me.btnPagar.Text = "&Pagar"
      Me.btnPagar.UseVisualStyleBackColor = True
      '
      'frmComprasOtr
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(811, 512)
      Me.Controls.Add(Me.btnPagar)
      Me.Controls.Add(Me.btnAnulaPago)
      Me.Controls.Add(Me.btnCerrar)
      Me.Controls.Add(Me.cmdEdicion)
      Me.Controls.Add(Me.cmdAlta)
      Me.Controls.Add(Me.cmdBaja)
      Me.Controls.Add(Me.chkPagados)
      Me.Controls.Add(Me.cbProveedor)
      Me.Controls.Add(Me.Label5)
      Me.Controls.Add(Me.cbComprob)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.DataGridView1)
      Me.Controls.Add(Me.cbPropietario)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.chkTodas)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.dtpFecHasta)
      Me.Controls.Add(Me.Label4)
      Me.Controls.Add(Me.dtpFecDesde)
      Me.Name = "frmComprasOtr"
      Me.Text = "Otros Comprobantes"
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents chkTodas As System.Windows.Forms.CheckBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents dtpFecHasta As System.Windows.Forms.DateTimePicker
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents dtpFecDesde As System.Windows.Forms.DateTimePicker
   Friend WithEvents cbPropietario As System.Windows.Forms.ComboBox
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
   Friend WithEvents cbComprob As System.Windows.Forms.ComboBox
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents cbProveedor As System.Windows.Forms.ComboBox
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents chkPagados As System.Windows.Forms.CheckBox
   Friend WithEvents cmdEdicion As System.Windows.Forms.Button
   Friend WithEvents cmdAlta As System.Windows.Forms.Button
   Friend WithEvents cmdBaja As System.Windows.Forms.Button
   Friend WithEvents btnCerrar As System.Windows.Forms.Button
   Friend WithEvents btnAnulaPago As System.Windows.Forms.Button
   Friend WithEvents btnPagar As System.Windows.Forms.Button
End Class
