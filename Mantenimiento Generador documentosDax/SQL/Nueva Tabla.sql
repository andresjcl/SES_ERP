USE [BdAdcomDxERP]
GO

/****** Object:  Table [dbo].[CamposAuxiliares]    Script Date: 06/18/2011 10:43:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CamposAuxiliares]') AND type in (N'U'))
DROP TABLE [dbo].[CamposAuxiliares]
GO

USE [BdAdcomDxERP]
GO

/****** Object:  Table [dbo].[CamposAuxiliares]    Script Date: 06/18/2011 10:43:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[CamposAuxiliares](
	[Abreviación] [varchar](15) NULL,
	[Descripción] [varchar](150) NULL,
	[TipoDato] [varchar](100) NULL,
	[Longitud] [numeric](18, 0) NULL,
	[Decimales] [numeric](18, 0) NULL,
	[Origen] [varchar](50) NULL,
	[CampoAsignado] [varchar](150) NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


