Imports SIRCO.Caja.ModCaja
Imports System.Drawing.Printing
Imports LibPrintTicketMatriz.Class1

Public Class frmMovimientosEspecialesCredito

#Region "VARIABLES"
    Dim objDataSet As New DataSet
    Public blnAnticipo As Boolean = False
    Dim Opcion As Integer = 0
    Dim Tipo As String = "" 'CARGO = CAR, CANCELAR = CAN, ANTICIPO = ANT, ABONO = ABO, CONVENIO = CON
    Dim Folio As String = ""
    Dim FolioAnt As String = ""
    Dim Cobrador As Integer = 0
#End Region

#Region "EVENTOS"

#Region "FORMA"

    Private Sub frmMovimientosEspecialesCredito_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            TraerPermisosCaja()
            If blnAnticipo = True Then
                btn_Anticipo_Click(sender, e)
                txt_AntDistrib_LostFocus(sender, e)
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub frmMovimientosEspecialesCredito_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

#End Region

#Region "BOTON"

    Private Sub btn_Cargo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Cargo.Click
        Try
            Opcion = 0
            btn_Cargo.Enabled = False
            btn_Cancelacion.Enabled = False
            btn_Anticipo.Enabled = False
            btn_Abono.Enabled = False
            btn_Convenio.Enabled = False
            gb_GenerarCargo.Visible = True
            gb_CancelarPago.Visible = False
            gb_AnticiparPago.Visible = False
            gb_Abono.Visible = False
            gb_ConvenioPago.Visible = False
            Tipo = "CAR"
            TraerSiguienteFolioMovimiento()
            txt_CarFolio.Text = Folio
            LlenarComboMotivos()
            txt_CarDistrib.Text = ""
            txt_CarDistribNombre.Text = ""
            txt_CarImporte.Text = ""
            txt_CarInteres.Text = ""
            txt_CarNota.Text = ""
            txt_CarPlazo.Text = ""
            txt_CarSucNot.Text = ""
            dt_CarAplicar.Value = GLB_FechaHoy
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_Cancelacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Cancelacion.Click
        Try
            Opcion = 0
            btn_Cargo.Enabled = False
            btn_Cancelacion.Enabled = False
            btn_Anticipo.Enabled = False
            btn_Abono.Enabled = False
            btn_Convenio.Enabled = False
            gb_GenerarCargo.Visible = False
            gb_CancelarPago.Visible = True
            gb_AnticiparPago.Visible = False
            gb_Abono.Visible = False
            gb_ConvenioPago.Visible = False
            txt_CanDistrib.Visible = False
            txt_CanDistribNombre.Visible = False
            lbl_CanDistrib.Visible = False
            txt_CanImporte.Visible = False
            lbl_CanImporte.Visible = False
            dt_CanFechaPago.Visible = False
            lbl_CanFecha.Visible = False
            Tipo = "CAN"
            TraerSiguienteFolioMovimiento()
            txt_CanFolio.Text = Folio
            LlenarComboMotivos()
            txt_CanSucPago.Text = ""
            txt_CanPago.Text = ""
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_Anticipo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Anticipo.Click
        Try
            Opcion = 0
            btn_Cargo.Enabled = False
            btn_Cancelacion.Enabled = False
            btn_Anticipo.Enabled = False
            btn_Abono.Enabled = False
            btn_Convenio.Enabled = False
            DGrid.Visible = False
            lbl_AntCortes.Visible = False
            gb_GenerarCargo.Visible = False
            gb_CancelarPago.Visible = False
            gb_AnticiparPago.Visible = True
            gb_Abono.Visible = False
            gb_ConvenioPago.Visible = False
            Tipo = "ANT"
            TraerSiguienteFolioMovimiento()
            txt_AntFolio.Text = Folio
            If blnAnticipo = False Then
                txt_AntDistrib.Text = ""
                txt_AntDistribNombre.Text = ""
                txt_AntImporte.Text = ""
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_Abono_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Abono.Click
        Try
            Opcion = 0
            btn_Cargo.Enabled = False
            btn_Cancelacion.Enabled = False
            btn_Anticipo.Enabled = False
            btn_Abono.Enabled = False
            btn_Convenio.Enabled = False
            gb_GenerarCargo.Visible = False
            gb_CancelarPago.Visible = False
            gb_AnticiparPago.Visible = False
            gb_Abono.Visible = True
            gb_ConvenioPago.Visible = False
            Tipo = "ABO"
            TraerSiguienteFolioMovimiento()
            txt_AboFolio.Text = Folio
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_Convenio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Convenio.Click
        Try
            Opcion = 0
            btn_Cargo.Enabled = False
            btn_Cancelacion.Enabled = False
            btn_Anticipo.Enabled = False
            btn_Abono.Enabled = False
            btn_Convenio.Enabled = False
            gb_GenerarCargo.Visible = False
            gb_CancelarPago.Visible = False
            gb_AnticiparPago.Visible = False
            gb_Abono.Visible = False
            gb_ConvenioPago.Visible = True
            Tipo = "CON"
            TraerSiguienteFolioMovimiento()
            txt_ConFolio.Text = Folio
            LlenarComboMotivos()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Aceptar.Click
        Try
            If Tipo = "CAR" Then
                GuardaMovimientos()
                btn_Cargo_Click(sender, e)
            End If
            If Tipo = "CAN" Then
                If Opcion = 0 Then
                    MessageBox.Show("No se selecciono pago", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
                GuardaMovimientos()
                btn_Cancelacion_Click(sender, e)

                If txt_CanSucPago.Text = "" Then
                    txt_CanSucPago.TabIndex = 0
                    txt_CanSucPago.Focus()
                End If

            End If
            If Tipo = "ANT" Then
                If Opcion = 0 Then
                    MessageBox.Show("Por Favor seleccione un distribuidor, o un importe mayor a cero", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
                GuardaMovimientos()
                btn_Anticipo_Click(sender, e)
            End If
            If Tipo = "ABO" Then
                If Opcion = 0 Then
                    MessageBox.Show("Por favor ingrese información", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
                GuardaMovimientos()
                btn_Abono_Click(sender, e)
            End If
            If Tipo = "CON" Then
                'If Opcion = 0 Then
                '    MessageBox.Show("Por favor ingrese información", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                '    Exit Sub
                'End If
              
                GuardaMovimientos()
                btn_Convenio_Click(sender, e)
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Salir.Click
        Try
            Me.Close()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

#End Region

#Region "TEXTBOX"

#Region "CARGO"

    Private Sub txt_CarNota_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_CarNota.LostFocus
        Try
            If txt_CarNota.Text.Trim = "" Then Exit Sub
            If txt_CarSucNot.Text.Trim = "" Then Exit Sub
            Dim Suc As String = ""
            Dim Nota As String = ""
            Suc = txt_CarSucNot.Text
            Nota = txt_CarNota.Text
            Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                objDataSet = objCajaCredito.usp_TraerCargos(1, CInt(Suc), CInt(Nota))
            End Using
            If objDataSet.Tables(0).Rows.Count > 0 Then
                txt_CarDistrib.Text = pub_RellenarIzquierda(objDataSet.Tables(0).Rows(0).Item("iddistrib").ToString, 6)
                txt_CarImporte.Text = "$ " & Format(CInt(objDataSet.Tables(0).Rows(0).Item("importe").ToString), "###,##0.00")
                txt_CarInteres.Text = "$ " & Format(CInt(objDataSet.Tables(0).Rows(0).Item("interes").ToString), "###,##0.00")
                dt_CarAplicar.Value = CDate(objDataSet.Tables(0).Rows(0).Item("aplicar").ToString)
                txt_CarPlazo.Text = objDataSet.Tables(0).Rows(0).Item("nplazos").ToString
                Opcion = 1
                Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                    objDataSet = objCajaCredito.usp_TraerDistribuidorCredito(1, CInt(txt_CarDistrib.Text), "")
                End Using
                txt_CarDistribNombre.Text = objDataSet.Tables(0).Rows(0).Item("nombre").ToString
                txt_CarImporte.Enabled = False
                txt_CarInteres.Enabled = False
                txt_CarPlazo.Enabled = False
                dt_CarAplicar.Enabled = False
                txt_CarSucNot.Enabled = False
                txt_CarNota.Enabled = False
            Else
                MessageBox.Show("El Cargo no Existe o esta cancelado", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txt_CarSucNot.Text = ""
                txt_CarNota.Text = ""
                Opcion = 0
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub txt_CarDistrib_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_CarDistrib.LostFocus
        Try
            If txt_CarDistrib.Text.Trim = "" Then
                txt_CarDistribNombre.Text = ""
                Exit Sub
            End If
            Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                objDataSet = objCajaCredito.usp_TraerDistribuidorCredito(1, CInt(txt_CarDistrib.Text), "")
            End Using
            If objDataSet.Tables(0).Rows.Count > 0 Then
                txt_CarDistrib.Text = pub_RellenarIzquierda(txt_CarDistrib.Text, 6)
                txt_CarDistribNombre.Text = objDataSet.Tables(0).Rows(0).Item("nombre").ToString
            Else
                Dim myForm As New frmConsulta
                myForm.Tipo = "DI"
                myForm.ShowDialog()
                txt_CarDistrib.Text = pub_RellenarIzquierda(myForm.Campo, 6)
                txt_CarDistribNombre.Text = myForm.Campo1
            End If
            If txt_CarSucNot.Text.Trim = "" Or txt_CarNota.Text = "" Then
                txt_CarSucNot.Text = ""
                txt_CarNota.Text = ""
                txt_CarSucNot.Enabled = False
                txt_CarNota.Enabled = False
                Tipo = "CAR"
                Opcion = 2
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub txt_CarImporte_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_CarImporte.LostFocus
        Try
            If txt_CarImporte.Text.Trim = "" Then
                txt_CarImporte.Text = "$ " + Format(CType(0.0, Double), "###,##0.00")
            Else
                txt_CarImporte.Text = "$ " + Format(CType(txt_CarImporte.Text, Double), "###,##0.00")
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub txt_CarInteres_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_CarInteres.LostFocus
        Try
            If txt_CarInteres.Text.Trim = "" Then
                txt_CarInteres.Text = "$ " + Format(CType(0.0, Double), "###,##0.00")
            Else
                txt_CarInteres.Text = "$ " + Format(CType(txt_CarInteres.Text, Double), "###,##0.00")
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

#End Region

#Region "CANCELACION"

    Private Sub txt_CanSucPago_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_CanSucPago.LostFocus
        Try
            If txt_CanSucPago.Text.Trim = "" Then Exit Sub
            txt_CanSucPago.Text = pub_RellenarIzquierda(txt_CanSucPago.Text, 2)
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub txt_CanPago_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_CanPago.LostFocus
        'mreyes 07/Diciembre/2018   05:18 p.m.
        Try
            If txt_CanPago.Text.Trim = "" Then Exit Sub
            txt_CanPago.Text = pub_RellenarIzquierda(txt_CanPago.Text, 6)
            Dim Sucursal As String = txt_CanSucPago.Text
            Dim FolioPago As String = txt_CanPago.Text
            Dim Distrib As String = ""
            Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                objDataSet = objCajaCredito.usp_TraerPago(1, Sucursal, FolioPago, 0, GLB_FechaHoy.ToString("yyyy-MM-dd"))
            End Using
            If objDataSet.Tables(0).Rows.Count > 0 Then
                Dim FechaPago As Date = CDate(objDataSet.Tables(0).Rows(0).Item("fecha").ToString)
                Dim EstatusPago As String = objDataSet.Tables(0).Rows(0).Item("status").ToString
                If FechaPago < GLB_FechaHoy Then
                    MessageBox.Show("El pago no es del hoy, No se puede cancelar", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
                If EstatusPago = "ZC" Then
                    MessageBox.Show("El pago ya esta cancelado", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
                Opcion = 1
                Distrib = objDataSet.Tables(0).Rows(0).Item("distrib").ToString
                txt_CanDistrib.Text = pub_RellenarIzquierda(Distrib, 6)
                txt_CanDistribNombre.Text = objDataSet.Tables(0).Rows(0).Item("nombre").ToString
                txt_CanImporte.Text = "$ " + Format(CType(objDataSet.Tables(0).Rows(0).Item("subtotaltotal").ToString, Double), "###,##0.00")
                dt_CanFechaPago.Value = FechaPago
                txt_CanDistrib.Visible = True
                txt_CanDistribNombre.Visible = True
                lbl_CanDistrib.Visible = True
                txt_CanImporte.Visible = True
                lbl_CanImporte.Visible = True
                dt_CanFechaPago.Visible = True
                lbl_CanFecha.Visible = True
            Else
                Opcion = 0
                txt_CanDistrib.Visible = False
                txt_CanDistribNombre.Visible = False
                lbl_CanDistrib.Visible = False
                txt_CanImporte.Visible = False
                lbl_CanImporte.Visible = False
                dt_CanFechaPago.Visible = False
                lbl_CanFecha.Visible = False
                txt_CanDistrib.Text = ""
                txt_CanDistribNombre.Text = ""
                txt_CanImporte.Text = ""
                dt_CanFechaPago.Value = GLB_FechaHoy
                MessageBox.Show("El Pago seleccionado no existe", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

#End Region

#Region "ANTICIPO"

    Private Sub txt_AntDistrib_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_AntDistrib.LostFocus
        Try
            If txt_AntDistrib.Text.Trim = "" Or CInt(txt_AntDistrib.Text) = 0 Then
                Opcion = 0
                Exit Sub
            End If
            txt_AntDistrib.Text = pub_RellenarIzquierda(txt_AntDistrib.Text, 6)
            Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                objDataSet = objCajaCredito.usp_TraerDistribuidorCredito(1, txt_AntDistrib.Text, "")
            End Using
            If objDataSet.Tables(0).Rows.Count = 1 Then
                txt_AntDistribNombre.Text = objDataSet.Tables(0).Rows(0).Item("nombre").ToString
                Cobrador = objDataSet.Tables(0).Rows(0).Item("cobrador").ToString
                txt_AntImporte.Focus()
                Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                    objDataSet = objCajaCredito.usp_TraerCortesCaja(Opcion, txt_AntDistrib.Text)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    MessageBox.Show("El distribuidor " + txt_AntDistrib.Text + " tiene pagos pendientes, no se le puede aplicar anticipo", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.Close()
                    Exit Sub
                End If
                'Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                '    objDataSet = objCajaCredito.usp_PpalPagoCreditoAdelantado(1, txt_AntDistrib.Text, 0)
                'End Using

                Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                    objDataSet = objCajaCredito.usp_TraerCortesCaja(3, txt_AntDistrib.Text)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    DGrid.Visible = True
                    lbl_AntCortes.Visible = True
                    DGrid.DataSource = objDataSet.Tables(0)
                    DGrid.Columns("fecha").HeaderText = "Fecha Pago"
                    DGrid.Columns("vencido").HeaderText = "Vencido"
                    DGrid.Columns("corte").HeaderText = "Corte"
                    DGrid.Columns("abono").HeaderText = "Abono"
                    DGrid.Columns("cobrador").HeaderText = "Cobrador"
                    DGrid.Columns("desctoap").HeaderText = "Descto"
                    DGrid.Columns("descto").HeaderText = "Descuento"
                    DGrid.Columns("apagar").HeaderText = "A Pagar"
                    DGrid.Columns("fecha").DefaultCellStyle.Format = "dd/MM/yyyy"
                    DGrid.Columns("vencido").DefaultCellStyle.Format = "c"
                    DGrid.Columns("corte").DefaultCellStyle.Format = "c"
                    DGrid.Columns("abono").DefaultCellStyle.Format = "c"
                    DGrid.Columns("cobrador").DefaultCellStyle.Format = "#0"
                    DGrid.Columns("desctoap").DefaultCellStyle.Format = "#0"
                    DGrid.Columns("descto").DefaultCellStyle.Format = "c"
                    DGrid.Columns("apagar").DefaultCellStyle.Format = "c"
                    DGrid.Columns("vencido").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    DGrid.Columns("corte").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    DGrid.Columns("abono").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    DGrid.Columns("desctoap").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGrid.Columns("descto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    DGrid.Columns("apagar").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    DGrid.Columns("vencido").Visible = False
                    DGrid.Columns("corte").Visible = False
                    DGrid.Columns("cobrador").Visible = False
                Else
                    MessageBox.Show("El Distribuidor " + txt_AntDistrib.Text + " no tiene pagos programados", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                Dim myForm As New frmConsulta
                myForm.Tipo = "DI"
                myForm.ShowDialog()
                txt_AntDistrib.Text = pub_RellenarIzquierda(myForm.Campo, 6)
                txt_AntDistribNombre.Text = myForm.Campo1
                Cobrador = myForm.Campo2
                If CInt(txt_AntDistrib.Text) = 0 Then
                    txt_AntDistrib.Focus()
                Else
                    txt_AntImporte.Focus()
                End If
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub txt_AntImporte_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_AntImporte.LostFocus
        Try
            If txt_AntImporte.Text.Trim = "" Then
                txt_AntImporte.Text = "$ " + Format(CType(0.0, Double), "###,##0.00")
                Opcion = 0
            Else
                txt_AntImporte.Text = "$ " + Format(CType(txt_AntImporte.Text, Double), "###,##0.00")
                Opcion = 1
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

#End Region

#Region "ABONO"

    Private Sub txt_AboNota_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_AboNota.LostFocus
        Try
            If txt_AboSucNota.Text.Trim = "" Then
                Opcion = 0
                Exit Sub
            End If
            If txt_AboNota.Text.Trim = "" Then
                Opcion = 0
                Exit Sub
            End If
            Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                objDataSet = objCajaCredito.usp_TraerNotaPP(1, txt_AboSucNota.Text, txt_AboNota.Text)
            End Using
            If objDataSet.Tables(0).Rows.Count > 0 Then
                If objDataSet.Tables(0).Rows(0).Item("importe").ToString.Trim = "" Then
                    Opcion = 0
                    MessageBox.Show("La nota no existe", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txt_AboSucNota.Text = ""
                    txt_AboNota.Text = ""
                    Exit Sub
                End If
                If CDbl(objDataSet.Tables(0).Rows(0).Item("importe").ToString) = 0 Then
                    Opcion = 0
                    MessageBox.Show("La nota seleccionada ya se pago", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txt_AboSucNota.Text = ""
                    txt_AboNota.Text = ""
                    Exit Sub
                End If
                Opcion = 1
                txt_AboCliente.Text = objDataSet.Tables(0).Rows(0).Item("idcliente").ToString
                txt_AboClienteNombre.Text = objDataSet.Tables(0).Rows(0).Item("clientenombre").ToString
                txt_AboDistrib.Text = objDataSet.Tables(0).Rows(0).Item("distrib").ToString
                txt_AboDistribNombre.Text = objDataSet.Tables(0).Rows(0).Item("distribnombre").ToString
                txt_AboImporte.Text = "$" & Format(CDbl(objDataSet.Tables(0).Rows(0).Item("importe").ToString), "###,##0.00")
                txt_AboDescto.Text = "$" & Format(CDbl(objDataSet.Tables(0).Rows(0).Item("descuento").ToString), "###,##0.00")
                txt_AboApagar.Text = "$" & Format(CDbl(objDataSet.Tables(0).Rows(0).Item("importe").ToString) - CDbl(objDataSet.Tables(0).Rows(0).Item("descuento").ToString), "###,##0.00")
            Else
                Opcion = 0
                MessageBox.Show("La nota no existe", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txt_AboSucNota.Text = ""
                txt_AboNota.Text = ""
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

#End Region

#Region "CONVENIOS"

    Private Sub txt_ConDistrib_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_ConDistrib.LostFocus
        Try
            If txt_ConDistrib.Text.Trim = "" Or CInt(txt_ConDistrib.Text) = 0 Then
                Opcion = 0
                Exit Sub
            End If
            txt_ConDistrib.Text = pub_RellenarIzquierda(txt_ConDistrib.Text, 6)
            Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                objDataSet = objCajaCredito.usp_TraerDistribuidorCredito(1, txt_ConDistrib.Text, "")
            End Using
            If objDataSet.Tables(0).Rows.Count = 1 Then
                txt_ConDistribNombre.Text = objDataSet.Tables(0).Rows(0).Item("nombre").ToString
                txt_ConCobrador.Text = objDataSet.Tables(0).Rows(0).Item("cobrador").ToString
                txt_ConCobradorNombre.Text = objDataSet.Tables(0).Rows(0).Item("nombrecobrador").ToString
                txt_ConSaldo.Text = "$" & Format(CDbl(objDataSet.Tables(0).Rows(0).Item("saldo").ToString), "###,##0.00")
                Dim SalVenci As Double = 0
                Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                    objDataSet = objCajaCredito.usp_TraerPlanPagos(1, txt_ConDistrib.Text)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    SalVenci = Val(objDataSet.Tables(0).Rows(0).Item("vencido").ToString)
                End If
                txt_ConVencido.Text = "$" & Format(SalVenci, "###,##0.00")
            Else
                Dim myForm As New frmConsulta
                myForm.Tipo = "DI"
                myForm.ShowDialog()
                txt_ConDistrib.Text = pub_RellenarIzquierda(myForm.Campo, 6)
                txt_ConDistribNombre.Text = myForm.Campo1
                Cobrador = myForm.Campo2
                If CInt(txt_ConDistrib.Text) = 0 Then
                    txt_ConDistrib.Focus()
                Else
                    txt_ConDistrib.Focus()
                End If
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub txt_ConDescuento_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_ConDescuento.TextChanged
        Try
            If txt_ConDescuento.Text.Trim = "" Then Exit Sub
            Dim MaxPorc As Double = 0
            Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                objDataSet = objCajaCredito.usp_TraerParametrosCredito("PORCENTAJE CONVENIO")
            End Using
            If objDataSet.Tables(0).Rows.Count > 0 Then
                MaxPorc = CDbl(objDataSet.Tables(0).Rows(0).Item("valor").ToString)
            Else
                MaxPorc = 50
            End If
            If CDbl(txt_ConDescuento.Text) > MaxPorc Then
                MessageBox.Show("El descuento debe ser menor al " & MaxPorc.ToString & "%", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txt_ConDescuento.Text = ""
                txt_ConApagar.Text = ""
                Exit Sub
            End If
            If rb_ConSaldo.Checked Then
                txt_ConApagar.Text = "$" & Format(((CDbl(txt_ConSaldo.Text) - CDbl(txt_ConAnticipo.Text)) - ((CDbl(txt_ConSaldo.Text) - CDbl(txt_ConAnticipo.Text)) * (CDbl(txt_ConDescuento.Text) / 100))), "###,##0.00")
            Else
                txt_ConApagar.Text = "$" & Format(((CDbl(txt_ConVencido.Text) - CDbl(txt_ConAnticipo.Text)) - ((CDbl(txt_ConVencido.Text) - CDbl(txt_ConAnticipo.Text)) * (CDbl(txt_ConDescuento.Text) / 100))), "###,##0.00")
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub txt_ConAnticipo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_ConAnticipo.LostFocus
        Try
            Dim MinAnticipo As Double = 0
            Dim MinAnticipoImp As Double = 0
            Dim Anticipo As Double = 0
            If txt_ConAnticipo.Text.Trim = "" Then
                'MessageBox.Show("Es obligatorio agregar un anticipo", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'txt_ConAnticipo.Focus()
                Exit Sub
            End If
            Anticipo = CDbl(txt_ConAnticipo.Text)
            Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                objDataSet = objCajaCredito.usp_TraerParametrosCredito("PORCENTAJE ANTICIPO")
            End Using
            If objDataSet.Tables(0).Rows.Count > 0 Then
                MinAnticipo = CDbl(objDataSet.Tables(0).Rows(0).Item("valor").ToString)
            Else
                MinAnticipo = 0
            End If
            Dim Tot As Double = 0
            If rb_ConSaldo.Checked Then
                Tot = CDbl(txt_ConSaldo.Text)
            Else
                Tot = CDbl(txt_ConVencido.Text)
            End If
            MinAnticipoImp = Tot * (MinAnticipo / 100)
            If Anticipo < MinAnticipoImp Then
                MessageBox.Show("El Anticipo debe ser igual o mayor al " & MinAnticipo.ToString & "% del total del " & IIf(rb_ConSaldo.Checked, "Saldo", "Vencido"), "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txt_ConAnticipo.Text = ""
                txt_ConAnticipo.Focus()
            End If
            txt_ConAnticipo.Text = "$" & Format(CDbl(txt_ConAnticipo.Text), "###,##0.00")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
#End Region

#End Region

#Region "COMBO"

    'Private Sub cb_ConPlazo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_ConPlazo.TextChanged
    '    Try
    '        Dim DiaIni As Date = GLB_FechaHoy
    '        Dim Plazo As Integer = 0
    '        Dim TipoPago As String = cb_ConPlazo.Text
    '        Dim Dias As Integer = 0
    '        If txt_ConPlazo.Text.Trim = "" Then
    '            txt_ConPlazo.Text = 10
    '        End If
    '        Plazo = txt_ConPlazo.Text
    '        If TipoPago = "SEMANAS" Then
    '            Dias = 7
    '            DiaIni = DiaIni.AddDays(Dias)
    '        ElseIf TipoPago = "QUINCENAS" Then
    '            Dias = 15
    '            DiaIni = DiaIni.AddDays(Dias)
    '        ElseIf TipoPago = "MESES" Then
    '            Dias = 30
    '            DiaIni = DiaIni.AddDays(Dias)
    '        End If
    '        Dim myForm As New frmConvenio
    '        myForm.DiaIni = DiaIni
    '        myForm.TotalPago = txt_ConApagar.Text
    '        myForm.Plazo = Plazo
    '        myForm.Dias = Dias
    '        myForm.StartPosition = FormStartPosition.CenterScreen
    '        myForm.ShowDialog()
    '    Catch ExceptionErr As Exception
    '        MessageBox.Show(ExceptionErr.Message.ToString)
    '    End Try
    'End Sub

#End Region

#End Region

#Region "METODOS"

    Private Sub TraerPermisosCaja()
        Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
            objDataSet = objCajaCredito.usp_TraerPermisosCaja(GLB_IdDeptoEmpleado, GLB_IdPuestoEmpleado, "MOV", "CARGO")
        End Using
        If objDataSet.Tables(0).Rows.Count > 0 Then
            btn_Cargo.Enabled = True
        Else
            btn_Cargo.Enabled = False
        End If
        Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
            objDataSet = objCajaCredito.usp_TraerPermisosCaja(GLB_IdDeptoEmpleado, GLB_IdPuestoEmpleado, "MOV", "CANCELACION")
        End Using
        If objDataSet.Tables(0).Rows.Count > 0 Then
            btn_Cancelacion.Enabled = True
        Else
            btn_Cancelacion.Enabled = False
        End If
        Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
            objDataSet = objCajaCredito.usp_TraerPermisosCaja(GLB_IdDeptoEmpleado, GLB_IdPuestoEmpleado, "MOV", "ANTICIPO")
        End Using
        If objDataSet.Tables(0).Rows.Count > 0 Then
            btn_Anticipo.Enabled = True
        Else
            btn_Anticipo.Enabled = False
        End If
        Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
            objDataSet = objCajaCredito.usp_TraerPermisosCaja(GLB_IdDeptoEmpleado, GLB_IdPuestoEmpleado, "MOV", "ABONO")
        End Using
        If objDataSet.Tables(0).Rows.Count > 0 Then
            btn_Abono.Enabled = True
        Else
            btn_Abono.Enabled = False
        End If
        Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
            objDataSet = objCajaCredito.usp_TraerPermisosCaja(GLB_IdDeptoEmpleado, GLB_IdPuestoEmpleado, "MOV", "CONVENIO")
        End Using
        If objDataSet.Tables(0).Rows.Count > 0 Then
            btn_Convenio.Enabled = True
        Else
            btn_Convenio.Enabled = False
        End If
        gb_GenerarCargo.Visible = False
        gb_CancelarPago.Visible = False
        gb_AnticiparPago.Visible = False
        gb_Abono.Visible = False
        gb_ConvenioPago.Visible = False
    End Sub

    Private Sub TraerSiguienteFolioMovimiento()
        'mreyes 05/Diciembre/2018   09:42 p.m.

        Try
            Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                objDataSet = objCajaCredito.usp_TraerMovimientos(1, GLB_CveSucursal)
            End Using
            If objDataSet.Tables(0).Rows.Count > 0 Then
                Folio = objDataSet.Tables(0).Rows(0).Item("folio").ToString
                Folio = CInt(Folio) + 1
                Folio = pub_RellenarIzquierda(Folio, 6)
                Folio = GLB_CveSucursal & Folio
            End If


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub LlenarComboMotivos()
        Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
            objDataSet = objCajaCredito.usp_TraerMotivos(Tipo)
        End Using
        If objDataSet.Tables(0).Rows.Count > 0 Then
            If Tipo = "CAR" Then
                cb_CarMotivo.DataSource = objDataSet.Tables(0)
                cb_CarMotivo.ValueMember = "id"
                cb_CarMotivo.DisplayMember = "descrip"
            ElseIf Tipo = "CAN" Then
                cb_CanMotivo.DataSource = objDataSet.Tables(0)
                cb_CanMotivo.ValueMember = "id"
                cb_CanMotivo.DisplayMember = "descrip"
            ElseIf Tipo = "CON" Then
                cb_ConMotivo.DataSource = objDataSet.Tables(0)
                cb_ConMotivo.ValueMember = "id"
                cb_ConMotivo.DisplayMember = "descrip"
            End If
        End If
    End Sub

    Private Sub GuardaMovimientos()
        Dim blnGuardo As Boolean = False
        Dim blnActualiza As Boolean = False
        Dim Sucursal As String = ""
        Dim FolioPago As String = ""
        Dim SucNot As String = ""
        Dim Nota As String = ""
        Dim Distrib As String = ""
        Dim FechaAplicar As Date = "1900-01-01"
        Dim ImpNota As Double = 0
        Dim IntNota As Double = 0
        Dim ImpPago As Double = 0
        Dim Plazo As Integer = 0
        Dim Motivo As Integer = 0
        Dim NumPagoCan As String = ""
        If Tipo = "CAR" Then
            If Opcion = 1 Then
                'OPCION CON CAMBIO DE UN CARGO
                SucNot = txt_CarSucNot.Text
                Nota = txt_CarNota.Text
                Distrib = txt_CarDistrib.Text
                FechaAplicar = dt_CarAplicar.Value
                Plazo = CInt(txt_CarPlazo.Text)
                Motivo = cb_CarMotivo.SelectedValue
                ImpNota = CDbl(txt_CarImporte.Text)
                IntNota = CDbl(txt_CarInteres.Text)
                TraerSiguienteFolioMovimiento()
                Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                    blnGuardo = objCajaCredito.usp_CapturaMovimiento(Folio, Distrib, Tipo, 0, 0, 0, SucNot, Nota, FechaAplicar.ToString("yyyy-MM-dd"),
                                                                     Plazo, Motivo, GLB_FechaHoy.ToString("yyyy-MM-dd"),
                                                                     ImpNota, IntNota, GLB_Idempleado,
                                                                     0)
                End Using
                If blnGuardo = True Then
                    MessageBox.Show("Movimiento Generado Correctamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        End If
        If Tipo = "CAN" Then
            Sucursal = txt_CanSucPago.Text
            FolioPago = txt_CanPago.Text
            If MessageBox.Show("Estas seguro que deseas cancelar el pago " & Sucursal & "-" & FolioPago & "?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.No Then Exit Sub
            Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                objDataSet = objCajaCredito.usp_TraerPago(1, Sucursal, FolioPago, 0, GLB_FechaHoy.ToString("yyyy-MM-dd"))
            End Using
            If objDataSet.Tables(0).Rows.Count > 0 Then
                blnActualiza = False
                Dim contador As Integer = 0
                Dim IdPago As Integer = objDataSet.Tables(0).Rows(0).Item("idpagos").ToString
                Distrib = objDataSet.Tables(0).Rows(0).Item("distrib").ToString
                For i As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                    SucNot = objDataSet.Tables(0).Rows(i).Item("sucnot").ToString
                    Nota = objDataSet.Tables(0).Rows(i).Item("nota").ToString
                    NumPagoCan = objDataSet.Tables(0).Rows(i).Item("pago").ToString
                    ImpPago = objDataSet.Tables(0).Rows(i).Item("subtotal").ToString
                    Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                        blnActualiza = objCajaCredito.usp_ActualizarPlanPagos(2, Distrib, SucNot, Nota, NumPagoCan, ImpPago, "1900-01-01", 0, GLB_Idempleado)
                    End Using
                    If blnActualiza = True Then
                        contador += 1
                    Else
                        contador = 0
                        Exit For
                    End If
                Next
                If contador > 0 Then
                    blnActualiza = False
                    Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                        blnActualiza = objCajaCredito.usp_TraerPagoUPDATE(2, Sucursal, FolioPago, GLB_Idempleado, GLB_FechaHoy.ToString("yyyy-MM-dd"))
                    End Using
                    If blnActualiza = True Then
                        blnActualiza = False
                        Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                            blnActualiza = objCajaCredito.usp_ActualizaStatusInfoPagos("ZC", IdPago, GLB_Idempleado)
                        End Using
                        If blnActualiza = True Then
                            blnActualiza = False
                            Motivo = cb_CanMotivo.SelectedValue
                            TraerSiguienteFolioMovimiento()
                            Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                                blnActualiza = objCajaCredito.usp_CapturaMovimiento(Folio, Distrib, "CAN", IdPago, 0, 0, "", "", "1900-01-01", 0, Motivo,
                                                                                    GLB_FechaHoy.ToString("yyyy-MM-dd"), 0.0, 0.0, GLB_Idempleado,
                                                                                     0)
                            End Using

                            If blnActualiza = True Then
                                Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                                    objCajaCredito.usp_ActualizarSaldoDistrib(2, Distrib, CDbl(txt_CanImporte.Text))
                                End Using
                                'Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditosql)
                                '    objCajaCredito.usp_GenerarCorte(Distrib)
                                'End Using
                                MessageBox.Show("Pago cancelado correctamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else
                                MessageBox.Show("Error al guardar el Movimiento", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            End If
                        Else
                            MessageBox.Show("Error al cancelar la forma de Pago", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    Else
                        MessageBox.Show("Error al cancelar el pago", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Else
                    MessageBox.Show("Error al actualizar el plan de pagos", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("El pago seleccionado no existe", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
        If Tipo = "ANT" Then
            Dim idPagoDet As Integer = 0
            Dim NumPagoAnt As String = ""
            Dim PagoDelPago As Integer = 0
            Dim ImporteTotDelPago As Double = 0
            Dim TotDelPago As Double = 0
            Dim PagadoElPago As Integer = 0
            Dim objDataSetAux As DataSet
            Dim idPago As Integer = 0
            Dim SubTotPag As Double = 0.0
            If Opcion = 1 Or CDbl(txt_AntImporte.Text) > 0 Then
                Dim myForm As New frmFormasPagoCredito
                myForm.txt_TotalEfe.Visible = False
                myForm.txt_SubtotalEfe.Visible = False
                myForm.txt_DescuentoEfe.Visible = False
                myForm.lbl_TotalEfe.Visible = False
                myForm.lbl_SubtotalEfe.Visible = False
                myForm.lbl_DescuentoEfe.Visible = False
                myForm.Txt_Distrib.Text = txt_AntDistrib.Text
                myForm.Txt_NombreDistrib.Text = txt_AntDistribNombre.Text
                TraerFolioPago()
                myForm.Folio = FolioAnt
                If txt_AntImporte.Text.Trim = "" Then
                    txt_AntImporte.Text = "0.00"
                End If
                myForm.txt_TotalEfe.Text = txt_AntImporte.Text
                myForm.txt_RecibeEfe.Text = txt_AntImporte.Text
                myForm.StartPosition = FormStartPosition.CenterScreen
                myForm.ShowDialog()
                If myForm.blnPago = False Then
                    MessageBox.Show("No se pudo completar la operación", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
                If myForm.ImportePago = 0 Then
                    MessageBox.Show("No se pudo completar la operación, debes indicar una cantidad mayor a cero ", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
                txt_AntImporte.Text = myForm.ImportePago
                blnActualiza = False
                Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                    blnActualiza = objCajaCredito.usp_CapturaAnticipo(1, 0, GLB_CveSucursal, txt_AntDistrib.Text, "AP", CDbl(txt_AntImporte.Text), 0, GLB_Idempleado, 0)
                End Using
                If blnActualiza = True Then
                    blnActualiza = False
                    Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                        objDataSet = objCajaCredito.usp_TraerAnticipo(1, txt_AntDistrib.Text, GLB_CveSucursal, GLB_Idempleado, GLB_FechaHoy.ToString("yyyy-MM-dd"))
                    End Using
                    Dim IdAnticipo As Integer = 0
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        IdAnticipo = CInt(objDataSet.Tables(0).Rows(0).Item("idanticipo").ToString)
                    End If
                    TraerSiguienteFolioMovimiento()
                    Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                        blnActualiza = objCajaCredito.usp_CapturaMovimiento(Folio, txt_AntDistrib.Text, "ANT", 0, IdAnticipo, 0, "", "", "1900-01-01", 0, 0,
                                                                            GLB_FechaHoy.ToString("yyyy-MM-dd"), CDbl(txt_AntImporte.Text), 0.0, GLB_Idempleado,
                                                                            0)
                    End Using
                    If blnActualiza = True Then
                        '''''''''''''''''AQUI VA EL CODIGO PARA APLICARSELO A LAS NOTAS EL PAGO ANTICIPADO'''''''''''''''''''''''
                        Dim Descto As Double = 0
                        Dim ImpAnticipo As Double = 0
                        ImpAnticipo = CDbl(txt_AntImporte.Text)
                        Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                            objDataSet = objCajaCredito.usp_TraerDescuentoCaja(ImpAnticipo)
                        End Using
                        If objDataSet.Tables(0).Rows.Count > 0 Then
                            Descto = CDbl(objDataSet.Tables(0).Rows(0).Item("descuento").ToString)
                        End If
                        TraerFolioPago()
                        Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                            blnActualiza = objCajaCredito.usp_CapturaPago(1, GLB_CveSucursal, FolioAnt, txt_AntDistrib.Text, "AP", GLB_FechaHoy.ToString("yyyy-MM-dd HH:mm:ss"),
                                                           0.0, 0.0, 0.0, 0.0, 0.0, 0.0,
                                                           ImpAnticipo, 0.0, 0.0, Cobrador, 0, GLB_Idempleado, 0)
                        End Using
                        Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                            objDataSet = objCajaCredito.usp_TraerIdPagoDistrib(1, txt_AntDistrib.Text, GLB_CveSucursal, GLB_Idempleado, "", "", 0)
                        End Using
                        If objDataSet.Tables(0).Rows.Count > 0 Then
                            idPago = CInt(objDataSet.Tables(0).Rows(0).Item("idpago").ToString)
                            For i As Integer = 0 To myForm.objDataSetFP.Tables(0).Rows.Count - 1
                                GuardaFormasDePago(idPago, myForm.objDataSetFP)
                            Next
                            'checar mreyes 19/diciembre/2018    05:05
                            Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                                objDataSet = objCajaCredito.usp_TraerCortesCaja(2, txt_AntDistrib.Text)
                            End Using
                            ' Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                            ' objDataSet = objCajaCredito.usp_PpalPagoCreditoAdelantado(2, txt_AntDistrib.Text, Descto)
                            'End Using
                            If objDataSet.Tables(0).Rows.Count > 0 Then
                                For i As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                                    If ImpAnticipo = 0 Then Exit For
                                    NumPagoAnt = ""
                                    objDataSetAux = New DataSet
                                    PagoDelPago = 0
                                    ImporteTotDelPago = 0
                                    idPagoDet = 0
                                    If ImpAnticipo >= (CDbl(objDataSet.Tables(0).Rows(i).Item("abono").ToString) - CDbl(objDataSet.Tables(0).Rows(i).Item("dsctoap").ToString)) Then
                                        SubTotPag += CDbl(objDataSet.Tables(0).Rows(i).Item("abono").ToString)
                                        NumPagoAnt = objDataSet.Tables(0).Rows(i).Item("pago").ToString.Substring(0, objDataSet.Tables(0).Rows(i).Item("pago").ToString.LastIndexOf("/"))
                                        Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                                            objDataSetAux = objCajaCredito.usp_TraerInfoPagoDet(1, objDataSet.Tables(0).Rows(i).Item("sucursal").ToString, objDataSet.Tables(0).Rows(i).Item("nota").ToString, NumPagoAnt)
                                        End Using
                                        If objDataSetAux.Tables(0).Rows.Count > 0 Then
                                            PagoDelPago = CInt(objDataSetAux.Tables(0).Rows(0).Item("numpago").ToString) + 1
                                        End If
                                        Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                                            objDataSetAux = objCajaCredito.usp_TraerInfoPagoDet(2, objDataSet.Tables(0).Rows(i).Item("sucursal").ToString, objDataSet.Tables(0).Rows(i).Item("nota").ToString, NumPagoAnt)
                                        End Using
                                        If objDataSetAux.Tables(0).Rows.Count > 0 Then
                                            ImporteTotDelPago = CDbl(objDataSetAux.Tables(0).Rows(0).Item("subtotal").ToString)
                                            'ImporteTotDelPago += myForm.ImportePago
                                            ImporteTotDelPago += CDbl(objDataSet.Tables(0).Rows(i).Item("abono").ToString)
                                        End If
                                        Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                                            objDataSetAux = objCajaCredito.usp_TraerInfoPagoDet(3, objDataSet.Tables(0).Rows(i).Item("sucursal").ToString, objDataSet.Tables(0).Rows(i).Item("nota").ToString, NumPagoAnt)
                                        End Using
                                        If objDataSetAux.Tables(0).Rows.Count > 0 Then
                                            TotDelPago = CDbl(objDataSetAux.Tables(0).Rows(0).Item("subtotal").ToString)
                                        End If
                                        If ImporteTotDelPago >= TotDelPago Then
                                            PagadoElPago = 1
                                        Else
                                            PagadoElPago = 0
                                        End If
                                        Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                                            objCajaCredito.usp_CapturaPagoDet(1, idPago, GLB_CveSucursal, objDataSet.Tables(0).Rows(i).Item("sucursal").ToString,
                                                                              objDataSet.Tables(0).Rows(i).Item("nota").ToString, CInt(NumPagoAnt), CDbl(objDataSet.Tables(0).Rows(i).Item("abono").ToString),
                                                                              CDbl(objDataSet.Tables(0).Rows(i).Item("dsctoap").ToString) - CDbl(objDataSet.Tables(0).Rows(i).Item("dsctoad").ToString), CDbl(objDataSet.Tables(0).Rows(i).Item("dsctoad").ToString), 0.0, 0.0, 0.0, (CDbl(objDataSet.Tables(0).Rows(i).Item("abono").ToString) - CDbl(objDataSet.Tables(0).Rows(i).Item("dsctoap").ToString)),
                                                                              CDbl(objDataSet.Tables(0).Rows(i).Item("vencido").ToString), 0.0, PagoDelPago, PagadoElPago, CDbl(objDataSet.Tables(0).Rows(i).Item("descuento").ToString) - CDbl(objDataSet.Tables(0).Rows(i).Item("descuentoadicional").ToString), CDbl(objDataSet.Tables(0).Rows(i).Item("descuentoadicional").ToString), 0.0, GLB_Idempleado)
                                        End Using
                                        ImpAnticipo -= (CDbl(objDataSet.Tables(0).Rows(i).Item("abono").ToString) - CDbl(objDataSet.Tables(0).Rows(i).Item("dsctoap").ToString))
                                        ImpAnticipo = Math.Round(ImpAnticipo, 2)
                                        Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                                            objDataSetAux = objCajaCredito.usp_TraerIdPagoDistrib(2, txt_AntDistrib.Text, GLB_CveSucursal, GLB_Idempleado, objDataSet.Tables(0).Rows(i).Item("sucursal").ToString, objDataSet.Tables(0).Rows(i).Item("nota").ToString, NumPagoAnt)
                                        End Using
                                        If objDataSetAux.Tables(0).Rows.Count > 0 Then
                                            idPagoDet = CInt(objDataSetAux.Tables(0).Rows(0).Item("idpagosdet").ToString)
                                        End If
                                        Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                                            objCajaCredito.usp_ActualizarPlanPagos(1, txt_AntDistrib.Text, objDataSet.Tables(0).Rows(i).Item("sucursal").ToString, objDataSet.Tables(0).Rows(i).Item("nota").ToString, CInt(NumPagoAnt), objDataSet.Tables(0).Rows(i).Item("abono").ToString,
                                                                                   GLB_FechaHoy.ToString("yyyy-MM-dd"), idPagoDet, GLB_Idempleado)
                                        End Using
                                    Else
                                        NumPagoAnt = objDataSet.Tables(0).Rows(i).Item("pago").ToString.Substring(0, objDataSet.Tables(0).Rows(i).Item("pago").ToString.LastIndexOf("/"))
                                        Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                                            objDataSetAux = objCajaCredito.usp_TraerInfoPagoDet(1, objDataSet.Tables(0).Rows(i).Item("sucursal").ToString, objDataSet.Tables(0).Rows(i).Item("nota").ToString, NumPagoAnt)
                                        End Using
                                        If objDataSetAux.Tables(0).Rows.Count > 0 Then
                                            PagoDelPago = CInt(objDataSetAux.Tables(0).Rows(0).Item("numpago").ToString) + 1
                                        End If
                                        Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                                            objDataSetAux = objCajaCredito.usp_TraerInfoPagoDet(2, objDataSet.Tables(0).Rows(i).Item("sucursal").ToString, objDataSet.Tables(0).Rows(i).Item("nota").ToString, NumPagoAnt)
                                        End Using
                                        If objDataSetAux.Tables(0).Rows.Count > 0 Then
                                            ImporteTotDelPago = CDbl(objDataSetAux.Tables(0).Rows(0).Item("subtotal").ToString)
                                            ImporteTotDelPago += ImpAnticipo
                                            'ImporteTotDelPago += CDbl(objDataSet.Tables(0).Rows(i).Item("abono").ToString)
                                        End If
                                        Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                                            objDataSetAux = objCajaCredito.usp_TraerInfoPagoDet(3, objDataSet.Tables(0).Rows(i).Item("sucursal").ToString, objDataSet.Tables(0).Rows(i).Item("nota").ToString, NumPagoAnt)
                                        End Using
                                        If objDataSetAux.Tables(0).Rows.Count > 0 Then
                                            TotDelPago = CDbl(objDataSetAux.Tables(0).Rows(0).Item("subtotal").ToString)
                                        End If
                                        If ImporteTotDelPago >= TotDelPago Then
                                            PagadoElPago = 1
                                        Else
                                            PagadoElPago = 0
                                        End If
                                        Dim SubTotalAnt As Double = 0.0
                                        Dim DesctoAnt As Double = 0.0
                                        SubTotalAnt = ImpAnticipo * 100 / (100 - Descto)
                                        DesctoAnt = SubTotalAnt - ImpAnticipo
                                        SubTotPag += SubTotalAnt
                                        Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                                            objCajaCredito.usp_CapturaPagoDet(1, idPago, GLB_CveSucursal, objDataSet.Tables(0).Rows(i).Item("sucursal").ToString,
                                                                              objDataSet.Tables(0).Rows(i).Item("nota").ToString, CInt(NumPagoAnt), SubTotalAnt,
                                                                              DesctoAnt - CDbl(objDataSet.Tables(0).Rows(i).Item("dsctoad").ToString), CDbl(objDataSet.Tables(0).Rows(i).Item("dsctoad").ToString), 0.0, 0.0, 0.0, ImpAnticipo,
                                                                              CDbl(objDataSet.Tables(0).Rows(i).Item("vencido").ToString), 0.0, PagoDelPago, PagadoElPago, Descto - CDbl(objDataSet.Tables(0).Rows(i).Item("descuentoadicional").ToString), CDbl(objDataSet.Tables(0).Rows(i).Item("descuentoadicional").ToString), 0.0, GLB_Idempleado)
                                        End Using
                                        Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                                            objDataSetAux = objCajaCredito.usp_TraerIdPagoDistrib(2, txt_AntDistrib.Text, GLB_CveSucursal, GLB_Idempleado, objDataSet.Tables(0).Rows(i).Item("sucursal").ToString, objDataSet.Tables(0).Rows(i).Item("nota").ToString, NumPagoAnt)
                                        End Using
                                        If objDataSetAux.Tables(0).Rows.Count > 0 Then
                                            idPagoDet = CInt(objDataSetAux.Tables(0).Rows(0).Item("idpagosdet").ToString)
                                        End If
                                        Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                                            blnActualiza = objCajaCredito.usp_ActualizarPlanPagos(1, txt_AntDistrib.Text, objDataSet.Tables(0).Rows(i).Item("sucursal").ToString, objDataSet.Tables(0).Rows(i).Item("nota").ToString, CInt(NumPagoAnt), SubTotalAnt,
                                                                                   GLB_FechaHoy.ToString("yyyy-MM-dd"), idPagoDet, GLB_Idempleado)
                                        End Using
                                        ImpAnticipo = 0
                                    End If
                                Next
                                ''''''FALTA GENERAR EL CORTE
                                Dim SalAnt As Double = 0
                                Dim SalNue As Double = 0
                                Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                                    objDataSet = objCajaCredito.usp_TraerDistribuidorCredito(1, txt_AntDistrib.Text, "")
                                End Using
                                If objDataSet.Tables(0).Rows.Count > 0 Then
                                    SalAnt = objDataSet.Tables(0).Rows(0).Item("saldo").ToString
                                End If
                                Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                                    objCajaCredito.usp_ActualizarSaldoDistrib(1, txt_AntDistrib.Text, SubTotPag)
                                End Using
                                Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                                    objDataSet = objCajaCredito.usp_TraerDistribuidorCredito(1, txt_AntDistrib.Text, "")
                                End Using
                                If objDataSet.Tables(0).Rows.Count > 0 Then
                                    SalNue = objDataSet.Tables(0).Rows(0).Item("saldo").ToString
                                End If
                                'veriricar mreyes   19/Diciembre/2018   05:29 p.m.
                                'Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                                '    objCajaCredito.usp_GenerarCorte(txt_AntDistrib.Text)
                                'End Using
                                imprimir_Tiquete(SubTotPag, SubTotPag - CDbl(txt_AntImporte.Text), CDbl(txt_AntImporte.Text), CDbl(txt_AntImporte.Text), 0.0, 1, FolioAnt, SalAnt, SalNue, txt_AntDistrib.Text, txt_AntDistribNombre.Text, 0)
                                MessageBox.Show("Anticipo aplicado correctamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Me.Close()
                            Else
                                MessageBox.Show("El distribuidor no tiene ningun pago pendiente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Exit Sub
                            End If
                        End If

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        'If blnActualiza = True Then
                        '    MessageBox.Show("Anticipo aplicado correctamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        'Else
                        '    MessageBox.Show("Error al guardar el movimiento", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        'End If
                    End If
                Else
                    MessageBox.Show("Error al grabar el anticipo", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("Importe incorrecto, por favor proporciona un importe mayor a Cero", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
        If Tipo = "ABO" Then

            If MessageBox.Show("Estas seguro que deseas aplicar el anticipo?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If
            Dim idPagoDet As Integer = 0
            Dim NumPagoAnt As String = ""
            Dim PagoDelPago As Integer = 0
            Dim ImporteTotDelPago As Double = 0
            Dim TotDelPago As Double = 0
            Dim PagadoElPago As Integer = 0
            Dim objDataSetAux As DataSet
            Dim idPago As Integer = 0
            Dim SubTotPag As Double = 0.0
            Dim myForm As New frmFormasPagoCredito
            'myForm.txt_TotalEfe.Visible = False
            'myForm.txt_SubtotalEfe.Visible = False
            'myForm.txt_DescuentoEfe.Visible = False
            'myForm.lbl_TotalEfe.Visible = False
            'myForm.lbl_SubtotalEfe.Visible = False
            'myForm.lbl_DescuentoEfe.Visible = False
            myForm.Subtotal = txt_AboImporte.Text
            myForm.Descuento = txt_AboDescto.Text
            myForm.Txt_Distrib.Text = txt_AboDistrib.Text
            myForm.Txt_NombreDistrib.Text = txt_AboDistribNombre.Text
            TraerFolioPago()
            myForm.Folio = FolioAnt
            If txt_AboApagar.Text.Trim = "" Then
                txt_AboApagar.Text = "0.00"
            End If
            myForm.Importe = txt_AboApagar.Text
            If txt_AboAbono.Text.Trim = "" Then
                txt_AboAbono.Text = "0.00"
            End If
            If myForm.txt_TotalEfe.Text.Trim = "" Then
                myForm.txt_TotalEfe.Text = "0.00"
            End If
            myForm.txt_RecibeEfe.Text = "$" & Format(CDbl(txt_AboAbono.Text), "###,##0.00")
            'myForm.txt_RecibeEfe.Text = txt_AntImporte.Text
            myForm.StartPosition = FormStartPosition.CenterScreen
            myForm.ShowDialog()
            If myForm.blnPago = False Then
                MessageBox.Show("No se pudo completar la operación", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If myForm.ImportePago = 0 Then
                MessageBox.Show("No se pudo completar la operación, debes indicar una cantidad mayor a cero ", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            txt_AboAbono.Text = myForm.ImportePago
            blnActualiza = False
            Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                blnActualiza = objCajaCredito.usp_CapturaAnticipo(1, 0, GLB_CveSucursal, txt_AboDistrib.Text, "AP", CDbl(txt_AboAbono.Text), 0, GLB_Idempleado, 0)
            End Using
            If blnActualiza = True Then
                blnActualiza = False
                Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                    objDataSet = objCajaCredito.usp_TraerAnticipo(1, txt_AboDistrib.Text, GLB_CveSucursal, GLB_Idempleado, GLB_FechaHoy.ToString("yyyy-MM-dd"))
                End Using
                Dim IdAnticipo As Integer = 0
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    IdAnticipo = CInt(objDataSet.Tables(0).Rows(0).Item("idanticipo").ToString)
                End If
                TraerSiguienteFolioMovimiento()
                Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                    blnActualiza = objCajaCredito.usp_CapturaMovimiento(Folio, txt_AboDistrib.Text, "ABO", 0, IdAnticipo, 0, "", "", "1900-01-01", 0, 0,
                                                                        GLB_FechaHoy.ToString("yyyy-MM-dd"), CDbl(txt_AboAbono.Text), 0.0, GLB_Idempleado,
                                                                         0)
                End Using
                If blnActualiza = True Then
                    '''''''''''''''''AQUI VA EL CODIGO PARA APLICARSELO A LAS NOTAS EL PAGO ANTICIPADO'''''''''''''''''''''''
                    Dim Descto As Double = 0
                    Dim ImpAnticipo As Double = 0
                    ImpAnticipo = CDbl(txt_AboAbono.Text)
                    'Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditosql)
                    '    objDataSet = objCajaCredito.usp_TraerDescuentoCaja(ImpAnticipo)
                    'End Using
                    'If objDataSet.Tables(0).Rows.Count > 0 Then
                    '    Descto = CDbl(objDataSet.Tables(0).Rows(0).Item("descuento").ToString)
                    'End If
                    TraerFolioPago()
                    Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                        blnActualiza = objCajaCredito.usp_CapturaPago(1, GLB_CveSucursal, FolioAnt, txt_AboDistrib.Text, "AP", GLB_FechaHoy.ToString("yyyy-MM-dd HH:mm:ss"),
                                                       0.0, 0.0, 0.0, 0.0, 0.0, 0.0,
                                                       ImpAnticipo, 0.0, 0.0, Cobrador, 0, GLB_Idempleado, 0)
                    End Using
                    Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                        objDataSet = objCajaCredito.usp_TraerIdPagoDistrib(1, txt_AboDistrib.Text, GLB_CveSucursal, GLB_Idempleado, "", "", 0)
                    End Using
                    idPago = 0
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        idPago = CInt(objDataSet.Tables(0).Rows(0).Item("idpago").ToString)
                        For i As Integer = 0 To myForm.objDataSetFP.Tables(0).Rows.Count - 1
                            GuardaFormasDePago(idPago, myForm.objDataSetFP)
                        Next
                        Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                            objDataSet = objCajaCredito.usp_TraerNotaPP(2, txt_AboSucNota.Text, txt_AboNota.Text)
                        End Using
                        If objDataSet.Tables(0).Rows.Count > 0 Then
                            SubTotPag = 0
                            For i As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                                If ImpAnticipo = 0 Then Exit For
                                NumPagoAnt = ""
                                objDataSetAux = New DataSet
                                PagoDelPago = 0
                                ImporteTotDelPago = 0
                                idPagoDet = 0
                                If ImpAnticipo >= (CDbl(objDataSet.Tables(0).Rows(i).Item("abono").ToString) - CDbl(objDataSet.Tables(0).Rows(i).Item("dsctoap").ToString)) Then
                                    SubTotPag += CDbl(objDataSet.Tables(0).Rows(i).Item("abono").ToString)
                                    NumPagoAnt = objDataSet.Tables(0).Rows(i).Item("pago").ToString
                                    Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                                        objDataSetAux = objCajaCredito.usp_TraerInfoPagoDet(1, txt_AboSucNota.Text, txt_AboNota.Text, NumPagoAnt)
                                    End Using
                                    If objDataSetAux.Tables(0).Rows.Count > 0 Then
                                        PagoDelPago = CInt(objDataSetAux.Tables(0).Rows(0).Item("numpago").ToString) + 1
                                    End If
                                    Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                                        objDataSetAux = objCajaCredito.usp_TraerInfoPagoDet(2, txt_AboSucNota.Text, txt_AboNota.Text, NumPagoAnt)
                                    End Using
                                    If objDataSetAux.Tables(0).Rows.Count > 0 Then
                                        ImporteTotDelPago = CDbl(objDataSetAux.Tables(0).Rows(0).Item("subtotal").ToString)
                                        'ImporteTotDelPago += myForm.ImportePago
                                        ImporteTotDelPago += CDbl(objDataSet.Tables(0).Rows(i).Item("abono").ToString)
                                    End If
                                    Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                                        objDataSetAux = objCajaCredito.usp_TraerInfoPagoDet(3, txt_AboSucNota.Text, txt_AboNota.Text, NumPagoAnt)
                                    End Using
                                    If objDataSetAux.Tables(0).Rows.Count > 0 Then
                                        TotDelPago = CDbl(objDataSetAux.Tables(0).Rows(0).Item("subtotal").ToString)
                                    End If
                                    If ImporteTotDelPago >= TotDelPago Then
                                        PagadoElPago = 1
                                    Else
                                        PagadoElPago = 0
                                    End If
                                    Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                                        objCajaCredito.usp_CapturaPagoDet(1, idPago, GLB_CveSucursal, txt_AboSucNota.Text,
                                                                          txt_AboNota.Text, CInt(NumPagoAnt), CDbl(objDataSet.Tables(0).Rows(i).Item("abono").ToString),
                                                                          CDbl(objDataSet.Tables(0).Rows(i).Item("dsctoap").ToString), 0, 0.0, 0.0, 0.0, (CDbl(objDataSet.Tables(0).Rows(i).Item("abono").ToString) - CDbl(objDataSet.Tables(0).Rows(i).Item("dsctoap").ToString)),
                                                                          CDbl(objDataSet.Tables(0).Rows(i).Item("vencido").ToString), 0.0, PagoDelPago, PagadoElPago, CDbl(objDataSet.Tables(0).Rows(i).Item("descuento").ToString), 0, 0.0, GLB_Idempleado)
                                    End Using
                                    ImpAnticipo -= (CDbl(objDataSet.Tables(0).Rows(i).Item("abono").ToString) - CDbl(objDataSet.Tables(0).Rows(i).Item("dsctoap").ToString))
                                    ImpAnticipo = Math.Round(ImpAnticipo, 2)
                                    Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                                        objDataSetAux = objCajaCredito.usp_TraerIdPagoDistrib(2, txt_AboDistrib.Text, GLB_CveSucursal, GLB_Idempleado, txt_AboSucNota.Text, txt_AboNota.Text, NumPagoAnt)
                                    End Using
                                    If objDataSetAux.Tables(0).Rows.Count > 0 Then
                                        idPagoDet = CInt(objDataSetAux.Tables(0).Rows(0).Item("idpagosdet").ToString)
                                    End If
                                    Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                                        objCajaCredito.usp_ActualizarPlanPagos(1, txt_AboDistrib.Text, txt_AboSucNota.Text, txt_AboNota.Text, CInt(NumPagoAnt), objDataSet.Tables(0).Rows(i).Item("abono").ToString,
                                                                               GLB_FechaHoy.ToString("yyyy-MM-dd"), idPagoDet, GLB_Idempleado)
                                    End Using
                                Else
                                    NumPagoAnt = objDataSet.Tables(0).Rows(i).Item("pago").ToString
                                    Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                                        objDataSetAux = objCajaCredito.usp_TraerInfoPagoDet(1, txt_AboSucNota.Text, txt_AboNota.Text, NumPagoAnt)
                                    End Using
                                    If objDataSetAux.Tables(0).Rows.Count > 0 Then
                                        PagoDelPago = CInt(objDataSetAux.Tables(0).Rows(0).Item("numpago").ToString) + 1
                                    End If
                                    Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                                        objDataSetAux = objCajaCredito.usp_TraerInfoPagoDet(2, txt_AboSucNota.Text, txt_AboNota.Text, NumPagoAnt)
                                    End Using
                                    If objDataSetAux.Tables(0).Rows.Count > 0 Then
                                        ImporteTotDelPago = CDbl(objDataSetAux.Tables(0).Rows(0).Item("subtotal").ToString)
                                        ImporteTotDelPago += ImpAnticipo
                                        'ImporteTotDelPago += CDbl(objDataSet.Tables(0).Rows(i).Item("abono").ToString)
                                    End If
                                    Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                                        objDataSetAux = objCajaCredito.usp_TraerInfoPagoDet(3, txt_AboSucNota.Text, txt_AboNota.Text, NumPagoAnt)
                                    End Using
                                    If objDataSetAux.Tables(0).Rows.Count > 0 Then
                                        TotDelPago = CDbl(objDataSetAux.Tables(0).Rows(0).Item("subtotal").ToString)
                                    End If
                                    If ImporteTotDelPago >= TotDelPago Then
                                        PagadoElPago = 1
                                    Else
                                        PagadoElPago = 0
                                    End If
                                    Dim SubTotalAnt As Double = 0.0
                                    Dim DesctoAnt As Double = 0.0
                                    If CDbl(objDataSet.Tables(0).Rows(i).Item("vencido").ToString) > 0 Then
                                        Descto = 0
                                    Else
                                        Descto = 12
                                    End If
                                    SubTotalAnt = ImpAnticipo * 100 / (100 - Descto)
                                    DesctoAnt = SubTotalAnt - ImpAnticipo
                                    SubTotPag += SubTotalAnt
                                    Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                                        objCajaCredito.usp_CapturaPagoDet(1, idPago, GLB_CveSucursal, txt_AboSucNota.Text,
                                                                          txt_AboNota.Text, CInt(NumPagoAnt), SubTotalAnt,
                                                                          DesctoAnt, CDbl(objDataSet.Tables(0).Rows(i).Item("dsctoad").ToString), 0.0, 0.0, 0.0, ImpAnticipo,
                                                                          CDbl(objDataSet.Tables(0).Rows(i).Item("vencido").ToString), 0.0, PagoDelPago, PagadoElPago, Descto, 0, 0.0, GLB_Idempleado)
                                    End Using
                                    Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                                        objDataSetAux = objCajaCredito.usp_TraerIdPagoDistrib(2, txt_AboDistrib.Text, GLB_CveSucursal, GLB_Idempleado, txt_AboSucNota.Text, txt_AboNota.Text, NumPagoAnt)
                                    End Using
                                    If objDataSetAux.Tables(0).Rows.Count > 0 Then
                                        idPagoDet = CInt(objDataSetAux.Tables(0).Rows(0).Item("idpagosdet").ToString)
                                    End If
                                    Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                                        blnActualiza = objCajaCredito.usp_ActualizarPlanPagos(1, txt_AboDistrib.Text, txt_AboSucNota.Text, txt_AboNota.Text, CInt(NumPagoAnt), SubTotalAnt,
                                                                               GLB_FechaHoy.ToString("yyyy-MM-dd"), idPagoDet, GLB_Idempleado)
                                    End Using
                                    ImpAnticipo = 0
                                End If
                            Next
                            ''''''FALTA GENERAR EL CORTE
                            Dim SalAnt As Double = 0
                            Dim SalNue As Double = 0
                            Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                                objDataSet = objCajaCredito.usp_TraerDistribuidorCredito(1, txt_AboDistrib.Text, "")
                            End Using
                            If objDataSet.Tables(0).Rows.Count > 0 Then
                                SalAnt = objDataSet.Tables(0).Rows(0).Item("saldo").ToString
                            End If
                            Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                                objCajaCredito.usp_ActualizarSaldoDistrib(1, txt_AboDistrib.Text, SubTotPag)
                            End Using
                            Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                                objDataSet = objCajaCredito.usp_TraerDistribuidorCredito(1, txt_AboDistrib.Text, "")
                            End Using
                            If objDataSet.Tables(0).Rows.Count > 0 Then
                                SalNue = objDataSet.Tables(0).Rows(0).Item("saldo").ToString
                            End If
                            'verificar mreyes   19/Diciembre/2018   05:33 p.m.

                            'Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                            '    objCajaCredito.usp_GenerarCorte(txt_AboDistrib.Text)
                            'End Using
                            Dim SalVenci As Double = 0
                            Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                                objDataSet = objCajaCredito.usp_TraerPlanPagos(1, txt_AboDistrib.Text)
                            End Using
                            If objDataSet.Tables(0).Rows.Count > 0 Then
                                SalVenci = objDataSet.Tables(0).Rows(0).Item("vencido").ToString
                            End If
                            imprimir_Tiquete(SubTotPag, SubTotPag - CDbl(txt_AboAbono.Text), CDbl(txt_AboAbono.Text) + myForm.Cambio, CDbl(txt_AboAbono.Text), myForm.Cambio, 1, FolioAnt, SalAnt, SalNue, txt_AboDistrib.Text, txt_AboDistribNombre.Text, SalVenci)
                        End If
                        MessageBox.Show("Anticipo aplicado correctamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.Close()
                    Else
                        MessageBox.Show("El distribuidor no tiene ningun pago pendiente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'If blnActualiza = True Then
                '    MessageBox.Show("Anticipo aplicado correctamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'Else
                '    MessageBox.Show("Error al guardar el movimiento", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                'End If
                'End If
            End If
        End If

        ''''If Tipo = "CON" Then
        ''''    Dim IdConvenio As Integer = 0
        ''''    Dim DiaIni As Date = GLB_FechaHoy
        ''''    Dim PlazoCon As Integer = 0
        ''''    Dim TipoPago As String = cb_ConPlazo.Text
        ''''    Dim Dias As Integer = 0
        ''''    If txt_ConPlazo.Text.Trim = "" Then
        ''''        txt_ConPlazo.Text = 10
        ''''    End If
        ''''    PlazoCon = txt_ConPlazo.Text
        ''''    If TipoPago = "SEMANAS" Then
        ''''        Dias = 7
        ''''        DiaIni = DiaIni.AddDays(Dias)
        ''''    ElseIf TipoPago = "QUINCENAS" Then
        ''''        Dias = 15
        ''''        DiaIni = DiaIni.AddDays(Dias)
        ''''    ElseIf TipoPago = "MESES" Then
        ''''        Dias = 30
        ''''        DiaIni = DiaIni.AddDays(Dias)
        ''''    End If
        ''''    Dim myForm As New frmConvenio
        ''''    myForm.DiaIni = DiaIni
        ''''    myForm.TotalPago = txt_ConApagar.Text
        ''''    myForm.Plazo = PlazoCon
        ''''    myForm.Dias = Dias
        ''''    myForm.StartPosition = FormStartPosition.CenterScreen
        ''''    myForm.ShowDialog()
        ''''    If myForm.blnConvenio = False Then
        ''''        MessageBox.Show("Debes ingresar todos los datos", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ''''        Exit Sub
        ''''    End If
        ''''    If MessageBox.Show("Esta seguro que deseas generar el convenio", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.No Then Exit Sub
        ''''    '' generar estatus 
        ''''    '' mreyes   15/Febrero/2016 11:13 a.m.
        ''''    Dim blnCambio As Boolean = False
        ''''    Using objdistrib As New BCL.BCLCatalogoDistribuidor(GLB_ConStringCredito)
        ''''        blnCambio = objdistrib.usp_ActualizarEstatus(1, txt_ConDistrib.Text, "S")
        ''''    End Using


        ''''    Dim myFormPago As New frmFormasPagoCredito
        ''''    myFormPago.txt_TotalEfe.Visible = False
        ''''    myFormPago.txt_SubtotalEfe.Visible = False
        ''''    myFormPago.txt_DescuentoEfe.Visible = False
        ''''    myFormPago.lbl_TotalEfe.Visible = False
        ''''    myFormPago.lbl_SubtotalEfe.Visible = False
        ''''    myFormPago.lbl_DescuentoEfe.Visible = False
        ''''    myFormPago.Txt_Distrib.Text = txt_ConDistrib.Text
        ''''    myFormPago.Txt_NombreDistrib.Text = txt_ConDistribNombre.Text
        ''''    myFormPago.Importe = CDbl(txt_ConAnticipo.Text)
        ''''    TraerFolioPago()
        ''''    myFormPago.Folio = FolioAnt
        ''''    If txt_ConAnticipo.Text.Trim = "" Then
        ''''        txt_ConAnticipo.Text = "0.00"
        ''''    End If
        ''''    myFormPago.txt_TotalEfe.Text = txt_ConAnticipo.Text
        ''''    myFormPago.txt_RecibeEfe.Text = txt_ConAnticipo.Text
        ''''    myFormPago.StartPosition = FormStartPosition.CenterScreen
        ''''    myFormPago.ShowDialog()
        ''''    If myFormPago.blnPago = False Then
        ''''        MessageBox.Show("Es necesario ingresar el pago del anticipo", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ''''        Exit Sub
        ''''    End If
        ''''    If myFormPago.ImportePago <> CDbl(txt_ConAnticipo.Text) Then
        ''''        MessageBox.Show("El importe pagado debe ser igual al anticipo", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ''''        Exit Sub
        ''''    End If
        ''''    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ''''    TraerFolioPago()
        ''''    Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
        ''''        blnActualiza = objCajaCredito.usp_CapturaPago(1, GLB_CveSucursal, FolioAnt, txt_ConDistrib.Text, "AP", GLB_FechaHoy.ToString("yyyy-MM-dd HH:mm:ss"),
        ''''                                       0.0, 0.0, 0.0, 0.0, 0.0, 0.0,
        ''''                                       CDbl(txt_ConAnticipo.Text), 0.0, 0.0, Cobrador, 0, GLB_Idempleado, 0)
        ''''    End Using
        ''''    Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
        ''''        objDataSet = objCajaCredito.usp_TraerIdPagoDistrib(1, txt_ConDistrib.Text, GLB_CveSucursal, GLB_Idempleado, "", "", 0)
        ''''    End Using
        ''''    Dim idPago As Integer = 0
        ''''    If objDataSet.Tables(0).Rows.Count > 0 Then
        ''''        idPago = CInt(objDataSet.Tables(0).Rows(0).Item("idpago").ToString)
        ''''        For i As Integer = 0 To myFormPago.objDataSetFP.Tables(0).Rows.Count - 1
        ''''            GuardaFormasDePago(idPago, myFormPago.objDataSetFP)
        ''''        Next
        ''''        Dim SalAnt As Double = 0
        ''''        Dim SalNue As Double = 0
        ''''        Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
        ''''            objDataSet = objCajaCredito.usp_TraerDistribuidorCredito(1, txt_ConDistrib.Text, "")
        ''''        End Using
        ''''        If objDataSet.Tables(0).Rows.Count > 0 Then
        ''''            SalAnt = objDataSet.Tables(0).Rows(0).Item("saldo").ToString
        ''''        End If
        ''''        Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
        ''''            objCajaCredito.usp_ActualizarSaldoDistrib(1, txt_ConDistrib.Text, txt_ConAnticipo.Text + IIf(rb_ConSaldo.Checked, CDbl(txt_ConSaldo.Text) - CDbl(txt_ConAnticipo.Text) - CDbl(txt_ConApagar.Text), CDbl(txt_ConVencido.Text) - CDbl(txt_ConAnticipo.Text) - CDbl(txt_ConApagar.Text)))
        ''''        End Using
        ''''        Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
        ''''            objDataSet = objCajaCredito.usp_TraerDistribuidorCredito(1, txt_ConDistrib.Text, "")
        ''''        End Using
        ''''        If objDataSet.Tables(0).Rows.Count > 0 Then
        ''''            SalNue = objDataSet.Tables(0).Rows(0).Item("saldo").ToString
        ''''        End If
        ''''        imprimir_Tiquete(txt_ConAnticipo.Text + IIf(rb_ConSaldo.Checked, CDbl(txt_ConSaldo.Text) - CDbl(txt_ConAnticipo.Text) - CDbl(txt_ConApagar.Text), CDbl(txt_ConVencido.Text) - CDbl(txt_ConAnticipo.Text) - CDbl(txt_ConApagar.Text)), IIf(rb_ConSaldo.Checked, CDbl(txt_ConSaldo.Text) - CDbl(txt_ConAnticipo.Text) - CDbl(txt_ConApagar.Text), CDbl(txt_ConVencido.Text) - CDbl(txt_ConAnticipo.Text) - CDbl(txt_ConApagar.Text)), myFormPago.ImportePago + myFormPago.Cambio, myFormPago.ImportePago, myFormPago.Cambio, 1, FolioAnt, SalAnt, SalNue, txt_ConDistrib.Text, txt_ConDistribNombre.Text, 0)
        ''''    End If
        ''''    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ''''    'Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditosql)
        ''''    '    blnActualiza = objCajaCredito.usp_CapturaConvenio(1, 0, txt_ConDistrib.Text, IIf(rb_ConSaldo.Checked, "S", "V"), 0, GLB_FechaHoy.ToString("yyyy-MM-dd"), CDbl(txt_ConAnticipo.Text) + CDbl(txt_ConApagar.Text), CDbl(txt_ConDescuento.Text), CInt(txt_ConCobrador.Text), _
        ''''    '                                                      txt_ConPlazo.Text & cb_ConPlazo.Text, cb_ConMotivo.SelectedValue, myForm.txt_Observaciones.Text, GLB_Idempleado, 0, "1900-01-01")
        ''''    'End Using
        ''''    'Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditosql)
        ''''    '    objDataSet = objCajaCredito.usp_TraerConvenio(1, GLB_FechaHoy.ToString("yyyy-MM-dd"), txt_ConDistrib.Text, GLB_Idempleado)
        ''''    'End Using
        ''''    'If objDataSet.Tables(0).Rows.Count > 0 Then
        ''''    '    IdConvenio = objDataSet.Tables(0).Rows(0).Item("idconvenio").ToString
        ''''    'End If
        ''''    'For i As Integer = 0 To myForm.DGrid.Rows.Count - 1
        ''''    '    Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditosql)
        ''''    '        objCajaCredito.usp_CapturaConvenioDet(1, IdConvenio, CDate(myForm.DGrid.Rows(i).Cells("col_fecha").Value).ToString("yyyy-MM-dd"), myForm.DGrid.Rows(i).Cells("col_pago").Value, txt_ConPlazo.Text, CDate(myForm.DGrid.Rows(i).Cells("col_fecha").Value).ToString("yyyy-MM-dd"), CDbl(myForm.DGrid.Rows(i).Cells("col_importe").Value), _
        ''''    '                                              0, 0, 0, 0, "0", "1900-01-01", "", 0, 0, 0)
        ''''    '    End Using
        ''''    'Next
        ''''    Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
        ''''        blnActualiza = objCajaCredito.usp_GenerarConvenio(IIf(rb_ConSaldo.Checked, 2, 1), 0, txt_ConDistrib.Text, IIf(rb_ConSaldo.Checked, "S", "V"), 0, GLB_FechaHoy.ToString("yyyy-MM-dd"), CDbl(txt_ConAnticipo.Text) + CDbl(txt_ConApagar.Text), CDbl(txt_ConDescuento.Text), CInt(txt_ConCobrador.Text),
        ''''                                                          txt_ConPlazo.Text & cb_ConPlazo.Text, cb_ConMotivo.SelectedValue, myForm.txt_Observaciones.Text, GLB_Idempleado, 0, "1900-01-01")
        ''''    End Using
        ''''    Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
        ''''        objDataSet = objCajaCredito.usp_TraerConvenio(1, GLB_FechaHoy.ToString("yyyy-MM-dd"), txt_ConDistrib.Text, GLB_Idempleado)
        ''''    End Using
        ''''    If objDataSet.Tables(0).Rows.Count > 0 Then
        ''''        IdConvenio = objDataSet.Tables(0).Rows(0).Item("idconvenio").ToString
        ''''    End If
        ''''    TraerSiguienteFolioMovimiento()
        ''''    Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
        ''''        blnActualiza = objCajaCredito.usp_CapturaMovimiento(Folio, txt_ConDistrib.Text, "CON", 0, 0, IdConvenio, "", "", "1900-01-01", 0, 0,
        ''''                                                            GLB_FechaHoy.ToString("yyyy-MM-dd"), 0.0, 0.0, GLB_Idempleado,
        ''''                                                             0)
        ''''    End Using
        ''''    Dim FolioNota As String = "0"
        ''''    Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
        ''''        objDataSet = objCajaCredito.usp_TraerFolioNota(GLB_CveSucursal)
        ''''    End Using
        ''''    If objDataSet.Tables(0).Rows.Count > 0 Then
        ''''        FolioNota = objDataSet.Tables(0).Rows(0).Item("nota").ToString
        ''''        FolioNota = pub_RellenarIzquierda(FolioNota, 6)
        ''''    End If
        ''''    Dim IdPlazo As Integer = 0
        ''''    'If cb_ConPlazo.Text = "SEMANAS" Then
        ''''    '    IdPlazo = 7
        ''''    'ElseIf cb_ConPlazo.Text = "QUINCENAS" Then
        ''''    '    IdPlazo = 15
        ''''    'ElseIf cb_ConPlazo.Text = "MESES" Then
        ''''    '    IdPlazo = 30
        ''''    'Else
        ''''    '    IdPlazo = 15
        ''''    'End If
        ''''    Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
        ''''        objCajaCredito.usp_CapturaCargo(GLB_CveSucursal, FolioNota, "AP", GLB_FechaHoy.ToString("yyyy-MM-dd"), txt_ConDistrib.Text, 0,
        ''''                                         0, 0, "CO", "CONVENIO", CDbl(txt_ConApagar.Text), 0, CDate(myForm.DGrid.Rows(0).Cells("col_fecha").Value),
        ''''                                         IdPlazo, CInt(txt_ConPlazo.Text), GLB_Idempleado, "SE GENERA CARGO POR CONVENIO")
        ''''    End Using
        ''''    Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
        ''''        blnActualiza = objCajaCredito.usp_CapturaPlanPagosConvenio(GLB_CveSucursal, FolioNota, txt_ConDistrib.Text)
        ''''    End Using
        ''''    For i As Integer = 0 To myForm.DGrid.Rows.Count - 1
        ''''        Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
        ''''            objCajaCredito.usp_CapturaPlanPagosDetConvenio(GLB_CveSucursal, FolioNota, CDate(myForm.DGrid.Rows(i).Cells("col_fecha").Value).ToString("yyyy-MM-dd"), myForm.DGrid.Rows(i).Cells("col_pago").Value, txt_ConPlazo.Text, CDate(myForm.DGrid.Rows(i).Cells("col_fecha").Value).ToString("yyyy-MM-dd"), CDbl(myForm.DGrid.Rows(i).Cells("col_importe").Value))
        ''''        End Using
        ''''    Next
        ''''    'verificar mreyes   19/Diciembre/2018   05:31 p.m.

        ''''    'Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
        ''''    '    objCajaCredito.usp_GenerarCorte(txt_ConDistrib.Text)
        ''''    'End Using
        ''''    If blnActualiza = True Then
        ''''        MessageBox.Show("Convenio generado correctamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ''''        Me.Close()
        ''''    End If
        ''''End If
    End Sub

    Private Sub TraerFolioPago()
        Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
            objDataSet = objCajaCredito.usp_TraerFolioPago(GLB_CveSucursal)
        End Using
        If objDataSet.Tables(0).Rows.Count > 0 Then
            FolioAnt = objDataSet.Tables(0).Rows(0).Item("folio").ToString
            FolioAnt = CInt(FolioAnt) + 1
            FolioAnt = pub_RellenarIzquierda(FolioAnt, 6)
            ' FolioAnt = FolioAnt
        End If
    End Sub

    Private Function GuardaFormasDePago(ByVal IdPago As Integer, ByVal objDataSetFormasPago As DataSet) As Boolean
        Dim Importe As Double = 0
        Dim Dolares As Double = 0
        Dim Cambio As Double = 0
        Dim Estatus As String = ""
        Dim Emisor As String = ""
        Dim NoTarjeta As String = ""
        Dim Autorizacion As String = ""
        Dim RutaBancaria As String = ""
        Dim NoCuenta As String = ""
        Dim NoCheque As String = ""
        Dim IdActivos As Integer = 0
        Dim Articulo As String = ""
        Dim Tipo As String = ""
        Dim Marca As String = ""
        Dim NumSerie As String = ""
        Dim Nuevo As Integer = 0
        Dim ImpComercial As Double = 0.0
        Dim Comercio As String = ""
        Dim ImpAdquirido As Double = 0.0
        Dim ImpVenta As Double = 0.0
        Dim blnGuardo As Boolean = False
        Dim blnGuardoAct As Boolean = False
        Dim ErrorGuardar As Integer = 0
        'EFE = EFECTIVO, TAC = TARJETA DE CREDITO, TAD = TARJETA DE DEBITO, CHE = CHEQUE, ACT = ACTIVOS, PAA = PAGO ADELANTADO
        For i As Integer = 0 To objDataSetFormasPago.Tables(0).Rows.Count - 1
            blnGuardo = False
            blnGuardoAct = False
            Importe = 0
            Dolares = 0
            Cambio = 0
            Estatus = ""
            Emisor = ""
            NoTarjeta = ""
            Autorizacion = ""
            RutaBancaria = ""
            NoCuenta = ""
            NoCheque = ""
            IdActivos = 0
            Articulo = ""
            Tipo = ""
            Marca = ""
            NumSerie = ""
            Nuevo = 0
            ImpComercial = 0.0
            Comercio = ""
            ImpAdquirido = 0.0
            ImpVenta = 0.0
            If objDataSetFormasPago.Tables(0).Rows(i).Item("formapago").ToString = "EFE" Then
                Importe = CDbl(objDataSetFormasPago.Tables(0).Rows(i).Item("importe").ToString)
                Cambio = CDbl(objDataSetFormasPago.Tables(0).Rows(i).Item("cambio").ToString)
                Estatus = "AP"
            End If
            If objDataSetFormasPago.Tables(0).Rows(i).Item("formapago").ToString = "DOL" Then
                Dolares = CDbl(objDataSetFormasPago.Tables(0).Rows(i).Item("dolares").ToString)
                Cambio = CDbl(objDataSetFormasPago.Tables(0).Rows(i).Item("cambio").ToString)
                Estatus = "AP"
            End If
            If objDataSetFormasPago.Tables(0).Rows(i).Item("formapago").ToString = "TAC" Or objDataSetFormasPago.Tables(0).Rows(i).Item("formapago").ToString = "TAD" Then
                Emisor = objDataSetFormasPago.Tables(0).Rows(i).Item("emisor").ToString
                NoTarjeta = objDataSetFormasPago.Tables(0).Rows(i).Item("notarjeta").ToString
                Autorizacion = objDataSetFormasPago.Tables(0).Rows(i).Item("autorizacion").ToString
                Importe = CDbl(objDataSetFormasPago.Tables(0).Rows(i).Item("importe").ToString)
                Estatus = "AP"
            End If
            If objDataSetFormasPago.Tables(0).Rows(i).Item("formapago").ToString = "CHE" Then
                RutaBancaria = objDataSetFormasPago.Tables(0).Rows(i).Item("rutabancaria").ToString
                NoCuenta = objDataSetFormasPago.Tables(0).Rows(i).Item("nocuenta").ToString
                NoCheque = objDataSetFormasPago.Tables(0).Rows(i).Item("nocheque").ToString
                Importe = CDbl(objDataSetFormasPago.Tables(0).Rows(i).Item("importe").ToString)
                Estatus = "AP"
            End If
            If objDataSetFormasPago.Tables(0).Rows(i).Item("formapago").ToString = "ACT" Then
                Articulo = objDataSetFormasPago.Tables(0).Rows(i).Item("articulo").ToString
                Tipo = objDataSetFormasPago.Tables(0).Rows(i).Item("tipo").ToString
                Marca = objDataSetFormasPago.Tables(0).Rows(i).Item("marca").ToString
                NumSerie = objDataSetFormasPago.Tables(0).Rows(i).Item("numserie").ToString
                Nuevo = objDataSetFormasPago.Tables(0).Rows(i).Item("nuevo").ToString
                ImpComercial = objDataSetFormasPago.Tables(0).Rows(i).Item("impcomercial").ToString
                Comercio = objDataSetFormasPago.Tables(0).Rows(i).Item("comercio").ToString
                Importe = objDataSetFormasPago.Tables(0).Rows(i).Item("impadquirido").ToString
                ImpVenta = objDataSetFormasPago.Tables(0).Rows(i).Item("impventa").ToString
                Estatus = "AP"
                '' verificar mreyes 19/Diciembre/2018   06:28 p.m.
                ''''Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                ''''    blnGuardoAct = objCajaCredito.usp_CapturaActivos(1, 1, Articulo, Tipo, Marca, NumSerie, Nuevo,
                ''''                                                      ImpComercial, Comercio, ImpAdquirido, ImpVenta, GLB_Idempleado)
                ''''End Using
                ''''If blnGuardoAct = True Then
                ''''    Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                ''''        objDataSet = objCajaCredito.usp_TraerActivos(1, Articulo, Tipo, Marca, NumSerie, GLB_Idempleado)
                ''''    End Using
                ''''    If objDataSet.Tables(0).Rows.Count > 0 Then
                ''''        IdActivos = CInt(objDataSet.Tables(0).Rows(0).Item("idactivos").ToString)
                ''''    End If
                ''''End If
            End If
            Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                blnGuardo = objCajaCredito.usp_CapturaTipoPagos(1, IdPago, GLB_CveSucursal, objDataSetFormasPago.Tables(0).Rows(i).Item("formapago").ToString, Estatus, GLB_FechaHoy.ToString("yyyy-MM-dd hh:mm:ss"),
                                                  Importe, Dolares, Cambio, Emisor, NoTarjeta, Autorizacion, RutaBancaria, NoCuenta, NoCheque, IdActivos, GLB_Idempleado)
            End Using
            If blnGuardo = False Then
                ErrorGuardar += 1
            End If
        Next
        If ErrorGuardar > 0 Then
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub imprimir_Tiquete(ByVal ImpBruto As Double, ByVal Descto As Double, ByVal recibido As Double, ByVal total As Double, ByVal cambio As Double, ByVal tipo_Tiquete As Integer, ByVal FolioPago As String, ByVal SaldoAnterior As Double, ByVal SaldoNuevo As Double, ByVal Distrib As String, ByVal NombreDistrib As String, ByVal SaldoVencido As Double)
        Try
            '**********************************
            '// La clase "CreaTicket" tiene varios metodos para imprimir con diferentes formatos (izquierda, derecha, centrado, desripcion precio,etc), a
            '   // continuacion se muestra el metodo con ejemplo de parametro que acepta, longitud maxima y un ejemplo de como imprimira, esta clase esta 
            '   // basada en una impresora Epson de matriz de puntos con impresion maxima de 40 caracteres por renglon
            '   // METODO                                      MAX_LONG                        EJEMPLOS
            '   //--------------------------------------------------------------------------------------------------------------------------
            '   // TextoIzquierda("Empleado 1")                    40                      Empleado 1      
            '   // TextoDerecha("Caja 1")                          40                                                        Caja 1
            '   // TextoCentro("Ticket")                           40                                         Ticket   
            '   // TextoExtremos("Fecha 6/1/2011","Hora:13:25")     18 y 18                 Fecha 6/1/2011                Hora:13:25
            '   // EncabezadoVenta()                                n/a                     Articulo        Can    P.Unit    Importe
            '   // LineasGuion()                                    n/a                     ----------------------------------------
            '   // AgregaArticulo("Aspirina","2",45.25,90.5)        16,3,10,11              Aspirina          2    $45.25     $90.50
            '   // LineasTotales()                                  n/a                                                ----------
            '   // AgregaTotales("Subtotal",235.25)                 25 y 15                Subtotal                         $235.25
            '   // LineasAsterisco()                                n/a                     ****************************************
            '   // LineasIgual()                                    n/a                     ========================================
            '   // CortaTicket()
            '   // AbreCajon()

            'Dim Cant As String
            'Dim Descp As String
            'Dim Totallinea As String
            Dim Hora As String
            Hora = DateTime.Now.ToString("h:mm:ss")
            'Dim total As String

            'Dim Ticket1 As New CreaTicket()
            'Ticket1.impresora = "Nombre de la impresora"
            'Ticket1.impresora = "EPSON TM-U220 Receipt"
            'Ticket1.impresora = "Movs"
            'Ticket1.AbreCajon()
            'Ticket1.TextoCentro("ZAPATERIAS TORREON")
            'Ticket1.TextoCentro("CALZADO DE TORREON S.A. DE C.V.")
            'Ticket1.TextoCentro("TEL.")
            'Ticket1.TextoCentro("")
            'Ticket1.LineasIgual()
            'Ticket1.TextoIzquierda("NOTA : " + ("1000"))
            'Ticket1.TextoIzquierda("CLIENTE : " + "")
            'Ticket1.TextoIzquierda("CAJERO  : " + "")
            'Ticket1.TextoCentro("Ticket")
            'Ticket1.TextoExtremos("FECHA : " + DateTime.Now.ToShortDateString() + " ", "HORA : " + Hora)

            Dim observaciones As String = ""
            Select Case tipo_Tiquete
                Case 1
                    observaciones = "PRUEBA" 'txt_Observacion.Text
                    imprimir_Ticket_Abono(ImpBruto, Descto, recibido, total, cambio, tipo_Tiquete, FolioPago, SaldoAnterior, SaldoNuevo, Distrib, NombreDistrib, SaldoVencido)
                Case 2
                    'Call imprimir_Tiquete_Adelanto_Pago(recibido)
                    '    observaciones = "ADELANTO PROGRAMADO PROGRAMADO  " + Chr(13) + " AL CORTE : "
                    'Case 3
            End Select

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        Finally
        End Try
    End Sub

    Private Sub imprimir_Ticket_Abono(ByVal ImpBruto As Double, ByVal Descto As Double, ByVal recibido As Double, ByVal total As Double, ByVal cambio As Double, ByVal tipo_Tiquete As Integer, ByVal FolioPago As String, ByVal SaldoAnterior As Double, ByVal SaldoNuevo As Double, ByVal Distrib As String, ByVal NombreDistrib As String, ByVal SaldoVencido As Double)
        Try
            Dim Hora As String
            Hora = DateTime.Now.ToString("h:mm:ss")
            'obtener informacion en MESSAJEBOX 
            'MessageBox.Show("ZAPATERIAS TORREON" & Chr(13) & _
            '"CALZADO DE TORREON S.A. DE C.V." & Chr(13) & _
            '"TEL." & Chr(13) & _
            '"" & Chr(13) & _
            '"=================================" & Chr(13) & _
            '"NOTA : " + FolioPago & Chr(13) & _
            '"CLIENTE : " + " " & txt_Distrib.Text & Chr(13) & txt_NombreDistrib.Text & Chr(13) & _
            '"CAJERO :" + GLB_Idempleado.ToString & " " & GLB_Usuario & Chr(13) & _
            '"Ticket " + Chr(13) & _
            '"FECHA : " + Now() + Chr(13) & _
            '"=================================" & Chr(13) & _
            '"=================================" & Chr(13) & _
            '"TOTAL : $ " & total & Chr(13) & _
            '"RECIBIDO : $ " & recibido & Chr(13) & _
            '"CAMBIO  : $ " & cambio & Chr(13) & _
            '"-----------------" & Chr(13) & _
            '"")

            '-- -----------------------------------------------------
            Dim Ticket1 As New CreaTicket()

            'Ticket1.impresora = "EPSON TM-U220 Receipt"
            Ticket1.impresora = "LR2000"
            Ticket1.AbreCajon()
            Ticket1.TextoCentro("ZAPATERIAS TORREON")
            'Ticket1.TextoCentro("CALZADO DE TORREON S.A. DE C.V.")
            Ticket1.TextoCentro("TEL. 711-46-52")
            Ticket1.TextoCentro("")
            Ticket1.LineasIgual()
            Ticket1.TextoIzquierda("SUCURSAL : " + GLB_CveSucursal + " - " + GLB_Sucursal)
            Ticket1.TextoIzquierda("FOLIO : " + FolioPago)
            Ticket1.TextoIzquierda("CLIENTE : " + Distrib)
            Ticket1.TextoIzquierda(NombreDistrib)
            Ticket1.TextoIzquierda("CAJERO :" + GLB_Idempleado.ToString & " " & GLB_Usuario)
            Ticket1.TextoCentro("      ")
            Ticket1.TextoCentro("RECIBO DE PAGO")
            Ticket1.TextoCentro("      ")
            Ticket1.TextoExtremos("FECHA : " + GLB_FechaHoy.ToString("dd/MMM/yyyy").ToUpper + " ", "HORA : " + Hora)
            Ticket1.TextoCentro("      ")
            'Ticket1.TextoIzquierda("NUMERO DE VALES : " + "0")
            'Ticket1.TextoIzquierda("TIPO DE PAGO : " + "FOR")
            Ticket1.TextoCentro("      ")
            Ticket1.AgregaTotales(" ABONADO A CUENTA", FormatCurrency(ImpBruto))
            Ticket1.AgregaTotales("        DESCUENTO", FormatCurrency(Descto))
            Ticket1.AgregaTotales("            TOTAL", FormatCurrency(total))
            Ticket1.AgregaTotales("         RECIBIDO", FormatCurrency(recibido))

            Ticket1.LineasTotales()
            Ticket1.AgregaTotales("         CAMBIO", FormatCurrency(cambio))

            Ticket1.TextoCentro("      ")
            Ticket1.TextoCentro("      ")
            Ticket1.TextoIzquierda("      SALDO ANTERIOR : " + FormatCurrency(SaldoAnterior))
            Ticket1.TextoIzquierda("             ABONADO : " + FormatCurrency(ImpBruto))
            Ticket1.TextoIzquierda("        SALDO ACTUAL : " + FormatCurrency(SaldoNuevo))
            Ticket1.TextoCentro("      ")
            Ticket1.AgregaTotales(" TOTAL SALDO VENCIDO : ", FormatCurrency(SaldoVencido))
            Ticket1.AgregaTotales("TOTAL SALDO X VENCER : ", FormatCurrency(SaldoNuevo - SaldoVencido))
            Ticket1.LineasTotales()
            Ticket1.AgregaTotales("         TOTAL SALDO : ", FormatCurrency(SaldoNuevo))
            Ticket1.TextoCentro("             ")
            Ticket1.TextoCentro("*SALDO AL " & GLB_FechaHoy.ToString("dd/MMM/yyyy").ToUpper & " a las " & Hora)
            Ticket1.CortaTicket()
            '-- -----------------------------------------------------
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Sub pnl_Datos_Paint(sender As Object, e As PaintEventArgs) Handles pnl_Datos.Paint

    End Sub

    Private Sub frmMovimientosEspecialesCredito_Activated(sender As Object, e As EventArgs) Handles Me.Activated

    End Sub

#End Region


End Class