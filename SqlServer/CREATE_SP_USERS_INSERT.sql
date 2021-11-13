USE ADMIN_USERS
GO

IF OBJECT_ID('SP_USERS_INSERT') IS NOT NULL
	DROP PROC SP_USERS_INSERT
GO

CREATE PROCEDURE SP_USERS_INSERT
@documentType_id INT,
@documentNumber BIGINT,
@name VARCHAR(30),
@surname VARCHAR(30),
@login VARCHAR(20),
@password VARCHAR(20),
@email VARCHAR(30),
@createBy BIGINT,
@dateCreate DATE,
@modifyBy BIGINT,
@dateModify DATE,
@active BIT,
@profile_id INT
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @id INT;
	SET @id = (SELECT id FROM VIEW_USERS WHERE documentNumber = @documentNumber and documentType = @documentType_id and [login] = @login)
	IF @id IS NULL
	BEGIN
		BEGIN TRANSACTION
		BEGIN TRY
			INSERT INTO USERS
			VALUES (@documentType_id,@documentNumber,@name,@surname,@login,@password,@email,@createBy,@dateCreate,@modifyBy,@dateModify,@active,@profile_id)
			SET @id = (SELECT id FROM VIEW_USERS WHERE documentNumber = @documentNumber and documentType = @documentType_id and [login] = @login)
			COMMIT TRANSACTION
			RETURN @id
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			RETURN 0
		END CATCH
	END ELSE 
	BEGIN
		RETURN 0
	END
END
GO
