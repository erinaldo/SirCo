
Public Class DALPromociones

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

    Public Function usp_TraerPromocion(ByVal IdPromocion As Integer, ByVal Estatus As String) As DataSet
        'miguelperez 20/Febrero/2019   
        Try
            usp_TraerPromocion = New DataSet
            MyBase.SQL = "usp_TraerPromocion"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@IdPromocionB", SqlDbType.Int, 10, IdPromocion)
            MyBase.AddParameter("@EstatusB", SqlDbType.VarChar, 15, Estatus)

            MyBase.FillDataSet(usp_TraerPromocion, "SirCoPV")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerPromocionAgrupacion(ByVal IdPromocion As Integer) As DataSet
        'miguelperez 20/Febrero/2019   
        Try
            usp_TraerPromocionAgrupacion = New DataSet
            MyBase.SQL = "usp_TraerPromocionAgrupacion"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@IdPromocionB", SqlDbType.Int, 10, IdPromocion)

            MyBase.FillDataSet(usp_TraerPromocionAgrupacion, "SirCoPV")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaPromocion(ByVal Nombre As String, ByVal Tipo As String, ByVal IniPromo As DateTime, ByVal FinPromo As DateTime, ByVal Preciero As String, ByVal Señalizador As String, ByVal Clasificacion As String, ByVal MinUniCompra As Integer, ByVal MinImpCompra As Decimal, ByVal UniPromo As Integer, ByVal Acumulable As String, ByVal ParesUnicos As String, ByVal CliNoRegis As String, ByVal IdUsuario As String, ByVal Imagen() As Byte) As DataSet
        'miguelperez 21/Febrero/2018  
        Try
            usp_CapturaPromocion = New DataSet
            MyBase.SQL = "usp_CapturaPromocion"
            Dim TamañoImagen As Integer
            If Imagen Is Nothing Then
                TamañoImagen = 16
            Else
                TamañoImagen = Imagen.Length
            End If

            MyBase.InitializeCommand()

            MyBase.AddParameter("@NombreB", SqlDbType.VarChar, 30, Nombre)
            MyBase.AddParameter("@TipoB", SqlDbType.VarChar, 10, Tipo)
            MyBase.AddParameter("@InicioPromoB", SqlDbType.DateTime, 10, IniPromo)
            MyBase.AddParameter("@FinPromoB", SqlDbType.DateTime, 10, FinPromo)
            MyBase.AddParameter("@PrecieroB", SqlDbType.VarChar, 30, Preciero)
            MyBase.AddParameter("@SeñalizadorB", SqlDbType.VarChar, 30, Señalizador)
            MyBase.AddParameter("@ClasificacionB", SqlDbType.VarChar, 10, Clasificacion)
            MyBase.AddParameter("@MinUniCompraB", SqlDbType.Int, 10, MinUniCompra)
            MyBase.AddParameter("@MinImpCompraB", SqlDbType.Decimal, 18, MinImpCompra)
            MyBase.AddParameter("@UniPromoB", SqlDbType.Int, 10, UniPromo)
            MyBase.AddParameter("@AcumulableB", SqlDbType.VarChar, 2, Acumulable)
            MyBase.AddParameter("@ParesUnicosB", SqlDbType.VarChar, 2, ParesUnicos)
            MyBase.AddParameter("@CliNoRegisB", SqlDbType.VarChar, 120, CliNoRegis)
            MyBase.AddParameter("@IdUsuarioB", SqlDbType.VarChar, 8, IdUsuario)
            MyBase.AddParameter("@ImagenB", SqlDbType.VarBinary, TamañoImagen, Imagen)

            MyBase.FillDataSet(usp_CapturaPromocion, "SirCoPV")
            'usp_CapturaAgrupacion = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ModificaPromocion(ByVal IdPromocion As Integer, ByVal Nombre As String, ByVal Estatus As String, ByVal IniPromo As DateTime, ByVal FinPromo As DateTime, ByVal Preciero As String, ByVal Señalizador As String, ByVal Clasificacion As String, ByVal MinUniCompra As Integer, ByVal MinImpCompra As Decimal, ByVal UniPromo As Integer, ByVal Acumulable As String, ByVal ParesUnicos As String, ByVal CliNoRegis As String, ByVal IdUsuario As String, ByVal Imagen() As Byte) As Boolean
        'miguelperez 21/Febrero/2018  
        Try
            MyBase.SQL = "usp_ModificaPromocion"
            Dim TamañoImagen As Integer
            If Imagen Is Nothing Then
                TamañoImagen = 16
            Else
                TamañoImagen = Imagen.Length
            End If

            MyBase.InitializeCommand()
            MyBase.AddParameter("@IdPromocionB", SqlDbType.Int, 4, IdPromocion)
            MyBase.AddParameter("@NombreB", SqlDbType.VarChar, 30, Nombre)
            MyBase.AddParameter("@EstatusB", SqlDbType.VarChar, 15, Estatus)
            MyBase.AddParameter("@InicioPromoB", SqlDbType.DateTime, 10, IniPromo)
            MyBase.AddParameter("@FinPromoB", SqlDbType.DateTime, 10, FinPromo)
            MyBase.AddParameter("@PrecieroB", SqlDbType.VarChar, 30, Preciero)
            MyBase.AddParameter("@SeñalizadorB", SqlDbType.VarChar, 30, Señalizador)
            MyBase.AddParameter("@ClasificacionB", SqlDbType.VarChar, 10, Clasificacion)
            MyBase.AddParameter("@MinUniCompraB", SqlDbType.Int, 10, MinUniCompra)
            MyBase.AddParameter("@MinImpCompraB", SqlDbType.Decimal, 18, MinImpCompra)
            MyBase.AddParameter("@UniPromoB", SqlDbType.Int, 10, UniPromo)
            MyBase.AddParameter("@AcumulableB", SqlDbType.VarChar, 2, Acumulable)
            MyBase.AddParameter("@ParesUnicosB", SqlDbType.VarChar, 2, ParesUnicos)
            MyBase.AddParameter("@CliNoRegisB", SqlDbType.VarChar, 2, CliNoRegis)
            MyBase.AddParameter("@IdUsuarioB", SqlDbType.VarChar, 8, IdUsuario)
            MyBase.AddParameter("@ImagenB", SqlDbType.VarBinary, TamañoImagen, Imagen)

            usp_ModificaPromocion = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerUsuFumPromocionesDet(ByVal IdPromocion As Integer) As DataSet
        'miguelperez 21/Febrero/2019   
        Try
            usp_TraerUsuFumPromocionesDet = New DataSet
            MyBase.SQL = "usp_TraerUsuFumPromocionesDet"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@IdPromocionB", SqlDbType.Int, 10, IdPromocion)

            MyBase.FillDataSet(usp_TraerUsuFumPromocionesDet, "SirCoPV")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerPromocionDet(ByVal IdPromocion As Integer, ByVal NumUnidad As Integer, ByVal Tipo As String, ByVal FormaPago As String) As DataSet
        'miguelperez 21/Febrero/2019   
        Try
            usp_TraerPromocionDet = New DataSet
            MyBase.SQL = "usp_TraerPromocionDet"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@IdPromocionB", SqlDbType.Int, 10, IdPromocion)
            MyBase.AddParameter("@NumUnidadB", SqlDbType.Int, 10, NumUnidad)
            MyBase.AddParameter("@TipoB", SqlDbType.VarChar, 10, Tipo)
            MyBase.AddParameter("@FormaPagoB", SqlDbType.VarChar, 2, FormaPago)

            MyBase.FillDataSet(usp_TraerPromocionDet, "SirCoPV")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaPromocionDet(ByVal IdPromocion As Integer, ByVal FormaPago As String, ByVal NumUnidad As Integer, ByVal Tipo As String, ByVal ImpFijo As Decimal, ByVal DescDirecto As Decimal, ByVal PorcDinElec As Decimal, ByVal ImpBono As Decimal, ByVal IdUsuario As String) As Boolean
        'miguelperez 26/Febrero/2018  
        Try
            MyBase.SQL = "usp_CapturaPromocionDet"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@IdPromocionB", SqlDbType.Int, 4, IdPromocion)
            MyBase.AddParameter("@FormaPagoB", SqlDbType.VarChar, 2, FormaPago)
            MyBase.AddParameter("@NumUnidadB", SqlDbType.Int, 4, NumUnidad)
            MyBase.AddParameter("@TipoB", SqlDbType.VarChar, 6, Tipo)
            MyBase.AddParameter("@ImpFijoB", SqlDbType.Decimal, 18, ImpFijo)
            MyBase.AddParameter("@DescDirectoB", SqlDbType.Decimal, 18, DescDirecto)
            MyBase.AddParameter("@PorcDinElecB", SqlDbType.Decimal, 18, PorcDinElec)
            MyBase.AddParameter("@ImpBonoB", SqlDbType.Decimal, 18, ImpBono)
            MyBase.AddParameter("@IdUsuarioB", SqlDbType.VarChar, 8, IdUsuario)

            usp_CapturaPromocionDet = ExecuteStoredProcedure()
            MyBase.ClearParameters()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ModificaPromocionDet(ByVal IdPromocion As Integer, ByVal FormaPago As String, ByVal NumUnidad As Integer, ByVal Tipo As String, ByVal ImpFijo As Decimal, ByVal DescDirecto As Decimal, ByVal PorcDinElec As Decimal, ByVal ImpBono As Decimal, ByVal IdUsuario As String) As Boolean
        'miguelperez 26/Febrero/2018  
        Try
            MyBase.SQL = "usp_ModificaPromocionDet"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@IdPromocionB", SqlDbType.Int, 4, IdPromocion)
            MyBase.AddParameter("@FormaPagoB", SqlDbType.VarChar, 2, FormaPago)
            MyBase.AddParameter("@NumUnidadB", SqlDbType.Int, 4, NumUnidad)
            MyBase.AddParameter("@TipoB", SqlDbType.VarChar, 6, Tipo)
            MyBase.AddParameter("@ImpFijoB", SqlDbType.Decimal, 18, ImpFijo)
            MyBase.AddParameter("@DescDirectoB", SqlDbType.Decimal, 18, DescDirecto)
            MyBase.AddParameter("@PorcDinElecB", SqlDbType.Decimal, 18, PorcDinElec)
            MyBase.AddParameter("@ImpBonoB", SqlDbType.Decimal, 18, ImpBono)
            MyBase.AddParameter("@IdUsuarioB", SqlDbType.VarChar, 8, IdUsuario)

            usp_ModificaPromocionDet = ExecuteStoredProcedure()
            MyBase.ClearParameters()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaPromocionAgrupacion(ByVal IdPromocion As Integer, ByVal IdAgrupacionCompra As Integer, ByVal IdAgrupacionPromo As Integer, ByVal IdUsuario As String) As Boolean
        'miguelperez 26/Febrero/2018  
        Try
            MyBase.SQL = "usp_CapturaPromocionAgrupacion"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@IdPromocionB", SqlDbType.Int, 4, IdPromocion)
            MyBase.AddParameter("@IdAgrupacionCompraB", SqlDbType.Int, 4, IdAgrupacionCompra)
            MyBase.AddParameter("@IdAgrupacionPromoB", SqlDbType.Int, 4, IdAgrupacionPromo)
            MyBase.AddParameter("@IdUsuarioB", SqlDbType.VarChar, 8, IdUsuario)

            usp_CapturaPromocionAgrupacion = ExecuteStoredProcedure()
            MyBase.ClearParameters()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_BuscaPromocionAgrupacion(ByVal IdPromocion As Integer, ByVal IdAgrupacionCompra As Integer, ByVal IdAgrupacionPromo As Integer) As DataSet
        'miguelperez 26/Febrero/2018  
        Try
            usp_BuscaPromocionAgrupacion = New DataSet
            MyBase.SQL = "usp_BuscaPromocionAgrupacion"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@IdPromocionB", SqlDbType.Int, 4, IdPromocion)
            MyBase.AddParameter("@IdAgrupacionCompraB", SqlDbType.Int, 4, IdAgrupacionCompra)
            MyBase.AddParameter("@IdAgrupacionPromoB", SqlDbType.Int, 4, IdAgrupacionPromo)

            MyBase.FillDataSet(usp_BuscaPromocionAgrupacion, "SirCoPV")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerCuponesPromocion(ByVal IdPromocion As Integer, ByVal Tipo As String) As DataSet
        'miguelperez 27/Febrero/2019   
        Try
            usp_TraerCuponesPromocion = New DataSet
            MyBase.SQL = "usp_TraerCuponesPromocion"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@IdPromocionB", SqlDbType.Int, 10, IdPromocion)
            MyBase.AddParameter("@TipoB", SqlDbType.VarChar, 12, Tipo)

            MyBase.FillDataSet(usp_TraerCuponesPromocion, "SirCoPV")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaPromocionCupon(ByVal IdPromocion As Integer, ByVal IdCupon As Integer, ByVal IdUsuario As String) As Boolean
        'miguelperez 27/Febrero/2018  
        Try
            MyBase.SQL = "usp_CapturaPromocionCupon"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@IdPromocionB", SqlDbType.Int, 4, IdPromocion)
            MyBase.AddParameter("@IdCuponB", SqlDbType.Int, 4, IdCupon)
            MyBase.AddParameter("@IdUsuarioB", SqlDbType.VarChar, 8, IdUsuario)

            usp_CapturaPromocionCupon = ExecuteStoredProcedure()
            MyBase.ClearParameters()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_EliminaPromocionCupon(ByVal IdPromocion As Integer, ByVal IdCupon As Integer) As Boolean
        'miguelperez 27/Febrero/2018  
        Try
            MyBase.SQL = "usp_EliminaPromocionCupon"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@IdPromocionB", SqlDbType.Int, 4, IdPromocion)
            MyBase.AddParameter("@IdCuponB", SqlDbType.Int, 4, IdCupon)

            usp_EliminaPromocionCupon = ExecuteStoredProcedure()
            MyBase.ClearParameters()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerPromocionRecurrencia(ByVal IdPromocion As Integer, ByVal Dia As String, ByVal HoraIni As String, ByVal HoraFin As String) As DataSet
        'miguelperez 27/Febrero/2019   
        Try
            usp_TraerPromocionRecurrencia = New DataSet
            MyBase.SQL = "usp_TraerPromocionRecurrencia"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@IdPromocionB", SqlDbType.Int, 10, IdPromocion)
            MyBase.AddParameter("@DiaB", SqlDbType.VarChar, 9, Dia)
            MyBase.AddParameter("@HoraIniB", SqlDbType.VarChar, 5, HoraIni)
            MyBase.AddParameter("@HoraFinB", SqlDbType.VarChar, 5, HoraFin)

            MyBase.FillDataSet(usp_TraerPromocionRecurrencia, "SirCoPV")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaPromocionRecurrencia(ByVal IdPromocion As Integer, ByVal Dia As String, ByVal HoraIni As String, ByVal HoraFin As String, ByVal IdUsuario As String) As Boolean
        'miguelperez 27/Febrero/2018  
        Try
            MyBase.SQL = "usp_CapturaPromocionRecurrencia"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@IdPromocionB", SqlDbType.Int, 10, IdPromocion)
            MyBase.AddParameter("@DiaB", SqlDbType.VarChar, 9, Dia)
            MyBase.AddParameter("@HoraIniB", SqlDbType.VarChar, 5, HoraIni)
            MyBase.AddParameter("@HoraFinB", SqlDbType.VarChar, 5, HoraFin)
            MyBase.AddParameter("@IdUsuarioB", SqlDbType.VarChar, 8, IdUsuario)

            usp_CapturaPromocionRecurrencia = ExecuteStoredProcedure()
            MyBase.ClearParameters()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_EliminaPromocionRecurrencia(ByVal IdPromocion As Integer, ByVal Dia As String, ByVal HoraIni As String) As Boolean
        'miguelperez 27/Febrero/2018  
        Try
            MyBase.SQL = "usp_EliminaPromocionRecurrencia"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@IdPromocionB", SqlDbType.Int, 10, IdPromocion)
            MyBase.AddParameter("@DiaB", SqlDbType.VarChar, 9, Dia)
            MyBase.AddParameter("@HoraIniB", SqlDbType.VarChar, 5, HoraIni)

            usp_EliminaPromocionRecurrencia = ExecuteStoredProcedure()
            MyBase.ClearParameters()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerPromocionesExclusiones(ByVal IdPromocion As Integer) As DataSet
        'miguelperez 27/Febrero/2019   
        Try
            usp_TraerPromocionesExclusiones = New DataSet
            MyBase.SQL = "usp_TraerPromocionesExclusiones"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@IdPromocionB", SqlDbType.Int, 10, IdPromocion)

            MyBase.FillDataSet(usp_TraerPromocionesExclusiones, "SirCoPV")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaPromocionesExclusiones(ByVal IdPromocion As Integer, ByVal Marca As String, ByVal Estilon As String, ByVal IdUsuario As String) As Boolean
        'miguelperez 27/Febrero/2018  
        Try
            MyBase.SQL = "usp_CapturaPromocionesExclusiones"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@IdPromocionB", SqlDbType.Int, 10, IdPromocion)
            MyBase.AddParameter("@MarcaB", SqlDbType.VarChar, 3, Marca)
            MyBase.AddParameter("@EstilonB", SqlDbType.VarChar, 7, Estilon)
            MyBase.AddParameter("@IdUsuarioB", SqlDbType.VarChar, 8, IdUsuario)

            usp_CapturaPromocionesExclusiones = ExecuteStoredProcedure()
            MyBase.ClearParameters()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_EliminaPromocionExclusion(ByVal IdPromocion As Integer, ByVal Marca As String, ByVal Estilon As String) As Boolean
        'miguelperez 27/Febrero/2018  
        Try
            MyBase.SQL = "usp_EliminaPromocionExclusion"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@IdPromocionB", SqlDbType.Int, 10, IdPromocion)
            MyBase.AddParameter("@MarcaB", SqlDbType.VarChar, 3, Marca)
            MyBase.AddParameter("@EstilonB", SqlDbType.VarChar, 7, Estilon)

            usp_EliminaPromocionExclusion = ExecuteStoredProcedure()
            MyBase.ClearParameters()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerPlazasSucursales(ByVal Tipo As String, Plaza As Integer) As DataSet
        'miguelperez 27/Febrero/2019   
        Try
            usp_TraerPlazasSucursales = New DataSet
            MyBase.SQL = "usp_TraerPlazasSucursales"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@TipoB", SqlDbType.VarChar, 8, Tipo)
            MyBase.AddParameter("@IdPlazaB", SqlDbType.Int, 10, Plaza)

            MyBase.FillDataSet(usp_TraerPlazasSucursales, "SirCoPV")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerPromocionesPlazas(ByVal IdPromocion As Integer, ByVal Plaza As String, ByVal Sucursal As String) As DataSet
        'miguelperez 27/Febrero/2019   
        Try
            usp_TraerPromocionesPlazas = New DataSet
            MyBase.SQL = "usp_TraerPromocionesPlazas"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@IdPromocionB", SqlDbType.Int, 10, IdPromocion)
            MyBase.AddParameter("@PlazaB", SqlDbType.VarChar, 2, Plaza)
            MyBase.AddParameter("@SucursalB", SqlDbType.VarChar, 2, Sucursal)

            MyBase.FillDataSet(usp_TraerPromocionesPlazas, "SirCoPV")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerPromocionesRestricciones(ByVal Id As Integer, ByVal Tipo As String) As DataSet
        'miguelperez 27/Febrero/2019   
        Try

            usp_TraerPromocionesRestricciones = New DataSet
            MyBase.SQL = "usp_TraerPromocionesRestricciones"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@IdB", SqlDbType.Int, 10, Id)
            MyBase.AddParameter("@TipoB", SqlDbType.VarChar, 10, Tipo)

            MyBase.FillDataSet(usp_TraerPromocionesRestricciones, "SirCoPV")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaRestriccion(ByVal Id As Integer, ByVal Tipo As String, ByVal Descripcion As String, ByVal Imagen() As Byte, ByVal Prioridad As Integer, ByVal IdUsuario As String) As Boolean
        'miguelperez 27/Febrero/2018  
        Try
            Dim TamañoImagen As Integer
            If Imagen Is Nothing Then
                TamañoImagen = 16
            Else
                TamañoImagen = Imagen.Length
            End If
            MyBase.SQL = "usp_CapturaRestriccion"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@IdB", SqlDbType.Int, 10, Id)
            MyBase.AddParameter("@TipoB", SqlDbType.VarChar, 10, Tipo)
            MyBase.AddParameter("@DescripcionB", SqlDbType.VarChar, 100, Descripcion)
            MyBase.AddParameter("@ImagenB", SqlDbType.VarBinary, TamañoImagen, Imagen)
            MyBase.AddParameter("@PrioridadB", SqlDbType.Int, 10, Prioridad)
            MyBase.AddParameter("@IdUsuarioB", SqlDbType.VarChar, 8, IdUsuario)

            usp_CapturaRestriccion = ExecuteStoredProcedure()
            MyBase.ClearParameters()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ModificaPrioridad(ByVal Id As Integer, ByVal Tipo As String, ByVal NuevaPrioridad As Integer, ByVal Clasificacion As String, ByVal IdUsuario As String) As Boolean
        'miguelperez 27/Febrero/2018  
        Try
            MyBase.SQL = "usp_ModificaPrioridad"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@IdB", SqlDbType.Int, 10, Id)
            MyBase.AddParameter("@TipoB", SqlDbType.VarChar, 10, Tipo)
            MyBase.AddParameter("@NuevaPrioridadB", SqlDbType.Int, 10, NuevaPrioridad)
            MyBase.AddParameter("@ClasificacionB", SqlDbType.VarChar, 10, Clasificacion)
            MyBase.AddParameter("@IdUsuarioB", SqlDbType.VarChar, 8, IdUsuario)

            usp_ModificaPrioridad = ExecuteStoredProcedure()
            MyBase.ClearParameters()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_EliminaRestricciones(ByVal Id As Integer, ByVal Tipo As String, ByVal Prioridad As Integer) As Boolean
        'miguelperez 27/Febrero/2018  
        Try
            MyBase.SQL = "usp_EliminaRestricciones"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@IdB", SqlDbType.Int, 10, Id)
            MyBase.AddParameter("@TipoB", SqlDbType.VarChar, 10, Tipo)
            MyBase.AddParameter("@PrioridadB", SqlDbType.Int, 10, Prioridad)

            usp_EliminaRestricciones = ExecuteStoredProcedure()
            MyBase.ClearParameters()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_BuscaPromocionesPlazas(ByVal IdPromocion As Integer, ByVal Plaza As String) As DataSet
        'miguelperez 27/Febrero/2019   
        Try
            usp_BuscaPromocionesPlazas = New DataSet
            MyBase.SQL = "usp_BuscaPromocionesPlazas"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@IdPromocionB", SqlDbType.Int, 10, IdPromocion)
            MyBase.AddParameter("@PlazaB", SqlDbType.VarChar, 2, Plaza)

            MyBase.FillDataSet(usp_BuscaPromocionesPlazas, "SirCoPV")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaPromocionesPlazas(ByVal IdPromocion As Integer, ByVal Plaza As String, ByVal Sucursal As String, ByVal IdUsuario As String) As Boolean
        'miguelperez 27/Febrero/2018  
        Try
            MyBase.SQL = "usp_CapturaPromocionesPlazas"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@IdPromocionB", SqlDbType.Int, 10, IdPromocion)
            MyBase.AddParameter("@PlazaB", SqlDbType.VarChar, 2, Plaza)
            MyBase.AddParameter("@SucursalB", SqlDbType.VarChar, 2, Sucursal)
            MyBase.AddParameter("@IdUsuarioB", SqlDbType.VarChar, 8, IdUsuario)

            usp_CapturaPromocionesPlazas = ExecuteStoredProcedure()
            MyBase.ClearParameters()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_EliminaPromocionesPlaza(ByVal IdPromocion As Integer, ByVal Plaza As String, ByVal Sucursal As String) As Boolean
        'miguelperez 27/Febrero/2018  
        Try
            MyBase.SQL = "usp_EliminaPromocionesPlaza"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@IdPromocionB", SqlDbType.Int, 10, IdPromocion)
            MyBase.AddParameter("@PlazaB", SqlDbType.VarChar, 2, Plaza)
            MyBase.AddParameter("@SucursalB", SqlDbType.VarChar, 2, Sucursal)

            usp_EliminaPromocionesPlaza = ExecuteStoredProcedure()
            MyBase.ClearParameters()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerSeñalizador(ByVal IdSeñalizador As Integer, ByVal Señalizador As String) As DataSet
        'miguelperez 03/Marzo/2019   
        Try
            usp_TraerSeñalizador = New DataSet
            MyBase.SQL = "usp_TraerSeñalizador"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@IdSeñalizadorB", SqlDbType.Int, 10, IdSeñalizador)
            MyBase.AddParameter("@SeñalizadorB", SqlDbType.VarChar, 30, Señalizador)

            MyBase.FillDataSet(usp_TraerSeñalizador, "SirCoPV")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerTipoPerciero(ByVal IdTipoPerciero As Integer, ByVal TipoPerciero As String) As DataSet
        'miguelperez 03/Marzo/2019   
        Try
            usp_TraerTipoPerciero = New DataSet
            MyBase.SQL = "usp_TraerTipoPerciero"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@IdTipoPercieroB", SqlDbType.Int, 10, IdTipoPerciero)
            MyBase.AddParameter("@TipoPercieroB", SqlDbType.VarChar, 30, TipoPerciero)

            MyBase.FillDataSet(usp_TraerTipoPerciero, "SirCoPV")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_EliminaPromocionAgrupacion(ByVal IdPromocion As Integer, ByVal Renglon As Integer) As Boolean
        'miguelperez 03/Marzo/2018  
        Try
            MyBase.SQL = "usp_EliminaPromocionAgrupacion"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@IdPromocionB", SqlDbType.Int, 10, IdPromocion)
            MyBase.AddParameter("@RenglonB", SqlDbType.Int, 10, Renglon)

            usp_EliminaPromocionAgrupacion = ExecuteStoredProcedure()
            MyBase.ClearParameters()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region

End Class
