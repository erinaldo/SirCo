Public Class BCLValesPorNegocio
    ''Tony Garcia 13/Octubre/2012 - 12:00 p.m.
    Implements IDisposable
    Private objDALValesPorNegocio As DAL.DALValesPorNegocio
    Private disposedValue As Boolean = False        ' To detect redundant calls

#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALValesPorNegocio = New DAL.DALValesPorNegocio(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALValesPorNegocio.Dispose()
            objDALValesPorNegocio = Nothing
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

#Region " Public Patient Functions "
    Public Function usp_TraerNombreDistribuidor(ByVal Distribuidor As String) As DataSet
        'Tony Garcia - 17/Enero/2013 - 09:45 a.m.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALValesPorNegocio.usp_TraerNombreDistribuidor(Distribuidor)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerCtdValesPorNegocio(ByVal Sucursal As String, ByVal Fechaini As Date, ByVal Fechafin As Date)
        'Tony Garcia - 20/Noviembre/2012 - 10:05 a.m
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALValesPorNegocio.usp_TraerCtdValesPorNegocio(Sucursal, Fechaini, Fechafin)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerCtdValesPorSucursal(ByVal Sucursal As String, ByVal Fechaini As Date, ByVal Fechafin As Date)
        'juan - 4/enero/2014 - 09:57 a.m
        Try
            Return objDALValesPorNegocio.usp_TraerCtdValesPorSucursal(Sucursal, Fechaini, Fechafin)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_PpalDiarioVales(ByVal Sucursal As String, ByVal Nota As String, ByVal Vale As String, ByVal Estatus As String, _
                                        ByVal Distribuidor As String, ByVal Cliente As String, ByVal Fechaini As Date, ByVal Fechafin As Date) As DataSet
        'Tony Garcia - 17/Enero/2013 - 09:45 a.m.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALValesPorNegocio.usp_PpalDiarioVales(Sucursal, Nota, Estatus, Vale, Distribuidor, Cliente, Fechaini, Fechafin)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalVentasDistrib(ByVal DistribuidorIni As String, ByVal DistribuidorFin As String, _
                                         ByVal Sucursal As String, ByVal Estatus As String, _
                                         ByVal Fechaini As Date, ByVal Fechafin As Date) As DataSet
        'Tony Garcia - 02/Junio/2013 - 09:45 a.m.
        Try
            'Call the data component to add the new group
            Return objDALValesPorNegocio.usp_PpalVentasDistrib(DistribuidorIni, DistribuidorFin, Sucursal, Estatus, Fechaini, Fechafin)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalVentasDistribDet(ByVal Sucursal As String, ByVal Distribuidor As String, ByVal Fechaini As Date, ByVal Fechafin As Date) As DataSet
        'Tony Garcia - 03/Junio/2013 - 11:00 a.m.
        Try
            'Call the data component to add the new group
            Return objDALValesPorNegocio.usp_PpalVentasDistribDet(Sucursal, Distribuidor, Fechaini, Fechafin)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerDetalleVentasDistrib(ByVal Sucursal As String, ByVal Venta As String) As DataSet
        'Tony Garcia - 07/Junio/2013 - 11:00 a.m.
        Try
            'Call the data component to add the new group
            Return objDALValesPorNegocio.usp_TraerDetalleVentasDistrib(Sucursal, Venta)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalDiarioValesAdapter(ByVal Sucursal As String, ByVal Nota As String, ByVal Vale As String, ByVal Estatus As String, _
                                ByVal Distribuidor As String, ByVal Cliente As String, ByVal Fechaini As Date, ByVal Fechafin As Date, ByVal NegocioB As String) As DataSet
        'juan Galvan - 7/Enero/2014 - 10:53 a.m.
        Try
            Return objDALValesPorNegocio.usp_PpalDiarioValesAdapter(Sucursal, Nota, Estatus, Vale, Distribuidor, Cliente, Fechaini, Fechafin, NegocioB)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

#End Region
End Class
