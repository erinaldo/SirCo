Imports System.Data.Odbc
''Tony Garcia - 28/Diciembre/2012 - 09:20 a.m.
Public Class DALCalendario
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
    Public Function usp_TraerDiasFestivosCal(ByVal Mes As String, ByVal Año As String) As DataSet
        ''Tony Garcia - 28/Diciembre/2012 - 09:40 a.m.
        Try
            usp_TraerDiasFestivosCal = New DataSet
            MyBase.SQL = "CALL usp_TraerDiasFestivosCal(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@MesB", OdbcType.Char, 2, Mes)
            MyBase.AddParameter("@AnioB", OdbcType.Char, 4, Año)

            MyBase.FillDataSet(usp_TraerDiasFestivosCal, "dwh")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerSapicaCal(ByVal Año As String) As DataSet
        ''Tony Garcia - 08/Enero/2013 - 10:40 a.m.
        Try
            usp_TraerSapicaCal = New DataSet
            MyBase.SQL = "CALL usp_TraerSapicaCal(?)"

            MyBase.InitializeCommand()
            'MyBase.AddParameter("@MesB", OdbcType.Char, 2, Mes)
            MyBase.AddParameter("@AnioB", OdbcType.Char, 4, Año)

            MyBase.FillDataSet(usp_TraerSapicaCal, "dwh")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerDiasResProvCal(ByVal Proveedor As String, ByVal Marca As String, ByVal FechaIni As String, _
                                            ByVal FechaFin As String) As DataSet
        ''Tony Garcia - 28/Diciembre/2012 - 04:40 p.m.
        Try
            usp_TraerDiasResProvCal = New DataSet
            MyBase.SQL = "CALL usp_TraerDiasResProvCal(?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@proveedorB", OdbcType.Char, 3, Proveedor)
            MyBase.AddParameter("@marcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@FechaIniB", OdbcType.Char, 10, FechaIni)
            MyBase.AddParameter("@FechaFinB", OdbcType.Char, 10, FechaFin)

            MyBase.FillDataSet(usp_TraerDiasResProvCal, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerMarca(ByVal Marca As String, ByVal Descripcion As String) As DataSet
        ''Tony Garcia - 12/Enero/2013 - 01:00 p.m.
        Try
            usp_TraerMarca = New DataSet
            MyBase.SQL = "Call usp_TraerMarca(?,?)"

            MyBase.InitializeCommand()

            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@DescripB", OdbcType.Char, 30, Descripcion)

            MyBase.FillDataSet(usp_TraerMarca, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
