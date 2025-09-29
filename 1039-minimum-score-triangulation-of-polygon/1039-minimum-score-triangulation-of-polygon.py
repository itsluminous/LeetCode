class Solution:
    def minScoreTriangulation(self, values: List[int]) -> int:
        n = len(values)
        self.dp = [[0] * n for _ in range(n)]
        return self.dfs(values, 0, n - 1)

    def dfs(self, values, i, j):
        res = float('inf')
        if self.dp[i][j] != 0: return self.dp[i][j]  # already calculated weight
        if j - i < 2: return 0  # triangle not possible

        # try all triangles with two points as i and j and 3rd between them
        # https://leetcode.com/problems/minimum-score-triangulation-of-polygon/solutions/286753/c-with-picture
        for k in range(i + 1, j):
            curr = values[i] * values[j] * values[k]
            left = self.dfs(values, i, k)
            right = self.dfs(values, k, j)
            res = min(res, curr + left + right)

        self.dp[i][j] = res
        return res