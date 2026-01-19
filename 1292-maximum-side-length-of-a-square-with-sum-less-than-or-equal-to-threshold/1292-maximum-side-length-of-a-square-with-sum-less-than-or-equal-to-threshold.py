class Solution:
    def maxSideLength(self, mat: list[list[int]], threshold: int) -> int:
        m, n = len(mat), len(mat[0])

        pre = [[0] * (n + 1) for _ in range(m + 1)]
        for i in range(1, m + 1):
            for j in range(1, n + 1):
                pre[i][j] = pre[i-1][j] + pre[i][j-1] - pre[i-1][j-1] + mat[i-1][j-1]
        
        def is_valid_sq(x0, y0, x1, y1):
            return pre[x1][y1] - pre[x0-1][y1] - pre[x1][y0-1] + pre[x0-1][y0-1] <= threshold
        
        max_ans, ans = min(m, n), 0
        for i in range(1, m + 1):
            for j in range(1, n + 1):
                # try all possible side lengths of square starting from i,j index
                for s in range(ans + 1, max_ans + 1):
                    if i + s - 1 <= m and j + s - 1 <= n and is_valid_sq(i, j, i + s - 1, j + s - 1):
                        ans += 1
                    else:
                        break
        
        return ans