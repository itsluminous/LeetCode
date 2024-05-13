class Solution:
    def matrixScore(self, grid: List[List[int]]) -> int:
        m, n, halfRows = len(grid), len(grid[0]), (len(grid)+1)//2
        
        # row operation - make sure that we have 1st bit set (Most Significant Bit)
        # because `10000` is greater than `01111` in binary
        for i in range(m):
            if grid[i][0] == 1: continue
            for j in range(n): grid[i][j] ^= 1  # flip the bit

        # col operation - make sure that count of 1 in col is >= count of 0
        # exclude col-1 because we just now ensured that they are all 1
        for j in range(1,n):
            setBit = 0
            for i in range(m): setBit += grid[i][j]

            if setBit >= halfRows: continue
            for i in range(m): grid[i][j] ^= 1  # flip the bit

        # calculate score of matrix
        score = 0
        for i in range(m):
            binStr = ''.join(map(str, grid[i]))
            score += int(binStr, 2)   # binary to decimal conversion

        return score