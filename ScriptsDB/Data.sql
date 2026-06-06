USE INTERNACION_NEUMOLOGICA_DB;
GO

-- 1. CARGA DE TABLAS DE CONFIGURACIÓN / PARÁMETROS MÉDICOS

INSERT INTO TABAQUISMO (descripcion) VALUES
('Nunca fumo'),
('Exfumador'),
('Fumador activo');

INSERT INTO ORIGEN_INTERNACION (descripcion) VALUES
('Guardia'),
('UTI'),
('Cirugia'),
('Otro hospital');

INSERT INTO DESTINO_EGRESO (descripcion) VALUES
('Domicilio'),
('UTI'),
('Cirugia'),
('Otra institucion'),
('Fallecimiento');

INSERT INTO INSUFICIENCIA_RESPIRATORIA (descripcion) VALUES
('No'),
('Hipoxemica'),
('Hipercapnica'),
('Mixta');

INSERT INTO SOPORTE_RESPIRATORIO (descripcion) VALUES
('Ninguno'),
('Oxigeno'),
('Alto flujo'),
('VNI'),
('ARM');


go

INSERT INTO ANTECEDENTE_RESPIRATORIO (descripcion) VALUES
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

INSERT INTO EXPOSICION_AMBIENTAL (descripcion) VALUES
('Humo de leña'),
('Aves'),
('Silice / Marmol / Granito'),
('Asbesto'),
('Otra exposicion relevante');

INSERT INTO COMORBILIDAD (descripcion) VALUES
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

-- 2. CARGA DE USUARIOS

-- Usuarios
INSERT INTO USUARIO (usuario, pass, esAdmin) VALUES
('admin', 'admin123', 1),
('usuario', 'usuario123', 0);

-- 3. CARGA DE DATOS DE PRUEBA (MOCKS)

-- Pacientes
INSERT INTO PACIENTE (dni, nombre, apellido, fecha_nacimiento, domicilio, telefono) VALUES
('20111222', 'Juan', 'Perez', '1965-05-10', 'Av. Siempre Viva 123', '11111111'),
('22333444', 'Maria', 'Gomez', '1978-08-21', 'Calle Falsa 456', '22222222'),
('30123456', 'Carlos', 'Fernandez', '1952-01-15', 'Belgrano 789', '33333333'),
('28999888', 'Ana', 'Rodriguez', '1985-12-03', 'San Martin 555', '44444444');
GO

-- Relaciones de Exposición Ambiental
INSERT INTO PACIENTE_EXPOSICION (id_paciente, id_exposicion) VALUES 
(1, 1), -- Juan: Humo de leña
(3, 2), -- Carlos: Aves
(3, 4); -- Carlos: Asbesto

-- Relaciones de Antecedentes Respiratorios
INSERT INTO PACIENTE_ANTECEDENTE (id_paciente, id_antecedente) VALUES 
(1, 1), -- Juan: EPOC
(1, 7), -- Juan: Oxigeno dom.
(2, 2), -- Maria: Asma
(3, 4), -- Carlos: EPD
(3, 15);-- Carlos: Neumonectomia

-- Relaciones de Comorbilidades
INSERT INTO PACIENTE_COMORBILIDAD (id_paciente, id_comorbilidad) VALUES 
(1, 1), -- Juan: HTA
(1, 7), -- Juan: Diabetes
(2, 8), -- Maria: Obesidad
(3, 13);-- Carlos: Enf reumatologica

-- Historial de Internaciones
INSERT INTO INTERNACION (id_paciente, fecha_ingreso, fecha_egreso, id_origen, id_destino, id_infeccion,id_obstructiva,id_intersticial,id_pleura,id_vascular,id_oncologica,id_otro, id_insuficiencia, id_soporte, id_tabaquismo, paquetes_anio) VALUES
(1, '2026-05-01', '2026-05-10', 1, 1, 6, 1,1,1,1,1,1,1,2, 3, 40)
--(2, '2026-04-12', '2026-04-15', 1, 1, 7, 1, 1, 2, 25),
--(3, '2026-03-20', '2026-04-05', 4, 4, 9, 4, 4, 1, NULL);
GO 


---Enfermedades 
INSERT INTO INFECCIONES(descripcion) VALUES
('Ninguna'),
('NAC (Neumonia adquirida en la comunidad)'),
('Neumonia intrahospitalaria'),
('Tuberculosis'),
('Infeccion viral'),
('Infeccion fungica'); 

go

INSERT INTO OBSTRUCTIVAS(descripcion) VALUES 
('Ninguna'),
('Exacerbacion de EPOC'),
('Exacerbacion de asma'),
('Exacerbacion de bronquiectasias'); 
go

INSERT INTO INTERSTICIALES(descripcion) VALUES 
('Ninguna'),
('Exacerbacion aguda de EPD'),
('EPD progresiva'),
('Hemorragia alveolar');

go
INSERT INTO PLEURA(descripcion) VALUES 
('Ninguna'),
('Derrame pleural'),
('Empiema'),
('Neumotorax'); 

go 
INSERT INTO VASCULARES(descripcion) VALUES 
('Ninguna'),
('TEP'),
('Hipertension pulmonar'); 

go 
INSERT INTO ONCOLOGICAS(descripcion) VALUES 
('Ninguna'),
('Masa pulmonar en estudio'),
('Complicacion oncologica'); 


go 
INSERT INTO OTROS(descripcion) VALUES 
('Ninguna'),
('Estudio diagnostico'),
('Manejo del dolor'),
('Cuidados paliativos'); 




