Public Class frmCatalogoEstilosTienda
    'mreyes 24/Octubre/2012 09:38 a.m.

    Dim Sql As String
    Public Accion As Integer  '' 1  = nuevo, 2 = edicion , 3 = eliminar , 4 = consultar 
    Public Sw_Registro As Boolean = False
    Private objDataSet As Data.DataSet
    Dim Costo As Decimal = 0
    Public Sw_PedidoNuevo As Boolean = False





    Private Sub Txt_Familia_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Familia.GotFocus
        Txt_Familia.SelectAll()
    End Sub

    Private Sub Txt_Familia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Familia.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    'Catálogo de Artículos
    'mreyes 07/Febrero/2012 05:37 p.m.


    Private Sub Txt_Familia_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Familia.LostFocus
        Try
            If Txt_Familia.Text.Length = 0 Then Exit Sub
            If Txt_Familia.Text.Trim.Length < 3 Then
                Txt_Familia.Text = pub_RellenarIzquierda(Txt_Familia.Text.Trim, 3)
            End If
            Call TxtLostfocus(Txt_Familia, Txt_DescripFamilia, "F")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub Txt_Marca_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Marca.GotFocus
        Txt_Marca.SelectAll()
    End Sub

    Private Sub Txt_Marca_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Marca.KeyPress
        e.KeyChar = UCase(e.KeyChar)

    End Sub

    Function Inserta_Articulo() As Boolean
        Using objCatalogoEstilos As New BCL.BCLCatalogoEstilos(Glb_ConStringCipSis)
            'Get a new Project DataSet
            Try
                objDataSet = objCatalogoEstilos.Inserta_Articulo  'INSERTA NUEVO DATASET
                'Initialize a datarow object from the Project DataSet
                Dim objDataRow As Data.DataRow = objDataSet.Tables(0).NewRow

                'Set the values in the DataRow

                objDataRow.Item("marca") = Trim(Txt_Marca.Text)
                objDataRow.Item("estilon") = (Txt_Estilon.Text)
                objDataRow.Item("estilof") = Trim(Txt_Estilof.Text)
                objDataRow.Item("descripc") = Trim(Txt_Descripc.Text)
                objDataRow.Item("familia") = Trim(Txt_Familia.Text)
                objDataRow.Item("linea") = Trim(Txt_Linea.Text)
                objDataRow.Item("proveedor") = Trim(Txt_Proveedor.Text)
                objDataRow.Item("tipoart") = Trim(Txt_TipoArt.Text)
                objDataRow.Item("categoria") = Trim(Txt_Categoria.Text)
                objDataRow.Item("descripl") = Trim(Txt_DescripL.Text)
                objDataRow.Item("medida") = Mid(Cbo_Medida.Text, 1, 1)
                objDataRow.Item("acepdevo") = Mid(Cbo_AcepDevo.Text, 1, 1)
                objDataRow.Item("fecha") = Format(Now, "yyyyMMdd") ' Ver
                objDataRow.Item("hora") = Format(Now, "hh:mm:ss")
                objDataRow.Item("resmin") = Val(Txt_Resmin.Text)

                'Add the DataRow to the DataSet
                objDataSet.Tables(0).Rows.Add(objDataRow)

                'Add the Project
                If Not objCatalogoEstilos.usp_Captura_Articulo(Accion, objDataSet) Then
                    Throw New Exception("Falló Inserción de Artículo")
                Else
                    Inserta_Articulo = True
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function
    Function Inserta_Corrida() As Boolean
        Try
            'mreyes 10/Febrero/2012 10:04 a.m.
            Dim Sw_ExisteCorrida As Boolean
            Dim TipoCrr As String = ""
            Dim Margen As Decimal = 0
            Dim TipoCrrBus As String = ""
            Dim CambPrec As String = ""
            Dim PrecioValor As Decimal = 0
            For I As Integer = 0 To DGrid.Rows.Count - 2
                If DGrid.Rows(I).Cells(0).Value.ToString.Length = 0 Then Exit Function
                Using objCatalogoEstilos As New BCL.BCLCatalogoEstilos(Glb_ConStringCipSis)
                    'Get a new Project DataSet
                    Try
                        PrecioValor = (DGrid.Rows(I).Cells(5).Value)

                        If Accion = 2 Then
                            Using objCorrida As New BCL.BCLCatalogoEstilos(GLB_ConStringCipSis)

                                objDataSet = objCorrida.usp_TraerCorrida("", Txt_Marca.Text, Txt_Estilon.Text, DGrid.Rows(I).Cells(0).Value.ToString, Txt_Proveedor.Text)

                                If objDataSet.Tables(0).Rows.Count > 0 Then
                                    Sw_ExisteCorrida = True

                                    ' checar los precios 
                                    ''If PrecioValor <> (DGrid.Rows(I).Cells(13).Value) Then 'cambio el precio
                                    ''    If MsgBox("El sistema ha detectado un cambio de precio para la corrida '" & DGrid.Rows(I).Cells(0).Value.ToString & ", Es correcto.?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación Cambio de Precio") = MsgBoxResult.Yes Then

                                    ''        CambPrec = fn_TraerFolioCambPrec("99") 'sucursal de cambio de precio
                                    ''        CambPrec = pub_RellenarIzquierda(CambPrec, 6)

                                    ''        If Inserta_OrdeComp(OrdeComp) = False Then
                                    ''            Throw New Exception("Falló Inserción de Corrida")
                                    ''            Exit Function
                                    ''        End If

                                    ''        If Actualiza_FolioCambPrec("") = False Then
                                    ''            Throw New Exception("Falló Inserción de Corrida")
                                    ''            Exit Function
                                    ''        End If
                                    ''    Else
                                    ''        PrecioValor = (DGrid.Rows(I).Cells(13).Value)
                                    ''    End If
                                    ''End If
                                Else
                                    Sw_ExisteCorrida = False
                                End If
                            End Using
                        End If
                        Margen = DGrid.Rows(I).Cells(6).Value
                        TipoCrrBus = IIf(IsNothing(DGrid.Rows(I).Cells(12).Value), "", DGrid.Rows(I).Cells(12).Value)
                        TipoCrr = CalcularTipoCrr(DGrid.Rows(I).Cells(0).Value.ToString, TipoCrrBus, Margen)
                        objDataSet = objCatalogoEstilos.Inserta_Corrida  'INSERTA NUEVO DATASET
                        Dim objDataRow As Data.DataRow = objDataSet.Tables(0).NewRow


                        objDataRow.Item("marca") = Trim(Txt_Marca.Text)
                        objDataRow.Item("estilon") = (Txt_Estilon.Text)
                        objDataRow.Item("corrida") = DGrid.Rows(I).Cells(0).Value.ToString
                        objDataRow.Item("intervalo") = DGrid.Rows(I).Cells(1).Value.ToString
                        objDataRow.Item("medini") = DGrid.Rows(I).Cells(2).Value.ToString
                        objDataRow.Item("medfin") = DGrid.Rows(I).Cells(3).Value.ToString
                        objDataRow.Item("costo") = (DGrid.Rows(I).Cells(4).Value)
                        '                        objDataRow.Item("precio") = (DGrid.Rows(I).Cells(5).Value)
                        objDataRow.Item("precio") = PrecioValor
                        ' NO SE GRABAN SI ES UNA MODIFICACIÓN
                        objDataRow.Item("ult_cmp") = "01-01-1900"
                        objDataRow.Item("ult_vta") = "01-01-1900"
                        objDataRow.Item("blofer") = ""
                        objDataRow.Item("tipocrr") = TipoCrr

                        '' objDataRow.Item("fechor") = Format(Now, "YYYY-MM-DD HH:MM:SS") ' Ver como se graba en la base de datos mysql

                        'Add the DataRow to the DataSet
                        objDataSet.Tables(0).Rows.Add(objDataRow)

                        'Add the Project
                        If Sw_ExisteCorrida = True Then
                            If Not objCatalogoEstilos.usp_Captura_Corrida(2, objDataSet) Then
                                If Accion <> 2 Then
                                    Throw New Exception("Falló Inserción de Corrida")
                                End If
                            End If
                        Else
                            If Not objCatalogoEstilos.usp_Captura_Corrida(1, objDataSet) Then
                                If Accion <> 2 Then
                                    Throw New Exception("Falló Inserción de Corrida")
                                End If
                            End If
                        End If
                        objDataSet.Dispose()
                        objDataRow.Table.Dispose()


                    Catch ExceptionErr As Exception
                        MessageBox.Show(ExceptionErr.Message.ToString)
                    End Try
                End Using
                If Accion = 2 Then
                    If Eliminar_Medida(Trim(Txt_Marca.Text), (Txt_Estilon.Text), DGrid.Rows(I).Cells(0).Value.ToString) = False Then
                        'pensar que poner
                    End If
                End If
                Call Genera_Medida(DGrid.Rows(I).Cells(2).Value.ToString, DGrid.Rows(I).Cells(3).Value.ToString, I)
            Next
            Inserta_Corrida = True
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function

    Function Inserta_CambPrec(ByVal CambPrec As String) As Boolean
        'mreyes 26/Abril/2012 06:13 p.m.
        Using objCambPrec As New BCL.BCLCatalogoEstilos(GLB_ConStringCipSis)
            'Get a new Project DataSet
            Try

                objDataSet = objCambPrec.Inserta_CambPrec  'INSERTA NUEVO DATASET
                'Initialize a datarow object from the Project DataSet
                Dim objDataRow As Data.DataRow = objDataSet.Tables(0).NewRow


                'Set the values in the DataRow

                objDataRow.Item("sucursal") = "99"
                objDataRow.Item("cambprec") = Trim(CambPrec)
                objDataRow.Item("status") = "PA"
                objDataRow.Item("fecha") = Now.Date
                objDataRow.Item("nivel") = "A"
                objDataRow.Item("mlfp") = ""
                objDataRow.Item("porcent") = 0
                objDataRow.Item("observa") = ""
                objDataRow.Item("usuario") = GLB_Usuario
                'Add the DataRow to the DataSet
                objDataSet.Tables(0).Rows.Add(objDataRow)

                'Add the Project
                ''If Not objCambPrec.usp_Captura_OrdeComp(Accion, objDataSet) Then
                ''    '' Throw New Exception("Falló Inserción de OrdeComp")
                ''Else
                ''    Inserta_CambPrec = True
                ''End If
                Inserta_CambPrec = True
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using

    End Function

    Function Inserta_Medida(ByVal Tipo As String, ByVal MedIni As String, ByVal Renglon As Integer) As Boolean
        'mreyes 23/Febrero/2012 01:01 p.m.


        Try
            Using objCatalogoEstilos As New BCL.BCLCatalogoEstilos(GLB_ConStringCipSis)
                objDataSet = objCatalogoEstilos.Inserta_Medida  'INSERTA NUEVO DATASET
                Dim objDataRow As Data.DataRow = objDataSet.Tables(0).NewRow
                'If Tipo = "N" Then
                '    If Mi < 10 Then
                '        MedIni = pub_RellenarIzquierda(Mi, 2)
                '    End If
                'End If
                objDataRow.Item("marca") = Trim(Txt_Marca.Text)
                objDataRow.Item("estilon") = (Txt_Estilon.Text)
                objDataRow.Item("medida") = MedIni
                objDataRow.Item("corrida") = DGrid.Rows(Renglon).Cells(0).Value.ToString
                objDataRow.Item("ctdcri") = 0
                objDataRow.Item("ctdide") = 0
                objDataRow.Item("ctdsol") = 0
                objDataRow.Item("orden") = "00"

                'Add the DataRow to the DataSet
                objDataSet.Tables(0).Rows.Add(objDataRow)





                If Not objCatalogoEstilos.usp_Captura_Medida(1, objDataSet) Then
                    If Accion <> 2 Then
                        Throw New Exception("Falló Inserción de Medida")
                    End If
                End If

            End Using
            Inserta_Medida = True
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function

    Function Genera_Medida(ByVal MedIni As String, ByVal MedFin As String, ByVal I As Integer) As Boolean
        'mreyes 23/Febrero/2012 12:42 p.m
        '' LA MEDIDA VA A CONSIDERACIÓN DEL INTERVALO... OJO PARA LOS NUMEROS 
        Try
            Dim MI As Integer = 0
            Dim MF As Integer = 0
            Dim Intervalo As String = ""
            Dim Inc As Integer = 0



            Select Case Mid(Cbo_Medida.Text, 1, 1)

                Case "N"
                    '' CASO DE NUMEROS 

                    MI = Val(DGrid.Rows(I).Cells(2).Value)
                    MF = Val(DGrid.Rows(I).Cells(3).Value)
                    Intervalo = DGrid.Rows(I).Cells(1).Value

                    For MI = Val(DGrid.Rows(I).Cells(2).Value) To MF
                        '' tomar en cuenta el intervalo para grabar el valor ...
                        If Intervalo <> "-" Then
                            Inc = Intervalo
                        Else
                            Inc = 1
                        End If
                        '' insertar medida 
                        Call Inserta_Medida("N", pub_RellenarIzquierda(MI, 2), I)
                        If Intervalo = "-" Then
                            Call Inserta_Medida("N", pub_RellenarIzquierda(MI, 2) + Intervalo, I)
                        End If
                        MI = MI + Inc - 1

                    Next

                Case Else
                    ' LETRS O SIN NADA 

                    Using objCatalogoEstilos As New BCL.BCLCatalogoEstilos(Glb_ConStringCipSis)
                        Try

                            Dim Medida As String = ""
                            Dim OrdeIni As String = DGrid.Rows(I).Cells("ordenini").Value
                            Dim OrdeFin As String = DGrid.Rows(I).Cells("ordenfin").Value

                            Dim objDataSet = objCatalogoEstilos.usp_TraerLetrasIniFin(OrdeIni, OrdeFin, Mid(Cbo_Medida.Text, 1, 1))

                            If objDataSet.Tables(0).Rows.Count > 0 Then
                                For z As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                                    Medida = objDataSet.Tables(0).rows(z).item("medida").ToString
                                    Call Inserta_Medida(Mid(Cbo_Medida.Text, 1, 1), Medida, I)
                                Next
                            End If
                        Catch ExceptionErr As Exception
                            MessageBox.Show(ExceptionErr.Message.ToString)
                        End Try
                    End Using


            End Select
            Genera_Medida = True
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function
    Private Sub usp_TraerCorrida(ByVal EstiloN As String)
        Using objCatalogoEstilos As New BCL.BCLCatalogoEstilos(GLB_ConStringCipSis)
            Try
                Dim Margen As Decimal
                Dim PComp As Decimal
                Dim Precio As Decimal
                objDataSet = objCatalogoEstilos.usp_TraerCorrida("", Txt_Marca.Text, EstiloN, "", Txt_Proveedor.Text)

                If objDataSet.Tables(0).Rows.Count > 0 Then

                    For I As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                        Costo = pub_CalcularCostoPedido((objDataSet.Tables(0).Rows(I).Item(6)), Val(Txt_Dsctopp.Text), Val(Txt_Dscto01.Text), Val(Txt_Dscto02.Text), Val(Txt_Dscto03.Text), Val(Txt_Dscto04.Text), Val(Txt_Dscto05.Text), Val(Txt_Iva.Text))
                        Precio = Val(objDataSet.Tables(0).Rows(I).Item("precio"))
                        PComp = Val(objDataSet.Tables(0).Rows(I).Item("costo"))
                        Margen = pub_CalcularMargenPedido(Precio, Costo)

                        DGrid.Rows.Add(objDataSet.Tables(0).Rows(I).Item(2).ToString, _
                                         objDataSet.Tables(0).Rows(I).Item(3).ToString, _
                                         objDataSet.Tables(0).Rows(I).Item(4).ToString, _
                                         objDataSet.Tables(0).Rows(I).Item(5).ToString, _
                                         Val(objDataSet.Tables(0).Rows(I).Item(6)), _
                                         Val(objDataSet.Tables(0).Rows(I).Item(7)), _
                                         Margen, _
                                         objDataSet.Tables(0).Rows(I).Item(10).ToString, _
                                         "", "", _
                                        objDataSet.Tables(0).Rows(I).Item(12).ToString, _
                                        objDataSet.Tables(0).Rows(I).Item(13).ToString, _
                                        objDataSet.Tables(0).Rows(I).Item(11).ToString, _
                                        Val(objDataSet.Tables(0).Rows(I).Item("precio")))


                    Next

                End If


            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub
    Private Function ValidarEdicion() As Boolean
        'mreyes 03/Marzo/2012 11:23 a.m. 
        ValidarEdicion = False
        Try
            If Txt_Marca.Text.Length = 0 Then
                MsgBox("Debe especificar una marca para el Estilo.", MsgBoxStyle.Critical, "Validación")
                Txt_Marca.Focus()
                Exit Function
            End If

            If Txt_Estilof.Text.Length = 0 Then
                MsgBox("Debe especificar el estilo de fábrica para el Estilo.", MsgBoxStyle.Critical, "Validación")
                Txt_Estilof.Focus()
                Exit Function
            End If

            If Txt_Descripc.Text.Length = 0 Then
                MsgBox("Debe especificar una descripción corta para el Estilo.", MsgBoxStyle.Critical, "Validación")
                Txt_Descripc.Focus()
                Exit Function
            End If

            If Txt_Familia.Text.Length = 0 Then
                MsgBox("Debe especificar una Familia para el Estilo.", MsgBoxStyle.Critical, "Validación")
                Txt_Familia.Focus()
                Exit Function
            End If

            If Txt_Linea.Text.Length = 0 Then
                MsgBox("Debe especificar una Línea para el Estilo.", MsgBoxStyle.Critical, "Validación")
                Txt_Linea.Focus()
                Exit Function
            End If

            If Txt_Proveedor.Text.Length = 0 Then
                MsgBox("Debe especificar un Proveedor para el Estilo.", MsgBoxStyle.Critical, "Validación")
                Txt_Proveedor.Focus()
                Exit Function
            End If

            If Txt_TipoArt.Text.Length = 0 Then
                MsgBox("Debe especificar un Tipo de Artículo para el Estilo.", MsgBoxStyle.Critical, "Validación")
                Txt_TipoArt.Focus()
                Exit Function
            End If

            If Txt_Categoria.Text.Length = 0 Then
                MsgBox("Debe especificar una Categoría para el Estilo.", MsgBoxStyle.Critical, "Validación")
                Txt_Categoria.Focus()
                Exit Function
            End If

            If Cbo_Medida.Text.Length = 0 Then
                MsgBox("Debe especificar una medida para el Estilo.", MsgBoxStyle.Critical, "Validación")
                Cbo_Medida.Focus()
                Exit Function
            End If

            If Cbo_AcepDevo.Text.Length = 0 Then
                MsgBox("Debe especificar si acepta o no devoluciones para el Estilo.", MsgBoxStyle.Critical, "Validación")
                Cbo_AcepDevo.Focus()
                Exit Function
            End If

            If Txt_Resmin.Text.Length = 0 Then
                MsgBox("Debe especificar el ResMin para el Estilo.", MsgBoxStyle.Critical, "Validación")
                Txt_Resmin.Focus()
                Exit Function
            End If

            '' validar corrida 
            With DGrid
                If .Rows(0).Cells(0).Value = "" Then
                    MsgBox("Debe especificar almenos una corrida para el Estilo.", MsgBoxStyle.Critical, "Validación")
                    DGrid.Focus()
                    Exit Function
                End If
            End With

            ValidarEdicion = True
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Function
    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click

        Try
            If Accion = 1 Then '''' es un articulo nuevo
                If ValidarEdicion() = False Then Exit Sub
                If MsgBox("Estas Seguro de Grabar el Artículo?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.Ok Then
                    If Inserta_Articulo() = True Then
                        If Inserta_Corrida() = True Then
                            MessageBox.Show("Exitosamente Grabado el estilo '" & Txt_Estilon.Text & "' para la marca '" & Txt_Marca.Text & " !", "Agregando Arículo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Sw_Registro = True
                            GLB_CatEsiloCancelado = False
                            Me.Close()
                            '' Me.Dispose()
                        Else
                            MessageBox.Show("Error Grabando !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End If
                End If
            ElseIf Accion = 2 Then 'es una actualización
                If ValidarEdicion() = False Then Exit Sub
                If MsgBox("Estas Seguro de Actualizar el Artículo?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.Ok Then
                    If Inserta_Articulo() = True Then
                        If Inserta_Corrida() = True Then
                            Sw_Registro = True
                            MessageBox.Show("Exitosamente Grabado el estilo '" & Txt_Estilon.Text & "' para la marca '" & Txt_Marca.Text & " !", "Agregando Arículo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Me.Close()
                            ' Me.Dispose()
                        Else
                            MessageBox.Show("Error Grabando !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                        GLB_RefrescarPedido = True
                    End If
                End If
            ElseIf Accion = 4 Then
                Me.Close()
                Me.Dispose()
            End If '' del if de accion = 1 

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Sub validar_Keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        '' FUNCION PARA SOLO ESCRIBIR LETRAS EN UN DATAGRID 
        Try
            ' obtener indice de la columna  
            If Accion = 3 Or Accion = 4 Then
                e.KeyChar = Chr(0)
                Exit Sub
            End If
            e.KeyChar = UCase(e.KeyChar)
            Dim columna As Integer = DGrid.CurrentCell.ColumnIndex
            Dim caracter As Char = e.KeyChar
            ' comprobar si la celda en edición corresponde a la columna 1 o 3   

            If columna = 0 Then ''columna de corrida

                ' Obtener caracter   


                ' comprobar si el caracter es un número o el retroceso   
                If Char.IsNumber(caracter) And (caracter = ChrW(Keys.Back)) = False Then
                    'Me.Text = e.KeyChar   
                    e.KeyChar = Chr(0)
                Else
                    If caracter = "A" Or caracter = "B" Or caracter = "C" Or caracter = "D" Or caracter = "E" Or caracter = "F" Then
                        e.KeyChar = UCase(caracter)
                    Else
                        e.KeyChar = Chr(0)
                    End If
                End If
            End If

            If columna = 1 Then '' columna de i
                If Mid(Cbo_Medida.Text, 1, 1) = "N" Then
                    If Not Char.IsNumber(caracter) And (caracter = ChrW(Keys.Back)) = False And Not caracter = "-" Then
                        e.KeyChar = Chr(0)
                    End If


                End If
            End If

            ''If Accion <> 1 Then
            ''    If columna = 5 Then
            ''        e.KeyChar = Chr(0)
            ''    End If
            ''End If

            If columna >= 4 And columna <= 5 Then

                If Not Char.IsNumber(caracter) And (caracter = ChrW(Keys.Back)) = False And Not (caracter = ".") Then
                    e.KeyChar = Chr(0)
                End If
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellDoubleClick

    End Sub

    Private Sub DGrid_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellEndEdit
        'mreyes 23/Febrero/2012 11:40 a.m.
        Try
            Dim columna As Integer = DGrid.CurrentCell.ColumnIndex
            Dim renglon As Integer = DGrid.CurrentCell.RowIndex
            If columna = 1 Then
                If Mid(Cbo_Medida.Text, 1, 1) <> "N" Then
                    If DGrid.Rows(renglon).Cells(columna).Value <> "L" Then
                        MsgBox("El intervalo en la medida '" & Cbo_Medida.Text & "' es L.", MsgBoxStyle.Critical, "Validación")
                        DGrid.Rows(renglon).Cells(columna).Value = "L"
                    End If

                End If
            End If

            If columna = 2 Or columna = 3 Then
                '' VALIDAR LO QUE SE ESTA ESCRIBIENDO SI

                If Mid(Cbo_Medida.Text, 1, 1) = "N" Then
                    If Not IsNumeric(DGrid.Rows(renglon).Cells(columna).Value) Then
                        MsgBox("Debe especificar un número valido para la corrida.", MsgBoxStyle.Critical, "Validación")
                    End If
                    DGrid.Rows(renglon).Cells(columna).Value = pub_RellenarIzquierda(DGrid.Rows(renglon).Cells(columna).Value, 2)
                End If

                If Mid(Cbo_Medida.Text, 1, 1) <> "N" Then
                    If IsNumeric(DGrid.Rows(renglon).Cells(columna).Value) And Mid(Cbo_Medida.Text, 1, 1) = "L" Then
                        MsgBox("Debe especificar una letra válido para la corrida.", MsgBoxStyle.Critical, "Validación")
                    Else
                        Txt_Campo.Text = DGrid.Rows(renglon).Cells(columna).Value
                        Txt_Campo1.Text = Mid(Cbo_Medida.Text, 1, 1)
                        Call TxtGrid(Txt_Campo, Txt_Campo1, "LT")
                        DGrid.Rows(renglon).Cells(columna).Value = Txt_Campo1.Text
                        If columna = 2 Then
                            DGrid.Rows(renglon).Cells("ordenini").Value = Txt_Campo.Text
                        Else
                            DGrid.Rows(renglon).Cells("ordenfin").Value = Txt_Campo.Text
                        End If

                    End If
                End If
            End If

            If columna = 4 Then
                '' calcular el costo
                DGrid.Rows(renglon).Cells(5).Value = pub_CalcularPrecioVenta(DGrid.Rows(renglon).Cells(4).Value, Val(Txt_Factor.Text))
                Costo = pub_CalcularCostoPedido(DGrid.Rows(renglon).Cells(4).Value, Val(Txt_Dsctopp.Text), Val(Txt_Dscto01.Text), Val(Txt_Dscto02.Text), Val(Txt_Dscto03.Text), Val(Txt_Dscto04.Text), Val(Txt_Dscto05.Text), Val(Txt_Iva.Text))

                DGrid.Rows(renglon).Cells(6).Value = pub_CalcularMargenPedido((DGrid.Rows(renglon).Cells(5).Value), Costo)
            End If
            If columna = 5 Then
                Costo = pub_CalcularCostoPedido(DGrid.Rows(renglon).Cells(4).Value, Val(Txt_Dsctopp.Text), Val(Txt_Dscto01.Text), Val(Txt_Dscto02.Text), Val(Txt_Dscto03.Text), Val(Txt_Dscto04.Text), Val(Txt_Dscto05.Text), Val(Txt_Iva.Text))
                DGrid.Rows(renglon).Cells(6).Value = pub_CalcularMargenPedido((DGrid.Rows(renglon).Cells(5).Value), Costo)


            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub TxtGrid(ByVal Txt_Campo As TextBox, ByVal Txt_Campo1 As TextBox, ByVal Tipo As String)
        'mreyes 23/Febrero/2012 11:50 a.m.
        Dim myForm As New frmConsulta
        If Txt_Campo.Text.Length = 0 Then Exit Sub
        Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringCipSis)
            Try
                objDataSet = objMySqlGral.usp_TraerDescripcion(Tipo, Txt_Campo.Text, Txt_Campo1.Text)
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_Campo1.Text = objDataSet.Tables(0).Rows(0).Item("campo").ToString
                Else
                    Txt_Campo.Text = ""
                    If Tipo <> "E" Then
                        myForm.Campo1 = Txt_Campo1.Text
                        myForm.Tipo = Tipo
                        myForm.ShowDialog()
                        Txt_Campo.Text = myForm.Campo
                        Txt_Campo1.Text = myForm.Campo1
                        ''If Txt_Campo.Text.Length = 0 Then
                        ''    Txt_Campo.Focus()
                        ''End If

                    End If
                End If


            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub DGrid_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGrid.CurrentCellDirtyStateChanged
        'mreyes 17/Febrero/2012 05:32 p.m.
        Try

            Dim columna As Integer = DGrid.CurrentCell.ColumnIndex
            Dim renglon As Integer = DGrid.CurrentCell.RowIndex
            Dim Importe As Double

            If columna = 4 Or columna = 5 Then
                If DGrid.Rows(renglon).Cells(4).Value <> 0 And DGrid.Rows(renglon).Cells(5).Value <> 0 Then
                    Importe = DGrid.Rows(renglon).Cells(4).Value
                    DGrid.Rows(renglon).Cells(4).Value = Format(Importe, "#,##0.00")
                    Importe = DGrid.Rows(renglon).Cells(5).Value
                    DGrid.Rows(renglon).Cells(5).Value = Format(Importe, "#,##0.00")
                    Costo = pub_CalcularCostoPedido(DGrid.Rows(renglon).Cells(4).Value, Val(Txt_Dsctopp.Text), Val(Txt_Dscto01.Text), Val(Txt_Dscto02.Text), Val(Txt_Dscto03.Text), Val(Txt_Dscto04.Text), Val(Txt_Dscto05.Text), Val(Txt_Iva.Text))

                    DGrid.Rows(renglon).Cells(6).Value = Format(pub_CalcularMargenPedido((DGrid.Rows(renglon).Cells(5).Value), Costo), "#0.00")
                End If
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub DGrid_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DGrid.EditingControlShowing
        Dim validar As TextBox = CType(e.Control, TextBox)
        Try
            ' agregar el controlador de eventos para el KeyPress   

            AddHandler validar.KeyPress, AddressOf validar_Keypress
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub frmCatalogoEstilos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'GLB_CatEsiloCancelado = True
    End Sub

    Private Sub frmCatalogoEstilos_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ' GLB_CatEsiloCancelado = True
    End Sub

    Private Sub frmCatalogoEstilos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then
                If Accion = 1 Or Accion = 2 Then
                    If MessageBox.Show("Estas seguro de cancelar el registro ?", "Confirmar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
                        Me.Dispose()
                        Me.Close()
                        GLB_CatEsiloCancelado = True
                    End If
                Else
                    Me.Dispose()
                    Me.Close()
                    GLB_CatEsiloCancelado = True
                End If
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub




    Private Sub frmCatalogoEstilos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Accion = 2

            Call GenerarToolTip()

            DGrid.RowHeadersVisible = False
            Call Edicion()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub usp_TraerEstilo()
        Using objCatalogoEstilos As New BCL.BCLCatalogoEstilos(GLB_ConStringCipSis)
            Try


                objDataSet = objCatalogoEstilos.usp_TraerEstilo(0, Txt_Marca.Text, Txt_Estilon.Text, Txt_Estilof.Text, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Txt_Proveedor.Text, "")

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_Marca.Text = objDataSet.Tables(0).Rows(0).Item("marca").ToString
                    Txt_DescripMarca.Text = objDataSet.Tables(0).Rows(0).Item("descripmarca").ToString
                    Txt_Estilon.Text = objDataSet.Tables(0).Rows(0).Item("estilon").ToString
                    Txt_Estilof.Text = objDataSet.Tables(0).Rows(0).Item("estilof").ToString
                    Txt_Descripc.Text = objDataSet.Tables(0).Rows(0).Item("descripc").ToString
                    Txt_Familia.Text = objDataSet.Tables(0).Rows(0).Item("familia").ToString
                    Txt_DescripFamilia.Text = objDataSet.Tables(0).Rows(0).Item("descripfamilia").ToString
                    Txt_Linea.Text = objDataSet.Tables(0).Rows(0).Item("linea").ToString
                    Txt_DescripLinea.Text = objDataSet.Tables(0).Rows(0).Item("descriplinea").ToString
                    Txt_Proveedor.Text = objDataSet.Tables(0).Rows(0).Item("proveedor").ToString
                    Txt_Raz_Soc.Text = objDataSet.Tables(0).Rows(0).Item("raz_soc").ToString
                    Txt_TipoArt.Text = objDataSet.Tables(0).Rows(0).Item("tipoart").ToString
                    Txt_DescripTipoArt.Text = objDataSet.Tables(0).Rows(0).Item("descriptipoart").ToString
                    Txt_Categoria.Text = objDataSet.Tables(0).Rows(0).Item("categoria").ToString
                    Txt_DescripCategoria.Text = objDataSet.Tables(0).Rows(0).Item("descripcategoria").ToString
                    Txt_DescripL.Text = objDataSet.Tables(0).Rows(0).Item("descripl").ToString
                    If Sw_PedidoNuevo = False Then
                        Txt_Dsctopp.Text = objDataSet.Tables(0).Rows(0).Item("dsctopp").ToString
                        Txt_Dscto01.Text = objDataSet.Tables(0).Rows(0).Item("dscto01").ToString
                        Txt_Dscto02.Text = objDataSet.Tables(0).Rows(0).Item("dscto02").ToString
                        Txt_Dscto03.Text = objDataSet.Tables(0).Rows(0).Item("dscto03").ToString
                        Txt_Dscto04.Text = objDataSet.Tables(0).Rows(0).Item("dscto04").ToString
                        Txt_Dscto05.Text = objDataSet.Tables(0).Rows(0).Item("dscto05").ToString
                        Txt_Iva.Text = "16"
                    End If
                    Txt_Factor.Text = objDataSet.Tables(0).Rows(0).Item("factor").ToString


                    If objDataSet.Tables(0).Rows(0).Item("medida").ToString = "N" Then
                        Cbo_Medida.Text = "NÚMEROS"
                    ElseIf objDataSet.Tables(0).Rows(0).Item("medida").ToString = "L" Then
                        Cbo_Medida.Text = "LETRAS"
                    Else
                        Cbo_Medida.Text = "SIN MEDIDA"
                    End If

                    If objDataSet.Tables(0).Rows(0).Item("acepdevo").ToString = "S" Then
                        Cbo_AcepDevo.Text = "SI"
                    Else
                        Cbo_AcepDevo.Text = "NO"
                    End If

                    Txt_Resmin.Text = objDataSet.Tables(0).Rows(0).Item("resmin").ToString
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub
    Private Sub GenerarToolTip()
        Try
            ToolTip.SetToolTip(Btn_Aceptar, "Aceptar la acción requerida por el usuario")
            ToolTip.SetToolTip(Btn_Cancelar, "Cancelar cualquier acción requerida por el usuario")
            ToolTip.SetToolTip(Btn_Nuevo, "Nuevo Artículo")
            ToolTip.SetToolTip(Btn_Editar, "Editar Artículo")
            ToolTip.SetToolTip(DGrid, "Detallado de corridas del Artículo")
            ToolTip.SetToolTip(Btn_NuevoF, "Nueva Foto")
            ToolTip.SetToolTip(Btn_EliminarF, "Eliminar Foto")
            ToolTip.SetToolTip(Btn_Ant, "Foto Anterior")
            ToolTip.SetToolTip(Btn_Sig, "Foto Siguiente")
            ToolTip.SetToolTip(Btn_AceptarF, "Guardar Foto")

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub LimpiarDatos()
        Try
            Txt_Marca.Text = ""
            Txt_Estilon.Text = ""
            Txt_Estilof.Text = ""
            Txt_Descripc.Text = ""
            Txt_Familia.Text = ""
            Txt_Linea.Text = ""
            Txt_Proveedor.Text = ""
            Txt_TipoArt.Text = ""
            Txt_Categoria.Text = ""
            Txt_DescripL.Text = ""
            Cbo_Medida.Text = ""
            Cbo_AcepDevo.Text = ""
            Txt_Resmin.Text = ""
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub

    Private Sub Txt_Descripc_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Descripc.GotFocus
        ''  Me.Txt_Descripc.SelectionStart = 0
        '' Me.Txt_Descripc.SelectionLength = Len(Me.Txt_Descripc.Text.Length)
        Txt_Descripc.SelectAll()
    End Sub

    Private Sub Txt_Descripc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Descripc.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")

        End If
    End Sub

    Private Sub Txt_Descripc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Descripc.LostFocus
        Txt_DescripL.Text = Txt_Descripc.Text
    End Sub

    Private Sub Txt_Descripc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Descripc.TextChanged
        ''If Txt_Descripc.Text.Length = 30 Then
        ''    Txt_Familia.Focus()
        ''End If
    End Sub

    Private Sub Txt_Marca_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Marca.LostFocus




    End Sub


    Private Sub Txt_Estilon_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Estilon.GotFocus
        Txt_Estilon.SelectAll()
    End Sub

    Private Sub Txt_Estilon_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Estilon.KeyPress

    End Sub


    Private Sub Txt_Estilof_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Estilof.GotFocus
        Txt_Estilof.SelectAll()
    End Sub

    Private Sub Txt_Estilof_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txt_Estilof.KeyDown

    End Sub

    Private Sub Txt_Estilof_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Estilof.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_Estilof_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Estilof.LostFocus
        If Accion <> 2 Then
            If Sw_PedidoNuevo = False Then
                Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringCipSis)
                    Try
                        Dim estilof As String = ""
                        estilof = Replace(Txt_Estilof.Text, "-", "")

                        If Txt_Estilof.Text.Length = 0 Then Exit Sub
                        objDataSet = objMySqlGral.usp_TraerDescripcion("EN", Txt_Marca.Text, estilof)

                        If objDataSet.Tables(0).Rows.Count > 0 Then
                            MsgBox("El estilo de fábrica '" & estilof & "' para a marca '" & Txt_Marca.Text & "' ya se encuentra registrado con el estilo nuestro '" & objDataSet.Tables(0).Rows(0).Item("campo").ToString & "'. Con la descripción '" & objDataSet.Tables(0).Rows(0).Item("descripc").ToString & ".", MsgBoxStyle.Information, "Aviso")

                        End If


                    Catch ExceptionErr As Exception
                        MessageBox.Show(ExceptionErr.Message.ToString)
                    End Try
                End Using
            End If
        End If
    End Sub

    Private Sub Txt_Estilof_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Estilof.TextChanged
        If Accion <> 2 Then
            Txt_Descripc.Text = Txt_Estilof.Text
        End If
        If Txt_Estilof.Text.Length = 14 Then
            Txt_Descripc.Focus()
        End If
    End Sub

    Private Sub Txt_Linea_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Linea.GotFocus
        Txt_Linea.SelectAll()
    End Sub

    Private Sub Txt_Linea_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Linea.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub






    Private Sub Txt_TipoArt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_TipoArt.GotFocus
        Txt_TipoArt.SelectAll()
    End Sub

    Private Sub Txt_TipoArt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_TipoArt.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_TipoArt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_TipoArt.LostFocus
        'mreyes 23/Febrero/2012 12:07 p.m.
        Try
            If Txt_TipoArt.Text.Length = 0 Then Exit Sub
            Call TxtLostfocus(Txt_TipoArt, Txt_DescripTipoArt, "TA")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub



    Private Sub Txt_Categoria_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Categoria.GotFocus
        Txt_Categoria.SelectAll()
    End Sub

    Private Sub Txt_Categoria_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Categoria.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_DescripL_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_DescripL.GotFocus
        Txt_DescripL.SelectAll()
    End Sub



    Private Sub Txt_DescripL_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_DescripL.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_Categoria_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Categoria.LostFocus

        Try
            If Txt_Categoria.Text.Length = 0 Then Exit Sub

            If Txt_Categoria.Text.Trim.Length < 3 Then
                Txt_Categoria.Text = pub_RellenarIzquierda(Txt_Categoria.Text.Trim, 3)
            End If
            Call TxtLostfocus(Txt_Categoria, Txt_DescripCategoria, "C")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub Txt_Resmin_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Resmin.GotFocus
        Txt_Resmin.SelectAll()
    End Sub

    Private Sub TxtLostfocus(ByVal Txt_Campo As TextBox, ByVal Txt_Campo1 As TextBox, ByVal Tipo As String)
        Dim myForm As New frmConsulta
        If Txt_Campo.Text.Length = 0 Then Exit Sub
        Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringCipSis)
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

    Private Sub Txt_Proveedor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Proveedor.TextChanged
        If Txt_Proveedor.Text.Length = 3 Then
            Txt_TipoArt.Focus()
        End If
    End Sub



    Private Sub Btn_Nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Nuevo.Click
        Try
            Accion = 1
            Call Edicion()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub
    Private Sub Edicion()
        Try
            Select Case Accion
                Case 3, 4
                    Btn_Aceptar.Enabled = True
                    Btn_Cancelar.Enabled = True
                    Btn_Nuevo.Enabled = True
                    Btn_Editar.Enabled = True

                    ' Pnl_Edicion.Enabled = False

                    Txt_Marca.BackColor = TextboxBackColor
                    Txt_Marca.BackColor = TextboxBackColor
                    Txt_Estilon.BackColor = TextboxBackColor
                    Txt_Estilof.BackColor = TextboxBackColor
                    Txt_Descripc.BackColor = TextboxBackColor
                    Txt_Familia.BackColor = TextboxBackColor
                    Txt_Linea.BackColor = TextboxBackColor
                    Txt_Proveedor.BackColor = TextboxBackColor
                    Txt_TipoArt.BackColor = TextboxBackColor
                    Txt_Categoria.BackColor = TextboxBackColor
                    Txt_DescripL.BackColor = TextboxBackColor
                    Cbo_Medida.BackColor = TextboxBackColor
                    Cbo_AcepDevo.BackColor = TextboxBackColor
                    Txt_Resmin.BackColor = TextboxBackColor

                    ' no dar de alta fotos 

                    Btn_AceptarF.Enabled = False
                    Btn_EliminarF.Enabled = False
                    Btn_NuevoF.Enabled = False

                Case 1, 2
                    Btn_Aceptar.Enabled = True
                    Btn_Cancelar.Enabled = True
                    Btn_Nuevo.Enabled = False
                    Btn_Editar.Enabled = False

                    Pnl_Grid.Enabled = True
                    Pnl_Grid.Enabled = True
                   
                    Txt_Marca.Focus()


            End Select
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub



    Private Sub Btn_Editar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Editar.Click
        Accion = 2
        Call Edicion()
    End Sub



    Private Sub Btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cancelar.Click
        Try

            If Accion = 1 Or Accion = 2 Then
                If MessageBox.Show("Estas seguro de cancelar el registro ?", "Confirmar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
                    'Me.Dispose()
                    Me.Close()
                End If
            Else

                Me.Close()
                Me.Dispose()
            End If
            GLB_CATESILOCANCELADO = True
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub



    Private Sub DGrid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DGrid.KeyPress


        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private Function Eliminar_Medida(ByVal Marca As String, ByVal Estilon As String, ByVal corrida As String) As Boolean
        'mreyes 23/Febrero/2012 03:47 p.m.
        'marca, estilo, medida, corrida
        Using objCatalogoEstilos As New BCL.BCLCatalogoEstilos(Glb_ConStringCipSis)
            Try
                'Get the specific project selected in the ListView control
                Eliminar_Medida = objCatalogoEstilos.usp_EliminarMedida(Marca, Estilon, corrida)
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function

    Private Sub Pnl_Foto_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Pnl_Foto.Paint

    End Sub
    Private Sub CargarFotoArticulo()
        'mreyes 02/Marzo/2012 04:12 p.m.
        'Glb_RutaArchivoFotos
        Try
            Dim Archivo As String = ""
            Dim NoFoto As String = "1"

            Using objIO As New BCL.BCLio(Glb_ConStringCipSis)

                Archivo = objIO.pub_ArmarNombreFotoEstilo(Glb_RutaArchivoFotos, Txt_Marca.Text, Txt_Estilon.Text, NoFoto)
                Txt_NoFoto.Text = NoFoto
                If objIO.pub_ExisteArchivo(Archivo) = True Then
                    PBox.Image = New System.Drawing.Bitmap(Archivo)
                    Exit Sub
                End If

                For i As Integer = 0 To 9
                    Txt_NoFoto.Text = i
                    Archivo = objIO.pub_ArmarNombreFotoEstilo(Glb_RutaArchivoFotos, Txt_Marca.Text, Txt_Estilon.Text, i)
                    If objIO.pub_ExisteArchivo(Archivo) = True Then
                        PBox.Image = New System.Drawing.Bitmap(Archivo)
                        Exit Sub
                    End If
                Next

                Txt_NoFoto.Text = 1
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub Btn_Sig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Sig.Click
        'mreyes 02/Marzo/2012 04:57 p.m.
        Try
            If Val(Txt_NoFoto.Text) < 9 Then
                Txt_NoFoto.Text = Val(Txt_NoFoto.Text) + 1
            End If
            If TraerFoto(Txt_NoFoto.Text) = False Then
                Txt_NoFoto.Text = Val(Txt_NoFoto.Text) - 1
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Function TraerFoto(ByVal NoFoto As String) As Boolean
        'mreyes 02/Marzo/2012 04:57 p.m.
        Try
            TraerFoto = False
            Dim Archivo As String = ""
            Using objIO As New BCL.BCLio(GLB_ConStringCipSis)
                Archivo = objIO.pub_ArmarNombreFotoEstilo(GLB_RutaArchivoFotos, Txt_Marca.Text, Txt_Estilon.Text, NoFoto)
                If objIO.pub_ExisteArchivo(Archivo) = True Then
                    PBox.Image = New System.Drawing.Bitmap(Archivo)
                    TraerFoto = True
                    Exit Function
                End If
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function

    Private Sub Btn_Ant_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Ant.Click
        Try
            If Val(Txt_NoFoto.Text) <> 1 Then
                If Val(Txt_NoFoto.Text) <= 9 And Val(Txt_NoFoto.Text > 0) Then
                    Txt_NoFoto.Text = Val(Txt_NoFoto.Text) - 1
                End If
            End If
            If TraerFoto(Txt_NoFoto.Text) = False Then
                If Txt_NoFoto.Text <> 1 Then
                    Txt_NoFoto.Text = Val(Txt_NoFoto.Text) - 1
                End If

            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub





    Private Sub Btn_AceptarF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_AceptarF.Click
        'mreyes 02/Marzo/2012 05:32 p.m.
        Try
            Dim RutaOrigen As String = ""
            Dim RutaDestino As String = ""

            '' BUSCAR LA IMAGEN... SI LA ENCUENTRA PREGUNTAR PARA EDITARLA SINO DARLA DE ALTA CON UN NUMERO MAS 

            If MsgBox("Esta seguro de querer guardar la imagen para el estilo.?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.No Then Exit Sub


            Using objIO As New BCL.BCLio(GLB_ConStringCipSis)
                RutaOrigen = Txt_Ruta.Text
                RutaDestino = ""
                RutaDestino = objIO.pub_ArmarNombreFotoEstilo(GLB_RutaArchivoFotos, Txt_Marca.Text, Txt_Estilon.Text, Txt_NoFoto.Text)

                If objIO.pub_ExisteArchivo(RutaDestino) = True Then
                    '' ya existe 
                    If MsgBox("Esta seguro de querer modificar la foto '" & Txt_NoFoto.Text & "' del estilo '" & Txt_Estilon.Text & " para la marca '" & Txt_Marca.Text & "'?. En caso contrario se registrará como nueva.", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.Yes Then
                        ''sobreescribir la que ya existe 
                        objIO.pub_RenombrarArchivo(RutaDestino, objIO.pub_NombreArchivo(objIO.pub_ArmarNombreFotoEstilo(GLB_RutaArchivoFotos, Txt_Marca.Text, Txt_Estilon.Text, "99")))
                        objIO.pub_EliminarArchivo(objIO.pub_ArmarNombreFotoEstilo(GLB_RutaArchivoFotos, Txt_Marca.Text, Txt_Estilon.Text, "99"))
                        ' CambiarArchivo(RutaOrigen, RutaDestino)
                        objIO.pub_CopiarArchivo(RutaOrigen, RutaDestino)
                        If Inserta_ArtFotos(2) = False Then
                            MsgBox("No se pudo grabar correctamente la imagen.", MsgBoxStyle.Critical, "Aviso")
                        End If
                    Else
                        RutaDestino = objIO.pub_ArmarNombreFotoEstilo(GLB_RutaArchivoFotos, Txt_Marca.Text, Txt_Estilon.Text, BuscarImagenSig)
                        '                        CambiarArchivo(RutaOrigen, RutaDestino)
                        objIO.pub_CopiarArchivo(RutaOrigen, RutaDestino)
                        If Inserta_ArtFotos(1) = False Then
                            MsgBox("No se pudo grabar correctamente la imagen.", MsgBoxStyle.Critical, "Aviso")
                        End If
                    End If
                Else
                    RutaDestino = objIO.pub_ArmarNombreFotoEstilo(GLB_RutaArchivoFotos, Txt_Marca.Text, Txt_Estilon.Text, BuscarImagenSig)
                    'CambiarArchivo(RutaOrigen, RutaDestino)
                    objIO.pub_CopiarArchivo(RutaOrigen, RutaDestino)
                    If Inserta_ArtFotos(1) = False Then
                        MsgBox("No se pudo grabar correctamente la imagen.", MsgBoxStyle.Critical, "Aviso")
                    End If
                End If
                RutaOrigen = Txt_Ruta.Text



                ' objIO.pub_CopiarArchivo(RutaOrigen, RutaDestino)
            End Using

            MsgBox("Archivo correctamente grabado en la ruta '" & RutaDestino & "'", MsgBoxStyle.Information, "Confirmación")
            ''  Btn_Aceptar.Enabled = False
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Function BuscarImagenSig() As String
        'mreyes 02/Marzo/2012 06:04 p.m.
        Try
            Dim Archivo As String = ""
            BuscarImagenSig = Txt_NoFoto.Text
            Using objIO As New BCL.BCLio(Glb_ConStringCipSis)
                For i As Integer = Val(Txt_NoFoto.Text) To 9

                    Archivo = objIO.pub_ArmarNombreFotoEstilo(GLB_RutaArchivoFotos, Txt_Marca.Text, Txt_Estilon.Text, i)
                    If objIO.pub_ExisteArchivo(Archivo) = False Then

                        BuscarImagenSig = i
                        Txt_NoFoto.Text = BuscarImagenSig
                        Exit Function
                    End If
                Next
            End Using
            BuscarImagenSig = 1
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function

    Private Sub CambiarArchivo(ByVal RutaOrigen As String, ByVal RutaDestino As String)
        'mreyes 03/Marzo/2012 09:17 a.m.
        ' Extraer primero el tipo de extención para agrandar la imagen
        'InStrRev()
        Dim Extension As String = ""
        Try
            Dim g As GBITMAPLib.GBitmap
            Using objIO As New BCL.BCLio(Glb_ConStringCipSis)
                Extension = objIO.pub_ExtensionArchivo(RutaOrigen)
                g = New GBITMAPLib.GBitmap
                If UCase(Extension) = ".BMP" Then
                    g.LoadFileBmp(RutaOrigen)
                Else
                    g.LoadFileJpg(RutaOrigen, 360)
                End If
                'g.Resize(320, 240)
                g.SaveFileJpg(RutaDestino)
                g = Nothing
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_NuevoF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_NuevoF.Click
        'mreyes 02/Marzo/2012 05:38 p.m.
        Try
            OpenFileDialog.Filter = "img files (*.jpg)|*.jpg|All files (*.*)|*.*"
            OpenFileDialog.FileName = ""
            OpenFileDialog.ShowDialog()
            If OpenFileDialog.FileName = "" Then Exit Sub
            PBox.Image = New System.Drawing.Bitmap(OpenFileDialog.FileName)
            Txt_Ruta.Text = OpenFileDialog.FileName
            If Txt_Ruta.Text.Length > 0 Then
                Btn_AceptarF.Enabled = True

            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub

    Private Sub PBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBox.Click

    End Sub

    Private Sub PBox_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles PBox.DoubleClick
        'mreyes 03/Marzo/2012 10:01 a.m.
        Try
            Dim myForm As New frmConsultaImagen
            myForm.Txt_Estilon.Text = Txt_Estilon.Text
            myForm.Txt_Marca.Text = Txt_Marca.Text
            myForm.Txt_NoFoto.Text = Txt_NoFoto.Text
            myForm.ShowDialog()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellContentClick

    End Sub

    Private Sub Btn_EliminarF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_EliminarF.Click
        Try
            If MsgBox("Esta seguro de querer eliminar la imagen.?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.Yes Then
                Using objIO As New BCL.BCLio(Glb_ConStringCipSis)
                    PBox.Image = Nothing
                    objIO.pub_EliminarArchivo(objIO.pub_ArmarNombreFotoEstilo(Glb_RutaArchivoFotos, Txt_Marca.Text, Txt_Estilon.Text, BuscarImagenSig))
                End Using
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Function Inserta_ArtFotos(ByVal Opcion As Integer) As Boolean
        'mreyes 26/Marzo/2012 04:10 p.m.

        Using objCatalogoEstilos As New BCL.BCLCatalogoEstilos(GLB_ConStringCipSis)
            'Get a new Project DataSet
            Try
                objDataSet = objCatalogoEstilos.Inserta_ArtFotos  'INSERTA NUEVO DATASET
                'Initialize a datarow object from the Project DataSet
                Dim objDataRow As Data.DataRow = objDataSet.Tables(0).NewRow

                'Set the values in the DataRow

                objDataRow.Item("marca") = Trim(Txt_Marca.Text)
                objDataRow.Item("estilon") = (Txt_Estilon.Text)
                objDataRow.Item("fotoart") = Txt_NoFoto.Text
                objDataRow.Item("fecha") = Format(Now.Date, "yyyyMMdd")
                objDataRow.Item("hora") = Format(Now, "hh:mm:ss")
                'Add the DataRow to the DataSet
                objDataSet.Tables(0).Rows.Add(objDataRow)

                'Add the Project
                If Not objCatalogoEstilos.usp_Captura_ArtFotos(Opcion, objDataSet) Then
                    Throw New Exception("Falló Inserción de Artículo")
                Else
                    Inserta_ArtFotos = True
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function



    Private Sub Txt_Estilon_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Estilon.LostFocus
        If Txt_Estilon.Text.Length = 0 Then Exit Sub
        Txt_Estilon.Text = Txt_Estilon.Text.PadLeft(7)
        Call usp_TraerEstilo()
        Call usp_TraerCorrida(Txt_Estilon.Text)
        Call CargarFotoArticulo()



    End Sub


    Private Function CalcularTipoCrr(ByVal Corrida As String, ByVal TipoCrr As String, ByVal Margen As Decimal) As String
        'mreyes 13/Abril/2012 11:47 a.m.
        Using objPedidos As New BCL.BCLCatalogoEstilos(GLB_ConStringCipSis)
            Try
                Dim objDataSet As Data.DataSet

                CalcularTipoCrr = ""

                Dim pTipo As String = ""
                Dim ptcr As String = ""
                objDataSet = objPedidos.usp_TraerClasifMargen
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    For I As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                        If "7" <= TipoCrr And TipoCrr <= "9" Then
                            pTipo = "7"
                        ElseIf "4" <= TipoCrr And TipoCrr <= "6" Then
                            pTipo = "4"
                        ElseIf TipoCrr = "" Then
                            pTipo = "7"
                        Else
                            pTipo = "1"
                        End If
                        ptcr = Trim(Str(pTipo + (3 - Val(objDataSet.Tables(0).Rows(0).Item("orden")))))
                        If Margen >= objDataSet.Tables(0).Rows(0).Item("porcent") And ptcr <> TipoCrr Then
                            CalcularTipoCrr = ptcr
                            Exit Function
                        End If
                    Next
                End If




            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
                CalcularTipoCrr = ""
            End Try
        End Using
    End Function
    Private Sub CalcularMargen1(ByVal Corrida As String, ByVal PComp As Decimal, ByVal Precio As Decimal, ByVal TipoCrr As String)
        'mreyes 13/Abril/2012 09:48 a.m.
        Using objPedidos As New BCL.BCLCatalogoEstilos(GLB_ConStringCipSis)
            Try
                Dim objDataSet As Data.DataSet
                Dim Costo As Decimal = 0
                Dim Porcent As Decimal = 0
                Dim Fecha As Date = Format(Now.Date, "yyyy-MM-dd")
                Dim Pporce As Decimal = 0
                Dim pmgn As Decimal = 0
                objDataSet = objPedidos.usp_TraerCostosxMarca(Txt_Marca.Text, "")
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    For I As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                        Costo = Costo * (100 + objDataSet.Tables(0).Rows(0).Item("porcent")) / 100
                    Next
                End If

                objDataSet = objPedidos.usp_TraerCostosGrales(Txt_Marca.Text)
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    For I As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                        Costo = Costo * (100 + objDataSet.Tables(0).Rows(0).Item("porcent")) / 100
                    Next
                End If

                'CALCULO DEL PRECIO TOMANDO BOLETINES DE OFERTA VIGENTES'
                objDataSet = objPedidos.usp_TraerPorcenBoletin(Txt_Marca.Text, Txt_Estilon.Text, Corrida, Fecha)
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    If objDataSet.Tables(0).Rows(0).Item("porcent") > Pporce Then
                        Pporce = objDataSet.Tables(0).Rows(0).Item("porcent")
                    End If
                End If

                '' POR TODOS LOS BOLETINES 

                objDataSet = objPedidos.usp_TraerPorcenBoletinNivel(Txt_Marca.Text, Txt_Estilon.Text, Corrida, Fecha, "M")
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    If objDataSet.Tables(0).Rows(0).Item("porcent") > Pporce Then
                        Pporce = objDataSet.Tables(0).Rows(0).Item("porcent")

                    End If
                End If
                objDataSet = objPedidos.usp_TraerPorcenBoletinNivel(Txt_Marca.Text, Txt_Estilon.Text, Corrida, Fecha, "F")
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    If objDataSet.Tables(0).Rows(0).Item("porcent") > Pporce Then
                        Pporce = objDataSet.Tables(0).Rows(0).Item("porcent")
                    End If
                End If
                objDataSet = objPedidos.usp_TraerPorcenBoletinNivel(Txt_Marca.Text, Txt_Estilon.Text, Corrida, Fecha, "L")
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    If objDataSet.Tables(0).Rows(0).Item("porcent") > Pporce Then
                        Pporce = objDataSet.Tables(0).Rows(0).Item("porcent")
                    End If
                End If
                objDataSet = objPedidos.usp_TraerPorcenBoletinNivel(Txt_Marca.Text, Txt_Estilon.Text, Corrida, Fecha, "P")
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    If objDataSet.Tables(0).Rows(0).Item("porcent") > Pporce Then
                        Pporce = objDataSet.Tables(0).Rows(0).Item("porcent")
                    End If
                End If

                objDataSet = objPedidos.usp_TraerPorcenBoletinNivel(Txt_Marca.Text, Txt_Estilon.Text, Corrida, Fecha, "T")
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    If objDataSet.Tables(0).Rows(0).Item("porcent") > Pporce Then
                        Pporce = objDataSet.Tables(0).Rows(0).Item("porcent")
                    End If
                End If
                objDataSet = objPedidos.usp_TraerPorcenBoletinNivel(Txt_Marca.Text, Txt_Estilon.Text, Corrida, Fecha, "C")
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    If objDataSet.Tables(0).Rows(0).Item("porcent") > Pporce Then
                        Pporce = objDataSet.Tables(0).Rows(0).Item("porcent")
                    End If
                End If

                ''''CALCULO DEL PRECIO TOMANDO DINERO ELECTRONICO 

                objDataSet = objPedidos.usp_TraerPorcenDinero(Txt_Marca.Text, Txt_Estilon.Text, Corrida, Fecha)
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    If objDataSet.Tables(0).Rows(0).Item("porcent") > Pporce Then
                        Pporce = objDataSet.Tables(0).Rows(0).Item("porcent")
                    End If
                End If

                objDataSet = objPedidos.usp_TraerPorcenDineroNivel(Txt_Marca.Text, Txt_Estilon.Text, Corrida, Fecha, "M")
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    If objDataSet.Tables(0).Rows(0).Item("porcent") > Pporce Then
                        Pporce = objDataSet.Tables(0).Rows(0).Item("porcent")

                    End If
                End If
                objDataSet = objPedidos.usp_TraerPorcenDineroNivel(Txt_Marca.Text, Txt_Estilon.Text, Corrida, Fecha, "F")
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    If objDataSet.Tables(0).Rows(0).Item("porcent") > Pporce Then
                        Pporce = objDataSet.Tables(0).Rows(0).Item("porcent")
                    End If
                End If
                objDataSet = objPedidos.usp_TraerPorcenDineroNivel(Txt_Marca.Text, Txt_Estilon.Text, Corrida, Fecha, "L")
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    If objDataSet.Tables(0).Rows(0).Item("porcent") > Pporce Then
                        Pporce = objDataSet.Tables(0).Rows(0).Item("porcent")
                    End If
                End If
                objDataSet = objPedidos.usp_TraerPorcenDineroNivel(Txt_Marca.Text, Txt_Estilon.Text, Corrida, Fecha, "P")
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    If objDataSet.Tables(0).Rows(0).Item("porcent") > Pporce Then
                        Pporce = objDataSet.Tables(0).Rows(0).Item("porcent")
                    End If
                End If

                objDataSet = objPedidos.usp_TraerPorcenDineroNivel(Txt_Marca.Text, Txt_Estilon.Text, Corrida, Fecha, "T")
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    If objDataSet.Tables(0).Rows(0).Item("porcent") > Pporce Then
                        Pporce = objDataSet.Tables(0).Rows(0).Item("porcent")
                    End If
                End If
                objDataSet = objPedidos.usp_TraerPorcenDineroNivel(Txt_Marca.Text, Txt_Estilon.Text, Corrida, Fecha, "C")
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    If objDataSet.Tables(0).Rows(0).Item("porcent") > Pporce Then
                        Pporce = objDataSet.Tables(0).Rows(0).Item("porcent")
                    End If
                End If

                PComp = Costo * PComp / 100


                If Pporce > 0 Then
                    Precio = (Precio * (1 - Pporce / 100))
                End If
                If Precio > 0 And Precio >= Costo Then

                    pmgn = (100 * (1 - Costo / Precio))
                Else
                    pmgn = 0
                End If
                Dim pTipo As String = ""
                Dim ptcr As String = ""
                objDataSet = objPedidos.usp_TraerClasifMargen
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    For I As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                        If "7" <= TipoCrr And TipoCrr <= "9" Then
                            pTipo = "7"
                        ElseIf "4" <= TipoCrr And TipoCrr <= "6" Then
                            pTipo = "4"
                        Else
                            pTipo = "1"
                        End If
                    Next
                End If

                ptcr = (Str(pTipo + (3 - Val(objDataSet.Tables(0).Rows(0).Item("orden")))))
                If pmgn >= objDataSet.Tables(0).Rows(0).Item("porcent") And ptcr <> TipoCrr Then

                End If


            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub


    Private Sub Btn_Limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Limpiar.Click
        Me.Txt_DescripMarca.Text = ""
        Me.Txt_Estilof.Text = ""
        Me.Txt_Estilon.Text = ""
        Me.Txt_Marca.Text = ""
        Txt_Descripc.Text = ""
        Txt_DescripLinea.Text = ""
        Txt_DescripCategoria.Text = ""
        Txt_DescripFamilia.Text = ""
        Txt_DescripTipoArt.Text = ""
        Txt_Raz_Soc.Text = ""

        PBox.Image = Nothing
        Call LimpiarDatos()
        DGrid.RowCount = 1
        Txt_Marca.Focus()
    End Sub


    Private Sub Txt_Estilon_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Estilon.TextChanged

    End Sub
End Class
