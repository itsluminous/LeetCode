class Solution:
    def numEnclaves(self, grid: List[List[int]]) -> int:
        m, n = len(grid), len(grid[0])
        self.dirs = [(0, 1), (0, -1), (1, 0), (-1, 0)]

        # visit all 1's starting from border
        for i in range(m):
            for j in range(n):
                if grid[i][j] == 1 and (i == 0 or j == 0 or i == m-1 or j == n-1):
                    self.markConnected(grid, i, j)

        # count unmarked 1's
        enclaves = 0
        for i in range(m):
            for j in range(n):
                if grid[i][j] == 1:
                    enclaves += 1
        
        return enclaves

    def markConnected(self, grid: List[List[int]], x: int, y: int):
        m, n = len(grid), len(grid[0])
        if x == -1 or y == -1 or x == m or y == n or grid[x][y] == 0: return

        grid[x][y] = 0 # mark visited
        for dx, dy in self.dirs:
            nx, ny = x + dx, y + dy
            self.markConnected(grid, nx, ny)
