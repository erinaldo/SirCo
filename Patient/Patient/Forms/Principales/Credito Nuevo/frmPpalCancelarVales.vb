Public Class frmPpalCancelarVales
    Private objDataSet As Data.DataSet


    Private Sub RellenarGrid()
        Using objCatalogoCancelarVales As New BCL.BCLCancelarVales(GLB_ConStringCreditoSQL)

            Try
                Me.Cursor = Cursors.WaitCursor
                Grid.DataSource = Nothing
                'Mandamos la opcion 2 como parametro para rellenar el Grid  
                objDataSet = objCatalogoCancelarVales.usp_MostrarCancelarVales(2, 0, "", "", "", 0, 0, 0, Date.Now)
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Grid.DataSource = objDataSet.Tables(0)

                    'Icializamos nuestro Grid para ver los datos 
                    InicializaGrid()
                    GridView1.BestFitColumns()

                    Me.Cursor = Cursors.Default
                Else
                    Me.Cursor = Cursors.Default
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

            GridView1.Columns("idusuario").Visible = False
            GridView1.Columns("idusuariomodif").Visible = False
            GridView1.Columns("idmotivo").Visible = False

            GridView1.Columns("iddistrib").Caption = "Distribuidor"
            GridView1.Columns("valera").Caption = "Valera"
            GridView1.Columns("valeini").Caption = "Valera Inicial"
            GridView1.Columns("valefin").Caption = "Valera Final"
            GridView1.Columns("idmotivo").Caption = "idmotivo"
            GridView1.Columns("motivo").Caption = "motivo"
            GridView1.Columns("idusuario").Caption = "idusuario"
            GridView1.Columns("entrega").Caption = "entrega"
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

    Private Sub Btn_Cancelar_Click(sender As Object, e As EventArgs) Handles Btn_Cancelar.Click
        Dim myForm As New frmCatalogoCancelarVentas
        myForm.opcion = 1
        myForm.Txt_Motivo.Enabled = False
        myForm.Dt_FechaEntrega.Enabled = False
        myForm.ShowDialog()
        Call RellenarGrid()
        Call InicializaGrid()
    End Sub

    Private Sub Grid_DoubleClick(sender As Object, e As EventArgs) Handles Grid.DoubleClick
        Dim myForm As New frmCatalogoCancelarVentas

        Dim iddistrib As Integer = 0
        Dim valera As String = ""
        Dim valeini As String = ""
        Dim valefin As String = ""
        Dim idmotivo As Integer = 0
        Dim motivo As String = ""
        Dim idusuario As Integer = 0
        Dim entrega As Date
        Dim fum As Date
        Dim idusuariomodif As Integer = 0
        Dim fummodif As Date

        For i As Integer = 0 To GridView1.RowCount - 1


            If GridView1.IsRowSelected(i) = True Then
                iddistrib = GridView1.GetRowCellValue(i, "iddistrib")
                valera = GridView1.GetRowCellValue(i, "valera")
                valeini = GridView1.GetRowCellValue(i, "valeini")
                valefin = GridView1.GetRowCellValue(i, "valefin")
                idmotivo = GridView1.GetRowCellValue(i, "idmotivo")
                motivo = GridView1.GetRowCellValue(i, "motivo")
                idusuario = GridView1.GetRowCellValue(i, "idusuario")
                entrega = GridView1.GetRowCellValue(i, "entrega")
                fum = GridView1.GetRowCellValue(i, "fum")
                idusuariomodif = GridView1.GetRowCellValue(i, "idusuariomodif")
                fummodif = GridView1.GetRowCellValue(i, "fummodif")
            End If
        Next

        'myForm.getRow(iddistrib)
        myForm.Txt_Distri.Text = iddistrib
        myForm.Txt_Inicio.Text = valeini
        myForm.Txt_Fin.Text = valefin
        myForm.Txt_Folio1.Text = valera
        myForm.Dt_FechaEntrega.Text = entrega
        myForm.Txt_Motivo.Text = motivo



        myForm.Txt_Inicio.Enabled = False
        myForm.Txt_Fin.Enabled = False
        myForm.Txt_Folio1.Enabled = False
        myForm.Txt_Distri.Enabled = False
        myForm.Dt_FechaEntrega.Enabled = False
        myForm.Txt_Motivo.Enabled = False
        myForm.btn_Aceptar.Enabled = False
        myForm.btn_Limpiar.Enabled = False



        myForm.ShowDialog()
        Call InicializaGrid()
    End Sub

    Private Sub Btn_Consultar_Click(sender As Object, e As EventArgs) Handles Btn_Consultar.Click
        Dim myForm As New frmCatalogoCancelarVentas

        Dim iddistrib As Integer = 0
        Dim valera As String = ""
        Dim valeini As String = ""
        Dim valefin As String = ""
        Dim idmotivo As Integer = 0
        Dim motivo As String = ""
        Dim idusuario As Integer = 0
        Dim entrega As Date
        Dim fum As Date
        Dim idusuariomodif As Integer = 0
        Dim fummodif As Date

        For i As Integer = 0 To GridView1.RowCount - 1


            If GridView1.IsRowSelected(i) = True Then
                iddistrib = GridView1.GetRowCellValue(i, "iddistrib")
                valera = GridView1.GetRowCellValue(i, "valera")
                valeini = GridView1.GetRowCellValue(i, "valeini")
                valefin = GridView1.GetRowCellValue(i, "valefin")
                idmotivo = GridView1.GetRowCellValue(i, "idmotivo")
                motivo = GridView1.GetRowCellValue(i, "motivo")
                idusuario = GridView1.GetRowCellValue(i, "idusuario")
                entrega = GridView1.GetRowCellValue(i, "entrega")
                fum = GridView1.GetRowCellValue(i, "fum")
                idusuariomodif = GridView1.GetRowCellValue(i, "idusuariomodif")
                fummodif = GridView1.GetRowCellValue(i, "fummodif")
            End If
        Next

        'myForm.getRow(iddistrib)
        myForm.Txt_Distri.Text = iddistrib
        myForm.Txt_Inicio.Text = valeini
        myForm.Txt_Fin.Text = valefin
        myForm.Txt_Folio1.Text = valera
        myForm.Dt_FechaEntrega.Text = entrega
        myForm.Txt_Motivo.Text = motivo



        myForm.Txt_Inicio.Enabled = False
        myForm.Txt_Fin.Enabled = False
        myForm.Txt_Folio1.Enabled = False
        myForm.Txt_Distri.Enabled = False
        myForm.Dt_FechaEntrega.Enabled = False
        myForm.Txt_Motivo.Enabled = False
        myForm.btn_Aceptar.Enabled = False
        myForm.btn_Limpiar.Enabled = False



        myForm.ShowDialog()
        Call InicializaGrid()
    End Sub

    Private Sub frmPpalCancelarVales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RellenarGrid()
    End Sub

    Private Sub Btn_Refrescar_Click(sender As Object, e As EventArgs) Handles Btn_Refrescar.Click
        RellenarGrid()
    End Sub
End Class