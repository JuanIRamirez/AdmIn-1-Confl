Public Class frmContratoFin
   '
   Public Contrato As Long
   Public FechaFin As Date
   '
   Dim Rs As New OleDb.OleDbCommand
   Dim Dr As OleDb.OleDbDataReader
   '
   Dim PerDesde As String
   Dim FechaMin As Date
   '
   Private Sub frmContratoFin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      '
      With Rs
         .Connection = Cn
         .CommandText = "SELECT Texto, PerDesde FROM Contratos WHERE Numero = " & Contrato
         Dr = .ExecuteReader
      End With
      '
      With Dr
         If .Read Then
            tbContrato.Text = Contrato
            tbDetalle.Text = !Texto & ""
            PerDesde = !PerDesde
            dtFecha.Value = UltDiaMes("28/" & PerDesde.Substring(4, 2) & "/" & PerDesde.Substring(0, 4))
            FechaMin = dtFecha.Value
         End If
         '
         .Close()
         '
      End With
      '
   End Sub
   '
   Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
      If dtFecha.Value < FechaMin Then
         MensajeTrad("Fecha incorrecta")
         dtFecha.Value = FechaMin
         dtFecha.Focus()
      Else
         FechaFin = dtFecha.Value
         Me.Close()
      End If
   End Sub
   '
   Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
      Me.Close()
   End Sub
   '
End Class