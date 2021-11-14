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
@profile_id INT,
@validation BIT OUT
AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRANSACTION
	BEGIN TRY
		UPDATE USERS SET documentType_id = @documentType_id, documentNumber = @documentNumber, [name] = @name, surname = @surname, [login] = @login,
		[password] = @password, email = @email, modifyBy = @modifyBy, dateModify = @dateModify, active = @active, profile_id = @profile_id WHERE id = @id

		DECLARE @count INT = 0;
		SET @count = (SELECT COUNT(id) FROM USERS WHERE documentNumber = @documentNumber AND documentType_id = @documentType_id AND [login] = @login)
		IF @count = 1
		BEGIN
			COMMIT TRANSACTION
			SET @validation = 1
			RETURN @validation
		END ELSE
		BEGIN
			ROLLBACK TRANSACTION
			SET @validation = 0
			RETURN @validation
		END
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		SET @validation = 0
		RETURN @validation
	END CATCH
END
GO
