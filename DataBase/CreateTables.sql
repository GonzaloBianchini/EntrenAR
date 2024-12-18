-- CREATE DATABASE ENTRENAR_DB
-- GO

USE ENTRENAR_DB
GO

CREATE TABLE Roles (
    IdRole INT PRIMARY KEY IDENTITY(1,1),
    RolName VARCHAR(50) NOT NULL
);

-- Tabla: Users
CREATE TABLE Users (
    IdUser INT PRIMARY KEY IDENTITY(1,1),
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    BirthDate DATE NOT NULL,
    Dni INT NOT NULL UNIQUE,
    Phone VARCHAR(50),
    Email VARCHAR(50) UNIQUE,
    IsActive BIT NOT NULL,
    UserNickName VARCHAR(50) NOT NULL,
    UserPassword VARCHAR(50) NOT NULL,
    IdRole INT NOT NULL,
    FOREIGN KEY (IdRole) REFERENCES Roles(IdRole)
);

-- Tabla: StatusClient
CREATE TABLE StatusesClient (
    IdStatus INT PRIMARY KEY IDENTITY(1,1),
    StatusName VARCHAR(50) NOT NULL UNIQUE,
    StatusDescription VARCHAR(150)
);

CREATE TABLE Clients (
    IdClient INT PRIMARY KEY IDENTITY(1,1),
    IdUser INT NOT NULL,  
    IdStatus INT NOT NULL,
    FOREIGN KEY (IdStatus) REFERENCES StatusesClient(IdStatus),
    FOREIGN KEY (IdUser) REFERENCES Users(IdUser)
);

CREATE TABLE Trainers (
    IdTrainer INT PRIMARY KEY IDENTITY(1,1),
    IdUser INT NOT NULL,
    FOREIGN KEY (IdUser) REFERENCES Users(IdUser)
);

-- Tabla intermedia: TrainerByClient (para asociar entrenadores con clientes)
CREATE TABLE ClientsByTrainer (
    IdTrainer INT NOT NULL,
    IdClient INT NOT NULL,
    PRIMARY KEY (IdTrainer, IdClient),
    FOREIGN KEY (IdTrainer) REFERENCES Trainers(IdTrainer),
    FOREIGN KEY (IdClient) REFERENCES Clients(IdClient)
);

-- Tabla: TrainingType
CREATE TABLE TrainingTypes (
    IdType INT PRIMARY KEY IDENTITY(1,1),
    TrainingTypeName VARCHAR(50) NOT NULL UNIQUE,
    TrainingTypeDescription VARCHAR(150)
);

-- Tabla: Training
CREATE TABLE Trainings (
    Id INT PRIMARY KEY IDENTITY(1,1),
    TrainingName VARCHAR(50) NOT NULL,
    TrainingDescription VARCHAR(150),
    IdType INT NOT NULL,
    StartDate DATETIME NOT NULL,
    EndDate DATETIME NOT NULL,
    FOREIGN KEY (IdType) REFERENCES TrainingTypes(IdType)
);

-- Tabla intermedia: TrainingByClient (para asociar entrenamientos con clientes)
CREATE TABLE TrainingsByClients (
    IdClient INT NOT NULL,
    IdTraining INT NOT NULL,
    PRIMARY KEY (IdClient, IdTraining),
    FOREIGN KEY (IdClient) REFERENCES Clients(IdClient),
    FOREIGN KEY (IdTraining) REFERENCES Trainings(Id)
);

-- Tabla: DailyRoutine
CREATE TABLE DailyRoutines (
    IdDailyRoutine INT PRIMARY KEY IDENTITY(1,1),
    DailyRoutineDate DATE NOT NULL
);

-- Tabla: Exercise
CREATE TABLE Exercises (
    IdExercise INT PRIMARY KEY IDENTITY(1,1),
    ExerciseName VARCHAR(50) NOT NULL,
    ExerciseDescription VARCHAR(150),
    UrlExercise VARCHAR(150)
);

-- Tabla intermedia: DailyRoutineByExercise (para asociar ejercicios con rutinas)
CREATE TABLE ExercisesByDailyRoutine(
    IdDailyRoutine INT NOT NULL,
    IdExercise INT NOT NULL,
    PRIMARY KEY (IdDailyRoutine, IdExercise),
    FOREIGN KEY (IdDailyRoutine) REFERENCES DailyRoutines(IdDailyRoutine),
    FOREIGN KEY (IdExercise) REFERENCES Exercises(IdExercise)
);


