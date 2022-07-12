Public Class frmCobrosABM
   '
   Public CobroComp As Boolean   'Nuevo 20/08/2005.
   Public Señas As Boolean
   '
   Dim Trn As OleDb.OleDbTransaction
   Dim Cmd As New OleDb.OleDbCommand
   Dim Cm2 As New OleDb.OleDbCommand
   Dim Drd As OleDb.OleDbDataReader
   '
   Dim Tipo As String
   Dim Sucursal As Int16
   Dim Numero As Int32
   '
   Dim Estado As Int16
   Dim Liquid As Boolean
   Dim nSubTotal As Double
   Dim nIntereses As Double
   Dim nTotal As Double
   '
   Dim AlicIva1 As Single
   Dim AlicIva2 As Single
   Dim i As Integer
   '
   Dim nTipoMov As Integer
   Dim cImput As String
   '
   Dim cCtaCaja As String
   Dim cCtaBanco As String
   Dim cCtaInt As String
   '
   Dim cmpInt As String
   Dim FormLoad As Boolean = False
   '
   Const estEMIT = 1
   '
   Private Sub frmCobrosABM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      '
      GetRegForm(Me)
      '
      'TraducirForm(Me)
      '
      If CobroComp Then
         cmpInt = "CB"
      Else
         cmpInt = "CO"
         If Señas Then
            Me.Text = "Señas"
         End If
      End If
      '
      Cmd.Connection = Cn
      '
      If SisContable Then
         If Not CaptCtasCaja(prmNroCaja, cCtaCaja, "") Then
            DeshabForm(Me)
         Else
            If Not CaptCtasConc(cfgCodigoInt, "", cCtaInt, "") Then
               DeshabForm(Me)
            End If
         End If
      End If
      '
      ArmaComboItem(cbCliente, "Clientes", , "Nombre", "Nombre", "(Todos)")
      '
      ArmaComboItem(cbEstado, "EstPagos", "Estado", , , "(Todos)")
      '
      dtpDesde.Value = Today
      dtpHasta.Value = Today
      '
      cmdDevolver.Visible = Señas
      '
      FormLoad = True
      '
      ActData()
      '
   End Sub
   '
   Private Sub frmCobrosABM_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
      TabReturn(e.KeyChar)
   End Sub
   '
   Private Sub DataGrid1_Click()
      ActivaCtrl()
   End Sub
   '
   Private Sub DataGrid1_RowColChange(LastRow As Object, ByVal LastCol As Integer)
      ActivaCtrl()
   End Sub
   '
   Private Sub cbNombre_Click() Handles cbCliente.TextChanged
      ActData()
   End Sub
   '
   Private Sub tbFechas_Change() Handles dtpDesde.ValueChanged, dtpHasta.ValueChanged
      ActData()
   End Sub

   Private Sub tbFecHasta_Change()
      ActData()
   End Sub
   '
   Private Sub btnDetalle_Click(sender As Object, e As EventArgs) Handles cmdDetalle.Click
      '
      With DataGridView1
         If .RowCount > 0 Then
            '
            Tipo = .SelectedCells(.Columns("Tipo").Index).Value
            Sucursal = .SelectedCells(.Columns("Sucursal").Index).Value
            Numero = .SelectedCells(.Columns("Numero").Index).Value
            '
            With frmCobrosOtr
               .SoloVer = True
               .Tipo = Tipo
               .Sucursal = Sucursal
               .Numero = Numero
               .ShowDialog(Me)
            End With
            '
         End If
      End With
      '
   End Sub
   '
   Private Sub cmdDevolver_Click(sender As Object, e As EventArgs) Handles cmdDevolver.Click
      '
      With DataGridView1
         If .RowCount > 0 Then
            '
            Tipo = .SelectedCells(.Columns("Tipo").Index).Value
            Sucursal = .SelectedCells(.Columns("Sucursal").Index).Value
            Numero = .SelectedCells(.Columns("Numero").Index).Value
            '
            Dim Frm As New frmSeñasAM
            With Frm
               .Tipo = Tipo
               .Sucursal = Sucursal
               .Numero = Numero
               .Devolucion = True
               .ShowDialog(Me)
               ActData()
            End With
            '
         End If
      End With
      '
   End Sub
   '
   Private Sub cmdAlta_Click(sender As Object, e As EventArgs) Handles cmdAlta.Click
      AltaMod(True)
   End Sub
   '
   Private Sub cmdAnular_Click(sender As Object, e As EventArgs) Handles cmdAnular.Click
      '
      With DataGridView1
         '
         If .RowCount = 0 Then
            MensajeTrad("DSelItem")
         Else
            '
            Estado = .SelectedCells(.Columns("Estado").Index).Value
            Tipo = .SelectedCells(.Columns("Tipo").Index).Value
            Sucursal = .SelectedCells(.Columns("Sucursal").Index).Value
            Numero = .SelectedCells(.Columns("Numero").Index).Value
            Liquid = .SelectedCells(.Columns("Liquidado").Index).Value
            '
            If Estado = 1 Then
               MensajeTrad("CobroConf")
            ElseIf Estado = 2 Then
               MensajeTrad("CobroYaAnul")
            ElseIf Liquid Then
               MensajeTrad("CobroLiquid")
            Else
               If MsgConfirma("Anula " & cmpInt & "-" & Numero) Then
                  AnularCobro(cmpInt, Tipo, Sucursal, Numero, CobroComp)
                  ActData()
               End If
            End If
            '
         End If
         '
      End With
      '
   End Sub
   '
   Private Sub cmdEdicion_Click()
      With DataGridView1
         If .RowCount > 0 Then
            ActTemporal()
            AltaMod(False)
         End If
      End With
   End Sub
   '
   Private Sub AltaMod(Alta As Boolean)
      '
      'Dim nNumero As Long
      Dim Nombre As String
      '
      If Not Alta Then
         With DataGridView1
            If .RowCount > 0 Then
               Numero = .SelectedCells(.Columns("Numero").Index).Value
               Nombre = .SelectedCells(.Columns("Nombre").Index).Value & ""
            End If
         End With
      End If
      '
      If CobroComp Then
         '* With frmCobros
         '   .Alta = Alta
         '   .cmpInt = cmpInt
         '   .Showdialog(Me)
         'End With
      Else
         If Señas Then
            With frmSeñasAM
               .ShowDialog(Me)
            End With
         Else
            With frmCobrosOtr
               .ShowDialog(Me)
            End With
         End If
         ActData()
      End If
      '
   End Sub
   '
   Private Sub cbEstado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbEstado.SelectedIndexChanged

      With cbEstado
         If .SelectedIndex > 0 Then
            Estado = .SelectedValue
         Else
            Estado = -1
         End If
      End With
      '
      ActData()
      '
   End Sub
   '
   Sub ActData()
      '
      If Not formload Then Exit Sub
      '
      Dim cWhere As String = ""
      Dim cSQL As String
      '
      If Not CobroComp Then
         cWhere = "WHERE CO.CacId IS NULL "
      End If
      '
      If cbCliente.SelectedIndex > 0 Then
         cWhere = cWhere & IIf(cWhere = "", " WHERE ", " AND ") & "CO.Cliente = " & cbCliente & " "
      End If
      '
      If Not chkFecTodas.Checked Then
         cWhere = cWhere & IIf(cWhere = "", " WHERE ", " AND ") & " CO.Fecha >= " & strFEC & Format(dtpDesde.Value, FormatFecha) & strFEC & " " & _
                                                       " AND CO.Fecha <= " & strFEC & Format(dtpHasta.Value, FormatFecha) & strFEC & " "
      End If
      '
      If Estado >= 0 Then
         cWhere = cWhere & IIf(cWhere = "", " WHERE ", " AND ") & " CO.Estado = " & Estado & " "
      End If
      '
      If Not CobroComp Then
         cWhere = cWhere & IIf(cWhere = "", " WHERE ", " AND ") & " D.Concepto " & IIf(Señas, "=", "<>") & " '" & cfgCodigoSen & "' "
      End If
      '
      cSQL = "SELECT CO.Fecha, CO.Tipo, CO.Sucursal, CO.Numero, " & IIf(CobroComp, "C", "CO") & ".Nombre, CO.Total, CO.Detalle, CO.Estado, CO.Efectivo, CO.Cheques, CO." & IIf(CobroComp, "CobTransf", "CooTransf") & " AS Transf, CO.Liquidado " & _
                                "FROM (" & IIf(CobroComp, "Cobros", "CobrosOtr") & " CO LEFT JOIN Clientes C " & _
                                "ON CO.Cliente = C.Codigo) " & _
                                IIf(CobroComp, "", " LEFT JOIN CobOtrDet D ON CO.Tipo = D.Tipo AND CO.Sucursal = D.Sucursal AND CO.Numero = D.Numero ") & _
                                cWhere & _
                                "ORDER BY CO.Fecha, CO.Sucursal, CO.Numero"
      '
      LlenarGrid(DataGridView1, cSQL)
      '
      SetCols()
      '
      DataGrid1_Click()
      '
   End Sub
   '
   Private Sub SetCols()
      '
      With DataGridView1
         For Each cCol As DataGridViewColumn In .Columns
            Select Case cCol.Name
               Case "Tipo"
                  cCol.Width = 50
               Case "Sucursal"
                  cCol.Width = 75
               Case "Numero"
                  cCol.Width = 100
               Case "Fecha"
                  cCol.Width = 110
               Case "Nombre"
                  cCol.Width = 350
                  cCol.HeaderText = "Cliente"
               Case "Total"
                  cCol.Width = 100
                  'cCol.NumberFormat = "#,##0.00"
               Case "Detalle"
                  cCol.Width = 300
               Case "Efectivo"
               Case "Cheques"
               Case "Transf"
               Case Else
                  cCol.Visible = False
            End Select
         Next cCol
      End With
      '
   End Sub
   '
   Private Sub ActTemporal()
      '
      Dim Tip As String = ""
      Dim Suc As Integer
      Dim Nro As Long
      '
      With DataGridView1
         If .RowCount > 0 Then
            Tip = .SelectedCells(.Columns("Tipo").Index).Value
            Suc = .SelectedCells(.Columns("Sucursal").Index).Value
            Nro = .SelectedCells(.Columns("Numero").Index).Value
         End If
      End With
      '
      With Cmd
         .CommandText = "DELETE FROM CobrosDetTmp WHERE Usuario = '" & Uid & "'"
         .ExecuteNonQuery()
         '
         .CommandText = "SELECT * FROM CobrosDet WHERE Tipo = '" & Tip & "' AND Sucursal = " & Suc & " AND Numero = " & Nro
         Drd = .ExecuteReader
      End With
      '
      Cm2.Connection = Cn
      '
      With Drd
         If .Read Then
            Do While !Tipo = Tip And _
                     !Sucursal = Suc And _
                     !Numero = Nro
               '
               'Cm2.CommandText = "SELECT COUNT(1) FROM Ventas WHERE Tipo = '" & !Tipo & "' AND Sucursal = " & !Sucursal & " AND Numero = " & !Numero
               'If Cm2.ExecuteScalar() = 0 Then
               'If rsCVta.EOF Then
               '
               'Else
               '
               Cm2.CommandText = "INSERT INTO CobrosDetTmp( Usuario, Cliente, Tipo, Sucursal, Numero, Nombre, Fecha, PerIva, Comprob, Total) " & _
                                 "SELECT '" & Uid & "', " & !Cliente & ", '" & !Tipo & "', " & !Sucursal & ", " & !Numero & ", Nombre, Fecha, PerIva, Comprob, Total " & _
                                 "FROM Ventas " & _
                                 "WHERE Tipo = '" & !Tipo & "' AND Sucursal = " & !Sucursal & " AND Numero = " & !Numero
               Cm2.ExecuteNonQuery()
               '
               '
               '      rsTcob.AddNew()
               '      rsTcob!Usuario = Uid
               '      rsTcob!Cliente = !Cliente
               '      rsTcob!Tipo = !Tipo
               '      rsTcob!Sucursal = !Sucursal
               '      rsTcob!Numero = !Numero
               '      rsTcob!Nombre = rsCVta!Nombre
               '      rsTcob!Fecha = rsCVta!Fecha
               '      rsTcob!PerIva = rsCVta!PerIva
               '      rsTcob!Comprob = rsCVta!Comprob
               '      rsTcob!Total = rsCVta!Total
               '      rsTcob.Update()
               '      rsTcob.Close()
               '      End If
               '.MoveNext()
               'rsCVta.Close()
               'If .EOF Then Exit Do
            Loop
         End If
         .Close()
      End With
      '
   End Sub
   '
   Private Sub cmdImprimir_Click(sender As Object, e As EventArgs) Handles cmdImprimir.Click
      '
      'Dim Reporte As String
      'Dim Filtro As String
      Dim Titulo As String
      Dim SonPesos As String
      Dim Tipo As String = ""
      Dim Sucursal As Int16
      Dim Numero As Int32
      Dim Efectivo, Cheques As Double
      '
      '* If Index = 0 Then
      Titulo = "Recibo"
      With DataGridView1
         If .RowCount > 0 Then
            Tipo = .SelectedCells(.Columns("Tipo").Index).Value
            Sucursal = .SelectedCells(.Columns("Sucursal").Index).Value
            Numero = .SelectedCells(.Columns("Numero").Index).Value
            Efectivo = .SelectedCells(.Columns("Efectivo").Index).Value
            Cheques = .SelectedCells(.Columns("Cheques").Index).Value
         End If
         '
         SonPesos = Numero_a_Texto(Efectivo + Cheques)
         '
         Trn = Cn.BeginTransaction
         With Cmd
            .Transaction = Trn
            .CommandText = "DELETE FROM LiqAux WHERE Usuario = '" & Uid & "'"
            .ExecuteNonQuery()
            .CommandText = "INSERT INTO LiqAux( Usuario, Recibe, SonPesos, Numero) " & _
                           "VALUES('" & Uid & "', '" & cfgNomEmp & "', '" & SonPesos & "', " & Numero & ")"
            .ExecuteNonQuery()
         End With
         Trn.Commit()
         '
         ImprimirRboOtr(Tipo, Sucursal, Numero)
         '
      End With
      '
      'Else
      'Titulo = "Listado de Cobros"
      'Reporte = "CobrosOtr"
      'Filtro = IIf(cbCliente.SelectedIndex = 0, "", " AND {CobrosOtr.Nombre} = '" & cbCliente.Text & "'")
      'If Not chkFecTodas.Checked Then
      '   Filtro = IIf(Filtro = "", "", Filtro & " AND ") & "{CobrosOtr.Fecha} IN CDATE('" & Format(dtpDesde.Value, FormatCDATE) & "')" & _
      '                                                                 "      TO CDATE('" & Format(dtpHasta.Value, FormatCDATE) & "') "
      'End If
      ''
      'ImprimirCrp(Reporte, crptToWindow, Filtro, Titulo)
      ''
      'End If
      '
   End Sub
   '
   'Private Sub cmdImprimir_Click(Index As Integer)
   '   '
   '   Dim Reporte As String
   '   Dim Filtro As String
   '   Dim Titulo As String
   '   Dim SonPesos As String
   '   '
   '   If Index = 0 Then
   '      Titulo = "Recibo"
   '      With Adodc1.Recordset
   '         SonPesos = Escribe_Numero(!Efectivo + !Cheques)
   '         '
   '         Cn.BeginTrans
   '         Cn.Execute "DELETE FROM LiqAux WHERE Usuario = '" & Uid & "'"
   '         Cn.Execute "INSERT INTO LiqAux( Usuario, Recibe, SonPesos, Numero) " & _
   '                    "VALUES('" & Uid & "', '" & cfgNomEmp & "', '" & SonPesos & "', " & !Numero & ")"
   '         Cn.CommitTrans
   '         '
   '         ImprimirRboOtr !Tipo, !Sucursal, !Numero
   '      End With
   '      '
   '   Else
   '      Titulo = "Listado de Cobros"
   '      Reporte = "CobrosOtr"
   '      Filtro = IIf(cbNombre.ListIndex = 0, "", " AND {CobrosOtr.Nombre} = '" & cbNombre & "'")
   '      If chkFecTodas = 0 Then
   '         Filtro = IIf(Filtro = "", "", Filtro & " AND ") & "{CobrosOtr.Fecha} IN CDATE('" & Format(tbFecDesde, FormatCDATE) & "')" & _
   '                                                           "      TO CDATE('" & Format(tbFecHasta, FormatCDATE) & "') "
   '      End If
   '      '
   '      ImprimirCrp Reporte, crptToWindow, , Filtro, Titulo
   '      '
   '   End If
   '   '
   'End Sub
   '
   Private Sub ActivaCtrl()
      '
      Dim Liq As Boolean
      Dim Est As Byte
      '
      With DataGridView1
         If .RowCount = 0 Then
            cmdDevolver.Enabled = False
            cmdDetalle.Enabled = False
            cmdAnular.Enabled = False
            'cmdEdicion.Enabled = False
            cmdImprimir.Enabled = False
         Else
            Liq = .SelectedCells(.Columns("Liquidado").Index).Value
            Est = .SelectedCells(.Columns("Estado").Index).Value
            '
            cmdDevolver.Enabled = Señas And Not Liq And Est = 0 And LGR
            cmdDetalle.Enabled = True
            cmdAnular.Enabled = LGR
            cmdImprimir.Enabled = True
         End If
      End With
   End Sub
   '
   Private Sub chkTodas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFecTodas.CheckedChanged
      dtpDesde.Enabled = Not chkFecTodas.Checked
      dtpHasta.Enabled = Not chkFecTodas.Checked
      ActData()
   End Sub
   '
   Private Sub cmdSalir_Click(sender As Object, e As EventArgs) Handles cmdSalir.Click
      Me.Close()
   End Sub
   '
   Private Sub frmCobrosABM_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
      SetRegForm(Me)
      'frmCobrosABM = Nothing
   End Sub
   '
End Class