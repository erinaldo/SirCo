Public Class BCLVentasCero

    Implements IDisposable
    Private objDALVentasCero As DAL.DALVentasCero
    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable 
#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALVentasCero = New DAL.DALVentasCero(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALVentasCero.Dispose()
            objDALVentasCero = Nothing
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

    Public Function usp_PpalSVentas(ByVal Sucursal As String, ByVal FecIni As String, ByVal FecFin As String, ByVal IdDivision As Integer, _
                                    ByVal IdDepto As Integer, ByVal DescripFamilia As String, ByVal DescripLinea As String, _
                                    ByVal DescripL1 As String, ByVal DescripL2 As String, ByVal DescripL3 As String, ByVal DescripL4 As String, _
                                    ByVal DescripL5 As String, ByVal DescripL6 As String, ByVal Marca As String, ByVal Modelo As String, _
                                    ByVal FecReciIni As String, ByVal FecReciFin As String, ByVal CtdIni As Integer, ByVal CtdFin As Integer) As DataSet
        'Tony Garcia - 29/Nov/2013 - 11:00 am
        Try
            'Call the data component to get all groups
            usp_PpalSVentas = objDALVentasCero.usp_PpalSVentas(Sucursal, FecIni, FecFin, IdDivision, IdDepto, DescripFamilia, DescripLinea, DescripL1, _
                                                               DescripL2, DescripL3, DescripL4, DescripL5, DescripL6, Marca, Modelo, FecReciIni, FecReciFin, CtdIni, CtdFin)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalSVentasDivisiones(ByVal Sucursal As String, ByVal FecIni As String, ByVal FecFin As String, ByVal IdDivision As Integer, _
                                    ByVal IdDepto As Integer, ByVal DescripFamilia As String, ByVal DescripLinea As String, _
                                    ByVal DescripL1 As String, ByVal DescripL2 As String, ByVal DescripL3 As String, ByVal DescripL4 As String, _
                                    ByVal DescripL5 As String, ByVal DescripL6 As String, ByVal Marca As String, ByVal Modelo As String, _
                                    ByVal FecReciIni As String, ByVal FecReciFin As String, ByVal CtdIni As Integer, ByVal CtdFin As Integer) As DataSet
        'Tony Garcia - 02/Dic/2013 - 04:45 pm
        Try
            'Call the data component to get all groups
            usp_PpalSVentasDivisiones = objDALVentasCero.usp_PpalSVentasDivisiones(Sucursal, FecIni, FecFin, IdDivision, IdDepto, DescripFamilia, DescripLinea, DescripL1, _
                                                               DescripL2, DescripL3, DescripL4, DescripL5, DescripL6, Marca, Modelo, FecReciIni, FecReciFin, CtdIni, CtdFin)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalSVentasDepto(ByVal Sucursal As String, ByVal FecIni As String, ByVal FecFin As String, ByVal IdDivision As Integer, _
                                    ByVal IdDepto As Integer, ByVal DescripFamilia As String, ByVal DescripLinea As String, _
                                    ByVal DescripL1 As String, ByVal DescripL2 As String, ByVal DescripL3 As String, ByVal DescripL4 As String, _
                                    ByVal DescripL5 As String, ByVal DescripL6 As String, ByVal Marca As String, ByVal Modelo As String, _
                                    ByVal FecReciIni As String, ByVal FecReciFin As String, ByVal CtdIni As Integer, ByVal CtdFin As Integer) As DataSet
        'Tony Garcia - 02/Dic/2013 - 04:45 pm
        Try
            'Call the data component to get all groups
            usp_PpalSVentasDepto = objDALVentasCero.usp_PpalSVentasDepto(Sucursal, FecIni, FecFin, IdDivision, IdDepto, DescripFamilia, DescripLinea, DescripL1, _
                                                               DescripL2, DescripL3, DescripL4, DescripL5, DescripL6, Marca, Modelo, FecReciIni, FecReciFin, CtdIni, CtdFin)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalSVentasFamilia(ByVal Sucursal As String, ByVal FecIni As String, ByVal FecFin As String, ByVal IdDivision As Integer, _
                                    ByVal IdDepto As Integer, ByVal DescripFamilia As String, ByVal DescripLinea As String, _
                                    ByVal DescripL1 As String, ByVal DescripL2 As String, ByVal DescripL3 As String, ByVal DescripL4 As String, _
                                    ByVal DescripL5 As String, ByVal DescripL6 As String, ByVal Marca As String, ByVal Modelo As String, _
                                    ByVal FecReciIni As String, ByVal FecReciFin As String, ByVal CtdIni As Integer, ByVal CtdFin As Integer) As DataSet
        'Tony Garcia - 02/Dic/2013 - 04:45 pm
        Try
            'Call the data component to get all groups
            usp_PpalSVentasFamilia = objDALVentasCero.usp_PpalSVentasFamilia(Sucursal, FecIni, FecFin, IdDivision, IdDepto, DescripFamilia, DescripLinea, DescripL1, _
                                                               DescripL2, DescripL3, DescripL4, DescripL5, DescripL6, Marca, Modelo, FecReciIni, FecReciFin, CtdIni, CtdFin)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalSVentasLinea(ByVal Sucursal As String, ByVal FecIni As String, ByVal FecFin As String, ByVal IdDivision As Integer, _
                                    ByVal IdDepto As Integer, ByVal DescripFamilia As String, ByVal DescripLinea As String, _
                                    ByVal DescripL1 As String, ByVal DescripL2 As String, ByVal DescripL3 As String, ByVal DescripL4 As String, _
                                    ByVal DescripL5 As String, ByVal DescripL6 As String, ByVal Marca As String, ByVal Modelo As String, _
                                    ByVal FecReciIni As String, ByVal FecReciFin As String, ByVal CtdIni As Integer, ByVal CtdFin As Integer) As DataSet
        'Tony Garcia - 02/Dic/2013 - 04:45 pm
        Try
            'Call the data component to get all groups
            usp_PpalSVentasLinea = objDALVentasCero.usp_PpalSVentasLinea(Sucursal, FecIni, FecFin, IdDivision, IdDepto, DescripFamilia, DescripLinea, DescripL1, _
                                                               DescripL2, DescripL3, DescripL4, DescripL5, DescripL6, Marca, Modelo, FecReciIni, FecReciFin, CtdIni, CtdFin)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalSVentasL1(ByVal Sucursal As String, ByVal FecIni As String, ByVal FecFin As String, ByVal IdDivision As Integer, _
                                    ByVal IdDepto As Integer, ByVal DescripFamilia As String, ByVal DescripLinea As String, _
                                    ByVal DescripL1 As String, ByVal DescripL2 As String, ByVal DescripL3 As String, ByVal DescripL4 As String, _
                                    ByVal DescripL5 As String, ByVal DescripL6 As String, ByVal Marca As String, ByVal Modelo As String, _
                                    ByVal FecReciIni As String, ByVal FecReciFin As String, ByVal CtdIni As Integer, ByVal CtdFin As Integer) As DataSet
        'Tony Garcia - 02/Dic/2013 - 04:45 pm
        Try
            'Call the data component to get all groups
            usp_PpalSVentasL1 = objDALVentasCero.usp_PpalSVentasL1(Sucursal, FecIni, FecFin, IdDivision, IdDepto, DescripFamilia, DescripLinea, DescripL1, _
                                                               DescripL2, DescripL3, DescripL4, DescripL5, DescripL6, Marca, Modelo, FecReciIni, FecReciFin, CtdIni, CtdFin)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalSVentasL2(ByVal Sucursal As String, ByVal FecIni As String, ByVal FecFin As String, ByVal IdDivision As Integer, _
                                    ByVal IdDepto As Integer, ByVal DescripFamilia As String, ByVal DescripLinea As String, _
                                    ByVal DescripL1 As String, ByVal DescripL2 As String, ByVal DescripL3 As String, ByVal DescripL4 As String, _
                                    ByVal DescripL5 As String, ByVal DescripL6 As String, ByVal Marca As String, ByVal Modelo As String, _
                                    ByVal FecReciIni As String, ByVal FecReciFin As String, ByVal CtdIni As Integer, ByVal CtdFin As Integer) As DataSet
        'Tony Garcia - 02/Dic/2013 - 04:45 pm
        Try
            'Call the data component to get all groups
            usp_PpalSVentasL2 = objDALVentasCero.usp_PpalSVentasL2(Sucursal, FecIni, FecFin, IdDivision, IdDepto, DescripFamilia, DescripLinea, DescripL1, _
                                                               DescripL2, DescripL3, DescripL4, DescripL5, DescripL6, Marca, Modelo, FecReciIni, FecReciFin, CtdIni, CtdFin)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalSVentasL3(ByVal Sucursal As String, ByVal FecIni As String, ByVal FecFin As String, ByVal IdDivision As Integer, _
                                    ByVal IdDepto As Integer, ByVal DescripFamilia As String, ByVal DescripLinea As String, _
                                    ByVal DescripL1 As String, ByVal DescripL2 As String, ByVal DescripL3 As String, ByVal DescripL4 As String, _
                                    ByVal DescripL5 As String, ByVal DescripL6 As String, ByVal Marca As String, ByVal Modelo As String, _
                                    ByVal FecReciIni As String, ByVal FecReciFin As String, ByVal CtdIni As Integer, ByVal CtdFin As Integer) As DataSet
        'Tony Garcia - 02/Dic/2013 - 04:45 pm
        Try
            'Call the data component to get all groups
            usp_PpalSVentasL3 = objDALVentasCero.usp_PpalSVentasL3(Sucursal, FecIni, FecFin, IdDivision, IdDepto, DescripFamilia, DescripLinea, DescripL1, _
                                                               DescripL2, DescripL3, DescripL4, DescripL5, DescripL6, Marca, Modelo, FecReciIni, FecReciFin, CtdIni, CtdFin)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalSVentasL4(ByVal Sucursal As String, ByVal FecIni As String, ByVal FecFin As String, ByVal IdDivision As Integer, _
                                    ByVal IdDepto As Integer, ByVal DescripFamilia As String, ByVal DescripLinea As String, _
                                    ByVal DescripL1 As String, ByVal DescripL2 As String, ByVal DescripL3 As String, ByVal DescripL4 As String, _
                                    ByVal DescripL5 As String, ByVal DescripL6 As String, ByVal Marca As String, ByVal Modelo As String, _
                                    ByVal FecReciIni As String, ByVal FecReciFin As String, ByVal CtdIni As Integer, ByVal CtdFin As Integer) As DataSet
        'Tony Garcia - 02/Dic/2013 - 04:45 pm
        Try
            'Call the data component to get all groups
            usp_PpalSVentasL4 = objDALVentasCero.usp_PpalSVentasL4(Sucursal, FecIni, FecFin, IdDivision, IdDepto, DescripFamilia, DescripLinea, DescripL1, _
                                                               DescripL2, DescripL3, DescripL4, DescripL5, DescripL6, Marca, Modelo, FecReciIni, FecReciFin, CtdIni, CtdFin)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalSVentasL5(ByVal Sucursal As String, ByVal FecIni As String, ByVal FecFin As String, ByVal IdDivision As Integer, _
                                    ByVal IdDepto As Integer, ByVal DescripFamilia As String, ByVal DescripLinea As String, _
                                    ByVal DescripL1 As String, ByVal DescripL2 As String, ByVal DescripL3 As String, ByVal DescripL4 As String, _
                                    ByVal DescripL5 As String, ByVal DescripL6 As String, ByVal Marca As String, ByVal Modelo As String, _
                                    ByVal FecReciIni As String, ByVal FecReciFin As String, ByVal CtdIni As Integer, ByVal CtdFin As Integer) As DataSet
        'Tony Garcia - 02/Dic/2013 - 04:45 pm
        Try
            'Call the data component to get all groups
            usp_PpalSVentasL5 = objDALVentasCero.usp_PpalSVentasL5(Sucursal, FecIni, FecFin, IdDivision, IdDepto, DescripFamilia, DescripLinea, DescripL1, _
                                                               DescripL2, DescripL3, DescripL4, DescripL5, DescripL6, Marca, Modelo, FecReciIni, FecReciFin, CtdIni, CtdFin)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalSVentasL6(ByVal Sucursal As String, ByVal FecIni As String, ByVal FecFin As String, ByVal IdDivision As Integer, _
                                    ByVal IdDepto As Integer, ByVal DescripFamilia As String, ByVal DescripLinea As String, _
                                    ByVal DescripL1 As String, ByVal DescripL2 As String, ByVal DescripL3 As String, ByVal DescripL4 As String, _
                                    ByVal DescripL5 As String, ByVal DescripL6 As String, ByVal Marca As String, ByVal Modelo As String, _
                                    ByVal FecReciIni As String, ByVal FecReciFin As String, ByVal CtdIni As Integer, ByVal CtdFin As Integer) As DataSet
        'Tony Garcia - 02/Dic/2013 - 04:45 pm
        Try
            'Call the data component to get all groups
            usp_PpalSVentasL6 = objDALVentasCero.usp_PpalSVentasL6(Sucursal, FecIni, FecFin, IdDivision, IdDepto, DescripFamilia, DescripLinea, DescripL1, _
                                                               DescripL2, DescripL3, DescripL4, DescripL5, DescripL6, Marca, Modelo, FecReciIni, FecReciFin, CtdIni, CtdFin)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalSVentasMarca(ByVal Sucursal As String, ByVal FecIni As String, ByVal FecFin As String, ByVal IdDivision As Integer, _
                                    ByVal IdDepto As Integer, ByVal DescripFamilia As String, ByVal DescripLinea As String, _
                                    ByVal DescripL1 As String, ByVal DescripL2 As String, ByVal DescripL3 As String, ByVal DescripL4 As String, _
                                    ByVal DescripL5 As String, ByVal DescripL6 As String, ByVal Marca As String, ByVal Modelo As String, _
                                    ByVal FecReciIni As String, ByVal FecReciFin As String, ByVal CtdIni As Integer, ByVal CtdFin As Integer) As DataSet
        'Tony Garcia - 02/Dic/2013 - 04:45 pm
        Try
            'Call the data component to get all groups
            usp_PpalSVentasMarca = objDALVentasCero.usp_PpalSVentasMarca(Sucursal, FecIni, FecFin, IdDivision, IdDepto, DescripFamilia, DescripLinea, DescripL1, _
                                                               DescripL2, DescripL3, DescripL4, DescripL5, DescripL6, Marca, Modelo, FecReciIni, FecReciFin, CtdIni, CtdFin)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalSVentasModelo(ByVal Sucursal As String, ByVal FecIni As String, ByVal FecFin As String, ByVal IdDivision As Integer, _
                                    ByVal IdDepto As Integer, ByVal DescripFamilia As String, ByVal DescripLinea As String, _
                                    ByVal DescripL1 As String, ByVal DescripL2 As String, ByVal DescripL3 As String, ByVal DescripL4 As String, _
                                    ByVal DescripL5 As String, ByVal DescripL6 As String, ByVal Marca As String, ByVal Modelo As String, _
                                    ByVal FecReciIni As String, ByVal FecReciFin As String, ByVal CtdIni As Integer, ByVal CtdFin As Integer) As DataSet
        'Tony Garcia - 02/Dic/2013 - 04:45 pm
        Try
            'Call the data component to get all groups
            usp_PpalSVentasModelo = objDALVentasCero.usp_PpalSVentasModelo(Sucursal, FecIni, FecFin, IdDivision, IdDepto, DescripFamilia, DescripLinea, DescripL1, _
                                                               DescripL2, DescripL3, DescripL4, DescripL5, DescripL6, Marca, Modelo, FecReciIni, FecReciFin, CtdIni, CtdFin)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_GeneraExist(ByVal Fecha As String, ByVal Actualiza As Boolean) As Boolean
        Try
            usp_GeneraExist = objDALVentasCero.usp_GeneraExist(Fecha, Actualiza)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerFecUltBitacora(ByVal Tipo As String) As DataSet
        'Tony Garcia - 23/01/2014 - 04:45 pm
        Try
            usp_TraerFecUltBitacora = objDALVentasCero.usp_TraerFecUltBitacora(Tipo)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
