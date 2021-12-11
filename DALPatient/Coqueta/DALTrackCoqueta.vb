Imports System.Data.Odbc


Public Class DALTrackCoqueta
    Inherits DALOdbc
#Region "Constructor And Destructor"
    Sub New(ByVal ConString As String)
        MyBase.New(ConString)
    End Sub

    Public Shadows Sub Dispose()
        MyBase.Dispose()
    End Sub
#End Region

#Region " Public Role Functions "


    Public Function usp_TraerCantidadCorridas(ByVal Marca As String, ByVal Estilon As String, ByVal Corrida As String) As DataSet
        'miguel pérez 11/Septiembre/2012 09:33 a.m.
        Try
            usp_TraerCantidadCorridas = New DataSet
            MyBase.SQL = "CALL usp_TraerCantidadCorridas(?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@EstilonB", OdbcType.Char, 7, Estilon)
            MyBase.AddParameter("@CorridaB", OdbcType.Char, 1, Corrida)

            MyBase.FillDataSet(usp_TraerCantidadCorridas, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerTrackCta(ByVal EstiloN As String, ByVal EstiloF As String, ByVal Medida As String) As DataSet
        'miguel pérez 12/Septiembre/2012 09:40 a.m.
        Try
            usp_TraerTrackCta = New DataSet
            MyBase.SQL = "CALL usp_TraerTrackCta(?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@EstilonB", OdbcType.Char, 7, EstiloN)
            MyBase.AddParameter("@EstilofB", OdbcType.Char, 7, EstiloF)
            MyBase.AddParameter("@MedidaB", OdbcType.Char, 4, Medida)

            MyBase.FillDataSet(usp_TraerTrackCta, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ActualizarTrackCta(ByVal sku As String, ByVal EstiloN As String, ByVal EstiloF As String, ByVal Medida As String, ByVal Estatus As String) As Boolean
        'miguel pérez 12/Septiembre/2012 12:07 p.m.
        Try
            MyBase.SQL = "CALL usp_ActualizarTrackCta(?,?,?,?,?)"
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.AddParameter("@skuB", OdbcType.Char, 15, sku)
            MyBase.AddParameter("@EstiloNB", OdbcType.Char, 7, EstiloN)
            MyBase.AddParameter("@EstilofB", OdbcType.Char, 10, EstiloF)
            MyBase.AddParameter("@MedidaB", OdbcType.Char, 4, Medida)
            MyBase.AddParameter("@EstatusB", OdbcType.Char, 1, Estatus)

            usp_ActualizarTrackCta = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaTrackCta(ByVal sku As String, ByVal EstiloN As String, ByVal EstiloF As String, ByVal Medida As String, ByVal Estatus As String) As Boolean
        'miguel pérez 12/Septiembre/2012 1:07 p.m.
        Try
            MyBase.SQL = "CALL usp_CapturaTrackCta(?,?,?,?,?)"
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.AddParameter("@skuB", OdbcType.Char, 15, sku)
            MyBase.AddParameter("@EstiloNB", OdbcType.Char, 7, EstiloN)
            MyBase.AddParameter("@EstilofB", OdbcType.Char, 10, EstiloF)
            MyBase.AddParameter("@MedidaB", OdbcType.Char, 4, Medida)
            MyBase.AddParameter("@EstatusB", OdbcType.Char, 1, Estatus)

            usp_CapturaTrackCta = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerSKU(ByVal sku As String) As DataSet
        'miguel pérez 12/Septiembre/2012 04:30 p.m.
        Try
            usp_TraerSKU = New DataSet
            MyBase.SQL = "CALL usp_TraerSKU(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@EstilonB", OdbcType.Char, 13, sku)

            MyBase.FillDataSet(usp_TraerSKU, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

#End Region
End Class
