USE [naor-pc]
GO


CREATE PROCEDURE dbo.DeletePerson
@id varchar(100)
AS
BEGIN
DELETE Persons
WHERE Id = @id
END