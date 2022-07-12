Public Class frmChRechAM
   '
   Public EmpresaId As Integer = 0
   Public Cliente As Integer = 0
   Public Banco As Integer
   Public BancoCta As String
   Public TipoMovBco As Integer
   Public NroMovBco As String
   '
   Dim BancoCh As Int16
   Dim CuentaCh As String = ""
   '
   Public CtaCont As String
   '
   Dim Trn As OleDb.OleDbTransaction
   Dim Cmd As New OleDb.OleDbCommand
   Dim Drd As OleDb.OleDbDataReader
   Dim Cm2 As New OleDb.OleDbCommand
   Dim Dr2 As OleDb.OleDbDataReader
   '
   Dim Estado As Byte
   Dim Caja As Int16
   Dim cImput As String
   Dim cTipoMov As String
   Dim ChCartID As Long
   Dim cCtaCaja As String
   Dim cCtaCajaA As String
   Dim cCtaVCar As String
   Dim i As Integer
   '
   Dim TipoRech As Byte = Val(CapturaDato(Cn, "TipoMovBco", "TipoMovBco", "TipoMov = 'RC'") & "")
   '
   Const ESTEMI = 1
   Const ESTDEP = 1
   Const estENTR = 2
   Const EstRECH = 3
   Const EstACOB = 4
   Const EstCOBR = 5
   '
   Private Sub frmChRechAM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      '
      GetRegForm(Me)
      '
      Cmd.Connection = cn
      Cm2.Connection = cn
      '
      tbDescBanco.Text = CapturaDato(cn, "Bancos", "Nombre", "Banco = " & Banco)
      tbCtaBco.Text = BancoCta
      '
      If SisContable Then
         If cfgCtaValCar = "" Then
            DeshabForm(Me)
         End If
      Else
         lblCuenta.Enabled = False
         tbCuenta.Enabled = False
         cbDescCta.Enabled = False
      End If
      '
      If TipoRech = 0 Then
         MensajeTrad("TMovRechNoDef")
         DeshabForm(Me)
      End If
      '
      cTipoMov = CapturaDato(cn, "TipoMovBco", "TipoMov", "TipoMovBco = " & TipoMovBco)
      '
      If SisContable Then
         ArmaCombo(cbDescCta, "Descrip", "PlanCtas", , "RecAsi <> 0", "Descrip", "(Seleccionar)")
      End If
      '
      ArmaComboItem(cbCaja, "Cajas", "Caja", , , "(Seleccionar)", "Caja <> 0", , , , prmNroCaja)
      '
      dtpFechaRech.Value = Today
      '
      If Cliente > 0 Then
         tbCliente.Text = CapturaDato(cn, "Clientes", "Nombre", "Cliente = " & Cliente) & ""
      End If
      '
      Me.CancelButton = cmdCancelar
      '
      With Cmd
         .CommandText = "SELECT * FROM BancosMov WHERE Banco = " & Banco & " AND BancoCta = '" & BancoCta & "' AND TipoMovBco = " & TipoMovBco & " AND NroMovBco = '" & NroMovBco & "'"
         Drd = .ExecuteReader
      End With
      '
      With Drd
         If .Read Then
            '
            Estado = !Estado
            If Estado <> 1 Then
               MensajeTrad("EstIncorrecto")
               .Close()
               DeshabForm(Me)
            End If
            '
            tbFechaAcr.Value = !FechaAcr
            tbDetalle.Text = !Detalle
            '
            If SisContable Then
               tbCuenta.Text = !CtaCont & ""
            End If
            '
            If cTipoMov = "DP" Then
               If !ChCartId <> 0 Then
                  Cm2.CommandText = "SELECT * FROM ChCartera WHERE ChCartId = " & !ChCartId
                  Dr2 = Cm2.ExecuteReader
                  '
                  If Dr2.Read Then
                     tbBancoCh.Text = CapturaDato(cn, "Bancos", "Nombre", "Banco = " & Dr2!Banco)
                     tbCuentaCh.Text = Dr2!BancoCta
                     tbNumeroCh.Text = Dr2!ChCartNro
                     tbImporteCh.Text = Format(Dr2!Importe, "Fixed")
                     PosCboItem(cbCaja, Dr2!Caja)
                  Else
                     MensajeTrad("ChCartNoEnc", , False)
                     DeshabForm(Me)
                  End If
                  Dr2.Close()
               Else
                  'na
               End If
               '
            End If
            '
         Else
            MensajeTrad("MovNoEnc", , False)
            DeshabForm(Me)
         End If
         '
         .Close()
         '
      End With
      '
   End Sub
   '
   Private Sub frmChRechAM_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
      TabReturn(e.KeyChar)
   End Sub
   '
   Private Sub cbDBcoCajaDep_Click()
      'cbBcoCajaDep.ListIndex = cbDBcoCajaDep.ListIndex
   End Sub
   '
   Private Sub cbCaja_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCaja.SelectedIndexChanged
      '
      With cbCaja
         If .SelectedIndex > 0 Then
            Caja = .SelectedValue
         Else
            Caja = -1
         End If
      End With
      '
   End Sub
   '
   Private Sub ArmaControles()
      '
      Select Case cTipoMov
         Case "CH"
            '
         Case "DP"
            '
            tbCuenta.Enabled = False
            cbDescCta.Enabled = False
            '
         Case "DB"
            '
         Case "CR"
            '
         Case "EX"
            '
      End Select
      '
   End Sub
   '
   Private Sub cmdAceptar_Click(sender As Object, e As EventArgs) Handles cmdAceptar.Click
      '
      If dtpFechaRech.Value > Today Then
         MensajeTrad("FecRech>Date")
         dtpFechaRech.Focus()
         Exit Sub
      End If
      '
      If dtpFechaRech.Value < tbFechaAcr.Value Then
         MensajeTrad("FecRech<Acr")
         tbFechaAcr.Focus()
         Exit Sub
      End If
      '
      If tbDetalle.Text = "" Then
         MensajeTrad("DIMotRech")
         tbDetalle.Focus()
         Exit Sub
      End If
      '
      If Guardar() Then
         Me.Close()
      End If
      '
   End Sub
   '
   Private Function Guardar() As Boolean
      '
      Dim BancoMovId As Int32
      Dim TipoCompAj As Byte
      Dim NroAjCtaCte As Int32
      Dim compCaja As String
      Dim nDebe As Double
      Dim nHaber As Double
      '
      Dim CodAsi As String
      Dim NroAsi As Long
      Dim RenASi As Integer
      Dim DetAsi As String
      '
      compCaja = "-" & cTipoMov & "-" & Banco & "-" & BancoCta & "-" & tbNumeroCh.Text
      CodAsi = compCaja
      DetAsi = IIf(tbDetalle.Text <> "", tbDetalle.Text, CodAsi)
      '
      If cTipoMov = "DP" Then
         ChCartID = Val(CapturaDato(cn, "ChCartera", "ChCartId", "Banco = " & Banco & " AND BancoCta = '" & tbCuentaCh.Text & "' AND ChCartNro = '" & tbNumeroCh.Text & "'"))
         If ChCartID = 0 Then
            MensajeTrad("ChCartNoEnc")
         End If
      End If
      '
      If Not IsNothing(CapturaDato(cn, "BancosMov", "Banco", "Banco = " & Banco & " AND BancoCta = '" & BancoCta & "' AND TipoMovBco = " & TipoRech & " AND NroMovBco = " & Val(tbNumeroCh.Text))) Then
         MensajeTrad("MovExiste")
         Exit Function
      End If
      '
      Try
         '
         Trn = cn.BeginTransaction
         '
         With Cmd
            '
            .Transaction = Trn
            .CommandText = "INSERT INTO BancosMov(Banco, BancoCta, TipoMovBco, NroMovBco, FechaEmi, FechaAcr, Debe, Haber, Detalle, ChCartID, Caja, Estado, CtaCont, Usuario, FechaMod) " & _
                           "VALUES(" & Banco & ", " & _
                                 "'" & BancoCta & "', " & _
                                       TipoRech & ", " & _
                                       tbNumeroCh.Text & ", " & _
                                 "'" & Format(tbFechaAcr.Value, FormatFecha) & "', " & _
                                 "'" & Format(dtpFechaRech.Value, FormatFecha) & "', " & _
                                       0 & ", " & _
                                       Val(tbImporteCh.Text) & ", " & _
                                 "'" & tbDetalle.Text & "', " & _
                                       ChCartID & ", " & _
                                       Caja & ", " & _
                                       ESTEMI & ", " & _
                                 "'" & tbCuenta.Text & "', " & _
                                 "'" & Uid & "', " & _
                                 "'" & Format(Now, FormatFechaHora) & "')"
            .ExecuteNonQuery()
            '
            BancoMovId = CapturaDato(cn, "BancosMov", "MAX(BancoMovId)", "", , , , Trn)
            '
         End With
         '
         If SisContable Then
            NroAsi = GuardaAsiento(CodAsi, tbFechaAcr.Value, DetAsi, Trn)
            If NroAsi = 0 Then
               Err.Raise(1001, , "NoUpAsiento")
            End If
            '
            If Not BorraAsienDet(NroAsi, Trn) Then
               Err.Raise(1001, , "NoDelAsiento")
            End If
            '
            RenASi = IIf(cImput = "D", 1, 2)
            If Not GuardaAsienDet(NroAsi, RenASi, CtaCont, DetAsi, nDebe, nHaber, Trn) Then
               Err.Raise(1001, , "NoUpAsiento")
            End If
         End If

         With Cmd
            .CommandText = "UPDATE ChCartera SET " & _
                           " Estado = " & EstRECH & ", " & _
                           " Usuario = '" & Uid & "', " & _
                           " FechaMod = '" & Format(Now, FormatFechaHora) & "' " & _
                           "WHERE Banco = " & Banco & _
                           "  AND BancoCta = '" & tbCuentaCh.Text & "'" & _
                           "  AND ChCartNro = '" & tbNumeroCh.Text & "'"
            .ExecuteNonQuery()
         End With
         '
         If SisContable Then
            RenASi = IIf(cImput = "D", 2, 1)
            If Not GuardaAsienDet(NroAsi, RenASi, cCtaVCar, DetAsi, nHaber, nDebe, Trn) Then
               Err.Raise(1001, , "NoUpAsiento")
            End If
         End If
         '
         If Cliente > 0 Then
            '
            TipoCompAj = Val(CapturaDato(cn, "TipoComp", "TipoComp", "Ajuste <> 0", , , , Trn) & "")
            '
            If TipoCompAj = 0 Then
               Err.Raise(1001, , Traducir("CmpAjNoDef", , Trn))
            End If
            '
            NroAjCtaCte = Val(CapturaDato(cn, "CtaCteCli", "ISNULL(MAX(CliNumero),0)", "TipoComp = " & TipoCompAj, , , , Trn)) + 1
            '
            With Cmd
               BancoMovId = CapturaDato(cn, "BancosMov", "MAX(BancoMovId)", "", , , , Trn)
               .CommandText = "INSERT INTO CtaCteCli( Sucursal, TipoComp, CliLetra, CliNumero, Cliente, Departamento, Fecha, Debe, Haber, Detalle, Pagado, Saldo, BancoMovId, Usuario, FechaMod) " & _
                              "VALUES(" & prmSucursal & ", " & _
                                          TipoCompAj & ", " & _
                                          "'', " & _
                                          NroAjCtaCte & ", " & _
                                          Cliente & ", " & _
                                          prmDepart & ", " & _
                                    "'" & Format(dtpFechaRech.Value, FormatFecha) & "', " & _
                                          tbImporteCh.Text & ", " & _
                                          0 & ", " & _
                                    "'" & Traducir("ChRech", , Trn) & "', " & _
                                          0 & ", " & _
                                          tbImporteCh.Text & ", " & _
                                          BancoMovId & ", " & _
                                    "'" & Uid & "', " & _
                                    "'" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
               '
            End With
         End If
         '
         GuardarAudit("Rechaza Cheque", tbBancoCh.Text & "/" & tbCuentaCh.Text & ": " & tbNumeroCh.Text, Me.Name, "Guardar", Trn)
         '
         Trn.Commit()
         '
         Return True
         '
      Catch ex As Exception
         '
         Dim st As New StackTrace(True)
         RegistrarError(st, Me.Name)
         Trn.Rollback()
         Return False
         '
      End Try
      '
   End Function
   '
   Private Sub tbNumero_KeyPress(KeyAscii As Integer)
      SoloNumeros(KeyAscii, False)
   End Sub
   '
   Private Sub txtCuenta_Change()
      cbDescCta = CapturaDato(cn, "PlanCtas", "Descrip", "CtaCont = '" & tbCuenta.Text & "'")
   End Sub
   '
   Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
      Me.Close()
   End Sub
   '
   Private Sub frmBancosMovAM_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
      SetRegForm(Me)
      Me.Dispose()
   End Sub
   '
End Class