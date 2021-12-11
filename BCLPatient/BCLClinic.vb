Public Class BCLClinic
    Implements IDisposable
    Private objDALClinic As DAL.DALClinic
    Private objDalPatient As DAL.DALPatient

    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
        objDALClinic = New DAL.DALClinic(Constring)
        objDalPatient = New DAL.DALPatient(Constring)
    End Sub
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALClinic.Dispose()
            objDALClinic = Nothing
            ' TODO: free shared unmanaged resources
        End If
        Me.disposedValue = True
    End Sub
    Function IsAlreadyExistClinic_ID(ByVal Clinic_ID As Integer) As Boolean
        Try
            Dim MyClinicDataset As New DataSet
            'Call the data component to get a specific group
            MyClinicDataset = objDALClinic.GetClinicByID(Clinic_ID)
            If MyClinicDataset.Tables("Clinic").Rows.Count > 0 Then
                IsAlreadyExistClinic_ID = True
            Else
                IsAlreadyExistClinic_ID = False
            End If
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

#Region " Public Clinic Functions "
    Public Function GetPatientName(ByVal PatientId As String) As String
        Try
            'Call the data component to get all groups
            Dim PatientDataset As New DataSet
            PatientDataset = objDalPatient.GetPatientByID(PatientId)
            If PatientDataset.Tables("Patient").Rows.Count > 0 Then
                Return PatientDataset.Tables("Patient").Rows(0).Item("Patient_Name").ToString
            Else
                Return ""
            End If
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function GetClinics() As DataSet
        Try
            'Call the data component to get all groups
            GetClinics = objDALClinic.GetClinic
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function rptClinicByClinicDate(ByVal ClinicDate As Date) As DataSet
        Try
            'Call the data component to get all groups
            rptClinicByClinicDate = objDALClinic.rptClinicByClinicDate(ClinicDate)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function rptClinicByPatientID(ByVal PatientID As String) As DataSet
        Try
            'Call the data component to get all groups
            rptClinicByPatientID = objDALClinic.rptClinicByPatientID(PatientID)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function GetClinicById(ByVal ClinicID As Integer) As DataSet
        Try
            'Call the data component to get a specific group
            GetClinicById = objDALClinic.GetClinicByIDShowAllField(ClinicID)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function GetClinicByPatientIdAllShowField(ByVal PatientID As String) As DataSet
        Try
            'Call the data component to get a specific group
            GetClinicByPatientIdAllShowField = objDALClinic.GetClinicByPatientIDAllFieldShow(PatientID)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function GetClinicByPatientName(ByVal PatientName As String) As DataSet
        Try
            'Call the data component to get a specific group
            GetClinicByPatientName = objDALClinic.GetClinicByPatientName(PatientName)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function GetClinicByDoctorName(ByVal DoctorName As String) As DataSet
        Try
            'Call the data component to get a specific group
            GetClinicByDoctorName = objDALClinic.GetClinicByDoctorName(DoctorName)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function GetClinicByDiagnosisName(ByVal Diagnosis_Description As String) As DataSet
        Try
            'Call the data component to get a specific group
            GetClinicByDiagnosisName = objDALClinic.GetClinicByDiagnosisName(Diagnosis_Description)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function GetClinicByClinicDate(ByVal ClinicDate As Date) As DataSet
        Try
            'Call the data component to get a specific group
            GetClinicByClinicDate = objDALClinic.GetClinicByClinicDate(ClinicDate)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function GetClinicByContactDate(ByVal ContactDate As Date) As DataSet
        Try
            'Call the data component to get a specific group
            GetClinicByContactDate = objDALClinic.GetClinicByContactDate(ContactDate)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function GetPicByClinicID(ByVal ClinicID As Integer) As DataSet
        Try
            'Call the data component to get a specific group
            GetPicByClinicID = objDALClinic.GetPicByClinicID(ClinicID)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function GetMaxClinicID() As Integer
        Try
            GetMaxClinicID = objDALClinic.GetMaxClinicId
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function GetMaxPicID() As Integer
        Try
            GetMaxPicID = objDALClinic.GetMaxPicId
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Function IsAlreadySaveForClinic(ByVal ClinicID) As Boolean
        Try
            Dim myDataset As DataSet
            myDataset = New DataSet
            myDataset = objDALClinic.GetClinicByID(ClinicID)
            If myDataset.Tables("Clinic").Rows.Count > 0 Then
                IsAlreadySaveForClinic = True
            Else
                IsAlreadySaveForClinic = False
            End If
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try

    End Function
    Public Function GetNewPictureDS() As DataSet
        Try
            'Instantiate a new DataSet object
            GetNewPictureDS = New DataSet
            'Create a DataTable object
            Dim objDataTable As DataTable = GetNewPictureDS.Tables.Add("Picture")

            'Create a DataColumn object
            Dim objDataColumn As DataColumn

            'Instantiate a new DataColumn and set its properties
            objDataColumn = New DataColumn("Pic_ID", _
                Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False

            'Add the column to the table
            objDataTable.Columns.Add(objDataColumn)

            'Instantiate a new DataColumn and set its properties
            objDataColumn = New DataColumn("Clinic_ID", _
                Type.GetType("System.Int16"))
            'objDataColumn.AllowDBNull = False

            'Add the column to the table
            objDataTable.Columns.Add(objDataColumn)

            'Instantiate a new DataColumn and set its properties
            objDataColumn = New DataColumn("PicName", _
                Type.GetType("System.String"))
            'objDataColumn.AllowDBNull = False

            'Add the column to the table
            objDataTable.Columns.Add(objDataColumn)

            'Instantiate a new DataColumn and set its properties
            objDataColumn = New DataColumn("PicRemark", _
                Type.GetType("System.String"))
            'objDataColumn.AllowDBNull = False

            'Add the column to the table
            objDataTable.Columns.Add(objDataColumn)

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function GetNewClinicDS() As DataSet
        Try
            'Instantiate a new DataSet object
            GetNewClinicDS = New DataSet
            'Create a DataTable object
            Dim objDataTable As DataTable = GetNewClinicDS.Tables.Add("Clinic")

            'Create a DataColumn object
            Dim objDataColumn As DataColumn

            'Instantiate a new DataColumn and set its properties
            objDataColumn = New DataColumn("Clinic_ID", _
                Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False

            'Add the column to the table
            objDataTable.Columns.Add(objDataColumn)

            'Instantiate a new DataColumn and set its properties
            objDataColumn = New DataColumn("Patient_ID", _
                Type.GetType("System.String"))
            objDataColumn.MaxLength = 10
            'objDataColumn.AllowDBNull = False

            'Add the column to the table
            objDataTable.Columns.Add(objDataColumn)

            'Instantiate a new DataColumn and set its properties
            objDataColumn = New DataColumn("Doctor_ID", _
                Type.GetType("System.Int16"))
            ' objDataColumn.AllowDBNull = False

            'Add the column to the table
            objDataTable.Columns.Add(objDataColumn)

            'Instantiate a new DataColumn and set its properties
            objDataColumn = New DataColumn("Diagnosis_Description", _
                Type.GetType("System.String"))
            '  objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 255

            'Add the column to the table
            objDataTable.Columns.Add(objDataColumn)

            'Instantiate a new DataColumn and set its properties
            objDataColumn = New DataColumn("DRUGAllergy_Description", _
                Type.GetType("System.String"))
            'objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 255

            'Add the column to the table
            objDataTable.Columns.Add(objDataColumn)

            'Instantiate a new DataColumn and set its properties
            objDataColumn = New DataColumn("Exam_BW", _
                Type.GetType("System.String"))
            'objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 50

            'Add the column to the table
            objDataTable.Columns.Add(objDataColumn)

            'Instantiate a new DataColumn and set its properties
            objDataColumn = New DataColumn("Exam_PR", _
                Type.GetType("System.String"))
            'objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 50

            'Add the column to the table
            objDataTable.Columns.Add(objDataColumn)

            'Instantiate a new DataColumn and set its properties
            objDataColumn = New DataColumn("Exam_BP", _
                Type.GetType("System.String"))
            ' objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 50

            'Add the column to the table
            objDataTable.Columns.Add(objDataColumn)

            'Instantiate a new DataColumn and set its properties
            objDataColumn = New DataColumn("History_Description", _
                Type.GetType("System.String"))
            ' objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 255

            'Add the column to the table
            objDataTable.Columns.Add(objDataColumn)

            'Instantiate a new DataColumn and set its properties
            objDataColumn = New DataColumn("Investigation_Description", _
                Type.GetType("System.String"))
            ' objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 255

            'Add the column to the table
            objDataTable.Columns.Add(objDataColumn)

            'Instantiate a new DataColumn and set its properties
            objDataColumn = New DataColumn("TreateMent_Desc", _
                Type.GetType("System.String"))
            'objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 255

            'Add the column to the table
            objDataTable.Columns.Add(objDataColumn)

            'Instantiate a new DataColumn and set its properties
            objDataColumn = New DataColumn("Clinic_Date", _
                Type.GetType("System.DateTime"))
            'objDataColumn.AllowDBNull = False

            'Add the column to the table
            objDataTable.Columns.Add(objDataColumn)

            'Instantiate a new DataColumn and set its properties
            objDataColumn = New DataColumn("Contact_Date", _
                Type.GetType("System.DateTime"))
            'objDataColumn.AllowDBNull = False

            'Add the column to the table
            objDataTable.Columns.Add(objDataColumn)

            'Instantiate a new DataColumn and set its properties
            objDataColumn = New DataColumn("Others", _
                Type.GetType("System.String"))
            'objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 50

            'Add the column to the table
            objDataTable.Columns.Add(objDataColumn)

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function AddClinic(ByVal Clinic As DataSet) As Boolean
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALClinic.AddClinic(Clinic)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function AddPicture(ByVal Picture As DataSet) As Boolean
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALClinic.SavePicture(Picture)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function UpdateClinic(ByVal Clinic As DataSet) As Boolean
        Try
            'Validate group data

            'Call the data component to update the group
            Return objDALClinic.UpdateClinic(Clinic)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function DeleteClinic(ByVal ClinicID As Integer) As Boolean
        Try
            'Call the data component to delete the group
            Return objDALClinic.DeleteClinic(ClinicID)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function DeletePic(ByVal PicID As Integer) As Boolean
        Try
            'Call the data component to delete the group
            Return objDALClinic.DeletePic(PicID)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
