<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmABM
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
      Me.lblEfectivo = New System.Windows.Forms.Label()
      Me.tbBuscar = New System.Windows.Forms.TextBox()
      Me.btnImprimir = New System.Windows.Forms.Button()
      Me.tbCodigo = New System.Windows.Forms.TextBox()
      Me.lblCodigo = New System.Windows.Forms.Label()
      Me.tbNombre = New System.Windows.Forms.TextBox()
      Me.lblDescrip = New System.Windows.Forms.Label()
      Me.tbDoble1 = New System.Windows.Forms.TextBox()
      Me.lblDoble1 = New System.Windows.Forms.Label()
      Me.tbDoble2 = New System.Windows.Forms.TextBox()
      Me.lblDoble2 = New System.Windows.Forms.Label()
      Me.chkLogico = New System.Windows.Forms.CheckBox()
      Me.btnAceptar = New System.Windows.Forms.Button()
      Me.btnCancelar = New System.Windows.Forms.Button()
      Me.btnDet = New System.Windows.Forms.Button()
        Me.tbEntero = New System.Windows.Forms.TextBox()
        Me.lblEntero = New System.Windows.Forms.Label()
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
        Me.DataGridView1.Location = New System.Drawing.Point(12, 42)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowTemplate.ReadOnly = True
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(893, 341)
        Me.DataGridView1.TabIndex = 1
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.CausesValidation = False
        Me.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnSalir.Location = New System.Drawing.Point(830, 389)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(75, 23)
        Me.btnSalir.TabIndex = 6
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnBaja
        '
        Me.btnBaja.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnBaja.Location = New System.Drawing.Point(81, 389)
        Me.btnBaja.Name = "btnBaja"
        Me.btnBaja.Size = New System.Drawing.Size(62, 23)
        Me.btnBaja.TabIndex = 3
        Me.btnBaja.Text = "&Baja"
        Me.btnBaja.UseVisualStyleBackColor = True
        '
        'btnModif
        '
        Me.btnModif.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnModif.Location = New System.Drawing.Point(149, 389)
        Me.btnModif.Name = "btnModif"
        Me.btnModif.Size = New System.Drawing.Size(66, 23)
        Me.btnModif.TabIndex = 4
        Me.btnModif.Text = "&Modificar"
        Me.btnModif.UseVisualStyleBackColor = True
        '
        'btnAlta
        '
        Me.btnAlta.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAlta.Location = New System.Drawing.Point(12, 389)
        Me.btnAlta.Name = "btnAlta"
        Me.btnAlta.Size = New System.Drawing.Size(63, 23)
        Me.btnAlta.TabIndex = 2
        Me.btnAlta.Text = "&Alta"
        Me.btnAlta.UseVisualStyleBackColor = True
        '
        'lblEfectivo
        '
        Me.lblEfectivo.AutoSize = True
        Me.lblEfectivo.Location = New System.Drawing.Point(12, 15)
        Me.lblEfectivo.Name = "lblEfectivo"
        Me.lblEfectivo.Size = New System.Drawing.Size(43, 13)
        Me.lblEfectivo.TabIndex = 153
        Me.lblEfectivo.Text = "Buscar:"
        '
        'tbBuscar
        '
        Me.tbBuscar.Location = New System.Drawing.Point(61, 12)
        Me.tbBuscar.MaxLength = 10
        Me.tbBuscar.Name = "tbBuscar"
        Me.tbBuscar.Size = New System.Drawing.Size(317, 20)
        Me.tbBuscar.TabIndex = 0
        '
        'btnImprimir
        '
        Me.btnImprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnImprimir.CausesValidation = False
        Me.btnImprimir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnImprimir.Location = New System.Drawing.Point(638, 389)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(75, 23)
        Me.btnImprimir.TabIndex = 5
        Me.btnImprimir.Text = "&Imprimir"
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'tbCodigo
        '
        Me.tbCodigo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tbCodigo.Enabled = False
        Me.tbCodigo.Location = New System.Drawing.Point(149, 432)
        Me.tbCodigo.MaxLength = 10
        Me.tbCodigo.Name = "tbCodigo"
        Me.tbCodigo.Size = New System.Drawing.Size(74, 20)
        Me.tbCodigo.TabIndex = 7
        '
        'lblCodigo
        '
        Me.lblCodigo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.Enabled = False
        Me.lblCodigo.Location = New System.Drawing.Point(48, 432)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(43, 13)
        Me.lblCodigo.TabIndex = 157
        Me.lblCodigo.Text = "Código:"
        Me.lblCodigo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbNombre
        '
        Me.tbNombre.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tbNombre.Enabled = False
        Me.tbNombre.Location = New System.Drawing.Point(149, 459)
        Me.tbNombre.MaxLength = 50
        Me.tbNombre.Name = "tbNombre"
        Me.tbNombre.Size = New System.Drawing.Size(372, 20)
        Me.tbNombre.TabIndex = 8
        '
        'lblDescrip
        '
        Me.lblDescrip.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblDescrip.AutoSize = True
        Me.lblDescrip.Enabled = False
        Me.lblDescrip.Location = New System.Drawing.Point(48, 462)
        Me.lblDescrip.Name = "lblDescrip"
        Me.lblDescrip.Size = New System.Drawing.Size(66, 13)
        Me.lblDescrip.TabIndex = 158
        Me.lblDescrip.Text = "Descripción:"
        Me.lblDescrip.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbDoble1
        '
        Me.tbDoble1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tbDoble1.Enabled = False
        Me.tbDoble1.Location = New System.Drawing.Point(149, 516)
        Me.tbDoble1.MaxLength = 10
        Me.tbDoble1.Name = "tbDoble1"
        Me.tbDoble1.Size = New System.Drawing.Size(90, 20)
        Me.tbDoble1.TabIndex = 10
        '
        'lblDoble1
        '
        Me.lblDoble1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblDoble1.AutoSize = True
        Me.lblDoble1.Enabled = False
        Me.lblDoble1.Location = New System.Drawing.Point(48, 519)
        Me.lblDoble1.Name = "lblDoble1"
        Me.lblDoble1.Size = New System.Drawing.Size(44, 13)
        Me.lblDoble1.TabIndex = 160
        Me.lblDoble1.Text = "Doble1:"
        Me.lblDoble1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblDoble1.Visible = False
        '
        'tbDoble2
        '
        Me.tbDoble2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tbDoble2.Enabled = False
        Me.tbDoble2.Location = New System.Drawing.Point(149, 544)
        Me.tbDoble2.MaxLength = 10
        Me.tbDoble2.Name = "tbDoble2"
        Me.tbDoble2.Size = New System.Drawing.Size(90, 20)
        Me.tbDoble2.TabIndex = 11
        '
        'lblDoble2
        '
        Me.lblDoble2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblDoble2.AutoSize = True
        Me.lblDoble2.Enabled = False
        Me.lblDoble2.Location = New System.Drawing.Point(48, 547)
        Me.lblDoble2.Name = "lblDoble2"
        Me.lblDoble2.Size = New System.Drawing.Size(44, 13)
        Me.lblDoble2.TabIndex = 162
        Me.lblDoble2.Text = "Doble2:"
        Me.lblDoble2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chkLogico
        '
        Me.chkLogico.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkLogico.AutoSize = True
        Me.chkLogico.Enabled = False
        Me.chkLogico.Location = New System.Drawing.Point(280, 547)
        Me.chkLogico.Name = "chkLogico"
        Me.chkLogico.Size = New System.Drawing.Size(58, 17)
        Me.chkLogico.TabIndex = 12
        Me.chkLogico.Text = "Logico"
        Me.chkLogico.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.Enabled = False
        Me.btnAceptar.Location = New System.Drawing.Point(749, 566)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 25)
        Me.btnAceptar.TabIndex = 15
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.Enabled = False
        Me.btnCancelar.Location = New System.Drawing.Point(830, 566)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 25)
        Me.btnCancelar.TabIndex = 16
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnDet
        '
        Me.btnDet.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDet.Location = New System.Drawing.Point(280, 389)
        Me.btnDet.Name = "btnDet"
        Me.btnDet.Size = New System.Drawing.Size(66, 23)
        Me.btnDet.TabIndex = 163
        Me.btnDet.Text = "&Det."
        Me.btnDet.UseVisualStyleBackColor = True
        Me.btnDet.Visible = False
        '
        'tbEntero
        '
        Me.tbEntero.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tbEntero.Enabled = False
        Me.tbEntero.Location = New System.Drawing.Point(149, 487)
        Me.tbEntero.MaxLength = 10
        Me.tbEntero.Name = "tbEntero"
        Me.tbEntero.Size = New System.Drawing.Size(74, 20)
        Me.tbEntero.TabIndex = 9
        '
        'lblEntero
        '
        Me.lblEntero.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblEntero.AutoSize = True
        Me.lblEntero.Enabled = False
        Me.lblEntero.Location = New System.Drawing.Point(48, 490)
        Me.lblEntero.Name = "lblEntero"
        Me.lblEntero.Size = New System.Drawing.Size(41, 13)
        Me.lblEntero.TabIndex = 165
        Me.lblEntero.Text = "Entero:"
        Me.lblEntero.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmABM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnSalir
        Me.ClientSize = New System.Drawing.Size(917, 597)
        Me.Controls.Add(Me.tbEntero)
        Me.Controls.Add(Me.lblEntero)
        Me.Controls.Add(Me.btnDet)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.chkLogico)
        Me.Controls.Add(Me.tbDoble2)
        Me.Controls.Add(Me.lblDoble2)
        Me.Controls.Add(Me.tbDoble1)
        Me.Controls.Add(Me.lblDoble1)
        Me.Controls.Add(Me.tbCodigo)
        Me.Controls.Add(Me.lblCodigo)
        Me.Controls.Add(Me.tbNombre)
        Me.Controls.Add(Me.lblDescrip)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.lblEfectivo)
        Me.Controls.Add(Me.tbBuscar)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnBaja)
        Me.Controls.Add(Me.btnModif)
        Me.Controls.Add(Me.btnAlta)
        Me.Controls.Add(Me.DataGridView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmABM"
        Me.Text = "A.B.M."
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
   Friend WithEvents btnSalir As System.Windows.Forms.Button
   Friend WithEvents btnBaja As System.Windows.Forms.Button
   Friend WithEvents btnModif As System.Windows.Forms.Button
   Friend WithEvents btnAlta As System.Windows.Forms.Button
   Friend WithEvents lblEfectivo As System.Windows.Forms.Label
   Friend WithEvents tbBuscar As System.Windows.Forms.TextBox
   Friend WithEvents btnImprimir As System.Windows.Forms.Button
   Friend WithEvents tbCodigo As System.Windows.Forms.TextBox
   Friend WithEvents lblCodigo As System.Windows.Forms.Label
   Friend WithEvents tbNombre As System.Windows.Forms.TextBox
   Friend WithEvents lblDescrip As System.Windows.Forms.Label
   Friend WithEvents tbDoble1 As System.Windows.Forms.TextBox
   Friend WithEvents lblDoble1 As System.Windows.Forms.Label
   Friend WithEvents tbDoble2 As System.Windows.Forms.TextBox
   Friend WithEvents lblDoble2 As System.Windows.Forms.Label
   Friend WithEvents chkLogico As System.Windows.Forms.CheckBox
   Friend WithEvents btnAceptar As System.Windows.Forms.Button
   Friend WithEvents btnCancelar As System.Windows.Forms.Button
   Friend WithEvents btnDet As System.Windows.Forms.Button
    Friend WithEvents tbEntero As TextBox
    Friend WithEvents lblEntero As Label
End Class
