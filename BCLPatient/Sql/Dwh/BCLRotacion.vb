Public Class BCLRotacion
    Implements IDisposable
    Private objDALEstadisticaVts As DAL.dalrotacion
    Private disposedValue As Boolean = False        ' To detect redundant calls

#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALEstadisticaVts = New DAL.DALRotacion(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then

                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALEstadisticaVts.Dispose()
            objDALEstadisticaVts = Nothing
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
    Public Function Usp_PpalRotacion(ByVal Tipo As String, ByVal Plaza As Integer, ByVal IdSucursal As Integer, ByVal FecIni As String, ByVal FecFin As String, ByVal Division As String, ByVal Depto As String, ByVal Familia As String, ByVal Linea As String, ByVal L1 As String, ByVal L2 As String, ByVal L3 As String, ByVal L4 As String, ByVal L5 As String, ByVal L6 As String, ByVal Marca As String, ByVal Modelo As String, ByVal AñoAnterior As Boolean, ByVal AntDia As Boolean, ByVal AntSemana As Boolean, ByVal Miles As Integer, ByVal IdAgrupacion As Integer, ByVal SoloSucVta As String) As DataSet
        'Rafa
        Try
            Usp_PpalRotacion = objDALEstadisticaVts.usp_PpalRotacion(Tipo, Plaza, IdSucursal, FecIni, FecFin, Division, Depto, Familia, Linea, L1, L2, L3, L4, L5, L6, Marca, Modelo, AñoAnterior, AntDia, AntDia, Miles, IdAgrupacion, SoloSucVta)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerEstructuraClave(ByVal Tipo As String, ByVal Clave As String, ByVal Id As Integer) As DataSet
        'miguelperez 10/Abril/2019   
        Try
            usp_TraerEstructuraClave = objDALEstadisticaVts.usp_TraerEstructuraClave(Tipo, Clave, Id)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
