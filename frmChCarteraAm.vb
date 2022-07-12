Public Class frmChCarteraAM
   '
   Public Alta As Boolean
   Public Banco As Integer = 0
   Public ChCartId As Long
   Public SoloVer As Boolean
   Public Entregar As Boolean
   Public aCobrar As Boolean
   Public Cobrado As Boolean
   Public Devolver As Boolean
   Public Editar As Boolean
   Public Comprob As String = ""
   '
   Dim a As String
   '
   Dim Trn As OleDb.OleDbTransaction
   Dim Cmd As New OleDb.OleDbCommand
   Dim Drd As OleDb.OleDbDataReader
   'Dim rsDLiq As New ADODB.Recordset
   '
   Dim nNumero As Long
   Dim Cliente As Long
   '
   Dim nSubTotal As Double
   Dim nIva1 As Double
   Dim nIva2 As Double
   Dim TotalPago As Double
   Dim AlicIva1 As Single
   Dim AlicIva2 As Single
   '
   Dim cCtaCaja As String
   Dim cCtaCajaAd As String
   Dim cCtaVCar As String
   Dim cCtaVCar3 As String
   Dim CaptCtas As Boolean
   Dim SdoVenc As Double
   Dim fPago As String
   Dim FechaEmi As Date
   '
   Const cmpInt = "CH"
   '
   Private Sub frmChCarteraAM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      '
      GetRegForm(Me)
      '
      TraducirForm(Me)
      '
      Me.Text = Me.Text & " - " & IIf(Entregar, "Entregar", IIf(Cobrado, "Cobrar", IIf(aCobrar, " A Cobrar", IIf(Alta, "Alta", "Modificar"))))
      '
      If SisContable Then
         If CaptCtasCaja(prmNroCaja, cCtaCaja, cCtaCajaAd) Then
            If CaptCtasConc(cfgCodigoVCar, "", cCtaVCar, cCtaVCar3) Then
               CaptCtas = True
            End If
         End If
         If Not CaptCtas Then DeshabForm(Me)
      End If
      '
      ArmaComboItem(cboBanco, "Bancos", "Banco", "Nombre", "Nombre", , , , , , Banco)
      '
      fPago = IIf(Entregar, "CHs", "CH")
      '
      Cmd.Connection = Cn
      '
      If Alta Then
         dtpFecha.Value = Today
         FechaEmi = Today
      Else
         With Cmd
            .CommandText = "SELECT * FROM ChCartera WHERE ChCartId = " & ChCartId
            Drd = .ExecuteReader
         End With
         With Drd
            If .Read Then
               PosCboItem(cboBanco, !Banco)
               tbCtaBco.Text = !BancoCta
               dtpFecha.Value = !FechaDif
               tbNumero.Text = !ChCartNro
               tbTitular.Text = !Titular & ""
               tbDetalle.Text = !Detalle & ""
               tbImporte.Text = !Importe
               tbEntrego.Text = !Entrego & ""
               FechaEmi = !FechaEmi
            Else
               MensajeTrad("Cheque No Encontrado")
            End If
            .Close()
         End With
      End If

      ActivaCtrl()
      '
   End Sub
   '
   Private Sub cboBanco_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBanco.SelectedIndexChanged
      With cboBanco
         If .SelectedIndex > 0 Then
            Banco = .SelectedValue
         End If
      End With
   End Sub
   '
   Private Sub frmChCarteraAM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
      TabReturn(e.KeyChar)
   End Sub
   '
   Private Sub ActivaCtrl()
      cboBanco.Enabled = Alta   'Not Entregar And Not aCobrar And Not Cobrado And Not Devolver And Not Editar
      tbCtaBco.Enabled = Alta   'Not Entregar And Not aCobrar And Not Cobrado And Not Devolver and not editar
      dtpFecha.Enabled = Not Entregar And Not aCobrar And Not Cobrado And Not Devolver And Comprob = ""
      tbNumero.Enabled = Alta   'Not Entregar And Not aCobrar And Not Cobrado And Not Devolver
      tbTitular.Enabled = Not Entregar And Not aCobrar And Not Cobrado And Not Devolver
      tbDetalle.Enabled = True
      tbImporte.Enabled = Not Entregar And Not aCobrar And Not Cobrado And Not Devolver And Comprob = ""
      tbEntrego.Enabled = Not Entregar And Not aCobrar And Not Cobrado And Not Devolver
   End Sub
   '
   Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
      If Validar() Then
         If Guardar() Then
            Me.Close()
         End If
      End If
   End Sub
   '
   Private Function Validar() As Boolean
      '
      If Banco = 0 Then
         MensajeTrad("DIBanco")
         If cboBanco.Enabled Then
            cboBanco.Focus()
         End If
         Return False
      End If
      '
      If tbCtaBco.Text = "" Then
         'If Alta Then
         MensajeTrad("DICtaBco")
         If tbCtaBco.Enabled Then
            tbCtaBco.Focus()
         End If
         Return False
      ElseIf tbNumero.Text = "" Then
         MensajeTrad("DINroCheque")
         If tbNumero.Enabled Then
            tbNumero.Focus()
         End If
         Return False
      ElseIf Val(tbNumero.Text) = 0 Then
         MensajeTrad("DINumero")
         tbNumero.Focus()
         Return False
      ElseIf Val(tbImporte.Text) = 0 Then
         MensajeTrad("Total=0")
         Return False
      Else
         If Alta Then
            If Not IsNothing(CapturaDato(Cn, "ChCartera", "ChCartId", "Banco = " & Banco & " AND BancoCta = '" & tbCtaBco.Text & "' AND ChCartNro = '" & tbNumero.Text & "'")) Then
               MensajeTrad("Cheque Existente")
               Return False
            End If
         End If
      End If
      '
      Return True
      '
   End Function
   '
   Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
      '
      Dim Ctrl As Control
      '
      If Alta And tbCtaBco.Text <> "" Then
         For Each Ctrl In Me.Controls
            If TypeOf Ctrl Is TextBox Then
               If Ctrl.Enabled Then
                  LimpiaCtrl(Me)
               End If
            End If
         Next Ctrl
      Else
         Me.Close()
      End If
      '
   End Sub

   Private Sub tbImporte_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbImporte.KeyPress
      SoloNumeros(e.KeyChar, True)
   End Sub
   '
   Private Function Guardar() As Boolean
      '
      Dim cComprob As String
      Dim DetAsi As String = ""
      Dim NroAsi As Long
      Dim RenASi As Integer
      Dim FP As String
      Dim DescripMov As String
      Dim DetalleMov As String
      Dim FecCaja As Date
      Dim Estado As Byte = IIf(Entregar, 2, IIf(aCobrar, 4, IIf(Cobrado, 5, 0)))
      Dim FechaSal As String
      '
      cComprob = fPago & "-" & Banco & "-" & tbCtaBco.Text & "-" & tbNumero.Text
      DescripMov = "CH en Cartera"
      DetalleMov = cComprob & " - " & Me.tbTitular.Text
      '
      Try
         Trn = Cn.BeginTransaction
         '
         With Cmd
            .Transaction = Trn
            If Alta Then
               .CommandText = "INSERT INTO [ChCartera]( [Banco], [BancoCta], [ChCartNro], [Titular], [FechaEmi], [FechaDif], [Entrego], [Importe], [Estado], [CajaAdm], [Detalle], [Caja], [FechaEnt], [FechaSal], [Usuario], [FechaMod]) " & _
                              "VALUES (" & Banco & ", " & _
                                     "'" & tbCtaBco.Text & "', " & _
                                     "'" & tbNumero.Text & "', " & _
                                     "'" & tbTitular.Text & "', " & _
                                     "'" & Format(Today, FormatFecha) & "', " & _
                                     "'" & Format(dtpFecha.Value, FormatFecha) & "', " & _
                                     "'" & tbEntrego.Text & "', " & _
                                           tbImporte.Text & ", " & _
                                           Estado & ", " & _
                                           0 & ", " & _
                                     "'" & tbDetalle.Text & "', " & _
                                           prmNroCaja & ", " & _
                                     "'" & Format(Today, FormatFecha) & "', " & _
                                          "NULL, " & _
                                     "'" & Uid & "', " & _
                                     "'" & Format(Now, FormatFechaHora) & "')"
            Else
               If Entregar Or aCobrar Then
                  FechaSal = "'" & Format(Today, FormatFecha) & "'"
               Else
                  FechaSal = "NULL"
               End If
               .CommandText = "UPDATE ChCartera SET " &
                              " Banco = " & Banco & ", " &
                              " BancoCta = '" & tbCtaBco.Text & "', " &
                              " Titular = '" & tbTitular.Text & "', " &
                              " FechaDif = '" & Format(dtpFecha.Value, FormatFecha) & "', " &
                              " ChCartNro = '" & tbNumero.Text & "', " &
                              " Importe = " & Val(tbImporte.Text) & ", " &
                              " FechaEmi = '" & Format(fechaemi, FormatFecha) & "', " &
                              " Entrego = '" & tbEntrego.Text & "', " &
                              " Estado = " & IIf(Entregar, 2, IIf(aCobrar, 4, IIf(Cobrado, 5, 0))) & ", " &
                              " Detalle = '" & tbDetalle.Text & "', " &
                              " FechaSal = " & FechaSal & ", " &
                              " Usuario = '" & Uid & "', " &
                              " FechaMod = '" & Format(Now, FormatFechaHora) & "' " &
                              "WHERE ChCartId = " & ChCartId
            End If
            '
            .ExecuteNonQuery()
            '
         End With
         '
         If Entregar Or aCobrar Then
            FP = fPagoCaja(cComprob, fPago, Trn)
            '
            If Not ActCaja(prmNroCaja, cComprob, FP, Today, tbEntrego.Text, "", Mid(tbDetalle.Text, 1, 50), 0, tbImporte.Text, True, Trn) Then
               Err.Raise(1001)
            End If
            '
            DescripMov = IIf(Entregar, "Entrega", "Pasa a Cobrar") & " " & DescripMov
         Else
            If Cobrado Then
               FP = fPagoCaja(cComprob, "EF", Trn)
               '
               If Not ActCaja(prmNroCaja, cComprob, FP, Today, tbEntrego.Text, "", Mid(tbDetalle.Text, 1, 50), tbImporte.Text, 0, True, Trn) Then
                  Err.Raise(1001)
               End If
               '
               DescripMov = DescripMov & " Cobrado"
            Else
               FP = "CH"
               If Alta Then
                  FecCaja = Today
               Else
                  If Devolver Then
                     FecCaja = Today
                  Else
                     FecCaja = CapturaDato(Cn, "Caja", "Fecha", "Comprob = '" & cComprob & "' AND FPago = '" & FP & "'", , , , Trn)
                     If Format(FecCaja, FormatFecha) = "00010101" Then
                        FecCaja = Today
                     End If
                  End If
               End If
               'FP = fPagoCaja(cComprob, IIf(Devolver, "-", "") & "CH", Trn)
               If Not ActCaja(prmNroCaja, cComprob, FP, FecCaja, tbEntrego.Text, "", Mid(tbDetalle.Text, 1, 50), tbImporte.Text, 0, True, Trn) Then
                  Err.Raise(1001, , "NoActCaja")
               End If
               DescripMov = IIf(Devolver, "Devuelve", IIf(Alta, "Alta", "Modif,")) & " " & DescripMov
            End If
         End If
         '
         If SisContable Then
            If Devolver Then
               BorraAsiento(cComprob, Trn)
            Else
               NroAsi = GuardaAsiento(cComprob, Today, "Salida Ch en Cartera", Trn)
               If NroAsi = 0 Then
                  Err.Raise(1001, , Traducir("NoUpAsiento", , Trn))
               End If
               '
               BorraAsienDet(NroAsi, Trn)
               RenASi = RenASi + 1
               If Not GuardaAsienDet(NroAsi, RenASi, IIf(Entregar, cCtaVCar, cCtaCaja), DetAsi, IIf(Entregar, 0, tbImporte.Text), IIf(Entregar, tbImporte.Text, 0), Trn) Then
                  Err.Raise(1001, , Traducir("NoUpAsiento", , Trn))
               End If
               '
               RenASi = RenASi + 1
               If Not GuardaAsienDet(NroAsi, RenASi, cCtaVCar, DetAsi, IIf(Entregar, tbImporte.Text, 0), IIf(Entregar, 0, tbImporte.Text), Trn) Then
                  Err.Raise(1001, , Traducir("NoUpAsiento", , Trn))
               End If
            End If
         End If
         '
         GuardarAudit(DescripMov, DetalleMov, Me.Name, "Guardar", Trn)
         '
         Trn.Commit()
         '
         Return True
         '
      Catch
         MsgBox(Err.Number & ": " & Err.Description & Chr(13) + Chr(10) & Traducir("TransNComp", , Trn))
         Trn.Rollback()
         Return False
      End Try
      '
   End Function
   '
   Private Sub frmChCarteraAM_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
      SetRegForm(Me)
      Me.Dispose()
   End Sub
   '
End Class