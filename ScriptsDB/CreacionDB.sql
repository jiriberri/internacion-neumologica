-- 1. CREACION DE LA BASE DE DATOS
USE master;
GO
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'INTERNACION_NEUMOLOGICA_DB')
BEGIN
    CREATE DATABASE INTERNACION_NEUMOLOGICA_DB;
END
GO
USE INTERNACION_NEUMOLOGICA_DB;
GO

-- 2. CREACION DE LA TABLA PACIENTE
CREATE TABLE PACIENTE
(
    id_paciente INT IDENTITY(1,1) PRIMARY KEY,
    dni VARCHAR(20) NOT NULL UNIQUE,
    nombre VARCHAR(100) NOT NULL,
    apellido VARCHAR(100) NOT NULL,
    fecha_nacimiento DATE NOT NULL,
    domicilio VARCHAR(200) NULL,
    telefono VARCHAR(50) NULL,

    id_tabaquismo INT NULL,
    paquetes_anio INT NULL
);
GO

-- 3. CREACION DE LA TABLA USUARIO
CREATE TABLE USUARIO (
    id_usuario INT IDENTITY(1,1) PRIMARY KEY,
    usuario VARCHAR(50) NOT NULL UNIQUE,
    pass VARCHAR(256) NOT NULL,
    esAdmin BIT NOT NULL   -- Ej: 1 para Admin, 0 para Usuario limitado
);
GO


CREATE TABLE ORIGEN_INTERNACION
(
    id_origen INT IDENTITY(1,1) PRIMARY KEY,

    descripcion VARCHAR(50) NOT NULL UNIQUE
);
GO
--carga de datos de origen--

INSERT INTO ORIGEN_INTERNACION
(descripcion)
VALUES
('Guardia'),
('UTI'),
('Cirugia'),
('Otro hospital');
GO

--DESTINO_ EGRESO--

CREATE TABLE DESTINO_EGRESO
(
    id_destino INT IDENTITY(1,1) PRIMARY KEY,

    descripcion VARCHAR(50) NOT NULL UNIQUE
);
GO

--carga--
INSERT INTO DESTINO_EGRESO
(descripcion)
VALUES
('Domicilio'),
('UTI'),
('Cirugia'),
('Otra institucion'),
('Fallecimiento');
GO

CREATE TABLE INSUFICIENCIA_RESPIRATORIA
(
    id_insuficiencia INT IDENTITY(1,1) PRIMARY KEY,

    descripcion VARCHAR(50) NOT NULL UNIQUE
);
GO

INSERT INTO INSUFICIENCIA_RESPIRATORIA
(descripcion)
VALUES
('No'),
('Hipoxemica'),
('Hipercapnica'),
('Mixta');
GO

CREATE TABLE SOPORTE_RESPIRATORIO
(
    id_soporte INT IDENTITY(1,1) PRIMARY KEY,

    descripcion VARCHAR(50) NOT NULL UNIQUE
);
GO

INSERT INTO SOPORTE_RESPIRATORIO
(descripcion)
VALUES
('Ninguno'),
('Oxigeno'),
('Alto flujo'),
('VNI'),
('ARM');
GO

CREATE TABLE MOTIVO_INTERNACION
(
    id_motivo INT IDENTITY(1,1) PRIMARY KEY,

    descripcion VARCHAR(150) NOT NULL UNIQUE
);
GO
INSERT INTO MOTIVO_INTERNACION(descripcion)
VALUES
('NAC (Neumonia adquirida en la comunidad)'),
('Neumonia intrahospitalaria'),
('Tuberculosis'),
('Infeccion viral'),
('Infeccion fungica'),

('Exacerbacion de EPOC'),
('Exacerbacion de asma'),
('Exacerbacion de bronquiectasias'),

('EPD progresiva'),
('Exacerbacion aguda de EPD'),
('Hemorragia alveolar'),

('Derrame pleural'),
('Empiema'),
('Neumotorax'),

('TEP'),
('Hipertension pulmonar'),

('Masa pulmonar en estudio'),
('Complicacion oncologica'),

('Estudio diagnostico'),
('Manejo del dolor'),
('Cuidados paliativos');
GO
--Antec respirtorio--
CREATE TABLE ANTECEDENTE_RESPIRATORIO
(
    id_antecedente INT IDENTITY(1,1) PRIMARY KEY,

    descripcion VARCHAR(150) NOT NULL UNIQUE
);
GO
--carga de datos--
INSERT INTO ANTECEDENTE_RESPIRATORIO
(descripcion)
VALUES
('EPOC (Enfermedad pulmonar obstructiva cronica)'),
('Asma'),
('Bronquiectasias'),
('EPD (Enfermedad pulmonar difusa)'),
('Tuberculosis previa'),
('Cancer de pulmon'),
('Oxigeno domiciliario'),
('VNI domiciliaria'),

('Secuela postinfecciosa'),
('Secuela postraumatica'),
('Secuela post-TBC'),
('Otra secuela pulmonar'),

('Lobectomia'),
('Segmentectomia'),
('Neumonectomia'),
('Otra reseccion pulmonar');
GO

--tbq--
CREATE TABLE TABAQUISMO
(
    id_tabaquismo INT IDENTITY(1,1) PRIMARY KEY,

    descripcion VARCHAR(50) NOT NULL UNIQUE
);
GO

INSERT INTO TABAQUISMO
(descripcion)
VALUES
('Nunca fumo'),
('Exfumador'),
('Fumador activo');
GO

ALTER TABLE PACIENTE
ADD CONSTRAINT FK_PACIENTE_TABAQUISMO
FOREIGN KEY (id_tabaquismo)
REFERENCES TABAQUISMO(id_tabaquismo);
GO

--exposicion ambiental--
CREATE TABLE EXPOSICION_AMBIENTAL
(
    id_exposicion INT IDENTITY(1,1) PRIMARY KEY,

    descripcion VARCHAR(100) NOT NULL UNIQUE
);
GO

INSERT INTO EXPOSICION_AMBIENTAL
(descripcion)
VALUES
('Humo de leña'),
('Aves'),
('Silice / Marmol / Granito'),
('Asbesto'),
('Otra exposicion relevante');
GO

--Comorbilideades--
CREATE TABLE COMORBILIDAD
(
    id_comorbilidad INT IDENTITY(1,1) PRIMARY KEY,

    descripcion VARCHAR(150) NOT NULL UNIQUE
);
GO
--carga de datos--
INSERT INTO COMORBILIDAD
(descripcion)
VALUES
('HTA (Hipertension arterial)'),
('Insuficiencia cardiaca'),
('Fibrilacion auricular'),
('Cardiopatia isquemica'),
('Hipertension pulmonar'),
('TEP previo'),

('Diabetes'),
('Obesidad'),

('ACV previo'),
('Enfermedad neuromuscular'),

('SAOS (Sindrome de apnea obstructiva del sueño)'),
('Sindrome obesidad-hipoventilacion'),

('Enfermedad reumatologica'),
('Inmunosuprimido'),
('HIV'),

('Neoplasia extrapulmonar activa');
GO



--4. CREACION DE LA TABLA INTERNACION

CREATE TABLE INTERNACION
(
    id_internacion INT IDENTITY(1,1) PRIMARY KEY,

    id_paciente INT NOT NULL,

    fecha_ingreso DATE NOT NULL,

    fecha_egreso DATE NULL,

    id_origen INT NOT NULL,

    id_destino INT NULL,

    id_motivo INT NOT NULL,

    id_insuficiencia INT NULL,

    id_soporte INT NULL,

    FOREIGN KEY (id_paciente)
        REFERENCES PACIENTE(id_paciente),

    FOREIGN KEY (id_origen)
        REFERENCES ORIGEN_INTERNACION(id_origen),

    FOREIGN KEY (id_destino)
        REFERENCES DESTINO_EGRESO(id_destino),

    FOREIGN KEY (id_motivo)
        REFERENCES MOTIVO_INTERNACION(id_motivo),

    FOREIGN KEY (id_insuficiencia)
        REFERENCES INSUFICIENCIA_RESPIRATORIA(id_insuficiencia),

    FOREIGN KEY (id_soporte)
        REFERENCES SOPORTE_RESPIRATORIO(id_soporte)
);
GO
--TABLAS DE CONEXION --

CREATE TABLE PACIENTE_EXPOSICION
(
    id_paciente INT NOT NULL,

    id_exposicion INT NOT NULL,

    PRIMARY KEY
    (
        id_paciente,
        id_exposicion
    ),

    FOREIGN KEY (id_paciente)
        REFERENCES PACIENTE(id_paciente),

    FOREIGN KEY (id_exposicion)
        REFERENCES EXPOSICION_AMBIENTAL(id_exposicion)
);
GO

CREATE TABLE PACIENTE_ANTECEDENTE
(
    id_paciente INT NOT NULL,

    id_antecedente INT NOT NULL,

    PRIMARY KEY
    (
        id_paciente,
        id_antecedente
    ),

    FOREIGN KEY (id_paciente)
        REFERENCES PACIENTE(id_paciente),

    FOREIGN KEY (id_antecedente)
        REFERENCES ANTECEDENTE_RESPIRATORIO(id_antecedente)
);
GO

CREATE TABLE PACIENTE_COMORBILIDAD
(
    id_paciente INT NOT NULL,

    id_comorbilidad INT NOT NULL,

    PRIMARY KEY
    (
        id_paciente,
        id_comorbilidad
    ),

    FOREIGN KEY (id_paciente)
        REFERENCES PACIENTE(id_paciente),

    FOREIGN KEY (id_comorbilidad)
        REFERENCES COMORBILIDAD(id_comorbilidad)
);
GO
-----CARGA DE DATOS DE PRUEBA-----

-- 1. CREACION DE LA BASE DE DATOS
USE master;
GO
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'INTERNACION_NEUMOLOGICA_DB')
BEGIN
    CREATE DATABASE INTERNACION_NEUMOLOGICA_DB;
END
GO
USE INTERNACION_NEUMOLOGICA_DB;
GO

-- 2. CREACION DE LA TABLA PACIENTE
CREATE TABLE PACIENTE
(
    id_paciente INT IDENTITY(1,1) PRIMARY KEY,
    dni VARCHAR(20) NOT NULL UNIQUE,
    nombre VARCHAR(100) NOT NULL,
    apellido VARCHAR(100) NOT NULL,
    fecha_nacimiento DATE NOT NULL,
    domicilio VARCHAR(200) NULL,
    telefono VARCHAR(50) NULL,

    id_tabaquismo INT NULL,
    paquetes_anio INT NULL
);
GO

-- 3. CREACION DE LA TABLA USUARIO
CREATE TABLE USUARIO (
    id_usuario INT IDENTITY(1,1) PRIMARY KEY,
    usuario VARCHAR(50) NOT NULL UNIQUE,
    pass VARCHAR(256) NOT NULL,
    tipo_usuario INT NOT NULL   -- Ej: 1 para Admin, 2 para Usuario limitado
);
GO


CREATE TABLE ORIGEN_INTERNACION
(
    id_origen INT IDENTITY(1,1) PRIMARY KEY,

    descripcion VARCHAR(50) NOT NULL UNIQUE
);
GO
--carga de datos de origen--

INSERT INTO ORIGEN_INTERNACION
(descripcion)
VALUES
('Guardia'),
('UTI'),
('Cirugia'),
('Otro hospital');
GO

--DESTINO_ EGRESO--

CREATE TABLE DESTINO_EGRESO
(
    id_destino INT IDENTITY(1,1) PRIMARY KEY,

    descripcion VARCHAR(50) NOT NULL UNIQUE
);
GO

--carga--
INSERT INTO DESTINO_EGRESO
(descripcion)
VALUES
('Domicilio'),
('UTI'),
('Cirugia'),
('Otra institucion'),
('Fallecimiento');
GO

CREATE TABLE INSUFICIENCIA_RESPIRATORIA
(
    id_insuficiencia INT IDENTITY(1,1) PRIMARY KEY,

    descripcion VARCHAR(50) NOT NULL UNIQUE
);
GO

INSERT INTO INSUFICIENCIA_RESPIRATORIA
(descripcion)
VALUES
('No'),
('Hipoxemica'),
('Hipercapnica'),
('Mixta');
GO

CREATE TABLE SOPORTE_RESPIRATORIO
(
    id_soporte INT IDENTITY(1,1) PRIMARY KEY,

    descripcion VARCHAR(50) NOT NULL UNIQUE
);
GO

INSERT INTO SOPORTE_RESPIRATORIO
(descripcion)
VALUES
('Ninguno'),
('Oxigeno'),
('Alto flujo'),
('VNI'),
('ARM');
GO

CREATE TABLE MOTIVO_INTERNACION
(
    id_motivo INT IDENTITY(1,1) PRIMARY KEY,

    descripcion VARCHAR(150) NOT NULL UNIQUE
);
GO
INSERT INTO MOTIVO_INTERNACION(descripcion)
VALUES
('NAC (Neumonia adquirida en la comunidad)'),
('Neumonia intrahospitalaria'),
('Tuberculosis'),
('Infeccion viral'),
('Infeccion fungica'),

('Exacerbacion de EPOC'),
('Exacerbacion de asma'),
('Exacerbacion de bronquiectasias'),

('EPD progresiva'),
('Exacerbacion aguda de EPD'),
('Hemorragia alveolar'),

('Derrame pleural'),
('Empiema'),
('Neumotorax'),

('TEP'),
('Hipertension pulmonar'),

('Masa pulmonar en estudio'),
('Complicacion oncologica'),

('Estudio diagnostico'),
('Manejo del dolor'),
('Cuidados paliativos');
GO
--Antec respirtorio--
CREATE TABLE ANTECEDENTE_RESPIRATORIO
(
    id_antecedente INT IDENTITY(1,1) PRIMARY KEY,

    descripcion VARCHAR(150) NOT NULL UNIQUE
);
GO
--carga de datos--
INSERT INTO ANTECEDENTE_RESPIRATORIO
(descripcion)
VALUES
('EPOC (Enfermedad pulmonar obstructiva cronica)'),
('Asma'),
('Bronquiectasias'),
('EPD (Enfermedad pulmonar difusa)'),
('Tuberculosis previa'),
('Cancer de pulmon'),
('Oxigeno domiciliario'),
('VNI domiciliaria'),

('Secuela postinfecciosa'),
('Secuela postraumatica'),
('Secuela post-TBC'),
('Otra secuela pulmonar'),

('Lobectomia'),
('Segmentectomia'),
('Neumonectomia'),
('Otra reseccion pulmonar');
GO

--tbq--
CREATE TABLE TABAQUISMO
(
    id_tabaquismo INT IDENTITY(1,1) PRIMARY KEY,

    descripcion VARCHAR(50) NOT NULL UNIQUE
);
GO

INSERT INTO TABAQUISMO
(descripcion)
VALUES
('Nunca fumo'),
('Exfumador'),
('Fumador activo');
GO

ALTER TABLE PACIENTE
ADD CONSTRAINT FK_PACIENTE_TABAQUISMO
FOREIGN KEY (id_tabaquismo)
REFERENCES TABAQUISMO(id_tabaquismo);
GO

--exposicion ambiental--
CREATE TABLE EXPOSICION_AMBIENTAL
(
    id_exposicion INT IDENTITY(1,1) PRIMARY KEY,

    descripcion VARCHAR(100) NOT NULL UNIQUE
);
GO

INSERT INTO EXPOSICION_AMBIENTAL
(descripcion)
VALUES
('Humo de leña'),
('Aves'),
('Silice / Marmol / Granito'),
('Asbesto'),
('Otra exposicion relevante');
GO

--Comorbilideades--
CREATE TABLE COMORBILIDAD
(
    id_comorbilidad INT IDENTITY(1,1) PRIMARY KEY,

    descripcion VARCHAR(150) NOT NULL UNIQUE
);
GO
--carga de datos--
INSERT INTO COMORBILIDAD
(descripcion)
VALUES
('HTA (Hipertension arterial)'),
('Insuficiencia cardiaca'),
('Fibrilacion auricular'),
('Cardiopatia isquemica'),
('Hipertension pulmonar'),
('TEP previo'),

('Diabetes'),
('Obesidad'),

('ACV previo'),
('Enfermedad neuromuscular'),

('SAOS (Sindrome de apnea obstructiva del sueño)'),
('Sindrome obesidad-hipoventilacion'),

('Enfermedad reumatologica'),
('Inmunosuprimido'),
('HIV'),

('Neoplasia extrapulmonar activa');
GO



--4. CREACION DE LA TABLA INTERNACION

CREATE TABLE INTERNACION
(
    id_internacion INT IDENTITY(1,1) PRIMARY KEY,

    id_paciente INT NOT NULL,

    fecha_ingreso DATE NOT NULL,

    fecha_egreso DATE NULL,

    id_origen INT NOT NULL,

    id_destino INT NULL,

    id_motivo INT NOT NULL,

    id_insuficiencia INT NULL,

    id_soporte INT NULL,

    FOREIGN KEY (id_paciente)
        REFERENCES PACIENTE(id_paciente),

    FOREIGN KEY (id_origen)
        REFERENCES ORIGEN_INTERNACION(id_origen),

    FOREIGN KEY (id_destino)
        REFERENCES DESTINO_EGRESO(id_destino),

    FOREIGN KEY (id_motivo)
        REFERENCES MOTIVO_INTERNACION(id_motivo),

    FOREIGN KEY (id_insuficiencia)
        REFERENCES INSUFICIENCIA_RESPIRATORIA(id_insuficiencia),

    FOREIGN KEY (id_soporte)
        REFERENCES SOPORTE_RESPIRATORIO(id_soporte)
);
GO
--TABLAS DE CONEXION --

CREATE TABLE PACIENTE_EXPOSICION
(
    id_paciente INT NOT NULL,

    id_exposicion INT NOT NULL,

    PRIMARY KEY
    (
        id_paciente,
        id_exposicion
    ),

    FOREIGN KEY (id_paciente)
        REFERENCES PACIENTE(id_paciente),

    FOREIGN KEY (id_exposicion)
        REFERENCES EXPOSICION_AMBIENTAL(id_exposicion)
);
GO

CREATE TABLE PACIENTE_ANTECEDENTE
(
    id_paciente INT NOT NULL,

    id_antecedente INT NOT NULL,

    PRIMARY KEY
    (
        id_paciente,
        id_antecedente
    ),

    FOREIGN KEY (id_paciente)
        REFERENCES PACIENTE(id_paciente),

    FOREIGN KEY (id_antecedente)
        REFERENCES ANTECEDENTE_RESPIRATORIO(id_antecedente)
);
GO

CREATE TABLE PACIENTE_COMORBILIDAD
(
    id_paciente INT NOT NULL,

    id_comorbilidad INT NOT NULL,

    PRIMARY KEY
    (
        id_paciente,
        id_comorbilidad
    ),

    FOREIGN KEY (id_paciente)
        REFERENCES PACIENTE(id_paciente),

    FOREIGN KEY (id_comorbilidad)
        REFERENCES COMORBILIDAD(id_comorbilidad)
);
GO


INSERT INTO USUARIO
(usuario, pass, tipo_usuario)
VALUES
('admin', 'admin123', 1),
('usuario', 'usuario123', 2);



INSERT INTO PACIENTE
(
    dni,
    nombre,
    apellido,
    fecha_nacimiento,
    domicilio,
    telefono,
    id_tabaquismo,
    paquetes_anio
)
VALUES

(
'20111222',
'Juan',
'Perez',
'1965-05-10',
'Av. Siempre Viva 123',
'11111111',
3,
40
),

(
'22333444',
'Maria',
'Gomez',
'1978-08-21',
'Calle Falsa 456',
'22222222',
2,
25
),

(
'30123456',
'Carlos',
'Fernandez',
'1952-01-15',
'Belgrano 789',
'33333333',
1,
NULL
),

(
'28999888',
'Ana',
'Rodriguez',
'1985-12-03',
'San Martin 555',
'44444444',
1,
NULL
);
GO
--JUAN--Humo de leña--
INSERT INTO PACIENTE_EXPOSICION
VALUES (1,1);

--Carlos-- aves y asbesto--
INSERT INTO PACIENTE_EXPOSICION
VALUES (3,4);
INSERT INTO PACIENTE_EXPOSICION
VALUES (3,4);

---JUAN EPOC u OCD--
INSERT INTO PACIENTE_ANTECEDENTE
VALUES (1,1);
INSERT INTO PACIENTE_ANTECEDENTE
VALUES (1,7);
--MARIA-- ASMA--
INSERT INTO PACIENTE_ANTECEDENTE
VALUES (2,2);
--CARLOS EPD y neumonectomia--
INSERT INTO PACIENTE_ANTECEDENTE
VALUES (3,4);
INSERT INTO PACIENTE_ANTECEDENTE
VALUES (3,15);
--JUAN HTA y dbtes--
INSERT INTO PACIENTE_COMORBILIDAD
VALUES (1,1);
INSERT INTO PACIENTE_COMORBILIDAD
VALUES (1,7);
--Maria-- obesidad --
INSERT INTO PACIENTE_COMORBILIDAD
VALUES (2,8);
--Carlos enf reumatologica--
INSERT INTO PACIENTE_COMORBILIDAD
VALUES (3,13);
-- Internaciones mock--
INSERT INTO INTERNACION
(
    id_paciente,
    fecha_ingreso,
    fecha_egreso,
    id_origen,
    id_destino,
    id_motivo,
    id_insuficiencia,
    id_soporte
)
VALUES
(
1,
'2026-05-01',
'2026-05-10',
1,
1,
6,
2,
2
),

(
2,
'2026-04-12',
'2026-04-15',
1,
1,
7,
1,
1
),

(
3,
'2026-03-20',
'2026-04-05',
4,
4,
9,
4,
4
);
GO
/*PARA PROBAR:
Login
Búsqueda por DNI
Búsqueda por apellido
Carga de antecedentes
Comorbilidades
Exposiciones
Internaciones
Reportes básicos*/