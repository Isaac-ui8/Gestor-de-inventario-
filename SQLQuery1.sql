-- Crear la base de datos si no existe
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'Query1')
BEGIN
    CREATE DATABASE Query1;
END
GO

-- Cambiar al contexto de la base de datos
USE Query1;
GO

-- Crear la tabla de Categorías con índice
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Categories')
BEGIN
    CREATE TABLE Categories (
        CategoryId INT PRIMARY KEY IDENTITY(1,1),  -- Identificador único de la categoría, con incremento automático
        CategoryName VARCHAR(100) NOT NULL,          -- Nombre de la categoría (Ej. Celulares, Accesorios, Computadoras)
        CONSTRAINT UC_CategoryName UNIQUE (CategoryName) -- Garantizar nombres únicos de categorías
    );
    -- Crear un índice para mejorar las consultas por CategoryName
    CREATE NONCLUSTERED INDEX IX_Categories_CategoryName ON Categories(CategoryName);
END
GO

-- Crear la tabla de Proveedores con índice
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Providers')
BEGIN
    CREATE TABLE Providers (
        ProviderId INT PRIMARY KEY IDENTITY(1,1),  -- Identificador único del proveedor, con incremento automático
        ProviderName VARCHAR(100) NOT NULL,          -- Nombre del proveedor (Ej. Samsung, Apple, HP)
        CONSTRAINT UC_ProviderName UNIQUE (ProviderName) -- Garantizar nombres únicos de proveedores
    );
    -- Crear un índice para mejorar las consultas por ProviderName
    CREATE NONCLUSTERED INDEX IX_Providers_ProviderName ON Providers(ProviderName);
END
GO

-- Crear la tabla de Productos con claves foráneas de Categorías y Proveedores
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Products')
BEGIN
    CREATE TABLE Products (
        ProductId INT PRIMARY KEY IDENTITY(1,1),   -- Identificador único del producto, con incremento automático
        ProductName VARCHAR(100) NOT NULL,           -- Nombre del producto (Ej. Samsung Galaxy S21, iPhone 13)
        ProductCode VARCHAR(50),                     -- Código único del producto
        ProductPrice DECIMAL(18, 2) NOT NULL,        -- Precio del producto
        ProductStock INT NOT NULL,                   -- Stock disponible del producto
        CategoryId INT,                              -- ID de la categoría (relación con la tabla Categories)
        ProviderId INT,                              -- ID del proveedor (relación con la tabla Providers)
        CONSTRAINT FK_Products_Category FOREIGN KEY (CategoryId) REFERENCES Categories(CategoryId) ON DELETE CASCADE,  -- Clave foránea a la categoría
        CONSTRAINT FK_Products_Provider FOREIGN KEY (ProviderId) REFERENCES Providers(ProviderId) ON DELETE CASCADE,  -- Clave foránea al proveedor
        CONSTRAINT UC_ProductCode UNIQUE (ProductCode) -- Garantizar que el código de producto sea único
    );
    -- Crear índices para mejorar el rendimiento de consultas por categoría y proveedor
    CREATE NONCLUSTERED INDEX IX_Products_CategoryId ON Products(CategoryId);
    CREATE NONCLUSTERED INDEX IX_Products_ProviderId ON Products(ProviderId);
END
GO

-- Insertar categorías si no existen
INSERT INTO Categories (CategoryName)
SELECT 'Celulares' WHERE NOT EXISTS (SELECT 1 FROM Categories WHERE CategoryName = 'Celulares')
UNION ALL
SELECT 'Computadoras' WHERE NOT EXISTS (SELECT 1 FROM Categories WHERE CategoryName = 'Computadoras')
UNION ALL
SELECT 'Accesorios' WHERE NOT EXISTS (SELECT 1 FROM Categories WHERE CategoryName = 'Accesorios')
UNION ALL
SELECT 'Tablets' WHERE NOT EXISTS (SELECT 1 FROM Categories WHERE CategoryName = 'Tablets');
GO

-- Insertar proveedores si no existen
INSERT INTO Providers (ProviderName)
SELECT 'Samsung' WHERE NOT EXISTS (SELECT 1 FROM Providers WHERE ProviderName = 'Samsung')
UNION ALL
SELECT 'Apple' WHERE NOT EXISTS (SELECT 1 FROM Providers WHERE ProviderName = 'Apple')
UNION ALL
SELECT 'HP' WHERE NOT EXISTS (SELECT 1 FROM Providers WHERE ProviderName = 'HP')
UNION ALL
SELECT 'Lenovo' WHERE NOT EXISTS (SELECT 1 FROM Providers WHERE ProviderName = 'Lenovo')
UNION ALL
SELECT 'Acer' WHERE NOT EXISTS (SELECT 1 FROM Providers WHERE ProviderName = 'Acer');
GO

-- Insertar productos si no existen
BEGIN TRANSACTION;

-- Celulares
INSERT INTO Products (ProductName, ProductCode, ProductPrice, ProductStock, CategoryId, ProviderId)
SELECT 'Samsung Galaxy S21', 'SGS21', 799.99, 50, CategoryId, ProviderId
FROM Categories c, Providers p
WHERE c.CategoryName = 'Celulares' AND p.ProviderName = 'Samsung'
AND NOT EXISTS (SELECT 1 FROM Products WHERE ProductCode = 'SGS21');

INSERT INTO Products (ProductName, ProductCode, ProductPrice, ProductStock, CategoryId, ProviderId)
SELECT 'iPhone 13', 'IP13', 999.99, 30, CategoryId, ProviderId
FROM Categories c, Providers p
WHERE c.CategoryName = 'Celulares' AND p.ProviderName = 'Apple'
AND NOT EXISTS (SELECT 1 FROM Products WHERE ProductCode = 'IP13');

-- Computadoras
INSERT INTO Products (ProductName, ProductCode, ProductPrice, ProductStock, CategoryId, ProviderId)
SELECT 'HP Pavilion x360', 'HPX360', 899.99, 20, CategoryId, ProviderId
FROM Categories c, Providers p
WHERE c.CategoryName = 'Computadoras' AND p.ProviderName = 'HP'
AND NOT EXISTS (SELECT 1 FROM Products WHERE ProductCode = 'HPX360');

INSERT INTO Products (ProductName, ProductCode, ProductPrice, ProductStock, CategoryId, ProviderId)
SELECT 'Lenovo ThinkPad X1', 'LTX1', 1199.99, 15, CategoryId, ProviderId
FROM Categories c, Providers p
WHERE c.CategoryName = 'Computadoras' AND p.ProviderName = 'Lenovo'
AND NOT EXISTS (SELECT 1 FROM Products WHERE ProductCode = 'LTX1');

-- Accesorios
INSERT INTO Products (ProductName, ProductCode, ProductPrice, ProductStock, CategoryId, ProviderId)
SELECT 'Cargador Inalámbrico', 'CI123', 29.99, 100, CategoryId, ProviderId
FROM Categories c, Providers p
WHERE c.CategoryName = 'Accesorios' AND p.ProviderName = 'Samsung'
AND NOT EXISTS (SELECT 1 FROM Products WHERE ProductCode = 'CI123');

INSERT INTO Products (ProductName, ProductCode, ProductPrice, ProductStock, CategoryId, ProviderId)
SELECT 'Funda iPhone 13', 'FIP13', 19.99, 80, CategoryId, ProviderId
FROM Categories c, Providers p
WHERE c.CategoryName = 'Accesorios' AND p.ProviderName = 'Apple'
AND NOT EXISTS (SELECT 1 FROM Products WHERE ProductCode = 'FIP13');

-- Tablets
INSERT INTO Products (ProductName, ProductCode, ProductPrice, ProductStock, CategoryId, ProviderId)
SELECT 'iPad Pro 12.9', 'IPAD12', 1099.99, 25, CategoryId, ProviderId
FROM Categories c, Providers p
WHERE c.CategoryName = 'Tablets' AND p.ProviderName = 'Apple'
AND NOT EXISTS (SELECT 1 FROM Products WHERE ProductCode = 'IPAD12');

INSERT INTO Products (ProductName, ProductCode, ProductPrice, ProductStock, CategoryId, ProviderId)
SELECT 'Samsung Galaxy Tab S7', 'GTAB7', 649.99, 40, CategoryId, ProviderId
FROM Categories c, Providers p
WHERE c.CategoryName = 'Tablets' AND p.ProviderName = 'Samsung'
AND NOT EXISTS (SELECT 1 FROM Products WHERE ProductCode = 'GTAB7');

COMMIT TRANSACTION;
GO

-- Verificar las tablas
SELECT * FROM Categories;
SELECT * FROM Providers;
SELECT * FROM Products;
GO

-- Asegúrate de que el usuario exista
IF NOT EXISTS (SELECT * FROM sys.server_principals WHERE name = 'SQLQuery1')
BEGIN
    CREATE LOGIN SQLQuery1 WITH PASSWORD = 'assa2345';
END
GO

USE Query1;
GO

IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = 'SQLQuery1')
BEGIN
    CREATE USER SQLQuery1 FOR LOGIN SQLQuery1;
END
GO

-- Otorgar permisos
ALTER ROLE db_owner ADD MEMBER SQLQuery1;
GO
