﻿'------------------------------------------------------------------------------
' <auto-generated>
'     Este código fue generado por una herramienta.
'     Versión de runtime:4.0.30319.42000
'
'     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
'     se vuelve a generar el código.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Namespace My
    
    <Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.6.0.0"),  _
     Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
    Partial Friend NotInheritable Class MySettings
        Inherits Global.System.Configuration.ApplicationSettingsBase
        
        Private Shared defaultInstance As MySettings = CType(Global.System.Configuration.ApplicationSettingsBase.Synchronized(New MySettings()),MySettings)
        
#Region "Funcionalidad para autoguardar My.Settings"
#If _MyType = "WindowsForms" Then
    Private Shared addedHandler As Boolean

    Private Shared addedHandlerLockObject As New Object

    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)> _
    Private Shared Sub AutoSaveSettings(sender As Global.System.Object, e As Global.System.EventArgs)
        If My.Application.SaveMySettingsOnExit Then
            My.Settings.Save()
        End If
    End Sub
#End If
#End Region
        
        Public Shared ReadOnly Property [Default]() As MySettings
            Get
                
#If _MyType = "WindowsForms" Then
               If Not addedHandler Then
                    SyncLock addedHandlerLockObject
                        If Not addedHandler Then
                            AddHandler My.Application.Shutdown, AddressOf AutoSaveSettings
                            addedHandler = True
                        End If
                    End SyncLock
                End If
#End If
                Return defaultInstance
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Data Source=SERVIDORZT\SQLSERVER2005;Initial Catalog=bonos;Persist Security Info="& _ 
            "True;User ID=bonos;Password=probono")>  _
        Public ReadOnly Property ConnectionStringBonos() As String
            Get
                Return CType(Me("ConnectionStringBonos"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Driver={MySQL ODBC 5.1 Driver};server=10.10.1.1;uid=root;pwd=z4pt0r;database=carg"& _ 
            "anomina;port=3306;no_bigint=1")>  _
        Public ReadOnly Property ConnectionStringNomSis() As String
            Get
                Return CType(Me("ConnectionStringNomSis"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Driver={MySQL ODBC 5.1 Driver};server=10.10.1.1;uid=root;pwd=z4pt0r;database=crvs"& _ 
            "is;port=3306;no_bigint=1")>  _
        Public ReadOnly Property ConnectionStringCrvSis() As String
            Get
                Return CType(Me("ConnectionStringCrvSis"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Driver={MySQL ODBC 5.1 Driver};server=10.10.1.1;uid=root;pwd=z4pt0r;database=pers"& _ 
            "is;port=3306;no_bigint=1")>  _
        Public ReadOnly Property ConnectionStringPerSis() As String
            Get
                Return CType(Me("ConnectionStringPerSis"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Driver={MySQL ODBC 5.1 Driver};server=10.10.1.1;uid=root;pwd=z4pt0r;database=cips"& _ 
            "is;port=3306;no_bigint=1")>  _
        Public ReadOnly Property ConnectionStringCipsis() As String
            Get
                Return CType(Me("ConnectionStringCipsis"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Driver={MySQL ODBC 5.1 Driver};server=10.10.1.1;uid=root;pwd=z4pt0r;database=cips"& _ 
            "is;port=3306;no_bigint=1")>  _
        Public ReadOnly Property ConnectionStringCipsisRpt() As String
            Get
                Return CType(Me("ConnectionStringCipsisRpt"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Driver={MySQL ODBC 5.1 Driver};server=10.10.1.1;uid=root;pwd=z4pt0r;database=dwh;"& _ 
            "port=3306;no_bigint=1")>  _
        Public ReadOnly Property ConnectionStringDwh() As String
            Get
                Return CType(Me("ConnectionStringDwh"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Driver={MySQL ODBC 5.1 Driver};server=10.10.1.1;uid=root;pwd=z4pt0r;database=crvs"& _ 
            "is;port=3306;no_bigint=1")>  _
        Public ReadOnly Property ConnectionStringCrvSis2() As String
            Get
                Return CType(Me("ConnectionStringCrvSis2"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Data Source=10.10.1.1;Initial Catalog=SirCoDwh;Persist Security Info=True;User ID"& _ 
            "=sa;Password=T0rre0nmx")>  _
        Public ReadOnly Property ConnectionStringDwhSql() As String
            Get
                Return CType(Me("ConnectionStringDwhSql"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Data Source=10.10.1.1;Initial Catalog=SirCo;Persist Security Info=True;User ID=sa"& _ 
            ";Password=T0rre0nmx")>  _
        Public ReadOnly Property ConnectionStringSirCoSql() As String
            Get
                Return CType(Me("ConnectionStringSirCoSql"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Data Source=10.10.1.1;Initial Catalog=SirCoNomina;Persist Security Info=True;User"& _ 
            " ID=sa;Password=T0rre0nmx")>  _
        Public ReadOnly Property ConnectionStringNominaSql() As String
            Get
                Return CType(Me("ConnectionStringNominaSql"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Data Source=10.10.1.1;Initial Catalog=SirCoCredito;Persist Security Info=True;Use"& _ 
            "r ID=sa;Password=T0rre0nmx")>  _
        Public ReadOnly Property ConnectionStringCreditoSql() As String
            Get
                Return CType(Me("ConnectionStringCreditoSql"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Driver={Firebird/InterBase(r) driver};dbname=\\10.10.1.1\c:\Microsip datos\ZAPATE"& _ 
            "RIAS TORREON.FDB;charset=NONE;client=C:\Archivos de programa\Microsip\2016\fbcli"& _ 
            "ent.dll;uid=SYSDBA;pwd=ztpersonal")>  _
        Public ReadOnly Property ConnectionStringMicrosip() As String
            Get
                Return CType(Me("ConnectionStringMicrosip"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Data Source=10.10.1.1;Initial Catalog=SirCoAPP;Persist Security Info=True;User ID"& _ 
            "=sa;Password=T0rre0nmx")>  _
        Public ReadOnly Property ConnectionStringAPPSql() As String
            Get
                Return CType(Me("ConnectionStringAPPSql"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Driver={MySQL ODBC 5.1 Driver};server=10.10.1.1;uid=root;pwd=z4pt0r;database=cred"& _ 
            "itolocal;port=3306;no_bigint=1")>  _
        Public ReadOnly Property ConnectionStringCredito() As String
            Get
                Return CType(Me("ConnectionStringCredito"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Data Source=10.10.1.1;Initial Catalog=SirCoControl;Persist Security Info=True;Use"& _ 
            "r ID=sa;Password=T0rre0nmx")>  _
        Public ReadOnly Property ConnectionStringControlSql() As String
            Get
                Return CType(Me("ConnectionStringControlSql"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Data Source=10.10.1.1;Initial Catalog=SirCoEnLinea;Persist Security Info=True;Use"& _ 
            "r ID=sa;Password=T0rre0nmx")>  _
        Public ReadOnly Property ConnectionStringVentaEnLineaSql() As String
            Get
                Return CType(Me("ConnectionStringVentaEnLineaSql"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Data Source=10.10.1.1;Initial Catalog=SirCoPV;Persist Security Info=True;User ID="& _ 
            "sa;Password=T0rre0nmx")>  _
        Public ReadOnly Property ConnectionStringPVSql() As String
            Get
                Return CType(Me("ConnectionStringPVSql"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Data Source=10.10.1.1;Initial Catalog=SirCoTEMP;Persist Security Info=True;User I"& _ 
            "D=sa;Password=T0rre0nmx")>  _
        Public ReadOnly Property ConnectionStringTEMPSql() As String
            Get
                Return CType(Me("ConnectionStringTEMPSql"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Data Source=10.10.1.1s;Initial Catalog=carganomina;Persist Security Info=True;Use"& _ 
            "r ID=sa;Password=T0rre0nmx")>  _
        Public ReadOnly Property ConnectionStringNomsisSql() As String
            Get
                Return CType(Me("ConnectionStringNomsisSql"),String)
            End Get
        End Property
    End Class
End Namespace

Namespace My
    
    <Global.Microsoft.VisualBasic.HideModuleNameAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
    Friend Module MySettingsProperty
        
        <Global.System.ComponentModel.Design.HelpKeywordAttribute("My.Settings")>  _
        Friend ReadOnly Property Settings() As Global.SIRCO.My.MySettings
            Get
                Return Global.SIRCO.My.MySettings.Default
            End Get
        End Property
    End Module
End Namespace
