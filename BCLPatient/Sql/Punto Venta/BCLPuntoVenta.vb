Public Class BCLPuntoVenta
    'mreyes 12/Marzo/2019   01:02 p.m.

    Implements IDisposable
    Private objDALPuntoVenta As DAL.DALPuntoVenta
    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALPuntoVenta = New DAL.DALpuntoventa(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALPuntoVenta.Dispose()
            objDALPuntoVenta = Nothing
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


    Public Function usp_TraerSeriePV(Serie As String) As DataSet
        'mreyes 12/Marzo/2019   01:11 p.m.  

        Try
            Return objDALPuntoVenta.usp_TraerSeriePV(Serie)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

#End Region
End Class
