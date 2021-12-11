
Imports System.Data
Imports System.Data.SqlClient
'mreyes 12/Marzo/2019   01:10 p.m.
Public Class DALPuntoVenta
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

    Public Function usp_TraerSeriePV(Serie As String) As DataSet
        'mreyes 12/Marzo/2019   01:09 p.m.
        Try
            usp_TraerSeriePV = New DataSet
            MyBase.SQL = "usp_TraerSeriePV"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@serie", SqlDbType.VarChar, 13, Serie)

            MyBase.FillDataSet(usp_TraerSeriePV, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
