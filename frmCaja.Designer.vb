<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCaja
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
      Me.Label2 = New System.Windows.Forms.Label()
      Me.cbCaja = New System.Windows.Forms.ComboBox()
      Me.chkTodas = New System.Windows.Forms.CheckBox()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.dtpDesde = New System.Windows.Forms.DateTimePicker()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.cbComprob = New System.Windows.Forms.ComboBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.cbUsuario = New System.Windows.Forms.ComboBox()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.tbDetalle = New System.Windows.Forms.TextBox()
      Me.tbImporte = New System.Windows.Forms.TextBox()
      Me.Label7 = New System.Windows.Forms.Label()
      Me.tbNumero = New System.Windows.Forms.TextBox()
      Me.Label8 = New System.Windows.Forms.Label()
      Me.DataGridView1 = New System.Windows.Forms.DataGridView()
      Me.cmdAlta = New System.Windows.Forms.Button()
      Me.cmdSalir = New System.Windows.Forms.Button()
      Me.cmdBaja = New System.Windows.Forms.Button()
      Me.cmdImprimir = New System.Windows.Forms.Button()
      Me.cmdEdicion = New System.Windows.Forms.Button()
      Me.cmdCajaRec = New System.Windows.Forms.Button()
      Me.cmdTransferir = New System.Windows.Forms.Button()
      Me.cmdListado = New System.Windows.Forms.Button()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.dtpHasta = New System.Windows.Forms.DateTimePicker()
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(10, 15)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(31, 13)
      Me.Label2.TabIndex = 76
      Me.Label2.Text = "Caja:"
      '
      'cbCaja
      '
      Me.cbCaja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbCaja.FormattingEnabled = True
      Me.cbCaja.Location = New System.Drawing.Point(47, 12)
      Me.cbCaja.Name = "cbCaja"
      Me.cbCaja.Size = New System.Drawing.Size(206, 21)
      Me.cbCaja.TabIndex = 0
      '
      'chkTodas
      '
      Me.chkTodas.AutoSize = True
      Me.chkTodas.Location = New System.Drawing.Point(310, 44)
      Me.chkTodas.Name = "chkTodas"
      Me.chkTodas.Size = New System.Drawing.Size(56, 17)
      Me.chkTodas.TabIndex = 5
      Me.chkTodas.Text = "&Todas"
      Me.chkTodas.UseVisualStyleBackColor = True
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(12, 45)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(40, 13)
      Me.Label4.TabIndex = 49
      Me.Label4.Text = "Fecha:"
      '
      'dtpDesde
      '
      Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDesde.Location = New System.Drawing.Point(58, 42)
      Me.dtpDesde.Name = "dtpDesde"
      Me.dtpDesde.Size = New System.Drawing.Size(80, 20)
      Me.dtpDesde.TabIndex = 4
      Me.dtpDesde.Value = New Date(2015, 9, 24, 0, 0, 0, 0)
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(259, 15)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(55, 13)
      Me.Label1.TabIndex = 79
      Me.Label1.Text = "Comprob.:"
      '
      'cbComprob
      '
      Me.cbComprob.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbComprob.FormattingEnabled = True
      Me.cbComprob.Location = New System.Drawing.Point(320, 12)
      Me.cbComprob.Name = "cbComprob"
      Me.cbComprob.Size = New System.Drawing.Size(206, 21)
      Me.cbComprob.TabIndex = 1
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(532, 15)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(46, 13)
      Me.Label3.TabIndex = 81
      Me.Label3.Text = "Usuario:"
      '
      'cbUsuario
      '
      Me.cbUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbUsuario.FormattingEnabled = True
      Me.cbUsuario.Location = New System.Drawing.Point(584, 12)
      Me.cbUsuario.Name = "cbUsuario"
      Me.cbUsuario.Size = New System.Drawing.Size(152, 21)
      Me.cbUsuario.TabIndex = 2
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.Location = New System.Drawing.Point(416, 46)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(69, 13)
      Me.Label5.TabIndex = 82
      Me.Label5.Text = "Det/Nombre:"
      '
      'tbDetalle
      '
      Me.tbDetalle.Location = New System.Drawing.Point(491, 43)
      Me.tbDetalle.Name = "tbDetalle"
      Me.tbDetalle.Size = New System.Drawing.Size(254, 20)
      Me.tbDetalle.TabIndex = 7
      '
      'tbImporte
      '
      Me.tbImporte.Location = New System.Drawing.Point(808, 12)
      Me.tbImporte.Name = "tbImporte"
      Me.tbImporte.Size = New System.Drawing.Size(86, 20)
      Me.tbImporte.TabIndex = 3
      '
      'Label7
      '
      Me.Label7.AutoSize = True
      Me.Label7.Location = New System.Drawing.Point(751, 15)
      Me.Label7.Name = "Label7"
      Me.Label7.Size = New System.Drawing.Size(51, 13)
      Me.Label7.TabIndex = 86
      Me.Label7.Text = "Importe $"
      '
      'tbNumero
      '
      Me.tbNumero.Location = New System.Drawing.Point(808, 42)
      Me.tbNumero.Name = "tbNumero"
      Me.tbNumero.Size = New System.Drawing.Size(85, 20)
      Me.tbNumero.TabIndex = 8
      '
      'Label8
      '
      Me.Label8.AutoSize = True
      Me.Label8.Location = New System.Drawing.Point(755, 45)
      Me.Label8.Name = "Label8"
      Me.Label8.Size = New System.Drawing.Size(47, 13)
      Me.Label8.TabIndex = 88
      Me.Label8.Text = "Número:"
      '
      'DataGridView1
      '
      Me.DataGridView1.AllowUserToAddRows = False
      Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
      Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.DataGridView1.Location = New System.Drawing.Point(11, 70)
      Me.DataGridView1.Name = "DataGridView1"
      Me.DataGridView1.ReadOnly = True
      Me.DataGridView1.RowTemplate.ReadOnly = True
      Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.DataGridView1.Size = New System.Drawing.Size(882, 437)
      Me.DataGridView1.TabIndex = 90
      '
      'cmdAlta
      '
      Me.cmdAlta.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdAlta.Location = New System.Drawing.Point(11, 514)
      Me.cmdAlta.Name = "cmdAlta"
      Me.cmdAlta.Size = New System.Drawing.Size(76, 27)
      Me.cmdAlta.TabIndex = 9
      Me.cmdAlta.Text = "&Alta"
      Me.cmdAlta.UseVisualStyleBackColor = True
      '
      'cmdSalir
      '
      Me.cmdSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdSalir.Location = New System.Drawing.Point(817, 514)
      Me.cmdSalir.Name = "cmdSalir"
      Me.cmdSalir.Size = New System.Drawing.Size(76, 27)
      Me.cmdSalir.TabIndex = 15
      Me.cmdSalir.Text = "&Salir"
      Me.cmdSalir.UseVisualStyleBackColor = True
      '
      'cmdBaja
      '
      Me.cmdBaja.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdBaja.Location = New System.Drawing.Point(93, 514)
      Me.cmdBaja.Name = "cmdBaja"
      Me.cmdBaja.Size = New System.Drawing.Size(76, 27)
      Me.cmdBaja.TabIndex = 10
      Me.cmdBaja.Text = "&Baja"
      Me.cmdBaja.UseVisualStyleBackColor = True
      '
      'cmdImprimir
      '
      Me.cmdImprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdImprimir.Location = New System.Drawing.Point(584, 514)
      Me.cmdImprimir.Name = "cmdImprimir"
      Me.cmdImprimir.Size = New System.Drawing.Size(76, 27)
      Me.cmdImprimir.TabIndex = 14
      Me.cmdImprimir.Text = "&Imprimir"
      Me.cmdImprimir.UseVisualStyleBackColor = True
      '
      'cmdEdicion
      '
      Me.cmdEdicion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdEdicion.Location = New System.Drawing.Point(175, 514)
      Me.cmdEdicion.Name = "cmdEdicion"
      Me.cmdEdicion.Size = New System.Drawing.Size(76, 27)
      Me.cmdEdicion.TabIndex = 11
      Me.cmdEdicion.Text = "&Modificar"
      Me.cmdEdicion.UseVisualStyleBackColor = True
      '
      'cmdCajaRec
      '
      Me.cmdCajaRec.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdCajaRec.Location = New System.Drawing.Point(329, 514)
      Me.cmdCajaRec.Name = "cmdCajaRec"
      Me.cmdCajaRec.Size = New System.Drawing.Size(106, 27)
      Me.cmdCajaRec.TabIndex = 12
      Me.cmdCajaRec.Text = "Caja a &Recuperar"
      Me.cmdCajaRec.UseVisualStyleBackColor = True
      '
      'cmdTransferir
      '
      Me.cmdTransferir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdTransferir.Location = New System.Drawing.Point(441, 514)
      Me.cmdTransferir.Name = "cmdTransferir"
      Me.cmdTransferir.Size = New System.Drawing.Size(76, 27)
      Me.cmdTransferir.TabIndex = 13
      Me.cmdTransferir.Text = "&Transferir"
      Me.cmdTransferir.UseVisualStyleBackColor = True
      '
      'cmdListado
      '
      Me.cmdListado.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdListado.Location = New System.Drawing.Point(666, 514)
      Me.cmdListado.Name = "cmdListado"
      Me.cmdListado.Size = New System.Drawing.Size(76, 27)
      Me.cmdListado.TabIndex = 91
      Me.cmdListado.Text = "&Listado"
      Me.cmdListado.UseVisualStyleBackColor = True
      '
      'Label6
      '
      Me.Label6.AutoSize = True
      Me.Label6.Location = New System.Drawing.Point(144, 45)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(38, 13)
      Me.Label6.TabIndex = 93
      Me.Label6.Text = "Hasta:"
      '
      'dtpHasta
      '
      Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpHasta.Location = New System.Drawing.Point(190, 42)
      Me.dtpHasta.Name = "dtpHasta"
      Me.dtpHasta.Size = New System.Drawing.Size(80, 20)
      Me.dtpHasta.TabIndex = 92
      Me.dtpHasta.Value = New Date(2015, 9, 24, 0, 0, 0, 0)
      '
      'frmCaja
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(905, 553)
      Me.Controls.Add(Me.Label6)
      Me.Controls.Add(Me.dtpHasta)
      Me.Controls.Add(Me.cmdListado)
      Me.Controls.Add(Me.cmdTransferir)
      Me.Controls.Add(Me.cmdCajaRec)
      Me.Controls.Add(Me.cmdEdicion)
      Me.Controls.Add(Me.cmdAlta)
      Me.Controls.Add(Me.cmdSalir)
      Me.Controls.Add(Me.cmdBaja)
      Me.Controls.Add(Me.cmdImprimir)
      Me.Controls.Add(Me.DataGridView1)
      Me.Controls.Add(Me.tbNumero)
      Me.Controls.Add(Me.Label8)
      Me.Controls.Add(Me.chkTodas)
      Me.Controls.Add(Me.tbImporte)
      Me.Controls.Add(Me.Label4)
      Me.Controls.Add(Me.dtpDesde)
      Me.Controls.Add(Me.Label7)
      Me.Controls.Add(Me.tbDetalle)
      Me.Controls.Add(Me.Label5)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.cbUsuario)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.cbComprob)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.cbCaja)
      Me.KeyPreview = True
      Me.Name = "frmCaja"
      Me.Text = "Caja"
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents cbCaja As System.Windows.Forms.ComboBox
   Friend WithEvents chkTodas As System.Windows.Forms.CheckBox
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents dtpDesde As System.Windows.Forms.DateTimePicker
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents cbComprob As System.Windows.Forms.ComboBox
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents cbUsuario As System.Windows.Forms.ComboBox
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents tbDetalle As System.Windows.Forms.TextBox
   Friend WithEvents tbImporte As System.Windows.Forms.TextBox
   Friend WithEvents Label7 As System.Windows.Forms.Label
   Friend WithEvents tbNumero As System.Windows.Forms.TextBox
   Friend WithEvents Label8 As System.Windows.Forms.Label
   Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
   Friend WithEvents cmdAlta As System.Windows.Forms.Button
   Friend WithEvents cmdSalir As System.Windows.Forms.Button
   Friend WithEvents cmdBaja As System.Windows.Forms.Button
   Friend WithEvents cmdImprimir As System.Windows.Forms.Button
   Friend WithEvents cmdEdicion As System.Windows.Forms.Button
   Friend WithEvents cmdCajaRec As System.Windows.Forms.Button
   Friend WithEvents cmdTransferir As System.Windows.Forms.Button
   Friend WithEvents cmdListado As System.Windows.Forms.Button
   Friend WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents dtpHasta As System.Windows.Forms.DateTimePicker
End Class
