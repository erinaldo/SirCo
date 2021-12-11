Public Class BCLCancelarVales
    'lvillegas 07-02-2018 10:58 a.m.

    Implements IDisposable
    Private objDALCancelarVales As DAL.DALCancelarVales
    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
        objDALCancelarVales = New DAL.DALCancelarVales(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALCancelarVales.Dispose()
            objDALCancelarVales = Nothing
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

#Region "Public Section Functions"


    Public Function usp_CapturaCancelarVales(ByVal opcion As Integer,
                                                                ByVal iddistrib As Integer,
                                                                ByVal valera As String,
                                                                ByVal valeini As String,
                                                                ByVal valefin As String,
                                                                ByVal idmotivo As Integer,
                                                                ByVal idusuario As Integer,
                                                                ByVal idusuariomodif As Integer,
                                                                ByVal fummodif As Date) As Boolean
        Try



            Return objDALCancelarVales.usp_CapturaCancelarVales(opcion,
                                                                iddistrib,
                                                                valera,
                                                                valeini,
                                                                valefin,
                                                                idmotivo,
                                                                idusuario,
                                                                idusuariomodif,
                                                                fummodif)




        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
               ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_MostrarCancelarVales(ByVal opcion As Integer,
                                                                ByVal iddistrib As Integer,
                                                                ByVal valera As String,
                                                                ByVal valeini As String,
                                                                ByVal valefin As String,
                                                                ByVal idmotivo As Integer,
                                                                ByVal idusuario As Integer,
                                                                ByVal idusuariomodif As Integer,
                                                                ByVal fummodif As Date) As DataSet

        usp_MostrarCancelarVales = objDALCancelarVales.usp_MostrarCancelarVales(opcion,
                                                                iddistrib,
                                                                valera,
                                                                valeini,
                                                                valefin,
                                                                idmotivo,
                                                                idusuario,
                                                                idusuariomodif,
                                                                fummodif)
    End Function
#End Region
End Class
