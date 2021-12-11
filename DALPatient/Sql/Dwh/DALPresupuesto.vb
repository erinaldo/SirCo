Public Class DALPresupuesto
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
    Public Function usp_CapturaPresupuesto(ByVal IdSucursal As Integer, ByVal Año As String, ByVal Mes As String, ByVal IdDivision As Integer, ByVal Division As String, ByVal Presupuesto As Decimal, ByVal IdUsuario As String) As Boolean
        'miguelperez 25/Abril/2019   
        Try
            MyBase.SQL = "usp_CapturaPresupuesto"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@IdSucursalB", SqlDbType.Int, 10, IdSucursal)
            MyBase.AddParameter("@AñoB", SqlDbType.VarChar, 4, Año)
            MyBase.AddParameter("@MesB", SqlDbType.VarChar, 2, Mes)
            MyBase.AddParameter("@IdDivisionB", SqlDbType.Int, 10, IdDivision)
            MyBase.AddParameter("@DivisionB", SqlDbType.VarChar, 30, Division)
            MyBase.AddParameter("@PresupuestoB", SqlDbType.Decimal, 18, Presupuesto)
            MyBase.AddParameter("@IdUsuarioB", SqlDbType.VarChar, 8, IdUsuario)

            usp_CapturaPresupuesto = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerPresupuesto(ByVal Tipo As String, ByVal Año As String, ByVal Mes As String) As DataSet
        'miguelperez 10/Abril/2019   
        Try
            usp_TraerPresupuesto = New DataSet
            MyBase.SQL = "usp_TraerPresupuesto"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@TipoB", SqlDbType.VarChar, 12, Tipo)
            MyBase.AddParameter("@AñoB", SqlDbType.VarChar, 4, Año)
            MyBase.AddParameter("@MesB", SqlDbType.VarChar, 2, Mes)

            MyBase.FillDataSet(usp_TraerPresupuesto, "SirCoDWH")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ModificaPresupuesto(ByVal IdSucursal As Integer, ByVal Año As String, ByVal Mes As String, ByVal IdDivision As Integer, ByVal Presupuesto As Decimal, ByVal IdUsuario As String) As Boolean
        'miguelperez 25/Abril/2019   
        Try
            MyBase.SQL = "usp_ModificaPresupuesto"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@IdSucursalB", SqlDbType.Int, 10, IdSucursal)
            MyBase.AddParameter("@AñoB", SqlDbType.VarChar, 4, Año)
            MyBase.AddParameter("@MesB", SqlDbType.VarChar, 2, Mes)
            MyBase.AddParameter("@IdDivisionB", SqlDbType.Int, 10, IdDivision)
            MyBase.AddParameter("@PresupuestoB", SqlDbType.Decimal, 18, Presupuesto)
            MyBase.AddParameter("@IdUsuarioB", SqlDbType.VarChar, 8, IdUsuario)

            usp_ModificaPresupuesto = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerCatPresupuesto(ByVal Tipo As String, ByVal Año As String, ByVal Mes As String, ByVal Plaza As Integer, ByVal Sucursal As Integer, ByVal Division As Integer) As DataSet
        'miguelperez 10/Abril/2019   
        Try
            usp_TraerCatPresupuesto = New DataSet
            MyBase.SQL = "usp_TraerCatPresupuesto"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@TipoB", SqlDbType.VarChar, 12, Tipo)
            MyBase.AddParameter("@AñoB", SqlDbType.VarChar, 4, Año)
            MyBase.AddParameter("@MesB", SqlDbType.VarChar, 2, Mes)
            MyBase.AddParameter("@IdPlazaB", SqlDbType.Int, 4, Plaza)
            MyBase.AddParameter("@IdSucursalB", SqlDbType.Int, 4, Sucursal)
            MyBase.AddParameter("@IdDivisionB", SqlDbType.Int, 4, Division)

            MyBase.FillDataSet(usp_TraerCatPresupuesto, "SirCoDWH")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
