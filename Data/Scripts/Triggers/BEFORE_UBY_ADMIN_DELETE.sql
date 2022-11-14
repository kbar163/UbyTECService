--Trigger para eliminar en cascada a un administrador
--uby de la base de datos. Antes de borrar el administrador
--se borran los numeros de telefono correspondientes al
--administrador a borrar en la tabla de admin_uby_telefonos

CREATE OR REPLACE FUNCTION DELETE_UBY_ADMIN_REL() 
   RETURNS TRIGGER 
   LANGUAGE PLPGSQL
AS $$
BEGIN
   DELETE FROM ADMIN_UBY_TELEFONOS
   WHERE CEDULA_ADMIN_UBY = OLD.CEDULA_ADMIN_UBY;
   RETURN OLD;
END;
$$

CREATE OR REPLACE TRIGGER BEFORE_UBY_ADMIN_DELETE
   BEFORE DELETE
   ON ADMINISTRADOR_UBY
   FOR EACH ROW
       EXECUTE PROCEDURE DELETE_UBY_ADMIN_REL();