USE [ZooApp]
GO
/****** Object:  StoredProcedure [dbo].[AgregarEspecie]    Script Date: 14/06/2017 19:21:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[AgregarEspecie]
@idEspecie bigint
,@idClasificacion bigint
,@idTipoAnimal bigint
,@nombre nvarchar(50)
,@nPatas smallint
,@esMascota bit
AS
BEGIN
INSERT INTO Especies(nombre) VALUES(@nombre)
END
