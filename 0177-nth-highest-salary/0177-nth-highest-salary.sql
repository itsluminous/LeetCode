-- using nested query
CREATE FUNCTION getNthHighestSalary(@N INT) RETURNS INT AS
BEGIN
    RETURN (
        SELECT salary FROM(
            SELECT salary, ROW_NUMBER() OVER (ORDER BY salary desc) as rownum
            FROM (SELECT DISTINCT salary FROM Employee) emp
        ) result
        WHERE rownum = @N
    );
END

-- Accepted - using CTE
/*
CREATE FUNCTION getNthHighestSalaryCTE(@N INT) RETURNS INT AS
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
*/