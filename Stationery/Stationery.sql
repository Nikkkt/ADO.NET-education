-- Create database
CREATE DATABASE Stationery;
GO
-- Use the database
USE Stationery;
GO
-- Create table for stationery types
CREATE TABLE StationeryTypes (
    TypeID INT PRIMARY KEY IDENTITY,
    TypeName VARCHAR(50)
);

-- Create table for stationery items
CREATE TABLE StationeryItems (
    ItemID INT PRIMARY KEY IDENTITY,
    ItemName VARCHAR(100),
    ItemTypeID INT,
    Price DECIMAL(10, 2),
    StockQuantity INT,
    CONSTRAINT FK_ItemType FOREIGN KEY (ItemTypeID) REFERENCES StationeryTypes(TypeID)
);

-- Create table for sales managers
CREATE TABLE SalesManagers (
    ManagerID INT PRIMARY KEY IDENTITY,
    ManagerName VARCHAR(100),
    ManagerEmail VARCHAR(100),
    TotalSales INT DEFAULT 0,
    TotalProfit DECIMAL(10, 2) DEFAULT 0.00
);

-- Create table for buyer companies
CREATE TABLE BuyerCompanies (
    CompanyID INT PRIMARY KEY IDENTITY,
    CompanyName VARCHAR(100),
    CompanyAddress VARCHAR(255),
    ContactPerson VARCHAR(100)
);

-- Create table for sales transactions
CREATE TABLE Sales (
    SaleID INT PRIMARY KEY IDENTITY,
    ItemID INT,
    CompanyID INT,
    ManagerID INT,
    SaleDate DATE,
    Quantity INT,
    TotalPrice DECIMAL(10, 2),
    CONSTRAINT FK_Sale_Item FOREIGN KEY (ItemID) REFERENCES StationeryItems(ItemID),
    CONSTRAINT FK_Sale_Company FOREIGN KEY (CompanyID) REFERENCES BuyerCompanies(CompanyID),
    CONSTRAINT FK_Sale_Manager FOREIGN KEY (ManagerID) REFERENCES SalesManagers(ManagerID)
);

-- Create archive tables based on existing tables' structure
CREATE TABLE ArchivedStationeryItems (
    ItemID INT PRIMARY KEY IDENTITY,
    ItemName VARCHAR(100),
    ItemTypeID INT,
    Price DECIMAL(10, 2),
    StockQuantity INT
);

CREATE TABLE ArchivedSalesManagers (
    ManagerID INT PRIMARY KEY IDENTITY,
    ManagerName VARCHAR(100),
    ManagerEmail VARCHAR(100),
    TotalSales INT DEFAULT 0,
    TotalProfit DECIMAL(10, 2) DEFAULT 0.00
);

CREATE TABLE ArchivedStationeryTypes (
    TypeID INT PRIMARY KEY IDENTITY,
    TypeName VARCHAR(50)
);

CREATE TABLE ArchivedBuyerCompanies (
    CompanyID INT PRIMARY KEY IDENTITY,
    CompanyName VARCHAR(100),
    CompanyAddress VARCHAR(255),
    ContactPerson VARCHAR(100)
);

-- Insert sample data into stationery types table
INSERT INTO StationeryTypes (TypeName) VALUES
('Pen'),
('Pencil'),
('Eraser'),
('Notebook'),
('Stapler');

-- Insert sample data into sales managers table
INSERT INTO SalesManagers (ManagerName, ManagerEmail) VALUES
('John Doe', 'john.doe@example.com'),
('Jane Smith', 'jane.smith@example.com');

-- Insert sample data into buyer companies table
INSERT INTO BuyerCompanies (CompanyName, CompanyAddress, ContactPerson) VALUES
('ABC Company', '123 Main St, City', 'Alice'),
('XYZ Corporation', '456 Elm St, Town', 'Bob');

-- Insert sample data into stationery items table
INSERT INTO StationeryItems (ItemName, ItemTypeID, Price, StockQuantity) VALUES
('Blue Pen', 1, 1.50, 100),
('Black Pencil', 2, 0.75, 200),
('Large Notebook', 4, 3.00, 50);

-- Insert sample data into sales transactions table
INSERT INTO Sales (ItemID, CompanyID, ManagerID, SaleDate, Quantity, TotalPrice) VALUES
(1, 1, 1, '2024-03-07', 50, 75.00),
(2, 2, 2, '2024-03-07', 100, 75.00);