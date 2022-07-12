Public Class frmABM
   '
   Public AltaAuto As Boolean          'Alta automática (Directa).
   Public Titulo As String             'Titulo del Formulario.
   Public Tabla As String              'Tabla del ABM.
   Public tblRelacion As String
   '
   Public colClave As String           'Columna Clave de la Tabla.
   Public colDescrip As String         'Columna descripción.
   Public colEntero As String          'Columna dato entero.
   Public colDoble1 As String          'Columna dato Doble 1.
   Public colDoble2 As String          'Columna dato Doble 2.
   Public colLogico As String             'Columna lógica.
   Public colUsuMod As String = "Usuario"
   Public colFecMod As String = "FechaMod"
   '
   Public titClave As String
   Public titDescrip As String
   Public titEntero As String
   Public titDoble1 As String          'Título Doble 1.
   Public titDoble2 As String          'Título campo Doble 2.
   Public titLogico As String          'Título campo lógico.
   '
   Public claveNumerica As Boolean     'Indica si la Clave es numérica.
   Public AutoNumerico As Boolean      '   "    "  es Autonumérico.
   Public lenClave As Integer          'Tamaño campo clave.
   Public lenDescrip As Integer        'Tamaño campo descripción.
   Public SQLMovim As String           'SQL p/DELETE (Verificar movimientos).
   Public noCero As Boolean            'No mostrar valor clave cero.
   Public Reporte As String = ""
   '
   Dim Alta As Boolean
   Dim Cmd As New OleDb.OleDbCommand
   Dim Trn As OleDb.OleDbTransaction
   '
   Private Sub frmABM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      '
      Try
         '
         GetRegForm(Me)
         '
         If Titulo <> "" Then Me.Text = Titulo
         '
         If Tabla = "" Then Err.Raise(1001, , "Debe definir Tabla")
         If colClave = "" Then Err.Raise(1001, , "Debe definir Col.Clave")
         If colDescrip = "" Then Err.Raise(1001, , "Debe definir Col.Descrip")
         '
         With btnImprimir
            .Visible = Reporte <> ""
            .Enabled = Reporte <> ""
         End With
         '
         If titClave <> "" Then
            lblCodigo.Text = titClave
         End If
         '
         If titDescrip <> "" Then
            lblDescrip.Text = titDescrip
         End If
         '
         If colEntero = "" Then
            lblEntero.Visible = False
            tbEntero.Visible = False
         End If
         '
         If titEntero <> "" Then
            lblEntero.Text = titEntero
         End If
         '
         If colDoble1 = "" Then
            lblDoble1.Visible = False
            tbDoble1.Visible = False
         End If
         '
         If titDoble1 <> "" Then
            lblDoble1.Text = titDoble1
            lblDoble1.Visible = True
         End If
         '
         If colDoble2 = "" Then
            lblDoble2.Visible = False
            tbDoble2.Visible = False
         End If
         '
         If titDoble2 <> "" Then
            lblDoble2.Text = titDoble2
         End If
         '
         If colLogico = "" Then
            chkLogico.Visible = False
         Else
            chkLogico.Text = IIf(titLogico <> "", titLogico, colLogico)
         End If
         '
         If AutoNumerico Then
            claveNumerica = True
         End If
         '
         tbCodigo.Enabled = Not AutoNumerico
         '
         If claveNumerica Then
            tbCodigo.TextAlign = HorizontalAlignment.Right
         End If
         '
         If lenClave = 0 Then lenClave = 5
         If lenDescrip = 0 Then lenDescrip = 50
         '
         tbCodigo.MaxLength = lenClave
         tbNombre.MaxLength = lenDescrip
         '
         Cmd.Connection = Cn
         ActData()
         '
         If AltaAuto Then AltaClick()
         '
      Catch ex As System.Exception
         Dim st As New StackTrace(True)
         RegistrarError(st, Me.Name)
         DeshabForm(Me)
      End Try
      '
   End Sub
   '
   Private Sub frmABM_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
      TabReturn(e.KeyChar)
   End Sub
   '
   Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
      ImprimirCrp(Reporte, crptToWindow, "", Me.Text)
   End Sub
   '
   Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
      If AltaAuto Then
         Me.Close()
      Else
         ActivaCtrl(False)
         DataClick()
      End If
   End Sub
   '
   'Private Sub optCodigo_Click()
   '   ActData()
   'End Sub
   '
   'Private Sub optDescrip_Click()
   '   ActData()
   'End Sub
   '
   Private Sub tbBuscar_TextChanged(sender As Object, e As EventArgs) Handles tbBuscar.TextChanged
      ActData()
   End Sub
   '
   Sub ActData()
      '
      On Error Resume Next
      '
      Dim cBookM
      '
      GetRegGrid(Me, DataGridView1)
      '
      Dim cWhere As String = ""
      '
      If noCero Then
         cWhere = "WHERE " & colClave & " <> 0 "
      End If
      '
      If tbBuscar.Text <> "" Then
         cWhere = IIf(cWhere = "", "WHERE", cWhere & " AND") & " " & colDescrip & " LIKE '%" & tbBuscar.Text & "%'"
      End If
      '
      LlenarGrid(DataGridView1, "SELECT * FROM " & Tabla & " " & cWhere & " ORDER BY " & colDescrip)
      '
      With DataGridView1
         For Each Col As DataGridViewColumn In .Columns
            With Col
               Select Case UCase(.Name)
                  Case UCase(colClave) : .Width = 100
                     Select Case UCase(.Name)
                        Case "TIPOPRESUP" : .HeaderText = "Tipo"
                        Case "PLAZOENT" : .HeaderText = "Plazo"
                        Case "CONDPAGO" : .HeaderText = "Cond."
                        Case "LOCALIDADID" : .HeaderText = "Id"
                     End Select
                     If claveNumerica Then
                        With .DefaultCellStyle
                           .Format = "#0 "
                           .Alignment = DataGridViewContentAlignment.MiddleRight
                        End With
                     End If
                  Case UCase(colDescrip) : .HeaderText = "Descripción" : .Width = 500
                  Case UCase(colEntero) : .HeaderText = titEntero
                  Case UCase(colDoble1) : .HeaderText = titDoble1
                  Case UCase(colDoble2) : .HeaderText = titDoble2
                  Case UCase(colLogico) : .HeaderText = titLogico
                  Case Else
                     .Visible = False
               End Select
            End With
         Next Col
      End With
      '
      SetRegGrid(Me, DataGridView1)
      '
      ActivaCtrl(False)
      DataClick()
      '
   End Sub
   '
   Private Sub DataGridView1_KeyUp(sender As Object, e As KeyEventArgs) Handles DataGridView1.KeyUp
      DataClick()
   End Sub
   '
   Private Sub DataGridView1_MouseClick(sender As Object, e As MouseEventArgs) Handles DataGridView1.MouseClick
      DataClick()
   End Sub
   '
   Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
      DataClick()
   End Sub
   '
   Private Sub DataClick()
      '
      With DataGridView1
         If .RowCount > 0 Then
            tbCodigo.Text = .SelectedCells(.Columns(colClave).Index).Value
            tbNombre.Text = .SelectedCells(.Columns(colDescrip).Index).Value & ""
            If colEntero <> "" Then
               tbEntero.Text = Val(.SelectedCells(.Columns(colEntero).Index).Value & "")
            End If
            If colDoble1 <> "" Then
               tbDoble1.Text = Format(.SelectedCells(.Columns(colDoble1).Index).Value, "Fixed")
            End If
            If colDoble2 <> "" Then
               tbDoble2.Text = Format(.SelectedCells(.Columns(colDoble2).Index).Value, "Fixed")
            End If
            If colLogico <> "" Then
               chkLogico.Checked = IIf(.SelectedCells(.Columns(colLogico).Index).Value, 1, 0)
            End If
         End If
      End With
      '
   End Sub
   '
   Private Sub btnBaja_Click(sender As Object, e As EventArgs) Handles btnBaja.Click
      '
      Dim Cod As Object
      Dim Nom As String
      '
      With DataGridView1
         If .RowCount > 0 Then
            '
            Cod = .SelectedCells(.Columns(colClave).Index).Value
            Nom = .SelectedCells(.Columns(colDescrip).Index).Value
            '
            If tblRelacion <> "" Then
               If ExisteIdentificacion(Cod, tblRelacion, colClave) Then
                  MsgBox("No se puede eliminar el registro porque tiene relacionadas.", vbInformation)
                  Exit Sub
               End If
            End If
            '
            If Not SQLMovim = "" Then
               With Cmd
                  .CommandText = SQLMovim & IIf(claveNumerica, "", "'") & Cod & IIf(claveNumerica, "", "'")
                  If .ExecuteNonQuery > 0 Then
                     MsgBox("El Item (" & Cod & " - " & Nom & ") que desea eliminar tiene movimientos, no podrá realizar la operación.", vbExclamation)
                     Exit Sub
                  End If
               End With
            End If
            '
            If DaDeBaja(Nom) Then
               Trn = Cn.BeginTransaction
               With Cmd
                  .Transaction = Trn
                  .CommandText = "DELETE FROM " & Tabla & " " & _
                                 "WHERE " & colClave & " = " & IIf(claveNumerica, "", "'") & Cod & IIf(claveNumerica, "", "'")
                  .ExecuteNonQuery()
               End With
               Trn.Commit()
               ActData()
            End If
            '
         End If
      End With

   End Sub
   '
   Private Sub btnAlta_Click(sender As Object, e As EventArgs) Handles btnAlta.Click
      AltaClick()
   End Sub
   '
   Private Sub AltaClick()
      Alta = True
      Limpiacampos(Me, tbBuscar.Name)
      ActivaCtrl(True)
      If claveNumerica Then
         With Cmd
            .CommandText = "SELECT ISNULL(MAX(" & colClave & "),0) AS Ultimo FROM " & Tabla
            tbCodigo.Text = .ExecuteScalar + 1
         End With
      End If
      If Not AltaAuto Then
         tbCodigo.Focus()
      End If
   End Sub
   '
   Private Sub btnModif_Click(sender As Object, e As EventArgs) Handles btnModif.Click
      Alta = False
      ActivaCtrl(True)
      tbNombre.Focus()
   End Sub
   '
   Private Sub ActivaCtrl(Modo As Boolean)
      '
      Dim lEnabl As Boolean = (DataGridView1.RowCount > 0)
      '
      'Me.CancelButton = IIf(Modo, btnSalir, btnCancelar)
      '
      tbBuscar.Enabled = Not Modo
      'optCodigo.Enabled = Not Modo
      'optDescrip.Enabled = Not Modo
      DataGridView1.Enabled = Not Modo
      btnAlta.Enabled = Not Modo
      btnBaja.Enabled = Not Modo And lEnabl
      btnModif.Enabled = Not Modo And lEnabl
      '
      btnAceptar.Enabled = Modo
      btnCancelar.Enabled = Modo
      '
      tbCodigo.Enabled = IIf(Alta, Modo And Not AutoNumerico, False)
      lblCodigo.Enabled = Modo
      lblEntero.Enabled = Modo
      lblDescrip.Enabled = Modo
      lblDoble1.Enabled = Modo
      lblDoble2.Enabled = Modo
      tbNombre.Enabled = Modo
      tbEntero.Enabled = Modo
      tbDoble1.Enabled = Modo
      tbDoble2.Enabled = Modo
      chkLogico.Enabled = Modo
      '
   End Sub
   '
   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      '
      'On Error GoTo mError
      '
      If tbCodigo.Text = "" Then
         If Not AutoNumerico Then
            MsgBox("Debe ingresar Código")
            tbCodigo.Focus()
            Exit Sub
         End If
      Else
         If Alta Then

            With Cmd
               .CommandText = "SELECT " & colClave & " FROM " & Tabla & " WHERE " & colClave & " = " & IIf(claveNumerica, "", "'") & tbCodigo.Text & IIf(claveNumerica, "", "'")
               If Not IsNothing(.ExecuteScalar) Then
                  MsgBox("Código existente", vbInformation)
                  tbCodigo.Focus()
                  Exit Sub
               End If
            End With
         End If
      End If
      '
      If tbNombre.Text = "" Then
         MsgBox("Debe ingresar Descripción")
         tbNombre.Focus()
         Exit Sub
      End If
      '
      Try
         Trn = Cn.BeginTransaction
         '
         With Cmd
            .Transaction = Trn
            If Alta Then
               .CommandText = "INSERT INTO " & Tabla & "(" & IIf(AutoNumerico, "", colClave & ", ") & colDescrip &
                              IIf(colEntero = "", "", ", " & colEntero) &
                              IIf(colDoble1 = "", "", ", " & colDoble1) &
                              IIf(colDoble2 = "", "", ", " & colDoble2) &
                              IIf(colLogico = "", "", ", " & colLogico) &
                              ", " & colUsuMod & ", " & colFecMod & ")" &
                              " VALUES(" & IIf(AutoNumerico, "", IIf(claveNumerica, "", "'") & tbCodigo.Text & IIf(claveNumerica, "", "'") & ", ") &
                                     "'" & tbNombre.Text & "', " &
                                           IIf(colEntero = "", "", Val(tbEntero.Text) & ", ") &
                                           IIf(colDoble1 = "", "", Val(tbDoble1.Text) & ", ") &
                                           IIf(colDoble2 = "", "", Val(tbDoble2.Text) & ", ") &
                                           IIf(colLogico = "", "", IIf(chkLogico.Checked, 1, 0) & ", ") &
                                           "'" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
            Else
               .CommandText = "UPDATE " & Tabla & " SET " &
                              colDescrip & " = '" & tbNombre.Text & "', " &
                              IIf(colEntero = "", "", colEntero & " = " & Val(tbEntero.Text) & ", ") &
                              IIf(colDoble1 = "", "", colDoble1 & " = " & Val(tbDoble1.Text) & ", ") &
                              IIf(colDoble2 = "", "", colDoble2 & " = " & Val(tbDoble2.Text) & ", ") &
                              IIf(colLogico = "", "", colLogico & " = " & IIf(chkLogico.Checked, 1, 0) & ", ") &
                              colUsuMod & " = '" & Uid & "', " &
                              colFecMod & " = '" & Format(Now, FormatFechaHora) & "' " &
                              "WHERE " & colClave & " = " & IIf(claveNumerica, "", "'") & tbCodigo.Text & IIf(claveNumerica, "", "'")
            End If
            .ExecuteNonQuery()
         End With
         '
         Trn.Commit()
         ActData()
         '
         If AltaAuto Then Me.Close()
         '
      Catch ex As System.Exception
         Trn.Rollback()
         Dim st As New StackTrace(True)
         RegistrarError(st, Me.Name)
      End Try
      '
   End Sub
   '
   'Private Sub tbCodigo_GotFocus()
   '   PintarTb tbCodigo
   'End Sub
   '
   Private Sub tbCodigo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbCodigo.KeyPress
      If claveNumerica Then
         SoloNumeros(e.KeyChar)
      End If
   End Sub
   '
   'Private Sub tbNombre_GotFocus()
   '   PintarTb tbNombre
   'End Sub
   '
   Private Sub tbDoble_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbDoble1.KeyPress, tbDoble2.KeyPress
      SoloNumeros(e.KeyChar, True)
   End Sub
   '
   Private Sub tbEntero_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbEntero.KeyPress
      SoloNumeros(e.KeyChar)
   End Sub
   '
   Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
      Me.Close()
   End Sub
   '
   Private Sub frmABM_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
      SetRegGrid(Me, DataGridView1)
      SetRegForm(Me)
      Me.Dispose()
   End Sub
   '
End Class