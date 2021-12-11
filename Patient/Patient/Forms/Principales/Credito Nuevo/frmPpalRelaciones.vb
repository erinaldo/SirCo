Imports DevExpress.XtraGrid.Views.Grid
Public Class frmPpalRelaciones
    Dim Sw_Pdf As Boolean = False

    Private Sub Btn_Refrescar_Click(sender As Object, e As EventArgs)
        Call RellenaGrid()
    End Sub
    Sub InicializaGrid()
        'GridView1
        Try
            GridView2.BestFitColumns()

            GridView2.Columns(0).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView2.Columns(1).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

            'GridView2.Columns(1).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView2.Columns(1).AppearanceHeader.Font = New Font(GridView2.Columns(1).AppearanceCell.Font, FontStyle.Bold)
            GridView2.Columns(2).AppearanceHeader.Font = New Font(GridView2.Columns(1).AppearanceCell.Font, FontStyle.Bold)

            GridView2.Columns(0).Caption = "Distrib"
            GridView2.Columns(1).Caption = "Nombre"
            GridView2.Columns(2).Caption = "Total"


            GridView2.OptionsView.ColumnAutoWidth = False
            GridView2.OptionsView.BestFitMaxRowCount = -1
            GridView2.BestFitColumns()


            GridView2.Columns(2).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            GridView2.Columns(2).DisplayFormat.FormatString = "#,###,###"
            GridView2.Columns(2).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView2.Columns(2).AppearanceHeader.Font = New Font(GridView2.Columns(2).AppearanceCell.Font, FontStyle.Bold)



            ' Call Colorear()
            GridView2.FixedLineWidth = 4
            GridView2.Columns(0).Fixed = 0

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
        'GridView.BestFitColumns or GridColumn.BestFit 
    End Sub
    Private Sub RellenaGrid()
        'mreyes 26/Octubre/2017     04:55 p.m.

        Dim objDataSet As Data.DataSet
        Dim idsucursal As Integer = 0
        Dim TipoCredito As String = ""
        TipoCredito = usp_GeneraTipoCredito()

        If Cbo_Sucursal.Text = "CRÉDITO" Then
            idsucursal = 99
        ElseIf Cbo_Sucursal.Text = "TRIANA" Then
            idsucursal = 6
        End If

        Using objTrasp As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)

            Try
                Me.Cursor = Cursors.WaitCursor

                'DGrid.ReadOnly = True
                ' GridControl.DataSource = Nothing

                objDataSet = objTrasp.usp_PpalRelacionesBlindaje(1, Txt_Distrib1.Text, Txt_Distrib2.Text, TipoCredito, DEFechaIni.Text, idsucursal)


                'Populate the Project Details section

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    'Populate the Project Details section www
                    'DGrid.ColumnCount = objDataSet.Tables(0).Columns.Count

                    Dgrid.DataSource = objDataSet.Tables(0)

                    InicializaGrid()

                    Me.Cursor = Cursors.Default

                Else


                    Me.Cursor = Cursors.Default
                    MsgBox("No se encontraron Estados de Cuenta, que cumplan sus filtros... Intente nuevamente", MsgBoxStyle.Critical, "Aviso")

                End If
                Me.Cursor = Cursors.Default
                ' LimpiarBusqueda()

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub Dgrid_Click(sender As Object, e As EventArgs) Handles Dgrid.Click

    End Sub

    Private Sub RellenaGridEstadoCuenta(Opcion As Integer)
        'mreyes 10/Abril/2018   01:52 p.m.

        Dim objDataSet As DataSet
        Dim idsucursal As Integer = 0
        Dim TipoCredito As String = ""
        TipoCredito = usp_GeneraTipoCredito()

        If Cbo_Sucursal.Text = "CRÉDITO" Then
            idsucursal = 99
        ElseIf Cbo_Sucursal.Text = "TRIANA" Then
            idsucursal = 6
        End If


        Using objTrasp As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)

            Try
                Me.Cursor = Cursors.WaitCursor

                'DGrid.ReadOnly = True
                ' GridControl.DataSource = Nothing

                objDataSet = objTrasp.usp_PpalRelacionesBlindaje(2, Txt_Distrib1.Text, Txt_Distrib2.Text, TipoCredito, DEFechaIni.Text, idsucursal)


                'Populate the Project Details section

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    If Opcion = 0 Then
                        Call AbrirReporte(1, objDataSet, "")
                        Call AbrirReporte(2, objDataSet, "")
                        '  Call AbrirReporte(3, objDataSet)
                    ElseIf Opcion = 1 Then
                        Call AbrirReporte(1, objDataSet, "")

                    Else
                        Call AbrirReporte(2, objDataSet, "")
                    End If
                End If
                Me.Cursor = Cursors.Default
                ' LimpiarBusqueda()

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub


    Private Sub RellenaGridEstadoCuentaPDF(Opcion As Integer)
        'mreyes 06/Abril/2020   11:49 a.m.
        Try

            Dim objDataSet As DataSet
            Dim idsucursal As Integer = 0
            Dim TipoCredito As String = ""
            Dim Nombre As String = ""
            TipoCredito = usp_GeneraTipoCredito()

            If Cbo_Sucursal.Text = "CRÉDITO" Then
                idsucursal = 99
            ElseIf Cbo_Sucursal.Text = "TRIANA" Then
                idsucursal = 6
            End If

            Do While Val(Txt_Distrib1.Text) <= Val(Txt_Distrib2.Text)

                Using objTrasp As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)

                    Try
                        Me.Cursor = Cursors.WaitCursor

                        'DGrid.ReadOnly = True
                        ' GridControl.DataSource = Nothing

                        objDataSet = objTrasp.usp_PpalRelacionesBlindaje(2, Txt_Distrib1.Text, Txt_Distrib1.Text, TipoCredito, DEFechaIni.Text, idsucursal)


                        'Populate the Project Details section

                        If objDataSet.Tables(0).Rows.Count > 0 Then
                            Nombre = objDataSet.Tables(0).Rows(0).Item("distrib").ToString & "_" & Trim(objDataSet.Tables(0).Rows(0).Item("nombrecompleto").ToString)
                            If Opcion = 0 Then
                                Call AbrirReporte(1, objDataSet, Nombre & "_Edo.pdf")
                                Call AbrirReporte(2, objDataSet, Nombre & "_Rec.pdf")
                                '  Call AbrirReporte(3, objDataSet)
                            ElseIf Opcion = 1 Then
                                Call AbrirReporte(1, objDataSet, Nombre)

                            Else
                                Call AbrirReporte(2, objDataSet, Nombre)
                            End If
                        End If
                        Me.Cursor = Cursors.Default
                        ' LimpiarBusqueda()
                        Txt_Distrib1.Text = pub_RellenarIzquierda(Val(Txt_Distrib1.Text) + 1, 6)

                    Catch ExceptionErr As Exception
                        MessageBox.Show(ExceptionErr.Message.ToString)
                    End Try
                End Using
            Loop


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Function usp_TraerMes(Mes As String) As String
        Try
            Dim Letra As String = ""

            If Mes = "1" Or Mes = "01" Then
                Letra = "ENE"
            ElseIf Mes = "2" Or Mes = "02" Then
                Letra = "FEB"
            ElseIf Mes = "3" Or Mes = "03" Then
                Letra = "MAR"
            ElseIf Mes = "4" Or Mes = "04" Then
                Letra = "ABR"
            ElseIf Mes = "5" Or Mes = "05" Then
                Letra = "MAY"
            ElseIf Mes = "6" Or Mes = "06" Then
                Letra = "JUN"
            ElseIf Mes = "7" Or Mes = "07" Then
                Letra = "JUL"
            ElseIf Mes = "8" Or Mes = "08" Then
                Letra = "AGO"
            ElseIf Mes = "9" Or Mes = "09" Then
                Letra = "SEP"
            ElseIf Mes = "10" Or Mes = "10" Then
                Letra = "OCT"
            ElseIf Mes = "11" Or Mes = "11" Then
                Letra = "NOV"
            ElseIf Mes = "12" Or Mes = "12" Then
                Letra = "DIC"

            End If
            Return Letra
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Function
    Private Sub AbrirReporte(Opcion As Integer, ObjDataSet As DataSet, Nombre As String)
        'mreyes 13/Abril/2018   11:33 a.m.
        Try
            Dim dia As Integer = 0
            Dim mesi As String = ""
            Dim mes As String = ""
            Dim anio As Integer = 0

            dia = Format(CDate(DEFechaIni.Text), "dd")
            mesi = Format(CDate(DEFechaIni.Text), "MM")
            mes = Format(CDate(DEFechaIni.Text), "MM")
            anio = Format(CDate(DEFechaIni.Text), "yyyy")

            If Opcion = 1 Then
                Dim myForm1 As New frmReportsBrowser
                Me.Cursor = Cursors.Default
                myForm1.objDataSetEstadoCuenta = GenerarEstadoCuenta(ObjDataSet)
                myForm1.Text = "Estados de Cuenta"
                myForm1.r_Descto1 = "12"
                myForm1.r_Descto2 = "12"
                myForm1.r_Descto3 = "12"
                myForm1.r_Descto4 = "12"
                myForm1.r_Descto5 = "11"
                myForm1.r_Descto6 = "10"
                myForm1.r_Descto7 = "0"

                If dia = 6 Or dia = 7 Then
                    myForm1.r_Fecha1 = "17" & "-" & usp_TraerMes(mes)
                    myForm1.r_Fecha2 = "18" & "-" & usp_TraerMes(mes)
                    myForm1.r_Fecha3 = "19" & "-" & usp_TraerMes(mes)
                    myForm1.r_Fecha4 = "20" & "-" & usp_TraerMes(mes)
                    myForm1.r_Fecha5 = "21" & "-" & usp_TraerMes(mes)
                    myForm1.r_Fecha6 = "22" & "-" & usp_TraerMes(mes)
                    myForm1.r_Fecha7 = "23" & "-" & usp_TraerMes(mes)
                ElseIf dia = 21 Or dia = 22 Then
                    If mesi = 12 Then
                        mesi = "01"
                    Else
                        mesi = Format(mesi + 1, "00")
                    End If

                    mes = Format(CDate(DEFechaIni.Text), "MM")

                    myForm1.r_Fecha1 = "02" & "-" & usp_TraerMes(mesi)
                    myForm1.r_Fecha2 = "03" & "-" & usp_TraerMes(mesi)
                    myForm1.r_Fecha3 = "04" & "-" & usp_TraerMes(mesi)
                    myForm1.r_Fecha4 = "05" & "-" & usp_TraerMes(mesi)
                    myForm1.r_Fecha5 = "06" & "-" & usp_TraerMes(mesi)
                    myForm1.r_Fecha6 = "07" & "-" & usp_TraerMes(mesi)
                    myForm1.r_Fecha7 = "08" & "-" & usp_TraerMes(mesi)

                End If

                myForm1.Sw_Pdf = Sw_Pdf
                myForm1.RutaGuardarPedidoNuevo = "c:\pdf\" & Nombre
                myForm1.ReportIndex = 6003
                myForm1.Show()
            End If
            If Opcion = 2 Then
                Dim myForm As New frmReportsBrowser
                Me.Cursor = Cursors.Default
                myForm.objDataSetImprimeRecibo = GenerarRecibo(ObjDataSet)
                myForm.Text = "Impresión de Recibos"


                If dia = 6 Or dia = 7 Then
                    myForm.r_Entrega = "15" & "/" & mes & "/" & anio

                ElseIf dia = 21 Or dia = 22 Then
                    mesi = mesi + 1
                    mes = Format(CDate(DEFechaIni.Text), "MM")
                    If mes = 1 Or mes = 3 Or mes = 5 Or mes = 7 Or mes = 8 Or mes = 10 Or mes = 12 Then
                        myForm.r_Entrega = "31" & "/" & mes & "/" & anio
                    ElseIf mes = 6 Or mes = 9 Or mes = 11 Or mes = 4 Then
                        myForm.r_Entrega = "30" & "/" & mes & "/" & anio
                    Else
                        myForm.r_Entrega = "28" & "/" & mes & "/" & anio
                    End If
                End If

                myForm.Sw_Pdf = Sw_Pdf
                myForm.RutaGuardarPedidoNuevo = "c:\pdf\" & Nombre
                myForm.ReportIndex = 42
                myForm.Show()
            End If

            'If Opcion = 3 Then
            '    Dim myForm As New frmReportsBrowser
            '    Me.Cursor = Cursors.Default
            '    myForm.objDataSetImprimeReciboImagen = GenerarReciboImagen(ObjDataSet)
            '    myForm.Text = "Listado de Saldos Vencidos con Dirección"

            '    myForm.ReportIndex = 55
            '    myForm.Show()
            'End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub



    Private Function GenerarEstadoCuenta(ObjDataSet As DataSet) As DSEstadoCuenta
        'mreyes 10/Abril/2018   01:50 p.m.
        Dim Cont As Integer = 0
        Dim SaldoAnterior As Decimal = 0
        Dim Distrib = ""
        Dim NombreCompleto = ""
        Dim FechaPago As Date = "1900-01-01"
        Dim FechaCorte As Date = "1900-01-01"
        Dim Apagar As Decimal = 0
        Dim NombreCliente As String = ""

        Try
            GenerarEstadoCuenta = New DSEstadoCuenta
            For I As Integer = 0 To ObjDataSet.Tables(0).Rows.Count - 1
                SaldoAnterior = Val(ObjDataSet.Tables(0).Rows(I).Item("saldo").ToString)
                FechaPago = Format(CDate(ObjDataSet.Tables(0).Rows(I).Item("fechavencimiento").ToString), "dd/MM/yyyy")
                Distrib = ObjDataSet.Tables(0).Rows(I).Item("distrib").ToString
                NombreCompleto = ObjDataSet.Tables(0).Rows(I).Item("nombrecompleto").ToString
                FechaCorte = Format(CDate(ObjDataSet.Tables(0).Rows(I).Item("fechacorte").ToString), "dd/MM/yyyy")
                Apagar = Val(ObjDataSet.Tables(0).Rows(I).Item("apagar").ToString)
                NombreCliente = ObjDataSet.Tables(0).Rows(I).Item("nombreclie").ToString



                Dim objDataRow As Data.DataRow = GenerarEstadoCuenta.Tables("Tbl_EstadoCuenta").NewRow()
                objDataRow.Item("Distrib") = ObjDataSet.Tables(0).Rows(I).Item("distrib").ToString

                objDataRow.Item("nombrecompleto") = ObjDataSet.Tables(0).Rows(I).Item("nombrecompleto").ToString

                objDataRow.Item("sucursal") = ObjDataSet.Tables(0).Rows(I).Item("sucursal").ToString
                objDataRow.Item("nota") = ObjDataSet.Tables(0).Rows(I).Item("nota").ToString
                objDataRow.Item("fechacompra") = Format(CDate(ObjDataSet.Tables(0).Rows(I).Item("fechacompra").ToString), "dd/MM/yyyy")
                objDataRow.Item("negocio") = ObjDataSet.Tables(0).Rows(I).Item("negocio").ToString
                objDataRow.Item("vale") = ObjDataSet.Tables(0).Rows(I).Item("vale").ToString
                objDataRow.Item("succliente") = ObjDataSet.Tables(0).Rows(I).Item("succliente").ToString
                objDataRow.Item("cliente") = ObjDataSet.Tables(0).Rows(I).Item("cliente").ToString
                objDataRow.Item("nombreclie") = ObjDataSet.Tables(0).Rows(I).Item("nombreclie").ToString
                objDataRow.Item("totalcompra") = Val(ObjDataSet.Tables(0).Rows(I).Item("totalcompra").ToString)
                objDataRow.Item("saldo") = Val(ObjDataSet.Tables(0).Rows(I).Item("saldo").ToString)
                objDataRow.Item("pago") = Val(ObjDataSet.Tables(0).Rows(I).Item("pago").ToString)
                objDataRow.Item("pagos") = Val(ObjDataSet.Tables(0).Rows(I).Item("pagos").ToString)
                objDataRow.Item("numpagos") = ObjDataSet.Tables(0).Rows(I).Item("numpagos").ToString
                objDataRow.Item("fechavencimiento") = Format(CDate(ObjDataSet.Tables(0).Rows(I).Item("fechavencimiento").ToString), "dd/MM/yyyy")

                objDataRow.Item("apagar") = Val(ObjDataSet.Tables(0).Rows(I).Item("apagar").ToString)
                objDataRow.Item("fechapago") = Format(CDate(ObjDataSet.Tables(0).Rows(I).Item("fechapago").ToString), "dd/MM/yyyy")

                objDataRow.Item("saldodistrib") = Val(ObjDataSet.Tables(0).Rows(I).Item("saldodistrib").ToString)


                objDataRow.Item("limitecredito") = Val(ObjDataSet.Tables(0).Rows(I).Item("limitecredito").ToString)
                objDataRow.Item("disponible") = Val(ObjDataSet.Tables(0).Rows(I).Item("disponible").ToString)
                objDataRow.Item("fechacorte") = Format(CDate(ObjDataSet.Tables(0).Rows(I).Item("fechacorte").ToString), "dd/MM/yyyy")
                objDataRow.Item("fechalimite") = Format(CDate(ObjDataSet.Tables(0).Rows(I).Item("fechalimite").ToString), "dd/MM/yyyy")
                'objDataRow.Item("descrip") = ObjDataSet.Tables(0).Rows(I).Item("descrip").ToString
                If Cbo_Sucursal.Text = "CRÉDITO" Then
                    objDataRow.Item("descrip1") = ObjDataSet.Tables(0).Rows(I).Item("descrip1").ToString
                Else
                    objDataRow.Item("descrip1") = ObjDataSet.Tables(0).Rows(I).Item("descrip1").ToString
                End If
                objDataRow.Item("blindaje") = ObjDataSet.Tables(0).Rows(I).Item("blindaje").ToString

                GenerarEstadoCuenta.Tables("Tbl_EstadoCuenta").Rows.Add(objDataRow)


                '-- GENERAR RECIBOS


            Next


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function


    Private Function GenerarRecibo(ObjDataSet As DataSet) As DSPpalRecibo
        'mreyes 13/Abril/2018   11:45 a.m.

        Dim Cont As Integer = 0
        Dim SaldoAnterior As Decimal = 0
        Dim Distrib = ""
        Dim NombreCompleto = ""
        Dim FechaPago As Date = "1900-01-01"
        Dim FechaCorte As Date = "1900-01-01"
        Dim Apagar As Decimal = 0
        Dim NombreCliente As String = ""
        Dim DistribAnt As String = ""

        Try
            GenerarRecibo = New DSPpalRecibo
            For I As Integer = 0 To ObjDataSet.Tables(0).Rows.Count - 1
                Distrib = ObjDataSet.Tables(0).Rows(I).Item("distrib").ToString
                If DistribAnt <> "" And DistribAnt <> Distrib And Cont Mod 2 <> 0 Then
                    '' impar

                    Dim objDataRow1 As Data.DataRow = GenerarRecibo.Tables(0).NewRow()
                    objDataRow1.Item("No. de Cta") = DistribAnt
                    objDataRow1.Item("CORTE") = FechaCorte
                    objDataRow1.Item("fecha") = FechaPago
                    objDataRow1.Item("abono corte") = 0
                    objDataRow1.Item("cliente") = "ZT INVÁLIDO"
                    objDataRow1.Item("distribuidor") = DistribAnt & "-" & "ZT INVÁLIDO"
                    objDataRow1.Item("saldo anterior") = 0
                    objDataRow1.Item("abonos") = 0

                    objDataRow1.Item("saldo nuevo") = 0
                    objDataRow1.Item("numpagos") = ""

                    'objDataRow.Item("No. de Cta") = 
                    GenerarRecibo.Tables(0).Rows.Add(objDataRow1)
                    DistribAnt = Distrib
                    Cont = 0

                End If

                SaldoAnterior = Val(ObjDataSet.Tables(0).Rows(I).Item("saldo").ToString)
                FechaPago = Format(CDate(ObjDataSet.Tables(0).Rows(I).Item("fechavencimiento").ToString), "dd/MM/yyyy")
                Distrib = ObjDataSet.Tables(0).Rows(I).Item("distrib").ToString
                NombreCompleto = Distrib & "-" & ObjDataSet.Tables(0).Rows(I).Item("nombrecompleto").ToString
                FechaCorte = Format(CDate(ObjDataSet.Tables(0).Rows(I).Item("fechacorte").ToString), "dd/MM/yyyy")



                Apagar = Val(ObjDataSet.Tables(0).Rows(I).Item("apagar").ToString)
                NombreCliente = ObjDataSet.Tables(0).Rows(I).Item("nombreclie").ToString



                Dim objDataRow As Data.DataRow = GenerarRecibo.Tables(0).NewRow()
                objDataRow.Item("No. de Cta") = Distrib
                objDataRow.Item("CORTE") = FechaCorte
                objDataRow.Item("fecha") = FechaPago
                objDataRow.Item("abono corte") = Apagar
                objDataRow.Item("cliente") = NombreCliente
                objDataRow.Item("distribuidor") = NombreCompleto
                objDataRow.Item("saldo anterior") = SaldoAnterior
                objDataRow.Item("abonos") = Apagar
                If SaldoAnterior < Apagar Then
                    objDataRow.Item("saldo nuevo") = 0
                Else

                    objDataRow.Item("saldo nuevo") = SaldoAnterior - Apagar
                End If
                objDataRow.Item("numpagos") = ObjDataSet.Tables(0).Rows(I).Item("numpagos").ToString
                'objDataRow.Item("No. de Cta") = 
                GenerarRecibo.Tables(0).Rows.Add(objDataRow)
                DistribAnt = Distrib
                Cont = Cont + 1

            Next


            If Cont Mod 2 <> 0 Then
                Dim objDataRow1 As Data.DataRow = GenerarRecibo.Tables(0).NewRow()
                objDataRow1.Item("No. de Cta") = DistribAnt
                objDataRow1.Item("CORTE") = FechaCorte
                objDataRow1.Item("fecha") = FechaPago
                objDataRow1.Item("abono corte") = 0
                objDataRow1.Item("cliente") = "ZT INVÁLIDO"
                objDataRow1.Item("distribuidor") = DistribAnt & "-" & "ZT INVÁLIDO"
                objDataRow1.Item("saldo anterior") = 0
                objDataRow1.Item("abonos") = 0

                objDataRow1.Item("saldo nuevo") = 0
                objDataRow1.Item("numpagos") = ""

                'objDataRow.Item("No. de Cta") = 
                GenerarRecibo.Tables(0).Rows.Add(objDataRow1)
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function


    Private Function GenerarReciboImagen(ObjDataSet As DataSet) As DSPpalReciboImagen
        'mreyes 14/Abril/2018   11:45 a.m.

        Dim Cont As Integer = 0
        Dim SaldoAnterior As Decimal = 0
        Dim Distrib = ""
        Dim NombreCompleto = ""
        Dim FechaPago As Date = "1900-01-01"
        Dim FechaCorte As Date = "1900-01-01"
        Dim Apagar As Decimal = 0
        Dim NombreCliente As String = ""


        Try
            GenerarReciboImagen = New DSPpalReciboImagen
            For I As Integer = 0 To ObjDataSet.Tables(0).Rows.Count - 1
                SaldoAnterior = Val(ObjDataSet.Tables(0).Rows(I).Item("saldo").ToString)
                FechaPago = Format(CDate(ObjDataSet.Tables(0).Rows(I).Item("fechavencimiento").ToString), "dd/MM/yyyy")
                Distrib = ObjDataSet.Tables(0).Rows(I).Item("distrib").ToString
                NombreCompleto = Distrib & "-" & ObjDataSet.Tables(0).Rows(I).Item("nombrecompleto").ToString
                FechaCorte = Format(CDate(ObjDataSet.Tables(0).Rows(I).Item("fechacorte").ToString), "dd/MM/yyyy")
                Apagar = Val(ObjDataSet.Tables(0).Rows(I).Item("apagar").ToString)
                NombreCliente = ObjDataSet.Tables(0).Rows(I).Item("nombreclie").ToString



                Dim objDataRow As Data.DataRow = GenerarReciboImagen.Tables(0).NewRow()
                objDataRow.Item("No. de Cta") = Distrib
                objDataRow.Item("CORTE") = FechaCorte
                objDataRow.Item("fecha") = FechaPago
                objDataRow.Item("abono corte") = Apagar
                objDataRow.Item("cliente") = NombreCliente
                objDataRow.Item("distribuidor") = NombreCompleto
                objDataRow.Item("saldo anterior") = SaldoAnterior
                objDataRow.Item("abonos") = Apagar
                objDataRow.Item("saldo nuevo") = SaldoAnterior - Apagar

                'objDataRow.Item("No. de Cta") = 
                GenerarReciboImagen.Tables(0).Rows.Add(objDataRow)

            Next


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Function usp_GeneraTipoCredito() As String
        Try
            usp_GeneraTipoCredito = ""
            Dim text As String = String.Empty
            'For Each item As Object In Chk_TipoCredito.CheckedItems
            '    Dim row As DataRowView = TryCast(item, DataRowView)
            '    text &= String.Format("{0},", row(0))
            'Next item
            'text = text.TrimEnd(","c)

            For Each item As DevExpress.XtraEditors.Controls.CheckedListBoxItem In Chk_TipoCredito.CheckedItems
                text = text & item.Value.ToString() & ","

            Next
            If text = "" Then Exit Function

            text = Mid(text, 1, Len(text) - 1)

            text = Replace(text, "NORMAL", 0)
            text = Replace(text, "VENCIDO", 1)
            text = Replace(text, "FRESCO", 2)
            text = Replace(text, "DEMANDA", 3)

            usp_GeneraTipoCredito = text
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles Btn_Refrescar.Click
        Call RellenaGrid()
    End Sub

    Private Sub Btn_RelacionyRecibos_Click(sender As Object, e As EventArgs) Handles Btn_RelacionyRecibos.Click
        Call RellenaGridEstadoCuenta(0)
    End Sub

    Private Sub SimpleButton1_Click_1(sender As Object, e As EventArgs) Handles Btn_Relaciones.Click
        Call RellenaGridEstadoCuenta(1)
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles Btn_Recibos.Click
        Call RellenaGridEstadoCuenta(2)
    End Sub

    Private Sub Txt_Distrib1_EditValueChanged(sender As Object, e As EventArgs) Handles Txt_Distrib1.EditValueChanged

    End Sub

    Private Sub Txt_Distrib1_LostFocus(sender As Object, e As EventArgs) Handles Txt_Distrib1.LostFocus
        Try
            ''rellena ceros
            If (Txt_Distrib1.Text <> "") Then
                If Txt_Distrib1.Text.Trim.Length < 6 Then
                    Txt_Distrib1.Text = pub_RellenarIzquierda(Txt_Distrib1.Text.Trim, 6)
                End If
                'consulta si existe
                'Using objMySqlGral As New BCL.BCLCreditoNuevo(GLB_ConStringCredito)
                '    If Txt_Distrib1.Text.Length = 0 Then Exit Sub
                '    Try
                '        Call TxtLostfocusDistrib(Txt_Distrib, Txt_NomDistrib, "D")
                '    Catch ExceptionErr As Exception
                '        MessageBox.Show(ExceptionErr.Message.ToString)
                '    End Try
                'End Using
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_Distrib2_EditValueChanged(sender As Object, e As EventArgs) Handles Txt_Distrib2.EditValueChanged

    End Sub

    Private Sub Txt_Distrib2_LostFocus(sender As Object, e As EventArgs) Handles Txt_Distrib2.LostFocus
        Try
            ''rellena ceros
            If (Txt_Distrib2.Text <> "") Then
                If Txt_Distrib2.Text.Trim.Length < 6 Then
                    Txt_Distrib2.Text = pub_RellenarIzquierda(Txt_Distrib2.Text.Trim, 6)
                End If
                'consulta si existe
                'Using objMySqlGral As New BCL.BCLCreditoNuevo(GLB_ConStringCredito)
                '    If Txt_Distrib1.Text.Length = 0 Then Exit Sub
                '    Try
                '        Call TxtLostfocusDistrib(Txt_Distrib, Txt_NomDistrib, "D")
                '    Catch ExceptionErr As Exception
                '        MessageBox.Show(ExceptionErr.Message.ToString)
                '    End Try
                'End Using
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Sub SimpleButton1_Click_2(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Try

            MsgBox("A continuación se crearán los ESTADOS DE CUENTA en pdf, este proceso puede tornarse lento.", MsgBoxStyle.Information, "Aviso")
            Sw_Pdf = True
            'RutaGuardarPedidoNuevo
            Call RellenaGridEstadoCuentaPDF(0)
            Sw_Pdf = False

            MsgBox("Proceso de creación de PDF, terminado.", MsgBoxStyle.Information, "Aviso")
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub
    'Private Function GenerarRecibo(Distrib As String, NombreCompleto As String, Corte As Date, FechaPago As Date, Apagar As Decimal,
    '                               NombreCliente As String, SaldoAnterior As Decimal) As DSPpalRecibo
    '    'mreyes 13/Abril/2018   11:25 a.m.

    '    Try

    '        Dim Columna As Integer = 0
    '        Dim Cont As Integer = 0
    '        GenerarRecibo = New DSPpalRecibo


    '        Dim objDataRow As Data.DataRow = GenerarRecibo.Tables(0).NewRow()
    '        objDataRow.Item("No. de Cta") = Distrib
    '        objDataRow.Item("CORTE") = Corte
    '        objDataRow.Item("fecha") = FechaPago
    '        objDataRow.Item("abono corte") = Apagar
    '        objDataRow.Item("cliente") = NombreCliente
    '        objDataRow.Item("distribuidor") = NombreCompleto
    '        objDataRow.Item("saldo anterior") = SaldoAnterior
    '        objDataRow.Item("abonos") = Apagar
    '        objDataRow.Item("saldo nuevo") = SaldoAnterior - Apagar

    '        'objDataRow.Item("No. de Cta") = 
    '        GenerarRecibo.Tables(0).Rows.Add(objDataRow)

    '    Catch ExceptionErr As Exception
    '        MessageBox.Show(ExceptionErr.Message.ToString)
    '    End Try
    'End Function

End Class