USE [naor-pc]
GO


CREATE PROCEDURE dbo.GetPersons
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
END