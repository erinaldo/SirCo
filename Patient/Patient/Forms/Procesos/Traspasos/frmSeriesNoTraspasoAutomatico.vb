Public Class frmSeriesNoTraspasoAutomatico
    'mreyes 26/Enero/2017    04:32 p.m.
    Private objDataSet As Data.DataSet
    Public IdProTrasB As Integer

    Private tiempoInicial As DateTime
    Private tiempoFinal As DateTime
    Private evaluando As Boolean = False
    Public Sw_Registros As Boolean = False


    Private Sub DGrid_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellEndEdit
        Try
            Dim columna As Integer = DGrid.CurrentCell.ColumnIndex
            Dim renglon As Integer = DGrid.CurrentCell.RowIndex
            Dim Serie As String = pub_RellenarIzquierda(DGrid.Rows(renglon).Cells(0).Value, 13)
            If columna = 0 Then 'ES DEVOLUCION Y ES SERIE 




                For I As Integer = 0 To DGrid.RowCount - 1 'objDataSet.Tables(0).Rows.Count - 1
                    If I <> renglon Then
                        If DGrid.Rows(I).Cells(0).Value = pub_RellenarIzquierda(DGrid.Rows(renglon).Cells(0).Value, 13) Then
                            MsgBox("La serie ya existe en el listado.", MsgBoxStyle.Critical, "Error")
                            DGrid.Rows(renglon).Cells(0).Value = ""
                            DGrid.Rows.RemoveAt(DGrid.CurrentCell.RowIndex)
                            Exit Sub
                        End If
                    End If
                Next


                Using ObjCatalogoEstilos As New BCL.BCLCatalogoEstilos(GLB_ConStringCipSis)


                    DGrid.Rows(renglon).Cells(0).Value = pub_RellenarIzquierda(DGrid.Rows(renglon).Cells(0).Value, 13)

                    objDataSet = ObjCatalogoEstilos.usp_TraerDatosSerie(Serie, "", "")

                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        ' si existe estilo, traerlo.




                        If objDataSet.Tables(0).Rows(0).Item("status").ToString = "BA" Then
                            MsgBox("La serie ya se encuentra dada de baja.", MsgBoxStyle.Critical, "Aviso")
                            DGrid.Rows(renglon).Cells(134).Value = ""
                            Exit Sub
                        End If

                        'If objDataSet.Tables(0).Rows(0).Item("status").ToString = "TR" Then
                        '    MsgBox("La serie se encuentra en traspaso.", MsgBoxStyle.Critical, "Aviso")
                        '    DGrid.Rows(renglon).Cells(134).Value = ""
                        '    Exit Sub
                        'End If




                        DGrid.Rows(renglon).Cells("modelo").Value = objDataSet.Tables(0).Rows(0).Item("ESTILON").ToString
                        DGrid.Rows(renglon).Cells("MARCA").Value = objDataSet.Tables(0).Rows(0).Item("MARCA").ToString
                        DGrid.Rows(renglon).Cells("MEDIDA").Value = objDataSet.Tables(0).Rows(0).Item("MEDIDA").ToString
                        DGrid.Rows(renglon).Cells("sucursal").Value = objDataSet.Tables(0).Rows(0).Item("sucursal").ToString


                    Else
                        MsgBox("La serie no existe o no se encuentra asignada a la sucursal.", MsgBoxStyle.Critical, "Aviso")
                        DGrid.Rows(renglon).Cells(134).Value = ""
                        Exit Sub

                    End If
                End Using
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click
        'mreyes 18/Agosto/2016  04:41 p.m.
        Try
            Dim Guardo As Boolean = False
            Dim Serie As String = ""
            Dim Marca As String = ""
            Dim Modelo As String = ""
            Dim Medida As String = ""
            Dim Sucursal As String = ""
            Dim Observa As String

            'If MsgBox("Esta usted seguro de registrar las series.", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.No Then Exit Sub

            ''Guardar en temporal... 

            For renglon As Integer = 0 To DGrid.RowCount - 2
                Serie = DGrid.Rows(renglon).Cells("serie").Value
                Marca = DGrid.Rows(renglon).Cells("marca").Value
                Modelo = DGrid.Rows(renglon).Cells("modelo").Value
                Medida = DGrid.Rows(renglon).Cells("medida").Value
                Sucursal = Txt_Sucursal.Text
                Observa = DGrid.Rows(renglon).Cells("observacion").Value

                Using objBultos As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoSQL)

                    Guardo = objBultos.usp_Captura_ProtraspDetNoaplica(1, Serie, Marca, Modelo, Medida, Sucursal, Observa, GLB_Idempleado)

                End Using



            Next

            ' MsgBox("Series reportadas a Administración para su seguimiento.", MsgBoxStyle.Information, "Aviso")
            Sw_Registros = True

            If usp_MatchPropuestaTraspaso() Then

            End If


            Me.Close()
            '   Me.Dispose()



            '' eliminar de la petición de traspaso... 

            '' igualar encabezados

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Function usp_MatchPropuestaTraspaso() As Boolean
        'mreyes 02/Noviembre/2016   05:32 p.m.


        Using objCalculo As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoSQL)
            Try
                'Get the specific project selected in the ListView controlsu

                Application.DoEvents()

                usp_MatchPropuestaTraspaso = objCalculo.usp_MatchPropuestaTraspaso




                Application.DoEvents()
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function
    Private Sub DGrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellContentClick

    End Sub

    Private Sub Btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cancelar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub frmSeriesNoTraspaso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call RellenaGrid()
        DGrid.Columns(0).ReadOnly = True
        DGrid.Columns(1).ReadOnly = True
        DGrid.Columns(2).ReadOnly = True
        DGrid.Columns(3).ReadOnly = True


        Txt_Serie.Focus()
    End Sub


    Private Sub RellenaGrid()
        'mreyes 06/Julio/2016   06:42 p.m.
        DGrid.Visible = False
        'InicializaGrid()
        Using objTrasp As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoSQL)

            Try
                Me.Cursor = Cursors.WaitCursor
                'DGrid.ReadOnly = True
                DGrid2.DataSource = Nothing

                objDataSet = objTrasp.usp_MatchTraspAut(1, Val(Txt_IdTraspAut.Text))

                'Populate the Project Details section
                If objDataSet.Tables(0).Rows.Count > 0 Then

                    '
                    DGrid2.DataSource = objDataSet.Tables(0)
                    InicializaGrid()

                    Me.Cursor = Cursors.Default
                    
                Else
                   
                End If
                Me.Cursor = Cursors.Default
                ' LimpiarBusqueda()
                DGrid.Visible = True
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Sub InicializaGrid()
        Try

            'Dim dt As DataTable = TryCast(DGrid2.DataSource, DataTable)

            'DGrid2.DataSource = dt

            Dim dt As DataTable = TryCast(DGrid2.DataSource, DataTable)
            Dim row As DataRow = dt.NewRow()

            row(3) = "TOTAL: "
            row("PEDIDA") = pub_SumarColumnaGrid(DGrid2, 4, DGrid2.RowCount - 1)
            row("traspasada") = pub_SumarColumnaGrid(DGrid2, 5, DGrid2.RowCount - 1)
            row("diferencia") = pub_SumarColumnaGrid(DGrid2, 6, DGrid2.RowCount - 1)


            dt.Rows.InsertAt(row, 0)
            DGrid2.DataSource = dt

            DGrid2.RowHeadersVisible = False
            DGrid2.Columns(0).HeaderText = "Id"
            DGrid2.Columns(1).HeaderText = "Marca"
            DGrid2.Columns(2).HeaderText = "Estilo"
            DGrid2.Columns(3).HeaderText = "Medida"

            DGrid2.Columns(4).HeaderText = "Solicitado"
            DGrid2.Columns(5).HeaderText = "Enviado"
            DGrid2.Columns(6).HeaderText = "Diferencia"



            DGrid2.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid2.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid2.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid2.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            DGrid2.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid2.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid2.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter



            DGrid2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

            DGrid2.Rows(0).DefaultCellStyle.BackColor = Color.PowderBlue
            DGrid2.Rows(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid2.Rows(0).DefaultCellStyle.Font = New Font(DGrid2.DefaultCellStyle.Font.FontFamily, DGrid2.DefaultCellStyle.Font.Size, FontStyle.Bold)

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_Serie_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Serie.LostFocus
        Try
            Dim Serie As String
            

            If Txt_Serie.Text.Length = 0 Or Txt_Serie.Text = "0" Then Exit Sub

            Serie = Txt_Serie.Text

          
            Using ObjCatalogoEstilos As New BCL.BCLCatalogoEstilos(GLB_ConStringCipSis)


                objDataSet = ObjCatalogoEstilos.usp_TraerDatosSerie(Serie, "", "")

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    ' si existe estilo, traerlo.




                    If objDataSet.Tables(0).Rows(0).Item("status").ToString = "BA" Then
                        MsgBox("La serie ya se encuentra dada de baja.", MsgBoxStyle.Critical, "Aviso")
                        Txt_Serie.Text = ""
                        Exit Sub
                    End If

                    DGrid.Rows.Add(Txt_Serie.Text, objDataSet.Tables(0).Rows(0).Item("MARCA").ToString, objDataSet.Tables(0).Rows(0).Item("estilon").ToString, objDataSet.Tables(0).Rows(0).Item("MEDIDA").ToString)

                Else
                    MsgBox("La serie no existe o no se encuentra asignada a la sucursal.", MsgBoxStyle.Critical, "Aviso")

                    Exit Sub

                End If
            End Using

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_Serie_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Serie.TextChanged
        Try

            If Txt_Serie.Text = "" Then Exit Sub
            Dim largo As Long = Me.Txt_Serie.Text.Length
            If evaluando = False And largo >= 1 Then
                tiempoInicial = Now
                evaluando = True
            Else
                If largo >= 1 Then 'evaluamos el tiempo
                    tiempoFinal = Now
                    Dim segundos As Long = DateDiff(DateInterval.Second, tiempoInicial, tiempoFinal)
                    If segundos >= 1 Then
                        'MsgBox("Entrada no permitida por teclado", MsgBoxStyle.Exclamation, "Error")
                        evaluando = False
                        Me.Txt_Serie.Text = ""

                    End If
                End If
            End If
            If largo = 0 Then
                evaluando = False
            End If

            If evaluando = True Then

                If Txt_Serie.Text.Length = 13 Then
                    Txt_Serie_LostFocus(sender, e)
                    Txt_Serie.Text = ""
                    Txt_Serie.Focus()
                End If
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
End Class