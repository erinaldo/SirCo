Imports System.Data.SqlClient
Imports System.Data
Imports System.Data.OleDb
Imports System
Imports System.IO
Imports System.Collections.Generic
Imports System.Text


Public Class frmactualizaUPCs
    Dim objExcel = CreateObject("Excel.Application")
    Dim objWorkbook
    Dim objWorksheet
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Ruta As String
        Dim nam As String
        If TextBox1.Text = "" Then
            MsgBox("Debe seleccionar una ruta de archivo valida", MsgBoxStyle.Information, "Error")
            TextBox1.Focus()
        Else
            Ruta = TextBox1.Text
            objWorkbook = objExcel.Workbooks.Open(Ruta)
            objExcel.DisplayAlerts = False
            objExcel.Visible = False
            objWorksheet = objWorkbook.Worksheets("Hoja1")
            objWorksheet.SaveAs("\\10.10.1.1\Sistemas .NET\CODIGO\" & Path.GetFileNameWithoutExtension(Ruta) & ".csv")
            objExcel.Quit
            nam = "\\10.10.1.1\Sistemas .NET\CODIGO\" & Path.GetFileNameWithoutExtension(Ruta) & ".csv"
            objWorkbook = objExcel.Workbooks.Open(nam)
            objExcel.DisplayAlerts = False
            objExcel.Visible = False
            objWorksheet = objWorkbook.Worksheets("Hoja1")
            objWorksheet.SaveAs("\\10.10.1.1\Sistemas .NET\CODIGO\" & Path.GetFileNameWithoutExtension(Ruta) & ".csv")
            objExcel.Quit
            Call Subir(nam)
            objExcel.Quit
            File.Delete(nam)
        End If
    End Sub
    Public Function Subir(ByVal Ruta As String)
        Try
            Using objeto As New BCL.BCLUPCs(GLB_ConStringSirCoVentaEnLineaSQL)
                Subir = objeto.usp_UPCs(Ruta)
            End Using
            MsgBox("Se han actualizado los UPC correctamente", MsgBoxStyle.Information, "Actualizacion")
            TextBox1.Clear()
            OpenFileDialog1.FileName = ""
        Catch ExceptionErr As Exception
            MsgBox("Se ha producido el siguiente error: " + ExceptionErr.Message,
                       MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Function

    Private Sub ActualizaUPCs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'MsgBox("Asegurese que el documen!!", MsgBoxStyle.Information, "Actualizacion")
        OpenFileDialog1.Filter = "Excel Files |*.csv;*.xlsx;*.xlsm;*.xlsb;*.xltx;*.xltm;*.xls;*.xlt;*.xml;*.xlam;*.xla;*.xlw |Todos los archivos (*.*)|*.*"
        OpenFileDialog1.Title = "Seleccion el archivo"
        OpenFileDialog1.ShowDialog()

        If OpenFileDialog1.FileName = "OpenFileDialog1" Then
            OpenFileDialog1.FileName = ""
        Else
            TextBox1.Text = OpenFileDialog1.FileName
        End If
    End Sub

End Class