Public Class frmFormasPagoCredito

#Region "VARIABLES"
    Public blnPago As Boolean = False
    Public TipoPago As String = "" 'EFE = EFECTIVO, TAC = TARJETA DE CREDITO, TAD = TARJETA DE DEBITO, CHE = CHEQUE, ACT = ACTIVOS, PAA = PAGO ADELANTADO
    Public Subtotal As Double = 0
    Public Descuento As Double = 0
    Public Importe As Double = 0
    Public ImportePago As Double = 0
    Public Cambio As Double = 0
    Public Folio As String = ""
    Public objDataSetFP As DataSet
    Dim intReglones As Integer = 0
    Dim VariasFormasPago As Boolean = False
    Dim ImporteFormaPago As Double = 0
    Dim objDataSet As DataSet
#End Region

#Region "EVENTOS"

#Region "FORMA"

    Private Sub frmFormasPagoCredito_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        Try
            txt_Sucursal.Text = GLB_CveSucursal
            txt_Folio.Text = Folio
            If VariasFormasPago = False Then
                GeneraDataSetFomasPago()
                btn_Efectivo_Click(sender, e)
            End If
            Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                objDataSet = objCajaCredito.usp_TraerPermisosCaja(GLB_IdDeptoEmpleado, GLB_IdPuestoEmpleado, "CAJ", "ACTIVOS")
            End Using
            If objDataSet.Tables(0).Rows.Count > 0 Then
                btn_Activos.Enabled = True
            Else
                btn_Activos.Enabled = False
            End If
            'txt_RecibeEfe.TabIndex = 0
            txt_RecibeEfe.Focus()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub frmFormasPagoCredito_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

#End Region

#Region "BOTON"

    Private Sub btn_Efectivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Efectivo.Click
        Try
            pnl_FormasPago.Enabled = False
            btn_Cambiar.Enabled = True
            btn_Pagar.Enabled = True
            gb_PagoEfectivo.Visible = True
            txt_SubtotalEfe.Text = "$ " + Format(Subtotal, "###,##0.00")
            txt_DescuentoEfe.Text = "$ " + Format(Descuento, "###,##0.00")
            txt_TotalEfe.Text = "$ " + Format(Importe, "###,##0.00")
            TipoPago = "EFE"
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_TarjetaCredito_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_TarjetaCredito.Click
        Try
            pnl_FormasPago.Enabled = False
            btn_Cambiar.Enabled = True
            btn_Pagar.Enabled = True
            gb_TarjetaCyD.Visible = True
            gb_TarjetaCyD.Text = "Tarjeta de Crédito"
            txt_RecibeTar.Text = "$ " + Format(Importe, "###,##0.00")
            TipoPago = "TAC"
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_TarjetaDebito_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_TarjetaDebito.Click
        Try
            pnl_FormasPago.Enabled = False
            btn_Cambiar.Enabled = True
            btn_Pagar.Enabled = True
            gb_TarjetaCyD.Visible = True
            gb_TarjetaCyD.Text = "Tarjeta de Débito"
            txt_RecibeTar.Text = "$ " + Format(Importe, "###,##0.00")
            TipoPago = "TAD"
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_Cheque_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Cheque.Click
        Try
            pnl_FormasPago.Enabled = False
            btn_Cambiar.Enabled = True
            btn_Pagar.Enabled = True
            gb_Cheque.Visible = True
            txt_RecibeChe.Text = "$ " + Format(Importe, "###,##0.00")
            TipoPago = "CHE"
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_Dolares_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Dolares.Click
        Try
            pnl_FormasPago.Enabled = False
            btn_Cambiar.Enabled = True
            btn_Pagar.Enabled = True
            Using objCajaCredito As New BCL.BCLCajaCredito(GLB_ConStringCredito)
                objDataSet = objCajaCredito.usp_TraerTipoCambio()
            End Using
            If objDataSet.Tables(0).Rows.Count > 0 Then
                txt_DolTipoCambio.Text = "$" & Format(CDbl(objDataSet.Tables(0).Rows(0).Item("tipocambio").ToString), "###,##0.00")
                glb_tipoCambio = objDataSet.Tables(0).Rows(0).Item("tipocambio")
            Else
                txt_DolTipoCambio.Text = "$ 0.00"
            End If
            txt_DolSubtotal.Text = "$ " + Format(Subtotal, "###,##0.00")
            txt_DolDescuento.Text = "$ " + Format(Descuento, "###,##0.00")
            txt_DolTotal.Text = "$ " + Format(Importe, "###,##0.00")
            gb_Dolares.Visible = True
            TipoPago = "DOL"
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_Activos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Activos.Click
        Try
            pnl_FormasPago.Enabled = False
            btn_Cambiar.Enabled = True
            btn_Pagar.Enabled = True
            gb_Activos.Visible = True
            TipoPago = "ACT"
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    

    Private Sub btn_Cambiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Cambiar.Click
        Try
            TipoPago = ""
            btn_Cambiar.Enabled = False
            btn_Pagar.Enabled = False
            gb_Cheque.Visible = False
            gb_PagoEfectivo.Visible = False
            gb_TarjetaCyD.Visible = False
            gb_Dolares.Visible = False
            gb_Activos.Visible = False
            pnl_FormasPago.Enabled = True
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Cancelar.Click
        Try
            blnPago = False
            Me.Close()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_Pagar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Pagar.Click
        Try
            'If MessageBox.Show("Estas seguro que deseas aplicar el Pago al distribuidor " + Txt_Distrib.Text + "?", "CONFIRMACIÓN", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.No Then Exit Sub
            blnPago = True
            If TipoPago = "EFE" Then
                ImporteFormaPago = CDbl(txt_RecibeEfe.Text) - IIf(CDbl(txt_CambioEfe.Text) < 0, 0.0, CDbl(txt_CambioEfe.Text))
                ImportePago += ImporteFormaPago
                Cambio = IIf(CDbl(txt_CambioEfe.Text) < 0, 0.0, CDbl(txt_CambioEfe.Text))
                objDataSetFP.Tables(0).Rows.Add()
                objDataSetFP.Tables(0).Rows(intReglones).Item("formapago") = TipoPago
                objDataSetFP.Tables(0).Rows(intReglones).Item("importe") = CDbl(txt_RecibeEfe.Text)
                objDataSetFP.Tables(0).Rows(intReglones).Item("dolares") = ""
                objDataSetFP.Tables(0).Rows(intReglones).Item("cambio") = IIf(CDbl(txt_CambioEfe.Text) < 0, 0.0, CDbl(txt_CambioEfe.Text))
                objDataSetFP.Tables(0).Rows(intReglones).Item("emisor") = ""
                objDataSetFP.Tables(0).Rows(intReglones).Item("notarjeta") = ""
                objDataSetFP.Tables(0).Rows(intReglones).Item("autorizacion") = ""
                objDataSetFP.Tables(0).Rows(intReglones).Item("rutabancaria") = ""
                objDataSetFP.Tables(0).Rows(intReglones).Item("nocuenta") = ""
                objDataSetFP.Tables(0).Rows(intReglones).Item("nocheque") = ""
                objDataSetFP.Tables(0).Rows(intReglones).Item("articulo") = ""
                objDataSetFP.Tables(0).Rows(intReglones).Item("tipo") = ""
                objDataSetFP.Tables(0).Rows(intReglones).Item("marca") = ""
                objDataSetFP.Tables(0).Rows(intReglones).Item("numserie") = ""
                objDataSetFP.Tables(0).Rows(intReglones).Item("nuevo") = ""
                objDataSetFP.Tables(0).Rows(intReglones).Item("impcomercial") = ""
                objDataSetFP.Tables(0).Rows(intReglones).Item("comercio") = ""
                objDataSetFP.Tables(0).Rows(intReglones).Item("impadquirido") = ""
                objDataSetFP.Tables(0).Rows(intReglones).Item("impventa") = ""
                intReglones += 1
            End If
            If TipoPago = "DOL" Then
                ImporteFormaPago = (CDbl(txt_DolRecibe.Text) * CDbl(txt_DolTipoCambio.Text)) - IIf(CDbl(txt_DolCambio.Text) < 0, 0.0, CDbl(txt_DolCambio.Text))
                ImportePago += ImporteFormaPago
                Cambio = IIf(CDbl(txt_DolCambio.Text) < 0, 0.0, CDbl(txt_DolCambio.Text))
                objDataSetFP.Tables(0).Rows.Add()
                objDataSetFP.Tables(0).Rows(intReglones).Item("formapago") = TipoPago
                objDataSetFP.Tables(0).Rows(intReglones).Item("importe") = ""
                objDataSetFP.Tables(0).Rows(intReglones).Item("dolares") = CDbl(txt_DolRecibe.Text)
                objDataSetFP.Tables(0).Rows(intReglones).Item("cambio") = IIf(CDbl(txt_DolCambio.Text) < 0, 0.0, CDbl(txt_DolCambio.Text))
                objDataSetFP.Tables(0).Rows(intReglones).Item("emisor") = ""
                objDataSetFP.Tables(0).Rows(intReglones).Item("notarjeta") = ""
                objDataSetFP.Tables(0).Rows(intReglones).Item("autorizacion") = ""
                objDataSetFP.Tables(0).Rows(intReglones).Item("rutabancaria") = ""
                objDataSetFP.Tables(0).Rows(intReglones).Item("nocuenta") = ""
                objDataSetFP.Tables(0).Rows(intReglones).Item("nocheque") = ""
                objDataSetFP.Tables(0).Rows(intReglones).Item("articulo") = ""
                objDataSetFP.Tables(0).Rows(intReglones).Item("tipo") = ""
                objDataSetFP.Tables(0).Rows(intReglones).Item("marca") = ""
                objDataSetFP.Tables(0).Rows(intReglones).Item("numserie") = ""
                objDataSetFP.Tables(0).Rows(intReglones).Item("nuevo") = ""
                objDataSetFP.Tables(0).Rows(intReglones).Item("impcomercial") = ""
                objDataSetFP.Tables(0).Rows(intReglones).Item("comercio") = ""
                objDataSetFP.Tables(0).Rows(intReglones).Item("impadquirido") = ""
                objDataSetFP.Tables(0).Rows(intReglones).Item("impventa") = ""
                intReglones += 1
            End If
            If TipoPago = "TAD" Or TipoPago = "TAC" Then
                ImporteFormaPago = CDbl(txt_RecibeTar.Text)
                ImportePago += ImporteFormaPago
                Cambio = 0
                objDataSetFP.Tables(0).Rows.Add()
                objDataSetFP.Tables(0).Rows(intReglones).Item("formapago") = TipoPago
                objDataSetFP.Tables(0).Rows(intReglones).Item("importe") = CDbl(txt_RecibeTar.Text)
                objDataSetFP.Tables(0).Rows(intReglones).Item("dolares") = ""
                objDataSetFP.Tables(0).Rows(intReglones).Item("cambio") = ""
                objDataSetFP.Tables(0).Rows(intReglones).Item("emisor") = cb_Emisor.Text
                objDataSetFP.Tables(0).Rows(intReglones).Item("notarjeta") = txt_Tarjeta1.Text & txt_Tarjeta2.Text & txt_Tarjeta3.Text & txt_Tarjeta4.Text
                objDataSetFP.Tables(0).Rows(intReglones).Item("autorizacion") = txt_Autorizacion.Text
                objDataSetFP.Tables(0).Rows(intReglones).Item("rutabancaria") = ""
                objDataSetFP.Tables(0).Rows(intReglones).Item("nocuenta") = ""
                objDataSetFP.Tables(0).Rows(intReglones).Item("nocheque") = ""
                objDataSetFP.Tables(0).Rows(intReglones).Item("articulo") = ""
                objDataSetFP.Tables(0).Rows(intReglones).Item("tipo") = ""
                objDataSetFP.Tables(0).Rows(intReglones).Item("marca") = ""
                objDataSetFP.Tables(0).Rows(intReglones).Item("numserie") = ""
                objDataSetFP.Tables(0).Rows(intReglones).Item("nuevo") = ""
                objDataSetFP.Tables(0).Rows(intReglones).Item("impcomercial") = ""
                objDataSetFP.Tables(0).Rows(intReglones).Item("comercio") = ""
                objDataSetFP.Tables(0).Rows(intReglones).Item("impadquirido") = ""
                objDataSetFP.Tables(0).Rows(intReglones).Item("impventa") = ""
                intReglones += 1
            End If
            If TipoPago = "CHE" Then
                ImporteFormaPago = CDbl(txt_RecibeChe.Text)
                ImportePago += ImporteFormaPago
                Cambio = 0
                objDataSetFP.Tables(0).Rows.Add()
                objDataSetFP.Tables(0).Rows(intReglones).Item("formapago") = TipoPago
                objDataSetFP.Tables(0).Rows(intReglones).Item("importe") = CDbl(txt_RecibeChe.Text)
                objDataSetFP.Tables(0).Rows(intReglones).Item("dolares") = ""
                objDataSetFP.Tables(0).Rows(intReglones).Item("cambio") = ""
                objDataSetFP.Tables(0).Rows(intReglones).Item("emisor") = ""
                objDataSetFP.Tables(0).Rows(intReglones).Item("notarjeta") = ""
                objDataSetFP.Tables(0).Rows(intReglones).Item("autorizacion") = ""
                objDataSetFP.Tables(0).Rows(intReglones).Item("rutabancaria") = txt_RutaBancaria.Text
                objDataSetFP.Tables(0).Rows(intReglones).Item("nocuenta") = txt_NoCuenta.Text
                objDataSetFP.Tables(0).Rows(intReglones).Item("nocheque") = txt_NoCheque.Text
                objDataSetFP.Tables(0).Rows(intReglones).Item("articulo") = ""
                objDataSetFP.Tables(0).Rows(intReglones).Item("tipo") = ""
                objDataSetFP.Tables(0).Rows(intReglones).Item("marca") = ""
                objDataSetFP.Tables(0).Rows(intReglones).Item("numserie") = ""
                objDataSetFP.Tables(0).Rows(intReglones).Item("nuevo") = ""
                objDataSetFP.Tables(0).Rows(intReglones).Item("impcomercial") = ""
                objDataSetFP.Tables(0).Rows(intReglones).Item("comercio") = ""
                objDataSetFP.Tables(0).Rows(intReglones).Item("impadquirido") = ""
                objDataSetFP.Tables(0).Rows(intReglones).Item("impventa") = ""
                intReglones += 1
            End If
            If TipoPago = "ACT" Then
                ImporteFormaPago = CDbl(txt_ImporteAdquirido.Text)
                ImportePago += ImporteFormaPago
                Cambio = 0
                objDataSetFP.Tables(0).Rows.Add()
                objDataSetFP.Tables(0).Rows(intReglones).Item("formapago") = TipoPago
                objDataSetFP.Tables(0).Rows(intReglones).Item("importe") = CDbl(txt_ImporteAdquirido.Text)
                objDataSetFP.Tables(0).Rows(intReglones).Item("dolares") = ""
                objDataSetFP.Tables(0).Rows(intReglones).Item("cambio") = ""
                objDataSetFP.Tables(0).Rows(intReglones).Item("emisor") = ""
                objDataSetFP.Tables(0).Rows(intReglones).Item("notarjeta") = ""
                objDataSetFP.Tables(0).Rows(intReglones).Item("autorizacion") = ""
                objDataSetFP.Tables(0).Rows(intReglones).Item("rutabancaria") = ""
                objDataSetFP.Tables(0).Rows(intReglones).Item("nocuenta") = ""
                objDataSetFP.Tables(0).Rows(intReglones).Item("nocheque") = ""
                objDataSetFP.Tables(0).Rows(intReglones).Item("articulo") = txt_Articulo.Text
                objDataSetFP.Tables(0).Rows(intReglones).Item("tipo") = cb_Tipo.Text
                objDataSetFP.Tables(0).Rows(intReglones).Item("marca") = txt_Marca.Text
                objDataSetFP.Tables(0).Rows(intReglones).Item("numserie") = txt_NumSerie.Text
                objDataSetFP.Tables(0).Rows(intReglones).Item("nuevo") = IIf(rb_ActNuevo.Checked, 1, 0)
                objDataSetFP.Tables(0).Rows(intReglones).Item("impcomercial") = txt_ImpComercial.Text
                objDataSetFP.Tables(0).Rows(intReglones).Item("comercio") = txt_Comercio.Text
                objDataSetFP.Tables(0).Rows(intReglones).Item("impadquirido") = txt_ImporteAdquirido.Text
                objDataSetFP.Tables(0).Rows(intReglones).Item("impventa") = 0.0
                intReglones += 1
            End If
            If Math.Round(Importe, 2) <= Math.Round(ImporteFormaPago, 2) Then
                'PAGO COMPLETO
                If MessageBox.Show("Estas seguro que deseas aplicar el Pago al distribuidor " + Txt_Distrib.Text + "?", "CONFIRMACIÓN", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.No Then Exit Sub
                Me.Close()
            Else
                'PAGO INCOMPLETO, PREGUNTO SI QUIERE AGREGAR UNA NUEVA FORMA DE PAGO
                If MessageBox.Show("El pago no esta completo, Deseas agregar otra forma de pago?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Importe = Importe - ImporteFormaPago
                    VariasFormasPago = True
                    btn_Cambiar_Click(sender, e)
                Else
                    Me.Close()
                End If
            End If
            'Me.Close()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_ActFotos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ActFotos.Click
        Try
            Dim myForm As New frmCatalogoFotosDocs
            myForm.Accion = 1
            myForm.tipo2 = "E"
            myForm.ID = txt_Sucursal.Text & txt_Folio.Text
            myForm.WindowState = FormWindowState.Normal
            myForm.Text = myForm.Text & " FOTO"
            myForm.Tipo = 51
            myForm.txt_pertenece.Text = Txt_NombreDistrib.Text
            myForm.Txt_NombreFoto.Enabled = False
            myForm.txt_pertenece.Enabled = False
            myForm.txt_numFoto.Enabled = False
            myForm.Btn_Ant.Visible = False
            myForm.Btn_Sig.Visible = False
            myForm.txt_numFoto.Text = "1"
            myForm.Show()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_ActFactura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ActFactura.Click
        Try
            Dim myForm As New frmCatalogoFotosDocs
            myForm.Accion = 1
            myForm.tipo2 = "E"
            myForm.ID = txt_Sucursal.Text & txt_Folio.Text
            myForm.WindowState = FormWindowState.Normal
            myForm.Text = myForm.Text & " FOTO"
            myForm.Tipo = 50
            myForm.txt_pertenece.Text = Txt_NombreDistrib.Text
            myForm.Txt_NombreFoto.Enabled = False
            myForm.txt_pertenece.Enabled = False
            myForm.txt_numFoto.Enabled = False
            myForm.Btn_Ant.Visible = False
            myForm.Btn_Sig.Visible = False
            myForm.txt_numFoto.Text = "1"
            myForm.Show()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

#End Region

#Region "TEXTBOX"

    Private Sub txt_RecibeEfe_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_RecibeEfe.LostFocus
        Try
            If txt_RecibeEfe.Text.Trim = "" Then Exit Sub
            If txt_RecibeEfe.Text.Trim = "$" Then
                txt_RecibeEfe.Text = ""
                Exit Sub
            End If
            If txt_RecibeEfe.Text.Trim = "." Then
                txt_RecibeEfe.Text = ""
                Exit Sub
            End If
            txt_RecibeEfe.Text = "$ " + Format(CType(txt_RecibeEfe.Text, Decimal), "###,##0.00")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub txt_RecibeEfe_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_RecibeEfe.TextChanged
        Try
            If txt_RecibeEfe.Text.Trim = "" Then
                txt_CambioEfe.Text = ""
                txt_RecibeEfe.Text = ""
                txt_PendienteEfe.Text = txt_TotalEfe.Text
                Exit Sub
            End If
            If IsNumeric(txt_RecibeEfe.Text.Trim) Then
                Dim Total As Decimal = IIf(txt_TotalEfe.Text.Trim = "", 0, CDec(txt_TotalEfe.Text))
                Dim Recibe As Decimal = IIf(txt_RecibeEfe.Text.Trim = "", 0, CDec(txt_RecibeEfe.Text))
                If Total < Recibe Then
                    txt_CambioEfe.Text = Recibe - Total
                    txt_CambioEfe.Text = "$ " + Format(CType(txt_CambioEfe.Text, Decimal), "###,##0.00")
                    txt_PendienteEfe.Text = "$ 0.00"
                Else
                    txt_PendienteEfe.Text = (Recibe - Total) * -1
                    txt_PendienteEfe.Text = "$ " + Format(CType(txt_PendienteEfe.Text, Decimal), "###,##0.00")
                    txt_CambioEfe.Text = "$ 0.00"
                End If
            Else
                If txt_RecibeEfe.Text.Trim = "." Or txt_RecibeEfe.Text.Trim = "$" Then
                    Exit Sub
                Else
                    txt_RecibeEfe.Text = txt_RecibeEfe.Text.Substring(0, txt_RecibeEfe.Text.Length - 1)
                    txt_RecibeEfe.Focus()
                End If
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub txt_DolRecibe_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_DolRecibe.LostFocus
        Try
            If txt_DolRecibe.Text.Trim = "" Then Exit Sub
            If txt_DolRecibe.Text.Trim = "$" Then
                txt_DolRecibe.Text = ""
                Exit Sub
            End If
            If txt_DolRecibe.Text.Trim = "." Then
                txt_DolRecibe.Text = ""
                Exit Sub
            End If
            txt_DolRecibe.Text = "$ " + Format(CType(txt_DolRecibe.Text, Decimal), "###,##0.00")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub txt_DolRecibe_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_DolRecibe.TextChanged
        Try
            If txt_DolRecibe.Text.Trim = "" Then
                txt_DolCambio.Text = ""
                txt_DolRecibe.Text = ""
                txt_DolPendiente.Text = txt_DolTotal.Text
                Exit Sub
            End If
            If IsNumeric(txt_DolRecibe.Text.Trim) Then
                Dim Total As Decimal = CDec(txt_DolTotal.Text)
                Dim Recibe As Decimal = CDec(txt_DolRecibe.Text) * CDec(txt_DolTipoCambio.Text)
                If Total < Recibe Then
                    txt_DolCambio.Text = Recibe - Total
                    txt_DolCambio.Text = "$ " + Format(CType(txt_DolCambio.Text, Decimal), "###,##0.00")
                    txt_DolPendiente.Text = "$ 0.00"
                Else
                    txt_DolPendiente.Text = (Recibe - Total) * -1
                    txt_DolPendiente.Text = "$ " + Format(CType(txt_DolPendiente.Text, Decimal), "###,##0.00")
                    txt_DolCambio.Text = "$ 0.00"
                End If
            Else
                If txt_DolRecibe.Text.Trim = "." Or txt_DolRecibe.Text.Trim = "$" Then
                    Exit Sub
                Else
                    txt_DolRecibe.Text = txt_DolRecibe.Text.Substring(0, txt_RecibeEfe.Text.Length - 1)
                    txt_DolRecibe.Focus()
                End If
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

#End Region

#End Region

#Region "METODOS"

    Private Sub GeneraDataSetFomasPago()
        objDataSetFP = New DataSet
        objDataSetFP.Tables.Add()
        objDataSetFP.Tables(0).Columns.Add("formapago")
        objDataSetFP.Tables(0).Columns.Add("importe")
        objDataSetFP.Tables(0).Columns.Add("dolares")
        objDataSetFP.Tables(0).Columns.Add("cambio")
        objDataSetFP.Tables(0).Columns.Add("emisor")
        objDataSetFP.Tables(0).Columns.Add("notarjeta")
        objDataSetFP.Tables(0).Columns.Add("autorizacion")
        objDataSetFP.Tables(0).Columns.Add("rutabancaria")
        objDataSetFP.Tables(0).Columns.Add("nocuenta")
        objDataSetFP.Tables(0).Columns.Add("nocheque")
        objDataSetFP.Tables(0).Columns.Add("articulo")
        objDataSetFP.Tables(0).Columns.Add("tipo")
        objDataSetFP.Tables(0).Columns.Add("marca")
        objDataSetFP.Tables(0).Columns.Add("numserie")
        objDataSetFP.Tables(0).Columns.Add("nuevo")
        objDataSetFP.Tables(0).Columns.Add("impcomercial")
        objDataSetFP.Tables(0).Columns.Add("comercio")
        objDataSetFP.Tables(0).Columns.Add("impadquirido")
        objDataSetFP.Tables(0).Columns.Add("impventa")
    End Sub

#End Region

    Private Sub gb_Dolares_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gb_Dolares.Enter

    End Sub

    Private Sub pnl_Botones_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnl_Botones.Paint

    End Sub

    Private Sub pnl_Datos_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnl_Datos.Paint

    End Sub

    Private Sub frmFormasPagoCredito_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        If txt_RecibeEfe.Text = "" Then
            txt_RecibeEfe.Focus()
        End If
    End Sub
End Class