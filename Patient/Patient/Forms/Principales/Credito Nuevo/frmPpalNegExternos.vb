Public Class frmPpalNegExternos
    Private objDataSet As Data.DataSet


    Private Sub RellenarGrid()
        Using objCatalogo As New BCL.BCLNegociosExternos(GLB_ConStringSircoControlSQL)

            Try
                Me.Cursor = Cursors.WaitCursor
                Grid.DataSource = Nothing
                'Mandamos la opcion 3 como parametro para rellenar el Grid
                objDataSet = objCatalogo.usp_mostrarNegociosExternos(3, 0, "", "", 0, 0, Date.Now)
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Grid.DataSource = objDataSet.Tables(0)

                    'Icializamos nuestro Grid para ver los datos 
                    InicializaGrid()
                    GridView1.BestFitColumns()

                    Me.Cursor = Cursors.Default
                Else
                    Me.Cursor = Cursors.Default
                    If Grid.DataSource = Nothing Then
                        Btn_Editar.Enabled = False
                        Btn_Consultar.Enabled = False
                        Btn_Excel.Enabled = False
                    End If
                    MsgBox("No se encontraron registros que cumplan con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")

                End If

                Me.Cursor = Cursors.Default

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Sub InicializaGrid()
        Try
            GridView1.Columns("idnegexterno").Visible = False
            GridView1.Columns("idusuario").Visible = False
            GridView1.Columns("idusuariomodif").Visible = False

            GridView1.Columns("idnegexterno").Caption = "Id Negocio Externo"
            GridView1.Columns("negocio").Caption = "Negocio"
            GridView1.Columns("descripcion").Caption = "Descripción"
            GridView1.Columns("idusuario").Caption = "id Usuario"
            GridView1.Columns("fum").Caption = "fum"
            GridView1.Columns("idusuariomodif").Caption = "idusuariomodif"
            GridView1.Columns("fummodif").Caption = "fummodif"

            GridView1.OptionsView.ColumnAutoWidth = False

            For I As Integer = 0 To GridView1.Columns.Count - 1

                GridView1.Columns(I).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                GridView1.Columns(I).AppearanceHeader.Font = New Font(GridView1.Columns(I).AppearanceCell.Font, FontStyle.Bold)
                GridView1.Columns(I).OptionsColumn.ReadOnly = True

            Next

            GridView1.BestFitColumns()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Btn_Salir_Click(sender As Object, e As EventArgs) Handles Btn_Salir.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub frmPpalNegExternos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RellenarGrid()
    End Sub

    Private Sub Btn_Refrescar_Click(sender As Object, e As EventArgs) Handles Btn_Refrescar.Click
        RellenarGrid()
    End Sub

    Private Sub Btn_Nuevo_Click(sender As Object, e As EventArgs) Handles Btn_Nuevo.Click
        Dim myForm As New frmCatalogosNegExternos
        myForm.opcion = 1
        'Call Edicion()
        Btn_Nuevo.Enabled = True
        Btn_Consultar.Enabled = True
        Btn_Excel.Enabled = True
        myForm.ShowDialog()
        Call RellenarGrid()
        Call InicializaGrid()
    End Sub

    Private Sub Btn_Editar_Click(sender As Object, e As EventArgs) Handles Btn_Editar.Click
        Dim myForm As New frmCatalogosNegExternos
        myForm.opcion = 2
        'myForm.getRow()

        Dim Renglon As Integer = 0
        Dim intposicion As Integer = 0
        Dim inttotalrows As Integer = 0
        Dim idnegexterno As Integer = 0
        Dim negocio As String = ""
        Dim descripcion As String = ""


        For i As Integer = 0 To GridView1.RowCount - 1


            If GridView1.IsRowSelected(i) = True Then
                idnegexterno = GridView1.GetRowCellValue(i, "idnegexterno")
                negocio = GridView1.GetRowCellValue(i, "negocio")
                descripcion = GridView1.GetRowCellValue(i, "descripcion")

            End If
        Next

        myForm.getRow(idnegexterno)
        myForm.Txt_Negocio1.Text = negocio
        myForm.Txt_Descripcion1.Text = descripcion
        myForm.Btn_Limpia.Enabled = False
        myForm.ShowDialog()
        Call RellenarGrid()
        Call InicializaGrid()
    End Sub

    Private Sub Grid_DoubleClick(sender As Object, e As EventArgs) Handles Grid.DoubleClick
        Dim myForm As New frmCatalogosNegExternos
        myForm.opcion = 2

        Dim Renglon As Integer = 0
        Dim intposicion As Integer = 0
        Dim inttotalrows As Integer = 0
        Dim idnegexterno As Integer = 0
        Dim negocio As String = ""
        Dim descripcion As String = ""


        For i As Integer = 0 To GridView1.RowCount - 1


            If GridView1.IsRowSelected(i) = True Then
                idnegexterno = GridView1.GetRowCellValue(i, "idnegexterno")
                negocio = GridView1.GetRowCellValue(i, "negocio")
                descripcion = GridView1.GetRowCellValue(i, "descripcion")

            End If
        Next

        myForm.getRow(idnegexterno)
        myForm.Txt_Negocio1.Text = negocio
        myForm.Txt_Descripcion1.Text = descripcion
        myForm.Txt_Negocio1.Enabled = False
        myForm.Txt_Descripcion1.Enabled = False
        myForm.Btn_Acepta.Enabled = False
        myForm.Btn_Limpia.Enabled = False
        myForm.ShowDialog()
        Call InicializaGrid()
    End Sub

    Private Sub Btn_Consultar_Click(sender As Object, e As EventArgs) Handles Btn_Consultar.Click
        Dim myForm As New frmCatalogosNegExternos
        myForm.opcion = 2

        Dim Renglon As Integer = 0
        Dim intposicion As Integer = 0
        Dim inttotalrows As Integer = 0
        Dim idnegexterno As Integer = 0
        Dim negocio As String = ""
        Dim descripcion As String = ""


        For i As Integer = 0 To GridView1.RowCount - 1


            If GridView1.IsRowSelected(i) = True Then
                idnegexterno = GridView1.GetRowCellValue(i, "idnegexterno")
                negocio = GridView1.GetRowCellValue(i, "negocio")
                descripcion = GridView1.GetRowCellValue(i, "descripcion")

            End If
        Next

        myForm.getRow(idnegexterno)
        myForm.Txt_Negocio1.Text = negocio
        myForm.Txt_Descripcion1.Text = descripcion
        myForm.Txt_Negocio1.Enabled = False
        myForm.Txt_Descripcion1.Enabled = False
        myForm.Btn_Acepta.Enabled = False
        myForm.Btn_Limpia.Enabled = False
        myForm.ShowDialog()
        Call InicializaGrid()
    End Sub
End Class