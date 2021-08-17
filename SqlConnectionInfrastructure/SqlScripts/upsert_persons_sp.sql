USE [naor-pc]
GO


CREATE PROCEDURE dbo.UpsertPersons
@personRows as dbo.[PersonRow] READONLY
AS
MERGE dbo.Persons as target
USING @personRows AS src
on (src.Id = target.Id)
WHEN MATCHED THEN UPDATE

SET FirstName = src.FirstName,
LastName = src.LastName,
[Address] = src.[Address],
City = src.City,
RowModified = sysdatetime()

WHEN NOT MATCHED THEN 
INSERT (
Id,
FirstName,
LastName,
Age,
[Address],
City
)
VALUES(
src.Id,
src.FirstName,
src.LastName,
src.Age,
src.[Address],
src.City
);