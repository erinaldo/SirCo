Imports System.Data.Odbc
'mreyes 02/Junio/2012 10:26 a.m.

Public Class DALCatalogoFrecPago
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



    Public Function usp_PpalCatalogoFrecPago(ByVal Clave As String) As DataSet
        'mreyes 19/Junio/2012 05:10 p.m.
        Try
            usp_PpalCatalogoFrecPago = New DataSet
            MyBase.SQL = "CALL usp_PpalCatalogoFrecPago(?)"


            MyBase.InitializeCommand()
            MyBase.AddParameter("@claveB", OdbcType.Char, 3, Clave)
            MyBase.FillDataSet(usp_PpalCatalogoFrecPago, "nomsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try




    End Function

    Public Function usp_Captura_FrecPago(ByVal Opcion As Integer, ByVal Clave As String, ByVal Descrip As String) As Boolean
        'mreyes 05/Junio/2012 12:11 a.m.
        Try

            MyBase.SQL = "CALL usp_Captura_FrecPago(?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@claveB", OdbcType.Char, 3, Clave)
            MyBase.AddParameter("@DescripB", OdbcType.Char, 30, Descrip)
            usp_Captura_FrecPago = ExecuteStoredProcedure()

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

#End Region
End Class
