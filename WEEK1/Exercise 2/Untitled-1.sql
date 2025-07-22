
CREATE PROC GetEmployeeByID @ID INT
AS
BEGIN
    SELECT * FROM Employees WHERE EmployeeID = @ID
END
GO


EXEC GetEmployeeByID @ID = 5;