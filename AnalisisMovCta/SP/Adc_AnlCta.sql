IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Adc_AnlCta]') AND type in (N'P', N'PC')) 
DROP PROCEDURE [dbo].[Adc_AnlCta]
go

CREATE PROCEDURE [dbo].[Adc_AnlCta]
@Nivel char(1)='5',
@solMov bit=0,
@ctaAux bit=0,
@ctaIni varchar(20)='',
@ctaFin varchar(20)='',
@Clasf varchar(60)='',
@TipoClasf varchar(60)='',
@TipoReg char(1)
AS
BEGIN
select d.cta_codigo,d.dia_ctanombre
	 ,sum(case MONTH(dia_fecha) when 1 then cast(dia_valor*dia_signo as numeric(18,2)) else 0 end) as 'Enero'
	 ,sum (case MONTH(dia_fecha) when 2 then cast(dia_valor*dia_signo as numeric(18,2)) else 0 end) as 'Febrero'
	 ,sum (case MONTH(dia_fecha) when 3 then cast(dia_valor*dia_signo  as numeric(18,2)) else 0 end) as 'Marzo'
	 ,sum (case MONTH(dia_fecha) when 4 then cast(dia_valor*dia_signo as numeric(18,2)) else 0 end) as 'Abril'
	 ,sum (case MONTH(dia_fecha) when 5 then cast(dia_valor*dia_signo as numeric(18,2)) else 0 end) as 'Mayo'
	 ,sum (case MONTH(dia_fecha) when 6 then cast(dia_valor*dia_signo as numeric(18,2)) else 0 end) as 'Junio'
	 ,sum (case MONTH(dia_fecha) when 7 then cast(dia_valor*dia_signo as numeric(18,2)) else 0 end) as 'Julio'
	 ,sum (case MONTH(dia_fecha) when 8 then cast(dia_valor*dia_signo as numeric(18,2)) else 0 end) as 'Agosto'
	 ,sum (case MONTH(dia_fecha) when 9 then cast(dia_valor*dia_signo as numeric(18,2)) else 0 end) as 'Septiembre'
	 ,sum (case MONTH(dia_fecha) when 10 then cast(dia_valor*dia_signo as numeric(18,2)) else 0 end) as 'Octubre'
	 ,sum (case MONTH(dia_fecha) when 11 then cast(dia_valor*dia_signo as numeric(18,2)) else 0 end) as 'Noviembre'
	 ,sum (case MONTH(dia_fecha) when 12 then cast(dia_valor*dia_signo as numeric(18,2)) else 0 end) as 'Diciembre'
	 from Adcdia d left join AdcCta cta on (cta.Cta_codigo = d.Cta_codigo )
	where ((cta.cta_nivel=@nivel) or (cta.cta_nivel<@Nivel and cta.Cta_agrupacion = 0)) and  
	((@solMov= 1 and cta.Cta_agrupacion  = 0) or @solMov  =0 ) and
	((@ctaAux  =1 and substring(d.Cta_codigo,1,LEN(@ctaIni))=@ctaIni) or 
		(@ctaIni <>'' and @ctaFin <>'' and d.cta_codigo>= @ctaIni and d.Cta_codigo <=@ctaFin)
		or (@ctaIni='' and cta.Cta_codigo <>'')) 
	and ((@Clasf='dia_costo' and d.dia_costo = @TipoClasf) or (@Clasf='dia_empleado' and d.dia_empleado = @TipoClasf)
		or (@Clasf='dia_proyecto' and d.dia_proyecto = @TipoClasf) or (@Clasf='dia_centroproduccion' and d.dia_centroproduccion = @TipoClasf) 
		or (@Clasf='dia_centroDistribucion' and d.dia_centroDistribucion = @TipoClasf) or (@Clasf='dia_directorio' and d.dia_directorio = @TipoClasf)
		or (@Clasf ='0' and cta.Cta_codigo <>'')) 
	and ((@TipoReg='D' and Dia_signo =1)or (@TipoReg='C' and Dia_signo =-1) or (@TipoReg='M'))
	group by d.Cta_codigo ,d.Dia_ctanombre
	order by d.cta_codigo

END


GO


