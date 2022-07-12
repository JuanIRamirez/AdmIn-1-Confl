<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListAdelPropSdo
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
      Me.Label4 = New System.Windows.Forms.Label()
      Me.dtpDesde = New System.Windows.Forms.DateTimePicker()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.dtpHasta = New System.Windows.Forms.DateTimePicker()
      Me.chkTodas = New System.Windows.Forms.CheckBox()
      Me.optDet = New System.Windows.Forms.RadioButton()
      Me.optRes = New System.Windows.Forms.RadioButton()
      Me.btnCancelar = New System.Windows.Forms.Button()
      Me.btnAceptar = New System.Windows.Forms.Button()
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.Panel2 = New System.Windows.Forms.Panel()
      Me.optNoRec = New System.Windows.Forms.RadioButton()
      Me.optTodos = New System.Windows.Forms.RadioButton()
      Me.Panel1.SuspendLayout()
      Me.Panel2.SuspendLayout()
      Me.SuspendLayout()
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(23, 105)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(41, 13)
      Me.Label4.TabIndex = 95
      Me.Label4.Text = "Desde:"
      '
      'dtpDesde
      '
      Me.dtpDesde.Enabled = False
      Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDesde.Location = New System.Drawing.Point(69, 102)
      Me.dtpDesde.Name = "dtpDesde"
      Me.dtpDesde.Size = New System.Drawing.Size(94, 20)
      Me.dtpDesde.TabIndex = 2
      Me.dtpDesde.Value = New Date(2015, 9, 24, 0, 0, 0, 0)
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(23, 143)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(38, 13)
      Me.Label1.TabIndex = 97
      Me.Label1.Text = "Hasta:"
      '
      'dtpHasta
      '
      Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpHasta.Location = New System.Drawing.Point(69, 140)
      Me.dtpHasta.Name = "dtpHasta"
      Me.dtpHasta.Size = New System.Drawing.Size(94, 20)
      Me.dtpHasta.TabIndex = 4
      Me.dtpHasta.Value = New Date(2015, 9, 24, 0, 0, 0, 0)
      '
      'chkTodas
      '
      Me.chkTodas.AutoSize = True
      Me.chkTodas.Enabled = False
      Me.chkTodas.Location = New System.Drawing.Point(223, 104)
      Me.chkTodas.Name = "chkTodas"
      Me.chkTodas.Size = New System.Drawing.Size(107, 17)
      Me.chkTodas.TabIndex = 3
      Me.chkTodas.Text = "&Todas las fechas"
      Me.chkTodas.UseVisualStyleBackColor = True
      '
      'optDet
      '
      Me.optDet.AutoSize = True
      Me.optDet.Location = New System.Drawing.Point(133, 23)
      Me.optDet.Name = "optDet"
      Me.optDet.Size = New System.Drawing.Size(70, 17)
      Me.optDet.TabIndex = 6
      Me.optDet.Text = "&Detallado"
      Me.optDet.UseVisualStyleBackColor = True
      '
      'optRes
      '
      Me.optRes.AutoSize = True
      Me.optRes.Checked = True
      Me.optRes.Location = New System.Drawing.Point(21, 23)
      Me.optRes.Name = "optRes"
      Me.optRes.Size = New System.Drawing.Size(72, 17)
      Me.optRes.TabIndex = 5
      Me.optRes.TabStop = True
      Me.optRes.Text = "&Resumido"
      Me.optRes.UseVisualStyleBackColor = True
      '
      'btnCancelar
      '
      Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnCancelar.Location = New System.Drawing.Point(397, 285)
      Me.btnCancelar.Name = "btnCancelar"
      Me.btnCancelar.Size = New System.Drawing.Size(63, 27)
      Me.btnCancelar.TabIndex = 8
      Me.btnCancelar.Text = "&Cancelar"
      Me.btnCancelar.UseVisualStyleBackColor = True
      '
      'btnAceptar
      '
      Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnAceptar.Location = New System.Drawing.Point(302, 285)
      Me.btnAceptar.Name = "btnAceptar"
      Me.btnAceptar.Size = New System.Drawing.Size(89, 27)
      Me.btnAceptar.TabIndex = 7
      Me.btnAceptar.Text = "&Aceptar"
      Me.btnAceptar.UseVisualStyleBackColor = True
      '
      'Panel1
      '
      Me.Panel1.Controls.Add(Me.optRes)
      Me.Panel1.Controls.Add(Me.optDet)
      Me.Panel1.Location = New System.Drawing.Point(26, 193)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(304, 64)
      Me.Panel1.TabIndex = 98
      '
      'Panel2
      '
      Me.Panel2.Controls.Add(Me.optNoRec)
      Me.Panel2.Controls.Add(Me.optTodos)
      Me.Panel2.Location = New System.Drawing.Point(26, 12)
      Me.Panel2.Name = "Panel2"
      Me.Panel2.Size = New System.Drawing.Size(304, 61)
      Me.Panel2.TabIndex = 0
      '
      'optNoRec
      '
      Me.optNoRec.AutoSize = True
      Me.optNoRec.Checked = True
      Me.optNoRec.Location = New System.Drawing.Point(21, 26)
      Me.optNoRec.Name = "optNoRec"
      Me.optNoRec.Size = New System.Drawing.Size(106, 17)
      Me.optNoRec.TabIndex = 0
      Me.optNoRec.TabStop = True
      Me.optNoRec.Text = "&No Recuperados"
      Me.optNoRec.UseVisualStyleBackColor = True
      '
      'optTodos
      '
      Me.optTodos.AutoSize = True
      Me.optTodos.Location = New System.Drawing.Point(133, 26)
      Me.optTodos.Name = "optTodos"
      Me.optTodos.Size = New System.Drawing.Size(55, 17)
      Me.optTodos.TabIndex = 1
      Me.optTodos.Text = "&Todos"
      Me.optTodos.UseVisualStyleBackColor = True
      '
      'frmListAdelPropSdo
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(471, 324)
      Me.Controls.Add(Me.Panel2)
      Me.Controls.Add(Me.Panel1)
      Me.Controls.Add(Me.btnCancelar)
      Me.Controls.Add(Me.btnAceptar)
      Me.Controls.Add(Me.chkTodas)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.dtpHasta)
      Me.Controls.Add(Me.Label4)
      Me.Controls.Add(Me.dtpDesde)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.MaximizeBox = False
      Me.Name = "frmListAdelPropSdo"
      Me.Text = "Listado Adelantos a Propietarios"
      Me.Panel1.ResumeLayout(False)
      Me.Panel1.PerformLayout()
      Me.Panel2.ResumeLayout(False)
      Me.Panel2.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents dtpDesde As System.Windows.Forms.DateTimePicker
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents dtpHasta As System.Windows.Forms.DateTimePicker
   Friend WithEvents chkTodas As System.Windows.Forms.CheckBox
   Friend WithEvents optDet As System.Windows.Forms.RadioButton
   Friend WithEvents optRes As System.Windows.Forms.RadioButton
   Friend WithEvents btnCancelar As System.Windows.Forms.Button
   Friend WithEvents btnAceptar As System.Windows.Forms.Button
   Friend WithEvents Panel1 As System.Windows.Forms.Panel
   Friend WithEvents Panel2 As System.Windows.Forms.Panel
   Friend WithEvents optNoRec As System.Windows.Forms.RadioButton
   Friend WithEvents optTodos As System.Windows.Forms.RadioButton
End Class
