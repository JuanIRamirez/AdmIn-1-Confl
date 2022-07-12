Public Class frmListAlq
   '
   Dim Periodo, PerAnt As String
   '
   Private Sub frmListAlq_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      '
      GetRegForm(Me)
      '
      TraducirForm(Me)
      '
      dtpPeriodo.Value = Today
      '
   End Sub
   '
   Private Sub frmListAlq_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
      TabReturn(e.KeyChar)
   End Sub
   '
   Private Sub dtpPeriodo_ValueChanged(sender As Object, e As EventArgs) Handles dtpPeriodo.ValueChanged
      Periodo = Format(dtpPeriodo.Value, "yyyyMM")
   End Sub
   '
   Private Sub cmdAceptar_Click(sender As Object, e As EventArgs) Handles cmdAceptar.Click
      '
      Dim Filtro As String
      Dim Formulas(1, 1) As String
      '
      ArmaAuxReporte()
      '
      Filtro = "{AuxReporte.Uid} = '" & Uid & "' AND {AuxReporte.Host} = '" & NombrePC & "'"
      '
      Formulas(0, 0) = "Subtitulo" : Formulas(0, 1) = "Período: " & Format(dtpPeriodo.Value, "MM/yyyy")
      Formulas(1, 0) = "Empresa" : Formulas(1, 1) = cfgNomEmp
      '
      ImprimirCrp("AlqCambVal", crptToWindow, Filtro, Me.Text, Formulas)
      '
   End Sub
   '
   Private Sub ArmaAuxReporte()
      '
      Dim Cmd, Cm2 As New OleDb.OleDbCommand
      Dim Drd As OleDb.OleDbDataReader
      '
      PerAnt = CalcPeriodo("01/" & Format(dtpPeriodo.Value, "MM/yyyy"), -1)
      '
      With Cmd
         .Connection = Cn
         .CommandText = "DELETE FROM AuxReporte WHERE Uid = '" & Uid & "' AND Host = '" & NombrePC & "'"
         .ExecuteNonQuery()
         '
         .CommandText = "SELECT P.Propietario, F.Propiedad, F.Inquilino, F.Importe " & _
                        "FROM FactInq F LEFT JOIN Propiedades P ON F.Propiedad = P.Codigo " & _
                        "WHERE Concepto = 'ALQ' " & _
                        "  AND Periodo = '" & Periodo & "' " & _
                        "  AND EXISTS( SELECT TOP 1 Periodo FROM FactInq " & _
                        "              WHERE Concepto = 'ALQ' AND Periodo = '" & PerAnt & "' AND Importe <> F.Importe " & _
                        "                AND Inquilino = F.Inquilino AND Propiedad = F.Propiedad " & _
                        "              ORDER BY Periodo DESC)"
         Drd = .ExecuteReader
      End With
      '
      With Drd
         While .Read
            Cm2.Connection = Cn
            Cm2.CommandText = "INSERT INTO AuxReporte( Propietario, Propiedad, Inquilino, Importe, Uid, Host) " & _
                              "VALUES(" & !Propietario & ", " & _
                                          !Propiedad & ", " & _
                                          !Inquilino & ", " & _
                                          !Importe & ", " & _
                                    "'" & Uid & "', " & _
                                    "'" & NombrePC & "')"
            Cm2.ExecuteNonQuery()
         End While
         .Close()
      End With
      '
   End Sub
   '
   Private Sub cmdCerrar_Click(sender As Object, e As EventArgs) Handles cmdCerrar.Click
      Me.Close()
   End Sub
   '
   Private Sub Form_Unload(Cancel As Integer)
      SetRegForm(Me)
   End Sub
   '
End Class