<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBancosCtas
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
      Me.btnSalir = New System.Windows.Forms.Button()
      Me.btnBaja = New System.Windows.Forms.Button()
      Me.btnModif = New System.Windows.Forms.Button()
      Me.btnAlta = New System.Windows.Forms.Button()
      Me.tbBanco = New System.Windows.Forms.TextBox()
      Me.Label8 = New System.Windows.Forms.Label()
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'DataGridView1
      '
      Me.DataGridView1.AllowUserToAddRows = False
      Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
      Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.DataGridView1.Location = New System.Drawing.Point(12, 34)
      Me.DataGridView1.Name = "DataGridView1"
      Me.DataGridView1.ReadOnly = True
      Me.DataGridView1.RowTemplate.ReadOnly = True
      Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.DataGridView1.Size = New System.Drawing.Size(611, 395)
      Me.DataGridView1.TabIndex = 151
      '
      'btnSalir
      '
      Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnSalir.CausesValidation = False
      Me.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnSalir.Location = New System.Drawing.Point(548, 435)
      Me.btnSalir.Name = "btnSalir"
      Me.btnSalir.Size = New System.Drawing.Size(75, 23)
      Me.btnSalir.TabIndex = 150
      Me.btnSalir.Text = "&Salir"
      Me.btnSalir.UseVisualStyleBackColor = True
      '
      'btnBaja
      '
      Me.btnBaja.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btnBaja.Location = New System.Drawing.Point(93, 435)
      Me.btnBaja.Name = "btnBaja"
      Me.btnBaja.Size = New System.Drawing.Size(75, 23)
      Me.btnBaja.TabIndex = 148
      Me.btnBaja.Text = "&Baja"
      Me.btnBaja.UseVisualStyleBackColor = True
      '
      'btnModif
      '
      Me.btnModif.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btnModif.Location = New System.Drawing.Point(174, 435)
      Me.btnModif.Name = "btnModif"
      Me.btnModif.Size = New System.Drawing.Size(75, 23)
      Me.btnModif.TabIndex = 149
      Me.btnModif.Text = "&Modificar"
      Me.btnModif.UseVisualStyleBackColor = True
      '
      'btnAlta
      '
      Me.btnAlta.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btnAlta.Location = New System.Drawing.Point(12, 435)
      Me.btnAlta.Name = "btnAlta"
      Me.btnAlta.Size = New System.Drawing.Size(75, 23)
      Me.btnAlta.TabIndex = 147
      Me.btnAlta.Text = "&Alta"
      Me.btnAlta.UseVisualStyleBackColor = True
      '
      'tbBanco
      '
      Me.tbBanco.Enabled = False
      Me.tbBanco.Location = New System.Drawing.Point(56, 6)
      Me.tbBanco.MaxLength = 10
      Me.tbBanco.Name = "tbBanco"
      Me.tbBanco.Size = New System.Drawing.Size(567, 20)
      Me.tbBanco.TabIndex = 152
      '
      'Label8
      '
      Me.Label8.AutoSize = True
      Me.Label8.Location = New System.Drawing.Point(9, 9)
      Me.Label8.Name = "Label8"
      Me.Label8.Size = New System.Drawing.Size(41, 13)
      Me.Label8.TabIndex = 153
      Me.Label8.Text = "Banco:"
      '
      'frmBancosCtas
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(635, 468)
      Me.Controls.Add(Me.tbBanco)
      Me.Controls.Add(Me.Label8)
      Me.Controls.Add(Me.DataGridView1)
      Me.Controls.Add(Me.btnSalir)
      Me.Controls.Add(Me.btnBaja)
      Me.Controls.Add(Me.btnModif)
      Me.Controls.Add(Me.btnAlta)
      Me.Name = "frmBancosCtas"
      Me.Text = "Cuentas Banco"
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
   Friend WithEvents btnSalir As System.Windows.Forms.Button
   Friend WithEvents btnBaja As System.Windows.Forms.Button
   Friend WithEvents btnModif As System.Windows.Forms.Button
   Friend WithEvents btnAlta As System.Windows.Forms.Button
   Friend WithEvents tbBanco As System.Windows.Forms.TextBox
   Friend WithEvents Label8 As System.Windows.Forms.Label
End Class
