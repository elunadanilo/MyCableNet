-- 1) Crear la base de datos
IF EXISTS(SELECT 1 FROM sys.databases WHERE name = 'EnvioDB')
    DROP DATABASE EnvioDB;
GO

CREATE DATABASE EnvioDB;
GO

USE EnvioDB;
GO

-------------------------------------------------------------------------------
-- 2) Tablas maestras
-------------------------------------------------------------------------------

-- Clientes
CREATE TABLE dbo.Cliente
(
    IdCliente       INT             IDENTITY(1,1)   PRIMARY KEY,
    CodLocalidad    VARCHAR(50)     NOT NULL,
    Cliente         VARCHAR(100)    NOT NULL,
    Direccion       VARCHAR(200)    NULL,
    Nit             VARCHAR(50)     NULL,
    [Grupo]         VARCHAR(50)     NULL,
    RowGuid         UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
    ClienteLegal    BIT             NOT NULL CONSTRAINT DF_Cliente_ClienteLegal DEFAULT(0),
    Contrato        VARCHAR(50)     NULL,
    CodTipoCliente  VARCHAR(50)     NULL,
    Exterior        BIT             NOT NULL CONSTRAINT DF_Cliente_Exterior DEFAULT(0)
);
GO

-- Empresa
CREATE TABLE dbo.Empresa
(
    IdEmpresa   INT             IDENTITY(1,1)   PRIMARY KEY,
    CodEmpresa  VARCHAR(50)     NOT NULL,
    Empresa     VARCHAR(100)    NOT NULL,
    Nit         VARCHAR(50)     NULL,
    Direccion   VARCHAR(200)    NULL,
    RowGuid     UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID()
);
GO

-- Proveedor
CREATE TABLE dbo.Proveedor
(
    IdProveedor    INT             IDENTITY(1,1)   PRIMARY KEY,
    CodProveedor   VARCHAR(50)     NOT NULL,
    CodLocalidad   VARCHAR(50)     NOT NULL,
    Proveedor      VARCHAR(100)    NOT NULL,
    Direccion      VARCHAR(200)    NULL,
    Nit            VARCHAR(50)     NULL,
    RowGuid        UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
    ProveedorLegal BIT             NOT NULL CONSTRAINT DF_Proveedor_ProveedorLegal DEFAULT(0)
);
GO

-- Usuario
CREATE TABLE dbo.Usuario
(
    IdUsuario   INT             IDENTITY(1,1)   PRIMARY KEY,
    Login       VARCHAR(50)     NOT NULL,
    CodLocalidad VARCHAR(50)    NULL,
    CodPerfil   VARCHAR(50)     NULL,
    Nombres     VARCHAR(100)    NOT NULL,
    Apellidos   VARCHAR(100)    NOT NULL,
    Cedula      VARCHAR(50)     NULL,
    Correo      VARCHAR(100)    NULL,
    [Password]  VARCHAR(200)    NOT NULL,
    Historial   VARCHAR(MAX)    NULL,
    RowGuid     UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
    Bloqueado   BIT             NOT NULL CONSTRAINT DF_Usuario_Bloqueado DEFAULT(0),
    Impresora   VARCHAR(100)    NULL,
    TipoPapel   VARCHAR(50)     NULL
);
GO

-- Empleado
CREATE TABLE dbo.Empleado
(
    IdEmpleado      INT             IDENTITY(1,1)   PRIMARY KEY,
    CodEmpleado     VARCHAR(50)     NOT NULL,
    CodLocalidad    VARCHAR(50)     NOT NULL,
    CodPuesto       VARCHAR(50)     NULL,
    Nombres         VARCHAR(100)    NOT NULL,
    Apellidos       VARCHAR(100)    NOT NULL,
    Cedula          VARCHAR(50)     NULL,
    RowGuid         UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID()
);
GO

-- Producto
CREATE TABLE dbo.Producto
(
    IdProducto             INT             IDENTITY(1,1)   PRIMARY KEY,
    CodProducto            VARCHAR(50)     NOT NULL,
    CodLocalidad           VARCHAR(50)     NOT NULL,
    Producto               VARCHAR(100)    NOT NULL,
    Laboratorio            VARCHAR(100)    NULL,
    RowGuid                UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
    Abreviatura            VARCHAR(50)     NULL,
    DescAbreviatura        VARCHAR(100)    NULL,
    AplicaTaraFrio         BIT             NOT NULL CONSTRAINT DF_Producto_AplicaTaraFrio DEFAULT(0),
    AplicaTaraAutomatica   BIT             NOT NULL CONSTRAINT DF_Producto_AplicaTaraAuto DEFAULT(0),
    AplicaNoEnvioManual    BIT             NOT NULL CONSTRAINT DF_Producto_AplicaNoEnvio DEFAULT(0),
    RestriccionVehiculo    BIT             NOT NULL CONSTRAINT DF_Producto_RestricVehic DEFAULT(0)
);
GO

-- Finca
CREATE TABLE dbo.Finca
(
    IdFinca          INT             IDENTITY(1,1)   PRIMARY KEY,
    CodEmpresa       VARCHAR(50)     NOT NULL,
    CodFinca         VARCHAR(50)     NOT NULL,
    Finca            VARCHAR(100)    NOT NULL,
    CodEmpresaOw     VARCHAR(50)     NULL,
    CodLocalidadOw   VARCHAR(50)     NULL,
    RowGuid          UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID()
);
GO

-- Pipa
CREATE TABLE dbo.Pipa
(
    IdPipa              INT             IDENTITY(1,1)   PRIMARY KEY,
    CodPipa             VARCHAR(50)     NOT NULL,
    CodTransportista    VARCHAR(50)     NULL,
    CodLocalidad        VARCHAR(50)     NULL,
    CodTipoVehiculo     VARCHAR(50)     NULL,
    Numero              VARCHAR(50)     NULL,
    Capacidad           DECIMAL(18,2)   NULL,
    EsPipa              BIT             NOT NULL CONSTRAINT DF_Pipa_EsPipa DEFAULT(0),
    Tara                DECIMAL(18,2)   NULL,
    RowGuid             UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
    UnidadNegocio       VARCHAR(50)     NULL,
    Activo              BIT             NOT NULL CONSTRAINT DF_Pipa_Activo DEFAULT(1),
    Propio              BIT             NOT NULL CONSTRAINT DF_Pipa_Propio DEFAULT(0),
    UT_UMT              VARCHAR(50)     NULL,
    Estado              VARCHAR(50)     NULL,
    PlacaNac            VARCHAR(50)     NULL,
    TiempoRestriccion   VARCHAR(50)     NULL
);
GO

-------------------------------------------------------------------------------
-- 3) Tabla central: Envíos
-------------------------------------------------------------------------------

CREATE TABLE dbo.Envio
(
    IdEnvio         INT             IDENTITY(1,1)   PRIMARY KEY,
    CodEnvio        VARCHAR(50)     NOT NULL,
    NoEnvio         VARCHAR(50)     NULL,
    CodEstado       VARCHAR(50)     NULL,
    IdTipoDoc       VARCHAR(50)     NULL,
    IdTipoMov       VARCHAR(50)     NULL,
    CodConovy       VARCHAR(50)     NULL,
    CodLocalidad    VARCHAR(50)     NULL,
    -- FKs:
    IdCliente       INT             NOT NULL,
    IdProveedor     INT             NULL,
    IdEmpresa       INT             NULL,
    IdPipa          INT             NULL,
    IdFinca         INT             NULL,
    IdProducto      INT             NULL,
    -- Datos del envío:
    Fecha           DATETIME2       NOT NULL DEFAULT SYSUTCDATETIME(),
    FTara           DECIMAL(18,2)   NULL,
    FBruto          DECIMAL(18,2)   NULL,
    FBulto          DECIMAL(18,2)   NULL,
    PTara           DECIMAL(18,2)   NULL,
    PBruto          DECIMAL(18,2)   NULL,
    RowGuid         UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID()
);
GO

-------------------------------------------------------------------------------
-- 4) Constraints de integridad referencial
-------------------------------------------------------------------------------

ALTER TABLE dbo.Envio 
  ADD CONSTRAINT FK_Envio_Cliente
    FOREIGN KEY (IdCliente) REFERENCES dbo.Cliente(IdCliente);

ALTER TABLE dbo.Envio 
  ADD CONSTRAINT FK_Envio_Proveedor
    FOREIGN KEY (IdProveedor) REFERENCES dbo.Proveedor(IdProveedor);

ALTER TABLE dbo.Envio 
  ADD CONSTRAINT FK_Envio_Empresa
    FOREIGN KEY (IdEmpresa) REFERENCES dbo.Empresa(IdEmpresa);

ALTER TABLE dbo.Envio 
  ADD CONSTRAINT FK_Envio_Pipa
    FOREIGN KEY (IdPipa) REFERENCES dbo.Pipa(IdPipa);

ALTER TABLE dbo.Envio 
  ADD CONSTRAINT FK_Envio_Finca
    FOREIGN KEY (IdFinca) REFERENCES dbo.Finca(IdFinca);

ALTER TABLE dbo.Envio 
  ADD CONSTRAINT FK_Envio_Producto
    FOREIGN KEY (IdProducto) REFERENCES dbo.Producto(IdProducto);

GO

-------------------------------------------------------------------------------
-- 5) Índices de apoyo (opcional)
-------------------------------------------------------------------------------

CREATE INDEX IDX_Envio_Fecha    ON dbo.Envio(Fecha);
CREATE INDEX IDX_Envio_Cliente   ON dbo.Envio(IdCliente);
CREATE INDEX IDX_Envio_Producto  ON dbo.Envio(IdProducto);
GO

PRINT 'Base de datos EnvioDB creada con éxito.';  
