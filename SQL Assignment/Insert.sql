USE WorkerDB

INSERT INTO Worker (FIRST_NAME, LAST_NAME, SALARY, JOINING_DATE, DEPARTMENT) VALUES
('Monika','Arora',100000,'2014-02-20 09:00:00','HR'),
('Niharika','Verma',80000,'2014-06-11 09:00:00','Admin'),
('Vishal','Singhal',300000,'2014-02-20 09:00:00','HR'),
('Amitabh','Singh',500000,'2014-02-20 09:00:00','Admin'),
('Vivek','Bhati',500000,'2014-06-11 09:00:00','Admin'),
('Vipul','Diwan',200000,'2014-06-11 09:00:00','Account'),
('Satish','Kumar',75000,'2014-01-20 09:00:00','Account'),
('Geetika','Chauhan',90000,'2014-04-11 09:00:00','Admin');

INSERT INTO Bonus VALUES
(1,5000,'2016-02-20'),
(2,3000,'2016-06-11'),
(3,4000,'2016-02-20'),
(1,4500,'2016-02-20'),
(2,3500,'2016-06-11');

INSERT INTO Title VALUES
(1,'Manager','2016-02-20'),
(2,'Executive','2016-06-11'),
(8,'Executive','2016-06-11'),
(5,'Manager','2016-06-11'),
(4,'Asst. Manager','2016-06-11'),
(7,'Executive','2016-06-11'),
(6,'Lead','2016-06-11'),
(3,'Lead','2016-06-11');

SELECT * FROM Worker;
SELECT * FROM Bonus;
SELECT * FROM Title;