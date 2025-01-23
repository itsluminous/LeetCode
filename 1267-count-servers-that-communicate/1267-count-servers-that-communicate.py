class Solution:
    def countServers(self, grid: List[List[int]]) -> int:
        m, n = len(grid), len(grid[0])
        
        # count servers in each row & col
        rows, cols = [0] * m, [0] * n
        for i in range(m):
            for j in range(n):
                rows[i] += grid[i][j]
                cols[j] += grid[i][j]

        # find out servers that can communicate
        count = 0
        for i in range(m):
            for j in range(n):
                if grid[i][j] == 0 or (rows[i] == 1 and cols[j] == 1): continue
                count += 1

        return count