Imports DevExpress.XtraGrid.Views.Grid.ViewInfo

Public Class frmPpalTipoVivenda
    'lvillegas 2018-01-19 18:16 p.m.
    Private objDataSet As Data.DataSet
    Public Opcion As Integer  '' 1  = nuevo, 2 = eliminar(no usar) , 3 = editar , 4 = consultar 


    Private Sub RellenarGrid()
        Using objCatalogo As New BCL.BCLTipoVivienda(GLB_ConStringSircoControlSQL)

            Try
                Me.Cursor = Cursors.WaitCursor
                Grid.DataSource = Nothing
                'Mandamos la Opcion 4 como parametro para rellenar el Grid
                objDataSet = objCatalogo.usp_mostrarTipoVivienda(4, 0, "", "", 0, 0, Date.Now)
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Grid.DataSource = objDataSet.Tables(0)

                    'Icializamos nuestro Grid para ver los datos 
                    InicializaGrid()
                    GridView.BestFitColumns()

                    Me.Cursor = Cursors.Default
                Else
                    Me.Cursor = Cursors.Default
                    If Grid.DataSource = Nothing Then
                        Btn_Editar.Enabled = False
                        Btn_Consultar.Enabled = False
                        Btn_Excel.Enabled = False
                    End If
                    MsgBox("No se encontraron registros De Tipo Vivienda. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")

                End If

                Me.Cursor = Cursors.Default

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub


    Sub InicializaGrid()
        Try

            GridView.Columns("idtipovivienda").Visible = False
            GridView.Columns("idusuario").Visible = False
            GridView.Columns("idusuariomodif").Visible = False

            GridView.Columns("idtipovivienda").Caption = "Id Tipo Vivienda"
            GridView.Columns("tipovivienda").Caption = "Tipo Vivivenda"
            GridView.Columns("observaciones").Caption = "Observaciones"
            GridView.Columns("idusuario").Caption = "Id Usuario"
            GridView.Columns("fum").Caption = "fum"
            GridView.Columns("idusuariomodif").Caption = "idusuariomodif"
            GridView.Columns("fummodif").Caption = "fummodif"



            GridView.OptionsView.ColumnAutoWidth = False

            For I As Integer = 0 To GridView.Columns.Count - 1

                GridView.Columns(I).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                GridView.Columns(I).AppearanceHeader.Font = New Font(GridView.Columns(I).AppearanceCell.Font, FontStyle.Bold)
                GridView.Columns(I).OptionsColumn.ReadOnly = True

            Next

            GridView.BestFitColumns()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Btn_Salir_Click(sender As Object, e As EventArgs) Handles Btn_Salir.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub Btn_Nuevo_Click(sender As Object, e As EventArgs) Handles Btn_Nuevo.Click

        Dim myForm As New frmCapturaTipoVivienda
        myForm.Opcionn = 1
        Call Edicion()
        Btn_Editar.Enabled = True
        Btn_Consultar.Enabled = True
        Btn_Excel.Enabled = True
        myForm.ShowDialog()
        Call InicializaGrid()
        Call RellenarGrid()



    End Sub

    Private Sub Btn_Editar_Click(sender As Object, e As EventArgs) Handles Btn_Editar.Click
        Dim MyForm As New frmCapturaTipoVivienda
        MyForm.Opcionn = 3
        MyForm.Text = MyForm.Text + "Editar Tipo Vivienda"


        Dim Renglon As Integer = 0
        Dim posicion As Integer = 0
        Dim totalrows As Integer = 0
        Dim idtipovivienda As Integer = 0
        Dim tipo As String = ""
        Dim Observaciones As String = ""

        For i As Integer = 0 To GridView.RowCount - 1


            If GridView.IsRowSelected(i) = True Then
                idtipovivienda = GridView.GetRowCellValue(i, "idtipovivienda")
                tipo = GridView.GetRowCellValue(i, "tipovivienda")
                Observaciones = GridView.GetRowCellValue(i, "observaciones")
            End If
        Next

        MyForm.getRow(idtipovivienda)
        MyForm.Txt_tipovivienda.Text = tipo
        MyForm.Txt_Observaciones.Text = Observaciones


        MyForm.ShowDialog()
        Call InicializaGrid()
        Call RellenarGrid()



    End Sub

    Private Sub Btn_Excel_Click(sender As Object, e As EventArgs) Handles Btn_Excel.Click

        'Try
        '    If ExportarDGridAExcel(GridView) = False Then
        '        MsgBox("Error al exportar a Excel. Intente nuevamente.", MsgBoxStyle.Critical, "Excel")
        '    End If
        'Catch ExceptionErr As Exception
        '    MessageBox.Show(ExceptionErr.Message.ToString)
        'End Try

    End Sub

    Private Sub Btn_Refrescar_Click(sender As Object, e As EventArgs) Handles Btn_Refrescar.Click
        Call Edicion()
        RellenarGrid()
    End Sub

    Private Sub Btn_Consultar_Click(sender As Object, e As EventArgs) Handles Btn_Consultar.Click
        Dim MyForm As New frmCapturaTipoVivienda

        Dim Renglon As Integer = 0
        Dim posicion As Integer = 0
        Dim totalrows As Integer = 0
        Dim idtipovivienda As Integer = 0
        Dim tipo As String = ""
        Dim Observaciones As String = ""

        For i As Integer = 0 To GridView.RowCount - 1


            If GridView.IsRowSelected(i) = True Then
                idtipovivienda = GridView.GetRowCellValue(i, "idtipovivienda")
                tipo = GridView.GetRowCellValue(i, "tipovivienda")
                Observaciones = GridView.GetRowCellValue(i, "observaciones")
            End If
        Next


        MyForm.Txt_tipovivienda.Text = tipo
        MyForm.Txt_Observaciones.Text = Observaciones
        MyForm.Txt_tipovivienda.Enabled = False
        MyForm.Txt_Observaciones.Enabled = False
        MyForm.Btn_LimpiarCampos.Enabled = False
        MyForm.Btn_Aceptar.Enabled = False
        MyForm.ShowDialog()
        Call InicializaGrid()
    End Sub

    Private Sub frmPpalTipoVivenda_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RellenarGrid()
    End Sub

    Private Sub Btn_Eliminar_Click(sender As Object, e As EventArgs)

    End Sub

    Public Sub Edicion()
        Select Case Opcion
            Case 1, 3
                Btn_Nuevo.Enabled = True
                Btn_Editar.Enabled = True

                If Opcion = 1 Then
                    Btn_Nuevo.Enabled = True

                    Btn_Editar.Enabled = False
                    Btn_Consultar.Enabled = False
                    Btn_Refrescar.Enabled = False
                    Btn_Excel.Enabled = False
                    Btn_Salir.Enabled = False


                ElseIf Opcion = 3 Then
                    Btn_Nuevo.Enabled = False

                    Btn_Editar.Enabled = True
                    Btn_Consultar.Enabled = False
                    Btn_Refrescar.Enabled = False
                    Btn_Excel.Enabled = False
                    Btn_Salir.Enabled = False
                End If

            Case 2, 4

                Btn_Consultar.Enabled = True

                If Opcion = 2 Then
                    Btn_Nuevo.Enabled = False

                    Btn_Editar.Enabled = False
                    Btn_Consultar.Enabled = False
                    Btn_Refrescar.Enabled = False
                    Btn_Excel.Enabled = False
                    Btn_Salir.Enabled = False

                ElseIf Opcion = 4 Then
                    Btn_Nuevo.Enabled = False

                    Btn_Editar.Enabled = False
                    Btn_Consultar.Enabled = True
                    Btn_Refrescar.Enabled = False
                    Btn_Excel.Enabled = False
                    Btn_Salir.Enabled = False

                End If

        End Select
    End Sub

    Private Sub Grid_DoubleClick(sender As Object, e As EventArgs) Handles Grid.DoubleClick

        Dim myForm As New frmCapturaTipoVivienda
        myForm.Opcionn = 3
        myForm.Text = myForm.Text + "Editar Tipo Vivienda"
        'myForm.getRow()

        Dim Renglon As Integer = 0
        Dim intposicion As Integer = 0
        Dim inttotalrows As Integer = 0
        Dim idtipovivienda As Integer = 0
        Dim tipo As String = ""
        Dim Observaciones As String = ""

        For i As Integer = 0 To GridView.RowCount - 1


            If GridView.IsRowSelected(i) = True Then
                idtipovivienda = GridView.GetRowCellValue(i, "idtipovivienda")
                tipo = GridView.GetRowCellValue(i, "tipovivienda")
                Observaciones = GridView.GetRowCellValue(i, "observaciones")
            End If
        Next

        myForm.getRow(idtipovivienda)
        myForm.Txt_tipovivienda.Text = tipo
        myForm.Txt_Observaciones.Text = Observaciones


        myForm.ShowDialog()
        Call InicializaGrid()
    End Sub
End Class