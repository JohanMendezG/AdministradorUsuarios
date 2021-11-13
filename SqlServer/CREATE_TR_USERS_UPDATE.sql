USE ADMIN_USERS
GO

IF OBJECT_ID('TR_USERS_UPDATE') IS NOT NULL
	DROP PROC TR_USERS_UPDATE
GO

CREATE TRIGGER TR_USERS_UPDATE 
   ON  USERS
   AFTER UPDATE
AS 
BEGIN
	SET NOCOUNT ON;
	DECLARE
	@id BIGINT,
	@documentType_id INT,
	@documentNumber BIGINT,
	@name VARCHAR(30),
	@surname VARCHAR(30),
	@login VARCHAR(20),
	@password VARCHAR(20),
	@email VARCHAR(30),
	@modifyBy BIGINT,
	@dateModify DATE,
	@active BIT,
	@profile_id INT,
	@Detail VARCHAR(255)
	SELECT @id = id, @documentType_id = documentType_id, @documentNumber = documentNumber, @name = [name], @surname = surname, @login = [login],
			@password = [password], @email = email, @modifyBy = modifyBy, @dateModify = dateModify, @active = active, @profile_id = profile_id FROM inserted
	SET @Detail = CONCAT('documentType_id: ',@documentType_id,', documentNumber: ',@documentNumber,', name: ',@name,', surname: ',@surname,', login: ',@login,
	', password: ',@password,', email: ',@email,', modifyBy: ',@modifyBy,', dateModify: ',@dateModify,', active: ',@active,', profile_id: ',@profile_id)
	INSERT INTO LOG_USERS VALUES(GETDATE(),@id,@modifyBy,@Detail)
END
GO
