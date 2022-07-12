Public Class FrmVentasAMProd
   '
   Public EmpresaId As Integer
   Public TablaAct As String
   Public Cliente As Long
   Public CompraRtoId As Long
   '
   Public Remitos As Boolean
   Public Facturar As Boolean
   Public Productos As Boolean
   Public Todos As Boolean
   Public Alta As Boolean
   Public Unico As Boolean
   Public Vencidas As Boolean
   Public Devolucion As Boolean
   Public MantenerAbierto As Boolean
   '
   Public NoModCant As Boolean
   Public Imput As String
   Public Pedido As Boolean
   '
   Public Renglon As Integer
   Public Proveedor As Long
   Public Producto As Long
   Public Partida As String
   '
   Public Descrip As String = ""
   Public Cantidad As Double = 0
   Public Precio As Double = 0
   Public ImpInt As Double
   Public Bonificacion As String
   Public FechaVenc As Date
   Public EgresoId As Long
   Public Margen As Single
   Public Letra As String
   Public BonifExtra As String
   '
   Dim Trn As OleDb.OleDbTransaction
   Dim Cmd As New OleDb.OleDbCommand
   '
   Dim Sucursal As Int16 = 0
   Dim PrUnit As Double
   Dim SubTotal As Double
   Dim Rubro As String
   Dim Costo As Double
   Dim AlicIva As String
   Dim AlicuoIva As Single
   '
   Dim FormLoad As Boolean = False
   '
   Private Sub FrmVentasAMProd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      '
      GetRegForm(Me)
      '
      Cmd.Connection = cn
      '
      '*optBruto.Checked = regDefPrFinal
      '
      tbCodigo.Text = CapturaDato(cn, "Productos", "CodProd", "Producto = " & Producto)
      tbDescrip.Text = Descrip
      tbPartida.Text = Partida
      If Alta Then
         tbCantidad.Text = ""
      Else
         tbCantidad.Text = Format(Cantidad, cfgFormatoCn)
      End If
      tbCantidad.Enabled = Not NoModCant
      tbPrecio.Text = Format(Precio, cfgFormatoPr)
      tbPrecio.Enabled = cfgModPrecioVta And Letra <> "B"
      tbPrecioFin.Enabled = cfgModPrecioVta And Letra = "B"
      tbBonif.Text = Bonificacion
      If Imput = "" Then
         Imput = "D"
      End If
      '
      If Not cfgSolPartida And Alta Then
         tbPartida.Text = "-"
      End If
      '
      ArmaComboItem(cboSucursal, "Sucursales", "Sucursal", , , "(Seleccionar)", , , , , prmSucursal)
      '
      If Alta Then
         ArmaCombo(cboRubro, "Descrip", "Rubros", "Descrip", "RubroPadre = '' OR RubroPadre IS NULL", , "(Todos)")
      End If
      '
      If Letra = "B" Then
         'lblPrecio.Text = "Precio Final $"
         '*optBruto.Checked = True
         '*optBruto.Enabled = False
         '*optNeto.Enabled = False
      End If
      '
      'btnAltaProd.Enabled = TienePermiso(cn, Uid, frmMenu.mProductosABM.Name)
      '
      FormLoad = True
      ActData()
      '
      With DataGridView1
         If .RowCount = 0 Then
            If cfgSolPartida Then
               MsgBox("No hay Partidas disponibles", vbInformation)
               Exit Sub
            End If
         Else
            ' row = 1
         End If
      End With
      '
      If Alta Then
         VerDatos()
      Else
         tbBuscar.Enabled = False
         Me.DataGridView1.Enabled = False
         VerDatos()
      End If
      '
      'chkAprox.Checked = GetConfigUsu(Me, chkAprox)
      '
   End Sub
   '
   Private Sub tbBuscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbBuscar.TextChanged
      ActData()
   End Sub

   Private Sub ActData()
      '
      Dim cSQL As String = ""
      Dim wFec As String = ""
      Dim cWhere As String = ""
      Dim cWher2 As String = ""
      Dim cLike As New Collection
      Dim DescProd As String
      Dim i As Int16
      '
      If Not FormLoad Then Exit Sub
      '
      Try
         '
         'wFec = IIf(Vencidas, "", "AND (A.FechaVenc IS NULL OR A.FechaVenc > " & strFEC & Format(Of Date, FormatFecha)() & strFEC & ") ")
         If tbBuscar.Text = "" Then
            cLike.Add("''")
         Else
            If cfuBusqInt Then
               cLike = ArmaLikeBuscar(tbBuscar.Text, True)
            Else
               cLike.Add("'" & tbBuscar.Text & "%'")
            End If
         End If
         '
         DescProd = IIf(cfgSumDescRubro, "R.Descrip + ' ' + ", "") + "P.Descrip"
         '
         If Alta Then
            cWhere = " AND P.Producto <> 0 "
            If CompraRtoId <> 0 Then
               cWhere = cWhere & " AND EXISTS( SELECT Partida FROM ComprasRtosDet WHERE CompraRtoId = " & CompraRtoId & " AND Producto = P.Producto " & IIf(cfgSolPartida, "AND Partida = A.Partida", "") & ") "
            End If
            If Rubro <> "" Then
               cWhere = cWhere & " AND P.Rubro = '" & Rubro & "' "
            End If
            If Not prmVerTodosProd Then
               For i = 1 To cLike.Count
                  If cLike(i) <> "''" Then
                     cWhere = IIf(cWhere = "", " ", cWhere & " AND ") & "(P.Descrip LIKE " & cLike(i) & " OR P.CodProd LIKE " & cLike(i) & ") "
                  Else
                     cWhere = IIf(cWhere = "", " ", cWhere & " AND ") & " P.Producto = 1 "
                  End If
               Next i
            End If
         Else
            cWhere = " AND P.Producto = " & Producto & " "
            If Not Pedido Then
               cWher2 = " AND A.Partida = '" & Partida & "' "
            End If
         End If
         '
         If Devolucion Then
            cSQL = "SELECT P.CodProd, P.Descrip, D.Producto, D.Partida, " &
                   "       D.Cantidad AS Saldo, D.Proveedor, P.CostoNeto, D.Precio, 0 AS ImpInt, '' AS Bonificacion, P.AlicIva " &
                   "FROM Egresos E, EgresosDet D, Productos P " &
                   "WHERE E.EgresoID = D.EgresoID " &
                   "  AND D.EgresoID = " & EgresoId &
                   "  AND D.Producto = P.Producto "
         Else
            If Pedido Then
               cSQL = "SELECT P.CodProd, PR.Nombre, " & DescProd & " AS Descrip, P.Producto, " &
                      "       P.Proveedor, NULL AS Partida, NULL AS FechaVenc, " &
                      "       P.CostoNeto, P.Precio, P.Bonificacion, 0 AS Saldo, P.ImpInt, (SELECT TOP 1 '*' FROM " & TablaAct & " WHERE CodPRod = P.CodProd) AS Sel, P.AlicIva " &
                      "FROM Productos P LEFT JOIN Proveedores PR " &
                      "  ON P.Proveedor = PR.Proveedor, Rubros R " &
                      "WHERE P.Inactivo = 0 " & cWhere &
                      "  AND P.Rubro = R.Rubro " &
                      " ORDER BY P.CodProd"
            Else
               If cfgSolPartida Then
                  If cfgEgrSinStk Then
                     cSQL = "SELECT P.CodProd, PR.Nombre, " & DescProd & " AS Descrip, P.Producto, " &
                            "       A.Proveedor, A.Partida, A.FechaVenc, " &
                            "       P.CostoNeto, P.Precio, P.Bonificacion, A.Saldo, P.ImpInt, P.AlicIva " &
                            "FROM Productos P LEFT JOIN ( Partidas A LEFT JOIN Proveedores PR " &
                            "  ON A.Proveedor = PR.Proveedor) " &
                            "  ON P.Producto = A.Producto " & wFec & cWher2 &
                            " AND A.EmpresaId = " & EmpresaId &
                            " AND A.Sucursal = " & Sucursal &
                            ", Rubros R " &
                            "WHERE P.Inactivo = 0 " & cWhere &
                            "  AND P.Rubro = R.Rubro " &
                            " ORDER BY P.Descrip, A.FechaVenc"
                  Else
                     cSQL = "SELECT P.CodProd, " & DescProd & " AS Descrip, A.Producto, " &
                            "       A.Partida, A.FechaVenc, " &
                            "       A.Saldo, A.Proveedor, P.CostoNeto, P.Precio, P.Bonificacion, P.ImpInt, P.AlicIva " &
                            "FROM Partidas A INNER JOIN (Productos P " &
                            " INNER JOIN Rubros ON P.Rubro = Rubros.Rubro)" &
                            "   ON A.Producto = P.Producto " &
                            "WHERE A.Sucursal = " & Sucursal &
                            "  AND A.EmpresaId = " & EmpresaId &
                            "  AND A.Saldo > 0 " & wFec & cWhere &
                            " ORDER BY P.Descrip, A.FechaVenc"
                  End If
               Else
                  cSQL = "SELECT P.CodProd, P.CodProv, PR.Nombre, " & DescProd & " AS Descrip, P.Producto, " &
                         "       P.Proveedor, NULL AS Partida, NULL AS FechaVenc, " &
                         "       P.CostoNeto, P.Precio, P.Bonificacion, S.Cantidad, S.CantDisp AS Saldo, P.ImpInt, (SELECT TOP 1 '*' FROM " & TablaAct & " WHERE CodPRod = P.CodProd) AS Sel, P.AlicIva " &
                         "FROM Rubros R INNER JOIN Productos P ON R.Rubro = P.Rubro " &
                         " LEFT JOIN Proveedores PR ON P.Proveedor = PR.Proveedor " &
                         " LEFT JOIN Stock S ON P.Producto = S.Producto AND S.EmpresaId = " & EmpresaId & " AND S.Sucursal = " & Sucursal & " " &
                         "WHERE P.Inactivo = 0 " & cWhere &
                         IIf(cfgEgrSinStk, "", " AND S.Cantidad > 0 ") &
                         " ORDER BY P.Descrip"
               End If
            End If
         End If
         '
         SetRegGrid(Me, DataGridView1)
         '
         LlenarGrid(Me.DataGridView1, cSQL)
         '
         btnAceptar.Enabled = IIf(Me.DataGridView1.RowCount > 0, True, False)
         '
         SetCols()
         VerDatos()
         '
         GetRegGrid(Me, DataGridView1)
         '
      Catch
         Dim st As New StackTrace(True)
         MensageError(st, Me.Name, Err.Description)
      End Try
      '
   End Sub
   '
   Private Sub SetCols()
      With DataGridView1
         For Each cCol As DataGridViewColumn In .Columns
            With cCol
               Select Case UCase(.Name)
                  Case "DESCRIP" : .HeaderText = "Descripción" : .Width = 125
                  Case "CODPROD" : .HeaderText = "Código" : .Width = 50
                  Case "CODPROV" : .HeaderText = "C.Prov." : .Width = 50
                  Case "NOMBRE" : .HeaderText = "Proveedor" : .Width = 50
                  Case "PARTIDA" : .Visible = cfgSolPartida : .Width = 50
                  Case "FECHAVENC" : .HeaderText = "Fecha Vto." : .DefaultCellStyle.Format = "MM/yyyy" : .Visible = cfgSolFecVenc : .Width = 50
                  Case "SALDO" : .DefaultCellStyle.Format = "#,##0.00 " : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .Width = 50
                  Case "PRECIO" : .DefaultCellStyle.Format = "#,##0.00 " : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .Width = 50
                  Case "DESCUENTO" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .Width = 50
                  Case "IMPINT" : .HeaderText = "Imp.Int." : .DefaultCellStyle.Format = "#,##0.00 " : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .Width = 50
                  Case "BONIFICACION" : .Width = 50
                  Case "SEL" : .Width = 12
                  Case Else : .Visible = False
               End Select
            End With
         Next
      End With
   End Sub
   '
   Private Sub DataGridView1_KeyUp(sender As Object, e As KeyEventArgs) Handles DataGridView1.KeyUp
      VerDatos()
   End Sub
   '
   Private Sub DataGridView1_MouseClick(sender As Object, e As MouseEventArgs) Handles DataGridView1.MouseClick
      VerDatos()
      tbCantidad.Focus()
   End Sub
   '
   Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
      VerDatos()
   End Sub
   '
   Private Sub VerDatos()
      '
      Dim PrecioCli As Double
      '
      With DataGridView1
         If .RowCount > 0 Then
            tbCodigo.Text = .SelectedCells(.Columns("CodProd").Index).Value & ""
            tbDescrip.Text = .SelectedCells(.Columns("Descrip").Index).Value & ""
            tbPartida.Text = .SelectedCells(.Columns("Partida").Index).Value & ""
            Costo = Val(.SelectedCells(.Columns("CostoNeto").Index).Value & "")
            '
            'If Alta Then
            PrecioCli = Val(CapturaDato(cn, "ClientesPrecios", "CliPrNeto", "Cliente = " & Cliente & " AND Producto = " & Producto))
            '
            If Cliente <> 0 And PrecioCli <> 0 Then
               Precio = PrecioCli
            Else
               If Margen = 0 Then
                  Precio = .SelectedCells(.Columns("Precio").Index).Value
               Else
                  'Precio = Format(!Costo + !Costo * Margen / 100, cfgFormatoPr)
                  Precio = .SelectedCells(.Columns("Costo").Index).Value + .SelectedCells(.Columns("Costo").Index).Value * Margen / 100
               End If
            End If
            '
            tbPrecio.Text = Format(Precio, cfgFormatoPr)
            ImpInt = Val(.SelectedCells(.Columns("ImpInt").Index).Value & "")
            'End If
            '
            tbImpInt.Text = Format(ImpInt, cfgFormatoPr)
            AlicIva = .SelectedCells(.Columns("AlicIva").Index).Value & ""
            If AlicIva = "" Then
               AlicuoIva = cfgAlicIva
            Else
               AlicuoIva = Val(CapturaDato(cn, "AlicIva", "Alicuo1", "AlicIva = '" & AlicIva & "'"))
            End If
            tbBonif.Text = ""
            Producto = .SelectedCells(.Columns("Producto").Index).Value
            If Bonificacion = "" Then
               If Val(.SelectedCells(.Columns("Bonificacion").Index).Value & "") <> 0 Then
                  tbBonif.Text = Val(.SelectedCells(.Columns("Bonificacion").Index).Value & "")
                  If Val(BonifExtra) <> 0 Then
                     tbBonif.Text = Val(tbBonif.Text) + Val(BonifExtra)
                  End If
               End If
            Else
               tbBonif.Text = Bonificacion
            End If
         End If
      End With
      '
      CalcImportes(0)
      '
   End Sub
   '
   Private Sub CalcImportes(ByVal PrecioLocal As Double)
      If FormLoad Then
         Dim Preciofin As Double
         tbSubtotal.Text = Format(CalcImportesVenta(tbPrecio.Text, PrecioLocal, Letra <> "B", tbBonif.Text, AlicuoIva, Preciofin, tbPrUnit, tbSubtotal, tbCantidad, ImpInt), cfgFormatoPr)
         If PrecioLocal = 0 Then
            'If Letra = "B" Then
            '   tbPrecio.Text = Format(Preciofin, cfgFormatoPr)
            'Else
            'tbPrecio.Text = Format(Precio, cfgFormatoPr)
            'End If
         End If
         tbPrecioFbon.Text = Format(Preciofin, cfgFormatoPr)
      End If
   End Sub
   '
   Private Sub TbCantidad_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbCantidad.TextChanged
      CalcImportes(0)
   End Sub
   '
   Private Sub TbBonif_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbBonif.TextChanged
      CalcImportes(0)
   End Sub
   '
   Private Sub OptNeto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
      CalcImportes(0)
   End Sub
   '
   Private Sub TbPrecio_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbPrecio.TextChanged
      CalcImportes(Val(tbPrecio.Text))
   End Sub
   '
   Private Sub tbPrecioFin_TextChanged(sender As Object, e As EventArgs) Handles tbPrecioFin.TextChanged
      tbPrecio.Text = Format(Val(tbPrecioFin.Text) / (1 + AlicuoIva / 100), cfgFormatoPr)
   End Sub
   '
   Private Sub OptBruto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
      CalcImportes(0)
   End Sub
   '
   Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
      '
      Dim Proveedor As Long
      Dim Cantidad As Double
      Dim CantReng As Integer
      '
      With DataGridView1
         If .RowCount > 0 Then
            If IsDBNull(.SelectedCells(.Columns("Proveedor").Index).Value) Then
               Proveedor = 0
            Else
               Proveedor = .SelectedCells(.Columns("Proveedor").Index).Value
            End If
         End If
      End With
      '
      If Facturar Then
         CantReng = CapturaDato(cn, TablaAct, "COUNT(1)", "")
         If Alta And cfgMaxRengFact > 0 And CantReng >= cfgMaxRengFact Then
            MensajeTrad("NoAddReng")
            btnCancelar.Focus()
            Exit Sub
         End If
      End If
      '
      If Val(tbCantidad.Text) = 0 Then
         MensajeTrad("DICantidad")
         If tbCantidad.Enabled Then
            tbCantidad.Focus()
         End If
         Exit Sub
      Else
         With DataGridView1
            If Val(tbCantidad.Text) > Val(.SelectedCells(.Columns("Saldo").Index).Value & "") Then
               If Devolucion Or Not cfgEgrSinStk Then
                  MsgBox("Cantidad mayor que Saldo", vbInformation)
                  tbCantidad.Focus()
                  Exit Sub
               End If
            End If
         End With
      End If
      '
      If Val(tbPrecio.Text) = 0 Then
         MsgBox("Debe ingresar precio de venta", vbInformation)
         With tbPrecio
            If .Enabled Then
               .Focus()
            End If
         End With
         Exit Sub
      End If
      '
      If Devolucion Then
         With DataGridView1
            If .SelectedCells(.Columns("Saldo").Index).Value < 0 Then
               MsgBox("No se puede realizar una devolución sobre una ya establecida", vbInformation)
               Exit Sub
            End If
         End With
      End If
      '
      Cantidad = IIf(Imput = "D", Val(tbCantidad.Text), -Val(tbCantidad.Text))
      'If Letra = "B" Then
      '   Precio = Precio * (1 + AlicuoIva / 100)
      '   PrUnit = PrUnit * (1 + AlicuoIva / 100)
      '   SubTotal = (PrUnit + ImpInt) * Math.Abs(Cantidad)
      'End If
      '
      Trn = cn.BeginTransaction
      '
      Try
         '
         Cmd.Transaction = Trn
         '
         If Alta Or tbPartida.Text <> Partida Then
            '
            Renglon = Val(CapturaDato(cn, TablaAct, "MAX(Renglon)", "", , , , Trn) & "") + 1
            '
            If Unico Then
               If Not IsNothing(CapturaDato(cn, TablaAct, "Producto", "Proveedor=" & Proveedor & " AND Producto=" & Producto & " AND Partida='" & tbPartida.Text & "'", , , , Trn)) Then
                  Err.Raise(1001, , "Código/Partida ya utilizado")
               End If
            End If
         End If
         '
         If Alta Then
            Cmd.CommandText = "INSERT INTO " & TablaAct & "( Renglon, Proveedor, Producto, CodProd, Partida, Detalle, Cantidad, Costo, Precio, Bonificacion, ImpInt, SubTotal, AlicuoIva) " &
                              "VALUES(" & Renglon & ", " & Proveedor & ", " & Producto & ", '" & tbCodigo.Text & "', '" & tbPartida.Text & "', '" & tbDescrip.Text & "', " & Cantidad & ", " & Costo & ", " & tbPrecio.Text & ", '" & tbBonif.Text & "', " & ImpInt & ", " & tbSubtotal.Text & ", " & AlicuoIva & ")"
            Cmd.ExecuteNonQuery()
         Else
            Cmd.CommandText = "UPDATE " & TablaAct & " SET " &
                              " Cantidad = " & Cantidad & ", " &
                              " Costo = " & Costo & ", " &
                              " Precio = " & tbPrecio.Text & ", " &
                              " Bonificacion = '" & tbBonif.Text & "', " &
                              " SubTotal = " & tbSubtotal.Text & ", " &
                              " AlicuoIva = " & AlicuoIva & " " &
                              "WHERE Renglon = " & Renglon
            Cmd.ExecuteNonQuery()
         End If
         '
         Trn.Commit()
         '
         If MantenerAbierto Then
            '' *** VER *** FormAct.ActData()
            tbCantidad.Text = ""
            ActData()
            'If Remitos Then
            'frmRemitosAM.ActData()
            'Else
            '  frmVentasAM.ActData()
            'End If
            DataGridView1.Focus()
            If Alta Then
               Renglon = Renglon + 1
            End If
         Else
            'If Remitos Then
            '   frmRemitosAM.ActData()
            'Else
            '   frmVentasAM.ActData()
            'End If
            Me.Close()
         End If
         '
      Catch ex As Exception
         '
         Trn.Rollback()
         Dim st As New StackTrace(True)
         RegistrarError(st, Me.Name)
         '
      End Try
      '
   End Sub

   Protected Sub ActForm()
      FrmVentasAM.ActData()
   End Sub

   Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
      Me.Close()
   End Sub
   '
   'Private Sub btnAltaProd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAltaProd.Click
   '   If Not SuperaRegistros("Productos") Then
   '      With FrmProductosAM
   '         .Alta = True
   '         .CambiaCod = False
   '         .Rubro = Rubro
   '         '.Medicam = EsMedicam(, .Rubro)
   '         .tbCodigo.Text = Rubro & "-"
   '         'SendKeys("{End}")
   '         .Show(Me)
   '      End With
   '      ActData()
   '   End If
   'End Sub
   '
   Private Sub cboRubro_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboRubro.SelectedIndexChanged
      With cboRubro
         If .SelectedIndex > 0 Then
            Rubro = CapturaDato(cn, "Rubros", "Rubro", "Descrip = '" & cboRubro.Text & "'")
         Else
            Rubro = ""
         End If
      End With
      ActData()
   End Sub
   '
   Private Sub cboSucursal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSucursal.SelectedIndexChanged
      With cboSucursal
         If .SelectedIndex > 0 Then
            Sucursal = .SelectedValue
         Else
            Sucursal = -1
         End If
      End With
      ActData()
   End Sub
   '
   Private Sub optDescrip_CheckedChanged(sender As Object, e As EventArgs)
      ActData()
   End Sub
   '
   Private Sub frmVentasAMProd_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
      SetRegGrid(Me, DataGridView1)
   End Sub
   '
End Class