Imports DevExpress.DashboardCommon
Imports DevExpress.Utils
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.BandedGrid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid.Columns.GridColumn
Imports DevExpress.XtraGrid
Imports DevExpress.Utils.Paint
Public Class frmAnalisisfull
    Dim Sw_Load As Boolean = True
    Dim objDataSet As DataSet
    Dim FechaIni As String
    Dim FechaFin As String
    Dim Marca As String
    Dim MarcaFOTO As String
    Dim EstiloNFOTO As String
    Dim Modelo As String
    Dim caja2 As Label = New Label()
    Dim caja3 As Label = New Label()
    Dim caja4 As Label = New Label()
    Dim caja5 As Label = New Label()

    Public Sub Limpia()
        'objDataSet = Nothing
        'grido.DataSource = Nothing
        GridView1.Columns.Clear()
        Call RellenaGrid()
    End Sub

    Public Sub RellenaGrid()
        Using objRepetitivo As New BCL.BCLAnalisisfull(GLB_ConStringDwhSQL)
            Try
                Me.Cursor = Cursors.WaitCursor
                If Sw_Load = True Then

                Else

                End If

                objDataSet = objRepetitivo.usp_GeneraAnalisis(FechaIni, FechaFin, Marca, Modelo)
                If objDataSet.Tables(0).Rows.Count > 0 Then

                    grido.DataSource = objDataSet.Tables(0)
                    If Sw_Load = False Then
                        InicializaGrid()
                    End If
                    Me.Cursor = Cursors.Default
                Else
                    Me.Cursor = Cursors.Default
                    For j As Integer = 0 To GridView1.RowCount
                        For i As Integer = -1 To GridView1.RowCount
                            GridView1.DeleteRow(i)
                        Next
                    Next
                    MsgBox("No se encontrarón registros entre estas fechas, pruebe ingresando otras", MsgBoxStyle.Critical, "ERROR")
                    Exit Sub
                End If

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
            Call llenado()
            Me.Panel2.Controls.Remove(caja2)
            Me.Panel2.Controls.Remove(caja4)
            Me.Panel3.Controls.Remove(caja3)
            Me.Panel4.Controls.Remove(caja5)
            Call controles()
            Call controles2()
            Call controles3()
            Call CargarFotoArticulo(Marca, Modelo)
        End Using
    End Sub
    Private Sub InicializaGrid()
        Try
            GridView1.Columns(0).Caption = " Sucursal "
            GridView1.Columns(1).Caption = " Concepto "
            GridView1.Columns(2).Caption = " Fecha "
            GridView1.BestFitColumns()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub Colorea(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles GridView1.RowStyle
        Try
            Dim quantity As String = Convert.ToString(GridView1.GetRowCellValue(e.RowHandle, "Concepto"))
            GridView1.OptionsBehavior.Editable = False
            If quantity = "aaaa" Then
                e.Appearance.BackColor = Color.FromArgb(0, 0, 0)
                e.Appearance.ForeColor = Color.FromArgb(0, 0, 0)
                e.Appearance.BorderColor = Color.FromArgb(0, 0, 0)
                e.Appearance.Font = New Font(e.Appearance.Font.FontFamily, e.Appearance.Font.Size, FontStyle.Bold)
            End If
            If quantity = "STOCK INICIAL" Then
                e.Appearance.BackColor = Color.FromArgb(255, 242, 204)
                e.Appearance.Font = New Font(e.Appearance.Font.FontFamily, e.Appearance.Font.Size, FontStyle.Bold)
            End If
            If quantity = "STOCK FINAL" Then
                e.Appearance.BackColor = Color.FromArgb(255, 230, 153)
                e.Appearance.Font = New Font(e.Appearance.Font.FontFamily, e.Appearance.Font.Size, FontStyle.Bold)
            End If
            If quantity = "STOCK ACTUAL" Then
                e.Appearance.BackColor = Color.FromArgb(248, 203, 173)
                e.Appearance.Font = New Font(e.Appearance.Font.FontFamily, e.Appearance.Font.Size, FontStyle.Bold)
            End If
            If quantity = "VENTA EN EL PERIODO" Then
                e.Appearance.BackColor = Color.FromArgb(146, 208, 80)
                e.Appearance.Font = New Font(e.Appearance.Font.FontFamily, e.Appearance.Font.Size, FontStyle.Bold)
            End If
            If quantity = "PEND X RECIBIR" Then
                e.Appearance.BackColor = Color.FromArgb(222, 235, 247)
                e.Appearance.Font = New Font(e.Appearance.Font.FontFamily, e.Appearance.Font.Size, FontStyle.Bold)
            End If
            e.HighPriority = True
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub CargarFotoArticulo(ByVal Marca, ByVal Modelo)
        'mreyes 14/Marzo/2012 07:06 p.m.
        'Glb_RutaArchivoFotos
        Try
            Dim Archivo As String = ""
            Dim NoFoto As String = "1"
            MarcaFOTO = Marca
            EstiloNFOTO = Modelo
            Using objIO As New BCL.BCLio(GLB_ConStringCipSis)
                Archivo = objIO.pub_ArmarNombreFotoEstilo(GLB_RutaArchivoFotos, Marca, Modelo, NoFoto)
                If objIO.pub_ExisteArchivo(Archivo) = True Then
                    PictureBox1.Image = New System.Drawing.Bitmap(Archivo)
                    PictureBox1.Visible = True
                    Exit Sub
                End If
                For i As Integer = 0 To 9
                    Archivo = objIO.pub_ArmarNombreFotoEstilo(GLB_RutaArchivoFotos, Marca, Modelo, i)
                    If objIO.pub_ExisteArchivo(Archivo) = True Then
                        PictureBox1.Image = New System.Drawing.Bitmap(Archivo)
                        PictureBox1.Visible = True
                        Exit Sub
                    End If
                Next
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub PictureBox1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox1.DoubleClick
        'mreyes 03/Marzo/2012 10:01 a.m.
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
    Private Sub gridView1_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GridView1.CustomColumnDisplayText
        If Convert.ToString(e.Value) = "" Then
            e.DisplayText = 0
        End If
    End Sub
    Private Sub Gv_CustomDrawCell(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles GridView1.CustomDrawCell
        If e.RowHandle = GridControl.AutoFilterRowHandle Then
            e.DisplayText = ""
        End If
    End Sub
    Private Sub Colorea3(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles GridView1.RowStyle
        Dim quantity As String = Convert.ToString(GridView1.GetRowCellValue(e.RowHandle, "Concepto"))
        Dim quantity2 As String = Convert.ToString(GridView1.GetRowCellValue(e.RowHandle, "Sucursal"))
        If quantity = "aaaa" And quantity2 <> "" Then
            e.Appearance.BackColor = Color.FromArgb(0, 0, 0)
            e.Appearance.ForeColor = Color.FromArgb(0, 0, 0)
            e.Appearance.BorderColor = Color.Red
        End If
    End Sub
    Private Sub Colorea4(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles GridView1.RowStyle
        Dim quantity As String = Convert.ToString(GridView1.GetRowCellValue(e.RowHandle, "Concepto"))
        If quantity = "" And e.Appearance.BackColor = Color.White Then
            GridView1.SetRowCellValue(e.RowHandle, "", "")
        End If
    End Sub
    Private Sub frmAnalisisfulfill_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel3.BackColor = Color.FromArgb(188, 211, 232)
        Panel4.BackColor = Color.FromArgb(255, 235, 173)
        dtp_FechaIni.Value = Date.Now.AddDays(-1)
        dtp_FechaFin.Value = Date.Now.AddDays(-1)
        lbl_marca.Text = Marca
        lbl_modelo.Text = Modelo
        lbl_FechaIni.Text = ""
        lbl_FechaFin.Text = ""
        idML.Visible = False
        idAmazon.Visible = False
        Sw_Load = True
    End Sub

    Private Sub llenado()
        Using objAnalisis As New BCL.BCLAnalisisfull(GLB_ConStringDwhSQL)
            objDataSet = objAnalisis.usp_GeneraAnalisisdet(Marca, Modelo)
            'Populate the Project Details section
            If objDataSet.Tables(0).Rows.Count > 0 Then
                Descrip.Text = objDataSet.Tables(0).Rows(0).Item("descripc").ToString
                Estilof.Text = objDataSet.Tables(0).Rows(0).Item("estilof").ToString
            End If
        End Using
    End Sub
    Private Sub controles()
        Dim z As Integer = 19
        Dim d As Integer = 38
        '============================================================================================================================================================================
        Using objAnalisis As New BCL.BCLAnalisisfull(GLB_ConStringDwhSQL)
            objDataSet = objAnalisis.usp_GeneraAnalisisdet(Marca, Modelo)
            If objDataSet.Tables(2).Rows.Count > 0 Then
                For i As Integer = 0 To objDataSet.Tables(3).Rows.Count - 1
                    caja5 = New Label()
                    caja5.Size = New Size(280, 13)
                    caja5.Parent = Panel4
                    caja5.Font = New Font(caja5.Font.FontFamily, 8.5)
                    caja5.Text = objDataSet.Tables(3).Rows(i).Item("precio").ToString & "       " & objDataSet.Tables(3).Rows(i).Item("promocion").ToString & "             " & objDataSet.Tables(3).Rows(i).Item("margen").ToString
                    caja5.Location = New Point(4, d)
                    d += 20
                    Me.Panel4.Controls.Add(caja5)
                Next
            Else
                Exit Sub
            End If
        End Using
        '============================================================================================================================================================================
        Using objAnalisis As New BCL.BCLAnalisisfull(GLB_ConStringDwhSQL)
            objDataSet = objAnalisis.usp_GeneraAnalisisdet(Marca, Modelo)
            If objDataSet.Tables(1).Rows.Count > 0 Then
                For i As Integer = 0 To objDataSet.Tables(1).Rows.Count - 1
                    caja2 = New Label()
                    caja2.Size = New Size(280, 13)
                    caja2.Parent = Me.Panel2
                    caja2.Font = New Font(caja2.Font.FontFamily, 8.5)
                    caja2.Text = objDataSet.Tables(1).Rows(i).Item("corrida").ToString & "            " & objDataSet.Tables(1).Rows(i).Item("costo").ToString
                    caja2.Location = New Point(133, z)
                    z += 20
                    Me.Panel2.Controls.Add(caja2)
                Next
            Else
                Exit Sub
            End If
        End Using
    End Sub
    Private Sub controles2()
        Dim C As Integer = 38
        Using objAnalisis As New BCL.BCLAnalisisfull(GLB_ConStringDwhSQL)
            objDataSet = objAnalisis.usp_GeneraAnalisisdet(Marca, Modelo)
            If objDataSet.Tables(2).Rows.Count > 0 Then
                For i As Integer = 0 To objDataSet.Tables(1).Rows.Count - 1
                    caja3 = New Label()
                    caja3.Size = New Size(280, 13)
                    caja3.Parent = Panel3
                    caja3.Font = New Font(caja3.Font.FontFamily, 8.5)
                    caja3.Text = objDataSet.Tables(2).Rows(i).Item("precio").ToString & "       " & objDataSet.Tables(2).Rows(i).Item("promocion").ToString & "             " & objDataSet.Tables(2).Rows(i).Item("margen").ToString
                    caja3.Location = New Point(4, C)
                    C += 20
                    Me.Panel3.Controls.Remove(caja3)
                    Me.Panel3.Controls.Add(caja3)
                Next
            End If
        End Using
        objDataSet = Nothing
    End Sub
    Private Sub controles3()
        Dim f As Integer = 27
        Using objAnalisis As New BCL.BCLAnalisisfull(GLB_ConStringDwhSQL)
            objDataSet = objAnalisis.usp_GeneraAnalisisdet(Marca, Modelo)
            If objDataSet.Tables(3).Rows.Count > 0 Then
                For i As Integer = 0 To objDataSet.Tables(4).Rows.Count - 1
                    caja4 = New Label()
                    caja4.Size = New Size(280, 13)
                    caja4.Parent = Panel2
                    caja4.Font = New Font(caja4.Font.FontFamily, 8.5)
                    caja4.Text = ""
                    caja4.Text = objDataSet.Tables(4).Rows(i).Item("mlm").ToString
                    caja4.Location = New Point(948, f)
                    f += 20
                    idML.Visible = True
                    Me.Panel2.Controls.Add(caja4)
                Next
            Else
                idML.Visible = False
                Exit Sub
            End If
        End Using
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btn_refrescar.Click
        Call RellenaGrid()
    End Sub

    Private Sub frmAnalisisfulfill_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub idML_LinkClicked_1(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles idML.LinkClicked
        Using objAnalisis As New BCL.BCLAnalisisfull(GLB_ConStringDwhSQL)
            objDataSet = objAnalisis.usp_GeneraAnalisisdet(Marca, Modelo)
            If objDataSet.Tables(4).Rows.Count > 0 Then
                System.Diagnostics.Process.Start(objDataSet.Tables(4).Rows(0).Item("link").ToString)
            Else
                MsgBox("No hay publicaciones de este producto en Mercado Libre", MsgBoxStyle.Critical, "ERROR")
            End If
        End Using
    End Sub
    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles btn_filtro.Click
        Dim form As New frmFiltroAnalisisFull

        form.txt_marca.Text = Marca
        form.txt_estilon.Text = Modelo
        form.StartPosition = FormStartPosition.CenterScreen
        form.dtp_FechaIni.Value = dtp_FechaIni.Value
        form.dtp_FechaFin.Value = dtp_FechaFin.Value
        form.txt_descripmarca.Text = lbl_mard.Text

        form.ShowDialog()
        If form.tipo = 1 Then
            Exit Sub
        End If

        lbl_mard.Text = form.txt_descripmarca.Text
        dtp_FechaIni.Value = form.dtp_FechaIni.Value
        dtp_FechaFin.Value = form.dtp_FechaFin.Value
        FechaIni = form.dtp_FechaIni.Value.ToShortDateString
        FechaFin = form.dtp_FechaFin.Value.ToShortDateString

        If Len(form.txt_estilon.Text) = 1 Then
            Modelo = "      " & form.txt_estilon.Text
        ElseIf Len(form.txt_estilon.Text) = 2 Then
            Modelo = "     " & form.txt_estilon.Text
        ElseIf Len(form.txt_estilon.Text) = 3 Then
            Modelo = "    " & form.txt_estilon.Text
        ElseIf Len(form.txt_estilon.Text) = 4 Then
            Modelo = "   " & form.txt_estilon.Text
        ElseIf Len(form.txt_estilon.Text) = 5 Then
            Modelo = "  " & form.txt_estilon.Text
        ElseIf Len(form.txt_estilon.Text) = 6 Then
            Modelo = " " & form.txt_estilon.Text
        ElseIf Len(form.txt_estilon.Text) = 7 Then
            Modelo = form.txt_estilon.Text
        End If

        lbl_marca.Text = form.txt_marca.Text
        lbl_modelo.Text = form.txt_estilon.Text
        Marca = form.txt_marca.Text
        lbl_FechaIni.Text = form.dtp_FechaIni.Value.ToShortDateString
        lbl_FechaFin.Text = form.dtp_FechaFin.Value.ToShortDateString

        If form.tipo = 2 Then
            Call Limpia()
        End If
    End Sub

    Private Sub idAmazon_Click(sender As Object, e As EventArgs) Handles idAmazon.Click
        Using objAnalisis As New BCL.BCLAnalisisfull(GLB_ConStringDwhSQL)
            objDataSet = objAnalisis.usp_GeneraAnalisisdet(Marca, Modelo)
            System.Diagnostics.Process.Start(objDataSet.Tables(3).Rows(0).Item("link").ToString)
        End Using
    End Sub
End Class