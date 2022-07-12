<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGarantes
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
      Me.DataGridView1 = New System.Windows.Forms.DataGridView()
      Me.cmdBaja = New System.Windows.Forms.Button()
      Me.cmdEditar = New System.Windows.Forms.Button()
      Me.cmdAlta = New System.Windows.Forms.Button()
      Me.cmdSalir = New System.Windows.Forms.Button()
      Me.tbBuscar = New System.Windows.Forms.TextBox()
      Me.lblDNI = New System.Windows.Forms.Label()
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
      Me.DataGridView1.Location = New System.Drawing.Point(12, 38)
      Me.DataGridView1.Name = "DataGridView1"
      Me.DataGridView1.ReadOnly = True
      Me.DataGridView1.RowTemplate.ReadOnly = True
      Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.DataGridView1.Size = New System.Drawing.Size(742, 437)
      Me.DataGridView1.TabIndex = 96
      '
      'cmdBaja
      '
      Me.cmdBaja.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdBaja.Enabled = False
      Me.cmdBaja.Location = New System.Drawing.Point(83, 481)
      Me.cmdBaja.Name = "cmdBaja"
      Me.cmdBaja.Size = New System.Drawing.Size(65, 27)
      Me.cmdBaja.TabIndex = 104
      Me.cmdBaja.Text = "&Eliminar"
      Me.cmdBaja.UseVisualStyleBackColor = True
      '
      'cmdEditar
      '
      Me.cmdEditar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdEditar.Enabled = False
      Me.cmdEditar.Location = New System.Drawing.Point(154, 481)
      Me.cmdEditar.Name = "cmdEditar"
      Me.cmdEditar.Size = New System.Drawing.Size(65, 27)
      Me.cmdEditar.TabIndex = 105
      Me.cmdEditar.Text = "&Modificar"
      Me.cmdEditar.UseVisualStyleBackColor = True
      '
      'cmdAlta
      '
      Me.cmdAlta.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdAlta.Enabled = False
      Me.cmdAlta.Location = New System.Drawing.Point(12, 481)
      Me.cmdAlta.Name = "cmdAlta"
      Me.cmdAlta.Size = New System.Drawing.Size(65, 27)
      Me.cmdAlta.TabIndex = 103
      Me.cmdAlta.Text = "A&gregar"
      Me.cmdAlta.UseVisualStyleBackColor = True
      '
      'cmdSalir
      '
      Me.cmdSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdSalir.Location = New System.Drawing.Point(678, 481)
      Me.cmdSalir.Name = "cmdSalir"
      Me.cmdSalir.Size = New System.Drawing.Size(76, 27)
      Me.cmdSalir.TabIndex = 108
      Me.cmdSalir.Text = "&Salir"
      Me.cmdSalir.UseVisualStyleBackColor = True
      '
      'tbBuscar
      '
      Me.tbBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.tbBuscar.Location = New System.Drawing.Point(126, 12)
      Me.tbBuscar.MaxLength = 50
      Me.tbBuscar.Name = "tbBuscar"
      Me.tbBuscar.Size = New System.Drawing.Size(176, 20)
      Me.tbBuscar.TabIndex = 110
      '
      'lblDNI
      '
      Me.lblDNI.AutoSize = True
      Me.lblDNI.Location = New System.Drawing.Point(77, 15)
      Me.lblDNI.Name = "lblDNI"
      Me.lblDNI.Size = New System.Drawing.Size(43, 13)
      Me.lblDNI.TabIndex = 109
      Me.lblDNI.Text = "Buscar:"
      '
      'frmGarantes
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(757, 511)
      Me.Controls.Add(Me.tbBuscar)
      Me.Controls.Add(Me.lblDNI)
      Me.Controls.Add(Me.cmdSalir)
      Me.Controls.Add(Me.cmdBaja)
      Me.Controls.Add(Me.cmdEditar)
      Me.Controls.Add(Me.cmdAlta)
      Me.Controls.Add(Me.DataGridView1)
      Me.KeyPreview = True
      Me.Name = "frmGarantes"
      Me.Text = "Garantes"
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
   Friend WithEvents cmdBaja As System.Windows.Forms.Button
   Friend WithEvents cmdEditar As System.Windows.Forms.Button
   Friend WithEvents cmdAlta As System.Windows.Forms.Button
   Friend WithEvents cmdSalir As System.Windows.Forms.Button
   Friend WithEvents tbBuscar As System.Windows.Forms.TextBox
   Friend WithEvents lblDNI As System.Windows.Forms.Label
End Class
