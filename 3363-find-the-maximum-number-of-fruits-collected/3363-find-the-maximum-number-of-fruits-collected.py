# child at (0,0) has no other option but to cover diagonal
# child starting top right should not cross diagonal else it will need more steps than n-1
# child starting bottom left should not cross diagonal else it will need more steps than n-1
class Solution:
    def maxCollectedFruits(self, fruits: List[List[int]]) -> int:
        n, ans = len(fruits), 0
        for i in range(n):
            ans += fruits[i][i]  # fruits consumed by child at (0,0)
        ans += self.traverse(fruits)     # fruits consumed by child at (0, n-1)
        self.swapAcrossDiagonal(fruits)  # swap bottom left with upper right so that same traverse method can be used
        ans += self.traverse(fruits)     # fruits consumed by child at (n-1, 0)
        return ans
    
    def traverse(self, fruits: List[List[int]]) -> int:
        n = len(fruits)
        # instead of creating n x n dp array, we just care about prev row
        prev = [float('-inf')] * n
        prev[n-1] = fruits[0][n-1]  # we start from here, so we definitely have this fruit
        
        # i = how much we drift from last col
        for i in range(1, n-1):
            curr = [float('-inf')] * n
            startCol = max(n-1-i, i+1)    # we cannot drift more than mid col, else we need more steps than n-1
            for j in range(startCol, n):
                best = prev[j]
                if j-1 >= 0: best = max(best, prev[j-1])
                if j+1 < n: best = max(best, prev[j+1])
                curr[j] = best + fruits[i][j]
            prev = curr[:]
        
        return prev[n-1]
    
    def swapAcrossDiagonal(self, fruits: List[List[int]]) -> None:
        n = len(fruits)
        for i in range(n):
            for j in range(i):
                fruits[i][j], fruits[j][i] = fruits[j][i], fruits[i][j]