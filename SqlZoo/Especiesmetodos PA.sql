--Creacion del GET de Especie
CREATE PROCEDURE [dbo].[GetEspecies]
AS
BEGIN
select
idEspecie, idClasificacion, idTipoAnimal, nombre, nPatas, esMascota 
FROM Especies
END
GO
--Creacion del GET id

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
--ELIMINAR (DELETE)
CREATE PROCEDURE [dbo].[EliminarEspecie]
@idEspecie bigint
AS
BEGIN
DELETE FROM Especies 
WHERE idEspecie = @idEspecie
END
GO
--Actualizar (PUT)
ALTER PROCEDURE [dbo].[ActualizarEspecie]
@idEspecie bigint

,@nombre nvarchar(50)

AS
BEGIN
update Especies SET
nombre = @nombre
WHERE idEspecie = @idEspecie
END
GO
--AGREGAR (POST)
CREATE PROCEDURE [dbo].[AgregarEspecie]
 @nombre nvarchar(50)
AS
BEGIN
INSERT INTO Especies(nombre) VALUES(@nombre)
END
GO