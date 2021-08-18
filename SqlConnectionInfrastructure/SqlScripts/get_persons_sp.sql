USE [naor-pc]
GO


CREATE PROCEDURE [dbo].[GetPersons]
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
ON (pn.PersonId = p.Id)
INNER JOIN FriendPhoneNumbers fpn
ON (fpn.PersonId = p.Id)
END