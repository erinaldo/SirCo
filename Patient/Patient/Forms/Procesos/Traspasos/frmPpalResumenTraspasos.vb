Public Class frmPpalResumenTraspasos

    'mreyes 07/Octubre/2016 11:24 a.m.

    Private objDataSet As Data.DataSet
    Private objDataSet1 As Data.DataSet 'Segundo Nivel
    Dim SucurOriB As Integer = 0
    Dim SucurDesB As Integer = 0
    Dim FechaInib As String
    Dim FechaFinb As String

    Dim Sw_Load As Boolean = True
    Dim Sw_NoRegistros As Boolean = False
    Dim Sw_Pintar As Boolean = False
    Public Opcion As Integer = 0   '1 = Enviado,  2 = Por Recibir
    Public OpcionSP As Integer = 0
    Dim MarcaFOTO As String = ""
    Dim EstiloNFOTO As String = ""
    Dim blnEntraDet As Boolean = False

    Dim IdProTrasB As Integer = 0
    Dim EstatusB As String = ""
    Private izquierda As Integer = 0
    Private alto As Integer = 0



    Private Sub frmPpalPpalDetFactProv_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Call GenerarToolTip()
        Sw_Pintar = True
        Sw_Load = True

        Call RellenaGrid()

    End Sub

    Private Sub frmPpalPpalDetFactProv_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If Sw_NoRegistros = False Then Exit Sub
        'If Sw_Load = True Then
        '    Sw_Load = False
        'blnPrimero = True
        ' InicializaGrid()
        'AgregarColumna()
        '    Call BarrerGrid()
        'End If
    End Sub

    Private Sub GenerarToolTip()
        Try
          

            ToolTip.SetToolTip(Btn_Salir, "Salir")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub



    Private Sub RellenaGrid()
        'mreyes 07/Octubre/2016 11:28 a.m.

        DGrid.Visible = False
        'InicializaGrid()
        Using objTrasp As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoSQL)

            Try
                Me.Cursor = Cursors.WaitCursor
                'DGrid.ReadOnly = True
                DGrid.DataSource = Nothing

                objDataSet = objTrasp.usp_PpalResumenProTrasp()

                'Populate the Project Details section
                If objDataSet.Tables(0).Rows.Count > 0 Then
                   
                    DGrid.DataSource = objDataSet.Tables(0)
                    DGrid1.DataSource = objDataSet.Tables(1)

                    InicializaGrid(DGrid)
                    InicializaGrid(DGrid1)
   
                    Me.Cursor = Cursors.Default

                    Sw_NoRegistros = True
                    Sw_Pintar = True
                   
                Else
                    Sw_NoRegistros = False
                    Me.Cursor = Cursors.Default
                    MsgBox("No se encontraron registros que cumplan con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")

                End If
                Me.Cursor = Cursors.Default
                DGrid.Visible = True
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Sub InicializaGrid(ByVal Grid As DataGridView)
        'mreyes 07/Octubre/2016 11:42 a.m.

        Try



            Dim dt As DataTable = TryCast(Grid.DataSource, DataTable)
            Dim row As DataRow = dt.NewRow()

            row(1) = "TOTAL: "
            row("PEDIDA") = pub_SumarColumnaGrid(Grid, 2, Grid.RowCount - 1)

            dt.Rows.InsertAt(row, 0)
            Grid.DataSource = dt

            Grid.RowHeadersVisible = False
            Grid.Columns(0).HeaderText = "Det"
            Grid.Columns(1).HeaderText = "Sucursal"
            Grid.Columns(2).HeaderText = "Pares"



            Grid.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Grid.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells


            Grid.Rows(0).DefaultCellStyle.BackColor = Color.PowderBlue
            Grid.Rows(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Grid.Rows(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub



    Private Sub Btn_Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Salir.Click
        Me.Close()
        Me.Dispose()
    End Sub



    Private Sub frmPpalPpalDetFactProv_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub








End Class
