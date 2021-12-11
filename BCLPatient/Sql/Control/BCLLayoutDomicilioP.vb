Public Class BCLLayoutDomicilioP
    'vgallegos 26/Enero/2018 11:32 am 

    Implements IDisposable
    Private objDALLayoutCodigos As DAL.DALLayoutDomicilioP
    Private disposedValue As Boolean ' Para detectar llamadas redundantes

#Region "IDisposable Support"
    Public Sub New(ByVal Constring As String)
9:      objDALLayoutCodigos = New DAL.DALLayoutDomicilioP(Constring)
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

    Public Function usp_CapturaLeerArchivoCodigos(ByVal d_codigo As String, ByVal d_asenta As String,
                                                  ByVal d_estado As String, ByVal d_ciudad As String,
                                                  ByVal isusuario As String) As Boolean
        Try
            Return objDALLayoutCodigos.usp_CapturaLayoutCodigos(d_codigo, d_asenta, d_estado,
                                                                               d_ciudad, isusuario)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
               ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerDomicilioParticular(ByVal opcion As Integer, ByVal CP As String, ByVal estado As Integer, ByVal ciudad As Integer, ByVal colonia As Integer) As DataSet

        Try

            Return objDALLayoutCodigos.usp_TraerDomicilioParticular(opcion, CP, estado, ciudad, colonia)


        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
               ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
