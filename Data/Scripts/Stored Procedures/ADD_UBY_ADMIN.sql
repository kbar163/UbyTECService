--Procedimiento almacenado creado en la base de datos
-- ubytecdb
--Entradas:
-- Todos los datos correspondientes a los atributos
--del administrador uby en la base de datos, mas
--un atributo de numero telefonico que se inserta en
-- la tabla admin_uby_telefonos
--Proceso: Se hace un insert con todos los datos
--del administrador en la tabla administrador_uby,
--seguido de un insert del numero de telefono y cedula
--del administrador_uby en la tabla admin_uby telefonos
-- Ejemplo de llamada : 
--CALL ADD_UBY_ADMIN('304930544','Kevin','Barrantes', 'Cerdas','kabarrantes163@gmail.com','kbar','password01','Cartago','Paraiso', 'Orosi','88888888')

--Procedimiento para caso en el que solo hay un numero telefonico
CREATE OR REPLACE PROCEDURE ADD_UBY_ADMIN(
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
INSERT INTO ADMINISTRADOR_UBY
VALUES
(CEDULA_ADMIN_U,NOMBRE_ADMIN_U,APELLIDO1_ADMIN_U,APELLIDO2_ADMIN_U,
CORREO_ADMIN_U,USR_ADMIN_U,PASS_ADMIN_U,PROVINCIA_ADMIN_U,CANTON_ADMIN_U,
DISTRITO_ADMIN_U);

INSERT INTO ADMIN_UBY_TELEFONOS
VALUES
(DEFAULT,CEDULA_ADMIN_U,TELEFONO_ADMIN_U);
end; $$

--Procedimiento para caso en el que hay 2 numeros telefonicos
CREATE OR REPLACE PROCEDURE ADD_UBY_ADMIN(
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
INSERT INTO ADMINISTRADOR_UBY
VALUES
(CEDULA_ADMIN_U,NOMBRE_ADMIN_U,APELLIDO1_ADMIN_U,APELLIDO2_ADMIN_U,
CORREO_ADMIN_U,USR_ADMIN_U,PASS_ADMIN_U,PROVINCIA_ADMIN_U,CANTON_ADMIN_U,
DISTRITO_ADMIN_U);

INSERT INTO ADMIN_UBY_TELEFONOS
VALUES
(DEFAULT,CEDULA_ADMIN_U,TELEFONO_ADMIN_U_1),
(DEFAULT,CEDULA_ADMIN_U,TELEFONO_ADMIN_U_2);

end; $$
