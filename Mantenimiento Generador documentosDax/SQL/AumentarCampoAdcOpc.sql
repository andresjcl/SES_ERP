if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcOpc' and col.name='Opc_LimiteCuadre')
begin
Alter table Adcopc add Opc_LimiteCuadre numeric(18,4) null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcOpc' and col.name='AutorizarPago')
begin
Alter table Adcopc add AutorizarPago bit null
end


