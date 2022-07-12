<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListPropiedades
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
      Me.cbPropietario = New System.Windows.Forms.ComboBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.cbLocalidad = New System.Windows.Forms.ComboBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.cmdImprimir = New System.Windows.Forms.Button()
      Me.btCerrar = New System.Windows.Forms.Button()
      Me.tbDomicilio = New System.Windows.Forms.TextBox()
      Me.Label31 = New System.Windows.Forms.Label()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.optParticular = New System.Windows.Forms.RadioButton()
      Me.optUsoTodas = New System.Windows.Forms.RadioButton()
      Me.optComercial = New System.Windows.Forms.RadioButton()
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.optEstTodas = New System.Windows.Forms.RadioButton()
      Me.optInactivas = New System.Windows.Forms.RadioButton()
      Me.optActivas = New System.Windows.Forms.RadioButton()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.Panel2 = New System.Windows.Forms.Panel()
      Me.optOcupTodas = New System.Windows.Forms.RadioButton()
      Me.optDesocup = New System.Windows.Forms.RadioButton()
      Me.optOcupadas = New System.Windows.Forms.RadioButton()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.chkNomencl = New System.Windows.Forms.CheckBox()
      Me.Panel1.SuspendLayout()
      Me.Panel2.SuspendLayout()
      Me.SuspendLayout()
      '
      'cbPropietario
      '
      Me.cbPropietario.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      Me.cbPropietario.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.cbPropietario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbPropietario.FormattingEnabled = True
      Me.cbPropietario.Location = New System.Drawing.Point(85, 27)
      Me.cbPropietario.Name = "cbPropietario"
      Me.cbPropietario.Size = New System.Drawing.Size(433, 21)
      Me.cbPropietario.TabIndex = 0
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(19, 30)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(60, 13)
      Me.Label1.TabIndex = 95
      Me.Label1.Text = "Propietario:"
      '
      'cbLocalidad
      '
      Me.cbLocalidad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      Me.cbLocalidad.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.cbLocalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbLocalidad.FormattingEnabled = True
      Me.cbLocalidad.Location = New System.Drawing.Point(85, 66)
      Me.cbLocalidad.Name = "cbLocalidad"
      Me.cbLocalidad.Size = New System.Drawing.Size(433, 21)
      Me.cbLocalidad.TabIndex = 1
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(23, 69)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(56, 13)
      Me.Label3.TabIndex = 97
      Me.Label3.Text = "Localidad:"
      '
      'cmdImprimir
      '
      Me.cmdImprimir.Location = New System.Drawing.Point(372, 292)
      Me.cmdImprimir.Name = "cmdImprimir"
      Me.cmdImprimir.Size = New System.Drawing.Size(75, 25)
      Me.cmdImprimir.TabIndex = 13
      Me.cmdImprimir.Text = "&Imprimir"
      Me.cmdImprimir.UseVisualStyleBackColor = True
      '
      'btCerrar
      '
      Me.btCerrar.Location = New System.Drawing.Point(453, 292)
      Me.btCerrar.Name = "btCerrar"
      Me.btCerrar.Size = New System.Drawing.Size(75, 25)
      Me.btCerrar.TabIndex = 14
      Me.btCerrar.Text = "&Cerrar"
      Me.btCerrar.UseVisualStyleBackColor = True
      '
      'tbDomicilio
      '
      Me.tbDomicilio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.tbDomicilio.Location = New System.Drawing.Point(85, 102)
      Me.tbDomicilio.Name = "tbDomicilio"
      Me.tbDomicilio.Size = New System.Drawing.Size(433, 20)
      Me.tbDomicilio.TabIndex = 2
      '
      'Label31
      '
      Me.Label31.AutoSize = True
      Me.Label31.Location = New System.Drawing.Point(27, 105)
      Me.Label31.Name = "Label31"
      Me.Label31.Size = New System.Drawing.Size(52, 13)
      Me.Label31.TabIndex = 101
      Me.Label31.Text = "Domicilio:"
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(26, 142)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(53, 13)
      Me.Label2.TabIndex = 102
      Me.Label2.Text = "Tipo Uso:"
      '
      'optParticular
      '
      Me.optParticular.AutoSize = True
      Me.optParticular.Location = New System.Drawing.Point(165, 140)
      Me.optParticular.Name = "optParticular"
      Me.optParticular.Size = New System.Drawing.Size(69, 17)
      Me.optParticular.TabIndex = 4
      Me.optParticular.Text = "&Particular"
      Me.optParticular.UseVisualStyleBackColor = True
      '
      'optUsoTodas
      '
      Me.optUsoTodas.AutoSize = True
      Me.optUsoTodas.Checked = True
      Me.optUsoTodas.Location = New System.Drawing.Point(85, 140)
      Me.optUsoTodas.Name = "optUsoTodas"
      Me.optUsoTodas.Size = New System.Drawing.Size(55, 17)
      Me.optUsoTodas.TabIndex = 3
      Me.optUsoTodas.TabStop = True
      Me.optUsoTodas.Text = "&Todas"
      Me.optUsoTodas.UseVisualStyleBackColor = True
      '
      'optComercial
      '
      Me.optComercial.AutoSize = True
      Me.optComercial.Location = New System.Drawing.Point(262, 140)
      Me.optComercial.Name = "optComercial"
      Me.optComercial.Size = New System.Drawing.Size(71, 17)
      Me.optComercial.TabIndex = 5
      Me.optComercial.Text = "&Comercial"
      Me.optComercial.UseVisualStyleBackColor = True
      '
      'Panel1
      '
      Me.Panel1.Controls.Add(Me.optEstTodas)
      Me.Panel1.Controls.Add(Me.optInactivas)
      Me.Panel1.Controls.Add(Me.optActivas)
      Me.Panel1.Controls.Add(Me.Label4)
      Me.Panel1.Location = New System.Drawing.Point(22, 179)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(330, 40)
      Me.Panel1.TabIndex = 6
      '
      'optEstTodas
      '
      Me.optEstTodas.AutoSize = True
      Me.optEstTodas.Location = New System.Drawing.Point(240, 10)
      Me.optEstTodas.Name = "optEstTodas"
      Me.optEstTodas.Size = New System.Drawing.Size(55, 17)
      Me.optEstTodas.TabIndex = 9
      Me.optEstTodas.Text = "&Todas"
      Me.optEstTodas.UseVisualStyleBackColor = True
      '
      'optInactivas
      '
      Me.optInactivas.AutoSize = True
      Me.optInactivas.Location = New System.Drawing.Point(143, 10)
      Me.optInactivas.Name = "optInactivas"
      Me.optInactivas.Size = New System.Drawing.Size(68, 17)
      Me.optInactivas.TabIndex = 8
      Me.optInactivas.Text = "&Inactivas"
      Me.optInactivas.UseVisualStyleBackColor = True
      '
      'optActivas
      '
      Me.optActivas.AutoSize = True
      Me.optActivas.Checked = True
      Me.optActivas.Location = New System.Drawing.Point(63, 10)
      Me.optActivas.Name = "optActivas"
      Me.optActivas.Size = New System.Drawing.Size(60, 17)
      Me.optActivas.TabIndex = 7
      Me.optActivas.TabStop = True
      Me.optActivas.Text = "&Activas"
      Me.optActivas.UseVisualStyleBackColor = True
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(4, 12)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(43, 13)
      Me.Label4.TabIndex = 103
      Me.Label4.Text = "Estado:"
      '
      'Panel2
      '
      Me.Panel2.Controls.Add(Me.optOcupTodas)
      Me.Panel2.Controls.Add(Me.optDesocup)
      Me.Panel2.Controls.Add(Me.optOcupadas)
      Me.Panel2.Controls.Add(Me.Label5)
      Me.Panel2.Location = New System.Drawing.Point(22, 233)
      Me.Panel2.Name = "Panel2"
      Me.Panel2.Size = New System.Drawing.Size(330, 40)
      Me.Panel2.TabIndex = 9
      '
      'optOcupTodas
      '
      Me.optOcupTodas.AutoSize = True
      Me.optOcupTodas.Location = New System.Drawing.Point(240, 10)
      Me.optOcupTodas.Name = "optOcupTodas"
      Me.optOcupTodas.Size = New System.Drawing.Size(55, 17)
      Me.optOcupTodas.TabIndex = 12
      Me.optOcupTodas.Text = "&Todas"
      Me.optOcupTodas.UseVisualStyleBackColor = True
      '
      'optDesocup
      '
      Me.optDesocup.AutoSize = True
      Me.optDesocup.Location = New System.Drawing.Point(143, 10)
      Me.optDesocup.Name = "optDesocup"
      Me.optDesocup.Size = New System.Drawing.Size(91, 17)
      Me.optDesocup.TabIndex = 11
      Me.optDesocup.Text = "&Desocupadas"
      Me.optDesocup.UseVisualStyleBackColor = True
      '
      'optOcupadas
      '
      Me.optOcupadas.AutoSize = True
      Me.optOcupadas.Checked = True
      Me.optOcupadas.Location = New System.Drawing.Point(63, 10)
      Me.optOcupadas.Name = "optOcupadas"
      Me.optOcupadas.Size = New System.Drawing.Size(74, 17)
      Me.optOcupadas.TabIndex = 10
      Me.optOcupadas.TabStop = True
      Me.optOcupadas.Text = "&Ocupadas"
      Me.optOcupadas.UseVisualStyleBackColor = True
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.Location = New System.Drawing.Point(8, 12)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(39, 13)
      Me.Label5.TabIndex = 103
      Me.Label5.Text = "Ocup.:"
      '
      'chkNomencl
      '
      Me.chkNomencl.AutoSize = True
      Me.chkNomencl.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.chkNomencl.Location = New System.Drawing.Point(22, 292)
      Me.chkNomencl.Name = "chkNomencl"
      Me.chkNomencl.Size = New System.Drawing.Size(136, 17)
      Me.chkNomencl.TabIndex = 10
      Me.chkNomencl.Text = "&Nomenclatura Catastral"
      Me.chkNomencl.UseVisualStyleBackColor = True
      '
      'frmListPropiedades
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(540, 329)
      Me.Controls.Add(Me.chkNomencl)
      Me.Controls.Add(Me.Panel2)
      Me.Controls.Add(Me.Panel1)
      Me.Controls.Add(Me.optComercial)
      Me.Controls.Add(Me.optParticular)
      Me.Controls.Add(Me.optUsoTodas)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.tbDomicilio)
      Me.Controls.Add(Me.Label31)
      Me.Controls.Add(Me.cmdImprimir)
      Me.Controls.Add(Me.btCerrar)
      Me.Controls.Add(Me.cbLocalidad)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.cbPropietario)
      Me.Controls.Add(Me.Label1)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.KeyPreview = True
      Me.MaximizeBox = False
      Me.Name = "frmListPropiedades"
      Me.Text = "Listado de Propiedades"
      Me.Panel1.ResumeLayout(False)
      Me.Panel1.PerformLayout()
      Me.Panel2.ResumeLayout(False)
      Me.Panel2.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents cbPropietario As System.Windows.Forms.ComboBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents cbLocalidad As System.Windows.Forms.ComboBox
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents cmdImprimir As System.Windows.Forms.Button
   Friend WithEvents btCerrar As System.Windows.Forms.Button
   Friend WithEvents tbDomicilio As System.Windows.Forms.TextBox
   Friend WithEvents Label31 As System.Windows.Forms.Label
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents optParticular As System.Windows.Forms.RadioButton
   Friend WithEvents optUsoTodas As System.Windows.Forms.RadioButton
   Friend WithEvents optComercial As System.Windows.Forms.RadioButton
   Friend WithEvents Panel1 As System.Windows.Forms.Panel
   Friend WithEvents optInactivas As System.Windows.Forms.RadioButton
   Friend WithEvents optActivas As System.Windows.Forms.RadioButton
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents Panel2 As System.Windows.Forms.Panel
   Friend WithEvents optOcupTodas As System.Windows.Forms.RadioButton
   Friend WithEvents optDesocup As System.Windows.Forms.RadioButton
   Friend WithEvents optOcupadas As System.Windows.Forms.RadioButton
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents optEstTodas As System.Windows.Forms.RadioButton
   Friend WithEvents chkNomencl As CheckBox
End Class
