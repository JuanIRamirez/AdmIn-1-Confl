'
' Compat.vb
' Mantiene compatibilidad con versiones anteriores del Sistema (VB6).
'
Module modCompat
    '
   Function Encrypt(ByVal Clave, Optional ByVal Inverso = False, Optional ByVal Dif = False, Optional ByVal Max = 0) As String
      '
      Dim Operador As Integer
      Dim Tamaño As Integer
      Dim r As String = ""
      Dim i As Int16
      '
      If Inverso Then
         Operador = -1
      Else
         Operador = 1
      End If
      '
      If Not IsDBNull(Clave) Then
         If Max = 0 Then
            Tamaño = Len(Clave)
         Else
            Tamaño = Max
         End If
         '
         If Len(Clave) < Tamaño Then
            Clave = Clave & Replicate(" ", Tamaño - Len(Clave))
         End If
         '
         If Dif Then
            For i = Tamaño To 1 Step -1
               r = r & Chr(Asc(Mid(Clave, i, 1)) + (i + 127) * Operador)
            Next i
         Else
            For i = 1 To Tamaño
               r = r & Chr(Asc(Mid(Clave, i, 1)) + (Tamaño - i + 1) * Operador)
            Next i
         End If
      End If
      '
      Return r
      '
   End Function
   '
   Function Encrypt2(ByVal Txt As String, Optional ByVal Inverso As Boolean = False)
      '
      Dim ret As String
      Dim i As Integer

      Txt = Trim(Txt)
      '
      ret = ""
      '
      If Txt <> "" Then
         For i = 1 To Len(Txt)
            If Not Inverso Then
               ret = ret & Chr(Asc(Mid(Txt, i, 1)) + 127 + i)
            Else
               ret = ret & Chr(Asc(Mid(Txt, i, 1)) - 127 - i)
            End If
         Next
      End If
      '
      Encrypt2 = ret
      '
   End Function
   '
   Function Replicate(ByVal Caracter As String, ByVal Tamaño As Integer) As String
      Dim i As Integer
      Dim c As String = ""
      For i = 1 To Tamaño
         c = c & Caracter
      Next i
      Replicate = c
   End Function
   '
   Sub TraducirForm(ByVal frm As Form)
      'Nada por ahora.
   End Sub
   '
   Function CaptFechaPartida(Proveedor, Producto, Partida, Costo) As Date
      Return Today
   End Function
   '
End Module
