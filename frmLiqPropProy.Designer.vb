<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLiqPropProy
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
      Me.Label1 = New System.Windows.Forms.Label()
      Me.txtPropietario = New System.Windows.Forms.TextBox()
      Me.tbPropiedad = New System.Windows.Forms.TextBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.txtPeriodo = New System.Windows.Forms.TextBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.DataGridView1 = New System.Windows.Forms.DataGridView()
      Me.txtTotAlq = New System.Windows.Forms.TextBox()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.txtTotOtr = New System.Windows.Forms.TextBox()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.txtTotDes = New System.Windows.Forms.TextBox()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.txtTotal = New System.Windows.Forms.TextBox()
      Me.Label7 = New System.Windows.Forms.Label()
      Me.cmdCerrar = New System.Windows.Forms.Button()
      Me.cmdSeleccionar = New System.Windows.Forms.Button()
      Me.tbTotBon = New System.Windows.Forms.TextBox()
      Me.Label8 = New System.Windows.Forms.Label()
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(12, 9)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(60, 13)
      Me.Label1.TabIndex = 0
      Me.Label1.Text = "Propietario:"
      '
      'txtPropietario
      '
      Me.txtPropietario.Enabled = False
      Me.txtPropietario.Location = New System.Drawing.Point(78, 6)
      Me.txtPropietario.Name = "txtPropietario"
      Me.txtPropietario.Size = New System.Drawing.Size(420, 20)
      Me.txtPropietario.TabIndex = 1
      '
      'tbPropiedad
      '
      Me.tbPropiedad.Enabled = False
      Me.tbPropiedad.Location = New System.Drawing.Point(78, 32)
      Me.tbPropiedad.Name = "tbPropiedad"
      Me.tbPropiedad.Size = New System.Drawing.Size(420, 20)
      Me.tbPropiedad.TabIndex = 3
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(12, 35)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(58, 13)
      Me.Label2.TabIndex = 2
      Me.Label2.Text = "Propiedad:"
      '
      'txtPeriodo
      '
      Me.txtPeriodo.Enabled = False
      Me.txtPeriodo.Location = New System.Drawing.Point(593, 32)
      Me.txtPeriodo.Name = "txtPeriodo"
      Me.txtPeriodo.Size = New System.Drawing.Size(87, 20)
      Me.txtPeriodo.TabIndex = 5
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(539, 35)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(48, 13)
      Me.Label3.TabIndex = 4
      Me.Label3.Text = "Período:"
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
      Me.DataGridView1.Location = New System.Drawing.Point(15, 58)
      Me.DataGridView1.Name = "DataGridView1"
      Me.DataGridView1.ReadOnly = True
      Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.DataGridView1.Size = New System.Drawing.Size(665, 317)
      Me.DataGridView1.TabIndex = 37
      '
      'txtTotAlq
      '
      Me.txtTotAlq.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.txtTotAlq.Enabled = False
      Me.txtTotAlq.Location = New System.Drawing.Point(15, 401)
      Me.txtTotAlq.Name = "txtTotAlq"
      Me.txtTotAlq.Size = New System.Drawing.Size(87, 20)
      Me.txtTotAlq.TabIndex = 39
      '
      'Label4
      '
      Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(12, 385)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(61, 13)
      Me.Label4.TabIndex = 38
      Me.Label4.Text = "Alquileres $"
      '
      'txtTotOtr
      '
      Me.txtTotOtr.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.txtTotOtr.Enabled = False
      Me.txtTotOtr.Location = New System.Drawing.Point(207, 401)
      Me.txtTotOtr.Name = "txtTotOtr"
      Me.txtTotOtr.Size = New System.Drawing.Size(87, 20)
      Me.txtTotOtr.TabIndex = 41
      '
      'Label5
      '
      Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.Label5.AutoSize = True
      Me.Label5.Location = New System.Drawing.Point(204, 385)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(41, 13)
      Me.Label5.TabIndex = 40
      Me.Label5.Text = "Otros $"
      '
      'txtTotDes
      '
      Me.txtTotDes.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.txtTotDes.Enabled = False
      Me.txtTotDes.Location = New System.Drawing.Point(300, 401)
      Me.txtTotDes.Name = "txtTotDes"
      Me.txtTotDes.Size = New System.Drawing.Size(87, 20)
      Me.txtTotDes.TabIndex = 43
      '
      'Label6
      '
      Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.Label6.AutoSize = True
      Me.Label6.Location = New System.Drawing.Point(297, 385)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(73, 13)
      Me.Label6.TabIndex = 42
      Me.Label6.Text = "Descuentos $"
      '
      'txtTotal
      '
      Me.txtTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.txtTotal.Enabled = False
      Me.txtTotal.Location = New System.Drawing.Point(393, 401)
      Me.txtTotal.Name = "txtTotal"
      Me.txtTotal.Size = New System.Drawing.Size(87, 20)
      Me.txtTotal.TabIndex = 45
      '
      'Label7
      '
      Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.Label7.AutoSize = True
      Me.Label7.Location = New System.Drawing.Point(390, 385)
      Me.Label7.Name = "Label7"
      Me.Label7.Size = New System.Drawing.Size(40, 13)
      Me.Label7.TabIndex = 44
      Me.Label7.Text = "Total $"
      '
      'cmdCerrar
      '
      Me.cmdCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdCerrar.Location = New System.Drawing.Point(605, 401)
      Me.cmdCerrar.Name = "cmdCerrar"
      Me.cmdCerrar.Size = New System.Drawing.Size(75, 23)
      Me.cmdCerrar.TabIndex = 46
      Me.cmdCerrar.Text = "&Cerrar"
      Me.cmdCerrar.UseVisualStyleBackColor = True
      '
      'cmdSeleccionar
      '
      Me.cmdSeleccionar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdSeleccionar.Location = New System.Drawing.Point(524, 401)
      Me.cmdSeleccionar.Name = "cmdSeleccionar"
      Me.cmdSeleccionar.Size = New System.Drawing.Size(75, 23)
      Me.cmdSeleccionar.TabIndex = 47
      Me.cmdSeleccionar.Text = "&Seleccionar"
      Me.cmdSeleccionar.UseVisualStyleBackColor = True
      '
      'tbTotBon
      '
      Me.tbTotBon.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.tbTotBon.Enabled = False
      Me.tbTotBon.Location = New System.Drawing.Point(108, 401)
      Me.tbTotBon.Name = "tbTotBon"
      Me.tbTotBon.Size = New System.Drawing.Size(87, 20)
      Me.tbTotBon.TabIndex = 49
      '
      'Label8
      '
      Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.Label8.AutoSize = True
      Me.Label8.Location = New System.Drawing.Point(105, 385)
      Me.Label8.Name = "Label8"
      Me.Label8.Size = New System.Drawing.Size(61, 13)
      Me.Label8.TabIndex = 48
      Me.Label8.Text = "Bonif.Alq. $"
      '
      'frmLiqPropProy
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(692, 433)
      Me.Controls.Add(Me.tbTotBon)
      Me.Controls.Add(Me.Label8)
      Me.Controls.Add(Me.cmdSeleccionar)
      Me.Controls.Add(Me.cmdCerrar)
      Me.Controls.Add(Me.txtTotal)
      Me.Controls.Add(Me.Label7)
      Me.Controls.Add(Me.txtTotDes)
      Me.Controls.Add(Me.Label6)
      Me.Controls.Add(Me.txtTotOtr)
      Me.Controls.Add(Me.Label5)
      Me.Controls.Add(Me.txtTotAlq)
      Me.Controls.Add(Me.Label4)
      Me.Controls.Add(Me.DataGridView1)
      Me.Controls.Add(Me.txtPeriodo)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.tbPropiedad)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.txtPropietario)
      Me.Controls.Add(Me.Label1)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "frmLiqPropProy"
      Me.Text = "Liquidación Propietario: Proyección"
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents txtPropietario As System.Windows.Forms.TextBox
   Friend WithEvents tbPropiedad As System.Windows.Forms.TextBox
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents txtPeriodo As System.Windows.Forms.TextBox
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
   Friend WithEvents txtTotAlq As System.Windows.Forms.TextBox
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents txtTotOtr As System.Windows.Forms.TextBox
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents txtTotDes As System.Windows.Forms.TextBox
   Friend WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents txtTotal As System.Windows.Forms.TextBox
   Friend WithEvents Label7 As System.Windows.Forms.Label
   Friend WithEvents cmdCerrar As System.Windows.Forms.Button
   Friend WithEvents cmdSeleccionar As System.Windows.Forms.Button
   Friend WithEvents tbTotBon As System.Windows.Forms.TextBox
   Friend WithEvents Label8 As System.Windows.Forms.Label
End Class
