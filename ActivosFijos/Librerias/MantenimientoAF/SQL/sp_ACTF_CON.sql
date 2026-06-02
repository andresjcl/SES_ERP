USE [BdAdcomDxSistemas]
GO

/****** Object:  StoredProcedure [dbo].[ACTF_CON]    Script Date: 07/28/2010 10:18:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
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


