use ENTRENAR_DB
go

INSERT INTO Addresses (StreetName, StreetNumber, Flat, Details, City, Province, Country)
VALUES 
('Av. Corrientes', '1234', '8A', 'Frente al Obelisco', 'Buenos Aires', 'CABA', 'Argentina'),
('San Martín', '567', NULL, NULL, 'Rosario', 'Santa Fe', 'Argentina'),
('9 de Julio', '789', '3B', 'Edificio con portero', 'Córdoba', 'Córdoba', 'Argentina'),
('Mitre', '456', NULL, NULL, 'Mendoza', 'Mendoza', 'Argentina'),
('Sarmiento', '321', '1C', NULL, 'La Plata', 'Buenos Aires', 'Argentina'),
('San Juan', '101', NULL, 'Cerca del parque principal', 'San Juan', 'San Juan', 'Argentina'),
('Rivadavia', '2020', '2A', 'Edificio con ascensor', 'San Luis', 'San Luis', 'Argentina'),
('Alem', '555', NULL, NULL, 'Mar del Plata', 'Buenos Aires', 'Argentina'),
('Urquiza', '777', '5C', 'Edificio moderno', 'Tucumán', 'Tucumán', 'Argentina'),
('Entre Ríos', '888', NULL, 'Frente a la plaza central', 'Paraná', 'Entre Ríos', 'Argentina'),
('Mitre', '123', '3A', 'Cerca de la estación de tren', 'Neuquén', 'Neuquén', 'Argentina'),
('Alsina', '444', '1B', NULL, 'Bahía Blanca', 'Buenos Aires', 'Argentina'),
('Castelli', '333', NULL, 'Barrio tranquilo', 'Resistencia', 'Chaco', 'Argentina'),
('San Martín', '909', NULL, 'Casa de esquina', 'Posadas', 'Misiones', 'Argentina'),
('Belgrano', '2222', '6D', 'Vista panorámica', 'Bariloche', 'Río Negro', 'Argentina'),
('Belgrano', '654', NULL, 'Casa esquinera', 'Salta', 'Salta', 'Argentina');

-- Crear los usuarios
INSERT INTO Users (IdAddress,FirstName, LastName, BirthDate, Dni, Phone, Email, ActiveStatus, UserNickName, UserPassword, IdRole)
VALUES 
(1,'Admin', 'Main', '1980-01-01', 10000001, '123456789', 'admin@entrenar.com', 1, 'admin', 'admin123', 1), -- Admin
(2,'Trainer1', 'Coach', '1985-02-01', 10000002, '123456780', 'trainer1@entrenar.com', 1, 'trainer1', 'trainer123', 2), -- Trainer 1
(3,'Trainer2', 'Coach', '1986-03-01', 10000003, '123456781', 'trainer2@entrenar.com', 1, 'trainer2', 'trainer123', 2), -- Trainer 2
(4,'Trainer3', 'Coach', '1987-04-01', 10000004, '123456782', 'trainer3@entrenar.com', 1, 'trainer3', 'trainer123', 2), -- Trainer 3
(5,'Client1', 'User', '1990-01-01', 10000005, '123456783', 'client1@entrenar.com', 1, 'client1', 'client123', 3), -- Client 1
(6,'Client2', 'User', '1991-02-01', 10000006, '123456784', 'client2@entrenar.com', 1, 'client2', 'client123', 3), -- Client 2
(7,'Client3', 'User', '1992-03-01', 10000007, '123456785', 'client3@entrenar.com', 1, 'client3', 'client123', 3), -- Client 3
(8,'Client4', 'User', '1993-04-01', 10000008, '123456786', 'client4@entrenar.com', 1, 'client4', 'client123', 3), -- Client 4
(9,'Client5', 'User', '1994-05-01', 10000009, '123456787', 'client5@entrenar.com', 1, 'client5', 'client123', 3), -- Client 5
(10,'Client6', 'User', '1995-06-01', 10000010, '123456788', 'client6@entrenar.com', 1, 'client6', 'client123', 3), -- Client 6
(11,'Client7', 'User', '1996-07-01', 10000011, '123456789', 'client7@entrenar.com', 1, 'client7', 'client123', 3), -- Client 7
(12,'Client8', 'User', '1997-08-01', 10000012, '123456790', 'client8@entrenar.com', 1, 'client8', 'client123', 3); -- Client 8

-- Asignar los entrenadores a la tabla Trainers
INSERT INTO Trainers (IdUser)
VALUES 
(2), -- Trainer 1
(3), -- Trainer 2
(4); -- Trainer 3

-- Asignar los clientes a la tabla Clients con el estado correspondiente
INSERT INTO Partners (IdUser, IdStatus)
VALUES 
(5, 3), -- Cliente 1 asignado (Assigned)
(6, 3), -- Cliente 2 asignado (Assigned)
(7, 3), -- Cliente 3 asignado (Assigned)
(8, 3), -- Cliente 4 asignado (Assigned)
(9, 3), -- Cliente 5 asignado (Assigned)
(10, 1), -- Cliente 6 disponible (Available)
(11, 1), -- Cliente 7 disponible (Available)
(12, 1); -- Cliente 8 disponible (Available)

-- Asociar clientes con entrenadores en ClientsByTrainer
INSERT INTO PartnersByTrainer (IdTrainer, IdPartner)
VALUES 
(1, 1), -- Cliente 1 con Entrenador 1
(1, 2), -- Cliente 2 con Entrenador 1
(1, 3), -- Cliente 3 con Entrenador 1
(2, 4), -- Cliente 4 con Entrenador 2
(2, 5); -- Cliente 5 con Entrenador 2;




select * from Users
SELECT * from Trainers
SELECT * from Partners
select * from Exercises Where IsActive=1
SELECT * from PartnersByTrainer
SELECT * from Addresses


INSERT INTO Users (FirstName, LastName, BirthDate, Dni, Phone, Email, UserNickName, UserPassword)
VALUES 
('Lalo', 'Landa', '1988-11-02', 33956474, '1134385063', 'lalo@entrenar.com', 'lalo22', 'blabla1')


select * from Users U 
left join Partners P
ON P.IdUser = U.IdUser
where U.IdRole = 3 and U.IsActive = 1 

