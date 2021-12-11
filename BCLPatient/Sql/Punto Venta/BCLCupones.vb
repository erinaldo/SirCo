Public Class BCLCupones
    Implements IDisposable
    Private objDALCupones As DAL.DALCupones
    Private disposedValue As Boolean = False        ' To detect redundant calls

#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALCupones = New DAL.DALCupones(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then

                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALCupones.Dispose()
            objDALCupones = Nothing
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

    Public Function usp_TraerCupones(ByVal IdCupon As Integer, ByVal Estatus As String) As DataSet
        'miguelperez 13/Febrero/2019   
        Try
            usp_TraerCupones = objDALCupones.usp_TraerCupones(IdCupon, Estatus)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaCupon(ByVal Nombre As String, ByVal Descripcion As String, ByVal Restricciones As String, ByVal Tipo As String, ByVal IdUsuario As String, ByVal fecIni As String, ByVal fecFin As String, ByVal Imagen As Byte()) As DataSet
        'miguelperez 13/Febrero/2019   
        Try
            usp_CapturaCupon = objDALCupones.usp_CapturaCupon(Nombre, Descripcion, Restricciones, Tipo, IdUsuario, fecIni, fecFin, Imagen)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ModificaCupon(ByVal IdCupon As Integer, ByVal Nombre As String, ByVal Descripcion As String, ByVal Restricciones As String, ByVal Estatus As String, ByVal Tipo As String, ByVal IdUsuario As String, ByVal fecIni As String, ByVal fecFin As String, ByVal Imagen As Byte()) As Boolean
        'miguelperez 13/Febrero/2019   
        Try
            usp_ModificaCupon = objDALCupones.usp_ModificaCupon(IdCupon, Nombre, Descripcion, Restricciones, Estatus, Tipo, IdUsuario, fecIni, fecFin, Imagen)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerFolioOperacion(ByVal Operacion As String, ByVal Sucursal As String, ByVal Usuario As String, Optional ByVal Tipo As String = "NORMAL", Optional ByVal Folio As Integer = 0) As DataSet
        'miguelperez 17/Febrero/2019      
        Try
            usp_TraerFolioOperacion = objDALCupones.usp_TraerFolioOperacion(Operacion, Sucursal, Usuario, Tipo, Folio)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerFolioCupon(ByVal IdCupon As Integer, ByVal Folio As String, ByVal Estatus As String) As DataSet
        'miguelperez 17/Febrero/2019      
        Try
            usp_TraerFolioCupon = objDALCupones.usp_TraerFolioCupon(IdCupon, Folio, Estatus)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaCuponDet(ByVal IdCupon As Integer, ByVal Folio As String, ByVal Estatus As String, ByVal IdUsuario As String) As Boolean
        'miguelperez 18/Febrero/2018   
        Try
            usp_CapturaCuponDet = objDALCupones.usp_CapturaCuponDet(IdCupon, Folio, Estatus, IdUsuario)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_EliminaCuponesDet(ByVal IdCupon As Integer, ByVal Folio As String) As Boolean
        'miguelperez 06/Marzo/2018    
        Try
            usp_EliminaCuponesDet = objDALCupones.usp_EliminaCuponesDet(IdCupon, Folio)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_BuscaCuponPromoActiva(ByVal IdCupon As Integer) As DataSet
        'miguelperez 13/Febrero/2019   
        Try
            usp_BuscaCuponPromoActiva = objDALCupones.usp_BuscaCuponPromoActiva(IdCupon)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

#End Region

End Class
