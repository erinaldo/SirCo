Public Class frmDoctorEntry
    Private objDataSet As Data.DataSet
    Private objDoctorDataSet As DataSet
    Private objDoctor As BCL.BCLPuesto
#Region "Validate Functions"

    Function CheckControl() As Boolean
        If IsInvalidField(txtDoctorID, ep, "Doctor Id is Required !") = False Then Exit Function
        If IsInvalidField(txtDoctorName, ep, "Doctor Name is Required!") = False Then Exit Function
        CheckControl = True
    End Function

#End Region

#Region "Doctor Functions"

    Function LoadMaxDoctorID() As Integer
        Using objDoctor As New BCL.BCLPuesto(G_ConString)
            Try
                'Clear previous bindings
                Return objDoctor.GetMaxDoctorID
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function

    Function AddDoctor() As Boolean
        Using objDoctor As New BCL.BCLPuesto(G_ConString)
            'Get a new Project DataSet
            objDataSet = objDoctor.GetNewDoctorDS
            'Initialize a datarow object from the Project DataSet
            Dim objDataRow As Data.DataRow = _
                objDataSet.Tables("Doctor").NewRow
            'Set the values in the DataRow
            objDataRow.Item("Puesto_ID") = Trim(txtDoctorID.Text)
            objDataRow.Item("Puesto_Name") = Trim(txtDoctorName.Text)
            objDataRow.Item("Descripcion") = Trim(TxtDesc.Text)

            'Add the DataRow to the DataSet
            objDataSet.Tables("Doctor").Rows.Add(objDataRow)
            'Add the Project
            If Not objDoctor.AddDoctor(objDataSet) Then
                Throw New Exception("Insertar Puesto Falló")
            Else
                AddDoctor = True
            End If
        End Using
    End Function

    Function UpdateDoctor() As Boolean
        Using objDoctor As New BCL.BCLPuesto(G_ConString)
            'Get a new Project DataSet
            objDataSet = objDoctor.GetNewDoctorDS
            'Initialize a datarow object from the Project DataSet
            Dim objDataRow As Data.DataRow = _
                objDataSet.Tables("Doctor").NewRow
            'Set the values in the DataRow
            objDataRow.Item("Puesto_ID") = Trim(txtDoctorID.Text)
            objDataRow.Item("Puesto_Name") = Trim(txtDoctorName.Text)
            objDataRow.Item("Descripcion") = Trim(TxtDesc.Text)

            'Add the DataRow to the DataSet
            objDataSet.Tables("Doctor").Rows.Add(objDataRow)
            'Add the Project
            If Not objDoctor.UpdateDoctor(objDataSet) Then
                Throw New Exception("Actualización Puesto Falló")
            Else
                UpdateDoctor = True
            End If
        End Using
    End Function

    Public Function DeleteDoctor(ByVal Puesto_ID As Integer) As Boolean
        Try
            'Call the data component to delete the project
            Return objDoctor.DeleteDoctor(Puesto_ID)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Function IsAlreadyExistDoctorID(ByVal Doctor_ID As Integer) As Boolean
        Using objDoctor As New BCL.BCLPuesto(G_ConString)
            Return objDoctor.IsAlreadyExistPuestoID(txtDoctorID.Text.Trim)
        End Using
    End Function

#End Region
    Sub ShowDoctorData(ByVal objDoctorDataSet As DataSet)
        txtDoctorID.Text = objDoctorDataSet.Tables("Doctor").Rows(0).Item(0).ToString
        txtDoctorName.Text = objDoctorDataSet.Tables("Doctor").Rows(0).Item(1).ToString
        TxtDesc.Text = objDoctorDataSet.Tables("Doctor").Rows(0).Item(2).ToString
    End Sub

    Sub LoadDoctorByDoctorID(ByVal Puesto_ID As Integer)
        Using objDoctor As New BCL.BCLPuesto(G_ConString)
            Try
                'Get the specific project selected in the ListView control
                objDataSet = objDoctor.GetDoctorById(Puesto_ID)
                'Populate the Project Details section
                ShowDoctorData(objDataSet)
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub picExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picExit.Click, lblExit.Click, CloseToolStripMenuItem.Click
        If MessageBox.Show("Estas Seguro de Salir ?", "Comfirmar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
            Me.Dispose()
            Me.Close()
        End If
    End Sub

    Private Sub PicSaveAndClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicSaveAndClose.Click, lblSave.Click
        If CheckControl() = False Then Exit Sub
        Try
            If IsAlreadyExistDoctorID(txtDoctorID.Text.Trim) = False Then
                If MsgBox("Estas Seguro de Grabar ?", MsgBoxStyle.OkCancel, "Comfirmar") = MsgBoxResult.Ok Then
                    If AddDoctor() = True Then
                        MessageBox.Show("Grabado Exitoso!", "Puesto Grabado")
                        Me.Close()
                        Me.Dispose()
                    Else
                        MessageBox.Show("Error Grabado!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            Else
                If MsgBox("Estas Seguro de Actualizar?", MsgBoxStyle.OkCancel, "Comfirmar") = MsgBoxResult.Ok Then
                    If UpdateDoctor() = True Then
                        MessageBox.Show("Actualizacion Exitosa!", "Puesto Actualizado")
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


    Private Sub frmDoctorEntry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If G_TempVariableString.Length = 0 Then
            txtDoctorID.Text = LoadMaxDoctorID()
            txtDoctorName.Focus()
        Else
            txtDoctorID.Enabled = False
            LoadDoctorByDoctorID(CInt(G_TempVariableString))
            txtDoctorName.Focus()
        End If
    End Sub

    Private Sub PicDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicDelete.Click, lblDelete.Click, DeleteToolStripMenuItem.Click
        Using objDoctor As New BCL.BCLPuesto(G_ConString)
            Try
                'Get the specific project selected in the ListView control
                If MessageBox.Show("Estas seguro de Eliminar ?", "Eliminar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = DialogResult.OK Then
                    If objDoctor.DeleteDoctor(txtDoctorID.Text.Trim) = True Then
                        MessageBox.Show("Eliminación Exitosa! ", "Eliminar!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.Dispose()
                        Me.Close()
                    Else
                        MessageBox.Show("Error al eliminar!", "Eliminar!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

End Class