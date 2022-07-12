Public Class frmPropConcAM
   '
   Public Alta As Boolean
   Public Concepto As String
   Public Fecha As Date
   Public Inquilino As Int32
   Public Propiedad As Int32
   '
   Dim aPropiet As Boolean
   Dim Imput As String
   '
   Dim Trn As OleDb.OleDbTransaction
   Dim cmd As New OleDb.OleDbCommand
   Dim Drd As OleDb.OleDbDataReader
   '
   Dim NroCtto As Long
   Dim PerDesde As String
   Dim PerHasta As String
   Dim nMeses As Integer
   Dim Dia As String
   '
   Const cmpInt = "CP"
   '
   Private Sub frmPropConcAM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      '
      GetRegForm(Me)
      '
      TraducirForm(Me)
      '
      tbPropietario.Text = CapturaDato(Cn, "Propietarios", "Nombre", "Codigo = ( SELECT Propietario FROM Propiedades WHERE Codigo = " & Propiedad & ")")
      tbPropiedad.Text = CapturaDato(Cn, "Propiedades", "Domicilio", "Codigo = " & Propiedad)
      '
      ArmaCombo(cbDescConc, "Descrip", "Conceptos", "Descrip", , , "(Seleccionar)")
      ArmaCombo(cbConcepto, "Codigo", "Conceptos", "Descrip", , , "(Seleccionar)")
      '
      PosCombo(cbConcepto, Concepto)
      '
      If Alta Then
         Me.Text = Me.Text & " - " & Traducir("Alta")
         tbImporte.Text = Format(0, "Fixed")
         tbFecDesde.Value = Today
         Fecha = Today
      Else
         Me.Text = Me.Text & " - " & Traducir("Edición")
         With cmd
            .Connection = Cn
            .CommandText = "SELECT * FROM PropiedConc WHERE Propiedad = " & Propiedad & " AND Concepto = '" & Concepto & "' AND FecDesde = " & strFEC & Format(Fecha, FormatFecha) & strFEC
            Drd = .ExecuteReader
            With Drd
               If .Read Then
                  tbDetalle.Text = !Detalle
                  tbImporte.Text = Format(!Importe, "Fixed")
                  optDebe.Checked = IIf(!Imputacion = "D", True, False)
                  optHaber.Checked = IIf(!Imputacion = "H", True, False)
                  optPropiet.Checked = !aPropiet
                  optAdmin.Checked = Not !aPropiet
                  tbFecDesde.Value = !FecDesde
                  tbFecDesde.Enabled = False
                  'cbConcepto.ListIndex = nList
                  cbConcepto.Enabled = False
                  cbDescConc.Enabled = False
                  chkNoInquilino.Checked = IIf(!NoInquilino, 1, 0)
                  If !Automatico Then
                     DeshabForm(Me)
                  End If
               Else
                  MensajeTrad("CodNoEnc")
                  DeshabForm(Me)
               End If
               .Close()
            End With
         End With
      End If
      '
      CaptDatosCtto(Inquilino, Propiedad, NroCtto, PerDesde, PerHasta, nMeses, Dia)
      '
      If NroCtto = 0 And Alta Then
         tbFecDesde.Value = "01/" & PerDesde.Substring(4, 2) + "/" + PerDesde.Substring(0, 4)
      End If
      '
      '            tbFecDesde.Value = "01/" & PerDesde.Substring(4, 2) + "/" + PerDesde.Substring(0, 4)
      '         End If
      'With cmd
      '   .Connection = Cn
      '   .CommandText = "SELECT * FROM Contratos WHERE Inquilino = " & Inquilino & " AND Propiedad = " & Propiedad & " AND Estado = 0"
      '   Drd = .ExecuteReader
      '   '
      '   With Drd
      '      If .Read Then
      '         NroCtto = !Numero
      '         If Alta Then
      '            'dFecDde = "01/" & Right(!PerDesde, 2) & "/" & Left(!PerDesde, 4)
      '         End If
      '         PerDesde = !PerDesde
      '         PerHasta = !PerHasta
      '         nMeses = !Meses
      '         Dia = !DiaVenc
      '      Else
      '         NroCtto = 0
      '         PerDesde = Format(Today, "yyyyMM")
      '         PerHasta = PerDesde
      '         nMeses = 1
      '         Dia = 10
      '         If Alta Then
      '            tbFecDesde.Value = "01/" & PerDesde.Substring(4, 2) + "/" + PerDesde.Substring(0, 4)
      '         End If
      '      End If
      '      .Close()
      '   End With
      'End With
      '
      If PerHasta < Format(Today, "yyyyMM") Then
         PerHasta = Format(Today, "yyyyMM")
      End If
      '
      If aPropiet Then
         optPropiet.Checked = True
         fraAsigna.Enabled = False
      End If
      If Imput <> "" Then
         optDebe = IIf(Imput = "D", True, False)
         optHaber = IIf(Imput = "H", True, False)
         fraImput.Enabled = False
      End If
      '
      If Concepto <> "" Then
         cbConcepto.Enabled = False
         cbDescConc.Enabled = False
      End If
      '
      'FormLoad = True
      '
   End Sub
   '
   Private Sub frmPropConcAM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
      TabReturn(e.KeyChar)
   End Sub
   '
   Private Sub cbConcepto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbConcepto.SelectedIndexChanged
      'If formload Then
      cbDescConc.SelectedIndex = cbConcepto.SelectedIndex
      If Alta Then
         tbDetalle.Text = cbDescConc.Text
      End If
      'End If
   End Sub
   '
   Private Sub cbDescConc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbDescConc.SelectedIndexChanged
      With cbConcepto
         If .Items.Count > 0 Then
            .SelectedIndex = cbDescConc.SelectedIndex
         End If
      End With
   End Sub
   '
   Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
      If ValTb() Then
         Guardar()
      End If
   End Sub
   '
   Private Function ValTb() As Boolean
      '
      If cbConcepto.Text = "" Then
         MensajeTrad("DIConcepto")
         cbConcepto.Focus()
         Exit Function
      Else
         If Alta Then
            If IsNothing(CapturaDato(Cn, "PropiedConc", "Concepto", "Propiedad = " & Propiedad & " AND Concepto = '" & cbConcepto.Text & "' AND FecDesde = " & strFEC & Format(tbFecDesde.Value, FormatFecha) & strFEC)) Then
               'Ok.
            Else
               MensajeTrad("CodFecExiste")
               With cbConcepto
                  If .Enabled Then
                     .Focus()
                  End If
               End With
               Exit Function
            End If
         End If
      End If
      '
      If Val(tbImporte.Text) <= 0 Then
         MensajeTrad("DIV>0")
         tbImporte.Focus()
         Exit Function
      End If
      '
      If Not optDebe.Checked And Not optHaber.Checked Then
         MensajeTrad("DIDebHab")
         Exit Function
      End If
      '
      ValTb = True
      '
   End Function
   '
   Private Sub Guardar()
      '
      Dim nMes As Integer
      Dim nCont As Integer
      Dim cPer As String
      '
      Try
         '
         Trn = Cn.BeginTransaction
         '
         With cmd
            .Connection = Cn
            .Transaction = Trn
            If Alta Then
               .CommandText = "INSERT INTO PropiedConc( Propiedad, Concepto, Detalle, Importe, Imputacion, aPropiet, aPagar, Automatico, NoInquilino, FecDesde, Usuario, FechaMod) " & _
                              "VALUES(" & Propiedad & ", " & _
                                    "'" & cbConcepto.Text & "', " & _
                                    "'" & tbDetalle.Text & "', " & _
                                          tbImporte.Text & ", " & _
                                    "'" & IIf(optDebe.Checked, "D", "H") & "', " & _
                                          IIf(optPropiet.Checked, 1, 0) & ", " & _
                                          0 & ", " & _
                                          0 & ", " & _
                                          IIf(chkNoInquilino.Checked, 1, 0) & ", " & _
                                    "'" & Format(tbFecDesde.Value, FormatFecha) & "', " & _
                                    "'" & Uid & "', " & _
                                    "'" & Format(Now, FormatFechaHora) & "')"
            Else
               .CommandText = "UPDATE PropiedConc SET " & _
                               " Detalle = '" & tbDetalle.Text & "', " & _
                               " Importe = " & tbImporte.Text & ", " & _
                               " Imputacion = '" & IIf(optDebe.Checked, "D", "H") & "', " & _
                               " aPropiet = " & IIf(optPropiet.Checked, 1, 0) & ", " & _
                               " aPagar = 0, " & _
                               " Automatico = 0, " & _
                               " NoInquilino = " & IIf(chkNoInquilino.Checked, 1, 0) & ", " & _
                               " FecDesde = '" & Format(tbFecDesde.Value, FormatFecha) & "', " & _
                               " Usuario = '" & Uid & "', " & _
                               " FechaMod = '" & Format(Now, FormatFechaHora) & "' " & _
                               "WHERE Propiedad = " & Propiedad & " AND Concepto = '" & cbConcepto.Text & "' AND FecDesde = " & strFEC & Format(Fecha, FormatFecha) & strFEC
            End If
            .ExecuteNonQuery()
         End With
         '
         nMes = 1
         nCont = 1
         Do While True
            cPer = CalcPeriodo(tbFecDesde.Value, nCont)
            If cPer > PerHasta Then
               Exit Do
            End If
            If cPer <= PerHasta Then
               If cPer >= Format(cfgFecIniAct, "yyyyMM") Then
                  ActPropConc(cPer, Propiedad, Inquilino, IIf(cPer < PerDesde, 0, nMes), Dia, cbConcepto.Text, Trn)
               End If
               If cPer >= PerDesde Then
                  nMes = nMes + 1
               End If
            End If
            nCont = nCont + 1
         Loop
         '
         If NroCtto <> 0 Then
            If SisContable Then
               If Not ActAsiFactInq(NroCtto, Trn) Then
                  Err.Raise(1001, , Traducir("NoUpAsiento", , Trn))
               End If
            End If
         End If
         '
         GuardarAudit(IIf(Alta, "Alta", "Modif.") & " Concepto Fijo", "Prt: " & tbPropietario.Text & ", Prd: " & tbPropiedad.Text & ", Conc: " & cbConcepto.Text & ", Dde: " & tbFecDesde.Value, Me.Name, "Guardar", Trn)
         '
         Trn.Commit()
         '
         Me.Close()
         '
      Catch ex As Exception
         Trn.Rollback()
         Dim st As New StackTrace(True)
         RegistrarError(st, Me.Name, , Traducir("TrnNoRealizada"), "Guardar")
      End Try
      '
   End Sub
   '
   Private Sub optAdmin_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optAdmin.CheckedChanged
      With chkNoInquilino
         .Checked = False
         .Enabled = False
      End With
   End Sub
   '
   Private Sub optPropiet_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optPropiet.CheckedChanged
      chkNoInquilino.Enabled = True
   End Sub
   '
   Private Sub tbImporte_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbImporte.KeyPress
      SoloNumeros(e.KeyChar, True)
   End Sub
   '
   Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
      Me.Close()
   End Sub
   '
   Private Sub frmPropConcAM_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
      SetRegForm(Me)
      Me.Dispose(True)
      'frmPropConcAM = Nothing
   End Sub
   '
End Class