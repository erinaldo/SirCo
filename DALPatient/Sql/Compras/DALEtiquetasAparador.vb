'Imports System.Data.Odbc
'mreyes 06/Julio/2016   06:14 p.m.

Imports System.Data
Imports System.Data.SqlClient

Public Class DALEtiquetasAparador
    ''''Inherits DALOdbc
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




    Public Function usp_PpalEtiquetasAparador(ByVal IdSucursal As Integer, _
                                            ByVal FechaIni As Date, ByVal FechaFin As Date) As DataSet

        'mreyes 26/Agosto/2016  12:21 p.m.
        Try


            usp_PpalEtiquetasAparador = New DataSet
            MyBase.SQL = "usp_PpalEtiquetasAparador"

            MyBase.InitializeCommand()

            MyBase.AddParameter("@Sucursal", SqlDbType.Int, 16, IdSucursal)
            MyBase.AddParameter("@FechaIni", SqlDbType.Date, 8, FechaIni)
            MyBase.AddParameter("@FechaFin", SqlDbType.Date, 8, FechaFin)



            MyBase.FillDataSet(usp_PpalEtiquetasAparador, "dwh")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try




    End Function

#End Region
End Class
