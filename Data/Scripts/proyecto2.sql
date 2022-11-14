--Script de creacion de la base de datos para el proyecto 2

CREATE TABLE ADMINISTRADOR_UBY
(
    CEDULA_ADMIN_UBY VARCHAR(9) NOT NULL,
    NOMBRE VARCHAR(50) NOT NULL,
    PRIMER_APELLIDO VARCHAR(50) NOT NULL,
    SEGUNDO_APELLIDO VARCHAR(50) NOT NULL,
    CORREO_ELECTRONICO VARCHAR(50) NOT NULL,
    USUARIO_ADMIN_UBY VARCHAR(50) NOT NULL,
    PASSWORD_ADMIN_UBY VARCHAR(50) NOT NULL,
    PROVINCIA VARCHAR(50) NOT NULL,
    CANTON VARCHAR(50) NOT NULL,
    DISTRITO VARCHAR(50) NOT NULL
);

ALTER TABLE ADMINISTRADOR_UBY
ADD PRIMARY KEY (CEDULA_ADMIN_UBY);

ALTER TABLE ADMINISTRADOR_UBY
ADD CONSTRAINT U_ADMIN_USER UNIQUE (USUARIO_ADMIN_UBY);

ALTER TABLE ADMINISTRADOR_UBY
ADD CONSTRAINT U_ADMIN_EMAIL UNIQUE (CORREO_ELECTRONICO);

CREATE TABLE ADMINISTRADOR_AFILIADO
(
    NOMBRE VARCHAR(50) NOT NULL,
    PRIMER_APELLIDO VARCHAR(50) NOT NULL,
    SEGUNDO_APELLIDO VARCHAR(50) NOT NULL,
    CORREO_ELECTRONICO VARCHAR(50) NOT NULL,
    USUARIO_ADMIN_AFI VARCHAR(50) NOT NULL,
    PASSWORD_ADMIN_AFI VARCHAR(50) NOT NULL,
    PROVINCIA VARCHAR(50) NOT NULL,
    CANTON VARCHAR(50) NOT NULL,
    DISTRITO VARCHAR(50) NOT NULL,
    ACTIVO BOOLEAN NOT NULL
);

ALTER TABLE ADMINISTRADOR_AFILIADO
ADD PRIMARY KEY (USUARIO_ADMIN_AFI);

ALTER TABLE ADMINISTRADOR_AFILIADO
ADD CONSTRAINT U_ADMIN_AFI_EMAIL UNIQUE (CORREO_ELECTRONICO);


CREATE TABLE CLIENTE
(
    CEDULA_CLIENTE VARCHAR(9) NOT NULL,
    NOMBRE VARCHAR(50) NOT NULL,
    PRIMER_APELLIDO VARCHAR(50) NOT NULL,
    SEGUNDO_APELLIDO VARCHAR(50) NOT NULL,
    FECHA_NACIMIENTO TIMESTAMP NOT NULL,
    CORREO_ELECTRONICO VARCHAR(50) NOT NULL,
    USUARIO_CLIENTE VARCHAR(50) NOT NULL,
    PASSWORD_CLIENTE VARCHAR(50) NOT NULL,
    PROVINCIA VARCHAR(50) NOT NULL,
    CANTON VARCHAR(50) NOT NULL,
    DISTRITO VARCHAR(50) NOT NULL
);

ALTER TABLE CLIENTE
ADD PRIMARY KEY (CEDULA_CLIENTE);

ALTER TABLE CLIENTE
ADD CONSTRAINT U_CLIENTE_USER UNIQUE (USUARIO_CLIENTE);

ALTER TABLE CLIENTE
ADD CONSTRAINT U_CLIENTE_EMAIL UNIQUE (CORREO_ELECTRONICO);

CREATE TABLE ADMIN_UBY_TELEFONOS
(
    ID SERIAL,
    CEDULA_ADMIN_UBY VARCHAR(9),
    TELEFONO VARCHAR(8)
);

ALTER TABLE ADMIN_UBY_TELEFONOS
ADD PRIMARY KEY (ID);

ALTER TABLE ADMIN_UBY_TELEFONOS
ADD CONSTRAINT U_ADMIN_UBY_TELEFONO UNIQUE (TELEFONO);

ALTER TABLE ADMIN_UBY_TELEFONOS
ADD CONSTRAINT FK_TELEFONOS_ADMIN_UBY
FOREIGN KEY (CEDULA_ADMIN_UBY) REFERENCES ADMINISTRADOR_UBY(CEDULA_ADMIN_UBY);

CREATE TABLE ADMIN_AFI_TELEFONOS
(
    ID SERIAL,
    USUARIO_ADMIN_AFI VARCHAR(9),
    TELEFONO VARCHAR(8)
);

ALTER TABLE ADMIN_AFI_TELEFONOS
ADD PRIMARY KEY (ID);

ALTER TABLE ADMIN_AFI_TELEFONOS
ADD CONSTRAINT U_ADMIN_AFI_TELEFONO UNIQUE (TELEFONO);

ALTER TABLE ADMIN_AFI_TELEFONOS
ADD CONSTRAINT FK_TELEFONOS_ADMIN_AFI
FOREIGN KEY (USUARIO_ADMIN_AFI) REFERENCES ADMINISTRADOR_AFILIADO(USUARIO_ADMIN_AFI);


CREATE TABLE CLIENTE_TELEFONOS
(
    ID SERIAL,
    CEDULA_CLIENTE VARCHAR(9),
    TELEFONO VARCHAR(8)
);

ALTER TABLE CLIENTE_TELEFONOS
ADD PRIMARY KEY (ID);

ALTER TABLE CLIENTE_TELEFONOS
ADD CONSTRAINT U_CLIENTE_TELEFONO UNIQUE (TELEFONO);

ALTER TABLE CLIENTE_TELEFONOS
ADD CONSTRAINT FK_TELEFONOS_CLIENTE
FOREIGN KEY (CEDULA_CLIENTE) REFERENCES CLIENTE(CEDULA_CLIENTE);

CREATE TABLE TIPO_COMERCIO
(
    ID_TIPO INT NOT NULL,
    NOMBRE_TIPO VARCHAR(30) NOT NULL
);

ALTER TABLE TIPO_COMERCIO
ADD PRIMARY KEY (ID_TIPO);

CREATE TABLE AFILIADO
(
    CEDULA_JURIDICA VARCHAR(12) NOT NULL,
    NOMBRE_COMERCIO VARCHAR(50) NOT NULL,
    SINPE_MOVIL VARCHAR(8) NOT NULL,
    CORREO VARCHAR(50) NOT NULL,
    PROVINCIA VARCHAR(50) NOT NULL,
    CANTON VARCHAR(50) NOT NULL,
    DISTRITO VARCHAR(50) NOT NULL,
    COMENTARIO_SOLICITUD VARCHAR(200),
    ACTIVO BOOLEAN NOT NULL,
    TIPO INT NOT NULL
);

ALTER TABLE AFILIADO
ADD PRIMARY KEY (CEDULA_JURIDICA);

ALTER TABLE AFILIADO
ADD CONSTRAINT U_AFILIADO_CORREO UNIQUE (CORREO);

ALTER TABLE AFILIADO
ADD CONSTRAINT FK_AFILIADO_TIPO
FOREIGN KEY (TIPO) REFERENCES TIPO_COMERCIO(ID_TIPO);

CREATE TABLE AFILIADO_TELEFONOS
(
    ID SERIAL,
    CEDULA_JURIDICA VARCHAR(12),
    TELEFONO VARCHAR(8)
);

ALTER TABLE AFILIADO_TELEFONOS
ADD PRIMARY KEY (ID);

ALTER TABLE AFILIADO_TELEFONOS
ADD CONSTRAINT U_AFILIADO_TELEFONO UNIQUE (TELEFONO);

ALTER TABLE AFILIADO_TELEFONOS
ADD CONSTRAINT FK_TELEFONOS_AFILIADO
FOREIGN KEY (CEDULA_JURIDICA) REFERENCES AFILIADO(CEDULA_JURIDICA);

CREATE TABLE AFILIADO_ADMIN
(
    CEDULA_JURIDICA VARCHAR(12) NOT NULL,
    USUARIO_ADMIN_AFI VARCHAR(50) NOT NULL,
    ACTIVO BOOLEAN NOT NULL
);

ALTER TABLE AFILIADO_ADMIN
ADD PRIMARY KEY (USUARIO_ADMIN_AFI);

ALTER TABLE AFILIADO_ADMIN
ADD CONSTRAINT FK_AFILIADOADMIN_AFILIADO
FOREIGN KEY (CEDULA_JURIDICA) REFERENCES AFILIADO(CEDULA_JURIDICA);

ALTER TABLE AFILIADO_ADMIN
ADD CONSTRAINT FK_AFILIADOADMIN_ADMINISTRADORAFILIADO
FOREIGN KEY (USUARIO_ADMIN_AFI) REFERENCES ADMINISTRADOR_AFILIADO(USUARIO_ADMIN_AFI);

CREATE TABLE REPARTIDOR
(
    USUARIO_REPART VARCHAR(50) NOT NULL,
    NOMBRE VARCHAR(50) NOT NULL,
    PRIMER_APELLIDO VARCHAR(50) NOT NULL,
    SEGUNDO_APELLIDO VARCHAR(50) NOT NULL,
    CORREO_REPART VARCHAR(50) NOT NULL,
    PASSWORD_REPART VARCHAR(50) NOT NULL,
    PROVINCIA VARCHAR(50) NOT NULL,
    CANTON VARCHAR(50) NOT NULL,
    DISTRITO VARCHAR(50) NOT NULL,
    DISPONIBLE BOOLEAN NOT NULL
);

ALTER TABLE REPARTIDOR
ADD PRIMARY KEY (USUARIO_REPART);

ALTER TABLE REPARTIDOR
ADD CONSTRAINT U_REPARTIDOR_USR UNIQUE (USUARIO_REPART);

ALTER TABLE REPARTIDOR
ADD CONSTRAINT U_REPARTIDOR_EMAIL UNIQUE (CORREO_REPART);

CREATE TABLE CATEGORIA
(
    ID_CATEGORIA SERIAL,
    NOMBRE_CATEGORIA VARCHAR(50) NOT NULL
);

ALTER TABLE CATEGORIA
ADD PRIMARY KEY (ID_CATEGORIA);

CREATE TABLE PRODUCTO
(
    ID_PRODUCTO SERIAL,
    NOMBRE_PRODUCTO VARCHAR(50) NOT NULL,
    URL_FOTO VARCHAR(300) NOT NULL,
    PRECIO INT NOT NULL,
    CEDULA_JURIDICA VARCHAR(12) NOT NULL,
    ID_CATEGORIA INT NOT NULL
);

ALTER TABLE PRODUCTO
ADD PRIMARY KEY (ID_PRODUCTO);

ALTER TABLE PRODUCTO
ADD CONSTRAINT FK_PRODUCTO_ADMIN_AFI
FOREIGN KEY (CEDULA_JURIDICA) REFERENCES AFILIADO(CEDULA_JURIDICA);

ALTER TABLE PRODUCTO
ADD CONSTRAINT FK_PRODUCTO_CATEGORIA
FOREIGN KEY (ID_CATEGORIA) REFERENCES CATEGORIA(ID_CATEGORIA);

CREATE TABLE ESTADO
(
    ID_ESTADO SERIAL,
    NOMBRE_ESTADO VARCHAR(50) NOT NULL
);

ALTER TABLE ESTADO
ADD PRIMARY KEY (ID_ESTADO);

CREATE TABLE PEDIDO
(
    ID_PEDIDO SERIAL,
    MONTO INT NOT NULL,
    ID_ESTADO INT NOT NULL,
    CEDULA_CLIENTE VARCHAR(9) NOT NULL,
    PROVINCIA VARCHAR(50) NOT NULL,
    CANTON VARCHAR(50) NOT NULL,
    DISTRITO VARCHAR(50) NOT NULL,
    CEDULA_JURIDICA VARCHAR(12) NOT NULL,
    FECHA_PEDIDO TIMESTAMP NOT NULL,
    USUARIO_REPART VARCHAR(50) NOT NULL
);

ALTER TABLE PEDIDO
ADD PRIMARY KEY (ID_PEDIDO);

ALTER TABLE PEDIDO
ADD CONSTRAINT FK_PEDIDO_ESTADO
FOREIGN KEY (ID_ESTADO) REFERENCES ESTADO(ID_ESTADO);

ALTER TABLE PEDIDO
ADD CONSTRAINT FK_PEDIDO_CLIENTE
FOREIGN KEY (CEDULA_CLIENTE) REFERENCES CLIENTE(CEDULA_CLIENTE);

ALTER TABLE PEDIDO
ADD CONSTRAINT FK_PEDIDO_AFILIADO
FOREIGN KEY (CEDULA_JURIDICA) REFERENCES AFILIADO(CEDULA_JURIDICA);

ALTER TABLE PEDIDO
ADD CONSTRAINT FK_PEDIDO_REPARTIDOR
FOREIGN KEY (USUARIO_REPART) REFERENCES REPARTIDOR(USUARIO_REPART);

CREATE TABLE PEDIDO_PRODUCTO
(
    ID_LINEA SERIAL,
    ID_PEDIDO INT NOT NULL,
    ID_PRODUCTO INT NOT NULL
);

ALTER TABLE PEDIDO_PRODUCTO
ADD PRIMARY KEY (ID_LINEA);

ALTER TABLE PEDIDO_PRODUCTO
ADD CONSTRAINT FK_PEDIDOPRODUCTO_PEDIDO
FOREIGN KEY (ID_PEDIDO) REFERENCES PEDIDO(ID_PEDIDO);

ALTER TABLE PEDIDO_PRODUCTO
ADD CONSTRAINT FK_PEDIDOPRODUCTO_PRODUCTO
FOREIGN KEY (ID_PRODUCTO) REFERENCES PRODUCTO(ID_PRODUCTO);
