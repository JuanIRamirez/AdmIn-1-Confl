Public Class frmLiqInquilinos
   '
   Public SoloLect As Boolean
   '
   Dim Tr As OleDb.OleDbTransaction
   Dim Cmd As New OleDb.OleDbCommand
   Dim Drd As OleDb.OleDbDataReader
   Dim Cm2 As New OleDb.OleDbCommand
   Dim Dr2 As OleDb.OleDbDataReader
   '
   Dim LiqInqId As Int32
   Dim Inquilino As Long
   Dim Estado As Int16
   Dim FormLoad As Boolean = False
   '
   Const cmpInt = "LI"
   '
   Private Sub frmLiqInquilinosAbm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      '
      GetRegForm(Me)
      '
      TraducirForm(Me)
      '
      Cmd.Connection = Cn
      Cm2.Connection = Cn
      '
      ArmaComboItem(cbInquilino, "Inquilinos", , "Nombre", "Nombre", "(Seleccionar)")
      ArmaComboItem(cbEstado, "EstLiquid", "Estado", , , "(Todos)", , , , , 0)
      '
      dtpDesde.Value = Today
      dtpHasta.Value = Today
      '
      FormLoad = True
      '
      ActData()
      '
   End Sub
   '
   Private Sub frmLiqInquilinosAbm_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
      TabReturn(e.KeyChar)
   End Sub
   '
   Private Sub cmdAlta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAlta.Click
      If TienePermiso(Cn, Uid, frmMenu.mAltaLiqInq.Name, True) Then
         Dim Frm As New frmLiqInquilinosAM
         With Frm
            .ShowDialog(Me)
         End With
         ActData()
      End If
   End Sub
   '
   Private Sub cbInquilino_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbInquilino.SelectedIndexChanged
      '
      With cbInquilino
         If .SelectedIndex > 0 Then
            Inquilino = .SelectedValue
         Else
            Inquilino = 0
         End If
      End With
      '
      ActData()
      '
   End Sub
   '
   Private Sub cbEstado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbEstado.SelectedIndexChanged
      With cbEstado
         If .SelectedIndex > 0 Then
            Estado = .SelectedValue
         Else
            Estado = -1
         End If
      End With
      ActData()
   End Sub
   '
   Private Sub dtpDesde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDesde.ValueChanged, dtpHasta.ValueChanged
      ActData()
   End Sub
   '
   Private Sub chkTodas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodas.CheckedChanged
      If chkTodas.Checked Then
         dtpDesde.Enabled = False
         dtpHasta.Enabled = False
      Else
         dtpDesde.Enabled = True
         dtpHasta.Enabled = True
      End If
      ActData()
   End Sub
   '
   Private Sub ActData()
      '
      Dim Sql, cCols As String
      Dim cWhere1 As String
      Dim cWhere2 As String
      Dim cWhere3 As String
      Dim cRels As String
      '
      If Not FormLoad Then Exit Sub
      '
      cCols = "C.LiqInqId, C.Fecha, O.LicFecha, " &
              "C.Tipo, C.Sucursal, C.Numero, " &
              "right(C.Periodo,2) + '/' + left(C.Periodo,4) as Per, " &
              "C.Inquilino, " &
              "Inquilinos.Nombre, " &
              "ISNULL(O.LicEfectivo + O.LicCheques + O.LicTransferencia + O.LicRetencion, C.Efectivo + C.Cheques + C.ImporteTR + Retencion) AS TotPago, D.LcdImpPago AS ImpPago, " &
              "C.SaldoPend, O.LicEfectivo, O.LicCheques, O.LicTransferencia, O.LicRetencion, " &
              "C.Efectivo + C.Cheques + C.ImporteTR + Retencion AS TotPend, " &
              "C.Detalle, C.Estado, EstLiquid.Descrip as DescEst, C.ChReciboID, " &
              "D.LiqPropiet, LP.Fecha, P.Nombre AS Propietario"
      '
      cRels = "C.Inquilino = Inquilinos.Codigo AND " &
              "C.Estado = EstLiquid.Estado"
      '
      If Inquilino = 0 Then
         cWhere1 = ""
      Else
         cWhere1 = " And C.Inquilino = " & Inquilino
      End If
      '
      If chkTodas.Checked Then
         cWhere2 = ""
      Else
         cWhere2 = " And C.Fecha >= " & strFEC & Format(dtpDesde.Value, FormatFecha) & strFEC &
                   " And C.Fecha <= " & strFEC & Format(dtpHasta.Value, FormatFecha) & strFEC
      End If
      '
      If Estado < 0 Then
         cWhere3 = ""
      Else
         cWhere3 = " And C.Estado = " & Estado
      End If
      '
      Sql = "SELECT " & cCols &
            " FROM LiqInqCab C LEFT JOIN LiqPropiet LP ON C.LiqPropiet = LP.Numero " &
            " LEFT JOIN LiqInqCobDet D ON D.LiqInqId = C.LiqInqId " &
            " LEFT JOIN LiqInqCob O ON O.LicId = D.LicId " &
            " LEFT JOIN Propietarios P ON C.Propietario = P.Codigo " &
            " INNER JOIN Inquilinos ON C.Inquilino = Inquilinos.Codigo " &
            " INNER JOIN EstLiquid ON C.Estado = EstLiquid.Estado " &
            " WHERE " & cRels & cWhere1 & cWhere2 & cWhere3 &
            " ORDER BY C.Fecha, C.Tipo, C.Sucursal, C.Numero"
      '
      SetRegGrid(Me, DataGridView1)
      '
      LlenarGrid(DataGridView1, Sql)
      '
      cmdImprimir.Enabled = False
      cmdAnular.Enabled = False
      '
      SetCols()
      '
      GetRegGrid(Me, DataGridView1)
      '
      ActPanel()
      '
   End Sub
   '
   Private Sub SetCols()
      With DataGridView1
         For Each Col As DataGridViewColumn In .Columns
            With Col
               Select Case UCase(.Name)
                  Case "FECHA" : .Width = 100
                  Case "LICFECHA" : .HeaderText = "Fec.cobro"
                  Case "TIPO" : .Width = 40 : .HeaderText = "Letra"
                  Case "SUCURSAL" : .Width = 50 : .HeaderText = "Suc."
                  Case "NUMERO" : .Width = 75 : .HeaderText = "Nº.Liq."
                  Case "PER" : .HeaderText = "Período" : .Width = 100
                  Case "NOMBRE" : .Width = 250 : .HeaderText = "Inquilino"
                  Case "IMPPAGO" : .Width = 100 : .HeaderText = "Total" : .DefaultCellStyle.Format = "#,##0.00 " : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                  Case "TOTPAGO" : .Width = 100 : .HeaderText = "Imp.Cob." : .DefaultCellStyle.Format = "#,##0.00 " : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                  Case "LIQPROPIET" : .Width = 100 : .HeaderText = "Liq.Propiet."
                  Case "DETALLE" : .Width = 250
                  Case "DESCEST" : .HeaderText = "Estado"
                  Case "LPFECHA" : .Width = 100 : .HeaderText = "LP.Fecha"
                  Case "TOTAL" : .Width = 100 : .DefaultCellStyle.Format = "#,##0.00 " : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                  Case "LICEFECTIVO" : .Width = 100 : .HeaderText = "Efectivo" : .DefaultCellStyle.Format = "#,##0.00 " : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                  Case "LICCHEQUES" : .Width = 100 : .HeaderText = "Cheque/s" : .DefaultCellStyle.Format = "#,##0.00 " : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                  Case "LICTRANSFERENCIA" : .HeaderText = "Transf." : .Width = 100 : .DefaultCellStyle.Format = "#,##0.00 " : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                  Case "LICRETENCION" : .Width = 100 : .HeaderText = "Retención" : .DefaultCellStyle.Format = "#,##0.00 " : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                  Case "SALDOPEND" : .HeaderText = "Sdo.Pend." : .Width = 100 : .DefaultCellStyle.Format = "#,##0.00 " : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                  Case "PROPIETARIO"
                  Case Else : .Visible = False
               End Select
            End With
         Next Col
      End With
   End Sub
   '
   Private Sub DataGridView1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyUp
      ActPanel()
   End Sub
   '
   Private Sub DataGridView1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridView1.MouseClick
      ActPanel()
   End Sub
   '
   Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
      ActPanel()
   End Sub
   '
   Private Sub ActPanel()
      With DataGridView1
         If .RowCount > 0 Then
            cmdImprimir.Enabled = .SelectedCells(.Columns("Estado").Index).Value <> Clases.EstadoLiq.Anulado
            cmdAnular.Enabled = (Not SoloLect And LGR) And .SelectedCells(.Columns("Estado").Index).Value <> Clases.EstadoLiq.Anulado
         End If
      End With
   End Sub
   '
   Private Sub cmdImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImprimir.Click
      '
      Dim Ltr As String
      Dim Suc As Int16
      Dim Num As Int32
      Dim Tot As Double
      Dim Per As String
      '
      With DataGridView1
         If .RowCount > 0 Then
            If .SelectedCells(.Columns("Estado").Index).Value = Clases.EstadoLiq.Anulado Then
               MensajeTrad("LiqAnulada")
               Exit Sub
            Else
               Ltr = .SelectedCells(.Columns("Tipo").Index).Value
               Suc = .SelectedCells(.Columns("Sucursal").Index).Value
               Num = .SelectedCells(.Columns("Numero").Index).Value
               If .SelectedCells(.Columns("Estado").Index).Value = Clases.EstadoLiq.Pendiente Then
                  Tot = .SelectedCells(.Columns("TotPend").Index).Value
               Else
                  Tot = .SelectedCells(.Columns("LicEfectivo").Index).Value +
                        .SelectedCells(.Columns("LicCheques").Index).Value +
                        .SelectedCells(.Columns("LicRetencion").Index).Value +
                        .SelectedCells(.Columns("LicTransferencia").Index).Value
               End If
               Per = .SelectedCells(.Columns("Per").Index).Value
            End If
         Else
            Exit Sub
         End If
      End With
      '
      Tr = Cn.BeginTransaction
      '
      With Cmd
         '
         .Transaction = Tr
         '
         .CommandText = "DELETE FROM LiqAux WHERE Usuario = '" & Uid & "' AND LqxPC = '" & NombrePC & "'"
         .ExecuteNonQuery()
         '
         .CommandText = "INSERT INTO LiqAux( Recibe, SonPesos, Periodo, Usuario, LqxPC, Numero) " & _
                        "VALUES('" & cfgNomEmp & "', " & _
                               "'" & Numero_a_Texto(Tot) & "', " & _
                               "'" & Per & "', " & _
                               "'" & Uid & "', " & _
                               "'" & NombrePC & "', " & _
                                     Num & ")"
         .ExecuteNonQuery()
      End With
      '
      Tr.Commit()
      '
      GenRepLiqInq(Ltr, Suc, Num, Traducir("LiqInquilino"), crptToWindow)
      '
   End Sub
   '
   Private Sub cmdAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAnular.Click
      With DataGridView1
         If .RowCount > 0 Then
            If .SelectedCells(.Columns("Estado").Index).Value = Clases.EstadoLiq.Anulado Then
               MensajeTrad("LiqYaAnulada")
               Exit Sub
            Else
               If Val(.SelectedCells(.Columns("LiqPropiet").Index).Value & "") <> 0 Then
                  MensajeTrad("LiqRendAProp")
               Else
                  LiqInqId = .SelectedCells(.Columns("LiqInqId").Index).Value
                  'If Not IsNothing(CapturaDato(Cn, "LiqInqCob C INNER JOIN LiqInqCobDet D ON C.LicId = D.LicId", "LicFecha", "D.LiqInqId = " & LiqInqId)) Then
                  If CapturaDato(Cn, "LiqInqCobDet", "COUNT(1)", "LicId = (SELECT LicId FROM LiqInqCobDet WHERE LiqInqId = " & LiqInqId & ")") > 1 Then
                     MensajeTrad("LiqAgrupada")
                  Else
                     Dim Ltr As String = .SelectedCells(.Columns("Tipo").Index).Value
                     Dim Suc As Int16 = .SelectedCells(.Columns("Sucursal").Index).Value
                     Dim Num As Int32 = .SelectedCells(.Columns("Numero").Index).Value
                     If MsgConfirma(Traducir("AnulaLiquid") & " " & Ltr & "-" & Suc & "-" & Num) Then
                        AnulaLiqInq(Ltr, Suc, Num)
                        ActData()
                     End If
                  End If
               End If
            End If
         End If
      End With
   End Sub
   '
   Private Sub btnAlquileres_Click(sender As Object, e As EventArgs) Handles btnAlquileres.Click
      Dim Inq As Int32
      With DataGridView1
         If .RowCount > 0 Then
            Inq = .SelectedCells(.Columns("Inquilino").Index).Value
            Dim Frm As New frmAlquileres
            With frm
               .Inquilino = Inq
               .ShowDialog()
            End With
         End If
      End With
   End Sub
   '
   Private Sub cmdcmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
      Me.Close()
   End Sub
   '
   Private Sub frmLiqInquilinosAbm_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
      SoloLect = False
      SetRegGrid(Me, DataGridView1)
      SetRegForm(Me)
   End Sub
   '
End Class