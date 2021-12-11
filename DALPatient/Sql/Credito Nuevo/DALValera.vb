Public Class DALValera


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

    Public Function usp_TraerEntregaDeValeras(ByVal idvalera As String) As DataSet
        'vgallegos 07/Febrero/2018  11:17 a.m.
        Try
            usp_TraerEntregaDeValeras = New DataSet
            MyBase.SQL = "usp_TraerEntregaDeValeras"

            MyBase.InitializeCommand()

            MyBase.AddParameter("@valera", SqlDbType.VarChar, 14, idvalera)

            MyBase.FillDataSet(usp_TraerEntregaDeValeras, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerDistrib(ByVal iddistrib As String) As DataSet
        Try
            usp_TraerDistrib = New DataSet
            MyBase.SQL = "usp_TraerDistrib"

            MyBase.InitializeCommand()

            MyBase.AddParameter("@iddistrib", SqlDbType.VarChar, 6, iddistrib)

            MyBase.FillDataSet(usp_TraerDistrib, "SirCo")


        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturarEntregaDeValeras(ByVal opcion As Integer, ByVal iddistrib As String, ByVal valera As String, ByVal valeini As String,
                                       ByVal valefin As String, ByVal entrega As Date, ByVal recoge As String, ByVal idusuario As Integer, ByVal idusuariomodif As Integer) As Boolean
        Try
            MyBase.SQL = "usp_CapturarEntregaDeValeras"

            MyBase.InitializeCommand()

            MyBase.AddParameter("@opcion", SqlDbType.Int, 4, opcion)
            MyBase.AddParameter("@distrib", SqlDbType.VarChar, 6, iddistrib)
            MyBase.AddParameter("@valera", SqlDbType.VarChar, 14, valera)
            MyBase.AddParameter("@valeini", SqlDbType.VarChar, 14, valeini)
            MyBase.AddParameter("@valefin", SqlDbType.VarChar, 14, valefin)
            MyBase.AddParameter("@entrega", SqlDbType.Date, 3, entrega)
            MyBase.AddParameter("@recoge", SqlDbType.VarChar, 150, recoge)
            MyBase.AddParameter("@idusuario", SqlDbType.Int, 4, idusuario)
            MyBase.AddParameter("@idusuariomodif", SqlDbType.Int, 4, idusuariomodif)


            usp_CapturarEntregaDeValeras = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

#End Region
End Class
