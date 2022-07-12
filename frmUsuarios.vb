Public Class FrmUsuarios
   '
   Dim Tabla As String
   Dim Alta As Boolean
   '
   Dim Trn As OleDb.OleDbTransaction
   Dim Cmd As New OleDb.OleDbCommand
   '
   Private Sub FrmUsuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      '
      GetRegForm(Me)
      '
      Tabla = IIf(PRV = "Jet", "Usuarios", "SysUsers")
      '
      ActData()
      '
   End Sub
   '
   Private Sub Form_KeyPress(KeyAscii As Integer)
      ' TabReturn(KeyAscii, False)
   End Sub
   '
   Private Sub ActData()
      '
      SetRegGrid(Me, DataGridView1)
      '
      LlenarGrid(DataGridView1, CaptSqlUsuarios)
      '
      With DataGridView1
         For Each Col As DataGridViewColumn In .Columns
            With Col
               Select Case UCase(.Name)
                  Case "USUARIO" : .Width = 100
                  Case "NOMBRE" : .Width = 300
                  Case "PERMISOS" : .HeaderText = "Perm.Tot."
                  Case "ADMIN" : .HeaderText = "Administrador"
                  Case Else
                     .Visible = False
               End Select
            End With
         Next Col
      End With
      '
      GetRegGrid(Me, DataGridView1)
      '
      ActivaCtrl(False)
      '
      actDatos()
      '
   End Sub
   '
   Private Sub btnPwd_Click(sender As Object, e As EventArgs) Handles btnPwd.Click
      Alta = False
      ActivaCtrl(True, True)
   End Sub
   '
   Private Sub ActivaCtrl(Modo As Boolean, Optional Cc As Boolean = False)
      '
      Dim lEnabl As Boolean
      '
      With DataGridView1
         .Enabled = Not Modo
         lEnabl = (.RowCount > 0)
      End With
      '
      cmdAlta.Enabled = Not Modo
      cmdBaja.Enabled = lEnabl And Not Modo
      cmdEdicion.Enabled = lEnabl And Not Modo
      btnPwd.Enabled = lEnabl And Not Modo
      '
      tbUsuario.Enabled = IIf(Alta, Modo, False)
      tbNombre.Enabled = Modo And Not Cc
      tbContraseña.Enabled = Modo And (Cc Or Alta)
      tbContraseñaR.Enabled = Modo And (Cc Or Alta)
      optParciales.Enabled = Modo And Not Cc
      optTotales.Enabled = Modo And Not Cc
      chkAdmin.Enabled = Modo And optTotales.Checked And Not Cc
      If optParciales.Checked Then
         chkAdmin.Checked = False
      End If
      '
      cmdAceptar.Enabled = Modo
      cmdCancelar.Enabled = Modo
      '
   End Sub
   '
   Private Sub DataGridView1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyUp   ', DgvConf.KeyUp
      ActDatos()
   End Sub
   '
   Private Sub DataGridView1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridView1.MouseClick   ', DgvConf.MouseClick
      actDatos()
   End Sub
   '
   Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
      actDatos()
   End Sub

   Private Sub ActDatos()
      '
      Dim Cc As Boolean = tbContraseña.Enabled
      '
      With DataGridView1
         If .RowCount > 0 Then
            tbUsuario.Text = .SelectedCells(.Columns("Usuario").Index).Value
            tbNombre.Text = .SelectedCells(.Columns("Nombre").Index).Value
            tbContraseña.Text = Encrypt(.SelectedCells(.Columns("Contraseña").Index).Value, True)
            tbContraseñaR.Text = Encrypt(.SelectedCells(.Columns("Contraseña").Index).Value, True)
            optParciales.Checked = Not .SelectedCells(.Columns("Admin").Index).Value
            optTotales.Checked = .SelectedCells(.Columns("Permisos").Index).Value
            chkAdmin.Checked = .SelectedCells(.Columns("Admin").Index).Value
            Debug.Print(tbContraseña.Text)
         End If
      End With
   End Sub
   '
   Private Sub DataGrid1_KeyPress(KeyAscii As Integer)
      'If KeyAscii > 32 Then
      '   txtBuscar = Chr(KeyAscii)
      '   txtBuscar.SetFocus()
      'End If
   End Sub
   '
   Private Sub CmdAlta_Click(sender As Object, e As EventArgs) Handles cmdAlta.Click
      If SuperaRegistros("Usuarios") Then
         Exit Sub
      End If
      Alta = True
      Limpiacampos(Me)
      ActivaCtrl(True)
      optParciales.Checked = True
      tbUsuario.Focus()
   End Sub
   '
   Private Sub CmdBaja_Click(sender As Object, e As EventArgs) Handles cmdBaja.Click
      '
      Dim Usu, Nom As String
      '
      With DataGridView1
         Usu = .SelectedCells(.Columns("Usuario").Index).Value
         Nom = .SelectedCells(.Columns("Nombre").Index).Value
      End With
      '
      If UCase(Usu) = "ADMIN" Or
         UCase(Usu) = "SUPERVISOR" Or
         UCase(Usu) = "SA" Then
         Mensaje("No se puede eliminar el Usuario '" & Usu & "'")
         Exit Sub
      End If
      '
      If DaDeBaja("Usuario: " & Usu) Then
         '
         Cmd.Connection = Cn
         '
         'If PRV = "Jet" Or AutDB Then
         Trn = Cn.BeginTransaction
            With Cmd
               .Transaction = Trn
               .CommandText = "DELETE FROM Usuarios WHERE Usuario = '" & Usu & "'"
               .ExecuteNonQuery()
            End With
         'Else
         '   With Cmd
         '      .CommandText = "sp_revokedbaccess '" & Nom & "'"
         '      .ExecuteNonQuery()
         '   End With
         'End If

         Trn.Commit()
         ActData()
      End If
      '
mError:
      If Err.Number <> 0 Then
         'Cn.RollbackTrans()
         MsgBox("ERROR: (" & Err.Number & ") " & Err.Description)
      End If
      '
   End Sub
   '
   Private Sub cmdEdicion_Click(sender As Object, e As EventArgs) Handles cmdEdicion.Click
      Alta = False
      ActivaCtrl(True)
      If PRV = "Jet" Or AutDB Then
         'Frame2.Enabled = True
      Else
         's
      End If
      tbNombre.Focus()
   End Sub
   '
   Private Sub CmdAceptar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdAceptar.Click
      '
      Dim Cc As Boolean = tbContraseña.Enabled
      '
      If Not Validar(Cc) Then Exit Sub
      '
      'Trn = Cn.BeginTransaction
      '
      Cmd.Connection = Cn
      'Cmd.Transaction = Trn
      '
      Try
         '
         If Alta Then
            'If PRV = "Jet" Or AutDB Then
            Cmd.CommandText = "INSERT INTO Usuarios( Usuario, Nombre, Contraseña, Permisos, Admin, UsuMod, FechaMod) " &
                                 "VALUES('" & tbUsuario.Text & "', " &
                                        "'" & tbNombre.Text & "', " &
                                        "'" & Encrypt(tbContraseña.Text) & "', " &
                                              IIf(optParciales.Checked, 0, 1) & ", " &
                                              IIf(chkAdmin.Checked, 1, 0) & ", " &
                                        "'" & Uid & "', " &
                                        "'" & Format(Now, FormatFechaHora) & "')"
               Cmd.ExecuteNonQuery()
            'End If
            'If Not TrustedCnx Then
            '   If PRV = "SQLOLEDB" Then
            '      With Cmd
            '         .CommandText = "sp_addlogin @loginame = '" & tbUsuario.Text & "', " &
            '                        "@passwd   = '" & tbContraseña.Text & "', " &
            '                        "@defdb    = '" & Cn.Database & "'"
            '         .ExecuteNonQuery()
            '         '
            '         .CommandText = "sp_adduser '" & tbUsuario.Text & "', '" & tbNombre.Text & "'"
            '         .ExecuteNonQuery()
            '         '
            '         If optParciales.Checked Then
            '            .CommandText = "sp_addrolemember 'db_datareader', '" & tbNombre.Text & "'"
            '            .ExecuteNonQuery()
            '            .CommandText = "sp_addrolemember 'db_datawriter', '" & tbNombre.Text & "'"
            '            .ExecuteNonQuery()
            '         Else
            '            .CommandText = "sp_addrolemember 'db_owner', '" & tbNombre.Text & "'"
            '            .ExecuteNonQuery()
            '         End If
            '         '
            '         Cn.Close()
            '         ConectarDB(Cn, PRV, Svr, "Master", TrustedCnx, Uid, Pwd)
            '         '
            '         .CommandText = "sp_adduser '" & tbUsuario.Text & "', '" & tbNombre.Text & "'"
            '         .ExecuteNonQuery()
            '         .CommandText = "sp_addrolemember 'db_datareader', '" & tbNombre.Text & "'"
            '         .ExecuteNonQuery()
            '         Cn.Close()
            '         '
            '         If DBT <> "" Then
            '            ConectarDB(Cn, PRV, Svr, DBT, TrustedCnx, Uid, Pwd)
            '            .CommandText = "sp_adduser '" & tbUsuario.Text & "', '" & tbNombre.Text & "'"
            '            .ExecuteNonQuery()
            '            .CommandText = "sp_addrolemember 'db_owner', '" & tbNombre.Text & "'"
            '            .ExecuteNonQuery()
            '            Cn.Close()
            '         End If
            '         '
            '         ConectarDB(Cn, PRV, Svr, DBN, TrustedCnx, Uid, Pwd)
            '         '
            '      End With
            '   End If
            'End If
         Else
            'If PRV = "Jet" Or AutDB Then
            With Cmd
               If Cc Then
                  .CommandText = "UPDATE Usuarios SET " &
                                    "  Contraseña = '" & Encrypt(tbContraseña.Text) & "', " &
                                    "  UsuMod = '" & Uid & "', " &
                                    "  FechaMod = '" & Format(Now, FormatFechaHora) & "' " &
                                     "WHERE Usuario = '" & tbUsuario.Text & "'"
               Else
                  .CommandText = "UPDATE Usuarios SET " &
                                    "  Nombre = '" & tbNombre.Text & "', " &
                                    "  Permisos = " & IIf(optParciales.Checked, 0, 1) & ", " &
                                    "  Admin = " & IIf(chkAdmin.Checked, 1, 0) & ", " &
                                    "  UsuMod = '" & Uid & "', " &
                                    "  FechaMod = '" & Format(Now, FormatFechaHora) & "' " &
                                     "WHERE Usuario = '" & tbUsuario.Text & "'"
               End If
               .ExecuteNonQuery()
            End With
            'End If
            '
            'If Not TrustedCnx Then
            '   If PRV = "SQLOLEDB" Then
            '      With Cmd
            '         .CommandText = "sp_password NULL, '" & tbContraseña.Text & "','" & tbUsuario.Text & "'"
            '         .ExecuteNonQuery()
            '         If optParciales.Checked Then
            '            .CommandText = "sp_addrolemember 'db_datareader', '" & tbUsuario.Text & "'"
            '            .ExecuteNonQuery()
            '            .CommandText = "sp_addrolemember 'db_datawriter', '" & tbUsuario.Text & "'"
            '            .ExecuteNonQuery()
            '         Else
            '            .CommandText = "sp_addrolemember 'db_owner', '" & tbUsuario.Text & "'"
            '            .ExecuteNonQuery()
            '         End If
            '      End With
            '   End If
            'End If
         End If
         '
         'Trn.Commit()
         '
         'If optTotales Then
         '   If chkAdminSeg = 1 Then
         '      If AutDB Then
         '         Cn.Execute "UPDATE Usuarios SET " & _
         '                    " Admin = " & chkAdminSeg & ", " & _
         '                    " UsuMod = '" & Uid & "', " & _
         '                    " FechaMod = '" & Format(Now, FormatFechaHora) & "' " & _
         '                    "WHERE Usuario = '" & tbUsuario & "'"
         '      Else
         '         Cn.Execute "sp_addsrvrolemember '" & tbUsuario & "', 'SysAdmin'"
         '      End If
         '      'Cn.Execute "sp_addsrvrolemember '" & tbUsuario & "', 'SecurityAdmin'"
         '   End If
         'End If
         '
         'Cn.CommitTrans()
         '
         'If tbUsuario = Uid Then
         '   If Not AutDB Then
         '      With Cn
         '         .Close()
         '         .ConnectionString = "SERVER=" & Svr & ";" & _
         '                             "DATABASE=" & DBN & ";" & _
         '                              "UID=" & tbUsuario & ";" & _
         '                              "PWD=" & tbContraseña
         '         .Open()
         '      End With
         '   End If
         'End If
         '
         GuardarAudit(IIf(Alta, "Alta", "Modificación") & " de Usuario", "Usr: " & tbUsuario.Text, Me.Name, "Guardar")
         '
         ActData()
         '
      Catch
         '
         Dim st As New StackTrace(True)
         RegistrarError(st, Me.Name)
         '
      End Try
      '
   End Sub
   '
   Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
      ActivaCtrl(False)
   End Sub
   '
   Private Function Validar(Cc As Boolean) As Boolean
      '
      If tbUsuario.Text = "" Then
         MsgBox("Debe ingresar Usuario", vbInformation)
         tbUsuario.Focus()
         Exit Function
      End If
      '
      If tbNombre.Text = "" Then
         MsgBox("Debe ingresar nombre completo", vbInformation)
         tbNombre.Focus()
         Exit Function
      End If
      '
      If Cc Then
         If tbContraseña.Text = "" Then
            MsgBox("Debe ingresar Contraseña", vbInformation)
            tbContraseña.Focus()
            Exit Function
         End If
         '
         If tbContraseña.Text <> tbContraseñaR.Text Then
            MsgBox("Contraseñas no coinciden", vbInformation)
            tbContraseña.Focus()
            Exit Function
         End If
      End If
      '
      Validar = True
      '
   End Function
   '
   Private Sub optParciales_CheckedChanged(sender As Object, e As EventArgs) Handles optParciales.CheckedChanged
      ActivaCtrl(optParciales.Enabled)
   End Sub
   '
   Private Sub optTotales_CheckedChanged(sender As Object, e As EventArgs) Handles optTotales.CheckedChanged
      ActivaCtrl(optTotales.Enabled)
   End Sub
   '
   Private Sub tbBuscar_TextChanged(sender As Object, e As EventArgs) Handles tbBuscar.TextChanged
      ActData()
   End Sub
   '
   Private Sub cmdSalir_Click(sender As Object, e As EventArgs) Handles cmdSalir.Click
      Me.Close()
   End Sub
   '
   Private Sub frmUsuarios_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
      SetRegGrid(Me, DataGridView1)
      SetRegForm(Me)
      Me.Dispose()
   End Sub
   '
End Class