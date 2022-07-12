Public Class frmPagosAgrCmp
   '
   'Public rsTPag As ADODB.Recordset
   Public cmpInt As String
   Public nProveedor As Long
   Public OrdenPagoId As Long
   '
   Dim Cmd As New OleDb.OleDbCommand
   Dim Propietario, Propiedad As Int32
   Dim FormLoad As Boolean = False
   '
   Private Sub frmPagosAgrCmp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      '
      GetRegForm(Me)
      TraducirForm(Me)
      '
      Cmd.Connection = Cn
      '
      dtpFecDesde.Value = Today
      dtpFecHasta.Value = Today
      '
      'Adodc1.ConnectionString = Cn
      ArmaComboItem(cbPropietario, "Propietarios", "Codigo", "Nombre", "Nombre", "(Todos)")
      '
      gbPropietario.Visible = (cmpInt = "PO")
      '
      FormLoad = True
      ActData()
      '
   End Sub
   '
   Private Sub frmPagosAgrCmp_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
      TabReturn(e.KeyChar)
   End Sub
   '
   Private Sub cbPropietario_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPropietario.SelectedIndexChanged
      With cbPropietario
         If .SelectedIndex > 0 Then
            Propietario = .SelectedValue
         Else
            Propietario = 0
         End If
         cbPropiedad.Enabled = (Propietario > 0)
         ArmaComboItem(cbPropiedad, "Propiedades", , "Domicilio", "Domicilio", "(Todas)", "Propietario = " & Propietario)
      End With
   End Sub
   '
   Private Sub cmdCargar_Click()
      If cmpInt = "PO" Then
         With frmComprasOtrAM
            .Alta = True
            .Comprob = "CP"
            .Show(Me)
         End With
      Else
         With frmComprasAM
            .Alta = True
            .Show(Me)
         End With
      End If
      ActData()
   End Sub
   '
   'Private Sub chkTodos_Click()
   'cbDescProp.Enabled = IIf(chkTodos.Value = 0, True, False)
   'ActData
   'End Sub
   '
   'Private Sub cbDescProp_Change()
   '   PintarCb(cbDescProp, LastKey)
   'End Sub
   ''
   'Private Sub cbDescProp_Click()
   '   cbPropietario.ListIndex = cbDescProp.ListIndex
   '   ActData()
   'End Sub
   '
   Private Sub cbPropiedad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPropiedad.SelectedIndexChanged
      With cbPropiedad
         If .SelectedIndex > 0 Then
            Propiedad = .SelectedValue
         Else
            Propiedad = 0
         End If
      End With
      ActData()
   End Sub
   '
   Private Sub chkTodas_CheckedChanged(sender As Object, e As EventArgs) Handles chkTodas.CheckedChanged
      dtpFecDesde.Enabled = Not chkTodas.Checked
      dtpFecHasta.Enabled = Not chkTodas.Checked
      ActData()
   End Sub
   '
   Private Sub dtpFechas_ValueChanged(sender As Object, e As EventArgs) Handles dtpFecDesde.ValueChanged, dtpFecHasta.ValueChanged
      ActData()
   End Sub
   '
   Private Sub DataGrid1_DblClick()
      'cmdAceptar_Click()
   End Sub
   '
   Private Sub cmdAgregar_Click(sender As Object, e As EventArgs) Handles cmdAgregar.Click
      '
      Dim Total As Double
      Dim Proveedor, Sucursal, Numero As Int32
      Dim Comprob, Nombre, PerIva, Tipo As String
      Dim Fecha As Date
      '
      With DataGridView1
         If .RowCount = 0 Then
            Exit Sub
         End If
         '
         Proveedor = .SelectedCells(.Columns("Proveedor").Index).Value
         Comprob = .SelectedCells(.Columns("Comprob").Index).Value
         Sucursal = .SelectedCells(.Columns("Sucursal").Index).Value
         Numero = .SelectedCells(.Columns("Numero").Index).Value
         Nombre = .SelectedCells(.Columns("Nombre").Index).Value & ""
         Fecha = .SelectedCells(.Columns("Fecha").Index).Value
         PerIva = .SelectedCells(.Columns("PerIva").Index).Value
         Tipo = .SelectedCells(.Columns("Tipo").Index).Value
         Total = .SelectedCells(.Columns("Total").Index).Value
         Propietario = .SelectedCells(.Columns("Propietario").Index).Value
         Propiedad = .SelectedCells(.Columns("Propiedad").Index).Value
         '
      End With
      'With Adodc1.Recordset
      'nTot = !Total
      'rsTPag.Open("SELECT * FROM PagosDetTmp WHERE Usuario = '" & Uid & "' AND Proveedor = " & !Proveedor & " AND Comprob = '" & !Comprob & "' AND Sucursal = " & !Sucursal & " AND numero = " & !Numero, Cn, adOpenKeyset, adLockOptimistic)
      With Cmd
         .CommandText = "INSERT INTO PagosDetTmp( Usuario, Proveedor, Sucursal, Numero, Nombre, Fecha, PerIva, Comprob, Tipo, Total, Propietario, Propiedad) " & _
                        "VALUES('" & Uid & "', " & _
                                     Proveedor & ", " & _
                                     Sucursal & ", " & _
                                     Numero & ", " & _
                               "'" & Nombre & "', " & _
                               "'" & Format(Fecha, FormatFecha) & "', " & _
                               "'" & PerIva & "', " & _
                               "'" & Comprob & "', " & _
                               "'" & Tipo & "', " & _
                                     Total & ", " & _
                                     Propietario & ", " & _
                                     Propiedad & ")"
         .ExecuteNonQuery()
      End With
      '
      ActData()
      '
   End Sub
   '
   Sub ActData()
      '
      If Not FormLoad Then Exit Sub
      '
      Dim cSql As String
      Dim wPro As String = ""
      Dim wfec As String
      Dim wTmp As String
      Dim wPrt As String
      Dim wPrd As String
      '
      If nProveedor > 0 Then
         wPro = " AND C.Proveedor = " & nProveedor
      End If
      '
      If chkTodas.Checked Then
         wfec = ""
      Else
         'If cmpINT = "PC" Then
         '   'wFec = " AND Compras.Fecha >= '" & Format(tbFecDesde, FormatFecha) & "' " & _
         '          " AND Compras.Fecha <= '" & Format(tbFecHasta, FormatFecha) & "' "
         '   wFec = " AND Compras.Fecha >= " & strFEC & Format(tbFecDesde, FormatFecha) & strFEC & _
         '          " AND Compras.Fecha <= " & strFEC & Format(tbFecHasta, FormatFecha) & strFEC
         'Else
         wfec = " AND C.Fecha >= " & strFEC & Format(dtpFecDesde.Value, FormatFecha) & strFEC & _
                " AND C.Fecha <= " & strFEC & Format(dtpFecHasta.Value, FormatFecha) & strFEC
         'End If
      End If
      '
      wTmp = " AND NOT EXISTS( SELECT * FROM PagosDetTmp WHERE Usuario = '" & Uid & "' AND Proveedor = C.Proveedor AND Comprob = C.Comprob AND Sucursal = C.Sucursal AND Numero = C.Numero) "
      '
      If Propietario <= 0 Then
         wPrt = ""
      Else
         wPrt = " AND C.Propietario = " & Propietario & " "
      End If
      '
      If Propiedad <= 0 Then
         wPrd = ""
      Else
         wPrd = " AND C.Propiedad = " & Propiedad & " "
      End If
      '
      SetRegGrid(Me, DataGridView1)
      '
      If cmpInt = "PC" Or cmpInt = "OP" Then
         cSql = "SELECT C.Fecha, C.Nombre, C.Proveedor, " & _
                " C.Sucursal, C.Numero, C.Comprob, " & _
                " C.Tipo, C.PerIva, C.Total, NULL AS Propietario, NULL AS Propiedad " & _
                "FROM Compras C " & _
                "WHERE (C.Pagado = 0 OR C.NroPago = " & OrdenPagoId & ") " & _
                wPro & wfec & wTmp & _
                "ORDER BY C.Fecha, C.FechaMod DESC"
      Else
         cSql = "SELECT C.Fecha, C.Nombre, C.Proveedor, " & _
                " C.Sucursal, C.Numero, C.Comprob, C.Detalle, " & _
                " '-' as Tipo, '-' as PerIva, C.Total, C.Propietario, P.Domicilio, C.Propiedad " & _
                "FROM (CompraOtr C LEFT JOIN Propiedades P ON C.Propiedad = P.Codigo) " & _
                "WHERE (C.Pagado = 0 OR C.NroPago = " & OrdenPagoId & ") " & _
                wPro & wfec & wTmp & wPrt & wPrd & _
                "ORDER BY C.Fecha, C.FechaMod DESC"
      End If
      '
      LlenarGrid(DataGridView1, cSql)
      '
      'iif(PagosDetTmp.Proveedor = Compras.Proveedor, '*', ' ') as Sel,
      '"LEFT JOIN PagosDetTmp " & _
      '"ON (Compras.Proveedor = PagosDetTmp.Proveedor AND " & _
      '"ON Compras.Sucursal = PagosDetTmp.Sucursal AND " & _
      '"ON Compras.Numero = PagosDetTmp.Numero AND " & _
      '"ON PagosDetTmp.Usuario = '" & uid & "' "
      '
      'Adodc1.Refresh()
      '
      With DataGridView1
         For Each Col As DataGridViewColumn In .Columns
            With Col
               Select Case .Name
                  Case "Sel" : .Width = 40
                  Case "Comprob" : .Width = 75 : .HeaderText = "Cpte."
                  Case "Tipo" : .Width = 50
                  Case "Sucursal" : .Width = 75
                  Case "Numero" : .Width = 100
                  Case "Fecha" : .Width = 110
                  Case "PerIva" : .Width = 100 : .HeaderText = "Per.Iva."
                  Case "Nombre" : .Width = 300 : .HeaderText = "Proveedor"
                  Case "Total" : .Width = 100 ': .NumberFormat = "#,##0.00"
                  Case "Domicilio" : .Width = 300
                  Case "Detalle" : .Width = 300
                  Case Else : .Visible = False
               End Select
            End With
         Next Col
      End With
      '
      GetRegGrid(Me, DataGridView1)
      '
   End Sub
   '
   Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
      Me.Close()
   End Sub
   '
   Private Sub Form_Unload(Cancel As Integer)
      SetRegGrid(Me, DataGridView1)
      SetRegForm(Me)
   End Sub
   '
End Class