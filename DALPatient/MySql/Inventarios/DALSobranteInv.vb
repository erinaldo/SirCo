Imports System.Data.Odbc
Public Class DALSobranteInv
    Inherits DALOdbc
#Region "Constructor And Destructor"
    Sub New(ByVal ConString As String)
        MyBase.New(ConString)
    End Sub

    Public Shadows Sub Dispose()
        MyBase.Dispose()
    End Sub
#End Region


    Public Function usp_PpalSobranteInv(ByVal Sucursal As String) As DataSet
        'mreyes 29/Abril/2015   11:42 a.m.
        Try
            usp_PpalSobranteInv = New DataSet
            MyBase.SQL = "CALL usp_PpalSobranteInv(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)

            MyBase.FillDataSet(usp_PpalSobranteInv, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalSucursalEnInventario(ByVal Sucursal As String) As DataSet
        'mreyes 29/Abril/2015   11:42 a.m.
        Try
            usp_PpalSucursalEnInventario = New DataSet
            MyBase.SQL = "CALL usp_PpalSucursalEnInventario(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)

            MyBase.FillDataSet(usp_PpalSucursalEnInventario, "persis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


End Class

