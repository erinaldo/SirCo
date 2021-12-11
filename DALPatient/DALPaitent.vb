Imports System.Data.OleDb

Public Class DALPaitent
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
    Public Function AddPatient(ByVal Patient As DataSet) As Boolean
        Try
            'MyBase.SQL = "usp_InsertRole" 'Insert Query
            MyBase.SQL = "INSERT INTO tbl_Patient ( Patient_ID, Patient_Name, NRCNo, Address, " & _
                        "DOB,Phone_R,Phone_O, Phone_HP, MaritalStatus, BloodGroup, ContactPhone, " & _
                        "ContaactPhoneII, Remark, PicName ) values (@Patient_ID,@Patient_Name," & _
                        "@NrcNo,@Address,@DOB,@Phone_R,@Phone_O,@Phone_HP,@MaritalStatus,@BloodGroup," & _
                        "@ContactPhone,@ContactPhoneII,@Remark,@PicName"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add the Parameters to the Parameters collection
            'Patient_ID Integer
            MyBase.AddParameter("@Patient_ID", _
                SqlDbType.Int, 16, _
                Patient.Tables("Patient").Rows(0).Item("Patient_ID"))
            'Patient_Name Text 50
            MyBase.AddParameter("@Patient_Name", _
                SqlDbType.Text, 50, _
                Patient.Tables("Patient").Rows(0).Item("Patient_Name"))
            'NRCNo Text 50
            MyBase.AddParameter("@NrcNo", _
                SqlDbType.Text, 50, _
                Patient.Tables("Patient").Rows(0).Item("NrcNo"))
            'Address Memo 
            MyBase.AddParameter("@Address", _
                SqlDbType.Text, 500, _
                Patient.Tables("Patient").Rows(0).Item("Address"))
            'DOB Date/Time
            MyBase.AddParameter("@DOB", _
                SqlDbType.DateTime, 8, _
                Patient.Tables("Patient").Rows(0).Item("DOB"))
            'Phone_R Text 20
            MyBase.AddParameter("@Phone_R", _
                            SqlDbType.Text, 20, _
                            Patient.Tables("Patient").Rows(0).Item("Phone_R"))
            'Phone_O Text 20
            MyBase.AddParameter("@Phone_O", _
                            SqlDbType.Text, 20, _
                            Patient.Tables("Patient").Rows(0).Item("Phone_O"))
            'Phone_HP Text 20
            MyBase.AddParameter("@Phone_HP", _
                            SqlDbType.Text, 20, _
                            Patient.Tables("Patient").Rows(0).Item("Phone_HP"))
            'MaritalStatus Numeric
            MyBase.AddParameter("@MaritalStatus", _
                            SqlDbType.Int, 1, _
                            Patient.Tables("Patient").Rows(0).Item("MaritalStatus"))
            'BloodGroup Text 2
            MyBase.AddParameter("@BloodGroup", _
                            SqlDbType.Text, 2, _
                            Patient.Tables("Patient").Rows(0).Item("BloodGroup"))
            'ContactPhone Text 20
            MyBase.AddParameter("@ContactPhone", _
                            SqlDbType.Text, 20, _
                            Patient.Tables("Patient").Rows(0).Item("ContactPhone"))
            'ContaactPhoneII Text 20
            MyBase.AddParameter("@ContaactPhoneII", _
                            SqlDbType.Text, 20, _
                            Patient.Tables("Patient").Rows(0).Item("ContaactPhoneII"))
            'Remark Text 250
            MyBase.AddParameter("@Remark", _
                            SqlDbType.Text, 250, _
                            Patient.Tables("Patient").Rows(0).Item("Remark"))
            'PicName Text 10
            MyBase.AddParameter("@PicName", _
                            SqlDbType.Text, 10, _
                            Patient.Tables("Patient").Rows(0).Item("PicName"))
            'Execute the stored procedure
            AddPatient = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function UpdatePatient(ByVal Patient As DataSet) As Boolean
        Try
            'MyBase.SQL = "usp_InsertRole" 'Insert Query
            MyBase.SQL = "Update  tbl_Patient Set  Patient_Name=@Patient_Name, NRCNo=@NrcNo," & _
                        "Address=@Address, DOB=@DOB,Phone_R=@Phone_R,Phone_O=@Phone_O, Phone_HP=@Phone_HP," & _
                        "MaritalStatus=@MaritalStatus, BloodGroup=@BloodGroup, ContactPhone=@ContactPhone" & _
                        "ContaactPhoneII=@ContactPhoneII, Remark=@Remark, PicName=@PicName where  Patient_ID=@Patient_ID"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add the Parameters to the Parameters collection
            'Patient_Name Text 50
            MyBase.AddParameter("@Patient_Name", _
                SqlDbType.Text, 50, _
                Patient.Tables("Patient").Rows(0).Item("Patient_Name"))
            'NRCNo Text 50
            MyBase.AddParameter("@NrcNo", _
                SqlDbType.Text, 50, _
                Patient.Tables("Patient").Rows(0).Item("NrcNo"))
            'Address Memo 
            MyBase.AddParameter("@Address", _
                SqlDbType.Text, 500, _
                Patient.Tables("Patient").Rows(0).Item("Address"))
            'DOB Date/Time
            MyBase.AddParameter("@DOB", _
                SqlDbType.DateTime, 8, _
                Patient.Tables("Patient").Rows(0).Item("DOB"))
            'Phone_R Text 20
            MyBase.AddParameter("@Phone_R", _
                            SqlDbType.Text, 20, _
                            Patient.Tables("Patient").Rows(0).Item("Phone_R"))
            'Phone_O Text 20
            MyBase.AddParameter("@Phone_O", _
                            SqlDbType.Text, 20, _
                            Patient.Tables("Patient").Rows(0).Item("Phone_O"))
            'Phone_HP Text 20
            MyBase.AddParameter("@Phone_HP", _
                            SqlDbType.Text, 20, _
                            Patient.Tables("Patient").Rows(0).Item("Phone_HP"))
            'MaritalStatus Numeric
            MyBase.AddParameter("@MaritalStatus", _
                            SqlDbType.Int, 1, _
                            Patient.Tables("Patient").Rows(0).Item("MaritalStatus"))
            'BloodGroup Text 2
            MyBase.AddParameter("@BloodGroup", _
                            SqlDbType.Text, 2, _
                            Patient.Tables("Patient").Rows(0).Item("BloodGroup"))
            'ContactPhone Text 20
            MyBase.AddParameter("@ContactPhone", _
                            SqlDbType.Text, 20, _
                            Patient.Tables("Patient").Rows(0).Item("ContactPhone"))
            'ContaactPhoneII Text 20
            MyBase.AddParameter("@ContaactPhoneII", _
                            SqlDbType.Text, 20, _
                            Patient.Tables("Patient").Rows(0).Item("ContaactPhoneII"))
            'Remark Text 250
            MyBase.AddParameter("@Remark", _
                            SqlDbType.Text, 250, _
                            Patient.Tables("Patient").Rows(0).Item("Remark"))
            'PicName Text 10
            MyBase.AddParameter("@PicName", _
                            SqlDbType.Text, 10, _
                            Patient.Tables("Patient").Rows(0).Item("PicName"))
            'Patient_ID Integer
            MyBase.AddParameter("@Patient_ID", _
                SqlDbType.Int, 16, _
                Patient.Tables("Patient").Rows(0).Item("Patient_ID"))
            'Execute the stored procedure
            UpdatePatient = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function GetPatient() As DataSet
        Try
            GetPatient = New DataSet
            MyBase.SQL = "Select * from tbl_Patient order by Patient_ID"
            MyBase.InitializeCommand()
            'Fill the DataSet
            MyBase.FillDataSet(GetPatient, "Patients")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function GetMaxPatientId() As Integer
        Try
            Dim Patient As New DataSet
            MyBase.SQL = "Select Max(Patient_ID) as MaxID from tbl_Patient"
            'Fill the DataSet
            MyBase.FillDataSet(Patient, "Patient")
            GetMaxPatientId = Val(Patient.Tables("Patient").Rows(0).Item("MaxID").ToString) + 1
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function GetPatientByID(ByVal PatientId As Integer) As DataSet
        Try
            GetPatientByID = New DataSet
            MyBase.SQL = "Select * from tbl_Patient where Patient_ID=@Patient_ID"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@Patient_ID", OleDbType.Integer, _
                16, PatientId)
            'Fill the DataSet
            MyBase.FillDataSet(GetPatientByID, "Patient")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function GetPatientByName(ByVal PatientName As String) As DataSet
        Try
            GetPatientByName = New DataSet
            MyBase.SQL = "Select * from tbl_Patient where Patient_Name Like @Patient_Name"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@Patient_Name", OleDbType.VarChar, _
                50, PatientName)
            'Fill the DataSet
            MyBase.FillDataSet(GetPatientByName, "Patients")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function GetPatientByNRC(ByVal NRCNo As String) As DataSet
        Try
            GetPatientByNRC = New DataSet
            MyBase.SQL = "Select * from tbl_Patient where NRCNo Like @NRCNo"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@NRCNo", OleDbType.VarChar, _
                50, NRCNo)
            'Fill the DataSet
            MyBase.FillDataSet(GetPatientByNRC, "Patients")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function DeletePatient(ByVal PatientID As Integer) As Boolean
        Try
            MyBase.SQL = "Delete * from tbl_Patient where Patient_ID=@Patient_ID"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@Patient_ID", _
                SqlDbType.Int, 16, PatientID)
            'Execute the stored procedure
            DeletePatient = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
