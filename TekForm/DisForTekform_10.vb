Option Strict Off
Option Explicit On
Friend Class DisForma
    Inherits System.Windows.Forms.Form


    'Dim NombreArchivo As String
    ' variables traidas desde el modulo anterios RUTINASTEKFORM.BAS
    Dim ALinea As Byte
    Dim PathImg As String
    Dim Valor As String
    Dim DeSys As New VB6.FixedLengthString(1)
    Dim FHeight, Ftop, FLeft, FWidth As Short
    Dim Numlin, fs, NumHor As Short
    Dim FN, FO, forma As String
    Dim FI, FB, FU As Byte


    '''''''''''

    Dim X1, Y1 As Short
    Dim PX, PY As Short
    Dim TotIma, TotDat, TotLin, TotEti, TotCua As Short
    Dim IndLin, IndDat, IndEt, IndImg, IndCua As Short

    Private Sub _tbToolBar_Button1_Click(sender As Object, e As EventArgs) Handles _tbToolBar_Button1.Click

    End Sub

    Dim TipoPintado As New VB6.FixedLengthString(1)

    Private Sub detiqueta_Click(sender As Object, e As EventArgs) Handles detiqueta.Click

    End Sub

    Private Sub Papel_Paint(sender As Object, e As PaintEventArgs) Handles Papel.Paint

    End Sub

    Private Sub _tbToolBar_Button2_Click(sender As Object, e As EventArgs) Handles _tbToolBar_Button2.Click

    End Sub

    Dim Actual As Object
    Dim NomImagen(16) As String
    Dim EnLinea As Boolean
    Dim AlargaAbajo, AlargaDerecha, AlargaIzquierda, AlargaArriba As Boolean
    Dim CambioValor(11) As Boolean
    'UPGRADE_NOTE: Separador was changed from a Constant to a Variable. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C54B49D7-5804-4D48-834B-B3D81E4C2F13"'
    Dim Separador As New VB6.FixedLengthString(1, ";")
    Const paso As Integer = 567 ' twips   =  1 cm

    Dim MaxLin, MaxDat, MaxEti, MaxIma, MaxCua As Short
    Dim PosIni, ColIni As Double
    Dim Nuevo As Short
    '0 sin operacion     1 nuevo      2 modificando
    'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'

    Private Sub Alarga_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles Alarga.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim index As Short = Alarga.GetIndex(eventSender)
        On Error Resume Next
        'UPGRADE_WARNING: Couldn't resolve default property of object Actual.Name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        If Actual.Name <> "Etiqueta" Then
            'UPGRADE_WARNING: Couldn't resolve default property of object Actual.Name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If Not Actual.Name = "linea" Then
                Text1.Visible = False
                'IgualarCuadro()
            End If
            X1 = X
            Y1 = Y
            Select Case index
                Case 0
                    AlargaDerecha = True
                Case 1
                    AlargaArriba = True
                Case 2
                    AlargaIzquierda = True
                Case 3
                    AlargaAbajo = True
            End Select
        End If
    End Sub

    'Private Sub Alarga_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles Alarga.MouseMove
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    Dim index As Short = Alarga.GetIndex(eventSender)
    '    On Error Resume Next
    '    If AlargaIzquierda Then
    '        'UPGRADE_WARNING: Couldn't resolve default property of object Actual.Name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '        If Actual.Name = "linea" Then
    '            linea(IndLin).X2 = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(linea(IndLin).X2) + X)
    '            linea(IndLin).Y2 = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(linea(IndLin).Y2) + Y)
    '            'poneralargadorlinea((IndLin))
    '        Else
    '            'UPGRADE_WARNING: Couldn't resolve default property of object Actual.Width. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '            Actual.Width = Actual.Width + X
    '            'UPGRADE_WARNING: Couldn't resolve default property of object Actual. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '            'PonerAlargador(Actual, IndCua)
    '            'IgualarCuadro()
    '        End If
    '    End If

    '    If AlargaAbajo Then
    '        'UPGRADE_WARNING: Couldn't resolve default property of object Actual.Height. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '        Actual.Height = Actual.Height + Y
    '        'UPGRADE_WARNING: Couldn't resolve default property of object Actual. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '        'PonerAlargador(Actual, IndCua)
    '        'IgualarCuadro()
    '    End If
    '    If AlargaArriba Then
    '        'UPGRADE_WARNING: Couldn't resolve default property of object Actual.Height. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '        Actual.Height = Actual.Height - Y
    '        'UPGRADE_WARNING: Couldn't resolve default property of object Actual.Top. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '        Actual.Top = Actual.Top + Y
    '        'UPGRADE_WARNING: Couldn't resolve default property of object Actual. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '        'PonerAlargador(Actual, IndCua)
    '        'IgualarCuadro()
    '    End If
    '    If AlargaDerecha Then
    '        'UPGRADE_WARNING: Couldn't resolve default property of object Actual.Name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '        If Actual.Name = "linea" Then
    '            linea(IndLin).X1 = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(linea(IndLin).X1) + X)
    '            linea(IndLin).Y1 = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(linea(IndLin).Y1) + Y)
    '            'poneralargadorlinea((IndLin))
    '        Else
    '            'UPGRADE_WARNING: Couldn't resolve default property of object Actual.Width. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '            Actual.Width = Actual.Width - X
    '            'UPGRADE_WARNING: Couldn't resolve default property of object Actual.Left. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '            Actual.Left = Actual.Left + X
    '            'UPGRADE_WARNING: Couldn't resolve default property of object Actual. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '            'PonerAlargador(Actual, IndCua)
    '            'IgualarCuadro()
    '        End If
    '    End If
    'End Sub

    'Private Sub Alarga_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles Alarga.MouseUp
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    Dim index As Short = Alarga.GetIndex(eventSender)
    '    AlargaDerecha = False
    '    AlargaArriba = False
    '    AlargaIzquierda = False
    '    AlargaAbajo = False
    '    'Cuadro.Visible = False
    'End Sub

    'Private Sub EtiquetaNueva()
    '    Dim i, Ex As Short
    '    On Error Resume Next
    '    Ex = 0
    '    For i = 1 To MaxEti
    '        If Etiqueta(i).Visible = False Then Ex = i
    '    Next i
    '    If Ex = 0 Then MaxEti = MaxEti + 1 : IndEt = MaxEti : Etiqueta.Load(IndEt) Else IndEt = Ex
    '    With Etiqueta(IndEt)
    '        .Top = marcador.Top
    '        .Left = marcador.Left
    '        .Visible = True
    '        .Enabled = True
    '        .Text = "Etiqueta-" & Str(IndEt)
    '        .Width = VB6.TwipsToPixelsX(600)
    '        .Height = VB6.TwipsToPixelsY(300)
    '        .Top = VB6.TwipsToPixelsY(PY)
    '        .Left = VB6.TwipsToPixelsX(PX)
    '        .TextAlign = ALinea
    '        If IndEt > TotEti Then TotEti = IndEt
    '        Actual = Etiqueta(IndEt)
    '        'UPGRADE_WARNING: Couldn't resolve default property of object Actual. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '        'PonerAlargador(Actual)
    '    End With
    'End Sub

    'Private Sub DatoNuevo()
    '    Dim i, Ex As Short
    '    Dim p As Integer
    '    Dim PasDatos() As String
    '    Dim Topp As Integer
    '    On Error Resume Next
    '    Pasar = ""
    '    Ex = False
    '    Datos.EsDeConsulta = NombreConsulta
    '    VB6.ShowForm(Datos, (1))
    '    If Pasar > "" Then
    '        PasDatos = Split(Pasar, ",")
    '        For p = LBound(PasDatos) To UBound(PasDatos)
    '            Pasar = PasDatos(p)
    '            Ex = 0
    '            For i = 1 To MaxDat
    '                If Dato(i).Visible = False Then Ex = i
    '            Next i
    '            If Ex = 0 Then MaxDat = MaxDat + 1 : IndDat = MaxDat : Dato.Load(IndDat) Else IndDat = Ex
    '            With Dato(IndDat)
    '                .Top = marcador.Top
    '                .Left = marcador.Left
    '                .Visible = True
    '                .Enabled = True
    '                .Text = Pasar
    '                .Tag = Tipo
    '                .Width = VB6.TwipsToPixelsX(600)
    '                .Height = VB6.TwipsToPixelsY(300)
    '                .TextAlign = ALinea
    '                ToolTip1.SetToolTip(Dato(IndDat), "")
    '                If IndDat > TotDat Then TotDat = IndDat
    '                Actual = Dato(IndDat)
    '                'UPGRADE_WARNING: Couldn't resolve default property of object Actual. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '                'PonerAlargador(Actual)
    '                marcador.Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(marcador.Top) + 100)
    '                marcador.Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(marcador.Left) + 100)
    '            End With
    '        Next p
    '    End If
    'End Sub

    'Private Sub ImagenNueva()
    '    Dim i, Ex As Short
    '    Dim bk As String
    '    On Error Resume Next

    '    bk = IngresaImagen("")

    '    If bk = "" Then Exit Sub
    '    Ex = 0
    '    For i = 1 To MaxIma
    '        If Imagen(i).Visible = False Then Ex = i
    '    Next i
    '    If Ex = 0 Then MaxIma = MaxIma + 1 : IndImg = i : Imagen.Load(IndImg) Else IndImg = Ex
    '    With Imagen(IndImg)
    '        .Top = marcador.Top
    '        .Left = marcador.Left
    '        .Visible = True
    '        .Enabled = True
    '        IndImg = i
    '        If IndImg > TotIma Then TotIma = IndImg
    '        NomImagen(IndImg) = bk
    '        If NomImagen(IndImg) > "" Then
    '            'UPGRADE_WARNING: Dir has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
    '            bk = Dir(PathImg & NomImagen(IndImg))
    '            If Len(bk) > 0 Then Imagen(IndImg).Image = System.Drawing.Image.FromFile(PathImg & NomImagen(IndImg))
    '        End If
    '    End With
    'End Sub

    'Private Sub LineaNueva()
    '    Dim i, Ex As Short
    '    On Error Resume Next
    '    Papel.Cursor = System.Windows.Forms.Cursors.Cross
    '    Ex = 0
    '    For i = 1 To MaxLin
    '        If linea(i).Visible = False Then Ex = i
    '    Next i
    '    If Ex = 0 Then
    '        MaxLin = MaxLin + 1
    '        IndLin = MaxLin
    '        linea.Load(IndLin)
    '        MarcLin.Load(IndLin)
    '    Else : IndLin = Ex
    '    End If
    '    If IndLin > TotLin Then TotLin = IndLin
    'End Sub

    'Private Sub CuadradoNuevo()
    '    Dim i, Ex As Short
    '    On Error Resume Next
    '    Ex = 0
    '    For i = 1 To MaxCua
    '        If CuadradoR(i).Visible = False Then Ex = i
    '    Next i
    '    If Ex = 0 Then
    '        MaxCua = MaxCua + 1
    '        IndCua = MaxCua
    '        CuadradoR.Load(IndCua)
    '        MarCuad.Load(IndCua)
    '    Else : IndCua = Ex
    '    End If
    '    With CuadradoR(IndCua)
    '        .Top = marcador.Top
    '        .Left = marcador.Left
    '        .Visible = True
    '        '       .Enabled = True
    '        '       .Text = "Cuadrado-" & Str(IndEt)
    '        .Width = VB6.TwipsToPixelsX(600)
    '        .Height = VB6.TwipsToPixelsY(300)
    '        .Top = VB6.TwipsToPixelsY(PY)
    '        .Left = VB6.TwipsToPixelsX(PX)
    '        '       .Alignment = ALinea
    '        If IndCua > TotCua Then TotCua = IndCua
    '        Actual = CuadradoR(IndCua)
    '        'UPGRADE_WARNING: Couldn't resolve default property of object Actual. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '        'PonerAlargador(Actual, IndCua)
    '    End With
    'End Sub

    Private Function IngresaImagen(ByRef Anterior As String) As String
        Dim Coop As New Scripting.FileSystemObject
        Dim resp As String
        On Error Resume Next
        'UPGRADE_WARNING: CommonDialog variable was not upgraded Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="671167DC-EA81-475D-B690-7A40C7BF4A23"'
        'With Utiliti
        '	.FileName = Anterior
        '	.InitialDirectory = PathImg
        '	.Title = "Escojer imagen para formulario"
        '	'UPGRADE_WARNING: Filter has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        '	.Filter = "Imágenes (*.bmp;*.ico;*.jpg)|*.bmp;*.ico;*.jpg"
        '	.ShowDialog()
        '	'UPGRADE_ISSUE: MSComDlg.CommonDialog property Utiliti.CancelError was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
        '	If .CancelError = True Then
        '		IngresaImagen = Anterior
        '	Else : IngresaImagen = SoloNombre(.FileName)
        '		Coop.CopyFile(.FileName, PathImg, True)
        '	End If
        'End With
    End Function

    '	Public Sub AlinHor_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles AlinHor.Click
    '		Dim i, r As Short
    '		Dim Labl As System.Windows.Forms.Control
    '		'UPGRADE_WARNING: Couldn't resolve default property of object Actual.Name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '		If Actual.Name <> "Etiqueta" And Actual.Name <> "Dato" Then MsgBox("Debe seleccionar un elemento inicial para la alineación") : Exit Sub
    '		r = MsgBox("Alinear horizontalmente todos los Elementos seleccionados ?", MsgBoxStyle.OKCancel)
    '		If r <> MsgBoxResult.OK Then BorrarPintados() : Exit Sub
    '		For	Each Labl In Me.Controls
    '			With Labl
    '				If .Name = "Etiqueta" Or .Name = "Dato" Then
    '					'UPGRADE_WARNING: Couldn't resolve default property of object Labl.BackStyle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '					If .BackStyle = 1 Then
    '						'UPGRADE_WARNING: Couldn't resolve default property of object Actual.Top. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '						.Top = VB6.TwipsToPixelsY(Actual.Top)
    '						'UPGRADE_WARNING: Couldn't resolve default property of object Actual.Height. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '						.Height = VB6.TwipsToPixelsY(Actual.Height)
    '						'UPGRADE_ISSUE: Control method Labl.BackStyle was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
    '						.BackStyle = 0
    '					End If
    '				End If
    '			End With
    '		Next Labl
    '		Select Case TipoPintado.Value

    '			Case "D"
    '				For i = 1 To TotDat
    '					With Dato(i)
    '						'UPGRADE_ISSUE: Label property Dato.BackStyle is not supported at runtime. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="74E732F3-CAD8-417B-8BC9-C205714BB4A7"'
    '						If .BackStyle = 1 Then
    '							'UPGRADE_WARNING: Couldn't resolve default property of object Actual.Top. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '							.Top = VB6.TwipsToPixelsY(Actual.Top)
    '							'UPGRADE_WARNING: Couldn't resolve default property of object Actual.Height. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '							.Height = VB6.TwipsToPixelsY(Actual.Height)
    '							'UPGRADE_ISSUE: Label property Dato.BackStyle is not supported at runtime. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="74E732F3-CAD8-417B-8BC9-C205714BB4A7"'
    '							.BackStyle = 0
    '						End If
    '					End With
    '				Next 
    '			Case "E"
    '				For i = 1 To TotEti
    '					With Etiqueta(i)
    '						'UPGRADE_ISSUE: Label property Etiqueta.BackStyle is not supported at runtime. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="74E732F3-CAD8-417B-8BC9-C205714BB4A7"'
    '						If .BackStyle = 1 Then
    '							'UPGRADE_WARNING: Couldn't resolve default property of object Actual.Top. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '							.Top = VB6.TwipsToPixelsY(Actual.Top)
    '							'UPGRADE_WARNING: Couldn't resolve default property of object Actual.Height. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '							.Height = VB6.TwipsToPixelsY(Actual.Height)
    '							'UPGRADE_ISSUE: Label property Etiqueta.BackStyle is not supported at runtime. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="74E732F3-CAD8-417B-8BC9-C205714BB4A7"'
    '							.BackStyle = 0
    '						End If
    '					End With
    '				Next 
    '		End Select
    '		TipoPintado.Value = ""
    '		TotPintados = 0
    '		'UPGRADE_WARNING: Couldn't resolve default property of object Actual. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '		PonerAlargador(Actual)
    '	End Sub

    '	Public Sub AlinVer_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles AlinVer.Click
    '		Dim i As Short
    '		Dim r As String
    '		Dim Labl As System.Windows.Forms.Control
    '		'UPGRADE_WARNING: Couldn't resolve default property of object Actual.Name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '		If Actual.Name <> "Etiqueta" And Actual.Name <> "Dato" Then MsgBox("Debe seleccionar un elemento inicial para la alineación") : Exit Sub
    '		r = CStr(MsgBox("Alinear verticalmente todos los elementos seleccionados ?", MsgBoxStyle.OKCancel))
    '		If r <> CStr(MsgBoxResult.OK) Then BorrarPintados() : Exit Sub

    '		For	Each Labl In Me.Controls
    '			With Labl
    '				If .Name = "Etiqueta" Or .Name = "Dato" Then
    '					'UPGRADE_WARNING: Couldn't resolve default property of object Labl.BackStyle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '					If .BackStyle = 1 Then
    '						'UPGRADE_WARNING: Couldn't resolve default property of object Actual.Left. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '						.Left = VB6.TwipsToPixelsX(Actual.Left)
    '						'UPGRADE_WARNING: Couldn't resolve default property of object Actual.Width. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '						If .Name = "Dato" Then .Width = VB6.TwipsToPixelsX(Actual.Width)
    '						'UPGRADE_ISSUE: Control method Labl.BackStyle was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
    '						.BackStyle = 0
    '					End If
    '				End If
    '			End With
    '		Next Labl


    '		Select Case TipoPintado.Value
    '			Case "D"
    '				For i = 1 To TotDat
    '					With Dato(i)
    '						'UPGRADE_ISSUE: Label property Dato.BackStyle is not supported at runtime. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="74E732F3-CAD8-417B-8BC9-C205714BB4A7"'
    '						If .BackStyle = 1 Then
    '							.Left = Dato(IndDat).Left
    '							.Width = Dato(IndDat).Width
    '							'UPGRADE_ISSUE: Label property Dato.BackStyle is not supported at runtime. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="74E732F3-CAD8-417B-8BC9-C205714BB4A7"'
    '							.BackStyle = 0
    '						End If
    '					End With
    '				Next 
    '			Case "E"
    '				For i = 1 To TotEti
    '					With Etiqueta(i)
    '						'UPGRADE_ISSUE: Label property Etiqueta.BackStyle is not supported at runtime. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="74E732F3-CAD8-417B-8BC9-C205714BB4A7"'
    '						If .BackStyle = 1 Then
    '							.Left = Etiqueta(IndEt).Left
    '							'.Width = Etiqueta(IndEt).Width
    '							'UPGRADE_ISSUE: Label property Etiqueta.BackStyle is not supported at runtime. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="74E732F3-CAD8-417B-8BC9-C205714BB4A7"'
    '							.BackStyle = 0
    '						End If
    '					End With
    '				Next 
    '		End Select
    '		TipoPintado.Value = ""
    '		TotPintados = 0
    '		'UPGRADE_WARNING: Couldn't resolve default property of object Actual. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '		PonerAlargador(Actual)
    '	End Sub

    '	'Private Sub Ddatos_Click()
    '	'On Error Resume Next
    '	'CambiarDatos
    '	'End Sub

    '	Public Sub Estadistica_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Estadistica.Click
    '		MsgBox("Elementos utilizados" & vbCr & "Datos: " & TotDat & vbCr & "Etiquetas: " & TotEti & vbCr & "Lineas: " & TotLin & vbCr & "Imagenes: " & TotIma, MsgBoxStyle.Information)
    '	End Sub

    '	'UPGRADE_ISSUE: Label event Etiqueta.DragDrop was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"'
    '	Private Sub Etiqueta_DragDrop(ByRef index As Short, ByRef Source As System.Windows.Forms.Control, ByRef X As Single, ByRef Y As Single)
    '		Dim T, L As Short
    '		X = VB6.PixelsToTwipsX(Etiqueta(index).Left) + X
    '		Y = VB6.PixelsToTwipsY(Etiqueta(index).Top) + Y
    '		ArreglarPaso(Source, X, Y)
    '	End Sub

    '	'UPGRADE_ISSUE: Label event Dato.DragDrop was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"'
    '	Private Sub Dato_DragDrop(ByRef index As Short, ByRef Source As System.Windows.Forms.Control, ByRef X As Single, ByRef Y As Single)
    '		Dim T, L As Short
    '		On Error Resume Next
    '		X = VB6.PixelsToTwipsX(Dato(index).Left) + X
    '		Y = VB6.PixelsToTwipsY(Dato(index).Top) + Y
    '		ArreglarPaso(Source, X, Y)
    '	End Sub

    '	Private Sub DisForma_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
    '		Dim KeyCode As Short = eventArgs.KeyCode
    '		Dim Shift As Short = eventArgs.KeyData \ &H10000
    '		Dim Cual As Double
    '		Dim CuantasLineas As Double
    '		Dim CantasFilas As Double
    '		Dim l1 As Single
    '		Dim l2 As Single
    '		If KeyCode = System.Windows.Forms.Keys.Insert And marcador.Visible = True Then
    '			Cual = Val(InputBox("Numero de lineas a insertar " & " desde la posicion de la marca ", "Tekform", CStr(0)))
    '			marcador.Visible = False
    '			If Cual <> 0 Then InsertarLineas((Cual))
    '		ElseIf KeyCode = System.Windows.Forms.Keys.Delete And marcador.Visible = True Then 
    '			Cual = Val(InputBox("Numero de lineas a eliminar " & " desde la posicion de la marca ", "Tekform", CStr(0)))
    '			marcador.Visible = False
    '			Cual = -Cual
    '			If Cual <> 0 Then InsertarLineas((Cual))
    '			'ElseIf KeyCode = vbKeyDelete And TotPintados > 0 Then
    '			'    If MsgBox("Confirma eliminar todos los elementos marcados ? ", vbYesNo + vbQuestion) = vbYes Then
    '			'        EliminarMarcados
    '			'    End If
    '		ElseIf KeyCode = System.Windows.Forms.Keys.Delete Then 
    '			EliminarElemento()
    '		ElseIf KeyCode > 36 And KeyCode < 41 Then 
    '			'UPGRADE_WARNING: Couldn't resolve default property of object Actual.Name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '			If Not Actual Is Nothing And Actual.Name = "linea" Then
    '				Select Case KeyCode
    '					Case 37
    '						'UPGRADE_WARNING: Couldn't resolve default property of object Actual.X1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '						If Actual.X1 > 5 Then
    '							'UPGRADE_WARNING: Couldn't resolve default property of object Actual.X1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '							Actual.X1 = Actual.X1 - 5
    '							'UPGRADE_WARNING: Couldn't resolve default property of object Actual.X2. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '							Actual.X2 = Actual.X2 - 5
    '						End If
    '					Case 39
    '						'UPGRADE_WARNING: Couldn't resolve default property of object Actual.X1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '						Actual.X1 = Actual.X1 + 5
    '						'UPGRADE_WARNING: Couldn't resolve default property of object Actual.X2. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '						Actual.X2 = Actual.X2 + 5
    '					Case 38
    '						'UPGRADE_WARNING: Couldn't resolve default property of object Actual.Y1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '						If Actual.Y1 > 5 Then
    '							'UPGRADE_WARNING: Couldn't resolve default property of object Actual.Y1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '							Actual.Y1 = Actual.Y1 - 5
    '							'UPGRADE_WARNING: Couldn't resolve default property of object Actual.Y2. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '							Actual.Y2 = Actual.Y2 - 5
    '						End If
    '					Case 40
    '						'UPGRADE_WARNING: Couldn't resolve default property of object Actual.Y1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '						Actual.Y1 = Actual.Y1 + 5
    '						'UPGRADE_WARNING: Couldn't resolve default property of object Actual.Y2. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '						Actual.Y2 = Actual.Y2 + 5

    '				End Select
    '				poneralargadorlinea((IndLin))
    '			Else
    '				Y1 = 0
    '				X1 = 0
    '				Select Case KeyCode
    '					Case 37
    '						'UPGRADE_WARNING: Couldn't resolve default property of object Actual.Left. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '						If Actual.Left > 5 Then Actual.Left = Actual.Left - 5
    '					Case 39
    '						'UPGRADE_WARNING: Couldn't resolve default property of object Actual.Width. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '						'UPGRADE_WARNING: Couldn't resolve default property of object Actual.Left. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '						'UPGRADE_WARNING: Couldn't resolve default property of object Actual.Left. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '						If Actual.Left + Actual.Width + 5 < VB6.PixelsToTwipsX(Papel.Width) Then Actual.Left = Actual.Left + 5
    '					Case 38
    '						'UPGRADE_WARNING: Couldn't resolve default property of object Actual.Top. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '						If Actual.Top > 5 Then Actual.Top = Actual.Top - 5
    '					Case 40
    '						'UPGRADE_WARNING: Couldn't resolve default property of object Actual.Height. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '						'UPGRADE_WARNING: Couldn't resolve default property of object Actual.Top. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '						'UPGRADE_WARNING: Couldn't resolve default property of object Actual.Top. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '						If Actual.Top + Actual.Height + 5 < VB6.PixelsToTwipsY(Papel.Height) Then Actual.Top = Actual.Top + 5
    '				End Select
    '				'ArreglarPaso Actual, Actual.Left, Actual.Top
    '				'UPGRADE_WARNING: Couldn't resolve default property of object Actual. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '				PonerAlargador(Actual, IndCua)
    '			End If

    '			MarCuad(0).Visible = False

    '		End If
    '	End Sub

    '	'UPGRADE_WARNING: Event DisForma.Resize may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    '	Private Sub DisForma_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
    '		Dim alto, Largo As Integer
    '		On Error GoTo final
    '		Dim hBARRA As Integer
    '		Dim hTOOL As Integer

    '		If BarraEstado.Visible = False Then hBARRA = 0 Else hBARRA = VB6.PixelsToTwipsY(BarraEstado.Height)
    '		If tbToolBar.Visible = False Then hTOOL = 0 Else hTOOL = VB6.PixelsToTwipsY(tbToolBar.Height)
    '		Soporte.SetBounds(VB6.TwipsToPixelsX(300), VB6.TwipsToPixelsY(250 + hTOOL), VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(Me.Width) - VB6.PixelsToTwipsX(VScroll1.Width) - 400), VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(Me.Height) - hTOOL - hBARRA - VB6.PixelsToTwipsY(HScroll1.Height) - VB6.PixelsToTwipsY(tbToolBar.Height) - 650))
    '		VScroll1.SetBounds(VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(Me.Width) - 500), Soporte.Top, VB6.TwipsToPixelsX(300), VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(Soporte.Height) - 100))
    '		HScroll1.SetBounds(Soporte.Left, VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(Soporte.Top) + VB6.PixelsToTwipsY(Soporte.Height) - 110), Soporte.Width, VB6.TwipsToPixelsY(300))
    'final: 
    '	End Sub


    '	'UPGRADE_ISSUE: Image event Imagen.DragDrop was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"'
    '	Private Sub Imagen_DragDrop(ByRef index As Short, ByRef Source As System.Windows.Forms.Control, ByRef X As Single, ByRef Y As Single)
    '		Dim T, L As Short
    '		On Error Resume Next
    '		X = VB6.PixelsToTwipsX(Imagen(index).Left) + X
    '		Y = VB6.PixelsToTwipsY(Imagen(index).Top) + Y
    '		ArreglarPaso(Source, X, Y)
    '	End Sub


    '	Private Sub marcador_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles marcador.DoubleClick
    '		If marcador.Visible = True Then marcador.Visible = False
    '	End Sub

    '	'UPGRADE_ISSUE: Label event Marclin.DragDrop was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"'
    '	Private Sub Marclin_DragDrop(ByRef index As Short, ByRef Source As System.Windows.Forms.Control, ByRef X As Single, ByRef Y As Single)
    '		On Error Resume Next
    '		X = VB6.PixelsToTwipsX(MarcLin(index).Left) + X
    '		Y = VB6.PixelsToTwipsY(MarcLin(index).Top) + Y
    '		ArreglarPaso(Source, X, Y)
    '	End Sub

    '	'UPGRADE_ISSUE: Label event MarCuad.DragDrop was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"'
    '	Private Sub MarCuad_DragDrop(ByRef index As Short, ByRef Source As System.Windows.Forms.Control, ByRef X As Single, ByRef Y As Single)
    '		On Error Resume Next
    '		X = VB6.PixelsToTwipsX(MarCuad(index).Left) + X
    '		Y = VB6.PixelsToTwipsY(MarCuad(index).Top) + Y
    '		ArreglarPaso(Source, X, Y)
    '		'If index = 0 Then Stop
    '	End Sub

    '	Private Sub ArreglarPaso(ByRef Source As System.Windows.Forms.Control, ByRef X As Single, ByRef Y As Single)
    '		Dim T, L As Short
    '		On Error Resume Next
    '		T = VB6.PixelsToTwipsY(Source.Top)
    '		L = VB6.PixelsToTwipsX(Source.Left)
    '		Source.Top = VB6.TwipsToPixelsY(Y - Y1)
    '		Source.Left = VB6.TwipsToPixelsX(X - X1)
    '		Source.Visible = True
    '		If Source.Name = "MarcLin" Then
    '			With linea(IndLin)
    '				.X1 = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(.X1) + (VB6.PixelsToTwipsX(Source.Left) - L))
    '				.Y1 = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(.Y1) + (VB6.PixelsToTwipsY(Source.Top) - T))
    '				.X2 = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(.X2) + (VB6.PixelsToTwipsX(Source.Left) - L))
    '				.Y2 = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(.Y2) + (VB6.PixelsToTwipsY(Source.Top) - T))
    '			End With
    '			poneralargadorlinea((IndLin))
    '		ElseIf Source.Name = "MarCuad" Then 
    '			'If IndCua = 0 Then Stop
    '			PonerAlargador(CuadradoR(IndCua), IndCua)
    '		Else
    '			PonerAlargador(Source)
    '		End If
    '	End Sub

    '	Public Sub ddato_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ddato.Click
    '		DatoNuevo()
    '	End Sub

    '	Public Sub detiqueta_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles detiqueta.Click
    '		EtiquetaNueva()
    '	End Sub

    '	Public Sub dimagen_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles dimagen.Click
    '		ImagenNueva()
    '	End Sub

    '	Public Sub dLinea_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles dLinea.Click
    '		LineaNueva()
    '	End Sub

    '	Public Sub dpropiedad_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles dpropiedad.Click
    '		PropiedadesElementos()
    '	End Sub

    '	Private Sub DisForma_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
    '		MaxEti = 0 '50
    '		MaxDat = 0 '60
    '		MaxIma = 0 ' 8
    '		MaxLin = 0 '32
    '		MaxCua = 0
    '		CambiarDatos()
    '		NumeroDeDigitos = 2
    '		NumeroDecimales = 2
    '		BorrarElementos()
    '		ArreglarBarras()
    '		'PathForm = PathServidor & "formas\"
    '		PathImg = Emp.PatServidor & "bin\imagenes\" & Valor
    '		PorGrabar = False
    '		DibujarLineas()
    '		BorrarAlargadores()
    '		PonerBotones(False, False)
    '	End Sub

    '	Private Sub ArreglarBarras()
    '		Dim NewLargeChange As Short
    '		On Error Resume Next
    '		If VB6.PixelsToTwipsY(Papel.Height) > VB6.PixelsToTwipsY(Soporte.Height) Then
    '			VScroll1.Maximum = (VB6.PixelsToTwipsY(Papel.Height) - VB6.PixelsToTwipsY(Soporte.Height) + 100 + VScroll1.LargeChange - 1)
    '		Else
    '			VScroll1.Maximum = (0 + VScroll1.LargeChange - 1)
    '		End If
    '		If VB6.PixelsToTwipsX(Papel.Width) > VB6.PixelsToTwipsX(Soporte.Width) Then
    '			HScroll1.Maximum = (VB6.PixelsToTwipsX(Papel.Width) - VB6.PixelsToTwipsX(Soporte.Width) + 100 + HScroll1.LargeChange - 1)
    '		Else
    '			HScroll1.Maximum = (0 + HScroll1.LargeChange - 1)
    '		End If
    '		NewLargeChange = VB6.PixelsToTwipsY(Soporte.Height)
    '		VScroll1.Maximum = VScroll1.Maximum + NewLargeChange - VScroll1.LargeChange
    '		VScroll1.LargeChange = NewLargeChange
    '		NewLargeChange = VB6.PixelsToTwipsX(Soporte.Width)
    '		HScroll1.Maximum = HScroll1.Maximum + NewLargeChange - HScroll1.LargeChange
    '		HScroll1.LargeChange = NewLargeChange
    '		VScroll1.SmallChange = 100
    '		HScroll1.SmallChange = 100
    '	End Sub

    '	Private Sub DisForma_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    '		Dim r As String
    '		Dim tot As Short
    '		If DebeGrabar Then
    '			r = CStr(MsgBox("Grabar el formato antes de salir ?", MsgBoxStyle.YesNoCancel))
    '			If r = CStr(MsgBoxResult.Cancel) Then
    '				'UPGRADE_ISSUE: Event parameter Cancel was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FB723E3C-1C06-4D2B-B083-E6CD0D334DA8"'
    '				Cancel = 1 : Exit Sub
    '			End If
    '			If r = CStr(MsgBoxResult.Yes) Then mnuFileSave_Click(mnuFileSave, New System.EventArgs())
    '		End If
    '		'UPGRADE_NOTE: Object DisForma may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
    '		Me = Nothing
    '		End
    '	End Sub


    '	Public Sub Fpropiedad_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Fpropiedad.Click
    '		On Error Resume Next
    '		VB6.ShowForm(PropFormato, (1))
    '		Papel.Width = VB6.TwipsToPixelsX(APapel)
    '		Papel.Height = VB6.TwipsToPixelsY(LPapel)
    '		DibujarLineas()
    '		ArreglarBarras()
    '	End Sub


    '	Public Sub mnuFileClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuFileClose.Click
    '		Dim r As String
    '		Dim tot As Short
    '		If DebeGrabar Then
    '			r = CStr(MsgBox("Grabar el formato antes de cerrar ?", MsgBoxStyle.YesNoCancel))
    '			If r = CStr(MsgBoxResult.Cancel) Then Exit Sub
    '			If r = CStr(MsgBoxResult.Yes) Then mnuFileSave_Click(mnuFileSave, New System.EventArgs())
    '		End If
    '		BorrarElementos()
    '		Nuevo = 0
    '		PorGrabar = False
    '		PonerBotones(False, False)
    '	End Sub

    '	Public Sub mnuHelpAbout_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuHelpAbout.Click
    '		VB6.ShowForm(AcercaDe, (1))
    '	End Sub

    '	'UPGRADE_ISSUE: PictureBox event Papel.KeyUp was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"'
    '	Private Sub Papel_KeyUp(ByRef KeyCode As Short, ByRef Shift As Short)
    '		If KeyCode = System.Windows.Forms.Keys.ShiftKey Then If TipoPintado.Value > "" Then BorrarPintados()
    '	End Sub
    '	Private Sub BorrarPintados()
    '		On Error Resume Next
    '		Dim i As Short
    '		For i = 1 To TotDat
    '			'UPGRADE_ISSUE: Label property Dato.BackStyle is not supported at runtime. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="74E732F3-CAD8-417B-8BC9-C205714BB4A7"'
    '			Dato(i).BackStyle = 0
    '		Next i
    '		For i = 1 To TotEti
    '			'UPGRADE_ISSUE: Label property Etiqueta.BackStyle is not supported at runtime. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="74E732F3-CAD8-417B-8BC9-C205714BB4A7"'
    '			Etiqueta(i).BackStyle = 0
    '		Next i
    '		TipoPintado.Value = ""
    '		TotPintados = 0
    '	End Sub
    '	Public Sub SelTodEtiquetas_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles SelTodEtiquetas.Click
    '		On Error Resume Next
    '		Dim i As Short
    '		If Actual Is Nothing Then Exit Sub
    '		'UPGRADE_WARNING: Couldn't resolve default property of object Actual.Name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '		If Actual.Name = "Etiqueta" Then
    '			For i = 1 To TotEti
    '				PintarCampo(Etiqueta(i))
    '			Next i
    '			If TotPintados > 0 Then TipoPintado.Value = "E"
    '		End If
    '	End Sub

    '	Public Sub SelTosDatos_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles SelTosDatos.Click
    '		On Error Resume Next
    '		Dim i As Short
    '		If Actual Is Nothing Then Exit Sub
    '		'UPGRADE_WARNING: Couldn't resolve default property of object Actual.Name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '		If Actual.Name = "Dato" Then
    '			For i = 1 To TotDat
    '				PintarCampo(Dato(i))
    '			Next i
    '			If TotPintados > 0 Then TipoPintado.Value = "D"
    '		End If
    '	End Sub

    '	Private Sub tbToolBar_ButtonClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _tbToolBar_Button1.Click, _tbToolBar_Button2.Click, _tbToolBar_Button3.Click, _tbToolBar_Button4.Click, _tbToolBar_Button5.Click, _tbToolBar_Button6.Click, _tbToolBar_Button7.Click, _tbToolBar_Button8.Click, _tbToolBar_Button9.Click, _tbToolBar_Button10.Click, _tbToolBar_Button11.Click, _tbToolBar_Button12.Click, _tbToolBar_Button13.Click, _tbToolBar_Button14.Click, _tbToolBar_Button15.Click, _tbToolBar_Button16.Click, _tbToolBar_Button17.Click, _tbToolBar_Button18.Click, _tbToolBar_Button19.Click, _tbToolBar_Button20.Click, _tbToolBar_Button21.Click, _tbToolBar_Button22.Click, _tbToolBar_Button23.Click, _tbToolBar_Button24.Click, _tbToolBar_Button25.Click, _tbToolBar_Button26.Click, _tbToolBar_Button27.Click, _tbToolBar_Button28.Click, _tbToolBar_Button29.Click, _tbToolBar_Button30.Click, _tbToolBar_Button31.Click, _tbToolBar_Button32.Click, _tbToolBar_Button33.Click, _tbToolBar_Button34.Click, _tbToolBar_Button35.Click, _tbToolBar_Button36.Click
    '		Dim Button As System.Windows.Forms.ToolStripItem = CType(eventSender, System.Windows.Forms.ToolStripItem)
    '		Dim resp As String
    '		On Error Resume Next
    '		marcador.Visible = False
    '		Select Case Button.Name
    '			Case "Nuevo"
    '				mnuFileNew_Click(mnuFileNew, New System.EventArgs())
    '			Case "Abrir"
    '				mnuFileOpen_Click(mnuFileOpen, New System.EventArgs())
    '			Case "Guardar"
    '				mnuFileSave_Click(mnuFileSave, New System.EventArgs())
    '			Case "cerrar"
    '				mnuFileClose_Click(mnuFileClose, New System.EventArgs())
    '			Case "Imprimir"
    '				mnuFilePrint_Click(mnuFilePrint, New System.EventArgs())
    '			Case "Negrita"
    '				'UPGRADE_WARNING: Couldn't resolve default property of object Actual.Name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '				'UPGRADE_WARNING: Couldn't resolve default property of object Actual.FontBold. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '				If Not (Actual.Name = "linea" Or Actual.Name = "imagen") Then Actual.FontBold = Not Actual.FontBold
    '			Case "Cursiva"
    '				'UPGRADE_WARNING: Couldn't resolve default property of object Actual.Name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '				'UPGRADE_WARNING: Couldn't resolve default property of object Actual.FontItalic. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '				If Not (Actual.Name = "linea" Or Actual.Name = "imagen") Then Actual.FontItalic = Not Actual.FontItalic
    '			Case "Subrayado"
    '				'UPGRADE_WARNING: Couldn't resolve default property of object Actual.Name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '				'UPGRADE_WARNING: Couldn't resolve default property of object Actual.FontUnderline. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '				If Not (Actual.Name = "linea" Or Actual.Name = "imagen") Then Actual.FontUnderline = Not Actual.FontUnderline
    '			Case "Alinear a la izquierda"
    '				'UPGRADE_WARNING: Couldn't resolve default property of object Actual.Name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '				'UPGRADE_WARNING: Couldn't resolve default property of object Actual.Alignment. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '				If Not (Actual.Name = "linea" Or Actual.Name = "imagen") Then Actual.Alignment = 0
    '				ALinea = 0
    '			Case "Centrar"
    '				'UPGRADE_WARNING: Couldn't resolve default property of object Actual.Name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '				'UPGRADE_WARNING: Couldn't resolve default property of object Actual.Alignment. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '				If Not (Actual.Name = "linea" Or Actual.Name = "imagen") Then Actual.Alignment = 2
    '				ALinea = 2
    '			Case "Alinear a la derecha"
    '				'UPGRADE_WARNING: Couldn't resolve default property of object Actual.Name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '				'UPGRADE_WARNING: Couldn't resolve default property of object Actual.Alignment. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '				If Not (Actual.Name = "linea" Or Actual.Name = "imagen") Then Actual.Alignment = 1
    '				ALinea = 1
    '			Case "Etiqueta"
    '				EtiquetaNueva()
    '			Case "Datos"
    '				DatoNuevo()
    '			Case "Imagen"
    '				ImagenNueva()
    '			Case "Línea"
    '				LineaNueva()
    '			Case "Cuadrado"
    '				CuadradoNuevo()
    '			Case "Eliminar"
    '				EliminarElemento()
    '			Case "Estilo de línea"
    '				'UPGRADE_WARNING: Couldn't resolve default property of object Actual.Name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '				If Actual.Name = "linea" Then PropiedadesLinea()
    '			Case "Propiedades"
    '				PropiedadesElementos()
    '				'        Case "DDatos"
    '				'             CambiarDatos
    '			Case "AlinHor"
    '				AlinHor_Click(AlinHor, New System.EventArgs())
    '			Case "AlinVer"
    '				AlinVer_Click(AlinVer, New System.EventArgs())
    '			Case "BMarco"
    '				VerMarco_Click(VerMarco, New System.EventArgs())
    '			Case "formularios"
    '				ImprimirFormularios()
    '			Case "eliminardoc"
    '				EliminarFormato(NombreArchivo)
    '			Case "salir"
    '				Me.Close()
    '		End Select
    '	End Sub

    '	Private Sub ImprimirFormularios()

    '	End Sub
    '	Private Sub PropiedadesElementos()
    '		Dim r As String
    '		On Error Resume Next
    '		If Actual Is Nothing Then Exit Sub
    '		'UPGRADE_WARNING: Couldn't resolve default property of object Actual.Name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '		Select Case Actual.Name
    '			Case "linea"
    '				PropLinea.ProLinea(linea(IndLin))
    '				poneralargadorlinea((IndLin))
    '			Case "Dato"
    '				PropDatos.PropDato(Dato(IndDat), "D", CambioValor)
    '				'UPGRADE_WARNING: Couldn't resolve default property of object Actual. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '				PonerAlargador(Actual)
    '			Case "Etiqueta"
    '				PropDatos.PropDato(Etiqueta(IndEt), "E", CambioValor)
    '				'UPGRADE_WARNING: Couldn't resolve default property of object Actual. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '				PonerAlargador(Actual)
    '			Case "CuadradoR"
    '				PropLinea.ProLinea(CuadradoR(IndCua))
    '				'UPGRADE_WARNING: Couldn't resolve default property of object Actual. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '				PonerAlargador(Actual)
    '		End Select

    '		If TotPintados > 0 Then
    '			r = CStr(MsgBox("Cambiar las propiedades de todos los Elementos seleccionados", MsgBoxStyle.YesNo))
    '			If r = CStr(MsgBoxResult.Yes) Then CambiarPropiedades()
    '		End If


    '	End Sub

    '	Private Sub CambiarPropiedades()
    '		Dim i As Short
    '		If Actual Is Nothing Then Exit Sub
    '		'Select Case Actual.Name
    '		'  Case "Dato"
    '		'UPGRADE_WARNING: Couldn't resolve default property of object Actual.Name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '		Select Case Actual.Name
    '			Case "Dato"
    '				With Dato(IndDat)
    '					For i = 1 To TotDat
    '						'UPGRADE_ISSUE: Label property Dato.BackStyle is not supported at runtime. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="74E732F3-CAD8-417B-8BC9-C205714BB4A7"'
    '						If Dato(i).Visible = True And Dato(i).BackStyle = 1 Then
    '							If CambioValor(0) = True Then Dato(i).TextAlign = .TextAlign
    '							If CambioValor(1) = True Then Dato(i).Font = VB6.FontChangeBold(Dato(i).Font, .Font.Bold)
    '							If CambioValor(2) = True Then Dato(i).Font = VB6.FontChangeItalic(Dato(i).Font, .Font.Italic)
    '							If CambioValor(3) = True Then Dato(i).Font = VB6.FontChangeName(Dato(i).Font, .Font.Name)
    '							If CambioValor(4) = True Then Dato(i).Font = VB6.FontChangeSize(Dato(i).Font, .Font.SizeInPoints)
    '							If CambioValor(5) = True Then Dato(i).Font = VB6.FontChangeUnderline(Dato(i).Font, .Font.Underline)
    '							If CambioValor(6) = True Then ToolTip1.SetToolTip(Dato(i), ToolTip1.GetToolTip(Dato(IndDat)))
    '							'UPGRADE_ISSUE: Label property Dato.DataField was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
    '							If CambioValor(7) = True Then Dato(i).DataField = .DataField
    '							'UPGRADE_ISSUE: Label property Dato.DataMember was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
    '							If CambioValor(8) = True Then Dato(i).DataMember = .DataMember
    '						End If
    '					Next 
    '				End With
    '			Case "Etiqueta"
    '				With Etiqueta(IndEt)
    '					For i = 1 To TotEti
    '						'UPGRADE_ISSUE: Label property Etiqueta.BackStyle is not supported at runtime. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="74E732F3-CAD8-417B-8BC9-C205714BB4A7"'
    '						If Etiqueta(i).Visible = True And Etiqueta(i).BackStyle = 1 Then
    '							If CambioValor(0) = True Then Etiqueta(i).TextAlign = .TextAlign
    '							If CambioValor(1) = True Then Etiqueta(i).Font = VB6.FontChangeBold(Etiqueta(i).Font, .Font.Bold)
    '							If CambioValor(2) = True Then Etiqueta(i).Font = VB6.FontChangeItalic(Etiqueta(i).Font, .Font.Italic)
    '							If CambioValor(3) = True Then Etiqueta(i).Font = VB6.FontChangeName(Etiqueta(i).Font, .Font.Name)
    '							If CambioValor(4) = True Then Etiqueta(i).Font = VB6.FontChangeSize(Etiqueta(i).Font, .Font.SizeInPoints)
    '							If CambioValor(5) = True Then Etiqueta(i).Font = VB6.FontChangeUnderline(Etiqueta(i).Font, .Font.Underline)
    '							If CambioValor(6) = True Then ToolTip1.SetToolTip(Etiqueta(i), ToolTip1.GetToolTip(Etiqueta(IndEt)))
    '							'UPGRADE_ISSUE: Label property Etiqueta.DataField was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
    '							If CambioValor(7) = True Then Etiqueta(i).DataField = .DataField
    '							'UPGRADE_ISSUE: Label property Etiqueta.DataMember was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
    '							If CambioValor(8) = True Then Etiqueta(i).DataMember = .DataMember
    '						End If
    '					Next 
    '				End With
    '		End Select
    '		BorrarPintados()
    '	End Sub
    '	'Private Sub mnuViewOptions_Click()
    '	'ImprimirEjemplo.Show (1)
    '	'End Sub

    '	Public Sub mnuViewStatusBar_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuViewStatusBar.Click
    '		On Error Resume Next
    '		mnuViewStatusBar.Checked = Not mnuViewStatusBar.Checked
    '		BarraEstado.Visible = mnuViewStatusBar.Checked
    '		DisForma_Resize(Me, New System.EventArgs())
    '	End Sub

    '	Public Sub mnuViewToolbar_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuViewToolbar.Click
    '		mnuViewToolbar.Checked = Not mnuViewToolbar.Checked
    '		tbToolBar.Visible = mnuViewToolbar.Checked
    '		DisForma_Resize(Me, New System.EventArgs())
    '	End Sub

    '	Public Sub mnuFileExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuFileExit.Click
    '		Dim r As String
    '		r = CStr(MsgBox("Confirma salir de TEKFORM ?", MsgBoxStyle.YesNo))
    '		If r = CStr(MsgBoxResult.Yes) Then Me.Close()
    '	End Sub

    '	Public Sub mnuFilePrint_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuFilePrint.Click
    '		Dim Printer As New Printer
    '		DibujarImpresion(Printer)
    '		Printer.EndDoc()
    '	End Sub

    '	Public Sub mnuFilePrintPreview_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuFilePrintPreview.Click
    '		DibujarImpresion((Previsual.papelito))
    '		Previsual.TA_Click(Nothing, New System.EventArgs())
    '		VB6.ShowForm(Previsual, (1))
    '	End Sub

    '	Private Sub PropiedadesLinea()
    '		PropLinea.ProLinea(linea(IndLin))
    '	End Sub
    '	Private Sub PropiedadesCuadrado()
    '		PropLinea.ProLinea(CuadradoR(IndCua))
    '	End Sub

    '	Public Sub mnuFilePageSetup_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuFilePageSetup.Click
    '		On Error Resume Next
    '		'UPGRADE_WARNING: CommonDialog variable was not upgraded Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="671167DC-EA81-475D-B690-7A40C7BF4A23"'
    '		With dlgCommonDialog
    '			.Title = "Configurar página"
    '			'UPGRADE_WARNING: The CommonDialog CancelError property is not supported in Visual Basic .NET. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="8B377936-3DF7-4745-AA26-DD00FA5B9BE1"'
    '			.CancelError = True
    '			.ShowDialog()
    '		End With

    '	End Sub

    '	Public Sub mnuFileSaveAs_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuFileSaveAs.Click
    '		On Error Resume Next
    '		Dim nom As String
    '		Dim Des As String
    '		Dim prog As New IngresaNombreformato
    '		prog.IngresaNombre(nom, Des)
    '		'VerNombre "S"
    '		If Len(nom) = 0 Then Exit Sub
    '		NombreArchivo = nom
    '		DescripcionArchivo = Des
    '		GuardarArchivo()
    '		PorGrabar = False
    '		PonerBotones(False, False)
    '		PonerTitulo()
    '	End Sub

    '	Public Sub mnuFileSave_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuFileSave.Click
    '		If Len(NombreArchivo) = 0 Then mnuFileSaveAs_Click(mnuFileSaveAs, New System.EventArgs())
    '		GuardarArchivo()
    '		PorGrabar = False
    '		PonerBotones(False, False)
    '	End Sub

    '	Public Sub mnuFileOpen_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuFileOpen.Click
    '		Dim Opcion As Integer
    '		Dim nom As String
    '		On Error Resume Next
    '		If DebeGrabar Then
    '			Opcion = MsgBox("Desea grabar el registro actual ? " & NombreArchivo, MsgBoxStyle.Exclamation + MsgBoxStyle.YesNoCancel)
    '			If Opcion = MsgBoxResult.Cancel Then Exit Sub
    '			If Opcion = MsgBoxResult.Yes Then mnuFileSave_Click(mnuFileSave, New System.EventArgs())
    '		End If
    '		nom = VerNombre("O")
    '		If Len(nom) = 0 Then Exit Sub
    '		If MsgBox("Confirma abrir el formato: " & vbCr & nom, MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
    '		CargarArchivo(nom)
    '		PonerBotones(False, False)
    '	End Sub

    '	Private Function VerNombre(ByRef Q As String) As String
    '		Dim prog As New BuscaFormasDoc
    '		VerNombre = SoloNombre(prog.IniciaBuscaClase(""))
    '		'UPGRADE_NOTE: Object prog may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
    '		prog = Nothing
    '	End Function

    '	Public Sub mnuFileNew_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuFileNew.Click
    '		Dim resp As String
    '		On Error Resume Next
    '		resp = CStr(MsgBox("Confirma Iniciar un nuevo formato ? ", MsgBoxStyle.YesNo))
    '		If resp = CStr(MsgBoxResult.Yes) Then
    '			BorrarElementos()
    '			BorrarAlargadores()
    '			NombreArchivo = ""
    '			PonerTitulo()
    '			CambiarOpcionDatos(True)
    '			PorGrabar = False
    '			Nuevo = 1
    '			PonerBotones(True, False)
    '		End If
    '	End Sub

    '	Private Sub MarcLin_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MarcLin.DoubleClick
    '		Dim index As Short = MarcLin.GetIndex(eventSender)
    '		PropiedadesLinea()
    '	End Sub

    '	Private Sub MarCuad_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MarCuad.DoubleClick
    '		Dim index As Short = MarCuad.GetIndex(eventSender)
    '		PropiedadesCuadrado()
    '	End Sub

    '	Private Sub Dato_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Dato.DoubleClick
    '		Dim index As Short = Dato.GetIndex(eventSender)
    '		On Error Resume Next
    '		Datos.EsDeConsulta = NombreConsulta
    '		VB6.ShowForm(Datos, (1))
    '		IndDat = index
    '		If Pasar > "" Then Dato(IndDat).Text = Pasar : Dato(IndDat).Tag = Tipo
    '		Actual = Dato(IndDat)
    '	End Sub

    '	Private Sub Etiqueta_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Etiqueta.DoubleClick
    '		Dim index As Short = Etiqueta.GetIndex(eventSender)
    '		On Error Resume Next
    '		IndEt = index
    '		With Text1
    '			.Text = Etiqueta(index).Text
    '			.Font = VB6.FontChangeName(.Font, Etiqueta(index).Font.Name)
    '			.Font = VB6.FontChangeSize(.Font, Etiqueta(index).Font.SizeInPoints)
    '			.ForeColor = Etiqueta(index).ForeColor
    '			.Font = VB6.FontChangeBold(.Font, Etiqueta(index).Font.Bold)
    '			.Font = VB6.FontChangeItalic(.Font, Etiqueta(index).Font.Italic)
    '			.Font = VB6.FontChangeStrikeOut(.Font, Etiqueta(index).Font.StrikeOut)
    '			.Font = VB6.FontChangeUnderline(.Font, Etiqueta(index).Font.Underline)
    '			.SetBounds(Etiqueta(index).Left, Etiqueta(index).Top, Etiqueta(index).Width, Etiqueta(index).Height)
    '			.Visible = True
    '			.Focus()
    '			'Etiqueta(IndEt).Visible = False
    '			Actual = Etiqueta(IndEt)
    '		End With
    '	End Sub

    '	Private Sub MarcLin_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles MarcLin.MouseDown
    '		Dim Button As Short = eventArgs.Button \ &H100000
    '		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '		Dim index As Short = MarcLin.GetIndex(eventSender)
    '		On Error Resume Next
    '		X1 = X
    '		Y1 = Y
    '		'UPGRADE_ISSUE: Label method MarcLin.Drag was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
    '		MarcLin(index).Drag()
    '		MarcLin(index).Visible = False
    '		IndLin = index
    '		BorrarAlargadores()
    '		Actual = linea(index)
    '	End Sub

    '	Private Sub MarCuad_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles MarCuad.MouseDown
    '		Dim Button As Short = eventArgs.Button \ &H100000
    '		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '		Dim index As Short = MarCuad.GetIndex(eventSender)
    '		On Error Resume Next
    '		If index = 0 Then MarCuad(index).Visible = False : Exit Sub
    '		X1 = X
    '		Y1 = Y
    '		'UPGRADE_ISSUE: Label method MarCuad.Drag was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
    '		MarCuad(index).Drag()
    '		MarCuad(index).Visible = False
    '		IndCua = index
    '		BorrarAlargadores()
    '		Actual = CuadradoR(index)
    '	End Sub

    '	Private Sub Imagen_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles Imagen.MouseDown
    '		Dim Button As Short = eventArgs.Button \ &H100000
    '		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '		Dim index As Short = Imagen.GetIndex(eventSender)
    '		On Error Resume Next
    '		X1 = X
    '		Y1 = Y
    '		'UPGRADE_ISSUE: Image method Imagen.Drag was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
    '		Imagen(index).Drag()
    '		Imagen(index).Visible = False
    '		IndImg = index
    '		BorrarAlargadores()
    '		Actual = Imagen(index)
    '	End Sub

    '	Private Sub Dato_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles Dato.MouseDown
    '		Dim Button As Short = eventArgs.Button \ &H100000
    '		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '		Dim index As Short = Dato.GetIndex(eventSender)
    '		On Error Resume Next
    '		If Shift = 1 And Not Actual Is Nothing Then
    '			'UPGRADE_WARNING: Couldn't resolve default property of object Actual.Name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '			If Actual.Name = "Dato" Then CambiaPintura(Dato(index), TipoPintado.Value)
    '		Else
    '			X1 = X
    '			Y1 = Y
    '			'UPGRADE_ISSUE: Label method Dato.Drag was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
    '			Dato(index).Drag()
    '			Dato(index).Visible = False
    '			BorrarAlargadores()
    '			Text1.Visible = False
    '			IndDat = index
    '			Actual = Dato(index)
    '			If TipoPintado.Value > "" Then BorrarPintados()
    '		End If
    '	End Sub

    '	Private Sub Etiqueta_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles Etiqueta.MouseDown
    '		Dim Button As Short = eventArgs.Button \ &H100000
    '		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '		Dim index As Short = Etiqueta.GetIndex(eventSender)
    '		On Error Resume Next
    '		If Shift = 1 And Not Actual Is Nothing Then
    '			'UPGRADE_WARNING: Couldn't resolve default property of object Actual.Name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '			If Actual.Name = "Etiqueta" Then CambiaPintura(Etiqueta(index), TipoPintado.Value)
    '		Else
    '			X1 = X
    '			Y1 = Y
    '			'UPGRADE_ISSUE: Label method Etiqueta.Drag was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
    '			Etiqueta(index).Drag()
    '			Etiqueta(index).Visible = False
    '			BorrarAlargadores()
    '			Text1.Visible = False
    '			IndEt = index
    '			Actual = Etiqueta(index)
    '			If TipoPintado.Value > "" Then BorrarPintados()
    '		End If
    '	End Sub
    '	Private Sub BorrarAlargadores()
    '		Dim i As Short
    '		For i = 0 To 3
    '			Alarga(i).Visible = False
    '		Next 
    '	End Sub

    '	'UPGRADE_NOTE: HScroll1.Change was changed from an event to a procedure. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="4E2DC008-5EDA-4547-8317-C9316952674F"'
    '	'UPGRADE_WARNING: HScrollBar event HScroll1.Change has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
    '	Private Sub HScroll1_Change(ByVal newScrollValue As Integer)
    '		Papel.Left = VB6.TwipsToPixelsX(0 - newScrollValue)
    '		Papel.Focus()
    '	End Sub

    '	Private Sub HScroll1_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HScroll1.Enter
    '		HScroll1_Change(0)
    '	End Sub

    '	Private Sub Imagen_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Imagen.DoubleClick
    '		Dim index As Short = Imagen.GetIndex(eventSender)
    '		Dim bk As String
    '		IndImg = index
    '		bk = IngresaImagen(NomImagen(IndImg))
    '		NomImagen(IndImg) = bk
    '		If NomImagen(IndImg) > "" Then
    '			'UPGRADE_WARNING: Dir has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
    '			bk = Dir(NomImagen(IndImg))
    '			If Len(bk) > 0 Then Imagen(IndImg).Image = System.Drawing.Image.FromFile(PathImg & NomImagen(IndImg))
    '		End If
    '	End Sub


    '	Private Sub PAPEL_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles PAPEL.DoubleClick
    '		marcador.Top = VB6.TwipsToPixelsY(PY - VB6.PixelsToTwipsY(marcador.Height) / 2)
    '		marcador.Left = VB6.TwipsToPixelsX(PX - VB6.PixelsToTwipsX(marcador.Width) / 2)
    '		marcador.Visible = True
    '	End Sub

    '	'UPGRADE_ISSUE: PictureBox event PAPEL.DragDrop was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"'
    '	Private Sub PAPEL_DragDrop(ByRef Source As System.Windows.Forms.Control, ByRef X As Single, ByRef Y As Single)
    '		Dim T, L As Short
    '		Source.Top = VB6.TwipsToPixelsY(Y - Y1)
    '		Source.Left = VB6.TwipsToPixelsX(X - X1)
    '		ArreglarPaso(Source, X, Y)
    '	End Sub

    '	'UPGRADE_ISSUE: PictureBox event Papel.DragOver was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"'
    '	Private Sub Papel_DragOver(ByRef Source As System.Windows.Forms.Control, ByRef X As Single, ByRef Y As Single, ByRef State As Short)
    '		Dim T, L As Short
    '		If Source.Name = "MarcLin" Then
    '			T = VB6.PixelsToTwipsY(Source.Top)
    '			L = VB6.PixelsToTwipsX(Source.Left)
    '			Source.Top = VB6.TwipsToPixelsY(Y - Y1)
    '			Source.Left = VB6.TwipsToPixelsX(X - X1)
    '			With linea(IndLin)
    '				.X1 = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(.X1) + (VB6.PixelsToTwipsX(Source.Left) - L))
    '				.Y1 = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(.Y1) + (VB6.PixelsToTwipsY(Source.Top) - T))
    '				.X2 = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(.X2) + (VB6.PixelsToTwipsX(Source.Left) - L))
    '				.Y2 = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(.Y2) + (VB6.PixelsToTwipsY(Source.Top) - T))
    '			End With
    '		ElseIf Source.Name = "MarCuad" Then 
    '			Source.Top = VB6.TwipsToPixelsY(Y - Y1)
    '			Source.Left = VB6.TwipsToPixelsX(X - X1)
    '			'If IndCua = 0 Then Stop
    '			With CuadradoR(IndCua)
    '				.Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(Source.Top))
    '				.Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(Source.Left))
    '				'ArreglarPaso Source, X, Y
    '			End With
    '		End If

    '	End Sub

    '	Private Sub PAPEL_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles PAPEL.MouseDown
    '		Dim Button As Short = eventArgs.Button \ &H100000
    '		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '		PX = X
    '		PY = Y
    '		If Papel.Cursor Is System.Windows.Forms.Cursors.Cross Then
    '			linea(IndLin).X1 = VB6.TwipsToPixelsX(X)
    '			linea(IndLin).Y1 = VB6.TwipsToPixelsY(Y)
    '			linea(IndLin).X2 = VB6.TwipsToPixelsX(X)
    '			linea(IndLin).Y2 = VB6.TwipsToPixelsY(Y)
    '			linea(IndLin).Visible = True
    '			If IndLin > TotLin Then TotLin = IndLin
    '			EnLinea = True
    '			Actual = linea(IndLin)
    '		ElseIf Papel.Cursor Is System.Windows.Forms.Cursors.Arrow Then 
    '			With Cubridor
    '				.Top = VB6.TwipsToPixelsY(Y - VB6.PixelsToTwipsY(.Height))
    '				.Left = VB6.TwipsToPixelsX(X - VB6.PixelsToTwipsX(.Width))
    '				.Visible = True
    '				PosIni = Y
    '				ColIni = X
    '				'UPGRADE_ISSUE: PictureBox property Papel.AutoRedraw was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
    '				Papel.AutoRedraw = False
    '			End With
    '		End If
    '	End Sub
    '	Private Sub ponerP(ByRef X As Integer, ByRef Y As Integer)
    '		p1.Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(Papel.Left) + X - (VB6.PixelsToTwipsX(p1.Width) / 2))
    '		p2.Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(Papel.Top) + Y - (VB6.PixelsToTwipsY(p2.Height) / 2))
    '		p1.Text = CStr(System.Math.Round(X / paso, 1))
    '		p2.Text = CStr(System.Math.Round(Y / paso, 1))
    '	End Sub
    '	Private Sub Dato_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles Dato.MouseMove
    '		Dim Button As Short = eventArgs.Button \ &H100000
    '		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '		Dim index As Short = Dato.GetIndex(eventSender)
    '		p1.Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(Dato(index).Left) + X + VB6.PixelsToTwipsX(Soporte.Left) - VB6.PixelsToTwipsX(p1.Width) / 2)
    '		p2.Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(Dato(index).Top) + Y + VB6.PixelsToTwipsY(Soporte.Top) - VB6.PixelsToTwipsY(p2.Height) / 2)
    '		p1.Text = CStr(System.Math.Round((VB6.PixelsToTwipsX(Dato(index).Left) + X) / paso, 1))
    '		p2.Text = CStr(System.Math.Round((VB6.PixelsToTwipsY(Dato(index).Top) + Y) / paso, 1))
    '	End Sub

    '	Private Sub Etiqueta_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles Etiqueta.MouseMove
    '		Dim Button As Short = eventArgs.Button \ &H100000
    '		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '		Dim index As Short = Etiqueta.GetIndex(eventSender)
    '		p1.Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(Etiqueta(index).Left) + X + VB6.PixelsToTwipsX(Soporte.Left) - VB6.PixelsToTwipsX(p1.Width) / 2)
    '		p2.Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(Etiqueta(index).Top) + Y + VB6.PixelsToTwipsY(Soporte.Top) - VB6.PixelsToTwipsY(p2.Height) / 2)
    '		p1.Text = CStr(System.Math.Round((VB6.PixelsToTwipsX(Etiqueta(index).Left) + X) / paso, 1))
    '		p2.Text = CStr(System.Math.Round((VB6.PixelsToTwipsY(Etiqueta(index).Top) + Y) / paso, 1))
    '	End Sub

    '	Private Sub PAPEL_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles PAPEL.MouseMove
    '		Dim Button As Short = eventArgs.Button \ &H100000
    '		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '		p1.Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(Soporte.Left) + X - (VB6.PixelsToTwipsX(p1.Width) / 2) + VB6.PixelsToTwipsX(Papel.Left))
    '		p2.Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(Soporte.Top) + Y - (VB6.PixelsToTwipsY(p2.Height) / 2) + VB6.PixelsToTwipsY(Papel.Top))
    '		p1.Text = CStr(System.Math.Round(X / paso, 1))
    '		p2.Text = CStr(System.Math.Round(Y / paso, 1))
    '		If Papel.Cursor Is System.Windows.Forms.Cursors.Cross And EnLinea = True Then
    '			linea(IndLin).X2 = VB6.TwipsToPixelsX(X) : linea(IndLin).Y2 = VB6.TwipsToPixelsY(Y)
    '		ElseIf Papel.Cursor Is System.Windows.Forms.Cursors.Arrow And Cubridor.Visible = True Then 
    '			With Cubridor
    '				If Y <= PosIni Then
    '					.Height = VB6.TwipsToPixelsY(PosIni - Y)
    '					.Top = VB6.TwipsToPixelsY(Y)
    '				Else
    '					.Top = VB6.TwipsToPixelsY(PosIni)
    '					.Height = VB6.TwipsToPixelsY(Y - PosIni)
    '				End If

    '				If X <= ColIni Then
    '					.Width = VB6.TwipsToPixelsX(ColIni - X)
    '					.Left = VB6.TwipsToPixelsX(X)
    '				Else
    '					.Left = VB6.TwipsToPixelsX(ColIni)
    '					.Width = VB6.TwipsToPixelsX(X - ColIni)
    '				End If
    '			End With
    '			CubrirControles()
    '		End If
    '	End Sub

    '	Private Sub PAPEL_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles PAPEL.MouseUp
    '		Dim Button As Short = eventArgs.Button \ &H100000
    '		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '		If Not Papel.Cursor Is System.Windows.Forms.Cursors.Arrow Then Papel.Cursor = System.Windows.Forms.Cursors.Arrow : EnLinea = False : poneralargadorlinea((IndLin))
    '		Cubridor.Visible = False
    '		Cubridor.Height = VB6.TwipsToPixelsY(50)
    '		Cubridor.Width = VB6.TwipsToPixelsX(50)
    '		'UPGRADE_ISSUE: PictureBox property Papel.AutoRedraw was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
    '		Papel.AutoRedraw = True

    '	End Sub

    '	'UPGRADE_WARNING: Event Text1.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    '	Private Sub Text1_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Text1.TextChanged
    '		Etiqueta(IndEt).Text = Text1.Text
    '		Text1.Width = Etiqueta(IndEt).Width
    '		'UPGRADE_WARNING: Couldn't resolve default property of object Actual. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '		PonerAlargador(Actual)
    '	End Sub

    '	Private Sub Text1_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Text1.Leave
    '		Text1.Visible = False
    '	End Sub

    '	Public Sub VerMarco_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles VerMarco.Click
    '		Dim i As Short
    '		Dim j As Byte
    '		VerMarco.Checked = Not VerMarco.Checked
    '		j = IIf(VerMarco.Checked = True, 1, 0)
    '		For i = 1 To MaxDat
    '			Dato(i).BorderStyle = j
    '		Next i
    '		For i = 1 To MaxEti
    '			Etiqueta(i).BorderStyle = j
    '		Next i
    '		For i = 1 To MaxIma
    '			Imagen(i).BorderStyle = j
    '		Next i

    '	End Sub

    '	'UPGRADE_NOTE: VScroll1.Change was changed from an event to a procedure. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="4E2DC008-5EDA-4547-8317-C9316952674F"'
    '	'UPGRADE_WARNING: VScrollBar event VScroll1.Change has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
    '	Private Sub VScroll1_Change(ByVal newScrollValue As Integer)
    '		Papel.Top = VB6.TwipsToPixelsY(0 - newScrollValue)
    '		Papel.Focus()
    '	End Sub

    '	Private Sub VScroll1_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles VScroll1.Enter
    '		VScroll1_Change(0)
    '	End Sub

    '	Private Sub DibujarImpresion(ByRef Papel As Object)
    '		Dim Printer As New Printer
    '		Dim Cuantos As Byte
    '		Dim i, j As Short
    '		Dim Aux As String
    '		On Error Resume Next
    '		'UPGRADE_WARNING: Couldn't resolve default property of object Papel.ScaleMode. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '		Papel.ScaleMode = 1
    '		'UPGRADE_WARNING: Couldn't resolve default property of object Papel.Width. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '		Papel.Width = Printer.Width
    '		'UPGRADE_WARNING: Couldn't resolve default property of object Papel.Height. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '		Papel.Height = Printer.Height
    '		For i = 1 To TotDat

    '			With Dato(i)
    '				If .Visible = True Then
    '					'UPGRADE_WARNING: Couldn't resolve default property of object Papel.CurrentY. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '					Papel.CurrentY = VB6.PixelsToTwipsY(.Top)
    '					'UPGRADE_WARNING: Couldn't resolve default property of object Papel.Font. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '					Papel.Font = .Font.Name
    '					'UPGRADE_WARNING: Couldn't resolve default property of object Papel.FontBold. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '					Papel.FontBold = .Font.Bold
    '					'UPGRADE_WARNING: Couldn't resolve default property of object Papel.FontItalic. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '					Papel.FontItalic = .Font.Italic
    '					'UPGRADE_WARNING: Couldn't resolve default property of object Papel.FontName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '					Papel.FontName = .Font.Name
    '					'UPGRADE_WARNING: Couldn't resolve default property of object Papel.FontSize. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '					Papel.FontSize = .Font.SizeInPoints
    '					'UPGRADE_WARNING: Couldn't resolve default property of object Papel.FontUnderline. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '					Papel.FontUnderline = .Font.Underline
    '					Aux = ""
    '					'UPGRADE_ISSUE: Label property Dato.DataMember was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
    '					If Val(.DataMember) > 0 Then
    '						'UPGRADE_ISSUE: Label property Dato.DataMember was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
    '						For j = 1 To Val(.DataMember)
    '							Aux = Aux & .Text & "  "
    '						Next j
    '					Else : Aux = .Text
    '					End If
    '					'UPGRADE_ISSUE: Label property Dato.DataField was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
    '					Cuantos = IIf(Val(.DataField) > 0, Val(.DataField), 1)
    '					For j = 1 To Cuantos
    '						'UPGRADE_WARNING: Couldn't resolve default property of object Papel.CurrentX. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '						Papel.CurrentX = VB6.PixelsToTwipsX(.Left)
    '						'UPGRADE_WARNING: Couldn't resolve default property of object Papel.Print. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '						If ToolTip1.GetToolTip(Dato(i)) > "" Then
    '							Papel.Print(VB6.Format(Aux, ToolTip1.GetToolTip(Dato(i))))
    '						Else
    '							'UPGRADE_WARNING: Couldn't resolve default property of object Papel.Print. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '							Papel.Print(Aux)
    '						End If
    '					Next j
    '				End If
    '			End With
    '		Next i
    '		For i = 1 To TotEti
    '			With Etiqueta(i)
    '				If .Visible = True Then
    '					'UPGRADE_WARNING: Couldn't resolve default property of object Papel.CurrentX. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '					Papel.CurrentX = VB6.PixelsToTwipsX(.Left)
    '					'UPGRADE_WARNING: Couldn't resolve default property of object Papel.CurrentY. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '					Papel.CurrentY = VB6.PixelsToTwipsY(.Top)
    '					'UPGRADE_WARNING: Couldn't resolve default property of object Papel.Font. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '					Papel.Font = .Font.Name
    '					'UPGRADE_WARNING: Couldn't resolve default property of object Papel.FontBold. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '					Papel.FontBold = .Font.Bold
    '					'UPGRADE_WARNING: Couldn't resolve default property of object Papel.FontItalic. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '					Papel.FontItalic = .Font.Italic
    '					'UPGRADE_WARNING: Couldn't resolve default property of object Papel.FontName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '					Papel.FontName = .Font.Name
    '					'UPGRADE_WARNING: Couldn't resolve default property of object Papel.FontSize. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '					Papel.FontSize = .Font.SizeInPoints
    '					'UPGRADE_WARNING: Couldn't resolve default property of object Papel.FontUnderline. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '					Papel.FontUnderline = .Font.Underline
    '					'UPGRADE_WARNING: Couldn't resolve default property of object Papel.Print. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '					Papel.Print(.Text)
    '				End If
    '			End With
    '		Next i
    '		For i = 1 To TotLin
    '			With linea(i)
    '				If .Visible = True Then
    '					'UPGRADE_WARNING: Couldn't resolve default property of object Papel.DrawWidth. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '					Papel.DrawWidth = .BorderWidth
    '					'UPGRADE_WARNING: Couldn't resolve default property of object Papel.DrawStyle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '					Papel.DrawStyle = .BorderStyle - 1
    '					If .Visible = True Then
    '                        'UPGRADE_WARNING: Couldn't resolve default property of object Papel.Line. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '                        Papel.Line((VB6.PixelsToTwipsX(.X1)), VB6.PixelsToTwipsY(.Y1)) - (VB6.PixelsToTwipsX(.X2), VB6.PixelsToTwipsY(.Y2)))
    '					End If
    '				End If
    '			End With
    '		Next i

    '		For i = 1 To TotCua
    '			With CuadradoR(i)
    '				If .Visible = True Then
    '					'UPGRADE_WARNING: Couldn't resolve default property of object Papel.DrawWidth. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '					Papel.DrawWidth = .BorderWidth
    '					'UPGRADE_WARNING: Couldn't resolve default property of object Papel.DrawStyle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '					Papel.DrawStyle = .BorderStyle - 1
    '					If .Visible = True Then
    '						'                 Papel.Line (.Left, .Top)-(.Width, .Height), , B
    '						'UPGRADE_WARNING: Couldn't resolve default property of object Papel.Line. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '						Papel.Line((VB6.PixelsToTwipsX(.Left), VB6.PixelsToTwipsY(.Top)) - (VB6.PixelsToTwipsX(.Left) + VB6.PixelsToTwipsX(.Width), VB6.PixelsToTwipsY(.Top)))
    '						'UPGRADE_WARNING: Couldn't resolve default property of object Papel.Line. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '						Papel.Line((VB6.PixelsToTwipsX(.Left), VB6.PixelsToTwipsY(.Top)) - (VB6.PixelsToTwipsX(.Left), VB6.PixelsToTwipsY(.Top) + VB6.PixelsToTwipsY(.Height)))
    '						'UPGRADE_WARNING: Couldn't resolve default property of object Papel.Line. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '						Papel.Line((VB6.PixelsToTwipsX(.Left) + VB6.PixelsToTwipsX(.Width), VB6.PixelsToTwipsY(.Top) + VB6.PixelsToTwipsY(.Height)) - (VB6.PixelsToTwipsX(.Left), VB6.PixelsToTwipsY(.Top) + VB6.PixelsToTwipsY(.Height)))
    '						'UPGRADE_WARNING: Couldn't resolve default property of object Papel.Line. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '						Papel.Line((VB6.PixelsToTwipsX(.Left) + VB6.PixelsToTwipsX(.Width), VB6.PixelsToTwipsY(.Top) + VB6.PixelsToTwipsY(.Height)) - (VB6.PixelsToTwipsX(.Left) + VB6.PixelsToTwipsX(.Width), VB6.PixelsToTwipsY(.Top)))
    '					End If
    '				End If
    '			End With
    '		Next i

    '		For i = 1 To TotIma
    '			With Imagen(i)
    '				If .Visible = True Then
    '					'UPGRADE_WARNING: Couldn't resolve default property of object Papel.PaintPicture. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '					Papel.PaintPicture(Imagen(i).Image, VB6.PixelsToTwipsX(Imagen(i).Left), VB6.PixelsToTwipsY(Imagen(i).Top), VB6.PixelsToTwipsX(Imagen(i).Width), VB6.PixelsToTwipsY(Imagen(i).Height))
    '				End If
    '			End With
    '		Next i
    '	End Sub

    '	Private Sub IgualarCuadro()
    '		'UPGRADE_WARNING: Couldn't resolve default property of object Actual.Name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '		If Actual.Name = "linea" Then
    '			poneralargadorlinea((IndLin))
    '		Else
    '			'If Actual.Name = "TEXT" Then Cuadro.BorderColor = vbCyan Else Cuadro.BorderColor = vbBlack
    '			Cuadro.Visible = True
    '			'UPGRADE_WARNING: Couldn't resolve default property of object Actual.Top. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '			Cuadro.Top = VB6.TwipsToPixelsY(Actual.Top)
    '			'UPGRADE_WARNING: Couldn't resolve default property of object Actual.Left. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '			Cuadro.Left = VB6.TwipsToPixelsX(Actual.Left)
    '			'UPGRADE_WARNING: Couldn't resolve default property of object Actual.Width. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '			Cuadro.Width = VB6.TwipsToPixelsX(Actual.Width)
    '			'UPGRADE_WARNING: Couldn't resolve default property of object Actual.Height. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '			Cuadro.Height = VB6.TwipsToPixelsY(Actual.Height)
    '		End If
    '	End Sub

    '	Private Sub PonerAlargador(ByRef Source As System.Windows.Forms.Control, Optional ByRef index As Short = 0)
    '		On Error Resume Next
    '		Dim a As String
    '		With Me
    '			.Alarga(0).Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(Source.Top) + VB6.PixelsToTwipsY(Source.Height) / 2 - VB6.PixelsToTwipsY(.Alarga(0).Height) / 2)
    '			.Alarga(0).Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(Source.Left) - VB6.PixelsToTwipsX(.Alarga(0).Width))
    '			.Alarga(0).Visible = True

    '			.Alarga(1).Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(Source.Top) - VB6.PixelsToTwipsY(.Alarga(1).Height))
    '			.Alarga(1).Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(Source.Left) + VB6.PixelsToTwipsX(Source.Width) / 2 - VB6.PixelsToTwipsX(.Alarga(1).Width) / 2)
    '			.Alarga(1).Visible = True

    '			.Alarga(2).Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(Source.Top) + VB6.PixelsToTwipsY(Source.Height) / 2 - VB6.PixelsToTwipsY(.Alarga(2).Height) / 2)
    '			.Alarga(2).Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(Source.Left) + VB6.PixelsToTwipsX(Source.Width))
    '			.Alarga(2).Visible = True

    '			.Alarga(3).Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(Source.Top) + VB6.PixelsToTwipsY(Source.Height))
    '			.Alarga(3).Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(Source.Left) + VB6.PixelsToTwipsX(Source.Width) / 2 - VB6.PixelsToTwipsX(.Alarga(1).Width) / 2)
    '			.Alarga(3).Visible = True
    '			Select Case Source.Name
    '				Case "Linea"
    '					'UPGRADE_WARNING: Couldn't resolve default property of object Source.index. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '					'UPGRADE_WARNING: Lower bound of collection DisForma.BarraEstado.Panels has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
    '					.BarraEstado.Items.Item(4).Text = "Linea" & "-" & Source.index
    '					'UPGRADE_WARNING: Couldn't resolve default property of object Source.Y2. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '					'UPGRADE_WARNING: Couldn't resolve default property of object Source.X2. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '					'UPGRADE_WARNING: Couldn't resolve default property of object Source.Y1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '					'UPGRADE_WARNING: Couldn't resolve default property of object Source.X1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '					'UPGRADE_WARNING: Lower bound of collection DisForma.BarraEstado.Panels has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
    '					.BarraEstado.Items.Item(5).Text = "Posicion: X1=" & System.Math.Round(Source.X1 / paso, 2) & "  " & "Y1=" & System.Math.Round(Source.Y1 / paso, 2) & " , " & "X2=" & System.Math.Round(Source.X2 / paso, 2) & "  " & "Y2=" & System.Math.Round(Source.Y2 / paso, 2) & " centimetros "
    '				Case "Etiqueta"
    '					'UPGRADE_WARNING: Couldn't resolve default property of object Source.index. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '					'UPGRADE_WARNING: Lower bound of collection DisForma.BarraEstado.Panels has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
    '					.BarraEstado.Items.Item(4).Text = "Etiqueta" & "-" & Source.index
    '					'Source.BorderStyle = 1
    '				Case "Imagen"
    '					'UPGRADE_WARNING: Couldn't resolve default property of object Source.index. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '					'UPGRADE_WARNING: Lower bound of collection DisForma.BarraEstado.Panels has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
    '					.BarraEstado.Items.Item(4).Text = "Imagen" & "-" & Source.index
    '					'Source.BorderStyle = 1
    '				Case "Dato"
    '					a = Source.Text
    '					'UPGRADE_WARNING: Lower bound of collection DisForma.BarraEstado.Panels has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
    '					.BarraEstado.Items.Item(4).Text = GenDatox.QUENOMBRE(a)
    '					'Source.BorderStyle = 1
    '				Case "CuadradoR"
    '					'UPGRADE_WARNING: Couldn't resolve default property of object Source.index. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '					'UPGRADE_WARNING: Lower bound of collection DisForma.BarraEstado.Panels has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
    '					.BarraEstado.Items.Item(4).Text = "Cuadrado" & "-" & Source.index
    '					'.BarraEstado.Panels(5).Text = "Posicion: X1=" & Round(.Left, 2) & "  " & "Y1=" & Round(.Top, 2) & " , " & "X2=" & Round(.Left + .Width, 2) & "  " & "Y2=" & Round(.Top + .Height, 2) & " centimetros "
    '					'If index = 0 Then Stop
    '					MarCuad(index).Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(Source.Top))
    '					MarCuad(index).Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(Source.Left))
    '					MarCuad(index).Visible = True
    '					MarCuad(index).Enabled = True

    '			End Select
    '			If Source.Name <> "Linea" Then
    '				'UPGRADE_WARNING: Lower bound of collection DisForma.BarraEstado.Panels has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
    '				.BarraEstado.Items.Item(5).Text = "Posicion: X=" & System.Math.Round(VB6.PixelsToTwipsX(Source.Left) / paso, 2) & "  " & "Y=" & System.Math.Round(VB6.PixelsToTwipsY(Source.Top) / paso, 2) & "  " & "Medidas: Ancho =" & System.Math.Round(VB6.PixelsToTwipsX(Source.Width) / paso, 2) & "  " & "Alto =" & System.Math.Round(VB6.PixelsToTwipsY(Source.Height) / paso, 2) & " centimetros "
    '			End If
    '		End With
    '		PorGrabar = True
    '		PonerBotones(PorGrabar, False)
    '	End Sub

    '	Private Sub poneralargadorlinea(ByRef index As Short)
    '		With linea(index)
    '			Alarga(0).Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(.Y1) - VB6.PixelsToTwipsY(Alarga(0).Height) / 2)
    '			Alarga(0).Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(.X1) - VB6.PixelsToTwipsX(Alarga(0).Width) / 2)
    '			Alarga(0).Visible = True

    '			Alarga(2).Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(.Y2) - VB6.PixelsToTwipsY(Alarga(2).Height) / 2)
    '			Alarga(2).Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(.X2) - VB6.PixelsToTwipsX(Alarga(2).Width) / 2)
    '			Alarga(2).Visible = True

    '			Alarga(1).Visible = False
    '			Alarga(3).Visible = False

    '			MarcLin(index).Top = VB6.TwipsToPixelsY(((VB6.PixelsToTwipsY(.Y1) + VB6.PixelsToTwipsY(.Y2)) / 2) - (VB6.PixelsToTwipsY(MarcLin(index).Height) / 2))
    '			MarcLin(index).Left = VB6.TwipsToPixelsX(((VB6.PixelsToTwipsX(.X1) + VB6.PixelsToTwipsX(.X2)) / 2) - (VB6.PixelsToTwipsX(MarcLin(index).Width) / 2))
    '			MarcLin(index).Visible = True
    '			MarcLin(index).Enabled = True
    '			'UPGRADE_WARNING: Lower bound of collection BarraEstado.Panels has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
    '			BarraEstado.Items.Item(4).Text = "Linea" & "-" & index
    '			'BarraEstado.Panels(5).Text = " Posicion X1=" & .X1 & "," & "Y1=" & .Y1 & ";" & "X2=" & .X2 & "," & "Y2=" & .Y2
    '			'UPGRADE_WARNING: Lower bound of collection BarraEstado.Panels has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
    '			BarraEstado.Items.Item(5).Text = "Posicion: X1=" & System.Math.Round(VB6.PixelsToTwipsX(.X1) / paso, 2) & "  " & "Y1=" & System.Math.Round(VB6.PixelsToTwipsY(.Y1) / paso, 2) & " , " & "X2=" & System.Math.Round(VB6.PixelsToTwipsX(.X2) / paso, 2) & "  " & "Y2=" & System.Math.Round(VB6.PixelsToTwipsY(.Y2) / paso, 2) & " centimetros "

    '		End With
    '		PorGrabar = True
    '		PonerBotones(PorGrabar, False)
    '	End Sub

    	Private Sub CargarArchivo(ByRef nom As String)
    		Dim L As Short
    		Dim ax As String
    		Dim DesysBak As New VB6.FixedLengthString(1)
    		Dim rs As New ADODB.Recordset
    		On Error Resume Next

    		'ax = Dir(PathForm & NombreArchivo)
    		rs.Open("select * from sysforms where l0 = '" & nom & "' order by S1 ", ConxAdcom, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
    		If rs.EOF Then rs.Close()
    		If rs.State = 0 Then MsgBox("El formato solicitado no existe" & nom) : Exit Sub
    		BorrarElementos()
    		NombreArchivo = nom
    		'Open PathForm & NombreArchivo For Input As #1
    		LeerPropiedades(rs.Fields("l1").Value)
    		Papel.Width = VB6.TwipsToPixelsX(APapel)
    		Papel.Height = VB6.TwipsToPixelsY(LPapel)

    		DesysBak.Value = DeSys.Value
    		CambiarOpcionDatos(False)
    		rs.MoveNext()
    		Do Until rs.EOF
    			If rs.EOF = False Then LeerLinea(rs.Fields("l1").Value)
    			Select Case Tipo
    				Case "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15"
    					If DesysBak.Value <> "P" And DesysBak.Value <> "A" Then
    						ax = GenDatox.QueNumero(Valor, Val(Tipo))
    						If ax > "" Then Valor = ax
    					End If
    					TotDat = TotDat + 1
    					Dato.Load(TotDat)
    					With Dato(TotDat)
    						.Visible = True
    						.Enabled = True
    						.Top = VB6.TwipsToPixelsY(Ftop)
    						.Left = VB6.TwipsToPixelsX(FLeft)
    						.Height = VB6.TwipsToPixelsY(FHeight)
    						.Width = VB6.TwipsToPixelsX(FWidth)
    						.Text = Valor
    						.Font = VB6.FontChangeName(.Font, FO)
    						.Font = VB6.FontChangeSize(.Font, fs)
    						.Font = VB6.FontChangeName(.Font, FN)
    						.Font = VB6.FontChangeBold(.Font, IIf(FB = 1, True, False))
    						.Font = VB6.FontChangeItalic(.Font, IIf(FI = 1, True, False))
    						.Font = VB6.FontChangeUnderline(.Font, IIf(FU = 1, True, False))
    						.Tag = Tipo
    						.TextAlign = ALinea
    						ToolTip1.SetToolTip(Dato(TotDat), RegresaForma(forma))
    						'UPGRADE_ISSUE: Label property Dato.DataField was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
    						.DataField = Numlin
    						'UPGRADE_ISSUE: Label property Dato.DataMember was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
    						.DataMember = NumHor
    						Actual = Dato(TotDat)
    					End With
    				Case "E"
    					TotEti = TotEti + 1
    					Etiqueta.Load(TotEti)
    					With Etiqueta(TotEti)
    						.Visible = True
    						.Enabled = True
    						.Top = VB6.TwipsToPixelsY(Ftop)
    						.Left = VB6.TwipsToPixelsX(FLeft)
    						.Height = VB6.TwipsToPixelsY(FHeight)
    						.Width = VB6.TwipsToPixelsX(FWidth)
    						.Text = Valor
    						.Font = VB6.FontChangeName(.Font, FO)
    						.Font = VB6.FontChangeSize(.Font, fs)
    						.Font = VB6.FontChangeName(.Font, FN)
    						.Font = VB6.FontChangeBold(.Font, IIf(FB = 1, True, False))
    						.Font = VB6.FontChangeItalic(.Font, IIf(FI = 1, True, False))
    						.Font = VB6.FontChangeUnderline(.Font, IIf(FU = 1, True, False))
    						.TextAlign = ALinea
    						Actual = Etiqueta(TotEti)
    					End With
    				Case "I"
    					If Valor > "" Then
    						TotIma = TotIma + 1
    						Imagen.Load(TotIma)
    						With Imagen(TotIma)
    							.Visible = True
    							.Enabled = True
    							.Top = VB6.TwipsToPixelsY(Ftop)
    							.Left = VB6.TwipsToPixelsX(FLeft)
    							.Height = VB6.TwipsToPixelsY(FHeight)
    							.Width = VB6.TwipsToPixelsX(FWidth)
    							NomImagen(TotIma) = Valor
    							.Image = System.Drawing.Image.FromFile(PathImg & Valor)
    							Actual = Imagen(TotIma)
    						End With
    					End If
    				Case "L"
    					TotLin = TotLin + 1
    					linea.Load(TotLin)
    					MarcLin.Load(TotLin)
    					With linea(TotLin)
    						.Visible = True
    						.Y1 = VB6.TwipsToPixelsY(Ftop)
    						.X1 = VB6.TwipsToPixelsX(FLeft)
    						.Y2 = VB6.TwipsToPixelsY(FHeight)
    						.X2 = VB6.TwipsToPixelsX(FWidth)
    						.BorderWidth = Val(Valor)
    						.BorderStyle = fs
    						poneralargadorlinea((TotLin))
    						Actual = linea(TotLin)
    					End With
    				Case "C"
    					TotCua = TotCua + 1
    					CuadradoR.Load(TotCua)
    					MarCuad.Load(TotCua)
    					With CuadradoR(TotCua)
    						.Visible = True
    						'.Enabled = True
    						.Top = VB6.TwipsToPixelsY(Ftop)
    						.Left = VB6.TwipsToPixelsX(FLeft)
    						.Height = VB6.TwipsToPixelsY(FHeight)
    						.Width = VB6.TwipsToPixelsX(FWidth)
    						.BorderWidth = IIf(Val(Valor) = 0, 1, Val(Valor))
    						' .BorderStyle = fs
    						Actual = CuadradoR(TotCua)
    						'UPGRADE_WARNING: Couldn't resolve default property of object Actual. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    						PonerAlargador(Actual, TotCua)
    					End With
    			End Select

    			rs.MoveNext()
    		Loop 
    		rs.Close()
    		'UPGRADE_NOTE: Object rs may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
    		rs = Nothing
    		MaxDat = TotDat
    		MaxEti = TotEti
    		MaxLin = TotLin
    		MaxIma = TotIma
    		MaxCua = TotCua
    		CambiarOpcionDatos(False)
    		PorGrabar = True
    		Nuevo = 2
    		PonerTitulo()
    	End Sub

    '	Private Sub CambiarOpcionDatos(ByRef Opcion As Boolean)
    '		'Ddatos.Enabled = Opcion
    '		'tbToolBar.Buttons(24).Enabled = Opcion
    '		DeSys.Value = "A"
    '		'If DeSys <= " " Then DeSys = "P"
    '		'If DeSys <> QueSistema Then QueSistema = DeSys:
    '		AbrirConexiones()
    '	End Sub

    '	Private Sub EliminarFormato(ByRef CualArchivo As String)

    '		If MsgBox("Confirma eliminar definitivamente el formato -" & CualArchivo & "-", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
    '			ConxAdcom.Execute("delete from sysforms where l0 = '" & CualArchivo & "'")
    '			BorrarElementos()
    '			'    BorrarAlargadores
    '			NombreArchivo = ""
    '			DescripcionArchivo = ""
    '			PonerTitulo()
    '		End If
    '	End Sub

    '	Private Sub GuardarArchivo()
    '		Dim L As Short
    '		Dim ax As String
    '		On Error Resume Next
    '		Dim rs As New ADODB.Recordset
    '		List1.Items.Clear()
    '		ConxAdcom.Execute("delete from sysforms where l0 = '" & NombreArchivo & "'")
    '		rs.Open("select * from sysforms where l0 = '" & NombreArchivo & "'", ConxAdcom, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
    '		rs.AddNew()
    '		rs.Fields("L0").Value = NombreArchivo
    '		rs.Fields("l1").Value = VB6.PixelsToTwipsX(Papel.Width) & Separador.Value & VB6.PixelsToTwipsY(Papel.Height) & Separador.Value & NroCopias & Separador.Value & CEsp(0) & Separador.Value & CEsp(1) & Separador.Value & CEsp(2) & Separador.Value & CEsp(3) & Separador.Value & MaqDin & Separador.Value & Acordeon & Separador.Value & DeSys.Value & Separador.Value & NombreConsulta & Separador.Value & IIf(SiImprimeRegistros, 1, 0) & Separador.Value & BaseConsulta & Separador.Value & DescripcionArchivo & Separador.Value & EsMultihoja
    '		rs.Fields("S1").Value = "A"
    '		rs.Fields("s2").Value = IIf(NombreConsulta > "", "E", "")
    '		rs.Fields("ln").Value = DescripcionArchivo
    '		rs.Update()
    '		For L = 1 To TotDat
    '			With Dato(L)
    '				If .Visible = True Then
    '					'UPGRADE_ISSUE: Label property Dato.DataMember was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
    '					'UPGRADE_ISSUE: Label property Dato.DataField was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
    '					List1.Items.Add("D" & VB.Right("00000000" & VB6.PixelsToTwipsY(.Top), 8) & Separador.Value & .Tag & Separador.Value & VB.Right("00000000" & VB6.PixelsToTwipsX(.Left), 8) & Separador.Value & VB6.PixelsToTwipsY(.Height) & Separador.Value & VB6.PixelsToTwipsX(.Width) & Separador.Value & .Text & Separador.Value & .Font.SizeInPoints & Separador.Value & .Font.Name & Separador.Value & .Font.Name & Separador.Value & IIf(.Font.Bold = True, 1, 0) & Separador.Value & IIf(.Font.Italic = True, 1, 0) & Separador.Value & IIf(.Font.Underline = True, 1, 0) & Separador.Value & ToolTip1.GetToolTip(Dato(L)) & Separador.Value & .DataField & Separador.Value & .TextAlign & Separador.Value & .DataMember)
    '				End If
    '			End With
    '		Next L

    '		For L = 1 To TotEti
    '			With Etiqueta(L)
    '				If .Visible = True Then
    '					List1.Items.Add("E" & VB.Right("00000000" & VB6.PixelsToTwipsY(.Top), 8) & Separador.Value & "E" & Separador.Value & VB.Right("00000000" & VB6.PixelsToTwipsX(.Left), 8) & Separador.Value & VB6.PixelsToTwipsY(.Height) & Separador.Value & VB6.PixelsToTwipsX(.Width) & Separador.Value & .Text & Separador.Value & .Font.SizeInPoints & Separador.Value & .Font.Name & Separador.Value & .Font.Name & Separador.Value & IIf(.Font.Bold = True, 1, 0) & Separador.Value & IIf(.Font.Italic = True, 1, 0) & Separador.Value & IIf(.Font.Underline = True, 1, 0) & Separador.Value & "0" & Separador.Value & "0" & Separador.Value & .TextAlign & Separador.Value & "0")
    '				End If
    '			End With
    '		Next L

    '		For L = 1 To TotIma
    '			With Imagen(L)
    '				If .Visible = True Then
    '					List1.Items.Add("I" & VB.Right("00000000" & VB6.PixelsToTwipsY(.Top), 8) & Separador.Value & "I" & Separador.Value & VB.Right("00000000" & VB6.PixelsToTwipsX(.Left), 8) & Separador.Value & VB6.PixelsToTwipsY(.Height) & Separador.Value & VB6.PixelsToTwipsX(.Width) & Separador.Value & NomImagen(L) & Separador.Value & "0" & Separador.Value & "0" & Separador.Value & "0" & Separador.Value & "0" & Separador.Value & "0" & Separador.Value & "0" & Separador.Value & "0" & Separador.Value & "0" & Separador.Value & "0" & Separador.Value & "0")
    '				End If
    '			End With
    '		Next L

    '		For L = 1 To TotLin
    '			With linea(L)
    '				If .Visible = True Then
    '					List1.Items.Add("L" & VB.Right("00000000" & VB6.PixelsToTwipsY(.Y1), 8) & Separador.Value & "L" & Separador.Value & VB6.PixelsToTwipsX(.X1) & Separador.Value & VB6.PixelsToTwipsY(.Y2) & Separador.Value & VB6.PixelsToTwipsX(.X2) & Separador.Value & .BorderWidth & Separador.Value & .BorderStyle & Separador.Value & "0" & Separador.Value & "0" & Separador.Value & "0" & Separador.Value & "0" & Separador.Value & "0" & Separador.Value & "0" & Separador.Value & "0" & Separador.Value & "0" & Separador.Value & "0")
    '				End If
    '			End With
    '		Next L

    '		For L = 1 To TotCua
    '			With CuadradoR(L)
    '				If .Visible = True Then
    '					List1.Items.Add("C" & VB.Right("00000000" & VB6.PixelsToTwipsY(.Top), 8) & Separador.Value & "C" & Separador.Value & VB6.PixelsToTwipsX(.Left) & Separador.Value & VB6.PixelsToTwipsY(.Height) & Separador.Value & VB6.PixelsToTwipsX(.Width) & Separador.Value & .BorderWidth & Separador.Value & .BorderStyle & Separador.Value & "0" & Separador.Value & "0" & Separador.Value & "0" & Separador.Value & "0" & Separador.Value & "0" & Separador.Value & "0" & Separador.Value & "0" & Separador.Value & "0" & Separador.Value & "0")
    '				End If
    '			End With
    '		Next L

    '		For L = 0 To List1.Items.Count - 1
    '			rs.AddNew()
    '			rs.Fields("L0").Value = NombreArchivo
    '			rs.Fields("l1").Value = Mid(VB6.GetItemString(List1, L), 2)
    '			rs.Fields("S1").Value = IIf(Mid(VB6.GetItemString(List1, L), 1, 1) = "I", "B", Mid(VB6.GetItemString(List1, L), 1, 1))
    '			rs.Fields("s2").Value = ""
    '			rs.Update()
    '		Next L
    '		rs.Close()
    '		'UPGRADE_NOTE: Object rs may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
    '		rs = Nothing
    '		PorGrabar = False
    '	End Sub

    '	Public Sub Guardar2006_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Guardar2006.Click
    '		Dim L As Short
    '		Dim ax As String
    '		Dim PathForm As String
    '		List1.Items.Clear()
    '		'UPGRADE_WARNING: CommonDialog variable was not upgraded Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="671167DC-EA81-475D-B690-7A40C7BF4A23"'
    '		With dlgCommonDialog
    '			.Title = "Guardar formato Adcom2006"
    '			'UPGRADE_WARNING: The CommonDialog CancelError property is not supported in Visual Basic .NET. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="8B377936-3DF7-4745-AA26-DD00FA5B9BE1"'
    '			.CancelError = False
    '			'UPGRADE_WARNING: Filter has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
    '			.Filter = "Todos los archivos (*.FGD)|*.FGD"
    '			.DefaultExt = "FGD"
    '			.InitialDirectory = PathForm
    '			.ShowDialog()
    '			If Len(.FileName) > 0 Then
    '				NombreArchivo = SoloNombre(.FileName)
    '			End If
    '		End With
    '		If NombreArchivo = "" Then Exit Sub
    '		FileOpen(1, PathForm & NombreArchivo, OpenMode.Output)
    '		PrintLine(1, VB6.PixelsToTwipsX(Papel.Width) & Separador.Value & VB6.PixelsToTwipsY(Papel.Height) & Separador.Value & NroCopias & Separador.Value & CEsp(0) & Separador.Value & CEsp(1) & Separador.Value & CEsp(2) & Separador.Value & CEsp(3) & Separador.Value & MaqDin & Separador.Value & Acordeon & Separador.Value & DeSys.Value)

    '		For L = 1 To TotDat
    '			With Dato(L)
    '				If .Visible = True Then
    '					'UPGRADE_ISSUE: Label property Dato.DataMember was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
    '					'UPGRADE_ISSUE: Label property Dato.DataField was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
    '					List1.Items.Add(VB.Right("00000000" & VB6.PixelsToTwipsY(.Top), 8) & Separador.Value & .Tag & Separador.Value & VB6.PixelsToTwipsX(.Left) & Separador.Value & VB6.PixelsToTwipsY(.Height) & Separador.Value & VB6.PixelsToTwipsX(.Width) & Separador.Value & .Text & Separador.Value & .Font.SizeInPoints & Separador.Value & .Font.Name & Separador.Value & .Font.Name & Separador.Value & IIf(.Font.Bold = True, 1, 0) & Separador.Value & IIf(.Font.Italic = True, 1, 0) & Separador.Value & IIf(.Font.Underline = True, 1, 0) & Separador.Value & ToolTip1.GetToolTip(Dato(L)) & Separador.Value & .DataField & Separador.Value & .TextAlign & Separador.Value & .DataMember)
    '				End If
    '			End With
    '		Next L

    '		For L = 1 To TotEti
    '			With Etiqueta(L)
    '				If .Visible = True Then
    '					List1.Items.Add(VB.Right("00000000" & VB6.PixelsToTwipsY(.Top), 8) & Separador.Value & "E" & Separador.Value & VB6.PixelsToTwipsX(.Left) & Separador.Value & VB6.PixelsToTwipsY(.Height) & Separador.Value & VB6.PixelsToTwipsX(.Width) & Separador.Value & .Text & Separador.Value & .Font.SizeInPoints & Separador.Value & .Font.Name & Separador.Value & .Font.Name & Separador.Value & IIf(.Font.Bold = True, 1, 0) & Separador.Value & IIf(.Font.Italic = True, 1, 0) & Separador.Value & IIf(.Font.Underline = True, 1, 0) & Separador.Value & "0" & Separador.Value & "0" & Separador.Value & .TextAlign & Separador.Value & "0")
    '				End If
    '			End With
    '		Next L

    '		For L = 1 To TotIma
    '			With Imagen(L)
    '				If .Visible = True Then
    '					List1.Items.Add(VB.Right("00000000" & VB6.PixelsToTwipsY(.Top), 8) & Separador.Value & "I" & Separador.Value & VB6.PixelsToTwipsX(.Left) & Separador.Value & VB6.PixelsToTwipsY(.Height) & Separador.Value & VB6.PixelsToTwipsX(.Width) & Separador.Value & NomImagen(L) & Separador.Value & "0" & Separador.Value & "0" & Separador.Value & "0" & Separador.Value & "0" & Separador.Value & "0" & Separador.Value & "0" & Separador.Value & "0" & Separador.Value & "0" & Separador.Value & "0" & Separador.Value & "0")
    '				End If
    '			End With
    '		Next L

    '		For L = 1 To TotLin
    '			With linea(L)
    '				If .Visible = True Then
    '					List1.Items.Add(VB.Right("00000000" & VB6.PixelsToTwipsY(.Y1), 8) & Separador.Value & "L" & Separador.Value & VB6.PixelsToTwipsX(.X1) & Separador.Value & VB6.PixelsToTwipsY(.Y2) & Separador.Value & VB6.PixelsToTwipsX(.X2) & Separador.Value & .BorderWidth & Separador.Value & .BorderStyle & Separador.Value & "0" & Separador.Value & "0" & Separador.Value & "0" & Separador.Value & "0" & Separador.Value & "0" & Separador.Value & "0" & Separador.Value & "0" & Separador.Value & "0" & Separador.Value & "0")
    '				End If
    '			End With
    '		Next L

    '		For L = 1 To TotCua
    '			With CuadradoR(L)
    '				If .Visible = True Then
    '					List1.Items.Add(VB.Right("00000000" & VB6.PixelsToTwipsY(.Top), 8) & Separador.Value & "C" & Separador.Value & VB6.PixelsToTwipsX(.Left) & Separador.Value & VB6.PixelsToTwipsY(.Height) & Separador.Value & VB6.PixelsToTwipsX(.Width) & Separador.Value & .BorderWidth & Separador.Value & .BorderStyle & Separador.Value & "0" & Separador.Value & "0" & Separador.Value & "0" & Separador.Value & "0" & Separador.Value & "0" & Separador.Value & "0" & Separador.Value & "0" & Separador.Value & "0" & Separador.Value & "0")
    '				End If
    '			End With
    '		Next L

    '		For L = 0 To List1.Items.Count
    '			PrintLine(1, VB6.GetItemString(List1, L))
    '		Next L
    '		FileClose(1)
    '		PorGrabar = False
    '	End Sub

    '	Private Sub EliminarElemento()
    '		Dim resp As String
    '		Dim CC As System.Windows.Forms.Control
    '		On Error Resume Next
    '		'UPGRADE_WARNING: Couldn't resolve default property of object Actual.Name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '		If Not Actual.Name > "" Then Exit Sub

    '		If TotPintados > 0 Then
    '			If MsgBox("Confirma eliminar todos los elementos marcados ? ", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Diseñador de formularios") = MsgBoxResult.Yes Then
    '				EliminarMarcados()
    '			End If
    '		Else
    '			'UPGRADE_WARNING: Lower bound of collection BarraEstado.Panels has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
    '			'UPGRADE_WARNING: Couldn't resolve default property of object Actual.Name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '			resp = CStr(MsgBox("Confirma eliminar " & Actual.Name & ": " & BarraEstado.Items.Item(4).Text, MsgBoxStyle.YesNo, "Diseñador de formularios"))
    '			If resp = CStr(MsgBoxResult.Yes) Then
    '				'UPGRADE_WARNING: Couldn't resolve default property of object Actual.Visible. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '				Actual.Visible = False
    '				BorrarAlargadores()
    '				'UPGRADE_WARNING: Couldn't resolve default property of object Actual.Name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '				If Actual.Name = "linea" Then MarcLin(IndLin).Visible = False
    '				'UPGRADE_WARNING: Couldn't resolve default property of object Actual.Name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '				If Actual.Name = "CuadradoR" Then MarCuad(IndCua).Visible = False
    '			End If
    '		End If
    '	End Sub

    '	Private Sub BorrarElementos()
    '		Dim Printer As New Printer
    '		Dim i As Short
    '		For i = 1 To MaxDat
    '			Dato.Unload(i)
    '		Next i
    '		MaxDat = 0

    '		For i = 1 To MaxEti
    '			Etiqueta.Unload(i)
    '		Next i
    '		MaxEti = 0

    '		For i = 1 To MaxLin
    '			linea.Unload(i)
    '			MarcLin.Unload(i)
    '		Next i
    '		MaxLin = 0

    '		For i = 1 To MaxCua
    '			CuadradoR.Unload(i)
    '			MarCuad.Unload(i)
    '		Next i
    '		MaxCua = 0


    '		For i = 1 To MaxIma
    '			Imagen.Unload(i)
    '		Next i
    '		MaxIma = 0

    '		AlargaIzquierda = False
    '		AlargaDerecha = False
    '		AlargaArriba = False
    '		AlargaAbajo = False
    '		ALinea = 0
    '		TotDat = 0
    '		TotEti = 0
    '		TotLin = 0
    '		TotIma = 0
    '		TotCua = 0
    '		Papel.Top = 0
    '		Papel.Left = 0
    '		Papel.Height = VB6.TwipsToPixelsY(Printer.Height)
    '		Papel.Width = VB6.TwipsToPixelsX(Printer.Width)
    '		Papel.Cursor = System.Windows.Forms.Cursors.Arrow
    '		NroCopias = 0
    '		EsMultihoja = 0
    '		TipoPintado.Value = ""
    '		APapel = VB6.PixelsToTwipsX(Papel.Width)
    '		LPapel = VB6.PixelsToTwipsY(Papel.Height)
    '		'NombreArchivo = ""
    '		BorrarAlargadores()
    '	End Sub

    '	Private Sub CambiarDatos()
    '		Dim r As String
    '		DeSys.Value = "A" 'EsBdatos.CambiarBaseDatos(QueSistema)
    '		'If DeSys <> QueSistema Then
    '		'   r = MsgBox("Seguro que desea cambiar de sistema de base de datos ?", vbYesNo)
    '		'   If r = vbYes Then CambiarOpcionDatos False
    '		'End If
    '		AbrirConexiones()
    '	End Sub

    '	Private Sub DibujarLineas()
    '		Dim Largo As Double
    '		Dim i, j As Integer
    '		'UPGRADE_ISSUE: PictureBox property Papel.DrawWidth was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
    '		Papel.DrawWidth = 1
    '		For i = paso To VB6.PixelsToTwipsX(Papel.Width) Step paso
    '			'UPGRADE_ISSUE: PictureBox method Papel.Line was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
    '			Papel.Line (i, 1) - (i, VB6.PixelsToTwipsY(Papel.Height))
    '		Next i
    '		For j = paso To VB6.PixelsToTwipsY(Papel.Height) Step paso
    '			'UPGRADE_ISSUE: PictureBox method Papel.Line was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
    '			Papel.Line (1, j) - (VB6.PixelsToTwipsX(Papel.Width), j)
    '		Next j
    '	End Sub

    '	Private Sub InsertarLineas(ByRef Cuantas As Double)
    '		Dim i As Short
    '		Dim TotLin As Integer
    '		Dim Marc As Integer
    '		On Error Resume Next
    '		TotLin = paso * Cuantas
    '		Marc = VB6.PixelsToTwipsY(marcador.Top) + VB6.PixelsToTwipsY(marcador.Height) / 2

    '		For i = 1 To TotEti
    '			If Etiqueta(i).Visible = True And VB6.PixelsToTwipsY(Etiqueta(i).Top) >= Marc Then Etiqueta(i).Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(Etiqueta(i).Top) + TotLin)
    '		Next i

    '		For i = 1 To TotDat
    '			If Dato(i).Visible = True And VB6.PixelsToTwipsY(Dato(i).Top) >= Marc Then Dato(i).Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(Dato(i).Top) + TotLin)
    '		Next i

    '		For i = 1 To TotIma
    '			If Imagen(i).Visible = True And VB6.PixelsToTwipsY(Imagen(i).Top) >= Marc Then Imagen(i).Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(Imagen(i).Top) + TotLin)
    '		Next i
    '		'UPGRADE_WARNING: Couldn't resolve default property of object Actual. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '		PonerAlargador(Actual)
    '	End Sub

    '	'Private Sub InsertarColumnas(Cuantas As Double)
    '	'Dim i As Integer, TotLin As Long
    '	'Dim Marc As Long
    '	'On Error Resume Next
    '	'TotLin = paso * Cuantas
    '	'Marc = marcador.Height + marcador.Width / 2
    '	'
    '	'For i = 1 To TotEti
    '	'If Etiqueta(i).Visible = True And Etiqueta(i).Height >= Marc Then Etiqueta(i).Height = Etiqueta(i).Height + TotLin
    '	'Next i
    '	'
    '	'For i = 1 To TotDat
    '	'If Dato(i).Visible = True And Dato(i).Height >= Marc Then Dato(i).Height = Dato(i).Height + TotLin
    '	'Next i
    '	'
    '	'For i = 1 To TotIma
    '	'If Imagen(i).Visible = True And Imagen(i).Height >= Marc Then Imagen(i).Height = Imagen(i).Height + TotLin
    '	'Next i
    '	'PonerAlargador Actual
    '	'End Sub

    '	Private Sub CubrirControles()
    '		Dim i As Short
    '		Dim TotLin As Integer
    '		Dim Derecha, Tope, Fondo, Izquierda As Integer
    '		On Error Resume Next
    '		Tope = VB6.PixelsToTwipsY(Cubridor.Top)
    '		Fondo = Tope + VB6.PixelsToTwipsY(Cubridor.Height)
    '		Izquierda = VB6.PixelsToTwipsX(Cubridor.Left)
    '		Derecha = Izquierda + VB6.PixelsToTwipsX(Cubridor.Width)

    '		For i = 1 To TotEti
    '			If Etiqueta(i).Visible = True And VB6.PixelsToTwipsY(Etiqueta(i).Top) >= Tope And VB6.PixelsToTwipsY(Etiqueta(i).Top) + VB6.PixelsToTwipsY(Etiqueta(i).Height) <= Fondo And VB6.PixelsToTwipsX(Etiqueta(i).Left) >= Izquierda And VB6.PixelsToTwipsX(Etiqueta(i).Left) + VB6.PixelsToTwipsX(Etiqueta(i).Width) <= Derecha Then
    '				PintarCampo(Etiqueta(i))
    '			Else
    '				'UPGRADE_ISSUE: Label property Etiqueta.BackStyle is not supported at runtime. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="74E732F3-CAD8-417B-8BC9-C205714BB4A7"'
    '				Etiqueta(i).BackStyle = 0
    '			End If
    '		Next i

    '		For i = 1 To TotDat
    '			If Dato(i).Visible = True And VB6.PixelsToTwipsY(Dato(i).Top) >= Tope And VB6.PixelsToTwipsY(Dato(i).Top) + VB6.PixelsToTwipsY(Dato(i).Height) <= Fondo And VB6.PixelsToTwipsX(Dato(i).Left) >= Izquierda And VB6.PixelsToTwipsX(Dato(i).Left) + VB6.PixelsToTwipsX(Dato(i).Width) <= Derecha Then
    '				PintarCampo(Dato(i))
    '			Else
    '				'UPGRADE_ISSUE: Label property Dato.BackStyle is not supported at runtime. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="74E732F3-CAD8-417B-8BC9-C205714BB4A7"'
    '				Dato(i).BackStyle = 0
    '			End If
    '		Next i
    '		PonerBotones(True, True)
    '	End Sub

    '	Private Sub EliminarMarcados()
    '		On Error Resume Next
    '		Dim i As Short
    '		For i = 1 To TotDat
    '			'UPGRADE_ISSUE: Label property Dato.BackStyle is not supported at runtime. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="74E732F3-CAD8-417B-8BC9-C205714BB4A7"'
    '			If Dato(i).BackStyle = 1 Then
    '				Dato(i).Visible = False
    '				'UPGRADE_ISSUE: Label property Dato.BackStyle is not supported at runtime. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="74E732F3-CAD8-417B-8BC9-C205714BB4A7"'
    '				Dato(i).BackStyle = 0
    '			End If
    '		Next i
    '		For i = 1 To TotEti
    '			'UPGRADE_ISSUE: Label property Etiqueta.BackStyle is not supported at runtime. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="74E732F3-CAD8-417B-8BC9-C205714BB4A7"'
    '			If Etiqueta(i).BackStyle = 1 Then
    '				Etiqueta(i).Visible = False
    '				'UPGRADE_ISSUE: Label property Etiqueta.BackStyle is not supported at runtime. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="74E732F3-CAD8-417B-8BC9-C205714BB4A7"'
    '				Etiqueta(i).BackStyle = 0
    '			End If
    '		Next i
    '		TipoPintado.Value = ""
    '		TotPintados = 0
    '		PonerBotones(True, False)
    '	End Sub
    '	Public Sub Mnuoi2006_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Mnuoi2006.Click
    '		''''' poner busqueda de directorio
    '		'Dim ElArchivo As String
    '		'With dlgCommonDialog
    '		'    .DialogTitle = "Importar formatos Adcom2006"
    '		'    .CancelError = False
    '		'    .Filter = "Todos los archivos (*.FGD)|*.FGD"
    '		'    .DefaultExt = "FGD"
    '		'    .InitDir = PathForm
    '		'    .ShowSave
    '		'    If Len(.FileName) > 0 Then
    '		'       NombreArchivo = SoloNombre(.FileName)
    '		'    End If
    '		'End With
    '		PasarFormas()
    '	End Sub

    '	Private Sub PasarFormas()
    '		Dim di As String
    '		Dim B As String
    '		Dim C As String
    '		Dim rs As New ADODB.Recordset
    '		Dim Tip() As String
    '		Dim cod As String
    '		Dim i As Integer
    '		Dim mm As String
    '		cod = "if not exists (select * from dbo.sysobjects where id = object_id(N'[SYSFORMS]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) " & " CREATE TABLE [dbo].[Sysforms]( " & " [L0] [varchar](50) COLLATE Modern_Spanish_CI_AS NOT NULL, " & " [L1] [varchar](1024) COLLATE Modern_Spanish_CI_AS NULL, " & " [S1] [char](1) COLLATE Modern_Spanish_CI_AS NULL, " & " [K0] [numeric](18, 0) IDENTITY(1,1) NOT NULL, " & " [Ln] [varchar](100) COLLATE Modern_Spanish_CI_AS NULL " & " ) ON [PRIMARY]"
    '		ConxAdcom.Execute(cod)
    '		If MsgBox("confirma pasar las formas de la version 2006", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
    '		di = InputBox("Digite el directorio donde se encuentran las formas tipo-2006")
    '		If VB.Right(di, 1) <> "/" Then di = di & "/"
    '		'UPGRADE_WARNING: Dir has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
    '		C = Dir(di & "*.fgd")
    '		B = ""
    '		i = 1
    '		Do While C <> ""
    '			B = B & C & ","
    '			'UPGRADE_WARNING: Dir has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
    '			C = Dir()
    '		Loop 
    '		rs.Open(" SELECT * FROM SYSFORMS", ConxAdcom, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
    '		If rs.EOF = False Then If MsgBox("Ya existen definidas formas de documentos, continuar con el proceso ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
    '		If VB.Right(B, 1) = "," Then i = 1 : B = Mid(B, 1, Len(B) - 1)
    '		Tip = Split(B, ",")
    '		For i = LBound(Tip, 1) To UBound(Tip, 1)
    '			FileOpen(1, di & Tip(i), OpenMode.Input)
    '			Do Until EOF(1)
    '				C = LineInput(1)
    '				If C > "" Then
    '					rs.AddNew()
    '					rs.Fields("L0").Value = Mid(Tip(i), 1, Len(Tip(i)) - 4)
    '					rs.Fields("l1").Value = C
    '					If Mid(C, 9, 1) = ";" Then
    '						mm = Mid(C, 10, 1)
    '						Select Case mm
    '							Case "D", "E", "I", "L", "C"
    '								rs.Fields("S1").Value = mm
    '							Case Else
    '								rs.Fields("S1").Value = "D"
    '						End Select
    '					Else
    '						rs.Fields("S1").Value = "A"
    '					End If
    '					rs.Update()
    '				End If
    '			Loop 
    '			FileClose(1)
    '		Next i
    '		rs.Close()
    '	End Sub

    '	Private Sub Timer1_Timer()
    '		On Error GoTo fIN
    '		If Emp.servidor = "" Then End
    '		Exit Sub
    'fIN: 
    '		End
    '	End Sub

    '	Private Sub PonerBotones(ByRef Estado As Boolean, ByRef Alinear As Boolean)
    '		Dim tot As Integer
    '		tot = TotEti + TotDat + TotLin + TotIma

    '		With tbToolBar
    '			.Items.Item("Nuevo").Enabled = Not PorGrabar
    '			.Items.Item("Abrir").Enabled = Not PorGrabar
    '			.Items.Item("Guardar").Enabled = PorGrabar
    '			.Items.Item("Imprimir").Enabled = (tot > 0)
    '			.Items.Item("Negrita").Enabled = Estado
    '			.Items.Item("Cursiva").Enabled = Estado
    '			.Items.Item("Subrayado").Enabled = Estado
    '			.Items.Item("Alinear a la izquierda").Enabled = Estado
    '			.Items.Item("Centrar").Enabled = Estado
    '			.Items.Item("Alinear a la derecha").Enabled = Estado
    '			.Items.Item("Etiqueta").Enabled = (Nuevo > 0)
    '			.Items.Item("Datos").Enabled = (Nuevo > 0)
    '			.Items.Item("Imagen").Enabled = (Nuevo > 0)
    '			.Items.Item("Cuadrado").Enabled = (Nuevo > 0)
    '			.Items.Item("Línea").Enabled = (Nuevo > 0)
    '			.Items.Item("Eliminar").Enabled = (Nuevo > 0)
    '			.Items.Item("Estilo de línea").Enabled = Estado
    '			.Items.Item("Propiedades").Enabled = Estado
    '			.Items.Item("AlinHor").Enabled = Alinear
    '			.Items.Item("AlinVer").Enabled = Alinear
    '			.Items.Item("BMarco").Enabled = (Nuevo > 0)
    '			'  .Buttons("formularios").Enabled = Estado
    '			.Items.Item("salir").Enabled = (Nuevo = 0)
    '		End With
    '	End Sub
    '	Private Function DebeGrabar() As Boolean
    '		Dim tot As Integer
    '		tot = TotEti + TotDat + TotLin + TotIma
    '		DebeGrabar = (tot > 0 And PorGrabar)
    '	End Function

    '	Private Sub PonerTitulo()
    '		Me.Text = "TEKFORM Diseñando documento : " & NombreArchivo & " - " & DescripcionArchivo
    '	End Sub

    '	Private Sub PintarCampo(ByRef Source As System.Windows.Forms.Label)
    '		If Source.Visible = True Then
    '			'UPGRADE_ISSUE: Label property Source.BackStyle is not supported at runtime. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="74E732F3-CAD8-417B-8BC9-C205714BB4A7"'
    '			Source.BackStyle = 1
    '			Source.BackColor = System.Drawing.ColorTranslator.FromOle(&HE0E0E0)
    '			TotPintados = TotPintados + 1
    '		End If
    '	End Sub

    '	Private Sub CambiaPintura(ByRef Source As System.Windows.Forms.Label, ByRef QuePinto As String)

    '		If Source.Name = "Dato" And QuePinto = "E" Then Exit Sub
    '		If Source.Name = "Etiqueta" And QuePinto = "D" Then Exit Sub
    '		'UPGRADE_ISSUE: Label property Source.BackStyle is not supported at runtime. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="74E732F3-CAD8-417B-8BC9-C205714BB4A7"'
    '		If Source.BackStyle = 0 Then
    '			'UPGRADE_ISSUE: Label property Source.BackStyle is not supported at runtime. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="74E732F3-CAD8-417B-8BC9-C205714BB4A7"'
    '			Source.BackStyle = 1
    '			Source.BackColor = System.Drawing.ColorTranslator.FromOle(&H808000)
    '			TotPintados = TotPintados + 1
    '			If TotPintados = 1 Then
    '				If Source.Name = "Dato" Then QuePinto = "D"
    '				If Source.Name = "Etiqueta" Then QuePinto = "E"
    '			End If
    '		Else
    '			'UPGRADE_ISSUE: Label property Source.BackStyle is not supported at runtime. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="74E732F3-CAD8-417B-8BC9-C205714BB4A7"'
    '			Source.BackStyle = 0
    '			TotPintados = TotPintados - 1
    '			If TotPintados = 0 Then QuePinto = ""
    '		End If

    '	End Sub

    '	Private Function SoloNombre(ByRef Archivo As String) As String
    '		Dim i, j As Short
    '		j = 0
    '		For i = Len(Archivo) To 1 Step -1
    '			If Mid(Archivo, i, 1) = "\" Or Mid(Archivo, i, 1) = "/" Then j = i : i = 1
    '		Next 
    '		SoloNombre = Mid(Archivo, j + 1)
    '	End Function

    '	Private Sub AbrirConexiones()
    '		On Error Resume Next
    '		GenDatox = New DaxLib.GenDatos
    '		GenDatox.Abrir("A")
    '		Me.Text = "Diseñador de Formularios para sistema"
    '		Me.Text = Me.Text & " ADCOMDX"
    '		'DisForma.tbToolBar.Buttons(24).Image = 28
    '	End Sub

    '	Private Sub LeerPropiedades(ByRef CampoTexto As String)
    '		Dim ax As String
    '		Dim i As Short
    '		On Error Resume Next

    '		''''' SI SE CAMBIA AQUI TAMBIEN CAMBIAR EN DLL. IMPDOC

    '		TextVal = Split(CampoTexto, ";")
    '		'If UBound(TextVal) < 0 Then MsgBox "Las propiedades del formato no están establecidas": Exit Sub
    '		APapel = Val(TextVal(0))
    '		LPapel = Val(TextVal(1))
    '		If IsNumeric(TextVal(2)) Then NroCopias = CShort(TextVal(2)) Else NroCopias = 1
    '		Acordeon = Val(TextVal(8))
    '		For i = 0 To 3
    '			CEsp(i) = Val(TextVal(i + 3))
    '		Next 
    '		MaqDin = Val(TextVal(7))
    '		DeSys.Value = TextVal(9)

    '		If UBound(TextVal) > 9 Then
    '			NombreConsulta = TextVal(10)
    '			SiImprimeRegistros = Val(TextVal(11))
    '			BaseConsulta = Val(TextVal(12))
    '		Else
    '			NombreConsulta = ""
    '			SiImprimeRegistros = 0
    '			BaseConsulta = CShort("")
    '		End If

    '		If UBound(TextVal) > 12 Then
    '			DescripcionArchivo = TextVal(13)
    '			EsMultihoja = Val(TextVal(14))
    '		Else
    '			DescripcionArchivo = ""
    '			EsMultihoja = 0
    '		End If

    '	End Sub

    '	Private Sub LeerLinea(ByRef CampoText As String)
    '		On Error Resume Next

    '		''''' SI SE CAMBIA AQUI TAMBIEN CAMBIAR EN DLL. IMPDOC

    '		'If RS.EOF = False Then
    '		'SepararTexto (Rs!L1)
    '		TextVal = Split(CampoText, ";")
    '		If Val(TextVal(0)) < 10 Then
    '			Tipo = TextVal(0)
    '			Ftop = Val(TextVal(1))
    '		Else
    '			Ftop = Val(TextVal(0))
    '			Tipo = TextVal(1)
    '		End If
    '		FLeft = Val(TextVal(2))
    '		FHeight = Val(TextVal(3))
    '		FWidth = Val(TextVal(4))
    '		Valor = TextVal(5)
    '		fs = Val(TextVal(6))
    '		FO = TextVal(7)
    '		FN = TextVal(8)
    '		FB = Val(TextVal(9))
    '		FI = Val(TextVal(10))
    '		FU = Val(TextVal(11))
    '		forma = TextVal(12)
    '		Numlin = Val(TextVal(13))
    '		ALinea = Val(TextVal(14))
    '		NumHor = Val(TextVal(15))
    '		'End If
    '	End Sub

    '	Private Function RegresaForma(ByRef forma As String) As String
    '		Dim i As Short
    '		Dim Formax As String
    '		RegresaForma = ""
    '		Formax = forma
    '		For i = 1 To Len(Formax)
    '			If Mid(Formax, i, 1) = "C" Then
    '				RegresaForma = RegresaForma & ","
    '			Else
    '				RegresaForma = RegresaForma & Mid(Formax, i, 1)
    '			End If
    '		Next 
    '	End Function
    '	Private Sub HScroll1_Scroll(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.ScrollEventArgs) Handles HScroll1.Scroll
    '		Select Case eventArgs.type
    '			Case System.Windows.Forms.ScrollEventType.EndScroll
    '				HScroll1_Change(eventArgs.newValue)
    '		End Select
    '	End Sub
    '	Private Sub VScroll1_Scroll(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.ScrollEventArgs) Handles VScroll1.Scroll
    '		Select Case eventArgs.type
    '			Case System.Windows.Forms.ScrollEventType.EndScroll
    '				VScroll1_Change(eventArgs.newValue)
    '		End Select
    '	End Sub
End Class