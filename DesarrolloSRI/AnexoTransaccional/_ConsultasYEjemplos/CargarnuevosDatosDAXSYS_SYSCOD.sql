delete Syscod where tiporeferencia in ('paises','tipopagosri','formapagosri')
go
INSERT INTO [Daxsys_acercons].[dbo].[Syscod]
           ([TipoReferencia]
           ,[Abreviación]
           ,[Descripcion]
           ,[Caracteristica1]
           ,[Caracteristica2]
           ,[Caracteristica3] )
select     [TipoReferencia]
           ,[Abreviación]
           ,[Descripcion]
           ,[Caracteristica1]
           ,[Caracteristica2]
           ,[Caracteristica3]
from tmpats2013.dbo.syscod

select * from Syscod where tiporeferencia in ('paises','tipopagosri','formapagosri') order by tiporeferencia