class Solution:
    def diagonalSum(self, mat: List[List[int]]) -> int:
        n, totalSum = len(mat)-1, 0
        for i in range(n+1):
            totalSum += mat[i][i]   # primary diagonal : left-top to right-down
            totalSum += mat[i][n-i] # secondary diagonal : right-top to left-down

        # if total rows count is odd, then we counted center cell twice
        if (n & 1) == 0:
            totalSum -= mat[n//2][n//2]
        
        return totalSum