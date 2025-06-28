CREATE DATABASE EscuelaMusicaDB;
GO

USE EscuelaMusicaDB;
GO

-- Escuelas
CREATE TABLE Escuelas (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Codigo NVARCHAR(20) NOT NULL UNIQUE,
    Nombre NVARCHAR(100) NOT NULL,
    Descripcion NVARCHAR(250)
);
GO

-- Profesores
CREATE TABLE Profesores (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Apellido NVARCHAR(100) NOT NULL,
    NumeroIdentificacion NVARCHAR(20) NOT NULL UNIQUE,
    EscuelaId INT NOT NULL,
    FOREIGN KEY (EscuelaId) REFERENCES Escuelas(Id)
);
GO

-- Alumnos
CREATE TABLE Alumnos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Apellido NVARCHAR(100) NOT NULL,
    FechaNacimiento DATE NOT NULL,
    NumeroIdentificacion NVARCHAR(20) NOT NULL UNIQUE
);
GO

-- Relacion muchos a muchos de Alumnos a Profesores
CREATE TABLE AlumnoProfesor (
    AlumnoId INT NOT NULL,
    ProfesorId INT NOT NULL,
    PRIMARY KEY (AlumnoId, ProfesorId),
    FOREIGN KEY (AlumnoId) REFERENCES Alumnos(Id),
    FOREIGN KEY (ProfesorId) REFERENCES Profesores(Id)
);
GO

-- Relación muchos a muchos de Alumnos a Escuelas (Inscripción)
CREATE TABLE Inscripciones (
    AlumnoId INT NOT NULL,
    EscuelaId INT NOT NULL,
    FechaInscripcion DATE DEFAULT GETDATE(),
    PRIMARY KEY (AlumnoId, EscuelaId),
    FOREIGN KEY (AlumnoId) REFERENCES Alumnos(Id),
    FOREIGN KEY (EscuelaId) REFERENCES Escuelas(Id)
);
GO

-- ---------------------------------------------- PROCEDIMIENTOS ALMACENADOS ------------------------------------------------ --

-- --------------------- Escuelas ----------------
-- Listar
CREATE PROCEDURE dbo.Escuelas_Listar
AS
BEGIN
    SELECT * FROM Escuelas;
END;
GO

-- Obtener por Id
CREATE PROCEDURE dbo.Escuelas_PorId
    @Id INT
AS
BEGIN
    SELECT * FROM Escuelas
    WHERE Id = @Id;
END;
GO

-- Crear
CREATE PROCEDURE dbo.Escuelas_Crear
    @Codigo NVARCHAR(20),
    @Nombre NVARCHAR(100),
    @Descripcion NVARCHAR(250)
AS
BEGIN
    INSERT INTO Escuelas (Codigo, Nombre, Descripcion)
    VALUES (@Codigo, @Nombre, @Descripcion);
END;
GO

-- Actualizar
CREATE PROCEDURE dbo.Escuelas_Actualizar
    @Id INT,
    @Codigo NVARCHAR(20) = null,
    @Nombre NVARCHAR(100)= null,
    @Descripcion NVARCHAR(250)= null
AS
BEGIN
    UPDATE Escuelas
    SET Codigo = @Codigo,
        Nombre = ISNULL(@Nombre, Nombre),
        Descripcion = ISNULL(@Descripcion, Descripcion)
    WHERE Id = @Id;
END;
GO

-- Eliminar
CREATE PROCEDURE dbo.Escuelas_Eliminar
    @Id INT
AS
BEGIN
    DELETE FROM Escuelas
    WHERE Id = @Id;
END;
GO

-- --------------------- Profesores ----------------
-- Listar
CREATE PROCEDURE dbo.Profesores_Listar
AS
BEGIN
    SELECT * FROM Profesores;
END;
GO

-- Obtener por Id
CREATE PROCEDURE dbo.Profesores_PorId
    @Id INT
AS
BEGIN
    SELECT * FROM Profesores
    WHERE Id = @Id;
END;
GO

-- Crear
CREATE PROCEDURE dbo.Profesores_Crear
    @Nombre NVARCHAR(100),
    @Apellido NVARCHAR(100),
    @NumeroIdentificacion NVARCHAR(20),
    @EscuelaId INT
AS
BEGIN
    INSERT INTO Profesores (Nombre, Apellido, NumeroIdentificacion, EscuelaId)
    VALUES (@Nombre, @Apellido, @NumeroIdentificacion, @EscuelaId);
END;
GO

-- Actualizar
CREATE PROCEDURE dbo.Profesores_Actualizar
    @Id INT,
    @Nombre NVARCHAR(100) = NULL,
    @Apellido NVARCHAR(100) = NULL,
    @NumeroIdentificacion NVARCHAR(20) = NULL,
    @EscuelaId INT = NULL
AS
BEGIN
    UPDATE Profesores
    SET Nombre = ISNULL(@Nombre, Nombre),
        Apellido = ISNULL(@Apellido, Apellido),
        NumeroIdentificacion = ISNULL(@NumeroIdentificacion, NumeroIdentificacion),
        EscuelaId = ISNULL(@EscuelaId, EscuelaId)
    WHERE Id = @Id;
END;
GO

-- Eliminar
CREATE PROCEDURE dbo.Profesores_Eliminar
    @Id INT
AS
BEGIN
    DELETE FROM Profesores
    WHERE Id = @Id;
END;
GO

-- --------------------- Alumnos ----------------
-- Listar
CREATE PROCEDURE dbo.Alumnos_Listar
AS
BEGIN
    SELECT * FROM Alumnos;
END;
GO

-- Obtener por Id
CREATE PROCEDURE dbo.Alumnos_PorId
    @Id INT
AS
BEGIN
    SELECT * FROM Alumnos
    WHERE Id = @Id;
END;
GO

-- Crear
CREATE PROCEDURE dbo.Alumnos_Crear
    @Nombre NVARCHAR(100),
    @Apellido NVARCHAR(100),
    @FechaNacimiento DATE,
    @NumeroIdentificacion NVARCHAR(20)
AS
BEGIN
    INSERT INTO Alumnos (Nombre, Apellido, FechaNacimiento, NumeroIdentificacion)
    VALUES (@Nombre, @Apellido, @FechaNacimiento, @NumeroIdentificacion);
END;
GO

-- Actualizar
CREATE PROCEDURE dbo.Alumnos_Actualizar
    @Id INT,
    @Nombre NVARCHAR(100) = NULL,
    @Apellido NVARCHAR(100) = NULL,
    @FechaNacimiento DATE = NULL,
    @NumeroIdentificacion NVARCHAR(20) = NULL
AS
BEGIN
    UPDATE Alumnos
    SET Nombre = ISNULL(@Nombre, Nombre),
        Apellido = ISNULL(@Apellido, Apellido),
        FechaNacimiento = ISNULL(@FechaNacimiento, FechaNacimiento),
        NumeroIdentificacion = ISNULL(@NumeroIdentificacion, NumeroIdentificacion)
    WHERE Id = @Id;
END;
GO

-- Eliminar
CREATE PROCEDURE dbo.Alumnos_Eliminar
    @Id INT
AS
BEGIN
    DELETE FROM Alumnos
    WHERE Id = @Id;
END;
GO

-- --------------------- AlumnoProfesor (muchos a muchos) ----------------
-- Asignar un alumno a un profesor
CREATE PROCEDURE dbo.AlumnoProfesor_Asignar
    @AlumnoId INT,
    @ProfesorId INT
AS
BEGIN
    INSERT INTO AlumnoProfesor (AlumnoId, ProfesorId)
    VALUES (@AlumnoId, @ProfesorId);
END;
GO

-- Eliminar una asignación alumno-profesor
CREATE PROCEDURE dbo.AlumnoProfesor_Eliminar
    @AlumnoId INT,
    @ProfesorId INT
AS
BEGIN
    DELETE FROM AlumnoProfesor
    WHERE AlumnoId = @AlumnoId AND ProfesorId = @ProfesorId;
END;
GO

-- Obtener profesores asignados a un alumno
CREATE PROCEDURE dbo.AlumnoProfesor_ProfesoresPorAlumno
    @AlumnoId INT
AS
BEGIN
    SELECT P.*, E.Nombre AS EscuelaNombre
    FROM Profesores P
    INNER JOIN AlumnoProfesor AP ON P.Id = AP.ProfesorId
    INNER JOIN Escuelas E ON P.EscuelaId = E.Id
    WHERE AP.AlumnoId = @AlumnoId;
END;
GO

-- Obtener alumnos asignados a un profesor
CREATE PROCEDURE dbo.AlumnoProfesor_AlumnosPorProfesor
    @ProfesorId INT
AS
BEGIN
    SELECT A.*
    FROM Alumnos A
    INNER JOIN AlumnoProfesor AP ON A.Id = AP.AlumnoId
    WHERE AP.ProfesorId = @ProfesorId;
END;
GO

-- --------------------- Inscripciones ----------------
-- Inscribir alumno a una escuela. Aquí contiene una validación para evitar duplicados, la cual se puede repetir en otras tablas
-- SIn embargo, por cuestiones de practicidad sólo lo utilizaré aquí.
CREATE PROCEDURE dbo.Inscripciones_Inscribir
    @AlumnoId INT,
    @EscuelaId INT
AS
BEGIN
    IF NOT EXISTS (
        SELECT 1 FROM Inscripciones
        WHERE AlumnoId = @AlumnoId AND EscuelaId = @EscuelaId
    )
    BEGIN
        INSERT INTO Inscripciones (AlumnoId, EscuelaId)
        VALUES (@AlumnoId, @EscuelaId);
    END
END;
GO

-- Eliminar una inscripción
CREATE PROCEDURE dbo.Inscripciones_Eliminar
    @AlumnoId INT,
    @EscuelaId INT
AS
BEGIN
    DELETE FROM Inscripciones
    WHERE AlumnoId = @AlumnoId AND EscuelaId = @EscuelaId;
END;
GO

-- Obtener escuelas en las que está inscrito un alumno
CREATE PROCEDURE dbo.Inscripciones_EscuelasPorAlumno
    @AlumnoId INT
AS
BEGIN
    SELECT E.*
    FROM Escuelas E
    INNER JOIN Inscripciones I ON E.Id = I.EscuelaId
    WHERE I.AlumnoId = @AlumnoId;
END;
GO

-- Obtener alumnos inscritos en una escuela
CREATE PROCEDURE dbo.Inscripciones_AlumnosPorEscuela
    @EscuelaId INT
AS
BEGIN
    SELECT A.*
    FROM Alumnos A
    INNER JOIN Inscripciones I ON A.Id = I.AlumnoId
    WHERE I.EscuelaId = @EscuelaId;
END;
GO












