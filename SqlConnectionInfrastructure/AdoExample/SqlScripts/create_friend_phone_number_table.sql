USE [naor-pc]
GO

CREATE TABLE dbo.FriendPhoneNumbers(
	[Id] int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[PersonId] [varchar](100) NOT NULL,
	[FriendName] [varchar](100) NOT NULL,
	[PhoneNumber] [varchar](100) NOT NULL,
	[RowCreated] [datetime2](7) NOT NULL,
	[RowModified] [datetime2](7) NOT NULL
)
GO

ALTER TABLE dbo.[FriendPhoneNumbers] ADD  CONSTRAINT [DF_FriendPhoneNumbers_RowCreated]  DEFAULT (sysdatetime()) FOR [RowCreated]
GO

ALTER TABLE dbo.[FriendPhoneNumbers] ADD  CONSTRAINT [DF_FriendPhoneNumbers_RowModified]  DEFAULT (sysdatetime()) FOR [RowModified]
GO


