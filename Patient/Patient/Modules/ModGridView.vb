Module ModGridView
    'mreyes 14/Febrero/2011 05:11 p.m.
    Public Function pub_SumarColumnaGridSTotal(ByVal DGrid As DataGridView, ByVal Columna As Integer, Optional ByVal HastaRenglon As Integer = 0) As Decimal
        'mreyes 14/Febrero/2012 05:08 p.m.
        Try
            ''Dim Col As Integer = DGrid.CurrentCell.ColumnIndex

            ''pub_SumarColumnaGrid = 0
            ''For Each row As DataGridViewRow In DGrid.Rows
            ''    If IsNumeric(row.Cells(Columna).Value) Then
            ''        pub_SumarColumnaGrid = (row.Cells(Columna).Value) + pub_SumarColumnaGrid
            ''    End If
            ''Next

            Dim Col As Integer = DGrid.CurrentCell.ColumnIndex

            pub_SumarColumnaGridSTotal = 0
            For renglon As Integer = 1 To IIf(HastaRenglon = 1, DGrid.RowCount - 2, HastaRenglon)
                If IsNumeric(DGrid.Rows(renglon).Cells(Columna).Value) Then
                    pub_SumarColumnaGridSTotal = CDbl(DGrid.Rows(renglon).Cells(Columna).Value) + pub_SumarColumnaGridSTotal
                End If
            Next
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function

    Public Function pub_SumarRenglonGridSTotal(ByVal DGrid As DataGridView, ByVal Renglon As Integer, ByVal Inicio As Integer, ByVal Fin As Integer) As Decimal
        'mreyes 16/Agosto/2016  01:28 p.m.
        Try

            Dim Col As Integer = DGrid.CurrentCell.ColumnIndex

            pub_SumarRenglonGridSTotal = 0
            For i As Integer = Inicio To Fin
                If IsNumeric(DGrid.Rows(Renglon).Cells(i).Value) Then
                    pub_SumarRenglonGridSTotal = CDbl(DGrid.Rows(Renglon).Cells(i).Value) + pub_SumarRenglonGridSTotal
                End If
            Next
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function

    Public Function pub_SumarColumnaGrid(ByVal DGrid As DataGridView, ByVal Columna As Integer, Optional ByVal HastaRenglon As Integer = 0) As Decimal
        'mreyes 14/Febrero/2012 05:08 p.m.
        Try
            ''Dim Col As Integer = DGrid.CurrentCell.ColumnIndex

            ''pub_SumarColumnaGrid = 0
            ''For Each row As DataGridViewRow In DGrid.Rows
            ''    If IsNumeric(row.Cells(Columna).Value) Then
            ''        pub_SumarColumnaGrid = (row.Cells(Columna).Value) + pub_SumarColumnaGrid
            ''    End If
            ''Next

            Dim Col As Integer = DGrid.CurrentCell.ColumnIndex

            pub_SumarColumnaGrid = 0
            For renglon As Integer = 0 To IIf(HastaRenglon = 0, DGrid.RowCount - 2, HastaRenglon)
                If IsNumeric(DGrid.Rows(renglon).Cells(Columna).Value) Then
                    pub_SumarColumnaGrid = CDbl(DGrid.Rows(renglon).Cells(Columna).Value) + pub_SumarColumnaGrid
                End If
            Next
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function
    Public Function pub_BuscarCadenaGrid(ByVal DGrid As DataGridView, ByVal Columna As Integer, ByVal Cadena As String) As Boolean
        'mreyes 22/Febrero/2012 11:00 p.m.
        Try

            pub_BuscarCadenaGrid = False

            For renglon As Integer = 0 To DGrid.RowCount - 2

                If DGrid.Rows(renglon).Cells(Columna).Value = Cadena Then
                    pub_BuscarCadenaGrid = True
                    Exit Function
                End If
            Next
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try


    End Function

    Public Function pub_BuscarNoFechaGrid(ByVal DGrid As DataGridView, ByVal Columna As Integer, ByVal Cadena As String) As Boolean
        'mreyes 24/Febrero/2012 12:03 p.m.
        Try

            pub_BuscarNoFechaGrid = False

            For renglon As Integer = 0 To DGrid.RowCount - 2

                If CDate(DGrid.Rows(renglon).Cells(Columna).Value) = Cadena And DGrid.Rows(renglon).Cells(0).Value <> "" Then
                    pub_BuscarNoFechaGrid = True
                    Exit Function
                ElseIf IsDBNull(DGrid.Rows(renglon).Cells(Columna).Value) = True Then
                    pub_BuscarNoFechaGrid = True
                    Exit Function
                ElseIf  DGrid.Rows(renglon).Cells(Columna).ToString.Length = 0 Then
                    pub_BuscarNoFechaGrid = True
                    Exit Function
                End If

            Next
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try


    End Function
End Module
