<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFondo
   Inherits System.Windows.Forms.Form

   'Form reemplaza a Dispose para limpiar la lista de componentes.
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

   'Requerido por el Diseñador de Windows Forms
   Private components As System.ComponentModel.IContainer

   'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
   'Se puede modificar usando el Diseñador de Windows Forms.  
   'No lo modifique con el editor de código.
   <System.Diagnostics.DebuggerStepThrough()> _
   Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFondo))
        Me.btnLiquidProp = New System.Windows.Forms.Button()
        Me.btnReciboInq = New System.Windows.Forms.Button()
        Me.btnInquilinos = New System.Windows.Forms.Button()
        Me.btnPropiedades = New System.Windows.Forms.Button()
        Me.btnPropietarios = New System.Windows.Forms.Button()
        Me.btnContrato = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnLiquidProp
        '
        Me.btnLiquidProp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLiquidProp.Image = CType(resources.GetObject("btnLiquidProp.Image"), System.Drawing.Image)
        Me.btnLiquidProp.Location = New System.Drawing.Point(245, 215)
        Me.btnLiquidProp.Name = "btnLiquidProp"
        Me.btnLiquidProp.Size = New System.Drawing.Size(227, 178)
        Me.btnLiquidProp.TabIndex = 8
        Me.btnLiquidProp.Text = "LIQUIDACION PROP."
        Me.btnLiquidProp.TextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.btnLiquidProp.UseVisualStyleBackColor = True
        '
        'btnReciboInq
        '
        Me.btnReciboInq.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReciboInq.Image = CType(resources.GetObject("btnReciboInq.Image"), System.Drawing.Image)
        Me.btnReciboInq.Location = New System.Drawing.Point(12, 215)
        Me.btnReciboInq.Name = "btnReciboInq"
        Me.btnReciboInq.Size = New System.Drawing.Size(227, 178)
        Me.btnReciboInq.TabIndex = 7
        Me.btnReciboInq.Text = "RECIBO INQ."
        Me.btnReciboInq.TextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.btnReciboInq.UseVisualStyleBackColor = True
        '
        'btnInquilinos
        '
        Me.btnInquilinos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInquilinos.Image = CType(resources.GetObject("btnInquilinos.Image"), System.Drawing.Image)
        Me.btnInquilinos.Location = New System.Drawing.Point(478, 12)
        Me.btnInquilinos.Name = "btnInquilinos"
        Me.btnInquilinos.Size = New System.Drawing.Size(227, 178)
        Me.btnInquilinos.TabIndex = 9
        Me.btnInquilinos.Text = "INQUILINOS"
        Me.btnInquilinos.TextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.btnInquilinos.UseVisualStyleBackColor = True
        '
        'btnPropiedades
        '
        Me.btnPropiedades.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPropiedades.Image = CType(resources.GetObject("btnPropiedades.Image"), System.Drawing.Image)
        Me.btnPropiedades.Location = New System.Drawing.Point(245, 12)
        Me.btnPropiedades.Name = "btnPropiedades"
        Me.btnPropiedades.Size = New System.Drawing.Size(227, 178)
        Me.btnPropiedades.TabIndex = 10
        Me.btnPropiedades.Text = "PROPIEDADES"
        Me.btnPropiedades.TextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.btnPropiedades.UseVisualStyleBackColor = True
        '
        'btnPropietarios
        '
        Me.btnPropietarios.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPropietarios.Image = CType(resources.GetObject("btnPropietarios.Image"), System.Drawing.Image)
        Me.btnPropietarios.Location = New System.Drawing.Point(12, 12)
        Me.btnPropietarios.Name = "btnPropietarios"
        Me.btnPropietarios.Size = New System.Drawing.Size(227, 178)
        Me.btnPropietarios.TabIndex = 11
        Me.btnPropietarios.Text = "PROPIETARIOS"
        Me.btnPropietarios.TextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.btnPropietarios.UseVisualStyleBackColor = True
        '
        'btnContrato
        '
        Me.btnContrato.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnContrato.Image = CType(resources.GetObject("btnContrato.Image"), System.Drawing.Image)
        Me.btnContrato.Location = New System.Drawing.Point(711, 12)
        Me.btnContrato.Name = "btnContrato"
        Me.btnContrato.Size = New System.Drawing.Size(227, 178)
        Me.btnContrato.TabIndex = 12
        Me.btnContrato.Text = "CONTRATO"
        Me.btnContrato.TextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.btnContrato.UseVisualStyleBackColor = True
        '
        'frmFondo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(972, 583)
        Me.Controls.Add(Me.btnContrato)
        Me.Controls.Add(Me.btnPropietarios)
        Me.Controls.Add(Me.btnPropiedades)
        Me.Controls.Add(Me.btnInquilinos)
        Me.Controls.Add(Me.btnLiquidProp)
        Me.Controls.Add(Me.btnReciboInq)
        Me.Name = "frmFondo"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnLiquidProp As Button
    Friend WithEvents btnReciboInq As Button
    Friend WithEvents btnInquilinos As Button
    Friend WithEvents btnPropiedades As Button
    Friend WithEvents btnPropietarios As Button
    Friend WithEvents btnContrato As Button
End Class
