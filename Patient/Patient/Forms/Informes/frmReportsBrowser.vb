Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO
Imports System.Drawing.Printing


Public Class frmReportsBrowser
    Declare Function SetDefaultPrinter Lib "winspool.drv" Alias "SetDefaultPrinterA" (ByVal pszPrinter As String) As Boolean

    Dim ConfiguracionesDeImpresion As New PrinterSettings

    Public ReportIndex As Integer
    Public Shared FilterIndex As Byte
    Public Shared FilterName As String
    Public Shared FechaIni As DateTime
    Public Shared FechaFin As DateTime
    Public Shared Nomina_Id As Integer
    Private objPatientDataSet As DataSet

    Private FilterStr As String

    Public SelectPatientId As String
    '' variables pedido nuevo
    ' mreyes 20/Febrero/2012 02:10 p.m.
    Public objDataSetTraspasosRecYEnv As DSTraspasosRecYEnv
    Public objDataSetVentasPorMes As DSVentasPorMes
    Public objDataSetSobranteInv As DSSobranteInv
    Public objDataSetDescuentosPorMes As DSDescuentosPorMes

    Public objDataSetExistenciaActual As DSEstrucExistenActual
    Public objDataSetPedBodega As DSPedBodega
    Public objDataSetFaltanteInv As DSFaltantesInv
    Public objDataSetAlcMetas As DSAlcanceMetas
    ' Public objPendienteRealiza As DSPendienteReliza
    'Public objAntiguedadBulto As DSAntBulo
    Public objDataSetPediNegados As DSPedidosNegados
    Public objDataSetReporteTraspaso As DSPReporteTraspasos
    'Public objDataSetBitProcesos As DSBitacoraProsesos
    Public objDataSetNoSurtir As DSNoSurtir
    'Public objDataSetComision As DSPcomision
    Public objDataSetRemision As DSPRemision
    Public objDataSetLiquidacion As DSPLiqfinal
    Public objDataSetCargos As DSPReporteCargos
    Public objDataSetImprimeRecibo As DSPpalRecibo
    Public objDataSetImprimeReciboImagen As DSPpalReciboImagen
    Public objDataSetPedidoNuevo As DtPedidoNuevo
    Public objDataSetReciboNomina As DSReciboNomina
    Public objDataSetReciboBono As DSReciboBono
    Public objDataSetPpalNomina As DsPpalNomina
    Public objDataSetReporteVentas As DSPReporteVentas2
    Public objDataSetBulto As DTBulto
    Public objDataSetReciboCobradores As DSPReporteCobradores
    Public objDataSetLiquidacionDetalle As DSPLiquidacionDetalle
    Public objDataSetArticulosRecibidos As DSArticulosRecibidos
    Public objDataSetDistribuidor As DSPpalDistribuidor2
    Public objDataSetProspecto As DSPpalprospecto2
    'Public objDataSetRutaCobro As DSPRutaCobro
    Public objDataSetSaldos As DSPpalSaldos3
    Public objDataSetHojaEntrega As DSEntregaCredito

    Public objDatasetreporteGastos As DSPGastos
    ' PUBLICOS PARA REPORTES DE CREDITO
    Public objDataSetPpalListadoPagos As DSPpalListadoPagos
    Public objDataSetPpalPendienteCortes As DSPpalPendienteCortes
    Public objDataSetPpalAuxiliarDistribuidor As DSPpalAuxiliarDistribuidor


    Public objDataSetPpalAparador As DSAparador
    Public objDataSetPpalCorteFolios As DSPpalCorteFolios

    Public objDataSetPpalVencidoDias As DSVencidoDias
    Public objDataSetPpalVencidoDireccion As DSVencidoDias

    Public objDataSetPpalVencidoGestor As usp_PpalVencidoGestor

    Public objDataSetEstadoCuenta As DSEstadoCuenta

    Public objDataVentasEnLinea As DSPVentasEnLinea


    Public objSapica As DSSapica

    'Public objDataSetPedidoNuevo1 As DtPedidoNuevo
    Public TextoColumna(14) As String
    Public Marca As String = ""
    Public Raz_Social As String = ""
    Public Vendedor As String = ""
    Public Transporte As String = ""
    Public Dsctopp As String = ""
    Public Plazopp As String = ""
    Public FechaPedido As String = ""
    Public Observaciones As String = ""
    Public prs As String = ""
    Public Subt As String = ""
    Public TIva As String = ""
    Public Iva As String = ""
    Public TDscto As String = ""
    Public Total As String = ""
    Public OrdeComp As String = ""
    Public FolioEntrada As String = ""
    Public FolioFactura As String = ""
    Public FechaFactura As Date
    Public FechaVence As Date
    Public BaseVence As Date
    Public FechaRecibo As Date
    'Public FechaFactura As Date


    Public Dscto01 As String = ""
    Public Dscto02 As String = ""
    Public Dscto03 As String = ""
    Public Dscto04 As String = ""
    Public Dscto05 As String = ""
    Public RutaGuardarPedidoNuevo As String = ""
    Public Sw_Bitacora As Boolean = False
    Public Sw_Cancelaciones As Boolean = False
    Public FechaNomina As Date
    Public FechaNominaB As String = ""
    Public IdFolioSuc As String = ""
    Public Sw_DevoSerie As Boolean = False
    Public TipoRecibo As String = ""
    Public CanceladoRecibo As String = ""

    Public r_Titulo As String = ""
    Public Observa As String = ""
    'juan 12:37 5-julio-2013 Cheques Privedores Liquidacion
    Public objDataSetChequeProveedores As DSChequeProvedor
    Public objDataSetChequeProveedoresAnexos As DSChequeProvedor


    Public objDataSetCancelaVale As DSCancelaVale

    Public r_Fecha1 As String = ""
    Public r_Fecha2 As String = ""
    Public r_Fecha3 As String = ""
    Public r_Fecha4 As String = ""
    Public r_Fecha5 As String = ""
    Public r_Fecha6 As String = ""
    Public r_Fecha7 As String = ""
    Public r_Entrega As String = ""

    Public r_Descto1 As Decimal = 0
    Public r_Descto2 As Decimal = 0
    Public r_Descto3 As Decimal = 0
    Public r_Descto4 As Decimal = 0
    Public r_Descto5 As Decimal = 0
    Public r_Descto6 As Decimal = 0
    Public r_Descto7 As Decimal = 0

    Public r_Descto11 As Decimal = 0
    Public r_Descto12 As Decimal = 0
    Public r_Descto13 As Decimal = 0
    Public r_Descto14 As Decimal = 0
    Public r_Descto15 As Decimal = 0
    Public r_Descto16 As Decimal = 0
    Public r_Descto17 As Decimal = 0


    Public Sw_Pdf As Boolean = False




    'Sub LoadPatient()
    '    Using objPatient As New BCL.BCLPatient(G_ConString)
    '        Try
    '            objPatientDataSet = New DataSet
    '            'Get the specific project selected in the ListView control
    '            Select Case FilterIndex
    '                Case 0
    '                    objPatientDataSet = objPatient.GetPatients("N")
    '                    FilterStr = "Todos"
    '                Case 1
    '                    objPatientDataSet = objPatient.GetPatientById(FilterName, "N")
    '                    FilterStr = "Filtrado por Id " & FilterName
    '                Case 2
    '                    objPatientDataSet = objPatient.GetPatientByName(FilterName, "N")
    '                    FilterStr = "Filtrado por Nombre " & FilterName
    '                Case 3
    '                    objPatientDataSet = objPatient.GetPatientByNRC(FilterName, "N")
    '                    FilterStr = "Filtrado por Puesto " & FilterName
    '                Case 4
    '                    objPatientDataSet = objPatient.GetPatientBySectionName(FilterName, "N")
    '                    FilterStr = "Filtrado por Depto " & FilterName
    '            End Select

    '            'Populate the Project Details section
    '        Catch ExceptionErr As Exception
    '            MessageBox.Show(ExceptionErr.Message.ToString)
    '        End Try
    '    End Using
    'End Sub

    Private Sub PredeterminarImpresora(Nombre As String)

        SetDefaultPrinter(Nombre)

    End Sub

    Private Sub frmReportsBrowser_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Dim ImprimeDataSet As DataSet

        ''Dim Rpt As New rptReportePedidoNuevo

        ''Rpt.SetDataSource(objDataSetPedidoNuevo.Tables(0))
        ''crReports.ReportSource = Rpt






        Select Case ReportIndex
            '--objDataSetPpalVencidoGestor

            Case 6005
                Dim RPt As New rptSapica


                RPt.SetDataSource(objSapica)
                RPt.DataDefinition.FormulaFields("r_Mensaje").Text = "'" & Glb_Mensaje & "'"
                crReports.ReportSource = RPt






            Case 6004
                Dim RPt As New rptVentaEnLinea




                RPt.SetDataSource(objDataSetPpalVencidoGestor)
                crReports.ReportSource = RPt
                RPt.PrintToPrinter(1, False, 0, 0)
            Case 6003
                'releación , se agrega pdf 
                'mreyes 03/Marzo/2020   04:12 p.m.
                Dim RPt As New rptEstadoCuenta
                Dim rptStream As New System.IO.MemoryStream

                If InStr(GLB_ImpresoraPredeterminada, "movs") = 0 Then
                    Call PredeterminarImpresora(GLB_ImpresoraRELACION)
                    If InStr(GLB_ImpresoraPredeterminada, "movs") = 0 Then
                        Call PredeterminarImpresora(GLB_ImpresoraRELACION)
                    End If
                End If

                    RPt.SetDataSource(objDataSetEstadoCuenta)
                RPt.DataDefinition.FormulaFields("r_Mensaje").Text = "'" & Glb_Mensaje & "'"
                RPt.DataDefinition.FormulaFields("r_Mensaje1").Text = "'" & Glb_Mensaje1 & "'"
                RPt.DataDefinition.FormulaFields("r_Mensaje2").Text = "'" & Glb_Mensaje2 & "'"
                RPt.DataDefinition.FormulaFields("r_Mensaje3").Text = "'" & Glb_Mensaje3 & "'"
                RPt.DataDefinition.FormulaFields("r_Mensaje4").Text = "'" & Glb_Mensaje4 & "'"


                'RPt.DataDefinition.FormulaFields("r_Descto1").Text = "'" & r_Descto1 & "'"
                'RPt.DataDefinition.FormulaFields("r_Descto2").Text = "'" & r_Descto2 & "'"
                'RPt.DataDefinition.FormulaFields("r_Descto3").Text = "'" & r_Descto3 & "'"
                'RPt.DataDefinition.FormulaFields("r_Descto4").Text = "'" & r_Descto4 & "'"
                'RPt.DataDefinition.FormulaFields("r_Descto5").Text = "'" & r_Descto5 & "'"
                'RPt.DataDefinition.FormulaFields("r_Descto6").Text = "'" & r_Descto6 & "'"
                'RPt.DataDefinition.FormulaFields("r_Descto7").Text = "'" & r_Descto7 & "'"


                RPt.DataDefinition.FormulaFields("r_Fecha1").Text = "'" & r_Fecha1 & "'"
                RPt.DataDefinition.FormulaFields("r_Fecha2").Text = "'" & r_Fecha2 & "'"
                RPt.DataDefinition.FormulaFields("r_Fecha3").Text = "'" & r_Fecha3 & "'"
                RPt.DataDefinition.FormulaFields("r_Fecha4").Text = "'" & r_Fecha4 & "'"
                RPt.DataDefinition.FormulaFields("r_Fecha5").Text = "'" & r_Fecha5 & "'"
                RPt.DataDefinition.FormulaFields("r_Fecha6").Text = "'" & r_Fecha6 & "'"
                RPt.DataDefinition.FormulaFields("r_Fecha7").Text = "'" & r_Fecha7 & "'"

                RPt.DataDefinition.FormulaFields("r_Asterisco").Text = "'*'"

                If Sw_Pdf = False Then

                    crReports.ReportSource = RPt
                    If InStr(GLB_ImpresoraPredeterminada, "movs") = 0 Then
                        Call PredeterminarImpresora(GLB_ImpresoraPredeterminada)
                        If InStr(GLB_ImpresoraPredeterminada, "movs") = 0 Then
                            Call PredeterminarImpresora(GLB_ImpresoraRELACION)
                        End If
                    End If

                Else

                    Dim CrExportOptions As CrystalDecisions.Shared.ExportOptions
                    Dim CrDiskFileDestinationOptions As New CrystalDecisions.Shared.DiskFileDestinationOptions
                    Dim CrFormatTypeOptions As New CrystalDecisions.Shared.PdfRtfWordFormatOptions



                    CrDiskFileDestinationOptions.DiskFileName = RutaGuardarPedidoNuevo
                    CrExportOptions = RPt.ExportOptions
                    With CrExportOptions
                        .ExportDestinationType = CrystalDecisions.Shared.ExportDestinationType.DiskFile
                        .ExportFormatType = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat
                        .DestinationOptions = CrDiskFileDestinationOptions
                        .FormatOptions = CrFormatTypeOptions

                    End With
                    RPt.Export()

                    crReports.ReportSource = RPt
                    '' TERMINA GENERAR EL ARCHIVO AHORA A ABRIRLO
                    'Shell(RutaGuardarPedidoNuevo)

                    'Process.Start("AcroRd32.exe", RutaGuardarPedidoNuevo)


                    Me.Close()
                    Me.Dispose()

                End If





            Case 6002
                Dim RPt As New rptPpalVencidoGestor
                RPt.SetDataSource(objDataSetPpalVencidoGestor)
                '--   RPt.DataDefinition.FormulaFields("r_titulo").Text = "'" & r_Titulo & "'"
                crReports.ReportSource = RPt


            Case 6000
                Dim RPt As New rptPpalVencidoDias
                RPt.SetDataSource(objDataSetPpalVencidoDias)
                RPt.DataDefinition.FormulaFields("r_titulo").Text = "'" & r_Titulo & "'"
                crReports.ReportSource = RPt

            Case 6001
                Dim RPt As New rptPpalVencidoDireccion
                RPt.SetDataSource(objDataSetPpalVencidoDias)
                RPt.DataDefinition.FormulaFields("r_titulo").Text = "'" & r_Titulo & "'"
                crReports.ReportSource = RPt




            Case 5529
                Dim RPt As New rptTraspasosRecyEnv
                RPt.SetDataSource(objDataSetTraspasosRecYEnv)
                RPt.DataDefinition.FormulaFields("r_titulo").Text = "'" & r_Titulo & "'"
                crReports.ReportSource = RPt


            Case 5527
                Dim RPt As New rptDescuentosPorMes
                RPt.SetDataSource(objDataSetDescuentosPorMes)
                crReports.ReportSource = RPt

            Case 5526
                Dim RPt As New rptDescuentosXMesPrincipal
                RPt.SetDataSource(objDataSetDescuentosPorMes)
                crReports.ReportSource = RPt



            Case 5525
                Dim RPt As New rptVentasPorMes
                RPt.SetDataSource(objDataSetVentasPorMes)
                crReports.ReportSource = RPt
            Case 5524
                Dim RPt As New rptSovranteInv
                RPt.SetDataSource(objDataSetSobranteInv)
                crReports.ReportSource = RPt

            Case 5523
                Dim RPt As New rptEstrucExistenActual
                RPt.SetDataSource(objDataSetExistenciaActual)
                crReports.ReportSource = RPt

            Case 5520
                Dim RPt As New rptFaltanteInv
                ' RPt.PrintOptions.PrinterName = GLB_ImpresoraMovs
                If InStr(GLB_ImpresoraPredeterminada, "movs") = 0 Then
                    Call PredeterminarImpresora(GLB_ImpresoraMovs)
                End If
                RPt.SetDataSource(objDataSetFaltanteInv)
                crReports.ReportSource = RPt
                If InStr(GLB_ImpresoraPredeterminada, "movs") = 0 Then
                    Call PredeterminarImpresora(GLB_ImpresoraPredeterminada)
                End If

            Case 5519
                Dim RPt As New rptPedBodega
                ' RPt.PrintOptions.PrinterName = GLB_ImpresoraMovs
                RPt.SetDataSource(objDataSetPedBodega)
                crReports.ReportSource = RPt

            Case 5518
                Dim RPt As New rptPedidosNegados
                ' RPt.PrintOptions.PrinterName = GLB_ImpresoraMovs
                RPt.SetDataSource(objDataSetPediNegados)
                crReports.ReportSource = RPt

            Case 702

                Dim RPt As New rptAlcanceMetas

                If InStr(GLB_ImpresoraPredeterminada, "movs") = 0 Then
                    Call PredeterminarImpresora(GLB_ImpresoraMovs)
                End If
                RPt.SetDataSource(objDataSetAlcMetas)
                crReports.ReportSource = RPt
                If InStr(GLB_ImpresoraPredeterminada, "movs") = 0 Then
                    Call PredeterminarImpresora(GLB_ImpresoraPredeterminada)
                End If

            Case 5518
                '    Dim RPt As New rptPendRealizaOp2
                '    RPt.PrintOptions.PrinterName = GLB_ImpresoraMovs
                '    RPt.SetDataSource(objPendienteRealiza)
                '    crReports.ReportSource = RPt

                'Case 700
                '    Dim RPt As New rptPendRealizaOp1
                '    RPt.PrintOptions.PrinterName = GLB_ImpresoraMovs
                '    RPt.SetDataSource(objPendienteRealiza)
                '    crReports.ReportSource = RPt



                'Case 699
                '    Dim RPt As New rptBitPros
                '    RPt.PrintOptions.PrinterName = GLB_ImpresoraMovs
                '    RPt.SetDataSource(objDataSetBitProcesos)
                '    crReports.ReportSource = RPt

                'Case 698
                '    Dim RPt As New rptABultos
                '    RPt.PrintOptions.PrinterName = GLB_ImpresoraMovs
                '    RPt.SetDataSource(objAntiguedadBulto)
                '    crReports.ReportSource = RPt

            Case 10000

                Dim Rpt As New rptNoSurtir
                'Rpt.PrintOptions.PrinterName = GLB_ImpresoraMovs
                If InStr(GLB_ImpresoraPredeterminada, "movs") = 0 Then
                    Call PredeterminarImpresora(GLB_ImpresoraMovs)
                End If
                Rpt.SetDataSource(objDataSetNoSurtir)
                crReports.ReportSource = Rpt
                If InStr(GLB_ImpresoraPredeterminada, "movs") = 0 Then
                    Call PredeterminarImpresora(GLB_ImpresoraPredeterminada)
                End If

            Case 8460

                Dim Rpt As New rptPpalLiqAutomaticaTdas

                ' Rpt.PrintOptions.PrinterName = GLB_ImpresoraMovs
                If InStr(GLB_ImpresoraPredeterminada, "movs") = 0 Then
                    Call PredeterminarImpresora(GLB_ImpresoraMovs)
                End If
                Rpt.SetDataSource(objDataSetPpalAparador)
                Rpt.DataDefinition.FormulaFields("rpt_leyenda").Text = "'" & r_Titulo & "'"

                crReports.ReportSource = Rpt
                If InStr(GLB_ImpresoraPredeterminada, "movs") = 0 Then
                    Call PredeterminarImpresora(GLB_ImpresoraPredeterminada)
                End If


            Case 8459

                Dim Rpt As New rptPpalEtiquetasAparador
                'Rpt.PrintOptions.PrinterName = GLB_ImpresoraMovs
                If InStr(GLB_ImpresoraPredeterminada, "movs") = 0 Then
                    Call PredeterminarImpresora(GLB_ImpresoraMovs)
                End If
                Rpt.SetDataSource(objDataSetPpalAparador)
                Rpt.DataDefinition.FormulaFields("rpt_leyenda").Text = "'" & r_Titulo & "'"

                crReports.ReportSource = Rpt
                If InStr(GLB_ImpresoraPredeterminada, "movs") = 0 Then
                    Call PredeterminarImpresora(GLB_ImpresoraPredeterminada)
                End If
                'Rpt.PrintToPrinter(1, False, 0, 0)
            Case 8458
                'ejemplo de impresión en tiendas 
                Dim Rpt As New rptPpalTraerReciboAparador

                If InStr(GLB_ImpresoraPredeterminada, "movs") = 0 Then
                    Call PredeterminarImpresora(GLB_ImpresoraMovs)
                End If
                ' Rpt.PrintOptions.PrinterName = GLB_ImpresoraMovs
                Rpt.SetDataSource(objDataSetPpalAparador)
                Rpt.DataDefinition.FormulaFields("rpt_leyenda").Text = "'" & r_Titulo & "'"

                crReports.ReportSource = Rpt
                If InStr(GLB_ImpresoraPredeterminada, "movs") = 0 Then
                    Call PredeterminarImpresora(GLB_ImpresoraPredeterminada)
                End If
                ' Rpt.PrintToPrinter(1, False, 0, 0)

            Case 8457
                '' prueba 
                Dim Rpt As New rptReportePedidoNuevoProvREMISION

                Dim rptStream As New System.IO.MemoryStream
                Dim Cadena As String


                Rpt.DataDefinition.FormulaFields("FM1").Text = "'" & TextoColumna(0) & "'"
                Rpt.DataDefinition.FormulaFields("FM2").Text = "'" & TextoColumna(1) & "'"
                Rpt.DataDefinition.FormulaFields("FM3").Text = "'" & TextoColumna(2) & "'"
                Rpt.DataDefinition.FormulaFields("FM4").Text = "'" & TextoColumna(3) & "'"
                Rpt.DataDefinition.FormulaFields("FM5").Text = "'" & TextoColumna(4) & "'"
                Rpt.DataDefinition.FormulaFields("FM6").Text = "'" & TextoColumna(5) & "'"
                Rpt.DataDefinition.FormulaFields("FM7").Text = "'" & TextoColumna(6) & "'"
                Rpt.DataDefinition.FormulaFields("FM8").Text = "'" & TextoColumna(7) & "'"
                Rpt.DataDefinition.FormulaFields("FM9").Text = "'" & TextoColumna(8) & "'"
                Rpt.DataDefinition.FormulaFields("FM10").Text = "'" & TextoColumna(9) & "'"
                Rpt.DataDefinition.FormulaFields("FM11").Text = "'" & TextoColumna(10) & "'"
                Rpt.DataDefinition.FormulaFields("FM12").Text = "'" & TextoColumna(11) & "'"
                Rpt.DataDefinition.FormulaFields("FM13").Text = "'" & TextoColumna(12) & "'"
                Rpt.DataDefinition.FormulaFields("FM14").Text = "'" & TextoColumna(13) & "'"
                Rpt.DataDefinition.FormulaFields("FMarca").Text = "'" & Marca & "'"
                Rpt.DataDefinition.FormulaFields("FRaz_Social").Text = "'" & Raz_Social & "'"
                Rpt.DataDefinition.FormulaFields("FVendedor").Text = "'" & Vendedor & "'"
                Rpt.DataDefinition.FormulaFields("Ftransporte").Text = "'" & Transporte & "'"
                Rpt.DataDefinition.FormulaFields("FDsctopp").Text = "'" & Dsctopp & "'"
                Rpt.DataDefinition.FormulaFields("Fdiaspp").Text = "'" & Plazopp & "'"
                Rpt.DataDefinition.FormulaFields("FFecha").Text = "'" & FechaPedido & "'"
                Rpt.DataDefinition.FormulaFields("Fobserva").Text = "'" & Observaciones & "'"
                '' calcular por orden de compra 
                Rpt.DataDefinition.FormulaFields("Fprs").Text = "'" & prs & "'"
                Rpt.DataDefinition.FormulaFields("FSubt").Text = "'" & Subt & "'"
                Rpt.DataDefinition.FormulaFields("Ftiva").Text = "'" & TIva & "'"
                Rpt.DataDefinition.FormulaFields("Fiva").Text = "'" & Iva & "'"
                Rpt.DataDefinition.FormulaFields("FTDesc").Text = "'" & TDscto & "'"
                Rpt.DataDefinition.FormulaFields("FTotal").Text = "'" & Total & "'"
                '' calcular por orden de compra 
                Rpt.DataDefinition.FormulaFields("FDscto01").Text = "'" & Dscto01 & "'"
                Rpt.DataDefinition.FormulaFields("FDscto02").Text = "'" & Dscto02 & "'"
                Rpt.DataDefinition.FormulaFields("FDscto03").Text = "'" & Dscto03 & "'"
                Rpt.DataDefinition.FormulaFields("FDscto04").Text = "'" & Dscto04 & "'"
                Rpt.DataDefinition.FormulaFields("FDscto05").Text = "'" & Dscto05 & "'"
                Cadena = ""
                If Dscto01.Length > 0 And Dscto01 <> "0" Then
                    Cadena = Dscto01
                End If
                If Dscto02.Length > 0 And Dscto02 <> "0" Then
                    Cadena = Cadena & " + " & Dscto02
                End If
                If Dscto03.Length > 0 And Dscto03 <> "0" Then
                    Cadena = Cadena & " + " & Dscto03
                End If
                If Dscto04.Length > 0 And Dscto04 <> "0" Then
                    Cadena = Cadena & " + " & Dscto04
                End If
                If Dscto05.Length > 0 And Dscto05 <> "0" Then
                    Cadena = Cadena & " + " & Dscto05
                End If

                Rpt.DataDefinition.FormulaFields("FDescuentos").Text = "'" & Cadena & "'"
                Rpt.DataDefinition.FormulaFields("FRealizo").Text = "'" & GLB_NomUsuario & "'"
                Rpt.DataDefinition.FormulaFields("FOrdecomp").Text = "'" & OrdeComp & "'"

                'prueba mreyes 10/Diciembre/2014
                If IdFolioSuc <> "" Then
                    Rpt.DataDefinition.FormulaFields("IdFolioSuc").Text = "'" & IdFolioSuc & "'"
                End If

                'Rpt.SetDataSource(objDataSetPedidoNuevo.Tables(0))

                Dim objDataSet As Data.DataSet
                Using objMySqlGral As New BCL.BCLPersis(GLB_ConStringPerSis)
                    Try


                        If Mid(OrdeComp, 1, 2) = "08" Or Observa = "RESURTIDO AUTOMÁTICO NOCTURNO" Then
                            'mientras

                            Rpt.DataDefinition.FormulaFields("FDir1").Text = "'SUCURSAL: MATRIZ'"
                            Rpt.DataDefinition.FormulaFields("FDir2").Text = "'JUAN ANTONIO DE LA FUENTE 345 SUR'"
                            Rpt.DataDefinition.FormulaFields("FDir3").Text = "'COL. CENTRO, C.P. 27000'"
                            Rpt.DataDefinition.FormulaFields("FDir4").Text = "'TORREÓN, COAH.'"
                            Rpt.DataDefinition.FormulaFields("FDir5").Text = "'" & "" & "'"
                            Rpt.DataDefinition.FormulaFields("FDir6").Text = "'" & "" & "'"
                        Else
                            objDataSet = objMySqlGral.usp_TraerDatosSucursal(Mid(OrdeComp, 1, 2))

                            If objDataSet.Tables(0).Rows.Count > 0 Then

                                If Mid(OrdeComp, 1, 2) <= "08" Then
                                    Rpt.DataDefinition.FormulaFields("FDir1").Text = "'" & objDataSet.Tables(0).Rows(0).Item("sucursal").ToString & "'"
                                Else
                                    Rpt.DataDefinition.FormulaFields("FDir1").Text = "'" & Mid(OrdeComp, 1, 2) & "'"

                                End If


                                Rpt.DataDefinition.FormulaFields("FDir2").Text = "'" & objDataSet.Tables(0).Rows(0).Item("calle").ToString & "'"
                                Rpt.DataDefinition.FormulaFields("FDir3").Text = "'Col. " & objDataSet.Tables(0).Rows(0).Item("colonia").ToString & "'"
                                Rpt.DataDefinition.FormulaFields("FDir4").Text = "'" & objDataSet.Tables(0).Rows(0).Item("ciudad").ToString & ", " & objDataSet.Tables(0).Rows(0).Item("estado").ToString & ", " & objDataSet.Tables(0).Rows(0).Item("codpos").ToString & "'"
                                Rpt.DataDefinition.FormulaFields("FDir5").Text = "'" & "" & "'"
                                Rpt.DataDefinition.FormulaFields("FDir6").Text = "'" & "" & "'"

                                'mientras
                                'Rpt.DataDefinition.FormulaFields("FDir1").Text = "'SUCURSAL: " & objDataSet.Tables(0).Rows(0).Item("sucursal").ToString & "'"
                                'Rpt.DataDefinition.FormulaFields("FDir2").Text = "'JUAN ANTONIO DE LA FUENTE 345 SUR'"
                                'Rpt.DataDefinition.FormulaFields("FDir3").Text = "'COL. CENTRO, C.P. 27000'"
                                'Rpt.DataDefinition.FormulaFields("FDir4").Text = "'TORREÓN, COAH.'"
                                'Rpt.DataDefinition.FormulaFields("FDir5").Text = "'" & "" & "'"
                                'Rpt.DataDefinition.FormulaFields("FDir6").Text = "'" & "" & "'"

                            End If
                        End If

                    Catch ExceptionErr As Exception
                        MessageBox.Show(ExceptionErr.Message.ToString)
                    End Try
                End Using
                Rpt.SetDataSource(objDataSetPedidoNuevo)




                Dim CrExportOptions As CrystalDecisions.Shared.ExportOptions
                Dim CrDiskFileDestinationOptions As New CrystalDecisions.Shared.DiskFileDestinationOptions
                Dim CrFormatTypeOptions As New CrystalDecisions.Shared.PdfRtfWordFormatOptions


                CrDiskFileDestinationOptions.DiskFileName = RutaGuardarPedidoNuevo
                CrExportOptions = Rpt.ExportOptions
                With CrExportOptions
                    .ExportDestinationType = CrystalDecisions.Shared.ExportDestinationType.DiskFile
                    .ExportFormatType = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat
                    .DestinationOptions = CrDiskFileDestinationOptions
                    .FormatOptions = CrFormatTypeOptions

                End With
                Rpt.Export()
                crReports.ReportSource = Rpt
                '' TERMINA GENERAR EL ARCHIVO AHORA A ABRIRLO
                'Shell(RutaGuardarPedidoNuevo)
                If Sw_Bitacora = False Then
                    Process.Start("AcroRd32.exe", RutaGuardarPedidoNuevo)
                End If

                ''Dim startInfo As New ProcessStartInfo("AcroRd32.exe")
                ''startInfo.WindowStyle = ProcessWindowStyle.Maximized

                ''Process.Start(startInfo)
                ''startInfo.FileName = RutaGuardarPedidoNuevo
                ''Process.Start(startInfo)


                Me.Close()
                Me.Dispose()
            Case 8456
                ' FICHA REMISION
                Dim Rpt As New rptPpalCorteFolios
                Rpt.DataDefinition.FormulaFields("Leyenda").Text = "'" & r_Titulo & "'"
                Rpt.SetDataSource(objDataSetPpalCorteFolios)
                crReports.ReportSource = Rpt


            Case 8455
                ' FICHA REMISION
                Dim Rpt As New rptReporteComision
                ' Rpt.SetDataSource(objDataSetComision)

                crReports.ReportSource = Rpt
            Case 8454

                Dim Rpt As New rptPpalAparador
                If InStr(GLB_ImpresoraPredeterminada, "movs") = 0 Then
                    Call PredeterminarImpresora(GLB_ImpresoraMovs)
                End If
                Rpt.SetDataSource(objDataSetPpalAparador)
                crReports.ReportSource = Rpt
                If InStr(GLB_ImpresoraPredeterminada, "movs") = 0 Then
                    Call PredeterminarImpresora(GLB_ImpresoraPredeterminada)
                End If
            Case 8450
                ' REPORTE DE Cobradores
                Dim Rpt As New rptPpalListadoPagos
                Rpt.DataDefinition.FormulaFields("r_Titulo").Text = "'" & r_Titulo & "'"
                'Rpt.DataDefinition.FormulaFields("FDescuentos").Text = "'" & Cadena & "'"
                Rpt.SetDataSource(objDataSetPpalListadoPagos)
                crReports.ReportSource = Rpt

            Case 8451
                ' REPORTE DE Cobradores
                Dim Rpt As New rptPpalPendienteCortes
                Rpt.DataDefinition.FormulaFields("r_Titulo").Text = "'" & r_Titulo & "'"
                'Rpt.DataDefinition.FormulaFields("FDescuentos").Text = "'" & Cadena & "'"
                Rpt.SetDataSource(objDataSetPpalPendienteCortes)
                crReports.ReportSource = Rpt

            Case 8452
                ' REPORTE DE Cobradores
                Dim Rpt As New rptPpalAuxiliarDistribuidor
                Rpt.DataDefinition.FormulaFields("r_Titulo").Text = "'" & r_Titulo & "'"
                'Rpt.DataDefinition.FormulaFields("FDescuentos").Text = "'" & Cadena & "'"
                Rpt.SetDataSource(objDataSetPpalAuxiliarDistribuidor)
                crReports.ReportSource = Rpt



            Case 8453
                ' REPORTE DE Cobradores
                Dim Rpt As New rptValesCancelados
                'Rpt.DataDefinition.FormulaFields("r_Titulo").Text = "'" & r_Titulo & "'"
                'Rpt.DataDefinition.FormulaFields("FDescuentos").Text = "'" & Cadena & "'"
                Rpt.SetDataSource(objDataSetCancelaVale)
                crReports.ReportSource = Rpt



            Case 111111
                ' REPORTE DE Cobradores
                Dim Rpt As New rptEntrega
                Rpt.SetDataSource(objDataSetHojaEntrega)
                crReports.ReportSource = Rpt
            Case 160589
                ' REPORTE DE Cobradores
                Dim Rpt As New rptArticulosRecibidos
                Rpt.SetDataSource(objDataSetArticulosRecibidos)
                crReports.ReportSource = Rpt
            Case 29
                ' REPORTE DE GASTOS
                Dim Rpt As New rptReporteGastos

                If InStr(GLB_ImpresoraPredeterminada, "movs") = 0 Then
                    Call PredeterminarImpresora(GLB_ImpresoraMovs)
                End If

                'Rpt.PrintOptions.PrinterName = GLB_ImpresoraMovs

                Rpt.SetDataSource(objDatasetreporteGastos)

                crReports.ReportSource = Rpt
                'Rpt.PrintToPrinter(1, False, 0, 0)
                If InStr(GLB_ImpresoraPredeterminada, "movs") = 0 Then
                    Call PredeterminarImpresora(GLB_ImpresoraPredeterminada)
                End If


            Case 11
                ' FICHA REMISION
                Dim Rpt As New rptReporteRemision
                Rpt.SetDataSource(objDataSetRemision)
                crReports.ReportSource = Rpt
            Case 12
                ' REPORTE DE LIQUIDACION
                ' Dim Rpt As New rptReporteLiquidacion
                Dim Rpt As New rptLiqFinal

                Rpt.DataDefinition.FormulaFields("rLetrero").Text = "'" & Observaciones & "'"
                Rpt.DataDefinition.FormulaFields("rTipo").Text = "'" & TipoRecibo & "'"
                Rpt.SetDataSource(objDataSetLiquidacion)
                crReports.ReportSource = Rpt
            Case 14
                ' REPORTE DE CARGOS
                Dim Rpt As New rptReporteCargos
                Rpt.SetDataSource(objDataSetCargos)
                crReports.ReportSource = Rpt

            Case 0  '''' PEDIDO NUEVO, CUANDO SE ESTA GENERANDO LA PRIMERA VEZ 
                Dim Rpt As New rptReportePedidoNuevoComp
                Dim rptStream As New System.IO.MemoryStream
                Dim Cadena As String


                Rpt.DataDefinition.FormulaFields("FM1").Text = "'" & TextoColumna(0) & "'"
                Rpt.DataDefinition.FormulaFields("FM2").Text = "'" & TextoColumna(1) & "'"
                Rpt.DataDefinition.FormulaFields("FM3").Text = "'" & TextoColumna(2) & "'"
                Rpt.DataDefinition.FormulaFields("FM4").Text = "'" & TextoColumna(3) & "'"
                Rpt.DataDefinition.FormulaFields("FM5").Text = "'" & TextoColumna(4) & "'"
                Rpt.DataDefinition.FormulaFields("FM6").Text = "'" & TextoColumna(5) & "'"
                Rpt.DataDefinition.FormulaFields("FM7").Text = "'" & TextoColumna(6) & "'"
                Rpt.DataDefinition.FormulaFields("FM8").Text = "'" & TextoColumna(7) & "'"
                Rpt.DataDefinition.FormulaFields("FM9").Text = "'" & TextoColumna(8) & "'"
                Rpt.DataDefinition.FormulaFields("FM10").Text = "'" & TextoColumna(9) & "'"
                Rpt.DataDefinition.FormulaFields("FM11").Text = "'" & TextoColumna(10) & "'"
                Rpt.DataDefinition.FormulaFields("FM12").Text = "'" & TextoColumna(11) & "'"
                Rpt.DataDefinition.FormulaFields("FM13").Text = "'" & TextoColumna(12) & "'"
                Rpt.DataDefinition.FormulaFields("FM14").Text = "'" & TextoColumna(13) & "'"
                Rpt.DataDefinition.FormulaFields("FMarca").Text = "'" & Marca & "'"
                Rpt.DataDefinition.FormulaFields("FRaz_Social").Text = "'" & Raz_Social & "'"
                Rpt.DataDefinition.FormulaFields("FVendedor").Text = "'" & Vendedor & "'"
                Rpt.DataDefinition.FormulaFields("Ftransporte").Text = "'" & Transporte & "'"
                Rpt.DataDefinition.FormulaFields("FDsctopp").Text = "'" & Dsctopp & "'"
                Rpt.DataDefinition.FormulaFields("Fdiaspp").Text = "'" & Plazopp & "'"
                Rpt.DataDefinition.FormulaFields("FFecha").Text = "'" & FechaPedido & "'"
                Rpt.DataDefinition.FormulaFields("Fobserva").Text = "'" & Observaciones & "'"
                '' calcular por orden de compra 
                Rpt.DataDefinition.FormulaFields("Fprs").Text = "'" & prs & "'"
                Rpt.DataDefinition.FormulaFields("FSubt").Text = "'" & Subt & "'"
                Rpt.DataDefinition.FormulaFields("Ftiva").Text = "'" & TIva & "'"
                Rpt.DataDefinition.FormulaFields("Fiva").Text = "'" & Iva & "'"
                Rpt.DataDefinition.FormulaFields("FTDesc").Text = "'" & TDscto & "'"
                Rpt.DataDefinition.FormulaFields("FTotal").Text = "'" & Total & "'"
                '' calcular por orden de compra 
                Rpt.DataDefinition.FormulaFields("FDscto01").Text = "'" & Dscto01 & "'"
                Rpt.DataDefinition.FormulaFields("FDscto02").Text = "'" & Dscto02 & "'"
                Rpt.DataDefinition.FormulaFields("FDscto03").Text = "'" & Dscto03 & "'"
                Rpt.DataDefinition.FormulaFields("FDscto04").Text = "'" & Dscto04 & "'"
                Rpt.DataDefinition.FormulaFields("FDscto05").Text = "'" & Dscto05 & "'"
                Cadena = ""
                If Dscto01.Length > 0 And Dscto01 <> "0" Then
                    Cadena = Dscto01
                End If
                If Dscto02.Length > 0 And Dscto02 <> "0" Then
                    Cadena = Cadena & " + " & Dscto02
                End If
                If Dscto03.Length > 0 And Dscto03 <> "0" Then
                    Cadena = Cadena & " + " & Dscto03
                End If
                If Dscto04.Length > 0 And Dscto04 <> "0" Then
                    Cadena = Cadena & " + " & Dscto04
                End If
                If Dscto05.Length > 0 And Dscto05 <> "0" Then
                    Cadena = Cadena & " + " & Dscto05
                End If

                Rpt.DataDefinition.FormulaFields("FDescuentos").Text = "'" & Cadena & "'"
                Rpt.DataDefinition.FormulaFields("FRealizo").Text = "'" & GLB_NomUsuario & "'"
                Rpt.DataDefinition.FormulaFields("FOrdecomp").Text = "'" & OrdeComp & "'"

                Dim objDataSet As Data.DataSet
                Using objMySqlGral As New BCL.BCLPersis(GLB_ConStringPerSis)
                    Try
                        If Mid(OrdeComp, 1, 2) = "08" Or Observa = "RESURTIDO AUTOMÁTICO NOCTURNO" Then
                            'mientras

                            Rpt.DataDefinition.FormulaFields("FDir1").Text = "'SUCURSAL: MATRIZ'"
                            Rpt.DataDefinition.FormulaFields("FDir2").Text = "'JUAN ANTONIO DE LA FUENTE 345 SUR'"
                            Rpt.DataDefinition.FormulaFields("FDir3").Text = "'COL. CENTRO, C.P. 27000'"
                            Rpt.DataDefinition.FormulaFields("FDir4").Text = "'TORREÓN, COAH.'"
                            Rpt.DataDefinition.FormulaFields("FDir5").Text = "'" & "" & "'"
                            Rpt.DataDefinition.FormulaFields("FDir6").Text = "'" & "" & "'"
                        Else

                            objDataSet = objMySqlGral.usp_TraerDatosSucursal(Mid(OrdeComp, 1, 2))

                            If objDataSet.Tables(0).Rows.Count > 0 Then
                                Rpt.DataDefinition.FormulaFields("FDir1").Text = "'" & objDataSet.Tables(0).Rows(0).Item("sucursal").ToString & "'"
                                Rpt.DataDefinition.FormulaFields("FDir2").Text = "'" & objDataSet.Tables(0).Rows(0).Item("calle").ToString & "'"
                                Rpt.DataDefinition.FormulaFields("FDir3").Text = "'Col. " & objDataSet.Tables(0).Rows(0).Item("colonia").ToString & "'"
                                Rpt.DataDefinition.FormulaFields("FDir4").Text = "'" & objDataSet.Tables(0).Rows(0).Item("ciudad").ToString & ", " & objDataSet.Tables(0).Rows(0).Item("estado").ToString & ", " & objDataSet.Tables(0).Rows(0).Item("codpos").ToString & "'"
                                Rpt.DataDefinition.FormulaFields("FDir5").Text = "'" & "" & "'"
                                Rpt.DataDefinition.FormulaFields("FDir6").Text = "'" & "" & "'"




                            End If
                        End If

                    Catch ExceptionErr As Exception
                        MessageBox.Show(ExceptionErr.Message.ToString)
                    End Try
                End Using

                Rpt.SetDataSource(objDataSetPedidoNuevo)




                Dim CrExportOptions As CrystalDecisions.Shared.ExportOptions
                Dim CrDiskFileDestinationOptions As New CrystalDecisions.Shared.DiskFileDestinationOptions
                Dim CrFormatTypeOptions As New CrystalDecisions.Shared.PdfRtfWordFormatOptions


                CrDiskFileDestinationOptions.DiskFileName = RutaGuardarPedidoNuevo
                CrExportOptions = Rpt.ExportOptions
                With CrExportOptions
                    .ExportDestinationType = CrystalDecisions.Shared.ExportDestinationType.DiskFile
                    .ExportFormatType = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat
                    .DestinationOptions = CrDiskFileDestinationOptions
                    .FormatOptions = CrFormatTypeOptions

                End With
                Rpt.Export()
                crReports.ReportSource = Rpt
                '' TERMINA GENERAR EL ARCHIVO AHORA A ABRIRLO
                'Shell(RutaGuardarPedidoNuevo)
                If Sw_Bitacora = False Then
                    Process.Start("AcroRd32.exe", RutaGuardarPedidoNuevo)
                End If
                Me.Close()
                Me.Dispose()


            Case -1  '''' FACTIRA CON COSTOS
                Dim Rpt As New rptReporteFacturaComp
                Dim rptStream As New System.IO.MemoryStream
                Dim Cadena As String


                Rpt.DataDefinition.FormulaFields("FM1").Text = "'" & TextoColumna(0) & "'"
                Rpt.DataDefinition.FormulaFields("FM2").Text = "'" & TextoColumna(1) & "'"
                Rpt.DataDefinition.FormulaFields("FM3").Text = "'" & TextoColumna(2) & "'"
                Rpt.DataDefinition.FormulaFields("FM4").Text = "'" & TextoColumna(3) & "'"
                Rpt.DataDefinition.FormulaFields("FM5").Text = "'" & TextoColumna(4) & "'"
                Rpt.DataDefinition.FormulaFields("FM6").Text = "'" & TextoColumna(5) & "'"
                Rpt.DataDefinition.FormulaFields("FM7").Text = "'" & TextoColumna(6) & "'"
                Rpt.DataDefinition.FormulaFields("FM8").Text = "'" & TextoColumna(7) & "'"
                Rpt.DataDefinition.FormulaFields("FM9").Text = "'" & TextoColumna(8) & "'"
                Rpt.DataDefinition.FormulaFields("FM10").Text = "'" & TextoColumna(9) & "'"
                Rpt.DataDefinition.FormulaFields("FM11").Text = "'" & TextoColumna(10) & "'"
                Rpt.DataDefinition.FormulaFields("FM12").Text = "'" & TextoColumna(11) & "'"
                Rpt.DataDefinition.FormulaFields("FM13").Text = "'" & TextoColumna(12) & "'"
                Rpt.DataDefinition.FormulaFields("FM14").Text = "'" & TextoColumna(13) & "'"
                Rpt.DataDefinition.FormulaFields("FMarca").Text = "'" & Marca & "'"
                Rpt.DataDefinition.FormulaFields("FRaz_Social").Text = "'" & Raz_Social & "'"
                Rpt.DataDefinition.FormulaFields("FVendedor").Text = "'" & Vendedor & "'"
                Rpt.DataDefinition.FormulaFields("Ftransporte").Text = "'" & Transporte & "'"
                Rpt.DataDefinition.FormulaFields("FDsctopp").Text = "'" & Dsctopp & "'"
                Rpt.DataDefinition.FormulaFields("Fdiaspp").Text = "'" & Plazopp & "'"
                Rpt.DataDefinition.FormulaFields("FFecha").Text = "'" & FechaPedido & "'"


                Rpt.DataDefinition.FormulaFields("FechaVence").Text = "'" & FechaVence & "'"
                Rpt.DataDefinition.FormulaFields("basevence").Text = "'" & BaseVence & "'"
                Rpt.DataDefinition.FormulaFields("fecharecibo").Text = "'" & FechaRecibo & "'"
                Rpt.DataDefinition.FormulaFields("fechafactura").Text = "'" & FechaFactura & "'"




                Rpt.DataDefinition.FormulaFields("Fobserva").Text = "'" & Observaciones & "'"
                '' calcular por orden de compra 
                Rpt.DataDefinition.FormulaFields("Fprs").Text = "'" & prs & "'"
                Rpt.DataDefinition.FormulaFields("FSubt").Text = "'" & Subt & "'"
                Rpt.DataDefinition.FormulaFields("Ftiva").Text = "'" & TIva & "'"
                Rpt.DataDefinition.FormulaFields("Fiva").Text = "'" & Iva & "'"
                Rpt.DataDefinition.FormulaFields("FTDesc").Text = "'" & TDscto & "'"
                Rpt.DataDefinition.FormulaFields("FTotal").Text = "'" & Total & "'"
                '' calcular por orden de compra 
                Rpt.DataDefinition.FormulaFields("FDscto01").Text = "'" & Dscto01 & "'"
                Rpt.DataDefinition.FormulaFields("FDscto02").Text = "'" & Dscto02 & "'"
                Rpt.DataDefinition.FormulaFields("FDscto03").Text = "'" & Dscto03 & "'"
                Rpt.DataDefinition.FormulaFields("FDscto04").Text = "'" & Dscto04 & "'"
                Rpt.DataDefinition.FormulaFields("FDscto05").Text = "'" & Dscto05 & "'"
                Cadena = ""
                If Dscto01.Length > 0 And Dscto01 <> "0" Then
                    Cadena = Dscto01
                End If
                If Dscto02.Length > 0 And Dscto02 <> "0" Then
                    Cadena = Cadena & " + " & Dscto02
                End If
                If Dscto03.Length > 0 And Dscto03 <> "0" Then
                    Cadena = Cadena & " + " & Dscto03
                End If
                If Dscto04.Length > 0 And Dscto04 <> "0" Then
                    Cadena = Cadena & " + " & Dscto04
                End If
                If Dscto05.Length > 0 And Dscto05 <> "0" Then
                    Cadena = Cadena & " + " & Dscto05
                End If

                Rpt.DataDefinition.FormulaFields("FDescuentos").Text = "'" & Cadena & "'"
                Rpt.DataDefinition.FormulaFields("FRealizo").Text = "'" & GLB_NomUsuario & "'"
                Rpt.DataDefinition.FormulaFields("FOrdecomp").Text = "'" & OrdeComp & "'"
                If IdFolioSuc <> "" Then
                    Rpt.DataDefinition.FormulaFields("IdFolioSuc").Text = "'" & IdFolioSuc & "'"
                End If


                Dim objDataSet As Data.DataSet
                Using objMySqlGral As New BCL.BCLPersis(GLB_ConStringPerSis)
                    Try

                        If Mid(OrdeComp, 1, 2) = "08" Or Observa = "RESURTIDO AUTOMÁTICO NOCTURNO" Then
                            'mientras

                            Rpt.DataDefinition.FormulaFields("FDir1").Text = "'SUCURSAL: MATRIZ'"
                            Rpt.DataDefinition.FormulaFields("FDir2").Text = "'JUAN ANTONIO DE LA FUENTE 345 SUR'"
                            Rpt.DataDefinition.FormulaFields("FDir3").Text = "'COL. CENTRO, C.P. 27000'"
                            Rpt.DataDefinition.FormulaFields("FDir4").Text = "'TORREÓN, COAH.'"
                            Rpt.DataDefinition.FormulaFields("FDir5").Text = "'" & "" & "'"
                            Rpt.DataDefinition.FormulaFields("FDir6").Text = "'" & "" & "'"
                        Else
                            objDataSet = objMySqlGral.usp_TraerDatosSucursal(Mid(OrdeComp, 1, 2))

                            If objDataSet.Tables(0).Rows.Count > 0 Then
                                Rpt.DataDefinition.FormulaFields("FDir1").Text = "'" & objDataSet.Tables(0).Rows(0).Item("sucursal").ToString & "'"
                                Rpt.DataDefinition.FormulaFields("FDir2").Text = "'" & objDataSet.Tables(0).Rows(0).Item("calle").ToString & "'"
                                Rpt.DataDefinition.FormulaFields("FDir3").Text = "'Col. " & objDataSet.Tables(0).Rows(0).Item("colonia").ToString & "'"
                                Rpt.DataDefinition.FormulaFields("FDir4").Text = "'" & objDataSet.Tables(0).Rows(0).Item("ciudad").ToString & ", " & objDataSet.Tables(0).Rows(0).Item("estado").ToString & ", " & objDataSet.Tables(0).Rows(0).Item("codpos").ToString & "'"
                                Rpt.DataDefinition.FormulaFields("FDir5").Text = "'" & "" & "'"
                                Rpt.DataDefinition.FormulaFields("FDir6").Text = "'" & "" & "'"


                                'mientras
                                'Rpt.DataDefinition.FormulaFields("FDir1").Text = "'SUCURSAL: " & objDataSet.Tables(0).Rows(0).Item("sucursal").ToString & "'"
                                'Rpt.DataDefinition.FormulaFields("FDir2").Text = "'JUAN ANTONIO DE LA FUENTE 345 SUR'"
                                'Rpt.DataDefinition.FormulaFields("FDir3").Text = "'COL. CENTRO, C.P. 27000'"
                                'Rpt.DataDefinition.FormulaFields("FDir4").Text = "'TORREÓN, COAH.'"
                                'Rpt.DataDefinition.FormulaFields("FDir5").Text = "'" & "" & "'"
                                'Rpt.DataDefinition.FormulaFields("FDir6").Text = "'" & "" & "'"

                            End If
                        End If

                    Catch ExceptionErr As Exception
                        MessageBox.Show(ExceptionErr.Message.ToString)
                    End Try
                End Using

                Rpt.SetDataSource(objDataSetPedidoNuevo)




                Dim CrExportOptions As CrystalDecisions.Shared.ExportOptions
                Dim CrDiskFileDestinationOptions As New CrystalDecisions.Shared.DiskFileDestinationOptions
                Dim CrFormatTypeOptions As New CrystalDecisions.Shared.PdfRtfWordFormatOptions


                CrDiskFileDestinationOptions.DiskFileName = RutaGuardarPedidoNuevo
                CrExportOptions = Rpt.ExportOptions
                With CrExportOptions
                    .ExportDestinationType = CrystalDecisions.Shared.ExportDestinationType.DiskFile
                    .ExportFormatType = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat
                    .DestinationOptions = CrDiskFileDestinationOptions
                    .FormatOptions = CrFormatTypeOptions

                End With
                Rpt.Export()
                crReports.ReportSource = Rpt
                '' TERMINA GENERAR EL ARCHIVO AHORA A ABRIRLO
                'Shell(RutaGuardarPedidoNuevo)
                If Sw_Bitacora = False Then
                    Process.Start("AcroRd32.exe", RutaGuardarPedidoNuevo)
                End If
                Me.Close()
                Me.Dispose()

            Case 1
                '' prueba 
                Dim Rpt As New rptReportePedidoNuevoProv
                Dim rptStream As New System.IO.MemoryStream
                Dim Cadena As String


                Rpt.DataDefinition.FormulaFields("FM1").Text = "'" & TextoColumna(0) & "'"
                Rpt.DataDefinition.FormulaFields("FM2").Text = "'" & TextoColumna(1) & "'"
                Rpt.DataDefinition.FormulaFields("FM3").Text = "'" & TextoColumna(2) & "'"
                Rpt.DataDefinition.FormulaFields("FM4").Text = "'" & TextoColumna(3) & "'"
                Rpt.DataDefinition.FormulaFields("FM5").Text = "'" & TextoColumna(4) & "'"
                Rpt.DataDefinition.FormulaFields("FM6").Text = "'" & TextoColumna(5) & "'"
                Rpt.DataDefinition.FormulaFields("FM7").Text = "'" & TextoColumna(6) & "'"
                Rpt.DataDefinition.FormulaFields("FM8").Text = "'" & TextoColumna(7) & "'"
                Rpt.DataDefinition.FormulaFields("FM9").Text = "'" & TextoColumna(8) & "'"
                Rpt.DataDefinition.FormulaFields("FM10").Text = "'" & TextoColumna(9) & "'"
                Rpt.DataDefinition.FormulaFields("FM11").Text = "'" & TextoColumna(10) & "'"
                Rpt.DataDefinition.FormulaFields("FM12").Text = "'" & TextoColumna(11) & "'"
                Rpt.DataDefinition.FormulaFields("FM13").Text = "'" & TextoColumna(12) & "'"
                Rpt.DataDefinition.FormulaFields("FM14").Text = "'" & TextoColumna(13) & "'"
                Rpt.DataDefinition.FormulaFields("FMarca").Text = "'" & Marca & "'"
                Rpt.DataDefinition.FormulaFields("FRaz_Social").Text = "'" & Raz_Social & "'"
                Rpt.DataDefinition.FormulaFields("FVendedor").Text = "'" & Vendedor & "'"
                Rpt.DataDefinition.FormulaFields("Ftransporte").Text = "'" & Transporte & "'"
                Rpt.DataDefinition.FormulaFields("FDsctopp").Text = "'" & Dsctopp & "'"
                Rpt.DataDefinition.FormulaFields("Fdiaspp").Text = "'" & Plazopp & "'"
                Rpt.DataDefinition.FormulaFields("FFecha").Text = "'" & FechaPedido & "'"
                Rpt.DataDefinition.FormulaFields("Fobserva").Text = "'" & Observaciones & "'"
                '' calcular por orden de compra 
                Rpt.DataDefinition.FormulaFields("Fprs").Text = "'" & prs & "'"
                Rpt.DataDefinition.FormulaFields("FSubt").Text = "'" & Subt & "'"
                Rpt.DataDefinition.FormulaFields("Ftiva").Text = "'" & TIva & "'"
                Rpt.DataDefinition.FormulaFields("Fiva").Text = "'" & Iva & "'"
                Rpt.DataDefinition.FormulaFields("FTDesc").Text = "'" & TDscto & "'"
                Rpt.DataDefinition.FormulaFields("FTotal").Text = "'" & Total & "'"
                '' calcular por orden de compra 
                Rpt.DataDefinition.FormulaFields("FDscto01").Text = "'" & Dscto01 & "'"
                Rpt.DataDefinition.FormulaFields("FDscto02").Text = "'" & Dscto02 & "'"
                Rpt.DataDefinition.FormulaFields("FDscto03").Text = "'" & Dscto03 & "'"
                Rpt.DataDefinition.FormulaFields("FDscto04").Text = "'" & Dscto04 & "'"
                Rpt.DataDefinition.FormulaFields("FDscto05").Text = "'" & Dscto05 & "'"
                Cadena = ""
                If Dscto01.Length > 0 And Dscto01 <> "0" Then
                    Cadena = Dscto01
                End If
                If Dscto02.Length > 0 And Dscto02 <> "0" Then
                    Cadena = Cadena & " + " & Dscto02
                End If
                If Dscto03.Length > 0 And Dscto03 <> "0" Then
                    Cadena = Cadena & " + " & Dscto03
                End If
                If Dscto04.Length > 0 And Dscto04 <> "0" Then
                    Cadena = Cadena & " + " & Dscto04
                End If
                If Dscto05.Length > 0 And Dscto05 <> "0" Then
                    Cadena = Cadena & " + " & Dscto05
                End If

                Rpt.DataDefinition.FormulaFields("FDescuentos").Text = "'" & Cadena & "'"
                Rpt.DataDefinition.FormulaFields("FRealizo").Text = "'" & GLB_NomUsuario & "'"
                Rpt.DataDefinition.FormulaFields("FOrdecomp").Text = "'" & OrdeComp & "'"

                'prueba mreyes 10/Diciembre/2014
                If IdFolioSuc <> "" Then
                    Rpt.DataDefinition.FormulaFields("IdFolioSuc").Text = "'" & IdFolioSuc & "'"
                End If

                'Rpt.SetDataSource(objDataSetPedidoNuevo.Tables(0))

                Dim objDataSet As Data.DataSet
                Using objMySqlGral As New BCL.BCLPersis(GLB_ConStringPerSis)
                    Try


                        If Mid(OrdeComp, 1, 2) = "08" Or Observa = "RESURTIDO AUTOMÁTICO NOCTURNO" Then
                            'mientras

                            Rpt.DataDefinition.FormulaFields("FDir1").Text = "'SUCURSAL: MATRIZ'"
                            Rpt.DataDefinition.FormulaFields("FDir2").Text = "'JUAN ANTONIO DE LA FUENTE 345 SUR'"
                            Rpt.DataDefinition.FormulaFields("FDir3").Text = "'COL. CENTRO, C.P. 27000'"
                            Rpt.DataDefinition.FormulaFields("FDir4").Text = "'TORREÓN, COAH.'"
                            Rpt.DataDefinition.FormulaFields("FDir5").Text = "'" & "" & "'"
                            Rpt.DataDefinition.FormulaFields("FDir6").Text = "'" & "" & "'"
                        Else
                            objDataSet = objMySqlGral.usp_TraerDatosSucursal(Mid(OrdeComp, 1, 2))

                            If objDataSet.Tables(0).Rows.Count > 0 Then
                                Rpt.DataDefinition.FormulaFields("FDir1").Text = "'" & objDataSet.Tables(0).Rows(0).Item("sucursal").ToString & "'"
                                Rpt.DataDefinition.FormulaFields("FDir2").Text = "'" & objDataSet.Tables(0).Rows(0).Item("calle").ToString & "'"
                                Rpt.DataDefinition.FormulaFields("FDir3").Text = "'Col. " & objDataSet.Tables(0).Rows(0).Item("colonia").ToString & "'"
                                Rpt.DataDefinition.FormulaFields("FDir4").Text = "'" & objDataSet.Tables(0).Rows(0).Item("ciudad").ToString & ", " & objDataSet.Tables(0).Rows(0).Item("estado").ToString & ", " & objDataSet.Tables(0).Rows(0).Item("codpos").ToString & "'"
                                Rpt.DataDefinition.FormulaFields("FDir5").Text = "'" & "" & "'"
                                Rpt.DataDefinition.FormulaFields("FDir6").Text = "'" & "" & "'"

                                'mientras
                                'Rpt.DataDefinition.FormulaFields("FDir1").Text = "'SUCURSAL: " & objDataSet.Tables(0).Rows(0).Item("sucursal").ToString & "'"
                                'Rpt.DataDefinition.FormulaFields("FDir2").Text = "'JUAN ANTONIO DE LA FUENTE 345 SUR'"
                                'Rpt.DataDefinition.FormulaFields("FDir3").Text = "'COL. CENTRO, C.P. 27000'"
                                'Rpt.DataDefinition.FormulaFields("FDir4").Text = "'TORREÓN, COAH.'"
                                'Rpt.DataDefinition.FormulaFields("FDir5").Text = "'" & "" & "'"
                                'Rpt.DataDefinition.FormulaFields("FDir6").Text = "'" & "" & "'"

                            End If
                        End If

                    Catch ExceptionErr As Exception
                        MessageBox.Show(ExceptionErr.Message.ToString)
                    End Try
                End Using
                Rpt.SetDataSource(objDataSetPedidoNuevo)




                Dim CrExportOptions As CrystalDecisions.Shared.ExportOptions
                Dim CrDiskFileDestinationOptions As New CrystalDecisions.Shared.DiskFileDestinationOptions
                Dim CrFormatTypeOptions As New CrystalDecisions.Shared.PdfRtfWordFormatOptions


                CrDiskFileDestinationOptions.DiskFileName = RutaGuardarPedidoNuevo
                CrExportOptions = Rpt.ExportOptions
                With CrExportOptions
                    .ExportDestinationType = CrystalDecisions.Shared.ExportDestinationType.DiskFile
                    .ExportFormatType = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat
                    .DestinationOptions = CrDiskFileDestinationOptions
                    .FormatOptions = CrFormatTypeOptions

                End With
                Rpt.Export()
                crReports.ReportSource = Rpt
                '' TERMINA GENERAR EL ARCHIVO AHORA A ABRIRLO
                'Shell(RutaGuardarPedidoNuevo)
                If Sw_Bitacora = False Then
                    Process.Start("AcroRd32.exe", RutaGuardarPedidoNuevo)
                End If

                ''Dim startInfo As New ProcessStartInfo("AcroRd32.exe")
                ''startInfo.WindowStyle = ProcessWindowStyle.Maximized

                ''Process.Start(startInfo)
                ''startInfo.FileName = RutaGuardarPedidoNuevo
                ''Process.Start(startInfo)


                Me.Close()
                Me.Dispose()


            Case 2
                '' prueba 
                Dim Rpt As New rptReporteCanceProv
                Dim rptStream As New System.IO.MemoryStream
                Dim Cadena As String = ""


                Rpt.DataDefinition.FormulaFields("FM1").Text = "'" & TextoColumna(0) & "'"
                Rpt.DataDefinition.FormulaFields("FM2").Text = "'" & TextoColumna(1) & "'"
                Rpt.DataDefinition.FormulaFields("FM3").Text = "'" & TextoColumna(2) & "'"
                Rpt.DataDefinition.FormulaFields("FM4").Text = "'" & TextoColumna(3) & "'"
                Rpt.DataDefinition.FormulaFields("FM5").Text = "'" & TextoColumna(4) & "'"
                Rpt.DataDefinition.FormulaFields("FM6").Text = "'" & TextoColumna(5) & "'"
                Rpt.DataDefinition.FormulaFields("FM7").Text = "'" & TextoColumna(6) & "'"
                Rpt.DataDefinition.FormulaFields("FM8").Text = "'" & TextoColumna(7) & "'"
                Rpt.DataDefinition.FormulaFields("FM9").Text = "'" & TextoColumna(8) & "'"
                Rpt.DataDefinition.FormulaFields("FM10").Text = "'" & TextoColumna(9) & "'"
                Rpt.DataDefinition.FormulaFields("FM11").Text = "'" & TextoColumna(10) & "'"
                Rpt.DataDefinition.FormulaFields("FM12").Text = "'" & TextoColumna(11) & "'"
                Rpt.DataDefinition.FormulaFields("FM13").Text = "'" & TextoColumna(12) & "'"
                Rpt.DataDefinition.FormulaFields("FM14").Text = "'" & TextoColumna(13) & "'"
                Rpt.DataDefinition.FormulaFields("FMarca").Text = "'" & Marca & "'"
                Rpt.DataDefinition.FormulaFields("FRaz_Social").Text = "'" & Raz_Social & "'"
                Rpt.DataDefinition.FormulaFields("FVendedor").Text = "'" & Vendedor & "'"
                Rpt.DataDefinition.FormulaFields("Ftransporte").Text = "'" & Transporte & "'"
                Rpt.DataDefinition.FormulaFields("FDsctopp").Text = "'" & Dsctopp & "'"
                Rpt.DataDefinition.FormulaFields("Fdiaspp").Text = "'" & Plazopp & "'"
                Rpt.DataDefinition.FormulaFields("FFecha").Text = "'" & FechaPedido & "'"
                Rpt.DataDefinition.FormulaFields("Fobserva").Text = "'" & Observaciones & "'"
                '' calcular por orden de compra 
                Rpt.DataDefinition.FormulaFields("Fprs").Text = "'" & prs & "'"
                Rpt.DataDefinition.FormulaFields("FSubt").Text = "'" & Subt & "'"
                Rpt.DataDefinition.FormulaFields("Ftiva").Text = "'" & TIva & "'"
                Rpt.DataDefinition.FormulaFields("Fiva").Text = "'" & Iva & "'"
                Rpt.DataDefinition.FormulaFields("FTDesc").Text = "'" & TDscto & "'"
                Rpt.DataDefinition.FormulaFields("FTotal").Text = "'" & Total & "'"
                '' calcular por orden de compra 
                Rpt.DataDefinition.FormulaFields("FDscto01").Text = "'" & Dscto01 & "'"
                Rpt.DataDefinition.FormulaFields("FDscto02").Text = "'" & Dscto02 & "'"
                Rpt.DataDefinition.FormulaFields("FDscto03").Text = "'" & Dscto03 & "'"
                Rpt.DataDefinition.FormulaFields("FDscto04").Text = "'" & Dscto04 & "'"
                Rpt.DataDefinition.FormulaFields("FDscto05").Text = "'" & Dscto05 & "'"

                Rpt.DataDefinition.FormulaFields("FDescuentos").Text = "'" & Cadena & "'"
                Rpt.DataDefinition.FormulaFields("FRealizo").Text = "'" & GLB_NomUsuario & "'"
                Rpt.DataDefinition.FormulaFields("FOrdecomp").Text = "'" & OrdeComp & "'"
                'Rpt.SetDataSource(objDataSetPedidoNuevo.Tables(0))

                Dim objDataSet As Data.DataSet
                Using objMySqlGral As New BCL.BCLPersis(GLB_ConStringPerSis)
                    Try
                        If Mid(OrdeComp, 1, 2) = "08" Or Observa = "RESURTIDO AUTOMÁTICO NOCTURNO" Then
                            'mientras

                            Rpt.DataDefinition.FormulaFields("FDir1").Text = "'SUCURSAL: MATRIZ'"
                            Rpt.DataDefinition.FormulaFields("FDir2").Text = "'JUAN ANTONIO DE LA FUENTE 345 SUR'"
                            Rpt.DataDefinition.FormulaFields("FDir3").Text = "'COL. CENTRO, C.P. 27000'"
                            Rpt.DataDefinition.FormulaFields("FDir4").Text = "'TORREÓN, COAH.'"
                            Rpt.DataDefinition.FormulaFields("FDir5").Text = "'" & "" & "'"
                            Rpt.DataDefinition.FormulaFields("FDir6").Text = "'" & "" & "'"
                        Else
                            objDataSet = objMySqlGral.usp_TraerDatosSucursal(Mid(OrdeComp, 1, 2))

                            If objDataSet.Tables(0).Rows.Count > 0 Then
                                Rpt.DataDefinition.FormulaFields("FDir1").Text = "'" & objDataSet.Tables(0).Rows(0).Item("sucursal").ToString & "'"
                                Rpt.DataDefinition.FormulaFields("FDir2").Text = "'" & objDataSet.Tables(0).Rows(0).Item("calle").ToString & "'"
                                Rpt.DataDefinition.FormulaFields("FDir3").Text = "'Col. " & objDataSet.Tables(0).Rows(0).Item("colonia").ToString & "'"
                                Rpt.DataDefinition.FormulaFields("FDir4").Text = "'" & objDataSet.Tables(0).Rows(0).Item("ciudad").ToString & ", " & objDataSet.Tables(0).Rows(0).Item("estado").ToString & ", " & objDataSet.Tables(0).Rows(0).Item("codpos").ToString & "'"
                                Rpt.DataDefinition.FormulaFields("FDir5").Text = "'" & "" & "'"
                                Rpt.DataDefinition.FormulaFields("FDir6").Text = "'" & "" & "'"


                                'mientras
                                'Rpt.DataDefinition.FormulaFields("FDir1").Text = "'SUCURSAL: " & objDataSet.Tables(0).Rows(0).Item("sucursal").ToString & "'"
                                'Rpt.DataDefinition.FormulaFields("FDir2").Text = "'JUAN ANTONIO DE LA FUENTE 345 SUR'"
                                'Rpt.DataDefinition.FormulaFields("FDir3").Text = "'COL. CENTRO, C.P. 27000'"
                                'Rpt.DataDefinition.FormulaFields("FDir4").Text = "'TORREÓN, COAH.'"
                                'Rpt.DataDefinition.FormulaFields("FDir5").Text = "'" & "" & "'"
                                'Rpt.DataDefinition.FormulaFields("FDir6").Text = "'" & "" & "'"
                            End If
                        End If

                    Catch ExceptionErr As Exception
                        MessageBox.Show(ExceptionErr.Message.ToString)
                    End Try
                End Using

                Rpt.SetDataSource(objDataSetPedidoNuevo)



                Dim CrExportOptions As CrystalDecisions.Shared.ExportOptions
                Dim CrDiskFileDestinationOptions As New CrystalDecisions.Shared.DiskFileDestinationOptions
                Dim CrFormatTypeOptions As New CrystalDecisions.Shared.PdfRtfWordFormatOptions


                CrDiskFileDestinationOptions.DiskFileName = RutaGuardarPedidoNuevo
                CrExportOptions = Rpt.ExportOptions
                With CrExportOptions
                    .ExportDestinationType = CrystalDecisions.Shared.ExportDestinationType.DiskFile
                    .ExportFormatType = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat
                    .DestinationOptions = CrDiskFileDestinationOptions
                    .FormatOptions = CrFormatTypeOptions

                End With
                Rpt.Export()
                crReports.ReportSource = Rpt
                '' TERMINA GENERAR EL ARCHIVO AHORA A ABRIRLO
                'Shell(RutaGuardarPedidoNuevo)
                If Sw_Bitacora = False Then
                    Process.Start("AcroRd32.exe", RutaGuardarPedidoNuevo)
                End If



                ''Dim startInfo As New ProcessStartInfo("AcroRd32.exe")
                ''startInfo.WindowStyle = ProcessWindowStyle.Maximized

                ''Process.Start(startInfo)
                ''startInfo.FileName = RutaGuardarPedidoNuevo
                ''Process.Start(startInfo)


                Me.Close()
                Me.Dispose()

            Case 3
                ' PEDIDO PARA CEDI

                Dim Rpt As New rptReporteCedi
                Dim rptStream As New System.IO.MemoryStream
                Dim Cadena As String


                Rpt.DataDefinition.FormulaFields("FM1").Text = "'" & TextoColumna(0) & "'"
                Rpt.DataDefinition.FormulaFields("FM2").Text = "'" & TextoColumna(1) & "'"
                Rpt.DataDefinition.FormulaFields("FM3").Text = "'" & TextoColumna(2) & "'"
                Rpt.DataDefinition.FormulaFields("FM4").Text = "'" & TextoColumna(3) & "'"
                Rpt.DataDefinition.FormulaFields("FM5").Text = "'" & TextoColumna(4) & "'"
                Rpt.DataDefinition.FormulaFields("FM6").Text = "'" & TextoColumna(5) & "'"
                Rpt.DataDefinition.FormulaFields("FM7").Text = "'" & TextoColumna(6) & "'"
                Rpt.DataDefinition.FormulaFields("FM8").Text = "'" & TextoColumna(7) & "'"
                Rpt.DataDefinition.FormulaFields("FM9").Text = "'" & TextoColumna(8) & "'"
                Rpt.DataDefinition.FormulaFields("FM10").Text = "'" & TextoColumna(9) & "'"
                Rpt.DataDefinition.FormulaFields("FM11").Text = "'" & TextoColumna(10) & "'"
                Rpt.DataDefinition.FormulaFields("FM12").Text = "'" & TextoColumna(11) & "'"
                Rpt.DataDefinition.FormulaFields("FM13").Text = "'" & TextoColumna(12) & "'"
                Rpt.DataDefinition.FormulaFields("FM14").Text = "'" & TextoColumna(13) & "'"
                Rpt.DataDefinition.FormulaFields("FMarca").Text = "'" & Marca & "'"
                Rpt.DataDefinition.FormulaFields("FRaz_Social").Text = "'" & Raz_Social & "'"
                Rpt.DataDefinition.FormulaFields("FVendedor").Text = "'" & Vendedor & "'"
                Rpt.DataDefinition.FormulaFields("Ftransporte").Text = "'" & Transporte & "'"
                Rpt.DataDefinition.FormulaFields("FDsctopp").Text = "'" & Dsctopp & "'"
                Rpt.DataDefinition.FormulaFields("Fdiaspp").Text = "'" & Plazopp & "'"
                Rpt.DataDefinition.FormulaFields("FFecha").Text = "'" & FechaPedido & "'"
                Rpt.DataDefinition.FormulaFields("Fobserva").Text = "'" & Observaciones & "'"
                '' calcular por orden de compra 
                Rpt.DataDefinition.FormulaFields("Fprs").Text = "'" & prs & "'"
                Rpt.DataDefinition.FormulaFields("FSubt").Text = "'" & Subt & "'"
                Rpt.DataDefinition.FormulaFields("Ftiva").Text = "'" & TIva & "'"
                Rpt.DataDefinition.FormulaFields("Fiva").Text = "'" & Iva & "'"
                Rpt.DataDefinition.FormulaFields("FTDesc").Text = "'" & TDscto & "'"
                Rpt.DataDefinition.FormulaFields("FTotal").Text = "'" & Total & "'"
                '' calcular por orden de compra 
                Rpt.DataDefinition.FormulaFields("FDscto01").Text = "'" & Dscto01 & "'"
                Rpt.DataDefinition.FormulaFields("FDscto02").Text = "'" & Dscto02 & "'"
                Rpt.DataDefinition.FormulaFields("FDscto03").Text = "'" & Dscto03 & "'"
                Rpt.DataDefinition.FormulaFields("FDscto04").Text = "'" & Dscto04 & "'"
                Rpt.DataDefinition.FormulaFields("FDscto05").Text = "'" & Dscto05 & "'"
                Cadena = ""
                If Dscto01.Length > 0 And Dscto01 <> "0" Then
                    Cadena = Dscto01
                End If
                If Dscto02.Length > 0 And Dscto02 <> "0" Then
                    Cadena = Cadena & " + " & Dscto02
                End If
                If Dscto03.Length > 0 And Dscto03 <> "0" Then
                    Cadena = Cadena & " + " & Dscto03
                End If
                If Dscto04.Length > 0 And Dscto04 <> "0" Then
                    Cadena = Cadena & " + " & Dscto04
                End If
                If Dscto05.Length > 0 And Dscto05 <> "0" Then
                    Cadena = Cadena & " + " & Dscto05
                End If

                Rpt.DataDefinition.FormulaFields("FDescuentos").Text = "'" & Cadena & "'"
                Rpt.DataDefinition.FormulaFields("FRealizo").Text = "'" & GLB_NomUsuario & "'"
                Rpt.DataDefinition.FormulaFields("FOrdecomp").Text = "'" & OrdeComp & "'"
                'Rpt.SetDataSource(objDataSetPedidoNuevo.Tables(0))

                Dim objDataSet As Data.DataSet
                Using objMySqlGral As New BCL.BCLPersis(GLB_ConStringPerSis)
                    Try
                        If Mid(OrdeComp, 1, 2) = "08" Or Observa = "RESURTIDO AUTOMÁTICO NOCTURNO" Then
                            'mientras

                            Rpt.DataDefinition.FormulaFields("FDir1").Text = "'SUCURSAL: MATRIZ'"
                            Rpt.DataDefinition.FormulaFields("FDir2").Text = "'JUAN ANTONIO DE LA FUENTE 345 SUR'"
                            Rpt.DataDefinition.FormulaFields("FDir3").Text = "'COL. CENTRO, C.P. 27000'"
                            Rpt.DataDefinition.FormulaFields("FDir4").Text = "'TORREÓN, COAH.'"
                            Rpt.DataDefinition.FormulaFields("FDir5").Text = "'" & "" & "'"
                            Rpt.DataDefinition.FormulaFields("FDir6").Text = "'" & "" & "'"
                        Else
                            objDataSet = objMySqlGral.usp_TraerDatosSucursal(Mid(OrdeComp, 1, 2))

                            If objDataSet.Tables(0).Rows.Count > 0 Then
                                Rpt.DataDefinition.FormulaFields("FDir1").Text = "'" & objDataSet.Tables(0).Rows(0).Item("sucursal").ToString & "'"
                                Rpt.DataDefinition.FormulaFields("FDir2").Text = "'" & objDataSet.Tables(0).Rows(0).Item("calle").ToString & "'"
                                Rpt.DataDefinition.FormulaFields("FDir3").Text = "'Col. " & objDataSet.Tables(0).Rows(0).Item("colonia").ToString & "'"
                                Rpt.DataDefinition.FormulaFields("FDir4").Text = "'" & objDataSet.Tables(0).Rows(0).Item("ciudad").ToString & ", " & objDataSet.Tables(0).Rows(0).Item("estado").ToString & ", " & objDataSet.Tables(0).Rows(0).Item("codpos").ToString & "'"
                                Rpt.DataDefinition.FormulaFields("FDir5").Text = "'" & "" & "'"
                                Rpt.DataDefinition.FormulaFields("FDir6").Text = "'" & "" & "'"

                                'mientras
                                'Rpt.DataDefinition.FormulaFields("FDir1").Text = "'SUCURSAL: " & objDataSet.Tables(0).Rows(0).Item("sucursal").ToString & "'"
                                'Rpt.DataDefinition.FormulaFields("FDir2").Text = "'JUAN ANTONIO DE LA FUENTE 345 SUR'"
                                'Rpt.DataDefinition.FormulaFields("FDir3").Text = "'COL. CENTRO, C.P. 27000'"
                                'Rpt.DataDefinition.FormulaFields("FDir4").Text = "'TORREÓN, COAH.'"
                                'Rpt.DataDefinition.FormulaFields("FDir5").Text = "'" & "" & "'"
                                'Rpt.DataDefinition.FormulaFields("FDir6").Text = "'" & "" & "'"

                            End If
                        End If

                    Catch ExceptionErr As Exception
                        MessageBox.Show(ExceptionErr.Message.ToString)
                    End Try
                End Using
                Rpt.SetDataSource(objDataSetPedidoNuevo)
                crReports.ReportSource = Rpt

            Case 13
                'RECIBO DE CEDI.

                Dim Rpt As New rptReporteFacturaCedi
                Dim rptStream As New System.IO.MemoryStream
                Dim Cadena As String
                Rpt.DataDefinition.FormulaFields("fechafactura").Text = "'" & FechaFactura & "'"
                Rpt.DataDefinition.FormulaFields("folioentrada").Text = "'" & FolioEntrada & "'"
                Rpt.DataDefinition.FormulaFields("foliofactura").Text = "'" & FolioFactura & "'"
                Rpt.DataDefinition.FormulaFields("FM1").Text = "'" & TextoColumna(0) & "'"
                Rpt.DataDefinition.FormulaFields("FM2").Text = "'" & TextoColumna(1) & "'"
                Rpt.DataDefinition.FormulaFields("FM3").Text = "'" & TextoColumna(2) & "'"
                Rpt.DataDefinition.FormulaFields("FM4").Text = "'" & TextoColumna(3) & "'"
                Rpt.DataDefinition.FormulaFields("FM5").Text = "'" & TextoColumna(4) & "'"
                Rpt.DataDefinition.FormulaFields("FM6").Text = "'" & TextoColumna(5) & "'"
                Rpt.DataDefinition.FormulaFields("FM7").Text = "'" & TextoColumna(6) & "'"
                Rpt.DataDefinition.FormulaFields("FM8").Text = "'" & TextoColumna(7) & "'"
                Rpt.DataDefinition.FormulaFields("FM9").Text = "'" & TextoColumna(8) & "'"
                Rpt.DataDefinition.FormulaFields("FM10").Text = "'" & TextoColumna(9) & "'"
                Rpt.DataDefinition.FormulaFields("FM11").Text = "'" & TextoColumna(10) & "'"
                Rpt.DataDefinition.FormulaFields("FM12").Text = "'" & TextoColumna(11) & "'"
                Rpt.DataDefinition.FormulaFields("FM13").Text = "'" & TextoColumna(12) & "'"
                Rpt.DataDefinition.FormulaFields("FM14").Text = "'" & TextoColumna(13) & "'"
                Rpt.DataDefinition.FormulaFields("FMarca").Text = "'" & Marca & "'"
                Rpt.DataDefinition.FormulaFields("FRaz_Social").Text = "'" & Raz_Social & "'"
                Rpt.DataDefinition.FormulaFields("FVendedor").Text = "'" & Vendedor & "'"
                Rpt.DataDefinition.FormulaFields("Ftransporte").Text = "'" & Transporte & "'"
                Rpt.DataDefinition.FormulaFields("FDsctopp").Text = "'" & Dsctopp & "'"
                Rpt.DataDefinition.FormulaFields("Fdiaspp").Text = "'" & Plazopp & "'"
                Rpt.DataDefinition.FormulaFields("FFecha").Text = "'" & FechaPedido & "'"
                Rpt.DataDefinition.FormulaFields("Fobserva").Text = "'" & Observaciones & "'"
                '' calcular por orden de compra 
                Rpt.DataDefinition.FormulaFields("Fprs").Text = "'" & prs & "'"
                Rpt.DataDefinition.FormulaFields("FSubt").Text = "'" & Subt & "'"
                Rpt.DataDefinition.FormulaFields("Ftiva").Text = "'" & TIva & "'"
                Rpt.DataDefinition.FormulaFields("Fiva").Text = "'" & Iva & "'"
                Rpt.DataDefinition.FormulaFields("FTDesc").Text = "'" & TDscto & "'"
                Rpt.DataDefinition.FormulaFields("FTotal").Text = "'" & Total & "'"
                '' calcular por orden de compra 
                Rpt.DataDefinition.FormulaFields("FDscto01").Text = "'" & Dscto01 & "'"
                Rpt.DataDefinition.FormulaFields("FDscto02").Text = "'" & Dscto02 & "'"
                Rpt.DataDefinition.FormulaFields("FDscto03").Text = "'" & Dscto03 & "'"
                Rpt.DataDefinition.FormulaFields("FDscto04").Text = "'" & Dscto04 & "'"
                Rpt.DataDefinition.FormulaFields("FDscto05").Text = "'" & Dscto05 & "'"
                Rpt.DataDefinition.FormulaFields("r_titulo").Text = "'" & r_Titulo & "'"
                Cadena = ""
                If Dscto01.Length > 0 And Dscto01 <> "0" Then
                    Cadena = Dscto01
                End If
                If Dscto02.Length > 0 And Dscto02 <> "0" Then
                    Cadena = Cadena & " + " & Dscto02
                End If
                If Dscto03.Length > 0 And Dscto03 <> "0" Then
                    Cadena = Cadena & " + " & Dscto03
                End If
                If Dscto04.Length > 0 And Dscto04 <> "0" Then
                    Cadena = Cadena & " + " & Dscto04
                End If
                If Dscto05.Length > 0 And Dscto05 <> "0" Then
                    Cadena = Cadena & " + " & Dscto05
                End If

                Rpt.DataDefinition.FormulaFields("FDescuentos").Text = "'" & Cadena & "'"
                Rpt.DataDefinition.FormulaFields("FRealizo").Text = "'" & GLB_NomUsuario & "'"
                Rpt.DataDefinition.FormulaFields("FOrdecomp").Text = "'" & OrdeComp & "'"
                Rpt.DataDefinition.FormulaFields("IdFolioSuc").Text = "'" & IdFolioSuc & "'"
                'Rpt.SetDataSource(objDataSetPedidoNuevo.Tables(0))

                Dim objDataSet As Data.DataSet
                Using objMySqlGral As New BCL.BCLPersis(GLB_ConStringPerSis)
                    Try

                        objDataSet = objMySqlGral.usp_TraerDatosSucursal(Mid(OrdeComp, 1, 2))
                        If Mid(OrdeComp, 1, 2) = "08" Or Observa = "RESURTIDO AUTOMÁTICO NOCTURNO" Then
                            'mientras

                            Rpt.DataDefinition.FormulaFields("FDir1").Text = "'SUCURSAL: MATRIZ'"
                            Rpt.DataDefinition.FormulaFields("FDir2").Text = "'JUAN ANTONIO DE LA FUENTE 345 SUR'"
                            Rpt.DataDefinition.FormulaFields("FDir3").Text = "'COL. CENTRO, C.P. 27000'"
                            Rpt.DataDefinition.FormulaFields("FDir4").Text = "'TORREÓN, COAH.'"
                            Rpt.DataDefinition.FormulaFields("FDir5").Text = "'" & "" & "'"
                            Rpt.DataDefinition.FormulaFields("FDir6").Text = "'" & "" & "'"
                        Else
                            If objDataSet.Tables(0).Rows.Count > 0 Then


                                Rpt.DataDefinition.FormulaFields("FDir1").Text = "'" & objDataSet.Tables(0).Rows(0).Item("sucursal").ToString & "'"
                                Rpt.DataDefinition.FormulaFields("FDir2").Text = "'" & objDataSet.Tables(0).Rows(0).Item("calle").ToString & "'"
                                Rpt.DataDefinition.FormulaFields("FDir3").Text = "'Col. " & objDataSet.Tables(0).Rows(0).Item("colonia").ToString & "'"
                                Rpt.DataDefinition.FormulaFields("FDir4").Text = "'" & objDataSet.Tables(0).Rows(0).Item("ciudad").ToString & ", " & objDataSet.Tables(0).Rows(0).Item("estado").ToString & ", " & objDataSet.Tables(0).Rows(0).Item("codpos").ToString & "'"
                                Rpt.DataDefinition.FormulaFields("FDir5").Text = "'" & "" & "'"
                                Rpt.DataDefinition.FormulaFields("FDir6").Text = "'" & "" & "'"

                                ''mientras
                                'Rpt.DataDefinition.FormulaFields("FDir1").Text = "'SUCURSAL: " & objDataSet.Tables(0).Rows(0).Item("sucursal").ToString & "'"
                                'Rpt.DataDefinition.FormulaFields("FDir2").Text = "'JUAN ANTONIO DE LA FUENTE 345 SUR'"
                                'Rpt.DataDefinition.FormulaFields("FDir3").Text = "'COL. CENTRO, C.P. 27000'"
                                'Rpt.DataDefinition.FormulaFields("FDir4").Text = "'TORREÓN, COAH.'"
                                'Rpt.DataDefinition.FormulaFields("FDir5").Text = "'" & "" & "'"
                                'Rpt.DataDefinition.FormulaFields("FDir6").Text = "'" & "" & "'"

                            End If
                        End If

                    Catch ExceptionErr As Exception
                        MessageBox.Show(ExceptionErr.Message.ToString)
                    End Try
                End Using
                Rpt.SetDataSource(objDataSetPedidoNuevo)
                crReports.ReportSource = Rpt

            Case 4
                '' prueba 
                Dim Rpt As New rptReciboNominaF
                Dim rptStream As New System.IO.MemoryStream


                'Rpt.DataDefinition.FormulaFields("ffechanomina").Text = "'" & FechaNominaB & " '"

                Rpt.SetDataSource(objDataSetReciboNomina)

                crReports.ReportSource = Rpt

            Case 5
                ' PEDIDO PARA CEDI

                Dim Rpt As New rptReciboBono
                ' Rpt.DataDefinition.FormulaFields("FDescuentos").Text = "'" & Cadena & "'"

                Rpt.SetDataSource(objDataSetReciboBono)
                crReports.ReportSource = Rpt


            Case 6
                ' NÒMINA DE BONOS

                Dim Rpt As New rtpPpalNomina
                ' Rpt.DataDefinition.FormulaFields("FDescuentos").Text = "'" & Cadena & "'"

                Rpt.SetDataSource(objDataSetPpalNomina)
                crReports.ReportSource = Rpt

            Case 7
                'nomina fiscal

                Dim Rpt As New rtpPpalNominaFiscal
                ' Rpt.DataDefinition.FormulaFields("FDescuentos").Text = "'" & Cadena & "'"

                Rpt.SetDataSource(objDataSetPpalNomina)
                crReports.ReportSource = Rpt

            Case 8
                'AGUIBONO

                Dim Rpt As New rptReciboAguiBono
                ' Rpt.DataDefinition.FormulaFields("FDescuentos").Text = "'" & Cadena & "'"

                Rpt.SetDataSource(objDataSetReciboBono)
                crReports.ReportSource = Rpt

            Case 9
                'nomina fiscal

                Dim Rpt As New rtpPpalNominaAguinaldo
                ' Rpt.DataDefinition.FormulaFields("FDescuentos").Text = "'" & Cadena & "'"

                Rpt.SetDataSource(objDataSetPpalNomina)
                crReports.ReportSource = Rpt

            Case 10
                ' BULTOS

                Dim Rpt As New rptBulto
                ' Rpt.DataDefinition.FormulaFields("FDescuentos").Text = "'" & Cadena & "'"
                'Rpt.PrintOptions.PrinterName = GLB_ImpresoraMovs
                Rpt.DataDefinition.FormulaFields("rTipo").Text = "'" & TipoRecibo & "'"
                Rpt.DataDefinition.FormulaFields("rCancelado").Text = "'" & CanceladoRecibo & "'"
                Rpt.DataDefinition.FormulaFields("r_Titulo").Text = "'" & r_Titulo & "'"
                Rpt.SetDataSource(objDataSetBulto)
                crReports.ReportSource = Rpt
                ' Rpt.PrintToPrinter(1, False, 0, 0)

            Case 16
                ' REPORTE DE LIQUIDACION DETALLE
                Dim Rpt As New rptReporteLiquidacionDetalle
                Rpt.SetDataSource(objDataSetLiquidacionDetalle)
                crReports.ReportSource = Rpt

            Case 23
                Dim Rpt As New rptReporteVentas
                Rpt.SetDataSource(objDataSetReporteVentas)
                crReports.ReportSource = Rpt
            Case 24
                Dim Rpt As New rptReporteVentasDet1
                Rpt.SetDataSource(objDataSetReporteVentas)
                crReports.ReportSource = Rpt
            Case 25
                Dim Rpt As New rptReporteVentasDet2
                Rpt.SetDataSource(objDataSetReporteVentas)
                crReports.ReportSource = Rpt
            Case 33
                'RECIBO DE CEDI, DEVOLUCION
                Dim Rpt As New rptReporteDevoCedi

                Dim rptStream As New System.IO.MemoryStream
                Dim Cadena As String
                Rpt.DataDefinition.FormulaFields("fechafactura").Text = "'" & FechaFactura & "'"
                Rpt.DataDefinition.FormulaFields("folioentrada").Text = "'" & FolioEntrada & "'"
                Rpt.DataDefinition.FormulaFields("foliofactura").Text = "'" & FolioFactura & "'"
                Rpt.DataDefinition.FormulaFields("FM1").Text = "'" & TextoColumna(0) & "'"
                Rpt.DataDefinition.FormulaFields("FM2").Text = "'" & TextoColumna(1) & "'"
                Rpt.DataDefinition.FormulaFields("FM3").Text = "'" & TextoColumna(2) & "'"
                Rpt.DataDefinition.FormulaFields("FM4").Text = "'" & TextoColumna(3) & "'"
                Rpt.DataDefinition.FormulaFields("FM5").Text = "'" & TextoColumna(4) & "'"
                Rpt.DataDefinition.FormulaFields("FM6").Text = "'" & TextoColumna(5) & "'"
                Rpt.DataDefinition.FormulaFields("FM7").Text = "'" & TextoColumna(6) & "'"
                Rpt.DataDefinition.FormulaFields("FM8").Text = "'" & TextoColumna(7) & "'"
                Rpt.DataDefinition.FormulaFields("FM9").Text = "'" & TextoColumna(8) & "'"
                Rpt.DataDefinition.FormulaFields("FM10").Text = "'" & TextoColumna(9) & "'"
                Rpt.DataDefinition.FormulaFields("FM11").Text = "'" & TextoColumna(10) & "'"
                Rpt.DataDefinition.FormulaFields("FM12").Text = "'" & TextoColumna(11) & "'"
                Rpt.DataDefinition.FormulaFields("FM13").Text = "'" & TextoColumna(12) & "'"
                Rpt.DataDefinition.FormulaFields("FM14").Text = "'" & TextoColumna(13) & "'"
                Rpt.DataDefinition.FormulaFields("FMarca").Text = "'" & Marca & "'"
                Rpt.DataDefinition.FormulaFields("FRaz_Social").Text = "'" & Raz_Social & "'"
                Rpt.DataDefinition.FormulaFields("FVendedor").Text = "'" & Vendedor & "'"
                Rpt.DataDefinition.FormulaFields("Ftransporte").Text = "'" & Transporte & "'"
                Rpt.DataDefinition.FormulaFields("FDsctopp").Text = "'" & Dsctopp & "'"
                Rpt.DataDefinition.FormulaFields("Fdiaspp").Text = "'" & Plazopp & "'"
                Rpt.DataDefinition.FormulaFields("FFecha").Text = "'" & FechaPedido & "'"
                Rpt.DataDefinition.FormulaFields("Fobserva").Text = "'" & Observaciones & "'"
                '' calcular por orden de compra 
                Rpt.DataDefinition.FormulaFields("Fprs").Text = "'" & prs & "'"
                Rpt.DataDefinition.FormulaFields("FSubt").Text = "'" & Subt & "'"
                Rpt.DataDefinition.FormulaFields("Ftiva").Text = "'" & TIva & "'"
                Rpt.DataDefinition.FormulaFields("Fiva").Text = "'" & Iva & "'"
                Rpt.DataDefinition.FormulaFields("FTDesc").Text = "'" & TDscto & "'"
                Rpt.DataDefinition.FormulaFields("FTotal").Text = "'" & Total & "'"
                '' calcular por orden de compra 
                Rpt.DataDefinition.FormulaFields("FDscto01").Text = "'" & Dscto01 & "'"
                Rpt.DataDefinition.FormulaFields("FDscto02").Text = "'" & Dscto02 & "'"
                Rpt.DataDefinition.FormulaFields("FDscto03").Text = "'" & Dscto03 & "'"
                Rpt.DataDefinition.FormulaFields("FDscto04").Text = "'" & Dscto04 & "'"
                Rpt.DataDefinition.FormulaFields("FDscto05").Text = "'" & Dscto05 & "'"
                Cadena = ""
                If Dscto01.Length > 0 And Dscto01 <> "0" Then
                    Cadena = Dscto01
                End If
                If Dscto02.Length > 0 And Dscto02 <> "0" Then
                    Cadena = Cadena & " + " & Dscto02
                End If
                If Dscto03.Length > 0 And Dscto03 <> "0" Then
                    Cadena = Cadena & " + " & Dscto03
                End If
                If Dscto04.Length > 0 And Dscto04 <> "0" Then
                    Cadena = Cadena & " + " & Dscto04
                End If
                If Dscto05.Length > 0 And Dscto05 <> "0" Then
                    Cadena = Cadena & " + " & Dscto05
                End If

                Rpt.DataDefinition.FormulaFields("FDescuentos").Text = "'" & Cadena & "'"
                Rpt.DataDefinition.FormulaFields("FRealizo").Text = "'" & GLB_NomUsuario & "'"
                Rpt.DataDefinition.FormulaFields("FOrdecomp").Text = "'" & OrdeComp & "'"
                Rpt.DataDefinition.FormulaFields("IdFolioSuc").Text = "'" & IdFolioSuc & "'"
                'Rpt.SetDataSource(objDataSetPedidoNuevo.Tables(0))

                Dim objDataSet As Data.DataSet
                Using objMySqlGral As New BCL.BCLPersis(GLB_ConStringPerSis)
                    Try

                        objDataSet = objMySqlGral.usp_TraerDatosSucursal(Mid(OrdeComp, 1, 2))

                        If objDataSet.Tables(0).Rows.Count > 0 Then


                            Rpt.DataDefinition.FormulaFields("FDir1").Text = "'" & objDataSet.Tables(0).Rows(0).Item("sucursal").ToString & "'"
                            Rpt.DataDefinition.FormulaFields("FDir2").Text = "'" & objDataSet.Tables(0).Rows(0).Item("calle").ToString & "'"
                            Rpt.DataDefinition.FormulaFields("FDir3").Text = "'Col. " & objDataSet.Tables(0).Rows(0).Item("colonia").ToString & "'"
                            Rpt.DataDefinition.FormulaFields("FDir4").Text = "'" & objDataSet.Tables(0).Rows(0).Item("ciudad").ToString & ", " & objDataSet.Tables(0).Rows(0).Item("estado").ToString & ", " & objDataSet.Tables(0).Rows(0).Item("codpos").ToString & "'"
                            Rpt.DataDefinition.FormulaFields("FDir5").Text = "'" & "" & "'"
                            Rpt.DataDefinition.FormulaFields("FDir6").Text = "'" & "" & "'"

                            ''mientras
                            'Rpt.DataDefinition.FormulaFields("FDir1").Text = "'SUCURSAL: " & objDataSet.Tables(0).Rows(0).Item("sucursal").ToString & "'"
                            'Rpt.DataDefinition.FormulaFields("FDir2").Text = "'JUAN ANTONIO DE LA FUENTE 345 SUR'"
                            'Rpt.DataDefinition.FormulaFields("FDir3").Text = "'COL. CENTRO, C.P. 27000'"
                            'Rpt.DataDefinition.FormulaFields("FDir4").Text = "'TORREÓN, COAH.'"
                            'Rpt.DataDefinition.FormulaFields("FDir5").Text = "'" & "" & "'"
                            'Rpt.DataDefinition.FormulaFields("FDir6").Text = "'" & "" & "'"

                        End If


                    Catch ExceptionErr As Exception
                        MessageBox.Show(ExceptionErr.Message.ToString)
                    End Try
                End Using
                Rpt.SetDataSource(objDataSetPedidoNuevo)
                crReports.ReportSource = Rpt


            Case 34
                'RECIBO DE CEDI, DEVOLUCION por serie
                Dim Rpt As New rptReporteDevoSerieCedi

                Dim rptStream As New System.IO.MemoryStream
                Dim Cadena As String
                Rpt.DataDefinition.FormulaFields("fechafactura").Text = "'" & FechaFactura & "'"
                Rpt.DataDefinition.FormulaFields("folioentrada").Text = "'" & FolioEntrada & "'"
                Rpt.DataDefinition.FormulaFields("foliofactura").Text = "'" & FolioFactura & "'"
                Rpt.DataDefinition.FormulaFields("FM1").Text = "'" & TextoColumna(0) & "'"
                Rpt.DataDefinition.FormulaFields("FM2").Text = "'" & TextoColumna(1) & "'"
                Rpt.DataDefinition.FormulaFields("FM3").Text = "'" & TextoColumna(2) & "'"
                Rpt.DataDefinition.FormulaFields("FM4").Text = "'" & TextoColumna(3) & "'"
                Rpt.DataDefinition.FormulaFields("FM5").Text = "'" & TextoColumna(4) & "'"
                Rpt.DataDefinition.FormulaFields("FM6").Text = "'" & TextoColumna(5) & "'"
                Rpt.DataDefinition.FormulaFields("FM7").Text = "'" & TextoColumna(6) & "'"
                Rpt.DataDefinition.FormulaFields("FM8").Text = "'" & TextoColumna(7) & "'"
                Rpt.DataDefinition.FormulaFields("FM9").Text = "'" & TextoColumna(8) & "'"
                Rpt.DataDefinition.FormulaFields("FM10").Text = "'" & TextoColumna(9) & "'"
                Rpt.DataDefinition.FormulaFields("FM11").Text = "'" & TextoColumna(10) & "'"
                Rpt.DataDefinition.FormulaFields("FM12").Text = "'" & TextoColumna(11) & "'"
                Rpt.DataDefinition.FormulaFields("FM13").Text = "'" & TextoColumna(12) & "'"
                Rpt.DataDefinition.FormulaFields("FM14").Text = "'" & TextoColumna(13) & "'"
                Rpt.DataDefinition.FormulaFields("FMarca").Text = "'" & Marca & "'"
                Rpt.DataDefinition.FormulaFields("FRaz_Social").Text = "'" & Raz_Social & "'"
                Rpt.DataDefinition.FormulaFields("FVendedor").Text = "'" & Vendedor & "'"
                Rpt.DataDefinition.FormulaFields("Ftransporte").Text = "'" & Transporte & "'"
                Rpt.DataDefinition.FormulaFields("FDsctopp").Text = "'" & Dsctopp & "'"
                Rpt.DataDefinition.FormulaFields("Fdiaspp").Text = "'" & Plazopp & "'"
                Rpt.DataDefinition.FormulaFields("FFecha").Text = "'" & FechaPedido & "'"
                Rpt.DataDefinition.FormulaFields("Fobserva").Text = "'" & Observaciones & "'"
                '' calcular por orden de compra 
                Rpt.DataDefinition.FormulaFields("Fprs").Text = "'" & prs & "'"
                Rpt.DataDefinition.FormulaFields("FSubt").Text = "'" & Subt & "'"
                Rpt.DataDefinition.FormulaFields("Ftiva").Text = "'" & TIva & "'"
                Rpt.DataDefinition.FormulaFields("Fiva").Text = "'" & Iva & "'"
                Rpt.DataDefinition.FormulaFields("FTDesc").Text = "'" & TDscto & "'"
                Rpt.DataDefinition.FormulaFields("FTotal").Text = "'" & Total & "'"
                '' calcular por orden de compra 
                Rpt.DataDefinition.FormulaFields("FDscto01").Text = "'" & Dscto01 & "'"
                Rpt.DataDefinition.FormulaFields("FDscto02").Text = "'" & Dscto02 & "'"
                Rpt.DataDefinition.FormulaFields("FDscto03").Text = "'" & Dscto03 & "'"
                Rpt.DataDefinition.FormulaFields("FDscto04").Text = "'" & Dscto04 & "'"
                Rpt.DataDefinition.FormulaFields("FDscto05").Text = "'" & Dscto05 & "'"
                Cadena = ""
                If Dscto01.Length > 0 And Dscto01 <> "0" Then
                    Cadena = Dscto01
                End If
                If Dscto02.Length > 0 And Dscto02 <> "0" Then
                    Cadena = Cadena & " + " & Dscto02
                End If
                If Dscto03.Length > 0 And Dscto03 <> "0" Then
                    Cadena = Cadena & " + " & Dscto03
                End If
                If Dscto04.Length > 0 And Dscto04 <> "0" Then
                    Cadena = Cadena & " + " & Dscto04
                End If
                If Dscto05.Length > 0 And Dscto05 <> "0" Then
                    Cadena = Cadena & " + " & Dscto05
                End If

                Rpt.DataDefinition.FormulaFields("FDescuentos").Text = "'" & Cadena & "'"
                Rpt.DataDefinition.FormulaFields("FRealizo").Text = "'" & GLB_NomUsuario & "'"
                Rpt.DataDefinition.FormulaFields("FOrdecomp").Text = "'" & OrdeComp & "'"
                Rpt.DataDefinition.FormulaFields("IdFolioSuc").Text = "'" & IdFolioSuc & "'"
                'Rpt.SetDataSource(objDataSetPedidoNuevo.Tables(0))

                Dim objDataSet As Data.DataSet
                Using objMySqlGral As New BCL.BCLPersis(GLB_ConStringPerSis)
                    Try

                        objDataSet = objMySqlGral.usp_TraerDatosSucursal(Mid(OrdeComp, 1, 2))

                        If objDataSet.Tables(0).Rows.Count > 0 Then


                            Rpt.DataDefinition.FormulaFields("FDir1").Text = "'" & objDataSet.Tables(0).Rows(0).Item("sucursal").ToString & "'"
                            Rpt.DataDefinition.FormulaFields("FDir2").Text = "'" & objDataSet.Tables(0).Rows(0).Item("calle").ToString & "'"
                            Rpt.DataDefinition.FormulaFields("FDir3").Text = "'Col. " & objDataSet.Tables(0).Rows(0).Item("colonia").ToString & "'"
                            Rpt.DataDefinition.FormulaFields("FDir4").Text = "'" & objDataSet.Tables(0).Rows(0).Item("ciudad").ToString & ", " & objDataSet.Tables(0).Rows(0).Item("estado").ToString & ", " & objDataSet.Tables(0).Rows(0).Item("codpos").ToString & "'"
                            Rpt.DataDefinition.FormulaFields("FDir5").Text = "'" & "" & "'"
                            Rpt.DataDefinition.FormulaFields("FDir6").Text = "'" & "" & "'"

                            ''mientras
                            'Rpt.DataDefinition.FormulaFields("FDir1").Text = "'SUCURSAL: " & objDataSet.Tables(0).Rows(0).Item("sucursal").ToString & "'"
                            'Rpt.DataDefinition.FormulaFields("FDir2").Text = "'JUAN ANTONIO DE LA FUENTE 345 SUR'"
                            'Rpt.DataDefinition.FormulaFields("FDir3").Text = "'COL. CENTRO, C.P. 27000'"
                            'Rpt.DataDefinition.FormulaFields("FDir4").Text = "'TORREÓN, COAH.'"
                            'Rpt.DataDefinition.FormulaFields("FDir5").Text = "'" & "" & "'"
                            'Rpt.DataDefinition.FormulaFields("FDir6").Text = "'" & "" & "'"

                        End If


                    Catch ExceptionErr As Exception
                        MessageBox.Show(ExceptionErr.Message.ToString)
                    End Try
                End Using
                Rpt.SetDataSource(objDataSetPedidoNuevo)
                crReports.ReportSource = Rpt

            Case 40
                Dim Rpt As New rptChequeProvedor
                Rpt.SetDataSource(objDataSetChequeProveedores)
                crReports.ReportSource = Rpt


            Case 41
                Dim Rpt As New rptAnexoChequeProvedor
                Rpt.SetDataSource(objDataSetChequeProveedoresAnexos)
                crReports.ReportSource = Rpt



            Case 42
                Dim Rpt As New rptRecibo


                Dim rptStream As New System.IO.MemoryStream



                If InStr(GLB_ImpresoraPredeterminada, "movs") = 0 Then
                    Call PredeterminarImpresora(GLB_ImpresoraMovs)
                End If
                Rpt.DataDefinition.FormulaFields("r_Entrega").Text = "'" & r_Entrega & "'"
                Rpt.SetDataSource(objDataSetImprimeRecibo)
                If Sw_Pdf = False Then

                    crReports.ReportSource = Rpt
                    If InStr(GLB_ImpresoraPredeterminada, "movs") = 0 Then
                        Call PredeterminarImpresora(GLB_ImpresoraPredeterminada)
                    End If
                Else

                    Dim CrExportOptions As CrystalDecisions.Shared.ExportOptions
                    Dim CrDiskFileDestinationOptions As New CrystalDecisions.Shared.DiskFileDestinationOptions
                    Dim CrFormatTypeOptions As New CrystalDecisions.Shared.PdfRtfWordFormatOptions


                    CrDiskFileDestinationOptions.DiskFileName = RutaGuardarPedidoNuevo
                    CrExportOptions = Rpt.ExportOptions
                    With CrExportOptions
                        .ExportDestinationType = CrystalDecisions.Shared.ExportDestinationType.DiskFile
                        .ExportFormatType = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat
                        .DestinationOptions = CrDiskFileDestinationOptions
                        .FormatOptions = CrFormatTypeOptions

                    End With
                    Rpt.Export()

                    crReports.ReportSource = Rpt
                    '' TERMINA GENERAR EL ARCHIVO AHORA A ABRIRLO
                    'Shell(RutaGuardarPedidoNuevo)

                    ' Process.Start("AcroRd32.exe", RutaGuardarPedidoNuevo)


                    Me.Close()
                    Me.Dispose()

                End If



            Case 55
                Dim Rpt As New rptReciboImagen
                Rpt.SetDataSource(objDataSetImprimeReciboImagen)
                crReports.ReportSource = Rpt

            Case 30
                ' REPORTE DE Cobradores
                Dim Rpt As New rptReporteCobradores
                Rpt.SetDataSource(objDataSetReciboCobradores)


            Case 2301
                ' REPORTE DE Traspasos2
                Dim Rpt As New rptReporteTraspasosSalida

                If InStr(GLB_ImpresoraPredeterminada, "movs") = 0 Then
                    Call PredeterminarImpresora(GLB_ImpresoraMovs)
                End If


                Rpt.SetDataSource(objDataSetReporteTraspaso)
                crReports.ReportSource = Rpt

                If InStr(GLB_ImpresoraPredeterminada, "movs") = 0 Then
                    Call PredeterminarImpresora(GLB_ImpresoraPredeterminada)
                End If

            Case 21
                ' REPORTE DE Traspasos2
                Dim Rpt As New rptTraspasosRecibe


                If InStr(GLB_ImpresoraPredeterminada, "movs") = 0 Then
                    Call PredeterminarImpresora(GLB_ImpresoraMovs)
                End If



                Rpt.SetDataSource(objDataSetReporteTraspaso)
                crReports.ReportSource = Rpt


                If InStr(GLB_ImpresoraPredeterminada, "movs") = 0 Then
                    Call PredeterminarImpresora(GLB_ImpresoraPredeterminada)
                End If

            Case 2101
                ' REPORTE DE Traspasos2
                Dim Rpt As New rptTraspasosRecibeTDAS

                If InStr(GLB_ImpresoraPredeterminada, "movs") = 0 Then
                    Call PredeterminarImpresora(GLB_ImpresoraMovs)
                End If

                Rpt.SetDataSource(objDataSetReporteTraspaso)
                crReports.ReportSource = Rpt

                If InStr(GLB_ImpresoraPredeterminada, "movs") = 0 Then
                    Call PredeterminarImpresora(GLB_ImpresoraPredeterminada)
                End If

            Case 210102
                ' REPORTE DE Traspasos2
                Dim Rpt As New rptReporteTraspasosResAut

                If InStr(GLB_ImpresoraPredeterminada, "movs") = 0 Then
                    Call PredeterminarImpresora(GLB_ImpresoraMovs)
                End If

                Rpt.SetDataSource(objDataSetReporteTraspaso)
                crReports.ReportSource = Rpt

                If InStr(GLB_ImpresoraPredeterminada, "movs") = 0 Then
                    Call PredeterminarImpresora(GLB_ImpresoraPredeterminada)
                End If
            Case 20
                ' REPORTE DE Traspasos
                If InStr(GLB_ImpresoraPredeterminada, "movs") = 0 Then
                    Call PredeterminarImpresora(GLB_ImpresoraMovs)
                End If

                Dim Rpt As New rptReporteTraspasos





                Rpt.SetDataSource(objDataSetReporteTraspaso)
                crReports.ReportSource = Rpt

                If InStr(GLB_ImpresoraPredeterminada, "movs") = 0 Then
                    Call PredeterminarImpresora(GLB_ImpresoraPredeterminada)
                End If

            Case 2001
                ' REPORTE DE Traspasos
                Dim Rpt As New rptReporteTraspasos



                If InStr(GLB_ImpresoraPredeterminada, "movs") = 0 Then
                    Call PredeterminarImpresora(GLB_ImpresoraMovs)
                End If



                Rpt.SetDataSource(objDataSetReporteTraspaso)
                crReports.ReportSource = Rpt

                If InStr(GLB_ImpresoraPredeterminada, "movs") = 0 Then
                    Call PredeterminarImpresora(GLB_ImpresoraPredeterminada)
                End If



            Case 200940
                ' REPORTE DE Traspasos
                If InStr(GLB_ImpresoraPredeterminada, "movs") = 0 Then
                    Call PredeterminarImpresora(GLB_ImpresoraMovs)
                End If

                Dim Rpt As New rptReporteTraspasosVEL





                Rpt.SetDataSource(objDataSetReporteTraspaso)
                crReports.ReportSource = Rpt

                If InStr(GLB_ImpresoraPredeterminada, "movs") = 0 Then
                    Call PredeterminarImpresora(GLB_ImpresoraPredeterminada)
                End If

            Case 20010940
                ' REPORTE DE Traspasos
                Dim Rpt As New rptReporteTraspasosVEL



                If InStr(GLB_ImpresoraPredeterminada, "movs") = 0 Then
                    Call PredeterminarImpresora(GLB_ImpresoraMovs)
                End If



                Rpt.SetDataSource(objDataSetReporteTraspaso)
                crReports.ReportSource = Rpt

                If InStr(GLB_ImpresoraPredeterminada, "movs") = 0 Then
                    Call PredeterminarImpresora(GLB_ImpresoraPredeterminada)
                End If

        End Select
    End Sub

    Private Sub crReports_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles crReports.Load

    End Sub
End Class