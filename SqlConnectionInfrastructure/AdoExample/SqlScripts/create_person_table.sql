USE [naor-pc]
GO

CREATE TABLE dbo.[Persons](
	[Id] [varchar](100) NOT NULL,
	[FirstName] [varchar](100) NOT NULL,
	[LastName] [varchar](100) NOT NULL,
	[Age] int NOT NULL,
	[Address] [varchar](100) NOT NULL,
	[City] [varchar](100) NOT NULL,
	[RowCreated] [datetime2](7) NOT NULL,
	[RowModified] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Persons] PRIMARY KEY CLUSTERED 
(
	Id ASC
)
) ON [PRIMARY]
GO

ALTER TABLE dbo.[Persons] ADD  CONSTRAINT [DF_Persons_RowCreated]  DEFAULT (sysdatetime()) FOR [RowCreated]
GO

ALTER TABLE dbo.[Persons] ADD  CONSTRAINT [DF_Persons_RowModified]  DEFAULT (sysdatetime()) FOR [RowModified]
GO


