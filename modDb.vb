Module modDb
   '
   Public Cn As New OleDb.OleDbConnection
   Public IngDesc As Boolean = True
   '
   Public Function ConectarDB(ByRef cnx As OleDb.OleDbConnection, ByVal Provider As String, ByVal Server As String, ByVal Catalog As String, ByVal Trusted As Boolean, Optional ByVal UserID As String = "", Optional ByVal Pass As String = "") As Boolean
      '
      Dim r As Boolean = False
      Dim m As String = ""
      Dim s As String
      '
      If cnx.State = 0 Then
         If Trusted Then
            cnx.ConnectionString = "Provider=" & Provider & "; Integrated Security=SSPI; Persist Security Info=False; Data Source=" & Server & ";Initial Catalog=" & Catalog & ";"
         Else
            cnx.ConnectionString = "Provider=" & Provider & "; Data Source=" & Server & ";Initial Catalog=" & Catalog & ";User ID=" & UserID & ";Password=" & Pass & ";"
         End If
         Try
            cnx.Open()
            r = True
         Catch ex As Exception
            m = ex.Message
            s = Err.Source
            r = False
            Dim st As New StackTrace(True)
            RegistrarError(st, "ConectarDb", , "No se pudo conectar a la Base de Datos: " & Catalog, s)
         End Try
      Else
         Mensaje("Ya conectado")
      End If
      '
      Return r
      '
   End Function
   '
   Function Crear_DB(Cnx As OleDb.OleDbConnection) As Boolean
      '
      Dim Rs As New OleDb.OleDbCommand
      '
      With Rs
         .Connection = Cnx
         .CommandText = "CREATE TABLE Usuarios ([Usuario] [varchar](50) NOT NULL, " &
                                " [Nombre] [varchar](50) NOT NULL, " &
                                " [Contraseña] [varchar](50) NOT NULL, " &
                                " [Admin] [bit] NOT NULL, " &
                                " [UsuMod] [varchar](50) NOT NULL, " &
                                " [FechaMod] [smalldatetime] NOT NULL, " &
                                " [Permisos] [bit] NOT NULL DEFAULT 0, " &
                                "CONSTRAINT [PK_Usuarios] PRIMARY KEY ([Usuario]))"
         .ExecuteNonQuery()
         If Not ExisteTabla(Cnx, "ConfigUsu") Then
            .CommandText = "CREATE TABLE [ConfigUsu]( " &
                           " [CfuUsuario] [varchar](25) NOT NULL, " &
                           " [CfuForm] [varchar](32) NOT NULL, " &
                           " [CfuControl] [varchar](32) NOT NULL, " &
                           " [CfuColName] [varchar](32) NOT NULL, " &
                           " [CfuWState] [smallint] NOT NULL DEFAULT 0, " &
                           " [CfuLeft] [smallint] NOT NULL DEFAULT 0, " &
                           " [CfuTop] [smallint] NOT NULL DEFAULT 0, " &
                           " [CfuWidth] [smallint] NOT NULL DEFAULT 0, " &
                           " [CfuHeight] [smallint] NOT NULL DEFAULT 0, " &
                           " [CfuValor] [varchar](250) NULL, " &
                           " [CfuFecMod] [smalldatetime] NOT NULL, " &
                           "CONSTRAINT [PK_ConfigUsu] PRIMARY KEY ([CfuUsuario] ASC, [CfuForm] ASC, [CfuControl] ASC, [CfuColName] Asc))"
            .ExecuteNonQuery()
         End If
         If Not ExisteTabla(Cnx, "Audit") Then
            .CommandText = "CREATE TABLE [dbo].[Audit]( " &
                           " [AuditID] [Int] IDENTITY(1, 1) Not NULL, " &
                           " [AuditDescrip] [varchar](250) Not NULL, " &
                           " [AuditDetalle] [varchar](512) NULL, " &
                           " [AuditFecha] [smalldatetime] Not NULL, " &
                           " [AuditProceso] [varchar](50) Not NULL, " &
                           " [AuditSubProc] [varchar](50) NULL, " &
                           " [AuditUid] [varchar](25) Not NULL, " &
                           " [AuditPC] [varchar](50) Not NULL, " &
                           "CONSTRAINT [PK_Audit] PRIMARY KEY ([AuditID] Asc))"
            .ExecuteNonQuery()
         End If
         If Not ExisteTabla(Cnx, "Config") Then
            .CommandText = "CREATE TABLE [dbo].[Config]( " &
                           " [Clave] [varchar](50) Not NULL, " &
                           " [Descrip] [varchar](50) NULL, " &
                           " [Mostrar] [varchar](50) NULL, " &
                           " [Valor] [varchar](250) NULL, " &
                           " [FechaMod] [smalldatetime] Not NULL, " &
                           " CONSTRAINT [PK_Config] PRIMARY KEY ([Clave] Asc))"
            .ExecuteNonQuery()
         End If
         If Not ExisteTabla(Cnx, "AlicIva") Then
            .CommandText = "CREATE TABLE [dbo].[AlicIva]( " &
                           " [Codigo] [nvarchar](3) Not NULL, " &
                           " [Descrip] [nvarchar](50) Not NULL, " &
                           " [Alicuo1] [real] NULL, " &
                           " [Alicuo2] [real] NULL, " &
                           " [Usuario] [nvarchar](50) NULL, " &
                           " [FechaMod] [smalldatetime] NULL, " &
                           " [AlicIva] [varchar](10) Not NULL, " &
                           "CONSTRAINT [PK_AlicIva] PRIMARY KEY ([Codigo] Asc))"
            .ExecuteNonQuery()
         End If
         If Not ExisteTabla(Cnx, "TipoIva") Then
            .CommandText = "CREATE TABLE [dbo].[TipoIva]( " &
                           " [Codigo] [varchar](3) Not NULL, " &
                           " [Descrip] [varchar](50) Not NULL, " &
                           " [EmiteComp] [varchar](10) NULL, " &
                           " [RecibeComp] [varchar](10) NULL, " &
                           " [Usuario] [varchar](20) Not NULL, " &
                           " [FechaMod] [smalldatetime] Not NULL, " &
                           " [TipoIva] [Int] IDENTITY(1, 1) Not NULL, " &
                           "CONSTRAINT [PK_TipoIva] PRIMARY KEY ([Codigo] Asc))"
            .ExecuteNonQuery()
         End If
         If Not ExisteTabla(Cnx, "CatGcias") Then
            .CommandText = "CREATE TABLE [dbo].[CatGcias]( " &
                           " [Codigo] [smallint] Not NULL, " &
                           " [Descrip] [nvarchar](50) Not NULL, " &
                           " [Abrev] [nvarchar](5) Not NULL, " &
                           " [Alicuota] [real] Not NULL, " &
                           " [MinimoImp] [float] Not NULL, " &
                           " [RetMinima] [float] Not NULL, " &
                           " [Usuario] [varchar](20) Not NULL, " &
                           " [FechaMod] [smalldatetime] Not NULL, " &
                           "CONSTRAINT [PK_CatGcias] PRIMARY KEY ([Codigo] Asc))"
            .ExecuteNonQuery()
         End If
         If Not ExisteTabla(Cnx, "Cajas") Then
            .CommandText = "CREATE TABLE [dbo].[Cajas]( " &
                           " [Caja] [smallint] Not NULL, " &
                           " [Descrip] [varchar](50) Not NULL, " &
                           " [Responsable] [varchar](50) Not NULL, " &
                           " [Cuenta] [varchar](12) NULL, " &
                           " [CtaAdm] [varchar](12) NULL, " &
                           " [SdoAnt] [float] NULL, " &
                           " [SdoAct] [float] NULL, " &
                           " [SubTitulo] [varchar](50) NULL, " &
                           " [UltNroMN] [Int] NULL, " &
                           " [Usuario] [varchar](20) Not NULL, " &
                           " [FechaMod] [smalldatetime] Not NULL, " &
                           " Constraint [PK_Cajas] PRIMARY KEY ([Caja] Asc))"
            .ExecuteNonQuery()
         End If
         If Not ExisteTabla(Cnx, "Localidad") Then
            .CommandText = "CREATE TABLE [dbo].[Localidad]( " &
                           " [Codigo] [varchar](10) Not NULL, " &
                           " [Descrip] [varchar](50) Not NULL, " &
                           " [Provincia] [varchar](50) NULL, " &
                           " [Pais] [smallint] NULL, " &
                           " [Usuario] [varchar](20) Not NULL, " &
                           " [FechaMod] [smalldatetime] Not NULL, " &
                           " [LocalidadId] [Int] IDENTITY(1, 1) Not NULL, " &
                           "CONSTRAINT [PK_Localidad] PRIMARY KEY ([LocalidadId] Asc))"
            .ExecuteNonQuery()
         End If
         If Not ExisteTabla(Cnx, "Idiomas") Then
            .CommandText = "CREATE TABLE [dbo].[Idiomas]( " &
                           " [Idioma] [varchar](10) Not NULL, " &
                           " [Descrip] [varchar](50) NULL)"
            .ExecuteNonQuery()
         End If
         If Not ExisteTabla(Cnx, "EstLiquid") Then
            .CommandText = "CREATE TABLE [dbo].[EstLiquid]( " &
                           " [Estado] [smallint] Not NULL, " &
                           " [Descrip] [nvarchar](50) Not NULL, " &
                           " [Usuario] [nvarchar](10) Not NULL, " &
                           " [FechaMod] [smalldatetime] NULL, " &
                           "CONSTRAINT [PK_EstLiquid] PRIMARY KEY ([Estado] Asc))"
            .ExecuteNonQuery()
         End If
         If Not ExisteTabla(Cnx, "EstContr") Then
            .CommandText = "CREATE TABLE [dbo].[EstContr]( " &
                           " [Estado] [smallint] Not NULL, " &
                           " [Descrip] [nvarchar](50) Not NULL, " &
                           " [Usuario] [nvarchar](10) Not NULL, " &
                           " [FechaMod] [smalldatetime] NULL, " &
                           "CONSTRAINT [PK_EstContr] PRIMARY KEY ([Estado] Asc))"
            .ExecuteNonQuery()
         End If
         If Not ExisteTabla(Cnx, "EstChCartera") Then
            .CommandText = "CREATE TABLE [dbo].[EstChCartera]( " &
                           " [Estado] [smallint] Not NULL, " &
                           " [Descrip] [nvarchar](50) Not NULL, " &
                           " [Usuario] [nvarchar](10) Not NULL, " &
                           " [FechaMod] [smalldatetime] NULL, " &
                           "CONSTRAINT [PK_EstChCartera] PRIMARY KEY ([Estado] Asc))"
            .ExecuteNonQuery()
         End If
         If Not ExisteTabla(Cnx, "Conceptos") Then
            .CommandText = "CREATE TABLE [dbo].[Conceptos]( " &
                           " [Codigo] [varchar](10) Not NULL, " &
                           " [Descrip] [varchar](50) Not NULL, " &
                           " [Accion] [nvarchar](1) Not NULL, " &
                           " [Cuenta] [varchar](50) NULL, " &
                           " [CtaAdm] [varchar](50) NULL, " &
                           " [Comision] [bit] Not NULL, " &
                           " [Prioridad] [smallint] NULL, " &
                           " [ImpDef] [float] NULL, " &
                           " [Usuario] [varchar](20) Not NULL, " &
                           " [FechaMod] [smalldatetime] Not NULL, " &
                           " [ConceptoId] [Int] IDENTITY(1, 1) Not NULL, " &
                           "CONSTRAINT [PK_Conceptos] PRIMARY KEY ([Codigo] Asc))"
            .ExecuteNonQuery()
         End If
         If Not ExisteTabla(Cnx, "TipoMovBco") Then
            .CommandText = "CREATE TABLE [dbo].[TipoMovBco]( " &
                           " [TipoMovBco] [smallint] Not NULL, " &
                           " [Descrip] [nvarchar](50) Not NULL, " &
                           " [Imput] [nvarchar](1) Not NULL, " &
                           " [TipoMov] [nvarchar](2) NULL, " &
                           " [Cuenta] [nvarchar](10) NULL, " &
                           " [Usuario] [nvarchar](10) Not NULL, " &
                           " [FechaMod] [smalldatetime] Not NULL, " &
                           "CONSTRAINT [PK_TipoMovBco] PRIMARY KEY ([TipoMovBco] Asc))"
            .ExecuteNonQuery()
         End If
         If Not ExisteTabla(Cnx, "Logicos") Then
            .CommandText = "CREATE TABLE [dbo].[Logicos]( " &
                           " [Dato] [bit] Not NULL, " &
                           " [SN] [varchar](10) NULL, " &
                           " [VF] [varchar](10) NULL, " &
                           " [Comision] [varchar](10) NULL, " &
                           " [Marca] [varchar](10) NULL, " &
                           "CONSTRAINT [PK_Logicos] PRIMARY KEY ([Dato] Asc))"
            .ExecuteNonQuery()
         End If
         If Not ExisteTabla(Cnx, "Traductor") Then
            .CommandText = "CREATE TABLE [dbo].[Traductor]( " &
                           " [Control] [nvarchar](20) Not NULL, " &
                           " [Palabra] [nvarchar](20) NULL, " &
                           " [Descrip] [nvarchar](50) NULL, " &
                           " [ENGLISH] [nvarchar](50) NULL, " &
                           " [ESPAÑOL] [nvarchar](128) NULL, " &
                           " [Sistema] [nvarchar](10) NULL, " &
                           " [FechaMod] [smalldatetime] Not NULL, " &
                           "CONSTRAINT [PK_Traductor] PRIMARY KEY ([Control] Asc))"
            .ExecuteNonQuery()
         End If
         If Not ExisteTabla(Cnx, "EstPagos") Then
            .CommandText = "CREATE TABLE [dbo].[EstPagos]( " &
                           "[Estado] [smallint] Not NULL, " &
                           " [Descrip] [nvarchar](50) Not NULL, " &
                           " [Usuario] [nvarchar](10) Not NULL, " &
                           " [FechaMod] [smalldatetime] NULL, " &
                           "CONSTRAINT [PK_EstPagos] PRIMARY KEY ([Estado] Asc))"
            .ExecuteNonQuery()
         End If
      End With
      '
   End Function
   '
   Function LoginRight(ByVal Cnx As OleDb.OleDbConnection, ByVal Usuario As String) As Boolean
      '
      If Cnx.ConnectionString = "" Then
         Exit Function
      End If
      '
      Dim Rs As New OleDb.OleDbCommand
      Dim Dr As OleDb.OleDbDataReader
      '
      Rs.Connection = Cnx
      'If AutDB Then
      If Not ExisteTabla(Cnx, "Usuarios") Then
         Err.Raise(1001, , "Tabla Usuarios no encontrada", vbInformation)
         End
      End If
      With Rs
         .CommandText = "SELECT Admin, Permisos FROM Usuarios " &
                           "WHERE Usuario = '" & Usuario & "'"
         Dr = .ExecuteReader
      End With
      With Dr
         If Dr.Read Then
            LoginRight = !Admin Or !Permisos
         Else
            .Close()
            Cnx.Close()
            Err.Raise(1001, , "Usuario o Contraseña incorrecto(s)", vbInformation)
         End If
         .Close()
      End With
      'Else
      '   If PRV = "Sql" Or PRV = "SQLOLEDB" Then
      '      If LCase(Usuario) = "sa" Then
      '         LoginRight = True
      '      Else
      '         With Rs
      '            .CommandText = "SELECT X.Sid, S.Uid, M.GroupUid " &
      '                          "FROM Master.." & IIf(PRV = "Sql", "SysXLogins", "SysLogins") & " X, SysUsers S, SysMembers M " &
      '                          "WHERE X.Name = '" & Usuario & "' " &
      '                          "  AND X.Sid = S.Sid " &
      '                          "  AND S.Uid = M.MemberUid"
      '            Dr = .ExecuteReader
      '         End With
      '         With Dr
      '            If .Read Then
      '               LoginRight = IIf(!GroupUid = 16384, True, False)
      '            End If
      '            .Close()
      '         End With
      '      End If
      '   End If
      'End If
      '
   End Function
   '
   Public Sub LlenarGrid(ByRef DataGrid As DataGridView, ByVal Sql As String)
      '
      Dim ds As New DataSet
      '
      Try
         Dim da As New OleDb.OleDbDataAdapter(Sql, Cn)
         '
         ds.Tables.Add("Tabla")
         da.Fill(ds.Tables("Tabla"))
         '
         DataGrid.DataSource = ds.Tables("Tabla")
         DataGrid.Refresh()
         '
      Catch ex As Exception
         Dim st As New StackTrace(True)
         RegistrarError(st, "LlenarGrid", , ex.Message)
      End Try
      '
   End Sub
   '
   Public Sub ArmaCombo(ByRef Combo As ComboBox, ByVal Columna As String, ByVal Tabla As String, Optional ByVal Orden As String = "", Optional ByVal Filtro As String = "", Optional ByVal Grupo As String = "", Optional ByVal Primero As String = "(Seleccionar)", Optional ByVal Distintos As Boolean = False)
      LlenarCbo(Combo, Tabla, Columna, Orden, Primero, Filtro, Grupo, , Distintos)
   End Sub
   '
   Public Sub LlenarCbo(ByRef Combo As ComboBox, ByVal Tabla As String, ByVal Columna As String, Optional ByVal Orden As String = "", Optional ByVal Primero As String = "", Optional ByVal Filtro As String = "", Optional ByVal Grupo As String = "", Optional ByVal colOpc As String = "", Optional ByVal Distintos As Boolean = False)
      '
      Dim cm As New OleDb.OleDbCommand
      Dim dr As OleDb.OleDbDataReader
      Dim sql As String = "SELECT " + IIf(Distintos, "DISTINCT ", "") & Columna & " AS Columna " & _
                          "FROM " & Tabla & _
                          IIf(Filtro = "", "", " WHERE " & Filtro) & _
                          IIf(Grupo = "", "", " GROUP BY " & Grupo) & _
                          IIf(Orden = "", "", " ORDER BY " & Orden)
      '
      Try
         cm.Connection = Cn
         cm.CommandText = sql
         '
         dr = cm.ExecuteReader
         '
         With Combo
            .DataSource = Nothing
            .Items.Clear()
            '
            If Primero <> "" Then
               .Items.Insert(0, Primero)
               .SelectedIndex = 0
            End If
            '
            While dr.Read
               .Items.Add(dr.Item(0) & "")
            End While
            '
            If .Items.Count = 1 Then
               .SelectedIndex = 0
            End If
            '
            .Refresh()
            '
         End With
         dr.Close()
         '
      Catch ex As Exception
         Dim st As New StackTrace(True)
         RegistrarError(st, "LlenarCbo", , ex.Message)
      End Try
      '
   End Sub
   '
   Public Sub ArmaComboItem(ByRef ComboBox As ComboBox, ByVal Tabla As String, Optional ByVal colClave As String = "Codigo", Optional ByVal ColDescr As String = "Descrip", Optional ByVal Orden As String = "Descrip", Optional ByVal Primero As String = "(Seleccionar)", Optional ByVal Filtro As String = "", Optional ByVal Grupo As String = "", Optional ByVal colOpc As String = "", Optional ByVal Distintos As Boolean = False, Optional ByVal ValorInicial As Int32 = -1)
      LlenarCboItem(ComboBox, Tabla, colClave, ColDescr, Orden, Primero, Filtro, Grupo, colOpc, Distintos)
      If ValorInicial >= 0 Then
         PosCboItem(ComboBox, ValorInicial)
      End If
   End Sub
   '
   Public Sub LlenarCboItem(ByRef ComboBox As ComboBox, ByVal Tabla As String, Optional ByVal colClave As String = "Codigo", Optional ByVal ColDescr As String = "Descrip", Optional ByVal Orden As String = "Descrip", Optional ByVal Primero As String = "", Optional ByVal Filtro As String = "", Optional ByVal Grupo As String = "", Optional ByVal colOpc As String = "", Optional ByVal Distintos As Boolean = False)
      '
      Dim cm As New OleDb.OleDbCommand
      Dim sql As String = ""
      Dim C1, C2 As String
      '
      If InStr(colClave, ".") = 0 Then
         C1 = colClave
      Else
         C1 = colClave.Split(".").GetValue(1)
      End If
      If InStr(ColDescr, ".") = 0 Then
         If InStr(ColDescr, "+") = 0 Then
            C2 = ColDescr
         Else
            C2 = "ColumnaDescripcion"
         End If
      Else
         C2 = ColDescr.Split(".").GetValue(1)
      End If
      '
      If Primero <> "" Then
         sql = "SELECT -1 AS " & C1 & ", ' " & Primero & "' AS " & C2 & " UNION "
      End If
      '
      sql = sql + "SELECT " + IIf(Distintos, "DISTINCT ", "") & colClave & ", " & ColDescr & colOpc & " AS " & C2 & " " &
                  "FROM " & Tabla &
                   IIf(Filtro = "", "", " WHERE " & Filtro) &
                   IIf(Grupo = "", "", " GROUP BY " & Grupo) &
                   IIf(Orden = "", "", " ORDER BY " & Orden)
      '
      Dim ds As New DataSet
      '
      Try
         Dim da As New OleDb.OleDbDataAdapter(sql, Cn)
         '
         ds.Tables.Add("Tabla")
         da.Fill(ds.Tables("Tabla"))
         '
         With ComboBox
            .DataSource = Nothing
            .Items.Clear()
            .DataSource = ds.Tables(0)
            .DisplayMember = ds.Tables(0).Columns(1).Caption.ToString
            .ValueMember = ds.Tables(0).Columns(0).Caption.ToString
            .Refresh()
         End With
         '
      Catch ex As Exception
         Dim st As New StackTrace(True)
         RegistrarError(st, "ModDb", , ex.Message, "LlenarCboItem")
      End Try
      '
   End Sub
   '
   Public Sub PosCboItem(ByVal Combo As ComboBox, ByVal Valor As Long)
      PosicionarComboItem(Combo, Valor)
   End Sub
   '
   Public Sub PosicionarComboItem(ByVal Combo As ComboBox, ByVal Valor As Long)
      With Combo
         If .Items.Count > 0 Then
            .SelectedValue = Valor
         End If
      End With
   End Sub
   '
   Public Sub PosCombo(ByVal Combo As ComboBox, ByVal Valor As String, Optional ByVal nLeft As Integer = 0)
      Dim i As Int16
      With Combo
         '.ListIndex = -1
         For i = 0 To .Items.Count - 1
            If nLeft = 0 Then
               If .Items.Item(i).ToString = Valor Then
                  .SelectedIndex = i
                  Exit For
               End If
            Else
               If Left(.Items(i).ToString, nLeft) = Valor Then
                  .SelectedIndex = i
                  Exit For
               End If
            End If
         Next i
      End With
   End Sub
   '
   Function CapturaDato(ByRef Cnx As OleDb.OleDbConnection, ByVal Tabla As String, ByVal Columna As String, ByVal Filtro As String, Optional ByVal Mensage As Boolean = False, Optional ByVal Grupo As String = "", Optional ByVal Orden As String = "", Optional ByRef Tr As Object = "", Optional Cmd As Object = "") As Object
      '
      'Dim Rsx As New OleDb.OleDbCommand
      '
      Dim r As Object
      '
      If Cnx.State = 0 Then
         Cnx.Open()
      End If
      '
      If Cmd.ToString = "" Then
         Cmd = New OleDb.OleDbCommand
      End If
      '
      Try
         With Cmd
            '
            .Connection = Cnx
            '
            If Tr.ToString <> "" Then
               .Transaction = Tr
            End If
            .CommandText = "SELECT " & Columna & " FROM " & Tabla &
                           IIf(Filtro = "", "", " WHERE " & Filtro) &
                           IIf(Grupo = "", "", " GROUP BY " & Grupo) &
                           IIf(Orden = "", "", " ORDER BY " & Orden)
            '
            r = .ExecuteScalar
            '
            If IsNothing(r) Then
               If Mensage Then
                  MsgBox(Columna & " no encontrado", vbExclamation)
               End If
            End If
            '
            Return r
            '
         End With
         '
      Catch ex As System.Exception
         Dim st As New StackTrace(True)
         RegistrarError(st, Err.Source, , Err.Description, "CapturaDato()")
         Return ""
      End Try
      '
   End Function
   '
   Function CapturaDatoCn(ByVal Tabla As String, ByVal Columna As String, ByVal Filtro As String, Optional ByVal Mensage As Boolean = False, Optional ByVal Grupo As String = "", Optional ByVal Orden As String = "", Optional ByVal Tr As Object = "") As Object
      '
      Return CapturaDato(cn, Tabla, Columna, Filtro, Mensage, Grupo, Orden, Tr)
      '
   End Function
   '
   Function ExisteDato(ByVal Cnx As OleDb.OleDbConnection, ByVal Tabla As String, ByVal Filtro As String, Optional ByVal Mensage As String = "", Optional ByRef Tr As Object = "") As Boolean
      '
      Dim Rsx As New OleDb.OleDbCommand
      Dim r As Boolean
      '
      With Rsx
         .Connection = Cnx
         If Tr.ToString <> "" Then
            .Transaction = Tr
         End If
         .CommandText = "SELECT COUNT(1) FROM " & Tabla & " WHERE " & Filtro
         '
         If .ExecuteScalar = 0 Then
            If Mensage <> "" Then
               MsgBox(Mensage, vbExclamation)
            End If
            r = False
         Else
            r = True
         End If
         '
         Return r
         '
      End With
      '
   End Function
   '
   Function SuperaRegistros(ByVal Tabla As String, Optional ByVal Mensaje As Boolean = True) As Boolean
      '
      Dim r As Boolean = False
      '
      If TrialVers Then
         '
         Dim cmd As New OleDb.OleDbCommand
         Dim n As Long
         '
         With cmd
            .Connection = cn
            .CommandText = "SELECT COUNT(1) AS CantReg FROM " & Tabla
            n = .ExecuteScalar
            If n >= TrialMaxReg Then
               If Mensaje Then
                  MensajeTrad("TrialVersNoAdd", , False)
               End If
               r = True
            End If
         End With
      End If
      '
      Return r
      '
   End Function
   '
   Public Sub MensajeTrad(ByVal Clave As String, Optional ByVal Idioma As String = "", Optional ByVal mError As Boolean = False, Optional ByVal Tr As Object = "")
      '
      MsgBox(IIf(mError, "Error: ", "") & Traducir(Clave, Idioma, Tr), IIf(mError, vbExclamation, vbInformation))
      '
   End Sub
   '
   Public Function Traducir(ByVal Palabra As String, Optional ByVal Idioma As String = "", Optional ByVal Tr As Object = "") As String
      '
      Dim m As MsgBoxResult
      Dim r As String
      '
      If cn.State = 0 Then
         r = Palabra
      Else
         '
         If Len(Palabra) > 17 Then
            Return Palabra
         End If
         '
         Dim Rs As New OleDb.OleDbCommand
         Dim Rs2 As New OleDb.OleDbCommand
         Dim dr As OleDb.OleDbDataReader
         '
         If Idioma = "" Then Idioma = prmIdioma
         '
         With Rs
            .Connection = Cn
            .CommandText = "SELECT * FROM Traductor WHERE Palabra = '" & Palabra & "'"
            If Tr.ToString <> "" Then
               .Transaction = Tr
            End If
            dr = Rs.ExecuteReader
            If Not dr.HasRows Then
               r = Palabra
               If usrAdmin Then
                  If IngDesc Then
                     m = MsgBox("Mensaje no definido. Ingresa descripción del mensaje ?", MsgBoxStyle.YesNoCancel)
                     If m = MsgBoxResult.Yes Then
                        r = InputBox("Ingrese descripción de " & Palabra & ":")
                        If r <> "" Then
                           With Rs2
                              .Connection = Cn
                              .CommandText = "INSERT INTO Traductor( Control, Palabra, Descrip, [" & IIf(Idioma.ToUpper() = "ESPAÑOL", "ESPAÑOL", "ENGLISH") & "], Sistema, FechaMod) " &
                                             "VALUES( 'msg" & Palabra & "', '" & Palabra & "', '', '" & r & "', '" & Sistema & "', '" & Format(Now, FormatFechaHora) & "')"
                              If Tr.ToString <> "" Then
                                 .Transaction = Tr
                              End If
                              .ExecuteNonQuery()
                           End With
                        End If
                     ElseIf m = MsgBoxResult.Cancel Then
                           IngDesc = False
                     End If
                  End If
               End If
            Else
               dr.Read()
               If dr.Item(Idioma) & "" <> "" Then
                  r = DelChar(dr.Item(Idioma), "&")
               Else
                  r = Palabra
               End If
            End If
            dr.Close()
         End With
      End If
      '
      Return r
      '
   End Function

   Function MsgConfirma(ByVal Mensage As String) As Boolean
      '
      If MsgBox(Mensage, vbQuestion + vbYesNo) = vbYes Then
         Return True
      Else
         Return False
      End If
      '
   End Function
   '
   Public Function DelChar(ByVal Cadena As String, ByVal Car As String, Optional ByVal Reempl As String = "") As String
      '
      Dim r As String
      Dim Remarca As Integer
      '
      Remarca = InStr(Cadena, Car)
      '
      If Remarca = 0 Then
         r = Cadena
      Else
         r = Left(Cadena, Remarca - 1) & Reempl & Right(Cadena, Len(Cadena) - Remarca)
      End If
      '
      Return r
      '
   End Function

   Sub DeshabForm(ByVal Formulario As Form)
      '
      Dim Ctrl As Control
      '
      With Formulario
         For Each Ctrl In .Controls
            'If TypeOf Ctrl Is CrystalReport Then
            '
            'Else
            Ctrl.Enabled = False
            'End If
         Next Ctrl
      End With
      '
   End Sub
   '
   Function CrearTabla(ByVal Cnx As OleDb.OleDbConnection, ByVal Estructura As String, Optional ByRef NomTabla As String = "", Optional ByVal MsgError As Boolean = True, Optional ByVal Reintentar As Boolean = True, Optional ByVal DefaultDB As String = "") As Boolean
      '
      Dim Opt As MsgBoxResult
      '
      Opt = IIf(Reintentar, vbRetry, vbCancel)
      '
      Randomize()
      '
      Try
         If NomTabla = "" Then
            NomTabla = IIf(DefaultDB = "", DBT, DefaultDB) & ".dbo." & "Tmp_" & Uid & "_" & Format(Today, "yyyyMMdd") & Int((999999 * Rnd()) + 1)
         End If
         '
         With Cnx
            'Tr.Connection
            'Tr.Begin()
            Dim cmd As New OleDb.OleDbCommand("CREATE TABLE " & NomTabla & "(" & Estructura & ")", Cnx)
            cmd.ExecuteNonQuery()
            'Tr.Commit()
         End With
         '
         Return True
         '
      Catch ex As System.Exception
         'Tr.Rollback()
         NomTabla = ""
         Dim st As New StackTrace(True)
         RegistrarError(st, Err.Source, , Err.Description, "CrearTabla()")
         Return False
         '
      End Try
      '
   End Function
   '
   Function BuscarCfg_(ByVal Control, ByVal Clave) As Boolean
      '
      If ExisteTabla(cn, "Config") Then
         Dim rsCfg As New OleDb.OleDbCommand
         Dim Valor
         '
         With rsCfg
            .Connection = cn
            .CommandText = "SELECT Valor FROM Config WHERE Clave = '" & Clave & "'"
            Valor = .ExecuteScalar
            If IsDBNull(Valor) Then
               BuscarCfg_ = False
            Else
               If TypeOf Control Is TextBox Then
                  Control.Text = Valor
               ElseIf TypeOf Control Is CheckBox Or _
                      TypeOf Control Is RadioButton Then
                  Control.Value = Valor
               Else
                  Control = Valor
               End If
               BuscarCfg_ = True
            End If
            '.Close()
         End With
      Else
         BuscarCfg_ = False
      End If
      '
   End Function
   '
   Function ExisteTabla(ByVal Cnx As OleDb.OleDbConnection, ByVal Tabla As String) As Boolean
      '
      Dim dt As DataTable = GetTables(Cnx)
      Dim Tb As String
      Dim i As Int16
      '
      With dt
         '
         For i = 0 To .Rows.Count - 1
            Tb = .Rows(i).Item(2).ToString
            If UCase(Tb) = UCase(Tabla) Then
               Return True
            End If
         Next i
         '
      End With
      '
      Return False
      '
   End Function
   '
   Function ExisteColumna(ByVal Tabla As String, ByVal Columna As String) As Boolean
      '
      Dim r As Boolean = False
      '
      Dim Ds As New DataSet
      '
      Try
         Dim da As New OleDb.OleDbDataAdapter("SELECT TOP 1 * FROM " & Tabla, Cn)
         '
         ds.Tables.Add("Tabla")
         da.Fill(Ds.Tables("Tabla"))
         '
         For Each col As DataColumn In Ds.Tables.Item("Tabla").Columns
            If col.ColumnName = Columna Then
               r = True
               Exit For
            End If
         Next
         '
      Catch ex As System.Exception
         Dim st As New StackTrace(True)
         RegistrarError(st, Err.Source)
      End Try
      '  
      Return r
      '
   End Function
   '
   Function Tamaño_Columna(ByVal Tabla As String, ByVal Columna As String) As Integer
      '
      Return Val(Obtener_Esquema_Tabla(Tabla, Columna, "ColumnSize"))
      '
   End Function
   '
   Private Function Obtener_Esquema_Tabla(ByVal Tabla As String, Optional Columna As String = "", Optional Propiedad As String = "") As Object
      '
      Dim r As Object = ""
      Dim Cmd As New OleDb.OleDbCommand()
      '
      Try
         '
         Cmd.Connection = Cn
         Cmd.CommandText = "SELECT * FROM " & "[" & Tabla & "]"
         '
         Using SqlDataReader As OleDb.OleDbDataReader = Cmd.ExecuteReader()
            '
            Dim esquema As DataTable = SqlDataReader.GetSchemaTable()
            Dim arrtemp As New ArrayList
            '
            If Columna = "" Then
               For Each Fila As DataRow In esquema.Rows
                  arrtemp.Add("Columna: " & Fila(0).ToString())
                  arrtemp.Add("-------------------------------")
                  For Each Prop As DataColumn In esquema.Columns
                     arrtemp.Add("    " & Prop.ColumnName & " = " & Fila(Prop).ToString)
                  Next
               Next
               arrtemp.Add("")
               r = arrtemp
            Else
               For Each Fila As DataRow In esquema.Rows
                  If Fila(0).ToString() = Columna Then
                     For Each Col As DataColumn In esquema.Columns
                        If Col.ColumnName = Propiedad Then
                           r = Fila(Col).ToString
                           Exit For
                        End If
                     Next
                     Exit For
                  End If
               Next
            End If
            '
         End Using
         '
      Catch ex As Exception
         MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
      End Try
      '
      Return r
      '
   End Function
   '
   Function CaptNroFact(ByVal EmpresaId As Integer, ByVal Sucursal As Integer, ByVal Letra As String, Optional ByVal Comprob As String = "Factura", Optional ByVal Tr As Object = "") As Long
      Return Val(CapturaDato(Cn, "Sucursales", Comprob & Letra, "EmpresaId = " & EmpresaId & " AND Sucursal = " & Sucursal, , , , Tr) & "") + 1
   End Function
   '
   Function TienePermiso(ByVal Cnx As OleDb.OleDbConnection, ByVal Usuario As String, ByVal Objeto As String, Optional ByVal MostrarMsg As Boolean = False) As Boolean
      '
      Dim r As Boolean = False
      '
      If IsNothing(Cnx) Then
         Return r
      End If
      '
      If LGR Then
         If usrAdmin And frmMenu.mPermisos.Checked Then
            Dim Frm As New frmPermisos
            With Frm
               .Objeto = Objeto
               .Show()
            End With
         Else
            r = True
         End If
      Else
         If Cnx.State = 0 Then
            Cnx.Open()
         End If
         Dim Rs As New OleDb.OleDbCommand("SELECT Usuario, Objeto FROM Permisos WHERE Usuario = '" & Usuario & "' " & " AND Objeto = '" & Objeto & "'", Cnx)
         Dim Dr As OleDb.OleDbDataReader = Rs.ExecuteReader
         '
         If Dr.Read Then
            r = True
         Else
            r = False
            If MostrarMsg Then
               Mensaje("No tiene permisos para esta opción")
            End If
         End If
         Dr.Close()
      End If
      '
      Return r
      '
   End Function
   '
   Function GetConfigUsu(ByVal Frm As Form, ByRef Var As String, Optional ByVal Tr As Object = "") As String
      '
      Dim Rs As New OleDb.OleDbCommand
      Dim Dr As OleDb.OleDbDataReader
      '
      With Rs
         .Connection = cn
         .CommandText = "SELECT * FROM ConfigUsu WHERE CfuUsuario = '" & Uid & "' AND CfuForm = '" & Frm.Name & "' AND CfuControl = '" & Var & "'"
         If Tr.ToString <> "" Then
            .Transaction = Tr
         End If
         Dr = .ExecuteReader
      End With
      '
      With Dr
         If .Read Then
            Var = .Item("CfuValor")
            GetConfigUsu = .Item("CfuValor")
         End If
         Dr.Close()
      End With
      '
      Return Var
      '
   End Function
   '
   Sub GetConfigUsu(ByVal Frm As Form, ByRef Ctrl As TextBox, Optional ByVal Tr As Object = "")
      '
      Dim Rs As New OleDb.OleDbCommand
      Dim Dr As OleDb.OleDbDataReader
      '
      With Rs
         .Connection = Cn
         .CommandText = "SELECT * FROM ConfigUsu WHERE CfuUsuario = '" & Uid & "' AND CfuForm = '" & Frm.Name & "' AND CfuControl = '" & Ctrl.Name & "'"
         If Tr.ToString <> "" Then
            .Transaction = Tr
         End If
         Dr = .ExecuteReader
      End With
      '
      With Dr
         If Dr.Read Then
            Ctrl.Text = .Item("CfuValor")
            'GetConfigUsu = .Item("CfuValor")
         End If
         Dr.Close()
      End With
      '
   End Sub
   '
   Function GetConfigUsu(ByVal Frm As Form, ByRef Chk As CheckBox, Optional ByVal Tr As Object = "") As Boolean
      '
      Dim Rs As New OleDb.OleDbCommand
      Dim Dr As OleDb.OleDbDataReader
      Dim r As Boolean
      '
      With Rs
         .Connection = cn
         .CommandText = "SELECT * FROM ConfigUsu WHERE CfuUsuario = '" & Uid & "' AND CfuForm = '" & Frm.Name & "' AND CfuControl = '" & Chk.Name & "'"
         If Tr.ToString <> "" Then
            .Transaction = Tr
         End If
         Dr = .ExecuteReader
      End With

      With Dr
         If .Read Then
            Chk = .Item("CfuValor")
            r = CBool(.Item("CfuValor"))
         End If
         Dr.Close()
      End With
      '
      Return r
      '
   End Function
   '
   Function AltaAuto(ByVal Tabla As String, ByVal ColCodigo As String, ByVal Codigo As Object, ByVal ColNombre As String, ByVal Nombre As String, ByVal TipoIva As String, ByVal Cuit As String, Optional Domicilio As String = "", Optional CondVenta As Int16 = -1, Optional ByVal MsgAlta As Boolean = False, Optional ByVal Tr As Object = "") As Boolean
      '
      '*** VER ***On Error GoTo mError
      '
      If Nombre = "" Then Exit Function
      '
      Dim Cmd As New OleDb.OleDbCommand
      Dim Car As String = ""
      Dim Coma As String = ""
      Dim Alta As Boolean
      Dim Commit As Boolean = False
      '
      If ColCodigo <> "" Then
         Coma = ", "
         If Not IsNumeric(Codigo) Then
            Car = "'"
         End If
      End If
      '
      Try
         If IsNothing(CapturaDato(Cn, Tabla, IIf(ColCodigo = "", ColNombre, ColCodigo), "Nombre = '" & Nombre & "'")) Then
            '
            If MsgAlta Then
               Alta = MsgConfirma("Da de Alta al Cliente")
            Else
               Alta = True
            End If
            '
            If Alta Then
               '
               If ColCodigo <> "" Then
                  Codigo = CapturaDato(Cn, Tabla, "ISNULL( MAX(" & ColCodigo & "), 0)", "") + 1
               End If
               '
               If Tr.ToString = "" Then
                  Tr = Cn.BeginTransaction
                  Commit = True
               End If
               '
               With Cmd
                  .Connection = Cn
                  .Transaction = Tr
                  .CommandText = "INSERT INTO " & Tabla & "( " & Car & ColCodigo & Car & Coma & "Nombre, Cuit, TipoIva" & _
                                 IIf(Domicilio = "", "", ", Domicilio") & _
                                 IIf(CondVenta = -1, "", ", CondVenta") & ", Usuario, FechaMod) " & _
                                 "VALUES(" & IIf(ColCodigo = "", "", Car & Codigo & Car & Coma) & _
                                         "'" & Nombre & "', " & _
                                         "'" & Cuit & "', " & _
                                         "'" & TipoIva & "', " & _
                                               IIf(Domicilio = "", "", "'" & Domicilio & "', ") & _
                                               IIf(CondVenta = -1, "", CondVenta & ", ") & _
                                         "'" & Uid & "', " & _
                                         "'" & Format(Now, FormatFechaHora) & "')"
                  .ExecuteNonQuery()
                  If Commit Then
                     Tr.Commit()
                  End If

               End With
               '
               Return True
               '
            End If
         End If
         '
      Catch ex As System.Exception
         Dim st As New StackTrace(True)
         RegistrarError(st, "AltaAuto")
         Tr.RollBack()
      End Try
      '
      Return False
      '
   End Function
   '
   Sub GuardarAudit(ByVal Descrip As String, ByVal Detalle As String, ByVal Proceso As String, ByVal SubProceso As String, Optional ByVal Tr As Object = "")
      Dim Rs As New OleDb.OleDbCommand
      If Not SLL Then
         Try
            With Rs
               .Connection = Cn
               If Tr.ToString <> "" Then
                  .Transaction = Tr
               End If
               .CommandText = "INSERT INTO Audit( AuditDescrip, AuditDetalle, AuditFecha, AuditProceso, AuditSubProc, AuditUid, AuditPC) " & _
                              "VALUES('" & Descrip & "', " & _
                                     "'" & Detalle & "', " & _
                                     "'" & Format(Now, FormatFechaHora) & "', " & _
                                     "'" & Proceso & "', " & _
                                     "'" & SubProceso & "', " & _
                                     "'" & Uid & "', " & _
                                     "'" & NombrePC & "')"
               .ExecuteNonQuery()
            End With
         Catch
            Dim st As New StackTrace(True)
            MensageError(st, "modDb.GuardarAudit", Err.Description)
         End Try
      End If
   End Sub
   '
   Function EliminaTmp(ByVal Cnx As OleDb.OleDbConnection, Optional ByVal Tmp As String = "") As Boolean
      '
      Dim Tabla As String
      Dim Cmd As New OleDb.OleDbCommand
      Dim i As Int16
      '
      Cmd.Connection = Cnx
      '
      If Tmp = "" Then
         '
         If DBT <> "" Then
            Cnx.Close()
            If Not ConectarDB(Cnx, PRV, Svr, DBT, TrustedCnx, Uid, Pwd) Then
               If Not ConectarDB(Cnx, PRV, Svr, DBN, TrustedCnx, Uid, Pwd) Then
                  Return False
               End If
            End If
         End If
         '
         Dim dt As DataTable = GetTables(Cnx)
         With dt
            For i = 0 To .Rows.Count - 1
               Tabla = .Rows(i).Item(2).ToString
               If Left(UCase(Tabla), 3) = "TMP" Then
                  If InStr(LCase(Tabla), "tmp_" & LCase(Uid)) > 0 Then
                     If ExisteTabla(Cnx, Tabla) Then
                        Cmd.CommandText = "DROP TABLE " & Tabla
                        Cmd.ExecuteNonQuery()
                     End If
                  End If
               End If
            Next i
         End With
         '
         If DBT <> "" Then
            Cnx.Close()
            ConectarDB(Cnx, PRV, Svr, DBN, TrustedCnx, Uid, Pwd)
         End If
         '
      Else
         If ExisteTabla(Cnx, Tmp) Then
            Cmd.CommandText = "DROP TABLE " & Tmp
            Cmd.ExecuteNonQuery()
         End If
      End If
      '
      Return True
      '
   End Function
   '
   Public Function GetTables(ByVal conn As OleDb.OleDbConnection) As DataTable
      If conn.State = 0 Then
         conn.Open()
      End If
      Dim schemaTable As DataTable = conn.GetOleDbSchemaTable(OleDb.OleDbSchemaGuid.Tables, New Object() {Nothing, Nothing, Nothing, "TABLE"})
      Return schemaTable
   End Function
   '
   Function NumeroEgreso(ByVal EmpresaId As Integer, ByVal Sucursal As Int16, Optional ByVal Tr As Object = "") As Long
      NumeroEgreso = Val(CapturaDato(cn, "Egresos", "MAX(EgrNumero)", "EmpresaId = " & EmpresaId & " AND Sucursal = " & Sucursal, , , , Tr) & "") + 1
   End Function

   Function CaptNroRbo(ByVal EmpresaId As Integer, ByVal Letra As String, Optional ByVal Tr As Object = "") As Long
      CaptNroRbo = Val(CapturaDato(cn, "Sucursales", "Recibo" & Letra, "EmpresaId = " & EmpresaId & " AND Sucursal = " & prmSucursal, , , , Tr) & "") + 1
   End Function
   '
   Sub msjTransOk()
      MsgBox("Transacción exitosa", MsgBoxStyle.Information)
   End Sub
   '
   Function DaDeBaja(ByVal Mensage As String) As Boolean
      If MsgBox("Da de Baja: " & Mensage, vbQuestion + vbYesNo) = vbYes Then
         DaDeBaja = True
      End If
   End Function
   '
   Sub GetDBForm(ByVal Form As Form)
      'Trae Tamaño y Posición del Formulario.
      '
      On Error Resume Next
      '
      Dim desktopSize As Size
      desktopSize = System.Windows.Forms.SystemInformation.PrimaryMonitorSize
      Dim wHeight As Integer = desktopSize.Height
      Dim wWidth As Integer = desktopSize.Width
      '
      Dim Rs As New OleDb.OleDbCommand
      Dim Dr As OleDb.OleDbDataReader
      Dim Ws As Integer
      Dim L As Integer
      Dim T As Integer
      Dim W As Integer
      Dim H As Integer
      '
      With Rs
         .Connection = cn
         .CommandText = "SELECT * FROM ConfigUsu WHERE CfuUsuario = '" & Uid & "' AND CfuForm = '" & Form.Name & "' AND CfuControl = 'Form'"
         Dr = Rs.ExecuteReader
      End With
      With Dr
         If .Read Then
            Ws = !CfuWState
            L = !CfuLeft
            T = !CfuTop
            W = !CfuWidth
            H = !CfuHeight
         End If
         .Close()
      End With
      '
      If T > wHeight Then
         T = 0
      End If
      If L > wWidth Then
         L = 0
      End If
      '
      With Form
         .WindowState = Ws
         If Ws = 0 Then
            .Left = L
            .Top = T
            If .FormBorderStyle = FormBorderStyle.Sizable Then
               If W <> 0 Then
                  .Width = W
               End If
               If H <> 0 Then
                  .Height = H
               End If
            End If
         Else
            If .WindowState = FormWindowState.Minimized Then
               .WindowState = FormWindowState.Normal
            End If
         End If
         '.Font.size = cfpFontSize
      End With
      '
   End Sub
   '
   Sub SetDBForm(ByVal Form As Form)
      '
      '* Guarda Tamaño y Posición del Formulario.
      '
      Dim Rs As New OleDb.OleDbCommand
      '
      Rs.Connection = Cn
      '
      With Form
         If .WindowState <> FormWindowState.Minimized Then
            If IsNothing(CapturaDato(Cn, "ConfigUsu", "CfuForm", "CfuUsuario = '" & Uid & "' AND CfuForm = '" & .Name & "' AND CfuControl = 'Form'")) Then
               Rs.CommandText = "INSERT INTO ConfigUsu( CfuUsuario, CfuForm, CfuControl, CfuColName, CfuWState, CfuLeft, CfuTop, CfuWidth, CfuHeight, CfuFecMod) " & _
                                "VALUES('" & Uid & "', '" & .Name & "', 'Form', '', " & .WindowState & ", " & .Left & ", " & .Top & ", " & .Width & ", " & .Height & ", '" & Format(Now, FormatFechaHora) & "')"
            Else
               Rs.CommandText = "UPDATE ConfigUsu SET " & _
                                " CfuWState = " & .WindowState & ", " & _
                                " CfuLeft = " & .Left & ", " & _
                                " CfuTop = " & .Top & ", " & _
                                " CfuWidth = " & .Width & ", " & _
                                " CfuHeight = " & .Height & ", " & _
                                " CfuFecMod = '" & Format(Now, FormatFechaHora) & "' " & _
                                "WHERE CfuUsuario = '" & Uid & "'" & _
                                "  AND CfuForm = '" & .Name & "'" & _
                                "  AND CfuControl = 'Form'"
            End If
            Rs.ExecuteNonQuery()
         End If
      End With
   End Sub
   '
   Function CaptNomUsuario(ByVal Uid As String, ByVal Cnx As OleDb.OleDbConnection) As String
      'If AutDB Then
      CaptNomUsuario = CapturaDato(Cnx, "Usuarios", "Nombre", "Usuario = '" & Uid & "'")
         usrAdmin = CapturaDato(Cnx, "Usuarios", "Admin", "Usuario = '" & Uid & "'")
      'Else
      '   If UCase(Left(PRV, 3)) = "SQL" Then
      '      If LCase(Uid) = "sa" Then
      '         CaptNomUsuario = "dbo"
      '      Else
      '         CaptNomUsuario = CapturaDato(Cnx, "SysUsers U, Master.." & IIf(PRV = "Sql", "SysXLogins", "SysLogins") & " M", "U.Name ", "M.Sid = U.Sid AND M.Name = '" & Uid & "'")
      '      End If
      '      usrAdmin = (LCase(Uid) = "sa")
      '   Else
      '      CaptNomUsuario = Uid
      '      usrAdmin = CapturaDato(Cnx, "Usuarios", "Admin", "Usuario = '" & Uid & "'")
      '   End If
      'End If
   End Function
   '
   Function CaptGroupName(ByVal UserName) As String
      '
      Dim Rs As New OleDb.OleDbCommand
      'Dim Dr As OleDb.OleDbDataReader
      '
      Dim r As String = ""
      'Dim db_Owner As Boolean
      'Dim db_DataWriter As Boolean
      'Dim db_DataReader As Boolean
      '
      'If AutDB Then
      If LCase(UserName) = "admin" Then
            r = "db_owner"
         End If
      'Else
      '   If UCase(PRV) = "SQL" Then
      '      With Rs
      '         .Connection = cn
      '         .CommandText = "EXEC sp_helpuser '" & UserName & "'"
      '         Dr = .ExecuteReader
      '      End With
      '      With Dr
      '         Do While .Read
      '            If !GroupName = "db_owner" Then
      '               db_Owner = True
      '            ElseIf !GroupName = "db_datawriter" Then
      '               db_DataWriter = True
      '            ElseIf !GroupName = "db_datareader" Then
      '               db_DataReader = True
      '            End If
      '         Loop
      '         .Close()
      '      End With
      '      r = IIf(db_Owner, "db_owner", IIf(db_DataWriter, "db_datawriter", "db_datareader"))
      '   ElseIf UCase(PRV) = "SQL2005" Then
      '      If UserName = "sa" Then
      '         r = "db_owner"
      '      End If
      '   End If
      'End If
      '
      Return r
      '
   End Function
   '
   Sub SetDBGrid(ByVal Frm As Form, ByVal Dtg As DataGridView)
      '
      Dim Rs As New OleDb.OleDbCommand
      Dim fSel As Integer
      'Dim Dr As OleDb.OleDbDataReader
      '
      Rs.Connection = cn
      '
      With Dtg
         If .RowCount > 0 Then
            If .SelectedCells.Count > 0 Then
               fSel = .SelectedCells(.Columns(0).Index).RowIndex
            End If
         End If
         '
         For Each Col As DataGridViewColumn In .Columns
            With Col
               If .Visible Then
                  If IsNothing(CapturaDato(Cn, "ConfigUsu", "CfuControl", "CfuUsuario = '" & Uid & "' AND CfuForm = '" & Frm.Name & "' AND CfuControl = '" & Dtg.Name & "' AND CfuColName = '" & .Name & "'")) Then
                     Rs.CommandText = "INSERT INTO ConfigUsu( CfuUsuario, CfuForm, CfuControl, CfuColName, CfuWidth, CfuHeight, CfuFecMod) " & _
                                      "VALUES('" & Uid & "', '" & Frm.Name & "', '" & Dtg.Name & "', '" & .Name & "', " & .Width & ", 10, '" & Format(Now, FormatFechaHora) & "')"
                  Else
                     Rs.CommandText = "UPDATE ConfigUsu SET " & _
                                      " CfuWidth = " & .Width & ", " & _
                                      " CfuHeight = 10, " & _
                                      " CfuFecMod = '" & Format(Now, FormatFechaHora) & "' " & _
                                      "WHERE CfuUsuario = '" & Uid & "' " & _
                                      "  AND CfuForm = '" & Frm.Name & "' " & _
                                      "  AND CfuControl = '" & Dtg.Name & "' " & _
                                      "  AND CfuColName = '" & .Name & "'"
                  End If
                  Rs.ExecuteNonQuery()
               End If
            End With
         Next
         '
         If fSel >= 0 Then
            If Frm.Name <> "" Then
               If IsNothing(CapturaDato(Cn, "ConfigUsu", "CfuControl", "CfuUsuario = '" & Uid & "' AND CfuForm = '" & Frm.Name & "' AND CfuControl = 'FilaSel'")) Then
                  Rs.CommandText = "INSERT INTO ConfigUsu( CfuUsuario, CfuForm, CfuControl, CfuColName, CfuValor, CfuFecMod) " & _
                                   "VALUES('" & Uid & "', '" & Frm.Name & "', 'FilaSel', '-', '" & fSel & "', '" & Format(Now, FormatFechaHora) & "')"
               Else
                  Rs.CommandText = "UPDATE ConfigUsu SET " & _
                                   " CfuValor = '" & fSel & "', " & _
                                   " CfuFecMod = '" & Format(Now, FormatFechaHora) & "' " & _
                                   "WHERE CfuUsuario = '" & Uid & "' " & _
                                   "  AND CfuForm = '" & Frm.Name & "' " & _
                                   "  AND CfuControl = 'FilaSel'"
               End If
               Rs.ExecuteNonQuery()
            End If
         End If
      End With
      '
   End Sub
   '
   Sub GetDbGrid(ByVal Frm As Form, ByVal Dtg As DataGridView)
      '
      Dim Rs As New OleDb.OleDbCommand
      Dim Dr As OleDb.OleDbDataReader
      Dim fSel As Integer
      Dim rSel As Boolean = False
      '
      Rs.Connection = cn
      '
      Try
         With Dtg
            For Each Col As DataGridViewColumn In .Columns
               With Col
                  If .Visible Then
                     With Rs
                        .CommandText = "SELECT * FROM ConfigUsu WHERE CfuUsuario = '" & Uid & "' AND CfuForm = '" & Frm.Name & "' AND CfuControl = '" & Dtg.Name & "' AND CfuColName = '" & Col.Name & "'"
                        Dr = .ExecuteReader
                     End With
                     If Dr.Read Then
                        .Width = Dr!CfuWidth
                     End If
                     Dr.Close()
                     'Rs.Dispose()
                  End If
               End With
            Next
            '
            fSel = Val(CapturaDato(cn, "ConfigUsu", "CfuValor", "CfuUsuario = '" & Uid & "' AND CfuForm = '" & Frm.Name & "' AND CfuControl = 'FilaSel'") & "")
            '
            If fSel >= 0 Then
               For Each r As DataGridViewRow In .Rows
                  'If .RowCount = 1 Then
                  If r.Index = fSel Then
                     r.Selected = True
                     rSel = True
                  Else
                     r.Selected = False
                  End If
               Next
            End If
            '
            If Not rSel Then
               If .RowCount > 0 Then
                  .Rows(0).Selected = True
               End If
            End If
            '
         End With
      Catch
         Rs.Dispose()
         'Dr.Close()
      End Try
   End Sub
   '
   Sub ArmaCbRubros(ByRef cboRubro As ComboBox, Optional ByVal Primero As String = "", Optional ByVal Medicam As Boolean = False, Optional ByVal RubroPadre As String = "")
      '
      Dim rsRub As New OleDb.OleDbCommand
      Dim cWhere As String
      '
      cWhere = "Inactivo = 0"
      '
      'If Medicam Then
      'cWhere = cWhere & " AND Medicam = " & IIf(Medicam, 1, 0)
      ' End If
      '
      If RubroPadre <> "" Then
         cWhere = cWhere & " AND RubroPadre = '" & RubroPadre & "' "
      End If
      '
      LlenarCboItem(cboRubro, "Rubros", "Rubro", , , Primero, cWhere)
      '
   End Sub
   '
   Function NumeroRemito(ByVal EmpresaId As Integer, ByVal Sucursal As Integer) As Long
      '
      Dim r As Long = 0
      Dim Cmd As New OleDb.OleDbCommand
      Dim DR As OleDb.OleDbDataReader
      '
      With Cmd
         .Connection = Cn
         .CommandText = "SELECT Remito FROM Sucursales " & _
                        "WHERE EmpresaId = " & EmpresaId & _
                        "  AND Sucursal = " & Sucursal
         DR = .ExecuteReader
      End With
      '
      With DR
         If .Read Then
            r = !Remito + 1
            Do While ExisteIdentificacion(r, "Remitos", "RtoNumero", "Sucursal = " & Sucursal, Cn)
               r = r + 1
            Loop
            .Close()
         Else
            MensajeTrad("Debe definir Sucursal", vbInformation)
            .Close()
            r = 0
         End If
      End With
      '
      Return r
      '
   End Function
   '
   Function ExisteIdentificacion(ByVal Dato As Object, ByVal Tabla As String, ByVal Campo As String, Optional ByVal Filtro As String = "", Optional ByVal Cnx As Object = "", Optional ByVal esNum As Boolean = False) As Boolean
      '
      Dim strsql As String
      Dim Cmd As New OleDb.OleDbCommand
      Dim DR As OleDb.OleDbDataReader
      '
      If ExisteTabla(cn, Tabla) Then
         If Filtro <> "" Then
            Filtro = " AND " & Filtro
         End If
         '
         If IsNumeric(Dato) And esNum Then
            strsql = "select " & Campo & " from " & Tabla & " where " & Campo & " = " & Dato & Filtro
         Else
            strsql = "select " & Campo & " from " & Tabla & " where " & Campo & " like '" & Dato & "'" & Filtro
         End If
         '
         'If Cnx = "" Then
         Cnx = cn
         'End If
         '
         With Cmd
            .Connection = Cnx
            .CommandText = strsql
            DR = .ExecuteReader
         End With
         '
         With DR
            If .Read Then
               ExisteIdentificacion = True
            Else
               ExisteIdentificacion = False
            End If
         End With

      End If
      '
      'mError:
      '   If Not Err.Number = 0 Then
      '      MsgBox "Ocurrió el siguiente error:" & Err.Description
      '   End If
      '
   End Function
   '
   Sub VerificaDb()
      '
      Dim nCont As Int32 = 0
      Dim Msg As String = ""
      Dim Cmd As New OleDb.OleDbCommand
      '
      With Cmd
         .Connection = Cn
         '
         If Not ExisteTabla(Cn, "ConfigUsu") Then
            .CommandText = "CREATE TABLE [ConfigUsu]( " & _
                           " [CfuUsuario] [varchar](25) NOT NULL, " & _
                           " [CfuForm] [varchar](32) NOT NULL, " & _
                           " [CfuControl] [varchar](32) NOT NULL, " & _
                           " [CfuColName] [varchar](32) NOT NULL, " & _
                           " [CfuWState] [smallint] NOT NULL DEFAULT 0, " & _
                           " [CfuLeft] [smallint] NOT NULL DEFAULT 0, " & _
                           " [CfuTop] [smallint] NOT NULL DEFAULT 0, " & _
                           " [CfuWidth] [smallint] NOT NULL DEFAULT 0, " & _
                           " [CfuHeight] [smallint] NOT NULL DEFAULT 0, " & _
                           " [CfuValor] [varchar](250) NULL, " & _
                           " [CfuFecMod] [smalldatetime] NOT NULL, " & _
                           "CONSTRAINT [PK_ConfigUsu] PRIMARY KEY ([CfuUsuario] ASC, [CfuForm] ASC, [CfuControl] ASC, [CfuColName] Asc))"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If Not ExisteColumna("Traductor", "FechaMod") Then
            .CommandText = "ALTER TABLE [Traductor] ADD [FechaMod] [SmallDateTime] NOT NULL DEFAULT '" & Now & "'"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If Not ExisteColumna("LiqAux", "LqxPC") Then
            .CommandText = "ALTER TABLE [LiqAux] ADD [LqxPC] [VARCHAR](50) NULL"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If Tamaño_Columna("LiqAux", "SonPesos") < 512 Then
            .CommandText = "ALTER TABLE [LiqAux] ALTER COLUMN [SonPesos] [VARCHAR](512) NULL"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If Not ExisteTabla(Cn, "LiqInqCob") Then
            .CommandText = "CREATE TABLE [LiqInqCob]( " & _
                           " [LicId] [int] IDENTITY(1,1) NOT NULL, " & _
                           " [Inquilino] [int] NOT NULL, " & _
                           " [LicFecha] [smalldatetime] NOT NULL, " & _
                           " [LicEfectivo] [float] NULL, " & _
                           " [LicRetencion] [float] NULL, " & _
                           " [LicTransferencia] [float] NULL, " & _
                           " [LiqInqTrId] INT NULL, " & _
                           " [LicCheques] [float] NULL, " & _
                           " [LicSaldo] [FLOAT] NULL DEFAULT 0, " & _
                           " [LicUid] [VARCHAR] (50) NOT NULL, " & _
                           " [LicFecMod] [SMALLDATETIME] NOT NULL, " & _
                           " CONSTRAINT [PK_LiqInqCob] PRIMARY KEY ([LicId]))"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If Not ExisteTabla(Cn, "LiqInqCobDet") Then
            .CommandText = "CREATE TABLE [LiqInqCobDet]( " & _
                           " [LcdId] [int] IDENTITY(1,1) NOT NULL, " & _
                           " [LicId] [int] NOT NULL, " & _
                           " [LiqInqId] [int] NOT NULL, " & _
                           " [LcdImpPago] [float] NULL, " & _
                           " [LcdSaldo] [FLOAT] NULL DEFAULT 0, " & _
                           " [LcdUid] [VARCHAR] (50) NOT NULL, " & _
                           " [LcdFecMod] [SMALLDATETIME] NOT NULL, " & _
                           " CONSTRAINT [PK_LiqInqCobDet] PRIMARY KEY ([LcdId]))"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If Not ExisteTabla(Cn, "LiqInqCobCh") Then
            .CommandText = "CREATE TABLE [LiqInqCobCh]( " & _
                         " [LchId] [int] IDENTITY(1,1) NOT NULL, " & _
                         " [LicId] [int] NOT NULL, " & _
                         " [ChCarteraId] [int] NOT NULL, " & _
                         " [LicUid] [varchar](50) NOT NULL, " & _
                         " [LicFecMod] [smalldatetime] NOT NULL, " & _
                         " CONSTRAINT [PK_LiqInqCobCh] PRIMARY KEY ([LchId]))"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If ExisteColumna("ChCartera", "ChCarteraId") Then
            .CommandText = "EXEC sp_rename 'ChCartera.ChCarteraId', 'ChCartId', 'COLUMN'"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If ExisteColumna("ChCartera", "Cuenta") Then
            .CommandText = "EXEC sp_rename 'ChCartera.Cuenta', 'BancoCta', 'COLUMN'"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If ExisteColumna("ChCartera", "Numero") Then
            .CommandText = "EXEC sp_rename 'ChCartera.Numero', 'ChCartNro', 'COLUMN'"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If Not ExisteColumna("ChCartera", "Comprob") Then
            .CommandText = "ALTER TABLE [ChCartera] ADD [Comprob] [VARCHAR](50) NULL"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If Not ExisteColumna("LiqInqCob", "LiqInqTrId") Then
            .CommandText = "ALTER TABLE [LiqInqCob] ADD [LiqInqTrId] [INT] NULL"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If Not ExisteColumna("LiqInqCob", "Inquilino") Then
            .CommandText = "ALTER TABLE [LiqInqCob] ADD [Inquilino] [INT] NULL"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If Not ExisteColumna("LiqInqCob", "LicSaldo") Then
            .CommandText = "ALTER TABLE [LiqInqCob] ADD [LicSaldo] [FLOAT] NULL DEFAULT 0"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If Not ExisteColumna("LiqInqCobDet", "LcdSaldo") Then
            .CommandText = "ALTER TABLE [LiqInqCobDet] ADD [LcdSaldo] [FLOAT] NULL"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If Not ExisteColumna("Barrios", "BarrioId") Then
            .CommandText = "ALTER TABLE [Barrios] ADD [BarrioId] [INT] IDENTITY(1,1) NOT NULL"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If Not ExisteColumna("Barrios", "BarrioUId") Then
            .CommandText = "ALTER TABLE [Barrios] ADD [BarrioUId] [VARCHAR] (50) NULL"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If Not ExisteColumna("Propietarios", "AlicGan") Then
            .CommandText = "ALTER TABLE [Propietarios] ADD [AlicGan] [REAL] NULL"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If Not ExisteColumna("Propietarios", "LocalidadId") Then
            .CommandText = "ALTER TABLE [Propietarios] ADD [LocalidadId] [INT] NULL"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If Tamaño_Columna("Propietarios", "Localidad") < 64 Then
            .CommandText = "ALTER TABLE [Propietarios] ALTER COLUMN [Localidad] [VARCHAR] (64) NULL"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If Tamaño_Columna("Propietarios", "LocEmp") < 64 Then
            .CommandText = "ALTER TABLE [Propietarios] ALTER COLUMN [LocEmp] [VARCHAR] (64) NULL"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If Not ExisteColumna("Localidad", "LocalidadId") Then
            .CommandText = "ALTER TABLE Localidad DROP CONSTRAINT PK_Localidad"
            .ExecuteNonQuery()
            nCont = nCont + 1
            .CommandText = "ALTER TABLE [Localidad] ADD [LocalidadId] [INT] IDENTITY (1, 1) "
            .ExecuteNonQuery()
            nCont = nCont + 1
            .CommandText = "ALTER TABLE [Localidad] ADD CONSTRAINT [PK_Localidad] PRIMARY KEY ([LocalidadId])"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If Not ExisteColumna("Proveedores", "Cod_Postal") Then
            .CommandText = "ALTER TABLE [Proveedores] ADD [Cod_Postal] [VarChar] (10) NULL"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If Not ExisteColumna("Garantias", "GaranteId") Then
            .CommandText = "ALTER TABLE [Garantias] ADD [GaranteId] [INT] IDENTITY (1, 1) "
            .ExecuteNonQuery()
            nCont = nCont + 1
            .CommandText = "ALTER TABLE [Garantias] ADD CONSTRAINT [PK_Garantias] PRIMARY KEY ([GaranteId])"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If Not ExisteColumna("Garantias", "Usuario") Then
            .CommandText = "ALTER TABLE [Garantias] ADD [Usuario] [VARCHAR] (50) NOT NULL DEFAULT ('sa')"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If Not ExisteColumna("Garantias", "LocalidadId") Then
            .CommandText = "ALTER TABLE [Garantias] ADD [LocalidadId] [INT] NULL"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If Not ExisteColumna("Garantias", "DNI") Then
            .CommandText = "sp_RENAME 'Garantias.Codigo', 'DNI', 'COLUMN'"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If Not ExisteColumna("Contratos", "GaranteId") Then
            .CommandText = "ALTER TABLE [Contratos] ADD [GaranteId] [INT] NULL "
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If Not ExisteColumna("CobOtrTmp", "Renglon") Then
            With Cmd
               .CommandText = "ALTER TABLE [CobOtrTmp] ADD [Renglon] [SMALLINT] NULL "
               .ExecuteNonQuery()
               nCont = nCont + 1
            End With
         End If
         '
         If Not ExisteColumna("Inquilinos", "InqEMail") Then
            With Cmd
               .CommandText = "ALTER TABLE [Inquilinos] ADD [InqEMail] [VARCHAR] (250) NULL "
               .ExecuteNonQuery()
               nCont = nCont + 1
            End With
         End If
         '
         If Not ExisteTabla(Cn, "CobrosOtrCh") Then
            .CommandText = "CREATE TABLE [dbo].[CobrosOtrCh]( " & _
                           " [CobOtrChId] [int] IDENTITY(1,1) NOT NULL, " & _
                           " [CobroOtrId] [int] NOT NULL, " & _
                           " [Origen] [varchar](1) NULL, " & _
                           " [Banco] [smallint] NOT NULL, " & _
                           " [CuentaBco] [varchar](50) NOT NULL, " & _
                           " [Numero] [varchar](50) NOT NULL, " & _
                           " [CrdUsuario] [varchar](50) NOT NULL, " & _
                           " [CrdFecMod] [smalldatetime] NOT NULL, " & _
                           "CONSTRAINT [PK_CobrosOtrCh] PRIMARY KEY ([CobOtrChId]))"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If Not ExisteTabla(Cn, "PropietAg") Then
            .CommandText = "CREATE TABLE [dbo].[PropietAg]( " & _
                           " [PropietAgId] [int] IDENTITY(1,1) NOT NULL, " & _
                           " [PagDescrip] [varchar] (50) NOT NULL, " & _
                           " [PagUsuario] [varchar](50) NOT NULL, " & _
                           " [PagFecMod] [smalldatetime] NOT NULL, " & _
                           "CONSTRAINT [PK_PropietAg] PRIMARY KEY ([PropietAgId]))"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If Not ExisteTabla(Cn, "PropietAgDet") Then
            .CommandText = "CREATE TABLE [dbo].[PropietAgDet]( " & _
                           " [PropietAgId] [int] NOT NULL, " & _
                           " [Propietario] [INT] NOT NULL, " & _
                           " [PadUsuario] [varchar](50) NOT NULL, " & _
                           " [PadFecMod] [smalldatetime] NOT NULL, " & _
                           "CONSTRAINT [PK_PropietAgDet] PRIMARY KEY ([PropietAgId], [Propietario]))"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If ExisteTabla(Cn, "MovBancos") Then
            .CommandText = "EXEC sp_rename 'MovBancos', 'BancosMov'"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If ExisteColumna("BancosMov", "MovBancoId") Then
            .CommandText = "EXEC sp_rename 'BancosMov.MovBancoId', 'BancoMovId', 'COLUMN'"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If ExisteColumna("BancosMov", "Cuenta") Then
            .CommandText = "EXEC sp_rename 'BancosMov.Cuenta', 'BancoCta', 'COLUMN'"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If ExisteColumna("BancosMov", "Tipo") Then
            .CommandText = "EXEC sp_rename 'BancosMov.Tipo', 'TipoMovBco', 'COLUMN'"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If ExisteColumna("BancosMov", "Numero") Then
            .CommandText = "EXEC sp_rename 'BancosMov.Numero', 'NroMovBco', 'COLUMN'"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If ExisteColumna("BancosMov", "ChCarteraId") Then
            With Cmd
               .CommandText = "EXEC sp_rename 'BancosMov.ChCarteraId', 'ChCartId', 'COLUMN'"
               .ExecuteNonQuery()
               nCont = nCont + 1
            End With
         End If
         '
         If Not ExisteColumna("BancosMov", "ChCartId") Then
            With Cmd
               .CommandText = "ALTER TABLE BancosMov ADD ChCartId INT NULL"
               .ExecuteNonQuery()
               nCont = nCont + 1
            End With
         End If
         '
         If ExisteTabla(Cn, "BancoCta") Then
            .CommandText = "EXEC sp_rename 'BancoCta', 'BancosCtas'"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If

         If ExisteColumna("BancosCtas", "Cuenta") Then
            .CommandText = "EXEC sp_rename 'BancosCtas.Cuenta', 'BancoCta', 'COLUMN'"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If ExisteColumna("TipoMovBco", "Tipo") Then
            .CommandText = "EXEC sp_rename 'TipoMovBco.Tipo', 'TipoMovBco', 'COLUMN'"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If Not ExisteColumna("CobrosOtr", "CooTransf") Then
            With Cmd
               .CommandText = "ALTER TABLE CobrosOtr ADD CooTransf [FLOAT] NULL"
               .ExecuteNonQuery()
               nCont = nCont + 1
            End With
         End If
         '
         If Not ExisteColumna("Cobros", "CobTransf") Then
            With Cmd
               .CommandText = "ALTER TABLE Cobros ADD CobTransf [FLOAT] NULL"
               .ExecuteNonQuery()
               nCont = nCont + 1
            End With
         End If
         '
         If Not ExisteTabla(Cn, "CobrosOtrTr") Then
            .CommandText = "CREATE TABLE CobrosOtrTr( " & _
                           " [CobroOtrTrID] [int] IDENTITY(1,1) NOT NULL, " & _
                           " [CobroOtrID] [int] NOT NULL, " & _
                           " [Banco0] [int] NOT NULL, " & _
                           " [Cuenta0] [varchar](25) NOT NULL, " & _
                           " [Titular0] [varchar](50) NOT NULL, " & _
                           " [Banco1] [int] NOT NULL, " & _
                           " [Cuenta1] [varchar](25) NOT NULL, " & _
                           " [FechaTR] [smalldatetime] NOT NULL, " & _
                           " [NumeroTR] [varchar](25) NOT NULL, " & _
                           " [ImporteTR] [float] NOT NULL, " & _
                           " [Usuario] [varchar](25) NOT NULL, " & _
                           " [FechaMod] [smalldatetime] NOT NULL, " & _
                           "CONSTRAINT [PK_CobrosOtrTR] PRIMARY KEY ([CobroOtrTrID]))"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If Not ExisteColumna("TipoProp", "TipoPropId") Then
            .CommandText = "ALTER TABLE TipoProp ADD TipoPropId [INT] IDENTITY(1,1) NOT NULL"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If ExisteColumna("ChPropios", "Numero") Then
            .CommandText = "EXEC sp_rename 'ChPropios.Numero', 'ChPropNro', 'COLUMN'"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         'If Tamaño_Columna("ChPropios", "ChPropNro") < 25 Then
         '   .CommandText = "ALTER TABLE [ChPropios] ALTER COLUMN [ChPropNro] [VARCHAR] (25) NULL"
         '   .ExecuteNonQuery()
         '   nCont = nCont + 1
         'End If
         '
         If ExisteColumna("ChPropios", "Cuenta") Then
            .CommandText = "EXEC sp_rename 'ChPropios.Cuenta', 'BancoCta', 'COLUMN'"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If ExisteColumna("ChPropios", "Tipo") Then
            .CommandText = "EXEC sp_rename 'ChPropios.Tipo', 'TipoMovBco', 'COLUMN'"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If ExisteColumna("Bancos", "Codigo") Then
            .CommandText = "EXEC sp_rename 'Bancos.Codigo', 'Banco', 'COLUMN'"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If Tamaño_Columna("PropiedConc", "Detalle") < 250 Then
            .CommandText = "ALTER TABLE [PropiedConc] ALTER COLUMN [Detalle] [VARCHAR] (250) NULL"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If Tamaño_Columna("Config", "Valor") < 250 Then
            .CommandText = "ALTER TABLE [Config] ALTER COLUMN [Valor] [VARCHAR] (250) NULL"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If ExisteColumna("TipoIva", "TipoIvaId") Then
            .CommandText = "EXEC sp_rename 'TipoIva.TipoIvaId', 'TipoIva', 'COLUMN'"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If Not ExisteColumna("TipoIva", "TipoIva") Then
            .CommandText = "ALTER TABLE TipoIva ADD TipoIva [INT] IDENTITY(1,1) NOT NULL"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If ExisteColumna("TipoComp", "TipoCompId") Then
            .CommandText = "EXEC sp_rename 'TipoComp.TipoCompId', 'TipoComp', 'COLUMN'"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If Not ExisteColumna("TipoComp", "TipoComp") Then
            .CommandText = "ALTER TABLE TipoComp ADD TipoComp [INT] IDENTITY(1,1) NOT NULL"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If Not ExisteColumna("Proveedores", "Dias") Then
            .CommandText = "ALTER TABLE Proveedores ADD Dias [SMALLINT] NULL"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If Not ExisteColumna("Proveedores", "AlicIva") Then
            .CommandText = "ALTER TABLE Proveedores ADD AlicIva [VARCHAR] (3) NOT NULL DEFAULT 'GEN'"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If Not ExisteColumna("Compras", "RetIva") Then
            .CommandText = "ALTER TABLE Compras ADD RetIva FLOAT NULL"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If Not ExisteColumna("Compras", "RetIB") Then
            .CommandText = "ALTER TABLE Compras ADD RetIB FLOAT NULL"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If Not ExisteColumna("Compras", "RetGan") Then
            .CommandText = "ALTER TABLE Compras ADD RetGan FLOAT NULL"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If Not ExisteTabla(Cn, "CtaCtePro") Then
            .CommandText = "CREATE TABLE CtaCtePro ( " & _
                           " [CtaCteProId] [INT] IDENTITY(1,1) NOT NULL, " & _
                           " [Sucursal] [smallint] NOT NULL, " & _
                           " [Departamento] [smallint] NOT NULL, " & _
                           " [Proveedor] [int] NOT NULL, " & _
                           " [TipoComp] [tinyint] NOT NULL, " & _
                           " [ProSucursal] [smallint] NOT NULL, " & _
                           " [ProNumero] [int] NOT NULL, " & _
                           " [Letra] [varchar](1) NULL, " & _
                           " [Fecha] [smalldatetime] NULL, " & _
                           " [Debe] [float] NULL, " & _
                           " [Haber] [float] NULL, " & _
                           " [FechaVenc] [smalldatetime] NULL, " & _
                           " [Detalle] [varchar](50) NULL, " & _
                           " [Pagado] [bit] NOT NULL, " & _
                           " [CompraID] [int] NULL, " & _
                           " [PagoID] [int] NULL, " & _
                           " [Usuario] [varchar](25) NOT NULL, " & _
                           " [FechaMod] [smalldatetime] NOT NULL, " & _
                           " [Saldo] [float] NOT NULL, " & _
                           " [EmpresaId] [smallint] NULL, " & _
                           "CONSTRAINT [PK_CtaCtePro] PRIMARY KEY ([Proveedor], [TipoComp], [ProSucursal], [ProNumero] ))"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If Not ExisteColumna("Conceptos", "ConceptoId") Then
            .CommandText = "ALTER TABLE Conceptos ADD ConceptoId [INT] IDENTITY(1, 1) NOT NULL"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         '
         If ExisteTabla(Cn, "CompraDet") Then
            .CommandText = "EXEC sp_rename 'CompraDet', 'ComprasDet'"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If Not ExisteColumna("ComprasDet", "CompraId") Then
            .CommandText = "ALTER TABLE ComprasDet ADD CompraId [INT] NOT NULL DEFAULT 0"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If Not ExisteColumna("Contratos", "CtoFecFin") Then
            .CommandText = "ALTER TABLE Contratos ADD CtoFecFin [SMALLDATETIME] NULL"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If Not ExisteColumna("Proveedores", "Proveedor") Then
            .CommandText = "ALTER TABLE Proveedores ADD Proveedor [INT] IDENTITY(1, 1) NOT NULL"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If Not ExisteColumna("Proveedores", "Inactivo") Then
            .CommandText = "ALTER TABLE Proveedores ADD Inactivo [BIT] NOT NULL DEFAULT 0"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If Not ExisteColumna("Proveedores", "EmpresaId") Then
            .CommandText = "ALTER TABLE Proveedores ADD EmpresaId [SMALLINT] NULL"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If Not ExisteTabla(Cn, "Estados") Then
            .CommandText = "CREATE TABLE Estados( " & _
                           " [Estado] [tinyint] NOT NULL, " & _
                           " [Descrip] [varchar](50) NOT NULL, " & _
                           " [Compras] [bit] NOT NULL, " & _
                           " [Ventas] [bit] NOT NULL, " & _
                           " [Bancos] [bit] NOT NULL, " & _
                           " [Pagos] [bit] NOT NULL, " & _
                           " [Egresos] [bit] NOT NULL, " & _
                           " [Cheques] [bit] NOT NULL, " & _
                           " [Usuario] [varchar](25) NOT NULL, " & _
                           " [FechaMod] [smalldatetime] NOT NULL, " & _
                           " [Pedidos] [bit] NOT NULL, " & _
                           " [Remitos] [bit] NULL, " & _
                           " [DescAlt] [varchar](50) NULL, " & _
                           "CONSTRAINT [PK_Estados] PRIMARY KEY ([Estado]))"
            .ExecuteNonQuery()
            '
            .CommandText = "INSERT INTO Estados( Estado, Descrip, DescAlt, Compras, Ventas, Bancos, Pagos, Egresos, Cheques, Pedidos, Remitos, Usuario, FechaMod) " & _
                           "VALUES( 0, 'Generado', 'En Cartera1', 1, 1, 0, 1, 1, 1, 1, 1, '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
            .ExecuteNonQuery()
            '
            .CommandText = "INSERT INTO Estados( Estado, Descrip, DescAlt, Compras, Ventas, Bancos, Pagos, Egresos, Cheques, Pedidos, Remitos, Usuario, FechaMod) " & _
                            "VALUES( 1, 'Emitido', 'Depositado', 0, 0, 1, 0, 0, 1, 0, 0, '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
            .ExecuteNonQuery()
            '
            .CommandText = "INSERT INTO Estados( Estado, Descrip, DescAlt, Compras, Ventas, Bancos, Pagos, Egresos, Cheques, Pedidos, Remitos, Usuario, FechaMod) " & _
                           "VALUES( 2, 'Confirmado', NULL, 0, 0, 0, 1, 0, 0, 0, 1, '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
            .ExecuteNonQuery()
            '
            .CommandText = "INSERT INTO Estados( Estado, Descrip, DescAlt, Compras, Ventas, Bancos, Pagos, Egresos, Cheques, Pedidos, Remitos, Usuario, FechaMod) " & _
                           "VALUES( 3, 'Pagado', NULL, 1, 1, 0, 0, 0, 0, 0, 0, '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
            .ExecuteNonQuery()
            '
            .CommandText = "INSERT INTO Estados( Estado, Descrip, DescAlt, Compras, Ventas, Bancos, Pagos, Egresos, Cheques, Pedidos, Remitos, Usuario, FechaMod) " & _
                           "VALUES( 4, 'Anulado', 'Rechazado', 1, 1, 1, 1, 1, 1, 0, 1, '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
            .ExecuteNonQuery()
            '
            .CommandText = "INSERT INTO Estados( Estado, Descrip, DescAlt, Compras, Ventas, Bancos, Pagos, Egresos, Cheques, Pedidos, Remitos, Usuario, FechaMod) " & _
                           "VALUES( 5, 'Conciliado', 'Conciliado', 0, 0, 1, 0, 0, 1, 0, 0, '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
            .ExecuteNonQuery()
            '
            .CommandText = "INSERT INTO Estados( Estado, Descrip, DescAlt, Compras, Ventas, Bancos, Pagos, Egresos, Cheques, Pedidos, Remitos, Usuario, FechaMod) " & _
                           "VALUES( 6, 'Entregado', 'Entregado', 0, 0, 0, 0, 0, 1, 0, 0, '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
            .ExecuteNonQuery()
            '
            .CommandText = "INSERT INTO Estados( Estado, Descrip, DescAlt, Compras, Ventas, Bancos, Pagos, Egresos, Cheques, Pedidos, Remitos, Usuario, FechaMod) " & _
                           "VALUES( 7, 'Facturado', NULL, 0, 0, 0, 0, 0, 0, 0, 1, '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
            .ExecuteNonQuery()
            '
            .CommandText = "INSERT INTO Estados( Estado, Descrip, DescAlt, Compras, Ventas, Bancos, Pagos, Egresos, Cheques, Pedidos, Remitos, Usuario, FechaMod) " & _
               "VALUES( 8, 'Cerrado', NULL, 0, 0, 0, 0, 0, 0, 0, 0, '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
            .ExecuteNonQuery()
            '
            .CommandText = "INSERT INTO Estados( Estado, Descrip, DescAlt, Compras, Ventas, Bancos, Pagos, Egresos, Cheques, Pedidos, Remitos, Usuario, FechaMod) " & _
               "VALUES( 9, 'Enviado', NULL, 0, 0, 0, 0, 0, 0, 1, 0, '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
            .ExecuteNonQuery()
            '
            .CommandText = "INSERT INTO Estados( Estado, Descrip, DescAlt, Compras, Ventas, Bancos, Pagos, Egresos, Cheques, Pedidos, Remitos, Usuario, FechaMod) " & _
               "VALUES( 10, 'Recibido', NULL, 0, 0, 0, 0, 0, 0, 1, 0, '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
            .ExecuteNonQuery()
            '
            nCont = nCont + 1
         End If
         '
         If Not ExisteTabla(Cn, "Empresas") Then
            .CommandText = "CREATE TABLE Empresas( " & _
                           " [EmpresaID] [int] NOT NULL, " & _
                           " [EmpNombre] [varchar](50) NOT NULL, " & _
                           " [EmpRazonSocial] [varchar](250) NOT NULL, " & _
                           " [EmpDomicilio] [varchar](250) NULL, " & _
                           " [Localidad] [int] NOT NULL, " & _
                           " [EmpCPostal] [varchar](15) NULL, " & _
                           " [EmpTelefonos] [varchar](250) NULL, " & _
                           " [EmpEMail] [varchar](250) NULL, " & _
                           " [TipoIva] [smallint] NOT NULL, " & _
                           " [EmpCuit] [varchar](15) NULL, " & _
                           " [EmpUsuario] [varchar](50) NOT NULL, " & _
                           " [EmpFechaMod] [smalldatetime] NOT NULL, " & _
                           " [EmpGas] [bit] NOT NULL, " & _
                           "CONSTRAINT [PK_Empresas] PRIMARY KEY ([EmpresaID]))"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If Not ExisteTabla(Cn, "PedidosProv") Then
            .CommandText = "CREATE TABLE PedidosProv( " & _
                           " [PedidoPrID] [int] IDENTITY(1,1) NOT NULL, " & _
                           " [Sucursal] [smallint] NOT NULL, " & _
                           " [Departamento] [smallint] NOT NULL, " & _
                           " [PedidoPrNro] [varchar](25) NOT NULL, " & _
                           " [Proveedor] [int] NOT NULL, " & _
                           " [Fecha] [smalldatetime] NOT NULL, " & _
                           " [FechaEnv] [smalldatetime] NULL, " & _
                           " [Estado] [tinyint] NOT NULL, " & _
                           " [Observ] [varchar](250) NULL, " & _
                           " [PedidoID] [int] NULL, " & _
                           " [Total] [float] NOT NULL, " & _
                           " [Saldo] [float] NOT NULL, " & _
                           " [Usuario] [varchar](20) NOT NULL, " & _
                           " [FechaMod] [smalldatetime] NOT NULL, " & _
                           " [FechaRec] [smalldatetime] NULL, " & _
                           " [EmpresaId] [smallint] NOT NULL, " & _
                           "CONSTRAINT [PK_PedidosProv] PRIMARY KEY ([PedidoPrID]))"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If ExisteColumna("Compras", "Tipo") Then
            .CommandText = "EXEC sp_rename 'Compras.Tipo', 'CompLetra', 'COLUMN'"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If Not ExisteColumna("Compras", "CompSucursal") Then
            .CommandText = "EXEC sp_rename 'Compras.Sucursal', 'CompSucursal', 'COLUMN'"
            .ExecuteNonQuery()
            nCont = nCont + 1
            '
            .CommandText = "ALTER TABLE Compras ADD Sucursal [INT] NOT NULL DEFAULT 0"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If ExisteColumna("Compras", "Numero") Then
            .CommandText = "EXEC sp_rename 'Compras.Numero', 'CompNumero', 'COLUMN'"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If Not ExisteColumna("Compras", "CondVenta") Then
            .CommandText = "ALTER TABLE Compras ADD CondVenta [TINYINT] NOT NULL DEFAULT 1"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If Not ExisteColumna("Compras", "IngresoID") Then
            .CommandText = "ALTER TABLE Compras ADD IngresoID [INT] NULL"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If Not ExisteColumna("Compras", "Estado") Then
            .CommandText = "ALTER TABLE Compras ADD Estado [TINYINT] NOT NULL DEFAULT 0"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If Not ExisteColumna("Compras", "CompServ") Then
            .CommandText = "ALTER TABLE Compras ADD CompServ [BIT] NOT NULL DEFAULT 1"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If Not ExisteColumna("TipoComp", "DescAbrev") Then
            .CommandText = "ALTER TABLE TipoComp ADD DescAbrev [VARCHAR] (3) NULL"
            .ExecuteNonQuery()
            nCont = nCont + 1
            '
            .CommandText = "UPDATE TipoComp SET DescAbrev = Codigo"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If Not ExisteColumna("Compras", "TipoComp") Then
            .CommandText = "ALTER TABLE Compras ADD TipoComp [INT] NOT NULL DEFAULT 1"
            .ExecuteNonQuery()
            nCont = nCont + 1
            '
            .CommandText = "UPDATE Compras SET TipoComp = (SELECT TipoComp FROM TipoComp WHERE Codigo = Compras.Comprob)"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If Not ExisteColumna("Compras", "PedidoPrId") Then
            .CommandText = "ALTER TABLE Compras ADD PedidoPrId [INT] NULL"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If Not ExisteTabla(Cn, "Ingresos") Then
            .CommandText = "CREATE TABLE [dbo].[Ingresos]( " & _
                           " [IngresoID] [int] IDENTITY(1,1) NOT NULL, " & _
                           " [Sucursal] [smallint] NOT NULL, " & _
                           " [Departamento] [smallint] NOT NULL, " & _
                           " [Proveedor] [int] NOT NULL, " & _
                           " [RtoSucursal] [smallint] NOT NULL, " & _
                           " [RtoNumero] [int] NOT NULL, " & _
                           " [FechaIng] [smalldatetime] NOT NULL, " & _
                           " [FechaRto] [smalldatetime] NOT NULL, " & _
                           " [Detalle] [varchar](250) NULL, " & _
                           " [Estado] [tinyint] NOT NULL, " & _
                           " [RecTecnica] [int] NOT NULL, " & _
                           " [OrdCompra] [int] NOT NULL, " & _
                           " [Destino] [nvarchar](50) NULL, " & _
                           " [SubTotal] [float] NOT NULL, " & _
                           " [Bonificacion] [real] NOT NULL, " & _
                           " [Total] [float] NOT NULL, " & _
                           " [Auto] [bit] NOT NULL, " & _
                           " [Usuario] [varchar](25) NOT NULL, " & _
                           " [FechaMod] [smalldatetime] NOT NULL, " & _
                           " [EmpresaId] [smallint] NOT NULL, " & _
                           " CONSTRAINT [PK_Ingresos] PRIMARY KEY ([IngresoID]))"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If Not ExisteTabla(Cn, "IngresosDet") Then
            .CommandText = "CREATE TABLE [dbo].[IngresosDet]( " & _
                           " [IngresoID] [int] NOT NULL, " & _
                           " [RtoRenglon] [smallint] NOT NULL, " & _
                           " [Producto] [int] NOT NULL, " & _
                           " [Concepto] [smallint] NOT NULL, " & _
                           " [Detalle] [varchar](50) NULL, " & _
                           " [Partida] [varchar](20) NOT NULL, " & _
                           " [Cantidad] [float] NOT NULL, " & _
                           " [Saldo] [float] NOT NULL, " & _
                           " [Costo] [float] NOT NULL, " & _
                           " [Descuento] [real] NOT NULL, " & _
                           " [FechaVenc] [smalldatetime] NULL, " & _
                           " [RenglonOC] [smallint] NOT NULL, " & _
                           " [Usuario] [varchar](25) NOT NULL, " & _
                           " [FechaMod] [smalldatetime] NOT NULL, " & _
                           " [Bonificacion] [varchar](25) NULL, " & _
                           " [SubTotal] [varchar](25) NULL, " & _
                           " [ImpInt] [float] NULL, " & _
                           " [AlicuoIva] [real] NULL, " & _
                           "CONSTRAINT [PK_IngresosDet] PRIMARY KEY ([IngresoID], [RtoRenglon]))"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If Not ExisteColumna("AlicIva", "AlicIva") Then
            .CommandText = "ALTER TABLE AlicIva ADD AlicIva VARCHAR(10) NOT NULL DEFAULT ''"
            .ExecuteNonQuery()
            nCont = nCont + 1
            '
            .CommandText = "UPDATE AlicIva SET AlicIva = Codigo"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If Tamaño_Columna("Audit", "AuditDescrip") < 512 Then
            .CommandText = "ALTER TABLE [Audit] ALTER COLUMN [AuditDescrip] [VARCHAR] (512) NOT NULL"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If Tamaño_Columna("Audit", "AuditDetalle") < 512 Then
            .CommandText = "ALTER TABLE [Audit] ALTER COLUMN [AuditDetalle] [VARCHAR] (512) NOT NULL"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If Tamaño_Columna("ChPropios", "ChPropNro") < 50 Then
            .CommandText = "ALTER TABLE [ChPropios] ALTER COLUMN [ChPropNro] [VARCHAR] (50) NOT NULL"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If Not ExisteTabla(Cn, "AuxReporte") Then
            .CommandText = "CREATE TABLE [dbo].[AuxReporte](" &
                           " [Propietario] [int] NULL, " &
                           " [Propiedad] [int] NULL, " &
                           " [Inquilino] [int] NULL, " &
                           " [Codigo] [varchar](50) NULL, " &
                           " [Concepto] [varchar](10) NULL, " &
                           " [Importe] [float] NULL, " &
                           " [Uid] [varchar](50) NULL, " &
                           " [Host] [varchar](50) NULL)"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If Not ExisteColumna("AuxReporte", "Periodo") Then
            .CommandText = "ALTER TABLE AuxReporte ADD Periodo VARCHAR(10) NULL"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If Not ExisteColumna("AuxReporte", "Saldo") Then
            .CommandText = "ALTER TABLE AuxReporte ADD Saldo FLOAT NULL"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If Not ExisteColumna("AuxReporte", "Numero") Then
            .CommandText = "ALTER TABLE AuxReporte ADD Numero INT NULL"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If Not ExisteTabla(Cn, "EscContrato") Then
            .CommandText = "CREATE TABLE [dbo].[EscContrato]( " &
                           " [Escalon] [Tinyint] NOT NULL, " &
                           " [EscDescrip] [VARCHAR] (50) NOT NULL, " &
                           " [EscSimbolo] [VARCHAR] (10) NOT NULL, " &
                           " [EscUsuario] [varchar](50) NOT NULL, " &
                           " [EscFecMod] [smalldatetime] NOT NULL, " &
                           "CONSTRAINT [PK_EscContrato] PRIMARY KEY ([Escalon]))"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If Not ExisteTabla(Cn, "ContratosAct") Then
            .CommandText = "CREATE TABLE [dbo].[ContratosAct]( " &
                          " [ContratoActId] [Int] IDENTITY(1, 1) Not NULL, " &
                          " [Numero] [Int] Not NULL, " &
                          " [Escalon] [tinyint] NULL, " &
                          " [MesesEsc] [smallint] NULL, " &
                          " [Incremento] [float] NULL, " &
                          " [Usuario] [varchar](20) Not NULL, " &
                          " [FechaMod] [smalldatetime] Not NULL, " &
                          " Constraint [PK_ContratosAct] PRIMARY KEY CLUSTERED (	[Contratoactid] ASC))"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If Not ExisteColumna("LiqInqCob", "LiqPropiet") Then
            .CommandText = "ALTER TABLE LiqInqCob ADD LiqPropiet INT NOT NULL DEFAULT 0"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If Not ExisteTabla(Cn, "LiqPropietDet") Then
            .CommandText = "CREATE TABLE [dbo].[LiqPropietDet](" &
                           " [Numero] [Int] Not NULL," &
                           " [Renglon] [smallint] Not NULL," &
                           " [Concepto] [varchar](5) Not NULL," &
                           " [Fecha] [smalldatetime] Not NULL," &
                           " [Detalle] [varchar](250) NULL," &
                           " [Importe] [float] Not NULL," &
                           " [Debe] [float] Not NULL," &
                           " [Haber] [float] Not NULL," &
                           " [Saldo] [float] Not NULL," &
                           " [Comprob] [varchar](50) NULL," &
                           " [Origen] [smallint] Not NULL," &
                           " [Usuario] [varchar](20) Not NULL," &
                           " [FechaMod] [smalldatetime] NULL," &
                           " Constraint [PK_LiqPropietDet] PRIMARY KEY ([Numero] Asc, [Renglon] ASC))"
            .ExecuteNonQuery()
            nCont = nCont + 1
            '
            .CommandText = "ALTER TABLE [dbo].[LiqPropietDet] ADD CONSTRAINT [FK_LiqPropietDet_LiqPropiet] FOREIGN KEY([Numero]) REFERENCES [dbo].[LiqPropiet]([Numero])"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If Not ExisteColumna("LiqPropTmp", "Importe") Then
            .CommandText = "ALTER TABLE LiqPropTmp ADD Importe FLOAT NULL"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         'If Not ExisteColumna("LiqPropTmp", "Saldo") Then
         '   .CommandText = "ALTER TABLE LiqPropTmp ADD Saldo FLOAT DEFAULT 0"
         '   .ExecuteNonQuery()
         '   nCont = nCont + 1
         'End If
         '
         If Not ExisteColumna("ResALiqProp", "Importe") Then
            .CommandText = "ALTER TABLE ResALiqProp ADD Importe FLOAT NULL"
            .ExecuteNonQuery()
            .CommandText = "ALTER TABLE ResALiqProp ADD Saldo FLOAT NULL"
            .ExecuteNonQuery()
            .CommandText = "ALTER TABLE ResALiqProp ADD Origen TINYINT NULL"
            .ExecuteNonQuery()
            .CommandText = "ALTER TABLE ResALiqProp ADD Proveedor INT NULL"
            .ExecuteNonQuery()
            .CommandText = "ALTER TABLE ResALiqProp ADD Retencion FLOAT NULL"
            .ExecuteNonQuery()
            .CommandText = "ALTER TABLE ResALiqProp ADD LicId INT NULL"
            .ExecuteNonQuery()
            nCont = nCont + 6
         End If
         '
         If Tamaño_Columna("ResALiqProp", "Tipo") < 50 Then
            .CommandText = "ALTER TABLE [ResALiqProp] ALTER COLUMN [Tipo] [VARCHAR] (50) NULL"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If Tamaño_Columna("ResALiqProp", "Nombre") < 250 Then
            .CommandText = "ALTER TABLE [ResALiqProp] ALTER COLUMN [Nombre] [VARCHAR] (250) NULL"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If Not ExisteColumna("LiqInqCobDet", "LiqPropiet") Then
            .CommandText = "ALTER TABLE LiqInqCobDet ADD LiqPropiet INT NOT NULL DEFAULT 0"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If Not ExisteColumna("LiqInqCobDet", "LcdRetencion") Then
            .CommandText = "ALTER TABLE LiqInqCobDet ADD LcdRetencion FLOAT NOT NULL DEFAULT 0"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If Tamaño_Columna("Propiedades", "Domicilio") < 100 Then
            .CommandText = "ALTER TABLE [Propiedades] ALTER COLUMN [Domicilio] [VARCHAR] (100) NOT NULL"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         'If Tamaño_Columna("Traductor", "Control") < 25 Then
         '   .CommandText = "ALTER TABLE [Traductor] ALTER COLUMN [Control] [VARCHAR] (25) NOT NULL"
         '   .ExecuteNonQuery()
         '   nCont = nCont + 1
         'End If
         '
         If Tamaño_Columna("Traductor", "Palabra") < 50 Then
            .CommandText = "ALTER TABLE [Traductor] ALTER COLUMN [Palabra] [VARCHAR] (50) NOT NULL"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If Tamaño_Columna("Traductor", "Descrip") < 128 Then
            .CommandText = "ALTER TABLE [Traductor] ALTER COLUMN [Descrip] [VARCHAR] (128)"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If Tamaño_Columna("Traductor", "ESPAÑOL") < 250 Then
            .CommandText = "ALTER TABLE [Traductor] ALTER COLUMN [ESPAÑOL] [VARCHAR] (250)"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If Tamaño_Columna("Traductor", "ENGLISH") < 250 Then
            .CommandText = "ALTER TABLE [Traductor] ALTER COLUMN [ENGLISH] [VARCHAR] (250)"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If Not ExisteColumna("Propietarios", "ComFija") Then
            .CommandText = "ALTER TABLE [Propietarios] ADD [ComFija] [bit] NOT NULL DEFAULT 0"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If Not ExisteColumna("ContratosAct", "FechaVenc") Then
            .CommandText = "ALTER TABLE ContratosAct ADD [FechaVenc] [SMALLDATETIME]"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If Not ExisteColumna("ContratosAct", "Iva") Then
            .CommandText = "ALTER TABLE ContratosAct ADD [Iva] [Float] NOT NULL DEFAULT 0"
            .ExecuteNonQuery()
            nCont = nCont + 1
         End If
         '
         If Not ExisteColumna("ContratosAct", "Porcent") Then
            .CommandText = "ALTER TABLE ContratosAct ADD [Porcent] [Real] NOT NULL DEFAULT 0"
            .ExecuteNonQuery()
            nCont += 1
         End If
         '
         If Not ExisteColumna("Contratos", "Porcent") Then
            .CommandText = "ALTER TABLE Contratos ADD [Porcent] [Real] NOT NULL DEFAULT 0"
            .ExecuteNonQuery()
            nCont += 1
         End If
         '
         .Dispose()
         '
         If nCont = 0 Then
            Msg = "No se realizaron cambios, todo correcto."
         Else
            If nCont = 1 Then
               Msg = "ó " & nCont & " cambio"
            Else
               Msg = "aron " & nCont & " cambios"
            End If
            Msg = "Se realiz" & Msg & " en la base de datos."
         End If
         '
         Mensaje(Msg)
         '
      End With
      '
   End Sub
   '
   Sub CargaTablasBase()
      '
      Dim Cmd As New OleDb.OleDbCommand
      '
      Try
         With Cmd
            .Connection = Cn
            .CommandText = "SELECT COUNT(1) FROM AlicIva"
            If .ExecuteScalar = 0 Then
               .CommandText = "INSERT INTO AlicIva( [Codigo], [AlicIva], [Descrip], [Alicuo1], [Alicuo2], [Usuario], [FechaMod]) " &
                              "VALUES( 'EXE', 'EXE', 'Alícuota Exenta', 0, 0, '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
               .CommandText = "INSERT INTO AlicIva( [Codigo], [AlicIva], [Descrip], [Alicuo1], [Alicuo2], [Usuario], [FechaMod]) " &
                              "VALUES( 'GEN', 'GEN', 'Alícuota General', 21, 10.5, '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
               .CommandText = "INSERT INTO AlicIva( [Codigo], [AlicIva], [Descrip], [Alicuo1], [Alicuo2], [Usuario], [FechaMod]) " &
                              "VALUES( 'SER', 'SER', 'Alícuota Servicios', 27, 13.5, '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
            End If
            '
            .CommandText = "SELECT COUNT(1) FROM TipoIva"
            If .ExecuteScalar = 0 Then
               .CommandText = "INSERT INTO TipoIva( [Codigo], [Descrip], [EmiteComp], [RecibeComp], [Usuario], [FechaMod]) " & _
                              "VALUES( 'CFI', 'Consumidor Final', '', ' BC', '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
               .CommandText = "INSERT INTO TipoIva( [Codigo], [Descrip], [EmiteComp], [RecibeComp], [Usuario], [FechaMod]) " & _
                              "VALUES( 'EXE', 'Exento', '  C', ' BC', '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
               .CommandText = "INSERT INTO TipoIva( [Codigo], [Descrip], [EmiteComp], [RecibeComp], [Usuario], [FechaMod]) " & _
                              "VALUES( 'MTR', 'Monotributo', '  C', ' BC', '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
               .CommandText = "INSERT INTO TipoIva( [Codigo], [Descrip], [EmiteComp], [RecibeComp], [Usuario], [FechaMod]) " & _
                              "VALUES( 'RIN', 'Responsable Inscripto', 'AB', 'A C', '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
               .CommandText = "INSERT INTO TipoIva( [Codigo], [Descrip], [EmiteComp], [RecibeComp], [Usuario], [FechaMod]) " & _
                              "VALUES( 'RNI', 'Responsable no Inscripto', '  C', 'A C', '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
            End If
            '
            .CommandText = "SELECT COUNT(1) FROM CatGcias"
            If .ExecuteScalar = 0 Then
               .CommandText = "INSERT INTO CatGcias( [Codigo], [Descrip], [Abrev], [Alicuota], [MinimoImp], [RetMinima], [Usuario], [FechaMod]) " & _
                              "VALUES( 0, 'Ninguna', 'NO', 0, 0, 0, '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
               .CommandText = "INSERT INTO CatGcias( [Codigo], [Descrip], [Abrev], [Alicuota], [MinimoImp], [RetMinima], [Usuario], [FechaMod]) " & _
                              "VALUES( 1, 'Inscripto', 'INS', 6, 5000, 20, '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
               .CommandText = "INSERT INTO CatGcias( [Codigo], [Descrip], [Abrev], [Alicuota], [MinimoImp], [RetMinima], [Usuario], [FechaMod]) " & _
                              "VALUES( 2, 'No Inscripto', 'NOI', 28, 5000, 20, '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
            End If
            '
            .CommandText = "SELECT COUNT(1) FROM Cajas"
            If .ExecuteScalar = 0 Then
               .CommandText = "INSERT INTO Cajas( [Caja], [Descrip], [Responsable], [Cuenta], [CtaAdm], [SdoAnt], [SdoAct], [SubTitulo], [UltNroMN], [Usuario], [FechaMod]) " & _
                              "VALUES( 1, 'CAJA ADMINISTRACION', '" & Uid & "', '', '', 0, 0, '', 0, '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
            End If
            '
            .CommandText = "SELECT COUNT(1) FROM Localidad"
            If .ExecuteScalar = 0 Then
               .CommandText = "INSERT INTO Localidad( [Codigo], [Descrip], [Provincia], [Pais], [Usuario], [FechaMod]) " &
                              "VALUES( 8300,	'NEUQUEN', 'NEUQUEN', 54, '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
               .CommandText = "INSERT INTO Localidad( [Codigo], [Descrip], [Provincia], [Pais], [Usuario], [FechaMod]) " &
                              "VALUES( 8309,	'CENTENARIO', 'NEUQUEN', 54, '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
            End If
            '
            .CommandText = "SELECT COUNT(1) FROM Idiomas"
            If .ExecuteScalar = 0 Then
               .CommandText = "INSERT INTO Idiomas( [Idioma], [Descrip]) " & _
                              "VALUES('Es', 'Español')"
               .ExecuteNonQuery()
            End If
            '
            .CommandText = "SELECT COUNT(1) FROM Estados"
            If .ExecuteScalar = 0 Then
               .CommandText = "INSERT INTO Estados( [Estado], [Descrip], [Compras],[Ventas],[Bancos],[Pagos],[Egresos],[Cheques],[Usuario],[FechaMod],[Pedidos],[Remitos],[DescAlt]) " &
                              "VALUES( 0, 'Generado', 1, 1, 0, 1, 1, 1, '" & Uid & "', '" & Format(Now, FormatFechaHora) & "', 1, 1, 'En Cartera')"
               .ExecuteNonQuery()
               .CommandText = "INSERT INTO Estados( [Estado], [Descrip], [Compras],[Ventas],[Bancos],[Pagos],[Egresos],[Cheques],[Usuario],[FechaMod],[Pedidos],[Remitos],[DescAlt]) " &
                              "VALUES( 1, 'Emitido', 0, 0, 1, 0, 0, 1, '" & Uid & "', '" & Format(Now, FormatFechaHora) & "', 0, 0, 'Depositado')"
               .ExecuteNonQuery()
               .CommandText = "INSERT INTO Estados( [Estado], [Descrip], [Compras],[Ventas],[Bancos],[Pagos],[Egresos],[Cheques],[Usuario],[FechaMod],[Pedidos],[Remitos],[DescAlt]) " &
                              "VALUES( 2, 'Confirmado', 0, 0, 0, 1, 0, 0, '" & Uid & "', '" & Format(Now, FormatFechaHora) & "', 0, 1, NULL)"
               .ExecuteNonQuery()
               .CommandText = "INSERT INTO Estados( [Estado], [Descrip], [Compras],[Ventas],[Bancos],[Pagos],[Egresos],[Cheques],[Usuario],[FechaMod],[Pedidos],[Remitos],[DescAlt]) " &
                              "VALUES( 3, 'Pagado', 1, 1, 0, 0, 0, 0, '" & Uid & "', '" & Format(Now, FormatFechaHora) & "', 0, 0, NULL)"
               .ExecuteNonQuery()
               .CommandText = "INSERT INTO Estados( [Estado], [Descrip], [Compras],[Ventas],[Bancos],[Pagos],[Egresos],[Cheques],[Usuario],[FechaMod],[Pedidos],[Remitos],[DescAlt]) " &
                              "VALUES( 4, 'Anulado', 1, 1, 1, 1, 1, 1, '" & Uid & "', '" & Format(Now, FormatFechaHora) & "', 0, 1, 'Rechazado')"
               .ExecuteNonQuery()
               .CommandText = "INSERT INTO Estados( [Estado], [Descrip], [Compras],[Ventas],[Bancos],[Pagos],[Egresos],[Cheques],[Usuario],[FechaMod],[Pedidos],[Remitos],[DescAlt]) " &
                              "VALUES( 5, 'Conciliado', 0, 0, 1, 0, 0, 1, '" & Uid & "', '" & Format(Now, FormatFechaHora) & "', 0, 0, 'Conciliado')"
               .ExecuteNonQuery()
               .CommandText = "INSERT INTO Estados( [Estado], [Descrip], [Compras],[Ventas],[Bancos],[Pagos],[Egresos],[Cheques],[Usuario],[FechaMod],[Pedidos],[Remitos],[DescAlt]) " &
                              "VALUES( 6, 'Entregado', 0, 0, 0, 0, 0, 1, '" & Uid & "', '" & Format(Now, FormatFechaHora) & "', 0, 0, 'Entregado')"
               .ExecuteNonQuery()
               .CommandText = "INSERT INTO Estados( [Estado], [Descrip], [Compras],[Ventas],[Bancos],[Pagos],[Egresos],[Cheques],[Usuario],[FechaMod],[Pedidos],[Remitos],[DescAlt]) " &
                              "VALUES( 7, 'Facturado', 0, 0, 0, 0, 0, 0, '" & Uid & "', '" & Format(Now, FormatFechaHora) & "', 0, 1, NULL)"
               .ExecuteNonQuery()
               .CommandText = "INSERT INTO Estados( [Estado], [Descrip], [Compras],[Ventas],[Bancos],[Pagos],[Egresos],[Cheques],[Usuario],[FechaMod],[Pedidos],[Remitos],[DescAlt]) " &
                              "VALUES( 8, 'Cerrado', 0, 0, 0, 0, 0, 0, '" & Uid & "', '" & Format(Now, FormatFechaHora) & "', 0, 0, NULL)"
               .ExecuteNonQuery()
               .CommandText = "INSERT INTO Estados( [Estado], [Descrip], [Compras],[Ventas],[Bancos],[Pagos],[Egresos],[Cheques],[Usuario],[FechaMod],[Pedidos],[Remitos],[DescAlt]) " &
                              "VALUES( 9, 'Enviado', 0, 0, 0, 0, 0, 0, '" & Uid & "', '" & Format(Now, FormatFechaHora) & "', 1, 0, NULL)"
               .ExecuteNonQuery()
               .CommandText = "INSERT INTO Estados( [Estado], [Descrip], [Compras],[Ventas],[Bancos],[Pagos],[Egresos],[Cheques],[Usuario],[FechaMod],[Pedidos],[Remitos],[DescAlt]) " &
                              "VALUES( 10, 'Recibido', 0, 0, 0, 0, 0, 0, '" & Uid & "', '" & Format(Now, FormatFechaHora) & "', 1, 0, NULL)"
               .ExecuteNonQuery()
            End If
            '
            .CommandText = "SELECT COUNT(1) FROM EstLiquid"
            If .ExecuteScalar = 0 Then
               .CommandText = "INSERT INTO EstLiquid( [Estado], [Descrip], [Usuario], [FechaMod]) " & _
                              "VALUES( 0, 'Generado', '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
               .CommandText = "INSERT INTO EstLiquid( [Estado], [Descrip], [Usuario], [FechaMod]) " & _
                              "VALUES( 1, 'Confirmado', '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
               .CommandText = "INSERT INTO EstLiquid( [Estado], [Descrip], [Usuario], [FechaMod]) " & _
                              "VALUES( 2, 'Anulado', '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
               .CommandText = "INSERT INTO EstLiquid( [Estado], [Descrip], [Usuario], [FechaMod]) " & _
                              "VALUES( 3, 'Pendiente', '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
            End If

            .CommandText = "SELECT COUNT(1) FROM EstContr"
            If .ExecuteScalar = 0 Then
               .CommandText = "INSERT INTO EstContr( [Estado], [Descrip], [Usuario], [FechaMod]) " & _
                              "VALUES( 0, 'Generado', '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
               .CommandText = "INSERT INTO EstContr( [Estado], [Descrip], [Usuario], [FechaMod]) " & _
                              "VALUES( 1, 'Finalizado', '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
               .CommandText = "INSERT INTO EstContr( [Estado], [Descrip], [Usuario], [FechaMod]) " & _
                              "VALUES( 2, 'Anulado', '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
            End If
            '
            .CommandText = "SELECT COUNT(1) FROM EstChCartera"
            If .ExecuteScalar = 0 Then
               .CommandText = "INSERT INTO EstChCartera( [Estado], [Descrip], [Usuario], [FechaMod]) " & _
                              "VALUES( 0, 'En Cartera', '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
               .CommandText = "INSERT INTO EstChCartera( [Estado], [Descrip], [Usuario], [FechaMod]) " & _
                              "VALUES( 2, 'Entregado', '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
               .CommandText = "INSERT INTO EstChCartera( [Estado], [Descrip], [Usuario], [FechaMod]) " & _
                              "VALUES( 4, 'A Cobrar', '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
               .CommandText = "INSERT INTO EstChCartera( [Estado], [Descrip], [Usuario], [FechaMod]) " & _
                              "VALUES( 5, 'Cobrado', '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
            End If
            '
            .CommandText = "SELECT COUNT(1) FROM Conceptos"
            If .ExecuteScalar = 0 Then
               .CommandText = "INSERT INTO Conceptos( [Codigo], [Descrip], [Accion], [Cuenta], [CtaAdm], [Comision], [Prioridad], [ImpDef], [Usuario], [FechaMod]) " &
                              "VALUES('ADL', 'ADELANTO ALQUILER', 'D', '', '', 1, 0, 0, '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
               .CommandText = "INSERT INTO Conceptos( [Codigo], [Descrip], [Accion], [Cuenta], [CtaAdm], [Comision], [Prioridad], [ImpDef], [Usuario], [FechaMod]) " &
                              "VALUES('ALQ', 'ALQUILER', 'D', '', '', 1, 99, 0, '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
               .CommandText = "INSERT INTO Conceptos( [Codigo], [Descrip], [Accion], [Cuenta], [CtaAdm], [Comision], [Prioridad], [ImpDef], [Usuario], [FechaMod]) " &
                              "VALUES('BON', 'BONIFICACION ALQUILER', 'D', '', '', 1, 150, 0, '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
               .CommandText = "INSERT INTO Conceptos( [Codigo], [Descrip], [Accion], [Cuenta], [CtaAdm], [Comision], [Prioridad], [ImpDef], [Usuario], [FechaMod]) " &
                              "VALUES('IVA', 'IVA ALQUILER', 'D', '', '', 0, 98, 0, '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
               .CommandText = "INSERT INTO Conceptos( [Codigo], [Descrip], [Accion], [Cuenta], [CtaAdm], [Comision], [Prioridad], [ImpDef], [Usuario], [FechaMod]) " &
                              "VALUES('COM', 'GESTION POR COBRANZA', 'D', '', '', 0, 0, 0, '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
               .CommandText = "INSERT INTO Conceptos( [Codigo], [Descrip], [Accion], [Cuenta], [CtaAdm], [Comision], [Prioridad], [ImpDef], [Usuario], [FechaMod]) " &
                             "VALUES('SEN', 'SEÑA', 'D', '', '', 0, 0, 0, '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
               .CommandText = "INSERT INTO Conceptos( [Codigo], [Descrip], [Accion], [Cuenta], [CtaAdm], [Comision], [Prioridad], [ImpDef], [Usuario], [FechaMod]) " &
                             "VALUES('EXP', 'EXPENSAS', 'D', '', '', 0, 0, 0, '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
               .CommandText = "INSERT INTO Conceptos( [Codigo], [Descrip], [Accion], [Cuenta], [CtaAdm], [Comision], [Prioridad], [ImpDef], [Usuario], [FechaMod]) " &
                             "VALUES('HNP', 'HONORARIOS PROFESIONALES', 'D', '', '', 0, 0, 0, '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
               .CommandText = "INSERT INTO Conceptos( [Codigo], [Descrip], [Accion], [Cuenta], [CtaAdm], [Comision], [Prioridad], [ImpDef], [Usuario], [FechaMod]) " &
                             "VALUES('MDP', 'MES DEPOSITO', 'D', '', '', 0, 30, 0, '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
               .CommandText = "INSERT INTO Conceptos( [Codigo], [Descrip], [Accion], [Cuenta], [CtaAdm], [Comision], [Prioridad], [ImpDef], [Usuario], [FechaMod]) " &
                             "VALUES('SEL', 'SELLADO', 'D', '', '', 0, 30, 0, '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
               .CommandText = "INSERT INTO Conceptos( [Codigo], [Descrip], [Accion], [Cuenta], [CtaAdm], [Comision], [Prioridad], [ImpDef], [Usuario], [FechaMod]) " &
                              "VALUES('ICF', 'IVA CREDITO FISCAL 21%',          'D', '', '', 0, 99, 0, '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
               .CommandText = "INSERT INTO Conceptos( [Codigo], [Descrip], [Accion], [Cuenta], [CtaAdm], [Comision], [Prioridad], [ImpDef], [Usuario], [FechaMod]) " &
                              "VALUES('IDF', 'IVA DEBITO FISCAL 21%',          'D', '', '', 0, 99, 0, '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
               .CommandText = "INSERT INTO Conceptos( [Codigo], [Descrip], [Accion], [Cuenta], [CtaAdm], [Comision], [Prioridad], [ImpDef], [Usuario], [FechaMod]) " &
                                          "VALUES('INT', 'MULTA',          'D', '', '', 0, 1, 0, '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
               .CommandText = "INSERT INTO Conceptos( [Codigo], [Descrip], [Accion], [Cuenta], [CtaAdm], [Comision], [Prioridad], [ImpDef], [Usuario], [FechaMod]) " &
                                          "VALUES('RGN', 'RETENCION GANANCIAS',          'D', '', '', 0, 0, 0, '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
               .CommandText = "INSERT INTO Conceptos( [Codigo], [Descrip], [Accion], [Cuenta], [CtaAdm], [Comision], [Prioridad], [ImpDef], [Usuario], [FechaMod]) " &
                                          "VALUES('VCA', 'VALORES EN CARTERA',          'D', '', '', 0, 0, 0, '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
               .CommandText = "INSERT INTO Conceptos( [Codigo], [Descrip], [Accion], [Cuenta], [CtaAdm], [Comision], [Prioridad], [ImpDef], [Usuario], [FechaMod]) " &
                                          "VALUES('DIF', 'DIFERENCIA', 'D', '', '', 0, 0, 0, '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
            End If
            '
            .CommandText = "SELECT COUNT(1) FROM [TipoMovBco]"
            If .ExecuteScalar = 0 Then
               .CommandText = "INSERT INTO TipoMovBco( [TipoMovBco], [Descrip], [Imput], [TipoMov], [Cuenta], [Usuario], [FechaMod]) " & _
                              "VALUES( 1, 'CHEQUE', 'H', 'CH', NULL,	'" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
               .CommandText = "INSERT INTO TipoMovBco( [TipoMovBco], [Descrip], [Imput], [TipoMov], [Cuenta], [Usuario], [FechaMod]) " & _
                              "VALUES( 2, 'DEPOSITO', 'D', 'DP', NULL,	'" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
               .CommandText = "INSERT INTO TipoMovBco( [TipoMovBco], [Descrip], [Imput], [TipoMov], [Cuenta], [Usuario], [FechaMod]) " & _
                              "VALUES( 3, 'DEBITO', 'H', 'DB', NULL,	'" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
               .CommandText = "INSERT INTO TipoMovBco( [TipoMovBco], [Descrip], [Imput], [TipoMov], [Cuenta], [Usuario], [FechaMod]) " & _
                              "VALUES( 4, 'CREDITO', 'D', 'CR', NULL, '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
               .CommandText = "INSERT INTO TipoMovBco( [TipoMovBco], [Descrip], [Imput], [TipoMov], [Cuenta], [Usuario], [FechaMod]) " & _
                              "VALUES( 5, 'EXTRACCION', 'H', 'EX', NULL, '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
               .CommandText = "INSERT INTO TipoMovBco( [TipoMovBco], [Descrip], [Imput], [TipoMov], [Cuenta], [Usuario], [FechaMod]) " & _
                              "VALUES( 6, 'TRANSFERENCIA', 'D', 'TR', NULL, '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
            End If
            '
            .CommandText = "SELECT COUNT(1) FROM [EstPagos]"
            If .ExecuteScalar = 0 Then
               .CommandText = "INSERT INTO EstPagos( [Estado], [Descrip], [Usuario], [FechaMod]) " & _
                              "VALUES( 0, 'Generado', '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
               .CommandText = "INSERT INTO EstPagos( [Estado], [Descrip], [Usuario], [FechaMod]) " & _
                              "VALUES( 1, 'Autorizado', '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
               .CommandText = "INSERT INTO EstPagos( [Estado], [Descrip], [Usuario], [FechaMod]) " & _
                              "VALUES( 2, 'Confirmado', '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
               .CommandText = "INSERT INTO EstPagos( [Estado], [Descrip], [Usuario], [FechaMod]) " & _
                              "VALUES( 3, 'Pagado', '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
               .CommandText = "INSERT INTO EstPagos( [Estado], [Descrip], [Usuario], [FechaMod]) " & _
                              "VALUES( 4, 'Rendido', '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
               .CommandText = "INSERT INTO EstPagos( [Estado], [Descrip], [Usuario], [FechaMod]) " & _
                              "VALUES( 5, 'Anulado', '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
               .CommandText = "INSERT INTO EstPagos( [Estado], [Descrip], [Usuario], [FechaMod]) " & _
                              "VALUES( 6, 'Agrupado', '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
            End If
            '
            .CommandText = "SELECT COUNT(1) FROM [Logicos]"
            If .ExecuteScalar = 0 Then
               .CommandText = "INSERT INTO Logicos( [Dato], [SN], [VF], [Comision], [Marca]) " & _
                              "VALUES( 0, 'No',	'F', '', '')"
               .ExecuteNonQuery()
               .CommandText = "INSERT INTO Logicos( [Dato], [SN], [VF], [Comision], [Marca]) " & _
                              "VALUES( 1, 'Si',	'V', 'Sí', '*')"
               .ExecuteNonQuery()
            End If
            '
            .CommandText = "SELECT COUNT(1) FROM [CompInt]"
            If .ExecuteScalar = 0 Then
               .CommandText = "INSERT INTO [CompInt]( [Codigo], [Descrip], [Usuario], [FechaMod]) " & _
                              "VALUES( 'CB', 'COBROS', '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
               .CommandText = "INSERT INTO [CompInt]( [Codigo], [Descrip], [Usuario], [FechaMod]) " & _
                              "VALUES( 'CC', 'CONCEPTOS A COBRAR', '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
               .CommandText = "INSERT INTO [CompInt]( [Codigo], [Descrip], [Usuario], [FechaMod]) " & _
                              "VALUES('CH', 'CHEQUES', '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
               .CommandText = "INSERT INTO [CompInt]( [Codigo], [Descrip], [Usuario], [FechaMod]) " & _
                              "VALUES('CM', 'COMPRAS', '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
               .CommandText = "INSERT INTO [CompInt]( [Codigo], [Descrip], [Usuario], [FechaMod]) " & _
                              "VALUES('CO', 'COBROS OTROS', '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
               .CommandText = "INSERT INTO [CompInt]( [Codigo], [Descrip], [Usuario], [FechaMod]) " & _
                              "VALUES('CP', 'COMPRA OTROS', '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
               .CommandText = "INSERT INTO [CompInt]( [Codigo], [Descrip], [Usuario], [FechaMod]) " & _
                              "VALUES('CT', 'CONTRATO', '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
               .CommandText = "INSERT INTO [CompInt]( [Codigo], [Descrip], [Usuario], [FechaMod]) " & _
                              "VALUES('DB', 'DEBITO', '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
               .CommandText = "INSERT INTO [CompInt]( [Codigo], [Descrip], [Usuario], [FechaMod]) " & _
                              "VALUES('DP', 'DEPOSITO', '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
               .CommandText = "INSERT INTO [CompInt]( [Codigo], [Descrip], [Usuario], [FechaMod]) " & _
                              "VALUES('FC', 'VENTAS', '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
               .CommandText = "INSERT INTO [CompInt]( [Codigo], [Descrip], [Usuario], [FechaMod]) " & _
                              "VALUES('LI', 'LIQUIDACION INQUILINO', '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
               .CommandText = "INSERT INTO [CompInt]( [Codigo], [Descrip], [Usuario], [FechaMod]) " & _
                              "VALUES('LP', 'LIQUIDACION PROPIETARIO', '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
               .CommandText = "INSERT INTO [CompInt]( [Codigo], [Descrip], [Usuario], [FechaMod]) " & _
                              "VALUES('MN', '(MANUALES)', '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
               .CommandText = "INSERT INTO [CompInt]( [Codigo], [Descrip], [Usuario], [FechaMod]) " & _
                              "VALUES('OP', 'ORDEN DE PAGO', '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
               .CommandText = "INSERT INTO [CompInt]( [Codigo], [Descrip], [Usuario], [FechaMod]) " & _
                              "VALUES('PC', 'PAGO COMPROBANTES', '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
               .CommandText = "INSERT INTO [CompInt]( [Codigo], [Descrip], [Usuario], [FechaMod]) " & _
                              "VALUES('PO', 'PAGO OTROS', '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
               '
            End If
            '
            .CommandText = "SELECT COUNT(1) FROM [EscContrato]"
            If .ExecuteScalar = 0 Then
               .CommandText = "INSERT INTO [EscContrato] ([Escalon], [EscDescrip], [EscSimbolo], [EscUsuario], [EscFecMod] ) " &
                              "VALUES ( 0, 'Uniforme', '', '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
               .CommandText = "INSERT INTO [EscContrato] ([Escalon], [EscDescrip], [EscSimbolo], [EscUsuario], [EscFecMod] ) " &
                              "VALUES ( 1, 'Incremental', '$', '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
               .CommandText = "INSERT INTO [EscContrato] ([Escalon], [EscDescrip], [EscSimbolo], [EscUsuario], [EscFecMod] ) " &
                              "VALUES ( 2, 'Bloques', '$', '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
               .CommandText = "INSERT INTO [EscContrato] ([Escalon], [EscDescrip], [EscSimbolo], [EscUsuario], [EscFecMod] ) " &
                              "VALUES ( 3, 'Porcentaje', '%', '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
               .CommandText = "INSERT INTO [EscContrato] ([Escalon], [EscDescrip], [EscSimbolo], [EscUsuario], [EscFecMod] ) " &
                              "VALUES ( 4, 'Manual', '$', '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
            End If
            '
            If CapturaDato(Cn, "TipoComp", "COUNT(1)", "") = 0 Then
               Cmd.CommandText = "INSERT INTO TipoComp( Codigo, DescAbrev, Descrip, Imput, ParaFact, CompPago, Usuario, FechaMod) " &
                                 "VALUES( 1, 'FC', 'Factura', 'D', 1, 0, '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               Cmd.ExecuteNonQuery()
               Cmd.CommandText = "INSERT INTO TipoComp( Codigo, DescAbrev, Descrip, Imput, ParaFact, CompPago, Usuario, FechaMod) " &
                                 "VALUES( 2, 'NC', 'Nota de Crédito', 'H', 1, 0, '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               Cmd.ExecuteNonQuery()
               Cmd.CommandText = "INSERT INTO TipoComp( Codigo, DescAbrev, Descrip, Imput, ParaFact, CompPago, Usuario, FechaMod) " &
                                 "VALUES( 3, 'ND', 'Nota de Débito', 'D', 1, 0, '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               Cmd.ExecuteNonQuery()
               Cmd.CommandText = "INSERT INTO TipoComp( Codigo, DescAbrev, Descrip, Imput, ParaFact, CompPago, Usuario, FechaMod) " &
                                 "VALUES( 4, 'RC', 'Recibo', 'H', 0, 1, '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               Cmd.ExecuteNonQuery()
               Cmd.CommandText = "INSERT INTO TipoComp( Codigo, DescAbrev, Descrip, Imput, ParaFact, CompPago, Usuario, FechaMod) " &
                                 "VALUES( 5, 'TK', 'Ticket', 'D', 1, 0, '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               Cmd.ExecuteNonQuery()
               Cmd.CommandText = "INSERT INTO TipoComp( Codigo, DescAbrev, Descrip, Imput, ParaFact, CompPago, Usuario, FechaMod) " &
                                 "VALUES( 6, 'RM', 'Remito', 'D', 0, 0, '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               Cmd.ExecuteNonQuery()
               Cmd.CommandText = "INSERT INTO TipoComp( Codigo, DescAbrev, Descrip, Imput, ParaFact, CompPago, Usuario, FechaMod) " &
                                 "VALUES( 10, 'OP', 'Orden de Pago', 'H', 0, 1, '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               Cmd.ExecuteNonQuery()
            End If
            '
            If CapturaDato(Cn, "TipoProp", "COUNT(1)", "") = 0 Then
               Cmd.CommandText = "INSERT INTO TipoProp( Codigo, Descrip, Usuario, FechaMod) " &
                                 "VALUES( 'C', 'Casa', '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               Cmd.ExecuteNonQuery()
               Cmd.CommandText = "INSERT INTO TipoProp( Codigo, Descrip, Usuario, FechaMod) " &
                                 "VALUES( 'D', 'Departamento', '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               Cmd.ExecuteNonQuery()
               Cmd.CommandText = "INSERT INTO TipoProp( Codigo, Descrip, Usuario, FechaMod) " &
                                 "VALUES( 'L', 'Local comercial', '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               Cmd.ExecuteNonQuery()
               Cmd.CommandText = "INSERT INTO TipoProp( Codigo, Descrip, Usuario, FechaMod) " &
                                 "VALUES( 'D', 'Duplex', '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
               Cmd.ExecuteNonQuery()
            End If
            '
         End With
         '
      Catch ex As Exception
         Dim st As New StackTrace(True)
         RegistrarError(st, "")
      End Try
      '
   End Sub
   '
   Function AltaLocalidadAuto(Localidad As String, Optional CodPostal As Int32 = 0, Optional Tr As Object = "") As Integer
      '
      If Localidad = "" Then Return 0
      If Trim(Localidad) = "(Seleccionar)" Then Return 0
      '
      Dim r As Integer = 0
      Dim Cmd As New OleDb.OleDbCommand
      '
      With cmd
         .Connection = Cn
         If Tr.ToString <> "" Then
            .Transaction = Tr
         End If
         .CommandText = "Select LocalidadId FROM Localidad WHERE Descrip = '" & Localidad & "'"
         r = .ExecuteScalar
         If r = 0 Then
            .CommandText = "INSERT INTO Localidad( [Codigo], [Descrip], [Provincia], [Pais], [Usuario], [FechaMod]) " & _
                           "VALUES( " & CodPostal & ", '" & Localidad & "', '', 54, '" & Uid & "', '" & Format(Now, FormatFechaHora) & "')"
            .ExecuteNonQuery()
            .CommandText = "SELECT MAX(LocalidadId) FROM Localidad"
            r = .ExecuteScalar
         End If
      End With
      '
      Return r
      '
   End Function
   '
   Function LlenarTraductor() As Boolean
      '
      Dim Cmd As New OleDb.OleDbCommand
      '
      Dim Palabras As New Collection
      Dim Descrip As New Collection
      Dim Español As New Collection
      Dim English As New Collection
      Dim i, n As Int16
      '
      Palabras.Add("Alta") : Descrip.Add("") : Español.Add("Alta") : English.Add("Add")
      Palabras.Add("AnulaContrato") : Descrip.Add("") : Español.Add("Anula Contrato") : English.Add("Cancel Contract")
      Palabras.Add("Anulada") : Descrip.Add("") : Español.Add("Anulada") : English.Add("Canceled")
      Palabras.Add("AnulaLiqConf") : Descrip.Add("") : Español.Add("Anula Liquidación Confirmada") : English.Add("Cancel Confirmed Settlement")
      Palabras.Add("AnulaLiqProp") : Descrip.Add("") : Español.Add("Anula Liquidación Propietario") : English.Add("Cancel Owner Settlement")
      '
      Palabras.Add("Conciliar") : Descrip.Add("") : Español.Add("Conciliar") : English.Add("Conciliate")
      Palabras.Add("Modificar") : Descrip.Add("") : Español.Add("Modificar") : English.Add("Edit")
      '
      Palabras.Add("ComprExist") : Descrip.Add("") : Español.Add("Comprobante Existente") : English.Add("Existing Voucher")
      Palabras.Add("ConcAut") : Descrip.Add("") : Español.Add("Concepto Automático") : English.Add("Automatic Concept")
      Palabras.Add("CptePagado") : Descrip.Add("") : Español.Add("Comprobante Pagado") : English.Add("Voucher Paid")
      Palabras.Add("Contrato") : Descrip.Add("") : Español.Add("Contrato") : English.Add("Contract")
      Palabras.Add("CttoAnulado") : Descrip.Add("") : Español.Add("Contrato Anulado") : English.Add("Canceled Contract")
      Palabras.Add("CttoFinaliz") : Descrip.Add("") : Español.Add("Contrato Finalizado") : English.Add("Contract Completed")
      '
      Palabras.Add("DIIAlq>0") : Descrip.Add("") : Español.Add("Debe ingresar Importe Alquiler mayor que cero") : English.Add("You must enter Rental Amount greater than zero")
      '
      Palabras.Add("Factura") : Descrip.Add("") : Español.Add("Factura") : English.Add("Invoice")
      Palabras.Add("FondoFijo") : Descrip.Add("") : Español.Add("Fondo Fijo") : English.Add("Imprest")
      '
      Palabras.Add("LiqYaAnulada") : Descrip.Add("") : Español.Add("Liquidación ya Anulada") : English.Add("Settlement already Canceled")
      Palabras.Add("LiqConfNoAnul") : Descrip.Add("") : Español.Add("Liquidación Confirmada, no se puede anular") : English.Add("Settlement Confirmed, cannot be canceled")
      Palabras.Add("Login") : Descrip.Add("") : Español.Add("Ingresar") : English.Add("Login")
      '
      Palabras.Add("NoHayRegAct") : Descrip.Add("") : Español.Add("No hay registro activo") : English.Add("No active record")
      Palabras.Add("TrialVersNoAdd") : Descrip.Add("") : Español.Add("Versión de prueba, no es posible agregar mas datos") : English.Add("Trial version, it is not possible to add more data")
      Palabras.Add("TransNComp") : Descrip.Add("") : Español.Add("Transacción no completada") : English.Add("Transaction not completed")
      '
      With Cmd
         .Connection = Cn
         For i = 1 To Palabras.Count
            If IsNothing(CapturaDato(Cn, "Traductor", "Control", "Palabra = '" & Palabras.Item(i) & "'")) Then
               .CommandText = "INSERT INTO Traductor( Control, Palabra, Descrip, ENGLISH, ESPAÑOL, Sistema, FechaMod) " &
                              "VALUES ('msg" & Palabras.Item(i) & "', " &
                                         "'" & Palabras.Item(i) & "', " &
                                         "'" & Descrip.Item(i) & "', " &
                                         "'" & English.Item(i) & "', " &
                                         "'" & Español.Item(i) & "', " &
                                         "'" & "AdmIn" & "', " &
                                         "'" & Format(Now, FormatFechaHora) & "')"
            Else
               .CommandText = "UPDATE Traductor SET " &
                              " Control = 'msg" & Palabras.Item(i) & "', " &
                              " Descrip = '" & Descrip.Item(i) & "', " &
                              " ENGLISH = '" & English.Item(i) & "', " &
                              " ESPAÑOL = '" & Español.Item(i) & "', " &
                              " Sistema = '" & "AdmIn" & "', " &
                              " FechaMod = '" & Format(Now, FormatFechaHora) & "' " &
                              "WHERE Palabra = '" & Palabras.Item(i) & "'"
            End If
            n += .ExecuteNonQuery()
         Next
      End With
   End Function
   '
End Module