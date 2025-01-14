use ENTRENAR_DB
go

INSERT INTO Addresses (IdProvince, StreetName, StreetNumber, Flat, Details, City, Country)
VALUES
(1, 'Av. Corrientes', '1234', '8A', 'Frente al Obelisco', 'Buenos Aires', 'Argentina'),
(5, 'San Martín', '567', NULL, NULL, 'Córdoba', 'Argentina'),
(7, '9 de Julio', '789', '3B', 'Edificio con portero', 'Paraná', 'Argentina'),
(2, 'Mitre', '456', NULL, NULL, 'San Fernando del Valle de Catamarca', 'Argentina'),
(3, 'Belgrano', '321', '1C', NULL, 'Resistencia', 'Argentina'),
(4, 'Rivadavia', '654', NULL, 'Casa esquinera', 'Trelew', 'Argentina'),
(6, 'Sarmiento', '111', '2A', 'Cerca del río', 'Corrientes', 'Argentina'),
(8, 'España', '222', '4B', NULL, 'Formosa', 'Argentina'),
(9, 'Italia', '333', NULL, 'Barrio central', 'San Salvador de Jujuy', 'Argentina'),
(10, 'San Lorenzo', '444', NULL, NULL, 'Santa Rosa', 'Argentina'),
(11, 'Colón', '555', '5D', 'Zona histórica', 'La Rioja', 'Argentina'),
(12, 'Alsina', '666', NULL, 'Barrio residencial', 'Mendoza', 'Argentina'),
(13, 'Francia', '777', NULL, NULL, 'Posadas', 'Argentina'),
(14, 'Bolívar', '888', '6E', 'Vista al río', 'Barrio Norte', 'Argentina'),
(15, 'Castelli', '999', NULL, 'Cerca del puerto', 'Viedma', 'Argentina'),
(16, 'Perú', '1010', NULL, NULL, 'Salta', 'Argentina');


-- Insertar Admin
INSERT INTO Users (IdRole, UserNickName, UserPassword)
VALUES (1, 'admin_user', 'AdminPass'); -- Admin tiene IdRole = 1

-- Insertar Trainers
INSERT INTO Users (IdRole, UserNickName, UserPassword)
VALUES 
(2, 'trainer1', 'TrainerPass1'),
(2, 'trainer2', 'TrainerPass2'),
(2, 'trainer3', 'TrainerPass3'); -- Trainers tienen IdRole = 2

-- Insertar Partners
INSERT INTO Users (IdRole, UserNickName, UserPassword)
VALUES 
(3, 'partner1', 'PartnerPass1'),
(3, 'partner2', 'PartnerPass2'),
(3, 'partner3', 'PartnerPass3'),
(3, 'partner4', 'PartnerPass4'),
(3, 'partner5', 'PartnerPass5'),
(3, 'partner6', 'PartnerPass6'); -- Partners tienen IdRole = 3

-- Insertar Trainers en la tabla Trainers
INSERT INTO Trainers (IdUser)
VALUES 
((SELECT IdUser FROM Users WHERE UserNickName = 'trainer1')),
((SELECT IdUser FROM Users WHERE UserNickName = 'trainer2')),
((SELECT IdUser FROM Users WHERE UserNickName = 'trainer3'));


-- Insertar Partners en la tabla Partners
INSERT INTO Partners (IdUser, IdStatus, Dni, FirstName, LastName, Gender, Email, Phone, BirthDate, IdAddress)
VALUES
((SELECT IdUser FROM Users WHERE UserNickName = 'partner1'), 3, 12345678, 'John', 'Doe', 'Male', 'john.doe@example.com', '123456789', '1990-01-01', 1),
((SELECT IdUser FROM Users WHERE UserNickName = 'partner2'), 3, 23456789, 'Jane', 'Doe', 'Female', 'jane.doe@example.com', '987654321', '1991-02-02', 2),
((SELECT IdUser FROM Users WHERE UserNickName = 'partner3'), 3, 34567890, 'Alice', 'Smith', 'Female', 'alice.smith@example.com', '567890123', '1992-03-03', 3),
((SELECT IdUser FROM Users WHERE UserNickName = 'partner4'), 3, 45678901, 'Bob', 'Brown', 'Male', 'bob.brown@example.com', '890123456', '1993-04-04', 4),
((SELECT IdUser FROM Users WHERE UserNickName = 'partner5'), 3, 56789012, 'Charlie', 'Johnson', 'Male', 'charlie.johnson@example.com', '345678901', '1994-05-05', 5),
((SELECT IdUser FROM Users WHERE UserNickName = 'partner6'), 1, 67890123, 'Eve', 'Davis', 'Female', 'eve.davis@example.com', '123890456', '1995-06-06', 6);

-- Asociar Partners con Trainers
INSERT INTO PartnersByTrainer (IdTrainer, IdPartner)
VALUES
((SELECT IdTrainer FROM Trainers WHERE IdUser = (SELECT IdUser FROM Users WHERE UserNickName = 'trainer1')),
 (SELECT IdPartner FROM Partners WHERE IdUser = (SELECT IdUser FROM Users WHERE UserNickName = 'partner1'))),
((SELECT IdTrainer FROM Trainers WHERE IdUser = (SELECT IdUser FROM Users WHERE UserNickName = 'trainer1')),
 (SELECT IdPartner FROM Partners WHERE IdUser = (SELECT IdUser FROM Users WHERE UserNickName = 'partner2'))),
((SELECT IdTrainer FROM Trainers WHERE IdUser = (SELECT IdUser FROM Users WHERE UserNickName = 'trainer2')),
 (SELECT IdPartner FROM Partners WHERE IdUser = (SELECT IdUser FROM Users WHERE UserNickName = 'partner3'))),
((SELECT IdTrainer FROM Trainers WHERE IdUser = (SELECT IdUser FROM Users WHERE UserNickName = 'trainer2')),
 (SELECT IdPartner FROM Partners WHERE IdUser = (SELECT IdUser FROM Users WHERE UserNickName = 'partner4'))),
((SELECT IdTrainer FROM Trainers WHERE IdUser = (SELECT IdUser FROM Users WHERE UserNickName = 'trainer2')),
 (SELECT IdPartner FROM Partners WHERE IdUser = (SELECT IdUser FROM Users WHERE UserNickName = 'partner5')));



select * from Users
SELECT * from Trainers
SELECT * from Partners
SELECT * from PartnersByTrainer
SELECT * from Addresses
SELECT * FROM Provinces
SELECT * FROM Exercises
Select * from ROLES


