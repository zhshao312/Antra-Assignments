/**
	Assignment 2
	Zihao Shao
**/

--Answer following questions:
--1. What is a result set?
--A: Result set is a set of data.This data can be empty and is returned by select statements or stored procedures. 

--2. What is the difference between Union and Union All?
--A: Union only keeps the unique records but Union All keeps all records including duplicates.

--3. What are the other Set Operators SQL Server has?
--A: It has UNION, UNION ALL, INTERSECT, EXCEPT.

--4. What is the difference between Union and Join?
--A: Joins combine data into new columns but Unions combine data into new rows.

--5. What is the difference between INNER JOIN and FULL JOIN?
--A: Inner JOIN returns only the matching rows between both the tables, non-matching rows are eliminated, 
--   but FULL JOIN returns all rows from two tables(left table and right table), non-matching rows are included.

--6. What is difference between left Join and Outer Join?
--A: Left join is one of the Outer joins. It will bring all the records from the left table 
--   but only those records from the right will satisfy the join condition. 
--   For non matching records right table will return null value.
--   Outer Join have three difference types: left join, right join and full join.

--7. What is CROSS JOIN?
--A: The CROSS JOIN is used to generate a paired combination of each row of the first table with each row of the second table. 

--8. Where are the diferences between WHERE clause and Having clause?
--A: 1.WHERE Clause is used to filter records from table based on specified conditions
--     but HAVING clause is used to filter records from group based on specidied conditions,
--   2.WHERE clause can be used without GROUP BY clause, but HAVING clause must be used with GROUP BY clause.
--   3.WHERE clause implements in rows operations, but HAVING clause implements in column operations.
--   4.WHERE clause is used before GROUP BY clause, but HAVING clause is used after GROUP BY clause.

--9. Can there be multiple group by columns?
--A: Yes, a grouping can consist of two or more columns.

-- Write queries for following scenarios:
--1
SELECT COUNT(*) AS NumOfProduct FROM Production.Product;

--2
SELECT COUNT(ProductSubcategoryID) AS NumOfSubcategory FROM Production.Product;

--3
SELECT ProductSubcategoryID, COUNT([Name]) AS CountedProducts
FROM Production.Product GROUP BY ProductSubcategoryID;

--4
SELECT COUNT(*) AS NumNoSubcatgory FROM Production.Product 
WHERE ProductSubcategoryID IS NULL;

--5
SELECT ProductId, SUM(Quantity) AS TheSum 
FROM Production.ProductInventory GROUP BY ProductID;

--6
SELECT ProductID, SUM(Quantity) AS TheSum
FROM Production.ProductInventory 
WHERE LocationID = 40
GROUP BY ProductID
HAVING SUM(Quantity) < 100;

--7
SELECT ProductID, Shelf, SUM(Quantity) AS TheSum
FROM Production.ProductInventory
WHERE LocationID = 40
Group by ProductID, Shelf
HAVING SUM(Quantity) < 100;

--8
SELECT AVG(Quantity) AS TheAvg
FROM Production.ProductInventory
WHERE LocationID = 10;

--9
SELECT ProductID, Shelf, AVG(Quantity) AS TheAvg
FROM Production.ProductInventory 
GROUP BY ProductID, Shelf;

--10
SELECT ProductID, Shelf, AVG(Quantity) AS TheAvg
FROM Production.ProductInventory
WHERE Shelf <> 'N/A'
GROUP BY ProductID, Shelf;

--11
SELECT Color, Class, COUNT(*) AS TheCount, AVG(ListPrice) AS AvgPrice
FROM Production.Product
WHERE Color IS NOT NULL AND Class IS NOT NULL
GROUP BY Color, Class;

--12
SELECT PC.Name AS Country, PS.Name AS Province
FROM Person.CountryRegion AS PC JOIN Person.StateProvince AS PS
ON PC.CountryRegionCode = PS.CountryRegionCode;

--13
SELECT PC.Name AS Country, PS.Name AS Province
FROM Person.CountryRegion AS PC JOIN Person.StateProvince AS PS
ON PC.CountryRegionCode = PS.CountryRegionCode
WHERE PC.Name IN ('Germany', 'Canada')

--14
SELECT p.ProductID, p.ProductName, p.UnitPrice, SUM(od.Quantity) AS SumSold, o.OrderDate
FROM Orders AS o JOIN [Order Details] AS od ON o.OrderID = od.OrderID
JOIN Products AS p ON od.productID = p.ProductID
WHERE o.Orderdate BETWEEN DATEADD(YEAR, -25, GETDATE()) AND GETDATE()
GROUP BY p.ProductID, p.ProductName, p.UnitPrice, o.OrderDate
HAVING SUM(od.Quantity) >=1;

--15
SELECT TOP 5 o.ShipPostalCode, SUM(od.Quantity) AS SumSold
FROM Orders AS o JOIN [Order Details] AS od ON o.OrderID = od.OrderID
GROUP BY o.ShipPostalCode
Order by SUM(od.Quantity) desc;

--16
SELECT TOP 5 o.ShipPostalCode, SUM(od.Quantity) AS SumSold, o.OrderDate
FROM Orders AS o JOIN [Order Details] AS od ON o.OrderID = od.OrderID
WHERE o.OrderDate BETWEEN DATEADD(YEAR, -25, GETDATE()) AND GETDATE()
GROUP BY o.ShipPostalCode, o.OrderDate
Order by SUM(od.Quantity) desc;

--17
SELECT TOP 5 o.ShipCity, COUNT(o.CustomerID) AS NumOfCustomer, o.ShipPostalCode, SUM(od.Quantity) AS SumSold, o.OrderDate
FROM Orders AS o JOIN [Order Details] AS od ON o.OrderID = od.OrderID
WHERE o.OrderDate BETWEEN DATEADD(YEAR, -25, GETDATE()) AND GETDATE()
GROUP BY o.ShipCity, o.ShipPostalCode, o.OrderDate
Order by SUM(od.Quantity) desc;

18
SELECT ShipCity, COUNT(CustomerID) AS NumOfCustomers FROM Orders
GROUP BY ShipCity
HAVING COUNT(CustomerID) > 10;

--19
SELECT DISTINCT c.ContactName
FROM Customers c JOIN Orders o ON c.CustomerID = o.CustomerID
WHERE o.OrderDate > '1998-01-01'


--20
SELECT c.ContactName, Max(o.Orderdate) AS RecentPurcharse
FROM Customers c JOIN Orders o ON c.CustomerID = o.CustomerID
GROUP BY c.ContactName


--21
SELECT c.ContactName, COUNT(od.Quantity) AS NumProduct
FROM Customers c JOIN Orders o ON c.CustomerID = o.CustomerID
JOIN [Order Details] AS od ON o.OrderID = od.OrderID
GROUP BY c.ContactName ORDER BY c.ContactName

--22
SELECT c.ContactName, COUNT(od.Quantity) AS NumProduct
FROM Customers c JOIN Orders o ON c.CustomerID = o.CustomerID
JOIN [Order Details] AS od ON o.OrderID = od.OrderID
GROUP BY c.ContactName 
HAVING COUNT(od.Quantity)>100
ORDER BY c.ContactName

--23
SELECT DISTINCT s.CompanyName AS [Supplier Company Name], sp.CompanyName AS [Shipping Company Name]
FROM Suppliers s JOIN Products p ON s.SupplierID = p.SupplierID
JOIN [Order Details] od ON p.ProductID = od.ProductID
JOIN Orders o ON od.OrderID = o.OrderID
JOIN Shippers sp ON o.ShipVia = sp.ShipperID

--24
SELECT o.OrderDate, p.ProductName
FROM Products p JOIN [Order Details] od ON p.ProductID = od.ProductID
JOIN Orders o ON od.OrderID = o.OrderID

--25
SELECT e1.LastName, e1.FirstName, e1.Title, e2.LastName, e2.FirstName, e1.Title
FROM Employees e1 INNER JOIN Employees e2 ON e2.Title = e1.Title
WHERE e1.EmployeeID <> e2.EmployeeID 

--26
SELECT M.FirstName AS ManagerFirstName, m.LastName AS ManagerLastName, COUNT(m.EmployeeID) AS ManageNum
FROM Employees e LEFT JOIN Employees m
ON e.ReportsTo = m.EmployeeID
GROUP BY m.FirstName, m.LastName 
HAVING COUNT(m.EmployeeID)>2

--27
SELECT c.ContactName, 'Customer' AS Type
FROM Customers c JOIN OrderS o ON c.CustomerID = o.CustomerID
JOIN [Order Details] od ON o.OrderID = od.OrderID
JOIN Products p ON od.ProductID = p.ProductID
JOIN Suppliers s ON p.SupplierID = s.SupplierID
WHERE c.City = s.City
UNION
SELECT s.ContactName, 'Supplier' AS Type
FROM Customers c JOIN OrderS o ON c.CustomerID = o.CustomerID
JOIN [Order Details] od ON o.OrderID = od.OrderID
JOIN Products p ON od.ProductID = p.ProductID
JOIN Suppliers s ON p.SupplierID = s.SupplierID
WHERE s.City = c.City;
--28
--SELECT * FROM T1 INNER JOIN T2 ON F1.T1 = F2.T2;
--RESULT:
--  2
--  3

--29
--SELECT * FROM T1 LEFT JOIN T2 ON F1.T1 = F2.T2;
--RESULT:
--  1
--  2
--  3