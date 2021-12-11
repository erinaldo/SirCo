Public Class BCLConceptoRep
    'miguel perez, tony garcia  31/Agosto/2012 12:00 p.m.

    Implements IDisposable
    Private objDALConceptoRep As DAL.DALConceptoRep
    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALConceptoRep = New DAL.DALConceptoRep(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALConceptoRep.Dispose()
            objDALConceptoRep = Nothing
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

    Public Function usp_PpalConceptoReporte(ByVal IdPeriodo As String, ByVal TipoNom As String, ByVal IdEmpleado As Integer, _
                                    ByVal Sucursal As String, ByVal IdDepto As Integer, ByVal IdPuesto As Integer, ByVal ClaveConcepto As String) As DataSet
        'miguel perez, tony garcia 31/Agosto/2012 01:42 p.m.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALConceptoRep.usp_PpalConceptoReporte(IdPeriodo, TipoNom, IdEmpleado, Sucursal, IdDepto, IdPuesto, ClaveConcepto)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    
End Class

