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

INSERT INTO Users (IdRole, UserNickName, UserPassword)
VALUES (2, 'trainer_user', 'trainer'); -- trainer tiene IdRole = 2

select * from Users


EXEC insert_trainer 'gonzoo','holaqueTal123',2,'Gonzalo','Bianchini'
EXEC insert_trainer 'trainer1','TrainerPass1',2,'Entrenador 1','Apellido 1'
EXEC insert_trainer 'trainer2','TrainerPass2',2,'Entrenador 2','Apellido 2'
EXEC insert_trainer 'trainer3','TrainerPass3',2,'Entrenador 3','Apellido 3'

EXEC insert_partner 'partner1','PartnerPass1',3,1,12345678,'John', 'Doe', 'Male','john.doe@example.com', '123456789', '1990-01-01', 1
EXEC insert_partner 'partner2','PartnerPass2',3,1,23456789, 'Jane', 'Doe', 'Female', 'jane.doe@example.com', '987654321', '1991-02-02', 2
EXEC insert_partner 'partner3','PartnerPass3',3,1,34567890, 'Alice', 'Smith', 'Female', 'alice.smith@example.com', '567890123', '1992-03-03', 3
EXEC insert_partner 'partner4','PartnerPass4',3,1,45678901, 'Bob', 'Brown', 'Male', 'bob.brown@example.com', '890123456', '1993-04-04', 4
EXEC insert_partner 'partner5','PartnerPass5',3,1,56789012, 'Charlie', 'Johnson', 'Male', 'charlie.johnson@example.com', '345678901', '1994-05-05', 5
EXEC insert_partner 'partner6','PartnerPass6',3,1,67890123, 'Eve', 'Davis', 'Female', 'eve.davis@example.com', '123890456', '1995-06-06', 6;




select * from Users
SELECT * from Trainers
SELECT * from Partners
SELECT * from PartnersByTrainer
SELECT * from Addresses
SELECT * FROM Provinces
SELECT * FROM Exercises
Select * from ROLES

-- DELETE  FROM Users