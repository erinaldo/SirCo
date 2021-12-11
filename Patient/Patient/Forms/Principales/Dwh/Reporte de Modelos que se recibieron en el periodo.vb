Namespace SIRCO
    Public Class ReportedeModelosqueserecibieronenelperiodo
        Inherits DevExpress.XtraReports.UI.XtraReport

        Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
        Friend WithEvents table1 As DevExpress.XtraReports.UI.XRTable
        Friend WithEvents tableRow1 As DevExpress.XtraReports.UI.XRTableRow
        Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents table2 As DevExpress.XtraReports.UI.XRTable
        Friend WithEvents tableRow2 As DevExpress.XtraReports.UI.XRTableRow
        Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
        Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
        Friend WithEvents ReportHeaderBandStyle As DevExpress.XtraReports.UI.XRControlStyle
        Friend WithEvents ReportGroupHeaderBandStyle As DevExpress.XtraReports.UI.XRControlStyle
        Friend WithEvents ReportDetailBandStyle As DevExpress.XtraReports.UI.XRControlStyle
        Friend WithEvents ReportGroupFooterBandStyle As DevExpress.XtraReports.UI.XRControlStyle
        Friend WithEvents ReportFooterBandStyle As DevExpress.XtraReports.UI.XRControlStyle
        Friend WithEvents ReportOddStyle As DevExpress.XtraReports.UI.XRControlStyle
        Friend WithEvents ReportEvenStyle As DevExpress.XtraReports.UI.XRControlStyle

        Private Sub InitializeComponent()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.table1 = New DevExpress.XtraReports.UI.XRTable()
            Me.tableRow1 = New DevExpress.XtraReports.UI.XRTableRow()
            Me.table2 = New DevExpress.XtraReports.UI.XRTable()
            Me.tableRow2 = New DevExpress.XtraReports.UI.XRTableRow()
            Me.ReportHeaderBandStyle = New DevExpress.XtraReports.UI.XRControlStyle()
            Me.ReportGroupHeaderBandStyle = New DevExpress.XtraReports.UI.XRControlStyle()
            Me.ReportDetailBandStyle = New DevExpress.XtraReports.UI.XRControlStyle()
            Me.ReportGroupFooterBandStyle = New DevExpress.XtraReports.UI.XRControlStyle()
            Me.ReportFooterBandStyle = New DevExpress.XtraReports.UI.XRControlStyle()
            Me.ReportOddStyle = New DevExpress.XtraReports.UI.XRControlStyle()
            Me.ReportEvenStyle = New DevExpress.XtraReports.UI.XRControlStyle()
            CType(Me.table1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.table2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'TopMargin
            '
            Me.TopMargin.Dpi = 254.0!
            Me.TopMargin.Name = "TopMargin"
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.table1})
            Me.PageHeader.Dpi = 254.0!
            Me.PageHeader.HeightF = 64.0!
            Me.PageHeader.Name = "PageHeader"
            Me.PageHeader.StyleName = "ReportHeaderBandStyle"
            '
            'Detail
            '
            Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.table2})
            Me.Detail.Dpi = 254.0!
            Me.Detail.EvenStyleName = "ReportEvenStyle"
            Me.Detail.HeightF = 64.0!
            Me.Detail.Name = "Detail"
            Me.Detail.OddStyleName = "ReportOddStyle"
            Me.Detail.StyleName = "ReportDetailBandStyle"
            '
            'ReportFooter
            '
            Me.ReportFooter.Dpi = 254.0!
            Me.ReportFooter.HeightF = 0!
            Me.ReportFooter.Name = "ReportFooter"
            '
            'BottomMargin
            '
            Me.BottomMargin.Dpi = 254.0!
            Me.BottomMargin.Name = "BottomMargin"
            '
            'table1
            '
            Me.table1.Dpi = 254.0!
            Me.table1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.table1.Name = "table1"
            Me.table1.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.tableRow1})
            Me.table1.SizeF = New System.Drawing.SizeF(5.0!, 64.0!)
            '
            'tableRow1
            '
            Me.tableRow1.Dpi = 254.0!
            Me.tableRow1.Name = "tableRow1"
            Me.tableRow1.Weight = 10.46953028649871R
            '
            'table2
            '
            Me.table2.Dpi = 254.0!
            Me.table2.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.table2.Name = "table2"
            Me.table2.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.tableRow2})
            Me.table2.SizeF = New System.Drawing.SizeF(5.0!, 64.0!)
            '
            'tableRow2
            '
            Me.tableRow2.Dpi = 254.0!
            Me.tableRow2.Name = "tableRow2"
            Me.tableRow2.Weight = 10.46953028649871R
            '
            'ReportHeaderBandStyle
            '
            Me.ReportHeaderBandStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(206, Byte), Integer), CType(CType(206, Byte), Integer), CType(CType(206, Byte), Integer))
            Me.ReportHeaderBandStyle.Name = "ReportHeaderBandStyle"
            Me.ReportHeaderBandStyle.Padding = New DevExpress.XtraPrinting.PaddingInfo(4, 4, 0, 0, 100.0!)
            Me.ReportHeaderBandStyle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '
            'ReportGroupHeaderBandStyle
            '
            Me.ReportGroupHeaderBandStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(206, Byte), Integer), CType(CType(206, Byte), Integer), CType(CType(206, Byte), Integer))
            Me.ReportGroupHeaderBandStyle.Name = "ReportGroupHeaderBandStyle"
            Me.ReportGroupHeaderBandStyle.Padding = New DevExpress.XtraPrinting.PaddingInfo(4, 0, 0, 0, 100.0!)
            Me.ReportGroupHeaderBandStyle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '
            'ReportDetailBandStyle
            '
            Me.ReportDetailBandStyle.BackColor = System.Drawing.Color.Transparent
            Me.ReportDetailBandStyle.Name = "ReportDetailBandStyle"
            Me.ReportDetailBandStyle.Padding = New DevExpress.XtraPrinting.PaddingInfo(4, 4, 0, 0, 100.0!)
            Me.ReportDetailBandStyle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '
            'ReportGroupFooterBandStyle
            '
            Me.ReportGroupFooterBandStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(206, Byte), Integer), CType(CType(206, Byte), Integer), CType(CType(206, Byte), Integer))
            Me.ReportGroupFooterBandStyle.Name = "ReportGroupFooterBandStyle"
            Me.ReportGroupFooterBandStyle.Padding = New DevExpress.XtraPrinting.PaddingInfo(4, 4, 0, 0, 100.0!)
            Me.ReportGroupFooterBandStyle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '
            'ReportFooterBandStyle
            '
            Me.ReportFooterBandStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(206, Byte), Integer), CType(CType(206, Byte), Integer), CType(CType(206, Byte), Integer))
            Me.ReportFooterBandStyle.Name = "ReportFooterBandStyle"
            Me.ReportFooterBandStyle.Padding = New DevExpress.XtraPrinting.PaddingInfo(4, 4, 0, 0, 100.0!)
            Me.ReportFooterBandStyle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '
            'ReportOddStyle
            '
            Me.ReportOddStyle.BackColor = System.Drawing.Color.Transparent
            Me.ReportOddStyle.Name = "ReportOddStyle"
            Me.ReportOddStyle.Padding = New DevExpress.XtraPrinting.PaddingInfo(4, 4, 0, 0, 100.0!)
            Me.ReportOddStyle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '
            'ReportEvenStyle
            '
            Me.ReportEvenStyle.BackColor = System.Drawing.Color.Transparent
            Me.ReportEvenStyle.Name = "ReportEvenStyle"
            Me.ReportEvenStyle.Padding = New DevExpress.XtraPrinting.PaddingInfo(4, 4, 0, 0, 100.0!)
            Me.ReportEvenStyle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '
            'ReportedeModelosqueserecibieronenelperiodo
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.TopMargin, Me.PageHeader, Me.Detail, Me.ReportFooter, Me.BottomMargin})
            Me.Dpi = 254.0!
            Me.Margins = New System.Drawing.Printing.Margins(254, 254, 100, 100)
            Me.PageHeight = 2970
            Me.PageWidth = 2100
            Me.PaperKind = System.Drawing.Printing.PaperKind.A4
            Me.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter
            Me.SnapGridSize = 25.0!
            Me.StyleSheet.AddRange(New DevExpress.XtraReports.UI.XRControlStyle() {Me.ReportHeaderBandStyle, Me.ReportGroupHeaderBandStyle, Me.ReportDetailBandStyle, Me.ReportGroupFooterBandStyle, Me.ReportFooterBandStyle, Me.ReportOddStyle, Me.ReportEvenStyle})
            Me.Version = "18.2"
            CType(Me.table1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.table2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
    End Class
End Namespace
