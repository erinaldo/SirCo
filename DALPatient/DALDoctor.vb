
Imports System.Data.SqlClient
Public Class DALDoctor
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
    Public Function AddDoctor(ByVal Doctor As DataSet) As Boolean
        Try
            'MyBase.SQL = "usp_InsertRole" 'Insert Query
            MyBase.SQL = "INSERT INTO tbl_Doctor (Doctor_ID, Doctor_Name) values (@Doctor_ID," & _
                        "@Doctor_Name )"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add the Parameters to the Parameters collection
            'User_Name Text 15

            MyBase.AddParameter("@Patient_ID", _
               SqlDbType.Int, 16, _
               Doctor.Tables("Doctor").Rows(0).Item("Doctor_ID"))
            'Patient_Name Text 50
            MyBase.AddParameter("@Doctor_Name", _
                 Data.SqlDbType.VarChar, 20, _
                Doctor.Tables("Doctor").Rows(0).Item("Doctor_Name"))
            AddDoctor = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function UpdateDoctor(ByVal Doctor As DataSet) As Boolean
        Try
            'MyBase.SQL = "usp_InsertRole" 'Insert Query
            MyBase.SQL = "Update  tbl_Doctor Set Doctor_Name=@Doctor_Name where  Doctor_ID=@Doctor_ID"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add the Parameters to the Parameters collection
            'Doctor_Name Text 50
            MyBase.AddParameter("@Doctor_Name", _
                 Data.SqlDbType.VarChar, 20, _
                Doctor.Tables("Doctor").Rows(0).Item("Doctor_Name"))
            'Doctore_ID Integer
            MyBase.AddParameter("@Doctor_ID", _
                SqlDbType.Int, 16, _
                Doctor.Tables("Doctor").Rows(0).Item("Doctor_ID"))
            UpdateDoctor = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function GetDoctor() As DataSet
        Try
            GetDoctor = New DataSet
            MyBase.SQL = "Select Doctor_ID,Doctor_Name from tbl_Doctor Order by Doctor_ID"
            MyBase.InitializeCommand()
            'Fill the DataSet
            MyBase.FillDataSet(GetDoctor, "Doctors")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function


    Public Function GetMaxDoctorId() As Integer
        Try
            Dim Doctor As New DataSet
            MyBase.SQL = "Select Max(Doctor_ID) as MaxID from tbl_Doctor"
            'Fill the DataSet
            MyBase.FillDataSet(Doctor, "Doctor")
            GetMaxDoctorId = Val(Doctor.Tables("Doctor").Rows(0).Item("MaxID").ToString) + 1
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function GetDoctorByID(ByVal Doctor_Id As Integer) As DataSet
        Try
            GetDoctorByID = New DataSet
            MyBase.SQL = "Select * from tbl_Doctor where Doctor_ID=@Doctor_ID"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@Doctor_ID", SqlDbType.Int, _
                16, Doctor_Id)
            'Fill the DataSet
            MyBase.FillDataSet(GetDoctorByID, "Doctor")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function DeleteDoctor(ByVal Doctor_ID As Integer) As Boolean
        Try
            MyBase.SQL = "Delete * from tbl_Doctor where Doctor_ID=@Doctor_ID"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@Doctor_ID", _
                SqlDbType.Int, 16, Doctor_ID)
            'Execute the stored procedure
            DeleteDoctor = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

#End Region
End Class
