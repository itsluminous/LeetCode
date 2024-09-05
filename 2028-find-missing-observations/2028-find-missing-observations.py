class Solution:
    def missingRolls(self, rolls: List[int], mean: int, n: int) -> List[int]:
        expectedTotal = mean * (len(rolls) + n)
        currTotal = sum(rolls)
        remaining = expectedTotal - currTotal

        if remaining < n or remaining > n * 6: return []

        newMean, pending = remaining // n, remaining % n
        ans = [newMean] * n
        for i in range(pending): ans[i] += 1
        
        return ans