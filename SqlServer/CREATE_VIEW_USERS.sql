USE ADMIN_USERS
GO

IF OBJECT_ID('VIEW_USERS') IS NOT NULL
	DROP VIEW VIEW_USERS
GO

CREATE VIEW VIEW_USERS
AS
SELECT 
	U.id,
	D.documentType,
	U.documentNumber,
	U.[name],
	U.surname,
	U.[login],
	U.[password],
	U.email,
	U.createBy,
	U.dateCreate,
	U.modifyBy,
	U.dateModify,
	U.active,
	P.[profile]
FROM USERS U
INNER JOIN DOCUMENTTYPES D ON U.documentType_id = D.id
INNER JOIN PROFILES P ON U.profile_id = P.[profile]
GO
