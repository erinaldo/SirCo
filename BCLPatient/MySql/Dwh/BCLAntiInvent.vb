Public Class BCLAntiInvent
    'mreyes 18/Octubre/2012 02:06 p.m.

    Implements IDisposable
    Private objDALAntiInvent As DAL.DALAntiInvent
    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALAntiInvent = New DAL.DALAntiInvent(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALAntiInvent.Dispose()
            objDALAntiInvent = Nothing
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
    Public Function usp_PpalDetAntiInvent(ByVal SucursalB As String, ByVal Marca As String, ByVal IdDivision As Integer, ByVal IdDepto As Integer, ByVal IdFamilia As Integer, ByVal IdLinea As Integer, _
                                        ByVal IdL1 As Integer, ByVal IdL2 As Integer, ByVal IdL3 As Integer, ByVal IdL4 As Integer, ByVal IdL5 As Integer, _
                                        ByVal IdL6 As Integer, ByVal DiasIni As Integer, ByVal DiasFin As Integer) As DataSet
        'mreyes 18/Octubre/2012 04:08 p.m.
        Try
            usp_PpalDetAntiInvent = objDALAntiInvent.usp_PpalDetAntiInvent(SucursalB, Marca, IdDivision, IdDepto, _
                                                                           IdFamilia, IdLinea, IdL1, IdL2, IdL3, IdL4, IdL5, IdL6, DiasIni, DiasFin)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_PpalDetAntiInventSinOzo(ByVal SucursalB As String, ByVal Marca As String, ByVal TipoArtB As String, ByVal DiasIni As Integer, ByVal DiasFin As Integer) As DataSet
        'mreyes 18/Octubre/2012 04:08 p.m.
        Try
            usp_PpalDetAntiInventSinOzo = objDALAntiInvent.usp_PpalDetAntiInventSinOzo(SucursalB, Marca, TipoArtB, DiasIni, DiasFin)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalInventarioTiendas(ByVal SucursalB As String, ByVal IdDivision As Integer, ByVal IdDepto As Integer, ByVal IdFamilia As Integer, ByVal IdLinea As Integer, _
                                        ByVal IdL1 As Integer, ByVal IdL2 As Integer, ByVal IdL3 As Integer, ByVal IdL4 As Integer, ByVal IdL5 As Integer, _
                                        ByVal IdL6 As Integer) As DataSet
        'mreyes 18/Octubre/2012 04:08 p.m.
        Try
            usp_PpalInventarioTiendas = objDALAntiInvent.usp_PpalInventarioTiendas(SucursalB, IdDivision, IdDepto, _
                                                                                                       IdFamilia, IdLinea, IdL1, IdL2, IdL3, IdL4, IdL5, IdL6)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalInventarioTiendasDesglosado(ByVal SucursalB As String, ByVal Marca As String, _
                                        ByVal Modelo As String, ByVal EstiloF As String, ByVal IdDivision As Integer, ByVal IdDepto As Integer, ByVal IdFamilia As Integer, ByVal IdLinea As Integer, _
                                        ByVal IdL1 As Integer, ByVal IdL2 As Integer, ByVal IdL3 As Integer, ByVal IdL4 As Integer, ByVal IdL5 As Integer, _
                                        ByVal IdL6 As Integer, ByVal Proveedor As String) As DataSet
        'miguel pérez 05/Noviembre/2012 10:12 a.m.
        Try
            usp_PpalInventarioTiendasDesglosado = objDALAntiInvent.usp_PpalInventarioTiendasDesglosado(SucursalB, Marca, Modelo, EstiloF, IdDivision, IdDepto, _
                                                                                                       IdFamilia, IdLinea, IdL1, IdL2, IdL3, IdL4, IdL5, IdL6, Proveedor)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalInventarioTiendasSinOzo(ByVal SucursalB As String, ByVal TipoArt As String) As DataSet
        'mreyes 18/Octubre/2012 04:08 p.m.
        Try
            usp_PpalInventarioTiendasSinOzo = objDALAntiInvent.usp_PpalInventarioTiendasSinOzo(SucursalB, TipoArt)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_PpalInventarioTiendasSinOzoResumen(ByVal SucursalB As String, ByVal TipoArt As String) As DataSet
        'mreyes 18/Octubre/2012 04:08 p.m.
        Try
            usp_PpalInventarioTiendasSinOzoResumen = objDALAntiInvent.usp_PpalInventarioTiendasSinOzoResumen(SucursalB, TipoArt)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_PpalInventarioMarcas(ByVal SucursalB As String, ByVal IdDivision As Integer, ByVal IdDepto As Integer, ByVal IdFamilia As Integer, ByVal IdLinea As Integer, _
                                        ByVal IdL1 As Integer, ByVal IdL2 As Integer, ByVal IdL3 As Integer, ByVal IdL4 As Integer, ByVal IdL5 As Integer, _
                                        ByVal IdL6 As Integer, ByVal Marca As String) As DataSet
        'mreyes 18/Octubre/2012 04:08 p.m.
        Try
            usp_PpalInventarioMarcas = objDALAntiInvent.usp_PpalInventarioMarcas(SucursalB, IdDivision, IdDepto, _
                                                                                IdFamilia, IdLinea, IdL1, IdL2, IdL3, IdL4, IdL5, IdL6, Marca)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalInventarioMarcasSinOzo(ByVal SucursalB As String, ByVal TipoArt As String, ByVal Marca As String) As DataSet
        'mreyes 18/Octubre/2012 04:08 p.m.
        Try
            usp_PpalInventarioMarcasSinOzo = objDALAntiInvent.usp_PpalInventarioMarcasSinOzo(SucursalB, TipoArt, Marca)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalInventarioResumenTiendas(ByVal SucursalB As String, ByVal TipoArt As String) As DataSet
        'mreyes 19/Octubre/2012 09:31 a.m.
        Try
            usp_PpalInventarioResumenTiendas = objDALAntiInvent.usp_PpalInventarioResumenTiendas(SucursalB, TipoArt)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalInventarioResumenTiendasSinOzo(ByVal SucursalB As String, ByVal TipoArt As String) As DataSet
        'mreyes 19/Octubre/2012 09:31 a.m.
        Try
            usp_PpalInventarioResumenTiendasSinOzo = objDALAntiInvent.usp_PpalInventarioResumenTiendasSinOzo(SucursalB, TipoArt)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerFecUltMod(ByVal Opcion As Integer) As DataSet
        'miguel pérez 20/Octubre/2012 09:56 a.m.
        Try
            usp_TraerFecUltMod = objDALAntiInvent.usp_TraerFecUltMod(Opcion)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalInventarioPorcDias(ByVal SucursalB As String, ByVal TipoArt As String) As DataSet
        'miguel pérez 20/Octubre/2012 11:09 a.m.
        Try
            usp_PpalInventarioPorcDias = objDALAntiInvent.usp_PpalInventarioPorcDias(SucursalB, TipoArt)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalInventarioFamLineaResumen(ByVal SucursalB As String, ByVal TipoArt As String) As DataSet
        'miguel pérez 20/Noviembre/2012 12:45 p.m.
        Try
            usp_PpalInventarioFamLineaResumen = objDALAntiInvent.usp_PpalInventarioFamLineaResumen(SucursalB, TipoArt)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalInventarioFamLineaSinOzonoResumen(ByVal SucursalB As String, ByVal TipoArt As String) As DataSet
        'miguel pérez 20/Noviembre/2012 12:45 p.m.
        Try
            usp_PpalInventarioFamLineaSinOzonoResumen = objDALAntiInvent.usp_PpalInventarioFamLineaSinOzonoResumen(SucursalB, TipoArt)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerFolioInvent(ByVal Opcion As String) As DataSet
        'miguel pérez 24/Noviembre/2012 09:10 a.m.
        Try
            usp_TraerFolioInvent = objDALAntiInvent.usp_TraerFolioInvent(Opcion)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_InsertaInventario(ByVal Opcion As String, ByVal Folio As Integer, ByVal Fecha As String, ByVal Hora As String) As Boolean
        'miguel pérez 24/Noviembre/2012 09:11 a.m.
        Try
            usp_InsertaInventario = objDALAntiInvent.usp_InsertaInventario(Opcion, Folio, Fecha, Hora)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_InsertaDetInventario(ByVal Opcion As Integer, ByVal objDataSet As DataSet) As Boolean
        'miguel pérez 26/Noviembre/2012 09:12 a.m.
        Try
            usp_InsertaDetInventario = objDALAntiInvent.usp_InsertaDetInventario(Opcion, objDataSet)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerFecHora(ByVal Opcion As String, ByVal Fecha As String, ByVal Hora As String) As DataSet
        'miguel pérez 24/Noviembre/2012 09:10 a.m.
        Try
            usp_TraerFecHora = objDALAntiInvent.usp_TraerFecHora(Opcion, Fecha, Hora)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalInventarioTiendasEstructura(ByVal Opcion As Integer, ByVal Plaza As String, ByVal Sucursales As String, ByVal Division As String, ByVal Depto As String, ByVal Familia As String, ByVal Linea As String, _
                                                        ByVal L1 As String, ByVal L2 As String, ByVal L3 As String, ByVal L4 As String, ByVal L5 As String, ByVal L6 As String, ByVal Marca As String, ByVal Modelo As String, ByVal DiasIni As Integer, ByVal DiasFin As Integer, ByVal Opcion2 As Integer) As DataSet
        'miguel pérez 24/Noviembre/2012 09:10 a.m.
        Try
            usp_PpalInventarioTiendasEstructura = objDALAntiInvent.usp_PpalInventarioTiendasEstructura(Opcion, Plaza, Sucursales, Division, Depto, Familia, Linea, L1, L2, L3, L4, L5, L6, Marca, Modelo, DiasIni, DiasFin, Opcion2)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerInventario(ByVal Opcion As Integer, ByVal Plaza As Integer, ByVal Sucursales As String, ByVal Division As String, ByVal Depto As String, ByVal Familia As String, ByVal Linea As String, _
                                                        ByVal L1 As String, ByVal L2 As String, ByVal L3 As String, ByVal L4 As String, ByVal L5 As String, ByVal L6 As String, ByVal Marca As String, ByVal Modelo As String, _
                                                        ByVal NomTabla As String, ByVal IdAgrupacion As Integer, ByVal MInicio As String) As DataSet
        'miguel pérez 24/Noviembre/2012 09:10 a.m.
        Try
            usp_TraerInventario = objDALAntiInvent.usp_TraerInventario(Opcion, Plaza, Sucursales, Division, Depto, Familia, Linea, L1, L2, L3, L4, L5, L6, Marca, Modelo, NomTabla, IdAgrupacion, MInicio)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerBitacora(ByVal Opcion As Integer, ByVal Tipo As String, ByVal FechaIni As Date, ByVal FechaFin As Date) As DataSet
        'miguel pérez 24/Noviembre/2012 09:10 a.m.
        Try
            usp_TraerBitacora = objDALAntiInvent.usp_TraerBitacora(Opcion, Tipo, FechaIni, FechaFin)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
