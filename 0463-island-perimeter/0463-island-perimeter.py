class Solution:
    def islandPerimeter(self, grid: List[List[int]]) -> int:
        m,n,per = len(grid), len(grid[0]), 0
        for i in range(m):
            for j in range(n):
                if grid[i][j] == 1:
                    per += self.perimeter(grid, i, j)
        return per

    def perimeter(self, grid: List[List[int]], x: int, y: int) -> int:
        m,n,per = len(grid), len(grid[0]), 0
        if x == 0 or grid[x-1][y] == 0: per += 1
        if x == m-1 or grid[x+1][y] == 0: per += 1
        if y == 0 or grid[x][y-1] == 0: per += 1
        if y == n-1 or grid[x][y+1] == 0: per += 1

        return per