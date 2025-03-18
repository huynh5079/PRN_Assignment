CREATE DATABASE CourseManagementDB;
GO

USE CourseManagementDB;
GO

-- 1. User Table
CREATE TABLE [User] (
    ID INT PRIMARY KEY IDENTITY(1,1),
    FullName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    Password NVARCHAR(255) NOT NULL,
    Role NVARCHAR(20) CHECK (Role IN ('Admin', 'Student')) NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE()
);
GO

-- 2. Course Table
CREATE TABLE Course (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR(200) NOT NULL,
    Category NVARCHAR(100),
    CourseCode NVARCHAR(20) UNIQUE NOT NULL,
    Capacity INT CHECK (Capacity >= 0) NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE()
);
GO

-- 3. EnrollmentRecords Table
CREATE TABLE EnrollmentRecords (
    ID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT NOT NULL,
    CourseID INT NOT NULL,
    EnrollDate DATETIME DEFAULT GETDATE(),
    Dropped BIT DEFAULT 0,
    CONSTRAINT FK_Enrollment_User FOREIGN KEY (UserID) REFERENCES [User](ID),
    CONSTRAINT FK_Enrollment_Course FOREIGN KEY (CourseID) REFERENCES Course(ID)
);
GO

-- 4. Sessions Table
CREATE TABLE Sessions (
    SessionID NVARCHAR(50) PRIMARY KEY,
    UserID INT NOT NULL,
    Role NVARCHAR(20) CHECK (Role IN ('Admin', 'Student')) NOT NULL,
    ExpiresAt DATETIME NOT NULL,
    CONSTRAINT FK_Sessions_User FOREIGN KEY (UserID) REFERENCES [User](ID)
);
GO
