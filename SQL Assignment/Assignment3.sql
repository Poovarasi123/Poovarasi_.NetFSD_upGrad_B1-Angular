CREATE DATABASE SchoolManagementDB;

USE SchoolManagementDB;

--Assignment 1

CREATE TABLE Departments (
    DepartmentID INT PRIMARY KEY,
    DepartmentName VARCHAR(100) NOT NULL,
    Location VARCHAR(100)
);

CREATE TABLE Teachers (
    TeacherID INT PRIMARY KEY,
    TeacherName VARCHAR(100) NOT NULL,
    Email VARCHAR(100) UNIQUE,
    DepartmentID INT,
    HireDate DATE,
    
    FOREIGN KEY (DepartmentID) 
    REFERENCES Departments(DepartmentID)
);

CREATE TABLE Students (
    StudentID INT PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    DateOfBirth DATE,
    Gender VARCHAR(10),
    DepartmentID INT,
    AdmissionDate DATE,

    FOREIGN KEY (DepartmentID)
    REFERENCES Departments(DepartmentID)
);

CREATE TABLE Courses (
    CourseID INT PRIMARY KEY,
    CourseName VARCHAR(100),
    Credits INT,
    DepartmentID INT,
    TeacherID INT,

    FOREIGN KEY (DepartmentID)
    REFERENCES Departments(DepartmentID),

    FOREIGN KEY (TeacherID)
    REFERENCES Teachers(TeacherID)
);

CREATE TABLE Enrollments (
    EnrollmentID INT PRIMARY KEY,
    StudentID INT,
    CourseID INT,
    EnrollmentDate DATE,

    FOREIGN KEY (StudentID)
    REFERENCES Students(StudentID),

    FOREIGN KEY (CourseID)
    REFERENCES Courses(CourseID)
);

CREATE TABLE Exams (
    ExamID INT PRIMARY KEY,
    CourseID INT,
    ExamDate DATE,
    ExamType VARCHAR(50),

    FOREIGN KEY (CourseID)
    REFERENCES Courses(CourseID)
);

CREATE TABLE Marks (
    MarkID INT PRIMARY KEY,
    StudentID INT,
    ExamID INT,
    MarksObtained INT,

    FOREIGN KEY (StudentID)
    REFERENCES Students(StudentID),

    FOREIGN KEY (ExamID)
    REFERENCES Exams(ExamID)
);

SELECT * FROM INFORMATION_SCHEMA.TABLES;

--Assignment 2 Constraints

ALTER TABLE Departments
ADD CONSTRAINT UQ_DepartmentName UNIQUE (DepartmentName);

ALTER TABLE Students
ADD CONSTRAINT CHK_Gender
CHECK (Gender IN ('M','F'));

ALTER TABLE Courses
ADD CONSTRAINT CHK_Credits
CHECK (Credits BETWEEN 1 AND 5);

ALTER TABLE Marks
ADD CONSTRAINT CHK_Marks
CHECK (MarksObtained BETWEEN 0 AND 100);

ALTER TABLE Teachers
ADD CONSTRAINT UQ_TeacherEmail UNIQUE (Email);

ALTER TABLE Enrollments
ADD CONSTRAINT DF_EnrollmentDate
DEFAULT GETDATE() FOR EnrollmentDate;

--Assignment 3 – ALTER TABLE

ALTER TABLE Students
ADD PhoneNumber VARCHAR(15);

ALTER TABLE Teachers
ADD Salary INT;

ALTER TABLE Teachers
ALTER COLUMN Salary DECIMAL(10,2);

ALTER TABLE Teachers
ADD CONSTRAINT CHK_Salary
CHECK (Salary > 20000);

ALTER TABLE Students
DROP COLUMN PhoneNumber;

EXEC sp_rename 'Teachers.TeacherName', 'FullName', 'COLUMN';

--Assignment 4 – Insert Sample Data

INSERT INTO Departments VALUES
(1,'Computer Science','Block A'),
(2,'Mechanical','Block B'),
(3,'Electrical','Block C'),
(4,'Civil','Block D'),
(5,'Mathematics','Block E');

INSERT INTO Teachers VALUES
(1,'John','john@mail.com',1,'2023-01-10',50000),
(2,'David','david@mail.com',2,'2021-06-15',45000),
(3,'Sara','sara@mail.com',1,'2022-08-20',60000),
(4,'Priya','priya@mail.com',3,'2020-03-10',52000),
(5,'Kumar','kumar@mail.com',4,'2022-11-01',48000),
(6,'Anita','anita@mail.com',5,'2023-02-15',47000),
(7,'Ravi','ravi@mail.com',2,'2021-09-18',43000),
(8,'Meena','meena@mail.com',3,'2022-12-01',55000),
(9,'Arun','arun@mail.com',4,'2023-03-22',51000),
(10,'Divya','divya@mail.com',1,'2021-05-30',62000);

INSERT INTO Students VALUES
(1,'Arun','Kumar','2006-04-12','M',1,'2023-06-01'),
(2,'Anita','Raj','2005-08-10','F',1,'2023-06-01'),
(3,'Ajay','Singh','2007-02-15','M',2,'2023-06-01'),
(4,'Divya','Sharma','2006-11-20','F',3,'2023-06-01'),
(5,'Rahul','Das','2005-01-05','M',2,'2023-06-01'),
(6,'Priya','Nair','2007-07-17','F',1,'2023-06-01'),
(7,'Kiran','Rao','2006-03-22','M',3,'2023-06-01'),
(8,'Meena','Paul','2005-09-12','F',4,'2023-06-01'),
(9,'Suresh','K','2007-05-11','M',2,'2023-06-01'),
(10,'Lakshmi','R','2006-06-19','F',5,'2023-06-01'),
(11,'Amit','Shah','2005-10-01','M',1,'2023-06-01'),
(12,'Deepa','Menon','2007-01-08','F',3,'2023-06-01'),
(13,'Ramesh','Patel','2006-12-30','M',4,'2023-06-01'),
(14,'Anjali','Verma','2005-04-14','F',2,'2023-06-01'),
(15,'Vijay','Kumar','2007-03-28','M',5,'2023-06-01'),
(16,'Sneha','Iyer','2006-07-16','F',1,'2023-06-01'),
(17,'Aravind','M','2005-02-02','M',3,'2023-06-01'),
(18,'Neha','Kapoor','2007-09-09','F',2,'2023-06-01'),
(19,'Manoj','Reddy','2006-01-13','M',4,'2023-06-01'),
(20,'Asha','N','2005-11-21','F',5,'2023-06-01');

INSERT INTO Courses VALUES
(1,'Database Systems',4,1,1),
(2,'Web Development',3,1,3),
(3,'Thermodynamics',4,2,2),
(4,'Machine Design',3,2,7),
(5,'Power Systems',4,3,4),
(6,'Circuit Analysis',3,3,8),
(7,'Structural Engineering',4,4,5),
(8,'Surveying',3,4,9),
(9,'Algebra',4,5,6),
(10,'Statistics',3,5,6);

INSERT INTO Enrollments VALUES
(1,1,1,GETDATE()),
(2,1,2,GETDATE()),
(3,2,1,GETDATE()),
(4,3,3,GETDATE()),
(5,4,5,GETDATE()),
(6,5,3,GETDATE()),
(7,6,2,GETDATE()),
(8,7,6,GETDATE()),
(9,8,7,GETDATE()),
(10,9,4,GETDATE()),
(11,10,9,GETDATE()),
(12,11,1,GETDATE()),
(13,12,5,GETDATE()),
(14,13,7,GETDATE()),
(15,14,3,GETDATE()),
(16,15,10,GETDATE()),
(17,16,2,GETDATE()),
(18,17,6,GETDATE()),
(19,18,4,GETDATE()),
(20,19,8,GETDATE()),
(21,20,9,GETDATE()),
(22,2,2,GETDATE()),
(23,3,4,GETDATE()),
(24,4,6,GETDATE()),
(25,5,7,GETDATE()),
(26,6,1,GETDATE()),
(27,7,5,GETDATE()),
(28,8,3,GETDATE()),
(29,9,2,GETDATE()),
(30,10,10,GETDATE());

INSERT INTO Exams VALUES
(1,1,'2024-03-10','Midterm'),
(2,2,'2024-03-12','Midterm'),
(3,3,'2024-03-15','Final'),
(4,5,'2024-03-18','Final'),
(5,9,'2024-03-20','Midterm');

INSERT INTO Marks VALUES
(1,1,1,85),
(2,2,1,78),
(3,3,3,70),
(4,4,4,88),
(5,5,3,60),
(6,6,2,75),
(7,7,2,82),
(8,8,4,69),
(9,9,3,73),
(10,10,5,90),
(11,11,1,84),
(12,12,4,77),
(13,13,4,65),
(14,14,3,71),
(15,15,5,88),
(16,16,2,79),
(17,17,2,68),
(18,18,3,72),
(19,19,4,80),
(20,20,5,91),
(21,1,2,74),
(22,2,2,69),
(23,3,1,76),
(24,4,5,85),
(25,5,4,67),
(26,6,1,81),
(27,7,3,70),
(28,8,5,83),
(29,9,4,66),
(30,10,1,87);

SELECT * FROM Students;
SELECT * FROM Courses;
SELECT * FROM Marks;

--Assignment 5 – WHERE Queries

SELECT * 
FROM Students
WHERE DepartmentID =
(SELECT DepartmentID FROM Departments WHERE DepartmentName='Computer Science');

SELECT * FROM Teachers
WHERE HireDate > '2022-01-01';

SELECT * FROM Students
WHERE FirstName LIKE 'A%';

SELECT * FROM Courses
WHERE Credits > 3;

SELECT * FROM Students
WHERE DateOfBirth BETWEEN '2005-01-01' AND '2008-12-31';

SELECT *
FROM Students
WHERE DepartmentID NOT IN
(SELECT DepartmentID FROM Departments WHERE DepartmentName='Mechanical');

SELECT * FROM Teachers
WHERE Salary BETWEEN 40000 AND 70000;

SELECT * FROM Courses
WHERE TeacherID <> 3;

--Assignment 6 – GROUP BY

SELECT DepartmentID, COUNT(*) AS TotalStudents
FROM Students
GROUP BY DepartmentID;

SELECT ExamID, AVG(MarksObtained) AS AvgMarks
FROM Marks
GROUP BY ExamID;

SELECT CourseID, COUNT(StudentID)
FROM Enrollments
GROUP BY CourseID;

SELECT ExamID, MAX(MarksObtained)
FROM Marks
GROUP BY ExamID;

SELECT CourseID, MIN(MarksObtained)
FROM Exams E
JOIN Marks M ON E.ExamID = M.ExamID
GROUP BY CourseID;

SELECT DepartmentID, COUNT(*) AS Total
FROM Students
GROUP BY DepartmentID
HAVING COUNT(*) > 5;

--Assignment 7 – JOINS

SELECT S.FirstName, D.DepartmentName
FROM Students S
JOIN Departments D
ON S.DepartmentID = D.DepartmentID;

SELECT C.CourseName, T.FullName
FROM Courses C
JOIN Teachers T
ON C.TeacherID = T.TeacherID;

SELECT S.FirstName, C.CourseName
FROM Students S
JOIN Enrollments E ON S.StudentID = E.StudentID
JOIN Courses C ON E.CourseID = C.CourseID;

SELECT S.FirstName, M.MarksObtained
FROM Students S
JOIN Marks M ON S.StudentID = M.StudentID;

SELECT C.CourseName, T.FullName
FROM Courses C
LEFT JOIN Teachers T
ON C.TeacherID = T.TeacherID;

SELECT *
FROM Teachers
WHERE TeacherID NOT IN
(SELECT TeacherID FROM Courses);

--Assignment 8 – Subqueries

SELECT *
FROM Marks
WHERE MarksObtained >
(SELECT AVG(MarksObtained) FROM Marks);

SELECT *
FROM Courses
WHERE Credits =
(SELECT MAX(Credits) FROM Courses);

SELECT StudentID
FROM Enrollments
GROUP BY StudentID
HAVING COUNT(CourseID) > 2;

SELECT *
FROM Teachers
WHERE DepartmentID =
(SELECT DepartmentID FROM Teachers WHERE FullName='John');

SELECT *
FROM Marks
WHERE MarksObtained =
(SELECT MAX(MarksObtained) FROM Marks);

SELECT TOP 1 DepartmentID, COUNT(*) AS Total
FROM Students
GROUP BY DepartmentID
ORDER BY Total DESC;

--Assignment 9 – Views

CREATE VIEW StudentDeptView AS
SELECT S.StudentID,
S.FirstName,
D.DepartmentName
FROM Students S
JOIN Departments D
ON S.DepartmentID = D.DepartmentID;

CREATE VIEW StudentCourseView AS
SELECT S.FirstName,
C.CourseName,
E.EnrollmentDate
FROM Students S
JOIN Enrollments E ON S.StudentID = E.StudentID
JOIN Courses C ON E.CourseID = C.CourseID;

CREATE VIEW ExamResultView AS
SELECT S.FirstName,
C.CourseName,
E.ExamType,
M.MarksObtained
FROM Students S
JOIN Marks M ON S.StudentID = M.StudentID
JOIN Exams E ON M.ExamID = E.ExamID
JOIN Courses C ON E.CourseID = C.CourseID;

SELECT * FROM StudentDeptView;

DROP VIEW StudentDeptView;

--Assignment 10 – Indexes

CREATE INDEX idx_LastName
ON Students(LastName);

CREATE INDEX idx_Email
ON Teachers(Email);

CREATE INDEX idx_StudentCourse
ON Enrollments(StudentID, CourseID);

CREATE UNIQUE INDEX idx_DepartmentName
ON Departments(DepartmentName);

DROP INDEX idx_LastName
ON Students;

