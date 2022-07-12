<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmListInquilinos
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
      Me.cbPropietario = New System.Windows.Forms.ComboBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.cbInquilino = New System.Windows.Forms.ComboBox()
      Me.Label13 = New System.Windows.Forms.Label()
      Me.cbConcepto = New System.Windows.Forms.ComboBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.optListDeuda = New System.Windows.Forms.RadioButton()
      Me.optListDeudaT = New System.Windows.Forms.RadioButton()
      Me.dtpHasta = New System.Windows.Forms.DateTimePicker()
      Me.Label18 = New System.Windows.Forms.Label()
      Me.chkResumen = New System.Windows.Forms.CheckBox()
      Me.cmdCancelar = New System.Windows.Forms.Button()
      Me.cmdAceptar = New System.Windows.Forms.Button()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.optInqAct = New System.Windows.Forms.RadioButton()
      Me.optInactivos = New System.Windows.Forms.RadioButton()
        Me.SuspendLayout()
        '
        'cbPropietario
        '
        Me.cbPropietario.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbPropietario.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbPropietario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPropietario.FormattingEnabled = True
        Me.cbPropietario.Location = New System.Drawing.Point(98, 46)
        Me.cbPropietario.Name = "cbPropietario"
        Me.cbPropietario.Size = New System.Drawing.Size(433, 21)
        Me.cbPropietario.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(32, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 70
        Me.Label1.Text = "Propietario:"
        '
        'cbInquilino
        '
        Me.cbInquilino.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbInquilino.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbInquilino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbInquilino.FormattingEnabled = True
        Me.cbInquilino.Location = New System.Drawing.Point(98, 85)
        Me.cbInquilino.Name = "cbInquilino"
        Me.cbInquilino.Size = New System.Drawing.Size(433, 21)
        Me.cbInquilino.TabIndex = 1
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(43, 88)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(49, 13)
        Me.Label13.TabIndex = 72
        Me.Label13.Text = "Inquilino:"
        '
        'cbConcepto
        '
        Me.cbConcepto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbConcepto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbConcepto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbConcepto.FormattingEnabled = True
        Me.cbConcepto.Location = New System.Drawing.Point(98, 125)
        Me.cbConcepto.Name = "cbConcepto"
        Me.cbConcepto.Size = New System.Drawing.Size(433, 21)
        Me.cbConcepto.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(36, 128)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 74
        Me.Label2.Text = "Concepto:"
        '
        'optListDeuda
        '
        Me.optListDeuda.AutoSize = True
        Me.optListDeuda.Checked = True
        Me.optListDeuda.Location = New System.Drawing.Point(98, 172)
        Me.optListDeuda.Name = "optListDeuda"
        Me.optListDeuda.Size = New System.Drawing.Size(57, 17)
        Me.optListDeuda.TabIndex = 3
        Me.optListDeuda.TabStop = True
        Me.optListDeuda.Text = "&Deuda"
        Me.optListDeuda.UseVisualStyleBackColor = True
        '
        'optListDeudaT
        '
        Me.optListDeudaT.AutoSize = True
        Me.optListDeudaT.Location = New System.Drawing.Point(179, 172)
        Me.optListDeudaT.Name = "optListDeudaT"
        Me.optListDeudaT.Size = New System.Drawing.Size(84, 17)
        Me.optListDeudaT.TabIndex = 4
        Me.optListDeudaT.Text = "Deuda &Total"
        Me.optListDeudaT.UseVisualStyleBackColor = True
        '
        'dtpHasta
        '
        Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpHasta.Location = New System.Drawing.Point(98, 212)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(88, 20)
        Me.dtpHasta.TabIndex = 6
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(54, 214)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(38, 13)
        Me.Label18.TabIndex = 89
        Me.Label18.Text = "Hasta:"
        '
        'chkResumen
        '
        Me.chkResumen.AutoSize = True
        Me.chkResumen.Location = New System.Drawing.Point(288, 213)
        Me.chkResumen.Name = "chkResumen"
        Me.chkResumen.Size = New System.Drawing.Size(71, 17)
        Me.chkResumen.TabIndex = 7
        Me.chkResumen.Text = "&Resumen"
        Me.chkResumen.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Location = New System.Drawing.Point(548, 280)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(65, 27)
        Me.cmdCancelar.TabIndex = 9
        Me.cmdCancelar.Text = "&Cancelar"
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAceptar.Location = New System.Drawing.Point(455, 280)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(87, 27)
        Me.cmdAceptar.TabIndex = 8
        Me.cmdAceptar.Text = "&Aceptar"
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(43, 174)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 90
        Me.Label3.Text = "Reporte:"
        '
        'optInqAct
        '
        Me.optInqAct.AutoSize = True
        Me.optInqAct.Location = New System.Drawing.Point(288, 172)
        Me.optInqAct.Name = "optInqAct"
        Me.optInqAct.Size = New System.Drawing.Size(107, 17)
        Me.optInqAct.TabIndex = 91
        Me.optInqAct.Text = "Inquilinos &Activos"
        Me.optInqAct.UseVisualStyleBackColor = True
        '
        'optInactivos
        '
        Me.optInactivos.AutoSize = True
        Me.optInactivos.Location = New System.Drawing.Point(418, 172)
        Me.optInactivos.Name = "optInactivos"
        Me.optInactivos.Size = New System.Drawing.Size(115, 17)
        Me.optInactivos.TabIndex = 92
        Me.optInactivos.Text = "Inquilinos &Inactivos"
        Me.optInactivos.UseVisualStyleBackColor = True
        '
        'FrmListInquilinos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(625, 319)
        Me.Controls.Add(Me.optInactivos)
        Me.Controls.Add(Me.optInqAct)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Controls.Add(Me.chkResumen)
        Me.Controls.Add(Me.dtpHasta)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.optListDeudaT)
        Me.Controls.Add(Me.optListDeuda)
        Me.Controls.Add(Me.cbConcepto)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cbInquilino)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.cbPropietario)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmListInquilinos"
        Me.Text = "Listados de Inquilinos"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cbPropietario As System.Windows.Forms.ComboBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents cbInquilino As System.Windows.Forms.ComboBox
   Friend WithEvents Label13 As System.Windows.Forms.Label
   Friend WithEvents cbConcepto As System.Windows.Forms.ComboBox
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents optListDeuda As System.Windows.Forms.RadioButton
   Friend WithEvents optListDeudaT As System.Windows.Forms.RadioButton
   Friend WithEvents dtpHasta As System.Windows.Forms.DateTimePicker
   Friend WithEvents Label18 As System.Windows.Forms.Label
   Friend WithEvents chkResumen As System.Windows.Forms.CheckBox
   Friend WithEvents cmdCancelar As System.Windows.Forms.Button
   Friend WithEvents cmdAceptar As System.Windows.Forms.Button
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents optInqAct As RadioButton
   Friend WithEvents optInactivos As RadioButton
End Class
