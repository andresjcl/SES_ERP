Imports System.Data.SqlClient
Public Class DaxCombobx

    Dim conectar As New SqlConnection()
    Dim nombre As String = ""
    Dim nom As String = ""
    Dim cod As String = ""
    Dim datosCond As String = ""
    Dim cmpCond As String = ""
    Dim tabla As String = ""
    Dim condicion As String = ""
    Dim Todos As String = ""
    Dim usr As New DaxUsr.DaxsofUsr
    Dim ctrlUser As DaxUsr.CtrlUsuario
    'Dim usuar As String = usr.UsuarioAct.nombre.ToUpper

    'Public Function DaxCombos(ByVal nombr As String, ByVal CondicionCons As String, ByVal con As String, ByRef PasCombo As ComboBox) As Boolean
    '    nombre = nombr
    '    condicion = CondicionCons.Replace(" ", "','")
    '    conectar.ConnectionString = con
    '    Dim ssql As String = consulta(nombr)
    '    Dim dat As New DataSet()
    '    Dim datA As New SqlDataAdapter(ssql, conectar)
    '    If conectar.State = ConnectionState.Open Then conectar.Close()
    '    conectar.Open()
    '    datA.Fill(dat, "Datos")
    '    PasCombo.DataSource = dat.Tables(0)
    '    PasCombo.DisplayMember = nom
    '    PasCombo.ValueMember = cod
    '    conectar.Close()
    '    DaxCombos = True
    'End Function
    Public Function DaxCombosDoc(ByVal ClaseDoc As String, ByVal TipoDoc As String, ByVal todos As Boolean, ByVal strCon As String, ByRef PasCombo As ComboBox) As Boolean
        usr = New ctrlUser
        ctrlUser = usr.UsuarioAct
        Dim usuar As String = ctrlUser.nombre
        Dim CLASE As String = ""
        Dim tds As String = "select 'Todos los Documentos' as Opc_nombre,'0' as Opc_documento "
        condicion = usr.UsuarioAct.Docs.Replace(" ", "','")
        conectar.ConnectionString = strCon
        Dim ssql As String = " select TOP 100 Opc_nombre,Opc_documento from AdcOpc where opc_documento <> ''"
        If ClaseDoc <> "" Then
            CLASE = " and ("
            For I = 0 To ClaseDoc.Length - 1 Step 3
                Select Case ClaseDoc.Substring(I, 3).ToUpper
                    Case "AUT"
                        ssql += CLASE + " documentonoactivado=1 " : CLASE = " OR "
                    Case "INV"
                        ssql += CLASE + " substring(opc_extension,5,1) <> '0' " : CLASE = " OR "
                    Case "TTB"
                        ssql += CLASE + " opc_contabiliza = 1 " : CLASE = " OR "
                    Case "CTB"
                        ssql += CLASE + " opc_tipo='DIA' OR opc_contabiliza = 1 " : CLASE = " OR "
                    Case "SRI"
                        ssql += CLASE + " opc_tipoSRI > '' " : CLASE = " Or "
                    Case Else
                        ssql += CLASE + " opc_tipo='" & ClaseDoc.Substring(I, 3).ToUpper & "'" : CLASE = " OR "
                End Select
            Next
            ssql += ") "
        End If
        If TipoDoc.Length() = 3 Then
            ssql += " and Opc_documento ='" & TipoDoc & "'"
        Else
            If TipoDoc.Length() > 3 Then
                ssql += " and Opc_documento in(" & TipoDoc & ")"
            End If
        End If

        If Not (usuar.ToUpper() = "ADMINISTRADOR" Or usuar.ToUpper() = "CONTROL") Then
            If TipoDoc <> "" Then ssql += " and Opc_documento ='" & TipoDoc & "'"
            ssql += " and Opc_documento in('" & condicion & "')"
        End If
        If todos = True Then ssql = tds & "union all SELECT * FROM (" & ssql & " ORDER BY OPC_NOMBRE) R1"
        Dim dat As New DataSet()
        Dim datA As New SqlDataAdapter(ssql, conectar)
        If conectar.State = ConnectionState.Open Then conectar.Close()
        conectar.Open()
        datA.Fill(dat, "Datos")
        PasCombo.DataSource = dat.Tables("Datos")
        PasCombo.DisplayMember = "Opc_nombre"
        PasCombo.ValueMember = "Opc_documento"
        conectar.Close()
        DaxCombosDoc = True
    End Function
    Public Function DaxCombosDoc(ByVal ClaseDoc As String, ByVal TipoDoc As String, ByVal todos As Boolean, ByVal strCon As String, ByRef PasCombo As ToolStripComboBox) As Boolean
        ctrlUser = usr.UsuarioAct
        Dim usuar As String = ctrlUser.nombre
        Dim CLASE As String = ""
        Dim tds As String = "select 'Todos los Documentos' as Opc_nombre,'0' as Opc_documento "
        PasCombo.Items.Clear()
        condicion = usr.UsuarioAct.Docs.Replace(" ", "','")
        conectar.ConnectionString = strCon
        Dim ssql As String = " select TOP 100 Opc_nombre,Opc_documento from AdcOpc where opc_documento <> ''"
        If ClaseDoc <> "" Then
            CLASE = " and ("
            For I = 0 To ClaseDoc.Length - 1 Step 3
                Select Case ClaseDoc.Substring(I, 3).ToUpper
                    Case "AUT"
                        ssql += CLASE + " documentonoactivado=1 " : CLASE = " OR "
                    Case "INV"
                        ssql += CLASE + " substring(opc_extension,5,1) <> '0' " : CLASE = " OR "
                    Case "TTB"
                        ssql += CLASE + " opc_contabiliza = 1 " : CLASE = " OR "
                    Case "CTB"
                        ssql += CLASE + " opc_tipo='DIA' OR opc_contabiliza = 1 " : CLASE = " OR "
                    Case "SRI"
                        ssql += CLASE + " opc_tipoSRI > '' " : CLASE = " Or "
                    Case Else
                        ssql += CLASE + " opc_tipo='" & ClaseDoc.Substring(I, 3).ToUpper & "'" : CLASE = " OR "
                End Select
            Next
            ssql += ") "
        End If
        If Not (usuar.ToUpper() = "ADMINISTRADOR" Or usuar.ToUpper() = "CONTROL") Then
            If TipoDoc <> "" Then ssql += " and Opc_documento ='" & TipoDoc & "'"
            ssql += " and Opc_documento in('" & condicion & "')"
        End If
        If todos = True Then ssql = tds & "union all SELECT * FROM (" & ssql & " ORDER BY OPC_NOMBRE) R1"
        Dim dat As New DataSet()
        Dim datA As New SqlDataAdapter(ssql, conectar)
        If conectar.State = ConnectionState.Open Then conectar.Close()
        conectar.Open()
        datA.Fill(dat, "Datos")
        For Each row As DataRow In dat.Tables("Datos").Rows
            PasCombo.Items.Add(row("Opc_documento").ToString() + "-" + row("Opc_nombre").ToString())
            conectar.Close()
            DaxCombosDoc = True
        Next
    End Function

    Public Function DaxCombosVend(ByVal StrCon As String, ByRef PasCombo As ComboBox, Optional ByVal TODOS As Boolean = True) As Boolean
        conectar.ConnectionString = StrCon
        Dim ssql As String = ""
        If TODOS Then ssql = "select 'Todos' as NombreImpresion,'0' as codigo  UNION ALL "
        ssql &= "select NombreImpresion, codigo from identificacion where esVendedor=1"
        Dim dat As New DataSet()
        Dim datA As New SqlDataAdapter(ssql, conectar)
        If conectar.State = ConnectionState.Open Then conectar.Close()
        conectar.Open()
        datA.Fill(dat, "Datos")
        PasCombo.DataSource = dat.Tables(0)
        PasCombo.DisplayMember = "NombreImpresion"
        PasCombo.ValueMember = "codigo"
        conectar.Close()
        DaxCombosVend = True
    End Function

    Public Function DaxCombosPtoVta(ByVal StrCon As String, ByRef PasCombo As ComboBox, Optional ByVal TODOS As Boolean = True) As Boolean
        conectar.ConnectionString = StrCon
        Dim ssql As String = ""
        If TODOS Then ssql = "select 'Todos' as puntoo,'0' as codigo  UNION ALL "
        ssql &= "select top 100 percent case when ltrim(rtrim(isnull(PuntoVta,''))) = '' then 'Empresa' else PuntoVta end as puntoo "
        ssql &= ", case when ltrim(rtrim(isnull(PuntoVta,''))) = '' then 'Empresa' else PuntoVta end as codigo "
        ssql &= "from adcdoc "
        ssql &= "group by case when ltrim(rtrim(isnull(PuntoVta,''))) = '' then 'Empresa' else PuntoVta end "
        '        ssql &= "order by case when ltrim(rtrim(isnull(PuntoVta,''))) = '' then 'Empresa' else PuntoVta end "
        Dim dat As New DataSet()
        Dim datA As New SqlDataAdapter(ssql, conectar)
        If conectar.State = ConnectionState.Open Then conectar.Close()
        conectar.Open()
        datA.Fill(dat, "Datos")
        PasCombo.DataSource = dat.Tables(0)
        PasCombo.DisplayMember = "puntoo"
        PasCombo.ValueMember = "codigo"
        conectar.Close()
        DaxCombosPtoVta = True
    End Function

    Public Function DaxCombosBancos(ByVal StrCon As String, ByRef PasCombo As ComboBox) As Boolean
        conectar.ConnectionString = StrCon
        Dim ssql As String = "select NombreImpresion, codigo from identificacion where esBanco=1"
        Dim dat As New DataSet()
        Dim datA As New SqlDataAdapter(ssql, conectar)
        If conectar.State = ConnectionState.Open Then conectar.Close()
        conectar.Open()
        datA.Fill(dat, "Datos")
        PasCombo.DataSource = dat.Tables(0)
        PasCombo.DisplayMember = "NombreImpresion"
        PasCombo.ValueMember = "codigo"
        conectar.Close()
        DaxCombosBancos = True
    End Function

    Public Function DaxCombosCat(ByVal categoria As String, ByVal tipo As String, ByVal StrCon As String, ByRef PasCombo As ComboBox) As Boolean
        Dim tabla As String = ""
        conectar.ConnectionString = StrCon
        Dim td As String = "select 'Todo' as Niv_nombre, '0' as Niv_abrevia union all "
        Dim cat As String = ""
        Select Case categoria
            Case "CL" : cat = "2"
            Case "G" : cat = "3"
            Case "S" : cat = "4"
            Case Else : cat = "1"
        End Select
        If tipo = "A" Then tabla = "AdcNivAcf" Else tabla = "AdcNiv"
        Dim ssql As String = td & "select Niv_nombre, Niv_abrevia from " & tabla & " where Niv_categor=" & cat
        Dim dat As New DataSet()
        Dim datA As New SqlDataAdapter(ssql, conectar)
        If conectar.State = ConnectionState.Open Then conectar.Close()
        conectar.Open()
        datA.Fill(dat, "Datos")
        PasCombo.DataSource = dat.Tables(0)
        PasCombo.DisplayMember = "Niv_nombre"
        PasCombo.ValueMember = "Niv_abrevia"
        conectar.Close()
        DaxCombosCat = True
    End Function

    Public Function DaxCombosSuc(ByVal empresa As String, ByVal todo As Boolean, ByVal StrCon As String, ByRef PasCombo As ComboBox, Optional ByVal userSuc As Boolean = True) As Boolean
        ctrlUser = usr.UsuarioAct
        Dim usuar As String = ctrlUser.nombre
        conectar.ConnectionString = StrCon
        Dim cat As String = ""
        Dim td As String = "select 'Todas las sucursales' as Suc_Nombre, '0' as Suc_Codigo union all "
        If Not (usr.UsuarioAct.Sucs Is Nothing) Then
            condicion = usr.UsuarioAct.Sucs.Replace(" ", "','")
        Else
            condicion = ""
        End If
        Dim ssql As String = "select * from (select top 100 Suc_Nombre, Suc_Codigo from Emp_Suc where Suc_Codigo<>'' and emp_codigo=" & empresa
        If todo = True Then ssql = td & ssql
        If Not (usuar = "ADMINISTRADOR" Or usuar = "CONTROL") And userSuc Then ssql += " and Suc_Codigo in('" & condicion & "')"
        Dim dat As New DataSet()
        Dim datA As New SqlDataAdapter(ssql & " order by suc_nombre) r1", conectar)
        If conectar.State = ConnectionState.Open Then conectar.Close()
        conectar.Open()
        datA.Fill(dat, "Datos")
        PasCombo.DataSource = dat.Tables(0)
        PasCombo.DisplayMember = "Suc_Nombre"
        PasCombo.ValueMember = "Suc_Codigo"
        conectar.Close()
        DaxCombosSuc = True
    End Function

    Public Function DaxCombosBods(ByVal Suc As String, ByVal todo As Boolean, ByVal StrCon As String, ByRef PasCombo As ComboBox, Optional ByVal deUser As Boolean = True) As Boolean
        ctrlUser = usr.UsuarioAct
        Dim usuar As String = ctrlUser.nombre
        conectar.ConnectionString = StrCon
        Dim cat As String = ""
        Dim CONEMP As New AdcDax.DaxSofSys()
        Dim SYSEMP As AdcDax.Empresa

        SYSEMP = CONEMP.EmpresaAct
        Dim codEmp As Integer = SYSEMP.codigo
        Dim ssql As String = ""
        If todo Then ssql = "select 'Todas las bodegas' as Bod_nombre, '0' as Bod_codigo union all "
        condicion = usr.UsuarioAct.Bods.Replace(" ", "','")
        ssql &= "select Bod_nombre, Bod_codigo from Emp_bod where Bod_codigo<>'' and emp_codigo=" & codEmp
        If Suc <> "" Then ssql += " and Suc_codigo='" & Suc & "'"
        If Not (usuar = "ADMINISTRADOR" Or usuar = "CONTROL") And deUser Then ssql += " and Bod_Codigo in('" & condicion & "')"
        Dim dat As New DataSet()
        Dim datA As New SqlDataAdapter(ssql, conectar)
        If conectar.State = ConnectionState.Open Then conectar.Close()
        conectar.Open()
        datA.Fill(dat, "Datos")
        PasCombo.DataSource = dat.Tables(0)
        PasCombo.DisplayMember = "Bod_nombre"
        PasCombo.ValueMember = "Bod_codigo"
        conectar.Close()
        DaxCombosBods = True
    End Function

    Public Function DaxCombosReferencia(ByVal referencia As String, ByVal StrCon As String, ByRef PasCombo As ComboBox, Optional ByVal todos As Boolean = False) As Boolean
        Dim ssql As String = ""
        conectar.ConnectionString = StrCon
        If todos Then ssql = "select ' Todos' as Descripcion, '0' as Abreviación union all "
        ssql += "select Descripcion, Abreviación from SysCod where TipoReferencia ='" & referencia & "'"
        ssql += " and Abreviación <>'#'"
        ssql += " order by descripcion "
        Dim dat As New DataSet()
        Dim datA As New SqlDataAdapter(ssql, conectar)
        If conectar.State = ConnectionState.Open Then conectar.Close()
        conectar.Open()
        datA.Fill(dat, "Datos")
        PasCombo.DataSource = dat.Tables(0)
        PasCombo.DisplayMember = "Descripcion"
        PasCombo.ValueMember = "Abreviación"
        conectar.Close()
        DaxCombosReferencia = True
    End Function

    Public Function DaxCombosCtasCorrientes(ByVal StrCon As String, ByRef PasCombo As ComboBox) As Boolean
        conectar.ConnectionString = StrCon
        Dim ssql As String = "select Bco_Nombre, Bco_NumCta from Adcctabco "
        Dim dat As New DataSet()
        Dim datA As New SqlDataAdapter(ssql, conectar)
        If conectar.State = ConnectionState.Open Then conectar.Close()
        conectar.Open()
        datA.Fill(dat, "Datos")
        PasCombo.DataSource = dat.Tables(0)
        PasCombo.DisplayMember = "Bco_Nombre"
        PasCombo.ValueMember = "Bco_NumCta"
        conectar.Close()
        DaxCombosCtasCorrientes = True
    End Function

    Public Function DaxCombosClasf(ByVal StrCon As String, ByRef PasCombo As ComboBox) As Boolean
        conectar.ConnectionString = StrCon
        Dim ssql As String = "select nombre from adcclasfctb where esclasificador = 1"
        Dim dat As New DataSet()
        Dim datA As New SqlDataAdapter(ssql, conectar)
        If conectar.State = ConnectionState.Open Then conectar.Close()
        conectar.Open()
        datA.Fill(dat, "Datos")
        PasCombo.DataSource = dat.Tables(0)
        PasCombo.DisplayMember = "nombre"
        PasCombo.ValueMember = "nombre"
        conectar.Close()
        DaxCombosClasf = True
    End Function

    Public Function DaxCombosFormPago(ByVal StrCon As String, ByRef PasCombo As ComboBox) As Boolean
        conectar.ConnectionString = StrCon
        Dim ssql As String = "select idFormasDePago,Descripcion  from FormasDePago "
        Dim dat As New DataSet()
        Dim datA As New SqlDataAdapter(ssql, conectar)
        If conectar.State = ConnectionState.Open Then conectar.Close()
        conectar.Open()
        datA.Fill(dat, "Datos")
        PasCombo.DataSource = dat.Tables(0)
        PasCombo.DisplayMember = "Descripcion"
        PasCombo.ValueMember = "idFormasDePago"
        conectar.Close()
        DaxCombosFormPago = True
    End Function

End Class


