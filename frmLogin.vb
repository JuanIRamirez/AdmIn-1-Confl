Imports System.IO

Public Class FrmLogin
   '
   Public cnX As New OleDb.OleDbConnection
   '
   Dim cArchivoReg As String
   '
   ReadOnly hMin As Int16 = 215
   ReadOnly wMin As Int16 = 632
   ReadOnly hMax As Int16 = 529
   ReadOnly wMax As Int16 = 632
   '
   Private Sub FrmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      '
      Me.Text = Sistema & ": " & Traducir("Login")
      '
      Me.Height = hMin
      Me.Width = wMin
      '
      ConfigIni()
      CaptVarIni()
      '
   End Sub
   '
   Private Sub ChkModoPrueba_CheckedChanged(sender As Object, e As EventArgs) Handles chkModoPrueba.CheckedChanged
      ConfigIni(chkModoPrueba.Checked)
      CaptVarIni()
   End Sub
   '
   Private Sub CaptVarIni()
      '
      cArchivoReg = ArchivoIni
      TrustedCnx = True
      AutDB = True
      '
      If Dir(cArchivoReg) <> "" Then
         TrustedCnx = CBool(GetVarTxt(cArchivoReg, "TrustedCnx"))
         Svr = GetVarTxt(cArchivoReg, "Server")
         PRV = GetVarTxt(cArchivoReg, "Proveedor")
         DBN = GetVarTxt(cArchivoReg, "DataBase")
         DBT = GetVarTxt(cArchivoReg, "DBTemp")
         DSN = GetVarTxt(cArchivoReg, "ODBC")
         RPT = GetVarTxt(cArchivoReg, "Reportes")
         AutDB = True   'Val(GetVarTxt(cArchivoReg, "AutDB"))
         Uid = GetVarTxt(cArchivoReg, "Usuario")
         regPID = GetVarTxt(cArchivoReg, "PID")
         UsrDb = GetVarTxt(cArchivoReg, "UsrDB")
         PwdDb = Encrypt(GetVarTxt(cArchivoReg, "PwdDB"), True)
      End If
      '
      tbUsuario.Text = Uid
      chkTruCnx.Checked = TrustedCnx
      tbServidor.Text = Svr
      tbCatalogo.Text = DBN
      tbDbTemp.Text = DBT
      tbReportes.Text = RPT
      tbArchivoCfg.Text = cArchivoReg
      tbUserDb.Text = UsrDb
      tbPwdDb.Text = PwdDb
      '
   End Sub
   '
   Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
      '
      Dim Rs As New OleDb.OleDbCommand
      Dim Dr As OleDb.OleDbDataReader
      Dim NomUsuario As String
      '
      Uid = tbUsuario.Text
      Pwd = tbContraseña.Text
      '
      Svr = tbServidor.Text
      DBN = tbCatalogo.Text
      DBT = tbDbTemp.Text
      RPT = tbReportes.Text
      AutDB = chkTruCnx.Checked
      TrustedCnx = chkTruCnx.Checked
      UsrDb = tbUserDb.Text
      PwdDb = tbPwdDb.Text
      '
      If Not Validar() Then Exit Sub
      '
      Try
         '
         If ConectarDB(cnX, PRV, Svr, DBN, TrustedCnx, UsrDb, PwdDb) Then
            '
            'If Not AutDB Then
            '   LGR = LoginRight(cnX, tbUsuario.Text)
            'Else
            If Not ExisteTabla(cnX, "Usuarios") Then
               If tbUsuario.Text = "Admin" Then
                  '
                  Crear_DB(cnX)
                  '
               Else
                  Err.Raise(1001, , "Tabla Usuarios no encontrada", vbInformation)
               End If
            End If
            If CapturaDato(cnX, "Usuarios", "COUNT(1)", "") = 0 Then
               With Rs
                  .Connection = cnX
                  .CommandText = "INSERT INTO Usuarios( Usuario, Nombre, [Contraseña], Permisos, Admin, UsuMod, FechaMod) " &
                                 "VALUES('" & tbUsuario.Text & "', 'Administrador', '" & Encrypt(tbContraseña.Text) & "', 1, 1, 'Login', '" & Format(Now, FormatFechaHora) & "')"
                  .ExecuteNonQuery()
               End With
            End If
            'End If
            '
            NomUsuario = CaptNomUsuario(tbUsuario.Text, cnX)
            '
            With Rs
               .Connection = cnX
               .CommandText = "SELECT Usuario, Nombre, Permisos, Admin FROM Usuarios " &
                              "WHERE Usuario = '" & tbUsuario.Text & "'" &
                              IIf(LGR, "", "  AND [contraseña] = '" & Encrypt(tbContraseña.Text) & "'")
               Dr = .ExecuteReader
            End With
            '
            With Dr
               If .Read Then
                  NomUsuario = !Nombre
                  LGR = !Permisos
                  usrAdmin = !Admin
               Else
                  .Close()
                  cnX.Close()
                  Mensaje("Usuario o Contraseña incorrecto(s)")
                  tbContraseña.Focus()
                  Exit Sub
               End If
               .Close()
            End With
            '
            If NomUsuario = "" Then
               MsgBox("Usuario no permitido en la Base de Datos", vbInformation)
               cnX.Close()
               Exit Sub
            End If
            '
            GroupName = CaptGroupName(NomUsuario)
            '
            strDEL = IIf(PRV = "Jet", " * FROM ", "")
            strFEC = IIf(PRV = "Jet", "#", "'")
            strLIKE = IIf(PRV = "Jet", "*", "%")
            FormatFecha = IIf(PRV = "Jet", "yyyy/MM/dd", "yyyyMMdd")
            FormatFechaHora = IIf(PRV = "Jet", "yyyy/MM/dd HH:mm", "yyyyMMdd HH:mm")
            FormatFechaVenc = IIf(PRV = "Jet", "yyyy/MM", "yyyyMM")
            ModoPrueba = chkModoPrueba.Checked
            '
            GuardaConfigTxt(cArchivoReg)
            '
            Cn = cnX
            cnX.Close()
            Cn.Open()
            '
            GuardarAudit("Login", "Ingreso al sistema", Me.Name, "")
            '
            Me.Hide()
            '
            frmMenu.Show()
            '
         End If
         '
         Exit Sub
         '
      Catch ex As System.Exception
         Dim st As New StackTrace(True)
         RegistrarError(st, "Login.Aceptar", True, Err.Description)
         If cnX.State = 1 Then
            cnX.Close()
         End If
      End Try
      '
   End Sub
   '
   Private Function Validar() As Boolean
      '
      If tbUsuario.Text = "" Then
         MsgBox("Debe ingresar Usuario", vbInformation)
         tbUsuario.Focus()
         Exit Function
      End If
      '
      If Svr = "" Then
         MsgBox("Servidor no definido", vbInformation)
         Exit Function
      End If
      '
      If PRV = "" Then
         MsgBox("Proveedor no definido", vbInformation)
         Exit Function
      End If
      '
      If DBN = "" Then
         MsgBox("Base de Datos no definida", vbInformation)
         Exit Function
      End If
      '
      If Not TrustedCnx Then
         If tbUserDb.Text = "" Or tbPwdDb.Text = "" Then
            MsgBox("Debe ingresar Usuario y Contraseña de la DB", vbInformation)
            If tbUserDb.Text = "" Then
               tbUserDb.Focus()
            Else
               tbPwdDb.Focus()
            End If
            Exit Function
         End If
      End If
      '
      Return True
      '
   End Function
   '
   Private Sub CmdDetalles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDetalles.Click
      Detalles()
   End Sub
   '
   Private Sub Detalles()
      '
      Dim Edit As Boolean = True
      '
      If Me.Height < hMax Then
         Me.Width = wMax
         Me.Height = hMax
         cmdDetalles.Text = "&Ocultar"
         If tbServidor.Text = "" Then
            Edit = True
         End If
         chkTruCnx.Enabled = Edit
         tbServidor.Enabled = Edit
         tbCatalogo.Enabled = Edit
         tbDbTemp.Enabled = Edit
         tbReportes.Enabled = Edit
         btnValDef.Enabled = Edit
      Else
         Me.Width = wMin
         Me.Height = hMin
         cmdDetalles.Text = "&Det. Conexión"
      End If
      '
   End Sub
   '
   Private Sub BtnValDef_Click(sender As Object, e As EventArgs) Handles btnValDef.Click
      tbUsuario.Text = "Admin"
      chkTruCnx.Checked = True
      tbServidor.Text = "(Local)\SqlExpress"
      tbCatalogo.Text = "Admin"
      tbDbTemp.Text = "RsTemp"
      tbReportes.Text = Application.StartupPath & "\Reportes"
   End Sub
   '
   Private Sub chkTruCnx_CheckedChanged(sender As Object, e As EventArgs) Handles chkTruCnx.CheckedChanged
      tbUserDb.Enabled = Not chkTruCnx.Checked
      tbPwdDb.Enabled = Not chkTruCnx.Checked
   End Sub

   '
   Private Sub BtnCrearDB_Click(sender As Object, e As EventArgs) Handles btnCrearDB.Click
      '
      Dim cnM As New OleDb.OleDbConnection
      Dim cmd As New OleDb.OleDbCommand
      '
      If Validar() Then
         Try
            If Trim(tbCatalogo.Text) = "" Then
               MsgBox("Debe ingresar el nombre de la Base de Datos o Catálogo", vbInformation)
               tbCatalogo.Focus()
            Else
               If ConectarDB(cnM, PRV, tbServidor.Text, "", chkTruCnx.Checked, tbUsuario.Text, tbContraseña.Text) Then
                  cnM.Close()
                  If ConectarDB(cnM, PRV, tbServidor.Text, tbCatalogo.Text, chkTruCnx.Checked, tbUsuario.Text, tbContraseña.Text) Then
                     'Crear_DB(cnM)
                     With cmd
                        .Connection = cnM
                        .CommandText = File.OpenText(Application.StartupPath & "\sql\Admin.sql").ReadToEnd()
                        .ExecuteNonQuery()
                     End With
                     cnM.Close()
                  Else
                     If ConectarDB(cnM, PRV, tbServidor.Text, "", chkTruCnx.Checked, tbUsuario.Text, tbContraseña.Text) Then
                        cmd.Connection = cnM
                        cmd.CommandText = "CREATE DATABASE " & tbCatalogo.Text
                        cmd.ExecuteNonQuery()
                        Crear_DB(cnM)
                        cnM.Close()
                     End If
                  End If
                  MsgBox("Base de Datos creada con éxito")
               End If
            End If
         Catch er As OleDb.OleDbException
            Dim st As New StackTrace(True)
            RegistrarError(st, Me.Name)
         End Try
      End If
      '
   End Sub
   '
   Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
      Application.Exit()
   End Sub
   '
End Class