Public Class frmLiqPropProy
   '
   Public Propietario As Int32
   Public Propiedad As Int32
   Public Periodo As String
   '
   Public Seleccionar As Boolean
   '
   Public TotAlq As Double
   Public TotBon As Double
   Public TotOtr As Double
   Public TotDesc As Double
   '
   Private Sub frmLiqPropProy_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      '
      GetRegForm(Me)
      '
      txtPropietario.Text = CapturaDatoCn("Propietarios", "Nombre", "Codigo = " & Propietario)
      tbPropiedad.Text = CapturaDatoCn("Propiedades", "Domicilio", "Codigo = " & Propiedad)
      If tbPropiedad.Text = "" Then
         tbPropiedad.Text = "(Todas)"
      End If
      txtPeriodo.Text = Periodo
      Periodo = Periodo.Substring(0, 4) & Periodo.Substring(5, 2)
      '
      ActData()
      '
      Seleccionar = False
      '
   End Sub
   '
   Private Sub ActData()
      '
      Dim Total As Double
      Dim i As Int16
      '
      TotAlq = 0
      TotOtr = 0
      TotDesc = 0
      '
      SetRegGrid(Me, DataGridView1)
      LlenarGrid(DataGridView1, SqlProyAdel(Propietario, Propiedad, Periodo))
      SetCols()
      GetRegGrid(Me, DataGridView1)
      '
      With DataGridView1
         If .RowCount > 0 Then
            For i = 0 To .RowCount - 1
               Total = Total + .Item("Importe", i).Value
               If .Item("Concepto", i).Value = cfgCodigoAlq Then
                  TotAlq = TotAlq + .Item("Importe", i).Value
               ElseIf .Item("Concepto", i).Value = cfgCodigoBon Then
                  TotBon = TotBon + .Item("Importe", i).Value
               ElseIf .Item("Importe", i).Value > 0 Then
                  TotOtr = TotOtr + .Item("Importe", i).Value
               Else
                  TotDesc = TotDesc + .Item("Importe", i).Value
               End If
            Next i
         End If
      End With
      '
      txtTotAlq.Text = TotAlq
      tbTotBon.Text = TotBon
      txtTotOtr.Text = TotOtr
      txtTotDes.Text = TotDesc
      txtTotal.Text = Total
      '
   End Sub
   '
   Private Sub SetCols()
      '
      With DataGridView1
         For Each Col As DataGridViewColumn In .Columns
            With Col
               Select Case UCase(.Name)
                  Case "FECHA" : .Width = 100
                  Case "CONCEPTO" : .Width = 90
                  Case "PROPIEDAD" : .Width = 200
                  Case "DETALLE" : .Width = 200
                  Case "NOMBRE" : .Width = 200
                  Case "IMPORTE" : .Width = 110 : .DefaultCellStyle.Format = "#,##0.00" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                  Case "SALDO" : .Width = 110 : .DefaultCellStyle.Format = "#,##0.00" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
               End Select
            End With
         Next Col
      End With
      '
   End Sub
   '
   Private Sub cmdSeleccionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSeleccionar.Click
      Seleccionar = True
      Me.Close()
   End Sub
   '
   Private Sub cmdCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCerrar.Click
      Me.Close()
   End Sub
   '
   Private Sub frmLiqPropProy_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
      SetRegGrid(Me, DataGridView1)
      SetRegForm(Me)
   End Sub
   '
End Class
