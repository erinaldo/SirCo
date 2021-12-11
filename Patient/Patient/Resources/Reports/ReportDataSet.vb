Partial Class ReportDataSet

    Partial Class tbl_PatientDataTable

        Private Sub tbl_PatientDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.columnPuesto_Name.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class

End Class

Namespace ReportDataSetTableAdapters
    
    Partial Public Class usp_RptNominaBonos1TableAdapter
    End Class
End Namespace
