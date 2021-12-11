Imports System.Data.Odbc
'miguel pérez 09/Octubre/2012 10:43 a.m.

Public Class DALVentas
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

    Public Function usp_PpalVentasPlaza(ByVal FecIniA As String, ByVal FecIniB As String, ByVal Plaza As Integer, ByVal Sucursal As Integer, ByVal Division As Integer, ByVal Depto As Integer, ByVal FamiliaDescrip As String, ByVal LineaDescrip As String, ByVal L1Descrip As String, ByVal L2Descrip As String, ByVal L3Descrip As String, ByVal L4Descrip As String, ByVal L5Descrip As String, ByVal L6Descrip As String, ByVal Marca As String, ByVal Modelo As String, ByVal FecRecA As String, ByVal FecRecB As String, ByVal AñoAnterior As Boolean, ByVal IdAgrupacion As Integer, ByVal AñoAnteriorIgual As Boolean, ByVal MInicio As Char) As DataSet
        'mreyes 13/Octubre/2015 12:08 p.m.

        Try
            usp_PpalVentasPlaza = New DataSet
            MyBase.SQL = "CALL usp_PpalVentasPlaza(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"


            MyBase.InitializeCommand()
            MyBase.AddParameter("@FecIniA", OdbcType.Char, 10, FecIniA)
            MyBase.AddParameter("@FecIniB", OdbcType.Char, 10, FecIniB)
            MyBase.AddParameter("@PlazaB", OdbcType.Int, 16, Plaza)
            MyBase.AddParameter("@SucursalB", OdbcType.Int, 16, Sucursal)
            MyBase.AddParameter("@DivisionesB", OdbcType.Int, 16, Division)
            MyBase.AddParameter("@DeptoB", OdbcType.Int, 16, Depto)
            MyBase.AddParameter("@FamiliaDescripB", OdbcType.Char, 30, FamiliaDescrip)
            MyBase.AddParameter("@LineaDescripB", OdbcType.Char, 30, LineaDescrip)
            MyBase.AddParameter("@L1DescripB", OdbcType.Char, 30, L1Descrip)
            MyBase.AddParameter("@L2DescripB", OdbcType.Char, 30, L2Descrip)
            MyBase.AddParameter("@L3DescripB", OdbcType.Char, 30, L3Descrip)
            MyBase.AddParameter("@L4DescripB", OdbcType.Char, 30, L4Descrip)
            MyBase.AddParameter("@L5DescripB", OdbcType.Char, 30, L5Descrip)
            MyBase.AddParameter("@L6DescripB", OdbcType.Char, 30, L6Descrip)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@ModeloB", OdbcType.Char, 7, Modelo)
            MyBase.AddParameter("@FecRecA", OdbcType.Char, 10, FecRecA)
            MyBase.AddParameter("@FecRecB", OdbcType.Char, 10, FecRecB)
            MyBase.AddParameter("@AnioAnterior", OdbcType.Int, 8, AñoAnterior)
            MyBase.AddParameter("@IdAgrupacionb", OdbcType.Int, 8, IdAgrupacion)
            MyBase.AddParameter("@AnioAnteriorIgual", OdbcType.Int, 8, AñoAnteriorIgual)

            MyBase.AddParameter("@MInicioB", OdbcType.Char, 1, MInicio)

            MyBase.FillDataSet(usp_PpalVentasPlaza, "dwh")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_PpalVentas(ByVal FecIniA As String, ByVal FecIniB As String, ByVal Plaza As Integer, ByVal Sucursal As Integer, ByVal Division As Integer, ByVal Depto As Integer, ByVal FamiliaDescrip As String, ByVal LineaDescrip As String, ByVal L1Descrip As String, ByVal L2Descrip As String, ByVal L3Descrip As String, ByVal L4Descrip As String, ByVal L5Descrip As String, ByVal L6Descrip As String, ByVal Marca As String, ByVal Modelo As String, ByVal FecRecA As String, ByVal FecRecB As String, ByVal AñoAnterior As Boolean, ByVal IdAgrupacion As Integer, ByVal AñoAnteriorIgual As Boolean, ByVal MInicio As Char) As DataSet
        'miguel perez 13JUN2013

        Try
            usp_PpalVentas = New DataSet
            MyBase.SQL = "CALL usp_PpalVentas(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"


            MyBase.InitializeCommand()
            MyBase.AddParameter("@FecIniA", OdbcType.Char, 10, FecIniA)
            MyBase.AddParameter("@FecIniB", OdbcType.Char, 10, FecIniB)
            MyBase.AddParameter("@PlazaB", OdbcType.Int, 16, Plaza)
            MyBase.AddParameter("@SucursalB", OdbcType.Int, 16, Sucursal)
            MyBase.AddParameter("@DivisionesB", OdbcType.Int, 16, Division)
            MyBase.AddParameter("@DeptoB", OdbcType.Int, 16, Depto)
            MyBase.AddParameter("@FamiliaDescripB", OdbcType.Char, 30, FamiliaDescrip)
            MyBase.AddParameter("@LineaDescripB", OdbcType.Char, 30, LineaDescrip)
            MyBase.AddParameter("@L1DescripB", OdbcType.Char, 30, L1Descrip)
            MyBase.AddParameter("@L2DescripB", OdbcType.Char, 30, L2Descrip)
            MyBase.AddParameter("@L3DescripB", OdbcType.Char, 30, L3Descrip)
            MyBase.AddParameter("@L4DescripB", OdbcType.Char, 30, L4Descrip)
            MyBase.AddParameter("@L5DescripB", OdbcType.Char, 30, L5Descrip)
            MyBase.AddParameter("@L6DescripB", OdbcType.Char, 30, L6Descrip)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@ModeloB", OdbcType.Char, 7, Modelo)
            MyBase.AddParameter("@FecRecA", OdbcType.Char, 10, FecRecA)
            MyBase.AddParameter("@FecRecB", OdbcType.Char, 10, FecRecB)
            MyBase.AddParameter("@AnioAnterior", OdbcType.Int, 8, AñoAnterior)
            MyBase.AddParameter("@IdAgrupacionb", OdbcType.Int, 8, IdAgrupacion)
            MyBase.AddParameter("@AnioAnteriorIgual", OdbcType.Int, 8, AñoAnteriorIgual)

            MyBase.AddParameter("@MInicioB", OdbcType.Char, 1, MInicio)
            MyBase.FillDataSet(usp_PpalVentas, "dwh")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalVentasDivisiones(ByVal FecIniA As String, ByVal FecIniB As String, ByVal plaza As Integer, ByVal Sucursal As Integer, ByVal Division As Integer, ByVal Depto As Integer, ByVal FamiliaDescrip As String, ByVal LineaDescrip As String, ByVal L1Descrip As String, ByVal L2Descrip As String, ByVal L3Descrip As String, ByVal L4Descrip As String, ByVal L5Descrip As String, ByVal L6Descrip As String, ByVal Marca As String, ByVal Modelo As String, ByVal FecRecA As String, ByVal FecRecB As String, ByVal AñoAnterior As Boolean, ByVal idagrupacion As Integer, ByVal AñoAnteriorIgual As Boolean, ByVal MInicio As Char) As DataSet
        'miguel perez 13JUN2013

        Try
            usp_PpalVentasDivisiones = New DataSet
            MyBase.SQL = "CALL usp_PpalVentasDivisiones(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"


            MyBase.InitializeCommand()
            MyBase.AddParameter("@FecIniA", OdbcType.Char, 10, FecIniA)
            MyBase.AddParameter("@FecIniB", OdbcType.Char, 10, FecIniB)
            MyBase.AddParameter("@PlazaB", OdbcType.Int, 16, plaza)

            MyBase.AddParameter("@SucursalB", OdbcType.Int, 16, Sucursal)
            MyBase.AddParameter("@DivisionesB", OdbcType.Int, 16, Division)
            MyBase.AddParameter("@DeptoB", OdbcType.Int, 16, Depto)
            MyBase.AddParameter("@FamiliaDescripB", OdbcType.Char, 30, FamiliaDescrip)
            MyBase.AddParameter("@LineaDescripB", OdbcType.Char, 30, LineaDescrip)
            MyBase.AddParameter("@L1DescripB", OdbcType.Char, 30, L1Descrip)
            MyBase.AddParameter("@L2DescripB", OdbcType.Char, 30, L2Descrip)
            MyBase.AddParameter("@L3DescripB", OdbcType.Char, 30, L3Descrip)
            MyBase.AddParameter("@L4DescripB", OdbcType.Char, 30, L4Descrip)
            MyBase.AddParameter("@L5DescripB", OdbcType.Char, 30, L5Descrip)
            MyBase.AddParameter("@L6DescripB", OdbcType.Char, 30, L6Descrip)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@ModeloB", OdbcType.Char, 7, Modelo)
            MyBase.AddParameter("@FecRecA", OdbcType.Char, 10, FecRecA)
            MyBase.AddParameter("@FecRecB", OdbcType.Char, 10, FecRecB)
            MyBase.AddParameter("@AnioAnterior", OdbcType.Int, 8, AñoAnterior)
            MyBase.AddParameter("@IdAgrupacionb", OdbcType.Int, 8, idagrupacion)
            MyBase.AddParameter("@AnioAnteriorIgual", OdbcType.Int, 8, AñoAnteriorIgual)


            MyBase.AddParameter("@MInicioB", OdbcType.Char, 1, MInicio)

            MyBase.FillDataSet(usp_PpalVentasDivisiones, "dwh")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalVentasDepto(ByVal FecIniA As String, ByVal FecIniB As String, ByVal Plaza As Integer, ByVal Sucursal As Integer, ByVal Division As Integer, ByVal Depto As Integer, ByVal FamiliaDescrip As String, ByVal LineaDescrip As String, ByVal L1Descrip As String, ByVal L2Descrip As String, ByVal L3Descrip As String, ByVal L4Descrip As String, ByVal L5Descrip As String, ByVal L6Descrip As String, ByVal Marca As String, ByVal Modelo As String, ByVal FecRecA As String, ByVal FecRecB As String, ByVal AñoAnterior As Boolean, ByVal IdAgrupacion As Integer, ByVal AñoAnteriorIgual As Boolean, ByVal MInicio As Char) As DataSet
        'miguel perez 13JUN2013

        Try
            usp_PpalVentasDepto = New DataSet
            MyBase.SQL = "CALL usp_PpalVentasDepto(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"


            MyBase.InitializeCommand()
            MyBase.AddParameter("@FecIniA", OdbcType.Char, 10, FecIniA)
            MyBase.AddParameter("@FecIniB", OdbcType.Char, 10, FecIniB)
            MyBase.AddParameter("@PlazaB", OdbcType.Int, 16, Plaza)
            MyBase.AddParameter("@SucursalB", OdbcType.Int, 16, Sucursal)
            MyBase.AddParameter("@DivisionesB", OdbcType.Int, 16, Division)
            MyBase.AddParameter("@DeptoB", OdbcType.Int, 16, Depto)
            MyBase.AddParameter("@FamiliaDescripB", OdbcType.Char, 30, FamiliaDescrip)
            MyBase.AddParameter("@LineaDescripB", OdbcType.Char, 30, LineaDescrip)
            MyBase.AddParameter("@L1DescripB", OdbcType.Char, 30, L1Descrip)
            MyBase.AddParameter("@L2DescripB", OdbcType.Char, 30, L2Descrip)
            MyBase.AddParameter("@L3DescripB", OdbcType.Char, 30, L3Descrip)
            MyBase.AddParameter("@L4DescripB", OdbcType.Char, 30, L4Descrip)
            MyBase.AddParameter("@L5DescripB", OdbcType.Char, 30, L5Descrip)
            MyBase.AddParameter("@L6DescripB", OdbcType.Char, 30, L6Descrip)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@ModeloB", OdbcType.Char, 7, Modelo)
            MyBase.AddParameter("@FecRecA", OdbcType.Char, 10, FecRecA)
            MyBase.AddParameter("@FecRecB", OdbcType.Char, 10, FecRecB)
            MyBase.AddParameter("@AnioAnterior", OdbcType.Int, 8, AñoAnterior)
            MyBase.AddParameter("@IdAgrupacionb", OdbcType.Int, 8, IdAgrupacion)
            MyBase.AddParameter("@AnioAnteriorIgual", OdbcType.Int, 8, AñoAnteriorIgual)

            MyBase.AddParameter("@MInicioB", OdbcType.Char, 1, MInicio)

            MyBase.FillDataSet(usp_PpalVentasDepto, "dwh")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalVentasFamilia(ByVal FecIniA As String, ByVal FecIniB As String, ByVal Plaza As Integer, ByVal Sucursal As Integer, ByVal Division As Integer, ByVal Depto As Integer, ByVal FamiliaDescrip As String, ByVal LineaDescrip As String, ByVal L1Descrip As String, ByVal L2Descrip As String, ByVal L3Descrip As String, ByVal L4Descrip As String, ByVal L5Descrip As String, ByVal L6Descrip As String, ByVal Marca As String, ByVal Modelo As String, ByVal FecRecA As String, ByVal FecRecB As String, ByVal AñoAnterior As Boolean, ByVal IdAgrupacion As Integer, ByVal AñoAnteriorIgual As Boolean, ByVal MInicio As String) As DataSet
        'miguel perez 13JUN2013

        Try
            usp_PpalVentasFamilia = New DataSet
            MyBase.SQL = "CALL usp_PpalVentasFamilia(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"


            MyBase.InitializeCommand()
            MyBase.AddParameter("@FecIniA", OdbcType.Char, 10, FecIniA)
            MyBase.AddParameter("@FecIniB", OdbcType.Char, 10, FecIniB)
            MyBase.AddParameter("@PlazaB", OdbcType.Int, 16, Plaza)
            MyBase.AddParameter("@SucursalB", OdbcType.Int, 16, Sucursal)
            MyBase.AddParameter("@DivisionesB", OdbcType.Int, 16, Division)
            MyBase.AddParameter("@DeptoB", OdbcType.Int, 16, Depto)
            MyBase.AddParameter("@FamiliaDescripB", OdbcType.Char, 30, FamiliaDescrip)
            MyBase.AddParameter("@LineaDescripB", OdbcType.Char, 30, LineaDescrip)
            MyBase.AddParameter("@L1DescripB", OdbcType.Char, 30, L1Descrip)
            MyBase.AddParameter("@L2DescripB", OdbcType.Char, 30, L2Descrip)
            MyBase.AddParameter("@L3DescripB", OdbcType.Char, 30, L3Descrip)
            MyBase.AddParameter("@L4DescripB", OdbcType.Char, 30, L4Descrip)
            MyBase.AddParameter("@L5DescripB", OdbcType.Char, 30, L5Descrip)
            MyBase.AddParameter("@L6DescripB", OdbcType.Char, 30, L6Descrip)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@ModeloB", OdbcType.Char, 7, Modelo)
            MyBase.AddParameter("@FecRecA", OdbcType.Char, 10, FecRecA)
            MyBase.AddParameter("@FecRecB", OdbcType.Char, 10, FecRecB)
            MyBase.AddParameter("@AnioAnterior", OdbcType.Int, 8, AñoAnterior)
            MyBase.AddParameter("@IdAgrupacionb", OdbcType.Int, 8, IdAgrupacion)
            MyBase.AddParameter("@AnioAnteriorIgual", OdbcType.Int, 8, AñoAnteriorIgual)
            MyBase.AddParameter("@MInicioB", OdbcType.Char, 1, MInicio)

            MyBase.FillDataSet(usp_PpalVentasFamilia, "dwh")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalVentasLinea(ByVal FecIniA As String, ByVal FecIniB As String, ByVal Plaza As Integer, ByVal Sucursal As Integer, ByVal Division As Integer, ByVal Depto As Integer, ByVal FamiliaDescrip As String, ByVal LineaDescrip As String, ByVal L1Descrip As String, ByVal L2Descrip As String, ByVal L3Descrip As String, ByVal L4Descrip As String, ByVal L5Descrip As String, ByVal L6Descrip As String, ByVal Marca As String, ByVal Modelo As String, ByVal FecRecA As String, ByVal FecRecB As String, ByVal AñoAnterior As Boolean, ByVal IdAgrupacion As Integer, ByVal AñoAnteriorIgual As Boolean, ByVal MInicio As String) As DataSet
        'miguel perez 13JUN2013

        Try
            usp_PpalVentasLinea = New DataSet
            MyBase.SQL = "CALL usp_PpalVentasLinea(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"


            MyBase.InitializeCommand()
            MyBase.AddParameter("@FecIniA", OdbcType.Char, 10, FecIniA)
            MyBase.AddParameter("@FecIniB", OdbcType.Char, 10, FecIniB)
            MyBase.AddParameter("@PlazaB", OdbcType.Int, 16, Plaza)
            MyBase.AddParameter("@SucursalB", OdbcType.Int, 16, Sucursal)
            MyBase.AddParameter("@DivisionesB", OdbcType.Int, 16, Division)
            MyBase.AddParameter("@DeptoB", OdbcType.Int, 16, Depto)
            MyBase.AddParameter("@FamiliaDescripB", OdbcType.Char, 30, FamiliaDescrip)
            MyBase.AddParameter("@LineaDescripB", OdbcType.Char, 30, LineaDescrip)
            MyBase.AddParameter("@L1DescripB", OdbcType.Char, 30, L1Descrip)
            MyBase.AddParameter("@L2DescripB", OdbcType.Char, 30, L2Descrip)
            MyBase.AddParameter("@L3DescripB", OdbcType.Char, 30, L3Descrip)
            MyBase.AddParameter("@L4DescripB", OdbcType.Char, 30, L4Descrip)
            MyBase.AddParameter("@L5DescripB", OdbcType.Char, 30, L5Descrip)
            MyBase.AddParameter("@L6DescripB", OdbcType.Char, 30, L6Descrip)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@ModeloB", OdbcType.Char, 7, Modelo)
            MyBase.AddParameter("@FecRecA", OdbcType.Char, 10, FecRecA)
            MyBase.AddParameter("@FecRecB", OdbcType.Char, 10, FecRecB)
            MyBase.AddParameter("@AnioAnterior", OdbcType.Int, 8, AñoAnterior)
            MyBase.AddParameter("@IdAgrupacionb", OdbcType.Int, 8, IdAgrupacion)
            MyBase.AddParameter("@AnioAnteriorIgual", OdbcType.Int, 8, AñoAnteriorIgual)
            MyBase.AddParameter("@MInicioB", OdbcType.Char, 1, MInicio)



            MyBase.FillDataSet(usp_PpalVentasLinea, "dwh")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalVentasL1(ByVal FecIniA As String, ByVal FecIniB As String, ByVal Plaza As Integer, ByVal Sucursal As Integer, ByVal Division As Integer, ByVal Depto As Integer, ByVal FamiliaDescrip As String, ByVal LineaDescrip As String, ByVal L1Descrip As String, ByVal L2Descrip As String, ByVal L3Descrip As String, ByVal L4Descrip As String, ByVal L5Descrip As String, ByVal L6Descrip As String, ByVal Marca As String, ByVal Modelo As String, ByVal FecRecA As String, ByVal FecRecB As String, ByVal AñoAnterior As Boolean, ByVal IdAgrupacion As Integer, ByVal AñoAnteriorIgual As Boolean, ByVal MInicio As String) As DataSet
        'miguel perez 13JUN2013

        Try
            usp_PpalVentasL1 = New DataSet
            MyBase.SQL = "CALL usp_PpalVentasL1(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"


            MyBase.InitializeCommand()
            MyBase.AddParameter("@FecIniA", OdbcType.Char, 10, FecIniA)
            MyBase.AddParameter("@FecIniB", OdbcType.Char, 10, FecIniB)
            MyBase.AddParameter("@PlazaB", OdbcType.Int, 16, Plaza)
            MyBase.AddParameter("@SucursalB", OdbcType.Int, 16, Sucursal)
            MyBase.AddParameter("@DivisionesB", OdbcType.Int, 16, Division)
            MyBase.AddParameter("@DeptoB", OdbcType.Int, 16, Depto)
            MyBase.AddParameter("@FamiliaDescripB", OdbcType.Char, 30, FamiliaDescrip)
            MyBase.AddParameter("@LineaDescripB", OdbcType.Char, 30, LineaDescrip)
            MyBase.AddParameter("@L1DescripB", OdbcType.Char, 30, L1Descrip)
            MyBase.AddParameter("@L2DescripB", OdbcType.Char, 30, L2Descrip)
            MyBase.AddParameter("@L3DescripB", OdbcType.Char, 30, L3Descrip)
            MyBase.AddParameter("@L4DescripB", OdbcType.Char, 30, L4Descrip)
            MyBase.AddParameter("@L5DescripB", OdbcType.Char, 30, L5Descrip)
            MyBase.AddParameter("@L6DescripB", OdbcType.Char, 30, L6Descrip)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@ModeloB", OdbcType.Char, 7, Modelo)
            MyBase.AddParameter("@FecRecA", OdbcType.Char, 10, FecRecA)
            MyBase.AddParameter("@FecRecB", OdbcType.Char, 10, FecRecB)
            MyBase.AddParameter("@AnioAnterior", OdbcType.Int, 8, AñoAnterior)
            MyBase.AddParameter("@IdAgrupacionb", OdbcType.Int, 8, IdAgrupacion)
            MyBase.AddParameter("@AnioAnteriorIgual", OdbcType.Int, 8, AñoAnteriorIgual)

            MyBase.AddParameter("@MInicioB", OdbcType.Char, 1, MInicio)

            MyBase.FillDataSet(usp_PpalVentasL1, "dwh")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalVentasL2(ByVal FecIniA As String, ByVal FecIniB As String, ByVal Plaza As Integer, ByVal Sucursal As Integer, ByVal Division As Integer, ByVal Depto As Integer, ByVal FamiliaDescrip As String, ByVal LineaDescrip As String, ByVal L1Descrip As String, ByVal L2Descrip As String, ByVal L3Descrip As String, ByVal L4Descrip As String, ByVal L5Descrip As String, ByVal L6Descrip As String, ByVal Marca As String, ByVal Modelo As String, ByVal FecRecA As String, ByVal FecRecB As String, ByVal AñoAnterior As Boolean, ByVal IdAgrupacion As Integer, ByVal AñoAnteriorIgual As Boolean, ByVal MInicio As String) As DataSet
        'miguel perez 13JUN2013

        Try
            usp_PpalVentasL2 = New DataSet
            MyBase.SQL = "CALL usp_PpalVentasL2(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"


            MyBase.InitializeCommand()
            MyBase.AddParameter("@FecIniA", OdbcType.Char, 10, FecIniA)
            MyBase.AddParameter("@FecIniB", OdbcType.Char, 10, FecIniB)
            MyBase.AddParameter("@PlazaB", OdbcType.Int, 16, Plaza)
            MyBase.AddParameter("@SucursalB", OdbcType.Int, 16, Sucursal)
            MyBase.AddParameter("@DivisionesB", OdbcType.Int, 16, Division)
            MyBase.AddParameter("@DeptoB", OdbcType.Int, 16, Depto)
            MyBase.AddParameter("@FamiliaDescripB", OdbcType.Char, 30, FamiliaDescrip)
            MyBase.AddParameter("@LineaDescripB", OdbcType.Char, 30, LineaDescrip)
            MyBase.AddParameter("@L1DescripB", OdbcType.Char, 30, L1Descrip)
            MyBase.AddParameter("@L2DescripB", OdbcType.Char, 30, L2Descrip)
            MyBase.AddParameter("@L3DescripB", OdbcType.Char, 30, L3Descrip)
            MyBase.AddParameter("@L4DescripB", OdbcType.Char, 30, L4Descrip)
            MyBase.AddParameter("@L5DescripB", OdbcType.Char, 30, L5Descrip)
            MyBase.AddParameter("@L6DescripB", OdbcType.Char, 30, L6Descrip)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@ModeloB", OdbcType.Char, 7, Modelo)
            MyBase.AddParameter("@FecRecA", OdbcType.Char, 10, FecRecA)
            MyBase.AddParameter("@FecRecB", OdbcType.Char, 10, FecRecB)
            MyBase.AddParameter("@AnioAnterior", OdbcType.Int, 8, AñoAnterior)
            MyBase.AddParameter("@IdAgrupacionb", OdbcType.Int, 8, IdAgrupacion)
            MyBase.AddParameter("@AnioAnteriorIgual", OdbcType.Int, 8, AñoAnteriorIgual)

            MyBase.AddParameter("@MInicioB", OdbcType.Char, 1, MInicio)

            MyBase.FillDataSet(usp_PpalVentasL2, "dwh")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalVentasL3(ByVal FecIniA As String, ByVal FecIniB As String, ByVal Plaza As Integer, ByVal Sucursal As Integer, ByVal Division As Integer, ByVal Depto As Integer, ByVal FamiliaDescrip As String, ByVal LineaDescrip As String, ByVal L1Descrip As String, ByVal L2Descrip As String, ByVal L3Descrip As String, ByVal L4Descrip As String, ByVal L5Descrip As String, ByVal L6Descrip As String, ByVal Marca As String, ByVal Modelo As String, ByVal FecRecA As String, ByVal FecRecB As String, ByVal AñoAnterior As Boolean, ByVal IdAgrupacion As Integer, ByVal AñoAnteriorIgual As Boolean, ByVal MInicio As String) As DataSet
        'miguel perez 13JUN2013

        Try
            usp_PpalVentasL3 = New DataSet
            MyBase.SQL = "CALL usp_PpalVentasL3(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"


            MyBase.InitializeCommand()
            MyBase.AddParameter("@FecIniA", OdbcType.Char, 10, FecIniA)
            MyBase.AddParameter("@FecIniB", OdbcType.Char, 10, FecIniB)
            MyBase.AddParameter("@PlazaB", OdbcType.Int, 16, Plaza)
            MyBase.AddParameter("@SucursalB", OdbcType.Int, 16, Sucursal)
            MyBase.AddParameter("@DivisionesB", OdbcType.Int, 16, Division)
            MyBase.AddParameter("@DeptoB", OdbcType.Int, 16, Depto)
            MyBase.AddParameter("@FamiliaDescripB", OdbcType.Char, 30, FamiliaDescrip)
            MyBase.AddParameter("@LineaDescripB", OdbcType.Char, 30, LineaDescrip)
            MyBase.AddParameter("@L1DescripB", OdbcType.Char, 30, L1Descrip)
            MyBase.AddParameter("@L2DescripB", OdbcType.Char, 30, L2Descrip)
            MyBase.AddParameter("@L3DescripB", OdbcType.Char, 30, L3Descrip)
            MyBase.AddParameter("@L4DescripB", OdbcType.Char, 30, L4Descrip)
            MyBase.AddParameter("@L5DescripB", OdbcType.Char, 30, L5Descrip)
            MyBase.AddParameter("@L6DescripB", OdbcType.Char, 30, L6Descrip)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@ModeloB", OdbcType.Char, 7, Modelo)
            MyBase.AddParameter("@FecRecA", OdbcType.Char, 10, FecRecA)
            MyBase.AddParameter("@FecRecB", OdbcType.Char, 10, FecRecB)
            MyBase.AddParameter("@AnioAnterior", OdbcType.Int, 8, AñoAnterior)
            MyBase.AddParameter("@IdAgrupacionb", OdbcType.Int, 8, IdAgrupacion)
            MyBase.AddParameter("@AnioAnteriorIgual", OdbcType.Int, 8, AñoAnteriorIgual)

            MyBase.AddParameter("@MInicioB", OdbcType.Char, 1, MInicio)
            MyBase.FillDataSet(usp_PpalVentasL3, "dwh")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalVentasL4(ByVal FecIniA As String, ByVal FecIniB As String, ByVal Plaza As Integer, ByVal Sucursal As Integer, ByVal Division As Integer, ByVal Depto As Integer, ByVal FamiliaDescrip As String, ByVal LineaDescrip As String, ByVal L1Descrip As String, ByVal L2Descrip As String, ByVal L3Descrip As String, ByVal L4Descrip As String, ByVal L5Descrip As String, ByVal L6Descrip As String, ByVal Marca As String, ByVal Modelo As String, ByVal FecRecA As String, ByVal FecRecB As String, ByVal AñoAnterior As Boolean, ByVal IdAgrupacion As Integer, ByVal AñoAnteriorIgual As Boolean, ByVal MInicio As String) As DataSet
        'miguel perez 13JUN2013

        Try
            usp_PpalVentasL4 = New DataSet
            MyBase.SQL = "CALL usp_PpalVentasL4(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@FecIniA", OdbcType.Char, 10, FecIniA)
            MyBase.AddParameter("@FecIniB", OdbcType.Char, 10, FecIniB)
            MyBase.AddParameter("@PlazaB", OdbcType.Int, 16, Plaza)
            MyBase.AddParameter("@SucursalB", OdbcType.Int, 16, Sucursal)
            MyBase.AddParameter("@DivisionesB", OdbcType.Int, 16, Division)
            MyBase.AddParameter("@DeptoB", OdbcType.Int, 16, Depto)
            MyBase.AddParameter("@FamiliaDescripB", OdbcType.Char, 30, FamiliaDescrip)
            MyBase.AddParameter("@LineaDescripB", OdbcType.Char, 30, LineaDescrip)
            MyBase.AddParameter("@L1DescripB", OdbcType.Char, 30, L1Descrip)
            MyBase.AddParameter("@L2DescripB", OdbcType.Char, 30, L2Descrip)
            MyBase.AddParameter("@L3DescripB", OdbcType.Char, 30, L3Descrip)
            MyBase.AddParameter("@L4DescripB", OdbcType.Char, 30, L4Descrip)
            MyBase.AddParameter("@L5DescripB", OdbcType.Char, 30, L5Descrip)
            MyBase.AddParameter("@L6DescripB", OdbcType.Char, 30, L6Descrip)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@ModeloB", OdbcType.Char, 7, Modelo)
            MyBase.AddParameter("@FecRecA", OdbcType.Char, 10, FecRecA)
            MyBase.AddParameter("@FecRecB", OdbcType.Char, 10, FecRecB)
            MyBase.AddParameter("@AnioAnterior", OdbcType.Int, 8, AñoAnterior)
            MyBase.AddParameter("@IdAgrupacionb", OdbcType.Int, 8, IdAgrupacion)
            MyBase.AddParameter("@AnioAnteriorIgual", OdbcType.Int, 8, AñoAnteriorIgual)

            MyBase.AddParameter("@MInicioB", OdbcType.Char, 1, MInicio)


            MyBase.FillDataSet(usp_PpalVentasL4, "dwh")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalVentasL5(ByVal FecIniA As String, ByVal FecIniB As String, ByVal Plaza As Integer, ByVal Sucursal As Integer, ByVal Division As Integer, ByVal Depto As Integer, ByVal FamiliaDescrip As String, ByVal LineaDescrip As String, ByVal L1Descrip As String, ByVal L2Descrip As String, ByVal L3Descrip As String, ByVal L4Descrip As String, ByVal L5Descrip As String, ByVal L6Descrip As String, ByVal Marca As String, ByVal Modelo As String, ByVal FecRecA As String, ByVal FecRecB As String, ByVal AñoAnterior As Boolean, ByVal IdAgrupacion As Integer, ByVal AñoAnteriorIgual As Boolean, ByVal MInicio As String) As DataSet
        'miguel perez 13JUN2013

        Try
            usp_PpalVentasL5 = New DataSet
            MyBase.SQL = "CALL usp_PpalVentasL5(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"


            MyBase.InitializeCommand()
            MyBase.AddParameter("@FecIniA", OdbcType.Char, 10, FecIniA)
            MyBase.AddParameter("@FecIniB", OdbcType.Char, 10, FecIniB)
            MyBase.AddParameter("@PlazaB", OdbcType.Int, 16, Plaza)
            MyBase.AddParameter("@SucursalB", OdbcType.Int, 16, Sucursal)
            MyBase.AddParameter("@DivisionesB", OdbcType.Int, 16, Division)
            MyBase.AddParameter("@DeptoB", OdbcType.Int, 16, Depto)
            MyBase.AddParameter("@FamiliaDescripB", OdbcType.Char, 30, FamiliaDescrip)
            MyBase.AddParameter("@LineaDescripB", OdbcType.Char, 30, LineaDescrip)
            MyBase.AddParameter("@L1DescripB", OdbcType.Char, 30, L1Descrip)
            MyBase.AddParameter("@L2DescripB", OdbcType.Char, 30, L2Descrip)
            MyBase.AddParameter("@L3DescripB", OdbcType.Char, 30, L3Descrip)
            MyBase.AddParameter("@L4DescripB", OdbcType.Char, 30, L4Descrip)
            MyBase.AddParameter("@L5DescripB", OdbcType.Char, 30, L5Descrip)
            MyBase.AddParameter("@L6DescripB", OdbcType.Char, 30, L6Descrip)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@ModeloB", OdbcType.Char, 7, Modelo)
            MyBase.AddParameter("@FecRecA", OdbcType.Char, 10, FecRecA)
            MyBase.AddParameter("@FecRecB", OdbcType.Char, 10, FecRecB)
            MyBase.AddParameter("@AnioAnterior", OdbcType.Int, 8, AñoAnterior)
            MyBase.AddParameter("@IdAgrupacionb", OdbcType.Int, 8, IdAgrupacion)
            MyBase.AddParameter("@AnioAnteriorIgual", OdbcType.Int, 8, AñoAnteriorIgual)
            MyBase.AddParameter("@MInicioB", OdbcType.Char, 1, MInicio)
            MyBase.FillDataSet(usp_PpalVentasL5, "dwh")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalVentasL6(ByVal FecIniA As String, ByVal FecIniB As String, ByVal Plaza As Integer, ByVal Sucursal As Integer, ByVal Division As Integer, ByVal Depto As Integer, ByVal FamiliaDescrip As String, ByVal LineaDescrip As String, ByVal L1Descrip As String, ByVal L2Descrip As String, ByVal L3Descrip As String, ByVal L4Descrip As String, ByVal L5Descrip As String, ByVal L6Descrip As String, ByVal Marca As String, ByVal Modelo As String, ByVal FecRecA As String, ByVal FecRecB As String, ByVal AñoAnterior As Boolean, ByVal IdAgrupacion As Integer, ByVal AñoAnteriorIgual As Boolean, ByVal MInicio As String) As DataSet
        'miguel perez 13JUN2013  

        Try
            usp_PpalVentasL6 = New DataSet
            MyBase.SQL = "CALL usp_PpalVentasL6(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"


            MyBase.InitializeCommand()
            MyBase.AddParameter("@FecIniA", OdbcType.Char, 10, FecIniA)
            MyBase.AddParameter("@FecIniB", OdbcType.Char, 10, FecIniB)
            MyBase.AddParameter("@PlazaB", OdbcType.Int, 16, Plaza)
            MyBase.AddParameter("@SucursalB", OdbcType.Int, 16, Sucursal)
            MyBase.AddParameter("@DivisionesB", OdbcType.Int, 16, Division)
            MyBase.AddParameter("@DeptoB", OdbcType.Int, 16, Depto)
            MyBase.AddParameter("@FamiliaDescripB", OdbcType.Char, 30, FamiliaDescrip)
            MyBase.AddParameter("@LineaDescripB", OdbcType.Char, 30, LineaDescrip)
            MyBase.AddParameter("@L1DescripB", OdbcType.Char, 30, L1Descrip)
            MyBase.AddParameter("@L2DescripB", OdbcType.Char, 30, L2Descrip)
            MyBase.AddParameter("@L3DescripB", OdbcType.Char, 30, L3Descrip)
            MyBase.AddParameter("@L4DescripB", OdbcType.Char, 30, L4Descrip)
            MyBase.AddParameter("@L5DescripB", OdbcType.Char, 30, L5Descrip)
            MyBase.AddParameter("@L6DescripB", OdbcType.Char, 30, L6Descrip)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@ModeloB", OdbcType.Char, 7, Modelo)
            MyBase.AddParameter("@FecRecA", OdbcType.Char, 10, FecRecA)
            MyBase.AddParameter("@FecRecB", OdbcType.Char, 10, FecRecB)
            MyBase.AddParameter("@AnioAnterior", OdbcType.Int, 8, AñoAnterior)
            MyBase.AddParameter("@IdAgrupacionb", OdbcType.Int, 8, IdAgrupacion)
            MyBase.AddParameter("@AnioAnteriorIgual", OdbcType.Int, 8, AñoAnteriorIgual)
            MyBase.AddParameter("@MInicioB", OdbcType.Char, 1, MInicio)
            MyBase.FillDataSet(usp_PpalVentasL6, "dwh")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalVentasMarca(ByVal FecIniA As String, ByVal FecIniB As String, ByVal Plaza As Integer, ByVal Sucursal As Integer, ByVal Division As Integer, ByVal Depto As Integer, ByVal FamiliaDescrip As String, ByVal LineaDescrip As String, ByVal L1Descrip As String, ByVal L2Descrip As String, ByVal L3Descrip As String, ByVal L4Descrip As String, ByVal L5Descrip As String, ByVal L6Descrip As String, ByVal Marca As String, ByVal Modelo As String, ByVal FecRecA As String, ByVal FecRecB As String, ByVal AñoAnterior As Boolean, ByVal IdAgrupacion As Integer, ByVal AñoAnteriorIgual As Boolean, ByVal MInicio As String) As DataSet
        'miguel perez 13JUN2013

        Try
            usp_PpalVentasMarca = New DataSet
            MyBase.SQL = "CALL usp_PpalVentasMarca(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"


            MyBase.InitializeCommand()
            MyBase.AddParameter("@FecIniA", OdbcType.Char, 10, FecIniA)
            MyBase.AddParameter("@FecIniB", OdbcType.Char, 10, FecIniB)
            MyBase.AddParameter("@PlazaB", OdbcType.Int, 16, Plaza)
            MyBase.AddParameter("@SucursalB", OdbcType.Int, 16, Sucursal)
            MyBase.AddParameter("@DivisionesB", OdbcType.Int, 16, Division)
            MyBase.AddParameter("@DeptoB", OdbcType.Int, 16, Depto)
            MyBase.AddParameter("@FamiliaDescripB", OdbcType.Char, 30, FamiliaDescrip)
            MyBase.AddParameter("@LineaDescripB", OdbcType.Char, 30, LineaDescrip)
            MyBase.AddParameter("@L1DescripB", OdbcType.Char, 30, L1Descrip)
            MyBase.AddParameter("@L2DescripB", OdbcType.Char, 30, L2Descrip)
            MyBase.AddParameter("@L3DescripB", OdbcType.Char, 30, L3Descrip)
            MyBase.AddParameter("@L4DescripB", OdbcType.Char, 30, L4Descrip)
            MyBase.AddParameter("@L5DescripB", OdbcType.Char, 30, L5Descrip)
            MyBase.AddParameter("@L6DescripB", OdbcType.Char, 30, L6Descrip)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@ModeloB", OdbcType.Char, 7, Modelo)
            MyBase.AddParameter("@FecRecA", OdbcType.Char, 10, FecRecA)
            MyBase.AddParameter("@FecRecB", OdbcType.Char, 10, FecRecB)
            MyBase.AddParameter("@AnioAnterior", OdbcType.Int, 8, AñoAnterior)
            MyBase.AddParameter("@IdAgrupacionb", OdbcType.Int, 8, IdAgrupacion)
            MyBase.AddParameter("@AnioAnteriorIgual", OdbcType.Int, 8, AñoAnteriorIgual)
            MyBase.AddParameter("@MInicioB", OdbcType.Char, 1, MInicio)
            MyBase.FillDataSet(usp_PpalVentasMarca, "dwh")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalVentasMarcaModelo(ByVal FecIniA As String, ByVal FecIniB As String, ByVal Plaza As Integer, ByVal Sucursal As Integer, ByVal Division As Integer, ByVal Depto As Integer, ByVal FamiliaDescrip As String, ByVal LineaDescrip As String, ByVal L1Descrip As String, ByVal L2Descrip As String, ByVal L3Descrip As String, ByVal L4Descrip As String, ByVal L5Descrip As String, ByVal L6Descrip As String, ByVal Marca As String, ByVal Modelo As String, ByVal FecRecA As String, ByVal FecRecB As String, ByVal AñoAnterior As Boolean, ByVal Miles As Integer, ByVal IdAgrupacion As Integer, ByVal AñoAnteriorIgual As Boolean, ByVal MInicio As String) As DataSet
        'miguel perez 13JUN2013

        Try
            usp_PpalVentasMarcaModelo = New DataSet
            MyBase.SQL = "CALL usp_PpalVentasMarcaModelo(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"


            MyBase.InitializeCommand()
            MyBase.AddParameter("@FecIniA", OdbcType.Char, 10, FecIniA)
            MyBase.AddParameter("@FecIniB", OdbcType.Char, 10, FecIniB)
            MyBase.AddParameter("@PlazaB", OdbcType.Int, 16, Plaza)
            MyBase.AddParameter("@SucursalB", OdbcType.Int, 16, Sucursal)
            MyBase.AddParameter("@DivisionesB", OdbcType.Int, 16, Division)
            MyBase.AddParameter("@DeptoB", OdbcType.Int, 16, Depto)
            MyBase.AddParameter("@FamiliaDescripB", OdbcType.Char, 30, FamiliaDescrip)
            MyBase.AddParameter("@LineaDescripB", OdbcType.Char, 30, LineaDescrip)
            MyBase.AddParameter("@L1DescripB", OdbcType.Char, 30, L1Descrip)
            MyBase.AddParameter("@L2DescripB", OdbcType.Char, 30, L2Descrip)
            MyBase.AddParameter("@L3DescripB", OdbcType.Char, 30, L3Descrip)
            MyBase.AddParameter("@L4DescripB", OdbcType.Char, 30, L4Descrip)
            MyBase.AddParameter("@L5DescripB", OdbcType.Char, 30, L5Descrip)
            MyBase.AddParameter("@L6DescripB", OdbcType.Char, 30, L6Descrip)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@ModeloB", OdbcType.Char, 7, Modelo)
            MyBase.AddParameter("@FecRecA", OdbcType.Char, 10, FecRecA)
            MyBase.AddParameter("@FecRecB", OdbcType.Char, 10, FecRecB)
            MyBase.AddParameter("@AnioAnterior", OdbcType.Int, 8, AñoAnterior)
            MyBase.AddParameter("@Miles", OdbcType.Int, 4, Miles)
            MyBase.AddParameter("@IdAgrupacionb", OdbcType.Int, 8, IdAgrupacion)
            MyBase.AddParameter("@AnioAnteriorIgual", OdbcType.Int, 8, AñoAnteriorIgual)

            MyBase.AddParameter("@MInicioB", OdbcType.Char, 1, MInicio)

            MyBase.FillDataSet(usp_PpalVentasMarcaModelo, "dwh")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerPlaza(ByVal Plaza As String) As DataSet
        'mreyes 14/Octubre/2015 12:18 p.m.
        Try
            usp_TraerPlaza = New DataSet
            MyBase.SQL = "CALL usp_TraerPlaza(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@PlazaB", OdbcType.Char, 2, Plaza)

            MyBase.FillDataSet(usp_TraerPlaza, "dwh")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerSucursal(ByVal Sucursal As String) As DataSet
        'miguel perez 13JUN2013
        Try
            usp_TraerSucursal = New DataSet
            MyBase.SQL = "CALL usp_TraerSucursal(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)

            MyBase.FillDataSet(usp_TraerSucursal, "dwh")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ActualizarSucursal(ByVal Sucursal As String, ByVal Visible As String) As Boolean
        'miguel pérez 05/Diciembre/2012 12:13 p.m.
        Try
            MyBase.SQL = "CALL usp_ActualizarSucursal(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@OrdeCompB", OdbcType.Char, 1, Visible)
            usp_ActualizarSucursal = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_GeneraVentasBase(ByVal FecIni As String, ByVal FecFin As String, ByVal idUsuario As Integer) As Boolean
        'miguel pérez 05/Diciembre/2012 12:13 p.m.
        Try
            MyBase.SQL = "CALL usp_GeneraVentasBase(?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@fecini", OdbcType.Char, 10, FecIni)
            MyBase.AddParameter("@fwcfin", OdbcType.Char, 10, FecFin)
            MyBase.AddParameter("@idusuariob", OdbcType.Int, 8, idUsuario)
            usp_GeneraVentasBase = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_GeneraTxtCoqueta(ByVal Sucursal As String, ByVal FechaIni As Date, ByVal FechaFin As Date) As DataSet
        'mreyes 25/Abril/2016   10:27 a.m.
        Try
            usp_GeneraTxtCoqueta = New DataSet
            MyBase.SQL = "CALL usp_GeneraTxtCoqueta(?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@FechaIniB", OdbcType.Date, 10, FechaIni)
            MyBase.AddParameter("@FechaFinB", OdbcType.Date, 10, FechaFin)

            MyBase.FillDataSet(usp_GeneraTxtCoqueta, "dwh")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_GeneraTxtOzono(ByVal FechaIni As Date, ByVal FechaFin As Date) As DataSet
        'Tony Garcia - 21/Enero/2014
        Try
            usp_GeneraTxtOzono = New DataSet
            MyBase.SQL = "CALL usp_GeneraTxtOzono(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@FechaIniB", OdbcType.Date, 10, FechaIni)
            MyBase.AddParameter("@FechaFinB", OdbcType.Date, 10, FechaFin)

            MyBase.FillDataSet(usp_GeneraTxtOzono, "dwh")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerPedidoTrac(ByVal Sucursal As String, ByVal OrdeComp As String) As DataSet
        'mreyes 19/Abril/2016   05:58 p.m.
        Try
            usp_TraerPedidoTrac = New DataSet
            MyBase.SQL = "CALL usp_TraerPedidoTrac(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@OrdeCompB", OdbcType.Char, 6, OrdeComp)

            MyBase.FillDataSet(usp_TraerPedidoTrac, "dwh")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
