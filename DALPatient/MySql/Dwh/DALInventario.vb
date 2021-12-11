Imports System.Data.Odbc
'miguel pérez 09/Octubre/2012 10:43 a.m.

Public Class DALInventario
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

    Public Function usp_PpalInventario(ByVal Opcion As String, ByVal Sucursal As String, ByVal Marca As String, ByVal Estilon As String, ByVal Proveedor As String) As DataSet
        'miguel pérez 11/Mar/2013
        Try
            usp_PpalInventario = New DataSet
            MyBase.SQL = "CALL usp_PpalInventario(?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", OdbcType.Int, 1, Opcion)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@EstilonB", OdbcType.Char, 7, Estilon)
            MyBase.AddParameter("@ProveedorB", OdbcType.Char, 3, Proveedor)

            MyBase.FillDataSet(usp_PpalInventario, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
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
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

#End Region
End Class
