<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOrdenPagoVsAg
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
      Me.btnAgregar = New System.Windows.Forms.Button()
      Me.btnCerrar = New System.Windows.Forms.Button()
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
      Me.DataGridView1.Location = New System.Drawing.Point(12, 9)
      Me.DataGridView1.Name = "DataGridView1"
      Me.DataGridView1.ReadOnly = True
      Me.DataGridView1.RowTemplate.ReadOnly = True
      Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.DataGridView1.Size = New System.Drawing.Size(590, 408)
      Me.DataGridView1.TabIndex = 112
      '
      'btnAgregar
      '
      Me.btnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnAgregar.Location = New System.Drawing.Point(444, 426)
      Me.btnAgregar.Name = "btnAgregar"
      Me.btnAgregar.Size = New System.Drawing.Size(88, 25)
      Me.btnAgregar.TabIndex = 183
      Me.btnAgregar.Text = "&Agregar"
      Me.btnAgregar.UseVisualStyleBackColor = True
      '
      'btnCerrar
      '
      Me.btnCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnCerrar.Location = New System.Drawing.Point(538, 426)
      Me.btnCerrar.Name = "btnCerrar"
      Me.btnCerrar.Size = New System.Drawing.Size(64, 25)
      Me.btnCerrar.TabIndex = 184
      Me.btnCerrar.Text = "&Cerrar"
      Me.btnCerrar.UseVisualStyleBackColor = True
      '
      'frmOrdenPagoVsAg
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(614, 463)
      Me.Controls.Add(Me.btnAgregar)
      Me.Controls.Add(Me.btnCerrar)
      Me.Controls.Add(Me.DataGridView1)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.MaximizeBox = False
      Me.Name = "frmOrdenPagoVsAg"
      Me.Text = "Orden de Pago Vs"
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
   Friend WithEvents btnAgregar As System.Windows.Forms.Button
   Friend WithEvents btnCerrar As System.Windows.Forms.Button
End Class
