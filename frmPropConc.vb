Public Class frmPropConc
   '
   Public Propietario As Int32 = 0
   Public Propiedad As Int32 = 0
   Public NuevoCtto As Boolean = False
   '
   Dim NroCtto As Long
   Dim Inquilino As Long
   Dim nCol As Integer
   Dim nRow As Integer
   Dim FormLoad As Boolean
   '
   Private Sub frmPropConc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      '
      GetRegForm(Me)
      '
      Dim Prt As Int32 = Propietario
      Dim Prd As Int32 = Propiedad
      '
      ArmaComboItem(cbPropietario, "Propietarios", , "Nombre", "Nombre", "(Seleccionar)", "Estado = 'A'")
      '
      If Prt <> 0 Then
         PosCboItem(cbPropietario, Prt)
         cbPropietario.Enabled = False
      End If
      If Prd <> 0 Then
         PosCboItem(cbPropiedad, Prd)
         cbPropiedad.Enabled = False
      End If
      '
      FormLoad = True
      '
      ActData()
      '
   End Sub
   '
   Private Sub frmPropConc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
      TabReturn(e.KeyChar)
   End Sub
   '
   Private Sub cmdListado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdListado.Click
      frmListConcFijos.ShowDialog(Me)
   End Sub
   '
   Private Sub chkTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodos.CheckedChanged
      ActData()
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
      Inquilino = Val(CapturaDato(Cn, "Propiedades", "Inquilino", "Codigo = " & Propiedad) & "")
      '
      If Inquilino = 0 Then
         Inquilino = Val(CapturaDato(Cn, "Contratos", "Inquilino", "Propietario = " & Propietario & " AND Propiedad = " & Propiedad & " AND Estado = 0") & "")
      End If
      '
      tbInquilino.Text = CapturaDato(Cn, "Inquilinos", "Nombre", "Codigo = " & Inquilino) & ""
      '
      If tbInquilino.Text = "" Then
         If Not NuevoCtto Then
            If Propiedad > 0 Then
               tbInquilino.Text = "(Propiedad Desocupada!)"
            End If
         End If
      End If
      '
      ActData()
      '
   End Sub
   '
   Private Sub cbPropietario_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbPropietario.SelectedIndexChanged
      With cbPropietario
         If .SelectedIndex > 0 Then
            Propietario = .SelectedValue
         Else
            Propietario = 0
         End If
      End With
      ArmaCbPrd()
      ActData()
   End Sub
   '
   Private Sub ArmaCbPrd()
      '
      ArmaComboItem(cbPropiedad, "Propiedades", , "Domicilio", "Domicilio", "(Seleccionar)", "Propietario = " & Propietario & " AND Estado = 'A'")
      '
      If Propiedad <> 0 Then
         PosCboItem(cbPropiedad, Propiedad)
         cbPropiedad.Enabled = False
      Else
         If cbPropiedad.Items.Count = 2 Then
            cbPropiedad.SelectedIndex = 1
         End If
      End If
      '
   End Sub
   '
   Sub ActData()
      '
      Dim cSql As String
      '
      If Not FormLoad Then Exit Sub
      '
      If chkTodos.Checked Then
         cSql = "SELECT Concepto, FecDesde, Detalle, Importe, " & _
                " Imputacion AS Imp, aPropiet, Automatico, NoInquilino " & _
                "FROM PropiedConc " & _
                "WHERE Propiedad = " & Propiedad & " " & _
                "ORDER BY Concepto, FecDesde DESC"
      Else
         cSql = "SELECT Concepto, FecDesde, Detalle, Importe, " &
                " Imputacion AS Imp, aPropiet, Automatico, NoInquilino " &
                "FROM PropiedConc P " &
                "WHERE Propiedad = " & Propiedad &
                "  AND FecDesde = ( SELECT MAX(FecDesde) FROM PropiedConc " &
                "              WHERE Propiedad = P.Propiedad " &
                "                AND Concepto = P.Concepto " &
                "                AND FecDesde <= " & strFEC & Format(Today, FormatFecha) & strFEC &
                "              GROUP BY Concepto) " &
                "ORDER BY Concepto, FecDesde DESC"
      End If
      '
      SetRegGrid(Me, DataGridView1)
      '
      LlenarGrid(DataGridView1, cSql)
      '
      SetCols()
      '
      GetRegGrid(Me, DataGridView1)
      '
      With DataGridView1
         cmdBaja.Enabled = .RowCount > 0
         cmdEdicion.Enabled = .RowCount > 0
         btnGenerar.Enabled = .RowCount > 0
      End With
      '
   End Sub
   '
   Private Sub SetCols()
      With DataGridView1
         For Each Col As DataGridViewColumn In .Columns
            With Col
               Select Case UCase(.Name)
                  Case "CONCEPTO" : .Width = 80
                  Case "FECDESDE" : .Width = 100
                  Case "DETALLE" : .Width = 360
                  Case "IMPORTE" : .Width = 120
                     With .DefaultCellStyle
                        .Format = "##,##0.00 "
                        .Alignment = DataGridViewContentAlignment.MiddleRight
                     End With
                  Case "IMP" : .Width = 40
                  Case "AUT" : .Width = 40
                  Case "APROPIET" : .Width = 40 : .HeaderText = "a Propiet."
               End Select
            End With
         Next Col
      End With
   End Sub
   '
   Private Sub DataGridView1_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentDoubleClick
      AltaMod(False)
   End Sub
   '
   Private Sub cmdAlta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAlta.Click
      If Propiedad = 0 Then
         MensajeTrad("DSelPropiedad")
      Else
         AltaMod(True)
      End If
   End Sub
   '
   Private Sub cmdBaja_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBaja.Click
      '
      Dim Trn As OleDb.OleDbTransaction
      Dim Cmd As New OleDb.OleDbCommand
      Dim Cm2 As New OleDb.OleDbCommand
      Dim Drd As OleDb.OleDbDataReader
      '
      Dim lAut As Boolean
      Dim cConc As String
      Dim dFecD As Date
      Dim cPerD As String
      Dim nMes As Integer
      '
      Dim NoInq As Boolean
      Dim Comprob As String
      Dim cDet As String
      '
      Dim Meses As Byte = 0
      Dim DiaVenc As Byte = 0
      Dim PerDesde As String = ""
      '
      With DataGridView1
         If .RowCount = 0 Then
            Exit Sub
         Else
            lAut = .SelectedCells(.Columns("Automatico").Index).Value
            cConc = .SelectedCells(.Columns("Concepto").Index).Value
            dFecD = .SelectedCells(.Columns("FecDesde").Index).Value
            NoInq = .SelectedCells(.Columns("NoInquilino").Index).Value
            cDet = .SelectedCells(.Columns("Detalle").Index).Value
         End If
      End With
      '
      If lAut Then
         If Not MsgConfirma(Traducir("ConcAut") & ", " & Traducir("Continúa") & "?") Then
            Exit Sub
         End If
      End If
      '
      Comprob = "CP-" & Propiedad & "-" & cConc
      cPerD = Format(dFecD, "yyyyMM")
      '
      If MsgConfirma(Traducir("DaDeBaja") & " " & cDet & " - " & dFecD) Then
         '
         Try
            '
            Trn = Cn.BeginTransaction
            '
            With Cmd
               .Connection = Cn
               .Transaction = Trn
               .CommandText = "DELETE FROM PropiedConc " & _
                              "WHERE Propiedad = " & Propiedad & _
                              "  AND Concepto = '" & cConc & "'" & _
                              "  AND FecDesde = " & strFEC & Format(dFecD, FormatFecha) & strFEC
               .ExecuteNonQuery()
               '
               .CommandText = "DELETE FROM FactInq " & _
                              "WHERE Concepto = '" & cConc & "'" & _
                              "  AND Propiedad = " & Propiedad & _
                              "  AND Automatico <> 0 AND Liquidado = 0"
               .ExecuteNonQuery()
               '
            End With
            '
            With Cmd
               .CommandText = "DELETE FROM CompraOtrDet " & _
                              "WHERE Comprob = '" & Comprob & "'" & _
                              "  AND EXISTS( SELECT Comprob FROM CompraOtr " & _
                              "              WHERE Comprob = CompraOtrDet.Comprob " & _
                              "                AND Sucursal = CompraOtrDet.Sucursal " & _
                              "                AND Numero = CompraOtrDet.Numero " & _
                              "                AND Fecha >= " & strFEC & Format(dFecD, FormatFecha) & strFEC & _
                              "                AND Pagado = 0)"
               .ExecuteNonQuery()
               '
               .CommandText = "DELETE FROM CompraOtr " & _
                              "WHERE Comprob = '" & Comprob & "'" & _
                              "  AND Fecha >= " & strFEC & Format(dFecD, FormatFecha) & strFEC & _
                              "  AND Pagado = 0"
               .ExecuteNonQuery()
            End With
            '
            With Cmd
               .CommandText = "SELECT * FROM Contratos WHERE Inquilino = " & Inquilino & " AND Propiedad = " & Propiedad & " AND Estado = 0"
               Drd = .ExecuteReader
            End With
            With Drd
               If .Read Then
                  NroCtto = .Item("Numero")
                  Meses = .Item("Meses")
                  PerDesde = .Item("PerDesde")
                  DiaVenc = .Item("DiaVenc")
               End If
               .Close()
            End With
            '
            If NroCtto <> 0 Then
               '
               For nMes = 1 To Val(Meses)
                  cPerD = CalcPeriodo("01/" & PerDesde.Substring(4, 2) & "/" & PerDesde.Substring(0, 4), nMes)
                  '
                  If cPerD >= Format(Today, "yyyyMM") Then
                     ActPropConc(cPerD, Propiedad, Inquilino, nMes, DiaVenc, cConc, Trn)
                  End If
                  '
               Next nMes
               '
               If SisContable Then
                  If Not ActAsiFactInq(NroCtto, Trn) Then
                     Err.Raise(1001, , Traducir("NoUpAsiento", , Trn))
                  End If
               End If
               '
            End If
            '
            GuardarAudit("Baja Concepto Fijo", "Prt: " & cbPropietario.Text & ", Prd: " & cbPropiedad.Text & ", Conc: " & cConc & ", Dde: " & dFecD, Me.Name, "Baja", Trn)
            '
            Trn.Commit()
            '
         Catch ex As System.Exception
            Trn.Rollback()
            Dim st As New StackTrace(True)
            MensageError(st, "frmPropConc.cmdBaja_Click", Err.Description)
         End Try
         '
         ActData()
         '
      End If
      '
   End Sub
   '
   Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
      '
      Dim Trn As OleDb.OleDbTransaction
      Dim Cmd As New OleDb.OleDbCommand
      Dim Drd As OleDb.OleDbDataReader
      '
      Dim nMes As Byte
      Dim cConc, cPerD As String
      Dim Cont As Boolean = True
      Dim ActConc As Boolean = False
      '
      If tbInquilino.Text = "" Then
         Cont = MsgConfirma(Traducir("PrdDesocup") & ". " & Traducir("Continúa"))
      End If
      '
      If Cont Then
         '
         With DataGridView1
            If .RowCount = 0 Then
               MensajeTrad("DSelItem")
               Exit Sub
            Else
               cConc = .SelectedCells(.Columns("Concepto").Index).Value
            End If
         End With
         '
         Try
            '
            Trn = Cn.BeginTransaction
            '
            With Cmd
               .Connection = Cn
               .Transaction = Trn
               If Inquilino = 0 Then
                  .CommandText = "SELECT * FROM Contratos WHERE Propiedad = " & Propiedad & " AND Estado = 1 AND CtoFecFin > '" & Format(Today, FormatFecha) & "'"
               Else
                  .CommandText = "SELECT * FROM Contratos WHERE Inquilino = " & Inquilino & " AND Propiedad = " & Propiedad & " AND Estado = 0"
               End If
               Drd = .ExecuteReader
            End With
            '
            With Drd
               If .Read Then
                  For nMes = 1 To Val(!Meses)
                     '
                     cPerD = CalcPeriodo("01/" & !PerDesde.ToString.Substring(4, 2) & "/" & !PerDesde.ToString.Substring(0, 4), nMes)
                     '
                     If cPerD >= Format(Today, "yyyyMM") Then
                        '
                        ActConc = False
                        '
                        If IsDBNull(!CtoFecFin) Then
                           ActConc = True
                        Else
                           If cPerD <= Format(!CtoFecFin, "yyyyMM") Then
                              ActConc = True
                           End If
                        End If
                        If ActConc Then
                           ActPropConc(cPerD, !Propiedad, !Inquilino, nMes, !DiaVenc, cConc, Trn)
                        End If
                     End If
                     '
                  Next nMes
               End If
               .Close()
            End With
            '
            If SisContable Then
               If Not ActAsiFactInq(NroCtto, Trn) Then
                  Err.Raise(1001, , Traducir("NoUpAsiento", , Trn))
               End If
            End If
            '
            Trn.Commit()
            '
            Mensaje("Se regeneraron los Conceptos")
            '
         Catch ex As System.Exception
            '
            Trn.Rollback()
            Dim st As New StackTrace(True)
            RegistrarError(st, "PropConc.Generar")
            '
         End Try
         '
      End If
      '
   End Sub
   '
   Private Sub cmdEdicion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdicion.Click
      '
      AltaMod(False)
      '
   End Sub
   '
   Private Sub AltaMod(ByVal Alta As Boolean)
      '
      Dim cCon As String = ""
      Dim dFec As Date
      '
      If Not Alta Then
         With DataGridView1
            If .RowCount = 0 Then
               MensajeTrad("DSelItem")
               Exit Sub
            Else
               cCon = .SelectedCells(.Columns("Concepto").Index).Value
               dFec = .SelectedCells(.Columns("FecDesde").Index).Value
            End If
         End With
      End If
      '
      Dim Frm As New frmPropConcAM
      With Frm
         If Alta Then
            .Concepto = ""
         Else
            .Concepto = cCon
            .Fecha = dFec
         End If
         .Alta = Alta
         .Inquilino = Inquilino
         .Propiedad = Propiedad
         .ShowDialog(Me)
         ActData()
      End With
      '
   End Sub
   '
   Private Sub cmdImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImprimir.Click
      Dim Reporte As String = IIf(chkTodos.Checked, "ConceptosFijos", "ConceptosFijosAct")
      Dim Filtro As String = "{Propiedades.Propietario} = " & Propietario & " AND {PropiedConc.FecDesde} <= CDATE('" & Format(Today, FormatCDATE) & "') "
      ImprimirCrp(Reporte, crptToWindow, Filtro, Me.Text)
   End Sub
   '
   Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
      Me.Close()
   End Sub
   '
   Private Sub frmPropConc_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
      SetRegGrid(Me, DataGridView1)
      SetRegForm(Me)
      Me.Dispose()
   End Sub
   '

   Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

   End Sub
End Class