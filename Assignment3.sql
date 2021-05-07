/**
Assignment 3
Zihao Shao
**/

--1
--I prefer use joins when working on a big data set, since the execution of joins is faster than subqueries. 
--However, subqueries is easy to undersand and code maintenance is also at ease. In some cases,
--subqueries can replace complex joins and unions.

--2
--CTE stands for common table expression, is the result set of a query which exists temporarily and for use only
--within the context of a large query. It can be used to:
--create a recursive query
--substitute for a view when the general use of a view is not required.
--improve redability and ease in maintenance of complex queires. 

--3
--The table variable is a special type of the local variable that helps to store data temporarily similar to a temporary table.
--The table variable scope is within the batch. We can define a table variable inside a stored procedure and functions as well.
--In this case, the tale variable scope in within the stored procedure and function.
--Table variable is stored in the tempdb system databse.

--4
--DELETE is used to delete specific data, and TRUNCATE is used to delete the entire data of the table.
--DELETE can be used with WHERE clause but TRUNCATE cannot.
--DELETE locks the table row before deleting the row, and TRUNCATE locks the entire table
--DELETE can rollback the changes, but TRUNCATE cannot.
--DELETE is slower than TRUNCATE.

--5
--Identity column is a special type of column that is used to automatically generate key values based on a provied seed and increment.
--DELETE retains the identity and does not reset it to the seed value. TRUNCATE resets the identity to its seed value.

--6
--DELETE FROM table_name is used to delete all records from table_name.
--TRUNCATE table table_name is used to delete records from table_name without removing table structure, it doesn't use WHERE clause. 


--1
SELECT c.City
FROM Customers c 
WHERE EXISTS (SELECT 1 FROM Employees e WHERE c.city = e.city)
UNION
SELECT e.City
FROM Employees e
WHERE EXISTS (SELECT 1 FROM Customers c WHERE c.city = e.city)

--2
--a
SELECT c.City 
FROM Customers c 
WHERE NOT EXISTS (SELECT 1 FROM Employees e WHERE c.city = e.city)
ORDER BY c.City;

--b
SELECT DISTINCT c.City
FROM Customers c LEFT JOIN Orders o ON c.CustomerID = o.CustomerID
INNER JOIN Employees e ON o.EmployeeID = e.EmployeeID
WHERE c.City <> e.City
ORDER BY c.City;

--3
WITH productCTE
AS
(
SELECT p.ProductName, COUNT(od.Quantity) AS 'Total Order Quantities' FROM [Order Details] od 
FULL JOIN Products p ON p.ProductID = od.ProductID
GROUP BY p.ProductName
)
SELECT * FROM productCTE

--4
SELECT c.City, COUNT(od.Quantity) AS 'Total Ordered'
FROM Customers c LEFT JOIN Orders o ON c.CustomerID = o.CustomerID
RIGHT JOIN [Order Details] od ON o.OrderID = od.OrderID
GROUP BY c.City
ORDER BY COUNT(od.Quantity) DESC

--5
--a
SELECT c.City, COUNT(c.CustomerID) AS NumCus FROM Customers c
GROUP BY c.City
HAVING COUNT(c.CustomerID) >= 2
UNION
SELECT s.City, COUNT(s.CustomerID) AS NumCus FROM Customers s
GROUP BY s.City
HAVING COUNT(s.CustomerID) >= 2;
--b
SELECT DISTINCT City FROM Customers WHERE City NOT IN 
(SELECT City FROM Customers 
	GROUP BY City
	HAVING COUNT(CustomerID) <2 )
ORDER BY City;

--6
SELECT DISTINCT c.City
FROM Customers c FULL JOIN Orders o ON c.CustomerID = o.CustomerID
FULL JOIN [Order Details] od ON o.OrderID = od.OrderID
FULL JOIN Products p ON od.ProductID = p.ProductID
INNER JOIN Products r ON p.ProductName <> r.ProductName
GROUP BY City
HAVING COUNT(o.OrderID)>=2

--7
SELECT DISTINCT c.ContactName, c.City, o.ShipCity
FROM Customers c FULL JOIN Orders o ON c.CustomerID = o.CustomerID
WHERE c.City <> o.ShipCity;

--8
SELECT TOP 5 p.ProductName, AVG(od.unitPrice) AS AvgPrice, SUM(od.Quantity) AS TotalQuantity, c.City
FROM Customers c FULL JOIN Orders o ON c.CustomerID = o.CustomerID
FULL JOIN [Order Details] od ON o.OrderID = od.OrderID
FULL JOIN Products p ON od.ProductID = p.ProductID
GROUP BY p.ProductName, c.City
ORDER BY TotalQuantity DESC

--9
--a
SELECT DISTINCT o.ShipCity
FROM Orders o WHERE o.ShipCity IN 
(SELECT e.City 
	FROM Employees e
	GROUP BY e.city
	HAVING COUNT(e.EmployeeID) > 0)
GROUP BY o.ShipCity
HAVING COUNT(o.OrderID) = 0 

--b
SELECT DISTINCT o.ShipCity
FROM Orders o FULL JOIN Employees e ON o.EmployeeID = e.EmployeeID
GROUP BY o.ShipCity
HAVING COUNT(e.EmployeeID)>0 AND COUNT(o.OrderID) = 0 

--10
SELECT DISTINCT e.City
FROM Employees e FULL JOIN Orders o ON e.EmployeeID = o.EmployeeID 
WHERE e.City IN 
(SELECT o.ShipCity
FROM Orders r FULL JOIN [Order Details] od ON r.OrderID = od.OrderID 
WHERE o.shipCity IN 
(SELECT TOP 1 shipCity FROM [Order Details] 
GROUP BY COUNT(Quantity))
)

--11
--using cte and DELETE
WITH cte AS (
SELECT 
columnNames1,
columnNames2,
columnNames3,
columnNames4

ROW_NUMBER() OVER (
	PARTITION BY
		columnNames2,
		columnNames3,
		columnNames4
	ORDER BY
		columnNames2,
		columnNames3,
		columnNames4
) row_num
FROM 
	tableName
)

DELETE FROM cte
WHERE row_num>1

--12
SELECT * FROM (SELECT * FROM Employee) AS T1
INNER JOIN 
(SELECT mgrid, COUNT(mgrid) AS Subordinate) FROM Employee
WHERE mgrid IS NOT NULL
GROUP BY mgrid
HAVING COUNT(mgrid) = 0) T2
ON T2.mgrid = T1.empid;

--13
with deps as
 (select dep.department_name as dep_name, count(emp.employee_id) as cnt
    from departments dep
   inner join employees emp
      on emp.department_id = dep.department_id
   group by dep.department_name)
select deps.dep_name,cnt from deps 
where cnt=(select max(cnt) from deps)

--14
SELECT
    dpt.Name AS Department,
    e1.Name AS Employee,
    e1.Salary AS Salary
FROM Employee AS e1
INNER JOIN Department dpt
ON e1.DepartmentID = dpt.Id
WHERE 3 > (
           SELECT COUNT(DISTINCT Salary)
           FROM Employee AS e2
           WHERE e2.Salary > e1.Salary
           AND e1.DepartmentID = e2.DepartmentID
          )
ORDER BY
Department ASC,
Salary DESC;
































