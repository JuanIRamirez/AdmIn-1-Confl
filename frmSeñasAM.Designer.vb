<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSeñasAM
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
      Me.cbCliente = New System.Windows.Forms.ComboBox()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.cbPropietario = New System.Windows.Forms.ComboBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.tbNumero = New System.Windows.Forms.TextBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.cboBanco = New System.Windows.Forms.ComboBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.tbEfectivo = New System.Windows.Forms.TextBox()
      Me.dtpFecHasta = New System.Windows.Forms.DateTimePicker()
      Me.Label22 = New System.Windows.Forms.Label()
      Me.lblObserv = New System.Windows.Forms.Label()
      Me.tbConcepto = New System.Windows.Forms.TextBox()
      Me.cmdCancelar = New System.Windows.Forms.Button()
      Me.cmdGenerar = New System.Windows.Forms.Button()
      Me.lblLetra = New System.Windows.Forms.Label()
      Me.tbSucursal = New System.Windows.Forms.TextBox()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.Label7 = New System.Windows.Forms.Label()
      Me.tbTotal = New System.Windows.Forms.TextBox()
      Me.Label8 = New System.Windows.Forms.Label()
      Me.tbFecCheque = New System.Windows.Forms.DateTimePicker()
      Me.tbCheque = New System.Windows.Forms.TextBox()
      Me.Label9 = New System.Windows.Forms.Label()
      Me.Label12 = New System.Windows.Forms.Label()
      Me.Label10 = New System.Windows.Forms.Label()
      Me.tbCtaBanco = New System.Windows.Forms.TextBox()
      Me.cbPropiedad = New System.Windows.Forms.ComboBox()
      Me.Label11 = New System.Windows.Forms.Label()
      Me.Label13 = New System.Windows.Forms.Label()
      Me.tbDetalle = New System.Windows.Forms.TextBox()
      Me.txtDescConc = New System.Windows.Forms.TextBox()
      Me.GroupBox1 = New System.Windows.Forms.GroupBox()
      Me.chkMesDep = New System.Windows.Forms.CheckBox()
      Me.chkExp3 = New System.Windows.Forms.CheckBox()
      Me.chkAgu3 = New System.Windows.Forms.CheckBox()
      Me.chkExp2 = New System.Windows.Forms.CheckBox()
      Me.chkAgu2 = New System.Windows.Forms.CheckBox()
      Me.chkExp1 = New System.Windows.Forms.CheckBox()
      Me.chkAgu1 = New System.Windows.Forms.CheckBox()
      Me.chkRet3 = New System.Windows.Forms.CheckBox()
      Me.chkRet2 = New System.Windows.Forms.CheckBox()
      Me.chkRet1 = New System.Windows.Forms.CheckBox()
      Me.Label20 = New System.Windows.Forms.Label()
      Me.Label19 = New System.Windows.Forms.Label()
      Me.Label18 = New System.Windows.Forms.Label()
      Me.txtAlq3 = New System.Windows.Forms.TextBox()
      Me.txtAlq2 = New System.Windows.Forms.TextBox()
      Me.Label17 = New System.Windows.Forms.Label()
      Me.Label16 = New System.Windows.Forms.Label()
      Me.Label15 = New System.Windows.Forms.Label()
      Me.Label14 = New System.Windows.Forms.Label()
      Me.txtAlq1 = New System.Windows.Forms.TextBox()
      Me.Label21 = New System.Windows.Forms.Label()
      Me.tbTitular = New System.Windows.Forms.TextBox()
      Me.chkAPropiet = New System.Windows.Forms.CheckBox()
      Me.cbNroCheque = New System.Windows.Forms.ComboBox()
      Me.GroupBox1.SuspendLayout()
      Me.SuspendLayout()
      '
      'cbCliente
      '
      Me.cbCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      Me.cbCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.cbCliente.FormattingEnabled = True
      Me.cbCliente.Location = New System.Drawing.Point(71, 50)
      Me.cbCliente.Name = "cbCliente"
      Me.cbCliente.Size = New System.Drawing.Size(414, 21)
      Me.cbCliente.TabIndex = 0
      '
      'Label6
      '
      Me.Label6.AutoSize = True
      Me.Label6.Location = New System.Drawing.Point(18, 53)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(42, 13)
      Me.Label6.TabIndex = 101
      Me.Label6.Text = "Cliente:"
      '
      'cbPropietario
      '
      Me.cbPropietario.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      Me.cbPropietario.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.cbPropietario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbPropietario.FormattingEnabled = True
      Me.cbPropietario.Location = New System.Drawing.Point(21, 96)
      Me.cbPropietario.Name = "cbPropietario"
      Me.cbPropietario.Size = New System.Drawing.Size(414, 21)
      Me.cbPropietario.TabIndex = 1
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(18, 80)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(60, 13)
      Me.Label2.TabIndex = 137
      Me.Label2.Text = "Propietario:"
      '
      'tbNumero
      '
      Me.tbNumero.BackColor = System.Drawing.Color.LightYellow
      Me.tbNumero.Enabled = False
      Me.tbNumero.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.tbNumero.Location = New System.Drawing.Point(198, 23)
      Me.tbNumero.Name = "tbNumero"
      Me.tbNumero.Size = New System.Drawing.Size(77, 20)
      Me.tbNumero.TabIndex = 138
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(138, 27)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(54, 13)
      Me.Label1.TabIndex = 139
      Me.Label1.Text = "Número #"
      '
      'cboBanco
      '
      Me.cboBanco.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      Me.cboBanco.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.cboBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboBanco.Enabled = False
      Me.cboBanco.FormattingEnabled = True
      Me.cboBanco.Location = New System.Drawing.Point(295, 377)
      Me.cboBanco.Name = "cboBanco"
      Me.cboBanco.Size = New System.Drawing.Size(403, 21)
      Me.cboBanco.TabIndex = 21
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(245, 380)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(41, 13)
      Me.Label3.TabIndex = 141
      Me.Label3.Text = "Banco:"
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(55, 338)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(55, 13)
      Me.Label4.TabIndex = 143
      Me.Label4.Text = "Efectivo $"
      '
      'tbEfectivo
      '
      Me.tbEfectivo.Location = New System.Drawing.Point(118, 335)
      Me.tbEfectivo.Name = "tbEfectivo"
      Me.tbEfectivo.Size = New System.Drawing.Size(87, 20)
      Me.tbEfectivo.TabIndex = 18
      Me.tbEfectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'dtpFecHasta
      '
      Me.dtpFecHasta.Enabled = False
      Me.dtpFecHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpFecHasta.Location = New System.Drawing.Point(118, 310)
      Me.dtpFecHasta.Name = "dtpFecHasta"
      Me.dtpFecHasta.Size = New System.Drawing.Size(88, 20)
      Me.dtpFecHasta.TabIndex = 17
      '
      'Label22
      '
      Me.Label22.AutoSize = True
      Me.Label22.Location = New System.Drawing.Point(44, 313)
      Me.Label22.Name = "Label22"
      Me.Label22.Size = New System.Drawing.Size(68, 13)
      Me.Label22.TabIndex = 145
      Me.Label22.Text = "Válido hasta:"
      '
      'lblObserv
      '
      Me.lblObserv.AutoSize = True
      Me.lblObserv.Location = New System.Drawing.Point(507, 57)
      Me.lblObserv.Name = "lblObserv"
      Me.lblObserv.Size = New System.Drawing.Size(56, 13)
      Me.lblObserv.TabIndex = 147
      Me.lblObserv.Text = "Concepto:"
      '
      'tbConcepto
      '
      Me.tbConcepto.BackColor = System.Drawing.Color.LightYellow
      Me.tbConcepto.Enabled = False
      Me.tbConcepto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.tbConcepto.Location = New System.Drawing.Point(563, 53)
      Me.tbConcepto.Name = "tbConcepto"
      Me.tbConcepto.Size = New System.Drawing.Size(44, 20)
      Me.tbConcepto.TabIndex = 148
      '
      'cmdCancelar
      '
      Me.cmdCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.cmdCancelar.Location = New System.Drawing.Point(773, 446)
      Me.cmdCancelar.Name = "cmdCancelar"
      Me.cmdCancelar.Size = New System.Drawing.Size(83, 25)
      Me.cmdCancelar.TabIndex = 27
      Me.cmdCancelar.Text = "&Cancelar"
      Me.cmdCancelar.UseVisualStyleBackColor = True
      '
      'cmdGenerar
      '
      Me.cmdGenerar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdGenerar.Location = New System.Drawing.Point(684, 446)
      Me.cmdGenerar.Name = "cmdGenerar"
      Me.cmdGenerar.Size = New System.Drawing.Size(83, 25)
      Me.cmdGenerar.TabIndex = 26
      Me.cmdGenerar.Text = "&Guardar"
      Me.cmdGenerar.UseVisualStyleBackColor = True
      '
      'lblLetra
      '
      Me.lblLetra.AutoSize = True
      Me.lblLetra.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblLetra.Location = New System.Drawing.Point(68, 26)
      Me.lblLetra.Name = "lblLetra"
      Me.lblLetra.Size = New System.Drawing.Size(15, 13)
      Me.lblLetra.TabIndex = 152
      Me.lblLetra.Text = "X"
      '
      'tbSucursal
      '
      Me.tbSucursal.BackColor = System.Drawing.Color.LightYellow
      Me.tbSucursal.Enabled = False
      Me.tbSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.tbSucursal.Location = New System.Drawing.Point(93, 23)
      Me.tbSucursal.Name = "tbSucursal"
      Me.tbSucursal.Size = New System.Drawing.Size(39, 20)
      Me.tbSucursal.TabIndex = 151
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.Location = New System.Drawing.Point(18, 26)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(44, 13)
      Me.Label5.TabIndex = 153
      Me.Label5.Text = "Recibo:"
      '
      'Label7
      '
      Me.Label7.AutoSize = True
      Me.Label7.Location = New System.Drawing.Point(70, 448)
      Me.Label7.Name = "Label7"
      Me.Label7.Size = New System.Drawing.Size(40, 13)
      Me.Label7.TabIndex = 155
      Me.Label7.Text = "Total $"
      '
      'tbTotal
      '
      Me.tbTotal.BackColor = System.Drawing.Color.LightYellow
      Me.tbTotal.Enabled = False
      Me.tbTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.tbTotal.Location = New System.Drawing.Point(118, 445)
      Me.tbTotal.Name = "tbTotal"
      Me.tbTotal.Size = New System.Drawing.Size(88, 20)
      Me.tbTotal.TabIndex = 154
      '
      'Label8
      '
      Me.Label8.AutoSize = True
      Me.Label8.Location = New System.Drawing.Point(704, 409)
      Me.Label8.Name = "Label8"
      Me.Label8.Size = New System.Drawing.Size(40, 13)
      Me.Label8.TabIndex = 163
      Me.Label8.Text = "Fecha:"
      '
      'tbFecCheque
      '
      Me.tbFecCheque.Enabled = False
      Me.tbFecCheque.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.tbFecCheque.Location = New System.Drawing.Point(750, 406)
      Me.tbFecCheque.Name = "tbFecCheque"
      Me.tbFecCheque.Size = New System.Drawing.Size(87, 20)
      Me.tbFecCheque.TabIndex = 25
      Me.tbFecCheque.Value = New Date(2015, 9, 24, 0, 0, 0, 0)
      '
      'tbCheque
      '
      Me.tbCheque.Location = New System.Drawing.Point(118, 377)
      Me.tbCheque.MaxLength = 15
      Me.tbCheque.Name = "tbCheque"
      Me.tbCheque.Size = New System.Drawing.Size(88, 20)
      Me.tbCheque.TabIndex = 20
      Me.tbCheque.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label9
      '
      Me.Label9.AutoSize = True
      Me.Label9.Location = New System.Drawing.Point(57, 380)
      Me.Label9.Name = "Label9"
      Me.Label9.Size = New System.Drawing.Size(53, 13)
      Me.Label9.TabIndex = 162
      Me.Label9.Text = "Cheque $"
      '
      'Label12
      '
      Me.Label12.AutoSize = True
      Me.Label12.Location = New System.Drawing.Point(509, 409)
      Me.Label12.Name = "Label12"
      Me.Label12.Size = New System.Drawing.Size(41, 13)
      Me.Label12.TabIndex = 161
      Me.Label12.Text = "Ch. Nº:"
      '
      'Label10
      '
      Me.Label10.AutoSize = True
      Me.Label10.Location = New System.Drawing.Point(66, 410)
      Me.Label10.Name = "Label10"
      Me.Label10.Size = New System.Drawing.Size(44, 13)
      Me.Label10.TabIndex = 160
      Me.Label10.Text = "Cuenta:"
      '
      'tbCtaBanco
      '
      Me.tbCtaBanco.Enabled = False
      Me.tbCtaBanco.Location = New System.Drawing.Point(117, 406)
      Me.tbCtaBanco.MaxLength = 50
      Me.tbCtaBanco.Name = "tbCtaBanco"
      Me.tbCtaBanco.Size = New System.Drawing.Size(127, 20)
      Me.tbCtaBanco.TabIndex = 22
      '
      'cbPropiedad
      '
      Me.cbPropiedad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      Me.cbPropiedad.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.cbPropiedad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbPropiedad.FormattingEnabled = True
      Me.cbPropiedad.Location = New System.Drawing.Point(441, 96)
      Me.cbPropiedad.Name = "cbPropiedad"
      Me.cbPropiedad.Size = New System.Drawing.Size(414, 21)
      Me.cbPropiedad.TabIndex = 2
      '
      'Label11
      '
      Me.Label11.AutoSize = True
      Me.Label11.Location = New System.Drawing.Point(438, 80)
      Me.Label11.Name = "Label11"
      Me.Label11.Size = New System.Drawing.Size(58, 13)
      Me.Label11.TabIndex = 165
      Me.Label11.Text = "Propiedad:"
      '
      'Label13
      '
      Me.Label13.AutoSize = True
      Me.Label13.Location = New System.Drawing.Point(593, 136)
      Me.Label13.Name = "Label13"
      Me.Label13.Size = New System.Drawing.Size(43, 13)
      Me.Label13.TabIndex = 168
      Me.Label13.Text = "Detalle:"
      '
      'tbDetalle
      '
      Me.tbDetalle.Location = New System.Drawing.Point(395, 152)
      Me.tbDetalle.Multiline = True
      Me.tbDetalle.Name = "tbDetalle"
      Me.tbDetalle.Size = New System.Drawing.Size(461, 203)
      Me.tbDetalle.TabIndex = 16
      '
      'txtDescConc
      '
      Me.txtDescConc.BackColor = System.Drawing.Color.LightYellow
      Me.txtDescConc.Enabled = False
      Me.txtDescConc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtDescConc.Location = New System.Drawing.Point(613, 53)
      Me.txtDescConc.Name = "txtDescConc"
      Me.txtDescConc.Size = New System.Drawing.Size(242, 20)
      Me.txtDescConc.TabIndex = 171
      '
      'GroupBox1
      '
      Me.GroupBox1.Controls.Add(Me.chkMesDep)
      Me.GroupBox1.Controls.Add(Me.chkExp3)
      Me.GroupBox1.Controls.Add(Me.chkAgu3)
      Me.GroupBox1.Controls.Add(Me.chkExp2)
      Me.GroupBox1.Controls.Add(Me.chkAgu2)
      Me.GroupBox1.Controls.Add(Me.chkExp1)
      Me.GroupBox1.Controls.Add(Me.chkAgu1)
      Me.GroupBox1.Controls.Add(Me.chkRet3)
      Me.GroupBox1.Controls.Add(Me.chkRet2)
      Me.GroupBox1.Controls.Add(Me.chkRet1)
      Me.GroupBox1.Controls.Add(Me.Label20)
      Me.GroupBox1.Controls.Add(Me.Label19)
      Me.GroupBox1.Controls.Add(Me.Label18)
      Me.GroupBox1.Controls.Add(Me.txtAlq3)
      Me.GroupBox1.Controls.Add(Me.txtAlq2)
      Me.GroupBox1.Controls.Add(Me.Label17)
      Me.GroupBox1.Controls.Add(Me.Label16)
      Me.GroupBox1.Controls.Add(Me.Label15)
      Me.GroupBox1.Controls.Add(Me.Label14)
      Me.GroupBox1.Controls.Add(Me.txtAlq1)
      Me.GroupBox1.Location = New System.Drawing.Point(21, 140)
      Me.GroupBox1.Name = "GroupBox1"
      Me.GroupBox1.Size = New System.Drawing.Size(363, 151)
      Me.GroupBox1.TabIndex = 3
      Me.GroupBox1.TabStop = False
      '
      'chkMesDep
      '
      Me.chkMesDep.AutoSize = True
      Me.chkMesDep.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.chkMesDep.Location = New System.Drawing.Point(6, 4)
      Me.chkMesDep.Name = "chkMesDep"
      Me.chkMesDep.Size = New System.Drawing.Size(91, 17)
      Me.chkMesDep.TabIndex = 3
      Me.chkMesDep.Text = "Mes &Depósito"
      Me.chkMesDep.UseVisualStyleBackColor = True
      '
      'chkExp3
      '
      Me.chkExp3.AutoSize = True
      Me.chkExp3.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.chkExp3.Enabled = False
      Me.chkExp3.Location = New System.Drawing.Point(328, 114)
      Me.chkExp3.Name = "chkExp3"
      Me.chkExp3.Size = New System.Drawing.Size(15, 14)
      Me.chkExp3.TabIndex = 15
      Me.chkExp3.UseVisualStyleBackColor = True
      '
      'chkAgu3
      '
      Me.chkAgu3.AutoSize = True
      Me.chkAgu3.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.chkAgu3.Enabled = False
      Me.chkAgu3.Location = New System.Drawing.Point(328, 89)
      Me.chkAgu3.Name = "chkAgu3"
      Me.chkAgu3.Size = New System.Drawing.Size(15, 14)
      Me.chkAgu3.TabIndex = 12
      Me.chkAgu3.UseVisualStyleBackColor = True
      '
      'chkExp2
      '
      Me.chkExp2.AutoSize = True
      Me.chkExp2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.chkExp2.Enabled = False
      Me.chkExp2.Location = New System.Drawing.Point(231, 114)
      Me.chkExp2.Name = "chkExp2"
      Me.chkExp2.Size = New System.Drawing.Size(15, 14)
      Me.chkExp2.TabIndex = 14
      Me.chkExp2.UseVisualStyleBackColor = True
      '
      'chkAgu2
      '
      Me.chkAgu2.AutoSize = True
      Me.chkAgu2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.chkAgu2.Enabled = False
      Me.chkAgu2.Location = New System.Drawing.Point(231, 88)
      Me.chkAgu2.Name = "chkAgu2"
      Me.chkAgu2.Size = New System.Drawing.Size(15, 14)
      Me.chkAgu2.TabIndex = 11
      Me.chkAgu2.UseVisualStyleBackColor = True
      '
      'chkExp1
      '
      Me.chkExp1.AutoSize = True
      Me.chkExp1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.chkExp1.Location = New System.Drawing.Point(144, 114)
      Me.chkExp1.Name = "chkExp1"
      Me.chkExp1.Size = New System.Drawing.Size(15, 14)
      Me.chkExp1.TabIndex = 13
      Me.chkExp1.UseVisualStyleBackColor = True
      '
      'chkAgu1
      '
      Me.chkAgu1.AutoSize = True
      Me.chkAgu1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.chkAgu1.Location = New System.Drawing.Point(144, 88)
      Me.chkAgu1.Name = "chkAgu1"
      Me.chkAgu1.Size = New System.Drawing.Size(15, 14)
      Me.chkAgu1.TabIndex = 10
      Me.chkAgu1.UseVisualStyleBackColor = True
      '
      'chkRet3
      '
      Me.chkRet3.AutoSize = True
      Me.chkRet3.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.chkRet3.Enabled = False
      Me.chkRet3.Location = New System.Drawing.Point(328, 63)
      Me.chkRet3.Name = "chkRet3"
      Me.chkRet3.Size = New System.Drawing.Size(15, 14)
      Me.chkRet3.TabIndex = 9
      Me.chkRet3.UseVisualStyleBackColor = True
      '
      'chkRet2
      '
      Me.chkRet2.AutoSize = True
      Me.chkRet2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.chkRet2.Enabled = False
      Me.chkRet2.Location = New System.Drawing.Point(231, 61)
      Me.chkRet2.Name = "chkRet2"
      Me.chkRet2.Size = New System.Drawing.Size(15, 14)
      Me.chkRet2.TabIndex = 8
      Me.chkRet2.UseVisualStyleBackColor = True
      '
      'chkRet1
      '
      Me.chkRet1.AutoSize = True
      Me.chkRet1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.chkRet1.Location = New System.Drawing.Point(144, 62)
      Me.chkRet1.Name = "chkRet1"
      Me.chkRet1.Size = New System.Drawing.Size(15, 14)
      Me.chkRet1.TabIndex = 7
      Me.chkRet1.UseVisualStyleBackColor = True
      '
      'Label20
      '
      Me.Label20.AutoSize = True
      Me.Label20.Location = New System.Drawing.Point(24, 111)
      Me.Label20.Name = "Label20"
      Me.Label20.Size = New System.Drawing.Size(56, 13)
      Me.Label20.TabIndex = 187
      Me.Label20.Text = "Expensas:"
      '
      'Label19
      '
      Me.Label19.AutoSize = True
      Me.Label19.Location = New System.Drawing.Point(24, 85)
      Me.Label19.Name = "Label19"
      Me.Label19.Size = New System.Drawing.Size(35, 13)
      Me.Label19.TabIndex = 183
      Me.Label19.Text = "Agua:"
      '
      'Label18
      '
      Me.Label18.AutoSize = True
      Me.Label18.Location = New System.Drawing.Point(24, 59)
      Me.Label18.Name = "Label18"
      Me.Label18.Size = New System.Drawing.Size(66, 13)
      Me.Label18.TabIndex = 179
      Me.Label18.Text = "Retributivos:"
      '
      'txtAlq3
      '
      Me.txtAlq3.Enabled = False
      Me.txtAlq3.Location = New System.Drawing.Point(265, 30)
      Me.txtAlq3.Name = "txtAlq3"
      Me.txtAlq3.Size = New System.Drawing.Size(87, 20)
      Me.txtAlq3.TabIndex = 6
      Me.txtAlq3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtAlq2
      '
      Me.txtAlq2.Enabled = False
      Me.txtAlq2.Location = New System.Drawing.Point(172, 30)
      Me.txtAlq2.Name = "txtAlq2"
      Me.txtAlq2.Size = New System.Drawing.Size(87, 20)
      Me.txtAlq2.TabIndex = 5
      Me.txtAlq2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label17
      '
      Me.Label17.AutoSize = True
      Me.Label17.Location = New System.Drawing.Point(307, 4)
      Me.Label17.Name = "Label17"
      Me.Label17.Size = New System.Drawing.Size(39, 13)
      Me.Label17.TabIndex = 175
      Me.Label17.Text = "3º Año"
      '
      'Label16
      '
      Me.Label16.AutoSize = True
      Me.Label16.Location = New System.Drawing.Point(210, 3)
      Me.Label16.Name = "Label16"
      Me.Label16.Size = New System.Drawing.Size(39, 13)
      Me.Label16.TabIndex = 174
      Me.Label16.Text = "2º Año"
      '
      'Label15
      '
      Me.Label15.AutoSize = True
      Me.Label15.Location = New System.Drawing.Point(120, 3)
      Me.Label15.Name = "Label15"
      Me.Label15.Size = New System.Drawing.Size(39, 13)
      Me.Label15.TabIndex = 173
      Me.Label15.Text = "1º Año"
      '
      'Label14
      '
      Me.Label14.AutoSize = True
      Me.Label14.Location = New System.Drawing.Point(23, 33)
      Me.Label14.Name = "Label14"
      Me.Label14.Size = New System.Drawing.Size(50, 13)
      Me.Label14.TabIndex = 172
      Me.Label14.Text = "Alquiler $"
      '
      'txtAlq1
      '
      Me.txtAlq1.Location = New System.Drawing.Point(79, 30)
      Me.txtAlq1.Name = "txtAlq1"
      Me.txtAlq1.Size = New System.Drawing.Size(87, 20)
      Me.txtAlq1.TabIndex = 4
      Me.txtAlq1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label21
      '
      Me.Label21.AutoSize = True
      Me.Label21.Location = New System.Drawing.Point(250, 409)
      Me.Label21.Name = "Label21"
      Me.Label21.Size = New System.Drawing.Size(39, 13)
      Me.Label21.TabIndex = 174
      Me.Label21.Text = "Titular:"
      '
      'tbTitular
      '
      Me.tbTitular.Enabled = False
      Me.tbTitular.Location = New System.Drawing.Point(295, 406)
      Me.tbTitular.MaxLength = 50
      Me.tbTitular.Name = "tbTitular"
      Me.tbTitular.Size = New System.Drawing.Size(208, 20)
      Me.tbTitular.TabIndex = 23
      '
      'chkAPropiet
      '
      Me.chkAPropiet.AutoSize = True
      Me.chkAPropiet.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.chkAPropiet.Location = New System.Drawing.Point(248, 337)
      Me.chkAPropiet.Name = "chkAPropiet"
      Me.chkAPropiet.Size = New System.Drawing.Size(86, 17)
      Me.chkAPropiet.TabIndex = 19
      Me.chkAPropiet.Text = "A &Propietario"
      Me.chkAPropiet.UseVisualStyleBackColor = True
      '
      'cbNroCheque
      '
      Me.cbNroCheque.FormattingEnabled = True
      Me.cbNroCheque.Location = New System.Drawing.Point(556, 406)
      Me.cbNroCheque.Name = "cbNroCheque"
      Me.cbNroCheque.Size = New System.Drawing.Size(141, 21)
      Me.cbNroCheque.TabIndex = 175
      '
      'frmSeñasAM
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(868, 483)
      Me.Controls.Add(Me.cbNroCheque)
      Me.Controls.Add(Me.chkAPropiet)
      Me.Controls.Add(Me.Label21)
      Me.Controls.Add(Me.tbTitular)
      Me.Controls.Add(Me.GroupBox1)
      Me.Controls.Add(Me.txtDescConc)
      Me.Controls.Add(Me.Label13)
      Me.Controls.Add(Me.cbPropiedad)
      Me.Controls.Add(Me.tbDetalle)
      Me.Controls.Add(Me.Label11)
      Me.Controls.Add(Me.Label8)
      Me.Controls.Add(Me.tbFecCheque)
      Me.Controls.Add(Me.tbCheque)
      Me.Controls.Add(Me.Label9)
      Me.Controls.Add(Me.Label12)
      Me.Controls.Add(Me.Label10)
      Me.Controls.Add(Me.tbCtaBanco)
      Me.Controls.Add(Me.Label7)
      Me.Controls.Add(Me.tbTotal)
      Me.Controls.Add(Me.Label5)
      Me.Controls.Add(Me.lblLetra)
      Me.Controls.Add(Me.tbSucursal)
      Me.Controls.Add(Me.cmdCancelar)
      Me.Controls.Add(Me.cmdGenerar)
      Me.Controls.Add(Me.tbConcepto)
      Me.Controls.Add(Me.lblObserv)
      Me.Controls.Add(Me.dtpFecHasta)
      Me.Controls.Add(Me.Label22)
      Me.Controls.Add(Me.Label4)
      Me.Controls.Add(Me.tbEfectivo)
      Me.Controls.Add(Me.cboBanco)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.tbNumero)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.cbPropietario)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.cbCliente)
      Me.Controls.Add(Me.Label6)
      Me.KeyPreview = True
      Me.Name = "frmSeñasAM"
      Me.Text = "Seña"
      Me.GroupBox1.ResumeLayout(False)
      Me.GroupBox1.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents cbCliente As System.Windows.Forms.ComboBox
   Friend WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents cbPropietario As System.Windows.Forms.ComboBox
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents tbNumero As System.Windows.Forms.TextBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents cboBanco As System.Windows.Forms.ComboBox
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents tbEfectivo As System.Windows.Forms.TextBox
   Friend WithEvents dtpFecHasta As System.Windows.Forms.DateTimePicker
   Friend WithEvents Label22 As System.Windows.Forms.Label
   Friend WithEvents lblObserv As System.Windows.Forms.Label
   Friend WithEvents tbConcepto As System.Windows.Forms.TextBox
   Friend WithEvents cmdCancelar As System.Windows.Forms.Button
   Friend WithEvents cmdGenerar As System.Windows.Forms.Button
   Friend WithEvents lblLetra As System.Windows.Forms.Label
   Friend WithEvents tbSucursal As System.Windows.Forms.TextBox
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents Label7 As System.Windows.Forms.Label
   Friend WithEvents tbTotal As System.Windows.Forms.TextBox
   Friend WithEvents Label8 As System.Windows.Forms.Label
   Friend WithEvents tbFecCheque As System.Windows.Forms.DateTimePicker
   Friend WithEvents tbCheque As System.Windows.Forms.TextBox
   Friend WithEvents Label9 As System.Windows.Forms.Label
   Friend WithEvents Label12 As System.Windows.Forms.Label
   Friend WithEvents Label10 As System.Windows.Forms.Label
   Friend WithEvents tbCtaBanco As System.Windows.Forms.TextBox
   Friend WithEvents cbPropiedad As System.Windows.Forms.ComboBox
   Friend WithEvents Label11 As System.Windows.Forms.Label
   Friend WithEvents Label13 As System.Windows.Forms.Label
   Friend WithEvents tbDetalle As System.Windows.Forms.TextBox
   Friend WithEvents txtDescConc As System.Windows.Forms.TextBox
   Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents Label14 As System.Windows.Forms.Label
   Friend WithEvents txtAlq1 As System.Windows.Forms.TextBox
   Friend WithEvents Label17 As System.Windows.Forms.Label
   Friend WithEvents Label16 As System.Windows.Forms.Label
   Friend WithEvents Label15 As System.Windows.Forms.Label
   Friend WithEvents txtAlq3 As System.Windows.Forms.TextBox
   Friend WithEvents txtAlq2 As System.Windows.Forms.TextBox
   Friend WithEvents Label19 As System.Windows.Forms.Label
   Friend WithEvents Label18 As System.Windows.Forms.Label
   Friend WithEvents Label20 As System.Windows.Forms.Label
   Friend WithEvents chkRet1 As System.Windows.Forms.CheckBox
   Friend WithEvents chkExp3 As System.Windows.Forms.CheckBox
   Friend WithEvents chkAgu3 As System.Windows.Forms.CheckBox
   Friend WithEvents chkExp2 As System.Windows.Forms.CheckBox
   Friend WithEvents chkAgu2 As System.Windows.Forms.CheckBox
   Friend WithEvents chkExp1 As System.Windows.Forms.CheckBox
   Friend WithEvents chkAgu1 As System.Windows.Forms.CheckBox
   Friend WithEvents chkRet3 As System.Windows.Forms.CheckBox
   Friend WithEvents chkRet2 As System.Windows.Forms.CheckBox
   Friend WithEvents chkMesDep As System.Windows.Forms.CheckBox
   Friend WithEvents Label21 As System.Windows.Forms.Label
   Friend WithEvents tbTitular As System.Windows.Forms.TextBox
   Friend WithEvents chkAPropiet As System.Windows.Forms.CheckBox
   Friend WithEvents cbNroCheque As System.Windows.Forms.ComboBox
End Class
