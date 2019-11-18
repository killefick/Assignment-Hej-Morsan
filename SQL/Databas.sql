USE Student13

select * from persons

DROP TABLE IF EXISTS Persons
GO

CREATE TABLE Persons
(
	Id       int         IDENTITY(1,1),
	Name     varchar(50) NOT NULL,
	Phone    varchar(20) NOT NULL,
	Birthday varchar(10),
	Counter  int         NOT NULL
)
GO

-- insert sample data
INSERT INTO Persons
	(Name, Phone, Birthday, Counter)
VALUES
	('Mamma', '076-234 22 24', '1954-03-23', 4)
INSERT INTO Persons
	(Name, Phone, Birthday, Counter)
VALUES
	('Pappa', '072-234 24 24', '1944-06-13', 2)
INSERT INTO Persons
	(Name, Phone, Birthday, Counter)
VALUES
	('Mormor', '076-224 12 24', '1914-12-12', 8)
INSERT INTO Persons
	(Name, Phone, Birthday, Counter)
VALUES
	('Syrran', '077-277 77 24', '2008-11-11', 12)
GO
INSERT INTO Persons
	(Name, Phone, Birthday, Counter)
VALUES
	('Olle', '077-277 77 24', '2008-11-11', -1)
GO
INSERT INTO Persons
	(Name, Phone, Birthday, Counter)
VALUES
	('Lasse', '077-277 77 24', '2008-11-11', 1)
GO


-- AddPerson
CREATE OR ALTER PROCEDURE AddPerson
	@Name varchar(50),
	@Phone varchar(20),
	@Birthday varchar(10),
	@Counter int = NULL
AS
INSERT INTO Persons
	(Name,
	Phone,
	Birthday,
	Counter)
VALUES
	(
		@Name,
		@Phone,
		@Birthday,
		@Counter
)
GO

SELECT
	*
FROM
	persons
GO
EXEC AddPerson 'Pelle', '073-123456', '2019-08-09', 5
GO

-- DeletePerson (lägg index på name!)
CREATE OR ALTER  PROCEDURE DeletePerson
	@Id int
AS
DELETE
FROM Persons
WHERE Id = @Id
GO

EXEC DeletePerson 4
GO


-- UpdatePerson
CREATE OR ALTER PROCEDURE UpdatePerson
	@Id int,
	@Name varchar(50),
	@Phone varchar(20),
	@Birthday varchar(10),
	@Counter int
AS
UPDATE Persons
SET Name = @Name,
	Phone = @Phone, 
	Birthday = @Birthday,
	Counter = @Counter
WHERE Id = @Id
GO


-- GetPersons
CREATE OR ALTER PROCEDURE GetPersons
AS
SELECT
	Id,
	Name,
	Phone,
	Birthday,
	Counter
FROM
	Persons
GO