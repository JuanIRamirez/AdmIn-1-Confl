Module modContab
   '
   Public cfgCtaIvaCF1 As String
   Public cfgCtaIvaCF2 As String
   Public cfgCtaIvaDF1 As String
   Public cfgCtaIvaDF2 As String
   Public cfgCtaCaja As String
   Public cfgCtaMerc As String
   Public cfgCtaInter As String
   Public cfgCtaValCar As String
   Public cfgCtaTarjC As String
   Public cfgCtaTarjD As String
   Public cfgCtaCliVar As String
   Public cfgCtaProVar As String
   Public cfgCtaImpInt As String
   Public cfgCtaRetGcias As String
   Public cfgCtaRetIB As String
   Public cfgCtaRetIva As String
   Public cfgUniCtaCliVar As Boolean
   '
   Public Function CaptCtasCaja(ByVal nroCaja As Int16, ByRef CtaCont As String, Optional ByRef CtaAdm As String = "", Optional ByVal Mensaje As Boolean = True) As Boolean
      '
      CtaCont = CapturaDato(Cn, "Cajas", "Cuenta", "Caja = " & nroCaja) & ""
      CtaAdm = CapturaDato(Cn, "Cajas", "CtaAdm", "Caja = " & nroCaja) & ""
      '
      If CtaCont = "" And CtaAdm = "" Then
         If Mensaje Then
            MensajeTrad("CtaCajaNoAsig")
         End If
         Return False
      End If
      '
      Return True
      '
   End Function
   '
   Function GuardaAsiento(ByVal CodAsi As String, ByVal Fecha As Date, ByVal DetAsi As String, Optional ByVal Tr As Object = "") As Long
      '
      Dim rsCAsi As New OleDb.OleDbCommand
      Dim Asiento As Long
      '
      Try
         With rsCAsi
            .Connection = Cn
            If Tr.ToString <> "" Then
               .Transaction = Tr
            End If
            .CommandText = "SELECT ISNULL(Numero,0) FROM Asientos WHERE Codigo = '" & CodAsi & "'"
            Asiento = .ExecuteScalar()
            If Asiento = 0 Then
               'Asiento = Val(CapturaDato(Cn, "Asientos", "MAX(Numero)", "", , , , Tr) & "") + 1
               'Do While Not IsNothing(CapturaDato(Cn, "Asientos", "Numero", "Numero = " & Asiento, , , , Tr))
               'Asiento = Asiento + 1
               'Loop
               .CommandText = "INSERT INTO Asientos( Fecha, Codigo, Detalle, cFecha, Usuario, FechaMod) " & _
                              "VALUES('" & Format(Fecha, FormatFecha) & "', " & _
                                     "'" & CodAsi & "', " & _
                                     "'" & DetAsi & "', " & _
                                     "'" & Format(Fecha, "yyyyMMdd") & "', " & _
                                     "'" & Uid & "', " & _
                                     "'" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
               .CommandText = "SELECT MAX(Numero) FROM Asientos"
               Asiento = .ExecuteScalar
            Else
               .CommandText = "UPDATE Asientos SET " & _
                              " Codigo = '" & CodAsi & "', " & _
                              " Fecha = '" & Format(Fecha, FormatFecha) & "', " & _
                              " cFecha = '" & Format(Fecha, FormatFecha) & "', " & _
                              " Detalle = '" & DetAsi & "', " & _
                              " Usuario = '" & Uid & "', " & _
                              " FechaMod = '" & Format(Now, FormatFechaHora) & "' " & _
                              "WHERE Numero = " & Asiento
               .ExecuteNonQuery()
            End If
         End With
         '
      Catch e As SystemException
         MensajeTrad(Err.Description, , True)
         Return 0
      End Try
      '
      Return Asiento
      '
   End Function
   '
   Function BorraAsienDet(ByVal Asiento As Long, Optional ByVal Tr As Object = "") As Boolean
      '
      Dim rsCAsi As New OleDb.OleDbCommand
      Dim r As Boolean
      '
      Try
         With rsCAsi
            .Connection = Cn
            If Tr.ToString <> "" Then
               .Transaction = Tr
            End If
            .CommandText = "DELETE FROM AsienDet WHERE Numero = " & Asiento
            .ExecuteNonQuery()
            r = True
         End With
      Catch ex As Exception
         MensajeTrad("NoDelDetAsi", , True)
         r = False
      End Try
      '
      Return r
      '
   End Function
   '
   Function GuardaAsienDet(ByVal NroAsi As Long, ByVal RenASi As Integer, _
                           ByVal CtaCont As String, ByVal Detalle As String, ByVal Debe As Double, _
                           ByVal Haber As Double, Optional ByVal Tr As Object = "") As Boolean
      '
      Dim rsCAsi As New OleDb.OleDbCommand
      Dim r As Boolean
      '
      If CtaCont = "" Then
         MsgBox("Cuenta en blanco")
         Return False
      End If
      '
      Try
         With rsCAsi
            .Connection = Cn
            If Tr.ToString <> "" Then
               .Transaction = Tr
            End If
            .CommandText = "INSERT INTO AsienDet( Numero, Renglon, Cuenta, Detalle, Debe, Haber, Usuario, FechaMod) " & _
                           "VALUES(" & NroAsi & ", " & _
                                       RenASi & ", " & _
                                 "'" & CtaCont & "', " & _
                                 "'" & Left(Detalle, 250) & "', " & _
                                 "'" & Debe & "', " & _
                                 "'" & Haber & "', " & _
                                 "'" & Uid & "', " & _
                                 "'" & Format(Now, FormatFechaHora) & "')"
            .ExecuteNonQuery()
            r = True
         End With
         '
      Catch ex As Exception
         Dim st As New StackTrace(True)
         MensageError(st, "modContab.GuardaAsienDet", ex.Message)
         r = False
      End Try
      '
      Return r
      '
   End Function
   '
   Function BorraAsiento(ByVal CodAsi As String, Optional ByVal Tr As Object = "") As Boolean
      '
      Dim Numero As Long
      '
      Numero = Val(CapturaDato(Cn, "Asientos", "Numero", "Codigo = '" & CodAsi & "'", , , , Tr) & "")
      '
      Return BorraAsientoNro(Numero, Tr)
      '
      'mError:
      '      MensageError("ModContab.BorraAsiento", Traducir("NoDelAsiento"))
      '      Return False
      '
   End Function
   '
   Function BorraAsientoNro(ByVal NroAsi As Long, Optional ByVal Tr As Object = "") As Boolean
      '
      Dim cmd As New OleDb.OleDbCommand
      '
      Try
         '
         With cmd
            .Connection = Cn
            If Tr.ToString <> "" Then
               .Transaction = Tr
            End If
            .CommandText = "DELETE FROM Asientos WHERE Numero = " & NroAsi
            .ExecuteNonQuery()

            .CommandText = "DELETE FROM AsienDet WHERE Numero = " & NroAsi
            .ExecuteNonQuery()
         End With
         '
         Return True
         '
      Catch ex As System.Exception
         Dim st As New StackTrace(True)
         MensageError(st, "BorraAsiento", Err.Description)
         Return False
      End Try
      '
   End Function
   '
   Function ActCaja(ByVal Caja As Integer, ByVal Comprob As String, ByVal fPago As String,
                    ByVal Fecha As Date, ByVal Nombre As String, ByVal Descrip As String,
                    ByVal Detalle As String, ByVal Entrada As Double, ByVal Salida As Double,
                    Optional ByVal CajaAdm As Boolean = False, Optional ByVal Tr As Object = "", Optional Cmd As Object = "") As Boolean
      '
      Dim cSQL As String
      Dim r As Boolean
      '
      If Cmd.ToString = "" Then
         Cmd = New OleDb.OleDbCommand
      End If
      '
      Try
         If IsNothing(CapturaDato(Cn, "Caja", "Comprob", "Comprob = '" & Comprob & "' AND fPago = '" & fPago & "'", , , , Tr, cmd)) Then
            cSQL = "INSERT INTO Caja( Caja, Comprob, Fecha, FechaC, Nombre, Detalle, fPago, Entrada, Salida, CajaAdm, Usuario, FechaMod) " &
                   "VALUES(" & Caja & ", " &
                         "'" & Comprob & "', " &
                         "'" & Format(Now, FormatFechaHora) & "', " &
                         "'" & Format(Fecha, FormatFecha) & "', " &
                         "'" & Nombre & "', " &
                         "'" & Left(Detalle, 50) & "', " &
                         "'" & fPago & "', " &
                         "'" & Entrada & "', " &
                         "'" & Salida & "', " &
                         "'" & IIf(CajaAdm, 1, 0) & "', " &
                         "'" & Uid & "', " &
                         "'" & Format(Now, FormatFechaHora) & "')"
         Else
            cSQL = "UPDATE Caja SET " &
                   " Caja = " & Caja & ", " &
                   " Fecha = '" & Format(Now, FormatFechaHora) & "', " &
                   " FechaC = '" & Format(Fecha, FormatFecha) & "', " &
                   " Nombre = '" & Nombre & "', " &
                   " Detalle = '" & Left(Detalle, 50) & "', " &
                   " fPago = '" & fPago & "', " &
                   " Entrada = '" & Entrada & "', " &
                   " Salida = '" & Salida & "', " &
                   " CajaAdm = '" & IIf(CajaAdm, 1, 0) & "', " &
                   " Usuario = '" & Uid & "', " &
                   " FechaMod = '" & Format(Now, FormatFechaHora) & "' " &
                   "WHERE Comprob = '" & Comprob & "'" &
                   "  AND FPago = '" & fPago & "'"
         End If
         '

         With Cmd
            If .Connection.ToString = "" Then
               .Connection = Cn
            End If
            .CommandText = cSQL
            If Tr.ToString <> "" Then
               .Transaction = Tr
            End If
            .ExecuteNonQuery()
            r = True
         End With
         '
      Catch ex As System.Exception
         Dim st As New StackTrace(True)
         MensageError(st, "ActCaja()")
         r = False
      End Try
      '
      Return r
      '
   End Function
   '
   Function BajaCaja(ByVal Comprob As String, Optional ByVal fPago As String = "", Optional ByVal Tr As Object = "", Optional Caja As Byte = 0) As Boolean
      '
      Dim Cmd As New OleDb.OleDbCommand
      Dim Cm2 As New OleDb.OleDbCommand
      Dim Drd As OleDb.OleDbDataReader
      '
      Dim r As Boolean
      '
      Dim CajaAdm As Byte
      Dim Fecha As Date
      Dim Nombre, Detalle, FP As String
      Dim Entrada, Salida As Double
      '
      Try
         With Cmd
            .Connection = Cn
            If Tr.ToString <> "" Then
               .Transaction = Tr
            End If
            '
            .CommandText = "SELECT * FROM Caja WHERE Comprob = '" & Comprob & "'" & IIf(fPago = "", "", " AND FPago = '" & fPago & "'")
            Drd = .ExecuteReader
         End With
         '
         With Cm2
            .Connection = Cn
            If Tr.ToString <> "" Then
               .Transaction = Tr
            End If
         End With
         '
         With Drd
            Do While .Read
               If Caja = 0 Then
                  Caja = !Caja
               End If
               Fecha = Now
               Nombre = !Nombre & ""
               Detalle = !Detalle
               FP = !FPago
               Entrada = !Salida
               Salida = !Entrada
               CajaAdm = IIf(!CajaAdm, 1, 0)
               '
               Cm2.CommandText = "INSERT INTO Caja( Caja, Comprob, Fecha, FechaC, Nombre, Detalle, fPago, Entrada, Salida, CajaAdm, Usuario, FechaMod) " & _
                                 "VALUES(" & Caja & ", " & _
                                       "'-" & Comprob & "', " & _
                                       "'" & Format(Fecha, FormatFechaHora) & "', " & _
                                       "'" & Format(Fecha, FormatFecha) & "', " & _
                                       "'" & Nombre & "', " & _
                                       "'" & Left("Anula " & Detalle, 50) & "', " & _
                                       "'" & FP & "', " & _
                                             Entrada & ", " & _
                                             Salida & ", " & _
                                             CajaAdm & ", " & _
                                       "'" & Uid & "', " & _
                                       "'" & Format(Now, FormatFechaHora) & "')"
               Cm2.ExecuteNonQuery()
            Loop
            .Close()
         End With
         '
         r = True
         '
      Catch
         Dim st As New StackTrace(True)
         MensageError(st, "BajaCaja")
         r = False
      End Try
      '
      Return r
      '
   End Function
   '
   Function CapturaCtaCliente(ByVal Cliente As Long, Optional ByVal Tr As Object = "") As String
      Dim CtaCont As String
      CtaCont = CapturaDato(cn, "Clientes", "CtaCont", "Cliente = " & Cliente, , , , Tr) & ""
      If IsDBNull(CtaCont) Or CtaCont = "" Then
         CtaCont = cfgCtaCliVar
      End If
      Return CtaCont
   End Function
   '
   Function PerIvaCerrado(ByVal Fecha As Date) As Boolean
      If Format(Fecha, "yyyyMM") <= cfgPerCierreIVA Then
         PerIvaCerrado = True
      End If
   End Function
   '
   Sub AnularEgreso(ByVal EgresoId As Long, Optional ByVal Tr As Object = "")
      '
      Dim Cmd As New OleDb.OleDbCommand
      Dim Sucursal As Integer
      Dim Depart As Integer
      '
      Sucursal = CapturaDato(cn, "Egresos", "Sucursal", "EgresoID = " & EgresoId, , , , Tr)
      Depart = CapturaDato(cn, "Egresos", "Departamento", "EgresoID = " & EgresoId, , , , Tr)
      '
      With Cmd
         If Tr.ToString <> "" Then
            .Transaction = Tr
         End If
         .Connection = cn
         .CommandText = "UPDATE Partidas " & _
                    "SET Saldo = Saldo + " & _
                    " (SELECT SUM(CantEntr) FROM EgresosDet " & _
                    "  WHERE Sucursal = Partidas.Sucursal " & _
                    "    AND Departamento = Partidas.Departamento " & _
                    "    AND Proveedor = Partidas.Proveedor " & _
                    "    AND Producto = Partidas.Producto " & _
                    "    AND Partida = Partidas.Partida " & _
                    "    AND EgresoID = " & EgresoId & "), " & _
                    "    Usuario = '" & Uid & "', " & _
                    "    FechaMod = '" & Format(Now, FormatFechaHora) & "' " & _
                    "WHERE Sucursal = " & Sucursal & _
                    "  AND Departamento = " & Depart & _
                    "  AND EXISTS( SELECT null FROM EgresosDet " & _
                    "              WHERE Sucursal = Partidas.Sucursal " & _
                    "                AND Departamento = Partidas.Departamento " & _
                    "                AND Proveedor = Partidas.Proveedor " & _
                    "                AND Producto = Partidas.Producto " & _
                    "                AND Partida = Partidas.Partida " & _
                    "                AND EgresoID = " & EgresoId & ")"
         .ExecuteNonQuery()
         '
         .CommandText = "UPDATE Stock SET Cantidad = Cantidad + " & _
                    " (SELECT SUM(CantEntr) AS Cant FROM EgresosDet " & _
                    "  WHERE EgresoID = " & EgresoId & _
                    "    AND Producto = Stock.Producto " & _
                    "  GROUP BY Producto), " & _
                    " CantDisp = CantDisp + " & _
                    " (SELECT SUM(Cantidad) AS Cant FROM EgresosDet " & _
                    "  WHERE EgresoID = " & EgresoId & _
                    "    AND Producto = Stock.Producto " & _
                    "  GROUP BY Producto), " & _
                    "    Usuario = '" & Uid & "', " & _
                    "    FechaMod = '" & Format(Now, FormatFechaHora) & "' " & _
                    " WHERE Sucursal= " & Sucursal & _
                    "   AND Departamento = " & Depart & _
                    "   AND Producto " & _
                    "    IN( SELECT DISTINCT Producto FROM EgresosDet " & _
                    "        WHERE EgresoID = " & EgresoId & ")"
         .ExecuteNonQuery()
         '
         .CommandText = "UPDATE Egresos SET " & _
                    " Estado = 4, " & _
                    " Detalle = 'Anulado', " & _
                    " Usuario = '" & Uid & "', " & _
                    " FechaMod = '" & Format(Now, FormatFechaHora) & "' " & _
                    "WHERE EgresoID = " & EgresoId
         .ExecuteNonQuery()
         '
         .CommandText = "DELETE FROM EgresosDet WHERE EgresoID = " & EgresoId
         .ExecuteNonQuery()
         '
      End With
   End Sub
   '
   Function CapturaAsiento(ByVal CodAsi As String) As Long
      Return Val(CapturaDato(Cn, "Asientos", "Numero", "Codigo = '" & CodAsi & "'") & "")
   End Function
   '
   Function CaptCtasConc(ByVal Codigo As String, ByRef Descrip As String, ByRef Cuenta As String, ByRef CtaAdm As String, Optional ByRef Prioridad As Int16 = 0, Optional ByVal Tr As Object = "") As Boolean
      '
      Dim rsConc As New OleDb.OleDbCommand
      Dim Dr As OleDb.OleDbDataReader
      Dim r As Boolean = True
      '
      If Codigo = "" Then
         MensajeTrad(Traducir("ConcNoDef") & ": (" & Descrip & ")")
         Exit Function
      End If
      '
      With rsConc
         .Connection = Cn
         If Tr.ToString <> "" Then
            .Transaction = Tr
         End If
         .CommandText = "SELECT * FROM Conceptos WHERE Codigo = '" & Left(Codigo, 3) & "'"
         Dr = .ExecuteReader
      End With
      '
      With Dr
         If .Read Then
            If !Descrip <> "" Then Descrip = !Descrip
            If IsDBNull(!Cuenta) Or IsDBNull(!CtaAdm) Then
               MsgBox(Traducir("ConcSinCtaAsig") & ": (" & Codigo & ")")
               .Close()
               Return False
            End If
            If !Cuenta <> "" Then Cuenta = !Cuenta
            If !CtaAdm <> "" Then CtaAdm = !CtaAdm
            Prioridad = !Prioridad
         Else
            MensajeTrad("Concepto [" & Codigo & "], No Definido.")
            .Close()
            Return False
         End If
         .Close()
      End With
      '
      Return True
      '
   End Function
   '
   Function ProximoNroAsi(Optional ByVal Tr As Object = "") As Int64
      '
      Return Val(CapturaDato(Cn, "Asientos", "MAX(Numero)", "", , , , Tr) & "") + 1
      '
   End Function
   '
   Function ProxCompCaja(Optional ByVal Comprob = "MN", Optional ByRef Numero = 0, Optional ByVal Tr = "") As String
      '
      Dim r As String
      '
      Numero = Val(CapturaDato(Cn, "Config", "Valor", "Clave = 'cfgNroCajaMN'", , , , Tr) & "") + 1
      '
      r = Comprob & Numero
      '
      Do While ExisteDato(Cn, "Caja", "Comprob = '" & r & "'",, Tr)
         Numero = Numero + 1
         r = Comprob & Numero
      Loop
      '
      Return r
      '
   End Function
   '
End Module
