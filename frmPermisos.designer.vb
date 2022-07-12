<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPermisos
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
      Me.DataGridView2 = New System.Windows.Forms.DataGridView()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.lblUsuariosDe = New System.Windows.Forms.Label()
      Me.btnAgregar = New System.Windows.Forms.Button()
      Me.btnQuitar = New System.Windows.Forms.Button()
      Me.btnCerrar = New System.Windows.Forms.Button()
      Me.DataGridView1 = New System.Windows.Forms.DataGridView()
      CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'DataGridView2
      '
      Me.DataGridView2.AllowUserToAddRows = False
      Me.DataGridView2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.DataGridView2.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
      Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.DataGridView2.Location = New System.Drawing.Point(371, 34)
      Me.DataGridView2.Name = "DataGridView2"
      Me.DataGridView2.ReadOnly = True
      Me.DataGridView2.RowTemplate.ReadOnly = True
      Me.DataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.DataGridView2.Size = New System.Drawing.Size(357, 497)
      Me.DataGridView2.TabIndex = 3
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(12, 15)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(105, 13)
      Me.Label1.TabIndex = 4
      Me.Label1.Text = "Usuarios Disponibles"
      '
      'lblUsuariosDe
      '
      Me.lblUsuariosDe.AutoSize = True
      Me.lblUsuariosDe.Location = New System.Drawing.Point(378, 15)
      Me.lblUsuariosDe.Name = "lblUsuariosDe"
      Me.lblUsuariosDe.Size = New System.Drawing.Size(63, 13)
      Me.lblUsuariosDe.TabIndex = 5
      Me.lblUsuariosDe.Text = "Usuarios de"
      '
      'btnAgregar
      '
      Me.btnAgregar.Location = New System.Drawing.Point(290, 537)
      Me.btnAgregar.Name = "btnAgregar"
      Me.btnAgregar.Size = New System.Drawing.Size(75, 23)
      Me.btnAgregar.TabIndex = 6
      Me.btnAgregar.Text = "&Agregar >>"
      Me.btnAgregar.UseVisualStyleBackColor = True
      '
      'btnQuitar
      '
      Me.btnQuitar.Location = New System.Drawing.Point(371, 537)
      Me.btnQuitar.Name = "btnQuitar"
      Me.btnQuitar.Size = New System.Drawing.Size(75, 23)
      Me.btnQuitar.TabIndex = 7
      Me.btnQuitar.Text = "<< &Quitar"
      Me.btnQuitar.UseVisualStyleBackColor = True
      '
      'btnCerrar
      '
      Me.btnCerrar.Location = New System.Drawing.Point(653, 537)
      Me.btnCerrar.Name = "btnCerrar"
      Me.btnCerrar.Size = New System.Drawing.Size(75, 23)
      Me.btnCerrar.TabIndex = 8
      Me.btnCerrar.Text = "&Cerrar"
      Me.btnCerrar.UseVisualStyleBackColor = True
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
      Me.DataGridView1.Size = New System.Drawing.Size(353, 497)
      Me.DataGridView1.TabIndex = 9
      '
      'frmPermisos
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(740, 563)
      Me.Controls.Add(Me.DataGridView1)
      Me.Controls.Add(Me.btnCerrar)
      Me.Controls.Add(Me.btnQuitar)
      Me.Controls.Add(Me.btnAgregar)
      Me.Controls.Add(Me.lblUsuariosDe)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.DataGridView2)
      Me.Name = "frmPermisos"
      Me.Text = "Permisos"
      CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents lblUsuariosDe As System.Windows.Forms.Label
   Friend WithEvents btnAgregar As System.Windows.Forms.Button
   Friend WithEvents btnQuitar As System.Windows.Forms.Button
   Friend WithEvents btnCerrar As System.Windows.Forms.Button
   Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
End Class
