CREATE OR REPLACE PROCEDURE UPDATE_PRODUCT(id_producto_sp integer,nombre_producto_sp character varying,url_sp character varying,precio_sp integer,id_categoria_sp integer)
    LANGUAGE 'plpgsql'
    
AS $BODY$
begin
-- stored procedure body
UPDATE PRODUCTO
SET
NOMBRE_PRODUCTO = NOMBRE_PRODUCTO_SP,
URL_FOTO = URL_SP,
PRECIO = PRECIO_SP,
ID_CATEGORIA = ID_CATEGORIA_SP
WHERE ID_PRODUCTO = ID_PRODUCTO_SP;

end;
$BODY$;