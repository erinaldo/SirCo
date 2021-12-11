Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid.Views.Grid
Public Class frmPpalValeras
    Dim opcion As Integer = 0
    Dim objDataSet As Data.DataSet
    Dim idvalera As String = ""
    Dim iddistrib As Integer
    Dim valeini As String
    Dim valefin As String
    Dim entrega As Date
    Dim recoge As String
    Dim idusuario As Integer = GLB_Idempleado
    Dim idusuariomodif As Integer
    Dim distrib As String
    Dim distribuidor As String

    Private Sub Btn_Excel_Click(sender As Object, e As EventArgs) Handles Btn_Excel.Click
        Try
            If sfdRuta.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                DGrid.ExportToXls(sfdRuta.FileName)
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Sub InicializaGrid()
        Try
            GridView1.Columns("iddistrib").Caption = "idDistrib"
            GridView1.Columns("distrib").Caption = "FolioDistrib"
            GridView1.Columns("distribuidor").Caption = "Distribuidor"
            GridView1.Columns("valera").Caption = "Valera"
            GridView1.Columns("valeini").Caption = "Folio Inicial"
            GridView1.Columns("valefin").Caption = "Folio Final"
            GridView1.Columns("entrega").Caption = "Fecha de Entrega"
            GridView1.Columns("recoge").Caption = "Recoge"
            GridView1.Columns("fum").Caption = "FUM"

            GridView1.OptionsView.ColumnAutoWidth = False

            GridView1.Columns("iddistrib").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns("distrib").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            'GridView1.Columns("distribuidor").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns("valera").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns("valeini").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns("valefin").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns("entrega").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns("recoge").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

            For I As Integer = 0 To GridView1.Columns.Count - 1

                GridView1.Columns(I).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                GridView1.Columns(I).AppearanceHeader.Font = New Font(GridView1.Columns(I).AppearanceCell.Font, FontStyle.Bold)
                GridView1.Columns(I).OptionsColumn.ReadOnly = True

            Next

            GridView1.Columns("iddistrib").Visible = False
            GridView1.Columns("distrib").Visible = False
            GridView1.Columns("entrega").Visible = False
            GridView1.Columns("recoge").Visible = False
            GridView1.Columns("fum").Visible = False

            GridView1.BestFitColumns()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub Btn_Salir_Click(sender As Object, e As EventArgs) Handles Btn_Salir.Click
        Me.Close()
    End Sub

    Private Sub frmPpalValeras_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RellenaGrid()
    End Sub

    Private Sub RellenaGrid()

        Using objTrasp As New BCL.BCLValera(GLB_ConStringCreditoSQL)

            Try
                Me.Cursor = Cursors.WaitCursor
                DGrid.DataSource = Nothing


                objDataSet = objTrasp.usp_TraerEntregaDeValeras(idvalera)
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

    Private Sub Btn_Nuevo_Click(sender As Object, e As EventArgs) Handles Btn_Nuevo.Click
        Try
            Dim myForm As New frmCatalogoValeras
            myForm.Text = myForm.Text + "(Nueva Entrega de Valeras)"
            myForm.Accion = 1
            myForm.ShowDialog()
            Call RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Editar_Click(sender As Object, e As EventArgs) Handles Btn_Editar.Click
        Try
            Dim myForm As New frmCatalogoValeras
            myForm.Text = myForm.Text + " (Editar Valera)"
            Dim valera As String = ""
            Dim Renglon As Integer = 0
            Dim intposicion As Integer = 0
            Dim inttotalrows As Integer = 0
            Dim IdCliente As Integer = 0
            Dim tipo As String = ""
            Dim Observaciones As String = ""

            For i As Integer = 0 To GridView1.RowCount - 1


                If GridView1.IsRowSelected(i) = True Then
                    iddistrib = GridView1.GetRowCellValue(i, "iddistrib")
                    distrib = GridView1.GetRowCellValue(i, "distrib")
                    distribuidor = GridView1.GetRowCellValue(i, "distribuidor")
                    valera = GridView1.GetRowCellValue(i, "valera")
                    valeini = GridView1.GetRowCellValue(i, "valeini")
                    valefin = GridView1.GetRowCellValue(i, "valefin")
                    entrega = GridView1.GetRowCellValue(i, "entrega")
                    recoge = GridView1.GetRowCellValue(i, "recoge")
                End If
            Next

            myForm.Accion = 2
            myForm.Txt_Recoge.Text = recoge
            myForm.Dt_Entrega.Text = entrega
            myForm.Txt_ValeHasta.Text = valefin
            myForm.Txt_ValeDesde.Text = valeini
            myForm.Txt_idDistrib.Text = distrib
            myForm.Txt_NombreDistrib.Text = distribuidor
            myForm.Txt_Valera.Text = valera

            myForm.Txt_Valera.Enabled = False


            myForm.ShowDialog()
            Call InicializaGrid()
            Call RellenaGrid()

        Catch ExceptionErr As Exception
            MessageBox.Show("Seleccione un cliente porfavor, " & ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Consultar_Click(sender As Object, e As EventArgs) Handles Btn_Consultar.Click
        Try
            Dim myForm As New frmCatalogoValeras
            myForm.Text = myForm.Text + " (Consultar Valera)"

            Dim valera As String = ""

            For i As Integer = 0 To GridView1.RowCount - 1


                If GridView1.IsRowSelected(i) = True Then
                    iddistrib = GridView1.GetRowCellValue(i, "iddistrib")
                    distrib = GridView1.GetRowCellValue(i, "distrib")
                    distribuidor = GridView1.GetRowCellValue(i, "distribuidor")
                    valera = GridView1.GetRowCellValue(i, "valera")
                    valeini = GridView1.GetRowCellValue(i, "valeini")
                    valefin = GridView1.GetRowCellValue(i, "valefin")
                    entrega = GridView1.GetRowCellValue(i, "entrega")
                    recoge = GridView1.GetRowCellValue(i, "recoge")
                End If
            Next

            myForm.Accion = 3
            myForm.Txt_Recoge.Text = recoge
            myForm.Dt_Entrega.Text = entrega
            myForm.Txt_ValeHasta.Text = valefin
            myForm.Txt_ValeDesde.Text = valeini
            myForm.Txt_idDistrib.Text = distrib
            myForm.Txt_NombreDistrib.Text = distribuidor
            myForm.Txt_Valera.Text = valera

            myForm.Txt_Valera.Enabled = False
            myForm.Btn_Aceptar.Enabled = False
            myForm.Pnl_Valera.Enabled = False


            myForm.ShowDialog()
            Call InicializaGrid()
            Call RellenaGrid()

        Catch ExceptionErr As Exception
            MessageBox.Show("Seleccione un cliente porfavor, " & ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_DoubleClick(sender As Object, e As EventArgs) Handles DGrid.DoubleClick
        Try
            Dim Myform As New frmCatalogoValeras
            Dim Renglon As Point = DGrid.PointToClient(Control.MousePosition)
            Dim info As GridHitInfo = GridView1.CalcHitInfo(Renglon)

            Dim Renglon1 As Integer = info.RowHandle



            Myform.Accion = 3
            Myform.Text = Myform.Text + " (Consultar Valera)"
            'Myform.Txt_id.Text = GridView1.GetRowCellValue(Renglon1, "iddistrib")

            Myform.Txt_idDistrib.Text = GridView1.GetRowCellValue(Renglon1, "distrib")
            Myform.Txt_NombreDistrib.Text = GridView1.GetRowCellValue(Renglon1, "distribuidor")
            Myform.Txt_Valera.Text = GridView1.GetRowCellValue(Renglon1, "valera")
            Myform.Txt_ValeDesde.Text = GridView1.GetRowCellValue(Renglon1, "valeini")
            Myform.Txt_ValeHasta.Text = GridView1.GetRowCellValue(Renglon1, "valefin")
            Myform.Dt_Entrega.Text = GridView1.GetRowCellValue(Renglon1, "entrega")
            Myform.Txt_Recoge.Text = GridView1.GetRowCellValue(Renglon1, "recoge")
            Myform.Txt_Valera.Enabled = False

            Myform.Btn_Aceptar.Enabled = False
            Myform.Pnl_Valera.Enabled = False

            Myform.ShowDialog()

            If GLB_RefrescarPedido = True Then
                Call RellenaGrid()
            End If
            'Dim myForm As New frmCatalogoValeras
            'myForm.Text = myForm.Text + " (Consultar Valera)"

            'Dim valera As String = ""


            'For i As Integer = 0 To GridView1.RowCount - 1


            '    If GridView1.IsRowSelected(i) = True Then
            '        iddistrib = GridView1.GetRowCellValue(i, "iddistrib")
            '        distrib = GridView1.GetRowCellValue(i, "distrib")
            '        distribuidor = GridView1.GetRowCellValue(i, "distribuidor")
            '        valera = GridView1.GetRowCellValue(i, "valera")
            '        valeini = GridView1.GetRowCellValue(i, "valeini")
            '        valefin = GridView1.GetRowCellValue(i, "valefin")
            '        entrega = GridView1.GetRowCellValue(i, "entrega")
            '        recoge = GridView1.GetRowCellValue(i, "recoge")
            '    End If
            'Next

            'myForm.Accion = 3
            'myForm.Txt_Recoge.Text = recoge
            'myForm.Dt_Entrega.Text = entrega
            'myForm.Txt_ValeHasta.Text = valefin
            'myForm.Txt_ValeDesde.Text = valeini
            'myForm.Txt_idDistrib.Text = distrib
            'myForm.Txt_NombreDistrib.Text = distribuidor
            'myForm.Txt_Valera.Text = valera

            'myForm.Txt_Valera.Enabled = False

            'myForm.Btn_Aceptar.Enabled = False
            'myForm.Pnl_Valera.Enabled = False


            'myForm.ShowDialog()
            'Call InicializaGrid()
            'Call RellenaGrid()

        Catch ExceptionErr As Exception
            MessageBox.Show("Seleccione un cliente porfavor, " & ExceptionErr.Message.ToString)
        End Try
    End Sub
End Class