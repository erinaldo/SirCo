Public Class BCLAgrupaciones
    Implements IDisposable
    Private objDALAgrupaciones As DAL.DALAgrupaciones
    Private disposedValue As Boolean = False        ' To detect redundant calls

#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALAgrupaciones = New DAL.DALAgrupaciones(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then

                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALAgrupaciones.Dispose()
            objDALAgrupaciones = Nothing
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


    Public Function usp_TraerAgrupaciones(ByVal IdAgrupacion As Integer, ByVal Nombre As String) As DataSet
        'miguelperez 02/Febrero/2019   
        Try
            usp_TraerAgrupaciones = objDALAgrupaciones.usp_TraerAgrupaciones(IdAgrupacion, Nombre)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerEstructura(ByVal Tipo As String, Optional Division As Integer = 0, Optional Departamento As Integer = 0, Optional Familia As Integer = 0, Optional Linea As Integer = 0, Optional L1 As Integer = 0, Optional L2 As Integer = 0, Optional L3 As Integer = 0, Optional L4 As Integer = 0, Optional L5 As Integer = 0, Optional L6 As Integer = 0) As DataSet
        'miguelperez 04/Febrero/2019   
        Try
            usp_TraerEstructura = objDALAgrupaciones.usp_TraerEstructura(Tipo, Division, Departamento, Familia, Linea, L1, L2, L3, L4, L5, L6)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaAgrupacion(ByVal Nombre As String, ByVal Fecha As String, ByVal IdUsuario As String) As DataSet
        'miguelperez 06/Febrero/2019   
        Try
            usp_CapturaAgrupacion = objDALAgrupaciones.usp_CapturaAgrupacion(Nombre, Fecha, IdUsuario)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ModificaAgrupacion(ByVal IdAgrupacion As Integer, ByVal Nombre As String, ByVal IdUsuario As String) As Boolean
        'miguelperez 06/Febrero/2019   
        Try
            usp_ModificaAgrupacion = objDALAgrupaciones.usp_ModificaAgrupacion(IdAgrupacion, Nombre, IdUsuario)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerAgrupacionesDet(ByVal IdAgrupacion As Integer, ByVal Renglon As Integer) As DataSet
        'miguelperez 07/Febrero/2019  
        Try
            usp_TraerAgrupacionesDet = objDALAgrupaciones.usp_TraerAgrupacionesDet(IdAgrupacion, Renglon)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_BuscaAgrupacionDet(ByVal IdAgrupacion As Integer, ByVal Nivel As String, ByVal IdDivision As Integer, ByVal IdDepto As Integer, ByVal idFamilia As Integer, ByVal IdLinea As Integer, ByVal IdL1 As Integer, ByVal IdL2 As Integer, ByVal IdL3 As Integer, ByVal IdL4 As Integer, ByVal IdL5 As Integer, ByVal IdL6 As Integer, ByVal Marca As String, ByVal Estilon As String) As DataSet
        'miguelperez 07/Febrero/2019  
        Try
            usp_BuscaAgrupacionDet = objDALAgrupaciones.usp_BuscaAgrupacionDet(IdAgrupacion, Nivel, IdDivision, IdDepto, idFamilia, IdLinea, IdL1, IdL2, IdL3, IdL4, IdL5, IdL6, Marca, Estilon)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_BuscaAgrupacionPromoActiva(ByVal IdAgrupacion As Integer) As DataSet
        'miguelperez 07/Febrero/2019  
        Try
            usp_BuscaAgrupacionPromoActiva = objDALAgrupaciones.usp_BuscaAgrupacionPromoActiva(IdAgrupacion)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaAgrupacionDet(ByVal IdAgrupacion As Integer, ByVal IdDivision As Integer, ByVal IdDepto As Integer, ByVal idFamilia As Integer, ByVal IdLinea As Integer, ByVal IdL1 As Integer, ByVal IdL2 As Integer, ByVal IdL3 As Integer, ByVal IdL4 As Integer, ByVal IdL5 As Integer, ByVal IdL6 As Integer, ByVal Marca As String, ByVal Estilon As String, ByVal Nivel As String, ByVal IdUsuario As String) As Boolean
        'miguelperez 08/Febrero/2019   
        Try
            usp_CapturaAgrupacionDet = objDALAgrupaciones.usp_CapturaAgrupacionDet(IdAgrupacion, IdDivision, IdDepto, idFamilia, IdLinea, IdL1, IdL2, IdL3, IdL4, IdL5, IdL6, Marca, Estilon, Nivel, IdUsuario)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ModificaAgrupacionDet(ByVal IdAgrupacion As Integer, ByVal IdDivision As Integer, ByVal IdDepto As Integer, ByVal idFamilia As Integer, ByVal IdLinea As Integer, ByVal IdL1 As Integer, ByVal IdL2 As Integer, ByVal IdL3 As Integer, ByVal IdL4 As Integer, ByVal IdL5 As Integer, ByVal IdL6 As Integer, ByVal Marca As String, ByVal Estilon As String, ByVal Nivel As String, ByVal Renglon As Integer, ByVal IdUsuario As String) As Boolean
        'miguelperez 08/Febrero/2019   
        Try
            usp_ModificaAgrupacionDet = objDALAgrupaciones.usp_ModificaAgrupacionDet(IdAgrupacion, IdDivision, IdDepto, idFamilia, IdLinea, IdL1, IdL2, IdL3, IdL4, IdL5, IdL6, Marca, Estilon, Nivel, Renglon, IdUsuario)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_EliminaAgrupacionDet(ByVal IdAgrupacion As Integer, ByVal Renglon As String) As Boolean
        'miguelperez 08/Febrero/2019   
        Try
            usp_EliminaAgrupacionDet = objDALAgrupaciones.usp_EliminaAgrupacionDet(IdAgrupacion, Renglon)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

#End Region

End Class
