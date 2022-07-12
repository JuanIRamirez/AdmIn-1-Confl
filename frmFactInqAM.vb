Public Class frmFactInqAM
   '
   Public Periodo As String = ""
   Public Propiedad As Long
   Public Concepto As String
   Public Inquilino As Long
   Public MesPago As Integer
   Public aPropiet As Boolean
   '
   Dim Tr As OleDb.OleDbTransaction
   Dim Rs As New OleDb.OleDbCommand
   Dim Dr As OleDb.OleDbDataReader

   '
   Dim cDia As String
   Dim NroCtto As Long
   '
   Private Sub frmFactInqAM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      '
      GetRegForm(Me)
      '
      TraducirForm(Me)
      '
      Rs.Connection = Cn
      '
      If Propiedad = 0 Then
         NroCtto = 0
         cDia = "10"
      Else
         With Rs
            .CommandText = "SELECT * FROM Contratos WHERE Inquilino = " & Inquilino & " AND Propiedad = " & Propiedad & " AND Estado = 0 ORDER BY FechaContrato DESC"
            Dr = .ExecuteReader
            With Dr
               If .Read Then
                  NroCtto = !Numero
                  cDia = !DiaVenc
               End If
               .Close()
            End With
         End With
      End If
      '
      tbPropiedad.Text = CapturaDato(Cn, "Propiedades", "Domicilio", "Codigo = " & Propiedad)
      tbPropietario.Text = CapturaDato(Cn, "Propietarios", "Nombre", "Codigo = (SELECT Propietario FROM Propiedades WHERE Codigo = " & Propiedad & ")")
      tbInquilino.Text = CapturaDato(Cn, "Inquilinos", "Nombre", "Codigo = " & Inquilino)
      '
      If Periodo.Length > 0 Then
         tbPeriodo.Text = Periodo.Substring(4, 2) & "/" & Periodo.Substring(0, 4)
      End If
      '
      With dtFecha
         .MinDate = CDate("01/" & tbPeriodo.Text)
         .Value = .MinDate
      End With
      '
      ArmaCombo(cbConcepto, "Codigo", "Conceptos", "Descrip", , , "(Seleccionar")
      ArmaCombo(cbDescConc, "Descrip", "Conceptos", "Descrip", , , "(Seleccionar")
      '
      PosCombo(cbConcepto, Concepto)
      '
      With Rs
         If Concepto = "" Or Propiedad = 0 Then
            Me.Text = Me.Text & " - Alta"
         Else
            Me.Text = Me.Text & " - Edición"
            .CommandText = "SELECT * FROM FactInq WHERE Periodo = '" & Periodo & "' AND Propiedad = " & Propiedad & " AND Concepto = '" & Concepto & "'"
            Dr = .ExecuteReader
            With Dr
               If .Read Then
                  If dtFecha.MinDate > !Fecha Then
                     dtFecha.MinDate = !Fecha
                  End If
                  dtFecha.Value = !Fecha
                  tbDetalle.Text = !Detalle & ""
                  optDebe.Checked = (!Imputacion = "D")
                  optHaber.Checked = (!Imputacion = "H")
                  tbImporte.Text = Format(!Importe, "Fixed")
                  optPropiet.Checked = !aPropiet
                  optAdmin.Checked = Not !aPropiet
                  cbConcepto.Enabled = False
                  cbDescConc.Enabled = False
               Else
                  MensajeTrad("CodNoEnc")
                  DeshabForm(Me)
               End If
               .Close()
            End With
         End If
      End With
      '
   End Sub
   '
   Private Sub frmFactInqAM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
      TabReturn(e.KeyChar)
   End Sub
   '
   Private Sub cbConcepto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbConcepto.SelectedIndexChanged
      If cbDescConc.Items.Count > 0 Then
         cbDescConc.SelectedIndex = cbConcepto.SelectedIndex
         tbDetalle.Text = cbDescConc.Text
      End If
   End Sub
   '
   Private Sub cbDescConc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbDescConc.SelectedIndexChanged
      If cbConcepto.Items.Count > 0 Then
         cbConcepto.SelectedIndex = cbDescConc.SelectedIndex
      End If
   End Sub
   '
   Private Sub btAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAceptar.Click
      '
      If cbConcepto.SelectedIndex <= 0 Or cbDescConc.SelectedIndex <= 0 Then
         MensajeTrad("DIConcepto")
         cbDescConc.Focus()
         Exit Sub
      End If
      '
      If Not optDebe.Checked And Not optHaber.Checked Then
         MensajeTrad("DIDebHab")
         optDebe.Focus()
         Exit Sub
      End If
      '
      If Val(tbImporte.Text) <= 0 Then
         MensajeTrad("DII>0")
         tbImporte.Focus()
         Exit Sub
      End If
      '
      With Rs
         If Concepto = "" Or Propiedad = 0 Then
            If Not IsNothing(CapturaDato(Cn, "FactInq", "Periodo", "Periodo = '" & Periodo & "' AND Propiedad = " & Propiedad & " " & IIf(Propiedad = 0, "AND Inquilino = " & Inquilino, "") & " AND Concepto = '" & cbConcepto.Text & "'")) Then
               MensajeTrad("Concepto utilizado en el Período")
               cbDescConc.Focus()
               Exit Sub
            End If
         End If
      End With
      '
      Try
         '
         Tr = Cn.BeginTransaction
         '
         With Rs
            '
            .Transaction = Tr
            '
            .CommandText = "DELETE FROM FactInq WHERE Periodo = '" & Periodo & "' AND Propiedad = " & Propiedad & " " & IIf(Propiedad = 0, "AND Inquilino = " & Inquilino, "") & " AND Concepto = '" & cbConcepto.Text & "'"
            .ExecuteNonQuery()
            '
            .CommandText = "INSERT INTO FactInq( Periodo, Propiedad, Inquilino, Concepto, Fecha, Detalle, Importe, Saldo, aPropiet, MesPago, Imputacion, Usuario, FechaMod) " & _
                           "VALUES('" & Periodo & "', " & _
                                        Propiedad & ", " & _
                                        Inquilino & ", " & _
                                  "'" & cbConcepto.Text & "', " & _
                                  "'" & Format(dtFecha.Value, FormatFecha) & "', " & _
                                  "'" & tbDetalle.Text & "', " & _
                                        tbImporte.Text & ", " & _
                                        tbImporte.Text & ", " & _
                                        IIf(optPropiet.Checked, 1, 0) & ", " & _
                                        MesPago & ", " & _
                                  "'" & IIf(optDebe.Checked, "D", "H") & "', " & _
                                  "'" & Uid & "', " & _
                                  "'" & Format(Now, FormatFechaHora) & "')"
            .ExecuteNonQuery()
         End With
         '
         If NroCtto <> 0 Then
            '
            ActPropConc(Periodo, Propiedad, Inquilino, MesPago, cDia, cbConcepto.Text, Tr)
            '
            If SisContable Then
               If Not ActAsiFactInq(NroCtto, Tr) Then
                  Err.Raise(1001, , Traducir("NoUpAsiento"))
               End If
            End If
            '
         End If
         '
         GuardarAudit("Facturación Inquilino", tbInquilino.Text & ", Per: " & tbPeriodo.Text & ", Conc: " & cbConcepto.Text & ", Imp.$ " & tbImporte.Text, "frmFactInq", "Guardar", Tr)
         '
         Tr.Commit()
         '
         Me.Close()
         '
      Catch ex As System.Exception
         Dim st As New StackTrace(True)
         MensageError(st, "frmFactInqAM.btAceptar_Click", Err.Description)
         Tr.Rollback()
         '
      End Try
      '
   End Sub
   '
   Private Sub tbImporte_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbImporte.KeyPress
      SoloNumeros(e.KeyChar, True)
   End Sub
   '
   Private Sub btCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCancelar.Click
      Me.Close()
   End Sub
   '
   Private Sub frmFactInqAM_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
      SetRegForm(Me)
      Me.Dispose()
   End Sub
   '
End Class