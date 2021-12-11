Imports SIRCO.Caja.ModCaja
Imports System.Drawing.Printing

Imports LibPrintTicketMatriz.Class1

Public Class frmPpalCajaCredito

#Region "VARIABLES"
    Private objDataSet As New DataSet
    Private Distribuidor As String = ""
    Private Opcion As Integer = 0
    Private Folio As String = ""
    Private blnDescuento As Boolean = False
    Private DescuentoEspecial As Double = 0
    Private Cobrador As Integer = 0
    Private blnConvenio As Boolean = False
#End Region

#Region "EVENTOS"

#Region "FORMA"

    Private Sub frmPpalCajaCredito_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            GLB_CveSucursal = "20"
            GLB_FechaHoy = pub_TraerFechaHoy()
            blnDescuento = False
            Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                objDataSet = objCajaCredito.usp_TraerPermisosCaja(GLB_IdDeptoEmpleado, GLB_IdPuestoEmpleado, "CAJ", "DESCUENTO")
            End Using
            If objDataSet.Tables(0).Rows.Count > 0 Then
                btn_DesctoEspecial.Enabled = True
            Else
                btn_DesctoEspecial.Enabled = False
            End If
            'GLB_ConStringCredito = "Driver={MySQL ODBC 5.1 Driver};server=10.10.1.1;uid=root;pwd=z4pt0r;database=credito;port=3306;no_bigint=1"
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub frmCajaCredito_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

#End Region

#Region "TEXT BOX"

    Private Sub txt_Distrib_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_Distrib.GotFocus

    End Sub

    Private Sub txt_Distrib_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Distrib.LostFocus
        Try
            If txt_Distrib.Text.Trim = "" Then Exit Sub
            GLB_FechaHoy = pub_TraerFechaHoy()
            Distribuidor = pub_RellenarIzquierda(txt_Distrib.Text, 6)
            txt_Distrib.Text = pub_RellenarIzquierda(txt_Distrib.Text, 6)

            '' Buscar si existe o no el distribuidor.
            '' mreyes 19/Febrero/2019   05:25 p.m.

            Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                objDataSet = objCajaCredito.usp_TraerDistribuidorCredito(1, txt_Distrib.Text, "")
            End Using
            If objDataSet.Tables(0).Rows.Count > 0 Then
                txt_NombreDistrib.Text = objDataSet.Tables(0).Rows(0).Item("nombrecompleto").ToString
                If TieneConvenio() Then
                    'MessageBox.Show("El distribuidor seleccionado tiene convenio", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    blnConvenio = True
                    TraerConvenio()
                    Cobrador = CInt(DGrid.Rows(0).Cells("cobrador").Value)
                    btn_Historial.Visible = True
                    Exit Sub
                Else
                    blnConvenio = False
                End If
                Opcion = 1
                RellenaInformacionPago()
            Else
                Dim myForm As New frmConsulta
                myForm.Tipo = "DI"
                myForm.ShowDialog()
                If myForm.blnConsultoDistrib = False Then
                    txt_Distrib.Text = ""
                    txt_NombreDistrib.Text = ""
                    Cobrador = 0
                    txt_Distrib.Focus()
                    Exit Sub
                End If
                txt_Distrib.Text = pub_RellenarIzquierda(myForm.Campo, 6)
                '  txt_NombreDistrib.Text = myForm.Campo1
                'Cobrador = myForm.Campo2
                txt_Distrib.Focus()
                DGrid.Focus()
            End If




        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub txt_Distrib_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Distrib.TextChanged
        Try
            If txt_Distrib.Text.Trim = "" Then Exit Sub
            ''If txt_Distrib.Text = "003085" Then
            ''    frmPagoVisitaDistrib.Label10.Visible = True
            ''    frmPagoVisitaDistrib.Label8.Visible = True
            ''    frmPagoVisitaDistrib.txt_folio.Visible = True
            ''    frmPagoVisitaDistrib.txt_importe.Visible = True
            ''    frmPagoVisitaDistrib.Show()
            ''    Exit Sub
            ''End If

            If IsNumeric(txt_Distrib.Text) Then
                Exit Sub
            Else
                If txt_Distrib.Text.Trim = "?" Then
                    '  txt_Distrib_LostFocus(sender, e)
                Else
                    txt_Distrib.Text = txt_Distrib.Text.Substring(0, txt_Distrib.Text.Length - 1)
                End If
            End If

            
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

#End Region

#Region "BOTON"

    Private Sub btn_Pagar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Pagar.Click
        Try
            If txt_Distrib.Text.Trim = "" Then Exit Sub
            Dim myForm As New frmFormasPagoCredito
            Dim blnEncabezadoPago As Boolean = False
            Dim sw_GeneraDetallePago As Boolean = False
            Dim idPago As Integer = 0
            Dim idPagoDet As Integer = 0
            Dim NumPago As String = ""
            Dim PagoDelPago As Integer = 0
            Dim ImporteTotDelPago As Double = 0
            Dim TotDelPago As Double = 0
            Dim PagadoElPago As Integer = 0
            Dim objDataSetAux As DataSet


            'Dim SalAnt As Double = 0
            'Dim SalNue As Double = 0
            'Dim SalVenci As Double = 0


            myForm.StartPosition = FormStartPosition.CenterParent
            myForm.Txt_Distrib.Text = txt_Distrib.Text
            myForm.Txt_NombreDistrib.Text = txt_NombreDistrib.Text
            myForm.Subtotal = txt_Subtotal.Text
            myForm.Descuento = txt_Descuento.Text
            myForm.Importe = txt_Pagar.Text
            TraerFolioPago() 'revisar mreyes 14/12
            myForm.Folio = Folio
            myForm.ShowDialog()
            myForm.txt_RecibeEfe.Focus()
            'If blnConvenio = True Then
            '    Dim IdConvenio As Integer = CInt(DGrid.Rows(0).Cells("idconvenio").Value)
            '    If myForm.blnPago = True Then
            '        If CDbl(myForm.ImportePago) = CDbl(txt_Pagar.Text) Then
            '            TraerFolioPago()
            '            Using objCajaCredito As New BCL.BCLCajaCredito(GLB_ConStringCredito)
            '                blnEncabezadoPago = objCajaCredito.usp_CapturaPago(1, GLB_CveSucursal, Folio, Distribuidor, "AP", GLB_FechaHoy.ToString("yyyy-MM-dd HH:mm:ss"), _
            '                                               CDbl(txt_Subtotal.Text), CDbl(txt_Descuento.Text) - CDbl(txt_DescuentoAdicional.Text), CDbl(txt_DescuentoAdicional.Text), 0.0, 0.0, 0.0, _
            '                                               CDbl(txt_Pagar.Text), CDbl(txt_Vencido.Text), 0.0, Cobrador, IdConvenio, GLB_Idempleado, GLB_FechaHoy.ToString("yyyy-MM-dd HH:mm:ss"), 0, "1900-01-01 00:00:00")
            '            End Using
            '            Using objCajaCredito As New BCL.BCLCajaCredito(GLB_ConStringCredito)
            '                objDataSet = objCajaCredito.usp_TraerIdPagoDistrib(1, Distribuidor, GLB_CveSucursal, GLB_Idempleado, "", "", 0)
            '            End Using
            '            If objDataSet.Tables(0).Rows.Count > 0 Then
            '                idPago = CInt(objDataSet.Tables(0).Rows(0).Item("idpago").ToString)
            '                Using objCajaCredito As New BCL.BCLCajaCredito(GLB_ConStringCredito)
            '                    objCajaCredito.usp_ActualizarConvenio(1, IdConvenio, CInt(DGrid.Rows(0).Cells("pago").Value), CDbl(txt_Pagar.Text), _
            '                                                            GLB_FechaHoy.ToString("yyyy-MM-dd"), idPago, Cobrador, GLB_Idempleado)
            '                End Using
            '                blnEncabezadoPago = GuardaFormasDePago(idPago, myForm.objDataSetFP)
            '                Dim SalAnt As Double = 0
            '                Dim SalNue As Double = 0
            '                Dim SalVenci As Double = 0
            '                If blnEncabezadoPago = True Then
            '                    Using objCajaCredito As New BCL.BCLCajaCredito(GLB_ConStringCredito)
            '                        objDataSet = objCajaCredito.usp_TraerDistribuidorCredito(1, Distribuidor, "")
            '                    End Using
            '                    If objDataSet.Tables(0).Rows.Count > 0 Then
            '                        SalAnt = objDataSet.Tables(0).Rows(0).Item("saldo").ToString
            '                    End If
            '                    Using objCajaCredito As New BCL.BCLCajaCredito(GLB_ConStringCredito)
            '                        objCajaCredito.usp_ActualizarSaldoDistrib(1, Distribuidor, CDbl(txt_Subtotal.Text))
            '                    End Using
            '                    Using objCajaCredito As New BCL.BCLCajaCredito(GLB_ConStringCredito)
            '                        objDataSet = objCajaCredito.usp_TraerDistribuidorCredito(1, Distribuidor, "")
            '                    End Using
            '                    If objDataSet.Tables(0).Rows.Count > 0 Then
            '                        SalNue = objDataSet.Tables(0).Rows(0).Item("saldo").ToString
            '                    End If
            '                    Using objCajaCredito As New BCL.BCLCajaCredito(GLB_ConStringCredito)
            '                        objCajaCredito.usp_GenerarCorte(Distribuidor)
            '                    End Using
            '                    Using objCajaCredito As New BCL.BCLCajaCredito(GLB_ConStringCredito)
            '                        objDataSet = objCajaCredito.usp_TraerPlanPagos(1, Distribuidor)
            '                    End Using
            '                    If objDataSet.Tables(0).Rows.Count > 0 Then
            '                        SalVenci = objDataSet.Tables(0).Rows(0).Item("vencido").ToString
            '                    End If
            '                Else
            '                    MessageBox.Show("Error al guardar la forma de Pago", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '                    Exit Sub
            '                End If
            '                'If myForm.txt_RecibeEfe.Text.Trim <> "" Then
            '                '    imprimir_Tiquete(myForm.txt_RecibeEfe.Text, txt_Pagar.Text, myForm.txt_CambioEfe.Text, 1, myForm.txt_Folio.Text, SalAnt, SalNue) ' <-- pago del corte
            '                'Else
            '                imprimir_Tiquete(CDbl(txt_Subtotal.Text), CDbl(txt_Subtotal.Text) - myForm.ImportePago, myForm.ImportePago + myForm.Cambio, txt_Pagar.Text, myForm.Cambio, 1, myForm.txt_Folio.Text, SalAnt, SalNue, SalVenci)
            '                'End If
            '                MessageBox.Show("Pago Aplicado Correctamente!", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '                NuevaInformacion()
            '                RevisarCantidadEfectivo()
            '            End If
            '        ElseIf CDbl(myForm.ImportePago) < CDbl(txt_Pagar.Text) Then
            '            MessageBox.Show("Por Favor solicite autorización para realizar el pago del convenio incompleto", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '            TraerFolioPago()
            '            Using objCajaCredito As New BCL.BCLCajaCredito(GLB_ConStringCredito)
            '                blnEncabezadoPago = objCajaCredito.usp_CapturaPago(1, GLB_CveSucursal, Folio, Distribuidor, "AP", GLB_FechaHoy.ToString("yyyy-MM-dd HH:mm:ss"), _
            '                                               0.0, 0.0, 0.0, 0.0, 0.0, 0.0, _
            '                                               CDbl(myForm.ImportePago), 0.0, 0.0, Cobrador, IdConvenio, GLB_Idempleado, GLB_FechaHoy.ToString("yyyy-MM-dd HH:mm:ss"), 0, "1900-01-01 00:00:00")
            '            End Using
            '            Using objCajaCredito As New BCL.BCLCajaCredito(GLB_ConStringCredito)
            '                objDataSet = objCajaCredito.usp_TraerIdPagoDistrib(1, Distribuidor, GLB_CveSucursal, GLB_Idempleado, "", "", 0)
            '            End Using
            '            If objDataSet.Tables(0).Rows.Count > 0 Then
            '                idPago = CInt(objDataSet.Tables(0).Rows(0).Item("idpago").ToString)
            '                Using objCajaCredito As New BCL.BCLCajaCredito(GLB_ConStringCredito)
            '                    objCajaCredito.usp_ActualizarConvenio(1, IdConvenio, CInt(DGrid.Rows(0).Cells("pago").Value), myForm.ImportePago, _
            '                                                            GLB_FechaHoy.ToString("yyyy-MM-dd"), idPago, Cobrador, GLB_Idempleado)
            '                End Using
            '                blnEncabezadoPago = GuardaFormasDePago(idPago, myForm.objDataSetFP)
            '                Dim SalAnt As Double = 0
            '                Dim SalNue As Double = 0
            '                Dim SalVenci As Double = 0
            '                If blnEncabezadoPago = True Then
            '                    Using objCajaCredito As New BCL.BCLCajaCredito(GLB_ConStringCredito)
            '                        objDataSet = objCajaCredito.usp_TraerDistribuidorCredito(1, Distribuidor, "")
            '                    End Using
            '                    If objDataSet.Tables(0).Rows.Count > 0 Then
            '                        SalAnt = objDataSet.Tables(0).Rows(0).Item("saldo").ToString
            '                    End If
            '                    Using objCajaCredito As New BCL.BCLCajaCredito(GLB_ConStringCredito)
            '                        objCajaCredito.usp_ActualizarSaldoDistrib(1, Distribuidor, myForm.ImportePago)
            '                    End Using
            '                    Using objCajaCredito As New BCL.BCLCajaCredito(GLB_ConStringCredito)
            '                        objDataSet = objCajaCredito.usp_TraerDistribuidorCredito(1, Distribuidor, "")
            '                    End Using
            '                    If objDataSet.Tables(0).Rows.Count > 0 Then
            '                        SalNue = objDataSet.Tables(0).Rows(0).Item("saldo").ToString
            '                    End If
            '                    Using objCajaCredito As New BCL.BCLCajaCredito(GLB_ConStringCredito)
            '                        objCajaCredito.usp_GenerarCorte(Distribuidor)
            '                    End Using
            '                    Using objCajaCredito As New BCL.BCLCajaCredito(GLB_ConStringCredito)
            '                        objDataSet = objCajaCredito.usp_TraerPlanPagos(1, Distribuidor)
            '                    End Using
            '                    If objDataSet.Tables(0).Rows.Count > 0 Then
            '                        SalVenci = objDataSet.Tables(0).Rows(0).Item("vencido").ToString
            '                    End If
            '                Else
            '                    MessageBox.Show("Error al guardar la forma de Pago", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '                    Exit Sub
            '                End If
            '                'If myForm.txt_RecibeEfe.Text.Trim <> "" Then
            '                '    imprimir_Tiquete(myForm.txt_RecibeEfe.Text, txt_Pagar.Text, myForm.txt_CambioEfe.Text, 1, myForm.txt_Folio.Text, SalAnt, SalNue) ' <-- pago del corte
            '                'Else
            '                imprimir_Tiquete(myForm.ImportePago, 0, myForm.ImportePago + myForm.Cambio, myForm.ImportePago, myForm.Cambio, 1, myForm.txt_Folio.Text, SalAnt, SalNue, SalVenci)
            '                'End If
            '                MessageBox.Show("Pago Aplicado Correctamente!", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '                NuevaInformacion()
            '                RevisarCantidadEfectivo()
            '            End If
            '        End If
            '    End If
            '    blnConvenio = False
            '    Exit Sub
            'End If
            If myForm.blnPago = True Then
                If CDbl(myForm.ImportePago) = CDbl(txt_Pagar.Text) Then
                    'ES POR SI SE HIZO EL PAGO CORRECTO(POR LA CANTIDAD INDICADA)
                    '  TraerFolioPago()
                    Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                        blnEncabezadoPago = objCajaCredito.usp_CapturaPago(1, GLB_CveSucursal, Folio, Distribuidor, "AP", GLB_FechaHoy,
                                                       CDbl(txt_Subtotal.Text), CDbl(txt_Descuento.Text) - CDbl(txt_DescuentoAdicional.Text), CDbl(txt_DescuentoAdicional.Text), 0.0, 0.0, 0.0,
                                                       CDbl(txt_Pagar.Text), CDbl(txt_Vencido.Text), 0.0, Cobrador, 0, GLB_Idempleado, 0)
                    End Using
                    If blnEncabezadoPago = True Then
                        Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                            objDataSet = objCajaCredito.usp_TraerIdPagoDistrib(1, Distribuidor, GLB_CveSucursal, GLB_Idempleado, "", "", 0)
                        End Using
                        If objDataSet.Tables(0).Rows.Count > 0 Then
                            idPago = CInt(objDataSet.Tables(0).Rows(0).Item("idpago").ToString)
                            If blnConvenio = True Then
                                Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                                    'CHECRA LO DEL CONVENIO  MREYES 07/DICIEMBRE /2018 A.M.
                                    '   objDataSet = objCajaCredito.usp_TraerPlanPagosDetConvenio(DGrid.Rows(0).Cells("sucursal").Value, DGrid.Rows(0).Cells("nota").Value)
                                End Using
                            Else
                                Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                                    objDataSet = objCajaCredito.usp_TraerCortesCaja(2, Distribuidor)
                                End Using
                            End If
                            If objDataSet.Tables(0).Rows.Count > 0 Then
                                For i As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                                    NumPago = ""
                                    objDataSetAux = New DataSet
                                    PagoDelPago = 0
                                    ImporteTotDelPago = 0
                                    idPagoDet = 0
                                    NumPago = objDataSet.Tables(0).Rows(i).Item("pago").ToString.Substring(0, objDataSet.Tables(0).Rows(i).Item("pago").ToString.LastIndexOf("/"))
                                    Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                                        objDataSetAux = objCajaCredito.usp_TraerInfoPagoDet(1, objDataSet.Tables(0).Rows(i).Item("sucursal").ToString, objDataSet.Tables(0).Rows(i).Item("nota").ToString, NumPago)
                                    End Using
                                    If objDataSetAux.Tables(0).Rows.Count > 0 Then
                                        PagoDelPago = CInt(objDataSetAux.Tables(0).Rows(0).Item("numpago").ToString) + 1
                                    End If
                                    Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                                        objDataSetAux = objCajaCredito.usp_TraerInfoPagoDet(2, objDataSet.Tables(0).Rows(i).Item("sucursal").ToString, objDataSet.Tables(0).Rows(i).Item("nota").ToString, NumPago)
                                    End Using
                                    ''''''REVISAR ESTA PROGRAMACION
                                    If objDataSetAux.Tables(0).Rows.Count > 0 Then
                                        ImporteTotDelPago = CDbl(objDataSetAux.Tables(0).Rows(0).Item("subtotal").ToString)
                                        ImporteTotDelPago += CDbl(objDataSet.Tables(0).Rows(i).Item("abono").ToString)
                                    End If
                                    ''''''''''''''''''''''''''''''''
                                    Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                                        objDataSetAux = objCajaCredito.usp_TraerInfoPagoDet(3, objDataSet.Tables(0).Rows(i).Item("sucursal").ToString, objDataSet.Tables(0).Rows(i).Item("nota").ToString, NumPago)
                                    End Using
                                    If objDataSetAux.Tables(0).Rows.Count > 0 Then
                                        TotDelPago = CDbl(objDataSetAux.Tables(0).Rows(0).Item("subtotal").ToString)
                                    End If
                                    If ImporteTotDelPago >= TotDelPago Then
                                        PagadoElPago = 1
                                    Else
                                        PagadoElPago = 0
                                    End If
                                    Try
                                        Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                                            objCajaCredito.usp_CapturaPagoDet(1, idPago, GLB_CveSucursal, objDataSet.Tables(0).Rows(i).Item("sucursal").ToString,
                                                                          objDataSet.Tables(0).Rows(i).Item("nota").ToString, CInt(NumPago), CDbl(objDataSet.Tables(0).Rows(i).Item("abono").ToString),
                                                                          CDbl(objDataSet.Tables(0).Rows(i).Item("dsctoap").ToString) - CDbl(objDataSet.Tables(0).Rows(i).Item("dsctoad").ToString), CDbl(objDataSet.Tables(0).Rows(i).Item("dsctoad").ToString), 0.0, 0.0, 0.0, (CDbl(objDataSet.Tables(0).Rows(i).Item("abono").ToString) - CDbl(objDataSet.Tables(0).Rows(i).Item("dsctoap").ToString)),
                                                                          CDbl(objDataSet.Tables(0).Rows(i).Item("vencido").ToString), 0.0, PagoDelPago, PagadoElPago, CDbl(objDataSet.Tables(0).Rows(i).Item("descuento").ToString) - CDbl(objDataSet.Tables(0).Rows(i).Item("descuentoadicional").ToString), CDbl(objDataSet.Tables(0).Rows(i).Item("descuentoadicional").ToString), 0.0, GLB_Idempleado)
                                        End Using
                                    Catch ExceptionErr As Exception
                                        MessageBox.Show(ExceptionErr.Message.ToString)
                                    End Try
                                    Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                                        objDataSetAux = objCajaCredito.usp_TraerIdPagoDistrib(2, Distribuidor, GLB_CveSucursal, GLB_Idempleado, objDataSet.Tables(0).Rows(i).Item("sucursal").ToString, objDataSet.Tables(0).Rows(i).Item("nota").ToString, NumPago)
                                    End Using
                                    If objDataSetAux.Tables(0).Rows.Count > 0 Then
                                        idPagoDet = CInt(objDataSetAux.Tables(0).Rows(0).Item("idpagosdet").ToString)
                                    End If
                                    Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                                        objCajaCredito.usp_ActualizarPlanPagos(1, Distribuidor, objDataSet.Tables(0).Rows(i).Item("sucursal").ToString, objDataSet.Tables(0).Rows(i).Item("nota").ToString, CInt(NumPago), objDataSet.Tables(0).Rows(i).Item("abono").ToString,
                                                                               GLB_FechaHoy.ToString("yyyy-MM-dd"), idPagoDet, GLB_Idempleado)
                                    End Using
                                Next
                            End If
                            blnEncabezadoPago = GuardaFormasDePago(idPago, myForm.objDataSetFP)
                        End If
                        Dim SalAnt As Double = 0
                        Dim SalNue As Double = 0
                        Dim SalVenci As Double = 0
                        If blnEncabezadoPago = True Then


                            SalAnt = Val(Txt_Saldo.Text)

                            Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                                objCajaCredito.usp_ActualizarSaldoDistrib(1, Distribuidor, CDbl(txt_Subtotal.Text))
                            End Using


                            SalNue = Val(Txt_Saldo.Text) + Val(txt_Subtotal.Text)


                            SalVenci = Val(Txt_Vencido1.Text)

                        Else
                            MessageBox.Show("Error al guardar la forma de Pago", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Exit Sub
                        End If
                        'If myForm.txt_RecibeEfe.Text.Trim <> "" Then
                        '    imprimir_Tiquete(myForm.txt_RecibeEfe.Text, txt_Pagar.Text, myForm.txt_CambioEfe.Text, 1, myForm.txt_Folio.Text, SalAnt, SalNue) ' <-- pago del corte
                        'Else
                        imprimir_Tiquete(CDbl(txt_Subtotal.Text), CDbl(txt_Subtotal.Text) - myForm.ImportePago, myForm.ImportePago + myForm.Cambio, txt_Pagar.Text, myForm.Cambio, 1, myForm.txt_Folio.Text, SalAnt, SalNue, SalVenci, idPago)
                        'End If
                        MessageBox.Show("Pago Aplicado Correctamente!", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        NuevaInformacion()
                        ''  RevisarCantidadEfectivo() quitar por mientras
                    End If
                ElseIf CDbl(myForm.ImportePago) < CDbl(txt_Pagar.Text) Then
                    Dim Abono As Double = 0
                    Dim ImpPag As Double = myForm.ImportePago
                    'ES POR SI EL PAGO SE HIZO POR UNA CANTIDAD MENOR DE LA INDICADA
                    ' TraerFolioPago()
                    Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                        blnEncabezadoPago = objCajaCredito.usp_CapturaPago(1, GLB_CveSucursal, Folio, Distribuidor, "AP", GLB_FechaHoy,
                                                      CDbl(myForm.ImportePago), 0.0, 0.0, 0.0, 0.0, 0.0,
                                                       CDbl(myForm.ImportePago), 0.0, 0.0, Cobrador, 0, GLB_Idempleado, 0)
                    End Using
                    If blnEncabezadoPago = True Then
                        Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                            objDataSet = objCajaCredito.usp_TraerIdPagoDistrib(1, Distribuidor, GLB_CveSucursal, GLB_Idempleado, "", "", 0)
                        End Using
                        If objDataSet.Tables(0).Rows.Count > 0 Then
                            idPago = CInt(objDataSet.Tables(0).Rows(0).Item("idpago").ToString)
                            Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                                objDataSet = objCajaCredito.usp_TraerCortesCaja(2, Distribuidor)
                            End Using
                            If objDataSet.Tables(0).Rows.Count > 0 Then
                                For i As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                                    If myForm.ImportePago = 0 Then Exit For
                                    NumPago = ""
                                    objDataSetAux = New DataSet
                                    PagoDelPago = 0
                                    ImporteTotDelPago = 0
                                    idPagoDet = 0
                                    If myForm.ImportePago >= (CDbl(objDataSet.Tables(0).Rows(i).Item("abono").ToString) - CDbl(objDataSet.Tables(0).Rows(i).Item("dsctoap").ToString)) Then
                                        Abono += (CDbl(objDataSet.Tables(0).Rows(i).Item("abono").ToString))
                                        NumPago = objDataSet.Tables(0).Rows(i).Item("pago").ToString.Substring(0, objDataSet.Tables(0).Rows(i).Item("pago").ToString.LastIndexOf("/"))
                                        Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                                            objDataSetAux = objCajaCredito.usp_TraerInfoPagoDet(1, objDataSet.Tables(0).Rows(i).Item("sucursal").ToString, objDataSet.Tables(0).Rows(i).Item("nota").ToString, NumPago)
                                        End Using
                                        If objDataSetAux.Tables(0).Rows.Count > 0 Then
                                            PagoDelPago = CInt(objDataSetAux.Tables(0).Rows(0).Item("numpago").ToString) + 1
                                        End If
                                        Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                                            objDataSetAux = objCajaCredito.usp_TraerInfoPagoDet(2, objDataSet.Tables(0).Rows(i).Item("sucursal").ToString, objDataSet.Tables(0).Rows(i).Item("nota").ToString, NumPago)
                                        End Using
                                        If objDataSetAux.Tables(0).Rows.Count > 0 Then
                                            ImporteTotDelPago = CDbl(objDataSetAux.Tables(0).Rows(0).Item("subtotal").ToString)
                                            'ImporteTotDelPago += myForm.ImportePago
                                            ImporteTotDelPago += CDbl(objDataSet.Tables(0).Rows(i).Item("abono").ToString)
                                        End If
                                        Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                                            objDataSetAux = objCajaCredito.usp_TraerInfoPagoDet(3, objDataSet.Tables(0).Rows(i).Item("sucursal").ToString, objDataSet.Tables(0).Rows(i).Item("nota").ToString, NumPago)
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
                                                                              objDataSet.Tables(0).Rows(i).Item("nota").ToString, CInt(NumPago), CDbl(objDataSet.Tables(0).Rows(i).Item("abono").ToString),
                                                                              CDbl(objDataSet.Tables(0).Rows(i).Item("dsctoap").ToString) - CDbl(objDataSet.Tables(0).Rows(i).Item("dsctoad").ToString), CDbl(objDataSet.Tables(0).Rows(i).Item("dsctoad").ToString), 0.0, 0.0, 0.0, (CDbl(objDataSet.Tables(0).Rows(i).Item("abono").ToString) - CDbl(objDataSet.Tables(0).Rows(i).Item("dsctoap").ToString)),
                                                                              CDbl(objDataSet.Tables(0).Rows(i).Item("vencido").ToString), 0.0, PagoDelPago, PagadoElPago, CDbl(objDataSet.Tables(0).Rows(i).Item("descuento").ToString) - CDbl(objDataSet.Tables(0).Rows(i).Item("descuentoadicional").ToString), CDbl(objDataSet.Tables(0).Rows(i).Item("descuentoadicional").ToString), 0.0, GLB_Idempleado)
                                        End Using
                                        myForm.ImportePago -= (CDbl(objDataSet.Tables(0).Rows(i).Item("abono").ToString) - CDbl(objDataSet.Tables(0).Rows(i).Item("dsctoap").ToString))
                                        Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                                            objDataSetAux = objCajaCredito.usp_TraerIdPagoDistrib(2, Distribuidor, GLB_CveSucursal, GLB_Idempleado, objDataSet.Tables(0).Rows(i).Item("sucursal").ToString, objDataSet.Tables(0).Rows(i).Item("nota").ToString, NumPago)
                                        End Using
                                        If objDataSetAux.Tables(0).Rows.Count > 0 Then
                                            idPagoDet = CInt(objDataSetAux.Tables(0).Rows(0).Item("idpagosdet").ToString)
                                        End If
                                        Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                                            objCajaCredito.usp_ActualizarPlanPagos(1, Distribuidor, objDataSet.Tables(0).Rows(i).Item("sucursal").ToString, objDataSet.Tables(0).Rows(i).Item("nota").ToString, CInt(NumPago), objDataSet.Tables(0).Rows(i).Item("abono").ToString,
                                                                                   GLB_FechaHoy, idPagoDet, GLB_Idempleado)
                                        End Using
                                    Else
                                        NumPago = objDataSet.Tables(0).Rows(i).Item("pago").ToString.Substring(0, objDataSet.Tables(0).Rows(i).Item("pago").ToString.LastIndexOf("/"))
                                        Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                                            objDataSetAux = objCajaCredito.usp_TraerInfoPagoDet(1, objDataSet.Tables(0).Rows(i).Item("sucursal").ToString, objDataSet.Tables(0).Rows(i).Item("nota").ToString, NumPago)
                                        End Using
                                        If objDataSetAux.Tables(0).Rows.Count > 0 Then
                                            PagoDelPago = CInt(objDataSetAux.Tables(0).Rows(0).Item("numpago").ToString) + 1
                                        End If
                                        Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                                            objDataSetAux = objCajaCredito.usp_TraerInfoPagoDet(2, objDataSet.Tables(0).Rows(i).Item("sucursal").ToString, objDataSet.Tables(0).Rows(i).Item("nota").ToString, NumPago)
                                        End Using
                                        If objDataSetAux.Tables(0).Rows.Count > 0 Then
                                            ImporteTotDelPago = CDbl(objDataSetAux.Tables(0).Rows(0).Item("subtotal").ToString)
                                            ImporteTotDelPago += myForm.ImportePago
                                            'ImporteTotDelPago += CDbl(objDataSet.Tables(0).Rows(i).Item("abono").ToString)
                                        End If
                                        Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                                            objDataSetAux = objCajaCredito.usp_TraerInfoPagoDet(3, objDataSet.Tables(0).Rows(i).Item("sucursal").ToString, objDataSet.Tables(0).Rows(i).Item("nota").ToString, NumPago)
                                        End Using
                                        If objDataSetAux.Tables(0).Rows.Count > 0 Then
                                            TotDelPago = CDbl(objDataSetAux.Tables(0).Rows(0).Item("subtotal").ToString)
                                        End If
                                        If ImporteTotDelPago >= TotDelPago Then
                                            PagadoElPago = 1
                                        Else
                                            PagadoElPago = 0
                                        End If
                                        Dim SubTotalPar As Double = 0.0
                                        Dim DesctoPar As Double = 0.0
                                        SubTotalPar = myForm.ImportePago * 100 / (100 - CDbl(objDataSet.Tables(0).Rows(i).Item("descuento").ToString))
                                        Abono += SubTotalPar
                                        DesctoPar = SubTotalPar - myForm.ImportePago
                                        Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                                            objCajaCredito.usp_CapturaPagoDet(1, idPago, GLB_CveSucursal, objDataSet.Tables(0).Rows(i).Item("sucursal").ToString,
                                                                              objDataSet.Tables(0).Rows(i).Item("nota").ToString, CInt(NumPago), SubTotalPar,
                                                                              DesctoPar - CDbl(objDataSet.Tables(0).Rows(i).Item("dsctoad").ToString), CDbl(objDataSet.Tables(0).Rows(i).Item("dsctoad").ToString), 0.0, 0.0, 0.0, myForm.ImportePago,
                                                                              CDbl(objDataSet.Tables(0).Rows(i).Item("vencido").ToString), 0.0, PagoDelPago, PagadoElPago, CDbl(objDataSet.Tables(0).Rows(i).Item("descuento").ToString) - CDbl(objDataSet.Tables(0).Rows(i).Item("descuentoadicional").ToString), CDbl(objDataSet.Tables(0).Rows(i).Item("descuentoadicional").ToString), 0.0, GLB_Idempleado)
                                        End Using
                                        Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                                            objDataSetAux = objCajaCredito.usp_TraerIdPagoDistrib(2, Distribuidor, GLB_CveSucursal, GLB_Idempleado, objDataSet.Tables(0).Rows(i).Item("sucursal").ToString, objDataSet.Tables(0).Rows(i).Item("nota").ToString, NumPago)
                                        End Using
                                        If objDataSetAux.Tables(0).Rows.Count > 0 Then
                                            idPagoDet = CInt(objDataSetAux.Tables(0).Rows(0).Item("idpagosdet").ToString)
                                        End If
                                        Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                                            objCajaCredito.usp_ActualizarPlanPagos(1, Distribuidor, objDataSet.Tables(0).Rows(i).Item("sucursal").ToString, objDataSet.Tables(0).Rows(i).Item("nota").ToString, CInt(NumPago), SubTotalPar,
                                                                                   GLB_FechaHoy.ToString("yyyy-MM-dd"), idPagoDet, GLB_Idempleado)
                                        End Using
                                        myForm.ImportePago = 0
                                    End If
                                Next
                            End If
                            blnEncabezadoPago = GuardaFormasDePago(idPago, myForm.objDataSetFP)
                        End If
                        Dim SalAnt As Double = 0
                        Dim SalNue As Double = 0
                        If blnEncabezadoPago = True Then

                            SalAnt = Val(Txt_Saldo.Text)

                            Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                                objCajaCredito.usp_ActualizarSaldoDistrib(1, Distribuidor, Abono)
                            End Using

                            SalNue = Val(Txt_Saldo.Text) + Abono


                            Dim SalVenci As Double = 0

                            SalVenci = Val(Txt_Vencido1.Text)

                            imprimir_Tiquete(Abono, Abono - ImpPag, ImpPag, ImpPag, myForm.Cambio, 1, myForm.txt_Folio.Text, SalAnt, SalNue, SalVenci, idPago)
                            'End If
                        Else
                            MessageBox.Show("Error al guardar la forma de Pago", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                        MessageBox.Show("Pago Aplicado Correctamente!", "CONFIRMACIÓN DE PAGO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        NuevaInformacion()
                        'RevisarCantidadEfectivo()
                    End If
                End If
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_Movimientos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Movimientos.Click
        Try
            Dim myForm As New frmMovimientosEspecialesCredito
            myForm.StartPosition = FormStartPosition.CenterParent
            myForm.ShowDialog()
            NuevaInformacion()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_Nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Nuevo.Click
        Try
            If txt_Distrib.Text.Trim <> "" Then
                If MessageBox.Show("Estas seguro que deseas cancelar la operación? La información no se guardara", "CONFIRMACIÓN", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                    NuevaInformacion()
                End If
            End If
            txt_Distrib.Focus()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_Regresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Regresar.Click
        Try
            txt_Distrib_LostFocus(sender, e)
            btn_Regresar.Visible = False
            btn_Invertir.Visible = False
            btn_DetalladoPago.Visible = False
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_Corte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Entrega.Click
        Try
            Dim myForm As New frmEntregaCajaCredito
            myForm.StartPosition = FormStartPosition.CenterScreen
            myForm.ShowDialog()
            If myForm.blnAceptar = True Then
                'Using objCajaCredito As New BCL.BCLCajaCredito(GLB_ConStringCredito)
                '    objDataSet = objCajaCredito.usp_TraerImporteEntregaCaja(GLB_Idempleado, GLB_FechaHoy.ToString("yyyy-MM-dd"))
                'End Using
                'If objDataSet.Tables(0).Rows.Count > 0 Then
                '    Dim Cantidad As Double = CDbl(objDataSet.Tables(0).Rows(0).Item("importe").ToString)
                '    If myForm.dblCantidad >= Cantidad Then
                '        MessageBox.Show("OK")
                '    Else
                '        MessageBox.Show("NO")
                '    End If
                'End If
                MessageBox.Show("Entrega generado correctamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'Else
                '    MessageBox.Show("Proceso no terminado", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_Historial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Historial.Click
        Try
            Dim myForm As New frmHistorialPagos
            myForm.Distribuidor = Distribuidor
            myForm.txt_Distrib.Text = Distribuidor
            myForm.txt_NombreDistrib.Text = txt_NombreDistrib.Text
            myForm.StartPosition = FormStartPosition.CenterScreen
            myForm.ShowDialog()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_Invertir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Invertir.Click
        Try
            For i As Integer = 0 To DGrid.Rows.Count - 1
                If DGrid.Rows(i).Cells("selec").ReadOnly = False Then
                    DGrid.Rows(i).Cells("selec").Value = Not (DGrid.Rows(i).Cells("selec").Value)
                End If
            Next
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_DetalladoPago_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_DetalladoPago.Click
        Try
            DGrid.Columns("descuento").Visible = Not (DGrid.Columns("descuento").Visible)
            DGrid.Columns("descuentoadicional").Visible = Not (DGrid.Columns("descuentoadicional").Visible)
            'DGrid.Columns("dstopagnor").Visible = Not (DGrid.Columns("dstopagnor").Visible)
            'DGrid.Columns("desctohol").Visible = Not (DGrid.Columns("desctohol").Visible)
            DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_DesctoEspecial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_DesctoEspecial.Click
        Try
            Dim myForm As New frmModificarDescuentoCaja
            myForm.StartPosition = FormStartPosition.CenterScreen
            myForm.ShowDialog()
            'Dim myForm As New frmModificarDescuentoCaja
            'myForm.Distribuidor = txt_Distrib.Text
            'myForm.NombreDistrib = txt_NombreDistrib.Text
            'myForm.StartPosition = FormStartPosition.CenterScreen
            'myForm.ShowDialog()
            'If myForm.blnDescto = True Then
            '    blnDescuento = True
            '    DescuentoEspecial = myForm.Descuento
            '    RellenaInformacionPago()
            'End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

#End Region

#Region "GRID"

    Private Sub DGrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGrid.DoubleClick
        Try
            If Opcion = 2 Then Exit Sub
            Opcion = 2
            RellenaInformacionPago()
            btn_Regresar.Visible = True
            'btn_Invertir.Visible = True
            btn_DetalladoPago.Visible = True
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub



#End Region

#End Region

#Region "METODOS"

    Private Sub RellenaInformacionPago()
        Try
            DGrid.DataSource = Nothing
            DGrid.Columns.Clear()
            If blnDescuento = False Then
                DescuentoEspecial = 0
            End If
            Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                objDataSet = objCajaCredito.usp_TraerCortesCaja(Opcion, Distribuidor)
            End Using
            If objDataSet.Tables(0).Rows.Count > 0 Then
                DGrid.DataSource = objDataSet.Tables(0)
                If Opcion = 1 Then  'MREYES, VOLVER A PONER 14/DICIEMBRE/2018
                    'If GLB_CveSucursal <= 11 Then

                    '    If objDataSet.Tables(0).Rows(0).Item("ESTATUS").ToString = "DEMANDA" Then
                    '        MsgBox("El distribuidor se encuentra en proceso de DEMANDA, por lo que no puede recibir pagos en tienda, Enviarlo a Oficina de Crédito", MsgBoxStyle.Information, "No puede realizar el cobro")
                    '        NuevaInformacion()
                    '        Exit Sub

                    '    End If
                    'End If
                End If
                If Opcion = 1 Then
                    txt_Distrib.Text = pub_RellenarIzquierda(objDataSet.Tables(0).Rows(0).Item("distrib").ToString, 6)
                    txt_NombreDistrib.Text = objDataSet.Tables(0).Rows(0).Item("nombrecompleto").ToString
                    Lbl_TipoDistrib.Text = objDataSet.Tables(0).Rows(0).Item("tipodistrib").ToString

                    txt_Vencido.Text = objDataSet.Tables(0).Rows(0).Item("totalvencido").ToString
                    Txt_Vencido1.Text = objDataSet.Tables(0).Rows(0).Item("totalvencido").ToString

                    Txt_LimiteCredito.Text = objDataSet.Tables(0).Rows(0).Item("limitecredito").ToString
                    Txt_Saldo.Text = objDataSet.Tables(0).Rows(0).Item("saldo").ToString
                    Txt_Disponible.Text = objDataSet.Tables(0).Rows(0).Item("disponible").ToString

                    txt_Descuento.Text = objDataSet.Tables(0).Rows(0).Item("dsctoap").ToString

                    'txt_DescuentoAdicional.Text = objDataSet.Tables(0).Rows(0).Item("dsctoad").ToString
                    txt_PorcDescto.Text = objDataSet.Tables(0).Rows(0).Item("descuento").ToString
                    txt_Subtotal.Text = Val(objDataSet.Tables(0).Rows(0).Item("total")) + Val(objDataSet.Tables(0).Rows(0).Item("dsctoap"))
                    txt_Pagar.Text = objDataSet.Tables(0).Rows(0).Item("total").ToString '  - objDataSet.Tables(0).Rows(0).Item("dsctoap").ToString '- objDataSet.Tables(0).Rows(0).Item("dsctoad").ToString

                    'MREYES 18/DICIEMBRE/2018   10:40 A.M.
                    txt_Descuento.Text = Val(objDataSet.Tables(0).Rows(0).Item("dsctoap").ToString) - Val(objDataSet.Tables(0).Rows(0).Item("impdescuentoadicional"))
                    txt_Pagar.Text = objDataSet.Tables(0).Rows(0).Item("total").ToString '  - objDataSet.Tables(0).Rows(0).Item("dsctoap").ToString '- objDataSet.Tables(0).Rows(0).Item("dsctoad").ToString
                    txt_PorcDescto.Text = Format(CDbl(objDataSet.Tables(0).Rows(0).Item("descuento").ToString), "#0.##")
                    txt_Subtotal.Text = Val(objDataSet.Tables(0).Rows(0).Item("total")) + Val(objDataSet.Tables(0).Rows(0).Item("dsctoap"))


                    txt_Adicional.Text = Format(CDbl(objDataSet.Tables(0).Rows(0).Item("descuentoadicional")), "#0.##")
                    txt_DescuentoAdicional.Text = (objDataSet.Tables(0).Rows(0).Item("impdescuentoadicional"))
                    InicializaGridInformacionPago()
                    FormatosTextBox()
                    txt_Distrib.Enabled = False
                    txt_Distrib.BackColor = Color.White




                End If
                If Opcion = 2 Then
                    InicializaGridInformacionPago()
                End If
                btn_Historial.Visible = True
            Else
                Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                    objDataSet = objCajaCredito.usp_TraerDistribuidorCredito(1, Distribuidor, "")
                End Using
                If objDataSet.Tables(0).Rows.Count = 1 Then
                    txt_NombreDistrib.Text = objDataSet.Tables(0).Rows(0).Item("nombrecompleto").ToString
                    Using objCajaCredito As New BCL.BCLCajaCredito(GLB_ConStringCredito)
                        objDataSet = objCajaCredito.usp_PpalPagoCreditoAdelantado(1, Distribuidor, 0)
                    End Using
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        If MessageBox.Show("No existen pagos pendientes para el distribuidor, desea adelantar pago?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                            Dim myForm As New frmMovimientosEspecialesCredito
                            myForm.blnAnticipo = True
                            myForm.txt_AntDistrib.Text = Distribuidor
                            myForm.txt_AntDistribNombre.Text = txt_NombreDistrib.Text
                            myForm.txt_AntImporte.Text = "0.00"
                            myForm.StartPosition = FormStartPosition.CenterScreen
                            myForm.ShowDialog()
                            NuevaInformacion()
                            btn_Historial.Visible = True
                        Else
                            NuevaInformacion()
                        End If
                    Else
                        MessageBox.Show("No existen pagos pendientes para el distribuidor seleccionado", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        txt_Distrib.Text = ""
                        NuevaInformacion()
                    End If
                    'txt_Distrib.Focus()
                Else
                    Dim myForm As New frmConsulta
                    myForm.Tipo = "DI"
                    myForm.ShowDialog()
                    If myForm.blnConsultoDistrib = False Then
                        txt_Distrib.Text = ""
                        txt_NombreDistrib.Text = ""
                        Cobrador = 0
                        txt_Distrib.Focus()
                        Exit Sub
                    End If
                    txt_Distrib.Text = pub_RellenarIzquierda(myForm.Campo, 6)
                    '  txt_NombreDistrib.Text = myForm.Campo1
                    'Cobrador = myForm.Campo2
                    txt_Distrib.Focus()
                    DGrid.Focus()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        Finally
        End Try
    End Sub

    Private Sub InicializaGridInformacionPago()
        Try
            If Opcion = 1 Then
                DGrid.Columns("distrib").HeaderText = "Distribuidor"
                DGrid.Columns("nombrecompleto").HeaderText = "Nombre"
                '  DGrid.Columns("saldo").HeaderText = "Saldo Actual"
                DGrid.Columns("fechacorte").HeaderText = "Fecha Corte"
                DGrid.Columns("totalcorte").HeaderText = "Total Corte"
                DGrid.Columns("abono").HeaderText = "Total Abono"
                DGrid.Columns("vencido").HeaderText = "Vencido"
                DGrid.Columns("saldocorte").HeaderText = "Saldo Corte"
                DGrid.Columns("dsctoap").HeaderText = "Dsto."
                DGrid.Columns("Total").HeaderText = "A Pagar"

                DGrid.Columns("distrib").Visible = False
                DGrid.Columns("nombrecompleto").Visible = False
                DGrid.Columns("limitecredito").Visible = False

                'di.limitecredito, di.saldo, di.disponible, di.tipodistrib, di.clasificacion,
                'isnull(ve.vencido, 0) as totalvencido
                DGrid.Columns("saldo").Visible = False
                DGrid.Columns("disponible").Visible = False
                DGrid.Columns("tipodistrib").Visible = False
                DGrid.Columns("clasificacion").Visible = False
                DGrid.Columns("totalvencido").Visible = False
                DGrid.Columns("descuento").Visible = False
                DGrid.Columns("descuentoadicional").Visible = False
                DGrid.Columns("impdescuentoadicional").Visible = False
                DGrid.Columns("saldo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns("totalcorte").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns("abono").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns("vencido").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns("saldocorte").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns("dsctoap").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.ReadOnly = True
                DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

                DGrid.Columns("fechacorte").DefaultCellStyle.Format = "dd/MM/yyyy"

            End If
            If Opcion = 2 Then
                DGrid.Columns("distrib").HeaderText = "Distribuidor"
                DGrid.Columns("sucursal").HeaderText = "Sucursal"
                DGrid.Columns("nota").HeaderText = "Nota"
                DGrid.Columns("negocio").HeaderText = "Negocio"
                DGrid.Columns("vale").HeaderText = "Vale"
                DGrid.Columns("pago").HeaderText = "Pago"
                DGrid.Columns("fecha").HeaderText = "Fecha Pago"
                DGrid.Columns("cliente").HeaderText = "Cliente"
                DGrid.Columns("vencido").HeaderText = "Saldo Vencido"
                DGrid.Columns("corte").HeaderText = "Corte"
                DGrid.Columns("abono").HeaderText = "Total"
                DGrid.Columns("descuento").HeaderText = "% Dscto. Original"
                DGrid.Columns("dsctoap").HeaderText = "Descuento"
                DGrid.Columns("descuentoadicional").HeaderText = "% Dscto. Adicional"
                DGrid.Columns("descuentoadicional").HeaderText = "Dscto. Adicional"
                DGrid.Columns("dstopagnor").HeaderText = "% Normal"
                DGrid.Columns("desctohol").HeaderText = "% Castigo"
                DGrid.Columns("distrib").Visible = False
                DGrid.Columns("sucursal").Visible = False
                DGrid.Columns("nota").Visible = False
                DGrid.Columns("descuento").Visible = False
                DGrid.Columns("descuentoadicional").Visible = False
                DGrid.Columns("dstopagnor").Visible = False
                DGrid.Columns("desctohol").Visible = False
                DGrid.Columns("negocio").AutoSizeMode = DataGridViewAutoSizeColumnsMode.AllCells
                DGrid.Columns("vale").AutoSizeMode = DataGridViewAutoSizeColumnsMode.AllCells
                DGrid.Columns("cliente").AutoSizeMode = DataGridViewAutoSizeColumnsMode.AllCells
                DGrid.Columns("pago").AutoSizeMode = DataGridViewAutoSizeColumnsMode.AllCells
                DGrid.Columns("fecha").AutoSizeMode = DataGridViewAutoSizeColumnsMode.AllCells
                DGrid.Columns("vencido").AutoSizeMode = DataGridViewAutoSizeColumnsMode.AllCells
                DGrid.Columns("descuento").AutoSizeMode = DataGridViewAutoSizeColumnsMode.AllCells
                DGrid.Columns("descuentoadicional").AutoSizeMode = DataGridViewAutoSizeColumnsMode.AllCells
                DGrid.Columns("dstopagnor").AutoSizeMode = DataGridViewAutoSizeColumnsMode.AllCells
                DGrid.Columns("desctohol").AutoSizeMode = DataGridViewAutoSizeColumnsMode.AllCells
                DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                DGrid.Columns("pago").DefaultCellStyle.Format = "#0"
                DGrid.Columns("fecha").DefaultCellStyle.Format = "dd/MM/yyyy"
                DGrid.Columns("descuento").DefaultCellStyle.Format = "#0"
                DGrid.Columns("descuentoadicional").DefaultCellStyle.Format = "#0"
                DGrid.Columns("dstopagnor").DefaultCellStyle.Format = "#0"
                DGrid.Columns("desctohol").DefaultCellStyle.Format = "#0"
                DGrid.Columns("cliente").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                DGrid.Columns("vencido").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns("corte").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns("abono").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns("dsctoap").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                ' se quito el 03/Ene/2019   09:52 a.m.

                'AgregarColumna()
                'DGrid.ReadOnly = False
                ''For i As Integer = 0 To DGrid.ColumnCount - 1
                ''    If DGrid.Columns(i).Name.Trim = "Selec" Then
                '        DGrid.Columns(i).ReadOnly = False
                '    Else
                '        DGrid.Columns(i).ReadOnly = True
                '    End If
                'Next
                'For i As Integer = 0 To DGrid.RowCount - 1
                '    DGrid.Rows(i).Cells("selec").Value = True
                '    If CDbl(DGrid.Rows(i).Cells("vencido").Value) > 0 Then
                '        DGrid.Rows(i).Cells("selec").ReadOnly = True
                '    End If
                'Next
                ' DGrid.Columns("selec").Visible = False
                DGrid.Columns("descuentoadicional").Visible = False
                DGrid.Columns("dsctoad").Visible = False
                DGrid.Columns("corte").DefaultCellStyle.Format = "dd/MM/yyyy"
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        Finally
        End Try
    End Sub

    Private Sub NuevaInformacion()
        Try
            txt_Distrib.Text = ""
            txt_Distrib.Enabled = True
            txt_NombreDistrib.Text = ""
            DGrid.DataSource = Nothing
            DGrid.Columns.Clear()
            txt_Subtotal.Text = ""
            txt_Vencido.Text = ""
            txt_Descuento.Text = ""
            txt_Pagar.Text = ""
            btn_Regresar.Visible = False
            txt_Distrib.Focus()
            blnDescuento = False
            Cobrador = 0
            btn_Historial.Visible = False

            Txt_LimiteCredito.Text = ""
            Txt_Vencido1.Text = ""
            Txt_Saldo.Text = ""
            Txt_Disponible.Text = ""
            Lbl_TipoDistrib.Text = ""

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        Finally
        End Try
    End Sub

    Private Sub FormatosTextBox()
        Try
            '  txt_Descuento.Text = "0.0"
            'txt_DescuentoAdicional.Text = "0.0"
            txt_Vencido.Text = "$ " + Format(CType(txt_Vencido.Text, Decimal), "###,##0.00")
            Txt_Vencido1.Text = "$ " + Format(CType(Txt_Vencido1.Text, Decimal), "###,##0.00")
            Txt_LimiteCredito.Text = "$ " + Format(CType(Txt_LimiteCredito.Text, Decimal), "###,##0.00")
            Txt_Saldo.Text = "$ " + Format(CType(Txt_Saldo.Text, Decimal), "###,##0.00")
            Txt_Disponible.Text = "$ " + Format(CType(Txt_Disponible.Text, Decimal), "###,##0.00")
            txt_Descuento.Text = "$ " + Format(CType(txt_Descuento.Text, Decimal), "###,##0.00")
            txt_DescuentoAdicional.Text = "$ " + Format(CType(txt_DescuentoAdicional.Text, Decimal), "###,##0.00")
            txt_Subtotal.Text = "$ " + Format(CType(txt_Subtotal.Text, Decimal), "###,##0.00")
            txt_Pagar.Text = "$ " + Format(CType(txt_Pagar.Text, Decimal), "###,##0.00")
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        Finally
        End Try
    End Sub

    Private Sub AgregarColumna()
        'mreyes 28/Abril/2012 10:40 a.m.

        Dim colImagen As DataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn()
        colImagen.Name = "Selec"
        colImagen.HeaderText = "Pagar"
        colImagen.DisplayIndex = 25
        colImagen.ReadOnly = False
        colImagen.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        colImagen.CellTemplate = New DataGridViewCheckBoxCell()
        ' añadir columna de imagen a la coleccion del grid 
        DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        ''DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells

        Me.DGrid.Columns.Add(colImagen)

    End Sub

    Private Sub TraerFolioPago()
        'mreyes 28/Noviembre/2018   10:38 a.m.
        Try
            Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                objDataSet = objCajaCredito.usp_TraerFolioPago(GLB_CveSucursal)
            End Using
            If objDataSet.Tables(0).Rows.Count > 0 Then
                Folio = objDataSet.Tables(0).Rows(0).Item("folio").ToString
                'Folio = CInt(Folio) + 1
                Folio = pub_RellenarIzquierda(Folio, 6)
                ' Folio = Folio
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        Finally
        End Try
    End Sub

    Private Function GuardaFormasDePago(ByVal IdPago As Integer, ByVal objDataSetFormasPago As DataSet) As Boolean
        'mreyes 07/Diciembre/2018   12:31 p.m.
        Try
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

                    'mreyes, activos, si poner
                    'Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                    '    blnGuardoAct = objCajaCredito.usp_CapturaActivos(1, 1, Articulo, Tipo, Marca, NumSerie, Nuevo,
                    '                                                      ImpComercial, Comercio, ImpAdquirido, ImpVenta, GLB_Idempleado)
                    'End Using
                    'If blnGuardoAct = True Then
                    '    Using objCajaCredito As New BCL.BCLCajaCredito(GLB_ConStringCredito)
                    '        objDataSet = objCajaCredito.usp_TraerActivos(1, Articulo, Tipo, Marca, NumSerie, GLB_Idempleado)
                    '    End Using
                    '    If objDataSet.Tables(0).Rows.Count > 0 Then
                    '        IdActivos = CInt(objDataSet.Tables(0).Rows(0).Item("idactivos").ToString)
                    '    End If
                    'End If
                End If
                Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                    blnGuardo = objCajaCredito.usp_CapturaTipoPagos(1, IdPago, GLB_CveSucursal, objDataSetFormasPago.Tables(0).Rows(i).Item("formapago").ToString, Estatus, GLB_FechaHoy,
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

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        Finally
        End Try
    End Function

    Private Sub imprimir_Tiquete(ByVal ImpBruto As Double, ByVal Descto As Double, ByVal recibido As Double, ByVal total As Double, ByVal cambio As Double, ByVal tipo_Tiquete As Integer, ByVal FolioPago As String, ByVal SaldoAnterior As Double, ByVal SaldoNuevo As Double, ByVal SaldoVencido As Double, ByVal IdPago As Integer)
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
                    imprimir_Ticket_Abono(ImpBruto, Descto, recibido, total, cambio, tipo_Tiquete, FolioPago, SaldoAnterior, SaldoNuevo, SaldoVencido, IdPago)
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

    Private Sub imprimir_Ticket_Abono(ByVal ImpBruto As Double, ByVal Descto As Double, ByVal recibido As Double, ByVal total As Double, ByVal cambio As Double, ByVal tipo_Tiquete As Integer, ByVal FolioPago As String, ByVal SaldoAnterior As Double, ByVal SaldoNuevo As Double, ByVal SaldoVencido As Double, ByVal IdPago As Integer)
        Try
            Dim Hora As String
            Dim Sw_Cheque As Boolean = False
            Dim DetImporte As Double = 0
            Hora = DateTime.Now.ToString("HH:mm:ss")


            '-- -----------------------------------------------------
            Dim Ticket1 As New CreaTicket()

            'Ticket1.impresora = "EPSON TM-U220 Receipt"
            'Ticket1.impresora = "tick"
            GLB_ImpresoraTicket = "LR2000"
            Ticket1.impresora = GLB_ImpresoraTicket
            Ticket1.AbreCajon()
            Ticket1.TextoCentro("ZAPATERIAS TORREON")
            'Ticket1.TextoCentro("CALZADO DE TORREON S.A. DE C.V.")
            Ticket1.TextoCentro("TEL. 711-46-52")
            Ticket1.TextoCentro("")
            Ticket1.LineasIgual()
            Ticket1.TextoIzquierda("SUCURSAL : " + GLB_CveSucursal + " - " + GLB_Sucursal)
            Ticket1.TextoIzquierda("FOLIO : " + FolioPago)
            Ticket1.TextoIzquierda("CLIENTE : " + txt_Distrib.Text)
            Ticket1.TextoIzquierda(txt_NombreDistrib.Text)
            Ticket1.TextoIzquierda("CAJERO :" + GLB_Idempleado.ToString & " " & GLB_NomUsuario)
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
            Ticket1.AgregaTotales("    TOTAL A PAGAR", FormatCurrency(total))
            Ticket1.AgregaTotales("   TOTAL RECIBIDO", FormatCurrency(recibido))
            Ticket1.TextoCentro("      ")
            '' agregar formas de pago
            ''' mreyes   15/Febrero/2016 12:04 p.m.
            'Using objCajaCredito As New BCL.BCLCajaCredito(GLB_ConStringCredito)
            '    objDataSet = objCajaCredito.usp_TraerInfoPagos(idpago)
            'End Using
            'If objDataSet.Tables(0).Rows.Count > 0 Then
            '    For i As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
            '        If objDataSet.Tables(0).Rows(i).Item("descripcion").ToString = "CHEQUE" Then
            '            Sw_Cheque = True
            '        ElseIf objDataSet.Tables(0).Rows(i).Item("descripcion").ToString = "DOLARES" Then

            '            DetImporte = objDataSet.Tables(0).Rows(i).Item("dolares")
            '        End If
            '        Ticket1.AgregaTotales("" + pub_RellenarEspaciosIzquierda(objDataSet.Tables(0).Rows(i).Item("descripcion").ToString, 17 - Len(objDataSet.Tables(0).Rows(i).Item("descripcion").ToString)), FormatCurrency(DETIMPORTE))

            '    Next
            'End If


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

            If Sw_Cheque = True Then
                Ticket1.TextoCentro("             ")
                Ticket1.TextoCentro("*SE RECIBE CHEQUE SALVO BUEN COBRO")
            End If

            'If tipopago Then
            Ticket1.CortaTicket()
            Ticket1.impresora = GLB_ImpresoraPredeterminada
            '-- -----------------------------------------------------
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Public Sub RevisarCantidadEfectivo()
        Dim TotalEntregado As Double = 0
        Dim TotalCobrado As Double = 0
        Dim MaximoPermitido As Double = 0
        Using objCajaCredito As New BCL.BCLCajaCredito(GLB_ConStringCredito)
            objDataSet = objCajaCredito.usp_TraerEntrega(2, GLB_Idempleado, GLB_FechaHoy.ToString("yyyy-MM-dd"))
        End Using
        If objDataSet.Tables(0).Rows.Count > 0 Then
            TotalEntregado = CDbl(objDataSet.Tables(0).Rows(0).Item("efectivo").ToString)
        End If
        Using objCajaCredito As New BCL.BCLCajaCredito(GLB_ConStringCredito)
            objDataSet = objCajaCredito.usp_TraerImporteEntregaCaja(GLB_Idempleado, GLB_FechaHoy.ToString("yyyy-MM-dd 12:00:00"))
        End Using
        If objDataSet.Tables(0).Rows.Count > 0 Then
            TotalCobrado = CDbl(objDataSet.Tables(0).Rows(0).Item("importe").ToString)
        End If
        Using objCajaCredito As New BCL.BCLCajaCredito(GLB_ConStringCredito)
            objDataSet = objCajaCredito.usp_TraerParametrosCredito("ENTREGA")
        End Using
        If objDataSet.Tables(0).Rows.Count > 0 Then
            MaximoPermitido = CDbl(objDataSet.Tables(0).Rows(0).Item("valor").ToString)
        End If
        If MaximoPermitido < (TotalCobrado - TotalEntregado) Then
            MessageBox.Show("Por Favor realiza una entrega de caja, tu Efectivo excede el limite permitido", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Public Function TieneConvenio() As Boolean
        Using objCajaCredito As New BCL.BCLCajaCredito(GLB_ConStringCredito)
            objDataSet = objCajaCredito.usp_TraerConvenio(2, "1900-01-01", txt_Distrib.Text, 0)
        End Using
        If objDataSet.Tables(0).Rows.Count > 0 Then
            MessageBox.Show("El distribuidor seleccionado tiene convenio", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            MessageBox.Show(objDataSet.Tables(0).Rows(0).Item("observaciones").ToString, "OBSERVACIONES CONVENIO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return True
        Else
            Return False
        End If
    End Function

    Public Sub TraerConvenio()
        Using objCajaCredito As New BCL.BCLCajaCredito(GLB_ConStringCredito)
            objDataSet = objCajaCredito.usp_TraerConvenio(3, "1900-01-01", txt_Distrib.Text, 0)
        End Using
        DGrid.DataSource = objDataSet.Tables(0)
        DGrid.Visible = False
        If GLB_FechaHoy > CDate(DGrid.Rows(0).Cells("fechavencimiento").Value) Then
            MessageBox.Show("La fecha para realizar este pago a vencido, por favor solicite autorización para realizar este pago", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        DGrid.Visible = True
        ' di.nombre, d.idconvenio, d.fechaaplicar, d.pago, d.pagos, d.fechavencimiento, d.importe - d.abono as apagar, 
        'd.descuento, d.interes, d.gastoscobranza, d.pagado,  d.cobrador
        DGrid.Columns("nombre").Visible = False
        DGrid.Columns("fecha").Visible = False
        DGrid.Columns("cobrador").Visible = False
        DGrid.Columns("corte").Visible = False
        DGrid.Columns("vencido").Visible = False
        txt_NombreDistrib.Text = DGrid.Rows(0).Cells("nombre").Value
        DGrid.Columns("nombrecobrador").HeaderText = "Cobrador"
        DGrid.Columns("sucursal").HeaderText = "Sucursal"
        DGrid.Columns("nota").HeaderText = "Nota"
        DGrid.Columns("pago").HeaderText = "Pago"
        DGrid.Columns("fechavencimiento").HeaderText = "Fecha Vencimiento"
        DGrid.Columns("abono").HeaderText = "A Pagar"
        DGrid.Columns("pago").DefaultCellStyle.Format = "#0"
        DGrid.Columns("fechavencimiento").DefaultCellStyle.Format = "dd/MM/yyyy"
        DGrid.Columns("nombrecobrador").AutoSizeMode = DataGridViewAutoSizeColumnsMode.AllCells
        DGrid.Columns("sucursal").AutoSizeMode = DataGridViewAutoSizeColumnsMode.AllCells
        DGrid.Columns("nota").AutoSizeMode = DataGridViewAutoSizeColumnsMode.AllCells
        DGrid.Columns("pago").AutoSizeMode = DataGridViewAutoSizeColumnsMode.AllCells
        DGrid.Columns("fechavencimiento").AutoSizeMode = DataGridViewAutoSizeColumnsMode.AllCells
        DGrid.Columns("abono").AutoSizeMode = DataGridViewAutoSizeColumnsMode.AllCells
        txt_Subtotal.Text = "$" & Format(CDbl(DGrid.Rows(0).Cells("abono").Value), "###,##0.00")
        txt_Pagar.Text = txt_Subtotal.Text
        txt_Descuento.Text = 0
        txt_DescuentoAdicional.Text = 0
        txt_Vencido.Text = 0
    End Sub

#End Region

    Private Sub DGrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellContentClick

    End Sub

    Private Sub pnl_Botones_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnl_Botones.Paint

    End Sub

    Private Sub txt_Distrib_MouseDown(sender As Object, e As MouseEventArgs) Handles txt_Distrib.MouseDown

    End Sub

    Private Sub Txt_LimiteCredito_TextChanged(sender As Object, e As EventArgs) Handles Txt_LimiteCredito.TextChanged

    End Sub

    Private Sub txt_Distrib_MouseCaptureChanged(sender As Object, e As EventArgs) Handles txt_Distrib.MouseCaptureChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Btn_Excel.Click
        Try
            If ExportarDGridAExcel(DGrid) = False Then
                MsgBox("Error al exportar a Excel. Intente nuevamente.", MsgBoxStyle.Critical, "Excel")
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
End Class