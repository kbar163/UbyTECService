--Datos de prueba
INSERT INTO ADMINISTRADOR_UBY
VALUES
('304930544','Kevin', 'Barrantes', 'Cerdas','kabarrantes163@ubytec.com','kbar','password01','Cartago','Paraiso', 'Orosi');

INSERT INTO ADMIN_UBY_TELEFONOS
VALUES
(DEFAULT,'304930544','89734502'),
(DEFAULT,'304930544','88888888');

INSERT INTO ADMINISTRADOR_AFILIADO
VALUES
('Robert', 'Baratheon', 'Stormsend','bobbyb@sevenkingdoms.com','bobbyb','ak2Jk30a','San Jose','Montes de Oca', 'San Pedro',TRUE),
('Eddard', 'Stark', 'Winterfell','nedstark@sevenkingdoms.com','warden','vOmsdu397','San Jose','Montes de Oca', 'Sabanilla',TRUE);

INSERT INTO ADMIN_AFI_TELEFONOS
VALUES
(DEFAULT,'bobbyb','11111111'),
(DEFAULT,'warden','22222222');

INSERT INTO CLIENTE
VALUES
('333333333','Jamie', 'Lannister', 'CasterlyRock','01/01/1999','kingslayer@sevenkingdoms.com','kingslayer','mcnUlso23','San Jose','Montes de Oca', 'San Rafael'),
('444444444','Jon', 'Snow', 'Winterfell','01/01/1999','lordcommander@sevenkingdoms.com','nwatch','akInfpa02','San Jose','Montes de Oca', 'Mercedes');

INSERT INTO CLIENTE_TELEFONOS
VALUES
(DEFAULT,'333333333','55555555'),
(DEFAULT,'444444444','66666666');

INSERT INTO REPARTIDOR
VALUES
('herb82','Hernan','Barboza','Salguero','herbarboza@correo.com','kInf038n','San Jose','San Jose','San Jose',TRUE),
('Messi10','Lionel','Messi','Cuccittini','leomessi@correo.com','ciuaUIBH38','San Jose','San Jose','San Jose',TRUE);

INSERT INTO REPARTIDOR_TELEFONOS
VALUES
(DEFAULT,'herb82','78765456'),
(DEFAULT,'Messi10','10101010');

INSERT INTO TIPO_COMERCIO
VALUES
(DEFAULT,'Comida Rapida'),
(DEFAULT,'Bar/Restaurante'),
(DEFAULT,'Soda');

INSERT INTO AFILIADO
VALUES
('234543675458','Kurger Bing','86576439','servicio@kurgerbing.com','San Jose','San Jose','Zapote','sin comentario',true,1),
('347576803458','MacDonalz','86576439','servicio@macdonalz.com','San Jose','San Jose','Zapote','sin comentario',true,1);

INSERT INTO AFILIADO_ADMIN
VALUES
('234543675458','bobbyb',true),
('347576803458','warden',true);

INSERT INTO PEDIDO
VALUES
(DEFAULT,5000,1,'333333333','San Jose','Montes de Oca','San Rafael','234543675458','11-15-22 14:05:06.789',''),
(DEFAULT,3750,1,'444444444','San Jose','Montes de Oca','Mercedes','347576803458','11-15-22 14:05:06.789','');

INSERT INTO CATEGORIA
VALUES
(DEFAULT,'Hamburguesa');

INSERT INTO PRODUCTO
VALUES
(DEFAULT,'Guopper','https://media.istockphoto.com/id/927593762/photo/a-real-life-homemade-burger-what-hamburgers-really-look-like.jpg?s=612x612&w=0&k=20&c=GXg1R1u3VQqp2BrG03J_SM-tID8-yU0JUB3NU0s5E1I=',
 5000,'234543675458',1),
(DEFAULT,'smolMac','https://media.istockphoto.com/id/176601160/photo/ugly-burger.jpg?s=612x612&w=0&k=20&c=8CbeBeKc0pjy1Yy_3rh3i_XJoD9Ao3YhQSraKFgxCvI=',
 3750,'347576803458',1);
 
INSERT INTO PEDIDO_PRODUCTO
VALUES
(DEFAULT,1,1),
(DEFAULT,2,2);