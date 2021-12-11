Imports System.IO
Public Class frmCargarFirmasDistrib
    Private Sub Btn_AceptarF_Click(sender As Object, e As EventArgs) Handles Btn_AceptarF.Click
        Try
            Dim RutaOrigen As String
            Dim Archivo As String = ""
            Dim IdDistrib As Integer = 0
            Dim Distrib As String = ""
            Dim NumFoto As Integer = 0

            ' Dim TotalArchivos As Integer = 0
            Dim fileCreatedDate As DateTime

            'If sfdRuta.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            '    Txt_RutaOrigen.Text = sfdRuta.FileName

            'End If

            RutaOrigen = Txt_RutaOrigen.Text
            Dim TotalArchivos As Integer = Val(My.Computer.FileSystem.GetFiles(RutaOrigen))
            Dim Files As String(), File1 As String
            PBar1.Value = 0
            PBar1.Minimum = 0
            PBar1.Maximum = TotalArchivos
            Files = IO.Directory.GetFiles(RutaOrigen)
            For Each File1 In Files

                Archivo = IO.Path.GetFileNameWithoutExtension(File1)
                Archivo = IO.Path.GetFileName(File1)
                Distrib = Mid(Archivo, 1, 6)
                numfoto = Mid(Archivo, 8)
                IdDistrib = usp_TraerIdDistrib(distrib)




                '' grabar en sistema.



                PBar1.Value = PBar1.Value + 1

            Next



        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Function usp_TraerIdDistrib(Distrib As String) As Integer
        'mreyes 13/Febrero/2018 04:06 p.m.
        Dim IdDistrib As Integer = 0
        usp_TraerIdDistrib = 0
        Dim objDataSet As Data.DataSet
        Using objCatalogo As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
            Try

                objDataSet = objCatalogo.usp_TraerIdDistrib(Distrib)
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    '' cargar combos de ciudades colonias etc,.


                    IdDistrib = Val(objDataSet.Tables(0).Rows(0).Item("distrib").ToString)



                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try

            Return usp_TraerIdDistrib
        End Using
    End Function

End Class