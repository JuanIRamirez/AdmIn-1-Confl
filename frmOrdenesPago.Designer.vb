<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmOrdenesPago
   Inherits System.Windows.Forms.Form

   'Form overrides dispose to clean up the component list.
   <System.Diagnostics.DebuggerNonUserCode()>
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
   <System.Diagnostics.DebuggerStepThrough()>
   Private Sub InitializeComponent()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.dtpFecDesde = New System.Windows.Forms.DateTimePicker()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.dtpFecHasta = New System.Windows.Forms.DateTimePicker()
      Me.cbProveedor = New System.Windows.Forms.ComboBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.cbEstado = New System.Windows.Forms.ComboBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.DataGridView1 = New System.Windows.Forms.DataGridView()
      Me.cmdCancelar = New System.Windows.Forms.Button()
      Me.cmdAlta = New System.Windows.Forms.Button()
      Me.cmdAnular = New System.Windows.Forms.Button()
      Me.cmdModificar = New System.Windows.Forms.Button()
      Me.tbNumero = New System.Windows.Forms.TextBox()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.chkTodas = New System.Windows.Forms.CheckBox()
      Me.cmdAutorizar = New System.Windows.Forms.Button()
      Me.cmdConfirmar = New System.Windows.Forms.Button()
      Me.cmdPagar = New System.Windows.Forms.Button()
      Me.cmdRendir = New System.Windows.Forms.Button()
      Me.btnImprimir = New System.Windows.Forms.Button()
      Me.btnAgrupar = New System.Windows.Forms.Button()
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(23, 41)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(41, 13)
      Me.Label4.TabIndex = 103
      Me.Label4.Text = "Desde:"
      '
      'dtpFecDesde
      '
      Me.dtpFecDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpFecDesde.Location = New System.Drawing.Point(70, 38)
      Me.dtpFecDesde.Name = "dtpFecDesde"
      Me.dtpFecDesde.Size = New System.Drawing.Size(81, 20)
      Me.dtpFecDesde.TabIndex = 102
      Me.dtpFecDesde.Value = New Date(2015, 9, 24, 0, 0, 0, 0)
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(165, 41)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(38, 13)
      Me.Label1.TabIndex = 105
      Me.Label1.Text = "Hasta:"
      '
      'dtpFecHasta
      '
      Me.dtpFecHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpFecHasta.Location = New System.Drawing.Point(209, 38)
      Me.dtpFecHasta.Name = "dtpFecHasta"
      Me.dtpFecHasta.Size = New System.Drawing.Size(81, 20)
      Me.dtpFecHasta.TabIndex = 104
      Me.dtpFecHasta.Value = New Date(2015, 9, 24, 0, 0, 0, 0)
      '
      'cbProveedor
      '
      Me.cbProveedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      Me.cbProveedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.cbProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbProveedor.FormattingEnabled = True
      Me.cbProveedor.Location = New System.Drawing.Point(70, 11)
      Me.cbProveedor.Name = "cbProveedor"
      Me.cbProveedor.Size = New System.Drawing.Size(426, 21)
      Me.cbProveedor.TabIndex = 106
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(5, 14)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(59, 13)
      Me.Label2.TabIndex = 107
      Me.Label2.Text = "Proveedor:"
      '
      'cbEstado
      '
      Me.cbEstado.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      Me.cbEstado.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.cbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbEstado.FormattingEnabled = True
      Me.cbEstado.Location = New System.Drawing.Point(564, 11)
      Me.cbEstado.Name = "cbEstado"
      Me.cbEstado.Size = New System.Drawing.Size(136, 21)
      Me.cbEstado.TabIndex = 108
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(515, 14)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(43, 13)
      Me.Label3.TabIndex = 109
      Me.Label3.Text = "Estado:"
      '
      'DataGridView1
      '
      Me.DataGridView1.AllowUserToAddRows = False
      Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
      Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.DataGridView1.Location = New System.Drawing.Point(8, 64)
      Me.DataGridView1.Name = "DataGridView1"
      Me.DataGridView1.ReadOnly = True
      Me.DataGridView1.RowTemplate.ReadOnly = True
      Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.DataGridView1.Size = New System.Drawing.Size(811, 375)
      Me.DataGridView1.TabIndex = 110
      '
      'cmdCancelar
      '
      Me.cmdCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdCancelar.Location = New System.Drawing.Point(755, 445)
      Me.cmdCancelar.Name = "cmdCancelar"
      Me.cmdCancelar.Size = New System.Drawing.Size(64, 27)
      Me.cmdCancelar.TabIndex = 123
      Me.cmdCancelar.Text = "&Cerrar"
      Me.cmdCancelar.UseVisualStyleBackColor = True
      '
      'cmdAlta
      '
      Me.cmdAlta.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdAlta.Location = New System.Drawing.Point(8, 445)
      Me.cmdAlta.Name = "cmdAlta"
      Me.cmdAlta.Size = New System.Drawing.Size(56, 27)
      Me.cmdAlta.TabIndex = 122
      Me.cmdAlta.Text = "&Alta"
      Me.cmdAlta.UseVisualStyleBackColor = True
      '
      'cmdAnular
      '
      Me.cmdAnular.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdAnular.Enabled = False
      Me.cmdAnular.Location = New System.Drawing.Point(70, 445)
      Me.cmdAnular.Name = "cmdAnular"
      Me.cmdAnular.Size = New System.Drawing.Size(51, 27)
      Me.cmdAnular.TabIndex = 124
      Me.cmdAnular.Text = "A&nular"
      Me.cmdAnular.UseVisualStyleBackColor = True
      '
      'cmdModificar
      '
      Me.cmdModificar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdModificar.Enabled = False
      Me.cmdModificar.Location = New System.Drawing.Point(127, 445)
      Me.cmdModificar.Name = "cmdModificar"
      Me.cmdModificar.Size = New System.Drawing.Size(65, 27)
      Me.cmdModificar.TabIndex = 125
      Me.cmdModificar.Text = "&Modificar"
      Me.cmdModificar.UseVisualStyleBackColor = True
      '
      'tbNumero
      '
      Me.tbNumero.Location = New System.Drawing.Point(617, 38)
      Me.tbNumero.MaxLength = 10
      Me.tbNumero.Name = "tbNumero"
      Me.tbNumero.Size = New System.Drawing.Size(83, 20)
      Me.tbNumero.TabIndex = 127
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.Location = New System.Drawing.Point(592, 41)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(19, 13)
      Me.Label5.TabIndex = 126
      Me.Label5.Text = "Nº"
      '
      'chkTodas
      '
      Me.chkTodas.AutoSize = True
      Me.chkTodas.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.chkTodas.Location = New System.Drawing.Point(309, 41)
      Me.chkTodas.Name = "chkTodas"
      Me.chkTodas.Size = New System.Drawing.Size(56, 17)
      Me.chkTodas.TabIndex = 128
      Me.chkTodas.Text = "&Todas"
      Me.chkTodas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      Me.chkTodas.UseVisualStyleBackColor = True
      '
      'cmdAutorizar
      '
      Me.cmdAutorizar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdAutorizar.Enabled = False
      Me.cmdAutorizar.Location = New System.Drawing.Point(209, 445)
      Me.cmdAutorizar.Name = "cmdAutorizar"
      Me.cmdAutorizar.Size = New System.Drawing.Size(81, 27)
      Me.cmdAutorizar.TabIndex = 129
      Me.cmdAutorizar.Text = "Au&torizar"
      Me.cmdAutorizar.UseVisualStyleBackColor = True
      '
      'cmdConfirmar
      '
      Me.cmdConfirmar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdConfirmar.Enabled = False
      Me.cmdConfirmar.Location = New System.Drawing.Point(296, 445)
      Me.cmdConfirmar.Name = "cmdConfirmar"
      Me.cmdConfirmar.Size = New System.Drawing.Size(79, 27)
      Me.cmdConfirmar.TabIndex = 130
      Me.cmdConfirmar.Text = "Con&firmar"
      Me.cmdConfirmar.UseVisualStyleBackColor = True
      '
      'cmdPagar
      '
      Me.cmdPagar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdPagar.Enabled = False
      Me.cmdPagar.Location = New System.Drawing.Point(381, 445)
      Me.cmdPagar.Name = "cmdPagar"
      Me.cmdPagar.Size = New System.Drawing.Size(76, 27)
      Me.cmdPagar.TabIndex = 131
      Me.cmdPagar.Text = "&Pagar"
      Me.cmdPagar.UseVisualStyleBackColor = True
      '
      'cmdRendir
      '
      Me.cmdRendir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdRendir.Enabled = False
      Me.cmdRendir.Location = New System.Drawing.Point(463, 445)
      Me.cmdRendir.Name = "cmdRendir"
      Me.cmdRendir.Size = New System.Drawing.Size(65, 27)
      Me.cmdRendir.TabIndex = 132
      Me.cmdRendir.Text = "&Rendir"
      Me.cmdRendir.UseVisualStyleBackColor = True
      '
      'btnImprimir
      '
      Me.btnImprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btnImprimir.Enabled = False
      Me.btnImprimir.Location = New System.Drawing.Point(635, 445)
      Me.btnImprimir.Name = "btnImprimir"
      Me.btnImprimir.Size = New System.Drawing.Size(65, 27)
      Me.btnImprimir.TabIndex = 133
      Me.btnImprimir.Text = "&Imprimir"
      Me.btnImprimir.UseVisualStyleBackColor = True
      '
      'btnAgrupar
      '
      Me.btnAgrupar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btnAgrupar.Enabled = False
      Me.btnAgrupar.Location = New System.Drawing.Point(534, 445)
      Me.btnAgrupar.Name = "btnAgrupar"
      Me.btnAgrupar.Size = New System.Drawing.Size(65, 27)
      Me.btnAgrupar.TabIndex = 134
      Me.btnAgrupar.Text = "A&grupar"
      Me.btnAgrupar.UseVisualStyleBackColor = True
      '
      'frmOrdenesPago
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(829, 484)
      Me.Controls.Add(Me.btnAgrupar)
      Me.Controls.Add(Me.btnImprimir)
      Me.Controls.Add(Me.cmdRendir)
      Me.Controls.Add(Me.cmdPagar)
      Me.Controls.Add(Me.cmdConfirmar)
      Me.Controls.Add(Me.cmdAutorizar)
      Me.Controls.Add(Me.chkTodas)
      Me.Controls.Add(Me.tbNumero)
      Me.Controls.Add(Me.Label5)
      Me.Controls.Add(Me.cmdModificar)
      Me.Controls.Add(Me.cmdAnular)
      Me.Controls.Add(Me.cmdCancelar)
      Me.Controls.Add(Me.cmdAlta)
      Me.Controls.Add(Me.DataGridView1)
      Me.Controls.Add(Me.cbEstado)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.cbProveedor)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.dtpFecHasta)
      Me.Controls.Add(Me.Label4)
      Me.Controls.Add(Me.dtpFecDesde)
      Me.Name = "frmOrdenesPago"
      Me.Text = "Ordenes de Pago"
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents dtpFecDesde As System.Windows.Forms.DateTimePicker
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents dtpFecHasta As System.Windows.Forms.DateTimePicker
   Friend WithEvents cbProveedor As System.Windows.Forms.ComboBox
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents cbEstado As System.Windows.Forms.ComboBox
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
   Friend WithEvents cmdCancelar As System.Windows.Forms.Button
   Friend WithEvents cmdAlta As System.Windows.Forms.Button
   Friend WithEvents cmdAnular As System.Windows.Forms.Button
   Friend WithEvents cmdModificar As System.Windows.Forms.Button
   Friend WithEvents tbNumero As System.Windows.Forms.TextBox
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents chkTodas As System.Windows.Forms.CheckBox
   Friend WithEvents cmdAutorizar As System.Windows.Forms.Button
   Friend WithEvents cmdConfirmar As System.Windows.Forms.Button
   Friend WithEvents cmdPagar As System.Windows.Forms.Button
   Friend WithEvents cmdRendir As System.Windows.Forms.Button
   Friend WithEvents btnImprimir As System.Windows.Forms.Button
   Friend WithEvents btnAgrupar As System.Windows.Forms.Button
End Class
