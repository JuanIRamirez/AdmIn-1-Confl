Public Class frmOrdenPagoVsAg

   Public TablaAct As String
   Public cmpInt As String
   'Public OrdenPagoId As Long
   'Public Estado As Integer
   'Public TablaAct As String
   'Public cmpInt As String
   '
   Dim Cmd As New OleDb.OleDbCommand
   Dim trn As OleDb.OleDbTransaction
   '
   Dim nTotal As Double
   Dim Caja As Integer
   Dim CuentaProv As String
   Dim cCtaCaja As String
   Dim cCtaCajaA As String
   Dim FecPago As Date
   Dim nTipoMov As Integer
   Dim cImput As String
   Dim cDescInt As String
   Dim cCtaInt As String
   Dim cDescVCar As String
   Dim cCtaVCar As String
   Dim CaptCtas As Boolean
   Dim Comprob As String
   Dim EstOP As String
   '
   Dim cTmp As String
   'Dim cTmpDev As String
   Dim cTmpOP As String
   '
   Const EstAut = 1
   Const EstConf = 2
   Const EstPagado = 3
   Const estRendido = 4
   '
   Private Sub frmOrdenPagoVsAg_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      '
      GetRegForm(Me)
      '
      'TraducirForm(Me)
      '
      If cmpInt = "" Then
         cmpInt = "OP"
      End If
      '
      'Adodc1.ConnectionString = Cn
      ActData()
      '
   End Sub
   '
   Private Sub frmOrdenPagoVsAg_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
      TabReturn(e.KeyChar)
   End Sub
   '
   Sub ActData()
      '
      On Error Resume Next
      '
      nTotal = 0
      '
      SetRegGrid(Me, DataGridView1)
      '
      LlenarGrid(DataGridView1, "SELECT O.OrdenPagoID, O.OPNumero, O.OPFecha, P.Nombre, O.OPDetalle, O.OPTotal, O.OpEfectivo, O.OpCheques " & _
                                "FROM OrdenPago O LEFT JOIN Proveedores P " & _
                                "  ON O.Proveedor = P.Codigo " & _
                                "WHERE O.OpNumero NOT IN( SELECT OpNumero FROM " & TablaAct & ") " & _
                                "  AND O.Estado = " & EstAut & " " & _
                                "  AND O.OpTipo = '" & cmpInt & "' " & _
                                "ORDER BY O.OPNumero")

      btnAgregar.Enabled = (DataGridView1.RowCount > 0)
      '
      SetCols()
      GetRegGrid(Me, DataGridView1)
      '
   End Sub
   '
   Private Sub SetCols()
      '
      'Dim cCol As MSDBGrid.Column
      '
      With DataGridView1
         For Each Col As DataGridViewColumn In .Columns
            With Col
               Select Case UCase(.Name)
                  Case "COMPROB" : .Width = 50 : .HeaderText = "Cpte."
                  Case "TIPO" : .Width = 30
                     If cmpInt = "PO" Then
                        .Visible = False
                     End If
                  Case "Sucursal" : .Width = 50
                  Case "Numero" : .Width = 100 : Case "Fecha"
                  Case "PerIva" : .Width = 100 : .HeaderText = "Per.Iva."
                     If cmpInt = "PO" Then
                        .Visible = False
                     End If
                  Case "Nombre"
                     If cmpInt = "OP" Then
                        .Width = 250
                        .HeaderText = "Proveedor"
                     Else
                        .Visible = False
                     End If
                  Case "NomProp"
                     If cmpInt = "PO" Then
                        .Width = 250
                        .HeaderText = "Propietario"
                     Else
                        .Visible = False
                     End If
                  Case "Detalle" : .Width = 2500
                  Case "Total" : .Width = 1000   ' : cCol.NumberFormat = "#,##0.00"
                  Case Else
                     'cCol.Visible = False
               End Select
            End With
         Next Col
      End With
      '
   End Sub
   '
   'Private Sub tbCheque_Change()
   '   If Val(tbCheque) = 0 Then
   '      ActCtrlBco False
   '   Else
   '      ActCtrlBco True
   '   End If
   'End Sub
   '
   'Private Sub ActCtrlBco(Activo As Boolean)
   '
   'With Me
   '   .cbDescBco.Enabled = Activo
   '   .cbCtaBco.Enabled = Activo
   '   .cbNroCheque.Enabled = Activo
   '   .tbFecCheque.Enabled = Activo
   'End With
   ''
   'End Sub
   '
   'Private Sub cbDescBco_Click()
   '
   'cbBanco.ListIndex = cbDescBco.ListIndex
   'cbCtaBco.Clear
   '
   'With rsCBco
   '   .Open "SELECT * FROM BancoCta WHERE Banco = " & Val(cbBanco), Cn, adOpenForwardOnly, adLockReadOnly
   '   '.Seek ">=", cbBanco, ""
   '   'If .NoMatch Then
   '   '   'No tiene cuentas.
   '   'Else
   '      'Do While !Banco = cbBanco
   '      Do Until .EOF
   '         cbCtaBco.AddItem !Cuenta
   '         .MoveNext
   '         'If .EOF Then Exit Do
   '      Loop
   '   'End If
   '   .Close
   'End With
   '
   'End Sub
   '
   Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
      '
      Dim OpNumero As Int32
      '
      With DataGridView1
         If .RowCount > 0 Then
            OpNumero = .SelectedCells(.Columns("OpNumero").Index).Value
            '
            trn = Cn.BeginTransaction
            With Cmd
               .Connection = Cn
               .Transaction = trn
               .CommandText = "INSERT INTO " & TablaAct & "(OpNumero) VALUES( " & OpNumero & ")"
               .ExecuteNonQuery()
            End With
            '
            trn.Commit()
            '
            ActData()
            '
         End If
      End With
   End Sub
   '
   Private Sub cmdCancelar_Click()
      Me.Close()
   End Sub
   '
   Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
      Me.Close()
   End Sub
   '
   Private Sub frmOrdenPagoVsAg_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
      SetRegGrid(Me, DataGridView1)
      SetRegForm(Me)
   End Sub
   '
End Class