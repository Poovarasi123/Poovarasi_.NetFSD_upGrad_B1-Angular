CREATE DATABASE SchoolDB;
GO

USE SchoolDB;

CREATE TABLE Students (
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100),
    Age INT,
    Grade NVARCHAR(10)
);

CREATE TABLE Employees (
    EmpId INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100),
    Salary DECIMAL(10,2),
    Department NVARCHAR(50)
);

CREATE PROCEDURE InsertEmployee
    @Name NVARCHAR(100),
    @Salary DECIMAL(10,2),
    @Department NVARCHAR(50)
AS
BEGIN
    INSERT INTO Employees(Name, Salary, Department)
    VALUES (@Name, @Salary, @Department)
END

CREATE PROCEDURE GetEmployeesByDepartment
    @Department NVARCHAR(50)
AS
BEGIN
    SELECT * FROM Employees WHERE Department = @Department
END


CREATE PROCEDURE UpdateSalary
    @EmpId INT,
    @Salary DECIMAL(10,2)
AS
BEGIN
    UPDATE Employees SET Salary = @Salary WHERE EmpId = @EmpId
END

CREATE TABLE Books (
    BookId INT PRIMARY KEY IDENTITY,
    Title NVARCHAR(200),
    Author NVARCHAR(100),
    Price DECIMAL(10,2)
);

