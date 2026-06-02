if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[AdcNote]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[AdcNote]
GO

/****** Object:  Table [dbo].[AdcNote]    Script Date: 10/13/2010 09:39:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[AdcNote](
	[Nota_Codigo] [decimal](18, 0) NULL,
	[Nota_Cta] [varchar](15) NULL,
	[Nota_Mes] [varchar](5) NULL,
	[Nota_Año] [varchar](5) NULL,
	[Nota_Descripcion] [ntext] NULL,
	[Nota_Origen] [varchar](15) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


