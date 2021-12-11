Public Class DALAgrupaciones
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
    Public Function usp_TraerAgrupaciones(ByVal IdAgrupacion As Integer, ByVal Nombre As String) As DataSet
        'miguelperez 02/Febrero/2019   
        Try
            usp_TraerAgrupaciones = New DataSet
            MyBase.SQL = "usp_TraerAgrupaciones"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@IdAgrupacionB", SqlDbType.Int, 10, IdAgrupacion)
            MyBase.AddParameter("@NombreB", SqlDbType.VarChar, 30, Nombre)

            MyBase.FillDataSet(usp_TraerAgrupaciones, "SirCoPV")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerEstructura(ByVal Tipo As String, Optional Division As Integer = 0, Optional Departamento As Integer = 0, Optional Familia As Integer = 0, Optional Linea As Integer = 0, Optional L1 As Integer = 0, Optional L2 As Integer = 0, Optional L3 As Integer = 0, Optional L4 As Integer = 0, Optional L5 As Integer = 0, Optional L6 As Integer = 0) As DataSet
        'miguelperez 02/Febrero/2019   
        Try
            usp_TraerEstructura = New DataSet
            MyBase.SQL = "usp_TraerEstructura"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@TipoB", SqlDbType.VarChar, 12, Tipo)
            MyBase.AddParameter("@DivisionB", SqlDbType.Int, 10, Division)
            MyBase.AddParameter("@DepartamentoB", SqlDbType.Int, 10, Departamento)
            MyBase.AddParameter("@FamiliaB", SqlDbType.Int, 10, Familia)
            MyBase.AddParameter("@LineaB", SqlDbType.Int, 10, Linea)
            MyBase.AddParameter("@L1B", SqlDbType.Int, 10, L1)
            MyBase.AddParameter("@L2B", SqlDbType.Int, 10, L2)
            MyBase.AddParameter("@L3B", SqlDbType.Int, 10, L3)
            MyBase.AddParameter("@L4B", SqlDbType.Int, 10, L4)
            MyBase.AddParameter("@L5B", SqlDbType.Int, 10, L5)
            MyBase.AddParameter("@L6B", SqlDbType.Int, 10, L6)

            MyBase.FillDataSet(usp_TraerEstructura, "SirCoPV")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaAgrupacion(ByVal Nombre As String, ByVal Fecha As String, ByVal IdUsuario As String) As DataSet
        'miguelperez 06/Febrero/2018  
        Try
            usp_CapturaAgrupacion = New DataSet
            MyBase.SQL = "usp_CapturaAgrupacion"

            MyBase.InitializeCommand()

            MyBase.AddParameter("@NombreB", SqlDbType.VarChar, 30, Nombre)
            MyBase.AddParameter("@FechaB", SqlDbType.VarChar, 10, Fecha)
            MyBase.AddParameter("@IdUsuarioB", SqlDbType.VarChar, 8, IdUsuario)

            MyBase.FillDataSet(usp_CapturaAgrupacion, "SirCoPV")
            'usp_CapturaAgrupacion = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ModificaAgrupacion(ByVal IdAgrupacion As Integer, ByVal Nombre As String, ByVal IdUsuario As String) As Boolean
        'miguelperez 06/Febrero/2018  
        Try
            MyBase.SQL = "EXEC usp_ModificaAgrupacion "

            MyBase.InitializeCommand()

            MyBase.AddParameter("@IdAgrupacionB", SqlDbType.Int, 10, IdAgrupacion)
            MyBase.AddParameter("@NombreB", SqlDbType.VarChar, 30, Nombre)
            MyBase.AddParameter("@IdUsuarioB", SqlDbType.VarChar, 8, IdUsuario)

            usp_ModificaAgrupacion = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerAgrupacionesDet(ByVal IdAgrupacion As Integer, ByVal Renglon As Integer) As DataSet
        'miguelperez 07/Febrero/2019   
        Try
            usp_TraerAgrupacionesDet = New DataSet
            MyBase.SQL = "usp_TraerAgrupacionesDet"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@IdAgrupacionB", SqlDbType.Int, 10, IdAgrupacion)
            MyBase.AddParameter("@RenglonB", SqlDbType.Int, 10, Renglon)

            MyBase.FillDataSet(usp_TraerAgrupacionesDet, "SirCoPV")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_BuscaAgrupacionDet(ByVal IdAgrupacion As Integer, ByVal Nivel As String, ByVal IdDivision As Integer, ByVal IdDepto As Integer, ByVal idFamilia As Integer, ByVal IdLinea As Integer, ByVal IdL1 As Integer, ByVal IdL2 As Integer, ByVal IdL3 As Integer, ByVal IdL4 As Integer, ByVal IdL5 As Integer, ByVal IdL6 As Integer, ByVal Marca As String, ByVal Estilon As String) As DataSet
        'miguelperez 07/Febrero/2019   
        Try
            usp_BuscaAgrupacionDet = New DataSet
            MyBase.SQL = "usp_BuscaAgrupacionDet"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@IdAgrupacionB", SqlDbType.Int, 10, IdAgrupacion)
            MyBase.AddParameter("@NivelB", SqlDbType.VarChar, 12, Nivel)
            MyBase.AddParameter("@IdDivisionesB", SqlDbType.Int, 10, IdDivision)
            MyBase.AddParameter("@IdDeptoB", SqlDbType.Int, 10, IdDepto)
            MyBase.AddParameter("@IdFamiliaB", SqlDbType.Int, 10, idFamilia)
            MyBase.AddParameter("@IdLineaB", SqlDbType.Int, 10, IdLinea)
            MyBase.AddParameter("@IdL1B", SqlDbType.Int, 10, IdL1)
            MyBase.AddParameter("@IdL2B", SqlDbType.Int, 10, IdL2)
            MyBase.AddParameter("@IdL3B", SqlDbType.Int, 10, IdL3)
            MyBase.AddParameter("@IdL4B", SqlDbType.Int, 10, IdL4)
            MyBase.AddParameter("@IdL5B", SqlDbType.Int, 10, IdL5)
            MyBase.AddParameter("@IdL6B", SqlDbType.Int, 10, IdL6)
            MyBase.AddParameter("@MarcaB", SqlDbType.VarChar, 3, Marca)
            MyBase.AddParameter("@EstilonB", SqlDbType.VarChar, 7, Estilon)

            MyBase.FillDataSet(usp_BuscaAgrupacionDet, "SirCoPV")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_BuscaAgrupacionPromoActiva(ByVal IdAgrupacion As Integer) As DataSet
        'miguelperez 07/Febrero/2019   
        Try
            usp_BuscaAgrupacionPromoActiva = New DataSet
            MyBase.SQL = "usp_BuscaAgrupacionPromoActiva"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@IdAgrupacionB", SqlDbType.Int, 10, IdAgrupacion)

            MyBase.FillDataSet(usp_BuscaAgrupacionPromoActiva, "SirCoPV")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_CapturaAgrupacionDet(ByVal IdAgrupacion As Integer, ByVal IdDivision As Integer, ByVal IdDepto As Integer, ByVal idFamilia As Integer, ByVal IdLinea As Integer, ByVal IdL1 As Integer, ByVal IdL2 As Integer, ByVal IdL3 As Integer, ByVal IdL4 As Integer, ByVal IdL5 As Integer, ByVal IdL6 As Integer, ByVal Marca As String, ByVal Estilon As String, ByVal Nivel As String, ByVal IdUsuario As String) As Boolean
        'miguelperez 08/Febrero/2018  
        Try
            MyBase.SQL = "usp_CapturaAgrupacionDet"
            MyBase.InitializeCommand()

            MyBase.AddParameter("@IdAgrupacionB", SqlDbType.Int, 10, IdAgrupacion)
            MyBase.AddParameter("@IdDivisionesB", SqlDbType.Int, 10, IdDivision)
            MyBase.AddParameter("@IdDeptoB", SqlDbType.Int, 10, IdDepto)
            MyBase.AddParameter("@IdFamiliaB", SqlDbType.Int, 10, idFamilia)
            MyBase.AddParameter("@IdLineaB", SqlDbType.Int, 10, IdLinea)
            MyBase.AddParameter("@IdL1B", SqlDbType.Int, 10, IdL1)
            MyBase.AddParameter("@IdL2B", SqlDbType.Int, 10, IdL2)
            MyBase.AddParameter("@IdL3B", SqlDbType.Int, 10, IdL3)
            MyBase.AddParameter("@IdL4B", SqlDbType.Int, 10, IdL4)
            MyBase.AddParameter("@IdL5B", SqlDbType.Int, 10, IdL5)
            MyBase.AddParameter("@IdL6B", SqlDbType.Int, 10, IdL6)
            MyBase.AddParameter("@MarcaB", SqlDbType.VarChar, 3, Marca)
            MyBase.AddParameter("@EstilonB", SqlDbType.VarChar, 7, Estilon)
            MyBase.AddParameter("@NivelB", SqlDbType.VarChar, 12, Nivel)
            MyBase.AddParameter("@IdUsuarioB", SqlDbType.VarChar, 8, IdUsuario)

            usp_CapturaAgrupacionDet = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_ModificaAgrupacionDet(ByVal IdAgrupacion As Integer, ByVal IdDivision As Integer, ByVal IdDepto As Integer, ByVal idFamilia As Integer, ByVal IdLinea As Integer, ByVal IdL1 As Integer, ByVal IdL2 As Integer, ByVal IdL3 As Integer, ByVal IdL4 As Integer, ByVal IdL5 As Integer, ByVal IdL6 As Integer, ByVal Marca As String, ByVal Estilon As String, ByVal Nivel As String, ByVal Renglon As Integer, ByVal IdUsuario As String) As Boolean
        'miguelperez 08/Febrero/2018  
        Try
            MyBase.SQL = "usp_ModificaAgrupacionDet"
            MyBase.InitializeCommand()

            MyBase.AddParameter("@IdAgrupacionB", SqlDbType.Int, 10, IdAgrupacion)
            MyBase.AddParameter("@IdDivisionesB", SqlDbType.Int, 10, IdDivision)
            MyBase.AddParameter("@IdDeptoB", SqlDbType.Int, 10, IdDepto)
            MyBase.AddParameter("@IdFamiliaB", SqlDbType.Int, 10, idFamilia)
            MyBase.AddParameter("@IdLineaB", SqlDbType.Int, 10, IdLinea)
            MyBase.AddParameter("@IdL1B", SqlDbType.Int, 10, IdL1)
            MyBase.AddParameter("@IdL2B", SqlDbType.Int, 10, IdL2)
            MyBase.AddParameter("@IdL3B", SqlDbType.Int, 10, IdL3)
            MyBase.AddParameter("@IdL4B", SqlDbType.Int, 10, IdL4)
            MyBase.AddParameter("@IdL5B", SqlDbType.Int, 10, IdL5)
            MyBase.AddParameter("@IdL6B", SqlDbType.Int, 10, IdL6)
            MyBase.AddParameter("@MarcaB", SqlDbType.VarChar, 3, Marca)
            MyBase.AddParameter("@EstilonB", SqlDbType.VarChar, 7, Estilon)
            MyBase.AddParameter("@NivelB", SqlDbType.VarChar, 12, Nivel)
            MyBase.AddParameter("@RenglonB", SqlDbType.Int, 10, Renglon)
            MyBase.AddParameter("@IdUsuarioB", SqlDbType.VarChar, 8, IdUsuario)

            usp_ModificaAgrupacionDet = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_EliminaAgrupacionDet(ByVal IdAgrupacion As Integer, ByVal Renglon As Integer) As Boolean
        'miguelperez 08/Febrero/2018  
        Try
            MyBase.SQL = "usp_EliminaAgrupacionDet"
            MyBase.InitializeCommand()

            MyBase.AddParameter("@IdAgrupacionB", SqlDbType.Int, 10, IdAgrupacion)
            MyBase.AddParameter("@RenglonB", SqlDbType.Int, 10, Renglon)

            usp_EliminaAgrupacionDet = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

#End Region

End Class
