<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmContratosList
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
      Me.dtpDesde = New System.Windows.Forms.DateTimePicker()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.dtpHasta = New System.Windows.Forms.DateTimePicker()
      Me.cbPropietario = New System.Windows.Forms.ComboBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.chkFinalizados = New System.Windows.Forms.CheckBox()
      Me.chkActivos = New System.Windows.Forms.CheckBox()
      Me.optInicio = New System.Windows.Forms.RadioButton()
      Me.cmdAceptar = New System.Windows.Forms.Button()
      Me.cmdCerrar = New System.Windows.Forms.Button()
      Me.optFinal = New System.Windows.Forms.RadioButton()
      Me.chkAnulados = New System.Windows.Forms.CheckBox()
      Me.chkTodas = New System.Windows.Forms.CheckBox()
      Me.chkNoAct = New System.Windows.Forms.CheckBox()
      Me.SuspendLayout()
      '
      'dtpDesde
      '
      Me.dtpDesde.CustomFormat = "MM/yyyy"
      Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpDesde.Location = New System.Drawing.Point(219, 176)
      Me.dtpDesde.Name = "dtpDesde"
      Me.dtpDesde.Size = New System.Drawing.Size(70, 20)
      Me.dtpDesde.TabIndex = 3
      Me.dtpDesde.Value = New Date(2015, 9, 24, 0, 0, 0, 0)
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.Location = New System.Drawing.Point(329, 180)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(38, 13)
      Me.Label5.TabIndex = 54
      Me.Label5.Text = "Hasta:"
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(172, 180)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(41, 13)
      Me.Label4.TabIndex = 53
      Me.Label4.Text = "Desde:"
      '
      'dtpHasta
      '
      Me.dtpHasta.CustomFormat = "MM/yyyy"
      Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpHasta.Location = New System.Drawing.Point(373, 176)
      Me.dtpHasta.Name = "dtpHasta"
      Me.dtpHasta.Size = New System.Drawing.Size(69, 20)
      Me.dtpHasta.TabIndex = 4
      Me.dtpHasta.Value = New Date(2015, 9, 24, 0, 0, 0, 0)
      '
      'cbPropietario
      '
      Me.cbPropietario.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      Me.cbPropietario.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.cbPropietario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbPropietario.FormattingEnabled = True
      Me.cbPropietario.Location = New System.Drawing.Point(99, 52)
      Me.cbPropietario.Name = "cbPropietario"
      Me.cbPropietario.Size = New System.Drawing.Size(448, 21)
      Me.cbPropietario.TabIndex = 0
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(33, 55)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(60, 13)
      Me.Label1.TabIndex = 68
      Me.Label1.Text = "Propietario:"
      '
      'chkFinalizados
      '
      Me.chkFinalizados.AutoSize = True
      Me.chkFinalizados.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.chkFinalizados.Location = New System.Drawing.Point(169, 112)
      Me.chkFinalizados.Name = "chkFinalizados"
      Me.chkFinalizados.Size = New System.Drawing.Size(78, 17)
      Me.chkFinalizados.TabIndex = 2
      Me.chkFinalizados.Text = "&Finalizados"
      Me.chkFinalizados.UseVisualStyleBackColor = True
      '
      'chkActivos
      '
      Me.chkActivos.AutoSize = True
      Me.chkActivos.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.chkActivos.Checked = True
      Me.chkActivos.CheckState = System.Windows.Forms.CheckState.Checked
      Me.chkActivos.Location = New System.Drawing.Point(55, 112)
      Me.chkActivos.Name = "chkActivos"
      Me.chkActivos.Size = New System.Drawing.Size(61, 17)
      Me.chkActivos.TabIndex = 1
      Me.chkActivos.Text = "&Activos"
      Me.chkActivos.UseVisualStyleBackColor = True
      '
      'optInicio
      '
      Me.optInicio.AutoSize = True
      Me.optInicio.Checked = True
      Me.optInicio.Location = New System.Drawing.Point(171, 239)
      Me.optInicio.Name = "optInicio"
      Me.optInicio.Size = New System.Drawing.Size(83, 17)
      Me.optInicio.TabIndex = 5
      Me.optInicio.TabStop = True
      Me.optInicio.Text = "&Fecha &Inicio"
      Me.optInicio.UseVisualStyleBackColor = True
      '
      'cmdAceptar
      '
      Me.cmdAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdAceptar.Location = New System.Drawing.Point(435, 341)
      Me.cmdAceptar.Name = "cmdAceptar"
      Me.cmdAceptar.Size = New System.Drawing.Size(76, 27)
      Me.cmdAceptar.TabIndex = 8
      Me.cmdAceptar.Text = "&Aceptar"
      Me.cmdAceptar.UseVisualStyleBackColor = True
      '
      'cmdCerrar
      '
      Me.cmdCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdCerrar.Location = New System.Drawing.Point(517, 341)
      Me.cmdCerrar.Name = "cmdCerrar"
      Me.cmdCerrar.Size = New System.Drawing.Size(70, 27)
      Me.cmdCerrar.TabIndex = 9
      Me.cmdCerrar.Text = "&Cerrar"
      Me.cmdCerrar.UseVisualStyleBackColor = True
      '
      'optFinal
      '
      Me.optFinal.AutoSize = True
      Me.optFinal.Location = New System.Drawing.Point(301, 239)
      Me.optFinal.Name = "optFinal"
      Me.optFinal.Size = New System.Drawing.Size(80, 17)
      Me.optFinal.TabIndex = 7
      Me.optFinal.Text = "Finalización"
      Me.optFinal.UseVisualStyleBackColor = True
      '
      'chkAnulados
      '
      Me.chkAnulados.AutoSize = True
      Me.chkAnulados.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.chkAnulados.Location = New System.Drawing.Point(301, 112)
      Me.chkAnulados.Name = "chkAnulados"
      Me.chkAnulados.Size = New System.Drawing.Size(70, 17)
      Me.chkAnulados.TabIndex = 69
      Me.chkAnulados.Text = "A&nulados"
      Me.chkAnulados.UseVisualStyleBackColor = True
      '
      'chkTodas
      '
      Me.chkTodas.AutoSize = True
      Me.chkTodas.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.chkTodas.Location = New System.Drawing.Point(60, 178)
      Me.chkTodas.Name = "chkTodas"
      Me.chkTodas.Size = New System.Drawing.Size(56, 17)
      Me.chkTodas.TabIndex = 70
      Me.chkTodas.Text = "&Todas"
      Me.chkTodas.UseVisualStyleBackColor = True
      '
      'chkNoAct
      '
      Me.chkNoAct.AutoSize = True
      Me.chkNoAct.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.chkNoAct.Location = New System.Drawing.Point(435, 112)
      Me.chkNoAct.Name = "chkNoAct"
      Me.chkNoAct.Size = New System.Drawing.Size(103, 17)
      Me.chkNoAct.TabIndex = 71
      Me.chkNoAct.Text = "N&o Actualizados"
      Me.chkNoAct.UseVisualStyleBackColor = True
      '
      'frmContratosList
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(599, 380)
      Me.Controls.Add(Me.chkNoAct)
      Me.Controls.Add(Me.chkTodas)
      Me.Controls.Add(Me.chkAnulados)
      Me.Controls.Add(Me.optFinal)
      Me.Controls.Add(Me.cmdAceptar)
      Me.Controls.Add(Me.cmdCerrar)
      Me.Controls.Add(Me.optInicio)
      Me.Controls.Add(Me.chkActivos)
      Me.Controls.Add(Me.chkFinalizados)
      Me.Controls.Add(Me.cbPropietario)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.dtpDesde)
      Me.Controls.Add(Me.Label5)
      Me.Controls.Add(Me.Label4)
      Me.Controls.Add(Me.dtpHasta)
      Me.Name = "frmContratosList"
      Me.Text = "Listados de Contratos"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents dtpDesde As System.Windows.Forms.DateTimePicker
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents dtpHasta As System.Windows.Forms.DateTimePicker
   Friend WithEvents cbPropietario As System.Windows.Forms.ComboBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents chkFinalizados As System.Windows.Forms.CheckBox
   Friend WithEvents chkActivos As System.Windows.Forms.CheckBox
   Friend WithEvents optInicio As System.Windows.Forms.RadioButton
   Friend WithEvents cmdAceptar As System.Windows.Forms.Button
   Friend WithEvents cmdCerrar As System.Windows.Forms.Button
   Friend WithEvents optFinal As System.Windows.Forms.RadioButton
   Friend WithEvents chkAnulados As System.Windows.Forms.CheckBox
   Friend WithEvents chkTodas As System.Windows.Forms.CheckBox
   Friend WithEvents chkNoAct As CheckBox
End Class
