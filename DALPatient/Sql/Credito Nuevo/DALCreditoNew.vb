Imports System.Data
Imports System.Data.SqlClient

Public Class DALCreditoNew
    Inherits DALBase
    Sub New(ByVal ConString As String)
        MyBase.New(ConString)
    End Sub

    Public Function usp_PpalEstadoCarteraNew(ByVal Opcion As Integer, ByVal fecha As Date) As DataSet
        'jvargas 22/Agosto/2018   09:30 a.m.
        Try
            usp_PpalEstadoCarteraNew = New DataSet
            MyBase.SQL = "usp_PpalEstadoCarteraNew"
            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", SqlDbType.Int, 1, Opcion)
            MyBase.AddParameter("@fecha", SqlDbType.Date, 10, fecha)
            MyBase.FillDataSet(usp_PpalEstadoCarteraNew, "SirCo")

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalEstadoCarteraDrillDownNew(ByVal fecha_hasta As Date, tipo_cartera As Integer, id_consulta As Integer) As DataSet
        'jvargas 22/Agosto/2018   09:30 a.m.
        Try
            usp_PpalEstadoCarteraDrillDownNew = New DataSet
            MyBase.SQL = "usp_PpalEstadoCarteraDrillDownNew"
            MyBase.InitializeCommand()
            MyBase.AddParameter("@fecha", SqlDbType.Date, 10, fecha_hasta)
            MyBase.AddParameter("@opcion_cartera", SqlDbType.Int, 1, tipo_cartera)
            MyBase.AddParameter("@id_consulta", SqlDbType.Int, 1, id_consulta)
            MyBase.FillDataSet(usp_PpalEstadoCarteraDrillDownNew, "SirCo")

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
End Class
