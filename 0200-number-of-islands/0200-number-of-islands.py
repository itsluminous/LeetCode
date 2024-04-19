class Solution:
    def numIslands(self, grid: List[List[str]]) -> int:
        count = 0
        for i in range(len(grid)):
            for j in range(len(grid[0])):
                if grid[i][j] == '1':
                    count += 1
                    self.traverseIsland(grid, i, j)
        return count

    # DFS
    def traverseIsland(self, grid: List[List[str]], x: int, y: int):
        if(x == -1 or y == -1 or x == len(grid) or y == len(grid[0]) or grid[x][y] == '0'): return
        grid[x][y] = '0'
        self.traverseIsland(grid, x-1, y)
        self.traverseIsland(grid, x+1, y)
        self.traverseIsland(grid, x, y-1)
        self.traverseIsland(grid, x, y+1)