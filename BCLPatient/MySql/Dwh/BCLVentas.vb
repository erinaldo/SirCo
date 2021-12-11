Public Class BCLVentas
    'mreyes 18/Octubre/2012 02:06 p.m.

    Implements IDisposable
    Private objDALAntiInvent As DAL.DALVentas
    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALAntiInvent = New DAL.DALVentas(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALAntiInvent.Dispose()
            objDALAntiInvent = Nothing
            ' TODO: free shared unmanaged resources
        End If
        Me.disposedValue = True
    End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region
#Region " Public Section Functions "
    Public Function usp_PpalVentasPlaza(ByVal FecIniA As String, ByVal FecIniB As String, ByVal Plaza As Integer, ByVal Sucursal As Integer, ByVal Division As Integer, ByVal Depto As Integer, ByVal FamiliaDescrip As String, ByVal LineaDescrip As String, ByVal L1Descrip As String, ByVal L2Descrip As String, ByVal L3Descrip As String, ByVal L4Descrip As String, ByVal L5Descrip As String, ByVal L6Descrip As String, ByVal Marca As String, ByVal Modelo As String, ByVal FecRecA As String, ByVal FecRecB As String, ByVal AñoAnterior As Boolean, ByVal IdAgrupacion As Integer, ByVal AñoAnteriorIgual As Boolean, ByVal MInicio As String) As DataSet
        'mreyes 13/Octubre/2015 12:08 p.m.
        Try
            usp_PpalVentasPlaza = objDALAntiInvent.usp_PpalVentasPlaza(FecIniA, FecIniB, Plaza, Sucursal, Division, Depto, FamiliaDescrip, LineaDescrip, L1Descrip, L2Descrip, L3Descrip, L4Descrip, L5Descrip, L6Descrip, Marca, Modelo, FecRecA, FecRecB, AñoAnterior, IdAgrupacion, AñoAnteriorIgual, MInicio)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function



    Public Function usp_PpalVentas(ByVal FecIniA As String, ByVal FecIniB As String, ByVal Plaza As Integer, ByVal Sucursal As Integer, ByVal Division As Integer, ByVal Depto As Integer, ByVal FamiliaDescrip As String, ByVal LineaDescrip As String, ByVal L1Descrip As String, ByVal L2Descrip As String, ByVal L3Descrip As String, ByVal L4Descrip As String, ByVal L5Descrip As String, ByVal L6Descrip As String, ByVal Marca As String, ByVal Modelo As String, ByVal FecRecA As String, ByVal FecRecB As String, ByVal AñoAnterior As Boolean, ByVal IdAgrupacion As Integer, ByVal AñoAnteriorIgual As Boolean, ByVal MInicio As String) As DataSet
        'mreyes 18/Octubre/2012 04:08 p.m.
        Try
            usp_PpalVentas = objDALAntiInvent.usp_PpalVentas(FecIniA, FecIniB, Plaza, Sucursal, Division, Depto, FamiliaDescrip, LineaDescrip, L1Descrip, L2Descrip, L3Descrip, L4Descrip, L5Descrip, L6Descrip, Marca, Modelo, FecRecA, FecRecB, AñoAnterior, IdAgrupacion, AñoAnteriorIgual, MInicio)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_PpalVentasDivisiones(ByVal FecIniA As String, ByVal FecIniB As String, ByVal Plaza As Integer, ByVal Sucursal As Integer, ByVal Division As Integer, ByVal Depto As Integer, ByVal FamiliaDescrip As String, ByVal LineaDescrip As String, ByVal L1Descrip As String, ByVal L2Descrip As String, ByVal L3Descrip As String, ByVal L4Descrip As String, ByVal L5Descrip As String, ByVal L6Descrip As String, ByVal Marca As String, ByVal Modelo As String, ByVal FecRecA As String, ByVal FecRecB As String, ByVal AñoAnterior As Boolean, ByVal IdAgrupacion As Integer, ByVal AñoAnteriorIgual As Boolean, ByVal MInicio As String) As DataSet
        'mreyes 18/Octubre/2012 04:08 p.m.
        Try
            usp_PpalVentasDivisiones = objDALAntiInvent.usp_PpalVentasDivisiones(FecIniA, FecIniB, Plaza, Sucursal, Division, Depto, FamiliaDescrip, LineaDescrip, L1Descrip, L2Descrip, L3Descrip, L4Descrip, L5Descrip, L6Descrip, Marca, Modelo, FecRecA, FecRecB, AñoAnterior, IdAgrupacion, AñoAnteriorIgual, MInicio)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalVentasDepto(ByVal FecIniA As String, ByVal FecIniB As String, ByVal Plaza As Integer, ByVal Sucursal As Integer, ByVal Division As Integer, ByVal Depto As Integer, ByVal FamiliaDescrip As String, ByVal LineaDescrip As String, ByVal L1Descrip As String, ByVal L2Descrip As String, ByVal L3Descrip As String, ByVal L4Descrip As String, ByVal L5Descrip As String, ByVal L6Descrip As String, ByVal Marca As String, ByVal Modelo As String, ByVal FecRecA As String, ByVal FecRecB As String, ByVal AñoAnterior As Boolean, ByVal IdAgrupacion As Integer, ByVal AñoAnteriorIgual As Boolean, ByVal MInicio As String) As DataSet
        'mreyes 18/Octubre/2012 04:08 p.m.
        Try
            usp_PpalVentasDepto = objDALAntiInvent.usp_PpalVentasDepto(FecIniA, FecIniB, Plaza, Sucursal, Division, Depto, FamiliaDescrip, LineaDescrip, L1Descrip, L2Descrip, L3Descrip, L4Descrip, L5Descrip, L6Descrip, Marca, Modelo, FecRecA, FecRecB, AñoAnterior, IdAgrupacion, AñoAnteriorIgual, MInicio)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalVentasFamilia(ByVal FecIniA As String, ByVal FecIniB As String, ByVal Plaza As Integer, ByVal Sucursal As Integer, ByVal Division As Integer, ByVal Depto As Integer, ByVal FamiliaDescrip As String, ByVal LineaDescrip As String, ByVal L1Descrip As String, ByVal L2Descrip As String, ByVal L3Descrip As String, ByVal L4Descrip As String, ByVal L5Descrip As String, ByVal L6Descrip As String, ByVal Marca As String, ByVal Modelo As String, ByVal FecRecA As String, ByVal FecRecB As String, ByVal AñoAnterior As Boolean, ByVal IdAgrupacion As Integer, ByVal AñoAnteriorIgual As Boolean, ByVal MInicio As String) As DataSet
        'mreyes 18/Octubre/2012 04:08 p.m.
        Try
            usp_PpalVentasFamilia = objDALAntiInvent.usp_PpalVentasFamilia(FecIniA, FecIniB, Plaza, Sucursal, Division, Depto, FamiliaDescrip, LineaDescrip, L1Descrip, L2Descrip, L3Descrip, L4Descrip, L5Descrip, L6Descrip, Marca, Modelo, FecRecA, FecRecB, AñoAnterior, IdAgrupacion, AñoAnteriorIgual, MInicio)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalVentasLinea(ByVal FecIniA As String, ByVal FecIniB As String, ByVal Plaza As Integer, ByVal Sucursal As Integer, ByVal Division As Integer, ByVal Depto As Integer, ByVal FamiliaDescrip As String, ByVal LineaDescrip As String, ByVal L1Descrip As String, ByVal L2Descrip As String, ByVal L3Descrip As String, ByVal L4Descrip As String, ByVal L5Descrip As String, ByVal L6Descrip As String, ByVal Marca As String, ByVal Modelo As String, ByVal FecRecA As String, ByVal FecRecB As String, ByVal AñoAnterior As Boolean, ByVal IdAgrupacion As Integer, ByVal AñoAnteriorIgual As Boolean, ByVal MInicio As String) As DataSet
        'mreyes 18/Octubre/2012 04:08 p.m.
        Try
            usp_PpalVentasLinea = objDALAntiInvent.usp_PpalVentasLinea(FecIniA, FecIniB, Plaza, Sucursal, Division, Depto, FamiliaDescrip, LineaDescrip, L1Descrip, L2Descrip, L3Descrip, L4Descrip, L5Descrip, L6Descrip, Marca, Modelo, FecRecA, FecRecB, AñoAnterior, IdAgrupacion, AñoAnteriorIgual, MInicio)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalVentasL1(ByVal FecIniA As String, ByVal FecIniB As String, ByVal Plaza As Integer, ByVal Sucursal As Integer, ByVal Division As Integer, ByVal Depto As Integer, ByVal FamiliaDescrip As String, ByVal LineaDescrip As String, ByVal L1Descrip As String, ByVal L2Descrip As String, ByVal L3Descrip As String, ByVal L4Descrip As String, ByVal L5Descrip As String, ByVal L6Descrip As String, ByVal Marca As String, ByVal Modelo As String, ByVal FecRecA As String, ByVal FecRecB As String, ByVal AñoAnterior As Boolean, ByVal IdAgrupacion As Integer, ByVal AñoAnteriorIgual As Boolean, ByVal MInicio As String) As DataSet
        'mreyes 18/Octubre/2012 04:08 p.m.
        Try
            usp_PpalVentasL1 = objDALAntiInvent.usp_PpalVentasL1(FecIniA, FecIniB, Plaza, Sucursal, Division, Depto, FamiliaDescrip, LineaDescrip, L1Descrip, L2Descrip, L3Descrip, L4Descrip, L5Descrip, L6Descrip, Marca, Modelo, FecRecA, FecRecB, AñoAnterior, IdAgrupacion, AñoAnteriorIgual, MInicio)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalVentasL2(ByVal FecIniA As String, ByVal FecIniB As String, ByVal Plaza As Integer, ByVal Sucursal As Integer, ByVal Division As Integer, ByVal Depto As Integer, ByVal FamiliaDescrip As String, ByVal LineaDescrip As String, ByVal L1Descrip As String, ByVal L2Descrip As String, ByVal L3Descrip As String, ByVal L4Descrip As String, ByVal L5Descrip As String, ByVal L6Descrip As String, ByVal Marca As String, ByVal Modelo As String, ByVal FecRecA As String, ByVal FecRecB As String, ByVal AñoAnterior As Boolean, ByVal IdAgrupacion As Integer, ByVal AñoAnteriorIgual As Boolean, ByVal MInicio As String) As DataSet
        'mreyes 18/Octubre/2012 04:08 p.m.
        Try
            usp_PpalVentasL2 = objDALAntiInvent.usp_PpalVentasL2(FecIniA, FecIniB, Plaza, Sucursal, Division, Depto, FamiliaDescrip, LineaDescrip, L1Descrip, L2Descrip, L3Descrip, L4Descrip, L5Descrip, L6Descrip, Marca, Modelo, FecRecA, FecRecB, AñoAnterior, IdAgrupacion, AñoAnteriorIgual, MInicio)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalVentasL3(ByVal FecIniA As String, ByVal FecIniB As String, ByVal Plaza As Integer, ByVal Sucursal As Integer, ByVal Division As Integer, ByVal Depto As Integer, ByVal FamiliaDescrip As String, ByVal LineaDescrip As String, ByVal L1Descrip As String, ByVal L2Descrip As String, ByVal L3Descrip As String, ByVal L4Descrip As String, ByVal L5Descrip As String, ByVal L6Descrip As String, ByVal Marca As String, ByVal Modelo As String, ByVal FecRecA As String, ByVal FecRecB As String, ByVal AñoAnterior As Boolean, ByVal IdAgrupacion As Integer, ByVal AñoAnteriorIgual As Boolean, ByVal MInicio As String) As DataSet
        'mreyes 18/Octubre/2012 04:08 p.m.
        Try
            usp_PpalVentasL3 = objDALAntiInvent.usp_PpalVentasL3(FecIniA, FecIniB, Plaza, Sucursal, Division, Depto, FamiliaDescrip, LineaDescrip, L1Descrip, L2Descrip, L3Descrip, L4Descrip, L5Descrip, L6Descrip, Marca, Modelo, FecRecA, FecRecB, AñoAnterior, IdAgrupacion, AñoAnteriorIgual, MInicio)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalVentasL4(ByVal FecIniA As String, ByVal FecIniB As String, ByVal Plaza As Integer, ByVal Sucursal As Integer, ByVal Division As Integer, ByVal Depto As Integer, ByVal FamiliaDescrip As String, ByVal LineaDescrip As String, ByVal L1Descrip As String, ByVal L2Descrip As String, ByVal L3Descrip As String, ByVal L4Descrip As String, ByVal L5Descrip As String, ByVal L6Descrip As String, ByVal Marca As String, ByVal Modelo As String, ByVal FecRecA As String, ByVal FecRecB As String, ByVal AñoAnterior As Boolean, ByVal IdAgrupacion As Integer, ByVal AñoAnteriorIgual As Boolean, ByVal MInicio As String) As DataSet
        'mreyes 18/Octubre/2012 04:08 p.m.
        Try
            usp_PpalVentasL4 = objDALAntiInvent.usp_PpalVentasL4(FecIniA, FecIniB, Plaza, Sucursal, Division, Depto, FamiliaDescrip, LineaDescrip, L1Descrip, L2Descrip, L3Descrip, L4Descrip, L5Descrip, L6Descrip, Marca, Modelo, FecRecA, FecRecB, AñoAnterior, IdAgrupacion, AñoAnteriorIgual, MInicio)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalVentasL5(ByVal FecIniA As String, ByVal FecIniB As String, ByVal Plaza As Integer, ByVal Sucursal As Integer, ByVal Division As Integer, ByVal Depto As Integer, ByVal FamiliaDescrip As String, ByVal LineaDescrip As String, ByVal L1Descrip As String, ByVal L2Descrip As String, ByVal L3Descrip As String, ByVal L4Descrip As String, ByVal L5Descrip As String, ByVal L6Descrip As String, ByVal Marca As String, ByVal Modelo As String, ByVal FecRecA As String, ByVal FecRecB As String, ByVal AñoAnterior As Boolean, ByVal IdAgrupacion As Integer, ByVal AñoAnteriorIgual As Boolean, ByVal MInicio As String) As DataSet
        'mreyes 18/Octubre/2012 04:08 p.m .
        Try
            usp_PpalVentasL5 = objDALAntiInvent.usp_PpalVentasL5(FecIniA, FecIniB, Plaza, Sucursal, Division, Depto, FamiliaDescrip, LineaDescrip, L1Descrip, L2Descrip, L3Descrip, L4Descrip, L5Descrip, L6Descrip, Marca, Modelo, FecRecA, FecRecB, AñoAnterior, IdAgrupacion, AñoAnteriorIgual, MInicio)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalVentasL6(ByVal FecIniA As String, ByVal FecIniB As String, ByVal Plaza As Integer, ByVal Sucursal As Integer, ByVal Division As Integer, ByVal Depto As Integer, ByVal FamiliaDescrip As String, ByVal LineaDescrip As String, ByVal L1Descrip As String, ByVal L2Descrip As String, ByVal L3Descrip As String, ByVal L4Descrip As String, ByVal L5Descrip As String, ByVal L6Descrip As String, ByVal Marca As String, ByVal Modelo As String, ByVal FecRecA As String, ByVal FecRecB As String, ByVal AñoAnterior As Boolean, ByVal IdAgrupacion As Integer, ByVal AñoAnteriorIgual As Boolean, ByVal MInicio As String) As DataSet
        'mreyes 18/Octubre/2012 04:08 p.m. 
        Try
            usp_PpalVentasL6 = objDALAntiInvent.usp_PpalVentasL6(FecIniA, FecIniB, Plaza, Sucursal, Division, Depto, FamiliaDescrip, LineaDescrip, L1Descrip, L2Descrip, L3Descrip, L4Descrip, L5Descrip, L6Descrip, Marca, Modelo, FecRecA, FecRecB, AñoAnterior, IdAgrupacion, AñoAnteriorIgual, MInicio)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalVentasMarca(ByVal FecIniA As String, ByVal FecIniB As String, ByVal Plaza As Integer, ByVal Sucursal As Integer, ByVal Division As Integer, ByVal Depto As Integer, ByVal FamiliaDescrip As String, ByVal LineaDescrip As String, ByVal L1Descrip As String, ByVal L2Descrip As String, ByVal L3Descrip As String, ByVal L4Descrip As String, ByVal L5Descrip As String, ByVal L6Descrip As String, ByVal Marca As String, ByVal Modelo As String, ByVal FecRecA As String, ByVal FecRecB As String, ByVal AñoAnterior As Boolean, ByVal IdAgrupacion As Integer, ByVal AñoAnteriorIgual As Boolean, ByVal MInicio As String) As DataSet
        'mreyes 18/Octubre/2012 04:08 p.m.
        Try
            usp_PpalVentasMarca = objDALAntiInvent.usp_PpalVentasMarca(FecIniA, FecIniB, Plaza, Sucursal, Division, Depto, FamiliaDescrip, LineaDescrip, L1Descrip, L2Descrip, L3Descrip, L4Descrip, L5Descrip, L6Descrip, Marca, Modelo, FecRecA, FecRecB, AñoAnterior, IdAgrupacion, AñoAnteriorIgual, MInicio)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalVentasMarcaModelo(ByVal FecIniA As String, ByVal FecIniB As String, ByVal Plaza As Integer, ByVal Sucursal As Integer, ByVal Division As Integer, ByVal Depto As Integer, ByVal FamiliaDescrip As String, ByVal LineaDescrip As String, ByVal L1Descrip As String, ByVal L2Descrip As String, ByVal L3Descrip As String, ByVal L4Descrip As String, ByVal L5Descrip As String, ByVal L6Descrip As String, ByVal Marca As String, ByVal Modelo As String, ByVal FecRecA As String, ByVal FecRecB As String, ByVal AñoAnterior As Boolean, ByVal Miles As Integer, ByVal IdAgrupacion As Integer, ByVal AñoAnteriorIgual As Boolean, ByVal MInicio As String) As DataSet
        'mreyes 18/Octubre/2012 04:08 p.m.
        Try
            usp_PpalVentasMarcaModelo = objDALAntiInvent.usp_PpalVentasMarcaModelo(FecIniA, FecIniB, Plaza, Sucursal, Division, Depto, FamiliaDescrip, LineaDescrip, L1Descrip, L2Descrip, L3Descrip, L4Descrip, L5Descrip, L6Descrip, Marca, Modelo, FecRecA, FecRecB, AñoAnterior, Miles, IdAgrupacion, AñoAnteriorIgual, MInicio)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerPlaza(ByVal Plaza As String) As DataSet
        'mreyes 14/Octubre/2015 12:17 p.m.
        Try
            usp_TraerPlaza = objDALAntiInvent.usp_TraerPlaza(Plaza)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerSucursal(ByVal Sucursal As String) As DataSet
        'mreyes 18/Octubre/2012 04:08 p.m.
        Try
            usp_TraerSucursal = objDALAntiInvent.usp_TraerSucursal(Sucursal)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ActualizarSucursal(ByVal Sucursal As String, ByVal Visible As String) As Boolean
        'mreyes 18/Octubre/2012 04:08 p.m.
        Try
            usp_ActualizarSucursal = objDALAntiInvent.usp_ActualizarSucursal(Sucursal, Visible)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_GeneraVentasBase(ByVal FecIni As String, ByVal FecFin As String, ByVal idUsuario As Integer) As Boolean
        'mreyes 18/Octubre/2012 04:08 p.m.
        Try
            usp_GeneraVentasBase = objDALAntiInvent.usp_GeneraVentasBase(FecIni, FecFin, idUsuario)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_GeneraTxtCoqueta(ByVal Sucursal As String, ByVal FechaIni As Date, ByVal FechaFin As Date) As DataSet
        'mreyes 25/Abril/2016   10:26 a.m.
        Try
            usp_GeneraTxtCoqueta = objDALAntiInvent.usp_GeneraTxtCoqueta(Sucursal, FechaIni, FechaFin)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_GeneraTxtOzono(ByVal FechaIni As Date, ByVal FechaFin As Date) As DataSet
        'Tony Garcia - 21/Enero/2014
        Try
            usp_GeneraTxtOzono = objDALAntiInvent.usp_GeneraTxtOzono(FechaIni, FechaFin)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerPedidoTrac(ByVal Sucursal As String, ByVal OrdeComp As String) As DataSet
        'meyes  19/Abril/201605:57 p.m.
        Try
            usp_TraerPedidoTrac = objDALAntiInvent.usp_TraerPedidoTrac(Sucursal, OrdeComp)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
