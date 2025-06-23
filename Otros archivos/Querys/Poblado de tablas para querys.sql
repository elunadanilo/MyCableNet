USE EnvioDB;
GO

---------------------------------------------------------------------------------
---- 1) Limpiar datos existentes (opcional)
---------------------------------------------------------------------------------
--TRUNCATE TABLE dbo.Envio;
--TRUNCATE TABLE dbo.Producto;
--TRUNCATE TABLE dbo.Finca;
--TRUNCATE TABLE dbo.Empresa;
--TRUNCATE TABLE dbo.Cliente;
--GO

-------------------------------------------------------------------------------
-- 2) Poblar tablas maestras
-------------------------------------------------------------------------------

INSERT INTO dbo.Cliente (CodLocalidad, Cliente, Direccion, Nit)
VALUES
  ('LOC1', 'Cliente A', 'Av. Siempre Viva 123', 'NIT-A'),
  ('LOC1', 'Cliente B', 'Calle Falsa 456',     'NIT-B'),
  ('LOC2', 'Cliente C', 'Boulevard 789',       'NIT-C');

INSERT INTO dbo.Producto (CodProducto, CodLocalidad, Producto)
VALUES
  ('P001','LOC1','Producto X'),
  ('P002','LOC1','Producto Y'),
  ('P003','LOC2','Producto Z');

INSERT INTO dbo.Empresa (CodEmpresa, Empresa, Nit)
VALUES
  ('EMP1','Empresa Alfa','NIT-EMP1'),
  ('EMP2','Empresa Beta','NIT-EMP2');

INSERT INTO dbo.Finca (CodEmpresa, CodFinca, Finca)
VALUES
  ('EMP1','F001','Finca Central'),
  ('EMP2','F002','Finca Secundaria');
GO

-------------------------------------------------------------------------------
-- 3) Envíos 2014: datos para Top 10 peso bruto
-------------------------------------------------------------------------------

DECLARE @m INT = 1;

WHILE @m <= 12
BEGIN
  INSERT INTO dbo.Envio (CodEnvio, NoEnvio, IdCliente, IdProducto, Fecha, PBruto)
  VALUES
    ('E14A' + RIGHT('0' + CAST(@m AS VARCHAR(2)),2),
     'N14A' + RIGHT('0' + CAST(@m AS VARCHAR(2)),2),
     1, 1,
     DATEFROMPARTS(2014,@m,15),
     100 + @m*10);

  SET @m = @m + 1;
END

SET @m = 1;
WHILE @m <= 12
BEGIN
  INSERT INTO dbo.Envio (CodEnvio, NoEnvio, IdCliente, IdProducto, Fecha, PBruto)
  VALUES
    ('E14B' + RIGHT('0' + CAST(@m AS VARCHAR(2)),2),
     'N14B' + RIGHT('0' + CAST(@m AS VARCHAR(2)),2),
     2, 2,
     DATEFROMPARTS(2014,@m,20),
     50 + @m*5);

  SET @m = @m + 1;
END

SET @m = 1;
WHILE @m <= 6
BEGIN
  INSERT INTO dbo.Envio (CodEnvio, NoEnvio, IdCliente, IdProducto, Fecha, PBruto)
  VALUES
    ('E14C' + RIGHT('0' + CAST(@m AS VARCHAR(2)),2),
     'N14C' + RIGHT('0' + CAST(@m AS VARCHAR(2)),2),
     3, 3,
     DATEFROMPARTS(2014,@m,10),
     75 + @m*8);

  SET @m = @m + 1;
END
GO

-------------------------------------------------------------------------------
-- 4) Envíos primer semestre 2015: para conteo mensual por finca
-------------------------------------------------------------------------------

DECLARE @mes INT, @i INT;

-- Finca Central (IdFinca=1): 120 envíos cada mes
SET @mes = 1;
WHILE @mes <= 6
BEGIN
  SET @i = 1;
  WHILE @i <= 120
  BEGIN
    INSERT INTO dbo.Envio (CodEnvio, NoEnvio, IdCliente, IdProducto, IdEmpresa, IdFinca, Fecha, PBruto)
    VALUES
      ('E15C' 
       + RIGHT('0' + CAST(@mes AS VARCHAR(2)),2)
       + RIGHT('00' + CAST(@i AS VARCHAR(3)),3),
       'N15C' 
       + RIGHT('0' + CAST(@mes AS VARCHAR(2)),2)
       + RIGHT('00' + CAST(@i AS VARCHAR(3)),3),
       1, 1, 1, 1,
       DATEFROMPARTS(2015,@mes,5),
       10.0);
    SET @i = @i + 1;
  END
  SET @mes = @mes + 1;
END

-- Finca Secundaria (IdFinca=2): 80 envíos cada mes
SET @mes = 1;
WHILE @mes <= 6
BEGIN
  SET @i = 1;
  WHILE @i <= 80
  BEGIN
    INSERT INTO dbo.Envio (CodEnvio, NoEnvio, IdCliente, IdProducto, IdEmpresa, IdFinca, Fecha, PBruto)
    VALUES
      ('E15S' 
       + RIGHT('0' + CAST(@mes AS VARCHAR(2)),2)
       + RIGHT('00' + CAST(@i AS VARCHAR(3)),3),
       'N15S' 
       + RIGHT('0' + CAST(@mes AS VARCHAR(2)),2)
       + RIGHT('00' + CAST(@i AS VARCHAR(3)),3),
       2, 2, 2, 2,
       DATEFROMPARTS(2015,@mes,10),
       5.0);
    SET @i = @i + 1;
  END
  SET @mes = @mes + 1;
END
GO

PRINT 'Datos de prueba generados con éxito.';
