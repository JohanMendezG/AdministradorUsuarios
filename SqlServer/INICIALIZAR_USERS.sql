USE [ADMIN_USERS]
GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[SP_USERS_INSERT]
		@documentType_id = 1,
		@documentNumber = 1111111111,
		@name = N'Bill',
		@surname = N'Gates',
		@login = N'BGates',
		@password = N'bgates',
		@email = N'bill@gates.com',
		@createBy = 1111111111,
		@dateCreate = '20210101',
		@modifyBy = NULL,
		@dateModify = NULL,
		@active = 1,
		@profile_id = 1

SELECT	'Return Value' = @return_value
GO
