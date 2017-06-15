USE [ZooApp]
GO
/****** Object:  StoredProcedure [dbo].[ActualizarEspecie]    Script Date: 15/06/2017 17:05:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[ActualizarEspecie]
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
