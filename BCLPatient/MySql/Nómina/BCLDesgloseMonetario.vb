Public Class BCLDesgloseMonetario
    'Tony Garcia - 19/Sept/2012 - 09:50 a.m.

    Implements IDisposable
    Private objDALDesgloseMonetario As DAL.DALDesgloseMonetario
    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALDesgloseMonetario = New DAL.DALDesgloseMonetario(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALDesgloseMonetario.Dispose()
            objDALDesgloseMonetario = Nothing
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

    Public Function usp_PpalDesgloseMon(ByVal IdEmpleado As Integer, ByVal IdPeriodo As Integer, ByVal TipoNom As String, _
                                        ByVal Sucursal As String, ByVal IdDepto As Integer, ByVal IdPuesto As Integer) As DataSet
        'Tony Garcia - 19/Sept/2012 09:56 a.m.

        Try
            'Call the data component to get all groups
            usp_PpalDesgloseMon = objDALDesgloseMonetario.usp_PpalDesgloseMon(IdEmpleado, IdPeriodo, TipoNom, Sucursal, IdDepto, IdPuesto)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
