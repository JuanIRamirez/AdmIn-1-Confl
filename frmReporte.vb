'
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
'Imports CrystalDecisions.Windows.Forms
'
Public Class frmReporte
   '
   Public Reporte As String = "Reporte"
   Public Titulo As String = ""
   Public Filtro As String = ""
   Public Formulas As Object
   '
   Dim cryRpt As New ReportDocument
   Dim crtableLogoninfos As New TableLogOnInfos
   Dim crtableLogoninfo As New TableLogOnInfo
   Dim crConnectionInfo As New ConnectionInfo
   '
   Dim CrTables As Tables
   Dim CrTable As Table
   '
   Private Sub FrmReporte_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      '
      Dim i As Int16
      '
      If Titulo <> "" Then
         Me.Text = Titulo
      End If
      '
      GetRegForm(Me)
      '
      If Reporte = "" Then
         MensajeTrad("DDReporte")
         DeshabForm(Me)
      Else
         '
         Try
            '
            If InStr(LCase(Reporte), ".rpt") = 0 Then
               Reporte = Reporte & ".Rpt"
            End If
            '
            If InStr(Reporte, "\") = 0 Then
               Reporte = RPT & "\" & Reporte
            End If
            '
            If Dir(Reporte) = "" Then
               MensajeTrad("ReporteNE")
               DeshabForm(Me)
            Else
               '
               With cryRpt
                  .Load(Reporte)
                  If Filtro <> "" Then
                     .RecordSelectionFormula = Filtro
                  End If
                  If TypeOf Formulas Is String(,) Then
                     For i = 0 To (Formulas.Length / 2) - 1
                        .DataDefinition.FormulaFields(Formulas(i, 0)).Text = "'" & Formulas(i, 1) & "'"
                     Next i
                  End If
               End With
               '
               If InStr(Reporte, "\Report\") <> 0 Then
                  With crConnectionInfo
                     .IntegratedSecurity = TrustedCnx
                     .ServerName = Svr
                     .DatabaseName = DBN
                     If Not TrustedCnx Then
                        .UserID = UsrDb
                        .Password = PwdDb
                     End If
                  End With
                  '
                  CrTables = cryRpt.Database.Tables
                  For Each CrTable In CrTables
                     crtableLogoninfo = CrTable.LogOnInfo
                     crtableLogoninfo.ConnectionInfo = crConnectionInfo
                     CrTable.ApplyLogOnInfo(crtableLogoninfo)
                  Next
                  '
                  cryRpt.VerifyDatabase()
                  cryRpt.Refresh()
                  '
               End If
               '
               CrystalReportViewer1.ReportSource = cryRpt
               CrystalReportViewer1.Refresh()
               '
            End If
            '
         Catch ex As Exception
            '
            Dim st As New StackTrace(True)
            RegistrarError(st, Me.Name)
            '
         End Try
         '
      End If
      '
   End Sub
   '
   Private Sub Form_Closed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
      CrystalReportViewer1.Dispose()
      SetRegForm(Me)
      Me.Dispose()
   End Sub
   '
End Class