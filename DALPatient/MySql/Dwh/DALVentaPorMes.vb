Imports System.Data.Odbc
Public Class DALVentaPorMes

    Inherits DALBase
#Region "Constructor And Destructor"
    Sub New(ByVal ConString As String)
        MyBase.New(ConString)
    End Sub

    Public Shadows Sub Dispose()
        MyBase.Dispose()
    End Sub
#End Region


    Public Function usp_PpalVentaPorMes(ByVal año As String) As DataSet
        'mreyes 29/Abril/2015   11:42 a.m.
        Try
            usp_PpalVentaPorMes = New DataSet
            MyBase.SQL = "usp_PpalVentasPorMes"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@aniob", SqlDbType.VarChar, 4, año)

            MyBase.FillDataSet(usp_PpalVentaPorMes, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function



End Class
