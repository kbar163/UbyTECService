--Funcion creada en la base de datos ubytecdb
--Entradas:
--UBY_ADMIN_USR es un nombre de usuario a buscar en la tabla ADMINISTRADOR_UBY
--UBY_ADMIN_PSW es un password a buscar en la tabla de ADMINISTRADOR_UBY
--Salida: Un valor booleano
--Proceso: Se selecciona de la tabla de ADMINISTRADOR_UBY, el USUARIO_ADMIN_UBY y PASSWORD_ADMIN_UBY
--que haga match con los parametros de entrada, si encuentra un par de valores a seleccionar, retorna True,
--de lo contrario, retorna False.

CREATE OR REPLACE FUNCTION VALIDATE_UBY_ADMIN_CREDENTIALS(UBY_ADMIN_USR VARCHAR(50),UBY_ADMIN_PSW VARCHAR(50))
RETURNS BOOLEAN
LANGUAGE 'plpgsql'

AS
$BODY$
BEGIN
	PERFORM ADMINISTRADOR_UBY.USUARIO_ADMIN_UBY,ADMINISTRADOR_UBY.PASSWORD_ADMIN_UBY
	FROM ADMINISTRADOR_UBY
	WHERE ADMINISTRADOR_UBY.USUARIO_ADMIN_UBY = UBY_ADMIN_USR
	AND ADMINISTRADOR_UBY.PASSWORD_ADMIN_UBY = UBY_ADMIN_PSW;
	RETURN FOUND;
END
$BODY$;