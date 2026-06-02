
create procedure CH_BANCO
@fechaInicial datetime,
@fechaFinal datetime,
@institucion varchar(3)='',
@opcion as varchar(3)=''
as
BEGIN
	if @opcion = 's'
	begin 
		select Doc_CobraCheque as Registro, Doc_fecha as Fecha,
		Doc_NombreImp as Beneficiario, Doc_detalle as Detalle, Doc_docnombre as Documento,
		Doc_TipoDoc as Tipo, IdClaveDoc as Número, Doc_numero as Cheque, (Doc_valor *  Doc_Banco) as Valor
		from AdcDoc
		where doc_BancoOrigen = @institucion
		and ((Doc_CobraCheque >= @fechaInicial or @fechaInicial ='')and (Doc_CobraCheque <= @fechaFinal or @fechaFinal =''))
	end
	if @opcion = 'n'
	begin
		select Doc_CobraCheque as Registro, Doc_fecha as Fecha,
		Doc_NombreImp as Beneficiario, Doc_detalle as Detalle, Doc_docnombre as Documento,
		Doc_TipoDoc as Tipo, IdClaveDoc as Número, Doc_numero as Cheque, (Doc_valor*Doc_Banco) as Valor
		from AdcDoc
		where doc_BancoOrigen = @institucion
		and (Doc_CobraCheque =''
		or Doc_CobraCheque is NULL)
		and Doc_fecha between @fechaInicial and @fechaFinal
	end
	if @opcion = 'sn'
	begin
		select Doc_CobraCheque as Registro, Doc_fecha as Fecha,
		Doc_NombreImp as Beneficiario, Doc_detalle as Detalle, Doc_docnombre as Documento,
		Doc_TipoDoc as Tipo, IdClaveDoc as Número, Doc_numero as Cheque, (Doc_valor*Doc_Banco) as Valor
		from AdcDoc
		where doc_BancoOrigen = @institucion
		and ((Doc_CobraCheque >= @fechaInicial or @fechaInicial ='')and (Doc_CobraCheque <= @fechaFinal or @fechaFinal =''))
		or ((Doc_fecha >= @fechaInicial or @fechaInicial ='')and (Doc_fecha <= @fechaFinal or @fechaFinal =''))
	end
END




