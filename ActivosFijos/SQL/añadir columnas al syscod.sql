if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='syscod' and col.name='Tipo1')
begin
Alter table syscod add Tipo1 varchar(50) null
end
go

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='syscod' and col.name='Tipo2')
begin
Alter table syscod add Tipo2 varchar(50) null
end
go
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='syscod' and col.name='Tipo3')
begin
Alter table syscod add Tipo3 varchar(50) null
end
go
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='syscod' and col.name='Tipo4')
begin
Alter table syscod add Tipo4 varchar(50) null
end
go
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='syscod' and col.name='Tipo5')
begin
Alter table syscod add Tipo5 varchar(50) null
end
go

---------------------------------------------------------------------

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='syscod' and col.name='longitud1')
begin
Alter table syscod add longitud1 int null
end
go

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='syscod' and col.name='longitud2')
begin
Alter table syscod add longitud2 int null
end
go
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='syscod' and col.name='longitud3')
begin
Alter table syscod add longitud3 int null
end
go
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='syscod' and col.name='longitud4')
begin
Alter table syscod add longitud4 int null
end
go
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='syscod' and col.name='longitud5')
begin
Alter table syscod add longitud5 int null
end
go
---------------------------------------------------------------------
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='syscod' and col.name='decimales1')
begin
Alter table syscod add decimales1 int null
end
go

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='syscod' and col.name='decimales2')
begin
Alter table syscod add decimales2 int null
end
go

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='syscod' and col.name='decimales3')
begin
Alter table syscod add decimales3 int null
end
go

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='syscod' and col.name='decimales4')
begin
Alter table syscod add decimales4 int null
end
go

if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='syscod' and col.name='decimales5')
begin
Alter table syscod add decimales5 int null
end
go

---------------------------------------------------------------------