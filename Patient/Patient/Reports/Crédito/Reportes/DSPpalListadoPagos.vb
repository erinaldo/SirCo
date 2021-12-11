Partial Class DSPpalListadoPagos
    Partial Class Tlb_ListadoPagosDataTable

        Private Sub Tlb_ListadoPagosDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.DetColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class

End Class
