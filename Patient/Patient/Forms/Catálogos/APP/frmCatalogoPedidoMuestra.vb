Imports System.IO
Public Class frmCatalogoPedidoMuestra
    'mreyes 13/10/2017  11:18 a.m.

    Public Marca As String = ""
    Public Modelo As String = ""
    Public Sw_Guardo As Boolean = False
    Dim Linea As String = ""
    Dim L1 As String = ""
    Dim MedIni1 As String = ""
    Dim MedFin1 As String = ""
    Dim Intervalo As String = ""
    Dim Inicio As Integer
    Dim Fin As Integer
    Dim Sw_MalTotal As Boolean = False
    Dim Sw_Entro As Boolean = False

    Private Sub frmCatalogoPedidoMuestra_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try


            Call RellenaGrid(Marca, Modelo)
            '  Call RellenaGridPedido()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub InicializaGrid()

        Try
            DGrid.Columns(0).HeaderText = "I"
            DGrid.Columns(1).HeaderText = "Ini"
            DGrid.Columns(2).HeaderText = "Fin"
            DGrid.Columns(3).HeaderText = "PLista"
            DGrid.Columns(4).HeaderText = "Costo"
            DGrid.Columns(5).HeaderText = "Precio"
            DGrid.Columns(6).HeaderText = "Margen"

            DGrid.Columns(7).Visible = False
            DGrid.Columns(8).Visible = False
            DGrid.Columns(9).Visible = False
            DGrid.Columns(10).Visible = False


            DGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.PowderBlue
            DGrid.ColumnHeadersDefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            DGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            DGrid.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            DGrid.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGrid.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGrid.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            DGrid.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(6).DefaultCellStyle.Format = "#0.00"

            'DGrid.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            ' DGrid.Columns(0).DefaultCellStyle.BackColor = Color.PowderBlue
            ' DGrid.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            ' DGrid.Columns(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

            DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

            '' rellena grid 

            DGrid.RowHeadersVisible = False
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub RellenaGrid(Marca As String, Estilof As String)
        'mreyes 03/Octubre/2017 11:46 p.m.
        Dim objDataSet As DataSet
        Using objTrasp As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoAppSQL)

            Try
                Me.Cursor = Cursors.WaitCursor
                DGrid.DataSource = Nothing
                DGrid.Visible = False
                objDataSet = objTrasp.usp_TraerCostosPreciosMuestrasDet(2, Marca, Estilof)
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    DGrid.DataSource = objDataSet.Tables(0)
                    InicializaGrid()

                    ' PBox1.Image = objDataSet.Tables(1).Rows(0).Item("imagen")
                    Dim bytBLOBData() As Byte = objDataSet.Tables(1).Rows(0).Item("imagen")
                    Dim stmBLOBData As New MemoryStream(bytBLOBData)
                    PBox1.Image = Image.FromStream(stmBLOBData)

                    PBox1.SizeMode = PictureBoxSizeMode.StretchImage

                    Me.Cursor = Cursors.Default

                End If
                Me.Cursor = Cursors.Default
                DGrid.Visible = True
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub RellenaGridPedido()
        'mreyes 17/Octubre/2017 05:28 p.m.
        Dim objDataSet As Data.DataSet
        Using objRegistro As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoAppSQL)

            Try
                Me.Cursor = Cursors.WaitCursor


                DGridPropuesta.Visible = False
                MedIni1 = DGrid.Rows(0).Cells("MEDINI1").Value & ""
                MedFin1 = DGrid.Rows(0).Cells("MEDFIN1").Value & ""
                Intervalo = DGrid.Rows(0).Cells("INTERVALO").Value & ""
                Linea = DGrid.Rows(0).Cells("LINEA").Value & ""
                L1 = DGrid.Rows(0).Cells("L1").Value & ""

                objDataSet = objRegistro.usp_GeneraPedidoxCurvaIdeal(1, Val(Txt_Entregas.Text), Txt_Marca.Text, Txt_Estilof.Text, Linea, L1, Intervalo, MedIni1, MedFin1, Val(Txt_Pares.Text))


                'Populate the Project Details section
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    'Populate the Project Details section


                    DGridPropuesta.DataSource = objDataSet.Tables(0)
                    InicializaGridPedido(DGridPropuesta)

                    'ColorearGrid(DGridPropuesta)

                    '' PROPUESTA COLOR 
                    For i As Integer = 4 To DGridPropuesta.Rows.Count - 1
                        If DGridPropuesta.Rows(i).Cells(0).Value >= 86 And DGridPropuesta.Rows(i).Cells(0).Value <= 89 Then
                            For j As Integer = 0 To DGridPropuesta.Columns.Count - 1
                                If DGridPropuesta.Columns(j).Visible = True Then
                                    If DGridPropuesta.Rows(i).Cells(j).Value = "0" Then
                                        If j <> 3 Then
                                            DGridPropuesta.Rows(i).Cells(j).Style.ForeColor = Color.Beige
                                            DGridPropuesta.Rows(i).Cells(j).Style.BackColor = Color.Beige
                                        Else
                                            DGridPropuesta.Rows(i).Cells(j).Style.BackColor = Color.Beige
                                        End If
                                    Else

                                        DGridPropuesta.Rows(i).Cells(j).Style.ForeColor = Color.Black
                                        DGridPropuesta.Rows(i).Cells(j).Style.BackColor = Color.Beige
                                    End If
                                End If
                            Next
                        End If
                    Next

                    'LimpiarBusqueda()
                    Me.Cursor = Cursors.Default
                    'Btn_Excel.Enabled = True

                Else


                    Me.Cursor = Cursors.Default
                    MsgBox("No se encontraron movimientos.", MsgBoxStyle.Critical, "Aviso")
                    'Btn_Excel.Enabled = False

                End If
                Me.Cursor = Cursors.Default

                DGridPropuesta.Visible = True


            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using


    End Sub
    Private Sub DGridPropuesta_CellEndEdit1(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGridPropuesta.CellEndEdit
        Try
            Dim columna As Integer = DGridPropuesta.CurrentCell.ColumnIndex
            Dim renglon As Integer = DGridPropuesta.CurrentCell.RowIndex

            Dim TotalExi As Integer = 0


            Dim TotalTotalExi As Integer = 0
            GuardarDatos(DGridPropuesta)
            If columna < 3 Then Exit Sub


            Sw_MalTotal = False


            DGridPropuesta.Rows(0).Cells(columna).Value = pub_SumarColumnaGridSTotal(DGridPropuesta, columna, DGridPropuesta.RowCount - 1)

            DGridPropuesta.Rows(renglon).Cells(3).Value = pub_SumarRenglonGridSTotal(DGridPropuesta, renglon, Inicio, Fin)

            DGridPropuesta.Rows(0).Cells(3).Value = pub_SumarColumnaGridSTotal(DGridPropuesta, 3, DGridPropuesta.RowCount - 1)


            DGridPropuesta.Rows(renglon).Cells(columna).Style.ForeColor = Color.Black




            Sw_MalTotal = False
                DGridPropuesta.Rows(0).Cells(columna).Style.ForeColor = Color.Black
                DGridPropuesta.Rows(0).Cells(columna).Style.BackColor = Color.PowderBlue

            DGridPropuesta.Rows(renglon).Cells(columna).Style.ForeColor = Color.Black
            DGridPropuesta.Rows(renglon).Cells(columna).Style.BackColor = Color.Yellow
            Sw_Entro = True

        Catch ExceptionErr As Exception


            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub DGridPropuesta_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles DGridPropuesta.CellBeginEdit
        Try
            Dim columna As Integer = DGridPropuesta.CurrentCell.ColumnIndex
            Dim renglon As Integer = DGridPropuesta.CurrentCell.RowIndex


            DGridPropuesta.Rows(renglon).Cells(columna).Style.ForeColor = Color.Black



        Catch ExceptionErr As Exception


            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub DGridPropuesta_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DGridPropuesta.EditingControlShowing
        Dim validar As TextBox = CType(e.Control, TextBox)
        Try
            ' agregar el controlador de eventos para el KeyPress   
            AddHandler validar.KeyPress, AddressOf validar_Keypress
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub validar_Keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        'mreyes 13/Febrero/2011 11:25 a.m.
        'Función para validar la escritura en cada una de las columnas del detalle de pedido
        Try
            ' obtener indice de la columna  
            Dim columna As Integer = DGridPropuesta.CurrentCell.ColumnIndex
            Dim renglon As Integer = DGridPropuesta.CurrentCell.RowIndex
            Dim caracter As Char = e.KeyChar

            If Not Char.IsNumber(caracter) And (caracter = ChrW(Keys.Back)) = False And caracter <> "/" And caracter <> "-" Then

                e.KeyChar = Chr(0)
            End If


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub DGridPropuesta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGridPropuesta.KeyDown
        Try
            Dim selectedCellCount As Integer = DGridPropuesta.GetCellCount(DataGridViewElementStates.Selected)
            Dim TotalExi As Integer = 0


            If (e.KeyCode = 46) Then
                Dim renglon As Integer = DGridPropuesta.CurrentCell.RowIndex
                If selectedCellCount > 0 Then

                    For i As Integer = 0 To selectedCellCount - 1
                        DGridPropuesta.SelectedCells(i).Value = "0"
                    Next
                End If

                ''' CHECAR TOTRALES
                ''' 


                For COLUMNA As Integer = Inicio To Fin

                    Sw_MalTotal = False


                    DGridPropuesta.Rows(0).Cells(COLUMNA).Value = pub_SumarColumnaGridSTotal(DGridPropuesta, COLUMNA, DGridPropuesta.RowCount - 1)
                    DGridPropuesta.Rows(renglon).Cells(3).Value = pub_SumarRenglonGridSTotal(DGridPropuesta, renglon, Inicio, Fin)

                    Sw_MalTotal = False
                    DGridPropuesta.Rows(0).Cells(COLUMNA).Style.ForeColor = Color.Black
                    DGridPropuesta.Rows(0).Cells(COLUMNA).Style.BackColor = Color.PowderBlue


                    Sw_Entro = True
                Next
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub InicializaGridPedido(ByVal DGridFormato As DataGridView)
        'mreyes 17/Octubre/2017   05:28 p.m.
        Try


            Dim Sw_EmpiezaMedios As Boolean = False
            Dim Sw_TerminaMedios As Boolean = False
            Dim dt As DataTable = TryCast(DGridFormato.DataSource, DataTable)
            Dim row As DataRow = dt.NewRow()



            row(1) = "TOTAL: "

            DGridFormato.Columns(0).Frozen = True
            DGridFormato.Columns(1).Frozen = True
            DGridFormato.Columns(2).Frozen = True
            DGridFormato.Columns(3).Frozen = True

            DGridFormato.RowHeadersVisible = False
            'DGridFormato.Columns(2).Visible = False
            DGridFormato.Columns(4).HeaderText = "01"
            DGridFormato.Columns(5).HeaderText = "01-"
            DGridFormato.Columns(6).HeaderText = "02"
            DGridFormato.Columns(7).HeaderText = "02-"
            DGridFormato.Columns(8).HeaderText = "03"
            DGridFormato.Columns(9).HeaderText = "03-"
            DGridFormato.Columns(10).HeaderText = "04"
            DGridFormato.Columns(11).HeaderText = "04-"
            DGridFormato.Columns(12).HeaderText = "05"
            DGridFormato.Columns(13).HeaderText = "05-"
            DGridFormato.Columns(14).HeaderText = "06"
            DGridFormato.Columns(15).HeaderText = "06-"
            DGridFormato.Columns(16).HeaderText = "07"
            DGridFormato.Columns(17).HeaderText = "07-"
            DGridFormato.Columns(18).HeaderText = "08"
            DGridFormato.Columns(19).HeaderText = "08-"
            DGridFormato.Columns(20).HeaderText = "09"
            DGridFormato.Columns(21).HeaderText = "09-"
            DGridFormato.Columns(22).HeaderText = "10"
            DGridFormato.Columns(23).HeaderText = "10-"


            DGridFormato.Columns(24).HeaderText = "11"
            DGridFormato.Columns(25).HeaderText = "11-"
            DGridFormato.Columns(26).HeaderText = "12"
            DGridFormato.Columns(27).HeaderText = "12-"
            DGridFormato.Columns(28).HeaderText = "13"
            DGridFormato.Columns(29).HeaderText = "13-"
            DGridFormato.Columns(30).HeaderText = "14"
            DGridFormato.Columns(31).HeaderText = "14-"
            DGridFormato.Columns(32).HeaderText = "15"
            DGridFormato.Columns(33).HeaderText = "15-"
            DGridFormato.Columns(34).HeaderText = "16"
            DGridFormato.Columns(35).HeaderText = "16-"
            DGridFormato.Columns(36).HeaderText = "17"
            DGridFormato.Columns(37).HeaderText = "17-"
            DGridFormato.Columns(38).HeaderText = "18"
            DGridFormato.Columns(39).HeaderText = "18-"
            DGridFormato.Columns(40).HeaderText = "19"
            DGridFormato.Columns(41).HeaderText = "19-"
            DGridFormato.Columns(42).HeaderText = "20"
            DGridFormato.Columns(43).HeaderText = "20-"


            DGridFormato.Columns(44).HeaderText = "21"
            DGridFormato.Columns(45).HeaderText = "21-"
            DGridFormato.Columns(46).HeaderText = "22"
            DGridFormato.Columns(47).HeaderText = "22-"
            DGridFormato.Columns(48).HeaderText = "23"
            DGridFormato.Columns(49).HeaderText = "23-"
            DGridFormato.Columns(50).HeaderText = "24"
            DGridFormato.Columns(51).HeaderText = "24-"
            DGridFormato.Columns(52).HeaderText = "25"
            DGridFormato.Columns(53).HeaderText = "25-"
            DGridFormato.Columns(54).HeaderText = "26"
            DGridFormato.Columns(55).HeaderText = "26-"
            DGridFormato.Columns(56).HeaderText = "27"
            DGridFormato.Columns(57).HeaderText = "27-"
            DGridFormato.Columns(58).HeaderText = "28"
            DGridFormato.Columns(59).HeaderText = "28-"
            DGridFormato.Columns(60).HeaderText = "29"
            DGridFormato.Columns(61).HeaderText = "29-"
            DGridFormato.Columns(62).HeaderText = "30"
            DGridFormato.Columns(63).HeaderText = "30-"
            DGridFormato.Columns(64).HeaderText = "31"
            DGridFormato.Columns(65).HeaderText = "31-"


            Sw_EmpiezaMedios = False

            If InStr(MedIni1, "-") > 0 Then
                ' empieza en medios.
                Sw_EmpiezaMedios = True
                Inicio = Mid(MedIni1, 1, 2)
            Else
                Inicio = MedIni1

            End If

            If InStr(MedFin1, "-") > 0 Then
                Sw_TerminaMedios = True
                Fin = Mid(MedFin1, 1, 2)
            Else
                Fin = MedFin1
            End If


            Inicio = (Inicio + 2) * 2
            If Sw_EmpiezaMedios = True Then
                Inicio = Inicio - 2
            Else
                Inicio = Inicio - 2
            End If

            Fin = (Fin + 2) * 2

            'If Sw_TerminaMedios Then   'nueva programa
            Fin = Fin - 1
            'End If

            For i As Integer = 4 To DGridFormato.ColumnCount - 1 ''  eran primero 3 y luego eran dos
                DGridFormato.Columns(i).Visible = False

            Next
            ' Medida = DGridPropuesta.Columns(j).HeaderText
            '  row(3) = pub_SumarColumnaGrid(DGridFormato, 3, DGridFormato.RowCount - 1)
            DGridFormato.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            For i As Integer = Inicio To Fin
                ' sumar
                row(i) = pub_SumarColumnaGrid(DGridFormato, i, DGridFormato.RowCount - 1)

                DGridFormato.Columns(i).Visible = True
                DGridFormato.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                '' ''If Sw_EmpiezaMedios = False Then
                '' ''    'quitar medios 
                '' ''    If InStr(DGridFormato.Columns(i).HeaderText, "-") > 0 Then
                '' ''        DGridFormato.Columns(i).Visible = False
                '' ''    End If
                '' ''End If
            Next

            row("total") = pub_SumarColumnaGrid(DGridFormato, 3, DGridFormato.RowCount - 1)

            dt.Rows.InsertAt(row, 0)
            DGridFormato.DataSource = dt

            DGridFormato.Columns(DGridFormato.ColumnCount - 1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGridFormato.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells


            DGridFormato.Rows(0).DefaultCellStyle.BackColor = Color.PowderBlue
            DGridFormato.Rows(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGridFormato.Rows(0).DefaultCellStyle.Font = New Font(DGridFormato.DefaultCellStyle.Font.FontFamily, DGridFormato.DefaultCellStyle.Font.Size, FontStyle.Bold)




        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub

    'Public Sub ColorearGrid(ByVal DGridFormato As DataGridView)
    '    Try
    '        DGridFormato.Visible = False

    '        Dim Col1 As Color
    '        Col1 = Color.LimeGreen
    '        Dim Col2 As Color
    '        Col2 = Color.Gold
    '        Dim Col3 As Color
    '        Col3 = Color.SkyBlue
    '        Dim Col4 As Color
    '        Col4 = Color.Plum
    '        Dim Col5 As Color
    '        If DGridFormato.DataSource Is Nothing Then Exit Sub
    '        For i As Integer = 1 To DGridFormato.Rows.Count - 1
    '            For j As Integer = 5 To DGridFormato.Columns.Count - 1
    '                If DGridFormato.Columns(j).Visible = True Then
    '                    If DGridFormato.Rows(i).Cells(j).Value = "0" Then

    '                        If DGridFormato.Rows(i).Cells("Entrega").Value.ToString.Trim = "VENTA" Then

    '                            Col5 = Col1
    '                        ElseIf DGridFormato.Rows(i).Cells("Entrega").Value.ToString.Trim = "EXISTENCIA" Then
    '                            Col5 = Col2
    '                        ElseIf DGridFormato.Rows(i).Cells("Entrega").Value.ToString.Trim = "" Then
    '                            Col5 = Col3
    '                        ElseIf DGridFormato.Rows(i).Cells("Entrega").Value.ToString.Trim = "PEDIDO PENDIENTE" Then
    '                            Col5 = Col4
    '                        ElseIf DGridFormato.Rows(i).Cells("Entrega").Value.ToString.Trim = "NEGRO" Then
    '                            Col5 = Color.Black
    '                        Else
    '                            Col5 = Color.White
    '                        End If

    '                        DGridFormato.Rows(i).Cells(j).Style.ForeColor = Col5 ' DGrid.Rows(i).DefaultCellStyle.BackColor
    '                    End If


    '                End If

    '            Next
    '            If DGridFormato.Rows(i).Cells("Entrega").Value.ToString.Trim = "VENTA" Then
    '                DGridFormato.Rows(i).DefaultCellStyle.BackColor = Col1

    '                Continue For
    '            End If
    '            If DGridFormato.Rows(i).Cells("Entrega").Value.ToString.Trim = "EXISTENCIA" Then
    '                DGridFormato.Rows(i).DefaultCellStyle.BackColor = Col2
    '                Continue For
    '            End If
    '            If DGridFormato.Rows(i).Cells("Entrega").Value.ToString.Trim = "" Then
    '                DGridFormato.Rows(i).DefaultCellStyle.BackColor = Col3


    '                Continue For
    '            End If
    '            If DGridFormato.Rows(i).Cells("Entrega").Value.ToString.Trim = "PEDIDO PENDIENTE" Then
    '                DGridFormato.Rows(i).DefaultCellStyle.BackColor = Col4
    '                Continue For
    '            End If

    '            If DGridFormato.Rows(i).Cells("Entrega").Value.ToString.Trim = "NEGRO" Then
    '                DGridFormato.Rows(i).DefaultCellStyle.ForeColor = Color.Black
    '                DGridFormato.Rows(i).DefaultCellStyle.BackColor = Color.Black

    '                Continue For
    '            End If


    '        Next


    '        '' CHECAR PROPUESTA PARA COLOR

    '        DGridFormato.Visible = True
    '    Catch ExceptionErr As Exception
    '        MessageBox.Show(ExceptionErr.Message.ToString)
    '    End Try
    'End Sub

    Private Sub DGrid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGrid.CellContentClick

    End Sub

    Private Sub Txt_Pares_TextChanged(sender As Object, e As EventArgs) Handles Txt_Pares.TextChanged

    End Sub

    Private Sub Txt_Pares_LostFocus(sender As Object, e As EventArgs) Handles Txt_Pares.LostFocus
        RellenaGridPedido()
    End Sub

    Private Sub GuardarDatos(DGrid As DataGridView)
        'mreyes 18/Octubre/2017 12:03 p.m.

        Try


            Dim nombre As String = ""
            Dim Guardo As Boolean = False
            Dim EntregaAnt As String = ""
            Dim EntregaNvo As String = ""
            Dim Medida As String = ""
            Dim idsucursal As Integer = 0
            Dim Ctd As Integer = 0

            'Guardar en el detallado de la muestra 

            Dim columna As Integer = Dgrid.CurrentCell.ColumnIndex
            Dim renglon As Integer = Dgrid.CurrentCell.RowIndex

            EntregaAnt = Format(DGrid.Rows(renglon).Cells("entregaant").Value, "dd/MM/yyyy")
            EntregaNvo = Format(DGrid.Rows(renglon).Cells("entrega").Value, "dd/MM/yyyy")
            Medida = DGrid.Columns(columna).HeaderText
            idsucursal = DGrid.Rows(renglon).Cells("DET").Value & ""
            ' Ctd = Val(DGrid.Rows(renglon).Cells("ctd").Value)

            If columna = 2 Then
                ' esta cambiando fecha
                Using objBultos As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoAppSQL)
                    Guardo = objBultos.usp_Captura_PedidoTmp(2, Txt_Marca.Text, Txt_Estilof.Text, EntregaAnt, EntregaNvo, Medida, idsucursal, Ctd)
                End Using
                DGrid.Rows(renglon).Cells("entregaant").Value = EntregaNvo
                For i As Integer = 1 To DGrid.RowCount - 1
                    If Format(DGrid.Rows(i).Cells("entrega").Value, "dd/MM/yyyy") = EntregaAnt Then
                        DGrid.Rows(i).Cells("entregaant").Value = EntregaNvo
                        DGrid.Rows(i).Cells("entrega").Value = EntregaNvo

                    End If
                Next
            Else
                Ctd = Val(DGrid.Rows(renglon).Cells(columna).Value)
                Using objBultos As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoAppSQL)
                    Guardo = objBultos.usp_Captura_PedidoTmp(1, Txt_Marca.Text, Txt_Estilof.Text, EntregaAnt, EntregaNvo, Medida, idsucursal, Ctd)
                End Using
            End If



        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGridPropuesta_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGridPropuesta.CellContentClick

    End Sub

    Private Sub DGrid_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DGrid.CellEndEdit

    End Sub
End Class