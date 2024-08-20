/* Write your T-SQL query statement below */
SELECT c.name as Customers
FROM Customers c
LEFT JOIN Orders o ON o.customerId = c.id
WHERE o.id IS NULL