Public Class BCLGestoresDeCartera
    'vgallegos 09/Febrero/2018

    Implements IDisposable
    Private objDALGestor As DAL.DALGestoresDeCartera



    Private disposedValue As Boolean = False
#Region "IDisposable Support"

    Public Sub New(ByVal Constring As String)
9:      objDALGestor = New DAL.DALGestoresDeCartera(Constring)
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

    Public Function usp_TraerGestoresDeCartera(ByVal opcion As Integer, ByVal idgestor As Integer) As DataSet
        Try
            Return objDALGestor.usp_TraerGestoresDeCartera(opcion, idgestor)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaGestorDeCartera(ByVal opcion As Integer, ByVal idgestor As Integer, ByVal tipo As String, ByVal carterafresca As Integer,
                                      ByVal carteravencida As String, ByVal idusuario As Integer, ByVal idusuariomodif As Integer) As Boolean
        Try
            Return objDALGestor.usp_CapturaGestorDeCartera(opcion, idgestor, tipo, carterafresca, carteravencida, idusuario, idusuariomodif)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

#End Region


End Class
