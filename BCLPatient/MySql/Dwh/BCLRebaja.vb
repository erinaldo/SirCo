Public Class BCLRebaja
    'mreyes 18/Octubre/2012 02:06 p.m.

    Implements IDisposable
    Private objDALRebaja As DAL.DALRebaja
    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALRebaja = New DAL.DALRebaja(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALRebaja.Dispose()
            objDALRebaja = Nothing
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
    Public Function usp_PpalRebaja(ByVal sucursal As String, ByVal FechaIni As String, ByVal FechaFin As String, ByVal Division As String, ByVal Depto As String, ByVal Familia As String, ByVal Linea As String,
    ByVal L1 As String, ByVal L2 As String, ByVal L3 As String, ByVal L4 As String, ByVal L5 As String, ByVal L6 As String, ByVal Marca As String, ByVal idagrupacion As Integer) As DataSet
        'mreyes 18/Octubre/2012 04:08 p.m.
        Try
            usp_PpalRebaja = objDALRebaja.usp_PpalRebaja(sucursal, FechaIni, FechaFin, Division, Depto, Familia, Linea, L1, L2, L3, L4, L5, L6, Marca, idagrupacion)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function


#End Region
End Class
