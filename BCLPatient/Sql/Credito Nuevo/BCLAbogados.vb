Public Class BCLAbogados
    'lvillegas 31-01-2018 12:18 p.m.

    Implements IDisposable
    Private objDALabogado As DAL.DALAbogados
    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
        objDALabogado = New DAL.DALAbogados(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALabogado.Dispose()
            objDALabogado = Nothing
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

#Region "Public section function"
    Public Function usp_CapturaAbogado(ByVal opcion As Integer,
                                       ByVal idabogado As Integer,
                                       ByVal nombre As String,
                                       ByVal appaterno As String,
                                       ByVal apmaterno As String,
                                       ByVal cedula As String,
                                       ByVal idestado As Integer,
                                       ByVal idciudad As Integer,
                                       ByVal idcolonia As Integer,
                                       ByVal cp As Integer,
                                       ByVal calle As String,
                                       ByVal numero As Integer,
                                       ByVal tel1 As String,
                                       ByVal tel2 As String,
                                       ByVal celular1 As String,
                                       ByVal celular2 As String,
                                       ByVal email As String,
                                       ByVal despacho As String,
                                       ByVal idestadodpcho As Integer,
                                       ByVal idciudadpcho As Integer,
                                       ByVal idcoloniadpcho As Integer,
                                       ByVal cpdpcho As Integer,
                                       ByVal calledpcho As String,
                                       ByVal entrecallesdpcho As String,
                                       ByVal numerodpcho As Integer,
                                       ByVal idusuario As Integer,
                                       ByVal fum As Date,
                                       ByVal idusuariomodif As Integer,
                                       ByVal fummodif As Date) As Boolean
        Try

            Return objDALabogado.usp_CapturaAbogado(opcion,
                                                    idabogado,
                                                    nombre,
                                                    appaterno,
                                                    apmaterno,
                                                    cedula,
                                                    idestado,
                                                    idciudad,
                                                    idcolonia,
                                                    cp,
                                                    calle,
                                                    numero,
                                                    tel1,
                                                    tel2,
                                                    celular1,
                                                    celular2,
                                                    email,
                                                    despacho,
                                                    idestadodpcho,
                                                    idciudadpcho,
                                                    idcoloniadpcho,
                                                    cpdpcho,
                                                    calledpcho,
                                                    entrecallesdpcho,
                                                    numerodpcho,
                                                    idusuario,
                                                    fum,
                                                    idusuariomodif,
                                                    fummodif)

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try

    End Function

    Public Function usp_mostrarAbogado(ByVal opcion As Integer,
                                       ByVal idabogado As Integer,
                                       ByVal nombre As String,
                                       ByVal appaterno As String,
                                       ByVal apmaterno As String,
                                       ByVal cedula As String,
                                       ByVal idestado As Integer,
                                       ByVal idciudad As Integer,
                                       ByVal idcolonia As Integer,
                                       ByVal cp As Integer,
                                       ByVal calle As String,
                                       ByVal numero As Integer,
                                       ByVal tel1 As String,
                                       ByVal tel2 As String,
                                       ByVal celular1 As String,
                                       ByVal celular2 As String,
                                       ByVal email As String,
                                       ByVal despacho As String,
                                       ByVal idestadodpcho As Integer,
                                       ByVal idciudadpcho As Integer,
                                       ByVal idcoloniadpcho As Integer,
                                       ByVal cpdpcho As Integer,
                                       ByVal calledpcho As String,
                                       ByVal entrecallesdpcho As String,
                                       ByVal numerodpcho As Integer,
                                       ByVal idusuario As Integer,
                                       ByVal fum As Date,
                                       ByVal idusuariomodif As Integer,
                                       ByVal fummodif As Date) As DataSet

        usp_mostrarAbogado = objDALabogado.usp_mostrarAbogado(opcion,
                                                    idabogado,
                                                    nombre,
                                                    appaterno,
                                                    apmaterno,
                                                    cedula,
                                                    idestado,
                                                    idciudad,
                                                    idcolonia,
                                                    cp,
                                                    calle,
                                                    numero,
                                                    tel1,
                                                    tel2,
                                                    celular1,
                                                    celular2,
                                                    email,
                                                    despacho,
                                                    idestadodpcho,
                                                    idciudadpcho,
                                                    idcoloniadpcho,
                                                    cpdpcho,
                                                    calledpcho,
                                                    entrecallesdpcho,
                                                    numerodpcho,
                                                    idusuario,
                                                    fum,
                                                    idusuariomodif,
                                                    fummodif)
    End Function



    Public Function usp_traerNombreAbogado(
                                           ByVal idabogado As Integer,
                                          ByVal nombre As String,
                                       ByVal appaterno As String,
                                       ByVal apmaterno As String) As DataSet
        Try



            usp_traerNombreAbogado = objDALabogado.usp_traerNombreAbogados(idabogado, nombre, appaterno, apmaterno)

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region

End Class
