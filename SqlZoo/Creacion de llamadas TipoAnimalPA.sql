--Creacion del GET de Tipos de Animales
CREATE PROCEDURE [dbo].[GetTiposdeAnimales]
AS
BEGIN
select
idTipoAnimal , denominacion
FROM TipoDeAnimales
END
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
--ELIMINAR (DELETE)
CREATE PROCEDURE [dbo].[EliminarTipoAnimal]
@idTipoAnimal bigint
AS
BEGIN
DELETE FROM TipoDeAnimales 
WHERE idTipoAnimal = @idTipoAnimal
END
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
--AGREGAR (POST)
CREATE PROCEDURE [dbo].[AgregarTipoAnimal]
 @denominacion nvarchar(50)
AS
BEGIN
INSERT INTO TipoDeAnimales(denominacion) VALUES(@denominacion)
END
GO