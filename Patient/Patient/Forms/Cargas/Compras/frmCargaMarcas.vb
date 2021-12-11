Public Class frmCargaMarcas

    Dim Sw_NoRegistros As Boolean = False
    Dim blnBindingOff As Boolean = False
    Public arreMarcas() As String
    Dim SqlBuscar As String
    Private objDataSet As Data.DataSet

    Private Sub TraerMarcas()
        Using objCalendario As New BCL.BCLCalendario(GLB_ConStringCipSis)
            Try
                If Sw_NoRegistros = True Then
                    DGrid.Columns.Remove("Selec")
                End If
                objDataSet = objCalendario.usp_TraerMarca("", "")
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    DGrid.DataSource = Nothing
                    DGrid.DataSource = objDataSet.Tables(0)
                    Sw_NoRegistros = True
                    InicializaGrid()
                Else
                    Sw_NoRegistros = False
                End If

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub RellenaGrid()
        Dim SqlWhere As String = ""
        Call TraerMarcas()

        'Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringCipSis)
        '    Try
        '        If Txt_Buscar.Text.Length > 0 Then
        '            SqlWhere = " WHERE     descrip LIKE '%" & Txt_Buscar.Text & "%'"
        '        End If

        '        SqlBuscar = objMySqlGral.ufn_TraeSqlBuscar("MARCA", SqlWhere)
        '        'Me.Text = "Buscar Marca"

        '        objDataSet = objMySqlGral.usp_TraerUnCampo(SqlBuscar)
        '        'Populate the Project Details section
        '        DGrid.ReadOnly = True
        '        DGrid.DataSource = Nothing
        '        DGrid.DataSource = objDataSet.Tables(0)

        '        Call InicializaGrid()

        '    Catch ExceptionErr As Exception
        '        MessageBox.Show(ExceptionErr.Message.ToString)
        '    End Try
        'End Using
    End Sub

    Sub InicializaGrid()
        DGrid.RowHeadersVisible = False
        ''DGrid.AllowUserToResizeColumns = True


        'DGrid.Columns(0).HeaderText = "Marca"
        'DGrid.Columns(1).HeaderText = "Descripción"


        DGrid.Columns(0).HeaderText = "Decripción"
        DGrid.Columns(1).HeaderText = "Factor"
        DGrid.Columns(2).HeaderText = "Resmin"
        DGrid.Columns(3).HeaderText = "Marca"

        DGrid.Columns(1).Visible = False
        DGrid.Columns(2).Visible = False

        DGrid.Columns(3).DisplayIndex = 1
        DGrid.Columns(0).DisplayIndex = 2

        DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

        Call AgregarColumna()

        DGrid.Columns(0).ReadOnly = True
        DGrid.Columns(3).ReadOnly = True
    End Sub

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
            Call RellenaGrid()
            Call GenerarToolTip()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub

    Private Sub GenerarToolTip()
        Try
            ToolTip.SetToolTip(Btn_InvertirSeleccion, "Invertir selección")
            ToolTip.SetToolTip(Btn_Aceptar, "Filtrar marcas seleccionadas")
           
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
        Dim valor As String
        Dim intNumLet As Integer = 0
        Dim cm1 As CurrencyManager
        Try

            'If blnBindingOff = False Then
            cm1 = BindingContext(Me.DGrid.DataSource)
            blnBindingOff = True
            'End If

            cm1.SuspendBinding()

            For i As Integer = 0 To DGrid.Rows.Count - 2
                'valor = DGrid.Rows(i).Cells("marca").Value
                intNumLet = Txt_Buscar.Text.Length
                valor = Txt_Buscar.Text

                If Mid(DGrid.Rows(i).Cells("descrip").Value, 1, intNumLet) = valor Then
                    DGrid.Rows(i).Visible = True
                    Continue For
                End If

                If Mid(DGrid.Rows(i).Cells("descrip").Value, 1, intNumLet) <> valor Then
                    DGrid.Rows(i).Visible = False
                    Continue For
                End If

            Next

            cm1.ResumeBinding()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub Btn_InvertirSeleccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_InvertirSeleccion.Click
        For i As Integer = 0 To DGrid.Rows.Count - 2
            If DGrid.Rows(i).Cells("Selec").Value = True Then
                DGrid.Rows(i).Cells("Selec").Value = False
            Else
                DGrid.Rows(i).Cells("Selec").Value = True
            End If
        Next
    End Sub

    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click
        'Tony Garcia - 14/Enero/2012 - 09:35 a.m.
        'Dim myform As New frmEspera
        Dim i As Integer = 0
        Dim intContador = 0

        For Each row As DataGridViewRow In DGrid.Rows
            If row.Cells("Selec").Value = True Then
                ReDim Preserve arreMarcas(intContador)
                arreMarcas(intContador) = row.Cells("MARCA").Value
                intContador += 1
            End If
        Next

        Me.Close()
    End Sub

    Private Sub AgregarColumna()
        Dim colImagen As DataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn()
        colImagen.Name = "Selec"
        colImagen.HeaderText = "Selec"
        colImagen.DisplayIndex = 3

        colImagen.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        colImagen.CellTemplate = New DataGridViewCheckBoxCell()
        ' añadir columna de imagen a la coleccion del grid 
        DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        ''DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DGrid.Columns.Add(colImagen)
    End Sub

    Private Sub DGrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellContentClick

    End Sub

    Private Sub Pnl_Edicion_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Pnl_Edicion.Paint

    End Sub
End Class