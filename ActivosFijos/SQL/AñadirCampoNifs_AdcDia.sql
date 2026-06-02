if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcDia' and col.name='Nifs')
begin
Alter table AdcDia add Nifs bit null
end