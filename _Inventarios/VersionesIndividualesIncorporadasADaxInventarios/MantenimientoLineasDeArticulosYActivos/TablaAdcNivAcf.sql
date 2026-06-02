
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[AdcNivAcf]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
CREATE TABLE [dbo].[AdcNivAcf](
	[Niv_categor] [varchar](5) NULL,
	[Niv_nombre] [varchar](40) NULL,
	[Niv_abrevia] [varchar](5) NOT NULL,
	[Niv_IdCta] [varchar](15) NULL,
	[Niv_Idcta2] [varchar](15) NULL,
	[Niv_Idcta3] [varchar](15) NULL,
	[Niv_Alto] [decimal](18, 0) NULL,
	[Niv_Medio] [decimal](18, 0) NULL,
	[Niv_Bajo] [decimal](18, 0) NULL,
	[Niv_Idcta4] [varchar](15) NULL,
	[Niv_Grafico] [varchar](512) NULL,
) ON [PRIMARY]

GO



