USE EnvioDB;
GO

SELECT TOP 10
    c.cliente         AS NombreCliente,
    c.direccion       AS DireccionCliente,
    c.nit             AS NITCliente,
    p.producto        AS NombreProducto,
    SUM(e.PBruto)     AS PesoBrutoTotal,
    MONTH(e.Fecha)    AS Mes,
    YEAR(e.Fecha)     AS Anio
FROM dbo.Envio e
INNER JOIN dbo.Cliente  c ON e.IdCliente   = c.IdCliente
INNER JOIN dbo.Producto p ON e.IdProducto  = p.IdProducto
WHERE YEAR(e.Fecha) = 2014
GROUP BY
    c.cliente,
    c.direccion,
    c.nit,
    p.producto,
    MONTH(e.Fecha),
    YEAR(e.Fecha)
ORDER BY
    PesoBrutoTotal DESC;


USE EnvioDB;
GO

SELECT
    f.finca          AS NombreFinca,
    em.empresa       AS NombreEmpresa,
    MONTH(e.Fecha)   AS Mes,
    COUNT(*)         AS TotalEnvios
FROM dbo.Envio     e
INNER JOIN dbo.Finca   f  ON e.IdFinca   = f.IdFinca
INNER JOIN dbo.Empresa em ON e.IdEmpresa = em.IdEmpresa
WHERE e.Fecha >= '2015-01-01'
  AND e.Fecha <  '2015-07-01'
GROUP BY
    f.finca,
    em.empresa,
    MONTH(e.Fecha)
HAVING COUNT(*) >= 100
ORDER BY
    f.finca,
    Mes;
