class Solution:
    def setZeroes(self, matrix: List[List[int]]) -> None:
        r, c = len(matrix), len(matrix[0])
        rows, cols = [False]*r, [False]*c

        # mark all rows & cols that need to be changed
        for i in range(r):
            for j in range(c):
                if matrix[i][j] == 0:
                    rows[i] = cols[j] = True

        # change all cols for a row
        for i in range(r):
            if rows[i]:
                for j in range(c): matrix[i][j] = 0

        # change all rows for a col
        for j in range(c):
            if cols[j]:
                for i in range(r): matrix[i][j] = 0
        