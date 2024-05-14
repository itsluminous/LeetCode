class Solution:
    def getMaximumGold(self, grid: List[List[int]]) -> int:
        self.maxGold = 0
        self.m, self.n = len(grid), len(grid[0])

        for i in range(self.m):
            for j in range(self.n):
                if self.isValid(grid, i, j): self.backtrack(grid, 0, i, j)
        
        return self.maxGold

    def backtrack(self, grid: List[List[int]], gold: int, x: int, y: int):
        # check if this is the max gold
        gold += grid[x][y]
        self.maxGold = max(self.maxGold, gold)

        # mark current cell as visited
        val = grid[x][y]
        grid[x][y] = 0

        # now try to go in all four directions
        if self.isValid(grid, x+1, y): self.backtrack(grid, gold, x+1, y)
        if self.isValid(grid, x-1, y): self.backtrack(grid, gold, x-1, y)
        if self.isValid(grid, x, y+1): self.backtrack(grid, gold, x, y+1)
        if self.isValid(grid, x, y-1): self.backtrack(grid, gold, x, y-1)

        # revert changes
        grid[x][y] = val
    
    def isValid(self, grid: List[List[int]], x: int, y: int) -> bool:
        if x == -1 or y == -1 or x == self.m or y == self.n: return False  # out of bound
        if grid[x][y] == 0: return False     # already visited or no gold
        return True