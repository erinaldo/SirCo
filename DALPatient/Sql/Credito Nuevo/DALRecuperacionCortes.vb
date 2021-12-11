
Imports System.Data
Imports System.Data.SqlClient
Public Class DALRecuperacionCortes
    Inherits DALBase
#Region "Constructor And Destructor"
    Sub New(ByVal ConString As String)
        MyBase.New(ConString)
    End Sub

    Public Shadows Sub Dispose()
        MyBase.Dispose()
    End Sub
#End Region
#Region " Public Role Functions "
    Public Function usp_Ppalrecuperacioncortes(ByVal Año As Integer) As DataSet
        'mreyes 12/Diciembre/2016   12:29 p.m.

        Try
            usp_Ppalrecuperacioncortes = New DataSet
            MyBase.SQL = "usp_Ppalrecuperacioncortes"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@anio", SqlDbType.Int, 4, Año)
            'Execute the stored procedure
            MyBase.FillDataSet(usp_Ppalrecuperacioncortes, "SirCoCredito")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
