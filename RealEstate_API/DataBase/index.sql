-- Create a new database called 'RealEstateDB'
-- Connect to the 'master' database to run this snippet
USE master
GO

use RealEstateDB
-- Create the new database if it does not exist already
IF NOT EXISTS (
    SELECT [name]
        FROM sys.databases
        WHERE [name] = N'RealEstateDB'
)
CREATE DATABASE RealEstateDB
GO
use RealEstateDB

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
    [CreatedAt] DATETIME NOT NULL,
    [DeletedAt] DATETIME,
    [UpdatedAt] DATETIME,

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
    [CreatedAt] DATETIME NOT NULL ,
    [DeletedAt] DATETIME,
    [UpdatedAt] DATETIME,
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
    [CreatedAt] DATETIME NOT NULL,
    [DeletedAt] DATETIME,
    [UpdatedAt] DATETIME,
    
    -- Specify more columns here
);
GO
ALTER TABLE Product Add  CategoryId int
alter table Product add FOREIGN KEY(CategoryId)  REFERENCES Category(id)
-- Add a new column '[NewColumnName]' to table '[TableName]' in schema '[dbo]'
ALTER TABLE [dbo].[TableName]
    ADD [NewColumnName] /*new_column_name*/ int /*new_column_datatype*/ NULL /*new_column_nullability*/
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
    [CreatedAt] DATETIME NOT NULL,
    [DeletedAt] DATETIME,
    [UpdatedAt] DATETIME,
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
    [CreatedAt] DATETIME NOT NULL,
    [DeletedAt] DATETIME,
    [UpdatedAt] DATETIME,
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
    [ProductId]int References Product(Id) NOT NULL,
    [IsDeleted] bit,
    [CreatedAt] DATETIME NOT NULL,
    [DeletedAt] DATETIME,
    [UpdatedAt] DATETIME,
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
    [CreatedAt] DATETIME NOT NULL,
    [DeletedAt] DATETIME,
    [UpdatedAt] DATETIME,
);
GO
 -- Add a new column '[NewColumnName]' to table '[TableName]' in schema '[dbo]'
ALTER TABLE [dbo].[Employees]
    ADD [PublicId] /*new_column_name*/ NVARCHAR(300) /*new_column_datatype*/  not NULL /*new_column_nullability*/UNIQUE
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
    [CreatedAt] DATETIME NOT NULL,
    [DeletedAt] DATETIME,
    [UpdatedAt] DATETIME,
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
    [CreatedAt] DATETIME NOT NULL,
    [DeletedAt] DATETIME,
    [UpdatedAt] DATETIME,
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
    [Id] INT NOT NULL PRIMARY KEY IDENTITY, -- Primary Key column
    [Name] NVARCHAR(300) NOT NULL,
    [Email] NVARCHAR(300) NOT NULL,
    [Message] NVARCHAR(max) NOT NULL,
    [IsDeleted] bit,
    [IsResponded] bit,
    [CreatedAt] DATETIME NOT NULL,
    [DeletedAt] DATETIME,
    [UpdatedAt] DATETIME,
    -- Specify more columns here
);
GO

-- Select rows from a Table or View '[Category]' in schema '[dbo]'
SELECT * FROM [dbo].[Category]
GO

-- Insert rows into table 'Category' in schema '[dbo]'
INSERT INTO [dbo].[Category]
( -- Columns to insert data into
 [Name], [IsDeleted], [CreatedAt]
)
VALUES
( -- First row: values for the columns in the list above
 'Villa', 0, GETDATE()
),
( -- First row: values for the columns in the list above
 ' Apartment', 0, GETDATE()
),
( -- First row: values for the columns in the list above
 'Private house', 0, GETDATE()
),
( -- First row: values for the columns in the list above
 'Building', 0, GETDATE()
),
( -- First row: values for the columns in the list above
 'Shop', 0, GETDATE()
)

-- Add more rows here
GO

select*from  Employees

SELECT*FROM Setting



