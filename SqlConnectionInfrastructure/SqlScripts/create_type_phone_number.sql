USE [naor-pc]
GO

CREATE TYPE dbo.[PhoneNumberRow] AS TABLE(
	[PersonId] [varchar](100) NOT NULL,
	[PhoneNumber] [varchar](100) NOT NULL
)
GO


