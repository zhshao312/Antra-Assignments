/**
Assignment 1
Zihao Shao
5/4/2021
**/

--1
SELECT ProductID, Name, Color, ListPrice FROM production.Product;
--2
SELECT ProductID, Name, Color, ListPrice FROM production.Product WHERE ListPrice = 0;
--3
SELECT ProductID, Name, Color, ListPrice FROM production.Product WHERE Color IS NULL;
--4
SELECT ProductID, Name, Color, ListPrice FROM production.Product WHERE Color IS NOT NULL;
--5
SELECT ProductID, Name, Color, ListPrice FROM production.Product WHERE Color IS NOT NULL AND ListPrice > 0;
--6
SELECT Name, Color FROM Production.Product WHERE NOT Color IS NULL;
--7
SELECT Name, Color FROM Production.Product WHERE NOT Color IS NULL;
--8
SELECT ProductID, Name FROM Production.Product WHERE ProductID BETWEEN 400 AND 500;
--9
SELECT ProductID, Name, Color FROM Production.Product WHERE Color IN ('Black', 'blue');
--10
SELECT ProductID, Name, Color, ListPrice FROM Production.Product WHERE Name LIKE 'S%';
--11
SELECT Name, ListPrice FROM Production.Product WHERE Name LIKE 'S%' ORDER BY Name;
--12
SELECT Name, ListPrice FROM Production.Product WHERE Name LIKE '[A,S]%' ORDER BY Name;
--13
SELECT Name, ListPrice FROM Production.Product WHERE Name LIKE 'SPO[^K]%' ORDER BY Name;
--14
SELECT DISTINCT Color FROM Production.Product ORDER BY Color DESC;
--15
SELECT DISTINCT ProductSubcategoryID, Color FROM Production.Product WHERE NOT ProductSubcategoryID IS NULL AND NOT Color IS NULL ORDER BY ProductSubcategoryID, Color DESC;
--16
SELECT ProductSubCategoryID, LEFT([Name],35) AS [Name], Color, ListPrice FROM Production.Product
WHERE Color IN ('Red', 'Black') AND ProductSubcategoryID = 1 OR ListPrice BETWEEN 1000 AND 2000 
ORDER BY ProductID;
--17
SELECT ProductSubCategoryID, Name, Color, ListPrice FROM Production.Product 
WHERE ProductSubcategoryID BETWEEN 1 AND 14 AND ProductSubcategoryID != 13
AND NOT Color IS NULL
ORDER BY ProductSubcategoryID DESC, ListPrice DESC;
