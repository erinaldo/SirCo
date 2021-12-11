Public Class frmPpalAbogados
    Private objDataSet As Data.DataSet


    Private Sub RellenarGrid()
        Using objCatalogo As New BCL.BCLAbogados(GLB_ConStringCreditoSQL)

            Try
                Me.Cursor = Cursors.WaitCursor
                Grid.DataSource = Nothing
                'Unicamente envio la opcion 3 de consulta y todo lo demas en ceros y entre comillas para los caracteres 
                objDataSet = objCatalogo.usp_mostrarAbogado(3, 0, "", "", "", "", 0, 0, 0, 0, "", 0, "", "", "", "", "", "", 0, 0, 0, 0, "", "", 0, 0, Date.Now, 0, Date.Now)
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Grid.DataSource = objDataSet.Tables(0)

                    'Icializamos nuestro Grid para ver los datos 
                    InicializaGrid()
                    GridView1.BestFitColumns()

                    Me.Cursor = Cursors.Default
                Else
                    Me.Cursor = Cursors.Default
                    'Si el Grid esta vacio me deshabilita los siguientes botones 
                    If Grid.DataSource = Nothing Then
                        Btn_Editar.Enabled = False
                        Btn_Consultar.Enabled = False
                        Btn_Excel.Enabled = False
                    End If
                    MsgBox("No se encontraron registros de Abogados. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")

                End If

                Me.Cursor = Cursors.Default

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Sub InicializaGrid()
        Try
            GridView1.Columns("idestado").Visible = False
            GridView1.Columns("idciudad").Visible = False
            GridView1.Columns("idcolonia").Visible = False
            GridView1.Columns("idestadodpcho").Visible = False
            GridView1.Columns("idciudadpcho").Visible = False
            GridView1.Columns("idcoloniadpcho").Visible = False
            GridView1.Columns("idusuario").Visible = False
            GridView1.Columns("idusuariomodif").Visible = False
            GridView1.Columns("idabogado").Visible = False
            GridView1.Columns("fum").Visible = False
            GridView1.Columns("fummodif").Visible = False

            GridView1.Columns("idabogado").Caption = "Id Abogado"
            GridView1.Columns("nombre").Caption = "Nombre"
            GridView1.Columns("appaterno").Caption = "Apellido Paterno"
            GridView1.Columns("apmaterno").Caption = "Apellido Materno"
            GridView1.Columns("cedula").Caption = "Cédula"
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
            GridView1.Columns("despacho").Caption = "Despacho"
            GridView1.Columns("idestadodpcho").Caption = "Estado"
            GridView1.Columns("idciudadpcho").Caption = "Ciudad"
            GridView1.Columns("idcoloniadpcho").Caption = "Colonia"
            GridView1.Columns("cpdpcho").Caption = "Código Postal"
            GridView1.Columns("calledpcho").Caption = "Calle"
            GridView1.Columns("entrecallesdpcho").Caption = "Entre Calles"
            GridView1.Columns("numerodpcho").Caption = "Número"
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

    Private Sub frmAbogado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RellenarGrid()
    End Sub

    Private Sub Btn_Refrescar_Click(sender As Object, e As EventArgs) Handles Btn_Refrescar.Click
        RellenarGrid()
    End Sub

    Private Sub Btn_Salir_Click(sender As Object, e As EventArgs) Handles Btn_Salir.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub Btn_Excel_Click(sender As Object, e As EventArgs) Handles Btn_Excel.Click
        Try
            If sfdRuta.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                GridView1.ExportToXls(sfdRuta.FileName)
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Nuevo_Click(sender As Object, e As EventArgs) Handles Btn_Nuevo.Click
        Dim myForm As New frmCatalogoAbogados
        myForm.opcion = 1
        Btn_Editar.Enabled = True
        Btn_Consultar.Enabled = True
        Btn_Excel.Enabled = True
        myForm.ShowDialog()
        Call RellenarGrid()
        Call InicializaGrid()
    End Sub





    Private Sub Btn_Editar_Click(sender As Object, e As EventArgs) Handles Btn_Editar.Click
        Dim myForm As New frmCatalogoAbogados
        myForm.opcion = 2
        'myForm.getRow()

        Dim Renglon As Integer = 0
        Dim intposicion As Integer = 0
        Dim inttotalrows As Integer = 0
        Dim idabogado As Integer = 0
        Dim nombre As String = ""
        Dim appaterno As String = ""

        Dim apmaterno As String = ""
        Dim cedula As String = ""
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
        Dim despacho As String = ""

        Dim idestadodpcho As Integer = 0
        Dim idciudadpcho As Integer = 0
        Dim idcoloniadpcho As Integer = 0
        Dim cpdpcho As Integer = 0
        Dim calledpcho As String = ""
        Dim entrecallesdpcho As String = ""
        Dim numerodpcho As Integer = 0
        Dim fum As Date




        'Dim Observaciones As String = ""

        For i As Integer = 0 To GridView1.RowCount - 1


            If GridView1.IsRowSelected(i) = True Then
                idabogado = GridView1.GetRowCellValue(i, "idabogado")
                nombre = GridView1.GetRowCellValue(i, "nombre")
                appaterno = GridView1.GetRowCellValue(i, "appaterno")

                apmaterno = GridView1.GetRowCellValue(i, "apmaterno")
                cedula = GridView1.GetRowCellValue(i, "cedula")
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
                despacho = GridView1.GetRowCellValue(i, "despacho")
                idestadodpcho = GridView1.GetRowCellValue(i, "idestadodpcho")
                idciudadpcho = GridView1.GetRowCellValue(i, "idciudadpcho")
                idcoloniadpcho = GridView1.GetRowCellValue(i, "idcoloniadpcho")
                cpdpcho = GridView1.GetRowCellValue(i, "cpdpcho")
                calledpcho = GridView1.GetRowCellValue(i, "calledpcho")
                entrecallesdpcho = GridView1.GetRowCellValue(i, "entrecallesdpcho")
                numerodpcho = GridView1.GetRowCellValue(i, "numerodpcho")
                fum = GridView1.GetRowCellValue(i, "fum")
            End If
        Next

        myForm.getRow(idabogado)
        myForm.getRowCP(cp)
        myForm.getRowCodigoPostal1(cpdpcho)
        myForm.getRowEstado(idestado)
        myForm.getRowCiudad(idciudad)
        myForm.getRowColonia(idcolonia)
        myForm.getRowEstado1(idestadodpcho)
        myForm.getRowCiudad1(idciudadpcho)
        'myForm.Txt_Idabogado.Text = idabogado
        myForm.Txt_nomAbogado.Text = nombre
        myForm.Txt_Appaterno.Text = appaterno
        myForm.Txt_ApMaterno.Text = apmaterno

        myForm.Txt_Cedula.Text = cedula

        myForm.Cmb_EstadoDomicilio.Text = idestado
        myForm.Cmb_CiudadDomicilio.Text = idciudad
        myForm.Cmb_ColoniaDomicilio.Text = idcolonia

        myForm.Cmb_CP.Text = cp
        myForm.Txt_CalleDomicilio.Text = calle
        myForm.Txt_NumeroDomicilio.Text = numero
        myForm.Txt_Tel1contacto.Text = tel1
        myForm.Txt_Tel2contacto.Text = tel2
        myForm.Txt_Cel1contacto.Text = celular1
        myForm.Txt_Cel2contacto.Text = celular2
        myForm.Txt_Emailcontacto.Text = email
        myForm.Txt_NombreDespacho.Text = despacho

        myForm.Cmb_EstadoDespacho.Text = idestadodpcho
        myForm.Cmb_CiudadDespacho.Text = idciudadpcho
        myForm.Cmb_ColoniaDespacho.Text = idcoloniadpcho

        myForm.Cmb_CP1.Text = cpdpcho
        myForm.Txt_CalleDespacho.Text = calledpcho
        myForm.Txt_EntrecallesDespacho.Text = entrecallesdpcho
        myForm.Txt_NumeroDespacho.Text = numerodpcho
        myForm.Dt_FechaAsignacion.Text = fum
        myForm.idcolonia = idcolonia
        myForm.idciudad = idciudad
        myForm.idestado = idestado

        myForm.idcolonia1 = idcoloniadpcho
        myForm.idciudad1 = idciudadpcho
        myForm.idestado1 = idestadodpcho
        myForm.ShowDialog()
        Call RellenarGrid()
        Call InicializaGrid()
    End Sub

    Private Sub Grid_DoubleClick(sender As Object, e As EventArgs) Handles Grid.DoubleClick

        Dim myForm As New frmCatalogoAbogados

        Dim Renglon As Integer = 0
        Dim intposicion As Integer = 0
        Dim inttotalrows As Integer = 0
        Dim idabogado As Integer = 0
        Dim nombre As String = ""
        Dim appaterno As String = ""

        Dim apmaterno As String = ""
        Dim cedula As String = ""
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
        Dim despacho As String = ""

        Dim idestadodpcho As Integer = 0
        Dim idciudadpcho As Integer = 0
        Dim idcoloniadpcho As Integer = 0
        Dim cpdpcho As Integer = 0
        Dim calledpcho As String = ""
        Dim entrecallesdpcho As String = ""
        Dim numerodpcho As Integer = 0
        Dim fum As Date




        'Dim Observaciones As String = ""

        For i As Integer = 0 To GridView1.RowCount - 1


            If GridView1.IsRowSelected(i) = True Then
                idabogado = GridView1.GetRowCellValue(i, "idabogado")
                nombre = GridView1.GetRowCellValue(i, "nombre")
                appaterno = GridView1.GetRowCellValue(i, "appaterno")

                apmaterno = GridView1.GetRowCellValue(i, "apmaterno")
                cedula = GridView1.GetRowCellValue(i, "cedula")
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
                despacho = GridView1.GetRowCellValue(i, "despacho")
                idestadodpcho = GridView1.GetRowCellValue(i, "idestadodpcho")
                idciudadpcho = GridView1.GetRowCellValue(i, "idciudadpcho")
                idcoloniadpcho = GridView1.GetRowCellValue(i, "idcoloniadpcho")
                cpdpcho = GridView1.GetRowCellValue(i, "cpdpcho")
                calledpcho = GridView1.GetRowCellValue(i, "calledpcho")
                entrecallesdpcho = GridView1.GetRowCellValue(i, "entrecallesdpcho")
                numerodpcho = GridView1.GetRowCellValue(i, "numerodpcho")
                fum = GridView1.GetRowCellValue(i, "fum")
            End If
        Next

        myForm.getRow(idabogado)
        myForm.Txt_nomAbogado.Text = nombre
        myForm.Txt_Appaterno.Text = appaterno
        myForm.Txt_ApMaterno.Text = apmaterno

        myForm.Txt_Cedula.Text = cedula
        myForm.Cmb_EstadoDomicilio.Text = idestado
        myForm.Cmb_CiudadDomicilio.Text = idciudad
        myForm.Cmb_ColoniaDomicilio.Text = idcolonia
        myForm.Cmb_CP.Text = cp
        myForm.Txt_CalleDomicilio.Text = calle
        myForm.Txt_NumeroDomicilio.Text = numero
        myForm.Txt_Tel1contacto.Text = tel1
        myForm.Txt_Tel2contacto.Text = tel2
        myForm.Txt_Cel1contacto.Text = celular1
        myForm.Txt_Cel2contacto.Text = celular2
        myForm.Txt_Emailcontacto.Text = email
        myForm.Txt_NombreDespacho.Text = despacho
        myForm.Cmb_EstadoDespacho.Text = idestadodpcho
        myForm.Cmb_CiudadDespacho.Text = idciudadpcho
        myForm.Cmb_ColoniaDespacho.Text = idcoloniadpcho
        myForm.Cmb_CP1.Text = cpdpcho
        myForm.Txt_CalleDespacho.Text = calledpcho
        myForm.Txt_EntrecallesDespacho.Text = entrecallesdpcho
        myForm.Txt_NumeroDespacho.Text = numerodpcho
        myForm.Dt_FechaAsignacion.Text = fum


        myForm.Txt_nomAbogado.Enabled = False
        myForm.Txt_Appaterno.Enabled = False
        myForm.Txt_ApMaterno.Enabled = False

        myForm.Txt_Cedula.Enabled = False
        myForm.Cmb_EstadoDomicilio.Enabled = False
        myForm.Cmb_CiudadDomicilio.Enabled = False
        myForm.Cmb_ColoniaDomicilio.Enabled = False
        myForm.Cmb_CP.Enabled = False
        myForm.Txt_CalleDomicilio.Enabled = False
        myForm.Txt_NumeroDomicilio.Enabled = False
        myForm.Txt_Tel1contacto.Enabled = False
        myForm.Txt_Tel2contacto.Enabled = False
        myForm.Txt_Cel1contacto.Enabled = False
        myForm.Txt_Cel2contacto.Enabled = False
        myForm.Txt_Emailcontacto.Enabled = False
        myForm.Txt_NombreDespacho.Enabled = False
        myForm.Cmb_EstadoDespacho.Enabled = False
        myForm.Cmb_CiudadDespacho.Enabled = False
        myForm.Cmb_ColoniaDespacho.Enabled = False
        myForm.Cmb_CP1.Enabled = False
        myForm.Txt_CalleDespacho.Enabled = False
        myForm.Txt_EntrecallesDespacho.Enabled = False
        myForm.Txt_NumeroDespacho.Enabled = False
        myForm.Dt_FechaAsignacion.Enabled = False
        myForm.btn_Aceptar.Enabled = False
        myForm.btn_Limpiar.Enabled = False

        myForm.idcolonia = idcolonia
        myForm.idciudad = idciudad
        myForm.idestado = idestado

        myForm.idcolonia1 = idcoloniadpcho
        myForm.idciudad1 = idciudadpcho
        myForm.idestado1 = idestadodpcho
        myForm.ShowDialog()
        Call InicializaGrid()
    End Sub

    Private Sub Btn_Consultar_Click(sender As Object, e As EventArgs) Handles Btn_Consultar.Click

        Dim myForm As New frmCatalogoAbogados

        Dim Renglon As Integer = 0
        Dim intposicion As Integer = 0
        Dim inttotalrows As Integer = 0
        Dim idabogado As Integer = 0
        Dim nombre As String = ""
        Dim appaterno As String = ""

        Dim apmaterno As String = ""
        Dim cedula As String = ""
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
        Dim despacho As String = ""

        Dim idestadodpcho As Integer = 0
        Dim idciudadpcho As Integer = 0
        Dim idcoloniadpcho As Integer = 0
        Dim cpdpcho As Integer = 0
        Dim calledpcho As String = ""
        Dim entrecallesdpcho As String = ""
        Dim numerodpcho As Integer = 0
        Dim fum As Date




        'Dim Observaciones As String = ""

        For i As Integer = 0 To GridView1.RowCount - 1


            If GridView1.IsRowSelected(i) = True Then
                idabogado = GridView1.GetRowCellValue(i, "idabogado")
                nombre = GridView1.GetRowCellValue(i, "nombre")
                appaterno = GridView1.GetRowCellValue(i, "appaterno")

                apmaterno = GridView1.GetRowCellValue(i, "apmaterno")
                cedula = GridView1.GetRowCellValue(i, "cedula")
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
                despacho = GridView1.GetRowCellValue(i, "despacho")
                idestadodpcho = GridView1.GetRowCellValue(i, "idestadodpcho")
                idciudadpcho = GridView1.GetRowCellValue(i, "idciudadpcho")
                idcoloniadpcho = GridView1.GetRowCellValue(i, "idcoloniadpcho")
                cpdpcho = GridView1.GetRowCellValue(i, "cpdpcho")
                calledpcho = GridView1.GetRowCellValue(i, "calledpcho")
                entrecallesdpcho = GridView1.GetRowCellValue(i, "entrecallesdpcho")
                numerodpcho = GridView1.GetRowCellValue(i, "numerodpcho")
                fum = GridView1.GetRowCellValue(i, "fum")
            End If
        Next

        myForm.getRow(idabogado)
        myForm.Txt_nomAbogado.Text = nombre
        myForm.Txt_Appaterno.Text = appaterno
        myForm.Txt_ApMaterno.Text = apmaterno

        myForm.Txt_Cedula.Text = cedula
        myForm.Cmb_EstadoDomicilio.Text = idestado
        myForm.Cmb_CiudadDomicilio.Text = idciudad
        myForm.Cmb_ColoniaDomicilio.Text = idcolonia
        myForm.Cmb_CP.Text = cp
        myForm.Txt_CalleDomicilio.Text = calle
        myForm.Txt_NumeroDomicilio.Text = numero
        myForm.Txt_Tel1contacto.Text = tel1
        myForm.Txt_Tel2contacto.Text = tel2
        myForm.Txt_Cel1contacto.Text = celular1
        myForm.Txt_Cel2contacto.Text = celular2
        myForm.Txt_Emailcontacto.Text = email
        myForm.Txt_NombreDespacho.Text = despacho
        myForm.Cmb_EstadoDespacho.Text = idestadodpcho
        myForm.Cmb_CiudadDespacho.Text = idciudadpcho
        myForm.Cmb_ColoniaDespacho.Text = idcoloniadpcho
        myForm.Cmb_CP1.Text = cpdpcho
        myForm.Txt_CalleDespacho.Text = calledpcho
        myForm.Txt_EntrecallesDespacho.Text = entrecallesdpcho
        myForm.Txt_NumeroDespacho.Text = numerodpcho
        myForm.Dt_FechaAsignacion.Text = fum


        myForm.Txt_nomAbogado.Enabled = False
        myForm.Txt_Appaterno.Enabled = False
        myForm.Txt_ApMaterno.Enabled = False

        myForm.Txt_Cedula.Enabled = False
        myForm.Cmb_EstadoDomicilio.Enabled = False
        myForm.Cmb_CiudadDomicilio.Enabled = False
        myForm.Cmb_ColoniaDomicilio.Enabled = False
        myForm.Cmb_CP.Enabled = False
        myForm.Txt_CalleDomicilio.Enabled = False
        myForm.Txt_NumeroDomicilio.Enabled = False
        myForm.Txt_Tel1contacto.Enabled = False
        myForm.Txt_Tel2contacto.Enabled = False
        myForm.Txt_Cel1contacto.Enabled = False
        myForm.Txt_Cel2contacto.Enabled = False
        myForm.Txt_Emailcontacto.Enabled = False
        myForm.Txt_NombreDespacho.Enabled = False
        myForm.Cmb_EstadoDespacho.Enabled = False
        myForm.Cmb_CiudadDespacho.Enabled = False
        myForm.Cmb_ColoniaDespacho.Enabled = False
        myForm.Cmb_CP1.Enabled = False
        myForm.Txt_CalleDespacho.Enabled = False
        myForm.Txt_EntrecallesDespacho.Enabled = False
        myForm.Txt_NumeroDespacho.Enabled = False
        myForm.Dt_FechaAsignacion.Enabled = False
        myForm.btn_Aceptar.Enabled = False
        myForm.btn_Limpiar.Enabled = False

        myForm.idcolonia = idcolonia
        myForm.idciudad = idciudad
        myForm.idestado = idestado

        myForm.idcolonia1 = idcoloniadpcho
        myForm.idciudad1 = idciudadpcho
        myForm.idestado1 = idestadodpcho
        myForm.ShowDialog()
        Call InicializaGrid()
    End Sub
End Class