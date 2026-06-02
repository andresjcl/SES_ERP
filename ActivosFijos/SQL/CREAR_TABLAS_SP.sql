if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='Identificacion' and col.name='CodAsociacion')
begin
Alter table Identificacion add CodAsociacion varchar(20) null

end
go
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='Identificacion' and col.name='RegistroMunicp')
begin
Alter table Identificacion add RegistroMunicp varchar(20) null
end
go

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[AdcAcfNov]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[AdcAcfNov]
GO
GO

CREATE TABLE [dbo].[AdcAcfNov](
	[Doc_sucursal] [char](3) NOT NULL,
	[Opc_documento] [char](3) NOT NULL,
	[Doc_numero] [numeric](18, 0) NOT NULL,
	[Codigo] [varchar](20) NULL,
	[FechaDocumento] [datetime] NULL,
	[FechaNovedad] [datetime] NULL,
	[TipoNovedad] [varchar](50) NULL,
	[NVvalorresidual] [numeric](22, 4) NULL,
	[NVvidautil] [numeric](18, 0) NULL,
	[NVdeterioro] [numeric](22, 4) NULL,
	[NVrevalorizacion] [numeric](22, 4) NULL,
	[NVvalorproduccionmes] [numeric](22, 4) NULL,
	[NVSucursalNueva] [varchar](50) NULL,
	[NvDepartamentoNvo] [varchar](50) NULL,
	[NvSeccionNvo] [varchar](50) NULL,
	[NvResponsable] [varchar](50) NULL,
	[NVValorAuxiliar1] [numeric](22, 4) NULL,
	[NVValorAuxiliar2] [numeric](22, 4) NULL,
	[NVValorAuxiliar3] [numeric](22, 4) NULL,
	[NVValorAuxiliar4] [numeric](22, 4) NULL,
	[NVValorAuxiliar5] [numeric](22, 4) NULL,
	[NVValorAuxiliar6] [numeric](22, 4) NULL,
	[Observaciones] [varchar](50) NULL
) ON [PRIMARY]

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[AdcAcfDep]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[AdcAcfDep]
GO
GO

CREATE TABLE [dbo].[AdcAcfDep](
	[Codigo] [varchar](20) NOT NULL,
	[año] [numeric](4, 0) NOT NULL,
	[Mes] [numeric](4, 0) NOT NULL,
	[ClaseDepreciacion] [char](1) NULL,
	[AcumDepreciacion] [numeric](22, 8) NULL,
	[AcumRevaloriizacion] [numeric](22, 8) NULL,
	[AcumDeterioro] [numeric](22, 8) NULL,
	[VidaUtilAlMes] [numeric](18, 0) NULL,
	[CapacidadProduccionMes] [numeric](18, 0) NULL,
	[NroDiasLiquidacion] [numeric](4, 0) NULL,
	[ProduccionMes] [numeric](22, 8) NULL,
	[ValorResidual] [numeric](22, 8) NULL,
	[DeterioroMes] [numeric](22, 8) NULL,
	[RevalorizacionMes] [numeric](22, 8) NULL,
	[DepreciacionMes] [numeric](22, 8) NULL,
	[FechaProceso] [datetime] NULL,
	[UsuarioProceso] [varchar](50) NULL,
	[Estado] [bit] NULL,
	[Acumulados] [bit] NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[AdcAcf]    Script Date: 08/16/2010 10:10:23 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[AdcAcf]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[AdcAcf]
GO

CREATE TABLE [dbo].[AdcAcf](
	[Codigo] [varchar](20) NOT NULL,
	[Nombre] [varchar](80) NOT NULL,
	[TipoActivo] [varchar](20) NULL,
	[Categoria] [varchar](5) NULL,
	[Clase] [varchar](5) NULL,
	[Grupo] [varchar](5) NULL,
	[Subgrupo] [varchar](5) NULL,
	[Marca] [varchar](30) NULL,
	[Serie] [varchar](25) NULL,
	[NroLote] [varchar](20) NULL,
	[CentroCosto] [varchar](25) NULL,
	[CodActivoPrincipal] [varchar](20) NULL,
	[EsActivoCompuesto] [bit] NOT NULL,
	[Descripcion] [ntext] NULL,
	[UbicaSucursal] [varchar](3) NULL,
	[UbicaDepartamento] [varchar](3) NULL,
	[UbicaSeccion] [varchar](30) NULL,
	[Responsable] [varchar](50) NULL,
	[Estado] [varchar](40) NULL,
	[TasaDepreciacion] [numeric](8, 4) NOT NULL,
	[FecIngreso] [datetime] NULL,
	[CostoIngreso] [numeric](22, 8) NULL,
	[DocTipIngreso] [varchar](3) NULL,
	[DocNumIngreso] [numeric](18, 0) NULL,
	[FecSalida] [datetime] NULL,
	[DocTipSalida] [varchar](3) NULL,
	[DocNumSalida] [numeric](18, 0) NULL,
	[CtaContable1] [varchar](15) NULL,
	[CtaContable2] [varchar](15) NULL,
	[CtaContable3] [varchar](15) NULL,
	[CtaContable4] [varchar](15) NULL,
	[ValorResidual] [numeric](22, 8) NULL,
	[TipoDepreciacionCont] [int] NULL,
	[TipoDepreciacionTributa] [int] NULL,
	[VidaUtilCont] [numeric](4, 0) NULL,
	[VidaUtilTributa] [numeric](4, 0) NULL,
	[UnidacesProduccionCont] [numeric](10, 0) NULL,
	[UnidadesProduccionTribut] [numeric](10, 0) NULL,
	[TasaDepCont] [numeric](8, 4) NULL,
	[TasaDepTribut] [numeric](8, 4) NULL,
	[ValorActualCont] [numeric](22, 4) NULL,
	[ValorActualTribut] [numeric](22, 4) NULL,
	[UltimoAñoCalc] [numeric](6, 0) NULL,
	[UltimoMesCalc] [numeric](6, 0) NULL,
	[UsuarioCrea] [varchar](30) NULL,
	[FechaCrea] [datetime] NULL,
	[UsuarioModifica] [varchar](30) NULL,
	[FechaModifica] [datetime] NULL,
	[Texto1] [varchar](30) NULL,
	[Texto2] [varchar](30) NULL,
	[Texto3] [varchar](30) NULL,
	[Texto4] [varchar](30) NULL,
	[Texto5] [varchar](30) NULL,
	[Texto6] [varchar](30) NULL,
	[Texto7] [varchar](30) NULL,
	[Texto8] [varchar](30) NULL,
	[Texto9] [varchar](30) NULL,
	[Texto10] [varchar](30) NULL,
	[Det1] [varchar](80) NULL,
	[Det2] [varchar](80) NULL,
	[Det3] [varchar](80) NULL,
	[Det4] [varchar](80) NULL,
	[Det5] [varchar](80) NULL,
	[Valor1] [numeric](22, 8) NULL,
	[Valor2] [numeric](22, 8) NULL,
	[Valor3] [numeric](22, 8) NULL,
	[Valor4] [numeric](22, 8) NULL,
	[Valor5] [numeric](22, 8) NULL,
	[Fecha1] [datetime] NULL,
	[Fecha2] [datetime] NULL,
	[Fecha3] [datetime] NULL,
	[Logico1] [bit] NULL,
	[Logico2] [bit] NULL,
	[Logico3] [bit] NULL,
	[Imagen] [varchar](512) NULL,
	[Cantidad] [numeric](22, 8) NULL,
	[Aseguradora] [varchar](30) NULL,
	[NContrato] [numeric](22, 0) NULL,
	[FechaIngSeguro] [datetime] NULL,
	[FechaSalSeguro] [datetime] NULL,
	[MontoAsegurado] [numeric](22, 8) NULL,
	[Deducible] [numeric](22, 8) NULL,
	[PagoMensual] [numeric](22, 8) NULL,
	[Moneda] [char](3) NULL,
	[Paridad] [numeric](22, 8) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

if exists(select * from sys.objects where name ='ADC_REP004')
begin
DROP PROCEDURE [dbo].[ADC_REP004]
end
GO


CREATE PROCEDURE [dbo].[ADC_REP004]
@Opcion char(1)='',
@codigo varchar(20)=''
AS
BEGIN
if @Opcion ='T'
begin
		select movs.Codigo,movs.Nombre,movs.Opc_nombre as Documento,movs.Doc_numero as Numero,movs.FechaDocumento,ide.NombreImpresion as Responsable,
		movs.Suc as Sucursal, movs.Depart as departamento, movs.Seccion 
		from Identificacion ide
		right join 
		(select movCmp.*,sist.Descripcion as Seccion 
		from daxsys.dbo.Syscod  sist right join
		(select m.*, sis.Descripcion as Depart
		from daxsys.dbo.Syscod  sis right join
		(select act.Codigo,act.Nombre,mov.Doc_numero,mov.FechaDocumento,mov.Opc_nombre,
		case when(ISNULL (mov.NVSucursalNueva,'')<>'')then mov.NVSucursalNueva else act.UbicaSucursal end as Suc,
		case when(ISNULL (mov.NvDepartamentoNvo,'')<>'')then mov.NvDepartamentoNvo else act.UbicaDepartamento end as Dep,
		case when(ISNULL (mov.NvSeccionNvo,'')<>'')then mov.NvSeccionNvo else act.UbicaSeccion end as Sec,
		case when(ISNULL (mov.NvResponsable,'')<>'')then mov.NvResponsable else act.Responsable end as Resp
		from AdcAcf act
		left join
		(select nov.Codigo, det.Opc_nombre,nov.Doc_numero,nov.FechaDocumento,nov.NVSucursalNueva,
		nov.NvDepartamentoNvo,nov.NvSeccionNvo,nov.NvResponsable 
		from AdcAcfNov nov
		left join
		(select opc.Opc_documento,opc.Opc_nombre,mv.Codigo
		from adcOpc opc
		left join
		(Select Codigo,Opc_documento 
		From AdcAcfNov 
		where TipoNovedad='MOV_ACT')mv on(opc.Opc_documento = mv.Opc_documento))det
		on(nov.Codigo = det.Codigo )
		)mov on(act.Codigo=mov.Codigo))m
		on(sis.Abreviación=m.Dep  and sis.TipoReferencia='Departamento')) movCmp
		on(sist.Abreviación =movCmp.Sec and sist.TipoReferencia='Seccion') )movs 
		on (ide.Codigo = movs.Resp)
		group by movs.Codigo , movs.Doc_numero, movs.Nombre, movs.Opc_nombre, movs.FechaDocumento,ide.NombreImpresion,
		movs.Suc,movs.Depart,movs.Seccion 
end
else
begin 
select movs.Codigo,movs.Nombre,movs.Opc_nombre as Documento,movs.Doc_numero as Numero,movs.FechaDocumento,ide.NombreImpresion as Responsable,
		movs.Suc as Sucursal, movs.Depart as departamento, movs.Seccion 
		from Identificacion ide
		right join 
		(select movCmp.*,sist.Descripcion as Seccion 
		from daxsys.dbo.Syscod  sist right join
		(select m.*, sis.Descripcion as Depart
		from daxsys.dbo.Syscod  sis right join
		(select act.Codigo,act.Nombre,mov.Doc_numero,mov.FechaDocumento,mov.Opc_nombre,
		case when(ISNULL (mov.NVSucursalNueva,'')<>'')then mov.NVSucursalNueva else act.UbicaSucursal end as Suc,
		case when(ISNULL (mov.NvDepartamentoNvo,'')<>'')then mov.NvDepartamentoNvo else act.UbicaDepartamento end as Dep,
		case when(ISNULL (mov.NvSeccionNvo,'')<>'')then mov.NvSeccionNvo else act.UbicaSeccion end as Sec,
		case when(ISNULL (mov.NvResponsable,'')<>'')then mov.NvResponsable else act.Responsable end as Resp
		from AdcAcf act
		left join
		(select nov.Codigo, det.Opc_nombre,nov.Doc_numero,nov.FechaDocumento,nov.NVSucursalNueva,
		nov.NvDepartamentoNvo,nov.NvSeccionNvo,nov.NvResponsable 
		from AdcAcfNov nov
		left join
		(select opc.Opc_documento,opc.Opc_nombre,mv.Codigo
		from adcOpc opc
		left join
		(Select Codigo,Opc_documento 
		From AdcAcfNov 
		where TipoNovedad='MOV_ACT')mv on(opc.Opc_documento = mv.Opc_documento))det
		on(nov.Codigo = det.Codigo )
		)mov on(act.Codigo=mov.Codigo)
		where act.Codigo = @codigo)m
		on(sis.Abreviación=m.Dep  and sis.TipoReferencia='Departamento')) movCmp
		on(sist.Abreviación =movCmp.Sec and sist.TipoReferencia='Seccion') )movs 
		on (ide.Codigo = movs.Resp)
		group by movs.Codigo , movs.Doc_numero, movs.Nombre, movs.Opc_nombre, movs.FechaDocumento,ide.NombreImpresion,
		movs.Suc,movs.Depart,movs.Seccion 
		
end
END

GO

if exists(select * from sys.objects where name ='ADC_REP003')
begin
DROP PROCEDURE [dbo].[ADC_REP003]
end
GO


 CREATE PROCEDURE [dbo].[ADC_REP003]
@opcion char(1)
AS
BEGIN 
if @opcion ='D'
begin

		select depre.Codigo,activo.Nombre ,activo.FecIngreso,depre.año,depre.Mes,
		cast(ABS(a1.DepF - a2.DepT) as numeric(18,2))as Depreciación, cast(ABS(a1.AcumF -a2.AcumT) as numeric(18,2)) as AcumuladoDep,
		ABS((activo.CostoIngreso - a11.valAcT)-(activo.CostoIngreso-a12.AcumF)) as ValorLibros
		from adcAcfDep depre
		left join
		(select codigo,Mes,año, DepreciacionMes as DepF,AcumDepreciacion as AcumF from AdcAcfDep
		where ClaseDepreciacion='F')a1 on (depre.Codigo = a1.Codigo and depre.Mes =a1.Mes and depre.año = a1.año)
		left join
		(select Codigo ,Mes, año 
		,ABS(AcumDepreciacion +AcumRevaloriizacion -AcumDeterioro - DepreciacionMes + RevalorizacionMes - DeterioroMes )as AcumF
		from AdcAcfDep 
		where ClaseDepreciacion='F') a12 on(depre.Codigo =a12.Codigo and depre.año=a12.año and depre.Mes =a12.Mes )
		left join
		(select codigo,Mes,año, DepreciacionMes as DepT,AcumDepreciacion as AcumT from AdcAcfDep
		where ClaseDepreciacion='T')a2 on(depre.Codigo =a2.Codigo and depre.año=a2.año and depre.Mes =a2.Mes )
		left join
		(select Codigo ,Mes, año 
		,ABS(AcumDepreciacion +AcumRevaloriizacion -AcumDeterioro - DepreciacionMes + RevalorizacionMes - DeterioroMes )as valAcT
		from AdcAcfDep 
		where ClaseDepreciacion='T') a11 on (depre.Codigo=a11.Codigo and depre.Mes =a11.Mes and depre.año = a11.año )
		left join 
		(select act.Codigo, act.Nombre ,act.CostoIngreso, act.FecIngreso from AdcAcf act) activo 
		on depre.Codigo = activo.Codigo 
		group by depre.Codigo,activo.Nombre ,activo.FecIngreso,depre.año,depre.Mes,activo.CostoIngreso, a1.DepF 
		,a2.DepT, a1.AcumF ,a2.AcumT,a11.valAcT ,a12.AcumF  
		order by depre.Codigo,depre.año,depre.Mes 
end
else
begin
		select act.Codigo, max(act.Nombre) as Nombre ,
		max(act.FecIngreso )as FecIngreso,dep.año,dep.mes, max(cast(dep.DepreciacionMes as numeric (18,2))) as Depreciación,max(cast(dep.AcumDepreciacion as numeric(18,2))) as AcumuladoDep,
		cast((max(act.CostoIngreso) - ABS(max(dep.AcumDepreciacion)+max(dep.AcumRevaloriizacion) -max(dep.AcumDeterioro)-max(dep.DepreciacionMes) +max(dep.RevalorizacionMes -dep.DeterioroMes)))as numeric(18,2)) as ValorLibros
		from AdcAcf act right join
			(
			select depre.Codigo,depre.año,depre.Mes
			,(AcumDepreciacion+ isnull(actF.AcumDep,0)) as AcumDepreciacion,
			(AcumRevaloriizacion+ isnull(actF.AcumRev,0) ) as AcumRevaloriizacion ,(AcumDeterioro+isnull(actF.AcumDet ,0)) as AcumDeterioro,
			(DepreciacionMes+isnull(actF.Dep ,0)) as DepreciacionMes ,(RevalorizacionMes+isnull(actF.Rev,0)) as  RevalorizacionMes,
			(DeterioroMes+isnull(actF.Det,0)) as DeterioroMes
			from adcAcfDep depre
				left join
				(
				select max(Codigo) as Codigo,sum(actp.CostoIngreso) as CostoIngreso ,max(actp.CodActivoPrincipal) as ActPrincipal , Mes,año,sum(DepreciacionMes) as Dep, sum(DeterioroMes ) as Det,sum(RevalorizacionMes) as Rev ,
				sum(AcumDepreciacion) as AcumDep ,sum(AcumDeterioro) as AcumDet,sum(AcumRevaloriizacion ) as AcumRev
				from AdcAcfDep dp
					left join (select codigo as cod, CodActivoPrincipal, CostoIngreso from Adcacf) actp on(actp.cod = dp.Codigo)
					where codigo in(select codigo from AdcAcf where EsActivoCompuesto=0) group by dp.Mes, dp.año
					) actF on(depre.Codigo = actF.ActPrincipal and depre.Mes= actF.Mes and depre.año =actF.año )
					where ClaseDepreciacion=@opcion 
				) dep on(act.Codigo = dep.Codigo )
		where act.EsActivoCompuesto=1
		group by act.Codigo,dep.año ,dep.Mes 
		
		
		--select depre.Codigo,activo.Nombre ,activo.FecIngreso,depre.año,depre.Mes,cast(depre.DepreciacionMes as numeric(18,2)) as Depreciación
		--,cast(depre.AcumDepreciacion as numeric(18,2))as AcumuladoDep,
		--cast((activo.CostoIngreso - ABS(AcumDepreciacion+AcumRevaloriizacion -AcumDeterioro-DepreciacionMes +RevalorizacionMes -DeterioroMes))as numeric(18,2)) as ValorLibros
		--from adcAcfDep depre
		--left join
		--(select act.Codigo, act.Nombre ,act.CostoIngreso, act.FecIngreso from AdcAcf act) activo 
		--on depre.Codigo = activo.Codigo
		--where ClaseDepreciacion=@opcion 
		--group by depre.Codigo,activo.Nombre ,activo.FecIngreso,depre.año,depre.Mes,activo.CostoIngreso,
		--depre.DepreciacionMes,AcumDepreciacion,AcumDeterioro,AcumRevaloriizacion,RevalorizacionMes,DeterioroMes 
		--order by depre.Codigo,depre.año,depre.Mes 
end
END

GO
if exists(select * from sys.objects where name ='ADC_REP002')
begin
DROP PROCEDURE [dbo].[ADC_REP002]
end
GO


 CREATE PROCEDURE [dbo].[ADC_REP002]

AS
BEGIN 

select actF.Codigo,MAX(actF.Nombre) as Nombre,depreciacion.Depreciacion, max(actF.FecIngreso) as FecIngreso, depreciacion.año ,depreciacion.Mes  ,max(cast(actF.CostoIngreso+ ISNULL (depreciacion.CostoIngreso,0)as numeric(18,2))) as CostoIngreso,
sum(depreciacion.AcumuladoDep) as AcumuladoDep,sum(depreciacion.AcumuladoRev) as AcumuladoRev,sum(depreciacion.AcumuladoDet) as AcumuladoDet, SUM(depreciacion.Depreciación) as Depreciación, SUM(depreciacion.Revalor) as Revalor,
SUM(depreciacion.Deterioro) as Deterioro
from AdcAcf actF
right join
(
select depre.Codigo,
case when depre.ClaseDepreciacion='T' then 'Tributaria' else 'Financiera' end as Depreciacion,act.CostoIngreso 
,depre.año,depre.Mes,cast((depre.AcumDepreciacion+ ISNULL(act.AcumDep ,0)) as numeric (22,2)) as AcumuladoDep,
cast((depre.AcumRevaloriizacion+ ISNULL(act.AcumRev ,0)) as numeric(22,2)) as AcumuladoRev, cast((depre.AcumDeterioro+ ISNULL(act.AcumDet ,0)) as numeric(22,2)) as AcumuladoDet,cast((depre.DepreciacionMes+ISNULL(act.Dep ,0)) as numeric(22,2)) as Depreciación,
cast((depre.RevalorizacionMes+ ISNULL(act.Rev   ,0)) as numeric(22,2))as Revalor,cast((depre.DeterioroMes+ISNULL(act.Det  ,0)) as numeric(22,2)) as Deterioro  
from adcAcfDep depre
left join
(
select max(Codigo) as Codigo,sum(actp.CostoIngreso) as CostoIngreso ,max(actp.CodActivoPrincipal) as ActPrincipal , Mes,año,sum(DepreciacionMes) as Dep, sum(DeterioroMes ) as Det,sum(RevalorizacionMes) as Rev ,
sum(AcumDepreciacion) as AcumDep ,sum(AcumDeterioro) as AcumDet,sum(AcumRevaloriizacion  ) as AcumRev
from AdcAcfDep dp
left join (select codigo as cod, CodActivoPrincipal, CostoIngreso from Adcacf) actp on(actp.cod = dp.Codigo)
where codigo in(select codigo from AdcAcf where EsActivoCompuesto=0) group by dp.Mes, dp.año
) act on(depre.Codigo = act.ActPrincipal and depre.Mes= act.Mes and depre.año =act.año )
) depreciacion on(actF.Codigo =depreciacion.Codigo )
where actf.EsActivoCompuesto =1
group by actF.Codigo,depreciacion.Depreciacion,depreciacion.año ,depreciacion.Mes




--select depre.Codigo,activo.Nombre ,
--case when depre.ClaseDepreciacion='T' then 'Tributaria' else 'Financiera' end as Depreciacion,activo.FecIngreso,
--depre.año,depre.Mes,cast(activo.CostoIngreso as numeric (22,2)) as CostoIngreso, cast(depre.AcumDepreciacion as numeric (22,2)) as AcumuladoDep,
--cast(depre.AcumRevaloriizacion as numeric(22,2)) as AcumuladoRev, cast(depre.AcumDeterioro as numeric(22,2)) as AcumuladoDet,cast(depre.DepreciacionMes as numeric(22,2)) as Depreciación,
--cast(depre.RevalorizacionMes as numeric(22,2))as Revalor,cast(depre.DeterioroMes as numeric(22,2)) as Deterioro  
--from adcAcfDep depre
--left join 
--(select act.Codigo, act.Nombre ,act.CostoIngreso, act.FecIngreso from AdcAcf act) activo 
--on depre.Codigo = activo.Codigo 
--order by depre.Codigo,depre.año,depre.Mes
END

GO

if exists(select * from sys.objects where name ='ADC_REP001')
begin
DROP PROCEDURE [dbo].[ADC_REP001]
end
GO



 CREATE PROCEDURE [dbo].[ADC_REP001]

AS
BEGIN 
Declare @Codigo varchar(20)  
declare CursorAct cursor for
select Codigo from AdcAcf

--	CREAR LA TABLA TEMPORAL

	create table  #Temporal (Codigo varchar(20),Sucursal varchar(50),Departamento varchar(50), Seccion varchar(50))

--	CREAR EL CURSOR
	open CursorAct 
	fetch next from CursorAct
	into @Codigo 
	while @@FETCH_STATUS =0
	begin

-- INSERTAR LOS REGISTROS EN LA TABLA TEMPORAL

	 insert into #Temporal (Codigo,Sucursal,Departamento,Seccion )
		select Dpto.Codigo,Dpto.Sucursal,Dpto.Depart, sist.Descripcion as Seccion
		from daxsys.dbo.Syscod  sist right join
			(select Activo.*, sis.Descripcion as Depart
			 from daxsys.dbo.Syscod  sis right join
			  (      
				select adcacf.Codigo ,
				case when (ISNULL(r1.NVSucursalNueva,'')<> '')then r1.NVSucursalNueva else ubicasucursal end as Sucursal,
				case when (ISNULL(r2.NvDepartamentoNvo,'')<> '')then r2.NvDepartamentoNvo else ubicadepartamento end as Departamento,
				case when (ISNULL(r3.NvSeccionNvo,'')<> '')then r3.NvSeccionNvo else ubicaseccion end as Seccion
				from  adcacf
					left join 
					(
					select top 1 Codigo, NVSucursalNueva , FechaDocumento 
					from adcacfnov 
					where NVSucursalNueva > '' and Codigo=@Codigo 
					order by codigo, FechaDocumento desc 
					) r1
					on adcacf.Codigo = r1.Codigo 
					left join
					(
					select top 1 Codigo, NvDepartamentoNvo  , FechaDocumento 
					from adcacfnov 
					where NvDepartamentoNvo  > '' and Codigo=@Codigo
					order by FechaDocumento desc 
					) r2
					on adcacf.Codigo  = r2.Codigo 
					left join 
					(
					select top 1 Codigo, NvSeccionNvo  , FechaDocumento 
					from adcacfnov 
					where NvSeccionNvo  > '' and Codigo=@Codigo
					order by FechaDocumento desc
					) r3 
					on AdcAcf.Codigo =r3.Codigo 
				where AdcAcf.Codigo =@Codigo) activo 
				on sis.Abreviación = activo.Departamento and sis.TipoReferencia ='Departamento')Dpto			
			on sist.Abreviación = Dpto.Seccion and sist.TipoReferencia= 'Seccion' 
	fetch next from CursorAct
	into @Codigo
	end
	close CursorAct
	deallocate CursorAct	

--	CONSULTA GENERAL DE ACTIVOS (CATALOGO)

	select act.Codigo,act.Nombre,CAST(act.CostoIngreso as decimal(18,2))as CostoIngreso,CAST((act.CostoIngreso- ABS(sub1.ValorActual))as decimal(18,2))as ValorActual,
	ubicacion.Sucursal, ubicacion.Departamento, ubicacion.Seccion
	from AdcAcf act 
	 left join (select dep.codigo, (SUM(dep.AcumDepreciacion)+ SUM(dep.AcumRevaloriizacion)- SUM(dep.AcumDeterioro)-SUM(dep.DepreciacionMes)+SUM(dep.RevalorizacionMes)) as ValorActual
	from AdcAcfDep dep where dep.ClaseDepreciacion ='F' group by dep.Codigo)sub1 on act.Codigo= sub1.Codigo
	left join  (select Codigo,Sucursal,Departamento,Seccion from #Temporal) ubicacion 
	on act.Codigo = ubicacion.Codigo
	where DATEDIFF(DAY,act.FecIngreso, GETDATE())>0

-- ELIMINAR LA TABLA TEMPORAL
	drop table #Temporal 

END


GO

if exists(select * from sys.objects where name ='ADC_INDETIFIC_INS')
begin
DROP PROCEDURE [dbo].[ADC_INDETIFIC_INS]
end
GO

 CREATE PROCEDURE [dbo].[ADC_INDETIFIC_INS]
    (
    @Opcion char(1)='',
    @TipoPersona varchar(10)='',
	@EsCliente bit=0,
	@EsProveedor bit=0,
	@EsEmpleado bit=0,
	@EsBanco bit=0,
	@EsAsociado bit=0,
	@EsVendedor bit=0,
	@Codigo varchar(15)='',
	@TipoIdentificacion char(1)='',
	@CedulaIdentidadRuc varchar(16)='',
	@Nombres varchar(80)='',
	@Apellidos varchar(80)='',
	@NombreImpresion varchar(128)='',
	@País varchar(15)='',
	@Provincia varchar(15)='',
	@Ciudad varchar(15)='',
	@Domicilio varchar(70)='',
	@NumeroDomicilio  varchar(10)='',
	@Sector varchar(40)='',
	@Telefono1 varchar(13)='',
	@Telefono2 varchar(13)='',
	@Telefono3 varchar(13)='',
	@NúmeroFax varchar(13)='',
	@Casilla varchar(13)='',
	@CorreoElectrónico varchar(35)='',
	@Paginaweb varchar(40)='',
	@Logotipo varchar(600)='',
	@CodGrabo varchar(20)='',
	@ComisionVenta money=null,
	@CtaCobrarComisiones varchar(20)='',
	@FichaDental varchar(15)='',
	@ExoneradoIva bit=0,
	@CodAsociacion varchar(20)='',
	@RegistroMunicp varchar(20)=''
	) 
AS
BEGIN      
if (@Opcion ='I')
begin
	insert into Identificacion 
		(
		TipoPersona,
		EsCliente,
		EsProveedor,
		EsEmpleado,
		EsBanco,
		EsAsociado,
		EsVendedor,
		Codigo,
		TipoIdentificacion,
		CedulaIdentidadRuc,
		Nombres,
		Apellidos,
		NombreImpresion,
		País,
		Provincia,
		Ciudad,
		Domicilio,
		NumeroDomicilio,
		Sector,
		Telefono1,
		Telefono2,
		Telefono3,
		NúmeroFax,
		Casilla,
		CorreoElectrónico,
		Paginaweb,
		Logotipo,
		CodGrabo,
		ComisionVenta,
		CtaCobrarComisiones,
		FichaDental,
		ExoneradoIva,
		CodAsociacion,
		RegistroMunicp
	)
	values
	(
		@TipoPersona,
		@EsCliente,
		@EsProveedor,
		@EsEmpleado,
		@EsBanco,
		@EsAsociado,
		@EsVendedor,
		@Codigo,
		@TipoIdentificacion,
		@CedulaIdentidadRuc,
		@Nombres,
		@Apellidos,
		@NombreImpresion,
		@País,
		@Provincia,
		@Ciudad,
		@Domicilio,
		@NumeroDomicilio,
		@Sector,
		@Telefono1,
		@Telefono2,
		@Telefono3,
		@NúmeroFax,
		@Casilla,
		@CorreoElectrónico,
		@Paginaweb,
		@Logotipo,
		@CodGrabo,
		@ComisionVenta,
		@CtaCobrarComisiones,
		@FichaDental,
		@ExoneradoIva,
		@CodAsociacion,
		@RegistroMunicp
	)
	end
	else
	if @Opcion ='U'
	begin
	update Identificacion 
	set
	    TipoPersona=@TipoPersona,
		EsCliente=@EsCliente,
		EsProveedor=@EsProveedor,
		EsEmpleado=@EsEmpleado,
		EsBanco=@EsBanco,
		EsAsociado=@EsAsociado,
		EsVendedor=@EsVendedor,
		TipoIdentificacion=@TipoIdentificacion,
		CedulaIdentidadRuc=@CedulaIdentidadRuc,
		Nombres=@Nombres,
		Apellidos=@Apellidos,
		NombreImpresion=@NombreImpresion,
		País=@País,
		Provincia=@Provincia,
		Ciudad=@Ciudad,
		Domicilio=@Domicilio,
		NumeroDomicilio=@NumeroDomicilio,
		Sector=@Sector,
		Telefono1=@Telefono1,
		Telefono2=@Telefono2,
		Telefono3=@Telefono3,
		NúmeroFax=@NúmeroFax,
		Casilla=@Casilla,
		CorreoElectrónico=@CorreoElectrónico,
		Paginaweb=@Paginaweb,
		Logotipo=@Logotipo,
		CodGrabo=@CodGrabo,
		ComisionVenta=@ComisionVenta,
		CtaCobrarComisiones=@CtaCobrarComisiones,
		FichaDental=@FichaDental,
		ExoneradoIva=@ExoneradoIva,
		CodAsociacion=@CodAsociacion,
		RegistroMunicp=@RegistroMunicp
		where Codigo = @Codigo 
end
END
GO
if exists(select * from sys.objects where name ='ADC_CLIENTE_INS')
begin
DROP PROCEDURE [dbo].[ADC_CLIENTE_INS]
end
GO


 CREATE PROCEDURE [dbo].[ADC_CLIENTE_INS]
    (
    @Opcion char(1)='',
    @CodigoCli varchar(15)='',
	@TipoCli varchar(5)='',
	@ZonaVentas varchar(5)='',
	@VendedorInterno varchar(15)='',
	@ZonaCobranza varchar(5)='',
	@CobradorInterno varchar(5)='',
	@PrecioVenta varchar(5)='',
	@PorcDescuento numeric(8,2)=0,
	@FormaPago varchar(5)='',
	@LimiteCredito numeric(18,2)=0,
	@DescuentoAso numeric(8,2)=0,
	@Observaciones varchar(128)='',
	@CtbCobrar varchar(15)='',
	@Entregarmercaderia varchar(50)='',
	@Contacto varchar(50)=''
	) 
AS
BEGIN      
if (@Opcion ='I')
begin
	insert into CLIENTE  
		(
		CodigoCli,
		TipoCli,
		ZonaVentas,
		VendedorInterno,
		ZonaCobranza,
		CobradorInterno,
		PrecioVenta,
		PorcDescuento,
		FormaPago,
		LimiteCredito,
		DescuentoAso,
		Observaciones,
		CtbCobrar,
		Entregarmercaderia,
		Contacto
	)
	values
	(
		@CodigoCli,
		@TipoCli,
		@ZonaVentas,
		@VendedorInterno,
		@ZonaCobranza,
		@CobradorInterno,
		@PrecioVenta,
		@PorcDescuento,
		@FormaPago,
		@LimiteCredito,
		@DescuentoAso,
		@Observaciones,
		@CtbCobrar,
		@Entregarmercaderia,
		@Contacto
	)
	end
	else
	if @Opcion ='U'
	begin
	update CLIENTE  
	set
		TipoCli=@TipoCli,
		ZonaVentas=@ZonaVentas,
		VendedorInterno=@VendedorInterno,
		ZonaCobranza=@ZonaCobranza,
		CobradorInterno=@CobradorInterno,
		PrecioVenta=@PrecioVenta,
		PorcDescuento=@PorcDescuento,
		FormaPago=@FormaPago,
		LimiteCredito=@LimiteCredito,
		DescuentoAso=@DescuentoAso,
		Observaciones=@Observaciones,
		CtbCobrar=@CtbCobrar,
		Entregarmercaderia=@Entregarmercaderia,
		Contacto=@Contacto
 
end
END
GO

if exists(select * from sys.objects where name ='ACTOPC_CONS')
begin
DROP PROCEDURE [dbo].[ACTOPC_CONS]
end
GO

 CREATE PROCEDURE [dbo].[ACTOPC_CONS]

AS
BEGIN         
	SELECT *
	FROM AdcOpc 
END
GO

if exists(select * from sys.objects where name ='ACTNOV_INS_MOV')
begin
DROP PROCEDURE [dbo].[ACTNOV_INS_MOV]
end
GO

 CREATE PROCEDURE [dbo].[ACTNOV_INS_MOV]
    (@Opcion CHAR(1)='',
    @Doc_sucursal char(3)='',
	@Opc_documento char(3)='',
	@Doc_numero numeric (18,0)=0,
	@Codigo varchar(20)='',
	@FechaDocumento datetime = null,
	@FechaNovedad datetime = null,
	@TipoNovedad varchar(50)='',
	@NVSucursalNueva varchar(50)='',
	@NvDepartamentoNvo varchar(50)='',
	@NvSeccionNvo varchar(50)='',
	@NvResponsable varchar(50)='',
	@Observaciones varchar(50)=''
		)
AS
BEGIN         
	IF @Opcion ='I'
	INSERT INTO AdcAcfNov
	(
		Doc_sucursal,
		Opc_documento,
		Doc_numero,
		Codigo,
		FechaDocumento,
		FechaNovedad,
		TipoNovedad,
		NVSucursalNueva,
		NvDepartamentoNvo,
		NvSeccionNvo,
		NvResponsable,
		Observaciones
	    )
		 
	VALUES(
		@Doc_sucursal,
		@Opc_documento,
		@Doc_numero,
		@Codigo,
		@FechaDocumento,
		@FechaNovedad,
		@TipoNovedad ,
		@NVSucursalNueva,
		@NvDepartamentoNvo,
		@NvSeccionNvo ,
		@NvResponsable ,
		@Observaciones
		 )
	ELSE 
		IF @Opcion ='U'
		UPDATE AdcAcfNov 
		SET
			FechaDocumento=@FechaDocumento ,
			FechaNovedad=@FechaNovedad ,
			TipoNovedad=@TipoNovedad ,
			NVSucursalNueva=@NVSucursalNueva ,
			NvDepartamentoNvo=@NvDepartamentoNvo ,
			NvSeccionNvo=@NvSeccionNvo ,
			NvResponsable=@NvResponsable ,
			Observaciones=@Observaciones 
			where Codigo = @Codigo and Opc_documento =@Opc_documento and 
			Doc_numero =@Doc_numero and Doc_sucursal=@Doc_sucursal  
END

GO

if exists(select * from sys.objects where name ='ACTNOV_ELM_MOV')
begin
DROP PROCEDURE [dbo].[ACTNOV_ELM_MOV]
end
GO
 CREATE PROCEDURE [dbo].[ACTNOV_ELM_MOV]
    (@Opcion CHAR(1)='',
    @Doc_sucursal char(3)='',
	@Opc_documento char(3)='',
	@Doc_numero numeric (18,0)=0,
	@Codigo varchar(20)='',
	@FechaDocumento datetime = null
		)
AS
BEGIN         
	IF @Opcion ='E'
	DELETE FROM AdcAcfNov
	where Codigo = @Codigo and Opc_documento =@Opc_documento and 
		Doc_numero =@Doc_numero and Doc_sucursal=@Doc_sucursal and
		FechaDocumento =@FechaDocumento and TipoNovedad='MOV_ACT'
END

GO


if exists(select * from sys.objects where name ='ACTFDET_INS')
begin
DROP PROCEDURE [dbo].[ACTFDET_INS]
end
GO

 CREATE PROCEDURE [dbo].[ACTFDET_INS]
    (
    @Doc_sucursal char(3)='',
	@Opc_documento char(3)='',
	@Doc_numero numeric(18,0)=0,
	@Codigo varchar(20)='',
	@FechaDocumento datetime=null,
	@FechaNovedad datetime=null,
	@NVdeterioro numeric(22,4)=0,
	@NVrevalorizacion numeric(22,4)=0
	) 
AS
BEGIN         
	insert into AdcAcfNov 
	(
	Doc_sucursal,
	Opc_documento,
	Doc_numero,
	Codigo,
	FechaDocumento,
	FechaNovedad,
	NVdeterioro,
	NVrevalorizacion)
	values
	(
	@Doc_sucursal,
	@Opc_documento,
	@Doc_numero,
	@Codigo,
	@FechaDocumento,
	@FechaNovedad,
	@NVdeterioro,
	@NVrevalorizacion)
END

GO

if exists(select * from sys.objects where name ='ACTFDEP_LISTADO')
begin
DROP PROCEDURE [dbo].[ACTFDEP_LISTADO]
end
GO

 CREATE PROCEDURE [dbo].[ACTFDEP_LISTADO]
    (
    @Codigo varchar(20)='',
    @Clase as char(3)='',
    @opcion as char(3)=''
	) 
AS
BEGIN 
if @opcion =1
begin        
	if (@clase='TD')
		begin
		select Codigo
		,(case when ClaseDepreciacion = 'T' then 'Tributaria'else 'Financiera' end)as Clase , año as Año
		,sum(case when Mes = 1 then cast(DepreciacionMes as numeric(18,2)) else 0 end) as Enero
		,sum(case when Mes = 2 then cast(DepreciacionMes as numeric(18,2)) else 0 end) as Febrero
		,sum(case when Mes = 3 then cast(DepreciacionMes as numeric(18,2)) else 0 end) as Marzo
		,sum(case when Mes = 4 then cast(DepreciacionMes as numeric(18,2)) else 0 end) as Abril
		,sum(case when Mes = 5 then cast(DepreciacionMes as numeric(18,2)) else 0 end) as Mayo
		,sum(case when Mes = 6 then cast(DepreciacionMes as numeric(18,2)) else 0 end) as Junio
		,sum(case when Mes = 7 then cast(DepreciacionMes as numeric(18,2)) else 0 end) as Julio
		,sum(case when Mes = 8 then cast(DepreciacionMes as numeric(18,2)) else 0 end) as Agosto
		,sum(case when Mes = 9 then cast(DepreciacionMes as numeric(18,2)) else 0 end) as Septiembre
		,sum(case when Mes = 10 then cast(DepreciacionMes as numeric(18,2)) else 0 end) as Octubre
		,sum(case when Mes = 11 then cast(DepreciacionMes as numeric(18,2)) else 0 end) as Noviembre
		,sum(case when Mes = 12 then cast(DepreciacionMes as numeric(18,2)) else 0 end) as Diciembre
		,SUM(DepreciacionMes) as Total
		from AdcAcfDep where Codigo= @Codigo group by Codigo, ClaseDepreciacion, año 
		end
	else
		begin
		select Codigo
		,(case when ClaseDepreciacion = 'T' then 'Tributaria'else 'Financiera' end)as Clase , año as Año
		,sum(case when Mes = 1 then cast(DepreciacionMes as numeric(18,2)) else 0 end) as Enero
		,sum(case when Mes = 2 then cast(DepreciacionMes as numeric(18,2)) else 0 end) as Febrero
		,sum(case when Mes = 3 then cast(DepreciacionMes as numeric(18,2)) else 0 end) as Marzo
		,sum(case when Mes = 4 then cast(DepreciacionMes as numeric(18,2)) else 0 end) as Abril
		,sum(case when Mes = 5 then cast(DepreciacionMes as numeric(18,2)) else 0 end) as Mayo
		,sum(case when Mes = 6 then cast(DepreciacionMes as numeric(18,2)) else 0 end) as Junio
		,sum(case when Mes = 7 then cast(DepreciacionMes as numeric(18,2)) else 0 end) as Julio
		,sum(case when Mes = 8 then cast(DepreciacionMes as numeric(18,2)) else 0 end) as Agosto
		,sum(case when Mes = 9 then cast(DepreciacionMes as numeric(18,2)) else 0 end) as Septiembre
		,sum(case when Mes = 10 then cast(DepreciacionMes as numeric(18,2)) else 0 end) as Octubre
		,sum(case when Mes = 11 then cast(DepreciacionMes as numeric(18,2)) else 0 end) as Noviembre
		,sum(case when Mes = 12 then cast(DepreciacionMes as numeric(18,2)) else 0 end) as Diciembre
		,SUM(DepreciacionMes) as Total
		from AdcAcfDep where Codigo= @Codigo and ClaseDepreciacion=ltrim(rtrim(@Clase)) group by Codigo, ClaseDepreciacion, año 
		end	
end
else
if (@clase='TD')
		begin
		select @Codigo as Codigo
		,(case when ClaseDepreciacion = 'T' then 'Tributaria'else 'Financiera' end)as Clase , año as Año
		,sum(case when Mes = 1 then cast(DepreciacionMes as numeric(18,2)) else 0 end) as Enero
		,sum(case when Mes = 2 then cast(DepreciacionMes as numeric(18,2)) else 0 end) as Febrero
		,sum(case when Mes = 3 then cast(DepreciacionMes as numeric(18,2)) else 0 end) as Marzo
		,sum(case when Mes = 4 then cast(DepreciacionMes as numeric(18,2)) else 0 end) as Abril
		,sum(case when Mes = 5 then cast(DepreciacionMes as numeric(18,2)) else 0 end) as Mayo
		,sum(case when Mes = 6 then cast(DepreciacionMes as numeric(18,2)) else 0 end) as Junio
		,sum(case when Mes = 7 then cast(DepreciacionMes as numeric(18,2)) else 0 end) as Julio
		,sum(case when Mes = 8 then cast(DepreciacionMes as numeric(18,2)) else 0 end) as Agosto
		,sum(case when Mes = 9 then cast(DepreciacionMes as numeric(18,2)) else 0 end) as Septiembre
		,sum(case when Mes = 10 then cast(DepreciacionMes as numeric(18,2)) else 0 end) as Octubre
		,sum(case when Mes = 11 then cast(DepreciacionMes as numeric(18,2)) else 0 end) as Noviembre
		,sum(case when Mes = 12 then cast(DepreciacionMes as numeric(18,2)) else 0 end) as Diciembre
		,SUM(DepreciacionMes) as Total
		from AdcAcfDep where Codigo in (
		select Codigo from AdcAcf where CodActivoPrincipal = @Codigo  or codigo = @Codigo 
		)
		 group by ClaseDepreciacion, año 
		end
	else
		begin
		select @Codigo as Codigo
		,(case when ClaseDepreciacion = 'T' then 'Tributaria'else 'Financiera' end)as Clase , año as Año
		,sum(case when Mes = 1 then cast(DepreciacionMes as numeric(18,2)) else 0 end) as Enero
		,sum(case when Mes = 2 then cast(DepreciacionMes as numeric(18,2)) else 0 end) as Febrero
		,sum(case when Mes = 3 then cast(DepreciacionMes as numeric(18,2)) else 0 end) as Marzo
		,sum(case when Mes = 4 then cast(DepreciacionMes as numeric(18,2)) else 0 end) as Abril
		,sum(case when Mes = 5 then cast(DepreciacionMes as numeric(18,2)) else 0 end) as Mayo
		,sum(case when Mes = 6 then cast(DepreciacionMes as numeric(18,2)) else 0 end) as Junio
		,sum(case when Mes = 7 then cast(DepreciacionMes as numeric(18,2)) else 0 end) as Julio
		,sum(case when Mes = 8 then cast(DepreciacionMes as numeric(18,2)) else 0 end) as Agosto
		,sum(case when Mes = 9 then cast(DepreciacionMes as numeric(18,2)) else 0 end) as Septiembre
		,sum(case when Mes = 10 then cast(DepreciacionMes as numeric(18,2)) else 0 end) as Octubre
		,sum(case when Mes = 11 then cast(DepreciacionMes as numeric(18,2)) else 0 end) as Noviembre
		,sum(case when Mes = 12 then cast(DepreciacionMes as numeric(18,2)) else 0 end) as Diciembre
		,SUM(DepreciacionMes) as Total
		from AdcAcfDep where Codigo in (
		select Codigo from AdcAcf where CodActivoPrincipal = @Codigo  or codigo = @Codigo 
		) and ClaseDepreciacion=ltrim(rtrim(@Clase)) group by ClaseDepreciacion, año 
		end	
END
GO

if exists(select * from sys.objects where name ='ACTFDEP_INS')
begin
DROP PROCEDURE [dbo].[ACTFDEP_INS]
end
GO


 CREATE PROCEDURE [dbo].[ACTFDEP_INS]
    (
    @Codigo varchar(20)='',
	@año numeric(4,0)=0,
	@Mes numeric(4,0)=0,
	@ClaseDepreciacion char(1)='',
	@AcumDepreciacion numeric(22,8)=0,
	@AcumRevaloriizacion numeric(22,8)=0,
	@AcumDeterioro numeric(22,8)=0,
	@VidaUtilAlMes numeric(18,0)=0,
	@CapacidadProduccionMes numeric(18,0)=0,
	@NroDiasLiquidacion numeric(4,0)=0,
	@ProduccionMes numeric(22,8)=0,
	@ValorResidual numeric(22,8)=0,
	@DeterioroMes numeric(22,8)=0,
	@RevalorizacionMes numeric(22,8)=0,
	@DepreciacionMes numeric(22,8)=0,
	@FechaProceso datetime=null,
	@UsuarioProceso varchar(50)='',
	@Estado bit=0,
	@Acumulados bit=0
	) 
AS
BEGIN         
	insert into AdcAcfDep 
	(
	Codigo,
	año,
	Mes,
	ClaseDepreciacion,
	AcumDepreciacion,
	AcumRevaloriizacion,
	AcumDeterioro,
	VidaUtilAlMes,
	CapacidadProduccionMes,
	NroDiasLiquidacion,
	ProduccionMes,
	ValorResidual,
	DeterioroMes,
	RevalorizacionMes,
	DepreciacionMes,
	FechaProceso,
	UsuarioProceso,
	Estado,
	Acumulados )
	values
	(
	@Codigo,
	@año,
	@Mes,
	@ClaseDepreciacion,
	@AcumDepreciacion,
	@AcumRevaloriizacion,
	@AcumDeterioro,
	@VidaUtilAlMes,
	@CapacidadProduccionMes,
	@NroDiasLiquidacion,
	@ProduccionMes,
	@ValorResidual,
	@DeterioroMes,
	@RevalorizacionMes,
	@DepreciacionMes,
	@FechaProceso,
	@UsuarioProceso,
	@Estado,
	@Acumulados )
END

GO


if exists(select * from sys.objects where name ='ACTF_INS_MOD')
begin
DROP PROCEDURE [dbo].[ACTF_INS_MOD]
end
GO


 CREATE PROCEDURE [dbo].[ACTF_INS_MOD]
    (@OPCION VARCHAR(3)='',
    @CODIGO VARCHAR(20)='',
	@NOMBRE VARCHAR(80)='',
	@TIPOACTIVO VARCHAR(20),
	@CATEGORIA VARCHAR(5)='',
	@CLASE VARCHAR(5)='',
	@GRUPO VARCHAR(5)='',
	@SUBGRUPO VARCHAR(5)='',
	@MARCA VARCHAR(30)='',
	@SERIE VARCHAR(25)='',
	@NROLOTE VARCHAR(20)='',
	@CENTROCOSTO VARCHAR(25)='',
	@CODACTIVOPRINCIPAL VARCHAR(20)='',
	@ESACTIVOCOMPUESTO BIT='',
	@DESCRIPCION NTEXT='',
	@UBICASUCURSAL VARCHAR(3)='',
	@UBICADEPARTAMENTO VARCHAR(3)='',
	@UBICASECCION VARCHAR(30)='',
	@RESPONSABLE VARCHAR(50)='',
	@ESTADO VARCHAR(40)='',
	@TASADEPRESIACION NUMERIC(8,4)=0,
	@FECINGRESO DATETIME='',
	@COSTOINGRESO NUMERIC(22,8)=0,
	@DOCTIPINGRESO VARCHAR(3)='',
	@DOCNUMINGRESO NUMERIC(18,0)=0,
	@FECSALIDA DATETIME='',
	@DOCTIPSALIDA VARCHAR(3)='',
	@DOCNUMSALIDA NUMERIC(18,0)=0,
	@CTACONTABLE1 VARCHAR(15)='',
	@CTACONTABLE2 VARCHAR(15)='',
	@CTACONTABLE3 VARCHAR(15)='',
	@CTACONTABLE4 VARCHAR(15)='',
	@VALORRESIDUAL NUMERIC(22,8)=0,
	@TIPODEPRECIACIONCONT INT=0,
	@TIPODEPRECIACIONTRIBUTA INT=0,
	@VIDAUTILCONT NUMERIC(4,0)=0,
	@VIDAUTILTRIBUTA NUMERIC(4,0)=0,
	@UNIDADESPRODUCCIONCONT NUMERIC(10,0)='',
	@UNIDADESPRODUCCIONTRIB NUMERIC(10,0)='',
	@TASADEPCONT NUMERIC(8,4)='',
	@TASADEPTRIBUT NUMERIC(8,4)=0,
	@VALORACTUALCONT NUMERIC(22,4)=0,
	@VALORACTUALTRIBUT NUMERIC(22,4)=0,
	@ULTIMOAÑOCALC NUMERIC(6,0)=0,
	@ULTIMOMESCALC NUMERIC(6,0)=0,
	@USUARIOCREA VARCHAR(30)='',
	@FECHACREA DATETIME='',
	@USUARIOMODIFICA VARCHAR(30)='',
	@FECHAMODIFICA DATETIME='',
	@TEXTO1 VARCHAR(30)='',
	@TEXTO2 VARCHAR(30)='',
	@TEXTO3 VARCHAR(30)='',
	@TEXTO4 VARCHAR(30)='',
	@TEXTO5 VARCHAR(30)='',
	@TEXTO6 VARCHAR(30)='',
	@TEXTO7 VARCHAR(30)='',
	@TEXTO8 VARCHAR(30)='',
	@TEXTO9 VARCHAR(30)='',
	@TEXTO10 VARCHAR(30)='',
	@DET1 VARCHAR(80)='',
	@DET2 VARCHAR(80)='',
	@DET3 VARCHAR(80)='',
	@DET4 VARCHAR(80)='',
	@DET5 VARCHAR(80)='',
	@VALOR1 NUMERIC(22,8)=0,
	@VALOR2 NUMERIC(22,8)=0,
	@VALOR3 NUMERIC(22,8)=0,
	@VALOR4 NUMERIC(22,8)=0,
	@VALOR5 NUMERIC(22,8)=0,
	@FECHA1 DATETIME=null,
	@FECHA2 DATETIME=null,
	@FECHA3 DATETIME=null,
	@LOGICO1 BIT='',
	@LOGICO2 BIT='',
	@LOGICO3 BIT='',
	@IMAGEN VARCHAR(512)='', 
	@CANTIDAD NUMERIC(22,8)=0,
	@ASEGURADORA VARCHAR(30)='',
	@NCONTRATO NUMERIC(22,0)=0,
	@FECHAINGSEGURO DATETIME=NULL,
	@FECHASALSEGURO DATETIME=NULL,
	@MONTOASEGURADO NUMERIC(22,8)=0,
	@DEDUCIBLE NUMERIC(22,8)=0,
	@PAGOMENSUAL NUMERIC (22,8)=0,
	@MONEDA CHAR(3)='',
	@PARIDAD NUMERIC(22,8)=0
	)
AS
BEGIN         
	IF @OPCION ='I'
	INSERT INTO AdcAcf
	(
		Codigo,
		Nombre,
		TipoActivo,
		Categoria,
		Clase,
		Grupo,
		Subgrupo,
		Marca,
		Serie,
		NroLote,
		CentroCosto,
		CodActivoPrincipal,
		EsActivoCompuesto,
		Descripcion,
		UbicaSucursal,
		UbicaDepartamento,
		UbicaSeccion,
		Responsable,
		Estado,
		TasaDepreciacion,
		FecIngreso,
		CostoIngreso,
		DocTipIngreso,
		DocNumIngreso,
		FecSalida,
		DocTipSalida,
		DocNumSalida,
		CtaContable1,
		CtaContable2,
		CtaContable3,
		CtaContable4,
		ValorResidual,
		TipoDepreciacionCont,
		TipoDepreciacionTributa,
		VidaUtilCont,
		VidaUtilTributa,
		UnidacesProduccionCont,
		UnidadesProduccionTribut,
		TasaDepCont,
		TasaDepTribut,
		ValorActualCont,
		ValorActualTribut,
		UltimoAñoCalc,
		UltimoMesCalc,
		UsuarioCrea,
		FechaCrea,
		UsuarioModifica,
		FechaModifica,
		Texto1,
		Texto2,
		Texto3,
		Texto4,
		Texto5,
		Texto6,
	    Texto7,
	    Texto8,
	    Texto9,
	    Texto10,
		Det1,
		Det2,
		Det3,
		Det4,
		Det5,
		Valor1,
		Valor2,
		Valor3,
		Valor4,
		Valor5,
		Fecha1,
		Fecha2,
		Fecha3,
		Logico1,
		Logico2,
		Logico3,
		Imagen,
		Cantidad,
		Aseguradora,
		NContrato,
		FechaIngSeguro,
		FechaSalSeguro,
		MontoAsegurado,
		Deducible,
		PagoMensual,
		Moneda,
		Paridad
	    )
		 
	VALUES(
		@CODIGO,
		@NOMBRE,
		@TIPOACTIVO,
		@CATEGORIA,
		@CLASE,
		@GRUPO,
		@SUBGRUPO,
		@MARCA,
		@SERIE,
		@NROLOTE,
		@CENTROCOSTO,
		@CODACTIVOPRINCIPAL,
		@ESACTIVOCOMPUESTO ,
		@DESCRIPCION,
		@UBICASUCURSAL,
		@UBICADEPARTAMENTO,
		@UBICASECCION,
		@RESPONSABLE,
		@ESTADO,
		@TASADEPRESIACION,
		@FECINGRESO,
		@COSTOINGRESO,
		@DOCTIPINGRESO,
		@DOCNUMINGRESO,
		@FECSALIDA,
		@DOCTIPSALIDA,
		@DOCNUMSALIDA,
		@CTACONTABLE1,
		@CTACONTABLE2,
		@CTACONTABLE3,
		@CTACONTABLE4,
		@VALORRESIDUAL,
		@TIPODEPRECIACIONCONT ,
		@TIPODEPRECIACIONTRIBUTA ,
		@VIDAUTILCONT,
		@VIDAUTILTRIBUTA,
		@UNIDADESPRODUCCIONCONT ,
		@UNIDADESPRODUCCIONTRIB ,
		@TASADEPCONT,
		@TASADEPTRIBUT,
		@VALORACTUALCONT,
		@VALORACTUALTRIBUT,
		@ULTIMOAÑOCALC,
		@ULTIMOMESCALC,
		@USUARIOCREA,
		@FECHACREA,
		@USUARIOMODIFICA,
		@FECHAMODIFICA,
		@TEXTO1,
		@TEXTO2,
		@TEXTO3,
		@TEXTO4,
		@TEXTO5,
		@TEXTO6,
		@TEXTO7,
		@TEXTO8,
		@TEXTO9,
		@TEXTO10,
		@DET1,
		@DET2,
		@DET3,
		@DET4,
		@DET5,
		@VALOR1,
		@VALOR2,
		@VALOR3,
		@VALOR4,
		@VALOR5,
		@FECHA1,
		@FECHA2,
		@FECHA3,
		@LOGICO1,
		@LOGICO2,
		@LOGICO3,
		@IMAGEN,
		@CANTIDAD,
		@ASEGURADORA,
		@NCONTRATO,
		@FECHAINGSEGURO,
		@FECHASALSEGURO,
		@MONTOASEGURADO,
		@DEDUCIBLE,
		@PAGOMENSUAL,
		@MONEDA,
		@PARIDAD )
	ELSE
	   IF @OPCION='U'
	      UPDATE AdcAcf 
	      SET
	      Nombre = @NOMBRE,
	      Categoria = @CATEGORIA ,
	      TipoActivo = @TIPOACTIVO ,
		  Clase = @CLASE ,
		  Grupo = @GRUPO ,
		  Subgrupo = @SUBGRUPO ,
		  Marca = @MARCA ,
		  Serie = @SERIE ,
		  NroLote = @NROLOTE ,
		  CentroCosto = @CENTROCOSTO ,
		  CodActivoPrincipal = @CODACTIVOPRINCIPAL ,
		  EsActivoCompuesto = @ESACTIVOCOMPUESTO ,
		  Descripcion = @DESCRIPCION ,
		  UbicaSucursal = @UBICASUCURSAL ,
		  UbicaDepartamento = @UBICADEPARTAMENTO ,
		  UbicaSeccion = @UBICASECCION ,
		  Responsable = @RESPONSABLE ,
		  Estado = @ESTADO ,
		  TasaDepreciacion = @TASADEPRESIACION ,
		  FecIngreso = @FECINGRESO ,
		  CostoIngreso = @COSTOINGRESO ,
		  DocTipIngreso = @DOCTIPINGRESO ,
		  DocNumIngreso = @DOCNUMSALIDA ,
		  FecSalida = @FECSALIDA ,
		  DocTipSalida = @DOCTIPSALIDA ,
		  DocNumSalida = @DOCNUMSALIDA,
		  CtaContable1 = @CTACONTABLE1 ,
		  CtaContable2 = @CTACONTABLE2 ,
		  CtaContable3 = @CTACONTABLE3 ,
		  CtaContable4 = @CTACONTABLE4 ,
		  ValorResidual = @VALORRESIDUAL ,
		  TipoDepreciacionCont  = @TIPODEPRECIACIONCONT ,
		  TipoDepreciacionTributa = @TIPODEPRECIACIONTRIBUTA ,
		  VidaUtilCont = @VIDAUTILCONT ,
		  VidaUtilTributa = @VIDAUTILTRIBUTA ,
		  UnidacesProduccionCont = @UNIDADESPRODUCCIONCONT ,
		  UnidadesProduccionTribut = @UNIDADESPRODUCCIONTRIB ,
		  TasaDepCont = @TASADEPCONT ,
		  TasaDepTribut = @TASADEPTRIBUT ,
		  ValorActualCont = @VALORACTUALCONT ,
		  ValorActualTribut = @VALORACTUALTRIBUT,
		  UltimoAñoCalc = @ULTIMOAÑOCALC,
		  UltimoMesCalc = @ULTIMOMESCALC,
		  UsuarioCrea = @USUARIOCREA,
		  FechaCrea = @FECHACREA,
		  UsuarioModifica = @USUARIOMODIFICA,
		  FechaModifica = @FECHAMODIFICA,
		  Texto1 = @TEXTO1,
		  Texto2 = @TEXTO2,
		  Texto3 = @TEXTO3,
		  Texto4 = @TEXTO4,
		  Texto5 = @TEXTO5,
		  Texto6 = @TEXTO6,
	      Texto7 = @TEXTO7,
	      Texto8 = @TEXTO8,
	      Texto9 = @TEXTO9,
	      Texto10 = @TEXTO10,
		  Det1 = @DET1 ,
		  Det2 = @DET2 ,
		  Det3 = @DET3,
		  Det4 = @DET4,
		  Det5 = @DET5,
		  Valor1 = @VALOR1,
		  Valor2 = @VALOR2,
		  Valor3 = @VALOR3,
		  Valor4 = @VALOR4,
		  Valor5 = @VALOR5,
		  Fecha1 = @FECHA1,
		  Fecha2 = @FECHA2,
		  Fecha3 = @FECHA3,
		  Logico1 = @LOGICO1,
		  Logico2 = @LOGICO2,
		  Logico3 = @LOGICO3,
		  Imagen = @IMAGEN,
		  Cantidad =@CANTIDAD,
		  Aseguradora=@ASEGURADORA ,
		  NContrato=@NCONTRATO,
		  FechaIngSeguro=@FECHAINGSEGURO,
		  FechaSalSeguro=@FECHASALSEGURO,
		  MontoAsegurado=@MONTOASEGURADO,
		  Deducible=@DEDUCIBLE,
		  PagoMensual = @PAGOMENSUAL,
		  Moneda = @MONEDA,
		  Paridad=@PARIDAD 
	      WHERE Codigo = @CODIGO 
END

GO

if exists(select * from sys.objects where name ='ACTF_CON')
begin
DROP PROCEDURE [dbo].[ACTF_CON]
end
GO


 CREATE PROCEDURE [dbo].[ACTF_CON]
    (@OPCION VARCHAR(3)='',
    @CODIGO VARCHAR(20)=''
	) 
AS
BEGIN         
	IF @OPCION ='C'
	   SELECT * 
	   FROM AdcAcf
	   WHERE Codigo = LTRIM(RTRIM(@CODIGO ))
	ELSE 
		IF @OPCION ='E'
			DELETE FROM AdcAcf 
			WHERE Codigo = LTRIM(RTRIM(@CODIGO ))
		ELSE
			SELECT *
			FROM AdcAcf  
END

GO

if exists(select * from sys.objects where name ='ACTF_ACTFDEP_INS')
begin
DROP PROCEDURE [dbo].[ACTF_ACTFDEP_INS]
end
GO


 CREATE PROCEDURE [dbo].[ACTF_ACTFDEP_INS]
    (
    @Codigo varchar(20)='',
	@año numeric(4,0)=0,
	@Mes numeric(4,0)=0,
	@ClaseDepreciacion char(1)='',
	@AcumDepreciacion numeric(22,8)=0,
	@AcumRevaloriizacion numeric(22,8)=0,
	@AcumDeterioro numeric(22,8)=0,
	@VidaUtilAlMes numeric(18,0)=0,
	@CapacidadProduccionMes numeric(18,0)=0,
	@NroDiasLiquidacion numeric(4,0)=0,
	@ProduccionMes numeric(22,8)=0,
	@ValorResidual numeric(22,8)=0,
	@DeterioroMes numeric(22,8)=0,
	@RevalorizacionMes numeric(22,8)=0,
	@DepreciacionMes numeric(22,8)=0,
	@FechaProceso datetime=null,
	@UsuarioProceso varchar(50)='',
	@Estado bit=''
	) 
AS
BEGIN         
	insert into AdcAcfDep 
	(
	Codigo,
	año,
	Mes,
	ClaseDepreciacion,
	AcumDepreciacion,
	AcumRevaloriizacion,
	AcumDeterioro,
	VidaUtilAlMes,
	CapacidadProduccionMes,
	NroDiasLiquidacion,
	ProduccionMes,
	ValorResidual,
	DeterioroMes,
	RevalorizacionMes,
	DepreciacionMes,
	FechaProceso,
	UsuarioProceso,
	Estado)
	values
	(
	@Codigo,
	@año,
	@Mes,
	@ClaseDepreciacion,
	@AcumDepreciacion,
	@AcumRevaloriizacion,
	@AcumDeterioro,
	@VidaUtilAlMes,
	@CapacidadProduccionMes,
	@NroDiasLiquidacion,
	@ProduccionMes,
	@ValorResidual,
	@DeterioroMes,
	@RevalorizacionMes,
	@DepreciacionMes,
	@FechaProceso,
	@UsuarioProceso,
	@Estado)
END

GO


--**********************HERRAMIENTAS NIF*********************************************

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[AdcVnr]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[AdcVnr]
GO

CREATE TABLE [dbo].[AdcVnr] (
	[vnr_codigo] [varchar] (20) COLLATE Modern_Spanish_CI_AS NULL ,
	[vnr_nombre] [varchar] (40) COLLATE Modern_Spanish_CI_AS NULL ,
	[vnr_existencia] [numeric](18, 6) NULL ,
	[vnr_valorunit] [numeric](18, 6) NULL ,
	[vnr_valortot] [numeric](18, 6) NULL ,
	[vnr_pvpunit] [numeric](18, 6) NULL ,
	[vnr_pvptot] [numeric](18, 6) NULL ,
	[vnr_costestimado] [numeric](18, 6) NULL ,
	[vnr_gastoterm] [numeric](18, 6) NULL ,
	[vnr_gastovent] [numeric](18, 6) NULL ,
	[vnr_valnetoreal] [numeric](18, 6) NULL ,
	[vnr_año] [varchar] (5) COLLATE Modern_Spanish_CI_AS NULL,
	[vnr_periodo][varchar](50) NULL,
	[vnr_valorAjustar] [numeric](18, 6) NULL,
	[vnr_NumDoc] [numeric](18, 0) NULL,
	[vnr_Mes] [varchar](5) NULL,
	[vnr_TipoDoc] [nchar](3) NULL,
	[vnr_NuevoCosto] [numeric](18, 6) NULL
) ON [PRIMARY]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[AdcNote]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[AdcNote]
GO

/****** Object:  Table [dbo].[AdcNote]    Script Date: 10/13/2010 09:39:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[AdcNote](
	[Nota_Codigo] [decimal](18, 0) NULL,
	[Nota_Cta] [varchar](15) NULL,
	[Nota_Mes] [varchar](5) NULL,
	[Nota_Año] [varchar](5) NULL,
	[Nota_Descripcion] [ntext] NULL,
	[Nota_Origen] [varchar](15) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCta' and col.name='Res_Vta')
begin
Alter table AdcCta add Res_Vta bit null
end
go

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCta' and col.name='Res_Cos')
begin
Alter table AdcCta add Res_Cos bit null
end
go

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCta' and col.name='Res_Gas')
begin
Alter table AdcCta add Res_Gas bit null
end
go

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCta' and col.name='Res_MovFin')
begin
Alter table AdcCta add Res_MovFin bit null
end
go

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCta' and col.name='Res_Imp')
begin
Alter table AdcCta add Res_Imp bit null
end
go

-------------------------------------------------------------------------------------

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCtaMov' and col.name='ene_sal')
begin
Alter table AdcCtaMov add ene_sal numeric(22,8) null
end
go

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCtaMov' and col.name='ene_deb')
begin
Alter table AdcCtaMov add ene_deb numeric(22,8) null
end
go

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCtaMov' and col.name='ene_cre')
begin
Alter table AdcCtaMov add ene_cre numeric(22,8) null
end
go

----------------------------
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCtaMov' and col.name='feb_sal')
begin
Alter table AdcCtaMov add feb_sal numeric(22,8) null
end
go

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCtaMov' and col.name='feb_deb')
begin
Alter table AdcCtaMov add feb_deb numeric(22,8) null
end
go

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCtaMov' and col.name='feb_cre')
begin
Alter table AdcCtaMov add feb_cre numeric(22,8) null
end
go

----------------------------
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCtaMov' and col.name='feb_sal')
begin
Alter table AdcCtaMov add feb_sal numeric(22,8) null
end
go

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCtaMov' and col.name='feb_deb')
begin
Alter table AdcCtaMov add feb_deb numeric(22,8) null
end
go

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCtaMov' and col.name='feb_cre')
begin
Alter table AdcCtaMov add feb_cre numeric(22,8) null
end
go

-----------------------------
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCtaMov' and col.name='mar_sal')
begin
Alter table AdcCtaMov add mar_sal numeric(22,8) null
end
go

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCtaMov' and col.name='mar_deb')
begin
Alter table AdcCtaMov add mar_deb numeric(22,8) null
end
go

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCtaMov' and col.name='mar_cre')
begin
Alter table AdcCtaMov add mar_cre numeric(22,8) null
end
go

-----------------------------
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCtaMov' and col.name='abr_sal')
begin
Alter table AdcCtaMov add abr_sal numeric(22,8) null
end
go

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCtaMov' and col.name='abr_deb')
begin
Alter table AdcCtaMov add abr_deb numeric(22,8) null
end
go

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCtaMov' and col.name='abr_cre')
begin
Alter table AdcCtaMov add abr_cre numeric(22,8) null
end
go
------------------------------
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCtaMov' and col.name='may_sal')
begin
Alter table AdcCtaMov add may_sal numeric(22,8) null
end
go

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCtaMov' and col.name='may_deb')
begin
Alter table AdcCtaMov add may_deb numeric(22,8) null
end
go

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCtaMov' and col.name='may_cre')
begin
Alter table AdcCtaMov add may_cre numeric(22,8) null
end
go
--------------------------------
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCtaMov' and col.name='may_sal')
begin
Alter table AdcCtaMov add may_sal numeric(22,8) null
end
go

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCtaMov' and col.name='may_deb')
begin
Alter table AdcCtaMov add may_deb numeric(22,8) null
end
go

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCtaMov' and col.name='may_cre')
begin
Alter table AdcCtaMov add may_cre numeric(22,8) null
end
go
---------------------------------
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCtaMov' and col.name='jun_sal')
begin
Alter table AdcCtaMov add jun_sal numeric(22,8) null
end
go

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCtaMov' and col.name='jun_deb')
begin
Alter table AdcCtaMov add jun_deb numeric(22,8) null
end
go

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCtaMov' and col.name='jun_cre')
begin
Alter table AdcCtaMov add jun_cre numeric(22,8) null
end
go
--------------------------------
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCtaMov' and col.name='jul_sal')
begin
Alter table AdcCtaMov add jul_sal numeric(22,8) null
end
go

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCtaMov' and col.name='jul_deb')
begin
Alter table AdcCtaMov add jul_deb numeric(22,8) null
end
go

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCtaMov' and col.name='jul_cre')
begin
Alter table AdcCtaMov add jul_cre numeric(22,8) null
end
go
--------------------------------
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCtaMov' and col.name='ags_sal')
begin
Alter table AdcCtaMov add ags_sal numeric(22,8) null
end
go

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCtaMov' and col.name='ags_deb')
begin
Alter table AdcCtaMov add ags_deb numeric(22,8) null
end
go

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCtaMov' and col.name='ags_cre')
begin
Alter table AdcCtaMov add ags_cre numeric(22,8) null
end
go
---------------------------------
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCtaMov' and col.name='sep_sal')
begin
Alter table AdcCtaMov add sep_sal numeric(22,8) null
end
go

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCtaMov' and col.name='sep_deb')
begin
Alter table AdcCtaMov add sep_deb numeric(22,8) null
end
go

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCtaMov' and col.name='sep_cre')
begin
Alter table AdcCtaMov add sep_cre numeric(22,8) null
end
go
-----------------------------------
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCtaMov' and col.name='oct_sal')
begin
Alter table AdcCtaMov add oct_sal numeric(22,8) null
end
go

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCtaMov' and col.name='oct_deb')
begin
Alter table AdcCtaMov add oct_deb numeric(22,8) null
end
go

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCtaMov' and col.name='oct_cre')
begin
Alter table AdcCtaMov add oct_cre numeric(22,8) null
end
go

--------------------------------
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCtaMov' and col.name='nov_sal')
begin
Alter table AdcCtaMov add nov_sal numeric(22,8) null
end
go

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCtaMov' and col.name='nov_deb')
begin
Alter table AdcCtaMov add nov_deb numeric(22,8) null
end
go

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCtaMov' and col.name='nov_cre')
begin
Alter table AdcCtaMov add nov_cre numeric(22,8) null
end
go
-------------------------------
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCtaMov' and col.name='dic_sal')
begin
Alter table AdcCtaMov add dic_sal numeric(22,8) null
end
go

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCtaMov' and col.name='dic_deb')
begin
Alter table AdcCtaMov add dic_deb numeric(22,8) null
end
go

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCtaMov' and col.name='dic_cre')
begin
Alter table AdcCtaMov add dic_cre numeric(22,8) null
end
go

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcAcf' and col.name='EsComponente')
begin
Alter table AdcAcf add EsComponente bit null
end
go

if exists(select * from sys.objects where name ='ADCTRA_GENERAR_INV')
begin
DROP PROCEDURE [dbo].[ADCTRA_GENERAR_INV]
end
GO

 CREATE PROCEDURE [dbo].[ADCTRA_GENERAR_INV]
 (
	@Doc_sucursal char(3)='',	
	@Doc_Bodega char(3)='',	
	@Opc_documento char(3)='',	
	@Doc_numero numeric(18,0)=0,	
	@Tra_TipoDoc varchar(3)='',	
	@Tra_DocSop varchar(3)='',	
	@Tra_NumSop numeric(18,0)=0,	
	@Tra_numlinea numeric(18,0)=0,	
	@Tra_Codigo varchar(20)='',	
	@Tra_docotro varchar(3)='',	
	@Tra_numotro numeric(18,0)=0,
	@Tra_fecha datetime =null,	
	@Tra_nombre varchar(120)='',	
	@Tra_cantidad numeric(22,8)=0,	
	@Tra_costuni numeric(22	,8)=0,
	@Tra_costtot numeric(22	,8)=0,
	@Tra_numprecio varchar(1)='',	
	@Tra_descdes varchar(40)='',	
	@Tra_porcendes numeric(19,4)=0,	
	@Tra_valordes numeric(19,4)=0,	
	@Tra_valor numeric(19,4)=0,	
	@Tra_extension varchar(15)='',	
	@Tra_sniva bit=0,	
	@Tra_Individual varchar(3)='',
	@Tra_quetipo varchar(1)='',	
	@Tra_precuni numeric(22,8)=0,	
	@Tra_prectot numeric(22,8)=0,	
	@Tra_DepDes varchar(50)='',	
	@Tra_Estado smallint=0,	
	@Tra_Oculto smallint=0,	
	@Tra_Inventario smallint=0,
	@Tra_Ventas smallint=0,	
	@Tra_Compras smallint=0,	
	@Tra_Activo smallint=0	,
	@Tra_Adicional1 numeric(19,4)=0,	
	@Tra_Adicional2 numeric(19,4)=0,	
	@Tra_piezas numeric(18,0)=0,	
	@Tra_medida varchar(5)='',	
	@Tra_multiplo numeric(22,8)=0,	
	@Tra_vence datetime =null,	
	@tra_Serie varchar(20)='',
	@IdClaveDoc numeric(18,0)=0,	
	@Tra_NroLote varchar(20)='',	
	@Tra_NroLoteDoc varchar(20)='',	
	@Periodo1 datetime=null,	
	@Periodo2 datetime =null,	
	@FacDesde datetime =null,	
	@FacHasta datetime =null	
 )
 AS
 BEGIN
 insert into AdcTra 
 (
	Doc_sucursal,
	Doc_Bodega,
	Opc_documento,
	Doc_numero,
	Tra_TipoDoc,
	Tra_DocSop,
	Tra_NumSop,
	Tra_numlinea,
	Tra_Codigo,
	Tra_docotro,
	Tra_numotro,
	Tra_fecha,
	Tra_nombre,
	Tra_cantidad,
	Tra_costuni,
	Tra_costtot,
	Tra_numprecio,
	Tra_descdes,
	Tra_porcendes,
	Tra_valordes,
	Tra_valor,
	Tra_extension,
	Tra_sniva,
	Tra_Individual,
	Tra_quetipo,
	Tra_precuni,
	Tra_prectot,
	Tra_DepDes,
	Tra_Estado,
	Tra_Oculto,
	Tra_Inventario,
	Tra_Ventas,
	Tra_Compras,
	Tra_Activo,
	Tra_Adicional1,
	Tra_Adicional2,
	Tra_piezas,
	Tra_medida,
	Tra_multiplo,
	Tra_vence,
	tra_Serie,
	IdClaveDoc,
	Tra_NroLote,
	Tra_NroLoteDoc,
	Periodo1,
	Periodo2,
	FacDesde,
	FacHasta
 )
 values
 (
	@Doc_sucursal,
	@Doc_Bodega,
	@Opc_documento,
	@Doc_numero,
	@Tra_TipoDoc,
	@Tra_DocSop,
	@Tra_NumSop,
	@Tra_numlinea,
	@Tra_Codigo,
	@Tra_docotro,
	@Tra_numotro,
	@Tra_fecha,
	@Tra_nombre,
	@Tra_cantidad,
	@Tra_costuni,
	@Tra_costtot,
	@Tra_numprecio,
	@Tra_descdes,
	@Tra_porcendes,
	@Tra_valordes,
	@Tra_valor,
	@Tra_extension,
	@Tra_sniva,
	@Tra_Individual,
	@Tra_quetipo,
	@Tra_precuni,
	@Tra_prectot,
	@Tra_DepDes,
	@Tra_Estado,
	@Tra_Oculto,
	@Tra_Inventario,
	@Tra_Ventas,
	@Tra_Compras,
	@Tra_Activo,
	@Tra_Adicional1,
	@Tra_Adicional2,
	@Tra_piezas,
	@Tra_medida,
	@Tra_multiplo,
	@Tra_vence,
	@tra_Serie,
	@IdClaveDoc,
	@Tra_NroLote,
	@Tra_NroLoteDoc,
	@Periodo1,
	@Periodo2,
	@FacDesde,
	@FacHasta )
 END
 
GO


if exists(select * from sys.objects where name ='ADCDOC_GENERAR_INV')
begin
DROP PROCEDURE [dbo].[ADCDOC_GENERAR_INV]
end
GO

 CREATE PROCEDURE [dbo].[ADCDOC_GENERAR_INV]
(@Doc_sucursal char(3)='',
@Doc_Bodega varchar(3)='',
@Opc_documento char(3)='',
@Doc_numero numeric(18,0)=0,
@Doc_docnombre varchar(40)='',
@Doc_TipoDoc varchar(3)='',
@Doc_DocSop varchar(3)='',
@Doc_NumSop numeric(18,0)='',
@Doc_fecha datetime=null,
@Doc_Hora datetime=null,
@Doc_extension varchar(15)='',
@Doc_codper varchar(15)='',
@Doc_codusu varchar(15)='',
@Doc_venabre varchar(15)='',
@Doc_porceniva numeric(19,4)=0,
@Doc_valoriva numeric(19,4)=0,
@Doc_totciva numeric(19,4)=0,
@Doc_totsiva numeric(19,4)=0,
@Doc_nombredes1 varchar(40)='',
@Doc_nombredes2 varchar(40)='',
@Doc_nombredes3 varchar(40)='',
@Doc_nombredes4 varchar(40)='',
@Doc_porcendes1 numeric(19,4)=0,
@Doc_porcendes2 numeric(19,4)=0,
@Doc_porcendes3 numeric(19,4)=0,
@Doc_porcendes4 numeric(19,4)=0,
@Doc_valordes1 numeric(19,4)=0,
@Doc_valordes2 numeric(19,4)=0,
@Doc_valordes3 numeric(19,4)=0,
@Doc_valordes4 numeric(19,4)=0,
@Doc_valor numeric(19,4)=0,
@Doc_valorabon numeric(19,4)=0,
@Doc_detalle varchar(512)='',
@Doc_NombreImp varchar(80)='',
@Doc_CiRuc varchar(20)='',
@Doc_Direccion varchar(80)='',
@Doc_Telefono1 varchar(15)='',
@Doc_Telefono2 varchar(15)='',
@Doc_DepDes varchar(50)='',
@Doc_TotDesArt numeric(19,4)=0,
@Doc_TotDesSer numeric(19,4)=0,
@Doc_TotArtCIva numeric(19,4)=0,
@Doc_TotArtSIva numeric(19,4)=0,
@Doc_TotSerCIva numeric(19,4)=0,
@Doc_TotSerSIva numeric(19,4)=0,
@Doc_TotAcf numeric(19,4)=0,
@Doc_Contado numeric(19,4)=0,
@Doc_FechaEfe datetime=null,
@Doc_Estado int=0,
@Doc_Oculto int=0,
@Doc_Contabilidad money=null,
@Doc_Banco money=null,
@Doc_Inventario smallint=0,
@Doc_Ventas smallint=0,
@Doc_Compras smallint=0,
@Doc_Activo smallint=0,
@Doc_Adicional1 numeric(19,4)=0,
@Doc_Adicional2 numeric(19,4)=0,
@Doc_NumeroExterno numeric(18,0)=0,
@Doc_NroIdDoc varchar(50)='',
@Doc_SaldoActualCli numeric(19,4)=0,
@Doc_SaldoFinalCli numeric(19,4)=0,
@Doc_FechaModifica datetime=null,
@Doc_CentroCosto varchar(20)='',
@IdClaveDoc numeric(18,0)=0,
@IdClaveDocSop numeric(18,0)=0,
@doc_SucursalDestino varchar(20)='',
@doc_SucDestino varchar(20)='',
@doc_BodDestino varchar(20)='',
@Doc_NroLoteDoc varchar(20)='',
@doc_BancoOrigen varchar(20)='',
@doc_BancoDestino varchar(20)='',
@doc_NumeroCheque varchar(20)='',
@doc_Aceptado bit=0,
@Doc_Liquidado bit=0,
@Doc_CobraCheque varchar(10)='',
@doc_TotDesCIva numeric(18,2)=0,
@doc_TotDesSiva numeric(18,2)=0,
@Periodo1 datetime=null,
@Periodo2 datetime=null,
@FacDesde datetime=null,
@FacHasta datetime=null,
@Habitacion varchar(15)='',
@Mesa varchar(15)='',
@TipoPeriodo varchar(20)='',
@Adi_NroAutSri varchar(20)='',
@Adi_SustTrib varchar(20)='',
@Adi_TipoDocSri varchar(20)='',
@Adi_SNDevIva char(1)='',
@Adi_FechContab datetime =null,
@Adi_CodigoNSR varchar(20)='',
@Dia_Status char(1)='',
@Moneda varchar(20)='',
@Paridad numeric(22,8)=0,
@ParidadBiMoneda numeric(22,8)=0,
@PaisDestino varchar(80)='',
@ProvinciaDestino varchar(80)='',
@CiudadDestino varchar(80)='',
@DireccionDestino varchar(80)='',
@Destinatario varchar(80)='',
@RucDestinatario varchar(80)='',
@ContactoDestino varchar(80)='',
@FecIniTransporte datetime =null,
@FecFinTransporte datetime = null,
@Transportista varchar(80)='',
@RucTransportista varchar(15)='',
@TipoTransporte varchar(20)='',
@EsContable varchar(1)='',
@AuxVar1 varchar(128)='',
@AuxVar2 varchar(128)='',
@AuxVar3 varchar(128)='',
@AuxVar4 varchar(128)='',
@AuxVar5 varchar(128)='',
@AuxVar6 varchar(128)='',
@AuxVar7 varchar(128)='',
@AuxVar8 varchar(128)='',
@AuxVar9 varchar(128)='',
@AuxVar10 varchar(128)='',
@AuxVar11 varchar(128)='',
@AuxVar12 varchar(128)='',
@AuxFec1 datetime= null,
@AuxFec2 datetime= null,
@AuxFec3 datetime= null,
@AuxLog1 varchar(1)='',
@AuxLog2 varchar(1)='',
@AuxLog3 varchar(1)='',
@AuxNum1 numeric(22,8)=0,
@AuxNum2 numeric(22,8)=0,
@AuxNum3 numeric(22,8)=0,
@AuxNum4 numeric(22,8)=0,
@AuxNum5 numeric(22,8)=0,
@AuxNum6 numeric(22,8)=0,
@AuxNum7 numeric(22,8)=0,
@AuxNum8 numeric(22,8)=0,
@AuxNum9 numeric(22,8)=0,
@AuxNum10 numeric(22,8)=0,
@AuxNum11 numeric(22,8)=0,
@AuxNum12 numeric(22,8)=0,
@doc_Anticipo bit=0,
@Consolidar bit=0,
@TipDocConsolida varchar(10)='',
@NroDocConsolida numeric(18,0)=0,
@Contabilizar bit=0,
@ProductoProduccion varchar(50)='',
@Mesero varchar(125)='',
@BaseImp1 numeric(22,4)=0,
@BaseImp2 numeric(22,4)=0,
@BaseImp3 numeric(22,4)=0,
@PorcImp1 numeric(22,4)=0,
@PorcImp2 numeric(22,4)=0,
@PorcImp3 numeric(22,4)=0,
@ValorImp1 numeric(22,4)=0,
@ValorImp2 numeric(22,4)=0,
@ValorImp3 numeric(22,4)=0,
@Ocupantes numeric(5,0)=0)
AS
BEGIN 
insert into AdcDoc 
		(Doc_sucursal,
		Doc_Bodega,
		Opc_documento,
		Doc_numero,
		Doc_docnombre,
		Doc_TipoDoc,
		Doc_DocSop,
		Doc_NumSop,
		Doc_fecha,
		Doc_Hora,
		Doc_extension,
		Doc_codper,
		Doc_codusu,
		Doc_venabre,
		Doc_porceniva,
		Doc_valoriva,
		Doc_totciva,
		Doc_totsiva,
		Doc_nombredes1,
		Doc_nombredes2,
		Doc_nombredes3,
		Doc_nombredes4,
		Doc_porcendes1,
		Doc_porcendes2,
		Doc_porcendes3,
		Doc_porcendes4,
		Doc_valordes1,
		Doc_valordes2,
		Doc_valordes3,
		Doc_valordes4,
		Doc_valor,
		Doc_valorabon,
		Doc_detalle,
		Doc_NombreImp,
		Doc_CiRuc,
		Doc_Direccion,
		Doc_Telefono1,
		Doc_Telefono2,
		Doc_DepDes,
		Doc_TotDesArt,
		Doc_TotDesSer,
		Doc_TotArtCIva,
		Doc_TotArtSIva,
		Doc_TotSerCIva,
		Doc_TotSerSIva,
		Doc_TotAcf,
		Doc_Contado,
		Doc_FechaEfe,
		Doc_Estado,
		Doc_Oculto,
		Doc_Contabilidad,
		Doc_Banco,
		Doc_Inventario,
		Doc_Ventas,
		Doc_Compras,
		Doc_Activo,
		Doc_Adicional1,
		Doc_Adicional2,
		Doc_NumeroExterno,
		Doc_NroIdDoc,
		Doc_SaldoActualCli,
		Doc_SaldoFinalCli,
		Doc_FechaModifica,
		Doc_CentroCosto,
		IdClaveDoc,
		IdClaveDocSop,
		doc_SucursalDestino,
		doc_SucDestino,
		doc_BodDestino,
		Doc_NroLoteDoc,
		doc_BancoOrigen,
		doc_BancoDestino,
		doc_NumeroCheque,
		doc_Aceptado,
		Doc_Liquidado,
		Doc_CobraCheque,
		doc_TotDesCIva,
		doc_TotDesSiva,
		Periodo1,
		Periodo2,
		FacDesde,
		FacHasta,
		Habitacion,
		Mesa,
		TipoPeriodo,
		Adi_NroAutSri,
		Adi_SustTrib,
		Adi_TipoDocSri,
		Adi_SNDevIva,
		Adi_FechContab,
		Adi_CodigoNSR,
		Dia_Status,
		Moneda,
		Paridad,
		ParidadBiMoneda,
		PaisDestino,
		ProvinciaDestino,
		CiudadDestino,
		DireccionDestino,
		Destinatario,
		RucDestinatario,
		ContactoDestino,
		FecIniTransporte,
		FecFinTransporte,
		Transportista,
		RucTransportista,
		TipoTransporte,
		EsContable,
		AuxVar1,
		AuxVar2,
		AuxVar3,
		AuxVar4,
		AuxVar5,
		AuxVar6,
		AuxVar7,
		AuxVar8,
		AuxVar9,
		AuxVar10,
		AuxVar11,
		AuxVar12,
		AuxFec1,
		AuxFec2,
		AuxFec3,
		AuxLog1,
		AuxLog2,
		AuxLog3,
		AuxNum1,
		AuxNum2,
		AuxNum3,
		AuxNum4,
		AuxNum5,
		AuxNum6,
		AuxNum7,
		AuxNum8,
		AuxNum9,
		AuxNum10,
		AuxNum11,
		AuxNum12,
		doc_Anticipo,
		Consolidar,
		TipDocConsolida,
		NroDocConsolida,
		Contabilizar,
		ProductoProduccion,
		Mesero)
		values
		(@Doc_sucursal,
		@Doc_Bodega,
		@Opc_documento,
		@Doc_numero,
		@Doc_docnombre,
		@Doc_TipoDoc,
		@Doc_DocSop,
		@Doc_NumSop,
		@Doc_fecha,
		@Doc_Hora,
		@Doc_extension,
		@Doc_codper,
		@Doc_codusu,
		@Doc_venabre,
		@Doc_porceniva,
		@Doc_valoriva,
		@Doc_totciva,
		@Doc_totsiva,
		@Doc_nombredes1,
		@Doc_nombredes2,
		@Doc_nombredes3,
		@Doc_nombredes4,
		@Doc_porcendes1,
		@Doc_porcendes2,
		@Doc_porcendes3,
		@Doc_porcendes4,
		@Doc_valordes1,
		@Doc_valordes2,
		@Doc_valordes3,
		@Doc_valordes4,
		@Doc_valor,
		@Doc_valorabon,
		@Doc_detalle,
		@Doc_NombreImp,
		@Doc_CiRuc,
		@Doc_Direccion,
		@Doc_Telefono1,
		@Doc_Telefono2,
		@Doc_DepDes,
		@Doc_TotDesArt,
		@Doc_TotDesSer,
		@Doc_TotArtCIva,
		@Doc_TotArtSIva,
		@Doc_TotSerCIva,
		@Doc_TotSerSIva,
		@Doc_TotAcf,
		@Doc_Contado,
		@Doc_FechaEfe,
		@Doc_Estado,
		@Doc_Oculto,
		@Doc_Contabilidad,
		@Doc_Banco,
		@Doc_Inventario,
		@Doc_Ventas,
		@Doc_Compras,
		@Doc_Activo,
		@Doc_Adicional1,
		@Doc_Adicional2,
		@Doc_NumeroExterno,
		@Doc_NroIdDoc,
		@Doc_SaldoActualCli,
		@Doc_SaldoFinalCli,
		@Doc_FechaModifica,
		@Doc_CentroCosto,
		@IdClaveDoc,
		@IdClaveDocSop,
		@doc_SucursalDestino,
		@doc_SucDestino,
		@doc_BodDestino,
		@Doc_NroLoteDoc,
		@doc_BancoOrigen,
		@doc_BancoDestino,
		@doc_NumeroCheque,
		@doc_Aceptado,
		@Doc_Liquidado,
		@Doc_CobraCheque,
		@doc_TotDesCIva,
		@doc_TotDesSiva,
		@Periodo1,
		@Periodo2,
		@FacDesde,
		@FacHasta,
		@Habitacion,
		@Mesa,
		@TipoPeriodo,
		@Adi_NroAutSri,
		@Adi_SustTrib,
		@Adi_TipoDocSri,
		@Adi_SNDevIva,
		@Adi_FechContab,
		@Adi_CodigoNSR,
		@Dia_Status,
		@Moneda,
		@Paridad,
		@ParidadBiMoneda,
		@PaisDestino,
		@ProvinciaDestino,
		@CiudadDestino,
		@DireccionDestino,
		@Destinatario,
		@RucDestinatario,
		@ContactoDestino,
		@FecIniTransporte,
		@FecFinTransporte,
		@Transportista,
		@RucTransportista,
		@TipoTransporte,
		@EsContable,
		@AuxVar1,
		@AuxVar2,
		@AuxVar3,
		@AuxVar4,
		@AuxVar5,
		@AuxVar6,
		@AuxVar7,
		@AuxVar8,
		@AuxVar9,
		@AuxVar10,
		@AuxVar11,
		@AuxVar12,
		@AuxFec1,
		@AuxFec2,
		@AuxFec3,
		@AuxLog1,
		@AuxLog2,
		@AuxLog3,
		@AuxNum1,
		@AuxNum2,
		@AuxNum3,
		@AuxNum4,
		@AuxNum5,
		@AuxNum6,
		@AuxNum7,
		@AuxNum8,
		@AuxNum9,
		@AuxNum10,
		@AuxNum11,
		@AuxNum12,
		@doc_Anticipo,
		@Consolidar,
		@TipDocConsolida,
		@NroDocConsolida,
		@Contabilizar,
		@ProductoProduccion,
		@Mesero)
END
GO

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
GO


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
GO

if exists(select * from sys.objects where name ='ADC_BALANCE_RESUL')
begin
DROP PROCEDURE [dbo].[ADC_BALANCE_RESUL]
end
GO

CREATE PROCEDURE [dbo].[ADC_BALANCE_RESUL]
 (
   @fecha datetime=NULL,
   @fecha1 datetime=null,
   @fechaAnt datetime=NULL,
   @fechaAnt1 datetime=null,
   @nivel int=1
   )
AS
BEGIN
select est.codigo ,est.Nombre , nota.Nota_Codigo as Nota,est.Año , cast(est.Año1 as numeric(18,2)) as Año1, cast((Año -Año1) as numeric(18,2)) as Diferencia
	,case when Año<=0 then 100 else cast(((Año1-Año)/Año *100) as numeric(18,2))end as Porcentaje
from
(
select SUBSTRING(max(vta.Cta_codigo) ,0,1) AS codigo,'INGRESOS POR VENTAS NETAS' as Nombre,SUM(vtaAnt.Valor) as Año, sum(vta.Valor) as Año1
from AdcCta
left Join
(
select AdcDia.Cta_codigo,sum(adcdia.dia_valor * adcdia.Dia_signo) as Valor
from AdcDia
where AdcDia.Dia_fecha >= @fecha and AdcDia.Dia_fecha<= @fecha1 
group by AdcDia.Cta_codigo 
) vta on (AdcCta.Cta_codigo = vta.Cta_codigo )
left Join
(
select AdcDia.Cta_codigo,sum(adcdia.dia_valor * adcdia.Dia_signo) as Valor
from AdcDia
where AdcDia.Dia_fecha >= @fechaAnt and AdcDia.Dia_fecha<= @fechaAnt1 
group by AdcDia.Cta_codigo 
) vtaAnt on (AdcCta.Cta_codigo = vtaAnt.Cta_codigo )
where AdcCta.res_vta=1

union all

select SUBSTRING(max(vta.Cta_codigo) ,0,1),'COSTO DE PRODUCTOS VENDIDOS' as Nombre,SUM(vtaAnt.Valor) as Año, sum(vta.Valor) as Año1
from AdcCta
left Join
(
select AdcDia.Cta_codigo,sum(adcdia.dia_valor * adcdia.Dia_signo) as Valor
from AdcDia
where AdcDia.Dia_fecha >= @fecha and AdcDia.Dia_fecha<= @fecha1 
group by AdcDia.Cta_codigo 
) vta on (AdcCta.Cta_codigo = vta.Cta_codigo )
left Join
(
select AdcDia.Cta_codigo,sum(adcdia.dia_valor * adcdia.Dia_signo) as Valor
from AdcDia
where AdcDia.Dia_fecha >= @fechaAnt and AdcDia.Dia_fecha<= @fechaAnt1 
group by AdcDia.Cta_codigo 
) vtaAnt on (AdcCta.Cta_codigo = vtaAnt.Cta_codigo )
where AdcCta.res_cos=1

union all

select null as Codigo,'GANANCIA BRUTA' as Nombre,SUM(vtaAnt.Valor) as Año, sum(vta.Valor) as Año1
from AdcCta
left Join
(
select AdcDia.Cta_codigo,sum(adcdia.dia_valor * adcdia.Dia_signo) as Valor
from AdcDia
where AdcDia.Dia_fecha >= @fecha and AdcDia.Dia_fecha<= @fecha1 
group by AdcDia.Cta_codigo 
) vta on (AdcCta.Cta_codigo = vta.Cta_codigo )
left Join
(
select AdcDia.Cta_codigo,sum(adcdia.dia_valor * adcdia.Dia_signo) as Valor
from AdcDia
where AdcDia.Dia_fecha >= @fechaAnt and AdcDia.Dia_fecha<= @fechaAnt1 
group by AdcDia.Cta_codigo 
) vtaAnt on (AdcCta.Cta_codigo = vtaAnt.Cta_codigo )
where AdcCta.res_cos=1 or AdcCta.res_vta=1

union all

select SUBSTRING(max(vta.Cta_codigo) ,0,1),'GASTOS DE COMERCIALIZACIÓN Y ADMINISTRACIÓN' as Nombre, SUM(vtaAnt.Valor ) as Año, sum(vta.Valor) as Año1
from AdcCta
left Join
(
select AdcDia.Cta_codigo,sum(adcdia.dia_valor * adcdia.Dia_signo) as Valor
from AdcDia
where AdcDia.Dia_fecha >= @fecha and AdcDia.Dia_fecha<= @fecha1 
group by AdcDia.Cta_codigo 
) vta on (AdcCta.Cta_codigo = vta.Cta_codigo )
left Join
(
select AdcDia.Cta_codigo,sum(adcdia.dia_valor * adcdia.Dia_signo) as Valor
from AdcDia
where AdcDia.Dia_fecha >= @fechaAnt and AdcDia.Dia_fecha<= @fechaAnt1 
group by AdcDia.Cta_codigo 
) vtaAnt on (AdcCta.Cta_codigo = vtaAnt.Cta_codigo )
where AdcCta.res_gas=1

union all

select vta.Cta_codigo ,vta.Dia_ctanombre as Nombre,vtaAnt.Valor  as Año, vta.Valor as Año1
from AdcCta
left Join
( 
select AdcDia.Cta_codigo,AdcDia.Dia_ctanombre ,sum(adcdia.dia_valor * adcdia.Dia_signo) as Valor
from AdcDia
where AdcDia.Dia_fecha >= @fecha and AdcDia.Dia_fecha<= @fecha1  
group by AdcDia.Cta_codigo , AdcDia.Dia_ctanombre
) vta on (AdcCta.Cta_codigo = vta.Cta_codigo and adccta.cta_nivel >= @nivel )
left Join
( 
select AdcDia.Cta_codigo,AdcDia.Dia_ctanombre ,sum(adcdia.dia_valor * adcdia.Dia_signo) as Valor
from AdcDia
where AdcDia.Dia_fecha >= @fechaAnt and AdcDia.Dia_fecha<= @fechaAnt1  
group by AdcDia.Cta_codigo , AdcDia.Dia_ctanombre
) vtaAnt on (AdcCta.Cta_codigo = vtaAnt.Cta_codigo and adccta.cta_nivel >= @nivel )
where AdcCta.res_gas=1 and isnull(vta.Dia_ctanombre,'') <> ''

union all

select null as Codigo,'RESULTADO OPERATIVO' as Nombre,sum(vtaAnt.Valor) as Año, sum(vta.Valor) as Año1
from AdcCta
left Join
(
select AdcDia.Cta_codigo,sum(adcdia.dia_valor * adcdia.Dia_signo) as Valor
from AdcDia
where AdcDia.Dia_fecha >= @fecha and AdcDia.Dia_fecha<= @fecha1 
group by AdcDia.Cta_codigo 
) vta on (AdcCta.Cta_codigo = vta.Cta_codigo )
left Join
(
select AdcDia.Cta_codigo,sum(adcdia.dia_valor * adcdia.Dia_signo) as Valor
from AdcDia
where AdcDia.Dia_fecha >= @fechaAnt and AdcDia.Dia_fecha<= @fechaAnt1 
group by AdcDia.Cta_codigo 
) vtaAnt on (AdcCta.Cta_codigo = vtaAnt.Cta_codigo )
where AdcCta.res_cos=1 or AdcCta.res_vta=1 or AdcCta.res_gas=1

union all

select SUBSTRING(max(vta.Cta_codigo) ,0,1),'MOVIMIENTOS FINANCIEROS' as Nombre,sum(vtaAnt.Valor) as Año, sum(vta.Valor) as Año1
from AdcCta
left Join
(
select AdcDia.Cta_codigo,sum(adcdia.dia_valor * adcdia.Dia_signo) as Valor
from AdcDia
where AdcDia.Dia_fecha >= @fecha and AdcDia.Dia_fecha<= @fecha1 
group by AdcDia.Cta_codigo 
) vta on (AdcCta.Cta_codigo = vta.Cta_codigo )
left Join
(
select AdcDia.Cta_codigo,sum(adcdia.dia_valor * adcdia.Dia_signo) as Valor
from AdcDia
where AdcDia.Dia_fecha >= @fechaAnt and AdcDia.Dia_fecha<= @fechaAnt1 
group by AdcDia.Cta_codigo 
) vtaAnt on (AdcCta.Cta_codigo = vtaAnt.Cta_codigo )
where AdcCta.res_movFin=1 

union all

select vta.Cta_codigo ,vta.Dia_ctanombre as Nombre,vta.Valor as Año, vta.Valor as Año1
from AdcCta
left Join
( 
select AdcDia.Cta_codigo,AdcDia.Dia_ctanombre ,sum(adcdia.dia_valor * adcdia.Dia_signo) as Valor
from AdcDia
where AdcDia.Dia_fecha >= @fecha and AdcDia.Dia_fecha<= @fecha1  
group by AdcDia.Cta_codigo , AdcDia.Dia_ctanombre
) vta on (AdcCta.Cta_codigo = vta.Cta_codigo and adccta.cta_nivel >= @nivel )
left Join
( 
select AdcDia.Cta_codigo,AdcDia.Dia_ctanombre ,sum(adcdia.dia_valor * adcdia.Dia_signo) as Valor
from AdcDia
where AdcDia.Dia_fecha >= @fechaAnt and AdcDia.Dia_fecha<= @fechaAnt1  
group by AdcDia.Cta_codigo , AdcDia.Dia_ctanombre
) vtaAnt on (AdcCta.Cta_codigo = vtaAnt.Cta_codigo and adccta.cta_nivel >= @nivel )
where AdcCta.res_movFin=1 and isnull(vta.Dia_ctanombre,'') <> ''

union all

select null as codigo,'RESULTADO ANTES DEL IMPUESTO' as Nombre,SUM(vtaAnt.Valor ) as Año, sum(vta.Valor) as Año
from AdcCta
left Join
(
select AdcDia.Cta_codigo,sum(adcdia.dia_valor * adcdia.Dia_signo) as Valor
from AdcDia
where AdcDia.Dia_fecha >= @fecha and AdcDia.Dia_fecha<= @fecha1 
group by AdcDia.Cta_codigo 
) vta on (AdcCta.Cta_codigo = vta.Cta_codigo )
left Join
(
select AdcDia.Cta_codigo,sum(adcdia.dia_valor * adcdia.Dia_signo) as Valor
from AdcDia
where AdcDia.Dia_fecha >= @fechaAnt and AdcDia.Dia_fecha<= @fechaAnt1 
group by AdcDia.Cta_codigo 
) vtaAnt on (AdcCta.Cta_codigo = vtaAnt.Cta_codigo )
where AdcCta.res_cos=1 or AdcCta.res_vta=1 or AdcCta.res_gas=1 or AdcCta.res_movFin=1

union all

select SUBSTRING(max(vta.Cta_codigo) ,0,1),'IMPUESTO A LAS GANANCIAS' as Nombre,SUM(vtaAnt.Valor ) as Año, sum(vta.Valor) as Año
from AdcCta
left Join
(
select AdcDia.Cta_codigo,sum(adcdia.dia_valor * adcdia.Dia_signo) as Valor
from AdcDia
where AdcDia.Dia_fecha >= @fecha and AdcDia.Dia_fecha<= @fecha1 
group by AdcDia.Cta_codigo 
) vta on (AdcCta.Cta_codigo = vta.Cta_codigo )
left Join
(
select AdcDia.Cta_codigo,sum(adcdia.dia_valor * adcdia.Dia_signo) as Valor
from AdcDia
where AdcDia.Dia_fecha >= @fechaAnt and AdcDia.Dia_fecha<= @fechaAnt1 
group by AdcDia.Cta_codigo 
) vtaAnt on (AdcCta.Cta_codigo = vtaAnt.Cta_codigo )
where AdcCta.res_imp=1

union all

select null as Codigo,'RESULTADO DEL EJERCICIO' as Nombre,SUM(vtaAnt.Valor) as Año, sum(vta.Valor) as Año
from AdcCta
left Join
(
select AdcDia.Cta_codigo,sum(adcdia.dia_valor * adcdia.Dia_signo) as Valor
from AdcDia
where AdcDia.Dia_fecha >= @fecha and AdcDia.Dia_fecha<= @fecha1 
group by AdcDia.Cta_codigo 
) vta on (AdcCta.Cta_codigo = vta.Cta_codigo )
left Join
(
select AdcDia.Cta_codigo,sum(adcdia.dia_valor * adcdia.Dia_signo) as Valor
from AdcDia
where AdcDia.Dia_fecha >= @fechaAnt and AdcDia.Dia_fecha<= @fechaAnt1 
group by AdcDia.Cta_codigo 
) vtaAnt on (AdcCta.Cta_codigo = vta.Cta_codigo )
where AdcCta.res_cos=1 or AdcCta.res_vta=1 or AdcCta.res_gas=1 or AdcCta.res_movFin=1 or AdcCta.res_imp=1) est 
left join
(
	select *
	from AdcNote 
	) nota
	on substring(nota.Nota_Mes,1,2) >= MONTH(@fecha)and substring(nota.Nota_Mes,4,2) >= MONTH(@fecha1) and nota.Nota_Año =YEAR(@fecha ) and nota.Nota_Origen ='BAL_RES'
	
END
GO
