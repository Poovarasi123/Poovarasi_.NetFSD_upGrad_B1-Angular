CREATE DATABASE EducationDB;

USE EducationDB;
CREATE TABLE Departments (
    DepartmentID INT PRIMARY KEY,
    DepartmentName VARCHAR(100)
);

CREATE TABLE Students (
    StudentID INT PRIMARY KEY,
    StudentName VARCHAR(100),
    DepartmentID INT,
    Email VARCHAR(100),
    FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID)
);

CREATE TABLE Teachers (
    TeacherID INT PRIMARY KEY,
    TeacherName VARCHAR(100),
    DepartmentID INT,
    FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID)
);

CREATE TABLE Courses (
    CourseID INT PRIMARY KEY,
    CourseName VARCHAR(100),
    DepartmentID INT,
    TeacherID INT,
    FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID),
    FOREIGN KEY (TeacherID) REFERENCES Teachers(TeacherID)
);

CREATE TABLE Enrollments (
    EnrollmentID INT PRIMARY KEY,
    StudentID INT,
    CourseID INT,
    EnrollmentDate DATE,
    FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
    FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)
);

CREATE TABLE Exams (
    ExamID INT PRIMARY KEY,
    CourseID INT,
    ExamDate DATE,
    FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)
);

CREATE TABLE Marks (
    MarkID INT PRIMARY KEY,
    StudentID INT,
    ExamID INT,
    MarksObtained INT,
    FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
    FOREIGN KEY (ExamID) REFERENCES Exams(ExamID)
);




-- ASSIGNMENT 1 : AUDIT TRIGGER FOR STUDENTS

-- Step 1 : Create Audit Table

CREATE TABLE StudentAudit (
    AuditID INT IDENTITY(1,1) PRIMARY KEY,
    StudentID INT,
    ActionType VARCHAR(20),
    ActionDate DATETIME
);
GO


-- Step 2 : Create Trigger

CREATE TRIGGER trg_StudentInsertAudit
ON Students
AFTER INSERT
AS
BEGIN

    INSERT INTO StudentAudit(StudentID, ActionType, ActionDate)
    SELECT StudentID, 'INSERT', GETDATE()
    FROM inserted;

END;
GO


-- ASSIGNMENT 2 : PREVENT DELETING STUDENTS

CREATE TRIGGER trg_PreventStudentDelete
ON Students
INSTEAD OF DELETE
AS
BEGIN

    IF EXISTS (
        SELECT 1
        FROM Enrollments e
        JOIN deleted d
        ON e.StudentID = d.StudentID
    )

    BEGIN
        RAISERROR ('Student has course enrollments and cannot be deleted',16,1)
        ROLLBACK TRANSACTION
    END

    ELSE
    BEGIN
        DELETE FROM Students
        WHERE StudentID IN (SELECT StudentID FROM deleted)
    END

END;
GO


-- ASSIGNMENT 3 : UPDATE MARKS TRIGGER


-- Step 1 : Create Audit Table

CREATE TABLE MarksAudit (
    AuditID INT IDENTITY(1,1) PRIMARY KEY,
    StudentID INT,
    ExamID INT,
    OldMarks INT,
    NewMarks INT,
    UpdatedDate DATETIME
);
GO


-- Step 2 : Create Trigger

CREATE TRIGGER trg_UpdateMarksAudit
ON Marks
AFTER UPDATE
AS
BEGIN

    INSERT INTO MarksAudit(StudentID, ExamID, OldMarks, NewMarks, UpdatedDate)

    SELECT 
        d.StudentID,
        d.ExamID,
        d.MarksObtained,
        i.MarksObtained,
        GETDATE()

    FROM deleted d
    JOIN inserted i
    ON d.StudentID = i.StudentID
    AND d.ExamID = i.ExamID

END;
GO


-- Insert Department
INSERT INTO Departments VALUES (1,'Computer Science');


-- Insert Students (Trigger 1 will fire)
INSERT INTO Students VALUES (101,'Ravi',1,'ravi@email.com');
INSERT INTO Students VALUES (102,'Arun',1,'arun@email.com');


-- Check Audit Table
SELECT * FROM StudentAudit;


-- Insert Teacher
INSERT INTO Teachers VALUES (1,'Dr. Kumar',1);


-- Insert Course
INSERT INTO Courses VALUES (201,'Database Systems',1,1);


-- Insert Enrollment
INSERT INTO Enrollments VALUES (1,101,201,GETDATE());


-- Try deleting student WITH enrollment (Trigger prevents delete)
DELETE FROM Students WHERE StudentID = 101;


-- Try deleting student WITHOUT enrollment
DELETE FROM Students WHERE StudentID = 102;


-- Insert Exam
INSERT INTO Exams VALUES (301,201,GETDATE());


-- Insert Marks
INSERT INTO Marks VALUES (1,101,301,75);


-- Update Marks (Trigger 3 will fire)
UPDATE Marks
SET MarksObtained = 85
WHERE StudentID = 101
AND ExamID = 301;


-- Check Marks Audit
SELECT * FROM MarksAudit;

USE EducationDB;
GO


-- ASSIGNMENT 2.1 INSERT STUDENT WITH EXCEPTION HANDLING

CREATE PROCEDURE sp_AddStudent
    @StudentID INT,
    @FirstName VARCHAR(50),
    @LastName VARCHAR(50),
    @DepartmentID INT,
    @Gender VARCHAR(10),
    @AdmissionDate DATE
AS
BEGIN

    BEGIN TRY

        INSERT INTO Students(StudentID, StudentName, DepartmentID, Email)
        VALUES(@StudentID, @FirstName + ' ' + @LastName, @DepartmentID, 'example@email.com')

        PRINT 'Student inserted successfully'

    END TRY

    BEGIN CATCH

        PRINT 'Error occurred while inserting student'
        PRINT ERROR_MESSAGE()

    END CATCH

END
GO



-- ASSIGNMENT 2.2 MARKS VALIDATION PROCEDURE


CREATE PROCEDURE sp_InsertMarks
    @MarkID INT,
    @StudentID INT,
    @ExamID INT,
    @MarksObtained INT
AS
BEGIN

    BEGIN TRY

        IF(@MarksObtained < 0 OR @MarksObtained > 100)
        BEGIN
            RAISERROR('Invalid Marks',16,1)
        END

        ELSE
        BEGIN
            INSERT INTO Marks VALUES(@MarkID,@StudentID,@ExamID,@MarksObtained)

            PRINT 'Marks inserted successfully'
        END

    END TRY

    BEGIN CATCH

        PRINT 'Error occurred while inserting marks'
        PRINT ERROR_MESSAGE()

    END CATCH

END
GO



-- ASSIGNMENT 2.3 SAFE DELETE STUDENT PROCEDURE


CREATE PROCEDURE sp_DeleteStudent
    @StudentID INT
AS
BEGIN

    BEGIN TRY

        DELETE FROM Students
        WHERE StudentID = @StudentID

        PRINT 'Student deleted successfully'

    END TRY

    BEGIN CATCH

        PRINT 'Error occurred while deleting student'
        PRINT ERROR_MESSAGE()

    END CATCH

END
GO




-- Insert valid student
EXEC sp_AddStudent 103,'Anu','Priya',1,'Female','2024-06-10';


-- Insert student with invalid DepartmentID
EXEC sp_AddStudent 104,'Test','Student',99,'Male','2024-06-10';



-- Insert valid marks
EXEC sp_InsertMarks 2,101,301,85;


-- Insert invalid marks
EXEC sp_InsertMarks 3,101,301,120;



-- Delete student without enrollment
EXEC sp_DeleteStudent 103;


-- Delete student with enrollment
EXEC sp_DeleteStudent 101;

USE EducationDB;
GO


-- ASSIGNMENT 3.1 DISPLAY STUDENT NAMES USING CURSOR


CREATE PROCEDURE sp_DisplayStudentsCursor
AS
BEGIN

    DECLARE @StudentID INT
    DECLARE @StudentName VARCHAR(100)

    DECLARE student_cursor CURSOR FOR
    SELECT StudentID, StudentName FROM Students

    OPEN student_cursor

    FETCH NEXT FROM student_cursor INTO @StudentID, @StudentName

    WHILE @@FETCH_STATUS = 0
    BEGIN

        PRINT 'StudentID: ' + CAST(@StudentID AS VARCHAR)
        PRINT 'StudentName: ' + @StudentName

        FETCH NEXT FROM student_cursor INTO @StudentID, @StudentName

    END

    CLOSE student_cursor
    DEALLOCATE student_cursor

END
GO



-- ASSIGNMENT 3.2 CALCULATE TOTAL MARKS PER STUDENT


CREATE PROCEDURE sp_CalculateStudentTotalMarks
AS
BEGIN

    DECLARE @StudentID INT
    DECLARE @StudentName VARCHAR(100)
    DECLARE @TotalMarks INT

    DECLARE marks_cursor CURSOR FOR
    SELECT StudentID, StudentName FROM Students

    OPEN marks_cursor

    FETCH NEXT FROM marks_cursor INTO @StudentID, @StudentName

    WHILE @@FETCH_STATUS = 0
    BEGIN

        SELECT @TotalMarks = SUM(MarksObtained)
        FROM Marks
        WHERE StudentID = @StudentID

        PRINT 'Student: ' + @StudentName
        PRINT 'Total Marks: ' + CAST(ISNULL(@TotalMarks,0) AS VARCHAR)

        FETCH NEXT FROM marks_cursor INTO @StudentID, @StudentName

    END

    CLOSE marks_cursor
    DEALLOCATE marks_cursor

END
GO


-- ASSIGNMENT 3.3 UPDATE COURSE CREDITS USING CURSOR


-- (Add Credits column if not exists)

ALTER TABLE Courses
ADD Credits INT DEFAULT 2;
GO


CREATE PROCEDURE sp_UpdateCourseCredits
AS
BEGIN

    DECLARE @CourseID INT
    DECLARE @Credits INT

    DECLARE course_cursor CURSOR FOR
    SELECT CourseID, Credits FROM Courses

    OPEN course_cursor

    FETCH NEXT FROM course_cursor INTO @CourseID, @Credits

    WHILE @@FETCH_STATUS = 0
    BEGIN

        IF @Credits < 3
        BEGIN
            UPDATE Courses
            SET Credits = Credits + 1
            WHERE CourseID = @CourseID
        END

        FETCH NEXT FROM course_cursor INTO @CourseID, @Credits

    END

    CLOSE course_cursor
    DEALLOCATE course_cursor

END
GO



-- Display students using cursor
EXEC sp_DisplayStudentsCursor;


-- Calculate total marks per student
EXEC sp_CalculateStudentTotalMarks;


-- Update course credits
EXEC sp_UpdateCourseCredits;


-- Check updated courses
SELECT * FROM Courses;

USE EducationDB;
GO


-- ASSIGNMENT 4.1 STUDENT ENROLLMENT TRANSACTION


CREATE PROCEDURE sp_EnrollStudentTransaction
    @EnrollmentID INT,
    @StudentID INT,
    @CourseID INT
AS
BEGIN

    BEGIN TRY

        BEGIN TRANSACTION

        INSERT INTO Enrollments
        VALUES(@EnrollmentID,@StudentID,@CourseID,GETDATE())

        COMMIT TRANSACTION

        PRINT 'Student enrolled successfully'

    END TRY

    BEGIN CATCH

        ROLLBACK TRANSACTION

        PRINT 'Enrollment failed'
        PRINT ERROR_MESSAGE()

    END CATCH

END
GO


-- ASSIGNMENT 4.2 EXAM MARKS TRANSACTION


CREATE PROCEDURE sp_RecordExamMarks
    @MarkID INT,
    @StudentID INT,
    @ExamID INT,
    @MarksObtained INT
AS
BEGIN

    BEGIN TRY

        BEGIN TRANSACTION

        -- Insert marks
        INSERT INTO Marks
        VALUES(@MarkID,@StudentID,@ExamID,@MarksObtained)

        -- Update exam record
        UPDATE Exams
        SET ExamDate = GETDATE()
        WHERE ExamID = @ExamID

        COMMIT TRANSACTION

        PRINT 'Marks recorded successfully'

    END TRY

    BEGIN CATCH

        ROLLBACK TRANSACTION

        PRINT 'Transaction failed'
        PRINT ERROR_MESSAGE()

    END CATCH

END
GO


-- ASSIGNMENT 4.3 DEPARTMENT TRANSFER TRANSACTION


CREATE PROCEDURE sp_TransferStudentDepartment
    @StudentID INT,
    @NewDepartmentID INT
AS
BEGIN

    BEGIN TRY

        BEGIN TRANSACTION

        -- Check department exists
        IF NOT EXISTS (
            SELECT * FROM Departments
            WHERE DepartmentID = @NewDepartmentID
        )
        BEGIN
            RAISERROR('Department does not exist',16,1)
        END

        -- Update department
        UPDATE Students
        SET DepartmentID = @NewDepartmentID
        WHERE StudentID = @StudentID

        COMMIT TRANSACTION

        PRINT 'Student transferred successfully'

    END TRY

    BEGIN CATCH

        ROLLBACK TRANSACTION

        PRINT 'Transfer failed'
        PRINT ERROR_MESSAGE()

    END CATCH

END
GO




-- Enroll student in course
EXEC sp_EnrollStudentTransaction 5,101,201;


-- Record exam marks
EXEC sp_RecordExamMarks 10,101,301,90;


-- Transfer student department
EXEC sp_TransferStudentDepartment 101,1;