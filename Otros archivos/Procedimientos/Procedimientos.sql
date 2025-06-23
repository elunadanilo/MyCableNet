--Este procedimiento agrupa los ingresos totales por mes para un año dado.

--CREATE OR ALTER PROCEDURE [dbo].[SP_ObtenerIngresosMensuales]
--    @Ano INT
--AS
--BEGIN
--    SET NOCOUNT ON;
--    SELECT 
--        DATENAME(MONTH, f.Fecha) AS Mes,
--        SUM(f.Total)            AS IngresoTotal
--    FROM Facturas f
--    WHERE YEAR(f.Fecha) = @Ano
--    GROUP BY MONTH(f.Fecha), DATENAME(MONTH, f.Fecha)
--    ORDER BY Mes;
--END;

EXEC dbo.SP_ObtenerIngresosMensuales @Ano = 2025;

--Este procedimiento lista los clientes con facturas vencidas sin pago tras un número de días especificado.

--CREATE OR ALTER PROCEDURE [dbo].[SP_ObtenerClientesMorosos]
--    @DiasVencidos INT
--AS
--BEGIN
--    SET NOCOUNT ON;
--    SELECT
--        c.Id                   AS ClienteId,
--        c.Nombre               AS NombreCliente,
--        COUNT(f.Id)            AS FacturasVencidas,
--        SUM(df.CostoMensual)   AS MontoTotalAdeudado
--    FROM Clientes c
--    JOIN Facturas f ON f.ClienteId = c.Id
--    LEFT JOIN Pagos p ON p.FacturaId = f.Id
--    JOIN DetallesFactura df ON df.FacturaId = f.Id
--    WHERE p.Id IS NULL
--      AND DATEDIFF(DAY, f.Fecha, GETDATE()) > @DiasVencidos
--    GROUP BY c.Id, c.Nombre
--    HAVING COUNT(f.Id) > 0
--    ORDER BY MontoTotalAdeudado DESC;
--END;

EXEC dbo.SP_ObtenerClientesMorosos @DiasVencidos = 10;