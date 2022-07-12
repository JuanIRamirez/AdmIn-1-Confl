Module ModAlgo
   '
   Function ArmaLikeBuscar(ByVal cBuscar As String, ByVal Aprox As Boolean) As Collection
      '
      Dim cLike As New Collection
      Dim nEsp As Integer
      '
      If Aprox Then
         Do While True
            nEsp = PosicionChar(" ", cBuscar)
            If nEsp = 0 Then
               cLike.Add(IIf(Aprox, "'%", "'") & cBuscar & IIf(cBuscar = "", "'", "%'"))
               Exit Do
            Else
               cLike.Add(IIf(Aprox, "'%", "'") & Left(cBuscar, nEsp - 1) & "%'")
               If nEsp = Len(cBuscar) Then
                  Exit Do
               End If
               cBuscar = Right(cBuscar, Len(cBuscar) - nEsp)
            End If
         Loop
      Else
         cLike.Add("'" & cBuscar & "%'")
      End If
      '
      Return cLike
      '
   End Function
   '
   Function PosicionChar(ByVal Caracter As String, ByVal Texto As String, Optional ByVal CompMayMin As Boolean = False) As Integer
      Dim i As Integer
      For i = 1 To Len(Texto)
         If CompMayMin Then
            If Mid(Texto, i, 1) = Caracter Then
               PosicionChar = i
               Exit For
            End If
         Else
            If UCase(Mid(Texto, i, 1)) = UCase(Caracter) Then
               PosicionChar = i
               Exit For
            End If
         End If
      Next i
   End Function
   '
   Sub TabReturn(ByRef Key As Char, Optional ByVal Mayusculas As Boolean = True, Optional ByVal Tilde As Boolean = True)
      If Key = Chr(13) Then
         Key = Chr(9)
      Else
         If Mayusculas Then
            Key = UCase(Key)
         End If
         If Not Tilde Then
            If Key = "'" Then
               Key = "´"
            End If
         End If
      End If
      LastKey = Key
   End Sub
   '
   Sub TabReturn(ByRef EvKey As KeyPressEventArgs, Optional ByVal Mayusculas As Boolean = True, Optional ByVal charNoPerm As String = "")
      '
      Dim Key As Char = EvKey.KeyChar
      '
      If Key = Chr(13) Then
         EvKey.Handled = True
         SendKeys.Send("{TAB}")
         'Key = Chr(9)
      Else
         If Mayusculas Then
            Key = UCase(Key)
         End If
         If charNoPerm <> "" Then
            If InStr(Key, charNoPerm) > 0 Then
               Key = " "
            End If
         End If
      End If
      '
      EvKey.KeyChar = Key
      '
   End Sub
   '
   Function Numero_a_Texto(ByVal nNumero As Double, Optional ByVal Miles As Boolean = False, Optional ByVal conDec As Boolean = True, Optional ByVal Mayusculas As Boolean = False, Optional ByVal MayMin As Boolean = True) As String
      '
      Dim cNumero As String = ""
      '
      Dim Entero As String = ""
      Dim cDecim As String = ""
      '
      Dim Unidad As String = ""
      Dim Decena As String = ""
      Dim Centena As String = ""
      Dim Millones As Integer
      Dim Signo As String = ""
      '
      Entero = CStr(Int(nNumero))
      If Len(Entero) > 6 Then
         Millones = Left(Entero, Len(Entero) - 6)
      End If
      Entero = Right(Entero, 6)
      '
      If Val(Entero) = 0 And Millones = 0 Then cNumero = "Cero "
      '
      If Millones > 0 Then cNumero = Numero_a_Texto(Millones, True, False) & " Millon" & IIf(Millones > 1, "es ", " ")
      If Val(Entero) > 999 Then cNumero = cNumero & Numero_a_Texto(Val(Entero) / 1000, True, False) + " Mil "
      If Val(Entero) > 99 Then Centena = Left(Right(Entero, 3), 1)
      If Val(Right(Entero, 2)) < 16 Then
         Unidad = Right(Entero, 2)
      Else
         Decena = Left(Right(Entero, 2), 1)
         Unidad = Right(Entero, 1)
      End If
      '
      If Centena <> "" Then cNumero = cNumero & Centenas(Val(Centena), Val(Decena), Val(Unidad))
      '
      If Decena <> "" Then
         cNumero = cNumero & Decenas(Val(Decena), Val(Unidad))
      End If
      If Unidad <> "" Then cNumero = cNumero & Unidades(Val(Unidad), Miles)
      '
      If Not Miles Then
         If conDec Then
            If nNumero - Int(nNumero) > 0 Then
               cDecim = " c/" & Format((nNumero - Int(nNumero)) * 100, "00") & " Cvs."
            End If
         End If
      End If
      '
      If Mayusculas Then
         cNumero = UCase(cNumero)
         cDecim = UCase(cDecim)
      Else
         If Not MayMin Then
            cNumero = LCase(cNumero)
            cDecim = LCase(cDecim)
         End If
      End If
      '
      Return Trim(cNumero) & cDecim
      '
   End Function
   '
   Function Unidades(ByVal nUnidad As Integer, ByVal Miles As Boolean) As String
      '
      Select Case nUnidad
         Case 1
            Unidades = IIf(Miles, "Un ", "Uno ")
         Case 2
            Unidades = "Dos "
         Case 3
            Unidades = "Tres "
         Case 4
            Unidades = "Cuatro "
         Case 5
            Unidades = "Cinco "
         Case 6
            Unidades = "Seis "
         Case 7
            Unidades = "Siete "
         Case 8
            Unidades = "Ocho "
         Case 9
            Unidades = "Nueve "
         Case 10
            Unidades = "Diez "
         Case 11
            Unidades = "Once "
         Case 12
            Unidades = "Doce "
         Case 13
            Unidades = "Trece "
         Case 14
            Unidades = "Catorce "
         Case 15
            Unidades = "Quince "
         Case Else
            Unidades = ""
      End Select
      '
   End Function
   '
   Function Decenas(ByVal nDecena As Integer, ByVal nUnidad As Integer) As String
      '
      Select Case nDecena
         Case 1
            Decenas = "Dieci"
         Case 2
            Decenas = IIf(nUnidad = 0, "Veinte ", "Veinti")
         Case 3
            Decenas = "Treinta "
         Case 4
            Decenas = "Cuarenta "
         Case 5
            Decenas = "Cincuenta "
         Case 6
            Decenas = "Sesenta "
         Case 7
            Decenas = "Setenta "
         Case 8
            Decenas = "Ochenta "
         Case 9
            Decenas = "Noventa "
         Case Else
            Decenas = ""
      End Select

      If nDecena > 2 And nUnidad > 0 Then
         Decenas = Decenas & "y "
      End If
      '
   End Function
   '
   Function Centenas(ByVal nCentenas As Integer, ByVal nDecenas As Integer, ByVal nUnidades As Integer) As String
      '
      Select Case nCentenas
         Case 1
            Centenas = IIf(nDecenas + nUnidades = 0, "Cien ", "Ciento ")
         Case 2
            Centenas = "Doscientos "
         Case 3
            Centenas = "Trescientos "
         Case 4
            Centenas = "Cuatrocientos "
         Case 5
            Centenas = "Quinientos "
         Case 6
            Centenas = "Seiscientos "
         Case 7
            Centenas = "Setecientos "
         Case 8
            Centenas = "Ochocientos "
         Case 9
            Centenas = "Novecientos "
         Case Else
            Centenas = ""
      End Select
      '
   End Function
   '
   Sub LimpiaCtrl(ByVal Frm As Form)

      Dim Ctrl As Control

      For Each Ctrl In Frm.Controls
         If TypeOf Ctrl Is TextBox Then
            Ctrl.Text = ""
         ElseIf TypeOf Ctrl Is ComboBox Then
            Ctrl.Text = ""
         ElseIf TypeOf Ctrl Is DateTimePicker Then
            'Ctrl.Value = Today
         End If
      Next Ctrl
   End Sub
   '
   Sub SoloNumeros(ByRef key As Integer, Optional ByVal Punto As Boolean = False, Optional ByVal Texto As String = "", Optional ByVal ChrAdic As String = "")
      SoloNumeros(ChrW(key), Punto, Texto, ChrAdic)
   End Sub
   '
   Sub SoloNumeros(ByRef Key As Char, Optional ByVal Punto As Boolean = False, Optional ByVal Texto As String = "", Optional ByVal ChrAdic As String = "")
      '
      Dim i As Integer
      Dim j As Integer
      Dim c As String = ""
      '
      If Texto = "" Then
         If Not Punto Then
            If Key = "." Then
               Key = ""
            End If
         End If
         If Key > " " And (Key < "0" Or Key > "9") And Key <> ChrAdic Then
            If Key <> "." Then
               Key = ""
            End If
         End If
      Else
         For i = 1 To Len(Texto)
            If Asc(Mid(Texto, i, 1)) >= 48 And Asc(Mid(Texto, i, 1)) <= 57 Then
               c = c & Mid(Texto, i, 1)
            End If
         Next i
         Texto = c
         If Punto Then
            Texto = ""
            For i = Len(c) To 1 Step -3
               j = j + 1
               If Len(c) - (3 * j) + 1 > 1 Then
                  Texto = "." & Mid(c, Len(c) - (3 * j) + 1, 3) & Texto
               Else
                  Texto = Mid(c, 1, Len(c) - (j - 1) * 3) & Texto
               End If
            Next i
         End If
      End If
      '
   End Sub
   '
   Function ValCuit(ByVal pCuit As String, Optional ByVal Mensaje As Boolean = True) As Boolean
      '
      Dim DigVf, CuitResto
      Dim i, CuitSum As Integer
      'Dim CuitDig
      Const ValVerif = "54327654321"
      '
      If Not IsNothing(pCuit) Then
         pCuit = ReemplazaChar(pCuit, "-", "")
         '
         If Len(pCuit) <> 11 Then
            If Mensaje Then
               MensajeTrad("C.U.I.T. no válido")
            End If
         Else
            DigVf = Val(Mid(pCuit, 11, 1))
            For i = 1 To 11
               CuitSum = CuitSum + Val(Mid(pCuit, i, 1)) * Val(Mid(ValVerif, i, 1))
            Next
            CuitResto = Resto(CuitSum, 11)
            If CuitResto = 0 Then
               ValCuit = True
            Else
               MensajeTrad("C.U.I.T. Incorrecto")
            End If
         End If
      End If
      '
   End Function
   '
   Function ReemplazaChar(ByVal Texto As String, ByVal Car As String, Optional ByVal Reemplazo As String = " ") As String
      Dim i As Integer
      If Not IsDBNull(Texto) Then
         For i = 1 To Len(Texto) + 1
            If Mid(Texto, i, Len(Car)) = Car Then
               Texto = Left(Texto, i - 1) & Reemplazo & _
                       Right(Texto, Len(Texto) - i - Len(Car) + 1)
            End If
         Next i
         'ReemplazaChar = Texto
      End If
      Return Texto
   End Function
   '
   Function Resto(ByVal Dividendo, ByVal Divisor) As String   ', Optional CantDig = 2) as Long
      Dim a As String
      Dim Pos As Integer
      a = Dividendo - Dividendo / Divisor
      Pos = PosicionChar(".", a)
      If Pos = 0 Then
         Resto = 0
      Else
         Resto = Right(a, Len(a) - Pos)
      End If
   End Function
   '
   'Sub Mayusculas(ByRef Key As Char)
   '   Key = UCase(Key)
   'End Sub
   ''
   'Sub Minusculas(ByRef Key As Char)
   '   Key = LCase(Key)
   'End Sub
   '
   Sub SetRegForm(ByVal Form As Form)   'Guarda Tamaño y Posición del Formulario.
      SetDBForm(Form)
   End Sub
   '
   Sub GetRegForm(ByVal Form As Form)   'Trae Tamaño y Posición del Formulario.
      GetDBForm(Form)
   End Sub
   '
   Sub GetRegGrid(ByVal Frm As Form, ByVal Dtg As DataGridView)
      GetDbGrid(Frm, Dtg)
   End Sub
   '
   Sub SetRegGrid(ByVal Frm As Form, ByVal Dtg As DataGridView)
      SetDBGrid(Frm, Dtg)
   End Sub
   '
   Sub Mensaje(ByVal Msg As String)
      MsgBox(Msg, vbInformation)
   End Sub
   '
   Public Sub MensageError(st As StackTrace, ByVal Obj As Object, Optional ByVal Msj As String = "")
      RegistrarError(st, Obj, True, Msj)
   End Sub
   '
   Public Sub RegistrarError(st As StackTrace, ByVal Obj As Object, Optional ByVal Mostrar As Boolean = True, Optional ByVal Msj As String = "", Optional Src As String = "", Optional err_Nro As Integer = 0)
      '
      Dim ArchLog As String
      Dim TextError As String
      Dim sStack As String = ""
      Dim i As Int32
      Dim Adjuntos As New Collection
      '
      For i = st.GetFrames.Length - 1 To 0 Step -1
         If st.GetFrame(i).GetFileName() <> "" Then
            sStack = sStack & "File: " & st.GetFrame(i).GetFileName() & ", Meth: " & st.GetFrame(i).GetMethod().Name & ", Line: " & st.GetFrame(i).GetFileLineNumber() & vbCrLf
         End If
      Next
      '
      If Mostrar Then
         MsgBox("ERROR: " & IIf(Msj = "", Err.Description, Msj) & vbCrLf & " " & IIf(err_Nro = 0, "", "(" & Err.Number & ")") & IIf(Src = "", "", ", Src: " & Src), MsgBoxStyle.Critical)
      End If
      '
      TextError = "Uid.: " & Uid & vbCrLf & _
                  "Obj.: " & Obj.ToString & vbCrLf & _
                  "Fec.: " & Format(Now, FormatFechaHora) & vbCrLf & _
                  "Err.: " & Err.Number & vbCrLf & _
                  "Src.: " & IIf(Src = "", Err.Source, Src) & vbCrLf & _
                  "L.N.: " & Err.Erl & vbCrLf & _
                  "Err.: " & Err.ToString & vbCrLf & _
                  "Des.: " & IIf(Msj = "", Err.Description, Msj) & vbCrLf & _
                  sStack & _
                  Replicate("-", Err.Description.Length + 5)
      '
      ArchLog = Raiz & EmpAbr & "\" & Sistema & "\Error.log"
      '
      Dim f As New System.IO.StreamWriter(ArchLog, True)
      '
      f.WriteLine(TextError)
      f.Close()
      '
      EnviarMail("jiramirez.nqn@gmail.com", "Error en tiempo de Ejecución", TextError, Adjuntos)
      '
   End Sub
   '
   Function PadL(ByVal Variable As String, ByVal Caracter As String, ByVal Tamaño As Integer) As String
      Dim c As String = ""
      Caracter = Replicate(Caracter, Tamaño)
      PadL = Right(Caracter & Variable, Tamaño)
      Return PadL
   End Function
   '
   Function PadR(ByVal Variable As String, ByVal Caracter As String, ByVal Tamaño As Integer) As String
      Dim c As String = ""
      Caracter = Replicate(Caracter, Tamaño)
      PadR = Left(Variable & Caracter, Tamaño)
      Return PadR
   End Function
   '
   Sub Limpiacampos(ByVal Form As Form, Optional ByVal Excepcion1 As String = "", Optional ByVal Excepcion2 As String = "", Optional ByVal Excepcion3 As String = "")
      '
      Dim Ctrl As New Control
      '
      For Each Ctrl In Form.Controls
         If Ctrl.Name <> Excepcion1 And _
            Ctrl.Name <> Excepcion2 And _
            Ctrl.Name <> Excepcion3 Then
            '
            If TypeOf Ctrl Is TextBox Then
               Ctrl.Text = ""
            ElseIf TypeOf Ctrl Is ComboBox Then
               'If Ctrl.Style = 0 Then
               Ctrl.Text = ""
               'Else
               '  Ctrl.ListIndex = -1
               'End If
            ElseIf TypeOf Ctrl Is CheckBox Then
               'Ctrl.checked = False
               'ElseIf TypeOf Ctrl Is MaskEdBox Then
            ElseIf Ctrl.Name = "Cuit" Then
               Ctrl.Text = PromptCuit
            End If
            '
         End If
      Next Ctrl
      '
   End Sub
   '
   Function DescontarBonificacion(ByVal Precio As Double, ByVal Bonificacion As String) As Double
      '
      Dim Bonif As New Collection
      Dim Pos As Integer
      Dim i As Int16
      '
      If Val(Bonificacion) <> 0 Then
         'Bonific = Bonificacion
         Bonif.Add(Val(Bonificacion))
         Do While InStr(Bonificacion, "+") > 0
            Pos = InStr(Bonificacion, "+")
            Bonificacion = Right(Bonificacion, Len(Bonificacion) - Pos)
            Bonif.Add(Val(Bonificacion))
         Loop
      End If
      'PrUnit = Val(tbCosto)
      For i = 1 To Bonif.Count
         Precio = Precio - Precio * Val(Bonif.Item(i)) / 100
      Next i
      '
      Return Precio
      '
   End Function
   '
   Function CapturaDatoColumna(ByVal dtg As DataGridView, ByVal col As String)
      With dtg
         Return .SelectedCells(.Columns(col).Index).Value()
      End With
   End Function
   '
   Function UltDiaMes(ByVal Fecha As Date) As Date
      Dim Mes As Integer
      Mes = Month(Fecha)
      Do While Month(Fecha) = Mes
         Fecha = Fecha.AddDays(1)
      Loop
      Fecha = Fecha.AddDays(-1)
      Return Fecha
   End Function
   '
   Function PrimeroDeMes(Fecha As Date) As Date
      Dim r As Date = "01/" & Fecha.Month & "/" & Fecha.Year
      Return r
   End Function
   '
   Function SumaMes(ByVal Fecha As Date, ByVal Meses As Integer) As Date
      '
      SumaMes = Fecha.AddMonths(Meses)
      '
   End Function
   '
   Function CodigoAut() As Boolean
      '
      Dim Clave As String = BuscarCfg("cfgCodigoAut", "")
      '
      If Clave <> "" Then
         With frmCodigoAut
            .ShowDialog()
            CodigoAut = .Autorizado
         End With
      Else
         CodigoAut = True
      End If
      '
   End Function
   '
End Module
