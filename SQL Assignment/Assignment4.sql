CREATE DATABASE  DepartmentDB
USE DepartmentDB

CREATE TABLE Departments (
    DepartmentID INT PRIMARY KEY IDENTITY(1,1),
    DepartmentName VARCHAR(100) NOT NULL,
    Location VARCHAR(100)
);

CREATE TABLE Students (
    StudentID INT PRIMARY KEY IDENTITY(1,1),
    StudentName VARCHAR(100),
    Gender VARCHAR(10),
    DateOfBirth DATE,
    DepartmentID INT,
    AdmissionDate DATE,
    FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID)
);

CREATE TABLE Teachers (
    TeacherID INT PRIMARY KEY IDENTITY(1,1),
    TeacherName VARCHAR(100),
    DepartmentID INT,
    HireDate DATE,
    FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID)
);

CREATE TABLE Courses (
    CourseID INT PRIMARY KEY IDENTITY(1,1),
    CourseName VARCHAR(100),
    DepartmentID INT,
    Credits INT,
    FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID)
);

CREATE TABLE Enrollments (
    EnrollmentID INT PRIMARY KEY IDENTITY(1,1),
    StudentID INT,
    CourseID INT,
    EnrollmentDate DATE,
    FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
    FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)
);

CREATE TABLE Exams (
    ExamID INT PRIMARY KEY IDENTITY(1,1),
    CourseID INT,
    ExamType VARCHAR(50),
    ExamDate DATE,
    FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)
);

CREATE TABLE Marks (
    MarkID INT PRIMARY KEY IDENTITY(1,1),
    StudentID INT,
    ExamID INT,
    MarksObtained INT,
    FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
    FOREIGN KEY (ExamID) REFERENCES Exams(ExamID)
);

SELECT * FROM Departments;
DROP TABLE Departments;

--Assignment 1 – Student Department View

CREATE VIEW vw_StudentDepartment AS
SELECT 
    s.StudentID,
    s.StudentName,
    d.DepartmentName,
    s.AdmissionDate
FROM Students s
JOIN Departments d
ON s.DepartmentID = d.DepartmentID;

SELECT * 
FROM vw_StudentDepartment;

SELECT *
FROM vw_StudentDepartment
WHERE DepartmentName = 'Computer Science';

DROP VIEW vw_StudentDepartment;

--Assignment 2 – Student Course Enrollment View

CREATE VIEW vw_StudentCourses AS
SELECT 
    s.StudentName,
    c.CourseName,
    e.EnrollmentDate,
    s.StudentID
FROM Students s
JOIN Enrollments e 
ON s.StudentID = e.StudentID
JOIN Courses c 
ON e.CourseID = c.CourseID;

SELECT CourseName, EnrollmentDate
FROM vw_StudentCourses
WHERE StudentID = 5;

SELECT CourseName, EnrollmentDate
FROM vw_StudentCourses
WHERE StudentID = 5;

SELECT StudentName, COUNT(CourseName) AS TotalCourses
FROM vw_StudentCourses
GROUP BY StudentName;

SELECT *
FROM vw_StudentCourses
WHERE EnrollmentDate > '2024-01-01';

--Assignment 3 – Exam Result View

CREATE VIEW vw_ExamResults AS
SELECT 
    s.StudentName,
    c.CourseName,
    e.ExamType,
    m.MarksObtained
FROM Students s
JOIN Marks m 
ON s.StudentID = m.StudentID
JOIN Exams e 
ON m.ExamID = e.ExamID
JOIN Courses c 
ON e.CourseID = c.CourseID;

SELECT *
FROM vw_ExamResults
WHERE MarksObtained > 80;

SELECT *
FROM vw_ExamResults
WHERE MarksObtained = (
    SELECT MAX(MarksObtained)
    FROM vw_ExamResults v2
    WHERE v2.ExamType = vw_ExamResults.ExamType
);

SELECT *
FROM vw_ExamResults
WHERE MarksObtained < 40;

--Assignment 4 – Aggregate View

CREATE VIEW vw_DepartmentStudentCount AS
SELECT 
    d.DepartmentName,
    COUNT(s.StudentID) AS TotalStudents
FROM Departments d
LEFT JOIN Students s
ON d.DepartmentID = s.DepartmentID
GROUP BY d.DepartmentName;

SELECT *
FROM vw_DepartmentStudentCount
WHERE TotalStudents > 10;

SELECT *
FROM vw_DepartmentStudentCount
ORDER BY TotalStudents DESC;

--Assignment 2.1. Insert Student Procedure

IF OBJECT_ID('sp_InsertStudent', 'P') IS NOT NULL
DROP PROCEDURE sp_InsertStudent;
GO

CREATE PROCEDURE sp_InsertStudent
    @FirstName VARCHAR(50),
    @LastName VARCHAR(50),
    @Gender VARCHAR(10),
    @DepartmentID INT,
    @AdmissionDate DATE
AS
BEGIN
    INSERT INTO Students (FirstName, LastName, Gender, DepartmentID, AdmissionDate)
    VALUES (@FirstName, @LastName, @Gender, @DepartmentID, @AdmissionDate);
END;
GO


--Assignment 2.2. Get Students By Department

IF OBJECT_ID('sp_GetStudentsByDepartment', 'P') IS NOT NULL
DROP PROCEDURE sp_GetStudentsByDepartment;
GO

CREATE PROCEDURE sp_GetStudentsByDepartment
    @DepartmentID INT
AS
BEGIN
    SELECT 
        StudentID,
        StudentName,
        AdmissionDate
    FROM Students
    WHERE DepartmentID = @DepartmentID;
END;
GO


-- Assignment 2.3. Enroll Student Procedure

IF OBJECT_ID('sp_EnrollStudent', 'P') IS NOT NULL
DROP PROCEDURE sp_EnrollStudent;
GO

CREATE PROCEDURE sp_EnrollStudent
    @StudentID INT,
    @CourseID INT
AS
BEGIN
    INSERT INTO Enrollments (StudentID, CourseID, EnrollmentDate)
    VALUES (@StudentID, @CourseID, GETDATE());
END;
GO


-- Assignment 2.4. Get Student Marks Procedure

IF OBJECT_ID('sp_GetStudentMarks', 'P') IS NOT NULL
DROP PROCEDURE sp_GetStudentMarks;
GO

CREATE PROCEDURE sp_GetStudentMarks
    @StudentID INT
AS
BEGIN
    SELECT 
        s.StudentName,
        c.CourseName,
        e.ExamType,
        m.MarksObtained
    FROM Students s
    JOIN Marks m ON s.StudentID = m.StudentID
    JOIN Exams e ON m.ExamID = e.ExamID
    JOIN Courses c ON e.CourseID = c.CourseID
    WHERE s.StudentID = @StudentID;
END;
GO


-- Assignment 2.5. Update Student Marks

IF OBJECT_ID('sp_UpdateMarks', 'P') IS NOT NULL
DROP PROCEDURE sp_UpdateMarks;
GO

CREATE PROCEDURE sp_UpdateMarks
    @MarkID INT,
    @NewMarks INT
AS
BEGIN
    UPDATE Marks
    SET MarksObtained = @NewMarks
    WHERE MarkID = @MarkID;

    SELECT * 
    FROM Marks
    WHERE MarkID = @MarkID;
END;
GO


-- Assignment 2.6. Delete Enrollment

IF OBJECT_ID('sp_DeleteEnrollment', 'P') IS NOT NULL
DROP PROCEDURE sp_DeleteEnrollment;
GO

CREATE PROCEDURE sp_DeleteEnrollment
    @EnrollmentID INT
AS
BEGIN
    DELETE FROM Enrollments
    WHERE EnrollmentID = @EnrollmentID;
END;
GO

EXEC sp_DeleteEnrollment 3;

SELECT *
FROM Enrollments;


-- Assignment 3.1. Calculate Grade Function (Scalar)

IF OBJECT_ID('fn_GetGrade','FN') IS NOT NULL
DROP FUNCTION fn_GetGrade;
GO

CREATE FUNCTION fn_GetGrade(@MarksObtained INT)
RETURNS VARCHAR(10)
AS
BEGIN
    DECLARE @Grade VARCHAR(10)

    IF @MarksObtained >= 90
        SET @Grade = 'A'
    ELSE IF @MarksObtained >= 75
        SET @Grade = 'B'
    ELSE IF @MarksObtained >= 60
        SET @Grade = 'C'
    ELSE
        SET @Grade = 'Fail'

    RETURN @Grade
END;
GO

-- Assignment 3.2. Student Age Function (Scalar)

IF OBJECT_ID('fn_GetStudentAge','FN') IS NOT NULL
DROP FUNCTION fn_GetStudentAge;
GO

CREATE FUNCTION fn_GetStudentAge(@DateOfBirth DATE)
RETURNS INT
AS
BEGIN
    DECLARE @Age INT

    SET @Age = DATEDIFF(YEAR,@DateOfBirth,GETDATE())

    RETURN @Age
END;
GO


-- Assignment 3.3. Total Marks Function (Scalar)

IF OBJECT_ID('fn_GetTotalMarks','FN') IS NOT NULL
DROP FUNCTION fn_GetTotalMarks;
GO

CREATE FUNCTION fn_GetTotalMarks(@StudentID INT)
RETURNS INT
AS
BEGIN
    DECLARE @TotalMarks INT

    SELECT @TotalMarks = SUM(MarksObtained)
    FROM Marks
    WHERE StudentID = @StudentID

    RETURN @TotalMarks
END;
GO


-- Assignment 3.4. Student Courses Function (Table Valued)

IF OBJECT_ID('fn_GetStudentCourses','TF') IS NOT NULL
DROP FUNCTION fn_GetStudentCourses;
GO

CREATE FUNCTION fn_GetStudentCourses(@StudentID INT)
RETURNS TABLE
AS
RETURN
(
    SELECT 
        c.CourseName,
        e.EnrollmentDate
    FROM Enrollments e
    JOIN Courses c
    ON e.CourseID = c.CourseID
    WHERE e.StudentID = @StudentID
);
GO


-- Assignment 3.5. Department Students Function (Table Valued)

IF OBJECT_ID('fn_GetDepartmentStudents','TF') IS NOT NULL
DROP FUNCTION fn_GetDepartmentStudents;
GO

CREATE FUNCTION fn_GetDepartmentStudents(@DepartmentID INT)
RETURNS TABLE
AS
RETURN
(
    SELECT 
        StudentID,
        StudentName,
        AdmissionDate
    FROM Students
    WHERE DepartmentID = @DepartmentID
);
GO


