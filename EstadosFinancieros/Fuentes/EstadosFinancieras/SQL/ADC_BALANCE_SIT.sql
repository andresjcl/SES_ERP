if exists(select * from sys.objects where name ='ADC_BALANCE_SIT')
begin
DROP PROCEDURE [dbo].[ADC_BALANCE_SIT]
end
GO

CREATE PROCEDURE [dbo].[ADC_BALANCE_SIT]
 (
   @opcion as varchar(20)=null,
   @fecha datetime=NULL,
   @fecha1 datetime=null,
   @nivel integer=0
   )
AS
BEGIN
if (@opcion='Saldo')
begin
	select t2.Codigo,t2.Nombre, nota.Nota_Codigo as Nota ,cast(t2.Año as numeric(18,2)) as Año , cast(t2.Año1 as numeric(18,2)) as Año1 ,cast((Año -Año1) as numeric(18,2)) as Diferencia
	,case when Año<=0 then 100 else cast(((Año1-Año)/Año *100) as numeric(18,2))end as Porcentaje
	from 
	(
	select 
		case when substring(t1.cTAaUX ,t1.Nivel +1,1)='Z' then '' else t1.Cta_codigo end as Codigo, t1.Nombre,
		case when (t1.Nivel IN (1,2)) AND NOT(substring(t1.cTAaUX ,t1.Nivel +1,1)='Z') then NULL else [2009] end as Año ,
		case when (t1.Nivel IN (1,2)) AND NOT(substring(t1.cTAaUX ,t1.Nivel +1,1)='Z') then NULL else [2010] end as Año1,
		t1.cTAaUX
	 from 
	(
		select R1.*,isnull(adcctamov.Mov_SalDebe,'0') as [2009]  from
		(
		SELECT AdcCta.cta_codigo AS cTAaUX,AdcCta.cta_codigo,MAX(ADCCTA.Cta_nombre) AS Nombre , sum(adcdia.dia_valor * adcdia.Dia_signo ) as [2010], max(Cta_Nivel) as Nivel,max(Cta_grupo ) as Grupo
		FROM         AdcCta LEFT OUTER JOIN
							  AdcDia ON AdcCta.Cta_codigo = substring(AdcDia.Cta_codigo,1,LEN(AdcCta.Cta_codigo))                      
							where ISNULL( adcdia.dia_valor ,0) > 0	and (adccta.Cta_Nivel  = @Nivel  or ( adccta.Cta_Nivel in (1,2))) and adcdia.Dia_fecha <=@Fecha and AdcCta.Cta_grupo <=3
		group by adccta.Cta_codigo
		) r1
		left join AdcCtaMov 
		on r1.Cta_codigo = adcctamov.Cta_Codigo 

	UNION ALL
		select r1.CODIGOTOTAL,r1.Cta_codigo  ,R1.Nombre,R1.[2010] ,R1.Nivel,R1.Grupo ,isnull(adcctamov.Mov_SalDebe,'0') as [2009]   from
		(
		SELECT  AdcCta.cta_codigo + 'Z' AS CODIGOTOTAL,AdcCta.cta_codigo,'     TOTAL ' + MAX(ADCCTA.Cta_nombre) AS Nombre , sum(adcdia.dia_valor * adcdia.Dia_signo ) as [2010], max(Cta_Nivel) as Nivel,max(Cta_grupo ) as Grupo
		FROM         AdcCta LEFT OUTER JOIN
							  AdcDia ON AdcCta.Cta_codigo = substring(AdcDia.Cta_codigo,1,LEN(AdcCta.Cta_codigo))                      
							where ISNULL( adcdia.dia_valor ,0) > 0	and (adccta.Cta_Nivel IN (1,2)) and adcdia.Dia_fecha <=@Fecha and adcdia.Dia_fecha <=@Fecha and AdcCta.Cta_grupo <=3
		group by adccta.Cta_codigo
		) r1
		left join AdcCtaMov 
		on r1.Cta_codigo = adcctamov.Cta_Codigo 
	UNION ALL
	select r2.CODIGOTOTAL,r2.Cta_codigo  ,R2.Nombre,R2.[2010] ,R2.Nivel,R2.Grupo ,isnull(adcctamov.Mov_SalDebe ,'0') as [2009]   from
	(
	select max(cta.CODIGOTOTAL) as  CODIGOTOTAL,max(adccta.Cta_codigo) as cta_codigo, max(cta.Nombre) as Nombre,sum(cta.[2010] ) as [2010],max(cta.Nivel) as Nivel,max(cta.Grupo) as grupo 
	from AdcCta 
	left join
	(SELECT AdcCta.cta_codigo + 'Z' AS CODIGOTOTAL,AdcCta.cta_codigo,'     TOTAL UTILIDADES' AS Nombre , sum(adcdia.dia_valor * adcdia.Dia_signo ) as [2010], max(Cta_Nivel) as Nivel,max(Cta_grupo ) as Grupo
		FROM         AdcCta LEFT OUTER JOIN
							  AdcDia ON AdcCta.Cta_codigo = substring(AdcDia.Cta_codigo,1,LEN(AdcCta.Cta_codigo))                  
							where ISNULL( adcdia.dia_valor ,0) > 0	and (adccta.Cta_Nivel IN (1)) and adcdia.Dia_fecha <=@Fecha and AdcCta.Cta_grupo=4
		group by adccta.Cta_codigo)cta
		on(cta.Cta_codigo = AdcCta.Cta_codigo)
	where (substring(cta.CODIGOTOTAL ,cta .Nivel +1,1)='Z') )R2 
		left join AdcCtaMov 
		on r2.Cta_codigo = adcctamov.Cta_Codigo 
	) t1
	)t2	
	left join
	(
	select *
	from AdcNote 
	) nota
	on t2.Codigo = nota.Nota_Cta and nota.Nota_Mes >= MONTH(@fecha) and nota.Nota_Año =YEAR(@fecha )
		ORDER BY t2.cTAaUX 
end

else

begin 
	select t2.Codigo,t2.Nombre, nota.Nota_Codigo as Nota ,cast(t2.Año as numeric(18,2)) as Año , cast(t2.Año1 as numeric(18,2)) as Año1 ,cast((Año -Año1) as numeric(18,2)) as Diferencia
	,case when Año<=0 then 100 else cast(((Año1-Año)/Año *100) as numeric(18,2))end as Porcentaje
	from 
	(
	select 
		case when substring(t1.cTAaUX ,t1.Nivel +1,1)='Z' then '' else t1.Cta_codigo end as Codigo, t1.Nombre,
		case when (t1.Nivel IN (1,2)) AND NOT(substring(t1.cTAaUX ,t1.Nivel +1,1)='Z') then NULL else [2009] end as Año ,
		case when (t1.Nivel IN (1,2)) AND NOT(substring(t1.cTAaUX ,t1.Nivel +1,1)='Z') then NULL else [2010] end as Año1,
		t1.cTAaUX
	 from 
	(
		select R1.*,isnull(adcctamov.Mov_SalDebe,'0') as [2009]  from
		(
		SELECT AdcCta.cta_codigo AS cTAaUX,AdcCta.cta_codigo,MAX(ADCCTA.Cta_nombre) AS Nombre , sum(adcdia.dia_valor * adcdia.Dia_signo ) as [2010], max(Cta_Nivel) as Nivel,max(Cta_grupo ) as Grupo
		FROM         AdcCta LEFT OUTER JOIN
							  AdcDia ON AdcCta.Cta_codigo = substring(AdcDia.Cta_codigo,1,LEN(AdcCta.Cta_codigo))                      
							where ISNULL( adcdia.dia_valor ,0) > 0	and (adccta.Cta_Nivel  = @Nivel  or ( adccta.Cta_Nivel in (1,2))) and (adcdia.Dia_fecha >=@Fecha and adcdia.Dia_fecha <=@fecha1) and AdcCta.Cta_grupo <=3
		group by adccta.Cta_codigo
		) r1
		left join AdcCtaMov 
		on r1.Cta_codigo = adcctamov.Cta_Codigo 

	UNION ALL
		select r1.CODIGOTOTAL,r1.Cta_codigo  ,R1.Nombre,R1.[2010] ,R1.Nivel,R1.Grupo ,isnull(adcctamov.Mov_SalDebe,'0') as [2009]   from
		(
		SELECT  AdcCta.cta_codigo + 'Z' AS CODIGOTOTAL,AdcCta.cta_codigo,'     TOTAL ' + MAX(ADCCTA.Cta_nombre) AS Nombre , sum(adcdia.dia_valor * adcdia.Dia_signo ) as [2010], max(Cta_Nivel) as Nivel,max(Cta_grupo ) as Grupo
		FROM         AdcCta LEFT OUTER JOIN
							  AdcDia ON AdcCta.Cta_codigo = substring(AdcDia.Cta_codigo,1,LEN(AdcCta.Cta_codigo))                      
							where ISNULL( adcdia.dia_valor ,0) > 0	and (adccta.Cta_Nivel IN (1,2)) and adcdia.Dia_fecha <=@Fecha and (adcdia.Dia_fecha >=@Fecha and adcdia.Dia_fecha <=@fecha1) and AdcCta.Cta_grupo <=3
		group by adccta.Cta_codigo
		) r1
		left join AdcCtaMov 
		on r1.Cta_codigo = adcctamov.Cta_Codigo 
	UNION ALL
	select r2.CODIGOTOTAL,r2.Cta_codigo  ,R2.Nombre,R2.[2010] ,R2.Nivel,R2.Grupo ,isnull(adcctamov.Mov_SalDebe ,'0') as [2009]   from
	(
	select max(cta.CODIGOTOTAL) as  CODIGOTOTAL,max(adccta.Cta_codigo) as cta_codigo, max(cta.Nombre) as Nombre,sum(cta.[2010] ) as [2010],max(cta.Nivel) as Nivel,max(cta.Grupo) as grupo 
	from AdcCta 
	left join
	(SELECT AdcCta.cta_codigo + 'Z' AS CODIGOTOTAL,AdcCta.cta_codigo,'     TOTAL UTILIDADES' AS Nombre , sum(adcdia.dia_valor * adcdia.Dia_signo ) as [2010], max(Cta_Nivel) as Nivel,max(Cta_grupo ) as Grupo
		FROM         AdcCta LEFT OUTER JOIN
							  AdcDia ON AdcCta.Cta_codigo = substring(AdcDia.Cta_codigo,1,LEN(AdcCta.Cta_codigo))                  
							where ISNULL( adcdia.dia_valor ,0) > 0	and (adccta.Cta_Nivel IN (1)) and (adcdia.Dia_fecha >=@Fecha and adcdia.Dia_fecha <=@fecha1) and AdcCta.Cta_grupo=4
		group by adccta.Cta_codigo)cta
		on(cta.Cta_codigo = AdcCta.Cta_codigo)
	where (substring(cta.CODIGOTOTAL ,cta .Nivel +1,1)='Z') )R2 
		left join AdcCtaMov 
		on r2.Cta_codigo = adcctamov.Cta_Codigo 
	) t1
	)t2	
	left join
	(
	select *
	from AdcNote 
	) nota
	on t2.Codigo = nota.Nota_Cta and nota.Nota_Mes >= MONTH(@fecha) and nota.Nota_Año =YEAR(@fecha )
		ORDER BY t2.cTAaUX 
end
END