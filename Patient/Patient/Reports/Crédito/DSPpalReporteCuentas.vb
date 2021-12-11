Partial Class DSPpalReporteCuentas

    Partial Class Tlb_AntiguedadSaldosDataTable

        Private Sub Tlb_AntiguedadSaldosDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me._90diasColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class

End Class
