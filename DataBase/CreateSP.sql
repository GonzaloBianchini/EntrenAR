
use ENTRENAR_DB
GO

CREATE OR ALTER PROCEDURE insert_user
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


CREATE OR ALTER PROCEDURE insert_partner
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

CREATE OR ALTER PROCEDURE insert_trainer
    @Username VARCHAR(50),
    @UserPassword VARCHAR(50),
    @IdRole INT,
    @FirstName VARCHAR(50),
    @LastName VARCHAR(50)
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
        INSERT INTO Trainers (IdUser, FirstName, LastName)
        VALUES (@NewUserId,@FirstName,@LastName);

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


CREATE OR ALTER PROCEDURE insert_address
    @IdProvince INT, -- ID de la provincia
    @StreetName VARCHAR(50), -- Nombre de la calle
    @StreetNumber VARCHAR(50), -- Número de la calle
    @Flat VARCHAR(50) = NULL, -- Departamento (opcional)
    @Details VARCHAR(50) = NULL, -- Detalles adicionales (opcional)
    @City VARCHAR(50), -- Ciudad
    @Country VARCHAR(50) -- País
AS
BEGIN
    -- Inserta una nueva dirección
    INSERT INTO Addresses (IdProvince, StreetName, StreetNumber, Flat, Details, City, Country)
    VALUES (@IdProvince, @StreetName, @StreetNumber, @Flat, @Details, @City, @Country);

    -- Recupera el ID generado y lo devuelve
    SELECT SCOPE_IDENTITY() AS LastId;
END;
GO


CREATE OR ALTER PROCEDURE insert_training
    @IdPartner INT,
    @TrainingName VARCHAR(50), 
    @TrainingDescription VARCHAR(150), 
    @IdType INT, 
    @StartDate DATETIME, 
    @EndDate DATETIME
AS
BEGIN
    
    INSERT INTO Trainings (IdPartner, TrainingName, TrainingDescription, IdType, StartDate, EndDate)
    VALUES (@IdPartner, @TrainingName, @TrainingDescription, @IdType, @StartDate, @EndDate);

    SELECT SCOPE_IDENTITY() AS LastId;
END;
GO


CREATE OR ALTER PROCEDURE insert_daily_routine
    @IdTraining INT,
    @DailyRoutineDate DATETIME
AS
BEGIN
    INSERT INTO DailyRoutines (IdTraining, DailyRoutineDate)
    VALUES (@IdTraining, @DailyRoutineDate)

    SELECT SCOPE_IDENTITY() AS LastId;
END;
GO

CREATE OR ALTER PROCEDURE insert_exercise_in_daily_routine
    @IdDailyRoutine INT,
    @IdExercise INT,
    @ExerciseSets INT,
    @ExerciseReps INT,
    @ExerciseWeight DECIMAL,
    @ExerciseRestTime INT
AS
BEGIN
    INSERT INTO ExercisesInDailyRoutine(IdDailyRoutine, IdExercise, ExerciseSets, ExerciseReps, ExerciseWeight, ExerciseRestTime)
    VALUES(@IdDailyRoutine, @IdExercise, @ExerciseSets, @ExerciseReps, @ExerciseWeight, @ExerciseRestTime)
END;
GO

CREATE OR ALTER PROCEDURE insert_request
    @IdRequestStatus INT,
    @IdTrainer INT,
    @IdPartner INT,
    @CreationDate DATE
AS
BEGIN

BEGIN TRANSACTION;

-- Insertar la nueva request
    INSERT INTO Requests(IdRequestStatus, IdTrainer, IdPartner, CreationDate)
    VALUES(@IdRequestStatus, @IdTrainer, @IdPartner, @CreationDate)

    -- Si la inserción fue exitosa, actualizar IdStatus en Partners
    IF @@ROWCOUNT > 0
    BEGIN
        UPDATE Partners 
        SET IdStatus = 2 
        WHERE IdPartner = @IdPartner;
    END
    
COMMIT TRANSACTION;

END;
GO

CREATE OR ALTER PROCEDURE update_request
    @IdRequestStatus INT,
    @IdTrainer INT,
    @IdPartner INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Verificar si existe la request antes de actualizar
    IF EXISTS (SELECT 1 FROM Requests WHERE IdTrainer = @IdTrainer AND IdPartner = @IdPartner)
    BEGIN
        BEGIN TRANSACTION;
        -- Actualizar el estado de la request
        UPDATE Requests 
        SET IdRequestStatus = @IdRequestStatus 
        WHERE IdTrainer = @IdTrainer AND IdPartner = @IdPartner;

        -- Si el estado es 2, insertar en PartnersByTrainer si no existe y actualizar IdStatus en Partners
        IF @IdRequestStatus = 2
        BEGIN
        -- Insertar en PartnersByTrainer si no existe
            IF NOT EXISTS (SELECT 1 FROM PartnersByTrainer WHERE IdTrainer = @IdTrainer AND IdPartner = @IdPartner)
            BEGIN
                INSERT INTO PartnersByTrainer (IdTrainer, IdPartner) 
                VALUES (@IdTrainer, @IdPartner);
            END
            -- Actualizar el IdStatus en la tabla Partners
            UPDATE Partners 
            SET IdStatus = 3 
            WHERE IdPartner = @IdPartner;
        END
        -- Si el estado es 3, eliminar de PartnersByTrainer y actualizar IdStatus en Partners
        ELSE IF @IdRequestStatus = 3
        BEGIN
        -- Eliminar de PartnersByTrainer
            DELETE FROM PartnersByTrainer 
            WHERE IdTrainer = @IdTrainer AND IdPartner = @IdPartner;
            -- Actualizar el IdStatus en la tabla Partners
            UPDATE Partners 
            SET IdStatus = 1 
            WHERE IdPartner = @IdPartner;
        END
        COMMIT TRANSACTION;
    END
END;


-- select * from Addresses
-- select * from Users
-- select * from Partners
-- select * from Trainers
-- select * from Provinces
-- select * from Roles
-- select * from Exercises
-- select * from Trainings
-- select * from DailyRoutines
-- select * from PartnersByTrainer
-- select * from ExercisesInDailyRoutine
-- select * from PartnersByTrainer
-- select * from RequestStatuses
-- select * from Requests



