Imports System.Data
Imports System.Data.SqlClient
Public Class DALLineo
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

    Public Function usp_TraerLineo() As DataSet
        'miguel pérez 22/Octubre/2012 07:21 p.m.
        Try
            usp_TraerLineo = New DataSet
            MyBase.SQL = "usp_Traer_Lineo"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection


            'Execute the stored procedure
            MyBase.FillDataSet(usp_TraerLineo, "SirCoEnLinea")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

#End Region
End Class
