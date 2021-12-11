Imports System.Data.Odbc
Public Class DALFaltanteInv
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

    Public Function usp_PpalFaltanteInv(ByVal division As String, ByVal sucursal As String) As DataSet
        'Manuel Vazquez, Paola Gonzalez 01:12 a.m. 
        Try
            usp_PpalFaltanteInv = New DataSet
            MyBase.SQL = "call usp_PpalFaltanteInv(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@DivisionB", OdbcType.Char, 20, division)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 10, sucursal)




            MyBase.FillDataSet(usp_PpalFaltanteInv, "cipsis")

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


#End Region
End Class
