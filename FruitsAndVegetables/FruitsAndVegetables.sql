CREATE DATABASE FruitsAndVegetables;
GO

USE FruitsAndVegetables;
GO

CREATE TABLE Produce (
    Id INT PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Type NVARCHAR(50) NOT NULL,
    Color NVARCHAR(50) NOT NULL,
    Calories INT NOT NULL
);

GO

INSERT INTO Produce (Id, Name, Type, Color, Calories) VALUES (1, 'Apple', 'Fruit', 'Red', 52);
INSERT INTO Produce (Id, Name, Type, Color, Calories) VALUES (2, 'Banana', 'Fruit', 'Yellow', 89);
INSERT INTO Produce (Id, Name, Type, Color, Calories) VALUES (3, 'Carrot', 'Vegetable', 'Orange', 41);
INSERT INTO Produce (Id, Name, Type, Color, Calories) VALUES (4, 'Tomato', 'Fruit', 'Red', 18);
INSERT INTO Produce (Id, Name, Type, Color, Calories) VALUES (5, 'Lettuce', 'Vegetable', 'Green', 15);
INSERT INTO Produce (Id, Name, Type, Color, Calories) VALUES (6, 'Strawberry', 'Fruit', 'Red', 32);
INSERT INTO Produce (Id, Name, Type, Color, Calories) VALUES (7, 'Broccoli', 'Vegetable', 'Green', 34);
INSERT INTO Produce (Id, Name, Type, Color, Calories) VALUES (8, 'Grape', 'Fruit', 'Purple', 69);
INSERT INTO Produce (Id, Name, Type, Color, Calories) VALUES (9, 'Spinach', 'Vegetable', 'Green', 23);
INSERT INTO Produce (Id, Name, Type, Color, Calories) VALUES (10, 'Blueberry', 'Fruit', 'Blue', 57);