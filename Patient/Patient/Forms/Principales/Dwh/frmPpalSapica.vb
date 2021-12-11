Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid

Imports System.Windows.Forms
Imports System.Drawing.Printing
Imports DevExpress.XtraPrinting
Imports DevExpress.LookAndFeel


Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Drawing.Drawing2D

Imports System.Drawing.Imaging
Imports LibPrintTicketMatriz.Class1

'mreyes 18/Agosto/2019  11:09 a.m.
Public Class frmPpalSapica
    Private izquierda As Integer = 0
    Private alto As Integer = 0
    Dim MarcaFOTO As String = ""
    Dim EstiloNFOTO As String = ""

    Private objDataSet As Data.DataSet
    Private objDataSet1 As Data.DataSet 'Segundo Nivel
    Dim SucurOriB As Integer = 0
    Dim SucurDesB As Integer = 0
    Dim FechaInib As String
    Dim FechaFinb As String

    Dim Sw_Load As Boolean = True
    Dim Sw_NoRegistros As Boolean = False
    Dim Sw_Pintar As Boolean = False


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
    Private Sub frmPpalPrevioVentaAnual_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '  Call RellenaGrid()
    End Sub
    Sub InicializaGrid()
        Try
            'view.GetRowCellValue(e.RowHandle1, e.Column)
            ' GridView1.Columns(I).OptionsColumn.AllowMerge = True
            'GridView1.GetRowCellValue(1, 0) '




            GridView1.Columns(0).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns(0).AppearanceHeader.Font = New Font(GridView1.Columns(0).AppearanceCell.Font, FontStyle.Bold)

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

            GridView1.Columns(16).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns(16).AppearanceHeader.Font = New Font(GridView1.Columns(16).AppearanceCell.Font, FontStyle.Bold)

            GridView1.Columns(0).Caption = "Línea"
            GridView1.Columns(1).Caption = "L1"
            GridView1.Columns(2).Caption = "Marca"
            GridView1.Columns(3).Caption = "Modelo"
            GridView1.Columns(4).Caption = "Estilof"
            GridView1.Columns(5).Caption = "Corrida"
            GridView1.Columns(6).Caption = "Med Ini"
            GridView1.Columns(7).Caption = "Med Fin"
            GridView1.Columns(8).Caption = "Costo Margen"
            GridView1.Columns(9).Caption = "Precio Lleno"
            GridView1.Columns(10).Caption = "Recibida"
            GridView1.Columns(11).Caption = "Vta. Neta"
            GridView1.Columns(12).Caption = "Vta. Lleno"
            GridView1.Columns(13).Caption = "Vta. Descto"
            GridView1.Columns(14).Caption = "M.I."
            GridView1.Columns(15).Caption = "M.F."
            GridView1.Columns(16).Caption = "Imagen"


            GridView1.Columns(5).Visible = False

            GridView1.Columns(17).Visible = False

            GridView1.Columns(2).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns(4).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns(5).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns(6).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns(7).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

            GridView1.Columns(8).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns(9).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns(10).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns(11).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns(12).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns(13).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns(14).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns(15).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

            GridView1.Columns(5).AppearanceCell.BackColor = Color.Pink
            '   GridView1.Columns(5).AppearanceCell.BackColor2 = Color.White

            GridView1.Columns(0).AppearanceCell.ForeColor = Color.Blue
            GridView1.Columns(0).AppearanceCell.Font = New Font(GridView1.Columns(0).AppearanceCell.Font, FontStyle.Bold)
            GridView1.Columns(1).AppearanceCell.ForeColor = Color.Blue
            GridView1.Columns(1).AppearanceCell.Font = New Font(GridView1.Columns(1).AppearanceCell.Font, FontStyle.Bold)

            GridView1.Columns(2).AppearanceCell.ForeColor = Color.Blue
            GridView1.Columns(2).AppearanceCell.Font = New Font(GridView1.Columns(2).AppearanceCell.Font, FontStyle.Bold)

            GridView1.Columns(3).AppearanceCell.ForeColor = Color.Blue
            GridView1.Columns(3).AppearanceCell.Font = New Font(GridView1.Columns(3).AppearanceCell.Font, FontStyle.Bold)

            GridView1.Columns(4).AppearanceCell.ForeColor = Color.Blue
            GridView1.Columns(4).AppearanceCell.Font = New Font(GridView1.Columns(4).AppearanceCell.Font, FontStyle.Bold)


            GridView1.Columns(12).AppearanceCell.ForeColor = Color.Green
            GridView1.Columns(12).AppearanceCell.Font = New Font(GridView1.Columns(12).AppearanceCell.Font, FontStyle.Bold)


            GridView1.Columns(13).AppearanceCell.ForeColor = Color.Green
            GridView1.Columns(13).AppearanceCell.Font = New Font(GridView1.Columns(13).AppearanceCell.Font, FontStyle.Bold)

            GridView1.Columns(14).AppearanceCell.ForeColor = Color.Red
            GridView1.Columns(14).AppearanceCell.Font = New Font(GridView1.Columns(14).AppearanceCell.Font, FontStyle.Bold)


            GridView1.Columns(15).AppearanceCell.ForeColor = Color.Red
            GridView1.Columns(15).AppearanceCell.Font = New Font(GridView1.Columns(15).AppearanceCell.Font, FontStyle.Bold)
            GridView1.Columns(16).AppearanceCell.ForeColor = Color.Red
            GridView1.Columns(16).AppearanceCell.Font = New Font(GridView1.Columns(16).AppearanceCell.Font, FontStyle.Bold)



            GridView1.Columns(8).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            GridView1.Columns(8).DisplayFormat.FormatString = "#,###,###.#0"

            GridView1.Columns(9).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            GridView1.Columns(9).DisplayFormat.FormatString = "#,###,###.#0"


            GridView1.Columns(14).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            GridView1.Columns(14).DisplayFormat.FormatString = "##.#0"

            GridView1.Columns(15).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            GridView1.Columns(15).DisplayFormat.FormatString = "##.#0"


            GridView1.OptionsView.ColumnAutoWidth = False
            GridView1.OptionsView.BestFitMaxRowCount = -1
            GridView1.BestFitColumns()


            ' Call Colorear()
            GridView1.FixedLineWidth = 2
            GridView1.Columns(0).Fixed = 1
            GridView1.Columns(1).Fixed = 1
            GridView1.Columns(2).Fixed = 1
            GridView1.Columns(3).Fixed = 1
            GridView1.Columns(4).Fixed = 1


            GridView1.Columns(0).OptionsColumn.ReadOnly = True
            GridView1.Columns(1).OptionsColumn.ReadOnly = True
            GridView1.Columns(2).OptionsColumn.ReadOnly = True
            GridView1.Columns(3).OptionsColumn.ReadOnly = True
            GridView1.Columns(4).OptionsColumn.ReadOnly = True
            GridView1.Columns(5).OptionsColumn.ReadOnly = True
            GridView1.Columns(6).OptionsColumn.ReadOnly = True
            GridView1.Columns(7).OptionsColumn.ReadOnly = True
            GridView1.Columns(8).OptionsColumn.ReadOnly = True

            GridView1.Columns(9).OptionsColumn.ReadOnly = True

            GridView1.Columns(10).OptionsColumn.ReadOnly = True
            GridView1.Columns(11).OptionsColumn.ReadOnly = True
            GridView1.Columns(12).OptionsColumn.ReadOnly = True
            GridView1.Columns(13).OptionsColumn.ReadOnly = True
            GridView1.Columns(14).OptionsColumn.ReadOnly = True
            GridView1.Columns(15).OptionsColumn.ReadOnly = True


            GridView1.Columns(16).Width = 100
            GridView1.RowHeight = 100

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub RellenaGrid()
        'mreyes 18/Agosto/2019  10:29 a.m.

        Dgrid.Visible = False

        Using objTrasp As New BCL.BCLVentaEnLinea(GLB_ConStringSirCoSQL)

            Try
                Me.Cursor = Cursors.WaitCursor
                Sw_Load = False
                'DGrid.ReadOnly = True
                ' GridControl.DataSource = Nothing

                objDataSet = objTrasp.usp_PpalSapica(FechIniB, FechFinB, Marca, Modelo, Division, Depto, Familia, Linea, L1, L2, L3, L4, L5, L6)

                'Populate the Project Details section

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    'Populate the Project Details section 
                    'DGrid.ColumnCount = objDataSet.Tables(0).Columns.Count
                    '
                    Dgrid.DataSource = objDataSet.Tables(0)

                    InicializaGrid()

                    Me.Cursor = Cursors.Default
                    Btn_Excel.Enabled = True
                    Sw_NoRegistros = True
                    Sw_Pintar = True
                Else

                    Sw_NoRegistros = False
                    Me.Cursor = Cursors.Default
                    MsgBox("LA INFORMACIÓN SE ESTA ACTUALIZANDO, FAVOR DE INTENTAR EN UNOS MINUTOS", MsgBoxStyle.Critical, "Aviso")
                    Btn_Excel.Enabled = False
                End If
                Me.Cursor = Cursors.Default
                ' LimpiarBusqueda()
                Dgrid.Visible = True
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub
    Private Sub DGrid_Click(sender As Object, e As EventArgs)

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




    Private Sub Btn_Refrescar_Click(sender As Object, e As EventArgs) Handles Btn_Refrescar.Click
        Call RellenaGrid()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Btn_Excel.Click
        If sfdRuta.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Dgrid.ExportToXls(sfdRuta.FileName)
        End If
    End Sub


    Private Sub GridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged

        Try

            'If Sw_Load = True Then
            '    Return
            'End If
            Dim precio As Decimal = 0
            Dim final As Decimal = 0
            Dim costomargen As Decimal = 0
            Dim Margen As Decimal = 0
            Dim Iva As Decimal = 0
            Dim Remision As Decimal = 0
            Dim TRemision As Decimal = 0
            Dim Renglon As Integer = 0
            Dim Columna As String = ""

            Columna = e.Column.Name

            Renglon = e.RowHandle

            If e.Column.Caption <> "Precio Nuevo" Then
                Return
            End If

            If e.Column.Caption = "Precio Nuevo" Then

                costomargen = GridView1.GetRowCellValue(Renglon, "costomargen")
                final = GridView1.GetRowCellValue(Renglon, "PrecioNuevo")


                Margen = ((final - (final * 0.1) - costomargen) / final) * 100
                precio = (final - (final * 0.1) - costomargen)
                GridView1.SetRowCellValue(Renglon, "MargenFinal", Margen)
                GridView1.SetRowCellValue(Renglon, "MargenPrecio", precio)

                Return
            End If



        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Filtro_Click(sender As Object, e As EventArgs) Handles Btn_Filtro.Click
        Try

            Dim myFormFiltros As New frmFiltrosEstrYExistActual
            myFormFiltros.StartPosition = FormStartPosition.CenterParent


            myFormFiltros.Sw_Filtro = False
            myFormFiltros.CB_Sucursal.Visible = False
            myFormFiltros.Label4.Visible = False
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
            '   Division = "CALZADO"

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
            If Modelo <> "" Then
                myFormFiltros.Txt_Modelo.Text = Modelo
            End If

            myFormFiltros.ShowDialog()
            If myFormFiltros.Sw_Filtro = True Then
                Dgrid.DataSource = Nothing
                Dgrid.Refresh()


                'If CInt(myFormFiltros.CB_Sucursal.SelectedValue.ToString) = 0 Then
                '    Sucursal = ""
                'Else
                '    Sucursal = pub_RellenarIzquierda(myFormFiltros.CB_Sucursal.SelectedValue.ToString, 2)
                '    DescripSucursal = myFormFiltros.CB_Sucursal.Text
                'End If

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
                Modelo = myFormFiltros.Txt_Modelo.Text
                'If Marca.Trim <> "" Then
                '    lbl_Marca.Text = Marca
                'End If

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

                Lbl_Leyenda.Text = Division & "\" & Marca & "\" & Modelo & "\" & Depto & "\" & Familia & "\" & Linea & "\" & L1 & "\" & L2 & "\" & L3 & "\" & L4 & "\" & L5 & "\" & L6

                Call RellenaGrid()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Dgrid_Click_1(sender As Object, e As EventArgs) Handles Dgrid.Click
        Try


            Dim Renglon As Point = Dgrid.PointToClient(Control.MousePosition)
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

    Private Sub Btn_Filtro_KeyUp(sender As Object, e As KeyEventArgs) Handles Btn_Filtro.KeyUp
        Try


            Dim Renglon As Point = Dgrid.PointToClient(Control.MousePosition)
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

    Private Sub PBox_Click(sender As Object, e As EventArgs) Handles PBox.Click

    End Sub

    Private Sub PBox_DoubleClick(sender As Object, e As EventArgs) Handles PBox.DoubleClick
        Try
            Dim myForm As New frmConsultaImagen
            myForm.Txt_Estilon.Text = EstiloNFOTO
            myForm.Txt_Marca.Text = MarcaFOTO
            myForm.Txt_NoFoto.Text = 1
            myForm.ShowDialog()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub PBox_MouseDown(sender As Object, e As MouseEventArgs) Handles PBox.MouseDown
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

    Private Sub PBox_MouseMove(sender As Object, e As MouseEventArgs) Handles PBox.MouseMove
        Try
            If e.Button = Windows.Forms.MouseButtons.Left Then
                PBox.Location = New Point(PBox.Left + e.X - izquierda, PBox.Top + e.Y - alto)
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub PBox_MouseUp(sender As Object, e As MouseEventArgs) Handles PBox.MouseUp
        Try
            PBox.Cursor = Cursors.Default
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub GridView1_RowCellStyle(sender As Object, e As RowCellStyleEventArgs) Handles GridView1.RowCellStyle

        Try
            Dim View As GridView = sender

            Dim Pos As Integer = 0
            Dim Pos1 As Integer = 0
            Dim Nombre As String = ""

            Pos = InStr(LCase(e.Column.FieldName), "margenfinal")
            Pos1 = InStr(LCase(e.Column.FieldName), "margenprecio")

            Nombre = LCase(e.Column.Name)


            If Pos > 0 Or Pos1 > 0 Then
                Dim importe As Decimal = Val(View.GetRowCellDisplayText(e.RowHandle, e.Column))
                If importe < 0 Then

                    e.Appearance.ForeColor = Color.Red
                    e.Appearance.FontStyleDelta = FontStyle.Bold
                End If
            End If


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try


    End Sub

    Private Sub Btn_Salir_Click(sender As Object, e As EventArgs) Handles Btn_Salir.Click
        Me.Close()
        Me.Dispose()
    End Sub

    'Private Sub Dgrid_KeyDown(sender As Object, e As KeyEventArgs) Handles Dgrid.KeyDown
    '    Try


    '        Dim Renglon As Point = Dgrid.PointToClient(Control.MousePosition)
    '        Dim info As GridHitInfo = GridView1.CalcHitInfo(Renglon)
    '        Dim Marca As String = ""
    '        Dim Modelo As String = ""
    '        Dim Renglon1 As Integer = info.RowHandle


    '        Marca = Mid(GridView1.GetRowCellValue(Renglon1, "marca"), 1, 3)
    '        Modelo = GridView1.GetRowCellValue(Renglon1, "modelo")

    '        CargarFotoArticulo(Marca, Modelo)

    '    Catch ExceptionErr As Exception
    '        MessageBox.Show(ExceptionErr.Message.ToString)
    '    End Try
    'End Sub

    Private Sub Dgrid_KeyUp(sender As Object, e As KeyEventArgs) Handles Dgrid.KeyUp
        Try


            'Dim Renglon As Point = Dgrid.PointToClient(Control.MousePosition)
            'Dim info As GridHitInfo = GridView1.CalcHitInfo(Renglon)
            'Dim Marca As String = ""
            'Dim Modelo As String = ""
            'Dim Renglon1 As Integer = info.RowHandle


            'Marca = Mid(GridView1.GetRowCellValue(Renglon1, "marca"), 1, 3)
            'Modelo = GridView1.GetRowCellValue(Renglon1, "modelo")

            'CargarFotoArticulo(Marca, Modelo)
            CargarFotoArticulo(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "marca").ToString(), GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "modelo").ToString())
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs)
        Try
            Dim printingSystem1 As New PrintingSystem()
            Dim printableComponentLink1 As New PrintableComponentLink()

            printingSystem1.PageSettings.Margins.Top = 0.5
            printingSystem1.PageSettings.Margins.Bottom = 0.5
            printingSystem1.PageSettings.Margins.Left = 0.5
            printingSystem1.PageSettings.Margins.Right = 0.5
            printingSystem1.Links.AddRange(New Object() {printableComponentLink1})
            printableComponentLink1.Component = Dgrid
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
            printableComponentLink12.Component = Dgrid
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
            printableComponentLink13.Component = Dgrid
            printableComponentLink13.Margins = New Margins(0.5, 0.5, 0.5, 0.5)
            'printableComponentLink1.Landscape = True


            printableComponentLink13.CreateDocument()
            printableComponentLink13.ShowPreviewDialog()


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub ImprimirReporte()
        Try
            Dim myForm As New frmReportsBrowser

            myForm.objSapica = GenerarReporte()
            myForm.WindowState = FormWindowState.Maximized

            myForm.ReportIndex = 6005
            myForm.Show()


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Function GenerarReporte() As DSSapica
        Dim Cont As Integer = 0
        Try

            GenerarReporte = New DSSapica

            For i As Integer = 0 To GridView1.RowCount - 1
                Dim objDataRow As Data.DataRow = GenerarReporte.Tables(0).NewRow()
                objDataRow.Item("linea") = GridView1.GetRowCellValue(i, "linea") & ""
                objDataRow.Item("l1") = GridView1.GetRowCellValue(i, "l1") & ""
                objDataRow.Item("marca") = GridView1.GetRowCellValue(i, "marca") & ""
                objDataRow.Item("modelo") = GridView1.GetRowCellValue(i, "modelo") & ""
                objDataRow.Item("estilof") = GridView1.GetRowCellValue(i, "estilof") & ""
                objDataRow.Item("corrida") = GridView1.GetRowCellValue(i, "corrida") & ""
                objDataRow.Item("medini") = CDbl(GridView1.GetRowCellValue(i, "medini"))
                objDataRow.Item("medfin") = CDbl(GridView1.GetRowCellValue(i, "medfin"))
                objDataRow.Item("costomargen") = CDbl(GridView1.GetRowCellValue(i, "costomargen"))
                objDataRow.Item("precio") = CDbl(GridView1.GetRowCellValue(i, "precio"))
                objDataRow.Item("recibida") = GridView1.GetRowCellValue(i, "recibida")
                objDataRow.Item("ctdneta") = GridView1.GetRowCellValue(i, "ctdneta")
                objDataRow.Item("ctdnormalneta") = GridView1.GetRowCellValue(i, "ctdnormalneta")
                objDataRow.Item("ctddesctoneta") = GridView1.GetRowCellValue(i, "ctddesctoneta")
                objDataRow.Item("mi") = GridView1.GetRowCellValue(i, "mi")
                objDataRow.Item("mf") = GridView1.GetRowCellValue(i, "mf")
                objDataRow.Item("imagen") = GridView1.GetRowCellValue(i, "foto")
                objDataRow.Item("ult_cmp") = Format(GridView1.GetRowCellValue(i, "ult_cmp"), "yyyy-MM-dd")

                If GridView1.GetRowCellValue(i, "ctdneta") > 0 Then
                    objDataRow.Item("porc1") = GridView1.GetRowCellValue(i, "ctdnormalneta") & "(" & CInt(GridView1.GetRowCellValue(i, "ctdnormalneta") * 100 / GridView1.GetRowCellValue(i, "ctdneta")) & "%)"
                Else
                    objDataRow.Item("porc1") = "0%"
                End If


                If GridView1.GetRowCellValue(i, "ctdneta") > 0 Then
                    objDataRow.Item("porc4") = GridView1.GetRowCellValue(i, "ctddesctoneta") & "(" & CInt(GridView1.GetRowCellValue(i, "ctddesctoneta") * 100 / GridView1.GetRowCellValue(i, "ctdneta")) & "%)"
                Else
                    objDataRow.Item("porc4") = "0%"
                End If

                Cont = Cont + 1
                '   GenerarReporte.Tables(0).Rows.Add(objDataRow)
                If Cont = 1 Then
                    i = i + 1
                    objDataRow.Item("linea1") = GridView1.GetRowCellValue(i, "linea") & ""
                    objDataRow.Item("l11") = GridView1.GetRowCellValue(i, "l1") & ""
                    objDataRow.Item("marca1") = GridView1.GetRowCellValue(i, "marca") & ""
                    objDataRow.Item("modelo1") = GridView1.GetRowCellValue(i, "modelo") & ""
                    objDataRow.Item("estilof1") = GridView1.GetRowCellValue(i, "estilof") & ""
                    objDataRow.Item("corrida1") = GridView1.GetRowCellValue(i, "corrida") & ""
                    objDataRow.Item("medini1") = CDbl(GridView1.GetRowCellValue(i, "medini"))
                    objDataRow.Item("medfin1") = CDbl(GridView1.GetRowCellValue(i, "medfin"))
                    objDataRow.Item("costomargen1") = CDbl(GridView1.GetRowCellValue(i, "costomargen"))
                    objDataRow.Item("precio1") = CDbl(GridView1.GetRowCellValue(i, "precio"))
                    objDataRow.Item("recibida1") = CDbl(GridView1.GetRowCellValue(i, "recibida"))
                    objDataRow.Item("ctdneta1") = CDbl(GridView1.GetRowCellValue(i, "ctdneta"))
                    objDataRow.Item("ctdnormalneta1") = CDbl(GridView1.GetRowCellValue(i, "ctdnormalneta"))
                    objDataRow.Item("ctddesctoneta1") = CDbl(GridView1.GetRowCellValue(i, "ctddesctoneta"))
                    objDataRow.Item("mi1") = CDbl(GridView1.GetRowCellValue(i, "mi"))
                    objDataRow.Item("mf1") = CDbl(GridView1.GetRowCellValue(i, "mf"))
                    objDataRow.Item("foto1") = GridView1.GetRowCellValue(i, "foto")
                    objDataRow.Item("ult_cmp1") = Format(GridView1.GetRowCellValue(i, "ult_cmp"), "yyyy-MM-dd")
                    Cont = Cont + 1

                    If GridView1.GetRowCellValue(i, "ctdneta") > 0 Then
                        objDataRow.Item("porc2") = GridView1.GetRowCellValue(i, "ctdnormalneta") & "(" & CInt(GridView1.GetRowCellValue(i, "ctdnormalneta") * 100 / GridView1.GetRowCellValue(i, "ctdneta")) & "%)"
                    Else
                        objDataRow.Item("porc2") = "0%"
                    End If

                    If GridView1.GetRowCellValue(i, "ctdneta") > 0 Then
                        objDataRow.Item("porc5") = GridView1.GetRowCellValue(i, "ctddesctoneta") & "(" & CInt(GridView1.GetRowCellValue(i, "ctddesctoneta") * 100 / GridView1.GetRowCellValue(i, "ctdneta")) & "%)"
                    Else
                        objDataRow.Item("porc5") = "0%"
                    End If


                    '  GenerarReporte.Tables(0).Rows.Add(objDataRow)
                End If

                If Cont = 2 Then
                    i = i + 1
                    objDataRow.Item("linea2") = GridView1.GetRowCellValue(i, "linea") & ""
                    objDataRow.Item("l12") = GridView1.GetRowCellValue(i, "l1") & ""
                    objDataRow.Item("marca2") = GridView1.GetRowCellValue(i, "marca") & ""
                    objDataRow.Item("modelo2") = GridView1.GetRowCellValue(i, "modelo") & ""
                    objDataRow.Item("estilof2") = GridView1.GetRowCellValue(i, "estilof") & ""
                    objDataRow.Item("corrida2") = GridView1.GetRowCellValue(i, "corrida") & ""
                    objDataRow.Item("medini2") = CDbl(GridView1.GetRowCellValue(i, "medini"))
                    objDataRow.Item("medfin2") = CDbl(GridView1.GetRowCellValue(i, "medfin"))
                    objDataRow.Item("costomargen2") = CDbl(GridView1.GetRowCellValue(i, "costomargen"))
                    objDataRow.Item("precio2") = CDbl(GridView1.GetRowCellValue(i, "precio"))
                    objDataRow.Item("recibida2") = CDbl(GridView1.GetRowCellValue(i, "recibida"))
                    objDataRow.Item("ctdneta2") = CDbl(GridView1.GetRowCellValue(i, "ctdneta"))
                    objDataRow.Item("ctdnormalneta2") = CDbl(GridView1.GetRowCellValue(i, "ctdnormalneta"))
                    objDataRow.Item("ctddesctoneta2") = CDbl(GridView1.GetRowCellValue(i, "ctddesctoneta"))
                    objDataRow.Item("mi2") = CDbl(GridView1.GetRowCellValue(i, "mi"))
                    objDataRow.Item("mf2") = CDbl(GridView1.GetRowCellValue(i, "mf"))
                    objDataRow.Item("foto2") = GridView1.GetRowCellValue(i, "foto")
                    objDataRow.Item("ult_cmp2") = Format(GridView1.GetRowCellValue(i, "ult_cmp"), "yyyy-MM-dd")
                    Cont = 0

                    If GridView1.GetRowCellValue(i, "ctdneta") > 0 Then
                        objDataRow.Item("porc3") = GridView1.GetRowCellValue(i, "ctdnormalneta") & "(" & CInt(GridView1.GetRowCellValue(i, "ctdnormalneta") * 100 / GridView1.GetRowCellValue(i, "ctdneta")) & "%)"
                    Else
                        objDataRow.Item("porc3") = "0%"
                    End If

                    If GridView1.GetRowCellValue(i, "ctdneta") > 0 Then
                        objDataRow.Item("porc6") = GridView1.GetRowCellValue(i, "ctddesctoneta") & "(" & CInt(GridView1.GetRowCellValue(i, "ctddesctoneta") * 100 / GridView1.GetRowCellValue(i, "ctdneta")) & "%)"
                    Else
                        objDataRow.Item("porc6") = "0%"
                    End If

                    GenerarReporte.Tables(0).Rows.Add(objDataRow)
                End If




            Next
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Glb_Mensaje = Lbl_Leyenda.Text
            Call ImprimirReporte()


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub

    Private Sub Btn_Imprimir_Click(sender As Object, e As EventArgs) Handles Btn_Imprimir.Click
        Try
            Dim printingSystem1 As New PrintingSystem()
            Dim printableComponentLink1 As New PrintableComponentLink()

            printingSystem1.PageSettings.Margins.Top = 0.5
            printingSystem1.PageSettings.Margins.Bottom = 0.5
            printingSystem1.PageSettings.Margins.Left = 0.5
            printingSystem1.PageSettings.Margins.Right = 0.5
            printingSystem1.Links.AddRange(New Object() {printableComponentLink1})
            printableComponentLink1.Component = Dgrid
            printableComponentLink1.Margins = New Margins(0.5, 0.5, 0.5, 0.5)
            'printableComponentLink1.Landscape = True


            printableComponentLink1.CreateDocument()
            printableComponentLink1.ShowPreviewDialog()




        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
End Class