Public Class BCLNegociosExternos
    Implements IDisposable
    Private objDALNegociosExternos As DAL.DALNegociosExternos
    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
        objDALNegociosExternos = New DAL.DALNegociosExternos(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALNegociosExternos.Dispose()
            objDALNegociosExternos = Nothing
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

#Region "Public section fuction"
    Public Function usp_CapturaNegocioExterno(ByVal opcion As Integer,
                                             ByVal idnegexterno As Integer,
                                             ByVal negocio As String,
                                             ByVal descripcion As String,
                                             ByVal idusuario As Integer,
                                             ByVal idusuariomodif As Integer,
                                             ByVal fummodif As Date) As Boolean

        Try

            Return objDALNegociosExternos.usp_CapturaNegocioExterno(opcion,
                                                                    idnegexterno,
                                                                    negocio,
                                                                    descripcion,
                                                                    idusuario,
                                                                    idusuariomodif,
                                                                    fummodif)

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_mostrarNegociosExternos(ByVal opcion As Integer,
                                             ByVal idnegexterno As Integer,
                                             ByVal negocio As String,
                                             ByVal descripcion As String,
                                             ByVal idusuario As Integer,
                                             ByVal idusuariomodif As Integer,
                                             ByVal fummodif As Date) As DataSet

        usp_mostrarNegociosExternos = objDALNegociosExternos.usp_mostrarNegocioExterno(opcion,
                                                                    idnegexterno,
                                                                    negocio,
                                                                    descripcion,
                                                                    idusuario,
                                                                    idusuariomodif,
                                                                    fummodif)
    End Function
#End Region
End Class
