-- 1. CREACIÓN DE LA BASE DE DATOS
USE master;
GO
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'INTERNACION_NEUMOLOGICA_DB')
BEGIN
    CREATE DATABASE INTERNACION_NEUMOLOGICA_DB;
END
GO
USE INTERNACION_NEUMOLOGICA_DB;
GO

-- 2. TABLAS MAESTRAS / CATÁLOGOS INDEPENDIENTES
CREATE TABLE USUARIO (
    id_usuario INT IDENTITY(1,1) PRIMARY KEY,
    usuario VARCHAR(50) NOT NULL UNIQUE,
    pass VARCHAR(256) NOT NULL,
    esAdmin BIT NOT NULL,   -- 1 para Admin, 0 para Usuario limitado
    activo BIT NOT NULL DEFAULT 1, -- 1 para activo, 0 para inactivo

);
GO

CREATE TABLE TABAQUISMO (
    id_tabaquismo INT IDENTITY(1,1) PRIMARY KEY,
    descripcion VARCHAR(50) NOT NULL UNIQUE
);
GO

CREATE TABLE ORIGEN_INTERNACION (
    id_origen INT IDENTITY(1,1) PRIMARY KEY,
    descripcion VARCHAR(50) NOT NULL UNIQUE
);
GO

CREATE TABLE DESTINO_EGRESO (
    id_destino INT IDENTITY(1,1) PRIMARY KEY,
    descripcion VARCHAR(50) NOT NULL UNIQUE
);
GO

CREATE TABLE INSUFICIENCIA_RESPIRATORIA (
    id_insuficiencia INT IDENTITY(1,1) PRIMARY KEY,
    descripcion VARCHAR(50) NOT NULL UNIQUE
);
GO

CREATE TABLE SOPORTE_RESPIRATORIO (
    id_soporte INT IDENTITY(1,1) PRIMARY KEY,
    descripcion VARCHAR(50) NOT NULL UNIQUE
);

GO

CREATE TABLE ANTECEDENTE_RESPIRATORIO (
    id_antecedente INT IDENTITY(1,1) PRIMARY KEY,
    descripcion VARCHAR(150) NOT NULL UNIQUE
);
GO

CREATE TABLE EXPOSICION_AMBIENTAL (
    id_exposicion INT IDENTITY(1,1) PRIMARY KEY,
    descripcion VARCHAR(100) NOT NULL UNIQUE
);
GO

CREATE TABLE COMORBILIDAD (
    id_comorbilidad INT IDENTITY(1,1) PRIMARY KEY,
    descripcion VARCHAR(150) NOT NULL UNIQUE
);

--5. Creaciones tablas de enfermedades 
GO
CREATE TABLE INFECCIONES(
id_infeccion INT IDENTITY(1,1) PRIMARY KEY,
    descripcion VARCHAR(150) NOT NULL UNIQUE
)
GO
CREATE TABLE OBSTRUCTIVAS(
id_obstructiva INT IDENTITY(1,1) PRIMARY KEY,
    descripcion VARCHAR(150) NOT NULL UNIQUE
)
GO
CREATE TABLE INTERSTICIALES(
id_intersticial INT IDENTITY(1,1) PRIMARY KEY,
    descripcion VARCHAR(150) NOT NULL UNIQUE
)
GO
CREATE TABLE PLEURA(
id_pleura INT IDENTITY(1,1) PRIMARY KEY,
    descripcion VARCHAR(150) NOT NULL UNIQUE
)
GO
CREATE TABLE VASCULARES(
id_vascular INT IDENTITY(1,1) PRIMARY KEY,
    descripcion VARCHAR(150) NOT NULL UNIQUE
)
GO
CREATE TABLE ONCOLOGICAS(
id_oncologica INT IDENTITY(1,1) PRIMARY KEY,
    descripcion VARCHAR(150) NOT NULL UNIQUE
)
GO
CREATE TABLE OTROS(
id_otro INT IDENTITY(1,1) PRIMARY KEY,
    descripcion VARCHAR(150) NOT NULL UNIQUE
)


GO

-- 3. TABLAS PRINCIPALES CON DEPENDENCIAS
CREATE TABLE PACIENTE (
    id_paciente INT IDENTITY(1,1) PRIMARY KEY,
    dni VARCHAR(20) NOT NULL UNIQUE,
    nombre VARCHAR(100) NOT NULL,
    apellido VARCHAR(100) NOT NULL,
    fecha_nacimiento DATE NOT NULL,
    domicilio VARCHAR(200) NULL,
    telefono VARCHAR(50) NULL,
);
GO

CREATE TABLE INTERNACION (
    id_internacion INT IDENTITY(1,1) PRIMARY KEY,
    id_paciente INT NOT NULL,
    fecha_ingreso DATE NOT NULL,
    fecha_egreso DATE NULL,
    id_origen INT NOT NULL,
    id_destino INT NULL,
    id_infeccion INT NULL, 
    id_obstructiva INT NULL, 
    id_intersticial INT NULL, 
    id_pleura INT NULL,
    id_vascular INT NULL, 
    id_oncologica INT NULL, 
    id_otro INT NULL,
    id_insuficiencia INT NULL,
    id_soporte INT NULL,
    id_tabaquismo INT NULL,
    paquetes_anio INT NULL,
    FOREIGN KEY (id_paciente) REFERENCES PACIENTE(id_paciente),
    FOREIGN KEY (id_origen) REFERENCES ORIGEN_INTERNACION(id_origen),
    FOREIGN KEY (id_destino) REFERENCES DESTINO_EGRESO(id_destino),
    FOREIGN KEY (id_infeccion) REFERENCES INFECCIONES(id_infeccion),
    FOREIGN KEY (id_obstructiva) REFERENCES OBSTRUCTIVAS(id_obstructiva),
    FOREIGN KEY (id_intersticial) REFERENCES INTERSTICIALES(id_intersticial),
    FOREIGN KEY (id_pleura) REFERENCES PLEURA (id_pleura),
    FOREIGN KEY (id_vascular) REFERENCES VASCULARES (id_vascular),
    FOREIGN KEY (id_oncologica) REFERENCES ONCOLOGICAS (id_oncologica), 
    FOREIGN KEY (id_otro) REFERENCES OTROS (id_otro),
    FOREIGN KEY (id_insuficiencia) REFERENCES INSUFICIENCIA_RESPIRATORIA(id_insuficiencia),
    FOREIGN KEY (id_soporte) REFERENCES SOPORTE_RESPIRATORIO(id_soporte),
    FOREIGN KEY (id_tabaquismo) REFERENCES TABAQUISMO(id_tabaquismo)
);
GO

-- 4. TABLAS DE CONEXION (RELACIONES MUCHOS A MUCHOS)
CREATE TABLE PACIENTE_EXPOSICION (
    id_paciente INT NOT NULL,
    id_exposicion INT NOT NULL,
    PRIMARY KEY (id_paciente, id_exposicion),
    FOREIGN KEY (id_paciente) REFERENCES PACIENTE(id_paciente),
    FOREIGN KEY (id_exposicion) REFERENCES EXPOSICION_AMBIENTAL(id_exposicion)
);
GO

CREATE TABLE PACIENTE_ANTECEDENTE (
    id_paciente INT NOT NULL,
    id_antecedente INT NOT NULL,
    PRIMARY KEY (id_paciente, id_antecedente),
    FOREIGN KEY (id_paciente) REFERENCES PACIENTE(id_paciente),
    FOREIGN KEY (id_antecedente) REFERENCES ANTECEDENTE_RESPIRATORIO(id_antecedente)
);
GO

CREATE TABLE PACIENTE_COMORBILIDAD (
    id_paciente INT NOT NULL,
    id_comorbilidad INT NOT NULL,
    PRIMARY KEY (id_paciente, id_comorbilidad),
    FOREIGN KEY (id_paciente) REFERENCES PACIENTE(id_paciente),
    FOREIGN KEY (id_comorbilidad) REFERENCES COMORBILIDAD(id_comorbilidad)
);
GO 

