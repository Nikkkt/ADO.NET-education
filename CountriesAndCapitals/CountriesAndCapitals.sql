CREATE DATABASE CountriesAndCapitals;
GO
USE CountriesAndCapitals;
GO
-- Create Countries table
CREATE TABLE Countries (
    country_id INT PRIMARY KEY IDENTITY,
    country_name VARCHAR(255) NOT NULL,
    population INT NOT NULL,
    area FLOAT NOT NULL
);

-- Create Capitals table
CREATE TABLE Capitals (
    capital_id INT PRIMARY KEY IDENTITY,
    capital_name VARCHAR(255) NOT NULL,
    country_id INT,
    population INT NOT NULL,
    FOREIGN KEY (country_id) REFERENCES Countries(country_id)
);

-- Create Cities table
CREATE TABLE Cities (
    city_id INT PRIMARY KEY IDENTITY,
    city_name VARCHAR(255) NOT NULL,
    country_id INT,
    population INT NOT NULL,
    FOREIGN KEY (country_id) REFERENCES Countries(country_id)
);

-- Insert sample data into Countries table
INSERT INTO Countries (country_name, population, area) VALUES
('USA', 331000000, 9833520),
('Canada', 38000000, 9984670),
('France', 67000000, 551695),
('Germany', 83000000, 357022),
('China', 1444000000, 9596961);

-- Insert sample data into Capitals table
INSERT INTO Capitals (capital_name, country_id, population) VALUES
('Washington D.C.', 1, 705749),
('Ottawa', 2, 934243),
('Paris', 3, 2148000),
('Berlin', 4, 3748000),
('Beijing', 5, 21707000);

-- Insert sample data into Cities table
INSERT INTO Cities (city_name, country_id, population) VALUES
('New York City', 1, 8337000),
('Toronto', 2, 2731571),
('Marseille', 3, 869815),
('Hamburg', 4, 1841179),
('Shanghai', 5, 27058479);
