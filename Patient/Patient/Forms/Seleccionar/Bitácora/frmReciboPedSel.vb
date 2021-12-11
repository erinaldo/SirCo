Public Class frmReciboPedSel


    Public SucSelect(50) As String
    Public IntSelect As Integer

    Public PedSelectPed(50) As String

    Public SucSelectPed(50) As String

    Public IntSelectPed As Integer
    Public IdFolio As Integer
    Dim SqlBuscar As String


    Private objDataSet As Data.DataSet
    'mreyes 09/Febrero/2012 12:42 a.m.
    'Forma que busca en varias tablas, por lo general un id y descripción
    Private Sub TraerSucursales()
        'mreyes 15/Febrero/2012 05:16 p.m.
        Using objSucursal As New BCL.BCLPedidos(GLB_ConStringCipSis)
            Try
                Me.Text = "Buscar Pedido"

                objDataSet = objSucursal.usp_PpalTraerPedidos(IdFolio)
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

        Call TraerSucursales()



    End Sub

    Sub InicializaGrid()
        DGrid.RowHeadersVisible = False
        ''DGrid.AllowUserToResizeColumns = True
        DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        Call AgregarColumna()

        DGrid.Columns(2).ReadOnly = False
        DGrid.Columns(0).ReadOnly = True
        DGrid.Columns(1).ReadOnly = True
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
            glb_formconsulta = True
            Call RellenaGrid()
            Call GenerarToolTip()
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
    Private Sub Txt_Buscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = UCase(e.KeyChar)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_Buscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Call RellenaGrid()
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
                'SucSelect(I) = row.Cells("sucursal").Value
                PedSelectPed(I) = row.Cells("pedido").Value
                SucSelectPed(I) = row.Cells("sucurped").Value
                I = I + 1
            End If
        Next
        IntSelect = I
        IntSelectPed = I
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