Imports System.Data.SqlClient

Public Class DALClinic
    Inherits DALBase
#Region "Constructor And Destructor"
    Sub New(ByVal ConString As String)
        MyBase.New(ConString)
    End Sub

    Public Shadows Sub Dispose()
        MyBase.Dispose()
    End Sub
#End Region

#Region " Public Role Functions "
    Public Function AddClinic(ByVal Clinic As DataSet) As Boolean
        Try
            MyBase.SQL = "INSERT INTO tbl_Clinic values(?,?,?,?,?,?,?,?,?,?,?,?,?,?)"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add the Parameters to the Parameters collection
            'Clinic_ID Integer
            MyBase.AddParameter("@Clinic_ID", _
                SqlDbType.Int, 16, _
                Clinic.Tables("Clinic").Rows(0).Item("Clinic_ID"))
            'Patient_ID Integer
            MyBase.AddParameter("@Patient_ID", _
                SqlDbType.VarChar, 10, _
                Clinic.Tables("Clinic").Rows(0).Item("Patient_ID"))
            'Doctor_ID Integer
            MyBase.AddParameter("@Doctor_ID", _
                SqlDbType.Int, 16, _
                Clinic.Tables("Clinic").Rows(0).Item("Doctor_ID"))
            'Diagnosis_Description Text 100
            MyBase.AddParameter("@Diagnosis_Description", _
                SqlDbType.VarChar, 100, _
                Clinic.Tables("Clinic").Rows(0).Item("Diagnosis_Description"))
            'DRUGAllergy_Description Text 100
            MyBase.AddParameter("@DRUGAllergy_Description", _
                SqlDbType.VarChar, 100, _
                Clinic.Tables("Clinic").Rows(0).Item("DRUGAllergy_Description"))
            'Exam_BW Text 50
            MyBase.AddParameter("@Exam_BW", _
                            SqlDbType.VarChar, 50, _
                            Clinic.Tables("Clinic").Rows(0).Item("Exam_BW"))
            'Exam_PR Text 50
            MyBase.AddParameter("@Exam_PR", _
                            SqlDbType.VarChar, 50, _
                            Clinic.Tables("Clinic").Rows(0).Item("Exam_PR"))
            'Exam_BP Text 50
            MyBase.AddParameter("@Exam_BP", _
                            SqlDbType.VarChar, 50, _
                            Clinic.Tables("Clinic").Rows(0).Item("Exam_BP"))
            'History_Description Text 100
            MyBase.AddParameter("@History_Description", _
                            SqlDbType.VarChar, 100, _
                            Clinic.Tables("Clinic").Rows(0).Item("History_Description"))
            'Investigation_Description Text 100
            MyBase.AddParameter("@Investigation_Description", _
                            SqlDbType.VarChar, 100, _
                            Clinic.Tables("Clinic").Rows(0).Item("Investigation_Description"))
            'TreateMent_Desc Text 100
            MyBase.AddParameter("@TreateMent_Desc", _
                            SqlDbType.VarChar, 100, _
                            Clinic.Tables("Clinic").Rows(0).Item("TreateMent_Desc"))
            'Clinic_Date Date
            MyBase.AddParameter("@Clinic_Date", _
                            SqlDbType.DateTime, 8, _
                            Clinic.Tables("Clinic").Rows(0).Item("Clinic_Date"))
            'Contact_Date Date
            MyBase.AddParameter("@Contact_Date", _
                            SqlDbType.DateTime, 8, _
                            Clinic.Tables("Clinic").Rows(0).Item("Contact_Date"))

            'Others Text 50
            MyBase.AddParameter("@Others", _
                            SqlDbType.VarChar, 50, _
                            Clinic.Tables("Clinic").Rows(0).Item("Others"))

            'Execute the stored procedure
            AddClinic = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function UpdateClinic(ByVal Clinic As DataSet) As Boolean
        Try
            'MyBase.SQL = "usp_InsertRole" 'Insert Query
            ' MyBase.SQL = "Update  tbl_Clinic Set Patient_ID=?, Doctor_ID=?, Diagnosis_Description=?, DRUGAllergy_Description=?, Exam_BW=?, Exam_PR=?, Exam_BP=?, History_Description=?, Investigation_Description=?, TreateMent_Desc=?, Clinic_Date=?, Contact_Date=?, Section=?, Others=? where Clinic_ID=? ;"
            MyBase.SQL = "UPDATE tbl_Clinic set Patient_ID=?,Doctor_ID=?,Diagnosis_Description=?," & _
                         "DRUGAllergy_Description=?,Exam_BW=?,Exam_PR=?,Exam_BP=?,History_Description=?," & _
                         "Investigation_Description=?,TreateMent_Desc=?,Clinic_Date=?,Contact_Date=?," & _
                         "Others=? where Clinic_ID=?"
            'MyBase.SQL = "INSERT INTO tbl_Clinic values(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"
            'Initialize the Command object
            MyBase.InitializeCommand()
            MyBase.AddParameter("@Patient_ID", SqlDbType.VarChar, 10, Clinic.Tables("Clinic").Rows(0).Item("Patient_ID"))
            MyBase.AddParameter("@Doctor_ID", SqlDbType.Int, 16, Clinic.Tables("Clinic").Rows(0).Item("Doctor_ID"))
            MyBase.AddParameter("@Diagnosis_Description", SqlDbType.VarChar, 100, Clinic.Tables("Clinic").Rows(0).Item("Diagnosis_Description"))
            MyBase.AddParameter("@DRUGAllergy_Description", SqlDbType.VarChar, 100, Clinic.Tables("Clinic").Rows(0).Item("DRUGAllergy_Description"))
            MyBase.AddParameter("@Exam_BW", SqlDbType.VarChar, 50, Clinic.Tables("Clinic").Rows(0).Item("Exam_BW"))
            MyBase.AddParameter("@Exam_PR", SqlDbType.VarChar, 50, Clinic.Tables("Clinic").Rows(0).Item("Exam_PR"))
            MyBase.AddParameter("@Exam_BP", SqlDbType.VarChar, 50, Clinic.Tables("Clinic").Rows(0).Item("Exam_BP"))
            MyBase.AddParameter("@History_Description", SqlDbType.VarChar, 100, Clinic.Tables("Clinic").Rows(0).Item("History_Description"))
            MyBase.AddParameter("@Investigation_Description", SqlDbType.VarChar, 100, Clinic.Tables("Clinic").Rows(0).Item("Investigation_Description"))
            MyBase.AddParameter("@TreateMent_Desc", SqlDbType.VarChar, 100, Clinic.Tables("Clinic").Rows(0).Item("TreateMent_Desc"))
            MyBase.AddParameter("@Clinic_Date", SqlDbType.DateTime, 8, Clinic.Tables("Clinic").Rows(0).Item("Clinic_Date"))
            MyBase.AddParameter("@Contact_Date", SqlDbType.DateTime, 8, Clinic.Tables("Clinic").Rows(0).Item("Contact_Date"))
            'MyBase.AddParameter("@Section", SqlDbType.VarChar, 50, Clinic.Tables("Clinic").Rows(0).Item("Section"))
            MyBase.AddParameter("@Others", SqlDbType.VarChar, 50, Clinic.Tables("Clinic").Rows(0).Item("Others"))
            MyBase.AddParameter("@Clinic_ID", SqlDbType.Int, 16, Clinic.Tables("Clinic").Rows(0).Item("Clinic_ID"))
            'Execute the stored procedure
            UpdateClinic = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Function SavePicture(ByVal PictureDataset As DataSet) As Boolean
        Try
            MyBase.SQL = "Insert Into tbl_Pic values(?,?,?,?)"
            MyBase.InitializeCommand()
            MyBase.AddParameter("@Pic_ID", SqlDbType.Int, 16, PictureDataset.Tables("Picture").Rows(0).Item("Pic_ID"))
            MyBase.AddParameter("@Clinic_ID", SqlDbType.Int, 16, PictureDataset.Tables("Picture").Rows(0).Item("Clinic_ID"))
            MyBase.AddParameter("@PicName", SqlDbType.VarChar, 30, PictureDataset.Tables("Picture").Rows(0).Item("PicName"))
            MyBase.AddParameter("@PicRemark", SqlDbType.VarChar, 30, PictureDataset.Tables("Picture").Rows(0).Item("PicRemark"))
            'Execute The Stored Procedure
            SavePicture = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                       ExceptionErr.InnerException)
        End Try
    End Function

    Public Function GetClinic() As DataSet
        Try
            GetClinic = New DataSet
            MyBase.SQL = "SELECT Clinic_Date, Clinic_ID, Patient_Name, DOB, NRCNo, Address, Diagnosis_Description,Doctor_Name,Contact_Date" & _
                        " FROM tbl_Clinic, tbl_Doctor, tbl_Patient WHERE ( tbl_Clinic.Doctor_ID = tbl_Doctor.Doctor_ID and  tbl_Clinic.Patient_ID = tbl_Patient.Patient_ID) order by Clinic_ID"
            MyBase.InitializeCommand()
            'Fill the DataSet
            MyBase.FillDataSet(GetClinic, "Clinics")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function GetMaxClinicId() As Integer
        Try
            Dim Clinic As New DataSet
            MyBase.SQL = "Select Max(Clinic_ID) as MaxID from tbl_Clinic"
            'Fill the DataSet
            MyBase.FillDataSet(Clinic, "Clinic")
            GetMaxClinicId = Val(Clinic.Tables("Clinic").Rows(0).Item("MaxID").ToString) + 1
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function GetMaxPicId() As Integer
        Try
            Dim PictureDataset As New DataSet
            MyBase.SQL = "Select Max(Pic_ID) as MaxID from tbl_Pic"
            'Fill the DataSet
            MyBase.FillDataSet(PictureDataset, "Picture")
            GetMaxPicId = Val(PictureDataset.Tables("Picture").Rows(0).Item("MaxID").ToString) + 1
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function GetClinicByID(ByVal ClinicId As Integer) As DataSet
        Try
            GetClinicByID = New DataSet
            MyBase.SQL = "SELECT Clinic_Date, Clinic_ID, Patient_Name, DOB, NRCNo, Address, Diagnosis_Description,Doctor_Name,Contact_Date" & _
                             " FROM tbl_Clinic, tbl_Doctor, tbl_Patient WHERE ( tbl_Clinic.Doctor_ID = tbl_Doctor.Doctor_ID and  tbl_Clinic.Patient_ID = tbl_Patient.Patient_ID) And " & _
                             " Clinic_ID=@Clinic_ID"
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@Clinic_ID", SqlDbType.Int, _
                16, ClinicId)
            'Fill the DataSet
            MyBase.FillDataSet(GetClinicByID, "Clinic")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function GetClinicByIDShowAllField(ByVal ClinicId As Integer) As DataSet
        Try
            GetClinicByIDShowAllField = New DataSet
            MyBase.SQL = "SELECT * from tbl_Clinic where Clinic_ID=@Clinic_ID"
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@Clinic_ID", SqlDbType.Int, _
                16, ClinicId)
            'Fill the DataSet
            MyBase.FillDataSet(GetClinicByIDShowAllField, "Clinic")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function rptClinicByClinicDate(ByVal ClinicDate As Date) As DataSet
        Try
            rptClinicByClinicDate = New DataSet
            MyBase.SQL = "SELECT tbl_Clinic.Clinic_ID, tbl_Patient.Patient_Name, tbl_Doctor.Doctor_Name, tbl_Clinic.Diagnosis_Description, tbl_Clinic.DRUGAllergy_Description, tbl_Clinic.Exam_BW, tbl_Clinic.Exam_PR, tbl_Clinic.Exam_BP, tbl_Clinic.History_Description, tbl_Clinic.Investigation_Description, tbl_Clinic.TreateMent_Desc, tbl_Clinic.Clinic_Date, tbl_Clinic.Contact_Date" & _
                         " FROM tbl_Clinic , tbl_Doctor, tbl_Patient where tbl_Clinic.Patient_ID=tbl_Patient.Patient_ID and tbl_Clinic.Doctor_ID=tbl_Doctor.Doctor_ID And tbl_Clinic.Clinic_Date=@ClinicDate"

            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@ClinicDate", SqlDbType.DateTime, _
                8, ClinicDate)
            'Fill the DataSet
            MyBase.FillDataSet(rptClinicByClinicDate, "Clinics")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function rptClinicByPatientID(ByVal PatientID As String) As DataSet
        Try
            rptClinicByPatientID = New DataSet
            MyBase.SQL = "SELECT tbl_Clinic.Clinic_ID, tbl_Patient.Patient_Name, tbl_Doctor.Doctor_Name, tbl_Clinic.Diagnosis_Description, tbl_Clinic.DRUGAllergy_Description, tbl_Clinic.Exam_BW, tbl_Clinic.Exam_PR, tbl_Clinic.Exam_BP, tbl_Clinic.History_Description, tbl_Clinic.Investigation_Description, tbl_Clinic.TreateMent_Desc, tbl_Clinic.Clinic_Date, tbl_Clinic.Contact_Date" & _
                         " FROM tbl_Clinic , tbl_Doctor, tbl_Patient where tbl_Clinic.Patient_ID=tbl_Patient.Patient_ID and tbl_Clinic.Doctor_ID=tbl_Doctor.Doctor_ID And tbl_Clinic.Patient_ID=@Patient_ID"

            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@Patient_ID", SqlDbType.VarChar, _
                10, PatientID)
            'Fill the DataSet
            MyBase.FillDataSet(rptClinicByPatientID, "Clinics")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function


    Public Function GetPicByClinicID(ByVal ClinicId As Integer) As DataSet
        Try
            GetPicByClinicID = New DataSet
            MyBase.SQL = "SELECT Pic_ID,PicName,PicRemark from tbl_pic where Clinic_ID=@Clinic_ID"
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@Clinic_ID", SqlDbType.Int, _
                16, ClinicId)
            'Fill the DataSet
            MyBase.FillDataSet(GetPicByClinicID, "Pictures")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function
    Public Function GetClinicByPatientIDAllFieldShow(ByVal PatientID As String) As DataSet
        Try
            GetClinicByPatientIDAllFieldShow = New DataSet
            MyBase.SQL = "SELECT tbl_Clinic.Clinic_Date,tbl_Clinic.Clinic_ID, tbl_Patient.Patient_Name, tbl_Doctor.Doctor_Name, tbl_Clinic.Diagnosis_Description, tbl_Clinic.DRUGAllergy_Description, tbl_Clinic.Exam_BW, tbl_Clinic.Exam_PR, tbl_Clinic.Exam_BP, tbl_Clinic.History_Description, tbl_Clinic.Investigation_Description, tbl_Clinic.TreateMent_Desc, tbl_Clinic.Clinic_Date, tbl_Clinic.Contact_Date" & _
                        " FROM tbl_Clinic , tbl_Doctor, tbl_Patient where tbl_Clinic.Patient_ID=tbl_Patient.Patient_ID and tbl_Clinic.Doctor_ID=tbl_Doctor.Doctor_ID And tbl_Clinic.Patient_ID=@Patient_ID"

            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@Patient_ID", SqlDbType.VarChar, _
                10, PatientID)
            'Fill the DataSet
            MyBase.FillDataSet(GetClinicByPatientIDAllFieldShow, "Clinics")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function GetClinicByPatientName(ByVal PatientName As String) As DataSet
        Try
            GetClinicByPatientName = New DataSet
            MyBase.SQL = "SELECT Clinic_Date, Clinic_ID, Patient_Name, DOB, NRCNo, Address, Diagnosis_Description,Doctor_Name,Contact_Date" & _
                             " FROM tbl_Clinic, tbl_Doctor, tbl_Patient WHERE ( tbl_Clinic.Doctor_ID = tbl_Doctor.Doctor_ID and  tbl_Clinic.Patient_ID = tbl_Patient.Patient_ID) And " & _
                             " Patient_Name Like @Patient_Name order by Clinic_Date"
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@Patient_Name", SqlDbType.VarChar, _
                50, PatientName)
            'Fill the DataSet
            MyBase.FillDataSet(GetClinicByPatientName, "Clinics")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function GetClinicByDoctorName(ByVal DoctorName As String) As DataSet
        Try
            GetClinicByDoctorName = New DataSet
            MyBase.SQL = "SELECT Clinic_Date, Clinic_ID, Patient_Name, DOB, NRCNo, Address, Diagnosis_Description,Doctor_Name,Contact_Date" & _
                             " FROM tbl_Clinic, tbl_Doctor, tbl_Patient WHERE ( tbl_Clinic.Doctor_ID = tbl_Doctor.Doctor_ID and  tbl_Clinic.Patient_ID = tbl_Patient.Patient_ID) And " & _
                             " Doctor_Name Like @Doctor_Name"
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@Doctor_Name", SqlDbType.VarChar, _
                50, DoctorName)
            'Fill the DataSet
            MyBase.FillDataSet(GetClinicByDoctorName, "Clinics")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function


    Public Function GetClinicByClinicDate(ByVal ClinicDate As Date) As DataSet
        Try
            GetClinicByClinicDate = New DataSet
            MyBase.SQL = "SELECT Clinic_Date, Clinic_ID, Patient_Name, DOB, NRCNo, Address, Diagnosis_Description,Doctor_Name,Contact_Date" & _
                             " FROM tbl_Clinic, tbl_Doctor, tbl_Patient WHERE ( tbl_Clinic.Doctor_ID = tbl_Doctor.Doctor_ID and  tbl_Clinic.Patient_ID = tbl_Patient.Patient_ID) And " & _
                             " Clinic_Date = @Clinic_Date"
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@Clinic_Date", SqlDbType.DateTime, _
                8, ClinicDate)
            'Fill the DataSet
            MyBase.FillDataSet(GetClinicByClinicDate, "Clinics")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function GetClinicByContactDate(ByVal ContactDate As Date) As DataSet
        Try
            GetClinicByContactDate = New DataSet
            MyBase.SQL = "SELECT Clinic_Date, Clinic_ID, Patient_Name, DOB, NRCNo, Address, Diagnosis_Description,Doctor_Name,Contact_Date" & _
                             " FROM tbl_Clinic, tbl_Doctor, tbl_Patient WHERE ( tbl_Clinic.Doctor_ID = tbl_Doctor.Doctor_ID and  tbl_Clinic.Patient_ID = tbl_Patient.Patient_ID) And " & _
                             " Contact_Date = @Contact_Date"
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@Clinic_Date", Data.SqlDbType.DateTime, _
                8, ContactDate)
            'Fill the DataSet
            MyBase.FillDataSet(GetClinicByContactDate, "Clinics")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    '
    Public Function GetClinicByDiagnosisName(ByVal DiagnosisName As String) As DataSet
        Try
            GetClinicByDiagnosisName = New DataSet
            MyBase.SQL = "SELECT Clinic_Date, Clinic_ID, Patient_Name, DOB, NRCNo, Address, Diagnosis_Description,Doctor_Name,Contact_Date" & _
                             " FROM tbl_Clinic, tbl_Doctor, tbl_Patient WHERE ( tbl_Clinic.Doctor_ID = tbl_Doctor.Doctor_ID and  tbl_Clinic.Patient_ID = tbl_Patient.Patient_ID) And " & _
                             " Diagnosis_Description Like @Diagnosis_Description"
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@Diagnosis_Description", SqlDbType.VarChar, _
                100, DiagnosisName)
            'Fill the DataSet
            MyBase.FillDataSet(GetClinicByDiagnosisName, "Clinics")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function DeleteClinic(ByVal ClinicID As Integer) As Boolean
        Try
            MyBase.SQL = "Delete * from tbl_Clinic where Clinic_ID=@Clinic_ID"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@Clinic_ID", _
                SqlDbType.Int, 16, ClinicID)
            'Execute the stored procedure
            DeleteClinic = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function DeletePic(ByVal PicID As Integer) As Boolean
        Try
            MyBase.SQL = "Delete * from tbl_Pic where Pic_ID=@PicID"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@PicID", _
                SqlDbType.Int, 16, PicID)
            'Execute the stored procedure
            DeletePic = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


#End Region

End Class
