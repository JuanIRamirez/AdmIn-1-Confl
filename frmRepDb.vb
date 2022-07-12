Public Class FrmRepDb
   '
   Dim Trn As OleDb.OleDbTransaction
   Dim Cmd As New OleDb.OleDbCommand
   Dim Cm2 As New OleDb.OleDbCommand
   Dim Cm3 As New OleDb.OleDbCommand
   Dim Drd As OleDb.OleDbDataReader
   Dim Dr2 As OleDb.OleDbDataReader
   '
   Dim LicId As Int32
   Dim nCont As Int16
   '
   Private Sub BtnTrInq_Click(sender As Object, e As EventArgs) Handles btnTrInq.Click
      '
      'Trn = Cn.BeginTransaction
      '
      Cm2.Connection = Cn
      Cm3.Connection = Cn
      '
      nCont = 0
      '
      With Cmd
         .Connection = Cn
         'Transaction = Trn
         '
         .CommandText = "DELETE FROM LiqInqTR WHERE LiqInqTrID IN( SELECT LiqInqTrID FROM LiqInqCab WHERE Estado = 2)"
         nCont = .ExecuteNonQuery()
         '
         .CommandText = "UPDATE LiqInqCab SET LiqInqTrId = NULL WHERE Estado = 2 AND NOT LiqInqTrId IS NULL"
         nCont = nCont + .ExecuteNonQuery()
         '
         .CommandText = "SELECT Periodo, Propietario, Propiedad, Inquilino, Fecha, Tipo, Sucursal, Numero, MesPago, SaldoAnt, SubTotal, Intereses, Iva1, Iva2, Total, Efectivo, Cheques, Banco, FecCheque, NroCheque, Saldo, Detalle, LiqPropiet, Liquidado, Estado, Caja, Bonos, cFecha, Usuario, FechaMod, ChReciboID, LiqInqTrID, ImporteTR, LiqInqID, SaldoPend, Retencion, RetencNro " &
                        "FROM LiqInqCab WHERE Estado < 2 " &
                        " AND LiqInqID NOT IN( SELECT LiqInqId FROM LiqInqCobDet)"
         Drd = .ExecuteReader
         '
         With Drd
            While .Read
               'Cm2.Transaction = Trn
               Cm2.CommandText = "INSERT INTO LiqInqCob( LicFecha, Inquilino, LicEfectivo, LicRetencion, LicTransferencia, LiqInqTrId, LicCheques, LicSaldo, LicUid, LicFecMod) " &
                                 "VALUES('" & Format(Today, FormatFecha) & "', " &
                                              !Inquilino & ", " &
                                              !Efectivo & ", " &
                                              !Retencion & ", " &
                                              !ImporteTr & ", " &
                                              IIf(IsDBNull(!LiqInqTrID), "NULL", !LiqInqTrID) & ", " &
                                              !Cheques & ", " &
                                              0 & ", " &
                                        "'" & Uid & "', " &
                                        "'" & Format(Now, FormatFechaHora) & "')"
               Cm2.ExecuteNonQuery()
               '
               LicId = CapturaDato(Cn, "LiqInqCob", "MAX(LicId)", "")   ', , , , Trn)
               '
               Cm2.CommandText = "INSERT INTO LiqInqCobDet( LicId, LiqInqId, LcdImpPago, LcdSaldo, LcdUid, LcdFecMod) " &
                                 "VALUES(" & LicId & ", " &
                                             !LiqInqId & ", " &
                                             !Total & ", " &
                                             0 & ", " &
                                       "'" & Uid & "', " &
                                       "'" & Format(Now, FormatFechaHora) & "')"
               Cm2.ExecuteNonQuery()
               '
               Cm2.CommandText = "SELECT C.ChCartId FROM ChRecibo R, ChCartera C WHERE R.Banco = C.Banco AND R.Cuenta = C.BancoCta AND R.Numero = C.ChCartNro AND R.RboTipo = '" & !tipo & "' AND R.RboSucursal = " & !Sucursal & " AND R.RboNumero = " & !Numero
               Dr2 = Cm2.ExecuteReader
               '
               With Dr2
                  While Dr2.Read
                     'Cm3.Transaction = Trn
                     Cm3.CommandText = "INSERT INTO LiqInqCobCh( LicId, ChCarteraId, LicUid, LicFecMod) " &
                                       "VALUES(" & LicId & ", " &
                                                   !ChCartId & ", " &
                                             "'" & Uid & "', " &
                                             "'" & Format(Now, FormatFechaHora) & "')"
                     Cm3.ExecuteNonQuery()
                     '
                  End While
                  '
                  .Close()
                  '
               End With
               '
               nCont = nCont + 1
               '
            End While
            '
            .Close()
            '
         End With
      End With
      '
      'Trn.Begin()
      '
      lblTrInq.Text = nCont & " Correcciones."
      '
   End Sub
   '
End Class