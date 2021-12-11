Public Class BCLTipoCredito

    'vgallegos 19/Enero/2018   05:16 p.m.


    Implements IDisposable
    Private objDALTipoCredito As DAL.DALTipoCredito

    Private disposedValue As Boolean = False        ' To detect redundant calls

#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALTipoCredito = New DAL.DALTipoCredito(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALTipoCredito.Dispose()
            objDALTipoCredito = Nothing
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

    Public Function InsertarTipoCredito() As DataSet
        'vgallegos 20/Enero/2018 11:30 am
        Try
            InsertarTipoCredito = New DataSet
            Dim objDataTable As DataTable = InsertarTipoCredito.Tables.Add("tipocredito")
            Dim objDataColumn As DataColumn

            objDataColumn = New DataColumn("idtipocredito", Type.GetType("System.Int32"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("tipocredito", Type.GetType("System.String"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("observaciones", Type.GetType("System.String"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("idusuario", Type.GetType("System.Int32"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("fum", Type.GetType("System.DateTime"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("idusuariomodif", Type.GetType("System.Int32"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("fummodif", Type.GetType("System.DateTime"))
            objDataTable.Columns.Add(objDataColumn)


            objDataTable.Columns.Add(objDataColumn)

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try

    End Function
    Public Function usp_CapturaTipoCredito(ByVal opcion As Integer, ByVal idtipocredito As Integer, ByVal tipocredito As String, ByVal idperiodicidad As Integer,
                                           ByVal fechalimpago1 As Integer, ByVal fechalimpago2 As Integer, ByVal diacorte1 As Integer, ByVal diacorte2 As Integer,
                                           ByVal carterafresco As Integer, ByVal gastofresco As Decimal, ByVal interesfresco As Decimal, ByVal carteravencido As Integer,
                                           ByVal gastovencido As Decimal, ByVal interesvencido As Decimal, ByVal gastodemanda As Decimal, ByVal observaciones As String,
                                           ByVal idusuario As Integer, ByVal idusuariomodif As Integer) As Boolean
        ' vgallegos 19/Enero/2018   07:00 p.m.
        Try
            Return objDALTipoCredito.usp_CapturaTipoCredito(opcion, idtipocredito, tipocredito, idperiodicidad, fechalimpago1, fechalimpago2, diacorte1, diacorte2,
                                                            carterafresco, gastofresco, interesfresco, carteravencido, gastovencido, interesvencido, gastodemanda,
                                                            observaciones, idusuario, idusuariomodif)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerTipoCredito(ByVal opcion As Integer, ByVal idtipocredito As Integer, ByVal tipocredito As String, ByVal idperiodicidad As Integer,
                                           ByVal fechalimpago1 As Integer, ByVal fechalimpago2 As Integer, ByVal diacorte1 As Integer, ByVal diacorte2 As Integer,
                                           ByVal carterafresco As Integer, ByVal gastofresco As Integer, ByVal interesfresco As Integer, ByVal carteravencido As Integer,
                                           ByVal gastovencido As Integer, ByVal interesvencido As Integer, ByVal gastodemanda As Integer, ByVal observaciones As String,
                                           ByVal idusuario As Integer, ByVal idusuariomodif As Integer) As DataSet

        Try
            Return objDALTipoCredito.usp_TraerTipoCredito(opcion, idtipocredito, tipocredito, idperiodicidad, fechalimpago1, fechalimpago2, diacorte1, diacorte2,
                                                            carterafresco, gastofresco, interesfresco, carteravencido, gastovencido, interesvencido, gastodemanda,
                                                            observaciones, idusuario, idusuariomodif)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try

    End Function

    Public Function usp_TraerTipoCreditoId(ByVal Opcion As Integer, ByVal idtipocredito As Integer, ByVal tipocredito As String,
                                 ByVal observaciones As String, ByVal idusuario As Integer, ByVal fum As DateTime,
                                 ByVal idusuariomod As Integer, ByVal fummod As DateTime) As DataSet

        Try
            Return objDALTipoCredito.usp_TraerTipoCreditoId(Opcion, idtipocredito, tipocredito, observaciones, idusuario, fum, idusuariomod, fummod)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try

    End Function

    Public Function usp_TraerPeriodicidad() As DataSet

        Try
            Return objDALTipoCredito.usp_TraerPeriodicidad()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try

    End Function
#End Region


End Class