USE [naor-pc]
GO

CREATE PROCEDURE [dbo].[GetPerson]
@id varchar(100)
AS
BEGIN
SELECT 
p.Id,
FirstName,
LastName,
Age,
[Address],
City,
pn.PhoneNumber,
fpn.FriendName,
fpn.PhoneNumber as FriendPhoneNumber
FROM Persons p
INNER JOIN PhoneNumbers pn
ON (pn.PersonId = @id)
INNER JOIN FriendPhoneNumbers fpn
ON (fpn.PersonId = @id)
WHERE p.Id = @id
END