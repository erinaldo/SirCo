Public Class frmPpalFormasPago

    Private objDataSet As Data.DataSet
    Public Opcion As Integer = 0
    Public Sucursal As String = ""
    Public FecIniA As String = ""
    Public FecIniB As String = ""
    Private Importes As Boolean = False
    Private Transacciones As Boolean = False
    Private Ambas As Boolean = False
    Dim myForm As frmFiltrosFormasPago
    Dim blnPrimero As Boolean = True

    Private Sub frmPpalNomina_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Try
            If DGrid.DataSource Is Nothing Then Exit Sub
            If blnPrimero = True Then
                blnPrimero = False
                DGrid.Rows(0).Frozen = True
                DGrid.Rows(0).DefaultCellStyle.BackColor = Color.PowderBlue
                DGrid.Rows(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Rows(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

                DGrid.Columns(1).Frozen = True
                DGrid.Columns(1).DefaultCellStyle.BackColor = Color.PowderBlue
                DGrid.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(1).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub frmPpalProveedores_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then
                Me.Close()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub frmPpalProveedores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            myForm = New frmFiltrosFormasPago
            RellenaGrid()
            RB_Importes.Checked = True
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub RellenaGrid()
        Dim MInicio As String = "S"

        If Chk_Sucursal.Checked = True Then

            MInicio = "N"
        End If

        If FecIniA = "" Then
            FecIniA = GLB_FechaHoy.ToString("yyyy-MM-dd")
            FecIniB = GLB_FechaHoy.ToString("yyyy-MM-dd")
        End If
        Using objMySqlGral As New BCL.BCLFormasPago(GLB_ConStringCipSis)
            objDataSet = objMySqlGral.usp_TraerFormasPago(Sucursal, FecIniA, FecIniB, 1.16, MInicio)
        End Using
        If objDataSet.Tables(0).Rows.Count > 0 Then
            DGrid.DataSource = Nothing
            DGrid.DataSource = objDataSet.Tables(0)
            InicializaGrid()
            lbl_Texto.Text = "FECHA DEL: " + CDate(FecIniA).ToString("dd/MMM/yyyy").ToUpper + " AL: " + CDate(FecIniB).ToString("dd/MMM/yyyy").ToUpper
        Else
            FecIniA = GLB_FechaHoy.AddDays(-1).ToString("yyyy-MM-dd")
            FecIniB = GLB_FechaHoy.AddDays(-1).ToString("yyyy-MM-dd")
            Using objMySqlGral As New BCL.BCLFormasPago(GLB_ConStringCipSis)
                objDataSet = objMySqlGral.usp_TraerFormasPago(Sucursal, FecIniA, FecIniB, 1.16, MInicio)
            End Using
            If objDataSet.Tables(0).Rows.Count > 0 Then
                DGrid.DataSource = Nothing
                DGrid.DataSource = objDataSet.Tables(0)
                InicializaGrid()
                lbl_Texto.Text = "FECHA DEL: " + CDate(FecIniA).ToString("dd/MMM/yyyy").ToUpper + " AL: " + CDate(FecIniB).ToString("dd/MMM/yyyy").ToUpper
            Else
                DGrid.DataSource = Nothing
                lbl_Texto.Text = ""
                MessageBox.Show("Información no encontrada", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

    Private Sub GenerarToolTip()
        Try
            '
            ToolTip.SetToolTip(Btn_Filtro, "Búsqueda Avanzada")
            ToolTip.SetToolTip(Btn_Excel, "Exportar a Excel")
            ToolTip.SetToolTip(Btn_Salir, "Salir")

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Public Function pub_SumarColumnaGridNombre(ByVal DGrid As DataGridView, ByVal Columna As String, Optional ByVal HastaRenglon As Integer = 0) As Decimal
        'mreyes 14/Febrero/2012 05:08 p.m.
        Try
            Dim Col As Integer = DGrid.CurrentCell.ColumnIndex

            pub_SumarColumnaGridNombre = 0
            For renglon As Integer = 0 To IIf(HastaRenglon = 0, DGrid.RowCount - 2, HastaRenglon)
                If IsNumeric(DGrid.Rows(renglon).Cells(Columna).Value) Then
                    pub_SumarColumnaGridNombre = (DGrid.Rows(renglon).Cells(Columna).Value) + pub_SumarColumnaGridNombre
                End If
            Next
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function

    Sub InicializaGrid()
        Try
            Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)

            Dim row As DataRow = dt.NewRow()
            row(1) = "TOTAL: "
            row("total") = pub_SumarColumnaGridNombre(DGrid, "total", DGrid.RowCount - 1)
            row("porctrans") = pub_SumarColumnaGridNombre(DGrid, "porctrans", DGrid.RowCount - 1)
            row("importe") = pub_SumarColumnaGridNombre(DGrid, "importe", DGrid.RowCount - 1)
            row("porcimporte") = pub_SumarColumnaGridNombre(DGrid, "porcimporte", DGrid.RowCount - 1)
            row("transefectivo") = pub_SumarColumnaGridNombre(DGrid, "transefectivo", DGrid.RowCount - 1)
            row("efectivo") = pub_SumarColumnaGridNombre(DGrid, "efectivo", DGrid.RowCount - 1)
            row("transvale") = pub_SumarColumnaGridNombre(DGrid, "transvale", DGrid.RowCount - 1)
            row("vale") = pub_SumarColumnaGridNombre(DGrid, "vale", DGrid.RowCount - 1)
            row("transcontravale") = pub_SumarColumnaGridNombre(DGrid, "transcontravale", DGrid.RowCount - 1)
            row("contravale") = pub_SumarColumnaGridNombre(DGrid, "contravale", DGrid.RowCount - 1)
            row("transdevventa") = pub_SumarColumnaGridNombre(DGrid, "transdevventa", DGrid.RowCount - 1)
            row("devventa") = pub_SumarColumnaGridNombre(DGrid, "devventa", DGrid.RowCount - 1)
            row("transcredito") = pub_SumarColumnaGridNombre(DGrid, "transcredito", DGrid.RowCount - 1)
            row("credito") = pub_SumarColumnaGridNombre(DGrid, "credito", DGrid.RowCount - 1)
            row("transdebito") = pub_SumarColumnaGridNombre(DGrid, "transdebito", DGrid.RowCount - 1)
            row("debito") = pub_SumarColumnaGridNombre(DGrid, "debito", DGrid.RowCount - 1)
            row("transcheque") = pub_SumarColumnaGridNombre(DGrid, "transcheque", DGrid.RowCount - 1)
            row("cheque") = pub_SumarColumnaGridNombre(DGrid, "cheque", DGrid.RowCount - 1)
            row("transventaapa") = pub_SumarColumnaGridNombre(DGrid, "transventaapa", DGrid.RowCount - 1)
            row("ventaapa") = pub_SumarColumnaGridNombre(DGrid, "ventaapa", DGrid.RowCount - 1)
            row("transcancapa") = pub_SumarColumnaGridNombre(DGrid, "transcancapa", DGrid.RowCount - 1)
            row("cancapa") = pub_SumarColumnaGridNombre(DGrid, "cancapa", DGrid.RowCount - 1)
            row("transdescto") = pub_SumarColumnaGridNombre(DGrid, "transdescto", DGrid.RowCount - 1)
            row("descto") = pub_SumarColumnaGridNombre(DGrid, "descto", DGrid.RowCount - 1)
            row("transdevpromo") = pub_SumarColumnaGridNombre(DGrid, "transdevpromo", DGrid.RowCount - 1)
            row("devpromo") = pub_SumarColumnaGridNombre(DGrid, "devpromo", DGrid.RowCount - 1)
            row("transfonacot") = pub_SumarColumnaGridNombre(DGrid, "transfonacot", DGrid.RowCount - 1)
            row("fonacot") = pub_SumarColumnaGridNombre(DGrid, "fonacot", DGrid.RowCount - 1)
            row("transgobcoa") = pub_SumarColumnaGridNombre(DGrid, "transgobcoa", DGrid.RowCount - 1)
            row("gobcoa") = pub_SumarColumnaGridNombre(DGrid, "gobcoa", DGrid.RowCount - 1)
            row("transdinele") = pub_SumarColumnaGridNombre(DGrid, "transdinele", DGrid.RowCount - 1)
            row("dinele") = pub_SumarColumnaGridNombre(DGrid, "dinele", DGrid.RowCount - 1)
            row("transpuntos") = pub_SumarColumnaGridNombre(DGrid, "transpuntos", DGrid.RowCount - 1)
            row("puntos") = pub_SumarColumnaGridNombre(DGrid, "puntos", DGrid.RowCount - 1)

            row("transTAMIGO") = pub_SumarColumnaGridNombre(DGrid, "transTAMIGO", DGrid.RowCount - 1)
            row("TAMIGO") = pub_SumarColumnaGridNombre(DGrid, "TAMIGO", DGrid.RowCount - 1)


            row("transvaletodo") = pub_SumarColumnaGridNombre(DGrid, "transvaletodo", DGrid.RowCount - 1)
            row("valetodo") = pub_SumarColumnaGridNombre(DGrid, "valetodo", DGrid.RowCount - 1)


            If row("total") > 0 Then
                'row("porc_tot") = Math.Round((row("total") / row("total")) * 100, 2)
                row("porctransefectivo") = Math.Round((row("transefectivo") / row("total")) * 100, 2)
                row("porctransvale") = Math.Round((row("transvale") / row("total")) * 100, 2)
                row("porctranscontravale") = Math.Round((row("transcontravale") / row("total")) * 100, 2)
                row("porctransdevventa") = Math.Round((row("transdevventa") / row("total")) * 100, 2)
                row("porctranscredito") = Math.Round((row("transcredito") / row("total")) * 100, 2)
                row("porctransdebito") = Math.Round((row("transdebito") / row("total")) * 100, 2)
                row("porctranscheque") = Math.Round((row("transcheque") / row("total")) * 100, 2)
                row("porctransventaapa") = Math.Round((row("transventaapa") / row("total")) * 100, 2)
                row("porctranscancapa") = Math.Round((row("transcancapa") / row("total")) * 100, 2)
                row("porctransdescto") = Math.Round((row("transdescto") / row("total")) * 100, 2)
                row("porctransdevpromo") = Math.Round((row("transdevpromo") / row("total")) * 100, 2)
                row("porctransfonacot") = Math.Round((row("transfonacot") / row("total")) * 100, 2)
                row("porctransgobcoa") = Math.Round((row("transgobcoa") / row("total")) * 100, 2)
                row("porctransdinele") = Math.Round((row("transdinele") / row("total")) * 100, 2)
                row("porctranspuntos") = Math.Round((row("transpuntos") / row("total")) * 100, 2)

                row("porctransTAMIGO") = Math.Round((row("transTAMIGO") / row("total")) * 100, 2)

                row("porcvaletodo") = Math.Round((row("Transvaletodo") / row("total")) * 100, 2)


            Else
                'row("porc_tot") = 0
                row("porctransefectivo") = 0
                row("porctransvale") = 0
                row("porctranscontravale") = 0
                row("porctransdevventa") = 0
                row("porctranscredito") = 0
                row("porctransdebito") = 0
                row("porctranscheque") = 0
                row("porctransventaapa") = 0
                row("porctranscancapa") = 0
                row("porctransdescto") = 0
                row("porctransdevpromo") = 0
                row("porctransfonacot") = 0
                row("porctransgobcoa") = 0
                row("porctransdinele") = 0
                row("porctranspuntos") = 0
                row("porctransTAMIGO") = 0

                row("porctransvaletodo") = 0




            End If

            If row("importe") > 0 Then
                'row("porc_tot") = Math.Round((row("total") / row("total")) * 100, 2)
                row("porcefectivo") = Math.Round((row("efectivo") / row("importe")) * 100, 2)
                row("porcvale") = Math.Round((row("vale") / row("importe")) * 100, 2)
                row("porccontravale") = Math.Round((row("contravale") / row("importe")) * 100, 2)
                row("porcdevventa") = Math.Round((row("devventa") / row("importe")) * 100, 2)
                row("porccredito") = Math.Round((row("credito") / row("importe")) * 100, 2)
                row("porcdebito") = Math.Round((row("debito") / row("importe")) * 100, 2)
                row("porccheque") = Math.Round((row("cheque") / row("importe")) * 100, 2)
                row("porcventaapa") = Math.Round((row("ventaapa") / row("importe")) * 100, 2)
                row("porccancapa") = Math.Round((row("cancapa") / row("importe")) * 100, 2)
                row("porcdescto") = Math.Round((row("descto") / row("importe")) * 100, 2)
                row("porcdevpromo") = Math.Round((row("devpromo") / row("importe")) * 100, 2)
                row("porcfonacot") = Math.Round((row("fonacot") / row("importe")) * 100, 2)
                row("porcgobcoa") = Math.Round((row("gobcoa") / row("importe")) * 100, 2)
                row("porcdinele") = Math.Round((row("dinele") / row("importe")) * 100, 2)
                row("porcpuntos") = Math.Round((row("puntos") / row("importe")) * 100, 2)

                row("porcTAMIGO") = Math.Round((row("TAMIGO") / row("importe")) * 100, 2)
                row("porcvaletodo") = Math.Round((row("valetodo") / row("importe")) * 100, 2)

            Else
                'row("porc_tot") = 0
                row("porcefectivo") = 0
                row("porcvale") = 0
                row("porccontravale") = 0
                row("porcdevventa") = 0
                row("porccredito") = 0
                row("porcdebito") = 0
                row("porccheque") = 0
                row("porcventaapa") = 0
                row("porccancapa") = 0
                row("porcdescto") = 0
                row("porcdevpromo") = 0
                row("porcfonacot") = 0
                row("porcgobcoa") = 0
                row("porcdinele") = 0
                row("porcpuntos") = 0

                row("porcTAMIGO") = 0
                row("porcvaletodo") = 0
            End If

            dt.Rows.InsertAt(row, 0)
            DGrid.DataSource = dt

            DGrid.Columns("Sucursal").HeaderText = "Sucursal"
            DGrid.Columns("DescripSucursal").HeaderText = "Sucursal"
            DGrid.Columns("total").HeaderText = "Total"
            DGrid.Columns("porctrans").HeaderText = "%"
            DGrid.Columns("importe").HeaderText = "Importe C/IVA"
            DGrid.Columns("porcimporte").HeaderText = "%"
            DGrid.Columns("transefectivo").HeaderText = "Ope. Efectivo"
            DGrid.Columns("porctransefectivo").HeaderText = "%"
            DGrid.Columns("efectivo").HeaderText = "$ Efectivo C/IVA"
            DGrid.Columns("porcefectivo").HeaderText = "%"
            DGrid.Columns("transvale").HeaderText = "Ope. Vale"
            DGrid.Columns("porctransvale").HeaderText = "%"
            DGrid.Columns("vale").HeaderText = "$ Vale C/IVA"
            DGrid.Columns("porcvale").HeaderText = "%"
            DGrid.Columns("transcontravale").HeaderText = "Ope. ContraVale"
            DGrid.Columns("porctranscontravale").HeaderText = "%"
            DGrid.Columns("contravale").HeaderText = "$ ContraVale C/IVA"
            DGrid.Columns("porccontravale").HeaderText = "%"
            DGrid.Columns("transdevventa").HeaderText = "Ope. Dev/Vta"
            DGrid.Columns("porctransdevventa").HeaderText = "%"
            DGrid.Columns("devventa").HeaderText = "$ Dev/Vta C/IVA"
            DGrid.Columns("porcdevventa").HeaderText = "%"
            DGrid.Columns("transcredito").HeaderText = "Ope. Tarj. Credito"
            DGrid.Columns("porctranscredito").HeaderText = "%"
            DGrid.Columns("credito").HeaderText = "$ Tarj. Credito C/IVA"
            DGrid.Columns("porccredito").HeaderText = "%"
            DGrid.Columns("transdebito").HeaderText = "Ope. Tarj. Debito"
            DGrid.Columns("porctransdebito").HeaderText = "%"
            DGrid.Columns("debito").HeaderText = "$ Tarj. Debito C/IVA"
            DGrid.Columns("porcdebito").HeaderText = "%"
            DGrid.Columns("transcheque").HeaderText = "Ope. Cheque"
            DGrid.Columns("porctranscheque").HeaderText = "%"
            DGrid.Columns("cheque").HeaderText = "$ Cheque C/IVA"
            DGrid.Columns("porccheque").HeaderText = "%"
            DGrid.Columns("transventaapa").HeaderText = "Ope. Vta. Apa"
            DGrid.Columns("porctransventaapa").HeaderText = "%"
            DGrid.Columns("ventaapa").HeaderText = "$ Vta. Apa. C/IVA"
            DGrid.Columns("porcventaapa").HeaderText = "%"
            DGrid.Columns("transcancapa").HeaderText = "Ope. Canc. Apa"
            DGrid.Columns("porctranscancapa").HeaderText = "%"
            DGrid.Columns("cancapa").HeaderText = "$ Canc. Apa C/IVA"
            DGrid.Columns("porccancapa").HeaderText = "%"
            DGrid.Columns("transdescto").HeaderText = "Ope. Descto"
            DGrid.Columns("porctransdescto").HeaderText = "%"
            DGrid.Columns("descto").HeaderText = "$ Descto C/IVA"
            DGrid.Columns("porcdescto").HeaderText = "%"
            DGrid.Columns("transdevpromo").HeaderText = "Ope. Dev. Promo"
            DGrid.Columns("porctransdevpromo").HeaderText = "%"
            DGrid.Columns("devpromo").HeaderText = "$ Dev. Promo C/IVA"
            DGrid.Columns("porcdevpromo").HeaderText = "%"
            DGrid.Columns("transfonacot").HeaderText = "Ope. Fonacot"
            DGrid.Columns("porctransfonacot").HeaderText = "%"
            DGrid.Columns("fonacot").HeaderText = "$ Fonacot C/IVA"
            DGrid.Columns("porcfonacot").HeaderText = "%"
            DGrid.Columns("transgobcoa").HeaderText = "Ope. Gob Coah"
            DGrid.Columns("porctransgobcoa").HeaderText = "%"
            DGrid.Columns("gobcoa").HeaderText = "$ Gob Coah C/IVA"
            DGrid.Columns("porcgobcoa").HeaderText = "%"
            DGrid.Columns("transdinele").HeaderText = "Ope. Din. Ele."
            DGrid.Columns("porctransdinele").HeaderText = "%"
            DGrid.Columns("dinele").HeaderText = "$ Din. Ele. C/IVA"
            DGrid.Columns("porcdinele").HeaderText = "%"
            DGrid.Columns("transpuntos").HeaderText = "Ope. Puntos"
            DGrid.Columns("porctranspuntos").HeaderText = "%"
            DGrid.Columns("puntos").HeaderText = "$ Puntos C/IVA"
            DGrid.Columns("porcpuntos").HeaderText = "%"

            DGrid.Columns("TAMIGO").HeaderText = "$ T.Amigo C/IVA"
            DGrid.Columns("porcTAMIGO").HeaderText = "%"

            DGrid.Columns("VALETODO").HeaderText = "$ Vale Todo C/IVA"
            DGrid.Columns("porcVALETODO").HeaderText = "%"




            For i As Integer = 0 To DGrid.ColumnCount - 1
                DGrid.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next

            DGrid.Columns("importe").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGrid.Columns("efectivo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGrid.Columns("vale").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGrid.Columns("contravale").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGrid.Columns("devventa").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGrid.Columns("credito").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGrid.Columns("debito").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGrid.Columns("cheque").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGrid.Columns("ventaapa").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGrid.Columns("cancapa").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGrid.Columns("descto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGrid.Columns("devpromo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGrid.Columns("fonacot").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGrid.Columns("gobcoa").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGrid.Columns("dinele").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGrid.Columns("puntos").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGrid.Columns("tamigo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


            DGrid.Columns("valetodo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


            DGrid.RowHeadersVisible = False
            
            DGrid.Columns("importe").DefaultCellStyle.Format = "c"
            DGrid.Columns("efectivo").DefaultCellStyle.Format = "c"
            DGrid.Columns("vale").DefaultCellStyle.Format = "c"
            DGrid.Columns("contravale").DefaultCellStyle.Format = "c"
            DGrid.Columns("devventa").DefaultCellStyle.Format = "c"
            DGrid.Columns("credito").DefaultCellStyle.Format = "c"
            DGrid.Columns("debito").DefaultCellStyle.Format = "c"
            DGrid.Columns("cheque").DefaultCellStyle.Format = "c"
            DGrid.Columns("ventaapa").DefaultCellStyle.Format = "c"
            DGrid.Columns("cancapa").DefaultCellStyle.Format = "c"
            DGrid.Columns("descto").DefaultCellStyle.Format = "c"
            DGrid.Columns("devpromo").DefaultCellStyle.Format = "c"
            DGrid.Columns("fonacot").DefaultCellStyle.Format = "c"
            DGrid.Columns("gobcoa").DefaultCellStyle.Format = "c"
            DGrid.Columns("dinele").DefaultCellStyle.Format = "c"
            DGrid.Columns("puntos").DefaultCellStyle.Format = "c"
            DGrid.Columns("tamigo").DefaultCellStyle.Format = "c"
            DGrid.Columns("valetodo").DefaultCellStyle.Format = "c"

            
            DGrid.Columns("porctrans").DefaultCellStyle.Format = "#0.00"
            DGrid.Columns("porcimporte").DefaultCellStyle.Format = "#0.00"
            DGrid.Columns("porctransefectivo").DefaultCellStyle.Format = "#0.00"
            DGrid.Columns("porcefectivo").DefaultCellStyle.Format = "#0.00"
            DGrid.Columns("porctransvale").DefaultCellStyle.Format = "#0.00"
            DGrid.Columns("porcvale").DefaultCellStyle.Format = "#0.00"
            DGrid.Columns("porctranscontravale").DefaultCellStyle.Format = "#0.00"
            DGrid.Columns("porccontravale").DefaultCellStyle.Format = "#0.00"
            DGrid.Columns("porctransdevventa").DefaultCellStyle.Format = "#0.00"
            DGrid.Columns("porcdevventa").DefaultCellStyle.Format = "#0.00"
            DGrid.Columns("porctranscredito").DefaultCellStyle.Format = "#0.00"
            DGrid.Columns("porccredito").DefaultCellStyle.Format = "#0.00"
            DGrid.Columns("porctransdebito").DefaultCellStyle.Format = "#0.00"
            DGrid.Columns("porcdebito").DefaultCellStyle.Format = "#0.00"
            DGrid.Columns("porctranscheque").DefaultCellStyle.Format = "#0.00"
            DGrid.Columns("porccheque").DefaultCellStyle.Format = "#0.00"
            DGrid.Columns("porcdescto").DefaultCellStyle.Format = "#0.00"
            DGrid.Columns("porctamigo").DefaultCellStyle.Format = "#0.00"
            DGrid.Columns("porcvaletodo").DefaultCellStyle.Format = "#0.00"


            DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            DGrid.Columns("sucursal").Visible = False

            If blnPrimero = False Then
                DGrid.Rows(0).Frozen = True
                DGrid.Rows(0).DefaultCellStyle.BackColor = Color.PowderBlue
                DGrid.Rows(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Rows(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

                DGrid.Columns(1).Frozen = True
                DGrid.Columns(1).DefaultCellStyle.BackColor = Color.PowderBlue
                DGrid.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(1).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            End If
            OcultarMostrarColumnas()
            DGrid.Columns("total").Visible = False
            DGrid.Columns("porctrans").Visible = False
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Filtro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Filtro.Click
        Try
            myForm.DT_FecIni.Value = CDate(FecIniA)
            myForm.DT_FecFin.Value = CDate(FecIniB)
            myForm.ShowDialog()
            If myForm.Sw_Filtro = True Then
                FecIniA = myForm.DT_FecIni.Value.ToString("yyyy-MM-dd")
                FecIniB = myForm.DT_FecFin.Value.ToString("yyyy-MM-dd")
                Sucursal = myForm.Txt_Sucursal.Text.Trim
                RellenaGrid()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DGrid.MouseDown
        Try
            If e.Button = Windows.Forms.MouseButtons.Right Then
                With Me.DGrid
                    Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                    If Hitest.Type = DataGridViewHitTestType.Cell Then
                        .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                    End If
                End With
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub RB_Importes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RB_Importes.CheckedChanged
        Try
            If DGrid.DataSource Is Nothing Then Exit Sub
            If RB_Importes.Checked Then
                Importes = True
                Transacciones = False
                Ambas = False
                OcultarMostrarColumnas()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub RB_Transacciones_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RB_Transacciones.CheckedChanged
        Try
            If DGrid.DataSource Is Nothing Then Exit Sub
            If RB_Transacciones.Checked Then
                Importes = False
                Transacciones = True
                Ambas = False
                OcultarMostrarColumnas()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub RB_TranImportes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RB_TranImportes.CheckedChanged
        Try
            If DGrid.DataSource Is Nothing Then Exit Sub
            If RB_TranImportes.Checked Then
                Importes = False
                Transacciones = False
                Ambas = True
                OcultarMostrarColumnas()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub OcultarMostrarColumnas()
        Dim nombre As String = ""
        For i As Integer = 6 To DGrid.ColumnCount - 1
            nombre = DGrid.Columns(i).Name
            If Importes Then
                If nombre.ToUpper.Contains("TRANS") Then
                    DGrid.Columns(i).Visible = False
                Else
                    DGrid.Columns(i).Visible = True
                End If
            End If
            If Transacciones Then
                If nombre.ToUpper.Contains("TRANS") Then
                    DGrid.Columns(i).Visible = True
                Else
                    DGrid.Columns(i).Visible = False
                End If
            End If
            If Ambas Then
                DGrid.Columns(i).Visible = True
            End If
        Next
        If Importes Then
            DGrid.Columns("total").Visible = False
            DGrid.Columns("porctrans").Visible = False
            DGrid.Columns("importe").Visible = True
            DGrid.Columns("porcimporte").Visible = True
        End If
        If Transacciones Then
            DGrid.Columns("total").Visible = True
            DGrid.Columns("porctrans").Visible = True
            DGrid.Columns("importe").Visible = False
            DGrid.Columns("porcimporte").Visible = False
        End If
        If Ambas Then
            DGrid.Columns("total").Visible = True
            DGrid.Columns("porctrans").Visible = True
            DGrid.Columns("importe").Visible = True
            DGrid.Columns("porcimporte").Visible = True
        End If
        DGrid.Columns("transventaapa").Visible = False
        DGrid.Columns("porctransventaapa").Visible = False
        DGrid.Columns("ventaapa").Visible = False
        DGrid.Columns("porcventaapa").Visible = False
        DGrid.Columns("transcancapa").Visible = False
        DGrid.Columns("porctranscancapa").Visible = False
        DGrid.Columns("cancapa").Visible = False
        DGrid.Columns("porccancapa").Visible = False
        DGrid.Columns("transdevpromo").Visible = False
        DGrid.Columns("porctransdevpromo").Visible = False
        DGrid.Columns("devpromo").Visible = False
        DGrid.Columns("porcdevpromo").Visible = False
        DGrid.Columns("transfonacot").Visible = False
        DGrid.Columns("porctransfonacot").Visible = False
        DGrid.Columns("fonacot").Visible = False
        DGrid.Columns("porcfonacot").Visible = False
        DGrid.Columns("transgobcoa").Visible = False
        DGrid.Columns("porctransgobcoa").Visible = False
        DGrid.Columns("gobcoa").Visible = False
        DGrid.Columns("porcgobcoa").Visible = False
        DGrid.Columns("transdinele").Visible = False
        DGrid.Columns("porctransdinele").Visible = False
        DGrid.Columns("dinele").Visible = False
        DGrid.Columns("porcdinele").Visible = False
        DGrid.Columns("transpuntos").Visible = False
        DGrid.Columns("porctranspuntos").Visible = False
        DGrid.Columns("puntos").Visible = False
        DGrid.Columns("porcpuntos").Visible = False
        DGrid.Columns("total").Visible = False
        DGrid.Columns("porctrans").Visible = False
    End Sub

    Private Sub Btn_Excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Excel.Click
        Try
            If ExportarDGridAExcel(DGrid) = False Then
                MsgBox("Error al exportar a Excel. Intente nuevamente.", MsgBoxStyle.Critical, "Excel")
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Salir.Click
        Me.Close()
    End Sub

    Private Sub Chk_Sucursal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_Sucursal.CheckedChanged

        DGrid.Visible = False
        Call RellenaGrid()
        DGrid.Visible = True
    End Sub
End Class