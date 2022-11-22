CREATE OR REPLACE FUNCTION DELETE_CLIENTE_REL() 
   RETURNS TRIGGER 
   LANGUAGE PLPGSQL
AS $$
BEGIN
   DELETE FROM CLIENTE_TELEFONOS
   WHERE CEDULA_CLIENTE = OLD.CEDULA_CLIENTE;
   RETURN OLD;
END;
$$

CREATE OR REPLACE TRIGGER BEFORE_CLIENTE_DELETE
   BEFORE DELETE
   ON CLIENTE
   FOR EACH ROW
       EXECUTE PROCEDURE DELETE_CLIENTE_REL();