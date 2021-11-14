USE ADMIN_USERS
GO

IF OBJECT_ID('PROFILES') IS NOT NULL
	DROP TABLE PROFILES
GO

CREATE TABLE PROFILES(
id INT PRIMARY KEY NOT NULL,
[profile] VARCHAR(20) NOT NULL
)
GO

INSERT INTO PROFILES VALUES (1,'Administrador'),(2, 'Usuario')
