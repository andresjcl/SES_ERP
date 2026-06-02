/****** Object:  Table [dbo].[AdcAcf]    Script Date: 06/24/2011 15:21:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[AdcAcfConta](
	[CtaDebeRevalorizaF] [nvarchar](15) NULL,
	[CtaDebeDeterioroF] [nvarchar](15) NULL,
	[CtaDebeDepreciacionF] [nvarchar](15) NULL,
	[CtaDebeDiferenciaDepF] [nvarchar](15) NULL,
	[CtaDebeAux1F] [nvarchar](15) NULL,
	[CtaHaberRevalorizaF] [nvarchar](15) NULL,
	[CtaHaberDeterioroF] [nvarchar](15) NULL,
	[CtaHaberDepreciacionF] [nvarchar](15) NULL,
	[CtaHaberDiferenciaDepF] [nvarchar](15) NULL,
	[CtaHaberAux1F] [nvarchar](15) NULL,
	[CtaDebeDepreciacionT] [nvarchar](15) NULL,
	[CtaHaberDepreciacionT] [nvarchar](15) NULL,
	[CtaDebeAux1T] [nvarchar](15) NULL,
	[CtaDebeAux2T] [nvarchar](15) NULL,
	[CtaDebeAux3T] [nvarchar](15) NULL,
	[CtaDebeAux4T] [nvarchar](15) NULL,
	[CtaHaberAux1T] [nvarchar](15) NULL,
	[CtaHaberAux2T] [nvarchar](15) NULL,
	[CtaHaberAux3T] [nvarchar](15) NULL,
	[CtaHaberAux4T] [nvarchar](51) NULL
) ON [PRIMARY] 
GO

SET ANSI_PADDING OFF
GO


