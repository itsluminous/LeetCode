class Solution:
    def maxCount(self, banned: List[int], n: int, maxSum: int) -> int:
        bnd = set(banned)
        count = 0
        for num in range(1, n+1):
            if num in bnd: continue
            if maxSum - num < 0: break
            maxSum -= num
            count += 1
        
        return count