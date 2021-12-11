Public Class DALSeguimientoCedis
    'josue hernandez 26/Septiembre/2020   9:49 a.m.
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
    Public Function usp_PpalSeguimientoCedis(ByVal FechIni As String, ByVal FechFin As String) As DataSet
        'josue hernandez 26/Septiembre/2020   09:51 a.m.
        Try
            usp_PpalSeguimientoCedis = New DataSet
            MyBase.SQL = "usp_PpalSeguimientoCedis"

            MyBase.InitializeCommand()

            MyBase.AddParameter("@fechaini", SqlDbType.VarChar, 12, FechIni)
            MyBase.AddParameter("@fechafin", SqlDbType.VarChar, 12, FechFin)

            MyBase.FillDataSet(usp_PpalSeguimientoCedis, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region

End Class
