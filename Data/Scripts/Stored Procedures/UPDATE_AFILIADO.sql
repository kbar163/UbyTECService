CREATE OR REPLACE PROCEDURE UPDATE_AFILIADO(
	CEDULA_JURIDICA_SP VARCHAR(12),
	NOMBRE_AFILIADO_SP VARCHAR(50),
	SINPE_SP VARCHAR(8),
	CORREO_AFILIADO_SP VARCHAR(50),
	PROVINCIA_AFILIADO_SP VARCHAR(50),
	CANTON_AFILIADO_SP VARCHAR(50),
	DISTRITO_AFILIADO_SP VARCHAR(50),
	TIPO_AFILIADO_SP INT,
	TELEFONO_AFILIADO_1_SP VARCHAR(8))
	
language plpgsql
as $$
begin
-- stored procedure body
UPDATE AFILIADO
SET
CEDULA_JURIDICA = CEDULA_JURIDICA_SP,
NOMBRE_COMERCIO = NOMBRE_AFILIADO_SP,
SINPE_MOVIL = SINPE_SP,
CORREO = CORREO_AFILIADO_SP,
PROVINCIA = PROVINCIA_AFILIADO_SP,
CANTON = CANTON_AFILIADO_SP,
DISTRITO = DISTRITO_AFILIADO_SP,
TIPO = TIPO_AFILIADO_SP

WHERE CEDULA_JURIDICA = CEDULA_JURIDICA_SP;
DELETE FROM AFILIADO_TELEFONOS WHERE CEDULA_JURIDICA = CEDULA_JURIDICA_SP;

INSERT INTO AFILIADO_TELEFONOS
VALUES
(DEFAULT,CEDULA_JURIDICA_SP,TELEFONO_AFILIADO_1_SP);
end; $$

--Caso para cuando hay 2 numeros de telefono
CREATE OR REPLACE PROCEDURE UPDATE_AFILIADO(
	CEDULA_JURIDICA_SP VARCHAR(12),
	NOMBRE_AFILIADO_SP VARCHAR(50),
	SINPE_SP VARCHAR(8),
	CORREO_AFILIADO_SP VARCHAR(50),
	PROVINCIA_AFILIADO_SP VARCHAR(50),
	CANTON_AFILIADO_SP VARCHAR(50),
	DISTRITO_AFILIADO_SP VARCHAR(50),
	TIPO_AFILIADO_SP INT,
	TELEFONO_AFILIADO_1_SP VARCHAR(8),
	TELEFONO_AFILIADO_2_SP VARCHAR(8))
	
language plpgsql
as $$
begin
-- stored procedure body
UPDATE AFILIADO
SET
CEDULA_JURIDICA = CEDULA_JURIDICA_SP,
NOMBRE_COMERCIO = NOMBRE_AFILIADO_SP,
SINPE_MOVIL = SINPE_SP,
CORREO = CORREO_AFILIADO_SP,
PROVINCIA = PROVINCIA_AFILIADO_SP,
CANTON = CANTON_AFILIADO_SP,
DISTRITO = DISTRITO_AFILIADO_SP,
TIPO = TIPO_AFILIADO_SP

WHERE CEDULA_JURIDICA = CEDULA_JURIDICA_SP;
DELETE FROM AFILIADO_TELEFONOS WHERE CEDULA_JURIDICA = CEDULA_JURIDICA_SP;

INSERT INTO AFILIADO_TELEFONOS
VALUES
(DEFAULT,CEDULA_JURIDICA_SP,TELEFONO_AFILIADO_1_SP),
(DEFAULT,CEDULA_JURIDICA_SP,TELEFONO_AFILIADO_2_SP);
end; $$