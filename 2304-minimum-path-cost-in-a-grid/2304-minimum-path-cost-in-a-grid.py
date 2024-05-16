class Solution:
    def minPathCost(self, grid: List[List[int]], moveCost: List[List[int]]) -> int:
        m, n, mincost = len(grid), len(grid[0]), float('inf')
        self.dp = [[0]*n for _ in range(m)]

        # get min cost from each col
        for col in range(n):
            cost = self.getMinCost(grid, moveCost, 0, col)
            mincost = min(mincost, cost)
        return mincost

    def getMinCost(self, grid: List[List[int]], moveCost: List[List[int]], srcRow: int, srcCol: int) -> int:
        if srcRow == len(grid): return 0
        if srcRow == len(grid)-1: return grid[srcRow][srcCol]
        if self.dp[srcRow][srcCol] != 0: return self.dp[srcRow][srcCol]

        n = len(grid[0])
        srcNum = grid[srcRow][srcCol]
        minCost = float('inf')
        
        for destCol in range(n):
            cost = self.getMinCost(grid, moveCost, srcRow+1, destCol)
            cost += grid[srcRow][srcCol] + moveCost[srcNum][destCol]
            minCost = min(minCost, cost)

        self.dp[srcRow][srcCol] = minCost
        return minCost