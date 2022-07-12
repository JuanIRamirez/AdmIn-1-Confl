Module ModPol
   '
   Function ValidaLogin(Usr As String, Pwd As String, Optional Msg As Boolean = True) As Boolean
      '
      Dim Val As Boolean
      '
      'If AutDB Then
      Val = Not IsNothing(CapturaDato(Cn, "Usuarios", "Nombre", "Usuario = '" & Usr & "' AND [Contraseña] = '" & Encrypt(Pwd) & "'"))
         If Not Val Then
            If Msg Then
               MsgBox("Usuario/Contraseña incorrecto/a", vbInformation)
            End If
         End If
         ValidaLogin = Val
      'Else
      '   ValidaLogin = False
      'End If
      '
   End Function
   '
   Function BuscarCfg(ByVal Clave As String, ByVal ValDef As Object, Optional ByVal Tr As Object = "") As String
      '
      Dim r As Object = ValDef
      '
      Dim Cmd As New OleDb.OleDbCommand
      Dim Drd As OleDb.OleDbDataReader
      '
      With Cmd
         .Connection = Cn
         If Tr.ToString <> "" Then
            .Transaction = Tr
         End If
         .CommandText = "SELECT Valor FROM Config WHERE Clave = '" & Clave & "'"
         Drd = .ExecuteReader
      End With
      With Drd
         If .Read Then
            r = .Item("Valor")
         End If
         .Close()
      End With
      '
      Return r
      '
   End Function
   '
   Function BuscarCfg(ByVal Clave As String) As String
      '
      Dim r As Object
      '
      Dim Cmd As New OleDb.OleDbCommand
      '
      With Cmd
         .Connection = Cn
         .CommandText = "SELECT Valor FROM Config WHERE Clave = '" & Clave & "'"
         r = .ExecuteScalar & ""
      End With
      '
      Return r
      '
   End Function
   '
   Sub GuardarCfg(ByRef Var As Object, ByVal Clave As String, ByVal Valor As String, Optional ByVal Tr As Object = "")
      '
      Dim Cmd As New OleDb.OleDbCommand
      '
      With Cmd
         .Connection = Cn
         If Tr.ToString <> "" Then
            .Transaction = Tr
         End If
         If IsNothing(CapturaDato(Cn, "Config", "Valor", "Clave = '" & Clave & "'", , , , Tr)) Then
            .CommandText = "INSERT INTO Config( Clave, Valor, FechaMod) " & _
                           "VALUES('" & Clave & "', '" & Valor & "', '" & Format(Now, FormatFechaHora) & "')"
         Else
            .CommandText = "UPDATE Config SET " & _
                           " Valor = '" & Valor & "', " & _
                           " FechaMod = '" & Format(Now, FormatFechaHora) & "' " & _
                           "WHERE Clave = '" & Clave & "'"
         End If
         .ExecuteNonQuery()
      End With
      '
      Var = Valor
      '
   End Sub
   '
   Function SQLLiqProp(ByVal Periodo As String, ByVal Propietario As Long, ByVal Propiedad As Long, Optional ByVal PerAnteriores As Boolean = True, Optional ByVal PropiedNull As Boolean = False, Optional Inactivos As Boolean = False) As String
      '
      Dim ret As String
      Dim wPer As String
      Dim wPrd As String
      Dim wLiq As String
      Dim wLiqP As String
      Dim wLiqR As String
      Dim wCOt As String
      Dim wCpo As String
      Dim wAd As String
      Dim wFc As String
      Dim cCposLq1 As String
      Dim cCposLq2 As String
      Dim cCposLqR As String
      Dim cCposLP1, cCposLP2 As String
      Dim cCposFc1 As String
      Dim cCposFc2 As String
      Dim cCposCo1 As String
      'Dim cCposCo2 As String
      Dim cCposCp1 As String
      Dim cCposCp2 As String
      Dim cCposAd1 As String
      Dim cCposAd2 As String
      Dim ultFecha As Date
      Dim DdeFecha As Date
      '
      'If Propietario = 0 Then
      '   SQLLiqProp = "SELECT Right(C.Periodo,2) + '/' + Left(C.Periodo,4) AS Per, " &
      '                " C.Propiedad, D.Fecha, D.Concepto, " &
      '                " D.Detalle, I.Codigo AS Inquilino, I.Nombre, " &
      '                " D.Importe AS Debe, 0 AS Haber, " &
      '                " D.Tipo, D.Sucursal, D.Numero, D.Renglon, " &
      '                " 0 AS Origen, 0 AS Proveedor, C.Retencion, 0 AS LicId " &
      '                "FROM LiqInqCab C, LiqInqDet D, Inquilinos I " &
      '                "WHERE Propietario = 0"
      '   Exit Function
      'End If
      '
      If Periodo = "" Then
         ultFecha = Today
      Else
         ultFecha = UltDiaMes("28/" & Right(Periodo, 2) & "/" & Left(Periodo, 4))
      End If
      '
      DdeFecha = "01/" & Format(ultFecha, "MM/yyyy")
      '
      cCposLq1 = "C.Propietario, RIGHT(C.Periodo,2) + '/' + LEFT(C.Periodo,4) AS Per, " &
                 "C.Propiedad, D.Fecha, D.Concepto, " &
                 "D.Detalle, I.Codigo AS Inquilino, I.Nombre, " &
                 "D.Importe AS Debe, 0 AS Haber, D.Importe AS Importe, D.Saldo, " &
                 "D.Tipo, D.Sucursal, D.Numero, D.Renglon, " &
                 "0 AS Origen, 0 AS Proveedor, C.Retencion, CD.LicId "
      '
      cCposLq2 = "C.Propietario, RIGHT(C.Periodo,2) + '/' + LEFT(C.Periodo,4) AS Per, " &
                 "C.Propiedad, D.Fecha, D.Concepto, " &
                 "D.Detalle, I.Codigo AS Inquilino, I.Nombre, " &
                 "0 AS Debe, D.Importe AS Haber, D.Importe AS Importe, D.Saldo, " &
                 "D.Tipo, D.Sucursal, D.Numero, D.Renglon, " &
                 "0 AS Origen, 0 AS Proveedor, C.Retencion, CD.LicId "
      '
      cCposLP1 = "C.Propietario, RIGHT(C.Periodo,2) + '/' + LEFT(C.Periodo,4) AS Per, " &
                 "C.Propiedad, D.Fecha, D.Concepto, " &
                 "D.Detalle, I.Codigo AS Inquilino, I.Nombre, " &
                 "D.Importe AS Debe, 0 AS Haber, D.Importe, D.Saldo, " &
                 "D.Tipo, D.Sucursal, D.Numero, D.Renglon, " &
                 "0 AS Origen, 0 AS Proveedor, C.Retencion, 0 AS LicId "
      '
      cCposLP2 = "C.Propietario, RIGHT(C.Periodo,2) + '/' + LEFT(C.Periodo,4) AS Per, " &
                 "C.Propiedad, D.Fecha, D.Concepto, " &
                 "D.Detalle, I.Codigo AS Inquilino, I.Nombre, " &
                 "0 AS Debe, D.Importe AS Haber, D.Importe, D.Saldo, " &
                 "D.Tipo, D.Sucursal, D.Numero, D.Renglon, " &
                 "0 AS Origen, 0 AS Proveedor, C.Retencion, 0 AS LicId "
      '
      '* Retenciones Inquilino */
      cCposLqR = "C.Propietario, Right(C.Periodo, 2) + '/' + Left(C.Periodo, 4) AS Per, " &
                  "C.Propiedad, C.Fecha, 'RGN' AS Concepto, " &
                  "'RETENCION' AS Detalle, L.Inquilino, I.Nombre, 0 AS Debe, D.LcdRetencion AS Haber, D.LcdRetencion AS Importe, 0 AS Saldo, " &
                  "C.Tipo, C.Sucursal, C.Numero, 0 AS Renglon, " &
                  "0 AS Origen, 0 AS Proveedor, D.LcdRetencion AS Retencion, 0 AS LicId "
      '
      cCposFc1 = "F.Propietario, Right(F.Periodo,2) + '/' + Left(F.Periodo,4) AS Per, " &
                 "F.Propiedad, F.Fecha, F.Concepto, " &
                 "F.Detalle, F.Inquilino, '' AS Nombre, " &
                 "F.Importe AS Debe, 0 AS Haber, F.Importe, 0 AS Saldo, " &
                 "'F' AS Tipo, 0 AS Sucursal, F.FactInqID AS Numero, 1 AS Renglon, " &
                 "4 AS Origen, 0 AS Proveedor, 0 AS Retencion, 0 AS LicId "
      '
      cCposFc2 = "F.Propietario, Right(F.Periodo,2) + '/' + Left(F.Periodo,4) AS Per, " &
                 "F.Propiedad, F.Fecha, F.Concepto, " &
                 "F.Detalle, F.Inquilino, '' AS Nombre, " &
                 "0 AS Debe, F.Importe AS Haber, F.Importe, 0 AS Saldo," &
                 "'F' AS Tipo, 0 AS Sucursal, F.FactInqID AS Numero, 1 AS Renglon, " &
                 "4 AS Origen, 0 AS Proveedor, 0 AS Retencion, 0 AS LicId "
      '
      wLiq = "C.Tipo = D.Tipo AND " &
             "C.Sucursal = D.Sucursal AND " &
             "C.Numero = D.Numero AND " &
             "C.Liquidado = 0 AND " &
             "C.Propietario = P.Codigo AND " &
             IIf(Propietario = 0, "", "C.Propietario = " & Propietario & " AND ") &
             "P.Estado = '" & IIf(Inactivos, "I", "A") & "' AND " &
             "D.aPropiet <> 0 AND " &
             "C.Estado IN(0) AND " &
             "C.Inquilino = I.Codigo AND " &
             "C.LiqInqId = CD.LiqInqId "
      '
      wLiqP = IIf(Propietario = 0, "", "C.Propietario = " & Propietario & " AND ") &
              "C.Estado = 1 " &
              " AND P.Estado = '" & IIf(Inactivos, "I", "A") & "' " &
              " AND CD.LiqPropiet = 0 " &
              " AND D.aPropiet <> 0 "
      '
      'wLiqR = "D.LiqInqId IN( SELECT TOP 1 C.LiqInqID FROM LiqInqCab C " &
      '                       "WHERE C.Liquidado = 0 AND " &
      '                       IIf(Propietario = 0, "", "C.Propietario = " & Propietario & " AND ") &
      '                       "C.Inquilino = L.Inquilino AND C.Estado IN( 0, 1) ORDER BY Fecha DESC) " &
      '        " AND P.Estado = '" & IIf(Inactivos, "I", "A") & "' AND L.LicRetencion > 0 "
      '*** 2022-02-11 ***
      wLiqR = " D.LiqInqId IN( " &
              "  SELECT CD.LiqInqId FROM LiqInqCab C " &
              "  INNER JOIN LiqInqCobDet CD On C.LiqInqID = CD.LiqInqId " &
              "  INNER JOIN LiqInqDet D ON C.LiqInqID = D.LiqInqID " &
              "  WHERE CD.LiqPropiet = 0 " &
              "    AND CD.LcdRetencion > 0 " &
              "    AND C.Propietario = " & Propietario &
              "    AND C.Inquilino = L.Inquilino " &
              "    AND C.Estado IN( 0, 1) " &
              "    AND D.aPropiet <> 0) " &
              " AND P.Estado = '" & IIf(Inactivos, "I", "A") & "' "
      '***
      wFc = "F.Liquidado = 0 And " &
            "P.Estado = '" & IIf(Inactivos, "I", "A") & "' AND " &
            IIf(Propietario = 0, "", "F.Propietario = " & Propietario & " AND ") &
            "F.Inquilino = 0 "
      '
      cCposCo1 = "C.Propietario, '  /    ' AS Per, NULL AS Propiedad, D.Fecha, " &
                 "D.Concepto, D.Detalle, NULL AS Inquilino, C.Nombre, " &
                 "D.Importe AS Debe, 0 AS Haber, D.Importe, 0 AS Saldo, " &
                 "C.Tipo, C.Sucursal, C.Numero, D.Renglon, " &
                 "2 AS Origen, 0 AS Proveedor, 0 AS Retencion, 0 AS LicId "
      'cCposCo2 = "C.Propietario, '  /    ' AS Per, NULL AS Propiedad, D.Fecha, " &
      '           "D.Concepto, D.Detalle, NULL AS Inquilino, C.Nombre, " &
      '           "0 AS Debe, D.Importe AS Haber, D.Importe, 0 AS Saldo, " &
      '           "C.Tipo, C.Sucursal, C.Numero, D.Renglon, " &
      '           "2 AS Origen, 0 AS Proveedor, 0 AS Retencion, 0 AS LicId "   ', " & _
      '
      wCOt = IIf(Propietario = 0, "", "C.Propietario = " & Propietario & " AND ") &
             "P.Estado = '" & IIf(Inactivos, "I", "A") & "' AND " &
             "C.Propietario = P.Codigo AND " &
             "D.Apropiet <> 0 AND " &
             "C.LiqPropiet = 0 AND " &
             IIf(PerAnteriores, "", "D.Fecha >= " & strFEC & Format(DdeFecha, FormatFecha) & strFEC & " AND ") &
             "D.Fecha <= " & strFEC & Format(ultFecha, FormatFecha) & strFEC & " AND " &
             "C.Tipo = D.Tipo AND " &
             "C.Sucursal = D.Sucursal AND " &
             "C.Numero = D.Numero "
      '
      cCposCp1 = "C.Propietario, '  /    ' AS Per, NULL AS Propiedad, D.Fecha," &
                 "D.Concepto, D.Detalle, NULL AS Inquilino, C.Nombre, " &
                 "D.Importe AS Debe, 0 AS Haber, D.Importe, 0 AS Saldo, " &
                 "C.Comprob AS Tipo, C.Sucursal, C.Numero, D.Renglon, " &
                 "1 AS Origen, C.Proveedor, 0 AS Retencion, 0 AS LicId "
      cCposCp2 = "C.Propietario, '  /    ' AS Per, NULL AS Propiedad, D.Fecha," &
                 "D.Concepto, D.Detalle, NULL AS Inquilino, C.Nombre, " &
                 "0 AS Debe, D.Importe AS Haber, D.Importe, 0 AS Saldo, " &
                 "C.Comprob AS Tipo, C.Sucursal, C.Numero, D.Renglon, " &
                 "1 AS Origen, C.Proveedor, 0 AS Retencion, 0 AS LicId "
      '
      wPrd = IIf(Propiedad = 0, "", "(C.Propiedad = " & Propiedad & "" & IIf(PropiedNull, " OR C.Propiedad = 0 OR C.Propiedad IS NULL", "") & " ) AND ")
      '
      wCpo = IIf(Propietario = 0, "", "C.Propietario = " & Propietario & " AND ") &
             "P.Estado = '" & IIf(Inactivos, "I", "A") & "' AND " &
             "C.Propietario = P.Codigo AND " &
             wPrd &
             " D.aPropiet <> 0 AND C.LiqPropiet = 0 " &
             IIf(PerAnteriores, "", " AND D.Fecha >= " & strFEC & Format(DdeFecha, FormatFecha) & strFEC) &
             " AND D.Fecha <= " & strFEC & Format(ultFecha, FormatFecha) & strFEC &
             " AND C.Proveedor = D.Proveedor AND C.Comprob = D.Comprob " &
             " AND C.Sucursal = D.Sucursal AND C.Numero = D.Numero "
      '
      cCposAd1 = "C.Propietario, Right(C.Periodo,2) + '/' + Left(C.Periodo,4) AS Per, " &
                 "C.Propiedad, D.Fecha, D.Concepto, " &
                 "D.Detalle, NULL AS Inquilino, ' - ' AS Nombre, " &
                 "D.Importe AS Debe, 0 AS Haber, D.Importe, 0 AS Saldo, " &
                 "D.Tipo, D.Sucursal, D.Numero, D.Renglon, " &
                 "3 AS Origen, 0 AS Proveedor, 0 AS Retencion, 0 AS LicId "
      cCposAd2 = "C.Propietario, Right(C.Periodo,2) + '/' + Left(C.Periodo,4) AS Per, " &
                 "C.Propiedad, D.Fecha, D.Concepto, " &
                 "D.Detalle, NULL AS Inquilino, ' - ' AS Nombre, " &
                 "0 AS Debe, D.Importe AS Haber, D.Importe, 0 AS Saldo, " &
                 "D.Tipo, D.Sucursal, D.Numero, D.Renglon, " &
                 "3 AS Origen, 0 AS Proveedor, 0 AS Retencion, 0 AS LicId "
      '
      wAd = "C.Numero = D.Numero AND " &
            wPrd &
            IIf(Propietario = 0, "", " C.Propietario = " & Propietario & " AND ") &
            "P.Estado = '" & IIf(Inactivos, "I", "A") & "' AND " &
            "C.Propietario = P.Codigo AND " &
            "D.Tipo = 'L' AND D.LiqPropiet = 0 "
      '
      wPer = " AND Periodo " & IIf(PerAnteriores, "<=", "=") & " '" & Periodo & "' "
      '
      ret = "SELECT " & cCposLq1 & " FROM LiqInqCab C, LiqInqDet D, Inquilinos I, LiqInqCobDet CD, Propietarios P " &
            "WHERE " & wLiq & wPer & " AND " & wPrd & " D.Imputacion = 'D' UNION " &
            "SELECT " & cCposLq2 & " FROM LiqInqCab C, LiqInqDet D, Inquilinos I, LiqInqCobDet CD, Propietarios P  " &
            "WHERE " & wLiq & wPer & " AND " & wPrd & " D.Imputacion = 'H' " &
            "UNION " &
            "SELECT DISTINCT " & cCposLP1 & " FROM LiqInqCob L INNER JOIN LiqInqCobDet CD on L.LicId = CD.LicId INNER JOIN LiqInqCab C on CD.LiqInqId = C.LiqInqID INNER JOIN Inquilinos I ON C.Inquilino = I.Codigo INNER JOIN LiqInqDet D ON D.LiqInqId = C.LiqInqId INNER JOIN Propietarios P ON C.Propietario = P.Codigo " &
            "WHERE " & wLiqP & wPer & " AND " & wPrd & " D.Imputacion = 'D' AND D.LiqPropiet = 0 " &
            "UNION " &
            "SELECT DISTINCT " & cCposLP2 & " FROM LiqInqCob L INNER JOIN LiqInqCobDet CD on L.LicId = CD.LicId INNER JOIN LiqInqCab C on CD.LiqInqId = C.LiqInqID INNER JOIN Inquilinos I ON C.Inquilino = I.Codigo INNER JOIN LiqInqDet D ON D.LiqInqId = C.LiqInqId INNER JOIN Propietarios P ON C.Propietario = P.Codigo " &
            "WHERE " & wLiqP & wPer & " AND " & wPrd & " D.Imputacion = 'H' AND D.LiqPropiet = 0 " &
            "UNION " &
            "SELECT " & cCposLqR & " FROM LiqInqCob L INNER JOIN LiqInqCobDet D ON L.LicId = D.LicId INNER JOIN Inquilinos I ON L.Inquilino = I.Codigo INNER JOIN LiqInqCab C ON C.LiqInqId = D.LiqInqId INNER JOIN Propietarios P ON C.Propietario = P.Codigo " &
            "WHERE " & wLiqR & wPer & " AND " & wPrd & " L.LiqPropiet = 0 AND D.LcdRetencion <> 0 " &
            "UNION " &
            "SELECT " & cCposFc1 & " FROM FactInq F INNER JOIN Propietarios P ON F.Propietario = P.Codigo " &
            "WHERE " & wFc & IIf(Propiedad = 0, "", " And Propiedad = " & Propiedad) & " And Imputacion = 'H' " &
            "UNION " &
            "SELECT " & cCposFc2 & " FROM FactInq F INNER JOIN Propietarios P ON F.Propietario = P.Codigo " &
            "WHERE " & wFc & IIf(Propiedad = 0, "", " AND Propiedad = " & Propiedad) & " AND Imputacion = 'D' " &
            "UNION " &
            "SELECT " & cCposCo1 & " FROM CobrosOtr C, CobOtrDet D, Propietarios P " &
            "WHERE " & wCOt & " AND D.Imputacion = 'D' UNION " &
            "SELECT " & cCposCo1 & " FROM CobrosOtr C, CobOtrDet D, Propietarios P " &
            "WHERE " & wCOt & " AND D.Imputacion = 'H' " &
            "UNION " &
            "SELECT " & cCposCp1 & " FROM CompraOtr C, CompraOtrDet D, Propietarios P " &
            "WHERE " & wCpo & " And D.Imput = 'H' UNION " &
            "SELECT " & cCposCp2 & " FROM CompraOtr C, CompraOtrDet D, Propietarios P " &
            "WHERE " & wCpo & " AND D.Imput = 'D' " &
            "UNION " &
            "SELECT " & cCposAd1 & " FROM LiqPropiet C, LiqInqDet D, Propietarios P " &
            "WHERE " & wAd & wPer & " AND D.Imputacion = 'D' " &
            " UNION " &
            "SELECT " & cCposAd2 & " FROM LiqPropiet C, LiqInqDet D, Propietarios P " &
            "WHERE " & wAd & " AND D.Imputacion = 'H' " & wPer &
            "ORDER BY D.Fecha, Numero "
      '
      Return ret
      '
   End Function
   '
   Function GuardarLiqProp(ByVal Propietario As Long, ByVal Periodo As String, ByVal Propiedad As Long, _
                           ByVal Comision As Double, ByVal Iva1 As Double, ByVal Iva2 As Double, ByVal RetGan As Double, _
                           ByVal Letra As String, ByVal NroRetG As Long, ByVal Recibo As Long, ByVal Detalle As String, _
                           ByVal ImpAlq As Double, ByVal ImpAlqRet As Double, ByVal ImpRetInq As Double, ByVal Debe As Double, ByVal Haber As Double, _
                           ByVal Total As Double, ByVal Efectivo As Double, ByVal Cheques As Double, _
                           ByVal NetoCom As Double, ByVal BonosInq As Double, ByVal DataGrid As DataGridView, _
                           ByVal Adelanto As Boolean, ByVal ImpAdl As Double, ByVal AcuPer As Double, ByVal NetoGan As Double, _
                           ByVal Subtotal As Double, ByVal cCtaPro As String, ByVal cCtaAdl As String, _
                           ByVal cCtaInt As String, ByVal cCtaCaja As String, ByVal cCtaCAdm As String, ByVal cCtaIDF1 As String, _
                           ByVal cCtaIDF2 As String, ByVal cCtaRGan As String, ByVal cCtaCajaAd As String, _
                           ByVal cCtaVCar As String, ByVal nTipo As Integer, ByVal cImput As String, _
                           ByVal vTipoIva As String, ByVal cCuitProp As String, ByVal cDescCAdm As String, _
                           ByVal ImporteTr As Double, ByVal GastosBanc As Double, ByVal TablaTr As String, Optional ByVal TablaCh As String = "", _
                           Optional ByVal Pendiente As Boolean = False, Optional ByVal ConfPendientes As Boolean = False, _
                           Optional ByVal Tr As Object = "") As Long
      '
      Dim Rs As New OleDb.OleDbCommand
      Dim RsD As New OleDb.OleDbCommand
      Dim Dr As OleDb.OleDbDataReader
      '
      Dim Renglon, RenLiq As Int16
      '
      Dim cComprob As String
      Dim cDetCaja As String
      Dim cTipo As String
      Dim cComp As String = ""
      '
      Dim NroAsi As Long
      Dim RenASi As Integer
      Dim DetAsi As String
      '
      Dim nImpCaja As Double
      Dim nImpCmpO As Double
      Dim nImpInt As Double
      Dim nDebe As Double
      Dim nHaber As Double
      Dim nImpProp As Double
      '
      Dim NroLiq As Long
      Dim DescProp As String
      Dim Factura As Long
      '
      Dim LiqPropTrID As Long
      Dim nBanco As Integer
      Dim cCuenta As String
      Dim cCtaBanco As String
      Dim nContCh As Integer
      Dim cNumero As String
      Dim CommitTr As Boolean = False
      Dim i As Int16
      Dim cNroLiq As String = ""
      '
      Const cmpInt = "LP"
      Const estEMIT = 1
      '
      Try
         '
         If Tr.ToString = "" Then
            Tr = Cn.BeginTransaction
            CommitTr = True
         End If
         '
         NroLiq = CaptNroLiqProp(Tr)
         '
         cComprob = cmpInt & "-" & Val(NroLiq)
         DescProp = CapturaDato(Cn, "Propietarios", "Nombre", "Codigo = " & Propietario, , , , Tr)
         DetAsi = Left(DescProp, 50)
         nImpCaja = Comision + Iva1 + Iva2 + RetGan
         '
         If TablaCh = "" Then
            TablaCh = "ChLiqProTmp"
         End If
         '
         GuardarCfg(cfgNroLiqP, "cfgNroLiqP", NroLiq, Tr)
         '
         If Val(Comision) = 0 Then
            Factura = 0
         Else
            Factura = CaptNroFactura(Letra, prmSucursal, Tr)
            If Letra = "A" Then
               GuardarCfg(cfgNroFactA, "cfgNroFactA", Factura, Tr)
            ElseIf Letra = "B" Then
               GuardarCfg(cfgNroFactB, "cfgNroFactB", Factura, Tr)
            Else
               GuardarCfg(cfgNroFactC, "cfgNroFactC", Factura, Tr)
            End If
         End If
         '
         If Val(NroRetG) > 0 Then
            NroRetG = CaptNroRetGan(Tr)
            GuardarCfg(cfgNroRetG, "cfgNroRetG", NroRetG, Tr)
         End If
         '
         With Rs
            .Connection = Cn
            .Transaction = Tr
            .CommandText = "INSERT INTO LiqPropiet( Numero, Propietario, Periodo, Fecha, FechaC, Recibo, Tipo, Sucursal, Factura, Detalle, Alquiler, Debe, Haber, Comision, Iva1, Iva2, RetGcias, Total, Efectivo, Cheque, NroCheque, Estado, Caja, NetoCom, Bonos, Propiedad, Usuario, FechaMod, AlquilerRet, ImporteTr, RetencionInq, GastosBanc) " & _
                           "VALUES( " & NroLiq & ", " & _
                                        Propietario & ", " & _
                                  "'" & Periodo & "', " & _
                                  "'" & Format(Today, FormatFecha) & "', " & _
                                  "'" & Format(Today, FormatFecha) & "', " & _
                                        Recibo & ", " & _
                                  "'" & Letra & "', " & _
                                        prmSucursal & ", " & _
                                        Factura & ", " & _
                                  "'" & Detalle & "', " & _
                                        ImpAlq & ", " & _
                                        Debe & ", " & _
                                        Haber & ", " & _
                                        Comision & ", " & _
                                        Iva1 & ", " & _
                                        Iva2 & ", " & _
                                        RetGan & ", " & _
                                        Total & ", " & _
                                        Efectivo & ", " & _
                                        Cheques & ", " & _
                                        0 & ", " & _
                                        IIf(Pendiente, 3, IIf(ConfPendientes, 0, 0)) & ", " & _
                                        prmNroCaja & ", " & _
                                        NetoCom & ", " & _
                                        BonosInq & ", " & _
                                        Propiedad & ", " & _
                                  "'" & Uid & "', " & _
                                  "'" & Format(Now, FormatFechaHora) & "', " & _
                                        ImpAlqRet & ", " & _
                                        ImporteTr & ", " & _
                                        ImpRetInq & ", " & _
                                        GastosBanc & ")"
            .ExecuteNonQuery()
         End With
         '
         If Not Adelanto And Not ConfPendientes Then
            With Rs
               '*** Nuevo 2021-11-09 ***
               '.CommandText = "UPDATE LiqInqCob SET LiqPropiet = " & NroLiq &
               '               " WHERE LicId IN ( SELECT DISTINCT CD.LicId FROM LiqInqCob L " &
               '               " INNER JOIN LiqInqCobDet CD on L.LicId = CD.LicId " &
               '               " INNER Join LiqInqCab C on CD.LiqInqId = C.LiqInqID " &
               '               " INNER Join Inquilinos I ON C.Inquilino = I.Codigo INNER JOIN LiqInqDet D ON D.LiqInqId = C.LiqInqId " &
               '               " WHERE C.Propietario = " & Propietario &
               '               "   AND C.Estado = 1 And L.LiqPropiet = 0 And D.aPropiet <> 0 And Periodo <= '" & Periodo & "' " &
               '               IIf(Propiedad = 0, "", " AND C.Propiedad = " & Propiedad) & " )"
               '*** Nuevo 2022-02-10 ***
               .CommandText = "UPDATE LiqInqCobDet SET LiqPropiet = " & NroLiq &
                              " WHERE LiqInqId IN ( " &
                              "  SELECT DISTINCT C.LiqInqId FROM LiqInqCab C " &
                              "  INNER JOIN LiqInqCobDet CD ON CD.LiqInqId = C.LiqInqID  " &
                              "  INNER JOIN LiqInqDet D ON D.LiqInqId = C.LiqInqId " &
                              "  WHERE C.Propietario = " & Propietario &
                              "  AND C.Estado IN( 0, 1) AND CD.LiqPropiet = 0 AND D.aPropiet <> 0 AND Periodo <= '" & Periodo & "' " &
                              IIf(Propiedad = 0, "", " AND C.Propiedad = " & Propiedad) & " )"
               .ExecuteNonQuery()
               '***
            End With
         End If
         '
         With DataGrid
            If .RowCount > 0 Then
               For i = 0 To .RowCount - 1
                  If ConfPendientes Then
                     Rs.CommandText = "UPDATE LiqPropiet Set Estado = 1 WHERE Numero = " & .Item("Numero", i).Value
                     Rs.ExecuteNonQuery()
                     '
                     Rs.CommandText = "INSERT INTO LiqPropietAg( Numero, LiqPropiet, Usuario, FechaMod) " &
                                      "VALUES(" & NroLiq & ", " & .Item("Numero", i).Value & ", '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
                     Rs.ExecuteNonQuery()
                     cNroLiq = IIf(cNroLiq = "", "", cNroLiq & " ,") & .Item("Numero", i).Value
                  Else
                     If .Item("Origen", i).Value = 0 Then
                        '
                        If .Item("Concepto", i).Value = cfgCodigoInt Then
                           nImpInt = nImpInt + .Item("Debe", i).Value - .Item("Haber", i).Value
                        End If
                        '
                        Rs.CommandText = "UPDATE LiqInqCab SET LiqPropiet = " & NroLiq & ", Liquidado = 1 WHERE Tipo = '" & .Item("Tipo", i).Value & "' AND Sucursal = " & .Item("Sucursal", i).Value & " AND Numero = " & .Item("Numero", i).Value
                        Rs.ExecuteNonQuery()
                        '
                        If .Item("Renglon", i).Value > 0 Then
                           Rs.CommandText = "UPDATE LiqInqDet SET LiqPropiet = " & NroLiq & " WHERE Tipo = '" & .Item("Tipo", i).Value & "' AND Sucursal = " & .Item("Sucursal", i).Value & " AND Numero = " & .Item("Numero", i).Value & " AND Renglon = " & .Item("Renglon", i).Value
                           Rs.ExecuteNonQuery()
                        End If
                        '
                        'If .Item("LicId", i).Value > 0 Then
                        '   Rs.CommandText = "UPDATE LiqInqCob SET LiqPropiet = " & NroLiq & " WHERE LicId = " & .Item("LicId", i).Value
                        '   Rs.ExecuteNonQuery()
                        'End If
                     ElseIf .Item("Origen", i).Value = 4 Then
                        Rs.CommandText = "UPDATE FactInq SET TipoNroRbo = 'LP." & NroLiq & "', Liquidado = 1, Saldo = 0 WHERE FactInqId = " & .Item("Numero", i).Value
                        Rs.ExecuteNonQuery()
                        '
                        Renglon = Renglon + 1
                        Rs.CommandText = "INSERT INTO LiqInqDet( Tipo, Sucursal, Numero, Renglon, Concepto, Fecha, Detalle, Importe, Imputacion, aPropiet, Saldo, LiqPropiet, Origen, Comprob, Usuario, FechaMod) " &
                                         "VALUES( 'F', " &
                                                  prmSucursal & ", " &
                                                  NroLiq & ", " &
                                                  Renglon & ", " &
                                            "'" & .Item("Concepto", i).Value & "', " &
                                            "'" & Format(.Item("Fecha", i).Value, FormatFecha) & "', " &
                                            "'" & .Item("Detalle", i).Value & "', " &
                                                  .Item("Debe", i).Value + .Item("Haber", i).Value & ", " &
                                            "'" & IIf(.Item("Debe", i).Value <> 0, "D", "H") & "', " &
                                                  1 & ", " &
                                                  0 & ", " &
                                                  NroLiq & ", " &
                                            "'" & .Item("Origen", i).Value & "', " &
                                            "'" & cComp & "', " &
                                            "'" & Uid & "', " &
                                            "'" & Format(Now, FormatFechaHora) & "')"
                        Rs.ExecuteNonQuery()
                        '
                     Else
                        '
                        If .Item("Origen", i).Value = 1 Then
                           Rs.CommandText = "UPDATE CompraOtr SET LiqPropiet = " & NroLiq & ", Liquidado = 1 WHERE Proveedor = " & .Item("Proveedor", i).Value & " AND Comprob = '" & .Item("Tipo", i).Value & "' AND Sucursal = " & .Item("Sucursal", i).Value & " AND Numero = " & .Item("Numero", i).Value
                           Rs.ExecuteNonQuery()
                           '
                           cTipo = "-"
                           cComp = CapturaDato(Cn, "CompraOtr", "Comprob", "Proveedor = " & .Item("Proveedor", i).Value & " AND Comprob = '" & .Item("Tipo", i).Value & "' AND Sucursal = " & .Item("Sucursal", i).Value & " AND Numero = " & .Item("Numero", i).Value, , , , Tr)
                           nImpCmpO = nImpCmpO + .Item("Haber", i).Value
                           '
                        ElseIf .Item("Origen", i).Value = 2 Then
                           Rs.CommandText = "UPDATE CobrosOtr SET LiqPropiet = " & NroLiq & ", Liquidado = 1 WHERE Tipo = '" & .Item("Tipo", i).Value & "' AND Sucursal = " & .Item("Sucursal", i).Value & " AND Numero = " & .Item("Numero", i).Value
                           Rs.ExecuteNonQuery()
                           cTipo = CapturaDato(Cn, "CobrosOtr", "Tipo", "Tipo = '" & .Item("Tipo", i).Value & "' AND Sucursal = " & .Item("Sucursal", i).Value & " AND Numero = " & .Item("Numero", i).Value, , , , Tr)
                           cComp = ""
                           '
                        ElseIf .Item("Origen", i).Value = 3 Then
                           cTipo = .Item("Tipo", i).Value
                           cComp = ""
                        End If
                        '
                        If .Item("Origen", i).Value < 3 Or Adelanto Then
                           Renglon = Renglon + 1
                           Rs.CommandText = "INSERT INTO LiqInqDet( Tipo, Sucursal, Numero, Renglon, Concepto, Fecha, Detalle, Importe, Imputacion, aPropiet, Saldo, LiqPropiet, Origen, Comprob, Usuario, FechaMod) " &
                                            "VALUES( 'L', " &
                                                      prmSucursal & ", " &
                                                      NroLiq & ", " &
                                                      Renglon & ", " &
                                                "'" & .Item("Concepto", i).Value & "', " &
                                                "'" & Format(.Item("Fecha", i).Value, FormatFecha) & "', " &
                                                "'" & .Item("Detalle", i).Value & "', " &
                                                      .Item("Debe", i).Value + .Item("Haber", i).Value & ", " &
                                                "'" & IIf(.Item("Debe", i).Value <> 0, IIf(Adelanto, "H", "D"), IIf(Adelanto, "D", "H")) & "', " &
                                                      1 & ", " &
                                                      0 & ", " &
                                                      IIf(Adelanto, 0, NroLiq) & ", " &
                                                "'" & .Item("Origen", i).Value & "', " &
                                                "'" & cComp & "', " &
                                                "'" & Uid & "', " &
                                                "'" & Format(Now, FormatFechaHora) & "')"
                           Rs.ExecuteNonQuery()
                        Else
                           Rs.CommandText = "UPDATE LiqInqDet SET LiqPropiet = " & NroLiq & " WHERE Tipo = '" & .Item("Tipo", i).Value & "' AND Sucursal = " & .Item("Sucursal", i).Value & " AND Numero = " & .Item("Numero", i).Value & " AND Renglon = " & .Item("Renglon", i).Value
                           Rs.ExecuteNonQuery()
                        End If
                        '
                     End If
                     '
                     RenLiq = RenLiq + 1
                     '
                     Rs.CommandText = "INSERT INTO LiqPropietDet( Numero, Renglon, Concepto, Fecha, Detalle, Importe, Debe, Haber, Saldo, Comprob, Origen, Usuario, FechaMod) " &
                                      "VALUES(" & NroLiq & ", " &
                                                  RenLiq & ", " &
                                            "'" & .Item("Concepto", i).Value & "', " &
                                            "'" & Format(.Item("Fecha", i).Value, FormatFecha) & "', " &
                                            "'" & .Item("Detalle", i).Value & " - " & .Item("Nombre", i).Value & "', " &
                                                  .Item("Importe", i).Value & ", " &
                                                  .Item("Debe", i).Value & ", " &
                                                  .Item("Haber", i).Value & ", " &
                                                  IIf(Adelanto, 0, .Item("Saldo", i).Value) & ", " &
                                            "'" & cComp & "', " &
                                                  .Item("Origen", i).Value & ", " &
                                            "'" & Uid & "', " &
                                            "'" & Format(Now, FormatFechaHora) & "')"
                     Rs.ExecuteNonQuery()
                     '
                     'If !Concepto = cfgCodigoAdl Then
                     '   cCtaAdm = cCtaAdl
                     'Else
                     '   'rsConc.Seek "=", !Concepto
                     '   Rs.Open "SELECT CtaAdm FROM Conceptos WHERE Codigo = '" & !Concepto & "'", Cn, adOpenForwardOnly, adLockReadOnly
                     '   cCtaAdm = Rs!CtaAdm
                     '   Rs.Close
                     'End If
                     '
                     'Detalle Asiento (Conceptos Liquidados).
                     'RenAsi = RenAsi + 1
                     'If Not GuardaAsienDet(NroAsi, RenAsi, cCtaAdm, DetAsi, !Debe, !Haber) Then
                     '   Err.Raise 1001, , Traducir("NoUpAsiento")
                     'End If
                  End If
               Next i
            End If
         End With
         '
         If NroRetG > 0 Then
            With Rs
               .CommandText = "INSERT INTO RetGcias( Numero, Fecha, Propietario, PeriodoC, Periodo, Acumulado, Neto, Retenido, Agente, DDJJAño, LiqPropiet, Usuario, FechaMod) " &
                              "VALUES( " & NroRetG & ", " &
                                     "'" & Format(Today, FormatFecha) & "', " &
                                           Propietario & ", " &
                                     "'" & Format(Today, "MMM") & " / " & Year(Today) & "', " &
                                     "'" & Year(Today) & Format(Month(Today), "00") & "', " &
                                           AcuPer & ", " &
                                           NetoGan & ", " &
                                           RetGan & ", " &
                                     "'" & cfgNomEmp & "', " &
                                           Year(Today) & ", " &
                                           NroLiq & ", " &
                                     "'" & Uid & "', " &
                                     "'" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
            End With
         End If
         '
         With Rs
            .CommandText = "DELETE FROM LiqAux WHERE Usuario = '" & Uid & "' AND LqxPC = '" & NombrePC & "'"
            .ExecuteNonQuery()
            .CommandText = "INSERT INTO LiqAux( Recibe, SonPesos, Periodo, Usuario, LqxPc, Numero) " & _
                           "VALUES('" & cfgNomEmp & "', " & _
                                  "'" & Numero_a_Texto(Total) & "', " & _
                                  "'" & Periodo & "', " & _
                                  "'" & Uid & "', " & _
                                  "'" & NombrePC & "', " & _
                                        NroLiq & ")"
            .ExecuteNonQuery()
         End With
         '
         'Asiento Liquidación.
         If SisContable Then
            NroAsi = GuardaAsiento(cComprob, Today, DetAsi, Tr)
            '
            If NroAsi = 0 Then
               Err.Raise(1001, , Traducir("NoUpAsiento", , Tr))
            End If
            '
            'Detalle Asiento (Propietario).
            'RenASi = 1
            'If Not GuardaAsienDet(NroAsi, RenASi, cCtaPro, DetAsi, tSubtotal - nImpInt, 0) Then
            '   Err.Raise 1001, , Traducir("NoUpAsiento")
            'End If
            'Detalle Asiento (Propietario).
            'If vImpAdl = 0 Then
            nImpProp = Math.Round(Subtotal - nImpInt - ImpAdl, 2)
            If nImpProp <> 0 Then   'Nuevo 20/12/2005.
               RenASi = 1
               If nImpProp > 0 Then
                  If Not GuardaAsienDet(NroAsi, RenASi, cCtaPro, DetAsi, nImpProp, 0, Tr) Then
                     Err.Raise(1001, , Traducir("NoUpAsiento", , Tr))
                  End If
               Else
                  If Not GuardaAsienDet(NroAsi, RenASi, cCtaPro, DetAsi, 0, Math.Abs(nImpProp), Tr) Then
                     Err.Raise(1001, , Traducir("NoUpAsiento", , Tr))
                  End If
               End If
            End If
            'Else
            '
            'Nuevo 25/06/2005.
            If ImpAdl <> 0 Then
               RenASi = RenASi + 1
               If ImpAdl > 0 Then
                  If Not GuardaAsienDet(NroAsi, RenASi, cCtaAdl, DetAsi, ImpAdl, 0, Tr) Then
                     Err.Raise(1001, , Traducir("NoUpAsiento", , Tr))
                  End If
               Else
                  If Not GuardaAsienDet(NroAsi, RenASi, cCtaAdl, DetAsi, 0, Math.Abs(ImpAdl), Tr) Then
                     Err.Raise(1001, , Traducir("NoUpAsiento", , Tr))
                  End If
               End If
               '
               'Detalle asiento (Caja Adm.)
               'If tSubtotal - nImpInt - vImpAdl > 0 Then
               '   RenASi = RenASi + 1
               '   If Not GuardaAsienDet(NroAsi, RenASi, cCtaCajaAd, DetAsi, tSubtotal - nImpInt - vImpAdl, 0) Then
               '      Err.Raise 1001, , Traducir("NoUpAsiento")
               '   End If
               'ElseIf tSubtotal - nImpInt - vImpAdl < 0 Then
               '   RenASi = RenASi + 1
               '   If Not GuardaAsienDet(NroAsi, RenASi, cCtaCajaAd, DetAsi, 0, Abs(tSubtotal - nImpInt - vImpAdl)) Then
               '      Err.Raise 1001, , Traducir("NoUpAsiento")
               '   End If
               'End If
            End If
            '
            'Detalle Asiento (Intereses rendidos).
            If nImpInt > 0 Then
               RenASi = RenASi + 1
               If Not GuardaAsienDet(NroAsi, RenASi, cCtaInt, DetAsi, nImpInt, 0, Tr) Then
                  Err.Raise(1001, , Traducir("NoUpAsiento", , Tr))
               End If
            End If

            'Detalle Asiento (Comisión).
            If Val(Comision) > 0 Then
               RenASi = RenASi + 1
               If Not GuardaAsienDet(NroAsi, RenASi, cCtaCAdm, DetAsi, 0, Comision, Tr) Then
                  Err.Raise(1001, , Traducir("NoUpAsiento", , Tr))
               End If
               '
               'Detalle Asiento (Iva 1).
               If Iva1 > 0 Then
                  RenASi = RenASi + 1
                  If Not GuardaAsienDet(NroAsi, RenASi, cCtaIDF1, DetAsi, 0, Iva1, Tr) Then
                     Err.Raise(1001, , Traducir("NoUpAsiento", , Tr))
                  End If
               End If
               '
               'Detalle Asiento (Iva 2).
               If Iva2 > 0 Then
                  RenASi = RenASi + 1
                  If Not GuardaAsienDet(NroAsi, RenASi, cCtaIDF2, DetAsi, 0, Iva2, Tr) Then
                     Err.Raise(1001, , Traducir("NoUpAsiento", , Tr))
                  End If
               End If
               '
            End If

            'Detalle Asiento (Ret.Gcias.).
            If RetGan > 0 Then
               RenASi = RenASi + 1
               If Not GuardaAsienDet(NroAsi, RenASi, cCtaRGan, DetAsi, 0, RetGan, Tr) Then
                  Err.Raise(1001, , Traducir("NoUpAsiento", , Tr))
               End If
            End If
            '
            'If nImpCmpO > 0 Then
            'Detalle Asiento (Anticipos de Impuestos).
            '   RenASi = RenASi + 1
            '   If Not GuardaAsienDet(NroAsi, RenASi, cCtaPro, DetAsi, 0, nImpCmpO) Then
            '      Err.Raise 1001, , "NoUpAsiento"
            '   End If
            'End If
            '
            'If Val(tbEfectivo) + nImpCaja > 0 Then
            '   'Detalle Asiento (Caja Adm.)
            '   RenAsi = RenAsi + 1
            '   If Not GuardaAsienDet(NroAsi, RenAsi, IIf(Adelanto, cCtaCaja, cCtaCajaAd), DetAsi, 0, tbEfectivo + nImpCaja) Then
            '      Err.Raise 1001, , Traducir("NoUpAsiento")
            '   End If
            'End If
         End If
         '
         If Not Pendiente Then
            If Efectivo <> 0 Then
               cDetCaja = "Efectivo"
               If Efectivo > 0 Then
                  nDebe = 0
                  nHaber = Math.Abs(Efectivo)
               Else
                  nDebe = Math.Abs(Efectivo)
                  nHaber = 0
               End If
               '
               If Not ActCaja(prmNroCaja, cComprob, "EF", Today, DescProp, "", cDetCaja, nDebe, nHaber, , Tr) Then
                  Err.Raise(1001)
               End If
               '
               'If Val(tbEfectivo) + nImpCaja > 0 Then
               'Detalle Asiento (Caja).
               If SisContable Then
                  RenASi = RenASi + 1
                  If Not GuardaAsienDet(NroAsi, RenASi, cCtaCajaAd, DetAsi, nDebe, nHaber, Tr) Then
                     Err.Raise(1001, , Traducir("NoUpAsiento", , Tr))
                  End If
               End If
               'end if
               '
            End If
            '
            If Cheques > 0 Then
               '
               With Rs
                  .CommandText = "SELECT * FROM " & TablaCh & " WHERE Usuario = '" & Uid & "'"
                  Dr = .ExecuteReader
               End With
               '
               RsD.Connection = Cn
               If Tr.ToString <> "" Then
                  RsD.Transaction = Tr
               End If
               '
               With Dr
                  '
                  Do While .Read
                     '
                     nContCh = nContCh + 1
                     '
                     If .Item("Origen") = "C" Then
                        cDetCaja = "CH." & !DescBco & ", CTA:" & !Cuenta & ", Nº" & !Numero & ", Al:" & !Fecha
                        If Not ActCaja(prmNroCaja, cComprob, "CH" & nContCh, Today, DescProp, "", cDetCaja, 0, !Importe, , Tr) Then
                           Err.Raise(1001)
                        End If
                     End If
                     '
                     'Detalle Asiento (Banco/Ch.Cartera).
                     If SisContable Then
                        RenASi = RenASi + 1
                        If Not GuardaAsienDet(NroAsi, RenASi, IIf(!Origen = "P", !CtaCont, cCtaVCar), DetAsi, 0, !Importe, Tr) Then
                           Err.Raise(1001, , Traducir("NoUpAsiento", , Tr))
                        End If
                     End If
                     '
                     If !Origen = "P" Then
                        '
                        nTipo = CapturaDato(Cn, "TipoMovBco", "TipoMovBco", "TipoMov = 'CH'", , , , Tr)
                        cDetCaja = "CH.PR." & !DescBco & "CTA:" & !Cuenta & " Nº" & !Numero & " Al:" & !Fecha
                        '
                        'If Not ActCaja(prmNroCaja, cComprob, "CP" & nContCh, Today, DescProp, "", cDetCaja, 0, !Importe, , Tr) Then
                        'Err.Raise(1001)
                        'End If
                        '
                        If Not IsNothing(CapturaDato(Cn, "BancosMov", "NroMovBco", "Banco = " & !Banco & " AND BancoCta = '" & !Cuenta & "' AND TipoMovBco = " & nTipo & " AND NroMovBco = '" & !Numero & "'", , , , Tr)) Then
                           .Close()
                           Err.Raise(1001, "ModPol.GuardarLiqProp", "MovBcoExiste")
                        End If
                        '
                        RsD.CommandText = "INSERT INTO BancosMov( Banco, BancoCta, TipoMovBco, NroMovBco, FechaEmi, FechaAcr, Debe, Haber, Detalle, Estado, HojaBco, Usuario, FechaMod) " & _
                                          "VALUES( " & !Banco & ", " & _
                                                 "'" & !Cuenta & "', " & _
                                                       nTipo & ", " & _
                                                       !Numero & ", " & _
                                                 "'" & Format(Today, FormatFecha) & "', " & _
                                                 "'" & Format(!Fecha, FormatFecha) & "', " & _
                                                       IIf(cImput = "D", !Importe, 0) & ", " & _
                                                       IIf(cImput = "H", !Importe, 0) & ", " & _
                                                 "'" & DetAsi & "', " & _
                                                       estEMIT & ", " & _
                                                       0 & ", " & _
                                                 "'" & Uid & "', " & _
                                                 "'" & Format(Now, FormatFechaHora) & "')"
                        RsD.ExecuteNonQuery()
                        '
                        If IsNothing(CapturaDato(Cn, "ChPropios", "ChPropNro", "Banco = " & !Banco & " AND BancoCta = '" & !Cuenta & "' AND TipomovBco = " & nTipo & " AND ChPropNro = '" & !Numero & "'", , , , Tr)) Then
                           RsD.CommandText = "INSERT INTO ChPropios( Banco, BancoCta, TipoMovBco, ChPropNro, Estado, Usuario, FechaMod) " & _
                                             "VALUES(" & !Banco & ", " & _
                                                   "'" & !Cuenta & "', " & _
                                                         nTipo & ", " & _
                                                   "'" & !Numero & "', " & _
                                                         estEMIT & ", " & _
                                                   "'" & Uid & "', " & _
                                                   "'" & Format(Now, FormatFechaHora) & "')"
                        Else
                           RsD.CommandText = "UPDATE ChPropios SET " & _
                                             "  Estado = " & estEMIT & ", " & _
                                             "  Usuario = '" & Uid & "', " & _
                                             "  FechaMod = '" & Format(Now, FormatFechaHora) & "' " & _
                                             "WHERE Banco = " & !Banco & _
                                             "  AND BancoCta = '" & !Cuenta & "'" & _
                                             "  AND TipoMovBco = " & nTipo & _
                                             "  AND ChPropNro = '" & !Numero & "'"
                        End If
                        RsD.ExecuteNonQuery()
                     Else
                        If IsNothing(CapturaDato(Cn, "ChCartera", "ChCartNro", "Estado = 0 AND Banco = " & !Banco & " AND BancoCta = '" & !Cuenta & "' AND ChCartNro = '" & !Numero & "'", , , , Tr)) Then
                           Err.Raise(1001, , Traducir("ChNoEnc", , Tr))
                        Else
                           RsD.CommandText = "UPDATE ChCartera SET " & _
                                             "  Estado = 2, " & _
                                             "  Usuario = '" & Uid & "', " & _
                                             "  FechaMod = '" & Format(Now, FormatFechaHora) & "' " & _
                                             "WHERE Banco = " & !Banco & _
                                             "  AND BancoCta = '" & !Cuenta & "'" & _
                                             "  AND ChCartNro = '" & !Numero & "'"
                           RsD.ExecuteNonQuery()
                        End If
                     End If
                     '
                     RsD.CommandText = "INSERT INTO ChLiqPro( LiqPro, Origen, Banco, Cuenta, Numero, Titular, Fecha, Importe, Usuario, FechaMod) " & _
                                       "VALUES( " & NroLiq & ", " & _
                                              "'" & !Origen & "', " & _
                                                    !Banco & ", " & _
                                              "'" & !Cuenta & "', " & _
                                              "'" & !Numero & "', " & _
                                              "'" & !Titular & "', " & _
                                              "'" & Format(!Fecha, FormatFecha) & "', " & _
                                                    !Importe & ", " & _
                                              "'" & Uid & "', " & _
                                              "'" & Format(Now, FormatFechaHora) & "')"
                     RsD.ExecuteNonQuery()
                     '
                  Loop
                  .Close()
               End With
            End If
            '
         End If
         '
         If SisContable Then
            If nImpCaja > 0 Then
               'Asiento Traspaso de Caja.
               NroAsi = GuardaAsiento(cComprob & "P", Today, DetAsi, Tr)
               If NroAsi = 0 Then
                  Err.Raise(1001, , Traducir("NoUpAsiento", , Tr))
               End If
               '
               'Detalle Asiento (Caja).
               RenASi = 1
               If Not GuardaAsienDet(NroAsi, RenASi, cCtaCaja, DetAsi, nImpCaja, 0, Tr) Then
                  Err.Raise(1001, , Traducir("NoUpAsiento", , Tr))
               End If
               '
               'Detalle Asiento (Caja Adm).
               RenASi = RenASi + 1
               If Not GuardaAsienDet(NroAsi, RenASi, cCtaCajaAd, DetAsi, 0, nImpCaja, Tr) Then
                  Err.Raise(1001, , Traducir("NoUpAsiento", , Tr))
               End If
               '
            End If
         End If
         '
         If Comision > 0 Then
            With Rs
               .CommandText = "INSERT INTO Ventas( Tipo, Sucursal, Numero, Comprob, Fecha, Inquilino, Popietario, Nombre, TipoIva, Cuit, Gravado, NoGravado, Exento, Iva1, Iva2, Total, Detalle, LiqPropiet, Estado, Usuario, FechaMod) " & _
                              "VALUES('" & Letra & "', " & _
                                           prmSucursal & ", " & _
                                           Factura & ", " & _
                                     "'" & "FC." & "', " & _
                                     "'" & Format(Today, FormatFecha) & "', " & _
                                           0 & ", " & _
                                           Propietario & ", " & _
                                     "'" & DescProp & "', " & _
                                     "'" & vTipoIva & "', " & _
                                     "'" & cCuitProp & "', " & _
                                           Comision & ", " & _
                                           0 & ", " & _
                                           0 & ", " & _
                                           Iva1 & ", " & _
                                           Iva2 & ", " & _
                                           Comision + Iva1 + Iva2 & ", " & _
                                     "'" & "CORRESPONDIENTE A LIQUIDACION N° " & NroLiq & "', " & _
                                           NroLiq & ", " & _
                                           0 & ", " & _
                                     "'" & Uid & "', " & _
                                     "'" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
               '
               .CommandText = "INSERT INTO VentasDet( Tipo, Sucursal, Numero, Renglon, Concepto, Detalle, Cantidad, Precio, Descuento, Usuario, FechaMod) " & _
                              "VALUES('" & Letra & "', " & _
                                           prmSucursal & ", " & _
                                           Factura & ", " & _
                                           1 & ", " & _
                                     "'" & cfgCodigoCAd & "', " & _
                                     "'" & cDescCAdm & "', " & _
                                           1 & ", " & _
                                           Comision & ", " & _
                                           0 & ", " & _
                                     "'" & Uid & "', " & _
                                     "'" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
            End With
         End If
         '
         If ImporteTr > 0 Then
            With Rs
               .CommandText = "INSERT INTO LiqPropTR( Banco0, Cuenta0, Banco1, Cuenta1, Titular1, FechaTR, NumeroTR, ImporteTR, GastosImp, GastosSF, GastosIva, ImporteNeto, Usuario, FechaMod) " & _
                              "SELECT Banco0, Cuenta0, Banco1, Cuenta1, Titular, FechaTR, NumeroTR, ImporteTR, GastosImp, GastosSF, GastosIva, ImporteNeto, '" & Uid & "', '" & Format(Now, FormatFechaHora) & "' " & _
                              "FROM " & TablaTr
               .ExecuteNonQuery()
            End With
            '
            LiqPropTrID = CapturaDato(Cn, "LiqPropTR", "MAX(LiqPropTrID)", "", , , , Tr)
            nBanco = CapturaDato(Cn, "LiqPropTR", "Banco0", "LiqpropTrID = " & LiqPropTrID, , , , Tr)
            cCuenta = CapturaDato(Cn, "LiqPropTR", "Cuenta0", "LiqPropTrID = " & LiqPropTrID, , , , Tr)
            cNumero = CapturaDato(Cn, "LiqPropTR", "NumeroTR", "LiqPropTrID = " & LiqPropTrID, , , , Tr)
            nTipo = CapturaDato(Cn, "TipoMovBco", "TipoMovBco", "TipoMov = 'TR'", , , , Tr)
            '
            If nTipo = 0 Then
               Err.Raise(1001, , "Tipo de Mov. Transferencia no Definida")
            End If
            '
            With Rs
               .CommandText = "UPDATE LiqPropiet SET LiqPropTrID = " & LiqPropTrID & " " & _
                              "WHERE Numero = " & NroLiq
               .ExecuteNonQuery()
               '
               cCtaBanco = CapturaDato(Cn, "BancosCtas", "CtaCont", "Banco = " & nBanco & " AND BancoCta = '" & cCuenta & "'", , , , Tr)
               '
               .CommandText = "INSERT INTO BancosMov( Banco, BancoCta, TipoMovBco, NroMovBco, FechaEmi, FechaAcr, Debe, Haber, Estado, HojaBco, Detalle, Caja, Usuario, FechaMod) " & _
                              "VALUES(" & nBanco & ", " & _
                                    "'" & cCuenta & "', " & _
                                          nTipo & ", " & _
                                    "'" & cNumero & "', " & _
                                    "'" & Format(Today, FormatFecha) & "', " & _
                                    "'" & Format(Today, FormatFecha) & "', " & _
                                          0 & ", " & _
                                          ImporteTr & ", " & _
                                          0 & ", " & _
                                          0 & ", " & _
                                    "'" & "Transf. Liq. Prop. " & DescProp & "', " & _
                                          prmNroCaja & ", " & _
                                    "'" & Uid & "', " & _
                                    "'" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
               '
               If GastosBanc > 0 Then
                  .CommandText = "INSERT INTO BancosMov( Banco, BancoCta, TipoMovBco, NroMovBco, FechaEmi, FechaAcr, Debe, Haber, Estado, HojaBco, Detalle, Caja, Usuario, FechaMod) " & _
                                 "VALUES(" & nBanco & ", " & _
                                       "'" & cCuenta & "', " & _
                                             nTipo & ", " & _
                                       "'" & cNumero & "', " & _
                                       "'" & Format(Today, FormatFecha) & "', " & _
                                       "'" & Format(Today, FormatFecha) & "', " & _
                                             0 & ", " & _
                                             GastosBanc & ", " & _
                                             0 & ", " & _
                                             0 & ", " & _
                                       "'" & "Transf. Liq. Prop. " & DescProp & "', " & _
                                             prmNroCaja & ", " & _
                                       "'" & Uid & "', " & _
                                       "'" & Format(Now, FormatFechaHora) & "')"
                  .ExecuteNonQuery()
               End If
               '
            End With
         End If
         '
         GuardarAudit(IIf(ConfPendientes, "Confirma", "Alta") & " liquidación " & IIf(Adelanto, "Adelanto ", "") & "Propietario" & IIf(cNroLiq = "", "", " ( " & cNroLiq & ")"), DescProp & " - Nº " & NroLiq & " - Período " & Periodo, "GuardarLiqProp", "", Tr)
         '
         If CommitTr Then
            Tr.commit()
         End If
         '
         Return NroLiq
         '
      Catch ex As System.Exception
         If CommitTr Then
            Tr.rollback()
         End If
         Dim st As New StackTrace(True)
         MensageError(st, "modPol.GuardarLiqProp", Err.Description)
         Return 0
      End Try
      '
   End Function
   '
   Function CaptNroLiqProp(Optional ByVal Tr As Object = "") As Long
      Dim Numero As Long
      BuscarCfg(cfgNroLiqP, "cfgNroLiqP", Tr)
      Numero = Val(cfgNroLiqP) + 1
      Do While Not IsNothing(CapturaDato(Cn, "LiqPropiet", "Numero", "Numero = " & Numero, , , , Tr))
         Numero = Numero + 1
      Loop
      CaptNroLiqProp = Numero
   End Function
   '
   Function CaptNroFactura(ByVal Tipo As String, ByVal Sucursal As Integer, Optional ByVal Tr As Object = "") As Long
      Dim Numero As Long
      If Tipo = "A" Then
         BuscarCfg(cfgNroFactA, "cfgNroFactA", Tr)
         Numero = Val(cfgNroFactA) + 1
      Else
         BuscarCfg(cfgNroFactB, "cfgNroFactB", Tr)
         Numero = Val(cfgNroFactB) + 1
      End If
      Do While Not IsNothing(CapturaDato(Cn, "Ventas", "Numero", "Tipo='" & Tipo & "' AND Sucursal = " & Sucursal & " AND Numero = " & Numero, , , , Tr))
         Numero = Numero + 1
      Loop
      Return Numero
   End Function
   '
   Function CaptNroRetGan(Optional ByVal Tr As Object = "") As Long
      Dim Numero As Long
      BuscarCfg(cfgNroRetG, "cfgNroRetG", Tr)
      Numero = Val(cfgNroRetG) + 1
      Do While Not IsNothing(CapturaDato(Cn, "RetGcias", "Numero", "Numero = " & Numero, , , , Tr))
         Numero = Numero + 1
      Loop
      Return Numero
   End Function
   '
   Sub SistNoReg(ByVal Msg As Boolean)
      If Msg Then
         MensajeTrad("VersEvalua")
      End If
      TrialVers = True
      TrialMaxReg = 10
      cfgNomEmp = Traducir("DemoInmo")
   End Sub
   '
   Sub ArmaCbPropiedad(ByRef Combo As ComboBox, Optional ByVal Propietario As Int32 = 0, Optional ByVal Primero As String = "", Optional ByVal Inquilino As Int32 = 0, Optional ByVal SoloActivas As Boolean = False)
      '
      Dim Rs As New OleDb.OleDbCommand
      '
      Dim Tabla, ColDesc, ColOpc As String
      Dim Filtro As String = ""
      '
      Tabla = "Propiedades P"
      ColDesc = "P.Domicilio"
      ColOpc = ""
      '
      If Propietario <> 0 Then
         Filtro = "P.Propietario = " & Propietario & " "
      End If
      '
      If Inquilino <> 0 Then
         Filtro = IIf(Filtro = "", "", Filtro & " AND ") & " P.Inquilino = " & Inquilino & " "
      Else
         Tabla = Tabla & " LEFT JOIN Inquilinos I ON P.Inquilino = I.Codigo "
         ColOpc = " + '   (' + ISNULL(I.Nombre,'') + ')'"
      End If
      '
      If SoloActivas Then
         Tabla = Tabla & ", Contratos C"
         Filtro = IIf(Filtro = "", "", Filtro & " AND ") & " P.Propietario = C.Propietario AND P.Codigo = C.Propiedad AND C.Estado = 0"
      End If
      '
      ArmaComboItem(Combo, Tabla, "P.Codigo", ColDesc, "Domicilio", Primero, Filtro,, ColOpc)
      '
   End Sub
   '
   Sub ArmaCbPropInq(ByVal cbDomicilio As ComboBox, ByVal Inquilino As String)
      '
      ArmaComboItem(cbDomicilio, "Contratos C, Propiedades P, FactInq F", "P.Codigo", "P.Domicilio", "Domicilio", "(Seleccionar)", _
                                 "C.Inquilino = " & Inquilino & _
                                 "  AND C.Estado <> 2 " & _
                                 "  AND C.Propiedad = P.Codigo " & _
                                 "  AND F.Inquilino = " & Inquilino & " " & _
                                 "  AND C.Propiedad = F.Propiedad " & _
                                 "  AND (F.Liquidado = 0 OR F.Saldo <> 0)")
      '
      If cbDomicilio.Items.Count = 2 Then
         cbDomicilio.SelectedIndex = 1
      End If
      '
   End Sub
   '
   Function AnulaLiqProp(ByVal Numero As Long, Optional ByVal Tr As Object = "") As Boolean
      '
      Dim Rs As New OleDb.OleDbCommand
      Dim Dr As OleDb.OleDbDataReader
      Dim Rs2 As New OleDb.OleDbCommand
      '
      Dim cTip As String = ""
      Dim nSuc As Integer = 0
      Dim nNro As Long = 0
      Dim cComprob As String
      '
      Dim nTipo As Integer
      Dim nBanco As Integer
      Dim cCtaBco As String
      Dim cNumero As String
      Dim cNroCheque As String
      Dim EstCh As Byte
      '
      Dim LiqPropTrID As Long
      Dim Propietario As Long
      Dim NombreProp As String = ""
      Dim Periodo As String = ""
      '
      Const estAnulado = 2
      Const cmpInt = "LP"
      '
      Try
         '
         Rs.Connection = Cn
         If Tr.ToString <> "" Then
            Rs.Transaction = Tr
         End If
         '
         Rs2.Connection = Cn
         If Tr.ToString <> "" Then
            Rs2.Transaction = Tr
         End If
         '
         With Rs
            .CommandText = "SELECT * FROM LiqPropiet WHERE Numero = " & Numero
            Dr = .ExecuteReader
         End With
         '
         With Dr
            If .Read Then
               cTip = !Tipo & ""
               nSuc = !Sucursal
               nNro = !Factura
               Periodo = !Periodo
               LiqPropTrID = Val(!LiqPropTrID & "")
               Propietario = !Propietario
               NombreProp = CapturaDato(Cn, "Propietarios", "Nombre", "Codigo = " & Propietario, , , , Tr)
            Else
               .Close()
               Err.Raise(1001, "ModPol.AnulaLiqPro")
            End If
            .Close()
         End With
         '
         With Rs
            .CommandText = "DELETE FROM LiqPropietDet WHERE Numero = " & Numero
            .ExecuteNonQuery()
            '
            .CommandText = "UPDATE LiqPropiet SET " &
                           " Alquiler = 0, " &
                           " Debe = 0, " &
                           " Haber = 0, " &
                           " Comision = 0, " &
                           " Iva1 = 0, " &
                           " Iva2 = 0, " &
                           " RetGCias = 0, " &
                           " Total = 0, " &
                           " Efectivo = 0, " &
                           " Cheque = 0, " &
                           " ImporteTr = 0, " &
                           " NroCheque = 0, " &
                           " Banco = 0, " &
                           " CtaBco = '', " &
                           " Detalle = '" & Traducir("Anulada", , Tr) & "', " &
                           " Estado = " & estAnulado & ", " &
                           " Caja = 0, " &
                           " AlquilerRet = 0, " &
                           " Usuario = '" & Uid & "', " &
                           " FechaMod = '" & Format(Now, FormatFechaHora) & "' " &
                           "WHERE Numero = " & Numero
            .ExecuteNonQuery()
            '
            .CommandText = "UPDATE LiqInqCab SET " &
                           " Liquidado = 0, " &
                           " LiqPropiet = 0, " &
                           " Usuario = '" & Uid & "', " &
                           " FechaMod = '" & Format(Now, FormatFechaHora) & "' " &
                           "WHERE LiqPropiet = " & Numero
            .ExecuteNonQuery()
            '
            .CommandText = "UPDATE LiqInqCob SET " &
                           " LiqPropiet = 0, " &
                           " LicUid = '" & Uid & "', " &
                           " LicFecMod = '" & Format(Now, FormatFechaHora) & "' " &
                           "WHERE LiqPropiet = " & Numero
            .ExecuteNonQuery()
            '
            .CommandText = "UPDATE LiqInqCobDet SET " &
                           " LiqPropiet = 0, " &
                           " LcdUid = '" & Uid & "', " &
                           " LcdFecMod = '" & Format(Now, FormatFechaHora) & "' " &
                           "WHERE LiqPropiet = " & Numero
            .ExecuteNonQuery()
            '
            .CommandText = "UPDATE CompraOtr SET " &
                           " Liquidado = 0, " &
                           " LiqPropiet = 0, " &
                           " Usuario = '" & Uid & "', " &
                           " FechaMod = '" & Format(Now, FormatFechaHora) & "' " &
                           "WHERE Propietario = " & Propietario & " AND LiqPropiet = " & Numero

            .ExecuteNonQuery()
            '
            .CommandText = "UPDATE CobrosOtr SET " &
                           " Liquidado = 0, " &
                           " LiqPropiet = 0, " &
                           " Usuario = '" & Uid & "', " &
                           " FechaMod = '" & Format(Now, FormatFechaHora) & "' " &
                           "WHERE Propietario = " & Propietario & " AND LiqPropiet = " & Numero
            .ExecuteNonQuery()
            '
            .CommandText = "UPDATE LiqInqDet SET " &
                           " LiqPropiet = 0, " &
                           " Usuario = '" & Uid & "', " &
                           " FechaMod = '" & Format(Now, FormatFechaHora) & "' " &
                           "WHERE LiqPropiet = " & Numero & " AND Origen IN( 0, 3)"
            .ExecuteNonQuery()
            '
            .CommandText = "DELETE FROM LiqInqDet WHERE LiqPropiet = " & Numero & " AND Origen NOT IN( 0, 3)"
            .ExecuteNonQuery()
            '
            .CommandText = "DELETE FROM LiqInqDet WHERE Tipo = 'L' AND Sucursal = " & nSuc & " AND Numero = " & Numero
            .ExecuteNonQuery()
            '
            .CommandText = "UPDATE RetGcias SET " &
                           " Acumulado = 0, " &
                           " Neto = 0, " &
                           " Retenido = 0, " &
                           " DDJJAño = 0, " &
                           " Estado = " & estAnulado & ", " &
                           " Usuario = '" & Uid & "', " &
                           " FechaMod = '" & Format(Now, FormatFechaHora) & "' " &
                           "WHERE LiqPropiet = " & Numero
            .ExecuteNonQuery()
            '
            .CommandText = "UPDATE FactInq SET " &
                           " TipoNroRbo = '', " &
                           " Liquidado = 0, " &
                           " Saldo = Importe, " &
                           " Usuario = '" & Uid & "', " &
                           " FechaMod = '" & Format(Now, FormatFechaHora) & "' " &
                           "WHERE TipoNroRbo = 'LP." & Numero & "'"
            .ExecuteNonQuery()
            '
         End With
         '
         cComprob = cmpInt & "-" & Numero
         '
         If Not BajaCaja(cComprob, , Tr) Then
            Err.Raise(1001, "ModPol.AnulaLiqProp", Traducir("NoBajaCaja", , Tr))
         End If
         '
         nTipo = CapturaDato(Cn, "TipoMovBco", "TipoMovBco", "TipoMov = 'CH'", , , , Tr)
         '
         With Rs
            .CommandText = "SELECT * FROM ChLiqPro WHERE LiqPro = " & Numero
            Dr = .ExecuteReader
         End With
         '
         With Dr
            Do While .Read
               '
               nBanco = !Banco
               cCtaBco = !Cuenta & ""
               cNroCheque = !Numero
               '
               If !Origen = "P" Then
                  With Rs2
                     '
                     EstCh = Val(CapturaDato(Cn, "ChPropios", "Estado", "Banco = " & nBanco & " AND BancoCta = '" & cCtaBco & "' AND ChPropNro = '" & cNroCheque & "'", , , , Tr))
                     '
                     If EstCh = 2 Then
                        Err.Raise(1001, , Traducir("MovBcoConc", , Tr))
                     End If
                     '
                     .CommandText = "DELETE FROM BancosMov WHERE Banco = " & nBanco & " AND BancoCta = '" & cCtaBco & "' AND TipoMovBco = " & nTipo & " AND NroMovBco = '" & cNroCheque & "' AND Estado <> 2"
                     .ExecuteNonQuery()
                     '
                     .CommandText = "UPDATE ChPropios SET " & _
                                    " Estado = 0, " & _
                                    " Usuario = '" & Uid & "', " & _
                                    " FechaMod = '" & Format(Now, FormatFechaHora) & "' " & _
                                    "WHERE Banco = " & nBanco & " AND BancoCta = '" & cCtaBco & "' AND TipoMovBco = " & nTipo & " AND ChPropNro = '" & cNroCheque & "'"
                     .ExecuteNonQuery()
                  End With
               Else
                  '
                  With Rs2
                     .CommandText = "UPDATE ChCartera SET " & _
                                    " Estado = 0, " & _
                                    " Usuario = '" & Uid & "', " & _
                                    " FechaMod = '" & Format(Now, FormatFechaHora) & "' " & _
                                    "WHERE Banco = " & nBanco & " AND BancoCta = '" & cCtaBco & "' AND ChCartNro = '" & cNroCheque & "'"
                     .ExecuteNonQuery()
                  End With
                  '
               End If
            Loop
            .Close()
         End With
         '
         If Not AnulaFactura(cTip, nSuc, nNro, Tr) Then
            Err.Raise(1001, "ModPol.AnulaLiqProp", "NoDelFactura")
         End If
         '
         If Not BorraAsiento(cComprob, Tr) Then
            Err.Raise(1001, , Traducir("NoDelAsiento"))
         End If
         '
         If Not BorraAsiento(cComprob & "P", Tr) Then
            Err.Raise(1001, , Traducir("NoDelAsiento"))
         End If
         '
         If LiqPropTrID <> 0 Then
            nBanco = CapturaDato(Cn, "LiqPropTR", "Banco0", "LiqpropTrID = " & LiqPropTrID, , , , Tr)
            cCtaBco = CapturaDato(Cn, "LiqPropTR", "Cuenta0", "LiqPropTrID = " & LiqPropTrID, , , , Tr)
            cNumero = CapturaDato(Cn, "LiqPropTR", "NumeroTR", "LiqPropTrID = " & LiqPropTrID, , , , Tr)
            nTipo = CapturaDato(Cn, "TipoMovBco", "TipoMovBco", "TipoMov = 'TR'", , , , Tr)
            If nTipo = 0 Then
               Err.Raise(1001, , "Tipo de Mov. Transferencia no Definida")
            End If
            '
            With Rs
               .CommandText = "DELETE FROM LiqPropTR WHERE LiqpropTrID = " & LiqPropTrID
               .ExecuteNonQuery()
               .CommandText = "DELETE FROM BancosMov WHERE Banco = " & nBanco & " AND BancoCta = '" & cCtaBco & "' AND TipoMovBco = " & nTipo & " AND NroMovBco = '" & cNumero & "'"
               .ExecuteNonQuery()
            End With
         End If
         '
         With Rs
            .CommandText = "UPDATE LiqPropiet SET Estado = 3 WHERE Numero IN( SELECT LiqPropiet FROM LiqPropietAg WHERE Numero = " & Numero & ")"
            .ExecuteNonQuery()
            .CommandText = "DELETE FROM LiqPropietAg WHERE Numero = " & Numero
            .ExecuteNonQuery()
         End With
         '
         GuardarAudit("Anula liquidación propietario", NombreProp & " - Nº " & Numero & " - Período " & Periodo, "Procesos", "AnulaLiqPro", Tr)
         '
         Return True
         '
      Catch ex As System.Exception
         Dim st As New StackTrace(True)
         MensageError(st, "ModPol.AnulaLiqProp", Err.Description)
         Return False
         '
      End Try
      '
   End Function
   '
   Function AltaFactura(ByVal Letra As String, ByVal Sucursal As Int16, ByVal Numero As Int32, ByVal Comprob As String, ByVal Fecha As Date, _
                        ByVal Inquilino As Int32, ByVal Propietario As Int32, ByVal Nombre As String, ByVal TipoIva As String, ByVal Cuit As String, _
                        ByVal Gravado As Double, ByVal NoGravado As Double, ByVal Exento As Double, ByVal Iva1 As Double, ByVal Iva2 As Double, _
                        ByVal Total As Double, ByVal Detalle As String, Optional ByVal LiqPropiet As Int32 = 0, _
                        Optional ByVal Estado As Byte = 0, Optional ByVal Tr As Object = "") As Boolean
      '
      Dim Rs As New OleDb.OleDbCommand
      '
      With Rs
         Try
            .Connection = Cn
            If Tr.ToString <> "" Then
               .Transaction = Tr
            End If
            .CommandText = "INSERT INTO Ventas( Tipo, Sucursal, Numero, Comprob, Fecha, Inquilino, Popietario, Nombre, TipoIva, Cuit, Gravado, NoGravado, Exento, Iva1, Iva2, Total, Detalle, LiqPropiet, Estado, Usuario, FechaMod) " & _
                           "VALUES('" & Letra & "', " & _
                                        Sucursal & ", " & _
                                        Numero & ", " & _
                                  "'" & Comprob & "', " & _
                                  "'" & Format(Today, FormatFecha) & "', " & _
                                        Inquilino & ", " & _
                                        Propietario & ", " & _
                                  "'" & Nombre & "', " & _
                                  "'" & TipoIva & "', " & _
                                  "'" & Cuit & "', " & _
                                        Gravado & ", " & _
                                        NoGravado & ", " & _
                                        Exento & ", " & _
                                        Iva1 & ", " & _
                                        Iva2 & ", " & _
                                        Gravado + NoGravado + Exento + Iva1 + Iva2 & ", " & _
                                  "'" & Detalle & "', " & _
                                        LiqPropiet & ", " & _
                                        Estado & ", " & _
                                  "'" & Uid & "', " & _
                                  "'" & Format(Now, FormatFechaHora) & "')"
            .ExecuteNonQuery()
         Catch
            Return False
         End Try
      End With
      '
      Return True
      '
   End Function
   '
   Function AltaRenFact(ByVal Letra As String, ByVal Sucursal As Int16, ByVal Numero As Int32, ByVal Renglon As Byte, ByVal Concepto As String,
                        ByVal Detalle As String, ByVal Cantidad As Double, ByVal Precio As Double, ByVal Descuento As Single, Optional Tr As Object = "") As Boolean
      '
      Dim Rs As New OleDb.OleDbCommand
      '
      With Rs
         .Connection = Cn
         If Tr.ToString <> "" Then
            .Transaction = Tr
         End If
         .CommandText = "INSERT INTO VentasDet( Tipo, Sucursal, Numero, Renglon, Concepto, Detalle, Cantidad, Precio, Descuento, Usuario, FechaMod) " &
                        "VALUES('" & Letra & "', " &
                                     prmSucursal & ", " &
                                     Numero & ", " &
                                     1 & ", " &
                               "'" & Concepto & "', " &
                               "'" & Detalle & "', " &
                                     1 & ", " &
                                     Precio & ", " &
                                     Descuento & ", " &
                               "'" & Uid & "', " &
                               "'" & Format(Now, FormatFechaHora) & "')"
         .ExecuteNonQuery()
      End With
      '
      Return True
      '
   End Function
   '
   Function AnulaFactura(ByVal Tipo As String, ByVal Sucursal As Integer, ByVal Numero As Long, Optional ByVal Tr As Object = "", Optional Borrar As Boolean = False) As Boolean
      '
      Dim Rs As New OleDb.OleDbCommand
      '
      Dim finTr As Boolean = False
      Dim CodAsi, CodAs2, Nombre, Comprob As String
      '
      CodAsi = "FC-" & Tipo & "-" & Sucursal & "-" & Numero
      CodAs2 = "FC-" & Tipo & "-" & Format(Sucursal, "0000") & "-" & Format(Numero, "00000000")
      '
      Try
         '
         With Rs
            .Connection = Cn
            If Tr.ToString = "" Then
               Tr = Cn.BeginTransaction
               finTr = True
            End If
            .Transaction = Tr
            '
            Nombre = CapturaDato(Cn, "Ventas", "Nombre", "Tipo = '" & Tipo & "' AND Sucursal = " & Sucursal & " AND Numero = " & Numero,,,, Tr)
            Comprob = CapturaDato(Cn, "Ventas", "Comprob", "Tipo = '" & Tipo & "' AND Sucursal = " & Sucursal & " AND Numero = " & Numero,,,, Tr)
            '
            If Borrar Then
               .CommandText = "DELETE FROM Ventas WHERE Tipo = '" & Tipo & "' AND Sucursal = " & Sucursal & " AND Numero = " & Numero
            Else
               .CommandText = "UPDATE Ventas SET " &
                           " Inquilino = '', " &
                           " Popietario = '', " &
                           " Nombre = '" & Traducir("Anulada", , Tr) & "', " &
                           " Cuit = '', " &
                           " Gravado = 0, " &
                           " NoGravado = 0, " &
                           " Exento = 0, " &
                           " Iva1 = 0, " &
                           " Iva2 = 0, " &
                           " Total = 0, " &
                           " Detalle = '" & Traducir("Anulada", , Tr) & "', " &
                           " Estado = 2, " &
                           " Usuario = '" & Uid & "'," &
                           " FechaMod = '" & Format(Now, FormatFechaHora) & "' " &
                           "WHERE Tipo = '" & Tipo & "'" &
                           "  AND Sucursal = " & Sucursal &
                           "  AND Numero = " & Numero
            End If
            .ExecuteNonQuery()
            '
            .CommandText = "DELETE FROM VentasDet " &
                           "WHERE Tipo = '" & Tipo & "'" &
                           "  AND Sucursal = " & Sucursal &
                           "  AND Numero = " & Numero
            .ExecuteNonQuery()
         End With
         '
         If Not BorraAsiento(CodAsi, Tr) Then
            If Not BorraAsiento(CodAs2, Tr) Then
               Err.Raise(1001, "ModPol.AnulaFactura", Traducir("NoBorraAsiento", , Tr))
            End If
         End If
         '
         GuardarAudit(IIf(Borrar, "Elimina", "Anula") & " Venta", Comprob & ": " & Tipo & "-" & Sucursal & "-" & Numero & ", " & Nombre, "Ventas", "ModPol.AnulaFactura", Tr)
         '
         If finTr Then
            Tr.commit()
         End If
         '
         Return True
         '
      Catch ex As SystemException
         If finTr Then
            Tr.rollback()
         End If
         Dim st As New StackTrace(True)
         MensageError(st, "ModPol.AnulaFactura", Err.Description)
         Return False
      End Try
      '
   End Function
   '
   Function AnulFinCtto(ByVal Numero As Long, ByVal Estado As Integer, ByVal FechaFin As Date, Optional Tr As Object = "") As Boolean
      '
      '*** Estado: 1=Finalizar, 2=Anular.
      '
      Dim Rs As New OleDb.OleDbCommand
      Dim Dr As OleDb.OleDbDataReader
      '
      Dim CodAsi As String
      Dim cTip As String
      Dim nSuc As Integer
      Dim nNro As Long
      Dim nMeses As Integer
      '
      Dim NomProp As String
      Dim NomInq As String
      Dim Propietario, Propiedad, Inquilino As Long
      Dim PerDesde As String = ""
      Dim PerHasta As String = ""
      Dim cmpInt As String
      Dim nFilas As Integer
      '
      cmpInt = "CT"
      '
      Try
         '
         If Tr.ToString <> "" Then
            'If IniTrans Then
            'Tr = Cn.BeginTransaction
            'End If
         End If
         '
         With Rs
            .Connection = Cn
            If Tr.ToString <> "" Then
               .Transaction = Tr
            End If
            .CommandText = "SELECT * FROM Contratos WHERE Numero = " & Numero
            Dr = .ExecuteReader
         End With
         With Dr
            If .Read Then
               '
               cTip = !Tipo & ""
               nSuc = !Sucursal
               nNro = !NroFact
               nMeses = !Meses
               Propietario = !Propietario
               Propiedad = !Propiedad
               Inquilino = !Inquilino
               PerDesde = Right(!PerDesde, 2) & "/" & Left(!PerDesde, 4)
               PerHasta = Right(!PerHasta, 2) & "/" & Left(!PerHasta, 4)
               '
               .Close()
            Else
               .Close()
               Err.Raise(1001, , Traducir("CttoNoEnc", , Tr))
            End If
         End With
         '
         With Rs
            .CommandText = "UPDATE Contratos SET " & _
                           " Texto = '" & IIf(Estado = 2, "Anulado", "Finalizado al " & FechaFin) & ", el: " & Today & ".-', " & _
                           " Convenio = '', " & _
                           " Estado = " & Estado & ", " & _
                           " CtoFecFin = '" & Format(FechaFin, FormatFecha) & "', " & _
                           " Usuario = '" & Uid & "', " & _
                           " FechaMod = '" & Format(Now, FormatFechaHora) & "' " & _
                           "WHERE Numero = " & Numero
            .ExecuteNonQuery()
         End With
         '
         NomProp = CapturaDato(Cn, "Propietarios", "Nombre", "Codigo = " & Propietario, , , , Tr)
         NomInq = CapturaDato(Cn, "Inquilinos", "Nombre", "Codigo = " & Inquilino, , , , Tr)
         '
         With Rs
            .CommandText = "UPDATE Propiedades SET " & _
                           " Inquilino = NULL, " & _
                           " Usuario = '" & Uid & "', " & _
                           " FechaMod = '" & Format(Now, FormatFechaHora) & "' " & _
                           "WHERE Codigo = " & Propiedad
            .ExecuteNonQuery()
         End With
         '
         If SisContable Then
            With Rs
               .CommandText = "SELECT * FROM FactInq WHERE Propiedad = " & Propiedad & " AND Inquilino = " & Inquilino & " AND Fecha >= " & strFEC & Format(FechaFin, FormatFecha) & strFEC & " AND Liquidado = 0"
               Dr = .ExecuteReader
            End With
            '
            With Dr
               Do While .Read
                  '
                  CodAsi = cmpInt & Numero & "/" & Format(!MesPago, "00")
                  '
                  If Not BorraAsiento(CodAsi, Tr) Then
                     Err.Raise(1001, , Traducir("NoDelAsiento", , Tr))
                  End If
                  '
                  If Not BorraAsiento(CodAsi & "P", Tr) Then
                     Err.Raise(1001, , Traducir("NoDelAsiento", , Tr))
                  End If
                  '
               Loop
               .Close()
            End With
         End If
         '
         With Rs
            .CommandText = "DELETE FROM FactInq WHERE Propiedad = " & Propiedad & " AND Inquilino = " & Inquilino & " AND Fecha >= " & strFEC & Format(FechaFin, FormatFecha) & strFEC & " AND Liquidado = 0"
            .ExecuteNonQuery()
            '
            .CommandText = "DELETE FROM CompraOtrDet WHERE EXISTS( " & _
                           " SELECT Comprob FROM CompraOtr WHERE Propiedad = " & Propiedad & _
                           "  AND Comprob LIKE 'CP-" & Propiedad & "%' " & _
                           "  AND Fecha >= " & strFEC & Format(FechaFin, FormatFecha) & strFEC & _
                           "  AND EXISTS( SELECT Concepto FROM PropiedConc WHERE Propiedad = " & Propiedad & " AND concepto = right(CompraOtr.Comprob,3) AND Apropiet = 0) " & _
                           "  AND Pagado = 0 AND Liquidado = 0 " & _
                           "  AND Comprob = CompraOtrDet.Comprob " & _
                           "  AND Sucursal = CompraOtrDet.Sucursal " & _
                           "  AND Numero = CompraOtrDet.Numero)"
            .ExecuteNonQuery()
            '
            .CommandText = "DELETE FROM CompraOtr WHERE Propiedad = " & Propiedad & _
                           "  AND Comprob LIKE 'CP-" & Propiedad & "%' " & _
                           "  AND Fecha >= " & strFEC & Format(FechaFin, FormatFecha) & strFEC & _
                           "  AND EXISTS( SELECT Concepto FROM PropiedConc WHERE Propiedad = " & Propiedad & " AND concepto = right(CompraOtr.Comprob,3) AND Apropiet = 0) " & _
                           "  AND Pagado = 0 AND Liquidado = 0"
            .ExecuteNonQuery()
            '
            .CommandText = "DELETE FROM PropiedConc " & _
                           "WHERE Propiedad = " & Propiedad & _
                           "  AND Concepto IN('" & cfgCodigoAlq & "', '" & cfgCodigoIva & "')" & _
                           "  AND Automatico <> 0 " & _
                           "  AND FecDesde >= " & strFEC & Format(CDate("01/" & PerDesde), FormatFecha) & strFEC & _
                           "  AND FecDesde <= " & strFEC & Format(UltDiaMes("28/" & PerHasta), FormatFecha) & strFEC
            .ExecuteNonQuery()
            '
         End With
         '
         If Estado = 2 Then
            With Rs
               .CommandText = "DELETE FROM CompraOtr WHERE Comprob = '" & cmpInt & "' AND Sucursal = " & prmSucursal & " AND Numero = " & Numero & " AND Pagado = 0"
               nFilas = .ExecuteNonQuery()
               If nFilas > 0 Then
                  .CommandText = "DELETE FROM CompraOtrDet WHERE Comprob = '" & cmpInt & "' AND Sucursal = " & prmSucursal & " AND Numero = " & Numero
                  .ExecuteNonQuery()
               End If
            End With
            '
            If Not AnulaFactura(cTip, nSuc, nNro, Tr) Then
               Err.Raise(1001, , "NoDelFactura")
            End If
            '
            BajaCaja("FC" & "-" & cTip & "-" & nSuc & "-" & nNro, , Tr)
            '
            BorraAsiento("FF" & "-" & Numero, Tr)
            '
         End If
         '
         If Estado = 2 Then
            '"Anulado"
            GuardarAudit("Anula contrato", NomProp & " - " & NomInq & " - Nº " & Numero, "AnulFinCtto", "", Tr)
         Else
            '"Finalizado"
            GuardarAudit("Finaliza contrato", NomProp & " - " & NomInq & " - Nº " & Numero, "AnulFinCtto", "", Tr)
         End If
         '
         If Tr.ToString <> "" Then
            'If IniTrans Then
            'Tr.Commit()
            'End If
         End If
         '
         Return True
         '
      Catch ex As System.Exception
         Dim st As New StackTrace(True)
         RegistrarError(st, "ModPol.AnulFinCtto", , Err.Description & Traducir("TransNComp", , Tr))
         If Tr.ToString <> "" Then
            'If IniTrans Then
            'Tr.Rollback()
            'End If
         End If
      End Try
      '
   End Function
   '
   Function FechaIncorrecta() As Boolean
      If Not IsNothing(CapturaDato(Cn, "Caja", "Comprob", "Fecha > '" & Format(Now, FormatFechaHora) & "'")) Then
         MensajeTrad("Fecha del sistema incorrecta")
         If Not LGR And Not usrAdmin Then
            FechaIncorrecta = True
         End If
      End If
   End Function
   '
   Sub DefMarcadores()
      '
      '*** Define Marcadores (Doc. Contrato).
      '
      Marcador(1) = "NUMEROCTTO" : DescMarc(1) = "Nº de Contrato"
      '
      Marcador(2) = "LOCADOR" : DescMarc(2) = "Nombre del Locador"
      Marcador(3) = "DNILOCADOR" : DescMarc(3) = "DNI del Locador"
      Marcador(4) = "DOMLOCADOR" : DescMarc(4) = "Domicilio del Locador"
      Marcador(5) = "LOCLOCADOR" : DescMarc(5) = "Localidad del Locador"
      '
      Marcador(6) = "LOCATARIO" : DescMarc(6) = "Nombre del Locatario"
      Marcador(7) = "DNILOCATARIO" : DescMarc(7) = "DNI del Locatario"
      Marcador(8) = "DOMLOCATARIO" : DescMarc(8) = "Domicilio del Locatario"
      Marcador(9) = "LOCLOCATARIO" : DescMarc(9) = "Localidad del Locatario"
      '
      Marcador(10) = "TIPOPROP" : DescMarc(10) = "Tipo de Propiedad"
      Marcador(11) = "DOMPROP" : DescMarc(11) = "Domicilio de la Propiedad"
      Marcador(12) = "LOCPROP" : DescMarc(12) = "Localidad de la Propiedad"
      Marcador(13) = "COMODIDADES" : DescMarc(13) = "Comodidades de la Propiedad"
      Marcador(14) = "DESTINOPROP" : DescMarc(14) = "Destino: Particular o Comercial"
      '
      Marcador(15) = "MESES" : DescMarc(15) = "Meses de duración del Contrato"
      Marcador(16) = "SONMESES" : DescMarc(16) = "Meses en letras"
      Marcador(17) = "AÑOS" : DescMarc(17) = "Años de duración del Contrato"
      Marcador(18) = "SONAÑOS" : DescMarc(18) = "Años en letras"
      Marcador(19) = "DESDE" : DescMarc(19) = "Fecha inicio de Contrato"
      Marcador(20) = "FECHADESDE" : DescMarc(20) = "Fecha inicio formato largo"
      Marcador(21) = "HASTA" : DescMarc(21) = "Fecha finalización de Contrato"
      Marcador(22) = "FECHAHASTA" : DescMarc(22) = "Fecha finalización formato largo"
      Marcador(23) = "DIAVENC" : DescMarc(23) = "Dia de Vencimiento de cada mes"
      '
      Marcador(24) = "SONPESOS" : DescMarc(24) = "Importe Alquiler en letras"
      Marcador(25) = "PESOS" : DescMarc(25) = "Importe Alquiler"
      Marcador(26) = "SONDOLARES" : DescMarc(26) = "Importe Dolares Alquiler en letras"
      Marcador(27) = "DOLARES" : DescMarc(27) = "Importe Dolares Alquiler"
      '
      Marcador(28) = "NOMEMP" : DescMarc(28) = "Nombre de la Inmobiliaria"
      Marcador(29) = "DOMEMP" : DescMarc(29) = "Domicilio de la Inmobiliaria"
      Marcador(30) = "LOCEMP" : DescMarc(30) = "localidad de la Inmobiliaria"
      '
      Marcador(31) = "GARANTE" : DescMarc(31) = "Nombre del Garante"
      Marcador(32) = "DNIGARANTE" : DescMarc(32) = "DNI del Garante"
      Marcador(33) = "DOMGARANTE" : DescMarc(33) = "Domicilio del Garante"
      Marcador(34) = "LOCGARANTE" : DescMarc(34) = "Localidad del Garante"
      '
      Marcador(35) = "PESOSDEPOSITO" : DescMarc(35) = "Importe mes Depósito en letras"
      Marcador(36) = "DEPOSITO" : DescMarc(36) = "Importe mes Depósito"
      Marcador(37) = "PSELLOCATARIO" : DescMarc(37) = "Porcentaje sellado Locatario"
      Marcador(38) = "PSELLOCADOR" : DescMarc(38) = "Porcentaje sellado Locador"
      '
      Marcador(39) = "INVENTARIO" : DescMarc(39) = "Inventario de la Propiedad"
      Marcador(40) = "CONSORCIO" : DescMarc(40) = "Nombre del Consorcio"
      '
      Marcador(41) = "DIAS" : DescMarc(41) = "Dia de la firma del Contrato"
      Marcador(42) = "SONDIAS" : DescMarc(42) = "Dia de la firma del Contrato en letras"
      Marcador(43) = "MES" : DescMarc(43) = "Mes del Contrato"
      Marcador(44) = "AÑO" : DescMarc(44) = "Año del Contrato"
      '
      Marcador(45) = "COTDOLAR" : DescMarc(45) = "Cotización Dolar"
      '
      Marcador(46) = "PROPIEDAD" : DescMarc(46) = "Tipo de Propiedad"
      Marcador(47) = "DOMPROPIEDAD" : DescMarc(47) = "Domicilio Propiedad"
      Marcador(48) = "LOCPROPIEDAD" : DescMarc(48) = "Localidad Propiedad"
      '
   End Sub
   '
   Function CaptColor_x(ByVal Cnx As OleDb.OleDbConnection, ByVal CodInq As Long, ByVal Nombre As String, ByVal DNI As String) As Object
      '
      Dim Rs As New OleDb.OleDbCommand
      Dim Dr As OleDb.OleDbDataReader
      Dim r As Object
      '
      varOkInq2 = False
      '
      If Cnx.State = 0 Then
         r = &H8000000F
      Else
         With Rs
            .Connection = Cn
            .CommandText = "SELECT Nombre, DNI FROM Inquilinos WHERE Codigo = " & CodInq
            Dr = .ExecuteReader
         End With
         With Dr
            If .Read Then
               If DNI = !DNI And Nombre = !Nombre Then
                  r = &H80000001
                  varOkInq2 = True
               Else
                  r = &H80000010
               End If
            Else
               r = &H80000010
            End If
            .Close()
         End With
      End If
      '
      Return r
      '
   End Function
   '
   Function CaptColor_Prd(ByVal Cnx As OleDb.OleDbConnection, ByVal CodPrd As String, ByVal Domicilio As String, ByVal Propietario As String) As Object
      '
      Dim Rs As New OleDb.OleDbCommand
      Dim Dr As OleDb.OleDbDataReader
      Dim r As Object
      '
      If Cnx.State = 0 Then
         r = &H8000000F
      Else
         With Rs
            .Connection = Cn
            .CommandText = "SELECT Domicilio, Propietario FROM Propiedades WHERE Codigo = '" & CodPrd & "'"
            Dr = .ExecuteReader
         End With
         With Dr
            If .Read Then
               If Domicilio = !Domicilio And Propietario = !Propietario Then
                  r = &H80000001
               Else
                  r = &H80000010
               End If
            Else
               r = &H80000010
            End If
            .Close()
         End With
      End If
      '
      Return r
      '
   End Function
   '
   Function CalcPeriodo(ByVal FechaDesde As Date, ByVal CantMeses As Int16, Optional ByVal MesAct As Int16 = 0) As String
      '
      Dim ContMes As Integer
      Dim nMes As Integer
      Dim Avance As Integer
      Dim FechaAct As Date
      Dim PerAct As String
      '
      Avance = IIf(CantMeses >= 0, 1, -1)
      ContMes = 1
      FechaAct = FechaDesde
      '
      If CantMeses <> 0 Then
         Do While True
            nMes = Month(FechaDesde)
            FechaDesde = FechaDesde.AddDays(Avance)
            If ContMes = Math.Abs(CantMeses) Then Exit Do
            If Month(FechaDesde) <> nMes Then ContMes = ContMes + Avance
            PerAct = Format(FechaAct, "yyyyMM")
            If PerAct = Format(Today, "yyyyMM") Then
               MesAct = ContMes
            End If
            SumaMes(FechaAct, Avance)
         Loop
      End If
      '
      Return Format(Year(FechaDesde), "0000") & Format(Month(FechaDesde), "00")
      '
   End Function
   '
   Function AlicuotasIva(ByVal LetraEmi As String, ByVal TipoIva As String, ByVal Alicuota As String, ByRef Alicuota1 As Single, ByRef Alicuota2 As Single) As Boolean
      '
      Dim RsTiva As New OleDb.OleDbCommand
      Dim rsAIva As New OleDb.OleDbCommand
      Dim Dr1 As OleDb.OleDbDataReader
      Dim Dr2 As OleDb.OleDbDataReader
      '
      With RsTiva
         .Connection = Cn
         .CommandText = "SELECT * FROM TipoIva WHERE Codigo = '" & TipoIva & "'"
         Dr1 = .ExecuteReader
      End With
      '
      With Dr1
         If .Read Then
            '
            With rsAIva
               .Connection = Cn
               .CommandText = "SELECT * FROM AlicIva WHERE Codigo = '" & Alicuota & "'"
               Dr2 = .ExecuteReader
            End With
            '
            With Dr2
               If .Read Then
                  Alicuota1 = !Alicuo1
                  Alicuota2 = 0
                  If LetraEmi = "A" And _
                     Trim(Dr1!EmiteComp) = "C" Then
                     Alicuota2 = 0   '!Alicuo2
                  End If
               Else
                  MensajeTrad("AIvaNoEnc")
                  Alicuota1 = 0
                  Alicuota2 = 0
               End If
               .Close()
            End With
         End If
      End With
      '
      AlicuotasIva = True
      '
   End Function
   '
   Function ActPropConc(ByVal Periodo As String, ByVal Propiedad As Long, ByVal Inquilino As Long, ByVal nMes As Int16, ByVal cDia As Byte, Optional ByVal Concepto As String = "", Optional ByRef Tr As Object = "") As Boolean
      '
      Dim FecIni As Date
      Dim Fecha As Date
      Dim cConc As String
      '
      Dim Cmd As New OleDb.OleDbCommand
      Dim Cm2 As New OleDb.OleDbCommand
      Dim Drd As OleDb.OleDbDataReader
      '
      FecIni = cDia & "/" & Right(Periodo, 2) & "/" & Left(Periodo, 4)
      Fecha = SumaMes(cDia & "/" & Right(Periodo, 2) & "/" & Left(Periodo, 4), cfgLiqVenCur * -1)
      '
      With Cmd
         .Connection = Cn
         '
         If Tr.ToString <> "" Then
            .Transaction = Tr
         End If
         '
         .CommandText = "DELETE FROM FactInq " &
                        "WHERE Periodo = '" & Periodo & "'" &
                        "  AND Propiedad = " & Propiedad &
                        "  AND Automatico <> 0 AND Liquidado = 0 AND LEFT(Concepto,3) <> 'DIF' " &
                        IIf(Concepto = "", "", " AND Concepto = '" & Concepto & "' ") &
                        "  AND NOT EXISTS( SELECT Numero FROM Contratos " &
                                          "WHERE Propiedad = FactInq.Propiedad AND Inquilino = FactInq.Inquilino AND Estado = 1 " &
                                          "  AND PerDesde <= FactInq.Periodo AND PerHasta >= FactInq.Periodo)"
         Dim n = .ExecuteNonQuery()
         '
      End With
      '
      If Not IsNothing(CapturaDato(Cn, "Contratos", "Numero", "Inquilino = " & Inquilino & " And Propiedad = " & Propiedad & " And (Estado = 0 Or Estado = 1 And CtoFecFin > '" & Format(Fecha, FormatFecha) & "') AND PerDesde <= '" & Periodo & "' AND PerHasta >= '" & Periodo & "'", , , , Tr)) Then
         '
         With Cm2
            .Connection = Cn
            '
            If Tr.ToString <> "" Then
               .Transaction = Tr
            End If
            '
            .CommandText = "SELECT * FROM PropiedConc P " &
                           "WHERE Propiedad = " & Propiedad &
                           "  AND noInquilino = 0" &
                           "  AND FecDesde = (SELECT MAX(FecDesde) FROM PropiedConc " &
                           "                  WHERE(Propiedad = P.Propiedad)" &
                           "                    AND FecDesde <= " & strFEC & Format(FecIni, FormatFecha) & strFEC &
                           "                    AND noInquilino = 0" &
                           "                    AND Concepto = P.Concepto) " &
                           IIf(Concepto = "", "", " AND P.Concepto = '" & Concepto & "' ") &
                           "ORDER BY Concepto"
            Drd = .ExecuteReader
         End With
         '
         With Drd
            Do While .Read
               cConc = !Concepto
               'Cm2.Connection = Cn
               If Tr.ToString <> "" Then
                  Cm2.Transaction = Tr
               End If
               '
               Cmd.CommandText = "UPDATE FactInq SET " &
                                " Periodo = '" & Periodo & "', " &
                                " Propiedad = " & Propiedad & ", " &
                                " Inquilino = " & Inquilino & ", " &
                                " Concepto = '" & cConc & "', " &
                                " Fecha = '" & Format(Fecha, FormatFecha) & "', " &
                                " Detalle = '" & !Detalle & "', " &
                                " Importe = '" & !Importe & "', " &
                                " Saldo = '" & !Importe & "', " &
                                " Imputacion = '" & !Imputacion & "', " &
                                " Automatico = 1, " &
                                " aPropiet = " & IIf(!aPropiet, 1, 0) & ", " &
                                " MesPago = " & nMes & ", " &
                                " Usuario = '" & Uid & "', " &
                                " FechaMod = '" & Format(Now, FormatFechaHora) & "' " &
                                "WHERE Periodo = '" & Periodo & "' " &
                                "  AND Propiedad = " & Propiedad & " " &
                                "  AND Concepto = '" & cConc & "' " &
                                "  AND Liquidado = 0"
               Cmd.ExecuteNonQuery()
               '
               'If Not GenCompraOtr(Propiedad, Propiedad, Periodo, Periodo, cConc, Tr) Then
               ' Return False
               'End If
               '
            Loop
            .Close()
         End With
         '
         Fecha = SumaMes(cDia & "/" & Right(Periodo, 2) & "/" & Left(Periodo, 4), cfgLiqVenCur * -1)
         '
         With Cmd
            .CommandText = "INSERT INTO FactInq( Periodo, Propiedad, Inquilino, Concepto, Fecha, Detalle, Importe, Saldo, Imputacion, Automatico, aPropiet, Liquidado, MesPago, Usuario, FechaMod) " &
                            "SELECT '" & Periodo & "', " & Propiedad & ", " & Inquilino & ", " &
                            " Concepto, '" & Format(Fecha, FormatFecha) & "', " &
                            " Detalle, Importe, Importe, Imputacion, 1, aPropiet, 0, " & nMes & ", '" & Uid & "', '" & Format(Now, FormatFechaHora) & "' " &
                            "FROM PropiedConc PC " &
                            "WHERE Propiedad = " & Propiedad & " " &
                            "  AND FecDesde <= " & strFEC & Format(FecIni, FormatFecha) & strFEC &
                            IIf(Concepto = "", "", " AND PC.Concepto = '" & Concepto & "' ") &
                            "  AND noInquilino = 0 " &
                            "  AND FecDesde = (SELECT MAX(FecDesde) FROM PropiedConc WHERE Propiedad = " & Propiedad & " AND Concepto = PC.Concepto AND FecDesde <= " & strFEC & Format(Fecha, FormatFecha) & strFEC & ") " &
                            "  AND NOT EXISTS( SELECT * FROM FactInq WHERE Periodo = '" & Periodo & "' AND Propiedad = PC.Propiedad AND Inquilino = " & Inquilino & " AND Concepto = PC.Concepto) " &
                            "ORDER BY Concepto, FecDesde"
            .ExecuteNonQuery()
            '
         End With
      End If
      '
      If Not GenCompraOtr(Propiedad, Propiedad, Periodo, Periodo, Concepto, Tr) Then
         Return False
      End If
      '
      Return True
      '
   End Function
   '
   Function ActAsiFactInq(ByVal NroContrato As Int32, Optional ByVal Tr As Object = "") As Boolean
      '
      If Not SisContable Then Exit Function
      '
      Const cmpInt = "CT"
      '
      Dim i As Integer
      Dim Prt As Int32
      Dim Prd As Int32
      Dim Inq As Int32
      Dim nMeses As Integer
      Dim cPer As String
      Dim n As Int16
      Dim Sucursal As Integer
      '
      Dim NroAsi As Long
      Dim NroAsP As Long
      Dim RenASi As Integer
      Dim RenAsP As Integer
      Dim CodAsi As String
      Dim CodAsP As String
      Dim FecAsi As Date
      Dim DetAsi As String
      Dim DetAsP As String
      '
      Dim CtaPrt As String
      Dim CtaInq As String
      Dim Nombre As String = ""
      Dim NomInq As String = ""
      '
      Dim ImpPrt As Double
      Dim ImpInq As Double
      Dim Cuenta As String
      Dim Debe As Double
      Dim Haber As Double
      '
      Dim Rs As New OleDb.OleDbCommand
      Dim RsD As New OleDb.OleDbCommand
      Dim Dr As OleDb.OleDbDataReader
      Dim DrD As OleDb.OleDbDataReader
      '
      'Dim rsProp As New ADODB.Recordset
      'Dim rsInq As New ADODB.Recordset
      'Dim rsConc As New ADODB.Recordset
      'Dim rsDOtr As New ADODB.Recordset
      '
      With Rs
         .Connection = Cn
         If Tr.ToString <> "" Then
            .Transaction = Tr
         End If
         .CommandText = "SELECT * FROM Contratos WHERE Numero = " & NroContrato
         Dr = .ExecuteReader
      End With
      With Dr
         If .Read Then
            Prt = !Propietario
            Inq = !Inquilino
            Prd = !Propiedad
            nMeses = !Meses
            FecAsi = SumaMes(!DiaVenc & "/" & Right(!PerDesde, 2) & "/" & Left(!PerDesde, 4), cfgLiqVenCur * -1)
            Sucursal = !Sucursal
         Else
            .Close()
            Err.Raise(1001, "ModPol.ActAsiFactInq", "CttoNoEnc")
         End If
         .Close()
      End With

      With Rs
         .CommandText = "SELECT * FROM Propietarios WHERE Codigo = " & Prt
         Dr = .ExecuteReader
      End With
      With Dr
         If .Read Then
            CtaPrt = IIf(cfgCtaPrtUnica, cfgCtaMadrePrt, !Cuenta)
            Nombre = !Nombre
         Else
            .Close()
            Err.Raise(1001, "ModPol.ActAsiFactInq", Traducir("PrtNoEnc", , Tr))
         End If
         .Close()
      End With
      '
      With Rs
         .CommandText = "SELECT * FROM Inquilinos WHERE Codigo = " & Inq
         Dr = .ExecuteReader
      End With
      With Dr
         If .Read Then
            CtaInq = IIf(cfgCtaInqUnica, cfgCtaMadreInq, !Cuenta)
            NomInq = !Nombre
         Else
            .Close()
            Err.Raise(1001, "ModPol.ActAsiFactInq", Traducir("InqNoEnc", , Tr))
         End If
         .Close()
      End With
      '
      For i = 1 To nMeses
         '
         n = 0
         '
         cPer = Format(FecAsi, "yyyyMM")
         With Rs
            .CommandText = "SELECT * FROM FactInq WHERE Inquilino = " & Inq & " AND Periodo = '" & cPer & "' AND Propiedad = " & Prd
            Dr = .ExecuteReader
         End With
         '
         RenASi = 0
         RenAsP = 0
         ImpInq = 0
         ImpPrt = 0
         '
         With Dr
            '
            Do While .Read
               '
               If n = 0 Then
                  '
                  n = n + 1
                  '
                  CodAsi = cmpInt & NroContrato & "/" & Format(i, "00")
                  CodAsP = CodAsi & "P"
                  DetAsi = Left(Traducir("Ctto.", , Tr) & "Nº" & NroContrato & "-" & Trim(Nombre) & "/" & Trim(NomInq), 50)
                  DetAsP = DetAsi
                  '
                  NroAsi = GuardaAsiento(CodAsi, FecAsi, DetAsi, Tr)
                  If NroAsi = 0 Then
                     .Close()
                     Err.Raise(1001, , Traducir("NoUpAsiento", , Tr))
                  End If
                  '
                  NroAsP = GuardaAsiento(CodAsP, FecAsi, DetAsP, Tr)
                  If NroAsP = 0 Then
                     .Close()
                     Err.Raise(1001, , Traducir("NoUpAsiento", , Tr))
                  End If
                  '
                  '/* Borra Detalle Asientos
                  If Not BorraAsienDet(NroAsi, Tr) Then
                     .Close()
                     GoTo mError
                  End If
                  If Not BorraAsienDet(NroAsP, Tr) Then
                     .Close()
                     GoTo mError
                  End If
               End If
               '*/
               '
               '.MoveFirst()
               'Do While !Inquilino = cInq And _
               '!Periodo = cPer And _
               '!Propiedad = cPrd
               '
               ImpInq = ImpInq + IIf(!Imputacion = "D", !Importe, -!Importe)
               If !aPropiet Then
                  ImpPrt = ImpPrt + IIf(!Imputacion = "D", !Importe, -!Importe)
               End If
               '.MoveNext()
               'If .EOF Then Exit Do
            Loop
            '
            RenASi = RenASi + 1
            If Not GuardaAsienDet(NroAsi, RenASi, CtaInq, DetAsi, ImpInq, 0, Tr) Then
               .Close()
               Err.Raise(1001, , Traducir("NoUpAsiento", , Tr))
            End If
            '
            .Close()
            '
         End With
         '.MoveFirst()
         '
         'Do While !Inquilino = cInq And _
         '         !Periodo = cPer And _
         '         !Propiedad = cPrd
         Dr = Rs.ExecuteReader
         '
         With Dr
            Do While .Read
               If Not CaptCtasConc(!Concepto, "", "", Cuenta, , Tr) Then
                  .Close()
                  Err.Raise(1001, , Traducir("ConcSinCtaAsig", , Tr) & " (" & !Concepto & ")")
               End If
               '
               If !Imputacion = "D" Then
                  Debe = 0
                  Haber = !Importe
               Else
                  Debe = !Importe
                  Haber = 0
               End If
               '
               RenASi = RenASi + 1
               If Not GuardaAsienDet(NroAsi, RenASi, Cuenta, _
                                     Left(DetAsi & "-" & !Detalle, 50), _
                                     Debe, Haber, Tr) Then
                  .Close()
                  Err.Raise(1001, , Traducir("NoUpAsiento", , Tr))
               End If
               '
               If !aPropiet Then
                  RenAsP = RenAsP + 1
                  If Not GuardaAsienDet(NroAsP, RenAsP, Cuenta, _
                                        Left(DetAsP & "-" & !Detalle, 50), _
                                        Haber, Debe, Tr) Then
                     .Close()
                     Err.Raise(1001, , Traducir("NoUpAsiento", , Tr))
                  End If
               End If
               '
               '.MoveNext()
               'If .EOF Then Exit Do
            Loop
            '
            If i = 1 Then
               With RsD
                  .Connection = Cn
                  If Tr.ToString <> "" Then
                     .Transaction = Tr
                  End If
                  .CommandText = "SELECT * FROM CompraOtrDet WHERE Comprob = '" & cmpInt & "' AND Sucursal = " & Sucursal & " AND Numero = " & NroContrato & " AND Renglon = 1"
                  DrD = .ExecuteReader
               End With
               With DrD
                  '
                  'If .Read Then
                  'Do While !Comprob = cmpInt And _
                  '!Sucursal = Sucursal And _
                  '!Numero = NroContrato
                  '
                  Do While .Read
                     '
                     If !aPropiet Then
                        '
                        If Not CaptCtasConc(!Concepto, "", "", Cuenta, , Tr) Then
                           .Close()
                           Err.Raise(1001, , Traducir("CtaConcNoDef", , Tr) & "( " & !Concepto & ")")
                        End If
                        '
                        If !Imput = "D" Then
                           Debe = 0
                           Haber = !Importe
                        Else
                           Debe = !Importe
                           Haber = 0
                        End If
                        '
                        RenAsP = RenAsP + 1
                        If Not GuardaAsienDet(NroAsP, RenAsP, Cuenta, _
                                              Left(DetAsP & "-" & !Detalle, 50), _
                                              Debe, Haber, Tr) Then
                           .Close()
                           Err.Raise(1001, , Traducir("NoUpAsiento", , Tr))
                        End If
                        '
                        ImpPrt = ImpPrt + Debe - Haber
                        '
                     End If
                     '
                     '.MoveNext()
                     'If .EOF Then Exit Do
                  Loop
                  'End If
                  .Close()
               End With
            End If
            '
            RenAsP = RenAsP + 1
            If Not GuardaAsienDet(NroAsP, RenAsP, CtaPrt, DetAsP, 0, ImpPrt, Tr) Then
               .Close()
               Err.Raise(1001, , Traducir("NoUpAsiento", , Tr))
            End If
            '
            .Close()
         End With
         FecAsi = SumaMes(FecAsi, 1)
      Next i
      '
      Return True
      '
      Exit Function
      '
mError:
      Return False
      '
   End Function
   '
   Function GenCompraOtr(ByVal PrdDesde As Long, ByVal PrdHasta As Long, ByVal PerDesde As String, ByVal PerHasta As String, Optional ByVal Concepto As String = "", Optional ByRef Tr As Object = "") As Boolean
      '
      Dim Cmd As New OleDb.OleDbCommand
      Dim Drd As OleDb.OleDbDataReader
      '
      Dim dFec As Date
      Dim cPer As String
      Dim dUno As Date = "01/" & Format(Today, "MM/yyyy")
      Dim nMeses As Integer
      Dim cProp As String
      Dim cConc As String
      Dim i As Integer
      Dim PerFin As String = ""
      '
      nMeses = DateDiff("m", "01/" & Right(PerDesde, 2) & "/" & Left(PerDesde, 4), "01/" & Right(PerHasta, 2) & "/" & Left(PerHasta, 4)) + 1
      '
      With Cmd
         .Connection = Cn
         If Tr.ToString <> "" Then
            .Transaction = Tr
         End If
         .CommandText = "SELECT C.*, P.Nombre, D.Propietario, D.Domicilio, (SELECT MIN(FecDesde) FROM PropiedConc " & _
                        "             WHERE Propiedad = C.Propiedad " & _
                        "               AND Concepto = C.Concepto " & _
                        "               AND FecDesde > C.FecDesde) AS FecHasta " & _
                        "FROM PropiedConc C " & _
                        " INNER JOIN Propiedades D ON C.Propiedad = D.Codigo " & _
                        " INNER JOIN Propietarios P ON D.Propietario = P.Codigo " & _
                        "WHERE C.Propiedad >= " & PrdDesde & _
                        "  AND C.Propiedad <= " & PrdHasta & _
                        IIf(Concepto = "", "", " AND C.Concepto = '" & Concepto & "' ") & _
                        "  AND ((aPropiet = 0 And Imputacion = 'D') OR noInquilino <> 0) " & _
                        "  AND C.FecDesde = (SELECT MAX(FecDesde) FROM PropiedConc C2 " & _
                        "                    WHERE C2.propiedad = C.Propiedad " & _
                        "                      AND ((C2.aPropiet = 0 And C2.Imputacion = 'D') OR C2.noInquilino <> 0) " & _
                        "                      AND C2.FecDesde <= '" & PerDesde & "01') " & _
                        "ORDER BY C.Propiedad, C.Concepto, C.FecDesde"
         Drd = .ExecuteReader
      End With
      '
      With Drd
         Do While .Read
            '
            cProp = .Item("Propiedad")
            cConc = .Item("Concepto")
            '
            If IsDBNull(.Item("FecHasta")) Then
               PerFin = ""
            Else
               PerFin = CalcPeriodo(!FecHasta, -1)
            End If
            '
            For i = 1 To nMeses
               '
               dFec = SumaMes("01/" & Right(PerDesde, 2) & "/" & Left(PerDesde, 4), i - 1)
               cPer = Format(dFec, "yyyyMM")
               '
               If .Item("FecDesde") <= dFec And (cPer <= PerFin Or PerFin = "") And dFec >= dUno Then
                  '
                  If Not GuardaCmpOtr(.Item("Propietario"), .Item("Propiedad"), .Item("Concepto"), cPer, .Item("Imputacion"), .Item("Importe"), .Item("Nombre"), .Item("Detalle"), .Item("Domicilio"), .Item("aPropiet"), Tr) Then
                     .Close()
                     Err.Raise(1001, , Traducir("NoGenCompraOtr", , Tr) & vbCrLf & _
                                       " Propiedad: " & !Propiedad & vbCrLf & _
                                       " Concepto : " & !Concepto)
                  End If
                  '
                  '*** frmMenuInmob.StatusBar1.Panels(1) = "Aguarde, Generando comprobantes..."
                  '
               End If
               '
            Next i
            '
         Loop
         '
         .Close()
         '
      End With
      '
      Return True
      '
   End Function
   '
   Private Function GuardaCmpOtr(ByVal Propietario As Int32, ByVal Propiedad As Int32, ByVal Concepto As String, ByVal Periodo As String, ByVal Imput As String, ByVal Importe As Double, ByVal Detalle As String, DetAsi As String, Domicilio As String, Optional ByVal aPropiet As Boolean = False, Optional ByRef Tr As Object = "") As Boolean
      '
      Dim Cmd As New OleDb.OleDbCommand
      '
      Dim Comprob As String
      Dim Mes As Integer
      Dim Año As Integer
      Dim Fecha As Date
      Dim CodAsi As String
      Dim NroAsi As Long
      Dim RenASi As Integer
      Dim CtaPrt As String
      Dim CtaCod As String = ""
      Dim DetConc As String = CapturaDato(Cn, "Conceptos", "Descrip", "Codigo = '" & Concepto & "'", , , , Tr)
      '
      Const cmpInt = "CP"
      '
      Comprob = cmpInt & "-" & Propiedad & "-" & Concepto
      Mes = Right(Periodo, 2)
      Año = Left(Periodo, 4)
      Fecha = "10/" & Mes & "/" & Año
      '
      If SisContable Then
         CodAsi = Comprob & "-" & Periodo
         DetAsi = Trim(Detalle)
      End If
      '
      With Cmd
         .Connection = Cn
         If Tr.ToString <> "" Then
            .Transaction = Tr
         End If
      End With
      '
      If SisContable Then
         CtaPrt = CapturaDato(Cn, "Propietarios", "Cuenta", "Codigo = " & Propietario, , , , Tr)
      End If
      '
      With Cmd
         '
         If IsNothing(CapturaDato(Cn, "CompraOtr", "Comprob", "Comprob = '" & Comprob & "' AND Sucursal = " & Mes & " AND Numero = " & Año, , , , Tr)) Then
            .CommandText = "INSERT INTO CompraOtr( Comprob, Sucursal, Numero, Pagado, Liquidado, Proveedor, Fecha, FechaVenc, Propietario, Propiedad, Detalle, Total, Usuario, FechaMod) " &
                           "VALUES('" & Comprob & "', " &
                                        Mes & ", " &
                                        Año & ", " &
                                        0 & ", " &
                                        0 & ", " &
                                        0 & ", " &
                                  "'" & Format(Fecha, FormatFecha) & "', " &
                                  "'" & Format(Fecha, FormatFecha) & "', " &
                                        Propietario & ", " &
                                        Propiedad & ", " &
                                  "'" & Detalle & "', " &
                                        Importe & ", " &
                                  "'" & Uid & "', " &
                                  "'" & Format(Now, FormatFechaHora) & "')"
            .ExecuteNonQuery()
         Else
            If IsNothing(CapturaDato(Cn, "CompraOtr", "Comprob", "Comprob = '" & Comprob & "' AND Sucursal = " & Mes & " AND Numero = " & Año & " AND (Pagado <> 0 Or Liquidado <> 0)", , , , Tr)) Then
               .CommandText = "UPDATE CompraOtr SET " &
                              " Comprob = '" & Comprob & "', " &
                              " Sucursal = " & Mes & ", " &
                              " Numero = " & Año & ", " &
                              " Pagado = 0, " &
                              " Liquidado = 0, " &
                              " Proveedor = 0, " &
                              " Fecha = '" & Format(Fecha, FormatFecha) & "', " &
                              " FechaVenc = '" & Format(Fecha, FormatFecha) & "', " &
                              " Propietario = " & Propietario & ", " &
                              " Propiedad = " & Propiedad & ", " &
                              " Detalle = '" & Detalle & "', " &
                              " Total = " & Importe & ", " &
                              " Usuario = '" & Uid & "', " &
                              " FechaMod = '" & Format(Now, FormatFechaHora) & "' " &
                              "WHERE Comprob = '" & Comprob & "' AND Sucursal = " & Mes & " AND Numero = " & Año
               .ExecuteNonQuery()
            End If
         End If
         '
         .CommandText = "DELETE FROM CompraOtrDet WHERE Comprob = '" & Comprob & "' AND Sucursal = " & Mes & " AND Numero = " & Año
         .ExecuteNonQuery()
         '
         .CommandText = "INSERT INTO CompraOtrDet( Comprob, Sucursal, Numero, Renglon, Proveedor, Fecha, Concepto, Detalle, Imput, Importe, aPropiet, Usuario, FechaMod) " &
                        "VALUES('" & Comprob & "', " &
                                     Mes & ", " &
                                     Año & ", " &
                                     1 & ", " &
                                     0 & ", " &
                               "'" & Format(Fecha, FormatFecha) & "', " &
                               "'" & Concepto & "', " &
                               "'" & DetConc & "-" & Domicilio & "', " &
                               "'" & Imput & "', " &
                                     Importe & ", " &
                                     IIf(aPropiet, 1, IIf(PropiedadAlquilada(Propiedad, Periodo, Tr), 0, 1)) & ", " &
                               "'" & Uid & "', " &
                               "'" & Format(Now, FormatFechaHora) & "')"
         .ExecuteNonQuery()
         '
      End With
      '
      If SisContable Then
         If PropiedadAlquilada(Propiedad, Periodo, Tr) Then
            BorraAsiento(CodAsi, Tr)
         End If
         '
         If Not CaptCtasConc(Concepto, "", "", CtaCod, , Tr) Then
            Err.Raise(1001, , Traducir("CtaConcNoDef", , Tr) & " (" & Concepto & ")")
         End If
         '
         NroAsi = GuardaAsiento(CodAsi, Fecha, Left(DetAsi & "-" & Detalle, 50), Tr)
         If NroAsi = 0 Then Err.Raise(1001, , "NoUpAsiento")
         '
         If Not BorraAsienDet(NroAsi, Tr) Then
            Err.Raise(1001, , "NoUpAsiento")
         End If
         '
         RenASi = RenASi + 1
         If Not GuardaAsienDet(NroAsi, RenASi, CtaPrt, Left(DetAsi & "-" & Domicilio, 50), Importe, 0, Tr) Then
            Err.Raise(1001, , "NoUpAsiento")
         End If
         '
         RenASi = RenASi + 1
         If Not GuardaAsienDet(NroAsi, RenASi, CtaCod, Left(Detalle & "-" & Domicilio, 50), 0, Importe, Tr) Then
            Err.Raise(1001, , "NoUpAsiento")
         End If
         '
      End If
      '
      Return True
      '
   End Function
   '
   Function PropiedadAlquilada(ByVal Propiedad As Int32, ByVal Periodo As String, Optional ByVal Tr As Object = "") As Boolean
      '
      If IsNothing(CapturaDato(Cn, "Contratos", "Estado", "Propiedad = " & Propiedad & " AND PerDesde <= '" & Periodo & "' AND PerHasta >= '" & Periodo & "' AND Estado <> 2", , , , Tr)) Then
         Return False
      Else
         Return True
      End If
      '
   End Function
   '
   Function TieneAdelantos(ByRef Propietario As Int32, ByRef Propiedad As Int32, ByRef Periodo As String) As Boolean
      '
      Dim Cmd As New OleDb.OleDbCommand
      Dim Dr As OleDb.OleDbDataReader
      '
      Dim r As Boolean
      Dim MismaProp As Boolean
      Dim TieneAdl As Boolean = False
      '
      With Cmd
         .Connection = Cn
         .CommandText = "SELECT * FROM LiqPropiet L, LiqInqDet D " & _
                        "WHERE D.Tipo = 'L' AND D.Numero = L.Numero " & _
                        "  AND D.Concepto = '" & cfgCodigoAdl & "'" & _
                        "  AND Propietario = " & Propietario & _
                        "  AND (Propiedad = " & Propiedad & " OR Propiedad IS NULL OR Propiedad = 0)" & _
                        "  AND Periodo = '" & Periodo & "'" & _
                        "  AND Estado <> 2"
         Dr = .ExecuteReader
      End With
      With Dr
         If Propiedad <> 0 Then
            Do While .Read
               If .Item("Propiedad") = Propiedad Then
                  MismaProp = True
                  Exit Do
               End If
            Loop
         Else
            If .Read Then
               TieneAdl = True
            End If
         End If
         '
         If Propiedad <> 0 And MismaProp Then
            MsgBox("Propiedad con adelanto en el período," & vbCrLf & "no es posible generar un nuevo adelanto")
            r = True
         Else
            If TieneAdl Then
               r = MsgBox("Propietario con adelantos en el período," & vbCrLf & "generar un nuevo adelanto", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No
            End If
         End If
         .Close()
      End With
      '
      Return r
      '
   End Function
   '
   Sub ActSdoIntAnt(ByVal Periodo As String, ByVal Propiedad As Int32, ByVal Inquilino As Int32, ByRef SdoAnt As Double, ByRef IntAnt As Double, ByRef FecAnt As Date)
      '
      Dim Rs As New OleDb.OleDbCommand
      Dim Dr As OleDb.OleDbDataReader
      '
      SdoAnt = 0
      IntAnt = 0
      FecAnt = Today
      '
      With Rs
         .Connection = Cn
         .CommandText = "SELECT TOP 1 * FROM LiqInqCab " & _
                        "WHERE Propiedad = " & Propiedad & _
                        "  AND Inquilino = " & Inquilino & _
                        "  AND Periodo <= '" & Periodo & "'" & _
                        "  AND Estado <> 2 " & _
                        "ORDER BY Periodo DESC, Numero DESC"
         Dr = .ExecuteReader
         '
         With Dr
            If .Read Then
               SdoAnt = !Saldo
               If !Periodo = Periodo Then
                  IntAnt = IntAnt + !Intereses
               End If
               FecAnt = !Fecha
            End If
            .Close()
         End With
      End With
      '
   End Sub
   '
   Sub AgrConsConc(ByVal Consorcio As String, ByVal Periodo As String, ByVal Dia As Byte)
      '
      'On Error GoTo Fin
      '
      Exit Sub
      '
      'Dim cAccion As String
      'Dim cDetalle As String
      '
      'Dim Cmd As New OleDb.OleDbCommand
      'Dim rsCCon As New ADODB.Recordset
      '
      'With Cmd
      '   '
      '   .CommandText = "SELECT * FROM ConsFact "
      '   If .EOF Then
      '      'Ok.
      '   Else
      '      Do While !Consorcio = cCons And !Periodo = cPer
      '         If !Liquidado Then
      '            Exit Sub
      '         ElseIf !Automatico Then
      '            .Delete()
      '         End If
      '         .MoveNext()
      '         If .EOF Then Exit Do
      '      Loop
      '   End If
      'End With
      '
      'With rsCCon
      '   '
      '   If .EOF Then
      '      'No tiene C.Fijos.-
      '   Else
      '      Do While !Consorcio = cCons
      '         rsFact.AddNew()
      '         rsFact!Consorcio = cCons
      '         rsFact!Periodo = cPer
      '         rsFact!Concepto = !Concepto
      '         rsFact!Depart = !Depart
      '         rsFact!Fecha = SumaMes(cDia & "/" & Right(cPer, 2) & "/" & Left(cPer, 4), cfgLiqVenCon * -1)
      '         rsFact!Detalle = !Detalle
      '         rsFact!Importe = !Importe
      '         rsFact!Imputacion = !Imputacion
      '         rsFact!Automatico = True
      '         rsFact!Usuario = Uid
      '         rsFact!FechaMod = Now
      '         rsFact.Update()
      '         .MoveNext()
      '         If .EOF Then Exit Do
      '      Loop
      '   End If
      'End With
      '
      '
   End Sub
   '
   Sub ActConsDFac(ByVal Consordio As Integer, ByVal Periodo As String, ByVal Depart As Int16, ByVal Propiedad As Integer, ByVal Inquilino As Integer, ByVal Porcent As Single)
      '
      'On Error GoTo Fin
      ''
      'Dim rsCFac As New ADODB.Recordset
      'Dim rsDFac As New ADODB.Recordset
      ''
      'Dim nImporte As Double
      'Dim bActual As Boolean
      ''
      'If cDep <> "" Then
      '   With rsDFac
      '      .Index = "ConDepPerC"
      '      '
      '      If .EOF Then
      '         'Ok.
      '      Else
      '         Do While !Consorcio = cCons And _
      '                  !Depart = cDep And _
      '                  !Periodo = cPer
      '            If !Liquidado Then
      '               Exit Sub
      '            End If
      '            .Delete()
      '            .MoveNext()
      '            If .EOF Then Exit Do
      '         Loop
      '      End If
      '   End With
      'End If
      ''
      'With rsCFac
      '   .Index = "ConsPerConc"
      '   If .EOF Then
      '      'No tiene Facturación.
      '   Else
      '      Do While !Consorcio = cCons And !Periodo = cPer
      '         bActual = False
      '         If !Depart = "(Todos)" Then
      '            nImporte = Round(!Importe * nPorc / 100, 2)
      '         Else
      '            nImporte = !Importe
      '         End If
      '         If cDep <> "" Then
      '            'P/Consorcios.
      '            If !Depart = "(Todos)" Or !Depart = cDep Then
      '               rsDFac.AddNew()
      '               rsDFac!Tipo = ""
      '               rsDFac!Consorcio = cCons
      '               rsDFac!Depart = cDep
      '               rsDFac!ImpTotal = !Importe
      '               bActual = True
      '            End If
      '         Else
      '            'P/Alquileres.
      '            rsDFac.Index = "PerPrdCon"
      '            '
      '            If rsDFac.EOF Then
      '               rsDFac.AddNew()
      '            Else
      '               'rsDFac.Edit
      '            End If
      '            rsDFac!Propiedad = cProp
      '            rsDFac!Inquilino = cInq
      '            rsDFac!Automatico = True
      '            bActual = True
      '         End If
      '         '
      '         If bActual Then
      '            rsDFac!Periodo = cPer
      '            rsDFac!Concepto = !Concepto
      '            rsDFac!Fecha = !Fecha
      '            rsDFac!Detalle = !Detalle
      '            rsDFac!Importe = nImporte
      '            rsDFac!Imputacion = !Imputacion
      '            rsDFac!Usuario = Uid
      '            rsDFac!FechaMod = Now
      '            rsDFac.Update()
      '         End If
      '         .MoveNext()
      '         If .EOF Then Exit Do
      '      Loop
      '   End If
      'End With
      '
      Exit Sub
      '
   End Sub
   '
   Function CapturaIva(ByVal Propietario As Long, ByRef TipoIva As String, ByRef Letra As String, ByRef AlicIva1 As Single, ByRef AlicIva2 As Single) As Boolean
      '
      Dim Rs As New OleDb.OleDbCommand
      Dim Dr As OleDb.OleDbDataReader
      Dim RsD As New OleDb.OleDbCommand
      Dim DrD As OleDb.OleDbDataReader
      '
      TipoIva = CapturaDato(Cn, "Propietarios", "TipoIva", "Codigo = " & Propietario)
      '
      With Rs
         .Connection = Cn
         .CommandText = "SELECT * FROM TipoIva WHERE Codigo = '" & TipoIva & "'"
         Dr = .ExecuteReader
         With Dr
            If .Read Then
               Letra = Left(Trim(!RecibeComp), 1)
               'CaptNumeros
               With RsD
                  .Connection = Cn
                  .CommandText = "SELECT * FROM AlicIva WHERE Codigo = 'GEN'"
                  DrD = .ExecuteReader
                  With DrD
                     If .Read Then
                        AlicIva1 = !Alicuo1
                        If Letra = "A" And Trim(Dr!EmiteComp) = "C" Then
                           AlicIva2 = !Alicuo2
                        Else
                           AlicIva2 = 0
                        End If
                        CapturaIva = True
                     Else
                        MensajeTrad("AlcIvaGenNEnc")
                        AlicIva1 = 0
                        AlicIva2 = 0
                     End If
                     .Close()
                  End With
               End With
            Else
               MensajeTrad("TIvaNoEnc")
               Propietario = 0
            End If
            .Close()
         End With
      End With
      '
   End Function
   '
   Function CalcInteres(ByVal Importe As Double, ByVal FecDesde As Date, ByVal FecHasta As Date, Optional ByVal IntDiario As Single = -1) As Double
      '
      Dim ndias As Integer
      '
      If IntDiario = -1 Then
         IntDiario = cfgIntDiario
      End If
      '
      CalcInteres = 0
      '
      If Importe <> 0 Then
         ndias = DateDiff(DateInterval.Day, FecDesde, FecHasta)
         If ndias > 0 Then
            CalcInteres = Importe * Val(IntDiario) / 100 * ndias
         End If
      End If
      '
   End Function
   '
   Sub ArmaComboPer(ByVal Combo As ComboBox, ByVal Desde As String, ByVal Hasta As String, Optional ByVal Primero As String = "")
      '
      Dim Mes0 As Integer
      Dim Año0 As Integer
      Dim Mes1 As Integer
      Dim Año1 As Integer
      Dim cPer As String
      '
      Mes0 = Val(Right(Desde, 2))
      Año0 = Val(Left(Desde, 4))
      Mes1 = Val(Right(Hasta, 2))
      Año1 = Val(Left(Hasta, 4))
      '
      Combo.Items.Clear()
      '
      If Primero <> "" Then
         Combo.Items.Add(Primero)
      End If
      '
      Do While True
         cPer = Format(Año0, "0000") + Format(Mes0, "00")
         Combo.Items.Add(Format(Mes0, "00") & "/" & Format(Año0, "0000"))
         If Mes0 < 12 Then
            Mes0 = Mes0 + 1
         Else
            Año0 = Año0 + 1
            Mes0 = 1
         End If
         If cPer >= Hasta Then
            Exit Do
         End If
      Loop
      '
   End Sub
   '
   Function CaptNroRecibo(ByVal Tipo As String, ByVal Sucursal As Int16, Optional ByVal Tr As Object = "") As Long
      Dim Numero As Long
      Select Case Tipo
         Case "A"
            cfgNroRboA = BuscarCfg("cfgNroRboA", 0, Tr)
            Numero = Val(cfgNroRboA) + 1
         Case "B"
            cfgNroRboB = BuscarCfg("cfgNroRboB", 0, Tr)
            Numero = Val(cfgNroRboB) + 1
         Case "C"
            cfgNroRboC = BuscarCfg("cfgNroRboC", 0, Tr)
            Numero = Val(cfgNroRboC) + 1
         Case "X"
            cfgNroRboX = BuscarCfg("cfgNroRboX", 0, Tr)
            Numero = Val(cfgNroRboX) + 1
      End Select
      Do While Not IsNothing(CapturaDato(Cn, "LiqInqCab", "Numero", "Tipo = '" & Tipo & "' AND Sucursal = " & Sucursal & " AND Numero = " & Numero, , , , Tr))
         Numero = Numero + 1
      Loop
      Return Numero
   End Function
   '
   Sub GuardarNroRecibo(ByVal Letra As String, ByVal Numero As Int32, Optional ByVal Tr As Object = "")
      Select Case Letra
         Case "A"
            GuardarCfg(cfgNroRboA, "cfgNroRboA", Numero, Tr)
         Case "B"
            GuardarCfg(cfgNroRboB, "cfgNroRboB", Numero, Tr)
         Case "C"
            GuardarCfg(cfgNroRboC, "cfgNroRboC", Numero, Tr)
         Case "X"
            GuardarCfg(cfgNroRboX, "cfgNroRboX", Numero, Tr)
      End Select
   End Sub
   '
   Function GuardarCaja(ByVal Alta As Boolean, ByVal GenAsi As Boolean, ByVal cmpInt As String, ByVal Caja As Integer, ByVal Entrada As Boolean, ByRef MovRec As Long, ByVal Importe As Double, ByVal fPago As String, ByVal Fecha As Date, ByVal Nombre As String, ByVal Detalle As String, ByVal Cuenta As String, ByVal ImporteAnt As Double, ByVal CtaCaja As String, Optional ByVal Tr As Object = "", Optional ByRef Comprob As String = "", Optional ByVal MovARec As Boolean = False) As Boolean
      '
      Dim Cmd As New OleDb.OleDbCommand
      Dim Cm2 As New OleDb.OleDbCommand
      Dim Drd As OleDb.OleDbDataReader
      '
      Dim NroAsi As Long
      Dim RenASi As Integer
      Dim nroCaja, ultNroCaja As Long
      Dim cMovRec As Object
      Dim Saldo As Double
      Dim SaldoRec As Object
      Dim CompNro As String
      '
      If Caja = 0 Then Caja = prmNroCaja
      '
      With Cmd
         .Connection = Cn
         If Tr.ToString <> "" Then
            .Transaction = Tr
         End If
      End With
      '
      If Alta Then
         '
         If GenAsi Then
            cMovRec = ProximoNroAsi(Tr)
            If Comprob = "" Then
               CompNro = cmpInt & cMovRec
            Else
               CompNro = Comprob
            End If
         Else
            If Comprob = "" Then
               CompNro = ProxCompCaja(cmpInt, cMovRec, Tr)
            Else
               CompNro = Comprob
            End If
         End If
         '
         With Cm2
            .Connection = Cn
            If Tr.ToString <> "" Then
               .Transaction = Tr
            End If
         End With
         '
         If Entrada Then
            If MovRec = 0 Then
               cMovRec = "NULL"
               SaldoRec = "NULL"
            Else
               cMovRec = MovRec
               SaldoRec = 0
               Saldo = Importe
               '
               With Cmd
                  '
                  Do While Saldo > 0
                     .CommandText = "SELECT * FROM Caja WHERE MovRec = " & MovRec & " AND Salida <> 0 AND SaldoRec > 0"
                     Drd = .ExecuteReader
                     With Drd
                        If .Read Then
                           With Cm2
                              '
                              If Saldo <= Math.Round(Drd!SaldoRec, 3) Then
                                 .CommandText = "UPDATE Caja SET " & _
                                                " SaldoRec = ROUND(SaldoRec, 3) - " & Saldo & " " & _
                                                "WHERE MovRec = " & MovRec & " AND " & Saldo & " <= ROUND(SaldoRec, 3)"
                                 Saldo = 0
                              Else
                                 .CommandText = "UPDATE Caja SET " & _
                                                " SaldoRec = 0 " & _
                                                "WHERE MovRec = " & MovRec & " AND " & Saldo & " > SaldoRec"
                                 Saldo = Saldo - Drd!SaldoRec
                                 If Saldo < 0.001 Then
                                    Saldo = 0.0
                                 End If
                              End If
                              .ExecuteNonQuery()
                              '
                           End With
                        End If
                        .Close()
                     End With
                  Loop
               End With
            End If
         Else
            cMovRec = IIf(MovARec, MovRec, "NULL")
            SaldoRec = IIf(MovARec, Importe, "NULL")
         End If
         '
         With Cmd
            .CommandText = "INSERT INTO Caja( Caja, Comprob, fPago, Fecha, FechaC, Nombre, Detalle, Entrada, Salida, CajaAdm, Cuenta, MovRec, SaldoRec, Usuario, FechaMod) " & _
                           "VALUES(" & Caja & ", " & _
                                 "'" & CompNro & "', " & _
                                 "'" & fPago & "', " & _
                                 "'" & Format(Fecha, FormatFechaHora) & "', " & _
                                 "'" & Format(Fecha, FormatFecha) & "', " & _
                                 "'" & Nombre & "', " & _
                                 "'" & Detalle & "', " & _
                                 IIf(Entrada, Importe, 0) & ", " & _
                                 IIf(Not Entrada, Importe, 0) & ", " & _
                                 0 & ", " & _
                                 "'" & Cuenta & "', " & _
                                 cMovRec & ", " & _
                                 SaldoRec & ", " & _
                                 "'" & Uid & "', " & _
                                 "'" & Format(Now, FormatFechaHora) & "')"
            .ExecuteNonQuery()
         End With
      Else
         CompNro = Comprob
         If Entrada Then
            If MovRec = 0 Then
               cMovRec = "NULL"
               SaldoRec = "NULL"
            Else
               cMovRec = MovRec
               SaldoRec = 0
               With Cmd
                  .CommandText = "UPDATE Caja SET " & _
                                 " SaldoRec = SaldoRec - " & Importe - ImporteAnt & ", " & _
                                 "WHERE MovRec = " & MovRec & " AND Salida <> 0"
                  .ExecuteNonQuery()
               End With
            End If
         Else
            cMovRec = IIf(MovARec, Right(CompNro, Len(CompNro) - 2), "NULL")
            SaldoRec = IIf(MovARec, "SaldoRec + " & Importe - ImporteAnt, "NULL")
         End If
         With Cmd
            .CommandText = "UPDATE Caja SET " & _
                           " Caja = " & Caja & ", " & _
                           " Fecha = '" & Format(Fecha, FormatFechaHora) & "', " & _
                           " FechaC = '" & Format(Fecha, FormatFecha) & "', " & _
                           " Nombre = '" & Nombre & "', " & _
                           " Detalle = '" & Detalle & "', " & _
                           " Entrada = " & IIf(Entrada, Importe, 0) & ", " & _
                           " Salida = " & IIf(Not Entrada, Importe, 0) & ", " & _
                           " CajaAdm = 0, " & _
                           " Cuenta = '" & Cuenta & "', " & _
                           " MovRec = " & cMovRec & ", " & _
                           " SaldoRec = " & SaldoRec & " " & _
                           "WHERE Comprob = '" & CompNro & "'" & _
                           "  AND fPago = '" & fPago & "'"
            .ExecuteNonQuery()
         End With
      End If
      '
      With Cmd
         .CommandText = "DELETE FROM LiqAux WHERE Usuario = '" & Uid & "' AND LqxPC = '" & NombrePC & "'"
         .ExecuteNonQuery()
         .CommandText = "INSERT INTO LiqAux( Recibe, SonPesos, Usuario, LqxPc) " & _
                        "VALUES('" & cfgNomEmp & "', " & _
                               "'" & Numero_a_Texto(Importe) & "', " & _
                               "'" & Uid & "', " & _
                               "'" & NombrePC & "')"
         .ExecuteNonQuery()
      End With
      '
      If Alta Then
         If Left(CompNro, 2) = "MN" Or
            Left(CompNro, 2) = "TR" Then
            nroCaja = Right(CompNro, Len(CompNro) - 2)
            ultNroCaja = Val(CapturaDato(Cn, "Config", "Valor", "Clave = 'cfgNroCajaMN'", , , , Tr) & "")
            If nroCaja > ultNroCaja Then
               With Cmd
                  .CommandText = "UPDATE Config SET Valor = '" & nroCaja & "' " & _
                                 "WHERE Clave = 'cfgNroCajaMN' AND Valor < '" & nroCaja & "'"
                  .ExecuteNonQuery()
                  cfgNroCajaMN = nroCaja
               End With
            End If
         End If
      End If
      '
      If GenAsi Then
         NroAsi = GuardaAsiento(CompNro, Fecha, Detalle, Tr)
         If NroAsi = 0 Then
            Err.Raise(1001, , "NoUpAsiento")
         End If
         '
         If Not BorraAsienDet(NroAsi, Tr) Then
            Err.Raise(1001, , "NoUpAsiento")
         End If
         '
         RenASi = RenASi + 1
         If Not GuardaAsienDet(NroAsi, RenASi, IIf(Entrada, CtaCaja, Cuenta), Detalle, Importe, 0, Tr) Then
            Err.Raise(1001, , "NoUpAsiento")
         End If
         '
         RenASi = RenASi + 1
         If Not GuardaAsienDet(NroAsi, RenASi, IIf(Not Entrada, CtaCaja, Cuenta), Detalle, 0, Importe, Tr) Then
            Err.Raise(1001, , "NoUpAsiento")
         End If
      End If
      '
      Comprob = CompNro
      '
      Return True
      '
   End Function
   '
   Function fPagoCaja(ByVal Comprob As String, ByVal fPago As String, Optional ByVal Tr As Object = "") As String
      Dim nContFp As Integer
      nContFp = 1
      Do While Not IsNothing(CapturaDato(Cn, "Caja", "Comprob", "Comprob = '" & Comprob & "' AND FPago = '" & fPago & "'", , , , Tr))
         nContFp = nContFp + 1
         fPago = "CH" & nContFp
      Loop
      fPagoCaja = fPago
   End Function
   '
   Sub AgrNuevoBarrio(Nombre As String, Optional Tr As Object = "")
      If IsNothing(CapturaDato(Cn, "Barrios", "Nombre", "Nombre = '" & Nombre & "'", , , , Tr)) Then
         Dim Cmd As New OleDb.OleDbCommand
         With Cmd
            .Connection = Cn
            If Tr.ToString <> "" Then
               .Transaction = Tr
            End If
            .CommandText = "INSERT INTO Barrios( Codigo, Nombre, BarrioUId, FechaMod) " & _
                           "VALUES( '', '" & Nombre & "', '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
            .ExecuteNonQuery()
         End With
      End If
   End Sub
   '
   Function CaptSqlUsuarios() As String
      '
      Dim r As String
      '
      'If PRV = "Jet" Or AutDB Then
      r = "SELECT Usuario, Nombre, Contraseña, Permisos, Admin " &
             "FROM Usuarios " &
             "ORDER BY Nombre"
      'Else
      '   r = "SELECT U.Status, M.Name AS Usuario, U.Name AS Nombre " &
      '       "FROM SysUsers U, Master.." & IIf(PRV = "Sql", "SysXLogins", "SysLogins") & " M " &
      '       " WHERE U.Status IN( 0, 2, 6) " &
      '       "  AND U.Sid = M.Sid " &
      '       "ORDER BY U.Name"
      'End If
      '
      Return r
      '
   End Function
   '
   Sub CaptDatosCtto(Inquilino As Int32, Propiedad As Int32, ByRef NroCtto As Int32, ByRef PerDesde As String, ByRef PerHasta As String, ByRef nMeses As Byte, ByRef DiaVenc As Byte, Optional Tr As Object = "")
      '
      Dim Cmd As New OleDb.OleDbCommand
      Dim Drd As OleDb.OleDbDataReader
      '
      With Cmd
         .Connection = Cn
         If Tr.ToString <> "" Then
            .Transaction = Tr
         End If
         .CommandText = "SELECT * FROM Contratos WHERE Inquilino = " & Inquilino & " AND Propiedad = " & Propiedad & " AND Estado = 0"
         Drd = .ExecuteReader
         '
         With Drd
            If .Read Then
               NroCtto = !Numero
               PerDesde = !PerDesde
               PerHasta = !PerHasta
               nMeses = !Meses
               DiaVenc = !DiaVenc
            Else
               NroCtto = 0
               PerDesde = Format(Today, "yyyyMM")
               PerHasta = PerDesde
               nMeses = 1
               DiaVenc = 10
            End If
            .Close()
         End With
      End With
      '
   End Sub
   '
   Function GuardarOrdenPago(Alta As Boolean, CmpInt As String, Proveedor As Int32, Fecha As Date, Total As Double, Efectivo As Double, Cheques As Double, Transf As Double, GtosBanc As Double, Detalle As String, OrdenPagoId As Int32, Caja As Byte, Recibe As String, TmpCmp As String, TmpChs As String, TmpTransf As String, Estado As Byte, Optional PagoDir As Boolean = False) As Boolean
      '
      Dim Trn As OleDb.OleDbTransaction
      Dim Cmd As New OleDb.OleDbCommand
      Dim Cm2 As New OleDb.OleDbCommand
      Dim Drd As OleDb.OleDbDataReader
      '
      Dim TablaC As String = IIf(CmpInt = "PC" Or CmpInt = "OP", "Compras", "CompraOtr")
      '
      Dim nRen As Integer
      Dim CmpCaja As String
      Dim DetCaja As String = ""
      '
      Dim OPTrID As Int32
      Dim Banco As Int16
      Dim Cuenta As String
      Dim Numero As Long
      Dim TMovTr As Byte
      '
      Dim CtaBanco As String
      Dim cBanco As String
      Dim TMovCh As Byte
      Dim Imput As String = ""
      '
      Dim CodAsi As String
      Dim NroAsi As Long
      Dim RenASi As Integer
      Dim DetAsi As String
      '
      Dim CtaCaja As String = ""
      Dim CtaProv As String = ""
      Dim CtaVCar As String = ""
      Dim DescVCar As String = ""
      '
      Dim fPago As String
      Dim nRenCh As Integer
      Dim OPNumero As Long
      Dim nContFp As Integer
      '
      '* Const EstGEN = 0
      '* Const EstAUT = 1
      '* Const EstCONF = 2
      '* Const EstPAGO = 3
      '* Const EstREND = 4
      '* Const EstANUL = 5
      '* Const EstAGRUP = 6
      Const EstEMIT = 1
      '
      If SisContable Then
         '
         If Proveedor = 0 Then
            CtaProv = cfgCtaProvVarios
         Else
            CtaProv = CapturaDato(Cn, "Proveedores", "Cuenta", "Codigo = " & Proveedor)
         End If
         '
         If CtaProv = "" Then
            MensajeTrad("CtaProvNoAsig")
            Return False
         End If
         '
         If Not CaptCtasCaja(Caja, CtaCaja) Then
            Return False
         End If
         '
         If Not CaptCtasConc(cfgCodigoVCar, DescVCar, "", CtaVCar) Then
            Return False
         End If
         '
      End If
      '
      If Cheques <> 0 Then
         '
         TMovCh = Val(CapturaDato(Cn, "TipoMovBco", "TipoMovBco", "TipoMov = 'CH'") & "")
         Imput = CapturaDato(Cn, "TipoMovBco", "Imput", "TipoMov = 'CH'") & ""
         '
         If TMovCh = 0 Or Imput = "" Then
            MensajeTrad("TMovCHNoDef")
            Return False
         End If
         '
      End If
      '
      If Transf <> 0 Then
         '
         TMovTr = Val(CapturaDato(Cn, "TipoMovBco", "TipoMovBco", "TipoMov = 'TR'") & "")
         '
         If TMovTr = 0 Then
            MensajeTrad("TMovTrNoDef")
            Return False
         End If
         '
      End If
      '
      Try
         '
         Trn = Cn.BeginTransaction
         '
         If Alta Then
            BuscarCfg(cfgNroPago, "cfgNroPago", Trn)
            OPNumero = cfgNroPago + 1
            GuardarCfg(cfgNroPago, "cfgNroPago", OPNumero, Trn)
         End If
         '
         CmpCaja = CmpInt & "-" & OPNumero
         CodAsi = CmpCaja
         DetAsi = CapturaDato(Cn, "Proveedores", "Nombre", "Codigo = " & Proveedor, , , , Trn) & ""
         '
         With Cmd
            .Connection = Cn
            .Transaction = Trn
            If Alta Then
               .CommandText = "INSERT INTO OrdenPago( Sucursal, OPNumero, OPTipo, OPFecha, Proveedor, OPTotal, OpEfectivo, OpCheques, OpTransf, OPDetalle, Estado, OPUid, OPFecMod) " & _
                              "VALUES(" & prmSucursal & ", " & _
                                          OPNumero & ", " & _
                                    "'" & CmpInt & "', " & _
                                    "'" & Format(Fecha, FormatFecha) & "', " & _
                                          Proveedor & ", " & _
                                          Total & ", " & _
                                          IIf(Estado >= 2, Efectivo, 0) & ", " & _
                                          IIf(Estado >= 2, Cheques, 0) & ", " & _
                                          IIf(Estado >= 2, Transf, 0) & ", " & _
                                    "'" & Detalle & "', " & _
                                          Estado & ", " & _
                                    "'" & Uid & "', " & _
                                    "'" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
               OrdenPagoId = CapturaDato(Cn, "OrdenPago", "MAX(OrdenPagoId)", "", , , , Trn)
            Else
               .CommandText = "UPDATE OrdenPago SET " & _
                              " OPFecha = '" & Format(Fecha, FormatFecha) & "', " & _
                              " OPFecPago = '" & Format(Today, FormatFecha) & "', " & _
                              " OPTotal = " & Total & ", " & _
                              " OPEfectivo = " & IIf(Estado >= 2, Efectivo, 0) & ", " & _
                              " OPCheques = " & IIf(Estado >= 2, Cheques, 0) & ", " & _
                              " OPTransf = " & IIf(Estado >= 2, Transf, 0) & ", " & _
                              " OPDetalle = '" & Detalle & "', " & _
                              " Estado = " & Estado & ", " & _
                              " OPUid = '" & Uid & "', " & _
                              " OPFecMod = '" & Format(Now, FormatFechaHora) & "' " & _
                              "WHERE OrdenPagoID = " & OrdenPagoId
               .ExecuteNonQuery()
            End If
            '
            If TmpCmp <> "" Then
               .CommandText = "DELETE FROM OrdenPagoDet WHERE OrdenPagoID = " & OrdenPagoId
               .ExecuteNonQuery()
               '
               .CommandText = "INSERT INTO OrdenPagoDet( OrdenPagoId, Proveedor, ProComprob, ProSucursal, ProNumero, OPDUid, OPDFecMod) " & _
                              "SELECT " & OrdenPagoId & ", Proveedor, Comprob, Sucursal, Numero, '" & Uid & "', '" & Format(Now, FormatFechaHora) & "' " & _
                              "FROM " & TmpCmp
               .ExecuteNonQuery()
               '
               .CommandText = "UPDATE " & TablaC & " SET Pagado = 0, NroPago = 0 WHERE NroPago = " & OrdenPagoId
               .ExecuteNonQuery()
               '
               .CommandText = ("UPDATE " & TablaC & " SET " & _
                               " Pagado = 1, " & _
                               " NroPago = " & OrdenPagoId & ", " & _
                               " Usuario = '" & Uid & "', " & _
                               " FechaMod = '" & Format(Now, FormatFechaHora) & "' " & _
                               "WHERE EXISTS( SELECT * FROM " & TmpCmp & " " & _
                                             "WHERE Proveedor = " & TablaC & ".Proveedor" & _
                                             "  AND Comprob = " & TablaC & ".Comprob" & _
                                             "  AND Sucursal = " & TablaC & ".Sucursal" & _
                                             "  AND Numero = " & TablaC & ".Numero)")
               .ExecuteNonQuery()
            End If
            '
         End With
         '
         If SisContable Then
            NroAsi = GuardaAsiento(CmpCaja, Today, DetAsi, Trn)
            BorraAsienDet(NroAsi, Trn)
            '
            RenASi = RenASi + 1
            If Not GuardaAsienDet(NroAsi, RenASi, CtaProv, DetAsi, Total, 0, Trn) Then
               Err.Raise(1001, , "NoUpAsiDet")
            End If
         End If
         '
         If Efectivo > 0 Then
            fPago = "EF"
            nContFp = 1
            Do While Not IsNothing(CapturaDato(Cn, "Caja", "Comprob", "Comprob = '" & CmpCaja & "' AND FPago = '" & fPago & "'", , , , Trn))
               nContFp = nContFp + 1
               fPago = "EF" & nContFp
            Loop
            '
            GuardarCaja(True, False, CmpInt, Caja, False, 0, Efectivo, fPago, Today, Recibe, DetCaja, CtaProv, 0, CtaCaja, Trn, CmpCaja)
            '
            If SisContable Then
               RenASi = RenASi + 1
               GuardaAsienDet(NroAsi, RenASi, CtaCaja, Detalle, 0, Efectivo, Trn)
            End If
         End If
         '
         If Cheques > 0 Then
            '
            With Cmd
               '
               .CommandText = "INSERT INTO OrdenPagoCH( OrdenPagoId, OPCRenglon, Origen, Banco, Cuenta, Numero, OPCUid, OPCFecMod) " & _
                              "SELECT " & OrdenPagoId & ", Renglon, Origen, Banco, Cuenta, Numero, '" & Uid & "', '" & Format(Now, FormatFechaHora) & "' " & _
                              "FROM " & TmpChs
               .ExecuteNonQuery()
               '
               .CommandText = "SELECT * FROM " & TmpChs
               Drd = .ExecuteReader
               '
            End With
            '
            With Drd
               Do While .Read
                  nRen = nRen + 1
                  '
                  cBanco = CapturaDato(Cn, "Bancos", "Nombre", "Codigo = " & !Banco, , , , Trn) & ""
                  '
                  If !Origen = "C" Then
                     nRenCh = 1
                     fPago = "CH"
                     Do While Not IsNothing(CapturaDato(Cn, "Caja", "Comprob", "Comprob = '" & CmpCaja & "' AND FPago = '" & fPago & "'", , , , Trn))
                        nRenCh = nRenCh + 1
                        fPago = "CH" & nRenCh
                     Loop
                     DetCaja = "CH. " & cBanco & " CTA:" & !Cuenta & ", Nº" & !Numero & ", Al:" & !Fecha
                     '
                     If Not ActCaja(Caja, CmpCaja, fPago, Today, Recibe, "", DetCaja, 0, !Importe) Then
                        Err.Raise(1001)
                     End If
                     '
                  End If
                  '
                  'Detalle Asiento (Banco/Ch.Cartera).
                  If SisContable Then
                     '
                     CtaBanco = CapturaDato(Cn, "BancoCta", "CtaCont", "Banco = " & !Banco & " AND Cuenta = '" & !Cuenta & "'", , , , Trn) & ""
                     '
                     RenASi = RenASi + 1
                     If Not GuardaAsienDet(NroAsi, RenASi, IIf(!Origen = "P", CtaBanco, CtaVCar), DetAsi, 0, !Importe) Then
                        Err.Raise(1001, , Traducir("NoUpAsiento"))
                     End If
                  End If
                  '
                  Cm2.Connection = Cn
                  Cm2.Transaction = Trn
                  '
                  If !Origen = "P" Then
                     If Not IsNothing(CapturaDato(Cn, "BancosMov", "Numero", "Banco = " & !Banco & " AND Cuenta = '" & !Cuenta & "' AND Tipo = " & TMovCh & " AND Numero = " & !Numero, , , , Trn)) Then
                        Err.Raise(1001, , Traducir("MovBcoExiste"))
                     End If
                     Cm2.CommandText = "INSERT INTO BancosMov( Banco, BancoCta, TipoMovBco, NroMovBco, FechaEmi, FechaAcr, Debe, Haber, Detalle, Estado, HojaBco, Usuario, FechaMod) " & _
                                       "VALUES(" & !Banco & ", " & _
                                             "'" & !Cuenta & "', " & _
                                                   TMovCh & ", " & _
                                                   !Numero & ", " & _
                                             "'" & Format(Today, FormatFecha) & "', " & _
                                             "'" & Format(!Fecha, FormatFecha) & "', " & _
                                                   IIf(Imput = "D", !Importe, 0) & ", " & _
                                                   IIf(Imput = "H", !Importe, 0) & ", " & _
                                             "'" & CmpCaja & " - " & DetAsi & "', " & _
                                                   EstEMIT & ", " & _
                                                   0 & ", " & _
                                             "'" & Uid & "', " & _
                                             "'" & Format(Now, FormatFechaHora) & "')"
                     Cm2.ExecuteNonQuery()
                     '
                     If IsNothing(CapturaDato(Cn, "ChPropios", "ChPropNro", "Banco = " & !Banco & " AND BancoCta = '" & !Cuenta & "' AND TipoMovBco = " & TMovCh & " AND ChPropNro = '" & !Numero & "'", , , , Trn)) Then
                        Cm2.CommandText = "INSERT INTO ChPropios( Banco, BancoCta, TipoMovBco, ChPropNro, Estado, Usuario, FechaMod) " & _
                                          "VALUES( " & !Banco & ", " & _
                                                 "'" & !Cuenta & "', " & _
                                                       TMovCh & ", " & _
                                                 "'" & !Numero & "', " & _
                                                       EstEMIT & ", " & _
                                                 "'" & Uid & "', " & _
                                                 "'" & Format(Now, FormatFechaHora) & "')"
                     Else
                        Cm2.CommandText = "UPDATE ChPropios SET " & _
                                          " Estado = " & EstEMIT & ", " & _
                                          " Usuario = '" & Uid & "', " & _
                                          " FechaMod = '" & Format(Now, FormatFechaHora) & "' " & _
                                          "WHERE Banco = " & !Banco & " AND BancoCta = '" & !Cuenta & "' AND TipoMovBco = " & TMovCh & " AND ChPropNro = '" & !Numero & "'"
                     End If
                     Cm2.ExecuteNonQuery()
                     '
                  Else
                     If IsNothing(CapturaDato(Cn, "Chcartera", "Numero", "Banco = " & !Banco & " AND BancoCta = '" & !Cuenta & "' AND ChCartNro = " & !Numero, , , , Trn)) Then
                        Err.Raise(1001, , Traducir("ChNoEnc"))
                     Else
                        Cm2.CommandText = "UPDATE Chcartera SET " & _
                                         " Estado = 2, " & _
                                         " Usuario = '" & Uid & "', " & _
                                         " FechaMod = '" & Format(Now, FormatFechaHora) & "' " & _
                                         "WHERE Banco = " & !Banco & " AND BancoCta = '" & !Cuenta & "' AND ChCartNro = " & !Numero
                        Cm2.ExecuteNonQuery()
                     End If
                  End If
                  '
               Loop
               '
               .Close()
               '
            End With
         End If
         '
         If Transf > 0 Then
            With Cmd
               .CommandText = "INSERT INTO OrdenPagoTR( OrdenPagoId, Banco0, Cuenta0, Banco1, Cuenta1, Titular1, FechaTR, NumeroTR, ImporteTR, GastosImp, GastosSF, GastosIva, ImporteNeto, Usuario, FechaMod) " & _
                              "SELECT " & OrdenPagoId & ", Banco0, Cuenta0, Banco1, Cuenta1, Titular, FechaTR, NumeroTR, ImporteTR, GastosImp, GastosSF, GastosIva, ImporteNeto, '" & Uid & "', '" & Format(Now, FormatFechaHora) & "' " & _
                              "FROM " & TmpTransf
               .ExecuteNonQuery()
            End With
            '
            OPTrID = CapturaDato(Cn, "OrdenPagoTR", "MAX(OrdenPagoTrId)", "", , , , Trn)
            Banco = CapturaDato(Cn, "OrdenPagoTR", "Banco0", "OrdenPagoTrID = " & OPTrID, , , , Trn)
            Cuenta = CapturaDato(Cn, "OrdenPagoTR", "Cuenta0", "OrdenPagoTrID = " & OPTrID, , , , Trn)
            Numero = CapturaDato(Cn, "OrdenPagoTR", "NumeroTR", "OrdenPagoTrID = " & OPTrID, , , , Trn)
            '
            'Cn.Execute "UPDATE OrdenPago SET OrdenPagoTrID = " & OrdenPagoTrID & " " & _
            '        "WHERE OrdenPagoId = " & OrdenPagoId
            '
            If SisContable Then
               CtaBanco = CapturaDato(Cn, "BancoCta", "CtaCont", "Banco = " & Banco & " AND BancoCta = '" & Cuenta & "'", , , , Trn)
            End If
            '
            With Cmd
               .CommandText = "INSERT INTO BancosMov( Banco, BancoCta, TipoMovBco, NroMovBco, FechaEmi, FechaAcr, Debe, Haber, Estado, HojaBco, Detalle, Caja, Usuario, FechaMod) " & _
                              "VALUES(" & Banco & ", " & _
                                    "'" & Cuenta & "', " & _
                                          TMovTr & ", " & _
                                    "'" & Numero & "', " & _
                                    "'" & Format(Today, FormatFecha) & "', " & _
                                    "'" & Format(Today, FormatFecha) & "', " & _
                                          0 & ", " & _
                                          Transf & ", " & _
                                          0 & ", " & _
                                          0 & ", " & _
                                    "'" & "Transf. O.P. " & Numero & "', " & _
                                          prmNroCaja & ", " & _
                                    "'" & Uid & "', " & _
                                    "'" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
               '
               .CommandText = "INSERT INTO BancosMov( Banco, BancoCta, TipoMovBco, NroMovBco, FechaEmi, FechaAcr, Debe, Haber, Estado, HojaBco, Detalle, Caja, Usuario, FechaMod) " & _
                              "VALUES(" & Banco & ", " & _
                                    "'" & Cuenta & "', " & _
                                          TMovTr & ", " & _
                                    "'" & Numero & "', " & _
                                    "'" & Format(Today, FormatFecha) & "', " & _
                                    "'" & Format(Today, FormatFecha) & "', " & _
                                          0 & ", " & _
                                          GtosBanc & ", " & _
                                          0 & ", " & _
                                          0 & ", " & _
                                    "'" & "Gastos O.P. " & Numero & "', " & _
                                          prmNroCaja & ", " & _
                                    "'" & Uid & "', " & _
                                    "'" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
               '
            End With
         End If
         '
         GuardarAudit(IIf(PagoDir, "Pago Directo", IIf(Estado = 2, "Guarda", IIf(Estado = 3, "Paga", "Rinde")) & " Orden de Pago"), CmpCaja, "ModPol", "GuardarOrdenPago", Trn)
         '
         Trn.Commit()
         '
         Return True
         '
      Catch ex As System.Exception
         '
         Dim st As New StackTrace(True)
         RegistrarError(st, "GuardarOrdenPago")
         '
      End Try
      '
   End Function
   '
   Function AnularCobro(cmpInt As String, Tipo As String, Sucursal As Integer, Numero As Long, CobroComp As Boolean) As Boolean
      '
      Dim Trn As OleDb.OleDbTransaction
      Dim Cmd As New OleDb.OleDbCommand
      Dim Cm2 As New OleDb.OleDbCommand
      Dim Drd As OleDb.OleDbDataReader
      '
      Dim Comprob As String
      'Dim Caja As Integer
      Dim CacId As Long
      Dim CobroId As Int32
      Dim ImpCobro As Double
      'Dim Banco As Integer
      'Dim CtaBco As String
      'Dim NroCheque As String
      Dim TipoMovBco As Byte = 0
      '
      Comprob = cmpInt & "-" & Tipo & "-" & Sucursal & "-" & Numero
      '
      If Not LGR Then
         Exit Function
      End If
      '
      CobroId = CapturaDato(Cn, IIf(CobroComp, "Cobros", "CobrosOtr"), IIf(CobroComp, "CobroId", "CobroOtrId"), "Tipo = '" & Tipo & "' AND Sucursal = " & Sucursal & " AND Numero = " & Numero) & ""
      '
      Trn = Cn.BeginTransaction
      '
      Try
         '
         Cm2.Connection = Cn
         Cm2.Transaction = Trn
         '
         With Cmd
            .Connection = Cn
            .Transaction = Trn
            .CommandText = "UPDATE " & IIf(CobroComp, "Cobros", "CobrosOtr") & " SET " & _
                           " Subtotal = 0, " & _
                           " Total = 0, " & _
                           " Efectivo = 0, " & _
                           " Cheques = 0, " & _
                           " Banco = 0, " & _
                           " CtaBco = '', " & _
                           " NroCheque = 0, " & _
                           " FecCheque = NULL, " & _
                           " Detalle = '" & Traducir("Anulado", , Trn) & "', " & _
                           " Estado = 2, " & _
                           IIf(CobroComp, "CobTransf", "CooTransf") & " = 0, " & _
                           " Usuario = '" & Uid & "', " & _
                           " FechaMod = '" & Format(Now, FormatFechaHora) & "' " & _
                           "WHERE Tipo = '" & Tipo & "' AND Sucursal = " & Sucursal & " AND Numero = " & Numero
            .ExecuteNonQuery()
            '
            If CobroComp Then
               .CommandText = "UPDATE Ventas SET " & _
                              " Estado = 0, " & _
                              " NroCobro = 0, " & _
                              " Usuario = '" & Uid & "', " & _
                              " FechaMod = '" & Now & "' " & _
                              "WHERE EXISTS( SELECT NULL FROM " & IIf(CobroComp, "CobrosDet", "CobOtrDet") & " " & _
                                           " WHERE Tipo = '" & Tipo & "'" & _
                                           "   AND Sucursal = " & Sucursal & _
                                           "   AND Numero = " & Numero & _
                                           "   AND CliTipo = Ventas.Tipo " & _
                                           "   AND CliSucursal = Ventas.Sucursal " & _
                                           "   AND CliNumero = Ventas.Numero)"
               .ExecuteNonQuery()
            End If
            '
            .CommandText = "DELETE FROM " & IIf(CobroComp, "CobrosDet", "CobOtrDet") & " " & _
                           "WHERE Tipo = '" & Tipo & "'" & _
                           "  AND Sucursal = " & Sucursal & _
                           "  AND Numero = " & Numero
            .ExecuteNonQuery()
            '
            If CobroComp Then
               '*** Ver CobrosCh ***
               '*** Ver CobrosTR ***
            Else
               '
               If Not IsNothing(CapturaDato(Cn, "ChCartera", "Estado", "Estado <> 0 AND EXISTS( SELECT NULL FROM CobrosOtrCh WHERE CobroOtrId = " & CobroId & " AND Banco = ChCartera.Banco AND CuentaBco = ChCartera.BancoCta AND Numero = ChCartera.ChCartNro)", , , , Trn)) Then
                  Err.Raise(1001, , "Un Cheque no está en cartera")
               End If
               '
               .CommandText = "DELETE FROM ChCartera WHERE EXISTS( SELECT NULL FROM CobrosOtrCh " & _
                                                                 " WHERE CobroOtrId = " & CobroId & _
                                                                 "  AND Banco = ChCartera.Banco" & _
                                                                 "  AND CuentaBco = ChCartera.BancoCta" & _
                                                                 "  AND Numero = ChCartera.ChCartNro) "
               .ExecuteNonQuery()
               '
               .CommandText = "DELETE FROM CobrosOtrCh WHERE CobroOtrId = " & CobroId
               .ExecuteNonQuery()
               '
               TipoMovBco = Val(CapturaDato(Cn, "TipoMovBco", "TipoMovBco", "TipoMov = 'TR'", , , , Trn) & "")
               If TipoMovBco = 0 Then
                  Err.Raise(1001, "AnularCobro", "TipoTrNoDef")
               End If
               '
               .CommandText = "DELETE FROM BancosMov WHERE EXISTS( SELECT NULL FROM CobrosOtrTR " & _
                                                                 " WHERE CobroOtrID = " & CobroId & _
                                                                 "  AND Banco1 = BancosMov.Banco " & _
                                                                 "  AND Cuenta1 = BancosMov.BancoCta " & _
                                                                 "  AND NumeroTr = BancosMov.NroMovBco)"
               .ExecuteNonQuery()
               '
               .CommandText = "DELETE FROM CobrosOtrTR WHERE CobroOtrID = " & CobroId
               .ExecuteNonQuery()
               '
            End If
            '
            If CacId > 0 Then
               '
               .CommandText = "UPDATE ComACob SET CacSaldo = CacSaldo + " & ImpCobro & " WHERE CacId = " & CacId
               .ExecuteNonQuery()
               '
               .CommandText = "SELECT * FROM ComACobDet WHERE CacId = " & CacId & " AND CadSaldo <> CadImporte ORDER BY CadCuota DESC"
               Drd = .ExecuteReader
               '
               With Drd
                  '
                  Do While .Read
                     '
                     'CadCuota = !CadCuota
                     '
                     If ImpCobro >= !CadImporte Then
                        ImpCobro = ImpCobro - (!CadImporte - !CadSaldo)
                        Cm2.CommandText = "UPDATE ComACobDet SET " & _
                                          " CadSaldo = " & !CadImporte & ", " & _
                                          " CadUsuario = '" & Uid & "', " & _
                                          " CadFecMod = '" & Format(Now, FormatFechaHora) & "' " & _
                                          "WHERE CacId = " & CacId & " AND CadCuota = " & !CadCuota
                        Cm2.ExecuteNonQuery()
                     Else
                        If ImpCobro >= (!CadImporte - !CadSaldo) Then
                           ImpCobro = ImpCobro - (!CadImporte - !CadSaldo)
                           Cm2.CommandText = "UPDATE ComACobDet SET " & _
                                             " CadSaldo = " & !CadImporte & ", " & _
                                             " CadUsuario = '" & Uid & "', " & _
                                             " CadFecMod = '" & Format(Now, FormatFechaHora) & "' " & _
                                             "WHERE CacId = " & CacId & " AND CadCuota = " & !CadCuota
                           Cm2.ExecuteNonQuery()
                        Else
                           Cm2.CommandText = "UPDATE ComACobDet SET " & _
                                             " CadSaldo = CadSaldo + " & !ImpCobro & ", " & _
                                             " CadUsuario = '" & Uid & "', " & _
                                             " CadFecMod = '" & Format(Now, FormatFechaHora) & "' " & _
                                             "WHERE CacId = " & CacId & " AND CadCuota = " & !CadCuota
                           Cm2.ExecuteNonQuery()
                           ImpCobro = 0
                        End If
                     End If
                     '                 
                     If ImpCobro = 0 Then
                        Exit Do
                     End If
                     '
                  Loop
                  .Close()
               End With
               '
            End If
            '
         End With
         '
         If Not BajaCaja(Comprob, , Trn) Then
            Err.Raise(1001, "AnularCobro", "No Baja Caja")
         End If
         '
         If Not BorraAsiento(Comprob, Trn) Then
            Err.Raise(1001, "AnularCobro", "No Borra Asiento")
         End If
         '
         GuardarAudit("Anula Cobro", Comprob, "Cobros Otros", "Anular", Trn)
         '
         Trn.Commit()
         '
         Return True
         '
      Catch ex As System.Exception
         Dim st As New StackTrace(True)
         RegistrarError(st, "AnularCobro")
         Trn.Rollback()
      End Try
      '
   End Function
   '
   Function SqlProyAdel(Propietario As Int32, Propiedad As Int32, Periodo As String) As String
      '
      Dim UltFecha As Date = UltDiaMes("01/" & Periodo.Substring(4, 2) & "/" & Periodo.Substring(0, 4))
      '
      Dim SqlFID As String = "SELECT F.Fecha, F.Concepto, P.Domicilio AS Propiedad, F.Detalle, I.Nombre, F.Importe, F.Saldo " & _
                             "FROM FactInq F, Inquilinos I, Propiedades P " & _
                             "WHERE F.Imputacion = 'D' AND F.Inquilino = I.Codigo " & _
                             "  AND F.Propiedad = P.Codigo " & _
                             "  AND Propiedad " & IIf(Propiedad = 0, "IN( SELECT Codigo FROM Propiedades WHERE Propietario = " & Propietario & ")", "= " & Propiedad) & _
                             "  AND Periodo <= '" & Periodo & "' AND Saldo <> 0 AND aPropiet <> 0 "
      '
      Dim SqlFIH As String = "SELECT F.Fecha, F.Concepto, P.Domicilio AS Propiedad, F.Detalle, I.Nombre, -F.Importe, -F.Saldo " & _
                             "FROM FactInq F, Inquilinos I, Propiedades P  " & _
                             "WHERE F.Imputacion = 'H' AND F.Inquilino = I.Codigo " & _
                             "  AND F.Propiedad = P.Codigo " & _
                             "  AND Propiedad " & IIf(Propiedad = 0, "IN( SELECT Codigo FROM Propiedades WHERE Propietario = " & Propietario & ")", "= " & Propiedad) & _
                             "  AND Periodo <= '" & Periodo & "' AND Saldo <> 0 AND aPropiet <> 0 "
      '
      Dim SqlLPA As String = "SELECT C.Fecha, D.Concepto, P.Domicilio AS Propiedad, D.Detalle, '' AS Nombre, (D.Importe * -1), (D.Importe * -1) " & _
                             "FROM LiqPropiet C INNER JOIN LiqInqDet D ON C.Numero = D.Numero AND D.Tipo = 'L'" & _
                             " LEFT JOIN Propiedades P ON C.Propiedad = P.Codigo " & _
                             "WHERE C.Propietario = " & Propietario & _
                             "  AND D.aPropiet <> 0 AND D.LiqPropiet = 0 " & _
                             "  AND C.Periodo <= '" & Periodo & "'" & _
                             "  AND Imputacion = 'H' " & _
                             IIf(Propiedad = 0, "", " AND C.Propiedad = " & Propiedad & " ") & _
                             " UNION " & _
                             "SELECT C.Fecha, D.Concepto, P.Domicilio AS Propiedad, D.Detalle, '' AS Nombre, (D.Importe), (D.Importe) " & _
                             "FROM LiqPropiet C INNER JOIN LiqInqDet D ON C.Numero = D.Numero AND D.Tipo = 'L'" & _
                             " LEFT JOIN Propiedades P ON C.Propiedad = P.Codigo " & _
                             "WHERE C.Propietario = " & Propietario & _
                             "  AND D.aPropiet <> 0 AND D.LiqPropiet = 0 " & _
                             "  AND C.Periodo <= '" & Periodo & "'" & _
                             "  AND Imputacion = 'D' " & _
                             IIf(Propiedad = 0, "", " AND C.Propiedad = " & Propiedad)
      '
      Dim cSql As String = SqlFID & "UNION " & SqlFIH & " UNION " & SqlLPA & " UNION " & _
                           "SELECT C.Fecha, D.Concepto, P.Domicilio AS Propiedad, D.Detalle, C.Nombre, D.Importe, D.Importe " & _
                           "FROM CobrosOtr C INNER JOIN CobOtrDet D ON C.Tipo = D.Tipo AND C.Sucursal = D.Sucursal AND C.Numero = D.Numero " & _
                           " LEFT JOIN Propiedades P ON C.Propiedad = P.Codigo " & _
                           "WHERE C.Propietario = " & Propietario & " AND C.LiqPropiet = 0" & _
                           "  AND C.Fecha <= " & strFEC & Format(UltFecha, FormatFecha) & strFEC & _
                           "  AND D.aPropiet <> 0 " & _
                           IIf(Propiedad = 0, "", " AND C.Propiedad = " & Propiedad & " ") & _
                           "UNION " & _
                           "SELECT C.Fecha, D.Concepto, P.Domicilio AS Propiedad, D.Detalle, C.Nombre, (D.Importe * -1), (D.Importe * -1) " & _
                           "FROM CompraOtr C INNER JOIN CompraOtrDet D ON C.Proveedor = D.Proveedor AND C.Comprob = D.Comprob AND C.Sucursal = D.Sucursal AND C.Numero = D.Numero " & _
                           " LEFT JOIN Propiedades P ON C.Propiedad = P.Codigo " & _
                           "WHERE C.Propietario = " & Propietario & " " & _
                           IIf(Propiedad = 0, "", "  AND C.Propiedad = " & Propiedad) & _
                           " AND D.aPropiet <> 0 AND C.LiqPropiet = 0 " & _
                           " AND C.Fecha <= " & strFEC & Format(UltFecha, FormatFecha) & strFEC & _
                           IIf(Propiedad = 0, "", " AND C.Propiedad = " & Propiedad & " ") & _
                           "ORDER BY Fecha, Concepto"
      '
      Return cSql
      '
   End Function
   '
   Function GuardarIngreso(ByVal IngresoId As Long, ByVal Proveedor As Long, ByVal RtoSucursal As Integer, ByVal RtoNumero As Long, _
                           ByVal FechaIng As Date, ByVal FechaRto As Date, ByVal Detalle As String, ByVal TablaTmp As String, _
                           ByVal IniTrans As Boolean, Optional ByVal Auto As Boolean = False, Optional ByVal EmpresaId As Int16 = 0, _
                           Optional ByVal Pide_ActCosto As Boolean = True, Optional ByVal Densidad As Single = 1, Optional ByVal Tr As Object = "") As Long
      '
      Dim Rs As New OleDb.OleDbCommand
      Dim SelIngDet As String = ""
      Dim SelCosto As String = ""
      Dim SelPartidas As String = ""
      Dim ActCosto As MsgBoxResult
      '
      SelPartidas = "SELECT Cantidad FROM Partidas " & _
                    "WHERE EmpresaId = I.EmpresaId " & _
                    "  AND Sucursal = I.Sucursal " & _
                    "  AND Departamento = I.Departamento " & _
                    IIf(cfgSolPartida, " AND Proveedor = I.Proveedor ", "") & _
                    "  AND Producto = D.Producto " & _
                    IIf(cfgSolPartida, " AND Partida = D.Partida ", "")
      '
      If Pide_ActCosto Then
         If cfgActCosto Then
            ActCosto = vbYes
         Else
            ActCosto = MsgBox("Actualiza Costos y Precios de Productos", vbQuestion + vbYesNo)
         End If
      End If
      '
      If IniTrans Then
         Tr = cn.BeginTransaction
      End If
      '
      With Rs
         .Connection = cn
         If Tr.ToString <> "" Then
            .Transaction = Tr
         End If
         '
         If IngresoId = 0 Then
            '
            .CommandText = "INSERT INTO Ingresos( EmpresaId, Sucursal, Departamento, Proveedor, RtoSucursal, RtoNumero, FechaIng, FechaRto, Detalle, Estado, Auto, Usuario, FechaMod) " & _
                           "VALUES(" & EmpresaId & ", " & _
                                       prmSucursal & ", " & _
                                       prmDepart & ", " & _
                                       Proveedor & ", " & _
                                       RtoSucursal & ", " & _
                                       RtoNumero & ", " & _
                                 "'" & Format(FechaIng, FormatFecha) & "', " & _
                                 "'" & Format(FechaRto, FormatFecha) & "', " & _
                                 "'" & Detalle & "', " & _
                                       0 & ", " & _
                                       IIf(Auto, 1, 0) & ", " & _
                                 "'" & Uid & "', " & _
                                 "'" & Format(Now, FormatFechaHora) & "')"
            .ExecuteNonQuery()
            IngresoId = CapturaDato(cn, "Ingresos", "MAX(IngresoId)", "", , , , Tr)
            '
            ArmaSel(SelIngDet, SelCosto, IngresoId)
         Else
            '(Modif).
            ArmaSel(SelIngDet, SelCosto, IngresoId)
            .CommandText = "UPDATE Ingresos SET " & _
                           " FechaIng = '" & Format(FechaIng, FormatFecha) & "', " & _
                           " FechaRto = '" & Format(FechaRto, FormatFecha) & "', " & _
                           " Detalle = '" & Detalle & "', " & _
                           " Usuario = '" & Uid & "', " & _
                           " FechaMod = '" & Format(Now, FormatFechaHora) & "' " & _
                           "WHERE IngresoID = " & IngresoId
            .ExecuteNonQuery()
            '
            .CommandText = "UPDATE Partidas SET " & _
                           " Saldo = Saldo - (" & SelIngDet & "), " & _
                           " Cantidad = Cantidad - (" & SelIngDet & "), " & _
                           " Usuario = '" & Uid & "', " & _
                           " FechaMod = '" & Format(Now, FormatFechaHora) & "' " & _
                           "WHERE EmpresaID = " & EmpresaId & _
                           "  AND Sucursal = " & prmSucursal & _
                           "  AND Departamento = " & prmDepart & _
                           IIf(cfgSolPartida, " AND Proveedor = " & Proveedor, "") & _
                           "  AND EXISTS (" & SelIngDet & ")"
            .ExecuteNonQuery()
            '
            .CommandText = "UPDATE Stock SET " & _
                       " Cantidad = Cantidad - (SELECT SUM(D.Cantidad) AS Cant FROM Ingresos I, IngresosDet D " & _
                       "                        WHERE I.IngresoID = " & IngresoId & _
                       "                          AND I.IngresoID = D.IngresoID " & _
                       "                          AND D.Producto = Stock.Producto " & _
                       "                        GROUP BY D.Producto), " & _
                       " CantDisp = CantDisp - (SELECT SUM(D.Cantidad) AS Cant FROM Ingresos I, IngresosDet D " & _
                       "                        WHERE I.IngresoID = " & IngresoId & _
                       "                          AND I.IngresoID = D.IngresoID " & _
                       "                          AND D.Producto = Stock.Producto " & _
                       "                        GROUP BY D.Producto), " & _
                       " Usuario   = '" & Uid & "', " & _
                       " FechaMod  = '" & Format(Now, FormatFechaHora) & "' " & _
                       "WHERE Stock.EmpresaId = " & EmpresaId & _
                       "  AND Stock.Sucursal = " & prmSucursal & _
                       "  AND Stock.Departamento = " & prmDepart & _
                       "  AND Producto IN( SELECT D.Producto FROM Ingresos I, IngresosDet D " & _
                       "                   WHERE I.IngresoID = " & IngresoId & _
                       "                     AND I.IngresoID = D.IngresoID " & _
                       "                   GROUP BY Producto )"
            .ExecuteNonQuery()
            '
            .CommandText = "DELETE FROM IngresosDet " & _
                           "WHERE IngresoID = " & IngresoId
            .ExecuteNonQuery()
            '
         End If
         '
         .CommandText = "INSERT INTO IngresosDet( IngresoID, RtoRenglon, Producto, Concepto, Detalle, Cantidad, Saldo, Costo, Bonificacion, SubTotal, Partida, FechaVenc, AlicuoIva, Usuario, FechaMod) " & _
                        "SELECT " & IngresoId & ", " & _
                        " Renglon, Producto, Concepto, Detalle, Cantidad, Cantidad, Costo, Bonificacion, SubTotal, Partida, FechaVenc, AlicuoIva, " & _
                        "'" & Uid & "' AS Usuario, " & _
                        "'" & Format(Now, FormatFechaHora) & "' AS FechaMod " & _
                        "FROM " & TablaTmp & " WHERE Producto <> 0"
         .ExecuteNonQuery()
         '
         .CommandText = "UPDATE Partidas SET " & _
                        " Saldo = Saldo + (" & SelIngDet & "), " & _
                        " Cantidad = Cantidad + (" & SelIngDet & "), " & _
                        " Costo = (" & SelCosto & "), " & _
                        " Usuario = '" & Uid & "', " & _
                        " FechaMod = '" & Format(Now, FormatFechaHora) & "' " & _
                        "WHERE EmpresaId = " & EmpresaId & _
                        "  AND Sucursal = " & prmSucursal & _
                        "  AND Departamento = " & prmDepart & _
                        IIf(cfgSolPartida, " AND Proveedor = " & Proveedor, "") & _
                        "  AND EXISTS (" & SelIngDet & ")"
         .ExecuteNonQuery()
         '
         .CommandText = "INSERT INTO Partidas( EmpresaId, Sucursal, Departamento, Proveedor, Partida, Producto, FechaVenc, Costo, Cantidad, Saldo, Usuario, FechaMod) " & _
                        "SELECT I.EmpresaId, I.Sucursal, I.Departamento, " & IIf(cfgSolPartida, "I.Proveedor, D.Partida", "0, ''") & ", D.Producto, MAX(D.FechaVenc), MAX(D.Costo), SUM(D.Cantidad), SUM(D.Cantidad), " & _
                        " '" & Uid & "', '" & Format(Now, FormatFechaHora) & "' AS FechaMod " & _
                        "FROM Ingresos I, IngresosDet D " & _
                        "WHERE I.IngresoID = " & IngresoId & _
                        "  AND I.IngresoID = D.IngresoID " & _
                        "  AND NOT EXISTS(" & SelPartidas & ") " & _
                        "GROUP BY I.EmpresaID, I.Sucursal, I.Departamento, " & IIf(cfgSolPartida, "I.Proveedor, D.Partida, ", "") & "D.Producto"
         .ExecuteNonQuery()
         '
         .CommandText = "UPDATE Stock SET " & _
                        " Cantidad = Cantidad + (SELECT SUM(Cantidad) FROM " & TablaTmp & _
                                               " WHERE Producto = Stock.Producto " & _
                                               " GROUP BY Producto), " & _
                        " CantDisp = CantDisp + (SELECT SUM(Cantidad) FROM " & TablaTmp & _
                                               " WHERE Producto = Stock.Producto " & _
                                               " GROUP BY Producto), " & _
                        " Usuario   = '" & Uid & "', " & _
                        " FechaMod  = '" & Format(Now, FormatFechaHora) & "' " & _
                        "WHERE EmpresaId = " & EmpresaId & _
                        "  AND Sucursal = " & prmSucursal & _
                        "  AND Departamento = " & prmDepart & _
                        "  AND Producto IN( SELECT Producto FROM " & TablaTmp & " " & _
                        "GROUP BY Producto)"
         .ExecuteNonQuery()
         '
         .CommandText = "INSERT INTO Stock( EmpresaId, Sucursal, Departamento, Producto, Cantidad, CantDisp, Usuario, FechaMod) " & _
                        "SELECT " & EmpresaId & ", " & _
                                    prmSucursal & ", " & _
                                    prmDepart & ", " & _
                                   "Producto, SUM(Cantidad), SUM(Cantidad), " & _
                                   "'" & Uid & "' AS Usuario, " & _
                                   "'" & Format(Now, FormatFechaHora) & "' AS FechaMod " & _
                        "FROM " & TablaTmp & " " & _
                        "WHERE Producto NOT IN( SELECT Producto FROM Stock " & _
                                               "WHERE EmpresaId = " & EmpresaId & _
                                               "  AND Sucursal = " & prmSucursal & _
                                               "  AND Departamento = " & prmDepart & ") " & _
                        "GROUP BY Producto"
         .ExecuteNonQuery()
         '
         If ActCosto Then
            .CommandText = "UPDATE Productos SET " & _
                           " Costo = (SELECT MAX(Costo) FROM " & TablaTmp & " WHERE Producto = Productos.Producto), " & _
                           " Proveedor = " & Proveedor & ", " & _
                           " Usuario = '" & Uid & "', " & _
                           " FechaMod = '" & Format(Now, FormatFechaHora) & "' " & _
                           "WHERE Producto IN( SELECT Producto FROM " & TablaTmp & _
                                             " WHERE Costo <> 0)"
            .ExecuteNonQuery()
         End If
         '
      End With

      If IniTrans Then
         Tr.Commit()
      End If
      '
      Return IngresoId
      '
   End Function
   '
   Sub ArmaSel(ByRef SelIngDet, ByRef SelCosto, ByVal IngresoId)
      '
      Dim cGroup As String
      If cfgSolPartida Then
         cGroup = "I.Proveedor, D.Producto, D.Partida"
      Else
         cGroup = "D.Producto"
      End If
      SelIngDet = "SELECT SUM(Cantidad) FROM Ingresos I, IngresosDet D " & _
                  "WHERE I.EmpresaId = Partidas.EmpresaId " & _
                  "  AND I.Sucursal = Partidas.Sucursal " & _
                  "  AND I.Departamento = Partidas.Departamento " & _
                  IIf(cfgSolPartida, "  AND I.Proveedor = Partidas.Proveedor ", "") & _
                  "  AND I.IngresoID = " & IngresoId & _
                  "  AND I.IngresoID = D.IngresoID " & _
                  "  AND D.Producto = Partidas.Producto " & _
                  IIf(cfgSolPartida, "  AND D.Partida = Partidas.Partida ", "") & _
                  "GROUP BY " & cGroup
      '
      SelCosto = "SELECT MAX(Costo) FROM Ingresos I, IngresosDet D " & _
                 "WHERE I.EmpresaId = Partidas.EmpresaId " & _
                 "  AND I.Sucursal = Partidas.Sucursal " & _
                 "  AND I.Departamento = Partidas.Departamento " & _
                 IIf(cfgSolPartida, "  AND I.Proveedor = Partidas.Proveedor ", "") & _
                 "  AND I.IngresoID = " & IngresoId & _
                 "  AND I.IngresoID = D.IngresoID " & _
                 "  AND D.Producto = Partidas.Producto " & _
                 IIf(cfgSolPartida, "  AND D.Partida = Partidas.Partida ", "") & _
                 "GROUP BY " & cGroup
      '
   End Sub
   '
   Function GuardarPago(ByVal PagoID As Long, ByVal Sucursal As Integer, ByVal RboNumero As Long, ByVal TipoComp As Integer, _
                        ByVal Fecha As Date, ByVal Proveedor As Long, ByVal Total As Double, ByVal Efectivo As Double, ByVal ImpCheque As Double, _
                        ByVal Detalle As String, ByVal Caja As Integer, ByVal CtaCaja As String, ByVal Moneda As Integer, ByVal TablaCmp As String, _
                        ByVal TablaCh As String, ByVal IniTrans As Boolean, Optional ByVal Auto As Boolean = False, Optional ByVal Nombre As String = "", _
                        Optional ByVal Pagado As Boolean = True, Optional ByVal PagoPedido As Boolean = False, Optional ByVal Bonificacion As Single = 0, _
                        Optional ByVal Conn As Object = "", Optional ByVal EmpresaId As Int16 = 0, Optional ByVal Tr As Object = "") As Boolean
      '
      Dim Rs As New OleDb.OleDbCommand
      Dim Rs2 As New OleDb.OleDbCommand
      Dim Rsx As New OleDb.OleDbCommand
      Dim Cmd As New OleDb.OleDbCommand
      Dim DR As OleDb.OleDbDataReader
      Dim DR2 As OleDb.OleDbDataReader
      '
      Dim nRen As Integer
      Dim compCaja As String
      Dim cDetCaja As String
      Dim cTipo As String
      Dim cComp As String
      '
      Dim CodAsi As String
      Dim NroAsi As Long
      Dim RenASi As Integer
      Dim DetAsi As String
      Dim cCtaProv As String = ""
      Dim cCtaConc As String = ""
      Dim CtaBanco As String = ""
      Dim CtaVCar As String
      Dim cDescConc As String
      Dim Importe As Double
      Dim Debe As Double
      Dim Haber As Double
      Dim NomProv As String
      Dim TipoMovBco As Integer
      Dim Imput As String
      Dim ChequeID As Long
      Dim ImpChCartera As Double
      Dim Saldo As Double
      Dim ImpPago As Double
      Dim TipoCompBP As Integer
      '
      Dim TablaSdo, CondSdo As String
      '
      On Error GoTo mError
      '
      If Conn.ToString <> "" Then
         Conn = Cn
      End If
      '
      If Conn.State = 0 Then
         Conn.Open()
      End If
      '
      TipoMovBco = CapturaDato(Cn, "TipoMovBco", "TipoMovBco", "TipoMov = 'CH'")
      Imput = CapturaDato(Cn, "TipoMovBco", "Imput", "TipoMov = 'CH'")
      If Bonificacion <> 0 Then
         TipoCompBP = CapturaDato(Cn, "TipoComp", "TipoComp", "CmpInt = 'BP'")
      End If
      '
      If Total <> (Efectivo + ImpCheque + Bonificacion) Then
         MensajeTrad("Tot<>ImpPago")
         Exit Function
      End If
      '
      Saldo = Total
      '
      If IniTrans Then
         Tr = Cn.BeginTransaction
      End If
      '
      With Rs
         .Transaction = Tr
         If IsNothing(CapturaDato(Cn, "Pagos", "PagoID", "PagoID = " & PagoID, , , , Tr)) Then
            .CommandText = "INSERT INTO Pagos( EmpresaId, RboSucursal, RboNumero, Fecha, Proveedor, SubTotal, Intereses, Total, Efectivo, Cheques, Bonificacion, Detalle, Caja, Moneda, Usuario, FechaMod) " & _
                           "VALUES( " & EmpresaId & ", " & _
                                        Sucursal & ", " & _
                                        RboNumero & ", " & _
                                  "'" & Fecha & "', " & _
                                        Proveedor & ", " & _
                                        Total & ", " & _
                                        0 & ", " & _
                                        Total & ", " & _
                                        Efectivo & ", " & _
                                        ImpCheque & ", " & _
                                        Bonificacion & ", " & _
                                  "'" & Detalle & "', " & _
                                        Caja & ", " & _
                                        Moneda & ", " & _
                                  "'" & Uid & "', " & _
                                  "'" & Format(Now, FormatFechaHora) & "')"
            .ExecuteNonQuery()
            PagoID = CapturaDato(Cn, "Pagos", "MAX(PagoId)", "", , , , Tr)
            '
         Else
            .CommandText = "UPDATE Pagos SET " & _
                           " EmpresaId = " & EmpresaId & ", " & _
                           " RboSucursal = " & Sucursal & ", " & _
                           " RboNumero = " & RboNumero & ", " & _
                           " Fecha = '" & Fecha & "', " & _
                           " Proveedor = " & Proveedor & ", " & _
                           " Total = " & Total & ", " & _
                           " Efectivo = " & Efectivo & ", " & _
                           " Cheques = " & ImpCheque & ", " & _
                           " Bonificacion = " & Bonificacion & ", " & _
                           " Detalle = '" & Detalle & "', " & _
                           " Caja = " & Caja & ", " & _
                           " Moneda = " & Moneda & ", " & _
                           " Usuario = '" & Uid & "', " & _
                           " FechaMod = '" & Format(Now, FormatFechaHora) & "' " & _
                           "WHERE PagoID = " & PagoID
            .ExecuteNonQuery()
         End If
         '
         If RboNumero <> 0 Then
            If IsNothing(CapturaDato(Cn, "CtaCtePro", "PagoId", "PagoID = " & PagoID, , , , Tr)) Then
               .CommandText = "INSERT INTO CtaCtePro( EmpresaId, Sucursal, Departamento, Proveedor, TipoComp, ProSucursal, ProNumero, Fecha, Debe, Haber, PagoID, Pagado, Detalle, Usuario, FechaMod) " & _
                              " VALUES( " & EmpresaId & ", " & _
                                            prmSucursal & ", " & _
                                            prmDepart & ", " & _
                                            Proveedor & ", " & _
                                            TipoComp & ", " & _
                                            Sucursal & ", " & _
                                            RboNumero & ", " & _
                                      "'" & Fecha & "', " & _
                                            0 & ", " & _
                                            Total & ", " & _
                                            PagoID & ", " & _
                                            IIf(Pagado, 1, 0) & ", " & _
                                      "'" & Detalle & "', " & _
                                      "'" & Uid & "', " & _
                                      "'" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
            Else
               .CommandText = "UPDATE CtaCtePro SET " & _
                              " EmpresaId = " & EmpresaId & ", " & _
                              " Sucursal = " & prmSucursal & ", " & _
                              " Departamento = " & prmDepart & ", " & _
                              " Proveedor = " & Proveedor & ", " & _
                              " TipoComp = " & TipoComp & ", " & _
                              " ProSucursal = " & Sucursal & ", " & _
                              " ProNumero = " & RboNumero & ", " & _
                              " Fecha = '" & Fecha & "', " & _
                              " Debe = 0, " & _
                              " Haber = " & Total & ", " & _
                              " PagoID = " & PagoID & ", " & _
                              " Pagado = " & IIf(Pagado, 1, 0) & ", " & _
                              " Detalle = '" & Detalle & "', " & _
                              " Usuario = '" & Uid & "', " & _
                              " FechaMod = '" & Format(Now, FormatFechaHora) & "' " & _
                              "WHERE PagoID = " & PagoID
               .ExecuteNonQuery()
            End If
         End If
      End With
      '
      GuardarCfg(cfgNroPago, "cfgNroPago", PagoID)
      '
      compCaja = "PG-" & PagoID
      CodAsi = compCaja
      If Nombre = "" Then
         NomProv = CapturaDato(Cn, "Proveedores", "Nombre", "Proveedor = " & Proveedor)
      Else
         NomProv = Nombre
      End If
      DetAsi = Left(Traducir("Pago") & " " & NomProv, 50)
      '
      If SisContable Then
         cCtaProv = CapturaDato(Cn, "Proveedores", "CtaCont", "Proveedor = " & Proveedor) & ""
         If cCtaProv = "" Then
            cCtaProv = cfgCtaProVar
            If cCtaProv = "" Then
               Err.Raise(1001, , "ProvSinCtaAsig")
            End If
         End If
         NroAsi = GuardaAsiento(CodAsi, Fecha, DetAsi)
         If NroAsi = 0 Then
            Err.Raise(1001, , "NoUpAsiento")
         End If
         Rs.CommandText = "DELETE FROM AsientosDet WHERE Asiento = " & NroAsi
         Rs.ExecuteNonQuery()
      End If
      '
      Rs.CommandText = "DELETE FROM PagosDet WHERE PagoID = " & PagoID
      Rs.ExecuteNonQuery()
      '
      'Debug.Print Val("SELECT SUM(Saldo) FROM " & TablaCmp & " WHERE Saldo < 0")
      Saldo = Saldo - Val(CapturaDato(Cn, TablaCmp, "ISNULL(SUM(Saldo),0)", "Saldo < 0", , , , Tr))
      '
      With Rs
         .CommandText = "SELECT * FROM " & TablaCmp
         DR = .ExecuteReader
         With DR
            Do While .Read
               nRen = nRen + 1
               '
               If !CompraID <> 0 Then
                  TablaSdo = "CtaCtePro"
                  CondSdo = "CompraID = " & !CompraID
               ElseIf !PagoPrId <> 0 Then
                  TablaSdo = "CtaCtePro"
                  CondSdo = "PagoID = " & !PagoPrId
               Else
                  TablaSdo = "PedidosProv "
                  CondSdo = "PedidoPrID = " & !CompraID
               End If
               Rs2.CommandText = "SELECT * FROM " & TablaSdo & " WHERE " & CondSdo
               DR2 = Rs2.ExecuteReader
               If DR2.Read Then
                  If DR2!Saldo < 0 Then
                     ImpPago = (DR2!Saldo)
                     Cmd.CommandText = "UPDATE " & TablaSdo & " SET Saldo = 0"
                  ElseIf DR2!Saldo < Saldo Then
                     Saldo = Saldo - DR2!Saldo
                     ImpPago = (DR2!Saldo)
                     Cmd.CommandText = "UPDATE " & TablaSdo & " SET Saldo = 0"
                  Else
                     Cmd.CommandText = "UPDATE " & TablaSdo & " SET Saldo = " & DR2!Saldo - Saldo
                     ImpPago = Saldo
                     Saldo = 0
                  End If
                  If PagoPedido Then
                     Cmd.CommandText = Cmd.CommandText & ", Estado = 3"
                  Else
                     Cmd.CommandText = Cmd.CommandText & ", Pagado = " & IIf(Pagado And DR2!Saldo = 0, 1, 0)
                  End If
                  Cmd.CommandText = Cmd.CommandText & ", Usuario = '" & Uid & "', FechaMod = '" & Format(Now, FormatFechaHora) & "' WHERE " & CondSdo
                  Cmd.ExecuteNonQuery()
               End If
               DR2.Close()
               '
               If PagoPedido Then
                  Rs2.CommandText = "SELECT * FROM PagosDet WHERE PagoID = " & PagoID & " AND PedidoPrID = " & !CompraID
               Else
                  Rs2.CommandText = "SELECT * FROM PagosDet WHERE PagoID = " & PagoID & " AND " & IIf(!CompraID <> 0, "CompraID", "PagoPrID") & " = " & IIf(!CompraID <> 0, !CompraID, !PagoPrId)
               End If
               DR2 = Rs2.ExecuteReader
               If Not DR2.Read Then
                  Cmd.CommandText = "INSERT INTO PagosDet( PagoID, PagoRenglon, CompraID, PedidoPrID, PagoPrID, ImpPago, Usuario, FechaMod ) " & _
                                    "VALUES( " & PagoID & ", " & _
                                                 nRen & ", " & _
                                                 IIf(PagoPedido, 0, DR.Item("CompraID")) & ", " & _
                                                 IIf(PagoPedido, DR.Item("CompraID"), 0) & ", " & _
                                                 IIf(PagoPedido, 0, DR.Item("PagoPrId")) & ", " & _
                                                 ImpPago & ", " & _
                                           "'" & Uid & "', " & _
                                           "'" & Format(Now, FormatFechaHora) & "')"
               End If
               Cmd.ExecuteNonQuery()
               '
               If Not PagoPedido Then
                  Cmd.CommandText = "UPDATE Compras SET " & _
                                    " Estado = 3, " & _
                                    " Usuario = '" & Uid & "', " & _
                                    " FechaMod = '" & Format(Now, FormatFechaHora) & "' " & _
                                    "WHERE CompraID = " & .Item("CompraID")
                  Cmd.ExecuteNonQuery()
               End If
               '
            Loop
            .Close()
         End With
      End With
      '
      Cmd.CommandText = "UPDATE CtaCtePro SET " & _
                        " Saldo = " & -Saldo & ", " & _
                        " Pagado = " & IIf(Saldo = 0, 1, 0) & " " & _
                        "WHERE PagoID = " & PagoID
      Cmd.ExecuteNonQuery()
      '
      If SisContable Then
         RenASi = RenASi + 1
         If Not GuardaAsienDet(NroAsi, RenASi, cCtaProv, DetAsi, Total, 0) Then
            Err.Raise(1001, , "NoUpAsiDet")
         End If
      End If
      '
      If Efectivo > 0 Then
         cDetCaja = "Efectivo"
         ActCaja(EmpresaId, Caja, compCaja, "EF", Fecha, NomProv, _
                 "", cDetCaja, 0, Efectivo)
         '
         If SisContable Then
            RenASi = RenASi + 1
            If Not GuardaAsienDet(NroAsi, RenASi, CtaCaja, DetAsi, 0, Efectivo) Then
               Err.Raise(1001, , "NoUpAsiDet")
            End If
         End If
         '
      End If
      '
      If ImpCheque > 0 Then
         '
         Cmd.CommandText = "DELETE FROM PagosDetCh WHERE PagoID = " & PagoID    '& " AND ChequeID NOT IN( SELECT ChequeID FROM " & TablaCh & ")"
         Cmd.ExecuteNonQuery()
         '
         Cmd.CommandText = "SELECT * FROM " & TablaCh
         DR = Cmd.ExecuteReader
         '
         nRen = 0
         With DR
            Do While .Read
               '
               nRen = nRen + 1
               '
               If !Origen = "T" Then
                  cDetCaja = "CH." & !Banco & ", CTA:" & !BancoCta & ", Nº" & !ChNumero & ", Al:" & !Fecha
                  '
                  ActCaja(EmpresaId, Caja, compCaja, "CH", Fecha, NomProv, _
                          "", cDetCaja, 0, !Importe)
               End If
               '
               If SisContable Then
                  'Detalle Asiento (Banco/Ch.Cartera).
                  RenASi = RenASi + 1
                  If Not GuardaAsienDet(NroAsi, RenASi, IIf(!Origen = "P", CtaBanco, CtaVCar), DetAsi, 0, !Importe) Then
                     Err.Raise(1001, , Traducir("NoUpAsiento"))
                  End If
               End If
               '
               If !Origen = "P" Then
                  Rs2.CommandText = "SELECT * FROM BancosMov WHERE Banco = " & !Banco & " AND BancoCta = '" & !BancoCta & "' AND TipoMovBco = " & TipoMovBco & " AND NroMovBco = " & !ChNumero
                  DR2 = Rs2.ExecuteReader
                  If .Read Then
                     'UPDATE
                     Rs2.CommandText = "UPDATE BancosMov SET " & _
                                       " EmpresaId = " & EmpresaId & ", " & _
                                       " Banco = " & !Banco & ", " & _
                                       " BancoCta = '" & !BancoCta & "', " & _
                                       " TipoMovBco = " & TipoMovBco & ", " & _
                                       " NroMovBco = " & !ChNumero & ", " & _
                                       " FechaEmi = '" & Format(Fecha, FormatFecha) & "', " & _
                                       " FechaAcr = '" & Format(!Fecha, FormatFecha) & "', " & _
                                       " Debe = " & IIf(Imput = "D", !Importe, 0) & ", " & _
                                       " Haber = " & IIf(Imput = "H", !Importe, 0) & ", " & _
                                       " Detalle = " & compCaja & " - " & DetAsi & ", " & _
                                       " Estado = 1, " & _
                                       " HojaBco = 0, " & _
                                       " Usuario = '" & Uid & "', " & _
                                       " FechaMod = '" & Format(Now, FormatFechaHora) & "' " & _
                                       "WHERE Banco = " & !Banco & " AND BancoCta = '" & !BancoCta & "' AND TipoMovBco = " & TipoMovBco & " AND NroMovBco = " & !ChNumero
                     Rs2.ExecuteNonQuery()
                  Else
                     Rs2.CommandText = "INSERT INTO BancosMov( EmpresaId, Banco, BancoCta, TipoMovBco, NroMovBco, FechaEmi, FechaAcr, Debe, Haber, Estado, HojaBco, Detalle, ChCartID, Caja, CtaCont, CajaAdm, Usuario, FechaMod) " & _
                                       "VALUES(" & EmpresaId & ", " & _
                                                  !Banco & ", " & _
                                                  !BancoCta & ", " & _
                                                   TipoMovBco & ", " & _
                                                  !ChNumero & ", " & _
                                                   Format(Fecha, FormatFecha) & ", " & _
                                                   Format(!Fecha, FormatFecha) & ", " & _
                                                   IIf(Imput = "D", !Importe, 0) & ", " & _
                                                   IIf(Imput = "H", !Importe, 0) & ", " & _
                                                   1 & ", " & _
                                                   0 & ", " & _
                                                   compCaja & " - " & DetAsi & ", " & _
                                                   0 & ", " & _
                                                   "0, '', 0, " & _
                                                   Uid & ", " & _
                                                   Format(Now, FormatFechaHora) & "')"
                     Rs2.ExecuteNonQuery()
                  End If
                  'HACER !!!
                  ' ''Rs2.Open("SELECT * FROM ChPropios WHERE Banco = " & !Banco & " AND BancoCta = '" & !BancoCta & "' AND ChPropNro = '" & !ChNumero & "'", Conn, adOpenKeyset, adLockOptimistic)
                  ' ''If Rs2.EOF Then
                  ' ''   Rs2.Close()
                  ' ''   Err.Raise(1001, , Traducir("ChNoEnc"))
                  ' ''Else
                  ' ''   Rs2!EmpresaId = EmpresaId
                  ' ''   Rs2!FechaEmi = Fecha
                  ' ''   Rs2!FechaDif = !Fecha
                  ' ''   Rs2!Importe = !Importe
                  ' ''   Rs2!Estado = 1
                  ' ''   Rs2!Usuario = Uid
                  ' ''   Rs2!FechaMod = Now
                  ' ''   Rs2.Update()
                  ' ''   ChequeID = Rs2!ChPropID
                  ' ''End If
                  ' ''Rs2.Close()
                  '
               Else
                  'HACER !!!
                  ' ''Rs2.Open("SELECT * FROM ChCartera WHERE Banco = " & !Banco & " AND BancoCta = '" & !BancoCta & "' AND ChCartNro = '" & !ChNumero & "'", Conn, adOpenKeyset, adLockOptimistic)
                  ' ''If Rs2.EOF Then
                  ' ''   Rs2.Close()
                  ' ''   Err.Raise(1001, , Traducir("ChNoEnc"))
                  ' ''   GoTo mError
                  ' ''Else
                  ' ''   Rs2!Estado = 6
                  ' ''   Rs2!Usuario = Uid
                  ' ''   Rs2!FechaMod = Now
                  ' ''   Rs2.Update()
                  ' ''   ChequeID = Rs2!ChCartID
                  ' ''   ImpChCartera = ImpChCartera + !Importe
                  ' ''End If
                  ' ''If cn <> Conn Then
                  ' ''   With Rsx
                  ' ''      .Open("SELECT * FROM ChCartera WHERE Banco = " & Rs!Banco & " AND BancoCta = '" & Rs!BancoCta & "' AND ChCartNro = '" & Rs!ChNumero & "'", cn, adOpenKeyset, adLockOptimistic)
                  ' ''      If .EOF Then
                  ' ''         .AddNew()
                  ' ''      End If
                  ' ''      For i = 1 To .Fields.Count - 1
                  ' ''         .Fields(i) = Rs2.Fields(i)
                  ' ''      Next
                  ' ''      .Update()
                  ' ''      ChequeID = Rsx!ChCartID
                  ' ''      .Close()
                  ' ''   End With
                  ' ''End If
                  ' ''Rs2.Close()
               End If
               'HACER !!!
               ' ''With Rs2
               ' ''   .Open("SELECT * FROM PagosDetCh WHERE PagoID = " & PagoID & " AND ChequeID = " & ChequeID & " AND Origen = '" & Rs!Origen & "'", cn, adOpenKeyset, adLockOptimistic)
               ' ''   If .EOF Then
               ' ''      .AddNew()
               ' ''   End If
               ' ''   !PagoID = PagoID
               ' ''   !Renglon = nRen
               ' ''   !ChequeID = ChequeID
               ' ''   !Origen = Rs!Origen
               ' ''   !Usuario = Uid
               ' ''   !FechaMod = Now
               ' ''   .Update()
               ' ''   .Close()
               ' ''End With
               '' ''
               ' ''.MoveNext()
               '
            Loop
            .Close()
         End With
      End If
      '
      If ImpChCartera > 0 Then
         cDetCaja = "Cheques"
         ActCaja(EmpresaId, Caja, compCaja, "CH", Fecha, NomProv, _
                 "", cDetCaja, 0, ImpChCartera)
         '
         If SisContable Then
            RenASi = RenASi + 1
            If Not GuardaAsienDet(NroAsi, RenASi, CtaCaja, DetAsi, 0, ImpChCartera) Then
               Err.Raise(1001, , "NoUpAsiDet")
            End If
         End If
         '
      End If
      '
      If IniTrans Then
         ' ''cn.CommitTrans()
      End If
      '
      GuardarPago = True
      Exit Function
      '
mError:
      MsgBox(Err.Number & ": " & Err.Description & Chr(13) & Chr(10) & _
             Traducir("TransNComp"))
      If IniTrans Then
         ' ''cn.RollbackTrans()
      End If
      '
   End Function
   '
   Sub AnulaLiqInq(ByVal Tipo As String, ByVal Sucursal As Integer, ByVal Numero As Long)
      '
      Dim n As Int16
      Dim cPer As String = ""
      Dim Inq As Int32 = 0
      Dim Prd As Int32 = 0
      '
      Dim i As Integer
      Dim cComprob As String
      Dim nroCaja As Integer
      Dim LiqInqTrID As Long
      Dim Nom As String
      Dim nBanco As Integer
      Dim cCtaBco As String
      Dim cNumero As String
      Dim nTipo As Integer
      Dim LicId As Int32
      Dim LiqInqId As Int32
      '
      Dim Trn As OleDb.OleDbTransaction
      Dim Cmd As New OleDb.OleDbCommand
      Dim Drd As OleDb.OleDbDataReader
      Dim Cm2 As New OleDb.OleDbCommand
      '
      Const cmpInt = "LI"
      Const estAnulado = 2
      '
      cComprob = cmpInt & "-" & Tipo & "-" & Sucursal & "-" & Numero
      '
      Trn = Cn.BeginTransaction
      '
      Try
         '
         Cmd.Connection = Cn
         Cm2.Connection = Cn
         '
         With Cmd
            '
            .Transaction = Trn
            .CommandText = "SELECT * FROM LiqInqCab WHERE  Tipo = '" & Tipo & "' AND Sucursal = " & Sucursal & " AND Numero = " & Numero
            '
            Drd = .ExecuteReader
            With Drd
               If .Read Then
                  LiqInqId = !LiqInqId
                  cPer = !Periodo
                  Prd = !Propiedad
                  Inq = !Inquilino
                  nroCaja = prmNroCaja   '!Caja
                  LiqInqTrID = Val(!LiqInqTrID & "")
               End If
               .Close()
            End With
            '
            .CommandText = "UPDATE LiqInqCab SET " &
                           " SaldoAnt = 0, " &
                           " Subtotal = 0, " &
                           " Intereses = 0, " &
                           " Iva1 = 0, " &
                           " Iva2 = 0, " &
                           " Total = 0, " &
                           " Efectivo = 0, " &
                           " Cheques = 0, " &
                           " Bonos = 0, " &
                           " ImporteTr = 0, " &
                           " Banco = 0, " &
                           " NroCheque = 0, " &
                           " Saldo = 0, " &
                           " Detalle = '" & Traducir("Anulada", , Trn) & "', " &
                           " Estado = " & estAnulado & ", " &
                           " ChReciboId = NULL, " &
                           " LiqInqTrId = NULL, " &
                           " SaldoPend = 0, " &
                           " Usuario = '" & Uid & "', " &
                           " FechaMod = '" & Format(Now, FormatFechaHora) & "' " &
                           "WHERE Tipo = '" & Tipo & "' AND Sucursal = " & Sucursal & " AND Numero = " & Numero
            .ExecuteNonQuery()
            '
            .CommandText = "SELECT * FROM LiqInqDet WHERE Tipo = '" & Tipo & "' AND Sucursal = " & Sucursal & " AND Numero = " & Numero
            Drd = .ExecuteReader
            With Drd
               Do While .Read
                  With Cm2
                     .Transaction = Trn
                     .CommandText = "UPDATE FactInq SET " &
                                    " Liquidado = 0, " &
                                    " Saldo = Saldo + " & Drd!Importe & ", " &
                                    " TipoNroRbo = ''" &
                                    "WHERE Periodo = '" & cPer & "' AND Propiedad = " & Prd & " AND Inquilino = " & Inq & " AND Concepto = '" & Drd!Concepto & "'"
                     n = .ExecuteNonQuery()
                     If n = 0 Then
                        .CommandText = "UPDATE FactInq SET " &
                                       " Liquidado = 0, " &
                                       " Saldo = Saldo + " & Drd!Importe & ", " &
                                       " TipoNroRbo = ''" &
                                       "WHERE Periodo = '" & cPer & "' AND Propiedad = 0 AND Inquilino = " & Inq & " AND Concepto = '" & Drd!Concepto & "'"
                        n = .ExecuteNonQuery
                     End If
                  End With
               Loop
               .Close()
            End With
            '
            .CommandText = "DELETE FROM LiqInqDet WHERE Tipo = '" & Tipo & "' AND Sucursal = " & Sucursal & " AND Numero = " & Numero
            .ExecuteNonQuery()
            '
            If Not BajaCaja(cComprob, , Trn, nroCaja) Then
               Err.Raise(1001, "frmLiqInquilinosAbm.AnulaLiqInq", Err.Description)
            End If
            '
            LicId = CapturaDato(Cn, "LiqInqCobDet", "LicId", "LiqInqId = " & LiqInqId, , , , Trn)
            '
            .CommandText = "DELETE FROM LiqInqCobCh WHERE LicId = " & LicId
            .ExecuteNonQuery()
            '
            .CommandText = "SELECT * FROM ChRecibo WHERE RboTipo = '" & Tipo & "' AND RboSucursal = " & Sucursal & " AND RboNumero = " & Numero
            Drd = .ExecuteReader
            '
            i = 1
            '
            Do While Drd.Read
               Cm2.CommandText = "DELETE FROM ChCartera WHERE Banco = " & Drd!Banco & " AND BancoCta = '" & Drd!Cuenta & "' AND ChCartNro = '" & Drd!Numero & "'"
               Cm2.ExecuteNonQuery()
               '
               If Not BajaCaja(cComprob & "/" & i, , Trn, nroCaja) Then
                  Err.Raise(1001, "frmLiqInquilinosAbm.AnulaLiqInq", Err.Description)
               End If
               '
               i = i + 1
               '
            Loop
            Drd.Close()
            '
            .CommandText = "DELETE FROM ChRecibo WHERE RboTipo = '" & Tipo & "' AND RboSucursal = " & Sucursal & " AND RboNumero = " & Numero
            .ExecuteNonQuery()
            '
         End With
         '
         If SisContable Then
            If Not BorraAsiento(cComprob, Trn) Then
               Err.Raise(1001, , Traducir("NoDelAsiento", , Trn))
            End If
         End If
         '
         With Cmd
            .CommandText = "UPDATE CobrosOtr SET " &
                           " Estado = 0, " &
                           " Liquidado = 0, " &
                           " Usuario = '" & Uid & "', " &
                           " FechaMod = '" & Format(Now, FormatFechaHora) & "' " &
                           "WHERE LiqInquilino = " & Numero
            .ExecuteNonQuery()
            '
            If LiqInqTrID <> 0 Then
               nBanco = CapturaDato(Cn, "LiqInqTR", "Banco1", "LiqInqTrID = " & LiqInqTrID, , , , Trn)
               cCtaBco = CapturaDato(Cn, "LiqInqTR", "Cuenta1", "LiqInqTrID = " & LiqInqTrID, , , , Trn)
               cNumero = CapturaDato(Cn, "LiqInqTR", "NumeroTR", "LiqInqTrID = " & LiqInqTrID, , , , Trn)
               nTipo = CapturaDato(Cn, "TipoMovBco", "TipoMovBco", "TipoMov = 'TR'", , , , Trn)
               If nTipo = 0 Then
                  Err.Raise(1001, , "Tipo de Mov. Transferencia no Definida")
               End If
               '
               .CommandText = "DELETE FROM LiqInqTR WHERE LiqInqTrID = " & LiqInqTrID
               .ExecuteNonQuery()
               '
               .CommandText = "DELETE FROM BancosMov WHERE Banco = " & nBanco & " AND BancoCta = '" & cCtaBco & "' AND TipoMovBco = " & nTipo & " AND NroMovBco = '" & cNumero & "'"
               .ExecuteNonQuery()
               '
            End If
            '
            .CommandText = "DELETE FROM LiqInqCobDet WHERE LicId = " & LicId
            .ExecuteNonQuery()
            '
            .CommandText = "DELETE FROM LiqInqCob WHERE LicId = " & LicId
            .ExecuteNonQuery()
            '
         End With
         '
         Nom = CapturaDato(Cn, "Inquilinos", "Nombre", "Codigo = " & Inq, , , , Trn)
         '
         GuardarAudit("Anula liquidación inquilino", Nom & " - Nº " & Numero & " - Período " & cPer, "ModPol", "AnulaLiqInq", Trn)
         '
         Trn.Commit()
         '
      Catch ex As Exception
         '
         Trn.Rollback()
         '
         Dim st As New StackTrace(True)
         RegistrarError(st, "LiqInquilinos", , Err.Description, "AnulaLiqInq")
         '
      End Try
      '
   End Sub
   '
   Function CalcImportesVenta(Precio As Double, PrecioLocal As Double, Neto As Boolean, Bonific As String, alicuoIva As Single, ByRef PrecioFin As Double, tbPrUnit As TextBox, tbSubtotal As TextBox, tbCantidad As TextBox, impInt As Double) As Double
      '
      Dim subTotal As Double
      Dim prUnit As Double
      Dim Bonif As New Collection
      Dim Pos As Integer
      Dim i As Int16
      '
      If PrecioLocal <> 0 Then
         'If Neto Then
         Precio = PrecioLocal
         'PrecioFin = Precio * (1 + alicuoIva / 100)
         'Else
         'Precio = PrecioLocal / (1 + alicuoIva / 100)
         'PrecioFin = PrecioLocal * (1 + alicuoIva / 100)
         'End If
      End If
      '
      If Val(Bonific) <> 0 Then
         'Bonific = tbBonif.Text
         Bonif.Add(Val(Bonific))
         Do While InStr(Bonific, "+") > 0
            Pos = InStr(Bonific, "+")
            If Len(Bonific) - Pos > 0 Then
               'Bonific = Mid(Bonific, Len(Bonific) - Pos,  Len(Bonific))
               Bonific = Mid(Bonific, Pos + 1, Len(Bonific) - Pos)
               Bonif.Add(Val(Bonific))
            Else
               Exit Do
            End If
         Loop
      End If
      'tbPrecio.Text = Format(Precio, cfgFormatoPr)
      '*PrecioFin = Precio
      If Not Neto Then
         'tbPrecio.Text = Format(Precio * (1 + alicuoIva / 100), cfgFormatoPr)
         '*PrecioFin = Precio * (1 + alicuoIva / 100)
      End If
      prUnit = Precio
      For i = 1 To Bonif.Count
         prUnit = prUnit - prUnit * Val(Bonif.Item(i)) / 100
      Next i
      'tbPrUnit.Text = Format(prUnit, cfgFormatoPr)
      If Not Neto Then
         '*prUnit = prUnit * (1 + alicuoIva / 100)
      End If
      '
      PrecioFin = prUnit * (1 + alicuoIva / 100)
      tbPrUnit.Text = Format(prUnit, cfgFormatoPr)
      subTotal = (prUnit + impInt) * Val(tbCantidad.Text)
      tbSubtotal.Text = Format(subTotal, cfgFormatoPr)
      '
      Return subTotal
      '
   End Function
   '
End Module

