# intution is that (a - b) + (b - c) + (c - d) = (a - d)
# so as long as there exists a path between two numbers a and d
# we just need to find difference between them and see if that is highest
class Solution:
    def maxScore(self, grid: List[List[int]]) -> int:
        m, n = len(grid), len(grid[0])
        dp = [[float('-inf')] * n for _ in range(m)]  # dp to track biggest possible num accessible at each index
        dp[m-1][n-1] = grid[m-1][n-1]
        
        # find biggest possible num accessible at each index
        for i in range(m-1, -1, -1):
            for j in range(n-1, -1, -1):
                if i < m-1: dp[i][j] = max(dp[i][j], dp[i+1][j])
                if j < n-1: dp[i][j] = max(dp[i][j], dp[i][j+1])
                dp[i][j] = max(dp[i][j], grid[i][j])
        
        # for each index, find difference between curr number & biggest possible num we can reach from here
        maxVal = float('-inf')
        for i in range(m):
            for j in range(n):
                if i < m-1: maxVal = max(maxVal, dp[i+1][j] - grid[i][j])
                if j < n-1: maxVal = max(maxVal, dp[i][j+1] - grid[i][j])
        return maxVal