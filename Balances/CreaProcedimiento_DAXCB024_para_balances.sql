USE [BdAdcomDx]
GO

/****** Object:  StoredProcedure [dbo].[DaxCB024]    Script Date: 10/22/2011 15:09:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

 ALTER procedure [dbo].[DaxCB024] ( @Fec1 datetime, @Fec2 datetime, @AnioCierre integer, @Movimiento as integer )
    AS
     select f1.CodCta,cta_nombre, f1.SaldoAnterior ,f1.Debito ,f1.Credito ,f1.SaldoFecha ,  cta_grupo, cta_agrupacion 
     into #tabla1
     from 
     ( 
		select isnull(CodigoCta,cta_codigo)as CodCta ,isnull(Mov_SalDebe,0) as SaldoAnterior,isnull(Debitos,0) as Debito
		,isnull(Creditos,0) as Credito,isnull(Mov_SalDebe,0) + isnull(Debitos,0) - isnull(Creditos,0) as SaldoFecha 
		from 
			( -- carga debitos y creditos en cada cuenta con los diarios desde f1 hasta f2
			 select adccta.Cta_codigo as CodigoCta,
			 sum(CASE WHEN isnull(dia_signo,1) = 1 then dia_valor else 0 end) as Debitos
			, sum(CASE WHEN isnull(dia_signo,0) = -1 then dia_valor else 0 end) as Creditos 
			from adccta left outer join adcdia on adccta.cta_codigo = substring(adcdia.cta_codigo,1,len(adccta.cta_codigo)) 
			where dia_fecha >= @fec1 and dia_fecha <= @fec2 group by adccta.cta_codigo 
			) r1 
			full Join 
			( -- carga la cuenta contable con el salo anterior a la fecha de inicio 
			select isnull(rs2.cta_codigo,rs1.codigoCta) as cta_codigo, isnull(saldotran,0) + isnull(mov_saldebe,0) as mov_saldebe 
			from 
				( -- carga elmovimiento de adcdia en cada cuenta contable de los diarios con fecha anterior
					select adccta.Cta_codigo as CodigoCta,sum(dia_signo * dia_valor) as SaldoTran 
					from adccta left outer join adcdia 
					on adccta.cta_codigo = substring(adcdia.cta_codigo,1,len(adccta.cta_codigo)) 
					--where dia_fecha < @fec1 
					group by adccta.cta_codigo 
				) rs1 
				full Join 
				( -- carga el saldo anterior al año de cierre especificado
					select m1.cta_codigo, m1.mov_saldebe 
					from adcctamov m1 left join adccta c1 
					on m1.cta_codigo = c1.cta_codigo 
					where cta_grupo <> 4 and Mov_Fecha = @Aniocierre 
				) rs2 
					on rs1.codigocta = rs2.cta_codigo 
				) m3 
				on  codigocta = m3.cta_codigo 
				Where IsNull(Mov_SalDebe, 0) <> 0 Or IsNull(Debitos, 0) <> 0 Or IsNull(Creditos, 0) <> 0 
			) f1 left join adccta on f1.codcta = cta_codigo 
			where @movimiento = 0 or (@movimiento=1 and cta_agrupacion <> 1) order by codcta
GO
