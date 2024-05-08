class Solution:
    def uniquePaths(self, m: int, n: int) -> int:
        dp = [[1 for _ in range(n)] for _ in range(m)]

        # for every other cell, it can either be reached from above one or left one
        for i in range(1, m):
            for j in range(1, n):
                print(f'dp[{i}][{j}]')
                dp[i][j] = dp[i-1][j] + dp[i][j-1]
        
        return dp[-1][-1]