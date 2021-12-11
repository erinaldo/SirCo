Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid.Views.Grid
Public Class frmPpalGestoresDeCartera
    Dim objDataSet As Data.DataSet
    Dim idgestor As Integer = 0
    Dim Opcion As Integer = 0
    Dim nombreGestor As String
    Dim appaternoGestor As String
    Dim apmaternoGestor As String
    Dim tipogestor As String
    Dim carterafresca As Integer
    Dim carteravencida As Integer
    Private Sub RellenaGrid()

        Using objTrasp As New BCL.BCLGestoresDeCartera(GLB_ConStringCreditoSQL)

            Try
                Me.Cursor = Cursors.WaitCursor
                DGrid.DataSource = Nothing


                objDataSet = objTrasp.usp_TraerGestoresDeCartera(1, idgestor)
                If objDataSet.Tables(0).Rows.Count > 0 Then

                    Btn_Editar.Enabled = True
                    Btn_Consultar.Enabled = True
                    Btn_Excel.Enabled = True
                    DGrid.DataSource = objDataSet.Tables(0)
                    InicializaGrid()
                    GridView1.BestFitColumns()

                    Me.Cursor = Cursors.Default
                Else
                    Me.Cursor = Cursors.Default
                    MsgBox("No se encontraron registros que cumplan con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")
                    Btn_Editar.Enabled = False
                    Btn_Consultar.Enabled = False
                    Btn_Excel.Enabled = False
                End If

                Me.Cursor = Cursors.Default

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub GenerarToolTip()
        Try

            ToolTip1.SetToolTip(Btn_Consultar, "Consultar")
            ToolTip1.SetToolTip(Btn_Nuevo, "    Nuevo")
            ToolTip1.SetToolTip(Btn_Editar, "Editar")
            ToolTip1.SetToolTip(Btn_Excel, "Generar Excel")
            ToolTip1.SetToolTip(Btn_Salir, "Salir")

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Sub InicializaGrid()
        Try
            GridView1.Columns("idgestor").Caption = "idGestor"
            GridView1.Columns("nombre").Caption = "Nombre"
            GridView1.Columns("appaterno").Caption = "Apellido Paterno"
            GridView1.Columns("apmaterno").Caption = "Apellido Materno"
            GridView1.Columns("tipo").Caption = "Tipo"
            GridView1.Columns("carterafresca").Caption = "Cartera Fresca"
            GridView1.Columns("carteravencida").Caption = "Cartera Vencida"
            GridView1.Columns("fum").Caption = "Fecha de registro"


            GridView1.OptionsView.ColumnAutoWidth = False

            GridView1.Columns("idgestor").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns("carterafresca").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns("carteravencida").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center


            For I As Integer = 0 To GridView1.Columns.Count - 1

                GridView1.Columns(I).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                GridView1.Columns(I).AppearanceHeader.Font = New Font(GridView1.Columns(I).AppearanceCell.Font, FontStyle.Bold)
                GridView1.Columns(I).OptionsColumn.ReadOnly = True

            Next

            GridView1.Columns("idgestor").Visible = False
            GridView1.Columns("carterafresca").Visible = False
            GridView1.Columns("carteravencida").Visible = False
            GridView1.Columns("fum").Visible = False

            GridView1.BestFitColumns()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub



    Private Sub Btn_Excel_Click(sender As Object, e As EventArgs) Handles Btn_Excel.Click
        Try
            If sfdRuta.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                DGrid.ExportToXls(sfdRuta.FileName)
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub PpalGestoresDeCartera_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call GenerarToolTip()
        Call RellenaGrid()
    End Sub

    Private Sub Btn_Salir_Click(sender As Object, e As EventArgs) Handles Btn_Salir.Click
        Me.Close()
    End Sub

    Private Sub Btn_Nuevo_Click(sender As Object, e As EventArgs) Handles Btn_Nuevo.Click
        Try
            Opcion = 1
            Dim myForm As New frmCatalogoGestoresDeCartera
            myForm.Accion = Opcion
            myForm.Text = myForm.Text + "(Nuevo Gestor de Cartera)"
            myForm.ShowDialog()

            Call RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Editar_Click(sender As Object, e As EventArgs) Handles Btn_Editar.Click
        Try
            Opcion = 2
            Dim myForm As New frmCatalogoGestoresDeCartera
            myForm.Accion = Opcion
            myForm.Text = myForm.Text + " (Editar Gestor de Cartera)"
            Dim idGestor As Integer
            For i As Integer = 0 To GridView1.RowCount - 1


                If GridView1.IsRowSelected(i) = True Then
                    idGestor = GridView1.GetRowCellValue(i, "idgestor")
                    nombreGestor = GridView1.GetRowCellValue(i, "nombre")
                    appaternoGestor = GridView1.GetRowCellValue(i, "appaterno")
                    apmaternoGestor = GridView1.GetRowCellValue(i, "apmaterno")
                    tipogestor = GridView1.GetRowCellValue(i, "tipo")
                    carterafresca = GridView1.GetRowCellValue(i, "carterafresca")
                    carteravencida = GridView1.GetRowCellValue(i, "carteravencida")
                End If
            Next

            myForm.Txt_id.Text = idGestor
            myForm.Txt_id.Enabled = False
            myForm.Txt_Nombre.Text = nombreGestor
            myForm.Txt_Appaterno.Text = appaternoGestor
            myForm.Txt_Apmaterno.Text = apmaternoGestor
            myForm.tipoGestor = tipogestor
            If carterafresca = 1 Then
                myForm.Chk_CarteraFresca.Checked = True
                myForm.Chk_CarteraVencida.Checked = False
            ElseIf carteravencida = 1 Then
                myForm.Chk_CarteraVencida.Checked = True
                myForm.Chk_CarteraFresca.Checked = False
            End If
            myForm.ShowDialog()
            Call InicializaGrid()
            Call RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Consultar_Click(sender As Object, e As EventArgs) Handles Btn_Consultar.Click
        Try
            Try

                Dim Myform As New frmCatalogoGestoresDeCartera
                Dim Renglon As Point = DGrid.PointToClient(Control.MousePosition)
                Dim info As GridHitInfo = GridView1.CalcHitInfo(Renglon)

                Dim Renglon1 As Integer = info.RowHandle



                Myform.Accion = 3
                Myform.Text = Myform.Text + " Consultar Gestor de Cartera)"
                Myform.Txt_id.Text = GridView1.GetRowCellValue(Renglon1, "idgestor")

                Myform.Txt_Nombre.Text = GridView1.GetRowCellValue(Renglon1, "nombre")
                Myform.Txt_Appaterno.Text = GridView1.GetRowCellValue(Renglon1, "appaterno")
                Myform.Txt_Apmaterno.Text = GridView1.GetRowCellValue(Renglon1, "apmaterno")
                carterafresca = GridView1.GetRowCellValue(Renglon1, "carterafresca")
                carteravencida = GridView1.GetRowCellValue(Renglon1, "carteravencida")
                Myform.Pnl_Gestor.Enabled = False
                Myform.Btn_Aceptar.Enabled = False

                If carterafresca = 1 Then
                    Myform.Chk_CarteraFresca.Checked = True
                    Myform.Chk_CarteraVencida.Checked = False
                ElseIf carteravencida = 1 Then
                    Myform.Chk_CarteraVencida.Checked = True
                    Myform.Chk_CarteraFresca.Checked = False
                End If
                Myform.ShowDialog()

                If GLB_RefrescarPedido = True Then
                    Call RellenaGrid()
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show("Seleccione un cliente porfavor, " & ExceptionErr.Message.ToString)
            End Try
            'Opcion = 3
            'Dim myForm As New frmCatalogoGestoresDeCartera
            'myForm.Accion = Opcion
            'myForm.Text = myForm.Text + " (Consultar Gestor de Cartera)"
            'Dim idGestor As Integer
            'For i As Integer = 0 To GridView1.RowCount - 1


            '    If GridView1.IsRowSelected(i) = True Then
            '        idGestor = GridView1.GetRowCellValue(i, "idgestor")
            '        nombreGestor = GridView1.GetRowCellValue(i, "nombre")
            '        appaternoGestor = GridView1.GetRowCellValue(i, "appaterno")
            '        apmaternoGestor = GridView1.GetRowCellValue(i, "apmaterno")
            '        tipogestor = GridView1.GetRowCellValue(i, "tipo")
            '        carterafresca = GridView1.GetRowCellValue(i, "carterafresca")
            '        carteravencida = GridView1.GetRowCellValue(i, "carteravencida")
            '    End If
            'Next
            'myForm.Txt_id.Text = idGestor
            'myForm.Pnl_Gestor.Enabled = False
            'myForm.Btn_Aceptar.Enabled = False
            'myForm.Txt_Nombre.Text = nombreGestor
            'myForm.Txt_Appaterno.Text = appaternoGestor
            'myForm.Txt_Apmaterno.Text = apmaternoGestor
            'If carterafresca = 1 Then
            '    myForm.Chk_CarteraFresca.Checked = True
            '    myForm.Chk_CarteraVencida.Checked = False
            'ElseIf carteravencida = 1 Then
            '    myForm.Chk_CarteraVencida.Checked = True
            '    myForm.Chk_CarteraFresca.Checked = False
            'End If
            'myForm.ShowDialog()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_DoubleClick(sender As Object, e As EventArgs) Handles DGrid.DoubleClick
        Try
            Dim Myform As New frmCatalogoGestoresDeCartera
            Dim Renglon As Point = DGrid.PointToClient(Control.MousePosition)
            Dim info As GridHitInfo = GridView1.CalcHitInfo(Renglon)

            Dim Renglon1 As Integer = info.RowHandle



            Myform.Accion = 3
            Myform.Text = Myform.Text + " Consultar Gestor de Cartera)"
            Myform.Txt_id.Text = GridView1.GetRowCellValue(Renglon1, "idgestor")

            Myform.Txt_Nombre.Text = GridView1.GetRowCellValue(Renglon1, "nombre")
            Myform.Txt_Appaterno.Text = GridView1.GetRowCellValue(Renglon1, "appaterno")
            Myform.Txt_Apmaterno.Text = GridView1.GetRowCellValue(Renglon1, "apmaterno")
            carterafresca = GridView1.GetRowCellValue(Renglon1, "carterafresca")
            carteravencida = GridView1.GetRowCellValue(Renglon1, "carteravencida")
            Myform.Pnl_Gestor.Enabled = False
            Myform.Btn_Aceptar.Enabled = False

            If carterafresca = 1 Then
                Myform.Chk_CarteraFresca.Checked = True
                Myform.Chk_CarteraVencida.Checked = False
            ElseIf carteravencida = 1 Then
                Myform.Chk_CarteraVencida.Checked = True
                Myform.Chk_CarteraFresca.Checked = False
            End If
            Myform.ShowDialog()

            If GLB_RefrescarPedido = True Then
                Call RellenaGrid()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show("Seleccione un cliente porfavor, " & ExceptionErr.Message.ToString)
        End Try
    End Sub
End Class