USE [naor-pc]
GO


CREATE PROCEDURE [dbo].[DeletePerson]
@id varchar(100)
AS
BEGIN
DELETE Persons
WHERE Id = @id
DELETE FriendPhoneNumbers
WHERE PersonId = @id
DELETE PhoneNumbers
WHERE PersonId = @id
END