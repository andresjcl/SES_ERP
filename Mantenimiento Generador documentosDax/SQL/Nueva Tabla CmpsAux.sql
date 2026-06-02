/****** Object:  Table [dbo].[CmpsAux]    Script Date: 07/04/2011 16:35:08 ******/
IF  not EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CmpsAux]') AND type in (N'U'))
begin
CREATE TABLE [dbo].[CmpsAux](
	[Abreviación] [varchar](40) NULL,
	[Descripción] [varchar](70) NULL,
	[TipoDato] [varchar](30) NULL,
	[Longitud] [int] NULL,
	[Decimales] [int] NULL,
	[Origen] [varchar](50) NULL,
	[CampoAsignado] [varchar](50) NULL,
	[UbicaCampo] [char](3) NULL,
	[UltimoCamVar] [int] NULL,
	[UltimoCamFec] [int] NULL,
	[UltimoCamLog] [int] NULL,
	[UltimoCamNum] [int] NULL
) ON [PRIMARY]
end


SET ANSI_PADDING OFF
GO


