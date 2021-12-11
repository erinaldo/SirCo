Imports System.IO
Imports System

Public Class frmPatientEntry
    Private objDataSet As Data.DataSet
    Private objPatientDataSet As DataSet
    Private objSection As BCL.BCLSection
    Private objPatient As BCL.BCLPatient
    Private myFileName As String
    Private isSetPic As Boolean

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
        Dim PuestoDataSet As New DataSet
        Using objSection As New BCL.BCLPuesto(G_ConString)
            Try
                'Clear previous bindings
                PuestoDataSet = objSection.GetDoctor
                CboPuesto.DataSource = PuestoDataSet.Tables("Doctors")
                CboPuesto.ValueMember = PuestoDataSet.Tables("Doctors").Columns(0).ToString
                CboPuesto.DisplayMember = PuestoDataSet.Tables("Doctors").Columns(1).ToString
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

    Sub ShowPatientData(ByVal PatientDataset As DataSet)
        Dim PicPath As String

        txtPatientID.Text = PatientDataset.Tables("Patients").Rows(0).Item(0).ToString
        txtPatientName.Text = PatientDataset.Tables("Patients").Rows(0).Item(1).ToString
        txtNrcNo.Text = PatientDataset.Tables("Patients").Rows(0).Item(2).ToString
        txtAddress.Text = PatientDataset.Tables("Patients").Rows(0).Item(3).ToString
        dtpDOB.Text = PatientDataset.Tables("Patients").Rows(0).Item(4).ToString
        txtPhone_R.Text = PatientDataset.Tables("Patients").Rows(0).Item(5).ToString
        txtPhone_O.Text = PatientDataset.Tables("Patients").Rows(0).Item(6).ToString
        txtPhone_Hp.Text = PatientDataset.Tables("Patients").Rows(0).Item(7).ToString
        cboMartialStatus.SelectedIndex = PatientDataset.Tables("Patients").Rows(0).Item(8).ToString
        cboBloodGroup.SelectedIndex = PatientDataset.Tables("Patients").Rows(0).Item(9).ToString
        txtContact_Phone.Text = PatientDataset.Tables("Patients").Rows(0).Item(10).ToString

        txtRemark.Text = PatientDataset.Tables("Patients").Rows(0).Item(11).ToString
        PicPath = PatientDataset.Tables("Patients").Rows(0).Item(12).ToString
        If PicPath.Length > 0 Then
            If File.Exists(Application.StartupPath & "\Pic\Patient\" & PicPath) Then
                picPatient.Load(Application.StartupPath & "\Pic\Patient\" & PicPath)
            End If
        End If
        
        cboSection.SelectedValue = PatientDataset.Tables("patients").Rows(0).Item(13).ToString
        CboPuesto.SelectedValue = PatientDataset.Tables("patients").Rows(0).Item(14).ToString
        CheckBox1.Checked = IIf(PatientDataset.Tables("patients").Rows(0).Item(15).ToString = "S", True, False)
        CboBono.SelectedIndex = PatientDataset.Tables("patients").Rows(0).Item(16).ToString

    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub frmPatientEntry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            LoadSectionCombo()
        myFileName = ""
        isSetPic = False
        If G_TempVariableString.Length = 0 Then
            txtPatientID.Enabled = True
            cboBloodGroup.SelectedIndex = 0
            cboMartialStatus.SelectedIndex = 0
            ' txtPatientName.Focus()
        Else
            txtPatientID.Enabled = False
            LoadPatientByPatientID(G_TempVariableString)
            txtPatientName.Focus()
        End If
        'txtPatientName.Focus()
        SendKeys.Send("{Tab}")
    End Sub

    Private Sub lnkPictureBwr_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkPictureBwr.LinkClicked
        'SaveFileDialog1.ShowDialog()
        'oflg.Filter = "Support graphics format (*.bmp,*.jpg,*.gif,*.png)|*.bmp;*.jpg;*.gif;*.jpeg;*.png"
        oflg.Filter = "Formatos de Grafico Soportado (*.jpg)|*.jpg"
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

    Sub SavePic(ByVal FilePath As String, ByVal TargetPath As String, ByVal FileName As String)
        File.Copy(FilePath, TargetPath & FileName, True)
    End Sub

    Sub DeletePic(ByVal picName As String)
        Dim myDeleteFile As String
        myDeleteFile = Application.StartupPath & "\Pic\Patient\" & picName & ".jpg"
        Debug.Print(myDeleteFile)
        If File.Exists(myDeleteFile) Then
            File.Delete(myDeleteFile)
        End If
    End Sub
#Region "Validate Functions"
    Function CheckControl() As Boolean
        If IsInvalidField(txtPatientName, ep, "Nombre de empleado es Requerido !") = False Then Exit Function
        If IsInvalidField(txtNrcNo, ep, "No. Seg Soc es Requerido !") = False Then Exit Function
        If IsInvalidField(txtAddress, ep, "Direccion es Requerida!") = False Then Exit Function
        'If cboMartialStatus.SelectedIndex <= 0 Then
        '    MessageBox.Show("Por favor Seleccione Estado Civil!", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    cboMartialStatus.Focus()
        '    Exit Function
        'End If
        'If cboBloodGroup.SelectedIndex <= 0 Then
        '    MessageBox.Show("Por favor Seleccione Grupo Sanguíneo!", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    cboBloodGroup.Focus()
        '    Exit Function
        'End If
        If cboSection.SelectedIndex < 0 Then
            MessageBox.Show("Por favor Seleccione Departamento!", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboSection.Focus()
            Exit Function
        End If
        If CboPuesto.SelectedIndex < 0 Then
            MessageBox.Show("Por favor Seleccione Puesto!", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            CboPuesto.Focus()
            Exit Function
        End If
        If CboBono.SelectedIndex < 0 Then
            MessageBox.Show("Por favor Seleccione Nivel Bono!", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            CboBono.Focus()
            Exit Function
        End If
        CheckControl = True
    End Function
#End Region

#Region "Patient Functions"

    Function LoadMaxPatientID() As Integer
        Using objPatient As New BCL.BCLPatient(G_ConString)
            Try
                'Clear previous bindings
                Return objPatient.GetMaxPatientID
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
            objDataRow.Item("Empleado_ID") = Trim(txtPatientID.Text)
            objDataRow.Item("Empleado_Name") = Trim(txtPatientName.Text)
            objDataRow.Item("NRCNo") = Trim(txtNrcNo.Text)
            objDataRow.Item("Address") = Trim(txtAddress.Text)
            objDataRow.Item("DOB") = dtpDOB.Text
            objDataRow.Item("Phone_R") = Trim(txtPhone_R.Text)
            objDataRow.Item("Phone_O") = Trim(txtPhone_O.Text)
            objDataRow.Item("Phone_HP") = Trim(txtPhone_Hp.Text)
            objDataRow.Item("MaritalStatus") = Trim(cboMartialStatus.SelectedIndex)
            objDataRow.Item("BloodGroup") = Trim(cboBloodGroup.SelectedIndex)
            objDataRow.Item("ContactPhone") = Trim(txtContact_Phone.Text)

            objDataRow.Item("Remark") = Trim(txtRemark.Text)
            objDataRow.Item("PicName") = IIf(myFileName.Length > 0, txtPatientID.Text.Trim & ".jpg", "")

            objDataRow.Item("Section_ID") = cboSection.SelectedValue

            objDataRow.Item("Puesto_ID") = CboPuesto.SelectedValue
            objDataRow.Item("Activo") = IIf(CheckBox1.Checked, "S", "N")
            objDataRow.Item("Nivel_Bono") = Trim(CboBono.SelectedIndex)

            'Add the DataRow to the DataSet
            objDataSet.Tables("Patient").Rows.Add(objDataRow)
            'Add the Project
            If Not objPatient.AddPatient(objDataSet) Then
                Throw New Exception("Insertar Nuevo Empleado Fallo")
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
            objDataRow.Item("Empleado_ID") = Trim(txtPatientID.Text)
            objDataRow.Item("Empleado_Name") = Trim(txtPatientName.Text)
            objDataRow.Item("NRCNo") = Trim(txtNrcNo.Text)
            objDataRow.Item("Address") = Trim(txtAddress.Text)
            objDataRow.Item("DOB") = dtpDOB.Text
            objDataRow.Item("Phone_R") = Trim(txtPhone_R.Text)
            objDataRow.Item("Phone_O") = Trim(txtPhone_O.Text)
            objDataRow.Item("Phone_HP") = Trim(txtPhone_Hp.Text)
            objDataRow.Item("MaritalStatus") = Trim(cboMartialStatus.SelectedIndex)
            objDataRow.Item("BloodGroup") = Trim(cboBloodGroup.SelectedIndex)
            objDataRow.Item("ContactPhone") = Trim(txtContact_Phone.Text)
            objDataRow.Item("Remark") = Trim(txtRemark.Text)
            objDataRow.Item("PicName") = txtPatientID.Text.Trim & ".jpg"
            objDataRow.Item("Section_ID") = cboSection.SelectedValue

            objDataRow.Item("Puesto_ID") = CboPuesto.SelectedValue
            objDataRow.Item("Activo") = IIf(CheckBox1.Checked, "S", "N")
            objDataRow.Item("Nivel_Bono") = Trim(CboBono.SelectedIndex)

            'Add the DataRow to the DataSet
            objDataSet.Tables("Patient").Rows.Add(objDataRow)
            'Add the Project
            If Not objPatient.UpdatePatient(objDataSet) Then
                Throw New Exception("Actualizacion Empleado Fallida")
            Else
                UpdatePatient = True
            End If
        End Using
    End Function

    Public Function DeletePatient(ByVal PatientID As Integer) As Boolean
        Try
            'Call the data component to delete the project
            Return objPatient.DeletePatient(PatientID)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


#End Region

    Function IsAlreadyExistPatientID(ByVal PatientID As String) As Boolean
        Using objPatient As New BCL.BCLPatient(G_ConString)
            Return objPatient.IsAlreadyExistPatientID(txtPatientID.Text.Trim)
        End Using
    End Function

    Private Sub PicSaveAndClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicSaveAndClose.Click, lblSave.Click, mnuSaveAndClose.Click
        If CheckControl() = False Then Exit Sub

        Try
            If IsAlreadyExistPatientID(txtPatientID.Text.Trim) = False Then
                If MsgBox("Estas Seguro de Grabar?", MsgBoxStyle.OkCancel, "Comfirmar") = MsgBoxResult.Ok Then
                    If AddPatient() = True Then
                        MessageBox.Show("Actualización Exitosa!", "Empleado Grabado")
                        If myFileName.Trim.Length > 0 And isSetPic = True Then SavePic(myFileName, Application.StartupPath & "\Pic\Patient\", txtPatientID.Text.Trim & ".jpg")
                        Me.Close()
                        Me.Dispose()
                    Else
                        MessageBox.Show("Error Grabando !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            Else
                'existente
                If txtPatientID.Enabled = True Then
                    MessageBox.Show("El Empleado ID ya Existe !", "Ya Existe", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                If MsgBox("Estas seguro de Actualizar?", MsgBoxStyle.OkCancel, "Comfirmar") = MsgBoxResult.Ok Then
                    If UpdatePatient() = True Then
                        MessageBox.Show("Actualización Exitosa!", "Actualizando Empleado")
                        If myFileName.Trim.Length > 0 And isSetPic = True Then SavePic(myFileName, Application.StartupPath & "\Pic\Patient\", txtPatientID.Text.Trim & ".jpg")
                        Me.Close()
                        Me.Dispose()
                    Else
                        MessageBox.Show("Error Actualizando !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Sub lblExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblExit.Click, picExit.Click, mnuClose.Click
        If MessageBox.Show("Estas seguro de Salir?", "Confirmar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
            Me.Dispose()
            Me.Close()
        End If
    End Sub

    Private Sub lblDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblDelete.Click, PicDelete.Click, mnuDelete.Click
        Using objPatient As New BCL.BCLPatient(G_ConString)
            Try
                'Get the specific project selected in the ListView control
                If IsAlreadyExistPatientID(txtPatientID.Text.Trim) = False Then
                    MessageBox.Show("El Empleado no Existe!", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
                If MessageBox.Show("Estas Seguro de Eliminar el Empleado?", "Comfirmar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = DialogResult.OK Then
                    If objPatient.DeletePatient(txtPatientID.Text.Trim) = True Then
                        MessageBox.Show("Eliminación Exitosa!", "Eliminar!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        DeletePic(txtPatientID.Text.Trim)
                        Me.Dispose()
                        Me.Close()
                    Else
                        MessageBox.Show("Error al Eliminar!", "Eliminar!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub cboSection_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSection.SelectedIndexChanged

    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
End Class