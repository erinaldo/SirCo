Public Class BCLPresupuesto
    Implements IDisposable
    Private objDALPresupuesto As DAL.DALPresupuesto
    Private disposedValue As Boolean = False        ' To detect redundant calls

#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALPresupuesto = New DAL.DALPresupuesto(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then

                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALPresupuesto.Dispose()
            objDALPresupuesto = Nothing
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
    Public Function usp_CapturaPresupuesto(ByVal IdSucursal As Integer, ByVal Año As String, ByVal Mes As String, ByVal IdDivision As Integer, ByVal Division As String, ByVal Presupuesto As Decimal, ByVal IdUsuario As String) As Boolean
        'miguelperez 25/Abril/2019   
        Try
            usp_CapturaPresupuesto = objDALPresupuesto.usp_CapturaPresupuesto(IdSucursal, Año, Mes, IdDivision, Division, Presupuesto, IdUsuario)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerPresupuesto(ByVal Tipo As String, ByVal Año As String, ByVal Mes As String) As DataSet
        'miguelperez 25/Abril/2019   
        Try
            usp_TraerPresupuesto = objDALPresupuesto.usp_TraerPresupuesto(Tipo, Año, Mes)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ModificaPresupuesto(ByVal IdSucursal As Integer, ByVal Año As String, ByVal Mes As String, ByVal IdDivision As Integer, ByVal Presupuesto As Decimal, ByVal IdUsuario As String) As Boolean
        'miguelperez 25/Abril/2019   
        Try
            usp_ModificaPresupuesto = objDALPresupuesto.usp_ModificaPresupuesto(IdSucursal, Año, Mes, IdDivision, Presupuesto, IdUsuario)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerCatPresupuesto(ByVal Tipo As String, ByVal Año As String, ByVal Mes As String, ByVal Plaza As Integer, ByVal Sucursal As Integer, ByVal Division As Integer) As DataSet
        'miguelperez 25/Abril/2019   
        Try
            usp_TraerCatPresupuesto = objDALPresupuesto.usp_TraerCatPresupuesto(Tipo, Año, Mes, Plaza, Sucursal, Division)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
