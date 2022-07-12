<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPropietAg
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
      Me.DataGridView1 = New System.Windows.Forms.DataGridView()
      Me.cbGrupo = New System.Windows.Forms.ComboBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.DataGridView2 = New System.Windows.Forms.DataGridView()
      Me.btnAgregar = New System.Windows.Forms.Button()
      Me.btnQuitar = New System.Windows.Forms.Button()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.cmdSalir = New System.Windows.Forms.Button()
      Me.tbBuscar = New System.Windows.Forms.TextBox()
      Me.Label3 = New System.Windows.Forms.Label()
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'DataGridView1
      '
      Me.DataGridView1.AllowUserToAddRows = False
      Me.DataGridView1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
      Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.DataGridView1.Location = New System.Drawing.Point(12, 50)
      Me.DataGridView1.Name = "DataGridView1"
      Me.DataGridView1.ReadOnly = True
      Me.DataGridView1.RowTemplate.ReadOnly = True
      Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.DataGridView1.Size = New System.Drawing.Size(433, 467)
      Me.DataGridView1.TabIndex = 2
      '
      'cbGrupo
      '
      Me.cbGrupo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      Me.cbGrupo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.cbGrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbGrupo.FormattingEnabled = True
      Me.cbGrupo.Location = New System.Drawing.Point(467, 17)
      Me.cbGrupo.Name = "cbGrupo"
      Me.cbGrupo.Size = New System.Drawing.Size(393, 21)
      Me.cbGrupo.TabIndex = 138
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(422, 20)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(39, 13)
      Me.Label2.TabIndex = 139
      Me.Label2.Text = "Grupo:"
      '
      'DataGridView2
      '
      Me.DataGridView2.AllowUserToAddRows = False
      Me.DataGridView2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.DataGridView2.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
      Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.DataGridView2.Location = New System.Drawing.Point(453, 50)
      Me.DataGridView2.Name = "DataGridView2"
      Me.DataGridView2.ReadOnly = True
      Me.DataGridView2.RowTemplate.ReadOnly = True
      Me.DataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.DataGridView2.Size = New System.Drawing.Size(407, 467)
      Me.DataGridView2.TabIndex = 140
      '
      'btnAgregar
      '
      Me.btnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btnAgregar.Location = New System.Drawing.Point(365, 523)
      Me.btnAgregar.Name = "btnAgregar"
      Me.btnAgregar.Size = New System.Drawing.Size(80, 27)
      Me.btnAgregar.TabIndex = 141
      Me.btnAgregar.Text = "&Agregar >>"
      Me.btnAgregar.UseVisualStyleBackColor = True
      '
      'btnQuitar
      '
      Me.btnQuitar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btnQuitar.Location = New System.Drawing.Point(453, 523)
      Me.btnQuitar.Name = "btnQuitar"
      Me.btnQuitar.Size = New System.Drawing.Size(80, 27)
      Me.btnQuitar.TabIndex = 142
      Me.btnQuitar.Text = "<< &Quitar"
      Me.btnQuitar.UseVisualStyleBackColor = True
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(12, 20)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(119, 13)
      Me.Label1.TabIndex = 143
      Me.Label1.Text = "Propietarios Disponibles"
      '
      'cmdSalir
      '
      Me.cmdSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.cmdSalir.Location = New System.Drawing.Point(800, 523)
      Me.cmdSalir.Name = "cmdSalir"
      Me.cmdSalir.Size = New System.Drawing.Size(60, 27)
      Me.cmdSalir.TabIndex = 144
      Me.cmdSalir.Text = "&Cerrar"
      Me.cmdSalir.UseVisualStyleBackColor = True
      '
      'tbBuscar
      '
      Me.tbBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.tbBuscar.Location = New System.Drawing.Point(229, 17)
      Me.tbBuscar.MaxLength = 50
      Me.tbBuscar.Name = "tbBuscar"
      Me.tbBuscar.Size = New System.Drawing.Size(187, 20)
      Me.tbBuscar.TabIndex = 145
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(180, 20)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(43, 13)
      Me.Label3.TabIndex = 146
      Me.Label3.Text = "Buscar:"
      '
      'frmPropietAg
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(872, 554)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.tbBuscar)
      Me.Controls.Add(Me.cmdSalir)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.btnQuitar)
      Me.Controls.Add(Me.btnAgregar)
      Me.Controls.Add(Me.DataGridView2)
      Me.Controls.Add(Me.cbGrupo)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.DataGridView1)
      Me.KeyPreview = True
      Me.Name = "frmPropietAg"
      Me.Text = "Propietarios: Agrupar"
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
   Friend WithEvents cbGrupo As System.Windows.Forms.ComboBox
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
   Friend WithEvents btnAgregar As System.Windows.Forms.Button
   Friend WithEvents btnQuitar As System.Windows.Forms.Button
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents cmdSalir As System.Windows.Forms.Button
   Friend WithEvents tbBuscar As System.Windows.Forms.TextBox
   Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
