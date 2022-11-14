--Procedimiento almacenado creado en la base de datos
-- ubytecdb
--Entradas:
-- Todos los datos correspondientes a los atributos
--del administrador uby en la base de datos, mas
--un atributo de numero telefonico que se actualiza en
-- la tabla admin_uby_telefonos
--Proceso: Se hace un update con todos los datos
--del administrador en la tabla administrador_uby,
--seguido de un update del numero de telefono en la tabla admin_uby telefonos

--Procedimiento para caso en el que solo hay un numero telefonico
CREATE OR REPLACE PROCEDURE UPDATE_UBY_ADMIN(
	CEDULA_ADMIN_U VARCHAR(9),
	NOMBRE_ADMIN_U VARCHAR(50),
	APELLIDO1_ADMIN_U VARCHAR(50),
	APELLIDO2_ADMIN_U VARCHAR(50),
	CORREO_ADMIN_U VARCHAR(50),
	USR_ADMIN_U VARCHAR(50),
	PASS_ADMIN_U VARCHAR(50),
	PROVINCIA_ADMIN_U VARCHAR(50),
	CANTON_ADMIN_U VARCHAR(50),
	DISTRITO_ADMIN_U VARCHAR(50),
	TELEFONO_ADMIN_U_1 VARCHAR(8))
language plpgsql
as $$
begin
-- stored procedure body
UPDATE ADMINISTRADOR_UBY
SET
NOMBRE = NOMBRE_ADMIN_U,
PRIMER_APELLIDO = APELLIDO1_ADMIN_U,
SEGUNDO_APELLIDO = APELLIDO2_ADMIN_U,
CORREO_ELECTRONICO = CORREO_ADMIN_U,
USUARIO_ADMIN_UBY = USR_ADMIN_U,
PASSWORD_ADMIN_UBY = PASS_ADMIN_U,
PROVINCIA = PROVINCIA_ADMIN_U,
CANTON = CANTON_ADMIN_U,
DISTRITO = DISTRITO_ADMIN_U

WHERE CEDULA_ADMIN_UBY = CEDULA_ADMIN_U;

DELETE FROM ADMIN_UBY_TELEFONOS WHERE CEDULA_ADMIN_UBY = CEDULA_ADMIN_U;

INSERT INTO ADMIN_UBY_TELEFONOS
VALUES
(DEFAULT,CEDULA_ADMIN_U,TELEFONO_ADMIN_U_1);
end; $$

--Procedimiento para caso en el que hay dos numeros telefonico
CREATE OR REPLACE PROCEDURE UPDATE_UBY_ADMIN(
	CEDULA_ADMIN_U VARCHAR(9),
	NOMBRE_ADMIN_U VARCHAR(50),
	APELLIDO1_ADMIN_U VARCHAR(50),
	APELLIDO2_ADMIN_U VARCHAR(50),
	CORREO_ADMIN_U VARCHAR(50),
	USR_ADMIN_U VARCHAR(50),
	PASS_ADMIN_U VARCHAR(50),
	PROVINCIA_ADMIN_U VARCHAR(50),
	CANTON_ADMIN_U VARCHAR(50),
	DISTRITO_ADMIN_U VARCHAR(50),
	TELEFONO_ADMIN_U_1 VARCHAR(8),
	TELEFONO_ADMIN_U_2 VARCHAR(8))
language plpgsql
as $$
begin
-- stored procedure body
UPDATE ADMINISTRADOR_UBY
SET
NOMBRE = NOMBRE_ADMIN_U,
PRIMER_APELLIDO = APELLIDO1_ADMIN_U,
SEGUNDO_APELLIDO = APELLIDO2_ADMIN_U,
CORREO_ELECTRONICO = CORREO_ADMIN_U,
USUARIO_ADMIN_UBY = USR_ADMIN_U,
PASSWORD_ADMIN_UBY = PASS_ADMIN_U,
PROVINCIA = PROVINCIA_ADMIN_U,
CANTON = CANTON_ADMIN_U,
DISTRITO = DISTRITO_ADMIN_U

WHERE CEDULA_ADMIN_UBY = CEDULA_ADMIN_U;

DELETE FROM ADMIN_UBY_TELEFONOS WHERE CEDULA_ADMIN_UBY = CEDULA_ADMIN_U;

INSERT INTO ADMIN_UBY_TELEFONOS
VALUES
(DEFAULT,CEDULA_ADMIN_U,TELEFONO_ADMIN_U_1),
(DEFAULT,CEDULA_ADMIN_U,TELEFONO_ADMIN_U_2);
end; $$