
/****** Object:  StoredProcedure [dbo].[Adc_CtaMovs]    Script Date: 12/19/2011 17:22:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Adc_CtaMovs]
@cta varchar(20)='',
@FecIni datetime=null,
@FecFin datetime=null,
@campAd varchar(20)='',
@valCamp varchar(20)=''
AS
BEGIN

declare @var1 as varchar(1024)
declare @var2 as varchar(200)
declare @campo as varchar(200)
declare @var3 as varchar(100)
set @cta = '''' + RTRIM(@cta) + ''''
if @campAd = '0'
 begin set @var2=''
 set @var3=''
 end
 else
begin  
	if @campAd ='1'
	begin set @campo='dia_costo' end
	else if @campAd='2'
	begin set @campo='Dia_CentroProduccion' end
	else if @campAd='3'
	begin set @campo='Dia_empleado' end
	else if @campAd='4'
	begin set @campo='Dia_centrodistribucion' end
	else if @campAd='5'
	begin set @campo='Dia_Proyecto' end
	else if @campAd='6'
	begin set @campo='dia_directorio' end
	set @var3 =','+@campo
   set @var2=' and '+@campo +'='''+@valCamp+''''
end
 set @campAd = '''' + RTRIM(@campAd) + ''''
set @var1='
select Dia_fecha as Fecha, Opc_documento as Doc,Doc_numero as Numero,dia_detalle as detalle,
case when dia_signo=1 then SUM(Dia_valor) end as  Debitos, 
case when dia_signo=-1 then SUM(Dia_valor) end as  Creditos ,
0.0 as saldo, case '+@campAd +' when ''1'' then dia_costo
when ''2'' then Dia_CentroProduccion
when''3'' then Dia_empleado 
when''4'' then Dia_centrodistribucion
when''5'' then Dia_Proyecto
when''6'' then dia_directorio
end as DatoAd
from AdcDia d 
where substring(d.Cta_codigo,1,len('+@cta+'))= '+@cta+ ' 
and dia_fecha>='''+ltrim(@FecIni)+ ''' and dia_fecha<='''+ltrim(@FecFin)+ ''''
+ @var2 +' 
group by d.Cta_codigo,Dia_fecha,d.Dia_linea,Opc_documento,Doc_numero,dia_detalle,Dia_signo ,IdClaveDoc'+@var3 +'
order by Opc_documento,Doc_numero,IdClaveDoc'
execute (@var1)
END


GO


