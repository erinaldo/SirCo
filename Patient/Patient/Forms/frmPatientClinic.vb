Imports System.IO
Imports System

Public Class frmPatientClinic
    Private objDataSet As Data.DataSet
    Private objClinicDataSet As DataSet
    Private objClinic As BCL.BCLClinic
    Private objDoctor As BCL.BCLPuesto
    Private myFileName As String
    Private isSetPic As Boolean

#Region "Clinic Functions"

    Sub SavePic(ByVal FilePath As String, ByVal TargetPath As String, ByVal FileName As String)
        File.Copy(FilePath, TargetPath & FileName, True)
    End Sub

    Sub LoadDoctorCombo()
        Dim DoctorDataset As New DataSet
        Using objDoctor As New BCL.BCLPuesto(G_ConString)
            Try
                'Clear previous bindings
                DoctorDataset = objDoctor.GetDoctor()
                cboDoctor.DataSource = DoctorDataset.Tables("Doctors")
                cboDoctor.ValueMember = DoctorDataset.Tables("Doctors").Columns(0).ToString
                cboDoctor.DisplayMember = DoctorDataset.Tables("Doctors").Columns(1).ToString
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    'Function GetPatientName(ByVal PatientID As String) As String
    '    Using objClinic As New BCL.BCLClinic(G_ConString)
    '        Try
    '            'Clear previous bindings
    '            Return objClinic.GetPatientName(PatientID)
    '        Catch ExceptionErr As Exception
    '            MessageBox.Show(ExceptionErr.Message.ToString)
    '        End Try
    '    End Using
    'End Function

    Function LoadMaxClinicID() As Integer
        Using objClinic As New BCL.BCLClinic(G_ConString)
            Try
                'Clear previous bindings
                Return objClinic.GetMaxClinicID
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function

    Function AddClinic() As Boolean
        Using objClinic As New BCL.BCLClinic(G_ConString)
            'Get a new Project DataSet
            objDataSet = objClinic.GetNewClinicDS
            'Initialize a datarow object from the Project DataSet
            Dim objDataRow As Data.DataRow = _
                objDataSet.Tables("Clinic").NewRow
            'Set the values in the DataRow
            objDataRow.Item("Clinic_ID") = CInt(Trim(txtRgsNo.Text))
            objDataRow.Item("Patient_ID") = lnkPatient.Tag
            objDataRow.Item("Doctor_ID") = CInt(cboDoctor.SelectedValue)
            objDataRow.Item("Diagnosis_Description") = Trim(txtDiagnosis.Text)
            objDataRow.Item("DRUGAllergy_Description") = Trim(txtDrugAllergy.Text)
            objDataRow.Item("Exam_BW") = Trim(txtBW.Text)
            objDataRow.Item("Exam_PR") = Trim(txtPR.Text)
            objDataRow.Item("Exam_BP") = Trim(txtBP.Text)
            objDataRow.Item("History_Description") = Trim(txtHistory.Text)
            objDataRow.Item("Investigation_Description") = Trim(txtInvestigation.Text)
            objDataRow.Item("TreateMent_Desc") = Trim(txtTreatement.Text)
            objDataRow.Item("Clinic_Date") = dtpDate.Text
            objDataRow.Item("Contact_Date") = dtpContactDate.Text
            ' objDataRow.Item("Section") = Trim(txtSection.Text)
            objDataRow.Item("Others") = Trim(txtOthers.Text)
            'Add the DataRow to the DataSet
            objDataSet.Tables("Clinic").Rows.Add(objDataRow)
            'Add the Project
            If Not objClinic.AddClinic(objDataSet) Then
                Throw New Exception("Insert Clinic Failed")
            Else
                AddClinic = True
            End If
        End Using
    End Function

    Function AddPicture() As Boolean
        Using objClinic As New BCL.BCLClinic(G_ConString)
            'Get a new Project DataSet
            Dim MaxPicID As Integer
            objDataSet = objClinic.GetNewPictureDS
            'Initialize a datarow object from the Project DataSet
            Dim objDataRow As Data.DataRow = _
                objDataSet.Tables("Picture").NewRow
            'Set the values in the DataRow
            MaxPicID = objClinic.GetMaxPicID
            objDataRow.Item("Pic_ID") = MaxPicID
            objDataRow.Item("Clinic_ID") = CInt(txtRgsNo.Text)
            objDataRow.Item("PicName") = txtRgsNo.Text.Trim & MaxPicID & ".jpg"
            objDataRow.Item("PicRemark") = Trim(txtPicRemark.Text)
            'Add the DataRow to the DataSet
            If isSetPic = True And myFileName.Length > 0 Then
                SavePic(myFileName, Application.StartupPath & "\Pic\PatientParts\", txtRgsNo.Text.Trim & MaxPicID & ".jpg")
            End If
            objDataSet.Tables("Picture").Rows.Add(objDataRow)
            'Add the Project
            If Not objClinic.AddPicture(objDataSet) Then
                Throw New Exception("Insert Picture Failed")
            Else
                AddPicture = True
            End If
        End Using
    End Function

    Sub ShowClinicData(ByVal ClinicDataSet As DataSet)
        txtRgsNo.Text = ClinicDataSet.Tables("Clinic").Rows(0).Item(0).ToString
        lnkPatient.Tag = ClinicDataSet.Tables("Clinic").Rows(0).Item(1).ToString
        '  lnkPatient.Text = GetPatientName(lnkPatient.Tag)
        LoadClinicByPatientID(lnkPatient.Tag)
        cboDoctor.SelectedValue = ClinicDataSet.Tables("Clinic").Rows(0).Item(2).ToString
        txtDiagnosis.Text = ClinicDataSet.Tables("Clinic").Rows(0).Item(3).ToString
        txtDrugAllergy.Text = ClinicDataSet.Tables("Clinic").Rows(0).Item(4).ToString
        txtBW.Text = ClinicDataSet.Tables("Clinic").Rows(0).Item(5).ToString
        txtPR.Text = ClinicDataSet.Tables("Clinic").Rows(0).Item(6).ToString
        txtBP.Text = ClinicDataSet.Tables("Clinic").Rows(0).Item(7).ToString
        txtHistory.Text = ClinicDataSet.Tables("Clinic").Rows(0).Item(8).ToString
        txtInvestigation.Text = ClinicDataSet.Tables("Clinic").Rows(0).Item(9).ToString
        txtTreatement.Text = ClinicDataSet.Tables("Clinic").Rows(0).Item(10).ToString
        dtpDate.Text = ClinicDataSet.Tables("Clinic").Rows(0).Item(11).ToString
        dtpContactDate.Text = ClinicDataSet.Tables("Clinic").Rows(0).Item(12).ToString
        ' txtSection.Text = ClinicDataSet.Tables("Clinic").Rows(0).Item(13).ToString
        txtOthers.Text = ClinicDataSet.Tables("Clinic").Rows(0).Item(13).ToString
        LoadPictureByClinicID(txtRgsNo.Text)
    End Sub

    Function UpdateClinic() As Boolean
        Using objClinic As New BCL.BCLClinic(G_ConString)
            'Get a new Project DataSet
            objDataSet = objClinic.GetNewClinicDS
            'Initialize a datarow object from the Project DataSet
            Dim objDataRow As Data.DataRow = _
                objDataSet.Tables("Clinic").NewRow
            'Set the values in the DataRow
            objDataRow.Item("Clinic_ID") = CInt(Trim(txtRgsNo.Text))
            objDataRow.Item("Patient_ID") = lnkPatient.Tag
            objDataRow.Item("Doctor_ID") = CInt(cboDoctor.SelectedValue)
            objDataRow.Item("Diagnosis_Description") = Trim(txtDiagnosis.Text)
            objDataRow.Item("DRUGAllergy_Description") = Trim(txtDrugAllergy.Text)
            objDataRow.Item("Exam_BW") = Trim(txtBW.Text)
            objDataRow.Item("Exam_PR") = Trim(txtPR.Text)
            objDataRow.Item("Exam_BP") = Trim(txtBP.Text)
            objDataRow.Item("History_Description") = Trim(txtHistory.Text)
            objDataRow.Item("Investigation_Description") = Trim(txtInvestigation.Text)
            objDataRow.Item("TreateMent_Desc") = Trim(txtTreatement.Text)
            objDataRow.Item("Clinic_Date") = CDate(dtpDate.Value)
            objDataRow.Item("Contact_Date") = CDate(dtpContactDate.Value)
            ' objDataRow.Item("Section") = Trim(txtSection.Text)
            objDataRow.Item("Others") = Trim(txtOthers.Text)
            'Add the DataRow to the DataSet
            objDataSet.Tables("Clinic").Rows.Add(objDataRow)
            'Update the Clinic Data
            If Not objClinic.UpdateClinic(objDataSet) Then
                Throw New Exception("Update Clinic Failed")
            Else
                UpdateClinic = True
            End If
        End Using
    End Function

    Public Function DeleteClinic(ByVal ClinicID As Integer) As Boolean
        Try
            'Call the data component to delete the project
            Return objClinic.DeleteClinic(ClinicID)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

#End Region

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub frmPatientClinic_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadDoctorCombo()
        If G_TempVariableString.Length = 0 Then
            txtRgsNo.Text = LoadMaxClinicID()
            txtDrugAllergy.Focus()
        Else
            LoadClinicByCliNicID(CInt(G_TempVariableString))
            txtDrugAllergy.Focus()
        End If
        LoadPictureByClinicID(txtRgsNo.Text)
    End Sub

    Private Sub lnkPictureBwr_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkPictureBwr.LinkClicked
        'SaveFileDialog1.ShowDialog()
        'oflg.Filter = "Support graphics format (*.bmp,*.jpg,*.gif,*.png)|*.bmp;*.jpg;*.gif;*.jpeg;*.png"
        oflg.Filter = "Support graphics format (*.jpg)|*.jpg"
        oflg.FileName = ""
        oflg.ShowDialog()
        myFileName = oflg.FileName
        lnkViewImage.Tag = ""
        If myFileName.Length = 0 Then Exit Sub
        picParts.Load(myFileName)
        lnkViewImage.Tag = myFileName
        btnSave.Enabled = True
        isSetPic = True
    End Sub

    Sub LoadClinicByCliNicID(ByVal ClinicID As Integer)
        Using objClinic As New BCL.BCLClinic(G_ConString)
            Try
                'Get the specific project selected in the ListView control
                objDataSet = objClinic.GetClinicById(ClinicID)
                'Populate the Project Details section
                ShowClinicData(objDataSet)
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub
    Private Sub picExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picExit.Click, lblExit.Click, CloseToolStripMenuItem.Click
        If MessageBox.Show("Are you sure you want to exit?", "Comfirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
            Me.Dispose()
            Me.Close()
        End If
    End Sub

    'Private Sub brwPatient_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles brwPatient.Click
    '    G_TempVariableString = ""
    '    bwrPatient.ShowDialog()
    '    If G_TempVariableString = "" Then Exit Sub
    '    ClearScreen()
    '    lnkPatient.Tag = G_TempVariableString
    '    lnkPatient.Text = GetPatientName(lnkPatient.Tag)
    '    LoadClinicByPatientID(lnkPatient.Tag)
    '    txtDrugAllergy.Focus()
    'End Sub

    Sub ClearScreen()
        txtRgsNo.Text = LoadMaxClinicID()
        lnkPatient.Tag = ""
        lnkPatient.Text = ""
        LoadClinicByPatientID("®")
        cboDoctor.SelectedIndex = -1
        txtDiagnosis.Text = ""
        txtDrugAllergy.Text = ""
        txtBW.Text = ""
        txtPR.Text = ""
        txtBP.Text = ""
        txtHistory.Text = ""
        txtInvestigation.Text = ""
        txtTreatement.Text = ""
        dtpDate.Text = Now.Date
        dtpContactDate.Text = Now.Date
        ' txtSection.Text = ""
        txtOthers.Text = ""
        picParts.Image = Nothing
        txtPicRemark.Text = ""
        LoadPictureByClinicID(txtRgsNo.Text)
        bwrPatient.Focus()
    End Sub

    Sub LoadPictureByClinicID(ByVal ClinicID As Integer)
        Using objClinic As New BCL.BCLClinic(G_ConString)
            Try
                objDataSet = objClinic.GetPicByClinicID(ClinicID)
                'Populate the Project Details section
                dgPic.DataSource = Nothing
                dgPic.DataSource = objDataSet.Tables("Pictures")
                dgPic.Columns(0).Visible = False
                If dgPic.RowCount = 0 Then
                    mnuDelete.Enabled = False
                Else
                    mnuDelete.Enabled = True
                End If

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub lblNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblNew.Click, picNew.Click
        ClearScreen()
        brwPatient.Focus()
    End Sub
    Function IsAlreadyExistClinic_ID(ByVal Clinic_ID As Integer) As Boolean
        Using objClinic As New BCL.BCLClinic(G_ConString)
            Return objClinic.IsAlreadyExistClinic_ID(Clinic_ID)
        End Using
    End Function
    Private Sub lblSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblSave.Click, PicSaveAndClose.Click
        Try
            If IsAlreadyExistClinic_ID(txtRgsNo.Text.Trim) = False Then
                If MsgBox("Are you sure you want to Save?", MsgBoxStyle.OkCancel, "Comfirm") = MsgBoxResult.Ok Then
                    If AddClinic() = True Then
                        MessageBox.Show("Successfully Saved!", "User Saving")
                        LoadClinicByPatientID(lnkPatient.Tag)
                    Else
                        MessageBox.Show("Error Saving !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            Else
                If MsgBox("Are you sure you want to Update?", MsgBoxStyle.OkCancel, "Comfirm") = MsgBoxResult.Ok Then
                    If UpdateClinic() = True Then
                        MessageBox.Show("Successfully Update!", "User Updating")
                        LoadClinicByPatientID(lnkPatient.Tag)
                    Else
                        MessageBox.Show("Error Updating !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Sub lblDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblDelete.Click, PicDelete.Click
        Using objClinic As New BCL.BCLClinic(G_ConString)
            Try
                'Get the specific project selected in the ListView control
                If MessageBox.Show("Are you sure you want to Delete?", "Comfirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = DialogResult.OK Then
                    If objClinic.DeleteClinic(txtRgsNo.Text.Trim) = True Then
                        MessageBox.Show("Delete Successful !", "Delete!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        ClearScreen()
                    Else
                        MessageBox.Show("Error To Delete!", "Delete!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        'If isSetPic = False Then
        '    MessageBox.Show("Please Choose Pic for Save!", "Need Pic To Save!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    Exit Sub
        'End If
        Using objClinic As New BCL.BCLClinic(G_ConString)
            Try
                If objClinic.IsAlreadySaveForClinic(txtRgsNo.Text.Trim) = True Then
                    If AddPicture() = True Then
                        MessageBox.Show("Successfully Save Picture!", "Save Pic", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        LoadPictureByClinicID(txtRgsNo.Text)
                        picParts.Image = Nothing
                        isSetPic = False
                    Else
                        MessageBox.Show("Error Saving Picture!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else
                    MessageBox.Show("Can't Save Picture Now !", "Save Pic", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub dgPic_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgPic.CellClick
        isSetPic = False
        btnSave.Enabled = False
        If dgPic.CurrentRow.Index < 0 Then
            mnuDelete.Enabled = False
            Exit Sub
        Else
            mnuDelete.Enabled = True
        End If
        txtPicRemark.Text = dgPic.Rows(dgPic.CurrentRow.Index).Cells(2).Value.ToString
        picParts.Load(Application.StartupPath & "\Pic\PatientParts\" & dgPic.Rows(dgPic.CurrentRow.Index).Cells(1).Value.ToString)
        lnkViewImage.Tag = Application.StartupPath & "\Pic\PatientParts\" & dgPic.Rows(dgPic.CurrentRow.Index).Cells(1).Value.ToString
    End Sub

    Private Sub lnkViewImage_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkViewImage.LinkClicked
        If lnkViewImage.Tag = "" Then
            MessageBox.Show("Can show Image !", "Image", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            Dim p As New System.Diagnostics.Process
            Dim s As New System.Diagnostics.ProcessStartInfo(lnkViewImage.Tag)
            s.UseShellExecute = True
            s.WindowStyle = ProcessWindowStyle.Maximized
            p.StartInfo = s
            p.Start()
        End If
    End Sub

    Sub LoadClinicByPatientID(ByVal PatientID As String)
        Using objClinic As New BCL.BCLClinic(G_ConString)
            Try
                'Get the specific project selected in the ListView control
                objDataSet = objClinic.GetClinicByPatientIdAllShowField(PatientID)
                'Populate the Project Details section
                dgClinicHis.DataSource = Nothing
                dgClinicHis.DataSource = objDataSet.Tables("Clinics")
                If dgClinicHis.RowCount = 0 Then
                    mnuView.Enabled = False
                Else
                    mnuView.Enabled = True
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub mnuView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuView.Click
        If dgClinicHis.CurrentRow.Index < 0 Then Exit Sub
        LoadClinicByCliNicID(dgClinicHis.Rows(dgClinicHis.CurrentRow.Index).Cells(1).Value.ToString)
    End Sub

    Private Sub dgClinicHis_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgClinicHis.CellClick
        If dgClinicHis.CurrentRow.Index < 0 Then Exit Sub
        LoadClinicByCliNicID(dgClinicHis.Rows(dgClinicHis.CurrentRow.Index).Cells(1).Value.ToString)
    End Sub

    Private Sub lnkPatient_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkPatient.LinkClicked
        G_TempVariableString = lnkPatient.Tag
        frmPatientEntry.ShowDialog()
    End Sub


    Private Sub mnuDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDelete.Click
        If dgPic.Rows.Count = 0 Then Exit Sub
        If MessageBox.Show("Are you sure you want to delete?", "Comfirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
            Using objClinic As New BCL.BCLClinic(G_ConString)
                Try
                    'Get the specific project selected in the ListView control
                    If objClinic.DeletePic(dgPic.Rows(dgPic.CurrentRow.Index).Cells(0).Value.ToString) Then
                        MessageBox.Show("Successfully Delete!", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        DeletePic(dgPic.Rows(dgPic.CurrentRow.Index).Cells(1).Value.ToString)
                        LoadPictureByClinicID(txtRgsNo.Text.Trim)
                        txtPicRemark.Text = ""
                        picParts.Image = Nothing
                    End If
                Catch ExceptionErr As Exception
                    MessageBox.Show(ExceptionErr.Message.ToString)
                End Try
            End Using
        End If
    End Sub

    Sub DeletePic(ByVal picName As String)
        Dim myDeleteFile As String
        myDeleteFile = Application.StartupPath & "\Pic\PatientParts\" & picName
        Debug.Print(myDeleteFile)
        If File.Exists(myDeleteFile) Then
            File.Delete(myDeleteFile)
        End If
    End Sub

End Class