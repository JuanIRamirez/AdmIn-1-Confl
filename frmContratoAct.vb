Public Class FrmContratoAct
   '
   Public Numero As Int32 = 0
   '
   Dim Trn As OleDb.OleDbTransaction
   Dim Cmd As New OleDb.OleDbCommand
   Dim Drd As OleDb.OleDbDataReader
   '
   Dim Propiedad, Inquilino As Int32
   Dim Escalon, EscalonM, DiaVenc As Byte
   Dim IncrPorc, IncrPorcM As Double
   Dim MesesEsc, MesesEscM As Byte
   Dim Porcent, PorcentM As Single
   Dim CaptCtas As Boolean
   Dim DescAlq, DescIva, cCtaCaja As String
   '
   Dim cTmp As String
   '
   Const cStruct = "Mes SMALLINT NOT NULL, FechaVenc SMALLDATETIME, Importe FLOAT NOT NULL, Iva FLOAT NOT NULL, Porcent REAL NULL"
   '
   Private Sub FrmContratoAct_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      '
      Dim cMes As New Collection
      Dim cFec As New Collection
      Dim i As Byte
      '
      cTmp = ""
      If Not CrearTabla(Cn, cStruct, cTmp) Then
         DeshabForm(Me)
      End If
      '
      If CaptCtasConc(cfgCodigoAlq, DescAlq, "", "") Then
         If CaptCtasConc(cfgCodigoIva, DescIva, "", "") Then
            If SisContable Then
               If CaptCtasCaja(prmNroCaja, cCtaCaja, "") Then
                  CaptCtas = True
               End If
            Else
               CaptCtas = True
            End If
         End If
      End If
      '
      If Not CaptCtas Then DeshabForm(Me)
      '
      With Cmd
         .Connection = Cn
         '
         .CommandText = "INSERT INTO " & cTmp & " SELECT MesesEsc, FechaVenc, Incremento, Iva, Porcent FROM ContratosAct WHERE Numero = " & Numero
         .ExecuteNonQuery()
         '
         .CommandText = "SELECT C.Numero, C.FechaContrato, C.Meses, C.PerDesde, C.PerHasta, P.Nombre, C.Propiedad, R.Domicilio, C.Inquilino, I.Nombre AS InqNom, C.Escalon, E.EscDescrip, E.EscSimbolo, C.MesesEsc, C.Incremento, C.DiaVenc, C.Porcent " &
                        "FROM Contratos C " &
                        "INNER JOIN Propietarios P ON C.Propietario = P.Codigo " &
                        "INNER JOIN Propiedades R ON C.Propiedad = R.Codigo " &
                        "INNER JOIN Inquilinos I ON C.Inquilino = I.Codigo " &
                        "INNER JOIN EscContrato E ON C.Escalon = E.Escalon " &
                        "WHERE C.Numero = " & Numero
         Drd = .ExecuteReader
      End With
      '
      With Drd
         If .Read Then
            tbContrato.Text = !Numero
            tbPropietario.Text = !Nombre
            tbPropiedad.Text = !Domicilio
            tbInquilino.Text = !InqNom
            tbMeses.Text = !Meses
            dtFechaCtto.Value = !FechaContrato
            dtpDesde.Value = "01/" & Strings.Right(!PerDesde, 2) & "/" & Strings.Left(!PerDesde, 4)
            dtpHasta.Value = "01/" & Strings.Right(!PerHasta, 2) & "/" & Strings.Left(!PerHasta, 4)
            tbImpAlq.Text = Val(CapturaDato(Cn, "FactInq", "Importe", "Propiedad = " & !Propiedad & " And Inquilino = " & !Inquilino & " And Concepto = '" & cfgCodigoAlq & "' AND Periodo = '" & !PerDesde & "'") & "")
            tbImpIva.Text = Val(CapturaDato(Cn, "FactInq", "Importe", "Propiedad = " & !Propiedad & " AND Inquilino = " & !Inquilino & " AND Concepto = '" & cfgCodigoIva & "' AND Periodo = '" & !PerDesde & "'") & "")
            tbEscalon.Text = !EscDescrip
            tbEscMeses.Text = !MesesEsc
            tbEscIncr.Text = !Incremento
            Propiedad = !Propiedad
            Inquilino = !Inquilino
            DiaVenc = !DiaVenc
            Porcent = !Porcent
            '
            Escalon = !Escalon
            IncrPorc = !Incremento
            MesesEsc = !MesesEsc
            lblIncrem.Text = "Increm. " & IIf(Porcent > 0, "%", !EscSimbolo)
            '
            EscalonM = Val(CapturaDato(Cn, "ContratosAct", "Escalon", "Numero = " & !Numero,,, "ContratoActId DESC") & "")
            tbEscalonM.Text = CapturaDato(Cn, "EscContrato", "EscDescrip", "Escalon = " & EscalonM) & ""
            tbEscMesesM.Text = CapturaDato(Cn, "ContratosAct", "MesesEsc", "Numero = " & !Numero,,, "ContratoActId DESC") & ""
            tbEscIncrM.Text = CapturaDato(Cn, "ContratosAct", "Incremento", "Numero = " & !Numero,,, "ContratoActId DESC") & ""
            lblIncremm.Text = "Increm. " & CapturaDato(Cn, "EscContrato", "EscSimbolo", "Escalon = " & EscalonM)
            IncrPorcM = Val(CapturaDato(Cn, "ContratosAct", "Incremento", "Numero = " & !Numero,,, "ContratoActId DESC") & "")
            MesesEscM = Val(CapturaDato(Cn, "ContratosAct", "MesesEsc", "Numero = " & !Numero,,, "ContratoActId DESC") & "")
            PorcentM = CapturaDato(Cn, "ContratosAct", "Porcent", "Numero = " & Numero)
            '
         End If
         .Close()
         '
      End With
      '
      With Cmd
         .CommandText = "SELECT * FROM " & cTmp & " ORDER BY Mes"
         Drd = .ExecuteReader
         With Drd
            Do While .Read
               cMes.Add(!Mes)
               cFec.Add(dtpDesde.Value.AddMonths(!Mes - 1))
            Loop
            .Close()
         End With
         For i = 1 To cFec.Count
            .CommandText = "UPDATE " & cTmp & " SET FechaVenc = '" & Format(cFec(i), FormatFecha) & "' WHERE Mes = " & cMes(i)
            .ExecuteNonQuery()
         Next
         '
      End With
      '
   End Sub
   '
   Private Sub btnModif_Click(sender As Object, e As EventArgs) Handles btnModif.Click
      Dim Frm As New frmContratoEsc
      With Frm
         .TablaTmp = cTmp
         .Comercial = Not IsNothing(CapturaDato(Cn, "PropiedConc", "Concepto", "Propiedad = " & Propiedad & " AND Concepto = '" & cfgCodigoIva & "' AND FecDesde >= '" & Format(dtpDesde.Value, FormatFecha) & "' AND FecDesde <= '" & Format(dtpHasta.Value, FormatFecha) & "'"))
         .AlicIva1 = cfgAlicIva
         .AlicIva2 = 0
         .ImpAlq = Val(tbImpAlq.Text)
         .Meses = Val(tbMeses.Text)
         .FecIni = dtpDesde.Value
         .Escalon = Escalon
         .IncrPorc = IncrPorc
         .MesesEsc = MesesEsc
         .Porcent = Porcent
         .ShowDialog(Me)
         EscalonM = .Escalon
         tbEscalonM.Text = CapturaDato(Cn, "EscContrato", "EscDescrip", "Escalon = " & EscalonM)
         tbEscIncrM.Text = .IncrPorc
         tbEscMesesM.Text = .MesesEsc
         PorcentM = .Porcent
         lblIncremm.Text = "Increm. " & IIf(PorcentM > 0, "%", CapturaDato(Cn, "EscContrato", "EscSimbolo", "Escalon = " & Escalon))
         If tbEscalonM.Text <> tbEscalon.Text Or tbEscMesesM.Text <> tbEscMeses.Text Or tbEscIncrM.Text <> tbEscIncr.Text Then
            cmdAceptar.Enabled = True
         Else
            cmdAceptar.Enabled = False
         End If
      End With
   End Sub
   '
   Private Sub CmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
      Me.Close()
   End Sub
   '
   Private Sub CmdAceptar_Click(sender As Object, e As EventArgs) Handles cmdAceptar.Click
      '
      Dim i As Byte
      Dim ImpAlqMes As Double
      Dim ImpAlqAnt As Double = 0
      Dim ImpIvaMes As Double
      Dim ImpIvaAnt As Double = 0
      Dim ContMes As Byte = 0
      Dim dFecDde As Date
      Dim cPer As String
      Dim Drd As OleDb.OleDbDataReader
      Dim cMes As New Collection
      Dim cImp As New Collection
      Dim cPor As New Collection
      Dim cIva As New Collection
      Dim cFec As New Collection
      Dim nImp As Double = 0.0
      '
      Trn = Cn.BeginTransaction
      '
      With Cmd
         '
         .Connection = Cn
         .Transaction = Trn
         '
         .CommandText = "DELETE FROM ContratosAct WHERE Numero = " & Numero
         .ExecuteNonQuery()
         '
         If Escalon = 4 Then
            .CommandText = "SELECT * from " & cTmp & " ORDER BY Mes"
            Drd = .ExecuteReader
            With Drd
               Do While .Read
                  If !Importe <> nImp Then
                     cMes.Add(!Mes)
                     cImp.Add(!Importe)
                     cIva.Add(!Iva)
                     cFec.Add(!FechaVenc)
                     cPor.Add(!Porcent)
                     nImp = !Importe
                  End If
               Loop
               .Close()
            End With
            For i = 1 To cMes.Count
               .CommandText = "INSERT INTO ContratosAct( [Numero], [Escalon], [MesesEsc], [Incremento], [Iva], [FechaVenc], [Porcent], [Usuario], [FechaMod]) " &
                              "VALUES( " & Numero & ", " & EscalonM & ", " & cMes(i) & ", " & cImp(i) & ", " & cIva(i) & ", '" & Format(cFec(i), FormatFecha) & "', " & Val(cPor(i) & "") & ", '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
            Next
         Else
            .CommandText = "INSERT INTO [dbo].[ContratosAct]( [Numero], [Escalon], [MesesEsc], [Incremento], [Iva], Porcent, [Usuario], [FechaMod]) " &
                           "VALUES( " & Numero & ", " & EscalonM & ", " & tbEscMesesM.Text & ", " & tbEscIncrM.Text & ", 0, " & PorcentM & ", '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
            .ExecuteNonQuery()
         End If
         '
         For i = 1 To tbMeses.Text
            '
            ImpAlqMes = CapturaDato(Cn, cTmp, "Importe", "Mes = " & i, , , , Trn)
            dFecDde = CapturaDato(Cn, cTmp, "FechaVenc", "Mes = " & i, , , , Trn)
            '
            If ImpAlqMes > 0 Then
               If ImpAlqMes <> ImpAlqAnt Then
                  '
                  If IsNothing(CapturaDato(Cn, "PropiedConc", "Concepto", "Propiedad = " & Propiedad & " AND Concepto = '" & cfgCodigoAlq & "' AND FecDesde = '" & Format(dFecDde, FormatFecha) & "'", , , , Trn)) Then
                     .CommandText = "INSERT INTO PropiedConc( Propiedad, Concepto, FecDesde, Automatico, Detalle, Importe, Imputacion, aPropiet, aPagar, NoInquilino, Usuario, FechaMod) " &
                                    "VALUES(" & Propiedad & ", " &
                                          "'" & cfgCodigoAlq & "', " &
                                          "'" & Format(dFecDde, FormatFecha) & "', " &
                                                1 & ", " &
                                          "'" & DescAlq & "', " &
                                                ImpAlqMes & ", " &
                                          "'" & "D" & "', " &
                                                1 & ", " &
                                                0 & ", " &
                                                0 & ", " &
                                          "'" & Uid & "', " &
                                          "'" & Format(Now, FormatFechaHora) & "')"
                  Else
                     .CommandText = "UPDATE PropiedConc SET " &
                                    " Automatico = 1, " &
                                    " Detalle = '" & DescAlq & "', " &
                                    " Importe = " & ImpAlqMes & ", " &
                                    " Imputacion = 'D', " &
                                    " aPropiet = 1, " &
                                    " aPagar = 0, " &
                                    " NoInquilino = 0, " &
                                    " Usuario = '" & Uid & "', " &
                                    " Fechamod = '" & Format(Now, FormatFechaHora) & "' " &
                                    "WHERE Propiedad = " & Propiedad & " AND Concepto = '" & cfgCodigoAlq & "' AND FecDesde = '" & Format(dFecDde, FormatFecha) & "'"
                     '
                  End If
                  '
                  .ExecuteNonQuery()
                  '
                  ImpAlqAnt = ImpAlqMes
                  '
               End If
            End If
            '
            If Val(tbImpIva.Text) > 0 Then
               ImpIvaMes = CapturaDato(Cn, cTmp, "Iva", "Mes = " & i, , , , Trn)
               '
               If ImpIvaMes > 0 Then
                  If ImpIvaMes <> ImpIvaAnt Then
                     If ImpAlqMes > cfgMaxAlqSIva Then
                        If IsNothing(CapturaDato(Cn, "PropiedConc", "Concepto", "Propiedad = " & Propiedad & " AND Concepto = '" & cfgCodigoIva & "' AND Automatico <> 0 AND FecDesde = '" & Format(dFecDde, FormatFecha) & "'", , , , Trn)) Then
                           .CommandText = "INSERT INTO PropiedConc( Propiedad, Concepto, FecDesde, Automatico, Detalle, Importe, Imputacion, aPropiet, aPagar, NoInquilino, Usuario, FechaMod) " &
                                          "VALUES(" & Propiedad & ", " &
                                                "'" & cfgCodigoIva & "', " &
                                                "'" & Format(dFecDde, FormatFecha) & "', " &
                                                      1 & ", " &
                                                "'" & DescIva & "', " &
                                                      ImpIvaMes & ", " &
                                                "'" & "D" & "', " &
                                                      1 & ", " &
                                                      0 & ", " &
                                                      0 & ", " &
                                                "'" & Uid & "', " &
                                             "'" & Format(Now, FormatFechaHora) & "')"
                        Else
                           .CommandText = "UPDATE PropiedConc SET " &
                                          " Automatico = 1, " &
                                          " Detalle = '" & DescIva & "', " &
                                          " Importe = " & ImpIvaMes & ", " &
                                          " Imputacion = 'D', " &
                                          " aPropiet = 1, " &
                                          " aPagar = 0, " &
                                          " NoInquilino = 0, " &
                                          " Usuario = '" & Uid & "', " &
                                          " Fechamod = '" & Format(Now, FormatFechaHora) & "' " &
                                          "WHERE Propiedad = " & Propiedad & " AND Concepto = '" & cfgCodigoIva & "' AND Automatico <> 0 AND FecDesde = '" & Format(dFecDde, FormatFecha) & "'"
                        End If
                        '
                        .ExecuteNonQuery()
                        '
                        ImpIvaAnt = ImpIvaMes
                        '
                     End If
                  End If
               End If
            End If
            '
            'dFecDde = SumaMes(dFecDde, 1)
            ContMes = ContMes + 1
            '
         Next i
         '
         For i = 1 To Val(tbMeses.Text)
            cPer = CalcPeriodo(dtpDesde.Value, i)
            ActPropConc(cPer, Propiedad, Inquilino, i, DiaVenc, , Trn)
         Next i
         '
         'Asientos.
         If SisContable Then
            If Not ActAsiFactInq(Numero, Trn) Then
               Err.Raise(1001, , "NoUpAsiento")
            End If
         End If
         '
         GuardarAudit("Actualización de Contrato", tbPropietario.Text & " - " & tbInquilino.Text & " - Nº " & Numero, Me.Name, cmdAceptar.Text, Trn)
         '
         Trn.Commit()
         '
      End With
      '
      Mensaje("Contrato Actualizado")
      '
      Me.Close()
      '
   End Sub
   '
   Private Sub FrmContratoAct_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
      EliminaTmp(Cn, cTmp)
   End Sub
   '
End Class