<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmVentasAMProd
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
      Me.tbBuscar = New System.Windows.Forms.TextBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.cboRubro = New System.Windows.Forms.ComboBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.DataGridView1 = New System.Windows.Forms.DataGridView()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.tbCodigo = New System.Windows.Forms.TextBox()
      Me.tbDescrip = New System.Windows.Forms.TextBox()
      Me.tbImpInt = New System.Windows.Forms.TextBox()
      Me.tbPartida = New System.Windows.Forms.TextBox()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.tbPrUnit = New System.Windows.Forms.TextBox()
      Me.Label7 = New System.Windows.Forms.Label()
      Me.tbCantidad = New System.Windows.Forms.TextBox()
      Me.Label8 = New System.Windows.Forms.Label()
      Me.tbBonif = New System.Windows.Forms.TextBox()
      Me.Label10 = New System.Windows.Forms.Label()
      Me.btnAltaProd = New System.Windows.Forms.Button()
      Me.btnAceptar = New System.Windows.Forms.Button()
      Me.btnCancelar = New System.Windows.Forms.Button()
      Me.tbSubtotal = New System.Windows.Forms.TextBox()
      Me.Label11 = New System.Windows.Forms.Label()
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.tbPrecioFin = New System.Windows.Forms.TextBox()
      Me.Label9 = New System.Windows.Forms.Label()
      Me.tbPrecio = New System.Windows.Forms.TextBox()
      Me.lblPrecio = New System.Windows.Forms.Label()
      Me.tbPrecioFbon = New System.Windows.Forms.TextBox()
      Me.Label12 = New System.Windows.Forms.Label()
      Me.Label29 = New System.Windows.Forms.Label()
      Me.cboSucursal = New System.Windows.Forms.ComboBox()
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.Panel1.SuspendLayout()
      Me.SuspendLayout()
      '
      'tbBuscar
      '
      Me.tbBuscar.Location = New System.Drawing.Point(58, 9)
      Me.tbBuscar.Name = "tbBuscar"
      Me.tbBuscar.Size = New System.Drawing.Size(386, 20)
      Me.tbBuscar.TabIndex = 3
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(9, 12)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(43, 13)
      Me.Label1.TabIndex = 4
      Me.Label1.Text = "Buscar:"
      '
      'cboRubro
      '
      Me.cboRubro.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      Me.cboRubro.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.cboRubro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboRubro.FormattingEnabled = True
      Me.cboRubro.Location = New System.Drawing.Point(192, 37)
      Me.cboRubro.Name = "cboRubro"
      Me.cboRubro.Size = New System.Drawing.Size(437, 21)
      Me.cboRubro.TabIndex = 5
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(147, 42)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(39, 13)
      Me.Label2.TabIndex = 6
      Me.Label2.Text = "Rubro:"
      '
      'DataGridView1
      '
      Me.DataGridView1.AllowUserToAddRows = False
      Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.DataGridView1.Location = New System.Drawing.Point(12, 66)
      Me.DataGridView1.Name = "DataGridView1"
      Me.DataGridView1.ReadOnly = True
      Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.DataGridView1.Size = New System.Drawing.Size(776, 337)
      Me.DataGridView1.TabIndex = 8
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(12, 443)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(43, 13)
      Me.Label3.TabIndex = 9
      Me.Label3.Text = "Código:"
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(11, 417)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(49, 13)
      Me.Label4.TabIndex = 10
      Me.Label4.Text = "Descrip.:"
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.Location = New System.Drawing.Point(9, 472)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(51, 13)
      Me.Label5.TabIndex = 11
      Me.Label5.Text = "Imp.Int. $"
      '
      'tbCodigo
      '
      Me.tbCodigo.Enabled = False
      Me.tbCodigo.Location = New System.Drawing.Point(58, 439)
      Me.tbCodigo.Name = "tbCodigo"
      Me.tbCodigo.Size = New System.Drawing.Size(193, 20)
      Me.tbCodigo.TabIndex = 15
      '
      'tbDescrip
      '
      Me.tbDescrip.Enabled = False
      Me.tbDescrip.Location = New System.Drawing.Point(58, 412)
      Me.tbDescrip.Name = "tbDescrip"
      Me.tbDescrip.Size = New System.Drawing.Size(386, 20)
      Me.tbDescrip.TabIndex = 13
      '
      'tbImpInt
      '
      Me.tbImpInt.Enabled = False
      Me.tbImpInt.Location = New System.Drawing.Point(69, 469)
      Me.tbImpInt.Name = "tbImpInt"
      Me.tbImpInt.Size = New System.Drawing.Size(97, 20)
      Me.tbImpInt.TabIndex = 19
      '
      'tbPartida
      '
      Me.tbPartida.Enabled = False
      Me.tbPartida.Location = New System.Drawing.Point(221, 469)
      Me.tbPartida.Name = "tbPartida"
      Me.tbPartida.Size = New System.Drawing.Size(97, 20)
      Me.tbPartida.TabIndex = 20
      '
      'Label6
      '
      Me.Label6.AutoSize = True
      Me.Label6.Location = New System.Drawing.Point(172, 472)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(43, 13)
      Me.Label6.TabIndex = 15
      Me.Label6.Text = "Partida:"
      '
      'tbPrUnit
      '
      Me.tbPrUnit.BackColor = System.Drawing.SystemColors.Info
      Me.tbPrUnit.Enabled = False
      Me.tbPrUnit.Location = New System.Drawing.Point(485, 473)
      Me.tbPrUnit.Name = "tbPrUnit"
      Me.tbPrUnit.Size = New System.Drawing.Size(97, 20)
      Me.tbPrUnit.TabIndex = 21
      '
      'Label7
      '
      Me.Label7.AutoSize = True
      Me.Label7.Location = New System.Drawing.Point(416, 476)
      Me.Label7.Name = "Label7"
      Me.Label7.Size = New System.Drawing.Size(48, 13)
      Me.Label7.TabIndex = 17
      Me.Label7.Text = "Pr.Unit.$"
      '
      'tbCantidad
      '
      Me.tbCantidad.Location = New System.Drawing.Point(688, 414)
      Me.tbCantidad.Name = "tbCantidad"
      Me.tbCantidad.Size = New System.Drawing.Size(97, 20)
      Me.tbCantidad.TabIndex = 14
      '
      'Label8
      '
      Me.Label8.AutoSize = True
      Me.Label8.Location = New System.Drawing.Point(623, 417)
      Me.Label8.Name = "Label8"
      Me.Label8.Size = New System.Drawing.Size(59, 13)
      Me.Label8.TabIndex = 19
      Me.Label8.Text = "Cantidad #"
      '
      'tbBonif
      '
      Me.tbBonif.Location = New System.Drawing.Point(470, 3)
      Me.tbBonif.MaxLength = 0
      Me.tbBonif.Name = "tbBonif"
      Me.tbBonif.Size = New System.Drawing.Size(58, 20)
      Me.tbBonif.TabIndex = 18
      '
      'Label10
      '
      Me.Label10.AutoSize = True
      Me.Label10.Location = New System.Drawing.Point(422, 6)
      Me.Label10.Name = "Label10"
      Me.Label10.Size = New System.Drawing.Size(42, 13)
      Me.Label10.TabIndex = 25
      Me.Label10.Text = "Bonif.%"
      '
      'btnAltaProd
      '
      Me.btnAltaProd.Location = New System.Drawing.Point(12, 37)
      Me.btnAltaProd.Name = "btnAltaProd"
      Me.btnAltaProd.Size = New System.Drawing.Size(119, 23)
      Me.btnAltaProd.TabIndex = 27
      Me.btnAltaProd.Text = "Agr.Producto"
      Me.btnAltaProd.UseVisualStyleBackColor = True
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(625, 499)
      Me.btnAceptar.Name = "btnAceptar"
      Me.btnAceptar.Size = New System.Drawing.Size(79, 24)
      Me.btnAceptar.TabIndex = 28
      Me.btnAceptar.Text = "&Aceptar"
      Me.btnAceptar.UseVisualStyleBackColor = True
      '
      'btnCancelar
      '
      Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancelar.Location = New System.Drawing.Point(710, 499)
      Me.btnCancelar.Name = "btnCancelar"
      Me.btnCancelar.Size = New System.Drawing.Size(75, 24)
      Me.btnCancelar.TabIndex = 29
      Me.btnCancelar.Text = "&Cerrar"
      Me.btnCancelar.UseVisualStyleBackColor = True
      '
      'tbSubtotal
      '
      Me.tbSubtotal.BackColor = System.Drawing.SystemColors.Info
      Me.tbSubtotal.Enabled = False
      Me.tbSubtotal.Location = New System.Drawing.Point(688, 469)
      Me.tbSubtotal.Name = "tbSubtotal"
      Me.tbSubtotal.Size = New System.Drawing.Size(97, 20)
      Me.tbSubtotal.TabIndex = 22
      '
      'Label11
      '
      Me.Label11.AutoSize = True
      Me.Label11.Location = New System.Drawing.Point(627, 472)
      Me.Label11.Name = "Label11"
      Me.Label11.Size = New System.Drawing.Size(55, 13)
      Me.Label11.TabIndex = 30
      Me.Label11.Text = "Subtotal $"
      '
      'Panel1
      '
      Me.Panel1.Controls.Add(Me.tbPrecioFin)
      Me.Panel1.Controls.Add(Me.Label9)
      Me.Panel1.Controls.Add(Me.tbPrecio)
      Me.Panel1.Controls.Add(Me.lblPrecio)
      Me.Panel1.Controls.Add(Me.tbBonif)
      Me.Panel1.Controls.Add(Me.Label10)
      Me.Panel1.Location = New System.Drawing.Point(257, 438)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(537, 29)
      Me.Panel1.TabIndex = 32
      '
      'tbPrecioFin
      '
      Me.tbPrecioFin.BackColor = System.Drawing.SystemColors.Window
      Me.tbPrecioFin.Enabled = False
      Me.tbPrecioFin.Location = New System.Drawing.Point(319, 3)
      Me.tbPrecioFin.Name = "tbPrecioFin"
      Me.tbPrecioFin.Size = New System.Drawing.Size(97, 20)
      Me.tbPrecioFin.TabIndex = 17
      '
      'Label9
      '
      Me.Label9.AutoSize = True
      Me.Label9.Location = New System.Drawing.Point(275, 6)
      Me.Label9.Name = "Label9"
      Me.Label9.Size = New System.Drawing.Size(38, 13)
      Me.Label9.TabIndex = 31
      Me.Label9.Text = "Final $"
      '
      'tbPrecio
      '
      Me.tbPrecio.Location = New System.Drawing.Point(162, 3)
      Me.tbPrecio.Name = "tbPrecio"
      Me.tbPrecio.Size = New System.Drawing.Size(97, 20)
      Me.tbPrecio.TabIndex = 16
      '
      'lblPrecio
      '
      Me.lblPrecio.AutoSize = True
      Me.lblPrecio.Location = New System.Drawing.Point(84, 6)
      Me.lblPrecio.Name = "lblPrecio"
      Me.lblPrecio.Size = New System.Drawing.Size(72, 13)
      Me.lblPrecio.TabIndex = 25
      Me.lblPrecio.Text = "Precio Neto $"
      '
      'tbPrecioFbon
      '
      Me.tbPrecioFbon.BackColor = System.Drawing.SystemColors.Info
      Me.tbPrecioFbon.Enabled = False
      Me.tbPrecioFbon.Location = New System.Drawing.Point(485, 499)
      Me.tbPrecioFbon.Name = "tbPrecioFbon"
      Me.tbPrecioFbon.Size = New System.Drawing.Size(97, 20)
      Me.tbPrecioFbon.TabIndex = 23
      '
      'Label12
      '
      Me.Label12.AutoSize = True
      Me.Label12.Location = New System.Drawing.Point(426, 505)
      Me.Label12.Name = "Label12"
      Me.Label12.Size = New System.Drawing.Size(38, 13)
      Me.Label12.TabIndex = 29
      Me.Label12.Text = "Final $"
      '
      'Label29
      '
      Me.Label29.AutoSize = True
      Me.Label29.Location = New System.Drawing.Point(457, 12)
      Me.Label29.Name = "Label29"
      Me.Label29.Size = New System.Drawing.Size(51, 13)
      Me.Label29.TabIndex = 131
      Me.Label29.Text = "Sucursal:"
      '
      'cboSucursal
      '
      Me.cboSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboSucursal.FormattingEnabled = True
      Me.cboSucursal.Location = New System.Drawing.Point(515, 9)
      Me.cboSucursal.Name = "cboSucursal"
      Me.cboSucursal.Size = New System.Drawing.Size(273, 21)
      Me.cboSucursal.TabIndex = 130
      '
      'FrmVentasAMProd
      '
      Me.AcceptButton = Me.btnAceptar
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me.btnCancelar
      Me.ClientSize = New System.Drawing.Size(797, 529)
      Me.Controls.Add(Me.tbPrecioFbon)
      Me.Controls.Add(Me.Label12)
      Me.Controls.Add(Me.Label29)
      Me.Controls.Add(Me.cboSucursal)
      Me.Controls.Add(Me.Panel1)
      Me.Controls.Add(Me.tbSubtotal)
      Me.Controls.Add(Me.Label11)
      Me.Controls.Add(Me.btnCancelar)
      Me.Controls.Add(Me.btnAceptar)
      Me.Controls.Add(Me.btnAltaProd)
      Me.Controls.Add(Me.tbCantidad)
      Me.Controls.Add(Me.Label8)
      Me.Controls.Add(Me.tbPrUnit)
      Me.Controls.Add(Me.Label7)
      Me.Controls.Add(Me.tbPartida)
      Me.Controls.Add(Me.Label6)
      Me.Controls.Add(Me.tbImpInt)
      Me.Controls.Add(Me.tbDescrip)
      Me.Controls.Add(Me.tbCodigo)
      Me.Controls.Add(Me.Label5)
      Me.Controls.Add(Me.Label4)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.DataGridView1)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.cboRubro)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.tbBuscar)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "FrmVentasAMProd"
      Me.Text = "Seleccionar Producto"
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.Panel1.ResumeLayout(False)
      Me.Panel1.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents tbBuscar As System.Windows.Forms.TextBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents cboRubro As System.Windows.Forms.ComboBox
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents tbCodigo As System.Windows.Forms.TextBox
   Friend WithEvents tbDescrip As System.Windows.Forms.TextBox
   Friend WithEvents tbImpInt As System.Windows.Forms.TextBox
   Friend WithEvents tbPartida As System.Windows.Forms.TextBox
   Friend WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents tbPrUnit As System.Windows.Forms.TextBox
   Friend WithEvents Label7 As System.Windows.Forms.Label
   Friend WithEvents tbCantidad As System.Windows.Forms.TextBox
   Friend WithEvents Label8 As System.Windows.Forms.Label
   Friend WithEvents tbBonif As System.Windows.Forms.TextBox
   Friend WithEvents Label10 As System.Windows.Forms.Label
   Friend WithEvents btnAltaProd As System.Windows.Forms.Button
   Friend WithEvents btnAceptar As System.Windows.Forms.Button
   Friend WithEvents btnCancelar As System.Windows.Forms.Button
   Friend WithEvents tbSubtotal As System.Windows.Forms.TextBox
   Friend WithEvents Label11 As System.Windows.Forms.Label
   Friend WithEvents Panel1 As System.Windows.Forms.Panel
   Friend WithEvents tbPrecio As System.Windows.Forms.TextBox
   Friend WithEvents lblPrecio As System.Windows.Forms.Label
   Friend WithEvents Label29 As System.Windows.Forms.Label
   Friend WithEvents cboSucursal As System.Windows.Forms.ComboBox
   Friend WithEvents tbPrecioFbon As TextBox
   Friend WithEvents Label12 As Label
   Friend WithEvents tbPrecioFin As TextBox
   Friend WithEvents Label9 As Label
End Class
