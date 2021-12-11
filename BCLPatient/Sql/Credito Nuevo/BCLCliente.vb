Public Class BCLCliente
    'vgallegos 03/Febrero/2018

    Implements IDisposable
    Private objDALCliente As DAL.DALCliente

    Private disposedValue As Boolean = False        ' To detect redundant calls
#Region "IDisposable Support"

    Public Sub New(ByVal Constring As String)
9:      objDALCliente = New DAL.DALCliente(Constring)
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

    Public Function usp_CapturaCliente(ByVal opcion As Integer, ByVal idcliente As Integer, ByVal nombre As String, ByVal appaterno As String,
                                       ByVal apmaterno As String, ByVal sexo As String, ByVal idestado As Integer, ByVal idciudad As Integer,
                                       ByVal idcolonia As Integer, ByVal codigopostal As String, ByVal calle As String, ByVal numero As Integer,
                                       ByVal celular1 As String, ByVal email As String, ByVal idusuario As Integer, ByVal idusuariomodif As Integer) As Boolean
        ' vgallegos 03/Fbrero/2018   11:24 am
        Try
            Return objDALCliente.usp_CapturaCliente(opcion, idcliente, nombre, appaterno, apmaterno, sexo, idestado, idciudad, idcolonia,
                                   codigopostal, calle, numero, celular1, email, idusuario, idusuariomodif)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerCliente(ByVal opcion As Integer, ByVal idcliente As Integer, ByVal nombre As String, ByVal appaterno As String, ByVal apmaterno As String) As DataSet
        ' vgallegos 03/Fbrero/2018   11:24 am
        Try
            Return objDALCliente.usp_TraerCliente(opcion, idcliente, nombre, appaterno, apmaterno)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_ValidarCliente(ByVal nombre As String, ByVal appaterno As String, ByVal apmaterno As String) As DataSet
        ' vgallegos 03/Fbrero/2018   11:24 am
        Try
            Return objDALCliente.usp_ValidarCliente(nombre, appaterno, apmaterno)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function


#End Region
End Class
