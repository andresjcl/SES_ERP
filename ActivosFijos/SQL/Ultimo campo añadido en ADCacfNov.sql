if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcAcfNov' and col.name='FechaProduccion')
begin
Alter table AdcAcfNov add FechaProduccion datetime null
end