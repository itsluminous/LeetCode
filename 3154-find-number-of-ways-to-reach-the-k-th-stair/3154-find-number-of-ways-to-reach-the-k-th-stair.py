class Solution(object):
    def __init__(self):
        self.dp = {}
    
    def solve(self, k, i, jump, can):
        # Base cases
        if i > k + 5  or jump > 31: return 0

        # Check memoization
        if (i, jump, can) in self.dp:
            return self.dp[(i, jump, can)]
        
        ans = int(i == k) # If current step is the target
        
        # Recursive calls
        if can:
            ans += self.solve(k, i - 1, jump, 0)
        if 1 + (1 << jump) <= k+1:
            ans += self.solve(k, i + (1 << jump), jump + 1, 1)
        
        # Memoization
        self.dp[(i, jump, can)] = ans
        return ans
    
    def waysToReachStair(self, k):
        if k <= 1: return 2 ** (k + 1)
        return self.solve(k, 1, 0, 1)