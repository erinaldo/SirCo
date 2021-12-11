
Imports System.Data
Imports System.Data.SqlClient

Public Class DALVentaEnLinea
    Inherits DALBase
#Region "Constructor And Destructor"
    Sub New(ByVal ConString As String)
        MyBase.New(ConString)
    End Sub

    Public Shadows Sub Dispose()
        MyBase.Dispose()
    End Sub
#End Region

#Region " Public Role Functions "

    Public Function usp_Captura_Usuario(Opcion As Integer, Usuario As String, IdEmpleado As Integer, Nombre As String, FechaNacim As Date, Password As String, IdUsuario As Integer, IdUsuarioModif As Integer) As Boolean
        'mreyes 17/Marzo/2018   09:55 a.m.

        Try
            MyBase.SQL = "usp_Captura_Usuario"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", SqlDbType.Int, 8, Opcion)
            MyBase.AddParameter("@Usuario", SqlDbType.VarChar, 10, Usuario)
            MyBase.AddParameter("@IdEmpleado", SqlDbType.Int, 16, IdEmpleado)
            MyBase.AddParameter("@Nombre", SqlDbType.VarChar, 150, Nombre)
            MyBase.AddParameter("@fechanacim", SqlDbType.VarChar, 10, FechaNacim)
            MyBase.AddParameter("@password", SqlDbType.VarChar, 50, Password)
            MyBase.AddParameter("@IdUsuario", SqlDbType.Int, 16, IdUsuario)
            MyBase.AddParameter("@IdUsuariomodif", SqlDbType.Int, 16, IdUsuario)


            usp_Captura_Usuario = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_Permisos(Opcion As Integer, Usuario As String, Damas As Integer, Caballeros As Integer, Ninas As Integer, Ninos As Integer, Bebes As Integer, Accesorios As Integer, IdUsuario As Integer, IdUsuarioModif As Integer) As Boolean
        'mreyes 20/Marzo/2018   11:18 a.m.

        Try
            MyBase.SQL = "usp_Captura_Permisos"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", SqlDbType.Int, 8, Opcion)
            MyBase.AddParameter("@Usuario", SqlDbType.VarChar, 10, Usuario)
            MyBase.AddParameter("@damas", SqlDbType.Int, 16, Damas)
            MyBase.AddParameter("@caballeros", SqlDbType.Int, 16, Caballeros)
            MyBase.AddParameter("@ninas", SqlDbType.Int, 16, Ninas)
            MyBase.AddParameter("@ninos", SqlDbType.Int, 16, Ninos)
            MyBase.AddParameter("@bebes", SqlDbType.Int, 16, Bebes)
            MyBase.AddParameter("@accesorios", SqlDbType.Int, 16, Accesorios)


            MyBase.AddParameter("@IdUsuario", SqlDbType.Int, 16, IdUsuario)
            MyBase.AddParameter("@IdUsuariomodif", SqlDbType.Int, 16, IdUsuario)


            usp_Captura_Permisos = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerUsuarioSistema(ByVal Usuario As String, IdEmpleado As Integer, Nombre As String) As DataSet
        'mreyes 17/Marzo/2018   10:35 a.m.
        Try
            usp_TraerUsuarioSistema = New DataSet
            MyBase.SQL = "usp_TraerUsuarioSistema"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@usuario", SqlDbType.VarChar, 10, Usuario)
            MyBase.AddParameter("@IdEmpleado", SqlDbType.Int, 10, IdEmpleado)
            MyBase.AddParameter("@nombre", SqlDbType.VarChar, 150, Nombre)

            MyBase.FillDataSet(usp_TraerUsuarioSistema, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalUsuario() As DataSet
        'mreyes 17/Marzo/2018   01:18 p.m.
        Try
            usp_PpalUsuario = New DataSet
            MyBase.SQL = "usp_PpalUsuario"

            MyBase.InitializeCommand()


            MyBase.FillDataSet(usp_PpalUsuario, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_PpalPrevioVentaAnualFoto(FechaIniB As Date, FEchaFinB As Date, MarcaB As String, ModeloB As String, DivisionB As String, DeptoB As String, LineaB As String, L1B As String, L2B As String, L3B As String, L4B As String, L5B As String, L6B As String) As DataSet
        'mreyes 29/Mayo/2019   10:43 a.m.
        Try
            usp_PpalPrevioVentaAnualFoto = New DataSet
            MyBase.SQL = "usp_PpalPrevioVentaAnual"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@FechaIniB", SqlDbType.Date, 8, FechaIniB)
            MyBase.AddParameter("@FechaFinB", SqlDbType.Date, 8, FEchaFinB)

            MyBase.AddParameter("@MarcaB", SqlDbType.VarChar, 3, MarcaB)
            MyBase.AddParameter("@ModeloB", SqlDbType.VarChar, 7, ModeloB)
            MyBase.AddParameter("@DivisionB", SqlDbType.VarChar, 30, DivisionB)
            MyBase.AddParameter("@DeptoB", SqlDbType.VarChar, 30, DeptoB)
            MyBase.AddParameter("@LineaB", SqlDbType.VarChar, 30, LineaB)
            MyBase.AddParameter("@L1B", SqlDbType.VarChar, 30, L1B)
            MyBase.AddParameter("@L2B", SqlDbType.VarChar, 30, L2B)
            MyBase.AddParameter("@L3B", SqlDbType.VarChar, 30, L3B)
            MyBase.AddParameter("@L4B", SqlDbType.VarChar, 30, L4B)
            MyBase.AddParameter("@L5B", SqlDbType.VarChar, 30, L5B)
            MyBase.AddParameter("@L6B", SqlDbType.VarChar, 30, L6B)



            MyBase.FillDataSet(usp_PpalPrevioVentaAnualFoto, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function



    Public Function usp_PpalSapica(FechaIniB As Date, FEchaFinB As Date, MarcaB As String, ModeloB As String, DivisionB As String, DeptoB As String, FamiliaB As String, LineaB As String, L1B As String, L2B As String, L3B As String, L4B As String, L5B As String, L6B As String) As DataSet
        'mreyes 18/Agosto/2019  11:09 a.m.
        Try
            usp_PpalSapica = New DataSet
            MyBase.SQL = "usp_PpalSapica"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@FechaIniB", SqlDbType.Date, 8, FechaIniB)
            MyBase.AddParameter("@FechaFinB", SqlDbType.Date, 8, FEchaFinB)

            MyBase.AddParameter("@MarcaB", SqlDbType.VarChar, 3, MarcaB)
            MyBase.AddParameter("@ModeloB", SqlDbType.VarChar, 7, ModeloB)

            MyBase.AddParameter("@DivisionB", SqlDbType.VarChar, 30, DivisionB)

            MyBase.AddParameter("@DeptoB", SqlDbType.VarChar, 30, DeptoB)
            MyBase.AddParameter("@FamiliaB", SqlDbType.VarChar, 30, FamiliaB)
            MyBase.AddParameter("@LineaB", SqlDbType.VarChar, 30, LineaB)
            MyBase.AddParameter("@L1B", SqlDbType.VarChar, 30, L1B)
            MyBase.AddParameter("@L2B", SqlDbType.VarChar, 30, L2B)
            MyBase.AddParameter("@L3B", SqlDbType.VarChar, 30, L3B)
            MyBase.AddParameter("@L4B", SqlDbType.VarChar, 30, L4B)
            MyBase.AddParameter("@L5B", SqlDbType.VarChar, 30, L5B)
            MyBase.AddParameter("@L6B", SqlDbType.VarChar, 30, L6B)



            MyBase.FillDataSet(usp_PpalSapica, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_PpalVentasEnLinea(Canal As String) As DataSet
        'mreyes 29/Mayo/2019   10:43 a.m.
        Try
            usp_PpalVentasEnLinea = New DataSet
            MyBase.SQL = "usp_PpalVentasEnLinea"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Canal", SqlDbType.VarChar, 2, Canal)

            MyBase.FillDataSet(usp_PpalVentasEnLinea, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalProductsPendientes(Usuario As String) As DataSet
        'mreyes 20/Marzo/2018   12:43 p.m.
        Try
            usp_PpalProductsPendientes = New DataSet
            MyBase.SQL = "usp_PpalProductsPendientes"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@usuario", SqlDbType.VarChar, 10, Usuario)

            MyBase.FillDataSet(usp_PpalProductsPendientes, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerColores(Opcion As Integer) As DataSet
        'mreyes 20/Marzo/2018   05:29 p.m.
        Try
            usp_TraerColores = New DataSet
            MyBase.SQL = "usp_TraerColores"

            MyBase.InitializeCommand()

            MyBase.AddParameter("@Opcion", SqlDbType.Int, 10, Opcion)

            MyBase.FillDataSet(usp_TraerColores, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerMaterial(Opcion As Integer) As DataSet
        'mreyes 20/Marzo/2018   05:31 p.m.
        Try
            usp_TraerMaterial = New DataSet
            MyBase.SQL = "usp_TraerMaterial"

            MyBase.InitializeCommand()

            MyBase.AddParameter("@Opcion", SqlDbType.Int, 10, Opcion)

            MyBase.FillDataSet(usp_TraerMaterial, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerProductsTemp(Opcion As Integer, cliente_id As String) As DataSet
        'mreyes 31/Marzo/2020   12:34 p.m.

        Try
            usp_TraerProductsTemp = New DataSet
            MyBase.SQL = "usp_TraerProductsTemp"

            MyBase.InitializeCommand()

            MyBase.AddParameter("@Opcion", SqlDbType.Int, 10, Opcion)
            MyBase.AddParameter("@cliente_id", SqlDbType.VarChar, 20, cliente_id)

            MyBase.FillDataSet(usp_TraerProductsTemp, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_Captura_Products(Opcion As Integer, Cliente_Id As String, Name As String, Descripcion As String, Color As String, Secondary_color As String, Material As String, Image_1 As String,
                                         Image_2 As String, Image_3 As String, Image_4 As String, Image_5 As String, Image_6 As String, Image_7 As String, Image_8 As String, Image_9 As String,
                                         Image_10 As String, IdUsuarioModif As Integer) As Boolean
        'mreyes 21/Marzo/2018   10:06 a.m.

        Try
            MyBase.SQL = "usp_Captura_Products"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", SqlDbType.Int, 8, Opcion)
            MyBase.AddParameter("@Cliente_Id", SqlDbType.VarChar, 50, Cliente_Id)
            MyBase.AddParameter("@name", SqlDbType.VarChar, 200, Name)
            MyBase.AddParameter("@descripcion", SqlDbType.VarChar, 1500, Descripcion)
            MyBase.AddParameter("@color", SqlDbType.VarChar, 50, Color)
            MyBase.AddParameter("@secondary_color", SqlDbType.VarChar, 50, Secondary_color)
            MyBase.AddParameter("@material", SqlDbType.VarChar, 50, Material)
            MyBase.AddParameter("@image_1", SqlDbType.VarChar, 255, Image_1)
            MyBase.AddParameter("@image_2", SqlDbType.VarChar, 255, Image_2)
            MyBase.AddParameter("@image_3", SqlDbType.VarChar, 255, Image_3)
            MyBase.AddParameter("@image_4", SqlDbType.VarChar, 255, Image_4)
            MyBase.AddParameter("@image_5", SqlDbType.VarChar, 255, Image_5)
            MyBase.AddParameter("@image_6", SqlDbType.VarChar, 255, Image_6)
            MyBase.AddParameter("@image_7", SqlDbType.VarChar, 255, Image_7)
            MyBase.AddParameter("@image_8", SqlDbType.VarChar, 255, Image_8)
            MyBase.AddParameter("@image_9", SqlDbType.VarChar, 255, Image_9)
            MyBase.AddParameter("@image_10", SqlDbType.VarChar, 255, Image_10)



            MyBase.AddParameter("@IdUsuariomodif", SqlDbType.Int, 16, IdUsuarioModif)


            usp_Captura_Products = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function



    Public Function usp_Captura_VentaMYSQL(Sucursal As String, Venta As String) As Boolean
        'mreyes 18/Mayo/2021    04:46 p.m.

        Try
            MyBase.SQL = "usp_Captura_VentaMYSQL"

            MyBase.InitializeCommand()

            MyBase.AddParameter("@Sucursal", SqlDbType.VarChar, 2, Sucursal)
            MyBase.AddParameter("@Venta", SqlDbType.VarChar, 6, Venta)

            usp_Captura_VentaMYSQL = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_Captura_Det_VtMYSQL(Sucursal As String, Venta As String, Marca As String, Estilon As String, Corrida As String, Medida As String, Serie As String, Precio As Decimal, PrecDesc As Decimal, Iva As Decimal, Costo As Decimal) As Boolean
        'mreyes 18/Mayo/2021    04:49 p.m.

        Try
            MyBase.SQL = "usp_Captura_Det_VtMYSQL"

            MyBase.InitializeCommand()

            MyBase.AddParameter("@Sucursal", SqlDbType.VarChar, 2, Sucursal)
            MyBase.AddParameter("@Venta", SqlDbType.VarChar, 6, Venta)
            MyBase.AddParameter("@Marca", SqlDbType.VarChar, 3, Marca)
            MyBase.AddParameter("@Estilon", SqlDbType.VarChar, 7, Estilon)
            MyBase.AddParameter("@Corrida", SqlDbType.VarChar, 1, Corrida)
            MyBase.AddParameter("@Medida", SqlDbType.VarChar, 3, Medida)
            MyBase.AddParameter("@Serie", SqlDbType.VarChar, 13, Serie)

            MyBase.AddParameter("@Precio", SqlDbType.Decimal, 18, Precio)
            MyBase.AddParameter("@PrecDesc", SqlDbType.Decimal, 18, PrecDesc)
            MyBase.AddParameter("@Iva", SqlDbType.Decimal, 18, Iva)
            MyBase.AddParameter("@Costo", SqlDbType.Decimal, 18, Costo)




            usp_Captura_Det_VtMYSQL = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_PagoMYSQL(Sucursal As String, Venta As String, Importe As Decimal) As Boolean
        'mreyes 18/Mayo/2021    04:49 p.m.

        Try
            MyBase.SQL = "usp_Captura_PagoMYSQL"

            MyBase.InitializeCommand()

            MyBase.AddParameter("@Sucursal", SqlDbType.VarChar, 2, Sucursal)
            MyBase.AddParameter("@Venta", SqlDbType.VarChar, 6, Venta)

            MyBase.AddParameter("@Importe", SqlDbType.Decimal, 18, Importe)




            usp_Captura_PagoMYSQL = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerSerieTmp(Serie As String) As DataSet
        'mreyes 18/Mayo/2021    05:49 p.m.
        Try
            usp_TraerSerieTmp = New DataSet
            MyBase.SQL = "usp_TraerSerieTmp"

            MyBase.InitializeCommand()

            MyBase.AddParameter("@Serie", SqlDbType.VarChar, 13, Serie)

            MyBase.FillDataSet(usp_TraerSerieTmp, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerTraspasoSerieDescrip(Serie As String) As DataSet
        'mreyes 18/Mayo/2021    05:49 p.m.
        Try
            usp_TraerTraspasoSerieDescrip = New DataSet
            MyBase.SQL = "usp_TraerTraspasoSerieDescrip"

            MyBase.InitializeCommand()

            MyBase.AddParameter("@Serie", SqlDbType.VarChar, 13, Serie)

            MyBase.FillDataSet(usp_TraerTraspasoSerieDescrip, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerPedidoVEL(Pedido As String) As DataSet
        'mreyes 19/Mayo/2021    11:31 a.m.
        Try
            usp_TraerPedidoVEL = New DataSet
            MyBase.SQL = "usp_TraerPedidoVEL"

            MyBase.InitializeCommand()

            MyBase.AddParameter("@Pedido", SqlDbType.VarChar, 100, Pedido)

            MyBase.FillDataSet(usp_TraerPedidoVEL, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerTraspasoSerieDescripVEL(Pedido As String, Serie As String) As DataSet
        'mreyes 19/Mayo/2021    12:48 p.m.
        Try
            usp_TraerTraspasoSerieDescripVEL = New DataSet
            MyBase.SQL = "usp_TraerTraspasoSerieDescripVEL"

            MyBase.InitializeCommand()

            MyBase.AddParameter("@Pedido", SqlDbType.VarChar, 100, Pedido)
            MyBase.AddParameter("@Serie", SqlDbType.VarChar, 13, Serie)

            MyBase.FillDataSet(usp_TraerTraspasoSerieDescripVEL, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_VentaEnLinea(pedido As String, Sucursal As String, Marca As String, Estilon As String, Corrida As String, Medida As String, Serie As String, Precio As Decimal, PrecDesc As Decimal, Iva As Decimal, CostoMargen As Decimal, MontoTotal As Decimal) As Boolean
        'mreyes 19/Mayo/2021    04:11 p.m.

        Try
            MyBase.SQL = "usp_Captura_VentaEnLinea"

            MyBase.InitializeCommand()

            MyBase.AddParameter("@Pedido", SqlDbType.VarChar, 100, pedido)
            MyBase.AddParameter("@Sucursal", SqlDbType.VarChar, 2, Sucursal)
            MyBase.AddParameter("@Marca", SqlDbType.VarChar, 3, Marca)
            MyBase.AddParameter("@Estilon", SqlDbType.VarChar, 7, Estilon)
            MyBase.AddParameter("@Corrida", SqlDbType.VarChar, 1, Corrida)
            MyBase.AddParameter("@Medida", SqlDbType.VarChar, 3, Medida)
            MyBase.AddParameter("@Serie", SqlDbType.VarChar, 13, Serie)

            MyBase.AddParameter("@Precio", SqlDbType.Decimal, 18, Precio)
            MyBase.AddParameter("@PrecDesc", SqlDbType.Decimal, 18, PrecDesc)
            MyBase.AddParameter("@Iva", SqlDbType.Decimal, 18, Iva)
            MyBase.AddParameter("@CostoMargen", SqlDbType.Decimal, 18, CostoMargen)
            MyBase.AddParameter("@MontoTotal", SqlDbType.Decimal, 18, MontoTotal)




            usp_Captura_VentaEnLinea = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function


#End Region
End Class
