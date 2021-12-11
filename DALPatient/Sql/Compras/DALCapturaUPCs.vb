Public Class DALCapturaUPCs
    'Josue Hernandez 30/Septiembre/2020  16:54 
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
    Public Function usp_CapturaUPCs(ByVal Marca As String, ByVal Modelo As String,
            ByVal Talla As String, ByVal UPC As String, ByVal IDUsuario As Integer) As DataSet
        'Josue Hernandez 30/Septiembre/2020  16:55
        Try
            usp_CapturaUPCs = New DataSet
            MyBase.SQL = "usp_CapturaUPCs"

            MyBase.InitializeCommand()

            MyBase.AddParameter("@marca", SqlDbType.VarChar, 3, Marca)
            MyBase.AddParameter("@modelo", SqlDbType.VarChar, 4, Modelo)
            MyBase.AddParameter("@talla", SqlDbType.VarChar, 3, Talla)
            MyBase.AddParameter("@upc", SqlDbType.VarChar, 13, UPC)
            MyBase.AddParameter("@idusuario", SqlDbType.VarChar, 10, IDUsuario)

            MyBase.FillDataSet(usp_CapturaUPCs, "SirCoTEMP")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
