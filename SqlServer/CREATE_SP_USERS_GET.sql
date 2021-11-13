USE ADMIN_USERS
GO

IF OBJECT_ID('SP_USERS_GET') IS NOT NULL
	DROP PROC SP_USERS_GET
GO

CREATE PROCEDURE SP_USERS_GET
	@id BIGINT
AS
BEGIN
SET NOCOUNT ON;

IF @id IS NULL
	BEGIN
		SELECT * FROM VIEW_USERS
	END
ELSE
	BEGIN
		SELECT * FROM VIEW_USERS WHERE id = @id
	END
END
GO
