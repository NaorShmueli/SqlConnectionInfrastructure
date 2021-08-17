USE [naor-pc]
GO


CREATE PROCEDURE dbo.GetPerson
@id varchar
AS
BEGIN
SELECT 
Id,
FirstName,
LastName,
Age,
[Address],
City
FROM Persons
WHERE Id = @id
END