Public Class BCLio
    'mreyes 22/Febrero/2012 12:46 p.m.
    Implements IDisposable
    Private objDALio As DAL.Dalio
    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALio = New DAL.Dalio(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALio.Dispose()
            objDALio = Nothing
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
    Public Function pub_ArmarNombreFotoDocs(ByVal Ruta As String, ByVal strID As String, ByVal Tipo As Integer, ByVal NoFoto As String) As String
        'Ro.Mtz 08-04-13 
        Try
            'Call the data component to get all groups
            pub_ArmarNombreFotoDocs = objDALio.pub_ArmarNombreFotoDocs(Ruta, strID, Tipo, NoFoto)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function pub_CrearDirectorioChequesLiquidacion(ByVal Ruta As String, ByVal Anio As String, ByVal Mes As String, ByVal Prov As String, ByVal Liquidacion As String) As Boolean
        'Tony Garcia - 28/Junio/2013 11:40 a.m.
        Try
            'Call the data component to get all groups
            pub_CrearDirectorioChequesLiquidacion = objDALio.pub_CrearDirectorioChequesLiquidacion(Ruta, Anio, Mes, Prov, Liquidacion)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function pub_ArmarNombreFotoFicha(ByVal Ruta As String, ByVal strReferenc As String) As String
        'Tony Garcia - 26/Junio/2013 07:00 p.m.
        Try
            'Call the data component to get all groups
            pub_ArmarNombreFotoFicha = objDALio.pub_ArmarNombreFotoFicha(Ruta, strReferenc)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function pub_ArmarNombreFirmaDistribuidor(ByVal Ruta As String, ByVal strIDDsitrib As String) As String
        'Tony Garcia - 23/Marzo/2012 11:00 a.m.
        Try
            'Call the data component to get all groups
            pub_ArmarNombreFirmaDistribuidor = objDALio.pub_ArmarNombreFirmaDistribuidor(Ruta, strIDDsitrib)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function pub_CrearDirectorio(ByVal Ruta As String) As Boolean
        'mreyes 22/Febrero/2012 12:46 p.m.
        Try
            'Call the data component to get all groups
            pub_CrearDirectorio = objDALio.pub_CrearDirectorio(Ruta)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function pub_CrearDirectorioMarca(ByVal Ruta As String, ByVal ResurtSN As String, ByVal Marca As String, ByVal Anio As String, ByVal Mes As String, ByVal Tipo As String) As Boolean
        'mreyes 22/Febrero/2012 12:46 p.m.
        Try
            'Call the data component to get all groups
            pub_CrearDirectorioMarca = objDALio.pub_CrearDirectorioMarca(Ruta, ResurtSN, Marca, Anio, Mes, Tipo)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function pub_CrearDirectorioRemisionProv(ByVal Ruta As String, ByVal Anio As String, ByVal Mes As String, ByVal Prov As String) As Boolean
        'Tony Garcia - 28/Junio/2013 11:40 a.m.
        Try
            'Call the data component to get all groups
            pub_CrearDirectorioRemisionProv = objDALio.pub_CrearDirectorioRemisionProv(Ruta, Anio, Mes, Prov)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function pub_EnviarCorreo(ByVal SmtpClient As String, ByVal CorreoCompras As String, ByVal PassCorreoCompras As String, ByVal Correos As String, ByVal Asunto As String, ByVal Mensaje As String, ByVal Archivo As String) As Boolean
        'mreyes 28/Febrero/2012 04:39 p.m.

        pub_EnviarCorreo = objDALio.pub_EnviarCorreo(SmtpClient, CorreoCompras, PassCorreoCompras, Correos, Asunto, Mensaje, Archivo)

    End Function

    Public Function pub_ExisteArchivo(ByVal Ruta As String) As Boolean
        'mreyes 02/Marzo/2012 04:30 p.m.
        Try
            'Call the data component to get all groups
            pub_ExisteArchivo = objDALio.pub_ExisteArchivo(Ruta)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function pub_DirectorioExiste(ByVal Ruta As String) As Boolean
        'mreyes 08/Marzo/2012 12:17 p.m.
        Try
            'Call the data component to get all groups
            pub_DirectorioExiste = objDALio.pub_DirectorioExiste(Ruta)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function pub_RenombrarArchivo(ByVal Archivo As String, ByVal NuevoNombre As String) As Boolean
        'mreyes 08/Marzo/2012 12:17 p.m.
        Try
            'Call the data component to get all groups
            pub_RenombrarArchivo = objDALio.pub_RenombrarArchivo(Archivo, NuevoNombre)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function pub_ArmarNombreFotoEstilo(ByVal Ruta As String, ByVal Marca As String, ByVal Estilon As String, ByVal NoFoto As String) As String
        'mreyes 02/Marzo/2012 04:32 p.m.
        Try
            'Call the data component to get all groups
            pub_ArmarNombreFotoEstilo = objDALio.pub_ArmarNombreFotoEstilo(Ruta, Marca, Estilon, NoFoto)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function pub_ArmarNombreBulto(ByVal Ruta As String, ByVal idFolio As Integer, ByVal Tipo As Integer) As String

        Try
            'Call the data component to get all groups
            pub_ArmarNombreBulto = objDALio.pub_ArmarNombreBulto(Ruta, idFolio, Tipo)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function pub_ArmarNombreFotoEmpleado(ByVal Ruta As String, ByVal strIDEmpleado As String) As String
        'miguel pérez 03/Septiembre/2012 06:54 p.m.
        Try
            'Call the data component to get all groups
            pub_ArmarNombreFotoEmpleado = objDALio.pub_ArmarNombreFotoEmpleado(Ruta, strIDEmpleado)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    ''File.Copy(openFileDialog1.FileName, destino)

    Public Function pub_CopiarArchivo(ByVal RutaOrigen As String, ByVal RutaDestino As String) As String
        'mreyes 02/Marzo/2012 05:28 p.m.
        Try
            'Call the data component to get all groups
            pub_CopiarArchivo = objDALio.pub_CopiarArchivo(RutaOrigen, RutaDestino)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function pub_ExtensionArchivo(ByVal Archivo As String) As String
        'mreyes 03/Marzo/2012 09:34 a.m.

        Try
            'Call the data component to get all groups
            pub_ExtensionArchivo = objDALio.pub_ExtensionArchivo(Archivo)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try


    End Function


    Public Function pub_NombreArchivo(ByVal Archivo As String) As String
        'mreyes 26/Marzo/2012 05:44 a.m.

        Try
            'Call the data component to get all groups
            pub_NombreArchivo = objDALio.pub_NombreArchivo(Archivo)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try


    End Function
    Public Function pub_EliminarArchivo(ByVal Archivo As String) As Boolean
        'mreyes 03/Marzo/2012 11:54 a.m.

        Try
            'Call the data component to get all groups
            pub_EliminarArchivo = objDALio.pub_EliminarArchivo(Archivo)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try


    End Function

   
#End Region
End Class
