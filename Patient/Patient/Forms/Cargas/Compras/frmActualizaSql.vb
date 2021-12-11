Public Class frmActualizaSql
    'mreyes 21/Noviembre/2018   11:02 
    Private Sub Btn_Aceptar_Click(sender As Object, e As EventArgs) Handles Btn_Aceptar.Click
        Try
            PictureBox1.Visible = True

            Me.Cursor = Cursors.WaitCursor

            If usp_GeneraPrecios() = False Then

            End If

            If usp_GeneraEstructura() = False Then

            End If
            MsgBox("Proceso Terminado", MsgBoxStyle.Information, "Aviso")
            Me.Cursor = Cursors.Default
            PictureBox1.Visible = False
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Sub

    Public Function usp_GeneraPrecios() As Boolean
        'mreyes 22/Mayo/2012 06:24 p.m.
        Try
            'Validate group data
            Using objDALCargaMysqlSql As New BCL.BCLCompras(GLB_ConStringCipSis)
                'Call the data component to add the new group
                If objDALCargaMysqlSql.usp_GeneraPrecios() Then
                End If
            End Using





        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_GeneraEstructura() As Boolean
        'mreyes 21/Noviembre/2018   11:20 a.m.
        Try
            'Validate group data
            Using objDALCargaMysqlSql As New BCL.BCLMigracion(GLB_ConStringDwhSQL)
                'Call the data component to add the new group
                If objDALCargaMysqlSql.usp_GeneraEstructura() Then

                End If

            End Using
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Private Sub frmActualizaSql_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then
                Me.Dispose()
                Me.Close()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub

    Private Sub frmActualizaSql_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class

