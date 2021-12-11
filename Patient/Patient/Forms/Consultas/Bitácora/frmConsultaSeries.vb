Imports System.Drawing.Printing
Public Class frmConsultaSeries
    'mreyes 24/Agosto/2013 10:07 a.m.
    Dim Contenido As PrintPageEventArgs
    Dim WithEvents Documento As New PrintDocument
    Dim impresora As New PrintDialog


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
        Contenido = e
        Contenido.Graphics.DrawString(Glb_ModeloEtiqueta, New Font("Arial", 34), Brushes.Black, 40, 0)
        Contenido.Graphics.DrawString(Glb_CorridaEtiqueta, New Font("Wide Latin", 15), Brushes.Black, 250, 20)
        Contenido.Graphics.DrawString(Glb_MedidaEtiqueta, New Font("Arial", 20), Brushes.Black, 190, 15)
        Contenido.Graphics.DrawString("*" & Glb_SerieEtiqueta & "*", New Font("3 of 9 Barcode", 24), Brushes.Black, 2, 50)
        Contenido.Graphics.DrawString(Glb_SerieEtiqueta, New Font("Arial", 8), Brushes.Black, 80, 75)
        Contenido.Graphics.DrawString(Glb_MarcaEtiqueta, New Font("Arial", 20), Brushes.Black, 200, 75)

        Contenido.Graphics.DrawString(Glb_DescripCEtiqueta, New Font("Arial", 8), Brushes.Black, 10, 103)
        ' Contenido.PageSettings.PaperSize

        Contenido.HasMorePages = False

    End Sub

    Private Sub RellenaGrid()
        Dim SqlWhere As String = ""
        Dim Buscar As String = ""

        Using objMySqlGral As New BCL.BCLPedidos(GLB_ConStringCipSis)
            Try


                If Txt_Buscar.Text.Length > 0 Then
                    Buscar = pub_RellenarIzquierda(Txt_Buscar.Text, 13)

                    Tipo = "P"
                End If

                If Tipo = "M" Then
                    objDataSet = objMySqlGral.usp_TraerSeriesConsultaModelos(Sucursal, Marca, Modelo, Buscar)
                ElseIf Tipo = "A" Then
                    objDataSet = objMySqlGral.usp_TraerSeries(Tipo, Sucursal, Folio, IdFolio, Buscar, "", Division, Depto, Familia, Linea, l1, l2, l3, l4, l5, l6)

                ElseIf Tipo = "S" Then
                    objDataSet = objMySqlGral.usp_TraerSeries(Tipo, Sucursal, Folio, IdFolio, Buscar, Buscar, "", "", "", "", "", "", "", "", "", "")
                ElseIf Tipo = "P" Then
                    objDataSet = objMySqlGral.usp_TraerSeries(Tipo, Sucursal, "", 0, Buscar, Buscar, "", "", "", "", "", "", "", "", "", "")
                Else
                    objDataSet = objMySqlGral.usp_TraerSeries(Tipo, Sucursal, Folio, IdFolio, Buscar, "", "", "", "", "", "", "", "", "", "", "")
                End If

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
                    'Close()
                    'Dispose()


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



            Call RellenaGrid()
            Call GenerarToolTip()

            If Tipo = "M" Then
                Me.Text = "Series Activas " + Marca + " - " + Modelo
            ElseIf Tipo = "A" Then
                Me.Text = "Series en Aparador"

            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub
    Private Sub GenerarToolTip()
        Try
            ToolTip.SetToolTip(Btn_Excel, "Exportar a Excel")
            ToolTip.SetToolTip(Txt_Buscar, "Escriba lo que pretende buscar")
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

    Private Sub Txt_Buscar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Buscar.LostFocus

    End Sub

    Private Sub Txt_Buscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Buscar.TextChanged
        'Try
        '    Call RellenaGrid()
        'Catch ExceptionErr As Exception
        '    MessageBox.Show(ExceptionErr.Message.ToString)
        'End Try
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
                Documento.Print()
            End If

        Next

      



       
    End Sub

    Private Sub Btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cancelar.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub DGrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellContentClick

    End Sub

    Private Sub DGrid_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGrid.KeyDown
        Dim Serie As String
        Dim columna As Integer = DGrid.CurrentCell.ColumnIndex
        Dim renglon As Integer = DGrid.CurrentCell.RowIndex
        Try
            If (e.KeyCode = 46) Then

                Serie = DGrid.Rows(renglon).Cells("serie").Value
                If MessageBox.Show("Estas seguro de que la serie '" & serie & "' será retirada del aparador ?", "Confirmar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then


                    If (DGrid.CurrentCell.RowIndex) <> DGrid.Rows.Count - 1 Then
                        DGrid.Rows.RemoveAt(DGrid.CurrentCell.RowIndex)
                        'End If

                        ' ELIMINAR DEL APARADOR.
                        '

                        Using objDetBulto As New BCL.BCLBulto(GLB_ConStringCipSis)

                            objDataSet = objDetBulto.usp_EliminarAparadorLeer(Serie)

                            MsgBox("La serie '" & Serie & "' ha sido retirada del aparador.", MsgBoxStyle.Information, "Confirmación")

                        End Using
                    End If
                    Call RellenaGrid()

                End If
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Filtro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Filtro.Click
        Call RellenaGrid()
    End Sub
End Class