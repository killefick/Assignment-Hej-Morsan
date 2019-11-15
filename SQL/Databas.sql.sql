DROP TABLE IF EXISTS Persons
GO

CREATE TABLE Persons
	(
	Id int identity(1,1),
    Name varchar(50) NOT NULL,
    Phone varchar(20) NOT NULL,
    Birthday varchar(10),
	Counter int NOT NULL
	)
GO

	-- insert sample data
insert into Persons
(Name, Phone, Birthday, Counter)
values ('Mamma', '076-234 22 24', '1954-03-23', 4)
insert into Persons
(Name, Phone, Birthday, Counter)
values ('Pappa', '072-234 24 24', '1944-06-13', 2)
insert into Persons
(Name, Phone, Birthday, Counter)
values ('Mormor', '076-224 12 24', '1914-12-12', 8)
insert into Persons
(Name, Phone, Birthday, Counter)
values ('Syrran', '077-277 77 24', '2008-11-11', 12)
GO


-- AddPerson
DROP PROCEDURE IF EXISTS AddPerson
GO
CREATE PROCEDURE AddPerson 
@Name varchar(50),
@Phone varchar(20), 
@Birthday varchar(10),
@Counter int = NULL
AS
INSERT INTO Persons (Name, Phone, Birthday, Counter)
VALUES (@Name, @Phone, @Birthday, @Counter
)
GO

exec AddPerson 'Pelle', '073-123456', '2019-08-09', 5 


-- DeletePerson
DROP PROCEDURE IF EXISTS DeletePerson
GO
CREATE PROCEDURE DeletePerson 
@Name varchar(50)
AS
DELETE
FROM Persons
WHERE Name = @Name
GO

exec DeletePerson 'Pelle'


-- UpdatePerson
DROP PROCEDURE IF EXISTS UpdatePerson
GO
CREATE PROCEDURE UpdatePerson 
@PersonToChange varchar(50),
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
WHERE Name = @PersonToChange
GO

exec UpdatePerson 'Syrran','Pelle','077-277 77 24', '2008-11-11', 12
select * from persons