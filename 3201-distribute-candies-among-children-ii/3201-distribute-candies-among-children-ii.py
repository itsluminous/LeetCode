class Solution:
    def distributeCandies(self, n: int, limit: int) -> int:
        ans = 0
        child1Min = max(0, n - 2 * limit)   # to ensure child2 & child3 are in limit
        child1Max = min(limit, n)           # cannot exceed limit

        for child1 in range(child1Min, child1Max+1):
            remaining = n - child1
            child2Min = max(0, remaining - limit)   # so that child3 is in limit
            child2Max = min(remaining, limit)       # ensure child2 is in limit
            ans += child2Max - child2Min + 1        # +1 because max & min range is inclusive
        return ans