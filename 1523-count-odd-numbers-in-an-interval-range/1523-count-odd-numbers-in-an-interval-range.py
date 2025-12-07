class Solution:
    def countOdds(self, low: int, high: int) -> int:
        ans = (high - low) // 2
        if (low & 1) == 1 or (high & 1) == 1: ans += 1
        return ans