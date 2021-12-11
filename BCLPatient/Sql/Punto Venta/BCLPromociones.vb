

Public Class BCLPromociones

    Implements IDisposable
    Private objDALPromociones As DAL.DALPromociones
    Private disposedValue As Boolean = False        ' To detect redundant calls

#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALPromociones = New DAL.DALPromociones(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then

                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALPromociones.Dispose()
            objDALPromociones = Nothing
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

    Public Function usp_TraerPromocion(ByVal IdPromocion As Integer, ByVal Estatus As String) As DataSet
        'miguelperez 20/Febrero/2019   
        Try
            usp_TraerPromocion = objDALPromociones.usp_TraerPromocion(IdPromocion, Estatus)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerPromocionAgrupacion(ByVal IdPromocion As Integer) As DataSet
        'miguelperez 20/Febrero/2019   
        Try
            usp_TraerPromocionAgrupacion = objDALPromociones.usp_TraerPromocionAgrupacion(IdPromocion)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaPromocion(ByVal Nombre As String, ByVal Tipo As String, ByVal IniPromo As DateTime, ByVal FinPromo As DateTime, ByVal Preciero As String, ByVal Señalizador As String, ByVal Clasificacion As String, ByVal MinUniCompra As Integer, ByVal MinImpCompra As Decimal, ByVal UniPromo As Integer, ByVal Acumulable As String, ByVal ParesUnicos As String, ByVal CliNoRegis As String, ByVal IdUsuario As String, ByVal Imagen() As Byte) As DataSet
        'miguelperez 21/Febrero/2018    
        Try
            usp_CapturaPromocion = objDALPromociones.usp_CapturaPromocion(Nombre, Tipo, IniPromo, FinPromo, Preciero, Señalizador, Clasificacion, MinUniCompra, MinImpCompra, UniPromo, Acumulable, ParesUnicos, CliNoRegis, IdUsuario, Imagen)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ModificaPromocion(ByVal IdPromocion As Integer, ByVal Nombre As String, ByVal Estatus As String, ByVal IniPromo As DateTime, ByVal FinPromo As DateTime, ByVal Preciero As String, ByVal Señalizador As String, ByVal Clasificacion As String, ByVal MinUniCompra As Integer, ByVal MinImpCompra As Decimal, ByVal UniPromo As Integer, ByVal Acumulable As String, ByVal ParesUnicos As String, ByVal CliNoRegis As String, ByVal IdUsuario As String, ByVal Imagen() As Byte) As Boolean
        'miguelperez 21/Febrero/2018     
        Try
            usp_ModificaPromocion = objDALPromociones.usp_ModificaPromocion(IdPromocion, Nombre, Estatus, IniPromo, FinPromo, Preciero, Señalizador, Clasificacion, MinUniCompra, MinImpCompra, UniPromo, Acumulable, ParesUnicos, CliNoRegis, IdUsuario, Imagen)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerUsuFumPromocionesDet(ByVal IdPromocion As Integer) As DataSet
        'miguelperez 22/Febrero/2019   
        Try
            usp_TraerUsuFumPromocionesDet = objDALPromociones.usp_TraerUsuFumPromocionesDet(IdPromocion)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerPromocionDet(ByVal IdPromocion As Integer, ByVal NumUnidad As Integer, ByVal Tipo As String, ByVal FormaPago As String) As DataSet
        'miguelperez 22/Febrero/2019   
        Try
            usp_TraerPromocionDet = objDALPromociones.usp_TraerPromocionDet(IdPromocion, NumUnidad, Tipo, FormaPago)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaPromocionDet(ByVal IdPromocion As Integer, ByVal FormaPago As String, ByVal NumUnidad As Integer, ByVal Tipo As String, ByVal ImpFijo As Decimal, ByVal DescDirecto As Decimal, ByVal PorcDinElec As Decimal, ByVal ImpBono As Decimal, ByVal IdUsuario As String) As Boolean
        'miguelperez 26/Febrero/2018       
        Try
            usp_CapturaPromocionDet = objDALPromociones.usp_CapturaPromocionDet(IdPromocion, FormaPago, NumUnidad, Tipo, ImpFijo, DescDirecto, PorcDinElec, ImpBono, IdUsuario)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ModificaPromocionDet(ByVal IdPromocion As Integer, ByVal FormaPago As String, ByVal NumUnidad As Integer, ByVal Tipo As String, ByVal ImpFijo As Decimal, ByVal DescDirecto As Decimal, ByVal PorcDinElec As Decimal, ByVal ImpBono As Decimal, ByVal IdUsuario As String) As Boolean
        'miguelperez 26/Febrero/2018       
        Try
            usp_ModificaPromocionDet = objDALPromociones.usp_ModificaPromocionDet(IdPromocion, FormaPago, NumUnidad, Tipo, ImpFijo, DescDirecto, PorcDinElec, ImpBono, IdUsuario)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaPromocionAgrupacion(ByVal IdPromocion As Integer, ByVal IdAgrupacionCompra As Integer, ByVal IdAgrupacionPromo As Integer, ByVal IdUsuario As String) As Boolean
        'miguelperez 26/Febrero/2018        
        Try
            usp_CapturaPromocionAgrupacion = objDALPromociones.usp_CapturaPromocionAgrupacion(IdPromocion, IdAgrupacionCompra, IdAgrupacionPromo, IdUsuario)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_BuscaPromocionAgrupacion(ByVal IdPromocion As Integer, ByVal IdAgrupacionCompra As Integer, ByVal IdAgrupacionPromo As Integer) As DataSet
        'miguelperez 26/Febrero/2018        
        Try
            usp_BuscaPromocionAgrupacion = objDALPromociones.usp_BuscaPromocionAgrupacion(IdPromocion, IdAgrupacionCompra, IdAgrupacionPromo)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerCuponesPromocion(ByVal IdPromocion As Integer, ByVal Tipo As String) As DataSet
        'miguelperez 27/Febrero/2019         
        Try
            usp_TraerCuponesPromocion = objDALPromociones.usp_TraerCuponesPromocion(IdPromocion, Tipo)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaPromocionCupon(ByVal IdPromocion As Integer, ByVal IdCupon As Integer, ByVal IdUsuario As String) As Boolean
        'miguelperez 27/Febrero/2018          
        Try
            usp_CapturaPromocionCupon = objDALPromociones.usp_CapturaPromocionCupon(IdPromocion, IdCupon, IdUsuario)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_EliminaPromocionCupon(ByVal IdPromocion As Integer, ByVal IdCupon As Integer) As Boolean
        'miguelperez 27/Febrero/2018          
        Try
            usp_EliminaPromocionCupon = objDALPromociones.usp_EliminaPromocionCupon(IdPromocion, IdCupon)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerPromocionRecurrencia(ByVal IdPromocion As Integer, ByVal Dia As String, ByVal HoraIni As String, ByVal HoraFin As String) As DataSet
        'miguelperez 27/Febrero/2019         
        Try
            usp_TraerPromocionRecurrencia = objDALPromociones.usp_TraerPromocionRecurrencia(IdPromocion, Dia, HoraIni, HoraFin)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaPromocionRecurrencia(ByVal IdPromocion As Integer, ByVal Dia As String, ByVal HoraIni As String, ByVal HoraFin As String, ByVal IdUsuario As String) As Boolean
        'miguelperez 27/Febrero/2018          
        Try
            usp_CapturaPromocionRecurrencia = objDALPromociones.usp_CapturaPromocionRecurrencia(IdPromocion, Dia, HoraIni, HoraFin, IdUsuario)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_EliminaPromocionRecurrencia(ByVal IdPromocion As Integer, ByVal Dia As String, ByVal HoraIni As String) As Boolean
        'miguelperez 27/Febrero/2018         
        Try
            usp_EliminaPromocionRecurrencia = objDALPromociones.usp_EliminaPromocionRecurrencia(IdPromocion, Dia, HoraIni)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerPromocionesExclusiones(ByVal IdPromocion As Integer) As DataSet
        'miguelperez 27/Febrero/2019          
        Try
            usp_TraerPromocionesExclusiones = objDALPromociones.usp_TraerPromocionesExclusiones(IdPromocion)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaPromocionesExclusiones(ByVal IdPromocion As Integer, ByVal Marca As String, ByVal Estilon As String, ByVal IdUsuario As String) As Boolean
        'miguelperez 27/Febrero/2018         
        Try
            usp_CapturaPromocionesExclusiones = objDALPromociones.usp_CapturaPromocionesExclusiones(IdPromocion, Marca, Estilon, IdUsuario)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_EliminaPromocionExclusion(ByVal IdPromocion As Integer, ByVal Marca As String, ByVal Estilon As String) As Boolean
        'miguelperez 27/Febrero/2018          
        Try
            usp_EliminaPromocionExclusion = objDALPromociones.usp_EliminaPromocionExclusion(IdPromocion, Marca, Estilon)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerPlazasSucursales(ByVal Tipo As String, Plaza As Integer) As DataSet
        'miguelperez 27/Febrero/2019         
        Try
            usp_TraerPlazasSucursales = objDALPromociones.usp_TraerPlazasSucursales(Tipo, Plaza)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerPromocionesPlazas(ByVal IdPromocion As Integer, ByVal Plaza As String, ByVal Sucursal As String) As DataSet
        'miguelperez 27/Febrero/2019          
        Try
            usp_TraerPromocionesPlazas = objDALPromociones.usp_TraerPromocionesPlazas(IdPromocion, Plaza, Sucursal)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerPromocionesRestricciones(ByVal Id As Integer, ByVal Tipo As String) As DataSet
        'miguelperez 27/Febrero/2019          
        Try
            usp_TraerPromocionesRestricciones = objDALPromociones.usp_TraerPromocionesRestricciones(Id, Tipo)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaRestriccion(ByVal Id As Integer, ByVal Tipo As String, ByVal Descripcion As String, ByVal Imagen() As Byte, ByVal Prioridad As Integer, ByVal IdUsuario As String) As Boolean
        'miguelperez 27/Febrero/2018          
        Try
            usp_CapturaRestriccion = objDALPromociones.usp_CapturaRestriccion(Id, Tipo, Descripcion, Imagen, Prioridad, IdUsuario)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ModificaPrioridad(ByVal Id As Integer, ByVal Tipo As String, ByVal NuevaPrioridad As Integer, ByVal Clasificacion As String, ByVal IdUsuario As String) As Boolean
        'miguelperez 27/Febrero/2018           
        Try
            usp_ModificaPrioridad = objDALPromociones.usp_ModificaPrioridad(Id, Tipo, NuevaPrioridad, Clasificacion, IdUsuario)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_EliminaRestricciones(ByVal Id As Integer, ByVal Tipo As String, ByVal Prioridad As Integer) As Boolean
        'miguelperez 27/Febrero/2018           
        Try
            usp_EliminaRestricciones = objDALPromociones.usp_EliminaRestricciones(Id, Tipo, Prioridad)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_BuscaPromocionesPlazas(ByVal IdPromocion As Integer, ByVal Plaza As String) As DataSet
        'miguelperez 27/Febrero/2019          
        Try
            usp_BuscaPromocionesPlazas = objDALPromociones.usp_BuscaPromocionesPlazas(IdPromocion, Plaza)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaPromocionesPlazas(ByVal IdPromocion As Integer, ByVal Plaza As String, ByVal Sucursal As String, ByVal IdUsuario As String) As Boolean
        'miguelperez 27/Febrero/2018          
        Try
            usp_CapturaPromocionesPlazas = objDALPromociones.usp_CapturaPromocionesPlazas(IdPromocion, Plaza, Sucursal, IdUsuario)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_EliminaPromocionesPlaza(ByVal IdPromocion As Integer, ByVal Plaza As String, ByVal Sucursal As String) As Boolean
        'miguelperez 27/Febrero/2018           
        Try
            usp_EliminaPromocionesPlaza = objDALPromociones.usp_EliminaPromocionesPlaza(IdPromocion, Plaza, Sucursal)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerSeñalizador(ByVal IdSeñalizador As Integer, ByVal Señalizador As String) As DataSet
        'miguelperez 03/Marzo/2019          
        Try
            usp_TraerSeñalizador = objDALPromociones.usp_TraerSeñalizador(IdSeñalizador, Señalizador)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerTipoPerciero(ByVal IdTipoPerciero As Integer, ByVal TipoPerciero As String) As DataSet
        'miguelperez 03/Marzo/2019           
        Try
            usp_TraerTipoPerciero = objDALPromociones.usp_TraerTipoPerciero(IdTipoPerciero, TipoPerciero)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_EliminaPromocionAgrupacion(ByVal IdPromocion As Integer, ByVal Renglon As Integer) As Boolean
        'miguelperez 03/Marzo/2018           
        Try
            usp_EliminaPromocionAgrupacion = objDALPromociones.usp_EliminaPromocionAgrupacion(IdPromocion, Renglon)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region

End Class
