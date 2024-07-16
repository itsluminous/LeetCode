-- Write your PostgreSQL query statement below
select emp.name as Employee
from Employee emp
inner join Employee mgr on mgr.id = emp.managerId
where emp.salary > mgr.salary