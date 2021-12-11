Public Class BCLApendiceSQL
    Implements IDisposable
    Private objDALApendice As DAL.DALApendiceSQL
    Private disposedValue As Boolean = False

#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALApendice = New DAL.DALApendiceSQL(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALApendice.Dispose()
            objDALApendice = Nothing
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
    Public Function usp_Traer_Forma_Pago(Fecha As String, ByVal Sucursal As String) As DataSet
        'mreyes 27/Diciembre/2017   07:08 p.m.
        Try
            Return objDALApendice.usp_Traer_Forma_Pago(Fecha, Sucursal)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_traer_desglose_movimientos_x_articulo(Fecha As String, ByVal Sucursal As String) As DataSet
        'fdoadame 27/Diciembre/2017   10:00 a.m.
        Try
            Return objDALApendice.usp_traer_desglose_movimientos_x_articulo(Fecha, Sucursal)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerSucursalTR(ByVal Sucursal As String) As DataSet
        'fdoadame 27/Diciembre/2017 11:44 a.m.
        Try
            'Call the data component to get all groups
            Return objDALApendice.usp_TraerSucursalTR(Sucursal)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
