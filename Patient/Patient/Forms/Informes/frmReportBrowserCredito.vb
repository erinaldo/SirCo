Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO

Public Class frmReportBrowserCredito

    Public ReportIndex As Integer
    Public Shared FilterIndex As Byte
    Public Shared FilterName As String
    Public Shared FechaIni As DateTime
    Public Shared FechaFin As DateTime
    Public Shared Nomina_Id As Integer
    Private objPatientDataSet As DataSet

    Private FilterStr As String
    Public SelectPatientId As String

    'juan 6:20 1/marzo/2013
    Public objDataSetRelacion As DSPpalRelacion
    'Public objDataSetRelacionNueva As DSPpalRelacionNueva

    ''ROBERTO 12:20 5/marzo/2013
    'Public objDataSetImprimeRecibo As DSPpalRecibo
    'Public objDataSetImprimeReciboImagen As DSPpalReciboImagen
    'Public objDataSetReporteDistribuidor As DSPReporteDistrib
    Public objDataSetReporteVentas As DSPReporteVentas2
    Public objDataSetReporteEstadoCuentas As DSPReporteEstadoCuentas

    'juan 6:20 16/mayo/2013
    Public objDataSetReporte As DSPpalReporteCuentas

    'juan 6:20 16/mayo/2013
    'Public objDataSetReporte_Detallado As DSPPpalReporteCobranzaMensual

    ''juan 11:03 21/mayo/2013
    'Public objDataSetReporte_Abonos As DSPPpalReporteCobranzaMensual

    ''juan 11:03 21/mayo/2013
    'Public objDataSetReporte_Abonos_Detallado As DSPPpalReporteCobranzaMensual

    'juan 1:47 28/mayo/2013
    Public objDataSetReporte_Cuentas As DSPpalReporteCuentas
    Public objDataSetReporte_Cuentas_Detallado As DSPpalReporteCuentas

    Public RutaGuardarRelacion As String = ""
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

    Private Sub frmReportBrowserCredito_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Select Case ReportIndex
            Case 11
                Dim Rpt As New rptPpalRelacion

                Rpt.SetDataSource(objDataSetRelacion)
                crReports.ReportSource = Rpt

                'Case 12
                '    Dim Rpt As New rptPpalRecibo

                '    Rpt.SetDataSource(objDataSetImprimeRecibo)
                '    crReports.ReportSource = Rpt

                'Case 14
                '    Dim Rpt As New rptPpalReciboImagen
                '    Rpt.SetDataSource(objDataSetImprimeReciboImagen)
                '    crReports.ReportSource = Rpt

                '    ' juangalvan 24-abril-2013
                '    ' Imprimir NUEVAS RELACIONES
                'Case 15
                '    Dim Rpt As New rptPpalRelacionNueva
                '    Rpt.SetDataSource(objDataSetRelacionNueva)
                '    crReports.ReportSource = Rpt

                ' juan galvan 16-mayo-2013
            Case 17
                Dim Rpt As New rptPpalReporteAntiguedadSaldos
                Rpt.SetDataSource(objDataSetReporte)
                crReports.ReportSource = Rpt

                ' juan galvan 20-mayo-2013
                'Case 18
                '    Dim Rpt As New rptPpalReporteCobranza_Detalle
                '    Rpt.SetDataSource(objDataSetReporte_Detallado)
                '    crReports.ReportSource = Rpt

                '    ' juan galvan 21-mayo-2013
                'Case 20
                '    Dim Rpt As New rptPpalReporteAbonosSucursal_Detalle
                '    Rpt.SetDataSource(objDataSetReporte_Abonos_Detallado)
                '    crReports.ReportSource = Rpt

                '    ' juan galvan 21-mayo-2013
                'Case 19
                '    Dim Rpt As New rptPpalReporteAbonosSucursal
                '    Rpt.SetDataSource(objDataSetReporte_Abonos)
                '    crReports.ReportSource = Rpt

                ' juan galvan 21-mayo-2013
                'Case 22
                '    Dim Rpt As New rptPpalReporteCuentas_Detallado
                '    Rpt.SetDataSource(objDataSetReporte_Cuentas_Detallado)
                '    crReports.ReportSource = Rpt
            Case 23
                Dim Rpt As New rptPpalReporteCuentas
                Rpt.SetDataSource(objDataSetReporte_Cuentas)
                crReports.ReportSource = Rpt



            Case 33
                Dim Rpt As New rptReporteVentas
                Rpt.SetDataSource(objDataSetReporteVentas)
                crReports.ReportSource = Rpt
            Case 34
                Dim Rpt As New rptReporteVentasDet1
                Rpt.SetDataSource(objDataSetReporteVentas)
                crReports.ReportSource = Rpt

            Case 35
                Dim Rpt As New rptReporteVentasDet2
                Rpt.SetDataSource(objDataSetReporteVentas)
                crReports.ReportSource = Rpt
            Case 36
                Dim Rpt As New rptPalReporteEstadoCuentas
                Rpt.SetDataSource(objDataSetReporteEstadoCuentas)
                crReports.ReportSource = Rpt

                'Case 24
                '    Dim Rpt As New rprReporteDistribuidores
                '    Rpt.SetDataSource(objDataSetReporteDistribuidor)
                '    crReports.ReportSource = Rpt

                'Case 50
                '    Dim Rpt As New rptPorcentDistrib
                '    Rpt.SetDataSource(objDataSetReporteDistribuidor)
                '    crReports.ReportSource = Rpt
                'Case 51
                '    Dim Rpt As New rptLimiteCredito
                '    Rpt.SetDataSource(objDataSetReporteDistribuidor)
                '    crReports.ReportSource = Rpt
                'Case 52
                '    Dim Rpt As New rptLimiteCredito2
                '    Rpt.SetDataSource(objDataSetReporteDistribuidor)
                '    crReports.ReportSource = Rpt


        End Select

    End Sub

    Private Sub crReports_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles crReports.Load

    End Sub
End Class