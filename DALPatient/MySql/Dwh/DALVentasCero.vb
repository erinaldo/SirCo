Imports System.Data.Odbc


Public Class DALVentasCero
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

    Public Function usp_PpalSVentas(ByVal Sucursal As String, ByVal FecIni As String, ByVal FecFin As String, ByVal IdDivision As Integer, _
                                    ByVal IdDepto As Integer, ByVal DescripFamilia As String, ByVal DescripLinea As String, _
                                    ByVal DescripL1 As String, ByVal DescripL2 As String, ByVal DescripL3 As String, ByVal DescripL4 As String, _
                                    ByVal DescripL5 As String, ByVal DescripL6 As String, ByVal Marca As String, ByVal Modelo As String, _
                                    ByVal FecReciIni As String, ByVal FecReciFin As String, ByVal CtdIni As Integer, ByVal CtdFin As Integer) As DataSet
        'Tony Garcia - 29/Nov/2013 - 11:00 am
        Try
            usp_PpalSVentas = New DataSet
            MyBase.SQL = "CALL usp_PpalSVentas(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Sucursal", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@Fecini", OdbcType.Char, 10, FecIni)
            MyBase.AddParameter("@Fecfin", OdbcType.Char, 10, FecFin)
            MyBase.AddParameter("@IdDivision", OdbcType.Int, 16, IdDivision)
            MyBase.AddParameter("@IdDepto", OdbcType.Int, 16, IdDepto)
            MyBase.AddParameter("@DescripFamilia", OdbcType.Char, 30, DescripFamilia)
            MyBase.AddParameter("@DescripLinea", OdbcType.Char, 30, DescripLinea)
            MyBase.AddParameter("@DescripL1", OdbcType.Char, 30, DescripL1)
            MyBase.AddParameter("@DescripL2", OdbcType.Char, 30, DescripL2)
            MyBase.AddParameter("@DescripL3", OdbcType.Char, 30, DescripL3)
            MyBase.AddParameter("@DescripL4", OdbcType.Char, 30, DescripL4)
            MyBase.AddParameter("@DescripL5", OdbcType.Char, 30, DescripL5)
            MyBase.AddParameter("@DescripL6", OdbcType.Char, 30, DescripL6)
            MyBase.AddParameter("@Marca", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@Modelo", OdbcType.Char, 7, Modelo)
            MyBase.AddParameter("@FecReciIni", OdbcType.Char, 10, FecReciIni)
            MyBase.AddParameter("@FecReciFin", OdbcType.Char, 10, FecReciFin)
            MyBase.AddParameter("@CtdIni", OdbcType.SmallInt, 4, CtdIni)
            MyBase.AddParameter("@CtdFin", OdbcType.SmallInt, 4, CtdFin)
            MyBase.FillDataSet(usp_PpalSVentas, "dwh")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalSVentasDivisiones(ByVal Sucursal As String, ByVal FecIni As String, ByVal FecFin As String, ByVal IdDivision As Integer, _
                                    ByVal IdDepto As Integer, ByVal DescripFamilia As String, ByVal DescripLinea As String, _
                                    ByVal DescripL1 As String, ByVal DescripL2 As String, ByVal DescripL3 As String, ByVal DescripL4 As String, _
                                    ByVal DescripL5 As String, ByVal DescripL6 As String, ByVal Marca As String, ByVal Modelo As String, _
                                    ByVal FecReciIni As String, ByVal FecReciFin As String, ByVal CtdIni As Integer, ByVal CtdFin As Integer) As DataSet
        'Tony Garcia - 02/Dic/2013 - 04:45 pm
        Try
            usp_PpalSVentasDivisiones = New DataSet
            MyBase.SQL = "CALL usp_PpalSVentasDivisiones(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Sucursal", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@Fecini", OdbcType.Char, 10, FecIni)
            MyBase.AddParameter("@Fecfin", OdbcType.Char, 10, FecFin)
            MyBase.AddParameter("@IdDivision", OdbcType.Int, 16, IdDivision)
            MyBase.AddParameter("@IdDepto", OdbcType.Int, 16, IdDepto)
            MyBase.AddParameter("@DescripFamilia", OdbcType.Char, 30, DescripFamilia)
            MyBase.AddParameter("@DescripLinea", OdbcType.Char, 30, DescripLinea)
            MyBase.AddParameter("@DescripL1", OdbcType.Char, 30, DescripL1)
            MyBase.AddParameter("@DescripL2", OdbcType.Char, 30, DescripL2)
            MyBase.AddParameter("@DescripL3", OdbcType.Char, 30, DescripL3)
            MyBase.AddParameter("@DescripL4", OdbcType.Char, 30, DescripL4)
            MyBase.AddParameter("@DescripL5", OdbcType.Char, 30, DescripL5)
            MyBase.AddParameter("@DescripL6", OdbcType.Char, 30, DescripL6)
            MyBase.AddParameter("@Marca", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@Modelo", OdbcType.Char, 7, Modelo)
            MyBase.AddParameter("@FecReciIni", OdbcType.Char, 10, FecReciIni)
            MyBase.AddParameter("@FecReciFin", OdbcType.Char, 10, FecReciFin)
            MyBase.AddParameter("@CtdIni", OdbcType.SmallInt, 4, CtdIni)
            MyBase.AddParameter("@CtdFin", OdbcType.SmallInt, 4, CtdFin)
            MyBase.FillDataSet(usp_PpalSVentasDivisiones, "dwh")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_PpalSVentasDepto(ByVal Sucursal As String, ByVal FecIni As String, ByVal FecFin As String, ByVal IdDivision As Integer, _
                                    ByVal IdDepto As Integer, ByVal DescripFamilia As String, ByVal DescripLinea As String, _
                                    ByVal DescripL1 As String, ByVal DescripL2 As String, ByVal DescripL3 As String, ByVal DescripL4 As String, _
                                    ByVal DescripL5 As String, ByVal DescripL6 As String, ByVal Marca As String, ByVal Modelo As String, _
                                    ByVal FecReciIni As String, ByVal FecReciFin As String, ByVal CtdIni As Integer, ByVal CtdFin As Integer) As DataSet
        'Tony Garcia - 02/Dic/2013 - 04:45 pm
        Try
            usp_PpalSVentasDepto = New DataSet
            MyBase.SQL = "CALL usp_PpalSVentasDepto(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Sucursal", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@Fecini", OdbcType.Char, 10, FecIni)
            MyBase.AddParameter("@Fecfin", OdbcType.Char, 10, FecFin)
            MyBase.AddParameter("@IdDivision", OdbcType.Int, 16, IdDivision)
            MyBase.AddParameter("@IdDepto", OdbcType.Int, 16, IdDepto)
            MyBase.AddParameter("@DescripFamilia", OdbcType.Char, 30, DescripFamilia)
            MyBase.AddParameter("@DescripLinea", OdbcType.Char, 30, DescripLinea)
            MyBase.AddParameter("@DescripL1", OdbcType.Char, 30, DescripL1)
            MyBase.AddParameter("@DescripL2", OdbcType.Char, 30, DescripL2)
            MyBase.AddParameter("@DescripL3", OdbcType.Char, 30, DescripL3)
            MyBase.AddParameter("@DescripL4", OdbcType.Char, 30, DescripL4)
            MyBase.AddParameter("@DescripL5", OdbcType.Char, 30, DescripL5)
            MyBase.AddParameter("@DescripL6", OdbcType.Char, 30, DescripL6)
            MyBase.AddParameter("@Marca", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@Modelo", OdbcType.Char, 7, Modelo)
            MyBase.AddParameter("@FecReciIni", OdbcType.Char, 10, FecReciIni)
            MyBase.AddParameter("@FecReciFin", OdbcType.Char, 10, FecReciFin)
            MyBase.AddParameter("@CtdIni", OdbcType.SmallInt, 4, CtdIni)
            MyBase.AddParameter("@CtdFin", OdbcType.SmallInt, 4, CtdFin)
            MyBase.FillDataSet(usp_PpalSVentasDepto, "dwh")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalSVentasFamilia(ByVal Sucursal As String, ByVal FecIni As String, ByVal FecFin As String, ByVal IdDivision As Integer, _
                                    ByVal IdDepto As Integer, ByVal DescripFamilia As String, ByVal DescripLinea As String, _
                                    ByVal DescripL1 As String, ByVal DescripL2 As String, ByVal DescripL3 As String, ByVal DescripL4 As String, _
                                    ByVal DescripL5 As String, ByVal DescripL6 As String, ByVal Marca As String, ByVal Modelo As String, _
                                    ByVal FecReciIni As String, ByVal FecReciFin As String, ByVal CtdIni As Integer, ByVal CtdFin As Integer) As DataSet
        'Tony Garcia - 02/Dic/2013 - 04:45 pm
        Try
            usp_PpalSVentasFamilia = New DataSet
            MyBase.SQL = "CALL usp_PpalSVentasFamilia(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Sucursal", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@Fecini", OdbcType.Char, 10, FecIni)
            MyBase.AddParameter("@Fecfin", OdbcType.Char, 10, FecFin)
            MyBase.AddParameter("@IdDivision", OdbcType.Int, 16, IdDivision)
            MyBase.AddParameter("@IdDepto", OdbcType.Int, 16, IdDepto)
            MyBase.AddParameter("@DescripFamilia", OdbcType.Char, 30, DescripFamilia)
            MyBase.AddParameter("@DescripLinea", OdbcType.Char, 30, DescripLinea)
            MyBase.AddParameter("@DescripL1", OdbcType.Char, 30, DescripL1)
            MyBase.AddParameter("@DescripL2", OdbcType.Char, 30, DescripL2)
            MyBase.AddParameter("@DescripL3", OdbcType.Char, 30, DescripL3)
            MyBase.AddParameter("@DescripL4", OdbcType.Char, 30, DescripL4)
            MyBase.AddParameter("@DescripL5", OdbcType.Char, 30, DescripL5)
            MyBase.AddParameter("@DescripL6", OdbcType.Char, 30, DescripL6)
            MyBase.AddParameter("@Marca", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@Modelo", OdbcType.Char, 7, Modelo)
            MyBase.AddParameter("@FecReciIni", OdbcType.Char, 10, FecReciIni)
            MyBase.AddParameter("@FecReciFin", OdbcType.Char, 10, FecReciFin)
            MyBase.AddParameter("@CtdIni", OdbcType.SmallInt, 4, CtdIni)
            MyBase.AddParameter("@CtdFin", OdbcType.SmallInt, 4, CtdFin)
            MyBase.FillDataSet(usp_PpalSVentasFamilia, "dwh")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalSVentasLinea(ByVal Sucursal As String, ByVal FecIni As String, ByVal FecFin As String, ByVal IdDivision As Integer, _
                                    ByVal IdDepto As Integer, ByVal DescripFamilia As String, ByVal DescripLinea As String, _
                                    ByVal DescripL1 As String, ByVal DescripL2 As String, ByVal DescripL3 As String, ByVal DescripL4 As String, _
                                    ByVal DescripL5 As String, ByVal DescripL6 As String, ByVal Marca As String, ByVal Modelo As String, _
                                    ByVal FecReciIni As String, ByVal FecReciFin As String, ByVal CtdIni As Integer, ByVal CtdFin As Integer) As DataSet
        'Tony Garcia - 02/Dic/2013 - 04:45 pm
        Try
            usp_PpalSVentasLinea = New DataSet
            MyBase.SQL = "CALL usp_PpalSVentasLinea(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Sucursal", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@Fecini", OdbcType.Char, 10, FecIni)
            MyBase.AddParameter("@Fecfin", OdbcType.Char, 10, FecFin)
            MyBase.AddParameter("@IdDivision", OdbcType.Int, 16, IdDivision)
            MyBase.AddParameter("@IdDepto", OdbcType.Int, 16, IdDepto)
            MyBase.AddParameter("@DescripFamilia", OdbcType.Char, 30, DescripFamilia)
            MyBase.AddParameter("@DescripLinea", OdbcType.Char, 30, DescripLinea)
            MyBase.AddParameter("@DescripL1", OdbcType.Char, 30, DescripL1)
            MyBase.AddParameter("@DescripL2", OdbcType.Char, 30, DescripL2)
            MyBase.AddParameter("@DescripL3", OdbcType.Char, 30, DescripL3)
            MyBase.AddParameter("@DescripL4", OdbcType.Char, 30, DescripL4)
            MyBase.AddParameter("@DescripL5", OdbcType.Char, 30, DescripL5)
            MyBase.AddParameter("@DescripL6", OdbcType.Char, 30, DescripL6)
            MyBase.AddParameter("@Marca", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@Modelo", OdbcType.Char, 7, Modelo)
            MyBase.AddParameter("@FecReciIni", OdbcType.Char, 10, FecReciIni)
            MyBase.AddParameter("@FecReciFin", OdbcType.Char, 10, FecReciFin)
            MyBase.AddParameter("@CtdIni", OdbcType.SmallInt, 4, CtdIni)
            MyBase.AddParameter("@CtdFin", OdbcType.SmallInt, 4, CtdFin)
            MyBase.FillDataSet(usp_PpalSVentasLinea, "dwh")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalSVentasL1(ByVal Sucursal As String, ByVal FecIni As String, ByVal FecFin As String, ByVal IdDivision As Integer, _
                                    ByVal IdDepto As Integer, ByVal DescripFamilia As String, ByVal DescripLinea As String, _
                                    ByVal DescripL1 As String, ByVal DescripL2 As String, ByVal DescripL3 As String, ByVal DescripL4 As String, _
                                    ByVal DescripL5 As String, ByVal DescripL6 As String, ByVal Marca As String, ByVal Modelo As String, _
                                    ByVal FecReciIni As String, ByVal FecReciFin As String, ByVal CtdIni As Integer, ByVal CtdFin As Integer) As DataSet
        'Tony Garcia - 02/Dic/2013 - 04:45 pm
        Try
            usp_PpalSVentasL1 = New DataSet
            MyBase.SQL = "CALL usp_PpalSVentasL1(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Sucursal", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@Fecini", OdbcType.Char, 10, FecIni)
            MyBase.AddParameter("@Fecfin", OdbcType.Char, 10, FecFin)
            MyBase.AddParameter("@IdDivision", OdbcType.Int, 16, IdDivision)
            MyBase.AddParameter("@IdDepto", OdbcType.Int, 16, IdDepto)
            MyBase.AddParameter("@DescripFamilia", OdbcType.Char, 30, DescripFamilia)
            MyBase.AddParameter("@DescripLinea", OdbcType.Char, 30, DescripLinea)
            MyBase.AddParameter("@DescripL1", OdbcType.Char, 30, DescripL1)
            MyBase.AddParameter("@DescripL2", OdbcType.Char, 30, DescripL2)
            MyBase.AddParameter("@DescripL3", OdbcType.Char, 30, DescripL3)
            MyBase.AddParameter("@DescripL4", OdbcType.Char, 30, DescripL4)
            MyBase.AddParameter("@DescripL5", OdbcType.Char, 30, DescripL5)
            MyBase.AddParameter("@DescripL6", OdbcType.Char, 30, DescripL6)
            MyBase.AddParameter("@Marca", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@Modelo", OdbcType.Char, 7, Modelo)
            MyBase.AddParameter("@FecReciIni", OdbcType.Char, 10, FecReciIni)
            MyBase.AddParameter("@FecReciFin", OdbcType.Char, 10, FecReciFin)
            MyBase.AddParameter("@CtdIni", OdbcType.SmallInt, 4, CtdIni)
            MyBase.AddParameter("@CtdFin", OdbcType.SmallInt, 4, CtdFin)
            MyBase.FillDataSet(usp_PpalSVentasL1, "dwh")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalSVentasL2(ByVal Sucursal As String, ByVal FecIni As String, ByVal FecFin As String, ByVal IdDivision As Integer, _
                                    ByVal IdDepto As Integer, ByVal DescripFamilia As String, ByVal DescripLinea As String, _
                                    ByVal DescripL1 As String, ByVal DescripL2 As String, ByVal DescripL3 As String, ByVal DescripL4 As String, _
                                    ByVal DescripL5 As String, ByVal DescripL6 As String, ByVal Marca As String, ByVal Modelo As String, _
                                    ByVal FecReciIni As String, ByVal FecReciFin As String, ByVal CtdIni As Integer, ByVal CtdFin As Integer) As DataSet
        'Tony Garcia - 02/Dic/2013 - 04:45 pm
        Try
            usp_PpalSVentasL2 = New DataSet
            MyBase.SQL = "CALL usp_PpalSVentasL2(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Sucursal", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@Fecini", OdbcType.Char, 10, FecIni)
            MyBase.AddParameter("@Fecfin", OdbcType.Char, 10, FecFin)
            MyBase.AddParameter("@IdDivision", OdbcType.Int, 16, IdDivision)
            MyBase.AddParameter("@IdDepto", OdbcType.Int, 16, IdDepto)
            MyBase.AddParameter("@DescripFamilia", OdbcType.Char, 30, DescripFamilia)
            MyBase.AddParameter("@DescripLinea", OdbcType.Char, 30, DescripLinea)
            MyBase.AddParameter("@DescripL1", OdbcType.Char, 30, DescripL1)
            MyBase.AddParameter("@DescripL2", OdbcType.Char, 30, DescripL2)
            MyBase.AddParameter("@DescripL3", OdbcType.Char, 30, DescripL3)
            MyBase.AddParameter("@DescripL4", OdbcType.Char, 30, DescripL4)
            MyBase.AddParameter("@DescripL5", OdbcType.Char, 30, DescripL5)
            MyBase.AddParameter("@DescripL6", OdbcType.Char, 30, DescripL6)
            MyBase.AddParameter("@Marca", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@Modelo", OdbcType.Char, 7, Modelo)
            MyBase.AddParameter("@FecReciIni", OdbcType.Char, 10, FecReciIni)
            MyBase.AddParameter("@FecReciFin", OdbcType.Char, 10, FecReciFin)
            MyBase.AddParameter("@CtdIni", OdbcType.SmallInt, 4, CtdIni)
            MyBase.AddParameter("@CtdFin", OdbcType.SmallInt, 4, CtdFin)
            MyBase.FillDataSet(usp_PpalSVentasL2, "dwh")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalSVentasL3(ByVal Sucursal As String, ByVal FecIni As String, ByVal FecFin As String, ByVal IdDivision As Integer, _
                                    ByVal IdDepto As Integer, ByVal DescripFamilia As String, ByVal DescripLinea As String, _
                                    ByVal DescripL1 As String, ByVal DescripL2 As String, ByVal DescripL3 As String, ByVal DescripL4 As String, _
                                    ByVal DescripL5 As String, ByVal DescripL6 As String, ByVal Marca As String, ByVal Modelo As String, _
                                    ByVal FecReciIni As String, ByVal FecReciFin As String, ByVal CtdIni As Integer, ByVal CtdFin As Integer) As DataSet
        'Tony Garcia - 02/Dic/2013 - 04:45 pm
        Try
            usp_PpalSVentasL3 = New DataSet
            MyBase.SQL = "CALL usp_PpalSVentasL3(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Sucursal", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@Fecini", OdbcType.Char, 10, FecIni)
            MyBase.AddParameter("@Fecfin", OdbcType.Char, 10, FecFin)
            MyBase.AddParameter("@IdDivision", OdbcType.Int, 16, IdDivision)
            MyBase.AddParameter("@IdDepto", OdbcType.Int, 16, IdDepto)
            MyBase.AddParameter("@DescripFamilia", OdbcType.Char, 30, DescripFamilia)
            MyBase.AddParameter("@DescripLinea", OdbcType.Char, 30, DescripLinea)
            MyBase.AddParameter("@DescripL1", OdbcType.Char, 30, DescripL1)
            MyBase.AddParameter("@DescripL2", OdbcType.Char, 30, DescripL2)
            MyBase.AddParameter("@DescripL3", OdbcType.Char, 30, DescripL3)
            MyBase.AddParameter("@DescripL4", OdbcType.Char, 30, DescripL4)
            MyBase.AddParameter("@DescripL5", OdbcType.Char, 30, DescripL5)
            MyBase.AddParameter("@DescripL6", OdbcType.Char, 30, DescripL6)
            MyBase.AddParameter("@Marca", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@Modelo", OdbcType.Char, 7, Modelo)
            MyBase.AddParameter("@FecReciIni", OdbcType.Char, 10, FecReciIni)
            MyBase.AddParameter("@FecReciFin", OdbcType.Char, 10, FecReciFin)
            MyBase.AddParameter("@CtdIni", OdbcType.SmallInt, 4, CtdIni)
            MyBase.AddParameter("@CtdFin", OdbcType.SmallInt, 4, CtdFin)
            MyBase.FillDataSet(usp_PpalSVentasL3, "dwh")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalSVentasL4(ByVal Sucursal As String, ByVal FecIni As String, ByVal FecFin As String, ByVal IdDivision As Integer, _
                                    ByVal IdDepto As Integer, ByVal DescripFamilia As String, ByVal DescripLinea As String, _
                                    ByVal DescripL1 As String, ByVal DescripL2 As String, ByVal DescripL3 As String, ByVal DescripL4 As String, _
                                    ByVal DescripL5 As String, ByVal DescripL6 As String, ByVal Marca As String, ByVal Modelo As String, _
                                    ByVal FecReciIni As String, ByVal FecReciFin As String, ByVal CtdIni As Integer, ByVal CtdFin As Integer) As DataSet
        'Tony Garcia - 02/Dic/2013 - 04:45 pm
        Try
            usp_PpalSVentasL4 = New DataSet
            MyBase.SQL = "CALL usp_PpalSVentasL4(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Sucursal", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@Fecini", OdbcType.Char, 10, FecIni)
            MyBase.AddParameter("@Fecfin", OdbcType.Char, 10, FecFin)
            MyBase.AddParameter("@IdDivision", OdbcType.Int, 16, IdDivision)
            MyBase.AddParameter("@IdDepto", OdbcType.Int, 16, IdDepto)
            MyBase.AddParameter("@DescripFamilia", OdbcType.Char, 30, DescripFamilia)
            MyBase.AddParameter("@DescripLinea", OdbcType.Char, 30, DescripLinea)
            MyBase.AddParameter("@DescripL1", OdbcType.Char, 30, DescripL1)
            MyBase.AddParameter("@DescripL2", OdbcType.Char, 30, DescripL2)
            MyBase.AddParameter("@DescripL3", OdbcType.Char, 30, DescripL3)
            MyBase.AddParameter("@DescripL4", OdbcType.Char, 30, DescripL4)
            MyBase.AddParameter("@DescripL5", OdbcType.Char, 30, DescripL5)
            MyBase.AddParameter("@DescripL6", OdbcType.Char, 30, DescripL6)
            MyBase.AddParameter("@Marca", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@Modelo", OdbcType.Char, 7, Modelo)
            MyBase.AddParameter("@FecReciIni", OdbcType.Char, 10, FecReciIni)
            MyBase.AddParameter("@FecReciFin", OdbcType.Char, 10, FecReciFin)
            MyBase.AddParameter("@CtdIni", OdbcType.SmallInt, 4, CtdIni)
            MyBase.AddParameter("@CtdFin", OdbcType.SmallInt, 4, CtdFin)
            MyBase.FillDataSet(usp_PpalSVentasL4, "dwh")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalSVentasL5(ByVal Sucursal As String, ByVal FecIni As String, ByVal FecFin As String, ByVal IdDivision As Integer, _
                                    ByVal IdDepto As Integer, ByVal DescripFamilia As String, ByVal DescripLinea As String, _
                                    ByVal DescripL1 As String, ByVal DescripL2 As String, ByVal DescripL3 As String, ByVal DescripL4 As String, _
                                    ByVal DescripL5 As String, ByVal DescripL6 As String, ByVal Marca As String, ByVal Modelo As String, _
                                    ByVal FecReciIni As String, ByVal FecReciFin As String, ByVal CtdIni As Integer, ByVal CtdFin As Integer) As DataSet
        'Tony Garcia - 02/Dic/2013 - 04:45 pm
        Try
            usp_PpalSVentasL5 = New DataSet
            MyBase.SQL = "CALL usp_PpalSVentasL5(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Sucursal", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@Fecini", OdbcType.Char, 10, FecIni)
            MyBase.AddParameter("@Fecfin", OdbcType.Char, 10, FecFin)
            MyBase.AddParameter("@IdDivision", OdbcType.Int, 16, IdDivision)
            MyBase.AddParameter("@IdDepto", OdbcType.Int, 16, IdDepto)
            MyBase.AddParameter("@DescripFamilia", OdbcType.Char, 30, DescripFamilia)
            MyBase.AddParameter("@DescripLinea", OdbcType.Char, 30, DescripLinea)
            MyBase.AddParameter("@DescripL1", OdbcType.Char, 30, DescripL1)
            MyBase.AddParameter("@DescripL2", OdbcType.Char, 30, DescripL2)
            MyBase.AddParameter("@DescripL3", OdbcType.Char, 30, DescripL3)
            MyBase.AddParameter("@DescripL4", OdbcType.Char, 30, DescripL4)
            MyBase.AddParameter("@DescripL5", OdbcType.Char, 30, DescripL5)
            MyBase.AddParameter("@DescripL6", OdbcType.Char, 30, DescripL6)
            MyBase.AddParameter("@Marca", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@Modelo", OdbcType.Char, 7, Modelo)
            MyBase.AddParameter("@FecReciIni", OdbcType.Char, 10, FecReciIni)
            MyBase.AddParameter("@FecReciFin", OdbcType.Char, 10, FecReciFin)
            MyBase.AddParameter("@CtdIni", OdbcType.SmallInt, 4, CtdIni)
            MyBase.AddParameter("@CtdFin", OdbcType.SmallInt, 4, CtdFin)
            MyBase.FillDataSet(usp_PpalSVentasL5, "dwh")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalSVentasL6(ByVal Sucursal As String, ByVal FecIni As String, ByVal FecFin As String, ByVal IdDivision As Integer, _
                                    ByVal IdDepto As Integer, ByVal DescripFamilia As String, ByVal DescripLinea As String, _
                                    ByVal DescripL1 As String, ByVal DescripL2 As String, ByVal DescripL3 As String, ByVal DescripL4 As String, _
                                    ByVal DescripL5 As String, ByVal DescripL6 As String, ByVal Marca As String, ByVal Modelo As String, _
                                    ByVal FecReciIni As String, ByVal FecReciFin As String, ByVal CtdIni As Integer, ByVal CtdFin As Integer) As DataSet
        'Tony Garcia - 02/Dic/2013 - 04:45 pm
        Try
            usp_PpalSVentasL6 = New DataSet
            MyBase.SQL = "CALL usp_PpalSVentasL6(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Sucursal", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@Fecini", OdbcType.Char, 10, FecIni)
            MyBase.AddParameter("@Fecfin", OdbcType.Char, 10, FecFin)
            MyBase.AddParameter("@IdDivision", OdbcType.Int, 16, IdDivision)
            MyBase.AddParameter("@IdDepto", OdbcType.Int, 16, IdDepto)
            MyBase.AddParameter("@DescripFamilia", OdbcType.Char, 30, DescripFamilia)
            MyBase.AddParameter("@DescripLinea", OdbcType.Char, 30, DescripLinea)
            MyBase.AddParameter("@DescripL1", OdbcType.Char, 30, DescripL1)
            MyBase.AddParameter("@DescripL2", OdbcType.Char, 30, DescripL2)
            MyBase.AddParameter("@DescripL3", OdbcType.Char, 30, DescripL3)
            MyBase.AddParameter("@DescripL4", OdbcType.Char, 30, DescripL4)
            MyBase.AddParameter("@DescripL5", OdbcType.Char, 30, DescripL5)
            MyBase.AddParameter("@DescripL6", OdbcType.Char, 30, DescripL6)
            MyBase.AddParameter("@Marca", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@Modelo", OdbcType.Char, 7, Modelo)
            MyBase.AddParameter("@FecReciIni", OdbcType.Char, 10, FecReciIni)
            MyBase.AddParameter("@FecReciFin", OdbcType.Char, 10, FecReciFin)
            MyBase.AddParameter("@CtdIni", OdbcType.SmallInt, 4, CtdIni)
            MyBase.AddParameter("@CtdFin", OdbcType.SmallInt, 4, CtdFin)
            MyBase.FillDataSet(usp_PpalSVentasL6, "dwh")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalSVentasMarca(ByVal Sucursal As String, ByVal FecIni As String, ByVal FecFin As String, ByVal IdDivision As Integer, _
                                    ByVal IdDepto As Integer, ByVal DescripFamilia As String, ByVal DescripLinea As String, _
                                    ByVal DescripL1 As String, ByVal DescripL2 As String, ByVal DescripL3 As String, ByVal DescripL4 As String, _
                                    ByVal DescripL5 As String, ByVal DescripL6 As String, ByVal Marca As String, ByVal Modelo As String, _
                                    ByVal FecReciIni As String, ByVal FecReciFin As String, ByVal CtdIni As Integer, ByVal CtdFin As Integer) As DataSet
        'Tony Garcia - 02/Dic/2013 - 04:45 pm
        Try
            usp_PpalSVentasMarca = New DataSet
            MyBase.SQL = "CALL usp_PpalSVentasMarca(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Sucursal", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@Fecini", OdbcType.Char, 10, FecIni)
            MyBase.AddParameter("@Fecfin", OdbcType.Char, 10, FecFin)
            MyBase.AddParameter("@IdDivision", OdbcType.Int, 16, IdDivision)
            MyBase.AddParameter("@IdDepto", OdbcType.Int, 16, IdDepto)
            MyBase.AddParameter("@DescripFamilia", OdbcType.Char, 30, DescripFamilia)
            MyBase.AddParameter("@DescripLinea", OdbcType.Char, 30, DescripLinea)
            MyBase.AddParameter("@DescripL1", OdbcType.Char, 30, DescripL1)
            MyBase.AddParameter("@DescripL2", OdbcType.Char, 30, DescripL2)
            MyBase.AddParameter("@DescripL3", OdbcType.Char, 30, DescripL3)
            MyBase.AddParameter("@DescripL4", OdbcType.Char, 30, DescripL4)
            MyBase.AddParameter("@DescripL5", OdbcType.Char, 30, DescripL5)
            MyBase.AddParameter("@DescripL6", OdbcType.Char, 30, DescripL6)
            MyBase.AddParameter("@Marca", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@Modelo", OdbcType.Char, 7, Modelo)
            MyBase.AddParameter("@FecReciIni", OdbcType.Char, 10, FecReciIni)
            MyBase.AddParameter("@FecReciFin", OdbcType.Char, 10, FecReciFin)
            MyBase.AddParameter("@CtdIni", OdbcType.SmallInt, 4, CtdIni)
            MyBase.AddParameter("@CtdFin", OdbcType.SmallInt, 4, CtdFin)
            MyBase.FillDataSet(usp_PpalSVentasMarca, "dwh")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalSVentasModelo(ByVal Sucursal As String, ByVal FecIni As String, ByVal FecFin As String, ByVal IdDivision As Integer, _
                                    ByVal IdDepto As Integer, ByVal DescripFamilia As String, ByVal DescripLinea As String, _
                                    ByVal DescripL1 As String, ByVal DescripL2 As String, ByVal DescripL3 As String, ByVal DescripL4 As String, _
                                    ByVal DescripL5 As String, ByVal DescripL6 As String, ByVal Marca As String, ByVal Modelo As String, _
                                    ByVal FecReciIni As String, ByVal FecReciFin As String, ByVal CtdIni As Integer, ByVal CtdFin As Integer) As DataSet
        'Tony Garcia - 02/Dic/2013 - 04:45 pm
        Try
            usp_PpalSVentasModelo = New DataSet
            MyBase.SQL = "CALL usp_PpalSVentasModelo(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Sucursal", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@Fecini", OdbcType.Char, 10, FecIni)
            MyBase.AddParameter("@Fecfin", OdbcType.Char, 10, FecFin)
            MyBase.AddParameter("@IdDivision", OdbcType.Int, 16, IdDivision)
            MyBase.AddParameter("@IdDepto", OdbcType.Int, 16, IdDepto)
            MyBase.AddParameter("@DescripFamilia", OdbcType.Char, 30, DescripFamilia)
            MyBase.AddParameter("@DescripLinea", OdbcType.Char, 30, DescripLinea)
            MyBase.AddParameter("@DescripL1", OdbcType.Char, 30, DescripL1)
            MyBase.AddParameter("@DescripL2", OdbcType.Char, 30, DescripL2)
            MyBase.AddParameter("@DescripL3", OdbcType.Char, 30, DescripL3)
            MyBase.AddParameter("@DescripL4", OdbcType.Char, 30, DescripL4)
            MyBase.AddParameter("@DescripL5", OdbcType.Char, 30, DescripL5)
            MyBase.AddParameter("@DescripL6", OdbcType.Char, 30, DescripL6)
            MyBase.AddParameter("@Marca", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@Modelo", OdbcType.Char, 7, Modelo)
            MyBase.AddParameter("@FecReciIni", OdbcType.Char, 10, FecReciIni)
            MyBase.AddParameter("@FecReciFin", OdbcType.Char, 10, FecReciFin)
            MyBase.AddParameter("@CtdIni", OdbcType.SmallInt, 4, CtdIni)
            MyBase.AddParameter("@CtdFin", OdbcType.SmallInt, 4, CtdFin)
            MyBase.FillDataSet(usp_PpalSVentasModelo, "dwh")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_GeneraExist(ByVal Fecha As String, ByVal Actualiza As Boolean) As Boolean
        'miguel pérez 05/Diciembre/2012 12:13 p.m.
        Try
            MyBase.SQL = "CALL usp_GeneraExist(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@fechaB", OdbcType.Char, 10, Fecha)
            MyBase.AddParameter("@Actualiza", OdbcType.Int, 8, Actualiza)
            usp_GeneraExist = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerFecUltBitacora(ByVal Tipo As String) As DataSet
        'Tony Garcia - 23/01/2014 - 04:45 pm
        Try
            usp_TraerFecUltBitacora = New DataSet
            MyBase.SQL = "CALL usp_TraerFecUltBitacora(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@TipoB", OdbcType.Char, 30, Tipo)

            MyBase.FillDataSet(usp_TraerFecUltBitacora, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

#End Region
End Class
