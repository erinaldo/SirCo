Public Class DALCupones
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

    Public Function usp_TraerCupones(ByVal IdCupon As Integer, ByVal Estatus As String) As DataSet
        'miguelperez 13/Febrero/2019   
        Try
            usp_TraerCupones = New DataSet
            MyBase.SQL = "usp_TraerCupones"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@IdCuponB", SqlDbType.Int, 10, IdCupon)
            MyBase.AddParameter("@EstatusB", SqlDbType.VarChar, 15, Estatus)

            MyBase.FillDataSet(usp_TraerCupones, "SirCoPV")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_CapturaCupon(ByVal Nombre As String, ByVal Descripcion As String, ByVal Restricciones As String, ByVal Tipo As String, ByVal IdUsuario As String, ByVal fecIni As String, ByVal fecFin As String, ByVal Imagen As Byte()) As DataSet
        'miguelperez 13/Febrero/2018  
        Try
            usp_CapturaCupon = New DataSet
            MyBase.SQL = "usp_CapturaCupon"
            Dim TamañoImagen As Integer
            If Imagen Is Nothing Then
                TamañoImagen = 16
            Else
                TamañoImagen = Imagen.Length
            End If

            MyBase.InitializeCommand()

            MyBase.AddParameter("@NombreB", SqlDbType.VarChar, 25, Nombre)
            MyBase.AddParameter("@DescripcionB", SqlDbType.VarChar, 150, Descripcion)
            MyBase.AddParameter("@RestriccionesB", SqlDbType.VarChar, 150, Restricciones)
            MyBase.AddParameter("@TipoB", SqlDbType.VarChar, 15, Tipo)
            MyBase.AddParameter("@IdUsuarioB", SqlDbType.VarChar, 8, IdUsuario)
            MyBase.AddParameter("@FecIniB", SqlDbType.VarChar, 10, fecIni)
            MyBase.AddParameter("@FecFinB", SqlDbType.VarChar, 10, fecFin)
            MyBase.AddParameter("@ImagenB", SqlDbType.VarBinary, TamañoImagen, Imagen)

            MyBase.FillDataSet(usp_CapturaCupon, "SirCoPV")
            'usp_CapturaAgrupacion = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ModificaCupon(ByVal IdCupon As Integer, ByVal Nombre As String, ByVal Descripcion As String, ByVal Restricciones As String, ByVal Estatus As String, ByVal Tipo As String, ByVal IdUsuario As String, ByVal fecIni As String, ByVal fecFin As String, ByVal Imagen As Byte()) As Boolean
        'miguelperez 14/Febrero/2018  
        Try
            MyBase.SQL = "usp_ModificaCupon"
            Dim TamañoImagen As Integer
            If Imagen Is Nothing Then
                TamañoImagen = 16
            Else
                TamañoImagen = Imagen.Length
            End If
            MyBase.InitializeCommand()
            MyBase.AddParameter("@IdCuponB", SqlDbType.Int, 4, IdCupon)
            MyBase.AddParameter("@NombreB", SqlDbType.VarChar, 25, Nombre)
            MyBase.AddParameter("@DescripcionB", SqlDbType.VarChar, 150, Descripcion)
            MyBase.AddParameter("@RestriccionesB", SqlDbType.VarChar, 150, Restricciones)
            MyBase.AddParameter("@EstatusB", SqlDbType.VarChar, 15, Estatus)
            MyBase.AddParameter("@TipoB", SqlDbType.VarChar, 15, Tipo)
            MyBase.AddParameter("@FecIniB", SqlDbType.VarChar, 10, fecIni)
            MyBase.AddParameter("@FecFinB", SqlDbType.VarChar, 10, fecFin)
            MyBase.AddParameter("@IdUsuarioB", SqlDbType.VarChar, 8, IdUsuario)
            MyBase.AddParameter("@ImagenB", SqlDbType.VarBinary, TamañoImagen, Imagen)

            usp_ModificaCupon = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerFolioOperacion(ByVal Operacion As String, ByVal Sucursal As String, ByVal Usuario As String, Optional ByVal Tipo As String = "NORMAL", Optional ByVal Folio As Integer = 0) As DataSet
        'miguelperez 17/Febrero/2019   
        Try
            usp_TraerFolioOperacion = New DataSet
            MyBase.SQL = "usp_TraerFolioOperacion"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@OperacionB", SqlDbType.VarChar, 15, Operacion)
            MyBase.AddParameter("@SucursalB", SqlDbType.VarChar, 2, Sucursal)
            MyBase.AddParameter("@IdUsuarioB", SqlDbType.VarChar, 8, Usuario)
            MyBase.AddParameter("@TipoB", SqlDbType.VarChar, 15, Tipo)
            MyBase.AddParameter("@FolioB", SqlDbType.Int, 10, Folio)

            MyBase.FillDataSet(usp_TraerFolioOperacion, "SirCoPV")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerFolioCupon(ByVal IdCupon As Integer, ByVal Folio As String, ByVal Estatus As String) As DataSet
        'miguelperez 17/Febrero/2019   
        Try
            usp_TraerFolioCupon = New DataSet
            MyBase.SQL = "usp_TraerFolioCupon"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@IdCuponB", SqlDbType.Int, 10, IdCupon)
            MyBase.AddParameter("@FolioB", SqlDbType.VarChar, 20, Folio)
            MyBase.AddParameter("@EstatusB", SqlDbType.VarChar, 15, Estatus)

            MyBase.FillDataSet(usp_TraerFolioCupon, "SirCoPV")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaCuponDet(ByVal IdCupon As Integer, ByVal Folio As String, ByVal Estatus As String, ByVal IdUsuario As String) As Boolean
        'miguelperez 18/Febrero/2018  
        Try
            MyBase.SQL = "usp_CapturaCuponDet"
            MyBase.InitializeCommand()

            MyBase.AddParameter("@IdCuponB", SqlDbType.Int, 10, IdCupon)
            MyBase.AddParameter("@FolioB", SqlDbType.VarChar, 20, Folio)
            MyBase.AddParameter("@EstatusB", SqlDbType.VarChar, 15, Estatus)
            MyBase.AddParameter("@IdUsuarioB", SqlDbType.VarChar, 8, IdUsuario)

            usp_CapturaCuponDet = ExecuteStoredProcedure()
            MyBase.ClearParameters()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_EliminaCuponesDet(ByVal IdCupon As Integer, ByVal Folio As String) As Boolean
        'miguelperez 06/Marzo/2018  
        Try
            MyBase.SQL = "usp_EliminaCuponesDet"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@IdCuponB", SqlDbType.Int, 4, IdCupon)
            MyBase.AddParameter("@FolioB", SqlDbType.VarChar, 20, Folio)

            usp_EliminaCuponesDet = ExecuteStoredProcedure()
            MyBase.ClearParameters()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_BuscaCuponPromoActiva(ByVal IdCupon As Integer) As DataSet
        'miguelperez 07/Febrero/2019   
        Try
            usp_BuscaCuponPromoActiva = New DataSet
            MyBase.SQL = "usp_BuscaCuponPromoActiva"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@IdCuponB", SqlDbType.Int, 10, IdCupon)

            MyBase.FillDataSet(usp_BuscaCuponPromoActiva, "SirCoPV")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

#End Region
End Class
