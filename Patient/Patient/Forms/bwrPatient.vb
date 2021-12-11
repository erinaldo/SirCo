Public Class bwrPatient
    Dim myList As EmpleadoList
    Private Sub bwrPatient_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        myList = New EmpleadoList()
        pnlMain.Controls.Add(myList)
        pnlMain.Refresh()
    End Sub

    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        G_TempVariableString = myList.SelectPatientId
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        G_TempVariableString = ""
        Me.Close()
        Me.Dispose()
    End Sub
End Class