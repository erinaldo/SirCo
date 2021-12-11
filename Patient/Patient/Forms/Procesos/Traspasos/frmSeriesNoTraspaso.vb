Public Class frmSeriesNoTraspaso
    'mreyes 18/Agosto/20160     04:11 p.m.
    Private objDataSet As Data.DataSet

    Private Sub DGrid_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellEndEdit
        Try
            Dim columna As Integer = DGrid.CurrentCell.ColumnIndex
            Dim renglon As Integer = DGrid.CurrentCell.RowIndex
            Dim Serie As String = pub_RellenarIzquierda(DGrid.Rows(renglon).Cells(0).Value, 13)
            If columna = 0 Then 'ES DEVOLUCION Y ES SERIE 




                For I As Integer = 0 To DGrid.RowCount - 1 'objDataSet.Tables(0).Rows.Count - 1
                    If I <> renglon Then
                        If DGrid.Rows(I).Cells(0).Value = pub_RellenarIzquierda(DGrid.Rows(renglon).Cells(0).Value, 13) Then
                            MsgBox("La serie ya existe en el listado.", MsgBoxStyle.Critical, "Error")
                            DGrid.Rows(renglon).Cells(0).Value = ""
                            DGrid.Rows.RemoveAt(DGrid.CurrentCell.RowIndex)
                            Exit Sub
                        End If
                    End If
                Next


                Using ObjCatalogoEstilos As New BCL.BCLCatalogoEstilos(GLB_ConStringCipSis)


                    DGrid.Rows(renglon).Cells(0).Value = pub_RellenarIzquierda(DGrid.Rows(renglon).Cells(0).Value, 13)

                    objDataSet = ObjCatalogoEstilos.usp_TraerDatosSerie(Serie, "", "")

                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        ' si existe estilo, traerlo.




                        If objDataSet.Tables(0).Rows(0).Item("status").ToString = "BA" Then
                            MsgBox("La serie ya se encuentra dada de baja.", MsgBoxStyle.Critical, "Aviso")
                            DGrid.Rows(renglon).Cells(134).Value = ""
                            Exit Sub
                        End If

                        'If objDataSet.Tables(0).Rows(0).Item("status").ToString = "TR" Then
                        '    MsgBox("La serie se encuentra en traspaso.", MsgBoxStyle.Critical, "Aviso")
                        '    DGrid.Rows(renglon).Cells(134).Value = ""
                        '    Exit Sub
                        'End If




                        DGrid.Rows(renglon).Cells("modelo").Value = objDataSet.Tables(0).Rows(0).Item("ESTILON").ToString
                        DGrid.Rows(renglon).Cells("MARCA").Value = objDataSet.Tables(0).Rows(0).Item("MARCA").ToString
                        DGrid.Rows(renglon).Cells("MEDIDA").Value = objDataSet.Tables(0).Rows(0).Item("MEDIDA").ToString
                        DGrid.Rows(renglon).Cells("sucursal").Value = objDataSet.Tables(0).Rows(0).Item("sucursal").ToString


                    Else
                        MsgBox("La serie no existe o no se encuentra asignada a la sucursal.", MsgBoxStyle.Critical, "Aviso")
                        DGrid.Rows(renglon).Cells(134).Value = ""
                        Exit Sub

                    End If
                End Using
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click
        'mreyes 18/Agosto/2016  04:41 p.m.
        Try
            Dim Guardo As Boolean = False
            Dim Serie As String = ""
            Dim Marca As String = ""
            Dim Modelo As String = ""
            Dim Medida As String = ""
            Dim Sucursal As String = ""
            Dim Observa As String

            If MsgBox("Esta usted seguro de registrar las series.", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.No Then Exit Sub

            ''Guardar en temporal... 

            For renglon As Integer = 0 To DGrid.RowCount - 2
                Serie = DGrid.Rows(renglon).Cells("serie").Value
                Marca = DGrid.Rows(renglon).Cells("marca").Value
                Modelo = DGrid.Rows(renglon).Cells("modelo").Value
                Medida = DGrid.Rows(renglon).Cells("medida").Value
                Sucursal = DGrid.Rows(renglon).Cells("sucursal").Value
                Observa = DGrid.Rows(renglon).Cells("observacion").Value

                Using objBultos As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoSQL)

                    Guardo = objBultos.usp_Captura_ProtraspDetNoaplica(1, Serie, Marca, Modelo, Medida, Sucursal, Observa, GLB_Idempleado)

                End Using



            Next


            If usp_MatchPropuestaTraspaso() Then

            End If


            MsgBox("Series reportadas a Administración para su seguimiento.", MsgBoxStyle.Information, "Aviso")


            Me.Close()
            Me.Dispose()



            '' eliminar de la petición de traspaso... 

            '' igualar encabezados

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Function usp_MatchPropuestaTraspaso() As Boolean
        'mreyes 02/Noviembre/2016   05:32 p.m.


        Using objCalculo As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoSQL)
            Try
                'Get the specific project selected in the ListView controlsu

                Application.DoEvents()

                usp_MatchPropuestaTraspaso = objCalculo.usp_MatchPropuestaTraspaso




                Application.DoEvents()
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function

    Private Sub Btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cancelar.Click
        Me.Close()
        Me.Dispose()
    End Sub
End Class