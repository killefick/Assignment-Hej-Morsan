USE Student13

SELECT
	*
FROM
	persons

DROP TABLE IF EXISTS Persons
GO

CREATE TABLE Persons
(
	Id             int         IDENTITY(1,1),
	Name           varchar(50),
	Phone          varchar(30) UNIQUE,
	Birthday       varchar(10),
	Counter        int,
	InitialCounter int
)
GO

-- insert sample data
CREATE OR ALTER PROCEDURE InitDB
AS
INSERT INTO Persons
	(Name, Phone, Birthday, Counter, InitialCounter)
VALUES
	('Mamma', '+46 70 5689 123', '1954-03-23', 3, 3)
INSERT INTO Persons
	(Name, Phone, Birthday, Counter, InitialCounter)
VALUES
	('Pappa', '+46 70 4455 543', '1944-06-13', 7, 7)
INSERT INTO Persons
	(Name, Phone, Birthday, Counter, InitialCounter)
VALUES
	('Mormor', '+46 70 1356 634', '1914-12-12', 15, 15)
INSERT INTO Persons
	(Name, Phone, Birthday, Counter, InitialCounter)
VALUES
	('Syrran', '+46 70 2366 154', '2008-11-11', 11, 11)
GO

USE Student13
EXEC InitDB
GO

-- Countdown 
CREATE OR ALTER PROCEDURE Day1
AS
UPDATE Persons
SET Counter = 3 WHERE Id = 1
UPDATE Persons
SET Counter = 1 WHERE Id = 2
UPDATE Persons
SET Counter = 0 WHERE Id = 3
UPDATE Persons
SET Counter = 11 WHERE Id = 4
GO

EXEC Day1
GO

-- Countdown 
CREATE OR ALTER PROCEDURE Day2
AS
UPDATE Persons
SET Counter = 2 WHERE Id = 1
UPDATE Persons
SET Counter = 0 WHERE Id = 2
UPDATE Persons
SET Counter = -1 WHERE Id = 3
UPDATE Persons
SET Counter = 10 WHERE Id = 4
GO

EXEC Day2
GO

-- AddPerson
CREATE OR ALTER PROCEDURE AddPerson
	@Name varchar(50),
	@Phone varchar(30),
	@Birthday varchar(10),
	@Counter int,
	@InitialCounter int
AS
INSERT INTO Persons
	(Name,
	Phone,
	Birthday,
	Counter,
	InitialCounter)
VALUES
	(
		@Name,
		@Phone,
		@Birthday,
		@Counter,
		@Counter
)
GO

SELECT
	*
FROM
	persons

EXEC AddPerson 'Pelle', '073-123456', '2019-08-09', 5, 5
GO


-- DeletePerson (lägg index på name!)
CREATE OR ALTER  PROCEDURE DeletePerson
	@Id int
AS
DELETE
FROM Persons
WHERE Id = @Id
GO

EXEC DeletePerson 5
GO


-- UpdateCounter
CREATE OR ALTER PROCEDURE UpdateCounter
	@Id int,
	@InitialCounter int
AS
UPDATE Persons
SET Counter = @InitialCounter
WHERE Id = @Id
GO

EXEC UpdateCounter 1, 8
GO


-- UpdatePerson
CREATE OR ALTER PROCEDURE UpdatePerson
	@Id int,
	@Name varchar(50),
	@Phone varchar(20),
	@Birthday varchar(10),
	@Counter int,
	@InitialCounter int
AS
UPDATE Persons
SET Name = @Name,
	Phone = @Phone, 
	Birthday = @Birthday,
	Counter = @Counter,
	InitialCounter = @Counter
WHERE Id = @Id
GO

EXEC UpdatePerson 7, 'Lasse', '073-123 47 56', '1976-09-28', 6 ,6
GO


-- GetPersons
CREATE OR ALTER PROCEDURE GetPersons
AS
SELECT
	Id,
	Name,
	Phone,
	Birthday,
	Counter,
	InitialCounter
FROM
	Persons
GO