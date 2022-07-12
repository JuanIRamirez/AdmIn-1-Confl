Public Class frmPermisos
   '
   Public Objeto As String
   '
   Dim Trn As OleDb.OleDbTransaction
   Dim Cmd As New OleDb.OleDbCommand
   '
   Private Sub frmPermisos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      '
      GetRegForm(Me)
      '
      lblUsuariosDe.Text = "Usuarios de " & Objeto

      Actdata1()
      ActData2()
      '
   End Sub
   '
   Private Sub Actdata1()
      '
      SetRegGrid(Me, DataGridView1)
      '
      Dim cSql As String
      'If PRV = "Jet" Or AutDB Then
      cSql = "SELECT Usuario, Nombre FROM Usuarios " & _
                         "WHERE Admin = 0 AND Usuario NOT IN " & _
                         "(SELECT Usuario FROM Permisos WHERE Objeto  = '" & Objeto & "') " & _
                         "ORDER BY Usuario"
      'Else
      '   cSql = "SELECT M.Name as Usuario, U.Name as Nombre " & _
      '                   "FROM SysUsers U, Master..SysXLogins M " & _
      '                   "WHERE U.Status = 2 AND U.UId > 2 " & _
      '                   " AND U.Sid = M.Sid " & _
      '                   " AND M.Name NOT IN " & _
      '                   "(SELECT Usuario FROM Permisos WHERE Objeto  = '" & Objeto & "') " & _
      '                   "ORDER BY Usuario"
      'End If
      '
      LlenarGrid(DataGridView1, cSql)
      btnAgregar.Enabled = (DataGridView1.RowCount > 0)
      '
      GetRegGrid(Me, DataGridView1)
      '
   End Sub
   '
   Private Sub ActData2()
      '
      SetRegGrid(Me, DataGridView2)
      '
      Dim cSql As String
      '
      'If PRV = "Jet" Or AutDB Then
      cSql = "SELECT Permisos.Usuario, Usuarios.Nombre " & _
                         "FROM Permisos INNER JOIN Usuarios " & _
                         " ON Permisos.Usuario = Usuarios.Usuario " & _
                         "WHERE Objeto = '" & Objeto & "' " & _
                         "ORDER BY Permisos.Usuario"
      'Else
      '   cSql = "SELECT P.Usuario, U.Name AS Nombre " & _
      '                   "FROM Permisos P, SysUsers U, Master..SysXLogins M " & _
      '                   "WHERE P.Objeto = '" & Objeto & "' " & _
      '                   " AND P.Usuario = M.Name " & _
      '                   " AND M.Sid = U.Sid " & _
      '                   "ORDER BY P.Usuario"
      'End If
      '
      LlenarGrid(DataGridView2, cSql)
      '
      btnQuitar.Enabled = (DataGridView2.RowCount > 0)
      '
      GetRegGrid(Me, DataGridView2)
      '
   End Sub
   '
   Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
      '
      Dim Usuario As String
      '
      With DataGridView1
         Usuario = .SelectedCells(.Columns("Usuario").Index).Value
      End With
      '
      Trn = cn.BeginTransaction
      '
      With Cmd
         .Connection = cn
         .Transaction = Trn
         .CommandText = "INSERT INTO Permisos( Usuario, Objeto, UsuMod, FechaMod) " & _
                        "VALUES('" & Usuario & "' , '" & Objeto & "', '" & Uid & "', '" & Format(Now, FormatFechaHora) & "') "
         .ExecuteNonQuery()
      End With
      '
      Trn.Commit()
      '
      Actdata1()
      ActData2()
      '
   End Sub
   '
   'Private Sub cmdAgregarT_Click()
   '   '
   '   With Adodc1.Recordset
   '      .MoveFirst()
   '      Do Until .EOF
   '         Cnx.BeginTrans()
   '         Cnx.Execute "INSERT INTO Permisos( Usuario, Objeto, UsuMod, FechaMod)" & _
   '                    " VALUES('" & !Usuario & "' , '" & Objeto & "', '" & Uid & "', '" & Format(Now, FormatFechaHora) & "') "
   '         Cnx.CommitTrans()
   '         .MoveNext()
   '      Loop
   '   End With
   '   '
   '   Actdata1()
   '   ActData2()
   '   '
   'End Sub
   '
   Private Sub btnQuitar_Click(sender As Object, e As EventArgs) Handles btnQuitar.Click
      '
      Dim Usuario As String
      '
      With DataGridView2
         Usuario = .SelectedCells(.Columns("Usuario").Index).Value
      End With
      '
      Trn = cn.BeginTransaction
      '
      With Cmd
         .Connection = cn
         .Transaction = Trn
         .CommandText = "DELETE " & strDEL & " Permisos " & _
                        "WHERE Usuario = '" & Usuario & "' " & _
                        "  AND Objeto  = '" & Objeto & "'"
         .ExecuteNonQuery()
      End With
      '
      Trn.Commit()
      '
      Actdata1()
      ActData2()
      '
   End Sub
   '
   'Private Sub cmdQuitarT_Click()
   '   '
   '   With Adodc2.Recordset
   '      Cnx.BeginTrans()
   '      Cnx.Execute "DELETE " & strDEL & " Permisos " & _
   '                  "WHERE Objeto  = '" & Objeto & "'"
   '      Cnx.CommitTrans()
   '   End With
   '   '
   '   Actdata1()
   '   ActData2()
   '   '
   'End Sub
   '
   Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
      Me.Close()
   End Sub
   '
   Private Sub frmPermisos_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
      SetRegGrid(Me, DataGridView1)
      SetRegGrid(Me, DataGridView2)
      SetRegForm(Me)
   End Sub
   '
End Class