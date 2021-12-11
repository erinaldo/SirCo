Public Class BCLImprimeTraspasos
    Implements IDisposable
    Private objDALReportes As DAL.DALImprimeTraspasos
    Private disposedValue As Boolean = False

#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALReportes = New DAL.DALImprimeTraspasos(Constring)
    End Sub
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free other state (managed objects).
            End If

            ' TODO: free your own state (unmanaged objects).
            ' TODO: set large fields to null.
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
    Public Function usp_ImprimeTraspasos(ByVal opcion As Integer, ByVal sucursal As String, ByVal traspaso As String) As DataSet
        'ro
        Try
            'Call the data component to get all groups
            usp_ImprimeTraspasos = objDALReportes.usp_ImprimeTraspasos(opcion, sucursal, traspaso)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerSucursalTR(ByVal sucursal As String) As DataSet
        'ro
        Try
            'Call the data component to get all groups
            usp_TraerSucursalTR = objDALReportes.usp_TraerSucursalTR(sucursal)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
