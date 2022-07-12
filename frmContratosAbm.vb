Public Class frmContratosAbm
   '
   Public SoloLect As Boolean
   Public Finalizar As Boolean
   Public Anular As Boolean
   Public Actualiz As Boolean = False
   '
   Dim Propietario As Long
   Dim Inquilino As Long
   Dim Estado As Int16
   Dim Cmd As New OleDb.OleDbCommand
   Dim Trn As OleDb.OleDbTransaction
   Dim PerDesde As String
   Dim PerHasta As String
   Dim cWhere As String = ""
   Dim FormLoad As Boolean = False
   '
   Const cmpInt = "CT"
   '
   Private Sub FrmContratosAbm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      '
      GetRegForm(Me)
      '
      TraducirForm(Me)
      '
      ArmaComboItem(cbPropietario, "Propietarios", , "Nombre", "Nombre", "(Todos)")
      ArmaComboItem(cbInquilino, "Inquilinos", , "Nombre", "Nombre", "(Todos)")
      ArmaComboItem(cbEstado, "EstContr", "Estado", , , "(Todos)", , , , , 0)
      '
      dtpDesde.Value = PrimeroDeMes(Today)
      dtpHasta.Value = Today
      '
      cmdAlta.Enabled = TienePermiso(Cn, Uid, frmMenu.mAltaContrato.Name)
      btnActualizar.Visible = Actualiz
      gbActualiz.Visible = Actualiz
      cbEstado.Enabled = Not Actualiz
      '
      FormLoad = True
      '
      ActData()
      '
   End Sub
   '
   Private Sub frmContratosABM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
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
   Private Sub cbInquilino_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbInquilino.SelectedIndexChanged
      With cbInquilino
         If .SelectedIndex > 0 Then
            Inquilino = .SelectedValue
         Else
            Inquilino = 0
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
            Estado = -1
         End If
      End With
      ActData()
   End Sub
   '
   Private Sub dtpFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDesde.ValueChanged, dtpHasta.ValueChanged
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
      Dim cRels As String
      '
      If Not FormLoad Then Exit Sub
      '
      cWhere = ""
      '
      cCols = "C.FechaContrato, C.Numero, " &
              "C.Propietario, Propietarios.Nombre as NomProp, " &
              "C.Propiedad, P.Domicilio, P.TipoAlq," &
              "C.Inquilino, Inquilinos.Nombre AS NomInq, " &
              "right(PerDesde,2) + '/' + left(PerDesde,4) as PerDde, " &
              "right(PerHasta,2) + '/' + left(PerHasta,4) as PerHta, " &
              "C.Estado, EstContr.Descrip as DescEst, C.Texto, C.Convenio, " &
              "(SELECT Importe FROM PropiedConc WHERE Propiedad = C.Propiedad AND Concepto = '" & cfgCodigoAlq & "' AND FecDesde = C.FechaContrato) AS " & cfgCodigoAlq & ", " &
              "(SELECT Importe FROM PropiedConc WHERE Propiedad = C.Propiedad AND Concepto = '" & cfgCodigoIva & "' AND FecDesde = C.FechaContrato) AS " & cfgCodigoIva & ", " &
              IIf(Actualiz, "(SELECT EscDescrip FROM EscContrato WHERE Escalon = (SELECT TOP 1 Escalon FROM ContratosAct WHERE Numero = C.Numero ORDER BY ContratoActId DESC)) AS EscDescrip, " &
              "(SELECT TOP 1 MesesEsc FROM ContratosAct WHERE Numero = C.Numero ORDER BY ContratoActId DESC) AS MesesEsc, " &
              "(SELECT TOP 1 Incremento FROM ContratosAct WHERE Numero = C.Numero ORDER BY ContratoActId DESC) AS Incremento ", "E.EscDescrip, C.MesesEsc, C.Incremento") &
              ", C.Tipo + '-' + CAST(C.Sucursal AS VarChar(4)) + '-' + CAST(C.NroFact AS VarChar(8)) AS Factura"
      '
      cRels = "C.Inquilino = Inquilinos.Codigo And " &
              "C.Propiedad = P.Codigo And " &
              "C.Propietario = Propietarios.Codigo And " &
              "C.Estado = EstContr.Estado "
      '
      If Propietario > 0 Then
         cWhere = " And C.Propietario = " & Propietario & " "
      End If
      '
      If Inquilino > 0 Then
         cWhere = cWhere & " And C.Inquilino = " & Inquilino & " "
      End If
      '
      If Not chkTodas.Checked Then
         cWhere = cWhere & " And C.FechaContrato >= " & strFEC & Format(dtpDesde.Value, FormatFecha) & strFEC &
                           " And C.FechaContrato <= " & strFEC & Format(dtpHasta.Value, FormatFecha) & strFEC
      End If
      '
      If Estado <> -1 Then
         cWhere = cWhere & " AND C.Estado = " & Estado
      End If
      '
      If Actualiz Then
         If Not optTodos.Checked Then
            cWhere = cWhere & " AND C.Numero " & IIf(optAct.Checked, "", "NOT") & " IN (SELECT Numero FROM ContratosAct WHERE Numero = C.Numero)"
         End If
      End If
      '
      If Not optPC.Checked Then
         If optParticular.Checked Then
            cWhere = cWhere & " AND P.TipoAlq = 'P'"
         Else
            cWhere = cWhere & " AND P.TipoAlq = 'C'"
         End If
      End If
      '
      SetRegGrid(Me, DataGridView1)
      '
      Sql = "Select " & cCols & " FROM Contratos C LEFT JOIN EscContrato E ON C.Escalon = E.Escalon, Propietarios, Propiedades P, Inquilinos, EstContr " &
                                " WHERE " & cRels & cWhere &
                                " ORDER BY FechaContrato DESC, Numero DESC"
      '
      LlenarGrid(DataGridView1, Sql)
      'LEFT JOIN ContratosAct A ON A.Numero = C.Numero " &
      '" 
      '
      With DataGridView1
         cmdImprimir.Enabled = .RowCount > 0
         btnImprList.Enabled = .RowCount > 0
         cmdAnular.Enabled = .RowCount > 0 And Not SoloLect And (LGR Or Anular)
         cmdFinalizar.Enabled = .RowCount > 0 And Not SoloLect And (LGR Or Finalizar)
         btnActualizar.Enabled = .RowCount > 0 And Not SoloLect And Actualiz
      End With
      '
      SetCols()
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
                  Case "NUMERO" : .Width = 75 : .HeaderText = "Nro."
                  Case "FECHACONTRATO" : .HeaderText = "Fecha"
                  Case "PROPIETARIO" : .Visible = False
                  Case "NOMPROP" : .Width = 200 : .HeaderText = "Propietario"
                  Case "PROPIEDAD" : .Width = 85
                  Case "TIPOALQ" : .Width = 50 : .HeaderText = "T.Alq."
                  Case "DOMICILIO" : .Width = 200
                  Case "INQUILINO" : .Visible = False
                  Case "NOMINQ" : .Width = 200 : .HeaderText = "Inquilino"
                  Case "PERDDE" : .HeaderText = "Per.Desde"
                  Case "PERHTA" : .HeaderText = "Per.Hasta"
                  Case "ESTADO" : .Visible = False
                  Case "DESCEST" : .HeaderText = "Estado"
                  Case "TEXTO" : .HeaderText = "Detalle"
                  Case "ESCDESCRIP" : .HeaderText = "Escalonam."
                  Case "MESESESC" : .HeaderText = "Mes(es)"
                  Case "INCREMENTO" : .HeaderText = "Imp./ %"
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
            cmdImprimir.Enabled = True
            cmdAnular.Enabled = True And Not SoloLect And (LGR Or Anular)
            cmdFinalizar.Enabled = True And Not SoloLect And (LGR Or Finalizar)
            btnActualizar.Enabled = True And Not SoloLect And Actualiz
         End If
      End With
   End Sub
   '
   Private Sub cmdImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImprimir.Click
      '
      Dim cCtto As String
      Dim cConv As String
      Dim Estado As Byte
      '
      With DataGridView1
         If .RowCount = 0 Then
            Exit Sub
         Else
            cCtto = .SelectedCells(.Columns("Texto").Index).Value & ""
            cConv = .SelectedCells(.Columns("Convenio").Index).Value & ""
            Estado = Val(.SelectedCells(.Columns("Estado").Index).Value & "")
         End If
      End With
      '
      If Estado = 2 Then
         Mensaje("CttoAnulado")
      Else
         AbrirDocWord(cCtto)
         If cConv <> "" Then
            AbrirDocWord(cConv)
         End If
      End If
      '
   End Sub
   '
   Private Sub cmdAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAnular.Click
      '
      Dim Ok As Boolean
      Dim Estado As Byte
      Dim Numero As Integer
      Dim PerDde, PerHta As String
      Dim Propiedad, Inquilino As Int32
      '
      With DataGridView1
         If .RowCount = 0 Then
            Exit Sub
         Else
            Estado = Val(.SelectedCells(.Columns("Estado").Index).Value & "")
            Numero = Val(.SelectedCells(.Columns("Numero").Index).Value & "")
            PerDde = .SelectedCells(.Columns("PerDde").Index).Value & ""
            PerHta = .SelectedCells(.Columns("PerHta").Index).Value & ""
            Propiedad = Val(.SelectedCells(.Columns("Propiedad").Index).Value & "")
            Inquilino = Val(.SelectedCells(.Columns("Inquilino").Index).Value & "")
         End If
      End With
      '
      Select Case Estado
         Case 0
            Ok = True
         Case 1
            Ok = MsgConfirma(Traducir("CttoFinaliz") & ". " & Traducir("AnulaContrato") & " ?")
         Case 2
            MensajeTrad("CttoYaAnulado")
      End Select
      '
      If Ok Then
         If PuedeAnular(Numero, Propiedad, Inquilino, PerDde, PerHta) Then
            If MsgBox(Traducir("AnulaContrato") & " Nº " & Numero,
                      vbQuestion & vbYesNo) = vbYes Then
               '
               Trn = Cn.BeginTransaction
               If AnulFinCtto(Numero, 2, "01/" & PerDde, Trn) Then
                  Trn.Commit()
                  ActData()
               Else
                  Trn.Rollback()
               End If

            End If
         End If
      End If
      '
   End Sub
   '
   Private Sub optParticular_CheckedChanged(sender As Object, e As EventArgs) Handles optParticular.CheckedChanged, optComercial.CheckedChanged, optPC.CheckedChanged
      ActData()
   End Sub
   '
   Private Sub CmdFinalizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFinalizar.Click
      '
      Dim Final As Boolean
      Dim Estado As Byte
      Dim Numero As Integer
      Dim PerDde As String
      '
      With DataGridView1
         If .RowCount = 0 Then
            Exit Sub
         Else
            Estado = Val(.SelectedCells(.Columns("Estado").Index).Value & "")
            Numero = Val(.SelectedCells(.Columns("Numero").Index).Value & "")
            PerDde = Val(.SelectedCells(.Columns("PerDde").Index).Value & "")
         End If
      End With
      '
      If Estado = 0 Then
         Final = True
      ElseIf Estado = 1 Then
         Final = MsgConfirma("Contrato ya finalizado. Finaliza nuevamente ?")
      ElseIf Estado = 2 Then
         MensajeTrad("CttoAnulado")
      End If
      '
      If Final Then
         Dim Frm As New frmContratoFin
         With Frm
            .Contrato = Numero
            .ShowDialog(Me)
            If Format(.FechaFin, "yyyyMMdd") > "19000101" Then
               Trn = Cn.BeginTransaction
               If AnulFinCtto(Numero, 1, .FechaFin, Trn) Then
                  Trn.Commit()
                  ActData()
               Else
                  Trn.Rollback()
               End If
            End If
         End With
      End If
      '
   End Sub
   '
   Private Function PuedeAnular(ByVal NroCtto, ByVal Propiedad, ByVal Inquilino, ByVal PerDesde, ByVal PerHasta) As Boolean
      '
      If Not IsNothing(CapturaDato(Cn, "FactInq", "Propiedad", "Propiedad = " & Propiedad & " And Inquilino = " & Inquilino & " And Liquidado <> 0 And Periodo >= '" & PerDesde & "' AND Periodo <= '" & PerHasta & "'")) Then
         MensajeTrad("CttoConLiq")
         Return False
      End If
      '
      If Not IsNothing(CapturaDato(Cn, "CompraOtr", "Pagado", "Comprob = '" & cmpInt & "' AND Sucursal = " & prmSucursal & " AND Numero = " & NroCtto & " AND Pagado <> 0")) Then
         MensajeTrad("SelCttoPago")
         Return False
      End If
      '
      If Not IsNothing(CapturaDato(Cn, "CompraOtr", "Pagado", "Comprob = '" & cmpInt & "' AND Sucursal = " & prmSucursal & " AND Numero = " & NroCtto & " AND Liquidado <> 0")) Then
         MensajeTrad("SelCttoLiq")
         Return False
      End If
      '
      Return True
      '
   End Function
   '
   Private Sub cmdAlta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAlta.Click
      If TienePermiso(Cn, Uid, frmMenu.mAltaContrato.Name) Then
         Dim Frm As New frmContrato
         With Frm
            .ShowDialog(Me)
            ActData()
         End With
      End If
   End Sub
   '
   Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
      Dim Numero As Int32
      With DataGridView1
         If .RowCount = 0 Then
            Exit Sub
         Else
            Estado = Val(.SelectedCells(.Columns("Estado").Index).Value & "")
            If Estado <> 0 Then
               Exit Sub
            End If
            Numero = Val(.SelectedCells(.Columns("Numero").Index).Value & "")
         End If
      End With
      Dim frm As New FrmContratoAct
      With frm
         '.MdiParent = frmMenu
         .Numero = Numero
         .ShowDialog(Me)
      End With
   End Sub
   '
   Private Sub optNoAct_CheckedChanged(sender As Object, e As EventArgs) Handles optNoAct.CheckedChanged, optAct.CheckedChanged, optTodos.CheckedChanged
      ActData()
   End Sub
   '
   Private Sub btnImprList_Click(sender As Object, e As EventArgs) Handles btnImprList.Click
      '
      Dim Filtro As String = "{AuxReporte.Uid} = '" & Uid & "' AND {AuxReporte.Host} = '" & NombrePC & "'"
      Dim Formulas(1, 1) As String
      Dim SubTitulo As String = ""
      '
      With Cmd
         .Connection = Cn
         .CommandText = "DELETE FROM AuxReporte WHERE Uid = '" & Uid & "' AND Host = '" & NombrePC & "'"
         .ExecuteNonQuery()
         '
         .CommandText = "INSERT INTO [AuxReporte] ( Numero, Uid, Host, Importe ) " &
                        "SELECT Numero, '" & Uid & "', '" & NombrePC & "', (SELECT MAX(Incremento) FROM ContratosAct WHERE Numero = C.Numero) FROM Contratos C , Propiedades P WHERE C.Propiedad = P.Codigo " & cWhere
         .ExecuteNonQuery()
      End With
      '
      If Propietario > 0 Then
         'Filtro = "{Contratos.Propietario} = " & Propietario & " "
         SubTitulo = "Prop.: " & cbPropietario.Text
      End If
      '
      If Inquilino > 0 Then
         'Filtro = IIf(Filtro = "", "", Filtro & " And ") & "{Contratos.Inquilino} = " & Inquilino & " "
         SubTitulo = IIf(SubTitulo = "", "", SubTitulo & ", ") & "Inq.: " & cbInquilino.Text
      End If
      '
      If Not chkTodas.Checked Then
         'Filtro = IIf(Filtro = "", "", Filtro & " And ") & "{Contratos.FechaContrato} IN CDate('" & Format(dtpDesde.Value, FormatCDATE) & "')" &
         '                                                                           " TO CDATE('" & Format(dtpHasta.Value, FormatCDATE) & "')"
         SubTitulo = IIf(SubTitulo = "", "", SubTitulo & ", ") & "Del: " & dtpDesde.Value & " al: " & dtpHasta.Value
      End If
      '
      If Estado <> -1 Then
         'Filtro = IIf(Filtro = "", "", Filtro & " AND ") & "{Contratos.Estado} = " & Estado
         SubTitulo = IIf(SubTitulo = "", "", SubTitulo & ", ") & cbEstado.Text
      End If
      '
      If Actualiz Then
         If Not optTodos.Checked Then
            'Filtro = IIf(Filtro = "", "", Filtro & " AND ") & "{Contratos.Numero} " & IIf(optAct.Checked, "", "NOT") & " IN (SELECT {ContratosAct.Numero} FROM ContratosAct WHERE {ContratosAct.Numero} = {Contratos.Numero})"
            SubTitulo = IIf(SubTitulo = "", "", SubTitulo & ", ") & IIf(optAct.Checked, "", "No ") & "Actualizados"
         End If
      End If
      '
      If Not optPC.Checked Then
         'If optParticular.Checked Then
         'Filtro = IIf(Filtro = "", "", Filtro & " AND ") & "{Propiedades.TipoAlq} = 'P'"
         SubTitulo = IIf(SubTitulo = "", "", SubTitulo & ", ") & IIf(optParticular.Checked, "Particular", "Comercial")
         'Filtro = IIf(Filtro = "", "", Filtro & " AND ") & "{Propiedades.TipoAlq} = 'C'"
         'End If
      End If
      '
      Formulas(0, 0) = "Empresa" : Formulas(0, 1) = cfgNomEmp
      Formulas(1, 0) = "Subtitulo" : Formulas(1, 1) = SubTitulo
      '
      ImprimirCrp("CttosActivos", crptToWindow, Filtro, "Contratos", Formulas)
      '
   End Sub
   '
   Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
      Me.Close()
   End Sub
   '
   Private Sub frmContratosAbm_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
      SoloLect = False
      SetRegGrid(Me, DataGridView1)
      SetRegForm(Me)
   End Sub
   '
End Class