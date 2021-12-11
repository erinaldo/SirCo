Imports System.Data.Odbc
'miguel pérez 09/Octubre/2012 10:43 a.m.

Public Class DALAntiInvent
    Inherits DALOdbc
#Region "Constructor And Destructor"
    Sub New(ByVal ConString As String)
        MyBase.New(ConString)
    End Sub

    Public Shadows Sub Dispose()
        MyBase.Dispose()
    End Sub
#End Region

#Region " Public Role Functions "

    Public Function usp_PpalDetAntiInvent(ByVal SucursalB As String, ByVal Marca As String, ByVal IdDivision As Integer, ByVal IdDepto As Integer, ByVal IdFamilia As Integer, ByVal IdLinea As Integer, _
                                        ByVal IdL1 As Integer, ByVal IdL2 As Integer, ByVal IdL3 As Integer, ByVal IdL4 As Integer, ByVal IdL5 As Integer, _
                                        ByVal IdL6 As Integer, ByVal DiasIni As Integer, ByVal DiasFin As Integer) As DataSet
        'mreyes 18/Octubre/2012 02:08 p.m.
        'Sucursalb char(2), MarcaB char(3),DiasIniB integer,DiasFinB integer

        Try
            usp_PpalDetAntiInvent = New DataSet
            MyBase.SQL = "CALL usp_PpalDetAntiInvent(?,?,?,?,?,?,?,?,?,?,?,?,?,?)"


            MyBase.InitializeCommand()
            MyBase.AddParameter("@sucursalb", OdbcType.Char, 2, SucursalB)
            MyBase.AddParameter("@marca", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@iddivisionb", OdbcType.Int, 16, IdDivision)
            MyBase.AddParameter("@iddeptob", OdbcType.Int, 16, IdDepto)
            MyBase.AddParameter("@idfamiliab", OdbcType.Int, 16, IdFamilia)
            MyBase.AddParameter("@idlineab", OdbcType.Int, 16, IdLinea)
            MyBase.AddParameter("@idl1b", OdbcType.Int, 16, IdL1)
            MyBase.AddParameter("@idl2b", OdbcType.Int, 16, IdL2)
            MyBase.AddParameter("@idl3b", OdbcType.Int, 16, IdL3)
            MyBase.AddParameter("@idl4b", OdbcType.Int, 16, IdL4)
            MyBase.AddParameter("@idl5b", OdbcType.Int, 16, IdL5)
            MyBase.AddParameter("@idl6b", OdbcType.Int, 16, IdL6)
            MyBase.AddParameter("@DiasIni", OdbcType.Int, 8, DiasIni)
            MyBase.AddParameter("@diasFin", OdbcType.Int, 8, DiasFin)


            MyBase.FillDataSet(usp_PpalDetAntiInvent, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalDetAntiInventSinOzo(ByVal SucursalB As String, ByVal Marca As String, ByVal TipoArt As String, ByVal DiasIni As Integer, ByVal DiasFin As Integer) As DataSet
        'mreyes 18/Octubre/2012 02:08 p.m.
        'Sucursalb char(2), MarcaB char(3),DiasIniB integer,DiasFinB integer

        Try
            usp_PpalDetAntiInventSinOzo = New DataSet
            MyBase.SQL = "CALL usp_PpalDetAntiInventSinOzo(?,?,?,?,?)"


            MyBase.InitializeCommand()
            MyBase.AddParameter("@sucursalb", OdbcType.Char, 2, SucursalB)
            MyBase.AddParameter("@marca", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@tipoart", OdbcType.Char, 1, TipoArt)
            MyBase.AddParameter("@DiasIni", OdbcType.Int, 8, DiasIni)
            MyBase.AddParameter("@diasFin", OdbcType.Int, 8, DiasFin)


            MyBase.FillDataSet(usp_PpalDetAntiInventSinOzo, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalInventarioTiendas(ByVal SucursalB As String, ByVal IdDivision As Integer, ByVal IdDepto As Integer, ByVal IdFamilia As Integer, ByVal IdLinea As Integer, _
                                        ByVal IdL1 As Integer, ByVal IdL2 As Integer, ByVal IdL3 As Integer, ByVal IdL4 As Integer, ByVal IdL5 As Integer, _
                                        ByVal IdL6 As Integer) As DataSet
        'mreyes 18/Octubre/2012 04:11 p.m.


        Try
            usp_PpalInventarioTiendas = New DataSet
            MyBase.SQL = "CALL usp_PpalInventarioTiendas(?,?,?,?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@sucursalb", OdbcType.Char, 2, SucursalB)
            MyBase.AddParameter("@iddivisionb", OdbcType.Int, 16, IdDivision)
            MyBase.AddParameter("@iddeptob", OdbcType.Int, 16, IdDepto)
            MyBase.AddParameter("@idfamiliab", OdbcType.Int, 16, IdFamilia)
            MyBase.AddParameter("@idlineab", OdbcType.Int, 16, IdLinea)
            MyBase.AddParameter("@idl1b", OdbcType.Int, 16, IdL1)
            MyBase.AddParameter("@idl2b", OdbcType.Int, 16, IdL2)
            MyBase.AddParameter("@idl3b", OdbcType.Int, 16, IdL3)
            MyBase.AddParameter("@idl4b", OdbcType.Int, 16, IdL4)
            MyBase.AddParameter("@idl5b", OdbcType.Int, 16, IdL5)
            MyBase.AddParameter("@idl6b", OdbcType.Int, 16, IdL6)


            MyBase.FillDataSet(usp_PpalInventarioTiendas, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalInventarioTiendasDesglosado(ByVal SucursalB As String, ByVal Marca As String, _
                                        ByVal Modelo As String, ByVal EstiloF As String, ByVal IdDivision As Integer, ByVal IdDepto As Integer, ByVal IdFamilia As Integer, ByVal IdLinea As Integer, _
                                        ByVal IdL1 As Integer, ByVal IdL2 As Integer, ByVal IdL3 As Integer, ByVal IdL4 As Integer, ByVal IdL5 As Integer, _
                                        ByVal IdL6 As Integer, ByVal Proveedor As String) As DataSet
        'miguel pérez 05/Noviembre/2012 10:11 a.m.


        Try
            usp_PpalInventarioTiendasDesglosado = New DataSet
            MyBase.SQL = "CALL usp_PpalInventarioTiendasDesglosado(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@sucursalb", OdbcType.Char, 2, SucursalB)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@ModeloB", OdbcType.Char, 7, Modelo)
            MyBase.AddParameter("@EstiloFB", OdbcType.Char, 14, EstiloF)
            MyBase.AddParameter("@idDivisionb", OdbcType.Int, 16, IdDivision)
            MyBase.AddParameter("@idDeptob", OdbcType.Int, 16, IdDepto)
            MyBase.AddParameter("@FamiliaB", OdbcType.Int, 16, IdFamilia)
            MyBase.AddParameter("@idLineaB", OdbcType.Int, 16, IdLinea)
            MyBase.AddParameter("@idL1B", OdbcType.Int, 16, IdL1)
            MyBase.AddParameter("@idL2B", OdbcType.Int, 16, IdL2)
            MyBase.AddParameter("@idL3B", OdbcType.Int, 16, IdL3)
            MyBase.AddParameter("@idL4B", OdbcType.Int, 16, IdL4)
            MyBase.AddParameter("@idL5B", OdbcType.Int, 16, IdL5)
            MyBase.AddParameter("@idL6B", OdbcType.Int, 16, IdL6)
            MyBase.AddParameter("@ProveedorB", OdbcType.Char, 3, Proveedor)


            MyBase.FillDataSet(usp_PpalInventarioTiendasDesglosado, "dwh")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_PpalInventarioTiendasSinOzo(ByVal SucursalB As String, ByVal TipoArt As String) As DataSet
        'mreyes 18/Octubre/2012 04:11 p.m.


        Try
            usp_PpalInventarioTiendasSinOzo = New DataSet
            MyBase.SQL = "CALL usp_PpalInventarioTiendasSinOzo(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@sucursalb", OdbcType.Char, 2, SucursalB)
            MyBase.AddParameter("@tipoart", OdbcType.Char, 1, TipoArt)


            MyBase.FillDataSet(usp_PpalInventarioTiendasSinOzo, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalInventarioTiendasSinOzoResumen(ByVal SucursalB As String, ByVal TipoArt As String) As DataSet
        'mreyes 18/Octubre/2012 04:11 p.m.


        Try
            usp_PpalInventarioTiendasSinOzoResumen = New DataSet
            MyBase.SQL = "CALL usp_PpalInventarioTiendasSinOzoResumen(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@sucursalb", OdbcType.Char, 2, SucursalB)
            MyBase.AddParameter("@tipoart", OdbcType.Char, 1, TipoArt)


            MyBase.FillDataSet(usp_PpalInventarioTiendasSinOzoResumen, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_PpalInventarioMarcas(ByVal SucursalB As String, ByVal IdDivision As Integer, ByVal IdDepto As Integer, ByVal IdFamilia As Integer, ByVal IdLinea As Integer, _
                                        ByVal IdL1 As Integer, ByVal IdL2 As Integer, ByVal IdL3 As Integer, ByVal IdL4 As Integer, ByVal IdL5 As Integer, _
                                        ByVal IdL6 As Integer, ByVal Marca As String) As DataSet
        'mreyes 18/Octubre/2012 04:11 p.m.


        Try
            usp_PpalInventarioMarcas = New DataSet
            MyBase.SQL = "CALL usp_PpalInventarioMarcas(?,?,?,?,?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@sucursalb", OdbcType.Char, 2, SucursalB)
            MyBase.AddParameter("@idDivisionb", OdbcType.Int, 16, IdDivision)
            MyBase.AddParameter("@idDeptob", OdbcType.Int, 16, IdDepto)
            MyBase.AddParameter("@FamiliaB", OdbcType.Int, 16, IdFamilia)
            MyBase.AddParameter("@idLineaB", OdbcType.Int, 16, IdLinea)
            MyBase.AddParameter("@idL1B", OdbcType.Int, 16, IdL1)
            MyBase.AddParameter("@idL2B", OdbcType.Int, 16, IdL2)
            MyBase.AddParameter("@idL3B", OdbcType.Int, 16, IdL3)
            MyBase.AddParameter("@idL4B", OdbcType.Int, 16, IdL4)
            MyBase.AddParameter("@idL5B", OdbcType.Int, 16, IdL5)
            MyBase.AddParameter("@idL6B", OdbcType.Int, 16, IdL6)
            MyBase.AddParameter("@marca", OdbcType.Char, 1, Marca)


            MyBase.FillDataSet(usp_PpalInventarioMarcas, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalInventarioMarcasSinOzo(ByVal SucursalB As String, ByVal TipoArt As String, ByVal Marca As String) As DataSet
        'mreyes 18/Octubre/2012 04:11 p.m.
        Try
            usp_PpalInventarioMarcasSinOzo = New DataSet
            MyBase.SQL = "CALL usp_PpalInventarioMarcasSinOzo(?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@sucursalb", OdbcType.Char, 2, SucursalB)
            MyBase.AddParameter("@tipoart", OdbcType.Char, 1, TipoArt)
            MyBase.AddParameter("@marca", OdbcType.Char, 1, Marca)


            MyBase.FillDataSet(usp_PpalInventarioMarcasSinOzo, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalInventarioResumenTiendas(ByVal SucursalB As String, ByVal TipoArt As String) As DataSet
        'mreyes 19/Octubre/2012 09:31 a.m.


        Try
            usp_PpalInventarioResumenTiendas = New DataSet
            MyBase.SQL = "CALL usp_PpalInventarioResumenTiendas(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@sucursalb", OdbcType.Char, 2, SucursalB)
            MyBase.AddParameter("@tipoart", OdbcType.Char, 1, TipoArt)


            MyBase.FillDataSet(usp_PpalInventarioResumenTiendas, "dwh")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_PpalInventarioResumenTiendasSinOzo(ByVal SucursalB As String, ByVal TipoArt As String) As DataSet
        'mreyes 19/Octubre/2012 09:31 a.m.


        Try
            usp_PpalInventarioResumenTiendasSinOzo = New DataSet
            MyBase.SQL = "CALL usp_PpalInventarioResumenTiendasSinOzo(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@sucursalb", OdbcType.Char, 2, SucursalB)
            MyBase.AddParameter("@tipoart", OdbcType.Char, 1, TipoArt)


            MyBase.FillDataSet(usp_PpalInventarioResumenTiendasSinOzo, "dwh")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerFecUltMod(ByVal Opcion As Integer) As DataSet
        'miguel pérez 20/Octubre/2012 09:54 a.m.
        Try
            usp_TraerFecUltMod = New DataSet
            MyBase.SQL = "CALL usp_TraerFecUltMod(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", OdbcType.Int, 8, Opcion)

            MyBase.FillDataSet(usp_TraerFecUltMod, "dwh")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalInventarioPorcDias(ByVal SucursalB As String, ByVal TipoArt As String) As DataSet
        'miguel pérez 20/Octubre/2012 11:07 a.m.
        Try
            usp_PpalInventarioPorcDias = New DataSet
            MyBase.SQL = "CALL usp_PpalInventarioPorcDias(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@sucursalb", OdbcType.Char, 2, SucursalB)
            MyBase.AddParameter("@tipoart", OdbcType.Char, 1, TipoArt)


            MyBase.FillDataSet(usp_PpalInventarioPorcDias, "dwh")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalInventarioFamLineaResumen(ByVal SucursalB As String, ByVal TipoArt As String) As DataSet
        'miguel pérez 20/Noviembre/2012 12:42 p.m.
        Try
            usp_PpalInventarioFamLineaResumen = New DataSet
            MyBase.SQL = "CALL usp_PpalInventarioFamLineaResumen(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@sucursalb", OdbcType.Char, 2, SucursalB)
            MyBase.AddParameter("@tipoart", OdbcType.Char, 1, TipoArt)

            MyBase.FillDataSet(usp_PpalInventarioFamLineaResumen, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalInventarioFamLineaSinOzonoResumen(ByVal SucursalB As String, ByVal TipoArt As String) As DataSet
        'miguel pérez 20/Noviembre/2012 12:44 p.m.
        Try
            usp_PpalInventarioFamLineaSinOzonoResumen = New DataSet
            MyBase.SQL = "CALL usp_PpalInventarioFamLineaSinOzonoResumen(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@sucursalb", OdbcType.Char, 2, SucursalB)
            MyBase.AddParameter("@tipoart", OdbcType.Char, 1, TipoArt)

            MyBase.FillDataSet(usp_PpalInventarioFamLineaSinOzonoResumen, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerFolioInvent(ByVal Opcion As String) As DataSet
        'miguel pérez 23/Noviembre/2012 04:38 p.m.
        Try
            usp_TraerFolioInvent = New DataSet
            MyBase.SQL = "CALL usp_TraerFolioInvent(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", OdbcType.Char, 1, Opcion)

            MyBase.FillDataSet(usp_TraerFolioInvent, "dwh")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_InsertaInventario(ByVal Opcion As Integer, ByVal Folio As Integer, ByVal Fecha As String, ByVal Hora As String) As Boolean
        'miguel pérez - 29/Noviembre/2012 - 5:00 p.m.
        Try
            MyBase.SQL = "Call usp_InsertaInventario(?,?,?,?)"
            MyBase.InitializeCommand()

            MyBase.AddParameter("@Opcion", OdbcType.Char, 1, Opcion)
            MyBase.AddParameter("@Folio", OdbcType.Int, 16, Folio)
            MyBase.AddParameter("@Fecha", OdbcType.Char, 10, Fecha)
            MyBase.AddParameter("@Hora", OdbcType.Char, 8, Hora)

            usp_InsertaInventario = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_InsertaDetInventario(ByVal Opcion As Integer, ByVal objDataSet As DataSet) As Boolean
        'miguel pérez - 29/Noviembre/2012 - 6:00 p.m.
        Try
            MyBase.SQL = "Call usp_InsertaDetInventario(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"
            MyBase.InitializeCommand()

            MyBase.AddParameter("@opcion", OdbcType.Int, 1, Opcion)
            MyBase.AddParameter("@Folio", OdbcType.Int, 16, objDataSet.Tables(0).Rows(0).Item("folio"))
            MyBase.AddParameter("@Sucursal", OdbcType.Char, 2, objDataSet.Tables(0).Rows(0).Item("sucursal"))
            MyBase.AddParameter("@descripsuc", OdbcType.Char, 20, objDataSet.Tables(0).Rows(0).Item("descripsuc"))
            MyBase.AddParameter("@Familia", OdbcType.Char, 3, objDataSet.Tables(0).Rows(0).Item("familia"))
            MyBase.AddParameter("@descripfamilia", OdbcType.Char, 20, objDataSet.Tables(0).Rows(0).Item("descripfamilia"))
            MyBase.AddParameter("@Linea", OdbcType.Char, 3, objDataSet.Tables(0).Rows(0).Item("linea"))
            MyBase.AddParameter("@descriplinea", OdbcType.Char, 20, objDataSet.Tables(0).Rows(0).Item("descriplinea"))
            MyBase.AddParameter("@dias_15", OdbcType.Int, 16, objDataSet.Tables(0).Rows(0).Item("dias_15"))
            MyBase.AddParameter("@porc_15", OdbcType.Double, 8, objDataSet.Tables(0).Rows(0).Item("porc_15"))
            MyBase.AddParameter("@dias_30", OdbcType.Int, 16, objDataSet.Tables(0).Rows(0).Item("dias_30"))
            MyBase.AddParameter("@porc_30", OdbcType.Double, 8, objDataSet.Tables(0).Rows(0).Item("porc_30"))
            MyBase.AddParameter("@dias_45", OdbcType.Int, 16, objDataSet.Tables(0).Rows(0).Item("dias_45"))
            MyBase.AddParameter("@porc_45", OdbcType.Double, 8, objDataSet.Tables(0).Rows(0).Item("porc_45"))
            MyBase.AddParameter("@dias_60", OdbcType.Int, 16, objDataSet.Tables(0).Rows(0).Item("dias_60"))
            MyBase.AddParameter("@porc_60", OdbcType.Double, 8, objDataSet.Tables(0).Rows(0).Item("porc_60"))
            MyBase.AddParameter("@dias_90", OdbcType.Int, 16, objDataSet.Tables(0).Rows(0).Item("dias_90"))
            MyBase.AddParameter("@porc_90", OdbcType.Double, 8, objDataSet.Tables(0).Rows(0).Item("porc_90"))
            MyBase.AddParameter("@dias_120", OdbcType.Int, 16, objDataSet.Tables(0).Rows(0).Item("dias_120"))
            MyBase.AddParameter("@porc_120", OdbcType.Double, 8, objDataSet.Tables(0).Rows(0).Item("porc_120"))
            MyBase.AddParameter("@dias_140", OdbcType.Int, 16, objDataSet.Tables(0).Rows(0).Item("dias_140"))
            MyBase.AddParameter("@porc_140", OdbcType.Double, 8, objDataSet.Tables(0).Rows(0).Item("porc_140"))
            MyBase.AddParameter("@dias_160", OdbcType.Int, 16, objDataSet.Tables(0).Rows(0).Item("dias_160"))
            MyBase.AddParameter("@porc_160", OdbcType.Double, 8, objDataSet.Tables(0).Rows(0).Item("porc_160"))
            MyBase.AddParameter("@dias_350", OdbcType.Int, 16, objDataSet.Tables(0).Rows(0).Item("dias_350"))
            MyBase.AddParameter("@porc_350", OdbcType.Double, 8, objDataSet.Tables(0).Rows(0).Item("porc_350"))
            MyBase.AddParameter("@dias_750", OdbcType.Int, 16, objDataSet.Tables(0).Rows(0).Item("dias_750"))
            MyBase.AddParameter("@porc_750", OdbcType.Double, 8, objDataSet.Tables(0).Rows(0).Item("porc_750"))
            MyBase.AddParameter("@dias_751", OdbcType.Int, 16, objDataSet.Tables(0).Rows(0).Item("dias_751"))
            MyBase.AddParameter("@porc_751", OdbcType.Double, 8, objDataSet.Tables(0).Rows(0).Item("porc_751"))
            MyBase.AddParameter("@total", OdbcType.Int, 16, objDataSet.Tables(0).Rows(0).Item("total"))
            MyBase.AddParameter("@porc_tot", OdbcType.Double, 8, objDataSet.Tables(0).Rows(0).Item("porc_tot"))
            usp_InsertaDetInventario = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerFecHora(ByVal Opcion As String, ByVal Fecha As String, ByVal Hora As String) As DataSet
        'miguel pérez 23/Noviembre/2012 04:38 p.m.
        Try
            usp_TraerFecHora = New DataSet
            MyBase.SQL = "CALL usp_TraerFecHora(?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", OdbcType.Char, 1, Opcion)
            MyBase.AddParameter("@FechaB", OdbcType.Char, 10, Fecha)
            MyBase.AddParameter("@HoraB", OdbcType.Char, 8, Hora)

            MyBase.FillDataSet(usp_TraerFecHora, "dwh")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_PpalInventarioTiendasEstructura(ByVal Opcion As Integer, ByVal Plaza As String, ByVal Sucursales As String, ByVal Division As String, ByVal Depto As String, ByVal Familia As String, ByVal Linea As String, _
                                                        ByVal L1 As String, ByVal L2 As String, ByVal L3 As String, ByVal L4 As String, ByVal L5 As String, ByVal L6 As String, ByVal Marca As String, ByVal Modelo As String, ByVal DiasIni As Integer, ByVal DiasFin As Integer, ByVal Opcion2 As Integer) As DataSet
        'miguel pérez 23/Noviembre/2012 04:38 p.m.
        Try
            usp_PpalInventarioTiendasEstructura = New DataSet
            MyBase.SQL = "CALL usp_PpalInventarioTiendasEstructura(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", OdbcType.Int, 8, Opcion)
            MyBase.AddParameter("@PlazaB", OdbcType.Char, 2, Plaza)
            MyBase.AddParameter("@SucursalesB", OdbcType.VarChar, 350, Sucursales)
            MyBase.AddParameter("@idDivisionB", OdbcType.Char, 30, Division)
            MyBase.AddParameter("@iddeptoB", OdbcType.Char, 30, Depto)
            MyBase.AddParameter("@idFamiliaB", OdbcType.Char, 30, Familia)
            MyBase.AddParameter("@idLineaB", OdbcType.Char, 30, Linea)
            MyBase.AddParameter("@idl1B", OdbcType.Char, 30, L1)
            MyBase.AddParameter("@idl2B", OdbcType.Char, 30, L2)
            MyBase.AddParameter("@idl3B", OdbcType.Char, 30, L3)
            MyBase.AddParameter("@idl4B", OdbcType.Char, 30, L4)
            MyBase.AddParameter("@idl5B", OdbcType.Char, 30, L5)
            MyBase.AddParameter("@idl6B", OdbcType.Char, 30, L6)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@ModeloB", OdbcType.Char, 7, Modelo)
            MyBase.AddParameter("@DiasIniB", OdbcType.Int, 8, DiasIni)
            MyBase.AddParameter("@DiasFinB", OdbcType.Int, 8, DiasFin)
            MyBase.AddParameter("@Opcion2B", OdbcType.Int, 8, Opcion2)

            MyBase.FillDataSet(usp_PpalInventarioTiendasEstructura, "dwh")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerInventario(ByVal Opcion As Integer, ByVal Plaza As Integer, ByVal Sucursales As String, ByVal Division As String, ByVal Depto As String, ByVal Familia As String, ByVal Linea As String, _
                                                        ByVal L1 As String, ByVal L2 As String, ByVal L3 As String, ByVal L4 As String, ByVal L5 As String, ByVal L6 As String, ByVal Marca As String, ByVal Modelo As String, _
                                                        ByVal NomTabla As String, ByVal IdAgrupacion As Integer, ByVal MInicio As String) As DataSet
        'miguel pérez 23/Noviembre/2012 04:38 p.m.
        Try
            usp_TraerInventario = New DataSet
            MyBase.SQL = "CALL usp_TraerInventario(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", OdbcType.Int, 8, Opcion)

            MyBase.AddParameter("@plazaB", OdbcType.Int, 8, Plaza)
            MyBase.AddParameter("@SucursalesB", OdbcType.VarChar, 350, Sucursales)
            MyBase.AddParameter("@idDivisionB", OdbcType.Char, 30, Division)
            MyBase.AddParameter("@iddeptoB", OdbcType.Char, 30, Depto)
            MyBase.AddParameter("@idFamiliaB", OdbcType.Char, 30, Familia)
            MyBase.AddParameter("@idLineaB", OdbcType.Char, 30, Linea)
            MyBase.AddParameter("@idl1B", OdbcType.Char, 30, L1)
            MyBase.AddParameter("@idl2B", OdbcType.Char, 30, L2)
            MyBase.AddParameter("@idl3B", OdbcType.Char, 30, L3)
            MyBase.AddParameter("@idl4B", OdbcType.Char, 30, L4)
            MyBase.AddParameter("@idl5B", OdbcType.Char, 30, L5)
            MyBase.AddParameter("@idl6B", OdbcType.Char, 30, L6)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@ModeloB", OdbcType.Char, 7, Modelo)
            MyBase.AddParameter("@NomTabla", OdbcType.Char, 500, NomTabla)
            MyBase.AddParameter("@IdAgrupacionb", OdbcType.Int, 8, IdAgrupacion)

            MyBase.AddParameter("@MInicioB", OdbcType.Char, 3, minicio)
            MyBase.FillDataSet(usp_TraerInventario, "dwh")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerBitacora(ByVal Opcion As Integer, ByVal Tipo As String, ByVal FechaIni As Date, ByVal FechaFin As Date) As DataSet
        'miguel pérez 23/Noviembre/2012 04:38 p.m.
        Try
            usp_TraerBitacora = New DataSet
            MyBase.SQL = "CALL usp_TraerBitacora(?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", OdbcType.Int, 8, Opcion)
            MyBase.AddParameter("@TipoB", OdbcType.Char, 20, Tipo)
            MyBase.AddParameter("@FechaIni", OdbcType.Date, 10, FechaIni)
            MyBase.AddParameter("@FechaFin", OdbcType.Date, 10, FechaFin)

            MyBase.FillDataSet(usp_TraerBitacora, "dwh")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

#End Region
End Class
