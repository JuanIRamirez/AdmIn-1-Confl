Public Class frmListPropiedades
   '
   Public Propietario As Int32
   Public Domicilio As String = ""
   '
   Dim Reporte As String
   Dim Criterio As String
   Dim Propiet As Int32
   '
   Private Sub frmListPropiedades_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      '
      GetRegForm(Me)
      '
      'TraducirForm(Me)
      '
      ArmaComboItem(cbPropietario, "Propietarios", , "Nombre", "Nombre", "(Todos)", "Estado = 'A'")
      If Propietario <> 0 Then
         PosCboItem(cbPropietario, Propietario)
      End If
      '
      If Domicilio <> "" Then
         tbDomicilio.Text = Domicilio
      End If
      '
      ArmaCombo(cbLocalidad, "DISTINCT Localidad", "Propiedades", "Localidad", "Estado = 'A'", , "(Todas)")
      '
   End Sub
   '
   Private Sub frmListPropiedades_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
      TabReturn(e.KeyChar)
   End Sub
   '
   Private Sub cbPropietario_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPropietario.SelectedIndexChanged
      With cbPropietario
         If .SelectedIndex > 0 Then
            Propiet = .SelectedValue
         Else
            Propiet = 0
         End If
      End With
   End Sub
   '
   Private Sub cmdImprimir_Click(sender As Object, e As EventArgs) Handles cmdImprimir.Click      '
      '
      Dim Formulas(0, 1) As String
      Dim Filtro As String = ""
      Dim SubTitulo As String = ""
      Dim Reporte As String = "Propiedades.rpt"
      '
      ActValorAlq()
      '
      If Propiet <> 0 Then
         Filtro = IIf(Filtro = "", "", Filtro & " AND ") & "{Propiedades.Propietario} = " & Propiet
         SubTitulo = SubTitulo & ", Propiet: " & cbPropietario.Text
      End If
      '
      If cbLocalidad.SelectedIndex > 0 Then
         Filtro = IIf(Filtro = "", "", Filtro & " AND ") & "{Propiedades.Localidad} = '" & cbLocalidad.Text & "'"
         SubTitulo = SubTitulo & ", Localidad: " & cbLocalidad.Text
      End If
      '
      If tbDomicilio.Text <> "" Then
         Filtro = IIf(Filtro = "", "", Filtro & " AND ") & "{Propiedades.Domicilio} LIKE '*" & tbDomicilio.Text & "*'"
         SubTitulo = SubTitulo & ", Domicilio: " & tbDomicilio.Text
      End If
      '
      If Not optEstTodas.Checked Then
         Filtro = IIf(Filtro = "", "", Filtro & " AND ") & "{Propiedades.Estado} = '" & IIf(optActivas.Checked, "A", "I") & "'"
         SubTitulo = IIf(optActivas.Checked, "Activas", "Inactivas")
      End If
      '
      If Not optUsoTodas.Checked Then
         Filtro = IIf(Filtro = "", "", Filtro & " AND ") & "{Propiedades.TipoAlq} = '" & IIf(optComercial.Checked, "C", "P") & "'"
         SubTitulo = SubTitulo & ", uso " & IIf(optComercial.Checked, "Comercial", "Particular")
      End If
      '
      If Not optOcupTodas.Checked Then
         Filtro = IIf(Filtro = "", "", Filtro & " AND ") & IIf(optOcupadas.Checked, "NOT ", "") & " ISNULL({Propiedades.Inquilino})"
         SubTitulo = SubTitulo & ", " & IIf(optOcupadas.Checked, "Ocupadas", "Desocupadas")
      End If
      '
      If chkNomencl.Checked Then
         Reporte = "PropiedNomencl.rpt"
      End If
      '
      Formulas(0, 0) = "Subtitulo" : Formulas(0, 1) = SubTitulo
      '
      ImprimirCrp(Reporte, crptToWindow, Filtro, Me.Text, Formulas)
      '
   End Sub
   '
   Private Sub ActValorAlq()
      '
      Dim Cmd As New OleDb.OleDbCommand
      Dim Trn As OleDb.OleDbTransaction
      '
      Trn = Cn.BeginTransaction
      '
      With Cmd
         .Connection = Cn
         .Transaction = Trn
         .CommandText = "UPDATE Propiedades SET " & _
                        " Valor = ISNULL(( SELECT TOP 1 Importe FROM PropiedConc " & _
                        "          WHERE Propiedad = Propiedades.Codigo AND Concepto = 'ALQ' AND FecDesde <= GETDATE() " & _
                        "          ORDER BY FecDesde DESC ), 0)"
         .ExecuteNonQuery()
      End With
      '
      Trn.Commit()
      '
   End Sub
   '
   Private Sub btCerrar_Click(sender As Object, e As EventArgs) Handles btCerrar.Click
      Me.Close()
   End Sub
   '
   Private Sub frmListPropiedades_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
      SetRegForm(Me)
      Me.Dispose()
   End Sub
   '
End Class