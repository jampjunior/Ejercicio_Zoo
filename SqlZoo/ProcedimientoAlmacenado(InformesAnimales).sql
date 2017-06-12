ALTER PROCEDURE InformeAnimales
AS
BEGIN
SELECT *
FROM Especies
   -- INNER JOIN Clasificacion on Clasificacion.denominacion = Clasificacion.denominacion
 --   INNER JOIN TipoDeAnimales on TipoDeAnimales.idTipoAnimal = TipoDeAnimales.idTipoAnimal
	--ORDER BY nombre
	
END