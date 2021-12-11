Imports System.Data.Odbc
'mreyes 02/Junio/2012 10:26 a.m.

Public Class DALCatalogoDeptos
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

    Public Function usp_PpalCatalogoDepto(ByVal IdDepto As Integer, ByVal Clave As String, ByVal Descrip As String) As DataSet

        'mreyes 04/Junio/2012 10:38 a.m.

        Try
            usp_PpalCatalogoDepto = New DataSet
            MyBase.SQL = "CALL usp_PpalCatalogoDepto(?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@IdDepto", OdbcType.Int, 16, IdDepto)
            MyBase.AddParameter("@ClaveB", OdbcType.Char, 3, Clave)
            MyBase.AddParameter("@DescripB", OdbcType.Char, 30, Descrip)
            MyBase.FillDataSet(usp_PpalCatalogoDepto, "nomsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalCatalogoPuesto(ByVal IdPuesto As Integer, ByVal IdDepto As Integer, ByVal Descrip As String) As DataSet

        'mreyes 05/Junio/2012 10:04 a.m.

        Try
            usp_PpalCatalogoPuesto = New DataSet
            MyBase.SQL = "CALL usp_PpalCatalogoPuesto(?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@IdPuesto", OdbcType.Int, 16, IdPuesto)
            MyBase.AddParameter("@IdDepto", OdbcType.Int, 16, IdDepto)
            MyBase.AddParameter("@DescripB", OdbcType.Char, 30, Descrip)
            MyBase.FillDataSet(usp_PpalCatalogoPuesto, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_Depto(ByVal Opcion As Integer, ByVal IdDepto As Integer, ByVal Clave As String, ByVal Descrip As String) As Boolean
        'mreyes 04/Junio/2012 10:31 a.m.
        Try

            MyBase.SQL = "CALL usp_Captura_Depto(?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@IdDepto", OdbcType.Int, 16, IdDepto)
            MyBase.AddParameter("@ClaveB", OdbcType.Char, 3, Clave)
            MyBase.AddParameter("@DescripB", OdbcType.Char, 30, Descrip)


            usp_Captura_Depto = ExecuteStoredProcedure()

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

#End Region
End Class
