Imports System.IO

Public Class PatientList
    Private objDataSet As Data.DataSet
    Private objPatientDataSet As DataSet
    Private objPatient As BCL.BCLPatient

    Public SelectPatientId As String

    Sub HideDataGridColumn()
        dgPatient.Columns(0).HeaderText = "Empleado ID"
        dgPatient.Columns(1).HeaderText = "Nombre"
        dgPatient.Columns(2).HeaderText = "NRC Number"
        dgPatient.Columns(5).HeaderText = "Telefono Casa"
        dgPatient.Columns(6).HeaderText = "Telefono Oficina"
        dgPatient.Columns(7).HeaderText = "Celular"
        dgPatient.Columns(15).HeaderText = "Nombre Departamento"
        dgPatient.Columns(8).Visible = False
        dgPatient.Columns(9).Visible = False
        dgPatient.Columns(10).Visible = False
        dgPatient.Columns(11).Visible = False
        dgPatient.Columns(12).Visible = False
        dgPatient.Columns(13).Visible = False
        dgPatient.Columns(14).Visible = False
    End Sub
    Sub LoadPatient()
        Using objPatient As New BCL.BCLPatient(G_ConString)
            Try
                'Get the specific project selected in the ListView control
                objDataSet = objPatient.GetPatients()
                'Populate the Project Details section
                dgPatient.DataSource = Nothing
                dgPatient.DataSource = objDataSet.Tables("Patients")
                HideDataGridColumn()
                MenuEnable()
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
                dgPatient.DataSource = Nothing
                dgPatient.DataSource = objDataSet.Tables("Patient")
                HideDataGridColumn()
                MenuEnable()
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Sub LoadPatientBySectionName(ByVal SectionName As String)
        Using objPatient As New BCL.BCLPatient(G_ConString)
            Try
                'Get the specific project selected in the ListView control
                objDataSet = objPatient.GetPatientBySectionName(SectionName)
                'Populate the Project Details section
                dgPatient.DataSource = Nothing
                dgPatient.DataSource = objDataSet.Tables("Patients")
                HideDataGridColumn()
                MenuEnable()
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Sub LoadPatientByPatientName(ByVal PatientName As String)
        Using objPatient As New BCL.BCLPatient(G_ConString)
            Try
                'Get the specific project selected in the ListView control
                objDataSet = objPatient.GetPatientByName(PatientName)
                'Populate the Project Details section
                dgPatient.DataSource = Nothing
                dgPatient.DataSource = objDataSet.Tables("Patients")
                HideDataGridColumn()
                MenuEnable()
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub
    Sub MenuEnable()
        If dgPatient.Rows.Count = 0 Then
            mnuDelete.Enabled = False
            mnuEdit.Enabled = False
            mnuPrint.Enabled = False
        Else
            mnuDelete.Enabled = True
            mnuEdit.Enabled = True
            mnuPrint.Enabled = True
        End If
    End Sub
    Sub LoadPatientByNRC(ByVal NRCNo As String)
        Using objPatient As New BCL.BCLPatient(G_ConString)
            Try
                'Get the specific project selected in the ListView control
                objDataSet = objPatient.GetPatientByNRC(NRCNo)
                'Populate the Project Details section
                dgPatient.DataSource = Nothing
                dgPatient.DataSource = objDataSet.Tables("Patients")
                HideDataGridColumn()
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub PatientList_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cboSearchBy.SelectedIndex = 0
        Me.Dock = DockStyle.Fill
        LoadPatient()
        If dgPatient.Rows.Count <= 0 Then Exit Sub
        SelectPatientId = dgPatient.Rows(dgPatient.CurrentRow.Index).Cells(0).Value
    End Sub

    Function DataValidate(ByVal Index As Byte) As Boolean
        Select Case Index
            Case 0 'Select One
                MessageBox.Show("Por Favor Seleccione Tipo de Busqueda!", "Validacion de Datos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cboSearchBy.Focus()
                Exit Function
            Case 1 'Search With PatientID
                If IsNumeric(txtSearch.Text) = False Then
                    MessageBox.Show("Por favor  EmpleadoID debe ser numerico!", "Validacion de Datos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtSearch.Focus()
                    Exit Function
                End If
                If txtSearch.Text.Trim.Length = 0 Then
                    MessageBox.Show("Por favor Teclee EmpleadoID para buscar!", "Validacion de Datos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtSearch.Focus()
                    Exit Function
                End If
            Case 2 'Search With Patient Name
                If txtSearch.Text.Trim.Length = 0 Then
                    MessageBox.Show("Por favor Teclee Nombre del empleado pára Buscar!", "Validacion de Datos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtSearch.Focus()
                    Exit Function
                End If
            Case 3 'Search With NrcNo
                If txtSearch.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please Type Patient's NRC number To Search!", "Validacion de Datos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtSearch.Focus()
                    Exit Function
                End If
            Case 4 'Search With Section Name
                If txtSearch.Text.Trim.Length = 0 Then
                    MessageBox.Show("Por favor teclee Departamento para buscar!", "Validacion de Datos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtSearch.Focus()
                    Exit Function
                End If
        End Select
        DataValidate = True
    End Function

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If DataValidate(cboSearchBy.SelectedIndex) = False Then Exit Sub
        Select Case cboSearchBy.SelectedIndex
            Case 1
                LoadPatientByPatientID(txtSearch.Text.Trim)
            Case 2
                LoadPatientByPatientName("%" & txtSearch.Text.Trim & "%")
                'Case 3
                '   LoadPatientByNRC("%" & txtSearch.Text.Trim & "%")
            Case 3
                LoadPatientBySectionName("%" & txtSearch.Text.Trim & "%")
        End Select
    End Sub

    Private Sub mnuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEdit.Click
        G_TempVariableString = ""
        If dgPatient.CurrentRow.Index < 0 Then Exit Sub
        G_TempVariableString = dgPatient.Rows(dgPatient.CurrentRow.Index).Cells(0).Value.ToString


        'frmPatientClinicCombine.ShowDialog()
        frmPatientEntry.ShowDialog()
        LoadPatient()
    End Sub

    Private Sub mnuNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNew.Click
        G_TempVariableString = ""
        'frmPatientClinicCombine.ShowDialog()
        frmPatientEntry.ShowDialog()
        LoadPatient()
    End Sub
    Sub DeletePic(ByVal picName As String)
        Dim myDeleteFile As String
        myDeleteFile = Application.StartupPath & "\Pic\Patient\" & picName & ".jpg"
        Debug.Print(myDeleteFile)
        If File.Exists(myDeleteFile) Then
            File.Delete(myDeleteFile)
        End If
    End Sub
    Private Sub mnuDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDelete.Click
        Using objPatient As New BCL.BCLPatient(G_ConString)
            Try
                'Get the specific project selected in the ListView control
                If MessageBox.Show("Estas Seguro de Elimnarlo?", "Confirmar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = DialogResult.OK Then
                    If objPatient.DeletePatient(dgPatient.Rows(dgPatient.CurrentRow.Index).Cells(0).Value.ToString) = True Then
                        MessageBox.Show("Eliminación Exitosa!", "Eliminar!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        DeletePic(dgPatient.Rows(dgPatient.CurrentRow.Index).Cells(0).Value.ToString)
                        LoadPatient()
                    Else
                        MessageBox.Show("Error al Eliminar!", "Eliminar!", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
        LoadPatient()
    End Sub

    Private Sub dgPatient_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgPatient.CellContentClick
        'If dgPatient.Rows.Count <= 0 Then Exit Sub
        'SelectPatientId = dgPatient.Rows(dgPatient.CurrentRow.Index).Cells(0).Value
    End Sub

    Private Sub mnuPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPrint.Click
        frmReportsBrowser.ReportIndex = 1
        frmReportsBrowser.ShowDialog()
    End Sub

    Private Sub dgPatient_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgPatient.Click
        If dgPatient.Rows.Count <= 0 Then Exit Sub
        SelectPatientId = dgPatient.Rows(dgPatient.CurrentRow.Index).Cells(0).Value
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
End Class
