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


    Public Function usp_TraerTrackCta(ByVal Marca As String, ByVal Estilon As String, ByVal Corrida As String) As DataSet
        'miguel pérez 12/Septiembre/2012 09:40 a.m.
        Try
            usp_TraerTrackCta = New DataSet
            MyBase.SQL = "CALL usp_TraerTrackCta(?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@EstilonB", OdbcType.Char, 7, Estilon)
            MyBase.AddParameter("@CorridaB", OdbcType.Char, 1, Corrida)

            MyBase.FillDataSet(usp_TraerTrackCta, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ActualizarTrackCta(ByVal EstiloN As String, ByVal EstiloF As String, ByVal Medida As String, ByVal Estatus As String) As Boolean
        'miguel pérez 12/Septiembre/2012 12:07 p.m.
        Try
            MyBase.SQL = "CALL usp_ActualizarTrackCta(?,?,?,?)"
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.AddParameter("@EstiloNB", OdbcType.Char, 7, EstiloN)
            MyBase.AddParameter("@EstilofB", OdbcType.Char, 14, EstiloF)
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

    Public Function usp_TraerLayoutCTA(ByVal Fecha As String, ByVal Sucursal As String) As DataSet
        'miguel pérez 13/Septiembre/2012 05:33 p.m.
        Try
            usp_TraerLayoutCTA = New DataSet
            MyBase.SQL = "CALL usp_TraerLayoutCTA(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@FechaB", OdbcType.Char, 10, Fecha)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.FillDataSet(usp_TraerLayoutCTA, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TiendasCTA(ByVal Sucursal As String, ByVal Tienda As String) As DataSet
        'miguel pérez 14/Septiembre/2012 05:00 p.m.
        Try
            usp_TiendasCTA = New DataSet
            MyBase.SQL = "CALL usp_TiendasCTA(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@TiendaB", OdbcType.Char, 6, Tienda)
            MyBase.FillDataSet(usp_TiendasCTA, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerDescripTrackCTA(ByVal Sku As String) As DataSet
        'miguel pérez 24/Septiembre/2012 12:00 p.m.
        Try
            usp_TraerDescripTrackCTA = New DataSet
            MyBase.SQL = "CALL usp_TraerDescripTrackCTA(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@skuB", OdbcType.Char, 13, sku)
            MyBase.FillDataSet(usp_TraerDescripTrackCTA, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaArchivosCta(ByVal Archivo As String, ByVal OrdenCompra As String, ByVal Sucursal As String) As Boolean
        'miguel pérez 27/Septiembre/2012 5:07 p.m.
        Try
            MyBase.SQL = "CALL usp_CapturaArchivosCta(?,?,?)"
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.AddParameter("@ArchivoB", OdbcType.Char, 19, Archivo)
            MyBase.AddParameter("@OrdeCompB", OdbcType.Char, 6, OrdenCompra)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)

            usp_CapturaArchivosCta = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerArchivosCTA(ByVal Archivo As String) As DataSet
        'miguel pérez 24/Septiembre/2012 5:30 p.m.
        Try
            usp_TraerArchivosCTA = New DataSet
            MyBase.SQL = "CALL usp_TraerArchivosCTA(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@ArchivoB", OdbcType.Char, 19, Archivo)
            MyBase.FillDataSet(usp_TraerArchivosCTA, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

#End Region
End Class
