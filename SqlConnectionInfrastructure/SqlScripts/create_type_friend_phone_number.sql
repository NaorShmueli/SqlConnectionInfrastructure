USE [naor-pc]
GO

CREATE TYPE dbo.[FriendPhoneNumberRow] AS TABLE(
	[PersonId] [varchar](100) NOT NULL,
	[FriendName] [varchar](100) NOT NULL,
	[PhoneNumber] [varchar](100) NOT NULL
)
GO


