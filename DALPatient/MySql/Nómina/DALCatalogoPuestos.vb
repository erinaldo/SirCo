Imports System.Data.Odbc
'mreyes 02/Junio/2012 10:26 a.m.

Public Class DALCatalogoPuestos
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



    Public Function usp_PpalCatalogoPuesto(ByVal IdPuesto As Integer, ByVal IdDepto As Integer, ByVal ClavePuesto As String, ByVal Descrip As String) As DataSet

        'mreyes 05/Junio/2012 10:04 a.m.

        Try
            usp_PpalCatalogoPuesto = New DataSet
            MyBase.SQL = "CALL usp_PpalCatalogoPuesto(?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@IdPuesto", OdbcType.Int, 16, IdPuesto)
            MyBase.AddParameter("@IdDepto", OdbcType.Int, 16, IdDepto)
            MyBase.AddParameter("@ClavePuesto", OdbcType.Char, 3, ClavePuesto)
            MyBase.AddParameter("@DescripB", OdbcType.Char, 30, Descrip)
            MyBase.FillDataSet(usp_PpalCatalogoPuesto, "nomsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_Puesto(ByVal Opcion As Integer, ByVal IdPuesto As Integer, _
                                        ByVal IdDepto As Integer, ByVal Clave As String, _
                                        ByVal Descrip As String, ByVal Comision As String, ByVal TVenta As String) As Boolean
        'mreyes 05/Junio/2012 12:11 a.m.
        Try

            MyBase.SQL = "CALL usp_Captura_Puesto(?,?,?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@IdPuesto", OdbcType.Int, 16, IdPuesto)
            MyBase.AddParameter("@IdDepto", OdbcType.Int, 16, IdDepto)
            MyBase.AddParameter("@claveB", OdbcType.Char, 3, Clave)
            MyBase.AddParameter("@DescripB", OdbcType.Char, 30, Descrip)
            MyBase.AddParameter("@Comision", OdbcType.Char, 1, Comision)
            MyBase.AddParameter("@tventa", OdbcType.Char, 1, TVenta)



            usp_Captura_Puesto = ExecuteStoredProcedure()

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

#End Region
End Class
