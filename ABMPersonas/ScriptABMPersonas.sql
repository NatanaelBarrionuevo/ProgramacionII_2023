USE [TUPPI]
GO
/****** Object:  Table [dbo].[estado_civil]    Script Date: 16/5/2023 11:19:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[estado_civil](
	[id_estado_civil] [int] NOT NULL,
	[n_estado_civil] [varchar](30) NULL,
 CONSTRAINT [PK_estado_civil] PRIMARY KEY CLUSTERED 
(
	[id_estado_civil] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[personas]    Script Date: 16/5/2023 11:19:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[personas](
	[apellido] [varchar](30) NULL,
	[nombres] [varchar](30) NULL,
	[tipo_documento] [int] NULL,
	[documento] [int] NOT NULL,
	[estado_civil] [int] NULL,
	[sexo] [int] NULL,
	[fallecio] [bit] NULL,
	[fecha_nacimiento] [date] NULL,
 CONSTRAINT [PK_personas] PRIMARY KEY CLUSTERED 
(
	[documento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tipo_documento]    Script Date: 16/5/2023 11:19:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tipo_documento](
	[id_tipo_documento] [int] NOT NULL,
	[n_tipo_documento] [varchar](30) NULL,
 CONSTRAINT [PK_tipo_documento] PRIMARY KEY CLUSTERED 
(
	[id_tipo_documento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[estado_civil] ([id_estado_civil], [n_estado_civil]) VALUES (1, N'Soltero')
INSERT [dbo].[estado_civil] ([id_estado_civil], [n_estado_civil]) VALUES (2, N'Casado')
INSERT [dbo].[estado_civil] ([id_estado_civil], [n_estado_civil]) VALUES (3, N'Viudo')
INSERT [dbo].[estado_civil] ([id_estado_civil], [n_estado_civil]) VALUES (4, N'Separado')
GO
INSERT [dbo].[personas] ([apellido], [nombres], [tipo_documento], [documento], [estado_civil], [sexo], [fallecio], [fecha_nacimiento]) VALUES (N'Perez', N'Juan', 2, 123456, 2, 1, 0, CAST(N'2001-01-01' AS Date))
INSERT [dbo].[personas] ([apellido], [nombres], [tipo_documento], [documento], [estado_civil], [sexo], [fallecio], [fecha_nacimiento]) VALUES (N'Luna', N'Ana', 5, 456789, 2, 1, 0, CAST(N'2003-03-03' AS Date))
INSERT [dbo].[personas] ([apellido], [nombres], [tipo_documento], [documento], [estado_civil], [sexo], [fallecio], [fecha_nacimiento]) VALUES (N'Soto', N'Mario', 1, 789123, 3, 2, 0, CAST(N'2005-05-05' AS Date))
GO
INSERT [dbo].[tipo_documento] ([id_tipo_documento], [n_tipo_documento]) VALUES (1, N'DNI')
INSERT [dbo].[tipo_documento] ([id_tipo_documento], [n_tipo_documento]) VALUES (2, N'LE')
INSERT [dbo].[tipo_documento] ([id_tipo_documento], [n_tipo_documento]) VALUES (3, N'LC')
INSERT [dbo].[tipo_documento] ([id_tipo_documento], [n_tipo_documento]) VALUES (4, N'Cedula')
INSERT [dbo].[tipo_documento] ([id_tipo_documento], [n_tipo_documento]) VALUES (5, N'Pasaporte')
GO
