Public Class DALGestoresDeCartera

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
    Public Function usp_TraerGestoresDeCartera(ByVal opcion As Integer, ByVal idgestor As Integer) As DataSet
        'vgallegos 09/Febrero/2018  11:41 a.m.
        Try
            usp_TraerGestoresDeCartera = New DataSet
            MyBase.SQL = "usp_TraerGestoresDeCartera"

            MyBase.InitializeCommand()

            MyBase.AddParameter("@opcion", SqlDbType.Int, 4, opcion)
            MyBase.AddParameter("@idgestor", SqlDbType.Int, 4, idgestor)

            MyBase.FillDataSet(usp_TraerGestoresDeCartera, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaGestorDeCartera(ByVal opcion As Integer, ByVal idgestor As Integer, ByVal tipo As String, ByVal carterafresca As Integer,
                                      ByVal carteravencida As String, ByVal idusuario As Integer, ByVal idusuariomodif As Integer) As Boolean
        Try
            MyBase.SQL = "usp_CapturaGestorDeCartera"

            MyBase.InitializeCommand()

            MyBase.AddParameter("@opcion", SqlDbType.Int, 4, opcion)
            MyBase.AddParameter("@idgestor", SqlDbType.Int, 4, idgestor)
            MyBase.AddParameter("@tipo", SqlDbType.VarChar, 1, tipo)
            MyBase.AddParameter("@carterafresca", SqlDbType.SmallInt, 2, carterafresca)
            MyBase.AddParameter("@carteravencida", SqlDbType.SmallInt, 2, carteravencida)
            MyBase.AddParameter("@idusuario", SqlDbType.Int, 4, idusuario)
            MyBase.AddParameter("@idusuariomodif", SqlDbType.Int, 4, idusuariomodif)


            usp_CapturaGestorDeCartera = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function


#End Region

End Class
