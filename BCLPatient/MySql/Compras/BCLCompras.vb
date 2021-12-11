Public Class BCLCompras
    'Tony García

    Implements IDisposable
    Private objDALCompras As DAL.DALCompras
    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALCompras = New DAL.DALCompras(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALCompras.Dispose()
            objDALCompras = Nothing
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
#Region " Public Section Functions "
    Public Function usp_PpalPptoCompras(ByVal Opcion As Integer) As DataSet
        'Tony García - 31/Octubre/2013 10:43 a.m.
        Try
            usp_PpalPptoCompras = objDALCompras.usp_PpalPptoCompras(Opcion)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_PpalPptoComprasEst(ByVal Opcion As Integer, ByVal Sucursal As String, ByVal DescripDivision As String, _
                                    ByVal DescripDepto As String, ByVal DescripFamilia As String, ByVal DescripLinea As String, _
                                    ByVal DescripL1 As String, ByVal DescripL2 As String, ByVal DescripL3 As String, ByVal DescripL4 As String, _
                                    ByVal DescripL5 As String, ByVal DescripL6 As String) As DataSet
        'Tony García - 31/Octubre/2013 11:43 a.m.
        Try
            usp_PpalPptoComprasEst = objDALCompras.usp_PpalPptoComprasEst(Opcion, Sucursal, DescripDivision, DescripDepto, DescripFamilia, DescripLinea, DescripL1, DescripL2, DescripL3, DescripL4, DescripL5, DescripL6)

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalPptoVentaEst(ByVal Opcion As Integer, ByVal Sucursal As String, ByVal DescripDivision As String, _
                                    ByVal DescripDepto As String, ByVal DescripFamilia As String, ByVal DescripLinea As String, _
                                    ByVal DescripL1 As String, ByVal DescripL2 As String, ByVal DescripL3 As String, ByVal DescripL4 As String, _
                                    ByVal DescripL5 As String, ByVal DescripL6 As String) As DataSet
        'Tony García - 31/Octubre/2013 11:43 a.m.
        Try
            usp_PpalPptoVentaEst = objDALCompras.usp_PpalPptoVentaEst(Opcion, Sucursal, DescripDivision, DescripDepto, DescripFamilia, DescripLinea, DescripL1, DescripL2, DescripL3, DescripL4, DescripL5, DescripL6)

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerOCParaCancelar(ByVal Fecha As Date) As DataSet
        'Miguel Pérez - 23/Dic/2013
        Try
            usp_TraerOCParaCancelar = objDALCompras.usp_TraerOCParaCancelar(Fecha)

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerOCCanceladas(ByVal FechaIni As Date, ByVal FechaFin As Date, ByVal Estatus As String) As DataSet
        'Miguel Pérez - 23/Dic/2013 
        Try
            usp_TraerOCCanceladas = objDALCompras.usp_TraerOCCanceladas(FechaIni, FechaFin, Estatus)

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaOCCancel(ByVal Sucursal As String, ByVal OrdeComp As String, ByVal Estatus As String, ByVal Proveedor As String, ByVal FecCancela As Date, ByVal UsuarioCancela As String, ByVal FecReactiva As Date, ByVal UsuarioReactiva As String, ByVal Motivo As String) As Boolean
        Try
            'Validate group data
            'Call the data component to add the new group
            Return objDALCompras.usp_CapturaOCCancel(Sucursal, OrdeComp, Estatus, Proveedor, FecCancela, UsuarioCancela, FecReactiva, UsuarioReactiva, Motivo)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ActualizarOCCancel(ByVal Sucursal As String, ByVal OrdeComp As String, ByVal FechaReactiva As Date, ByVal UsuarioReactiva As String, ByVal Motivo As String) As Boolean
        'miguel pérez 10/Diciembre/2012 12:00 a.m.
        Try
            'Call the data component to get all groups
            usp_ActualizarOCCancel = objDALCompras.usp_ActualizarOCCancel(Sucursal, OrdeComp, FechaReactiva, UsuarioReactiva, motivo)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ActualizarFechasDetOC(ByVal Sucursal As String, ByVal OrdeComp As String, ByVal FecEntrega As Date, ByVal FecCancela As Date) As Boolean
        'miguel pérez 10/Diciembre/2012 12:00 a.m.
        Try
            'Call the data component to get all groups
            usp_ActualizarFechasDetOC = objDALCompras.usp_ActualizarFechasDetOC(Sucursal, OrdeComp, FecEntrega, FecCancela)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_GeneraPrecios() As Boolean
        'mreyes 21/Noviembre/2018   12:03 p.m.
        Try
            'Call the data component to get all groups
            usp_GeneraPrecios = objDALCompras.usp_GeneraPrecios()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_QuitarParesUnicos(Marca As String, Modelo As String) As Boolean
        'mreyes 21/Noviembre/2018   12:03 p.m.
        Try
            'Call the data component to get all groups
            usp_QuitarParesUnicos = objDALCompras.usp_QuitarParesUnicos(Marca, Modelo)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
