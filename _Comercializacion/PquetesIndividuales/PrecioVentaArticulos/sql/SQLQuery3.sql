create procedure listaPrecios
@orderby varchar(1)='',
@Art_categor varchar(4)='',
@Art_clase varchar(4)='',
@Art_grupo varchar(4)='',
@Art_subgrup varchar(4)='',
@Art_codigo1 varchar(255)='',
@Art_codigo2 varchar(255)=''
AS
BEGIN
	if @orderby = 'N'
	begin
	select Art_codigo, Art_nombre,Art_unimed, Art_precvta1,Art_precvta2, Art_precvta3, Art_precvta4, Art_precvta5 from AdcArt
	WHERE (Art_categor =@Art_categor
          or Art_clase = @Art_clase
          or Art_grupo = @Art_grupo
          or Art_subgrup = @Art_subgrup)
          and(Art_codigo >= @Art_codigo1 and Art_codigo <=@Art_codigo2)
	group by Art_clase, Art_codigo, Art_nombre,Art_unimed, Art_precvta1,Art_precvta2, Art_precvta3, Art_precvta4, Art_precvta5
	order by LTRIM(Art_nombre)
	end	
	if @orderby = 'C'
	begin
	select Art_codigo, Art_nombre,Art_unimed, Art_precvta1,Art_precvta2, Art_precvta3, Art_precvta4, Art_precvta5 from AdcArt
	WHERE (Art_categor =@Art_categor
          or Art_clase = @Art_clase
          or Art_grupo = @Art_grupo
          or Art_subgrup = @Art_subgrup)
          and(Art_codigo >= @Art_codigo1 and Art_codigo <=@Art_codigo2)
	group by Art_categor,Art_codigo, Art_nombre,Art_unimed, Art_precvta1,Art_precvta2, Art_precvta3, Art_precvta4, Art_precvta5
	order by Art_codigo 
	end	
end