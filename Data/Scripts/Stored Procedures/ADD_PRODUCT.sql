CREATE OR REPLACE PROCEDURE ADD_PRODUCT(
	NOMBRE_PRODUCTO_SP VARCHAR(50),
	URL_SP VARCHAR(300),
	PRECIO_SP INT,
	CEDULA_JURIDICA_SP VARCHAR(12),
	ID_CATEGORIA_SP INT)
	
language plpgsql
as $$
begin
-- stored procedure body
INSERT INTO PRODUCTO
VALUES
(DEFAULT,NOMBRE_PRODUCTO_SP,URL_SP,PRECIO_SP,CEDULA_JURIDICA_SP,ID_CATEGORIA_SP);

end; $$