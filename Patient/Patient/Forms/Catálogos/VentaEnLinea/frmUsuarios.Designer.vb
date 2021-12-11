<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUsuarios
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUsuarios))
        Me.Pnl_Datos = New System.Windows.Forms.Panel()
        Me.Txt_Confirmacion = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.Txt_Password = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.DTNacim = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.Txt_IdEmpleado = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.Txt_Nombre = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.Txt_UsuarioSistema = New DevExpress.XtraEditors.TextEdit()
        Me.Pnl_Botones = New System.Windows.Forms.Panel()
        Me.Btn_Accesorios = New DevExpress.XtraEditors.CheckButton()
        Me.Btn_Bebes = New DevExpress.XtraEditors.CheckButton()
        Me.Btn_Ninos = New DevExpress.XtraEditors.CheckButton()
        Me.Btn_Ninas = New DevExpress.XtraEditors.CheckButton()
        Me.Btn_Caballeros = New DevExpress.XtraEditors.CheckButton()
        Me.Btn_Damas = New DevExpress.XtraEditors.CheckButton()
        Me.Pnl_Editar = New System.Windows.Forms.Panel()
        Me.Btn_Cancelar = New DevExpress.XtraEditors.SimpleButton()
        Me.Btn_Aceptar = New DevExpress.XtraEditors.SimpleButton()
        Me.Pnl_Datos.SuspendLayout()
        CType(Me.Txt_Confirmacion.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_Password.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DTNacim.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DTNacim.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_IdEmpleado.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_Nombre.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_UsuarioSistema.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pnl_Botones.SuspendLayout()
        Me.Pnl_Editar.SuspendLayout()
        Me.SuspendLayout()
        '
        'Pnl_Datos
        '
        Me.Pnl_Datos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pnl_Datos.Controls.Add(Me.Txt_Confirmacion)
        Me.Pnl_Datos.Controls.Add(Me.LabelControl6)
        Me.Pnl_Datos.Controls.Add(Me.LabelControl5)
        Me.Pnl_Datos.Controls.Add(Me.Txt_Password)
        Me.Pnl_Datos.Controls.Add(Me.LabelControl4)
        Me.Pnl_Datos.Controls.Add(Me.DTNacim)
        Me.Pnl_Datos.Controls.Add(Me.LabelControl3)
        Me.Pnl_Datos.Controls.Add(Me.Txt_IdEmpleado)
        Me.Pnl_Datos.Controls.Add(Me.LabelControl2)
        Me.Pnl_Datos.Controls.Add(Me.Txt_Nombre)
        Me.Pnl_Datos.Controls.Add(Me.LabelControl1)
        Me.Pnl_Datos.Controls.Add(Me.Txt_UsuarioSistema)
        Me.Pnl_Datos.Location = New System.Drawing.Point(1, 1)
        Me.Pnl_Datos.Name = "Pnl_Datos"
        Me.Pnl_Datos.Size = New System.Drawing.Size(430, 217)
        Me.Pnl_Datos.TabIndex = 0
        '
        'Txt_Confirmacion
        '
        Me.Txt_Confirmacion.EnterMoveNextControl = True
        Me.Txt_Confirmacion.Location = New System.Drawing.Point(88, 163)
        Me.Txt_Confirmacion.Name = "Txt_Confirmacion"
        Me.Txt_Confirmacion.Properties.MaxLength = 10
        Me.Txt_Confirmacion.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.Txt_Confirmacion.Size = New System.Drawing.Size(100, 20)
        Me.Txt_Confirmacion.TabIndex = 5
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(24, 166)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(62, 13)
        Me.LabelControl6.TabIndex = 28
        Me.LabelControl6.Text = "Confirmación"
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(24, 140)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(46, 13)
        Me.LabelControl5.TabIndex = 26
        Me.LabelControl5.Text = "Password"
        '
        'Txt_Password
        '
        Me.Txt_Password.EditValue = ""
        Me.Txt_Password.EnterMoveNextControl = True
        Me.Txt_Password.Location = New System.Drawing.Point(88, 137)
        Me.Txt_Password.Name = "Txt_Password"
        Me.Txt_Password.Properties.MaxLength = 10
        Me.Txt_Password.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.Txt_Password.Size = New System.Drawing.Size(100, 20)
        Me.Txt_Password.TabIndex = 4
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(24, 83)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(52, 13)
        Me.LabelControl4.TabIndex = 24
        Me.LabelControl4.Text = "Nacimiento"
        '
        'DTNacim
        '
        Me.DTNacim.EditValue = Nothing
        Me.DTNacim.EnterMoveNextControl = True
        Me.DTNacim.Location = New System.Drawing.Point(88, 80)
        Me.DTNacim.Name = "DTNacim"
        Me.DTNacim.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DTNacim.Size = New System.Drawing.Size(148, 20)
        Me.DTNacim.TabIndex = 2
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(24, 31)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(59, 13)
        Me.LabelControl3.TabIndex = 5
        Me.LabelControl3.Text = "Id Empleado"
        '
        'Txt_IdEmpleado
        '
        Me.Txt_IdEmpleado.EnterMoveNextControl = True
        Me.Txt_IdEmpleado.Location = New System.Drawing.Point(88, 28)
        Me.Txt_IdEmpleado.Name = "Txt_IdEmpleado"
        Me.Txt_IdEmpleado.Size = New System.Drawing.Size(72, 20)
        Me.Txt_IdEmpleado.TabIndex = 0
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(24, 57)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(37, 13)
        Me.LabelControl2.TabIndex = 3
        Me.LabelControl2.Text = "Nombre"
        '
        'Txt_Nombre
        '
        Me.Txt_Nombre.EnterMoveNextControl = True
        Me.Txt_Nombre.Location = New System.Drawing.Point(88, 54)
        Me.Txt_Nombre.Name = "Txt_Nombre"
        Me.Txt_Nombre.Size = New System.Drawing.Size(304, 20)
        Me.Txt_Nombre.TabIndex = 1
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(24, 114)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(36, 13)
        Me.LabelControl1.TabIndex = 1
        Me.LabelControl1.Text = "Usuario"
        '
        'Txt_UsuarioSistema
        '
        Me.Txt_UsuarioSistema.EnterMoveNextControl = True
        Me.Txt_UsuarioSistema.Location = New System.Drawing.Point(88, 111)
        Me.Txt_UsuarioSistema.Name = "Txt_UsuarioSistema"
        Me.Txt_UsuarioSistema.Size = New System.Drawing.Size(100, 20)
        Me.Txt_UsuarioSistema.TabIndex = 3
        '
        'Pnl_Botones
        '
        Me.Pnl_Botones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pnl_Botones.Controls.Add(Me.Btn_Accesorios)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Bebes)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Ninos)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Ninas)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Caballeros)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Damas)
        Me.Pnl_Botones.Location = New System.Drawing.Point(1, 224)
        Me.Pnl_Botones.Name = "Pnl_Botones"
        Me.Pnl_Botones.Size = New System.Drawing.Size(430, 117)
        Me.Pnl_Botones.TabIndex = 1
        '
        'Btn_Accesorios
        '
        Me.Btn_Accesorios.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.Btn_Accesorios.Image = Global.SIRCO.My.Resources.Resources.cap__1_
        Me.Btn_Accesorios.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopRight
        Me.Btn_Accesorios.Location = New System.Drawing.Point(349, 24)
        Me.Btn_Accesorios.Name = "Btn_Accesorios"
        Me.Btn_Accesorios.Size = New System.Drawing.Size(59, 68)
        Me.Btn_Accesorios.TabIndex = 11
        Me.Btn_Accesorios.Text = "Accesorios"
        '
        'Btn_Bebes
        '
        Me.Btn_Bebes.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.Btn_Bebes.Image = Global.SIRCO.My.Resources.Resources.baby_feet
        Me.Btn_Bebes.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopRight
        Me.Btn_Bebes.Location = New System.Drawing.Point(284, 24)
        Me.Btn_Bebes.Name = "Btn_Bebes"
        Me.Btn_Bebes.Size = New System.Drawing.Size(59, 68)
        Me.Btn_Bebes.TabIndex = 10
        Me.Btn_Bebes.Text = "Bebes"
        '
        'Btn_Ninos
        '
        Me.Btn_Ninos.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.Btn_Ninos.Image = Global.SIRCO.My.Resources.Resources.buckle_shoe
        Me.Btn_Ninos.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopRight
        Me.Btn_Ninos.Location = New System.Drawing.Point(219, 24)
        Me.Btn_Ninos.Name = "Btn_Ninos"
        Me.Btn_Ninos.Size = New System.Drawing.Size(59, 68)
        Me.Btn_Ninos.TabIndex = 9
        Me.Btn_Ninos.Text = "Niños"
        '
        'Btn_Ninas
        '
        Me.Btn_Ninas.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.Btn_Ninas.Image = Global.SIRCO.My.Resources.Resources.shoe
        Me.Btn_Ninas.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopRight
        Me.Btn_Ninas.Location = New System.Drawing.Point(154, 24)
        Me.Btn_Ninas.Name = "Btn_Ninas"
        Me.Btn_Ninas.Size = New System.Drawing.Size(59, 68)
        Me.Btn_Ninas.TabIndex = 8
        Me.Btn_Ninas.Text = "Niñas"
        '
        'Btn_Caballeros
        '
        Me.Btn_Caballeros.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.Btn_Caballeros.Image = Global.SIRCO.My.Resources.Resources.gucci_shoe__2_
        Me.Btn_Caballeros.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopRight
        Me.Btn_Caballeros.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Btn_Caballeros.Location = New System.Drawing.Point(89, 24)
        Me.Btn_Caballeros.Name = "Btn_Caballeros"
        Me.Btn_Caballeros.Size = New System.Drawing.Size(59, 68)
        Me.Btn_Caballeros.TabIndex = 7
        Me.Btn_Caballeros.Text = "Caballeros"
        '
        'Btn_Damas
        '
        Me.Btn_Damas.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.Btn_Damas.Image = Global.SIRCO.My.Resources.Resources.shoe__1_
        Me.Btn_Damas.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopRight
        Me.Btn_Damas.Location = New System.Drawing.Point(24, 24)
        Me.Btn_Damas.Name = "Btn_Damas"
        Me.Btn_Damas.Size = New System.Drawing.Size(59, 68)
        Me.Btn_Damas.TabIndex = 6
        Me.Btn_Damas.Text = "Damas"
        '
        'Pnl_Editar
        '
        Me.Pnl_Editar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pnl_Editar.Controls.Add(Me.Btn_Cancelar)
        Me.Pnl_Editar.Controls.Add(Me.Btn_Aceptar)
        Me.Pnl_Editar.Location = New System.Drawing.Point(1, 347)
        Me.Pnl_Editar.Name = "Pnl_Editar"
        Me.Pnl_Editar.Size = New System.Drawing.Size(430, 70)
        Me.Pnl_Editar.TabIndex = 2
        '
        'Btn_Cancelar
        '
        Me.Btn_Cancelar.Image = Global.SIRCO.My.Resources.Resources.cancel1
        Me.Btn_Cancelar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.Btn_Cancelar.Location = New System.Drawing.Point(303, 3)
        Me.Btn_Cancelar.Name = "Btn_Cancelar"
        Me.Btn_Cancelar.Size = New System.Drawing.Size(50, 55)
        Me.Btn_Cancelar.TabIndex = 12
        '
        'Btn_Aceptar
        '
        Me.Btn_Aceptar.Image = Global.SIRCO.My.Resources.Resources.OK
        Me.Btn_Aceptar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.Btn_Aceptar.Location = New System.Drawing.Point(359, 3)
        Me.Btn_Aceptar.Name = "Btn_Aceptar"
        Me.Btn_Aceptar.Size = New System.Drawing.Size(50, 55)
        Me.Btn_Aceptar.TabIndex = 11
        '
        'frmUsuarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(436, 419)
        Me.Controls.Add(Me.Pnl_Editar)
        Me.Controls.Add(Me.Pnl_Botones)
        Me.Controls.Add(Me.Pnl_Datos)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmUsuarios"
        Me.Text = "Usuarios"
        Me.Pnl_Datos.ResumeLayout(False)
        Me.Pnl_Datos.PerformLayout()
        CType(Me.Txt_Confirmacion.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_Password.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DTNacim.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DTNacim.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_IdEmpleado.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_Nombre.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_UsuarioSistema.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pnl_Botones.ResumeLayout(False)
        Me.Pnl_Editar.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Pnl_Datos As Panel
    Friend WithEvents Pnl_Botones As Panel
    Friend WithEvents Pnl_Editar As Panel
    Friend WithEvents Btn_Aceptar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Btn_Cancelar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Txt_UsuarioSistema As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Txt_IdEmpleado As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Txt_Nombre As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DTNacim As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Btn_Damas As DevExpress.XtraEditors.CheckButton
    Friend WithEvents Btn_Bebes As DevExpress.XtraEditors.CheckButton
    Friend WithEvents Btn_Ninos As DevExpress.XtraEditors.CheckButton
    Friend WithEvents Btn_Ninas As DevExpress.XtraEditors.CheckButton
    Friend WithEvents Btn_Caballeros As DevExpress.XtraEditors.CheckButton
    Friend WithEvents Txt_Confirmacion As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Txt_Password As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Btn_Accesorios As DevExpress.XtraEditors.CheckButton
End Class
