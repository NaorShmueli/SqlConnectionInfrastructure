USE [naor-pc]
GO


CREATE PROCEDURE dbo.UpsertPhoneNumbers
@phoneNumberRows as dbo.[PhoneNumberRow] READONLY
AS
MERGE dbo.PhoneNumbers as target
USING @phoneNumberRows AS src
on (src.PersonId = target.PersonId)
WHEN MATCHED THEN UPDATE

SET PhoneNumber = src.PhoneNumber,
RowModified = sysdatetime()

WHEN NOT MATCHED THEN 
INSERT (
PersonId,
PhoneNumber
)
VALUES(
src.PersonId,
src.PhoneNumber
);