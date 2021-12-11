Imports System.IO
Imports System
Public Class frmPatientClinicCombine
    Private objDataSet As Data.DataSet
    Private objPatientDataSet As DataSet
    Private objSection As BCL.BCLSection
    Private objPatient As BCL.BCLPatient
    Private myFileName As String
    Private isSetPic As Boolean

#Region "Validate Functions"
    Function CheckControl() As Boolean
        If IsInvalidField(txtPatientID, ep, "Patient Id is Required!") = False Then Exit Function
        If IsInvalidField(txtPatientName, ep, "Patient Name is Required !") = False Then Exit Function
        If IsInvalidField(txtNrcNo, ep, "Nrc Number is Required !") = False Then Exit Function
        If IsInvalidField(txtAddress, ep, "Address is Required !") = False Then Exit Function
        If cboMartialStatus.SelectedIndex <= 0 Then
            MessageBox.Show("Please choose Martial Status!", "Data Require", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboMartialStatus.Focus()
            Exit Function
        End If
        If cboBloodGroup.SelectedIndex <= 0 Then
            MessageBox.Show("Please choose Blood Gruop!", "Data Require", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboBloodGroup.Focus()
            Exit Function
        End If
        If cboSection.SelectedIndex < 0 Then
            MessageBox.Show("Please choose Section!", "Data Require", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboSection.Focus()
            Exit Function
        End If
        CheckControl = True
    End Function

    Function CheckClinicData() As Boolean
        'Must Do IT
        If IsInvalidField(txtDrugAllergy, ep, "Drug Allergy Name is Required !") = False Then Exit Function
        If IsInvalidField(txtHistory, ep, "History is Required !") = False Then Exit Function
        If IsInvalidField(txtBW, ep, "BW is Required !") = False Then Exit Function
        If IsInvalidField(txtPR, ep, "PR is Required !") = False Then Exit Function
        If IsInvalidField(txtBP, ep, "BP is Required !") = False Then Exit Function
        If IsInvalidField(txtDiagnosis, ep, "Diagnosis is Required !") = False Then Exit Function
        If IsInvalidField(txtTreatement, ep, "Treatment is Required !") = False Then Exit Function
        If IsInvalidField(txtInvestigation, ep, "Investigation is Required !") = False Then Exit Function
        If IsInvalidField(txtOthers, ep, "Others is Required !") = False Then Exit Function


        If cboDoctor.SelectedIndex < 0 Then
            MessageBox.Show("Please choose Doctory Name!", "Data Require", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboDoctor.Focus()
            Exit Function
        End If
        CheckClinicData = True
    End Function
#End Region

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

    Function IsAlreadyExistPatientID(ByVal PatientID As String) As Boolean
        Using objPatient As New BCL.BCLPatient(G_ConString)
            Return objPatient.IsAlreadyExistPatientID(txtPatientID.Text.Trim)
        End Using
    End Function

    Sub LoadClinicByCliNicID(ByVal ClinicID As Integer)
        Using objClinic As New BCL.BCLClinic(G_ConString)
            Try
                'Get the specific project selected in the ListView control
                objDataSet = objClinic.GetClinicById(ClinicID)
                'Populate the Project Details section
                If objDataSet.Tables("Clinic").Rows.Count > 0 Then ShowClinicData(objDataSet)
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
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

    Function AddPatient() As Boolean
        Using objPatient As New BCL.BCLPatient(G_ConString)
            'Get a new Project DataSet
            objDataSet = objPatient.GetNewPatientDS
            'Initialize a datarow object from the Project DataSet
            Dim objDataRow As Data.DataRow = _
                objDataSet.Tables("Patient").NewRow
            'Set the values in the DataRow
            objDataRow.Item("Patient_ID") = Trim(txtPatientID.Text)
            objDataRow.Item("Patient_Name") = Trim(txtPatientName.Text)
            objDataRow.Item("NRCNo") = Trim(txtNrcNo.Text)
            objDataRow.Item("Address") = Trim(txtAddress.Text)
            objDataRow.Item("DOB") = dtpDOB.Text
            objDataRow.Item("Phone_R") = Trim(txtPhone_R.Text)
            objDataRow.Item("Phone_O") = Trim(txtPhone_O.Text)
            objDataRow.Item("Phone_HP") = Trim(txtPhone_Hp.Text)
            objDataRow.Item("MaritalStatus") = Trim(cboMartialStatus.SelectedIndex)
            objDataRow.Item("BloodGroup") = Trim(cboBloodGroup.SelectedIndex)
            objDataRow.Item("ContactPhone") = Trim(txtContact_Phone.Text)
            objDataRow.Item("ContactPhoneII") = Trim(txtContact_PhoneII.Text)
            objDataRow.Item("Remark") = Trim(txtRemark.Text)
            objDataRow.Item("PicName") = IIf(myFileName.Length > 0, txtPatientID.Text.Trim & ".jpg", "")
            objDataRow.Item("Section_ID") = cboSection.SelectedValue
            'Add the DataRow to the DataSet
            objDataSet.Tables("Patient").Rows.Add(objDataRow)
            'Add the Project
            If Not objPatient.AddPatient(objDataSet) Then
                Throw New Exception("Insert Patient Failed")
            Else
                AddPatient = True
            End If
        End Using
    End Function

    Function UpdatePatient() As Boolean
        Using objPatient As New BCL.BCLPatient(G_ConString)
            'Get a new Project DataSet
            objDataSet = objPatient.GetNewPatientDS
            'Initialize a datarow object from the Project DataSet
            Dim objDataRow As Data.DataRow = _
                objDataSet.Tables("Patient").NewRow
            'Set the values in the DataRow
            objDataRow.Item("Patient_ID") = Trim(txtPatientID.Text)
            objDataRow.Item("Patient_Name") = Trim(txtPatientName.Text)
            objDataRow.Item("NRCNo") = Trim(txtNrcNo.Text)
            objDataRow.Item("Address") = Trim(txtAddress.Text)
            objDataRow.Item("DOB") = dtpDOB.Text
            objDataRow.Item("Phone_R") = Trim(txtPhone_R.Text)
            objDataRow.Item("Phone_O") = Trim(txtPhone_O.Text)
            objDataRow.Item("Phone_HP") = Trim(txtPhone_Hp.Text)
            objDataRow.Item("MaritalStatus") = Trim(cboMartialStatus.SelectedIndex)
            objDataRow.Item("BloodGroup") = Trim(cboBloodGroup.SelectedIndex)
            objDataRow.Item("ContactPhone") = Trim(txtContact_Phone.Text)
            objDataRow.Item("ContactPhoneII") = Trim(txtContact_PhoneII.Text)
            objDataRow.Item("Remark") = Trim(txtRemark.Text)
            objDataRow.Item("PicName") = txtPatientID.Text.Trim & ".jpg"
            objDataRow.Item("Section_ID") = cboSection.SelectedValue
            'Add the DataRow to the DataSet
            objDataSet.Tables("Patient").Rows.Add(objDataRow)
            'Add the Project
            If Not objPatient.UpdatePatient(objDataSet) Then
                Throw New Exception("Update Patient Failed")
            Else
                UpdatePatient = True
            End If
        End Using
    End Function

    Sub DeletePic(ByVal picName As String)
        Dim myDeleteFile As String
        myDeleteFile = Application.StartupPath & "\Pic\Patient\" & picName & ".jpg"
        Debug.Print(myDeleteFile)
        If File.Exists(myDeleteFile) Then
            File.Delete(myDeleteFile)
        End If
    End Sub

    Sub LoadSectionCombo()
        Dim SectionDataSet As New DataSet
        Using objSection As New BCL.BCLSection(G_ConString)
            Try
                'Clear previous bindings
                SectionDataSet = objSection.GetSection()
                cboSection.DataSource = SectionDataSet.Tables("Sections")
                cboSection.ValueMember = SectionDataSet.Tables("Sections").Columns(0).ToString
                cboSection.DisplayMember = SectionDataSet.Tables("Sections").Columns(1).ToString
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Sub LoadPatientByPatientID(ByVal PatientID As String)
        Using objPatient As New BCL.BCLPatient(G_ConString)
            Try
                'Get the specific project selected in the ListView control
                objDataSet = objPatient.GetPatientById(PatientID)
                'Populate the Project Details section
                ShowPatientData(objDataSet)
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Sub SavePic(ByVal FilePath As String, ByVal TargetPath As String, ByVal FileName As String)
        File.Copy(FilePath, TargetPath & FileName, True)
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

    Sub ShowClinicData(ByVal ClinicDataSet As DataSet)
        txtRgsNo.Text = ClinicDataSet.Tables("Clinic").Rows(0).Item(0).ToString
        'lnkPatient.Tag = ClinicDataSet.Tables("Clinic").Rows(0).Item(1).ToString
        'lnkPatient.Text = GetPatientName(lnkPatient.Tag)
        LoadClinicByPatientID(txtPatientID.Text)
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

    Sub ShowPatientData(ByVal PatientDataset As DataSet)
        txtPatientID.Enabled = False
        txtPatientID.Text = PatientDataset.Tables("Patient").Rows(0).Item(0).ToString
        txtPatientName.Text = PatientDataset.Tables("Patient").Rows(0).Item(1).ToString
        txtNrcNo.Text = PatientDataset.Tables("Patient").Rows(0).Item(2).ToString
        txtAddress.Text = PatientDataset.Tables("Patient").Rows(0).Item(3).ToString
        dtpDOB.Text = PatientDataset.Tables("Patient").Rows(0).Item(4).ToString
        txtPhone_R.Text = PatientDataset.Tables("Patient").Rows(0).Item(5).ToString
        txtPhone_O.Text = PatientDataset.Tables("Patient").Rows(0).Item(6).ToString
        txtPhone_Hp.Text = PatientDataset.Tables("Patient").Rows(0).Item(7).ToString
        cboMartialStatus.SelectedIndex = PatientDataset.Tables("Patient").Rows(0).Item(8).ToString
        cboBloodGroup.SelectedIndex = PatientDataset.Tables("Patient").Rows(0).Item(9).ToString
        txtContact_Phone.Text = PatientDataset.Tables("Patient").Rows(0).Item(10).ToString
        txtContact_PhoneII.Text = PatientDataset.Tables("Patient").Rows(0).Item(11).ToString
        txtRemark.Text = PatientDataset.Tables("Patient").Rows(0).Item(12).ToString
        If PatientDataset.Tables("Patient").Rows(0).Item(13).ToString.Length > 0 Then picPatient.Load(Application.StartupPath & "\Pic\Patient\" & PatientDataset.Tables("Patient").Rows(0).Item(13).ToString)
        cboSection.SelectedValue = PatientDataset.Tables("Patient").Rows(0).Item(14).ToString
    End Sub

    Sub ClearScreen()
        txtPatientID.Enabled = True
        txtPatientID.Text = ""
        txtPatientName.Text = ""
        txtNrcNo.Text = ""
        txtAddress.Text = ""
        dtpDOB.Text = Now.Date
        txtPhone_R.Text = ""
        txtPhone_O.Text = ""
        txtPhone_Hp.Text = ""
        cboMartialStatus.SelectedIndex = 0
        cboBloodGroup.SelectedIndex = 0
        txtContact_Phone.Text = ""
        txtContact_PhoneII.Text = ""
        txtRemark.Text = ""
        picPatient.Image = Nothing
        cboSection.SelectedIndex = 0
        txtPatientID.Focus()
    End Sub

    Private Sub frmPatientClinicCombine_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadSectionCombo()
        LoadDoctorCombo()
        myFileName = ""
        isSetPic = False
        'G_TempVariableString = ""

        If G_TempVariableString.Length = 0 Then
            txtPatientID.Enabled = True
            cboBloodGroup.SelectedIndex = 0
            cboMartialStatus.SelectedIndex = 0
            ' txtPatientName.Focus()
        Else
            txtPatientID.Enabled = False
            LoadPatientByPatientID(G_TempVariableString)
            LoadClinicByPatientID(G_TempVariableString)
            'txtPatientName.Focus()
        End If
        txtRgsNo.Text = LoadMaxClinicID()
        SendKeys.Send("{Tab}")
    End Sub

    Private Sub picExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picExit.Click, lblExit.Click
        If MessageBox.Show("Are you sure you want to exit?", "Comfirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
            Me.Dispose()
            Me.Close()
        End If
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click, Label33.Click
        If MessageBox.Show("Are you sure you want to exit?", "Comfirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
            Me.Dispose()
            Me.Close()
        End If
    End Sub

    Private Sub lnkPictureBwr_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkPictureBwr.LinkClicked
        'SaveFileDialog1.ShowDialog()
        'oflg.Filter = "Support graphics format (*.bmp,*.jpg,*.gif,*.png)|*.bmp;*.jpg;*.gif;*.jpeg;*.png"
        oflg.Filter = "Support graphics format (*.jpg)|*.jpg"
        oflg.FileName = ""
        myFileName = ""
        oflg.ShowDialog()
        myFileName = oflg.FileName
        If myFileName.Length = 0 Then Exit Sub
        picPatient.Load(myFileName)
        isSetPic = True
        'File.Copy(myFileName, Application.StartupPath & "\pic\patient\Test.jpg", True)
        'SavePic(myFileName, Application.StartupPath & "\Pic\Patient\", "Test.jpg")
    End Sub

    Private Sub PicSaveAndClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicSaveAndClose.Click, lblSave.Click
        If CheckControl() = False Then Exit Sub

        Try
            If IsAlreadyExistPatientID(txtPatientID.Text.Trim) = False Then
                If MsgBox("Are you sure you want to Save?", MsgBoxStyle.OkCancel, "Comfirm") = MsgBoxResult.Ok Then
                    If AddPatient() = True Then
                        MessageBox.Show("Successfully Saved!", "User Saving")
                        If myFileName.Trim.Length > 0 And isSetPic = True Then SavePic(myFileName, Application.StartupPath & "\Pic\Patient\", txtPatientID.Text.Trim & ".jpg")
                    Else
                        MessageBox.Show("Error Saving !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            Else
                If txtPatientID.Enabled = True Then
                    MessageBox.Show("This Patient ID is Already is Exist !", "Already Exist", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                If MsgBox("Are you sure you want to Update?", MsgBoxStyle.OkCancel, "Comfirm") = MsgBoxResult.Ok Then
                    If UpdatePatient() = True Then
                        MessageBox.Show("Successfully Update!", "User Updating")
                        If myFileName.Trim.Length > 0 And isSetPic = True Then SavePic(myFileName, Application.StartupPath & "\Pic\Patient\", txtPatientID.Text.Trim & ".jpg")
                    Else
                        MessageBox.Show("Error Updating !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Sub PicDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicDelete.Click, lblDelete.Click
        Using objPatient As New BCL.BCLPatient(G_ConString)
            Try
                'Get the specific project selected in the ListView control
                If IsAlreadyExistPatientID(txtPatientID.Text.Trim) = False Then
                    MessageBox.Show("This Patient is not present!", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
                If MessageBox.Show("Are you sure you want to Delete?", "Comfirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = DialogResult.OK Then
                    If objPatient.DeletePatient(txtPatientID.Text.Trim) = True Then
                        MessageBox.Show("Delete Successful !", "Delete!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        DeletePic(txtPatientID.Text.Trim)
                        Me.Dispose()
                        Me.Close()
                    Else
                        MessageBox.Show("Error To Delete!", "Delete!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub dgClinicHis_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgClinicHis.CellClick
        If dgClinicHis.CurrentRow.Index < 0 Then Exit Sub
        LoadClinicByCliNicID(dgClinicHis.Rows(dgClinicHis.CurrentRow.Index).Cells(1).Value.ToString)
    End Sub

    Private Sub lblNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblNew.Click, picNew.Click
        ClearScreen()
        ClearCinicData()
        LoadClinicByCliNicID(-1)
    End Sub

    Private Sub lnkClinicPictureBwr_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkClinicPictureBwr.LinkClicked
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

    Private Sub lblClinicNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblClinicNew.Click, picClinicNew.Click
        ''Muste Write This
        ClearCinicData()
    End Sub

    Sub ClearCinicData()
        txtRgsNo.Text = LoadMaxClinicID()
        'lnkPatient.Tag = ClinicDataSet.Tables("Clinic").Rows(0).Item(1).ToString
        'lnkPatient.Text = GetPatientName(lnkPatient.Tag)
        LoadClinicByPatientID(IIf(txtPatientID.Text = "", -1, txtPatientID.Text))
        cboDoctor.SelectedIndex = 0
        txtDiagnosis.Text = ""
        txtDrugAllergy.Text = ""
        txtBW.Text = ""
        txtPR.Text = ""
        txtBP.Text = ""
        txtHistory.Text = ""
        txtInvestigation.Text = ""
        txtTreatement.Text = ""
        dtpDate.Text = ""
        dtpContactDate.Text = Now.Date
        ' txtSection.Text = ClinicDataSet.Tables("Clinic").Rows(0).Item(13).ToString
        txtOthers.Text = ""
        LoadPictureByClinicID(-1)
        picParts.Image = Nothing
        txtPicRemark.Text = ""
    End Sub

    Private Sub lblClinicSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblClinicSave.Click, picSave.Click
        'This must be done
        If CheckClinicData() = False Then Exit Sub
        Try
            If IsAlreadyExistPatientID(txtPatientID.Text.Trim) = False Then
                MessageBox.Show("Please Patient Information First !", "Required!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            If IsAlreadyExistClinic_ID(txtRgsNo.Text.Trim) = False Then
                If MsgBox("Are you sure you want to Save?", MsgBoxStyle.OkCancel, "Comfirm") = MsgBoxResult.Ok Then
                    If AddClinic() = True Then
                        MessageBox.Show("Successfully Saved!", "User Saving")
                        LoadClinicByPatientID(txtPatientID.Text)
                    Else
                        MessageBox.Show("Error Saving !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            Else
                If MsgBox("Are you sure you want to Update?", MsgBoxStyle.OkCancel, "Comfirm") = MsgBoxResult.Ok Then
                    If UpdateClinic() = True Then
                        MessageBox.Show("Successfully Update!", "User Updating")
                        LoadClinicByPatientID(txtPatientID.Text)
                    Else
                        MessageBox.Show("Error Updating !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Function IsAlreadyExistClinic_ID(ByVal Clinic_ID As Integer) As Boolean
        Using objClinic As New BCL.BCLClinic(G_ConString)
            Return objClinic.IsAlreadyExistClinic_ID(Clinic_ID)
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
            objDataRow.Item("Patient_ID") = txtPatientID.Text
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

    Function UpdateClinic() As Boolean
        Using objClinic As New BCL.BCLClinic(G_ConString)
            'Get a new Project DataSet
            objDataSet = objClinic.GetNewClinicDS
            'Initialize a datarow object from the Project DataSet
            Dim objDataRow As Data.DataRow = _
                objDataSet.Tables("Clinic").NewRow
            'Set the values in the DataRow
            objDataRow.Item("Clinic_ID") = CInt(Trim(txtRgsNo.Text))
            objDataRow.Item("Patient_ID") = txtPatientID.Text
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

    Private Sub lblClinicDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblClinicDelete.Click
        Using objClinic As New BCL.BCLClinic(G_ConString)
            Try
                'Get the specific project selected in the ListView control
                If MessageBox.Show("Are you sure you want to Delete?", "Comfirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = DialogResult.OK Then
                    If objClinic.DeleteClinic(txtRgsNo.Text.Trim) = True Then
                        MessageBox.Show("Delete Successful !", "Delete!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        ClearCinicData()
                    Else
                        MessageBox.Show("Error To Delete!", "Delete!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub


End Class