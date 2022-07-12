<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVentasRenum
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
      Me.dtpFecha = New System.Windows.Forms.DateTimePicker
      Me.Label10 = New System.Windows.Forms.Label
      Me.Label9 = New System.Windows.Forms.Label
      Me.tbNumero = New System.Windows.Forms.TextBox
      Me.tbSucursal = New System.Windows.Forms.TextBox
      Me.Label2 = New System.Windows.Forms.Label
      Me.Label1 = New System.Windows.Forms.Label
      Me.tbTipoComp = New System.Windows.Forms.TextBox
      Me.tbLetra = New System.Windows.Forms.TextBox
      Me.tbCliente = New System.Windows.Forms.TextBox
      Me.Label3 = New System.Windows.Forms.Label
      Me.Label4 = New System.Windows.Forms.Label
      Me.tbNNumero = New System.Windows.Forms.TextBox
      Me.tbNSucursal = New System.Windows.Forms.TextBox
      Me.btnCancelar = New System.Windows.Forms.Button
      Me.btnAceptar = New System.Windows.Forms.Button
      Me.SuspendLayout()
      '
      'dtpFecha
      '
      Me.dtpFecha.Enabled = False
      Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpFecha.Location = New System.Drawing.Point(163, 112)
      Me.dtpFecha.Name = "dtpFecha"
      Me.dtpFecha.Size = New System.Drawing.Size(89, 20)
      Me.dtpFecha.TabIndex = 29
      '
      'Label10
      '
      Me.Label10.AutoSize = True
      Me.Label10.Location = New System.Drawing.Point(117, 116)
      Me.Label10.Name = "Label10"
      Me.Label10.Size = New System.Drawing.Size(40, 13)
      Me.Label10.TabIndex = 28
      Me.Label10.Text = "Fecha:"
      '
      'Label9
      '
      Me.Label9.AutoSize = True
      Me.Label9.Location = New System.Drawing.Point(230, 73)
      Me.Label9.Name = "Label9"
      Me.Label9.Size = New System.Drawing.Size(69, 13)
      Me.Label9.TabIndex = 27
      Me.Label9.Text = "Suc-Número:"
      '
      'tbNumero
      '
      Me.tbNumero.Enabled = False
      Me.tbNumero.Location = New System.Drawing.Point(349, 70)
      Me.tbNumero.Name = "tbNumero"
      Me.tbNumero.Size = New System.Drawing.Size(76, 20)
      Me.tbNumero.TabIndex = 26
      '
      'tbSucursal
      '
      Me.tbSucursal.Enabled = False
      Me.tbSucursal.Location = New System.Drawing.Point(308, 70)
      Me.tbSucursal.Name = "tbSucursal"
      Me.tbSucursal.Size = New System.Drawing.Size(35, 20)
      Me.tbSucursal.TabIndex = 25
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(123, 73)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(34, 13)
      Me.Label2.TabIndex = 30
      Me.Label2.Text = "Letra:"
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(84, 35)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(73, 13)
      Me.Label1.TabIndex = 32
      Me.Label1.Text = "Comprobante:"
      '
      'tbTipoComp
      '
      Me.tbTipoComp.Enabled = False
      Me.tbTipoComp.Location = New System.Drawing.Point(163, 32)
      Me.tbTipoComp.Name = "tbTipoComp"
      Me.tbTipoComp.Size = New System.Drawing.Size(118, 20)
      Me.tbTipoComp.TabIndex = 33
      '
      'tbLetra
      '
      Me.tbLetra.Enabled = False
      Me.tbLetra.Location = New System.Drawing.Point(163, 70)
      Me.tbLetra.Name = "tbLetra"
      Me.tbLetra.Size = New System.Drawing.Size(36, 20)
      Me.tbLetra.TabIndex = 34
      '
      'tbCliente
      '
      Me.tbCliente.Enabled = False
      Me.tbCliente.Location = New System.Drawing.Point(163, 152)
      Me.tbCliente.Name = "tbCliente"
      Me.tbCliente.Size = New System.Drawing.Size(427, 20)
      Me.tbCliente.TabIndex = 36
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(115, 155)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(42, 13)
      Me.Label3.TabIndex = 35
      Me.Label3.Text = "Cliente:"
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(60, 226)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(139, 13)
      Me.Label4.TabIndex = 37
      Me.Label4.Text = "Nuevos Sucursal y Número:"
      '
      'tbNNumero
      '
      Me.tbNNumero.Location = New System.Drawing.Point(267, 223)
      Me.tbNNumero.Name = "tbNNumero"
      Me.tbNNumero.Size = New System.Drawing.Size(76, 20)
      Me.tbNNumero.TabIndex = 1
      '
      'tbNSucursal
      '
      Me.tbNSucursal.Location = New System.Drawing.Point(226, 223)
      Me.tbNSucursal.Name = "tbNSucursal"
      Me.tbNSucursal.Size = New System.Drawing.Size(35, 20)
      Me.tbNSucursal.TabIndex = 0
      '
      'btnCancelar
      '
      Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancelar.Location = New System.Drawing.Point(546, 252)
      Me.btnCancelar.Name = "btnCancelar"
      Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
      Me.btnCancelar.TabIndex = 3
      Me.btnCancelar.Text = "&Cancelar"
      Me.btnCancelar.UseVisualStyleBackColor = True
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(461, 252)
      Me.btnAceptar.Name = "btnAceptar"
      Me.btnAceptar.Size = New System.Drawing.Size(79, 23)
      Me.btnAceptar.TabIndex = 2
      Me.btnAceptar.Text = "&Aceptar"
      Me.btnAceptar.UseVisualStyleBackColor = True
      '
      'frmVentasRenum
      '
      Me.AcceptButton = Me.btnAceptar
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me.btnCancelar
      Me.ClientSize = New System.Drawing.Size(633, 287)
      Me.Controls.Add(Me.btnCancelar)
      Me.Controls.Add(Me.btnAceptar)
      Me.Controls.Add(Me.tbNNumero)
      Me.Controls.Add(Me.tbNSucursal)
      Me.Controls.Add(Me.Label4)
      Me.Controls.Add(Me.tbCliente)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.tbLetra)
      Me.Controls.Add(Me.tbTipoComp)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.dtpFecha)
      Me.Controls.Add(Me.Label10)
      Me.Controls.Add(Me.Label9)
      Me.Controls.Add(Me.tbNumero)
      Me.Controls.Add(Me.tbSucursal)
      Me.KeyPreview = True
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "frmVentasRenum"
      Me.Text = "Ventas - Renumerar"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
   Friend WithEvents Label10 As System.Windows.Forms.Label
   Friend WithEvents Label9 As System.Windows.Forms.Label
   Friend WithEvents tbNumero As System.Windows.Forms.TextBox
   Friend WithEvents tbSucursal As System.Windows.Forms.TextBox
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents tbTipoComp As System.Windows.Forms.TextBox
   Friend WithEvents tbLetra As System.Windows.Forms.TextBox
   Friend WithEvents tbCliente As System.Windows.Forms.TextBox
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents tbNNumero As System.Windows.Forms.TextBox
   Friend WithEvents tbNSucursal As System.Windows.Forms.TextBox
   Friend WithEvents btnCancelar As System.Windows.Forms.Button
   Friend WithEvents btnAceptar As System.Windows.Forms.Button
End Class
