class Solution:
    def numMagicSquaresInside(self, grid: List[List[int]]) -> int:
        row, col = len(grid), len(grid[0])
        if row < 3 or col < 3: return 0

        count = 0
        for i in range(row - 2):
            for j in range(col - 2):
                count += self.isMagicSquare(grid, i, j)
        
        return count
    
    def isMagicSquare(self, grid: List[List[int]], x: int, y: int) -> int:
        diag1 = grid[x][y] + grid[x+1][y+1] + grid[x+2][y+2]
        diag2 = grid[x][y+2] + grid[x+1][y+1] + grid[x+2][y]

        if diag1 != diag2: return 0

        # calculate row & col sum
        seen = [False] * 10
        rowsum, colsum = [0] * 3, [0] * 3

        for i in range(3):
            for j in range(3):
                num = grid[x+i][y+j]
                if num == 0 or num > 9 or seen[num]: return 0
                seen[num] = True
                rowsum[i] += num
                colsum[j] += num

        if rowsum[0] != diag1 or rowsum[1] != diag1 or rowsum[2] != diag1: return 0
        if colsum[0] != diag1 or colsum[1] != diag1 or colsum[2] != diag1: return 0

        return 1