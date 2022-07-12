Public Class FrmListInquilinos
   '
   Dim rsInq As New OleDb.OleDbCommand
   Dim Propietario As Int32
   Dim Inquilino As Int32
   Dim Estado As String = "A"
   Dim Concepto As String = ""
   '
   Private Sub FrmListInquilinos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      '
      GetRegForm(Me)
      '
      TraducirForm(Me)
      '
      ArmaComboItem(cbPropietario, "Propietarios", , "Nombre", "Nombre", "(Todos)")
      ArmaComboItem(cbInquilino, "Inquilinos", , "Nombre", "Nombre", "(Todos)")
      ArmaCombo(cbConcepto, "Descrip", "Conceptos", "Descrip", , , "(Todos)")
      '
      dtpHasta.Value = Today   ' SumaMes(Today, -1)
      '
   End Sub
   '
   Private Sub ListInquilinos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
      TabReturn(e.KeyChar)
   End Sub
   '
   Private Sub CbPropietario_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPropietario.SelectedIndexChanged
      With cbPropietario
         If .SelectedIndex > 0 Then
            Propietario = .SelectedValue
         Else
            Propietario = 0
         End If
      End With
   End Sub
   '
   Private Sub CbInquilino_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbInquilino.SelectedIndexChanged
      With cbInquilino
         If .SelectedIndex > 0 Then
            Inquilino = .SelectedValue
         Else
            Inquilino = 0
         End If
      End With
   End Sub
   '
   Private Sub CbConcepto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbConcepto.SelectedIndexChanged
      With cbConcepto
         If .SelectedIndex > 0 Then
            Concepto = CapturaDato(Cn, "Conceptos", "Codigo", "Descrip = '" & cbConcepto.Text & "'")
         Else
            Concepto = ""
         End If
      End With
   End Sub
   '
   Private Sub OptListDeuda_CheckedChanged(sender As Object, e As EventArgs) Handles optListDeuda.CheckedChanged, optListDeudaT.CheckedChanged, optInqAct.CheckedChanged
      ActivaCtrl()
   End Sub
   '
   Private Sub ActivaCtrl()
      dtpHasta.Enabled = optListDeuda.Checked
      chkResumen.Enabled = optListDeuda.Checked Or optListDeudaT.Checked
   End Sub
   '
   Private Sub CmdAceptar_Click(sender As Object, e As EventArgs) Handles cmdAceptar.Click
      '
      Dim Filtro As String
      Dim Reporte As String
      Dim cPerAct As String
      Dim Periodo As String
      Dim Formulas(0, 1) As String
      '
      '*If ValPeriodo(tbPerHasta) Then
      Periodo = Format(dtpHasta.Value, "yyyyMM")
      '*Else
      '*Exit Sub
      '*End If
      '
      cPerAct = Format(Today, "yyyyMM")
      '
      If optInactivos.Checked Then
         Filtro = "{Inquilinos.Estado} = 'I'"
      Else
         Filtro = "{Inquilinos.Estado} = '" & Estado & "'"
      End If
      '
      If Concepto <> "" Then
         Filtro = Filtro & " AND {FactInq.Concepto} = '" & Concepto & "' "
      End If
      '
      If optInqAct.Checked Then
         Reporte = "ListInq"
         Formulas(0, 0) = "Subtitulo" : Formulas(0, 1) = "Activos"
         '
         If Inquilino <> 0 Then
            Filtro = Filtro & " AND {Inquilinos.Codigo} = " & Inquilino
         Else
            'Filtro = Filtro & " AND {Inquilinos.Nombre} >= '" & cbDescDesde & "' AND " & _
            '                  "{Inquilinos.Nombre} <= '" & cbDescHasta & "'"
            'Else
            'Filtro = ""
         End If
         'ElseIf optInqAct.Checked Then
         '   Reporte = "ListInqAct"
      ElseIf optInactivos.Checked Then
         Reporte = "ListInq"
         Formulas(0, 0) = "Subtitulo" : Formulas(0, 1) = "Inactivos"
      Else
         Filtro = Filtro & " AND {FactInq.Saldo} <> 0 "
         Formulas(0, 0) = "Subtitulo" : Formulas(0, 1) = ""
         If optListDeuda.Checked Then
            Formulas(0, 0) = "Subtitulo" : Formulas(0, 1) = "Al: " & dtpHasta.Value
            If Inquilino <> 0 Then
               Reporte = "EstDeudaInq"
               Filtro = Filtro & " AND {FactInq.Inquilino} = " & Inquilino & " AND {FactInq.Fecha} <= CDATE('" & Format(dtpHasta.Value, FormatCDATE) & "') "
            Else
               Reporte = IIf(Not chkResumen.Checked, "EstDeudaInq2", "ResDeudaInq")
               Filtro = Filtro & " AND {FactInq.Fecha} <= CDATE('" & Format(dtpHasta.Value, FormatCDATE) & "') "
               If Propietario <> 0 Then
                  Filtro = Filtro & " AND {Propietarios.Codigo} = " & Propietario
               End If
            End If
         Else
            Reporte = IIf(Not chkResumen.Checked, "EstDeudaTInq", "EstDeudaTInqRes")
            If Propietario <> 0 Then
               Filtro = "{Propietarios.Codigo} = " & Propietario
            End If
            If Inquilino <> 0 Then
               Filtro = Filtro & " AND {Inquilinos.Codigo} = " & Inquilino
            End If
         End If
      End If
      '
      ImprimirCrp(Reporte, crptToWindow, Filtro, Me.Text, Formulas)
      '
   End Sub
   '
   Private Sub CmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
      Me.Close()
   End Sub
   '
   Private Sub FrmListInquilinos_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
      SetRegForm(Me)
   End Sub
   '
End Class