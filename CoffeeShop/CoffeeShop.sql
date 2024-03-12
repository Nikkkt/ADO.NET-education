CREATE DATABASE CoffeeShop;
GO
USE CoffeeShop;
GO
-- Create the Coffee table
CREATE TABLE Coffee (
    id INT PRIMARY KEY,
    name VARCHAR(255),
    description TEXT,
    type VARCHAR(50),
    origin_country VARCHAR(100),
    cost_price DECIMAL(10, 2),
    selling_price DECIMAL(10, 2),
    grams INT
);

-- Insert sample data into the Coffee table
INSERT INTO Coffee (id, name, description, type, origin_country, cost_price, selling_price, grams)
VALUES 
(1, 'Brazilian Blend', 'A blend of Arabica and Robusta beans from Brazil', 'blend', 'Brazil', 5.00, 10.00, 250),
(2, 'Ethiopian Yirgacheffe', 'Single-origin Ethiopian Arabica coffee with floral notes', 'Arabica', 'Ethiopia', 6.50, 12.00, 200),
(3, 'Colombian Supremo', 'Premium Colombian Arabica coffee with a smooth taste', 'Arabica', 'Colombia', 7.00, 14.00, 300),
(4, 'Vietnamese Robusta', 'Strong and bold Robusta coffee from Vietnam', 'Robusta', 'Vietnam', 4.50, 9.00, 350),
(5, 'Kenyan AA', 'High-grade Kenyan Arabica coffee known for its bright acidity', 'Arabica', 'Kenya', 8.00, 16.00, 250),
(6, 'Costa Rican Tarrazu', 'Single-origin Arabica coffee from the Tarrazu region of Costa Rica', 'Arabica', 'Costa Rica', 9.50, 18.00, 200),
(7, 'Sumatra Mandheling', 'Full-bodied Arabica coffee from the Indonesian island of Sumatra', 'Arabica', 'Indonesia', 7.50, 15.00, 300),
(8, 'Guatemalan Antigua', 'Arabica coffee grown in the Antigua region of Guatemala', 'Arabica', 'Guatemala', 6.00, 12.00, 300),
(9, 'Mexican Chiapas', 'Smooth Arabica coffee from the Chiapas region of Mexico', 'Arabica', 'Mexico', 5.50, 11.00, 250),
(10, 'Tanzanian Peaberry', 'Rare Arabica coffee with a concentrated flavor profile from Tanzania', 'Arabica', 'Tanzania', 8.50, 17.00, 200);

-- Create the Country table
CREATE TABLE Country (
    id INT PRIMARY KEY,
    name VARCHAR(100)
);

-- Insert sample data into the Country table
INSERT INTO Country (id, name)
VALUES
(1, 'Brazil'),
(2, 'Ethiopia'),
(3, 'Colombia'),
(4, 'Vietnam'),
(5, 'Kenya'),
(6, 'Costa Rica'),
(7, 'Indonesia'),
(8, 'Guatemala'),
(9, 'Mexico'),
(10, 'Tanzania');

-- Create the Coffee_Country table to establish a many-to-many relationship between Coffee and Country
CREATE TABLE Coffee_Country (
    coffee_id INT,
    country_id INT,
    PRIMARY KEY (coffee_id, country_id),
    FOREIGN KEY (coffee_id) REFERENCES Coffee(id),
    FOREIGN KEY (country_id) REFERENCES Country(id)
);

-- Insert sample data into the Coffee_Country table
INSERT INTO Coffee_Country (coffee_id, country_id) VALUES
(1, 1), (2, 2), (3, 3), (4, 4), (5, 5),
(6, 6), (7, 7), (8, 8), (9, 9), (10, 10);