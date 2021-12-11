'Imports System.Data.Odbc
'vgallegos 19/Enero/2018  11:34 am
'vagallegos modificado el 31/Enero/2018 11:05 am se añaden nuevos valores al procedimiento almacenado

Imports System.Data
Imports System.Data.SqlClient



Public Class DALTipoCredito

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

    Public Function usp_TraerTipoCredito(ByVal opcion As Integer, ByVal idtipocredito As Integer, ByVal tipocredito As String, ByVal idperiodicidad As Integer,
                                           ByVal fechalimpago1 As Integer, ByVal fechalimpago2 As Integer, ByVal diacorte1 As Integer, ByVal diacorte2 As Integer,
                                           ByVal carterafresco As Integer, ByVal gastofresco As Integer, ByVal interesfresco As Integer, ByVal carteravencido As Integer,
                                           ByVal gastovencido As Integer, ByVal interesvencido As Integer, ByVal gastodemanda As Integer, ByVal observaciones As String,
                                           ByVal idusuario As Integer, ByVal idusuariomodif As Integer) As DataSet

        'vgallegos 20/Enero/2018 12:48 pm ----- LLENAR EL GRID CON MISMO SP usp_CapturaTipoCredito
        Try
            usp_TraerTipoCredito = New DataSet

            MyBase.SQL = "usp_CapturaTipoCredito"
            MyBase.InitializeCommand()

            MyBase.AddParameter("@opcion", SqlDbType.Int, 8, opcion)
            MyBase.AddParameter("@idtipocredito", SqlDbType.Int, 4, idtipocredito)
            MyBase.AddParameter("@tipocredito", SqlDbType.VarChar, 50, tipocredito)
            MyBase.AddParameter("@idperiodicidad", SqlDbType.Int, 4, idperiodicidad)
            MyBase.AddParameter("@fechalimpago1", SqlDbType.SmallInt, 4, fechalimpago1)
            MyBase.AddParameter("@fechalimpago2", SqlDbType.SmallInt, 4, fechalimpago2)
            MyBase.AddParameter("@diacorte1", SqlDbType.SmallInt, 4, diacorte1)
            MyBase.AddParameter("@diacorte2", SqlDbType.SmallInt, 4, diacorte2)
            MyBase.AddParameter("@carterafresco", SqlDbType.SmallInt, 4, carterafresco)
            MyBase.AddParameter("@gastofresco", SqlDbType.Decimal, 4, gastofresco)
            MyBase.AddParameter("@interesfresco", SqlDbType.Decimal, 4, interesfresco)
            MyBase.AddParameter("@carteravencido", SqlDbType.SmallInt, 4, carteravencido)
            MyBase.AddParameter("@gastovencido", SqlDbType.Decimal, 150, gastovencido)
            MyBase.AddParameter("@interesvencido", SqlDbType.Decimal, 4, interesvencido)
            MyBase.AddParameter("@gastodemanda", SqlDbType.Decimal, 8, gastodemanda)
            MyBase.AddParameter("@observaciones", SqlDbType.VarChar, 150, observaciones)
            MyBase.AddParameter("@idusuario", SqlDbType.Int, 4, idusuario)
            MyBase.AddParameter("@idusuariomodif", SqlDbType.Int, 4, idusuariomodif)

            MyBase.FillDataSet(usp_TraerTipoCredito, "SirCo")

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerTipoCreditoId(ByVal Opcion As Integer, ByVal idtipocredito As Integer, ByVal tipocredito As String,
                                  ByVal observaciones As String, ByVal idusuario As Integer, ByVal fum As DateTime,
                                  ByVal idusuariomod As Integer, ByVal fummod As DateTime) As DataSet

        'vgallegos 20/Enero/2018 01:25 pm ----- Traer un tipo de credito mediente id usp_CapturaTipoCredito
        Try
            usp_TraerTipoCreditoId = New DataSet

            MyBase.SQL = "usp_CapturaTipoCredito"
            MyBase.InitializeCommand()

            MyBase.AddParameter("@opcion", SqlDbType.Int, 4, Opcion)
            MyBase.AddParameter("@idtipocredito", SqlDbType.Int, 4, idtipocredito)
            MyBase.AddParameter("@tipocredito", SqlDbType.VarChar, 50, tipocredito)
            MyBase.AddParameter("@observaciones", SqlDbType.VarChar, 150, observaciones)
            MyBase.AddParameter("@idusuario", SqlDbType.Int, 4, idusuario)
            MyBase.AddParameter("@fum", SqlDbType.DateTime, 8, fum)
            MyBase.AddParameter("@idusuariomodif", SqlDbType.Int, 4, idusuariomod)
            MyBase.AddParameter("@fummodif", SqlDbType.DateTime, 8, fummod)



            MyBase.FillDataSet(usp_TraerTipoCreditoId, "SirCo")


        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_CapturaTipoCredito(ByVal opcion As Integer, ByVal idtipocredito As Integer, ByVal tipocredito As String, ByVal idperiodicidad As Integer,
                                           ByVal fechalimpago1 As Integer, ByVal fechalimpago2 As Integer, ByVal diacorte1 As Integer, ByVal diacorte2 As Integer,
                                           ByVal carterafresco As Integer, ByVal gastofresco As Integer, ByVal interesfresco As Integer, ByVal carteravencido As Integer,
                                           ByVal gastovencido As Integer, ByVal interesvencido As Integer, ByVal gastodemanda As Integer, ByVal observaciones As String,
                                           ByVal idusuario As Integer, ByVal idusuariomodif As Integer) As Boolean
        'vgallegos 19/Enero/2018  12:09 p.m.
        Try
            MyBase.SQL = "usp_CapturaTipoCredito"

            MyBase.InitializeCommand()

            MyBase.AddParameter("@opcion", SqlDbType.Int, 8, opcion)
            MyBase.AddParameter("@idtipocredito", SqlDbType.Int, 4, idtipocredito)
            MyBase.AddParameter("@tipocredito", SqlDbType.VarChar, 50, tipocredito)
            MyBase.AddParameter("@idperiodicidad", SqlDbType.Int, 4, idperiodicidad)
            MyBase.AddParameter("@fechalimpago1", SqlDbType.SmallInt, 4, fechalimpago1)
            MyBase.AddParameter("@fechalimpago2", SqlDbType.SmallInt, 4, fechalimpago2)
            MyBase.AddParameter("@diacorte1", SqlDbType.SmallInt, 4, diacorte1)
            MyBase.AddParameter("@diacorte2", SqlDbType.SmallInt, 4, diacorte2)
            MyBase.AddParameter("@carterafresco", SqlDbType.SmallInt, 4, carterafresco)
            MyBase.AddParameter("@gastofresco", SqlDbType.Decimal, 4, gastofresco)
            MyBase.AddParameter("@interesfresco", SqlDbType.Decimal, 4, interesfresco)
            MyBase.AddParameter("@carteravencido", SqlDbType.SmallInt, 4, carteravencido)
            MyBase.AddParameter("@gastovencido", SqlDbType.Decimal, 150, gastovencido)
            MyBase.AddParameter("@interesvencido", SqlDbType.Decimal, 4, interesvencido)
            MyBase.AddParameter("@gastodemanda", SqlDbType.Decimal, 8, gastodemanda)
            MyBase.AddParameter("@observaciones", SqlDbType.VarChar, 150, observaciones)
            MyBase.AddParameter("@idusuario", SqlDbType.Int, 4, idusuario)
            MyBase.AddParameter("@idusuariomodif", SqlDbType.Int, 4, idusuariomodif)

            usp_CapturaTipoCredito = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerPeriodicidad() As DataSet

        'vgallegos 31/Enero/2018 01:59 pm ----- LLENAR EL COMBO DE LA PERIORICIDAD
        Try
            usp_TraerPeriodicidad = New DataSet

            MyBase.SQL = "usp_TraerPeriodicidad"
            MyBase.InitializeCommand()

            MyBase.FillDataSet(usp_TraerPeriodicidad, "Periodicidad")

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region

End Class