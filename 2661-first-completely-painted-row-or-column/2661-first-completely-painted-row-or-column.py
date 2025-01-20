class Solution:
    def firstCompleteIndex(self, arr: List[int], mat: List[List[int]]) -> int:
        m, n = len(mat), len(mat[0])

        # pre-process the positions of the values in the matrix.
        pos = {}
        for i in range(m):
            for j in range(n):
                pos[mat[i][j]] = (i, j)
        
        # for each value in row, check if it fills row or col
        rows = [0] * m
        cols = [0] * n
        for i in range(len(arr)):
            r, c = pos[arr[i]]
            rows[r] += 1
            cols[c] += 1

            if rows[r] == n or cols[c] == m: return i
        return 0