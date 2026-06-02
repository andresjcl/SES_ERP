
------------------------ CONTABILIZACION FINANCIERA

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcAcf' and col.name='CtaDebeRevalorizaF')
begin
Alter table AdcAcf add CtaDebeRevalorizaF nvarchar(50) null
end

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcAcf' and col.name='CtaDebeDeterioroF')
begin
Alter table AdcAcf add CtaDebeDeterioroF nvarchar(50) null
end

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcAcf' and col.name='CtaDebeDepreciacionF')
begin
Alter table AdcAcf add CtaDebeDepreciacionF nvarchar(50) null
end

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcAcf' and col.name='CtaDebeDiferenciaDepF')
begin
Alter table AdcAcf add CtaDebeDiferenciaDepF nvarchar(50) null
end

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcAcf' and col.name='CtaDebeAux1F')
begin
Alter table AdcAcf add CtaDebeAux1F nvarchar(50) null
end

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcAcf' and col.name='CtaHaberRevalorizaF')
begin
Alter table AdcAcf add CtaHaberRevalorizaF nvarchar(50) null
end

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcAcf' and col.name='CtaHaberDeterioroF')
begin
Alter table AdcAcf add CtaHaberDeterioroF nvarchar(50) null
end

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcAcf' and col.name='CtaHaberDepreciacionF')
begin
Alter table AdcAcf add CtaHaberDepreciacionF nvarchar(50) null
end

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcAcf' and col.name='CtaHaberDiferenciaDepF')
begin
Alter table AdcAcf add CtaHaberDiferenciaDepF nvarchar(50) null
end

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcAcf' and col.name='CtaHaberAux1F')
begin
Alter table AdcAcf add CtaHaberAux1F nvarchar(50) null
end

------------------------ CONTABILIZACION TRIBUTARIA

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcAcf' and col.name='CtaDebeDepreciacionT')
begin
Alter table AdcAcf add CtaDebeDepreciacionT nvarchar(50) null
end

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcAcf' and col.name='CtaHaberDepreciacionT')
begin
Alter table AdcAcf add CtaHaberDepreciacionT nvarchar(50) null
end

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcAcf' and col.name='CtaDebeAux1T')
begin
Alter table AdcAcf add CtaDebeAux1T nvarchar(50) null
end

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcAcf' and col.name='CtaDebeAux2T')
begin
Alter table AdcAcf add CtaDebeAux2T nvarchar(50) null
end

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcAcf' and col.name='CtaDebeAux3T')
begin
Alter table AdcAcf add CtaDebeAux3T nvarchar(50) null
end

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcAcf' and col.name='CtaDebeAux4T')
begin
Alter table AdcAcf add CtaDebeAux4T nvarchar(50) null
end

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcAcf' and col.name='CtaHaberAux1T')
begin
Alter table AdcAcf add CtaHaberAux1T nvarchar(50) null
end

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcAcf' and col.name='CtaHaberAux2T')
begin
Alter table AdcAcf add CtaHaberAux2T nvarchar(50) null
end

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcAcf' and col.name='CtaHaberAux3T')
begin
Alter table AdcAcf add CtaHaberAux3T nvarchar(50) null
end

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcAcf' and col.name='CtaHaberAux4T')
begin
Alter table AdcAcf add CtaHaberAux4T nvarchar(50) null
end