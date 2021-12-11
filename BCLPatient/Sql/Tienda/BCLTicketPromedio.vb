Public Class BCLTicketPromedio
    Implements IDisposable
    Private objDALTicketPromedio As DAL.DALTicketPromedio
    Public Sub New(ByVal Constring As String)
9:      objDALTicketPromedio = New DAL.DALTicketPromedio(Constring)
    End Sub

    Public Function usp_TraerTicketPromedio(ByVal fecha_desde As String, fecha_hasta As String, Cve_Sucursal As String) As DataSet
        'jvargas 17/Agosto/2018   11:18 am
        Try
            Return objDALTicketPromedio.usp_TraerTicketPromedio(fecha_desde, fecha_hasta, Cve_Sucursal)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
#Region "IDisposable Support"
    Private disposedValue As Boolean ' Para detectar llamadas redundantes

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

End Class
