Public Class frmDate

  
    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        G_Date = dtpDate.Text
        frmReportsBrowser.ShowDialog()
    End Sub

    Private Sub frmDate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtpDate.Text = Now.Date
    End Sub
End Class