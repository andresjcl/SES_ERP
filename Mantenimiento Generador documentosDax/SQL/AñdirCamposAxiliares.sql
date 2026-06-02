
-- AÑADIR CAMPOS AUXILIARES A AdcDoc
-- STRING
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcDoc' and col.name='AuxVar1')
begin
Alter table AdcDoc add AuxVar1 nvarchar(128) null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcDoc' and col.name='AuxVar2')
begin
Alter table AdcDoc add AuxVar2 nvarchar(128) null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcDoc' and col.name='AuxVar3')
begin
Alter table AdcDoc add AuxVar3 nvarchar(128) null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcDoc' and col.name='AuxVar4')
begin
Alter table AdcDoc add AuxVar4 nvarchar(128) null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcDoc' and col.name='AuxVar5')
begin
Alter table AdcDoc add AuxVar5 nvarchar(128) null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcDoc' and col.name='AuxVar6')
begin
Alter table AdcDoc add AuxVar6 nvarchar(128) null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcDoc' and col.name='AuxVar7')
begin
Alter table AdcDoc add AuxVar7 nvarchar(128) null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcDoc' and col.name='AuxVar8')
begin
Alter table AdcDoc add AuxVar8 nvarchar(128) null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcDoc' and col.name='AuxVar9')
begin
Alter table AdcDoc add AuxVar9 nvarchar(128) null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcDoc' and col.name='AuxVar10')
begin
Alter table AdcDoc add AuxVar10 nvarchar(128) null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcDoc' and col.name='AuxVar11')
begin
Alter table AdcDoc add AuxVar11 nvarchar(128) null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcDoc' and col.name='AuxVar12')
begin
Alter table AdcDoc add AuxVar12 nvarchar(128) null
end

-- FECHA
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcDoc' and col.name='AuxFec1')
begin
Alter table AdcDoc add AuxFec1 datetime null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcDoc' and col.name='AuxFec2')
begin
Alter table AdcDoc add AuxFec2 datetime null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcDoc' and col.name='AuxFec3')
begin
Alter table AdcDoc add AuxFec3 datetime null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcDoc' and col.name='AuxFec4')
begin
Alter table AdcDoc add AuxFec4 datetime null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcDoc' and col.name='AuxFec5')
begin
Alter table AdcDoc add AuxFec5 datetime null
end

--LOGICOS
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcDoc' and col.name='AuxLog1')
begin
Alter table AdcDoc add AuxLog1 nvarchar(1) null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcDoc' and col.name='AuxLog2')
begin
Alter table AdcDoc add AuxLog2 nvarchar(1) null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcDoc' and col.name='AuxLog3')
begin
Alter table AdcDoc add AuxLog3 nvarchar(1) null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcDoc' and col.name='AuxLog4')
begin
Alter table AdcDoc add AuxLog4 nvarchar(1) null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcDoc' and col.name='AuxLog5')
begin
Alter table AdcDoc add AuxLog5 nvarchar(1) null
end

--NUMERICOS
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcDoc' and col.name='AuxNum1')
begin
Alter table AdcDoc add AuxNum1 numeric(22,8) null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcDoc' and col.name='AuxNum2')
begin
Alter table AdcDoc add AuxNum2 numeric(22,8) null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcDoc' and col.name='AuxNum3')
begin
Alter table AdcDoc add AuxNum3 numeric(22,8) null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcDoc' and col.name='AuxNum4')
begin
Alter table AdcDoc add AuxNum4 numeric(22,8) null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcDoc' and col.name='AuxNum5')
begin
Alter table AdcDoc add AuxNum5 numeric(22,8) null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcDoc' and col.name='AuxNum6')
begin
Alter table AdcDoc add AuxNum6 numeric(22,8) null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcDoc' and col.name='AuxNum7')
begin
Alter table AdcDoc add AuxNum7 numeric(22,8) null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcDoc' and col.name='AuxNum8')
begin
Alter table AdcDoc add AuxNum8 numeric(22,8) null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcDoc' and col.name='AuxNum9')
begin
Alter table AdcDoc add AuxNum9 numeric(22,8) null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcDoc' and col.name='AuxNum10')
begin
Alter table AdcDoc add AuxNum10 numeric(22,8) null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcDoc' and col.name='AuxNum11')
begin
Alter table AdcDoc add AuxNum11 numeric(22,8) null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcDoc' and col.name='AuxNum12')
begin
Alter table AdcDoc add AuxNum12 numeric(22,8) null
end

----------------------------------------------------------------------
----------------------------------------------------------------------
-- AÑADIR CAMPOS AUXILIARES A AdcTra
-- STRING
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcTra' and col.name='AuxVar1')
begin
Alter table AdcTra add AuxVar1 nvarchar(128) null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcTra' and col.name='AuxVar2')
begin
Alter table AdcTra add AuxVar2 nvarchar(128) null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcTra' and col.name='AuxVar3')
begin
Alter table AdcTra add AuxVar3 nvarchar(128) null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcTra' and col.name='AuxVar4')
begin
Alter table AdcTra add AuxVar4 nvarchar(128) null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcTra' and col.name='AuxVar5')
begin
Alter table AdcTra add AuxVar5 nvarchar(128) null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcTra' and col.name='AuxVar6')
begin
Alter table AdcTra add AuxVar6 nvarchar(128) null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcTra' and col.name='AuxVar7')
begin
Alter table AdcTra add AuxVar7 nvarchar(128) null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcTra' and col.name='AuxVar8')
begin
Alter table AdcTra add AuxVar8 nvarchar(128) null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcTra' and col.name='AuxVar9')
begin
Alter table AdcTra add AuxVar9 nvarchar(128) null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcTra' and col.name='AuxVar10')
begin
Alter table AdcTra add AuxVar10 nvarchar(128) null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcTra' and col.name='AuxVar11')
begin
Alter table AdcTra add AuxVar11 nvarchar(128) null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcTra' and col.name='AuxVar12')
begin
Alter table AdcTra add AuxVar12 nvarchar(128) null
end

-- FECHA
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcTra' and col.name='AuxFec1')
begin
Alter table AdcTra add AuxFec1 datetime null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcTra' and col.name='AuxFec2')
begin
Alter table AdcTra add AuxFec2 datetime null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcTra' and col.name='AuxFec3')
begin
Alter table AdcTra add AuxFec3 datetime null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcTra' and col.name='AuxFec4')
begin
Alter table AdcTra add AuxFec4 datetime null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcTra' and col.name='AuxFec5')
begin
Alter table AdcTra add AuxFec5 datetime null
end

--LOGICOS
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcTra' and col.name='AuxLog1')
begin
Alter table AdcTra add AuxLog1 nvarchar(1) null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcTra' and col.name='AuxLog2')
begin
Alter table AdcTra add AuxLog2 nvarchar(1) null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcTra' and col.name='AuxLog3')
begin
Alter table AdcTra add AuxLog3 nvarchar(1) null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcTra' and col.name='AuxLog4')
begin
Alter table AdcTra add AuxLog4 nvarchar(1) null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcTra' and col.name='AuxLog5')
begin
Alter table AdcTra add AuxLog5 nvarchar(1) null
end

--NUMERICOS
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcTra' and col.name='AuxNum1')
begin
Alter table AdcTra add AuxNum1 numeric(22,8) null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcTra' and col.name='AuxNum2')
begin
Alter table AdcTra add AuxNum2 numeric(22,8) null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcTra' and col.name='AuxNum3')
begin
Alter table AdcTra add AuxNum3 numeric(22,8) null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcTra' and col.name='AuxNum4')
begin
Alter table AdcTra add AuxNum4 numeric(22,8) null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcTra' and col.name='AuxNum5')
begin
Alter table AdcTra add AuxNum5 numeric(22,8) null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcTra' and col.name='AuxNum6')
begin
Alter table AdcTra add AuxNum6 numeric(22,8) null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcTra' and col.name='AuxNum7')
begin
Alter table AdcTra add AuxNum7 numeric(22,8) null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcTra' and col.name='AuxNum8')
begin
Alter table AdcTra add AuxNum8 numeric(22,8) null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcTra' and col.name='AuxNum9')
begin
Alter table AdcTra add AuxNum9 numeric(22,8) null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcTra' and col.name='AuxNum10')
begin
Alter table AdcTra add AuxNum10 numeric(22,8) null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcTra' and col.name='AuxNum11')
begin
Alter table AdcTra add AuxNum11 numeric(22,8) null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcTra' and col.name='AuxNum12')
begin
Alter table AdcTra add AuxNum12 numeric(22,8) null
end

---------------------------------------------------------------------
---------------------------------------------------------------------

-- AÑADIR CAMPOS AUXILIARES A AdcDia
-- STRING
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcDia' and col.name='AuxVar1')
begin
Alter table AdcDia add AuxVar1 nvarchar(128) null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcDia' and col.name='AuxVar2')
begin
Alter table AdcDia add AuxVar2 nvarchar(128) null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcDia' and col.name='AuxVar3')
begin
Alter table AdcDia add AuxVar3 nvarchar(128) null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcDia' and col.name='AuxVar4')
begin
Alter table AdcDia add AuxVar4 nvarchar(128) null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcDia' and col.name='AuxVar5')
begin
Alter table AdcDia add AuxVar5 nvarchar(128) null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcDia' and col.name='AuxVar6')
begin
Alter table AdcDia add AuxVar6 nvarchar(128) null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcDia' and col.name='AuxVar7')
begin
Alter table AdcDia add AuxVar7 nvarchar(128) null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcDia' and col.name='AuxVar8')
begin
Alter table AdcDia add AuxVar8 nvarchar(128) null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcDia' and col.name='AuxVar9')
begin
Alter table AdcDia add AuxVar9 nvarchar(128) null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcDia' and col.name='AuxVar10')
begin
Alter table AdcDia add AuxVar10 nvarchar(128) null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcDia' and col.name='AuxVar11')
begin
Alter table AdcDia add AuxVar11 nvarchar(128) null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcDia' and col.name='AuxVar12')
begin
Alter table AdcDia add AuxVar12 nvarchar(128) null
end

-- FECHA
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcDia' and col.name='AuxFec1')
begin
Alter table AdcDia add AuxFec1 datetime null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcDia' and col.name='AuxFec2')
begin
Alter table AdcDia add AuxFec2 datetime null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcDia' and col.name='AuxFec3')
begin
Alter table AdcDia add AuxFec3 datetime null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcDia' and col.name='AuxFec4')
begin
Alter table AdcDia add AuxFec4 datetime null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcDia' and col.name='AuxFec5')
begin
Alter table AdcDia add AuxFec5 datetime null
end

--LOGICOS
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcDia' and col.name='AuxLog1')
begin
Alter table AdcDia add AuxLog1 nvarchar(1) null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcDia' and col.name='AuxLog2')
begin
Alter table AdcDia add AuxLog2 nvarchar(1) null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcDia' and col.name='AuxLog3')
begin
Alter table AdcDia add AuxLog3 nvarchar(1) null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcDia' and col.name='AuxLog4')
begin
Alter table AdcDia add AuxLog4 nvarchar(1) null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcDia' and col.name='AuxLog5')
begin
Alter table AdcDia add AuxLog5 nvarchar(1) null
end

--NUMERICOS
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcDia' and col.name='AuxNum1')
begin
Alter table AdcDia add AuxNum1 numeric(22,8) null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcDia' and col.name='AuxNum2')
begin
Alter table AdcDia add AuxNum2 numeric(22,8) null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcDia' and col.name='AuxNum3')
begin
Alter table AdcDia add AuxNum3 numeric(22,8) null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcDia' and col.name='AuxNum4')
begin
Alter table AdcDia add AuxNum4 numeric(22,8) null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcDia' and col.name='AuxNum5')
begin
Alter table AdcDia add AuxNum5 numeric(22,8) null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcDia' and col.name='AuxNum6')
begin
Alter table AdcDia add AuxNum6 numeric(22,8) null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcDia' and col.name='AuxNum7')
begin
Alter table AdcDia add AuxNum7 numeric(22,8) null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcDia' and col.name='AuxNum8')
begin
Alter table AdcDia add AuxNum8 numeric(22,8) null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcDia' and col.name='AuxNum9')
begin
Alter table AdcDia add AuxNum9 numeric(22,8) null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcDia' and col.name='AuxNum10')
begin
Alter table AdcDia add AuxNum10 numeric(22,8) null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcDia' and col.name='AuxNum11')
begin
Alter table AdcDia add AuxNum11 numeric(22,8) null
end
if not exists (select col.name from sysobjects obj, syscolumns col 
where obj.id = col.id and obj.name='AdcDia' and col.name='AuxNum12')
begin
Alter table AdcDia add AuxNum12 numeric(22,8) null
end