Imports System.Data.Odbc
'miguel pérez 09/Octubre/2012 10:43 a.m.

Public Class DALProyeccionPromociones
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

    Public Function usp_TraerVentasNetasCosto(ByVal Sucursal As String, ByVal Vendedor As String, ByVal FechaIni As Date, ByVal FechaFin As Date, ByVal Opcion As String) As DataSet
        'miguel pérez 05/Octubre/2012 01:31 p.m.
        Try
            usp_TraerVentasNetasCosto = New DataSet
            MyBase.SQL = "CALL usp_TraerVentasNetasCosto(?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@sucursal", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@vendedor", OdbcType.Char, 2, Vendedor)
            MyBase.AddParameter("@fechaini", OdbcType.Date, 8, FechaIni)
            MyBase.AddParameter("@fechafin", OdbcType.Date, 8, FechaFin)
            MyBase.AddParameter("@opcion", OdbcType.Char, 1, Opcion)

            MyBase.FillDataSet(usp_TraerVentasNetasCosto, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

#End Region
End Class
