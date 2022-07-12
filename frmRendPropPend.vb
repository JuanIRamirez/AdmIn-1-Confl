Public Class frmRendPropPend
   '
   Dim Trn As OleDb.OleDbTransaction
   Dim Cmd As New OleDb.OleDbCommand
   Dim Propietario As Integer
   Dim cPeriodo As String
   Dim FecIni As Date
   Dim FecFin As Date
   Dim AlicIva1 As Single
   Dim AlicIva2 As Single
   '
   Private Sub frmRendPropPend_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      '
      GetRegForm(Me)
      TraducirForm(Me)
      '
      ArmaCbPropiet()
      '
      AlicIva1 = CapturaDato(Cn, "AlicIva", "Alicuo1", "Codigo = 'GEN'")
      AlicIva2 = CapturaDato(Cn, "AlicIva", "Alicuo2", "Codigo = 'GEN'")
      '
      dtpHasta.Value = Today
      '
   End Sub
   '
   Private Sub optActivos_CheckedChanged(sender As Object, e As EventArgs) Handles optActivos.CheckedChanged, optInactivos.CheckedChanged
      ArmaCbPropiet()
   End Sub
   '
   Private Sub ArmaCbPropiet()
      ArmaComboItem(cbPropietario, "Propietarios", , "Nombre", "Nombre", "(Todos)", "Estado = '" & IIf(optActivos.Checked, "A", "I") & "'")
   End Sub
   '
   Private Sub cbPropietario_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPropietario.SelectedIndexChanged
      With cbPropietario
         If .SelectedIndex > 0 Then
            Propietario = .SelectedValue
         Else
            Propietario = 0
         End If
      End With
   End Sub
   '
   Private Sub cmdAceptar_Click(sender As Object, e As EventArgs) Handles cmdAceptar.Click
      '
      Dim Reporte As String
      'Dim cCposLq1 As String
      'Dim cCposLq2 As String
      'Dim cCposCo1 As String
      'Dim cCposCo2 As String
      'Dim cCposCp1 As String
      'Dim cCposCp2 As String
      'Dim cCposAd1 As String
      'Dim cCposAd2 As String
      'Dim wPro As String
      'Dim wLiq As String
      'Dim wCob As String
      'Dim wCpo As String
      'Dim wAdl As String
      'Dim wPer As String
      'Dim wfec As String
      Dim cPer As String
      Dim cSql As New Collection
      'Dim ultFecha As Date
      Dim i As Int16
      '
      cPer = Format(dtpHasta.Value, "yyyyMM")
      'ultFecha = UltDiaMes("28/" & Format(dtpHasta.Value, "MM/yyyy"))
      ''
      'cCposLq1 = "Propietario, Right(Periodo,2) + '/' + Left(Periodo,4) AS Per, " & _
      '           "Propiedad, LiqInqDet.Fecha, LiqInqDet.Concepto, " & _
      '           "LiqInqDet.Detalle, Inquilinos.Nombre, " & _
      '           "LiqInqDet.Importe AS Debe, 0 AS Haber, " & _
      '           "LiqInqDet.Tipo, LiqInqDet.Sucursal, LiqInqDet.Numero, LiqInqDet.Renglon"
      'cCposLq2 = "Propietario, Right(Periodo,2) + '/' + Left(Periodo,4) AS Per, " & _
      '           "Propiedad, LiqInqDet.Fecha, LiqInqDet.Concepto, " & _
      '           "LiqInqDet.Detalle, Inquilinos.Nombre, " & _
      '           "0 AS Debe, LiqInqDet.Importe AS Haber, " & _
      '           "LiqInqDet.Tipo, LiqInqDet.Sucursal, LiqInqDet.Numero, LiqInqDet.Renglon"
      'wLiq = "WHERE C.Tipo = LiqInqDet.Tipo " & _
      '       "  AND C.Sucursal = LiqInqDet.Sucursal " & _
      '       "  AND C.Numero = LiqInqDet.Numero " & _
      '       "  AND C.Liquidado = 0 " & _
      '       "  AND LiqInqDet.aPropiet <> 0 " & _
      '       "  AND C.Inquilino = Inquilinos.Codigo "
      ''
      'cCposCo1 = "Propietario, '  /    ' AS Per, " & _
      '           "0 AS Propiedad, CobOtrDet.Fecha, CobOtrDet.Concepto, " & _
      '           "CobOtrDet.Detalle, C.Nombre, " & _
      '           "CobOtrDet.Importe AS Debe, 0 AS Haber, " & _
      '           "C.Tipo, C.Sucursal, C.Numero, CobOtrDet.Renglon"
      'cCposCo2 = "Propietario, '  /    ' AS Per, " & _
      '           "0 AS Propiedad, CobOtrDet.Fecha, CobOtrDet.Concepto, " & _
      '           "CobOtrDet.Detalle, C.Nombre, " & _
      '           "0 AS Debe, CobOtrDet.Importe AS Haber, " & _
      '           "C.Tipo, C.Sucursal, C.Numero, CobOtrDet.Renglon "
      'wCob = "WHERE Propietario <> 0 AND LiqPropiet = 0 " & _
      '       "  AND C.Fecha <= " & strFEC & Format(ultFecha, FormatFecha) & strFEC & _
      '       "  AND C.Tipo = CobOtrDet.Tipo " & _
      '       "  AND C.Sucursal = CobOtrDet.Sucursal " & _
      '       "  AND C.Numero = CobOtrDet.Numero " & _
      '       "  AND CobOtrDet.aPropiet <> 0 "
      '
      'cCposCp1 = "Propietario, '  /    ' AS Per, " & _
      '           "0 AS Propiedad, C.Fecha, CompraOtrDet.Concepto, " & _
      '           "CompraOtrDet.Detalle, C.Nombre, " & _
      '           "CompraOtrDet.Importe AS Debe, 0 AS Haber, " & _
      '           "LEFT(C.Comprob,2), C.Sucursal, C.Numero, CompraOtrDet.Renglon "
      'cCposCp2 = "Propietario, '  /    ' AS Per, " & _
      '           "0 AS Propiedad, C.Fecha, CompraOtrDet.Concepto, " & _
      '           "CompraOtrDet.Detalle, C.Nombre, " & _
      '           "0 AS Debe, CompraOtrDet.Importe AS Haber, " & _
      '           "LEFT(C.Comprob,2), C.Sucursal, C.Numero, CompraOtrDet.Renglon "
      'wCpo = "WHERE Propietario <> 0 AND aPropiet <> 0 AND LiqPropiet = 0 " & _
      '       "  AND C.Fecha <= " & strFEC & Format(ultFecha, FormatFecha) & strFEC & _
      '       "  AND C.Proveedor = CompraOtrDet.Proveedor " & _
      '       "  AND C.Comprob = CompraOtrDet.Comprob " & _
      '       "  AND C.Sucursal = CompraOtrDet.Sucursal " & _
      '       "  AND C.Numero = CompraOtrDet.Numero "
      ''
      'cCposAd1 = "Propietario, Right(C.Periodo,2) + '/' + Left(C.Periodo,4) AS Per, " & _
      '           "0 AS Propiedad, LiqInqDet.Fecha, LiqInqDet.Concepto, " & _
      '           "LiqInqDet.Detalle, ' - ' AS Nombre, " & _
      '           "LiqInqDet.Importe AS Debe, 0 AS Haber, " & _
      '           "LiqInqDet.Tipo, LiqInqDet.Sucursal, LiqInqDet.Numero, LiqInqDet.Renglon "
      'cCposAd2 = "Propietario, Right(C.Periodo,2) + '/' + Left(C.Periodo,4) AS Per, " & _
      '           "0 AS Propiedad, LiqInqDet.Fecha, LiqInqDet.Concepto, " & _
      '           "LiqInqDet.Detalle, ' - ' AS Nombre, " & _
      '           "0 AS Debe, LiqInqDet.Importe AS Haber, " & _
      '           "LiqInqDet.Tipo, LiqInqDet.Sucursal, LiqInqDet.Numero, LiqInqDet.Renglon "
      '***wAdl = "WHERE C.Numero = LiqInqDet.Numero " & _
      '***       "  AND LiqInqDet.Tipo = 'L' AND LiqInqDet.LiqPropiet = 0 "
      '
      '***wPer = " AND Periodo <= '" & cPer & "' "
      '***wPro = " AND C.Propietario = P.Codigo " & _
      '***IIf(Propietario = 0, "", " AND P.Codigo = " & Propietario) & _
      '***       " AND P.Estado = " & IIf(optActivos.Checked, " 'A'", "'I'")
      'IN(" & IIf(chkTodos = 1, "SELECT Codigo FROM Propietarios WHERE Estado = " & IIf(chkInactivos = 0, "'A'", "'I'"), "'" & cbPropietario(0) & "'") & ")"
      '***wfec = " AND C.Fecha <= " & strFEC & Format(ultFecha, FormatFecha) & strFEC
      '
      'cSql.Add("SELECT " & cCposLq1 & " FROM LiqInqCab C, LiqInqDet, Inquilinos, Propietarios P " &
      '         wLiq & wPro & wPer & " AND LiqInqDet.Imputacion = 'D'")
      'cSql.Add("SELECT " & cCposLq2 & " FROM LiqInqCab C, LiqInqDet, Inquilinos, Propietarios P " &
      '         wLiq & wPro & wPer & " AND LiqInqDet.Imputacion = 'H'")
      'cSql.Add("SELECT " & cCposCo1 & " FROM CobrosOtr C, CobOtrDet, Propietarios P " &
      '         wCob & wPro & wfec & " AND CobOtrDet.Imputacion = 'D'")
      'cSql.Add("SELECT " & cCposCo2 & " FROM CobrosOtr C, CobOtrDet, Propietarios P " &
      '         wCob & wPro & wfec & " AND CobOtrDet.Imputacion = 'H'")
      'cSql.Add("SELECT " & cCposCp1 & " FROM CompraOtr C, CompraOtrDet, Propietarios P " &
      '         wCpo & wPro & wfec & " AND CompraOtrDet.Imput = 'H'")
      'cSql.Add("SELECT " & cCposCp2 & " FROM CompraOtr C, CompraOtrDet, Propietarios P " &
      '         wCpo & wPro & wfec & " AND CompraOtrDet.Imput = 'D'")
      'cSql.Add("SELECT " & cCposAd1 & " FROM LiqPropiet C, LiqInqDet, Propietarios P " &
      '         wAdl & wPro & wPer & " AND LiqInqDet.Imputacion = 'D'")
      'cSql.Add("SELECT " & cCposAd2 & " FROM LiqPropiet C, LiqInqDet, Propietarios P " &
      '         wAdl & wPro & wPer & " AND LiqInqDet.Imputacion = 'H'")
      '
      cSql.Add(SQLLiqProp(cPer, Propietario, 0,,, IIf(optActivos.Checked, False, True)))
      '
      Trn = Cn.BeginTransaction
      '
      With Cmd
         .Connection = Cn
         .Transaction = Trn
         .CommandText = "DELETE FROM ResALiqProp"
         .ExecuteNonQuery()
         For i = 1 To cSql.Count
            '.CommandText = "INSERT INTO ResALiqProp( Propietario, Periodo, Propiedad, Fecha, Concepto, Detalle,     Nombre, Debe, Haber,    Tipo, Sucursal, Numero, Renglon) " & cSql.Item(i)
            .CommandText = "INSERT INTO ResALiqProp( Propietario, Periodo, Propiedad, Fecha, Concepto, Detalle, Inquilino, Nombre, Debe, Haber, Importe, Saldo, Tipo, Sucursal, Numero, Renglon, Origen, Proveedor, Retencion, LicId) " & cSql.Item(i)
            '                                                   ,     Per, Propiedad, Fecha, Concepto, Detalle, I.Codigo, Nombre, Debe, Haber, Importe, Saldo, Tipo, Sucursal, Numero, Renglon, Origen, Proveedor, Retencion, LicId 
            .ExecuteNonQuery()
         Next i
         .CommandText = "INSERT INTO ResALiqProp( Propietario, Periodo, Propiedad, Fecha, Concepto, Detalle, Nombre, Debe, Haber, Tipo, Sucursal, Numero, Renglon) " & _
                        "SELECT Propietario, '" & Strings.Right(cPer, 2) + "/" + Strings.Left(cPer, 4) & "' AS Periodo, 0 AS Propiedad, '" & Format(Today, FormatFecha) & "' AS Fecha, 'COM' AS Concepto, " & _
                        " 'Comisión Administración ' + CONVERT(VARCHAR(5), P.Comision) + '%' AS Detalle, '-' AS Nombre, " & _
                        "       0 AS Debe, SUM(Debe-Haber)*P.Comision/100 AS Haber, '-' AS Tipo, 0 AS Sucursal, 0 AS Numero, 999 AS Renglon " & _
                        "FROM ResALiqProp R, Propietarios P " & _
                        "WHERE Concepto IN('" & cfgCodigoAlq & "', '" & cfgCodigoAdl & "') " & _
                        "  AND R.Propietario = P.Codigo " & _
                        "GROUP BY R.Propietario, P.Comision"
         .ExecuteNonQuery()
         '
         '* .Open("SELECT * FROM ResALiqProp WHERE Concepto = 'COM'", Cn, adOpenKeyset, adLockPessimistic)
         'Do Until .EOF
         '   Cn.Execute "INSERT INTO ResALiqProp( Propietario, Periodo, Propiedad, Fecha, Concepto, Detalle, Nombre, Debe, Haber, Tipo, Sucursal, Numero, Renglon) " & _
         '              "VALUES( '" & !Propietario & "', " & _
         '                      "'" & !Periodo & "', " & _
         '                      "'" & !Propiedad & "', " & _
         '                      "'" & !Fecha & "', " & _
         '                      "'IVA', " & _
         '                      "'I.V.A.', '-', 0, " & _
         '                      !Haber * AlicIva1 / 100 & ", " & _
         '                      "'-', 0, 0, 1000 )"
         '   .MoveNext()
         '   Loop
         '.Close()

         .CommandText = "INSERT INTO ResALiqProp( Propietario, Periodo, Propiedad, Fecha, Concepto, Detalle, Nombre, Debe, Haber, Tipo, Sucursal, Numero, Renglon) " & _
                        "SELECT Propietario, Periodo, Propiedad, Fecha, 'IVA', 'I.V.A.', '-', 0, Haber * " & (AlicIva1 / 100) & ", '-', 0, 0, 1000 " & _
                        "FROM ResALiqProp WHERE Concepto = 'COM'"
         .ExecuteNonQuery()
      End With
      '
      Trn.Commit()
      '
      'Screen.MousePointer = vbHourglass
      '
      Reporte = IIf(chkResumen.Checked, "ResALiqPropRes", "ResALiqProp")
      '
      ImprimirCrp(Reporte, crptToWindow, "", Me.Text)
      '
      'Screen.MousePointer = vbDefault
      '
   End Sub
   '
   Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
      Me.Close()
   End Sub
   '
   Private Sub frmRendPropPend_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
      SetRegForm(Me)
      Me.Dispose()
   End Sub
   '
End Class