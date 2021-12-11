Public Class DALPromotorExterno

    Inherits DALBase
#Region "Constructor And Destructor"
    Sub New(ByVal ConString As String)
        MyBase.New(ConString)
    End Sub

    Public Shadows Sub Dispose()
        MyBase.Dispose()
    End Sub
#End Region

#Region "Public Section Functions"
    Public Function usp_CapturaPromotorExterno(ByVal opcion As Integer,
                                      ByVal idpromotorexterno As Integer,
                                      ByVal nombre As String,
                                      ByVal appaterno As String,
                                      ByVal apmaterno As String,
                                      ByVal idestado As Integer,
                                      ByVal idciudad As Integer,
                                      ByVal idcolonia As Integer,
                                      ByVal cp As Integer,
                                      ByVal calle As String,
                                      ByVal numero As Integer,
                                      ByVal tel1 As String,
                                      ByVal tel2 As String,
                                      ByVal celular1 As String,
                                      ByVal celular2 As String,
                                      ByVal email As String,
                                      ByVal idusuario As Integer,
                                      ByVal idusuariomodif As Integer,
                                      ByVal fummodif As Date) As Boolean

        Try
            MyBase.SQL = "usp_CapturaPromotorExterno"
            MyBase.InitializeCommand()
            MyBase.AddParameter("@opcion", SqlDbType.Int, 16, opcion)
            MyBase.AddParameter("@idpromotorexterno", SqlDbType.Int, 16, idpromotorexterno)
            MyBase.AddParameter("@nombre", SqlDbType.VarChar, 100, nombre)
            MyBase.AddParameter("@appaterno", SqlDbType.VarChar, 100, appaterno)
            MyBase.AddParameter("@apmaterno", SqlDbType.VarChar, 100, apmaterno)
            MyBase.AddParameter("@idestado", SqlDbType.Int, 16, idestado)
            MyBase.AddParameter("@idciudad", SqlDbType.Int, 16, idciudad)
            MyBase.AddParameter("@idcolonia", SqlDbType.Int, 16, idcolonia)
            MyBase.AddParameter("@cp", SqlDbType.Int, 16, cp)
            MyBase.AddParameter("@calle", SqlDbType.VarChar, 250, calle)
            MyBase.AddParameter("@numero", SqlDbType.SmallInt, 16, numero) 'verificar diferencia SmallInt e Int
            MyBase.AddParameter("@tel1", SqlDbType.VarChar, 50, tel1)
            MyBase.AddParameter("@tel2", SqlDbType.VarChar, 50, tel2)
            MyBase.AddParameter("@celular1", SqlDbType.VarChar, 50, celular1)
            MyBase.AddParameter("@celular2", SqlDbType.VarChar, 50, celular2)
            MyBase.AddParameter("@email", SqlDbType.VarChar, 150, email)
            MyBase.AddParameter("@idusuario", SqlDbType.Int, 16, idusuario)
            MyBase.AddParameter("@idusuariomodif", SqlDbType.Int, 16, idusuariomodif)
            MyBase.AddParameter("@fummodif", SqlDbType.Date, 10, fummodif)


            'Execute stored procedure, Recuerda inserta y elimina son Boolean 
            usp_CapturaPromotorExterno = ExecuteStoredProcedure()

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
              ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_mostrarPromotorExterno(ByVal opcion As Integer,
                                      ByVal idpromotorexterno As Integer,
                                      ByVal nombre As String,
                                      ByVal appaterno As String,
                                      ByVal apmaterno As String,
                                      ByVal idestado As Integer,
                                      ByVal idciudad As Integer,
                                      ByVal idcolonia As Integer,
                                      ByVal cp As Integer,
                                      ByVal calle As String,
                                      ByVal numero As Integer,
                                      ByVal tel1 As String,
                                      ByVal tel2 As String,
                                      ByVal celular1 As String,
                                      ByVal celular2 As String,
                                      ByVal email As String,
                                      ByVal idusuario As Integer,
                                      ByVal idusuariomodif As Integer,
                                      ByVal fummodif As Date) As DataSet
        Try
            usp_mostrarPromotorExterno = New DataSet
            MyBase.SQL = "usp_CapturaPromotorExterno"
            MyBase.InitializeCommand()
            MyBase.AddParameter("@opcion", SqlDbType.Int, 16, opcion)
            MyBase.AddParameter("@idpromotorexterno", SqlDbType.Int, 16, idpromotorexterno)
            MyBase.AddParameter("@nombre", SqlDbType.VarChar, 100, nombre)
            MyBase.AddParameter("@appaterno", SqlDbType.VarChar, 100, appaterno)
            MyBase.AddParameter("@apmaterno", SqlDbType.VarChar, 100, apmaterno)
            MyBase.AddParameter("@idestado", SqlDbType.Int, 16, idestado)
            MyBase.AddParameter("@idciudad", SqlDbType.Int, 16, idciudad)
            MyBase.AddParameter("@idcolonia", SqlDbType.Int, 16, idcolonia)
            MyBase.AddParameter("@cp", SqlDbType.Int, 16, cp)
            MyBase.AddParameter("@calle", SqlDbType.VarChar, 250, calle)
            MyBase.AddParameter("@numero", SqlDbType.SmallInt, 16, numero) 'verificar diferencia SmallInt e Int
            MyBase.AddParameter("@tel1", SqlDbType.VarChar, 50, tel1)
            MyBase.AddParameter("@tel2", SqlDbType.VarChar, 50, tel2)
            MyBase.AddParameter("@celular1", SqlDbType.VarChar, 50, celular1)
            MyBase.AddParameter("@celular2", SqlDbType.VarChar, 50, celular2)
            MyBase.AddParameter("@email", SqlDbType.VarChar, 150, email)
            MyBase.AddParameter("@idusuario", SqlDbType.Int, 16, idusuario)
            MyBase.AddParameter("@idusuariomodif", SqlDbType.Int, 16, idusuariomodif)
            MyBase.AddParameter("@fummodif", SqlDbType.Date, 10, fummodif)
            MyBase.FillDataSet(usp_mostrarPromotorExterno, "promotorexterno")

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
               ExceptionErr.InnerException)
        End Try

    End Function
#End Region
End Class
