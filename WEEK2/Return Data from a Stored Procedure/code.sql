CREATE PROCEDURE sp_GetEmployeeCountByDepartment(
    IN dept_id INT,
    OUT employee_count INT
)
BEGIN
    SELECT COUNT(*) INTO employee_count
    FROM Employees
    WHERE DepartmentID = dept_id;
    
    SELECT employee_count AS TotalEmployees;
END;