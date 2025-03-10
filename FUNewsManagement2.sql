
CREATE DATABASE FUNewsManagement2;
GO

USE FUNewsManagement2;
GO

CREATE TABLE SystemAccount (
    AccountID INT IDENTITY(1,1) PRIMARY KEY,
    AccountName NVARCHAR(100) NOT NULL,
    AccountEmail NVARCHAR(255) NOT NULL UNIQUE,
    AccountRole INT NOT NULL,
    AccountPassword NVARCHAR(100) NOT NULL
);

CREATE TABLE Category (
    CategoryID INT IDENTITY(1,1) PRIMARY KEY,
    CategoryName NVARCHAR(100) NOT NULL,
    CategoryDescription NVARCHAR(500),
    ParentCategoryID INT NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    FOREIGN KEY (ParentCategoryID) REFERENCES Category(CategoryID)
);

CREATE TABLE Tag (
    TagID INT IDENTITY(1,1) PRIMARY KEY,
    TagName NVARCHAR(50) NOT NULL UNIQUE,
    Note NVARCHAR(200)
);

CREATE TABLE NewsArticle (
    NewsArticleID INT IDENTITY(1,1) PRIMARY KEY,
    NewsTitle NVARCHAR(200) NOT NULL,
    Headline NVARCHAR(500) NOT NULL,
    CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
    NewsContent NVARCHAR(MAX) NOT NULL,
    NewsSource NVARCHAR(200),
    CategoryID INT NOT NULL,
    NewsStatus BIT NOT NULL DEFAULT 1,
    CreatedByID INT NOT NULL,
    UpdatedByID INT NULL,
    ModifiedDate DATETIME NULL,
    FOREIGN KEY (CategoryID) REFERENCES Category(CategoryID),
    FOREIGN KEY (CreatedByID) REFERENCES SystemAccount(AccountID),
    FOREIGN KEY (UpdatedByID) REFERENCES SystemAccount(AccountID)
);

CREATE TABLE NewsTag (
    NewsArticleID INT NOT NULL,
    TagID INT NOT NULL,
    PRIMARY KEY (NewsArticleID, TagID),
    FOREIGN KEY (NewsArticleID) REFERENCES NewsArticle(NewsArticleID),
    FOREIGN KEY (TagID) REFERENCES Tag(TagID)
);

INSERT INTO SystemAccount (AccountName, AccountEmail, AccountRole, AccountPassword) VALUES
('Admin', 'admin@FUNewsManagementSystem.org', 0, '@@abc123@@'), -- Admin role (0 as per config)
('Johndoe', 'john.doe@funews.org', 1, 'password123'), -- Staff
('Janesmith', 'jane.smith@funews.org', 1, 'pass456'), -- Staff
('Michaelbrown', 'michael.brown@funews.org', 2, 'lecturer789'), -- Lecturer
('Sarahlee', 'sarah.lee@funews.org', 1, 'staff101'), -- Staff
('Davidkim', 'david.kim@funews.org', 2, 'teach202'), -- Lecturer
('Emilychen', 'emily.chen@funews.org', 1, 'emp303'); -- Staff

INSERT INTO Category (CategoryName, CategoryDescription, ParentCategoryID, IsActive) VALUES
('Campus News', 'News related to campus events', NULL, 1),
('Academic Updates', 'Updates on academic programs', NULL, 1),
('Events', 'Campus events and activities', 1, 1),
('Research', 'Research highlights', 2, 1),
('Announcements', 'Official university announcements', 1, 1),
('Sports', 'Sports events and updates', 1, 0); -- Inactive category

INSERT INTO Tag (TagName, Note) VALUES
('Event', 'Related to campus events'),
('Research', 'Research-related content'),
('Announcement', 'Official notices'),
('Sports', 'Sports activities'),
('Academic', 'Academic updates'),
('Student', 'Student-focused news'),
('Faculty', 'Faculty-related news'),
('Technology', 'Tech-related content');

INSERT INTO NewsArticle (NewsTitle, Headline, NewsContent, NewsSource, CategoryID, NewsStatus, CreatedByID, UpdatedByID, ModifiedDate) VALUES
('Spring Festival 2025', 'Celebrate with Us!', 'Join us for the Spring Festival on March 15, 2025...', 'Campus Office', 3, 1, 2, NULL, NULL),
('New Research Grant', 'Funding for Innovation', 'University secures $500K for research...', 'Research Dept', 4, 1, 3, NULL, NULL),
('Exam Schedule Update', 'Important Dates', 'Exams start on April 1, 2025...', 'Academic Office', 2, 1, 5, 5, '2025-03-09 10:00:00'),
('Welcome Address', 'New Semester Begins', 'Welcome message from the Dean...', 'Admin Office', 5, 1, 1, NULL, NULL),
('Tech Workshop', 'Learn New Skills', 'Workshop on AI technologies...', 'Tech Dept', 2, 1, 6, NULL, NULL),
('Football Match Cancelled', 'Due to Weather', 'Match postponed to next week...', 'Sports Dept', 6, 0, 7, 7, '2025-03-08 15:00:00'),
('Student Awards 2025', 'Recognizing Excellence', 'Top students honored...', 'Student Affairs', 1, 1, 4, NULL, NULL);

INSERT INTO NewsTag (NewsArticleID, TagID) VALUES
(1, 1),  -- Spring Festival -> Event
(1, 6),  -- Spring Festival -> Student
(2, 2),  -- New Research Grant -> Research
(2, 7),  -- New Research Grant -> Faculty
(3, 5),  -- Exam Schedule Update -> Academic
(4, 3),  -- Welcome Address -> Announcement
(5, 8),  -- Tech Workshop -> Technology
(6, 4),  -- Football Match Cancelled -> Sports
(7, 6),  -- Student Awards 2025 -> Student
(7, 1);  -- Student Awards 2025 -> Event

UPDATE NewsArticle
SET CreatedByID = 5, UpdatedByID = 5
WHERE NewsArticleID = 5; -- Tech Workshop (originally CreatedByID = 6)

UPDATE NewsArticle
SET CreatedByID = 7, UpdatedByID = 7
WHERE NewsArticleID = 6; -- Football Match Cancelled (originally CreatedByID = 6)