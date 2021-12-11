Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid.Views.Grid

Public Class frmPpalCliente

    Dim objDataSet As Data.DataSet
    Dim idcliente As Integer = 0
    Dim Opcion As Integer = 0
    Dim Accion As Integer
    Dim blnValCliente As Boolean = False
    Dim idsucursal As Integer
    Dim cliente As String
    Dim nombre As String
    Dim appaterno As String
    Dim apmaterno As String
    Dim sexo As String
    Dim idestado As Integer
    Dim idciudad As Integer
    Dim idcolonia As Integer
    Dim codigopostal As String
    Dim calle As String
    Dim numero As Integer
    Dim celular1 As String
    Dim email As String
    Dim fecalta As Date
    Dim idusuario As Integer = GLB_Idempleado
    Dim idusuariomodif As Integer

    Private Sub RellenaGrid()

        Using objTrasp As New BCL.BCLCliente(GLB_ConStringCreditoSQL)

            Try
                Me.Cursor = Cursors.WaitCursor
                DGrid.DataSource = Nothing


                objDataSet = objTrasp.usp_TraerCliente(1, idcliente, "", "", "")
                If objDataSet.Tables(0).Rows.Count > 0 Then

                    Btn_Editar.Enabled = True
                    DGrid.DataSource = objDataSet.Tables(0)
                    InicializaGrid()
                    GridView1.BestFitColumns()

                    Me.Cursor = Cursors.Default
                Else
                    Me.Cursor = Cursors.Default
                    MsgBox("No se encontraron registros que cumplan con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")
                    Btn_Editar.Enabled = False
                End If

                Me.Cursor = Cursors.Default

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub
    Sub InicializaGrid()
        Try
            GridView1.Columns("idcliente").Caption = "IdCliente"
            GridView1.Columns("idsucursal").Caption = "IdSucursal"
            GridView1.Columns("cliente").Caption = "Cliente"
            GridView1.Columns("nombre").Caption = "Nombre"
            GridView1.Columns("appaterno").Caption = "Apellido paterno"
            GridView1.Columns("apmaterno").Caption = "Apellido materno"
            GridView1.Columns("sexo").Caption = "Sexo"
            GridView1.Columns("idestado").Caption = "idEstado"
            GridView1.Columns("estado").Caption = "Estado"
            GridView1.Columns("idciudad").Caption = "idCiudad"
            GridView1.Columns("ciudad").Caption = "Ciudad"
            GridView1.Columns("idcolonia").Caption = "idColonia"
            GridView1.Columns("colonia").Caption = "Colonia"
            GridView1.Columns("codigopostal").Caption = "Código postal"
            GridView1.Columns("calle").Caption = "Calle"
            GridView1.Columns("numero").Caption = "Número"
            GridView1.Columns("celular1").Caption = "Celular"
            GridView1.Columns("email").Caption = "Email"
            GridView1.Columns("fecalta").Caption = "Fecha alta"

            GridView1.OptionsView.ColumnAutoWidth = False

            GridView1.Columns("idcliente").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns("idsucursal").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            'GridView1.Columns("cliente").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            'GridView1.Columns("nombre").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            'GridView1.Columns("appaterno").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            'GridView1.Columns("apmaterno").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns("sexo").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns("idestado").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            'GridView1.Columns("estado").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns("idciudad").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            'GridView1.Columns("ciudad").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns("idcolonia").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            'GridView1.Columns("colonia").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns("codigopostal").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            'GridView1.Columns("calle").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns("numero").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns("celular1").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns("email").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns("fecalta").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

            For I As Integer = 0 To GridView1.Columns.Count - 1

                GridView1.Columns(I).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                GridView1.Columns(I).AppearanceHeader.Font = New Font(GridView1.Columns(I).AppearanceCell.Font, FontStyle.Bold)
                GridView1.Columns(I).OptionsColumn.ReadOnly = True

            Next


            GridView1.Columns("idcliente").Visible = False
            GridView1.Columns("idsucursal").Visible = False
            GridView1.Columns("cliente").Visible = False
            GridView1.Columns("sexo").Visible = False
            GridView1.Columns("celular1").Visible = False
            GridView1.Columns("email").Visible = False
            GridView1.Columns("idestado").Visible = False
            GridView1.Columns("idciudad").Visible = False
            GridView1.Columns("idcolonia").Visible = False
            GridView1.Columns("fecalta").Visible = False


            GridView1.BestFitColumns()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_Click(sender As Object, e As EventArgs) Handles DGrid.Click

    End Sub

    Private Sub frmPpalCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RellenaGrid()
    End Sub

    Private Sub Btn_Nuevo_Click(sender As Object, e As EventArgs) Handles Btn_Nuevo.Click
        Try
            Opcion = 1
            Dim myForm As New frmCatalogoCliente
            myForm.Accion = Opcion
            myForm.Txt_Sucursal.Visible = False
            myForm.Txt_Cliente.Visible = False
            myForm.Lbl_Cliente.Visible = False
            myForm.Lbl_Sucursal.Visible = False
            myForm.Text = myForm.Text + "(Nuevo Cliente)"
            myForm.ShowDialog()

            Call RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Editar_Click(sender As Object, e As EventArgs) Handles Btn_Editar.Click
        Try
            Dim myForm As New frmCatalogoCliente
            myForm.Accion = 2
            myForm.Text = myForm.Text + " (Editar Cliente)"

            Dim Renglon As Integer = 0
            Dim intposicion As Integer = 0
            Dim inttotalrows As Integer = 0
            Dim IdCliente As Integer = 0
            Dim tipo As String = ""
            Dim Observaciones As String = ""

            For i As Integer = 0 To GridView1.RowCount - 1


                If GridView1.IsRowSelected(i) = True Then
                    IdCliente = GridView1.GetRowCellValue(i, "idcliente")
                    nombre = GridView1.GetRowCellValue(i, "nombre")
                    appaterno = GridView1.GetRowCellValue(i, "appaterno")
                    apmaterno = GridView1.GetRowCellValue(i, "apmaterno")
                    sexo = GridView1.GetRowCellValue(i, "sexo")
                    idestado = GridView1.GetRowCellValue(i, "idestado")
                    idciudad = GridView1.GetRowCellValue(i, "idciudad")
                    idcolonia = GridView1.GetRowCellValue(i, "idcolonia")
                    codigopostal = GridView1.GetRowCellValue(i, "codigopostal")
                    calle = GridView1.GetRowCellValue(i, "calle")
                    numero = GridView1.GetRowCellValue(i, "numero")
                    celular1 = GridView1.GetRowCellValue(i, "celular1")
                    email = GridView1.GetRowCellValue(i, "email")
                End If
            Next
            If sexo = "F" Then
                sexo = "FEMENINO"
            Else
                sexo = "MASCULINO"
            End If
            'myForm.getRow(IdCliente)
            'myForm.getRowCP(codigopostal)
            myForm.Txt_Nombre.Text = nombre
            myForm.Txt_ApellidoPa.Text = appaterno
            myForm.Txt_ApellidoMa.Text = apmaterno
            myForm.Txt_Calle.Text = calle
            myForm.Txt_Numero.Text = numero
            myForm.Txt_Cliente.Enabled = False
            myForm.Txt_Sucursal.Enabled = False
            myForm.Txt_Email.Text = email
            myForm.Cmb_Sexo.Text = sexo
            myForm.Txt_Telef.Text = celular1
            myForm.ShowDialog()
            Call InicializaGrid()
            Call RellenaGrid()

        Catch ExceptionErr As Exception
            MessageBox.Show("Seleccione un cliente porfavor, " & ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Salir_Click(sender As Object, e As EventArgs) Handles Btn_Salir.Click
        Me.Close()
    End Sub

    Private Sub Btn_Excel_Click(sender As Object, e As EventArgs) Handles Btn_Excel.Click
        Try
            If sfdRuta.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                DGrid.ExportToXls(sfdRuta.FileName)
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_DoubleClick(sender As Object, e As EventArgs) Handles DGrid.DoubleClick
        Try

            Dim Myform As New frmCatalogoCliente
            Dim Renglon As Point = DGrid.PointToClient(Control.MousePosition)
            Dim info As GridHitInfo = GridView1.CalcHitInfo(Renglon)

            Dim Renglon1 As Integer = info.RowHandle

            Myform.Accion = 3
            Myform.Text = Myform.Text + " (Consultar Cliente)"
            Myform.idcliente = GridView1.GetRowCellValue(Renglon1, "idcliente")

            Myform.Txt_Nombre.Text = GridView1.GetRowCellValue(Renglon1, "nombre")
            Myform.Txt_ApellidoPa.Text = GridView1.GetRowCellValue(Renglon1, "appaterno")
            Myform.Txt_ApellidoMa.Text = GridView1.GetRowCellValue(Renglon1, "apmaterno")
            Myform.Txt_Calle.Text = GridView1.GetRowCellValue(Renglon1, "calle")
            Myform.Txt_Numero.Text = GridView1.GetRowCellValue(Renglon1, "numero")
            Myform.Txt_Email.Text = GridView1.GetRowCellValue(Renglon1, "email")
            Myform.Txt_Telef.Text = GridView1.GetRowCellValue(Renglon1, "celular1")
            Myform.codigopostal = GridView1.GetRowCellValue(Renglon1, "codigopostal")
            sexo = GridView1.GetRowCellValue(Renglon1, "sexo")
            If sexo = "F" Then
                sexo = "FEMENINO"
            Else
                sexo = "MASCULINO"
            End If
            Myform.Cmb_Sexo.Text = sexo
            Myform.Btn_Aceptar.Enabled = False

            Myform.Pnl_DatosGenerales.Enabled = False
            Myform.Pnl_DomicilioPart.Enabled = False
            Myform.Pnl_Contacto.Enabled = False
            Myform.StartPosition = FormStartPosition.CenterScreen
            Myform.ShowDialog()

            If GLB_RefrescarPedido = True Then
                Call RellenaGrid()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show("Seleccione un cliente porfavor, " & ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Consultar_Click(sender As Object, e As EventArgs) Handles Btn_Consultar.Click
        Try

            Dim Myform As New frmCatalogoCliente
            Dim Renglon As Point = DGrid.PointToClient(Control.MousePosition)
            Dim info As GridHitInfo = GridView1.CalcHitInfo(Renglon)

            Dim Renglon1 As Integer = info.RowHandle

            Myform.Accion = 3
            Myform.Text = Myform.Text + " (Consultar Cliente) "
            Myform.idcliente = GridView1.GetRowCellValue(Renglon1, "idcliente")

            Myform.Txt_Nombre.Text = GridView1.GetRowCellValue(Renglon1, "nombre")
            Myform.Txt_ApellidoPa.Text = GridView1.GetRowCellValue(Renglon1, "appaterno")
            Myform.Txt_ApellidoMa.Text = GridView1.GetRowCellValue(Renglon1, "apmaterno")
            Myform.Txt_Calle.Text = GridView1.GetRowCellValue(Renglon1, "calle")
            Myform.Txt_Numero.Text = GridView1.GetRowCellValue(Renglon1, "numero")
            Myform.Txt_Email.Text = GridView1.GetRowCellValue(Renglon1, "email")
            Myform.Txt_Telef.Text = GridView1.GetRowCellValue(Renglon1, "celular1")
            Myform.codigopostal = GridView1.GetRowCellValue(Renglon1, "codigopostal")
            sexo = GridView1.GetRowCellValue(Renglon1, "sexo")
            If sexo = "F" Then
                sexo = "FEMENINO"
            Else
                sexo = "MASCULINO"
            End If
            Myform.Cmb_Sexo.Text = sexo
            Myform.Btn_Aceptar.Enabled = False

            Myform.Pnl_DatosGenerales.Enabled = False
            Myform.Pnl_DomicilioPart.Enabled = False
            Myform.Pnl_Contacto.Enabled = False
            Myform.StartPosition = FormStartPosition.CenterScreen
            Myform.ShowDialog()

            If GLB_RefrescarPedido = True Then
                Call RellenaGrid()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show("Seleccione un cliente porfavor, " & ExceptionErr.Message.ToString)
        End Try
        'Try
        '    Dim myForm As New frmCatalogoCliente
        '    myForm.Accion = 3
        '    myForm.Text = myForm.Text + " (Consultar Cliente)"

        '    Dim Renglon As Integer = 0
        '    Dim intposicion As Integer = 0
        '    Dim inttotalrows As Integer = 0
        '    Dim IdCliente As Integer = 0
        '    Dim tipo As String = ""
        '    Dim Observaciones As String = ""

        '    For i As Integer = 0 To GridView1.RowCount - 1


        '        If GridView1.IsRowSelected(i) = True Then
        '            IdCliente = GridView1.GetRowCellValue(i, "idcliente")
        '            nombre = GridView1.GetRowCellValue(i, "nombre")
        '            appaterno = GridView1.GetRowCellValue(i, "appaterno")
        '            apmaterno = GridView1.GetRowCellValue(i, "apmaterno")
        '            sexo = GridView1.GetRowCellValue(i, "sexo")
        '            idestado = GridView1.GetRowCellValue(i, "idestado")
        '            idciudad = GridView1.GetRowCellValue(i, "idciudad")
        '            idcolonia = GridView1.GetRowCellValue(i, "idcolonia")
        '            codigopostal = GridView1.GetRowCellValue(i, "codigopostal")
        '            calle = GridView1.GetRowCellValue(i, "calle")
        '            numero = GridView1.GetRowCellValue(i, "numero")
        '            celular1 = GridView1.GetRowCellValue(i, "celular1")
        '            email = GridView1.GetRowCellValue(i, "email")
        '        End If
        '    Next

        '    If sexo = "F" Then
        '        sexo = "FEMENINO"
        '    Else
        '        sexo = "MASCULINO"
        '    End If

        '    myForm.getRow(IdCliente)
        '    myForm.getRowCP(codigopostal)
        '    myForm.Txt_Nombre.Text = nombre
        '    myForm.Txt_ApellidoPa.Text = appaterno
        '    myForm.Txt_ApellidoMa.Text = apmaterno
        '    myForm.Txt_Calle.Text = calle
        '    myForm.Txt_Numero.Text = numero
        '    myForm.Txt_Email.Text = email
        '    myForm.Txt_Telef.Text = celular1
        '    myForm.Cmb_Sexo.Text = sexo
        '    myForm.Btn_Aceptar.Enabled = False

        '    myForm.Pnl_DatosGenerales.Enabled = False
        '    myForm.Pnl_DomicilioPart.Enabled = False
        '    myForm.Pnl_Contacto.Enabled = False

        '    myForm.ShowDialog()
        'Catch ExceptionErr As Exception
        '    MessageBox.Show("Seleccione un cliente porfavor, " & ExceptionErr.Message.ToString)
        'End Try
    End Sub
End Class