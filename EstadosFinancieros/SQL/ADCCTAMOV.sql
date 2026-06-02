/****** Object:  Table [dbo].[AdcCtaMov]    Script Date: 05/23/2011 16:15:34 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AdcCtaMov]') AND type in (N'U'))
DROP TABLE [dbo].[AdcCtaMov]
GO

USE [BdAdcomDxForestek]
GO

/****** Object:  Table [dbo].[AdcCtaMov]    Script Date: 05/23/2011 16:15:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[AdcCtaMov](
	[Cta_Codigo] [varchar](15) NOT NULL,
	[Mov_Fecha] [int] NOT NULL,
	[Mov_SalDebe] [numeric](22, 8) NULL,
	[Mov_SalHaber] [numeric](22, 8) NULL,
	[ene_sal] [numeric](22, 8) NULL,
	[ene_deb] [numeric](22, 8) NULL,
	[ene_cre] [numeric](22, 8) NULL,
	[feb_sal] [numeric](22, 8) NULL,
	[feb_deb] [numeric](22, 8) NULL,
	[feb_cre] [numeric](22, 8) NULL,
	[mar_sal] [numeric](22, 8) NULL,
	[mar_deb] [numeric](22, 8) NULL,
	[mar_cre] [numeric](22, 8) NULL,
	[abr_sal] [numeric](22, 8) NULL,
	[abr_deb] [numeric](22, 8) NULL,
	[abr_cre] [numeric](22, 8) NULL,
	[may_sal] [numeric](22, 8) NULL,
	[may_deb] [numeric](22, 8) NULL,
	[may_cre] [numeric](22, 8) NULL,
	[jun_sal] [numeric](22, 8) NULL,
	[jun_deb] [numeric](22, 8) NULL,
	[jun_cre] [numeric](22, 8) NULL,
	[jul_sal] [numeric](22, 8) NULL,
	[jul_deb] [numeric](22, 8) NULL,
	[jul_cre] [numeric](22, 8) NULL,
	[ags_sal] [numeric](22, 8) NULL,
	[ags_deb] [numeric](22, 8) NULL,
	[ags_cre] [numeric](22, 8) NULL,
	[sep_sal] [numeric](22, 8) NULL,
	[sep_deb] [numeric](22, 8) NULL,
	[sep_cre] [numeric](22, 8) NULL,
	[oct_sal] [numeric](22, 8) NULL,
	[oct_deb] [numeric](22, 8) NULL,
	[oct_cre] [numeric](22, 8) NULL,
	[nov_sal] [numeric](22, 8) NULL,
	[nov_deb] [numeric](22, 8) NULL,
	[nov_cre] [numeric](22, 8) NULL,
	[dic_sal] [numeric](22, 8) NULL,
	[dic_deb] [numeric](22, 8) NULL,
	[dic_cre] [numeric](22, 8) NULL,
 CONSTRAINT [PK_AdcCtaMov] PRIMARY KEY NONCLUSTERED 
(
	[Cta_Codigo] ASC,
	[Mov_Fecha] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


