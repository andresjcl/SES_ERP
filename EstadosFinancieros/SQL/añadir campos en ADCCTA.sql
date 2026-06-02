if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCta' and col.name='Res_Vta')
begin
Alter table AdcCta add Res_Vta bit null
end

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCta' and col.name='Res_Cos')
begin
Alter table AdcCta add Res_Cos bit null
end

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCta' and col.name='Res_Gas')
begin
Alter table AdcCta add Res_Gas bit null
end

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCta' and col.name='Res_MovFin')
begin
Alter table AdcCta add Res_MovFin bit null
end

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCta' and col.name='Res_Imp')
begin
Alter table AdcCta add Res_Imp bit null
end
---------------------------------------------------------------------
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCtaMovMov' and col.name='ene_sal')
begin
Alter table AdcCtaMov add ene_sal  numeric(22,8) null
end

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCtaMov' and col.name='ene_deb')
begin
Alter table AdcCtaMov add ene_deb  numeric(22,8) null
end

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCtaMov' and col.name='ene_cre')
begin
Alter table AdcCtaMov add ene_cre  numeric(22,8) null
end

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCtaMov' and col.name='feb_sal')
begin
Alter table AdcCtaMov add feb_sal  numeric(22,8) null
end

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCtaMov' and col.name='feb_deb')
begin
Alter table AdcCtaMov add feb_deb  numeric(22,8) null
end

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCtaMov' and col.name='feb_cre')
begin
Alter table AdcCtaMov add feb_cre  numeric(22,8) null
end

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCtaMov' and col.name='mar_sal')
begin
Alter table AdcCtaMov add mar_sal  numeric(22,8) null
end

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCtaMov' and col.name='mar_deb')
begin
Alter table AdcCtaMov add mar_deb  numeric(22,8) null
end

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCtaMov' and col.name='mar_cre')
begin
Alter table AdcCtaMov add mar_cre  numeric(22,8) null
end

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCtaMov' and col.name='abr_sal')
begin
Alter table AdcCtaMov add abr_sal  numeric(22,8) null
end

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCtaMov' and col.name='abr_deb')
begin
Alter table AdcCtaMov add abr_deb  numeric(22,8) null
end

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCtaMov' and col.name='abr_cre')
begin
Alter table AdcCtaMov add abr_cre  numeric(22,8) null
end

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCtaMov' and col.name='may_sal')
begin
Alter table AdcCtaMov add may_sal  numeric(22,8) null
end

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCtaMov' and col.name='may_deb')
begin
Alter table AdcCtaMov add may_deb  numeric(22,8) null
end

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCtaMov' and col.name='may_cre')
begin
Alter table AdcCtaMov add may_cre  numeric(22,8) null
end

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCtaMov' and col.name='jun_sal')
begin
Alter table AdcCtaMov add jun_sal  numeric(22,8) null
end

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCtaMov' and col.name='jun_deb')
begin
Alter table AdcCtaMov add jun_deb  numeric(22,8) null
end

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCtaMov' and col.name='jun_cre')
begin
Alter table AdcCtaMov add jun_cre  numeric(22,8) null
end

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCtaMov' and col.name='jul_sal')
begin
Alter table AdcCtaMov add jul_sal  numeric(22,8) null
end

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCtaMov' and col.name='jul_deb')
begin
Alter table AdcCtaMov add jul_deb  numeric(22,8) null
end

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCtaMov' and col.name='jul_cre')
begin
Alter table AdcCtaMov add jul_cre  numeric(22,8) null
end

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCtaMov' and col.name='ags_sal')
begin
Alter table AdcCtaMov add ags_sal  numeric(22,8) null
end

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCtaMov' and col.name='ags_deb')
begin
Alter table AdcCtaMov add ags_deb  numeric(22,8) null
end

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCtaMov' and col.name='ags_cre')
begin
Alter table AdcCtaMov add ags_cre  numeric(22,8) null
end

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCtaMov' and col.name='sep_sal')
begin
Alter table AdcCtaMov add sep_sal  numeric(22,8) null
end

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCtaMov' and col.name='sep_deb')
begin
Alter table AdcCtaMov add sep_deb  numeric(22,8) null
end

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCtaMov' and col.name='sep_cre')
begin
Alter table AdcCtaMov add sep_cre  numeric(22,8) null
end

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCtaMov' and col.name='oct_sal')
begin
Alter table AdcCtaMov add oct_sal  numeric(22,8) null
end

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCtaMov' and col.name='oct_deb')
begin
Alter table AdcCtaMov add oct_deb  numeric(22,8) null
end

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCtaMov' and col.name='oct_cre')
begin
Alter table AdcCtaMov add oct_cre  numeric(22,8) null
end

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCtaMov' and col.name='nov_sal')
begin
Alter table AdcCtaMov add nov_sal  numeric(22,8) null
end

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCtaMov' and col.name='nov_deb')
begin
Alter table AdcCtaMov add nov_deb  numeric(22,8) null
end

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCtaMov' and col.name='nov_cre')
begin
Alter table AdcCtaMov add nov_cre  numeric(22,8) null
end

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCtaMov' and col.name='dic_sal')
begin
Alter table AdcCtaMov add dic_sal  numeric(22,8) null
end

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCtaMov' and col.name='dic_deb')
begin
Alter table AdcCtaMov add dic_deb  numeric(22,8) null
end

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcCtaMov' and col.name='dic_cre')
begin
Alter table AdcCtaMov add dic_cre  numeric(22,8) null
end