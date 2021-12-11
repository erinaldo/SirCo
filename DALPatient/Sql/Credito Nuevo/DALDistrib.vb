Public Class DALDistrib

    Inherits DALBase
#Region "Constructor And Destructor"

    Sub New(ByVal ConString As String)
        MyBase.New(ConString)
    End Sub

    Public Shadows Sub Dispose()
        MyBase.Dispose()
    End Sub
#End Region

#Region "public section functions"
    Public Function usp_DistribInfo(ByVal año As Integer) As DataSet
        Try
            usp_DistribInfo = New DataSet
            MyBase.SQL = "usp_DistribInfo"
            MyBase.InitializeCommand()
            MyBase.AddParameter("@anio", SqlDbType.Int, 16, año)
            MyBase.FillDataSet(usp_DistribInfo, "SirCoCredito")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
               ExceptionErr.InnerException)
        End Try
    End Function
#End Region

End Class
