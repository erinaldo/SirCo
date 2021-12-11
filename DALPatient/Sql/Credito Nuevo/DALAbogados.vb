Imports System.Data
Imports System.Data.SqlClient
Public Class DALAbogados


    Inherits DALBase
#Region "Constructor And Destructor"
    Sub New(ByVal ConString As String)
        MyBase.New(ConString)
    End Sub

    Public Shadows Sub Dispose()
        MyBase.Dispose()
    End Sub
#End Region

#Region "Public Functions"

    Public Function usp_CapturaAbogado(ByVal opcion As Integer,
                                       ByVal idabogado As Integer,
                                       ByVal nombre As String,
                                       ByVal appaterno As String,
                                       ByVal apmaterno As String,
                                       ByVal cedula As String,
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
                                       ByVal despacho As String,
                                       ByVal idestadodpcho As Integer,
                                       ByVal idciudadpcho As Integer,
                                       ByVal idcoloniadpcho As Integer,
                                       ByVal cpdpcho As Integer,
                                       ByVal calledpcho As String,
                                       ByVal entrecallesdpcho As String,
                                       ByVal numerodpcho As Integer,
                                       ByVal idusuario As Integer,
                                       ByVal fum As Date,
                                       ByVal idusuariomodif As Integer,
                                       ByVal fummodif As Date) As Boolean

        Try
            MyBase.SQL = "usp_CapturaAbogado"
            MyBase.InitializeCommand()
            MyBase.AddParameter("@opcion", SqlDbType.Int, 16, opcion)
            MyBase.AddParameter("@idabogado", SqlDbType.Int, 16, idabogado)
            MyBase.AddParameter("@nombre", SqlDbType.VarChar, 100, nombre)
            MyBase.AddParameter("@appaterno", SqlDbType.VarChar, 100, appaterno)
            MyBase.AddParameter("@apmaterno", SqlDbType.VarChar, 100, apmaterno)
            MyBase.AddParameter("@cedula", SqlDbType.VarChar, 14, cedula)
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
            MyBase.AddParameter("@despacho", SqlDbType.VarChar, 150, despacho)
            MyBase.AddParameter("@idestadodpcho", SqlDbType.Int, 16, idestadodpcho)
            MyBase.AddParameter("@idciudadpcho", SqlDbType.Int, 16, idciudadpcho)
            MyBase.AddParameter("@idcoloniadpcho", SqlDbType.Int, 16, idcoloniadpcho)
            MyBase.AddParameter("@cpdpcho", SqlDbType.Int, 16, cpdpcho)
            MyBase.AddParameter("@calledpcho", SqlDbType.VarChar, 250, calledpcho)
            MyBase.AddParameter("@entrecallesdpcho", SqlDbType.VarChar, 500, entrecallesdpcho)
            MyBase.AddParameter("@numerodpcho", SqlDbType.SmallInt, 16, numerodpcho) 'verificar smallint e int
            MyBase.AddParameter("@idusuario", SqlDbType.Int, 16, idusuario)
            MyBase.AddParameter("@fum", SqlDbType.Date, 10, fum)
            MyBase.AddParameter("@idusuariomodif", SqlDbType.Int, 16, idusuariomodif)
            MyBase.AddParameter("@fummodif", SqlDbType.Date, 10, fummodif)


            'Execute stored procedure, Recuerda inserta y elimina son Boolean 
            usp_CapturaAbogado = ExecuteStoredProcedure()

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
              ExceptionErr.InnerException)
        End Try

    End Function


    Public Function usp_mostrarAbogado(ByVal opcion As Integer,
                                       ByVal idabogado As Integer,
                                       ByVal nombre As String,
                                       ByVal appaterno As String,
                                       ByVal apmaterno As String,
                                       ByVal cedula As String,
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
                                       ByVal despacho As String,
                                       ByVal idestadodpcho As Integer,
                                       ByVal idciudadpcho As Integer,
                                       ByVal idcoloniadpcho As Integer,
                                       ByVal cpdpcho As Integer,
                                       ByVal calledpcho As String,
                                       ByVal entrecallesdpcho As String,
                                       ByVal numerodpcho As Integer,
                                       ByVal idusuario As Integer,
                                       ByVal fum As Date,
                                       ByVal idusuariomodif As Integer,
                                       ByVal fummodif As Date) As DataSet
        Try
            usp_mostrarAbogado = New DataSet
            MyBase.SQL = "usp_CapturaAbogado"
            MyBase.InitializeCommand()
            MyBase.AddParameter("@opcion", SqlDbType.Int, 16, opcion)
            MyBase.AddParameter("@idabogado", SqlDbType.Int, 16, idabogado)
            MyBase.AddParameter("@nombre", SqlDbType.VarChar, 100, nombre)
            MyBase.AddParameter("@appaterno", SqlDbType.VarChar, 100, appaterno)
            MyBase.AddParameter("@apmaterno", SqlDbType.VarChar, 100, apmaterno)
            MyBase.AddParameter("@cedula", SqlDbType.VarChar, 14, cedula)
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
            MyBase.AddParameter("@despacho", SqlDbType.VarChar, 150, despacho)
            MyBase.AddParameter("@idestadodpcho", SqlDbType.Int, 16, idestadodpcho)
            MyBase.AddParameter("@idciudadpcho", SqlDbType.Int, 16, idciudadpcho)
            MyBase.AddParameter("@idcoloniadpcho", SqlDbType.Int, 16, idcoloniadpcho)
            MyBase.AddParameter("@cpdpcho", SqlDbType.Int, 16, cpdpcho)
            MyBase.AddParameter("@calledpcho", SqlDbType.VarChar, 250, calledpcho)
            MyBase.AddParameter("@entrecallesdpcho", SqlDbType.VarChar, 500, entrecallesdpcho)
            MyBase.AddParameter("@numerodpcho", SqlDbType.SmallInt, 16, numerodpcho) 'verificar smallint e int
            MyBase.AddParameter("@idusuario", SqlDbType.Int, 16, idusuario)
            MyBase.AddParameter("@fum", SqlDbType.Date, 10, fum)
            MyBase.AddParameter("@idusuariomodif", SqlDbType.Int, 16, idusuariomodif)
            MyBase.AddParameter("@fummodif", SqlDbType.Date, 10, fummodif)
            MyBase.FillDataSet(usp_mostrarAbogado, "abogado")

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
               ExceptionErr.InnerException)
        End Try

    End Function

    Public Function usp_traerNombreAbogados(
                                           ByVal idabogado As Integer,
                                          ByVal nombre As String,
                                       ByVal appaterno As String,
                                       ByVal apmaterno As String) As DataSet
        Try

            usp_traerNombreAbogados = New DataSet
            MyBase.SQL = "usp_TraerNombreAbogados"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@idabogado", SqlDbType.Int, 16, idabogado)
            MyBase.AddParameter("@nombre", SqlDbType.VarChar, 100, nombre)
            MyBase.AddParameter("@appaterno", SqlDbType.VarChar, 100, appaterno)
            MyBase.AddParameter("@apmaterno", SqlDbType.VarChar, 100, apmaterno)
            MyBase.FillDataSet(usp_traerNombreAbogados, "abogado")

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
               ExceptionErr.InnerException)
        End Try
    End Function
#End Region






End Class
