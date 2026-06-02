USE [BdAdcomDxSistemas]
GO

/****** Object:  Table [dbo].[AdcAcf]    Script Date: 07/28/2010 10:05:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[AdcAcf](
	[Codigo] [varchar](20) NOT NULL,
	[Nombre] [varchar](80) NOT NULL,
	[TipoActivo] [varchar](20) NULL,
	[Categoria] [varchar](5) NULL,
	[Clase] [varchar](5) NULL,
	[Grupo] [varchar](5) NULL,
	[Subgrupo] [varchar](5) NULL,
	[Marca] [varchar](30) NULL,
	[Serie] [varchar](25) NULL,
	[NroLote] [varchar](20) NULL,
	[CentroCosto] [varchar](25) NULL,
	[CodActivoPrincipal] [varchar](20) NULL,
	[EsActivoCompuesto] [bit]NOT NULL,
	[Descripcion] [ntext] NULL,
	[UbicaSucursal] [varchar](3) NULL,
	[UbicaDepartamento] [varchar](3) NULL,
	[UbicaSeccion] [varchar](30) NULL,
	[Responsable] [varchar](50) NULL,
	[Estado] [varchar](40) NULL,
	[TasaDepreciacion] [numeric](8, 4) NOT NULL,
	[FecIngreso] [datetime] NULL,
	[CostoIngreso] [numeric](22, 8) NULL,
	[DocTipIngreso] [varchar](3) NULL,
	[DocNumIngreso] [numeric](18, 0) NULL,
	[FecSalida] [datetime] NULL,
	[DocTipSalida] [varchar](3) NULL,
	[DocNumSalida] [numeric](18, 0) NULL,
	[CtaContable1] [varchar](15) NULL,
	[CtaContable2] [varchar](15) NULL,
	[CtaContable3] [varchar](15) NULL,
	[CtaContable4] [varchar](15) NULL,
	[ValorResidual] [numeric](22, 8) NULL,
	[TipoDepreciacionCont] [int] NULL,
	[TipoDepreciacionTributa] [int] NULL,
	[VidaUtilCont] [numeric](4, 0) NULL,
	[VidaUtilTributa] [numeric](4, 0) NULL,
	[UnidacesProduccionCont] [numeric](10,0) NULL,
	[UnidadesProduccionTribut] [numeric](10,0) NULL,
	[TasaDepCont] [numeric](8, 4) NULL,
	[TasaDepTribut] [numeric](8, 4) NULL,
	[ValorActualCont] [numeric](22, 4) NULL,
	[ValorActualTribut] [numeric](22, 4) NULL,
	[UltimoAñoCalc] [numeric](6, 0) NULL,
	[UltimoMesCalc] [numeric](6, 0) NULL,
	[UsuarioCrea] [varchar](30) NULL,
	[FechaCrea] [datetime] NULL,
	[UsuarioModifica] [varchar](30) NULL,
	[FechaModifica] [datetime] NULL,
	[Texto1] [varchar](30) NULL,
	[Texto2] [varchar](30) NULL,
	[Texto3] [varchar](30) NULL,
	[Texto4] [varchar](30) NULL,
	[Texto5] [varchar](30) NULL,
	[Texto6] [varchar](30) NULL,
	[Texto7] [varchar](30) NULL,
	[Texto8] [varchar](30) NULL,
	[Texto9] [varchar](30) NULL,
	[Texto10] [varchar](30) NULL,
	[Det1] [varchar](80) NULL,
	[Det2] [varchar](80) NULL,
	[Det3] [varchar](80) NULL,
	[Det4] [varchar](80) NULL,
	[Det5] [varchar](80) NULL,
	[Valor1] [numeric](22, 8) NULL,
	[Valor2] [numeric](22, 8) NULL,
	[Valor3] [numeric](22, 8) NULL,
	[Valor4] [numeric](22, 8) NULL,
	[Valor5] [numeric](22, 8) NULL,
	[Fecha1] [datetime] NULL,
	[Fecha2] [datetime] NULL,
	[Fecha3] [datetime] NULL,
	[Logico1] [bit] NULL,
	[Logico2] [bit] NULL,
	[Logico3] [bit] NULL,
	[Imagen] [varchar](512) NULL,
	[Cantidad] [numeric](22,8) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


