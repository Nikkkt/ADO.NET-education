CREATE PROCEDURE GetProductById @Id INT
AS
BEGIN SELECT * FROM Produce WHERE id = @Id END

GO

CREATE PROCEDURE GetAllProducts
AS
BEGIN SELECT * FROM Produce END

GO

CREATE PROCEDURE UpdateProduct
    @Id INT,
    @Name NVARCHAR(50),
    @Type NVARCHAR(50),
    @Color NVARCHAR(50),
    @Calories INT
AS
BEGIN UPDATE Produce SET name = @Name, type = @Type, color = @Color, calories = @Calories WHERE id = @Id END

GO

CREATE PROCEDURE DeleteProduct @Id INT
AS
BEGIN DELETE FROM Produce WHERE id = @Id END

GO

CREATE PROCEDURE GetAverageCalories
AS
BEGIN SELECT AVG(calories) FROM Produce END