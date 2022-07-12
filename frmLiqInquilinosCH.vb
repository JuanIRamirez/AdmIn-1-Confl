Public Class frmLiqInquilinosCH

   Public Total As Double
   Public FechaDif As Date
   '
   Dim Tr As OleDb.OleDbTransaction
   Dim Cmd As New OleDb.OleDbCommand
   Dim Dr As OleDb.OleDbDataReader
   '
   Dim Alta As Boolean
   Dim Banco As Int32

   Private Sub frmLiqInqCH_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      '
      ArmaComboItem(cbBanco, "Bancos", "Banco", "Nombre", "Nombre")
      '
      tbFecCheque.MinDate = Today.AddDays(-365)
      tbFecCheque.MaxDate = Today.AddDays(365)
      tbFecCheque.Value = Today
      FechaDif = Today
      '
      ActData()
      '
   End Sub
   '
   Private Sub cmdBaja_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBaja.Click
      '
      Dim Banco As Int32
      Dim Cuenta As String
      Dim Numero As String
      '
      With DataGridView1
         If .RowCount > 0 Then
            If DaDeBaja("Cheque Nº: " & .SelectedCells(.Columns("Numero").Index).Value) Then
               Banco = .SelectedCells(.Columns("Banco").Index).Value
               Cuenta = .SelectedCells(.Columns("Cuenta").Index).Value
               Numero = .SelectedCells(.Columns("Numero").Index).Value
               Tr = Cn.BeginTransaction
               With Cmd
                  .Transaction = Tr
                  .CommandText = "DELETE FROM ChReciboTmp WHERE Banco = " & Banco & " AND Cuenta = '" & Cuenta & "' AND Numero = '" & Numero & "'"
                  .ExecuteNonQuery()
                  Tr.Commit()
               End With
               ActData()
            End If
         End If
      End With
   End Sub
   '
   Private Sub frmLiqInqCH_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
      TabReturn(e.KeyChar)
   End Sub
   '
   Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
      '
      Dim i As Int16
      '
      Total = 0
      '
      With DataGridView1
         If .RowCount = 0 Then
            MensajeTrad("DICheques")
            Exit Sub
         Else
            For i = 0 To .RowCount - 1
               Total = Total + .Item("Importe", i).Value
            Next i
            Me.Close()
         End If
      End With
      '
   End Sub
   '
   Private Sub cmdAceptar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar2.Click
      If Validar() Then
         If Guardar() Then
            Limpiar()
            ActData()
         End If
      End If
   End Sub

   Private Function Validar() As Boolean
      '
      If cbBanco.Text = "" Or Banco = 0 Then
         MensajeTrad("DIBanco")
         cbBanco.Focus()
         Return False
      End If
      '
      If tbCuenta.Text = "" Then
         MensajeTrad("DICuenta")
         tbCuenta.Focus()
         Return False
      End If
      '
      If tbNroCheque.Text = "" Then
         MensajeTrad("DINroCheque")
         tbNroCheque.Focus()
         Return False
      End If
      '
      If tbTitular.Text = "" Then
         MensajeTrad("DITitular")
         tbTitular.Focus()
         Return False
      End If
      '
      If Val(tbImporte.Text) = 0 Then
         MensajeTrad("DII>0")
         tbImporte.Focus()
         Return False
      End If
      '
      If Not IsNothing(CapturaDato(Cn, "Chcartera", "ChCartNro", "Banco = " & Banco & " AND BancoCta = '" & tbCuenta.Text & "' AND ChCartNro = '" & tbNroCheque.Text & "'")) Then
         MensajeTrad("ChEnCartera")
         Return False
      End If
      '
      If Alta Then
         If Not IsNothing(CapturaDato(Cn, "ChReciboTmp", "Numero", "Banco = " & Banco & " AND Cuenta = '" & tbCuenta.Text & "' AND Numero = '" & tbNroCheque.Text & "' AND Usuario = '" & Uid & "' AND PC = '" & NombrePC & "'")) Then
            MensajeTrad("ChYaIng")
            Return False
         End If
      End If
      '
      Return True
      '
   End Function
   '
   Private Function Guardar() As Boolean
      '
      Try
         '
         Tr = Cn.BeginTransaction
         '
         With Cmd
            .Connection = Cn
            .Transaction = Tr
            If Alta Then
               .CommandText = "INSERT INTO ChReciboTmp( DescBco, Banco, Cuenta, Titular, Numero, Fecha, Importe, Usuario, PC) " & _
                              "VALUES('" & CapturaDato(Cn, "Bancos", "Nombre", "Banco = " & Banco, , , , Tr) & "', " & _
                                           Banco & ", " & _
                                     "'" & tbCuenta.Text & "', " & _
                                     "'" & tbTitular.Text & "', " & _
                                     "'" & tbNroCheque.Text & "', " & _
                                     "'" & Format(tbFecCheque.Value, FormatFecha) & "', " & _
                                           Val(tbImporte.Text) & ", " & _
                                     "'" & Uid & "', " & _
                                     "'" & NombrePC & "')"
            Else
               .CommandText = "UPDATE ChReciboTmp SET " & _
                              " DescBco = '" & CapturaDato(Cn, "Bancos", "Nombre", "Banco = " & Banco, , , , Tr) & "', " & _
                              " Titular = '" & tbTitular.Text & "', " & _
                              " Fecha = '" & Format(tbFecCheque.Value, FormatFecha) & "', " & _
                              " Importe = " & Val(tbImporte.Text) & ", " & _
                              " Usuario = '" & Uid & "', " & _
                              " PC = '" & NombrePC & "' " & _
                              "WHERE  Banco = " & Banco & " AND Cuenta = '" & tbCuenta.Text & "' AND Numero = '" & tbNroCheque.Text & "'"
            End If
            .ExecuteNonQuery()
            '
         End With
         '
         Tr.Commit()
         '
         Return True
         '
      Catch ex As Exception
         '
         Dim st As New StackTrace(True)
         MensageError(st, "frmLiqInqCh.Guardar", ex.Message)
         Tr.Rollback()
         Return False
         '
      End Try

   End Function
   '
   Private Sub cmdAlta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAlta.Click
      tbImporte.Text = ""
      tbCuenta.Text = ""
      tbTitular.Text = ""
      tbNroCheque.Text = ""
      tbFecCheque.Value = Today
      ActivaCtrl(True)
      Alta = True
      cbBanco.Focus()
   End Sub
   '
   Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
      '
      Dim Cerrar As Boolean
      '
      If DataGridView1.RowCount > 0 Then
         If MsgConfirma("Cancela cheques ingresados") Then
            Tr = Cn.BeginTransaction
            With Cmd
               .Connection = Cn
               .Transaction = Tr
               .CommandText = "DELETE FROM ChReciboTmp WHERE Usuario = '" & Uid & "' AND PC = '" & NombrePC & "'"
               .ExecuteNonQuery()
               Tr.Commit()
            End With
            Cerrar = True
            FechaDif = Today
         End If
      Else
         Cerrar = True
      End If
      If Cerrar Then
         Total = 0
         Me.Close()
      End If
      '
   End Sub
   '
   Private Sub cmdCancelar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar2.Click
      Limpiar()
   End Sub
   '
   Private Sub Limpiar()
      ActivaCtrl(False)
      LimpiaCtrl(Me)
      DataGridView1.Focus()
   End Sub
   '
   Private Sub cmdEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEditar.Click
      ActivaCtrl(True)
      ActDatos()
      Alta = False
   End Sub
   '
   Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
      ActDatos()
   End Sub

   Private Sub DataGridView1_Click(sender As Object, e As EventArgs) Handles DataGridView1.Click
      ActDatos()
   End Sub
   '
   Private Sub DataGridView1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyUp
      ActDatos()
   End Sub
   '
   Private Sub ActDatos()
      With DataGridView1
         If .RowCount > 0 Then
            PosCboItem(cbBanco, .SelectedCells(.Columns("Banco").Index).Value)
            tbCuenta.Text = .SelectedCells(.Columns("Cuenta").Index).Value
            tbTitular.Text = .SelectedCells(.Columns("Titular").Index).Value
            tbNroCheque.Text = .SelectedCells(.Columns("Numero").Index).Value
            tbFecCheque.Value = .SelectedCells(.Columns("Fecha").Index).Value
            tbImporte.Text = .SelectedCells(.Columns("Importe").Index).Value
         End If
      End With
   End Sub
   '
   Private Sub cbBanco_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbBanco.SelectedIndexChanged
      With cbBanco
         If .SelectedIndex > 0 Then
            Banco = .SelectedValue
         Else
            Banco = 0
         End If
      End With
   End Sub
   '
   Private Sub ActData()
      '
      SetRegGrid(Me, DataGridView1)
      '
      LlenarGrid(DataGridView1, "SELECT * FROM ChReciboTmp WHERE Usuario = '" & Uid & "' AND PC = '" & NombrePC & "'")
      '
      With DataGridView1
         For Each Col As DataGridViewColumn In .Columns
            With Col
               Select Case UCase(.Name)
                  Case "USUARIO" : .Visible = False
                  Case "BANCO" : .Visible = False
               End Select
            End With
         Next Col
      End With
      '
      GetRegGrid(Me, DataGridView1)
      '
      ActivaCtrl(False)
      ActDatos()
      '
      tbTotal.Text = Format(Val(CapturaDato(Cn, "ChReciboTmp", "SUM(Importe)", "Usuario = '" & Uid & "' AND PC = '" & NombrePC & "'") & ""), "Fixed")
      '
   End Sub
   '
   Private Sub ActivaCtrl(ByVal Modo As Boolean)
      '
      DataGridView1.Enabled = Not Modo
      cmdAlta.Enabled = Not Modo
      cmdBaja.Enabled = Not Modo And DataGridView1.RowCount > 0
      cmdEditar.Enabled = Not Modo And DataGridView1.RowCount > 0
      '
      cmdAceptar.Enabled = Not Modo
      cmdCancelar.Enabled = Not Modo
      '
      gbDatos.Enabled = Modo
      'cmdAceptar2.Enabled = Modo
      'cmdCancelar2.Enabled = Modo
      '
      'cbBanco.Enabled = Modo
      'tbCuenta.Enabled = Modo
      'tbNroCheque.Enabled = Modo
      'tbTitular.Enabled = Modo
      'tbImporte.Enabled = Modo
      'tbFecCheque.Enabled = Modo
      '
   End Sub
   '
   Private Sub tbImporte_KeyPress(ByVal KeyAscii As Integer)
      SoloNumeros(KeyAscii, True)
   End Sub
   '
   Private Sub tbImporte_LostFocus()
      tbImporte.Text = Format(Val(tbImporte.Text), "Fixed")
   End Sub
   '
   Private Sub frmLiqInqCH_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
      SetRegGrid(Me, DataGridView1)
      SetRegForm(Me)
   End Sub
   '
End Class