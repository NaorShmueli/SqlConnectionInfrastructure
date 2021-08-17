USE [naor-pc]
GO

CREATE TYPE dbo.[PersonRow] AS TABLE(
	[Id] [varchar](100) NOT NULL,
	[FirstName] [varchar](100) NOT NULL,
	[LastName] [varchar](100) NOT NULL,
	[Age] int NOT NULL,
	[Address] [varchar](100) NOT NULL,
	[City] [varchar](100) NOT NULL
)
GO


