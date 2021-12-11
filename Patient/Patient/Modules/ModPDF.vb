Module ModPDF
   
    ' ''mreyes 10/Febrero/2012 01:34 p.m.

    ''Public Sub ExportarDGridAPDF(ByVal DGrid As DataGridView)

    ''    Try
    ''        Dim DataGrid As New DGrid
    ''        DataGrid = DGrid
    ''        'Intentar generar el documento.
    ''        Dim doc As New Document(PageSize.A4.Rotate(), 11, 11, 11, 11)
    ''        'Path que guarda el reporte en el escritorio de windows (Desktop).
    ''        Dim filename As String = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\Exportar.pdf"
    ''        Dim file As New FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.ReadWrite)
    ''        PdfWriter.GetInstance(doc, file)
    ''        doc.Open()
    ''        'Se crea un objeto PDFTable con el numero de columnas del DGRID. 
    ''        Dim datatable As New PdfPTable(DGrid.ColumnCount)
    ''        'Se asignan algunas propiedades para el diseño del PDF.
    ''        datatable.DefaultCell.Padding = 3
    ''        Dim headerwidths As Single() = GetColumnasSize(DataGrid)
    ''        datatable.SetWidths(headerwidths)
    ''        datatable.WidthPercentage = 100
    ''        datatable.DefaultCell.BorderWidth = 2
    ''        datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER
    ''        'Se crea el encabezado en el PDF. 
    ''        Dim encabezado As New Paragraph("TryCodeNet", New Font(Font.Name = "Tahoma", 14, Font.Bold))
    ''        'Se crea el texto abajo del encabezado.
    ''        Dim texto As New Phrase("LoboGriz" + Now.Date(), New Font(Font.Name = "Tahoma", 10, Font.Bold))
    ''        'Se capturan los nombres de las columnas del DataGrid .
    ''        For i As Integer = 0 To DataGrid.ColumnCount - 1
    ''            datatable.AddCell(DataGrid.Columns(i).HeaderText)
    ''        Next
    ''        datatable.HeaderRows = 1
    ''        datatable.DefaultCell.BorderWidth = 1
    ''        'Se generan las columnas del DataGrid . 
    ''        datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT
    ''        For i As Integer = 0 To DataGrid.RowCount - 1
    ''            For j As Integer = 0 To DataGrid.ColumnCount - 1
    ''                datatable.AddCell(DataGrid(j, i).Value.ToString)
    ''            Next
    ''            datatable.CompleteRow()
    ''        Next
    ''        'Se agrega el PDFTable al documento.
    ''        doc.Add(encabezado)
    ''        doc.Add(texto)
    ''        doc.Add(datatable)
    ''        doc.Close()
    ''        Process.Start(filename)
    ''    Catch ex As Exception
    ''        Me.Invoke(New MethodInvoker(AddressOf ErrorVisorPDF))
    ''    End Try

End Module
