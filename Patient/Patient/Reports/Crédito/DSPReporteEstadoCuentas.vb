Partial Class DSPReporteEstadoCuentas
    Partial Class Tlb_RelacionDataTable
        Private Sub Tlb_RelacionDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.DistribuidorColumn.ColumnName) Then
            End If
        End Sub
    End Class
End Class
