'mreyes 12/Marzo/2019   10:12 a.m. UN LOGRO, EMPEZAMOS PUNTO DE VENTA, URRA... URRAA!!!!
Imports DevExpress.XtraGrid.Views.Grid
Imports System.Text.RegularExpressions
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Windows.Forms
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid

Public Class frmPuntoVenta


    Private tblProducto As New DataTable
    Private dt As DataTable
    Dim NoArticulo As Integer = 0
    Dim Total As Decimal = 0
    Dim Subtotal As Decimal = 0
    Dim Descuento As Decimal = 0

    Private Sub frmPuntoVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            GLB_Sucursal = "MATRIZ"
            GLB_CveSucursal = "08"

            Lbl_Sucursal.Text = GLB_CveSucursal & " " & GLB_Sucursal



            ' HORA TIMER 
            Lbl_Fum.Text = String.Format("{0:HH:mm:ss}", DateTime.Now) & " " & GLB_FechaHoy
            TFum.Interval = 1000  ' Un segundo
            TFum.Start()

            Call usp_CrearGrid()

            Dim myForm As New frmFirmaPV

            myForm.StartPosition = FormStartPosition.CenterParent
            myForm.ShowDialog()




        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub usp_CrearGrid()
        Try
            tblProducto.Columns.Add("Ren")
            tblProducto.Columns.Add("Marca")
            tblProducto.Columns.Add("Modelo")
            tblProducto.Columns.Add("Talla")
            tblProducto.Columns.Add("Precio")
            tblProducto.Columns.Add("Descuento")
            tblProducto.Columns.Add("Final")
            tblProducto.Columns.Add("Serie")


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub InicializaGrid()
        'mreyes 21/Marzo/2019   12:08 p.m.
        Try
            GridView1.Columns(0).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns(1).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns(2).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns(3).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns(4).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns(5).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns(6).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns(7).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center


            GridView1.Columns(0).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns(1).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns(2).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns(3).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

            GridView1.Columns(4).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns(5).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns(6).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center


            'GridView1.Columns(5).AppearanceCell.BackColor = Color.Red
            'GridView1.Columns(5).AppearanceCell.BackColor2 = Color.Pink

            GridView1.Columns(5).AppearanceCell.ForeColor = Color.Red
            GridView1.Columns(6).AppearanceCell.ForeColor = Color.Blue


            GridView1.Columns(7).Visible = False
            GridView1.Columns(0).Visible = False

            GridView1.Columns(4).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            GridView1.Columns(4).DisplayFormat.FormatString = "#,###,###"

            GridView1.Columns(5).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            GridView1.Columns(5).DisplayFormat.FormatString = "#,###,###"

            GridView1.Columns(6).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            GridView1.Columns(6).DisplayFormat.FormatString = "#,###,###"

            GridView1.Columns(1).AppearanceCell.Font = New Font("Tahoma", 11, FontStyle.Bold)
            GridView1.Columns(2).AppearanceCell.Font = New Font("Tahoma", 11, FontStyle.Bold)
            GridView1.Columns(3).AppearanceCell.Font = New Font("Tahoma", 11, FontStyle.Bold)
            GridView1.Columns(4).AppearanceCell.Font = New Font("Tahoma", 11, FontStyle.Bold)
            GridView1.Columns(5).AppearanceCell.Font = New Font("Tahoma", 11, FontStyle.Bold)
            GridView1.Columns(6).AppearanceCell.Font = New Font("Tahoma", 11, FontStyle.Bold)
            GridView1.Columns(7).AppearanceCell.Font = New Font("Tahoma", 1112, FontStyle.Bold)



            GridView1.ClearSorting()

            GridView1.Columns("Ren").SortOrder = DevExpress.Data.ColumnSortOrder.Descending


            'GridView1.OptionsView.ColumnAutoWidth = False
            'GridView1.OptionsView.BestFitMaxRowCount = -1
            'GridView1.BestFitColumns()




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


            Pbox_Articulo.Visible = False
            Using objIO As New BCL.BCLio(GLB_ConStringCipSis)

                Archivo = objIO.pub_ArmarNombreFotoEstilo(GLB_RutaArchivoFotos, Marca, Estilon, NoFoto)

                If objIO.pub_ExisteArchivo(Archivo) = True Then
                    Pbox_Articulo.Image = New System.Drawing.Bitmap(Archivo)
                    Pbox_Articulo.Visible = True
                    Exit Sub
                End If

                For i As Integer = 0 To 9
                    Archivo = objIO.pub_ArmarNombreFotoEstilo(GLB_RutaArchivoFotos, Marca, Estilon, i)
                    If objIO.pub_ExisteArchivo(Archivo) = True Then
                        Pbox_Articulo.Image = New System.Drawing.Bitmap(Archivo)
                        Pbox_Articulo.Visible = True
                        Exit Sub
                    End If
                Next

            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub Pnl_Pie_Paint(sender As Object, e As PaintEventArgs) Handles Pnl_Pie.Paint

    End Sub

    Private Sub TFum_Tick(sender As Object, e As EventArgs) Handles TFum.Tick
        Lbl_Fum.Text = String.Format("{0:HH:mm:ss}", DateTime.Now) & " " & GLB_FechaHoy
    End Sub

    Private Sub DGrid_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub DGrid_KeyDown(sender As Object, e As KeyEventArgs)

    End Sub

    Private Sub GridView1_KeyDown(sender As Object, e As KeyEventArgs)
        Try
            If e.KeyCode = Windows.Forms.Keys.Delete Then
                If MsgBox("Desea elimina el registro?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                    'Dim concepto As String = (View.GetRowCellDisplayText(e.RowHandle, View.Columns("concepto")))
                    'Marca = GridView3.GetFocusedRowCellValue("marca") & ""
                    'Estilof = GridView3.GetFocusedRowCellValue("estilof") & ""

                    'Using objBultos As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoAppSQL)
                    '    Guardo = objBultos.usp_Captura_Muestrasdet(3, IdMuestrasB, Marca, Estilof, "", "", "", 0, 0, Nothing, GLB_Idempleado)
                    'End Using
                    'Call rellenagrid

                End If
            End If


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Msk_Serie_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs)

    End Sub





    Private Sub Button1_Click(sender As Object, e As EventArgs)


        Dim dr1 As DataRow = tblProducto.NewRow()

        dr1(0) = "Marca"
        dr1(1) = "Modelo"
        dr1(2) = "Talla"
        dr1(3) = "Precio"
        dr1(4) = "Descuento"
        dr1(5) = "Final"
        dr1(6) = "Serie"
        tblProducto.Rows.Add(dr1)
        DGrid.DataSource = tblProducto





    End Sub



    Private Sub Txt_Serie_LostFocus(sender As Object, e As EventArgs) Handles Txt_Serie.LostFocus
        'mreyes 21/Marzo/2019   11:49 a.m.
        'Estatus en caja 
        'AC / IF = VENTA
        'TR = TRASPASO
        'DV = DEVOLUCIÓN, NO PASADA PARA AMARRE, SE PUEDE VENDER.
        'NM = NO VENDER ESTA EN NOTA MANUAL
        'BA = BAJA NO VENDER

        Dim Serie As String = ""



        If Txt_Serie.Text = "" Then Exit Sub




        Serie = Txt_Serie.Text

        Dim objDataSet As Data.DataSet


        Try
            Using objArticulos As New BCL.BCLPuntoVenta(GLB_ConStringSirCoPVSQL)
                objDataSet = objArticulos.usp_TraerSeriePV(Serie)

                If objDataSet.Tables(0).Rows.Count > 0 Then

                    'Checar si es de la sucursal



                    If objDataSet.Tables(0).Rows(0).Item("sucursal") <> GLB_CveSucursal Then
                        MsgBox("Serie no pertenece a la sucural " & GLB_Sucursal & ".", MsgBoxStyle.Critical, "Error")

                        Txt_Serie.Text = ""
                        Txt_Serie.Focus()

                        Exit Sub
                    End If

                    If objDataSet.Tables(0).Rows(0).Item("status") <> "AC" And objDataSet.Tables(0).Rows(0).Item("status") <> "IF" Then
                        MsgBox("Serie se encuentra en estatus  " & objDataSet.Tables(0).Rows(0).Item("status") & ".", MsgBoxStyle.Critical, "Error")
                        Txt_Serie.Text = ""
                        Txt_Serie.Focus()

                        Exit Sub
                    End If

                    Dim dr1 As DataRow = tblProducto.NewRow()


                    NoArticulo = NoArticulo + 1

                    dr1("Ren") = NoArticulo
                    dr1("Marca") = objDataSet.Tables(0).Rows(0).Item("marca")
                    dr1("Modelo") = objDataSet.Tables(0).Rows(0).Item("estilon")
                    dr1("Talla") = objDataSet.Tables(0).Rows(0).Item("medida")
                    dr1("Precio") = objDataSet.Tables(0).Rows(0).Item("precio")
                    dr1("Descuento") = objDataSet.Tables(0).Rows(0).Item("descuento")
                    dr1("Final") = objDataSet.Tables(0).Rows(0).Item("final")
                    dr1("Serie") = objDataSet.Tables(0).Rows(0).Item("serie")


                    tblProducto.Rows.Add(dr1)
                    DGrid.DataSource = tblProducto


                    Total = Total + objDataSet.Tables(0).Rows(0).Item("final")
                    Subtotal = Subtotal + objDataSet.Tables(0).Rows(0).Item("precio")
                    Descuento = Descuento + objDataSet.Tables(0).Rows(0).Item("descuento")

                    InicializaGrid()

                End If
                Call CargarFotoArticulo(objDataSet.Tables(0).Rows(0).Item("marca"), objDataSet.Tables(0).Rows(0).Item("estilon"))
                Txt_Serie.Text = ""

                Txt_Subtotal.Text = Subtotal
                Txt_Descuento.Text = Descuento
                Txt_Total.Text = Total



                Txt_Serie.Focus()
            End Using


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_Click_1(sender As Object, e As EventArgs) Handles DGrid.Click

    End Sub

    Private Sub Txt_Serie_EditValueChanged(sender As Object, e As EventArgs) Handles Txt_Serie.EditValueChanged

    End Sub

    Private Sub Btn_Comprar_Click(sender As Object, e As EventArgs) Handles Btn_Comprar.Click

        Dim myForm As New frmFormasPagoPV
        If CDbl(Txt_Total.Text) > 0 Then
            myForm.StartPosition = FormStartPosition.CenterParent
            myForm.Txt_Descuento.Text = Txt_Descuento.Text
            myForm.Txt_Subtotal.Text = Txt_Subtotal.Text
            myForm.Txt_Total.Text = Txt_Total.Text

            myForm.ShowDialog()
        Else
            MsgBox("No se han escaneado productos.", MsgBoxStyle.Critical, "Error")
        End If

    End Sub

    Private Sub frmPuntoVenta_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        GLB_FormPuntoVenta = False
    End Sub

    Private Sub frmPuntoVenta_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        GLB_FormPuntoVenta = False
    End Sub


    'Protected Overrides Sub OnLoad(e As EventArgs)
    '    MyBase.OnLoad(e)
    '    Me.BeginInvoke(New MethodInvoker(AddressOf FocusTextEdit))
    'End Sub
End Class