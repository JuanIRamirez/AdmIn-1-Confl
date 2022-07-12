Public Class frmListAdelPropSdo
   '
   Dim Trn As OleDb.OleDbTransaction
   '
   Dim Cmd As New OleDb.OleDbCommand
   Dim Cm2 As New OleDb.OleDbCommand
   Dim Cm3 As New OleDb.OleDbCommand
   '
   Dim Drd As OleDb.OleDbDataReader
   Dim Dr2 As OleDb.OleDbDataReader
   '
   Private Sub frmListAdelPropSdo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      '
      GetRegForm(Me)
      '
      Cmd.Connection = Cn
      Cm2.Connection = Cn
      Cm3.Connection = Cn
      '
      dtpDesde.Value = Today.AddDays(-30)
      dtpHasta.Value = Today
      '
   End Sub
   '
   Private Sub optTodos_CheckedChanged(sender As Object, e As EventArgs) Handles optTodos.CheckedChanged
      ActCtrl()
   End Sub
   '
   Private Sub optNoRec_CheckedChanged(sender As Object, e As EventArgs) Handles optNoRec.CheckedChanged
      ActCtrl()
   End Sub
   '
   Private Sub chkTodas_CheckedChanged(sender As Object, e As EventArgs) Handles chkTodas.CheckedChanged
      ActCtrl()
   End Sub
   '
   Private Sub ActCtrl()
      chkTodas.Enabled = optTodos.Checked
      dtpDesde.Enabled = optTodos.Checked And Not chkTodas.Checked
      dtpHasta.Enabled = Not chkTodas.Checked
   End Sub
   '
   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      '
      Dim Reporte As String
      Dim Formulas(0, 1) As String
      '
      Reporte = IIf(optRes.Checked, "AdelPropSdoRes", "AdelPropSdo")
      '
      InsListAdel()
      '
      Formulas(0, 0) = "Subtitulo" : Formulas(0, 1) = IIf(optNoRec.Checked, "No Recuperados", "Todos") & IIf(dtpDesde.Enabled, ", Del: " & dtpDesde.Value, "") & IIf(dtpHasta.Enabled, ", Al: " & dtpHasta.Value, "")
      '
      ImprimirCrp(Reporte, crptToWindow, "", Me.Text, Formulas)
      '
   End Sub
   '
   Private Sub InsListAdel()
      '
      Trn = Cn.BeginTransaction
      '
      Cmd.Transaction = Trn
      Cm2.Transaction = Trn
      '
      With Cmd
         .CommandText = "DELETE FROM ListAdel"
         .ExecuteNonQuery()
         '
         '.CommandText = "SELECT LP.Propietario, LP.Fecha, LP.Periodo, LP.Numero, LD.Detalle, LD.Imputacion, LD.Importe, LP.Propiedad " & _
         '               "FROM LiqPropiet LP, LiqInqDet LD " & _
         '               "WHERE LP.Numero = LD.Numero " & _
         '               "  AND LD.Tipo = 'L' " & _
         '               "  AND LD.Origen = 3 " & _
         '               "  AND LP.Fecha >= '" & Format(dtpDesde.Value, FormatFecha) & "'" & _
         '               "  AND LP.Fecha <= '" & Format(dtpHasta.Value, FormatFecha) & "'"
         ''     "  AND LD.Concepto = '" & cfgCodigoAdl & "'"
         .CommandText = "INSERT INTO ListAdel( Propietario, Fecha, Periodo, NumeroLiq, Detalle, Debe, Haber, Propiedad) " & _
                        "SELECT LP.Propietario, LP.Fecha, LP.Periodo, LP.Numero, LD.Detalle, LD.Importe, 0, LP.Propiedad " & _
                        "FROM LiqPropiet LP, LiqInqDet LD " & _
                        "WHERE LD.Imputacion = 'D' " & _
                        "  AND LP.Numero = LD.Numero " & _
                        "  AND LD.Tipo = 'L' " & _
                        "  AND LD.Origen = 3 " & _
                        IIf(optNoRec.Checked, "  AND LD.LiqPropiet = 0 ", "") & _
                        IIf(dtpDesde.Enabled, " AND LP.Fecha >= '" & Format(dtpDesde.Value, FormatFecha) & "'", "") & _
                        IIf(dtpHasta.Enabled, " AND LP.Fecha <= '" & Format(dtpHasta.Value, FormatFecha) & "'", "")
         .ExecuteNonQuery()
         '
         .CommandText = "INSERT INTO ListAdel( Propietario, Fecha, Periodo, NumeroLiq, Detalle, Debe, Haber, Propiedad) " & _
                        "SELECT LP.Propietario, LP.Fecha, LP.Periodo, LP.Numero, LD.Detalle, 0, LD.Importe, LP.Propiedad " & _
                        "FROM LiqPropiet LP, LiqInqDet LD " & _
                        "WHERE LD.Imputacion = 'H' " & _
                        "  AND LP.Numero = LD.Numero " & _
                        "  AND LD.Tipo = 'L' " & _
                        "  AND LD.Origen = 3 " & _
                        IIf(optNoRec.Checked, "  AND LD.LiqPropiet = 0 ", "") & _
                        IIf(dtpDesde.Enabled, " AND LP.Fecha >= '" & Format(dtpDesde.Value, FormatFecha) & "'", "") & _
                        IIf(dtpHasta.Enabled, " AND LP.Fecha <= '" & Format(dtpHasta.Value, FormatFecha) & "'", "")
         .ExecuteNonQuery()
         '
         'Drd = .ExecuteReader
         '
      End With
      '
      'Cm2.Transaction = Trn
      ''
      'With Drd
      '   Do While .Read
      '      Cm2.CommandText = "INSERT INTO ListAdel( Propietario, Fecha, Periodo, NumeroLiq, Detalle, Debe, Haber, Propiedad) " & _
      '                        "VALUES(" & .Item("Propietario") & ", '" & Format(.Item("Fecha"), FormatFecha) & "', '" & .Item("Periodo") & "', " & .Item("Numero") & ", '" & .Item("Detalle") & "', " & _
      '                        IIf(.Item("Imputacion") = "D", .Item("Importe"), 0) & ", " & IIf(.Item("Imputacion") = "H", .Item("Importe"), 0) & ", " & .Item("Propiedad") & ")"
      '      Cm2.ExecuteNonQuery()
      '   Loop
      '   .Close()
      'End With
      '
      'With Cmd
      '   '.CommandText = "SELECT DISTINCT Propietario, Propiedad, Periodo FROM ListAdel"
      '   'Drd = .ExecuteReader
      '   .CommandText = "INSERT INTO ListAdel( Propietario, Fecha, Periodo, NumeroLiq, Detalle, Debe, Haber, Propiedad) " & _
      '                  "SELECT C.Propietario, D.Fecha, C.Periodo, D.Numero, D.Detalle, D.Importe AS Debe, 0 AS Haber, C.Propiedad " & _
      '                  "FROM LiqInqCab C, LiqInqDet D, Inquilinos I " & _
      '                  "WHERE C.Tipo = D.Tipo " & _
      '                  "  AND C.Sucursal = D.Sucursal " & _
      '                  "  AND C.Numero = D.Numero " & _
      '                  "  AND D.aPropiet <> 0 " & _
      '                  "  AND C.Inquilino = I.Codigo " & _
      '                  "  AND EXISTS( SELECT DISTINCT Propietario, Propiedad, Periodo FROM ListAdel " & _
      '                  "              WHERE Propietario =  C.Propietario " & _
      '                  "                AND Propiedad = C.Propiedad " & _
      '                  "                AND Periodo = C.Periodo)"
      '   .ExecuteNonQuery()
      'End With
      '
      'With Drd
      'Do While .Read
      '
      'cCposLq1 = "Right(C.Periodo,2) + '/' + Left(C.Periodo,4) AS Per, " & _
      '     "C.Propiedad, D.Fecha, D.Concepto, " & _
      '     "D.Detalle, I.Codigo AS Inquilino, I.Nombre, " & _
      '     "D.Importe AS Debe, 0 AS Haber, " & _
      '     "D.Tipo, D.Sucursal, D.Numero, D.Renglon, " & _
      '     "0 AS Origen, 0 AS Proveedor, C.Bonos "
      'cCposLq2 = "Right(C.Periodo,2) + '/' + Left(C.Periodo,4) AS Per, " & _
      '     "C.Propiedad, D.Fecha, D.Concepto, " & _
      '     "D.Detalle, I.Codigo AS Inquilino, I.Nombre, " & _
      '     "0 AS Debe, D.Importe AS Haber, " & _
      '     "D.Tipo, D.Sucursal, D.Numero, D.Renglon, " & _
      '     "0 AS Origen, 0 AS Proveedor, C.Bonos "
      '
      'Cm2.CommandText = "SELECT C.Propietario, D.Fecha, C.Periodo, D.Numero, D.Detalle, D.Importe AS Debe, 0 AS Haber, C.Propiedad " & _
      '                  "FROM LiqInqCab C, LiqInqDet D, Inquilinos I " & _
      '                  "WHERE C.Tipo = D.Tipo AND " & _
      '                  " C.Sucursal = D.Sucursal AND " & _
      '                  " C.Numero = D.Numero AND " & _
      '                  " C.Propietario = '" & !Propietario & "' AND " & _
      '                  " C.Propiedad = '" & !Propiedad & "' AND " & _
      '                  " C.Periodo = '" & !Periodo & "' AND " & _
      '                  " D.aPropiet <> 0 AND " & _
      '                  " C.Inquilino = I.Codigo "
      'Cm2.CommandText = "INSERT INTO ListAdel( Propietario, Fecha, Periodo, NumeroLiq, Detalle, Debe, Haber, Propiedad) " & _
      '                  "SELECT C.Propietario, D.Fecha, C.Periodo, D.Numero, D.Detalle, D.Importe AS Debe, 0 AS Haber, C.Propiedad " & _
      '                  "FROM LiqInqCab C, LiqInqDet D, Inquilinos I " & _
      '                  "WHERE C.Tipo = D.Tipo AND " & _
      '                  " C.Sucursal = D.Sucursal AND " & _
      '                  " C.Numero = D.Numero AND " & _
      '                 " D.aPropiet <> 0 AND " & _
      '                 " C.Inquilino = I.Codigo " & _
      '                 " AND EXISTS( SELECT DISTINCT Propietario, Propiedad, Periodo FROM ListAdel " & _
      '                  "             WHERE Propietario =  C.Propietario " & _
      '                  "               AND Propiedad = C.Propiedad " & _
      '                  "               AND Periodo = C.Periodo "
      'Cm2.ExecuteNonQuery()
      '
      '" C.Liquidado = 0 AND "
      '
      'Dr2 = Cm2.ExecuteReader
      ''
      'Cm3.Transaction = Trn
      ''
      'With Dr2
      '   Do While .Read
      '      Cm3.CommandText = "INSERT INTO ListAdel( Propietario, Fecha, Periodo, NumeroLiq, Detalle, Debe, Haber, Propiedad) " & _
      '                        "VALUES('" & !Propietario & "', '" & !Fecha & "', '" & !Periodo & "', " & !Numero & ", '" & !Detalle & "', " & _
      '                                     !Debe & ", " & !Haber & ", '" & !Propiedad & "')"
      '      Cm3.ExecuteNonQuery()
      '   Loop
      '   .Close()
      'End With
      '
      'Loop
      '
      '.Close()
      '
      'End With
      '
      'With Cmd
      '   .CommandText = "DELETE FROM ListAdel WHERE Propietario = '" & !Propietario & "' AND Propiedad = '" & !Propiedad & "' AND Periodo = '" & !Periodo & "'"

      '   .CommandText = "SELECT DISTINCT Propietario, Propiedad, Periodo, ROUND(SUM(DEBE-HABER),2) AS Saldo " & _
      '                  "FROM ListAdel GROUP BY Propietario, Propiedad, Periodo"
      '   Drd = .ExecuteReader
      'End With
      '
      'With Drd
      '   Do While .Read
      '      If !Saldo = 0 Then
      '         Cm2.CommandText = "DELETE FROM ListAdel WHERE Propietario = '" & !Propietario & "' AND Propiedad = '" & !Propiedad & "' AND Periodo = '" & !Periodo & "'"
      '         Cm2.ExecuteNonQuery()
      '      End If
      '   Loop
      '   .Close()
      'End With
      '
      Trn.Commit()
      '
   End Sub
   '
   Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
      Me.Close()
   End Sub
   '
   Private Sub frmListAdelPropSdo_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
      SetRegForm(Me)
   End Sub
   '
End Class