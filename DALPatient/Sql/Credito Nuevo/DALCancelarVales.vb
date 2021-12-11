Public Class DALCancelarVales
    'lvillegas 07-02-2018 10:58 a.m.


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

    Public Function usp_CapturaCancelarVales(ByVal opcion As Integer,
                                             ByVal iddistrib As Integer,
                                             ByVal valera As String,
                                             ByVal valeini As String,
                                             ByVal valefin As String,
                                             ByVal idmotivo As Integer,
                                             ByVal idusuario As Integer,
                                             ByVal idusuariomodif As Integer,
                                             ByVal fummodif As Date) As Boolean

        Try
            MyBase.SQL = "usp_CapturaCancelarVales"
            MyBase.InitializeCommand()
            MyBase.AddParameter("@opcion", SqlDbType.Int, 16, opcion)
            MyBase.AddParameter("@iddistrib", SqlDbType.Int, 16, iddistrib)
            MyBase.AddParameter("@valera", SqlDbType.VarChar, 14, valera)
            MyBase.AddParameter("@valeini", SqlDbType.VarChar, 14, valeini)
            MyBase.AddParameter("@valefin", SqlDbType.VarChar, 14, valefin)
            MyBase.AddParameter("@idmotivo", SqlDbType.Int, 16, idmotivo)
            MyBase.AddParameter("@idusuario", SqlDbType.Int, 16, idusuario)
            MyBase.AddParameter("@idusuariomodif", SqlDbType.Int, 16, idusuariomodif)
            MyBase.AddParameter("@fummodif", SqlDbType.Date, 10, fummodif)


            'Executar el stored procedure 
            usp_CapturaCancelarVales = ExecuteStoredProcedure()

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
             ExceptionErr.InnerException)
        End Try
    End Function




    Public Function usp_MostrarCancelarVales(ByVal opcion As Integer,
                                             ByVal iddistrib As Integer,
                                             ByVal valera As String,
                                             ByVal valeini As String,
                                             ByVal valefin As String,
                                             ByVal idmotivo As Integer,
                                             ByVal idusuario As Integer,
                                             ByVal idusuariomodif As Integer,
                                             ByVal fummodif As Date) As DataSet
        Try
            usp_MostrarCancelarVales = New DataSet
            MyBase.SQL = "usp_CapturaCancelarVales"
            MyBase.InitializeCommand()
            MyBase.AddParameter("@opcion", SqlDbType.Int, 16, opcion)
            MyBase.AddParameter("@iddistrib", SqlDbType.Int, 16, iddistrib)
            MyBase.AddParameter("@valera", SqlDbType.VarChar, 14, valera)
            MyBase.AddParameter("@valeini", SqlDbType.VarChar, 14, valeini)
            MyBase.AddParameter("@valefin", SqlDbType.VarChar, 14, valefin)
            MyBase.AddParameter("@idmotivo", SqlDbType.Int, 16, idmotivo)
            MyBase.AddParameter("@idusuario", SqlDbType.Int, 16, idusuario)
            MyBase.AddParameter("@idusuariomodif", SqlDbType.Int, 16, idusuariomodif)
            MyBase.AddParameter("@fummodif", SqlDbType.Date, 10, fummodif)


            MyBase.FillDataSet(usp_MostrarCancelarVales, "valescancelados")


        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
               ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
