Public Class frmLiqPropietAdl
   '
   Public Propietario As Int32
   Public NroLiq As Int32
   Public cTmp As String
   Public Alta As Boolean
   Public AlicIva1 As Single
   Public AlicIva2 As Single
   '
   Public Detalle As String
   Public Periodo As String
   Public Propiedad As Int32
   '
   Dim Comision As Single
   Dim Subt As Single
   Dim nCom As Single
   Dim nIva1 As Single
   Dim nIva2 As Single
   Dim AgRetGan As Boolean
   Dim Inquilino As Int32
   '
   Dim Trn As OleDb.OleDbTransaction
   Dim Cmd As New OleDb.OleDbCommand
   Dim Cm2 As New OleDb.OleDbCommand
   Dim Drd As OleDb.OleDbDataReader
   Dim Dr2 As OleDb.OleDbDataReader
   '
   Private Sub frmLiqPropAdl_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      '
      Dim i As Integer
      Dim PerAdl As String
      Dim UltPer As String = ""
      Dim Prd As Long
      Dim Inq As Long
      '
      GetRegForm(Me)
      '
      tbPropietario.Text = CapturaDato(Cn, "Propietarios", "Nombre", "Codigo = " & Propietario)
      '
      ArmaCbPropiedad(cbPropiedad, Propietario, "(Todas)")
      '
      ArmaCombo(cbConcepto, "Codigo", "Conceptos", "Descrip", "Codigo = '" & cfgCodigoAdl & "'", , "")
      ArmaCombo(cbDescConc, "Descrip", "Conceptos", "Descrip", "Codigo = '" & cfgCodigoAdl & "'", , "")
      '
      With cbDescConc
         If .Items.Count >= 1 Then
            .SelectedIndex = 0
         Else
            MsgBox("Código de adelanto no definido", vbInformation)
            DeshabForm(Me)
         End If
      End With
      '
      Cmd.Connection = Cn
      Cm2.Connection = Cn
      '
      If Alta Then
         Me.Text = Me.Text & " - " & Traducir("Alta")
      Else
         Me.Text = Me.Text & " - " & Traducir("Edición")
         With Cmd
            .CommandText = "SELECT * FROM LiqPropTmp WHERE Usuario = '" & Uid & "'"
            Drd = .ExecuteReader
         End With
         With Drd
            If .Read Then
               tbDetalle.Text = .Item("Detalle")
               tbImporte.Text = Format(.Item("Importe"), "Fixed")
            End If
            .Close()
         End With
      End If
      '
      With Cmd
         .CommandText = "SELECT * FROM Contratos WHERE Propietario = " & Propietario & " AND Estado <> 2"
         Drd = .ExecuteReader
      End With
      With Drd
         Do While .Read
            If .Item("Estado") = 0 Then
               If .Item("PerHasta") > UltPer Then
                  UltPer = .Item("PerHasta")
               End If
            Else
               Prd = .Item("Propiedad")
               Inq = .Item("Inquilino")
               With Cm2
                  .CommandText = "SELECT MAX(Periodo) FROM FactInq WHERE Propiedad = " & Prd & " AND Inquilino = " & Inq
                  Dr2 = .ExecuteReader
               End With
               With Dr2
                  If .Read Then
                     If .Item(0) & "" > UltPer Then
                        UltPer = .Item(0)
                     End If
                  End If
                  .Close()
               End With
            End If
         Loop
         .Close()
      End With
      '
      For i = 0 To cfgMaxMesAdl - 1
         PerAdl = Format(SumaMes(Today, i - 1), "yyyyMM")
         If PerAdl <= UltPer Then
            cbPeriodo.Items.Add(PerAdl.Substring(0, 4) & "/" & PerAdl.Substring(4, 2))
         End If
      Next i
      '
   End Sub
   '
   Private Sub frmLiqPropAdl_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
      TabReturn(e.KeyChar)
   End Sub
   '
   Private Sub cmdCancelar_Click()
      Me.Close()
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
      If Propiedad = 0 Then
         Comision = Val(CapturaDato(Cn, "Propietarios", "Comision", "Codigo = " & Propietario) & "")
         Inquilino = 0
         AgRetGan = False
      Else
         Comision = Val(CapturaDato(Cn, "Propiedades", "Comision", "Propietario = " & Propietario & " AND Codigo = " & Propiedad) & "")
         Inquilino = Val(CapturaDato(Cn, "Propiedades", "Inquilino", "Codigo = " & Propiedad) & "")
         AgRetGan = CapturaDato(Cn, "Inquilinos", "AgRetGan", "Codigo = " & Inquilino)
      End If
      '
      lblComision.Text = Traducir("Comisión ") & " " & Comision & " %"
      tbImpRet.Enabled = AgRetGan
      tbDetRet.Enabled = AgRetGan
      '
      If Not AgRetGan Then
         tbImpRet.Text = 0
         tbDetRet.Text = ""
      End If
      '
   End Sub
   '
   Private Sub cbPeriodo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbPeriodo.SelectedIndexChanged
      If tbDetalle.Text = "" Then
         tbDetalle.Text = cbDescConc.Text & " " & cbPeriodo.Text
      End If
      If cbPeriodo.Text > Format(Today, "yyyy/MM") Then
         If Not CodigoAut() Then
            cbPeriodo.SelectedIndex = 0
         End If
      End If
      If cbPeriodo.Text = "" Then
         Periodo = ""
      Else
         Periodo = cbPeriodo.Text.Substring(0, 4) & cbPeriodo.Text.Substring(5, 2)
      End If
      If TieneAdelantos(Propietario, Propiedad, Periodo) Then
         cbPeriodo.SelectedIndex = -1
      End If
   End Sub
   '
   Private Sub cbDescConc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbDescConc.SelectedIndexChanged
      cbConcepto.SelectedIndex = cbDescConc.SelectedIndex
   End Sub
   '
   Private Function ValTb() As Boolean
      '
      If cbConcepto.Text = "" Then
         MensajeTrad("DIConcepto")
         cbConcepto.Focus()
         Exit Function
      End If
      '
      If cbPeriodo.SelectedIndex = -1 Then
         MensajeTrad("DIPeriodo")
         cbPeriodo.Focus()
         Exit Function
      End If
      '
      If tbDetalle.Text = "" Then
         MensajeTrad("DIDetalle")
         tbDetalle.Focus()
         Exit Function
      End If
      '
      If Val(tbImporte.Text) <= 0 Then
         MensajeTrad("DIImporte>0")
         tbImporte.Focus()
         Exit Function
      End If
      '
      If Val(tbImpOtros.Text) > 0 Then
         If tbDetOtros.Text = "" Then
            MensajeTrad("DIDetalle")
            tbDetOtros.Focus()
            Exit Function
         End If
      End If
      '
      If Val(tbImpDesc.Text) > 0 Then
         If tbDetDesc.Text = "" Then
            MensajeTrad("DIDetalle")
            tbDetDesc.Focus()
            Exit Function
         End If
      End If
      '
      If Val(tbImpRet.Text) > 0 Then
         If tbDetRet.Text = "" Then
            MensajeTrad("DIDetalle")
            tbDetRet.Focus()
            Exit Function
         End If
      End If
      '
      If TieneAdelantos(Propietario, Propiedad, Periodo) Then
         Return False
      End If
      '
      If SuperaProy Then
         Return False
      End If
      '
      Return True
      '
   End Function
   '
   Private Function SuperaProy() As Boolean
      '
      Dim r As Boolean = False
      '
      Dim Cmd As New OleDb.OleDbCommand
      Dim Drd As OleDb.OleDbDataReader
      '
      Dim Total As Double = 0
      Dim TotAlq As Double = 0
      Dim TotOtr As Double = 0
      Dim TotDes As Double = 0
      Dim Msj As String
      '
      With Cmd
         .Connection = Cn
         .CommandText = SqlProyAdel(Propietario, Propiedad, Periodo)
         Drd = .ExecuteReader
      End With
      '
      With Drd
         Do While .Read
            Total = Total + .Item("Importe")
            If .Item("Concepto") = cfgCodigoAlq Then
               TotAlq = TotAlq + .Item("Importe")
            ElseIf .Item("Importe") > 0 Then
               TotOtr = TotOtr + .Item("Importe")
            Else
               TotDes = TotDes + .Item("Importe")
            End If
         Loop
      End With
      '
      If Total < 0 Then
         Msj = "TotalProy<0"
         r = True
      ElseIf TotAlq < Val(tbImporte.Text) Then
         Msj = "ImpAlq>Proy"
         r = True
      ElseIf TotOtr < Val(tbImpOtros.Text) Then
         Msj = "ImpOtr>Proy"
         r = True
      End If
      '
      If r Then
         If cfgAdelMayProy Then
            If cfgCodAutSup <> "" Then
               With frmCodigoAut
                  .Mensaje = Traducir(Msj)
                  .ShowDialog(Me)
                  r = Not .Autorizado
               End With
            Else
               r = False
            End If
         Else
            MensajeTrad(Msj)
         End If
      End If
      '
      Return r
      '
   End Function
   '
   Private Function Guardar() As Boolean
      '
      CalcImportes()
      '
      Try
         '
         Trn = Cn.BeginTransaction
         '
         With Cmd
            .Transaction = Trn
            .CommandText = "DELETE FROM LiqPropTmp WHERE Usuario = '" & Uid & "'"
            .ExecuteNonQuery()
            '
            .CommandText = "INSERT INTO LiqPropTmp( Periodo, Propiedad, Fecha, Concepto, Detalle, Nombre, Debe, Haber, Importe, Tipo, Sucursal, Numero, Origen, Proveedor, Usuario, FechaMod) " &
                           "VALUES('" & Format(Today, "yyyyMM") & "', " &
                                        Propiedad & ", " &
                                  "'" & Format(Today, FormatFecha) & "', " &
                                  "'" & cbConcepto.Text & "', " &
                                  "'" & tbDetalle.Text & "', " &
                                  "'" & "" & "', " &
                                        IIf(optNeto.Checked, Val(tbImporte.Text) + nCom + nIva1 + nIva2, tbImporte.Text) & ", " &
                                        0 & ", " &
                                        IIf(optNeto.Checked, Val(tbImporte.Text) + nCom + nIva1 + nIva2, tbImporte.Text) & ", " &
                                  "'" & "L" & "', " &
                                        0 & ", " &
                                        NroLiq & ", " &
                                        3 & ", " &
                                        0 & ", " &
                                  "'" & Uid & "', " &
                                  "'" & Format(Now, FormatFechaHora) & "')"
            .ExecuteNonQuery()
            '
            If Val(tbImpBon.Text) <> 0 Then
               .CommandText = "INSERT INTO LiqPropTmp( Periodo, Propiedad, Fecha, Concepto, Detalle, Nombre, Debe, Haber, Importe, Tipo, Sucursal, Numero, Origen, Proveedor, Usuario, FechaMod) " &
                              "VALUES('" & Format(Today, "yyyyMM") & "', " &
                                           Propiedad & ", " &
                                     "'" & Format(Today, FormatFecha) & "', " &
                                     "'" & cfgCodigoBon & "', " &
                                     "'" & tbDetBon.Text & "', " &
                                     "'" & "" & "', " &
                                           0 & ", " &
                                           tbImpBon.Text & ", " &
                                           tbImpBon.Text & ", " &
                                     "'" & "L" & "', " &
                                           0 & ", " &
                                           NroLiq & ", " &
                                           3 & ", " &
                                           0 & ", " &
                                     "'" & Uid & "', " &
                                     "'" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
               '
            End If
            '
            If Val(tbImpOtros.Text) <> 0 Then
               .CommandText = "INSERT INTO LiqPropTmp( Periodo, Propiedad, Fecha, Concepto, Detalle, Nombre, Debe, Haber, Importe, Tipo, Sucursal, Numero, Origen, Proveedor, Usuario, FechaMod) " &
                              "VALUES('" & Format(Today, "yyyyMM") & "', " &
                                           Propiedad & ", " &
                                     "'" & Format(Today, FormatFecha) & "', " &
                                     "'" & "OTR" & "', " &
                                     "'" & tbDetOtros.Text & "', " &
                                     "'" & "" & "', " &
                                           tbImpOtros.Text & ", " &
                                           0 & ", " &
                                           tbImpOtros.Text & ", " &
                                     "'" & "L" & "', " &
                                           0 & ", " &
                                           NroLiq & ", " &
                                           3 & ", " &
                                           0 & ", " &
                                     "'" & Uid & "', " &
                                     "'" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
               '
            End If
            '
            If Val(tbImpDesc.Text) <> 0 Then
               .CommandText = "INSERT INTO LiqPropTmp( Periodo, Propiedad, Fecha, Concepto, Detalle, Nombre, Debe, Haber, Importe, Tipo, Sucursal, Numero, Origen, Proveedor, Usuario, FechaMod) " &
                              "VALUES('" & Format(Today, "yyyyMM") & "', " &
                                           Propiedad & ", " &
                                     "'" & Format(Today, FormatFecha) & "', " &
                                     "'" & "OTR" & "', " &
                                     "'" & tbDetDesc.Text & "', " &
                                     "'" & "" & "', " &
                                           0 & ", " &
                                           tbImpDesc.Text & ", " &
                                           tbImpDesc.Text & ", " &
                                     "'" & "L" & "', " &
                                           0 & ", " &
                                           NroLiq & ", " &
                                           3 & ", " &
                                           0 & ", " &
                                     "'" & Uid & "', " &
                                     "'" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
               '
            End If
            '
            If Val(tbImpRet.Text) <> 0 Then
               .CommandText = "INSERT INTO LiqPropTmp( Periodo, Propiedad, Fecha, Concepto, Detalle, Nombre, Debe, Haber, Importe, Tipo, Sucursal, Numero, Origen, Proveedor, Usuario, FechaMod) " &
                              "VALUES('" & Format(Today, "yyyyMM") & "', " &
                                           Propiedad & ", " &
                                     "'" & Format(Today, FormatFecha) & "', " &
                                     "'" & cfgCodigoRGan & "', " &
                                     "'" & tbDetRet.Text & "', " &
                                     "'" & "" & "', " &
                                           0 & ", " &
                                           tbImpRet.Text & ", " &
                                           tbImpRet.Text & ", " &
                                     "'" & "L" & "', " &
                                           0 & ", " &
                                           NroLiq & ", " &
                                           3 & ", " &
                                           0 & ", " &
                                     "'" & Uid & "', " &
                                     "'" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
               ' 
            End If
            '
         End With
         '
         Trn.Commit()
         '
         Return True
         '
      Catch ex As SystemException
         '
         Trn.Rollback()
         '
         Dim st As New StackTrace(True)
         MensageError(st, Me.Name, Err.Number & ": " & Err.Description & Chr(13) + Chr(10) & Traducir("TransNComp"))
         '
      End Try
      '
   End Function
   '
   Private Sub optNeto_Bruto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optBruto.CheckedChanged, optNeto.CheckedChanged
      CalcImportes()
   End Sub
   '
   Private Sub tbImporte_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbImporte.TextChanged
      CalcImportes()
   End Sub
   '
   Private Sub tbImporte_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbImpAlq.KeyPress, tbImpBon.KeyPress, tbImpDesc.KeyPress, tbImporte.KeyPress, tbImpRet.KeyPress
      SoloNumeros(e.KeyChar, True)
   End Sub
   '
   Private Sub CalcImportes()
      '
      nCom = Math.Round(Val(tbImporte.Text) * Comision / 100, 2)
      nIva1 = Math.Round(nCom * AlicIva1 / 100, 2)
      nIva2 = Math.Round(nCom * AlicIva2 / 100, 2)
      If optNeto.Checked Then
         Subt = Val(tbImporte.Text) / (1 + (Comision / 100) + (Comision * AlicIva1 / 100) / 100)
         nCom = Math.Round(Subt * Comision / 100, 2)
         nIva1 = Math.Round(nCom * AlicIva1 / 100, 2)
         nIva2 = Math.Round(nCom * AlicIva2 / 100, 2)
      Else
         Subt = Val(tbImporte.Text) - nCom - nIva1 - nIva2
      End If
      '
      tbImpAlq.Text = Subt
      '
   End Sub
   '
   Private Sub cmdProyeccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdProyeccion.Click
      If cbPeriodo.Text = "" Then
         Mensaje("Debe seleccionar período")
         cbPeriodo.Focus()
         Exit Sub
      End If
      Dim Form As New frmLiqPropProy
      With Form
         .Propietario = Propietario
         .Propiedad = Propiedad
         .Periodo = cbPeriodo.Text
         .ShowDialog(Me)
         If .Seleccionar Then
            optBruto.Checked = True
            tbImporte.Text = .TotAlq
            tbImpBon.Text = Math.Abs(.TotBon)
            tbImpOtros.Text = .TotOtr
            tbImpDesc.Text = Math.Abs(.TotDesc)
            tbDetBon.Text = "BONIFICACIONES"
            tbDetOtros.Text = "OTROS"
            tbDetDesc.Text = "DESCUENTOS"
            tbImpRet.Text = 0
         End If
         .Dispose()
      End With
   End Sub
   '
   Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
      If ValTb() Then
         If Guardar() Then
            Detalle = tbDetalle.Text
            Periodo = cbPeriodo.Text
            Propiedad = cbPropiedad.SelectedValue
         End If
         Me.Close()
      End If
   End Sub
   '
   Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
      Me.Close()
   End Sub
   '
   Private Sub frmLiqPropAdl_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
      Me.Dispose()
      SetRegForm(Me)
   End Sub
   '
End Class