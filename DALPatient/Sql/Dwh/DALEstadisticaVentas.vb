Public Class DALEstadisticaVentas
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
    Public Function usp_TraerVentasBase(ByVal Tipo As String, ByVal Plaza As Integer, ByVal IdSucursal As Integer, ByVal FecIni As String, ByVal FecFin As String, ByVal Division As String, ByVal Depto As String, ByVal Familia As String, ByVal Linea As String, ByVal L1 As String, ByVal L2 As String, ByVal L3 As String, ByVal L4 As String, ByVal L5 As String, ByVal L6 As String, ByVal Marca As String, ByVal Modelo As String, ByVal AñoAnterior As Boolean, ByVal AntDia As Boolean, ByVal AntSemana As Boolean, ByVal Miles As Integer, ByVal IdAgrupacion As Integer, ByVal SoloSucVta As String) As DataSet
        'miguelperez 10/Abril/2019   
        Try
            usp_TraerVentasBase = New DataSet
            MyBase.SQL = "usp_TraerVentasBase"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@TipoB", SqlDbType.VarChar, 15, Tipo)
            MyBase.AddParameter("@PlazaB", SqlDbType.Int, 10, Plaza)
            MyBase.AddParameter("@IdSucursalB", SqlDbType.Int, 10, IdSucursal)
            MyBase.AddParameter("@FechaIniB", SqlDbType.VarChar, 10, FecIni)
            MyBase.AddParameter("@FechaFinB", SqlDbType.VarChar, 10, FecFin)
            MyBase.AddParameter("@DivisionB", SqlDbType.VarChar, 30, Division)
            MyBase.AddParameter("@DeptoB", SqlDbType.VarChar, 30, Depto)
            MyBase.AddParameter("@FamiliaB", SqlDbType.VarChar, 30, Familia)
            MyBase.AddParameter("@LineaB", SqlDbType.VarChar, 30, Linea)
            MyBase.AddParameter("@L1B", SqlDbType.VarChar, 30, L1)
            MyBase.AddParameter("@L2B", SqlDbType.VarChar, 30, L2)
            MyBase.AddParameter("@L3B", SqlDbType.VarChar, 30, L3)
            MyBase.AddParameter("@L4B", SqlDbType.VarChar, 30, L4)
            MyBase.AddParameter("@L5B", SqlDbType.VarChar, 30, L5)
            MyBase.AddParameter("@L6B", SqlDbType.VarChar, 30, L6)
            MyBase.AddParameter("@MarcaB", SqlDbType.VarChar, 3, Marca)
            MyBase.AddParameter("@ModeloB", SqlDbType.VarChar, 7, Modelo)
            MyBase.AddParameter("@AnoAnt", SqlDbType.Bit, 2, AñoAnterior)
            MyBase.AddParameter("@AntDia", SqlDbType.Bit, 2, AntDia)
            MyBase.AddParameter("@AntSem", SqlDbType.Bit, 2, AntSemana)
            MyBase.AddParameter("@MilesB", SqlDbType.Int, 10, Miles)
            MyBase.AddParameter("@IdAgrupacionB", SqlDbType.Int, 10, IdAgrupacion)
            MyBase.AddParameter("@SoloSucVtaB", SqlDbType.VarChar, 1, SoloSucVta)

            MyBase.Command.CommandTimeout = 120

            MyBase.FillDataSet(usp_TraerVentasBase, "SirCoDWH")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerEstructuraClave(ByVal Tipo As String, ByVal Clave As String, ByVal Id As Integer) As DataSet
        'miguelperez 10/Abril/2019   
        Try
            usp_TraerEstructuraClave = New DataSet
            MyBase.SQL = "usp_TraerEstructuraClave"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@TipoB", SqlDbType.VarChar, 15, Tipo)
            MyBase.AddParameter("@ClaveB", SqlDbType.VarChar, 10, Clave)
            MyBase.AddParameter("@IdB", SqlDbType.Int, 10, Id)

            MyBase.FillDataSet(usp_TraerEstructuraClave, "SirCoDWH")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region

End Class
