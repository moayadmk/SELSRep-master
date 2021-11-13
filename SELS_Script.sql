/*Create new database name is SELS */
USE MASTER;
GO 
IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'SELS')
BEGIN
CREATE DATABASE SELS ;
END
GO

/*Go to the SELS data base to accses the data base*/
USE SELS ;
GO

/*Create user table */
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'User')
BEGIN
CREATE TABLE [dbo].[User] ([ID] INT IDENTITY (1,1)  PRIMARY KEY, [Username]  VARCHAR (MAX), [Password] VARCHAR(MAX), [Phonenumber] VARCHAR(10));
END
GO
/*Create Category table */
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Category')
BEGIN
CREATE TABLE [dbo].[Category] ([ID] int identity(1,1)  PRIMARY KEY, [Name] nvarchar(50), [Description] nvarchar(max), [Photo] nvarchar(max));
END
GO

/*Create Lesson table */
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Lesson')
BEGIN
CREATE TABLE [dbo].[Lesson] ([ID] int identity(1,1)  PRIMARY KEY, [Name] nvarchar(50), [Description] nvarchar(max), [VideoLink] nvarchar(max));
END
GO

/*Create Lesson table */
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'CategoryPerUser')
BEGIN
CREATE TABLE [dbo].[CategoryPerUser] ([ID] int identity(1,1)  PRIMARY KEY,UserID INT FOREIGN KEY REFERENCES [User](ID),CategoryID INT FOREIGN KEY REFERENCES Category(ID));
END
GO



