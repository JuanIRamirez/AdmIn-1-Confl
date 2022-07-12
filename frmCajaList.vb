Public Class frmCajaList
   '
   Public Fecha As Date
   '
   Dim Caja As Integer
   '
   Private Sub frmCajaList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      '
      GetRegForm(Me)
      '
      TraducirForm(Me)
      '
      ArmaComboItem(cboCaja, "Cajas", "Caja", , , "(Todas)")
      ArmaCombo(cboUid, "Usuario", "Caja", "Usuario", "", , "(Todos)", True)
      '
      If Fecha = #12:00:00 AM# Then
         dtpDesde.Value = Today
      Else
         dtpDesde.Value = Fecha
      End If
      '
      DtpHasta.Value = dtpDesde.Value
      '
      cboCaja.SelectedIndex = 0
      '
   End Sub
   '
   Private Sub cboCaja_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCaja.SelectedIndexChanged
      With cboCaja
         If .SelectedIndex > 0 Then
            Caja = .SelectedValue
         Else
            Caja = 0
         End If
         '
         tbResponsable.Text = CapturaDato(Cn, "Cajas", "Responsable", "Caja = " & Caja)
         '
      End With
   End Sub
   '
   Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
      '
      Dim wCaja As String = ""
      Dim Filtro As String = ""
      '
      If Caja > 0 Then
         wCaja = "AND {Caja.Caja} = " & Caja
         If IsNothing(CapturaDato(Cn, "Cajas", "Caja", "Caja = " & Caja)) Then
            '* Dbx = CnBkp
         End If
      End If
      '
      CalcSdoAnt()
      CalcSdoGen()
      '
      Filtro = "{Caja.Fecha} IN CDATE('" & Format(dtpDesde.Value, FormatCDATE) & "') " &
                           " TO CDATE('" & Format(DtpHasta.Value, FormatCDATE) & "') " & wCaja
      '
      If cboUid.SelectedIndex > 0 Then
         Filtro = Filtro & " AND {Caja.Usuario} = '" & cboUid.Text & "' "
      End If
      '
      ImprimirCrp("Caja", crptToWindow, Filtro, Me.Text)
      '
   End Sub
   '
   Private Sub CalcSdoAnt()
      '
      Dim cmd As New OleDb.OleDbCommand
      Dim Trn As OleDb.OleDbTransaction
      '
      Trn = Cn.BeginTransaction
      '
      With cmd
         .Transaction = Trn
         .Connection = Cn
         If chkSaldoAnt.Checked Then
            .CommandText = "UPDATE Cajas SET SdoAnt = (SELECT ISNULL(SUM(Entrada-Salida),0) FROM Caja WHERE Caja = Cajas.Caja AND Fecha < '" & Format(dtpDesde.Value, FormatFecha) & "')"
         Else
            .CommandText = "UPDATE Cajas SET SdoAnt = 0"
         End If
         .ExecuteNonQuery()
      End With
      '
      Trn.Commit()
      '
   End Sub
   '
   Private Sub CalcSdoGen()
      '
      Dim cmd As New OleDb.OleDbCommand
      Dim Trn As OleDb.OleDbTransaction
      '
      'Dim SaldoGral As Double
      '
      Trn = Cn.BeginTransaction
      '
      With cmd
         .Transaction = Trn
         .Connection = Cn
         '.CommandText = "SELECT ISNULL( SUM( ISNULL( Entrada, 0) - ISNULL( Salida, 0)), 0) AS Saldo " &
         '               "FROM Caja " &
         '               "WHERE Fecha >= " & strFEC & Format(dtpDesde.Value, FormatFecha) & strFEC &
         '               "  AND Fecha <= " & strFEC & Format(DtpHasta.Value, FormatFecha2359) & strFEC &
         '               IIf(Caja = 0, "", " AND Caja = " & Caja)
         'SaldoGral = .ExecuteScalar
         '
         .CommandText = "UPDATE Cajas SET " &
                        " SubTitulo = '" & IIf(dtpDesde.Value <> DtpHasta.Value, "Del " & dtpDesde.Value & " ", "") & "Al " & DtpHasta.Value & "', " &
                        " SdoAct = (SELECT ISNULL( SUM( ISNULL( Entrada, 0) - ISNULL( Salida, 0)), 0) AS Saldo FROM Caja " &
                        "           WHERE Fecha >= " & strFEC & Format(dtpDesde.Value, FormatFecha) & strFEC &
                        "             AND Fecha <= " & strFEC & Format(DtpHasta.Value, FormatFecha2359) & strFEC &
                        "             AND Caja = Cajas.Caja) + SdoAnt"
         .ExecuteNonQuery()
         '
      End With
      '
      Trn.Commit()
      '
   End Sub
   '
   Private Sub DtpHasta_ValueChanged(sender As Object, e As EventArgs) Handles DtpHasta.ValueChanged
      If DtpHasta.Value < dtpDesde.Value Then
         dtpDesde.Value = DtpHasta.Value
      End If
   End Sub
   '
   Private Sub cmdCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCerrar.Click
      Me.Close()
   End Sub
   '
   Private Sub frmCajaList_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
      SetRegForm(Me)
   End Sub
   '
End Class