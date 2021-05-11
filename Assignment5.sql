/**
Assignment 5
Zihao Shao
**/

/**
1
A database object is any defined object in a database that is used to store or reference data. 
Some examples of database objects include tables, views, clusters, sequences, indexes, and synonyms. 

2
An index is associated with tables or table cluster that can speed data access and reducing disk I/O

Advantages
Speed up SELECT query
Helps to make a row unique or without duplicates(primary,unique) 
If index is set to fill-text index, then we can search against large string values. 

Disadvantages
Indexes take additional disk space.
indexes slow down INSERT,UPDATE and DELETE, but will speed up UPDATE if the WHERE condition has an indexed field.  
INSERT, UPDATE and DELETE becomes slower because on each operation the indexes must also be updated. 


3 
Clustered Index, Non-Clustered Index, Unique Index, Filtered Index, Columnstore Index, Hash Index


4
The clustered index is automatically created with a primary key
The un-clustered index is automatically  created with a unique key.

5
No, there can be only one clustered index per table.
Because the data rows themselves can be stored in only one order.
The only time the data rows in a table are stored in sorted order in when the table contains a clustered index.

6.
Yes, you can create an unclustered index on multiple columns and gain a nice performance increase
Yes, the order of the columns matters when it comes to improving performance of queries in your sql server.


7.
A unique clustered index can be created on the view, where the result set of that view will be stored in your database
the same as a real table with a unique clustered index.

8.
Database Normalization is a process of organizating data to minimize redundancy(data duplication), 
which in turn ensures data consistency.
First Normal Form, Second Normal Form, Third Normal Form

9
Denormalization is used to combine multiple table data into one so that it can be queried quickly
In a traditional normalized database, we store data in separate logical tables and attempt to minimize redundant data. 
We may strive to have only one copy of each piece of data in database. 

10.
Data Integrity is used to maintain accuracy and consistency of data in a table.
We can implement this using constraints. This is divided into three categories.

Entity integrity: Entity integrity ensures each row in a table is a uniquely identifiable entity. 
We can apply Entity integrity to the Table by specifying a primary key, unique key, and not null.

Referential Integrity
Referential integrity ensures the relationship between the Tables.
We can apply this using a Foreign Key constraint.

Domain Integrity
Domain integrity ensures the data values in a database follow defined rules for values, range, and format. 
A database can enforce these rules using Check and Default constraints.

11.
Types of Constraints:
1. NOT NULL, 2. Unique, 3. Primary key, 4.Foreign key, 5. Check Constraints

12.
Primary Key:
1.Unique identifier for rows of a table
2.Cannot be NULL
3.Only one primary key per table
4.Selection using primary key creates clustered index.
Unique key:
1.Unique identifier for rows of a table when primary key is not present
2.Can be NULL
3.Multiple Unique key can be present in a table
4.Selection using unique key creates non-clustered index

13.
A foreign key is a column or combination of columns that is used to establish
and enforce a link between the data in two tables. You can create a foreign key
by defining a FOREIGN KEY constraint when you create or modify a table.

14.
Yes, a table may have multiple foreign keys, and each foreign key can have a different
parent table.

15.
No, foreign key in a table doesn't have to be unique
Yes. foreign key can be null.

16.
Yes, creating an index on a table variable can be done implicitly within the declaration
of the table variable by defining a primary key and creating unique constraints.
Yes, you can create indexes on temporary tables.

17.
A transaction is the logical work unit that performs a single activity or multiple actitivies in a databases.
4 level of isolation for transcations:
Read Uncommitted(loweset level)
Read committed
Repeatable read
Serializable(Highest Level)


**/
--1
SELECT c.iname, SUM(o.order_id)
FROM Customer c INNER JOIN Order o  ON c.cust_id = o.cust_id 
WHERE year(o.order_date) = 2002
GROUP BY c.iname;

--2
SELECT id, firstname, lastname
FROM person WHERE lastname LIKE 'A&';

--3
SELECT p2.name as Manager, count(p1.person_id) AS NumberOfReportedFrom
FROM person p1 INNER JOIN person p2 ON p1.manager_id = p2.person_id;

--4

--DML statements (INSERT, UPDATE, DELETE) on a particular table or view, issued by any user

--DDL statements (CREATE or ALTER primarily) issued either by a particular schema/user or by any schema/user in the database

--Database events, such as logon/logoff, errors, or startup/shutdown, also issued either by a particular schema/user or by any schema/user in the database

--5
CREATE TABLE Company(
	CompanyId int primary key,
	CompanyName varchar(20) unique,
	DivisionId int foreign key references Divisions(DivisionID),
	PhysicalAddressId int foreign key references PhysicalAddress(PhysicalAddressID)
	)

CREATE TABLE Divisions(
	DivisionId int primary key,
	DivisionName varchar(20),
    PhysicalAddressId int foreign key references PhysicalAddress(PhysicalAddressID)

)

CREATE TABLE PhysicalAddress(
	PhysicalAddressID int primary key,
	PhysicalAddressDescription varchar(50)
)

CREATE TABLE Contact(
	ContactID int primary key,
	Telephone int unique,
	DivisionID int foreign key references Divisions(DivisionId),
	PhysicalAddressID int foreign key references PhysicalAddress(PhysicalAddressID),
	recordsStatus varchar(10)
)