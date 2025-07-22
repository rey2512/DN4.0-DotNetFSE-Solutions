
DROP TABLE IF EXISTS Employees;
DROP TABLE IF EXISTS Departments;
DROP PROCEDURE IF EXISTS sp_GetEmployeesByDepartment;
DROP PROCEDURE IF EXISTS sp_InsertEmployee;


CREATE TABLE Departments (
    DepartmentID INT PRIMARY KEY,
    DepartmentName VARCHAR(100)
);

CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    DepartmentID INT,
    Salary DECIMAL(10,2),
    JoinDate DATE,
    CONSTRAINT fk_department FOREIGN KEY (DepartmentID) 
    REFERENCES Departments(DepartmentID)
);

INSERT INTO Departments (DepartmentID, DepartmentName) VALUES
(1, 'HR'),
(2, 'Finance'),
(3, 'IT'),
(4, 'Marketing');

INSERT INTO Employees (EmployeeID, FirstName, LastName, DepartmentID, Salary, JoinDate) VALUES
(1, 'John', 'Doe', 1, 5000.00, '2020-01-15'),
(2, 'Jane', 'Smith', 2, 6000.00, '2019-03-22'),
(3, 'Michael', 'Johnson', 3, 7000.00, '2018-07-30'),
(4, 'Emily', 'Davis', 4, 5500.00, '2021-11-05');


CREATE PROCEDURE sp_GetEmployeesByDepartment(IN dept_id INT)
BEGIN
    SELECT 
        e.EmployeeID,
        e.FirstName,
        e.LastName,
        d.DepartmentName,
        e.Salary,
        e.JoinDate
    FROM Employees e
    JOIN Departments d ON e.DepartmentID = d.DepartmentID
    WHERE e.DepartmentID = dept_id
    ORDER BY e.LastName, e.FirstName;
END;


CALL sp_GetEmployeesByDepartment(1);


CREATE PROCEDURE sp_InsertEmployee(
    IN first_name VARCHAR(50),
    IN last_name VARCHAR(50),
    IN dept_id INT,
    IN emp_salary DECIMAL(10,2),
    IN join_date DATE
)
BEGIN
    DECLARE new_employee_id INT;
    
    IF NOT EXISTS (SELECT 1 FROM Departments WHERE DepartmentID = dept_id) THEN
        SIGNAL SQLSTATE '45000' 
        SET MESSAGE_TEXT = 'Invalid DepartmentID: Department does not exist';
    ELSE
        SELECT IFNULL(MAX(EmployeeID), 0) + 1 INTO new_employee_id FROM Employees;
        
        INSERT INTO Employees (EmployeeID, FirstName, LastName, DepartmentID, Salary, JoinDate)
        VALUES (new_employee_id, first_name, last_name, dept_id, emp_salary, join_date);
        
        SELECT CONCAT('Employee added successfully with ID: ', new_employee_id) AS Result;
    END IF;
END;

