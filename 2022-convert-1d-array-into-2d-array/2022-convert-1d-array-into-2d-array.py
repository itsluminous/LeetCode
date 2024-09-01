class Solution:
    def construct2DArray(self, original: List[int], m: int, n: int) -> List[List[int]]:
        leno, r, c = len(original), -1, 0
        if leno != m*n: return []

        matrix = [[0]*n for i in range(m)]
        for i in range(leno):
            if i % n == 0:
                r += 1
                c = 0
            matrix[r][c] = original[i]
            c += 1

        return matrix