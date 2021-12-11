Public Class BCLTipoVivienda
    'lvillegas 19-01-2018 04:46 p.m.
    'los nombres de las bcl y dals no pueden ser bclabc, no haces referencia a lo que se trata, en este caso
    'es bclcontrol o en su defecto bclnomtabla

    Implements IDisposable
    Private objDALTipoVivienda As DAL.DALTipoVivienda
    Private disposedValue As Boolean = False        ' To detect redundant calls

    Public Function usp_capturaTipoVivienda() As Boolean
        Throw New NotImplementedException()
    End Function

    'Disposable 
#Region "Constructor and Destructor"
    Public Sub New(ByVal Constring As String)
        objDALTipoVivienda = New DAL.DALTipoVivienda(Constring)
    End Sub


    'lvillegas 20-01-2018 09:17 a.m.
    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then

            End If
            objDALTipoVivienda.Dispose()
            objDALTipoVivienda = Nothing
        End If
        Me.disposedValue = True
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        ' No cambie este código. Coloque el código de limpieza en el anterior Dispose(disposing As Boolean).
        Dispose(True)
        ' TODO: quite la marca de comentario de la siguiente línea si Finalize() se ha reemplazado antes.
        GC.SuppressFinalize(Me)
    End Sub
#End Region


#Region "Public section Functions"
    Public Function usp_capturaTipoVivienda(opcion As Integer,
                                            idtipovivienda As Integer,
                                            tipovivienda As String,
                                            observaciones As String,
                                            idusuario As Integer,
                                            idusuariomodif As Integer,
                                            fummodif As Date) As Boolean
        'lvillegas 20-01-2018 09:33 a.m.
        Try
            Return objDALTipoVivienda.usp_capturaTipoVivienda(opcion,
                                                               idtipovivienda,
                                                               tipovivienda,
                                                               observaciones,
                                                               idusuario,
                                                               idusuariomodif,
                                                               fummodif)

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_CapturaAccesos(IdEmpleado As Integer, Usuario As String, Programa As String, ip As String) As Boolean
        'mreyes 04/Julio/2018   11:58 a.m.
        Try
            Return objDALTipoVivienda.usp_CapturaAccesos(IdEmpleado, Usuario, Programa, ip)

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaAccesosSIRCO(Opcion As Integer, IdEmpleado As Integer, Usuario As String, ip As String) As Boolean
        'mreyes 20/Febrero/2019   06:25 p.m.
        Try
            Return objDALTipoVivienda.usp_CapturaAccesosSIRCO(Opcion, IdEmpleado, Usuario, ip)

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerAccesosSIRCO(Opcion As Integer, IdEmpleado As Integer, Usuario As String, Ip As String) As DataSet
        'mreyes 20/Febrero/2019 06:32 p.m.
        Try
            usp_TraerAccesosSIRCO = objDALTipoVivienda.usp_TraerAccesosSIRCO(Opcion, IdEmpleado, Usuario, Ip)


        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_mostrarTipoVivienda(opcion As Integer,
                                            idtipovivienda As Integer,
                                            tipovivienda As String,
                                            observaciones As String,
                                            idusuario As Integer,
                                            idusuariomodif As Integer,
                                            fummodif As Date) As DataSet

        usp_mostrarTipoVivienda = objDALTipoVivienda.usp_mostrarTipoVivienda(opcion,
                                                               idtipovivienda,
                                                               tipovivienda,
                                                               observaciones,
                                                               idusuario,
                                                               idusuariomodif,
                                                               fummodif)
    End Function
#End Region

End Class
