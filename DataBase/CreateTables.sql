-- CREATE DATABASE ENTRENAR_DB
-- GO

USE ENTRENAR_DB
GO

CREATE TABLE Roles (
    IdRole INT PRIMARY KEY IDENTITY(1,1),
    RoleName VARCHAR(50) NOT NULL
);

-- Tabla: Addresses
CREATE TABLE Addresses (
    IdAddress INT PRIMARY KEY IDENTITY(1,1),
    StreetName VARCHAR(50) NOT NULL,
    StreetNumber VARCHAR(50) NOT NULL,
    Flat VARCHAR(50) NULL,
    Details VARCHAR(50) NULL,
    City VARCHAR(50) NOT NULL,
    Province VARCHAR(50) NOT NULL,
    Country VARCHAR(50) NOT NULL,
);

-- Tabla: Users
CREATE TABLE Users (
    IdUser INT PRIMARY KEY IDENTITY(1,1),
    IdRole INT DEFAULT 3 NOT NULL, -- Id Role 3 es para crear PARTNERS por DEFAULT
    UserNickName VARCHAR(50) NOT NULL,
    UserPassword VARCHAR(50) NOT NULL,
    FOREIGN KEY (IdRole) REFERENCES Roles(IdRole)
);

-- Tabla: StatusPartner
CREATE TABLE StatusesPartner (
    IdStatus INT PRIMARY KEY IDENTITY(1,1),
    StatusName VARCHAR(50) NOT NULL UNIQUE,
    StatusDescription VARCHAR(150)
);

CREATE TABLE Partners (
    IdPartner INT PRIMARY KEY IDENTITY(1,1),
    IdUser INT NOT NULL,  
    IdStatus INT DEFAULT 1 NOT NULL,
    ActiveStatus BIT DEFAULT 1 NOT NULL,
    Dni INT NOT NULL UNIQUE,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    Gender VARCHAR(50) NULL,
    Email VARCHAR(50) UNIQUE,
    Phone VARCHAR(50) NOT NULL,
    BirthDate DATE NOT NULL,
    IdAddress INT NOT NULL,
    FOREIGN KEY (IdUser) REFERENCES Users(IdUser),
    FOREIGN KEY (IdStatus) REFERENCES StatusesPartner(IdStatus),
);

CREATE TABLE Trainers (
    IdTrainer INT PRIMARY KEY IDENTITY(1,1),
    IdUser INT NOT NULL,
    FOREIGN KEY (IdUser) REFERENCES Users(IdUser)
);

-- Tabla intermedia: TrainerByPartner (para asociar entrenadores con Partners)
CREATE TABLE PartnersByTrainer (
    IdTrainer INT NOT NULL,
    IdPartner INT NOT NULL,
    PRIMARY KEY (IdTrainer, IdPartner),
    FOREIGN KEY (IdTrainer) REFERENCES Trainers(IdTrainer),
    FOREIGN KEY (IdPartner) REFERENCES Partners(IdPartner)
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

-- Tabla: DailyRoutine
CREATE TABLE DailyRoutines (
    IdDailyRoutine INT PRIMARY KEY IDENTITY(1,1),
    DailyRoutineDate DATE NOT NULL
);

-- Tabla: Exercise
CREATE TABLE Exercises (
    IdExercise INT PRIMARY KEY IDENTITY(1,1),
    ActiveStatus BIT DEFAULT 1 NOT NULL,
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


