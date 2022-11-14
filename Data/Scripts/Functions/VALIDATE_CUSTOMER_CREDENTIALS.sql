--Funcion creada en la base de datos ubytecdb
--Entradas:
--CUSTOMER_USR es un nombre de usuario a buscar en la tabla CLIENTE
--CUSTOMER_PSW es un password a buscar en la tabla de CLIENTE
--Salida: Un valor booleano
--Proceso: Se selecciona de la tabla de CLIENTE, el USUARIO_CLIENTE y PASSWORD_CLIENTE
--que haga match con los parametros de entrada, si encuentra un par de valores a seleccionar, retorna True,
--de lo contrario, retorna False.

CREATE OR REPLACE FUNCTION VALIDATE_CUSTOMER_CREDENTIALS(CUSTOMER_USR VARCHAR(50),CUSTOMER_PSW VARCHAR(50))
RETURNS BOOLEAN
LANGUAGE 'plpgsql'

AS
$BODY$
BEGIN
	PERFORM CLIENTE.USUARIO_CLIENTE,CLIENTE.PASSWORD_CLIENTE
	FROM CLIENTE
	WHERE CLIENTE.USUARIO_CLIENTE = CUSTOMER_USR
	AND CLIENTE.PASSWORD_CLIENTE = CUSTOMER_PSW;
	RETURN FOUND;
END
$BODY$;