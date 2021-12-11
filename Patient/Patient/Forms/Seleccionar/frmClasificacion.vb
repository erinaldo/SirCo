Public Class frmClasificacion


    Public CveSelect() As String
    Public DescripSelect() As String
    Public IntSelect As Integer


    Dim SqlBuscar As String
    Dim sw_load As Boolean = False

    Private objDataSet As Data.DataSet
    'mreyes 09/Febrero/2012 12:42 a.m.
    'Forma que busca en varias tablas, por lo general un id y descripción
    Private Sub TraerFamilias()
        'mreyes 15/Febrero/2012 05:16 p.m.
        Using objSucursal As New BCL.BCLResurtido(GLB_ConStringCipSis)
            Try
                Me.Text = "Buscar Sucursal"

                objDataSet = objSucursal.usp_TraerDifEstFamilia(1, "")
                ReDim CveSelect(objDataSet.Tables(0).Rows.Count - 1)
                ReDim DescripSelect(objDataSet.Tables(0).Rows.Count - 1)
                'Populate the Project Details section
                'DGrid.ReadOnly = True
                DGrid.DataSource = Nothing
                DGrid.DataSource = objDataSet.Tables(0)
                InicializaGrid()
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub


    Private Sub TraerFamilias2()
        'mreyes 15/Febrero/2012 05:16 p.m.
        Using objSucursal As New BCL.BCLResurtido(GLB_ConStringCipSis)
            Try
                Me.Text = "Buscar Sucursal"

                objDataSet = objSucursal.usp_TraerDifEstFamilia(2, Txt_Buscar.Text)
                ReDim CveSelect(objDataSet.Tables(0).Rows.Count - 1)
                ReDim DescripSelect(objDataSet.Tables(0).Rows.Count - 1)
                'Populate the Project Details section
                'DGrid.ReadOnly = True
                DGrid.DataSource = Nothing
                DGrid.DataSource = objDataSet.Tables(0)
                InicializaGrid()
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub


    Private Sub RellenaGrid()
        Dim SqlWhere As String = ""

        Call TraerFamilias()



    End Sub

    Sub InicializaGrid()
        DGrid.RowHeadersVisible = False
        ''DGrid.AllowUserToResizeColumns = True
        DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

        If sw_load = True Then
            Call AgregarColumna()
        End If
        DGrid.Columns("selec").ReadOnly = False
        DGrid.Columns("clave").ReadOnly = True
        DGrid.Columns("descrip").ReadOnly = True
        DGrid.Columns("selec").DisplayIndex = 2
    End Sub

    Private Sub frmConsulta_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        glb_formconsulta = False
    End Sub

    Private Sub frmConsulta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            glb_formconsulta = True
            Me.Close()
        End If

    End Sub

    Private Sub frmConsulta_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            sw_load = True
            GLB_FormConsulta = True
            Call RellenaGrid()
            Call GenerarToolTip()
            sw_load = False
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub
    Private Sub GenerarToolTip()
        Try

            ToolTip.SetToolTip(Btn_InvertirSeleccion, "Invertir selección")



        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub Txt_Buscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Buscar.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_Buscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Buscar.TextChanged
        Try
            Call TraerFamilias2()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub





    Private Sub Btn_Excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If ExportarDGridAExcel(DGrid) = False Then
                MsgBox("Error al exportar a Excel. Intente nuevamente.", MsgBoxStyle.Critical, "Excel")
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub Btn_InvertirSeleccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_InvertirSeleccion.Click
        'For Each row As DataGridViewRow In DGrid.Rows
        '    If row.Cells("Selec").Value = True Then
        '        row.Cells("Selec").Value = False
        '    Else
        '        row.Cells("Selec").Value = True
        '    End If
        'Next
        For i As Integer = 0 To DGrid.Rows.Count - 2
            If DGrid.Rows(i).Cells("Selec").Value = True Then
                DGrid.Rows(i).Cells("Selec").Value = False
            Else
                DGrid.Rows(i).Cells("Selec").Value = True
            End If
        Next
    End Sub

    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click
        Dim I As Integer = 0
        For Each row As DataGridViewRow In DGrid.Rows
            If row.Cells("Selec").Value = True Then
                CveSelect(I) = row.Cells("clave").Value
                DescripSelect(I) = row.Cells("descrip").Value
                I = I + 1
            End If
        Next
        IntSelect = I

        Me.Close()

    End Sub
    Private Sub AgregarColumna()
        'mreyes 21/Marzo/2012 09:52 a.m.

        Dim colImagen As DataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn()
        colImagen.Name = "Selec"
        colImagen.HeaderText = "Selec"
        colImagen.DisplayIndex = 2

        colImagen.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        colImagen.CellTemplate = New DataGridViewCheckBoxCell()
        ' añadir columna de imagen a la coleccion del grid 
        DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        ''DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DGrid.Columns.Add(colImagen)


    End Sub
    Private Sub DGrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellContentClick

    End Sub
End Class