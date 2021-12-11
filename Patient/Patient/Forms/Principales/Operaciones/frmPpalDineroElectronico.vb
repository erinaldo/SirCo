Public Class frmPpalDineroElectronico
    'mreyes 10/Noviembre/2016   10:01 a.m.


    Private objDataSet As Data.DataSet
    Dim Sw_Pintar As Boolean = False






    Private Sub RellenaGrid()
      
        DGrid.Visible = False
        'InicializaGrid()
        Using objTrasp As New BCL.BCLAparador(GLB_ConStringCipSis)

            Try
                Me.Cursor = Cursors.WaitCursor
                'DGrid.ReadOnly = True
                DGrid.DataSource = Nothing

                objDataSet = objTrasp.usp_PpalDineroElectronico(Txt_Cuenta.Text)

                'Populate the Project Details section
                If objDataSet.Tables(0).Rows.Count > 0 Then

                    '
                    DGrid.DataSource = objDataSet.Tables(0)
                    Sw_Pintar = True
                    InicializaGrid()
                    Txt_Cuenta.Enabled = False

                    Me.Cursor = Cursors.Default
                    Btn_Excel.Enabled = True

                    Sw_Pintar = True

                Else


                    Me.Cursor = Cursors.Default
                    MsgBox("No se encontraron registros que cumplan con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")
                    Btn_Excel.Enabled = False
                End If
                Me.Cursor = Cursors.Default
                ' LimpiarBusqueda()
                DGrid.Visible = True
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub GenerarToolTip()
        Try
            '

            ToolTip.SetToolTip(Btn_Excel, "Exportar a Excel")
            ToolTip.SetToolTip(Btn_Salir, "Salir")

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Sub InicializaGrid()
        'mreyes 10/Noviembre/2016   11:28 a.m.
        Try
            DGrid.RowHeadersVisible = False

            DGrid.Columns("Fecha").HeaderText = "Fecha"
            DGrid.Columns("Cuenta").HeaderText = "Cuenta"
            DGrid.Columns("tipo").HeaderText = "Tipo"
            DGrid.Columns("sucursal").HeaderText = "Det"
            DGrid.Columns("folio").HeaderText = "Folio"
            DGrid.Columns("Marca").HeaderText = "Marca"
            DGrid.Columns("EStilon").HeaderText = "Modelo"
            DGrid.Columns("dinero").HeaderText = "Dinero"
            DGrid.Columns("saldo").HeaderText = "Saldo"
            DGrid.Columns("fum").HeaderText = "fum"


            DGrid.Columns("fum").Visible = False
            DGrid.Columns("CUENTA").Visible = False
            DGrid.Columns("corrida").Visible = False
            DGrid.Columns("nombre").Visible = False

            DGrid.Columns("tipo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns("sucursal").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns("folio").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            DGrid.Columns("marca").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns("EStilon").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGrid.Columns("dinero").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGrid.Columns("saldo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


            DGrid.Columns("dinero").DefaultCellStyle.Format = "c"
            DGrid.Columns("saldo").DefaultCellStyle.Format = "c"

            Dim j As Integer
            Dim Saldo As Double = 0.0

            j = DGrid.RowCount - 2
            Txt_Nombre.Text = DGrid.Rows(1).Cells("nombre").Value
            For i As Integer = 0 To DGrid.RowCount - 2

                If DGrid.Rows(j).Cells("tipo").Value = "ASIGNADO" Then
                    Saldo = Saldo + CDbl(DGrid.Rows(j).Cells("dinero").Value)
                ElseIf DGrid.Rows(j).Cells("tipo").Value = "USADO" Then
                    Saldo = Saldo - CDbl(DGrid.Rows(j).Cells("dinero").Value)
                End If
                DGrid.Rows(j).Cells("saldo").Value = Saldo
                j = j - 1

            Next

            DGrid.Columns("saldo").DefaultCellStyle.Format = "c"

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub







    Private Sub Btn_Excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Excel.Click
        Try
            If ExportarDGridAExcel(DGrid) = False Then
                MsgBox("Error al exportar a Excel. Intente nuevamente.", MsgBoxStyle.Critical, "Excel")
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Salir.Click
        Me.Close()
    End Sub

    Private Sub Btn_Limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Limpiar.Click
        Try
            If DGrid.Rows.Count >= 1 Then
                DGrid.DataSource = Nothing
                DGrid.Columns.Clear()
                DGrid.Rows.Clear()


            End If

            Txt_Cuenta.Enabled = True
            Txt_Cuenta.Focus()
            Txt_Cuenta.Text = ""
            Txt_Nombre.Text = ""
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_Cuenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Cuenta.KeyPress
        ' e.KeyChar = Chr(0)
        Call pub_SoloNumeros(sender, e)
    End Sub

    Private Sub Txt_Cuenta_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Cuenta.LostFocus
        If Txt_Cuenta.Text <> "" Then
            Txt_Cuenta.Text = pub_RellenarIzquierda(Txt_Cuenta.Text, 13)
            Call RellenaGrid()
        End If
    End Sub

    Private Sub Txt_Cuenta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Cuenta.TextChanged
        'Dim tiempoInicial As DateTime
        'Dim tiempoFinal As DateTime

        'Dim evaluando As Boolean = False

        'Dim largo As Long = Me.Txt_Cuenta.Text.Length
        'If evaluando = False And largo >= 1 Then
        '    tiempoInicial = Now
        '    evaluando = True
        'Else
        '    If largo >= 1 Then 'evaluamos el tiempo
        '        tiempoFinal = Now
        '        Dim segundos As Long = DateDiff(DateInterval.Second, tiempoInicial, tiempoFinal)
        '        If segundos >= 0 Then
        '            MsgBox("Entrada no permitida por teclado", MsgBoxStyle.Exclamation, "C¢digo")
        '            Me.Txt_Cuenta.Text = ""
        '            evaluando = False
        '        End If
        '    End If
        'End If
        'If largo = 0 Then
        '    evaluando = False
        'End If
    End Sub

    Private Sub DGrid_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DGrid.CellFormatting
        Try
            If e.RowIndex = DGrid.RowCount - 1 Then

                Exit Sub
            End If
            If Sw_Pintar = False Then Exit Sub


            If UCase(Me.DGrid.Columns(e.ColumnIndex).Name) = "TIPO" Then

                If DGrid.Rows(e.RowIndex).Cells("TIPO").Value = "ASIGNADO" Then
                    DGrid.Rows(e.RowIndex).Cells("TIPO").Style.BackColor = Color.YellowGreen
                    DGrid.Rows(e.RowIndex).Cells("TIPO").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

                    DGrid.Rows(e.RowIndex).Cells("SALDO").Style.BackColor = Color.YellowGreen
                    DGrid.Rows(e.RowIndex).Cells("SALDO").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

                ElseIf DGrid.Rows(e.RowIndex).Cells("TIPO").Value = "USADO" Then
                    DGrid.Rows(e.RowIndex).Cells("TIPO").Style.BackColor = Color.Yellow
                    DGrid.Rows(e.RowIndex).Cells("TIPO").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

                    DGrid.Rows(e.RowIndex).Cells("SALDO").Style.BackColor = Color.Yellow
                    DGrid.Rows(e.RowIndex).Cells("SALDO").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)


                End If
            End If




        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub frmPpalDineroElectronico_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
   
    End Sub

    Private Sub frmPpalDineroElectronico_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Sw_Pintar = True
    End Sub
End Class