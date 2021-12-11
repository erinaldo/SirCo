Imports System.IO
Public Class frmCargaArchivoTaspaso

    Dim Sw_NoRegistros As Boolean = False
    Dim blnBindingOff As Boolean = False
    Public arreMarcas() As String
    Dim SqlBuscar As String
    Private objDataSet As Data.DataSet
    Private objDataSetFinal As New Data.DataSet

    Private Sub frmConsulta_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GLB_FormConsulta = False
    End Sub

    Private Sub frmConsulta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            GLB_FormConsulta = True
            Me.Close()
        End If
    End Sub

    Private Sub frmConsulta_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            GLB_FormConsulta = True
            Call GenerarToolTip()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub

    Private Sub GenerarToolTip()
        Try
            ToolTip.SetToolTip(Btn_Adjuntar, "Invertir selección")
            ToolTip.SetToolTip(Btn_Limpiar, "Filtrar marcas seleccionadas")
            ToolTip.SetToolTip(Btn_Adjuntar, "Adjuntar archivo")
            ToolTip.SetToolTip(Btn_Limpiar, "Limpiar Series Escaneadas")
            ToolTip.SetToolTip(Btn_AgregarSeries, "Agregar Series al Traspaso")

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Limpiar.Click
        Try
            DGrid.Rows.Clear()
            Txt_Archivo.Text = ""
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub Traspasos(ByVal myStream As StreamReader)
        Try
            DGrid.Rows.Clear()
            Dim NomArch As String
            NomArch = myStream.ReadToEnd()
            Dim Series() As String = Split(NomArch, vbNewLine)

            Dim objDataSetAux As New Data.DataSet
            objDataSetAux.Tables.Clear()
            objDataSetAux.Tables.Add()
            objDataSetAux.Tables(0).Columns.Add("serie")
            Dim cont As Integer = 0

            For i As Integer = 0 To Series.Length - 1
                If Series(i).Trim <> "" Then
                    objDataSetAux.Tables(0).Rows.Add()
                    objDataSetAux.Tables(0).Rows(i).Item("serie") = Series(i).Trim
                End If
            Next


            objDataSetFinal.Tables.Clear()
            objDataSetFinal.Tables.Add()
            objDataSetFinal.Tables(0).Columns.Add("serie")
            Dim cont1 As Integer = 0

            Dim objDataSetRepetidos As New Data.DataSet
            objDataSetRepetidos.Tables.Clear()
            objDataSetRepetidos.Tables.Add()
            objDataSetRepetidos.Tables(0).Columns.Add("serie")
            Dim cont2 As Integer = 0

            Dim objDataSetIlegibles As New Data.DataSet
            objDataSetIlegibles.Tables.Clear()
            objDataSetIlegibles.Tables.Add()
            objDataSetIlegibles.Tables(0).Columns.Add("serie")
            Dim cont3 As Integer = 0

            Dim blnExiste As Boolean = False
            For i As Integer = 0 To objDataSetAux.Tables(0).Rows.Count - 1
                If objDataSetFinal.Tables(0).Rows.Count = 0 Then
                    objDataSetFinal.Tables(0).Rows.Add()
                    objDataSetFinal.Tables(0).Rows(cont1).Item("serie") = objDataSetAux.Tables(0).Rows(i).Item("serie").ToString.Trim
                    cont1 += 1
                Else
                    Dim numSerie As String = objDataSetAux.Tables(0).Rows(i).Item("serie").ToString.Trim
                    Dim blnNumero As Boolean = False
                    If numSerie.Length <> 13 Then
                        objDataSetIlegibles.Tables(0).Rows.Add()
                        objDataSetIlegibles.Tables(0).Rows(cont3).Item("serie") = numSerie
                        cont3 += 1
                        Continue For
                    Else
                        For j As Integer = 0 To numSerie.Length - 1
                            Dim Numero As Char = numSerie.Substring(j, 1)
                            If Char.IsNumber(Numero) Then
                                blnNumero = True
                            Else
                                blnNumero = False
                                Exit For
                            End If
                        Next
                        If blnNumero = False Then
                            objDataSetIlegibles.Tables(0).Rows.Add()
                            objDataSetIlegibles.Tables(0).Rows(cont3).Item("serie") = numSerie.Trim
                            cont3 += 1
                            Continue For
                        End If
                    End If
                    blnExiste = False
                    For j As Integer = 0 To objDataSetFinal.Tables(0).Rows.Count - 1
                        If objDataSetAux.Tables(0).Rows(i).Item("serie").ToString.Trim = objDataSetFinal.Tables(0).Rows(j).Item("serie").ToString.Trim Then
                            blnExiste = True
                            Exit For
                        Else
                            blnExiste = False
                        End If
                    Next
                    If blnExiste = True Then
                        objDataSetRepetidos.Tables(0).Rows.Add()
                        objDataSetRepetidos.Tables(0).Rows(cont2).Item("serie") = objDataSetAux.Tables(0).Rows(i).Item("serie").ToString.Trim
                        cont2 += 1
                    Else
                        objDataSetFinal.Tables(0).Rows.Add()
                        objDataSetFinal.Tables(0).Rows(cont1).Item("serie") = objDataSetAux.Tables(0).Rows(i).Item("serie").ToString.Trim
                        cont1 += 1
                    End If
                End If
            Next

            Dim intMaxRenglones As Integer = 0
            intMaxRenglones = objDataSetFinal.Tables(0).Rows.Count
            If objDataSetRepetidos.Tables(0).Rows.Count > intMaxRenglones Then
                intMaxRenglones = objDataSetRepetidos.Tables(0).Rows.Count
            End If
            If objDataSetIlegibles.Tables(0).Rows.Count > intMaxRenglones Then
                intMaxRenglones = objDataSetIlegibles.Tables(0).Rows.Count
            End If

            If intMaxRenglones = 0 Then
                MessageBox.Show("Error, no se leyeron archivos correctamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            If intMaxRenglones = 1 Then
                DGrid.Rows.Add(intMaxRenglones)
            Else
                DGrid.Rows.Add(intMaxRenglones - 1)
            End If

            For i As Integer = 0 To objDataSetFinal.Tables(0).Rows.Count - 1
                DGrid.Rows(i).Cells(0).Value = objDataSetFinal.Tables(0).Rows(i).Item("serie")
            Next

            For i As Integer = 0 To objDataSetRepetidos.Tables(0).Rows.Count - 1
                DGrid.Rows(i).Cells(1).Value = objDataSetRepetidos.Tables(0).Rows(i).Item("serie")
            Next

            For i As Integer = 0 To objDataSetIlegibles.Tables(0).Rows.Count - 1
                DGrid.Rows(i).Cells(2).Value = objDataSetIlegibles.Tables(0).Rows(i).Item("serie")
            Next

            DGrid.Visible = True
            Btn_Limpiar.Visible = True
            Btn_AgregarSeries.Visible = True
            MessageBox.Show(cont1.ToString + " Articulos escaneados correctamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Adjuntar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Adjuntar.Click
        Try
            Dim myStream As StreamReader = Nothing
            myStream = Nothing
            Dim openFileDialog As New OpenFileDialog()


            openFileDialog.InitialDirectory = "c:\"
            openFileDialog.Filter = "Archivo de Texto(*.txt)|*.txt|Documento Excel(*.xlsx)|*.xlsx"
            openFileDialog.FileName = ""


            'me.dialog.filter = "Tipo texto|*.txt|tipo RTF|*.rtf|Tipo Word|*.doc.......etcétera"

            If openFileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                Try
                    myStream = New StreamReader(openFileDialog.FileName)
                    Txt_Archivo.Text = openFileDialog.FileName
                    If (myStream IsNot Nothing) Then
                        Call Traspasos(myStream)
                    Else
                        MessageBox.Show("El arhivo esta vacio", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Catch Ex As Exception
                    MessageBox.Show("Error, no se puede leer el archivo" & Ex.Message)
                End Try
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_AgregarSeries_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_AgregarSeries.Click
        Try
            Me.Close()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
End Class