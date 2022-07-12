<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProveedores
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
      Me.cbLocalidad = New System.Windows.Forms.ComboBox()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.tbBuscar = New System.Windows.Forms.TextBox()
      Me.lblDNI = New System.Windows.Forms.Label()
      Me.cmdSalir = New System.Windows.Forms.Button()
      Me.cmdBaja = New System.Windows.Forms.Button()
      Me.cmdEditar = New System.Windows.Forms.Button()
      Me.cmdAlta = New System.Windows.Forms.Button()
      Me.DataGridView1 = New System.Windows.Forms.DataGridView()
      Me.cbTipoIva = New System.Windows.Forms.ComboBox()
      Me.Label5 = New System.Windows.Forms.Label()
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'cbLocalidad
      '
      Me.cbLocalidad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      Me.cbLocalidad.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.cbLocalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbLocalidad.FormattingEnabled = True
      Me.cbLocalidad.Location = New System.Drawing.Point(75, 11)
      Me.cbLocalidad.Name = "cbLocalidad"
      Me.cbLocalidad.Size = New System.Drawing.Size(420, 21)
      Me.cbLocalidad.TabIndex = 93
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(9, 15)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(56, 13)
      Me.Label4.TabIndex = 94
      Me.Label4.Text = "Localidad:"
      '
      'tbBuscar
      '
      Me.tbBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.tbBuscar.Location = New System.Drawing.Point(561, 12)
      Me.tbBuscar.MaxLength = 50
      Me.tbBuscar.Name = "tbBuscar"
      Me.tbBuscar.Size = New System.Drawing.Size(176, 20)
      Me.tbBuscar.TabIndex = 117
      '
      'lblDNI
      '
      Me.lblDNI.AutoSize = True
      Me.lblDNI.Location = New System.Drawing.Point(512, 15)
      Me.lblDNI.Name = "lblDNI"
      Me.lblDNI.Size = New System.Drawing.Size(43, 13)
      Me.lblDNI.TabIndex = 116
      Me.lblDNI.Text = "Buscar:"
      '
      'cmdSalir
      '
      Me.cmdSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdSalir.Location = New System.Drawing.Point(661, 460)
      Me.cmdSalir.Name = "cmdSalir"
      Me.cmdSalir.Size = New System.Drawing.Size(76, 27)
      Me.cmdSalir.TabIndex = 115
      Me.cmdSalir.Text = "&Salir"
      Me.cmdSalir.UseVisualStyleBackColor = True
      '
      'cmdBaja
      '
      Me.cmdBaja.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdBaja.Enabled = False
      Me.cmdBaja.Location = New System.Drawing.Point(83, 460)
      Me.cmdBaja.Name = "cmdBaja"
      Me.cmdBaja.Size = New System.Drawing.Size(65, 27)
      Me.cmdBaja.TabIndex = 113
      Me.cmdBaja.Text = "&Eliminar"
      Me.cmdBaja.UseVisualStyleBackColor = True
      '
      'cmdEditar
      '
      Me.cmdEditar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdEditar.Enabled = False
      Me.cmdEditar.Location = New System.Drawing.Point(154, 460)
      Me.cmdEditar.Name = "cmdEditar"
      Me.cmdEditar.Size = New System.Drawing.Size(65, 27)
      Me.cmdEditar.TabIndex = 114
      Me.cmdEditar.Text = "&Modificar"
      Me.cmdEditar.UseVisualStyleBackColor = True
      '
      'cmdAlta
      '
      Me.cmdAlta.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdAlta.Location = New System.Drawing.Point(12, 460)
      Me.cmdAlta.Name = "cmdAlta"
      Me.cmdAlta.Size = New System.Drawing.Size(65, 27)
      Me.cmdAlta.TabIndex = 112
      Me.cmdAlta.Text = "A&gregar"
      Me.cmdAlta.UseVisualStyleBackColor = True
      '
      'DataGridView1
      '
      Me.DataGridView1.AllowUserToAddRows = False
      Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
      Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.DataGridView1.Location = New System.Drawing.Point(12, 66)
      Me.DataGridView1.Name = "DataGridView1"
      Me.DataGridView1.ReadOnly = True
      Me.DataGridView1.RowTemplate.ReadOnly = True
      Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.DataGridView1.Size = New System.Drawing.Size(725, 388)
      Me.DataGridView1.TabIndex = 111
      '
      'cbTipoIva
      '
      Me.cbTipoIva.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbTipoIva.FormattingEnabled = True
      Me.cbTipoIva.Location = New System.Drawing.Point(75, 39)
      Me.cbTipoIva.Name = "cbTipoIva"
      Me.cbTipoIva.Size = New System.Drawing.Size(217, 21)
      Me.cbTipoIva.TabIndex = 118
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.Location = New System.Drawing.Point(9, 42)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(60, 13)
      Me.Label5.TabIndex = 119
      Me.Label5.Text = "Tipo I.V.A.:"
      '
      'frmProveedores
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(749, 499)
      Me.Controls.Add(Me.cbTipoIva)
      Me.Controls.Add(Me.Label5)
      Me.Controls.Add(Me.tbBuscar)
      Me.Controls.Add(Me.lblDNI)
      Me.Controls.Add(Me.cmdSalir)
      Me.Controls.Add(Me.cmdBaja)
      Me.Controls.Add(Me.cmdEditar)
      Me.Controls.Add(Me.cmdAlta)
      Me.Controls.Add(Me.DataGridView1)
      Me.Controls.Add(Me.cbLocalidad)
      Me.Controls.Add(Me.Label4)
      Me.KeyPreview = True
      Me.Name = "frmProveedores"
      Me.Text = "Proveedores"
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents cbLocalidad As System.Windows.Forms.ComboBox
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents tbBuscar As System.Windows.Forms.TextBox
   Friend WithEvents lblDNI As System.Windows.Forms.Label
   Friend WithEvents cmdSalir As System.Windows.Forms.Button
   Friend WithEvents cmdBaja As System.Windows.Forms.Button
   Friend WithEvents cmdEditar As System.Windows.Forms.Button
   Friend WithEvents cmdAlta As System.Windows.Forms.Button
   Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
   Friend WithEvents cbTipoIva As System.Windows.Forms.ComboBox
   Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
