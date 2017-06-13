--Creacion del GET de Clasificacion
CREATE PROCEDURE [dbo].[GetClasificacion]
AS
BEGIN
select
idClasificacion , denominacion
FROM Clasificacion
END
GO
--Creacion del GET id

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
--ELIMINAR (DELETE)
CREATE PROCEDURE [dbo].[EliminarClasificacion]
@idClasificacion bigint
AS
BEGIN
DELETE FROM Clasificacion 
WHERE idClasificacion = @idClasificacion
END
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
--AGREGAR (POST)
CREATE PROCEDURE [dbo].[AgregarClasificacion]
 @denominacion nvarchar(50)
AS
BEGIN
INSERT INTO Clasificacion(denominacion) VALUES(@denominacion)
END
GO