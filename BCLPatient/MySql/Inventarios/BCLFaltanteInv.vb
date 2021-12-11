Public Class BCLFaltanteInv

    Implements IDisposable
    Private objDALFaltanteInv As DAL.DALFaltanteInv
    Private disposedValue As Boolean = False        ' To detect redundant calls
#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALFaltanteInv = New DAL.DALFaltanteInv(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALFaltanteInv.Dispose()
            objDALFaltanteInv = Nothing
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
    Public Function usp_PpalFaltInv(ByVal division As String, ByVal sucursal As String) As DataSet
        'mreyes 18/Octubre/2012 04:08 p.m.
        Try
            usp_PpalFaltInv = objDALFaltanteInv.usp_PpalFaltanteInv(division, sucursal)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region


End Class
