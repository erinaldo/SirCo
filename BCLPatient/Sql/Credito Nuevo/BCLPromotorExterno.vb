Public Class BCLPromotorExterno
    'lvillegas 09-02-2018 01:36 p.m.

    Implements IDisposable
    Private objDALPromotorExterno As DAL.DALPromotorExterno
    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
        objDALPromotorExterno = New DAL.DALPromotorExterno(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALPromotorExterno.Dispose()
            objDALPromotorExterno = Nothing
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
    Public Function usp_CapturaPromotorExterno(ByVal opcion As Integer,
                                       ByVal idpromotorexterno As Integer,
                                       ByVal nombre As String,
                                       ByVal appaterno As String,
                                       ByVal apmaterno As String,
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
                                       ByVal idusuario As Integer,
                                       ByVal idusuariomodif As Integer,
                                       ByVal fummodif As Date) As Boolean
        Try

            Return objDALPromotorExterno.usp_CapturaPromotorExterno(opcion,
                                                    idpromotorexterno,
                                                    nombre,
                                                    appaterno,
                                                    apmaterno,
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
                                                    idusuario,
                                                    idusuariomodif,
                                                    fummodif)

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try

    End Function

    Public Function usp_mostrarPromotorExterno(ByVal opcion As Integer,
                                       ByVal idpromotorexterno As Integer,
                                       ByVal nombre As String,
                                       ByVal appaterno As String,
                                       ByVal apmaterno As String,
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
                                       ByVal idusuario As Integer,
                                       ByVal idusuariomodif As Integer,
                                       ByVal fummodif As Date) As DataSet

        usp_mostrarPromotorExterno = objDALPromotorExterno.usp_mostrarPromotorExterno(opcion,
                                                    idpromotorexterno,
                                                    nombre,
                                                    appaterno,
                                                    apmaterno,
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
                                                    idusuario,
                                                    idusuariomodif,
                                                    fummodif)
    End Function




#End Region
End Class
