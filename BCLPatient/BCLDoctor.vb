Public Class BCLDoctor
    Implements IDisposable
    Private objDALDoctor As DAL.DALDoctor
    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALDoctor = New DAL.DALDoctor(Constring)
    End Sub
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALDoctor.Dispose()
            objDALDoctor = Nothing
            ' TODO: free shared unmanaged resources
        End If
        Me.disposedValue = True
    End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region
#Region " Public Doctor Functions "
    Public Function GetDoctor() As DataSet
        Try
            'Call the data component to get all groups
            GetDoctor = objDALDoctor.GetDoctor
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function GetDoctorById(ByVal Doctor_ID As Integer) As DataSet
        Try
            'Call the data component to get a specific group
            GetDoctorById = objDALDoctor.GetDoctorByID(Doctor_ID)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function GetMaxDoctorID() As Integer
        Try
            GetMaxDoctorID = objDALDoctor.GetMaxDoctorId
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function GetNewDoctorDS() As DataSet
        Try
            'Instantiate a new DataSet object
            GetNewDoctorDS = New DataSet

            'Create a DataTable object
            Dim objDataTable As DataTable = GetNewDoctorDS.Tables.Add("Doctor")

            'Create a DataColumn object
            Dim objDataColumn As DataColumn

            'Instantiate a new DataColumn and set its properties
            objDataColumn = New DataColumn("Doctor_ID", _
                Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False

            'Add the column to the table
            objDataTable.Columns.Add(objDataColumn)

            'Instantiate a new DataColumn and set its properties
            objDataColumn = New DataColumn("Doctor_Name", _
                Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 50

            'Add the column to the table
            objDataTable.Columns.Add(objDataColumn)

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function AddDoctor(ByVal Doctor As DataSet) As Boolean
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALDoctor.AddDoctor(Doctor)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function UpdateDoctor(ByVal Doctor As DataSet) As Boolean
        Try
            'Validate group data

            'Call the data component to update the group
            Return objDALDoctor.UpdateDoctor(Doctor)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function DeleteDoctor(ByVal Doctor_ID As Integer) As Boolean
        Try
            'Call the data component to delete the group
            Return objDALDoctor.DeleteDoctor(Doctor_ID)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Function IsAlreadyExistDoctorID(ByVal Doctor_ID As Integer) As Boolean
        Try
            Dim MyDoctorDataset As New DataSet
            'Call the data component to get a specific group
            MyDoctorDataset = objDALDoctor.GetDoctorByID(Doctor_ID)
            If MyDoctorDataset.Tables("Doctor").Rows.Count > 0 Then
                IsAlreadyExistDoctorID = True
            Else
                IsAlreadyExistDoctorID = False
            End If
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
