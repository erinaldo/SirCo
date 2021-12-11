Public Class frmLeerTraspaso
    'mreyes 28/Abril/2015   10:09 a.m.
    Dim Sql As String
    Public Sw_Filtro As Boolean = False
    Public Sw_Cancelar As Boolean = False

    Private objDataSet As Data.DataSet



    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click

        Try
            Sw_Filtro = True
            If MsgBox("Esta usted seguro de confirmar las series para el traspaso.?.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirmación") = MsgBoxResult.No Then Exit Sub

            ' si sigue

            Dim tArray() As String 'Declaro un array

            tArray = Split(Txt_LeerSeries.Text, vbCrLf) 'Almaceno en el array lo que hay en cada salto de linea

            For i As Integer = LBound(tArray) To UBound(tArray) 'Esas funciones recorren el array sin saber donde empieza ni donde acaba
                If Inserta_TraspasoLeer(tArray(i)) = True Then

                End If
                'Opcional, aniade la palabra a otra caja de texto

            Next i



            If usp_MatchPropuestaTraspaso() Then

            End If


            Me.Close()
            '' Me.Dispose()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
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

    Function Inserta_TraspasoLeer(ByVal SerieB As String) As Boolean
        'mreyes 02/Noviembre/2016   05:22 p.m.

        Using objSigBit As New BCL.BCLAparador(GLB_ConStringCipSis)
            'Get a new Project DataSet
            Try
                objDataSet = objSigBit.Inserta_TraspasoLeer
                'Initialize a datarow object from the Project DataSet
                Dim objDataRow As Data.DataRow = objDataSet.Tables(0).NewRow

                'Set the values in the DataRow
                objDataRow.Item("sucursal") = GLB_CveSucursal

                objDataRow.Item("serie") = SerieB
                objDataRow.Item("IDUSUARIOINICIALAPA") = GLB_Idempleado


                'Add the DataRow to the DataSet
                objDataSet.Tables(0).Rows.Add(objDataRow)

                'Add the Project
                If Not objSigBit.usp_Captura_TraspasoLeer(objDataSet) Then
                    'Throw New Exception("Falló Inserción de Serie de AparadorLeer")
                Else
                    Inserta_TraspasoLeer = True
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function

    Private Sub LimpiarDatos()
        Try
            Txt_LeerSeries.Text = ""

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub Btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cancelar.Click
        Try
            '' Me.Dispose()
            Sw_Cancelar = True
            Sw_Filtro = False
            Me.Close()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub GenerarToolTip()
        Try
            ToolTip.SetToolTip(Btn_Aceptar, "Aceptar la acción requerida por el usuario")
            ToolTip.SetToolTip(Btn_Cancelar, "Cancelar cualquier acción requerida por el usuario")
            ToolTip.SetToolTip(Btn_Limpiar, "Limpiar Filtros")


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub frmFiltrosPedidoNuevo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Sw_Filtro = False
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub
    Private Sub frmConsultaEstilo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call GenerarToolTip()
        'Call CargaDescripcion(sender, e)
    End Sub
    Private Sub Pnl_Edicion_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Pnl_Edicion.Paint

    End Sub
    Private Sub TxtLostfocusPersis(ByVal Txt_Campo As TextBox, ByVal Txt_Campo1 As TextBox, ByVal Tipo As String)
        Dim myForm As New frmConsulta


        If Txt_Campo.Text.Length = 0 Then Exit Sub
        Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringPerSis)
            Try


                objDataSet = objMySqlGral.usp_TraerDescripcion(Tipo, Txt_Campo.Text, "")

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_Campo1.Text = objDataSet.Tables(0).Rows(0).Item("campo").ToString
                Else
                    Txt_Campo.Text = ""
                    myForm.Tipo = Tipo
                    myForm.ShowDialog()
                    Txt_Campo.Text = myForm.Campo
                    Txt_Campo1.Text = myForm.Campo1
                    If Txt_Campo.Text.Length = 0 Then
                        Txt_Campo.Focus()
                    End If
                End If


            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub





    Private Sub Btn_Limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Limpiar.Click




    End Sub


End Class