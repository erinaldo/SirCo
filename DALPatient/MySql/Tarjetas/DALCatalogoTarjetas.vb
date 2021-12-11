Imports System.Data.Odbc


Public Class DALCatalogoTarjetas
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

    Public Function usp_PpalCatalogoBancosFactoraje() As DataSet
        'mreyes 31/Octubre/2014 04:11 p.m.
        Try
            usp_PpalCatalogoBancosFactoraje = New DataSet
            MyBase.SQL = "CALL usp_PpalCatalogoBancosFactoraje()"

            MyBase.InitializeCommand()
            'MyBase.AddParameter("@Marcab", OdbcType.Char, 50, Marca)


            MyBase.FillDataSet(usp_PpalCatalogoBancosFactoraje, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalCatalogoTarjetas() As DataSet
        'mreyes 17/Mayo/2012 05:32 p.m.
        Try
            usp_PpalCatalogoTarjetas = New DataSet
            MyBase.SQL = "CALL usp_PpalCatalogoTarjetas()"

            MyBase.InitializeCommand()
            'MyBase.AddParameter("@Marcab", OdbcType.Char, 50, Marca)


            MyBase.FillDataSet(usp_PpalCatalogoTarjetas, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerPagoTarjetas() As DataSet
        'mreyes 28/Mayo/2012 09:48 a.m.
        Try
            usp_TraerPagoTarjetas = New DataSet
            MyBase.SQL = "CALL usp_TraerPagoTarjetas()"

            MyBase.InitializeCommand()
            'MyBase.AddParameter("@Marcab", OdbcType.Char, 50, Marca)


            MyBase.FillDataSet(usp_TraerPagoTarjetas, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_Captura_Tarjetas(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        'mreyes 05/Mayo/2012 06:23 p.m.
        Try
            MyBase.SQL = "CALL usp_Captura_Tarjetas(?,?,?,?,?,?,?,?,?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()
            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@banco", OdbcType.Char, 20, Section.Tables(0).Rows(0).Item("banco"))
            MyBase.AddParameter("@titular", OdbcType.Char, 100, Section.Tables(0).Rows(0).Item("titular"))
            MyBase.AddParameter("@notarjeta", OdbcType.Char, 20, Section.Tables(0).Rows(0).Item("notarjeta"))
            MyBase.AddParameter("@tipo", OdbcType.Char, 20, Section.Tables(0).Rows(0).Item("tipo"))
            MyBase.AddParameter("@limcred", OdbcType.Double, 9, Section.Tables(0).Rows(0).Item("limcred"))
            MyBase.AddParameter("@saldo", OdbcType.Double, 9, Section.Tables(0).Rows(0).Item("saldo"))

            MyBase.AddParameter("@fechae", OdbcType.Date, 8, Section.Tables(0).Rows(0).Item("fechae"))
            MyBase.AddParameter("@fechav", OdbcType.Date, 8, Section.Tables(0).Rows(0).Item("fechav"))
            MyBase.AddParameter("@diacorte", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("diacorte"))
            MyBase.AddParameter("@diapago", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("diapago"))
            MyBase.AddParameter("@prioridad", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("prioridad"))
            MyBase.AddParameter("@tarjeta_id", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("tarjeta_id"))
          

            usp_Captura_Tarjetas = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_Captura_Tarjetas_Det(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        'mreyes 18/Mayo/2012 10:56 a.m.
        Try
            MyBase.SQL = "CALL usp_Captura_Tarjetas_Det(?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()
            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@tarjeta_idb", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("tarjeta_id"))
            MyBase.AddParameter("@meses", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("meses"))
            MyBase.AddParameter("@comision", OdbcType.Decimal, 8, Section.Tables(0).Rows(0).Item("comision"))
            
            usp_Captura_Tarjetas_Det = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerTarjetas(ByVal Tarjeta_id As Integer, ByVal Banco As String) As DataSet
        'mreyes 18/Mayo/2012 10:14 a.m.
        Try
            usp_TraerTarjetas = New DataSet
            MyBase.SQL = "CALL usp_TraerTarjetas(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Tarjeta_idB", OdbcType.Int, 16, Tarjeta_id)
            MyBase.AddParameter("@BancoB", OdbcType.Char, 20, Banco)

            MyBase.FillDataSet(usp_TraerTarjetas, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerTarjetas_Det(ByVal Tarjeta_id As Integer) As DataSet
        'mreyes 18/Mayo/2012 10:51 a.m.
        Try
            usp_TraerTarjetas_Det = New DataSet
            MyBase.SQL = "CALL usp_TraerTarjetas_Det(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Tarjeta_idB", OdbcType.Int, 16, Tarjeta_id)


            MyBase.FillDataSet(usp_TraerTarjetas_Det, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
