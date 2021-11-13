USE ADMIN_USERS
GO

IF OBJECT_ID('SP_USERS_UPDATE') IS NOT NULL
	DROP PROC SP_USERS_UPDATE
GO

CREATE PROCEDURE SP_USERS_UPDATE
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
@profile_id INT
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @validation BIGINT
	SET @validation = (SELECT TOP 1 id FROM USERS WHERE documentNumber = @documentNumber and documentType_id = @documentType_id and [login] = @login)
	IF @validation IS NULL
	BEGIN
		BEGIN TRANSACTION
		BEGIN TRY
			UPDATE USERS SET documentType_id = @documentType_id, documentNumber = @documentNumber, [name] = @name, surname = @surname, [login] = @login,
			[password] = @password, email = @email, modifyBy = @modifyBy, dateModify = @dateModify, active = @active, profile_id = @profile_id WHERE id = @id
			COMMIT TRANSACTION
			RETURN 1
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
