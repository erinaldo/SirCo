Imports System.Data.Odbc
'miguel pérez 29/Diciembre/2012 01:44 p.m.

Public Class DALBulto
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

    Public Function usp_PpalBultosDetallado(ByVal Opcion As Integer, ByVal Sucursal As String) As DataSet
        'Tony Garcia - 24/Enero/2013 - 12:50 p.m.
        Try
            usp_PpalBultosDetallado = New DataSet
            MyBase.SQL = "CALL usp_PpalBultosDetallado(?,?)"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@Opcion", OdbcType.Int, 4, Opcion)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)

            'Execute the stored procedure
            MyBase.FillDataSet(usp_PpalBultosDetallado, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_PpalBultosDetalladoDet(ByVal Opcion As Integer, ByVal Sucursal As String, ByVal Proveedor As String, ByVal Noguia As String, _
                                                  ByVal Folio As Integer, ByVal Recibe As Integer, _
                                                  ByVal Asigna As Integer, ByVal FechaRecIni As String, ByVal FechaRecFin As String, _
                                                  ByVal FechaAsigIni As String, ByVal FechaAsigFin As String, ByVal CveSucursal As String, ByVal Status As String, ByVal Tipo As String) As DataSet
        'Tony Garcia - 24/Enero/2013 - 12:50 p.m.
        Try
            usp_PpalBultosDetalladoDet = New DataSet
            MyBase.SQL = "CALL usp_PpalBultosDetalladoDet(?,?,?,?,?,?,?,?,?,?,?,?,?,?)"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@Opcion", OdbcType.Int, 4, Opcion)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@ProveedorB", OdbcType.Char, 3, Proveedor)
            MyBase.AddParameter("@NoguiaB", OdbcType.Char, 20, Noguia)
            MyBase.AddParameter("@FolioB", OdbcType.Int, 8, Folio)
            MyBase.AddParameter("@RecibeB", OdbcType.Int, 4, Recibe)
            MyBase.AddParameter("@AsignaB", OdbcType.Int, 4, Asigna)
            MyBase.AddParameter("@fechareciniB", OdbcType.Char, 10, FechaRecIni)
            MyBase.AddParameter("@fecharecfinB", OdbcType.Char, 10, FechaRecFin)
            MyBase.AddParameter("@fechaasiginiB", OdbcType.Char, 10, FechaAsigIni)
            MyBase.AddParameter("@fechaasigfinB", OdbcType.Char, 10, FechaAsigFin)
            MyBase.AddParameter("@CveSucursalB", OdbcType.Char, 2, CveSucursal)
            MyBase.AddParameter("@StatusB", OdbcType.Char, 2, Status)
            MyBase.AddParameter("@TipoB", OdbcType.Char, 1, Tipo)

            'Execute the stored procedure
            MyBase.FillDataSet(usp_PpalBultosDetalladoDet, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_Captura_Plano(ByVal Marca As String, ByVal Estilon As String, ByVal Archivo As String) As Boolean
        'mreyes 01/Abril/2015   10:27 a.m.
        Try
            MyBase.SQL = "CALL usp_Captura_Plano(?,?,?)"

            MyBase.InitializeCommand()

            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)

            MyBase.AddParameter("@EstilonB", OdbcType.Char, 7, Estilon)
            MyBase.AddParameter("@EstilonB", OdbcType.Char, 30, Archivo)

            usp_Captura_Plano = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_Bulto(ByVal Opcion As Integer, ByVal IdFolioB As Integer, ByVal ProveedorB As String, ByVal MarcaB As String, ByVal NoGuiaB As String, _
                               ByVal TransportaB As String, ByVal NoBultosB As Decimal, ByVal NoSucursalB As Integer, _
                               ByVal comentariosB As String, ByVal RecibeB As Integer, ByVal fecrecibeB As Date, ByVal asignaB As Integer, ByVal fecasignaB As Date, _
                              ByVal usuarioB As String, ByVal fumB As DateTime, ByVal usuarioasignaB As String, ByVal fumasignaB As DateTime, ByVal detalleB As Integer, _
                              ByVal fumdetalleB As DateTime, ByVal EntraJaulaB As Integer, ByVal SaleJaulaB As Integer, ByVal SubecamionB As Integer, _
                                ByVal generotraspasoB As Integer, ByVal IdFolioSucB As String, ByVal statusb As String, ByVal tipob As String, ByVal SFb As Integer, ByVal paqueteria As String) As Boolean
        'miguel pérez 30/Diciembre/2012 09:30 a.m.
        Try
            MyBase.SQL = "CALL usp_Captura_Bulto(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@OpcionB", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@IdFolioB", OdbcType.Int, 16, IdFolioB)
            MyBase.AddParameter("@ProveedorB", OdbcType.Char, 3, ProveedorB)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, MarcaB)
            MyBase.AddParameter("@NoGuiaB", OdbcType.Char, 20, NoGuiaB)
            MyBase.AddParameter("@TransportaB", OdbcType.Char, 150, TransportaB)
            MyBase.AddParameter("@NoBultosB", OdbcType.Decimal, 8, NoBultosB)
            MyBase.AddParameter("@NoSucursalB", OdbcType.Int, 16, NoSucursalB)
            MyBase.AddParameter("@ComentariosB", OdbcType.Char, 250, comentariosB)
            MyBase.AddParameter("@RecibeB", OdbcType.Int, 16, RecibeB)
            MyBase.AddParameter("@fecrecibeb", OdbcType.Date, 8, fecrecibeB)
            MyBase.AddParameter("@Asignab", OdbcType.Int, 16, asignaB)
            MyBase.AddParameter("@fecasignab", OdbcType.Date, 8, fecasignaB)
            MyBase.AddParameter("@usuarioB", OdbcType.Char, 8, usuarioB)
            MyBase.AddParameter("@fumb", OdbcType.DateTime, 16, fumB)
            MyBase.AddParameter("@usuarioasignab", OdbcType.Char, 8, usuarioasignaB)
            MyBase.AddParameter("@fumasignab", OdbcType.DateTime, 16, fumasignaB)
            MyBase.AddParameter("@detalleb", OdbcType.Int, 16, detalleB)
            MyBase.AddParameter("@fumdetalleb", OdbcType.DateTime, 16, fumdetalleB)
            MyBase.AddParameter("@entrajaulaB", OdbcType.Int, 16, EntraJaulaB)
            MyBase.AddParameter("@salejaulaB", OdbcType.Int, 16, SaleJaulaB)
            MyBase.AddParameter("@subecamionB", OdbcType.Int, 16, SubecamionB)
            MyBase.AddParameter("@generotraspasob", OdbcType.Int, 16, generotraspasoB)
            MyBase.AddParameter("@idfoliosuc", OdbcType.Char, 8, IdFolioSucB)
            MyBase.AddParameter("@statusb", OdbcType.Char, 2, statusb)
            MyBase.AddParameter("@tipob", OdbcType.Char, 1, tipob)
            MyBase.AddParameter("@sfb", OdbcType.Char, 1, SFb)
            MyBase.AddParameter("@PaqueteriaB", OdbcType.Char, 150, paqueteria)

            usp_Captura_Bulto = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_DetCodigo(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        Try
            'mreyes 17/Febrero/2013 01:20 p.m.
            MyBase.SQL = "CALL usp_Captura_DetCodigo(?,?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add the Parameters to the Parameters collection
            'User_Name Text 15

            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@idfolio", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("idfolio"))
            MyBase.AddParameter("@codigo", OdbcType.Char, 13, Section.Tables(0).Rows(0).Item("codigo"))
            MyBase.AddParameter("@impreso", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("impreso"))
            MyBase.AddParameter("@usuario", OdbcType.Char, 8, Section.Tables(0).Rows(0).Item("usuario"))
            MyBase.AddParameter("@usuarioimprime", OdbcType.Char, 8, Section.Tables(0).Rows(0).Item("usuarioimprime"))


            usp_Captura_DetCodigo = ExecuteStoredProcedure()

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerBulto(ByVal IdFolio As String, ByVal IdFolioSuc As String) As DataSet
        'mreyes 22/Enero/2012 04:52 p.m.
        Try
            usp_TraerBulto = New DataSet
            MyBase.SQL = "CALL usp_TraerBulto(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@FolioB", OdbcType.Char, 8, IdFolio)
            MyBase.AddParameter("@FoliosucB", OdbcType.Char, 8, IdFolioSuc)

            MyBase.FillDataSet(usp_TraerBulto, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerDetCodigo(ByVal Codigo As String) As DataSet
        'mreyes 17/Febrero/2013 02:41 p.m.
        Try
            usp_TraerDetCodigo = New DataSet
            MyBase.SQL = "CALL usp_TraerDetCodigo(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@CodigoB", OdbcType.Char, 13, Codigo)

            MyBase.FillDataSet(usp_TraerDetCodigo, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function pub_TraerIdFolio(ByVal IdFolioSuc As String) As DataSet
        'mreyes 17/Febrero/2013 02:41 p.m.
        Try
            pub_TraerIdFolio = New DataSet
            MyBase.SQL = "CALL usp_TraerIdFolio(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@idfoliob", OdbcType.Char, 8, IdFolioSuc)

            MyBase.FillDataSet(pub_TraerIdFolio, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerFolioDevoProv(ByVal IdFolio As Integer) As DataSet
        'mreyes 10/Diciembre/2014   10:31 a.m.
        Try
            usp_TraerFolioDevoProv = New DataSet
            MyBase.SQL = "CALL usp_TraerFolioDevoProv(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@idfoliob", OdbcType.Char, 8, IdFolio)

            MyBase.FillDataSet(usp_TraerFolioDevoProv, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerFolioEntrada(ByVal IdFolio As Integer) As DataSet
        'mreyes 10/Diciembre/2014   10:31 a.m.
        Try
            usp_TraerFolioEntrada = New DataSet
            MyBase.SQL = "CALL usp_TraerFolioEntrada(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@idfoliob", OdbcType.Char, 8, IdFolio)

            MyBase.FillDataSet(usp_TraerFolioEntrada, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerIdFolioSucBulto(ByVal IdFolio As Integer) As DataSet
        'mreyes 10/Diciembre/2014   10:31 a.m.
        Try
            usp_TraerIdFolioSucBulto = New DataSet
            MyBase.SQL = "CALL usp_TraerIdFolioSucBulto(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@idfoliob", OdbcType.Char, 8, IdFolio)

            MyBase.FillDataSet(usp_TraerIdFolioSucBulto, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function pub_TraerIdFolioBulto(ByVal IdFolioSuc As String) As DataSet
        'mreyes 17/Febrero/2013 02:41 p.m.
        Try
            pub_TraerIdFolioBulto = New DataSet
            MyBase.SQL = "CALL pub_TraerIdFolioBulto(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@idfoliob", OdbcType.Char, 8, IdFolioSuc)

            MyBase.FillDataSet(pub_TraerIdFolioBulto, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_EliminarAparadorLeer(ByVal Serie As String) As DataSet
        'mreyes 28/Octubre/2015   11:12 a.m.
        Try
            usp_EliminarAparadorLeer = New DataSet
            MyBase.SQL = "CALL usp_EliminarAparadorLeer(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@SerieB", OdbcType.Char, 13, Serie)

            MyBase.FillDataSet(usp_EliminarAparadorLeer, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_EliminarDetBulto(ByVal Folio As String) As DataSet
        'mreyes 28/Octubre/2015   11:12 a.m.
        Try
            usp_EliminarDetBulto = New DataSet
            MyBase.SQL = "CALL usp_EliminarDetBulto(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@IdFolioB", OdbcType.Char, 8, Folio)

            MyBase.FillDataSet(usp_EliminarDetBulto, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerDetBulto(ByVal Folio As String, ByVal Sucursal As String, ByVal Pedido As String) As DataSet
        'mreyes 20/Enero/2012   01:10 p.m.
        Try
            usp_TraerDetBulto = New DataSet
            MyBase.SQL = "CALL usp_TraerDetBulto(?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@IdFolioB", OdbcType.Char, 8, Folio)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@PedidoB", OdbcType.Char, 8, Pedido)
            MyBase.FillDataSet(usp_TraerDetBulto, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_DetBulto(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        Try
            'mreyes 20/Enero/2013 01:46 p.m.
            MyBase.SQL = "CALL usp_Captura_DetBulto(?,?,?,?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()


            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@idfolio", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("idfolio"))
            MyBase.AddParameter("@sucursal", OdbcType.Char, 2, Section.Tables(0).Rows(0).Item("sucursal"))
            MyBase.AddParameter("@nobultos", OdbcType.Decimal, 8, Section.Tables(0).Rows(0).Item("nobultos"))
            MyBase.AddParameter("@sucurorc", OdbcType.Char, 2, Section.Tables(0).Rows(0).Item("sucurorc"))
            MyBase.AddParameter("@ordecomp", OdbcType.Char, 6, Section.Tables(0).Rows(0).Item("ordecomp"))
            MyBase.AddParameter("@factura", OdbcType.Char, 15, Section.Tables(0).Rows(0).Item("factura"))
            MyBase.AddParameter("@fecfactura", OdbcType.Date, 8, Section.Tables(0).Rows(0).Item("fecfactura"))


            usp_Captura_DetBulto = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_PpalBulto(ByVal FolioA As String, ByVal FolioB As String, ByVal Sucursal As String, ByVal Proveedor As String, ByVal FechaIni As String, ByVal FechaFin As String) As DataSet
        'miguel pérez 30/Diciembre/2012 09:30 a.m.
        Try
            usp_PpalBulto = New DataSet
            MyBase.SQL = "CALL usp_PpalBulto(?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@FolioBA", OdbcType.Char, 8, FolioA)
            MyBase.AddParameter("@FolioBB", OdbcType.Char, 8, FolioB)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@ProveedorB", OdbcType.Char, 3, Proveedor)
            MyBase.AddParameter("@FechaIni", OdbcType.Char, 10, FechaIni)
            MyBase.AddParameter("@FechaFin", OdbcType.Char, 10, FechaFin)
            MyBase.FillDataSet(usp_PpalBulto, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ActualizaBultos(ByVal Folio As String, ByVal Sucursal As String, ByVal Proveedor As String, ByVal NoGuia As String, _
                                      ByVal Transporta As String, ByVal NoBultos As Integer, ByVal Recibe As Integer, ByVal NombreRec As String, _
                                      ByVal Entrega As Integer, ByVal NombreEnt As String, ByVal Factura As String, ByVal Comentarios As String) As Boolean
        'miguel pérez 30/Diciembre/2012 09:30 a.m.
        Try
            MyBase.SQL = "CALL usp_ActualizaBultos(?,?,?,?,?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@FolioB", OdbcType.Char, 6, Folio)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@ProveedorB", OdbcType.Char, 3, Proveedor)
            MyBase.AddParameter("@NoGuiaB", OdbcType.Char, 20, NoGuia)
            MyBase.AddParameter("@TransportaB", OdbcType.Char, 25, Transporta)
            MyBase.AddParameter("@NoBultosB", OdbcType.Int, 16, NoBultos)
            MyBase.AddParameter("@RecibeB", OdbcType.Int, 16, Recibe)
            MyBase.AddParameter("@NombreRecB", OdbcType.Char, 40, NombreRec)
            MyBase.AddParameter("@EntregaB", OdbcType.Int, 16, Entrega)
            MyBase.AddParameter("@NombreEntB", OdbcType.Char, 40, NombreEnt)
            MyBase.AddParameter("@FacturaB", OdbcType.Char, 6, Factura)
            MyBase.AddParameter("@ComentariosB", OdbcType.Char, 250, Comentarios)
            usp_ActualizaBultos = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_PpalAntiJaula(ByVal Accion As Integer, ByVal Opcion As Integer, ByVal Sucursal As String) As DataSet
        'Tony Garcia - 22/Febrero/2013 - 06:50 p.m.
        Try
            usp_PpalAntiJaula = New DataSet
            MyBase.SQL = "CALL usp_PpalAntiJaula(?,?,?)"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@Accion", OdbcType.Int, 4, Accion)
            MyBase.AddParameter("@Opcion", OdbcType.Int, 4, Opcion)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)

            'Execute the stored procedure
            MyBase.FillDataSet(usp_PpalAntiJaula, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function




    Public Function usp_PpalAntiJaulaDet(ByVal Accion As Integer, ByVal Opcion As Integer, ByVal Sucursal As String, ByVal Proveedor As String, ByVal Noguia As String, _
                                                      ByVal Folio As Integer, ByVal Recibe As Integer, _
                                                      ByVal Asigna As Integer, ByVal FechaRecIni As String, ByVal FechaRecFin As String, _
                                                      ByVal FechaAsigIni As String, ByVal FechaAsigFin As String, _
                                                      ByVal DiasIni As Integer, ByVal DiasFin As Integer) As DataSet
        'Tony Garcia - 23/Febrero/2013 - 11:20 a.m.
        Try
            usp_PpalAntiJaulaDet = New DataSet
            MyBase.SQL = "CALL usp_PpalAntiJaulaDet(?,?,?,?,?,?,?,?,?,?,?,?,?,?)"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@Accion", OdbcType.Int, 4, Accion)
            MyBase.AddParameter("@Opcion", OdbcType.Int, 4, Opcion)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@ProveedorB", OdbcType.Char, 3, Proveedor)
            MyBase.AddParameter("@NoguiaB", OdbcType.Char, 20, Noguia)
            MyBase.AddParameter("@FolioB", OdbcType.Int, 6, Folio)
            MyBase.AddParameter("@RecibeB", OdbcType.Int, 4, Recibe)
            MyBase.AddParameter("@AsignaB", OdbcType.Int, 4, Asigna)
            MyBase.AddParameter("@fechareciniB", OdbcType.Char, 10, FechaRecIni)
            MyBase.AddParameter("@fecharecfinB", OdbcType.Char, 10, FechaRecFin)
            MyBase.AddParameter("@fechaasiginiB", OdbcType.Char, 10, FechaAsigIni)
            MyBase.AddParameter("@fechaasigfinB", OdbcType.Char, 10, FechaAsigFin)
            MyBase.AddParameter("@DiasIniB", OdbcType.Int, 4, DiasIni)
            MyBase.AddParameter("@DiasFinB", OdbcType.Int, 4, DiasFin)

            'Execute the stored procedure
            MyBase.FillDataSet(usp_PpalAntiJaulaDet, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

#End Region
End Class
