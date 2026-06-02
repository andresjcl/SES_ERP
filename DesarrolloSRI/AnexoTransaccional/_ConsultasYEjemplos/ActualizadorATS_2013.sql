------------ ACTUALIZAR SRI-2013

----IVARET

------cambiar por empresa
USE IVARET
alter table Compras add CL_ParteRelacionada varchar(20) null
alter table Compras add CL_TipoProveedor varchar(20) null
alter table Compras add CL_pagoLocExt int null
alter table Compras add CL_pagoPais varchar(20) null
alter table Compras add CL_dobleTributacion varchar(10) null
alter table Compras add CL_pagoSujetoRetencion varchar(10) null
alter table Compras add CL_formaDePago int null

------cambiar por empresa
USE BdAdcomDx
alter table FormasDePago add SRI_formaDePago varchar(10) null
alter table FormasDePago add SRI_pagoLocExt varchar(10) null
alter table FormasDePago add SRI_pagoPais varchar(20) null
alter table FormasDePago add SRI_dobleTributacion varchar(10) null
alter table FormasDePago add SRI_pagoSujetoRetencion varchar(10) null


/****** Object:  View [dbo].[AdcDocNombre]    Script Date: 07/02/2013 00:31:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

 ALTER  VIEW [dbo].[AdcDocNombre] AS 
 SELECT r1.*,  RTRIM(iden_1.Nombres + '  ' + ISNULL(iden_1.Apellidos, '')) AS NombreVend, 
 LEFT(iden_1.Nombres, 1) + '.' + LEFT(ISNULL(iden_1.Apellidos, ''), 1) + '.' AS InicialVEND 
 FROM (SELECT dbo.AdcDoc.*, RTRIM(Iden.Nombres + '  ' + ISNULL(Iden.Apellidos, '')) AS NOMBRECLI1, 
 LEFT(Iden.Nombres, 1) + '.' + LEFT(Iden.Apellidos, 1) + '.' AS Iniciales, 
 case when iden.TipoPersona = 'N' then '01' else '02' end as TipoProveedor 
 ,case when isnull(iden.EsAsociado ,0) = 1 then 'SI' else 'NO' end as EsRelacionada, 
 lTRIM(ISNULL(Iden.Apellidos, '') + '  ' +  Iden.Nombres) AS NOMBRECLI2, Iden.Codigo AS CodigoCliente, 
 Iden.ExoneradoIva, Iden.País, Iden.Provincia, Iden.Ciudad, Iden.TipoIdentificacion , Iden.CedulaIdentidadRuc 
 FROM dbo.AdcDoc 
 LEFT OUTER JOIN dbo.Identificacion AS Iden  
 ON dbo.AdcDoc.Doc_codper = Iden.Codigo 
 WHERE (dbo.AdcDoc.Doc_codper <> '[0]')) r1 
 LEFT OUTER JOIN dbo.Identificacion iden_1 ON r1.Doc_venabre = iden_1.Codigo
GO

/****** Object:  View [dbo].[SriDocCompras2013]    Script Date: 07/01/2013 13:22:12 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[SriDocCompras2013]'))
DROP VIEW [dbo].[SriDocCompras2013]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[SriDocCompras2013] AS 
SELECT TOP 100 PERCENT D.Doc_sucursal , D.Opc_documento 
, Doc_numero AS NroRetencion, Doc_Compras, TipoIdentificacion, CedulaIdentidadRuc, 
SUBSTRING(Doc_NroIdDoc, 1, 3) AS NumSerieDoc, SUBSTRING(Doc_NroIdDoc, 5, 3) AS NumestabDoc
, Doc_fecha, Doc_codper, Doc_totsiva, Doc_totciva, Doc_porceniva, Doc_valoriva, D.IdClaveDoc, Doc_NumeroExterno
, 0 AS Adi_PorIce, 0 AS Adi_ValorIce, '' AS Adi_SNDevIva, '' AS Adi_ConceptoIce, Adi_SustTrib, Adi_TipoDocSri
, Adi_FechContab, Adi_CodigoNSR, Adi_NroAutSri 
,ISNULL(SRI_formaDePago,01)AS SRI_formaDePago
,ISNULL(SRI_pagoLocExt,0) AS SRI_pagoLocExt
,ISNULL(SRI_pagoPais,'') AS SRI_pagoPais
,ISNULL(SRI_dobleTributacion,'') AS SRI_dobleTributacion
,ISNULL(SRI_pagoSujetoRetencion,'') AS SRI_pagoSujetoRetencion  
,D.esrelacionada,D.tipoproveedor
From dbo.AdcDocNombre D LEFT JOIN
(select Doc_sucursal,Opc_documento,IdClaveDoc,Pag_Idpago
,ISNULL(SRI_formaDePago,01)AS SRI_formaDePago
,ISNULL(SRI_pagoLocExt,0) AS SRI_pagoLocExt
,ISNULL(SRI_pagoPais,'') AS SRI_pagoPais
,ISNULL(SRI_dobleTributacion,'') AS SRI_dobleTributacion
,ISNULL(SRI_pagoSujetoRetencion,'') AS SRI_pagoSujetoRetencion  
from adcpag A LEFT JOIN FormasDePago F
ON A.Pag_Idpago  = F.IdFormasDePago
where Pag_Numero = 1 AND isnull(SRI_pagoLocExt,'') <> 0 ) R1
ON D.Doc_sucursal = R1.Doc_sucursal AND D.Opc_documento = R1.Opc_documento AND D.IdClaveDoc = R1.IdClaveDoc 
 WHERE  (Doc_TipoDoc = 'FAP' OR Doc_TipoDoc = 'DEP') AND (Doc_Estado <> 0)
GO


/****** Object:  StoredProcedure [dbo].[DaxSriCompras]    Script Date: 07/01/2013 13:02:40 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DaxSriCompras2013]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[DaxSriCompras2013]
GO

/****** Object:  StoredProcedure [dbo].[DaxSriCompras2013]    Script Date: 07/01/2013 13:02:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE  PROCEDURE [dbo].[DaxSriCompras2013] @p1 datetime = '01/01/2000', @p2 datetime = '31/01/2000' AS 
SELECT SDC.Adi_SustTrib, isnull(SDC.TipoIdentificacion,SRC.TipoIdentificacion) AS TipoIdentificacion, 
ISNULL( SDC.CedulaIdentidadRuc,SRC.CedulaIdentidadRuc) AS CedulaIdentidadRuc, SDC.Adi_TipoDocSri
,tipoproveedor,esrelacionada
, SDC.Adi_FechContab, 
SDC.NumSerieDoc, SDC.NumestabDoc, SDC.NroRetencion, SDC.Doc_fecha, SDC.Adi_NroAutSri AS NroAutoriza,
0 as doc_totnoiva, SDC.Doc_totsiva, SDC.Doc_totciva, 0 AS ValorIce,SDC.Doc_valoriva, 
SRC.ValorRetIvaBienes
, case when SRC.CodigoRetIvaServicios <> '725' then  SRC.ValorRetIvaServicios else 0 end as ValorRetIvaServicios
, case when SRC.CodigoRetIvaServicios = '725' then  SRC.ValorRetIvaServicios else 0 end as ValorRetIva100
, isnull(SRI_pagoLocExt,01) as CL_pagoLocExt
,isnull(SRI_pagoPais,0) as CL_pagoPais
,isnull(SRI_pagoSujetoRetencion,'') as CL_pagoSujetoRetencion
,isnull(SRI_dobleTributacion,'') AS CL_dobleTributacion
,isnull(SRI_formaDePago,'') as CL_formaDePago
, case when Adi_CodigoNSR > '' then Adi_CodigoNSR else SRC.CodigoRetFuente end as CodigoRetFuente 
, case when Adi_CodigoNSR > '' then (Doc_totciva + Doc_totsiva) else SRC.BaseRetFuente end as BaseRetFuente
, SRC.PorRetFuente, SRC.ValorRetFuente, SRC.CodigoRetFuente1, SRC.BaseRetFuente1,SRC.PorRetFuente1, SRC.ValorRetFuente1
, SRC.SerieRetEstable,SRC.SerieRetEmision, SRC.NuemroRetencion, SRC.Adi_NroAutSri AS NroAutorizaRet, SRC.FechaRetencion
, '' AS TipMod, '' AS SerieEstbMod, '' AS SerieEmiMod, '' as SecModificado, '' AS NroAutMod 
FROM SriDocCompras2013 SDC 
full OUTER JOIN SriRetCompras SRC 
ON SDC.Doc_sucursal = SRC.Doc_sucursal AND SDC.Opc_documento = SRC.Doc_DocSop And SDC.IDCLAVEDOC = SRC.IDCLAVEDOCSOP 
where (isnull(Adi_FechContab,Doc_fecha) >=  @p1 and  isnull(Adi_FechContab,Doc_fecha) <=  @p2  ) or ( fecharetencion >=  @p1  and  fecharetencion <=  @p2  )
order by SDC.CedulaIdentidadRuc,SDC.NroRetencion
GO


