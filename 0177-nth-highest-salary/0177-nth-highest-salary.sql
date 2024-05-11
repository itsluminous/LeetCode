CREATE FUNCTION getNthHighestSalary(@N INT) RETURNS INT AS
BEGIN
    DECLARE @NthSalary INT;
    WITH RankedSalaries AS(
        SELECT salary, ROW_NUMBER() OVER (ORDER BY salary desc) as rownum
        FROM (SELECT DISTINCT salary FROM Employee) emp
    )
    SELECT @NthSalary = salary
    FROM RankedSalaries
    WHERE rownum = @N;

    RETURN @NthSalary;
END