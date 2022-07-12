<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCajas
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
      Me.lblBanco = New System.Windows.Forms.Label()
      Me.cbCtaCaja = New System.Windows.Forms.ComboBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.cbCtaCajaAd = New System.Windows.Forms.ComboBox()
      Me.DataGridView1 = New System.Windows.Forms.DataGridView()
      Me.btnCancelar = New System.Windows.Forms.Button()
      Me.btnAceptar = New System.Windows.Forms.Button()
      Me.tbCaja = New System.Windows.Forms.TextBox()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.tbDescrip = New System.Windows.Forms.TextBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.tbResponsable = New System.Windows.Forms.TextBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.btnAlta = New System.Windows.Forms.Button()
      Me.btnBaja = New System.Windows.Forms.Button()
      Me.btnModif = New System.Windows.Forms.Button()
      Me.btnCerrar = New System.Windows.Forms.Button()
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'lblBanco
      '
      Me.lblBanco.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblBanco.AutoSize = True
      Me.lblBanco.Location = New System.Drawing.Point(66, 412)
      Me.lblBanco.Name = "lblBanco"
      Me.lblBanco.Size = New System.Drawing.Size(44, 13)
      Me.lblBanco.TabIndex = 102
      Me.lblBanco.Text = "Cuenta:"
      '
      'cbCtaCaja
      '
      Me.cbCtaCaja.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cbCtaCaja.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      Me.cbCtaCaja.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.cbCtaCaja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbCtaCaja.Enabled = False
      Me.cbCtaCaja.FormattingEnabled = True
      Me.cbCtaCaja.Location = New System.Drawing.Point(119, 409)
      Me.cbCtaCaja.Name = "cbCtaCaja"
      Me.cbCtaCaja.Size = New System.Drawing.Size(468, 21)
      Me.cbCtaCaja.TabIndex = 101
      '
      'Label1
      '
      Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(39, 447)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(71, 13)
      Me.Label1.TabIndex = 104
      Me.Label1.Text = "Cuenta Adm.:"
      '
      'cbCtaCajaAd
      '
      Me.cbCtaCajaAd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cbCtaCajaAd.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      Me.cbCtaCajaAd.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.cbCtaCajaAd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbCtaCajaAd.Enabled = False
      Me.cbCtaCajaAd.FormattingEnabled = True
      Me.cbCtaCajaAd.Location = New System.Drawing.Point(119, 444)
      Me.cbCtaCajaAd.Name = "cbCtaCajaAd"
      Me.cbCtaCajaAd.Size = New System.Drawing.Size(468, 21)
      Me.cbCtaCajaAd.TabIndex = 103
      '
      'DataGridView1
      '
      Me.DataGridView1.AllowUserToAddRows = False
      Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
      Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.DataGridView1.Location = New System.Drawing.Point(12, 22)
      Me.DataGridView1.Name = "DataGridView1"
      Me.DataGridView1.ReadOnly = True
      Me.DataGridView1.RowTemplate.ReadOnly = True
      Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.DataGridView1.Size = New System.Drawing.Size(635, 234)
      Me.DataGridView1.TabIndex = 105
      '
      'btnCancelar
      '
      Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnCancelar.Enabled = False
      Me.btnCancelar.Location = New System.Drawing.Point(569, 487)
      Me.btnCancelar.Name = "btnCancelar"
      Me.btnCancelar.Size = New System.Drawing.Size(72, 25)
      Me.btnCancelar.TabIndex = 107
      Me.btnCancelar.Text = "&Cancelar"
      Me.btnCancelar.UseVisualStyleBackColor = True
      '
      'btnAceptar
      '
      Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnAceptar.Enabled = False
      Me.btnAceptar.Location = New System.Drawing.Point(487, 487)
      Me.btnAceptar.Name = "btnAceptar"
      Me.btnAceptar.Size = New System.Drawing.Size(76, 25)
      Me.btnAceptar.TabIndex = 106
      Me.btnAceptar.Text = "&Aceptar"
      Me.btnAceptar.UseVisualStyleBackColor = True
      '
      'tbCaja
      '
      Me.tbCaja.Enabled = False
      Me.tbCaja.Location = New System.Drawing.Point(119, 304)
      Me.tbCaja.Name = "tbCaja"
      Me.tbCaja.Size = New System.Drawing.Size(58, 20)
      Me.tbCaja.TabIndex = 108
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.Location = New System.Drawing.Point(64, 307)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(46, 13)
      Me.Label5.TabIndex = 109
      Me.Label5.Text = "Nº Caja:"
      '
      'tbDescrip
      '
      Me.tbDescrip.Enabled = False
      Me.tbDescrip.Location = New System.Drawing.Point(119, 330)
      Me.tbDescrip.MaxLength = 50
      Me.tbDescrip.Name = "tbDescrip"
      Me.tbDescrip.Size = New System.Drawing.Size(328, 20)
      Me.tbDescrip.TabIndex = 110
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(44, 333)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(66, 13)
      Me.Label2.TabIndex = 111
      Me.Label2.Text = "Descripción:"
      '
      'tbResponsable
      '
      Me.tbResponsable.Enabled = False
      Me.tbResponsable.Location = New System.Drawing.Point(119, 356)
      Me.tbResponsable.MaxLength = 50
      Me.tbResponsable.Name = "tbResponsable"
      Me.tbResponsable.Size = New System.Drawing.Size(328, 20)
      Me.tbResponsable.TabIndex = 112
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(38, 359)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(72, 13)
      Me.Label3.TabIndex = 113
      Me.Label3.Text = "Responsable:"
      '
      'btnAlta
      '
      Me.btnAlta.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnAlta.Location = New System.Drawing.Point(12, 262)
      Me.btnAlta.Name = "btnAlta"
      Me.btnAlta.Size = New System.Drawing.Size(76, 25)
      Me.btnAlta.TabIndex = 114
      Me.btnAlta.Text = "&Alta"
      Me.btnAlta.UseVisualStyleBackColor = True
      '
      'btnBaja
      '
      Me.btnBaja.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnBaja.Enabled = False
      Me.btnBaja.Location = New System.Drawing.Point(94, 262)
      Me.btnBaja.Name = "btnBaja"
      Me.btnBaja.Size = New System.Drawing.Size(76, 25)
      Me.btnBaja.TabIndex = 115
      Me.btnBaja.Text = "&Baja"
      Me.btnBaja.UseVisualStyleBackColor = True
      '
      'btnModif
      '
      Me.btnModif.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnModif.Enabled = False
      Me.btnModif.Location = New System.Drawing.Point(176, 262)
      Me.btnModif.Name = "btnModif"
      Me.btnModif.Size = New System.Drawing.Size(76, 25)
      Me.btnModif.TabIndex = 116
      Me.btnModif.Text = "&Modificar"
      Me.btnModif.UseVisualStyleBackColor = True
      '
      'btnCerrar
      '
      Me.btnCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnCerrar.Location = New System.Drawing.Point(571, 262)
      Me.btnCerrar.Name = "btnCerrar"
      Me.btnCerrar.Size = New System.Drawing.Size(76, 25)
      Me.btnCerrar.TabIndex = 117
      Me.btnCerrar.Text = "&Cerrar"
      Me.btnCerrar.UseVisualStyleBackColor = True
      '
      'frmCajas
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me.btnCerrar
      Me.ClientSize = New System.Drawing.Size(659, 526)
      Me.Controls.Add(Me.btnCerrar)
      Me.Controls.Add(Me.btnModif)
      Me.Controls.Add(Me.btnBaja)
      Me.Controls.Add(Me.btnAlta)
      Me.Controls.Add(Me.tbResponsable)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.tbDescrip)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.tbCaja)
      Me.Controls.Add(Me.Label5)
      Me.Controls.Add(Me.btnCancelar)
      Me.Controls.Add(Me.btnAceptar)
      Me.Controls.Add(Me.DataGridView1)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.cbCtaCajaAd)
      Me.Controls.Add(Me.lblBanco)
      Me.Controls.Add(Me.cbCtaCaja)
      Me.KeyPreview = True
      Me.Name = "frmCajas"
      Me.Text = "Cajas"
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblBanco As System.Windows.Forms.Label
   Friend WithEvents cbCtaCaja As System.Windows.Forms.ComboBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents cbCtaCajaAd As System.Windows.Forms.ComboBox
   Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
   Friend WithEvents btnCancelar As System.Windows.Forms.Button
   Friend WithEvents btnAceptar As System.Windows.Forms.Button
   Friend WithEvents tbCaja As System.Windows.Forms.TextBox
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents tbDescrip As System.Windows.Forms.TextBox
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents tbResponsable As System.Windows.Forms.TextBox
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents btnAlta As System.Windows.Forms.Button
   Friend WithEvents btnBaja As System.Windows.Forms.Button
   Friend WithEvents btnModif As System.Windows.Forms.Button
   Friend WithEvents btnCerrar As System.Windows.Forms.Button
End Class
