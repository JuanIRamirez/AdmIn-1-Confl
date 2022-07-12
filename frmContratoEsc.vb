Public Class frmContratoEsc
   '
   Public TablaTmp As String
   Public ImpAlq As Double
   Public Meses As Integer
   Public FecIni As Date
   Public AlicIva1 As Single
   Public AlicIva2 As Single
   Public Comercial As Boolean
   '
   Public Escalon As Integer
   Public IncrPorc As Double
   Public MesesEsc As Integer
   '
   Dim FormLoad As Boolean = False
   Dim AlqMes As New Collection
   '
   Dim Trn As OleDb.OleDbTransaction
   Dim Cmd As New OleDb.OleDbCommand
   '
   Dim cTmp As String
   Dim cTmpM As String       '*** Temporal opción manual.
   Const cStruct = "Mes SMALLINT NOT NULL, FechaVenc SMALLDATETIME, Importe FLOAT NOT NULL, Iva FLOAT NOT NULL, Porcent REAL NULL"
   Const cStrucM = "MesDesde SMALLINT NOT NULL, FechaVenc SMALLDATETIME, Importe FLOAT NOT NULL, Iva FLOAT NOT NULL, Porcent REAL NULL"    '*** Estructura opción manual.
   '
   Private Sub frmContratoEsc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      '
      Dim MesEsc As Integer
      Dim i As Int16
      '
      cTmp = ""
      cTmpM = ""
      If Not CrearTabla(Cn, cStruct, cTmp) Then
         DeshabForm(Me)
      Else
         '
         Trn = Cn.BeginTransaction
         '
         With Cmd
            .Connection = Cn
            .Transaction = Trn
            .CommandText = "INSERT INTO " & cTmp & "( Mes, FechaVenc, Importe, Iva, Porcent) " &
                           "SELECT Mes, FechaVenc, Importe, Iva, Porcent FROM " & TablaTmp
            .ExecuteNonQuery()
            '
            Cmd.CommandText = "DELETE FROM " & cTmp & " WHERE Mes > " & Meses
            Cmd.ExecuteNonQuery()
            '
         End With
         '
         Trn.Commit()
         '
         If CrearTabla(Cn, cStrucM, cTmpM) Then

         Else
            DeshabForm(Me)
         End If
         '
      End If
      '
      MesEsc = MesesEsc
      '
      UpDown1.Maximum = Meses
      '
      For i = 0 To Meses - 1
         AlqMes.Add(ImpAlq)
      Next i
      '
      txtImpAlq.Text = ImpAlq
      '
      If Escalon = 0 Then
         optUniforme.Checked = True
      ElseIf Escalon = 1 Then
         optIncremental.Checked = True
      ElseIf Escalon = 2 Then
         optBloques.Checked = True
      ElseIf Escalon = 3 Then
         optPorcent.Checked = True
      Else
         optManual.Checked = True
      End If
      '
      If Not optManual.Checked Then
         UpDown1.Value = MesEsc   ' txtMeses = MesEsc
         txtImpPorc.Text = Math.Abs(IncrPorc)
         If IncrPorc >= 0 Then
            optAumenta.Checked = True
         Else
            optDisminuye.Checked = True
         End If
      End If
      '
      FormLoad = True
      '
      If Escalon = 4 Then
         Opt_Escalon()
      Else
         Actualizar()
      End If
      '
      ActivaCtrl()
      '
   End Sub
   '
   Private Sub optUniforme_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optUniforme.CheckedChanged
      Opt_Escalon()
   End Sub
   '
   Private Sub Opt_Escalon()
      optImp.Enabled = True
      If optUniforme.Checked Then
         Escalon = 0
         txtImpPorc.Text = 0
      ElseIf optIncremental.Checked Then
         Escalon = 1
         With UpDown1
            .Minimum = 1
            .Maximum = 1
            .Value = 1
         End With
      ElseIf optBloques.Checked Then
         Escalon = 2
         With UpDown1
            .Minimum = 2
            .Maximum = Int(Meses / 2)
            If Val(.Value) < .Minimum Then
               .Value = .Minimum
            End If
         End With
      ElseIf optPorcent.Checked Then
         Escalon = 3
         With UpDown1
            .Minimum = 1
            .Maximum = Int(Meses / 2)
            .Value = 1
         End With
         optPorc.Checked = True
         optImp.Enabled = False
      Else
         Escalon = 4
         With UpDown1
            .Minimum = 1
            .Maximum = Meses
            .Value = 1
         End With
         txtImpPorc.Text = 0
         ActTmpManual()
      End If
      ActData()
      ActivaCtrl()
   End Sub
   '
   Private Sub optIncremental_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optIncremental.CheckedChanged
      Opt_Escalon()
   End Sub
   '
   Private Sub optBloques_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optBloques.CheckedChanged
      Opt_Escalon()
   End Sub
   '
   Private Sub optPorcent_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optPorcent.CheckedChanged
      Opt_Escalon()
   End Sub
   '
   Private Sub optManual_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optManual.CheckedChanged
      Opt_Escalon()
   End Sub
   '
   Private Sub ActTmpManual()
      '
      If Not FormLoad Then Exit Sub
      '
      Dim Rs2 As New OleDb.OleDbCommand
      Dim Dr2 As OleDb.OleDbDataReader
      '
      Dim ImpAnt As Double
      '
      With Cmd
         .CommandText = "DELETE FROM " & cTmpM
         .ExecuteNonQuery()
      End With
      '
      If optManual.Checked Then
         With Rs2
            .Connection = Cn
            .CommandText = "SELECT * FROM " & cTmp & " ORDER BY Mes"
            Dr2 = .ExecuteReader
         End With
         With Dr2
            Do While .Read
               If !Importe <> ImpAnt Then
                  Cmd.CommandText = "INSERT INTO " & cTmpM & "( MesDesde, FechaVenc, Importe, Iva, Porcent) " &
                                    "VALUES( " & !Mes & ", '" & !FechaVenc & "', " & !Importe & ", " & !Iva & ", " & Val(!Porcent & "") & ")"
                  Cmd.ExecuteNonQuery()
                  ImpAnt = !Importe
               End If
            Loop
            .Close()
         End With
      End If
      '
   End Sub
   '
   Private Sub ActData()
      '
      If Not FormLoad Then Exit Sub
      '
      Dim cSql As String
      '
      If optManual.Checked Then
         cSql = "SELECT * FROM " & cTmpM & " ORDER BY MesDesde"
      Else
         cSql = "SELECT * FROM " & cTmp & " ORDER BY Mes"
      End If
      '
      SetRegGrid(Me, DataGridView1)
      '
      LlenarGrid(DataGridView1, cSql)
      '
      GetRegGrid(Me, DataGridView1)
      '
   End Sub
   '
   Private Sub ActivaCtrl()
      Frame2.Enabled = Not optUniforme.Checked
      'UpDown1.Enabled = Not optIncremental.Checked
      UpDown1.Enabled = Not optIncremental.Checked   'And Not optManual.Checked
      'lblImpPorc.Text = IIf(optPorcent.Checked, "Porcentaje %", "Importe $")
      'DataGridView1.Enabled = optManual.Checked
      lblMes.Text = IIf(Me.optManual.Checked, "Desde mes:", "Cada:")
      lblMeses.Text = IIf(Me.optManual.Checked, "", "meses")
      optAumenta.Enabled = Not optManual.Checked
      optDisminuye.Enabled = Not optManual.Checked
   End Sub
   '
   Private Sub cmdActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdActualizar.Click
      Actualizar()
   End Sub
   '
   Private Function Actualizar() As Boolean
      '
      Dim Cont As Integer
      Dim ImpAnt As Double
      Dim ImpMes As Double
      Dim ImpIva As Double
      Dim Porcent As Single
      Dim cSql As String
      Dim i As Int16
      Dim FechaVenc As Date = FecIni
      '
      If Escalon > 0 Then
         If Val(txtImpPorc.Text) = 0 Then
            If FormLoad Then
               Mensaje("Ingrese un valor mayor que cero")
               txtImpPorc.Focus()
            End If
            Exit Function
         End If
      End If
      '
      If optIncremental.Checked Or optBloques.Checked Or optPorcent.Checked Then
         If Val(txtImpPorc.Text) = 0 Then
            Mensaje(IIf(optPorcent.Checked, "Porcentaje", "Incremento") & " debe ser distinto de cero")
            txtImpPorc.Focus()
            Exit Function
         ElseIf Val(txtImpPorc.Text) > 100 Then
            If optPorcent.Checked Then
               Mensaje("Porcentaje no puede ser mayor a 100")
               txtImpPorc.Focus()
               Exit Function
            End If
         End If
      End If
      '

      For i = AlqMes.Count To 1 Step -1
         AlqMes.Remove(i)
      Next i
      '
      If optManual.Checked Then
         If UpDown1.Value = 1 Then
            If optPorc.Checked Then
               Mensaje("No se puede aplicar porcentaje en el 1º mes")
               Exit Function
            End If
         End If
      End If
      '
      If optManual.Checked Then
         If UpDown1.Value <> 0 Then
            If optPorc.Checked Then
               ImpAnt = Val(CapturaDato(Cn, cTmpM, "TOP 1 Importe", "MesDesde < " & UpDown1.Value,,, "MesDesde DESC") & "")
               Porcent = Val(txtImpPorc.Text)
               ImpMes = Math.Round(ImpAnt * (1 + Porcent / 100), 2)
            Else
               Porcent = 0
               ImpMes = Val(txtImpPorc.Text)
            End If
            '
            ImpIva = IIf(Comercial And ImpMes > cfgMaxAlqSIva, Math.Round(Val(ImpMes) * (AlicIva1 + AlicIva2) / 100, 2), 0)
            '
            FechaVenc = FechaVenc.AddMonths(UpDown1.Value - 1)
            '
            If IsNothing(CapturaDato(Cn, cTmpM, "MesDesde", "MesDesde = " & UpDown1.Value)) Then
               cSql = "INSERT INTO " & cTmpM & "( MesDesde, FechaVenc, Importe, Iva, Porcent) " &
                      "VALUES (" & UpDown1.Value & ", '" & Format(FechaVenc, FormatFechaHora) & "', " & ImpMes & ", " & ImpIva & ", " & Porcent & ")"
            Else
               cSql = "UPDATE " & cTmpM & " SET " &
                      " FechaVenc = '" & Format(FechaVenc, FormatFechaHora) & "', " &
                      " Importe = " & ImpMes & ", " &
                      " Iva = " & ImpIva & ", " &
                      " Porcent = " & Porcent & " " &
                      "WHERE MesDesde = " & UpDown1.Value
            End If
            '
            Trn = Cn.BeginTransaction
            With Cmd
               .Transaction = Trn
               .CommandText = cSql
               .ExecuteNonQuery()
            End With
            Trn.Commit()
            '
            ActcTmp()
            '
         End If
      Else
         For i = 1 To Meses
            If optUniforme.Checked Or i = 1 Then
               AlqMes.Add(Val(txtImpAlq.Text))
               ImpMes = Val(txtImpAlq.Text)
               ImpAnt = AlqMes.Item(i)
               ImpIva = IIf(Comercial And ImpMes > cfgMaxAlqSIva, Math.Round(Val(ImpMes) * (AlicIva1 + AlicIva2) / 100, 2), 0)
               'Cn.Execute "UPDATE " & cTmp & " SET Importe = " & Val(txtImpAlq) & " WHERE Mes = " & i
            Else
               If optIncremental.Checked Then
                  '
                  If optPorc.Checked Then
                     'ImpAnt = Val(CapturaDato(Cn, cTmpM, "TOP 1 Importe", "MesDesde < " & UpDown1.Value,,, "MesDesde DESC") & "")
                     Porcent = Val(txtImpPorc.Text)
                     'ImpMes = Math.Round(ImpAnt * (1 + Porcent / 100), 2)
                     If optAumenta.Checked Then
                        ImpMes = ImpAnt * (1 + Porcent / 100)
                     Else
                        ImpMes = ImpAnt * (1 - Porcent / 100)
                     End If
                  Else
                     Porcent = 0
                     ImpMes = ImpAnt + IIf(optAumenta.Checked, Val(txtImpPorc.Text), -Val(txtImpPorc.Text))
                  End If
                  '
                  'ImpMes = ImpAnt + IIf(optAumenta.Checked, Val(txtImpPorc.Text), -Val(txtImpPorc.Text))
                  AlqMes.Add(ImpMes)
                  ImpAnt = ImpMes
                  'Cn.Execute "UPDATE " & cTmp & " SET Importe = " & ImpMes & " WHERE Mes = " & i
                  '
               ElseIf optBloques.Checked Then
                  If optBloques.Checked Then
                     If Cont = UpDown1.Value Then
                        ImpMes = ImpAnt + IIf(optAumenta.Checked, Val(txtImpPorc.Text), -Val(txtImpPorc.Text))
                        ImpAnt = ImpMes
                        Cont = 0
                     Else
                        ImpMes = ImpAnt
                     End If
                     AlqMes.Add(ImpMes)
                     'Cn.Execute "UPDATE " & cTmp & " SET Importe = " & ImpMes & " WHERE Mes = " & i
                  End If
               ElseIf optPorcent.Checked Then
                  If Cont = UpDown1.Value Then
                     ImpMes = Math.Round(ImpAnt + ImpAnt * IIf(optAumenta.Checked, Val(txtImpPorc.Text), -Val(txtImpPorc.Text)) / 100, 2)
                     'AlqMes.Add ImpMes
                     ImpAnt = ImpMes
                     Cont = 0
                  Else
                     ImpMes = ImpAnt
                  End If
                  AlqMes.Add(ImpMes)
                  'Cn.Execute "UPDATE " & cTmp & " SET Importe = " & ImpMes & " WHERE Mes = " & i
               End If
               '
               If ImpMes > 0 Then
                  '
                  ImpIva = IIf(Comercial And ImpMes > cfgMaxAlqSIva, Math.Round(Val(ImpMes) * (AlicIva1 + AlicIva2) / 100, 2), 0)
                  '
               Else
                  Mensaje("El incremento ingresado genera importes en cero, cambie el incremento.")
                  ImpIva = 0
                  txtImpPorc.Text = 0
                  txtImpPorc.Focus()
                  Exit Function
               End If
            End If
            '
            Trn = Cn.BeginTransaction
            '
            With Cmd
               .Transaction = Trn
               If IsNothing(CapturaDato(Cn, cTmp, "Mes", "Mes = " & i, , , , Trn)) Then
                  .CommandText = "INSERT INTO " & cTmp & "( Mes, FechaVenc, Importe, Iva, Porcent) " &
                                 "VALUES (" & i & ", '" & Format(FechaVenc, FormatFecha) & "', " & ImpMes & ", " & ImpIva & ", " & Porcent & ")"
               Else
                  .CommandText = "UPDATE " & cTmp & " SET " &
                                 " FechaVenc = '" & Format(FechaVenc, FormatFecha) & "', " &
                                 " Importe = " & ImpMes & ", " &
                                 " Iva = " & ImpIva & ", " &
                                 " Porcent = " & Porcent & " " &
                                 "WHERE Mes = " & i
               End If
               .ExecuteNonQuery()
               FechaVenc = FechaVenc.AddMonths(1)
            End With
            '
            Trn.Commit()
            '
            Cont = Cont + 1
            '
         Next i
      End If
      '
      If Not IsNothing(cTmp) Then
         ImpAlq = CapturaDato(Cn, cTmp, "Importe", "Mes=1")
      End If
      '
      ActData()
      Actualizar = True
      '
   End Function
   '
   Private Sub cmdEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEliminar.Click
      Trn = Cn.BeginTransaction
      Cmd.Transaction = Trn
      Cmd.CommandText = "DELETE FROM " & cTmpM & " WHERE MesDesde = " & UpDown1.Value
      Cmd.ExecuteNonQuery()
      Trn.Commit()
      ActcTmp()
      ActData()
   End Sub
   '
   Private Sub ActcTmp()
      '
      If Not FormLoad Then Exit Sub
      '
      Trn = Cn.BeginTransaction
      '
      Dim Cmd As New OleDb.OleDbCommand
      Dim Cm2 As New OleDb.OleDbCommand
      Dim Dr As OleDb.OleDbDataReader
      '
      With Cmd
         .Connection = Cn
         .Transaction = Trn
         .CommandText = "SELECT * FROM " & cTmpM & " ORDER BY MesDesde"
         Dr = .ExecuteReader
      End With
      '
      With Dr
         Do While .Read
            cm2.Connection = Cn
            cm2.Transaction = Trn
            Cm2.CommandText = "UPDATE " & cTmp & " SET " &
                              " Importe = " & !Importe & ", " &
                              " Iva = " & !Iva & ", " &
                              " Porcent = " & !Porcent & " " &
                              "WHERE Mes >= " & !MesDesde
            Cm2.ExecuteNonQuery()
         Loop
         .Close()
      End With
      '
      Trn.Commit()
      '
   End Sub
   '
   Private Sub txtImpAlq_GotFocus()
      'PintarTb(txtImpAlq)
   End Sub
   '
   Private Sub txtImpPorc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtImpPorc.TextChanged
      If optPorc.Checked Then
         If Val(txtImpPorc.Text) > 250 Then
            Mensaje("Porcentaje muy alto")
            txtImpPorc.Text = ""
         End If
      End If
      IncrPorc = Val(txtImpPorc.Text) * IIf(optAumenta.Checked, 1, -1)
      'Actualizar()
   End Sub
   '
   Private Sub txtImpPorc_GotFocus()
      'PintarTb(txtImpPorc)
   End Sub

   Private Sub txtImpPorc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtImpPorc.KeyPress
      SoloNumeros(e.KeyChar, True)
      If e.KeyChar = Chr(13) Then
         Actualizar()
         With UpDown1
            If .Enabled Then
               .Focus()
            End If
         End With
      End If
   End Sub
   '
   Private Sub UpDown1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpDown1.ValueChanged
      MesesEsc = UpDown1.Value
   End Sub
   '
   Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
      If Validar() Then
         Trn = Cn.BeginTransaction
         With Cmd
            .Transaction = Trn
            .CommandText = "DELETE FROM " & TablaTmp
            .ExecuteNonQuery()
            .CommandText = "INSERT INTO " & TablaTmp & "( Mes, FechaVenc, Importe, Iva, Porcent) " &
                           "SELECT Mes, FechaVenc, Importe, Iva, Porcent FROM " & cTmp
            .ExecuteNonQuery()
         End With
         Trn.Commit()
         '
         Me.Close()
         '
      End If
   End Sub
   '
   Private Function Validar() As Boolean
      If Escalon = 0 Then
         Return True
      Else
         If CapturaDato(Cn, cTmp, "COUNT(1)", "") = 0 Then
            Return False
         Else
            Return True
         End If
      End If
   End Function
   '
   Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
      Me.Close()
   End Sub
   '
   Private Sub frmContratoEsc_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
      EliminaTmp(Cn, cTmp)
      EliminaTmp(Cn, cTmpM)
      SetRegForm(Me)
      Me.Dispose()
   End Sub
   '
End Class