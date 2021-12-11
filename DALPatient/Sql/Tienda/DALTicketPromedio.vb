Public Class DALTicketPromedio
    Inherits DALBase
#Region "Constructor And Destructor"

    Sub New(ByVal ConString As String)
        MyBase.New(ConString)
    End Sub

    Public Shadows Sub Dispose()
        MyBase.Dispose()
    End Sub
#End Region

    Public Function usp_TraerTicketPromedio(ByVal fecha_desde As String, fecha_hasta As String, Cve_Sucursal As String) As DataSet
        'jvargas 17/Agosto/2018  11:17 a.m.
        Try
            usp_TraerTicketPromedio = New DataSet
            MyBase.SQL = "usp_TraerTicketPromedio"

            MyBase.InitializeCommand()

            MyBase.AddParameter("@fecha_desde", SqlDbType.VarChar, 10, fecha_desde)
            MyBase.AddParameter("@fecha_hasta", SqlDbType.VarChar, 10, fecha_hasta)
            MyBase.AddParameter("@Sucursal", SqlDbType.VarChar, 2, Cve_Sucursal)

            MyBase.FillDataSet(usp_TraerTicketPromedio, "TicketPromedio")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
End Class
