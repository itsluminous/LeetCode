class Solution:
    def luckyNumbers (self, matrix: List[List[int]]) -> List[int]:
        m, n = len(matrix), len(matrix[0])
        rowMin = [0] * m
        ans = []

        for i in range(m):
            mn = matrix[i][0]
            for j in range(1, n):
                mn = min(mn, matrix[i][j])
            rowMin[i] = mn

        for j in range(n):
            mx = matrix[0][j]
            for i in range(1, m):
                mx = max(mx, matrix[i][j])
            
            for i in range(m):
                if rowMin[i] == mx:
                    ans.append(mx)
                    break

        return ans