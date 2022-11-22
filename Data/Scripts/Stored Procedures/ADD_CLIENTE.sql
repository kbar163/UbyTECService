CREATE OR REPLACE PROCEDURE ADD_CLIENTE(
	CEDULA_CLIENTE_SP VARCHAR(9),
	NOMBRE_CLIENTE_SP VARCHAR(50),
	APELLIDO1_CLIENTE_SP VARCHAR(50),
	APELLIDO2_CLIENTE_SP VARCHAR(50),
	FECHA_NACIMIENTO_SP TIMESTAMP,
	CORREO_CLIENTE_SP VARCHAR(50),
	CLIENTE_USR_SP VARCHAR(50),
	PASS_CLIENTE_SP VARCHAR(50),
	PROVINCIA_CLIENTE_SP VARCHAR(50),
	CANTON_CLIENTE_SP VARCHAR(50),
	DISTRITO_CLIENTE_SP VARCHAR(50),
	TELEFONO_CLIENTE_SP_1 VARCHAR(8),
	TELEFONO_CLIENTE_SP_2 VARCHAR(8))
	
language plpgsql
as $$
begin
-- stored procedure body
INSERT INTO CLIENTE
VALUES
(CEDULA_CLIENTE_SP,NOMBRE_CLIENTE_SP,APELLIDO1_CLIENTE_SP,APELLIDO2_CLIENTE_SP,FECHA_NACIMIENTO_SP,
CORREO_CLIENTE_SP,CLIENTE_USR_SP,PASS_CLIENTE_SP,PROVINCIA_CLIENTE_SP,CANTON_CLIENTE_SP,DISTRITO_CLIENTE_SP);

INSERT INTO CLIENTE_TELEFONOS
VALUES
(DEFAULT,CEDULA_CLIENTE_SP,TELEFONO_CLIENTE_SP_1),
(DEFAULT,CEDULA_CLIENTE_SP,TELEFONO_CLIENTE_SP_2);
end; $$