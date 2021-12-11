Public Class DALRelacionSQL

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


    Public Function usp_TraerDistrib(ByVal iddistrib As Integer) As DataSet
        'vgallegos 03/Febrero/2018  11:51 p.m.
        Try
            usp_TraerDistrib = New DataSet
            MyBase.SQL = "usp_TraerDistrib"

            MyBase.InitializeCommand()

            MyBase.AddParameter("@iddistrib", SqlDbType.Int, 4, iddistrib)

            MyBase.FillDataSet(usp_TraerDistrib, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraeridDistrib(ByVal distrib As String) As DataSet
        Try
            usp_TraeridDistrib = New DataSet
            'MyBase.SQL = usp_TraerDistrib()

            MyBase.InitializeCommand()

            'MyBase.AddParameter("@distrib", SqlDbType.VarChar, 6, distrib)

            MyBase.FillDataSet(usp_TraeridDistrib, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

#End Region
End Class
