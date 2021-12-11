Imports System.IO
Imports DevExpress.XtraGrid.Views.Grid
Imports System.Text.RegularExpressions
Imports System.Drawing.Drawing2D

Imports System.Drawing.Imaging
Imports LibPrintTicketMatriz.Class1


Public Class frmPpalMuestras
    Private IdMuestrasB As Integer = 0
    Private ProveedorB As String = ""
    Private IdProveedorB As String = ""
    Private Sw_MuestrasMarcaB As Boolean = False
    Private Sw_EncontroMuestrasMarca As Boolean = False
    Dim RenglonB As Integer = 0
    Dim ColumnaB As String = ""
    Dim Sw_Load As Boolean = False
    Dim Sw_Entro As Boolean = False

    Private Sub frmPpalMuestras_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'MuestrasDetDataSet.muestrasdet' Puede moverla o quitarla según sea necesario.
        '   Me.MuestrasdetTableAdapter.Fill(Me.MuestrasDetDataSet.muestrasdet)

        Sw_Load = True

    End Sub



    Private Sub GridView3_KeyDown(sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridView3.KeyDown
        '' ELIMINAR REGISTRO DE GRID
        'mreyes 06/Septiembre/2017
        Try
            Dim Guardo As Boolean = False
            Dim Marca As String = ""
            Dim Estilof As String = ""
            Dim Intervalo As String = ""
            Dim MedIni As String = ""
            Dim MedFin As String = ""
            Dim Descrip As String = ""
            Dim Costo As Decimal = 0.0
            Dim Precio As Decimal = 0.0
            Dim PrecioLista As Decimal = 0.0


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
            If e.KeyCode = Windows.Forms.Keys.F4 Then
                If Pnl_Principal.Visible = True Then
                    Pnl_Principal.Visible = False
                Else
                    Pnl_Principal.Visible = True
                End If
            End If
            '  Dim bytBLOBData() As Byte
            ' Dim stmBLOBData As New MemoryStream(bytBLOBData)



            If e.KeyCode = Windows.Forms.Keys.F5 Then
                '' guardar 
                ''mreyes    20/Septiembre/2017  10:42 a.m.

                For renglon As Integer = 0 To GridView3.RowCount - 1
                    Estilof = GridView3.GetRowCellValue(renglon, "estilof")
                    Intervalo = GridView3.GetRowCellValue(renglon, "i")
                    Descrip = GridView3.GetRowCellValue(renglon, "descrip")
                    PrecioLista = GridView3.GetRowCellValue(renglon, "preciolista")
                    Costo = GridView3.GetRowCellValue(renglon, "costo")
                    Precio = GridView3.GetRowCellValue(renglon, "precio")

                    '  bytBLOBData = GridView3.GetRowCellValue(renglon, "imagen")


                    'PBox1.Image = GridView3.GetRowCellValue(renglon, "imagen")
                    'Dim ms As New MemoryStream
                    'PBox1.Image.Save(ms, PBox1.Image.RawFormat)
                    'Dim arrImage() As Byte = ms.GetBuffer


                    'Dim bytBLOBData() As Byte = objDataSet1.Tables(0).Rows(0).Item("tarjeta")
                    'Dim stmBLOBData As New MemoryStream(bytBLOBData)
                    'PBox1.Image = Image.FromStream(stmBLOBData)


                    'Dim bytBLOBData() As Byte = GridView3.GetRowCellValue(renglon, "imagen")
                    'Dim stmBLOBData As New MemoryStream(bytBLOBData)
                    'PBox1.Image = Image.FromStream(stmBLOBData)

                    Using objBultos As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoAppSQL)
                        Guardo = objBultos.usp_Captura_Muestrasdet(1, IdMuestrasB, Txt_Marca.Text, Estilof, Descrip, 0, "", 0, "", 0, "", 0, "", 0, "", 0, "", 0, "", 0, "", 0, "", 0, "", Intervalo, MedIni, MedFin, PrecioLista, Costo, Precio, GridView3.GetRowCellValue(renglon, "imagen"), GLB_Idempleado)
                    End Using
                Next
                'Call RellenaGrid()

            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    'Private Sub RellenaGrid()
    '    Dim arrFilename() As String = Split(Text, "\")
    '    Array.Reverse(arrFilename)
    '    Dim ms As New MemoryStream
    '    PBox1.Image.Save(ms, PBox1.Image.RawFormat)
    '    Dim arrImage() As Byte = ms.GetBuffer
    '    Dim objDataSet As Data.DataSet

    '    Using objArticulos As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoAppSQL)
    '        Try

    '            objDataSet = objArticulos.usp_PpalMuestrasdet(4, IdMuestrasB, "", "", "", "", "", 0, 0, arrImage, GLB_Idempleado)


    '            Me.Cursor = Cursors.Default

    '            If objDataSet.Tables(0).Rows.Count > 0 Then
    '                GridControl3.DataSource = objDataSet.Tables(0)
    '                'Me.Pnl_Imagenes.HorizontalScroll.Visible = True
    '            Else
    '                'Me.Pnl_Img.Controls.Clear()
    '                'PBar.Value = 0
    '                'Txt_Porc.Text = ""
    '                MessageBox.Show("No se encontraron artículos relacionados.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '            End If



    '        Catch ExceptionErr As Exception
    '            MessageBox.Show(ExceptionErr.Message.ToString)
    '        End Try
    '    End Using
    'End Sub

    'Private Sub GridView3_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles GridView3.RowUpdated
    '    'ACTUALIZAR O MODIFICAR UN REGISTRO


    'End Sub

    Private Sub Btn_NuevoF_Click(sender As Object, e As EventArgs) Handles Btn_NuevoF.Click
        'mreyes 05/Septiembre/2017  10:55 a.m.
        Try
            Dim Ruta As String = ""
            OpenFileDialog.Filter = "img files (*.jpg)|*.jpg|All files (*.*)|*.*"
            OpenFileDialog.FileName = ""
            OpenFileDialog.ShowDialog()

            If OpenFileDialog.FileName = "" Then Exit Sub
            PBox1.Image = New System.Drawing.Bitmap(OpenFileDialog.FileName)
            Ruta = OpenFileDialog.FileName
            'If Ruta.Length > 0 Then
            '    Btn_AceptarF.Enabled = True

            'End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Aceptar_Click(sender As Object, e As EventArgs) Handles Btn_Aceptar.Click
        'mreyes 06/Septiembre/20107 09:54 a.m.
        Try
            Dim Guardo As Boolean
            Dim arrFilename() As String = Split(Text, "\")
            Array.Reverse(arrFilename)
            Dim ms As New MemoryStream
            PBox1.Image.Save(ms, PBox1.Image.RawFormat)
            Dim arrImage() As Byte = ms.GetBuffer
            Dim objDataSet As Data.DataSet

            '' Traer el id muestras 

            Using objArticulos As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoAppSQL)
                objDataSet = objArticulos.usp_TraerIdMuestras

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    IdMuestrasb = Val(objDataSet.Tables(0).Rows(0).Item("idmuestras")) + 1
                End If
            End Using
            ''termina traer id muestra 

            Using objBultos As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoAppSQL)
                Guardo = objBultos.usp_Captura_Muestras(1, IdMuestrasB, Txt_Marca.Text, GLB_FechaHoy, "CA", ProveedorB, Val(Txt_Dscto.Text), Val(Txt_Plazo.Text), Val(Txt_Remision.Text), GLB_Idempleado, 0, 0)
            End Using

            '' guardar marca temporal si es nueva.
            If Sw_MuestrasMarcaB = True Then

                Using objBultos As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoAppSQL)
                    Guardo = objBultos.usp_Captura_MuestrasMarca(1, Txt_Marca.Text, Txt_DescripMarca.Text, Txt_Raz_Social.Text, Txt_Vendedor.Text, arrImage, "", GLB_Idempleado)
                End Using
            End If
            Pnl_Principal.Visible = False
            GridControl3.Visible = True
                Btn_Aceptar.Enabled = False
            GridControl3.Enabled = True
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub TxtLostfocus(ByVal Txt_Campo As TextBox, ByVal Txt_Campo1 As TextBox, ByVal Tipo As String)
        Try
            'mreyes 28/Febrero/2012 10:25 a.m.
            Dim objDataSet As Data.DataSet
            Dim objDataSet1 As Data.DataSet
            Dim Imagen As Image = PBox1.Image

            Dim arrFilename() As String = Split(Text, "\")
            Array.Reverse(arrFilename)
            Dim ms As New MemoryStream
            'PBox1.Image = Btn_Aceptar.Image

            PBox1.Image.Save(ms, PBox1.Image.RawFormat)

            Dim arrImage() As Byte = ms.GetBuffer



            Dim myForm As New frmConsulta
            If Txt_Campo.Text.Length = 0 Then Exit Sub
            Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringCipSis)
                Try
                    objDataSet = objMySqlGral.usp_TraerDescripcion(Tipo, Txt_Campo.Text, "")
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        Txt_Campo1.Text = objDataSet.Tables(0).Rows(0).Item("campo").ToString
                    Else
                        If Tipo = "M" Then
                            '' BUSCAR EN MARCASMUESTRAS ... 
                            Using objArticulos As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoAppSQL)
                                objDataSet1 = objArticulos.usp_PpalMuestrasMarca(6, Txt_Marca.Text, "", "", "", arrImage, "", GLB_Idempleado)


                                If objDataSet1.Tables(0).Rows.Count > 0 Then
                                    'IdMuestrasB = Val(objDataSet1.Tables(0).Rows(0).Item("idmuestras")) + 1
                                    Txt_DescripMarca.Text = objDataSet1.Tables(0).Rows(0).Item("nombre") & ""
                                    Txt_Raz_Social.Text = objDataSet1.Tables(0).Rows(0).Item("raz_soc") & ""
                                    Txt_Vendedor.Text = objDataSet1.Tables(0).Rows(0).Item("raz_soc") & ""
                                    Txt_Plazo.Text = objDataSet1.Tables(0).Rows(0).Item("plazo")
                                    Txt_Dscto.Text = objDataSet1.Tables(0).Rows(0).Item("dscto") & ""
                                    Txt_Remision.Text = objDataSet1.Tables(0).Rows(0).Item("remision") & ""

                                    Dim bytBLOBData() As Byte = objDataSet1.Tables(0).Rows(0).Item("tarjeta")
                                    Dim stmBLOBData As New MemoryStream(bytBLOBData)
                                    PBox1.Image = Image.FromStream(stmBLOBData)
                                    'PBox1.Image = objDataSet1.Tables(0).Rows(0).Item("tarjeta")

                                    Txt_DescripMarca.Enabled = False
                                    Txt_Raz_Social.Enabled = False
                                    'Txt_Vendedor.Enabled = False
                                    sw_EncontroMuestrasMarca = True
                                Else
                                    Sw_MuestrasMarcaB = True


                                    Txt_DescripMarca.Enabled = True
                                    Txt_DescripMarca.ReadOnly = False
                                    Txt_DescripMarca.Focus()
                                    Exit Sub
                                End If
                            End Using

                        End If
                        'Txt_Campo.Text = ""
                        'myForm.Tipo = Tipo
                        'myForm.ShowDialog()
                        'Txt_Campo.Text = myForm.Campo
                        'Txt_Campo1.Text = myForm.Campo1
                        'If Txt_Campo.Text.Length = 0 Then
                        '    Txt_Campo.Focus()
                        'End If
                    End If
                    ' PBox1.Image = Nothing
                Catch ExceptionErr As Exception
                    MessageBox.Show(ExceptionErr.Message.ToString)
                End Try

            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub Txt_Marca_LostFocus(sender As Object, e As EventArgs) Handles Txt_Marca.LostFocus
        'mreyes 06/Septiembre/2017  04:26 p.m.

        Dim objDataSet As Data.DataSet

        Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringCipSis)
            If Txt_Marca.Text.Length = 0 Then
                Txt_DescripMarca.Text = ""
                Exit Sub
            End If
            Try
                'Get the specific project selected in the ListView control
                If Txt_Marca.Text.Trim.Length < 3 Then
                    Txt_Marca.Text = pub_RellenarIzquierda(Txt_Marca.Text.Trim, 3)
                End If
                Call TxtLostfocus(Txt_Marca, Txt_DescripMarca, "M")

                If Txt_DescripMarca.Enabled = False Then
                    'If Sw_MuestrasMarcaB = True Then
                    '' checar el proveedor
                    If Txt_Raz_Social.Text = "" Then
                        Using objProveedores As New BCL.BCLCatalogoProveedores(GLB_ConStringCipSis)
                            objDataSet = objProveedores.usp_TraerProveedor("", Txt_Marca.Text)

                            If objDataSet.Tables(0).Rows.Count = 1 Then

                                If objDataSet.Tables(0).Rows(0).Item("status").ToString = "BA" Then
                                    If MsgBox("El proveedor se encuentra dado de BAJA.", MsgBoxStyle.Exclamation, "Datos Proveedor") Then Exit Sub
                                End If



                                ProveedorB = Val(objDataSet.Tables(0).Rows(0).Item("proveedor"))
                                Txt_Vendedor.Text = objDataSet.Tables(0).Rows(0).Item("agente").ToString

                                Txt_Raz_Social.Text = objDataSet.Tables(0).Rows(0).Item("raz_soc").ToString
                                Txt_Plazo.Text = Val(objDataSet.Tables(0).Rows(0).Item("diaspp"))

                                Txt_Dscto.Text = Val(objDataSet.Tables(0).Rows(0).Item("dsctopp"))
                                Btn_NuevoF.Visible = False
                                ' PBox1.Visible = False


                            Else
                                Dim myForm As New frmConsulta
                                myForm.Tipo = "P1"
                                myForm.Txt_Buscar.Text = Txt_Marca.Text
                                myForm.ShowDialog()
                                IdProveedorB = myForm.Campo

                                Txt_Raz_Social.Text = myForm.Campo1
                                Txt_Dscto.Text = myForm.Dscto
                                Txt_Plazo.Text = myForm.DIASPP
                                Txt_Raz_Social.ReadOnly = True
                                Txt_Vendedor.ReadOnly = True
                                Btn_NuevoF.Visible = False
                                ' PBox1.Visible = False
                                Exit Sub
                            End If

                        End Using
                    End If
                End If
                ''termina checar el proveedor 



            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub Txt_Marca_TextChanged(sender As Object, e As EventArgs) Handles Txt_Marca.TextChanged

    End Sub

    Private Sub Txt_Marca_MouseCaptureChanged(sender As Object, e As EventArgs) Handles Txt_Marca.MouseCaptureChanged

    End Sub

    Private Sub Txt_Marca_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_Marca.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_DescripMarca_TextChanged(sender As Object, e As EventArgs) Handles Txt_DescripMarca.TextChanged

    End Sub

    Private Sub Txt_DescripMarca_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_DescripMarca.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_Raz_Social_TextChanged(sender As Object, e As EventArgs) Handles Txt_Raz_Social.TextChanged

    End Sub

    Private Sub Txt_Raz_Social_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_Raz_Social.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_Vendedor_TextChanged(sender As Object, e As EventArgs) Handles Txt_Vendedor.TextChanged

    End Sub

    Private Sub Txt_Vendedor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_Vendedor.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub GridControl3_Click(sender As Object, e As EventArgs) Handles GridControl3.Click

    End Sub

    Private Sub frmPpalMuestras_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        Dim S As String

        S = UCase(e.KeyChar)

        S = ChrW(Asc(S))

        e.KeyChar = S
    End Sub

    Private Sub GridView3_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView3.CellValueChanged

        Try

            'If Sw_Load = True Then
            '    Return
            'End If
            If sw_entro = True Then
                Return
            End If
            Dim Renglon As Integer = 0
            Dim Columna As String = ""
            Dim UltPrecio As Integer
            Columna = e.Column.Name

            Renglon = e.RowHandle

            If e.Column.Caption <> "Precio Lista" And e.Column.Caption <> "Precio" Then
                Return
            End If

            If e.Column.Caption = "Precio" Then
                UltPrecio = Mid(GridView3.GetRowCellValue(Renglon, "precio"), GridView3.GetRowCellValue(Renglon, "precio").ToString.Length, 1)
                If UltPrecio <> 9 Then
                    GridView3.SetRowCellValue(Renglon, "precio", 0)
                End If
                Return
            End If

            ''''If Columna = ColumnaB And Renglon = RenglonB Then
            ''''    Return
            ''''End If

            Dim cellValue As String = e.Value.ToString() ''+ " " + view.GetRowCellValue(e.RowHandle, view.Columns("LastName")).ToString()
            ''view.SetRowCellValue(e.RowHandle, view.Columns("FullName"), cellValue)
            'MsgBox(cellValue)

            RenglonB = Renglon
            ColumnaB = Columna

            Call CalcularColumnas(Renglon)

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub CalcularColumnas(Renglon As Integer)
        'mreyes 09/Septiembre/2017  12:44 p.m.
        Try
            Dim precio As Decimal = 0
            Dim preciolista As Decimal = 0
            Dim costo As Decimal = 0
            Dim Margen As Decimal = 0
            Dim Iva As Decimal = 0
            Dim Remision As Decimal = 0
            Dim TRemision As Decimal = 0


            'DGrid1.Visible = False
            Sw_Entro = True
            preciolista = GridView3.GetRowCellValue(Renglon, "preciolista")
            Remision = Val(Txt_Remision.Text)

            If Remision >= 0 And Remision < 50 Then
                Iva = 0
                Margen = 57
            ElseIf Remision >= 50 And Remision < 100 Then
                Iva = 8
                Margen = 53
            Else
                Iva = 16
                Margen = 47
            End If



            costo = pub_CalcularCostoPedido(preciolista, Val(Txt_Dscto.Text), 0, 0, 0, 0, 0, Iva)
            precio = pub_CalcularPrecioVenta(preciolista, Margen)
            Margen = pub_CalcularMargenPedido(precio, costo)

            GridView3.SetRowCellValue(Renglon, "precio", precio)
            GridView3.SetRowCellValue(Renglon, "costo", costo)
            GridView3.SetRowCellValue(Renglon, "margen", Margen)







            Sw_Entro = False
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Pnl_Principal_Paint(sender As Object, e As PaintEventArgs) Handles Pnl_Principal.Paint

    End Sub

    Private Sub frmPpalMuestras_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        '' ELIMINAR REGISTRO DE GRID
        'mreyes 06/Septiembre/2017
        Try
            Dim Guardo As Boolean = False
            Dim Marca As String = ""
            Dim Estilof As String = ""
            Dim Intervalo As String = ""
            Dim MedIni As String = ""
            Dim MedFin As String = ""
            Dim Descrip As String = ""
            Dim Costo As Decimal = 0.0
            Dim Precio As Decimal = 0.0
            Dim PrecioLista As Decimal = 0.0

            If (e.KeyCode = Keys.Escape) Then
                Me.Close()
            End If

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
            If e.KeyCode = Windows.Forms.Keys.F4 Then
                If Pnl_Principal.Visible = True Then
                    Pnl_Principal.Visible = False
                Else
                    Pnl_Principal.Visible = True
                End If
            End If
            '  Dim bytBLOBData() As Byte
            ' Dim stmBLOBData As New MemoryStream(bytBLOBData)



            If e.KeyCode = Windows.Forms.Keys.F5 Then
                '' guardar 
                ''mreyes    20/Septiembre/2017  10:42 a.m.

                For renglon As Integer = 0 To GridView3.RowCount - 1
                    Estilof = GridView3.GetRowCellValue(renglon, "estilof")
                    Intervalo = GridView3.GetRowCellValue(renglon, "i")
                    Descrip = GridView3.GetRowCellValue(renglon, "descrip")
                    PrecioLista = GridView3.GetRowCellValue(renglon, "preciolista")
                    Costo = GridView3.GetRowCellValue(renglon, "costo")
                    Precio = GridView3.GetRowCellValue(renglon, "precio")
                    MedIni = GridView3.GetRowCellValue(renglon, "medini")
                    MedFin = GridView3.GetRowCellValue(renglon, "medfin")



                    Using objBultos As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoAppSQL)
                        Guardo = objBultos.usp_Captura_Muestrasdet(1, IdMuestrasB, Txt_Marca.Text, Estilof, Descrip, 0, "", 0, "", 0, "", 0, "", 0, "", 0, "", 0, "", 0, "", 0, "", 0, "", Intervalo, MedIni, MedFin, PrecioLista, Costo, Precio, GridView3.GetRowCellValue(renglon, "imagen"), GLB_Idempleado)
                    End Using
                Next
                'Call RellenaGrid()

            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Pnl_Principal_KeyDown(sender As Object, e As KeyEventArgs) Handles Pnl_Principal.KeyDown

    End Sub

    Private Sub PBox1_EditValueChanged(sender As Object, e As EventArgs) Handles PBox1.EditValueChanged

    End Sub
End Class