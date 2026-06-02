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
   @fecAnt datetime= null,
   @fecAnt1 datetime= null,
   @mes varchar(100)= null,
   @nivel integer=0
   )
AS
BEGIN

declare @mes1 char(1)
declare @mes2 char(1)
declare @mes3 char(1)
declare @mes4 char(1)
declare @mes5 char(1)
declare @mes6 char(1)
declare @mes7 char(1)
declare @mes8 char(1)
declare @mes9 char(1)
declare @mes10 char(1)
declare @mes11 char(1)
declare @mes12 char(1)

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
		select R1.*,isnull(isnull(mvs.saldo ,ctaMov.[2009] ),'0') as [2009]  from
		(
		SELECT AdcCta.cta_codigo AS cTAaUX,AdcCta.cta_codigo,MAX(ADCCTA.Cta_nombre) AS Nombre , sum(adcdia.dia_valor * adcdia.Dia_signo ) as [2010], max(Cta_Nivel) as Nivel,max(Cta_grupo ) as Grupo
		FROM         AdcCta LEFT OUTER JOIN
							  AdcDia ON AdcCta.Cta_codigo = substring(AdcDia.Cta_codigo,1,LEN(AdcCta.Cta_codigo))                      
							where ISNULL( adcdia.dia_valor ,0) > 0	and (adccta.Cta_Nivel  = @Nivel  or ( adccta.Cta_Nivel in (1,2))) and adcdia.Dia_fecha <=@Fecha and AdcCta.Cta_grupo <=3
		group by adccta.Cta_codigo
		) r1
		----------------- SALDOS DEL AÑO ANTERIOR
		left join
		(
		select case MONTH(@fecha ) 
					when 1 then ene_sal 
					when 2 then feb_sal
					when 3 then mar_sal
					when 4 then abr_sal
					when 5 then may_sal
					when 6 then jun_sal
					when 7 then jul_sal
					when 8 then ags_sal
					when 9 then sep_sal
					when 10 then oct_sal
					when 11 then nov_sal
					when 12 then dic_sal 
					end
					as saldo, Cta_Codigo 
		from AdcCtaMov
		) mvs on r1.Cta_codigo = mvs.Cta_Codigo 
		left join
		(SELECT AdcCta.cta_codigo AS cTAaUX,AdcCta.cta_codigo,MAX(ADCCTA.Cta_nombre) AS Nombre , sum(adcdia.dia_valor * adcdia.Dia_signo ) as [2009], max(Cta_Nivel) as Nivel,max(Cta_grupo ) as Grupo
				FROM         AdcCta LEFT OUTER JOIN
									  AdcDia ON AdcCta.Cta_codigo = substring(AdcDia.Cta_codigo,1,LEN(AdcCta.Cta_codigo))                      
									where ISNULL( adcdia.dia_valor ,0) > 0	and (adccta.Cta_Nivel  = @nivel  or ( adccta.Cta_Nivel in (1,2))) and adcdia.Dia_fecha <=@fecAnt and AdcCta.Cta_grupo <=3
								
				group by adccta.Cta_codigo) ctaMov
				on(r1.Cta_codigo = ctaMov.Cta_codigo ) 

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
	on t2.Codigo = nota.Nota_Cta and substring(nota.Nota_Mes,1,2) >= MONTH(@fecha)and substring(nota.Nota_Mes,4,2) >= MONTH(@fecha1) and nota.Nota_Año =YEAR(@fecha ) and nota.Nota_Origen ='BAL_SIT'
		ORDER BY t2.cTAaUX 
end

else

begin 
set @mes1 = SUBSTRING (@mes,1,1)
set @mes2 = SUBSTRING (@mes,2,1)
set @mes3 = SUBSTRING (@mes,3,1)
set @mes4 = SUBSTRING (@mes,4,1)
set @mes5 = SUBSTRING (@mes,5,1)
set @mes6 = SUBSTRING (@mes,6,1)
set @mes7 = SUBSTRING (@mes,7,1)
set @mes8 = SUBSTRING (@mes,8,1)
set @mes9 = SUBSTRING (@mes,9,1)
set @mes10 = SUBSTRING (@mes,10,1)
set @mes11 = SUBSTRING (@mes,11,1)
set @mes12 = SUBSTRING (@mes,12,1)

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
		select R1.*,isnull(isnull(mvs.saldo ,ctaMov.[2009] ),'0') as [2009]  from
		(
		SELECT AdcCta.cta_codigo AS cTAaUX,AdcCta.cta_codigo,MAX(ADCCTA.Cta_nombre) AS Nombre , sum(adcdia.dia_valor * adcdia.Dia_signo ) as [2010], max(Cta_Nivel) as Nivel,max(Cta_grupo ) as Grupo
		FROM         AdcCta LEFT OUTER JOIN
							  AdcDia ON AdcCta.Cta_codigo = substring(AdcDia.Cta_codigo,1,LEN(AdcCta.Cta_codigo))                      
							where ISNULL( adcdia.dia_valor ,0) > 0	and (adccta.Cta_Nivel  = @Nivel  or ( adccta.Cta_Nivel in (1,2))) and (adcdia.Dia_fecha >=@Fecha and adcdia.Dia_fecha <=@fecha1) and AdcCta.Cta_grupo <=3
		group by adccta.Cta_codigo
		) r1
		----------------- MOVIMIENTOS DEL AÑO ANTERIOR
		left join
		(
		select m.Cta_Codigo , ISNULL(mes.enero ,0)+ISNULL(mes.febrero,0)+ISNULL(mes.marzo,0)+ISNULL(mes.abril,0)+ISNULL(mes.mayo,0)+ISNULL(mes.junio,0)+ISNULL(mes.julio ,0)+ISNULL(mes.agosto,0)+ISNULL(mes.septiembre,0)+ISNULL(mes.octubre,0)+ISNULL(mes.noviembre,0)+ISNULL(mes.diciembre ,0) as Saldo
		from AdcCtaMov m
		left join
		(
		select 
		 case when @mes1 ='1' then ene_deb -ene_cre else 0 end as enero
		,case when @mes2 ='1' then feb_deb -feb_cre else 0 end as febrero
		,case when @mes3 ='1' then mar_deb -mar_cre else 0 end as marzo
		,case when @mes4 ='1' then abr_deb -abr_cre else 0 end as abril
		,case when @mes5 ='1' then may_deb -may_cre else 0 end as mayo
		,case when @mes6 ='1' then jun_deb -jun_cre else 0 end as junio
		,case when @mes7 ='1' then jul_deb -jul_cre else 0 end as julio
		,case when @mes8 ='1' then ags_deb -ags_cre else 0 end as agosto
		,case when @mes9 ='1' then sep_deb -sep_cre else 0 end as septiembre
		,case when @mes10 ='1' then oct_deb -oct_cre else 0 end as octubre
		,case when @mes11 ='1' then nov_deb -nov_cre else 0 end as noviembre
		,case when @mes12 ='1' then dic_deb -dic_cre else 0 end as diciembre
		,Cta_Codigo
		from AdcCtaMov)mes on mes.Cta_Codigo = m.Cta_Codigo 
		
		) mvs on r1.Cta_codigo = mvs.Cta_Codigo 
		left join
		(SELECT AdcCta.cta_codigo AS cTAaUX,AdcCta.cta_codigo,MAX(ADCCTA.Cta_nombre) AS Nombre , sum(adcdia.dia_valor * adcdia.Dia_signo ) as [2009], max(Cta_Nivel) as Nivel,max(Cta_grupo ) as Grupo
				FROM         AdcCta LEFT OUTER JOIN
									  AdcDia ON AdcCta.Cta_codigo = substring(AdcDia.Cta_codigo,1,LEN(AdcCta.Cta_codigo))                      
									where ISNULL( adcdia.dia_valor ,0) > 0	and (adccta.Cta_Nivel  = @Nivel  or ( adccta.Cta_Nivel in (1,2))) and (adcdia.Dia_fecha >=@fecAnt  and adcdia.Dia_fecha <=@fecAnt1 ) and AdcCta.Cta_grupo <=3
								
				group by adccta.Cta_codigo) ctaMov
				on(r1.Cta_codigo = ctaMov.Cta_codigo )  

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
	on t2.Codigo = nota.Nota_Cta and substring(nota.Nota_Mes,1,2) >= MONTH(@fecha)and substring(nota.Nota_Mes,4,2) >= MONTH(@fecha1) and nota.Nota_Año =YEAR(@fecha ) and nota.Nota_Origen ='BAL_SIT'
		ORDER BY t2.cTAaUX 
end
END