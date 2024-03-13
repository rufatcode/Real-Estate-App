-- Create a new database called 'RealEstateDB'
-- Connect to the 'master' database to run this snippet
USE master
GO
-- Create the new database if it does not exist already
IF NOT EXISTS (
    SELECT [name]
        FROM sys.databases
        WHERE [name] = N'RealEstateDB'
)
CREATE DATABASE RealEstateDB
GO


-- Create a new table called '[Slider]' in schema '[dbo]'
-- Drop the table if it already exists
IF OBJECT_ID('[dbo].[Slider]', 'U') IS NOT NULL
DROP TABLE [dbo].[Slider]
GO
-- Create the table in the specified schema
CREATE TABLE [dbo].[Slider]
(
    [Id] INT NOT NULL PRIMARY KEY identity, -- Primary Key column
    [Title] NVARCHAR(300) NOT NULL,
    [Content] NVARCHAR(MAX) NOT NULL,
    [ImageUrl] NVARCHAR(MAX) NOT NULL,
    [IsDeleted] bit,
    [CreatedAT] DATETIME NOT NULL,
    [DeletedAT] DATETIME,
    [UpdatedAT] DATETIME,

    -- Specify more columns here
);
GO


-- Create a new table called '[Category]' in schema '[dbo]'
-- Drop the table if it already exists
IF OBJECT_ID('[dbo].[Category]', 'U') IS NOT NULL
DROP TABLE [dbo].[Category]
GO
-- Create the table in the specified schema
CREATE TABLE [dbo].[Category]
(
    [Id] INT NOT NULL PRIMARY KEY identity, -- Primary Key column
    [Name] NVARCHAR(300) NOT NULL,
    [IsDeleted] bit,
    [CreatedAT] DATETIME NOT NULL ,
    [DeletedAT] DATETIME,
    [UpdatedAT] DATETIME,
    -- Specify more columns here
);
GO


-- Create a new table called '[Product]' in schema '[dbo]'
-- Drop the table if it already exists
IF OBJECT_ID('[dbo].[Product]', 'U') IS NOT NULL
DROP TABLE [dbo].[Product]
GO
-- Create the table in the specified schema
CREATE TABLE [dbo].[Product]
(
    [Id] INT NOT NULL PRIMARY KEY identity, -- Primary Key column
    [Name] NVARCHAR(300) NOT NULL,
    [Description] NVARCHAR(MAX) NOT NULL,
    [ForBuy]bit,
    [ForRent]bit,
    [Price] DECIMAL(18,2) ,
    [Country] NVARCHAR(300) not NULL,
    [City] NVARCHAR(300) not NULL,
    [Address] NVARCHAR(MAX) NOT NULL,
    [VideoUrl] NVARCHAR(max),
    [IsDeleted] bit,
    [CreatedAT] DATETIME NOT NULL,
    [DeletedAT] DATETIME,
    [UpdatedAT] DATETIME,
    
    -- Specify more columns here
);
GO


Alter TABLE Product Add CONSTRAINT  Price CHECK(Price>0)

-- Create a new table called '[ProductImages]' in schema '[dbo]'
-- Drop the table if it already exists
IF OBJECT_ID('[dbo].[ProductImages]', 'U') IS NOT NULL
DROP TABLE [dbo].[ProductImages]
GO
-- Create the table in the specified schema
CREATE TABLE [dbo].[ProductImages]
(
    [Id] INT NOT NULL PRIMARY KEY identity, -- Primary Key column
    [ImageUrl] NVARCHAR(max) NOT NULL,
    [ProductId] int  References Product(id) NOT NULL,
    [IsDeleted] bit,
    [CreatedAT] DATETIME NOT NULL,
    [DeletedAT] DATETIME,
    [UpdatedAT] DATETIME,
    -- Specify more columns here
);
GO

-- Create a new table called '[ProductDetail]' in schema '[dbo]'
-- Drop the table if it already exists
IF OBJECT_ID('[dbo].[ProductDetail]', 'U') IS NOT NULL
DROP TABLE [dbo].[ProductDetail]
GO
-- Create the table in the specified schema
CREATE TABLE [dbo].[ProductDetail]
(
    [Id] INT NOT NULL PRIMARY KEY, -- Primary Key column
    [ProductId] int References Product(Id) NOT NULL,
    [Bedrooms] TINYINT NOT NULL,
    [StructureType ] NVARCHAR(max) NOT NULL,
    [Price] DECIMAL(18,2) NOT NULL CHECK(Price>0),
    [Size] int NOT NULL,
    [Bathrooms] TINYINT NOT NULL,
    [GarageSize] int NOT NULL,
    [Rooms] int NOT NULL,
    [ExteriorMaterial ] NVARCHAR(max) NOT NULL,
    [Garages] TINYINT NOT NULL,
    [BuiltYear] DATETIME NOT NULL,
    [IsDeleted] bit,
    [CreatedAT] DATETIME NOT NULL,
    [DeletedAT] DATETIME,
    [UpdatedAT] DATETIME,
    -- Specify more columns here
);
GO


-- Create a new table called '[ProductAmenities]' in schema '[dbo]'
-- Drop the table if it already exists
IF OBJECT_ID('[dbo].[ProductAmenities]', 'U') IS NOT NULL
DROP TABLE [dbo].[ProductAmenities]
GO
-- Create the table in the specified schema
CREATE TABLE [dbo].[ProductAmenities]
(
    [Id] INT NOT NULL PRIMARY KEY identity, -- Primary Key column
    [Name] NVARCHAR(max) NOT NULL,
    [ProductId]int References Product(id) NOT NULL,
    [IsDeleted] bit,
    [CreatedAT] DATETIME NOT NULL,
    [DeletedAT] DATETIME,
    [UpdatedAT] DATETIME,
    -- Specify more columns here
);
GO


-- Create a new table called '[Employees]' in schema '[dbo]'
-- Drop the table if it already exists
IF OBJECT_ID('[dbo].[Employees]', 'U') IS NOT NULL
DROP TABLE [dbo].[Employees]
GO
-- Create the table in the specified schema
CREATE TABLE [dbo].[Employees]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY, -- Primary Key column
    [Name] NVARCHAR(300) NOT NULL,
    [Position] NVARCHAR(300) NOT NULL,
    [ImageUrl] NVARCHAR(max) NOT NULL,
    [PhoneNumber] NVARCHAR(100) NOT NULL,
    [IsDeleted] bit,
    [CreatedAT] DATETIME NOT NULL,
    [DeletedAT] DATETIME,
    [UpdatedAT] DATETIME,
);
GO


-- Create a new table called '[Subscibe]' in schema '[dbo]'
-- Drop the table if it already exists
IF OBJECT_ID('[dbo].[Subscibe]', 'U') IS NOT NULL
DROP TABLE [dbo].[Subscibe]
GO
-- Create the table in the specified schema
CREATE TABLE [dbo].[Subscibe]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY, -- Primary Key column
    [Email] NVARCHAR(100) NOT NULL,
    [IsDeleted] bit,
    [CreatedAT] DATETIME NOT NULL,
    [DeletedAT] DATETIME,
    [UpdatedAT] DATETIME,
    -- Specify more columns here
);
GO




-- Create a new table called '[Setting]' in schema '[dbo]'
-- Drop the table if it already exists
IF OBJECT_ID('[dbo].[Setting]', 'U') IS NOT NULL
DROP TABLE [dbo].[Setting]
GO
-- Create the table in the specified schema
CREATE TABLE [dbo].[Setting]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY, -- Primary Key column
    [Key] NVARCHAR(max) NOT NULL,
    [Value] NVARCHAR(max) NOT NULL,
    [IsDeleted] bit,
    [CreatedAT] DATETIME NOT NULL,
    [DeletedAT] DATETIME,
    [UpdatedAT] DATETIME,
    -- Specify more columns here
);
GO

-- Create a new table called '[Contact]' in schema '[dbo]'
-- Drop the table if it already exists
IF OBJECT_ID('[dbo].[Contact]', 'U') IS NOT NULL
DROP TABLE [dbo].[Contact]
GO
-- Create the table in the specified schema
CREATE TABLE [dbo].[Contact]
(
    [Id] INT NOT NULL PRIMARY KEY, -- Primary Key column
    [Name] NVARCHAR(300) NOT NULL,
    [Email] NVARCHAR(300) NOT NULL,
    [Message] NVARCHAR(max) NOT NULL,
    [IsDeleted] bit,
    [IsResponded] bit,
    [CreatedAT] DATETIME NOT NULL,
    [DeletedAT] DATETIME,
    [UpdatedAT] DATETIME,
    -- Specify more columns here
);
GO