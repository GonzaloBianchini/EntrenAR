
use ENTRENAR_DB
GO

--DROP PROCEDURE insert_user

CREATE PROCEDURE insert_user
    @Username VARCHAR(50), -- Nombre de usuario
    @UserPassword VARCHAR(50), -- Contraseña del usuario
    @IdRole INT --Role

AS
BEGIN
    -- Inserta el nuevo usuario
    INSERT INTO Users (UserNickName, UserPassword,IdRole)
    VALUES (@Username, @UserPassword,@IdRole);

    -- Recupera el ID generado y lo asigna al parámetro de salida
    -- SET @LastId = SCOPE_IDENTITY();
    SELECT SCOPE_IDENTITY() AS LastId
END;
GO

-- DECLARE @elultimo INT;

-- EXEC insert_user 'user12','aasdeg',3;

-- select @elultimo

-- select * from Users
-- select * from Addresses
-- select * from Users Where IdUser=15
-- select * from Roles where IdRole=3

-- DROP PROCEDURE insert_partner

-- CREATE PROCEDURE insert_partner
--     @Username VARCHAR(50), -- Nombre de usuario
--     @UserPassword VARCHAR(50), -- Contraseña del usuario
--     @IdRole INT, -- Rol del usuario (probablemente 3 para Partner)
--     @IdStatus INT, -- Estado inicial del socio
--     @Dni INT, -- DNI del socio
--     @FirstName VARCHAR(50), -- Nombre del socio
--     @LastName VARCHAR(50), -- Apellido del socio
--     @Gender VARCHAR(50) NULL, -- Género del socio
--     @Email VARCHAR(50) NULL, -- Email del socio
--     @Phone VARCHAR(50), -- Teléfono del socio
--     @BirthDate DATE, -- Fecha de nacimiento del socio
--     @IdAddress INT -- ID de la dirección del socio
-- AS
-- BEGIN
--     -- Inicia una transacción
--     BEGIN TRANSACTION;

--     BEGIN TRY
--         DECLARE @NewUserId INT;

--         -- Llama al SP insert_user para crear el usuario
--         EXEC insert_user @Username, @UserPassword, @IdRole;

--         -- Recupera el ID generado por el usuario
--         SELECT @NewUserId = SCOPE_IDENTITY();

--         -- Inserta el socio en la tabla Partners
--         INSERT INTO Partners (
--             IdUser,
--             IdStatus,
--             ActiveStatus,
--             Dni,
--             FirstName,
--             LastName,
--             Gender,
--             Email,
--             Phone,
--             BirthDate,
--             IdAddress
--         )
--         VALUES (
--             @NewUserId,
--             @IdStatus,
--             1, -- Socio activo por defecto
--             @Dni,
--             @FirstName,
--             @LastName,
--             @Gender,
--             @Email,
--             @Phone,
--             @BirthDate,
--             @IdAddress
--         );

--         -- Confirma la transacción
--         COMMIT TRANSACTION;
--     END TRY
--     BEGIN CATCH
--         -- Si hay un error, revierte la transacción
--         ROLLBACK TRANSACTION;
--         THROW;
--     END CATCH;
-- END;
-- GO

-- DROP PROCEDURE insert_user_alternative




-- EXEC insert_partner 'gonzoofonzoo','Hola123',2,1,'33956434','Andres','Bianchinosky','Masculino','andres3.b@gmail.com','47459806','1989-01-15',1;



-- select * from Users
-- select * from Partners

-- REVISAR LOS IDS GENERADOS EN USERS!!!!!
DROP PROCEDURE insert_partner

CREATE PROCEDURE insert_partner
    @Username VARCHAR(50),
    @UserPassword VARCHAR(50),
    @IdRole INT,
    @IdStatus INT,
    @Dni INT,
    @FirstName VARCHAR(50),
    @LastName VARCHAR(50),
    @Gender VARCHAR(50) NULL,
    @Email VARCHAR(50) NULL,
    @Phone VARCHAR(50),
    @BirthDate DATE,
    @IdAddress INT
AS
BEGIN
    -- Comienza una transacción explícita
    BEGIN TRANSACTION;

    BEGIN TRY
        -- Declaramos variable para capturar el ID del usuario
        DECLARE @NewUserId INT;

        -- Llama al procedimiento insert_user para crear el usuario
        INSERT INTO Users (UserNickName, UserPassword, IdRole)
        VALUES (@Username, @UserPassword, @IdRole);

        -- Recupera el ID del usuario creado
        SET @NewUserId = SCOPE_IDENTITY();

        -- Inserta el nuevo Partner usando el ID del usuario creado
        INSERT INTO Partners (
            IdUser,
            IdStatus,
            ActiveStatus,
            Dni,
            FirstName,
            LastName,
            Gender,
            Email,
            Phone,
            BirthDate,
            IdAddress
        )
        VALUES (
            @NewUserId,
            @IdStatus,
            1, -- ActiveStatus por defecto
            @Dni,
            @FirstName,
            @LastName,
            @Gender,
            @Email,
            @Phone,
            @BirthDate,
            @IdAddress
        );
        SELECT SCOPE_IDENTITY() AS LastId
        -- Si ambas operaciones fueron exitosas, confirma la transacción
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        -- Si ocurre un error, revierte la transacción
        ROLLBACK TRANSACTION;
        THROW; -- Lanza el error para depuración
    END CATCH;
END;
GO


EXEC insert_partner 'gonzfonz','Hola123',2,1,'33956402','Andres','Bianchinosky','Masculino','andres6.b@gmail.com','47459806','1989-01-15',1;

-- select * from Users
-- select * from Partners



