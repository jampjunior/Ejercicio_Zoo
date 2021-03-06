USE [ZooApp]
GO
/****** Object:  Table [dbo].[Clasificacion]    Script Date: 15/06/2017 18:52:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clasificacion](
	[idClasificacion] [bigint] IDENTITY(1,1) NOT NULL,
	[denominacion] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Clasificacion] PRIMARY KEY CLUSTERED 
(
	[idClasificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Especies]    Script Date: 15/06/2017 18:52:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Especies](
	[idEspecie] [bigint] IDENTITY(1,1) NOT NULL,
	[idClasificacion] [bigint] NOT NULL,
	[idTipoAnimal] [bigint] NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[nPatas] [smallint] NOT NULL,
	[esMascota] [bit] NOT NULL,
 CONSTRAINT [PK_Especies] PRIMARY KEY CLUSTERED 
(
	[idEspecie] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TipoDeAnimales]    Script Date: 15/06/2017 18:52:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoDeAnimales](
	[idTipoAnimal] [bigint] IDENTITY(1,1) NOT NULL,
	[denominacion] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TipoDeAnimales] PRIMARY KEY CLUSTERED 
(
	[idTipoAnimal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Especies]  WITH CHECK ADD  CONSTRAINT [FK_Especies_Clasificacion] FOREIGN KEY([idClasificacion])
REFERENCES [dbo].[Clasificacion] ([idClasificacion])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Especies] CHECK CONSTRAINT [FK_Especies_Clasificacion]
GO
ALTER TABLE [dbo].[Especies]  WITH CHECK ADD  CONSTRAINT [FK_Especies_TipoDeAnimales] FOREIGN KEY([idTipoAnimal])
REFERENCES [dbo].[TipoDeAnimales] ([idTipoAnimal])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Especies] CHECK CONSTRAINT [FK_Especies_TipoDeAnimales]
GO
/****** Object:  StoredProcedure [dbo].[ActualizarClasificacion]    Script Date: 15/06/2017 18:52:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Actualizar (PUT)
Create PROCEDURE [dbo].[ActualizarClasificacion]
@idClasificacion bigint

,@denominacion nvarchar(50)

AS
BEGIN
update Clasificacion SET
denominacion = @denominacion
WHERE idClasificacion = @idClasificacion
END

GO
/****** Object:  StoredProcedure [dbo].[ActualizarEspecie]    Script Date: 15/06/2017 18:52:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ActualizarEspecie]
@idEspecie bigint
,@idClasificacion bigint
,@idTipoAnimal bigint
,@nombre nvarchar(50)
,@nPatas smallint
,@esMascota bit
AS
BEGIN
update Especies SET
nombre = @nombre
WHERE idEspecie = @idEspecie
END

GO
/****** Object:  StoredProcedure [dbo].[ActualizarTipoAnimal]    Script Date: 15/06/2017 18:52:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Actualizar (PUT)
Create PROCEDURE [dbo].[ActualizarTipoAnimal]
@idTipoAnimal bigint

,@denominacion nvarchar(50)
AS
BEGIN
update TipoDeAnimales SET
denominacion = @denominacion
WHERE idTipoAnimal = @idTipoAnimal
END

GO
/****** Object:  StoredProcedure [dbo].[AgregarClasificacion]    Script Date: 15/06/2017 18:52:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--AGREGAR (POST)
CREATE PROCEDURE [dbo].[AgregarClasificacion]
 @denominacion nvarchar(50)
AS
BEGIN
INSERT INTO Clasificacion(denominacion) VALUES(@denominacion)
END

GO
/****** Object:  StoredProcedure [dbo].[AgregarEspecie]    Script Date: 15/06/2017 18:52:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AgregarEspecie]

@idClasificacion bigint
,@idTipoAnimal bigint
,@nombre nvarchar(50)
,@nPatas smallint
,@esMascota bit
AS
BEGIN
INSERT INTO Especies(idClasificacion, idTipoAnimal,nombre , nPatas, esMascota) 
VALUES(@idClasificacion ,@idTipoAnimal,@nombre, @nPatas, @esMascota)
END
GO
/****** Object:  StoredProcedure [dbo].[AgregarTipoAnimal]    Script Date: 15/06/2017 18:52:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--AGREGAR (POST)
CREATE PROCEDURE [dbo].[AgregarTipoAnimal]
 @denominacion nvarchar(50)
AS
BEGIN
INSERT INTO TipoDeAnimales(denominacion) VALUES(@denominacion)
END

GO
/****** Object:  StoredProcedure [dbo].[EliminarClasificacion]    Script Date: 15/06/2017 18:52:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--ELIMINAR (DELETE)
CREATE PROCEDURE [dbo].[EliminarClasificacion]
@idClasificacion bigint
AS
BEGIN
DELETE FROM Clasificacion 
WHERE idClasificacion = @idClasificacion
END

GO
/****** Object:  StoredProcedure [dbo].[EliminarEspecie]    Script Date: 15/06/2017 18:52:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarEspecie]
@idEspecie bigint
AS
BEGIN

DELETE FROM Especies 
WHERE idEspecie = @idEspecie
END

GO
/****** Object:  StoredProcedure [dbo].[EliminarTipoAnimal]    Script Date: 15/06/2017 18:52:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--ELIMINAR (DELETE)
CREATE PROCEDURE [dbo].[EliminarTipoAnimal]
@idTipoAnimal bigint
AS
BEGIN
DELETE FROM TipoDeAnimales 
WHERE idTipoAnimal = @idTipoAnimal
END

GO
/****** Object:  StoredProcedure [dbo].[GET_Clasificacion_ID]    Script Date: 15/06/2017 18:52:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GET_Clasificacion_ID]
@idClasificacion bigint
AS
BEGIN
SELECT *
FROM Clasificacion
WHERE Clasificacion.idClasificacion = @idClasificacion
ORDER BY Clasificacion.denominacion
END


GO
/****** Object:  StoredProcedure [dbo].[GET_ESPECIE_ID]    Script Date: 15/06/2017 18:52:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GET_ESPECIE_ID]
@idEspecie bigint
AS
BEGIN
SELECT *
FROM Especies
WHERE Especies.idEspecie = @idEspecie
ORDER BY Especies.nombre
END

GO
/****** Object:  StoredProcedure [dbo].[GET_TipoAnimal_ID]    Script Date: 15/06/2017 18:52:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Creacion del GET id
CREATE PROCEDURE [dbo].[GET_TipoAnimal_ID]
@idTipoAnimal bigint
AS
BEGIN
SELECT *
FROM TipoDeAnimales
WHERE TipoDeAnimales.idTipoAnimal = @idTipoAnimal
ORDER BY TipoDeAnimales.denominacion
END

GO
/****** Object:  StoredProcedure [dbo].[GetClasificacion]    Script Date: 15/06/2017 18:52:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetClasificacion]
AS
BEGIN
select
idClasificacion , denominacion
FROM Clasificacion
END

GO
/****** Object:  StoredProcedure [dbo].[GetEspecies]    Script Date: 15/06/2017 18:52:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetEspecies]
AS
BEGIN
select
idEspecie, idClasificacion, idTipoAnimal, nombre, nPatas, esMascota 
FROM Especies
END

GO
/****** Object:  StoredProcedure [dbo].[GetTiposdeAnimales]    Script Date: 15/06/2017 18:52:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Creacion del GET de Tipos de Animales
CREATE PROCEDURE [dbo].[GetTiposdeAnimales]
AS
BEGIN
select
idTipoAnimal , denominacion
FROM TipoDeAnimales
END

GO
/****** Object:  StoredProcedure [dbo].[InformeAnimales]    Script Date: 15/06/2017 18:52:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InformeAnimales]
AS
BEGIN
SELECT *
FROM Especies
   -- INNER JOIN Clasificacion on Clasificacion.denominacion = Clasificacion.denominacion
 --   INNER JOIN TipoDeAnimales on TipoDeAnimales.idTipoAnimal = TipoDeAnimales.idTipoAnimal
	--ORDER BY nombre
	
END
GO
