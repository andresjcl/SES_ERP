if exists(select * from sys.objects where name ='ADC_REP005')
begin
DROP PROCEDURE [dbo].[ADC_REP005]
end
GO

 CREATE PROCEDURE [dbo].[ADC_REP005]
(
 @periodo varchar(60)
)
AS
BEGIN
select vnr_codigo as Codigo, vnr_nombre as Descripcion,'' as Nota,cast(vnr_valorunit as numeric(18,2)) as costoUnitario,cast(vnr_valortot as numeric(18,2)) as CostoTotal,
cast(case when (vnr_valnetoreal < vnr_valorunit)then vnr_valnetoreal else vnr_valorunit end as numeric(18,2)) as CostoFinal,
cast(vnr_existencia*(case when (vnr_valnetoreal < vnr_valorunit)then vnr_valnetoreal else vnr_valorunit end) as numeric(18,2)) as CostoFTotal,
case when (vnr_tipoDoc ='AEI')then 'Ajuste Egreso Inventario' else 'Ajuste Ingreso Inventario' end  as Tipo_Doc,
cast(vnr_valorAjustar as numeric(18,2)) as ValorAjustar,vnr_periodo as Periodo 
from AdcVnr 
where vnr_periodo =@periodo and vnr_valorAjustar <> 0
order by vnr_codigo 
END