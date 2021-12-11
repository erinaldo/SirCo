Imports System.Data.Odbc
'mreyes 06/Junio/2012 10:20 a.m.

Public Class DALCatalogoPercDeduc
    Inherits DALOdbc
#Region "Constructor And Destructor"
    Sub New(ByVal ConString As String)
        MyBase.New(ConString)
    End Sub

    Public Shadows Sub Dispose()
        MyBase.Dispose()
    End Sub
#End Region

#Region " Public Role Functions "



    Public Function usp_PpalCatalogoPercDeduc(ByVal IdPercDeduc As Integer, ByVal Clave As String, ByVal Naturaleza As String, ByVal DescripC As String, ByVal DescripL As String, ByVal Repetitivo As String, ByVal TipoNom As String, ByVal Estatus As String, ByVal Tienda As String) As DataSet

        'mreyes 08/Junio/2012 12:00 p.m.
        'ByVal IdPercDeduc As Integer, ByVal Clave As String, ByVal Naturaleza As String, ByVal DescripC As String, ByVal DescripL As String, ByVal Activo As Integer
        Try
            usp_PpalCatalogoPercDeduc = New DataSet
            MyBase.SQL = "CALL usp_PpalCatalogoPercDeduc(?,?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@IdPercDeduc", OdbcType.Int, 16, IdPercDeduc)
            MyBase.AddParameter("@clave", OdbcType.Char, 3, Clave)
            MyBase.AddParameter("@naturaleza", OdbcType.Char, 1, Naturaleza)
            MyBase.AddParameter("@descripc", OdbcType.Char, 30, DescripC)
            MyBase.AddParameter("@descripl", OdbcType.Char, 60, DescripL)
            MyBase.AddParameter("@repetitivo", OdbcType.Char, 1, Repetitivo)
            MyBase.AddParameter("@tiponom", OdbcType.Char, 1, TipoNom)
            MyBase.AddParameter("@estatus", OdbcType.Char, 1, Estatus)
            MyBase.AddParameter("@tienda", OdbcType.Char, 1, Tienda)


            MyBase.FillDataSet(usp_PpalCatalogoPercDeduc, "nomsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_PercDeduc(ByVal Opcion As Integer, ByVal IdPercdeduc As Integer, ByVal Clave As String, _
                                          ByVal Naturaleza As String, ByVal DescripC As String, ByVal DescripL As String, _
                                          ByVal Repetitivo As String, ByVal TipoNom As String, ByVal Estatus As String, ByVal Tienda As String) As Boolean
        'mreyes 06/Junio/2012 10:52 a.m.
        Try

            MyBase.SQL = "CALL usp_Captura_PercDeduc(?,?,?,?,?,?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@idPercdeducB", OdbcType.Int, 16, IdPercdeduc)
            MyBase.AddParameter("@ClaveB", OdbcType.Char, 3, Clave)
            MyBase.AddParameter("@NaturalezaB", OdbcType.Char, 1, Naturaleza)
            MyBase.AddParameter("@DescripcB", OdbcType.Char, 30, DescripC)
            MyBase.AddParameter("@DescriplB", OdbcType.Char, 30, DescripL)
            MyBase.AddParameter("@RepetitivoB", OdbcType.Char, 1, Repetitivo)
            MyBase.AddParameter("@TipoNomb", OdbcType.Char, 1, TipoNom)
            MyBase.AddParameter("@EstatusB", OdbcType.Char, 1, Estatus)
            MyBase.AddParameter("@tiendab", OdbcType.Char, 1, Tienda)


            usp_Captura_PercDeduc = ExecuteStoredProcedure()

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

#End Region
End Class
