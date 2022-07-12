<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmContratosAbm
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
      Me.cmdAlta = New System.Windows.Forms.Button()
      Me.GroupBox1 = New System.Windows.Forms.GroupBox()
      Me.dtpDesde = New System.Windows.Forms.DateTimePicker()
      Me.chkTodas = New System.Windows.Forms.CheckBox()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.dtpHasta = New System.Windows.Forms.DateTimePicker()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.cbEstado = New System.Windows.Forms.ComboBox()
      Me.cbPropietario = New System.Windows.Forms.ComboBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.cbInquilino = New System.Windows.Forms.ComboBox()
      Me.DataGridView1 = New System.Windows.Forms.DataGridView()
      Me.cmdSalir = New System.Windows.Forms.Button()
      Me.cmdAnular = New System.Windows.Forms.Button()
      Me.cmdImprimir = New System.Windows.Forms.Button()
      Me.cmdFinalizar = New System.Windows.Forms.Button()
      Me.btnActualizar = New System.Windows.Forms.Button()
      Me.gbActualiz = New System.Windows.Forms.GroupBox()
      Me.optTodos = New System.Windows.Forms.RadioButton()
      Me.optAct = New System.Windows.Forms.RadioButton()
      Me.optNoAct = New System.Windows.Forms.RadioButton()
      Me.optParticular = New System.Windows.Forms.RadioButton()
      Me.optComercial = New System.Windows.Forms.RadioButton()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.btnImprList = New System.Windows.Forms.Button()
      Me.optPC = New System.Windows.Forms.RadioButton()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbActualiz.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdAlta
        '
        Me.cmdAlta.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdAlta.Location = New System.Drawing.Point(12, 516)
        Me.cmdAlta.Name = "cmdAlta"
        Me.cmdAlta.Size = New System.Drawing.Size(76, 27)
        Me.cmdAlta.TabIndex = 6
        Me.cmdAlta.Text = "&Alta"
        Me.cmdAlta.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dtpDesde)
        Me.GroupBox1.Controls.Add(Me.chkTodas)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.dtpHasta)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 33)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(369, 52)
        Me.GroupBox1.TabIndex = 70
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Fechas"
        '
        'dtpDesde
        '
        Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDesde.Location = New System.Drawing.Point(63, 19)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(83, 20)
        Me.dtpDesde.TabIndex = 51
        Me.dtpDesde.Value = New Date(2015, 9, 24, 0, 0, 0, 0)
        '
        'chkTodas
        '
        Me.chkTodas.AutoSize = True
        Me.chkTodas.Location = New System.Drawing.Point(303, 22)
        Me.chkTodas.Name = "chkTodas"
        Me.chkTodas.Size = New System.Drawing.Size(56, 17)
        Me.chkTodas.TabIndex = 4
        Me.chkTodas.Text = "&Todas"
        Me.chkTodas.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(161, 23)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 50
        Me.Label5.Text = "Hasta:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 13)
        Me.Label4.TabIndex = 49
        Me.Label4.Text = "Desde:"
        '
        'dtpHasta
        '
        Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpHasta.Location = New System.Drawing.Point(205, 19)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(83, 20)
        Me.dtpHasta.TabIndex = 3
        Me.dtpHasta.Value = New Date(2015, 9, 24, 0, 0, 0, 0)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(580, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 69
        Me.Label2.Text = "Estado:"
        '
        'cbEstado
        '
        Me.cbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbEstado.FormattingEnabled = True
        Me.cbEstado.Location = New System.Drawing.Point(629, 6)
        Me.cbEstado.Name = "cbEstado"
        Me.cbEstado.Size = New System.Drawing.Size(126, 21)
        Me.cbEstado.TabIndex = 1
        '
        'cbPropietario
        '
        Me.cbPropietario.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbPropietario.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbPropietario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPropietario.FormattingEnabled = True
        Me.cbPropietario.Location = New System.Drawing.Point(75, 6)
        Me.cbPropietario.Name = "cbPropietario"
        Me.cbPropietario.Size = New System.Drawing.Size(466, 21)
        Me.cbPropietario.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 66
        Me.Label1.Text = "Propietario:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(391, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 13)
        Me.Label3.TabIndex = 73
        Me.Label3.Text = "Inquilino:"
        '
        'cbInquilino
        '
        Me.cbInquilino.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbInquilino.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbInquilino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbInquilino.FormattingEnabled = True
        Me.cbInquilino.Location = New System.Drawing.Point(446, 51)
        Me.cbInquilino.Name = "cbInquilino"
        Me.cbInquilino.Size = New System.Drawing.Size(309, 21)
        Me.cbInquilino.TabIndex = 5
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(12, 91)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowTemplate.ReadOnly = True
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(1028, 419)
        Me.DataGridView1.TabIndex = 74
        '
        'cmdSalir
        '
        Me.cmdSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSalir.Location = New System.Drawing.Point(964, 516)
        Me.cmdSalir.Name = "cmdSalir"
        Me.cmdSalir.Size = New System.Drawing.Size(76, 27)
        Me.cmdSalir.TabIndex = 10
        Me.cmdSalir.Text = "&Salir"
        Me.cmdSalir.UseVisualStyleBackColor = True
        '
        'cmdAnular
        '
        Me.cmdAnular.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdAnular.Location = New System.Drawing.Point(176, 516)
        Me.cmdAnular.Name = "cmdAnular"
        Me.cmdAnular.Size = New System.Drawing.Size(76, 27)
        Me.cmdAnular.TabIndex = 8
        Me.cmdAnular.Text = "&Anular"
        Me.cmdAnular.UseVisualStyleBackColor = True
        '
        'cmdImprimir
        '
        Me.cmdImprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdImprimir.Location = New System.Drawing.Point(258, 516)
        Me.cmdImprimir.Name = "cmdImprimir"
        Me.cmdImprimir.Size = New System.Drawing.Size(101, 27)
        Me.cmdImprimir.TabIndex = 9
        Me.cmdImprimir.Text = "&Imprimir Ctto."
        Me.cmdImprimir.UseVisualStyleBackColor = True
        '
        'cmdFinalizar
        '
        Me.cmdFinalizar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdFinalizar.Location = New System.Drawing.Point(94, 516)
        Me.cmdFinalizar.Name = "cmdFinalizar"
        Me.cmdFinalizar.Size = New System.Drawing.Size(76, 27)
        Me.cmdFinalizar.TabIndex = 7
        Me.cmdFinalizar.Text = "&Finalizar"
        Me.cmdFinalizar.UseVisualStyleBackColor = True
        '
        'btnActualizar
        '
        Me.btnActualizar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnActualizar.Location = New System.Drawing.Point(430, 516)
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(76, 27)
        Me.btnActualizar.TabIndex = 75
        Me.btnActualizar.Text = "A&ctualizar"
        Me.btnActualizar.UseVisualStyleBackColor = True
        '
        'gbActualiz
        '
        Me.gbActualiz.Controls.Add(Me.optTodos)
        Me.gbActualiz.Controls.Add(Me.optAct)
        Me.gbActualiz.Controls.Add(Me.optNoAct)
        Me.gbActualiz.Location = New System.Drawing.Point(770, 6)
        Me.gbActualiz.Name = "gbActualiz"
        Me.gbActualiz.Size = New System.Drawing.Size(270, 50)
        Me.gbActualiz.TabIndex = 76
        Me.gbActualiz.TabStop = False
        Me.gbActualiz.Text = "Actualización"
        '
        'optTodos
        '
        Me.optTodos.AutoSize = True
        Me.optTodos.Location = New System.Drawing.Point(199, 24)
        Me.optTodos.Name = "optTodos"
        Me.optTodos.Size = New System.Drawing.Size(55, 17)
        Me.optTodos.TabIndex = 2
        Me.optTodos.Text = "&Todos"
        Me.optTodos.UseVisualStyleBackColor = True
        '
        'optAct
        '
        Me.optAct.AutoSize = True
        Me.optAct.Location = New System.Drawing.Point(108, 24)
        Me.optAct.Name = "optAct"
        Me.optAct.Size = New System.Drawing.Size(85, 17)
        Me.optAct.TabIndex = 1
        Me.optAct.Text = "&Actualizados"
        Me.optAct.UseVisualStyleBackColor = True
        '
        'optNoAct
        '
        Me.optNoAct.AutoSize = True
        Me.optNoAct.Checked = True
        Me.optNoAct.Location = New System.Drawing.Point(20, 24)
        Me.optNoAct.Name = "optNoAct"
        Me.optNoAct.Size = New System.Drawing.Size(82, 17)
        Me.optNoAct.TabIndex = 0
        Me.optNoAct.TabStop = True
        Me.optNoAct.Text = "&No Actualiz."
        Me.optNoAct.UseVisualStyleBackColor = True
        '
        'optParticular
        '
        Me.optParticular.AutoSize = True
        Me.optParticular.Location = New System.Drawing.Point(885, 68)
        Me.optParticular.Name = "optParticular"
        Me.optParticular.Size = New System.Drawing.Size(69, 17)
        Me.optParticular.TabIndex = 77
        Me.optParticular.Text = "&Particular"
        Me.optParticular.UseVisualStyleBackColor = True
        '
        'optComercial
        '
        Me.optComercial.AutoSize = True
        Me.optComercial.Location = New System.Drawing.Point(960, 68)
        Me.optComercial.Name = "optComercial"
        Me.optComercial.Size = New System.Drawing.Size(71, 17)
        Me.optComercial.TabIndex = 78
        Me.optComercial.Text = "&Comercial"
        Me.optComercial.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(787, 70)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(31, 13)
        Me.Label6.TabIndex = 79
        Me.Label6.Text = "Tipo:"
        '
        'btnImprList
        '
        Me.btnImprList.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnImprList.Location = New System.Drawing.Point(550, 516)
        Me.btnImprList.Name = "btnImprList"
        Me.btnImprList.Size = New System.Drawing.Size(101, 27)
        Me.btnImprList.TabIndex = 80
        Me.btnImprList.Text = "&Imprimir Listado"
        Me.btnImprList.UseVisualStyleBackColor = True
        '
        'optPC
        '
        Me.optPC.AutoSize = True
        Me.optPC.Checked = True
        Me.optPC.Location = New System.Drawing.Point(824, 68)
        Me.optPC.Name = "optPC"
        Me.optPC.Size = New System.Drawing.Size(55, 17)
        Me.optPC.TabIndex = 81
        Me.optPC.TabStop = True
        Me.optPC.Text = "&Todos"
        Me.optPC.UseVisualStyleBackColor = True
        '
        'frmContratosAbm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1052, 555)
        Me.Controls.Add(Me.optPC)
        Me.Controls.Add(Me.btnImprList)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.optComercial)
        Me.Controls.Add(Me.optParticular)
        Me.Controls.Add(Me.gbActualiz)
        Me.Controls.Add(Me.btnActualizar)
        Me.Controls.Add(Me.cmdFinalizar)
        Me.Controls.Add(Me.cmdSalir)
        Me.Controls.Add(Me.cmdAnular)
        Me.Controls.Add(Me.cmdImprimir)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cbInquilino)
        Me.Controls.Add(Me.cmdAlta)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cbEstado)
        Me.Controls.Add(Me.cbPropietario)
        Me.Controls.Add(Me.Label1)
        Me.KeyPreview = True
        Me.Name = "frmContratosAbm"
        Me.Text = "Contratos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbActualiz.ResumeLayout(False)
        Me.gbActualiz.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdAlta As System.Windows.Forms.Button
   Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents chkTodas As System.Windows.Forms.CheckBox
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents dtpHasta As System.Windows.Forms.DateTimePicker
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents cbEstado As System.Windows.Forms.ComboBox
   Friend WithEvents cbPropietario As System.Windows.Forms.ComboBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents cbInquilino As System.Windows.Forms.ComboBox
   Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
   Friend WithEvents cmdSalir As System.Windows.Forms.Button
   Friend WithEvents cmdAnular As System.Windows.Forms.Button
   Friend WithEvents cmdImprimir As System.Windows.Forms.Button
   Friend WithEvents cmdFinalizar As System.Windows.Forms.Button
   Friend WithEvents dtpDesde As System.Windows.Forms.DateTimePicker
   Friend WithEvents btnActualizar As Button
   Friend WithEvents gbActualiz As GroupBox
   Friend WithEvents optTodos As RadioButton
   Friend WithEvents optAct As RadioButton
   Friend WithEvents optNoAct As RadioButton
    Friend WithEvents optParticular As RadioButton
    Friend WithEvents optComercial As RadioButton
    Friend WithEvents Label6 As Label
    Friend WithEvents btnImprList As Button
   Friend WithEvents optPC As RadioButton
End Class
