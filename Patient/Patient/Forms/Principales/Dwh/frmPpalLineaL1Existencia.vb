Imports System.Web.UI.WebControls
Imports DevExpress.Utils
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid
Imports DevExpress.XtraEditors.Repository


Imports System.Windows.Forms
Imports System.Drawing.Printing
Imports DevExpress.XtraPrinting
Imports DevExpress.LookAndFeel


Public Class frmPpalControlAparador
    Dim MarcaFOTO As String = ""
    Dim EstiloNFOTO As String = ""
    Dim footer_existencia, footer_traspaso, footer_total As GridColumnSummaryItem
    Dim tot_existencia, tot_traspaso, tot_total As String

    Dim objDataSet As Data.DataSet
    Public DescripSucursal As String = ""
    Public Sucursal As String = ""
    Public Division As String = ""
    Private FechIniB As String = "1900-01-01"
    Private FechFinB As String = "1900-01-01"
    Public Depto As String = ""
    Public Familia As String = ""
    Public Linea As String = ""
    Public L1 As String = ""
    Public L2 As String = ""
    Public L3 As String = ""
    Public L4 As String = ""
    Public L5 As String = ""
    Public L6 As String = ""
    Public Marca As String = ""
    Public Modelo As String = ""
    Public ExiIni As Integer = 0
    Public ExiFin As Integer = 0

    Dim n As Integer

    Private izquierda As Integer = 0
    Private alto As Integer = 0

    Private Sub calcula_totales_cartera()
        n = 0

        Try
            For Each row As DataRow In objDataSet.Tables(0).Rows
                If n >= 1 Then

                    tot_existencia = CDbl(tot_existencia) + row("existencia")
                    tot_traspaso = CDbl(tot_traspaso) + row("traspaso")
                    tot_total = CDbl(tot_traspaso) + row("total")
                End If

                objDataSet.AcceptChanges()
                n = n + 1
            Next
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub
    Private Sub frmPpalLineaL1Existencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Call RellenaGrid()
        Try
            Sucursal = GLB_CveSucursal

            FechIniB = Format(Now.Add(New TimeSpan(-1, 0, 0, 0)), "yyyy-MM-dd")
            FechFinB = Format(Now.Add(New TimeSpan(-1, 0, 0, 0)), "yyyy-MM-dd")


            If Sucursal <= "11" Then
                Call RellenaGrid()
            End If


        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub

    Private Sub totales_columnas(gridview As Views.Grid.GridView)
        Try
            footer_existencia = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "existencia", "" + Format(CDbl(tot_existencia), "##,##0"))
            footer_traspaso = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "traspaso", "" + Format(CDbl(tot_traspaso), "##,##0"))
            footer_total = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total", "" + Format(CDbl(tot_total), "##,##0"))



            gridview.Columns("existencia").Summary.Add(footer_existencia)
            gridview.Columns("traspaso").Summary.Add(footer_traspaso)
            gridview.Columns("total").Summary.Add(footer_total)
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub
    Sub InicializaGrid()
        Try
            'mreyes 19/Febrero/2019 11:07 a.m.

            'view.GetRowCellValue(e.RowHandle1, e.Column)
            ' GridView1.Columns(I).OptionsColumn.AllowMerge = True
            'GridView1.GetRowCellValue(1, 0) '



            GridView1.Columns(0).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns(1).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

            GridView1.Columns(1).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns(1).AppearanceHeader.Font = New Font(GridView1.Columns(1).AppearanceCell.Font, FontStyle.Bold)

            GridView1.Columns(2).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns(2).AppearanceHeader.Font = New Font(GridView1.Columns(2).AppearanceCell.Font, FontStyle.Bold)

            GridView1.Columns(3).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns(3).AppearanceHeader.Font = New Font(GridView1.Columns(3).AppearanceCell.Font, FontStyle.Bold)

            GridView1.Columns(4).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns(4).AppearanceHeader.Font = New Font(GridView1.Columns(4).AppearanceCell.Font, FontStyle.Bold)

            GridView1.Columns(5).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns(5).AppearanceHeader.Font = New Font(GridView1.Columns(5).AppearanceCell.Font, FontStyle.Bold)

            GridView1.Columns(6).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns(6).AppearanceHeader.Font = New Font(GridView1.Columns(6).AppearanceCell.Font, FontStyle.Bold)

            GridView1.Columns(7).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns(7).AppearanceHeader.Font = New Font(GridView1.Columns(7).AppearanceCell.Font, FontStyle.Bold)

            GridView1.Columns(8).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns(8).AppearanceHeader.Font = New Font(GridView1.Columns(8).AppearanceCell.Font, FontStyle.Bold)

            GridView1.Columns(9).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns(9).AppearanceHeader.Font = New Font(GridView1.Columns(9).AppearanceCell.Font, FontStyle.Bold)

            GridView1.Columns(10).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns(10).AppearanceHeader.Font = New Font(GridView1.Columns(10).AppearanceCell.Font, FontStyle.Bold)

            GridView1.Columns(11).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns(11).AppearanceHeader.Font = New Font(GridView1.Columns(11).AppearanceCell.Font, FontStyle.Bold)

            GridView1.Columns(12).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns(12).AppearanceHeader.Font = New Font(GridView1.Columns(12).AppearanceCell.Font, FontStyle.Bold)

            GridView1.Columns(13).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns(13).AppearanceHeader.Font = New Font(GridView1.Columns(13).AppearanceCell.Font, FontStyle.Bold)


            GridView1.Columns(14).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns(14).AppearanceHeader.Font = New Font(GridView1.Columns(14).AppearanceCell.Font, FontStyle.Bold)

            GridView1.Columns(15).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns(15).AppearanceHeader.Font = New Font(GridView1.Columns(15).AppearanceCell.Font, FontStyle.Bold)

            '  GridView1.Columns(0).Visible = False
            GridView1.Columns(0).Caption = "División"
            GridView1.Columns(1).Caption = "Línea"
            GridView1.Columns(2).Caption = "L1"
            GridView1.Columns(3).Caption = "Marca"
            GridView1.Columns(4).Caption = "Modelo"
            GridView1.Columns(5).Caption = "Med Ini"
            GridView1.Columns(6).Caption = "Med Fin"
            GridView1.Columns(7).Caption = "Existencia"
            GridView1.Columns(8).Caption = "Traspaso"
            GridView1.Columns(9).Caption = "Total Exi"
            GridView1.Columns(10).Caption = "Precio Lleno"
            GridView1.Columns(11).Caption = "Precio Oferta"
            GridView1.Columns(12).Caption = "% Directo"
            GridView1.Columns(13).Caption = "% Dinero"
            GridView1.Columns(14).Caption = "Tipo Perciero"
            GridView1.Columns(15).Caption = "Revisado"


            GridView1.Columns(11).AppearanceCell.Font = New Font("Tahoma", 8, FontStyle.Bold)
            GridView1.Columns(11).AppearanceCell.ForeColor = Color.Red

            GridView1.Columns(12).AppearanceCell.Font = New Font("Tahoma", 8, FontStyle.Bold)
            GridView1.Columns(12).AppearanceCell.ForeColor = Color.Red


            GridView1.Columns(13).AppearanceCell.Font = New Font("Tahoma", 8, FontStyle.Bold)
            GridView1.Columns(13).AppearanceCell.ForeColor = Color.Red



            'Dim edit As RepositoryItemCheckEdit = New RepositoryItemCheckEdit()
            'Dim trueValue As Int64 = 1
            'Dim falseValue As Int64 = 0
            'edit.ValueChecked = trueValue
            'edit.ValueUnchecked = falseValue
            'Me.GridView1.Columns("TickMark").ColumnEdit = edit
            '' Me.gridMain.RepositoryItems.Add(edit)

            GridView1.Columns(0).Visible = False
            GridView1.Columns(7).Visible = False
            GridView1.Columns(8).Visible = False
            GridView1.Columns(9).Visible = False


            GridView1.Columns(3).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns(5).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns(6).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns(7).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns(8).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns(9).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

            GridView1.Columns(15).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center



            'For I As Integer = 0 To GridView1.Columns.Count - 1
            '    GridView1.Columns(I).OptionsColumn.ReadOnly = True
            '    ' GridView1.Columns(I).OptionsColumn.AllowMerge = True
            'Next


            For I As Integer = 10 To 13

                GridView1.Columns(I).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                GridView1.Columns(I).DisplayFormat.FormatString = "#,###,##0.00"
                GridView1.Columns(I).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                GridView1.Columns(I).AppearanceHeader.Font = New Font(GridView1.Columns(I).AppearanceCell.Font, FontStyle.Bold)
            Next



            'GridView1.Columns(7).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            'GridView1.Columns(7).DisplayFormat.FormatString = "##"
            'GridView1.Columns(7).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            'GridView1.Columns(7).AppearanceHeader.Font = New Font(GridView1.Columns(4).AppearanceCell.Font, FontStyle.Bold)



            'GridView1.Columns(8).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            'GridView1.Columns(8).DisplayFormat.FormatString = "##"
            'GridView1.Columns(8).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            'GridView1.Columns(8).AppearanceHeader.Font = New Font(GridView1.Columns(4).AppearanceCell.Font, FontStyle.Bold)


            'GridView1.Columns(9).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            'GridView1.Columns(9).DisplayFormat.FormatString = "##"
            'GridView1.Columns(9).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            'GridView1.Columns(9).AppearanceHeader.Font = New Font(GridView1.Columns(4).AppearanceCell.Font, FontStyle.Bold)

            ' Call Colorear()
            GridView1.FixedLineWidth = 4
            GridView1.Columns(0).Fixed = 0
            GridView1.Columns(1).Fixed = 1
            GridView1.Columns(2).Fixed = 1

            GridView1.BestFitColumns()

            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("VS2010")
            GridView1.OptionsView.ColumnAutoWidth = False
            GridView1.OptionsView.BestFitMaxRowCount = -1
            GridView1.BestFitColumns()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Sub InicializaGrid2()
        Try
            'mreyes 19/Febrero/2019 11:07 a.m.

            'view.GetRowCellValue(e.RowHandle1, e.Column)
            ' GridView2.Columns(I).OptionsColumn.AllowMerge = True
            'GridView2.GetRowCellValue(1, 0) '



            GridView2.Columns(0).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView2.Columns(1).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

            GridView2.Columns(1).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView2.Columns(1).AppearanceHeader.Font = New Font(GridView2.Columns(1).AppearanceCell.Font, FontStyle.Bold)

            GridView2.Columns(2).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView2.Columns(2).AppearanceHeader.Font = New Font(GridView2.Columns(2).AppearanceCell.Font, FontStyle.Bold)

            GridView2.Columns(3).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView2.Columns(3).AppearanceHeader.Font = New Font(GridView2.Columns(3).AppearanceCell.Font, FontStyle.Bold)

            GridView2.Columns(4).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView2.Columns(4).AppearanceHeader.Font = New Font(GridView2.Columns(4).AppearanceCell.Font, FontStyle.Bold)

            GridView2.Columns(5).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView2.Columns(5).AppearanceHeader.Font = New Font(GridView2.Columns(5).AppearanceCell.Font, FontStyle.Bold)

            GridView2.Columns(6).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView2.Columns(6).AppearanceHeader.Font = New Font(GridView2.Columns(6).AppearanceCell.Font, FontStyle.Bold)

            GridView2.Columns(7).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView2.Columns(7).AppearanceHeader.Font = New Font(GridView2.Columns(7).AppearanceCell.Font, FontStyle.Bold)

            GridView2.Columns(8).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView2.Columns(8).AppearanceHeader.Font = New Font(GridView2.Columns(8).AppearanceCell.Font, FontStyle.Bold)

            GridView2.Columns(9).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView2.Columns(9).AppearanceHeader.Font = New Font(GridView2.Columns(9).AppearanceCell.Font, FontStyle.Bold)


            GridView2.Columns(0).Visible = False
            GridView2.Columns(0).Caption = "Posición"
            GridView2.Columns(1).Caption = "Depto"
            GridView2.Columns(2).Caption = "Línea"
            GridView2.Columns(3).Caption = "L1"
            GridView2.Columns(4).Caption = "Marca"
            GridView2.Columns(5).Caption = "Modelo"
            GridView2.Columns(6).Caption = "Med Ini"
            GridView2.Columns(7).Caption = "Med Fin"
            GridView2.Columns(8).Caption = "Etiqueta"
            GridView2.Columns(9).Caption = "Revisado"


            GridView2.Columns(8).AppearanceCell.Font = New Font("Tahoma", 8, FontStyle.Bold)
            GridView2.Columns(8).AppearanceCell.ForeColor = Color.Green






            GridView2.Columns(5).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView2.Columns(6).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView2.Columns(7).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

            GridView2.Columns(8).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

            GridView2.Columns(9).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center


            GridView2.OptionsView.ColumnAutoWidth = False
            GridView2.OptionsView.BestFitMaxRowCount = -1
            GridView2.BestFitColumns()



            GridView2.FixedLineWidth = 4
            GridView2.Columns(0).Fixed = 0
            GridView2.Columns(1).Fixed = 1
            GridView2.Columns(2).Fixed = 1

            GridView2.BestFitColumns()

            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("VS2010")



            GridView2.OptionsView.ColumnAutoWidth = False
            GridView2.OptionsView.BestFitMaxRowCount = -1
            GridView2.BestFitColumns()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Sub InicializaGrid3()
        Try


            GridView3.Columns(0).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView3.Columns(1).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

            GridView3.Columns(1).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView3.Columns(1).AppearanceHeader.Font = New Font(GridView3.Columns(1).AppearanceCell.Font, FontStyle.Bold)

            GridView3.Columns(2).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView3.Columns(2).AppearanceHeader.Font = New Font(GridView3.Columns(2).AppearanceCell.Font, FontStyle.Bold)

            GridView3.Columns(3).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView3.Columns(3).AppearanceHeader.Font = New Font(GridView3.Columns(3).AppearanceCell.Font, FontStyle.Bold)

            GridView3.Columns(4).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView3.Columns(4).AppearanceHeader.Font = New Font(GridView3.Columns(4).AppearanceCell.Font, FontStyle.Bold)

            GridView3.Columns(5).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView3.Columns(5).AppearanceHeader.Font = New Font(GridView3.Columns(5).AppearanceCell.Font, FontStyle.Bold)

            GridView3.Columns(6).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView3.Columns(6).AppearanceHeader.Font = New Font(GridView3.Columns(6).AppearanceCell.Font, FontStyle.Bold)

            GridView3.Columns(7).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView3.Columns(7).AppearanceHeader.Font = New Font(GridView3.Columns(7).AppearanceCell.Font, FontStyle.Bold)

            GridView3.Columns(8).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView3.Columns(8).AppearanceHeader.Font = New Font(GridView3.Columns(8).AppearanceCell.Font, FontStyle.Bold)


            GridView3.Columns(0).Visible = False
            GridView3.Columns(0).Caption = "Posición"
            GridView3.Columns(1).Caption = "Depto"
            GridView3.Columns(2).Caption = "Línea"
            GridView3.Columns(3).Caption = "L1"
            GridView3.Columns(4).Caption = "Marca"
            GridView3.Columns(5).Caption = "Modelo"
            GridView3.Columns(6).Caption = "Colocar"
            GridView3.Columns(7).Caption = "Retirar"
            GridView3.Columns(8).Caption = "Revisado"



            GridView3.Columns(4).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView3.Columns(5).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView3.Columns(6).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView3.Columns(7).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center


            GridView3.OptionsView.ColumnAutoWidth = False
            GridView3.OptionsView.BestFitMaxRowCount = -1
            GridView3.BestFitColumns()



            GridView3.FixedLineWidth = 4
            GridView3.Columns(0).Fixed = 0
            GridView3.Columns(1).Fixed = 1
            GridView3.Columns(2).Fixed = 1

            GridView3.BestFitColumns()

            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("VS2010")

            ' GridView1.Columns(6).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            ' GridView1.Columns(6).DisplayFormat.FormatString = "#,###,###"

            GridView3.Columns(6).AppearanceCell.Font = New Font("Tahoma", 8, FontStyle.Bold)
            GridView3.Columns(6).AppearanceCell.ForeColor = Color.HotPink


            GridView3.Columns(7).AppearanceCell.Font = New Font("Tahoma", 8, FontStyle.Bold)
            GridView3.Columns(7).AppearanceCell.ForeColor = Color.Red

            GridView3.OptionsView.ColumnAutoWidth = False
            GridView3.OptionsView.BestFitMaxRowCount = -1
            GridView3.BestFitColumns()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub LimpiarBusqueda()

    End Sub



    Private Sub PBox_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PBox.MouseDown
        Try
            If e.Button = Windows.Forms.MouseButtons.Left Then
                izquierda = e.X
                alto = e.Y
                PBox.Cursor = Cursors.SizeAll
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub PBox_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PBox.MouseMove
        Try
            If e.Button = Windows.Forms.MouseButtons.Left Then
                PBox.Location = New Point(PBox.Left + e.X - izquierda, PBox.Top + e.Y - alto)
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub PBox_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PBox.MouseUp
        Try
            PBox.Cursor = Cursors.Default
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub CargarFotoArticulo(ByVal Marca, ByVal Estilon)
        'mreyes 14/Marzo/2012 07:06 p.m.
        'Glb_RutaArchivoFotos
        Try
            Dim Archivo As String = ""
            Dim NoFoto As String = "1"

            MarcaFOTO = Marca
            EstiloNFOTO = Estilon
            PBox.Visible = False
            Using objIO As New BCL.BCLio(GLB_ConStringCipSis)

                Archivo = objIO.pub_ArmarNombreFotoEstilo(If(GLB_CveSucursal <> "", GLB_RutaArchivoFotosLocal, GLB_RutaArchivoFotos), Marca, Estilon, NoFoto)

                If objIO.pub_ExisteArchivo(Archivo) = True Then
                    PBox.Image = New System.Drawing.Bitmap(Archivo)
                    PBox.Visible = True
                    Exit Sub


                End If

                For i As Integer = 1 To 9
                    Archivo = objIO.pub_ArmarNombreFotoEstilo(If(GLB_CveSucursal <> "", GLB_RutaArchivoFotosLocal, GLB_RutaArchivoFotos), Marca, Estilon, i)
                    If objIO.pub_ExisteArchivo(Archivo) = True Then
                        PBox.Image = New System.Drawing.Bitmap(Archivo)
                        PBox.Visible = True
                        Exit Sub

                    Else
                        Archivo = objIO.pub_ArmarNombreFotoEstilo(GLB_RutaArchivoFotos, Marca, Estilon, i)
                        If objIO.pub_ExisteArchivo(Archivo) = True Then
                            PBox.Image = New System.Drawing.Bitmap(Archivo)
                            PBox.Visible = True
                            Exit Sub
                        End If

                    End If
                Next

            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub RellenaGrid()
        'mreyes 19/Febrero/2019 10:43 a.m.
        tot_existencia = "0"
        tot_traspaso = "0"
        tot_total = "0"

        Using objFalt As New BCL.BCLTraspasosAutomaticos(GLB_ConStringDwhSQL)

            Try
                'Me.Cursor = Cursors.WaitCursor
                Me.Cursor = Cursors.WaitCursor

                DGrid1.DataSource = Nothing
                objDataSet = objFalt.usp_PpalLineaL1Existencia(Sucursal, Division, Linea, L1, L2, L3, L4, L5, L6, Marca, Modelo, ExiIni, ExiFin, FechIniB, FechFinB)
                If objDataSet.Tables(0).Rows.Count > 0 Or objDataSet.Tables(1).Rows.Count > 0 Or objDataSet.Tables(2).Rows.Count > 0 Then
                    DGrid1.DataSource = Nothing
                    GridView1.Columns.Clear()
                    calcula_totales_cartera()
                    DGrid1.DataSource = objDataSet.Tables(0)
                    InicializaGrid()
                    '  totales_columnas(GridView1)

                    DGrid2.DataSource = objDataSet.Tables(1)
                    InicializaGrid2()
                    DGrid3.DataSource = objDataSet.Tables(2)
                    InicializaGrid3()

                    Me.Cursor = Cursors.Default
                    Btn_Excel.Enabled = True

                Else
                    Me.Cursor = Cursors.Default
                    MsgBox("No se encontraron registros que cumplan con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")
                    Btn_Excel.Enabled = False
                End If
                Me.Cursor = Cursors.Default
                Call LimpiarBusqueda()

                Lbl_Leyenda.Text = Sucursal & "\" & DescripSucursal & "\" & FechIniB & "\" & FechFinB & "\" & Division & "\" & Depto & "\" & Familia & "\" & Linea & "\" & L1 & "\" & L2 & "\" & L3 & "\" & L4 & "\" & L5 & "\" & L6
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub Btn_Filtro_Click(sender As Object, e As EventArgs) Handles Btn_Filtro.Click
        Try
            Dim objDataSet As Data.DataSet
            Dim myFormFiltros As New frmFiltrosEstrYExistActual
            myFormFiltros.StartPosition = FormStartPosition.CenterParent
            myFormFiltros.Sw_Filtro = False
            myFormFiltros.CB_Sucursal.Visible = True
            myFormFiltros.Label4.Visible = True
            myFormFiltros.DT_RecFin.Visible = True
            myFormFiltros.DT_RecIni.Visible = True
            myFormFiltros.Chk_UltRecibo.Visible = True
            'myFormFiltros.CB_Sucursal.Visible = False
            myFormFiltros.Suc = Sucursal
            'myFormFiltros.Label4.Visible = False

            'If Accion = 1 Then
            '    myFormFiltros.Text = "Filtros Antigüedad Inventario"
            'ElseIf Accion = 2 Then
            '    myFormFiltros.Text = "Filtros Inventario Costo/Venta"
            '    If GLB_CveSucursal > "0" And GLB_CveSucursal < "90" Then
            '        myFormFiltros.CB_Sucursal.SelectedValue = GLB_CveSucursal
            '        myFormFiltros.CB_Sucursal.Enabled = False
            '    End If
            'End If


            If FechFinB <> "1900-01-01" Then
                myFormFiltros.Chk_UltRecibo.Checked = True
                myFormFiltros.DT_RecIni.Value = FechIniB
                myFormFiltros.DT_RecFin.Value = FechFinB
            End If


            If Division <> "" Then
                If Division = "CALZADO" Then
                    myFormFiltros.Txt_Division.Text = "001"
                ElseIf Division = "ACCESORIOS" Then
                    myFormFiltros.Txt_Division.Text = "002"
                ElseIf Division = "ELECTRONICA" Then
                    myFormFiltros.Txt_Division.Text = "003"
                ElseIf Division = "GENERAL" Then
                    myFormFiltros.Txt_Division.Text = "999"
                End If
                myFormFiltros.Txt_DescripDivision.Text = Division
            Else
                myFormFiltros.Txt_DescripDivision.Text = ""
                myFormFiltros.Txt_Division.Text = ""
            End If
            If Depto <> "" Then
                myFormFiltros.Txt_IdDepto.Text = Depto
                Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                    objDataSet = objCatalogoDeptos.usp_TraerEstDepto(0, 0, "", 0, Depto)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    myFormFiltros.Txt_DescripDepto.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                    myFormFiltros.Txt_Depto.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                End If
            End If
            If Familia <> "" Then
                Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                    objDataSet = objCatalogoDeptos.usp_TraerEstFamilia(0, 0, 0, "", 3, Familia)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    myFormFiltros.Txt_Familia.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    myFormFiltros.Txt_DescripFamilia.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                End If
            End If
            If Linea <> "" Then
                Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                    objDataSet = objCatalogoDeptos.usp_TraerEstLinea(0, 0, 0, 0, "", 3, Linea)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    myFormFiltros.Txt_Linea.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    myFormFiltros.Txt_DescripLinea.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                End If
            End If
            If L1 <> "" Then
                Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                    objDataSet = objCatalogoDeptos.usp_TraerEstl1(0, 0, 0, 0, 0, "", 3, L1)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    myFormFiltros.Txt_L1.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    myFormFiltros.Txt_DescripL1.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                End If
            End If
            If L2 <> "" Then
                Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                    objDataSet = objCatalogoDeptos.usp_TraerEstl2(0, 0, 0, 0, 0, 0, "", 3, L2)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    myFormFiltros.Txt_L2.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    myFormFiltros.Txt_DescripL2.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                End If
            End If
            If L3 <> "" Then
                Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                    objDataSet = objCatalogoDeptos.usp_TraerEstl3(0, 0, 0, 0, 0, 0, 0, "", 3, L3)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    myFormFiltros.Txt_L3.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    myFormFiltros.Txt_DescripL3.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                End If
            End If
            If L4 <> "" Then
                Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                    objDataSet = objCatalogoDeptos.usp_TraerEstl4(0, 0, 0, 0, 0, 0, 0, 0, "", 3, L4)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    myFormFiltros.Txt_L4.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    myFormFiltros.Txt_DescripL4.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                End If
            End If
            If L5 <> "" Then
                Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                    objDataSet = objCatalogoDeptos.usp_TraerEstl5(0, 0, 0, 0, 0, 0, 0, 0, 0, "", 3, L5)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    myFormFiltros.Txt_L5.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    myFormFiltros.Txt_DescripL5.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                End If
            End If
            If L6 <> "" Then
                Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                    objDataSet = objCatalogoDeptos.usp_TraerEstl6(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", 3, L6)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    myFormFiltros.Txt_L6.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    myFormFiltros.Txt_DescripL6.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                End If
            End If
            If Marca <> "" Then
                myFormFiltros.Txt_Marca.Text = Marca
            End If
            myFormFiltros.ShowDialog()
            If myFormFiltros.Sw_Filtro = True Then
                DGrid1.DataSource = Nothing
                DGrid1.Refresh()


                If CInt(myFormFiltros.CB_Sucursal.SelectedValue.ToString) = 0 Then
                    Sucursal = ""
                Else
                    Sucursal = pub_RellenarIzquierda(myFormFiltros.CB_Sucursal.SelectedValue.ToString, 2)
                    DescripSucursal = myFormFiltros.CB_Sucursal.Text
                End If

                ' fecha ultimo recibo
                If myFormFiltros.Chk_UltRecibo.Checked = True Then
                        ' Format(Now.Date, "yyyy-MM-dd")

                        FechIniB = Format(myFormFiltros.DT_RecIni.Value, "yyyy-MM-dd")
                        FechFinB = Format(myFormFiltros.DT_RecFin.Value, "yyyy-MM-dd")
                    Else
                        FechIniB = "1900-01-01"
                        FechFinB = "1900-01-01"
                    End If
                    Marca = myFormFiltros.Txt_Marca.Text
                    If Marca.Trim <> "" Then
                        lbl_Marca.Text = Marca
                    End If

                    If myFormFiltros.Txt_DescripDivision.Text.Trim = "" Then
                        Division = ""
                    Else
                        Division = myFormFiltros.Txt_DescripDivision.Text
                    End If
                    If myFormFiltros.Txt_DescripDepto.Text.Trim = "" Then
                        Depto = ""
                    Else
                        Depto = myFormFiltros.Txt_DescripDepto.Text
                    End If
                    If myFormFiltros.Txt_DescripFamilia.Text = "" Then
                        Familia = ""
                    Else
                        Familia = myFormFiltros.Txt_DescripFamilia.Text
                    End If
                    If myFormFiltros.Txt_DescripLinea.Text = "" Then
                        Linea = ""
                    Else
                        Linea = myFormFiltros.Txt_DescripLinea.Text
                    End If
                    If myFormFiltros.Txt_DescripL1.Text = "" Then
                        L1 = ""
                    Else
                        L1 = myFormFiltros.Txt_DescripL1.Text
                    End If
                    If myFormFiltros.Txt_DescripL2.Text = "" Then
                        L2 = ""
                    Else
                        L2 = myFormFiltros.Txt_DescripL2.Text
                    End If
                    If myFormFiltros.Txt_DescripL3.Text = "" Then
                        L3 = ""
                    Else
                        L3 = myFormFiltros.Txt_DescripL3.Text
                    End If
                    If myFormFiltros.Txt_DescripL4.Text = "" Then
                        L4 = ""
                    Else
                        L4 = myFormFiltros.Txt_DescripL4.Text
                    End If
                    If myFormFiltros.Txt_DescripL5.Text = "" Then
                        L5 = ""
                    Else
                        L5 = myFormFiltros.Txt_DescripL5.Text
                    End If
                    If myFormFiltros.Txt_DescripL6.Text = "" Then
                        L6 = ""
                    Else
                        L6 = myFormFiltros.Txt_DescripL6.Text
                    End If



                Lbl_Leyenda.Text = Sucursal & "\" & DescripSucursal & "\" & FechIniB & "\" & FechFinB & "\" & Division & "\" & Depto & "\" & Familia & "\" & Linea & "\" & L1 & "\" & L2 & "\" & L3 & "\" & L4 & "\" & L5 & "\" & L6

                Call RellenaGrid()
                End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid1_Click(sender As Object, e As EventArgs) Handles DGrid1.Click
        Try


            Dim Renglon As Point = DGrid1.PointToClient(Control.MousePosition)
            Dim info As GridHitInfo = GridView1.CalcHitInfo(Renglon)
            Dim Marca As String = ""
            Dim Modelo As String = ""
            Dim Renglon1 As Integer = info.RowHandle


            Marca = Mid(GridView1.GetRowCellValue(Renglon1, "marca"), 1, 3)
            Modelo = GridView1.GetRowCellValue(Renglon1, "modelo")

            CargarFotoArticulo(Marca, Modelo)

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Excel_Click(sender As Object, e As EventArgs) Handles Btn_Excel.Click
        Try
            Dim printingSystem1 As New PrintingSystem()
            Dim printableComponentLink1 As New PrintableComponentLink()

            printingSystem1.PageSettings.Margins.Top = 0.5
            printingSystem1.PageSettings.Margins.Bottom = 0.5
            printingSystem1.PageSettings.Margins.Left = 0.5
            printingSystem1.PageSettings.Margins.Right = 0.5
            printingSystem1.Links.AddRange(New Object() {printableComponentLink1})
            printableComponentLink1.Component = DGrid1
            printableComponentLink1.Margins = New Margins(0.5, 0.5, 0.5, 0.5)
            'printableComponentLink1.Landscape = True


            printableComponentLink1.CreateDocument()
            printableComponentLink1.ShowPreviewDialog()




            Dim printingSystem12 As New PrintingSystem()
            Dim printableComponentLink12 As New PrintableComponentLink()

            printingSystem12.PageSettings.Margins.Top = 0.5
            printingSystem12.PageSettings.Margins.Bottom = 0.5
            printingSystem12.PageSettings.Margins.Left = 0.5
            printingSystem12.PageSettings.Margins.Right = 0.5
            printingSystem12.Links.AddRange(New Object() {printableComponentLink12})
            printableComponentLink12.Component = DGrid2
            printableComponentLink12.Margins = New Margins(0.5, 0.5, 0.5, 0.5)
            'printableComponentLink1.Landscape = True


            printableComponentLink12.CreateDocument()
            printableComponentLink12.ShowPreviewDialog()



            Dim printingSystem13 As New PrintingSystem()
            Dim printableComponentLink13 As New PrintableComponentLink()

            printingSystem13.PageSettings.Margins.Top = 0.5
            printingSystem13.PageSettings.Margins.Bottom = 0.5
            printingSystem13.PageSettings.Margins.Left = 0.5
            printingSystem13.PageSettings.Margins.Right = 0.5
            printingSystem13.Links.AddRange(New Object() {printableComponentLink13})
            printableComponentLink13.Component = DGrid3
            printableComponentLink13.Margins = New Margins(0.5, 0.5, 0.5, 0.5)
            'printableComponentLink1.Landscape = True


            printableComponentLink13.CreateDocument()
            printableComponentLink13.ShowPreviewDialog()


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub PBox_Click(sender As Object, e As EventArgs) Handles PBox.Click

    End Sub

    Private Sub DGrid2_Click(sender As Object, e As EventArgs) Handles DGrid2.Click
        Try


            Dim Renglon As Point = DGrid2.PointToClient(Control.MousePosition)
            Dim info As GridHitInfo = GridView2.CalcHitInfo(Renglon)
            Dim Marca As String = ""
            Dim Modelo As String = ""
            Dim Renglon1 As Integer = info.RowHandle


            Marca = Mid(GridView2.GetRowCellValue(Renglon1, "marca"), 1, 3)
            Modelo = GridView2.GetRowCellValue(Renglon1, "modelo")

            CargarFotoArticulo(Marca, Modelo)

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid3_Click(sender As Object, e As EventArgs) Handles DGrid3.Click
        Try


            Dim Renglon As Point = DGrid3.PointToClient(Control.MousePosition)
            Dim info As GridHitInfo = GridView3.CalcHitInfo(Renglon)
            Dim Marca As String = ""
            Dim Modelo As String = ""
            Dim Renglon1 As Integer = info.RowHandle


            Marca = Mid(GridView3.GetRowCellValue(Renglon1, "marca"), 1, 3)
            Modelo = GridView3.GetRowCellValue(Renglon1, "modelo")

            CargarFotoArticulo(Marca, Modelo)

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Pnl_Botones_Paint(sender As Object, e As PaintEventArgs) Handles Pnl_Botones.Paint

    End Sub

    Private Sub DGrid1_KeyUp(sender As Object, e As KeyEventArgs) Handles DGrid1.KeyUp
        Try


            Dim Renglon As Point = DGrid1.PointToClient(Control.MousePosition)
            Dim info As GridHitInfo = GridView1.CalcHitInfo(Renglon)
            Dim Marca As String = ""
            Dim Modelo As String = ""
            Dim Renglon1 As Integer = info.RowHandle


            Marca = Mid(GridView1.GetRowCellValue(Renglon1, "marca"), 1, 3)
            Modelo = GridView1.GetRowCellValue(Renglon1, "modelo")

            CargarFotoArticulo(Marca, Modelo)

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid1_KeyDown(sender As Object, e As KeyEventArgs) Handles DGrid1.KeyDown
        Try


            Dim Renglon As Point = DGrid1.PointToClient(Control.MousePosition)
            Dim info As GridHitInfo = GridView1.CalcHitInfo(Renglon)
            Dim Marca As String = ""
            Dim Modelo As String = ""
            Dim Renglon1 As Integer = info.RowHandle


            Marca = Mid(GridView1.GetRowCellValue(Renglon1, "marca"), 1, 3)
            Modelo = GridView1.GetRowCellValue(Renglon1, "modelo")

            CargarFotoArticulo(Marca, Modelo)

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid1_KeyboardFocusViewChanged(sender As Object, e As ViewFocusEventArgs) Handles DGrid1.KeyboardFocusViewChanged
        Try


            Dim Renglon As Point = DGrid1.PointToClient(Control.MousePosition)
            Dim info As GridHitInfo = GridView1.CalcHitInfo(Renglon)
            Dim Marca As String = ""
            Dim Modelo As String = ""
            Dim Renglon1 As Integer = info.RowHandle


            Marca = Mid(GridView1.GetRowCellValue(Renglon1, "marca"), 1, 3)
            Modelo = GridView1.GetRowCellValue(Renglon1, "modelo")

            CargarFotoArticulo(Marca, Modelo)

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Salir_Click(sender As Object, e As EventArgs) Handles Btn_Salir.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub DGrid2_KeyUp(sender As Object, e As KeyEventArgs) Handles DGrid2.KeyUp

        Try


            Dim Renglon As Point = DGrid2.PointToClient(Control.MousePosition)
            Dim info As GridHitInfo = GridView2.CalcHitInfo(Renglon)
            Dim Marca As String = ""
            Dim Modelo As String = ""
            Dim Renglon1 As Integer = info.RowHandle


            Marca = Mid(GridView2.GetRowCellValue(Renglon1, "marca"), 1, 3)
            Modelo = GridView2.GetRowCellValue(Renglon1, "modelo")

            CargarFotoArticulo(Marca, Modelo)

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid2_KeyDown(sender As Object, e As KeyEventArgs) Handles DGrid2.KeyDown
        Try
            Dim Renglon As Point = DGrid2.PointToClient(Control.MousePosition)
            Dim info As GridHitInfo = GridView2.CalcHitInfo(Renglon)
            Dim Marca As String = ""
            Dim Modelo As String = ""
            Dim Renglon1 As Integer = info.RowHandle


            Marca = Mid(GridView2.GetRowCellValue(Renglon1, "marca"), 1, 3)
            Modelo = GridView1.GetRowCellValue(Renglon1, "modelo")

            CargarFotoArticulo(Marca, Modelo)

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid2_KeyboardFocusViewChanged(sender As Object, e As ViewFocusEventArgs) Handles DGrid2.KeyboardFocusViewChanged

        Dim Renglon As Point = DGrid2.PointToClient(Control.MousePosition)
        Dim info As GridHitInfo = GridView2.CalcHitInfo(Renglon)
        Dim Marca As String = ""
        Dim Modelo As String = ""
        Dim Renglon1 As Integer = info.RowHandle


        Marca = Mid(GridView2.GetRowCellValue(Renglon1, "marca"), 1, 3)
        Modelo = GridView2.GetRowCellValue(Renglon1, "modelo")

        CargarFotoArticulo(Marca, Modelo)

    End Sub

    Private Sub DGrid3_FocusedViewChanged(sender As Object, e As ViewFocusEventArgs) Handles DGrid3.FocusedViewChanged
        Try


            Dim Renglon As Point = DGrid3.PointToClient(Control.MousePosition)
            Dim info As GridHitInfo = GridView3.CalcHitInfo(Renglon)
            Dim Marca As String = ""
            Dim Modelo As String = ""
            Dim Renglon1 As Integer = info.RowHandle


            Marca = Mid(GridView3.GetRowCellValue(Renglon1, "marca"), 1, 3)
            Modelo = GridView3.GetRowCellValue(Renglon1, "modelo")

            CargarFotoArticulo(Marca, Modelo)

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid3_KeyDown(sender As Object, e As KeyEventArgs) Handles DGrid3.KeyDown
        Try


            Dim Renglon As Point = DGrid3.PointToClient(Control.MousePosition)
            Dim info As GridHitInfo = GridView3.CalcHitInfo(Renglon)
            Dim Marca As String = ""
            Dim Modelo As String = ""
            Dim Renglon1 As Integer = info.RowHandle


            Marca = Mid(GridView3.GetRowCellValue(Renglon1, "marca"), 1, 3)
            Modelo = GridView3.GetRowCellValue(Renglon1, "modelo")

            CargarFotoArticulo(Marca, Modelo)

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid3_KeyUp(sender As Object, e As KeyEventArgs) Handles DGrid3.KeyUp
        Try


            Dim Renglon As Point = DGrid3.PointToClient(Control.MousePosition)
            Dim info As GridHitInfo = GridView3.CalcHitInfo(Renglon)
            Dim Marca As String = ""
            Dim Modelo As String = ""
            Dim Renglon1 As Integer = info.RowHandle


            Marca = Mid(GridView3.GetRowCellValue(Renglon1, "marca"), 1, 3)
            Modelo = GridView3.GetRowCellValue(Renglon1, "modelo")

            CargarFotoArticulo(Marca, Modelo)

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
End Class