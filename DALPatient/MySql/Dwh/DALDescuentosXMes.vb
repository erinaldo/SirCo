Imports System.Data.Odbc
Public Class DALDescuentosXMes
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

    Public Function usp_PpalDescuentosXMes(ByVal opcion As Integer, ByVal fechaIni As String, ByVal fechaFin As String, ByVal sucursal As String) As DataSet
        'Manuel Vazquez, Paola Gonzalez 01:12 a.m. 
        Try
            usp_PpalDescuentosXMes = New DataSet
            MyBase.SQL = "call usp_PpalDescuentosXMes(?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@opcion", OdbcType.Int, 1, opcion)
            MyBase.AddParameter("@fechaIniB", OdbcType.Date, 10, fechaIni)
            MyBase.AddParameter("@fechaFinB", OdbcType.Date, 10, fechaFin)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, sucursal)




            MyBase.FillDataSet(usp_PpalDescuentosXMes, "cipsis")

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


#End Region
End Class
