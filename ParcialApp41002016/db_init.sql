USE [carpinteria_db]
GO
/****** Object:  Table [dbo].[T_DETALLES_PRESUPUESTO]    Script Date: 2/9/2023 10:17:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_DETALLES_PRESUPUESTO](
	[presupuesto_nro] [int] NOT NULL,
	[detalle_nro] [int] NOT NULL,
	[id_producto] [int] NOT NULL,
	[cantidad] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[presupuesto_nro] ASC,
	[detalle_nro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_PRESUPUESTOS]    Script Date: 2/9/2023 10:17:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_PRESUPUESTOS](
	[presupuesto_nro] [int] IDENTITY(1,1) NOT NULL,
	[fecha] [date] NOT NULL,
	[cliente] [varchar](255) NULL,
	[descuento] [numeric](5, 2) NULL,
	[fecha_baja] [date] NULL,
	[total] [numeric](8, 2) NOT NULL,
 CONSTRAINT [PK__T_PRESUP__33BEB70E03317E3D] PRIMARY KEY CLUSTERED 
(
	[presupuesto_nro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_PRODUCTOS]    Script Date: 2/9/2023 10:17:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_PRODUCTOS](
	[id_producto] [int] IDENTITY(1,1) NOT NULL,
	[n_producto] [varchar](255) NOT NULL,
	[precio] [numeric](8, 2) NOT NULL,
	[activo] [varchar](1) NOT NULL,
 CONSTRAINT [PK__T_PRODUC__FF341C0D7F60ED59] PRIMARY KEY CLUSTERED 
(
	[id_producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[T_DETALLES_PRESUPUESTO] ([presupuesto_nro], [detalle_nro], [id_producto], [cantidad]) VALUES (2, 0, 1, 1)
INSERT [dbo].[T_DETALLES_PRESUPUESTO] ([presupuesto_nro], [detalle_nro], [id_producto], [cantidad]) VALUES (3, 1, 1, 1)
INSERT [dbo].[T_DETALLES_PRESUPUESTO] ([presupuesto_nro], [detalle_nro], [id_producto], [cantidad]) VALUES (3, 2, 2, 1)
INSERT [dbo].[T_DETALLES_PRESUPUESTO] ([presupuesto_nro], [detalle_nro], [id_producto], [cantidad]) VALUES (4, 1, 2, 1)
INSERT [dbo].[T_DETALLES_PRESUPUESTO] ([presupuesto_nro], [detalle_nro], [id_producto], [cantidad]) VALUES (5, 1, 1, 1)
INSERT [dbo].[T_DETALLES_PRESUPUESTO] ([presupuesto_nro], [detalle_nro], [id_producto], [cantidad]) VALUES (5, 2, 2, 1)
INSERT [dbo].[T_DETALLES_PRESUPUESTO] ([presupuesto_nro], [detalle_nro], [id_producto], [cantidad]) VALUES (6, 1, 2, 1)
INSERT [dbo].[T_DETALLES_PRESUPUESTO] ([presupuesto_nro], [detalle_nro], [id_producto], [cantidad]) VALUES (6, 2, 1, 4)
GO
SET IDENTITY_INSERT [dbo].[T_PRESUPUESTOS] ON 

INSERT [dbo].[T_PRESUPUESTOS] ([presupuesto_nro], [fecha], [cliente], [descuento], [fecha_baja], [total]) VALUES (2, CAST(N'2021-05-11' AS Date), N'CONSUMIDOR FINAL', CAST(0.00 AS Numeric(5, 2)), NULL, CAST(11000.00 AS Numeric(8, 2)))
INSERT [dbo].[T_PRESUPUESTOS] ([presupuesto_nro], [fecha], [cliente], [descuento], [fecha_baja], [total]) VALUES (3, CAST(N'2021-05-11' AS Date), N'CONSUMIDOR FINAL', CAST(0.00 AS Numeric(5, 2)), NULL, CAST(24700.00 AS Numeric(8, 2)))
INSERT [dbo].[T_PRESUPUESTOS] ([presupuesto_nro], [fecha], [cliente], [descuento], [fecha_baja], [total]) VALUES (4, CAST(N'2021-05-28' AS Date), N'CONSUMIDOR FINAL', CAST(10.00 AS Numeric(5, 2)), NULL, CAST(12330.00 AS Numeric(8, 2)))
INSERT [dbo].[T_PRESUPUESTOS] ([presupuesto_nro], [fecha], [cliente], [descuento], [fecha_baja], [total]) VALUES (5, CAST(N'2022-10-26' AS Date), N'Oscar CONSUMIDOR FINAL', CAST(0.00 AS Numeric(5, 2)), NULL, CAST(24700.00 AS Numeric(8, 2)))
INSERT [dbo].[T_PRESUPUESTOS] ([presupuesto_nro], [fecha], [cliente], [descuento], [fecha_baja], [total]) VALUES (6, CAST(N'2022-10-26' AS Date), N'Otro CONSUMIDOR FINAL', CAST(20.00 AS Numeric(5, 2)), NULL, CAST(46160.00 AS Numeric(8, 2)))
SET IDENTITY_INSERT [dbo].[T_PRESUPUESTOS] OFF
GO
SET IDENTITY_INSERT [dbo].[T_PRODUCTOS] ON 

INSERT [dbo].[T_PRODUCTOS] ([id_producto], [n_producto], [precio], [activo]) VALUES (1, N'VENTANA CORREDIZA', CAST(11000.00 AS Numeric(8, 2)), N'S')
INSERT [dbo].[T_PRODUCTOS] ([id_producto], [n_producto], [precio], [activo]) VALUES (2, N'PUERTA 1 HOJA', CAST(13700.00 AS Numeric(8, 2)), N'S')
SET IDENTITY_INSERT [dbo].[T_PRODUCTOS] OFF
GO
ALTER TABLE [dbo].[T_DETALLES_PRESUPUESTO]  WITH CHECK ADD  CONSTRAINT [fk_presupuesto] FOREIGN KEY([presupuesto_nro])
REFERENCES [dbo].[T_PRESUPUESTOS] ([presupuesto_nro])
GO
ALTER TABLE [dbo].[T_DETALLES_PRESUPUESTO] CHECK CONSTRAINT [fk_presupuesto]
GO
ALTER TABLE [dbo].[T_DETALLES_PRESUPUESTO]  WITH CHECK ADD  CONSTRAINT [fk_producto] FOREIGN KEY([id_producto])
REFERENCES [dbo].[T_PRODUCTOS] ([id_producto])
GO
ALTER TABLE [dbo].[T_DETALLES_PRESUPUESTO] CHECK CONSTRAINT [fk_producto]
GO
/****** Object:  StoredProcedure [dbo].[SP_CONSULTAR_DETALLES_PRESUPUESTO]    Script Date: 2/9/2023 10:17:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_CONSULTAR_DETALLES_PRESUPUESTO] 
	@presupuesto_nro int
AS
BEGIN
	SELECT t.*, t2.n_producto, t2.precio, t3.cliente, t3.fecha, t3.total, t3.descuento
	FROM T_DETALLES_PRESUPUESTO t, T_PRODUCTOS t2, T_PRESUPUESTOS t3
	WHERE t.id_producto = t2.id_producto
	AND t.presupuesto_nro = t3.presupuesto_nro
	AND t.presupuesto_nro = @presupuesto_nro; 
END
GO
/****** Object:  StoredProcedure [dbo].[SP_CONSULTAR_PRESUPUESTOS]    Script Date: 2/9/2023 10:17:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_CONSULTAR_PRESUPUESTOS]
	@fecha_desde Datetime,
	@fecha_hasta Datetime,
	@cliente varchar(255)
AS
BEGIN
	SELECT * 
	FROM T_PRESUPUESTOS
	WHERE (@fecha_desde is null OR fecha >= @fecha_desde)
	AND (@fecha_hasta is null OR fecha <= @fecha_hasta)
	AND (@cliente is null OR cliente LIKE '%' + @cliente + '%')
	AND fecha_baja is null;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_CONSULTAR_PRODUCTOS]    Script Date: 2/9/2023 10:17:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_CONSULTAR_PRODUCTOS]
AS
BEGIN
	
	SELECT * from T_PRODUCTOS;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_ELIMINAR_PRESUPUESTO]    Script Date: 2/9/2023 10:17:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ELIMINAR_PRESUPUESTO] 
	@presupuesto_nro int
AS
BEGIN
	UPDATE T_PRESUPUESTOS SET fecha_baja = GETDATE()
	WHERE presupuesto_nro = @presupuesto_nro;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_INSERTAR_DETALLE]    Script Date: 2/9/2023 10:17:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INSERTAR_DETALLE] 
	@presupuesto_nro int,
	@detalle int, 
	@id_producto int, 
	@cantidad int
AS
BEGIN
	INSERT INTO T_DETALLES_PRESUPUESTO(presupuesto_nro,detalle_nro, id_producto, cantidad)
    VALUES (@presupuesto_nro, @detalle, @id_producto, @cantidad);
  
END
GO
/****** Object:  StoredProcedure [dbo].[SP_INSERTAR_MAESTRO]    Script Date: 2/9/2023 10:17:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INSERTAR_MAESTRO] 
	@cliente varchar(255), 
	@dto numeric(5,2),
	@total numeric(8,2),
	@presupuesto_nro int OUTPUT
AS
BEGIN
	INSERT INTO T_PRESUPUESTOS(fecha, cliente, descuento, total)
    VALUES (GETDATE(), @cliente, @dto, @total);
    --Asignamos el valor del último ID autogenerado (obtenido --  
    --mediante la función SCOPE_IDENTITY() de SQLServer)	
    SET @presupuesto_nro = SCOPE_IDENTITY();

END
GO
/****** Object:  StoredProcedure [dbo].[SP_MODIFICAR_MAESTRO]    Script Date: 2/9/2023 10:17:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_MODIFICAR_MAESTRO] 
	@cliente varchar(255), 
	@dto numeric(5,2),
	@total numeric(8,2), 
	@presupuesto_nro int
AS
BEGIN
	UPDATE T_PRESUPUESTOS SET cliente = @cliente, descuento = @dto, total = @total
	WHERE presupuesto_nro = @presupuesto_nro;
	
	DELETE T_DETALLES_PRESUPUESTO
	WHERE presupuesto_nro = @presupuesto_nro;
END
/****** Object:  StoredProcedure [dbo].[SP_MODIFICAR_PRODUCTOS]    Script Date: 23/9/2023 16:31:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_MODIFICAR_PRODUCTOS] 
	@id_producto int, 
	@n_producto varchar(255),
	@precio numeric(8,2), 
	@activo varchar(1)
AS
BEGIN
	UPDATE T_PRODUCTOS SET n_producto = @n_producto, precio = @precio, activo = @activo
	WHERE id_producto = @id_producto;	
END
GO
/****** Object:  StoredProcedure [dbo].[SP_PROXIMO_ID]    Script Date: 2/9/2023 10:17:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_PROXIMO_ID]
@next int OUTPUT
AS
BEGIN
	SET @next = (SELECT MAX(presupuesto_nro)+1  FROM T_PRESUPUESTOS);
END
GO
/****** Object:  StoredProcedure [dbo].[SP_REPORTE_PRODUCTOS]    Script Date: 23/9/2023 16:17:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_REPORTE_PRODUCTOS]
@fecha_desde datetime, 
@fecha_hasta datetime 

AS
BEGIN
	SELECT t2.n_producto as producto, SUM(t.cantidad) as cantidad
	FROM T_DETALLES_PRESUPUESTO t, T_PRODUCTOS t2, T_PRESUPUESTOS t3
	WHERE t.id_producto = t2.id_producto
	AND t.presupuesto_nro = t3.presupuesto_nro
	AND t3.fecha between @fecha_desde and @fecha_hasta
	GROUP BY t2.n_producto;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_PROXIMO_PRODUCTO]    Script Date: 23/9/2023 16:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_PROXIMO_PRODUCTO]
@next int OUTPUT
AS
BEGIN
	SET @next = (SELECT MAX(id_producto)+1  FROM T_PRODUCTOS);
END
/****** Object:  StoredProcedure [dbo].[SP_MODIFICAR_PRODUCTOS]    Script Date: 23/9/2023 16:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_MODIFICAR_PRODUCTOS] 
	@id_producto int, 
	@n_producto varchar(255),
	@precio numeric(8,2), 
	@activo varchar(1)
AS
BEGIN
	UPDATE T_PRODUCTOS SET n_producto = @n_producto, precio = @precio, activo = @activo
	WHERE id_producto = @id_producto;	
END
GO
/****** Object:  StoredProcedure [dbo].[SP_INSERTAR_PRODUCTO]    Script Date: 23/9/2023 16:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INSERTAR_PRODUCTO] 
	@n_producto varchar(255),
	@precio numeric(8,2), 
	@activo varchar(1)
AS
BEGIN
	INSERT INTO T_PRODUCTOS(n_producto, precio, activo)
    VALUES (@n_producto, @precio, @activo);
END
GO
/****** Object:  StoredProcedure [dbo].[SP_ELIMINAR_PRODUCTOS]    Script Date: 23/9/2023 16:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ELIMINAR_PRODUCTOS] 
	@id_producto int
AS
BEGIN
	UPDATE T_PRODUCTOS SET activo = 'N'
	WHERE id_producto = @id_producto;
END
GO
/****** Object:  Table [dbo].[PROVINCIAS]    Script Date: 23/9/2023 16:31 ******/

GO
CREATE TABLE PROVINCIAS(
ID_PROV INT,
PRIVINCIA VARCHAR(50) NOT NULL,
CONSTRAINT PK_PROVINCIA PRIMARY KEY(ID_PROV)
);
GO
/****** Object:  Table [dbo].[BARRIOS]    Script Date: 23/9/2023 16:31 ******/
CREATE TABLE BARRIOS(
ID_BARRIO INT,
ID_PROV INT NOT NULL,
BARRIO VARCHAR(50) NOT NULL,
CONSTRAINT PK_BARRIO PRIMARY KEY(ID_BARRIO),
CONSTRAINT FK_BARRIO_PROVINCIA FOREIGN KEY(ID_PROV) REFERENCES PROVINCIAS(ID_PROV)
);
GO
/****** Object:  Table [dbo].[CLIENTES]    Script Date: 23/9/2023 16:31 ******/
CREATE TABLE CLIENTES(
LEGAJO INT,
NOMBRE VARCHAR(50) NOT NULL,
APELLIDO VARCHAR(50) NOT NULL,
ID_BARRIO INT NOT NULL,
DOMICILIO VARCHAR(50) NOT NULL,
ALTURA INT NOT NULL,
TELEFONO INT,
[E-MAIL] VARCHAR(70) NOT NULL,
FEC_NAC DATETIME NOT NULL,
CONSTRAINT PK_CLIENTE PRIMARY KEY(LEGAJO),
CONSTRAINT FK_CLIENTE_BARRIO FOREIGN KEY(ID_BARRIO) REFERENCES BARRIOS(ID_BARRIO)
);
GO
ALTER TABLE CLIENTES
ADD ACTIVO BIT NOT NULL;
/****** Object:  StoredProcedure [dbo].[SP_PROXIMO_CLIENTE]    Script Date: 23/9/2023 16:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_PROXIMO_CLIENTE]
@next int OUTPUT
AS
BEGIN
	SET @next = (SELECT MAX(legajo)+1  FROM CLIENTES);
END
/****** Object:  StoredProcedure [dbo].[SP_MODIFICAR_PRODUCTOS]    Script Date: 23/9/2023 16:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_MODIFICAR_CLIENTES] 
	@legajo int, 
	@nombre varchar(50),
	@apellido varchar(50), 
	@id_barrio int,
	@domicilio varchar(50), 
	@altura int,
	@telefono int, 
	@mail varchar(1),
	@fecha datetime,
	@activo int
AS
BEGIN
	UPDATE CLIENTES SET  nombre = @nombre, apellido = @apellido,
	id_barrio = @id_barrio, altura = @altura, telefono = @telefono, [E-MAIL] = @mail,
	FEC_NAC = @fecha, activo = @activo
	WHERE legajo = @legajo;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_INSERTAR_CLIENTE]    Script Date: 23/9/2023 16:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INSERTAR_CLIENTE] 
	@legajo int, 
	@nombre varchar(50),
	@apellido varchar(50), 
	@id_barrio int,
	@domicilio varchar(50), 
	@altura int,
	@telefono int, 
	@mail varchar(1),
	@fecha datetime,
	@activo bit,
	@fec_alta datetime,
	@sexo varchar(1)
	
AS
BEGIN
	INSERT INTO CLIENTES(legajo, nombre, apellido, id_barrio, domicilio, altura, telefono, [e-mail],
	fec_nac, activo, fec_alta, sexo, fec_baja)
    VALUES (@legajo, @nombre, @apellido, @id_barrio, @domicilio, @altura, @telefono, 
	@mail, @fecha,	@activo, @fec_alta, @sexo);
END
GO
/****** Object:  StoredProcedure [dbo].[SP_ELIMINAR_CLIENTE]    Script Date: 23/9/2023 16:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ELIMINAR_CLIENTE] 
	@legajo int
AS
BEGIN
	UPDATE CLIENTES SET activo = 0
	WHERE LEGAJO = @legajo;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_CONSULTAR_CLIENTES]    Script Date: 23/9/2023 16:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_CONSULTAR_CLIENTES] 
	AS
BEGIN
	SELECT * FROM CLIENTES;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_CONSULTAR_BARRIOS]    Script Date: 23/9/2023 16:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_CONSULTAR_BARRIOS] 
	AS
BEGIN
	SELECT * FROM BARRIOS;
END
GO
-- Sentencias INSERT para la tabla PROVINCIAS
INSERT INTO PROVINCIAS (ID_PROV, PROVINCIA) VALUES (1, 'Buenos Aires');
INSERT INTO PROVINCIAS (ID_PROV, PROVINCIA) VALUES (2, 'Catamarca');
INSERT INTO PROVINCIAS (ID_PROV, PROVINCIA) VALUES (3, 'Chaco');
INSERT INTO PROVINCIAS (ID_PROV, PROVINCIA) VALUES (4, 'Chubut');
INSERT INTO PROVINCIAS (ID_PROV, PROVINCIA) VALUES (5, 'Córdoba');
INSERT INTO PROVINCIAS (ID_PROV, PROVINCIA) VALUES (6, 'Corrientes');
INSERT INTO PROVINCIAS (ID_PROV, PROVINCIA) VALUES (7, 'Entre Ríos');
INSERT INTO PROVINCIAS (ID_PROV, PROVINCIA) VALUES (8, 'Formosa');
INSERT INTO PROVINCIAS (ID_PROV, PROVINCIA) VALUES (9, 'Jujuy');
INSERT INTO PROVINCIAS (ID_PROV, PROVINCIA) VALUES (10, 'La Pampa');
INSERT INTO PROVINCIAS (ID_PROV, PROVINCIA) VALUES (11, 'La Rioja');
INSERT INTO PROVINCIAS (ID_PROV, PROVINCIA) VALUES (12, 'Mendoza');
INSERT INTO PROVINCIAS (ID_PROV, PROVINCIA) VALUES (13, 'Misiones');
INSERT INTO PROVINCIAS (ID_PROV, PROVINCIA) VALUES (14, 'Neuquén');
INSERT INTO PROVINCIAS (ID_PROV, PROVINCIA) VALUES (15, 'Río Negro');
INSERT INTO PROVINCIAS (ID_PROV, PROVINCIA) VALUES (16, 'Salta');
INSERT INTO PROVINCIAS (ID_PROV, PROVINCIA) VALUES (17, 'San Juan');
INSERT INTO PROVINCIAS (ID_PROV, PROVINCIA) VALUES (18, 'San Luis');
INSERT INTO PROVINCIAS (ID_PROV, PROVINCIA) VALUES (19, 'Santa Cruz');
INSERT INTO PROVINCIAS (ID_PROV, PROVINCIA) VALUES (20, 'Santa Fe');
INSERT INTO PROVINCIAS (ID_PROV, PROVINCIA) VALUES (21, 'Santiago del Estero');
INSERT INTO PROVINCIAS (ID_PROV, PROVINCIA) VALUES (22, 'Tierra del Fuego');
INSERT INTO PROVINCIAS (ID_PROV, PROVINCIA) VALUES (23, 'Tucumán');
INSERT INTO PROVINCIAS (ID_PROV, PROVINCIA) VALUES (24, 'CABA');
alter table provincias
add PROVINCIA VARCHAR(40) NOT NULL;

-- Sentencias INSERT para los barrios más populosos de Córdoba
INSERT INTO BARRIOS (ID_BARRIO, ID_PROV, BARRIO) VALUES (1, 5, 'Nueva Córdoba');
INSERT INTO BARRIOS (ID_BARRIO, ID_PROV, BARRIO) VALUES (2, 5, 'Alberdi');
INSERT INTO BARRIOS (ID_BARRIO, ID_PROV, BARRIO) VALUES (3, 5, 'Güemes');
INSERT INTO BARRIOS (ID_BARRIO, ID_PROV, BARRIO) VALUES (4, 5, 'Centro');
INSERT INTO BARRIOS (ID_BARRIO, ID_PROV, BARRIO) VALUES (5, 5, 'General Paz');
INSERT INTO BARRIOS (ID_BARRIO, ID_PROV, BARRIO) VALUES (6, 5, 'San Vicente');
INSERT INTO BARRIOS (ID_BARRIO, ID_PROV, BARRIO) VALUES (7, 5, 'Observatorio');
INSERT INTO BARRIOS (ID_BARRIO, ID_PROV, BARRIO) VALUES (8, 5, 'Alta Córdoba');
INSERT INTO BARRIOS (ID_BARRIO, ID_PROV, BARRIO) VALUES (9, 5, 'Bº Marqués de Sobremonte');
INSERT INTO BARRIOS (ID_BARRIO, ID_PROV, BARRIO) VALUES (10, 5, 'Bº Los Boulevares');
INSERT INTO BARRIOS (ID_BARRIO, ID_PROV, BARRIO) VALUES (11, 5, 'Bº Villa Belgrano');
INSERT INTO BARRIOS (ID_BARRIO, ID_PROV, BARRIO) VALUES (12, 5, 'Bº Villa Cabrera');
INSERT INTO BARRIOS (ID_BARRIO, ID_PROV, BARRIO) VALUES (13, 5, 'Bº Juniors');
INSERT INTO BARRIOS (ID_BARRIO, ID_PROV, BARRIO) VALUES (14, 5, 'Bº Jardín');
INSERT INTO BARRIOS (ID_BARRIO, ID_PROV, BARRIO) VALUES (15, 5, 'Bº Güemes');
INSERT INTO BARRIOS (ID_BARRIO, ID_PROV, BARRIO) VALUES (16, 5, 'Bº Urca');
INSERT INTO BARRIOS (ID_BARRIO, ID_PROV, BARRIO) VALUES (17, 5, 'Bº San Lorenzo');
INSERT INTO BARRIOS (ID_BARRIO, ID_PROV, BARRIO) VALUES (18, 5, 'Bº General Bustos');
INSERT INTO BARRIOS (ID_BARRIO, ID_PROV, BARRIO) VALUES (19, 5, 'Bº Parque');
INSERT INTO BARRIOS (ID_BARRIO, ID_PROV, BARRIO) VALUES (20, 5, 'Bº Pueyrredón');
INSERT INTO BARRIOS (ID_BARRIO, ID_PROV, BARRIO) VALUES (20, 5, 'Nueva Italia');