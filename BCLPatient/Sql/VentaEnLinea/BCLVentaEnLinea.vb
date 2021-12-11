Public Class BCLVentaEnLinea
    'mreyes 17/Marzo/2018   09:49 a.m.

    Implements IDisposable
    Private objDALVentaEnLinea As DAL.DALVentaEnLinea
    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALVentaEnLinea = New DAL.DALVentaEnLinea(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALVentaEnLinea.Dispose()
            objDALVentaEnLinea = Nothing
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



    Public Function usp_Captura_Usuario(Opcion As Integer, Usuario As String, IdEmpleado As Integer, Nombre As String, FechaNacim As Date, Password As String, IdUsuario As Integer, IdUsuarioModif As Integer) As Boolean

        'mreyes 17/Marzo/2018   09:54 a.m.


        Try

            usp_Captura_Usuario = objDALVentaEnLinea.usp_Captura_Usuario(Opcion, Usuario, IdEmpleado, Nombre, FechaNacim, Password, IdUsuario, IdUsuarioModif)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_Permisos(Opcion As Integer, Usuario As String, Damas As Integer, Caballeros As Integer, Ninas As Integer, Ninos As Integer, Bebes As Integer, Accesorios As Integer, IdUsuario As Integer, IdUsuarioModif As Integer) As Boolean

        'mreyes 20/Marzo/2018   11:09 a.m.


        Try

            usp_Captura_Permisos = objDALVentaEnLinea.usp_Captura_Permisos(Opcion, Usuario, Damas, Caballeros, Ninas, Ninos, Bebes, Accesorios, IdUsuario, IdUsuarioModif)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerUsuarioSistema(ByVal Usuario As String, IdEmpleado As Integer, Nombre As String) As DataSet
        'mreyes 17/Marzo/2018   10:38 p.m.

        Try
            Return objDALVentaEnLinea.usp_TraerUsuarioSistema(Usuario, IdEmpleado, Nombre)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalUsuario() As DataSet
        'mreyes 17/Marzo/2018   01:17 p.m.

        Try
            Return objDALVentaEnLinea.usp_PpalUsuario()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalVentasENLinea(Canal As String) As DataSet
        'mreyes 29/Mayo/2019   10:41 p.m.

        Try
            Return objDALVentaEnLinea.usp_PpalVentasENLinea(Canal)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_PpalPrevioVentaAnualFoto(FechaIniB As Date, FEchaFinB As Date, MarcaB As String, ModeloB As String, DivisionB As String, DeptoB As String, LineaB As String, L1B As String, L2B As String, L3B As String, L4B As String, L5B As String, L6B As String) As DataSet
        'mreyes 20/Marzo/2018   12:42 p.m.

        Try
            Return objDALVentaEnLinea.usp_PpalPrevioVentaAnualFoto(FechaIniB, FEchaFinB, MarcaB, ModeloB, DivisionB, DeptoB, LineaB, L1B, L2B, L3B, L4B, L5B, L6B)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalSapica(FechaIniB As Date, FEchaFinB As Date, MarcaB As String, ModeloB As String, DivisionB As String, DeptoB As String, FamiliaB As String, LineaB As String, L1B As String, L2B As String, L3B As String, L4B As String, L5B As String, L6B As String) As DataSet
        'mreyes 18/Agosto/2019  11:08 a.m.

        Try
            Return objDALVentaEnLinea.usp_PpalSapica(FechaIniB, FEchaFinB, MarcaB, ModeloB, DivisionB, DeptoB, FamiliaB, LineaB, L1B, L2B, L3B, L4B, L5B, L6B)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_PpalProductsPendientes(Usuario As String) As DataSet
        'mreyes 20/Marzo/2018   12:42 p.m.

        Try
            Return objDALVentaEnLinea.usp_PpalProductsPendientes(Usuario)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerColores(Opcion As Integer) As DataSet
        'mreyes 20/Marzo/2018   05:28 p.m.  

        Try
            Return objDALVentaEnLinea.usp_TraerColores(Opcion)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerMaterial(Opcion As Integer) As DataSet
        'mreyes 20/Marzo/2018   05:31 p.m.  

        Try
            Return objDALVentaEnLinea.usp_TraerMaterial(Opcion)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerProductsTemp(Opcion As Integer, cliente_id As String) As DataSet
        'mreyes 31/Marzo/2020 

        Try
            Return objDALVentaEnLinea.usp_TraerProductsTemp(Opcion, cliente_id)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_Products(Opcion As Integer, Cliente_Id As String, Name As String, Descripcion As String, Color As String, Secondary_color As String, Material As String, Image_1 As String,
                                         Image_2 As String, Image_3 As String, Image_4 As String, Image_5 As String, Image_6 As String, Image_7 As String, Image_8 As String, Image_9 As String,
                                         Image_10 As String, IdUsuarioModif As Integer) As Boolean

        'mreyes 21/Marzo/2018   10:03 a.m.


        Try

            usp_Captura_Products = objDALVentaEnLinea.usp_Captura_Products(Opcion, Cliente_Id, Name, Descripcion, Color, Secondary_color, Material, Image_1, Image_2, Image_3, Image_4, Image_5, Image_6, Image_7, Image_8, Image_9, Image_10, IdUsuarioModif)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_VentaMYSQL(Sucursal As String, Venta As String) As Boolean

        'mreyes 18/Mayo/2021    04:44 p.m.


        Try

            usp_Captura_VentaMYSQL = objDALVentaEnLinea.usp_Captura_VentaMYSQL(Sucursal, Venta)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_Det_VtMYSQL(Sucursal As String, Venta As String, Marca As String, Estilon As String, Corrida As String, Medida As String, Serie As String, Precio As Decimal, PrecDesc As Decimal, Iva As Decimal, Costo As Decimal) As Boolean

        'mreyes 18/Mayo/2021    04:48 p.m.


        Try

            usp_Captura_Det_VtMYSQL = objDALVentaEnLinea.usp_Captura_Det_VtMYSQL(Sucursal, Venta, Marca, Estilon, Corrida, Medida, Serie, Precio, PrecDesc, Iva, Costo)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_PagoMYSQL(Sucursal As String, Venta As String, Importe As Decimal) As Boolean

        'mreyes 18/Mayo/2021    04:54 p.m.


        Try

            usp_Captura_PagoMYSQL = objDALVentaEnLinea.usp_Captura_PagoMYSQL(Sucursal, Venta, Importe)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerSerieTmp(Serie As String) As DataSet
        'mreyes 18/Mayo/2021    05:49 p.m. 

        Try
            Return objDALVentaEnLinea.usp_TraerSerieTmp(Serie)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerTraspasoSerieDescrip(Serie As String) As DataSet
        'mreyes 18/Mayo/2021    07:02 p.m. 

        Try
            Return objDALVentaEnLinea.usp_TraerTraspasoSerieDescrip(Serie)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function



    Public Function usp_TraerPedidoVEL(Pedido As String) As DataSet
        'mreyes 19/Mayo/2021    11:31 a.m. 

        Try
            Return objDALVentaEnLinea.usp_TraerPedidoVEL(Pedido)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerTraspasoSerieDescripVEL(Pedido As String, Serie As String) As DataSet
        'mreyes 19/Mayo/2021    12:47 a.m. 

        Try
            Return objDALVentaEnLinea.usp_TraerTraspasoSerieDescripVEL(Pedido, Serie)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_Captura_VentaEnLinea(Pedido As String, Sucursal As String, Marca As String, Estilon As String, Corrida As String, Medida As String, Serie As String, Precio As Decimal, PrecDesc As Decimal, Iva As Decimal, CostoMargen As Decimal, MontoTotal As Decimal) As Boolean

        'mreyes 19/Mayo/2021    04:10 p.m.


        Try

            usp_Captura_VentaEnLinea = objDALVentaEnLinea.usp_Captura_VentaEnLinea(Pedido, Sucursal, Marca, Estilon, Corrida, Medida, Serie, Precio, PrecDesc, Iva, CostoMargen, MontoTotal)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

#End Region
End Class
