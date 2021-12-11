Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.BandedGrid
Imports System.Text.RegularExpressions
'Imports System.Web.UI.WebControls


Public Class frmPpalProyeccionComprasL1
    ' Public Event RowCreated As GridViewRowEventHandler
    ' Public CellValueChanged As CellValueChangedEventHandler
    Private objDataSet As Data.DataSet
    Private objDataSet1 As Data.DataSet 'Segundo Nivel
    Dim RenglonB As Integer = 0
    Dim ColumnaB As String = ""
    Dim Sw_Load As Boolean = False
    Dim Sw_Entro As Boolean = False

    Dim DiasMes1 As Integer = 0
    Dim DiasMes2 As Integer = 0
    Dim DiasMes3 As Integer = 0
    Dim DiasMes4 As Integer = 0
    Dim DiasMes5 As Integer = 0
    Dim DiasMes6 As Integer = 0
    Dim DiasMes7 As Integer = 0
    Dim DiasMes8 As Integer = 0
    Dim DiasMes9 As Integer = 0
    Dim DiasMes10 As Integer = 0
    Dim DiasMes11 As Integer = 0
    Dim DiasMes12 As Integer = 0

    Dim DI1 As Integer = 0
    Dim DI2 As Integer = 0
    Dim DI3 As Integer = 0
    Dim DI4 As Integer = 0
    Dim DI5 As Integer = 0
    Dim DI6 As Integer = 0
    Dim DI7 As Integer = 0
    Dim DI8 As Integer = 0
    Dim DI9 As Integer = 0
    Dim DI10 As Integer = 0
    Dim DI11 As Integer = 0
    Dim DI12 As Integer = 0

    Dim DiasInv1 As Decimal = 0.0
    Dim DiasInv2 As Decimal = 0.0
    Dim DiasInv3 As Decimal = 0.0
    Dim DiasInv4 As Decimal = 0.0
    Dim DiasInv5 As Decimal = 0.0
    Dim DiasInv6 As Decimal = 0.0
    Dim DiasInv7 As Decimal = 0.0
    Dim DiasInv8 As Decimal = 0.0
    Dim DiasInv9 As Decimal = 0.0
    Dim DiasInv10 As Decimal = 0.0
    Dim DiasInv11 As Decimal = 0.0
    Dim DiasInv12 As Decimal = 0.0

    Dim VtaDia1 As Decimal = 0.0
    Dim VtaDia2 As Decimal = 0.0
    Dim VtaDia3 As Decimal = 0.0
    Dim VtaDia4 As Decimal = 0.0
    Dim VtaDia5 As Decimal = 0.0
    Dim VtaDia6 As Decimal = 0.0
    Dim VtaDia7 As Decimal = 0.0
    Dim VtaDia8 As Decimal = 0.0
    Dim VtaDia9 As Decimal = 0.0
    Dim VtaDia10 As Decimal = 0.0
    Dim VtaDia11 As Decimal = 0.0
    Dim VtaDia12 As Decimal = 0.0

    Dim RenGranTotal As Integer = 0
    Dim RenTotal1 As Integer = 1
    Dim RenTotal2 As Integer = 7
    Dim RenTotal3 As Integer = 12
    Dim RenTotal4 As Integer = 21
    Dim RenTotal5 As Integer = 31
    Dim RenTotal6 As Integer = 42




    Private Sub Btn_Excel_Click(sender As Object, e As EventArgs) Handles Btn_Excel.Click
        If sfdRuta.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            DGrid1.ExportToXls(sfdRuta.FileName)
        End If
    End Sub

    Private Sub Btn_Salir_Click(sender As Object, e As EventArgs) Handles Btn_Salir.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub frmPpalProyeccionComprasL1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'Usp_PpalProyeccionComprasL1._usp_PpalProyeccionComprasL1' Puede moverla o quitarla según sea necesario.
        ' Me.Usp_PpalProyeccionComprasL1TableAdapter.Fill(Me.Usp_PpalProyeccionComprasL1._usp_PpalProyeccionComprasL1)
        Try
            Sw_Load = True
            Call RellenaGrid()


            For i As Integer = 0 To GridView1.RowCount - 1
                Call CalcularColumnas(i)
            Next
            Sw_Load = False
            DGrid1.Visible = False
            'Call CalcularColumnas(RenGranTotal)
            'Call CalcularColumnas(RenTotal1)
            'Call CalcularColumnas(RenTotal2)
            'Call CalcularColumnas(RenTotal3)
            'Call CalcularColumnas(RenTotal4)
            'Call CalcularColumnas(RenTotal5)
            'Call CalcularColumnas(RenTotal6)



            DGrid1.Visible = True
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub RellenaGrid()
        'mreyes 15/Agosto/2017
        Dim Fecha As Date = "1900-01-01"

        DGrid1.Visible = False
        'InicializaGrid()
        Using objTrasp As New BCL.BCLCostoMargen(GLB_ConStringDwhSQL)

            Try
                Me.Cursor = Cursors.WaitCursor
                'Sw_Load = False
                'DGrid.ReadOnly = True
                ' GridControl.DataSource = Nothing

                objDataSet = objTrasp.usp_PpalProyeccionComprasL1()


                'Populate the Project Details section

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    'Populate the Project Details section 
                    'DGrid.ColumnCount = objDataSet.Tables(0).Columns.Count
                    '
                    DGrid1.DataSource = objDataSet.Tables(0)

                    InicializaGrid()

                    Me.Cursor = Cursors.Default
                    Btn_Excel.Enabled = True
                    ' Sw_NoRegistros = True
                    'Sw_Pintar = True
                Else

                    ' Sw_NoRegistros = False
                    Me.Cursor = Cursors.Default
                    MsgBox("No se encontraron registros que cumplan con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")
                    Btn_Excel.Enabled = False
                End If
                Me.Cursor = Cursors.Default
                ' LimpiarBusqueda()
                DGrid1.Visible = True
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Sub InicializaGrid()
        Dim MesDescrip1 As String = ""
        Dim MesDescrip2 As String = ""
        Dim MesDescrip3 As String = ""
        Dim MesDescrip4 As String = ""
        Dim MesDescrip5 As String = ""
        Dim MesDescrip6 As String = ""
        Dim MesDescrip7 As String = ""
        Dim MesDescrip8 As String = ""
        Dim MesDescrip9 As String = ""
        Dim MesDescrip10 As String = ""
        Dim MesDescrip11 As String = ""
        Dim MesDescrip12 As String = ""

        Try

            GridView1.Columns(0).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns(1).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

            GridView1.Columns(1).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns(1).AppearanceHeader.Font = New Font(GridView1.Columns(1).AppearanceCell.Font, FontStyle.Bold)

            GridView1.Columns(2).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns(2).AppearanceHeader.Font = New Font(GridView1.Columns(2).AppearanceCell.Font, FontStyle.Bold)




            Dim MES = Month(GLB_FechaHoy)
            Dim Anio = Year(GLB_FechaHoy)

            '   MES = 1
            'For I As Integer = 3 To MES * 6 - 3
            '    GridView1.Columns(I).Visible = False

            'Next

            'For I As Integer = (MES + 8) * 6 - 3 To GridView1.Columns.Count - 3
            '    GridView1.Columns(I).Visible = False

            'Next

            If MES = 1 Then
                MesDescrip1 = "ENERO"
                MesDescrip2 = "FEBRERO"
                MesDescrip3 = "MARZO"
                MesDescrip4 = "ABRIL"
                MesDescrip5 = "MAYO"
                MesDescrip6 = "JUNIO"
                MesDescrip7 = "JULIO"
                MesDescrip8 = "AGOSTO"
                MesDescrip9 = "SEPTIEMBRE"
                MesDescrip10 = "OCTUBRE"
                MesDescrip11 = "NOVIEMBRE"
                MesDescrip12 = "DICIEMBRE"
                DiasMes1 = System.DateTime.DaysInMonth(Anio, 1)
                DiasMes2 = System.DateTime.DaysInMonth(Anio, 2)
                DiasMes3 = System.DateTime.DaysInMonth(Anio, 3)
                DiasMes4 = System.DateTime.DaysInMonth(Anio, 4)
                DiasMes5 = System.DateTime.DaysInMonth(Anio, 5)
                DiasMes6 = System.DateTime.DaysInMonth(Anio, 6)
                DiasMes7 = System.DateTime.DaysInMonth(Anio, 7)
                DiasMes8 = System.DateTime.DaysInMonth(Anio, 8)
                DiasMes9 = System.DateTime.DaysInMonth(Anio, 9)
                DiasMes10 = System.DateTime.DaysInMonth(Anio, 10)
                DiasMes11 = System.DateTime.DaysInMonth(Anio, 11)
                DiasMes12 = System.DateTime.DaysInMonth(Anio, 12)

            End If
            If MES = 2 Then

                MesDescrip1 = "FEBRERO"
                MesDescrip2 = "MARZO"
                MesDescrip3 = "ABRIL"
                MesDescrip4 = "MAYO"
                MesDescrip5 = "JUNIO"
                MesDescrip6 = "JULIO"
                MesDescrip7 = "AGOSTO"
                MesDescrip8 = "SEPTIEMBRE"
                MesDescrip9 = "OCTUBRE"
                MesDescrip10 = "NOVIEMBRE"
                MesDescrip11 = "DICIEMBRE"
                MesDescrip12 = "ENERO"
                DiasMes1 = System.DateTime.DaysInMonth(Anio, 2)
                DiasMes2 = System.DateTime.DaysInMonth(Anio, 3)
                DiasMes3 = System.DateTime.DaysInMonth(Anio, 4)
                DiasMes4 = System.DateTime.DaysInMonth(Anio, 5)
                DiasMes5 = System.DateTime.DaysInMonth(Anio, 6)
                DiasMes6 = System.DateTime.DaysInMonth(Anio, 7)
                DiasMes7 = System.DateTime.DaysInMonth(Anio, 8)
                DiasMes8 = System.DateTime.DaysInMonth(Anio, 9)
                DiasMes9 = System.DateTime.DaysInMonth(Anio, 10)
                DiasMes10 = System.DateTime.DaysInMonth(Anio, 11)
                DiasMes11 = System.DateTime.DaysInMonth(Anio, 12)
                DiasMes12 = System.DateTime.DaysInMonth(Anio + 1, 1)

            End If

            If MES = 3 Then
                MesDescrip1 = "MARZO"
                MesDescrip2 = "ABRIL"
                MesDescrip3 = "MAYO"
                MesDescrip4 = "JUNIO"
                MesDescrip5 = "JULIO"
                MesDescrip6 = "AGOSTO"
                MesDescrip7 = "SEPTIEMBRE"
                MesDescrip8 = "OCTUBRE"
                MesDescrip9 = "NOVIEMBRE"
                MesDescrip10 = "DICIEMBRE"
                MesDescrip11 = "ENERO"
                MesDescrip12 = "FEBRERO"
                DiasMes1 = System.DateTime.DaysInMonth(Anio, 3)
                DiasMes2 = System.DateTime.DaysInMonth(Anio, 4)
                DiasMes3 = System.DateTime.DaysInMonth(Anio, 5)
                DiasMes4 = System.DateTime.DaysInMonth(Anio, 6)
                DiasMes5 = System.DateTime.DaysInMonth(Anio, 7)
                DiasMes6 = System.DateTime.DaysInMonth(Anio, 8)
                DiasMes7 = System.DateTime.DaysInMonth(Anio, 9)
                DiasMes8 = System.DateTime.DaysInMonth(Anio, 10)
                DiasMes9 = System.DateTime.DaysInMonth(Anio, 11)
                DiasMes10 = System.DateTime.DaysInMonth(Anio, 12)
                DiasMes11 = System.DateTime.DaysInMonth(Anio + 1, 1)
                DiasMes12 = System.DateTime.DaysInMonth(Anio + 1, 2)
            End If

            If MES = 4 Then

                MesDescrip1 = "ABRIL"
                MesDescrip2 = "MAYO"
                MesDescrip3 = "JUNIO"
                MesDescrip4 = "JULIO"
                MesDescrip5 = "AGOSTO"
                MesDescrip6 = "SEPTIEMBRE"
                MesDescrip7 = "OCTUBRE"
                MesDescrip8 = "NOVIEMBRE"
                MesDescrip9 = "DICIEMBRE"
                MesDescrip10 = "ENERO"
                MesDescrip11 = "FEBRERO"
                MesDescrip12 = "MARZO"
                DiasMes1 = System.DateTime.DaysInMonth(Anio, 4)
                DiasMes2 = System.DateTime.DaysInMonth(Anio, 5)
                DiasMes3 = System.DateTime.DaysInMonth(Anio, 6)
                DiasMes4 = System.DateTime.DaysInMonth(Anio, 7)
                DiasMes5 = System.DateTime.DaysInMonth(Anio, 8)
                DiasMes6 = System.DateTime.DaysInMonth(Anio, 9)
                DiasMes7 = System.DateTime.DaysInMonth(Anio, 10)
                DiasMes8 = System.DateTime.DaysInMonth(Anio, 11)
                DiasMes9 = System.DateTime.DaysInMonth(Anio, 12)
                DiasMes10 = System.DateTime.DaysInMonth(Anio + 1, 1)
                DiasMes11 = System.DateTime.DaysInMonth(Anio + 1, 2)
                DiasMes12 = System.DateTime.DaysInMonth(Anio + 1, 3)
            End If

            If MES = 5 Then
                MesDescrip1 = "MAYO"
                MesDescrip2 = "JUNIO"
                MesDescrip3 = "JULIO"
                MesDescrip4 = "AGOSTO"
                MesDescrip5 = "SEPTIEMBRE"
                MesDescrip6 = "OCTUBRE"
                MesDescrip7 = "NOVIEMBRE"
                MesDescrip8 = "DICIEMBRE"
                MesDescrip9 = "ENERO"
                MesDescrip10 = "FEBRERO"
                MesDescrip11 = "MARZO"
                MesDescrip12 = "ABRIL"
                DiasMes1 = System.DateTime.DaysInMonth(Anio, 5)
                DiasMes2 = System.DateTime.DaysInMonth(Anio, 6)
                DiasMes3 = System.DateTime.DaysInMonth(Anio, 7)
                DiasMes4 = System.DateTime.DaysInMonth(Anio, 8)
                DiasMes5 = System.DateTime.DaysInMonth(Anio, 9)
                DiasMes6 = System.DateTime.DaysInMonth(Anio, 10)
                DiasMes7 = System.DateTime.DaysInMonth(Anio, 11)
                DiasMes8 = System.DateTime.DaysInMonth(Anio, 12)
                DiasMes9 = System.DateTime.DaysInMonth(Anio + 1, 1)
                DiasMes10 = System.DateTime.DaysInMonth(Anio + 1, 2)
                DiasMes11 = System.DateTime.DaysInMonth(Anio + 1, 3)
                DiasMes12 = System.DateTime.DaysInMonth(Anio + 1, 4)
            End If

            If MES = 6 Then

                MesDescrip1 = "JUNIO"
                MesDescrip2 = "JULIO"
                MesDescrip3 = "AGOSTO"
                MesDescrip4 = "SEPTIEMBRE"
                MesDescrip5 = "OCTUBRE"
                MesDescrip6 = "NOVIEMBRE"
                MesDescrip7 = "DICIEMBRE"
                MesDescrip8 = "ENERO"
                MesDescrip9 = "FEBRERO"
                MesDescrip10 = "MARZO"
                MesDescrip11 = "ABRIL"
                MesDescrip12 = "MAYO"
                DiasMes1 = System.DateTime.DaysInMonth(Anio, 6)
                DiasMes2 = System.DateTime.DaysInMonth(Anio, 7)
                DiasMes3 = System.DateTime.DaysInMonth(Anio, 8)
                DiasMes4 = System.DateTime.DaysInMonth(Anio, 9)
                DiasMes5 = System.DateTime.DaysInMonth(Anio, 10)
                DiasMes6 = System.DateTime.DaysInMonth(Anio, 11)
                DiasMes7 = System.DateTime.DaysInMonth(Anio, 12)
                DiasMes8 = System.DateTime.DaysInMonth(Anio + 1, 1)
                DiasMes9 = System.DateTime.DaysInMonth(Anio + 1, 2)
                DiasMes10 = System.DateTime.DaysInMonth(Anio + 1, 3)
                DiasMes11 = System.DateTime.DaysInMonth(Anio + 1, 4)
                DiasMes12 = System.DateTime.DaysInMonth(Anio + 1, 5)
            End If

            If MES = 7 Then
                MesDescrip1 = "JULIO"
                MesDescrip2 = "AGOSTO"
                MesDescrip3 = "SEPTIEMBRE"
                MesDescrip4 = "OCTUBRE"
                MesDescrip5 = "NOVIEMBRE"
                MesDescrip6 = "DICIEMBRE"
                MesDescrip7 = "ENERO"
                MesDescrip8 = "FEBRERO"
                MesDescrip9 = "MARZO"
                MesDescrip10 = "ABRIL"
                MesDescrip11 = "MAYO"
                MesDescrip12 = "JUNIO"
                DiasMes1 = System.DateTime.DaysInMonth(Anio, 7)
                DiasMes2 = System.DateTime.DaysInMonth(Anio, 8)
                DiasMes3 = System.DateTime.DaysInMonth(Anio, 9)
                DiasMes4 = System.DateTime.DaysInMonth(Anio, 10)
                DiasMes5 = System.DateTime.DaysInMonth(Anio, 11)
                DiasMes6 = System.DateTime.DaysInMonth(Anio, 12)
                DiasMes7 = System.DateTime.DaysInMonth(Anio + 1, 1)
                DiasMes8 = System.DateTime.DaysInMonth(Anio + 1, 2)
                DiasMes9 = System.DateTime.DaysInMonth(Anio + 1, 3)
                DiasMes10 = System.DateTime.DaysInMonth(Anio + 1, 4)
                DiasMes11 = System.DateTime.DaysInMonth(Anio + 1, 5)
                DiasMes12 = System.DateTime.DaysInMonth(Anio + 1, 6)
            End If

            If MES = 8 Then
                MesDescrip1 = "AGOSTO"
                MesDescrip2 = "SEPTIEMBRE"
                MesDescrip3 = "OCTUBRE"
                MesDescrip4 = "NOVIEMBRE"
                MesDescrip5 = "DICIEMBRE"
                MesDescrip6 = "ENERO"
                MesDescrip7 = "FEBRERO"
                MesDescrip8 = "MARZO"
                MesDescrip9 = "ABRIL"
                MesDescrip10 = "MAYO"
                MesDescrip11 = "JUNIO"
                MesDescrip12 = "JULIO"
                DiasMes1 = System.DateTime.DaysInMonth(Anio, 8)
                DiasMes2 = System.DateTime.DaysInMonth(Anio, 9)
                DiasMes3 = System.DateTime.DaysInMonth(Anio, 10)
                DiasMes4 = System.DateTime.DaysInMonth(Anio, 11)
                DiasMes5 = System.DateTime.DaysInMonth(Anio, 12)
                DiasMes6 = System.DateTime.DaysInMonth(Anio + 1, 1)
                DiasMes7 = System.DateTime.DaysInMonth(Anio + 1, 2)
                DiasMes8 = System.DateTime.DaysInMonth(Anio + 1, 3)
                DiasMes9 = System.DateTime.DaysInMonth(Anio + 1, 4)
                DiasMes10 = System.DateTime.DaysInMonth(Anio + 1, 5)
                DiasMes11 = System.DateTime.DaysInMonth(Anio + 1, 6)
                DiasMes12 = System.DateTime.DaysInMonth(Anio + 1, 7)




            End If

            If MES = 9 Then

                MesDescrip1 = "SEPTIEMBRE"
                MesDescrip2 = "OCTUBRE"
                MesDescrip3 = "NOVIEMBRE"
                MesDescrip4 = "DICIEMBRE"
                MesDescrip5 = "ENERO"
                MesDescrip6 = "FEBRERO"
                MesDescrip7 = "MARZO"
                MesDescrip8 = "ABRIL"
                MesDescrip9 = "MAYO"
                MesDescrip10 = "JUNIO"
                MesDescrip11 = "JULIO"
                MesDescrip12 = "AGOSTO"
                DiasMes1 = System.DateTime.DaysInMonth(Anio, 9)
                DiasMes2 = System.DateTime.DaysInMonth(Anio, 10)
                DiasMes3 = System.DateTime.DaysInMonth(Anio, 11)
                DiasMes4 = System.DateTime.DaysInMonth(Anio, 12)
                DiasMes5 = System.DateTime.DaysInMonth(Anio + 1, 1)
                DiasMes6 = System.DateTime.DaysInMonth(Anio + 1, 2)
                DiasMes7 = System.DateTime.DaysInMonth(Anio + 1, 3)
                DiasMes8 = System.DateTime.DaysInMonth(Anio + 1, 4)
                DiasMes9 = System.DateTime.DaysInMonth(Anio + 1, 5)
                DiasMes10 = System.DateTime.DaysInMonth(Anio + 1, 6)
                DiasMes11 = System.DateTime.DaysInMonth(Anio + 1, 7)
                DiasMes12 = System.DateTime.DaysInMonth(Anio + 1, 8)

            End If

            If MES = 10 Then
                MesDescrip1 = "OCTUBRE"
                MesDescrip2 = "NOVIEMBRE"
                MesDescrip3 = "DICIEMBRE"
                MesDescrip4 = "ENERO"
                MesDescrip5 = "FEBRERO"
                MesDescrip6 = "MARZO"
                MesDescrip7 = "ABRIL"
                MesDescrip8 = "MAYO"
                MesDescrip9 = "JUNIO"
                MesDescrip10 = "JULIO"
                MesDescrip11 = "AGOSTO"
                MesDescrip12 = "SEPTIEMBRE"
                DiasMes1 = System.DateTime.DaysInMonth(Anio, 10)
                DiasMes2 = System.DateTime.DaysInMonth(Anio, 11)
                DiasMes3 = System.DateTime.DaysInMonth(Anio, 12)
                DiasMes4 = System.DateTime.DaysInMonth(Anio + 1, 1)
                DiasMes5 = System.DateTime.DaysInMonth(Anio + 1, 2)
                DiasMes6 = System.DateTime.DaysInMonth(Anio + 1, 3)
                DiasMes7 = System.DateTime.DaysInMonth(Anio + 1, 4)
                DiasMes8 = System.DateTime.DaysInMonth(Anio + 1, 5)
                DiasMes9 = System.DateTime.DaysInMonth(Anio + 1, 6)
                DiasMes10 = System.DateTime.DaysInMonth(Anio + 1, 7)
                DiasMes11 = System.DateTime.DaysInMonth(Anio + 1, 8)
                DiasMes12 = System.DateTime.DaysInMonth(Anio + 1, 9)
            End If

            If MES = 11 Then

                MesDescrip1 = "NOVIEMBRE"
                MesDescrip2 = "DICIEMBRE"
                MesDescrip3 = "ENERO"
                MesDescrip4 = "FEBRERO"
                MesDescrip5 = "MARZO"
                MesDescrip6 = "ABRIL"
                MesDescrip7 = "MAYO"
                MesDescrip8 = "JUNIO"
                MesDescrip9 = "JULIO"
                MesDescrip10 = "AGOSTO"
                MesDescrip11 = "SEPTIEMBRE"
                MesDescrip12 = "OCTUBRE"
                DiasMes1 = System.DateTime.DaysInMonth(Anio, 11)
                DiasMes2 = System.DateTime.DaysInMonth(Anio, 12)
                DiasMes3 = System.DateTime.DaysInMonth(Anio + 1, 1)
                DiasMes4 = System.DateTime.DaysInMonth(Anio + 1, 2)
                DiasMes5 = System.DateTime.DaysInMonth(Anio + 1, 3)
                DiasMes6 = System.DateTime.DaysInMonth(Anio + 1, 4)
                DiasMes7 = System.DateTime.DaysInMonth(Anio + 1, 5)
                DiasMes8 = System.DateTime.DaysInMonth(Anio + 1, 6)
                DiasMes9 = System.DateTime.DaysInMonth(Anio + 1, 7)
                DiasMes10 = System.DateTime.DaysInMonth(Anio + 1, 8)
                DiasMes11 = System.DateTime.DaysInMonth(Anio + 1, 9)
                DiasMes12 = System.DateTime.DaysInMonth(Anio + 1, 10)

            End If

            If MES = 12 Then
                MesDescrip1 = "DICIEMBRE"
                MesDescrip2 = "ENERO"
                MesDescrip3 = "FEBRERO"
                MesDescrip4 = "MARZO"
                MesDescrip5 = "ABRIL"
                MesDescrip6 = "MAYO"
                MesDescrip7 = "JUNIO"
                MesDescrip8 = "JULIO"
                MesDescrip9 = "AGOSTO"
                MesDescrip10 = "SEPTIEMBRE"
                MesDescrip11 = "OCTUBRE"
                MesDescrip12 = "NOVIEMBRE"
                DiasMes1 = System.DateTime.DaysInMonth(Anio, 12)
                DiasMes2 = System.DateTime.DaysInMonth(Anio + 1, 1)
                DiasMes3 = System.DateTime.DaysInMonth(Anio + 1, 2)
                DiasMes4 = System.DateTime.DaysInMonth(Anio + 1, 3)
                DiasMes5 = System.DateTime.DaysInMonth(Anio + 1, 4)
                DiasMes6 = System.DateTime.DaysInMonth(Anio + 1, 5)
                DiasMes7 = System.DateTime.DaysInMonth(Anio + 1, 6)
                DiasMes8 = System.DateTime.DaysInMonth(Anio + 1, 7)
                DiasMes9 = System.DateTime.DaysInMonth(Anio + 1, 8)
                DiasMes10 = System.DateTime.DaysInMonth(Anio + 1, 9)
                DiasMes11 = System.DateTime.DaysInMonth(Anio + 1, 10)
                DiasMes12 = System.DateTime.DaysInMonth(Anio + 1, 11)
            End If

            GridView1.Columns(3).Caption = MesDescrip1 & " Inicial"
            GridView1.Columns(4).Caption = MesDescrip1 & " Venta"
            GridView1.Columns(5).Caption = MesDescrip1 & " XRecibir"
            GridView1.Columns(6).Caption = MesDescrip1 & " Inv + Recibo"
            GridView1.Columns(7).Caption = MesDescrip1 & " Recibo"
            GridView1.Columns(8).Caption = MesDescrip1 & " Dias Inv."

            GridView1.Columns(9).Caption = MesDescrip2 & " Inicial"
            GridView1.Columns(10).Caption = MesDescrip2 & " Venta"
            GridView1.Columns(11).Caption = MesDescrip2 & " XRecibir"
            GridView1.Columns(12).Caption = MesDescrip2 & " Inv + Recibo"
            GridView1.Columns(13).Caption = MesDescrip2 & " Recibo"
            GridView1.Columns(14).Caption = MesDescrip2 & " Dias Inv."

            GridView1.Columns(15).Caption = MesDescrip3 & " Inicial"
            GridView1.Columns(16).Caption = MesDescrip3 & " Venta"
            GridView1.Columns(17).Caption = MesDescrip3 & " XRecibir"
            GridView1.Columns(18).Caption = MesDescrip3 & " Inv + Recibo"
            GridView1.Columns(19).Caption = MesDescrip3 & " Recibo"
            GridView1.Columns(20).Caption = MesDescrip3 & " Dias Inv."

            GridView1.Columns(21).Caption = MesDescrip4 & " Inicial"
            GridView1.Columns(22).Caption = MesDescrip4 & " Venta"
            GridView1.Columns(23).Caption = MesDescrip4 & " XRecibir"
            GridView1.Columns(24).Caption = MesDescrip4 & " Inv + Recibo"
            GridView1.Columns(25).Caption = MesDescrip4 & " Recibo"
            GridView1.Columns(26).Caption = MesDescrip4 & " Dias Inv."

            GridView1.Columns(27).Caption = MesDescrip5 & " Inicial"
            GridView1.Columns(28).Caption = MesDescrip5 & " Venta"
            GridView1.Columns(29).Caption = MesDescrip5 & " XRecibir"
            GridView1.Columns(30).Caption = MesDescrip5 & " Inv + Recibo"
            GridView1.Columns(31).Caption = MesDescrip5 & " Recibo"
            GridView1.Columns(32).Caption = MesDescrip5 & " Dias Inv."

            GridView1.Columns(33).Caption = MesDescrip6 & " Inicial"
            GridView1.Columns(34).Caption = MesDescrip6 & " Venta"
            GridView1.Columns(35).Caption = MesDescrip6 & " XRecibir"
            GridView1.Columns(36).Caption = MesDescrip6 & " Inv + Recibo"
            GridView1.Columns(37).Caption = MesDescrip6 & " Recibo"
            GridView1.Columns(38).Caption = MesDescrip6 & " Dias Inv."

            GridView1.Columns(39).Caption = MesDescrip7 & " Inicial"
            GridView1.Columns(40).Caption = MesDescrip7 & " Venta"
            GridView1.Columns(41).Caption = MesDescrip7 & " XRecibir"
            GridView1.Columns(42).Caption = MesDescrip7 & " Inv + Recibo"
            GridView1.Columns(43).Caption = MesDescrip7 & " Recibo"
            GridView1.Columns(44).Caption = MesDescrip7 & " Dias Inv."

            GridView1.Columns(45).Caption = MesDescrip8 & " Inicial"
            GridView1.Columns(46).Caption = MesDescrip8 & " Venta"
            GridView1.Columns(47).Caption = MesDescrip8 & " XRecibir"
            GridView1.Columns(48).Caption = MesDescrip8 & " Inv + Recibo"
            GridView1.Columns(49).Caption = MesDescrip8 & " Recibo"
            GridView1.Columns(50).Caption = MesDescrip8 & " Dias Inv."


            GridView1.Columns(51).Caption = MesDescrip9 & " Inicial"
            GridView1.Columns(52).Caption = MesDescrip9 & " Venta"
            GridView1.Columns(53).Caption = MesDescrip9 & " XRecibir"
            GridView1.Columns(54).Caption = MesDescrip9 & " Inv + Recibo"
            GridView1.Columns(55).Caption = MesDescrip9 & " Recibo"
            GridView1.Columns(56).Caption = MesDescrip9 & " Dias Inv."

            GridView1.Columns(57).Caption = MesDescrip10 & " Inicial"
            GridView1.Columns(58).Caption = MesDescrip10 & " Venta"
            GridView1.Columns(59).Caption = MesDescrip10 & " XRecibir"
            GridView1.Columns(60).Caption = MesDescrip10 & " Inv + Recibo"
            GridView1.Columns(61).Caption = MesDescrip10 & " Recibo"
            GridView1.Columns(62).Caption = MesDescrip10 & " Dias Inv."

            GridView1.Columns(63).Caption = MesDescrip11 & " Inicial"
            GridView1.Columns(64).Caption = MesDescrip11 & " Venta"
            GridView1.Columns(65).Caption = MesDescrip11 & " XRecibir"
            GridView1.Columns(66).Caption = MesDescrip11 & " Inv + Recibo"
            GridView1.Columns(67).Caption = MesDescrip11 & " Recibo"
            GridView1.Columns(68).Caption = MesDescrip11 & " Dias Inv."

            GridView1.Columns(69).Caption = MesDescrip12 & " Inicial"
            GridView1.Columns(70).Caption = MesDescrip12 & " Venta"
            GridView1.Columns(71).Caption = MesDescrip12 & " XRecibir"
            GridView1.Columns(72).Caption = MesDescrip12 & " Inv + Recibo"
            GridView1.Columns(73).Caption = MesDescrip12 & " Recibo"
            GridView1.Columns(74).Caption = MesDescrip12 & " Dias Inv."


            ' DGrid1.Row.Cells(MES * 5 + 1).RowSpan = 2

            GridView1.OptionsView.ColumnAutoWidth = False
            GridView1.OptionsView.BestFitMaxRowCount = -1
            GridView1.BestFitColumns()

            'For I As Integer = 0 To GridView1.Columns.Count - 1
            '    GridView1.Columns(I).OptionsColumn.ReadOnly = True
            '    ' GridView1.Columns(I).OptionsColumn.AllowMerge = True
            'Next


            For I As Integer = 3 To GridView1.Columns.Count - 3

                '    GridView1.Columns(I).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                '    GridView1.Columns(I).DisplayFormat.FormatString = "#,###,###"
                GridView1.Columns(I).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                GridView1.Columns(I).AppearanceHeader.Font = New Font(GridView1.Columns(I).AppearanceCell.Font, FontStyle.Bold)

                GridView1.Columns(I).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            Next

            GridView1.Columns(6).Visible = False
            GridView1.Columns(12).Visible = False
            GridView1.Columns(18).Visible = False
            GridView1.Columns(24).Visible = False
            GridView1.Columns(30).Visible = False
            GridView1.Columns(36).Visible = False
            GridView1.Columns(42).Visible = False
            GridView1.Columns(48).Visible = False
            GridView1.Columns(54).Visible = False
            GridView1.Columns(60).Visible = False
            GridView1.Columns(66).Visible = False
            GridView1.Columns(72).Visible = False
            GridView1.Columns(75).Visible = False
            GridView1.Columns(76).Visible = False



            'GridView1.Columns(4).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            'GridView1.Columns(4).DisplayFormat.FormatString = "##"
            'GridView1.Columns(4).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            'GridView1.Columns(4).AppearanceHeader.Font = New Font(GridView1.Columns(4).AppearanceCell.Font, FontStyle.Bold)


            '' Call Colorear()
            'GridView1.FixedLineWidth = 4
            'GridView1.Columns(0).Fixed = 0
            'GridView1.Columns(1).Fixed = 1
            'GridView1.Columns(2).Fixed = 1




        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub frmPpalProyeccionComprasL1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged

        Try

            If Sw_Load = True Then
                Return
            End If
            If sw_entro = True Then
                Return
            End If
            Dim Renglon As Integer = 0
            Dim Columna As String = ""
            Columna = e.Column.Name

            Renglon = e.RowHandle


            ''''If Columna = ColumnaB And Renglon = RenglonB Then
            ''''    Return
            ''''End If

            Dim cellValue As String = e.Value.ToString() ''+ " " + view.GetRowCellValue(e.RowHandle, view.Columns("LastName")).ToString()
            ''view.SetRowCellValue(e.RowHandle, view.Columns("FullName"), cellValue)
            'MsgBox(cellValue)

            RenglonB = Renglon
            ColumnaB = Columna

            Call CalcularColumnas(Renglon)
            Call usp_Totales(Renglon)
            Call usp_TotalesGran()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub CalcularColumnas(Renglon As Integer)
        Try


            Dim Inv1 As Integer = 0
            Dim Vta1 As Integer = 0
            Dim XRecibir1 As Integer = 0
            Dim invRecibo1 As Integer = 0
            Dim Recibo1 As Integer = 0

            Dim Total As Integer = 0

            Dim Inv2 As Integer = 0
            Dim Vta2 As Integer = 0
            Dim XRecibir2 As Integer = 0
            Dim invRecibo2 As Integer = 0
            Dim Recibo2 As Integer = 0


            Dim Inv3 As Integer = 0
            Dim Vta3 As Integer = 0
            Dim XRecibir3 As Integer = 0
            Dim invRecibo3 As Integer = 0
            Dim Recibo3 As Integer = 0


            Dim Inv4 As Integer = 0
            Dim Vta4 As Integer = 0
            Dim XRecibir4 As Integer = 0
            Dim invRecibo4 As Integer = 0
            Dim Recibo4 As Integer = 0

            Dim Inv5 As Integer = 0
            Dim Vta5 As Integer = 0
            Dim XRecibir5 As Integer = 0
            Dim invRecibo5 As Integer = 0
            Dim Recibo5 As Integer = 0

            Dim Inv6 As Integer = 0
            Dim Vta6 As Integer = 0
            Dim XRecibir6 As Integer = 0
            Dim invRecibo6 As Integer = 0
            Dim Recibo6 As Integer = 0

            Dim Inv7 As Integer = 0
            Dim Vta7 As Integer = 0
            Dim XRecibir7 As Integer = 0
            Dim invRecibo7 As Integer = 0
            Dim Recibo7 As Integer = 0

            Dim Inv8 As Integer = 0
            Dim Vta8 As Integer = 0
            Dim XRecibir8 As Integer = 0
            Dim invRecibo8 As Integer = 0
            Dim Recibo8 As Integer = 0

            Dim Inv9 As Integer = 0
            Dim Vta9 As Integer = 0
            Dim XRecibir9 As Integer = 0
            Dim invRecibo9 As Integer = 0
            Dim Recibo9 As Integer = 0


            Dim Inv10 As Integer = 0
            Dim Vta10 As Integer = 0
            Dim XRecibir10 As Integer = 0
            Dim invRecibo10 As Integer = 0
            Dim Recibo10 As Integer = 0

            Dim Inv11 As Integer = 0
            Dim Vta11 As Integer = 0
            Dim XRecibir11 As Integer = 0
            Dim invRecibo11 As Integer = 0
            Dim Recibo11 As Integer = 0


            Dim Inv12 As Integer = 0
            Dim Vta12 As Integer = 0
            Dim XRecibir12 As Integer = 0
            Dim invRecibo12 As Integer = 0
            Dim Recibo12 As Integer = 0



            'DGrid1.Visible = False
            Sw_Entro = True
            Inv1 = GridView1.GetRowCellValue(Renglon, "inv1")
            Vta1 = GridView1.GetRowCellValue(Renglon, "vta1")
            XRecibir1 = GridView1.GetRowCellValue(Renglon, "xrecibir1")
            invRecibo1 = GridView1.GetRowCellValue(Renglon, "xrecibir1")
            Recibo1 = GridView1.GetRowCellValue(Renglon, "recibo1")
            invRecibo1 = Inv1 + Recibo1 + XRecibir1

            GridView1.SetRowCellValue(Renglon, "invrecibo1", invRecibo1)

            ''= SI(H5 < F5, H5 / F5 * 30, SI(Y(H5 > F5, H5 < (F5 + P5)), (30 + (H5 - F5) / P5 * 30), SI(Y(H5 > (F5 + P5), H5 < (F5 + P5 + W5)), (60 + (H5 - F5 - P5) / W5 * 30), SI(Y(H5 > (F5 + P5 + W5), H5 < (F5 + P5 + W5 + AD5)), 90 + (H5 - F5 - P5 - W5) / AD5 * 30, SI(Y(H5 > (F5 + P5 + W5 + AD5), H5 < (F5 + P5 + W5 + AD5 + AK5)), 120 + (H5 - F5 - P5 - W5 - AD5) / AK5 * 30, SI(Y(H5 > (F5 + P5 + W5 + AD5 + AK5), H5 < (F5 + P5 + W5 + AD5 + AK5 + AR5)), 150 + (H5 - F5 - P5 - W5 - AD5 - AK5) / AR5 * 30, H5 / F5 * 30))))))
            ''SEGUNDO MES 
            Inv2 = invRecibo1 - Vta1
            Vta2 = GridView1.GetRowCellValue(Renglon, "vta2")
            XRecibir2 = GridView1.GetRowCellValue(Renglon, "xrecibir2")
            invRecibo2 = GridView1.GetRowCellValue(Renglon, "xrecibir2")
            Recibo2 = GridView1.GetRowCellValue(Renglon, "recibo2")
            invRecibo2 = Inv2 + Recibo2 + XRecibir2

            GridView1.SetRowCellValue(Renglon, "inv2", Inv2)
            GridView1.SetRowCellValue(Renglon, "invrecibo2", invRecibo2)

            '' TERCER MES 
            Inv3 = invRecibo2 - Vta2
            Vta3 = GridView1.GetRowCellValue(Renglon, "vta3")
            XRecibir3 = GridView1.GetRowCellValue(Renglon, "xrecibir3")
            invRecibo3 = GridView1.GetRowCellValue(Renglon, "xrecibir3")
            Recibo3 = GridView1.GetRowCellValue(Renglon, "recibo3")
            invRecibo3 = Inv3 + Recibo3 + XRecibir3
            GridView1.SetRowCellValue(Renglon, "inv3", Inv3)
            GridView1.SetRowCellValue(Renglon, "invrecibo3", invRecibo3)

            '' CUARTO MES 
            Inv4 = invRecibo3 - Vta3
            Vta4 = GridView1.GetRowCellValue(Renglon, "vta4")
            XRecibir4 = GridView1.GetRowCellValue(Renglon, "xrecibir4")
            invRecibo4 = GridView1.GetRowCellValue(Renglon, "xrecibir4")
            Recibo4 = GridView1.GetRowCellValue(Renglon, "recibo4")
            invRecibo4 = Inv4 + Recibo4 + XRecibir4
            GridView1.SetRowCellValue(Renglon, "inv4", Inv4)
            GridView1.SetRowCellValue(Renglon, "invrecibo4", invRecibo4)

            '' QUINTO MES 
            Inv5 = invRecibo4 - Vta4
            Vta5 = GridView1.GetRowCellValue(Renglon, "vta5")
            XRecibir5 = GridView1.GetRowCellValue(Renglon, "xrecibir5")
            invRecibo5 = GridView1.GetRowCellValue(Renglon, "xrecibir5")
            Recibo5 = GridView1.GetRowCellValue(Renglon, "recibo5")
            invRecibo5 = Inv5 + Recibo5 + XRecibir5
            GridView1.SetRowCellValue(Renglon, "inv5", Inv5)
            GridView1.SetRowCellValue(Renglon, "invrecibo5", invRecibo5)

            '' SEXTO MES 
            Inv6 = invRecibo5 - Vta5
            Vta6 = GridView1.GetRowCellValue(Renglon, "vta6")
            XRecibir6 = GridView1.GetRowCellValue(Renglon, "xrecibir6")
            invRecibo6 = GridView1.GetRowCellValue(Renglon, "xrecibir6")
            Recibo6 = GridView1.GetRowCellValue(Renglon, "recibo6")
            invRecibo6 = Inv6 + Recibo6 + XRecibir6
            GridView1.SetRowCellValue(Renglon, "inv6", Inv6)
            GridView1.SetRowCellValue(Renglon, "invrecibo6", invRecibo6)

            '' SEPTIMO MES 
            Inv7 = invRecibo6 - Vta6
            Vta7 = GridView1.GetRowCellValue(Renglon, "vta7")
            XRecibir7 = GridView1.GetRowCellValue(Renglon, "xrecibir7")
            invRecibo7 = GridView1.GetRowCellValue(Renglon, "xrecibir7")
            Recibo7 = GridView1.GetRowCellValue(Renglon, "recibo7")
            invRecibo7 = Inv7 + Recibo7 + XRecibir7
            GridView1.SetRowCellValue(Renglon, "inv7", Inv7)
            GridView1.SetRowCellValue(Renglon, "invrecibo7", invRecibo7)


            '' OCTAVO MES 
            Inv8 = invRecibo7 - Vta7
            Vta8 = GridView1.GetRowCellValue(Renglon, "vta8")
            XRecibir8 = GridView1.GetRowCellValue(Renglon, "xrecibir8")
            invRecibo8 = GridView1.GetRowCellValue(Renglon, "xrecibir8")
            Recibo8 = GridView1.GetRowCellValue(Renglon, "recibo8")
            invRecibo8 = Inv8 + Recibo8 + XRecibir8
            GridView1.SetRowCellValue(Renglon, "inv8", Inv8)
            GridView1.SetRowCellValue(Renglon, "invrecibo8", invRecibo8)

            '' NOVENO MES 
            Inv9 = invRecibo8 - Vta8
            Vta9 = GridView1.GetRowCellValue(Renglon, "vta9")
            XRecibir9 = GridView1.GetRowCellValue(Renglon, "xrecibir9")
            invRecibo9 = GridView1.GetRowCellValue(Renglon, "xrecibir9")
            Recibo9 = GridView1.GetRowCellValue(Renglon, "recibo9")
            invRecibo9 = Inv9 + Recibo9 + XRecibir9
            GridView1.SetRowCellValue(Renglon, "inv9", Inv9)
            GridView1.SetRowCellValue(Renglon, "invrecibo9", invRecibo9)


            '' DECIMO MES 
            Inv10 = invRecibo9 - Vta9
            Vta10 = GridView1.GetRowCellValue(Renglon, "vta10")
            XRecibir10 = GridView1.GetRowCellValue(Renglon, "xrecibir10")
            invRecibo10 = GridView1.GetRowCellValue(Renglon, "xrecibir10")
            Recibo10 = GridView1.GetRowCellValue(Renglon, "recibo10")
            invRecibo10 = Inv10 + Recibo10 + XRecibir10
            GridView1.SetRowCellValue(Renglon, "inv10", Inv10)
            GridView1.SetRowCellValue(Renglon, "invrecibo10", invRecibo10)

            '' ONCEAVO MES
            Inv11 = invRecibo10 - Vta10
            Vta11 = GridView1.GetRowCellValue(Renglon, "vta11")
            XRecibir11 = GridView1.GetRowCellValue(Renglon, "xrecibir11")
            invRecibo11 = GridView1.GetRowCellValue(Renglon, "xrecibir11")
            Recibo11 = GridView1.GetRowCellValue(Renglon, "recibo11")
            invRecibo11 = Inv11 + Recibo11 + XRecibir11
            GridView1.SetRowCellValue(Renglon, "inv11", Inv11)
            GridView1.SetRowCellValue(Renglon, "invrecibo11", invRecibo11)

            '' DOCEAVO MES
            Inv12 = invRecibo11 - Vta11
            Vta12 = GridView1.GetRowCellValue(Renglon, "vta12")
            XRecibir12 = GridView1.GetRowCellValue(Renglon, "xrecibir12")
            invRecibo12 = GridView1.GetRowCellValue(Renglon, "xrecibir12")
            Recibo12 = GridView1.GetRowCellValue(Renglon, "recibo12")
            invRecibo12 = Inv12 + Recibo12 + XRecibir12
            GridView1.SetRowCellValue(Renglon, "inv12", Inv12)
            GridView1.SetRowCellValue(Renglon, "invrecibo12", invRecibo12)


            '' traer el dato de dias de inventario que ya tiene, si es diferente a cero, no hacer nada, porque ya lo hizo.



            DiasInv1 = 0
            DiasInv2 = 0
            DiasInv3 = 0
            DiasInv4 = 0
            DiasInv5 = 0
            DiasInv6 = 0
            DiasInv7 = 0
            DiasInv8 = 0
            DiasInv9 = 0
            DiasInv10 = 0
            DiasInv11 = 0
            DiasInv12 = 0



            Call usp_TraerDiasInv(Renglon)

            If invRecibo1 < Vta1 Then


                VtaDia1 = Vta1 / DiasMes1
                If VtaDia1 = 0 Then

                    DiasInv1 = If(DiasInv1 = 0, 0, DiasInv1)
                    Call usp_GuardarDiasInv(Renglon)
                Else
                    DiasInv1 = If(DiasInv1 = 0, (invRecibo1) / VtaDia1, DiasInv1)
                    Call usp_GuardarDiasInv(Renglon)
                    If invRecibo2 < Vta2 Then
                        GoTo Dos
                    End If
                End If



            ElseIf invRecibo2 < Vta2 Then
                '' me regreso a la primera
Dos:
                Call usp_TraerDiasInv(Renglon)
                VtaDia2 = Vta2 / DiasMes2
                If VtaDia2 = 0 Then
                    DiasInv1 = If(DiasInv1 = 0, DI1, DiasInv1)
                    DiasInv2 = If(DiasInv2 = 0, DI2, DiasInv2)
                    Call usp_GuardarDiasInv(Renglon)
                Else
                    DiasInv2 = If(DiasInv2 = 0, (invRecibo2) / VtaDia2, DiasInv2)
                    DiasInv1 = If(DiasInv1 = 0, DiasMes1 + DiasInv2, DiasInv1)
                    Call usp_GuardarDiasInv(Renglon)
                    If invRecibo3 < Vta3 Then
                        GoTo Tres
                    End If
                End If

            ElseIf invRecibo3 < Vta3 Then
                '' me regreso a el contador
Tres:
                Call usp_TraerDiasInv(Renglon)
                VtaDia3 = Vta3 / DiasMes3
                If VtaDia3 = 0 Then
                    DiasInv1 = If(DiasInv1 = 0, DI1, DiasInv1)
                    DiasInv2 = If(DiasInv2 = 0, DI2, DiasInv2)
                    DiasInv3 = If(DiasInv3 = 0, DI3, DiasInv3)
                    Call usp_GuardarDiasInv(Renglon)
                Else

                    DiasInv3 = If(DiasInv3 = 0, invRecibo3 / VtaDia3, DiasInv3)
                    DiasInv2 = If(DiasInv2 = 0, DiasMes2 + DiasInv3, DiasInv2)
                    DiasInv1 = If(DiasInv1 = 0, DiasMes1 + DiasMes2 + DiasInv3, DiasInv1)
                    Call usp_GuardarDiasInv(Renglon)
                    If invRecibo4 < Vta4 Then
                        GoTo Cuatro
                    End If
                End If

            ElseIf invRecibo4 < Vta4 Then
                '' me regreso a el contador
Cuatro:
                Call usp_TraerDiasInv(Renglon)
                VtaDia4 = Vta4 / DiasMes4
                If VtaDia4 = 0 Then
                    DiasInv1 = If(DiasInv1 = 0, DI1, DiasInv1)
                    DiasInv2 = If(DiasInv2 = 0, DI2, DiasInv2)
                    DiasInv3 = If(DiasInv3 = 0, DI3, DiasInv3)
                    DiasInv4 = If(DiasInv4 = 0, DI4, DiasInv4)
                    Call usp_GuardarDiasInv(Renglon)
                Else

                    DiasInv4 = If(DiasInv4 = 0, (invRecibo4) / VtaDia4, DiasInv4)
                    DiasInv3 = If(DiasInv3 = 0, DiasMes3 + DiasInv4, DiasInv3)
                    DiasInv2 = If(DiasInv2 = 0, DiasMes2 + DiasMes3 + DiasInv4, DiasInv2)
                    DiasInv1 = If(DiasInv1 = 0, DiasMes1 + DiasMes2 + DiasMes3 + DiasInv4, DiasInv1)
                    Call usp_GuardarDiasInv(Renglon)
                    If invRecibo5 < Vta5 Then
                        GoTo Cinco
                    End If
                End If

            ElseIf invRecibo5 < Vta5 Then
                '' me regreso a el contador
Cinco:
                Call usp_TraerDiasInv(Renglon)
                VtaDia5 = Vta5 / DiasMes5
                If VtaDia5 = 0 Then
                    DiasInv1 = If(DiasInv1 = 0, DI1, DiasInv1)
                    DiasInv2 = If(DiasInv2 = 0, DI2, DiasInv2)
                    DiasInv3 = If(DiasInv3 = 0, DI3, DiasInv3)
                    DiasInv4 = If(DiasInv4 = 0, DI4, DiasInv4)
                    DiasInv5 = If(DiasInv5 = 0, DI5, DiasInv5)
                    Call usp_GuardarDiasInv(Renglon)
                Else
                    DiasInv5 = If(DiasInv5 = 0, (invRecibo5) / VtaDia5, DiasInv5)
                    DiasInv4 = If(DiasInv4 = 0, DiasMes4 + DiasInv5, DiasInv4)
                    DiasInv3 = If(DiasInv3 = 0, DiasMes3 + DiasMes4 + DiasInv5, DiasInv3)
                    DiasInv2 = If(DiasInv2 = 0, DiasMes2 + DiasMes3 + DiasMes4 + DiasInv5, DiasInv2)
                    DiasInv1 = If(DiasInv1 = 0, DiasMes1 + DiasMes2 + DiasMes3 + DiasMes4 + DiasInv5, DiasInv1)
                    Call usp_GuardarDiasInv(Renglon)
                    If invRecibo6 < Vta6 Then
                        GoTo seis
                    End If
                End If

            ElseIf invRecibo6 < Vta6 Then
                '' me regreso a el contador
Seis:
                Call usp_TraerDiasInv(Renglon)
                VtaDia6 = Vta6 / DiasMes6
                If VtaDia6 = 0 Then
                    DiasInv1 = If(DiasInv1 = 0, DI1, DiasInv1)
                    DiasInv2 = If(DiasInv2 = 0, DI2, DiasInv2)
                    DiasInv3 = If(DiasInv3 = 0, DI3, DiasInv3)
                    DiasInv4 = If(DiasInv4 = 0, DI4, DiasInv4)
                    DiasInv5 = If(DiasInv5 = 0, DI5, DiasInv5)
                    DiasInv6 = If(DiasInv6 = 0, DI6, DiasInv6)
                    Call usp_GuardarDiasInv(Renglon)
                Else
                    DiasInv6 = If(DiasInv6 = 0, (invRecibo6) / VtaDia6, DiasInv6)
                    DiasInv5 = If(DiasInv5 = 0, DiasMes5 + DiasInv6, DiasInv5)
                    DiasInv4 = If(DiasInv4 = 0, DiasMes4 + DiasMes5 + DiasInv6, DiasInv4)
                    DiasInv3 = If(DiasInv3 = 0, DiasMes3 + DiasMes4 + DiasMes5 + DiasInv6, DiasInv3)
                    DiasInv2 = If(DiasInv2 = 0, DiasMes2 + DiasMes3 + DiasMes4 + DiasMes5 + DiasInv6, DiasInv2)
                    DiasInv1 = If(DiasInv1 = 0, DiasMes1 + DiasMes2 + DiasMes3 + DiasMes4 + DiasMes5 + DiasInv6, DiasInv1)
                    Call usp_GuardarDiasInv(Renglon)
                    If invRecibo7 < Vta7 Then
                        GoTo Siete
                    End If
                End If

            ElseIf invRecibo7 < Vta7 Then
                '' me regreso a el contador
Siete:
                Call usp_TraerDiasInv(Renglon)
                VtaDia7 = Vta7 / DiasMes7
                If VtaDia7 = 0 Then
                    DiasInv1 = If(DiasInv1 = 0, DI1, DiasInv1)
                    DiasInv2 = If(DiasInv2 = 0, DI2, DiasInv2)
                    DiasInv3 = If(DiasInv3 = 0, DI3, DiasInv3)
                    DiasInv4 = If(DiasInv4 = 0, DI4, DiasInv4)
                    DiasInv5 = If(DiasInv5 = 0, DI5, DiasInv5)
                    DiasInv6 = If(DiasInv6 = 0, DI6, DiasInv6)
                    DiasInv7 = If(DiasInv7 = 0, DI7, DiasInv7)
                    Call usp_GuardarDiasInv(Renglon)
                Else
                    DiasInv7 = If(DiasInv7 = 0, (invRecibo7) / VtaDia7, DiasInv7)
                    DiasInv6 = If(DiasInv6 = 0, DiasMes6 + DiasInv7, DiasInv6)
                    DiasInv5 = If(DiasInv5 = 0, DiasMes5 + DiasMes6 + DiasInv7, DiasInv5)
                    DiasInv4 = If(DiasInv4 = 0, DiasMes4 + DiasMes5 + DiasMes6 + DiasInv7, DiasInv4)
                    DiasInv3 = If(DiasInv3 = 0, DiasMes3 + DiasMes4 + DiasMes5 + DiasMes6 + DiasInv7, DiasInv3)
                    DiasInv2 = If(DiasInv2 = 0, DiasMes2 + DiasMes3 + DiasMes4 + DiasMes5 + DiasMes6 + DiasInv7, DiasInv2)
                    DiasInv1 = If(DiasInv1 = 0, DiasMes1 + DiasMes2 + DiasMes3 + DiasMes4 + DiasMes5 + DiasMes6 + DiasInv7, DiasInv1)
                    Call usp_GuardarDiasInv(Renglon)
                    If invRecibo8 < Vta8 Then
                        GoTo Ocho
                    End If

                End If

            ElseIf invRecibo8 < Vta8 Then
                '' me regreso a el contador
Ocho:
                Call usp_TraerDiasInv(Renglon)
                VtaDia8 = Vta8 / DiasMes8
                If VtaDia8 = 0 Then
                    DiasInv1 = If(DiasInv1 = 0, DI1, DiasInv1)
                    DiasInv2 = If(DiasInv2 = 0, DI2, DiasInv2)
                    DiasInv3 = If(DiasInv3 = 0, DI3, DiasInv3)
                    DiasInv4 = If(DiasInv4 = 0, DI4, DiasInv4)
                    DiasInv5 = If(DiasInv5 = 0, DI5, DiasInv5)
                    DiasInv6 = If(DiasInv6 = 0, DI6, DiasInv6)
                    DiasInv7 = If(DiasInv7 = 0, DI7, DiasInv7)
                    DiasInv8 = If(DiasInv8 = 0, DI8, DiasInv8)
                    Call usp_GuardarDiasInv(Renglon)
                Else
                    DiasInv8 = If(DiasInv8 = 0, (invRecibo8) / VtaDia8, DiasInv8)
                    DiasInv7 = If(DiasInv7 = 0, DiasMes7 + DiasInv8, DiasInv7)
                    DiasInv6 = If(DiasInv6 = 0, DiasMes6 + DiasMes7 + DiasInv8, DiasInv6)
                    DiasInv5 = If(DiasInv5 = 0, DiasMes5 + DiasMes6 + DiasMes7 + DiasInv8, DiasInv5)
                    DiasInv4 = If(DiasInv4 = 0, DiasMes4 + DiasMes5 + DiasMes6 + DiasMes7 + DiasInv8, DiasInv4)
                    DiasInv3 = If(DiasInv3 = 0, DiasMes3 + DiasMes4 + DiasMes5 + DiasMes6 + DiasMes7 + DiasInv8, DiasInv3)
                    DiasInv2 = If(DiasInv2 = 0, DiasMes2 + DiasMes3 + DiasMes4 + DiasMes5 + DiasMes6 + DiasMes7 + DiasInv8, DiasInv2)
                    DiasInv1 = If(DiasInv1 = 0, DiasMes1 + DiasMes2 + DiasMes3 + DiasMes4 + DiasMes5 + DiasMes6 + DiasMes7 + DiasInv8, DiasInv1)
                    Call usp_GuardarDiasInv(Renglon)
                    If invRecibo9 < Vta9 Then
                        GoTo Nueve
                    End If
                End If

            ElseIf invRecibo9 < Vta9 Then
                '' me regreso a el contador
Nueve:
                Call usp_TraerDiasInv(Renglon)
                VtaDia9 = Vta9 / DiasMes9
                If VtaDia9 = 0 Then
                    DiasInv1 = If(DiasInv1 = 0, DI1, DiasInv1)
                    DiasInv2 = If(DiasInv2 = 0, DI2, DiasInv2)
                    DiasInv3 = If(DiasInv3 = 0, DI3, DiasInv3)
                    DiasInv4 = If(DiasInv4 = 0, DI4, DiasInv4)
                    DiasInv5 = If(DiasInv5 = 0, DI5, DiasInv5)
                    DiasInv6 = If(DiasInv6 = 0, DI6, DiasInv6)
                    DiasInv7 = If(DiasInv7 = 0, DI7, DiasInv7)
                    DiasInv8 = If(DiasInv8 = 0, DI8, DiasInv8)
                    DiasInv9 = If(DiasInv9 = 0, DI9, DiasInv9)
                    Call usp_GuardarDiasInv(Renglon)
                Else
                    DiasInv9 = If(DiasInv9 = 0, invRecibo9 / VtaDia9, DiasInv9)
                    DiasInv8 = If(DiasInv8 = 0, DiasMes8 + DiasInv9, DiasInv8)
                    DiasInv7 = If(DiasInv7 = 0, DiasMes7 + DiasMes8 + DiasInv9, DiasInv7)
                    DiasInv6 = If(DiasInv6 = 0, DiasMes6 + DiasMes7 + DiasMes8 + DiasInv9, DiasInv6)
                    DiasInv5 = If(DiasInv5 = 0, DiasMes5 + DiasMes6 + DiasMes7 + DiasMes8 + DiasInv9, DiasInv5)
                    DiasInv4 = If(DiasInv4 = 0, DiasMes4 + DiasMes5 + DiasMes6 + DiasMes7 + DiasMes8 + DiasInv9, DiasInv4)
                    DiasInv3 = If(DiasInv3 = 0, DiasMes3 + DiasMes4 + DiasMes5 + DiasMes6 + DiasMes7 + DiasMes8 + DiasInv9, DiasInv3)
                    DiasInv2 = If(DiasInv2 = 0, DiasMes2 + DiasMes3 + DiasMes4 + DiasMes5 + DiasMes6 + DiasMes7 + DiasMes8 + DiasInv9, DiasInv2)
                    DiasInv1 = If(DiasInv1 = 0, DiasMes1 + DiasMes2 + DiasMes3 + DiasMes4 + DiasMes5 + DiasMes6 + DiasMes7 + DiasMes8 + DiasInv9, DiasInv1)
                    Call usp_GuardarDiasInv(Renglon)
                    If invRecibo10 < Vta10 Then
                        GoTo Diez
                    End If
                End If

            ElseIf invRecibo10 < Vta10 Then
                '' me regreso a el contador
Diez:
                Call usp_TraerDiasInv(Renglon)
                VtaDia10 = Vta10 / DiasMes10
                If VtaDia10 = 0 Then
                    DiasInv1 = If(DiasInv1 = 0, DI1, DiasInv1)
                    DiasInv2 = If(DiasInv2 = 0, DI2, DiasInv2)
                    DiasInv3 = If(DiasInv3 = 0, DI3, DiasInv3)
                    DiasInv4 = If(DiasInv4 = 0, DI4, DiasInv4)
                    DiasInv5 = If(DiasInv5 = 0, DI5, DiasInv5)
                    DiasInv6 = If(DiasInv6 = 0, DI6, DiasInv6)
                    DiasInv7 = If(DiasInv7 = 0, DI7, DiasInv7)
                    DiasInv8 = If(DiasInv8 = 0, DI8, DiasInv8)
                    DiasInv9 = If(DiasInv9 = 0, DI9, DiasInv9)
                    DiasInv10 = If(DiasInv10 = 0, DI10, DiasInv10)
                    Call usp_GuardarDiasInv(Renglon)
                Else
                    DiasInv10 = If(DiasInv10 = 0, (invRecibo10) / VtaDia10, DiasInv10)
                    DiasInv9 = If(DiasInv9 = 0, DiasMes9 + DiasInv10, DiasInv9)
                    DiasInv8 = If(DiasInv8 = 0, DiasMes8 + DiasMes9 + DiasInv10, DiasInv8)
                    DiasInv7 = If(DiasInv7 = 0, DiasMes7 + DiasMes8 + DiasMes9 + DiasInv10, DiasInv7)
                    DiasInv6 = If(DiasInv6 = 0, DiasMes6 + DiasMes7 + DiasMes8 + DiasMes9 + DiasInv10, DiasInv6)
                    DiasInv5 = If(DiasInv5 = 0, DiasMes5 + DiasMes6 + DiasMes7 + DiasMes8 + DiasMes9 + DiasInv10, DiasInv5)
                    DiasInv4 = If(DiasInv4 = 0, DiasMes4 + DiasMes5 + DiasMes6 + DiasMes7 + DiasMes8 + DiasMes9 + DiasInv10, DiasInv4)
                    DiasInv3 = If(DiasInv3 = 0, DiasMes3 + DiasMes4 + DiasMes5 + DiasMes6 + DiasMes7 + DiasMes8 + DiasMes9 + DiasInv10, DiasInv3)
                    DiasInv2 = If(DiasInv2 = 0, DiasMes2 + DiasMes3 + DiasMes4 + DiasMes5 + DiasMes6 + DiasMes7 + DiasMes8 + DiasMes9 + DiasInv10, DiasInv2)
                    DiasInv1 = If(DiasInv1 = 0, DiasMes1 + DiasMes2 + DiasMes3 + DiasMes4 + DiasMes5 + DiasMes6 + DiasMes7 + DiasMes8 + DiasMes9 + DiasInv10, DiasInv1)
                    Call usp_GuardarDiasInv(Renglon)
                    If invRecibo11 < Vta11 Then
                        GoTo Once
                    End If
                End If

            ElseIf invRecibo11 < Vta11 Then
                '' me regreso a el contador
Once:
                Call usp_TraerDiasInv(Renglon)
                VtaDia11 = Vta11 / DiasMes11
                If VtaDia11 = 0 Then
                    DiasInv1 = If(DiasInv1 = 0, DI1, DiasInv1)
                    DiasInv2 = If(DiasInv2 = 0, DI2, DiasInv2)
                    DiasInv3 = If(DiasInv3 = 0, DI3, DiasInv3)
                    DiasInv4 = If(DiasInv4 = 0, DI4, DiasInv4)
                    DiasInv5 = If(DiasInv5 = 0, DI5, DiasInv5)
                    DiasInv6 = If(DiasInv6 = 0, DI6, DiasInv6)
                    DiasInv7 = If(DiasInv7 = 0, DI7, DiasInv7)
                    DiasInv8 = If(DiasInv8 = 0, DI8, DiasInv8)
                    DiasInv9 = If(DiasInv9 = 0, DI9, DiasInv9)
                    DiasInv10 = If(DiasInv10 = 0, DI10, DiasInv10)
                    DiasInv11 = If(DiasInv11 = 0, DI11, DiasInv11)
                    Call usp_GuardarDiasInv(Renglon)
                Else
                    DiasInv11 = If(DiasInv11 = 0, (invRecibo11) / VtaDia11, DiasInv11)
                    DiasInv10 = If(DiasInv10 = 0, DiasMes10 + DiasInv11, DiasInv10)
                    DiasInv9 = If(DiasInv9 = 0, DiasMes9 + DiasMes10 + DiasInv11, DiasInv9)
                    DiasInv8 = If(DiasInv8 = 0, DiasMes8 + DiasMes9 + DiasMes10 + DiasInv11, DiasInv8)
                    DiasInv7 = If(DiasInv7 = 0, DiasMes7 + DiasMes8 + DiasMes9 + DiasMes10 + DiasInv11, DiasInv7)
                    DiasInv6 = If(DiasInv6 = 0, DiasMes6 + DiasMes7 + DiasMes8 + DiasMes9 + DiasMes10 + DiasInv11, DiasInv6)
                    DiasInv5 = If(DiasInv5 = 0, DiasMes5 + DiasMes6 + DiasMes7 + DiasMes8 + DiasMes9 + DiasMes10 + DiasInv11, DiasInv5)
                    DiasInv4 = If(DiasInv4 = 0, DiasMes4 + DiasMes5 + DiasMes6 + DiasMes7 + DiasMes8 + DiasMes9 + DiasMes10 + DiasInv11, DiasInv4)
                    DiasInv3 = If(DiasInv3 = 0, DiasMes3 + DiasMes4 + DiasMes5 + DiasMes6 + DiasMes7 + DiasMes8 + DiasMes9 + DiasMes10 + DiasInv11, DiasInv3)
                    DiasInv2 = If(DiasInv2 = 0, DiasMes2 + DiasMes3 + DiasMes4 + DiasMes5 + DiasMes6 + DiasMes7 + DiasMes8 + DiasMes9 + DiasMes10 + DiasInv11, DiasInv2)
                    DiasInv1 = If(DiasInv1 = 0, DiasMes1 + DiasMes2 + DiasMes3 + DiasMes4 + DiasMes5 + DiasMes6 + DiasMes7 + DiasMes8 + DiasMes9 + DiasMes10 + DiasInv11, DiasInv1)
                    Call usp_GuardarDiasInv(Renglon)
                    If invRecibo12 < Vta12 Then
                        GoTo Doce
                    End If
                End If

            ElseIf invRecibo12 < Vta12 Then
                '' me regreso a el contador
Doce:
                Call usp_TraerDiasInv(Renglon)
                VtaDia12 = Vta12 / DiasMes12
                If VtaDia12 = 0 Then
                    DiasInv1 = If(DiasInv1 = 0, DI1, DiasInv1)
                    DiasInv2 = If(DiasInv2 = 0, DI2, DiasInv2)
                    DiasInv3 = If(DiasInv3 = 0, DI3, DiasInv3)
                    DiasInv4 = If(DiasInv4 = 0, DI4, DiasInv4)
                    DiasInv5 = If(DiasInv5 = 0, DI5, DiasInv5)
                    DiasInv6 = If(DiasInv6 = 0, DI6, DiasInv6)
                    DiasInv7 = If(DiasInv7 = 0, DI7, DiasInv7)
                    DiasInv8 = If(DiasInv8 = 0, DI8, DiasInv8)
                    DiasInv9 = If(DiasInv9 = 0, DI9, DiasInv9)
                    DiasInv10 = If(DiasInv10 = 0, DI10, DiasInv10)
                    DiasInv11 = If(DiasInv11 = 0, DI11, DiasInv11)
                    DiasInv12 = If(DiasInv12 = 0, DI12, DiasInv12)
                    Call usp_GuardarDiasInv(Renglon)
                Else
                    DiasInv12 = If(DiasInv12 = 0, (invRecibo12) / VtaDia12, DiasInv12)
                    DiasInv11 = If(DiasInv11 = 0, DiasMes11 + DiasInv12, DiasInv11)
                    DiasInv10 = If(DiasInv10 = 0, DiasMes10 + DiasMes11 + DiasInv12, DiasInv10)
                    DiasInv9 = If(DiasInv9 = 0, DiasMes9 + DiasMes10 + DiasMes11 + DiasInv12, DiasInv9)
                    DiasInv8 = If(DiasInv8 = 0, DiasMes8 + DiasMes9 + DiasMes10 + DiasMes11 + DiasInv12, DiasInv8)
                    DiasInv7 = If(DiasInv7 = 0, DiasMes7 + DiasMes8 + DiasMes9 + DiasMes10 + DiasMes11 + DiasInv12, DiasInv7)
                    DiasInv6 = If(DiasInv6 = 0, DiasMes6 + DiasMes7 + DiasMes8 + DiasMes9 + DiasMes10 + DiasMes11 + DiasInv12, DiasInv6)
                    DiasInv5 = If(DiasInv5 = 0, DiasMes5 + DiasMes6 + DiasMes7 + DiasMes8 + DiasMes9 + DiasMes10 + DiasMes11 + DiasInv12, DiasInv5)
                    DiasInv4 = If(DiasInv4 = 0, DiasMes4 + DiasMes5 + DiasMes6 + DiasMes7 + DiasMes8 + DiasMes9 + DiasMes10 + DiasMes11 + DiasInv12, DiasInv4)
                    DiasInv3 = If(DiasInv3 = 0, DiasMes3 + DiasMes4 + DiasMes5 + DiasMes6 + DiasMes7 + DiasMes8 + DiasMes9 + DiasMes10 + DiasMes11 + DiasInv12, DiasInv3)
                    DiasInv2 = If(DiasInv2 = 0, DiasMes2 + DiasMes3 + DiasMes4 + DiasMes5 + DiasMes6 + DiasMes7 + DiasMes8 + DiasMes9 + DiasMes10 + DiasMes11 + DiasInv12, DiasInv2)
                    DiasInv1 = If(DiasInv1 = 0, DiasMes1 + DiasMes2 + DiasMes3 + DiasMes4 + DiasMes5 + DiasMes6 + DiasMes7 + DiasMes8 + DiasMes9 + DiasMes10 + DiasMes11 + DiasInv12, DiasInv1)
                    Call usp_GuardarDiasInv(Renglon)
                End If

            Else
                Call usp_TraerDiasInv(Renglon)
                VtaDia12 = Vta12 / DiasMes12
                If VtaDia12 = 0 Then
                    DiasInv1 = DiasMes1 + DiasMes2 + DiasMes3 + DiasMes4 + DiasMes5 + DiasMes6 + DiasMes7 + DiasMes8 + DiasMes9 + DiasMes10 + DiasMes11 + DiasMes12
                    DiasInv2 = DiasMes2 + DiasMes3 + DiasMes4 + DiasMes5 + DiasMes6 + DiasMes7 + DiasMes8 + DiasMes9 + DiasMes10 + DiasMes11 + DiasMes12
                    DiasInv3 = DiasMes3 + DiasMes4 + DiasMes5 + DiasMes6 + DiasMes7 + DiasMes8 + DiasMes9 + DiasMes10 + DiasMes11 + DiasMes12
                    DiasInv4 = DiasMes4 + DiasMes5 + DiasMes6 + DiasMes7 + DiasMes8 + DiasMes9 + DiasMes10 + DiasMes11 + DiasMes12
                    DiasInv5 = DiasMes5 + DiasMes6 + DiasMes7 + DiasMes8 + DiasMes9 + DiasMes10 + DiasMes11 + DiasMes12
                    DiasInv6 = DiasMes6 + DiasMes7 + DiasMes8 + DiasMes9 + DiasMes10 + DiasMes11 + DiasMes12
                    DiasInv7 = DiasMes7 + DiasMes8 + DiasMes9 + DiasMes10 + DiasMes11 + DiasMes12
                    DiasInv8 = DiasMes8 + DiasMes9 + DiasMes10 + DiasMes11 + DiasMes12
                    DiasInv9 = DiasMes9 + DiasMes10 + DiasMes11 + DiasMes12
                    DiasInv10 = DiasMes10 + DiasMes11 + DiasMes12
                    DiasInv11 = DiasMes11 + DiasMes12
                    DiasInv12 = DiasMes12
                    Call usp_GuardarDiasInv(Renglon)
                Else
                    DiasInv12 = If(DiasInv12 = 0, (invRecibo12) / VtaDia12, DiasInv12)
                    DiasInv11 = If(DiasInv11 = 0, DiasMes11 + DiasInv12, DiasInv11)
                    DiasInv10 = If(DiasInv10 = 0, DiasMes10 + DiasMes11 + DiasInv12, DiasInv10)
                    DiasInv9 = If(DiasInv9 = 0, DiasMes9 + DiasMes10 + DiasMes11 + DiasInv12, DiasInv9)
                    DiasInv8 = If(DiasInv8 = 0, DiasMes8 + DiasMes9 + DiasMes10 + DiasMes11 + DiasInv12, DiasInv8)
                    DiasInv7 = If(DiasInv7 = 0, DiasMes7 + DiasMes8 + DiasMes9 + DiasMes10 + DiasMes11 + DiasInv12, DiasInv7)
                    DiasInv6 = If(DiasInv6 = 0, DiasMes6 + DiasMes7 + DiasMes8 + DiasMes9 + DiasMes10 + DiasMes11 + DiasInv12, DiasInv6)
                    DiasInv5 = If(DiasInv5 = 0, DiasMes5 + DiasMes6 + DiasMes7 + DiasMes8 + DiasMes9 + DiasMes10 + DiasMes11 + DiasInv12, DiasInv5)
                    DiasInv4 = If(DiasInv4 = 0, DiasMes4 + DiasMes5 + DiasMes6 + DiasMes7 + DiasMes8 + DiasMes9 + DiasMes10 + DiasMes11 + DiasInv12, DiasInv4)
                    DiasInv3 = If(DiasInv3 = 0, DiasMes3 + DiasMes4 + DiasMes5 + DiasMes6 + DiasMes7 + DiasMes8 + DiasMes9 + DiasMes10 + DiasMes11 + DiasInv12, DiasInv3)
                    DiasInv2 = If(DiasInv2 = 0, DiasMes2 + DiasMes3 + DiasMes4 + DiasMes5 + DiasMes6 + DiasMes7 + DiasMes8 + DiasMes9 + DiasMes10 + DiasMes11 + DiasInv12, DiasInv2)
                    DiasInv1 = If(DiasInv1 = 0, DiasMes1 + DiasMes2 + DiasMes3 + DiasMes4 + DiasMes5 + DiasMes6 + DiasMes7 + DiasMes8 + DiasMes9 + DiasMes10 + DiasMes11 + DiasInv12, DiasInv1)
                    Call usp_GuardarDiasInv(Renglon)
                End If
                Call usp_GuardarDiasInv(Renglon)
            End If

            'Call usp_GuardarDiasInv(Renglon)
            '   DGrid1.Visible = True

            Sw_Entro = False
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub usp_GuardarDiasInv(Renglon As Integer)
        GridView1.SetRowCellValue(Renglon, "diasinv1", DiasInv1)
        GridView1.SetRowCellValue(Renglon, "diasinv2", DiasInv2)
        GridView1.SetRowCellValue(Renglon, "diasinv3", DiasInv3)
        GridView1.SetRowCellValue(Renglon, "diasinv4", DiasInv4)
        GridView1.SetRowCellValue(Renglon, "diasinv5", DiasInv5)
        GridView1.SetRowCellValue(Renglon, "diasinv6", DiasInv6)
        GridView1.SetRowCellValue(Renglon, "diasinv7", DiasInv7)
        GridView1.SetRowCellValue(Renglon, "diasinv8", DiasInv8)
        GridView1.SetRowCellValue(Renglon, "diasinv9", DiasInv9)
        GridView1.SetRowCellValue(Renglon, "diasinv10", DiasInv10)
        GridView1.SetRowCellValue(Renglon, "diasinv11", DiasInv11)
        GridView1.SetRowCellValue(Renglon, "diasinv12", DiasInv12)
    End Sub
    Private Sub usp_TraerDiasInv(Renglon As Integer)
        'DI1 = GridView1.GetRowCellValue(Renglon, "diasinv1")
        'DI2 = GridView1.GetRowCellValue(Renglon, "diasinv2")
        'DI3 = GridView1.GetRowCellValue(Renglon, "diasinv3")
        'DI4 = GridView1.GetRowCellValue(Renglon, "diasinv4")
        'DI5 = GridView1.GetRowCellValue(Renglon, "diasinv5")
        'DI6 = GridView1.GetRowCellValue(Renglon, "diasinv6")
        'DI7 = GridView1.GetRowCellValue(Renglon, "diasinv7")
        'DI8 = GridView1.GetRowCellValue(Renglon, "diasinv8")
        'DI9 = GridView1.GetRowCellValue(Renglon, "diasinv9")
        'DI10 = GridView1.GetRowCellValue(Renglon, "diasinv10")
        'DI11 = GridView1.GetRowCellValue(Renglon, "diasinv11")
        'DI12 = GridView1.GetRowCellValue(Renglon, "diasinv12")
        DI1 = DiasMes1
        DI2 = DiasMes2
        DI3 = DiasMes3
        DI4 = DiasMes4
        DI5 = DiasMes5
        DI6 = DiasMes6
        DI7 = DiasMes7
        DI8 = DiasMes8
        DI9 = DiasMes9
        DI10 = DiasMes10
        DI11 = DiasMes11
        DI12 = DiasMes12


    End Sub
    Private Sub usp_Totales(renglon As Integer)
        'mreyes 28/Agosto/2017  11:47 a.m.
        Try
            Dim Desde As Integer = 0
            Dim Hasta As Integer = 0
            Dim I As Integer = 0

            Dim RenTotal As Integer = 0
            Dim Tinv1 As Integer = 0
            Dim TVta1 As Integer = 0
            Dim TXRecibir1 As Integer = 0
            Dim TinvRecibo1 As Integer = 0
            Dim TRecibo1 As Integer = 0

            Dim Tinv2 As Integer = 0
            Dim TVta2 As Integer = 0
            Dim TXRecibir2 As Integer = 0
            Dim TinvRecibo2 As Integer = 0
            Dim TRecibo2 As Integer = 0

            Dim Tinv3 As Integer = 0
            Dim TVta3 As Integer = 0
            Dim TXRecibir3 As Integer = 0
            Dim TinvRecibo3 As Integer = 0
            Dim TRecibo3 As Integer = 0

            Dim Tinv4 As Integer = 0
            Dim TVta4 As Integer = 0
            Dim TXRecibir4 As Integer = 0
            Dim TinvRecibo4 As Integer = 0
            Dim TRecibo4 As Integer = 0

            Dim Tinv5 As Integer = 0
            Dim TVta5 As Integer = 0
            Dim TXRecibir5 As Integer = 0
            Dim TinvRecibo5 As Integer = 0
            Dim TRecibo5 As Integer = 0

            Dim Tinv6 As Integer = 0
            Dim TVta6 As Integer = 0
            Dim TXRecibir6 As Integer = 0
            Dim TinvRecibo6 As Integer = 0
            Dim TRecibo6 As Integer = 0

            Dim Tinv7 As Integer = 0
            Dim TVta7 As Integer = 0
            Dim TXRecibir7 As Integer = 0
            Dim TinvRecibo7 As Integer = 0
            Dim TRecibo7 As Integer = 0

            Dim Tinv8 As Integer = 0
            Dim TVta8 As Integer = 0
            Dim TXRecibir8 As Integer = 0
            Dim TinvRecibo8 As Integer = 0
            Dim TRecibo8 As Integer = 0

            Dim Tinv9 As Integer = 0
            Dim TVta9 As Integer = 0
            Dim TXRecibir9 As Integer = 0
            Dim TinvRecibo9 As Integer = 0
            Dim TRecibo9 As Integer = 0

            Dim Tinv10 As Integer = 0
            Dim TVta10 As Integer = 0
            Dim TXRecibir10 As Integer = 0
            Dim TinvRecibo10 As Integer = 0
            Dim TRecibo10 As Integer = 0

            Dim Tinv11 As Integer = 0
            Dim TVta11 As Integer = 0
            Dim TXRecibir11 As Integer = 0
            Dim TinvRecibo11 As Integer = 0
            Dim TRecibo11 As Integer = 0

            Dim Tinv12 As Integer = 0
            Dim TVta12 As Integer = 0
            Dim TXRecibir12 As Integer = 0
            Dim TinvRecibo12 As Integer = 0
            Dim TRecibo12 As Integer = 0

            Sw_Entro = True

            If renglon > 1 And renglon <= 6 Then
                RenTotal = 1
                Desde = 2
                Hasta = 6
            End If

            If renglon > 7 And renglon <= 11 Then
                RenTotal = 7
                Desde = 8
                Hasta = 11
            End If
            If renglon > 12 And renglon <= 20 Then
                RenTotal = 12
                Desde = 13
                Hasta = 20
            End If

            If renglon > 21 And renglon <= 30 Then
                RenTotal = 21
                Desde = 22
                Hasta = 30
            End If

            If renglon > 31 And renglon <= 41 Then
                RenTotal = 31
                Desde = 32
                Hasta = 41
            End If

            If renglon > 42 And renglon <= 48 Then
                RenTotal = 42
                Desde = 43
                Hasta = 48
            End If




            For I = Desde To Hasta

                Tinv1 = Tinv1 + GridView1.GetRowCellValue(I, "inv1")
                TVta1 = TVta1 + GridView1.GetRowCellValue(I, "vta1")
                TXRecibir1 = TXRecibir1 + GridView1.GetRowCellValue(I, "xrecibir1")
                TRecibo1 = TRecibo1 + GridView1.GetRowCellValue(I, "recibo1")

                Tinv2 = Tinv2 + GridView1.GetRowCellValue(I, "inv2")
                TVta2 = TVta2 + GridView1.GetRowCellValue(I, "vta2")
                TXRecibir2 = TXRecibir2 + GridView1.GetRowCellValue(I, "xrecibir2")
                TRecibo2 = TRecibo2 + GridView1.GetRowCellValue(I, "recibo2")

                Tinv3 = Tinv3 + GridView1.GetRowCellValue(I, "inv3")
                TVta3 = TVta3 + GridView1.GetRowCellValue(I, "vta3")
                TXRecibir3 = TXRecibir3 + GridView1.GetRowCellValue(I, "xrecibir3")
                TRecibo3 = TRecibo3 + GridView1.GetRowCellValue(I, "recibo3")

                Tinv4 = Tinv4 + GridView1.GetRowCellValue(I, "inv4")
                TVta4 = TVta4 + GridView1.GetRowCellValue(I, "vta4")
                TXRecibir4 = TXRecibir4 + GridView1.GetRowCellValue(I, "xrecibir4")
                TRecibo4 = TRecibo4 + GridView1.GetRowCellValue(I, "recibo4")

                Tinv5 = Tinv5 + GridView1.GetRowCellValue(I, "inv5")
                TVta5 = TVta5 + GridView1.GetRowCellValue(I, "vta5")
                TXRecibir5 = TXRecibir5 + GridView1.GetRowCellValue(I, "xrecibir5")
                TRecibo5 = TRecibo5 + GridView1.GetRowCellValue(I, "recibo5")

                Tinv6 = Tinv6 + GridView1.GetRowCellValue(I, "inv6")
                TVta6 = TVta6 + GridView1.GetRowCellValue(I, "vta6")
                TXRecibir6 = TXRecibir6 + GridView1.GetRowCellValue(I, "xrecibir6")
                TRecibo6 = TRecibo6 + GridView1.GetRowCellValue(I, "recibo6")

                Tinv7 = Tinv7 + GridView1.GetRowCellValue(I, "inv7")
                TVta7 = TVta7 + GridView1.GetRowCellValue(I, "vta7")
                TXRecibir7 = TXRecibir7 + GridView1.GetRowCellValue(I, "xrecibir7")
                TRecibo7 = TRecibo7 + GridView1.GetRowCellValue(I, "recibo7")

                Tinv8 = Tinv8 + GridView1.GetRowCellValue(I, "inv8")
                TVta8 = TVta8 + GridView1.GetRowCellValue(I, "vta8")
                TXRecibir8 = TXRecibir8 + GridView1.GetRowCellValue(I, "xrecibir8")
                TRecibo8 = TRecibo8 + GridView1.GetRowCellValue(I, "recibo8")

                Tinv9 = Tinv9 + GridView1.GetRowCellValue(I, "inv9")
                TVta9 = TVta9 + GridView1.GetRowCellValue(I, "vta9")
                TXRecibir9 = TXRecibir9 + GridView1.GetRowCellValue(I, "xrecibir9")
                TRecibo9 = TRecibo9 + GridView1.GetRowCellValue(I, "recibo9")

                Tinv10 = Tinv10 + GridView1.GetRowCellValue(I, "inv10")
                TVta10 = TVta10 + GridView1.GetRowCellValue(I, "vta10")
                TXRecibir10 = TXRecibir10 + GridView1.GetRowCellValue(I, "xrecibir10")
                TRecibo10 = TRecibo10 + GridView1.GetRowCellValue(I, "recibo10")

                Tinv11 = Tinv11 + GridView1.GetRowCellValue(I, "inv11")
                TVta11 = TVta11 + GridView1.GetRowCellValue(I, "vta11")
                TXRecibir11 = TXRecibir11 + GridView1.GetRowCellValue(I, "xrecibir11")
                TRecibo11 = TRecibo11 + GridView1.GetRowCellValue(I, "recibo11")

                Tinv12 = Tinv12 + GridView1.GetRowCellValue(I, "inv12")
                TVta12 = TVta12 + GridView1.GetRowCellValue(I, "vta12")
                TXRecibir12 = TXRecibir12 + GridView1.GetRowCellValue(I, "xrecibir12")
                TRecibo12 = TRecibo12 + GridView1.GetRowCellValue(I, "recibo12")

            Next

            TinvRecibo1 = Tinv1 + TRecibo1 + TXRecibir1
            TinvRecibo2 = Tinv2 + TRecibo2 + TXRecibir2
            TinvRecibo3 = Tinv3 + TRecibo3 + TXRecibir3
            TinvRecibo4 = Tinv4 + TRecibo4 + TXRecibir4
            TinvRecibo5 = Tinv5 + TRecibo5 + TXRecibir5
            TinvRecibo6 = Tinv6 + TRecibo6 + TXRecibir6
            TinvRecibo7 = Tinv7 + TRecibo7 + TXRecibir7
            TinvRecibo8 = Tinv8 + TRecibo8 + TXRecibir8
            TinvRecibo9 = Tinv9 + TRecibo9 + TXRecibir9
            TinvRecibo10 = Tinv10 + TRecibo10 + TXRecibir10
            TinvRecibo11 = Tinv11 + TRecibo11 + TXRecibir11
            TinvRecibo12 = Tinv12 + TRecibo12 + TXRecibir12

            GridView1.SetRowCellValue(RenTotal, "inv1", Tinv1)
            GridView1.SetRowCellValue(RenTotal, "vta1", TVta1)
            GridView1.SetRowCellValue(RenTotal, "xecibir1", TXRecibir1)
            GridView1.SetRowCellValue(RenTotal, "invrecibo1", TinvRecibo1)
            GridView1.SetRowCellValue(RenTotal, "recibo1", TRecibo1)
            '' SUMAR EL CERO.
            GridView1.SetRowCellValue(RenTotal, "inv2", Tinv2)
            GridView1.SetRowCellValue(RenTotal, "vta2", TVta2)
            GridView1.SetRowCellValue(RenTotal, "xecibir2", TXRecibir2)
            GridView1.SetRowCellValue(RenTotal, "invrecibo2", TinvRecibo2)
            GridView1.SetRowCellValue(RenTotal, "recibo2", TRecibo2)

            GridView1.SetRowCellValue(RenTotal, "inv3", Tinv3)
            GridView1.SetRowCellValue(RenTotal, "vta3", TVta3)
            GridView1.SetRowCellValue(RenTotal, "xecibir3", TXRecibir3)
            GridView1.SetRowCellValue(RenTotal, "invrecibo3", TinvRecibo3)
            GridView1.SetRowCellValue(RenTotal, "recibo3", TRecibo3)

            GridView1.SetRowCellValue(RenTotal, "inv4", Tinv4)
            GridView1.SetRowCellValue(RenTotal, "vta4", TVta4)
            GridView1.SetRowCellValue(RenTotal, "xecibir4", TXRecibir4)
            GridView1.SetRowCellValue(RenTotal, "invrecibo4", TinvRecibo4)
            GridView1.SetRowCellValue(RenTotal, "recibo4", TRecibo4)

            GridView1.SetRowCellValue(RenTotal, "inv5", Tinv5)
            GridView1.SetRowCellValue(RenTotal, "vta5", TVta5)
            GridView1.SetRowCellValue(RenTotal, "xecibir5", TXRecibir5)
            GridView1.SetRowCellValue(RenTotal, "invrecibo5", TinvRecibo5)
            GridView1.SetRowCellValue(RenTotal, "recibo5", TRecibo5)

            GridView1.SetRowCellValue(RenTotal, "inv6", Tinv6)
            GridView1.SetRowCellValue(RenTotal, "vta6", TVta6)
            GridView1.SetRowCellValue(RenTotal, "xecibir6", TXRecibir6)
            GridView1.SetRowCellValue(RenTotal, "invrecibo6", TinvRecibo6)
            GridView1.SetRowCellValue(RenTotal, "recibo6", TRecibo6)

            GridView1.SetRowCellValue(RenTotal, "inv7", Tinv7)
            GridView1.SetRowCellValue(RenTotal, "vta7", TVta7)
            GridView1.SetRowCellValue(RenTotal, "xecibir7", TXRecibir7)
            GridView1.SetRowCellValue(RenTotal, "invrecibo7", TinvRecibo7)
            GridView1.SetRowCellValue(RenTotal, "recibo7", TRecibo7)

            GridView1.SetRowCellValue(RenTotal, "inv8", Tinv8)
            GridView1.SetRowCellValue(RenTotal, "vta8", TVta8)
            GridView1.SetRowCellValue(RenTotal, "xecibir8", TXRecibir8)
            GridView1.SetRowCellValue(RenTotal, "invrecibo8", TinvRecibo8)
            GridView1.SetRowCellValue(RenTotal, "recibo8", TRecibo8)

            GridView1.SetRowCellValue(RenTotal, "inv9", Tinv9)
            GridView1.SetRowCellValue(RenTotal, "vta9", TVta9)
            GridView1.SetRowCellValue(RenTotal, "xecibir9", TXRecibir9)
            GridView1.SetRowCellValue(RenTotal, "invrecibo9", TinvRecibo9)
            GridView1.SetRowCellValue(RenTotal, "recibo9", TRecibo9)

            GridView1.SetRowCellValue(RenTotal, "inv10", Tinv10)
            GridView1.SetRowCellValue(RenTotal, "vta10", TVta10)
            GridView1.SetRowCellValue(RenTotal, "xecibir10", TXRecibir10)
            GridView1.SetRowCellValue(RenTotal, "invrecibo10", TinvRecibo10)
            GridView1.SetRowCellValue(RenTotal, "recibo10", TRecibo10)

            GridView1.SetRowCellValue(RenTotal, "inv11", Tinv11)
            GridView1.SetRowCellValue(RenTotal, "vta11", TVta11)
            GridView1.SetRowCellValue(RenTotal, "xecibir11", TXRecibir11)
            GridView1.SetRowCellValue(RenTotal, "invrecibo11", TinvRecibo11)
            GridView1.SetRowCellValue(RenTotal, "recibo11", TRecibo11)

            GridView1.SetRowCellValue(RenTotal, "inv12", Tinv12)
            GridView1.SetRowCellValue(RenTotal, "vta12", TVta12)
            GridView1.SetRowCellValue(RenTotal, "xecibir12", TXRecibir12)
            GridView1.SetRowCellValue(RenTotal, "invrecibo12", TinvRecibo12)
            GridView1.SetRowCellValue(RenTotal, "recibo12", TRecibo12)



            'Call CalcularColumnas(RenTotal)
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub



    Private Sub usp_TotalesGran()
        'mreyes 28/Agosto/2017  04:13 p.m.
        Try
            Dim Renglon As Integer = 0
            Dim Desde As Integer = 0
            Dim Hasta As Integer = 0
            Dim I As Integer = 0

            Dim RenTotal As Integer = 0
            Dim Tinv1 As Integer = 0
            Dim TVta1 As Integer = 0
            Dim TXRecibir1 As Integer = 0
            Dim TinvRecibo1 As Integer = 0
            Dim TRecibo1 As Integer = 0

            Dim Tinv2 As Integer = 0
            Dim TVta2 As Integer = 0
            Dim TXRecibir2 As Integer = 0
            Dim TinvRecibo2 As Integer = 0
            Dim TRecibo2 As Integer = 0

            Dim Tinv3 As Integer = 0
            Dim TVta3 As Integer = 0
            Dim TXRecibir3 As Integer = 0
            Dim TinvRecibo3 As Integer = 0
            Dim TRecibo3 As Integer = 0

            Dim Tinv4 As Integer = 0
            Dim TVta4 As Integer = 0
            Dim TXRecibir4 As Integer = 0
            Dim TinvRecibo4 As Integer = 0
            Dim TRecibo4 As Integer = 0

            Dim Tinv5 As Integer = 0
            Dim TVta5 As Integer = 0
            Dim TXRecibir5 As Integer = 0
            Dim TinvRecibo5 As Integer = 0
            Dim TRecibo5 As Integer = 0

            Dim Tinv6 As Integer = 0
            Dim TVta6 As Integer = 0
            Dim TXRecibir6 As Integer = 0
            Dim TinvRecibo6 As Integer = 0
            Dim TRecibo6 As Integer = 0

            Dim Tinv7 As Integer = 0
            Dim TVta7 As Integer = 0
            Dim TXRecibir7 As Integer = 0
            Dim TinvRecibo7 As Integer = 0
            Dim TRecibo7 As Integer = 0

            Dim Tinv8 As Integer = 0
            Dim TVta8 As Integer = 0
            Dim TXRecibir8 As Integer = 0
            Dim TinvRecibo8 As Integer = 0
            Dim TRecibo8 As Integer = 0

            Dim Tinv9 As Integer = 0
            Dim TVta9 As Integer = 0
            Dim TXRecibir9 As Integer = 0
            Dim TinvRecibo9 As Integer = 0
            Dim TRecibo9 As Integer = 0

            Dim Tinv10 As Integer = 0
            Dim TVta10 As Integer = 0
            Dim TXRecibir10 As Integer = 0
            Dim TinvRecibo10 As Integer = 0
            Dim TRecibo10 As Integer = 0

            Dim Tinv11 As Integer = 0
            Dim TVta11 As Integer = 0
            Dim TXRecibir11 As Integer = 0
            Dim TinvRecibo11 As Integer = 0
            Dim TRecibo11 As Integer = 0

            Dim Tinv12 As Integer = 0
            Dim TVta12 As Integer = 0
            Dim TXRecibir12 As Integer = 0
            Dim TinvRecibo12 As Integer = 0
            Dim TRecibo12 As Integer = 0

            Sw_Entro = True





            Tinv1 = GridView1.GetRowCellValue(RenTotal1, "inv1") + GridView1.GetRowCellValue(RenTotal2, "inv1") + GridView1.GetRowCellValue(RenTotal3, "inv1") + GridView1.GetRowCellValue(RenTotal4, "inv1") + GridView1.GetRowCellValue(RenTotal5, "inv1") + GridView1.GetRowCellValue(RenTotal6, "inv1")
            TVta1 = GridView1.GetRowCellValue(RenTotal1, "vta1") + GridView1.GetRowCellValue(RenTotal2, "vta1") + GridView1.GetRowCellValue(RenTotal3, "vta1") + GridView1.GetRowCellValue(RenTotal4, "vta1") + GridView1.GetRowCellValue(RenTotal5, "vta1") + GridView1.GetRowCellValue(RenTotal6, "vta1")
            TXRecibir1 = GridView1.GetRowCellValue(RenTotal1, "xrecibir1") + GridView1.GetRowCellValue(RenTotal2, "xrecibir1") + GridView1.GetRowCellValue(RenTotal3, "xrecibir1") + GridView1.GetRowCellValue(RenTotal4, "xrecibir1") + GridView1.GetRowCellValue(RenTotal5, "xrecibir1") + GridView1.GetRowCellValue(RenTotal6, "xrecibir1")
            TRecibo1 = GridView1.GetRowCellValue(RenTotal1, "recibo1") + GridView1.GetRowCellValue(RenTotal2, "recibo1") + GridView1.GetRowCellValue(RenTotal3, "recibo1") + GridView1.GetRowCellValue(RenTotal4, "recibo1") + GridView1.GetRowCellValue(RenTotal5, "recibo1") + GridView1.GetRowCellValue(RenTotal6, "recibo1")

            Tinv2 = GridView1.GetRowCellValue(RenTotal1, "inv2") + GridView1.GetRowCellValue(RenTotal2, "inv2") + GridView1.GetRowCellValue(RenTotal3, "inv2") + GridView1.GetRowCellValue(RenTotal4, "inv2") + GridView1.GetRowCellValue(RenTotal5, "inv2") + GridView1.GetRowCellValue(RenTotal6, "inv2")
            TVta2 = GridView1.GetRowCellValue(RenTotal1, "vta2") + GridView1.GetRowCellValue(RenTotal2, "vta2") + GridView1.GetRowCellValue(RenTotal3, "vta2") + GridView1.GetRowCellValue(RenTotal4, "vta2") + GridView1.GetRowCellValue(RenTotal5, "vta2") + GridView1.GetRowCellValue(RenTotal6, "vta2")
            TXRecibir2 = GridView1.GetRowCellValue(RenTotal1, "xrecibir2") + GridView1.GetRowCellValue(RenTotal2, "xrecibir2") + GridView1.GetRowCellValue(RenTotal3, "xrecibir2") + GridView1.GetRowCellValue(RenTotal4, "xrecibir2") + GridView1.GetRowCellValue(RenTotal5, "xrecibir2") + GridView1.GetRowCellValue(RenTotal6, "xrecibir2")
            TRecibo2 = GridView1.GetRowCellValue(RenTotal1, "recibo2") + GridView1.GetRowCellValue(RenTotal2, "recibo2") + GridView1.GetRowCellValue(RenTotal3, "recibo2") + GridView1.GetRowCellValue(RenTotal4, "recibo2") + GridView1.GetRowCellValue(RenTotal5, "recibo2") + GridView1.GetRowCellValue(RenTotal6, "recibo2")

            Tinv3 = GridView1.GetRowCellValue(RenTotal1, "inv3") + GridView1.GetRowCellValue(RenTotal2, "inv3") + GridView1.GetRowCellValue(RenTotal3, "inv3") + GridView1.GetRowCellValue(RenTotal4, "inv3") + GridView1.GetRowCellValue(RenTotal5, "inv3") + GridView1.GetRowCellValue(RenTotal6, "inv3")
            TVta3 = GridView1.GetRowCellValue(RenTotal1, "vta3") + GridView1.GetRowCellValue(RenTotal2, "vta3") + GridView1.GetRowCellValue(RenTotal3, "vta3") + GridView1.GetRowCellValue(RenTotal4, "vta3") + GridView1.GetRowCellValue(RenTotal5, "vta3") + GridView1.GetRowCellValue(RenTotal6, "vta3")
            TXRecibir3 = GridView1.GetRowCellValue(RenTotal1, "xrecibir3") + GridView1.GetRowCellValue(RenTotal2, "xrecibir3") + GridView1.GetRowCellValue(RenTotal3, "xrecibir3") + GridView1.GetRowCellValue(RenTotal4, "xrecibir3") + GridView1.GetRowCellValue(RenTotal5, "xrecibir3") + GridView1.GetRowCellValue(RenTotal6, "xrecibir3")
            TRecibo3 = GridView1.GetRowCellValue(RenTotal1, "recibo3") + GridView1.GetRowCellValue(RenTotal2, "recibo3") + GridView1.GetRowCellValue(RenTotal3, "recibo3") + GridView1.GetRowCellValue(RenTotal4, "recibo3") + GridView1.GetRowCellValue(RenTotal5, "recibo3") + GridView1.GetRowCellValue(RenTotal6, "recibo3")


            Tinv4 = GridView1.GetRowCellValue(RenTotal1, "inv4") + GridView1.GetRowCellValue(RenTotal2, "inv4") + GridView1.GetRowCellValue(RenTotal3, "inv4") + GridView1.GetRowCellValue(RenTotal4, "inv4") + GridView1.GetRowCellValue(RenTotal5, "inv4") + GridView1.GetRowCellValue(RenTotal6, "inv4")
            TVta4 = GridView1.GetRowCellValue(RenTotal1, "vta4") + GridView1.GetRowCellValue(RenTotal2, "vta4") + GridView1.GetRowCellValue(RenTotal3, "vta4") + GridView1.GetRowCellValue(RenTotal4, "vta4") + GridView1.GetRowCellValue(RenTotal5, "vta4") + GridView1.GetRowCellValue(RenTotal6, "vta4")
            TXRecibir4 = GridView1.GetRowCellValue(RenTotal1, "xrecibir4") + GridView1.GetRowCellValue(RenTotal2, "xrecibir4") + GridView1.GetRowCellValue(RenTotal3, "xrecibir4") + GridView1.GetRowCellValue(RenTotal4, "xrecibir4") + GridView1.GetRowCellValue(RenTotal5, "xrecibir4") + GridView1.GetRowCellValue(RenTotal6, "xrecibir4")
            TRecibo4 = GridView1.GetRowCellValue(RenTotal1, "recibo4") + GridView1.GetRowCellValue(RenTotal2, "recibo4") + GridView1.GetRowCellValue(RenTotal3, "recibo4") + GridView1.GetRowCellValue(RenTotal4, "recibo4") + GridView1.GetRowCellValue(RenTotal5, "recibo4") + GridView1.GetRowCellValue(RenTotal6, "recibo4")


            Tinv5 = GridView1.GetRowCellValue(RenTotal1, "inv5") + GridView1.GetRowCellValue(RenTotal2, "inv5") + GridView1.GetRowCellValue(RenTotal3, "inv5") + GridView1.GetRowCellValue(RenTotal4, "inv5") + GridView1.GetRowCellValue(RenTotal5, "inv5") + GridView1.GetRowCellValue(RenTotal6, "inv5")
            TVta5 = GridView1.GetRowCellValue(RenTotal1, "vta5") + GridView1.GetRowCellValue(RenTotal2, "vta5") + GridView1.GetRowCellValue(RenTotal3, "vta5") + GridView1.GetRowCellValue(RenTotal4, "vta5") + GridView1.GetRowCellValue(RenTotal5, "vta5") + GridView1.GetRowCellValue(RenTotal6, "vta5")
            TXRecibir5 = GridView1.GetRowCellValue(RenTotal1, "xrecibir5") + GridView1.GetRowCellValue(RenTotal2, "xrecibir5") + GridView1.GetRowCellValue(RenTotal3, "xrecibir5") + GridView1.GetRowCellValue(RenTotal4, "xrecibir5") + GridView1.GetRowCellValue(RenTotal5, "xrecibir5") + GridView1.GetRowCellValue(RenTotal6, "xrecibir5")
            TRecibo5 = GridView1.GetRowCellValue(RenTotal1, "recibo5") + GridView1.GetRowCellValue(RenTotal2, "recibo5") + GridView1.GetRowCellValue(RenTotal3, "recibo5") + GridView1.GetRowCellValue(RenTotal4, "recibo5") + GridView1.GetRowCellValue(RenTotal5, "recibo5") + GridView1.GetRowCellValue(RenTotal6, "recibo5")


            Tinv6 = GridView1.GetRowCellValue(RenTotal1, "inv6") + GridView1.GetRowCellValue(RenTotal2, "inv6") + GridView1.GetRowCellValue(RenTotal3, "inv6") + GridView1.GetRowCellValue(RenTotal4, "inv6") + GridView1.GetRowCellValue(RenTotal5, "inv6") + GridView1.GetRowCellValue(RenTotal6, "inv6")
            TVta6 = GridView1.GetRowCellValue(RenTotal1, "vta6") + GridView1.GetRowCellValue(RenTotal2, "vta6") + GridView1.GetRowCellValue(RenTotal3, "vta6") + GridView1.GetRowCellValue(RenTotal4, "vta6") + GridView1.GetRowCellValue(RenTotal5, "vta6") + GridView1.GetRowCellValue(RenTotal6, "vta6")
            TXRecibir6 = GridView1.GetRowCellValue(RenTotal1, "xrecibir6") + GridView1.GetRowCellValue(RenTotal2, "xrecibir6") + GridView1.GetRowCellValue(RenTotal3, "xrecibir6") + GridView1.GetRowCellValue(RenTotal4, "xrecibir6") + GridView1.GetRowCellValue(RenTotal5, "xrecibir6") + GridView1.GetRowCellValue(RenTotal6, "xrecibir6")
            TRecibo6 = GridView1.GetRowCellValue(RenTotal1, "recibo6") + GridView1.GetRowCellValue(RenTotal2, "recibo6") + GridView1.GetRowCellValue(RenTotal3, "recibo6") + GridView1.GetRowCellValue(RenTotal4, "recibo6") + GridView1.GetRowCellValue(RenTotal5, "recibo6") + GridView1.GetRowCellValue(RenTotal6, "recibo6")


            Tinv7 = GridView1.GetRowCellValue(RenTotal1, "inv7") + GridView1.GetRowCellValue(RenTotal2, "inv7") + GridView1.GetRowCellValue(RenTotal3, "inv7") + GridView1.GetRowCellValue(RenTotal4, "inv7") + GridView1.GetRowCellValue(RenTotal5, "inv7") + GridView1.GetRowCellValue(RenTotal6, "inv7")
            TVta7 = GridView1.GetRowCellValue(RenTotal1, "vta7") + GridView1.GetRowCellValue(RenTotal2, "vta7") + GridView1.GetRowCellValue(RenTotal3, "vta7") + GridView1.GetRowCellValue(RenTotal4, "vta7") + GridView1.GetRowCellValue(RenTotal5, "vta7") + GridView1.GetRowCellValue(RenTotal6, "vta7")
            TXRecibir7 = GridView1.GetRowCellValue(RenTotal1, "xrecibir7") + GridView1.GetRowCellValue(RenTotal2, "xrecibir7") + GridView1.GetRowCellValue(RenTotal3, "xrecibir7") + GridView1.GetRowCellValue(RenTotal4, "xrecibir7") + GridView1.GetRowCellValue(RenTotal5, "xrecibir7") + GridView1.GetRowCellValue(RenTotal6, "xrecibir7")
            TRecibo7 = GridView1.GetRowCellValue(RenTotal1, "recibo7") + GridView1.GetRowCellValue(RenTotal2, "recibo7") + GridView1.GetRowCellValue(RenTotal3, "recibo7") + GridView1.GetRowCellValue(RenTotal4, "recibo7") + GridView1.GetRowCellValue(RenTotal5, "recibo7") + GridView1.GetRowCellValue(RenTotal6, "recibo7")


            Tinv8 = GridView1.GetRowCellValue(RenTotal1, "inv8") + GridView1.GetRowCellValue(RenTotal2, "inv8") + GridView1.GetRowCellValue(RenTotal3, "inv8") + GridView1.GetRowCellValue(RenTotal4, "inv8") + GridView1.GetRowCellValue(RenTotal5, "inv8") + GridView1.GetRowCellValue(RenTotal6, "inv8")
            TVta8 = GridView1.GetRowCellValue(RenTotal1, "vta8") + GridView1.GetRowCellValue(RenTotal2, "vta8") + GridView1.GetRowCellValue(RenTotal3, "vta8") + GridView1.GetRowCellValue(RenTotal4, "vta8") + GridView1.GetRowCellValue(RenTotal5, "vta8") + GridView1.GetRowCellValue(RenTotal6, "vta8")
            TXRecibir8 = GridView1.GetRowCellValue(RenTotal1, "xrecibir8") + GridView1.GetRowCellValue(RenTotal2, "xrecibir8") + GridView1.GetRowCellValue(RenTotal3, "xrecibir8") + GridView1.GetRowCellValue(RenTotal4, "xrecibir8") + GridView1.GetRowCellValue(RenTotal5, "xrecibir8") + GridView1.GetRowCellValue(RenTotal6, "xrecibir8")
            TRecibo8 = GridView1.GetRowCellValue(RenTotal1, "recibo8") + GridView1.GetRowCellValue(RenTotal2, "recibo8") + GridView1.GetRowCellValue(RenTotal3, "recibo8") + GridView1.GetRowCellValue(RenTotal4, "recibo8") + GridView1.GetRowCellValue(RenTotal5, "recibo8") + GridView1.GetRowCellValue(RenTotal6, "recibo8")


            Tinv9 = GridView1.GetRowCellValue(RenTotal1, "inv9") + GridView1.GetRowCellValue(RenTotal2, "inv9") + GridView1.GetRowCellValue(RenTotal3, "inv9") + GridView1.GetRowCellValue(RenTotal4, "inv9") + GridView1.GetRowCellValue(RenTotal5, "inv9") + GridView1.GetRowCellValue(RenTotal6, "inv9")
            TVta9 = GridView1.GetRowCellValue(RenTotal1, "vta9") + GridView1.GetRowCellValue(RenTotal2, "vta9") + GridView1.GetRowCellValue(RenTotal3, "vta9") + GridView1.GetRowCellValue(RenTotal4, "vta9") + GridView1.GetRowCellValue(RenTotal5, "vta9") + GridView1.GetRowCellValue(RenTotal6, "vta9")
            TXRecibir9 = GridView1.GetRowCellValue(RenTotal1, "xrecibir9") + GridView1.GetRowCellValue(RenTotal2, "xrecibir9") + GridView1.GetRowCellValue(RenTotal3, "xrecibir9") + GridView1.GetRowCellValue(RenTotal4, "xrecibir9") + GridView1.GetRowCellValue(RenTotal5, "xrecibir9") + GridView1.GetRowCellValue(RenTotal6, "xrecibir9")
            TRecibo9 = GridView1.GetRowCellValue(RenTotal1, "recibo9") + GridView1.GetRowCellValue(RenTotal2, "recibo9") + GridView1.GetRowCellValue(RenTotal3, "recibo9") + GridView1.GetRowCellValue(RenTotal4, "recibo9") + GridView1.GetRowCellValue(RenTotal5, "recibo9") + GridView1.GetRowCellValue(RenTotal6, "recibo9")


            Tinv10 = GridView1.GetRowCellValue(RenTotal1, "inv10") + GridView1.GetRowCellValue(RenTotal2, "inv10") + GridView1.GetRowCellValue(RenTotal3, "inv10") + GridView1.GetRowCellValue(RenTotal4, "inv10") + GridView1.GetRowCellValue(RenTotal5, "inv10") + GridView1.GetRowCellValue(RenTotal6, "inv10")
            TVta10 = GridView1.GetRowCellValue(RenTotal1, "vta10") + GridView1.GetRowCellValue(RenTotal2, "vta10") + GridView1.GetRowCellValue(RenTotal3, "vta10") + GridView1.GetRowCellValue(RenTotal4, "vta10") + GridView1.GetRowCellValue(RenTotal5, "vta10") + GridView1.GetRowCellValue(RenTotal6, "vta10")
            TXRecibir10 = GridView1.GetRowCellValue(RenTotal1, "xrecibir10") + GridView1.GetRowCellValue(RenTotal2, "xrecibir10") + GridView1.GetRowCellValue(RenTotal3, "xrecibir10") + GridView1.GetRowCellValue(RenTotal4, "xrecibir10") + GridView1.GetRowCellValue(RenTotal5, "xrecibir10") + GridView1.GetRowCellValue(RenTotal6, "xrecibir10")
            TRecibo10 = GridView1.GetRowCellValue(RenTotal1, "recibo10") + GridView1.GetRowCellValue(RenTotal2, "recibo10") + GridView1.GetRowCellValue(RenTotal3, "recibo10") + GridView1.GetRowCellValue(RenTotal4, "recibo10") + GridView1.GetRowCellValue(RenTotal5, "recibo10") + GridView1.GetRowCellValue(RenTotal6, "recibo10")


            Tinv11 = GridView1.GetRowCellValue(RenTotal1, "inv11") + GridView1.GetRowCellValue(RenTotal2, "inv11") + GridView1.GetRowCellValue(RenTotal3, "inv11") + GridView1.GetRowCellValue(RenTotal4, "inv11") + GridView1.GetRowCellValue(RenTotal5, "inv11") + GridView1.GetRowCellValue(RenTotal6, "inv11")
            TVta11 = GridView1.GetRowCellValue(RenTotal1, "vta11") + GridView1.GetRowCellValue(RenTotal2, "vta11") + GridView1.GetRowCellValue(RenTotal3, "vta11") + GridView1.GetRowCellValue(RenTotal4, "vta11") + GridView1.GetRowCellValue(RenTotal5, "vta11") + GridView1.GetRowCellValue(RenTotal6, "vta11")
            TXRecibir11 = GridView1.GetRowCellValue(RenTotal1, "xrecibir11") + GridView1.GetRowCellValue(RenTotal2, "xrecibir11") + GridView1.GetRowCellValue(RenTotal3, "xrecibir11") + GridView1.GetRowCellValue(RenTotal4, "xrecibir11") + GridView1.GetRowCellValue(RenTotal5, "xrecibir11") + GridView1.GetRowCellValue(RenTotal6, "xrecibir11")
            TRecibo11 = GridView1.GetRowCellValue(RenTotal1, "recibo11") + GridView1.GetRowCellValue(RenTotal2, "recibo11") + GridView1.GetRowCellValue(RenTotal3, "recibo11") + GridView1.GetRowCellValue(RenTotal4, "recibo11") + GridView1.GetRowCellValue(RenTotal5, "recibo11") + GridView1.GetRowCellValue(RenTotal6, "recibo11")


            Tinv12 = GridView1.GetRowCellValue(RenTotal1, "inv12") + GridView1.GetRowCellValue(RenTotal2, "inv12") + GridView1.GetRowCellValue(RenTotal3, "inv12") + GridView1.GetRowCellValue(RenTotal4, "inv12") + GridView1.GetRowCellValue(RenTotal5, "inv12") + GridView1.GetRowCellValue(RenTotal6, "inv12")
            TVta12 = GridView1.GetRowCellValue(RenTotal1, "vta12") + GridView1.GetRowCellValue(RenTotal2, "vta12") + GridView1.GetRowCellValue(RenTotal3, "vta12") + GridView1.GetRowCellValue(RenTotal4, "vta12") + GridView1.GetRowCellValue(RenTotal5, "vta12") + GridView1.GetRowCellValue(RenTotal6, "vta12")
            TXRecibir12 = GridView1.GetRowCellValue(RenTotal1, "xrecibir12") + GridView1.GetRowCellValue(RenTotal2, "xrecibir12") + GridView1.GetRowCellValue(RenTotal3, "xrecibir12") + GridView1.GetRowCellValue(RenTotal4, "xrecibir12") + GridView1.GetRowCellValue(RenTotal5, "xrecibir12") + GridView1.GetRowCellValue(RenTotal6, "xrecibir12")
            TRecibo12 = GridView1.GetRowCellValue(RenTotal1, "recibo12") + GridView1.GetRowCellValue(RenTotal2, "recibo12") + GridView1.GetRowCellValue(RenTotal3, "recibo12") + GridView1.GetRowCellValue(RenTotal4, "recibo12") + GridView1.GetRowCellValue(RenTotal5, "recibo12") + GridView1.GetRowCellValue(RenTotal6, "recibo12")





            TinvRecibo1 = Tinv1 + TRecibo1 + TXRecibir1
            TinvRecibo2 = Tinv2 + TRecibo2 + TXRecibir2
            TinvRecibo3 = Tinv3 + TRecibo3 + TXRecibir3
            TinvRecibo4 = Tinv4 + TRecibo4 + TXRecibir4
            TinvRecibo5 = Tinv5 + TRecibo5 + TXRecibir5
            TinvRecibo6 = Tinv6 + TRecibo6 + TXRecibir6
            TinvRecibo7 = Tinv7 + TRecibo7 + TXRecibir7
            TinvRecibo8 = Tinv8 + TRecibo8 + TXRecibir8
            TinvRecibo9 = Tinv9 + TRecibo9 + TXRecibir9
            TinvRecibo10 = Tinv10 + TRecibo10 + TXRecibir10
            TinvRecibo11 = Tinv11 + TRecibo11 + TXRecibir11
            TinvRecibo12 = Tinv12 + TRecibo12 + TXRecibir12

            GridView1.SetRowCellValue(RenTotal, "inv1", Tinv1)
            GridView1.SetRowCellValue(RenTotal, "vta1", TVta1)
            GridView1.SetRowCellValue(RenTotal, "xecibir1", TXRecibir1)
            GridView1.SetRowCellValue(RenTotal, "invrecibo1", TinvRecibo1)
            GridView1.SetRowCellValue(RenTotal, "recibo1", TRecibo1)
            '' SUMAR EL CERO.
            GridView1.SetRowCellValue(RenTotal, "inv2", Tinv2)
            GridView1.SetRowCellValue(RenTotal, "vta2", TVta2)
            GridView1.SetRowCellValue(RenTotal, "xecibir2", TXRecibir2)
            GridView1.SetRowCellValue(RenTotal, "invrecibo2", TinvRecibo2)
            GridView1.SetRowCellValue(RenTotal, "recibo2", TRecibo2)

            GridView1.SetRowCellValue(RenTotal, "inv3", Tinv3)
            GridView1.SetRowCellValue(RenTotal, "vta3", TVta3)
            GridView1.SetRowCellValue(RenTotal, "xecibir3", TXRecibir3)
            GridView1.SetRowCellValue(RenTotal, "invrecibo3", TinvRecibo3)
            GridView1.SetRowCellValue(RenTotal, "recibo3", TRecibo3)

            GridView1.SetRowCellValue(RenTotal, "inv4", Tinv4)
            GridView1.SetRowCellValue(RenTotal, "vta4", TVta4)
            GridView1.SetRowCellValue(RenTotal, "xecibir4", TXRecibir4)
            GridView1.SetRowCellValue(RenTotal, "invrecibo4", TinvRecibo4)
            GridView1.SetRowCellValue(RenTotal, "recibo4", TRecibo4)

            GridView1.SetRowCellValue(RenTotal, "inv5", Tinv5)
            GridView1.SetRowCellValue(RenTotal, "vta5", TVta5)
            GridView1.SetRowCellValue(RenTotal, "xecibir5", TXRecibir5)
            GridView1.SetRowCellValue(RenTotal, "invrecibo5", TinvRecibo5)
            GridView1.SetRowCellValue(RenTotal, "recibo5", TRecibo5)

            GridView1.SetRowCellValue(RenTotal, "inv6", Tinv6)
            GridView1.SetRowCellValue(RenTotal, "vta6", TVta6)
            GridView1.SetRowCellValue(RenTotal, "xecibir6", TXRecibir6)
            GridView1.SetRowCellValue(RenTotal, "invrecibo6", TinvRecibo6)
            GridView1.SetRowCellValue(RenTotal, "recibo6", TRecibo6)

            GridView1.SetRowCellValue(RenTotal, "inv7", Tinv7)
            GridView1.SetRowCellValue(RenTotal, "vta7", TVta7)
            GridView1.SetRowCellValue(RenTotal, "xecibir7", TXRecibir7)
            GridView1.SetRowCellValue(RenTotal, "invrecibo7", TinvRecibo7)
            GridView1.SetRowCellValue(RenTotal, "recibo7", TRecibo7)

            GridView1.SetRowCellValue(RenTotal, "inv8", Tinv8)
            GridView1.SetRowCellValue(RenTotal, "vta8", TVta8)
            GridView1.SetRowCellValue(RenTotal, "xecibir8", TXRecibir8)
            GridView1.SetRowCellValue(RenTotal, "invrecibo8", TinvRecibo8)
            GridView1.SetRowCellValue(RenTotal, "recibo8", TRecibo8)

            GridView1.SetRowCellValue(RenTotal, "inv9", Tinv9)
            GridView1.SetRowCellValue(RenTotal, "vta9", TVta9)
            GridView1.SetRowCellValue(RenTotal, "xecibir9", TXRecibir9)
            GridView1.SetRowCellValue(RenTotal, "invrecibo9", TinvRecibo9)
            GridView1.SetRowCellValue(RenTotal, "recibo9", TRecibo9)

            GridView1.SetRowCellValue(RenTotal, "inv10", Tinv10)
            GridView1.SetRowCellValue(RenTotal, "vta10", TVta10)
            GridView1.SetRowCellValue(RenTotal, "xecibir10", TXRecibir10)
            GridView1.SetRowCellValue(RenTotal, "invrecibo10", TinvRecibo10)
            GridView1.SetRowCellValue(RenTotal, "recibo10", TRecibo10)

            GridView1.SetRowCellValue(RenTotal, "inv11", Tinv11)
            GridView1.SetRowCellValue(RenTotal, "vta11", TVta11)
            GridView1.SetRowCellValue(RenTotal, "xecibir11", TXRecibir11)
            GridView1.SetRowCellValue(RenTotal, "invrecibo11", TinvRecibo11)
            GridView1.SetRowCellValue(RenTotal, "recibo11", TRecibo11)

            GridView1.SetRowCellValue(RenTotal, "inv12", Tinv12)
            GridView1.SetRowCellValue(RenTotal, "vta12", TVta12)
            GridView1.SetRowCellValue(RenTotal, "xecibir12", TXRecibir12)
            GridView1.SetRowCellValue(RenTotal, "invrecibo12", TinvRecibo12)
            GridView1.SetRowCellValue(RenTotal, "recibo12", TRecibo12)



            Call CalcularColumnas(RenTotal)
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub GridView1_RowCellStyle(ByVal sender As Object, ByVal e As RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        Try
            Dim View As GridView = sender

            Dim Pos As Integer = 0
            Dim Pos1 As Integer = 0
            Dim Nombre As String = ""

            Pos = InStr(LCase(e.Column.FieldName), "precio")
            Pos1 = InStr(LCase(e.Column.FieldName), "costo")
            Nombre = LCase(e.Column.Name)


            If Pos > 0 Or Pos1 > 0 Then
                Dim importe As Decimal = Val(View.GetRowCellDisplayText(e.RowHandle, e.Column))
                If importe < 0 Then
                    e.Appearance.ForeColor = Color.Red
                    e.Appearance.FontStyleDelta = FontStyle.Bold
                End If
            End If


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try


    End Sub

    Private Sub GridView1_RowStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles GridView1.RowStyle
        Dim View As GridView = sender
        If (e.RowHandle >= 0) Then
            Dim category As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("l1"))
            If category = ".TOTAL" Then
                e.Appearance.BackColor = Color.PowderBlue
                e.Appearance.BackColor2 = Color.SeaShell
            End If
        End If
    End Sub
    Private Sub DGrid1_Click(sender As Object, e As EventArgs) Handles DGrid1.Click

    End Sub

    Private Sub frmPpalProyeccionComprasL1_ForeColorChanged(sender As Object, e As EventArgs) Handles Me.ForeColorChanged

    End Sub

    Private Sub Btn_Aceptar_Click(sender As Object, e As EventArgs) Handles Btn_Aceptar.Click
        'mreyes 30/Agosto/2017  05:19 p.m.
        Try
            Dim Linea As String = ""
            Dim L1 As String = ""
            Dim Recibo1 As Integer = 0
            Dim Recibo2 As Integer = 0
            Dim Recibo3 As Integer = 0
            Dim Recibo4 As Integer = 0
            Dim Recibo5 As Integer = 0
            Dim Recibo6 As Integer = 0
            Dim Recibo7 As Integer = 0
            Dim Recibo8 As Integer = 0
            Dim Recibo9 As Integer = 0
            Dim Recibo10 As Integer = 0
            Dim Recibo11 As Integer = 0
            Dim Recibo12 As Integer = 0

            Btn_Aceptar.Enabled = False
            Using objTrasp As New BCL.BCLCostoMargen(GLB_ConStringDwhSQL)
                If objTrasp.usp_CapturaProyeccionReciboL1(5, "", "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0) Then

                End If

            End Using

            For i As Integer = 0 To GridView1.RowCount - 1
                    Linea = GridView1.GetRowCellValue(i, "linea")
                    L1 = GridView1.GetRowCellValue(i, "l1")
                    If L1 <> ".TOTAL" Then
                        Recibo1 = GridView1.GetRowCellValue(i, "recibo1")
                        Recibo2 = GridView1.GetRowCellValue(i, "recibo2")
                        Recibo3 = GridView1.GetRowCellValue(i, "recibo3")
                        Recibo4 = GridView1.GetRowCellValue(i, "recibo4")
                        Recibo5 = GridView1.GetRowCellValue(i, "recibo5")
                        Recibo6 = GridView1.GetRowCellValue(i, "recibo6")
                        Recibo7 = GridView1.GetRowCellValue(i, "recibo7")
                        Recibo8 = GridView1.GetRowCellValue(i, "recibo8")
                        Recibo9 = GridView1.GetRowCellValue(i, "recibo9")
                        Recibo10 = GridView1.GetRowCellValue(i, "recibo10")
                        Recibo11 = GridView1.GetRowCellValue(i, "recibo11")
                        Recibo12 = GridView1.GetRowCellValue(i, "recibo12")

                    Using objTrasp As New BCL.BCLCostoMargen(GLB_ConStringDwhSQL)
                        If objTrasp.usp_CapturaProyeccionReciboL1(1, Linea, L1, Recibo1, Recibo2, Recibo3, Recibo4, Recibo5, Recibo6, Recibo7, Recibo8, Recibo9, Recibo10, Recibo11, Recibo12) Then

                        End If
                    End Using
                End If
                Next
                Sw_Load = False


            'Using objTrasp As New BCL.BCLCostoMargen(GLB_ConStringDwhSQL)
            '    usp_GeneraProyeccionCompra
            'End Using
            MsgBox("Guardado correctamente", MsgBoxStyle.Information, "Confirmación")
            Btn_Aceptar.Enabled = True
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Eliminar_Click(sender As Object, e As EventArgs) Handles Btn_Eliminar.Click
        'mreyes 30/Agosto/2017  05:50 p.m.
        Try


            Btn_Eliminar.Enabled = False
            Using objTrasp As New BCL.BCLCostoMargen(GLB_ConStringDwhSQL)
                If objTrasp.usp_CapturaProyeccionReciboL1(5, "", "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0) Then

                End If

            End Using

            'dejar en ceros todo lo de recibo.
            Call RellenaGrid()
            For i As Integer = 0 To GridView1.RowCount - 1
                Call CalcularColumnas(i)
            Next

            MsgBox("Eliminado correctamente", vbOK, "Confirmación")
            Btn_Eliminar.Enabled = True
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub frmPpalProyeccionComprasL1_GiveFeedback(sender As Object, e As GiveFeedbackEventArgs) Handles Me.GiveFeedback

    End Sub
End Class