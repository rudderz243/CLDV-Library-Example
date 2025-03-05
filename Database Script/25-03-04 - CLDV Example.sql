-- Creating a new database
CREATE DATABASE LibraryDB;

-- Selecting that database
USE LibraryDB;

-- Creating a new table
CREATE TABLE Category(
-- PRIMARY KEY means that CategoryID represents each unique record in the table
-- It helps us to prevent duplicate data in the table, and ensures we have a unique "thing" to identify each record
-- IDENTITY (1,1) means that the ID will start at 1 (the first number in brackets), and go up by 1 each time (second number)
CategoryID INT PRIMARY KEY IDENTITY(1,1),
CategoryName NVARCHAR(100) NOT NULL,
CategoryDescription NVARCHAR(255) NOT NULL,
DOI FLOAT NOT NULL
);


CREATE TABLE Book (
BookID INT PRIMARY KEY IDENTITY(1,1),
Title NVARCHAR(100) NOT NULL,
ReplacementPrice FLOAT NOT NULL,
-- FOREIGN KEY means that we are linking this specific field in this table, to a field in another table
-- It ensures that we cannot insert data here, that doesn't exist in the other table
CategoryID INT FOREIGN KEY REFERENCES Category(CategoryID)
);

-- The C in CRUD
-- Inserting data into a table, specifying multiple values
INSERT INTO Category VALUES
-- EACH value must be seperated by a ,
-- String/NVARCHAR data must be wrapped in ' and not "
('Fiction', 'Made up stories for people who are bored.', 123.4),
('Non-Fiction', 'Science-y stuff.', 134.2),
('Textbooks', 'Things that cost too much and teach too little', 143.1);

INSERT INTO Book VALUES
('Life of Pi', 123.45, 1),
('How to make a bomb (in minecraft)', 321.90, 2),
('C# to cry about', 9000.12, 3);

-- The R in CRUD
-- We tell it what we want to fetch (in this case, * means everything), and where we want to fetch it from.
SELECT * FROM Category;
SELECT * FROM Book;

-- U - Update values
-- First we tell it which table
UPDATE Book
-- then we tell it what to change,
SET ReplacementPrice = 10000
-- finally, we tell it which record to change it for.
WHERE BookID = 3;

UPDATE Category
SET DOI = 555.5
WHERE CategoryID = 1;

-- D for DELETE
-- Very similar to SELECT (R from CRUD), but instead of fetching, it deletes.
DELETE FROM Book WHERE BookID = 3;



