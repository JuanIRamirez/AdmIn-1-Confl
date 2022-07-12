<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmContratoEsc
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
      Me.Frame1 = New System.Windows.Forms.GroupBox()
      Me.optManual = New System.Windows.Forms.RadioButton()
      Me.optPorcent = New System.Windows.Forms.RadioButton()
      Me.optBloques = New System.Windows.Forms.RadioButton()
      Me.optIncremental = New System.Windows.Forms.RadioButton()
      Me.optUniforme = New System.Windows.Forms.RadioButton()
      Me.DataGridView1 = New System.Windows.Forms.DataGridView()
      Me.Frame2 = New System.Windows.Forms.GroupBox()
      Me.cmdEliminar = New System.Windows.Forms.Button()
      Me.cmdActualizar = New System.Windows.Forms.Button()
      Me.txtImpPorc = New System.Windows.Forms.TextBox()
        Me.optDisminuye = New System.Windows.Forms.RadioButton()
        Me.optAumenta = New System.Windows.Forms.RadioButton()
        Me.lblMeses = New System.Windows.Forms.Label()
        Me.lblMes = New System.Windows.Forms.Label()
        Me.UpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.txtImpAlq = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.cmdAceptar = New System.Windows.Forms.Button()
        Me.gbValor = New System.Windows.Forms.GroupBox()
        Me.optImp = New System.Windows.Forms.RadioButton()
        Me.optPorc = New System.Windows.Forms.RadioButton()
        Me.Frame1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Frame2.SuspendLayout()
        CType(Me.UpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbValor.SuspendLayout()
        Me.SuspendLayout()
        '
        'Frame1
        '
        Me.Frame1.Controls.Add(Me.optManual)
        Me.Frame1.Controls.Add(Me.optPorcent)
        Me.Frame1.Controls.Add(Me.optBloques)
        Me.Frame1.Controls.Add(Me.optIncremental)
        Me.Frame1.Controls.Add(Me.optUniforme)
        Me.Frame1.Location = New System.Drawing.Point(409, 44)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.Size = New System.Drawing.Size(240, 141)
        Me.Frame1.TabIndex = 1
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Escalonamiento"
        '
        'optManual
        '
        Me.optManual.AutoSize = True
        Me.optManual.Location = New System.Drawing.Point(108, 111)
        Me.optManual.Name = "optManual"
        Me.optManual.Size = New System.Drawing.Size(60, 17)
        Me.optManual.TabIndex = 4
        Me.optManual.Text = "&Manual"
        Me.optManual.UseVisualStyleBackColor = True
        '
        'optPorcent
        '
        Me.optPorcent.AutoSize = True
        Me.optPorcent.Location = New System.Drawing.Point(108, 88)
        Me.optPorcent.Name = "optPorcent"
        Me.optPorcent.Size = New System.Drawing.Size(76, 17)
        Me.optPorcent.TabIndex = 3
        Me.optPorcent.Text = "&Porcentaje"
        Me.optPorcent.UseVisualStyleBackColor = True
        '
        'optBloques
        '
        Me.optBloques.AutoSize = True
        Me.optBloques.Location = New System.Drawing.Point(108, 65)
        Me.optBloques.Name = "optBloques"
        Me.optBloques.Size = New System.Drawing.Size(63, 17)
        Me.optBloques.TabIndex = 2
        Me.optBloques.Text = "&Bloques"
        Me.optBloques.UseVisualStyleBackColor = True
        '
        'optIncremental
        '
        Me.optIncremental.AutoSize = True
        Me.optIncremental.Location = New System.Drawing.Point(108, 42)
        Me.optIncremental.Name = "optIncremental"
        Me.optIncremental.Size = New System.Drawing.Size(80, 17)
        Me.optIncremental.TabIndex = 1
        Me.optIncremental.Text = "&Incremental"
        Me.optIncremental.UseVisualStyleBackColor = True
        '
        'optUniforme
        '
        Me.optUniforme.AutoSize = True
        Me.optUniforme.Checked = True
        Me.optUniforme.Location = New System.Drawing.Point(108, 19)
        Me.optUniforme.Name = "optUniforme"
        Me.optUniforme.Size = New System.Drawing.Size(67, 17)
        Me.optUniforme.TabIndex = 0
        Me.optUniforme.TabStop = True
        Me.optUniforme.Text = "&Uniforme"
        Me.optUniforme.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
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
        Me.DataGridView1.Size = New System.Drawing.Size(391, 419)
        Me.DataGridView1.TabIndex = 75
        '
        'Frame2
        '
        Me.Frame2.Controls.Add(Me.optDisminuye)
        Me.Frame2.Controls.Add(Me.optAumenta)
        Me.Frame2.Controls.Add(Me.lblMeses)
        Me.Frame2.Controls.Add(Me.lblMes)
        Me.Frame2.Controls.Add(Me.UpDown1)
        Me.Frame2.Location = New System.Drawing.Point(409, 191)
        Me.Frame2.Name = "Frame2"
        Me.Frame2.Size = New System.Drawing.Size(240, 115)
        Me.Frame2.TabIndex = 76
        Me.Frame2.TabStop = False
        Me.Frame2.Text = "Incremento"
        '
        'cmdEliminar
        '
        Me.cmdEliminar.Location = New System.Drawing.Point(172, 55)
        Me.cmdEliminar.Name = "cmdEliminar"
        Me.cmdEliminar.Size = New System.Drawing.Size(62, 23)
        Me.cmdEliminar.TabIndex = 95
        Me.cmdEliminar.Text = "&Eliminar"
        Me.cmdEliminar.UseVisualStyleBackColor = True
        '
        'cmdActualizar
        '
        Me.cmdActualizar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdActualizar.Location = New System.Drawing.Point(93, 55)
        Me.cmdActualizar.Name = "cmdActualizar"
        Me.cmdActualizar.Size = New System.Drawing.Size(73, 23)
        Me.cmdActualizar.TabIndex = 94
        Me.cmdActualizar.Text = "&Actualizar"
        Me.cmdActualizar.UseVisualStyleBackColor = True
        '
        'txtImpPorc
        '
        Me.txtImpPorc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImpPorc.Location = New System.Drawing.Point(161, 21)
        Me.txtImpPorc.MaxLength = 10
        Me.txtImpPorc.Name = "txtImpPorc"
        Me.txtImpPorc.Size = New System.Drawing.Size(73, 20)
        Me.txtImpPorc.TabIndex = 93
        '
        'optDisminuye
        '
        Me.optDisminuye.AutoSize = True
        Me.optDisminuye.Location = New System.Drawing.Point(125, 67)
        Me.optDisminuye.Name = "optDisminuye"
        Me.optDisminuye.Size = New System.Drawing.Size(73, 17)
        Me.optDisminuye.TabIndex = 91
        Me.optDisminuye.Text = "&Disminuye"
        Me.optDisminuye.UseVisualStyleBackColor = True
        '
        'optAumenta
        '
        Me.optAumenta.AutoSize = True
        Me.optAumenta.Checked = True
        Me.optAumenta.Location = New System.Drawing.Point(32, 67)
        Me.optAumenta.Name = "optAumenta"
        Me.optAumenta.Size = New System.Drawing.Size(67, 17)
        Me.optAumenta.TabIndex = 90
        Me.optAumenta.TabStop = True
        Me.optAumenta.Text = "&Aumenta"
        Me.optAumenta.UseVisualStyleBackColor = True
        '
        'lblMeses
        '
        Me.lblMeses.AutoSize = True
        Me.lblMeses.Location = New System.Drawing.Point(169, 29)
        Me.lblMeses.Name = "lblMeses"
        Me.lblMeses.Size = New System.Drawing.Size(41, 13)
        Me.lblMeses.TabIndex = 89
        Me.lblMeses.Text = "Meses."
        '
        'lblMes
        '
        Me.lblMes.AutoSize = True
        Me.lblMes.Location = New System.Drawing.Point(29, 29)
        Me.lblMes.Name = "lblMes"
        Me.lblMes.Size = New System.Drawing.Size(90, 13)
        Me.lblMes.TabIndex = 88
        Me.lblMes.Text = "Incremento cada:"
        '
        'UpDown1
        '
        Me.UpDown1.Location = New System.Drawing.Point(125, 27)
        Me.UpDown1.Name = "UpDown1"
        Me.UpDown1.Size = New System.Drawing.Size(38, 20)
        Me.UpDown1.TabIndex = 1
        '
        'txtImpAlq
        '
        Me.txtImpAlq.BackColor = System.Drawing.SystemColors.Info
        Me.txtImpAlq.Enabled = False
        Me.txtImpAlq.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImpAlq.Location = New System.Drawing.Point(555, 11)
        Me.txtImpAlq.Name = "txtImpAlq"
        Me.txtImpAlq.Size = New System.Drawing.Size(94, 20)
        Me.txtImpAlq.TabIndex = 88
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(415, 14)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(105, 13)
        Me.Label17.TabIndex = 87
        Me.Label17.Text = "Valor inicial alquiler $"
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Location = New System.Drawing.Point(574, 411)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(75, 25)
        Me.cmdCancelar.TabIndex = 89
        Me.cmdCancelar.Text = "&Cancelar"
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAceptar.Location = New System.Drawing.Point(483, 411)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(85, 25)
        Me.cmdAceptar.TabIndex = 90
        Me.cmdAceptar.Text = "&Aceptar"
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'gbValor
        '
        Me.gbValor.Controls.Add(Me.optPorc)
        Me.gbValor.Controls.Add(Me.optImp)
        Me.gbValor.Controls.Add(Me.txtImpPorc)
        Me.gbValor.Controls.Add(Me.cmdEliminar)
        Me.gbValor.Controls.Add(Me.cmdActualizar)
        Me.gbValor.Location = New System.Drawing.Point(409, 312)
        Me.gbValor.Name = "gbValor"
        Me.gbValor.Size = New System.Drawing.Size(240, 93)
        Me.gbValor.TabIndex = 96
        Me.gbValor.TabStop = False
        Me.gbValor.Text = "Valor"
        '
        'optImp
        '
        Me.optImp.AutoSize = True
        Me.optImp.Checked = True
        Me.optImp.Location = New System.Drawing.Point(22, 22)
        Me.optImp.Name = "optImp"
        Me.optImp.Size = New System.Drawing.Size(69, 17)
        Me.optImp.TabIndex = 96
        Me.optImp.Text = "&Importe $"
        Me.optImp.UseVisualStyleBackColor = True
        '
        'optPorc
        '
        Me.optPorc.AutoSize = True
        Me.optPorc.Location = New System.Drawing.Point(94, 22)
        Me.optPorc.Name = "optPorc"
        Me.optPorc.Size = New System.Drawing.Size(61, 17)
        Me.optPorc.TabIndex = 97
        Me.optPorc.Text = "&Porc. %"
        Me.optPorc.UseVisualStyleBackColor = True
        '
        'frmContratoEsc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(661, 449)
        Me.Controls.Add(Me.gbValor)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.txtImpAlq)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Frame2)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Frame1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmContratoEsc"
        Me.Text = "Contrato: Escalonamiento"
        Me.Frame1.ResumeLayout(False)
        Me.Frame1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Frame2.ResumeLayout(False)
        Me.Frame2.PerformLayout()
        CType(Me.UpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbValor.ResumeLayout(False)
        Me.gbValor.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Frame1 As System.Windows.Forms.GroupBox
   Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
   Friend WithEvents Frame2 As System.Windows.Forms.GroupBox
   Friend WithEvents UpDown1 As System.Windows.Forms.NumericUpDown
   Friend WithEvents txtImpAlq As System.Windows.Forms.TextBox
   Friend WithEvents Label17 As System.Windows.Forms.Label
   Friend WithEvents optManual As System.Windows.Forms.RadioButton
   Friend WithEvents optPorcent As System.Windows.Forms.RadioButton
   Friend WithEvents optBloques As System.Windows.Forms.RadioButton
   Friend WithEvents optIncremental As System.Windows.Forms.RadioButton
   Friend WithEvents optUniforme As System.Windows.Forms.RadioButton
   Friend WithEvents lblMeses As System.Windows.Forms.Label
   Friend WithEvents lblMes As System.Windows.Forms.Label
   Friend WithEvents txtImpPorc As System.Windows.Forms.TextBox
    Friend WithEvents optDisminuye As System.Windows.Forms.RadioButton
    Friend WithEvents optAumenta As System.Windows.Forms.RadioButton
    Friend WithEvents cmdEliminar As System.Windows.Forms.Button
    Friend WithEvents cmdActualizar As System.Windows.Forms.Button
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
    Friend WithEvents gbValor As GroupBox
    Friend WithEvents optPorc As RadioButton
    Friend WithEvents optImp As RadioButton
End Class
