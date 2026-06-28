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
('VNI+Alto flujo');

INSERT INTO ANTECEDENTE_RESPIRATORIO (descripcion) VALUES
('EPOC (Enfermedad pulmonar obstructiva cronica)'),
('Asma'),
('Bronquiectasias'),
('EPD (Enfermedad pulmonar difusa)'),
('Tuberculosis previa'),
('Cancer de pulmon'),
('Oxigeno domiciliario'),
('VNI domiciliaria');

INSERT INTO SECUELA (descripcion) values
('Secuela postinfecciosa'),
('Secuela postraumatica'),
('Secuela post-TBC'),
('Otra secuela pulmonar');

INSERT INTO CIRUGIA (descripcion) VALUES
('Lobectomía'),
('Segmentectomía'),
('Neumonectomía'),
('Tubo de avenamiento pleural'),
('Toracotomía'),
('Toracoscopía'),
('Otra resección pulmonar');

INSERT INTO EXPOSICION_AMBIENTAL (descripcion) VALUES
('Humo de leña'),
('Biomasa'),
('Aves'),
('Silice / Marmol / Granito'),
('Asbesto'),
('Otra exposicion relevante');

INSERT INTO COMORBILIDAD_CARDIOVASCULAR (descripcion) VALUES
('HTA (Hipertensión arterial)'),
('Insuficiencia cardíaca'),
('Arritmias'),
('Cardiopatía isquémica'),
('Hipertensión pulmonar'),
('TEP previo');

INSERT INTO COMORBILIDAD_METABOLICA (descripcion) VALUES
('Diabetes'),
('Obesidad'); 
INSERT INTO COMORBILIDAD_NEUROLOGICA (descripcion) VALUES
('ACV previo'),
('Enfermedad neuromuscular');

INSERT INTO COMORBILIDAD_SUEÑO (descripcion) VALUES
('SAOS (Sindrome de apnea obstructiva del sueño)'),
('Sindrome obesidad-hipoventilacion');

INSERT INTO COMORBILIDAD_INMUNOLOGICA (descripcion) VALUES
('Enfermedad reumatologica'),
('Inmunosuprimido'),
('HIV');
INSERT INTO COMORBILIDAD_ONCOLOGICA (descripcion) VALUES
('Neoplasia extrapulmonar activa');
GO

---Enfermedades 
INSERT INTO DIAGNOSTICO_INFECCIONES(descripcion) VALUES
('Ninguna'),
('NAC (Neumonia adquirida en la comunidad)'),
('Neumonia intrahospitalaria'),
('Tuberculosis'),
('Infeccion viral'),
('Infeccion fungica'); 


INSERT INTO DIAGNOSTICO_OBSTRUCTIVAS(descripcion) VALUES 
('Ninguna'),
('Exacerbación de EPOC'),
('Exacerbación de asma'),
('Exacerbación de bronquiectasias'),
('Exacerbación de patología obstructiva de la vía aérea'); 

INSERT INTO DIAGNOSTICO_INTERSTICIALES(descripcion) VALUES 
('Ninguna'),
('Exacerbación aguda de EPD'),
('EPD sobreinfectada'),
('EPD progresiva'),
('Hemorragia alveolar');

INSERT INTO DIAGNOSTICO_PLEURA(descripcion) VALUES 
('Ninguna'),
('Derrame pleural'),
('Empiema'),
('Neumotorax'); 

INSERT INTO DIAGNOSTICO_VASCULARES(descripcion) VALUES 
('Ninguna'),
('TEP'),
('Hipertension pulmonar'), 
('Hemoptisis');


INSERT INTO DIAGNOSTICO_ONCOLOGICAS(descripcion) VALUES 
('Ninguna'),
('Neoplasia pulmonar activa'),
('Masa pulmonar en estudio'),
('Complicacion oncologica'); 

INSERT INTO DIAGNOSTICO_OTROS(descripcion) VALUES 
('Ninguna'),
('Neumomediastino'),
('Estudio diagnostico'),
('Manejo del dolor'),
('Cuidados paliativos'); 

-- Usuarios
INSERT INTO USUARIO (usuario, pass, email, esAdmin, activo) VALUES
('admin', 'admin123', 'admin@hospital.com', 1, 1),
('usuario', 'usuario123', 'usuario@hospital.com', 0, 1);
GO

-- Pacientes
INSERT INTO PACIENTE (dni, nombre, apellido, fecha_nacimiento, domicilio, telefono) VALUES
('20111222', 'Juan', 'Perez', '1965-05-10', 'Av. Siempre Viva 123', '11111111'),
('22333444', 'Maria', 'Gomez', '1978-08-21', 'Calle Falsa 456', '22222222'),
('30123456', 'Carlos', 'Fernandez', '1952-01-15', 'Belgrano 789', '33333333'),
('28999888', 'Ana', 'Rodriguez', '1985-12-03', 'San Martin 555', '44444444'),
('31555444','Luis','Martinez','1958-07-12','Av Colon 100','5551111'), 
('28777111','Laura','Suarez','1972-10-05','Mitre 234','5552222'), 
('33444555','Pedro','Lopez','1949-11-30','Sarmiento 456','5553333'), 
('29888777','Silvia','Alvarez','1969-01-18','Belgrano 789','5554444'), 
('35666999','Diego','Ruiz','1980-03-21','Italia 456','5555555'), 
('27111222','Marta','Sosa','1955-08-14','Roca 123','5556666'), 
('32222333','Oscar','Torres','1962-06-09','French 456','5557777'), 
('29999111','Patricia','Acosta','1976-09-28','Brown 222','5558888');
GO

-- Relaciones de Exposición Ambiental
INSERT INTO PACIENTE_EXPOSICION_AMBIENTAL (id_paciente, id_exposicion) VALUES 
(1, 1), -- Juan: Humo de leña
(3, 2), -- Carlos: Aves
(3, 4); -- Carlos: Asbesto


-- ============================================================
-- HISTORIAL DE INTERNACIONES
-- Una internación por cada paciente de prueba
-- ============================================================

INSERT INTO INTERNACION
(
    id_paciente,
    fecha_ingreso,
    fecha_egreso,
    id_origen,
    id_destino,
    id_infeccion,
    id_obstructiva,
    id_intersticial,
    id_pleura,
    id_vascular,
    id_oncologica,
    id_otro,
    id_insuficiencia,
    id_soporte,
    id_tabaquismo,
    paquetes_anio
)
VALUES

-- Paciente 1
(1,
'2026-05-01',
'2026-05-10',
1,
1,
6,
1,
NULL,
NULL,
NULL,
NULL,
NULL,
1,
2,
3,
40),

-- Paciente 2
(2,
'2026-04-12',
'2026-04-18',
2,
2,
NULL,
2,
NULL,
NULL,
NULL,
NULL,
NULL,
2,
1,
2,
25),

-- Paciente 3
(3,
'2026-03-20',
'2026-04-05',
3,
5,
NULL,
NULL,
1,
NULL,
NULL,
NULL,
NULL,
1,
3,
1,
60),

-- Paciente 4
(4,
'2026-02-08',
'2026-02-15',
1,
1,
NULL,
NULL,
NULL,
1,
NULL,
NULL,
NULL,
2,
2,
3,
15);

GO

-- ============================================================
-- COMORBILIDADES DE LOS PACIENTES (Datos de prueba)
-- ============================================================

INSERT INTO PACIENTE_COMORBILIDAD_CARDIOVASCULAR
(id_paciente, id_cardiovascular)
VALUES
(1,1), -- Juan: HTA
(2,2), -- María: Insuficiencia cardíaca
(3,1), -- Carlos: HTA
(4,3); -- Ana: arritmias


INSERT INTO PACIENTE_COMORBILIDAD_METABOLICA
(id_paciente, id_metabolica)
VALUES
(1,1), -- Diabetes
(4,2); -- Obesidad


INSERT INTO PACIENTE_COMORBILIDAD_NEUROLOGICA
(id_paciente, id_neurologico)
VALUES
(3,1); -- ACV previo


INSERT INTO PACIENTE_COMORBILIDAD_SUEÑO
(id_paciente, id_sueño)
VALUES
(2,1); -- SAOS


INSERT INTO PACIENTE_COMORBILIDAD_INMUNOLOGICA
(id_paciente, id_inmunologica)
VALUES
(4,2); -- Inmunosuprimido


INSERT INTO PACIENTE_COMORBILIDAD_ONCOLOGICA
(id_paciente, id_oncologica)
VALUES
(3,1); -- Neoplasia extrapulmonar activa

GO


-- ==========================================
-- REINTERNACIONES PARA PRUEBAS DE REPORTES
-- ==========================================

INSERT INTO INTERNACION
(id_paciente,fecha_ingreso,fecha_egreso,id_origen,id_destino,
id_infeccion,id_obstructiva,id_intersticial,id_pleura,
id_vascular,id_oncologica,id_otro,id_insuficiencia,
id_soporte,id_tabaquismo,paquetes_anio)
VALUES

-- Juan
(1,'2025-01-15','2025-01-22',1,1,NULL,1,NULL,NULL,NULL,NULL,NULL,1,1,3,40),
(1,'2025-09-02','2025-09-10',2,5,6,NULL,NULL,NULL,NULL,NULL,NULL,2,4,3,40),

-- Maria
(2,'2025-02-08','2025-02-14',1,1,1,NULL,NULL,NULL,NULL,NULL,NULL,1,2,2,25),
(2,'2025-11-18','2025-11-26',1,2,NULL,2,NULL,NULL,NULL,NULL,NULL,2,3,2,25),

-- Carlos
(3,'2024-07-10','2024-07-18',2,1,NULL,NULL,1,NULL,NULL,NULL,NULL,1,3,1,60),
(3,'2025-03-03','2025-03-12',3,5,NULL,NULL,NULL,1,NULL,NULL,NULL,2,4,1,60),
(3,'2025-12-01','2025-12-15',1,1,NULL,NULL,NULL,NULL,1,NULL,NULL,1,2,1,60),

-- Ana
(4,'2025-05-20','2025-05-28',1,1,NULL,NULL,NULL,NULL,NULL,1,NULL,1,1,3,15),
(4,'2025-10-10','2025-10-18',2,2,NULL,NULL,NULL,NULL,NULL,NULL,1,2,2,3,15),

-- Luis
(5,'2025-06-01','2025-06-08',1,1,6,NULL,NULL,NULL,NULL,NULL,NULL,1,2,2,20),
(5,'2025-12-20','2025-12-29',2,1,NULL,1,NULL,NULL,NULL,NULL,NULL,2,3,2,20);
GO



