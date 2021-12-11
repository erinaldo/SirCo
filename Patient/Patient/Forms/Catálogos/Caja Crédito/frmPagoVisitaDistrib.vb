Public Class frmPagoVisitaDistrib
    Private objDataSet As Data.DataSet
    Dim Sw_NoRegistros As Boolean = False
    Dim Sw_Pintar As Boolean = False
    Dim Sw_Load As Boolean = True
    Public accion As Integer = 0
    Public abono As Boolean = False
    Public impabono As Double
    Public cantidad As Double = 0
    'Friend WithEvents Pnl_Botones As System.Windows.Forms.Panel
    Friend WithEvents Btn_Imprimir As System.Windows.Forms.Button
    'Friend WithEvents Btn_Cancelar As System.Windows.Forms.Button
    'Friend WithEvents Btn_Aceptar As System.Windows.Forms.Button
    Friend WithEvents DGrid As System.Windows.Forms.DataGridView
    Dim importe As Double = 0
    
    Private Sub frmCatalogoVisitaDistrib_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub
    Private Sub Edicion()
        Try
            If abono = True Then
                accion = 3

            End If
            Select Case accion
                Case 3, 4
                    Btn_Aceptar.Enabled = False
                    Btn_Cancelar.Enabled = True
                    Panel1.Enabled = False
                    Panel2.Enabled = False
                Case 1, 2
                    Btn_Aceptar.Enabled = True
                    Btn_Cancelar.Enabled = True
                    Panel2.Enabled = True
                    If accion = 1 Then
                        txt_nombre.Focus()
                        Application.DoEvents()
                    ElseIf accion = 2 Then
                        txt_nombre.Focus()
                        txt_nombre.Focus()
                    End If
            End Select
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub GenerarToolTip()
        Try
            ToolTip.SetToolTip(Btn_Aceptar, "Aceptar la acción requerida por el usuario")
            ToolTip.SetToolTip(Btn_Cancelar, "Cancelar cualquier acción requerida por el usuario")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub frmCatalogoVisitaDistrib_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Left = (Screen.PrimaryScreen.WorkingArea.Width - Me.Width) / 2
        Me.Top = (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) / 2
        Call Edicion()
    End Sub
    Private Sub Btn_Aceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click
        Try
           
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub
    Private Sub Btn_Cancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_Cancelar.Click
        Try
            If accion = 1 Or accion = 2 Then
                If MessageBox.Show("Estas seguro de cancelar el registro ?", "Confirmar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
                    'Me.Dispose()
                    Me.Close()
                End If
            Else
                Me.Close()
                Me.Dispose()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub txt_resultado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txt_importe_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_importe.KeyPress
        pub_SoloNumeros(sender, e)
    End Sub
    Private Sub txt_impXcobrar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        pub_SoloNumeros(sender, e)
    End Sub
    Private Sub Cbo_VisitoAval_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = True
    End Sub
    Private Sub txt_importe_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_importe.LostFocus

        If txt_importe.Text = "" Then
            txt_importe.Text = 0
            importe = txt_importe.Text
            txt_importe.Text = Format(importe, "$###,##0.00")
        End If
        importe = txt_importe.Text
        txt_importe.Text = Format(importe, "$###,##0.00")
    End Sub

    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.Pnl_Botones = New System.Windows.Forms.Panel
        Me.Btn_Cancelar = New System.Windows.Forms.Button
        Me.Btn_Aceptar = New System.Windows.Forms.Button
        Me.txt_nombre = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_id = New System.Windows.Forms.TextBox
        Me.txt_nomDistrib = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_Distrib = New System.Windows.Forms.TextBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Txt_Ruta = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Txt_DescripRuta = New System.Windows.Forms.TextBox
        Me.DTPicker1 = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txt_importe = New System.Windows.Forms.TextBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.txt_folio = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.Pnl_Botones.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Pnl_Botones
        '
        Me.Pnl_Botones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Botones.Controls.Add(Me.Btn_Cancelar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Aceptar)
        Me.Pnl_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pnl_Botones.Location = New System.Drawing.Point(0, 286)
        Me.Pnl_Botones.Name = "Pnl_Botones"
        Me.Pnl_Botones.Size = New System.Drawing.Size(564, 56)
        Me.Pnl_Botones.TabIndex = 8
        '
        'Btn_Cancelar
        '
        Me.Btn_Cancelar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Cancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Cancelar.Image = Global.SIRCO.My.Resources.Resources.dialog_close
        Me.Btn_Cancelar.Location = New System.Drawing.Point(458, 0)
        Me.Btn_Cancelar.Name = "Btn_Cancelar"
        Me.Btn_Cancelar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Cancelar.TabIndex = 51
        Me.Btn_Cancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Cancelar.UseVisualStyleBackColor = True
        '
        'Btn_Aceptar
        '
        Me.Btn_Aceptar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Aceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Aceptar.Image = Global.SIRCO.My.Resources.Resources.OK
        Me.Btn_Aceptar.Location = New System.Drawing.Point(509, 0)
        Me.Btn_Aceptar.Name = "Btn_Aceptar"
        Me.Btn_Aceptar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Aceptar.TabIndex = 50
        Me.Btn_Aceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Aceptar.UseVisualStyleBackColor = True
        '
        'txt_nombre
        '
        Me.txt_nombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nombre.Location = New System.Drawing.Point(179, 39)
        Me.txt_nombre.Name = "txt_nombre"
        Me.txt_nombre.Size = New System.Drawing.Size(305, 20)
        Me.txt_nombre.TabIndex = 124
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 13)
        Me.Label1.TabIndex = 125
        Me.Label1.Text = "Cobrador/Gestor"
        '
        'txt_id
        '
        Me.txt_id.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_id.Location = New System.Drawing.Point(105, 39)
        Me.txt_id.Name = "txt_id"
        Me.txt_id.Size = New System.Drawing.Size(68, 20)
        Me.txt_id.TabIndex = 123
        '
        'txt_nomDistrib
        '
        Me.txt_nomDistrib.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nomDistrib.Location = New System.Drawing.Point(179, 72)
        Me.txt_nomDistrib.Name = "txt_nomDistrib"
        Me.txt_nomDistrib.Size = New System.Drawing.Size(305, 20)
        Me.txt_nomDistrib.TabIndex = 127
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 13)
        Me.Label2.TabIndex = 128
        Me.Label2.Text = "Distribuidor"
        '
        'txt_Distrib
        '
        Me.txt_Distrib.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Distrib.Location = New System.Drawing.Point(105, 72)
        Me.txt_Distrib.Name = "txt_Distrib"
        Me.txt_Distrib.Size = New System.Drawing.Size(68, 20)
        Me.txt_Distrib.TabIndex = 126
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.Controls.Add(Me.Txt_Ruta)
        Me.Panel1.Controls.Add(Me.txt_nomDistrib)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.Txt_DescripRuta)
        Me.Panel1.Controls.Add(Me.txt_id)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txt_Distrib)
        Me.Panel1.Controls.Add(Me.txt_nombre)
        Me.Panel1.Enabled = False
        Me.Panel1.Location = New System.Drawing.Point(27, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(509, 120)
        Me.Panel1.TabIndex = 129
        '
        'Txt_Ruta
        '
        Me.Txt_Ruta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Ruta.Location = New System.Drawing.Point(105, 11)
        Me.Txt_Ruta.Name = "Txt_Ruta"
        Me.Txt_Ruta.Size = New System.Drawing.Size(68, 20)
        Me.Txt_Ruta.TabIndex = 146
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(13, 14)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(30, 13)
        Me.Label11.TabIndex = 148
        Me.Label11.Text = "Ruta"
        '
        'Txt_DescripRuta
        '
        Me.Txt_DescripRuta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_DescripRuta.Location = New System.Drawing.Point(179, 11)
        Me.Txt_DescripRuta.Name = "Txt_DescripRuta"
        Me.Txt_DescripRuta.Size = New System.Drawing.Size(305, 20)
        Me.Txt_DescripRuta.TabIndex = 147
        '
        'DTPicker1
        '
        Me.DTPicker1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPicker1.Location = New System.Drawing.Point(123, 12)
        Me.DTPicker1.Name = "DTPicker1"
        Me.DTPicker1.Size = New System.Drawing.Size(238, 20)
        Me.DTPicker1.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(13, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 13)
        Me.Label3.TabIndex = 129
        Me.Label3.Text = "Fecha de Pago"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(16, 107)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(85, 13)
        Me.Label8.TabIndex = 139
        Me.Label8.Text = "Importe Cobrado"
        Me.Label8.Visible = False
        '
        'txt_importe
        '
        Me.txt_importe.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_importe.Location = New System.Drawing.Point(123, 107)
        Me.txt_importe.Name = "txt_importe"
        Me.txt_importe.Size = New System.Drawing.Size(89, 22)
        Me.txt_importe.TabIndex = 5
        Me.txt_importe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txt_importe.Visible = False
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.txt_folio)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.txt_importe)
        Me.Panel2.Controls.Add(Me.DTPicker1)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Location = New System.Drawing.Point(0, 131)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(564, 148)
        Me.Panel2.TabIndex = 145
        '
        'txt_folio
        '
        Me.txt_folio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_folio.Location = New System.Drawing.Point(123, 58)
        Me.txt_folio.Name = "txt_folio"
        Me.txt_folio.Size = New System.Drawing.Size(89, 22)
        Me.txt_folio.TabIndex = 3
        Me.txt_folio.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(16, 58)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(90, 13)
        Me.Label10.TabIndex = 145
        Me.Label10.Text = "No. Folio Manual:"
        Me.Label10.Visible = False
        '
        'ToolTip
        '
        Me.ToolTip.IsBalloon = True
        '
        'frmPagoVisitaDistrib
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(564, 342)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Pnl_Botones)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmPagoVisitaDistrib"
        Me.Text = "Pago de Gestoría"
        Me.Pnl_Botones.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    'Private Sub InitializeComponent()
    '    Me.Pnl_Botones = New System.Windows.Forms.Panel
    '    Me.Btn_Imprimir = New System.Windows.Forms.Button
    '    Me.Btn_Cancelar = New System.Windows.Forms.Button
    '    Me.Btn_Aceptar = New System.Windows.Forms.Button
    '    Me.DGrid = New System.Windows.Forms.DataGridView
    '    Me.Pnl_Botones.SuspendLayout()
    '    CType(Me.DGrid, System.ComponentModel.ISupportInitialize).BeginInit()
    '    Me.SuspendLayout()
    '    '
    '    'Pnl_Botones
    '    '
    '    Me.Pnl_Botones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    '    Me.Pnl_Botones.Controls.Add(Me.Btn_Imprimir)
    '    Me.Pnl_Botones.Controls.Add(Me.Btn_Cancelar)
    '    Me.Pnl_Botones.Controls.Add(Me.Btn_Aceptar)
    '    Me.Pnl_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
    '    Me.Pnl_Botones.Location = New System.Drawing.Point(0, 278)
    '    Me.Pnl_Botones.Name = "Pnl_Botones"
    '    Me.Pnl_Botones.Size = New System.Drawing.Size(338, 52)
    '    Me.Pnl_Botones.TabIndex = 16
    '    '
    '    'Btn_Imprimir
    '    '
    '    Me.Btn_Imprimir.Dock = System.Windows.Forms.DockStyle.Right
    '    Me.Btn_Imprimir.Enabled = False
    '    Me.Btn_Imprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    '    Me.Btn_Imprimir.Image = Global.SIRCO.My.Resources.Resources.document_print
    '    Me.Btn_Imprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
    '    Me.Btn_Imprimir.Location = New System.Drawing.Point(181, 0)
    '    Me.Btn_Imprimir.Name = "Btn_Imprimir"
    '    Me.Btn_Imprimir.Size = New System.Drawing.Size(51, 48)
    '    Me.Btn_Imprimir.TabIndex = 56
    '    Me.Btn_Imprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    '    Me.Btn_Imprimir.UseVisualStyleBackColor = True
    '    Me.Btn_Imprimir.Visible = False
    '    '
    '    'Btn_Cancelar
    '    '
    '    Me.Btn_Cancelar.Dock = System.Windows.Forms.DockStyle.Right
    '    Me.Btn_Cancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    '    Me.Btn_Cancelar.Image = Global.SIRCO.My.Resources.Resources.dialog_close
    '    Me.Btn_Cancelar.Location = New System.Drawing.Point(232, 0)
    '    Me.Btn_Cancelar.Name = "Btn_Cancelar"
    '    Me.Btn_Cancelar.Size = New System.Drawing.Size(51, 48)
    '    Me.Btn_Cancelar.TabIndex = 52
    '    Me.Btn_Cancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    '    Me.Btn_Cancelar.UseVisualStyleBackColor = True
    '    '
    '    'Btn_Aceptar
    '    '
    '    Me.Btn_Aceptar.Dock = System.Windows.Forms.DockStyle.Right
    '    Me.Btn_Aceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    '    Me.Btn_Aceptar.Image = Global.SIRCO.My.Resources.Resources.OK
    '    Me.Btn_Aceptar.Location = New System.Drawing.Point(283, 0)
    '    Me.Btn_Aceptar.Name = "Btn_Aceptar"
    '    Me.Btn_Aceptar.Size = New System.Drawing.Size(51, 48)
    '    Me.Btn_Aceptar.TabIndex = 51
    '    Me.Btn_Aceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    '    Me.Btn_Aceptar.UseVisualStyleBackColor = True
    '    '
    '    'DGrid
    '    '
    '    Me.DGrid.AllowUserToAddRows = False
    '    Me.DGrid.AllowUserToDeleteRows = False
    '    Me.DGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    '    Me.DGrid.Dock = System.Windows.Forms.DockStyle.Fill
    '    Me.DGrid.Location = New System.Drawing.Point(0, 0)
    '    Me.DGrid.Name = "DGrid"
    '    Me.DGrid.ReadOnly = True
    '    Me.DGrid.Size = New System.Drawing.Size(338, 278)
    '    Me.DGrid.TabIndex = 17
    '    '
    '    'frmCatalogoVisitaDistrib
    '    '
    '    Me.ClientSize = New System.Drawing.Size(338, 330)
    '    Me.Controls.Add(Me.DGrid)
    '    Me.Controls.Add(Me.Pnl_Botones)
    '    Me.Name = "frmCatalogoVisitaDistrib"
    '    Me.Pnl_Botones.ResumeLayout(False)
    '    CType(Me.DGrid, System.ComponentModel.ISupportInitialize).EndInit()
    '    Me.ResumeLayout(False)

    'End Sub

    Private Sub Panel2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub
End Class