Public Class ClinicReportOption
    Dim objPatient As BCL.BCLPatient

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub rdoDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoDate.CheckedChanged
        'If rdoDate.Checked = True Then
        '    dtpDate.Enabled = True
        'End If
        dtpDate.Enabled = rdoDate.Checked
    End Sub

    Private Sub rbPatientName_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbPatientName.CheckedChanged
        'If rbPatientName.Checked = True Then
        '    cboPatientName.Enabled = True
        'End If
        cboPatientName.Enabled = rbPatientName.Checked
    End Sub

    Private Sub ClinicReportOption_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        rdoDate.Checked = True
        LoadPaitentCombo()
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        If rdoDate.Checked = True Then
            frmReportsBrowser.ReportIndex = 2
            G_Date = dtpDate.Text
        ElseIf rbPatientName.Checked = True Then
            frmReportsBrowser.ReportIndex = 3
            G_TempVariableString = cboPatientName.SelectedValue
        End If
        frmReportsBrowser.ShowDialog()
    End Sub

    Sub LoadPaitentCombo()
        Dim PatientDataSet As New DataSet
        Using objPatient As New BCL.BCLPatient(G_ConString)
            Try
                'Clear previous bindings
                PatientDataSet = objPatient.GetPatients()
                cboPatientName.DataSource = PatientDataSet.Tables("Patients")
                cboPatientName.ValueMember = PatientDataSet.Tables("Patients").Columns(0).ToString
                cboPatientName.DisplayMember = PatientDataSet.Tables("Patients").Columns(1).ToString
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub
End Class