Public Class ClinicList

    Private objDataSet As Data.DataSet
    Private objClinicDataSet As DataSet
    Private objClinic As BCL.BCLClinic

    Sub LoadClinic()
        Using objClinic As New BCL.BCLClinic(G_ConString)
            Try
                'Get the specific project selected in the ListView control
                objDataSet = objClinic.GetClinics()
                'Populate the Project Details section
                dgClinic.DataSource = Nothing
                dgClinic.DataSource = objDataSet.Tables("Clinics")
                MenuEnable()
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Sub LoadClinicByClinicID(ByVal ClinicID As Integer)
        Using objClinic As New BCL.BCLClinic(G_ConString)
            Try
                'Get the specific project selected in the ListView control
                objDataSet = objClinic.GetClinicById(ClinicID)
                'Populate the Project Details section
                dgClinic.DataSource = Nothing
                dgClinic.DataSource = objDataSet.Tables("Clinic")
                MenuEnable()
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Sub LoadClinicByPatientName(ByVal PatientName As String)
        Using objClinic As New BCL.BCLClinic(G_ConString)
            Try
                'Get the specific project selected in the ListView control
                objDataSet = objClinic.GetClinicByPatientName(PatientName)
                'Populate the Project Details section
                dgClinic.DataSource = Nothing
                dgClinic.DataSource = objDataSet.Tables("Clinics")
                MenuEnable()
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Sub LoadClinicByDoctorName(ByVal DoctorName As String)
        Using objClinic As New BCL.BCLClinic(G_ConString)
            Try
                'Get the specific project selected in the ListView control
                objDataSet = objClinic.GetClinicByDoctorName(DoctorName)
                'Populate the Project Details section
                dgClinic.DataSource = Nothing
                dgClinic.DataSource = objDataSet.Tables("Clinics")
                MenuEnable()
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub


    Sub LoadClinicByDiagnosisName(ByVal DiagnosisName As String)
        Using objClinic As New BCL.BCLClinic(G_ConString)
            Try
                'Get the specific project selected in the ListView control
                objDataSet = objClinic.GetClinicByDiagnosisName(DiagnosisName)
                'Populate the Project Details section
                dgClinic.DataSource = Nothing
                dgClinic.DataSource = objDataSet.Tables("Clinics")
                MenuEnable()
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Sub LoadClinicByClinicDate(ByVal ClinicDate As Date)
        Using objClinic As New BCL.BCLClinic(G_ConString)
            Try
                'Get the specific project selected in the ListView control
                objDataSet = objClinic.GetClinicByClinicDate(ClinicDate)
                'Populate the Project Details section
                dgClinic.DataSource = Nothing
                dgClinic.DataSource = objDataSet.Tables("Clinics")
                MenuEnable()
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Sub LoadClinicByContactDate(ByVal ContactDate As Date)
        Using objClinic As New BCL.BCLClinic(G_ConString)
            Try
                'Get the specific project selected in the ListView control
                objDataSet = objClinic.GetClinicByContactDate(ContactDate)
                'Populate the Project Details section
                dgClinic.DataSource = Nothing
                dgClinic.DataSource = objDataSet.Tables("Clinics")
                MenuEnable()
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Sub MenuEnable()
        If dgClinic.Rows.Count = 0 Then
            mnuDelete.Enabled = False
            mnuEdit.Enabled = False
            mnuPrint.Enabled = False
        Else
            mnuDelete.Enabled = True
            mnuEdit.Enabled = True
            mnuPrint.Enabled = True
        End If
    End Sub


    Function DataValidate(ByVal Index As Byte) As Boolean
        ''        Clinic(ID)
        ''        Patient(Name)
        ''        Doctor(Name)
        ''      Diagnosis
        ''      Date
        ''      Contact Date
        Select Case Index
            Case 0 'Select One
                MessageBox.Show("Please Choose Search Type!", "Data Validation", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cboSearchBy.Focus()
                Exit Function
            Case 1 ' Clinic(ID)
                If IsNumeric(txtSearch.Text) = False Then
                    MessageBox.Show("Please Clinic ID must be numeric value!", "Data Validation", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtSearch.Focus()
                    Exit Function
                End If
                If txtSearch.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please Type Clinic ID To Search!", "Data Validation", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtSearch.Focus()
                    Exit Function
                End If
            Case 2 'Search With Patient Name
                If txtSearch.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please Type Patient Name To Search!", "Data Validation", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtSearch.Focus()
                    Exit Function
                End If
            Case 3 'Search With Doctor Name
                If txtSearch.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please Type Doctor Name To Search!", "Data Validation", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtSearch.Focus()
                    Exit Function
                End If
            Case 4 'Search With Diagnosis
                If txtSearch.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please Type Diagnosis Name To Search!", "Data Validation", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtSearch.Focus()
                    Exit Function
                End If
            Case 5 'Search With Clinic Date
                If txtSearch.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please Type Clinic Date To Search!", "Data Validation", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtSearch.Focus()
                    Exit Function
                End If
                If IsDate(txtSearch.Text) = False Then
                    MessageBox.Show("Please Clinic Date must be Date!", "Data Validation", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtSearch.Focus()
                    Exit Function
                End If
            Case 6 'Search With Contact Date
                If txtSearch.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please Type Contact Date To Search!", "Data Validation", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtSearch.Focus()
                    Exit Function
                End If
                If IsDate(txtSearch.Text) = False Then
                    MessageBox.Show("Please Contact Date must be Date!", "Data Validation", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtSearch.Focus()
                    Exit Function
                End If
        End Select
        DataValidate = True
    End Function

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If DataValidate(cboSearchBy.SelectedIndex) = False Then Exit Sub
        Select Case cboSearchBy.SelectedIndex
            Case 1 'Clinic ID
                LoadClinicByClinicID(txtSearch.Text.Trim)
            Case 2 'Patient Name
                LoadClinicByPatientName("%" & txtSearch.Text.Trim & "%")
            Case 3 'Doctor Name
                LoadClinicByDoctorName("%" & txtSearch.Text.Trim & "%")
            Case 4 'Diagnosis Name
                LoadClinicByDiagnosisName("%" & txtSearch.Text.Trim & "%")
            Case 5 'Clinic Date
                LoadClinicByClinicDate(CDate(txtSearch.Text.Trim))
            Case 6 'Contact Date
                LoadClinicByContactDate(CDate(txtSearch.Text.Trim))
        End Select
    End Sub

    Private Sub mnuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEdit.Click
        G_TempVariableString = ""
        If dgClinic.CurrentRow.Index < 0 Then Exit Sub
        G_TempVariableString = dgClinic.Rows(dgClinic.CurrentRow.Index).Cells(1).Value.ToString
        frmPatientClinic.ShowDialog()
        LoadClinic()
    End Sub

    Public Sub mnuNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNew.Click
        Dim myDialogForm As New frmPatientClinic
        G_TempVariableString = ""
        myDialogForm.ShowDialog()
        LoadClinic()
    End Sub

    Private Sub mnuDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDelete.Click
        Using objClinic As New BCL.BCLClinic(G_ConString)
            Try
                'Get the specific project selected in the ListView control
                If MessageBox.Show("Are you sure you want to Delete?", "Comfirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = DialogResult.OK Then
                    If objClinic.DeleteClinic(dgClinic.Rows(dgClinic.CurrentRow.Index).Cells(1).Value.ToString) = True Then
                        MessageBox.Show("Delete Successful !", "Delete!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        LoadClinic()
                    Else
                        MessageBox.Show("Error To Delete!", "Delete!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub btnAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAll.Click
        cboSearchBy.SelectedIndex = 0
        txtSearch.Text = ""
        LoadClinic()
    End Sub

    Private Sub ClinicList_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cboSearchBy.SelectedIndex = 0
        LoadClinic()
        Me.Dock = DockStyle.Fill
    End Sub

    Private Sub mnuPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPrint.Click
        'frmReportsBrowser.ReportIndex = 2
        'frmDate.ShowDialog()
        ClinicReportOption.ShowDialog()
        'frmReportsBrowser.ShowDialog()
    End Sub

    Private Sub csmClinic_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles csmClinic.Opening

    End Sub
End Class
