--Trigger para eliminar en cascada a un repartidor
--de la base de datos. Antes de borrar el repartidor
--se borran los numeros de telefono correspondientes al
--repartidor a borrar en la tabla de repartidor_telefonos

CREATE OR REPLACE FUNCTION DELETE_REPARTIDOR_REL() 
   RETURNS TRIGGER 
   LANGUAGE PLPGSQL
AS $$
BEGIN
   DELETE FROM REPARTIDOR_TELEFONOS
   WHERE USUARIO_REPART = OLD.USUARIO_REPART;
   RETURN OLD;
END;
$$

CREATE OR REPLACE TRIGGER BEFORE_REPARTIDOR_DELETE
   BEFORE DELETE
   ON REPARTIDOR
   FOR EACH ROW
       EXECUTE PROCEDURE DELETE_REPARTIDOR_REL();