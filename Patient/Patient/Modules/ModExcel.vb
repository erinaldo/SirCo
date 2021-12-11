Module ModExcel
    'mreyes 09/Febrero/2012 05:17 p.m.
    'Función para Exportar a excel y dejar abierto el archivo.
    Public Function ExportarDGridAExcel(ByVal DGrid As DataGridView, Optional ByVal Sw_Ocultas As Boolean = False, Optional ByVal sw_abrir As Boolean = False, Optional ByVal BanBajio As Boolean = False) As Boolean

        'Creamos las variables
        Dim exApp As New Microsoft.Office.Interop.Excel.Application
        Dim exLibro As Microsoft.Office.Interop.Excel.Workbook
        Dim exHoja As Microsoft.Office.Interop.Excel.Worksheet

        Try
            'Añadimos el Libro al programa, y la hoja al libro
            exLibro = exApp.Workbooks.Add
            exHoja = exLibro.Worksheets.Add()

            ' ¿Cuantas columnas y cuantas filas?
            Dim NCol As Integer = DGrid.ColumnCount
            Dim NRow As Integer = DGrid.RowCount
            Dim i1 As Integer = 1
            Dim Col1 As Integer = 1
            'Aqui recorremos todas las filas, y por cada fila todas las columnas y vamos escribiendo.
            For i As Integer = 1 To NCol
                ''exHoja.Cells.Item(1, i) = DGrid.Columns(i - 1).Name.ToString
                If DGrid.Columns(i - 1).Visible = True Or Sw_Ocultas = True Then
                    exHoja.Cells.Item(1, i1) = DGrid.Columns(i - 1).HeaderText
                    i1 = i1 + 1
                End If
            Next

            If BanBajio = True Then
                For Fila As Integer = 0 To NRow - 1
                    For Col As Integer = 0 To NCol - 1
                        If DGrid.Rows(Fila).Cells(Col).Visible = True Or Sw_Ocultas = True Then
                            If IsDBNull(DGrid.Rows(Fila).Cells(Col).Value) = False Then
                                If Mid(DGrid.Rows(Fila).Cells(Col).Value, 1, 1) = "0" Then
                                    exHoja.Cells.Item(Fila + 2, Col1) = "'" & DGrid.Rows(Fila).Cells(Col).Value
                                Else
                                    exHoja.Cells.Item(Fila + 2, Col1) = DGrid.Rows(Fila).Cells(Col).Value

                                End If
                                Col1 = Col1 + 1
                            End If
                        End If
                    Next
                    Col1 = 1
                Next


            Else

                For Fila As Integer = 0 To NRow - 1
                    For Col As Integer = 0 To NCol - 1
                        If DGrid.Rows(Fila).Cells(Col).Visible = True Or Sw_Ocultas = True Then
                            exHoja.Cells.Item(Fila + 2, Col1) = DGrid.Rows(Fila).Cells(Col).Value
                            Col1 = Col1 + 1
                        End If
                    Next
                    Col1 = 1
                Next

            End If
            'Titulo en negrita, Alineado al centro y que el tamaño de la columna se ajuste al texto

            exHoja.Rows.Item(1).Font.Bold = 1
            exHoja.Rows.Item(1).HorizontalAlignment = 3
            exHoja.Columns.AutoFit()


            'Aplicación visible
            If sw_abrir = False Then
                exApp.Application.Visible = True
            Else
                Dim nombre As String = ""


                nombre = "\" & Format(Date.Now, "yyyy-MM-dd hh:mm:ss")
                nombre = nombre.Replace("-", "")
                nombre = nombre.Replace(":", "")
                nombre = GLB_RutaArchivoDigitalPedidos & nombre & ".xls"
                exLibro.SaveAs(nombre)
                exLibro.Close()
            End If


            exHoja = Nothing
            exLibro = Nothing
            exApp = Nothing

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al exportar a Excel")
            Return False
        End Try

        Return True

    End Function

End Module
