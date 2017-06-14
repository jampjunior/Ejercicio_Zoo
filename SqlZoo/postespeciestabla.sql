USE [ZooApp]
GO
/****** Object:  StoredProcedure [dbo].[AgregarEspecie]    Script Date: 14/06/2017 21:22:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[AgregarEspecie]

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