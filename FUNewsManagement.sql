-- Drop database if exists
IF EXISTS (SELECT * FROM sys.databases WHERE name = 'FUNewsManagement')
    DROP DATABASE FUNewsManagement;
GO

-- Create new database
CREATE DATABASE FUNewsManagement;
GO

USE FUNewsManagement;
GO

-- Create Accounts table
CREATE TABLE Accounts (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Email NVARCHAR(255) UNIQUE NOT NULL,
    Password NVARCHAR(255) NOT NULL,
    FullName NVARCHAR(255) NOT NULL,
    Role INT CHECK (Role IN (1,2)) NOT NULL, -- 1 = Staff, 2 = Lecturer
    Status BIT NOT NULL DEFAULT 1 -- 1 = Active, 0 = Inactive
);
GO

-- Create Categories table
CREATE TABLE Categories (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(255) NOT NULL,
    Status BIT NOT NULL DEFAULT 1 -- 1 = Active, 0 = Inactive
);
GO

-- Create NewsArticles table
CREATE TABLE NewsArticles (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(255) NOT NULL,
    Content NVARCHAR(MAX) NOT NULL,
    CategoryId INT NOT NULL,
    AuthorId INT NOT NULL,
    CreatedDate DATETIME DEFAULT GETDATE(),
    Status BIT NOT NULL DEFAULT 1, -- 1 = Active, 0 = Inactive
    FOREIGN KEY (CategoryId) REFERENCES Categories(Id),
    FOREIGN KEY (AuthorId) REFERENCES Accounts(Id)
);
GO

-- Create Tags table
CREATE TABLE Tags (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(255) NOT NULL,
    NewsArticleId INT NULL,
    FOREIGN KEY (NewsArticleId) REFERENCES NewsArticles(Id)
);
GO

-- Insert 30 sample Accounts
INSERT INTO Accounts (Email, Password, FullName, Role, Status)
VALUES 
('staff1@news.com', 'Password1', 'Staff One', 1, 1),
('staff2@news.com', 'Password2', 'Staff Two', 1, 1),
('staff3@news.com', 'Password3', 'Staff Three', 1, 1),
('lecturer1@news.com', 'Password4', 'Lecturer One', 2, 1),
('lecturer2@news.com', 'Password5', 'Lecturer Two', 2, 1);

-- Generate more sample accounts
DECLARE @i INT = 6;
WHILE @i <= 30
BEGIN
    INSERT INTO Accounts (Email, Password, FullName, Role, Status)
    VALUES 
    ('user' + CAST(@i AS NVARCHAR) + '@news.com', 
     'Password' + CAST(@i AS NVARCHAR), 
     'User ' + CAST(@i AS NVARCHAR), 
     CASE WHEN @i % 2 = 0 THEN 1 ELSE 2 END, -- Alternating roles
     1);
    SET @i = @i + 1;
END;

-- Insert 30 sample Categories
INSERT INTO Categories (Name, Status)
VALUES 
('Technology', 1),
('Education', 1),
('Health', 1),
('Business', 1),
('Entertainment', 1);

-- Generate more sample categories
DECLARE @j INT = 6;
WHILE @j <= 30
BEGIN
    INSERT INTO Categories (Name, Status)
    VALUES ('Category ' + CAST(@j AS NVARCHAR), 1);
    SET @j = @j + 1;
END;

-- Insert 30 sample NewsArticles
INSERT INTO NewsArticles (Title, Content, CategoryId, AuthorId, CreatedDate, Status)
VALUES 
('Tech News 1', 'Content of Tech News 1', 1, 1, GETDATE(), 1),
('Education Update', 'Latest in education', 2, 2, GETDATE(), 1),
('Health Tips', 'Stay healthy with these tips', 3, 3, GETDATE(), 1),
('Business Insights', 'Market trends analysis', 4, 4, GETDATE(), 1),
('Movie Review', 'Latest blockbuster review', 5, 5, GETDATE(), 1);

-- Generate more sample news articles
DECLARE @k INT = 6;
WHILE @k <= 30
BEGIN
    INSERT INTO NewsArticles (Title, Content, CategoryId, AuthorId, CreatedDate, Status)
    VALUES 
    ('News Title ' + CAST(@k AS NVARCHAR), 
     'Content for news article ' + CAST(@k AS NVARCHAR), 
     (@k % 5) + 1, -- Assigning random categories
     (@k % 30) + 1, -- Assigning random authors
     DATEADD(DAY, -(@k * 2), GETDATE()), -- Created dates in the past
     1);
    SET @k = @k + 1;
END;

-- Insert 30 sample Tags
INSERT INTO Tags (Name, NewsArticleId)
VALUES 
('Tech', 1),
('Education', 2),
('Health', 3),
('Business', 4),
('Movies', 5);

-- Generate more sample tags
DECLARE @m INT = 6;
WHILE @m <= 30
BEGIN
    INSERT INTO Tags (Name, NewsArticleId)
    VALUES 
    ('Tag ' + CAST(@m AS NVARCHAR), 
     CASE WHEN @m % 3 = 0 THEN NULL ELSE (@m % 30) + 1 END); -- Some tags have no article
    SET @m = @m + 1;
END;
