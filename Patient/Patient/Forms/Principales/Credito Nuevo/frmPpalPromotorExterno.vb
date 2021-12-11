Public Class frmPpalPromotorExterno
    'lvillegas 09/02/2018 11:20 a.m.
    Private objDataSet As Data.DataSet

    Private Sub RellenarGrid()
        Using objCatalogo As New BCL.BCLPromotorExterno(GLB_ConStringCreditoSQL)

            Try
                Me.Cursor = Cursors.WaitCursor
                Grid.DataSource = Nothing
                'Mandamos la opcion 3 como parametro para rellenar el grid  
                objDataSet = objCatalogo.usp_mostrarPromotorExterno(3, 0, "", "", "", 0, 0, 0, 0, "", 0, "", "", "", "", "", 0, 0, Date.Now)
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Grid.DataSource = objDataSet.Tables(0)

                    'Icializamos nuestro Grid para ver los datos 
                    InicializaGrid()
                    GridView1.BestFitColumns()

                    Me.Cursor = Cursors.Default
                Else
                    Me.Cursor = Cursors.Default
                    If Grid.DataSource = Nothing Then
                        Btn_Editar.Enabled = False
                        Btn_Consultar.Enabled = False
                        Btn_Excel.Enabled = False

                    End If
                    MsgBox("No se encontraron registros de promotores externos. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")

                End If

                Me.Cursor = Cursors.Default

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Sub InicializaGrid()
        Try
            GridView1.Columns("idpromotorexterno").Visible = False
            GridView1.Columns("idestado").Visible = False
            GridView1.Columns("idciudad").Visible = False
            GridView1.Columns("idcolonia").Visible = False
            GridView1.Columns("idusuario").Visible = False
            GridView1.Columns("idusuariomodif").Visible = False

            GridView1.Columns("idpromotorexterno").Caption = "Id Promotor Externo"
            GridView1.Columns("nombre").Caption = "Nombre"
            GridView1.Columns("appaterno").Caption = "Apellido Paterno"
            GridView1.Columns("apmaterno").Caption = "Apellido Materno"
            GridView1.Columns("idestado").Caption = "Estado"
            GridView1.Columns("idciudad").Caption = "Ciudad"
            GridView1.Columns("idcolonia").Caption = "Colonia"
            GridView1.Columns("cp").Caption = "Código Postal"
            GridView1.Columns("calle").Caption = "Calle"
            GridView1.Columns("numero").Caption = "Número"
            GridView1.Columns("tel1").Caption = "Tel 1"
            GridView1.Columns("tel2").Caption = "Tel 2"
            GridView1.Columns("celular1").Caption = "Cel 1"
            GridView1.Columns("celular2").Caption = "Cel 2"
            GridView1.Columns("email").Caption = "email"
            GridView1.Columns("idusuario").Caption = "id Usuario"
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

    Private Sub Btn_Refrescar_Click(sender As Object, e As EventArgs) Handles Btn_Refrescar.Click
        Call RellenarGrid()
    End Sub

    Private Sub Btn_Salir_Click(sender As Object, e As EventArgs) Handles Btn_Salir.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub Grid_DoubleClick(sender As Object, e As EventArgs) Handles Grid.DoubleClick
        Dim myForm As New frmCatalogoPromotorExterno

        Dim Renglon As Integer = 0
        Dim intposicion As Integer = 0
        Dim inttotalrows As Integer = 0
        Dim idpromotorexterno As Integer = 0
        Dim nombre As String = ""
        Dim appaterno As String = ""

        Dim apmaterno As String = ""

        Dim idestado As Integer = 0
        Dim idciudad As Integer = 0
        Dim idcolonia As Integer = 0
        Dim cp As Integer = 0
        Dim calle As String = ""
        Dim numero As Integer = 0
        Dim tel1 As String = ""
        Dim tel2 As String = ""
        Dim celular1 As String = ""
        Dim celular2 As String = ""
        Dim email As String = ""






        'Dim Observaciones As String = ""

        For i As Integer = 0 To GridView1.RowCount - 1


            If GridView1.IsRowSelected(i) = True Then
                idpromotorexterno = GridView1.GetRowCellValue(i, "idpromotorexterno")
                nombre = GridView1.GetRowCellValue(i, "nombre")
                appaterno = GridView1.GetRowCellValue(i, "appaterno")

                apmaterno = GridView1.GetRowCellValue(i, "apmaterno")

                idestado = GridView1.GetRowCellValue(i, "idestado")
                idciudad = GridView1.GetRowCellValue(i, "idciudad")
                idcolonia = GridView1.GetRowCellValue(i, "idcolonia")
                cp = GridView1.GetRowCellValue(i, "cp")
                calle = GridView1.GetRowCellValue(i, "calle")

                numero = GridView1.GetRowCellValue(i, "numero")
                tel1 = GridView1.GetRowCellValue(i, "tel1")
                tel2 = GridView1.GetRowCellValue(i, "tel2")
                celular1 = GridView1.GetRowCellValue(i, "celular1")
                celular2 = GridView1.GetRowCellValue(i, "celular2")
                email = GridView1.GetRowCellValue(i, "email")

            End If
        Next

        myForm.getRow(idpromotorexterno)
        myForm.Txt_NomPromotor.Text = nombre
        myForm.Txt_Appaterno.Text = appaterno
        myForm.Txt_ApMaterno.Text = apmaterno

        myForm.Cmb_Estado.Text = idestado
        myForm.Cmb_Ciudad.Text = idciudad
        myForm.Cmb_Colonia.Text = idcolonia
        myForm.Cmb_CP.SelectedValue = cp
        myForm.Txt_Calle.Text = calle
        myForm.Txt_Numero.Text = numero
        myForm.Txt_Tel1.Text = tel1
        myForm.Txt_Tel2.Text = tel2
        myForm.Txt_Cel1.Text = celular1
        myForm.Txt_Cel2.Text = celular2
        myForm.Txt_Email.Text = email




        myForm.Txt_NomPromotor.Enabled = False
        myForm.Txt_Appaterno.Enabled = False
        myForm.Txt_ApMaterno.Enabled = False


        myForm.Cmb_Estado.Enabled = False
        myForm.Cmb_Ciudad.Enabled = False
        myForm.Cmb_Colonia.Enabled = False
        myForm.Cmb_CP.Enabled = False
        myForm.Txt_Calle.Enabled = False
        myForm.Txt_Numero.Enabled = False
        myForm.Txt_Tel1.Enabled = False
        myForm.Txt_Tel2.Enabled = False
        myForm.Txt_Cel1.Enabled = False
        myForm.Txt_Cel2.Enabled = False
        myForm.Txt_Email.Enabled = False


        myForm.btn_Aceptar.Enabled = False
        myForm.btn_Limpiar.Enabled = False

        myForm.idcolonia = idcolonia
        myForm.idciudad = idciudad
        myForm.idestado = idestado
        myForm.ShowDialog()
        Call InicializaGrid()
    End Sub

    Private Sub Btn_Consultar_Click(sender As Object, e As EventArgs) Handles Btn_Consultar.Click
        Dim myForm As New frmCatalogoPromotorExterno

        Dim Renglon As Integer = 0
        Dim intposicion As Integer = 0
        Dim inttotalrows As Integer = 0
        Dim idpromotorexterno As Integer = 0
        Dim nombre As String = ""
        Dim appaterno As String = ""

        Dim apmaterno As String = ""

        Dim idestado As Integer = 0
        Dim idciudad As Integer = 0
        Dim idcolonia As Integer = 0
        Dim cp As Integer = 0
        Dim calle As String = ""
        Dim numero As Integer = 0
        Dim tel1 As String = ""
        Dim tel2 As String = ""
        Dim celular1 As String = ""
        Dim celular2 As String = ""
        Dim email As String = ""






        'Dim Observaciones As String = ""

        For i As Integer = 0 To GridView1.RowCount - 1


            If GridView1.IsRowSelected(i) = True Then
                idpromotorexterno = GridView1.GetRowCellValue(i, "idpromotorexterno")
                nombre = GridView1.GetRowCellValue(i, "nombre")
                appaterno = GridView1.GetRowCellValue(i, "appaterno")

                apmaterno = GridView1.GetRowCellValue(i, "apmaterno")

                idestado = GridView1.GetRowCellValue(i, "idestado")
                idciudad = GridView1.GetRowCellValue(i, "idciudad")
                idcolonia = GridView1.GetRowCellValue(i, "idcolonia")
                cp = GridView1.GetRowCellValue(i, "cp")
                calle = GridView1.GetRowCellValue(i, "calle")

                numero = GridView1.GetRowCellValue(i, "numero")
                tel1 = GridView1.GetRowCellValue(i, "tel1")
                tel2 = GridView1.GetRowCellValue(i, "tel2")
                celular1 = GridView1.GetRowCellValue(i, "celular1")
                celular2 = GridView1.GetRowCellValue(i, "celular2")
                email = GridView1.GetRowCellValue(i, "email")

            End If
        Next

        myForm.getRow(idpromotorexterno)
        myForm.Txt_NomPromotor.Text = nombre
        myForm.Txt_Appaterno.Text = appaterno
        myForm.Txt_ApMaterno.Text = apmaterno

        myForm.Cmb_Estado.Text = idestado
        myForm.Cmb_Ciudad.Text = idciudad
        myForm.Cmb_Colonia.Text = idcolonia
        myForm.Cmb_CP.Text = cp
        myForm.Txt_Calle.Text = calle
        myForm.Txt_Numero.Text = numero
        myForm.Txt_Tel1.Text = tel1
        myForm.Txt_Tel2.Text = tel2
        myForm.Txt_Cel1.Text = celular1
        myForm.Txt_Cel2.Text = celular2
        myForm.Txt_Email.Text = email




        myForm.Txt_NomPromotor.Enabled = False
        myForm.Txt_Appaterno.Enabled = False
        myForm.Txt_ApMaterno.Enabled = False


        myForm.Cmb_Estado.Enabled = False
        myForm.Cmb_Ciudad.Enabled = False
        myForm.Cmb_Colonia.Enabled = False
        myForm.Cmb_CP.Enabled = False
        myForm.Txt_Calle.Enabled = False
        myForm.Txt_Numero.Enabled = False
        myForm.Txt_Tel1.Enabled = False
        myForm.Txt_Tel2.Enabled = False
        myForm.Txt_Cel1.Enabled = False
        myForm.Txt_Cel2.Enabled = False
        myForm.Txt_Email.Enabled = False

        myForm.idcolonia = idcolonia
        myForm.idciudad = idciudad
        myForm.idestado = idestado

        myForm.btn_Aceptar.Enabled = False
        myForm.btn_Limpiar.Enabled = False
        myForm.ShowDialog()
        Call InicializaGrid()
    End Sub


    Private Sub Btn_Nuevo_Click(sender As Object, e As EventArgs) Handles Btn_Nuevo.Click
        Dim myForm As New frmCatalogoPromotorExterno
        myForm.opcion = 1
        'Call Edicion()
        Btn_Editar.Enabled = True
        Btn_Consultar.Enabled = True
        Btn_Excel.Enabled = True

        myForm.ShowDialog()
        Call RellenarGrid()
        Call InicializaGrid()
    End Sub

    Private Sub Btn_Editar_Click(sender As Object, e As EventArgs) Handles Btn_Editar.Click
        Dim myForm As New frmCatalogoPromotorExterno
        myForm.opcion = 2
        myForm.btn_Limpiar.Enabled = False
        'Call Edicion()

        Dim Renglon As Integer = 0
        Dim intposicion As Integer = 0
        Dim inttotalrows As Integer = 0
        Dim idpromotorexterno As Integer = 0
        Dim nombre As String = ""
        Dim appaterno As String = ""

        Dim apmaterno As String = ""

        Dim idestado As Integer = 0
        Dim idciudad As Integer = 0
        Dim idcolonia As Integer = 0
        Dim cp As Integer = 0
        Dim calle As String = ""
        Dim numero As Integer = 0
        Dim tel1 As String = ""
        Dim tel2 As String = ""
        Dim celular1 As String = ""
        Dim celular2 As String = ""
        Dim email As String = ""






        'Dim Observaciones As String = ""

        For i As Integer = 0 To GridView1.RowCount - 1


            If GridView1.IsRowSelected(i) = True Then
                idpromotorexterno = GridView1.GetRowCellValue(i, "idpromotorexterno")
                nombre = GridView1.GetRowCellValue(i, "nombre")
                appaterno = GridView1.GetRowCellValue(i, "appaterno")

                apmaterno = GridView1.GetRowCellValue(i, "apmaterno")

                idestado = GridView1.GetRowCellValue(i, "idestado")
                idciudad = GridView1.GetRowCellValue(i, "idciudad")
                idcolonia = GridView1.GetRowCellValue(i, "idcolonia")
                cp = GridView1.GetRowCellValue(i, "cp")
                calle = GridView1.GetRowCellValue(i, "calle")

                numero = GridView1.GetRowCellValue(i, "numero")
                tel1 = GridView1.GetRowCellValue(i, "tel1")
                tel2 = GridView1.GetRowCellValue(i, "tel2")
                celular1 = GridView1.GetRowCellValue(i, "celular1")
                celular2 = GridView1.GetRowCellValue(i, "celular2")
                email = GridView1.GetRowCellValue(i, "email")

            End If
        Next

        myForm.getRow(idpromotorexterno)
        myForm.getRowEstado(idestado)
        myForm.getRowCiudad(idciudad)
        myForm.getRowColonia(idcolonia)
        myForm.getRowCP(cp)



        myForm.Cmb_Estado.Text = idestado
        myForm.Cmb_Ciudad.Text = idciudad
        myForm.Cmb_Colonia.Text = idcolonia
        myForm.Cmb_CP.Text = cp
        myForm.Txt_Calle.Text = calle
        myForm.Txt_Numero.Text = numero
        myForm.Txt_Tel1.Text = tel1
        myForm.Txt_Tel2.Text = tel2
        myForm.Txt_Cel1.Text = celular1
        myForm.Txt_Cel2.Text = celular2
        myForm.Txt_Email.Text = email

        myForm.Txt_NomPromotor.Text = nombre
        myForm.Txt_Appaterno.Text = appaterno
        myForm.Txt_ApMaterno.Text = apmaterno
        myForm.idcolonia = idcolonia
        myForm.idciudad = idciudad
        myForm.idestado = idestado

        myForm.ShowDialog()
        Call RellenarGrid()
        Call InicializaGrid()
    End Sub

    Private Sub frmPpalPromotorExterno_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call RellenarGrid()
    End Sub


End Class