<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRepDb
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
      Me.btnTrInq = New System.Windows.Forms.Button()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.lblTrInq = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnTrInq
        '
        Me.btnTrInq.Location = New System.Drawing.Point(405, 52)
        Me.btnTrInq.Name = "btnTrInq"
        Me.btnTrInq.Size = New System.Drawing.Size(69, 23)
        Me.btnTrInq.TabIndex = 0
        Me.btnTrInq.Text = "Corregir"
        Me.btnTrInq.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(36, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(272, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Corregir Inconsistencias en Transferencias de Inquilinos:"
        '
        'lblTrInq
        '
        Me.lblTrInq.AutoSize = True
        Me.lblTrInq.Location = New System.Drawing.Point(315, 57)
        Me.lblTrInq.Name = "lblTrInq"
        Me.lblTrInq.Size = New System.Drawing.Size(0, 13)
        Me.lblTrInq.TabIndex = 2
        '
        'FrmRepDb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(504, 249)
        Me.Controls.Add(Me.lblTrInq)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnTrInq)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmRepDb"
        Me.Text = "RepDb"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnTrInq As System.Windows.Forms.Button
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents lblTrInq As System.Windows.Forms.Label
End Class
