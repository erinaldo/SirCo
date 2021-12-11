Public Class BCLTrackCoqueta

    Implements IDisposable
    Private objDALTrackCoqueta As DAL.DALTrackCoqueta
    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALTrackCoqueta = New DAL.DALTrackCoqueta(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALTrackCoqueta.Dispose()
            objDALTrackCoqueta = Nothing
            ' TODO: free shared unmanaged resources
        End If
        Me.disposedValue = True
    End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region
#Region " Public Section Functions "

    Public Function usp_TraerCantidadCorridas(ByVal Marca As String, ByVal Estilon As String, ByVal Corrida As String) As DataSet
        'miguel pérez 11/Septiembre/2012 09:35 a.m.

        Try
            'Call the data component to get all groups
            usp_TraerCantidadCorridas = objDALTrackCoqueta.usp_TraerCantidadCorridas(Marca, Estilon, Corrida)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerTrackCta(ByVal Marca As String, ByVal Estilon As String, ByVal Corrida As String) As DataSet
        'miguel pérez 11/Septiembre/2012 09:43 a.m.

        Try
            'Call the data component to get all groups
            usp_TraerTrackCta = objDALTrackCoqueta.usp_TraerTrackCta(Marca, Estilon, Corrida)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ActualizarTrackCta(ByVal EstiloN As String, ByVal EstiloF As String, ByVal Medida As String, ByVal Estatus As String) As Boolean
        'miguel pérez 12/Septiembre/2012 12:26 p.m.

        Try
            'Call the data component to get all groups
            usp_ActualizarTrackCta = objDALTrackCoqueta.usp_ActualizarTrackCta(EstiloN, EstiloF, Medida, Estatus)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaTrackCta(ByVal sku As String, ByVal EstiloN As String, ByVal EstiloF As String, ByVal Medida As String, ByVal Estatus As String) As Boolean
        'miguel pérez 12/Septiembre/2012 1:10 p.m.

        Try
            'Call the data component to get all groups
            usp_CapturaTrackCta = objDALTrackCoqueta.usp_CapturaTrackCta(sku, EstiloN, EstiloF, Medida, Estatus)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerSKU(ByVal sku As String) As DataSet
        'miguel pérez 11/Septiembre/2012 09:43 a.m.

        Try
            'Call the data component to get all groups
            usp_TraerSKU = objDALTrackCoqueta.usp_TraerSKU(sku)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerLayoutCTA(ByVal Fecha As String, ByVal Sucursal As String) As DataSet
        'miguel pérez 13/Septiembre/2012 05:43 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerLayoutCTA = objDALTrackCoqueta.usp_TraerLayoutCTA(Fecha, Sucursal)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TiendasCTA(ByVal Sucursal As String, ByVal Tienda As String) As DataSet
        'miguel pérez 14/Septiembre/2012 05:01 p.m.
        Try
            'Call the data component to get all groups
            usp_TiendasCTA = objDALTrackCoqueta.usp_TiendasCTA(Sucursal, Tienda)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerDescripTrackCTA(ByVal Sku As String) As DataSet
        'miguel pérez 24/Septiembre/2012 12:01 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerDescripTrackCTA = objDALTrackCoqueta.usp_TraerDescripTrackCTA(Sku)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaArchivosCta(ByVal Archivo As String, ByVal OrdenCompra As String, ByVal Sucursal As String) As Boolean
        'miguel pérez 27/Septiembre/2012 5:10 p.m.

        Try
            'Call the data component to get all groups
            usp_CapturaArchivosCta = objDALTrackCoqueta.usp_CapturaArchivosCta(Archivo, OrdenCompra, Sucursal)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerArchivosCTA(ByVal Archivo As String) As DataSet
        'miguel pérez 27/Septiembre/2012 05:31 a.m.

        Try
            'Call the data component to get all groups
            usp_TraerArchivosCTA = objDALTrackCoqueta.usp_TraerArchivosCTA(Archivo)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

#End Region
End Class
