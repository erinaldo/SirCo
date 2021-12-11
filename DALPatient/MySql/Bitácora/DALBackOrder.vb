Imports System.Data.Odbc


Public Class DALBackOrder
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

    Public Function usp_PpalBackOrder(ByVal Opcion As Integer, ByVal Proveedor As String, ByVal Sucursal As String, _
                                    ByVal AnioIni As Integer, ByVal MesIni As Integer, ByVal AnioFin As Integer, ByVal MesFin As Integer, _
                                    ByVal IdDivision As Integer, _
                                    ByVal IdDepto As Integer, ByVal DescripFamilia As String, ByVal DescripLinea As String, _
                                    ByVal DescripL1 As String, ByVal DescripL2 As String, ByVal DescripL3 As String, ByVal DescripL4 As String, _
                                    ByVal DescripL5 As String, ByVal DescripL6 As String, ByVal Marca As String, ByVal Modelo As String, _
                                    ByVal FecIni As Date, ByVal FecFin As Date, ByVal S1 As Integer, _
                                    ByVal S2 As String, ByVal S3 As String, ByVal S4 As String, ByVal S5 As String) As DataSet
        'Tony Garcia - 31/Mar/2014 - 11:00 am
        Try
            usp_PpalBackOrder = New DataSet
            MyBase.SQL = "CALL usp_PpalBackOrder(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@opcion", OdbcType.SmallInt, 2, Opcion)
            MyBase.AddParameter("@proveedorb", OdbcType.Char, 3, Proveedor)
            MyBase.AddParameter("@sucursalb", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@aniob", OdbcType.SmallInt, 4, AnioIni)
            MyBase.AddParameter("@mesb", OdbcType.SmallInt, 4, MesFin)
            MyBase.AddParameter("@aniob", OdbcType.SmallInt, 4, AnioIni)
            MyBase.AddParameter("@mesb", OdbcType.SmallInt, 4, MesFin)
            MyBase.AddParameter("@IdDivision", OdbcType.Int, 16, IdDivision)
            MyBase.AddParameter("@IdDepto", OdbcType.Int, 16, IdDepto)
            MyBase.AddParameter("@DescripFamilia", OdbcType.Char, 30, DescripFamilia)
            MyBase.AddParameter("@DescripLinea", OdbcType.Char, 30, DescripLinea)
            MyBase.AddParameter("@DescripL1", OdbcType.Char, 30, DescripL1)
            MyBase.AddParameter("@DescripL2", OdbcType.Char, 30, DescripL2)
            MyBase.AddParameter("@DescripL3", OdbcType.Char, 30, DescripL3)
            MyBase.AddParameter("@DescripL4", OdbcType.Char, 30, DescripL4)
            MyBase.AddParameter("@DescripL5", OdbcType.Char, 30, DescripL5)
            MyBase.AddParameter("@DescripL6", OdbcType.Char, 30, DescripL6)
            MyBase.AddParameter("@Marca", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@Modelo", OdbcType.Char, 7, Modelo)
            MyBase.AddParameter("@fecini", OdbcType.Date, 10, FecIni)
            MyBase.AddParameter("@fecfin", OdbcType.Date, 10, FecFin)
            MyBase.AddParameter("@s1", OdbcType.SmallInt, 2, S1)
            MyBase.AddParameter("@s2", OdbcType.SmallInt, 2, S2)
            MyBase.AddParameter("@s3", OdbcType.SmallInt, 2, S3)
            MyBase.AddParameter("@s4", OdbcType.SmallInt, 2, S4)
            MyBase.AddParameter("@s5", OdbcType.SmallInt, 2, S5)
            MyBase.FillDataSet(usp_PpalBackOrder, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function



    Public Function usp_TraerSemanasBackOrder(ByVal FecIni As Date, ByVal FecFin As Date) As DataSet
        Try
            usp_TraerSemanasBackOrder = New DataSet
            MyBase.SQL = "CALL usp_TraerSemanasBackOrder(?,?)"

            MyBase.InitializeCommand()
           
            MyBase.AddParameter("@fecini", OdbcType.Date, 10, FecIni)
            MyBase.AddParameter("@fecfin", OdbcType.Date, 10, FecFin)
           
            MyBase.FillDataSet(usp_TraerSemanasBackOrder, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerFechasSemana(ByVal Anio As Integer, ByVal Semana As Integer) As DataSet
        Try
            usp_TraerFechasSemana = New DataSet
            MyBase.SQL = "CALL usp_TraerFechasSemana(?,?)"

            MyBase.InitializeCommand()

            MyBase.AddParameter("@Anio", OdbcType.SmallInt, 4, Anio)
            MyBase.AddParameter("@Semana", OdbcType.SmallInt, 2, Semana)

            MyBase.FillDataSet(usp_TraerFechasSemana, "dwh")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

#End Region
End Class
