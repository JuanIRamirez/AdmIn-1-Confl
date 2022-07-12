Public Class FrmLiqPropietABM
   '
   Public SoloLect As Boolean = False
   '
   Dim Tr As OleDb.OleDbTransaction
   ReadOnly Cmd As New OleDb.OleDbCommand
   'Dim nTipoMov As Integer
   Dim Estado As Integer
   Dim NroLiq As Long
   Dim Propietario As Long
   Dim FormLoad As Boolean = False
   '
   Const estAnulado = 2
   Const cmpInt = "LP"
   '
   Private Sub FrmLiqPropietMod_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      '
      GetRegForm(Me)
      '
      TraducirForm(Me)
      '
      ArmaComboItem(cbPropietario, "Propietarios", , "Nombre", "Nombre", "(Todos)")
      ArmaComboItem(cbEstado, "EstLiquid", "Estado", , , "(Todos)")
      '
      PosCboItem(cbEstado, 0)
      '
      dtpDesde.Value = Today
      dtpHasta.Value = Today
      dtpPeriodo.Value = Today
      '
      Cmd.Connection = Cn
      '
      cmdAlta.Enabled = TienePermiso(Cn, Uid, frmMenu.mAltaLiqPro.Name)
      '
      FormLoad = True
      '
      ActData()
      '
   End Sub
   '
   Private Sub frmLiqPropietMod_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
      TabReturn(e.KeyChar)
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
      ActData()
   End Sub
   '
   Private Sub cbEstado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbEstado.SelectedIndexChanged
      With cbEstado
         If .SelectedIndex > 0 Then
            Estado = .SelectedValue
         Else
            Estado = 0
         End If
      End With
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
      Dim Sql As String
      Dim cCols As String
      Dim cWhere1 As String
      Dim cWhere2 As String
      Dim cWhere3 As String
      Dim cRels As String
      '
      If Not FormLoad Then Exit Sub
      '
      cCols = "L.Fecha, " &
              "L.Numero, " &
              "L.Propietario, " &
              "P.Nombre, " &
              "L.Recibo, " &
              "CAST(L.Detalle AS VARCHAR(250)) AS Detalle, " &
              "right(L.Periodo,2) + '/' + left(L.Periodo,4) as Per, " &
              "L.Estado, " &
              "EstLiquid.Descrip as DescEst, " &
              "( SELECT SUM(Retenido) FROM RetGcias WHERE LiqPropiet = L.Numero) AS RetGan, " &
              " R.Numero AS NroRet, " &
              "L.Total, " &
              "LA.Numero AS LPAG, P.eMail, L.Tipo, L.Sucursal, L.Factura AS FactNro, " &
              "(SELECT COUNT (1) FROM LiqPropietAg WHERE Numero = L.Numero) AS CantConf "
      '
      cRels = "L.Estado = EstLiquid.Estado AND L.Propietario = P.Codigo "
      '
      If Propietario <= 0 Then
         cWhere1 = ""
      Else
         cWhere1 = " AND L.Propietario = " & Propietario
      End If
      '
      If chkPeriodo.Checked Then
         cWhere2 = " AND L.Periodo = '" & Format(dtpPeriodo.Value, "yyyyMM") & "' "
      Else
         If Not chkTodas.Checked Then
            cWhere2 = " AND L.Fecha >= " & strFEC & Format(dtpDesde.Value, FormatFecha) & strFEC &
                      " AND L.Fecha <= " & strFEC & Format(dtpHasta.Value, FormatFecha) & strFEC
         End If
      End If
      '
      If cbEstado.SelectedIndex <= 0 Then
         cWhere3 = ""
      Else
         cWhere3 = " AND L.Estado = " & Estado
      End If
      '
      Sql = "SELECT " & cCols & ", '' AS Factura " &
            "FROM LiqPropiet L LEFT JOIN LiqPropietAg LA ON L.Numero = LA.LiqPropiet LEFT JOIN RetGcias R ON L.Numero = R.LiqPropiet, Propietarios P, EstLiquid " &
            "WHERE " & cRels & cWhere1 & cWhere2 & cWhere3 &
            "  AND L.Factura = 0 " &
            "UNION " &
            "SELECT " & cCols & ", L.Tipo + '-' + CAST(L.Sucursal AS VARCHAR(4)) + '-' + CAST(L.Factura AS VARCHAR(8)) AS Factura " &
            "FROM LiqPropiet L LEFT JOIN LiqPropietAg LA ON L.Numero = LA.LiqPropiet LEFT JOIN RetGcias R ON L.Numero = R.LiqPropiet, Propietarios P, EstLiquid " &
            "WHERE " & cRels & cWhere1 & cWhere2 & cWhere3 &
            "  AND L.Factura <> 0 " &
            "ORDER BY Fecha, Numero"
      '
      SetRegGrid(Me, DataGridView1)
      LlenarGrid(DataGridView1, Sql)
      '
      cmdImprimir.Enabled = False
      cmdAnular.Enabled = False
      '
      SetCols()
      GetRegGrid(Me, DataGridView1)
      '
      ActPanel()
      '
   End Sub
   '
   Private Sub SetCols()
      '
      With DataGridView1
         For Each Col As DataGridViewColumn In .Columns
            With Col
               Select Case UCase(.Name)
                  Case "FECHA" : .Width = 100
                  Case "NUMERO" : .Width = 90
                  Case "DETALLE" : .Width = 300 : .HeaderText = "Det./ Obs."
                  Case "NOMBRE" : .Width = 290
                  Case "PER" : .Width = 110 : .HeaderText = "Período"
                  Case "DESCEST" : .Width = 110 : .HeaderText = "Estado"
                  Case "RETGAN" : Width = 110 : .HeaderText = "Ret.Gan." : .DefaultCellStyle.Format = "#,##0.00" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                  Case "TOTAL" : .Width = 110 : .DefaultCellStyle.Format = "#,##0.00" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                  Case "LPAG"
                  Case "EMAIL" : .HeaderText = "e-Mail"
                  Case "FACTNRO" : .HeaderText = "N° Fact."
                  Case "NRORET" : .HeaderText = "Ret.N°"
                  Case "CANTCONF" : .HeaderText = "Liq.Conf."
                  Case Else : .Visible = False
               End Select
            End With
         Next Col
      End With
      '
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
      Dim Estado As Byte
      Dim eMail As String
      With DataGridView1
         If .RowCount > 0 Then
            Estado = .SelectedCells(.Columns("Estado").Index).Value
            eMail = .SelectedCells(.Columns("eMail").Index).Value
            cmdImprimir.Enabled = Estado <> estAnulado
            cmdAnular.Enabled = (Not SoloLect And LGR) And Estado <> estAnulado
            btnEnviarMail.Enabled = Estado <> estAnulado And InStr(eMail, "@") > 0
         End If
      End With
   End Sub
   '
   Private Sub btnEnviarMail_Click(sender As Object, e As EventArgs) Handles btnEnviarMail.Click
      Imprimir(crptToMail)
   End Sub
   '
   Private Sub cmdImpimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImprimir.Click
      Imprimir(crptToWindow)
   End Sub
   '
   Private Sub Imprimir(Destino As Byte)
      '
      With DataGridView1
         If .RowCount = 0 Then
            Exit Sub
         Else
            NroLiq = Val(.SelectedCells(.Columns("Numero").Index).Value & "")
         End If
      End With
      '
      ImprimirLiqPropiet(NroLiq, Destino)
      '
   End Sub
   '
   Private Sub cmdAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAnular.Click
      With DataGridView1
         If .RowCount = 0 Then
            Exit Sub
         Else
            Estado = Val(.SelectedCells(.Columns("Estado").Index).Value & "")
            NroLiq = Val(.SelectedCells(.Columns("Numero").Index).Value & "")
         End If
      End With
      If Estado = Clases.EstadoLiq.Anulado Then
         MensajeTrad("LiqYaAnulada")
      ElseIf Estado = Clases.EstadoLiq.Confirmado Then
         MensajeTrad("LiqConfNoAnul")
      Else
         If MsgConfirma(Traducir("AnulaLiqProp") & " Nº " & NroLiq) Then
            Tr = Cn.BeginTransaction
            If AnulaLiqProp(NroLiq, Tr) Then
               Tr.Commit()
            Else
               Tr.Rollback()
            End If
            ActData()
         End If
      End If
   End Sub
   '
   Private Sub DtpFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDesde.ValueChanged, dtpHasta.ValueChanged
      ActData()
   End Sub
   '
   Private Sub CmdAlta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAlta.Click
      If TienePermiso(Cn, Uid, frmMenu.mAltaLiqPro.Name, True) Then
         Dim Frm As New frmLiqPropiet
         With Frm
            .ShowDialog(Me)
         End With
         ActData()
      End If
   End Sub
   '
   Private Sub dtpPeriodo_ValueChanged(sender As Object, e As EventArgs) Handles dtpPeriodo.ValueChanged
      ActData()
   End Sub
   '
   Private Sub chkPeriodo_CheckedChanged(sender As Object, e As EventArgs) Handles chkPeriodo.CheckedChanged
      dtpPeriodo.Enabled = chkPeriodo.Checked
   End Sub
   '
   Private Sub CmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
      Me.Close()
   End Sub
   '
   Private Sub FrmLiqPropietMod_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
      SetRegGrid(Me, DataGridView1)
      SetRegForm(Me)
   End Sub
   '
End Class