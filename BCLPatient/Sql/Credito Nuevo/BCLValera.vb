Public Class BCLValera
    'vgallegos 07/Febrero/2018 11:12 am

    Implements IDisposable
    Private objDALValera As DAL.DALValera

    Private disposedValue As Boolean = False ' Para detectar llamadas redundantes
#Region "IDisposable Support"

    Public Sub New(ByVal Constring As String)
9:      objDALValera = New DAL.DALValera(Constring)
    End Sub

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                ' TODO: elimine el estado administrado (objetos administrados).
            End If

            ' TODO: libere los recursos no administrados (objetos no administrados) y reemplace Finalize() a continuación.
            ' TODO: configure los campos grandes en nulos.
        End If
        disposedValue = True
    End Sub

    ' TODO: reemplace Finalize() solo si el anterior Dispose(disposing As Boolean) tiene código para liberar recursos no administrados.
    'Protected Overrides Sub Finalize()
    '    ' No cambie este código. Coloque el código de limpieza en el anterior Dispose(disposing As Boolean).
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' Visual Basic agrega este código para implementar correctamente el patrón descartable.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' No cambie este código. Coloque el código de limpieza en el anterior Dispose(disposing As Boolean).
        Dispose(True)
        ' TODO: quite la marca de comentario de la siguiente línea si Finalize() se ha reemplazado antes.
        ' GC.SuppressFinalize(Me)
    End Sub
#End Region


#Region " Public Section Functions "
    Public Function usp_TraerEntregaDeValeras(ByVal idvalera As String) As DataSet
        ' vgallegos 07/Fbrero/2018   11:18 am
        Try
            Return objDALValera.usp_TraerEntregaDeValeras(idvalera)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerDistrib(ByVal iddistrib As String) As DataSet
        Try
            Return objDALValera.usp_TraerDistrib(iddistrib)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function



    Public Function usp_CapturarEntregaDeValeras(ByVal opcion As Integer, ByVal iddistrib As String, ByVal valera As String, ByVal valeini As String,
                                       ByVal valefin As String, ByVal entrega As Date, ByVal recoge As String, ByVal idusuario As Integer, ByVal idusuariomodif As Integer) As Boolean
        Try
            Return objDALValera.usp_CapturarEntregaDeValeras(opcion, iddistrib, valera, valeini, valefin, entrega, recoge, idusuario, idusuariomodif)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

#End Region

End Class
