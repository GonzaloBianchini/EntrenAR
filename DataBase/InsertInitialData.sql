use ENTRENAR_DB

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

INSERT INTO Roles (RolName)
VALUES 
    ('Admin'),
    ('Trainer'),
    ('Partner');

INSERT INTO Exercises (ExerciseName, ExerciseDescription, UrlExercise)
VALUES
    ('Sentadillas', 'Ejercicio básico/compuesto de piernas', 'www.entrenar.com/squats'),
    ('Pecho plano', 'Ejercicio básico/compuesto de pecho', 'www.entrenar.com/bench-press'),
    ('Dominadas', 'Ejercicio básico/compuesto de espalda', 'www.entrenar.com/pull-ups'),
    ('Curl de bíceps', 'Ejercicio básico/localizado de bíceps', 'www.entrenar.com/curl-biceps');

    

