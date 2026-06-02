Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class SRIP01
	Inherits System.Windows.Forms.Form
	Dim borra As Boolean
	Dim ArchSalida As String
	
	Private Sub ArreglaMalla400()
		Dim I As Short
		
		With Malla400.LaMalla
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla400.LaMalla.Rows. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.Rows = 15
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla400.LaMalla.Cols. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.Cols = 7
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla400.LaMalla.FixedRows. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.FixedRows = 1
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla400.LaMalla.FixedCols. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.FixedCols = 1
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla400.LaMalla.Redraw. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.Redraw = False
			Malla400.MallaFija = True
			
			For I = 1 To 14
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla400.LaMalla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(I, 1) = I + 400 + IIf(I > 10, 10, 0)
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla400.LaMalla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(I, 3) = I + 410 + IIf(I > 10, 10, 0)
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla400.LaMalla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(I, 5) = I + 420 + IIf(I > 10, 10, 0)
			Next I
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla400.LaMalla.ColAlignment. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.ColAlignment(1) = 3
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla400.LaMalla.ColAlignment. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.ColAlignment(2) = 7
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla400.LaMalla.ColAlignment. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.ColAlignment(3) = 3
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla400.LaMalla.ColAlignment. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.ColAlignment(4) = 7
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla400.LaMalla.ColAlignment. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.ColAlignment(5) = 3
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla400.LaMalla.ColAlignment. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.ColAlignment(6) = 7
			
			Malla400.set_ColLock(1, True)
			Malla400.set_ColLock(3, True)
			Malla400.set_ColLock(5, True)
			
			Malla400.set_ColData(2, 12)
			Malla400.set_ColData(4, 12)
			Malla400.set_ColData(6, 12)
			
			
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla400.LaMalla.AllowBigSelection. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.AllowBigSelection = True
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla400.LaMalla.FillStyle. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.FillStyle = MSFlexGridLib.FillStyleSettings.flexFillRepeat
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla400.LaMalla.Row. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.Row = 0
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla400.LaMalla.col. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.col = 0
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla400.LaMalla.RowSel. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla400.LaMalla.FixedRows. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.RowSel = .FixedRows - 1
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla400.LaMalla.ColSel. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla400.LaMalla.Cols. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.ColSel = .Cols - 1
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla400.LaMalla.CellFontBold. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.CellFontBold = True
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla400.LaMalla.CellFontName. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.CellFontName = "Ms Serif"
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla400.LaMalla.CellFontSize. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.CellFontSize = 7
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla400.LaMalla.Row. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.Row = 1
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla400.LaMalla.RowSel. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla400.LaMalla.Rows. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.RowSel = .Rows - 1
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla400.LaMalla.CellFontName. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.CellFontName = "Ms Serif"
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla400.LaMalla.CellFontSize. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.CellFontSize = 7
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla400.LaMalla.CellFontBold. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.CellFontBold = False
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla400.LaMalla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.TextMatrix(0, 0) = "RESUMEN DE VENTAS Y OTRAS OPERACIONES DEL PERÍODO QUE DECLARA"
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla400.LaMalla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.TextMatrix(0, 2) = "VALOR BRUTO"
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla400.LaMalla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.TextMatrix(0, 4) = "VALOR NETO "
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla400.LaMalla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.TextMatrix(0, 6) = "IMP. GENERADO"
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla400.LaMalla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.TextMatrix(0, 1) = ""
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla400.LaMalla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.TextMatrix(0, 3) = ""
			
			' atenuar celdas
			AtenuarCeldas(1, 14, 1, 1, (Malla400.LaMalla))
			AtenuarCeldas(1, 14, 3, 3, (Malla400.LaMalla))
			AtenuarCeldas(1, 14, 5, 5, (Malla400.LaMalla))
			
			borra = True
			AtenuarCeldas(3, 8, 5, 6, (Malla400.LaMalla))
			AtenuarCeldas(10, 14, 1, 2, (Malla400.LaMalla))
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla400.LaMalla.Cols. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			AtenuarCeldas(10, 10, 0, .Cols - 1, (Malla400.LaMalla))
			AtenuarCeldas(10, 12, 5, 6, (Malla400.LaMalla))
			'AtenuarCeldas 14, 14, 6, 6, Malla400.LaMalla
			
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla400.LaMalla.AllowBigSelection. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.AllowBigSelection = False
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla400.LaMalla.FillStyle. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.FillStyle = MSFlexGridLib.FillStyleSettings.flexFillSingle
			
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla400.LaMalla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.TextMatrix(1, 0) = "VENTAS LOCALES (EXCLUYE ACTIVOS FIJOS) GRAVADAS TARIFA 12%"
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla400.LaMalla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.TextMatrix(2, 0) = "VENTAS DE ACTIVOS FIJOS GRAVADAS TARIFA 12%"
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla400.LaMalla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.TextMatrix(3, 0) = "VENTAS LOCALES (EXCLUYE ACTIVOS FIJOS) GRAVADAS TARIFA 0% QUE NO DAN DERECHO A CREDITO TRIBUTARIO)"
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla400.LaMalla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.TextMatrix(4, 0) = "VENTAS DE ACTIVOS FIJOS GRAVADAS TARIFA 0% QUE NO DAN DERECHO A CREDITO TRIBUTARIO"
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla400.LaMalla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.TextMatrix(5, 0) = "VENTAS LOCALES (EXCLUYE ACTIVOS FIJOS) GRAVADAS TARIFA 0% QUE DAN DERECHO A CREDITO TRIBUTARIO"
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla400.LaMalla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.TextMatrix(6, 0) = "VENTAS DE ACTIVOS FIJOS GRAVADAS TARIFA 0% QUE DAN DERECHO A CREDITO TRIBUTARIO"
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla400.LaMalla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.TextMatrix(7, 0) = "EXPORTACIONES DE BIENES"
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla400.LaMalla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.TextMatrix(8, 0) = "EXPORTACIONES DE SERVICIOS"
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla400.LaMalla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.TextMatrix(9, 0) = "TOTAL VENTAS Y OTRAS OPERACIONES"
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla400.LaMalla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.TextMatrix(10, 0) = ""
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla400.LaMalla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.TextMatrix(11, 0) = "TRANSFERENCIAS NO OBJETO DE IVA"
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla400.LaMalla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.TextMatrix(12, 0) = "NOTAS DE CRÉDITO TARIFA 0% POR COMPENSAR PRÓXIMO MES (INFORMATIVO)"
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla400.LaMalla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.TextMatrix(13, 0) = "NOTAS DE CRÉDITO TARIFA 12% POR COMPENSAR PRÓXIMO MES (INFORMATIVO)"
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla400.LaMalla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.TextMatrix(14, 0) = "INGRESOS POR REEMBOLSO COMO INTERMEDIARIO (INFORMATIVO)"
			'.TextMatrix(15, 0) = "Not.Créd.por transferencias netas objeto iva por compensar próximo mes"
			'.TextMatrix(16, 0) = "Ingreso neto por concepto reembolso de gastos del intermediario"
			'.TextMatrix(17, 0) = "Presuntivo Salas de Juego (Bingo - Mecánicos) y otros juegos de Azar "
			
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla400.LaMalla.ColWidth. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.ColWidth(0) = 7000
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla400.LaMalla.ColWidth. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.ColWidth(1) = 400
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla400.LaMalla.ColWidth. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.ColWidth(2) = 1400
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla400.LaMalla.ColWidth. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.ColWidth(3) = 400
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla400.LaMalla.ColWidth. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.ColWidth(4) = 1400
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla400.LaMalla.ColWidth. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.ColWidth(5) = 400
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla400.LaMalla.ColWidth. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.ColWidth(6) = 1400
			
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla400.LaMalla.Redraw. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.Redraw = True
		End With
	End Sub
	
	Private Sub Arreglamalla500()
		Dim I As Short
		borra = False
		With malla500.LaMalla
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla500.LaMalla.Rows. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.Rows = 15
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla500.LaMalla.Cols. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.Cols = 7
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla500.LaMalla.FixedRows. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.FixedRows = 1
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla500.LaMalla.FixedCols. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.FixedCols = 1
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla500.LaMalla.Redraw. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.Redraw = False
			malla500.MallaFija = True
			
			For I = 1 To 14
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla500.LaMalla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(I, 1) = I + 500 + IIf(I > 10, 10, 0)
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla500.LaMalla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(I, 3) = I + 510 + IIf(I > 10, 10, 0)
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla500.LaMalla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(I, 5) = I + 520 + IIf(I > 10, 10, 0)
			Next I
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla500.LaMalla.ColAlignment. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.ColAlignment(1) = 3
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla500.LaMalla.ColAlignment. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.ColAlignment(2) = 7
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla500.LaMalla.ColAlignment. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.ColAlignment(3) = 3
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla500.LaMalla.ColAlignment. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.ColAlignment(4) = 7
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla500.LaMalla.ColAlignment. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.ColAlignment(5) = 3
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla500.LaMalla.ColAlignment. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.ColAlignment(6) = 7
			malla500.set_ColLock(1, True)
			malla500.set_ColLock(3, True)
			malla500.set_ColLock(5, True)
			
			malla500.set_ColData(2, 12)
			malla500.set_ColData(4, 12)
			malla500.set_ColData(6, 12)
			
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla500.LaMalla.AllowBigSelection. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.AllowBigSelection = True
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla500.LaMalla.FillStyle. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.FillStyle = MSFlexGridLib.FillStyleSettings.flexFillRepeat
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla500.LaMalla.Row. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.Row = 0
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla500.LaMalla.col. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.col = 0
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla500.LaMalla.RowSel. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla500.LaMalla.FixedRows. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.RowSel = .FixedRows - 1
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla500.LaMalla.ColSel. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla500.LaMalla.Cols. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.ColSel = .Cols - 1
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla500.LaMalla.CellFontBold. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.CellFontBold = True
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla500.LaMalla.CellFontName. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.CellFontName = "Ms Serif"
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla500.LaMalla.CellFontSize. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.CellFontSize = 7
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla500.LaMalla.Row. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.Row = 1
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla500.LaMalla.RowSel. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla500.LaMalla.Rows. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.RowSel = .Rows - 1
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla500.LaMalla.CellFontName. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.CellFontName = "Ms Serif"
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla500.LaMalla.CellFontSize. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.CellFontSize = 7
			
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla500.LaMalla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.TextMatrix(0, 0) = "RESUMEN DE ADQUISICIONES Y PAGOS DEL PERÍODO QUE DECLARA"
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla500.LaMalla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.TextMatrix(0, 2) = "VALOR BRUTO"
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla500.LaMalla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.TextMatrix(0, 4) = "VALOR NETO"
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla500.LaMalla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.TextMatrix(0, 6) = "IMP.GENERADO"
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla500.LaMalla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.TextMatrix(0, 1) = ""
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla500.LaMalla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.TextMatrix(0, 3) = ""
			
			' atenuar celdas
			AtenuarCeldas(1, 14, 1, 1, (malla500.LaMalla))
			AtenuarCeldas(1, 14, 3, 3, (malla500.LaMalla))
			AtenuarCeldas(1, 14, 5, 5, (malla500.LaMalla))
			
			borra = True
			AtenuarCeldas(6, 8, 5, 6, (malla500.LaMalla))
			AtenuarCeldas(8, 8, 1, 2, (malla500.LaMalla))
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla500.LaMalla.Cols. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			AtenuarCeldas(10, 10, 0, .Cols - 1, (malla500.LaMalla))
			AtenuarCeldas(11, 14, 1, 2, (malla500.LaMalla))
			AtenuarCeldas(11, 12, 5, 6, (malla500.LaMalla))
			
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla500.LaMalla.AllowBigSelection. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.AllowBigSelection = False
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla500.LaMalla.FillStyle. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.FillStyle = MSFlexGridLib.FillStyleSettings.flexFillSingle
			
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla500.LaMalla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.TextMatrix(1, 0) = "ADQUISICIONES Y PAGOS (EXCLUYE ACTIVOS FIJOS) GRAVADOS TARIFA 12% (CON DERECHO A CRÉDITO TRIBUTARIO)"
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla500.LaMalla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.TextMatrix(2, 0) = "ADQUISICIONES LOCALES DE ACTIVOS FIJOS GRAVADOS TARIFA 12% (CON DERECHO A CRÉDITO TRIBUTARIO)"
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla500.LaMalla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.TextMatrix(3, 0) = "OTRAS ADQUISICIONES Y PAGOS GRAVADOS TARIFA 12% (SIN DERECHO A CRÉDITO TRIBUTARIO)"
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla500.LaMalla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.TextMatrix(4, 0) = "IMPORTACIONES DE BIENES (EXCLUYE ACTIVOS FIJOS) GRAVADOS TARIFA 12%"
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla500.LaMalla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.TextMatrix(5, 0) = "IMPORTACIONES DE ACTIVOS FIJOS GRAVADOS TARIFA 12%"
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla500.LaMalla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.TextMatrix(6, 0) = "IMPORTACIONES DE BIENES (INCLUYE ACTIVOS FIJOS) GRAVADOS TARIFA 0%"
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla500.LaMalla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.TextMatrix(7, 0) = "ADQUISICIONES Y PAGOS (INCLUYE ACTIVOS FIJOS) GRAVADOS TARIFA 0%"
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla500.LaMalla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.TextMatrix(8, 0) = "ADQUISICIONES REALIZADAS A CONTRIBUYENTES RISE "
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla500.LaMalla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.TextMatrix(9, 0) = "TOTAL ADQUISICIONES Y PAGOS "
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla500.LaMalla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.TextMatrix(10, 0) = ""
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla500.LaMalla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.TextMatrix(11, 0) = "ADQUISICIONES NO OBJETO DE IVA"
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla500.LaMalla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.TextMatrix(12, 0) = "NOTAS DE CRÉDITO TARIFA 0% POR COMPENSAR PRÓXIMO MES (INFORMATIVO)"
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla500.LaMalla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.TextMatrix(13, 0) = "NOTAS DE CRÉDITO TARIFA 12% POR COMPENSAR PRÓXIMO MES (INFORMATIVO)"
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla500.LaMalla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.TextMatrix(14, 0) = "PAGOS NETOS POR REEMBOLSO COMO INTERMEDIARIO (INFORMATIVO)"
			
			
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla500.LaMalla.ColWidth. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.ColWidth(0) = 7000
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla500.LaMalla.ColWidth. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.ColWidth(1) = 400
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla500.LaMalla.ColWidth. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.ColWidth(2) = 1400
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla500.LaMalla.ColWidth. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.ColWidth(3) = 400
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla500.LaMalla.ColWidth. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.ColWidth(4) = 1400
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla500.LaMalla.ColWidth. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.ColWidth(5) = 400
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla500.LaMalla.ColWidth. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.ColWidth(6) = 1400
			
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla500.LaMalla.Redraw. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.Redraw = True
		End With
	End Sub
	
	Private Sub Arreglamalla700()
		Dim I As Short
		borra = False
		With Malla700.LaMalla
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla700.LaMalla.Rows. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.Rows = 13
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla700.LaMalla.Cols. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.Cols = 5
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla700.LaMalla.FixedRows. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.FixedRows = 1
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla700.LaMalla.FixedCols. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.FixedCols = 1
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla700.LaMalla.Redraw. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.Redraw = False
			Malla700.MallaFija = True
			
			'For i = 1 To 12
			'.TextMatrix(i, 1) = i + 700
			'.TextMatrix(i, 3) = i + 720
			'Next i
			
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla700.LaMalla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.TextMatrix(1, 0) = 721
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla700.LaMalla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.TextMatrix(2, 0) = 723
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla700.LaMalla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.TextMatrix(3, 0) = 725
			
			
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla700.LaMalla.ColAlignment. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.ColAlignment(1) = 7
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla700.LaMalla.ColAlignment. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.ColAlignment(2) = 7
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla700.LaMalla.ColAlignment. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.ColAlignment(3) = 7
			'.ColAlignment(4) = 7
			'Malla700.ColLock(1) = True
			'Malla700.ColLock(3) = True
			
			Malla700.set_ColData(1, 12)
			Malla700.set_ColData(2, 12)
			Malla700.set_ColData(3, 12)
			
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla700.LaMalla.AllowBigSelection. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.AllowBigSelection = True
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla700.LaMalla.FillStyle. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.FillStyle = MSFlexGridLib.FillStyleSettings.flexFillRepeat
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla700.LaMalla.Row. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.Row = 0
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla700.LaMalla.col. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.col = 0
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla700.LaMalla.RowSel. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla700.LaMalla.FixedRows. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.RowSel = .FixedRows - 1
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla700.LaMalla.ColSel. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla700.LaMalla.Cols. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.ColSel = .Cols - 1
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla700.LaMalla.CellFontBold. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.CellFontBold = True
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla700.LaMalla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.TextMatrix(0, 0) = "Descripción del concepto"
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla700.LaMalla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.TextMatrix(0, 1) = ""
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla700.LaMalla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.TextMatrix(0, 2) = "Valor del Iva"
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla700.LaMalla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.TextMatrix(0, 3) = ""
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla700.LaMalla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.TextMatrix(0, 4) = "Valor Retenido"
			' atenuar celdas
			
			'AtenuarCeldas 1, 12, 1, 1, Malla700.LaMalla
			'AtenuarCeldas 1, 12, 3, 3, Malla700.LaMalla
			
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla700.LaMalla.AllowBigSelection. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.AllowBigSelection = False
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla700.LaMalla.FillStyle. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.FillStyle = MSFlexGridLib.FillStyleSettings.flexFillSingle
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla700.LaMalla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.TextMatrix(1, 0) = "Retenciónes (30%)"
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla700.LaMalla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.TextMatrix(2, 0) = "Retenciónes (70%)"
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla700.LaMalla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.TextMatrix(3, 0) = "Retenciónes 100%"
			
			
			'.TextMatrix(1, 0) = "IVA por la prestación de servicios de profesionales"
			'.TextMatrix(2, 0) = "IVA por el arrendamiento de inmuebles a personas naturales"
			'.TextMatrix(3, 0) = "IVA en otras compras de bienes y servicios con emisión de liquidación de compras y prestación de servicios"
			'.TextMatrix(4, 0) = "IVA en la depreciación de activos en internación temporal"
			'.TextMatrix(5, 0) = "IVA en la distribución de combustibles"
			'.TextMatrix(6, 0) = "IVA en leasing internacional"
			'.TextMatrix(7, 0) = "IVA en operaciones realizadas por exportdores"
			'.TextMatrix(8, 0) = "IVA por la prestación de otros servicios"
			'.TextMatrix(9, 0) = "IVA retenido por emisoras de tarjetas de crédito servicios"
			'.TextMatrix(10, 0) = "IVA retenido por emisoras de tarjetas de crédito bienes"
			'.TextMatrix(11, 0) = "IVA por la compra de bienes"
			'.TextMatrix(12, 0) = "IVA en contratos de construccion"
			
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla700.LaMalla.ColWidth. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.ColWidth(0) = 7200
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla700.LaMalla.ColWidth. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.ColWidth(1) = 400
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla700.LaMalla.ColWidth. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.ColWidth(2) = 1400
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla700.LaMalla.ColWidth. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.ColWidth(3) = 400
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla700.LaMalla.ColWidth. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.ColWidth(4) = 1400
			
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla700.LaMalla.Redraw. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.Redraw = True
		End With
	End Sub
	
	Private Sub AtenuarCeldas(ByRef R1 As Short, ByRef R2 As Short, ByRef c1 As Short, ByRef c2 As Short, ByRef Malla As System.Windows.Forms.Control)
		Dim I, j As Short
		
		With Malla
			For I = R1 To R2
				For j = c1 To c2
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.col. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.col = j
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.Row. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.Row = I
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.CellBackColor. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.CellBackColor = &HC0C0C0
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If borra Then .TextMatrix(I, j) = ""
				Next 
			Next 
		End With
	End Sub
	
	
	Private Sub Botones_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Botones.Click
		Dim Index As Short = Botones.GetIndex(eventSender)
		Dim IngresaArchivo As Object
		Dim Aux As String
		Aux = "104" & IIf(Txt104.Text > "", "SUS_", "ORI_") & UCase(VB6.Format("01/" & ELMES.SelectedIndex + 1 & "/" & ELANIO.Text, "MMMYYYY"))
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto IngresaArchivo.IngresarArchivo. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		ArchSalida = IngresaArchivo.IngresarArchivo("Generar Archivo Formulario SRI 104", "XML", Aux)
		
		'UPGRADE_WARNING: Dir tiene un nuevo comportamiento. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		If Len(Dir(ArchSalida)) > 0 Then
			If MsgBox("El archivo ya existe CONFIRMA SOBREESCRIBIR", MsgBoxStyle.YesNo + MsgBoxStyle.Critical) = MsgBoxResult.Yes Then
				GenerarXml()
			End If
		Else
			GenerarXml()
		End If
		
	End Sub
	
	Private Sub GenerarXml()
		Dim Comilla As String
		Dim I As Integer
		Dim j As Short
		Comilla = """"
		If VB.Right(ArchSalida, 4) = ".XML" Then
			FileOpen(1, ArchSalida, OpenMode.Output)
		Else
			FileOpen(1, ArchSalida & ".XML", OpenMode.Output)
		End If
		GrabarCampoXML("?xml version=" & Comilla & "1.0" & Comilla & " encoding=" & Comilla & "UTF-8" & Comilla & "?", "", 1, CStr(500), 1)
		GrabarCampoXML("formulario version=" & Comilla & "0.2" & Comilla & "><cabecera><codigo_version_formulario>04200803</codigo_version_formulario", "", 1, CStr(500), 1)
		GrabarCampoXML("ruc", lbRuc.Text, 1, CStr(20), 2)
		GrabarCampoXML("codigo_moneda", "1", 20, CStr(2), 2)
		GrabarCampoXML("cabecera", "", 1, CStr(0), 3)
		GrabarCampoXML("detalle", "", 1, CStr(0), 1)
		GrabarCampoXML("campo", CStr(ELMES.SelectedIndex + 1), 4, CStr(0), 4, "101")
		GrabarCampoXML("campo", ELANIO.Text, 4, CStr(0), 4, "102")
		GrabarCampoXML("campo", IIf(Sustitutiva.CheckState, "S", "O"), 4, CStr(0), 4, "31")
		GrabarCampoXML("campo", Txt104.Text, 4, CStr(0), 4, "104")
		GrabarCampoXML("campo", lbRuc.Text, 4, CStr(0), 4, "201")
		GrabarCampoXML("campo", lbNom.Text, 4, CStr(0), 4, "202")
		'GrabarCampoXML "campo", "<![CDATA[ " & lbNom & "]]>", 4, 0, 4, "202"
		GrabarCampoXML("campo", txt301.Text, 2, CStr(10), 4, CStr(301))
		GrabarCampoXML("campo", txt302.Text, 2, CStr(10), 4, CStr(302))
		GrabarCampoXML("campo", txt303.Text, 2, CStr(10), 4, CStr(303))
		GrabarCampoXML("campo", txt304.Text, 2, CStr(10), 4, CStr(304))
		GrabarCampoXML("campo", txt399.Text, 2, CStr(10), 4, CStr(399))
		
		With Malla400
			For I = 1 To .Rows - 1
				For j = 2 To 6 Step 2
					If I <> 10 Then
						If I < 3 Or j = 4 Or (I < 10 And j = 2) Or (I > 12 And j = 6) Or I = 9 Then
							GrabarCampoXML("campo", .get_TextMatrix(I, j), 2, CStr(15), 4, .get_TextMatrix(I, j - 1))
						End If
					End If
				Next j
			Next I
		End With
		
		GrabarCampoXML("campo", Txt480.Text, 2, CStr(10), 4, CStr(480))
		GrabarCampoXML("campo", txt481.Text, 2, CStr(10), 4, CStr(481))
		GrabarCampoXML("campo", txt482.Text, 2, CStr(10), 4, CStr(482))
		GrabarCampoXML("campo", txt483.Text, 2, CStr(10), 4, CStr(483))
		GrabarCampoXML("campo", txt484.Text, 2, CStr(10), 4, CStr(484))
		GrabarCampoXML("campo", txt485.Text, 2, CStr(10), 4, CStr(485))
		GrabarCampoXML("campo", txt499.Text, 2, CStr(10), 4, CStr(499))
		
		'GrabarCampoXML "campo", txt460, 2, 10, 4, 460
		'GrabarCampoXML "campo", tXT107, 2, 10, 4, 107
		
		With malla500
			For I = 1 To .Rows - 1
				For j = 2 To 6 Step 2
					If I <> 10 Then
						If I < 6 Or j = 4 Or (I < 8 And j = 2) Or (I > 12 And j = 6) Or I = 9 Then
							GrabarCampoXML("campo", .get_TextMatrix(I, j), 2, CStr(15), 4, .get_TextMatrix(I, j - 1))
						End If
					End If
				Next j
			Next I
		End With
		
		'GrabarCampoXML "campo", txt560, 2, 10, 4, 560
		GrabarCampoXML("campo", txt553.Text, 2, CStr(10), 4, CStr(554))
		GrabarCampoXML("campo", txt554.Text, 2, CStr(10), 4, CStr(555))
		
		GrabarCampoXML("campo", txt601.Text, 2, CStr(10), 4, CStr(601))
		GrabarCampoXML("campo", txt602.Text, 2, CStr(10), 4, CStr(602))
		'GrabarCampoXML "campo", txt603, 2, 10, 4, 603
		'GrabarCampoXML "campo", txt604, 2, 10, 4, 604
		GrabarCampoXML("campo", txt605.Text, 2, CStr(10), 4, CStr(605))
		GrabarCampoXML("campo", txt607.Text, 2, CStr(10), 4, CStr(607))
		GrabarCampoXML("campo", txt609.Text, 2, CStr(10), 4, CStr(609))
		GrabarCampoXML("campo", txt611.Text, 2, CStr(10), 4, CStr(611))
		GrabarCampoXML("campo", txt615.Text, 2, CStr(10), 4, CStr(615))
		GrabarCampoXML("campo", txt617.Text, 2, CStr(10), 4, CStr(617))
		GrabarCampoXML("campo", txt619.Text, 2, CStr(10), 4, CStr(619))
		GrabarCampoXML("campo", txt621.Text, 2, CStr(10), 4, CStr(621))
		GrabarCampoXML("campo", Txt699.Text, 2, CStr(10), 4, CStr(699))
		
		'GrabarCampoXML "campo", txt901, 2, 10, 4, 901
		GrabarCampoXML("campo", TXT902.Text, 2, CStr(10), 4, CStr(902))
		GrabarCampoXML("campo", txt903.Text, 2, CStr(10), 4, CStr(903))
		GrabarCampoXML("campo", txt904.Text, 2, CStr(10), 4, CStr(904))
		GrabarCampoXML("campo", txt198.Text, 2, CStr(10), 4, CStr(198))
		GrabarCampoXML("campo", Txt999.Text, 2, CStr(10), 4, CStr(999))
		
		With Malla700
			For I = 1 To .Rows - 1
				If Val(.get_TextMatrix(I, 2)) <> 0 Then
					GrabarCampoXML("campo", .get_TextMatrix(I, 2), 2, CStr(15), 4, CStr(720 + I))
				End If
				'    GrabarCampoXML "campo", .TextMatrix(i, 4), 2, 15, 4, 720 + i
			Next I
		End With
		
		GrabarCampoXML("campo", Txt799.Text, 2, CStr(10), 4, CStr(799))
		GrabarCampoXML("campo", Txt859.Text, 2, CStr(10), 4, CStr(859))
		GrabarCampoXML("campo", Txt799.Text, 2, CStr(10), 4, CStr(899))
		
		
		GrabarCampoXML("campo", txt897.Text, 2, CStr(10), 4, CStr(897))
		GrabarCampoXML("campo", txt898.Text, 2, CStr(10), 4, CStr(898))
		GrabarCampoXML("campo", txt899.Text, 2, CStr(10), 4, CStr(899))
		
		
		'GrabarCampoXML "campo", txt901, 2, 10, 4, 901
		GrabarCampoXML("campo", TXT902.Text, 2, CStr(10), 4, CStr(902))
		GrabarCampoXML("campo", txt903.Text, 2, CStr(10), 4, CStr(903))
		GrabarCampoXML("campo", txt904.Text, 2, CStr(10), 4, CStr(904))
		
		GrabarCampoXML("campo", Txt999.Text, 2, CStr(10), 4, CStr(999))
		
		GrabarCampoXML("campo", txt905.Text, 2, CStr(10), 4, CStr(905))
		GrabarCampoXML("campo", txt906.Text, 2, CStr(10), 4, CStr(906))
		GrabarCampoXML("campo", txt907.Text, 2, CStr(10), 4, CStr(907))
		GrabarCampoXML("campo", txt908.Text, 2, CStr(10), 4, CStr(908))
		GrabarCampoXML("campo", txt909.Text, 2, CStr(10), 4, CStr(909))
		GrabarCampoXML("campo", txt910.Text, 2, CStr(10), 4, CStr(910))
		GrabarCampoXML("campo", txt911.Text, 2, CStr(10), 4, CStr(911))
		GrabarCampoXML("campo", txt912.Text, 2, CStr(10), 4, CStr(912))
		GrabarCampoXML("campo", txt913.Text, 2, CStr(10), 4, CStr(913))
		GrabarCampoXML("campo", txt914.Text, 2, CStr(10), 4, CStr(914))
		GrabarCampoXML("campo", txt915.Text, 2, CStr(10), 4, CStr(915))
		GrabarCampoXML("campo", txt916.Text, 2, CStr(10), 4, CStr(916))
		GrabarCampoXML("campo", txt917.Text, 2, CStr(10), 4, CStr(917))
		GrabarCampoXML("campo", txt918.Text, 2, CStr(10), 4, CStr(918))
		GrabarCampoXML("campo", txt919.Text, 2, CStr(10), 4, CStr(919))
		'GrabarCampoXML "campo", txt922, 2, 10, 4, 922
		
		
		'GrabarCampoXML "campo", Rlegal, 1, 10, 4, 198
		'GrabarCampoXML "campo", Rcontador, 1, 10, 4, 199
		
		GrabarCampoXML("detalle", "", 1, CStr(0), 3)
		GrabarCampoXML("formulario", "", 1, CStr(0), 3)
		
		FileClose(1)
	End Sub
	
	Private Sub btCancelar_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btCancelar.Click
		LimpiarFormulario(Me)
	End Sub
	
	Private Sub btCar_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btCar.Click
		CargarValores()
	End Sub
	
	Private Sub btSalir_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btSalir.Click
		If ConfirmaSalir Then Me.Close()
	End Sub
	
	Private Sub SRIP01_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Dim NContador As Object
		Dim Rcontador As Object
		Dim NLegal As Object
		Dim Rlegal As Object
		Dim opAlex As New DirectorioAlex
		SSTab1.TabPages.Item(0).Visible = False
		ELMES.SelectedIndex = Month(Today) - 1
		ELANIO.Text = CStr(Year(Today))
		lbRuc.Text = Emp.ruc
		lbNom.Text = Emp.Nombre
		opAlex = New DirectorioAlex
		opAlex.CargarAlex((Emp.RepLegal), False)
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Rlegal. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Rlegal = opAlex.CiRuc
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto NLegal. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		NLegal = opAlex.NombreImpresion
		
		opAlex.CargarAlex((Emp.Contador), False)
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Rcontador. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Rcontador = opAlex.CiRuc
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto NContador. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		NContador = opAlex.NombreImpresion
		'UPGRADE_NOTE: El objeto opAlex no se puede destruir hasta que no se realice la recolección de los elementos no utilizados. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		opAlex = Nothing
		LimpiarFormulario(Me)
		ArreglaMalla400()
		Arreglamalla500()
		Arreglamalla700()
		'CargarValores
	End Sub
	
	Private Sub txt300_Change(ByRef Index As Short)
		Dim total As Double
		total = 0
		Select Case Index
			Case 0 To 3
				total = total + Val(txt301.Text) + Val(txt302.Text) + Val(txt303.Text) + Val(txt304.Text)
		End Select
	End Sub
	
    Private Sub malla500_CambiaMalla(ByVal eventSender As System.Object, ByVal eventArgs As AxDaxGrid.__DaxGridIn_CambiaMallaEvent)
        Operaciones500()
    End Sub
	
    Private Sub Malla700_CambiaMalla(ByVal eventSender As System.Object, ByVal eventArgs As AxDaxGrid.__DaxGridIn_CambiaMallaEvent)
        Operaciones700()
    End Sub
	
	'UPGRADE_WARNING: El evento txt302.TextChanged se puede desencadenar cuando se inicializa el formulario. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub txt302_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt302.TextChanged
		Total399()
	End Sub
	
	'UPGRADE_WARNING: El evento txt303.TextChanged se puede desencadenar cuando se inicializa el formulario. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub txt303_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt303.TextChanged
		Total399()
	End Sub
	
	'UPGRADE_WARNING: El evento txt304.TextChanged se puede desencadenar cuando se inicializa el formulario. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub txt304_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt304.TextChanged
		Total399()
	End Sub
	
	Private Sub Total399()
		Dim Tot As Double
		Tot = Val(txt302.Text) - Val(txt303.Text) + Val(txt304.Text)
		txt399.Text = CStr(roundd(Tot, 2))
	End Sub
	
	Private Sub Malla400_CambiaMalla(ByVal eventSender As System.Object, ByVal eventArgs As AxDaxGrid.__DaxGridIn_CambiaMallaEvent) Handles Malla400.CambiaMalla
		Operaciones400()
	End Sub
	
	'UPGRADE_WARNING: El evento Txt480.TextChanged se puede desencadenar cuando se inicializa el formulario. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub Txt480_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Txt480.TextChanged
		Operaciones400()
	End Sub
	
	'UPGRADE_WARNING: El evento Txt481.TextChanged se puede desencadenar cuando se inicializa el formulario. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub Txt481_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Txt481.TextChanged
		Operaciones400()
	End Sub
	
	'UPGRADE_WARNING: El evento txt483.TextChanged se puede desencadenar cuando se inicializa el formulario. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub txt483_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt483.TextChanged
		Operaciones400()
	End Sub
	
	'UPGRADE_WARNING: El evento txt484.TextChanged se puede desencadenar cuando se inicializa el formulario. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub txt484_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt484.TextChanged
		Operaciones400()
	End Sub
	'Private Sub Total484()
	'Dim tot As Double
	'''''''tot = val(Txt480) + val(txt481) * 12 / 100
	'' qui va el valor del 12% del iva '' poner el valor directamente por si acaso cambie el iva en medio mes u otros valores
	'End Sub
	
	Private Function SUMAR(ByRef Malla As Object, ByRef Lin1 As Short, ByRef lin2 As Short, ByRef Col1 As Short, ByRef Col2 As Short) As Double
		Dim Tot As Double
		Dim I As Short
		Dim j As Short
		Tot = 0
		With Malla
			For I = Lin1 To lin2
				For j = Col1 To Col2
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					Tot = Val(.TextMatrix(I, j)) + Tot
				Next j
			Next I
		End With
		SUMAR = Tot
	End Function
	Private Sub Operaciones400()
		Dim Tot As Double
		'cambiar on error Resume Next
		With Malla400
			.set_TextMatrix(9, 2, roundd(SUMAR(Malla400, 1, 8, 2, 2), 2))
			.set_TextMatrix(9, 4, roundd(SUMAR(Malla400, 1, 8, 4, 4), 2))
			.set_TextMatrix(9, 6, roundd(SUMAR(Malla400, 1, 2, 6, 6), 2))
			
			txt482.Text = .get_TextMatrix(9, 6)
			Tot = Val(txt482.Text) - Val(txt484.Text)
			txt485.Text = CStr(roundd(Tot, 2))
			
			Tot = Val(txt483.Text) + Val(txt484.Text) '+ val(Malla400.TextMatrix(17, 6))
			txt499.Text = CStr(roundd(Tot, 2))
		End With
	End Sub
	
	Private Sub Operaciones500()
		Dim Tot As Double
		Dim I As Short
		Dim j As Short
		
		With malla500
			.set_TextMatrix(9, 2, roundd(SUMAR(malla500, 1, 7, 2, 2), 2))
			.set_TextMatrix(9, 4, roundd(SUMAR(malla500, 1, 8, 4, 4), 2))
			.set_TextMatrix(9, 6, roundd(SUMAR(malla500, 1, 8, 6, 6), 2))
			If Val(Malla400.get_TextMatrix(9, 4)) > 0 Then
				txt553.Text = CStr(roundd(SUMAR(Malla400, 1, 2, 4, 4) + SUMAR(Malla400, 5, 8, 4, 4) / Val(Malla400.get_TextMatrix(9, 4)), 2))
			End If
			txt554.Text = CStr(roundd(SUMAR(malla500, 1, 2, 6, 6) + SUMAR(malla500, 4, 5, 6, 6) * Val(txt553.Text), 2))
		End With
		
	End Sub
	Private Sub operaciones600()
		Dim Tot As Double
		Tot = System.Math.Round(Val(txt499.Text) - Val(txt554.Text), 2)
		If Tot > 0 Then
			txt601.Text = CStr(Tot)
			txt602.Text = ""
		Else
			txt602.Text = CStr(Tot)
			txt601.Text = ""
		End If
		Tot = roundd(Val(txt601.Text) - Val(txt602.Text) - Val(txt605.Text) - Val(txt607.Text) - Val(txt609.Text) + Val(txt611.Text), 2)
		If Tot > 0 Then txt619.Text = CStr(Tot)
		Txt699.Text = CStr(roundd(Val(txt619.Text) + Val(txt621.Text), 2))
	End Sub
	
	Private Sub Operaciones700()
		Dim Tot As Double
		Dim I As Short
		With Malla700
			Txt799.Text = CStr(roundd(SUMAR(Malla700, 1, .Rows - 1, 2, 2), 2))
			Txt859.Text = CStr(roundd(Val(CStr(CDbl(Txt799.Text) + Val(Txt699.Text))), 2))
		End With
	End Sub
	
	'UPGRADE_WARNING: El evento txt485.TextChanged se puede desencadenar cuando se inicializa el formulario. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub txt485_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt485.TextChanged
		Operaciones400()
	End Sub
	
	'UPGRADE_WARNING: El evento txt554.TextChanged se puede desencadenar cuando se inicializa el formulario. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub txt554_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt554.TextChanged
		If Val(txt554.Text) > 0 Then operaciones600()
		'txt601=val(
	End Sub
	
	'UPGRADE_WARNING: El evento txt601.TextChanged se puede desencadenar cuando se inicializa el formulario. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub txt601_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt601.TextChanged
		TotalizarPago()
	End Sub
	
	'UPGRADE_WARNING: El evento txt602.TextChanged se puede desencadenar cuando se inicializa el formulario. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub txt602_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt602.TextChanged
		TotalizarPago()
	End Sub
	
	Private Sub txt603_Change()
		TotalizarPago()
	End Sub
	
	Private Sub txt604_Change()
		TotalizarPago()
	End Sub
	
	Private Sub TotalizarPago()
		Dim txt698 As Object
		Dim txt604 As Object
		Dim txt603 As Object
		Dim Tot As Double
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto txt604. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto txt603. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Tot = Val(txt601.Text) - Val(txt602.Text) - Val(txt603) - Val(txt604)
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto txt698. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If Tot < 0 Then txt698 = roundd(System.Math.Abs(Tot), 2) Else Txt699.Text = CStr(roundd(Tot, 2))
	End Sub
	
	Private Sub Txt699_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Txt699.Click
		txt798_Change()
	End Sub
	
	Private Sub txt798_Change()
		Dim txt798 As Object
		Dim Tot As Double
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto txt798. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Tot = Val(Txt699.Text) + Val(txt798)
		Txt799.Text = CStr(roundd(Tot, 2))
	End Sub
	
	'UPGRADE_WARNING: El evento Txt799.TextChanged se puede desencadenar cuando se inicializa el formulario. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub Txt799_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Txt799.TextChanged
		Dim OT As Object
		Dim txt901 As Object
		Dim Tot As Double
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto txt901. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Tot = Val(Txt799.Text) - Val(txt901)
		TXT902.Text = CStr(roundd(Tot, 2))
		Tot = Val(TXT902.Text) + Val(txt903.Text) + Val(txt904.Text)
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto OT. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Txt999.Text = CStr(roundd(OT, 2))
	End Sub
	
	Private Sub CargarValores()
		Dim txt118 As Object
		Dim tota As Object
		Dim total As Object
		Dim txt604 As Object
		Dim rs As New ADODB.Recordset
		Dim SSQL As String
		Dim I As Short
		Dim j As Short
		'cambiar on error Resume Next
		LimpiarFormulario(Me)
		SSQL = "DaxSr401404 " & ELMES.SelectedIndex + 1 & ", " & ELANIO.Text ', ConxAdcom, adOpenForwardOnly, adLockReadOnly
		rs = ConxAdcom.Execute(SSQL)
		If rs.State = 0 Then MsgBox("No se puede continuar, la opción no esta configurada falta: DaxSr401404 ")
		With Malla400
			If rs.EOF = False Then
				.set_TextMatrix(1, 2, roundd(CorrijeNuloN(rs.Fields("V401")), 2))
				.set_TextMatrix(1, 4, roundd(CorrijeNuloN(rs.Fields("V411")), 2))
				.set_TextMatrix(1, 6, roundd(CorrijeNuloN(rs.Fields("V421")), 2))
				.set_TextMatrix(2, 2, roundd(CorrijeNuloN(rs.Fields("V402")), 2))
				.set_TextMatrix(2, 4, roundd(CorrijeNuloN(rs.Fields("V412")), 2))
				.set_TextMatrix(2, 6, roundd(CorrijeNuloN(rs.Fields("V422")), 2))
				.set_TextMatrix(3, 2, roundd(CorrijeNuloN(rs.Fields("V403")), 2))
				.set_TextMatrix(3, 4, roundd(CorrijeNuloN(rs.Fields("V413")), 2))
				.set_TextMatrix(4, 2, roundd(CorrijeNuloN(rs.Fields("V404")), 2))
				.set_TextMatrix(4, 4, roundd(CorrijeNuloN(rs.Fields("V414")), 2))
				
				.set_TextMatrix(9, 2, roundd(CorrijeNuloN(rs.Fields("V409")), 2))
				.set_TextMatrix(9, 4, roundd(CorrijeNuloN(rs.Fields("V419")), 2))
				.set_TextMatrix(9, 6, roundd(CorrijeNuloN(rs.Fields("V429")), 2))
			End If
			rs.Close()
			SSQL = "DaxSr480481 " & ELMES.SelectedIndex + 1 & ", " & ELANIO.Text ', ConxAdcom, adOpenForwardOnly, adLockReadOnly
			rs = ConxAdcom.Execute(SSQL)
			If rs.EOF Then
				Txt480.Text = CStr(0)
				txt481.Text = CStr(0)
				txt482.Text = CStr(0)
			Else
				Txt480.Text = CStr(CorrijeNuloN(rs.Fields("V480")))
				txt481.Text = CStr(CorrijeNuloN(rs.Fields("V481")))
				txt482.Text = CStr(CorrijeNuloN(rs.Fields("V482")))
			End If
			rs.Close()
		End With
		
		SSQL = "DaxSr501509 " & ELMES.SelectedIndex + 1 & ", " & ELANIO.Text ', ConxAdcom, adOpenForwardOnly, adLockReadOnly
		rs = ConxAdcom.Execute(SSQL)
		With malla500
			.set_TextMatrix(8, 2, "")
			.set_TextMatrix(8, 4, "")
			.set_TextMatrix(8, 6, "")
			
			Do Until rs.EOF
				'If rs!Doc_TipoDoc = "FAP" Then
				'    If rs!ElTipo = "A" Then
				.set_TextMatrix(1, 2, roundd(CorrijeNuloN(rs.Fields("c501")), 2))
				.set_TextMatrix(1, 4, roundd(CorrijeNuloN(rs.Fields("c511")), 2))
				.set_TextMatrix(1, 6, roundd(CorrijeNuloN(rs.Fields("c521")), 2))
				'    ElseIf rs!ElTipo = "S" Then
				.set_TextMatrix(2, 2, roundd(CorrijeNuloN(rs.Fields("c502")), 2))
				.set_TextMatrix(2, 4, roundd(CorrijeNuloN(rs.Fields("c512")), 2))
				.set_TextMatrix(2, 6, roundd(CorrijeNuloN(rs.Fields("c522")), 2))
				'    End If
				'ElseIf rs!Doc_TipoDoc = "DEP" Then
				.set_TextMatrix(7, 2, roundd(Val(.get_TextMatrix(8, 2)) + CorrijeNuloN(rs.Fields("c507")), 2))
				.set_TextMatrix(7, 4, roundd(Val(.get_TextMatrix(8, 4)) + CorrijeNuloN(rs.Fields("c517")), 2))
				'End If
				rs.MoveNext()
			Loop 
			rs.Close()
			
			SSQL = "DaxSr604 " & ELMES.SelectedIndex + 1 & ", " & ELANIO.Text ', ConxAdcom, adOpenForwardOnly, adLockReadOnly
			rs = ConxAdcom.Execute(SSQL)
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto txt604. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If rs.EOF = False Then txt604 = roundd(CorrijeNuloN(rs.Fields("totalret")), 2)
			rs.Close()
		End With
		
		With Malla700
			rs = ConxAdcom.Execute("DaxSr700Dx " & ELMES.SelectedIndex + 1 & ", " & ELANIO.Text)
			If rs.State = 1 Then
				Do Until rs.EOF
					I = 0
					If (rs.Fields("porc")).Value = 30 Then
						I = 1
					ElseIf (rs.Fields("porc")).Value = 70 Then 
						I = 2
					ElseIf (rs.Fields("porc")).Value = 100 Then 
						I = 3
					End If
					If I > 0 Then
						.set_TextMatrix(I, 4, roundd(CorrijeNuloN(rs.Fields("valorretenido")), 2))
						.set_TextMatrix(I, 2, roundd(CorrijeNuloN(rs.Fields("Impuesto")), 2))
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto total. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto tota. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						tota = total + roundd(CorrijeNuloN(rs.Fields("valorretenido")), 2)
					End If
					rs.MoveNext()
				Loop 
				rs.Close()
			End If
		End With
		If rs.State = 1 Then rs.Close()
		',,,,,,,,chequear
		rs.Open("SELECT  COUNT(Opc_documento) AS Cuantos From dbo.AdcDoc " & "WHERE     (MONTH(Doc_fecha) = " & ELMES.SelectedIndex + 1 & ") AND (YEAR(Doc_fecha) = " & ELANIO.Text & ") AND (Opc_documento = 'RTP') " & "GROUP BY Opc_documento ", ConxAdcom, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto txt118. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If rs.EOF = False Then txt118 = CorrijeNuloN(rs.Fields("Cuantos"))
		If rs.State = 1 Then rs.Close()
		Operaciones400()
		Operaciones500()
		operaciones600()
		Operaciones700()
	End Sub

    Private Sub malla500_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles malla500.CellContentClick

    End Sub
End Class