Imports DevExpress.DashboardCommon
Imports DevExpress.Utils
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.BandedGrid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid.Columns.GridColumn
Imports DevExpress.XtraEditors
Imports System
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraReports.UI
Public Class frm_Lineo
    Private objDataSet As DataSet
    Private objDataSet1 As DataSet
    Private Sub frm_Lineo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call RellenarGrido()
        Call GenerarToolTip()
    End Sub

    Private Sub RellenarGrido()
        'Rafael Saucedo - 04/Agosto/2020 - 7:37 p.m.
        Using objTrasp As New BCL.BCLLineo(GLB_ConStringSirCoVentaEnLineaSQL)
            Try
                Me.Cursor = Cursors.WaitCursor
                Grido.DataSource = Nothing
                objDataSet = objTrasp.usp_TraerLineo()
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Grido.DataSource = objDataSet.Tables(0)
                    Me.Cursor = Cursors.Default
                    If GridView1.Columns.Count > 0 Then
                        InicializarGrido()
                    End If
                End If
                    Me.Cursor = Cursors.Default
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub
    Private Sub GenerarToolTip()
        Try
            ToolTip1.SetToolTip(Btn_excel, "Exportar a Excel")
            ToolTip1.SetToolTip(Btn_rfsh, "Refrescar")
            ToolTip1.SetToolTip(Btn_ex, "Salir")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub InicializarGrido()
        Try
            GridView1.Columns(0).Caption = "Nombre"
            GridView1.Columns(1).Caption = "Marca"
            GridView1.Columns(2).Caption = "Modelo"
            GridView1.Columns(3).Caption = "Descripción"
            GridView1.Columns(4).Caption = "Destacados"
            GridView1.Columns(5).Caption = "Color"
            GridView1.Columns(6).Caption = "País de producción"
            GridView1.Columns(7).Caption = "Medidas del producto"
            GridView1.Columns(8).Caption = "Peso del producto"
            GridView1.Columns(9).Caption = "Categoría primaria"
            GridView1.Columns(10).Caption = "Categoría adicional 1"
            GridView1.Columns(11).Caption = "Categoría adicional 2"
            GridView1.Columns(12).Caption = "Categoría adicional 3"
            GridView1.Columns(13).Caption = "Precio"
            GridView1.Columns(14).Caption = "Precio de descuento"
            GridView1.Columns(15).Caption = "Fecha inicial del descuento"
            GridView1.Columns(16).Caption = "Fecha final del descuento"
            GridView1.Columns(17).Caption = "SKU del vendedor"
            GridView1.Columns(18).Caption = "SKU padre"
            GridView1.Columns(19).Caption = "Variacion"
            GridView1.Columns(20).Caption = "Codigo de barras"
            GridView1.Columns(21).Caption = "Cantidad"
            GridView1.Columns(22).Caption = "Estilo"
            GridView1.Columns(23).Caption = "Genero"
            GridView1.Columns(24).Caption = "Material pincipal"
            GridView1.Columns(25).Caption = "Color principal"
            GridView1.Columns(26).Caption = "Tipo Reloj"
            GridView1.Columns(27).Caption = "Box Shape"
            GridView1.Columns(28).Caption = "Belt Material"
            GridView1.Columns(29).Caption = "Calendar"
            GridView1.Columns(30).Caption = "Condicion del producto"
            GridView1.Columns(31).Caption = "Detalles de la condicion"
            GridView1.Columns(32).Caption = "Tiempo de garantía"
            GridView1.Columns(33).Caption = "Garantía"
            GridView1.Columns(34).Caption = "Alto del paquete"
            GridView1.Columns(35).Caption = "Ancho del paquete"
            GridView1.Columns(36).Caption = "Largo del paquete"
            GridView1.Columns(37).Caption = "Peso del paquete"
            GridView1.Columns(38).Caption = "Contenido del paquete"
            GridView1.Columns(39).Caption = "Impuestos"
            GridView1.Columns(40).Caption = "Contenido"
            GridView1.Columns(41).Caption = "Tiecket Number"
            GridView1.Columns(42).Caption = "Imagen 1"
            GridView1.Columns(43).Caption = "Imagen 2"
            GridView1.Columns(44).Caption = "Imagen 3"
            GridView1.Columns(45).Caption = "Imagen 4"
            GridView1.Columns(46).Caption = "Imagen 5"
            GridView1.Columns(47).Caption = "Imagen 6"
            GridView1.Columns(48).Caption = "Imagen 7"
            GridView1.Columns(49).Caption = "Imagen 8"
            GridView1.BestFitColumns()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Btn_excel.Click
        Try
            If SFdRuta.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                Dim path As String = SFdRuta.FileName
                GridView1.ExportToXlsx(path)
                ' Open the created XLSX file with the default application.
                Process.Start(path)
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Btn_rfsh.Click
        Call RellenarGrido()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Btn_ex.Click
        Me.Close()
    End Sub

    Private Sub frm_Lineo_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub
End Class