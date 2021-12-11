Imports System.IO
Imports Microsoft.Office.Interop
Public Class frmCapturaUPCs

    Private captura As Data.DataSet
    Private actualizacion As Data.DataSet
    Private Marca As String
    Private Modelo As String
    Private Talla As String
    Private UPC As String
    Private IDUsuario As Integer = GLB_Idempleado
    Private tabla As String
    Dim NomArch As String
    Dim ap As New Excel.Application
    Dim libro As Excel.Workbook
    Dim hoja As Excel.Worksheet
    Dim sheet As Excel.Worksheet
    Const adOpenStatic = 3
    Const adLockOptimistic = 3
    Const adCmdText = &H1

    Private Sub Btn_Subir_Excel_Click(sender As Object, e As EventArgs) Handles Btn_Subir_Excel.Click
        Try
            If TextBox1.Text = "" Then
                MsgBox("Se debe seleccionar una ruta de archivo válida", MsgBoxStyle.Critical, "ERROR")
            Else
                If MsgBox("¿Está seguro de iniciar este proceso?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.Yes Then
                    SubirArchivo(TextBox1.Text)
                Else

                End If
            End If
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, ExceptionErr.InnerException)
        End Try

    End Sub

    Public Function SubirArchivo(ByVal ruta As String)

        Try
            Dim con = New ADODB.Connection
            Dim recset = New ADODB.Recordset

            con.Open("Provider=Microsoft.ACE.OLEDB.12.0" &
              ";Data Source=" & ruta &
              ";Extended Properties=""Excel 12.0 Xml;HDR=Yes;""")

            For Each hoja In libro.Worksheets

                recset.Open("Select * FROM [" + hoja.Name + "$];",
                con, adOpenStatic, adLockOptimistic, adCmdText)

                'Registro de información del archivo Excel en tabla upcs
                For i As Integer = 0 To recset.RecordCount - 1

                    Marca = recset.Fields(0).Value
                    Modelo = recset.Fields(1).Value
                    Talla = recset.Fields(2).Value
                    UPC = recset.Fields(3).Value

                    Try
                        Using capturaUPCs As New BCL.BCLCapturaUPCs(GLB_ConStringSirCoTEMPSQL)
                            captura = capturaUPCs.usp_CapturaUPCs(Marca.ToUpper, Modelo, Talla, UPC, IDUsuario)
                        End Using
                    Catch ExceptionErr As Exception
                        MessageBox.Show(ExceptionErr.Message.ToString)
                    End Try
                    recset.MoveNext
                Next
                recset.Close()
            Next
            con.Close()

            'Reemplazo de upcs en tabla products
            Try
                Using actualizacionUpcs As New BCL.BCLActualizaUpcs(GLB_ConStringSirCoVentaEnLineaSQL)
                    actualizacion = actualizacionUpcs.usp_ActualizaUpcs(IDUsuario)
                End Using
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try

            MsgBox("La información se ha guardado correctamente", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "AVISO")
            TextBox1.Clear()
            LimpiarVariables()

        Catch ExceptionErr As Exception

            LimpiarVariables()
            Throw New System.Exception(ExceptionErr.Message,
        ExceptionErr.InnerException)

        End Try


    End Function

    Private Sub LimpiarVariables()
        Marca = ""
        Modelo = ""
        Talla = ""
        UPC = ""
    End Sub

    Private Sub frmSubirUPC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then
                Me.Dispose()
                Me.Close()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Examinar_Click(sender As Object, e As EventArgs) Handles Btn_Examinar.Click
        ExcelSubir.Filter = "Archivos de Excel |*.xlsx;*.xlsm;*.xlsb;*.xltx;*.xltm;*.xls;*.xlt;*.xml;*.xlam;*.xla;*.xlw "
        ExcelSubir.Title = "Selecciona el archivo"
        ExcelSubir.ShowDialog()
        If ExcelSubir.FileName = "OpenFileDialog1" Then
            ExcelSubir.FileName = ""
        Else
            TextBox1.Text = ExcelSubir.FileName
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        'tabla = Path.GetFileNameWithoutExtension(TextBox1.Text)
        If TextBox1.Text <> "" Then
            libro = ap.Workbooks.Open(TextBox1.Text)
            sheet = libro.Sheets(1)
            'ComboBox1.Text = sheet.Name
            'For Each hoja In libro.Worksheets
            '    ComboBox1.Items.Add(hoja.Name)
            'Next
            'ComboBox1.Enabled = True
        End If
    End Sub

    Private Sub Btn_Salir_Click(sender As Object, e As EventArgs) Handles Btn_Salir.Click
        Me.Close()
        Me.Dispose()
    End Sub

End Class