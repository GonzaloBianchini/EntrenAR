
use ENTRENAR_DB
GO

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

CREATE PROCEDURE insert_trainer
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


CREATE PROCEDURE insert_address
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


CREATE PROCEDURE insert_training
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


CREATE PROCEDURE insert_daily_routine
    @IdTraining INT,
    @DailyRoutineDate DATETIME
AS
BEGIN
    INSERT INTO DailyRoutines (IdTraining, DailyRoutineDate)
    VALUES (@IdTraining, @DailyRoutineDate)

    SELECT SCOPE_IDENTITY() AS LastId;
END;
GO

CREATE PROCEDURE insert_exercise_in_daily_routine
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

CREATE PROCEDURE insert_request
    @IdRequestStatus INT,
    @IdTrainer INT,
    @IdPartner INT,
    @CreationDate DATE
AS
BEGIN
    INSERT INTO Requests(IdRequestStatus, IdTrainer, IdPartner, CreationDate)
    VALUES(@IdRequestStatus, @IdTrainer, @IdPartner, @CreationDate)
END;
GO


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
-- SELECT * from PartnersByTrainer
-- select * from Requests

EXEC insert_training 12,'John-Fuerza-FEB2025','Entrenamiento de fuerza para John bla bla bla',1,'2025-02-01','2025-05-01'
EXEC insert_daily_routine '1','2025-03-01'
EXEC insert_daily_routine '1','2025-03-02'
EXEC insert_daily_routine '1','2025-03-03'

EXEC insert_exercise_in_daily_routine 1,2,4,10,60,120


INSERT INTO PartnersByTrainer(IdPartner,IdTrainer) 
VALUES
(13,3),
(12,3),
(7,6),
(9,7)


select * from Trainers T
INNER join PartnersByTrainer P ON T.IdTrainer = P.IdTrainer
WHERE P.IdPartner = 12

INSERT INTO DailyRoutines(IdTraining,DailyRoutineDate) VALUES(2,'2025-02-10')

SELECT * from PartnersByTrainer where IdTrainer = 3