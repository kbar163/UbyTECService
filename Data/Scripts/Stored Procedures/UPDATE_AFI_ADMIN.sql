CREATE OR REPLACE PROCEDURE UPDATE_AFI_ADMIN(
	NOMBRE_ADMIN_AFI VARCHAR(50),
	APELLIDO1_ADMIN_AFI VARCHAR(50),
	APELLIDO2_ADMIN_AFI VARCHAR(50),
	CORREO_ADMIN_AFI VARCHAR(50),
	USR_ADMIN_AFI VARCHAR(50),
	PASS_ADMIN_AFI VARCHAR(50),
	PROVINCIA_ADMIN_AFI VARCHAR(50),
	CANTON_ADMIN_AFI VARCHAR(50),
	DISTRITO_ADMIN_AFI VARCHAR(50),
	TELEFONO_ADMIN_AFI_1 VARCHAR(8))
language plpgsql
as $$
begin
-- stored procedure body
UPDATE ADMINISTRADOR_AFILIADO
SET
NOMBRE = NOMBRE_ADMIN_AFI,
PRIMER_APELLIDO = APELLIDO1_ADMIN_AFI,
SEGUNDO_APELLIDO = APELLIDO2_ADMIN_AFI,
CORREO_ELECTRONICO = CORREO_ADMIN_AFI,
USUARIO_ADMIN_AFI = USR_ADMIN_AFI,
PASSWORD_ADMIN_AFI = PASS_ADMIN_AFI,
PROVINCIA = PROVINCIA_ADMIN_AFI,
CANTON = CANTON_ADMIN_AFI,
DISTRITO = DISTRITO_ADMIN_AFI
WHERE USUARIO_ADMIN_AFI = USR_ADMIN_AFI;

DELETE FROM ADMIN_AFI_TELEFONOS WHERE USUARIO_ADMIN_AFI = USR_ADMIN_AFI;
INSERT INTO ADMIN_AFI_TELEFONOS
VALUES
(DEFAULT,USR_ADMIN_AFI,TELEFONO_ADMIN_AFI_1);
end; $$

--CASO PARA 2 TELEFONOS
CREATE OR REPLACE PROCEDURE UPDATE_AFI_ADMIN(
	NOMBRE_ADMIN_AFI VARCHAR(50),
	APELLIDO1_ADMIN_AFI VARCHAR(50),
	APELLIDO2_ADMIN_AFI VARCHAR(50),
	CORREO_ADMIN_AFI VARCHAR(50),
	USR_ADMIN_AFI VARCHAR(50),
	PASS_ADMIN_AFI VARCHAR(50),
	PROVINCIA_ADMIN_AFI VARCHAR(50),
	CANTON_ADMIN_AFI VARCHAR(50),
	DISTRITO_ADMIN_AFI VARCHAR(50),
	TELEFONO_ADMIN_AFI_1 VARCHAR(8),
	TELEFONO_ADMIN_AFI_2 VARCHAR(8))
language plpgsql
as $$
begin
-- stored procedure body
UPDATE ADMINISTRADOR_AFILIADO
SET
NOMBRE = NOMBRE_ADMIN_AFI,
PRIMER_APELLIDO = APELLIDO1_ADMIN_AFI,
SEGUNDO_APELLIDO = APELLIDO2_ADMIN_AFI,
CORREO_ELECTRONICO = CORREO_ADMIN_AFI,
USUARIO_ADMIN_AFI = USR_ADMIN_AFI,
PASSWORD_ADMIN_AFI = PASS_ADMIN_AFI,
PROVINCIA = PROVINCIA_ADMIN_AFI,
CANTON = CANTON_ADMIN_AFI,
DISTRITO = DISTRITO_ADMIN_AFI
WHERE USUARIO_ADMIN_AFI = USR_ADMIN_AFI;

DELETE FROM ADMIN_AFI_TELEFONOS WHERE USUARIO_ADMIN_AFI = USR_ADMIN_AFI;
INSERT INTO ADMIN_AFI_TELEFONOS
VALUES
(DEFAULT,USR_ADMIN_AFI,TELEFONO_ADMIN_AFI_1),
(DEFAULT,USR_ADMIN_AFI,TELEFONO_ADMIN_AFI_2);
end; $$