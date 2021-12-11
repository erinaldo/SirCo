Imports System.Data.Odbc
'miguel pérez 29/Diciembre/2012 01:44 p.m.

Public Class DALOperaciones
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

    Public Function usp_TraerOperaciones(ByVal Tipo As String, ByVal Sucursal As String) As DataSet
        'miguel pérez 30/Diciembre/2012 09:30 a.m.
        Try
            usp_TraerOperaciones = New DataSet
            MyBase.SQL = "CALL usp_TraerOperaciones(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@TipoB", OdbcType.Char, 8, Tipo)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.FillDataSet(usp_TraerOperaciones, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerIdFolioBulto(ByVal CveSucursal As String) As DataSet
        'mreyes 20/Enero/2012 11:29 a.m.
        Try
            usp_TraerIdFolioBulto = New DataSet
            MyBase.SQL = "CALL usp_TraerIdFolioBulto(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, CveSucursal)

            MyBase.FillDataSet(usp_TraerIdFolioBulto, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerIdFolio(ByVal IdFolioSuc As String) As DataSet
        'mreyes 20/Enero/2012 11:29 a.m.
        Try
            usp_TraerIdFolio = New DataSet
            MyBase.SQL = "CALL usp_TraerIdFolio(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@idfoliosucb", OdbcType.Char, 8, IdFolioSuc)

            MyBase.FillDataSet(usp_TraerIdFolio, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_ActualizarFoliosOperaciones(ByVal Tipo As String, ByVal Sucursal As String) As Boolean
        'miguel pérez 30/Diciembre/2012 09:30 a.m.
        Try
            MyBase.SQL = "CALL usp_ActualizarFoliosOperaciones(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@TipoB", OdbcType.Char, 8, Tipo)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            usp_ActualizarFoliosOperaciones = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

#End Region
End Class
