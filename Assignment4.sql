/**
Assignment 4
Zihao Shao

1
View is a virtural table whose contents are defined by a query. 
Like a real table, a view consists of a set of named columns and rows of data.
Benifits of using views: 
1. To simplify data munipulation.
2. Views enable you to create a backward compatible interface for a table when its schema changes.
3. To customize data, views let different users to see data in different ways, even they are using the same data at the same time.
4. Distributed query can also be used to define views that use data from multiple heterogeneous sources.

2
Data can be modified through views. 
Modifying Data Through a View, Any modifications, including UPDATE, INSERT, and DELETE statements, 
must reference columns from only one base table. 
The columns that are being modified in the view must reference the underlying data in the table columns directly.

3
A stored procedure groups one or more transact-sql statement into a logical unit, stored as an object in a SQL Server database.
Benifits of using stored procedures
1. Increase database security.
2. Fast execution.
3. Stored procedures help centralize your transact-sql code in the data tier.
4. Stored procedures can help reduce network traffic of larger ad hoc queries.
5. Stored procedures encourage code reusability.

4
A Stored Procedure:
Accepts parameters
Can NOT be used as building block in a larger query
Can contain several statements, loops, IF ELSE, etc.
Can perform modifications to one or several tables
Can NOT be used as the target of an INSERT, UPDATE or DELETE statement.

A View:
Does NOT accept parameters
Can be used as building block in a larger query
Can contain only one single SELECT query
Can NOT perform modifications to any table
But can (sometimes) be used as the target of an INSERT, UPDATE or DELETE statement.


5
1.The function must return a value but in Stored Procedure it is optional. Even a procedure can return zero or n values.
2.Functions can have only input parameters for it whereas Procedures can have input or output parameters.
3.Functions can be called from Procedure whereas Procedures cannot be called from a Function.

6
Stored procedures contain IN and OUT parameters or both. 
They may return result sets in case you use SELECT statements. Stored procedures can return multiple result sets.

7
Store procedure cannot be used in select statement. 
You can re-write this SP in Function and call this function in Select statement as you need.

8
Triggers are a special type of stored procedure that get executed(fired) when a specific event happens.
There are three types of triggers: 
DML (data manipulation language) triggers – These are – INSERT, UPDATE, and DELETE
DDL (data definition language) triggers – As expected, triggers of this type shall react to DDL commands like – CREATE, ALTER, and DROP
Logon triggers – The name says it all. This type reacts to LOGON events

9
Create trigger [trigger name] on [table name]
[FOR|AFTER|INSTEAD OF]
{insert|update|delete}
AS
{
sql_statement
}

10
Stored procedures are a pieces of the code in written in PL/SQL to do some specific task. Stored procedures can be invoked explicitly by the user. 
It's like a java program , it can take some input as a parameter then can do some processing and can return values.

On the other hand,  trigger is a stored procedure that runs automatically when various events happen (eg update, insert, delete). 
Triggers are more like an event handler they run at the specific event. Trigger can not take input and they can’t return values.
**/

--1
--a
INSERT Region (RegionID, RegionDescription) VALUES (5, 'Middle Earth');

--b
INSERT Territories VALUES (12345, 'Gonder', 5)

--c
INSERT Employees(LastName, FirstName) VALUES ('Argorn', 'King')
INSERT EmployeeTerritories VALUES (10, 12345)

--2
UPDATE Territories 
SET TerritoryDescription = 'Arnor'
WHERE TerritoryID = 12345

--3
DELETE FROM EmployeeTerritories WHERE EmployeeID = 10;
DELETE FROM Employees WHERE EmployeeID = 10;
DELETE FROM Territories WHERE TerritoryDescription = 'Arnor';
DELETE FROM Region WHERE RegionDescription = 'Middle Earth';

--4
CREATE VIEW view_product_order_Shao AS
SELECT p.ProductID, p.ProductName, COUNT(od.Quantity) AS TotalQuantity
FROM Products p 
FULL JOIN [Order Details] od ON p.ProductID = od.ProductID
GROUP BY p.ProductID, p.ProductName

SELECT * FROM view_product_order_Shao ORDER BY TotalQuantity DESC;

--5
CREATE PROCEDURE sp_product_order_quantity_Shao
	@productID int, 
	@TotalQuantity int OUTPUT
AS
BEGIN
	SELECT @TotalQuantity = COUNT(od.Quantity) 
	FROM Products p FULL JOIN [Order Details] od ON p.productID = od.productID
	WHERE p.ProductID = @productID
END 
GO

--6
CREATE PROCEDURE sp_product_order_city_Shao
	@productName nvarchar(40),
	@Top5City nvarchar(15) OUTPUT,
	@TotalQuantity int OUTPUT
AS
BEGIN
	SELECT TOP 5 @Top5City = o.ShipCity, @TotalQuantity = COUNT(od.Quantity)
	FROM Products p FULL JOIN [Order Details] od ON p.ProductID = od.ProductID
	FULL JOIN Orders o ON od.OrderID = o.OrderID 
	WHERE p.ProductName = @productName
	GROUP BY o.ShipCity
	ORDER BY COUNT(od.Quantity)
END
GO

--7
CREATE PROCEDURE sp_move_employees_Shao
	@TotalEmployee int,
	@EmployeeID int
AS
BEGIN 
	SELECT @EmployeeID = e.EmployeeID, @TotalEmployee = COUNT(e.EmployeeID)
	FROM Employees e INNER JOIN EmployeeTerritories et ON e.EmployeeID = et.EmployeeID
	INNER JOIN Territories t ON t.TerritoryID = et.TerritoryID
	WHERE t.TerritoryDescription = 'Tory'

	IF(@TotalEmployee > 0)
	BEGIN
		INSERT INTO Territories VALUES ('12345', 'Stevens Point', 3)
		UPDATE EmployeeTerritories SET TerritoryID = '12345' WHERE EmployeeID = @EmployeeID
	END
END

--8
CREATE TRIGGER moveEmployees ON Territiories
FOR UPDATE 
AS
	BEGIN
	IF(SELECT COUNT(t.EmployeeID) FROM EmployeeTerritories t HAVING TerritoryID = 3 )>100)
		BEGIN
		UPDATE 
		EmployeeTerritories  SET TerritoryID = '48084' WHERE TerritoryID = '12345';
	END
END

--9
CREATE TABLE people_Shao(Id int primary key, Name varchar(20), CityId int foreign key references city_Shao(Id))

CREATE TABLE city_Shao(Id int primary key, CityName varchar(20))

INSERT INTO city_Shao VALUES (1, 'Seattle');
INSERT INTO city_Shao VALUES (2, 'Green Bay');

INSERT INTO people_Shao VALUES (1, 'Aaron Rogers', 2);
INSERT INTO people_Shao VALUES (2, 'Russel Willson', 1);
INSERT INTO people_Shao VALUES (3, 'Jody Nelson', 2);

INSERT INTO city_Shao VALUES (3, 'Madition');

UPDATE people_Shao SET CityId = 3 WHERE CityId = 1;  
SELECT * FROM people_Shao;

DELETE FROM city_Shao WHERE CityName = 'Seattle';

CREATE VIEW Packer_Shao AS 
SELECT p.Id, p.Name
FROM city_Shao c FULL JOIN people_Shao p ON c.Id = p.CityId
WHERE c.CityName = 'Green Bay';
SELECT * FROM Packer_Shao;
DROP TABLE people_Shao;
DROP TABLE city_Shao;
DROP VIEW Packer_Shao;

--10
CREATE PROCEDURE sp_birthday_employees_Shao AS 
	BEGIN
		CREATE TABLE birthday_employee_Shao
		(EmployeeId int not null primary key,
		 LastName nvarchar(20) not null,
		 FirstName nvarchar(10) not null,
		 BirthDate datetime not null
		)
	INSERT INTO birthday_employee_Shao(EmployeeID, LastName, FirstName, BirthDate)
	SELECT EmployeeID, LastName, FirstName, BirthDate
	FROM Employees WHERE MONTH(BirthDate) = 2
	END

--11
CREATE PROCEDURE sp_Shao
AS
	SELECT c.City
	FROM Customers c INNER JOIN Orders o ON c.CustomerID = o.CustomerID
	INNER JOIN [Order Details] od ON o.OrderID = od.OrderID
	GROUP BY c.City
	HAVING COUNT(c.ContactName) >= 2 AND COUNT(od.Quantity)<=1
GO

CREATE PROCEDURE sp_Shao2
AS
	SELECT City FROM Customers WHERE CustomerID IN
		(SELECT CustomerID FROM Orders WHERE OrderID IN 
			(SELECT OrderID FROM [Order Details] 
				GROUP BY OrderID HAVING COUNT(Quantity)<=1)
			)GROUP BY CITY HAVING COUNT(ContactName) >=2
GO

--12
/**
An inner join to pick up the rows where the primary key exists in both tables, 
but there is a difference in the value of one or more of the other columns. 
This would pick up changed rows in original.

A left outer join to pick up the rows that are in the original tables, 
but not in the backup table (i.e. a row in original has a primary key that does not exist in backup). 
This would return rows inserted into the original.

A right outer join to pick up the rows in backup which no longer exist in the original. 
This would return rows that have been deleted from the original.
**/

--14
SELECT CONCAT([First Name] + ' ' + [Last Name] + ' ' + [MiddleName] + '.') AS [FULL NAME] FROM table_name;

--15
SELECT Student, 
		Marks, 
		DENSE_RANK() OVER (ORDER BY Marks DESC) Rank 
FROM table_name
WHERE Sex = "F"
ORDER BY Rank;

--16
SELECT Student, 
		Marks
		Sex,
		DENSE_RANK() OVER (PARTITION BY Sex ORDER BY Marks DESC) Rank
FROM table_name
ORDER BY Rank;
