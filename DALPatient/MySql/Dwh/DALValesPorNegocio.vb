Imports System.Data.Odbc

Public Class DALValesPorNegocio
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


    Public Function usp_TraerNombreDistribuidor(ByVal Distribuidor As String) As DataSet
        'Tony Garcia - 17/Enero/2013 - 09:45 a.m.
        Try
            usp_TraerNombreDistribuidor = New DataSet
            MyBase.SQL = "CALL usp_TraerNombreDistribuidor(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@distribB", OdbcType.Char, 6, Distribuidor)

            MyBase.FillDataSet(usp_TraerNombreDistribuidor, "crvsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerCtdValesPorNegocio(ByVal Sucursal As String, ByVal Fechaini As Date, ByVal Fechafin As Date) As DataSet
        'Tony Garcia - 20/Noviembre/2012 - 01:30 p.m.
        Try
            usp_TraerCtdValesPorNegocio = New DataSet
            MyBase.SQL = "CALL usp_TraerCtdValesPorNegocio(?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@sucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@FechainiB", OdbcType.Date, 8, Fechaini)
            MyBase.AddParameter("@FechafinB", OdbcType.Date, 8, Fechafin)

            MyBase.FillDataSet(usp_TraerCtdValesPorNegocio, "crvsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerCtdValesPorSucursal(ByVal Sucursal As String, ByVal Fechaini As Date, ByVal Fechafin As Date) As DataSet
        'Juan - 4/Enero/2014 - 09:59 p.m.
        Try
            usp_TraerCtdValesPorSucursal = New DataSet
            MyBase.SQL = "CALL usp_TraerCtdValesPorSucursal(?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@sucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@FechainiB", OdbcType.Date, 8, Fechaini)
            MyBase.AddParameter("@FechafinB", OdbcType.Date, 8, Fechafin)

            MyBase.FillDataSet(usp_TraerCtdValesPorSucursal, "crvsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_PpalDiarioVales(ByVal Sucursal As String, ByVal Nota As String, ByVal Vale As String, ByVal Estatus As String, _
                                        ByVal Distribuidor As String, ByVal Cliente As String, ByVal Fechaini As Date, ByVal Fechafin As Date) As DataSet
        'Tony Garcia - 17/Enero/2013 - 09:45 a.m.
        Try
            usp_PpalDiarioVales = New DataSet
            MyBase.SQL = "CALL usp_PpalDiarioVales(?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Sucursalb", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@notaB", OdbcType.Char, 6, Nota)
            MyBase.AddParameter("@statusB", OdbcType.Char, 2, Estatus)
            MyBase.AddParameter("@valeB", OdbcType.Char, 6, Vale)
            MyBase.AddParameter("@distribB", OdbcType.Char, 6, Distribuidor)
            MyBase.AddParameter("@clienteB", OdbcType.Char, 6, Cliente)
            MyBase.AddParameter("@fechainiB", OdbcType.Date, 8, Fechaini)
            MyBase.AddParameter("@fechafinB", OdbcType.Date, 8, Fechafin)

            MyBase.FillDataSet(usp_PpalDiarioVales, "crvsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalVentasDistrib(ByVal DistribuidorIni As String, ByVal DistribuidorFin As String, _
                                          ByVal Sucursal As String, ByVal Estatus As String, _
                                          ByVal Fechaini As Date, ByVal Fechafin As Date) As DataSet
        'Tony Garcia - 02/Junio/2013 - 09:45 a.m.
        Try
            usp_PpalVentasDistrib = New DataSet
            MyBase.SQL = "CALL usp_PpalVentasDistrib(?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@distribiniB", OdbcType.Char, 6, DistribuidorIni)
            MyBase.AddParameter("@distribfinB", OdbcType.Char, 6, DistribuidorFin)
            MyBase.AddParameter("@sucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@estatusB", OdbcType.Char, 2, Estatus)
            MyBase.AddParameter("@fechainiB", OdbcType.Date, 8, Fechaini)
            MyBase.AddParameter("@fechafinB", OdbcType.Date, 8, Fechafin)

            MyBase.FillDataSet(usp_PpalVentasDistrib, "crvsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalVentasDistribDet(ByVal Sucursal As String, ByVal Distribuidor As String, ByVal Fechaini As Date, ByVal Fechafin As Date) As DataSet
        'Tony Garcia - 03/Junio/2013 - 11:00 a.m.
        Try
            usp_PpalVentasDistribDet = New DataSet
            MyBase.SQL = "CALL usp_PpalVentasDistribDet(?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@sucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@distribB", OdbcType.Char, 6, Distribuidor)
            MyBase.AddParameter("@fechainiB", OdbcType.Date, 8, Fechaini)
            MyBase.AddParameter("@fechafinB", OdbcType.Date, 8, Fechafin)

            MyBase.FillDataSet(usp_PpalVentasDistribDet, "crvsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerDetalleVentasDistrib(ByVal Sucursal As String, ByVal Venta As String) As DataSet
        'Tony Garcia - 07/Junio/2013 - 11:00 a.m.
        Try
            usp_TraerDetalleVentasDistrib = New DataSet
            MyBase.SQL = "CALL usp_TraerDetalleVentasDistrib(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@sucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@fechainiB", OdbcType.Char, 6, Venta)

            MyBase.FillDataSet(usp_TraerDetalleVentasDistrib, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalDiarioValesAdapter(ByVal Sucursal As String, ByVal Nota As String, ByVal Vale As String, ByVal Estatus As String, _
                                ByVal Distribuidor As String, ByVal Cliente As String, ByVal Fechaini As Date, ByVal Fechafin As Date, ByVal NegocioB As String) As DataSet
        'Juan Galvan  - 7/Enero/2014 - 09:45 a.m.
        Try
            usp_PpalDiarioValesAdapter = New DataSet
            MyBase.SQL = "CALL usp_PpalDiarioValesAdapter(?,?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Sucursalb", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@notaB", OdbcType.Char, 6, Nota)
            MyBase.AddParameter("@statusB", OdbcType.Char, 2, Estatus)
            MyBase.AddParameter("@valeB", OdbcType.Char, 6, Vale)
            MyBase.AddParameter("@distribB", OdbcType.Char, 6, Distribuidor)
            MyBase.AddParameter("@clienteB", OdbcType.Char, 6, Cliente)
            MyBase.AddParameter("@fechainiB", OdbcType.Date, 8, Fechaini)
            MyBase.AddParameter("@fechafinB", OdbcType.Date, 8, Fechafin)
            MyBase.AddParameter("@NegocioB", OdbcType.Char, 2, NegocioB)

            MyBase.FillDataSet(usp_PpalDiarioValesAdapter, "crvsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

#End Region
End Class
