Imports System.Data.SqlClient
Imports System.Data

Public Class DALLayoutDomicilioP


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

    Public Function usp_CapturaLayoutCodigos(ByVal d_codigo As String, ByVal d_asenta As String,
                                                  ByVal d_estado As String, ByVal d_ciudad As String,
                                                  ByVal isusuario As String) As Boolean
        Try
            MyBase.SQL = "usp_CapturaLeerArchivoCodigos"
            MyBase.InitializeCommand()
            MyBase.AddParameter("@d_codigo", SqlDbType.VarChar, 5, d_codigo)
            MyBase.AddParameter("@d_asenta", SqlDbType.VarChar, 50, d_asenta)
            MyBase.AddParameter("@d_estado", SqlDbType.VarChar, 50, d_estado)
            MyBase.AddParameter("@d_ciudad", SqlDbType.VarChar, 50, d_ciudad)
            MyBase.AddParameter("@idusuario", SqlDbType.Int, 8, isusuario)
            usp_CapturaLayoutCodigos = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerDomicilioParticular(ByVal opcion As Integer, ByVal CP As String, ByVal estado As Integer, ByVal ciudad As Integer, ByVal colonia As Integer) As DataSet
        Try
            usp_TraerDomicilioParticular = New DataSet

            MyBase.SQL = "usp_TraerDomicilioParticular"
            MyBase.InitializeCommand()
            MyBase.AddParameter("@opcion", SqlDbType.Int, 8, opcion)
            MyBase.AddParameter("@CodigoPostal", SqlDbType.VarChar, 5, CP)
            MyBase.AddParameter("@idestado", SqlDbType.Int, 8, estado)
            MyBase.AddParameter("@idciudad", SqlDbType.Int, 8, ciudad)
            MyBase.AddParameter("@idcolonia", SqlDbType.Int, 8, colonia)


            MyBase.FillDataSet(usp_TraerDomicilioParticular, "SirCo")

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

#End Region
End Class
