Imports System.Data.Odbc
'mreyes 29/Marzo/2012 09:59 a.m.

Public Class DALDevoluciones
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


    Public Function usp_PpalDevoluciones(ByVal Sucursal As String, ByVal DevIni As String, ByVal DevFin As String, ByVal FactProvIni As String, ByVal FactProvFin As String, _
                                         ByVal Marca As String, ByVal Proveedor As String, ByVal Status As String, _
                                        ByVal FechaIni As String, ByVal Fechafin As String, ByVal VenceIni As String, ByVal VenceFin As String, _
                                         ByVal IdFolioSucIni As String, ByVal IdFolioSucFin As String) As DataSet

        'mreyes 29/Marzo/2012 10:00 a.m.

        Try
            usp_PpalDevoluciones = New DataSet
            MyBase.SQL = "CALL usp_PpalDevoluciones(?,?,?,?,?,?,?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@DevIniB", OdbcType.Char, 6, DevIni)
            MyBase.AddParameter("@DevFinB", OdbcType.Char, 6, DevFin)
            MyBase.AddParameter("@FactProvIniB", OdbcType.Char, 10, FactProvIni)
            MyBase.AddParameter("@FactProvFinB", OdbcType.Char, 10, FactProvFin)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)


            MyBase.AddParameter("@ProveedorB", OdbcType.Char, 3, Proveedor)

            MyBase.AddParameter("@StatusB", OdbcType.Char, 2, Status)
            MyBase.AddParameter("@FechaIniB", OdbcType.Char, 10, FechaIni)
            MyBase.AddParameter("@FechaFinB", OdbcType.Char, 10, Fechafin)
            MyBase.AddParameter("@VenceIniB", OdbcType.Char, 10, VenceIni)
            MyBase.AddParameter("@VenceFinB", OdbcType.Char, 10, VenceFin)
            MyBase.AddParameter("@idfoliosuciniB", OdbcType.Char, 10, IdFolioSucIni)
            MyBase.AddParameter("@idfoliosucfinB", OdbcType.Char, 10, IdFolioSucFin)

            MyBase.FillDataSet(usp_PpalDevoluciones, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


#End Region
End Class
