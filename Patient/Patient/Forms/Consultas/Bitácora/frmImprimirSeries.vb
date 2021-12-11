Imports System.Drawing.Printing
Public Class frmImprimirSeries
    'mreyes 23/Septiembre/2015  11:43 a.m.
    Dim Contenido As PrintPageEventArgs
    Dim WithEvents Documento As New PrintDocument
    Dim impresora As New PrintDialog

    Dim Guardo As Boolean = False
    'E = ESTILO
    Public Campo As String = "" '' valor de regreso para el primer texto
    Public Campo1 As String = "" ''valor de regreso para el segundo texto
    Dim Sw_NoRegistros As Boolean = False
    Public Tipo As String = ""
    Public Sucursal As String = ""
    Public Folio As String = ""
    Public IdFolio As Integer = 0
    Public Marca As String = ""
    Public Modelo As String = ""


    Public Division As String = ""
    Public Depto As String = ""
    Public Familia As String = ""
    Public Linea As String = ""
    Public l1 As String = ""
    Public l2 As String = ""
    Public l3 As String = ""
    Public l4 As String = ""
    Public l5 As String = ""
    Public l6 As String = ""


    Dim Sw_Load As Boolean = True
    Dim SqlBuscar As String
    Private objDataSet As Data.DataSet

    Private Sub Documento_PrintPage(ByVal sender As System.Object, _
                                ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles Documento.PrintPage


        'Contenido = e
        'Contenido.Graphics.DrawString(Glb_ModeloEtiqueta, New Font("Arial", 34), Brushes.Black, 40, 0)
        'Contenido.Graphics.DrawString(Glb_CorridaEtiqueta, New Font("Wide Latin", 12), Brushes.Black, 250, 20)
        'Contenido.Graphics.DrawString(Glb_MedidaEtiqueta, New Font("Arial", 20), Brushes.Black, 200, 15)
        'Contenido.Graphics.DrawString("*" & Glb_SerieEtiqueta & "*", New Font("C39HrP48DhTt", 48), Brushes.Black, 30, 50)

        'Contenido.Graphics.DrawString(Glb_MarcaEtiqueta, New Font("Arial", 20), Brushes.Black, 200, 75)

        'Contenido.Graphics.DrawString(Glb_DescripCEtiqueta, New Font("Arial", 8), Brushes.Black, 10, 120)


        'Contenido.HasMorePages = False


        Contenido = e
        Contenido.Graphics.DrawString(Glb_ModeloEtiqueta, New Font("Arial", 34), Brushes.Black, 40, 0)
        ' Contenido.Graphics.DrawString(Glb_CorridaEtiqueta, New Font("Wide Latin", 12), Brushes.Black, 250, 20)
        Contenido.Graphics.DrawString(Glb_MedidaEtiqueta, New Font("Arial", 20), Brushes.Black, 200, 15)
        Contenido.Graphics.DrawString("*" & Glb_SerieEtiqueta & "*", New Font("C39HrP48DhTt", 48), Brushes.Black, 20, 50)

        Contenido.Graphics.DrawString(Glb_MarcaEtiqueta, New Font("Arial", 14), Brushes.Black, 200, 75)

        Contenido.Graphics.DrawString(Glb_DescripCEtiqueta, New Font("Arial", 8), Brushes.Black, 10, 120)


        Contenido.HasMorePages = False



    End Sub

    Private Sub RellenaGrid()
        Dim SqlWhere As String = ""
        Dim Buscar As String = ""

        '---- buscar duplicidad de series.
        If Txt_Serie1.Text <> "" Then
            Using objAjustes As New BCL.BCLAjustes(GLB_ConStringCipSis)


                objDataSet = objAjustes.usp_Captura_TraerImpreSeries(5, "", Txt_Serie1.Text, Txt_Serie2.Text, GLB_Idempleado)

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    MsgBox("No puede imprimir etiquetas, no se ha terminado de actualizar el recibo. Avice a Sistemas.", MsgBoxStyle.Critical, "Error")
                    Exit Sub
                End If
            End Using
        End If
        '----buscar duplicidad de series.



        Using objMySqlGral As New BCL.BCLPedidos(GLB_ConStringCipSis)
            Try

                If Txt_IdFolioBulto.Text <> "" Then
                    Sucursal = Mid(Txt_IdFolioBulto.Text, 1, 2)
                    Folio = Mid(Txt_IdFolioBulto.Text, 3, 6)
                End If


                objDataSet = objMySqlGral.usp_TraerSeries("S", Sucursal, Folio, IdFolio, Txt_Serie1.Text, Txt_Serie2.Text, "", "", "", "", "", "", "", "", "", "")


                'Populate the Project Details section

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    'Populate the Project Details section
                    Sw_NoRegistros = True
                    DGrid.DataSource = objDataSet.Tables(0)
                    InicializaGrid()
                    'LimpiarBusqueda()
                    Me.Cursor = Cursors.Default
                    Btn_Excel.Enabled = True
                    Sw_NoRegistros = True
                Else
                    Sw_NoRegistros = False
                    Me.Cursor = Cursors.Default
                    MsgBox("La serie no existe O esta dada de baja, verifique por favor. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")
                    Btn_Excel.Enabled = False
                    


                End If


            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Sub InicializaGrid()
        DGrid.RowHeadersVisible = False
        ''DGrid.AllowUserToResizeColumns = True
        DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

        'mreyes 12/Febrero/2011 05:37 p.m.
        Try

            If Tipo = "M" Then
                DGrid.Columns(0).HeaderText = "Sucursal"
                DGrid.Columns(1).HeaderText = "Serie"
                DGrid.Columns(2).HeaderText = "Marca"
                DGrid.Columns(3).HeaderText = "Modelo"
                DGrid.Columns(4).HeaderText = "Corrida"
                DGrid.Columns(5).HeaderText = "Medida"

                DGrid.Columns(0).ReadOnly = True
                DGrid.Columns(1).ReadOnly = True
                DGrid.Columns(2).ReadOnly = True
                DGrid.Columns(3).ReadOnly = True
                DGrid.Columns(4).ReadOnly = True
                DGrid.Columns(5).ReadOnly = True
                DGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

                DGrid.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Else
                DGrid.Columns(0).HeaderText = "Serie"
                DGrid.Columns(1).HeaderText = "Marca"
                DGrid.Columns(2).HeaderText = "Modelo"
                DGrid.Columns(3).HeaderText = "Corrida"
                DGrid.Columns(4).HeaderText = "Medida"


                DGrid.Columns(0).ReadOnly = True
                DGrid.Columns(1).ReadOnly = True
                DGrid.Columns(2).ReadOnly = True
                DGrid.Columns(3).ReadOnly = True
                DGrid.Columns(4).ReadOnly = True
                DGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

                DGrid.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            End If




            DGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try


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
            Sw_Load = True
            GLB_FormConsulta = True
            If GLB_Idempleado = 132 Then
                Btn_SeriesM.Visible = True
            End If


            '    Call RellenaGrid()
            Call GenerarToolTip()

            'If Tipo = "M" Then
            '    Me.Text = "Series Activas " + Marca + " - " + Modelo
            'ElseIf Tipo = "A" Then
            '    Me.Text = "Series en Aparador"

            'End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub
    Private Sub GenerarToolTip()
        Try
            ToolTip.SetToolTip(Btn_Excel, "Exportar a Excel")
            ToolTip.SetToolTip(Txt_Serie1, "Escriba lo que pretende buscar")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub Txt_Buscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Serie1.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
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

    Private Sub Configurar()
        impresora.Document = Documento
        ' impresora.ShowDialog()

        Documento.PrinterSettings = impresora.PrinterSettings
        '    Documento.PrinterSettings.PaperSizes("Custom Paper Size", 100, 200)

    End Sub


    Private Sub Btn_Series_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Series.Click
        ' no puede imprimir etiquetas, 
        Dim objDataSet As Data.DataSet
        Dim Sw_NoImprime As Boolean = False


        If GLB_Sw_Costos = False Then

            'buscar si es serie impresa
            'buscar si es folio impreso
            If Txt_IdFolioBulto.Text <> "" Then
                Try
                    Using objAjustes As New BCL.BCLAjustes(GLB_ConStringCipSis)


                        objDataSet = objAjustes.usp_Captura_TraerImpreSeries(2, "", Txt_IdFolioBulto.Text, "", GLB_Idempleado)

                        If objDataSet.Tables(0).Rows.Count > 0 Then
                            MsgBox("No puede imprimir etiquetas, ya que hay impresión previa. Este proceso solo lo puede autorizar Sistemas.", MsgBoxStyle.Critical, "Error")
                            Exit Sub
                        End If
                    End Using

                Catch ExceptionErr As Exception
                    MessageBox.Show(ExceptionErr.Message.ToString)
                End Try
            End If
        End If


        If MsgBox("Esta usted seguro de querer imprimir, las etiquetas seleccionadas. Asegurese de que la impresora este encendida.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirmación") = MsgBoxResult.No Then Exit Sub

        'mreyes 14/Septiembre/2015  11:24 a.m.
        Lbl_Leyenda.Text = ""
        PBar1.Value = 0
        PBar1.Minimum = 0
        PBar1.Maximum = DGrid.RowCount - 1
        Configurar()
        Dim DescripC As String = ""
        Dim Marca As String = ""
        Dim Estilon As String = ""



        Dim Medida As String = ""
        Dim Corrida As String = ""
        Dim Serie As String = ""
        Dim I As Integer
        For I = 0 To DGrid.RowCount - 1
            ' CAST(Taller.cod_taller AS CHAR CHARACTER SET utf8 

            


            Glb_DescripCEtiqueta = DGrid.Rows(I).Cells("descripc").Value & ""
            'Marca = Replace(Trim(DGrid.Rows(I).Cells("nomlayout").Value & ""), "Ñ", "@")
            Glb_MarcaEtiqueta = DGrid.Rows(I).Cells("marca").Value & ""
            Glb_ModeloEtiqueta = DGrid.Rows(I).Cells("estilon").Value & ""
            Glb_MedidaEtiqueta = DGrid.Rows(I).Cells("medida").Value & ""
            Glb_CorridaEtiqueta = DGrid.Rows(I).Cells("corrida").Value & ""
            Glb_SerieEtiqueta = DGrid.Rows(I).Cells("serie").Value & ""


            'Call usp_ImprimeEtiqueta(sender, e, Marca, Estilon, DescripC, Corrida, Medida, Serie)
            Lbl_Leyenda.Text = Glb_SerieEtiqueta & " Son " & I & " de " & DGrid.RowCount - 1
            If Glb_SerieEtiqueta <> "" Then
                PBar1.Value = PBar1.Value + 1
            End If

            If Glb_SerieEtiqueta <> "" Then
                If Txt_IdFolioBulto.Text = "" And GLB_IdDeptoEmpleado <> 1 Then
                    Try
                        Using objAjustes As New BCL.BCLAjustes(GLB_ConStringCipSis)


                            objDataSet = objAjustes.usp_Captura_TraerImpreSeries(3, "", "", Glb_SerieEtiqueta, GLB_Idempleado)

                            If objDataSet.Tables(0).Rows.Count > 0 Then
                                MsgBox("No puede imprimir etiquetas, ya que hay impresión previa. Verifique con su encargado de Recibo.", MsgBoxStyle.Critical, "Error")
                                Sw_NoImprime = True
                                GoTo saltar
                            End If
                        End Using

                    Catch ExceptionErr As Exception
                        MessageBox.Show(ExceptionErr.Message.ToString)
                    End Try
                End If
            End If
            If Glb_SerieEtiqueta <> "" Then
                Documento.Print()
            End If


            'gUARDAR LA SERIE IMPRESA.
saltar:
            If Glb_SerieEtiqueta <> "" Then
                Using objAjuste As New BCL.BCLAjustes(GLB_ConStringCipSis)
                    Guardo = objAjuste.usp_Captura_ImpreSeries(1, GLB_CveSucursal, Txt_IdFolioBulto.Text, Glb_SerieEtiqueta, IIf(Sw_NoImprime = True, "NO", "SI"), GLB_Idempleado)

                End Using
            End If
        Next






    End Sub

    Private Sub Btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cancelar.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub Pnl_Edicion_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Pnl_Edicion.Paint

    End Sub

    Private Sub Btn_Filtro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Filtro.Click
        Try
            'buscar si es folio impreso
            If GLB_Idempleado <> 132 Then


                If Txt_IdFolioBulto.Text <> "" Then
                    '---- buscar duplicidad de series.

                    Using objAjustes As New BCL.BCLAjustes(GLB_ConStringCipSis)


                        objDataSet = objAjustes.usp_Captura_TraerImpreSeries(4, "", Txt_IdFolioBulto.Text, "", GLB_Idempleado)

                        If objDataSet.Tables(0).Rows.Count > 0 Then
                            MsgBox("No puede imprimir etiquetas, no se ha terminado de actualizar el recibo RECUERDE QUE MANEJAMOS REPLICACION. Avice a Sistemas.", MsgBoxStyle.Critical, "Error")
                            Exit Sub
                        End If
                    End Using

                    '----buscar duplicidad de series.


                    Using objAjustes As New BCL.BCLAjustes(GLB_ConStringCipSis)


                        objDataSet = objAjustes.usp_Captura_TraerImpreSeries(2, "", Txt_IdFolioBulto.Text, "", GLB_Idempleado)

                        If objDataSet.Tables(0).Rows.Count > 0 Then
                            MsgBox("No puede imprimir etiquetas, ya que hay impresión previa. Avise a su encargado de Recibo y realice una petición a Sistemas.", MsgBoxStyle.Critical, "Error")
                            Exit Sub
                        End If
                    End Using

                End If
            End If

            Call RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_Serie1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Serie1.LostFocus
        If Txt_Serie1.Text = "" Then Exit Sub
        Txt_Serie1.Text = pub_RellenarIzquierda(Txt_Serie1.Text, 13)
        Txt_Serie2.Text = pub_RellenarIzquierda(Txt_Serie1.Text, 13)
    End Sub

    Private Sub Txt_Serie1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Serie1.TextChanged

    End Sub

    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Btn_Limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Limpiar.Click
        If DGrid.Rows.Count >= 1 Then
            DGrid.DataSource = Nothing
            DGrid.Columns.Clear()
            DGrid.Rows.Clear()

        End If
        Txt_Serie1.Text = ""
        Txt_Serie2.Text = ""
        Txt_IdFolioBulto.Text = ""
        Txt_Serie1.Focus()

    End Sub

    Private Sub Btn_SeriesM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_SeriesM.Click
        Dim SqlWhere As String = ""
        Dim Buscar As String = ""

        Using objMySqlGral As New BCL.BCLPedidos(GLB_ConStringCipSis)
            Try

              


                objDataSet = objMySqlGral.usp_TraerSeries("T", Sucursal, Folio, IdFolio, Txt_Serie1.Text, Txt_Serie2.Text, "", "", "", "", "", "", "", "", "", "")


                'Populate the Project Details section

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    'Populate the Project Details section
                    Sw_NoRegistros = True
                    DGrid.DataSource = objDataSet.Tables(0)
                    InicializaGrid()
                    'LimpiarBusqueda()
                    Me.Cursor = Cursors.Default
                    Btn_Excel.Enabled = True
                    Sw_NoRegistros = True
                Else
                    Sw_NoRegistros = False
                    Me.Cursor = Cursors.Default
                    MsgBox("La serie no existe, verifique por favor. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")
                    Btn_Excel.Enabled = False



                End If


            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub Txt_IdFolioBulto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_IdFolioBulto.LostFocus
        'mreyes 13/Octubre/2016 05:26 p.m.
        Try
            If GLB_Sw_Costos = False Then
                If Mid(Txt_IdFolioBulto.Text, 1, 2) <> GLB_CveSucursal Then
                    MsgBox("No puede imprimir etiquetas de otra sucursal.", MsgBoxStyle.Critical, "Aviso")
                    Txt_IdFolioBulto.Text = ""
                    Txt_IdFolioBulto.Focus()
                End If

            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_IdFolioBulto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_IdFolioBulto.TextChanged

    End Sub

    Private Sub Txt_Serie2_TextChanged(sender As Object, e As EventArgs) Handles Txt_Serie2.TextChanged

    End Sub

    Private Sub Txt_IdFolioBulto_MouseWheel(sender As Object, e As MouseEventArgs) Handles Txt_IdFolioBulto.MouseWheel

    End Sub
End Class