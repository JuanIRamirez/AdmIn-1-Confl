Public Class FrmLiqInquilinosPend
   '
   Const EstANUL = 2
   Const EstPEND = 3
   Const EstCONF = 1
   '
   Dim Trn As OleDb.OleDbTransaction
   Dim Cmd As New OleDb.OleDbCommand
   Dim Cm2 As New OleDb.OleDbCommand
   Dim Drd As OleDb.OleDbDataReader
   '
   Dim Inquilino As Long
   Dim LiqInqId As Long
   '
   Dim Tipo As String
   Dim Sucursal As Integer
   Dim Numero As Long
   '
   Dim Periodo As String
   Dim NombreInq As String
   '
   Dim TotalLiq As Double
   Dim cCtaInq As String
   Dim cCtaCaja As String
   Dim cCtaCajaAd As String
   Dim cCtaVCar As String
   Dim cCtaVCar3 As String
   Dim cDescInt As String
   Dim cCtaInt As String
   Dim cCtaInt3 As String
   Dim cCtaRGan As String
   Dim cDescRGan As String
   '
   Dim nPrdInt As Integer
   Dim VerifConc As Boolean
   Dim CantLiq As Integer
   Dim cTmp As String
   Dim cTmpTr As String
   Dim aCuenta As Boolean
   Dim AgRetGan As Boolean
   Dim formLoad As Boolean
   '
   Const cStruct = "Tipo VarChar (1) NOT NULL, Sucursal SmallInt NOT NULL, Numero INT NOT NULL, Retencion FLOAT NULL DEFAULT 0, LiqInqId INT"
   Const cStrTR = "Banco0 INT NOT NULL, " &
                  "Cuenta0 VarChar(25) NOT NULL, " &
                  "Titular VarChar(50) NOT NULL, " &
                  "Banco1 INT NOT NULL, " &
                  "Cuenta1 VarChar(25) NOT NULL, " &
                  "FechaTR SmallDateTime NOT NULL, " &
                  "NumeroTR VarChar(25) NOT NULL, " &
                  "ImporteTR FLOAT NOT NULL, " &
                  "GastosImp FLOAT NULL, " &
                  "GastosSF FLOAT NULL, " &
                  "GastosIva FLOAT NULL, " &
                  "ImporteNeto FLOAT NULL"
   '
   Const minHeight = 6555
   Const minWidth = 9810
   Const cmpInt = "LI"
   '
   Private Sub LiqInqPend_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      '
      GetRegForm(Me)
      '
      TraducirForm(Me)
      '
      If SisContable Then
         cCtaCaja = CapturaDato(Cn, "Cajas", "Cuenta", "Caja = " & prmNroCaja) & ""
         cCtaCajaAd = CapturaDato(Cn, "Cajas", "CtaAdm", "Caja = " & prmNroCaja) & ""
         '
         If cCtaCaja = "" Or cCtaCajaAd = "" Then
            MensajeTrad("CtaCajaNoAsig")
            DeshabForm(Me)
            Exit Sub
         End If
      End If
      '
      If FechaIncorrecta() Then
         DeshabForm(Me)
      End If
      '
      If SisContable Then
         If CaptCtasConc(cfgCodigoVCar, "", cCtaVCar, cCtaVCar3) Then
            If CaptCtasConc(cfgCodigoInt, cDescInt, cCtaInt, cCtaInt3, nPrdInt) Then
               If CaptCtasConc(cfgCodigoRGan, cDescRGan, cCtaRGan, "") Then
                  VerifConc = True
               End If
            End If
         End If
         If Not VerifConc Then DeshabForm(Me)
      End If
      '
      cTmp = ""
      If Not CrearTabla(Cn, cStruct, cTmp) Then
         DeshabForm(Me)
      End If
      '
      cTmpTr = ""
      If Not CrearTabla(Cn, cStrTR, cTmpTr) Then
         DeshabForm(Me)
      End If
      '
      ArmaComboItem(cboInquilino, "Inquilinos", , "Nombre", "Nombre", "(Todos)", "Codigo IN( SELECT DISTINCT Inquilino FROM LiqInqCab WHERE Estado = 3 OR (Estado <> " & EstANUL & " AND SaldoPend > 0)) OR Codigo IN( SELECT DISTINCT Inquilino FROM LiqInqCob)")
      '
      Trn = Cn.BeginTransaction
      With Cmd
         .Transaction = Trn
         .Connection = Cn
         .CommandText = "DELETE FROM ChReciboTmp WHERE Usuario = '" & Uid & "' AND PC = '" & NombrePC & "'"
         .ExecuteNonQuery()
      End With
      Trn.Commit()
      '
      Cm2.Connection = Cn
      '
      dtpFecha.Value = Today
      '
      formLoad = True
      '
      ActData()
      '
   End Sub
   '
   Private Sub frmLiqInqPend_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
      TabReturn(e.KeyChar, True)
   End Sub
   '
   Private Sub chkConfirmadas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkConfirmadas.CheckedChanged
      ActData()
   End Sub
   '
   Private Sub cboInquilino_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboInquilino.SelectedIndexChanged
      '
      With cboInquilino
         If .SelectedIndex > 0 Then
            Inquilino = .SelectedValue
            AgRetGan = CapturaDato(Cn, "Inquilinos", "AgRetGan", "Codigo = " & Inquilino)
         Else
            Inquilino = 0
         End If
      End With
      '
      cmdAgregar.Enabled = (Inquilino > 0)
      ActData()
      '
   End Sub
   '
   Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
      Cancelar()
   End Sub
   '
   Private Sub Cancelar()
      Trn = Cn.BeginTransaction
      With Cmd
         .Transaction = Trn
         .CommandText = "DELETE FROM " & cTmp
         .ExecuteNonQuery()
         .CommandText = "DELETE FROM ChReciboTmp WHERE Usuario = '" & Uid & "' AND PC = '" & NombrePC & "'"
         .ExecuteNonQuery()
      End With
      Trn.Commit()
      ActivaCtrl()
      txtEfectivo.Text = ""
      tbCheques.Text = ""
      txtRetencion.Text = ""
      txtTransf.Text = ""
      ActData()
   End Sub
   '
   Private Sub cmdAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAgregar.Click
      Agregar()
   End Sub
   '
   Private Sub Agregar()
      With DataGridView1
         If .RowCount > 0 Then
            '
            Tipo = .SelectedCells(.Columns("Tipo").Index).Value
            Sucursal = .SelectedCells(.Columns("Sucursal").Index).Value
            Numero = .SelectedCells(.Columns("Numero").Index).Value
            LiqInqId = .SelectedCells(.Columns("LiqInqId").Index).Value
            '
            Trn = Cn.BeginTransaction()
            Cmd.Transaction = Trn
            '
            Cmd.CommandText = "INSERT INTO " & cTmp & "( Tipo, Sucursal, Numero, LiqInqId) VALUES ('" & Tipo & "', " & Sucursal & ", " & Numero & ", " & LiqInqId & ")"
            Cmd.ExecuteNonQuery()
            '
            Cmd.CommandText = "INSERT INTO ChReciboTmp( DescBco, Banco, Cuenta, Numero, Titular, Fecha, Importe, Usuario, PC) " &
                              "SELECT B.Nombre, C.Banco, C.Cuenta, C.Numero, C.Titular, C.Fecha, C.Importe, '" & Uid & "', '" & NombrePC & "' " &
                              "FROM ChRecibo C, Bancos B " &
                              "WHERE C.RboTipo = '" & Tipo & "'" &
                              "  AND C.RboSucursal = " & Sucursal &
                              "  AND C.RboNumero = " & Numero &
                              "  AND C.Banco = B.Banco " &
                              "  AND NOT EXISTS( SELECT Numero FROM ChReciboTmp WHERE Numero = C.Numero )"
            Cmd.ExecuteNonQuery()
            '
            Trn.Commit()
            ActData()
         End If
      End With
   End Sub
   '
   Private Sub cmdQuitar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdQuitar.Click
      With DataGridView2
         If .RowCount > 0 Then
            Trn = Cn.BeginTransaction
            Cmd.Transaction = Trn
            Cmd.CommandText = "DELETE FROM " & cTmp & " WHERE Numero = " & .SelectedCells(.Columns("Numero").Index).Value
            Cmd.ExecuteNonQuery()
            Trn.Commit()
            ActData()
         End If
      End With
   End Sub
   '
   Private Sub cmdIngCheques_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIngCheques.Click
      Dim Frm As New frmLiqInquilinosCH
      With Frm
         .ShowDialog(Me)
         tbCheques.Text = Format(.Total, "Fixed")
         CalcImportes()
      End With
   End Sub
   '
   Private Sub dtpFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFecha.ValueChanged
      ActData()
   End Sub
   '
   Private Sub chkTodas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodas.CheckedChanged
      If chkTodas.Checked Then
         dtpFecha.Enabled = False
      Else
         dtpFecha.Enabled = True
      End If
      ActData()
   End Sub
   '
   Private Sub ActData()
      '
      If Not formLoad Then Exit Sub
      '
      Dim cSQL As String
      Dim cCols As String
      Dim cWhere1 As String
      Dim cWhere2 As String
      Dim cWhere3 As String
      Dim cRels As String
      '
      cCols = "C.Fecha, " &
              "C.Tipo, " &
              "C.Sucursal, " &
              "C.Numero, " &
              "right(C.Periodo,2) + '/' + left(C.Periodo,4) AS Per, " &
              "C.Inquilino, " &
              "I.Nombre, " &
              "C.LiqPropiet, " &
              "C.Detalle, " &
              "C.Estado, " &
              "E.Descrip as DescEst, " &
              "C.Total, " &
              "C.SaldoPend AS Saldo, " &
              "C.Efectivo, C.Retencion, C.Cheques, C.Bonos, C.ImporteTr, C.Intereses, C.ChReciboID, C.Usuario, C.LiqInqId "
      '
      cRels = "C.Inquilino = I.Codigo AND " &
              "C.Estado = E.Estado"
      '
      If Inquilino = 0 Then
         cWhere1 = ""
      Else
         cWhere1 = " AND C.Inquilino = " & Inquilino & " "
      End If
      '
      If chkTodas.Checked Then
         cWhere2 = ""
      Else
         cWhere2 = " AND " & IIf(chkConfirmadas.Checked, "L.LicFecha", "C.Fecha") & " = " & strFEC & Format(dtpFecha.Value, FormatFecha) & strFEC
      End If
      '
      If Not chkConfirmadas.Checked Then
         cWhere3 = " AND (C.Estado = " & EstPEND & " OR (C.Estado <> " & EstANUL & " AND (C.SaldoPend > 0.001 OR C.SaldoPend < -0.001))) "
      Else
         cWhere3 = " AND (C.Estado = " & EstCONF & ") "
      End If
      '
      If chkConfirmadas.Checked Then
         SetRegGrid(Me, DgvConf)
         'cSQL = "SELECT L.LicId, L.LicFecha AS Fecha, I.Nombre, L.LicEfectivo AS Efectivo, L.LicRetencion AS Retencion, L.LicTransferencia AS ImporteTr, L.LicCheques AS Cheques, L.LiqInqTrId, L.Inquilino, 1 AS Estado, L.LicSaldo AS Saldo, 'Confirmada' AS DescEst " &
         '       ", (SELECT MAX(C.LiqPropiet) FROM LiqInqCobDet D, LiqInqCab C WHERE D.LicId = L.LicId AND D.LiqInqId = C.LiqInqID) AS LiqPropiet " &
         '       "FROM LiqInqCob L, Inquilinos I " &
         '       "WHERE L.Inquilino = I.Codigo " & cWhere1 & cWhere2 &
         '       "ORDER BY L.LicFecha DESC"
         '
         cSQL = "SELECT L.LicId, C.Fecha, L.LicFecha As FecCobro, C.Numero, I.Nombre, L.LicEfectivo As Efectivo, L.LicRetencion As Retencion, " &
                " L.LicTransferencia AS ImporteTr, L.LicCheques As Cheques, " &
                " L.LiqInqTrId, L.Inquilino, C.Estado, L.LicSaldo As Saldo, E.Descrip As DescEst, D.LiqPropiet " &
                "FROM LiqInqCob L, LiqInqCobDet D, LiqInqCab C, Inquilinos I, EstLiquid E " &
                "WHERE L.LicId = D.LicId " &
                "  AND D.LiqInqId = C.LiqInqID " &
                "  AND L.Inquilino = I.Codigo " &
                "  AND C.Estado = E.Estado" &
                cWhere1 & cWhere2 & cWhere3 &
                "ORDER BY L.LicFecha DESC, L.LicId DESC"
         '
         LlenarGrid(DgvConf, cSQL)
         DgvConf.Visible = True
         DataGridView1.Visible = False
         SetCols3()
         GetRegGrid(Me, DgvConf)
      Else
         SetRegGrid(Me, DataGridView1)
         cSQL = "SELECT " & cCols &
                "FROM LiqInqCab C, Inquilinos I, EstLiquid E " &
                "WHERE C.Numero NOT IN( SELECT Numero FROM " & cTmp & ") " &
                " AND " & cRels & cWhere1 & cWhere2 & cWhere3 &
                "ORDER BY C.Fecha, C.Tipo, C.Sucursal, C.Numero"
         LlenarGrid(DataGridView1, cSQL)
         DataGridView1.Visible = True
         DgvConf.Visible = False
         SetCols1()
         GetRegGrid(Me, DataGridView1)
      End If
      '
      'SetRegGrid(Me, DataGridView2)
      ActData2()
      'SetCols2()
      'GetRegGrid(Me, DataGridView2)
      '
      With DataGridView2
         CantLiq = .RowCount
         cmdQuitar.Enabled = .RowCount > 0
         cmdConfirmar.Enabled = .RowCount = 0
      End With
      '
      txtEfectivo.Text = Format(Val(CapturaDato(Cn, "LiqInqCab", "SUM(ISNULL(Efectivo, 0))",
                                    "EXISTS( SELECT Numero FROM " & cTmp & " " &
                                    "        WHERE Tipo = LiqInqCab.Tipo " &
                                    "          AND Sucursal = LiqInqCab.Sucursal " &
                                    "          AND Numero = LiqInqCab.Numero)") & ""), "Fixed")
      tbCheques.Text = Format(Val(CapturaDato(Cn, "LiqInqCab", "SUM(Cheques)",
                                    "EXISTS( SELECT Numero FROM " & cTmp & " " &
                                    "        WHERE Tipo = LiqInqCab.Tipo " &
                                    "          AND Sucursal = LiqInqCab.Sucursal " &
                                    "          AND Numero = LiqInqCab.Numero )") & ""), "Fixed")
      txtRetencion.Text = Format(Val(CapturaDato(Cn, "LiqInqCab", "SUM(Retencion)",
                                    "EXISTS( SELECT Numero FROM " & cTmp & " " &
                                    "        WHERE Tipo = LiqInqCab.Tipo " &
                                    "          AND Sucursal = LiqInqCab.Sucursal " &
                                    "          AND Numero = LiqInqCab.Numero )") & ""), "Fixed")
      txtTransf.Text = Format(Val(CapturaDato(Cn, "LiqInqCab", "SUM(ImporteTr)",
                                    "EXISTS( SELECT Numero FROM " & cTmp & " " &
                                    "        WHERE Tipo = LiqInqCab.Tipo " &
                                    "          AND Sucursal = LiqInqCab.Sucursal " &
                                    "          AND Numero = LiqInqCab.Numero )") & ""), "Fixed")
      txtTotal.Text = Format(Val(CapturaDato(Cn, "LiqInqCab", "SUM(Total)",
                                    "EXISTS( SELECT Numero FROM " & cTmp & " " &
                                    "        WHERE Tipo = LiqInqCab.Tipo " &
                                    "          AND Sucursal = LiqInqCab.Sucursal " &
                                    "          AND Numero = LiqInqCab.Numero )") & ""), "Fixed")
      txtSaldoPend.Text = Format(Val(CapturaDato(Cn, "LiqInqCab", "SUM(SaldoPend)",
                                    "EXISTS( SELECT Numero FROM " & cTmp & " " &
                                    "        WHERE Tipo = LiqInqCab.Tipo " &
                                    "          AND Sucursal = LiqInqCab.Sucursal " &
                                    "          AND Numero = LiqInqCab.Numero )") & ""), "Fixed")
      '
      If Math.Round(Val(txtSaldoPend.Text), 2) < Math.Round(Val(txtTotal.Text), 2) Then
         If Math.Round(Val(txtEfectivo.Text), 2) > Math.Round(Val(txtSaldoPend.Text), 2) Then
            txtEfectivo.Text = txtSaldoPend.Text
         End If
         'txtEfectivo.Text = ""
         'tbCheques.Text = ""
         'txtRetencion.Text = ""
         'txtTransf.Text = ""
      End If
      '
      cmdConfirmar.Enabled = False
      cmdAnular.Enabled = False
      '
      ActivaCtrl()
      '
   End Sub
   '
   Private Sub SetCols1()
      '
      For Each Col As DataGridViewColumn In DataGridView1.Columns
         With Col
            Select Case .Name
               Case "Fecha" : .Width = 100
               Case "Tipo" : .Width = 40
               Case "Sucursal" : .Width = 50 : .HeaderText = "Suc."
               Case "Numero" : .Width = 75 : .HeaderText = "Rbo.Nº"
               Case "Per" : .HeaderText = "Período" : .Width = 100
               Case "Nombre" : .Width = 250 : .HeaderText = "Inquilino"
               Case "Detalle" : .Width = 225
               Case "DescEst" : .HeaderText = "Estado" : .Width = 100
               Case "Total" : .DefaultCellStyle.Format = "#,##0.00 " : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .Width = 100
               Case "Saldo" : .DefaultCellStyle.Format = "#,##0.00 " : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .Width = 100
               Case "Efectivo" : .DefaultCellStyle.Format = "#,##0.00 " : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .Width = 100
               Case "Retencion" : .DefaultCellStyle.Format = "#,##0.00 " : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .Width = 100
               Case "Cheques" : .DefaultCellStyle.Format = "#,##0.00 " : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .Width = 100
               Case "ImporteTr" : .HeaderText = "Transf." : .DefaultCellStyle.Format = "#,##0.00 " : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .Width = 100
               Case "LiqPropiet" : .Width = 75 : .HeaderText = "Liq.Prop."
               Case "Usuario"
               Case Else : .Visible = False
            End Select
         End With
      Next Col
      '
   End Sub
   '
   Private Sub SetCols2()
      For Each Col As DataGridViewColumn In DataGridView2.Columns
         With Col
            Select Case .Name
               Case "Fecha" : .Width = 100
               Case "Tipo" : .Width = 40
               Case "Sucursal" : .Width = 50 : .HeaderText = "Suc."
               Case "Numero" : .Width = 75 : .HeaderText = "Rbo.Nº"
               Case "Per" : .HeaderText = "Período" : .Width = 100
               Case "Nombre" : .Width = 250 : .HeaderText = "Inquilino"
               Case "Detalle" : .Width = 225
               Case "DescEst" : .HeaderText = "Estado" : .Width = 100
               Case "Total" : .DefaultCellStyle.Format = "#,##0.00 " : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .Width = 100
               Case "Saldo" : .DefaultCellStyle.Format = "#,##0.00 " : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .Width = 100
               Case "SaldoAct" : .HeaderText = "Saldo Act." : .DefaultCellStyle.Format = "#,##0.00 " : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .Width = 100
               Case "SaldoLiq" : .HeaderText = "Saldo Liq." : .DefaultCellStyle.Format = "#,##0.00 " : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .Width = 100
               Case "Efectivo" : .DefaultCellStyle.Format = "#,##0.00 " : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .Width = 100
               Case "Cheques" : .DefaultCellStyle.Format = "#,##0.00 " : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .Width = 100
               Case "ImporteTr" : .HeaderText = "Transf." : .DefaultCellStyle.Format = "#,##0.00 " : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .Width = 100
               Case "Retencion" : .HeaderText = "Ret." : .DefaultCellStyle.Format = "#,##0.00 " : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .Width = 100
               Case "ImpPago" : .HeaderText = "Imp.Pago" : .DefaultCellStyle.Format = "#,##0.00 " : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .Width = 100
               Case "LiqPropiet" : .Width = 75 : .HeaderText = "Liq.Prop."
               Case "Usuario"
               Case Else : .Visible = False
            End Select
         End With
      Next Col
      '
   End Sub
   '
   Private Sub SetCols3()
      '
      For Each Col As DataGridViewColumn In DgvConf.Columns
         With Col
            Select Case .Name
               Case "LicId" : .Width = 100 : .HeaderText = "Liq.Nº"
               Case "Fecha" : .Width = 100
               Case "Numero" : .Width = 100 : .HeaderText = "Rbo. Nº"
               Case "FecCobro" : .Width = 100 : .HeaderText = "Fec.Cobro"
               Case "Per" : .HeaderText = "Período" : .Width = 100
               Case "Nombre" : .Width = 250 : .HeaderText = "Inquilino"
               Case "Detalle" : .Width = 225
               Case "DescEst" : .HeaderText = "Estado" : .Width = 100
               Case "Total" : .DefaultCellStyle.Format = "#,##0.00 " : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .Width = 100
               Case "Saldo" : .DefaultCellStyle.Format = "#,##0.00 " : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .Width = 100
               Case "Efectivo" : .DefaultCellStyle.Format = "#,##0.00 " : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .Width = 100
               Case "Retencion" : .DefaultCellStyle.Format = "#,##0.00 " : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .Width = 100
               Case "Cheques" : .DefaultCellStyle.Format = "#,##0.00 " : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .Width = 100
               Case "ImporteTr" : .HeaderText = "Transf." : .DefaultCellStyle.Format = "#,##0.00 " : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .Width = 100
               Case "LiqPropiet" : .Width = 75 : .HeaderText = "Liq.Prop."
               Case "Usuario"
               Case Else : .Visible = False
            End Select
         End With
      Next Col
      '
   End Sub
   '
   Private Sub cmdImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImprimir.Click
      If chkConfirmadas.Checked Then
         With Me.DgvConf
            ImprimirCrp("LiqInqConf", IIf(prmVistPrevLiq, crptToWindow, crptToPrinter), "{LiqInqCob.LicId} = " & .SelectedCells(.Columns("LicId").Index).Value, Me.Text)
         End With
      Else
         With DataGridView1
            If .RowCount > 0 Then
               GenRepLiqInq(.SelectedCells(.Columns("Tipo").Index).Value, .SelectedCells(.Columns("Sucursal").Index).Value, .SelectedCells(.Columns("Numero").Index).Value, "Recibo. Inq. Pendiente", IIf(prmVistPrevLiq, crptToWindow, crptToPrinter))
            End If
         End With
      End If
   End Sub
   '

   Private Sub cmdListado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdListado.Click
      '
      Dim Filtro As String = ""
      '
      If Inquilino <> 0 Then
         Filtro = "{LiqInqCab.Inquilino} = " & Inquilino & " "
      End If
      '
      If chkTodas.Checked = False Then
         Filtro = IIf(Filtro = "", "", Filtro & " AND ") & "{LiqInqCab.Fecha} = CDATE('" & Format(dtpFecha.Value, FormatCDATE) & "')"
      End If
      '
      If chkConfirmadas.Checked = False Then
         Filtro = IIf(Filtro = "", "", Filtro & " AND ") & "({LiqInqCab.Estado} = " & EstPEND & " OR ({LiqInqCab.Estado} <> " & EstANUL & " AND {LiqInqCab.SaldoPend} > 0.001)) "
      Else
         Filtro = IIf(Filtro = "", "", Filtro & " AND ") & " AND ({LiqInqCab.Estado} = " & EstCONF & ") "
      End If
      '
      ImprimirCrp("LiqInqPend", IIf(prmVistPrevLiq, crptToWindow, crptToPrinter), Filtro, Me.Text)
      '
   End Sub
   '
   Private Sub DataGridView1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyUp, DgvConf.KeyUp
      ActData2()
      ActivaCtrl()
   End Sub
   '
   Private Sub DataGridView1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridView1.MouseClick, DgvConf.MouseClick
      ActData2()
      ActivaCtrl()
   End Sub
   '
   Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick, DgvConf.CellContentClick
      ActData2()
      ActivaCtrl()
   End Sub
   '
   Private Sub ActData2()
      '
      Dim cSql As String
      Dim LicId As Int32 = 0
      '
      If chkConfirmadas.Checked Then
         With DgvConf
            If .RowCount > 0 Then
               LicId = .SelectedCells(.Columns("LicId").Index).Value
            End If
         End With
         cSql = "SELECT L.Tipo, L.Sucursal, L.Numero, L.Fecha, RIGHT(L.Periodo,2) + '/' + LEFT(L.Periodo,4) AS Per, I.Nombre, L.Total, L.SaldoPend AS SaldoAct, D.LcdImpPago AS ImpPago, L.Total-D.LcdImpPago AS SaldoLiq, L.Intereses, L.Efectivo, L.Cheques, L.ImporteTr, L.Retencion, L.ChReciboID, L.Inquilino, L.LiqInqTrID, L.LiqInqId, D.LiqPropiet " &
                "FROM LiqInqCab L, LiqInqCobDet D, Inquilinos I " &
                "WHERE L.LiqInqId = D.LiqInqId " &
                "  AND D.LicId = " & LicId & " " &
                "  AND L.Inquilino = I.Codigo " &
                "ORDER BY L.Tipo, L.Sucursal, L.Numero"
      Else
         cSql = "SELECT L.Tipo, L.Sucursal, L.Numero, L.Fecha, RIGHT(L.Periodo,2) + '/' + LEFT(L.Periodo,4) AS Per, I.Nombre, L.Total, L.SaldoPend AS Saldo, L.Intereses, L.Efectivo, L.Cheques, L.ImporteTr, L.Retencion, L.ChReciboID, L.Inquilino, LiqInqTrID, L.LiqInqId, LiqPropiet " &
                "FROM LiqInqCab L, " & cTmp & " T, Inquilinos I " &
                "WHERE T.Numero = L.Numero " &
                "  AND L.Inquilino = I.Codigo " &
                "ORDER BY L.Tipo, L.Sucursal, L.Numero"
      End If
      '
      SetRegGrid(Me, DataGridView2)
      LlenarGrid(DataGridView2, cSql)
      SetCols2()
      GetRegGrid(Me, DataGridView2)
      '
   End Sub
   '
   Private Sub cmdConfirmar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConfirmar.Click
      '
      Dim Periodo As String
      Dim Estado As Byte
      Dim Saldo As Double
      '
      With DataGridView1
         TotalLiq = Math.Round(.SelectedCells(.Columns("Efectivo").Index).Value + .SelectedCells(.Columns("Cheques").Index).Value + .SelectedCells(.Columns("Retencion").Index).Value + .SelectedCells(.Columns("ImporteTr").Index).Value, 2)
         Tipo = .SelectedCells(.Columns("Tipo").Index).Value
         Sucursal = .SelectedCells(.Columns("Sucursal").Index).Value
         Numero = .SelectedCells(.Columns("Numero").Index).Value
         'NombreInq = .SelectedCells(.Columns("Nombre").Index).Value
         Periodo = .SelectedCells(.Columns("Per").Index).Value
         cCtaInq = IIf(cfgCtaInqUnica, cfgCtaMadreInq, CapturaDato(Cn, "Inquilinos", "Cuenta", "Codigo = " & .SelectedCells(.Columns("Inquilino").Index).Value))
         Estado = .SelectedCells(.Columns("Estado").Index).Value
         Saldo = .SelectedCells(.Columns("Saldo").Index).Value
         AgRetGan = CapturaDato(Cn, "Inquilinos", "AgRetGan", "Codigo = " & .SelectedCells(.Columns("Inquilino").Index).Value)
      End With
      '
      With Cmd
         .CommandText = "DELETE FROM LiqAux WHERE Usuario = '" & Uid & "'"
         .ExecuteNonQuery()
         .CommandText = "INSERT INTO LiqAux( Usuario, Recibe, SonPesos, Periodo) " &
                        "VALUES('" & Uid & "', '" & cfgNomEmp & "', '" & Numero_a_Texto(TotalLiq) & "', '" & Periodo & "')"
         .ExecuteNonQuery()
      End With
      '
      If Estado <> EstPEND And Saldo = 0 Then
         MensajeTrad("LiqNoPend")
      Else
         '
         With Cmd
            .CommandText = "DELETE FROM ChReciboTmp WHERE Usuario = '" & Uid & "' AND PC = '" & NombrePC & "'"
            .ExecuteNonQuery()
            .CommandText = "INSERT INTO ChReciboTmp( DescBco, Banco, Cuenta, Numero, Titular, Fecha, Importe, Usuario, PC) " &
                           "SELECT B.Nombre, C.Banco, C.Cuenta, C.Numero, C.Titular, C.Fecha, C.Importe, '" & Uid & "', '" & NombrePC & "' " &
                           "FROM ChRecibo C, Bancos B " &
                           "WHERE C.RboTipo = '" & Tipo & "'" &
                           "  AND C.RboSucursal = " & Sucursal &
                           "  AND C.RboNumero = " & Numero &
                           "  AND C.Banco = B.Banco"
            .ExecuteNonQuery()
         End With
         '
         Agregar()
         '
      End If
      '
   End Sub
   '
   Private Sub ActivaCtrl()
      '
      Dim HayLiq As Boolean = False
      Dim Estado As Byte = 0
      Dim Saldo As Double = 0
      Dim Agregado As Boolean = False
      Dim LiqPropiet As Int32 = 0
      '
      If Me.chkConfirmadas.Checked Then
         With Me.DgvConf
            If .RowCount > 0 Then
               Estado = .SelectedCells(.Columns("Estado").Index).Value
               Saldo = 0
               LiqPropiet = .SelectedCells(.Columns("LiqPropiet").Index).Value
               HayLiq = True
            End If
         End With
      Else
         With DataGridView1
            If .RowCount > 0 Then
               Estado = .SelectedCells(.Columns("Estado").Index).Value
               Saldo = .SelectedCells(.Columns("Saldo").Index).Value
               LiqPropiet = .SelectedCells(.Columns("LiqPropiet").Index).Value
               HayLiq = True
            End If
         End With
      End If
      '
      Agregado = (DataGridView2.RowCount > 0 And Not chkConfirmadas.Checked)
      '
      cboInquilino.Enabled = Not Agregado
      DataGridView1.Enabled = Not Agregado Or Inquilino <> 0
      '
      cmdAgregar.Enabled = (Estado = EstPEND Or Saldo <> 0) And Inquilino <> 0
      cmdQuitar.Enabled = Agregado
      cmdConfirmar.Enabled = ((Estado = EstPEND Or Saldo <> 0) And Not Agregado)
      cmdAnular.Enabled = ((Estado = EstPEND Or Estado = EstCONF) And Not Agregado) And LGR
      cmdGenerar.Enabled = Agregado
      cmdCancelar.Enabled = Agregado
      cmdImprimir.Enabled = HayLiq
      btnLiqProp.Enabled = LiqPropiet > 0
      cmdIngCheques.Enabled = Agregado
      txtEfectivo.Enabled = Agregado
      'txtRetencion.Enabled = Agregado
      btnRetencion.Enabled = Agregado And AgRetGan
      cmdTransferencia.Enabled = Agregado
      '
   End Sub
   '
   Private Sub cmdAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAnular.Click
      '
      With IIf(Me.chkConfirmadas.Checked, Me.DgvConf, DataGridView1)
         '
         If .RowCount > 0 Then
            '
            If .SelectedCells(.Columns("Estado").Index).Value = EstANUL Then
               MensajeTrad("LiqYaAnulada")
            Else
               '
               Dim LicId As Int32
               Dim LiqPropiet As Int32
               LiqPropiet = .SelectedCells(.Columns("LiqPropiet").Index).Value ' CapturaDato(Cn, "LiqInqCob", "LiqPropiet", "LicId = " & LicId)
               '
               If chkConfirmadas.Checked Then
                  If LiqPropiet > 0 Then
                     MensajeTrad("LiqRendAProp")
                  Else
                     LicId = .SelectedCells(.Columns("LicId").Index).Value
                     If ChsEnCartera(LicId) Then
                        If MsgBox(Traducir("AnulaLiqConf"), vbQuestion + vbYesNo) = vbYes Then
                           AnulaLiqConf(LicId)
                           ActData()
                        End If
                     End If
                  End If
                  '
               Else
                  If LiqPropiet > 0 Then
                     '
                     MensajeTrad("LiqRendAProp")
                     '
                  Else
                     '
                     Tipo = .SelectedCells(.Columns("Tipo").Index).Value
                     Sucursal = .SelectedCells(.Columns("Sucursal").Index).Value
                     Numero = .SelectedCells(.Columns("Numero").Index).Value
                     '
                     If MsgBox(Traducir("AnulaLiquid") & " " & Tipo & "-" & Sucursal & "-" & Numero,
                               vbQuestion + vbYesNo) = vbYes Then
                        AnulaLiqInq(Tipo, Sucursal, Numero)
                        ActData()
                     End If
                  End If
               End If
            End If
         End If
      End With
   End Sub
   '
   Private Function ChsEnCartera(LicId As Int32) As Boolean
      Dim Nro As String
      Nro = CapturaDato(Cn, "ChCartera", "ChCartNro", "Estado > 0 AND CHCartId IN( SELECT ChCarteraId FROM LiqInqCobCh WHERE LicId = " & LicId & ")") & ""
      If Nro = "" Then
         Return True
      Else
         Mensaje("Cheque Nro. " & Nro & ", no se encuentra en Cartera")
         Return False
      End If
   End Function
   '
   Private Sub AnulaLiqConf(ByVal LicId As Int32)
      '
      Dim LiqInqTrID As Int32
      Dim Comprob As String
      Dim Numeros As String = ""
      Dim TipoTR As String
      Dim i, n As Int16
      'Dim EstLiqInq As Byte
      '
      Comprob = cmpInt & "-P-" & Sucursal & "-" & LicId
      TipoTR = Val(CapturaDato(Cn, "TipoMovBco", "TipoMovBco", "TipoMov = 'TR'", , , , Trn) & "")
      '
      Try
         Trn = Cn.BeginTransaction
         '
         Cmd.Transaction = Trn
         Cm2.Transaction = Trn
         '
         With Cmd
            '
            .CommandText = "SELECT * FROM LiqInqCobDet WHERE LicId = " & LicId
            Drd = .ExecuteReader
            With Drd
               Do While .Read
                  '
                  Cm2.CommandText = "UPDATE LiqInqCab SET " &
                                    " SaldoPend = SaldoPend + " & !LcdImpPago & " " &
                                    "WHERE LiqInqId = " & !LiqInqId
                  Cm2.ExecuteNonQuery()
                  '
                  Cm2.CommandText = "UPDATE LiqInqCab SET " &
                                    " Estado = 3 " &
                                    "WHERE LiqInqId = " & !LiqInqId &
                                    "  AND SaldoPend = Total"
                  Cm2.ExecuteNonQuery()
                  '
                  Cm2.CommandText = "DELETE FROM ChReciboDesc WHERE EXISTS( SELECT * FROM LiqInqCab WHERE Tipo = ChReciboDesc.Tipo AND Sucursal = ChReciboDesc.Sucursal AND Numero = ChReciboDesc.Numero AND LiqInqId = " & !LiqInqId & ")"
                  Cm2.ExecuteNonQuery()
                  ''
                  'Cm2.CommandText = "DELETE FROM LiqInqPPar WHERE LiqInqId = " & !LiqInqId
                  'Cm2.ExecuteNonQuery()
                  '
                  Numeros = IIf(Numeros = "", "", Numeros & "-") & CapturaDato(Cn, "LiqInqCab", "Numero", "LiqInqId = " & !LiqInqId, , , , Trn)
                  '
               Loop
               .Close()
            End With
            '
            .CommandText = "SELECT ChCarteraId FROM LiqInqCobCh WHERE LicId = " & LicId
            Drd = .ExecuteReader
            n = Drd.FieldCount
            '
            Dim ChCarteraId(n) As Int32
            i = 0
            '
            With Drd
               While .Read
                  ChCarteraId(i) = .Item("ChCarteraId")
                  i += 1
               End While
               .Close()
            End With
            '
            For i = 1 To n
               If Not BajaCaja(Comprob & "/" & i, , Trn) Then
                  Err.Raise(1001)
               End If
            Next i
            '
            LiqInqTrID = Val(CapturaDato(Cn, "LiqInqCob", "LiqInqTrID", "LicId = " & LicId, , , , Trn) & "")
            '
            .CommandText = "Select * FROM LiqInqTr WHERE LiqInqTrID = " & LiqInqTrID
            Drd = .ExecuteReader
            With Drd
               If .Read Then
                  Cm2.CommandText = "DELETE FROM BancosMov WHERE Banco = " & !Banco1 & " And BancoCta = '" & !Cuenta1 & "' AND TipoMovBco = " & TipoTR & " AND NroMovBco = " & !NumeroTR
                  Cm2.ExecuteNonQuery()
               End If
               .Close()
            End With
            '
            .CommandText = "DELETE FROM LiqInqTR WHERE LiqInqTrID = " & LiqInqTrID
            Cmd.ExecuteNonQuery()
            '
            .CommandText = "DELETE FROM LiqInqCobDet WHERE LicId = " & LicId
            .ExecuteNonQuery()
            '
            .CommandText = "DELETE FROM LiqInqCobCh WHERE LicId = " & LicId
            .ExecuteNonQuery()
            '
            .CommandText = "DELETE FROM LiqInqCob WHERE LicId = " & LicId
            .ExecuteNonQuery()
            '
            For i = 0 To n - 1
               .CommandText = "DELETE FROM ChCartera WHERE ChCartId = " & ChCarteraId(i)
               .ExecuteNonQuery()
            Next i
            '
            .CommandText = "DELETE FROM LiqAux WHERE Usuario = '" & Uid & "' AND LqxPC = '" & NombrePC & "'"
            .ExecuteNonQuery()
            '
         End With
         '
         If SisContable Then
            If Not BorraAsiento(Comprob, Trn) Then
               Err.Raise(1001)
            End If
         End If
         '
         If Not BajaCaja(Comprob, , Trn) Then
            Err.Raise(1001)
         End If
         '
         GuardarAudit("Anula Liq. Inq. Confirmada", NombreInq & " - Nº " & LicId, Me.Name, "AnulaLiqConf", Trn)
         '
         Trn.Commit()
         '
      Catch ex As System.Exception
         Dim st As New StackTrace(True)
         RegistrarError(st, "AnulaLiqConf")
         Trn.Rollback()
      End Try
      '
   End Sub
   '
   Private Sub CmdGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGenerar.Click
      '
      Dim Drd As OleDb.OleDbDataReader
      '
      Dim LicId As Long
      Dim nInq As Long
      Dim Numeros As String = ""
      Dim DetChs As String = ""
      Dim Periodo As String
      Dim cComprob As String = ""
      Dim cDetCaja As String
      Dim NroAsi As Long
      Dim RenASi As Integer
      Dim DetAsi As String
      Dim Efectivo, Retencion, Transferencia, Cheques, LcdRetencion As Double
      Dim nImpCaja As Double   'Ver a que corresponde.
      Dim nTotPago As Double
      Dim nIntereses As Double
      Dim TotalLiq As Double
      Dim LiqInqTrID As Long
      Dim nBanco As Integer
      Dim cCuenta As String
      Dim cCtaBanco As String
      Dim SaldoPend As Double
      Dim SaldoPago As Double
      Dim cNumero As String
      Dim nTipo As Integer
      Dim i As Int16
      Dim chCant As Byte
      '
      If Val(txtTotal.Text) = 0 Then
         MensajeTrad("Total=0")
         Exit Sub
      End If
      '
      aCuenta = False
      SaldoPend = 0
      nTotPago = Val(txtEfectivo.Text) + Val(tbCheques.Text) + Val(txtRetencion.Text) + Val(txtTransf.Text)
      If nTotPago <= 0 Then
         MensajeTrad("TotPago<=0")
         Exit Sub
      End If
      '
      If Val(txtTransf.Text) > 0 Then
         If CapturaDato(Cn, cTmpTr, "COUNT(1)", "") = 0 Then
            MensajeTrad("Faltan datos de la transferencia")
            Exit Sub
         End If
      End If
      '
      If Format(nTotPago, "Fixed") <> Format(txtSaldoPend.Text, "Fixed") Then
         If Val(Format(nTotPago, "Fixed")) < Val(Format(txtSaldoPend.Text, "Fixed")) Then   'And CantLiq = 1 Then
            If MsgConfirma("Genera Pago Parcial") Then
               aCuenta = True
               SaldoPend = Val(txtSaldoPend.Text) - nTotPago
            Else
               Exit Sub
            End If
         Else
            If MsgConfirma("Genera Pago a Cuenta") Then
               aCuenta = True
               SaldoPend = Val(txtSaldoPend.Text) - nTotPago
            Else
               Exit Sub
            End If
         End If
      End If
      '
      Try
         '
         Trn = Cn.BeginTransaction
         '
         Cmd.Transaction = Trn
         Cm2.Transaction = Trn
         '
         With DataGridView2
            If .RowCount > 0 Then
               For i = 0 To .RowCount - 1
                  If i = 0 Then
                     nInq = .Item("Inquilino", i).Value
                     cCtaInq = IIf(cfgCtaInqUnica, cfgCtaMadreInq, CapturaDato(Cn, "Inquilinos", "Cuenta", "Codigo = " & .Item("Inquilino", i).Value, , , , Trn))
                     NombreInq = CapturaDato(Cn, "Inquilinos", "Nombre", "Codigo = " & .Item("Inquilino", i).Value, , , , Trn)
                  End If
                  nIntereses = nIntereses + .Item("Intereses", i).Value
                  Numeros = IIf(Numeros = "", "", Numeros & "-") & .Item("Numero", i).Value
                  '
               Next i
            End If
         End With
         '
         Efectivo = Val(txtEfectivo.Text)
         Retencion = Val(txtRetencion.Text)
         Transferencia = Val(txtTransf.Text)
         Cheques = Val(tbCheques.Text)
         '
         TotalLiq = CapturaDato(Cn, "LiqInqCab", "SUM(SaldoPend)",
                                    "EXISTS( SELECT Numero FROM " & cTmp & " " &
                                    "        WHERE Tipo = LiqInqCab.Tipo " &
                                    "          AND Sucursal = LiqInqCab.Sucursal " &
                                    "          AND Numero = LiqInqCab.Numero )", , , , Trn)
         '
         SaldoPago = nTotPago
         '
         With Cmd
            .CommandText = "INSERT INTO LiqInqCob( LicFecha, Inquilino, LicEfectivo, LicRetencion, LicTransferencia, LicCheques, LicSaldo, LicUid, LicFecMod) " &
                           "VALUES('" & Format(Today, FormatFecha) & "', " &
                                        nInq & ", " &
                                        Efectivo & ", " &
                                        Retencion & ", " &
                                        Transferencia & ", " &
                                        Cheques & ", " &
                                        SaldoPend & ", " &
                                  "'" & Uid & "', " &
                                  "'" & Format(Now, FormatFechaHora) & "')"
            .ExecuteNonQuery()
            LicId = CapturaDato(Cn, "LiqInqCob", "MAX(LicId)", "", , , , Trn)
            cComprob = cmpInt & "-P-" & Sucursal & "-" & LicId
            cDetCaja = Mid(Traducir("ConfRboPend", , Trn) & " (" & LicId & ") Rbo/s: " & Numeros, 1, 250)
            DetAsi = cDetCaja
         End With
         '
         With DataGridView2
            If .RowCount > 0 Then
               For i = 0 To .RowCount - 1
                  '
                  LiqInqId = .Item("LiqInqId", i).Value
                  LcdRetencion = CapturaDato(Cn, cTmp, "Retencion", "LiqInqId = " & LiqInqId,,,, Trn)
                  '
                  If .Item("Saldo", i).Value <= SaldoPago Then
                     '
                     SaldoPago = SaldoPago - .Item("Saldo", i).Value
                     '
                     Cm2.CommandText = "INSERT INTO LiqInqCobDet( LicId, LiqInqId, LcdImpPago, LcdSaldo, LcdRetencion, LcdUid, LcdFecMod) " &
                                       "VALUES(" & LicId & ", " &
                                                   LiqInqId & ", " &
                                                   .Item("Saldo", i).Value & ", " &
                                                   0 & ", " &
                                                   LcdRetencion & ", " &
                                             "'" & Uid & "', " &
                                             "'" & Format(Now, FormatFechaHora) & "')"
                     Cm2.ExecuteNonQuery()
                     '
                     Cm2.CommandText = "UPDATE LiqInqCab SET " &
                                       " SaldoPend = " & IIf(i = .RowCount - 1, Math.Round(-SaldoPago, 2), 0) & ", " &
                                       " Estado = 1 " &
                                       "WHERE LiqInqId = " & LiqInqId
                     Cm2.ExecuteNonQuery()
                     '
                  Else
                     '
                     SaldoPend = CapturaDato(Cn, "LiqInqCab", "SaldoPend", "LiqInqId = " & LiqInqId, , , , Trn) - SaldoPago
                     '
                     Cm2.CommandText = "INSERT INTO LiqInqCobDet( LicId, LiqInqId, LcdImpPago, LcdSaldo, LcdRetencion, LcdUid, LcdFecMod) " &
                                       "VALUES(" & LicId & ", " &
                                                   LiqInqId & ", " &
                                                   SaldoPago & ", " &
                                                   SaldoPend & ", " &
                                                   LcdRetencion & ", " &
                                             "'" & Uid & "', " &
                                             "'" & Format(Now, FormatFechaHora) & "')"
                     Cm2.ExecuteNonQuery()
                     '
                     Cm2.CommandText = "UPDATE LiqInqCab SET " &
                                       " SaldoPend = " & SaldoPend & ", " &
                                       " Estado = 1 " &
                                       "WHERE LiqInqId = " & LiqInqId
                     Cm2.ExecuteNonQuery()
                     '
                     SaldoPago = 0
                  End If
                  '
               Next i
               '
            End If
         End With
         '
         'Cmd.CommandText = "UPDATE LiqInqCobDet SET LcdRetencion = (SELECT Retencion FROM " & cTmp & " WHERE LiqInqId = LiqInqCobDet.LiqInqId) WHERE LicId = " & LicId
         'Cmd.ExecuteNonQuery()
         '
         If Val(tbCheques.Text) > 0 Then
            '
            With Cmd
               .CommandText = "INSERT INTO ChCartera( Banco, BancoCta, ChCartNro, Titular, FechaEmi, FechaDif, Entrego, Importe, CajaAdm, Caja, Estado, Comprob, Usuario, FechaMod) " &
                              "SELECT Banco, Cuenta, Numero, Titular, Fecha, Fecha, '" & NombreInq & "', Importe, 1, " & prmNroCaja & ", 0, 'LI-" & LicId & "', '" & Uid & "', '" & Format(Now, FormatFechaHora) & "' " &
                              "FROM ChReciboTmp WHERE Usuario = '" & Uid & "' AND PC = '" & NombrePC & "'"
               .ExecuteNonQuery()
               '
               .CommandText = "INSERT INTO LiqInqCobCh( LicId, ChCarteraId, LicUid, LicFecMod) " &
                              "SELECT " & LicId & ", C.ChCartId, '" & Uid & "', '" & Format(Now, FormatFechaHora) & "' " &
                              "FROM ChCartera C, ChReciboTmp T " &
                              "WHERE C.Banco = T.Banco AND C.BancoCta = T.Cuenta AND C.ChCartNro = T.Numero AND T.Usuario = '" & Uid & "' AND T.PC = '" & NombrePC & "'"
               .ExecuteNonQuery()
               '
               .CommandText = "SELECT T.*, B.Nombre FROM ChReciboTmp T, Bancos B WHERE T.Banco = B.Banco AND T.Usuario = '" & Uid & "' AND T.PC = '" & NombrePC & "'"
               Drd = .ExecuteReader
               '
            End With
            '
            With Drd
               While .Read
                  DetChs = DetChs & !Nombre & " N°" & !Numero & " $" & !Importe & " Fecha: " & !Fecha & ".-   "
               End While
               .Close()
               '
               '.CommandText = "SELECT * FROM ChReciboTmp WHERE Usuario = '" & Uid & "' AND PC = '" & NombrePC & "'"
               'Drd = .ExecuteReader
               'With Drd
               '   While .Read
               '      '
               '      Cm2.CommandText = "INSERT INTO ChCartera( Banco, BancoCta, ChCartNro, Titular, FechaEmi, FechaDif, Entrego, Importe, CajaAdm, Caja, Estado, Usuario, FechaMod) " &
               '                        "VALUES(" & !Banco & ", " &
               '                              "'" & !Cuenta & "', " &
               '                              "'" & !Numero & "', " &
               '                              "'" & !Titular & "', " &
               '                              "'" & Format(!Fecha, FormatFecha) & "', " &
               '                              "'" & Format(!Fecha, FormatFecha) & "', " &
               '                              "'" & NombreInq & "', " &
               '                                    !Importe & ", " &
               '                                    1 & ", " &
               '                                    prmNroCaja & ", " &
               '                                    0 & ", " &
               '                              "'" & Uid & "', " &
               '                              "'" & Format(Now, FormatFechaHora) & "')"
               '      Cm2.ExecuteNonQuery()
               '      ChCartId = CapturaDato(Cn, "ChCartera", "ChCartId", "Banco = " & !Banco & " AND BancoCta = '" & !Cuenta & "' AND ChCartNro = '" & !Numero & "'", , , , Trn)
               '      '
               '      Cm2.CommandText = "INSERT INTO LiqInqCobCh( LicId, ChCarteraId, LicUid, LicFecMod) " &
               '                        "VALUES(" & LicId & ", " &
               '                                    ChCartId & ", " &
               '                              "'" & Uid & "', " &
               '                              "'" & Format(Now, FormatFechaHora) & "')"
               '      Cm2.ExecuteNonQuery()
               '      '
               '*NomBanco = CapturaDato(Cn, "Bancos", "Nombre", "Banco = " & !Banco, , , , Trn) & ""
               '      If NomBanco = "" Then
               '         Err.Raise(1001, , Traducir("BcoNoEnc"))
               '      End If
               '      '
               'DetChs = DetChs & NomBanco & " N°" & !Numero & " $" & !Importe & " Fecha: " & !Fecha & ".-   "
               '      '
               '   End While
               '   '
               '   .Close()
               '   '
               'End With
               '
            End With
            '
         End If
         '
         If Val(txtTransf.Text) > 0 Then
            '
            Cmd.CommandText = "INSERT INTO LiqInqTR( Banco0, Cuenta0, Titular0, Banco1, Cuenta1, FechaTR, NumeroTR, ImporteTR, Usuario, FechaMod) " &
                              "SELECT Banco0, Cuenta0, Titular, Banco1, Cuenta1, FechaTR, NumeroTR, ImporteTR, '" & Uid & "', '" & Format(Now, FormatFechaHora) & "' " &
                              "FROM " & cTmpTr
            Cmd.ExecuteNonQuery()
            '
            LiqInqTrID = CapturaDato(Cn, "LiqInqTR", "MAX(LiqInqTrID)", "", , , , Trn)
            nBanco = CapturaDato(Cn, "LiqInqTR", "Banco1", "LiqInqTrID = " & LiqInqTrID, , , , Trn)
            cCuenta = CapturaDato(Cn, "LiqInqTR", "Cuenta1", "LiqInqTrID = " & LiqInqTrID, , , , Trn)
            cNumero = CapturaDato(Cn, "LiqInqTR", "NumeroTR", "LiqInqTrID = " & LiqInqTrID, , , , Trn)
            nTipo = CapturaDato(Cn, "TipoMovBco", "TipoMovBco", "TipoMov = 'TR'", , , , Trn)
            '
            If nTipo = 0 Then
               Err.Raise(1001, , "Tipo de Mov. Transferencia no Definida")
            End If
            '
            Cmd.CommandText = "UPDATE LiqInqCob SET LiqInqTrID = " & LiqInqTrID & " " &
                              "WHERE LicId = " & LicId
            Cmd.ExecuteNonQuery()
            '
            cCtaBanco = CapturaDato(Cn, "BancosCtas", "CtaCont", "Banco = " & nBanco & " AND BancoCta = '" & cCuenta & "'", , , , Trn)
            With Cmd
               .CommandText = "INSERT INTO BancosMov( Banco, BancoCta, TipoMovBco, NroMovBco, FechaEmi, FechaAcr, Debe, Haber, Estado, HojaBco, Detalle, Caja, Usuario, FechaMod) " &
                              "VALUES( " & nBanco & ", " &
                                     "'" & cCuenta & "', " &
                                           nTipo & ", " &
                                     "'" & cNumero & "', " &
                                     "'" & Format(Today, FormatFecha) & "', " &
                                     "'" & Format(Today, FormatFecha) & "', " &
                                           Val(txtTransf.Text) & ", " &
                                           0 & ", " & 0 & ", " & 0 & ", " &
                                     "'" & Mid("Liq.Inq." & NombreInq, 1, 50) & "', " &
                                           prmNroCaja & ", " &
                                     "'" & Uid & "', " &
                                     "'" & Format(Now, FormatFechaHora) & "')"
               .ExecuteNonQuery()
               '
            End With
         End If
         '
         With Cmd
            .CommandText = "DELETE FROM ChReciboDesc WHERE Tipo = '" & Tipo & "' AND Sucursal = " & Sucursal & " AND Numero = " & Numero
            .ExecuteNonQuery()
            .CommandText = "INSERT INTO ChReciboDesc( Tipo, Sucursal, Numero, Detalle, Usuario, FechaMod) " &
                           "VALUES('" & Tipo & "', " &
                                        Sucursal & ", " &
                                        Numero & ", " &
                                  "'" & DetChs & "', " &
                                  "'" & Uid & "', " &
                                  "'" & Format(Now, FormatFechaHora) & "')"
            .ExecuteNonQuery()
            '
            .CommandText = "DELETE FROM LiqAux WHERE Usuario = '" & Uid & "' AND LqxPC = '" & NombrePC & "'"
            .ExecuteNonQuery()
            .CommandText = "INSERT INTO LiqAux( Recibe, SonPesos, Periodo, Usuario, LqxPC ) " &
                           "VALUES('" & cfgNomEmp & "', " &
                                  "'" & Numero_a_Texto(nTotPago) & "', " &
                                  "'" & Periodo & "', " &
                                  "'" & Uid & "', " &
                                  "'" & NombrePC & "')"
            .ExecuteNonQuery()
            '
         End With
         '
         'Asiento.
         If SisContable Then
            NroAsi = GuardaAsiento(cComprob, Today, DetAsi, Trn)
            If NroAsi = 0 Then
               Err.Raise(1001, , Traducir("NoUpAsiento", , Trn))
            End If
         End If
         '
         If Val(txtEfectivo.Text) > 0 Then
            '
            If Not ActCaja(prmNroCaja, cComprob, "EF", Today, NombreInq, "", cDetCaja, Val(txtEfectivo.Text), 0, True, Trn) Then
               Err.Raise(1001)
            End If
            '
            If SisContable Then
               If Efectivo - nImpCaja >= 0 Then
                  RenASi = RenASi + 1
                  If Not GuardaAsienDet(NroAsi, RenASi, cCtaCajaAd, DetAsi, Efectivo - nImpCaja, 0, Trn) Then
                     Err.Raise(1001, , Traducir("NoUpAsiento", , Trn))
                  End If
                  If nImpCaja > 0 Then
                     RenASi = RenASi + 1
                     If Not GuardaAsienDet(NroAsi, RenASi, cCtaCaja, DetAsi, nImpCaja, 0, Trn) Then
                        Err.Raise(1001, , Traducir("NoUpAsiento", , Trn))
                     End If
                     nImpCaja = 0
                  End If
               End If
            End If
            '
         End If
         '
         If Val(txtRetencion.Text) > 0 Then
            If SisContable Then
               RenASi = RenASi + 1
               If Not GuardaAsienDet(NroAsi, RenASi, cCtaRGan, DetAsi, Val(txtRetencion) - nImpCaja, 0, Trn) Then
                  Err.Raise(1001, , Traducir("NoUpAsiento", , Trn))
               End If
            End If
         End If
         '
         If Val(tbCheques.Text) > 0 Then
            '
            chCant = CapturaDato(Cn, "ChReciboTmp", "COUNT(1)", "Usuario = '" & Uid & "' AND PC = '" & NombrePC & "'",,,, Trn)
            '
            Dim ChNumero(chCant - 1) As String
            Dim ChImporte(chCant - 1) As Double
            '
            With Cmd
               .CommandText = "SELECT * FROM ChReciboTmp WHERE Usuario = '" & Uid & "' AND PC = '" & NombrePC & "'"
               Drd = .ExecuteReader
               With Drd
                  i = 0
                  While .Read
                     ChNumero(i) = .Item("Numero")
                     ChImporte(i) = .Item("Importe")
                     i = i + 1
                  End While               '
                  .Close()
               End With
            End With
            '
            For i = 1 To chCant
               If Not ActCaja(prmNroCaja, cComprob & "/" & i, "CH", Today, NombreInq, "", Mid(cDetCaja & " Ch.Nº ", 1, 250) & ChNumero(i - 1), ChImporte(i - 1), 0, True, Trn, Cm2) Then
                  Err.Raise(1001)
               End If
            Next i
            '
            If Val(tbCheques.Text) - nImpCaja >= 0 Then
               If SisContable Then
                  RenASi = RenASi + 1
                  If Not GuardaAsienDet(NroAsi, RenASi, cCtaVCar3, DetAsi, Val(tbCheques.Text) - nImpCaja, 0, Trn) Then
                     Err.Raise(1001, , Traducir("NoUpAsiento", , Trn))
                  End If
                  If nImpCaja > 0 Then
                     RenASi = RenASi + 1
                     If Not GuardaAsienDet(NroAsi, RenASi, cCtaVCar, DetAsi, nImpCaja, 0, Trn) Then
                        Err.Raise(1001, , Traducir("NoUpAsiento", , Trn))
                     End If
                  End If
               End If
            End If
            '
         End If
         '
         If SisContable Then
            If Val(txtTransf.Text) > 0 Then
               nBanco = CapturaDato(Cn, "LiqInqTR", "Banco1", "LiqInqTrID = " & LiqInqTrID, , , , Trn)
               cCuenta = CapturaDato(Cn, "LiqInqTR", "Cuenta1", "LiqInqTrID = " & LiqInqTrID, , , , Trn)
               cCtaBanco = CapturaDato(Cn, "BancoCta", "CtaCont", "Banco = " & nBanco & " AND BancoCta = '" & cCuenta & "'", , , , Trn)
               RenASi = RenASi + 1
               If Not GuardaAsienDet(NroAsi, RenASi, cCtaBanco, DetAsi, Val(txtTransf), 0, Trn) Then
                  Err.Raise(1001, , Traducir("NoUpAsiento", , Trn))
               End If
            End If
            '
            If nTotPago - nIntereses > 0 Then
               RenASi = RenASi + 1
               If Not GuardaAsienDet(NroAsi, RenASi, cCtaInq, DetAsi, 0, nTotPago - nIntereses, Trn) Then
                  Err.Raise(1001, , Traducir("NoUpAsiento", , Trn))
               End If
            End If
            '
            If nIntereses > 0 Then
               RenASi = RenASi + 1
               If Not GuardaAsienDet(NroAsi, RenASi, cCtaInt3, DetAsi, 0, nIntereses, Trn) Then
                  Err.Raise(1001, , Traducir("NoUpAsiento", , Trn))
               End If
            End If
         End If
         '
         GuardarAudit("Confirma Recibo/s pendiente/s", NombreInq & " - Nº " & Numeros, Me.Name, Me.cmdGenerar.Text, Trn)
         '
         Trn.Commit()
         '
         ImprimirCrp("LiqInqConf", IIf(prmVistPrevLiq, crptToWindow, crptToPrinter), "{LiqInqCob.LicId} = " & LicId, Me.Text)
         '
         Cancelar()
         '
      Catch ex As System.Exception
         '
         Trn.Rollback()
         '
         Dim st As New StackTrace(True)
         RegistrarError(st, Me.Name)
         '
      End Try
      '
   End Sub
   '
   Private Sub CmdTransferencia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTransferencia.Click
      Dim Frm As New frmLiqTransf
      With Frm
         .TablaTmp = cTmpTr
         .TransfRec = True
         .ShowDialog(Me)
         txtTransf.Text = Format(.Total, "Fixed")
         CalcImportes()
      End With
   End Sub
   '
   Private Sub btnRetencion_Click(sender As Object, e As EventArgs) Handles btnRetencion.Click
      Dim Frm As New frmLiqInquilinosRet
      With Frm
         .tablatmp = cTmp
         .ShowDialog(Me)
         txtRetencion.Text = Format(.Total, "Fixed")
         CalcImportes()
      End With
   End Sub
   '
   Private Sub TxtImportes_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEfectivo.KeyPress, txtRetencion.KeyPress
      SoloNumeros(e.KeyChar, True)
   End Sub
   '
   Private Sub TxtRetencion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRetencion.TextChanged
      CalcImportes()
   End Sub
   '
   Private Sub CalcImportes()
      If Val(txtSaldoPend.Text) > 0 Then
         txtEfectivo.Text = Format(Val(txtSaldoPend.Text) - Val(tbCheques.Text) - Val(txtTransf.Text) - Val(txtRetencion.Text), "Fixed")
      End If
   End Sub
   '
   Private Sub BtnRestCol1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRestCol1.Click
      If Not chkConfirmadas.Checked Then
         SetCols1()
      End If
   End Sub
   '
   Private Sub BtnRestCol2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRestCol2.Click
      SetCols2()
   End Sub
   '
   Private Sub btnLiqProp_Click(sender As Object, e As EventArgs) Handles btnLiqProp.Click
      Dim LiqPropiet As Int32
      If chkConfirmadas.Checked Then
         LiqPropiet = CapturaDatoColumna(DgvConf, "LiqPropiet")
      Else
         LiqPropiet = CapturaDatoColumna(DataGridView1, "LiqPropiet")
      End If
      '
      ImprimirLiqPropiet(LiqPropiet, crptToWindow)
      '
   End Sub
   '
   Private Sub CmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
      Me.Close()
   End Sub
   '
   Private Sub FrmLiqInqPend_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
      SetRegGrid(Me, Me.DataGridView1)
      SetRegGrid(Me, Me.DataGridView2)
      SetRegGrid(Me, Me.DgvConf)
      SetRegForm(Me)
   End Sub
   '
End Class