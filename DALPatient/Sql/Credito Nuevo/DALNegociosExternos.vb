Public Class DALNegociosExternos

    Inherits DALBase
#Region "Constructor And Destructor"
    Sub New(ByVal ConString As String)
        MyBase.New(ConString)
    End Sub

    Public Shadows Sub Dispose()
        MyBase.Dispose()
    End Sub
#End Region

#Region "Public section Fuctions"

    Public Function usp_CapturaNegocioExterno(ByVal opcion As Integer,
                                              ByVal idnegexterno As Integer,
                                              ByVal negocio As String,
                                              ByVal descripcion As String,
                                              ByVal idusuario As Integer,
                                              ByVal idusuariomodif As Integer,
                                              ByVal fummodif As Date) As Boolean
        Try
            MyBase.SQL = "usp_CapturaNegocioExterno"
            MyBase.InitializeCommand()
            MyBase.AddParameter("@opcion", SqlDbType.Int, 16, opcion)
            MyBase.AddParameter("@idnegexterno", SqlDbType.Int, 16, idnegexterno)
            MyBase.AddParameter("@negocio", SqlDbType.VarChar, 2, negocio)
            MyBase.AddParameter("@descripcion", SqlDbType.VarChar, 50, descripcion)
            MyBase.AddParameter("@idusuario", SqlDbType.Int, 16, idusuario)
            MyBase.AddParameter("@idusuariomodif", SqlDbType.Int, 16, idusuariomodif)
            MyBase.AddParameter("@fummodif", SqlDbType.Date, 10, fummodif)



            'Execute stored procedure, Recuerda inserta y elimina son Boolean 
            usp_CapturaNegocioExterno = ExecuteStoredProcedure()

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
              ExceptionErr.InnerException)
        End Try

    End Function

    Public Function usp_mostrarNegocioExterno(ByVal opcion As Integer,
                                              ByVal idnegexterno As Integer,
                                              ByVal negocio As String,
                                              ByVal descripcion As String,
                                              ByVal idusuario As Integer,
                                              ByVal idusuariomodif As Integer,
                                              ByVal fummodif As Date) As DataSet

        Try
            usp_mostrarNegocioExterno = New DataSet
            MyBase.SQL = "usp_CapturaNegocioExterno"
            MyBase.InitializeCommand()
            MyBase.AddParameter("@opcion", SqlDbType.Int, 16, opcion)
            MyBase.AddParameter("@idnegexterno", SqlDbType.Int, 16, idnegexterno)
            MyBase.AddParameter("@negocio", SqlDbType.VarChar, 2, negocio)
            MyBase.AddParameter("@descripcion", SqlDbType.VarChar, 50, descripcion)
            MyBase.AddParameter("@idusuario", SqlDbType.Int, 16, idusuario)
            MyBase.AddParameter("@idusuariomodif", SqlDbType.Int, 16, idusuariomodif)
            MyBase.AddParameter("@fummodif", SqlDbType.Date, 10, fummodif)

            MyBase.FillDataSet(usp_mostrarNegocioExterno, "negocioexterno")

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
           ExceptionErr.InnerException)
        End Try
    End Function

#End Region
End Class
