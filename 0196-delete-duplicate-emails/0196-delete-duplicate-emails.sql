/* Write your T-SQL query statement below */
WITH CTE AS(
    SELECT id, email, 
        RANK() OVER (PARTITION BY email ORDER BY id) as rank
    FROM person
)
DELETE from person
WHERE id IN (
    SELECT id
    FROM CTE
    WHERE rank > 1
)