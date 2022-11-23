--Stored procedure utilizado para confirmar que un cliente recibio una orden
--pone en disponible al repartidor y marca el pedido como 
--finalizado.

CREATE OR REPLACE PROCEDURE CONFIRM_ORDER(
	ID_ORDER_SP INT)
language plpgsql
as $$
begin
-- stored procedure body
UPDATE REPARTIDOR SET
	DISPONIBLE = TRUE
	WHERE USUARIO_REPART = (SELECT USUARIO_REPART FROM PEDIDO WHERE ID_PEDIDO = ID_ORDER_SP);

UPDATE PEDIDO SET
	ID_ESTADO = 3
	WHERE ID_PEDIDO = ID_ORDER_SP;
end; $$