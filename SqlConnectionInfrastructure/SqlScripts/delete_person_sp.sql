USE [naor-pc]
GO


CREATE PROCEDURE dbo.DeletePerson
@id varchar
AS
BEGIN
DELETE Persons
WHERE Id = @id
END