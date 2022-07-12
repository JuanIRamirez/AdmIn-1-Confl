Public Class frmComprasOtrAM
   '
   Public Alta As Boolean
   Public Comprob As String = ""
   Public Proveedor As Int32 = 0
   Public Sucursal As Int16 = 0
   Public Numero As Int32 = 0
   '
   Public OrdenPagoId As Int32 = 0
   Public Pagar As Boolean = False
   Public SoloVer As Boolean = False
   Public NoModDet As Boolean = False
   Public Propiet As Int32 = 0
   Public Propied As Int32 = 0
   '
   Dim Propiedad As Int32
   '
   Dim Trn As OleDb.OleDbTransaction
   Dim Cmd As New OleDb.OleDbCommand
   Dim Drd As OleDb.OleDbDataReader
   '
   Dim nCol As Integer
   Dim nColFec As Integer
   Dim nColCon As Integer
   Dim nColDet As Integer
   Dim nColImp As Integer
   Dim nColAcc As Integer
   '
   Dim nTotal As Double
   Dim TotalAct As Double
   Dim TotalAnt As Double
   Dim TotalActP As Double
   Dim TotalAntP As Double
   Dim AlicIva1 As Single
   Dim AlicIva2 As Single
   Dim i As Integer
   '
   Dim NuevoProv As Long
   Dim tTmp As String
   '
   Dim FormLoad As Boolean
   '
   Private Sub frmComprasOtrAM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      '
      GetRegForm(Me)
      '
      Me.Text = Me.Text & " - " & Traducir(IIf(Alta, "Alta", "Modificación"))
      '
      tTmp = ""
      CrearTabla(Cn, "Proveedor INT NOT NULL, " & _
                     "Renglon smallint NOT NULL, " & _
                     "Concepto VARCHAR (10) NOT NULL, " & _
                     "Detalle VARCHAR (250) NOT NULL, " & _
                     "Fecha SMALLDATETIME NULL, " & _
                     "Debe float NOT NULL, " & _
                     "Haber float NOT NULL, " & _
                     "aPropiet bit NOT NULL", tTmp)
      '
      ArmaCbProv()
      '
      Cmd.Connection = Cn
      '
      If Alta Then
         dtpFecha.Value = Today
         dtpFecVenc.Value = Today
         If Comprob = "" Then
            Comprob = "CP"
         End If
      Else
         tbSucursal.Enabled = False
         tbNumero.Enabled = False
         With Cmd
            .CommandText = "SELECT * FROM CompraOtr WHERE Proveedor = " & Proveedor & " AND Comprob = '" & Comprob & "' AND Sucursal = " & Sucursal & " AND Numero = " & Numero
            Drd = .ExecuteReader
         End With
         '
         With Drd
            If .Read Then
               tbSucursal.Text = Sucursal
               tbNumero.Text = Numero
               dtpFecha.Value = !Fecha
               dtpFecVenc.Value = !FechaVenc
               tbTotal.Text = Format(!Total, "Fixed")
               tbDetalle.Text = !Detalle & ""
               If Proveedor > 0 Then
                  PosicionarComboItem(cbProveedor, Proveedor)
               End If
               If Not IsDBNull(!Propietario) Then
                  Propiet = !Propietario
               End If
               If Not IsDBNull(!Propiedad) Then
                  Propied = !Propiedad
                  'PosCboItem(cbPropiedad, Propied)
               End If
            Else
               MensajeTrad("ComprNoEnc")
               DeshabForm(Me)
            End If
            .Close()
         End With
         '
         Trn = Cn.BeginTransaction
         With Cmd
            .Transaction = Trn
            .CommandText = "INSERT INTO " & tTmp & "( Proveedor, Renglon, aPropiet, Fecha, Concepto, Detalle, Debe, Haber) " & _
                           "SELECT Proveedor, Renglon, aPropiet, Fecha, Concepto, Detalle, Importe, 0 " & _
                           "FROM CompraOtrDet WHERE Imput = 'D' AND Proveedor = " & Proveedor & " AND Comprob = '" & Comprob & "' AND Sucursal = " & Sucursal & " AND Numero = " & Numero
            .ExecuteNonQuery()
            .CommandText = "INSERT INTO " & tTmp & "( Proveedor, Renglon, aPropiet, Fecha, Concepto, Detalle, Debe, Haber) " & _
                           "SELECT Proveedor, Renglon, aPropiet, Fecha, Concepto, Detalle, 0, Importe " & _
                           "FROM CompraOtrDet WHERE Imput = 'H' AND Proveedor = " & Proveedor & " AND Comprob = '" & Comprob & "' AND Sucursal = " & Sucursal & " AND Numero = " & Numero
            .ExecuteNonQuery()
         End With
         '
         Trn.Commit()
         '
         TotalAnt = Val(CapturaDato(Cn, tTmp, "SUM(Debe-Haber)", "aPropiet = 0") & "")
         TotalAntP = Val(CapturaDato(Cn, tTmp, "SUM(Debe-Haber)", "aPropiet <> 0") & "")
      End If
      '
      ActData()
      '
      ArmaComboItem(cbPropietario, "Propietarios", , "Nombre", "Nombre", "(Adm)", "Estado = 'A'", , , , Propiet)
      '
      If Propiet <> 0 Then
         cbPropietario.Enabled = False
      End If
      If Propied <> 0 Then
         PosCboItem(cbPropiedad, Propied)
         cbPropiedad.Enabled = False
      End If
      '
      If Alta Then
         ActivaCtrl(False)
      Else
         Aceptar()
      End If
      '
      If Comprob = "" Then
         MensajeTrad("TipoCompNoEnc")
         DeshabForm(Me)
      End If
      '
   End Sub
   '
   Private Sub frmComprasOtrAM_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
      TabReturn(e.KeyChar)
   End Sub
   '
   Private Sub ArmaCbProv()
      ArmaComboItem(cbProveedor, "Proveedores", "Codigo", "Nombre", "Nombre", , "Codigo <> 0")
   End Sub
   '
   Private Sub cbProveedor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbProveedor.SelectedIndexChanged
      With cbProveedor
         If .SelectedIndex > 0 Then
            NuevoProv = .SelectedValue
         Else
            NuevoProv = 0
         End If
      End With
      If Alta Then
         Proveedor = NuevoProv
      End If
   End Sub
   '
   Private Sub dtpFecha_ValueChanged(sender As Object, e As EventArgs) Handles dtpFecha.ValueChanged
      With dtpFecVenc
         If .Value < dtpFecha.Value Then
            .Value = dtpFecha.Value
         End If
         .MinDate = dtpFecha.Value
      End With
   End Sub
   '
   Private Sub cbPropietario_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPropietario.SelectedIndexChanged
      '
      With cbPropietario
         If .SelectedIndex > 0 Then
            Propiet = .SelectedValue
         Else
            Propiet = 0
         End If
      End With
      '
      ArmaCbPropiedad(cbPropiedad, Propiet, "(Todas)")
      '
   End Sub
   '
   Private Sub cbPropiedad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPropiedad.SelectedIndexChanged
      With cbPropiedad
         If .SelectedIndex > 0 Then
            Propiedad = .SelectedValue
         Else
            Propiedad = 0
         End If
      End With
   End Sub
   '
   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      Aceptar()
   End Sub
   '
   Private Sub Aceptar()
      If Validar1() Then
         ActData()
         CalcImportes()
         ActivaCtrl(True)
      End If
   End Sub
   '
   Private Sub ActivaCtrl(Activo As Boolean)
      '
      dtpFecha.Enabled = Activo
      dtpFecVenc.Enabled = Activo
      cbPropietario.Enabled = Activo And Propiet = 0
      cbPropiedad.Enabled = Activo And Propied = 0
      tbDetalle.Enabled = Activo
      '
      cmdGuardar.Enabled = Activo And Not SoloVer
      cmdCancelar.Enabled = Activo
      '
      cmdAlta.Enabled = Activo And Not NoModDet
      cmdBaja.Enabled = Activo And Not NoModDet
      cmdEdicion.Enabled = Activo And Not NoModDet
      '
      cbProveedor.Enabled = Not Activo And Alta
      btnNuevoProv.Enabled = Not Activo And Alta
      tbSucursal.Enabled = Not Activo And Alta
      tbNumero.Enabled = Not Activo And Alta
      btnAceptar.Enabled = Not Activo
      '
   End Sub
   '
   Private Sub cmdAlta_Click(sender As Object, e As EventArgs) Handles cmdAlta.Click
      AltaMod(True)
   End Sub
   '
   Private Sub cmdEdicion_Click(sender As Object, e As EventArgs) Handles cmdEdicion.Click
      AltaMod(False)
   End Sub
   '
   Private Sub AltaMod(Alta As Boolean)
      '
      Dim Concepto As String = ""
      Dim Renglon As Byte
      '
      With DataGridView1
         If Alta Then
            Renglon = .RowCount + 1
         Else
            If .RowCount = 0 Then
               MensajeTrad("DSelItem")
               Exit Sub
            Else
               Concepto = .SelectedCells(.Columns("Concepto").Index).Value
               Renglon = .SelectedCells(.Columns("Renglon").Index).Value
            End If
         End If
      End With
      '
      Dim frm As New frmComprasOtrAmDet
      With frm
         .Propietario = Propiet
         .tTmp = tTmp
         .Alta = Alta
         .cmpInt = Comprob
         .cConcepto = Concepto
         .nProveedor = NuevoProv
         .nSucursal = tbSucursal.Text
         .nNumero = tbNumero.Text
         .nRenglon = Renglon
         .ShowDialog(Me)
         ActData()
      End With
      '
   End Sub
   '
   Private Sub cmdBaja_Click(sender As Object, e As EventArgs) Handles cmdBaja.Click
      '
      Dim Concepto, Detalle As String
      Dim Renglon As Byte
      '
      With DataGridView1
         If .RowCount = 0 Then
            MensajeTrad("DSelItem")
         Else
            Renglon = .SelectedCells(.Columns("Renglon").Index).Value
            Detalle = .SelectedCells(.Columns("Detalle").Index).Value
            Concepto = .SelectedCells(.Columns("Concepto").Index).Value
            If DaDeBaja("(" & Concepto & ") " & Detalle) Then
               Cmd.CommandText = "DELETE FROM " & tTmp & " WHERE Renglon = " & Renglon
               Cmd.ExecuteNonQuery()
               ActData()
            End If
         End If
      End With
      '
   End Sub
   '
   Private Sub cmdGuardar_Click(sender As Object, e As EventArgs) Handles cmdGuardar.Click
      '
      If Validar2() Then
         If AltaAuto("Proveedores", "Codigo", Proveedor, "Nombre", cbProveedor.Text, 0, "  -        - ", , True) Then
            ArmaComboItem(cbProveedor, "Proveedores", "Codigo", "Nombre", "Nombre")
         End If
         If Guardar() Then
            If Pagar Then
               If MsgConfirma("Paga comprobante") Then
                  Dim Frm As New frmOrdenPagoPago
                  With Frm
                     .OrdenPagoId = 0
                     .Proveedor = NuevoProv
                     .Comprob = Comprob
                     .Sucursal = tbSucursal.Text
                     .Numero = tbNumero.Text
                     .PagoDir = True
                     .cmpInt = "PO"
                     .ShowDialog(Me)
                  End With
               End If
            End If
            Cancelar()
         End If
      End If
   End Sub
   '
   Private Function Validar1() As Boolean
      '
      If NuevoProv = 0 Then
         MensajeTrad("DIProveedor")
         cbProveedor.Focus()
         Exit Function
      End If
      '
      If tbSucursal.Text = "" Then
         MensajeTrad("DISucursal")
         tbSucursal.Focus()
         Exit Function
      End If
      '
      If Val(tbNumero.Text) = 0 Then
         MensajeTrad("DINumero")
         tbNumero.Focus()
         Exit Function
      End If
      '
      If IsNothing(CapturaDato(Cn, "CompraOtr", "Comprob", "Proveedor = " & Proveedor & " AND Comprob = '" & Comprob & "' AND Sucursal = " & tbSucursal.Text & " AND Numero = " & tbNumero.Text)) Then
         'Ok.
      Else
         If Alta Then
            MensajeTrad("ComprExist")
            tbNumero.Focus()
            Exit Function
         End If
      End If
      '
      Validar1 = True
      '
   End Function
   '
   Private Function Validar2() As Boolean
      '
      If NuevoProv = 0 Then
         MensajeTrad("DIProveedor")
         Return False
      End If
      If Val(tbTotal.Text) = 0 Then
         MensajeTrad("Total=0")
         Return False
      End If
      '
      Return True
      '
   End Function
   '
   Sub ActData()
      '
      LlenarGrid(DataGridView1, "SELECT * FROM " & tTmp)
      '
      TotalAct = Val(CapturaDato(Cn, tTmp, "SUM(Debe-Haber)", "aPropiet = 0") & "")
      TotalActP = Val(CapturaDato(Cn, tTmp, "SUM(Debe-Haber)", "aPropiet <> 0") & "")
      '
      SetRegGrid(Me, DataGridView1)
      '
      With DataGridView1
         For Each Col As DataGridViewColumn In .Columns
            With Col
               Select Case UCase(.Name)
                  Case "CONCEPTO" : .Width = 100
                  Case "DETALLE" : .Width = 550
                  Case "DEBE" : .Width = 125
                  Case "HABER" : .Width = 125
                  Case Else
                     .Visible = False
               End Select
            End With
         Next Col
      End With
      '
      GetRegGrid(Me, DataGridView1)
      '
      CalcImportes()
      '
   End Sub
   '
   Private Sub cmdSalir_Click()
      Me.Close()
   End Sub
   '
   Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
      Cancelar()
   End Sub
   '
   Private Sub Cancelar()
      If Alta Then
         ActivaCtrl(False)
         LimpiaTemp()
         ActData()
         CalcImportes()
         If cbProveedor.Enabled Then
            cbProveedor.Focus()
         End If
      Else
         Me.Close()
      End If
   End Sub
   '
   Private Sub CalcImportes()
      '
      nTotal = 0
      '
      If Alta Then
         tbTotal.Text = Format(0, "Fixed")
      End If
      '
      nTotal = Val(CapturaDato(Cn, tTmp, "SUM(Debe-Haber)", "") & "")
      tbTotal.Text = Format(nTotal, "Fixed")
      '
   End Sub
   '
   Private Function Guardar() As Boolean
      '
      Dim Cm2 As New OleDb.OleDbCommand
      '
      Dim nRenglon As Integer
      Dim Liquid As Boolean
      Dim Imput As String
      Dim TotalP As Double
      Dim Total As Double
      Dim Concepto As String
      Dim Inquilino As Long
      Dim MesPago As Integer
      Dim Periodo As String
      Dim Detalle As String = ""
      Dim GenDif As Boolean
      Dim ConcDif As String = "DIF"
      Dim ContDif As Integer
      Dim PerAnt, PerDesde As String
      Dim PerHasta As String = ""
      Dim Fecha As Date
      Dim cSql As String = ""
      Dim nMes As Byte
      Dim aPropiet, noInq As Boolean
      '
      If (TotalAnt <> TotalAct Or TotalAntP <> TotalActP) Then
         If Not Alta Then
            If cfgGenDifComprob Then
               GenDif = MsgConfirma("Genera comprobantes por Diferencia de Importes")
            End If
         End If
      End If
      '
      Try
         '
         Trn = Cn.BeginTransaction
         '
         Cmd.Transaction = Trn
         '
         If Not Alta Then
            Liquid = CapturaDato(Cn, "CompraOtr", "Liquidado", "Proveedor = " & Proveedor & " AND Comprob = '" & Comprob & "' AND Sucursal = " & tbSucursal.Text & " AND Numero = " & tbNumero.Text, , , , Trn) & ""
         End If
         '
         If Not Liquid Then
            With Cmd
               If Alta Then
                  .CommandText = "INSERT INTO CompraOtr( Proveedor, Comprob, Sucursal, Numero, Fecha, FechaVenc, Propietario, Propiedad, Nombre, Detalle, Total, Usuario, FechaMod) " & _
                                 "VALUES(" & NuevoProv & ", " & _
                                       "'" & Comprob & "', " & _
                                             tbSucursal.Text & ", " & _
                                             tbNumero.Text & ", " & _
                                       "'" & Format(dtpFecha.Value, FormatFecha) & "', " & _
                                       "'" & Format(dtpFecVenc.Value, FormatFecha) & "', " & _
                                             Propiet & ", " & _
                                             Propiedad & ", " & _
                                       "'" & cbProveedor.Text & "', " & _
                                       "'" & tbDetalle.Text & "', " & _
                                             Val(tbTotal.Text) & ", " & _
                                       "'" & Uid & "', " & _
                                       "'" & Format(Now, FormatFechaHora) & "')"
               Else
                  .CommandText = "UPDATE CompraOtr SET " & _
                                 " Proveedor = " & NuevoProv & ", " & _
                                 " Propietario = " & Propiet & ", " & _
                                 " Propiedad = " & Propiedad & ", " & _
                                 " Nombre = '" & cbProveedor.Text & "', " & _
                                 " Fecha = '" & Format(dtpFecha.Value, FormatFecha) & "', " & _
                                 " FechaVenc = '" & Format(dtpFecVenc.Value, FormatFecha) & "', " & _
                                 " Total = " & Val(tbTotal.Text) & ", " & _
                                 " Detalle = '" & tbDetalle.Text & "', " & _
                                 " Usuario = '" & Uid & "', " & _
                                 " FechaMod = '" & Format(Now, FormatFechaHora) & "' " & _
                                 "WHERE Proveedor = " & Proveedor & " AND Comprob = '" & Comprob & "' AND Sucursal = " & tbSucursal.Text & " AND Numero = " & tbNumero.Text
               End If
               .ExecuteNonQuery()
               '
               .CommandText = "DELETE FROM CompraOtrDet WHERE Proveedor = " & Proveedor & " AND Comprob = '" & Comprob & "' AND Sucursal = " & tbSucursal.Text & " AND Numero = " & tbNumero.Text
               .ExecuteNonQuery()
               '
               .CommandText = "INSERT INTO CompraOtrDet( Proveedor, Comprob, Sucursal, Numero, Renglon, Fecha, Concepto, Detalle, Importe, Imput, aPropiet, Usuario, FechaMod) " & _
                              "SELECT " & NuevoProv & ", '" & Comprob & "', " & tbSucursal.Text & ", " & tbNumero.Text & ", Renglon, '" & Format(dtpFecha.Value, FormatFecha) & "', Concepto, Detalle, Debe, 'D', aPropiet, '" & Uid & "', '" & Format(Now, FormatFechaHora) & "' " & _
                              "FROM " & tTmp & " WHERE Debe <> 0 "
               .ExecuteNonQuery()
               .CommandText = "INSERT INTO CompraOtrDet( Proveedor, Comprob, Sucursal, Numero, Renglon, Fecha, Concepto, Detalle, Importe, Imput, aPropiet, Usuario, FechaMod) " & _
                              "SELECT " & NuevoProv & ", '" & Comprob & "', " & tbSucursal.Text & ", " & tbNumero.Text & ", Renglon, '" & Format(dtpFecha.Value, FormatFecha) & "', Concepto, Detalle, Haber, 'H', aPropiet, '" & Uid & "', '" & Format(Now, FormatFechaHora) & "' " & _
                              "FROM " & tTmp & " WHERE Haber <> 0 "
               .ExecuteNonQuery()
               '
               .CommandText = "UPDATE OrdenPagoDet SET Proveedor = " & NuevoProv & _
                              "WHERE OrdenPagoId = " & OrdenPagoId & " AND ProComprob = '" & Comprob & "' AND ProSucursal = " & tbSucursal.Text & " AND ProNumero = " & tbNumero.Text
               .ExecuteNonQuery()
               '
            End With
         Else
            '
            With Cmd
               '
               .CommandText = "UPDATE CompraOtr SET " & _
                              " Detalle = '" & tbDetalle.Text & "', " & _
                              " Usuario = '" & Uid & "', " & _
                              " FechaMod = '" & Format(Now, FormatFechaHora) & "' " & _
                              "WHERE Proveedor = " & Proveedor & " AND Comprob = '" & Comprob & "' AND Sucursal = " & tbSucursal.Text & " AND Numero = " & tbNumero.Text
               .ExecuteNonQuery()
               '
               .CommandText = "UPDATE CompraOtr SET " & _
                                 " Proveedor = " & NuevoProv & ", " & _
                                 " Usuario = '" & Uid & "', " & _
                                 " FechaMod = '" & Format(Now, FormatFechaHora) & "' " & _
                                 "WHERE Proveedor = " & Proveedor & " AND Comprob = '" & Comprob & "' AND Sucursal = " & tbSucursal.Text & " AND Numero = " & tbNumero.Text
               .ExecuteNonQuery()
               '
               .CommandText = "UPDATE CompraOtrDet SET " & _
                              " Proveedor = " & NuevoProv & ", " & _
                              " Usuario = '" & Uid & "', " & _
                              " FechaMod = '" & Format(Now, FormatFechaHora) & "' " & _
                              "WHERE Proveedor = " & Proveedor & " AND Comprob = '" & Comprob & "' AND Sucursal = " & tbSucursal.Text & " AND Numero = " & tbNumero.Text
               .ExecuteNonQuery()
               '
               .CommandText = "UPDATE OrdenPagoDet SET Proveedor = " & NuevoProv & _
                              "WHERE OrdenPagoId = " & OrdenPagoId & " AND ProComprob = '" & Comprob & "' AND ProSucursal = " & tbSucursal.Text & " AND ProNumero = " & tbNumero.Text
               .ExecuteNonQuery()
               '
            End With
            '
            If (TotalAnt <> TotalAct Or TotalAntP <> TotalActP) Then
               Comprob = Comprob & "/Dif"
               nTotal = Val(tbTotal.Text) - (TotalAnt + TotalAntP)
               Imput = IIf(nTotal > 0, "D", "H")
               With Cmd
                  If IsNothing(CapturaDato(Cn, "CompraOtr", "Comprob", "Proveedor = " & NuevoProv & " AND Comprob = '" & Comprob & "' AND Sucursal = " & tbSucursal.Text & " AND Numero = " & tbNumero.Text, , , , Trn)) Then
                     '
                     .CommandText = "INSERT INTO CompraOtr( Proveedor, Comprob, Sucursal, Numero, Fecha, FechaVenc, Propietario, Propiedad, Nombre, Detalle, Total, Usuario, FechaMod) " & _
                                    "VALUES(" & NuevoProv & ", " & _
                                          "'" & Comprob & "', " & _
                                                tbSucursal.Text & ", " & _
                                                tbNumero.Text & ", " & _
                                          "'" & Format(SumaMes(dtpFecha.Value, 1), FormatFecha) & "', " & _
                                          "'" & Format(SumaMes(dtpFecVenc.Value, 1), FormatFecha) & "', " & _
                                                Propiet & ", " & _
                                                Propiedad & ", " & _
                                          "'" & cbProveedor.Text & "', " & _
                                          "'" & tbDetalle.Text & "', " & _
                                                nTotal & ", " & _
                                          "'" & Uid & "', " & _
                                          "'" & Format(Now, FormatFechaHora) & "')"
                  Else
                     .CommandText = "UPDATE CompraOtr SET " & _
                                    " Proveedor = " & NuevoProv & ", " & _
                                    " Comprob = '" & Comprob & "', " & _
                                    " Sucursal = " & tbSucursal.Text & ", " & _
                                    " Numero = " & tbNumero.Text & ", " & _
                                    " Propietario = " & Propiet & ", " & _
                                    " Propiedad = " & Propiedad & ", " & _
                                    " Nombre = '" & cbProveedor.Text & "', " & _
                                    " Fecha = '" & Format(SumaMes(dtpFecha.Value, 1), FormatFecha) & "', " & _
                                    " FechaVenc = '" & Format(SumaMes(dtpFecVenc.Value, 1), FormatFechaHora) & "', " & _
                                    " Total = " & nTotal & ", " & _
                                    " Detalle = '" & tbDetalle.Text & "', " & _
                                    " Pagado = 1, " & _
                                    " NroPago = " & OrdenPagoId & ", " & _
                                    " Usuario = '" & Uid & "', " & _
                                    " FechaMod = '" & Format(Now, FormatFechaHora) & "' " & _
                                    "WHERE Proveedor = " & Proveedor & " AND Comprob = '" & Comprob & "' AND Sucursal = " & tbSucursal.Text & " AND Numero = " & tbNumero.Text
                  End If
                  .ExecuteNonQuery()
                  '
                  nRenglon = 1
                  TotalP = Math.Round(TotalActP - TotalAntP, 2)
                  Imput = IIf(TotalP > 0, "D", "H")
                  '
                  .CommandText = "DELETE FROM CompraOtrDet WHERE Comprob = '" & Comprob & "' AND Sucursal = " & tbSucursal.Text & " AND Numero = " & tbNumero.Text
                  .ExecuteNonQuery()
                  '
                  If TotalAntP <> TotalActP Then
                     .CommandText = "INSERT INTO CompraOtrDet( Proveedor, Comprob, Sucursal, Numero, Renglon, Fecha, Concepto, Detalle, Importe, Imput, aPropiet, Usuario, FechaMod) " & _
                                    "SELECT TOP 1 " & NuevoProv & ", '" & Comprob & "', " & tbSucursal.Text & ", " & tbNumero.Text & ", " & nRenglon & ", '" & Format(SumaMes(dtpFecha.Value, 1), FormatFecha) & "', Concepto, '" & tbDetalle.Text & "', " & Math.Abs(TotalP) & ", '" & Imput & "', aPropiet, '" & Uid & "', '" & Format(Now, FormatFechaHora) & "' " & _
                                    "FROM " & tTmp & " WHERE aPropiet <> 0"
                     .ExecuteNonQuery()
                     nRenglon = nRenglon + 1
                  End If
                  '
                  Total = Math.Round(TotalAct - TotalAnt, 2)
                  Imput = IIf(Total > 0, "D", "H")
                  '
                  If TotalAnt <> TotalAct Then
                     .CommandText = "INSERT INTO CompraOtrDet( Proveedor, Comprob, Sucursal, Numero, Renglon, Fecha, Concepto, Detalle, Importe, Imput, aPropiet, Usuario, FechaMod) " & _
                                    "SELECT TOP 1 " & NuevoProv & ", '" & Comprob & "', " & tbSucursal.Text & ", " & tbNumero.Text & ", " & nRenglon & ", '" & Format(SumaMes(dtpFecha.Value, 1), FormatFecha) & "', Concepto, '" & tbDetalle.Text & "', " & Math.Abs(Total) & ", '" & Imput & "', aPropiet, '" & Uid & "', '" & Format(Now, FormatFechaHora) & "' " & _
                                    "FROM " & tTmp & " WHERE aPropiet = 0"
                     .ExecuteNonQuery()
                     nRenglon = nRenglon + 1
                  End If
                  If OrdenPagoId <> 0 Then
                     .CommandText = "DELETE FROM OrdenPagoDet WHERE OrdenPagoId = " & OrdenPagoId & " AND ProComprob = '" & Comprob & "' AND ProSucursal = " & tbSucursal.Text & " AND ProNumero = " & tbNumero.Text
                     .ExecuteNonQuery()
                     '
                     .CommandText = "INSERT INTO OrdenPagoDet( OrdenPagoId, Proveedor, ProComprob, ProSucursal, ProNumero, OPDUid, OPDFecMod) " & _
                                    "VALUES(" & OrdenPagoId & ", " & NuevoProv & ", '" & Comprob & "', " & tbSucursal.Text & ", " & tbNumero.Text & ", '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
                     .ExecuteNonQuery()
                  End If
               End With
            End If
         End If
         '
         If GenDif Then
            Total = Math.Round(TotalAct - TotalAnt, 2)
            If Total <> 0 Then
               Imput = IIf(Total > 0, "D", "H")
               Concepto = CapturaDato(Cn, tTmp, "Concepto", "aPropiet=0", , , , Trn)
               '
               With Cmd
                  Fecha = dtpFecha.Value
                  .CommandText = "SELECT * FROM FactInq WHERE Propiedad = " & Propiedad & " AND Concepto = '" & Concepto & "' AND Periodo = '" & Format(Fecha, "yyyyMM") & "'"
                  Drd = .ExecuteReader
               End With
               '
               With Drd
                  If .Read Then
                     If !Saldo = !Importe Then
                        cSql = "UPDATE FactInq SET " & _
                               " Importe = " & TotalAct & ", " & _
                               " Saldo = " & TotalAct & ", " & _
                               " Usuario = '" & Uid & "', " & _
                               " FechaMod = '" & Format(Now, FormatFechaHora) & "' " & _
                               "WHERE Propiedad = " & Propiedad & " AND Concepto = '" & Concepto & "' AND Periodo = '" & Format(Fecha, "yyyyMM") & "'"
                        Inquilino = !Inquilino
                     Else
                        Inquilino = !Inquilino
                        MesPago = !MesPago
                        PerAnt = !Periodo
                        Periodo = !Periodo
                        Detalle = !Detalle
                        .Close()
                        '
                        Periodo = CapturaDato(Cn, "FactInq", "MIN(Periodo)", "Propiedad = " & Propiedad & " AND Inquilino = " & Inquilino & " AND Liquidado = 0", , , , Trn) & ""
                        If Periodo = "" Then
                           Periodo = CapturaDato(Cn, "FactInq", "MAX(Periodo)", "Propiedad = " & Propiedad & " AND Inquilino = " & Inquilino, , , , Trn) & ""
                           If Periodo = "" Then
                              Periodo = CalcPeriodo(Today, 0)
                           End If
                        End If
                        '
                        ContDif = 1
                        '
                        Do While Not IsNothing(CapturaDato(Cn, "FactInq", "Concepto", "Propiedad = " & Propiedad & " AND Concepto = '" & ConcDif & "' AND Periodo = '" & Periodo & "'", , , , Trn))
                           ContDif = ContDif + 1
                           ConcDif = "DIF" & ContDif
                        Loop
                        '
                        cSql = "INSERT INTO FactInq( Periodo, Propiedad, Inquilino, Concepto, Fecha, Detalle, Importe, Saldo, Imputacion, Liquidado, TipoNroRbo, Automatico, aPropiet, MesPago, Propietario, Usuario, FechaMod) " & _
                               "VALUES('" & Periodo & "', " & _
                                            Propiedad & ", " & _
                                            Inquilino & ", " & _
                                      "'" & ConcDif & "', " & _
                                      "'" & Format(Fecha, FormatFecha) & "', " & _
                                      "'" & Detalle & " (Dif. " & PerAnt & ")', " & _
                                            Math.Abs(Total) & ", " & _
                                            Math.Abs(Total) & ", " & _
                                      "'" & Imput & "', " & _
                                            0 & ", " & _
                                            "'', " & _
                                            1 & ", " & _
                                            0 & ", " & _
                                      "'" & MesPago & "', " & _
                                            0 & ", " & _
                                      "'" & Uid & "', " & _
                                      "'" & Format(Now, FormatFechaHora) & "')"
                        '
                        End If
                  End If
                  '
                  .Close()
                  '
               End With
               '
               If cSql <> "" Then
                  With Cmd
                     .CommandText = cSql
                     .ExecuteNonQuery()
                  End With
               End If
               '
            End If
         End If
         '
         If GenDif Then
            Fecha = dtpFecha.Value
            Concepto = CapturaDato(Cn, tTmp, "Concepto", "", , , , Trn)
            aPropiet = CapturaDato(Cn, tTmp, "aPropiet", "", , , , Trn)
            noInq = aPropiet
            If TotalAct = 0 Then
               TotalAct = TotalActP
            End If
            If TotalAct <> 0 Then
               If Not IsNothing(CapturaDato(Cn, "PropiedConc", "Concepto", "Propiedad = " & Propiedad & " AND Concepto = '" & Concepto & "'", , , , Trn)) Then
                  If Detalle = "" Then
                     Detalle = CapturaDato(Cn, "Conceptos", "Descrip", "Codigo = '" & Concepto & "'", , , , Trn)
                  End If
                  With Cmd
                     If IsNothing(CapturaDato(Cn, "PropiedConc", "Concepto", "Propiedad = " & Propiedad & " AND Concepto = '" & Concepto & "' AND FecDesde = '" & Format(Fecha, FormatFecha) & "'", , , , Trn)) Then
                        .CommandText = "INSERT INTO PropiedConc( Propiedad, Concepto, FecDesde, Detalle, Importe, Imputacion, Automatico, aPropiet, aPagar, noInquilino, Usuario, FechaMod) " &
                                       "VALUES(" & Propiedad & ", " &
                                             "'" & Concepto & "', " &
                                             "'" & Format(Fecha, FormatFecha) & "', " &
                                             "'" & Detalle & "', " &
                                                   Math.Abs(TotalAct) & ", " &
                                             "'" & IIf(TotalAct > 0, "D", "H") & "', " &
                                                   1 & ", " &
                                                   IIf(aPropiet, 1, 0) & ", " &
                                                   0 & ", " &
                                                   IIf(noInq, 1, 0) & ", " &
                                             "'" & Uid & "', " &
                                             "'" & Format(Now, FormatFechaHora) & "')"
                     Else
                        .CommandText = "UPDATE PropiedConc SET " &
                                       " aPagar = 0, " &
                                       " Automatico = 0, " &
                                       " Detalle = '" & Detalle & "', " &
                                       " Importe = " & Math.Abs(TotalAct) & ", " &
                                       " Imputacion = '" & IIf(TotalAct > 0, "D", "H") & "', " &
                                       " aPropiet = " & IIf(aPropiet, 1, 0) & ", " &
                                       " NoInquilino = " & IIf(noInq, 1, 0) & ", " &
                                       " Usuario = '" & Uid & "', " &
                                       " FechaMod = '" & Format(Now, FormatFechaHora) & "' " &
                                       "WHERE Propiedad = " & Propiedad & " AND Concepto = '" & Concepto & "' AND FecDesde = '" & Format(Fecha, FormatFecha) & "'"
                     End If
                     .ExecuteNonQuery()
                  End With
                  '
                  CaptDatosCtto(Inquilino, Propiedad, 0, "", PerHasta, 0, 1, Trn)
                  '
                  nMes = 1
                  Do While True
                     PerDesde = CalcPeriodo(dtpFecha.Value, nMes)
                     If PerDesde > PerHasta Then
                        Exit Do
                     Else
                        If PerDesde >= Format(cfgFecIniAct, "yyyyMM") Then
                           If PerDesde > Format(Fecha, "yyyyMM") Then
                              ActPropConc(PerDesde, Propiedad, Inquilino, nMes, 1, Concepto, Trn)
                           End If
                        End If
                        nMes = nMes + 1
                     End If
                  Loop
                  '
               End If
            End If
         End If
         '
         GuardarAudit(IIf(Alta, "Alta", "Modifica") & " Cpte. Otros", Comprob & "-" & tbSucursal.Text & "-" & tbNumero.Text & IIf(Propiet = 0, "", " Prt: " & cbPropietario.Text) & IIf(GenDif, ", (" & ConcDif & ") $" & Format(Total, cfgFormatoPr), ""), Me.Name, Me.cmdGuardar.Text, Trn)
         '
         Trn.Commit()
         '
         Return True
         '
      Catch ex As Exception
         '
         Trn.Rollback()
         Dim st As New StackTrace(True)
         RegistrarError(st, "CompraOtrAm", , Err.Description, "Guardar")
         Return False
         '
      End Try
      '
   End Function
   '
   Private Sub LimpiaTemp()
      '
      Trn = Cn.BeginTransaction
      '
      With Cmd
         .Transaction = Trn
         .CommandText = "DELETE FROM " & tTmp
         .ExecuteNonQuery()
      End With
      '
      Trn.Commit()
      '
   End Sub
   '
   Private Sub btnNuevoProv_Click(sender As Object, e As EventArgs) Handles btnNuevoProv.Click
      If TienePermiso(Cn, Uid, frmMenu.mProveedoresAlta.Name) Then
         frmProveedoresAM.ShowDialog(Me)
         ArmaCbProv()
      End If
   End Sub
   '
   Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
      Me.Close()
   End Sub
   '
   Private Sub frmComprasOtrAM_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
      SetRegGrid(Me, DataGridView1)
      SetRegForm(Me)
      Me.Dispose()
   End Sub
   '
End Class