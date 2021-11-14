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
@modifyBy BIGINT NULL,
@dateModify DATE NULL,
@active BIT,
@profile_id INT,
@id INT OUT
AS
BEGIN
	SET NOCOUNT ON;
	SET @id = (SELECT TOP 1 id FROM USERS WHERE documentNumber = @documentNumber AND documentType_id = @documentType_id AND [login] = @login)
	IF @id IS NULL
	BEGIN
		BEGIN TRANSACTION
		BEGIN TRY
			INSERT INTO USERS
			VALUES (@documentType_id,@documentNumber,@name,@surname,@login,@password,@email,@createBy,@dateCreate,@modifyBy,@dateModify,@active,@profile_id)
			COMMIT TRANSACTION
			SET @id = (SELECT TOP 1 id FROM USERS WHERE documentNumber = @documentNumber AND documentType_id = @documentType_id AND [login] = @login)
			RETURN @id
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			SET @id = 0
			RETURN @id
		END CATCH
	END ELSE 
	BEGIN
		SET @id = 0
		RETURN @id
	END
END
GO
