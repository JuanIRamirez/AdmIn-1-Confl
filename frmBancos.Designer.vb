<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBancos
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
      Me.lblEfectivo = New System.Windows.Forms.Label()
      Me.tbBuscar = New System.Windows.Forms.TextBox()
      Me.btnBaja = New System.Windows.Forms.Button()
      Me.btnModif = New System.Windows.Forms.Button()
      Me.btnAlta = New System.Windows.Forms.Button()
      Me.btnSalir = New System.Windows.Forms.Button()
      Me.DataGridView1 = New System.Windows.Forms.DataGridView()
      Me.btnCuentas = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblEfectivo
        '
        Me.lblEfectivo.AutoSize = True
        Me.lblEfectivo.Location = New System.Drawing.Point(9, 15)
        Me.lblEfectivo.Name = "lblEfectivo"
        Me.lblEfectivo.Size = New System.Drawing.Size(43, 13)
        Me.lblEfectivo.TabIndex = 93
        Me.lblEfectivo.Text = "Buscar:"
        '
        'tbBuscar
        '
        Me.tbBuscar.Location = New System.Drawing.Point(58, 12)
        Me.tbBuscar.MaxLength = 10
        Me.tbBuscar.Name = "tbBuscar"
        Me.tbBuscar.Size = New System.Drawing.Size(317, 20)
        Me.tbBuscar.TabIndex = 92
        '
        'btnBaja
        '
        Me.btnBaja.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnBaja.Location = New System.Drawing.Point(92, 438)
        Me.btnBaja.Name = "btnBaja"
        Me.btnBaja.Size = New System.Drawing.Size(75, 25)
        Me.btnBaja.TabIndex = 111
        Me.btnBaja.Text = "&Baja"
        Me.btnBaja.UseVisualStyleBackColor = True
        '
        'btnModif
        '
        Me.btnModif.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnModif.Location = New System.Drawing.Point(173, 438)
        Me.btnModif.Name = "btnModif"
        Me.btnModif.Size = New System.Drawing.Size(75, 25)
        Me.btnModif.TabIndex = 112
        Me.btnModif.Text = "&Modificar"
        Me.btnModif.UseVisualStyleBackColor = True
        '
        'btnAlta
        '
        Me.btnAlta.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAlta.Location = New System.Drawing.Point(11, 438)
        Me.btnAlta.Name = "btnAlta"
        Me.btnAlta.Size = New System.Drawing.Size(75, 25)
        Me.btnAlta.TabIndex = 110
        Me.btnAlta.Text = "&Alta"
        Me.btnAlta.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.CausesValidation = False
        Me.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnSalir.Location = New System.Drawing.Point(622, 438)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(75, 25)
        Me.btnSalir.TabIndex = 113
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(12, 41)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowTemplate.ReadOnly = True
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(685, 391)
        Me.DataGridView1.TabIndex = 146
        '
        'btnCuentas
        '
        Me.btnCuentas.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCuentas.Location = New System.Drawing.Point(388, 438)
        Me.btnCuentas.Name = "btnCuentas"
        Me.btnCuentas.Size = New System.Drawing.Size(75, 25)
        Me.btnCuentas.TabIndex = 147
        Me.btnCuentas.Text = "&Cuentas"
        Me.btnCuentas.UseVisualStyleBackColor = True
        '
        'frmBancos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnSalir
        Me.ClientSize = New System.Drawing.Size(709, 473)
        Me.Controls.Add(Me.btnCuentas)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnBaja)
        Me.Controls.Add(Me.btnModif)
        Me.Controls.Add(Me.btnAlta)
        Me.Controls.Add(Me.lblEfectivo)
        Me.Controls.Add(Me.tbBuscar)
        Me.KeyPreview = True
        Me.MinimizeBox = False
        Me.Name = "frmBancos"
        Me.Text = "Bancos"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblEfectivo As System.Windows.Forms.Label
   Friend WithEvents tbBuscar As System.Windows.Forms.TextBox
   Friend WithEvents btnBaja As System.Windows.Forms.Button
   Friend WithEvents btnModif As System.Windows.Forms.Button
   Friend WithEvents btnAlta As System.Windows.Forms.Button
   Friend WithEvents btnSalir As System.Windows.Forms.Button
   Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
   Friend WithEvents btnCuentas As System.Windows.Forms.Button
End Class
