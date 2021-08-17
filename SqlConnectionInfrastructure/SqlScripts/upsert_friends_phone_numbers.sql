USE [naor-pc]
GO


CREATE PROCEDURE dbo.UpsertFriendPhoneNumbers
@friendPhoneNumberRows as dbo.[FriendPhoneNumberRow] READONLY
AS
MERGE dbo.FriendPhoneNumbers as target
USING @friendPhoneNumberRows AS src
on (src.PersonId = target.PersonId)
WHEN MATCHED THEN UPDATE

SET PhoneNumber = src.PhoneNumber,
FriendName = src.FriendName,
RowModified = sysdatetime()

WHEN NOT MATCHED THEN 
INSERT (
PersonId,
FriendName,
PhoneNumber
)
VALUES(
src.PersonId,
src.FriendName,
src.PhoneNumber
);