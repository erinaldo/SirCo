Public Class frmLayoutCoqueta
    'miguel pérez 13/Septiembre/2012 04:06 p.m.    

    Private objDataSet As New Data.DataSet
    Private objDataSet1 As New Data.DataSet

    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click
        'miguel pérez 13/Septiembre/2012 04:20 p.m.
        Try
            If MsgBox("Esta seguro de querer generar el layout para todas las sucursales?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirmación") = MsgBoxResult.No Then Exit Sub

            Dim Archivo As String = ""
            Dim Linea As String = ""
            Dim strSKU As String = ""
            Dim strPares As String = ""
            Dim strCliente As String = ""
            Dim strSucursalCTA As String = ""
            Dim FecLayout As String = ""
            Dim strFecha As String = ""
            Dim strFechaTitulo As String = ""
            Dim Sucursal As String = ""
            strFecha = DTPicker.Value.ToString("yyyy-MM-dd")
            strFechaTitulo = strFecha.Substring(0, 4)
            strFechaTitulo += strFecha.Substring(5, 2)
            strFechaTitulo += strFecha.Substring(8, 2)
            Using objTrack As New BCL.BCLTrackCoqueta(GLB_ConStringCipSis)
                objDataSet1 = objTrack.usp_TiendasCTA()
            End Using
            For j As Integer = 0 To objDataSet1.Tables(0).Rows.Count - 1
                Sucursal = objDataSet1.Tables(0).Rows(j).Item("sucursal")
                strSucursalCTA = objDataSet1.Tables(0).Rows(j).Item("tienda")
                Using objTrack As New BCL.BCLTrackCoqueta(GLB_ConStringCipSis)
                    objDataSet = objTrack.usp_TraerLayoutCTA(strFecha, Sucursal)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Archivo = "C:\V" & strFechaTitulo.Trim & strSucursalCTA & ".txt"
                    Dim sw As New System.IO.StreamWriter(Archivo)
                    For i As Integer = 1 To objDataSet.Tables(0).Rows.Count
                        strSKU = objDataSet.Tables(0).Rows(i - 1).Item("SKU").ToString & ","
                        strPares = objDataSet.Tables(0).Rows(i - 1).Item("Pares").ToString & ","
                        strCliente = "3934" & ","
                        Linea = strSKU & strPares & strCliente & strSucursalCTA
                        sw.WriteLine(Linea)
                    Next
                    sw.Close()
                    Dim NombreArchivo As String = Archivo.Substring(3, 19)
                    My.Computer.Network.UploadFile(Archivo, "ftp://ftp.coqueta.com.mx/" & NombreArchivo, "ctorreon", "clte3934@93", True, 500)
                End If
            Next

            MessageBox.Show("Layout Generado para todas las sucursales", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

End Class