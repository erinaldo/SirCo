Imports System.Data.Odbc
'miguel pérez 09/Octubre/2012 10:43 a.m.

Public Class DALRebaja
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

    Public Function usp_PpalRebaja(ByVal sucursal As String, ByVal FechaIni As String, ByVal FechaFin As String, ByVal Division As String, ByVal Depto As String, ByVal Familia As String, ByVal Linea As String,
    ByVal L1 As String, ByVal L2 As String, ByVal L3 As String, ByVal L4 As String, ByVal L5 As String, ByVal L6 As String, ByVal Marca As String, ByVal idagrupacion As Integer) As DataSet
        'miguel pérez 11/Mar/2013
        Try
            usp_PpalRebaja = New DataSet
            MyBase.SQL = "CALL usp_PpalRebaja(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@FechaIniB", OdbcType.Date, 10, FechaIni)
            MyBase.AddParameter("@FechaFinB", OdbcType.Date, 10, FechaFin)
            MyBase.AddParameter("@sucursalB", OdbcType.VarChar, 2, sucursal)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@DivisionB", OdbcType.Char, 30, Division)
            MyBase.AddParameter("@DeptoB", OdbcType.Char, 30, Depto)
            MyBase.AddParameter("@FamiliaB", OdbcType.Char, 30, Familia)
            MyBase.AddParameter("@LineaB", OdbcType.Char, 30, Linea)
            MyBase.AddParameter("@L1B", OdbcType.Char, 30, L1)
            MyBase.AddParameter("@L2B", OdbcType.Char, 30, L2)
            MyBase.AddParameter("@L3B", OdbcType.Char, 30, L3)
            MyBase.AddParameter("@L4B", OdbcType.Char, 30, L4)
            MyBase.AddParameter("@L5B", OdbcType.Char, 30, L5)
            MyBase.AddParameter("@L6B", OdbcType.Char, 30, L6)
            MyBase.AddParameter("@IdAgrupacionB", OdbcType.Int, 16, idagrupacion)


            MyBase.FillDataSet(usp_PpalRebaja, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_CalculaAntInvent(ByVal Sucursal As String, ByVal Marca As String) As Boolean
        'miguel pérez  19/Mar/2013
        Try
            MyBase.SQL = "Call usp_CalculaAntInvent(?,?)"
            MyBase.InitializeCommand()

            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)

            usp_CalculaAntInvent = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

#End Region
End Class
