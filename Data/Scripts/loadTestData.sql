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