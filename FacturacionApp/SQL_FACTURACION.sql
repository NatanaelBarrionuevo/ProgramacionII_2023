GO
CREATE DATABASE FACTURACION;
GO
USE FACTURACION;
GO
SET DATEFORMAT dmy;
GO
--TABLA ARTICULOS
CREATE TABLE ARTICULOS(
COD_ARTICULO INT IDENTITY(1,1),
NOMBRE VARCHAR(40) NOT NULL,
PRE_UNITARIO DECIMAL(8,2) NOT NULL,
CANTIDAD INT NOT NULL,
ACTIVO BIT NOT NULL
CONSTRAINT PK__ARTICULO PRIMARY KEY(COD_ARTICULO)
);

/*
//////////////////////////////////////////////
//////////INSERTS TABLA ARTICULOS/////////////
/////////////////////////////////////////////
*/
GO
DELETE FROM ARTICULOS;
GO
SELECT * FROM ARTICULOS;
GO
INSERT INTO ARTICULOS (NOMBRE, PRE_UNITARIO, CANTIDAD, ACTIVO) VALUES ('Pelota de F�tbol', 5599, 100, 1);--1
GO
INSERT INTO ARTICULOS (NOMBRE, PRE_UNITARIO, CANTIDAD, ACTIVO) VALUES ('Raqueta Tenis', 8950, 100, 1);--2
GO
INSERT INTO ARTICULOS (NOMBRE, PRE_UNITARIO, CANTIDAD, ACTIVO) VALUES ('Pelota de Basket', 2975, 100, 1);--3
GO
INSERT INTO ARTICULOS (NOMBRE, PRE_UNITARIO, CANTIDAD, ACTIVO) VALUES ('Guantes de Boxeo', 3599, 100, 1);--4
GO
INSERT INTO ARTICULOS (NOMBRE, PRE_UNITARIO, CANTIDAD, ACTIVO) VALUES ('Tabla de Surf', 15900, 100, 1);--5
GO
INSERT INTO ARTICULOS (NOMBRE, PRE_UNITARIO, CANTIDAD, ACTIVO) VALUES ('Casco Ciclismo', 4550, 100, 1);--6
GO
INSERT INTO ARTICULOS (NOMBRE, PRE_UNITARIO, CANTIDAD, ACTIVO) VALUES ('Raqueta Squash', 3425, 100, 1);--7
GO
INSERT INTO ARTICULOS (NOMBRE, PRE_UNITARIO, CANTIDAD, ACTIVO) VALUES ('Pantalones de Yoga', 2999, 100, 1)--8;
GO
INSERT INTO ARTICULOS (NOMBRE, PRE_UNITARIO, CANTIDAD, ACTIVO) VALUES ('Pelota Voleibol', 2875, 100, 1);--9
GO
INSERT INTO ARTICULOS (NOMBRE, PRE_UNITARIO, CANTIDAD, ACTIVO) VALUES ('Cinta de Correr', 49900, 100, 1);--10
GO
INSERT INTO ARTICULOS (NOMBRE, PRE_UNITARIO, CANTIDAD, ACTIVO) VALUES ('Raqueta B�dminton', 3650, 100, 1);--11
GO
INSERT INTO ARTICULOS (NOMBRE, PRE_UNITARIO, CANTIDAD, ACTIVO) VALUES ('Guantes de Aqrquero', 2750, 100, 1);--12
GO
INSERT INTO ARTICULOS (NOMBRE, PRE_UNITARIO, CANTIDAD, ACTIVO) VALUES ('Patines', 5999, 100, 1);--13
GO
INSERT INTO ARTICULOS (NOMBRE, PRE_UNITARIO, CANTIDAD, ACTIVO) VALUES ('Mallas de Running', 6875, 100, 1);--14
GO
INSERT INTO ARTICULOS (NOMBRE, PRE_UNITARIO, CANTIDAD, ACTIVO) VALUES ('Pelota de Rugby', 3225, 100, 1);--15
GO
INSERT INTO ARTICULOS (NOMBRE, PRE_UNITARIO, CANTIDAD, ACTIVO) VALUES ('Raqueta de P�del', 6450, 100, 1);--16
GO
INSERT INTO ARTICULOS (NOMBRE, PRE_UNITARIO, CANTIDAD, ACTIVO) VALUES ('Soga para Saltar', 999, 100, 1);--17
GO
INSERT INTO ARTICULOS (NOMBRE, PRE_UNITARIO, CANTIDAD, ACTIVO) VALUES ('Cinta de Yoga', 1450, 100, 1);--18
GO
INSERT INTO ARTICULOS (NOMBRE, PRE_UNITARIO, CANTIDAD, ACTIVO) VALUES ('Pelota Medicinal', 2875, 100, 1);--19
GO
INSERT INTO ARTICULOS (NOMBRE, PRE_UNITARIO, CANTIDAD, ACTIVO) VALUES ('Camiseta de Racing(cba)', 12199, 100, 1);--20
GO
INSERT INTO ARTICULOS (NOMBRE, PRE_UNITARIO, CANTIDAD, ACTIVO) VALUES ('Red de Tenis', 9250, 100, 1);--21
GO
INSERT INTO ARTICULOS (NOMBRE, PRE_UNITARIO, CANTIDAD, ACTIVO) VALUES ('Gorra de Nataci�n', 3225, 100, 1);--22
GO
INSERT INTO ARTICULOS (NOMBRE, PRE_UNITARIO, CANTIDAD, ACTIVO) VALUES ('Bal�n de F�tbol Sala', 2299, 100, 1);--23
GO
INSERT INTO ARTICULOS (NOMBRE, PRE_UNITARIO, CANTIDAD, ACTIVO) VALUES ('Tablas de Esqu�', 12900, 100, 1);--24
GO
INSERT INTO ARTICULOS (NOMBRE, PRE_UNITARIO, CANTIDAD, ACTIVO) VALUES ('Saco de Boxeo', 6950, 100, 1);--25
GO
INSERT INTO ARTICULOS (NOMBRE, PRE_UNITARIO, CANTIDAD, ACTIVO) VALUES ('Bicicleta de Monta�a', 34900, 100, 1);--26
GO
INSERT INTO ARTICULOS (NOMBRE, PRE_UNITARIO, CANTIDAD, ACTIVO) VALUES ('Pelotas de Golf', 5000, 100, 1);--27
GO
INSERT INTO ARTICULOS (NOMBRE, PRE_UNITARIO, CANTIDAD, ACTIVO) VALUES ('Mancuernas', 5450, 100, 1);--28
GO
INSERT INTO ARTICULOS (NOMBRE, PRE_UNITARIO, CANTIDAD, ACTIVO) VALUES ('Botella de Agua Deportiva', 2250, 100, 1);--29
GO
INSERT INTO ARTICULOS (NOMBRE, PRE_UNITARIO, CANTIDAD, ACTIVO) VALUES ('Rodillera Deportiva', 2000, 100, 1);--30
GO
INSERT INTO ARTICULOS (NOMBRE, PRE_UNITARIO, CANTIDAD, ACTIVO) VALUES ('Casaca de Ciclismo', 7000, 100, 1);--31
GO
INSERT INTO ARTICULOS (NOMBRE, PRE_UNITARIO, CANTIDAD, ACTIVO) VALUES ('Pelota de Cricket', 3000, 100, 1);--32
GO
INSERT INTO ARTICULOS (NOMBRE, PRE_UNITARIO, CANTIDAD, ACTIVO) VALUES ('Peto de Entrenamiento', 15000, 100, 1);--33
GO
INSERT INTO ARTICULOS (NOMBRE, PRE_UNITARIO, CANTIDAD, ACTIVO) VALUES ('Tablero de Ajedrez', 5000, 100, 1);--34
GO

--TABLA FORMA DE PAGO
CREATE TABLE FORMA_PAGOS(
COD_FPAGO INT IDENTITY(1,1),
DESCRIPCION VARCHAR(40) NOT NULL,
ACTIVO BIT NOT NULL,
CONSTRAINT PK_FPAGO PRIMARY KEY(COD_FPAGO)
);
GO


/*
//////////////////////////////////////////////
/////////INSERTS TABLA FORMA_PAGOS////////////
/////////////////////////////////////////////
*/
INSERT INTO FORMA_PAGOS (DESCRIPCION, ACTIVO) VALUES(
'EFECTIVO', 1),--1
('TARJETA DEBITO', 1),--2
('TARJETA CREDITO',1);--3
GO
CREATE TABLE PAISES(
COD_PAIS INT IDENTITY(1,1),
PAIS VARCHAR(70),
CONSTRAINT PK_PAIS PRIMARY KEY(COD_PAIS)
);
-- Sentencias INSERT para la tabla PAISES
GO 
INSERT INTO PAISES(PAIS) VALUES('ARGENTINA');
GO
CREATE TABLE PROVINCIAS(
COD_PROVINCIA INT IDENTITY(1,1),
COD_PAIS INT NOT NULL,
PROVINCIA VARCHAR(70) NOT NULL,
CONSTRAINT PK_PROVINCIA PRIMARY KEY(COD_PROVINCIA),
CONSTRAINT FK_PROVINCIA_PAIS FOREIGN KEY(COD_PAIS) REFERENCES PAISES(COD_PAIS)
);
GO
-- Sentencias INSERT para la tabla PROVINCIAS
INSERT INTO PROVINCIAS (PROVINCIA, COD_PAIS) VALUES ('Buenos Aires', 1);
GO
INSERT INTO PROVINCIAS (PROVINCIA, COD_PAIS) VALUES ('Catamarca', 1);
GO
INSERT INTO PROVINCIAS (PROVINCIA, COD_PAIS) VALUES ('Chaco', 1);
GO
INSERT INTO PROVINCIAS (PROVINCIA, COD_PAIS) VALUES ('Chubut', 1);
GO
INSERT INTO PROVINCIAS (PROVINCIA, COD_PAIS) VALUES ('C�rdoba', 1);
GO
INSERT INTO PROVINCIAS (PROVINCIA, COD_PAIS) VALUES ('Corrientes', 1);
GO
INSERT INTO PROVINCIAS (PROVINCIA, COD_PAIS) VALUES ('Entre R�os', 1);
GO
INSERT INTO PROVINCIAS (PROVINCIA, COD_PAIS) VALUES ('Formosa', 1);
GO
INSERT INTO PROVINCIAS (PROVINCIA, COD_PAIS) VALUES ('Jujuy', 1);
GO
INSERT INTO PROVINCIAS (PROVINCIA, COD_PAIS) VALUES ('La Pampa', 1);
GO
INSERT INTO PROVINCIAS (PROVINCIA, COD_PAIS) VALUES ('La Rioja', 1);
GO
INSERT INTO PROVINCIAS (PROVINCIA, COD_PAIS) VALUES ('Mendoza', 1);
GO
INSERT INTO PROVINCIAS (PROVINCIA, COD_PAIS) VALUES ('Misiones', 1);
GO
INSERT INTO PROVINCIAS (PROVINCIA, COD_PAIS) VALUES ('Neuqu�n', 1);
GO
INSERT INTO PROVINCIAS (PROVINCIA, COD_PAIS) VALUES ('R�o Negro', 1);
GO
INSERT INTO PROVINCIAS (PROVINCIA, COD_PAIS) VALUES ('Salta', 1);
GO
INSERT INTO PROVINCIAS (PROVINCIA, COD_PAIS) VALUES ('San Juan', 1);
GO
INSERT INTO PROVINCIAS (PROVINCIA, COD_PAIS) VALUES ('San Luis', 1);
GO
INSERT INTO PROVINCIAS (PROVINCIA, COD_PAIS) VALUES ('Santa Cruz', 1);
GO
INSERT INTO PROVINCIAS (PROVINCIA, COD_PAIS) VALUES ('Santa Fe', 1);
GO
INSERT INTO PROVINCIAS (PROVINCIA, COD_PAIS) VALUES ('Santiago del Estero', 1);
GO
INSERT INTO PROVINCIAS (PROVINCIA, COD_PAIS) VALUES ('Tierra del Fuego', 1);
GO
INSERT INTO PROVINCIAS (PROVINCIA, COD_PAIS) VALUES ('Tucum�n', 1);
GO
INSERT INTO PROVINCIAS (PROVINCIA, COD_PAIS) VALUES ('CABA', 1);
GO
CREATE TABLE BARRIOS(
COD_BARRIO INT IDENTITY(1,1),
COD_PROV INT NOT NULL,
BARRIO VARCHAR(70) NOT NULL,
CONSTRAINT PK_BARRIO PRIMARY KEY(COD_BARRIO),
CONSTRAINT FK_BARRIO_PROVINCIA FOREIGN KEY(COD_PROV) REFERENCES PROVINCIAS(COD_PROVINCIA)
);
GO
CREATE TABLE CLEINTES(
LEGAJO INT,
APELLIDO VARCHAR(70) NOT NULL,
NOMBRE VARCHAR(70) NOT NULL,
DIRECCION VARCHAR(70) NOT NULL,
COD_BARRIO INT NOT NULL,
TELEFONO INT,
[E-MAIL] VARCHAR(90),
fec_nac datetime not null,
fec_alta datetime not null,
fec_baja datetime not null,
CONSTRAINT PK_CLIENTE PRIMARY KEY(LEGAJO),
CONSTRAINT FK_BARRIO FOREIGN KEY(COD_BARRIO) REFERENCES BARRIOS(COD_BARRIO)
);
--TABLA FACTURAS 
CREATE TABLE FACTURAS(
NRO_FACTURA INT IDENTITY(1,1),
FECHA DATETIME NOT NULL,
CLIENTE VARCHAR(90) NOT NULL,
MONTO DECIMAL(10,2) NOT NULL,
COD_F_PAGO INT NOT NULL,
DESCUENTO INT,
CONSTRAINT PK_FACTURA PRIMARY KEY(NRO_FACTURA),
CONSTRAINT FK_FACTURA_FPAGO FOREIGN KEY(COD_F_PAGO) REFERENCES FORMA_PAGOS(COD_FPAGO)
);
GO
/*
//////////////////////////////////////////////
//////////INSERTS TABLA FACTURAS/////////////
/////////////////////////////////////////////
*/
INSERT INTO FACTURAS(FECHA, CLIENTE, MONTO, COD_F_PAGO, DESCUENTO) VALUES('28/08/2023', 'CONSUMIDOR FINAL', 6718.8, 1, 10);

--DETALLE DE FACTURAS 
CREATE TABLE DETALLE_FACTURAS(
NRO_DETALLE INT,
NRO_FACTURA INT NOT NULL,
COD_ARTICULO INT NOT NULL,
CANTIDAD INT NOT NULL,
CONSTRAINT PK_DETALLE_FACTURA PRIMARY KEY (NRO_DETALLE, NRO_FACTURA),
CONSTRAINT FK_DETALLE_ARTICULO FOREIGN KEY(COD_ARTICULO) REFERENCES ARTICULOS(COD_ARTICULO),
CONSTRAINT FK_DETALLE_MAESTRO FOREIGN KEY(NRO_FACTURA) REFERENCES FACTURAS(NRO_FACTURA)
);
GO
/*
//////////////////////////////////////////////
//////INSERTS TABLA DETALLE_FACTURAS/////////
/////////////////////////////////////////////
*/
GO
INSERT INTO DETALLE_FACTURAS(NRO_DETALLE, NRO_FACTURA, COD_ARTICULO, CANTIDAD) VALUES(
1, 1, 1, 1);
GO
SELECT * FROM FACTURAS F
JOIN DETALLE_FACTURAS D ON F.NRO_FACTURA = D.NRO_FACTURA;
SELECT * FROM ARTICULOS;
--DELETE FROM FACTURAS;

CREATE PROCEDURE SP_C_PROVINCIAS
AS
BEGIN
	SELECT * FROM PROVINCIAS
END

CREATE PROCEDURE SP_C_BARRIOS
@cod_provincia INT
AS
BEGIN
	SELECT * FROM BARRIOS B, PROVINCIAS P
	WHERE B.COD_PROV = P.PROVINCIA AND B.COD_BARRIO = @cod_provincia
END

CREATE PROCEDURE SP_C_CLIENTES
AS
BEGIN
	SELECT * FROM ARTICULOS
END