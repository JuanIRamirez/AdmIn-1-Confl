Public Class frmFactInquilino
   '
   Public Propietario As Int32
   Public Periodo As String
   '
   Dim Cmd As New OleDb.OleDbCommand
   'Dim Dr As OleDb.OleDbDataReader
   Dim Inquilino As Int32
   Dim Propiedad As Int32
   '
   'Dim nCol As Integer
   'Dim nColFec As Integer
   'Dim nColCon As Integer
   'Dim nColDet As Integer
   'Dim nColImp As Integer
   'Dim nColAcc As Integer
   '
   Dim nTotConc As Double
   Dim nSdoAnt As Double
   Dim nTotal As Double
   Dim nMesPago As Integer
   Dim DiaVenc As Integer
   Dim PerDesde As String
   Dim PerHasta As String
   '
   Private Sub frmFactInquilino_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      '
      GetRegForm(Me)
      '
      TraducirForm(Me)
      '
      ArmaComboItem(cbInquilino, "Inquilinos", , "Nombre", "Nombre", "(Seleccionar)")
      '
      PerDesde = Format(Today, "yyyyMM")
      PerHasta = Format(SumaMes(Today, 6), "yyyyMM")
      '
      ArmaCboPeriodo()
      '
   End Sub
   '
   Private Sub frmFactInquilino_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
      TabReturn(e.KeyChar)
   End Sub
   '
   Private Sub ArmaCboPeriodo()
      ArmaComboPer(cbPeriodo, PerDesde, PerHasta)
   End Sub
   '
   Private Sub cbPeriodo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbPeriodo.SelectedIndexChanged
      CalcPeriodo()
   End Sub
   '
   Private Sub CalcPeriodo()
      With cbPeriodo
         If .Text <> "" Then
            Periodo = cbPeriodo.Text.Substring(3, 4) & cbPeriodo.Text.Substring(0, 2)
            nMesPago = cbPeriodo.SelectedIndex + 1
         Else
            Periodo = ""
            nMesPago = 0
         End If
      End With
      Validar()
   End Sub
   '
   Private Function Validar() As Boolean
      '
      Dim FecSdoIntAnt As Date = Today
      '
      If cbInquilino.Text = "" Or Inquilino = 0 Then
         MensajeTrad("DSelInquilino")
         cbInquilino.Focus()
         Return False
      ElseIf cbPropiedad.Text = "" Or Propiedad = 0 Then
         If UCase(Sistema) = "RSISQL2" Then
            'ArmaComboPer cbPeriodo, Format(Date, "yyyyMM"), Format(SumaMes(Date, 1), "yyyyMM")
         Else
            MensajeTrad("DSelPropiedad")
            cbPropiedad.Focus()
            Return False
         End If
      End If
      If Not IsDate("01/" & cbPeriodo.Text) Then
         MensajeTrad("PeriodoInv")
         cbPeriodo.Focus()
         Return False
      End If
      '
      If Not IsNothing(CapturaDato(Cn, "FactInq", "Liquidado", "Propiedad = " & Propiedad & " AND Inquilino = " & Inquilino & " AND Periodo = '" & Periodo & "' AND Liquidado <> 0")) Then
         If MsgConfirma("Período ya liquidado, continua ?") Then
            lblInfo.Text = Traducir("PerYaLiq")
         Else
            ActivaAbm(False)
            cbPeriodo.Text = ""
            cbPeriodo.Focus()
            Return False
         End If
      End If
      '
      ActSdoIntAnt(Periodo, Propiedad, Inquilino, nSdoAnt, 0, FecSdoIntAnt)
      '
      'ActPropConc cPeriodo, rsPCon, rsFac, cbPropiedad, cbInquilino, nMesPago
      '
      'With Rs
      '   .Open("SELECT * FROM ConsDepart WHERE Propiedad = " & Propiedad, Cn, adOpenForwardOnly, adLockReadOnly)
      '   '.Seek "=", cbPropiedad
      '   If .EOF Then
      '      'No pertenece a un Consorcio.
      '   Else
      '      AgrConsConc()!Consorcio, cPeriodo, DiaVenc
      '      ActConsDFac()!Consorcio, cPeriodo, "", Propiedad, _
      '                  cbInquilino, !Porcent
      '   End If
      '   .Close()
      'End With
      '
      ActData()
      ActivaAbm(True)
      cmdAlta.Focus()
      '
   End Function
   '
   Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
      Me.Close()
   End Sub
   '
   Sub ActData()
      '
      Dim i As Int16
      '
      SetRegGrid(Me, DataGridView1)
      '
      LlenarGrid(DataGridView1, "SELECT Fecha, Periodo, Concepto, Detalle, Importe, Saldo, " &
                                "       Imputacion as Imp, Liquidado as Liq, aPropiet, Automatico AS Aut " &
                                "FROM FactInq " &
                                "WHERE Periodo " & IIf(chkFRango.Checked, "<", "=") & " '" & Periodo & "' " &
                                "  AND Propiedad = " & Propiedad &
                                "  AND Inquilino = " & Inquilino)
      '
      SetCols()
      '
      nTotConc = 0
      '
      With DataGridView1
         For i = 0 To .RowCount - 1
            nTotConc = nTotConc + IIf(.Item("Imp", i).Value = "D", .Item("Importe", i).Value, - .Item("Importe", i).Value)
         Next i
         lblInfo.Text = ""
         'If .RecordCount > 0 Then
         '.MoveFirst()
         'lblInfo = IIf(!Liq, Traducir("PerYaLiq"), "")
         'End If
      End With
      '
      nTotal = nTotConc + nSdoAnt
      '
      tbSdoAnt.Text = Format(nSdoAnt, "Fixed")
      tbTotConc.Text = Format(nTotConc, "Fixed")
      tbTotal.Text = Format(nTotal, "Fixed")
      '
      GetRegGrid(Me, DataGridView1)
      '
   End Sub
   '
   Private Sub SetCols()
      With DataGridView1
         For Each Col As DataGridViewColumn In .Columns
            With Col
               Select Case UCase(.Name)
                  Case "FECHA" : .Width = 100
                  Case "CONCEPTO" : .Width = 80
                  Case "DETALLE" : .Width = 450
                  Case "IMPORTE" : .Width = 100 : .DefaultCellStyle.Format = "#,##0.00 " : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                  Case "SALDO" : .Width = 100 : .DefaultCellStyle.Format = "#,##0.00 " : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                  Case "IMP" : .Width = 50
                  Case "LIQ"
                  Case "AUT"
                  Case "APROPIET" : Width = 50 : .HeaderText = "A Prop."
                  Case "DEBE" : .Width = 100 : .DefaultCellStyle.Format = "#,##0.00 " : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                  Case "HABER" : .Width = 100 : .DefaultCellStyle.Format = "#,##0.00 " : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                  Case Else : .Visible = False
               End Select
            End With
         Next Col
      End With
   End Sub
   '
   Private Sub ActivaAbm(ByVal Activo As Boolean)
      '
      'Dim Ctrl As Control
      '
      cmdAlta.Enabled = Activo
      cmdBaja.Enabled = Activo And Me.DataGridView1.RowCount > 0
      cmdEditar.Enabled = Activo And Me.DataGridView1.RowCount > 0
      'cmdTerminar.Enabled = Activo
      '
      If Activo Then
         'cmdTerminar.Cancel = True
      Else
         'cmdSalir.Cancel = True
      End If
      '
      'cmdAceptar.Enabled = Not Activo
      'cbPeriodo.Enabled = Not Activo
      '
      'For Each Ctrl In Me.Controls
      'If TypeOf Ctrl Is ComboBox Then Ctrl.Enabled = Not Activo
      'Next Ctrl
      '
   End Sub
   '
   Private Sub cmdTerminar_Click()
      ActivaAbm(False)
      'Cancelar
   End Sub
   '
   Private Sub cbInquilino_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbInquilino.SelectedIndexChanged
      '
      Dim PerIni As String
      '
      With cbInquilino
         If .SelectedIndex > 0 Then
            Inquilino = .SelectedValue
         Else
            Inquilino = 0
         End If
      End With
      '
      'If Inquilino = 0 Then Exit Sub
      '
      If Not IsNothing(CapturaDato(Cn, "Inquilinos", "Estado", "Codigo = " & Inquilino & " AND Estado = 'I'")) Then
         lblInfo.Text = Traducir("CtaInactiva")
         Cancelar()
         Exit Sub
      End If
      '
      lblInfo.Text = ""
      '
      PerIni = CapturaDato(Cn, "FactInq", "MIN(Periodo)", "Inquilino = " & Inquilino & " AND Saldo <> 0") & ""
      '
      If PerIni <> "" Then
         PerDesde = PerIni
      End If
      '
      ArmaCboPeriodo()
      ArmaCbPropInq(cbPropiedad, Inquilino)
      '
   End Sub
   '
   Private Sub Cancelar()
      '
      Dim nPer As Integer
      '
      cbPropiedad.SelectedIndex = -1
      nPer = cbPeriodo.SelectedIndex
      cbPeriodo.Items.Clear()
      nSdoAnt = 0
      '
      ActivaAbm(False)
      '
   End Sub
   '
   Private Sub optCtto_CheckedChanged(sender As Object, e As EventArgs) Handles optActual.CheckedChanged, optAnterior.CheckedChanged
      If Inquilino <> 0 And Propiedad <> 0 Then
         ArmaCbPeriodo()
      End If
   End Sub
   '
   Private Sub cbPropiedad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbPropiedad.SelectedIndexChanged
      '
      With cbPropiedad
         If .SelectedIndex > 0 Then
            Propiedad = .SelectedValue
         Else
            Propiedad = 0
         End If
      End With
      '
      Propietario = Val(CapturaDato(Cn, "Propiedades", "Propietario", "Codigo = " & Propiedad) & "")
      tbPropietario.Text = CapturaDato(Cn, "Propietarios", "Nombre", "Codigo = " & Propietario)
      '
      If Propiedad = 0 Then
         ActData()
         ActivaAbm(False)
         Exit Sub
      Else
         If Propietario = 0 Then
            MensajeTrad("PrtNoEnc")
         End If
      End If
      '
      ArmaCbPeriodo()
      '
   End Sub
   '
   Private Sub ArmaCbPeriodo()
      '
      Dim Cmd As New OleDb.OleDbCommand
      Dim Drd As OleDb.OleDbDataReader
      '
      Dim i As Integer
      Dim Ok As Boolean
      '
      With Cmd
         .Connection = Cn
         '.CommandText = "SELECT MIN(Periodo) FROM FactInq WHERE Inquilino = " & Inquilino & " AND Propiedad = " & Propiedad & " AND Saldo <> 0"
         'PerDesde = .ExecuteScalar & ""
         '
         .CommandText = "SELECT TOP 1 * FROM Contratos " &
                        "WHERE Inquilino = " & Inquilino &
                        "  AND Propiedad = " & Propiedad &
                        "  AND Estado IN( 0, 1) " &
                        IIf(optActual.Checked, "", " AND Numero NOT IN(SELECT MAX(numero) FROM Contratos WHERE Inquilino = " & Inquilino & " AND Propiedad = " & Propiedad & " AND Estado IN( 0, 1)) ") &
                        "ORDER BY Numero DESC"
         Drd = .ExecuteReader
         '
         With Drd
            If .Read Then
               If !Estado = 0 Then
                  Ok = True
               Else
                  If optActual.Checked Then
                     Ok = MsgConfirma("Contrato finalizado, continua ?")
                  Else
                     Ok = True
                  End If
                  'If PerDesde = "" Or !PerDesde < PerDesde Then
                  '   PerDesde = !PerDesde
                  'End If
               End If
               cbPeriodo.Items.Clear()
               If Ok Then
                  If !Inquilino = Inquilino And
                     !Propiedad = Propiedad Then
                     ArmaComboPer(cbPeriodo, !PerDesde, !PerHasta)
                     DiaVenc = !DiaVenc
                  Else
                     MensajeTrad("ContratoNoEnc")
                     cbPropiedad.SelectedIndex = -1
                     .Close()
                     Exit Sub
                  End If
               End If
            Else
               MensajeTrad("ContratoNoEnc")
               lblInfo.Text = Traducir("ContratoNoEnc")
               cbPropiedad.SelectedIndex = -1
               .Close()
               Exit Sub
            End If
            '
            .Close()
            '
         End With
         '
         .CommandText = "SELECT * FROM FactInq " &
                        "WHERE Propiedad = " & Propiedad &
                        "  AND Inquilino = " & Inquilino &
                        "  AND Liquidado = 0 " &
                        "ORDER BY Periodo"
         Drd = .ExecuteReader
         '
         With Drd
            Do While .Read
               For i = 0 To cbPeriodo.Items.Count - 1
                  If cbPeriodo.Items.Item(i) = !Periodo.ToString.Substring(4, 2) + "/" + !Periodo.ToString.Substring(0, 4) Then
                     cbPeriodo.SelectedIndex = i
                     Periodo = !Periodo
                     Exit Do
                  End If
               Next i
            Loop
            .Close()
         End With
      End With
      '
   End Sub
   '
   Private Sub DataGrid1_DblClick()
      'cmdEdicion_Click()
   End Sub
   '
   Private Sub CmdAlta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAlta.Click
      AltaMod("A")
   End Sub
   '
   Private Sub CmdBaja_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBaja.Click
      '
      Dim Conc As String
      Dim Per As String
      '
      With DataGridView1
         If .RowCount > 0 Then
            If .SelectedCells(.Columns("Aut").Index).Value = True Then
               MensajeTrad("ConcAutNoBaja")
               Exit Sub
            ElseIf .SelectedCells(.Columns("Liq").Index).Value = True Then
               MensajeTrad("ConcLiqNoBaja")
               Exit Sub
            Else
               If DaDeBaja(.SelectedCells(.Columns("Detalle").Index).Value) Then
                  Conc = .SelectedCells(.Columns("Concepto").Index).Value
                  Per = .SelectedCells(.Columns("Periodo").Index).Value
                  'Cn.BeginTrans()
                  Cmd.Connection = Cn
                  Cmd.CommandText = "DELETE FROM FactInq WHERE Inquilino = " & Inquilino & " AND Periodo = '" & Per & "' AND Propiedad = " & Propiedad & " AND Concepto = '" & Conc & "'"
                  Cmd.ExecuteNonQuery()
                  '
                  GuardarAudit("Baja Facturación Inquilino", "Inq: " & cbInquilino.Text & " - Período: " & Per & " - Prd: " & Me.tbPropietario.Text & " - Concepto: " & Conc, "FactInquilino", Me.cmdBaja.Name)
                  'Cn.CommitTrans()
                  ActData()
               End If
            End If
         Else
            MensajeTrad("DSelItem")
         End If
      End With
      '
   End Sub
   '
   Private Sub CmdEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEditar.Click
      '
      If DataGridView1.RowCount = 0 Then
         MensajeTrad("DSelItem")
      Else
         AltaMod("E")
      End If
      '
   End Sub
   '
   Private Sub AltaMod(ByVal Modo)
      '
      With frmFactInqAM
         If Modo = "A" Then
            .Concepto = ""
         Else
            With DataGridView1
               If .RowCount > 0 Then
                  If .SelectedCells(.Columns("Aut").Index).Value = True Then
                     MensajeTrad("ConcAutNoMod")
                     Exit Sub
                  End If
                  frmFactInqAM.Concepto = .SelectedCells(.Columns("Concepto").Index).Value
               End If
            End With
         End If
         .Periodo = Periodo
         .Propiedad = Propiedad
         .Inquilino = Inquilino
         .MesPago = nMesPago
         '.Cnx = Cn
         .ShowDialog(Me)
         ActData()
      End With
      '
   End Sub
   '
   Private Sub chkFRango_CheckedChanged(sender As Object, e As EventArgs) Handles chkFRango.CheckedChanged
      cbPeriodo.Enabled = Not chkFRango.Checked
      If chkFRango.Checked Then
         Periodo = Format(Today, "yyyyMM")
         Validar()
      Else
         CalcPeriodo()
      End If
   End Sub
   '
   Private Sub frmFactInquilino_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
      SetRegGrid(Me, DataGridView1)
      SetRegForm(Me)
      Me.Dispose()
   End Sub
   '
End Class