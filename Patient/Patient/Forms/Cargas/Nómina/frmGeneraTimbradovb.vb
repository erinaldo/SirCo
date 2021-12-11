Public Class frmGeneraTimbradovb
    Public idperiodo As Integer
    Dim Sql As String
    Private objDataSet As Data.DataSet
    Public SucSelect(250) As String
    Public IntSelect As Integer
    Public Periodo As String = ""
    Public Fechaperiodo As String = ""

    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click
        Try
            Dim I As Integer = 0
            Periodo = "0"
            For Each row As DataGridViewRow In DGrid.Rows
                If row.Cells("Selec").Value = True Then
                    SucSelect(I) = row.Cells("idperiodo").Value
                    Periodo = row.Cells("idperiodo").Value
                    Fechaperiodo = row.Cells("Periodo").Value
                    I = I + 1
                End If
            Next

            IntSelect = I
            If Periodo = "" Then
                MessageBox.Show("Debe seleccionar un periodo.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            If MsgBox("Esta seguro de querer Generar Timbrado " + Fechaperiodo + " ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.Yes Then
                GeneraTimbrado()
            End If

            MsgBox("Proceso terminado, correctamente.", MsgBoxStyle.Information)

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try

    End Sub

    Function GeneraTimbrado() As Boolean
        'Gmanvaz 04/Febrero/2017 11:33 a.m.

        Using objGeneraTimbrado As New BCL.BCLGeneraTimbrado(GLB_ConStringNomSis)
            'Get a new Project DataSet
            Try
                'Add the Project
                If objGeneraTimbrado.usp_GeneraTimbrado(Periodo) Then
                    'Throw New Exception("Falló Inserción de Timbrado")
                    GeneraTimbrado = True
                Else
                    GeneraTimbrado = True
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function

    Private Sub frmGeneraTimbradovb_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call RellenaGrid()
        Call BuscarPeriodos()
        Call GenerarToolTip()

    End Sub
    Private Sub GenerarToolTip()
        Try
            Dim toolTip1 As New ToolTip()

            toolTip1.SetToolTip(Btn_Aceptar, "Aceptar")
            toolTip1.SetToolTip(Btn_Cancelar, "Cancelar")

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub BuscarPeriodos()
        'SucSelect(250)
        For Each row As DataGridViewRow In DGrid.Rows
            For i As Integer = 0 To IntSelect - 1
                If InStr(row.Cells("idperiodo").Value, SucSelect(i)) Then
                    row.Cells("Selec").Value = True
                    Exit For
                End If
            Next
        Next

    End Sub

    Private Sub RellenaGrid()
        'Gmanvaz 08/Febrero/2017 11:33 a.m.
        Using objRegistro As New BCL.BCLMySqlGral(GLB_ConStringNomSis)

            Try
                Me.Cursor = Cursors.WaitCursor
                ' DGrid.ReadOnly = True
                DGrid.DataSource = Nothing

                objDataSet = objRegistro.usp_TraerPeriodoNomina(2)
                'Populate the Project Details section
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    'Populate the Project Details section

                    DGrid.DataSource = objDataSet.Tables(0)
                    'If Sw_Load = False Then
                    InicializaGrid()
                    'End If
                    'LimpiarBusqueda()
                    Me.Cursor = Cursors.Default

                Else

                    Me.Cursor = Cursors.Default
                    MsgBox("No se encontraron empleados que cumplan con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")

                End If
                Me.Cursor = Cursors.Default
                ' LimpiarBusqueda()

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using


    End Sub

    Sub InicializaGrid()
        'mreyes 30/Junio/2012 10:47 a.m.
        Try

            DGrid.RowHeadersVisible = False
            ' DGrid.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, 8, FontStyle.Regular)
            DGrid.Columns(0).HeaderText = "IdPeriodo"
            DGrid.Columns(1).HeaderText = "Periodo"
            DGrid.Columns(2).HeaderText = "FechaIni"
            DGrid.Columns(3).HeaderText = "FechaFin"
            DGrid.Columns(0).Visible = False
            DGrid.Columns(2).Visible = False
            DGrid.Columns(3).Visible = False

            DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

            Call AgregarColumna()
            DGrid.Columns(4).ReadOnly = False
            DGrid.Columns(0).ReadOnly = True
            DGrid.Columns(1).ReadOnly = True

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub AgregarColumna()
        'mreyes 21/Marzo/2012 09:52 a.m.

        Dim colImagen As DataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn()
        colImagen.Name = "Selec"
        colImagen.HeaderText = "Selec"
        colImagen.DisplayIndex = 4

        colImagen.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        colImagen.CellTemplate = New DataGridViewCheckBoxCell()
        ' añadir columna de imagen a la coleccion del grid 
        DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        ''DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DGrid.Columns.Add(colImagen)


    End Sub
   
    Private Sub Btn_Cancelar_Click(sender As Object, e As EventArgs) Handles Btn_Cancelar.Click
        Me.Close()
    End Sub
End Class