use ENTRENAR_DB

INSERT INTO Provinces (ProvinceName)
VALUES
('Cap Fed'),
('Buenos Aires'),
('Catamarca'),
('Chaco'),
('Chubut'),
('Córdoba'),
('Corrientes'),
('Entre Ríos'),
('Formosa'),
('Jujuy'),
('La Pampa'),
('La Rioja'),
('Mendoza'),
('Misiones'),
('Neuquén'),
('Río Negro'),
('Salta'),
('San Juan'),
('San Luis'),
('Santa Cruz'),
('Santa Fe'),
('Santiago del Estero'),
('Tierra del Fuego'),
('Tucumán');


INSERT INTO StatusesPartner (StatusName, StatusDescription)
VALUES 
('Available', 'No tiene trainer y está buscando, puede enviar solicitudes'),
('Pending', 'Envió solicitud y espera respuesta'),
('Assigned', 'Fue asignado/a y está bajo supervisión de Trainer');

INSERT INTO TrainingTypes (TrainingTypeName, TrainingTypeDescription)
VALUES 
('Fuerza', 'Entrenamiento de fuerza general'),
('Acondicionamiento', 'Ideal para pretemporada o post rehabilitación'),
('MetCon', 'Cardio de distintas disciplinas'),
('Funcional', 'Entrenamiento all around con BodyWeight');

INSERT INTO Roles (RoleName)
VALUES 
    ('Admin'),
    ('Trainer'),
    ('Partner');

INSERT INTO Exercises (ExerciseName, ExerciseDescription, UrlExercise)
VALUES
    ('Sentadillas', 'Ejercicio básico/compuesto de piernas', 'https://www.youtube.com/shorts/MLoZuAkIyZI?feature=share'),
    ('Pecho plano', 'Ejercicio básico/compuesto de pecho', 'https://www.youtube.com/shorts/hWbUlkb5Ms4?feature=share'),
    ('Dominadas', 'Ejercicio básico/compuesto de espalda', 'https://www.youtube.com/shorts/l6-aIZTbAR0?feature=share'),
    ('Curl de bíceps', 'Ejercicio básico/localizado de bíceps', 'https://www.youtube.com/shorts/2jpteC44QKg?feature=share');


INSERT INTO RequestStatuses (RequestStatusName)
VALUES
    ('En Revision'),
    ('Aceptada'),
    ('Rechazada');
