<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListConcAdm
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
      Me.cbConceptos = New System.Windows.Forms.ComboBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.cmdImprimir = New System.Windows.Forms.Button()
      Me.btCerrar = New System.Windows.Forms.Button()
      Me.cbConcepto = New System.Windows.Forms.ComboBox()
      Me.dtpPeriodo = New System.Windows.Forms.DateTimePicker()
      Me.Label18 = New System.Windows.Forms.Label()
      Me.chkTodos = New System.Windows.Forms.CheckBox()
      Me.GroupBox1 = New System.Windows.Forms.GroupBox()
      Me.optPagoSi = New System.Windows.Forms.RadioButton()
      Me.optPagoNo = New System.Windows.Forms.RadioButton()
      Me.optPagoT = New System.Windows.Forms.RadioButton()
      Me.GroupBox2 = New System.Windows.Forms.GroupBox()
      Me.optCobroT = New System.Windows.Forms.RadioButton()
      Me.optCobroNo = New System.Windows.Forms.RadioButton()
      Me.optCobroSi = New System.Windows.Forms.RadioButton()
      Me.GroupBox1.SuspendLayout()
      Me.GroupBox2.SuspendLayout()
      Me.SuspendLayout()
      '
      'cbConceptos
      '
      Me.cbConceptos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cbConceptos.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      Me.cbConceptos.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.cbConceptos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbConceptos.FormattingEnabled = True
      Me.cbConceptos.Location = New System.Drawing.Point(169, 31)
      Me.cbConceptos.Name = "cbConceptos"
      Me.cbConceptos.Size = New System.Drawing.Size(438, 21)
      Me.cbConceptos.TabIndex = 1
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(23, 34)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(56, 13)
      Me.Label1.TabIndex = 97
      Me.Label1.Text = "Concepto:"
      '
      'cmdImprimir
      '
      Me.cmdImprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdImprimir.Location = New System.Drawing.Point(451, 300)
      Me.cmdImprimir.Name = "cmdImprimir"
      Me.cmdImprimir.Size = New System.Drawing.Size(75, 25)
      Me.cmdImprimir.TabIndex = 98
      Me.cmdImprimir.Text = "&Imprimir"
      Me.cmdImprimir.UseVisualStyleBackColor = True
      '
      'btCerrar
      '
      Me.btCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btCerrar.Location = New System.Drawing.Point(532, 300)
      Me.btCerrar.Name = "btCerrar"
      Me.btCerrar.Size = New System.Drawing.Size(75, 25)
      Me.btCerrar.TabIndex = 99
      Me.btCerrar.Text = "&Cerrar"
      Me.btCerrar.UseVisualStyleBackColor = True
      '
      'cbConcepto
      '
      Me.cbConcepto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cbConcepto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      Me.cbConcepto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.cbConcepto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbConcepto.FormattingEnabled = True
      Me.cbConcepto.Location = New System.Drawing.Point(88, 31)
      Me.cbConcepto.Name = "cbConcepto"
      Me.cbConcepto.Size = New System.Drawing.Size(75, 21)
      Me.cbConcepto.TabIndex = 0
      '
      'dtpPeriodo
      '
      Me.dtpPeriodo.CustomFormat = "MM/yyyy"
      Me.dtpPeriodo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpPeriodo.Location = New System.Drawing.Point(88, 81)
      Me.dtpPeriodo.Name = "dtpPeriodo"
      Me.dtpPeriodo.Size = New System.Drawing.Size(86, 20)
      Me.dtpPeriodo.TabIndex = 2
      '
      'Label18
      '
      Me.Label18.AutoSize = True
      Me.Label18.Location = New System.Drawing.Point(23, 84)
      Me.Label18.Name = "Label18"
      Me.Label18.Size = New System.Drawing.Size(48, 13)
      Me.Label18.TabIndex = 102
      Me.Label18.Text = "Período:"
      '
      'chkTodos
      '
      Me.chkTodos.AutoSize = True
      Me.chkTodos.Location = New System.Drawing.Point(187, 84)
      Me.chkTodos.Name = "chkTodos"
      Me.chkTodos.Size = New System.Drawing.Size(56, 17)
      Me.chkTodos.TabIndex = 3
      Me.chkTodos.Text = "&Todos"
      Me.chkTodos.UseVisualStyleBackColor = True
      '
      'GroupBox1
      '
      Me.GroupBox1.Controls.Add(Me.optPagoT)
      Me.GroupBox1.Controls.Add(Me.optPagoNo)
      Me.GroupBox1.Controls.Add(Me.optPagoSi)
      Me.GroupBox1.Location = New System.Drawing.Point(17, 128)
      Me.GroupBox1.Name = "GroupBox1"
      Me.GroupBox1.Size = New System.Drawing.Size(590, 52)
      Me.GroupBox1.TabIndex = 103
      Me.GroupBox1.TabStop = False
      Me.GroupBox1.Text = "Pagados"
      '
      'optPagoSi
      '
      Me.optPagoSi.AutoSize = True
      Me.optPagoSi.Checked = True
      Me.optPagoSi.Location = New System.Drawing.Point(107, 19)
      Me.optPagoSi.Name = "optPagoSi"
      Me.optPagoSi.Size = New System.Drawing.Size(36, 17)
      Me.optPagoSi.TabIndex = 0
      Me.optPagoSi.TabStop = True
      Me.optPagoSi.Text = "&Sí"
      Me.optPagoSi.UseVisualStyleBackColor = True
      '
      'optPagoNo
      '
      Me.optPagoNo.AutoSize = True
      Me.optPagoNo.Location = New System.Drawing.Point(170, 19)
      Me.optPagoNo.Name = "optPagoNo"
      Me.optPagoNo.Size = New System.Drawing.Size(39, 17)
      Me.optPagoNo.TabIndex = 1
      Me.optPagoNo.Text = "&No"
      Me.optPagoNo.UseVisualStyleBackColor = True
      '
      'optPagoT
      '
      Me.optPagoT.AutoSize = True
      Me.optPagoT.Location = New System.Drawing.Point(234, 19)
      Me.optPagoT.Name = "optPagoT"
      Me.optPagoT.Size = New System.Drawing.Size(67, 17)
      Me.optPagoT.TabIndex = 2
      Me.optPagoT.Text = "&Indistinto"
      Me.optPagoT.UseVisualStyleBackColor = True
      '
      'GroupBox2
      '
      Me.GroupBox2.Controls.Add(Me.optCobroT)
      Me.GroupBox2.Controls.Add(Me.optCobroNo)
      Me.GroupBox2.Controls.Add(Me.optCobroSi)
      Me.GroupBox2.Location = New System.Drawing.Point(17, 186)
      Me.GroupBox2.Name = "GroupBox2"
      Me.GroupBox2.Size = New System.Drawing.Size(590, 52)
      Me.GroupBox2.TabIndex = 104
      Me.GroupBox2.TabStop = False
      Me.GroupBox2.Text = "Cobrados"
      '
      'optCobroT
      '
      Me.optCobroT.AutoSize = True
      Me.optCobroT.Location = New System.Drawing.Point(234, 19)
      Me.optCobroT.Name = "optCobroT"
      Me.optCobroT.Size = New System.Drawing.Size(67, 17)
      Me.optCobroT.TabIndex = 2
      Me.optCobroT.Text = "&Indistinto"
      Me.optCobroT.UseVisualStyleBackColor = True
      '
      'optCobroNo
      '
      Me.optCobroNo.AutoSize = True
      Me.optCobroNo.Checked = True
      Me.optCobroNo.Location = New System.Drawing.Point(104, 19)
      Me.optCobroNo.Name = "optCobroNo"
      Me.optCobroNo.Size = New System.Drawing.Size(39, 17)
      Me.optCobroNo.TabIndex = 1
      Me.optCobroNo.TabStop = True
      Me.optCobroNo.Text = "&No"
      Me.optCobroNo.UseVisualStyleBackColor = True
      '
      'optCobroSi
      '
      Me.optCobroSi.AutoSize = True
      Me.optCobroSi.Location = New System.Drawing.Point(170, 19)
      Me.optCobroSi.Name = "optCobroSi"
      Me.optCobroSi.Size = New System.Drawing.Size(36, 17)
      Me.optCobroSi.TabIndex = 0
      Me.optCobroSi.Text = "&Sí"
      Me.optCobroSi.UseVisualStyleBackColor = True
      '
      'frmListConcAdm
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(619, 336)
      Me.Controls.Add(Me.GroupBox2)
      Me.Controls.Add(Me.GroupBox1)
      Me.Controls.Add(Me.chkTodos)
      Me.Controls.Add(Me.dtpPeriodo)
      Me.Controls.Add(Me.Label18)
      Me.Controls.Add(Me.cbConcepto)
      Me.Controls.Add(Me.cmdImprimir)
      Me.Controls.Add(Me.btCerrar)
      Me.Controls.Add(Me.cbConceptos)
      Me.Controls.Add(Me.Label1)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.MaximizeBox = False
      Me.Name = "frmListConcAdm"
      Me.Text = "Listado de Conceptos Administrados"
      Me.GroupBox1.ResumeLayout(False)
      Me.GroupBox1.PerformLayout()
      Me.GroupBox2.ResumeLayout(False)
      Me.GroupBox2.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents cbConceptos As System.Windows.Forms.ComboBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents cmdImprimir As System.Windows.Forms.Button
   Friend WithEvents btCerrar As System.Windows.Forms.Button
   Friend WithEvents cbConcepto As System.Windows.Forms.ComboBox
   Friend WithEvents dtpPeriodo As System.Windows.Forms.DateTimePicker
   Friend WithEvents Label18 As System.Windows.Forms.Label
   Friend WithEvents chkTodos As System.Windows.Forms.CheckBox
   Friend WithEvents GroupBox1 As GroupBox
   Friend WithEvents optPagoT As RadioButton
   Friend WithEvents optPagoNo As RadioButton
   Friend WithEvents optPagoSi As RadioButton
   Friend WithEvents GroupBox2 As GroupBox
   Friend WithEvents optCobroT As RadioButton
   Friend WithEvents optCobroNo As RadioButton
   Friend WithEvents optCobroSi As RadioButton
End Class
