# using 1d dp matrix
class Solution:
    def maximalSquare(self, matrix: List[List[str]]) -> int:
        m, n, max_val, diag = len(matrix), len(matrix[0]), 0, 0
        dp = [0]*(n+1)

        for i in range(m):
            for j in range(n):
                temp = dp[j+1]
                if matrix[i][j] == '1':
                    # min of diagonal-up, left, up
                    dp[j+1] = 1 + min(diag, dp[j+1], dp[j])
                    max_val = max(max_val, dp[j+1])
                else:
                    dp[j+1] = 0
                diag = temp
        
        return max_val * max_val    # area will be square

# Accepted using 2d dp matrix
class Solution2d:
    def maximalSquare(self, matrix: List[List[str]]) -> int:
        m, n, max_val = len(matrix), len(matrix[0]), 0
        dp = [[0]*(n+1) for _ in range(m+1)]

        for i in range(m):
            for j in range(n):
                if matrix[i][j] == '1':
                    # min of diagonal-up, left, up
                    dp[i+1][j+1] = 1 + min(dp[i][j], dp[i][j+1], dp[i+1][j])
                max_val = max(max_val, dp[i+1][j+1])
        
        return max_val * max_val    # area will be square
