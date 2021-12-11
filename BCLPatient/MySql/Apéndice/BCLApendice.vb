Public Class BCLApendice

    Implements IDisposable
    Private objDALPruebas As DAL.DALApendice
    Private disposedValue As Boolean = False

#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALPruebas = New DAL.DALApendice(Constring)
    End Sub
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free other state (managed objects).
            End If

            ' TODO: free your own state (unmanaged objects).
            ' TODO: set large fields to null.
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

    Public Function usp_traer_detalle_ventas_por_articulos(ByVal fecha As String, ByVal sucursal As String, ByVal tipoart As String) As DataSet
        Try
            usp_traer_detalle_ventas_por_articulos = objDALPruebas.usp_traer_detalle_ventas_por_articulos(fecha, sucursal, tipoart)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function



    Public Function usp_traer_forma_pago(ByVal fecha As String, ByVal sucursal As String) As DataSet

        Try
            usp_traer_forma_pago = objDALPruebas.usp_traer_forma_pago(fecha, sucursal)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_traer_consecutivo_folio(ByVal fecha As String, ByVal sucursal As String) As DataSet

        Try
            usp_traer_consecutivo_folio = objDALPruebas.usp_traer_consecutivo_folio(fecha, sucursal)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_traer_Cancelados_NoAplicados(ByVal fecha As String, ByVal sucursal As String) As DataSet
        Try
            usp_traer_Cancelados_NoAplicados = objDALPruebas.usp_traer_Cancelados_NoAplicados(fecha, sucursal)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_traer_detalle_Devoluciones(ByVal fecha As String, ByVal sucursal As String) As DataSet
        Try
            usp_traer_detalle_Devoluciones = objDALPruebas.usp_traer_detalle_Devoluciones(fecha, sucursal)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_traer_desglose_movimientos_x_articulo(ByVal fecha As String, ByVal sucursal As String) As DataSet
        Try
            usp_traer_desglose_movimientos_x_articulo = objDALPruebas.usp_traer_desglose_movimientos_x_articulo(fecha, sucursal)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function



    Public Function usp_Cargar_Apendice(ByVal opcion As Integer, ByVal sucursal As String, ByVal fechaInicio As String, ByVal fechaFin As String, ByVal Importe As Double, ByVal porcentaje As Integer, ByVal Cajero As String) As DataSet
        Try
            usp_Cargar_Apendice = objDALPruebas.usp_Cargar_Apendice(opcion, sucursal, fechaInicio, fechaFin, Importe, porcentaje, cajero)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

End Class
