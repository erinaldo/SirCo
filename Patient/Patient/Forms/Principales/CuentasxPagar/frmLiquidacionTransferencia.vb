Public Class frmLiquidacionTransferencia

    'mreyes 09/Mayo/2019    11:21 a.m.
    Dim Sql As String

    Private objDataSet As Data.DataSet
    Public Sw_Filtro As Boolean = False
    Public Sw_Cancelar As Boolean = False
    Public objDataSetLiquidacion As DataSet
    Public blnAplicar As Boolean = False
    Public blnCheck As Boolean = False

    Private idFolio As String = ""
    Private FechaFactura As Date
    Private Marca As String = ""
    Private Proveedor As String = ""
    Public Remision As Boolean = False
    Public PagarRemision As Boolean = False

    Private Sub frmFiltrosEstilos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Chk_Fechas.Checked = True
            'If Chk_Fechas.Checked = False Then
            '    DT_FecVencimientoFin.Enabled = False
            '    DT_FecVencimientoIni.Enabled = False
            'End If
            Call GenerarToolTip()
            RellenaComboCuentas()
            If PagarRemision Then
                Btn_Aceptar_Click(sender, e)
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub GenerarToolTip()
        Try
            ToolTip.SetToolTip(Btn_Aceptar, "Aceptar la acción requerida por el usuario")
            ToolTip.SetToolTip(Btn_Cancelar, "Cancelar cualquier acción requerida por el usuario")
            ToolTip.SetToolTip(Btn_Limpiar, "Limpiar Filtros")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub RellenaComboCuentas()
        Try
            Using objCuentas As New BCL.BCLCatalogoCuentas(GLB_ConStringCipSis)
                objDataSet = objCuentas.usp_TraerCuenta(0, "")
            End Using
            If objDataSet.Tables(0).Rows.Count > 0 Then
                CBO_Cuentas.DataSource = objDataSet.Tables(0)
                CBO_Cuentas.ValueMember = "idcuenta"
                CBO_Cuentas.DisplayMember = "cuentabanco"
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click
        Dim idCuenta As Integer = 0
        Dim objDataSetFacturasAux As New DataSet
        Dim objDataSetLiquidacionAux As New DataSet
        Dim objDataSetChequeAux As New DataSet
        Dim EmpezoActualizar1 As Boolean = False
        Dim EmpezoActualizar2 As Boolean = False
        Dim EmpezoActualizar3 As Boolean = False
        Dim EmpezoActualizar4 As Boolean = False
        Try
            If blnAplicar = True Then
                Dim idLiquidacion As Integer = objDataSetLiquidacion.Tables(0).Rows(0).Item("idliquidacion").ToString

                If PagarRemision = True Then
                    idCuenta = 0
                Else
                    If MessageBox.Show("Esta seguro que desea aplicar la liquidación de Pagos ?", "CONFIRMACIÓN", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.No Then
                        Exit Sub
                    End If


                    idCuenta = CInt(CBO_Cuentas.SelectedValue.ToString)
                End If
                Dim encabezado As Boolean = False
                ''ACTUALIZA EL ENCABEZADO
                'Using objCuentas As New BCL.BCLLiquidacion(GLB_ConStringCipSis)
                '    encabezado = objCuentas.usp_ActualizaEstatusLiquidacion(1, idLiquidacion, "AP", idCuenta, 0, 0, 0, 0, 0, 0, 0, "", 0)
                'End Using
                'If encabezado = False Then
                '    MessageBox.Show("Error al guardar, por favor intenta de nuevo", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                '    Exit Sub
                'End If
                Dim sumSubTotal As Double = 0
                Dim sumGastos As Double = 0
                Dim sumImpuesto As Double = 0
                Dim sumCargo As Double = 0
                Dim sumCredito As Double = 0
                Dim sumDescuento As Double = 0
                Dim sumTotal As Double = 0
                Dim intCont As Integer = 0

                Dim SumImprocedente As Double = 0

                Using objCuentas As New BCL.BCLLiquidacion(GLB_ConStringCipSis)
                    objDataSetFacturasAux = objCuentas.usp_TraerLiquidacionDetalleTransferencia(4, idLiquidacion, "")
                End Using
                Using objCuentas As New BCL.BCLLiquidacion(GLB_ConStringCipSis)
                    objDataSetLiquidacionAux = objCuentas.usp_TraerLiquidacionDetalleTransferencia(5, idLiquidacion, "")
                End Using
                Using objCuentas As New BCL.BCLCatalogoCuentas(GLB_ConStringCipSis)
                    objDataSetChequeAux = objCuentas.usp_TraerCuenta(idCuenta, "")
                End Using
                For i As Integer = 0 To objDataSetLiquidacion.Tables(0).Rows.Count - 1
                    Dim status As String = ""
                    status = objDataSetLiquidacion.Tables(0).Rows(i).Item("status").ToString
                    If status = "" Then
                        Continue For
                    End If
                    Dim idFolio As String = ""
                    idFolio = objDataSetLiquidacion.Tables(0).Rows(i).Item("idfolio").ToString
                    Using objCuentas As New BCL.BCLLiquidacion(GLB_ConStringCipSis)
                        objCuentas.usp_ActualizaLiquidacionDetTransferencia(1, idLiquidacion, idFolio, "", status, "")
                    End Using
                    EmpezoActualizar1 = True
                    intCont += 1
                    If status = 0 Then
                        Using objCuentas As New BCL.BCLCatalogoCuentas(GLB_ConStringCipSis)
                            objCuentas.usp_ActualizaPagoFactura(1, idFolio, 3, "", 0)
                        End Using
                    Else
                        Dim subtotal As Double = objDataSetLiquidacion.Tables(0).Rows(i).Item("subtotal").ToString
                        Dim gastos As Double = objDataSetLiquidacion.Tables(0).Rows(i).Item("gastos").ToString
                        Dim impuesto As Double = objDataSetLiquidacion.Tables(0).Rows(i).Item("impuesto").ToString
                        Dim cargo As Double = objDataSetLiquidacion.Tables(0).Rows(i).Item("cargo").ToString
                        Dim credito As Double = objDataSetLiquidacion.Tables(0).Rows(i).Item("credito").ToString
                        Dim descuento As Double = objDataSetLiquidacion.Tables(0).Rows(i).Item("descuento").ToString
                        Dim Total As Double = objDataSetLiquidacion.Tables(0).Rows(i).Item("total").ToString
                        Dim Improcedente As Double = objDataSetLiquidacion.Tables(0).Rows(i).Item("Improcedente").ToString

                        SumImprocedente += Improcedente
                        sumSubTotal += subtotal
                        sumGastos += gastos
                        sumImpuesto += impuesto
                        sumCargo += cargo
                        sumCredito += credito
                        sumDescuento += descuento
                        sumTotal += Total
                    End If
                Next
                If intCont > 0 Then
                    Using objCuentas As New BCL.BCLLiquidacion(GLB_ConStringCipSis)
                        objCuentas.usp_ActualizaEstatusLiquidacionTransferencia(3, idLiquidacion, "AP", idCuenta, sumSubTotal, sumGastos, sumImpuesto, sumCargo, sumCredito, sumDescuento, sumTotal, Now.ToString("yyyy-MM-dd HH:mm:ss"), GLB_Idempleado)
                    End Using
                    EmpezoActualizar4 = True
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Using objCuentas As New BCL.BCLLiquidacion(GLB_ConStringCipSis)
                    objDataSet = objCuentas.usp_TraerLiquidacionTransferencia(idLiquidacion, "1900-01-01", "1900-01-01", "INSERT INTO clasificacion (status) VALUES ('AP')", "INSERT INTO clasificacion (status) VALUES ('AP')", "INSERT INTO clasificacion (status) VALUES ('AP')", "")
                End Using
                Dim Tipo As String = ""
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Tipo = objDataSet.Tables(0).Rows(0).Item("tipo").ToString
                End If
                Dim objDataSetProveedores As New DataTable
                If Tipo.Trim = "F" Or Tipo.Trim = "T" Then
                    ''SEPARA TODOS LOS PROVEEDORES Y LES ASIGNA UN NUMERO DE CHEQUE
                    objDataSetProveedores.Columns.Add("Proveedor")
                    objDataSetProveedores.Columns.Add("Cheque")
                    Dim Renglones As Integer = 0
                    For i As Integer = 0 To objDataSetLiquidacion.Tables(0).Rows.Count - 1
                        If objDataSetLiquidacion.Tables(0).Rows(i).Item("status").ToString = 0 Then Continue For
                        If CDbl(objDataSetLiquidacion.Tables(0).Rows(i).Item("total").ToString) = 0 Then Continue For
                        If i = 0 Then
                            objDataSetProveedores.Rows.Add()
                            objDataSetProveedores.Rows(Renglones).Item("Proveedor") = objDataSetLiquidacion.Tables(0).Rows(i).Item("Proveedor").ToString
                            Renglones += 1
                        Else
                            Dim blnExiste As Boolean = False
                            For j As Integer = 0 To objDataSetProveedores.Rows.Count - 1
                                If objDataSetLiquidacion.Tables(0).Rows(i).Item("Proveedor").ToString = objDataSetProveedores.Rows(j).Item("Proveedor").ToString Then
                                    blnExiste = True
                                    Continue For
                                Else
                                    blnExiste = False
                                End If
                            Next
                            If blnExiste = False Then
                                objDataSetProveedores.Rows.Add()
                                objDataSetProveedores.Rows(Renglones).Item("Proveedor") = objDataSetLiquidacion.Tables(0).Rows(i).Item("Proveedor").ToString
                                Renglones += 1
                            End If
                        End If
                    Next
                    For i As Integer = 0 To objDataSetProveedores.Rows.Count - 1

                        Dim noCheque As String = i
                        Dim noChequeNvo As String = pub_RellenarIzquierda(CInt(noCheque) + 1, 7)

                        objDataSetProveedores.Rows(i).Item("Cheque") = noCheque
                    Next
                End If
                ''''''''''''''''''''''''''''''''


                ''ACTUALIZA EL DETALLADO Y CAMBIA EL ESTATUS PAGADO EN FACTURAS
                For i As Integer = 0 To objDataSetLiquidacion.Tables(0).Rows.Count - 1
                    If objDataSetLiquidacion.Tables(0).Rows(i).Item("status").ToString = 0 Then Continue For
                    idFolio = objDataSetLiquidacion.Tables(0).Rows(i).Item("idfolio").ToString
                    Proveedor = objDataSetLiquidacion.Tables(0).Rows(i).Item("PROVEEDOR").ToString.Trim
                    Dim noCheque As String = ""
                    Using objCuentas As New BCL.BCLLiquidacion(GLB_ConStringCipSis)
                        objDataSet = objCuentas.usp_TraerLiquidacionTransferencia(idLiquidacion, "1900-01-01", "1900-01-01", "INSERT INTO clasificacion (status) VALUES ('AP')", "INSERT INTO clasificacion (status) VALUES ('AP')", "INSERT INTO clasificacion (status) VALUES ('AP')", "")
                    End Using
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        Tipo = objDataSet.Tables(0).Rows(0).Item("tipo").ToString
                    End If
                    If Tipo.Trim = "F" Or Tipo.Trim = "T" Then
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        For j As Integer = 0 To objDataSetProveedores.Rows.Count - 1
                            If Proveedor = objDataSetProveedores.Rows(j).Item("Proveedor").ToString.Trim Then
                                noCheque = objDataSetProveedores.Rows(j).Item("Cheque").ToString
                                Exit For
                            End If
                        Next
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End If

                    Using objCuentas As New BCL.BCLLiquidacion(GLB_ConStringCipSis)
                        objCuentas.usp_ActualizaLiquidacionDetTransferencia(2, idLiquidacion, idFolio, noCheque, 0, "")
                    End Using
                    EmpezoActualizar3 = True
                    Using objCuentas As New BCL.BCLCatalogoCuentas(GLB_ConStringCipSis)
                        objCuentas.usp_ActualizaPagoFactura(2, idFolio, 1, GLB_FechaHoy.ToString("yyyy-MM-dd"), idLiquidacion)
                    End Using

                Next
                EmpezoActualizar1 = False
                EmpezoActualizar2 = False
                EmpezoActualizar3 = False
                EmpezoActualizar4 = False
                MessageBox.Show("Liquidación aplicada correctamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            End If
            If blnAplicar = False Then
                If MessageBox.Show("Esta seguro que desea generar la liquidación de Pagos?", "CONFIRMACIÓN", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.No Then
                    Exit Sub
                End If
                Dim sumSubTotal As Double = 0
                Dim sumGastos As Double = 0
                Dim sumImpuesto As Double = 0
                Dim sumCargo As Double = 0
                Dim sumCredito As Double = 0
                Dim SumDescuento As Double = 0
                Dim sumTotal As Double = 0
                Dim sumImprocedente As Double = 0

                Dim objDataSetAux As DataSet = objDataSetLiquidacion.Clone
                Dim contador As Integer = 0
                Dim fechaVencimientoIni As Date = DT_FecVencimientoIni.Value.ToString("dd-MM-yyyy")
                Dim fechaVencimientoFin As Date = DT_FecVencimientoFin.Value.ToString("dd-MM-yyyy")
                Dim TipoRF As String = ""
                Dim NoPago As Integer = 0
                EmpezoActualizar1 = False
                EmpezoActualizar2 = False
                EmpezoActualizar3 = False
                If blnCheck = True Then
                    ''''Si hay facturas seleccionadas en la pantalla de facturas pendientes de pago
                    fechaVencimientoIni = "1900-01-01"
                    fechaVencimientoFin = "1900-01-01"
                    For i As Integer = 0 To objDataSetLiquidacion.Tables(0).Rows.Count - 1

                        NoPago = objDataSetLiquidacion.Tables(0).Rows(i).Item("pares")
                        If objDataSetLiquidacion.Tables(0).Rows(i).Item("idfoliosuc").ToString.Trim = "" Then
                            idFolio = 0
                        Else
                            idFolio = objDataSetLiquidacion.Tables(0).Rows(i).Item("idfoliosuc").ToString
                        End If
                        Using objCuentas As New BCL.BCLLiquidacion(GLB_ConStringCipSis)
                            objDataSet = objCuentas.usp_TraerFacturaReferenc(idFolio)
                        End Using
                        Dim Pagado As String = ""
                        Dim Tipo As String = ""
                        If objDataSet.Tables(0).Rows.Count > 0 Then
                            Pagado = objDataSet.Tables(0).Rows(0).Item("pagado").ToString.Trim
                            Tipo = objDataSet.Tables(0).Rows(0).Item("tipo").ToString.Trim
                        End If
                        If Remision Then
                            TipoRF = "R"
                        Else
                            TipoRF = "F"
                        End If
                        Dim TipoPago As String = "3"
                        'If TipoRF = "F" Then
                        '    TipoPago = "3"
                        'Else
                        '    TipoPago = "7"
                        'End If
                        If Pagado = TipoPago And Tipo = TipoRF Then
                            objDataSetAux.Tables(0).LoadDataRow(objDataSetLiquidacion.Tables(0).Rows(i).ItemArray, True)
                            Dim subtotal As Double = objDataSetLiquidacion.Tables(0).Rows(i).Item("SUBTOTAL").ToString
                            Dim gastos As Double = objDataSetLiquidacion.Tables(0).Rows(i).Item("gastos").ToString
                            Dim impuesto As Double = objDataSetLiquidacion.Tables(0).Rows(i).Item("IMPUESTO").ToString
                            Dim cargo As Double = objDataSetLiquidacion.Tables(0).Rows(i).Item("cargo").ToString
                            Dim credito As Double = objDataSetLiquidacion.Tables(0).Rows(i).Item("credito").ToString
                            Dim descuento As Double = objDataSetLiquidacion.Tables(0).Rows(i).Item("descuento").ToString
                            Dim Total As Double = objDataSetLiquidacion.Tables(0).Rows(i).Item("importe").ToString

                            Dim Improcedente As Double = objDataSetLiquidacion.Tables(0).Rows(i).Item("Improcedente").ToString

                            sumImprocedente += Improcedente
                            sumSubTotal += subtotal
                            sumGastos += gastos
                            sumImpuesto += impuesto
                            sumCargo += cargo
                            sumCredito += credito
                            SumDescuento += descuento
                            sumTotal += Total
                            contador += 1
                        End If
                    Next
                Else
                    ''''Si no hay facturas seleccionadas y se piden con los filtros
                    For i As Integer = 0 To objDataSetLiquidacion.Tables(0).Rows.Count - 1
                        Dim FecVen As Date = CDate(objDataSetLiquidacion.Tables(0).Rows(i).Item("fecvenc").ToString).ToString("dd-MM-yyyy")
                        If Chk_Fechas.Checked = True Then
                            ''''CON FECHAS
                            If FecVen >= fechaVencimientoIni And FecVen <= fechaVencimientoFin Then
                                If objDataSetLiquidacion.Tables(0).Rows(i).Item("idfoliosuc").ToString.Trim = "" Then
                                    idFolio = 0
                                Else
                                    idFolio = objDataSetLiquidacion.Tables(0).Rows(i).Item("idfoliosuc").ToString
                                End If
                                Using objCuentas As New BCL.BCLLiquidacion(GLB_ConStringCipSis)
                                    objDataSet = objCuentas.usp_TraerFacturaReferenc(idFolio)
                                End Using
                                Dim Pagado As String = ""
                                Dim Tipo As String = ""
                                If objDataSet.Tables(0).Rows.Count > 0 Then
                                    Pagado = objDataSet.Tables(0).Rows(0).Item("pagado").ToString.Trim
                                    Tipo = objDataSet.Tables(0).Rows(0).Item("tipo").ToString.Trim
                                End If
                                If Remision Then
                                    TipoRF = "R"
                                Else
                                    TipoRF = "F"
                                End If
                                Dim TipoPago As String = "3"
                                'If TipoRF = "F" Then
                                '    TipoPago = "3"
                                'Else
                                '    TipoPago = "7"
                                'End If
                                If Pagado = TipoPago And Tipo = TipoRF Then
                                    If Txt_Proveedor.Text.Trim = "" Then
                                        objDataSetAux.Tables(0).LoadDataRow(objDataSetLiquidacion.Tables(0).Rows(i).ItemArray, True)
                                        Dim subtotal As Double = objDataSetLiquidacion.Tables(0).Rows(i).Item("SUBTOTAL").ToString
                                        Dim gastos As Double = objDataSetLiquidacion.Tables(0).Rows(i).Item("gastos").ToString
                                        Dim impuesto As Double = objDataSetLiquidacion.Tables(0).Rows(i).Item("IMPUESTO").ToString
                                        Dim cargo As Double = objDataSetLiquidacion.Tables(0).Rows(i).Item("cargo").ToString
                                        Dim credito As Double = objDataSetLiquidacion.Tables(0).Rows(i).Item("credito").ToString
                                        Dim descuento As Double = objDataSetLiquidacion.Tables(0).Rows(i).Item("descuento").ToString
                                        Dim Total As Double = objDataSetLiquidacion.Tables(0).Rows(i).Item("importe").ToString

                                        Dim Improcedente As Double = objDataSetLiquidacion.Tables(0).Rows(i).Item("Improcedente").ToString

                                        sumImprocedente += Improcedente
                                        sumSubTotal += subtotal
                                        sumGastos += gastos
                                        sumImpuesto += impuesto
                                        sumCargo += cargo
                                        sumCredito += credito
                                        SumDescuento += descuento
                                        sumTotal += Total
                                        contador += 1
                                    Else
                                        Dim Prov As String = Txt_Proveedor.Text.Trim + " - " + Txt_Raz_Soc.Text.Trim
                                        If objDataSetLiquidacion.Tables(0).Rows(i).Item("Proveedor").ToString.Trim = Prov Then
                                            objDataSetAux.Tables(0).LoadDataRow(objDataSetLiquidacion.Tables(0).Rows(i).ItemArray, True)
                                            Dim subtotal As Double = objDataSetLiquidacion.Tables(0).Rows(i).Item("SUBTOTAL").ToString
                                            Dim gastos As Double = objDataSetLiquidacion.Tables(0).Rows(i).Item("gastos").ToString
                                            Dim impuesto As Double = objDataSetLiquidacion.Tables(0).Rows(i).Item("IMPUESTO").ToString
                                            Dim cargo As Double = objDataSetLiquidacion.Tables(0).Rows(i).Item("cargo").ToString
                                            Dim credito As Double = objDataSetLiquidacion.Tables(0).Rows(i).Item("credito").ToString
                                            Dim descuento As Double = objDataSetLiquidacion.Tables(0).Rows(i).Item("descuento").ToString
                                            Dim Total As Double = objDataSetLiquidacion.Tables(0).Rows(i).Item("importe").ToString
                                            Dim Improcedente As Double = objDataSetLiquidacion.Tables(0).Rows(i).Item("Improcedente").ToString

                                            sumImprocedente += Improcedente
                                            sumSubTotal += subtotal
                                            sumGastos += gastos
                                            sumImpuesto += impuesto
                                            sumCargo += cargo
                                            sumCredito += credito
                                            SumDescuento += descuento
                                            sumTotal += Total
                                            contador += 1
                                        End If
                                    End If
                                End If
                            End If
                        Else
                            ''''SIN FECHAS
                            fechaVencimientoIni = "1900-01-01"
                            fechaVencimientoFin = "1900-01-01"
                            If objDataSetLiquidacion.Tables(0).Rows(i).Item("idfoliosuc").ToString.Trim = "" Then
                                idFolio = 0
                            Else
                                idFolio = objDataSetLiquidacion.Tables(0).Rows(i).Item("idfoliosuc").ToString
                            End If
                            Using objCuentas As New BCL.BCLLiquidacion(GLB_ConStringCipSis)
                                objDataSet = objCuentas.usp_TraerFacturaReferenc(idFolio)
                            End Using
                            Dim Pagado As String = ""
                            Dim Tipo As String = ""
                            If objDataSet.Tables(0).Rows.Count > 0 Then
                                Pagado = objDataSet.Tables(0).Rows(0).Item("pagado").ToString.Trim
                                Tipo = objDataSet.Tables(0).Rows(0).Item("tipo").ToString.Trim
                            End If
                            If Remision Then
                                TipoRF = "R"
                            Else
                                TipoRF = "F"
                            End If
                            Dim TipoPago As String = "3"
                            'If TipoRF = "F" Then
                            '    TipoPago = "3"
                            'Else
                            '    TipoPago = "7"
                            'End If
                            If Pagado = TipoPago And Tipo = TipoRF Then
                                If Txt_Proveedor.Text.Trim = "" Then
                                    objDataSetAux.Tables(0).LoadDataRow(objDataSetLiquidacion.Tables(0).Rows(i).ItemArray, True)
                                    Dim subtotal As Double = objDataSetLiquidacion.Tables(0).Rows(i).Item("SUBTOTAL").ToString
                                    Dim gastos As Double = objDataSetLiquidacion.Tables(0).Rows(i).Item("gastos").ToString
                                    Dim impuesto As Double = objDataSetLiquidacion.Tables(0).Rows(i).Item("IMPUESTO").ToString
                                    Dim cargo As Double = objDataSetLiquidacion.Tables(0).Rows(i).Item("cargo").ToString
                                    Dim credito As Double = objDataSetLiquidacion.Tables(0).Rows(i).Item("credito").ToString
                                    Dim descuento As Double = objDataSetLiquidacion.Tables(0).Rows(i).Item("descuento").ToString
                                    Dim Total As Double = objDataSetLiquidacion.Tables(0).Rows(i).Item("importe").ToString
                                    Dim Improcedente As Double = objDataSetLiquidacion.Tables(0).Rows(i).Item("Improcedente").ToString

                                    sumImprocedente += Improcedente
                                    sumSubTotal += subtotal
                                    sumGastos += gastos
                                    sumImpuesto += impuesto
                                    sumCargo += cargo
                                    sumCredito += credito
                                    SumDescuento += descuento
                                    sumTotal += Total
                                    contador += 1
                                Else
                                    Dim Prov As String = Txt_Proveedor.Text.Trim + " - " + Txt_Raz_Soc.Text.Trim
                                    If objDataSetLiquidacion.Tables(0).Rows(i).Item("Proveedor").ToString.Trim = Prov Then
                                        objDataSetAux.Tables(0).LoadDataRow(objDataSetLiquidacion.Tables(0).Rows(i).ItemArray, True)
                                        Dim subtotal As Double = objDataSetLiquidacion.Tables(0).Rows(i).Item("SUBTOTAL").ToString
                                        Dim gastos As Double = objDataSetLiquidacion.Tables(0).Rows(i).Item("gastos").ToString
                                        Dim impuesto As Double = objDataSetLiquidacion.Tables(0).Rows(i).Item("IMPUESTO").ToString
                                        Dim cargo As Double = objDataSetLiquidacion.Tables(0).Rows(i).Item("cargo").ToString
                                        Dim credito As Double = objDataSetLiquidacion.Tables(0).Rows(i).Item("credito").ToString
                                        Dim descuento As Double = objDataSetLiquidacion.Tables(0).Rows(i).Item("descuento").ToString
                                        Dim Total As Double = objDataSetLiquidacion.Tables(0).Rows(i).Item("importe").ToString
                                        Dim Improcedente As Double = objDataSetLiquidacion.Tables(0).Rows(i).Item("Improcedente").ToString

                                        sumImprocedente += Improcedente
                                        sumSubTotal += subtotal
                                        sumGastos += gastos
                                        sumImpuesto += impuesto
                                        sumCargo += cargo
                                        sumCredito += credito
                                        SumDescuento += descuento
                                        sumTotal += Total
                                        contador += 1
                                    End If
                                End If
                            End If
                        End If
                    Next
                End If
                If contador > 0 Then
                    Dim encabezado As Boolean = False
                    Using objCuentas As New BCL.BCLLiquidacion(GLB_ConStringCipSis)
                        encabezado = objCuentas.usp_CapturaLiquidacionTransferencia(0, sumSubTotal, sumGastos, sumImpuesto, sumCargo, sumCredito, SumDescuento, sumTotal, "GE", TipoRF, Now.ToString("yyyy-MM-dd HH:mm:ss"), GLB_Idempleado, fechaVencimientoIni, fechaVencimientoFin, sumImprocedente)
                    End Using
                    If encabezado = False Then
                        MessageBox.Show("Error al guardar, por favor intenta de nuevo", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If
                    Dim idLiquidacion As Integer = 0
                    Using objCuentas As New BCL.BCLLiquidacion(GLB_ConStringCipSis)
                        idLiquidacion = CInt(objCuentas.usp_TraerIdLiquidaciontransferencia().Tables(0).Rows(0).Item("idliquidacion").ToString)
                    End Using
                    'Using objCuentas As New BCL.BCLLiquidacion(GLB_ConStringCipSis)
                    '    objDataSetFacturasAux = objCuentas.usp_TraerLiquidacionDetalle(4, idLiquidacion, "")
                    'End Using
                    For i As Integer = 0 To objDataSetAux.Tables(0).Rows.Count - 1
                        Dim Factura As String = ""
                        If objDataSetAux.Tables(0).Rows(i).Item("idfoliosuc").ToString.Trim = "" Then
                            idFolio = 0
                        Else
                            idFolio = objDataSetAux.Tables(0).Rows(i).Item("idfoliosuc").ToString
                        End If
                        Proveedor = objDataSetAux.Tables(0).Rows(i).Item("proveedor").ToString
                        Dim FechaFactura As Date = objDataSetAux.Tables(0).Rows(i).Item("fecha").ToString
                        Dim Fecha As Date = objDataSetAux.Tables(0).Rows(i).Item("fecvenc").ToString
                        Dim subtotal As Double = objDataSetAux.Tables(0).Rows(i).Item("SUBTOTAL").ToString
                        Dim gastos As Double = objDataSetAux.Tables(0).Rows(i).Item("gastos").ToString
                        Dim impuesto As Double = objDataSetAux.Tables(0).Rows(i).Item("IMPUESTO").ToString
                        Dim cargo As Double = objDataSetAux.Tables(0).Rows(i).Item("cargo").ToString
                        Dim credito As Double = objDataSetAux.Tables(0).Rows(i).Item("credito").ToString
                        Dim descuento As Double = objDataSetAux.Tables(0).Rows(i).Item("descuento").ToString
                        Dim Total As Double = objDataSetAux.Tables(0).Rows(i).Item("importe").ToString
                        Dim Improcedente As Double = objDataSetAux.Tables(0).Rows(i).Item("Improcedente").ToString

                        Using objCuentas As New BCL.BCLLiquidacion(GLB_ConStringCipSis)
                            Factura = objCuentas.usp_TraerFacturaReferenc(idFolio).Tables(0).Rows(0).Item("referenc").ToString
                        End Using
                        Using objCuentas As New BCL.BCLLiquidacion(GLB_ConStringCipSis)
                            objCuentas.usp_CapturaLiquidacionDetTransferencia(idLiquidacion, idFolio, "", Proveedor, Factura, 1, FechaFactura, Fecha, subtotal, gastos, impuesto, cargo, credito, descuento, Total, Improcedente)
                        End Using

                        Using objCuentas As New BCL.BCLCatalogoCuentas(GLB_ConStringCipSis)
                            objCuentas.usp_ActualizaPagoFactura(1, idFolio, 4, "", 0)
                        End Using

                    Next

                    MessageBox.Show("Liquidación Generada correctamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                    If MessageBox.Show("Desea abrir el Catálogo de Liquidaciones?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                        Exit Sub
                    End If
                    Dim myForm As New frmCatalogoLiquidacion
                    myForm.MdiParent = BitacoraMain
                    myForm.Show()
                Else
                    MessageBox.Show("No hay facturas que cumplan los filtros seleccionados", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.Close()
                    Exit Sub
                End If
            End If
        Catch ExceptionErr As Exception
            Try
                If blnAplicar = True Then
                    If EmpezoActualizar1 = True Then
                        For i As Integer = 0 To objDataSetFacturasAux.Tables(0).Rows.Count - 1
                            Using objCuentas As New BCL.BCLCatalogoCuentas(GLB_ConStringCipSis)
                                objCuentas.usp_ActualizaPagoFactura(1, objDataSetFacturasAux.Tables(0).Rows(i).Item("idfoliosuc").ToString, objDataSetFacturasAux.Tables(0).Rows(i).Item("pagado").ToString, "", 0)
                            End Using
                        Next
                        For i As Integer = 0 To objDataSetLiquidacionAux.Tables(0).Rows.Count - 1
                            Using objCuentas As New BCL.BCLLiquidacion(GLB_ConStringCipSis)
                                objCuentas.usp_ActualizaLiquidacionDetTransferencia(1, objDataSetLiquidacionAux.Tables(0).Rows(i).Item("idliquidacion").ToString, objDataSetLiquidacionAux.Tables(0).Rows(i).Item("idfolio").ToString, "", objDataSetLiquidacionAux.Tables(0).Rows(i).Item("status").ToString, "")
                            End Using
                        Next
                    End If
                    If EmpezoActualizar4 = True Then
                        Using objCuentas As New BCL.BCLLiquidacion(GLB_ConStringCipSis)
                            objCuentas.usp_ActualizaEstatusLiquidacionTransferencia(1, objDataSetLiquidacion.Tables(0).Rows(0).Item("idliquidacion").ToString, "RV", 0, 0, 0, 0, 0, 0, 0, 0, "", 0)
                        End Using
                    End If
                    ''If EmpezoActualizar2 = True Then
                    ''    Using objCuentas As New BCL.BCLCatalogoCuentas(GLB_ConStringCipSis)
                    ''        objCuentas.usp_ActualizaNoCheque(idCuenta, objDataSetChequeAux.Tables(0).Rows(0).Item("cheque").ToString)
                    ''    End Using
                    ''End If
                    If EmpezoActualizar3 = True Then
                        For i As Integer = 0 To objDataSetFacturasAux.Tables(0).Rows.Count - 1
                            Using objCuentas As New BCL.BCLCatalogoCuentas(GLB_ConStringCipSis)
                                objCuentas.usp_ActualizaPagoFactura(2, objDataSetFacturasAux.Tables(0).Rows(i).Item("idfoliosuc").ToString, objDataSetFacturasAux.Tables(0).Rows(i).Item("pagado").ToString, objDataSetFacturasAux.Tables(0).Rows(i).Item("fecpag").ToString, objDataSetFacturasAux.Tables(0).Rows(i).Item("idliquidacion").ToString)
                            End Using
                        Next
                        For i As Integer = 0 To objDataSetLiquidacionAux.Tables(0).Rows.Count - 1
                            Using objCuentas As New BCL.BCLLiquidacion(GLB_ConStringCipSis)
                                objCuentas.usp_ActualizaLiquidacionDetTransferencia(2, objDataSetLiquidacionAux.Tables(0).Rows(i).Item("idliquidacion").ToString, objDataSetLiquidacionAux.Tables(0).Rows(i).Item("idfolio").ToString, objDataSetLiquidacionAux.Tables(0).Rows(i).Item("nocheque").ToString, 0, "")
                            End Using
                        Next
                    End If
                    MessageBox.Show("Error al hacer los cambios, por favor vuelve a intentarlo", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    'Else
                    '    For i As Integer = 0 To objDataSetFacturasAux.Tables(0).Rows.Count - 1
                    '        Using objCuentas As New BCL.BCLCatalogoCuentas(GLB_ConStringCipSis)
                    '            objCuentas.usp_ActualizaPagoFactura(1, objDataSetFacturasAux.Tables(0).Rows(i).Item("idfolio").ToString, objDataSetFacturasAux.Tables(0).Rows(i).Item("pagado").ToString, "", 0)
                    '        End Using
                    '    Next
                End If
                MessageBox.Show(ExceptionErr.Message.ToString)
            Catch ExceptionEr1 As Exception
                MessageBox.Show(ExceptionEr1.Message.ToString)
            End Try
        End Try
    End Sub

    Private Sub CBO_Cuentas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBO_Cuentas.SelectedIndexChanged
        Try
            If CBO_Cuentas.SelectedValue.ToString = "System.Data.DataRowView" Then Exit Sub
            Dim idCuenta As Integer = CBO_Cuentas.SelectedValue.ToString
            Using objCuentas As New BCL.BCLCatalogoCuentas(GLB_ConStringCipSis)
                Label3.Text = objCuentas.usp_TraerCuenta(idCuenta, "").Tables(0).Rows(0).Item("nocheque").ToString
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_Proveedor_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Proveedor.LostFocus
        Try
            If Txt_Proveedor.Text.Length = 0 Then Exit Sub
            If Txt_Proveedor.Text.Trim.Length < 3 Then
                Txt_Proveedor.Text = pub_RellenarIzquierda(Txt_Proveedor.Text.Trim, 3)
            End If
            Call TxtLostfocus(Txt_Proveedor, Txt_Raz_Soc, "P")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub TxtLostfocus(ByVal Txt_Campo As TextBox, ByVal Txt_Campo1 As TextBox, ByVal Tipo As String)
        'mreyes 28/Febrero/2012 10:49 a.m.
        Dim myForm As New frmConsulta


        If Txt_Campo.Text.Length = 0 Then Exit Sub
        Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringCipSis)
            Try
                objDataSet = objMySqlGral.usp_TraerDescripcion(Tipo, Txt_Campo.Text, "")
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_Campo1.Text = objDataSet.Tables(0).Rows(0).Item("campo").ToString
                Else
                    Txt_Campo.Text = ""
                    myForm.Tipo = Tipo
                    myForm.ShowDialog()
                    Txt_Campo.Text = myForm.Campo
                    Txt_Campo1.Text = myForm.Campo1
                    If Txt_Campo.Text.Length = 0 Then
                        Txt_Campo.Focus()
                    End If
                End If


            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub Btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cancelar.Click
        Try
            Me.Close()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Limpiar.Click
        Try
            Chk_Fechas.Checked = False
            DT_FecVencimientoFin.Value = GLB_FechaHoy
            DT_FecVencimientoIni.Value = GLB_FechaHoy
            DT_FecVencimientoFin.Enabled = False
            DT_FecVencimientoIni.Enabled = False
            Txt_Proveedor.Text = ""
            Txt_Raz_Soc.Text = ""
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Public Function pub_TraerIdFolioBulto(ByVal IdFolioSuc As String) As Integer
        'mreyes 25/Junio/2013 01:03 p.m.
        Try
            Dim objDataSet As Data.DataSet
            pub_TraerIdFolioBulto = 0
            Using objParame_Det As New BCL.BCLBulto(GLB_ConStringCipSis)
                objDataSet = objParame_Det.pub_TraerIdFolio(IdFolioSuc)
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    pub_TraerIdFolioBulto = objDataSet.Tables(0).Rows(0).Item("idfolio").ToString
                End If

            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
            pub_TraerIdFolioBulto = 0
        End Try
    End Function
    Private Sub Chk_Fechas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_Fechas.CheckedChanged
        Try
            If Chk_Fechas.Checked = True Then
                DT_FecVencimientoFin.Enabled = True
                DT_FecVencimientoIni.Enabled = True
            Else
                DT_FecVencimientoFin.Enabled = False
                DT_FecVencimientoIni.Enabled = False
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
End Class