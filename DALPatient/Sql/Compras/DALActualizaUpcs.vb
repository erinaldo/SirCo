Public Class DALActualizaUpcs
    'josue hernandez 02/Octubre/2020  17:18 
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
    Public Function usp_ActualizaUpcs(ByVal IDUsuario As Integer) As DataSet
        'josue hernandez 02/Octubre/2020  17:19
        Try
            usp_ActualizaUpcs = New DataSet
            MyBase.SQL = "usp_ActualizaUpcs"

            MyBase.InitializeCommand()

            MyBase.AddParameter("@idusuario", SqlDbType.Int, 10, IDUsuario)

            MyBase.FillDataSet(usp_ActualizaUpcs, "SirCoEnLinea")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
