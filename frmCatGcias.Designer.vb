<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCatGcias
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
      Me.tbCodigo = New System.Windows.Forms.TextBox()
      Me.Label8 = New System.Windows.Forms.Label()
      Me.btnCancelar = New System.Windows.Forms.Button()
      Me.btnAceptar = New System.Windows.Forms.Button()
      Me.tbDescrip = New System.Windows.Forms.TextBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.tbAbrev = New System.Windows.Forms.TextBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.tbAlicuota = New System.Windows.Forms.TextBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.tbMinImp = New System.Windows.Forms.TextBox()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.tbRetMin = New System.Windows.Forms.TextBox()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.DataGridView1 = New System.Windows.Forms.DataGridView()
      Me.btnCerrar = New System.Windows.Forms.Button()
      Me.btnModif = New System.Windows.Forms.Button()
      Me.btnBaja = New System.Windows.Forms.Button()
      Me.btnAlta = New System.Windows.Forms.Button()
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'tbCodigo
      '
      Me.tbCodigo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.tbCodigo.Enabled = False
      Me.tbCodigo.Location = New System.Drawing.Point(140, 307)
      Me.tbCodigo.MaxLength = 2
      Me.tbCodigo.Name = "tbCodigo"
      Me.tbCodigo.Size = New System.Drawing.Size(49, 20)
      Me.tbCodigo.TabIndex = 95
      '
      'Label8
      '
      Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.Label8.AutoSize = True
      Me.Label8.Location = New System.Drawing.Point(84, 310)
      Me.Label8.Name = "Label8"
      Me.Label8.Size = New System.Drawing.Size(50, 13)
      Me.Label8.TabIndex = 96
      Me.Label8.Text = "Código #"
      '
      'btnCancelar
      '
      Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnCancelar.Location = New System.Drawing.Point(557, 441)
      Me.btnCancelar.Name = "btnCancelar"
      Me.btnCancelar.Size = New System.Drawing.Size(76, 27)
      Me.btnCancelar.TabIndex = 116
      Me.btnCancelar.Text = "&Cancelar"
      Me.btnCancelar.UseVisualStyleBackColor = True
      '
      'btnAceptar
      '
      Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnAceptar.Location = New System.Drawing.Point(475, 441)
      Me.btnAceptar.Name = "btnAceptar"
      Me.btnAceptar.Size = New System.Drawing.Size(76, 27)
      Me.btnAceptar.TabIndex = 115
      Me.btnAceptar.Text = "&Aceptar"
      Me.btnAceptar.UseVisualStyleBackColor = True
      '
      'tbDescrip
      '
      Me.tbDescrip.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.tbDescrip.Enabled = False
      Me.tbDescrip.Location = New System.Drawing.Point(140, 333)
      Me.tbDescrip.MaxLength = 50
      Me.tbDescrip.Name = "tbDescrip"
      Me.tbDescrip.Size = New System.Drawing.Size(439, 20)
      Me.tbDescrip.TabIndex = 117
      '
      'Label1
      '
      Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(68, 336)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(66, 13)
      Me.Label1.TabIndex = 118
      Me.Label1.Text = "Descripción:"
      '
      'tbAbrev
      '
      Me.tbAbrev.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.tbAbrev.Enabled = False
      Me.tbAbrev.Location = New System.Drawing.Point(140, 359)
      Me.tbAbrev.MaxLength = 5
      Me.tbAbrev.Name = "tbAbrev"
      Me.tbAbrev.Size = New System.Drawing.Size(76, 20)
      Me.tbAbrev.TabIndex = 119
      '
      'Label2
      '
      Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(62, 362)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(72, 13)
      Me.Label2.TabIndex = 120
      Me.Label2.Text = "Desc. Abrev.:"
      '
      'tbAlicuota
      '
      Me.tbAlicuota.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.tbAlicuota.Enabled = False
      Me.tbAlicuota.Location = New System.Drawing.Point(140, 385)
      Me.tbAlicuota.MaxLength = 5
      Me.tbAlicuota.Name = "tbAlicuota"
      Me.tbAlicuota.Size = New System.Drawing.Size(39, 20)
      Me.tbAlicuota.TabIndex = 121
      '
      'Label3
      '
      Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(76, 388)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(58, 13)
      Me.Label3.TabIndex = 122
      Me.Label3.Text = "Alícuota %"
      '
      'tbMinImp
      '
      Me.tbMinImp.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.tbMinImp.Enabled = False
      Me.tbMinImp.Location = New System.Drawing.Point(140, 415)
      Me.tbMinImp.MaxLength = 10
      Me.tbMinImp.Name = "tbMinImp"
      Me.tbMinImp.Size = New System.Drawing.Size(76, 20)
      Me.tbMinImp.TabIndex = 123
      '
      'Label4
      '
      Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(60, 418)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(74, 13)
      Me.Label4.TabIndex = 124
      Me.Label4.Text = "Mínimo Imp. $"
      '
      'tbRetMin
      '
      Me.tbRetMin.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.tbRetMin.Enabled = False
      Me.tbRetMin.Location = New System.Drawing.Point(140, 441)
      Me.tbRetMin.MaxLength = 10
      Me.tbRetMin.Name = "tbRetMin"
      Me.tbRetMin.Size = New System.Drawing.Size(76, 20)
      Me.tbRetMin.TabIndex = 125
      '
      'Label5
      '
      Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.Label5.AutoSize = True
      Me.Label5.Location = New System.Drawing.Point(46, 444)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(88, 13)
      Me.Label5.TabIndex = 126
      Me.Label5.Text = "Retención Min. $"
      '
      'DataGridView1
      '
      Me.DataGridView1.AllowUserToAddRows = False
      Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
      Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.DataGridView1.Location = New System.Drawing.Point(12, 12)
      Me.DataGridView1.Name = "DataGridView1"
      Me.DataGridView1.ReadOnly = True
      Me.DataGridView1.RowTemplate.ReadOnly = True
      Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.DataGridView1.Size = New System.Drawing.Size(621, 239)
      Me.DataGridView1.TabIndex = 127
      '
      'btnCerrar
      '
      Me.btnCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCerrar.Location = New System.Drawing.Point(557, 257)
      Me.btnCerrar.Name = "btnCerrar"
      Me.btnCerrar.Size = New System.Drawing.Size(76, 25)
      Me.btnCerrar.TabIndex = 131
      Me.btnCerrar.Text = "&Cerrar"
      Me.btnCerrar.UseVisualStyleBackColor = True
      '
      'btnModif
      '
      Me.btnModif.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btnModif.Enabled = False
      Me.btnModif.Location = New System.Drawing.Point(176, 257)
      Me.btnModif.Name = "btnModif"
      Me.btnModif.Size = New System.Drawing.Size(76, 25)
      Me.btnModif.TabIndex = 130
      Me.btnModif.Text = "&Modificar"
      Me.btnModif.UseVisualStyleBackColor = True
      '
      'btnBaja
      '
      Me.btnBaja.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btnBaja.Enabled = False
      Me.btnBaja.Location = New System.Drawing.Point(94, 257)
      Me.btnBaja.Name = "btnBaja"
      Me.btnBaja.Size = New System.Drawing.Size(76, 25)
      Me.btnBaja.TabIndex = 129
      Me.btnBaja.Text = "&Baja"
      Me.btnBaja.UseVisualStyleBackColor = True
      '
      'btnAlta
      '
      Me.btnAlta.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btnAlta.Location = New System.Drawing.Point(12, 257)
      Me.btnAlta.Name = "btnAlta"
      Me.btnAlta.Size = New System.Drawing.Size(76, 25)
      Me.btnAlta.TabIndex = 128
      Me.btnAlta.Text = "&Alta"
      Me.btnAlta.UseVisualStyleBackColor = True
      '
      'frmCatGcias
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(645, 480)
      Me.Controls.Add(Me.btnCerrar)
      Me.Controls.Add(Me.btnModif)
      Me.Controls.Add(Me.btnBaja)
      Me.Controls.Add(Me.btnAlta)
      Me.Controls.Add(Me.DataGridView1)
      Me.Controls.Add(Me.tbRetMin)
      Me.Controls.Add(Me.Label5)
      Me.Controls.Add(Me.tbMinImp)
      Me.Controls.Add(Me.Label4)
      Me.Controls.Add(Me.tbAlicuota)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.tbAbrev)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.tbDescrip)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.btnCancelar)
      Me.Controls.Add(Me.btnAceptar)
      Me.Controls.Add(Me.tbCodigo)
      Me.Controls.Add(Me.Label8)
      Me.KeyPreview = True
      Me.Name = "frmCatGcias"
      Me.Text = "Categorías de Ganancias"
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents tbCodigo As System.Windows.Forms.TextBox
   Friend WithEvents Label8 As System.Windows.Forms.Label
   Friend WithEvents btnCancelar As System.Windows.Forms.Button
   Friend WithEvents btnAceptar As System.Windows.Forms.Button
   Friend WithEvents tbDescrip As System.Windows.Forms.TextBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents tbAbrev As System.Windows.Forms.TextBox
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents tbAlicuota As System.Windows.Forms.TextBox
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents tbMinImp As System.Windows.Forms.TextBox
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents tbRetMin As System.Windows.Forms.TextBox
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
   Friend WithEvents btnCerrar As System.Windows.Forms.Button
   Friend WithEvents btnModif As System.Windows.Forms.Button
   Friend WithEvents btnBaja As System.Windows.Forms.Button
   Friend WithEvents btnAlta As System.Windows.Forms.Button
End Class
