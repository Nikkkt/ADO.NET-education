CREATE DATABASE TeaShop;
GO
USE TeaShop;
GO
-- Create the Tea table
CREATE TABLE Tea (
    id INT PRIMARY KEY,
    name VARCHAR(255),
    description TEXT,
    type VARCHAR(50),
    origin_country VARCHAR(100),
    cost_price DECIMAL(10, 2),
    selling_price DECIMAL(10, 2),
    grams INT
);

-- Insert sample data into the Tea table
INSERT INTO Tea (id, name, description, type, origin_country, cost_price, selling_price, grams)
VALUES 
(1, 'Darjeeling First Flush', 'First harvest Darjeeling tea with delicate flavor and aroma', 'Black', 'India', 3.00, 6.00, 50),
(2, 'Sencha', 'Traditional Japanese green tea with a fresh and grassy flavor', 'Green', 'Japan', 4.50, 9.00, 75),
(3, 'Earl Grey', 'Classic black tea blend flavored with bergamot oil', 'Black', 'United Kingdom', 2.50, 5.00, 100),
(4, 'Jasmine Pearl', 'Chinese green tea scented with jasmine flowers, hand-rolled into pearls', 'Green', 'China', 5.00, 10.00, 50),
(5, 'Assam Breakfast', 'Robust black tea from the Assam region, perfect for mornings', 'Black', 'India', 3.50, 7.00, 100),
(6, 'Matcha', 'Finely ground Japanese green tea powder used in traditional tea ceremonies', 'Green', 'Japan', 6.00, 12.00, 25),
(7, 'Chamomile', 'Herbal tea made from dried chamomile flowers, known for its calming properties', 'Herbal', 'Egypt', 3.00, 6.00, 50),
(8, 'Oolong', 'Partially oxidized tea with a diverse range of flavors, often described as between green and black tea', 'Oolong', 'China', 4.00, 8.00, 75),
(9, 'Rooibos', 'Herbal tea from South Africa, naturally caffeine-free with a sweet and nutty flavor', 'Herbal', 'South Africa', 3.50, 7.00, 100),
(10, 'Genmaicha', 'Japanese green tea blended with roasted brown rice, known for its toasty flavor', 'Green', 'Japan', 4.00, 8.00, 75);

-- Create the Country table
CREATE TABLE Country (
    id INT PRIMARY KEY,
    name VARCHAR(100)
);

-- Insert sample data into the Country table
INSERT INTO Country (id, name)
VALUES
(1, 'India'),
(2, 'Japan'),
(3, 'United Kingdom'),
(4, 'China'),
(5, 'Egypt'),
(6, 'South Africa');

-- Create the Tea_Country table to establish a many-to-many relationship between Tea and Country
CREATE TABLE Tea_Country (
    tea_id INT,
    country_id INT,
    PRIMARY KEY (tea_id, country_id),
    FOREIGN KEY (tea_id) REFERENCES Tea(id),
    FOREIGN KEY (country_id) REFERENCES Country(id)
);

-- Insert sample data into the Tea_Country table
INSERT INTO Tea_Country (tea_id, country_id) VALUES
(1, 1), (2, 2), (3, 3), (4, 4), (5, 1),
(6, 2), (7, 5), (8, 4), (9, 6), (10, 2);
