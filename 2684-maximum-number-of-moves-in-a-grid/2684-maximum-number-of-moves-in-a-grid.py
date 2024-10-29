class Solution:
    def maxMoves(self, grid: List[List[int]]) -> int:
        self.dp = []
        m, n, moves = len(grid), len(grid[0]), 0
        self.dp = [[-1] * n for _ in range(m)]

        for i in range(m):
            curr = self.getMoves(grid, i, 0)
            moves = max(moves, curr)

        return moves

    def getMoves(self, grid, r, c):
        m, n, moves = len(grid), len(grid[0]), 0
        if c == n-1: return 0
        if self.dp[r][c] != -1: return self.dp[r][c]

        # above row
        if r > 0 and grid[r-1][c+1] > grid[r][c]:
            moves = max(moves, 1 + self.getMoves(grid, r-1, c+1))
        
        # same row
        if grid[r][c+1] > grid[r][c]:
            moves = max(moves, 1 + self.getMoves(grid, r, c+1))

        # next row
        if r < m-1 and grid[r+1][c+1] > grid[r][c]:
            moves = max(moves, 1 + self.getMoves(grid, r+1, c+1))
        
        self.dp[r][c] = moves
        return moves