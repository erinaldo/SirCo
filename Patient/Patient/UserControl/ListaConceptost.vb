Public Class DoctorList

    Private objDataSet As Data.DataSet
    Private objDoctorDataSet As DataSet
    Private objDoctor As BCL.BCLPuesto

    Sub HideDataGridColumn()
        dgDoctor.Columns(1).Width = 600

        dgDoctor.Columns(0).HeaderText = "Puesto ID"
        dgDoctor.Columns(1).HeaderText = "Nombre"
        
        dgDoctor.Columns(1).Width = 500
        dgDoctor.Columns(2).Width = 1100
        'dgDoctor.Columns(9).Visible = False
        
    End Sub
    Sub MenuEnable()
        If dgDoctor.Rows.Count = 0 Then
            mnuDelete.Enabled = False
            mnuEdit.Enabled = False
            mnuPrint.Enabled = False
        Else
            mnuDelete.Enabled = True
            mnuEdit.Enabled = True
            mnuPrint.Enabled = True
        End If
    End Sub
    Sub LoadDoctor()
        Using objDoctor As New BCL.BCLPuesto(G_ConString)
            Try
                'Get the specific project selected in the ListView control
                objDataSet = objDoctor.GetDoctor
                'Populate the Project Details section
                dgDoctor.DataSource = Nothing
                dgDoctor.DataSource = objDataSet.Tables("Doctors")
                HideDataGridColumn()

                MenuEnable()
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Sub LoadDoctorByDoctorID(ByVal Doctor_ID As Integer)
        Using objDoctor As New BCL.BCLPuesto(G_ConString)
            Try
                'Get the specific project selected in the ListView control
                objDataSet = objDoctor.GetDoctorById(Doctor_ID)
                'Populate the Project Details section
                dgDoctor.DataSource = Nothing
                dgDoctor.DataSource = objDataSet.Tables("Doctor")
                MenuEnable()
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub DoctorList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadDoctor()
        Me.Dock = DockStyle.Fill
    End Sub

    Private Sub mnuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEdit.Click
        G_TempVariableString = ""
        If dgDoctor.CurrentRow.Index < 0 Then Exit Sub
        G_TempVariableString = dgDoctor.Rows(dgDoctor.CurrentRow.Index).Cells(0).Value.ToString
        frmDoctorEntry.ShowDialog()
        LoadDoctor()
    End Sub

    Private Sub mnuNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNew.Click
        G_TempVariableString = ""
        frmDoctorEntry.ShowDialog()
        LoadDoctor()
    End Sub

    Private Sub mnuDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDelete.Click
        Using objDoctor As New BCL.BCLPuesto(G_ConString)
            Try
                'Get the specific project selected in the ListView control
                If MessageBox.Show("Estas Seguro de Eliminar?", "Comfirmar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = DialogResult.OK Then
                    If objDoctor.DeleteDoctor(dgDoctor.Rows(dgDoctor.CurrentRow.Index).Cells(0).Value.ToString) = True Then
                        MessageBox.Show("Eliminación Exitosa !", "Eliminado!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        LoadDoctor()
                    Else
                        MessageBox.Show("Error al Eliminar!", "Eliminar!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub dgPatient_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDoctor.CellContentClick

    End Sub

    Private Sub csmDoctor_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles csmDoctor.Opening

    End Sub
End Class
